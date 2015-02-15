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

Imports System.Threading
Imports VB = Microsoft.VisualBasic

Module CodeDefs
    Public strChar() As String = New String() _
        {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", _
        "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", _
        "U", "V", "W", "X", "Y", "Z", _
        "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", _
        ".", ",", "?", "!", "=", "&", "/"}
    Public strDefn() As String = New String() _
        {".-", "-...", ".. .", "-..", ".", ".-.", "--.", "....", "..", "-.-.", _
        "-.-", "=", "--", "-.", ". .", ".....", "..-.", ". ..", "...", "-", _
        "..-", "...-", ".--", ".-..", ".. ..", "... .", _
        ".--.", "..-..", "...-.", "....-", "---", "......", "--..", "-....", "-..-", "#", _
        "..--..", ".-.-", "-..-.", "---.", "----", ". ...", "..--"}
    Public blnEmph() As Boolean = New Boolean() _
        {False, False, False, False, False, False, False, False, False, False, _
        False, True, False, False, False, False, False, False, False, False, _
        False, False, False, False, False, False, _
        True, True, True, True, True, True, True, True, True, True, _
        True, True, True, True, True, True, True}

    Public ITA2() As String = New String() _
        {"<NUL>", "E", "<LF>", "A", " ", "S", "I", "U", _
        "<CR>", "D", "R", "J", "N", "F", "C", "K", _
        "T", "Z", "L", "W", "H", "Y", "P", "Q", _
        "O", "B", "G", "<FIGS>", "M", "X", "V", "<LTRS>"}
    Public Const ttyLF = &H2
    Public Const ttyCR = &H8
    Public Const ttyFIGS = &H1B
    Public Const ttyLTRS = &H1F
End Module

Module CodeReader
    Private Const DotVsDash = 1.5         ' Dot-dash threshold
    Private Const DashVsLongDash = 5      ' T vs L threshold
    Private Const LongVsClose = 12        ' L vs line closure threshold
    Private Const SpaceAfterDot = 2.4     ' Threshold for space following a dot
    Private Const SpaceAfterDash = 2.5    ' Threshold for space following a dash
    Private Const Tolerance = 1.05        ' Tolerance for two spaces to be "equal"
    Private Const TranslateInterval = 10  ' Interval in dot units to force translation

    Public readerOn As Boolean = True
    Public showTimingData As Boolean = False

    Private lastChar As String = ""
    Private lastSpace As Integer = 10000
    Private currChar As String = ""
    Private currSpace As Integer = 0

    Private WithEvents tmrCircuitClosed As New System.Timers.Timer
    Private WithEvents tmrTranslate As New System.Timers.Timer

    Public thdReaderLoop As New Thread(AddressOf ReaderLoop)

    Public Sub SetState(ByVal S As Boolean, ByVal t As Integer)
        Static sLast As Boolean = False
        Static tLast As Integer = Timing.GetTime() - 10000
        Static strBuf As String = ""
        Dim DeltaT As Integer

        If Debug.ttyMode Then
            SetStateTTY(S, t)
            Exit Sub
        End If
        If readerOn And (sLast <> S Or t = 0) Then
            If t = 0 Then
                DeltaT = 10000
            Else
                sLast = S
                DeltaT = t - tLast
                tLast = t
            End If
            DisplayTimingData(S, DeltaT)
            If Not S Then  ' End of mark
                tmrCircuitClosed.Stop()
                tmrTranslate.Interval = TranslateInterval * dotLen
                tmrTranslate.Start()
                If DeltaT < DotVsDash * dotLen Then  ' Dot
                    strBuf &= "."
                Else  ' Dash
                    If DeltaT < DashVsLongDash * dotLen Then
                        strBuf &= "-"
                    ElseIf DeltaT < LongVsClose * dotLen Then
                        strBuf &= "="
                    Else
                        strBuf &= "_"
                    End If
                End If
            Else  ' End of space
                tmrTranslate.Stop()
                If t <> 0 Then
                    tmrCircuitClosed.Interval = LongVsClose * dotLen
                    tmrCircuitClosed.Start()
                End If
                If strBuf <> "" Then
                    If VB.Right(strBuf, 1) = "." And DeltaT > SpaceAfterDot * dotLen _
                            Or VB.Right(strBuf, 1) <> "." And DeltaT > SpaceAfterDash * dotLen Then
                        QueueCharString(strBuf, DeltaT)
                        strBuf = ""
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub SetStateTTY(ByVal S As Boolean, ByVal t As Integer)
        Static running As Boolean = False
        Static tStart As Integer = t
        Static sLast As Boolean = True
        Static ch As Integer
        Static dataBits As Integer

        If readerOn Then
            If running Then
                If t > tStart + 22 * dataBits + 33 Then
                    ch = 2 * ch + (S And 1)
                    dataBits += 1
                    If dataBits >= 5 Then
                        PrintCharTTY(ch)
                        running = False
                        sLast = S
                    End If
                End If
            Else
                If sLast <> S Then
                    sLast = S
                    If Not S Then  ' start bit detected
                        running = True
                        tStart = t
                        ch = 0
                        dataBits = 0
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub PrintCharTTY(ByVal c As String)
        If c = ttyLF Then
            Main.DisplayText(ITA2(c) & vbCrLf)
        Else
            Main.DisplayText(ITA2(c))
        End If
    End Sub

    Private Sub QueueCharString(ByVal strChar As String, ByVal intSpace As Integer)
        If currChar <> "" Then
            currChar = "Overrun"  ' Code reader overrun
        Else
            currChar = strChar
        End If
        currSpace = intSpace
    End Sub

    Private Sub ReaderLoop()
        Do
            If currChar <> "" Then
                If currSpace * Tolerance < lastSpace Then  ' Potential Morse space
                    If lastChar <> "" Then
                        PrintChar(lastChar, lastSpace)
                    End If
                    lastChar = currChar
                    lastSpace = currSpace
                Else  ' Char space
                    If lastChar <> "" Then
                        If currSpace > Tolerance * lastSpace Then
                            PrintChar(lastChar & " " & currChar, currSpace, lastSpace)
                        Else
                            PrintChar(lastChar, lastSpace)
                            PrintChar(currChar, currSpace)
                        End If
                        lastChar = ""
                        lastSpace = currSpace
                    Else
                        PrintChar(currChar, currSpace)
                        lastChar = ""
                        lastSpace = currSpace
                    End If
                End If
                currChar = ""
            End If
            Thread.Sleep(1)
        Loop
    End Sub

    Private Sub PrintChar(ByVal strChar As String, ByVal intSpace As Integer, _
            Optional ByVal lastSpace As Integer = -1)
        Dim I As Integer

        If showTimingData Then
            Main.DisplayText(vbCrLf)
        End If
        If Len(strChar) > 1 Then
            Do
                I = InStr(strChar, "=")
                If I > 0 Then
                    Mid(strChar, I, 1) = "-"
                Else
                    Exit Do
                End If
            Loop
        End If
        I = 0
        While I <= CodeDefs.strDefn.GetUpperBound(0) AndAlso strChar <> CodeDefs.strDefn(I)
            I = I + 1
        End While
        If strChar = "_" Then
            DisplayTextWithSpace("_", intSpace)
        ElseIf strChar = ". ..." Then
            DisplayTextWithSpace("E", lastSpace)
            DisplayTextWithSpace("S", intSpace)
        ElseIf I <= CodeDefs.strDefn.GetUpperBound(0) Then
            DisplayTextWithSpace(CodeDefs.strChar(I), intSpace)
        Else
            I = InStr(1, strChar, " ")
            If I > 0 Then
                PrintChar(lastChar, lastSpace)
                PrintChar(currChar, currSpace)
            Else
                PrintCode(strChar, intSpace)
            End If
        End If
        If showTimingData Then
            Main.DisplayText(" ")
        End If
    End Sub

    Private Sub DisplayTextWithSpace(ByVal strS As String, ByVal intSpaceTime As Integer)
        Dim N As Integer

        Main.DisplayText(strS)
        N = Int((intSpaceTime / dotLen - 1.75) / 1.5)
        If N > 5 Then
            N = 5
        End If
        If N < 0 Then
            N = 0
        End If
        If N <= 2 Then
            Main.DisplayText(New String(ChrW(&HA0S), N))  ' Nonbreaking spaces
        Else
            Main.DisplayText(New String(ChrW(&HA0S), 2) & VB.Space(N - 2))
        End If
    End Sub

    Private Sub PrintCode(ByVal strS As String, ByVal intSpaceTime As Integer)
        Dim I As Integer
        Dim S As String

        S = ""
        S = S & "[" & ChrW(&HA0S) ' Nonbreaking space
        For I = 1 To Len(strS)
            S = S & Mid(strS, I, 1) & ChrW(&HA0S)
        Next I
        S = S & "]"
        DisplayTextWithSpace(S, intSpaceTime)
    End Sub

    Private Sub DisplayTimingData(ByVal S As Boolean, ByVal T As Integer)
        If showTimingData Then
            If Not S Then
                Main.DisplayText("+")
            Else
                Main.DisplayText("-")
            End If
            If T > 9999 Then
                T = 9999
            End If
            Main.DisplayText(T)
        End If
    End Sub

    Private Sub tmrCircuitClosed_Elapsed(ByVal sender As Object, _
            ByVal e As System.Timers.ElapsedEventArgs) Handles tmrCircuitClosed.Elapsed
        tmrCircuitClosed.Enabled = False
        Main.DisplayText(" _")
    End Sub

    Private Sub tmrTranslate_Elapsed(ByVal sender As Object, _
            ByVal e As System.Timers.ElapsedEventArgs) Handles tmrTranslate.Elapsed
        tmrTranslate.Stop()
        SetState(True, 0)
        If showTimingData Then
            Main.DisplayText(vbCrLf & "~")
        End If
    End Sub
End Module

Module CodeSender
    Public OutState As Boolean = False
    Private extraCharSpace As Integer = 0
    Private extraWordSpace As Integer = 0
    Private extraPhraseSpace As Integer = 0
    Private intLastCharType As Integer ' -1: space, 0: normal, +1: emphasized

    Public Sub SetExtraSpaces(ByVal t As Integer, ByVal s As Integer)
        extraCharSpace = 0
        extraWordSpace = 0
        extraPhraseSpace = 0
        Select Case t
            Case 1
                extraCharSpace = s
            Case 2
                extraWordSpace = s
            Case 3
                extraPhraseSpace = s
        End Select
    End Sub

    Public Sub SendChar(ByVal S As Char)
        If Debug.ttyMode Then
            SendCharTTY(S)
            Exit Sub
        End If
        S = UCase(S)
        If S = VB.vbTab Then  ' Long word space
            SetState(False, 2 * 7 * dotLen + extraPhraseSpace + 2 * extraWordSpace + 4 * extraCharSpace)
            intLastCharType = -1
        ElseIf S = " " Or S = vbLf Then  ' Word space
            SetState(False, 7 * dotLen + extraWordSpace + 2 * extraCharSpace)
            intLastCharType = -1
        ElseIf S = "-" Then  ' Hyphen: short word space
            SetState(False, 5.8 * dotLen + extraWordSpace + 1.5 * extraCharSpace)
            intLastCharType = -1
        ElseIf S <> vbCr Then
            Dim I As Integer = 0
            Do While I <= CodeDefs.strChar.GetUpperBound(0) AndAlso CodeDefs.strChar(I) <> S
                I = I + 1
            Loop
            If I <= CodeDefs.strChar.GetUpperBound(0) Then
                If intLastCharType > 0 Or intLastCharType = 0 And CodeDefs.blnEmph(I) Then
                    SetState(False, 4.2 * dotLen + extraCharSpace)  ' Emphasized character space
                ElseIf intLastCharType = 0 Then
                    SetState(False, 3.7 * dotLen + extraCharSpace)  ' Normal character space
                End If
                SendCodeElements(CodeDefs.strDefn(I))
                If CodeDefs.blnEmph(I) Then
                    intLastCharType = 1
                Else
                    intLastCharType = 0
                End If
            Else
                SetState(False, 4.6 * dotLen + extraCharSpace)  ' Unrecognized character (e.g. apostrophe): long char space
                intLastCharType = -1
            End If
        End If
        SetState(False, 0)
    End Sub

    Private Sub SendCharTTY(ByVal c As String)
        c = UCase(c)
        Select Case c
            Case ";"
                SendTTYBits(ttyCR)
            Case "."
                SendTTYBits(ttyLF)
            Case ","
                SendTTYBits(ttyLTRS)
            Case "`"
                SendTTYBits(ttyFIGS)
            Case vbLf
                SendTTYBits(ttyCR)
                SendTTYBits(ttyLF)
                SendTTYBits(ttyLTRS)
            Case Else
                Dim i As Integer = 0
                Do While i < 32 AndAlso ITA2(i) <> c
                    i += 1
                Loop
                If i < 32 Then
                    SendTTYBits(i)
                End If
        End Select
    End Sub

    Private Sub SendTTYBits(ByVal c As Integer)
        SetState(False, 22)  ' start bit
        For i As Integer = 1 To 5
            SetState(c And &H10, 22)
            c *= 2
        Next
        SetState(True, 33)  ' stop bit
    End Sub

    Private Sub SendCodeElements(ByVal strCodeString As String)
        Dim I As Integer
        Dim S As Char
        Dim S1 As Char

        I = 1
        Do While I <= Len(strCodeString)
            S = Mid(strCodeString, I, 1)
            S1 = Mid(strCodeString, I + 1, 1)
            If S = "." Then  ' Dot
                SetState(True, dotLen)
            ElseIf S = "-" Then  ' Dash
                If S1 = "-" Then
                    SetState(True, 2.7 * dotLen)
                Else
                    SetState(True, 3.3 * dotLen)
                End If
            ElseIf S = "=" Then  ' Long dash
                SetState(True, 5.6 * dotLen)  ' 2*dash - 2*emph
            ElseIf S = "#" Then  ' Extra long dash
                SetState(True, 8.9 * dotLen)  ' 3*dash - 2*emph
            End If
            If S1 = " " Then ' Morse space
                SetState(False, 2.7 * dotLen)
                I += 1
            ElseIf S = "-" And S1 = "-" Then
                SetState(False, 1.6 * dotLen)
            ElseIf I < Len(strCodeString) Then
                SetState(False, dotLen)
            End If
            I += 1
        Loop
    End Sub

    Private Sub SetState(ByVal s As Boolean, ByVal dt As Integer)
        OutState = s
        My.Application.DoEvents()
        Thread.Sleep(dt)
    End Sub
End Module
