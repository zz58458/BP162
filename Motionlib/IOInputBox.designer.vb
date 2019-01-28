<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IOInputBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IOInputBox))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ObjectBstate = New System.Windows.Forms.TextBox()
        Me.ObjectAstate = New System.Windows.Forms.TextBox()
        Me.CanselObjct = New System.Windows.Forms.Button()
        Me.OKPutIO = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ObjectName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label1.Name = "Label1"
        '
        'ObjectBstate
        '
        resources.ApplyResources(Me.ObjectBstate, "ObjectBstate")
        Me.ObjectBstate.Name = "ObjectBstate"
        '
        'ObjectAstate
        '
        resources.ApplyResources(Me.ObjectAstate, "ObjectAstate")
        Me.ObjectAstate.Name = "ObjectAstate"
        '
        'CanselObjct
        '
        resources.ApplyResources(Me.CanselObjct, "CanselObjct")
        Me.CanselObjct.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.CanselObjct.Name = "CanselObjct"
        Me.CanselObjct.UseVisualStyleBackColor = True
        '
        'OKPutIO
        '
        resources.ApplyResources(Me.OKPutIO, "OKPutIO")
        Me.OKPutIO.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.OKPutIO.Name = "OKPutIO"
        Me.OKPutIO.UseVisualStyleBackColor = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label3.Name = "Label3"
        '
        'ObjectName
        '
        resources.ApplyResources(Me.ObjectName, "ObjectName")
        Me.ObjectName.Name = "ObjectName"
        '
        'IOInputBox
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ObjectBstate)
        Me.Controls.Add(Me.ObjectAstate)
        Me.Controls.Add(Me.CanselObjct)
        Me.Controls.Add(Me.OKPutIO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ObjectName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IOInputBox"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ObjectBstate As System.Windows.Forms.TextBox
    Friend WithEvents ObjectAstate As System.Windows.Forms.TextBox
    Friend WithEvents CanselObjct As System.Windows.Forms.Button
    Friend WithEvents OKPutIO As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ObjectName As System.Windows.Forms.TextBox
End Class
