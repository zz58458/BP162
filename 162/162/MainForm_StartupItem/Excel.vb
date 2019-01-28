Imports Microsoft.office.interop
Imports System

Public Class ExcelFile

    Public m_OLEDBConnectDB As OLEDBConnectDB
    '用于保存表的变量
    Public NormalTable, EngTable, AdminTable As DataTable
    ''' <summary>
    ''' ExcelFile类的构造函数
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub
    ''' <summary>
    ''' 用于读取Excel文件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LinkExcelFile()
        Dim appXL As Excel.Application
        Dim bookXL As Excel.Workbook
        Dim sheetXL As Excel.Worksheet
        Dim raXL As Excel.Range
        appXL = CreateObject("Excel.Application")
        'bookXL = appXL.Workbooks.Add'创建Excel文件
        bookXL = appXL.Workbooks.Open("C:\Users\25683\Desktop\德速达\5000\5000\bin\Debug\Config\用户信息.xlsx") '打开已经存在的Excel文件
        sheetXL = bookXL.Worksheets(1) '设置活动工作表
        sheetXL.Cells(1, 1).Value = "用户名" '给单元格（row行，col列）添加值
        sheetXL.Cells(1, 2).Value = "工号"
        sheetXL.Cells(1, 3).Value = "密码"
        '格式A1：D1为粗体，垂直对齐=中心。
        With sheetXL.Range("A1", "C1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        bookXL.Save() '保存Excel文件
        'appXL.Visible = True 'Excel的可见性
        bookXL.Close() '关闭Excel文件
        raXL = Nothing
        sheetXL = Nothing
        bookXL = Nothing
        appXL.Quit()
        appXL = Nothing
        GC.Collect() '由于 .net 的特殊性,上方的关闭无法将Excel进程结束,需要调用以下函数进行关闭.调用回收程序内存垃圾，结束Excel进程
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
    End Sub
    ''' <summary>
    ''' 打开access文件的函数（OLEDBConnectDB对象打开文件，Get_UserTable函数得到表）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LinkAccessFile()
        Dim connstr As String
        connstr = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Application.StartupPath & "./Config/MyDB.mdb"
        m_OLEDBConnectDB = New OLEDBConnectDB(connstr) '
        Get_UserTable() '得到DataTable表
    End Sub
    ''' <summary>
    ''' 分别获取access文件中的表
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Get_UserTable()
        Dim i As Integer
        For i = 0 To m_OLEDBConnectDB.TableName.Count - 1
            Dim mysql As String = "select * from " + m_OLEDBConnectDB.TableName(i)
            Select Case i
                Case 0
                    AdminTable = m_OLEDBConnectDB.ReadMyDataTable(mysql)
                Case 1
                    EngTable = m_OLEDBConnectDB.ReadMyDataTable(mysql)
                Case 2
                    NormalTable = m_OLEDBConnectDB.ReadMyDataTable(mysql)
            End Select
        Next
    End Sub

End Class
