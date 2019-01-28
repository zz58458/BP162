Public Class IOForm
    Private mList As New ArrayList '保存字符串类型
    Private List() As IOType  '可用的InIO
    Private ListOut() As OutIOType
    Private Shared Node As New ArrayList '保存配置好的节点
    Private mType As String
    Public IO As New ArrayList
    Private IOSenderBase As BaseFunction
    Public CardType As String
    ''' <summary>
    ''' IO点
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure IOType
        Public InPut As String
        Public IsUsed As Boolean
        Public CardN As String
    End Structure


    ''' <summary>
    ''' OutIO点
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure OutIOType
        Public OutPut As String
        Public OutIsUsed As Boolean
        Public CardN As String
    End Structure
    ''' <summary>
    ''' 配置节点
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure _PNode
        Public Name As String
        Public IO_Node As String
    End Structure



    ''' <summary>
    ''' IO点个数
    ''' </summary>
    ''' <param name="Count">IO点个数</param>
    ''' <remarks></remarks>
    Public Sub ListInputCom(ByVal Count As Integer, ByVal CardNumb As Int16, ByVal Count1 As Integer, ByVal CardNupb1 As Int16)
        Try
            Dim cout As Integer = Count * (CardNumb) + Count1 * CardNupb1
            Dim Start_Num As Short
            Dim Stop_Num As Short
            Select Case CardType
                Case "5600", "5800"
                    Start_Num = 0
                    Stop_Num = Count - 1
                    ReDim List(cout - 1)
                Case Else
                    Start_Num = 1
                    Stop_Num = Count
                    ReDim List(cout)
            End Select

            For j As Int16 = 0 To CardNumb + CardNupb1 - 1
                Select Case CardType
                    Case "5600", "5800"
                        Start_Num = 0
                        Stop_Num = Count - 1

                    Case Else
                        If j = CardNumb + CardNupb1 - 1 Then
                            Start_Num = 1
                            Stop_Num = Count1
                        Else
                            Start_Num = 1
                            Stop_Num = Count
                        End If
                End Select
                For i As Int16 = Start_Num To Stop_Num
                    Dim IOTP As IOType
                    IOTP.InPut = i.ToString
                    IOTP.CardN = CStr(j)
                    For k As Int16 = 0 To InputRString.Count - 1
                        Dim Node As InPutStrc = InputRString(k)
                        If (IOTP.InPut = Node.InputNum) And (IOTP.CardN = Node.InCardput) Then
                            IOTP.IsUsed = True
                            Exit For
                        Else
                            IOTP.IsUsed = False
                        End If
                    Next
                    Dim L As Int16 = j * Count
                    List(L + i) = IOTP
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ListOutPutCom(ByVal count As Integer, ByVal CardNumb As Int16, ByVal Count1 As Integer, ByVal CardNupb1 As Int16)
        Dim cout As Integer = count * (CardNumb) + Count1 * CardNupb1

        Dim Start_Num As Short
        Dim Stop_Num As Short
        Select Case CardType
            Case "5600", "5800"
                Start_Num = 0
                Stop_Num = count - 1
                ReDim ListOut(cout - 1)
            Case Else
                Start_Num = 1
                Stop_Num = count
                ReDim ListOut(cout)
        End Select

        For j As Int16 = 0 To CardNumb + CardNupb1 - 1

            Select Case CardType
                Case "5600", "5800"
                    Start_Num = 0
                    Stop_Num = count - 1
                Case Else
                    If j = CardNumb + CardNupb1 - 1 Then
                        Start_Num = 1
                        Stop_Num = Count1
                    Else
                        Start_Num = 1
                        Stop_Num = count
                    End If
            End Select
            For i As Int16 = Start_Num To Stop_Num
                Dim IOTP As OutIOType
                IOTP.OutPut = i.ToString
                IOTP.CardN = CStr(j)
                For k As Int16 = 0 To OutPPutString.Count - 1
                    Dim uu As OutPutStrc = OutPPutString(k)
                    If (IOTP.OutPut = uu.OutputNum) And (IOTP.CardN = uu.OutCardput) Then
                        IOTP.OutIsUsed = True
                        Exit For
                    Else
                        IOTP.OutIsUsed = False
                    End If
                Next
                Dim L As Int16 = j * count
                ListOut(L + i) = IOTP
            Next
        Next

    End Sub
    Public Structure InPutStrc '输入结构
        Public InputNum As String
        Public InputName As String
        Public InputA As String
        Public InputB As String
        Public InCardput As String
    End Structure

    Public OutPutStrDY As OutPutStrc
    Public Structure OutPutStrc '输出结构
        Public OutputNum As String
        Public OutputName As String
        Public OutputA As String
        Public OutputB As String
        Public OutCardput As String
    End Structure


    Private InPutStrcing As InPutStrc
    Private OutPutSS As OutPutStrc
    Private InPutString As New ArrayList '原始文件里面读出来输入
    Private InputRString As New ArrayList '操作输入
    Private OutPutString As New ArrayList '原始文件里面读出来输出
    Private OutPPutString As New ArrayList '操作输出
    Private Sub IOForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CardType = ReadParam.GetCardType
            If CardType = "2410" Then
                IOSenderBase = New _2410Base
            ElseIf CardType = "5400" Then
                IOSenderBase = New _5400Base
            ElseIf CardType = "5600" Then
                IOSenderBase = New _5600Base
            ElseIf CardType = "5800" Then
                IOSenderBase = New _5800Base
            ElseIf CardType = "DFQ601" Then
                IOSenderBase = New _601Base
            End If

            '初始化卡放这里为了测试是否IO能读取
            '实际工程上不能放这里，因为初始化卡只能调用一次
            'Dim kk As Integer
            'kk = IOSenderBase.Init()

            LoadReadInPutS()
            DisPlayTypeGrid()
            Select Case CardType
                Case "5600", "5800"
                    ListInputCom(32, CardNumInComBox.Items.Count, 0, 0)
                Case Else

                    ListInputCom(20, CardNumInComBox.Items.Count - 1, 32, 1)
                   

            End Select

            IOGridViewChange()

            LoadReadOutPutS()
            DisPlayTypeGridOut()
            Select Case CardType
                Case "5600", "5800"
                    ListOutPutCom(32, CardNumInComBox.Items.Count, 0, 0)
                Case Else
                    ListOutPutCom(20, CardNumInComBox.Items.Count - 1, 32, 1)
            End Select

            OutIOGridViewChange()

            My.Settings.Language = Language
            'ReLoadForm()
        Catch ex As Exception

        End Try
    End Sub


    Private pathTH As String = My.Application.Info.DirectoryPath
    Private path As String = pathTH.Substring(0, pathTH.LastIndexOf("\")) & "\Config\OutParam.mtq"
    Private paths As String = pathTH.Substring(0, pathTH.LastIndexOf("\")) & "\Config\OutPParam.mtq"
    Private pathIN As String = pathTH.Substring(0, pathTH.LastIndexOf("\")) & "\Config\Param.mtq"
    Private pathINI As String = pathTH.Substring(0, pathTH.LastIndexOf("\")) & "\Config\PParam.mtq"

    Private Sub LoadReadOutPutS() '读出OutPutString
        If System.IO.File.Exists(path) Then
            Dim Count As Int16 = CInt(ReadP("Count", "0", path, "Count"))
            Dim OputStr As String = "Put"
            For i As Int16 = 1 To Count
                'OutPutSS.OutputNum = ReadP("OutPut", "0", path, OputStr & i)
                OutPutSS.OutputName = ReadP("Name", "0", path, OputStr & i)
                OutPutSS.OutputA = ReadP("ValA", "0", path, OputStr & i)
                OutPutSS.OutputB = ReadP("ValB", "0", path, OputStr & i)
                'OutPutSS.OutCardput = ReadP("Card", "0", path, OputStr & i)
                OutPutString.Add(OutPutSS)
            Next
        Else

        End If

        If System.IO.File.Exists(paths) Then
            Dim Countt As Int16 = CInt(ReadP("Count", "0", paths, "Count"))
            Dim OputStrr As String = "Put"
            For i As Int16 = 1 To Countt
                OutPutSS.OutputNum = ReadP("OutPut", "0", paths, OputStrr & i)
                OutPutSS.OutputName = ReadP("Name", "0", paths, OputStrr & i)
                OutPutSS.OutputA = ReadP("ValA", "0", paths, OputStrr & i)
                OutPutSS.OutputB = ReadP("ValB", "0", paths, OputStrr & i)
                OutPutSS.OutCardput = ReadP("Card", "0", paths, OputStrr & i)
                Dim Ob As System.Windows.Forms.DataGridViewComboBoxCell
                'Dim Oc As System.Windows.Forms.DataGridViewComboBoxCell
                Me.CongOutIO.Rows.Add()
                Me.CongOutIO.Item(0, i - 1).Value = OutPutSS.OutputName
                Me.CongOutIO.Item(1, i - 1).Value = OutPutSS.OutCardput
                Me.CongOutIO.Item(2, i - 1).Value = OutPutSS.OutputNum
                Ob = CongOutIO.Item(3, i - 1)
                'Oc = CongOutIO.Item(4, i - 1)
                Ob.Value = Nothing
                'Oc.Value = Nothing
                Ob.Items.Add(OutPutSS.OutputA)
                Ob.Items.Add(OutPutSS.OutputB)
                'Oc.Items.Add(OutPutSS.OutputA)
                'Oc.Items.Add(OutPutSS.OutputB)
                Ob.Value = OutPutSS.OutputA
                'Oc.Value = OutPutSS.OutputB
                OutPPutString.Add(OutPutSS)

                If ReadNowOutIO(CShort(OutPutSS.OutCardput), CShort(OutPutSS.OutputNum)) Then
                    Ob.Value = OutPutSS.OutputA
                Else
                    Ob.Value = OutPutSS.OutputB
                End If
            Next
        End If

    End Sub

    Private Sub LoadReadInPutS() '读出InPutString

        If System.IO.File.Exists(pathIN) Then
            Dim Count As Int16 = CInt(ReadP("Count", "0", pathIN, "Count"))
            Dim IputStr As String = "Put"
            For i As Int16 = 1 To Count
                InPutStrcing.InputName = ReadP("Name", "0", pathIN, IputStr & i)
                InPutStrcing.InputA = ReadP("ValA", "0", pathIN, IputStr & i)
                InPutStrcing.InputB = ReadP("ValB", "0", pathIN, IputStr & i)
                InPutString.Add(InPutStrcing)
            Next
        Else
            MsgBox("404031;" & XX没有要读取的文件)
            Exit Sub
        End If

        If System.IO.File.Exists(pathINI) Then
            Dim Countt As Int16 = CInt(ReadP("Count", "0", pathINI, "Count"))
            Dim IputStrr As String = "Put"
            For i As Int16 = 1 To Countt
                InPutStrcing.InputNum = ReadP("InPut", "0", pathINI, IputStrr & i)
                InPutStrcing.InputName = ReadP("Name", "0", pathINI, IputStrr & i)
                InPutStrcing.InputA = ReadP("ValA", "0", pathINI, IputStrr & i)
                InPutStrcing.InputB = ReadP("ValB", "0", pathINI, IputStrr & i)
                InPutStrcing.InCardput = ReadP("Card", "0", pathINI, IputStrr & i)
                Dim Ob As System.Windows.Forms.DataGridViewComboBoxCell
                'Dim Oc As System.Windows.Forms.DataGridViewComboBoxCell
                Me.Configer.Rows.Add()
                Me.Configer.Item(0, i - 1).Value = InPutStrcing.InputName
                Me.Configer.Item(1, i - 1).Value = InPutStrcing.InCardput
                Me.Configer.Item(2, i - 1).Value = InPutStrcing.InputNum
                Ob = Configer.Item(3, i - 1)
                'Oc = Configer.Item(4, i - 1)
                Ob.Value = Nothing

                Ob.Items.Add(InPutStrcing.InputA)
                Ob.Items.Add(InPutStrcing.InputB)
                Ob.Value = InPutStrcing.InputA
                'Oc.Value = InPutStrcing.InputB
                InputRString.Add(InPutStrcing)

                If ReadNowInIO(CShort(InPutStrcing.InCardput), CShort(InPutStrcing.InputNum)) Then
                    Ob.Value = InPutStrcing.InputA
                Else
                    Ob.Value = InPutStrcing.InputB
                End If
            Next
        Else '要补充

        End If

    End Sub


    Private Sub DisPlayTypeGrid() '显示输入没有定义IO名字
        TypeGrid.Rows.Clear()
        Dim AddF As Boolean = False
        For i As Int16 = 0 To InPutString.Count - 1
            Dim InPutS As InPutStrc = InPutString(i)
            For j As Int16 = 0 To InputRString.Count - 1
                Dim InputR As InPutStrc = InputRString(j)
                If InPutS.InputName = InputR.InputName Then
                    AddF = True
                    Exit For
                Else
                    AddF = False
                End If
            Next
            If AddF = False Then
                TypeGrid.Rows.Add(InPutS.InputName)
            End If
        Next
    End Sub

    Private Sub DisPlayTypeGridOut() '显示输出没有定义IO名字
        TypeGridOut.Rows.Clear()
        Dim AddF As Boolean = False
        For i As Int16 = 0 To OutPutString.Count - 1
            Dim OutPutS As OutPutStrc = OutPutString(i)
            For j As Int16 = 0 To OutPPutString.Count - 1
                Dim OutPutR As OutPutStrc = OutPPutString(j)
                If OutPutR.OutputName = OutPutS.OutputName Then
                    AddF = True
                    Exit For
                Else
                    AddF = False
                End If
            Next
            If AddF = False Then
                TypeGridOut.Rows.Add(OutPutS.OutputName)
            End If
        Next
    End Sub

    Private Sub OutOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutOK.Click
        Dim Name As String
        If TypeGridOut.Rows.Count = 0 Then
            MsgBox("404032;" & XX没有要配置的点)
            Exit Sub
        End If
        If Me.OutIOGridView.Rows.Count = 0 Then
            MsgBox("404033;" & XX是否有对应的IO点)
            Exit Sub
        Else
            Name = Me.OutIOGridView.CurrentCell.Value
        End If
        mType = Me.TypeGridOut.CurrentCell.Value
        Dim putName As String = Me.OutIOGridView.CurrentCell.Value
      
        For j As Int16 = 0 To OutPPutString.Count - 1
            OutPutSS = OutPPutString(j)
            If mType = OutPutSS.OutputName Then
                MsgBox("404034;" & XX已经配置完成)
                Exit Sub
            End If
        Next
        Dim start_num As Short
        Dim stop_num As Short
        Select Case CardType
            Case "5600", "5800"
                start_num = 0
                stop_num = ListOut.Length - 1
            Case Else
                start_num = 1
                stop_num = ListOut.Length
        End Select
        For i As Int16 = start_num To stop_num
            If ListOut(i).OutPut = putName And ListOut(i).CardN = CardNumInComBox.Text Then
                ListOut(i).OutIsUsed = True
                'Dim Pnode As _PNode
                'Pnode.Name = mType
                'Pnode.IO_Node = Name
                'Node.Add(Pnode)
                Exit For
            End If
        Next

        'mList.Add(Me.TypeGrid.CurrentCell.Value)
        TypeGridOut_CellClick(Nothing, Nothing)
        OutUpDataAdd()
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        If Me.TypeGrid.Rows.Count = 0 Then
            MsgBox("404035;" & XX没有要配置的点)
            Exit Sub
        End If
        If Me.IOGridView.Rows.Count = 0 Then
            MsgBox("404036;" & XX是否有对应的IO点)
            Exit Sub
        End If
        Dim putName As String = Me.IOGridView.CurrentCell.Value
        Dim PutNum As String = TypeGrid.CurrentCell.Value
        mType = Me.TypeGrid.CurrentCell.Value
        For j As Int16 = 0 To InputRString.Count - 1
            InPutStrcing = InputRString(j)
            If mType = InPutStrcing.InputName Then
                MsgBox("404037;" & XX已经配置完成)
                Exit Sub
            End If
        Next

        Dim start_num As Short
        Dim Stop_num As Short
        Select Case CardType
            Case "5600", "5800"
                start_num = 0
                Stop_num = List.Length - 1
            Case Else
                start_num = 1
                Stop_num = List.Length
        End Select
        For i As Int16 = start_num To Stop_num
            If List(i).InPut = putName And List(i).CardN = CardNumInComBox.Text Then

                List(i).IsUsed = True
                'Dim Pnode As _PNode
                'Pnode.Name = mType
                'Pnode.IO_Node = Name
                'Node.Add(Pnode)
                Exit For
            End If
        Next

        mList.Add(Me.TypeGrid.CurrentCell.Value)
        TypeGrid_CellClick(Nothing, Nothing)
        UpDataAdd()
    End Sub

    Private OutIOGVCurrCell As String
    Private Sub TypeGridOut_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TypeGridOut.CellClick '输出事件
        OutIOGridViewChange()
    End Sub
    Private Sub OutIOGridViewChange()
        If ListOut Is Nothing Then
            Exit Sub
        End If
        If OutIOGridView.Rows.Count <> 0 Then
            If Me.OutIOGridView.CurrentCell Is Nothing Then
                Exit Sub
            End If
            OutIOGVCurrCell = Me.OutIOGridView.CurrentCell.Value
        End If
        Me.OutIOGridView.Rows.Clear()
        Dim Card_num As Short = CardNumInComBox.Text
        Dim Start_num As Short
        Dim Stop_num As Short

        Select Case CardType
            Case "5600", "5800"
                Start_num = Card_num * 32
                Stop_num = (Card_num + 1) * 32 - 1
            Case Else
                If Card_num < 3 Then
                    Start_num = Card_num * 20 + 1
                    Stop_num = (Card_num + 1) * 20
                Else
                    Start_num = (Card_num) * 20 + 1
                    Stop_num = (Card_num) * 20 + 32
                End If
        End Select
        For i As Int16 = Start_num To Stop_num
            Dim myIO As OutIOType = ListOut(i)
            If myIO.OutIsUsed Then
                Continue For
            End If
            Me.OutIOGridView.Rows.Add(ListOut(i).OutPut)
        Next

    End Sub


    Private IOGVCurrCell As String
    Private Sub TypeGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TypeGrid.CellClick
        IOGridViewChange()
    End Sub


    Private Sub IOGridViewChange()
        If List Is Nothing Then
            Exit Sub
        End If
        If IOGridView.Rows.Count <> 0 Then
            IOGVCurrCell = Me.IOGridView.CurrentCell.Value
        End If
        Me.IOGridView.Rows.Clear()
        Dim Card_num As Short = CardNumInComBox.Text
        Dim Start_num As Short
        Dim Stop_num As Short

        Select Case CardType
            Case "5600", "5800"
                Start_num = Card_num * 32
                Stop_num = (Card_num + 1) * 32 - 1
            Case Else
                If Card_num < 3 Then
                    Start_num = Card_num * 20 + 1
                    Stop_num = (Card_num + 1) * 20
                Else
                    Start_num = (Card_num) * 20 + 1
                    Stop_num = (Card_num) * 20 + 32
                End If

        End Select
        For i As Int16 = Start_num To Stop_num
            Dim myIO As IOType = List(i)
            If myIO.IsUsed Then
                Continue For
            End If
            Me.IOGridView.Rows.Add(List(i).InPut)
        Next
    End Sub

    Private Sub DelOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelOut.Click '输出删除
        Dim Ob As System.Windows.Forms.DataGridViewComboBoxCell
        Dim mNode As OutPutStrc
        Dim NewList As New ArrayList
        Dim NewStr As New ArrayList
        If Me.CongOutIO.Rows.Count = 0 Then
            MsgBox("404038;" & XX没有要配置的点)
            Exit Sub
        Else
            mNode.OutputName = Me.CongOutIO.Item(0, Me.CongOutIO.CurrentCell.RowIndex).Value
            mNode.OutCardput = Me.CongOutIO.Item(1, Me.CongOutIO.CurrentCell.RowIndex).Value
            mNode.OutputNum = Me.CongOutIO.Item(2, Me.CongOutIO.CurrentCell.RowIndex).Value
            mNode.OutputA = Me.CongOutIO.Item(3, Me.CongOutIO.CurrentCell.RowIndex).Value
            Ob = CongOutIO.Item(3, Me.CongOutIO.CurrentCell.RowIndex)
            Dim InputBStr As String = Ob.Items.Item(1)
            If mNode.OutputA = Ob.Items.Item(0) Then
                InputBStr = Ob.Items.Item(1)
            Else
                InputBStr = Ob.Items.Item(0)
            End If
            mNode.OutputB = InputBStr

            'mNode.OutputB = Me.CongOutIO.Item(4, Me.CongOutIO.CurrentCell.RowIndex).Value

        End If
        Dim start_num As Short
        Dim stop_num As Short
        Select Case CardType
            Case "5600", "5800"
                start_num = 0
                stop_num = ListOut.Length - 1
            Case Else
                start_num = 1
                stop_num = ListOut.Length
        End Select
        For i As Int16 = start_num To stop_num '将ListOut里面OutIsUsed变为False那个加上去
            If (ListOut(i).OutPut = mNode.OutputNum) And (ListOut(i).CardN = mNode.OutCardput) Then
                If ListOut(i).OutIsUsed Then
                    ListOut(i).OutIsUsed = False
                End If
                Exit For
            End If
        Next




        'For j As Int16 = 0 To OutPPutString.Count - 1 '把OutPPutString干掉要删除的
        '    Dim OutputR As OutPutStrc = OutPPutString(j)
        '    If OutputR.OutputName = mNode.OutputName Then
        '        OutPPutString.RemoveAt(j)
        '        Exit For
        '    End If
        'Next




        OutPPutString.Clear()
        For h As Int16 = 0 To CongOutIO.Rows.Count - 1
            Dim OutputR As OutPutStrc
            OutputR.OutputName = CongOutIO.Item(0, h).Value
            OutputR.OutCardput = CongOutIO.Item(1, h).Value
            OutputR.OutputNum = CongOutIO.Item(2, h).Value
            OutputR.OutputA = CongOutIO.Item(3, h).Value

            Ob = CongOutIO.Item(3, h)

            If OutputR.OutputA = Ob.Items.Item(0) Then
                OutputR.OutputB = Ob.Items.Item(1)
            Else
                OutputR.OutputB = Ob.Items.Item(0)
            End If
 
            'OutputR.OutputB = CongOutIO.Item(4, h).Value
            OutPPutString.Add(OutputR)

        Next
        OutPPutString.Remove(mNode)






        Node.Clear()
        Node = NewList.Clone
        mList.Clear()
        'mList = NewStr.Clone
        Me.CongOutIO.Rows.Clear()
        TypeGridOut_CellClick(Nothing, Nothing)
        OutUpData()

    End Sub

    Private Sub Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Del.Click '输入删除
        Dim Oc As System.Windows.Forms.DataGridViewComboBoxCell
        Dim mNode As InPutStrc
        Dim NewList As New ArrayList
        Dim NewStr As New ArrayList
        If Me.Configer.Rows.Count = 0 Then
            MsgBox("404039;" & XX没有要删除的数据)
            Exit Sub
        Else
            mNode.InputName = Me.Configer.Item(0, Me.Configer.CurrentCell.RowIndex).Value
            mNode.InCardput = Me.Configer.Item(1, Me.Configer.CurrentCell.RowIndex).Value
            mNode.InputNum = Me.Configer.Item(2, Me.Configer.CurrentCell.RowIndex).Value
            mNode.InputA = Me.Configer.Item(3, Me.Configer.CurrentCell.RowIndex).Value
            Oc = Configer.Item(3, Me.Configer.CurrentCell.RowIndex)
            If mNode.InputA = Oc.Items.Item(0) Then
                mNode.InputB = Oc.Items.Item(1)
            Else
                mNode.InputB = Oc.Items.Item(0)
            End If
        End If
        Dim start_num As Short
        Dim Stop_num As Short
        Select Case CardType
            Case "5600", "5800"
                start_num = 0
                Stop_num = List.Length - 1
            Case Else
                start_num = 1
                Stop_num = List.Length
        End Select


        For i As Int16 = start_num To Stop_num '将List里面IsUsed变为False那个加上去
            If (List(i).InPut = mNode.InputNum) And (List(i).CardN = mNode.InCardput) Then
                If List(i).IsUsed Then
                    List(i).IsUsed = False
                End If
                Exit For
            End If
        Next

        InputRString.Clear()

        For h As Int16 = 0 To Configer.Rows.Count - 1
            Dim InputR As InPutStrc
            InputR.InputName = Configer.Item(0, h).Value
            InputR.InCardput = Configer.Item(1, h).Value
            InputR.InputNum = Configer.Item(2, h).Value
            InputR.InputA = Configer.Item(3, h).Value
            Oc = Configer.Item(3, h)
            If InputR.InputA = Oc.Items.Item(0) Then
                InputR.InputB = Oc.Items.Item(1)
            Else
                InputR.InputB = Oc.Items.Item(0)
            End If
            InputRString.Add(InputR)

        Next

        InputRString.Remove(mNode)



        'For j As Int16 = 0 To InputRString.Count - 1 '把InputRString干掉要删除的
        '    Dim InputR As InPutStrc = InputRString(j)
        '    If InputR.InputName = mNode.InputName Then
        '        InputRString.RemoveAt(j)
        '        Exit For
        '    End If
        'Next




        'Node.Clear()
        'Node = NewList.Clone
        'mList.Clear()
        'mList = NewStr.Clone
        Me.Configer.Rows.Clear()
        TypeGrid_CellClick(Nothing, Nothing)
        UpData()

    End Sub


    Public Sub OutUpData() '输出删除显示
        Dim Ob As System.Windows.Forms.DataGridViewComboBoxCell
        'Dim Oc As System.Windows.Forms.DataGridViewComboBoxCell
        For i As Int16 = 0 To OutPPutString.Count - 1
            Me.CongOutIO.Rows.Add()
            Dim yy As OutPutStrc = OutPPutString(i)
            CongOutIO.Item(0, i).Value = yy.OutputName
            CongOutIO.Item(1, i).Value = yy.OutCardput
            CongOutIO.Item(2, i).Value = yy.OutputNum
            Ob = CongOutIO.Item(3, i)
            'Oc = CongOutIO.Item(4, i)
            Ob.Value = Nothing
            'Oc.Value = Nothing
            Ob.Items.Add(yy.OutputA)
            Ob.Items.Add(yy.OutputB)
            'Oc.Items.Add(yy.OutputA)
            'Oc.Items.Add(yy.OutputB)
            Ob.Value = yy.OutputA
            'Oc.Value = yy.OutputB
        Next
        DisPlayTypeGridOut()
    End Sub





    Public Sub UpData() '输入删除显示
        Dim Ob As System.Windows.Forms.DataGridViewComboBoxCell
        'Dim Oc As System.Windows.Forms.DataGridViewComboBoxCell
        For i As Int16 = 0 To InputRString.Count - 1
            Me.Configer.Rows.Add()
            Dim yy As InPutStrc = InputRString(i)
            Configer.Item(0, i).Value = yy.InputName
            Configer.Item(1, i).Value = yy.InCardput
            Configer.Item(2, i).Value = yy.InputNum
            Ob = Configer.Item(3, i)
            'Oc = Configer.Item(4, i)
            Ob.Value = Nothing
            'Oc.Value = Nothing
            Ob.Items.Add(yy.InputA)
            Ob.Items.Add(yy.InputB)
            'Oc.Items.Add(yy.InputA)
            'Oc.Items.Add(yy.InputB)
            Ob.Value = yy.InputA
            'Oc.Value = yy.InputB
        Next
        DisPlayTypeGrid()
    End Sub


    Public Sub OutUpDataAdd() '输出显示
        Dim Ob As System.Windows.Forms.DataGridViewComboBoxCell
        'Dim Oc As System.Windows.Forms.DataGridViewComboBoxCell
        Dim mType As String = Me.TypeGridOut.CurrentCell.Value
        Me.CongOutIO.Rows.Add()
        Dim mIOGrid As String = OutIOGVCurrCell
        For i As Int16 = 0 To OutPutString.Count - 1

            Dim yy As OutPutStrc = OutPutString(i)
            If yy.OutputName = mType Then
                CongOutIO.Item(0, OutPPutString.Count).Value = yy.OutputName
                CongOutIO.Item(1, OutPPutString.Count).Value = CardNumInComBox.Text
                CongOutIO.Item(2, OutPPutString.Count).Value = mIOGrid
                Ob = CongOutIO.Item(3, OutPPutString.Count)
                'Oc = CongOutIO.Item(4, OutPPutString.Count)
                Ob.Value = Nothing
                'Oc.Value = Nothing
                Ob.Items.Add(yy.OutputA)
                Ob.Items.Add(yy.OutputB)
                'Oc.Items.Add(yy.OutputA)
                'Oc.Items.Add(yy.OutputB)
                Ob.Value = yy.OutputA
                'Oc.Value = yy.OutputB

                yy.OutputNum = mIOGrid
                yy.OutCardput = CardNumInComBox.Text

                OutPPutString.Add(yy)
            End If
        Next
        DisPlayTypeGridOut()
    End Sub

    Public Sub UpDataAdd() '输入显示
        Dim Ob As System.Windows.Forms.DataGridViewComboBoxCell
        'Dim Oc As System.Windows.Forms.DataGridViewComboBoxCell
        Me.Configer.Rows.Add()
        Dim mType As String = Me.TypeGrid.CurrentCell.Value
        Dim mIOGrid As String = IOGVCurrCell
        For i As Int16 = 0 To InPutString.Count - 1
            Dim yy As InPutStrc = InPutString(i)
            If yy.InputName = mType Then
                Configer.Item(0, InputRString.Count).Value = mType
                Configer.Item(1, InputRString.Count).Value = CardNumInComBox.Text
                Configer.Item(2, InputRString.Count).Value = mIOGrid
                Ob = Configer.Item(3, (InputRString.Count))
                'Oc = Configer.Item(4, (InputRString.Count))
                Ob.Value = Nothing
                'Oc.Value = Nothing
                Ob.Items.Add(yy.InputA)
                Ob.Items.Add(yy.InputB)
                'Oc.Items.Add(yy.InputA)
                'Oc.Items.Add(yy.InputB)
                Ob.Value = yy.InputA
                'Oc.Value = yy.InputB
                yy.InputNum = mIOGrid
                yy.InCardput = CardNumInComBox.Text
                InputRString.Add(yy)
            End If
        Next
        DisPlayTypeGrid()
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click

        Try
            Dim Count As Int16 = Configer.RowCount

            If Configer.Rows.Count = 0 Then
                MsgBox("404040;" & XX没有要保存的数据)
                Exit Sub
            End If
            Dim path As String = My.Application.Info.DirectoryPath
            path = path.Substring(0, path.LastIndexOf("\")) & "\Config\PParam.mtq"
            If System.IO.File.Exists(pathINI) Then
                System.IO.File.Delete(pathINI)
                Dim ChangeIn As Boolean = False
            End If

            WriteP("Count", "Count", Count, pathINI)

            Dim Ob As System.Windows.Forms.DataGridViewComboBoxCell
            Dim CutRuuStr As InPutStrc

            For i As Int16 = 0 To Count - 1
                Dim CumInt As Int16 = Configer.CurrentCell.RowIndex
                CutRuuStr.InputName = Configer.Item(0, i).Value
                CutRuuStr.InCardput = Configer.Item(1, i).Value
                CutRuuStr.InputNum = Configer.Item(2, i).Value
                CutRuuStr.InputA = Configer.Item(3, i).Value
                Ob = Configer.Item(3, i)

                If ReadNowInIO(CShort(CutRuuStr.InCardput), CShort(CutRuuStr.InputNum)) Then
                    CutRuuStr.InputA = Configer.Item(3, i).Value


                    If CutRuuStr.InputA = Ob.Items.Item(0) Then
                        CutRuuStr.InputB = Ob.Items.Item(1)
                    Else
                        CutRuuStr.InputB = Ob.Items.Item(0)
                    End If
                Else
                    CutRuuStr.InputB = Configer.Item(3, i).Value

                    If CutRuuStr.InputB = Ob.Items.Item(0) Then
                        CutRuuStr.InputA = Ob.Items.Item(1)
                    Else
                        CutRuuStr.InputA = Ob.Items.Item(0)
                    End If
                End If

                Dim IputStrr As String = "Put"
                WriteP(IputStrr & i + 1, "Name", CutRuuStr.InputName, path)
                WriteP(IputStrr & i + 1, "ValA", CutRuuStr.InputA, path)
                WriteP(IputStrr & i + 1, "ValB", CutRuuStr.InputB, path)
                WriteP(IputStrr & i + 1, "InPut", CutRuuStr.InputNum, path)
                WriteP(IputStrr & i + 1, "Card", CutRuuStr.InCardput, path)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveAll()
        If Configer.Rows.Count = 0 Then
            MsgBox("404041;" & XX没有要保存的数据)
            Exit Sub
        End If
        Dim path As String = My.Application.Info.DirectoryPath
        path = path.Substring(0, path.LastIndexOf("\")) & "\Config\PParam.mtq"
        If System.IO.File.Exists(path) Then
            System.IO.File.Delete(path)
        End If
        WriteP("Count", "Count", InputRString.Count, path)
        For i As Int16 = 0 To InputRString.Count - 1
            Dim yy As InPutStrc = InputRString(i)
            Dim myIO As New ClassIO
            myIO.StrInput.InUseName = yy.InputName
            myIO.StrInput.InPiontNameID = yy.InputNum
            myIO.StrInput.LowActivelevel = yy.InputA
            myIO.StrInput.HightActivelevel = yy.InputB
            myIO.StrInput.InCardNum = yy.InCardput
            myIO.StrInput.SaveIn(path, "Put" & i + 1)
        Next
    End Sub




    Private Sub SaveOutIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveOutIO.Click
        Dim Count As Int16 = CongOutIO.RowCount

        If CongOutIO.Rows.Count = 0 Then
            MsgBox("404042;" & XX没有要保存的数据)
            Exit Sub
        End If
        Dim path As String = My.Application.Info.DirectoryPath
        path = path.Substring(0, path.LastIndexOf("\")) & "\Config\OutPParam.mtq"
        If System.IO.File.Exists(path) Then
            System.IO.File.Delete(path)

        End If
        WriteP("Count", "Count", Count, path)
        For i As Int16 = 0 To Count - 1
            Dim Ob As System.Windows.Forms.DataGridViewComboBoxCell
            Dim CutRuuStr As OutPutStrc
            Dim CumInt As Int16 = CongOutIO.CurrentCell.RowIndex
            CutRuuStr.OutputName = CongOutIO.Item(0, i).Value
            CutRuuStr.OutCardput = CongOutIO.Item(1, i).Value
            CutRuuStr.OutputNum = CongOutIO.Item(2, i).Value
            CutRuuStr.OutputA = CongOutIO.Item(3, i).Value
            ' CutRuuStr.OutputB = CongOutIO.Item(4, CumInt).Value
            Ob = CongOutIO.Item(3, i)


            If ReadNowOutIO(CShort(CutRuuStr.OutCardput), CShort(CutRuuStr.OutputNum)) Then
                CutRuuStr.OutputA = CongOutIO.Item(3, i).Value

                If CutRuuStr.OutputA = Ob.Items.Item(0) Then
                    CutRuuStr.OutputB = Ob.Items.Item(1)
                Else
                    CutRuuStr.OutputB = Ob.Items.Item(0)
                End If
            Else
                CutRuuStr.OutputB = CongOutIO.Item(3, i).Value

                If CutRuuStr.OutputB = Ob.Items.Item(0) Then
                    CutRuuStr.OutputA = Ob.Items.Item(1)
                Else
                    CutRuuStr.OutputA = Ob.Items.Item(0)
                End If
            End If

           



            'If ReadNowOutIO(CShort(CutRuuStr.OutCardput), CShort(CutRuuStr.OutputNum)) Then
            '    Dim OutputStra As String = Ob.Items.Item(0)
            '    Dim OutputStrb As String = Ob.Items.Item(1)
            '    CutRuuStr.OutputA = OutputStra
            '    CutRuuStr.OutputB = OutputStrb
            'Else
            '    Dim OutputStra As String = Ob.Items.Item(0)
            '    Dim OutputStrb As String = Ob.Items.Item(1)
            '    CutRuuStr.OutputA = OutputStrb
            '    CutRuuStr.OutputB = OutputStra
            'End If
            Dim IputStrr As String = "Put"
            'OutPutStrDY.OutputNum = ReadP("OutPut", "0", path, IputStrr & i)
            WriteP(IputStrr & i + 1, "Name", CutRuuStr.OutputName, path)
            WriteP(IputStrr & i + 1, "OutPut", CutRuuStr.OutputNum, path)
            WriteP(IputStrr & i + 1, "ValA", CutRuuStr.OutputA, path)
            WriteP(IputStrr & i + 1, "ValB", CutRuuStr.OutputB, path)
            WriteP(IputStrr & i + 1, "Card", CutRuuStr.OutCardput, path)
        Next
        'SaveSingelOut(CutRuuStr)
    End Sub


    Private Sub SaveAllOut()
        If CongOutIO.Rows.Count = 0 Then
            MsgBox("404043;" & XX没有要保存的数据)
            Exit Sub
        End If

        Dim path As String = My.Application.Info.DirectoryPath
        path = path.Substring(0, path.LastIndexOf("\")) & "\Config\OutPParam.mtq"

        If System.IO.File.Exists(path) Then
            System.IO.File.Delete(path)
        End If

        WriteP("Count", "Count", OutPPutString.Count, path)
        For i As Int16 = 0 To OutPPutString.Count - 1
            Dim yy As OutPutStrc = OutPPutString(i)
            Dim myIO As New ClassIO
            myIO.StrOutput.OutUseName = yy.OutputName
            myIO.StrOutput.OutPiontNameID = yy.OutputNum
            myIO.StrOutput.OutActivelevel = yy.OutputA
            myIO.StrOutput.OutHightActivelevel = yy.OutputB
            myIO.StrOutput.OutCardNum = yy.OutCardput
            myIO.StrOutput.SaveOut(path, "Put" & i + 1)
        Next
    End Sub





    Private Sub CongOutIO_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CongOutIO.CellClick
        'Dim ReadOutBool As Boolean = IOSenderBase.ReadOutbit(CInt(CongOutIO.Item(1, Me.CongOutIO.CurrentCell.RowIndex).Value), CInt(CongOutIO.Item(2, Me.CongOutIO.CurrentCell.RowIndex).Value.ToString.Substring(6, 1)))
        'Try
        '    Dim OutID As String = CongOutIO.Item(2, Me.CongOutIO.CurrentCell.RowIndex).Value.ToString.Substring(6, 1)
        '    If ReadOutBool Then
        '        IOSenderBase.WriteOutbit(CInt(CongOutIO.Item(1, CongOutIO.CurrentCell.RowIndex).Value), CInt(OutID), 0)
        '    Else
        '        IOSenderBase.WriteOutbit(CInt(CongOutIO.Item(1, CongOutIO.CurrentCell.RowIndex).Value), CInt(OutID), 1)
        '    End If
        'Catch ex As Exception
        '    MsgBox("错误报警")
        'End Try
    End Sub



    Private Sub TimerReadInIO_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerReadInIO.Tick
        Try
            Dim ConfigerButton As System.Windows.Forms.DataGridViewButtonCell
            For i As Int16 = 0 To Configer.Rows.Count - 1
                Dim InputNum As Short = CShort(Configer.Item(2, i).Value)
                ConfigerButton = (Configer.Item(4, i))
                If IOSenderBase.ReadInbit(CInt(Configer.Item(1, i).Value), CInt(InputNum)) Then
                    ConfigerButton.Value = 高电平
                Else
                    ConfigerButton.Value = 低电平
                End If
            Next
            For j As Int16 = 0 To CongOutIO.Rows.Count - 1
                Dim OutputNum As Short = CShort(CongOutIO.Item(2, j).Value)
                ConfigerButton = (CongOutIO.Item(4, j))
                If IOSenderBase.ReadOutbit(CShort(CongOutIO.Item(1, j).Value), OutputNum) Then
                    ConfigerButton.Value = 高电平
                Else
                    ConfigerButton.Value = 低电平
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveInIO()
        Dim path As String = My.Application.Info.DirectoryPath
        path = path.Substring(0, path.LastIndexOf("\")) & "\Config\Param.mtq"
        If System.IO.File.Exists(path) Then
            System.IO.File.Delete(path)
        End If
        Dim CountStr As String = InPutString.Count
        Dim InputStr As String = "put"
        WriteP("Count", "Count", CountStr, path)
        For i As Int16 = 0 To InPutString.Count - 1
            Dim InPutSave As InPutStrc = InPutString(i)
            WriteP(InputStr & i + 1, "Name", InPutSave.InputName, path)
            WriteP(InputStr & i + 1, "ValA", InPutSave.InputA, path)
            WriteP(InputStr & i + 1, "ValB", InPutSave.InputB, path)
        Next
    End Sub


    Private InputAddStr As String
    Private Sub BtnAddInPut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddInPut.Click
        Try
            Dim AddInPutShow As New IOInputBox
            Dim AddInPutStr As InPutStrc = Nothing
            AddInPutShow.ShowDialog()
            If AddInPutShow.ObjectNameStr Is Nothing Or AddInPutShow.HightlevelIOStr Is Nothing Or AddInPutShow.LowlevelIOStr Is Nothing Then
                Exit Sub
            Else
                AddInPutStr.InputName = AddInPutShow.ObjectNameStr
                AddInPutStr.InputA = AddInPutShow.HightlevelIOStr
                AddInPutStr.InputB = AddInPutShow.LowlevelIOStr
                'AddInPutStr.InputNum = IOGridView.CurrentCell.Value
                'AddInPutStr.InCardput = CardNumInComBox.Text
                For i As Int16 = 0 To InPutString.Count - 1
                    Dim PutStr As InPutStrc = InPutString(i)
                    If PutStr.InputName = AddInPutStr.InputName Then
                        MsgBox("404045;" & XX与已经有的IO点有冲突)
                        Exit Sub
                    End If
                Next
                InPutString.Add(AddInPutStr)
                DisPlayTypeGrid()
                SaveInIO()

            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub SaveOutIOT()
        Dim path As String = My.Application.Info.DirectoryPath
        path = path.Substring(0, path.LastIndexOf("\")) & "\Config\OutParam.mtq"
        If System.IO.File.Exists(path) Then
            System.IO.File.Delete(path)
        End If
        Dim CountStr As String = OutPutString.Count
        Dim InputStr As String = "put"
        WriteP("Count", "Count", CountStr, path)
        For i As Int16 = 0 To OutPutString.Count - 1
            Dim InPutSave As OutPutStrc = OutPutString(i)
            WriteP(InputStr & i + 1, "Name", InPutSave.OutputName, path)
            WriteP(InputStr & i + 1, "ValA", InPutSave.OutputA, path)
            WriteP(InputStr & i + 1, "ValB", InPutSave.OutputB, path)
        Next
    End Sub

    Private Sub BtnAddOutPut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddOutPut.Click
        Try
            Dim AddInPutShow As New IOInputBox
            Dim AddInPutStr As OutPutStrc = Nothing
            AddInPutShow.ShowDialog()
            If AddInPutShow.ObjectNameStr Is Nothing Or AddInPutShow.HightlevelIOStr Is Nothing Or AddInPutShow.LowlevelIOStr Is Nothing Then
                Exit Sub
            Else
                AddInPutStr.OutputName = AddInPutShow.ObjectNameStr
                AddInPutStr.OutputA = AddInPutShow.HightlevelIOStr
                AddInPutStr.OutputB = AddInPutShow.LowlevelIOStr
                'AddInPutStr.OutputNum = OutIOGridView.CurrentCell.Value
                'AddInPutStr.OutCardput = CardNumInComBox.Text
                For i As Int16 = 0 To OutPutString.Count - 1
                    Dim PutStr As OutPutStrc = OutPutString(i)
                    If PutStr.OutputName = AddInPutStr.OutputName Then
                        MsgBox("404044;" & XX与已经有的IO点有冲突)
                        Exit Sub
                    End If
                Next
                OutPutString.Add(AddInPutStr)
                DisPlayTypeGridOut()
                SaveOutIOT()
            End If
        Catch ex As Exception

        End Try
    End Sub


    ''' <summary>
    ''' 读取通用输入
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ReadNowInIO(ByVal CadrN As Short, ByVal PutN As Short) As Boolean
        If IOSenderBase.ReadInbit(CadrN, PutN) Then
            Return True
        Else
            Return False
        End If
    End Function


    ''' <summary>
    ''' 读取通用输出
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ReadNowOutIO(ByVal CadrN As Short, ByVal PutN As Short) As Boolean

        If IOSenderBase.ReadOutbit(CadrN, PutN) Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub AddCard_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddCard_But.Click
        'Dim CountN As Int16 = CardNumInComBox.Items.Count
        'CardNumInComBox.Items.Add(CountN)
        'ListInputCom(20, CardNumInComBox.Items.Count)
        'ListOutPutCom(20, CardNumInComBox.Items.Count)
    End Sub

    Private Sub ExitFormIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFormIO.Click
        Me.Close()
        Me.Dispose()
    End Sub

    'Private Sub ReLoadForm()
    '    Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(My.Settings.Language)
    '    ' Dim s As String = My.Resources.停止
    '    Me.Label6.Text = My.Resources.卡号选择
    '    Me.AddCard_But.Text = My.Resources.添加卡
    '    Me.InIOoperate.Text = My.Resources.输入操作
    '    Me.IOGridView.Columns(0).HeaderText = My.Resources.可用输入
    '    Me.TypeGrid.Columns(0).HeaderText = My.Resources.类型选择

    '    Me.Configer.Columns(0).HeaderText = My.Resources.类型
    '    Me.Configer.Columns(1).HeaderText = My.Resources.卡号
    '    Me.Configer.Columns(2).HeaderText = My.Resources.使用IO点
    '    Me.Configer.Columns(3).HeaderText = My.Resources.状态
    '    Me.Configer.Columns(4).HeaderText = My.Resources.当前状态
    '    Me.OK.Text = My.Resources.确定
    '    Me.Del.Text = My.Resources.删除
    '    Me.Save.Text = My.Resources.保存
    '    Me.BtnAddInPut.Text = My.Resources.添加输入
    '    Me.ExitFormIO.Text = My.Resources.退出

    '    Me.OutIOoperate.Text = My.Resources.输出操作
    '    Me.TypeGridOut.Columns(0).HeaderText = My.Resources.类型选择
    '    Me.OutIOGridView.Columns(0).HeaderText = My.Resources.可用输出
    '    Me.OutOK.Text = My.Resources.确定
    '    Me.DelOut.Text = My.Resources.删除
    '    Me.SaveOutIO.Text = My.Resources.保存配置
    '    Me.BtnAddOutPut.Text = My.Resources.添加输出
    '    Me.CongOutIO.Columns(0).HeaderText = My.Resources.类型
    '    Me.CongOutIO.Columns(1).HeaderText = My.Resources.卡号
    '    Me.CongOutIO.Columns(2).HeaderText = My.Resources.使用IO点
    '    Me.CongOutIO.Columns(3).HeaderText = My.Resources.状态
    '    Me.CongOutIO.Columns(4).HeaderText = My.Resources.测试
    '    Me.Label2.Text = My.Resources.输出类型
    '    Me.Label3.Text = My.Resources.对应关系

    'End Sub

    Private Sub CardNumInComBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardNumInComBox.SelectedIndexChanged
        IOGridViewChange()
        OutIOGridViewChange()
    End Sub

    Private Sub CongOutIO_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CongOutIO.CellContentDoubleClick
        Dim ReadOutBool As Boolean = IOSenderBase.ReadOutbit(CInt(CongOutIO.Item(1, Me.CongOutIO.CurrentCell.RowIndex).Value), CInt(CongOutIO.Item(2, Me.CongOutIO.CurrentCell.RowIndex).Value))
        Try
            Dim OutID As String = CongOutIO.Item(2, Me.CongOutIO.CurrentCell.RowIndex).Value
            If ReadOutBool Then
                IOSenderBase.WriteOutbit(CInt(CongOutIO.Item(1, CongOutIO.CurrentCell.RowIndex).Value), CInt(OutID), 0)
            Else
                IOSenderBase.WriteOutbit(CInt(CongOutIO.Item(1, CongOutIO.CurrentCell.RowIndex).Value), CInt(OutID), 1)
            End If

            'Dim ReadOutBool As Boolean = IOSenderBase.ReadOutbit(CInt(CongOutIO.Item(1, Me.CongOutIO.CurrentCell.RowIndex).Value), CInt(CongOutIO.Item(2, Me.CongOutIO.CurrentCell.RowIndex).Value.ToString.Substring(6, 1)))
            'Try
            '    Dim OutID As String = CongOutIO.Item(2, Me.CongOutIO.CurrentCell.RowIndex).Value.ToString.Substring(6, 1)
            '    If ReadOutBool Then
            '        IOSenderBase.WriteOutbit(CInt(CongOutIO.Item(1, CongOutIO.CurrentCell.RowIndex).Value), CInt(OutID), 0)
            '    Else
            '        IOSenderBase.WriteOutbit(CInt(CongOutIO.Item(1, CongOutIO.CurrentCell.RowIndex).Value), CInt(OutID), 1)
            '    End If



        Catch ex As Exception
            ' MsgBox("错误报警")
        End Try
    End Sub
End Class