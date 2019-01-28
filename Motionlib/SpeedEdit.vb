Public Class SpeedEdit
    Public AddEditSpedStr As AddEditSped
    Public mAxisName As String

    Public Structure AddEditSped
        Public AddObjectNameStr As String
        Public AddObjectStSpeedStr As String
        Public AddMaxSpeedStr As String
        Public AddORGSpeedStr As String
        Public AddSpedTStr As String
        Public SubSpedTStr As String
        Public AddSpedPStr As String
        Public SubSpeedPStr As String
        Public RunTimeOutStr As String
        Public ReduceRioStr As String
    End Structure

    Private Sub OKSpedBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKSpedBut.Click
        AddEditSpedStr.AddObjectNameStr = mAxisName & AddObjectName.Text
        AddEditSpedStr.AddObjectStSpeedStr = AddObjectStSpeed.Text
        AddEditSpedStr.AddMaxSpeedStr = AddMaxSpeed.Text
        AddEditSpedStr.AddORGSpeedStr = AddORGSpeed.Text
        AddEditSpedStr.AddSpedTStr = AddSpedT.Text
        AddEditSpedStr.SubSpedTStr = SubSpedT.Text
        AddEditSpedStr.AddSpedPStr = AddSpedP.Text
        AddEditSpedStr.SubSpeedPStr = SubSpeedP.Text
        AddEditSpedStr.RunTimeOutStr = RunTimeOut.Text
        AddEditSpedStr.ReduceRioStr = ReduceDior.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub CanselSpedBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CanselSpedBut.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub


    Private Sub SpeedEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If My.Settings.Language = "en-US" Then
        '    My.Settings.Language = "zh-CHS"
        'ElseIf My.Settings.Language = "zh-CHS" Then
        '    My.Settings.Language = "en-US"
        'End If
        My.Settings.Language = Language
        ReLoadForm()
    End Sub
    Private Sub ReLoadForm()
        Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(My.Settings.Language)
        ' Dim s As String = My.Resources.停止
        Me.Label1.Text = My.Resources.速度名称
        Me.Label3.Text = My.Resources.启动速度
        Me.Label2.Text = My.Resources.最大速度
        Me.Label4.Text = My.Resources.复位速度
        Me.Label5.Text = My.Resources.加速时间
        Me.Label6.Text = My.Resources.减速时间
        Me.Label7.Text = My.Resources.加速脉冲
        Me.Label9.Text = My.Resources.减速脉冲
        Me.Label8.Text = My.Resources.运动超时
        Me.Label19.Text = My.Resources.减速比
        Me.Label15.Text = My.Resources.脉冲
        Me.Label16.Text = My.Resources.脉冲
        Me.OKSpedBut.Text = My.Resources.确定
        Me.CanselSpedBut.Text = My.Resources.取消

    End Sub

End Class