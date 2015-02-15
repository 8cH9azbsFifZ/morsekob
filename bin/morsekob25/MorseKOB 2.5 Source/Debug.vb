Imports MorseKOB.Main  ' temp debug

' Note: checkboxes whose values are saved and restored as application settings must be
' unchecked on the form.  Otherwise saving and restoring doesn't work right. 

Public Class Debug
    Private Const maxTimes = 1000
    Private Shared savedTimes(maxTimes) As Short
    Private Shared nTimes As Integer = 0
    Private Shared saveTimingData As Boolean = False
    Public Shared ttyMode As Boolean = False
    Private Shared debugInstance As Integer = 0

    Private Sub Debug_Activated(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles Me.Activated
        OK_Button.Focus()
    End Sub

    Public Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles OK_Button.Click
        Main.blnDebug = chkDebug.Checked
        CodeReader.readerOn = chkReaderOn.Checked
        Internet.dspyVersions = chkDisplayVersions.Checked
        If txtRemoteHost.Text = "morsecode.dyndns.org" Then
            MsgBox("MorseKOB is not certified for use with " & vbCrLf _
                & "the server at morsecode.dyndns.org.  " & vbCrLf _
                & "Please select a different server.")
            txtRemoteHost.Text = Internet.remHost
        Else
            Internet.remHost = txtRemoteHost.Text
        End If
        Internet.dspyPcktData = chkPacketData.Checked
        KOB.directSound = chkDirectSound.Checked
        KOB.SetIntSounderType(Preferences.cboInternalSounder.SelectedIndex)
        KOB.noiseFilter = nudNoiseFilter.Value
        ttyMode = chkTTY.Checked
        CodeSender.OutState = ttyMode
        Me.Hide()
    End Sub

    Public Shared Sub SaveTiming(ByVal dt As Integer)
        If saveTimingData Then
            If nTimes < maxTimes Then
                nTimes += 1
                savedTimes(nTimes) = dt
            End If
        End If
    End Sub

    Private Sub tmrDisplayTimers_Tick(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles tmrDisplayTimers.Tick
        Static phase As Integer = 0

        phase = 1 - phase
        If phase = 1 Then
            Timing.DisplayDwellTimer()
            lblTimerIntvlHWM.Text = Timing.intervalHWM
        Else
            Timing.dwellTimeHWM = 0
            Timing.intervalHWM = 0
        End If
        lblNoiseWidth.Text = KOB.noisePulseWidth
        lblNoiseCount.Text = KOB.noisePulseCount
    End Sub

    Private Sub chkDebug_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles chkDebug.CheckedChanged
        If chkDebug.Checked Then
            Timing.dwellTimeHWM = 0
            Timing.intervalHWM = 0
            tmrDisplayTimers.Start()
        Else
            tmrDisplayTimers.Stop()
        End If
    End Sub

    Private Sub chkTimingData_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles chkTimingData.CheckedChanged
        saveTimingData = chkTimingData.Checked
        If Not chkTimingData.Checked Then
            For I As Integer = 1 To nTimes
                Main.DisplayText(savedTimes(I))
                If savedTimes(I) > 0 Then
                    Main.DisplayText(", ")
                Else
                    Main.DisplayText(vbCrLf)
                End If
            Next
        End If
        nTimes = 0
    End Sub

    Private Sub chkDirectSound_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles chkDirectSound.CheckedChanged
        If Not chkDirectSound.Checked Then
            MsgBox("For this setting to take effect," & vbCrLf & "please close and restart the program.")
        End If
    End Sub

End Class