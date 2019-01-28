Public Class AxisNoConfig
    ''错误代码 404001~404050
    Private PathS As String = My.Application.Info.DirectoryPath
    Private Path As String = PathS.Substring(0, PathS.LastIndexOf("\")) & "\Config\"
    Public CardCount As Int16
    Public List() As _PNode
    Public NameStr As New ArrayList
    Public RelsetList As New ArrayList
    Public CarNewList As New ArrayList '配置好的数据
    Public RestList As New ArrayList '轴数组
    Public SubList As New ArrayList '没有配置的轴
    Private Count As Int16 '有多少要配置的轴
    Private CardNE As Int16 = 4
    Private CardStrName As String

    Public Structure _PNode
        Public cardNum As String
        Public AxisName As String
        Public AxisNum As Byte
        Public IsUse As Boolean
    End Structure

    Public Structure _CardType
        Public cardNum As String
        Public name As String
        Public num As Byte
        Public Sub Save(ByVal Path As String, ByVal lpSectionName As String)
            Try
                Path = Path & ".txt"
                WriteP(lpSectionName, "cardNum", cardNum, Path)
                WriteP(lpSectionName, "name", name, Path)
                WriteP(lpSectionName, "num", num, Path)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub load(ByVal Path As String, ByVal lpSectionName As String)
            Try
                Path = Path & ".txt"
                cardNum = CInt(ReadP("cardNum", 0, Path, lpSectionName))
                name = CSng(ReadP("name", 0, Path, lpSectionName))
                num = CSng(ReadP("num", 0, Path, lpSectionName))
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Structure
    Private New_CardType As _CardType
    Public Sub LoadAxiaN(ByVal Path As String, ByVal lpSectionName As String)
        Try
            PathS = Path & "AxisName" & ".mtq"
            Dim Str As IO.StreamReader = New IO.StreamReader(PathS)
            Str.ReadLine()
            New_CardType.cardNum = Str.ReadLine()
            CardStrName = New_CardType.cardNum.Substring(New_CardType.cardNum.LastIndexOf("=") + 1, New_CardType.cardNum.Length - New_CardType.cardNum.LastIndexOf("=") - 1)
            CardText.Text = CardStrName
            Dim CardCountStr As String = Str.ReadLine()

            CardCount = CInt(CardCountStr.Substring(CardCountStr.LastIndexOf("=") + 1, CardCountStr.Length - CardCountStr.LastIndexOf("=") - 1))
            Dim CountStr As String = Str.ReadLine()
            Count = CInt(CountStr.Substring(CountStr.LastIndexOf("=") + 1, CountStr.Length - CountStr.LastIndexOf("=") - 1))
            CardNumTxt.Text = CardCount
            For i As Int16 = 0 To Count - 1
                New_CardType.name = Str.ReadLine()
                RestList.Add(New_CardType.name) '轴名称的数组
            Next
            Str.Close()
            Str.Dispose()
            Select Case CardStrName
                Case "5600"
                    CardNE = 6
                Case "2410"
                    CardNE = 4
                Case "5400"
                    CardNE = 4
                Case "5800"
                    CardNE = 8
                Case "DFQ601"
                    CardNE = 6
            End Select
            Dim PathSS As String = Path & "AxisParam" & ".mtq"
            For j As Int16 = 0 To RestList.Count - 1
                Dim New_CardT As _PNode
                Dim RestListStr As String = RestList(j)
                Dim ReadName As String = (ReadP("name", 0, PathSS, RestListStr))
                If ReadName = RestListStr Then
                    New_CardT.cardNum = (ReadP("cardNum", 0, PathSS, RestListStr))
                    New_CardT.AxisName = ReadName
                    New_CardT.AxisNum = (ReadP("num", 0, PathSS, RestListStr))
                    New_CardT.IsUse = True
                    CarNewList.Add(New_CardT) '配置的轴数组
                Else
                    SubList.Add(RestListStr)
                End If
            Next
        Catch ex As Exception
            Throw New Exception()
        End Try
    End Sub
    Private Sub ExitForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitForm.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub AxisNoConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadAxiaN(Path, "Mation")
            NameGridDis() '显示没有配置的轴名称
            ConfigerDis() '显示配置的轴
            NoGridDis() '显示没有配置的轴号
            My.Settings.Language = Language
            'ReLoadForm()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' 显示NameGrid没有配置的轴
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NameGridDis()
        Try
            NameGrid.Rows.Clear()
            If SubList.Count > 0 Then
                For i As Int16 = 0 To SubList.Count - 1
                    Dim NameGridStr As String = SubList(i)
                    NameGrid.Rows.Add(NameGridStr)
                Next
            End If
        Catch ex As Exception
            Throw New Exception("404001;" & XX更新轴名称表格错误)
        End Try

    End Sub
    ''' <summary>
    ''' 显示Configer已经配置的轴
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConfigerDis()
        Try
            Configer.Rows.Clear()
            If CarNewList.Count > 0 Then
                For i As Int16 = 0 To CarNewList.Count - 1
                    Dim CarNewListValue As _PNode = CarNewList(i)
                    Configer.Rows.Add()
                    Configer.Item(0, i).Value = CarNewListValue.cardNum
                    Configer.Item(1, i).Value = CarNewListValue.AxisName
                    Configer.Item(2, i).Value = CarNewListValue.AxisNum
                Next
            End If
        Catch ex As Exception
            Throw New Exception("404002;" & XX更新轴对应关系表格错误)
        End Try
    End Sub

    Private OVerNoAxiaStr As New ArrayList
    Private NoAxiaStr As New ArrayList
    ''' <summary>
    ''' 显示没有配置的轴号NoGrid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NoGridDis()
        Try
            NoGrid.Rows.Clear()
            Dim NoAxia As Int16 = CardCount * CardNE
            If CarNewList.Count = 0 Then
                For i As Int16 = 0 To NoAxia - 1
                    NoAxiaStr.Add(CShort(i))
                Next
            End If
            If CarNewList.Count > 0 Then
                For i As Int16 = 0 To NoAxia - 1
                    NoAxiaStr.Add(i)
                Next
                For j As Int16 = 0 To CarNewList.Count - 1
                    Dim CarStr As _PNode = CarNewList(j)
                    Dim uu As String = CarStr.AxisNum
                    OVerNoAxiaStr.Add(uu)
                Next
                For k As Int16 = 0 To OVerNoAxiaStr.Count - 1
                    Dim remove As Int16 = CInt(OVerNoAxiaStr(k))
                    NoAxiaStr.Remove(remove)
                Next
                For h As Int16 = 0 To NoAxiaStr.Count - 1
                    Dim yu As String = NoAxiaStr(h)
                    NoGrid.Rows.Add(yu)
                Next
            Else
                For h As Int16 = 0 To NoAxiaStr.Count - 1
                    Dim yu As String = NoAxiaStr(h)
                    NoGrid.Rows.Add(yu)
                Next
            End If
        Catch ex As Exception
            Throw New Exception("404003;" & XX更新轴号表格错误)
        End Try

    End Sub
    ''' <summary>
    ''' 显示NoGrid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NoGridSub()
        Try
            NoGrid.Rows.Clear()
            For h As Int16 = 0 To NoAxiaStr.Count - 1
                Dim yu As String = NoAxiaStr(h)
                NoGrid.Rows.Add(yu)
            Next
        Catch ex As Exception
            Throw New Exception("404004;" & XX更新轴号表格错误)
        End Try
    End Sub
    ''' <summary>
    ''' 添加/删除CarNewList
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CarNewListChange()
        Try
            Dim Peizhihao As _PNode
            Peizhihao.cardNum = CardText.Text
            Peizhihao.AxisName = SubListf
            Peizhihao.AxisNum = PutNum
            Peizhihao.IsUse = True
            CarNewList.Add(Peizhihao)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub AddSubNoGrid()
        Try
            NoGrid.Rows.Clear()
            For i As Int16 = 0 To NoAxiaStr.Count - 1
                Dim yu As String = NoAxiaStr(i)
                NoGrid.Rows.Add(yu)
            Next
        Catch ex As Exception
            Throw New Exception("404006;" & XX更新轴号表格错误)
        End Try
    End Sub
    Private SubListf As String
    Private PutNum As String
    ''' <summary>
    ''' 确定配对
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            If NameGrid.Rows.Count = 0 Then
                MsgBox(XX没有要配置的轴)
                Exit Sub
            End If
            If NoGrid.Rows.Count = 0 Then
                MsgBox(XX没有要配置的轴号)
                Exit Sub
            End If
            SubListf = NameGrid.CurrentCell.Value
            PutNum = NoGrid.CurrentCell.Value
            If SubList.Count > 0 Then
                SubList.Remove(SubListf)
            Else
                MsgBox(XX没有要配置的轴)
                Exit Sub
            End If
            If NoAxiaStr.Count > 0 Then
                NoAxiaStr.Remove(CShort(PutNum))
            Else
                MsgBox(XX没有要配置的轴号)
                Exit Sub
            End If
            NameGridDis()
            CarNewListChange()
            AddSubNoGrid()
            ConfigerDis()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' 添加要配置的轴名字
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AddName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddName.Click
        Try
            Dim AddStrN As String = InputBox("要添加的轴名称")
            If AddStrN = Nothing Then
                Exit Sub
            Else
                NameGrid.Rows.Add(AddStrN)
                SubList.Add(AddStrN)
                RestList.Add(AddStrN)
                Count = Count + 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' 删除要配置的轴名字
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DelName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelName.Click
        Try
            If NameGrid.Rows.Count = 0 Then
                MsgBox(XX没有要删除的轴)
                Exit Sub
            End If
            Dim SubListfs As String = NameGrid.CurrentCell.Value
            Dim SubListfInt As Int16 = NameGrid.CurrentRow.Index
            Dim PutNums As String = NoGrid.CurrentCell.Value
            NameGrid.Rows.RemoveAt(SubListfInt)
            SubList.Remove(SubListfs)
            RestList.Remove(SubListfs)
            Count = Count - 1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' 删除已经配置好的轴配置
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Configer.Rows.Count = 0 Then
                MsgBox(XX没有要删除的配置)
                Exit Sub
            End If
            Dim SubArrlist As _PNode
            SubArrlist.cardNum = Configer.Item(0, Me.Configer.CurrentCell.RowIndex).Value
            SubArrlist.AxisName = Configer.Item(1, Me.Configer.CurrentCell.RowIndex).Value
            SubArrlist.AxisNum = Configer.Item(2, Me.Configer.CurrentCell.RowIndex).Value
            SubArrlist.IsUse = True
            Configer.Rows.RemoveAt(Me.Configer.CurrentCell.RowIndex)
            SubList.Add(SubArrlist.AxisName)
            CarNewList.Remove(SubArrlist)
            NameGridDis()
            NoAxiaStr.Add(CShort(SubArrlist.AxisNum))
            OVerNoAxiaStr.Remove((CStr(SubArrlist.AxisNum)))
            NoGridSub()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' 保存数据
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SaveAxiapeizhi(Path)
    End Sub
    Private Sub SaveAxiapeizhi(ByVal path As String)
        Try
            If Configer.Rows.Count = 0 Then
                MsgBox(XX没有要保存的数据_请检查数据)
                Exit Sub
            End If
            Dim paths As String = path & "AxisParam" & ".mtq"
            If System.IO.File.Exists(paths) Then
                IO.File.Delete(paths)
            End If
            For i As Int16 = 0 To CarNewList.Count - 1
                Dim _PNodeSave As _PNode = CarNewList(i)
                WriteP(_PNodeSave.AxisName, "cardNum", _PNodeSave.cardNum, paths)
                WriteP(_PNodeSave.AxisName, "name", _PNodeSave.AxisName, paths)
                WriteP(_PNodeSave.AxisName, "num", _PNodeSave.AxisNum, paths)
            Next
            Dim pathss As String = path & "AxisName" & ".mtq"
            If System.IO.File.Exists(pathss) Then
                IO.File.Delete(pathss)
            End If
            Dim str As IO.StreamWriter = New IO.StreamWriter(pathss)
            Try
                str.WriteLine("[Mation]")
                str.WriteLine("CardType" & "=" & CardStrName)
                str.WriteLine("CardCount" & "=" & CardCount)
                str.WriteLine("AxisCount" & "=" & CStr(Count))
                For j As Int16 = 0 To RestList.Count - 1
                    Dim Axian As String = RestList(j)
                    str.WriteLine(Axian)
                Next
            Catch ex As Exception
                str.Close()
                str.Dispose()
                Throw New Exception("404006;" & XX更新保存轴关系表错误_请重新配置 & Chr(13) & ex.Message)
            End Try
            str.Close()
            str.Dispose()
        Catch ex As Exception
            Throw New Exception("404007;" & XX更新保存轴关系表错误_请重新配置 & Chr(13) & ex.Message)
        End Try
         
    End Sub
   
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If Me.Configer.Rows.Count = 0 Then
    '        Exit Sub
    '    End If
    '    Dim name As String = Me.Configer.Item(2, Me.Configer.CurrentCell.RowIndex).Value
    '    Dim num As String = Me.Configer.Item(3, Me.Configer.CurrentCell.RowIndex).Value
    '    For i As Int16 = 0 To NameStr.Count - 1
    '        Dim Node As _PNode = NameStr(i)
    '        If Node.AxisName = name Then
    '            Node.IsUse = False
    '            NameStr(i) = Node
    '        End If
    '    Next
    '    For i As Int16 = 0 To List.Length - 1
    '        Dim Node As _PNode = List(i)
    '        If Node.AxisName = num & "轴" Then
    '            List(i).IsUse = False
    '        End If
    '    Next
    '    For i As Int16 = 0 To RelsetList.Count - 1
    '        Dim cardtype As _CardType = RelsetList(i)
    '        If cardtype.num = num Then
    '            RelsetList.RemoveAt(i)
    '            Exit For
    '        End If
    '    Next
    '    CardGridUpData()
    '    NoGridUpData()
    '    NameGridUpData()
    'End Sub
    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    'Dim save As New Windows.Forms.SaveFileDialog
    'Dim mpath As String
    'If save.ShowDialog = Windows.Forms.DialogResult.OK Then
    '    mpath = save.FileName
    '    For i As Int16 = 0 To RelsetList.Count - 1
    '        Dim mtype As _CardType = RelsetList(i)
    '        mtype.Save(mpath, mtype.name)
    '    Next
    'End If
    'End Sub
    'Private Sub ReLoadForm()
    '    Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(My.Settings.Language)
    '    ' Dim s As String = My.Resources.停止
    '    Me.GroupBox1.Text = My.Resources.卡类型
    '    Me.GroupBox2.Text = My.Resources.卡数量
    '    Me.Label1.Text = My.Resources.张
    '    Me.Label4.Text = My.Resources.对应关系
    '    Me.NameGrid.Columns(0).HeaderText = My.Resources.轴名称
    '    Me.NoGrid.Columns(0).HeaderText = My.Resources.轴号
    '    Me.OK.Text = My.Resources.确定
    '    Me.AddName.Text = My.Resources.添加
    '    Me.DelName.Text = My.Resources.删除轴名称
    '    Me.Button1.Text = My.Resources.删除配置结果
    '    Me.Button2.Text = My.Resources.保存
    '    Me.ExitForm.Text = My.Resources.退出
    '    Me.Configer.Columns(0).HeaderText = My.Resources.型号
    '    Me.Configer.Columns(1).HeaderText = My.Resources.名称
    '    Me.Configer.Columns(2).HeaderText = My.Resources.轴号
    'End Sub


End Class