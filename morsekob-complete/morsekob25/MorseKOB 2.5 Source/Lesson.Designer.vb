<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lesson
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Lesson))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.nudWordsPerGroup = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.nudMaxWordLength = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPossibleLetters = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtRequiredLetters = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.nudNGroups = New System.Windows.Forms.NumericUpDown
        Me.nudLevel = New System.Windows.Forms.NumericUpDown
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.nudWordsPerGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxWordLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(192, 141)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 99
        Me.Cancel_Button.Text = "Cancel"
        '
        'nudWordsPerGroup
        '
        Me.nudWordsPerGroup.Location = New System.Drawing.Point(110, 106)
        Me.nudWordsPerGroup.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudWordsPerGroup.Name = "nudWordsPerGroup"
        Me.nudWordsPerGroup.Size = New System.Drawing.Size(57, 20)
        Me.nudWordsPerGroup.TabIndex = 5
        Me.nudWordsPerGroup.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Level"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 108)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Words per Group"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(180, 68)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Max Word Length"
        '
        'nudMaxWordLength
        '
        Me.nudMaxWordLength.Location = New System.Drawing.Point(278, 65)
        Me.nudMaxWordLength.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMaxWordLength.Name = "nudMaxWordLength"
        Me.nudMaxWordLength.Size = New System.Drawing.Size(57, 20)
        Me.nudMaxWordLength.TabIndex = 4
        Me.nudMaxWordLength.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 41)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Possible Letters"
        '
        'txtPossibleLetters
        '
        Me.txtPossibleLetters.Location = New System.Drawing.Point(110, 38)
        Me.txtPossibleLetters.Name = "txtPossibleLetters"
        Me.txtPossibleLetters.Size = New System.Drawing.Size(157, 20)
        Me.txtPossibleLetters.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 67)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Required Letters"
        '
        'txtRequiredLetters
        '
        Me.txtRequiredLetters.Location = New System.Drawing.Point(110, 64)
        Me.txtRequiredLetters.Name = "txtRequiredLetters"
        Me.txtRequiredLetters.Size = New System.Drawing.Size(57, 20)
        Me.txtRequiredLetters.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(184, 108)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Number of Groups"
        '
        'nudNGroups
        '
        Me.nudNGroups.Location = New System.Drawing.Point(278, 106)
        Me.nudNGroups.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNGroups.Name = "nudNGroups"
        Me.nudNGroups.Size = New System.Drawing.Size(57, 20)
        Me.nudNGroups.TabIndex = 6
        Me.nudNGroups.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'nudLevel
        '
        Me.nudLevel.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.MorseKOB.My.MySettings.Default, "Level", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.nudLevel.Location = New System.Drawing.Point(110, 12)
        Me.nudLevel.Maximum = New Decimal(New Integer() {26, 0, 0, 0})
        Me.nudLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudLevel.Name = "nudLevel"
        Me.nudLevel.Size = New System.Drawing.Size(57, 20)
        Me.nudLevel.TabIndex = 1
        Me.nudLevel.Value = Global.MorseKOB.My.MySettings.Default.Level
        '
        'Lesson
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 182)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nudNGroups)
        Me.Controls.Add(Me.txtRequiredLetters)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPossibleLetters)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.nudMaxWordLength)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudWordsPerGroup)
        Me.Controls.Add(Me.nudLevel)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Lesson"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lesson"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.nudWordsPerGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxWordLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents nudLevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudWordsPerGroup As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudMaxWordLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPossibleLetters As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRequiredLetters As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudNGroups As System.Windows.Forms.NumericUpDown

End Class
