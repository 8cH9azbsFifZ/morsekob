<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Debug
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Debug))
        Me.lblDwl = New System.Windows.Forms.Label
        Me.lblDwellTime = New System.Windows.Forms.Label
        Me.lblLag = New System.Windows.Forms.Label
        Me.lblTimerIntvlHWM = New System.Windows.Forms.Label
        Me.chkTimingData = New System.Windows.Forms.CheckBox
        Me.chkDebug = New System.Windows.Forms.CheckBox
        Me.tmrDisplayTimers = New System.Windows.Forms.Timer(Me.components)
        Me.lblAdr = New System.Windows.Forms.Label
        Me.txtRemoteHost = New System.Windows.Forms.TextBox
        Me.chkPacketData = New System.Windows.Forms.CheckBox
        Me.chkDisplayVersions = New System.Windows.Forms.CheckBox
        Me.lblNoiseFilter = New System.Windows.Forms.Label
        Me.nudNoiseFilter = New System.Windows.Forms.NumericUpDown
        Me.grpNoiseFilter = New System.Windows.Forms.GroupBox
        Me.lblWidth = New System.Windows.Forms.Label
        Me.lblNoiseWidth = New System.Windows.Forms.Label
        Me.lblCount = New System.Windows.Forms.Label
        Me.lblNoiseCount = New System.Windows.Forms.Label
        Me.lblCallAlert = New System.Windows.Forms.Label
        Me.OK_Button = New System.Windows.Forms.Button
        Me.chkTTY = New System.Windows.Forms.CheckBox
        Me.chkDirectSound = New System.Windows.Forms.CheckBox
        Me.cboCallAlert = New System.Windows.Forms.ComboBox
        Me.chkReaderOn = New System.Windows.Forms.CheckBox
        CType(Me.nudNoiseFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNoiseFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDwl
        '
        Me.lblDwl.AutoSize = True
        Me.lblDwl.Location = New System.Drawing.Point(65, 195)
        Me.lblDwl.Name = "lblDwl"
        Me.lblDwl.Size = New System.Drawing.Size(25, 13)
        Me.lblDwl.TabIndex = 18
        Me.lblDwl.Text = "Dwl"
        '
        'lblDwellTime
        '
        Me.lblDwellTime.AutoSize = True
        Me.lblDwellTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDwellTime.Location = New System.Drawing.Point(96, 192)
        Me.lblDwellTime.MinimumSize = New System.Drawing.Size(70, 21)
        Me.lblDwellTime.Name = "lblDwellTime"
        Me.lblDwellTime.Size = New System.Drawing.Size(70, 21)
        Me.lblDwellTime.TabIndex = 17
        Me.lblDwellTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLag
        '
        Me.lblLag.AutoSize = True
        Me.lblLag.Location = New System.Drawing.Point(65, 227)
        Me.lblLag.Name = "lblLag"
        Me.lblLag.Size = New System.Drawing.Size(25, 13)
        Me.lblLag.TabIndex = 16
        Me.lblLag.Text = "Lag"
        '
        'lblTimerIntvlHWM
        '
        Me.lblTimerIntvlHWM.AutoSize = True
        Me.lblTimerIntvlHWM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTimerIntvlHWM.Location = New System.Drawing.Point(96, 224)
        Me.lblTimerIntvlHWM.MinimumSize = New System.Drawing.Size(70, 21)
        Me.lblTimerIntvlHWM.Name = "lblTimerIntvlHWM"
        Me.lblTimerIntvlHWM.Size = New System.Drawing.Size(70, 21)
        Me.lblTimerIntvlHWM.TabIndex = 14
        Me.lblTimerIntvlHWM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkTimingData
        '
        Me.chkTimingData.AutoSize = True
        Me.chkTimingData.Location = New System.Drawing.Point(24, 80)
        Me.chkTimingData.Name = "chkTimingData"
        Me.chkTimingData.Size = New System.Drawing.Size(97, 17)
        Me.chkTimingData.TabIndex = 11
        Me.chkTimingData.Text = "Capture Timing"
        Me.chkTimingData.UseVisualStyleBackColor = True
        '
        'chkDebug
        '
        Me.chkDebug.AutoSize = True
        Me.chkDebug.Location = New System.Drawing.Point(144, 16)
        Me.chkDebug.Name = "chkDebug"
        Me.chkDebug.Size = New System.Drawing.Size(88, 17)
        Me.chkDebug.TabIndex = 0
        Me.chkDebug.Text = "Debug Mode"
        Me.chkDebug.UseVisualStyleBackColor = True
        '
        'tmrDisplayTimers
        '
        Me.tmrDisplayTimers.Interval = 500
        '
        'lblAdr
        '
        Me.lblAdr.AutoSize = True
        Me.lblAdr.Location = New System.Drawing.Point(21, 115)
        Me.lblAdr.Name = "lblAdr"
        Me.lblAdr.Size = New System.Drawing.Size(38, 13)
        Me.lblAdr.TabIndex = 25
        Me.lblAdr.Text = "Server"
        '
        'txtRemoteHost
        '
        Me.txtRemoteHost.Location = New System.Drawing.Point(65, 112)
        Me.txtRemoteHost.Name = "txtRemoteHost"
        Me.txtRemoteHost.Size = New System.Drawing.Size(142, 20)
        Me.txtRemoteHost.TabIndex = 26
        Me.txtRemoteHost.Text = "mtc-kob.dyndns.org"
        '
        'chkPacketData
        '
        Me.chkPacketData.AutoSize = True
        Me.chkPacketData.Location = New System.Drawing.Point(144, 48)
        Me.chkPacketData.Name = "chkPacketData"
        Me.chkPacketData.Size = New System.Drawing.Size(95, 17)
        Me.chkPacketData.TabIndex = 27
        Me.chkPacketData.Text = "Show Packets"
        Me.chkPacketData.UseVisualStyleBackColor = True
        '
        'chkDisplayVersions
        '
        Me.chkDisplayVersions.AutoSize = True
        Me.chkDisplayVersions.Location = New System.Drawing.Point(24, 48)
        Me.chkDisplayVersions.Name = "chkDisplayVersions"
        Me.chkDisplayVersions.Size = New System.Drawing.Size(96, 17)
        Me.chkDisplayVersions.TabIndex = 32
        Me.chkDisplayVersions.Text = "Show Versions"
        Me.chkDisplayVersions.UseVisualStyleBackColor = True
        '
        'lblNoiseFilter
        '
        Me.lblNoiseFilter.AutoSize = True
        Me.lblNoiseFilter.Location = New System.Drawing.Point(27, 21)
        Me.lblNoiseFilter.Name = "lblNoiseFilter"
        Me.lblNoiseFilter.Size = New System.Drawing.Size(34, 13)
        Me.lblNoiseFilter.TabIndex = 34
        Me.lblNoiseFilter.Text = "Delay"
        Me.lblNoiseFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudNoiseFilter
        '
        Me.nudNoiseFilter.Location = New System.Drawing.Point(67, 19)
        Me.nudNoiseFilter.Name = "nudNoiseFilter"
        Me.nudNoiseFilter.Size = New System.Drawing.Size(55, 20)
        Me.nudNoiseFilter.TabIndex = 33
        Me.nudNoiseFilter.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'grpNoiseFilter
        '
        Me.grpNoiseFilter.Controls.Add(Me.lblWidth)
        Me.grpNoiseFilter.Controls.Add(Me.lblNoiseWidth)
        Me.grpNoiseFilter.Controls.Add(Me.lblCount)
        Me.grpNoiseFilter.Controls.Add(Me.lblNoiseCount)
        Me.grpNoiseFilter.Controls.Add(Me.nudNoiseFilter)
        Me.grpNoiseFilter.Controls.Add(Me.lblNoiseFilter)
        Me.grpNoiseFilter.Location = New System.Drawing.Point(271, 12)
        Me.grpNoiseFilter.Name = "grpNoiseFilter"
        Me.grpNoiseFilter.Size = New System.Drawing.Size(130, 117)
        Me.grpNoiseFilter.TabIndex = 35
        Me.grpNoiseFilter.TabStop = False
        Me.grpNoiseFilter.Text = "Noise Filter"
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Location = New System.Drawing.Point(11, 54)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(35, 13)
        Me.lblWidth.TabIndex = 38
        Me.lblWidth.Text = "Width"
        '
        'lblNoiseWidth
        '
        Me.lblNoiseWidth.AutoSize = True
        Me.lblNoiseWidth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNoiseWidth.Location = New System.Drawing.Point(52, 51)
        Me.lblNoiseWidth.MinimumSize = New System.Drawing.Size(70, 21)
        Me.lblNoiseWidth.Name = "lblNoiseWidth"
        Me.lblNoiseWidth.Size = New System.Drawing.Size(70, 21)
        Me.lblNoiseWidth.TabIndex = 37
        Me.lblNoiseWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(11, 85)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(35, 13)
        Me.lblCount.TabIndex = 36
        Me.lblCount.Text = "Count"
        '
        'lblNoiseCount
        '
        Me.lblNoiseCount.AutoSize = True
        Me.lblNoiseCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNoiseCount.Location = New System.Drawing.Point(52, 82)
        Me.lblNoiseCount.MinimumSize = New System.Drawing.Size(70, 21)
        Me.lblNoiseCount.Name = "lblNoiseCount"
        Me.lblNoiseCount.Size = New System.Drawing.Size(70, 21)
        Me.lblNoiseCount.TabIndex = 35
        Me.lblNoiseCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCallAlert
        '
        Me.lblCallAlert.AutoSize = True
        Me.lblCallAlert.Location = New System.Drawing.Point(21, 147)
        Me.lblCallAlert.Name = "lblCallAlert"
        Me.lblCallAlert.Size = New System.Drawing.Size(48, 13)
        Me.lblCallAlert.TabIndex = 37
        Me.lblCallAlert.Text = "Call Alert"
        Me.lblCallAlert.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(296, 224)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(72, 24)
        Me.OK_Button.TabIndex = 39
        Me.OK_Button.Text = "OK"
        '
        'chkTTY
        '
        Me.chkTTY.AutoSize = True
        Me.chkTTY.Checked = Global.MorseKOB.My.MySettings.Default.TTY
        Me.chkTTY.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.MorseKOB.My.MySettings.Default, "TTY", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkTTY.Location = New System.Drawing.Point(248, 176)
        Me.chkTTY.Name = "chkTTY"
        Me.chkTTY.Size = New System.Drawing.Size(77, 17)
        Me.chkTTY.TabIndex = 0
        Me.chkTTY.Text = "TTY Mode"
        Me.chkTTY.UseVisualStyleBackColor = True
        '
        'chkDirectSound
        '
        Me.chkDirectSound.AutoSize = True
        Me.chkDirectSound.Checked = Global.MorseKOB.My.MySettings.Default.DirectSound
        Me.chkDirectSound.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.MorseKOB.My.MySettings.Default, "DirectSound", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkDirectSound.Location = New System.Drawing.Point(144, 80)
        Me.chkDirectSound.Name = "chkDirectSound"
        Me.chkDirectSound.Size = New System.Drawing.Size(85, 17)
        Me.chkDirectSound.TabIndex = 40
        Me.chkDirectSound.Text = "DirectSound"
        Me.chkDirectSound.UseVisualStyleBackColor = True
        '
        'cboCallAlert
        '
        Me.cboCallAlert.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MorseKOB.My.MySettings.Default, "CallAlert", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cboCallAlert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCallAlert.FormattingEnabled = True
        Me.cboCallAlert.Items.AddRange(New Object() {"Off", "Chime", "Ring"})
        Me.cboCallAlert.Location = New System.Drawing.Point(75, 144)
        Me.cboCallAlert.MaxDropDownItems = 9
        Me.cboCallAlert.Name = "cboCallAlert"
        Me.cboCallAlert.Size = New System.Drawing.Size(99, 21)
        Me.cboCallAlert.TabIndex = 38
        Me.cboCallAlert.Text = Global.MorseKOB.My.MySettings.Default.CallAlert
        '
        'chkReaderOn
        '
        Me.chkReaderOn.AutoSize = True
        Me.chkReaderOn.Checked = Global.MorseKOB.My.MySettings.Default.ReaderOn
        Me.chkReaderOn.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.MorseKOB.My.MySettings.Default, "ReaderOn", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkReaderOn.Location = New System.Drawing.Point(24, 16)
        Me.chkReaderOn.Name = "chkReaderOn"
        Me.chkReaderOn.Size = New System.Drawing.Size(89, 17)
        Me.chkReaderOn.TabIndex = 19
        Me.chkReaderOn.Text = "Code Reader"
        Me.chkReaderOn.UseVisualStyleBackColor = True
        '
        'Debug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 272)
        Me.Controls.Add(Me.chkTTY)
        Me.Controls.Add(Me.chkDirectSound)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.cboCallAlert)
        Me.Controls.Add(Me.lblCallAlert)
        Me.Controls.Add(Me.grpNoiseFilter)
        Me.Controls.Add(Me.chkDisplayVersions)
        Me.Controls.Add(Me.chkPacketData)
        Me.Controls.Add(Me.lblAdr)
        Me.Controls.Add(Me.txtRemoteHost)
        Me.Controls.Add(Me.chkDebug)
        Me.Controls.Add(Me.chkReaderOn)
        Me.Controls.Add(Me.lblDwl)
        Me.Controls.Add(Me.lblDwellTime)
        Me.Controls.Add(Me.lblLag)
        Me.Controls.Add(Me.lblTimerIntvlHWM)
        Me.Controls.Add(Me.chkTimingData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Debug"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Debug"
        CType(Me.nudNoiseFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNoiseFilter.ResumeLayout(False)
        Me.grpNoiseFilter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDwl As System.Windows.Forms.Label
    Friend WithEvents lblDwellTime As System.Windows.Forms.Label
    Friend WithEvents lblLag As System.Windows.Forms.Label
    Friend WithEvents lblTimerIntvlHWM As System.Windows.Forms.Label
    Friend WithEvents chkTimingData As System.Windows.Forms.CheckBox
    Friend WithEvents chkReaderOn As System.Windows.Forms.CheckBox
    Friend WithEvents chkDebug As System.Windows.Forms.CheckBox
    Friend WithEvents tmrDisplayTimers As System.Windows.Forms.Timer
    Friend WithEvents lblAdr As System.Windows.Forms.Label
    Friend WithEvents txtRemoteHost As System.Windows.Forms.TextBox
    Friend WithEvents chkPacketData As System.Windows.Forms.CheckBox
    Friend WithEvents chkDisplayVersions As System.Windows.Forms.CheckBox
    Friend WithEvents lblNoiseFilter As System.Windows.Forms.Label
    Friend WithEvents nudNoiseFilter As System.Windows.Forms.NumericUpDown
    Friend WithEvents grpNoiseFilter As System.Windows.Forms.GroupBox
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents lblNoiseWidth As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents lblNoiseCount As System.Windows.Forms.Label
    Friend WithEvents lblCallAlert As System.Windows.Forms.Label
    Friend WithEvents cboCallAlert As System.Windows.Forms.ComboBox
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents chkDirectSound As System.Windows.Forms.CheckBox
    Friend WithEvents chkTTY As System.Windows.Forms.CheckBox
End Class
