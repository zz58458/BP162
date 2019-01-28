Public Class IOInputBox
    Public ObjectNameStr As String
    Public HightlevelIOStr As String
    Public LowlevelIOStr As String
    Private Sub OKPutIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKPutIO.Click
        If ObjectName.Text = Nothing Or ObjectAstate.Text = Nothing Or ObjectBstate.Text = Nothing Then
            MsgBox(M请检查是否给控件赋值正确)
            Exit Sub
        End If
        ObjectNameStr = ObjectName.Text
        HightlevelIOStr = ObjectAstate.Text
        LowlevelIOStr = ObjectBstate.Text
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub CanselObjct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CanselObjct.Click
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub IOInputBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If My.Settings.Language = "en-US" Then
        '    My.Settings.Language = "zh-CHS"
        'ElseIf My.Settings.Language = "zh-CHS" Then
        '    My.Settings.Language = "en-US"
        'End If
        My.Settings.Language = Language
        'ReLoadForm()
    End Sub

    'Private Sub ReLoadForm()
    '    Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(My.Settings.Language)
    '    ' Dim s As String = My.Resources.停止
    '    Me.Label3.Text = My.Resources.添加项目名称
    '    Me.Label1.Text = My.Resources.添加项目状态A
    '    Me.Label2.Text = My.Resources.添加项目状态B
    '    Me.OKPutIO.Text = My.Resources.添加项目
    '    Me.CanselObjct.Text = My.Resources.取消
    'End Sub
End Class