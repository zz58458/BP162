<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.connect = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.txt_axis_dist = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.combox_axis_num = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_in = New System.Windows.Forms.TextBox()
        Me.txt_out = New System.Windows.Forms.TextBox()
        Me.txt_enc_pos = New System.Windows.Forms.TextBox()
        Me.out_num = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_num = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_jog_p = New System.Windows.Forms.Button()
        Me.btn_jog_n = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_stop_dec = New System.Windows.Forms.Button()
        Me.btn_axis_dec = New System.Windows.Forms.Button()
        Me.btn_axis_acc = New System.Windows.Forms.Button()
        Me.txt_min_vel = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_max_vel = New System.Windows.Forms.TextBox()
        Me.txt_acc_time = New System.Windows.Forms.TextBox()
        Me.txt_dec_time = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_axis_home = New System.Windows.Forms.Button()
        Me.btn_stop_emg = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_plan_pos = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.cmbox_home_mode = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_new_pos = New System.Windows.Forms.TextBox()
        Me.btn_set_target = New System.Windows.Forms.Button()
        Me.btn_card_init = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_ready = New System.Windows.Forms.Button()
        Me.btn_inpos = New System.Windows.Forms.Button()
        Me.btn_alarm = New System.Windows.Forms.Button()
        Me.txt_ready = New System.Windows.Forms.TextBox()
        Me.txt_inpos = New System.Windows.Forms.TextBox()
        Me.txt_alarm = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'connect
        '
        Me.connect.Location = New System.Drawing.Point(12, 12)
        Me.connect.Name = "connect"
        Me.connect.Size = New System.Drawing.Size(48, 23)
        Me.connect.TabIndex = 0
        Me.connect.Text = "连接"
        Me.connect.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(66, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(48, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "断开"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(8, 68)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 13
        Me.Button10.Text = "使能"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(7, 25)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 23)
        Me.Button11.TabIndex = 14
        Me.Button11.Text = "正"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(132, 25)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 23)
        Me.Button12.TabIndex = 15
        Me.Button12.Text = "负"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(105, 68)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 16
        Me.Button8.Text = "去使能"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(297, 179)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(71, 23)
        Me.Button9.TabIndex = 17
        Me.Button9.Text = "OUT-ON"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(375, 179)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(57, 23)
        Me.Button13.TabIndex = 18
        Me.Button13.Text = "OUT-OFF"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19"})
        Me.ComboBox1.Location = New System.Drawing.Point(243, 181)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(48, 20)
        Me.ComboBox1.TabIndex = 19
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(301, 25)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(75, 23)
        Me.Button14.TabIndex = 20
        Me.Button14.Text = "READ_IN"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(301, 63)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(75, 23)
        Me.Button15.TabIndex = 21
        Me.Button15.Text = "READ_OUT"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(216, 97)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(104, 23)
        Me.Button16.TabIndex = 22
        Me.Button16.Text = "读编码器位置"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'txt_axis_dist
        '
        Me.txt_axis_dist.Location = New System.Drawing.Point(64, 99)
        Me.txt_axis_dist.Name = "txt_axis_dist"
        Me.txt_axis_dist.Size = New System.Drawing.Size(82, 21)
        Me.txt_axis_dist.TabIndex = 23
        Me.txt_axis_dist.Text = "10000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "步距："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "控制轴号："
        '
        'combox_axis_num
        '
        Me.combox_axis_num.FormattingEnabled = True
        Me.combox_axis_num.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5"})
        Me.combox_axis_num.Location = New System.Drawing.Point(105, 41)
        Me.combox_axis_num.Name = "combox_axis_num"
        Me.combox_axis_num.Size = New System.Drawing.Size(75, 20)
        Me.combox_axis_num.TabIndex = 27
        Me.combox_axis_num.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(214, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 12)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "OUT"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(152, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "脉冲"
        '
        'txt_in
        '
        Me.txt_in.Location = New System.Drawing.Point(382, 25)
        Me.txt_in.Name = "txt_in"
        Me.txt_in.Size = New System.Drawing.Size(50, 21)
        Me.txt_in.TabIndex = 29
        Me.txt_in.Text = "0"
        '
        'txt_out
        '
        Me.txt_out.Location = New System.Drawing.Point(382, 62)
        Me.txt_out.Name = "txt_out"
        Me.txt_out.Size = New System.Drawing.Size(50, 21)
        Me.txt_out.TabIndex = 30
        Me.txt_out.Text = "0"
        '
        'txt_enc_pos
        '
        Me.txt_enc_pos.Location = New System.Drawing.Point(326, 97)
        Me.txt_enc_pos.Name = "txt_enc_pos"
        Me.txt_enc_pos.Size = New System.Drawing.Size(106, 21)
        Me.txt_enc_pos.TabIndex = 31
        Me.txt_enc_pos.Text = "0"
        '
        'out_num
        '
        Me.out_num.FormattingEnabled = True
        Me.out_num.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19"})
        Me.out_num.Location = New System.Drawing.Point(248, 65)
        Me.out_num.Name = "out_num"
        Me.out_num.Size = New System.Drawing.Size(48, 20)
        Me.out_num.TabIndex = 32
        Me.out_num.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(219, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 12)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "NO:"
        '
        'in_num
        '
        Me.in_num.FormattingEnabled = True
        Me.in_num.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        Me.in_num.Location = New System.Drawing.Point(248, 28)
        Me.in_num.Name = "in_num"
        Me.in_num.Size = New System.Drawing.Size(47, 20)
        Me.in_num.TabIndex = 34
        Me.in_num.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(219, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 12)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "NO:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button11)
        Me.GroupBox1.Controls.Add(Me.Button12)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 270)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(213, 59)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "点位运动"
        '
        'btn_jog_p
        '
        Me.btn_jog_p.Location = New System.Drawing.Point(7, 20)
        Me.btn_jog_p.Name = "btn_jog_p"
        Me.btn_jog_p.Size = New System.Drawing.Size(45, 23)
        Me.btn_jog_p.TabIndex = 37
        Me.btn_jog_p.Text = "正"
        Me.btn_jog_p.UseVisualStyleBackColor = True
        '
        'btn_jog_n
        '
        Me.btn_jog_n.Location = New System.Drawing.Point(58, 20)
        Me.btn_jog_n.Name = "btn_jog_n"
        Me.btn_jog_n.Size = New System.Drawing.Size(45, 23)
        Me.btn_jog_n.TabIndex = 38
        Me.btn_jog_n.Text = "负"
        Me.btn_jog_n.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_stop_dec)
        Me.GroupBox2.Controls.Add(Me.btn_axis_dec)
        Me.GroupBox2.Controls.Add(Me.btn_axis_acc)
        Me.GroupBox2.Controls.Add(Me.btn_jog_p)
        Me.GroupBox2.Controls.Add(Me.btn_jog_n)
        Me.GroupBox2.Location = New System.Drawing.Point(454, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(265, 59)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "JOG"
        '
        'btn_stop_dec
        '
        Me.btn_stop_dec.Location = New System.Drawing.Point(212, 22)
        Me.btn_stop_dec.Name = "btn_stop_dec"
        Me.btn_stop_dec.Size = New System.Drawing.Size(47, 23)
        Me.btn_stop_dec.TabIndex = 53
        Me.btn_stop_dec.Text = "停止"
        Me.btn_stop_dec.UseVisualStyleBackColor = True
        '
        'btn_axis_dec
        '
        Me.btn_axis_dec.Location = New System.Drawing.Point(160, 20)
        Me.btn_axis_dec.Name = "btn_axis_dec"
        Me.btn_axis_dec.Size = New System.Drawing.Size(45, 23)
        Me.btn_axis_dec.TabIndex = 52
        Me.btn_axis_dec.Text = "减速"
        Me.btn_axis_dec.UseVisualStyleBackColor = True
        '
        'btn_axis_acc
        '
        Me.btn_axis_acc.Location = New System.Drawing.Point(109, 20)
        Me.btn_axis_acc.Name = "btn_axis_acc"
        Me.btn_axis_acc.Size = New System.Drawing.Size(45, 23)
        Me.btn_axis_acc.TabIndex = 39
        Me.btn_axis_acc.Text = "加速"
        Me.btn_axis_acc.UseVisualStyleBackColor = True
        '
        'txt_min_vel
        '
        Me.txt_min_vel.Location = New System.Drawing.Point(78, 21)
        Me.txt_min_vel.Name = "txt_min_vel"
        Me.txt_min_vel.Size = New System.Drawing.Size(54, 21)
        Me.txt_min_vel.TabIndex = 40
        Me.txt_min_vel.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "最小速度："
        '
        'txt_max_vel
        '
        Me.txt_max_vel.Location = New System.Drawing.Point(78, 48)
        Me.txt_max_vel.Name = "txt_max_vel"
        Me.txt_max_vel.Size = New System.Drawing.Size(54, 21)
        Me.txt_max_vel.TabIndex = 41
        Me.txt_max_vel.Text = "1000"
        '
        'txt_acc_time
        '
        Me.txt_acc_time.Location = New System.Drawing.Point(78, 76)
        Me.txt_acc_time.Name = "txt_acc_time"
        Me.txt_acc_time.Size = New System.Drawing.Size(54, 21)
        Me.txt_acc_time.TabIndex = 42
        Me.txt_acc_time.Text = "0.01"
        '
        'txt_dec_time
        '
        Me.txt_dec_time.Location = New System.Drawing.Point(78, 104)
        Me.txt_dec_time.Name = "txt_dec_time"
        Me.txt_dec_time.Size = New System.Drawing.Size(54, 21)
        Me.txt_dec_time.TabIndex = 43
        Me.txt_dec_time.Text = "0.01"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "最大速度："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "加速时间："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 107)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 12)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "减速时间"
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(141, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 12)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "pluse/s"
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
        Me.GroupBox3.Location = New System.Drawing.Point(8, 126)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(194, 138)
        Me.GroupBox3.TabIndex = 44
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "运动参数"
        '
        'btn_axis_home
        '
        Me.btn_axis_home.Location = New System.Drawing.Point(375, 215)
        Me.btn_axis_home.Name = "btn_axis_home"
        Me.btn_axis_home.Size = New System.Drawing.Size(57, 23)
        Me.btn_axis_home.TabIndex = 45
        Me.btn_axis_home.Text = "回零"
        Me.btn_axis_home.UseVisualStyleBackColor = True
        '
        'btn_stop_emg
        '
        Me.btn_stop_emg.Location = New System.Drawing.Point(208, 241)
        Me.btn_stop_emg.Name = "btn_stop_emg"
        Me.btn_stop_emg.Size = New System.Drawing.Size(224, 23)
        Me.btn_stop_emg.TabIndex = 46
        Me.btn_stop_emg.Text = "急停"
        Me.btn_stop_emg.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(219, 138)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 23)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "读取规划位置"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt_plan_pos
        '
        Me.txt_plan_pos.Location = New System.Drawing.Point(327, 138)
        Me.txt_plan_pos.Name = "txt_plan_pos"
        Me.txt_plan_pos.Size = New System.Drawing.Size(105, 21)
        Me.txt_plan_pos.TabIndex = 49
        Me.txt_plan_pos.Text = "0"
        '
        'BackgroundWorker1
        '
        '
        'cmbox_home_mode
        '
        Me.cmbox_home_mode.FormattingEnabled = True
        Me.cmbox_home_mode.Items.AddRange(New Object() {"原点", "原点+EZ", "EZ"})
        Me.cmbox_home_mode.Location = New System.Drawing.Point(269, 215)
        Me.cmbox_home_mode.Name = "cmbox_home_mode"
        Me.cmbox_home_mode.Size = New System.Drawing.Size(100, 20)
        Me.cmbox_home_mode.TabIndex = 50
        Me.cmbox_home_mode.Text = "原点"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(208, 220)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "回零方式："
        '
        'txt_new_pos
        '
        Me.txt_new_pos.Location = New System.Drawing.Point(243, 295)
        Me.txt_new_pos.Name = "txt_new_pos"
        Me.txt_new_pos.Size = New System.Drawing.Size(100, 21)
        Me.txt_new_pos.TabIndex = 52
        Me.txt_new_pos.Text = "0"
        '
        'btn_set_target
        '
        Me.btn_set_target.Location = New System.Drawing.Point(357, 293)
        Me.btn_set_target.Name = "btn_set_target"
        Me.btn_set_target.Size = New System.Drawing.Size(75, 23)
        Me.btn_set_target.TabIndex = 53
        Me.btn_set_target.Text = "更新位置"
        Me.btn_set_target.UseVisualStyleBackColor = True
        '
        'btn_card_init
        '
        Me.btn_card_init.Location = New System.Drawing.Point(120, 12)
        Me.btn_card_init.Name = "btn_card_init"
        Me.btn_card_init.Size = New System.Drawing.Size(60, 23)
        Me.btn_card_init.TabIndex = 54
        Me.btn_card_init.Text = "初始化"
        Me.btn_card_init.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(454, 97)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 55
        Me.Button2.Text = "位置清零"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_ready
        '
        Me.btn_ready.Location = New System.Drawing.Point(461, 138)
        Me.btn_ready.Name = "btn_ready"
        Me.btn_ready.Size = New System.Drawing.Size(75, 23)
        Me.btn_ready.TabIndex = 56
        Me.btn_ready.Text = "READY"
        Me.btn_ready.UseVisualStyleBackColor = True
        '
        'btn_inpos
        '
        Me.btn_inpos.Location = New System.Drawing.Point(461, 177)
        Me.btn_inpos.Name = "btn_inpos"
        Me.btn_inpos.Size = New System.Drawing.Size(75, 23)
        Me.btn_inpos.TabIndex = 57
        Me.btn_inpos.Text = "INPOS"
        Me.btn_inpos.UseVisualStyleBackColor = True
        '
        'btn_alarm
        '
        Me.btn_alarm.Location = New System.Drawing.Point(461, 214)
        Me.btn_alarm.Name = "btn_alarm"
        Me.btn_alarm.Size = New System.Drawing.Size(75, 23)
        Me.btn_alarm.TabIndex = 58
        Me.btn_alarm.Text = "ALARM"
        Me.btn_alarm.UseVisualStyleBackColor = True
        '
        'txt_ready
        '
        Me.txt_ready.Location = New System.Drawing.Point(563, 137)
        Me.txt_ready.Name = "txt_ready"
        Me.txt_ready.Size = New System.Drawing.Size(100, 21)
        Me.txt_ready.TabIndex = 59
        '
        'txt_inpos
        '
        Me.txt_inpos.Location = New System.Drawing.Point(563, 177)
        Me.txt_inpos.Name = "txt_inpos"
        Me.txt_inpos.Size = New System.Drawing.Size(100, 21)
        Me.txt_inpos.TabIndex = 60
        '
        'txt_alarm
        '
        Me.txt_alarm.Location = New System.Drawing.Point(563, 220)
        Me.txt_alarm.Name = "txt_alarm"
        Me.txt_alarm.Size = New System.Drawing.Size(100, 21)
        Me.txt_alarm.TabIndex = 61
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 331)
        Me.Controls.Add(Me.txt_alarm)
        Me.Controls.Add(Me.txt_inpos)
        Me.Controls.Add(Me.txt_ready)
        Me.Controls.Add(Me.btn_alarm)
        Me.Controls.Add(Me.btn_inpos)
        Me.Controls.Add(Me.btn_ready)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_card_init)
        Me.Controls.Add(Me.btn_set_target)
        Me.Controls.Add(Me.txt_new_pos)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbox_home_mode)
        Me.Controls.Add(Me.txt_plan_pos)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_stop_emg)
        Me.Controls.Add(Me.btn_axis_home)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.in_num)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.out_num)
        Me.Controls.Add(Me.txt_enc_pos)
        Me.Controls.Add(Me.txt_out)
        Me.Controls.Add(Me.txt_in)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.combox_axis_num)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_axis_dist)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.connect)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents connect As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents txt_axis_dist As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents combox_axis_num As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_in As TextBox
    Friend WithEvents txt_out As TextBox
    Friend WithEvents txt_enc_pos As TextBox
    Friend WithEvents out_num As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents in_num As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn_jog_p As Button
    Friend WithEvents btn_jog_n As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txt_min_vel As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_max_vel As TextBox
    Friend WithEvents txt_acc_time As TextBox
    Friend WithEvents txt_dec_time As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btn_axis_home As Button
    Friend WithEvents btn_stop_emg As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txt_plan_pos As TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmbox_home_mode As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btn_axis_dec As Button
    Friend WithEvents btn_axis_acc As Button
    Friend WithEvents btn_stop_dec As Button
    Friend WithEvents txt_new_pos As TextBox
    Friend WithEvents btn_set_target As Button
    Friend WithEvents btn_card_init As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btn_ready As Button
    Friend WithEvents btn_inpos As Button
    Friend WithEvents btn_alarm As Button
    Friend WithEvents txt_ready As TextBox
    Friend WithEvents txt_inpos As TextBox
    Friend WithEvents txt_alarm As TextBox
End Class
