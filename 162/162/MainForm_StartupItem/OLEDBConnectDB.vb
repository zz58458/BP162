Imports System.Data.OleDb

Public Class OLEDBConnectDB
    '连接文件对象
    Public Conn As OleDbConnection
    Public adapter As OleDbDataAdapter
    '用于统计或者保存DataTable表数量或者对象
    Public TableName As List(Of String) = New List(Of String)()
    ''' <summary>
    ''' OLEDBConnectDB类的构造函数
    ''' </summary>
    ''' <param name="connstr"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal connstr As String)
        DBOpen(connstr)
    End Sub
    ''' <summary>
    ''' 用于打开access文件
    ''' </summary>
    ''' <param name="connstr"></param>
    ''' <remarks></remarks>
    Private Sub DBOpen(ByVal connstr As String)
        Dim row As DataRow
        If Conn Is Nothing Then
            Conn = New OleDbConnection()
            Conn.ConnectionString = connstr '设置文件的路径
        End If
        If Conn.State <> ConnectionState.Open Then
            Conn.Open() '打开access文件
        End If
        Dim dataTable As DataTable = Conn.GetSchema("Tables")
        '这是VB.net里代码,row(3).ToString() = "TABLE"　
        '意思是第4列里每行的值是table的话, 既用户建立的表, 不是系统表, 
        '那么第3列:  row(2).ToString(对应的值就是表名, 放到list中) : List.Add(row(2).ToString())
        For Each row In dataTable.Rows
            If row(3).ToString() = "TABLE" Then
                TableName.Add(row(2).ToString())
            End If
        Next
    End Sub
    ''' <summary>
    ''' 用于返回access文件的DataTable表
    ''' </summary>
    ''' <param name="mysql">SQL的命令（这里是选择表所有数据的命令）</param>
    ''' <returns>返回DataTable表</returns>
    ''' <remarks></remarks>
    Public Function ReadMyDataTable(ByVal mysql As String) As DataTable
        Dim i As Integer
        Dim datatable As DataTable = New DataTable
        adapter = New OleDbDataAdapter(mysql, Conn) '使用命令连接数据库
        adapter.Fill(datatable) '匹配表
        Dim tabname(datatable.Rows.Count - 1) As String
        For i = 0 To datatable.Rows.Count - 1
            tabname(i) = datatable.Rows(i).Item("Name") '获取表中的"Name"列中的某行的值
        Next
        'Conn.Close() '关闭数据库
        Return datatable
    End Function

    Public Sub UpdateDatabase(ByVal sql As String)
        Try
            Dim cmd As OleDbCommand = New OleDbCommand(sql, Conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("修改错误！", ex.Message)
        End Try

    End Sub
    Public Sub DeleteModel(ByVal sql As String)
        Try
            Dim cmd As OleDbCommand = New OleDbCommand(sql, Conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("删除失败，请再试一次！", ex.Message)
        End Try
    End Sub
    Public Sub InsertModel(ByVal sql As String)
        Try
            Dim cmd As OleDbCommand = New OleDbCommand(sql, Conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("插入失败，请再试一次！", ex.Message)
        End Try
    End Sub
    Public Function CheckModel(ByVal sql As String) As Boolean
        Try
            Dim cmd As OleDbCommand = New OleDbCommand(sql, Conn)
            cmd.ExecuteNonQuery()
            Dim RS As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(cmd)
            Dim DT As DataTable = New DataTable()
            RS.Fill(DT)
            If DT.Rows.Count = 0 Then
                Return False
            Else
                MessageBox.Show("已经注册过，请重新注册！")
            End If
        Catch ex As Exception
            MessageBox.Show("查找失败，请再试一次！", ex.Message)
            Return False
        End Try
        Return True
    End Function
End Class
