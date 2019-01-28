<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AxisNoConfig
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AxisNoConfig))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DelName = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.AddName = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Configer = New System.Windows.Forms.DataGridView()
        Me.OK = New System.Windows.Forms.Button()
        Me.NoGrid = New System.Windows.Forms.DataGridView()
        Me.NameGrid = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CardText = New System.Windows.Forms.TextBox()
        Me.CardNumTxt = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ExitForm = New System.Windows.Forms.Button()
        Me.WFileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Configer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NameGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DelName
        '
        resources.ApplyResources(Me.DelName, "DelName")
        Me.DelName.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.DelName.Name = "DelName"
        Me.DelName.UseVisualStyleBackColor = True
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'AddName
        '
        resources.ApplyResources(Me.AddName, "AddName")
        Me.AddName.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.AddName.Name = "AddName"
        Me.AddName.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label4.Name = "Label4"
        '
        'Configer
        '
        resources.ApplyResources(Me.Configer, "Configer")
        Me.Configer.AllowUserToAddRows = False
        Me.Configer.AllowUserToDeleteRows = False
        Me.Configer.AllowUserToResizeColumns = False
        Me.Configer.AllowUserToResizeRows = False
        Me.Configer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Configer.BackgroundColor = System.Drawing.Color.LightGray
        Me.Configer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Configer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Configer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Configer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Configer.DefaultCellStyle = DataGridViewCellStyle8
        Me.Configer.MultiSelect = False
        Me.Configer.Name = "Configer"
        Me.Configer.RowHeadersVisible = False
        Me.Configer.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("新宋体", 10.0!)
        Me.Configer.RowTemplate.Height = 10
        Me.Configer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'OK
        '
        resources.ApplyResources(Me.OK, "OK")
        Me.OK.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.OK.Name = "OK"
        Me.OK.UseVisualStyleBackColor = True
        '
        'NoGrid
        '
        resources.ApplyResources(Me.NoGrid, "NoGrid")
        Me.NoGrid.AllowUserToAddRows = False
        Me.NoGrid.AllowUserToDeleteRows = False
        Me.NoGrid.AllowUserToResizeColumns = False
        Me.NoGrid.AllowUserToResizeRows = False
        Me.NoGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.NoGrid.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow
        Me.NoGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NoGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.NoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NoGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NoGrid.DefaultCellStyle = DataGridViewCellStyle10
        Me.NoGrid.MultiSelect = False
        Me.NoGrid.Name = "NoGrid"
        Me.NoGrid.ReadOnly = True
        Me.NoGrid.RowHeadersVisible = False
        Me.NoGrid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("新宋体", 10.0!)
        Me.NoGrid.RowTemplate.Height = 10
        Me.NoGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'NameGrid
        '
        resources.ApplyResources(Me.NameGrid, "NameGrid")
        Me.NameGrid.AllowUserToAddRows = False
        Me.NameGrid.AllowUserToDeleteRows = False
        Me.NameGrid.AllowUserToResizeColumns = False
        Me.NameGrid.AllowUserToResizeRows = False
        Me.NameGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.NameGrid.BackgroundColor = System.Drawing.Color.MintCream
        Me.NameGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NameGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.NameGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NameGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WFileName})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NameGrid.DefaultCellStyle = DataGridViewCellStyle12
        Me.NameGrid.MultiSelect = False
        Me.NameGrid.Name = "NameGrid"
        Me.NameGrid.ReadOnly = True
        Me.NameGrid.RowHeadersVisible = False
        Me.NameGrid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("新宋体", 10.0!)
        Me.NameGrid.RowTemplate.Height = 10
        Me.NameGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.CardText)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'CardText
        '
        resources.ApplyResources(Me.CardText, "CardText")
        Me.CardText.Name = "CardText"
        Me.CardText.ReadOnly = True
        '
        'CardNumTxt
        '
        resources.ApplyResources(Me.CardNumTxt, "CardNumTxt")
        Me.CardNumTxt.Name = "CardNumTxt"
        Me.CardNumTxt.ReadOnly = True
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CardNumTxt)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label1.Name = "Label1"
        '
        'ExitForm
        '
        resources.ApplyResources(Me.ExitForm, "ExitForm")
        Me.ExitForm.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.ExitForm.Name = "ExitForm"
        Me.ExitForm.UseVisualStyleBackColor = True
        '
        'WFileName
        '
        Me.WFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.WFileName, "WFileName")
        Me.WFileName.Name = "WFileName"
        Me.WFileName.ReadOnly = True
        Me.WFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.WFileName.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.FillWeight = 150.0!
        resources.ApplyResources(Me.Column1, "Column1")
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.FillWeight = 150.0!
        resources.ApplyResources(Me.Column2, "Column2")
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.FillWeight = 150.0!
        resources.ApplyResources(Me.Column3, "Column3")
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'AxisNoConfig
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ExitForm)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DelName)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.AddName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Configer)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.NoGrid)
        Me.Controls.Add(Me.NameGrid)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "AxisNoConfig"
        CType(Me.Configer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NameGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DelName As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents AddName As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Configer As System.Windows.Forms.DataGridView
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents NoGrid As System.Windows.Forms.DataGridView
    Friend WithEvents NameGrid As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CardNumTxt As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ExitForm As System.Windows.Forms.Button
    Friend WithEvents CardText As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WFileName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
