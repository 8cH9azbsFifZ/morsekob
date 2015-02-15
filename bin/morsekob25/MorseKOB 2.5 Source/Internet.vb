'   Copyright © 2009 Les Kerr

'   This file is part of MorseKOB.

'   MorseKOB is free software: you can redistribute it and/or modify
'   it under the terms of the GNU General Public License as published by
'   the Free Software Foundation, either version 3 of the License, or
'   (at your option) any later version.

'   MorseKOB is distributed in the hope that it will be useful,
'   but WITHOUT ANY WARRANTY; without even the implied warranty of
'   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'   GNU General Public License for more details.

'   You should have received a copy of the GNU General Public License
'   along with MorseKOB.  If not, see <http://www.gnu.org/licenses/>.

'   For more information about MorseKOB see <http://morsekob.org>.

Imports System.Net.Sockets
Imports System.Threading
Imports VB = Microsoft.VisualBasic
Imports MorseKOB.Main

Module Internet
    Private Const conRemotePort = 7890     ' UDP port number for CWCom server
    Private Const conIDInterval = 10000    ' 10 seconds between ID packets
    Public conPacketReps As Integer = 2    ' Number of duplicate code packets to send

    Public remHost As String = ""          ' Remote host address or name
    Private chan As Integer = 0            ' CWCom channel
    Private strRemoteID As String = ""     ' ID of station currently sending
    Private intPacketsSent As Integer = 0  ' Count of UDP packets sent
    Private intLastRcvdPckt As Integer = 0 ' Number of last code packet received
    Private lrInput As LongRecord          ' 496-byte input record
    Private lrInputCode(50) As Integer
    Private lrOutput As LongRecord         ' 496-byte output record
    Private lrOutputCode(50) As Integer
    Private lrOutCodeBuf(495) As Byte      ' Code record output buffer
    Public intConnState As Integer = 0     ' 0: Disconnected, 1: Connected, 2: Waiting
    Private blnXmtCktClosed As Boolean     ' Key closed longer than 1000 ms
    Private Const MaxIDs = 50              ' Maximum number of stations in ID list
    Public nIDs As Integer                 ' Current number of stations in ID list
    Public IDList(MaxIDs) As String        ' Stations in ID list
    Public IDVersion(MaxIDs) As String     ' Version number of sender's KOB software
    Public IDTime(MaxIDs) As Date          ' Time that ID was last refreshed
    Public rcvState As Boolean = True      ' Incoming state of the internet wire
    Public dspyVersions As Boolean = False ' Include version numbers in the ID window
    Public dspyPcktData As Boolean = False ' Display timing data of received packets

    'Private Structure ShortRecord
    '    Dim CmdCode As Short
    '    Dim Channel As Short
    'End Structure

    Private Structure LongRecord
        Dim CmdCode As Short
        Dim Length As Short
        Dim ID As String  ' 128 bytes
        Dim Unknown_1 As Integer
        Dim PacketNo As Integer
        Dim Unknown_2 As Integer  ' 0 for data, 1 for ID
        Dim Unknown_3 As Integer  ' 755 (1000?)
        Dim Unknown_4 As Integer  ' 16777215 for data, 65535 for ID
        'Dim Code() As Integer  ' ReDim (50)
        Dim CodeElements As Integer
        Dim Txt As String  ' 128 bytes
        Dim Unknown_5 As Integer
        Dim Unknown_6 As Integer
    End Structure

    Private udpSocket As UdpClient
    Private endPoint As System.Net.IPEndPoint
    Public WithEvents tmrSendID As New System.Timers.Timer
    Private WithEvents tmrTimeOut As New System.Timers.Timer
    Private thdRcvLoop As Thread

    Public Sub ToggleConnect()
        If intConnState = 0 Then
            If Not KOB.localState Then
                Main.chkCircuitCloser.Checked = True
            End If
            Connect()
            thdRcvLoop = New Thread(AddressOf RcvLoop)
            Timing.StartThread(thdRcvLoop, ThreadPriority.AboveNormal)
        Else
            thdRcvLoop.Abort()
            Disconnect()
        End If
    End Sub

    Public Sub Connect()
        If SetupConnection() Then
            intConnState = 2
            rcvState = True
            blnXmtCktClosed = True
            tmrSendID.Interval = 1
            tmrSendID.Start()
        Else
            MsgBox("Can't set up Internet connection.")
        End If
    End Sub

    Public Sub Disconnect()
        intConnState = 0
        rcvState = True
        tmrSendID.Stop()
        tmrTimeOut.Stop()
        SendShortPacket(2)  ' Disconnect
        Main.txtDisplay.Refresh()
        Try
            udpSocket.Close()
        Catch ex As Exception
            MsgBox("Can't close socket. " & ex.Message)
        End Try
        nIDs = 0
    End Sub

    Public Sub ChangeChannel(ByVal ch As Integer)
        chan = ch
        tmrSendID.Interval = 1
        nIDs = 0
    End Sub

    Private Sub RcvLoop()
        Dim bytBuffer() As Byte
        Dim bytesTotal As Integer
        Dim intCommand As Integer
        Dim I1 As Integer
        Static PacketReps As Integer = 0

        Do
            Try
                bytBuffer = udpSocket.Receive(endPoint)
            Catch ex As Exception
                If intConnState <> 0 Then
                    My.Computer.Audio.Play(My.Resources.Server_Error, AudioPlayMode.Background)
                    Main.DisplayText(vbCrLf & "<Server error. " & ex.Message & ">")
                    Try
                        udpSocket = New UdpClient(remHost, conRemotePort)
                    Catch ex1 As Exception
                        Dbg("Can't reconnect to server. " & ex1.Message)
                    End Try
                End If
                Dim nullArray As Byte() = {0}
                bytBuffer = nullArray
                Thread.Sleep(500)
            End Try
            bytesTotal = bytBuffer.Length
            If bytesTotal = 2 Or bytesTotal = 4 Or bytesTotal = 496 Then
                If intConnState = 2 Then
                    intConnState = 1
                End If
                tmrTimeOut.Stop()
                tmrTimeOut.Interval = 64000
                tmrTimeOut.Start()
                intCommand = UnpackShort(bytBuffer, 0)
                If dspyPcktData Then
                    Main.DisplayText(vbCrLf & "<Received packet type " & intCommand.ToString & ">")
                End If
                Select Case intCommand
                    Case 2  ' Disconnect
                        If intConnState = 1 Then
                            intConnState = 2
                        End If
                    Case 3  ' Data
                        UnpackLongRecord(bytBuffer)
                        If intConnState <> 0 Then
                            If lrInput.CodeElements = 0 Then  ' ID packet
                                If lrInput.ID = strRemoteID Then
                                    If lrInput.PacketNo < intLastRcvdPckt Or _
                                            lrInput.PacketNo > intLastRcvdPckt + 2 Then  ' ID sequence error
                                        If Main.blnDebug Then
                                            Main.DisplayText("º")  ' This is actually an underlined °
                                        End If
                                    End If
                                    intLastRcvdPckt = lrInput.PacketNo
                                End If
                                UpdateIDs(lrInput.ID, lrInput.Txt)
                            Else  ' Code packet
                                If lrInput.ID <> strRemoteID Then
                                    UpdateSender(lrInput.ID)
                                    intLastRcvdPckt = lrInput.PacketNo - 1
                                End If
                                If lrInput.PacketNo < intLastRcvdPckt Then  ' Out of order packet
                                    If Main.blnDebug Then
                                        Main.DisplayText("°")
                                    End If
                                ElseIf lrInput.PacketNo = intLastRcvdPckt Then  ' Duplicate packet
                                    PacketReps += 1
                                Else  ' New data packet
                                    If lrInput.PacketNo <> intLastRcvdPckt + 1 Then  ' Missing packet(s)
                                        Main.DisplayText("* ")
                                    End If
                                    intLastRcvdPckt = lrInput.PacketNo
                                    For I1 = 0 To lrInput.CodeElements - 1
                                        If lrInputCode(I1) < -3000 Then
                                            lrInputCode(I1) = -150  ' long enough for TTY char
                                        End If
                                        ReceiveElement(lrInputCode(I1))
                                    Next I1
                                    If dspyPcktData Then
                                        Main.DisplayText(vbCrLf & "<Rcvd ")
                                        For I1 = 0 To lrInput.CodeElements - 1
                                            If I1 > 0 Then
                                                Main.DisplayText(", ")
                                            End If
                                            Main.DisplayText(lrInputCode(I1))
                                        Next I1
                                        Main.DisplayText(">")
                                    End If
                                    If PacketReps = 1 And Main.blnDebug Then
                                        Main.DisplayText("^")
                                    End If
                                    PacketReps = 1
                                End If
                            End If
                        End If
                    Case 4  ' Connect
                        If intConnState <> 0 Then
                            intConnState = 1
                        End If
                    Case 5  ' Null (aka Ack)
                    Case Else
                        Dbg("Unrecognized command")
                End Select
            Else
                Dbg("Unexpected record length: " & bytesTotal)
            End If
        Loop
    End Sub

    Private Sub RcvWait(ByVal dt As Integer)
        Static t0 As Integer = Timing.GetTime()

        Dim t As Integer = Timing.GetTime()
        Dim dtMax As Integer = 10 * dotLen
        If dt > dtMax Then
            dt = dtMax
            t0 = t + dtMax
        Else
            t0 += dt
            dt = t0 - t
            If dt < 0 Then
                dt = 0
                t0 = t
            End If
        End If
        Thread.Sleep(dt)
    End Sub

    Private Sub ReceiveElement(ByVal c As Integer)
        Debug.SaveTiming(c)
        If c > 0 Then  ' mark
            rcvState = True
            If c > 2 Then  ' ignore timing delays for +1 and +2
                RcvWait(c)
            End If
            If c > 1 Then  ' if 1 ms mark then leave circuit closed
                rcvState = False
            End If
        Else  ' space
            RcvWait(-c)
        End If
    End Sub

    Public Sub SetXmtState(ByVal S As Boolean, ByVal t As Integer)
        Static pending As Boolean = False  ' waiting to send a pending packet
        Static tSend As Integer = t  ' time to send pending packet
        'Static latched As Boolean = False  ' circuit has been latched in mark (true) state
        Static latched As Boolean = True  ' circuit has been latched in mark (true) state
        Static sLast As Boolean = True  ' state of last transition
        Static tLast As Integer = t  ' time of last transition
        Dim deltaT As Integer  ' time since last transition

        If intConnState = 0 Then Exit Sub
        If pending And t >= tSend Then  ' send the pending packet
            If sLast And Not latched Then
                SendCodeElement(+1)
                latched = True
            End If
            SendCodePacket()
            pending = False
        ElseIf sLast <> S Then
            sLast = S
            deltaT = t - tLast
            tLast = t
            If S Then  ' End of space
                SendCodeElement(-deltaT)
                If Not Debug.ttyMode Then
                    pending = False
                End If
            Else  ' End of mark
                If latched Then
                    SendCodeElement(-deltaT)
                    SendCodeElement(+2)  ' 2 ms mark: end circuit closure
                    latched = False
                Else
                    SendCodeElement(deltaT)
                End If
                If Not pending Then
                    pending = True
                    If Debug.ttyMode Then
                        tSend = t + 7 * 22
                    Else
                        tSend = t + 2 * dotLen
                    End If
                End If
            End If
        ElseIf t > tLast + 10 * dotLen And sLast And Not latched Then  ' latch long mark
            SendCodeElement(+1)
            latched = True
            SendCodePacket()
        End If
    End Sub

    Private Sub SendCodeElement(ByVal DeltaT As Integer)
        With lrOutput
            '.Code(.CodeElements) = DeltaT
            lrOutputCode(.CodeElements) = DeltaT
            .CodeElements = .CodeElements + 1
            If .CodeElements = 50 Then
                SendCodePacket()
            End If
        End With
    End Sub

    Public Sub SendIDPacket()
        Dim buf(495) As Byte

        If lrOutput.ID = "" Then
            lrOutput.ID = "No ID"
        End If
        UpdateIDs(lrOutput.ID, Main.kobVersion)
        intPacketsSent += 1
        For i As Integer = 0 To 495
            buf(i) = 0
        Next
        PackShort(buf, 0, 3)  ' Command code
        PackShort(buf, 2, 492)  ' Length
        PackString(buf, 4, lrOutput.ID)
        PackInteger(buf, 136, intPacketsSent)
        PackInteger(buf, 140, 1)
        PackInteger(buf, 144, 755)
        PackInteger(buf, 148, 65535)
        PackString(buf, 360, Main.kobVersion)
        Try
            udpSocket.Send(buf, 496)
        Catch ex As Exception
            Dbg("Can't send ID packet. " & ex.Message)
        End Try
    End Sub

    Private Sub SendCodePacket()
        If dspyPcktData Then
            Main.DisplayText(vbCrLf & "<Sent ")
            For I1 As Integer = 0 To lrOutput.CodeElements - 1
                If I1 > 0 Then
                    Main.DisplayText(", ")
                End If
                Main.DisplayText(lrOutputCode(I1))
            Next I1
            Main.DisplayText(">")
        End If
        If lrOutput.ID = "" Then
            lrOutput.ID = "No ID"
        End If
        UpdateIDs(lrOutput.ID, Main.kobVersion)
        intPacketsSent += 1
        lrOutput.PacketNo = intPacketsSent
        PackLongRecord()
        For i As Integer = 1 To conPacketReps
            Try
                udpSocket.Send(lrOutCodeBuf, 496)
            Catch ex As Exception
                Dbg("Can't send code packet. " & ex.Message)
            End Try
        Next i
        lrOutput.CodeElements = 0
        If lrOutput.ID <> strRemoteID Then
            UpdateSender(lrOutput.ID)
        End If
    End Sub

    Private Sub PackLongRecord()
        With lrOutput
            PackShort(lrOutCodeBuf, 0, .CmdCode)
            PackShort(lrOutCodeBuf, 2, .Length)
            If lrOutput.ID = "" Then
                lrOutput.ID = "No ID"
            End If
            PackString(lrOutCodeBuf, 4, .ID)
            PackInteger(lrOutCodeBuf, 132, .Unknown_1)
            PackInteger(lrOutCodeBuf, 136, .PacketNo)
            PackInteger(lrOutCodeBuf, 140, .Unknown_2)
            PackInteger(lrOutCodeBuf, 144, .Unknown_3)
            PackInteger(lrOutCodeBuf, 148, .Unknown_4)
            For i As Integer = 0 To 50
                PackInteger(lrOutCodeBuf, 152 + 4 * i, lrOutputCode(i))
            Next
            PackInteger(lrOutCodeBuf, 356, .CodeElements)
            PackString(lrOutCodeBuf, 360, .Txt)
            PackInteger(lrOutCodeBuf, 488, .Unknown_5)
            PackInteger(lrOutCodeBuf, 492, .Unknown_6)
        End With
    End Sub

    Private Sub SendShortPacket(ByVal cmdCode As Integer)
        Dim buf(3) As Byte

        intPacketsSent += 1
        PackShort(buf, 0, cmdCode)
        PackShort(buf, 2, chan)
        Try
            udpSocket.Send(buf, 4)
        Catch ex As Exception
            Dbg("Can't send short packet. " & ex.Message)
        End Try
    End Sub

    Private Function SetupConnection() As Boolean
        With lrOutput
            .CmdCode = 3
            .Length = 492
            .CodeElements = 0
            .Txt = ""
            .Unknown_1 = 0
            .Unknown_2 = 0
            .Unknown_3 = 755
            .Unknown_4 = 16777215
            .Unknown_5 = 0
            .Unknown_6 = 0
        End With
        Try
            udpSocket = New UdpClient(remHost, conRemotePort)
        Catch ex As Exception
            Dbg("Can't create new UDP client. " & ex.Message)
            SetupConnection = False
            Exit Function
        End Try
        SetupConnection = True
    End Function

    Public Sub SetID(ByVal strID As String)
        If strID = "" Then
            Dbg("Blank ID ignored.")
        Else
            lrOutput.ID = strID
        End If
    End Sub

    Private Sub UpdateIDs(ByVal strID As String, ByVal strVersion As String)
        Dim I As Integer

        I = nIDs
        Do While I > 0
            If IDList(I) = strID Then
                Exit Do
            End If
            I -= 1
        Loop
        If I = 0 Then
            If nIDs < MaxIDs Then
                nIDs += 1
            End If
            IDList(nIDs) = strID
            I = nIDs
        End If
        IDVersion(I) = Mid(strVersion, Len("MorseKOB ") + 1)
        IDTime(I) = Now
    End Sub

    Public Sub DisplayIDs()
        Dim S As String = ""
        Dim I As Integer
        Dim expirationTime As Date

        expirationTime = DateAdd(DateInterval.Second, -60, Now)  ' Drop after 60 seconds
        I = nIDs
        Do While I > 0
            If IDTime(I) < expirationTime Then
                Exit Do
            End If
            I -= 1
        Loop
        If I > 0 Then
            For I = I To nIDs - 1
                IDList(I) = IDList(I + 1)
                IDVersion(I) = IDVersion(I + 1)
                IDTime(I) = IDTime(I + 1)
            Next
            nIDs -= 1
        End If
        For I = 1 To nIDs
            S &= IDList(I)
            If dspyVersions Then
                S &= " " & IDVersion(I)
            End If
            S &= vbCrLf
        Next
        Main.txtIDs.Text = S
        Main.txtIDs.SelectionLength = 0
    End Sub

    Private Sub UpdateSender(ByVal strSender As String)
        strRemoteID = strSender
        Main.DisplayText(vbCrLf & "<" & strSender & ">")
        Dim I As Integer = nIDs
        Do While I > 0
            If IDList(I) = strSender Then
                Exit Do
            End If
            I -= 1
        Loop
        If I = 0 Then
            Dbg("Sender not already in ID list")
        Else
            Dim vsn As String = IDVersion(I)
            For I = I To nIDs - 1
                IDList(I) = IDList(I + 1)
                IDVersion(I) = IDVersion(I + 1)
                IDTime(I) = IDTime(I + 1)
            Next
            IDList(nIDs) = strSender
            IDVersion(nIDs) = vsn
            IDTime(nIDs) = Now
        End If
    End Sub

    Private Sub PackShort(ByRef buf() As Byte, ByVal i As Integer, ByVal x As Short)
        For j As Integer = 1 To 2
            buf(i + j - 1) = x And &HFF
            x >>= 8
        Next
    End Sub

    Private Sub PackInteger(ByRef buf() As Byte, ByVal i As Integer, ByVal x As Integer)
        For j As Integer = 1 To 4
            buf(i + j - 1) = x And &HFF
            x >>= 8
        Next
    End Sub

    Private Sub PackString(ByRef buf() As Byte, ByVal i As Integer, ByVal s As String)
        For j As Integer = 1 To Len(s)
            buf(i + j - 1) = Asc(Mid(s, j, 1))
        Next
        buf(i + Len(s)) = 0
    End Sub

    Private Sub UnpackLongRecord(ByRef buf() As Byte)
        With lrInput
            .CmdCode = UnpackShort(buf, 0)
            .Length = UnpackShort(buf, 2)
            .ID = UnpackString(buf, 4)
            .Unknown_1 = UnpackInteger(buf, 132)
            .PacketNo = UnpackInteger(buf, 136)
            .Unknown_2 = UnpackInteger(buf, 140)
            .Unknown_3 = UnpackInteger(buf, 144)
            .Unknown_4 = UnpackInteger(buf, 148)
            For i As Integer = 0 To 50
                lrInputCode(i) = UnpackInteger(buf, 152 + 4 * i)
            Next
            .CodeElements = UnpackInteger(buf, 356)
            .Txt = UnpackString(buf, 360)
            .Unknown_5 = UnpackInteger(buf, 488)
            .Unknown_6 = UnpackInteger(buf, 492)
        End With
    End Sub

    Private Function UnpackShort(ByRef buf() As Byte, ByVal i As Integer) As Short
        Dim x As Short = 0
        For j As Integer = 1 To 2
            x <<= 8
            x += buf(i + 2 - j)
        Next
        UnpackShort = x
    End Function

    Private Function UnpackInteger(ByRef buf() As Byte, ByVal i As Integer) As Integer
        Dim x As Integer = 0
        For j As Integer = 1 To 4
            x <<= 8
            x += buf(i + 4 - j)
        Next
        UnpackInteger = x
    End Function

    Private Function UnpackString(ByRef buf() As Byte, ByVal i As Integer) As String
        Dim s As String = ""
        For j As Integer = 1 To 127
            If buf(i + j - 1) = 0 Then Exit For
            s &= Chr(buf(i + j - 1))
        Next
        UnpackString = s
    End Function

    Private Sub tmrSendID_Elapsed(ByVal sender As Object, _
            ByVal e As System.Timers.ElapsedEventArgs) Handles tmrSendID.Elapsed
        tmrSendID.Interval = conIDInterval
        SendShortPacket(4)  ' Connect request
        SendIDPacket()
    End Sub

    Private Sub tmrTimeOut_Elapsed(ByVal sender As Object, _
            ByVal e As System.Timers.ElapsedEventArgs) Handles tmrTimeOut.Elapsed
        tmrTimeOut.Stop()
        If intConnState = 1 Then
            intConnState = 2
        End If
    End Sub

    Private Sub SendTTY(ByVal c As Short())
        For i As Integer = 0 To c.GetUpperBound(0)
            SendCodeElement(c(i))
        Next
        SendCodePacket()
    End Sub
End Module
