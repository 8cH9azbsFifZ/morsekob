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
Imports RE = System.Text.RegularExpressions

Public Class Main
    Public Shared kobVersion As String = "MorseKOB x.y (ymm-n)"
    Public Shared blnDebug As Boolean = False
    Public Shared senderActive As Boolean = False
    Public Shared displayBuffer As String = ""

    Public Shared Sub DisplayText(ByVal str As String)
        displayBuffer &= str
    End Sub

    Public Shared Sub Dbg(ByVal strS As String)
        If blnDebug Then
            Main.DisplayText(vbCrLf & "«" & strS & "»")
        End If
    End Sub

    Private Sub SendCode()
        If senderActive Then Exit Sub
        senderActive = True

        Dim reps As Integer = 0
        Dim rptStrt As Integer = -1
        Do While senderActive
            txtKeyboard.SelectionLength = 1
            Dim c As Char = Mid(txtKeyboard.Text, txtKeyboard.SelectionStart + 1, 1)
            If c = " " And Mid(txtKeyboard.Text, txtKeyboard.SelectionStart + 2, 1) = " " Then
                c = vbTab
                txtKeyboard.SelectionStart += 1
            ElseIf c = vbCr And Mid(txtKeyboard.Text, txtKeyboard.SelectionStart + 2, 1) = vbLf Then
                If Debug.ttyMode Then
                    c = vbLf
                Else
                    c = " "
                End If
                txtKeyboard.SelectionStart += 1
            End If
            If reps = 0 And rptStrt < 0 And c <> " " And c <> vbTab And c <> vbNullChar Then
                reps = Preferences.nudTimes.Value - 1
                rptStrt = txtKeyboard.SelectionStart
            End If
            If Preferences.cboRepeat.SelectedIndex = 1 Then
                If c = " " Or c = vbTab Then
                    CodeSender.SendChar(" ")
                    CodeSender.SendChar(c)
                    txtKeyboard.SelectionStart += 1
                ElseIf c <> vbNullChar Then
                    For reps = 1 To Preferences.nudTimes.Value
                        CodeSender.SendChar(c)
                    Next
                    reps = 0
                    rptStrt = -1
                    txtKeyboard.SelectionStart += 1
                End If
            ElseIf Preferences.cboRepeat.SelectedIndex = 2 And (c = " " Or c = vbTab Or c = vbNullChar) Then
                CodeSender.SendChar(" ")
                If reps > 0 Then
                    reps -= 1
                    txtKeyboard.SelectionStart = rptStrt
                ElseIf c <> vbNullChar Then
                    rptStrt = -1
                    txtKeyboard.SelectionStart += 1
                End If
            ElseIf Preferences.cboRepeat.SelectedIndex = 3 And (c = vbTab Or c = vbNullChar) Then
                CodeSender.SendChar(vbTab)
                If reps > 0 Then
                    reps -= 1
                    txtKeyboard.SelectionStart = rptStrt
                ElseIf c <> vbNullChar Then
                    rptStrt = -1
                    txtKeyboard.SelectionStart += 1
                End If
            ElseIf c <> vbNullChar Then
                CodeSender.SendChar(c)
                txtKeyboard.SelectionStart += 1
            End If
            If c = vbNullChar And txtKeyboard.SelectionStart >= Len(txtKeyboard.Text) Then
                If chkCodeSenderLoop.Checked Then
                    CodeSender.SendChar(" ")
                    rptStrt = -1
                    txtKeyboard.SelectionStart = 0
                Else
                    senderActive = False
                End If
            End If
        Loop
    End Sub

    Private Sub Main_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtKeyboard.Focus()
    End Sub

    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) _
            Handles Me.FormClosing
        senderActive = False
        If Internet.intConnState <> 0 Then
            Internet.Disconnect()
        End If
        Timing.StopThreads()
    End Sub

    Private Sub Main_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            chkCircuitCloser.Checked = Not chkCircuitCloser.Checked
        ElseIf e.KeyCode = Keys.F3 Then
            DisplayText(vbCrLf & "«readerOn: " & CodeReader.readerOn.ToString _
                    & "; directSound: " & KOB.directSound.ToString & "»")
        ElseIf e.KeyCode = Keys.F4 Then
            nudCodeSpeed.DownButton()
        ElseIf e.KeyCode = Keys.F5 Then
            nudCodeSpeed.UpButton()
        ElseIf e.KeyCode = Keys.Left Then
            KOB.keyerPaddle = KOB.PaddleState.Dot
        ElseIf e.KeyCode = Keys.Right Then
            KOB.keyerPaddle = KOB.PaddleState.Dash
        ElseIf e.KeyCode = Keys.F11 Then
            txtDisplay.Text = ""
        ElseIf e.KeyCode = Keys.F12 Then
            txtKeyboard.Text = ""
        ElseIf e.KeyCode = Keys.Pause Then
            chkCodeSenderOn.Checked = Not chkCodeSenderOn.Checked
        ElseIf e.KeyCode = Keys.Home Then
            txtKeyboard.SelectionStart = 0
        ElseIf e.KeyCode = Keys.End Then
            txtKeyboard.SelectionStart = txtKeyboard.TextLength
        ElseIf e.KeyCode = Keys.Insert Then
            senderActive = False
            chkCodeSenderOn.Checked = False
            txtKeyboard.Text = My.Computer.Clipboard.GetText()
            txtKeyboard.SelectionStart = 0
            txtKeyboard.SelectionLength = 0
            txtKeyboard.Focus()
        ElseIf e.KeyCode = Keys.D And e.Modifiers = Keys.Alt Then
            DebugToolStripMenuItem_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub Main_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
          Handles Me.KeyUp
        If e.KeyCode = Keys.Left And keyerPaddle = PaddleState.Dot Then
            keyerPaddle = PaddleState.Off
        ElseIf e.KeyCode = Keys.Right And keyerPaddle = PaddleState.Dash Then
            keyerPaddle = PaddleState.Off
        End If
    End Sub

    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles Me.Load
        Me.Activate()
        txtDisplay.Width = SplitContainer1.Panel1.Width  ' this is a shim to handle a VB rescaling bug
        txtDisplay.Height = SplitContainer1.Panel1.Height
        txtKeyboard.Width = SplitContainer1.Panel2.Width
        txtKeyboard.Height = SplitContainer1.Panel2.Height
        If Location.X < 0 Or Location.Y < 0 Then  ' restore window if program was closed with window minimized
            Location = New System.Drawing.Point(100, 100)
        End If
        kobVersion = My.Application.Info.ProductName
        kobVersion &= " " & My.Application.Info.Version.Major _
                & "." & My.Application.Info.Version.Minor
        kobVersion &= " (" & My.Application.Info.Version.Build _
                & "-" & My.Application.Info.Version.Revision & ")"
        'txtKeyboard.Focus()
        Debug.OK_Button_Click(sender, e)
        'DisplayText(vbCrLf & "«readerOn: " & CodeReader.readerOn.ToString _
        '        & "; directSound: " & KOB.directSound.ToString & "»")
        Preferences.OK_Button_Click(sender, e)
        KOB.SetIntSounder(True)
        Thread.Sleep(100)
        KOB.SetIntSounder(False)
        Thread.Sleep(100)
        txtKeyboard.Font = txtDisplay.Font
        txtIDs.Font = txtDisplay.Font
        chkCodeSenderOn.Checked = True
        txtKeyboard.Focus()
        Timing.StartThreads()
    End Sub

    Private Sub btnConnect_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles btnConnect.Click
        Internet.ToggleConnect()
        txtKeyboard.Focus()
    End Sub

    Private Sub chkCircuitCloser_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles chkCircuitCloser.CheckedChanged
        KOB.cktCloserState = chkCircuitCloser.Checked
        If chkCircuitCloser.Checked Then
            Internet.rcvState = True
        End If
        txtKeyboard.Focus()
    End Sub

    Private Sub chkCodeSenderLoop_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles chkCodeSenderLoop.Click
        txtKeyboard.Focus()
    End Sub

    Private Sub chkCodeSenderOn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles chkCodeSenderOn.CheckedChanged
        chkCodeSenderOn.Refresh()  ' update the displayed checkmark before sending code
        If chkCodeSenderOn.Checked Then
            txtKeyboard.Cursor = Cursors.Arrow
            txtKeyboard.Focus()
            SendCode()
        Else
            senderActive = False
            txtKeyboard.Cursor = Cursors.IBeam
            txtKeyboard.Focus()
        End If
    End Sub

    Private Sub nudChannel_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles nudChannel.ValueChanged
        tmrChangeWireNo.Enabled = False
        tmrChangeWireNo.Enabled = True
    End Sub

    Private Sub nudCodeSpeed_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles nudCodeSpeed.ValueChanged
        KOB.dotLen = 1200 / nudCodeSpeed.Value
    End Sub

    Private Sub tmrChangeWireNo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles tmrChangeWireNo.Tick
        tmrChangeWireNo.Enabled = False
        Internet.ChangeChannel(nudChannel.Value)
    End Sub

    Private Sub tmrDisplayIDList_Tick(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles tmrDisplayIDList.Tick
        Internet.DisplayIDs()
    End Sub

    Private Sub tmrSetIndicators_Tick(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles tmrSetIndicators.Tick
        'Static penTrace As Pen = New Pen(Color.Black)
        'Static grphTrace As Graphics = Dialup.pnlSignalTrace.CreateGraphics
        'Dim I As Integer
        'Static traceVScale As Single = Dialup.pnlSignalTrace.Size.Height / 2.0F
        'Static traceHScale As Single = 2

        If displayBuffer <> "" Then
            Dim db As String = displayBuffer
            displayBuffer = ""
            txtDisplay.AppendText(db)
        End If

        Const CALLALERTINTERVAL = 30  ' minimum time between alerts (seconds)
        Static ringTicks As Integer = 0  ' timer ticks since last selector ring
        ringTicks += 1
        If Debug.cboCallAlert.SelectedIndex > 0 _
                And ringTicks > CALLALERTINTERVAL * 1000 / tmrSetIndicators.Interval Then
            Dim c1 As Char = Mid(txtLocalID.Text, 1, 1)
            Dim c2 As Char = Mid(txtLocalID.Text, 2, 1)
            Dim pattern As String = "\u00A0{2}\s+" & c1 & "\u00A0{0,2}" & c2 & "\u00A0{2}\s+.{0,10}?$"
            Dim regex As New RE.Regex(pattern, System.Text.RegularExpressions.RegexOptions.RightToLeft)
            If regex.Match(txtDisplay.Text).Success Then
                If Debug.cboCallAlert.SelectedIndex = 1 Then
                    My.Computer.Audio.Play(My.Resources.Chimes, AudioPlayMode.Background)
                ElseIf Debug.cboCallAlert.SelectedIndex = 2 Then
                    My.Computer.Audio.Play(My.Resources.Selector_Ring, AudioPlayMode.Background)
                End If
                ringTicks = 0
            End If
        End If

        Select Case Internet.intConnState
            Case 0 ' Disconnected
                pnlIntConnect.BackColor = Color.White
            Case 1 ' Connected
                pnlIntConnect.BackColor = Color.Red
            Case 2 ' Waiting
                If pnlIntConnect.BackColor <> Color.Red Then
                    pnlIntConnect.BackColor = Color.Red
                Else
                    pnlIntConnect.BackColor = Color.White
                End If
        End Select

        'Select Case Dialup.intConnState
        '    Case 0 ' Disconnected
        '        Dialup.pnlDUConnect.BackColor = Color.White
        '    Case 1 ' Connected
        '        Dialup.pnlDUConnect.BackColor = Color.Red
        '    Case 2 ' Underrun
        '        If Dialup.pnlDUConnect.BackColor <> Color.Red Then
        '            Dialup.pnlDUConnect.BackColor = Color.Red
        '        Else
        '            Dialup.pnlDUConnect.BackColor = Color.White
        '        End If
        '    Case 3 ' Overrun
        '        Dialup.pnlDUConnect.BackColor = Color.Yellow
        'End Select
        'If Dialup.intTrace >= 100 Then
        '    For I = 0 To 99
        '        penTrace.Color = Color.White
        '        grphTrace.DrawLine(penTrace, I * traceHScale + 3, 0, _
        '                I * traceHScale + 3, 2 * traceVScale)
        '        penTrace.Color = Dialup.traceColor(I)
        '        grphTrace.DrawLine(penTrace, I * traceHScale + 3, traceVScale, _
        '                I * traceHScale + 3, (1 - Dialup.traceMark(I)) * traceVScale)
        '        grphTrace.DrawLine(penTrace, I * traceHScale + 3, traceVScale, _
        '                I * traceHScale + 3, (1 + Dialup.traceSpace(I)) * traceVScale)
        '    Next
        '    Dialup.intTrace = 0
        'End If
    End Sub

    Private Sub txtKeyboard_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles txtKeyboard.KeyPress
        If chkCodeSenderOn.Checked Then
            If e.KeyChar >= " " And e.KeyChar <= "~" Or e.KeyChar = vbCr Then
                Preferences.cboRepeat.SelectedIndex = 0
                Dim ss As Integer = txtKeyboard.SelectionStart
                If e.KeyChar = vbCr Then
                    txtKeyboard.AppendText(vbCrLf)
                Else
                    txtKeyboard.AppendText(e.KeyChar)
                End If
                txtKeyboard.SelectionStart = ss
                SendCode()
            ElseIf e.KeyChar = vbBack Then
                Dim ss As Integer = txtKeyboard.SelectionStart
                Dim kb As String = txtKeyboard.Text
                txtKeyboard.Text = ""
                If kb.Length > 0 Then
                    txtKeyboard.AppendText(VB.Left(kb, kb.Length - 1))
                End If
                txtKeyboard.SelectionStart = ss
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub txtLocalID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtLocalID.TextChanged
        Internet.SetID(txtLocalID.Text)
    End Sub

    Private Sub txtKeyboard_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtKeyboard.Click
        If txtKeyboard.SelectionStart <> Len(txtKeyboard.Text) Then
            chkCodeSenderOn.Checked = False
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles NewToolStripMenuItem.Click
        senderActive = False
        chkCodeSenderOn.Checked = False
        txtKeyboard.Text = ""
        txtKeyboard.SelectionStart = 0
        txtKeyboard.SelectionLength = 0
        txtKeyboard.Focus()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles OpenToolStripMenuItem.Click
        OpenFileDialog.InitialDirectory = Application.UserAppDataPath & "\Text Files"
        If OpenFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            senderActive = False
            chkCodeSenderOn.Checked = False
            Dim sr As New System.IO.StreamReader(OpenFileDialog.FileName)
            txtKeyboard.Text = sr.ReadToEnd
            sr.Close()
            txtKeyboard.SelectionStart = 0
            txtKeyboard.SelectionLength = 0
            txtKeyboard.Focus()
        End If
    End Sub

    Private Sub WordListToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles LessonToolStripMenuItem.Click
        senderActive = False
        chkCodeSenderOn.Checked = False
        Lesson.Show()
        Lesson.Activate()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FontToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        Dim fd As New System.Windows.Forms.FontDialog
        fd.Font = txtDisplay.Font
        If fd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtDisplay.Font = fd.Font
            txtKeyboard.Font = fd.Font
            txtIDs.Font = fd.Font
        End If
    End Sub

    Private Sub DebugToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles DebugToolStripMenuItem.Click
        Debug.Show()
        Debug.Activate()
        'Debug.chkDebug.Focus()
    End Sub

    Private Sub PreferencesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles PreferencesToolStripMenuItem.Click
        Preferences.Show()
        Preferences.Activate()
    End Sub

    Private Sub AboutMorseKOBToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles AboutMorseKOBToolStripMenuItem.Click
        AboutBox.Show()
        AboutBox.Activate()
    End Sub
End Class

Module Timing
    Const ClockResolution = 5

    Public Declare Function GetTime Lib "winmm.dll" Alias "timeGetTime" () As Integer

    Private Declare Function timeBeginPeriod Lib "winmm.dll" (ByVal uPeriod As Integer) As Integer
    Private Declare Function timeEndPeriod Lib "winmm.dll" (ByVal uPeriod As Integer) As Integer

    Private dwellStopWatch As New System.Diagnostics.Stopwatch
    Public dwellTimeHWM As Integer = 0
    Public intervalHWM As Integer = 0

    Public Sub StartThreads()
        If timeBeginPeriod(ClockResolution) Then MsgBox("Can't begin timer period.")
        StartThread(KOB.thdKOBLoop, ThreadPriority.AboveNormal)
        StartThread(CodeReader.thdReaderLoop, ThreadPriority.BelowNormal)
    End Sub

    Public Sub StartThread(ByVal th As Thread, ByVal pr As ThreadPriority)
        th.IsBackground = True
        th.Priority = pr
        th.Start()
    End Sub

    Public Sub StopThreads()
        If timeEndPeriod(ClockResolution) <> 0 Then MsgBox("Can't end timer period.")
        KOB.thdKOBLoop.Abort()
        CodeReader.thdReaderLoop.Abort()
    End Sub

    Public Sub StartDwellTimer()
        dwellStopWatch.Reset()
        dwellStopWatch.Start()
    End Sub

    Public Sub StopDwellTimer()
        Dim dw As Integer

        dwellStopWatch.Stop()
        dw = dwellStopWatch.ElapsedTicks
        If dw > dwellTimeHWM Then
            dwellTimeHWM = dw
        End If
    End Sub

    Public Sub DisplayDwellTimer()
        'Dim dwms As Single

        'dwms = dwellTimeHWM / System.Diagnostics.Stopwatch.Frequency * 1000
        'Debug.lblDwellTime.Text = dwms.ToString("n")
    End Sub
End Module
