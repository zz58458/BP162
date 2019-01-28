<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IOForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IOForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TimerReadInIO = New System.Windows.Forms.Timer(Me.components)
        Me.AddCard_But = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CardNumInComBox = New System.Windows.Forms.ComboBox()
        Me.InIOoperate = New System.Windows.Forms.TabPage()
        Me.BtnAddInPut = New System.Windows.Forms.Button()
        Me.Save = New System.Windows.Forms.Button()
        Me.Del = New System.Windows.Forms.Button()
        Me.Configer = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.卡号 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.OK = New System.Windows.Forms.Button()
        Me.IOGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeGrid = New System.Windows.Forms.DataGridView()
        Me.WFileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.OutIOoperate = New System.Windows.Forms.TabPage()
        Me.CongOutIO = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CardOutNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.测试 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.OutIOGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeGridOut = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnAddOutPut = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SaveOutIO = New System.Windows.Forms.Button()
        Me.DelOut = New System.Windows.Forms.Button()
        Me.OutOK = New System.Windows.Forms.Button()
        Me.ExitFormIO = New System.Windows.Forms.Button()
        Me.InIOoperate.SuspendLayout()
        CType(Me.Configer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IOGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.OutIOoperate.SuspendLayout()
        CType(Me.CongOutIO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OutIOGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeGridOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerReadInIO
        '
        Me.TimerReadInIO.Enabled = True
        Me.TimerReadInIO.Interval = 200
        '
        'AddCard_But
        '
        resources.ApplyResources(Me.AddCard_But, "AddCard_But")
        Me.AddCard_But.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.AddCard_But.Name = "AddCard_But"
        Me.AddCard_But.UseVisualStyleBackColor = True
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label6.Name = "Label6"
        '
        'CardNumInComBox
        '
        resources.ApplyResources(Me.CardNumInComBox, "CardNumInComBox")
        Me.CardNumInComBox.FormattingEnabled = True
        Me.CardNumInComBox.Items.AddRange(New Object() {resources.GetString("CardNumInComBox.Items"), resources.GetString("CardNumInComBox.Items1"), resources.GetString("CardNumInComBox.Items2"), resources.GetString("CardNumInComBox.Items3")})
        Me.CardNumInComBox.Name = "CardNumInComBox"
        '
        'InIOoperate
        '
        resources.ApplyResources(Me.InIOoperate, "InIOoperate")
        Me.InIOoperate.Controls.Add(Me.BtnAddInPut)
        Me.InIOoperate.Controls.Add(Me.Save)
        Me.InIOoperate.Controls.Add(Me.Del)
        Me.InIOoperate.Controls.Add(Me.Configer)
        Me.InIOoperate.Controls.Add(Me.OK)
        Me.InIOoperate.Controls.Add(Me.IOGridView)
        Me.InIOoperate.Controls.Add(Me.TypeGrid)
        Me.InIOoperate.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.InIOoperate.Name = "InIOoperate"
        Me.InIOoperate.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.InIOoperate.UseVisualStyleBackColor = True
        '
        'BtnAddInPut
        '
        resources.ApplyResources(Me.BtnAddInPut, "BtnAddInPut")
        Me.BtnAddInPut.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.BtnAddInPut.Name = "BtnAddInPut"
        Me.BtnAddInPut.UseVisualStyleBackColor = True
        '
        'Save
        '
        resources.ApplyResources(Me.Save, "Save")
        Me.Save.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Save.Name = "Save"
        Me.Save.UseVisualStyleBackColor = True
        '
        'Del
        '
        resources.ApplyResources(Me.Del, "Del")
        Me.Del.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Del.Name = "Del"
        Me.Del.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Configer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Configer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Configer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.卡号, Me.DataGridViewTextBoxColumn4, Me.Column1, Me.Column3})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Configer.DefaultCellStyle = DataGridViewCellStyle2
        Me.Configer.MultiSelect = False
        Me.Configer.Name = "Configer"
        Me.Configer.RowHeadersVisible = False
        Me.Configer.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("新宋体", 10.0!)
        Me.Configer.RowTemplate.Height = 10
        Me.Configer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.DataGridViewTextBoxColumn3, "DataGridViewTextBoxColumn3")
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        '卡号
        '
        resources.ApplyResources(Me.卡号, "卡号")
        Me.卡号.Name = "卡号"
        Me.卡号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.卡号.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.DataGridViewTextBoxColumn4, "DataGridViewTextBoxColumn4")
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'Column1
        '
        resources.ApplyResources(Me.Column1, "Column1")
        Me.Column1.Name = "Column1"
        Me.Column1.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'Column3
        '
        resources.ApplyResources(Me.Column3, "Column3")
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'OK
        '
        resources.ApplyResources(Me.OK, "OK")
        Me.OK.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.OK.Name = "OK"
        Me.OK.UseVisualStyleBackColor = True
        '
        'IOGridView
        '
        resources.ApplyResources(Me.IOGridView, "IOGridView")
        Me.IOGridView.AllowUserToAddRows = False
        Me.IOGridView.AllowUserToDeleteRows = False
        Me.IOGridView.AllowUserToResizeColumns = False
        Me.IOGridView.AllowUserToResizeRows = False
        Me.IOGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.IOGridView.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow
        Me.IOGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IOGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.IOGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.IOGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IOGridView.DefaultCellStyle = DataGridViewCellStyle4
        Me.IOGridView.MultiSelect = False
        Me.IOGridView.Name = "IOGridView"
        Me.IOGridView.ReadOnly = True
        Me.IOGridView.RowHeadersVisible = False
        Me.IOGridView.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("新宋体", 10.0!)
        Me.IOGridView.RowTemplate.Height = 10
        Me.IOGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
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
        'TypeGrid
        '
        resources.ApplyResources(Me.TypeGrid, "TypeGrid")
        Me.TypeGrid.AllowUserToAddRows = False
        Me.TypeGrid.AllowUserToResizeColumns = False
        Me.TypeGrid.AllowUserToResizeRows = False
        Me.TypeGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.TypeGrid.BackgroundColor = System.Drawing.Color.PaleTurquoise
        Me.TypeGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TypeGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.TypeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TypeGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WFileName})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TypeGrid.DefaultCellStyle = DataGridViewCellStyle6
        Me.TypeGrid.MultiSelect = False
        Me.TypeGrid.Name = "TypeGrid"
        Me.TypeGrid.ReadOnly = True
        Me.TypeGrid.RowHeadersVisible = False
        Me.TypeGrid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("新宋体", 10.0!)
        Me.TypeGrid.RowTemplate.Height = 10
        Me.TypeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
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
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.InIOoperate)
        Me.TabControl1.Controls.Add(Me.OutIOoperate)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'OutIOoperate
        '
        resources.ApplyResources(Me.OutIOoperate, "OutIOoperate")
        Me.OutIOoperate.Controls.Add(Me.CongOutIO)
        Me.OutIOoperate.Controls.Add(Me.OutIOGridView)
        Me.OutIOoperate.Controls.Add(Me.TypeGridOut)
        Me.OutIOoperate.Controls.Add(Me.BtnAddOutPut)
        Me.OutIOoperate.Controls.Add(Me.Label3)
        Me.OutIOoperate.Controls.Add(Me.Label2)
        Me.OutIOoperate.Controls.Add(Me.SaveOutIO)
        Me.OutIOoperate.Controls.Add(Me.DelOut)
        Me.OutIOoperate.Controls.Add(Me.OutOK)
        Me.OutIOoperate.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.OutIOoperate.Name = "OutIOoperate"
        Me.OutIOoperate.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.OutIOoperate.UseVisualStyleBackColor = True
        '
        'CongOutIO
        '
        resources.ApplyResources(Me.CongOutIO, "CongOutIO")
        Me.CongOutIO.AllowUserToAddRows = False
        Me.CongOutIO.AllowUserToDeleteRows = False
        Me.CongOutIO.AllowUserToResizeColumns = False
        Me.CongOutIO.AllowUserToResizeRows = False
        Me.CongOutIO.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.CongOutIO.BackgroundColor = System.Drawing.Color.LightGray
        Me.CongOutIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CongOutIO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.CongOutIO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CongOutIO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.CardOutNum, Me.DataGridViewTextBoxColumn7, Me.DataGridViewComboBoxColumn1, Me.测试})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CongOutIO.DefaultCellStyle = DataGridViewCellStyle8
        Me.CongOutIO.MultiSelect = False
        Me.CongOutIO.Name = "CongOutIO"
        Me.CongOutIO.RowHeadersVisible = False
        Me.CongOutIO.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("新宋体", 10.0!)
        Me.CongOutIO.RowTemplate.Height = 10
        Me.CongOutIO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'CardOutNum
        '
        resources.ApplyResources(Me.CardOutNum, "CardOutNum")
        Me.CardOutNum.Name = "CardOutNum"
        Me.CardOutNum.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.DataGridViewTextBoxColumn7, "DataGridViewTextBoxColumn7")
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'DataGridViewComboBoxColumn1
        '
        resources.ApplyResources(Me.DataGridViewComboBoxColumn1, "DataGridViewComboBoxColumn1")
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        '测试
        '
        resources.ApplyResources(Me.测试, "测试")
        Me.测试.Name = "测试"
        Me.测试.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'OutIOGridView
        '
        resources.ApplyResources(Me.OutIOGridView, "OutIOGridView")
        Me.OutIOGridView.AllowUserToAddRows = False
        Me.OutIOGridView.AllowUserToDeleteRows = False
        Me.OutIOGridView.AllowUserToResizeColumns = False
        Me.OutIOGridView.AllowUserToResizeRows = False
        Me.OutIOGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.OutIOGridView.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow
        Me.OutIOGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OutIOGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.OutIOGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OutIOGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.OutIOGridView.DefaultCellStyle = DataGridViewCellStyle10
        Me.OutIOGridView.MultiSelect = False
        Me.OutIOGridView.Name = "OutIOGridView"
        Me.OutIOGridView.ReadOnly = True
        Me.OutIOGridView.RowHeadersVisible = False
        Me.OutIOGridView.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("新宋体", 10.0!)
        Me.OutIOGridView.RowTemplate.Height = 10
        Me.OutIOGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.DataGridViewTextBoxColumn5, "DataGridViewTextBoxColumn5")
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'TypeGridOut
        '
        resources.ApplyResources(Me.TypeGridOut, "TypeGridOut")
        Me.TypeGridOut.AllowUserToAddRows = False
        Me.TypeGridOut.AllowUserToDeleteRows = False
        Me.TypeGridOut.AllowUserToResizeColumns = False
        Me.TypeGridOut.AllowUserToResizeRows = False
        Me.TypeGridOut.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.TypeGridOut.BackgroundColor = System.Drawing.Color.PaleTurquoise
        Me.TypeGridOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TypeGridOut.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.TypeGridOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TypeGridOut.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TypeGridOut.DefaultCellStyle = DataGridViewCellStyle12
        Me.TypeGridOut.MultiSelect = False
        Me.TypeGridOut.Name = "TypeGridOut"
        Me.TypeGridOut.ReadOnly = True
        Me.TypeGridOut.RowHeadersVisible = False
        Me.TypeGridOut.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("新宋体", 10.0!)
        Me.TypeGridOut.RowTemplate.Height = 10
        Me.TypeGridOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.DataGridViewTextBoxColumn6, "DataGridViewTextBoxColumn6")
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.ToolTipText = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'BtnAddOutPut
        '
        resources.ApplyResources(Me.BtnAddOutPut, "BtnAddOutPut")
        Me.BtnAddOutPut.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.BtnAddOutPut.Name = "BtnAddOutPut"
        Me.BtnAddOutPut.UseVisualStyleBackColor = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label2.Name = "Label2"
        '
        'SaveOutIO
        '
        resources.ApplyResources(Me.SaveOutIO, "SaveOutIO")
        Me.SaveOutIO.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.SaveOutIO.Name = "SaveOutIO"
        Me.SaveOutIO.UseVisualStyleBackColor = True
        '
        'DelOut
        '
        resources.ApplyResources(Me.DelOut, "DelOut")
        Me.DelOut.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.DelOut.Name = "DelOut"
        Me.DelOut.UseVisualStyleBackColor = True
        '
        'OutOK
        '
        resources.ApplyResources(Me.OutOK, "OutOK")
        Me.OutOK.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.OutOK.Name = "OutOK"
        Me.OutOK.UseVisualStyleBackColor = True
        '
        'ExitFormIO
        '
        resources.ApplyResources(Me.ExitFormIO, "ExitFormIO")
        Me.ExitFormIO.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.ExitFormIO.Name = "ExitFormIO"
        Me.ExitFormIO.UseVisualStyleBackColor = True
        '
        'IOForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ControlBox = False
        Me.Controls.Add(Me.ExitFormIO)
        Me.Controls.Add(Me.AddCard_But)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CardNumInComBox)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IOForm"
        Me.InIOoperate.ResumeLayout(False)
        CType(Me.Configer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IOGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.OutIOoperate.ResumeLayout(False)
        Me.OutIOoperate.PerformLayout()
        CType(Me.CongOutIO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OutIOGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeGridOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimerReadInIO As System.Windows.Forms.Timer
    Friend WithEvents AddCard_But As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CardNumInComBox As System.Windows.Forms.ComboBox
    Friend WithEvents InIOoperate As System.Windows.Forms.TabPage
    Friend WithEvents BtnAddInPut As System.Windows.Forms.Button
    Friend WithEvents Save As System.Windows.Forms.Button
    Friend WithEvents Del As System.Windows.Forms.Button
    Friend WithEvents Configer As System.Windows.Forms.DataGridView
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents IOGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TypeGrid As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents OutIOoperate As System.Windows.Forms.TabPage
    Friend WithEvents CongOutIO As System.Windows.Forms.DataGridView
    Friend WithEvents OutIOGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TypeGridOut As System.Windows.Forms.DataGridView
    Friend WithEvents BtnAddOutPut As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveOutIO As System.Windows.Forms.Button
    Friend WithEvents DelOut As System.Windows.Forms.Button
    Friend WithEvents OutOK As System.Windows.Forms.Button
    Friend WithEvents ExitFormIO As System.Windows.Forms.Button
    Friend WithEvents WFileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 卡号 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CardOutNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents 测试 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
