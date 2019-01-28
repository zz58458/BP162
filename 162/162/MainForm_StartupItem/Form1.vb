Imports System.Threading

Public Class Form1
    '定义操作access数据库类的对象
    Private AccessFile As ExcelFile = New ExcelFile()
    Public frm3 As Features_Config = New Features_Config()
    Public frm1 As Form1
    Public fm As New FMain
    Public ModelCon As ModelConfig = New ModelConfig()
    ''' <summary>
    ''' 窗体初始化事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        frm1 = Me
        
        '设置窗口大小
        Dim pt As Point = New Point(540, 520)
        Me.Size = New System.Drawing.Size(pt)
        '创建Excel文件并写入
        'excel.LinkExcelFile()
        AccessFile.LinkAccessFile()
        RadGeneral.Checked = True

    End Sub
    ''' <summary>
    ''' 更改密码控件事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButChange_Click(sender As System.Object, e As System.EventArgs) Handles ButChange.Click
        Dim pt As Point = New Point(951, 520)
        Me.Size = New System.Drawing.Size(pt)

    End Sub
    ''' <summary>
    ''' 退出账号变更控件事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButExitChange_Click(sender As System.Object, e As System.EventArgs) Handles ButExitChange.Click
        TextNumChange.Text = ""
        TextPassChange.Text = ""
        ComUseName.Text = ""
        TextUseNum.Text = ""
        TextUsePass.Text = ""
        Dim pt As Point = New Point(540, 520)
        Me.Size = New System.Drawing.Size(pt)
    End Sub
    ''' <summary>
    ''' 退出界面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButExit_Click(sender As System.Object, e As System.EventArgs) Handles ButExit.Click
        AccessFile.m_OLEDBConnectDB.Conn.Close()
        Me.Close()
    End Sub
    ''' <summary>
    ''' 登陆系统控件函数
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButLink_Click(sender As System.Object, e As System.EventArgs) Handles ButLink.Click
        If (ComName.Text = "" And TexNum.Text = "" And TexPassword.Text = "") Then
            MessageBox.Show("用户信息不能空，请确定！")
            Return
        End If
        If (RadGeneral.Checked) Then
            For i As Integer = 0 To AccessFile.NormalTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.NormalTable.Rows(i).ItemArray
                If (ComName.Text = ItemArray(1).ToString() And TexNum.Text = ItemArray(2).ToString() And
                    TexPassword.Text = ItemArray(3).ToString()) Then
                    formSetPara()
                    fm.Show()
                    ButLink.Enabled = False
                    ButExit.Enabled = False
                    frm1.Hide()
                    TexPassword.Text = ""
                    Return
                End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TexPassword.Text = ""
            Return
        ElseIf (RadEngineel.Checked) Then
            For i As Integer = 0 To AccessFile.EngTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.EngTable.Rows(i).ItemArray
                If (ComName.Text = ItemArray(1).ToString() And TexNum.Text = ItemArray(2).ToString() And
                    TexPassword.Text = ItemArray(3).ToString()) Then
                    formSetPara()
                    fm.Show()
                    ButLink.Enabled = False
                    ButExit.Enabled = False
                    frm1.Hide()
                    TexPassword.Text = ""
                    Return
                End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TexPassword.Text = ""
            Return
        ElseIf (RadAdminis.Checked) Then
            For i As Integer = 0 To AccessFile.AdminTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.AdminTable.Rows(i).ItemArray
                If (ComName.Text = ItemArray(1).ToString() And TexNum.Text = ItemArray(2).ToString() And
                    TexPassword.Text = ItemArray(3).ToString()) Then
                    formSetPara()
                    fm.Show()
                    ButLink.Enabled = False
                    ButExit.Enabled = False
                    frm1.Hide()
                    TexPassword.Text = ""
                    Return
                End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TexPassword.Text = ""
            Return
        End If

        'frm1.Enabled = False
    End Sub
    ''' <summary>
    ''' 打开新的窗口，并将用户登陆信息写入到.txt文件中
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub formSetPara()
        ' Dim frm2 As SoftWareVersion = New SoftWareVersion()
        Dim dat As String = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.ToString("HH:mm:ss")
        Dim strMessage As String = "员工名字:" + ComName.Text + " 工号:" + TexNum.Text
        Dim textMessage As String = dat + " " + strMessage + vbCrLf
        Dim filePath As String = "Config/员工登陆记录/" + "登陆记录" + ".txt"
        System.IO.File.AppendAllText(filePath, textMessage)
        'frm2.Show()
    End Sub
    Private Sub Features_Config_Show()

        frm3.Show()
    End Sub
    ''' <summary>
    ''' 普通用户信息显示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RadGeneral_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadGeneral.CheckedChanged
        Dim i As Integer
        ComName.Items.Clear()
        ComUseName.Items.Clear()
        For i = 0 To AccessFile.NormalTable.Rows.Count - 1
            Dim ItemArray() As Object = AccessFile.NormalTable.Rows(i).ItemArray
            ComName.Items.Add(ItemArray(1).ToString())
            ComUseName.Items.Add(ItemArray(1).ToString())
            ComName.Text = ItemArray(1).ToString()
            TexNum.Text = ItemArray(2).ToString()
            ComUseName.Text = ItemArray(1).ToString()
            TextUseNum.Text = ItemArray(2).ToString()
        Next
    End Sub
    ''' <summary>
    ''' 工程师信息显示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RadEngineel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadEngineel.CheckedChanged
        Dim i As Integer
        ComName.Items.Clear()
        ComUseName.Items.Clear()
        For i = 0 To AccessFile.EngTable.Rows.Count - 1
            Dim ItemArray() As Object = AccessFile.EngTable.Rows(i).ItemArray
            ComName.Items.Add(ItemArray(1).ToString())
            ComUseName.Items.Add(ItemArray(1).ToString())
            ComName.Text = ItemArray(1).ToString()
            TexNum.Text = ItemArray(2).ToString()
            ComUseName.Text = ItemArray(1).ToString()
            TextUseNum.Text = ItemArray(2).ToString()
        Next
    End Sub
    ''' <summary>
    ''' 管理者的信息显示到上位机
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RadAdminis_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadAdminis.CheckedChanged
        Dim i As Integer
        ComName.Items.Clear()
        ComUseName.Items.Clear()
        For i = 0 To AccessFile.AdminTable.Rows.Count - 1
            Dim ItemArray() As Object = AccessFile.AdminTable.Rows(i).ItemArray
            ComName.Items.Add(ItemArray(1).ToString())
            ComUseName.Items.Add(ItemArray(1).ToString())
            ComName.Text = ItemArray(1).ToString()
            TexNum.Text = ItemArray(2).ToString()
            ComUseName.Text = ItemArray(1).ToString()
            TextUseNum.Text = ItemArray(2).ToString()
        Next
    End Sub
    ''' <summary>
    ''' 客户信息修改功能
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButMakeChanges_Click(sender As System.Object, e As System.EventArgs) Handles ButMakeChanges.Click
        If (ComUseName.Text = "" And TextUseNum.Text = "" And TextUsePass.Text = "" And
            TexSetName.Text = "" And TextNumChange.Text = "" And TextPassChange.Text = "") Then
            MessageBox.Show("信息不能为空，请确定！")
            Return
        End If
        If (RadGeneral.Checked) Then
            For i As Integer = 0 To AccessFile.NormalTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.NormalTable.Rows(i).ItemArray
                If (ComUseName.Text = ItemArray(1).ToString() And TextUseNum.Text = ItemArray(2).ToString() And
                    TextUsePass.Text = ItemArray(3).ToString()) Then

                    Dim mysql As System.Text.StringBuilder = New System.Text.StringBuilder()
                    mysql.Append("Update 普通用户 Set [Name]='").Append(TexSetName.Text).Append("',").Append(" [Number]='").Append(TextNumChange.Text).Append("',").
                        Append(" [PassWord]='").Append(TextPassChange.Text).Append("'").Append(" where [Name]='").Append(ComUseName.Text).Append("' and").
                         Append(" [Number]='").Append(TextUseNum.Text).Append("' and").Append(" [PassWord]='").Append(TextUsePass.Text).Append("'")

                    AccessFile.m_OLEDBConnectDB.UpdateDatabase(mysql.ToString) '更新客户信息
                    AccessFile.Get_UserTable() '
                    RadGeneral_CheckedChanged(Nothing, Nothing) '更新控件的数据.
                    TextNumChange.Text = ""
                    TextPassChange.Text = ""
                    ComUseName.Text = ""
                    TextUseNum.Text = ""
                    TextUsePass.Text = ""
                    Return
                End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TexNum.Text = ""
            TexPassword.Text = ""
            Return
        ElseIf (RadEngineel.Checked) Then
            For i As Integer = 0 To AccessFile.EngTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.EngTable.Rows(i).ItemArray
                If (ComUseName.Text = ItemArray(1).ToString() And TextUseNum.Text = ItemArray(2).ToString() And
                    TextUsePass.Text = ItemArray(3).ToString()) Then
                    'Dim mysql As String = String.Format("Update 工程师 Set Name='{0}',Number='{1}',PassWord='{2}' where Name='{3}'and Number='{4}'and PassWord='{5}'",
                    '                                    TexSetName.Text, TextNumChange.Text, TextPassChange.Text, ComUseName.Text, TextUseNum.Text, TextUsePass.Text)
                    Dim mysql As System.Text.StringBuilder = New System.Text.StringBuilder()
                    mysql.Append("Update 工程师 Set [Name]='").Append(TexSetName.Text).Append("',").Append(" [Number]='").Append(TextNumChange.Text).Append("',").
                        Append(" [PassWord]='").Append(TextPassChange.Text).Append("'").Append(" where [Name]='").Append(ComUseName.Text).Append("' and").
                         Append(" [Number]='").Append(TextUseNum.Text).Append("' and").Append(" [PassWord]='").Append(TextUsePass.Text).Append("'")
                    AccessFile.m_OLEDBConnectDB.UpdateDatabase(mysql.ToString) '更新客户信息
                    AccessFile.Get_UserTable() '
                    RadEngineel_CheckedChanged(Nothing, Nothing) '更新控件的数据.
                    TextNumChange.Text = ""
                    TextPassChange.Text = ""
                    ComUseName.Text = ""
                    TextUseNum.Text = ""
                    TextUsePass.Text = ""
                    Return
                End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TexNum.Text = ""
            TexPassword.Text = ""
            Return
        ElseIf (RadAdminis.Checked) Then
            For i As Integer = 0 To AccessFile.AdminTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.AdminTable.Rows(i).ItemArray
                If (ComUseName.Text = ItemArray(1).ToString() And TextUseNum.Text = ItemArray(2).ToString() And
                    TextUsePass.Text = ItemArray(3).ToString()) Then
                    Dim mysql As System.Text.StringBuilder = New System.Text.StringBuilder()
                    mysql.Append("Update 管理员 Set [Name]='").Append(TexSetName.Text).Append("',").Append(" [Number]='").Append(TextNumChange.Text).Append("',").
                        Append(" [PassWord]='").Append(TextPassChange.Text).Append("'").Append(" where [Name]='").Append(ComUseName.Text).Append("' and").
                         Append(" [Number]='").Append(TextUseNum.Text).Append("' and").Append(" [PassWord]='").Append(TextUsePass.Text).Append("'")
                    AccessFile.m_OLEDBConnectDB.UpdateDatabase(mysql.ToString) '更新客户信息
                    AccessFile.Get_UserTable() '
                    RadAdminis_CheckedChanged(Nothing, Nothing) '更新控件的数据.
                    TextNumChange.Text = ""
                    TextPassChange.Text = ""
                    ComUseName.Text = ""
                    TextUseNum.Text = ""
                    TextUsePass.Text = ""
                    Return
                End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TextNumChange.Text = ""
            TextPassChange.Text = ""
            ComUseName.Text = ""
            TextUseNum.Text = ""
            TextUsePass.Text = ""
            Return
        End If
    End Sub
    ''' <summary>
    ''' 客户信息删除功能
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButDeleChange_Click(sender As System.Object, e As System.EventArgs) Handles ButDeleChange.Click
        If (ComUseName.Text = "" And TextUseNum.Text = "" And TextUsePass.Text = "") Then
            MessageBox.Show("信息不能为空，请确定！")
            'TextNumChange.Text = ""
            'TextPassChange.Text = ""
            'ComUseName.Text = ""
            'TextUseNum.Text = ""
            'TextUsePass.Text = ""
            Return
        End If
        If (RadGeneral.Checked) Then
            For i As Integer = 0 To AccessFile.NormalTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.NormalTable.Rows(i).ItemArray
                If (ComUseName.Text = ItemArray(1).ToString() And TextUseNum.Text = ItemArray(2).ToString() And
                    TextUsePass.Text = ItemArray(3).ToString()) Then
                    Dim mysql As System.Text.StringBuilder = New System.Text.StringBuilder()
                    mysql.Append("Delete from 普通用户 where [Name]='").Append(ComUseName.Text).Append("' and").
                          Append(" [Number]='").Append(TextUseNum.Text).Append("' and").Append(" [PassWord]='").Append(TextUsePass.Text).Append("'")
                    AccessFile.m_OLEDBConnectDB.DeleteModel(mysql.ToString) '删除客户信息
                    AccessFile.Get_UserTable() '
                    RadGeneral_CheckedChanged(Nothing, Nothing) '更新控件的数据.
                    TextNumChange.Text = ""
                    TextPassChange.Text = ""
                    ComUseName.Text = ""
                    TextUseNum.Text = ""
                    TextUsePass.Text = ""
                    Return
                End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TexNum.Text = ""
            TexPassword.Text = ""
            Return
        ElseIf (RadEngineel.Checked) Then
            For i As Integer = 0 To AccessFile.EngTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.EngTable.Rows(i).ItemArray
                If (ComUseName.Text = ItemArray(1).ToString() And TextUseNum.Text = ItemArray(2).ToString() And
                    TextUsePass.Text = ItemArray(3).ToString()) Then
                    'Dim mysql As String = String.Format("Delete from 普通用户 where Name={0},Number={1},PassWord={2}",
                    '                                     ComUseName.Text, TextUseNum.Text, TextUsePass.Text)
                    Dim mysql As System.Text.StringBuilder = New System.Text.StringBuilder()
                    mysql.Append("Delete from 工程师 where [Name]='").Append(ComUseName.Text).Append("' and").
                          Append(" [Number]='").Append(TextUseNum.Text).Append("' and").Append(" [PassWord]='").Append(TextUsePass.Text).Append("'")

                    AccessFile.m_OLEDBConnectDB.DeleteModel(mysql.ToString) '删除客户信息
                    AccessFile.Get_UserTable() '
                    RadEngineel_CheckedChanged(Nothing, Nothing) '更新控件的数据.
                    TextNumChange.Text = ""
                    TextPassChange.Text = ""
                    ComUseName.Text = ""
                    TextUseNum.Text = ""
                    TextUsePass.Text = ""
                    Return
                End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TexNum.Text = ""
            TexPassword.Text = ""
            Return
        ElseIf (RadAdminis.Checked) Then
            For i As Integer = 0 To AccessFile.AdminTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.AdminTable.Rows(i).ItemArray
                If (ComUseName.Text = ItemArray(1).ToString() And TextUseNum.Text = ItemArray(2).ToString() And
                    TextUsePass.Text = ItemArray(3).ToString()) Then
                    Dim mysql As System.Text.StringBuilder = New System.Text.StringBuilder()
                    mysql.Append("Delete from 管理员 where [Name]='").Append(ComUseName.Text).Append("' and").
                          Append(" [Number]='").Append(TextUseNum.Text).Append("' and").Append(" [PassWord]='").Append(TextUsePass.Text).Append("'")
                    AccessFile.m_OLEDBConnectDB.DeleteModel(mysql.ToString) '删除客户信息
                    AccessFile.Get_UserTable() '
                    RadAdminis_CheckedChanged(Nothing, Nothing) '更新控件的数据.
                    TextNumChange.Text = ""
                    TextPassChange.Text = ""
                    ComUseName.Text = ""
                    TextUseNum.Text = ""
                    TextUsePass.Text = ""
                    Return
                End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TextNumChange.Text = ""
            TextPassChange.Text = ""
            ComUseName.Text = ""
            TextUseNum.Text = ""
            TextUsePass.Text = ""
            Return
        End If
    End Sub
    ''' <summary>
    ''' 注册新的客户账号，（已注册账号提示错误）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButRegister_Click(sender As System.Object, e As System.EventArgs) Handles ButRegister.Click
        If (TexSetName.Text = "" And TextNumChange.Text = "" And TextPassChange.Text = "") Then
            MessageBox.Show("信息不能为空，请确定！")
            Return
        End If
        If (RadGeneral.Checked) Then
            For i As Integer = 0 To AccessFile.NormalTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.NormalTable.Rows(i).ItemArray
                'If (ComUseName.Text = ItemArray(1).ToString() And TextUseNum.Text = ItemArray(2).ToString() And
                '    TextUsePass.Text = ItemArray(3).ToString()) Then
                Dim mysql As System.Text.StringBuilder = New System.Text.StringBuilder()
                Dim mysql1 As System.Text.StringBuilder = New System.Text.StringBuilder()
                mysql.Append("Select * from 普通用户 where [Name]='").Append(TexSetName.Text).Append("'")
                If AccessFile.m_OLEDBConnectDB.CheckModel(mysql.ToString) Then

                Else
                    mysql1.Append("Insert into 普通用户 ([Name],[Number],[PassWord])").Append(" Values(").Append(TexSetName.Text).Append(",").
                   Append(TextNumChange.Text).Append(",").Append(TextPassChange.Text).Append(")")
                    AccessFile.m_OLEDBConnectDB.InsertModel(mysql1.ToString) '删除客户信息
                End If
                AccessFile.Get_UserTable() '
                RadGeneral_CheckedChanged(Nothing, Nothing) '更新控件的数据.
                TextNumChange.Text = ""
                TextPassChange.Text = ""
                'ComUseName.Text = ""
                'TextUseNum.Text = ""
                'TextUsePass.Text = ""
                Return
                ' End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TexNum.Text = ""
            TexPassword.Text = ""
            Return
        ElseIf (RadEngineel.Checked) Then
            For i As Integer = 0 To AccessFile.EngTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.EngTable.Rows(i).ItemArray
                'If (ComUseName.Text = ItemArray(1).ToString() And TextUseNum.Text = ItemArray(2).ToString() And
                '    TextUsePass.Text = ItemArray(3).ToString()) Then
                'Dim mysql As String = String.Format("Delete from 普通用户 where Name={0},Number={1},PassWord={2}",
                Dim mysql As System.Text.StringBuilder = New System.Text.StringBuilder()
                Dim mysql1 As System.Text.StringBuilder = New System.Text.StringBuilder()
                mysql.Append("Select * from 管理员 where [Name]='").Append(TexSetName.Text).Append("'")
                If AccessFile.m_OLEDBConnectDB.CheckModel(mysql.ToString) Then

                Else
                    mysql1.Append("Insert into 管理员 ([Name],[Number],[PassWord])").Append(" Values(").Append(TexSetName.Text).Append(",").
                   Append(TextNumChange.Text).Append(",").Append(TextPassChange.Text).Append(")")
                    AccessFile.m_OLEDBConnectDB.InsertModel(mysql1.ToString) '删除客户信息
                End If
                AccessFile.Get_UserTable() '
                RadEngineel_CheckedChanged(Nothing, Nothing) '更新控件的数据.
                TextNumChange.Text = ""
                TextPassChange.Text = ""
                'ComUseName.Text = ""
                'TextUseNum.Text = ""
                'TextUsePass.Text = ""
                Return
                ' End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TexNum.Text = ""
            TexPassword.Text = ""
            Return
        ElseIf (RadAdminis.Checked) Then
            For i As Integer = 0 To AccessFile.AdminTable.Rows.Count - 1
                Dim ItemArray() As Object = AccessFile.AdminTable.Rows(i).ItemArray
                'If (ComUseName.Text = ItemArray(1).ToString() And TextUseNum.Text = ItemArray(2).ToString() And
                '    TextUsePass.Text = ItemArray(3).ToString()) Then
                Dim mysql As System.Text.StringBuilder = New System.Text.StringBuilder()
                Dim mysql1 As System.Text.StringBuilder = New System.Text.StringBuilder()
                mysql.Append("Select * from 普通用户 where [Name]='").Append(TexSetName.Text).Append("'")
                If AccessFile.m_OLEDBConnectDB.CheckModel(mysql.ToString) Then

                Else
                    mysql1.Append("Insert into 普通用户 ([Name],[Number],[PassWord])").Append(" Values(").Append(TexSetName.Text).Append(",").
                   Append(TextNumChange.Text).Append(",").Append(TextPassChange.Text).Append(")")
                    AccessFile.m_OLEDBConnectDB.InsertModel(mysql1.ToString) '删除客户信息
                End If
                AccessFile.Get_UserTable() '
                RadAdminis_CheckedChanged(Nothing, Nothing) '更新控件的数据.
                TextNumChange.Text = ""
                TextPassChange.Text = ""
                'ComUseName.Text = ""
                'TextUseNum.Text = ""
                'TextUsePass.Text = ""
                Return
                'End If
            Next
            MessageBox.Show("用户输入错误，请确定!")
            TextNumChange.Text = ""
            TextPassChange.Text = ""
            'ComUseName.Text = ""
            'TextUseNum.Text = ""
            'TextUsePass.Text = ""
            Return
        End If
    End Sub

   
    Private Sub Form1_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Features_Config.features_display()
    End Sub
End Class
