﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OutIOButton
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写 Dispose，以清理组件列表。
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OutIOButton))
        Me.But_SYSOutIO = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.But_OutPic = New System.Windows.Forms.PictureBox
        CType(Me.But_OutPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'But_SYSOutIO
        '
        Me.But_SYSOutIO.Location = New System.Drawing.Point(3, 3)
        Me.But_SYSOutIO.Name = "But_SYSOutIO"
        Me.But_SYSOutIO.Size = New System.Drawing.Size(249, 39)
        Me.But_SYSOutIO.TabIndex = 0
        Me.But_SYSOutIO.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(132, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "停止按钮灯"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Y0000"
        '
        'But_OutPic
        '
        Me.But_OutPic.Image = CType(resources.GetObject("But_OutPic.Image"), System.Drawing.Image)
        Me.But_OutPic.Location = New System.Drawing.Point(36, 12)
        Me.But_OutPic.Name = "But_OutPic"
        Me.But_OutPic.Size = New System.Drawing.Size(19, 26)
        Me.But_OutPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.But_OutPic.TabIndex = 3
        Me.But_OutPic.TabStop = False
        '
        'OutIOButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.But_OutPic)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.But_SYSOutIO)
        Me.Name = "OutIOButton"
        Me.Size = New System.Drawing.Size(255, 46)
        CType(Me.But_OutPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents But_SYSOutIO As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents But_OutPic As System.Windows.Forms.PictureBox

End Class
