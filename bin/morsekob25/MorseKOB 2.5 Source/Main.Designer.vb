<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LessonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpTopicsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.AboutMorseKOBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.txtDisplay = New System.Windows.Forms.TextBox
        Me.txtKeyboard = New System.Windows.Forms.TextBox
        Me.txtIDs = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkCircuitCloser = New System.Windows.Forms.CheckBox
        Me.nudCodeSpeed = New System.Windows.Forms.NumericUpDown
        Me.lblWPM = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkCodeSenderOn = New System.Windows.Forms.CheckBox
        Me.chkCodeSenderLoop = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pnlIntConnect = New System.Windows.Forms.Panel
        Me.nudChannel = New System.Windows.Forms.NumericUpDown
        Me.btnConnect = New System.Windows.Forms.Button
        Me.tmrDisplayIDList = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSetIndicators = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.txtLocalID = New System.Windows.Forms.TextBox
        Me.tmrChangeWireNo = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nudCodeSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(592, 24)
        Me.MenuStrip.TabIndex = 26
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.LessonToolStripMenuItem, Me.ToolStripSeparator4, Me.SaveToolStripMenuItem, Me.SaveToolStripMenuItem1, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.OpenToolStripMenuItem.Text = "Open..."
        '
        'LessonToolStripMenuItem
        '
        Me.LessonToolStripMenuItem.Name = "LessonToolStripMenuItem"
        Me.LessonToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.LessonToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.LessonToolStripMenuItem.Text = "Lesson..."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(153, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveToolStripMenuItem1
        '
        Me.SaveToolStripMenuItem1.Enabled = False
        Me.SaveToolStripMenuItem1.Name = "SaveToolStripMenuItem1"
        Me.SaveToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.SaveToolStripMenuItem1.Text = "Save As..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(153, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator1, Me.SelectAllToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Enabled = False
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Enabled = False
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Enabled = False
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Enabled = False
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(114, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Enabled = False
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FontToolStripMenuItem, Me.DebugToolStripMenuItem, Me.PreferencesToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.OptionsToolStripMenuItem.Text = "Tools"
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.FontToolStripMenuItem.Text = "Font..."
        '
        'DebugToolStripMenuItem
        '
        Me.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem"
        Me.DebugToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.DebugToolStripMenuItem.Text = "Debug..."
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.PreferencesToolStripMenuItem.Text = "Preferences..."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpTopicsToolStripMenuItem, Me.ToolStripSeparator3, Me.AboutMorseKOBToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpTopicsToolStripMenuItem
        '
        Me.HelpTopicsToolStripMenuItem.Enabled = False
        Me.HelpTopicsToolStripMenuItem.Name = "HelpTopicsToolStripMenuItem"
        Me.HelpTopicsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.HelpTopicsToolStripMenuItem.Text = "Tutorial"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(152, 6)
        '
        'AboutMorseKOBToolStripMenuItem
        '
        Me.AboutMorseKOBToolStripMenuItem.Name = "AboutMorseKOBToolStripMenuItem"
        Me.AboutMorseKOBToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.AboutMorseKOBToolStripMenuItem.Text = "About MorseKOB"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDisplay)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtKeyboard)
        Me.SplitContainer1.Size = New System.Drawing.Size(373, 383)
        Me.SplitContainer1.SplitterDistance = 271
        Me.SplitContainer1.SplitterWidth = 8
        Me.SplitContainer1.TabIndex = 29
        Me.SplitContainer1.TabStop = False
        '
        'txtDisplay
        '
        Me.txtDisplay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDisplay.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.MorseKOB.My.MySettings.Default, "Font", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtDisplay.Font = Global.MorseKOB.My.MySettings.Default.Font
        Me.txtDisplay.Location = New System.Drawing.Point(0, 0)
        Me.txtDisplay.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDisplay.Multiline = True
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDisplay.Size = New System.Drawing.Size(373, 271)
        Me.txtDisplay.TabIndex = 99
        Me.txtDisplay.TabStop = False
        '
        'txtKeyboard
        '
        Me.txtKeyboard.AcceptsTab = True
        Me.txtKeyboard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKeyboard.HideSelection = False
        Me.txtKeyboard.Location = New System.Drawing.Point(0, 0)
        Me.txtKeyboard.Margin = New System.Windows.Forms.Padding(0)
        Me.txtKeyboard.Multiline = True
        Me.txtKeyboard.Name = "txtKeyboard"
        Me.txtKeyboard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtKeyboard.Size = New System.Drawing.Size(373, 104)
        Me.txtKeyboard.TabIndex = 0
        '
        'txtIDs
        '
        Me.txtIDs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIDs.Location = New System.Drawing.Point(0, 0)
        Me.txtIDs.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.txtIDs.Multiline = True
        Me.txtIDs.Name = "txtIDs"
        Me.txtIDs.Size = New System.Drawing.Size(193, 220)
        Me.txtIDs.TabIndex = 1
        Me.txtIDs.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 248)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(193, 135)
        Me.Panel1.TabIndex = 27
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkCircuitCloser)
        Me.GroupBox3.Controls.Add(Me.nudCodeSpeed)
        Me.GroupBox3.Controls.Add(Me.lblWPM)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(188, 47)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'chkCircuitCloser
        '
        Me.chkCircuitCloser.AutoSize = True
        Me.chkCircuitCloser.Checked = Global.MorseKOB.My.MySettings.Default.CircuitCloser
        Me.chkCircuitCloser.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.MorseKOB.My.MySettings.Default, "CircuitCloser", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkCircuitCloser.Location = New System.Drawing.Point(8, 18)
        Me.chkCircuitCloser.Name = "chkCircuitCloser"
        Me.chkCircuitCloser.Size = New System.Drawing.Size(87, 17)
        Me.chkCircuitCloser.TabIndex = 0
        Me.chkCircuitCloser.Text = "Circuit Closer"
        Me.chkCircuitCloser.UseVisualStyleBackColor = True
        '
        'nudCodeSpeed
        '
        Me.nudCodeSpeed.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.MorseKOB.My.MySettings.Default, "CodeSpeed", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.nudCodeSpeed.Location = New System.Drawing.Point(134, 17)
        Me.nudCodeSpeed.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudCodeSpeed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCodeSpeed.Name = "nudCodeSpeed"
        Me.nudCodeSpeed.Size = New System.Drawing.Size(46, 20)
        Me.nudCodeSpeed.TabIndex = 1
        Me.nudCodeSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudCodeSpeed.Value = Global.MorseKOB.My.MySettings.Default.CodeSpeed
        '
        'lblWPM
        '
        Me.lblWPM.AutoSize = True
        Me.lblWPM.Location = New System.Drawing.Point(100, 20)
        Me.lblWPM.Margin = New System.Windows.Forms.Padding(3)
        Me.lblWPM.Name = "lblWPM"
        Me.lblWPM.Size = New System.Drawing.Size(34, 13)
        Me.lblWPM.TabIndex = 2
        Me.lblWPM.Text = "WPM"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkCodeSenderOn)
        Me.GroupBox2.Controls.Add(Me.chkCodeSenderLoop)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(91, 77)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Code Sender"
        '
        'chkCodeSenderOn
        '
        Me.chkCodeSenderOn.AutoSize = True
        Me.chkCodeSenderOn.Location = New System.Drawing.Point(15, 23)
        Me.chkCodeSenderOn.Name = "chkCodeSenderOn"
        Me.chkCodeSenderOn.Size = New System.Drawing.Size(40, 17)
        Me.chkCodeSenderOn.TabIndex = 0
        Me.chkCodeSenderOn.Text = "On"
        Me.chkCodeSenderOn.UseVisualStyleBackColor = True
        '
        'chkCodeSenderLoop
        '
        Me.chkCodeSenderLoop.AutoSize = True
        Me.chkCodeSenderLoop.Location = New System.Drawing.Point(15, 48)
        Me.chkCodeSenderLoop.Name = "chkCodeSenderLoop"
        Me.chkCodeSenderLoop.Size = New System.Drawing.Size(50, 17)
        Me.chkCodeSenderLoop.TabIndex = 1
        Me.chkCodeSenderLoop.Text = "Loop"
        Me.chkCodeSenderLoop.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnlIntConnect)
        Me.GroupBox1.Controls.Add(Me.nudChannel)
        Me.GroupBox1.Controls.Add(Me.btnConnect)
        Me.GroupBox1.Location = New System.Drawing.Point(100, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(91, 77)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Wire No."
        '
        'pnlIntConnect
        '
        Me.pnlIntConnect.BackColor = System.Drawing.Color.White
        Me.pnlIntConnect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlIntConnect.Location = New System.Drawing.Point(73, 23)
        Me.pnlIntConnect.Name = "pnlIntConnect"
        Me.pnlIntConnect.Size = New System.Drawing.Size(8, 12)
        Me.pnlIntConnect.TabIndex = 2
        '
        'nudChannel
        '
        Me.nudChannel.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.MorseKOB.My.MySettings.Default, "WireNo", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.nudChannel.Location = New System.Drawing.Point(6, 19)
        Me.nudChannel.Maximum = New Decimal(New Integer() {32000, 0, 0, 0})
        Me.nudChannel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudChannel.Name = "nudChannel"
        Me.nudChannel.Size = New System.Drawing.Size(61, 20)
        Me.nudChannel.TabIndex = 0
        Me.nudChannel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudChannel.Value = Global.MorseKOB.My.MySettings.Default.WireNo
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(6, 45)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(79, 25)
        Me.btnConnect.TabIndex = 1
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'tmrDisplayIDList
        '
        Me.tmrDisplayIDList.Enabled = True
        Me.tmrDisplayIDList.Interval = 1000
        '
        'tmrSetIndicators
        '
        Me.tmrSetIndicators.Enabled = True
        Me.tmrSetIndicators.Interval = 250
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.DefaultExt = "txt"
        Me.OpenFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        Me.OpenFileDialog.RestoreDirectory = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.Location = New System.Drawing.Point(9, 30)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Panel1MinSize = 50
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtIDs)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtLocalID)
        Me.SplitContainer2.Panel2MinSize = 50
        Me.SplitContainer2.Size = New System.Drawing.Size(574, 383)
        Me.SplitContainer2.SplitterDistance = 373
        Me.SplitContainer2.SplitterWidth = 8
        Me.SplitContainer2.TabIndex = 30
        Me.SplitContainer2.TabStop = False
        '
        'txtLocalID
        '
        Me.txtLocalID.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtLocalID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MorseKOB.My.MySettings.Default, "ID", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtLocalID.Location = New System.Drawing.Point(3, 228)
        Me.txtLocalID.Margin = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.txtLocalID.Name = "txtLocalID"
        Me.txtLocalID.Size = New System.Drawing.Size(186, 20)
        Me.txtLocalID.TabIndex = 2
        Me.txtLocalID.Text = Global.MorseKOB.My.MySettings.Default.ID
        '
        'tmrChangeWireNo
        '
        Me.tmrChangeWireNo.Interval = 1500
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 422)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.MenuStrip)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.MorseKOB.My.MySettings.Default, "WindowLocation", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = Global.MorseKOB.My.MySettings.Default.WindowLocation
        Me.MainMenuStrip = Me.MenuStrip
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MorseKOB"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nudCodeSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.nudChannel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalID As System.Windows.Forms.TextBox
    Friend WithEvents tmrDisplayIDList As System.Windows.Forms.Timer
    Friend WithEvents tmrSetIndicators As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlIntConnect As System.Windows.Forms.Panel
    Friend WithEvents nudChannel As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblWPM As System.Windows.Forms.Label
    Friend WithEvents chkCircuitCloser As System.Windows.Forms.CheckBox
    Friend WithEvents nudCodeSpeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtKeyboard As System.Windows.Forms.TextBox
    Friend WithEvents txtIDs As System.Windows.Forms.TextBox
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PreferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents HelpTopicsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutMorseKOBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DebugToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents LessonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkCodeSenderLoop As System.Windows.Forms.CheckBox
    Friend WithEvents chkCodeSenderOn As System.Windows.Forms.CheckBox
    Friend WithEvents tmrChangeWireNo As System.Windows.Forms.Timer
End Class
