Imports System.IO

Public Class SL_Config
    Public Shared FeedName As List(Of String) = New List(Of String)
    Dim FilePath As String = "F:\自动化软件\德速达\5000_19.1.4\5000\bin\Debug\Config\上料配置.txt"
    Dim Type As String
    Dim NameS As String
    Dim Port As String
    Dim Sum As UInt32
    Dim BarCode As String
    Dim Position As String
    Private Sub DataGridView1_RowStateChanged_1(sender As System.Object, e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs)
        Dim i As Integer

        For i = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).HeaderCell.Value = (i + 1).ToString
            Dim dvs As New DataGridViewCellStyle()
            dvs.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Rows(i).HeaderCell.Style = dvs
        Next
    End Sub

    Private Sub Customize_Config_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DataGridView1.TopLeftHeaderCell.Value = "序号"
        Dim checkBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        Dim textBoxColumn As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        Dim testBoxColumn2 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        checkBoxColumn.Name = "Enable"
        checkBoxColumn.HeaderText = "使能"
        textBoxColumn.Name = "Type"
        textBoxColumn.HeaderText = "类型"
        testBoxColumn2.Name = "Name"
        testBoxColumn2.HeaderText = "名称"
        DataGridView1.Columns.Add(textBoxColumn)
        DataGridView1.Columns.Add(testBoxColumn2)
        DataGridView1.Columns.Add(checkBoxColumn)
        FlieLoad(FilePath)

    End Sub
    Private Sub FlieLoad(ByVal FliePath As String)
        ' DataGridView1 = New DataGridView()
        FeedName.Clear()
        Dim Str As StreamReader = New StreamReader(FliePath, System.Text.Encoding.GetEncoding("gb2312"))
        Dim strLine As String = Str.ReadLine()
        While (String.IsNullOrEmpty(strLine) <> True)
            Dim strlist() As String = strLine.Split(" ")
            Dim i = DataGridView1.Rows.Add()
            DataGridView1.Rows(i).Cells(0).Value = strlist(0)
            DataGridView1.Rows(i).Cells(1).Value = strlist(1)
            FeedName.Add(strlist(1))
            DataGridView1.Rows(i).Cells(2).Value = IIf(strlist(2) = "1", True, False)
            strLine = Str.ReadLine()
        End While
        Str.Close()
        ' Form1.ModelCon.ReSetList()
    End Sub


    Private Sub AddDate(ByVal FliePath As String)

        Dim j As Integer
        Dim myfile As New System.IO.StreamWriter(FilePath)
        For j = 0 To DataGridView1.RowCount - 2
            Dim strTemp As String = ""
            strTemp = DataGridView1.Rows(j).Cells(0).Value + " " + DataGridView1.Rows(j).Cells(1).Value + " " + "1" + " " + Port + " " + Convert.ToString(Sum) + " " + BarCode + " " + Position
            myfile.WriteLine(strTemp)
        Next
        myfile.Close()
        For j = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows.Clear()
        Next
        FlieLoad(FilePath)
    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        AddDate(FilePath)
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Type = ComboBox1.Text
        NameS = TextBox2.Text
        Port = ComboBox5.Text
        Sum = NumericUpDown2.Value
        BarCode = TextBox1.Text
        Position = ComboBox4.Text
        Dim i = DataGridView1.Rows.Add()
        DataGridView1.Rows(i).Cells(0).Value = Type
        DataGridView1.Rows(i).Cells(1).Value = NameS
        DataGridView1.Rows(i).Cells(2).Value = True
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If DataGridView1.Rows(1).Cells(1).GetType.Name = "DataGridViewTextBoxCell" + "*" Then
            MessageBox.Show(DataGridView1.Rows(1).Cells(1).GetType.Name)
        End If
    End Sub
End Class