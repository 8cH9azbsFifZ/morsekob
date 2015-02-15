Public Class Preferences
    Public Sub OK_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles OK_Button.Click
        KOB.portMode = cboMode.SelectedIndex
        KOB.SetSerialPort(cboSerialPort.Text)
        KOB.SetIntSounderType(cboInternalSounder.SelectedIndex)
        CodeSender.SetExtraSpaces(cboFarnsworthType.SelectedIndex, nudFarnsworthSpace.Value)
        Me.Hide()
    End Sub

    Private Sub Preferences_Activated(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles Me.Activated
        cboSerialPort.Items.Clear()
        cboSerialPort.Items.Add("None")
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cboSerialPort.Items.Add(sp)
        Next
    End Sub
End Class
