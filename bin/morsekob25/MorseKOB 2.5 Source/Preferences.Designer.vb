<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Preferences
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Preferences))
        Me.lblKeySndr = New System.Windows.Forms.Label
        Me.grpConfig = New System.Windows.Forms.GroupBox
        Me.lblSound = New System.Windows.Forms.Label
        Me.lblMode = New System.Windows.Forms.Label
        Me.grpCodeSender = New System.Windows.Forms.GroupBox
        Me.lblTimes = New System.Windows.Forms.Label
        Me.lblSpace = New System.Windows.Forms.Label
        Me.lblRepeat = New System.Windows.Forms.Label
        Me.lblDelay = New System.Windows.Forms.Label
        Me.OK_Button = New System.Windows.Forms.Button
        Me.cboMode = New System.Windows.Forms.ComboBox
        Me.cboInternalSounder = New System.Windows.Forms.ComboBox
        Me.cboSerialPort = New System.Windows.Forms.ComboBox
        Me.nudTimes = New System.Windows.Forms.NumericUpDown
        Me.nudFarnsworthSpace = New System.Windows.Forms.NumericUpDown
        Me.cboRepeat = New System.Windows.Forms.ComboBox
        Me.cboFarnsworthType = New System.Windows.Forms.ComboBox
        Me.grpConfig.SuspendLayout()
        Me.grpCodeSender.SuspendLayout()
        CType(Me.nudTimes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFarnsworthSpace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblKeySndr
        '
        Me.lblKeySndr.AutoSize = True
        Me.lblKeySndr.Location = New System.Drawing.Point(31, 22)
        Me.lblKeySndr.Name = "lblKeySndr"
        Me.lblKeySndr.Size = New System.Drawing.Size(26, 13)
        Me.lblKeySndr.TabIndex = 0
        Me.lblKeySndr.Text = "Port"
        Me.lblKeySndr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpConfig
        '
        Me.grpConfig.Controls.Add(Me.lblSound)
        Me.grpConfig.Controls.Add(Me.cboMode)
        Me.grpConfig.Controls.Add(Me.cboInternalSounder)
        Me.grpConfig.Controls.Add(Me.lblMode)
        Me.grpConfig.Controls.Add(Me.cboSerialPort)
        Me.grpConfig.Controls.Add(Me.lblKeySndr)
        Me.grpConfig.Location = New System.Drawing.Point(159, 12)
        Me.grpConfig.Name = "grpConfig"
        Me.grpConfig.Size = New System.Drawing.Size(141, 105)
        Me.grpConfig.TabIndex = 2
        Me.grpConfig.TabStop = False
        Me.grpConfig.Text = "Configuration"
        '
        'lblSound
        '
        Me.lblSound.AutoSize = True
        Me.lblSound.Location = New System.Drawing.Point(19, 76)
        Me.lblSound.Name = "lblSound"
        Me.lblSound.Size = New System.Drawing.Size(38, 13)
        Me.lblSound.TabIndex = 2
        Me.lblSound.Text = "Sound"
        Me.lblSound.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMode
        '
        Me.lblMode.AutoSize = True
        Me.lblMode.Location = New System.Drawing.Point(23, 49)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(34, 13)
        Me.lblMode.TabIndex = 1
        Me.lblMode.Text = "Mode"
        Me.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpCodeSender
        '
        Me.grpCodeSender.Controls.Add(Me.lblTimes)
        Me.grpCodeSender.Controls.Add(Me.lblSpace)
        Me.grpCodeSender.Controls.Add(Me.nudTimes)
        Me.grpCodeSender.Controls.Add(Me.nudFarnsworthSpace)
        Me.grpCodeSender.Controls.Add(Me.cboRepeat)
        Me.grpCodeSender.Controls.Add(Me.cboFarnsworthType)
        Me.grpCodeSender.Controls.Add(Me.lblRepeat)
        Me.grpCodeSender.Controls.Add(Me.lblDelay)
        Me.grpCodeSender.Location = New System.Drawing.Point(12, 12)
        Me.grpCodeSender.Name = "grpCodeSender"
        Me.grpCodeSender.Size = New System.Drawing.Size(141, 139)
        Me.grpCodeSender.TabIndex = 1
        Me.grpCodeSender.TabStop = False
        Me.grpCodeSender.Text = "Farnsworth"
        '
        'lblTimes
        '
        Me.lblTimes.AutoSize = True
        Me.lblTimes.Location = New System.Drawing.Point(45, 108)
        Me.lblTimes.Name = "lblTimes"
        Me.lblTimes.Size = New System.Drawing.Size(12, 13)
        Me.lblTimes.TabIndex = 3
        Me.lblTimes.Text = "x"
        Me.lblTimes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSpace
        '
        Me.lblSpace.AutoSize = True
        Me.lblSpace.Location = New System.Drawing.Point(37, 49)
        Me.lblSpace.Name = "lblSpace"
        Me.lblSpace.Size = New System.Drawing.Size(20, 13)
        Me.lblSpace.TabIndex = 1
        Me.lblSpace.Text = "ms"
        Me.lblSpace.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRepeat
        '
        Me.lblRepeat.AutoSize = True
        Me.lblRepeat.Location = New System.Drawing.Point(21, 81)
        Me.lblRepeat.Name = "lblRepeat"
        Me.lblRepeat.Size = New System.Drawing.Size(42, 13)
        Me.lblRepeat.TabIndex = 2
        Me.lblRepeat.Text = "Repeat"
        Me.lblRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDelay
        '
        Me.lblDelay.AutoSize = True
        Me.lblDelay.Location = New System.Drawing.Point(23, 22)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(34, 13)
        Me.lblDelay.TabIndex = 0
        Me.lblDelay.Text = "Delay"
        Me.lblDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(233, 128)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'cboMode
        '
        Me.cboMode.AutoCompleteCustomSource.AddRange(New String() {"Normal", "Keyer", "Loop", "Modem"})
        Me.cboMode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MorseKOB.My.MySettings.Default, "Mode", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMode.FormattingEnabled = True
        Me.cboMode.Items.AddRange(New Object() {"Normal", "Keyer", "Loop", "Modem"})
        Me.cboMode.Location = New System.Drawing.Point(63, 46)
        Me.cboMode.MaxDropDownItems = 9
        Me.cboMode.Name = "cboMode"
        Me.cboMode.Size = New System.Drawing.Size(66, 21)
        Me.cboMode.TabIndex = 1
        Me.cboMode.Text = Global.MorseKOB.My.MySettings.Default.Mode
        '
        'cboInternalSounder
        '
        Me.cboInternalSounder.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MorseKOB.My.MySettings.Default, "InternalSounder", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cboInternalSounder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInternalSounder.FormattingEnabled = True
        Me.cboInternalSounder.Items.AddRange(New Object() {"Off", "Normal", "Tone", "Mixed", "Classic", "Snappy", "Mellow", "Plain", "Kiwi"})
        Me.cboInternalSounder.Location = New System.Drawing.Point(63, 73)
        Me.cboInternalSounder.MaxDropDownItems = 9
        Me.cboInternalSounder.Name = "cboInternalSounder"
        Me.cboInternalSounder.Size = New System.Drawing.Size(66, 21)
        Me.cboInternalSounder.TabIndex = 2
        Me.cboInternalSounder.Text = Global.MorseKOB.My.MySettings.Default.InternalSounder
        '
        'cboSerialPort
        '
        Me.cboSerialPort.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MorseKOB.My.MySettings.Default, "SerialPort", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cboSerialPort.FormattingEnabled = True
        Me.cboSerialPort.Items.AddRange(New Object() {"None"})
        Me.cboSerialPort.Location = New System.Drawing.Point(63, 19)
        Me.cboSerialPort.MaxDropDownItems = 9
        Me.cboSerialPort.Name = "cboSerialPort"
        Me.cboSerialPort.Size = New System.Drawing.Size(66, 21)
        Me.cboSerialPort.Sorted = True
        Me.cboSerialPort.TabIndex = 0
        Me.cboSerialPort.Text = Global.MorseKOB.My.MySettings.Default.SerialPort
        '
        'nudTimes
        '
        Me.nudTimes.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.MorseKOB.My.MySettings.Default, "RepeatTimes", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.nudTimes.Location = New System.Drawing.Point(63, 106)
        Me.nudTimes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
        Me.nudTimes.Name = "nudTimes"
        Me.nudTimes.Size = New System.Drawing.Size(66, 20)
        Me.nudTimes.TabIndex = 3
        Me.nudTimes.Value = Global.MorseKOB.My.MySettings.Default.RepeatTimes
        '
        'nudFarnsworthSpace
        '
        Me.nudFarnsworthSpace.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.MorseKOB.My.MySettings.Default, "FarnsworthSpace", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.nudFarnsworthSpace.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nudFarnsworthSpace.Location = New System.Drawing.Point(63, 47)
        Me.nudFarnsworthSpace.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
        Me.nudFarnsworthSpace.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudFarnsworthSpace.Name = "nudFarnsworthSpace"
        Me.nudFarnsworthSpace.Size = New System.Drawing.Size(66, 20)
        Me.nudFarnsworthSpace.TabIndex = 1
        Me.nudFarnsworthSpace.Value = Global.MorseKOB.My.MySettings.Default.FarnsworthSpace
        '
        'cboRepeat
        '
        Me.cboRepeat.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MorseKOB.My.MySettings.Default, "RepeatGroup", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cboRepeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRepeat.FormattingEnabled = True
        Me.cboRepeat.Items.AddRange(New Object() {"Off", "Char", "Word", "Phrase"})
        Me.cboRepeat.Location = New System.Drawing.Point(63, 78)
        Me.cboRepeat.MaxDropDownItems = 9
        Me.cboRepeat.Name = "cboRepeat"
        Me.cboRepeat.Size = New System.Drawing.Size(66, 21)
        Me.cboRepeat.TabIndex = 2
        Me.cboRepeat.Text = Global.MorseKOB.My.MySettings.Default.RepeatGroup
        '
        'cboFarnsworthType
        '
        Me.cboFarnsworthType.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MorseKOB.My.MySettings.Default, "FarnsworthType", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cboFarnsworthType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFarnsworthType.FormattingEnabled = True
        Me.cboFarnsworthType.Items.AddRange(New Object() {"Off", "Char", "Word", "Phrase"})
        Me.cboFarnsworthType.Location = New System.Drawing.Point(63, 19)
        Me.cboFarnsworthType.MaxDropDownItems = 9
        Me.cboFarnsworthType.Name = "cboFarnsworthType"
        Me.cboFarnsworthType.Size = New System.Drawing.Size(66, 21)
        Me.cboFarnsworthType.TabIndex = 0
        Me.cboFarnsworthType.Text = Global.MorseKOB.My.MySettings.Default.FarnsworthType
        '
        'Preferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 163)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.grpConfig)
        Me.Controls.Add(Me.grpCodeSender)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Preferences"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preferences"
        Me.grpConfig.ResumeLayout(False)
        Me.grpConfig.PerformLayout()
        Me.grpCodeSender.ResumeLayout(False)
        Me.grpCodeSender.PerformLayout()
        CType(Me.nudTimes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFarnsworthSpace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblKeySndr As System.Windows.Forms.Label
    Friend WithEvents cboSerialPort As System.Windows.Forms.ComboBox
    Friend WithEvents grpConfig As System.Windows.Forms.GroupBox
    Friend WithEvents cboInternalSounder As System.Windows.Forms.ComboBox
    Friend WithEvents lblSound As System.Windows.Forms.Label
    Friend WithEvents grpCodeSender As System.Windows.Forms.GroupBox
    Friend WithEvents lblRepeat As System.Windows.Forms.Label
    Friend WithEvents cboRepeat As System.Windows.Forms.ComboBox
    Friend WithEvents nudTimes As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTimes As System.Windows.Forms.Label
    Friend WithEvents lblSpace As System.Windows.Forms.Label
    Friend WithEvents nudFarnsworthSpace As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboFarnsworthType As System.Windows.Forms.ComboBox
    Friend WithEvents lblDelay As System.Windows.Forms.Label
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents cboMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblMode As System.Windows.Forms.Label

End Class
