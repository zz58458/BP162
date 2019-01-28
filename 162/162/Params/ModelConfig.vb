Imports System.IO
Imports System.Windows.Forms
Imports DSD.MotionLib.AxisNoConfig
Imports System.Threading
Imports DSD.MotionLib


Public Class ModelConfig
    Public Veneer As List(Of String) = New List(Of String)
    Public PotoBit As New List(Of String) '拍照位
    'Public RetrievalLibrary As List(Of String) = New List(Of String) '爪库编号
    Public BarCodeName As List(Of String) = New List(Of String) '轴名称
    Public MaterialName As New List(Of String) '取料名称
    Public CardNowValue As New ArrayList '存储轴的位置及状态
    Dim BarCode As String = "F:\自动化软件\162项目\162\162\bin\Config\机种参数\设定点位.txt"
    Dim ReclaimBit As String = "F:\自动化软件\162项目\162\162\bin\Config\机种参数\自动测试.txt"
    Dim StitchBit As String = "F:\自动化软件\162项目\162\162\bin\Config\机种参数\针脚位.txt"
    Dim PluginBit As String = "F:\自动化软件\162项目\162\162\bin\Config\机种参数\插件位.txt"
    Dim MarkBit As String = "F:\自动化软件\162项目\162\162\bin\Config\机种参数\Mark位.txt"

    Dim CellValue As String
    Dim undoStack As New Stack(Of Object()())
    Dim redoStack As New Stack(Of Object()())
    Dim ignore As Boolean = False
    Dim GetEncoderNum As Int64 = 0
    Dim GetPositionNum As Int64 = 0
    Public GetPositionNum1 As New ArrayList '保存复位位置
    Public GetPositionNum2 As New ArrayList '启动位置
    Dim axisN As New AxisName
    'Dim IO As ArrayList = New ArrayList()

    Public Enum AxisName
        X = 0
        Y = 1
        Z1 = 2
        Z2 = 3
        Z3 = 4
        R1 = 5
        R2 = 6
        R3 = 7
        R4 = 8
        Z4 = 9
        Z5 = 10
        Z6 = 11
    End Enum

    Private Sub ModelConfig_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadFile()
        SetRightClick()
        For Each feed As String In SL_Config.FeedName '上料名称
            ComboBox6.Items.Add(feed)
        Next
        For Each item As String In Veneer
            ComboBox11.Items.Add(item)
        Next
        For Each item As String In BarCodeName
            ComboBox1.Items.Add(item)
            ComboBox4.Items.Add(item)
        Next
        For Each item As String In MaterialName
            ComboBox9.Items.Add(item)
            ComboBox8.Items.Add(item)
        Next
        For Each item As String In PotoBit
            ComboBox10.Items.Add(item)
        Next
        CVDate(DataGridView1)
        ComboBox1.SelectedIndex = 0
        ' Timer1.Enabled = True
        ' LoadF()
     
        'Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub GetE(ByVal Motion As DMCCard)
        For i As Short = 0 To DataGridView1.RowCount - 2
            DataGridView1.Rows(i).Cells(5).Value = Motion.InCard.GetPosition(i)
        Next
    End Sub
    Public Sub LoadFile()
        FlieLoad(BarCode, DataGridView1, DataGridView1.ColumnCount, 0)
        ' FlieLoad(StitchBit, DataGridView5, 11, 1)
        FlieLoad(ReclaimBit, DataGridView2, DataGridView2.ColumnCount, 2)
        'FlieLoad(PluginBit, DataGridView3, 11, 3)
        'FlieLoad(MarkBit, DataGridView4, 4, 4)
    End Sub
    ''' <summary>
    ''' 将本地文件加载到表中
    ''' </summary>
    ''' <param name="FliePath">本地文件路径</param>
    ''' <param name="DataGridV">表控件对象</param>
    ''' <param name="Rowss">表对象相应的列数</param>
    ''' <remarks></remarks>
    Public Sub FlieLoad(ByVal FliePath As String, ByRef DataGridV As DataGridView, ByVal Rowss As UInt16, ByVal num As UInt16)

        Dim Str As StreamReader = New StreamReader(FliePath, System.Text.Encoding.GetEncoding("gb2312"))
        Dim strLine As String = Str.ReadLine()
        While (String.IsNullOrEmpty(strLine) <> True)
            Dim strlist() As String = strLine.Split(" ")
            Dim i = DataGridV.Rows.Add()
            Dim j As Integer
            If num = 1 Then
                MaterialName.Add(strlist(0))
            ElseIf num = 4 Then
                Veneer.Add(strlist(0))
            ElseIf num = 0 Then
                BarCodeName.Add(strlist(1))
                GetPositionNum1.Add(strlist(5))
                GetPositionNum2.Add(strlist(6))
            ElseIf num = 2 Then
                PotoBit.Add(strlist(1))
            End If
            For j = 0 To Rowss - 1
                DataGridV.Rows(i).Cells(j).Value = strlist(j)
                If DataGridV.Rows(i).Cells(j).GetType.Name.Substring(12, 8) = "CheckBox" Then
                    DataGridV.Rows(i).Cells(j).Value = IIf(strlist(j) = "1", True, False)
                End If
            Next
            strLine = Str.ReadLine()
            ' My.Settings.Language = "zh_cn"
        End While
        Str.Close()
    End Sub
    ''' <summary>
    ''' 用于将数据添加到表中
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Select Case TabControl1.SelectedIndex
            Case 0
                'Features_Config.ControlCard.SetEncoder()
                For item As Short = 0 To DataGridView1.Rows.Count - 1
                    If TextBox1.Text = DataGridView1.Rows(item).Cells(0).Value Then
                        MessageBox.Show("轴已存在！！！")
                        Exit Sub
                    End If
                Next
                Dim i = DataGridView1.Rows.Add()
                DataGridView1.Rows(i).Cells(0).Value = TextBox1.Text
                DataGridView1.Rows(i).Cells(1).Value = ComboBox1.Text
                DataGridView1.Rows(i).Cells(2).Value = ComboBox2.Text
                DataGridView1.Rows(i).Cells(3).Value = ComboBox3.Text
                'DataGridView1.Rows(i).Cells(3).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 0) * (40.0 / 10000.0)
                DataGridView1.Rows(i).Cells(4).Value = FMain.Motion.InCard.GetEncoder(Convert.ToInt16(ComboBox1.Text))
                DataGridView1.Rows(i).Cells(5).Value = FMain.Motion.InCard.GetPosition(Convert.ToInt16(ComboBox1.Text))
                DataGridView1.Rows(i).Cells(6).Value = FMain.Motion.InCard.GetCheckDone(Convert.ToInt16(ComboBox1.Text))
                AddFlie(BarCode, DataGridView1)
                BarCodeName.Clear()
                ComboBox5.Items.Clear()
                FlieLoad(BarCode, DataGridView1, 7, 0)
                For Each item As String In BarCodeName
                    ComboBox5.Items.Add(item)
                Next
            Case 1
                For item As Short = 0 To DataGridView5.Rows.Count - 1
                    If TextBox2.Text = DataGridView5.Rows(item).Cells(0).Value Then
                        MessageBox.Show("轴已存在！！！")
                        Exit Sub
                    End If
                Next
                '  Features_Config.ControlCard.SetEncoder()
                Dim i = DataGridView5.Rows.Add()
                DataGridView5.Rows(i).Cells(0).Value = TextBox2.Text
                DataGridView5.Rows(i).Cells(1).Value = ComboBox4.Text
                DataGridView5.Rows(i).Cells(2).Value = ComboBox5.Text
                DataGridView5.Rows(i).Cells(3).Value = ComboBox6.Text
                'DataGridView2.Rows(i).Cells(4).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 0) * (40.0 / 10000.0)
                'DataGridView2.Rows(i).Cells(5).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 1) * (50.0 / 10000.0)
                'DataGridView2.Rows(i).Cells(6).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 2) * (50.0 / 10000.0)
                'DataGridView2.Rows(i).Cells(7).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 3) * (40.0 / 10000.0)
                DataGridView5.Rows(i).Cells(8).Value = "1"
                DataGridView5.Rows(i).Cells(9).Value = "0"
                DataGridView5.Rows(i).Cells(10).Value = "1"

                AddFlie(ReclaimBit, DataGridView5)
                MaterialName.Clear()
                ComboBox8.Items.Clear()
                ComboBox9.Items.Clear()
                FlieLoad(ReclaimBit, DataGridView5, 11, 1)
                For Each item As String In MaterialName
                    ComboBox9.Items.Add(item)
                    ComboBox8.Items.Add(item)
                Next
            Case 2
                For item As Short = 0 To DataGridView2.Rows.Count - 1
                    If TextBox3.Text = DataGridView2.Rows(item).Cells(0).Value Then
                        MessageBox.Show("轴已存在！！！")
                        Exit Sub
                    End If
                Next
                'Features_Config.ControlCard.SetEncoder()
                Dim i = DataGridView2.Rows.Add()
                DataGridView2.Rows(i).Cells(0).Value = True
                DataGridView2.Rows(i).Cells(1).Value = TextBox3.Text
                DataGridView2.Rows(i).Cells(2).Value = ComboBox7.Text
                'DataGridView3.Rows(i).Cells(3).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 0) * (40.0 / 10000.0)
                'DataGridView3.Rows(i).Cells(4).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 1) * (50.0 / 10000.0)
                'DataGridView3.Rows(i).Cells(5).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 2) * (50.0 / 10000.0)
                'DataGridView3.Rows(i).Cells(6).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 3) * (40.0 / 10000.0)
                DataGridView2.Rows(i).Cells(7).Value = False
                DataGridView2.Rows(i).Cells(8).Value = False
                AddFlie(StitchBit, DataGridView2)
                PotoBit.Clear()
                ComboBox10.Items.Clear()
                FlieLoad(StitchBit, DataGridView2, 9, 2)
                For Each item As String In PotoBit
                    ComboBox10.Items.Add(item)
                Next
            Case 3
                For item As Short = 0 To DataGridView3.Rows.Count - 1
                    If TextBox4.Text = DataGridView3.Rows(item).Cells(0).Value Then
                        MessageBox.Show("轴已存在！！！")
                        Exit Sub
                    End If
                Next
                ' Features_Config.ControlCard.SetEncoder()
                Dim i = DataGridView3.Rows.Add()
                DataGridView3.Rows(i).Cells(0).Value = True
                DataGridView3.Rows(i).Cells(1).Value = TextBox4.Text
                DataGridView3.Rows(i).Cells(2).Value = ComboBox9.Text
                DataGridView3.Rows(i).Cells(3).Value = ComboBox10.Text
                DataGridView3.Rows(i).Cells(4).Value = ComboBox11.Text
                'DataGridView4.Rows(i).Cells(5).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 0) * (40.0 / 10000.0)
                'DataGridView4.Rows(i).Cells(6).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 1) * (50.0 / 10000.0)
                'DataGridView4.Rows(i).Cells(7).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 2) * (50.0 / 10000.0)
                'DataGridView4.Rows(i).Cells(8).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 3) * (40.0 / 10000.0)
                DataGridView3.Rows(i).Cells(9).Value = False
                DataGridView3.Rows(i).Cells(10).Value = False
                AddFlie(PluginBit, DataGridView3)
                FlieLoad(PluginBit, DataGridView3, 11, 3)
            Case 4
                For item As Short = 0 To DataGridView4.Rows.Count - 1
                    If TextBox5.Text = DataGridView4.Rows(item).Cells(0).Value Then
                        MessageBox.Show("轴已存在！！！")
                        Exit Sub
                    End If
                Next
                'Features_Config.ControlCard.SetEncoder()
                Dim i = DataGridView4.Rows.Add()
                DataGridView4.Rows(i).Cells(0).Value = TextBox5.Text
                DataGridView4.Rows(i).Cells(1).Value = ComboBox12.Text
                'DataGridView5.Rows(i).Cells(2).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 0) * (40.0 / 10000.0)
                'DataGridView5.Rows(i).Cells(3).Value = ModuleCard.dmc_get_encoder(Features_Config.ControlCard.CardNo, 1) * (50.0 / 10000.0)
                AddFlie(MarkBit, DataGridView4)
                Veneer.Clear()
                ComboBox11.Items.Clear()
                FlieLoad(MarkBit, DataGridView4, 4, 4)
                For Each item As String In Veneer
                    ComboBox11.Items.Add(item)
                Next
        End Select
    End Sub
    ''' <summary>
    ''' 将表中数据添加到本地文件中去
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <param name="DataGridV"></param>
    ''' <remarks></remarks>
    Private Sub AddFlie(ByVal FilePath As String, ByRef DataGridV As DataGridView)
        Dim i As Integer
        Dim j As Integer
        Dim myfile As New System.IO.StreamWriter(FilePath)
        For j = 0 To DataGridV.RowCount - 2
            Dim strTemp As String = ""
            For i = 0 To DataGridV.ColumnCount - 1
                strTemp += Convert.ToString(DataGridV.Rows(j).Cells(i).Value) + " "
            Next
            myfile.WriteLine(strTemp)
        Next
        myfile.Close()
        For j = 0 To DataGridV.RowCount - 1
            DataGridV.Rows.Clear()
        Next
        'LoadFile()
    End Sub
#Region "用户两个TabControl控件的同步变化"
    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                TabControl2.SelectedIndex = 0
                ' Me.ContextMenuStrip1.Items.Clear()
            Case 1
                TabControl2.SelectedIndex = 1
                'Me.ContextMenuStrip1.Items.Clear()
            Case 2
                TabControl2.SelectedIndex = 2
                ' Me.ContextMenuStrip1.Items.Clear()
            Case 3
                TabControl2.SelectedIndex = 3
                ' Me.ContextMenuStrip1.Items.Clear()
            Case 4
                TabControl2.SelectedIndex = 4
                'Me.ContextMenuStrip1.Items.Clear()
        End Select
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl2.SelectedIndexChanged
        Select Case TabControl2.SelectedIndex
            Case 0
                TabControl1.SelectedIndex = 0
            Case 1
                TabControl1.SelectedIndex = 1
            Case 2
                TabControl1.SelectedIndex = 2
            Case 3
                TabControl1.SelectedIndex = 3
            Case 4
                TabControl1.SelectedIndex = 4
        End Select
    End Sub
#End Region
    ''' <summary>
    '''删除行控件函数
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Select Case TabControl1.SelectedIndex
            Case 0
                DeleRow(DataGridView1)
                AddFlie(BarCode, DataGridView1)
                FlieLoad(BarCode, DataGridView1, 7, 0)
            Case 1
                DeleRow(DataGridView5)
                AddFlie(ReclaimBit, DataGridView5)
                FlieLoad(ReclaimBit, DataGridView5, 11, 1)
            Case 2
                DeleRow(DataGridView2)
                AddFlie(StitchBit, DataGridView2)
                FlieLoad(StitchBit, DataGridView2, 9, 2)
            Case 3
                DeleRow(DataGridView3)
                AddFlie(PluginBit, DataGridView3)
                FlieLoad(PluginBit, DataGridView3, 11, 3)
            Case 4
                DeleRow(DataGridView4)
                AddFlie(MarkBit, DataGridView4)
                FlieLoad(MarkBit, DataGridView4, 4, 4)
        End Select
    End Sub
    ''' <summary>
    ''' 用于删除选中的一行
    ''' </summary>
    ''' <param name="DataGridV">数据表</param>
    ''' <remarks></remarks>
    Private Sub DeleRow(ByRef DataGridV As DataGridView)
        For Each r As DataGridViewRow In DataGridV.SelectedRows
            If Not r.IsNewRow Then
                DataGridV.Rows.Remove(r)
            End If
        Next
    End Sub
    ''' <summary>
    ''' 用于在表行头显示行号
    ''' </summary>
    ''' <param name="DataGridV"></param>
    ''' <remarks></remarks>
    Private Sub RowNum(ByRef DataGridV As DataGridView)
        Dim i As Integer
        For i = 0 To DataGridV.RowCount - 1
            DataGridV.Rows(i).HeaderCell.Value = (i + 1).ToString
            Dim dvs As DataGridViewCellStyle = New DataGridViewCellStyle()
            dvs.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridV.Rows(i).HeaderCell.Style = dvs

        Next
    End Sub
#Region "表行数变化时，发生的事件"

    Private Sub DataGridView1_GotFocus(sender As Object, e As System.EventArgs) Handles DataGridView1.GotFocus
        ' Focus_goty()
    End Sub
    Private Sub DataGridView1_RowStateChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView1.RowStateChanged
        RowNum(DataGridView1)
    End Sub

    Private Sub DataGridView1_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValidated
        CVDate(DataGridView1)
    End Sub

    Private Sub DataGridView2_GotFocus(sender As Object, e As System.EventArgs)
        'Focus_Got(DataGridView2) '生成菜单项
        ' Focus_goty()
    End Sub

    Private Sub DataGridView2_RowStateChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs)
        RowNum(DataGridView5)
    End Sub

    Private Sub DataGridView2_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView3_GotFocus(sender As Object, e As System.EventArgs) Handles DataGridView2.GotFocus
        'Focus_Got(DataGridView3) '生成菜单项
        'Focus_goty()
    End Sub

    Private Sub DataGridView3_RowStateChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView2.RowStateChanged
        RowNum(DataGridView2)
    End Sub
    Private Sub DataGridView3_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellValidated

    End Sub

    Private Sub DataGridView4_GotFocus(sender As Object, e As System.EventArgs) Handles DataGridView3.GotFocus
        'Focus_Got(DataGridView4) '生成菜单项
        '  Focus_goty()
    End Sub

    Private Sub DataGridView4_RowStateChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView3.RowStateChanged
        RowNum(DataGridView3)
    End Sub

    Private Sub DataGridView4_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellValidated

    End Sub

    Private Sub DataGridView5_GotFocus(sender As Object, e As System.EventArgs) Handles DataGridView4.GotFocus
        'Focus_Got(DataGridView5) '生成菜单项
        'Focus_goty()
    End Sub

    Private Sub DataGridView5_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellValidated

    End Sub

    Private Sub DataGridView5_RowStateChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView4.RowStateChanged
        RowNum(DataGridView4)
    End Sub
#End Region
    Private Sub SetRightClick()
        DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridView5.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridView2.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridView3.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridView4.ContextMenuStrip = Me.ContextMenuStrip1
    End Sub

    Public Sub ReSetList()
        ComboBox6.Items.Clear()
        For Each feed As String In SL_Config.FeedName '上料名称
            ComboBox6.Items.Add(feed)
        Next
    End Sub

    Private Sub Focus_Got(ByRef DataGridV As DataGridView)
        '动态生成菜单单项的过程
        With DataGridV
            '清除菜单项
            ' Me.ContextMenuStrip1.Items.Clear()
            'Dim fgx1 As ToolStripSeparator = New ToolStripSeparator()
            'Me.ContextMenuStrip1.Items.Add(fgx1)
            'Dim Menu_item1 As ToolStripMenuItem = New ToolStripMenuItem
            'Menu_item1.Text = "选择显示的字段"
            'Menu_item1.Enabled = False
            'Me.ContextMenuStrip1.Items.Add(Menu_item1)
            ''添加分割线
            'Dim fgx As ToolStripSeparator = New ToolStripSeparator()
            'Me.ContextMenuStrip1.Items.Add(fgx)
            '根据DataGridView的列名添加菜单项、
            Dim doItem As ToolStripMenuItem = ContextMenuStrip1.Items("选择显示列ToolStripMenuItem")
            Dim i As UInt16
            For i = 0 To DataGridV.ColumnCount - 1
                Dim Menu_item As ToolStripMenuItem = New ToolStripMenuItem()
                Menu_item.Text = DataGridV.Columns(i).HeaderText
                Menu_item.Checked = DataGridV.Columns(i).Visible
                doItem.DropDownItems.Add(Menu_item)
            Next
        End With
    End Sub

    Private Sub ContextMenuStrip1_Closed(sender As Object, e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles ContextMenuStrip1.Closed
        '关闭菜单时，将选定的结果应用到DataGridView
        Dim doItem As ToolStripMenuItem = ContextMenuStrip1.Items("选择显示列ToolStripMenuItem")
        Dim i As Int16
        For i = 0 To doItem.DropDownItems.Count - 1 'Me.ContextMenuStrip1.Items.Count - 1
            '这里我们需要设置被点击的菜单项（ToolStripMenuItem）的Checked状态，但是我们不能直接通过Me.ContextMenuStrip1.Items(i).Checked的方式操作，
            '必须把它进行类型转换，同样的情况见“ContextMenuStrip1.ItemClicked”
            Try
                If doItem.DropDownItems(i).Text <> "" Then 'Me.ContextMenuStrip1.Items(i).Text <> "" 
                    Select Case Me.TabControl1.SelectedIndex
                        Case 0
                            Me.DataGridView1.Columns(doItem.DropDownItems(i).Text + "0").Visible = CType(doItem.DropDownItems(i), ToolStripMenuItem).Checked()
                            'Case 1
                            '    Me.DataGridView2.Columns(Me.ContextMenuStrip1.Items(i).Text + "1").Visible = CType(Me.ContextMenuStrip1.Items(i), ToolStripMenuItem).Checked()
                        Case 1
                            Me.DataGridView5.Columns(doItem.DropDownItems(i).Text + "1").Visible = CType(doItem.DropDownItems(i), ToolStripMenuItem).Checked()
                        Case 2
                            Me.DataGridView2.Columns(doItem.DropDownItems(i).Text + "2").Visible = CType(doItem.DropDownItems(i), ToolStripMenuItem).Checked()
                        Case 3
                            Me.DataGridView3.Columns(doItem.DropDownItems(i).Text + "3").Visible = CType(doItem.DropDownItems(i), ToolStripMenuItem).Checked()
                        Case 4
                            Me.DataGridView4.Columns(doItem.DropDownItems(i).Text + "4").Visible = CType(doItem.DropDownItems(i), ToolStripMenuItem).Checked()
                    End Select
                End If
            Catch ex As Exception
                MessageBox.Show("请选中单元格！！！", ex.Message)
                Exit For
            End Try

        Next
    End Sub

    Private Sub ContextMenuStrip1_Closing(sender As Object, e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        '取消点击选项就消失，这样只有在菜单外的区域点击菜单才会消失
        '在此判断引发时间的原因即“e.CloseReason”的值
        'If e.CloseReason.ToString = "ItemClicked" Then
        '    e.Cancel = True
        'End If

    End Sub

    Private Sub ContextMenuStrip1_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        '点击菜单项时，将菜单项的选定状态取反
        '被点击的菜单项为e.ClickedItem
        'CType(e.ClickedItem, ToolStripMenuItem).Checked = Not CType(e.ClickedItem, ToolStripMenuItem).Checked
    End Sub

    Private Sub Focus_goty()
        Dim doItem As ToolStripMenuItem = ContextMenuStrip1.Items("选择显示列ToolStripMenuItem")
        Select Case TabControl1.SelectedIndex
            Case 0
                doItem.DropDownItems.Clear()
                Focus_Got(DataGridView1) '生成菜单项
            Case 1
                doItem.DropDownItems.Clear()
                Focus_Got(DataGridView5) '生成菜单项
            Case 2
                doItem.DropDownItems.Clear()
                Focus_Got(DataGridView2) '生成菜单项
            Case 3
                doItem.DropDownItems.Clear()
                Focus_Got(DataGridView3) '生成菜单项
            Case 4
                doItem.DropDownItems.Clear()
                Focus_Got(DataGridView4) '生成菜单项
        End Select
    End Sub

    Private Sub 选择显示列ToolStripMenuItem_DropDownItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles 选择显示列ToolStripMenuItem.DropDownItemClicked
        CType(e.ClickedItem, ToolStripMenuItem).Checked = Not CType(e.ClickedItem, ToolStripMenuItem).Checked
    End Sub
    Declare Function SendMessage Lib "user" (ByVal hWnd As Integer, ByVal wMsg As Integer, wParam As Integer, lparam As Int16) As Long


    Private Sub 复制ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 复制ToolStripMenuItem.Click
        Select Case TabControl1.SelectedIndex
            Case 0
                CellValue = DataGridView1.CurrentCell.Value
            Case 1
                CellValue = DataGridView5.CurrentCell.Value
            Case 2
                CellValue = DataGridView2.CurrentCell.Value
            Case 3
                CellValue = DataGridView3.CurrentCell.Value
            Case 4
                CellValue = DataGridView4.CurrentCell.Value
        End Select
    End Sub

    Private Sub 粘贴ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 粘贴ToolStripMenuItem.Click
        Select Case TabControl1.SelectedIndex
            Case 0
                DataGridView1.CurrentCell.Value = CellValue
            Case 1
                DataGridView5.CurrentCell.Value = CellValue
            Case 2
                DataGridView2.CurrentCell.Value = CellValue
            Case 3
                DataGridView3.CurrentCell.Value = CellValue
            Case 4
                DataGridView4.CurrentCell.Value = CellValue
        End Select
    End Sub

    Private Sub 全选ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 全选ToolStripMenuItem.Click
        Select Case TabControl1.SelectedIndex
            Case 0
                Dim Smessage As String = String.Empty
                For column As Integer = 0 To DataGridView1.ColumnCount - 1
                    Smessage += DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(column).Value + " "
                Next
            Case 1
                Dim Smessage As String = String.Empty
                For column As Integer = 0 To DataGridView5.ColumnCount - 1
                    Smessage += DataGridView5.Rows(DataGridView5.CurrentCell.RowIndex).Cells(column).Value
                Next
            Case 2
                Dim Smessage As String = String.Empty
                For column As Integer = 0 To DataGridView2.ColumnCount - 1
                    Smessage += DataGridView2.Rows(DataGridView2.CurrentCell.RowIndex).Cells(column).Value
                Next
            Case 3
                Dim Smessage As String = String.Empty
                For column As Integer = 0 To DataGridView3.ColumnCount - 1
                    Smessage += DataGridView3.Rows(DataGridView3.CurrentCell.RowIndex).Cells(column).Value
                Next
            Case 4
                Dim Smessage As String = String.Empty
                For column As Integer = 0 To DataGridView4.ColumnCount - 1
                    Smessage += DataGridView4.Rows(DataGridView4.CurrentCell.RowIndex).Cells(column).Value
                Next
        End Select
    End Sub

    Private Sub 删除ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 删除ToolStripMenuItem.Click
        Select Case TabControl1.SelectedIndex
            Case 0
                DataGridView1.CurrentCell.Value = ""
            Case 1
                DataGridView5.CurrentCell.Value = ""
            Case 2
                DataGridView2.CurrentCell.Value = ""
            Case 3
                DataGridView3.CurrentCell.Value = ""
            Case 4
                DataGridView4.CurrentCell.Value = ""
        End Select
    End Sub

    Private Sub 撤销UToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 撤销UToolStripMenuItem.Click
        Select Case TabControl1.SelectedIndex
            Case 0

            Case 1
                DataGridView5.CurrentCell.Value = ""
            Case 2
                DataGridView2.CurrentCell.Value = ""
            Case 3
                DataGridView3.CurrentCell.Value = ""
            Case 4
                DataGridView4.CurrentCell.Value = ""
        End Select
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' 当表中的值出现变化时，发生此事件；
    ''' 每当修改值时，将修改的步骤添加到“撤回”undoStack数组中（二维数组）
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <remarks></remarks>
    Private Sub CVDate(ByRef dgv As DataGridView)
        If ignore Then Return
        If undoStack.NeddsItem(dgv) Then '将上一步步骤与目前表格的情况相比较，相同时返回（NOT）true,否则为(NOT)false
            undoStack.Push(dgv.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).Select(Function(r) r.Cells.Cast(Of DataGridViewCell).Select(Function(c) c.Value).ToArray).ToArray)
        End If
        ToolStripButton2.Enabled = undoStack.Count > 0
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        UndoClick(DataGridView1)
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        RedoClick(DataGridView1)
    End Sub
    ''' <summary>
    ''' 撤回（左）
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <remarks></remarks>
    Private Sub UndoClick(ByVal dgv As DataGridView)
        If redoStack.Count = 0 OrElse redoStack.NeddsItem(dgv) Then
            '在撤回时，将最后的步骤加入到“恢复”redoStack数组中
            ' 将目前表格后一步步骤与目前表格的情况相比较，相同时返回（NOT）true,否则为(NOT)false
            redoStack.Push(dgv.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).Select(Function(r) r.Cells.Cast(Of DataGridViewCell).Select(Function(c) c.Value).ToArray).ToArray)
        End If
        Dim rows()() As Object = undoStack.Pop '并去掉“撤回”数组中最后加入的步骤
        While rows.ItemEquals(dgv.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).ToArray) '用撤回的步骤与目前表格的情况相比，相同时，为true。不同时为false
            rows = undoStack.Pop '当撤回的步骤与目前表格相同的时候，需要过滤掉这一步，而进入下一步撤回步骤。
        End While
        ignore = True
        dgv.Rows.Clear()
        For x As Integer = 0 To rows.GetUpperBound(0)
            dgv.Rows.Add(rows(x))
        Next
        ignore = False
        ToolStripButton2.Enabled = undoStack.Count > 0
        ToolStripButton3.Enabled = redoStack.Count > 0
    End Sub
    ''' <summary>
    ''' 恢复（右）
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <remarks></remarks>
    Private Sub RedoClick(ByVal dgv As DataGridView)
        If undoStack.Count = 0 OrElse undoStack.NeddsItem(dgv) Then
            '在恢复时，将最后的步骤加入到“撤回”undoStack数组中
            ' 将目前表格前一步步骤与目前表格的情况相比较，相同时返回（NOT）true,否则为(NOT)false
            undoStack.Push(dgv.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).Select(Function(r) r.Cells.Cast(Of DataGridViewCell).Select(Function(c) c.Value).ToArray).ToArray)
        End If
        Dim rows()() As Object = redoStack.Pop '并去掉“恢复”数组中最后加入的步骤
        While rows.ItemEquals(dgv.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).ToArray) '用恢复的步骤与目前表格的情况相比，相同时，为true。不同时为false
            rows = redoStack.Pop '当恢复的步骤与目前表格相同的时候，需要过滤掉这一步，而进入下一步撤回步骤。
        End While
        ignore = True
        dgv.Rows.Clear()
        For x As Integer = 0 To rows.GetUpperBound(0)
            dgv.Rows.Add(rows(x))
        Next
        ignore = False
        ToolStripButton2.Enabled = undoStack.Count > 0
        ToolStripButton3.Enabled = redoStack.Count > 0

    End Sub

    Private Sub OutlookBar1_Click(sender As System.Object, e As _162.OutlookStyleControls.OutlookBar.ButtonClickEventArgs)

    End Sub

    Private Sub LoadF()
        Try
            Dim PathS As String = My.Application.Info.DirectoryPath
            Dim Path As String = PathS.Substring(0, PathS.LastIndexOf("\")) & "\Config\"
            FMain.frm.ANConfig.LoadAxiaN(Path, "Mation")
            DataGridView1.Rows.Clear()
            If FMain.frm.ANConfig.CarNewList.Count > 0 Then
                For i As Int16 = 0 To FMain.frm.ANConfig.CarNewList.Count - 1
                    Dim CarNewListValue As _PNode = FMain.frm.ANConfig.CarNewList(i)
                    DataGridView1.Rows.Add()
                    DataGridView1.Item(0, i).Value = CarNewListValue.AxisName
                    DataGridView1.Item(1, i).Value = CarNewListValue.AxisNum
                    DataGridView1.Item(2, i).Value = CarNewListValue.cardNum
                    DataGridView1.Item(3, i).Value = FMain.frm.ANConfig.CardCount
                    'DataGridView1.Item(4, i).Value = FMain.Motion.InCard.GetEncoder(CarNewListValue.AxisNum)
                    ' DataGridView1.Item(5, i).Value = FMain.Motion.InCard.GetPosition(CarNewListValue.AxisNum)
                    DataGridView1.Item(6, i).Value = "true"
                Next
            End If
        Catch ex As Exception
            Throw New Exception("404002;" & "XX更新轴对应关系表格错误")
        End Try
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If DataGridView1.CurrentCell IsNot Nothing Then
            GetEncoderNum = FMain.Motion.InCard.GetEncoder(Convert.ToInt16(ComboBox1.Text))
            GetPositionNum = FMain.Motion.InCard.GetPosition(Convert.ToInt16(ComboBox1.Text))
            DataGridView1.Rows(Convert.ToInt16(ComboBox1.Text)).Cells(4).Value() = GetEncoderNum
            If DataGridView1.CurrentCell.ColumnIndex = 5 Then
                DataGridView1.Rows(Convert.ToInt16(ComboBox1.Text)).Cells(5).Value() = GetPositionNum
                GetPositionNum1(5) = GetPositionNum
                'GetPositionNum1.Add(GetPositionNum)
            ElseIf DataGridView1.CurrentCell.ColumnIndex = 6 Then
                DataGridView1.Rows(Convert.ToInt16(ComboBox1.Text)).Cells(6).Value() = GetPositionNum
                GetPositionNum2(6) = GetPositionNum
                'GetPositionNum2.Add(GetPositionNum)
            End If
        Else
            MessageBox.Show("请选择好要修改的内容！！！")
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If DataGridView1.CurrentCell IsNot Nothing Then
            FMain.Motion.InCard.TPmove(Convert.ToInt16(ComboBox1.Text), Convert.ToUInt64(DataGridView1.CurrentCell.Value), 0)
        Else
            MessageBox.Show("请选择要移动到的位置！！！")
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Select Case TabControl1.SelectedIndex
            Case 0
                AddFlie(BarCode, DataGridView1)
                BarCodeName.Clear()
                ComboBox5.Items.Clear()
                FlieLoad(BarCode, DataGridView1, 7, 0)
                For Each item As String In BarCodeName
                    ComboBox5.Items.Add(item)
                Next
            Case 1
                AddFlie(ReclaimBit, DataGridView5)
                MaterialName.Clear()
                ComboBox8.Items.Clear()
                ComboBox9.Items.Clear()
                FlieLoad(ReclaimBit, DataGridView5, 11, 1)
                For Each item As String In MaterialName
                    ComboBox9.Items.Add(item)
                    ComboBox8.Items.Add(item)
                Next
            Case 2
                AddFlie(StitchBit, DataGridView2)
                PotoBit.Clear()
                ComboBox10.Items.Clear()
                FlieLoad(StitchBit, DataGridView2, 9, 2)
                For Each item As String In PotoBit
                    ComboBox10.Items.Add(item)
                Next
            Case 3
                AddFlie(PluginBit, DataGridView3)
                FlieLoad(PluginBit, DataGridView3, 11, 3)
            Case 4
                AddFlie(MarkBit, DataGridView4)
                Veneer.Clear()
                ComboBox11.Items.Clear()
                FlieLoad(MarkBit, DataGridView4, 4, 4)
                For Each item As String In Veneer
                    ComboBox11.Items.Add(item)
                Next
        End Select
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Seletion(ComboBox1, TextBox1)
    End Sub

    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i = DataGridView1.CurrentCell.RowIndex
        Try
            ComboBox1.SelectedIndex = i
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs)


        'FMain.Fio.GerIOStatus()
    End Sub

    Private Sub DataGridView2_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim i = DataGridView2.CurrentCell.RowIndex
        Try
            ComboBox4.SelectedIndex = i
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Seletion(ByRef ComboBox As ComboBox, ByRef textbox As TextBox)
        Select Case ComboBox.SelectedIndex
            Case 0
                textbox.Text = AxisName.X.ToString
            Case 1
                textbox.Text = AxisName.Y.ToString
            Case 2
                textbox.Text = AxisName.Z1.ToString
            Case 3
                textbox.Text = AxisName.Z2.ToString
            Case 4
                textbox.Text = AxisName.Z3.ToString
            Case 5
                textbox.Text = AxisName.R1.ToString
            Case 6
                textbox.Text = AxisName.R2.ToString
            Case 7
                textbox.Text = AxisName.R3.ToString
            Case 8
                textbox.Text = AxisName.R4.ToString
            Case 9
                textbox.Text = AxisName.Z4.ToString
            Case 10
                textbox.Text = AxisName.Z5.ToString
            Case 11
                textbox.Text = AxisName.Z6.ToString
        End Select
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Seletion(ComboBox4, TextBox2)
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        FMain.Motion.InCard.HomeMode(Convert.ToUInt16(ComboBox4.Text), 0, 0)
        FMain.Motion.InCard.HomeMove(Convert.ToUInt16(ComboBox4.Text), 2, 1)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub


    Private Sub XPanderPanel4_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class
