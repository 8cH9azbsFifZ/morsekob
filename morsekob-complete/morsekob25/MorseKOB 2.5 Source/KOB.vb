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

Imports DS = Microsoft.DirectX.DirectSound
Imports MorseKOB.Main

Module KOB
    Const Debounce = 25  ' contact debounce delay (ms)

    Public Enum PaddleState
        Off
        Dot
        Dash
    End Enum

    Public dotLen As Integer = 50
    Private portSerial As New SerPort
    Public portMode As Integer = 0  ' 0: Normal, 1: Keyer, 2: Loop, 3: Modem
    Private clickSound As System.IO.UnmanagedMemoryStream
    Private clackSound As System.IO.UnmanagedMemoryStream
    Public directSound As Boolean = True
    Private sndDevice As DS.Device
    Private bufClick As DS.Buffer
    Private bufClack As DS.Buffer
    Private intSounder As Integer = 0
    Public cktCloserState As Boolean = False
    Private keyState As Boolean = False
    Public keyerPaddle As PaddleState = PaddleState.Off
    Public noiseFilter As Integer = 15  ' threshold for ignoring noise spikes in Loop and Modem mode (ms)
    Public noisePulseWidth As Integer = 0
    Public noisePulseCount As Integer = 0
    Public localState As Boolean = False  ' combined state of key, code sender, and circuit closer
    Private loopState As Boolean = True  ' state of "remote" external key (e.g., dialup modem)
    Public thdKOBLoop As New System.Threading.Thread(AddressOf KOBLoop)

    Friend Declare Function GetDesktopWindow Lib "user32.dll" () As Integer

    Public Sub SetSerialPort(ByVal comPort As String)
        Static cp As String = ""

        If cp <> comPort Then
            cp = comPort
            portSerial.OpenPort(comPort)
            portSerial.DTR = True
            portSerial.RTS = False
        End If
    End Sub

    Private Sub KOBLoop()
        Static t0 As Integer = Timing.GetTime()
        Dim dt As Integer = 0
        Dim t As Integer

        Do
            t = Timing.GetTime()
            dt = t - t0
            t0 = t
            If dt > Timing.intervalHWM Then
                Timing.intervalHWM = dt
            End If
            Timing.StartDwellTimer()
            GetLoopState(t)
            GetKeyerState(t)
            localState = keyState Or CodeSender.OutState Or cktCloserState
            SaveTiming(localState And loopState, t)
            SetIntSounder(localState And loopState And Internet.rcvState)
            SetLoopState(localState And Internet.rcvState)
            Internet.SetXmtState(localState And loopState, t)
            CodeReader.SetState(localState And loopState And Internet.rcvState, t)
            Timing.StopDwellTimer()
            System.Threading.Thread.Sleep(1)
        Loop
    End Sub

    Public Sub GetLoopState(ByVal t As Integer)
        Static dsrContact As Boolean = False
        Static ctsContact As Boolean = False
        Static tdsrContact As Integer = t - Debounce
        Static tctsContact As Integer = t - Debounce
        Static pending As Boolean = False
        Static t0 As Integer = Timing.GetTime()
        Dim s As Boolean

        If portMode < 2 Then  ' debounce contacts
            If t - tdsrContact > Debounce Then
                s = portSerial.DSR
                If dsrContact <> s Then
                    dsrContact = s
                    tdsrContact = t
                    If portMode = 1 Then  ' Keyer
                        If dsrContact Then
                            keyerPaddle = PaddleState.Dot
                        ElseIf keyerPaddle = PaddleState.Dot Then
                            keyerPaddle = PaddleState.Off
                        End If
                    ElseIf portMode = 0 Then  ' Manual
                        If dsrContact Then
                            keyerPaddle = PaddleState.Dash
                        ElseIf keyerPaddle = PaddleState.Dash Then
                            keyerPaddle = PaddleState.Off
                        End If
                    Else
                        keyerPaddle = PaddleState.Off
                    End If
                End If
            End If
            If t - tctsContact > Debounce Then
                s = portSerial.CTS
                If ctsContact <> s Then
                    ctsContact = s
                    tctsContact = t
                    If portMode = 1 Then  ' Keyer
                        If ctsContact Then
                            keyerPaddle = PaddleState.Dash
                        ElseIf keyerPaddle = PaddleState.Dash Then
                            keyerPaddle = PaddleState.Off
                        End If
                    End If
                End If
            End If
            loopState = True
        Else  ' filter out noise pulses
            s = portSerial.DSR
            If Not pending And s <> loopState Then
                pending = True
                t0 = t
            ElseIf pending And t > t0 + noiseFilter Then
                loopState = s
                pending = False
            ElseIf pending And s = loopState Then
                pending = False
                noisePulseWidth = t - t0
                noisePulseCount += 1
            End If
        End If
    End Sub

    Public Sub SetLoopState(ByVal s As Boolean)
        Static loopState As Boolean = False

        If loopState <> s Then
            loopState = s
            portSerial.RTS = loopState
        End If
    End Sub

    Private Sub GetKeyerState(ByVal t As Integer)
        Static sendingDots As Boolean = False
        Static forceDot As Boolean = False
        Static tWait As Integer = t
        Static lastPaddle As PaddleState = PaddleState.Off

        If keyerPaddle <> lastPaddle And keyerPaddle = PaddleState.Dot Then
            forceDot = True
        End If
        lastPaddle = keyerPaddle
        If sendingDots Then
            If t >= tWait Then
                If keyState Then
                    keyState = False
                    tWait += dotLen
                Else
                    If keyerPaddle = PaddleState.Dot Or forceDot Then
                        keyState = True
                        tWait += dotLen
                        forceDot = False
                    Else
                        sendingDots = False
                    End If
                End If
            End If
        Else
            If keyerPaddle = PaddleState.Dash Then
                keyState = True
            ElseIf keyState Then
                keyState = False
                tWait = t + dotLen
            ElseIf forceDot Then
                sendingDots = True
                If tWait < t Then
                    tWait = t
                End If
            End If
        End If
    End Sub

    Public Sub SetIntSounderType(ByVal sdr As Integer)
        Static bufDescClick As DS.BufferDescription
        Static bufDescClack As DS.BufferDescription

        If sdr > 0 And directSound Then
            sndDevice = New DS.Device()
            sndDevice.SetCooperativeLevel(Main, DS.CooperativeLevel.Priority)
            bufDescClick = New DS.BufferDescription()
            bufDescClick.ControlEffects = False  ' necessary because .wav file is so short
            bufDescClick.GlobalFocus = True  ' to enable audio when program is in background
            bufDescClack = New DS.BufferDescription()
            bufDescClack.ControlEffects = False
            bufDescClack.GlobalFocus = True
            Select Case sdr
                Case 1
                    bufClick = New DS.Buffer(My.Resources.Click_1, bufDescClick, sndDevice)
                    bufClack = New DS.Buffer(My.Resources.Clack_1, bufDescClack, sndDevice)
                Case 2
                    bufClick = New DS.Buffer(My.Resources.Click_2, bufDescClick, sndDevice)
                    bufClack = New DS.Buffer(My.Resources.Clack_3, bufDescClack, sndDevice)
                Case 3
                    bufClick = New DS.Buffer(My.Resources.Click_3, bufDescClick, sndDevice)
                    bufClack = New DS.Buffer(My.Resources.Clack_3, bufDescClack, sndDevice)
                Case 4
                    bufClick = New DS.Buffer(My.Resources.Click_4, bufDescClick, sndDevice)
                    bufClack = New DS.Buffer(My.Resources.Clack_4, bufDescClack, sndDevice)
                Case 5
                    bufClick = New DS.Buffer(My.Resources.Click_5, bufDescClick, sndDevice)
                    bufClack = New DS.Buffer(My.Resources.Clack_5, bufDescClack, sndDevice)
                Case 6
                    bufClick = New DS.Buffer(My.Resources.Click_6, bufDescClick, sndDevice)
                    bufClack = New DS.Buffer(My.Resources.Clack_6, bufDescClack, sndDevice)
                Case 7
                    bufClick = New DS.Buffer(My.Resources.Click_7, bufDescClick, sndDevice)
                    bufClack = New DS.Buffer(My.Resources.Clack_7, bufDescClack, sndDevice)
                Case 8
                    bufClick = New DS.Buffer(My.Resources.Click_8, bufDescClick, sndDevice)
                    bufClack = New DS.Buffer(My.Resources.Clack_8, bufDescClack, sndDevice)
            End Select
        End If
        intSounder = sdr
    End Sub

    Public Sub SetIntSounder(ByVal s As Boolean)
        Static sounderState As Boolean = False

        If sounderState <> s Then
            sounderState = s
            If intSounder > 0 Then
                If sounderState Then
                    If directSound Then
                        bufClick.Stop()  ' test
                        bufClack.Stop()  ' test
                        bufClick.SetCurrentPosition(0)  ' test
                        bufClick.Play(0, DS.BufferPlayFlags.Default)
                    Else
                        Select Case intSounder
                            Case 1
                                My.Computer.Audio.Play(My.Resources.Click_1, AudioPlayMode.Background)
                            Case 2
                                My.Computer.Audio.Play(My.Resources.Click_2, AudioPlayMode.Background)
                            Case 3
                                My.Computer.Audio.Play(My.Resources.Click_3, AudioPlayMode.Background)
                            Case 4
                                My.Computer.Audio.Play(My.Resources.Click_4, AudioPlayMode.Background)
                            Case 5
                                My.Computer.Audio.Play(My.Resources.Click_5, AudioPlayMode.Background)
                            Case 6
                                My.Computer.Audio.Play(My.Resources.Click_6, AudioPlayMode.Background)
                            Case 7
                                My.Computer.Audio.Play(My.Resources.Click_7, AudioPlayMode.Background)
                            Case 8
                                My.Computer.Audio.Play(My.Resources.Click_8, AudioPlayMode.Background)
                        End Select
                    End If
                Else
                    If directSound Then
                        If intSounder = 2 Or intSounder = 3 Then  ' Tone or Mixed
                            bufClick.Stop()
                            bufClick.SetCurrentPosition(0)
                        End If
                        If intSounder <> 2 Then  ' if not Tone
                            bufClick.Stop()  ' test
                            bufClack.Stop()  ' test
                            bufClack.SetCurrentPosition(0)  ' test
                            bufClack.Play(0, DS.BufferPlayFlags.Default)
                        End If
                    Else
                        Select Case intSounder
                            Case 1
                                My.Computer.Audio.Play(My.Resources.Clack_1, AudioPlayMode.Background)
                            Case 2
                                My.Computer.Audio.Play(My.Resources.Clack_2, AudioPlayMode.Background)
                            Case 3
                                My.Computer.Audio.Play(My.Resources.Clack_3, AudioPlayMode.Background)
                            Case 4
                                My.Computer.Audio.Play(My.Resources.Clack_4, AudioPlayMode.Background)
                            Case 5
                                My.Computer.Audio.Play(My.Resources.Clack_5, AudioPlayMode.Background)
                            Case 6
                                My.Computer.Audio.Play(My.Resources.Clack_6, AudioPlayMode.Background)
                            Case 7
                                My.Computer.Audio.Play(My.Resources.Clack_7, AudioPlayMode.Background)
                            Case 8
                                My.Computer.Audio.Play(My.Resources.Clack_8, AudioPlayMode.Background)
                        End Select
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub SaveTiming(ByVal s As Boolean, ByVal t As Integer)
        Static sLast As Boolean = False
        Static tLast As Integer = Timing.GetTime()
        Dim dt As Integer

        If s <> sLast Then
            sLast = s
            dt = t - tLast
            If dt > 10000 Then
                dt = 10000
            End If
            tLast = t
            If s Then
                dt = -dt
            End If
            Debug.SaveTiming(dt)
        End If
    End Sub
End Module

Class SerPort
    Const SETRTS = 3
    Const CLRRTS = 4
    Const SETDTR = 5
    Const CLRDTR = 6
    Const MS_CTS_ON = &H10&
    Const MS_DSR_ON = &H20&
    Const GENERIC_READ As Integer = &H80000000
    Const GENERIC_WRITE As Integer = &H40000000
    Const OPEN_EXISTING As Integer = 3
    Const FILE_ATTRIBUTE_NORMAL As Integer = &H80

    Private hSerialPort As Integer = -1

    Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, _
        ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByVal lpSecurityAttributes As Integer, _
        ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, _
        ByVal hTemplateFile As Integer) As Integer
    Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" (ByVal hObject As Integer) As Integer
    Declare Function EscapeCommFunction Lib "kernel32" Alias "EscapeCommFunction" (ByVal nCid As Integer, _
        ByVal nFunc As Integer) As Integer
    Declare Function GetCommModemStatus Lib "kernel32" Alias "GetCommModemStatus" (ByVal hFile As Integer, _
        ByRef lpModemStat As Integer) As Integer
    Declare Function GetLastError Lib "kernel32" Alias "GetLastError" () As Integer

    Public Sub OpenPort(ByVal comPort As String)
        ClosePort()
        If comPort <> "None" Then
            hSerialPort = CreateFile(comPort, GENERIC_READ Or GENERIC_WRITE, 0, 0, OPEN_EXISTING, _
                    FILE_ATTRIBUTE_NORMAL, 0)
            If hSerialPort = -1 Then
                Dbg("Unable to obtain a handle to the COM port. " & GetLastError())
                MsgBox("Unable to open serial port " & comPort & "." & vbCrLf _
                       & "It may be in use by another application.")
            End If
        End If
    End Sub

    Public Sub ClosePort()
        If hSerialPort <> -1 Then
            If CloseHandle(hSerialPort) = False Then
                Dbg("Unable to release handle to COM port. " & GetLastError())
            End If
            hSerialPort = -1
        End If
    End Sub

    WriteOnly Property RTS()
        Set(ByVal value)
            If hSerialPort <> -1 Then
                If value Xor (portMode = 3) Then
                    If EscapeCommFunction(hSerialPort, SETRTS) = 0 Then
                        Dbg("Can't set RTS. " & GetLastError())
                    End If
                Else
                    If EscapeCommFunction(hSerialPort, CLRRTS) = 0 Then
                        Dbg("Can't clear RTS. " & GetLastError())
                    End If
                End If
            End If
        End Set
    End Property

    ReadOnly Property CTS()
        Get
            Dim ms As Integer

            If hSerialPort <> -1 Then
                If GetCommModemStatus(hSerialPort, ms) = 0 Then
                    Dbg("Can't get CTS. " & GetLastError())
                    CTS = False
                Else
                    CTS = (ms And MS_CTS_ON) = MS_CTS_ON
                End If
            Else
                CTS = False
            End If
            CTS = CTS Xor (portMode = 3)
        End Get
    End Property

    WriteOnly Property DTR()
        Set(ByVal value)
            If hSerialPort <> -1 Then
                If value Xor (portMode = 3) Then
                    If EscapeCommFunction(hSerialPort, SETDTR) = 0 Then
                        Dbg("Can't set DTR. " & GetLastError())
                    End If
                Else
                    If EscapeCommFunction(hSerialPort, CLRDTR) = 0 Then
                        Dbg("Can't clear DTR. " & GetLastError())
                    End If
                End If
            End If
        End Set
    End Property

    ReadOnly Property DSR()
        Get
            Dim ms As Integer

            If hSerialPort <> -1 Then
                If GetCommModemStatus(hSerialPort, ms) = 0 Then
                    Dbg("Can't get DSR. " & GetLastError())
                    DSR = False
                Else
                    DSR = (ms And MS_DSR_ON) = MS_DSR_ON
                End If
            Else
                DSR = False
            End If
            DSR = DSR Xor (portMode = 3)
        End Get
    End Property
End Class