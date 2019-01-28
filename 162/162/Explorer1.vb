Imports System
Imports System.Diagnostics
Imports System.Windows.Forms
Imports DSD.MotionLib
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports Microsoft.VisualBasic.FileIO

Public Class Explorer1
    Private mReadIO As IORW
    Dim Patht As String = My.Application.Info.DirectoryPath
    Dim path As String = Patht.Substring(0, Patht.LastIndexOf("\")) & "\Config\PParam.mtq"
    Dim pathS As String = Patht.Substring(0, Patht.LastIndexOf("\")) & "\Config\OutPParam.mtq"
    Dim Params As New absMtAxis.AxisParam
    Dim AxisParam As New AxisRunParam

    Dim Num As Int16
    Dim index As Single = 0.0
    Dim cio As New ClassIO
    Dim MarkBit As String = "F:\自动化软件\162项目\162\162\bin\Config\机种参数\AxisParam.txt"
    Dim dir As String = Patht.Substring(0, Patht.LastIndexOf("\")) & "\Config" & "\"
    Dim datagridv As New DataGridView

    Public Structure AxisRunParam
        Public Card As String
        Public XCoordinata As String
        Public YCoordinata As String
        Public ZCoordinata As String
        Public RCoordinata As String
        Public Seep As String
        Public Stime As String
        Public Enable As String

        Public Sub Save(ByVal Path As String)
            Try
                WriteIni("Card", Card, Path)
                WriteIni("XCoordinata", XCoordinata, Path)
                WriteIni("YCoordinata", YCoordinata, Path)
                WriteIni("ZCoordinata", ZCoordinata, Path)
                WriteIni("RCoordinata", RCoordinata, Path)
                WriteIni("Seep", Seep, Path)
                WriteIni("Stime", Stime, Path)
                WriteIni("Enable", Enable, Path)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub load(ByVal Path As String, ByVal ipsectionname As String)
            Try
                Path = Path & ".mtq"
                Card = Convert.ToString(ReadI(ipsectionname, "Card", 0, Path))
                XCoordinata = Convert.ToString(ReadI(ipsectionname, "XCoordinata", 0, Path))
                YCoordinata = Convert.ToString(ReadI(ipsectionname, "YCoordinata", 0, Path))
                ZCoordinata = Convert.ToString(ReadI(ipsectionname, "ZCoordinata", 0, Path))
                RCoordinata = Convert.ToString(ReadI(ipsectionname, "RCoordinata", 0, Path))
                Seep = Convert.ToString(ReadI(ipsectionname, "Seep", 0, Path))
                Stime = Convert.ToString(ReadI(ipsectionname, "Stime", 0, Path))
                Enable = Convert.ToString(ReadI(ipsectionname, "Enable", 0, Path))
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Structure
    'Class Paramm
    '    Public para As absMtAxis.AxisParam
    'End Class
    Private Sub Explorer1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '设置 UI
        ' SetUpListViewColumns()
        'LoadTree()
        'CreateMyListView()
        mReadIO = New IORW(Form1.fm.frm.Motion.InCard)
        ' DataShow(path, mReadIO.gggIN)
    End Sub

    Private Sub LoadListView()
        ' TODO: 添加代码以根据在树视图中选择的项向列表视图中添加项

        Dim lvItem As ListViewItem
        ListView.Items.Clear()

        lvItem = ListView.Items.Add("ListViewItem1")
        lvItem.ImageKey = "Graph1"
        lvItem.SubItems.AddRange(New String() {"列2", "列3"})

        lvItem = ListView.Items.Add("ListViewItem2")
        lvItem.ImageKey = "Graph2"
        lvItem.SubItems.AddRange(New String() {"列2", "列3"})

        lvItem = ListView.Items.Add("ListViewItem3")
        lvItem.ImageKey = "Graph3"
        lvItem.SubItems.AddRange(New String() {"列2", "列3"})
    End Sub

    Private Sub SetUpListViewColumns()

        ' TODO: 添加代码以设置列表视图中的列
        Dim lvColumnHeader As ColumnHeader

        ' 设置列宽操作仅应用于当前视图，所以此行
        '  将 ListView 显式设置为显示 SmallIcon 视图
        '  在设置列宽之前
        SetView(View.SmallIcon)

        lvColumnHeader = ListView.Columns.Add("列1")
        ' 请将 SmallIcon 视图列宽设置得足够大，以便各个项目
        '  不会发生重叠
        ' 请注意，SmallIcon 视图中未显示第二列和第三列，
        '  所以在处于 SmallIcon 视图中时不需要设置它们
        lvColumnHeader.Width = 90

        ' 将视图更改为 Details 并将 Details 视图
        '  中相应列的宽度设置为与 SmallIcon 视图不同的宽度
        SetView(View.Details)

        ' Details 视图中第一列的宽度需要稍大于它在
        '  SmallIcon 视图中的宽度，列2 和 列3 需要显式设置
        '  Details 视图的大小
        lvColumnHeader.Width = 100

        lvColumnHeader = ListView.Columns.Add("列2")
        lvColumnHeader.Width = 70

        lvColumnHeader = ListView.Columns.Add("列3")
        lvColumnHeader.Width = 70

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        '关闭此窗体
        Me.Close()
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBarToolStripMenuItem.Click
        '切换工具条的可见性及相关菜单项的选中状态
        ToolBarToolStripMenuItem.Checked = Not ToolBarToolStripMenuItem.Checked
        ToolStrip.Visible = ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusBarToolStripMenuItem.Click
        '切换状态条的可见性及相关菜单项的选中状态
        StatusBarToolStripMenuItem.Checked = Not StatusBarToolStripMenuItem.Checked
        StatusStrip.Visible = StatusBarToolStripMenuItem.Checked
    End Sub

    '更改文件夹窗格的可见性
    Private Sub ToggleFoldersVisible()
        '首先切换相关菜单项的选中状态
        FoldersToolStripMenuItem.Checked = Not FoldersToolStripMenuItem.Checked

        '同步文件夹工具栏按钮
        FoldersToolStripButton.Checked = FoldersToolStripMenuItem.Checked

        ' 折叠包含 TreeView 的面板。
        Me.SplitContainer.Panel1Collapsed = Not FoldersToolStripMenuItem.Checked
    End Sub

    Private Sub FoldersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoldersToolStripMenuItem.Click
        ' ToggleFoldersVisible()
    End Sub

    Private Sub FoldersToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoldersToolStripButton.Click
        ToggleFoldersVisible()
    End Sub

    Private Sub SetView(ByVal View As System.Windows.Forms.View)
        '判断哪个菜单项应处于选中状态
        Dim MenuItemToCheck As ToolStripMenuItem = Nothing
        Select Case View
            Case View.Details
                MenuItemToCheck = DetailsToolStripMenuItem
            Case View.LargeIcon
                MenuItemToCheck = LargeIconsToolStripMenuItem
            Case View.List
                MenuItemToCheck = ListToolStripMenuItem
            Case View.SmallIcon
                MenuItemToCheck = SmallIconsToolStripMenuItem
            Case View.Tile
                MenuItemToCheck = TileToolStripMenuItem
            Case Else
                ' Debug.Fail("Unexpected View")
                View = View.Details
                MenuItemToCheck = DetailsToolStripMenuItem
        End Select

        '选中“视图”菜单下相应的菜单项并取消选中所有其他菜单项
        For Each MenuItem As ToolStripMenuItem In ListViewToolStripButton.DropDownItems
            If MenuItem Is MenuItemToCheck Then
                MenuItem.Checked = True
            Else
                MenuItem.Checked = False
            End If
        Next

        '最后，设置所请求的视图
        ListView.View = View
    End Sub

    Private Sub ListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListToolStripMenuItem.Click
        SetView(View.List)
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailsToolStripMenuItem.Click
        SetView(View.Details)
    End Sub

    Private Sub LargeIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LargeIconsToolStripMenuItem.Click
        SetView(View.LargeIcon)
    End Sub

    Private Sub SmallIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmallIconsToolStripMenuItem.Click
        SetView(View.SmallIcon)
    End Sub

    Private Sub TileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileToolStripMenuItem.Click
        SetView(View.Tile)
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "文本文件 (*.txt)|*.txt"
        OpenFileDialog.ShowDialog(Me)

        Dim FileName As String = OpenFileDialog.FileName
        ' TODO: 添加代码以打开该文件
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "文本文件 (*.txt)|*.txt"
        SaveFileDialog.ShowDialog(Me)

        Dim FileName As String = SaveFileDialog.FileName
        ' TODO: 在此处添加代码，将窗体的当前内容保存到一个文件中。
    End Sub

    Private Sub TreeView_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
        ' TODO: 根据树视图当前选定的节点，添加更改 Listview 内容的代码

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click

        If index >= 20 And index < 30 Then
            SaveFlie(Params, 1)
            '   showData((ToolStripTextBox2.Text.Substring(ToolStripTextBox2.Text.LastIndexOf("\")).Substring(1, 2)))
        ElseIf index > 0 And index < 20 Then
            SaveFlie(cio.StrInput)
            mReadIO.ReGetIOStauta()
        End If
    End Sub

    Private Sub DataShow(ByVal path As String, Optional ByVal ginout(,) As String = Nothing, Optional ByVal para As Object = Nothing, Optional ByVal ft As Boolean = False, Optional ByVal boo As Int16 = 0)
        ToolStripTextBox2.Text = path

        Dim Count As Int16

        Count = CInt(ReadP("Count", "0", path, "Count"))
        If Count < 1 Then
            Count = 1
        End If
        If boo = 0 Then
            '    Dim Counts As Int16 = CInt(ReadP("Count", "0", pathS, "Count"))
            Dim Str As StreamReader = New StreamReader(path, System.Text.Encoding.GetEncoding("gb2312"))
            Dim strLine As String = Str.ReadLine()
            strLine = Str.ReadLine()
            Str.Close()

            Dim AddN As Int16 = 0
            If (String.IsNullOrEmpty(strLine) <> True) Then
                Dim strlist() As String = strLine.Split(" ")
                Num = Convert.ToInt16(strlist(0))
                If Num = 0 Then
                    Exit Sub
                End If
                For i As Int16 = 1 To Num
                    DataGridView1.Columns.Add(strlist(i), strlist(i))
                Next
            End If
        End If

        For j As Int16 = 0 To Count - 1
            Dim i = DataGridView1.Rows.Add()
            If ginout IsNot Nothing Then
                For jj As Int16 = 0 To Num - 1
                    DataGridView1.Rows(i).Cells(jj).Value = ginout(j, jj) 'mReadIO.gggIN(j, jj)
                Next
            End If

            If ginout Is Nothing Then
                Dim ii As Int16 = 1
                If ft = True Then
                    ii = 0
                End If
                For Each item In para.GetType.GetFields
                    If ii >= Num Then
                        Exit For
                    End If
                    DataGridView1.Rows(i).Cells(ii).Value = item.GetValue(para)
                    If ii = 22 Then
                        DataGridView1.Rows(i).Cells(0).Value = IIf(DataGridView1.Rows(i).Cells(ii).Value, 0 Or 1, True)
                    End If
                    ii = ii + 1
                Next
                If ft = True Then
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As System.Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Select Case (e.Node.Text)
            Case "IOParam"

            Case "AxisParam"

            Case "PParam"
                DataGridView1.Rows.Clear()
                DataGridView1.Columns.Clear()
                DataShow(path, mReadIO.gggIN)
                MessageBox.Show("加载完成！！！")
                index = 10
            Case "OutPParam"
                DataGridView1.Rows.Clear()
                DataGridView1.Columns.Clear()
                DataShow(pathS, mReadIO.gggOUT)
                MessageBox.Show("加载完成！！！")
                index = 11
            Case "R1BaseParam"
                showData("R1", Params)
                index = 20
            Case "R2BaseParam"
                showData("R2", Params)
                index = 21
            Case "R3BaseParam"
                showData("R2", Params)
                index = 22
            Case "R4BaseParam"
                showData("R4", Params)
                index = 23
            Case "XBaseParam"
                showData("X", Params)
                index = 24
            Case "YBaseParam"
                showData("Y", Params)
                index = 25
            Case "Z1BaseParam"
                showData("Z1", Params)
                index = 26
            Case "Z2BaseParam"
                showData("Z2", Params)
                index = 27
            Case "Z3BaseParam"
                showData("Z3", Params)
                index = 28
            Case "Z4BaseParam"
                showData("Z4", Params)
                index = 29
            Case "Z5BaseParam"
                showData("Z5", Params)
                index = 29.1
            Case "CVBaseParam"
                showData("CV", Params)
                index = 29.2
        End Select
    End Sub

    Private Sub showData(ByVal dirr As String, ByVal Para As Object, Optional ByVal n As Int16 = 1)
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        For i As Int16 = 0 To n - 1
            If Patht IsNot Nothing And Patht <> String.Empty And IO.Directory.Exists(Patht) Then
                Dim diri = dir & dirr & "BaseParam"
                If IO.File.Exists(diri & ".mtq") Then
                    Para.load(diri)
                    DataShow(diri + ".mtq", , Para)
                ElseIf IO.File.Exists(diri & ".mtq") = False Then
                    diri = ""
                    diri = dir + "机种参数\" + dirr
                    Para.load(diri, i + 1)
                    DataShow(diri + ".mtq", , Para, True, i)
                Else
                    MessageBox.Show("XX未发现该轴参数文件")
                End If
            End If
        Next
        MessageBox.Show("加载完成！！！")
    End Sub
    ''' <summary>
    ''' 保存每个轴的配置文件
    ''' </summary>
    ''' <param name="Params">结构体</param>
    ''' <remarks></remarks>
    Private Sub SaveFlie(ByRef Params As Object, Optional ByVal Number As Int16 = 0)
        Dim jElem As String = Nothing
        Dim ii As Int16 = Number
        For i As Integer = 0 To DataGridView1.RowCount - 2
            For item As Int16 = 0 To DataGridView1.ColumnCount - 1
                If ii > Num Then
                    Exit For
                End If
                jElem += Convert.ToString(DataGridView1.Rows(i).Cells(item).Value) + "^"
                ii = ii + 1
            Next
            Params = DelimStrToStruct(jElem, Params, "^", Number)
            If index >= 20 And index < 30 Then
                Params.Save(ToolStripTextBox2.Text, Params)
            ElseIf index > 0 And index < 20 Then
                cio.StrInput = Params
                cio.StrInput.SaveIn(ToolStripTextBox2.Text, "Put" & i + 1)
            End If
            jElem = Nothing
            ii = Number
        Next
    End Sub


    Private Function StructSetValue(ByRef iStruct As Object, ByVal iFidName As String, ByVal iValue As Object) As Object
        Dim tStruct As ValueType = iStruct
        Dim field As FieldInfo = tStruct.[GetType]().GetField(iFidName)
        Dim ty As Type = field.FieldType
        Try
            field.SetValue(tStruct, CTypeDynamic(iValue, field.FieldType))
            Return tStruct
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function DelimStrToStruct(ByVal iArr As String, ByRef iStruct As Object, ByVal iDilimChar As Char, ByVal inum As Int16) As Object
        Dim tLine() As String = iArr.Split(iDilimChar)
        Dim i As Short = inum
        Dim tStruct As ValueType = iStruct
        Dim fields As FieldInfo() = tStruct.[GetType]().GetFields(BindingFlags.Instance Or BindingFlags.[Public])
        For Each field As FieldInfo In fields

            If i < tLine.Length - 1 Then
                tStruct = StructSetValue(tStruct, field.Name, tLine(i))
            Else
                Exit For
            End If
            i += 1
        Next
        Return tStruct
    End Function

    Private Sub SaveParam()
        Dim jElem As String = ""
        Dim ii As Int16 = 1
        For i As Integer = 0 To DataGridView1.RowCount - 2
            For item As Int16 = 1 To DataGridView1.ColumnCount - 1
                If ii >= Num Then
                    Exit For
                End If
                jElem += Convert.ToString(DataGridView1.Rows(i).Cells(item).Value) + "^"
                ii = ii + 1
            Next
        Next
    End Sub


    Private Sub TreeView2_NodeMouseClick(sender As System.Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView2.NodeMouseClick
        Select Case e.Node.Text
            Case "AxisMotionParam"
                showData("AxisMotionParam", AxisParam, 11)
        End Select
    End Sub

    Private Sub TreeView3_NodeMouseClick(sender As System.Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView3.NodeMouseClick
        Select Case e.Node.Text
            Case "参数"
                TabControl1.Visible = True
            Case "系统参数"
                TabControl1.SelectedIndex = 0
            Case "膜参数"
                TabControl1.SelectedIndex = 1
            Case "相机参数"
                TabControl1.SelectedIndex = 2
        End Select
    End Sub

    Private Sub Explorer1_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        datagridv = DataGridView1
    End Sub
End Class
