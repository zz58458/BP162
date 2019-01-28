<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMain
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
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txt_plan_pos = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txt_enc_pos = New System.Windows.Forms.TextBox()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_dec_time = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_acc_time = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_max_vel = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_min_vel = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TexBox_Axis_Distance = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComBox_Axis_Num = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.配置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.点位配置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.运动配置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.速度配置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.调试ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IO调试ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.未配置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.未配置的轴ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.修改卡参数ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(497, 372)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button5)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.txt_plan_pos)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.txt_enc_pos)
        Me.TabPage1.Controls.Add(Me.Button16)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.Button8)
        Me.TabPage1.Controls.Add(Me.Button10)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.TexBox_Axis_Distance)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.ComBox_Axis_Num)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(489, 346)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "测试轴"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(318, 104)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 81
        Me.Button5.Text = "断开"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(338, 290)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 80
        Me.Button4.Text = "急停"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txt_plan_pos
        '
        Me.txt_plan_pos.Location = New System.Drawing.Point(369, 56)
        Me.txt_plan_pos.Name = "txt_plan_pos"
        Me.txt_plan_pos.Size = New System.Drawing.Size(105, 21)
        Me.txt_plan_pos.TabIndex = 79
        Me.txt_plan_pos.Text = "0"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(261, 56)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 23)
        Me.Button3.TabIndex = 78
        Me.Button3.Text = "读取规划位置"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txt_enc_pos
        '
        Me.txt_enc_pos.Location = New System.Drawing.Point(368, 15)
        Me.txt_enc_pos.Name = "txt_enc_pos"
        Me.txt_enc_pos.Size = New System.Drawing.Size(106, 21)
        Me.txt_enc_pos.TabIndex = 77
        Me.txt_enc_pos.Text = "0"
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(258, 15)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(104, 23)
        Me.Button16.TabIndex = 76
        Me.Button16.Text = "读编码器位置"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(120, 312)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 75
        Me.Button2.Text = "负"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txt_dec_time)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txt_acc_time)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txt_max_vel)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txt_min_vel)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(19, 108)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(194, 138)
        Me.GroupBox3.TabIndex = 74
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "运动参数"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "最大速度："
        '
        'txt_dec_time
        '
        Me.txt_dec_time.Location = New System.Drawing.Point(78, 104)
        Me.txt_dec_time.Name = "txt_dec_time"
        Me.txt_dec_time.Size = New System.Drawing.Size(54, 21)
        Me.txt_dec_time.TabIndex = 43
        Me.txt_dec_time.Text = "0.01"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "最小速度："
        '
        'txt_acc_time
        '
        Me.txt_acc_time.Location = New System.Drawing.Point(78, 76)
        Me.txt_acc_time.Name = "txt_acc_time"
        Me.txt_acc_time.Size = New System.Drawing.Size(54, 21)
        Me.txt_acc_time.TabIndex = 42
        Me.txt_acc_time.Text = "0.01"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(141, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 12)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "pulse/s"
        '
        'txt_max_vel
        '
        Me.txt_max_vel.Location = New System.Drawing.Point(78, 48)
        Me.txt_max_vel.Name = "txt_max_vel"
        Me.txt_max_vel.Size = New System.Drawing.Size(54, 21)
        Me.txt_max_vel.TabIndex = 41
        Me.txt_max_vel.Text = "1000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(141, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 12)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "pluse/s"
        '
        'txt_min_vel
        '
        Me.txt_min_vel.Location = New System.Drawing.Point(78, 21)
        Me.txt_min_vel.Name = "txt_min_vel"
        Me.txt_min_vel.Size = New System.Drawing.Size(54, 21)
        Me.txt_min_vel.TabIndex = 40
        Me.txt_min_vel.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(141, 79)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 12)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "s"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(141, 107)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 12)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "s"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "加速时间："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "减速时间："
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(120, 264)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 73
        Me.Button8.Text = "去使能"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(23, 264)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 72
        Me.Button10.Text = "使能"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(23, 312)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 71
        Me.Button1.Text = "正"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TexBox_Axis_Distance
        '
        Me.TexBox_Axis_Distance.Location = New System.Drawing.Point(82, 61)
        Me.TexBox_Axis_Distance.Name = "TexBox_Axis_Distance"
        Me.TexBox_Axis_Distance.Size = New System.Drawing.Size(121, 21)
        Me.TexBox_Axis_Distance.TabIndex = 70
        Me.TexBox_Axis_Distance.Text = "10000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "距离："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "轴号："
        '
        'ComBox_Axis_Num
        '
        Me.ComBox_Axis_Num.FormattingEnabled = True
        Me.ComBox_Axis_Num.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"})
        Me.ComBox_Axis_Num.Location = New System.Drawing.Point(82, 17)
        Me.ComBox_Axis_Num.Name = "ComBox_Axis_Num"
        Me.ComBox_Axis_Num.Size = New System.Drawing.Size(121, 20)
        Me.ComBox_Axis_Num.TabIndex = 67
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.配置ToolStripMenuItem, Me.调试ToolStripMenuItem, Me.未配置ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(784, 25)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '配置ToolStripMenuItem
        '
        Me.配置ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.点位配置ToolStripMenuItem, Me.运动配置ToolStripMenuItem, Me.速度配置ToolStripMenuItem})
        Me.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem"
        Me.配置ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.配置ToolStripMenuItem.Text = "配置"
        '
        '点位配置ToolStripMenuItem
        '
        Me.点位配置ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExplorerToolStripMenuItem})
        Me.点位配置ToolStripMenuItem.Name = "点位配置ToolStripMenuItem"
        Me.点位配置ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.点位配置ToolStripMenuItem.Text = "轨迹配置"
        '
        'ExplorerToolStripMenuItem
        '
        Me.ExplorerToolStripMenuItem.Name = "ExplorerToolStripMenuItem"
        Me.ExplorerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExplorerToolStripMenuItem.Text = "Explorer"
        '
        '运动配置ToolStripMenuItem
        '
        Me.运动配置ToolStripMenuItem.Name = "运动配置ToolStripMenuItem"
        Me.运动配置ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.运动配置ToolStripMenuItem.Text = "运动基本参数配置"
        '
        '速度配置ToolStripMenuItem
        '
        Me.速度配置ToolStripMenuItem.Name = "速度配置ToolStripMenuItem"
        Me.速度配置ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.速度配置ToolStripMenuItem.Text = "速度配置"
        '
        '调试ToolStripMenuItem
        '
        Me.调试ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IO调试ToolStripMenuItem})
        Me.调试ToolStripMenuItem.Name = "调试ToolStripMenuItem"
        Me.调试ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.调试ToolStripMenuItem.Text = "监控"
        '
        'IO调试ToolStripMenuItem
        '
        Me.IO调试ToolStripMenuItem.Name = "IO调试ToolStripMenuItem"
        Me.IO调试ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.IO调试ToolStripMenuItem.Text = "IO监控界面"
        '
        '未配置ToolStripMenuItem
        '
        Me.未配置ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.未配置的轴ToolStripMenuItem, Me.修改卡参数ToolStripMenuItem})
        Me.未配置ToolStripMenuItem.Name = "未配置ToolStripMenuItem"
        Me.未配置ToolStripMenuItem.Size = New System.Drawing.Size(56, 21)
        Me.未配置ToolStripMenuItem.Text = "可配置"
        '
        '未配置的轴ToolStripMenuItem
        '
        Me.未配置的轴ToolStripMenuItem.Name = "未配置的轴ToolStripMenuItem"
        Me.未配置的轴ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.未配置的轴ToolStripMenuItem.Text = "可配置的轴"
        '
        '修改卡参数ToolStripMenuItem
        '
        Me.修改卡参数ToolStripMenuItem.Name = "修改卡参数ToolStripMenuItem"
        Me.修改卡参数ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.修改卡参数ToolStripMenuItem.Text = "可配置的IO"
        '
        'FMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 502)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FMain"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txt_plan_pos As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txt_enc_pos As System.Windows.Forms.TextBox
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_dec_time As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_acc_time As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_max_vel As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_min_vel As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TexBox_Axis_Distance As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComBox_Axis_Num As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 配置ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 调试ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IO调试ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 点位配置ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 未配置ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 未配置的轴ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 运动配置ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 修改卡参数ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 速度配置ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
