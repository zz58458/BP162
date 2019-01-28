<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpeedEdit
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
        Me.AddMaxSpeed = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.AddObjectStSpeed = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.AddORGSpeed = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.AddSpedT = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SubSpedT = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.AddSpedP = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.RunTimeOut = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.SubSpeedP = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.OKSpedBut = New System.Windows.Forms.Button
        Me.CanselSpedBut = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.AddObjectName = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.ReduceDior = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'AddMaxSpeed
        '
        Me.AddMaxSpeed.Location = New System.Drawing.Point(106, 90)
        Me.AddMaxSpeed.Name = "AddMaxSpeed"
        Me.AddMaxSpeed.Size = New System.Drawing.Size(120, 21)
        Me.AddMaxSpeed.TabIndex = 3
        Me.AddMaxSpeed.Text = "1000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "最大速度："
        '
        'AddObjectStSpeed
        '
        Me.AddObjectStSpeed.Location = New System.Drawing.Point(106, 56)
        Me.AddObjectStSpeed.Name = "AddObjectStSpeed"
        Me.AddObjectStSpeed.Size = New System.Drawing.Size(120, 21)
        Me.AddObjectStSpeed.TabIndex = 5
        Me.AddObjectStSpeed.Text = "50"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "启动速度："
        '
        'AddORGSpeed
        '
        Me.AddORGSpeed.Location = New System.Drawing.Point(106, 124)
        Me.AddORGSpeed.Name = "AddORGSpeed"
        Me.AddORGSpeed.Size = New System.Drawing.Size(120, 21)
        Me.AddORGSpeed.TabIndex = 7
        Me.AddORGSpeed.Text = "200"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "复位速度："
        '
        'AddSpedT
        '
        Me.AddSpedT.Location = New System.Drawing.Point(106, 158)
        Me.AddSpedT.Name = "AddSpedT"
        Me.AddSpedT.Size = New System.Drawing.Size(120, 21)
        Me.AddSpedT.TabIndex = 9
        Me.AddSpedT.Text = "0.2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "加速时间："
        '
        'SubSpedT
        '
        Me.SubSpedT.Location = New System.Drawing.Point(106, 192)
        Me.SubSpedT.Name = "SubSpedT"
        Me.SubSpedT.Size = New System.Drawing.Size(120, 21)
        Me.SubSpedT.TabIndex = 11
        Me.SubSpedT.Text = "0.2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "减速时间："
        '
        'AddSpedP
        '
        Me.AddSpedP.Location = New System.Drawing.Point(106, 226)
        Me.AddSpedP.Name = "AddSpedP"
        Me.AddSpedP.Size = New System.Drawing.Size(120, 21)
        Me.AddSpedP.TabIndex = 13
        Me.AddSpedP.Text = "200"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "加速脉冲："
        '
        'RunTimeOut
        '
        Me.RunTimeOut.Location = New System.Drawing.Point(106, 294)
        Me.RunTimeOut.Name = "RunTimeOut"
        Me.RunTimeOut.Size = New System.Drawing.Size(120, 21)
        Me.RunTimeOut.TabIndex = 15
        Me.RunTimeOut.Text = "10"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(35, 302)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "运动超时："
        '
        'SubSpeedP
        '
        Me.SubSpeedP.Location = New System.Drawing.Point(106, 260)
        Me.SubSpeedP.Name = "SubSpeedP"
        Me.SubSpeedP.Size = New System.Drawing.Size(120, 21)
        Me.SubSpeedP.TabIndex = 17
        Me.SubSpeedP.Text = "200"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(35, 267)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "减速脉冲："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(232, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "mm/s"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(232, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 12)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "mm/s"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(232, 127)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 12)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "mm/s"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(232, 162)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 12)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "S"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(232, 195)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 12)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "S"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(232, 229)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 12)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "脉冲"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(232, 265)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 12)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "脉冲"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(232, 299)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 12)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "S"
        '
        'OKSpedBut
        '
        Me.OKSpedBut.Location = New System.Drawing.Point(37, 370)
        Me.OKSpedBut.Name = "OKSpedBut"
        Me.OKSpedBut.Size = New System.Drawing.Size(75, 32)
        Me.OKSpedBut.TabIndex = 19
        Me.OKSpedBut.Text = "确定"
        Me.OKSpedBut.UseVisualStyleBackColor = True
        '
        'CanselSpedBut
        '
        Me.CanselSpedBut.Location = New System.Drawing.Point(174, 370)
        Me.CanselSpedBut.Name = "CanselSpedBut"
        Me.CanselSpedBut.Size = New System.Drawing.Size(75, 32)
        Me.CanselSpedBut.TabIndex = 20
        Me.CanselSpedBut.Text = "取消"
        Me.CanselSpedBut.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "速度名称："
        '
        'AddObjectName
        '
        Me.AddObjectName.Location = New System.Drawing.Point(106, 20)
        Me.AddObjectName.Name = "AddObjectName"
        Me.AddObjectName.Size = New System.Drawing.Size(120, 21)
        Me.AddObjectName.TabIndex = 22
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(232, 336)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(0, 12)
        Me.Label18.TabIndex = 25
        '
        'ReduceDior
        '
        Me.ReduceDior.Location = New System.Drawing.Point(106, 331)
        Me.ReduceDior.Name = "ReduceDior"
        Me.ReduceDior.Size = New System.Drawing.Size(120, 21)
        Me.ReduceDior.TabIndex = 24
        Me.ReduceDior.Text = "0.3"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(47, 336)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 12)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "减速比："
        '
        'SpeedEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 448)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ReduceDior)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.AddObjectName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CanselSpedBut)
        Me.Controls.Add(Me.OKSpedBut)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.SubSpeedP)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.RunTimeOut)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.AddSpedP)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SubSpedT)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.AddSpedT)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.AddORGSpeed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.AddObjectStSpeed)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.AddMaxSpeed)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SpeedEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SpeedEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AddMaxSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AddObjectStSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AddORGSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AddSpedT As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SubSpedT As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents AddSpedP As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RunTimeOut As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SubSpeedP As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents OKSpedBut As System.Windows.Forms.Button
    Friend WithEvents CanselSpedBut As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AddObjectName As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ReduceDior As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
