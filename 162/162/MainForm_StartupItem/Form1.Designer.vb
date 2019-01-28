<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.LabMes = New System.Windows.Forms.Label()
        Me.ComName = New System.Windows.Forms.ComboBox()
        Me.LabName = New System.Windows.Forms.Label()
        Me.LabNum = New System.Windows.Forms.Label()
        Me.LabPassword = New System.Windows.Forms.Label()
        Me.RadGeneral = New System.Windows.Forms.RadioButton()
        Me.RadEngineel = New System.Windows.Forms.RadioButton()
        Me.RadAdminis = New System.Windows.Forms.RadioButton()
        Me.ButLink = New System.Windows.Forms.Button()
        Me.ButChange = New System.Windows.Forms.Button()
        Me.ButExit = New System.Windows.Forms.Button()
        Me.LabMesNew = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.GroMesLink = New System.Windows.Forms.GroupBox()
        Me.TexPassword = New System.Windows.Forms.TextBox()
        Me.TexNum = New System.Windows.Forms.TextBox()
        Me.GroMesNew = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButRegister = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextUsePass = New System.Windows.Forms.TextBox()
        Me.TextUseNum = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComUseName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TexSetName = New System.Windows.Forms.TextBox()
        Me.TextPassChange = New System.Windows.Forms.TextBox()
        Me.TextNumChange = New System.Windows.Forms.TextBox()
        Me.LabSetName = New System.Windows.Forms.Label()
        Me.LabSetPass = New System.Windows.Forms.Label()
        Me.LabSetNum = New System.Windows.Forms.Label()
        Me.ButExitChange = New System.Windows.Forms.Button()
        Me.ButDeleChange = New System.Windows.Forms.Button()
        Me.ButMakeChanges = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroMesLink.SuspendLayout()
        Me.GroMesNew.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabMes
        '
        Me.LabMes.AutoSize = True
        Me.LabMes.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabMes.Location = New System.Drawing.Point(6, 37)
        Me.LabMes.Name = "LabMes"
        Me.LabMes.Size = New System.Drawing.Size(178, 21)
        Me.LabMes.TabIndex = 0
        Me.LabMes.Text = "MES连接用户登录"
        '
        'ComName
        '
        Me.ComName.FormattingEnabled = True
        Me.ComName.Location = New System.Drawing.Point(21, 123)
        Me.ComName.Name = "ComName"
        Me.ComName.Size = New System.Drawing.Size(121, 20)
        Me.ComName.TabIndex = 1
        '
        'LabName
        '
        Me.LabName.AutoSize = True
        Me.LabName.Location = New System.Drawing.Point(19, 97)
        Me.LabName.Name = "LabName"
        Me.LabName.Size = New System.Drawing.Size(53, 12)
        Me.LabName.TabIndex = 2
        Me.LabName.Text = "用户名："
        '
        'LabNum
        '
        Me.LabNum.AutoSize = True
        Me.LabNum.Location = New System.Drawing.Point(19, 157)
        Me.LabNum.Name = "LabNum"
        Me.LabNum.Size = New System.Drawing.Size(41, 12)
        Me.LabNum.TabIndex = 4
        Me.LabNum.Text = "工号："
        '
        'LabPassword
        '
        Me.LabPassword.AutoSize = True
        Me.LabPassword.Location = New System.Drawing.Point(19, 217)
        Me.LabPassword.Name = "LabPassword"
        Me.LabPassword.Size = New System.Drawing.Size(41, 12)
        Me.LabPassword.TabIndex = 6
        Me.LabPassword.Text = "密码："
        '
        'RadGeneral
        '
        Me.RadGeneral.AutoSize = True
        Me.RadGeneral.Location = New System.Drawing.Point(70, 320)
        Me.RadGeneral.Name = "RadGeneral"
        Me.RadGeneral.Size = New System.Drawing.Size(71, 16)
        Me.RadGeneral.TabIndex = 7
        Me.RadGeneral.Text = "普通用户"
        Me.RadGeneral.UseVisualStyleBackColor = True
        '
        'RadEngineel
        '
        Me.RadEngineel.AutoSize = True
        Me.RadEngineel.Location = New System.Drawing.Point(249, 320)
        Me.RadEngineel.Name = "RadEngineel"
        Me.RadEngineel.Size = New System.Drawing.Size(59, 16)
        Me.RadEngineel.TabIndex = 8
        Me.RadEngineel.Text = "工程师"
        Me.RadEngineel.UseVisualStyleBackColor = True
        '
        'RadAdminis
        '
        Me.RadAdminis.AutoSize = True
        Me.RadAdminis.Location = New System.Drawing.Point(447, 320)
        Me.RadAdminis.Name = "RadAdminis"
        Me.RadAdminis.Size = New System.Drawing.Size(59, 16)
        Me.RadAdminis.TabIndex = 9
        Me.RadAdminis.Text = "管理员"
        Me.RadAdminis.UseVisualStyleBackColor = True
        '
        'ButLink
        '
        Me.ButLink.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButLink.Location = New System.Drawing.Point(52, 377)
        Me.ButLink.Name = "ButLink"
        Me.ButLink.Size = New System.Drawing.Size(107, 46)
        Me.ButLink.TabIndex = 10
        Me.ButLink.Text = "登陆"
        Me.ButLink.UseVisualStyleBackColor = True
        '
        'ButChange
        '
        Me.ButChange.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButChange.Location = New System.Drawing.Point(225, 377)
        Me.ButChange.Name = "ButChange"
        Me.ButChange.Size = New System.Drawing.Size(107, 46)
        Me.ButChange.TabIndex = 11
        Me.ButChange.Text = "更改密码"
        Me.ButChange.UseVisualStyleBackColor = True
        '
        'ButExit
        '
        Me.ButExit.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButExit.Location = New System.Drawing.Point(399, 377)
        Me.ButExit.Name = "ButExit"
        Me.ButExit.Size = New System.Drawing.Size(107, 46)
        Me.ButExit.TabIndex = 12
        Me.ButExit.Text = "退出"
        Me.ButExit.UseVisualStyleBackColor = True
        '
        'LabMesNew
        '
        Me.LabMesNew.AutoSize = True
        Me.LabMesNew.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabMesNew.Location = New System.Drawing.Point(61, 37)
        Me.LabMesNew.Name = "LabMesNew"
        Me.LabMesNew.Size = New System.Drawing.Size(134, 21)
        Me.LabMesNew.TabIndex = 13
        Me.LabMesNew.Text = "MES生产信息"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "产品单号："
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(104, 111)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox1.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "产品批次："
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(104, 171)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox2.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "产品型号："
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(104, 231)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox3.TabIndex = 18
        '
        'GroMesLink
        '
        Me.GroMesLink.Controls.Add(Me.TexPassword)
        Me.GroMesLink.Controls.Add(Me.TexNum)
        Me.GroMesLink.Controls.Add(Me.LabMes)
        Me.GroMesLink.Controls.Add(Me.ComName)
        Me.GroMesLink.Controls.Add(Me.LabName)
        Me.GroMesLink.Controls.Add(Me.LabNum)
        Me.GroMesLink.Controls.Add(Me.LabPassword)
        Me.GroMesLink.Location = New System.Drawing.Point(17, 20)
        Me.GroMesLink.Name = "GroMesLink"
        Me.GroMesLink.Size = New System.Drawing.Size(215, 280)
        Me.GroMesLink.TabIndex = 20
        Me.GroMesLink.TabStop = False
        Me.GroMesLink.Text = "登陆信息："
        '
        'TexPassword
        '
        Me.TexPassword.Location = New System.Drawing.Point(21, 239)
        Me.TexPassword.Name = "TexPassword"
        Me.TexPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TexPassword.Size = New System.Drawing.Size(121, 21)
        Me.TexPassword.TabIndex = 30
        Me.TexPassword.Text = "5454"
        Me.TexPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TexNum
        '
        Me.TexNum.Location = New System.Drawing.Point(21, 179)
        Me.TexNum.Name = "TexNum"
        Me.TexNum.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TexNum.Size = New System.Drawing.Size(121, 21)
        Me.TexNum.TabIndex = 29
        Me.TexNum.Text = "123456"
        Me.TexNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroMesNew
        '
        Me.GroMesNew.Controls.Add(Me.LabMesNew)
        Me.GroMesNew.Controls.Add(Me.ComboBox1)
        Me.GroMesNew.Controls.Add(Me.Label3)
        Me.GroMesNew.Controls.Add(Me.Label1)
        Me.GroMesNew.Controls.Add(Me.ComboBox3)
        Me.GroMesNew.Controls.Add(Me.ComboBox2)
        Me.GroMesNew.Controls.Add(Me.Label2)
        Me.GroMesNew.Location = New System.Drawing.Point(249, 20)
        Me.GroMesNew.Name = "GroMesNew"
        Me.GroMesNew.Size = New System.Drawing.Size(257, 280)
        Me.GroMesNew.TabIndex = 21
        Me.GroMesNew.TabStop = False
        Me.GroMesNew.Text = "MES信息："
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroMesNew)
        Me.GroupBox1.Controls.Add(Me.RadGeneral)
        Me.GroupBox1.Controls.Add(Me.GroMesLink)
        Me.GroupBox1.Controls.Add(Me.RadEngineel)
        Me.GroupBox1.Controls.Add(Me.ButExit)
        Me.GroupBox1.Controls.Add(Me.RadAdminis)
        Me.GroupBox1.Controls.Add(Me.ButChange)
        Me.GroupBox1.Controls.Add(Me.ButLink)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(529, 456)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButRegister)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.ButExitChange)
        Me.GroupBox2.Controls.Add(Me.ButDeleChange)
        Me.GroupBox2.Controls.Add(Me.ButMakeChanges)
        Me.GroupBox2.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(555, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(349, 456)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "更改密码："
        '
        'ButRegister
        '
        Me.ButRegister.Location = New System.Drawing.Point(106, 377)
        Me.ButRegister.Name = "ButRegister"
        Me.ButRegister.Size = New System.Drawing.Size(63, 63)
        Me.ButRegister.TabIndex = 29
        Me.ButRegister.Text = "注册"
        Me.ButRegister.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextUsePass)
        Me.GroupBox3.Controls.Add(Me.TextUseNum)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.ComUseName)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(315, 165)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "原用户信息："
        '
        'TextUsePass
        '
        Me.TextUsePass.Location = New System.Drawing.Point(105, 122)
        Me.TextUsePass.Name = "TextUsePass"
        Me.TextUsePass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextUsePass.Size = New System.Drawing.Size(121, 30)
        Me.TextUsePass.TabIndex = 33
        Me.TextUsePass.Text = "5454"
        Me.TextUsePass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextUseNum
        '
        Me.TextUseNum.Location = New System.Drawing.Point(105, 81)
        Me.TextUseNum.Name = "TextUseNum"
        Me.TextUseNum.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextUseNum.Size = New System.Drawing.Size(121, 30)
        Me.TextUseNum.TabIndex = 32
        Me.TextUseNum.Text = "123456"
        Me.TextUseNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 20)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "用户名："
        '
        'ComUseName
        '
        Me.ComUseName.FormattingEnabled = True
        Me.ComUseName.Location = New System.Drawing.Point(105, 42)
        Me.ComUseName.Name = "ComUseName"
        Me.ComUseName.Size = New System.Drawing.Size(121, 28)
        Me.ComUseName.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 20)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "密码："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 20)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "工号："
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.ControlDark
        Me.GroupBox4.Controls.Add(Me.TexSetName)
        Me.GroupBox4.Controls.Add(Me.TextPassChange)
        Me.GroupBox4.Controls.Add(Me.TextNumChange)
        Me.GroupBox4.Controls.Add(Me.LabSetName)
        Me.GroupBox4.Controls.Add(Me.LabSetPass)
        Me.GroupBox4.Controls.Add(Me.LabSetNum)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 191)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(315, 163)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "更改用户信息："
        '
        'TexSetName
        '
        Me.TexSetName.Location = New System.Drawing.Point(105, 36)
        Me.TexSetName.Name = "TexSetName"
        Me.TexSetName.Size = New System.Drawing.Size(119, 30)
        Me.TexSetName.TabIndex = 35
        '
        'TextPassChange
        '
        Me.TextPassChange.Location = New System.Drawing.Point(105, 121)
        Me.TextPassChange.Name = "TextPassChange"
        Me.TextPassChange.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPassChange.Size = New System.Drawing.Size(121, 30)
        Me.TextPassChange.TabIndex = 34
        Me.TextPassChange.Text = "123456"
        Me.TextPassChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextNumChange
        '
        Me.TextNumChange.Location = New System.Drawing.Point(105, 78)
        Me.TextNumChange.Name = "TextNumChange"
        Me.TextNumChange.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextNumChange.Size = New System.Drawing.Size(121, 30)
        Me.TextNumChange.TabIndex = 33
        Me.TextNumChange.Text = "123456"
        Me.TextNumChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabSetName
        '
        Me.LabSetName.AutoSize = True
        Me.LabSetName.Location = New System.Drawing.Point(6, 38)
        Me.LabSetName.Name = "LabSetName"
        Me.LabSetName.Size = New System.Drawing.Size(93, 20)
        Me.LabSetName.TabIndex = 21
        Me.LabSetName.Text = "用户名："
        '
        'LabSetPass
        '
        Me.LabSetPass.AutoSize = True
        Me.LabSetPass.Location = New System.Drawing.Point(6, 124)
        Me.LabSetPass.Name = "LabSetPass"
        Me.LabSetPass.Size = New System.Drawing.Size(72, 20)
        Me.LabSetPass.TabIndex = 25
        Me.LabSetPass.Text = "密码："
        '
        'LabSetNum
        '
        Me.LabSetNum.AutoSize = True
        Me.LabSetNum.Location = New System.Drawing.Point(6, 81)
        Me.LabSetNum.Name = "LabSetNum"
        Me.LabSetNum.Size = New System.Drawing.Size(72, 20)
        Me.LabSetNum.TabIndex = 23
        Me.LabSetNum.Text = "工号："
        '
        'ButExitChange
        '
        Me.ButExitChange.Location = New System.Drawing.Point(286, 377)
        Me.ButExitChange.Name = "ButExitChange"
        Me.ButExitChange.Size = New System.Drawing.Size(63, 63)
        Me.ButExitChange.TabIndex = 28
        Me.ButExitChange.Text = "退出更改"
        Me.ButExitChange.UseVisualStyleBackColor = True
        '
        'ButDeleChange
        '
        Me.ButDeleChange.Location = New System.Drawing.Point(189, 377)
        Me.ButDeleChange.Name = "ButDeleChange"
        Me.ButDeleChange.Size = New System.Drawing.Size(63, 63)
        Me.ButDeleChange.TabIndex = 27
        Me.ButDeleChange.Text = "删除账号"
        Me.ButDeleChange.UseVisualStyleBackColor = True
        '
        'ButMakeChanges
        '
        Me.ButMakeChanges.Location = New System.Drawing.Point(11, 377)
        Me.ButMakeChanges.Name = "ButMakeChanges"
        Me.ButMakeChanges.Size = New System.Drawing.Size(63, 63)
        Me.ButMakeChanges.TabIndex = 26
        Me.ButMakeChanges.Text = "确定更改"
        Me.ButMakeChanges.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(964, 522)
        Me.TabControl1.TabIndex = 24
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.DarkGray
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(956, 496)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "登陆界面"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(976, 534)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "登录界面"
        Me.GroMesLink.ResumeLayout(False)
        Me.GroMesLink.PerformLayout()
        Me.GroMesNew.ResumeLayout(False)
        Me.GroMesNew.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabMes As System.Windows.Forms.Label
    Friend WithEvents ComName As System.Windows.Forms.ComboBox
    Friend WithEvents LabName As System.Windows.Forms.Label
    Friend WithEvents LabNum As System.Windows.Forms.Label
    Friend WithEvents LabPassword As System.Windows.Forms.Label
    Friend WithEvents RadGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents RadEngineel As System.Windows.Forms.RadioButton
    Friend WithEvents RadAdminis As System.Windows.Forms.RadioButton
    Friend WithEvents ButLink As System.Windows.Forms.Button
    Friend WithEvents ButChange As System.Windows.Forms.Button
    Friend WithEvents ButExit As System.Windows.Forms.Button
    Friend WithEvents LabMesNew As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents GroMesLink As System.Windows.Forms.GroupBox
    Friend WithEvents GroMesNew As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ButExitChange As System.Windows.Forms.Button
    Friend WithEvents ButDeleChange As System.Windows.Forms.Button
    Friend WithEvents ButMakeChanges As System.Windows.Forms.Button
    Friend WithEvents LabSetPass As System.Windows.Forms.Label
    Friend WithEvents LabSetNum As System.Windows.Forms.Label
    Friend WithEvents LabSetName As System.Windows.Forms.Label
    Friend WithEvents TexPassword As System.Windows.Forms.TextBox
    Friend WithEvents TexNum As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextUsePass As System.Windows.Forms.TextBox
    Friend WithEvents TextUseNum As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComUseName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TextPassChange As System.Windows.Forms.TextBox
    Friend WithEvents TextNumChange As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TexSetName As System.Windows.Forms.TextBox
    Friend WithEvents ButRegister As System.Windows.Forms.Button

End Class
