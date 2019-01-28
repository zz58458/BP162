Imports DSD.MotionLib

Public Class SpeedEdit2
    Private paramSpd As New absMtAxis._RunParam
    'Private Spdedit2 As New SpeedDealW
    Private pathSpeedFile As String = My.Application.Info.DirectoryPath
    Public Shared SpeedArrry As New ArrayList
    Public Shared AxisName As String
    Public SpeedList As New ArrayList

    Private Sub SpeedEdit2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If My.Settings.Language = "en-US" Then
        '    My.Settings.Language = "zh-CHS"
        'ElseIf My.Settings.Language = "zh-CHS" Then
        '    My.Settings.Language = "en-US"
        'End If
        My.Settings.Language = Language
        ReLoadForm()
        ReadG()
    End Sub
    Public Sub SpeedL()

    End Sub

    Private Sub ReadG() '把数据放入界面中
        For i As Int16 = 0 To SpeedList.Count - 1
            Dim SpedStru As DMCCard.SpeedStrut = SpeedList(i)
            paramSpd = SpedStru.SpeedAORG(0)

            WkComDGv.Rows.Add()
            WkComDGv.Item(0, i).Value = SpedStru.SpeedStuName
            WkComDGv.Item(1, i).Value = CStr(paramSpd.Min_Vel)
            WkComDGv.Item(2, i).Value = CStr(paramSpd.Max_Vel)
            WkComDGv.Item(3, i).Value = CStr(paramSpd.OrgSpeed)
            WkComDGv.Item(4, i).Value = CStr(paramSpd.Tacc)
            WkComDGv.Item(5, i).Value = CStr(paramSpd.Tdec)
            WkComDGv.Item(6, i).Value = CStr(paramSpd.Sacc)
            WkComDGv.Item(7, i).Value = CStr(paramSpd.Sdec)
            WkComDGv.Item(8, i).Value = CStr(paramSpd.RunTime)
            WkComDGv.Item(9, i).Value = CStr(paramSpd.ReduceRatio)
        Next
    End Sub

    Private Sub ChangeSpeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeSpeed.Click
        Dim AddEditName As String
        Dim CountNum As Int16 = WkComDGv.CurrentCell.RowIndex
        If WkComDGv.Item(0, 0).Value = "" Then
            MsgBox("请先选择要添加的轴")
            Exit Sub
        Else
            AddEditName = CStr(WkComDGv.Item(0, 0).Value).Substring(0, CStr(WkComDGv.Item(0, 0).Value).LastIndexOf("-"))
        End If
        Dim frm As New SpeedEdit
        frm.AddObjectName.Text = WkComDGv.Item(0, CountNum).Value
        frm.AddObjectStSpeed.Text = WkComDGv.Item(1, CountNum).Value
        frm.AddMaxSpeed.Text = WkComDGv.Item(2, CountNum).Value
        frm.AddORGSpeed.Text = WkComDGv.Item(3, CountNum).Value
        frm.AddSpedT.Text = WkComDGv.Item(4, CountNum).Value
        frm.SubSpedT.Text = WkComDGv.Item(5, CountNum).Value
        frm.AddSpedP.Text = WkComDGv.Item(6, CountNum).Value
        frm.SubSpeedP.Text = WkComDGv.Item(7, CountNum).Value
        frm.RunTimeOut.Text = WkComDGv.Item(8, CountNum).Value
        frm.ReduceDior.Text = WkComDGv.Item(9, CountNum).Value
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        frm.Dispose()
        WkComDGv.Item(0, CountNum).Value = frm.AddEditSpedStr.AddObjectNameStr
        WkComDGv.Item(1, CountNum).Value = frm.AddEditSpedStr.AddObjectStSpeedStr
        WkComDGv.Item(2, CountNum).Value = frm.AddEditSpedStr.AddMaxSpeedStr
        WkComDGv.Item(3, CountNum).Value = frm.AddEditSpedStr.AddORGSpeedStr
        WkComDGv.Item(4, CountNum).Value = frm.AddEditSpedStr.AddSpedTStr
        WkComDGv.Item(5, CountNum).Value = frm.AddEditSpedStr.SubSpedTStr
        WkComDGv.Item(6, CountNum).Value = frm.AddEditSpedStr.AddSpedPStr
        WkComDGv.Item(7, CountNum).Value = frm.AddEditSpedStr.SubSpeedPStr
        WkComDGv.Item(8, CountNum).Value = frm.AddEditSpedStr.RunTimeOutStr
        WkComDGv.Item(9, CountNum).Value = frm.AddEditSpedStr.ReduceRioStr
    End Sub

    Private Sub AddSpeedNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddSpeedNow.Click
        Dim AddEditName As String
        Try
            If AxisName = "" Then
                MsgBox("请先选择要添加的轴")
                Exit Sub
            Else
                AddEditName = AxisName
            End If
            Dim frm As New SpeedEdit
            '   frm.AddObjectName.Text = AddEditName & "-"
            frm.mAxisName = AddEditName & "-"
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            frm.Dispose()
            WkComDGv.Rows.Add()
            Dim Count As Int16 = WkComDGv.Rows.Count - 2
            WkComDGv.Item(0, Count).Value = frm.AddEditSpedStr.AddObjectNameStr
            WkComDGv.Item(1, Count).Value = frm.AddEditSpedStr.AddObjectStSpeedStr
            WkComDGv.Item(2, Count).Value = frm.AddEditSpedStr.AddMaxSpeedStr
            WkComDGv.Item(3, Count).Value = frm.AddEditSpedStr.AddORGSpeedStr
            WkComDGv.Item(4, Count).Value = frm.AddEditSpedStr.AddSpedTStr
            WkComDGv.Item(5, Count).Value = frm.AddEditSpedStr.SubSpedTStr
            WkComDGv.Item(6, Count).Value = frm.AddEditSpedStr.AddSpedPStr
            WkComDGv.Item(7, Count).Value = frm.AddEditSpedStr.SubSpeedPStr
            WkComDGv.Item(8, Count).Value = frm.AddEditSpedStr.RunTimeOutStr
            WkComDGv.Item(9, Count).Value = frm.AddEditSpedStr.ReduceRioStr

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SubSpeedNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubSpeedNow.Click
        If WkComDGv.Item(0, 0).Value = "" Then
            MsgBox("没有要删除的选项")
            Exit Sub
        End If
        Dim intCueen As Int16 = WkComDGv.CurrentCell.RowIndex
        Dim StrCueen As String = WkComDGv.Item(0, WkComDGv.CurrentCell.RowIndex).Value
        WkComDGv.Rows.RemoveAt(intCueen)
    End Sub





    Private Sub SaveNewSped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveNewSped.Click
        Try
            Dim layname As String

            SpeedArrry.Clear()
            For i As Int16 = 0 To WkComDGv.RowCount - 2
                Dim NewArr As New ArrayList
                Dim SpedStru As DMCCard.SpeedStrut
                layname = CStr(WkComDGv.Item(0, i).Value)
                paramSpd.Min_Vel = CInt(WkComDGv.Item(1, i).Value)
                paramSpd.Max_Vel = CInt(WkComDGv.Item(2, i).Value)
                paramSpd.OrgSpeed = CInt(WkComDGv.Item(3, i).Value)
                paramSpd.Tacc = CSng(WkComDGv.Item(4, i).Value)
                paramSpd.Tdec = CSng(WkComDGv.Item(5, i).Value)
                paramSpd.Sacc = CInt(WkComDGv.Item(6, i).Value)
                paramSpd.Sdec = CInt(WkComDGv.Item(7, i).Value)
                paramSpd.RunTime = CLng(WkComDGv.Item(8, i).Value)
                paramSpd.ReduceRatio = CSng(WkComDGv.Item(9, i).Value)
                SpedStru.SpeedStuName = layname
                SpedStru.SpeedAORG = NewArr
                SpedStru.SpeedAORG.Add(paramSpd)
                SpeedArrry.Add(SpedStru)
            Next

        Catch ex As Exception

        End Try
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ExitNewSpeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitNewSpeed.Click
        ' SpeedArrry.Clear()
        'Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ReLoadForm()
        Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(My.Settings.Language)
        ' Dim s As String = My.Resources.停止

        Me.SpeedEditGB.Text = My.Resources.速度编辑
        Me.WkComDGv.Columns(0).HeaderText = My.Resources.速度类型
        Me.WkComDGv.Columns(1).HeaderText = My.Resources.启动速度
        Me.WkComDGv.Columns(2).HeaderText = My.Resources.最大速度
        Me.WkComDGv.Columns(3).HeaderText = My.Resources.复位速度
        Me.WkComDGv.Columns(4).HeaderText = My.Resources.加速时间
        Me.WkComDGv.Columns(5).HeaderText = My.Resources.减速时间
        Me.WkComDGv.Columns(6).HeaderText = My.Resources.加速脉冲
        Me.WkComDGv.Columns(7).HeaderText = My.Resources.减速脉冲
        Me.WkComDGv.Columns(8).HeaderText = My.Resources.运动超时
        Me.WkComDGv.Columns(9).HeaderText = My.Resources.减速比
        Me.SubSpeedNow.Text = My.Resources.删除选中速度
        Me.AddSpeedNow.Text = My.Resources.添加速度
        Me.ChangeSpeed.Text = My.Resources.改变选中速度
        Me.ExitNewSpeed.Text = My.Resources.退出
        Me.SaveNewSped.Text = My.Resources.保存

    End Sub

End Class