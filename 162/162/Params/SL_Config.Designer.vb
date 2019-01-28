<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_Config
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(1, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(903, 489)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(895, 463)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "SL配置"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(43, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(240, 394)
        Me.DataGridView1.TabIndex = 21
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(300, 201)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(49, 23)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "加载"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(571, 201)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(49, 23)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "删除"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(436, 201)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(49, 23)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "保存"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox2.Controls.Add(Me.ComboBox4)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.ComboBox5)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(311, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(342, 151)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "_1入2出F1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(74, 105)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 21)
        Me.TextBox1.TabIndex = 14
        Me.TextBox1.Text = "DSD"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(0, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "物料剩余数："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "物料条码："
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(79, 70)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(83, 21)
        Me.NumericUpDown2.TabIndex = 7
        Me.NumericUpDown2.Value = New Decimal(New Integer() {1233, 0, 0, 0})
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"振动盘"})
        Me.ComboBox4.Location = New System.Drawing.Point(251, 69)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(85, 20)
        Me.ComboBox4.TabIndex = 6
        Me.ComboBox4.Text = "R2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(168, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 12)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "钢琴键位置："
        '
        'ComboBox5
        '
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Items.AddRange(New Object() {"振动盘"})
        Me.ComboBox5.Location = New System.Drawing.Point(251, 34)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(85, 20)
        Me.ComboBox5.TabIndex = 4
        Me.ComboBox5.Text = "C2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(192, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "端口号："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(32, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "名称："
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(79, 34)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(66, 21)
        Me.TextBox2.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"振动盘"})
        Me.ComboBox1.Location = New System.Drawing.Point(99, 13)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox1.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(246, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "添加"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "模式："
        '
        'SL_Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 502)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "SL_Config"
        Me.Text = "SL_Config"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
