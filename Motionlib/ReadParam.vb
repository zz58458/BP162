Public Class ReadParam


    ''' <summary>
    ''' 读取所有轴名称
    ''' </summary>
    ''' <returns>轴名称数组</returns>
    ''' <remarks></remarks>
    Public Function Read_All_AxisName() As ArrayList
        Dim path As String = BaseParamPath & "\AxisName" & ".mtq"
        Dim paths As String = BaseParamPath & "\AxisParam" & ".mtq"

        Dim CardAxiaConfig As New ArrayList
        Dim CardAxiaName As New ArrayList

        If IO.File.Exists(path) = False Or IO.File.Exists(paths) = False Then
            'MsgBox("未找到轴配置文件")
            Return Nothing
        End If

        Dim CardNN As DMCCard._AxisNameConf
        Dim Str As IO.StreamReader = New IO.StreamReader(path)
        Try

            For i As Int16 = 0 To 3
                Dim jj As String = Str.ReadLine()
            Next

            While True
                Dim StrReadAxle As String = Str.ReadLine()
                If StrReadAxle = Nothing Then
                    Exit While
                End If
                CardAxiaName.Add(StrReadAxle)
            End While
            If CardAxiaName.Count > 0 Then
                For j As Int16 = 0 To CardAxiaName.Count - 1
                    Dim SearchCardAxia As String = CardAxiaName(j)
                    ' CardNN.CardNameN = ReadP("cardNum", 0, paths, SearchCardAxia)
                    CardNN.CardNameNUm = ReadP("cardNum", 0, paths, SearchCardAxia)
                    CardNN.AxiaNameN = ReadP("name", 0, paths, SearchCardAxia)
                    CardNN.AxisNo = ReadP("num", 0, paths, SearchCardAxia)
                    If CardNN.AxiaNameN <> "0" Then
                        CardAxiaConfig.Add(CardNN)
                    End If
                Next
            Else
                Exit Try
            End If
        Catch ex As Exception

        End Try
        Str.Close()
        Str.Dispose()

        Return CardAxiaConfig
    End Function

    Public Shared Function GetCardType() As String
        Dim path As String = BaseParamPath & "\AxisName" & ".mtq"
        Dim cardtype As String = ""
        Try
            Dim Sr As IO.StreamReader = New IO.StreamReader(path)
            Sr.ReadLine()
            cardtype = Sr.ReadLine
            cardtype = cardtype.Substring(cardtype.LastIndexOf("=") + 1, cardtype.Length - cardtype.LastIndexOf("=") - 1)
            Sr.Close()
        Catch ex As Exception

        End Try
        Return cardtype

    End Function

    Public Shared Function GetAxisNum() As Int16
        Dim path As String = BaseParamPath & "\AxisName" & ".mtq"
        Dim AxisNum As String = ""
        Try
            Dim Sr As IO.StreamReader = New IO.StreamReader(path)
            Sr.ReadLine()
            Sr.ReadLine()
            Sr.ReadLine()
            AxisNum = Sr.ReadLine
            AxisNum = AxisNum.Substring(AxisNum.LastIndexOf("=") + 1, AxisNum.Length - AxisNum.LastIndexOf("=") - 1)
        Catch ex As Exception

        End Try
        Return CInt(AxisNum)

    End Function



    ''' <summary>
    ''' 加载轴基本参数
    ''' </summary>
    ''' <param name="CardCount">卡数，传址</param>
    ''' <param name="param">卡参数结构，传址</param>
    ''' <remarks></remarks>
    Public Sub LodeAxisparam(ByRef CardCount As Byte, ByRef param As absMotionHaw.MotionHawParam)

        Try
            Dim RD As IO.StreamReader
            Dim mdir() As String
            Dim n As Integer
            Dim CardAxiaConfig As ArrayList = Read_All_AxisName()

            If IO.File.Exists(BaseParamPath & "\AxisName.mtq") Then
                RD = New IO.StreamReader(BaseParamPath & "\AxisName.mtq")

                Dim count As Int16 = 0
                Dim str As String
                While True
                    str = RD.ReadLine
                    If str = "" Then
                        Exit While
                    End If
                    If count = 2 Then
                        CardCount = str.Substring(str.LastIndexOf("=") + 1, str.Length - str.LastIndexOf("=") - 1)
                    End If
                    count += 1
                End While
                ReDim param.AxisParams(CardAxiaConfig.Count - 1)

                RD.Close()
                RD.Dispose()
            Else
                ' MsgBox("未发现轴配置文件")
                Exit Sub
            End If

            mdir = IO.Directory.GetFiles(BaseParamPath)
            Dim AxisLei As Byte = 0
            For n = 0 To mdir.Length - 1
                Dim str As String
                str = mdir(n)

                Dim name As String = ""
                name = str.Substring(str.LastIndexOf("\") + 1, str.Length - str.LastIndexOf("\") - 1)
                name = name.Substring(0, name.LastIndexOf("."))
                Dim Number As Byte '对应的轴号
                '  For j As Integer = 0 To mdir.Length - 1

                If name.EndsWith("BaseParam") Then
                    Dim ContinuFor As Boolean = False
                    For i As Int16 = 0 To CardAxiaConfig.Count - 1 '遍历该轴轴号
                        Dim CardT As DMCCard._AxisNameConf = CardAxiaConfig(i)
                        If name.Substring(0, name.LastIndexOf("BaseParam")) = CardT.AxiaNameN Then
                            Number = CardT.AxisNo
                            Exit For
                        End If
                        If i = CardAxiaConfig.Count - 1 Then
                            ContinuFor = True
                        End If
                    Next
                    If ContinuFor Then
                        Continue For
                    End If
                    str = str.Substring(0, str.LastIndexOf("."))
                    param.AxisParams(AxisLei).load(str)
                    param.AxisParams(AxisLei).IsExist = True
                    param.AxisParams(AxisLei).AxisNo = Number
                    AxisLei += 1
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 获取制程中所有轴的速度与位置
    ''' </summary>
    ''' <param name="AllSpeedList">所有轴的速度,传址</param>
    ''' <remarks></remarks>
    Public Sub GetAllAxisParam(ByVal ProgPath As String, ByRef AllSpeedList As ArrayList)


        AllSpeedList.Clear()

        Try
            Dim CardAxiaConfig As ArrayList = Read_All_AxisName()

            For i As Int16 = 0 To CardAxiaConfig.Count - 1
                Dim Node As DMCCard._AxisNameConf = CardAxiaConfig(i)
                Dim Name As String = Node.AxiaNameN
                Dim SpeedList As New ArrayList
                Dim PosionList As New ArrayList
                'AxiaSpeedArrilist.Clear()
                'AxiaPositionArrilist.Clear()
                LodeList(Name, ProgPath & Name & ".mtq", SpeedList, PosionList)
                LodeSpeed(ProgPath & Name & "参数.mtq", SpeedList, AllSpeedList)
            Next
        Catch ex As Exception

        End Try

    End Sub

    '将速度及位置名称加载到ArrayList中
    Private Sub LodeList(ByVal AxiaNameStr As String, ByVal path As String, ByRef SpeedList As ArrayList, ByRef PosionList As ArrayList) '读取轴速度，位置名字
        If IO.File.Exists(path) = False Then
            Exit Sub
        End If
        Dim Str As IO.StreamReader = New IO.StreamReader(path)
        Dim AxiaS As String = Str.ReadLine
        Try
            If AxiaS = "#" & AxiaNameStr & "速度" Then
                While True
                    Dim NowStrS As String = Str.ReadLine
                    If NowStrS = "" Then
                        Exit Try
                    End If

                    If (NowStrS.Substring(0, 1) = "#") = False Then
                        SpeedList.Add(NowStrS)
                    Else
                        Exit While
                    End If
                End While
                While True
                    Dim NowStrP As String = Str.ReadLine
                    If (NowStrP <> "") Then
                        PosionList.Add(NowStrP)
                    Else
                        Exit While
                    End If
                End While
            Else
                'MsgBox("参数文件不正确")
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        Str.Dispose()
        Str.Close()
    End Sub

    '
    Private Sub LodeSpeed(ByVal PathAxiaName As String, ByVal SpeedList As ArrayList, ByRef AllSpeedList As ArrayList)
        Dim mLise As New ArrayList
        ' Dim paths As String = ParamPath & "\" & PathAxiaName & ".mtq"
        Dim GDgridRSpeedSIG As New ArrayList
        Dim param0Speed As New absMtAxis._RunParam


        For i As Int16 = 0 To SpeedList.Count - 1
            Dim Spee As DMCCard.SpeedStrut
            Dim AxiaSpeedStr As String = SpeedList(i)
            GDgridRSpeedSIG = param0Speed.loadFastenCong(PathAxiaName, AxiaSpeedStr)
            param0Speed = GDgridRSpeedSIG(0)
            Spee.SpeedAORG = GDgridRSpeedSIG
            Spee.SpeedStuName = AxiaSpeedStr

            mLise.Add(Spee)
        Next
        'If mLise.Count <> 0 Then
        AllSpeedList.Add(mLise)
        'End If
    End Sub


    ''' <summary>
    ''' 保存轴运动参数，速度
    ''' </summary>
    ''' <param name="mPath"></param>
    ''' <param name="AllAxisSpeed"></param>
    ''' <param name="AllAxisPosition"></param>
    ''' <remarks></remarks>
    Public Sub SaveAll(ByVal mPath As String, ByVal AllAxisSpeed As ArrayList, ByVal AllAxisPosition As ArrayList)
        Dim DgAxiaNameStr As String
        Dim SpeedStuuA As New ArrayList
        Dim PositionNode As New ArrayList

        Dim AllAxisName As ArrayList = Read_All_AxisName()
        If AllAxisName Is Nothing Then
            Exit Sub
        End If

        If IO.Directory.Exists(mPath) = False Then
            IO.Directory.CreateDirectory(mPath)
        End If

        For i As Int16 = 0 To AllAxisName.Count - 1
            SpeedStuuA.Clear()
            PositionNode.Clear()
            Dim mNode As DMCCard._AxisNameConf = AllAxisName(i)
            DgAxiaNameStr = mNode.AxiaNameN

            If IO.File.Exists(mPath & "\" & DgAxiaNameStr & "参数" & ".mtq") Then
                IO.File.Delete(mPath & "\" & DgAxiaNameStr & "参数" & ".mtq")
            End If

            For j As Int16 = 0 To AllAxisSpeed.Count - 1
                Dim List As ArrayList = AllAxisSpeed(j)
                If List.Count = 0 Then
                    Continue For
                End If

                Dim Node As DMCCard.SpeedStrut = List(0)
                Dim mName As String = Node.SpeedStuName.Substring(0, Node.SpeedStuName.LastIndexOf("-"))
                If DgAxiaNameStr = mName Then
                    SpeedStuuA = List.Clone

                    For k As Int16 = 0 To SpeedStuuA.Count - 1
                        Dim SaveSArr As New ArrayList
                        Dim SaveSp As DMCCard.SpeedStrut = SpeedStuuA(k)
                        SaveSArr = SaveSp.SpeedAORG
                        SaveFastenCong(SaveSp.SpeedStuName, mPath & "\" & DgAxiaNameStr & "参数", SaveSArr)
                    Next
                    Exit For
                End If
            Next

            For j As Int16 = 0 To AllAxisPosition.Count - 1
                Dim List As ArrayList = AllAxisPosition(j)
                If List.Count = 0 Then
                    Continue For
                End If
                Dim Node As DMCCard.Postn = List(0)
                Dim mName As String = Node.PotionStrr
                mName = mName.Substring(0, mName.LastIndexOf("-"))
                If DgAxiaNameStr = mName Then
                    PositionNode = List.Clone
                    SaveNamePositStr(mPath & "\" & DgAxiaNameStr & "参数", DgAxiaNameStr, PositionNode)
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub SaveFastenCong(ByVal laname As String, ByVal Path As String, ByVal Arr As ArrayList)
        Try
            Path = Path & ".mtq"
            Dim param0Speed As absMtAxis._RunParam = Arr(0)
            WriteP(laname, "Min_Vel", param0Speed.Min_Vel, Path)
            WriteP(laname, "Max_Vel", param0Speed.Max_Vel, Path)
            WriteP(laname, "OrgSpeed", param0Speed.OrgSpeed, Path)
            WriteP(laname, "Tacc", param0Speed.Tacc, Path)
            WriteP(laname, "Tdec", param0Speed.Tdec, Path)
            WriteP(laname, "Sacc", param0Speed.Sacc, Path)
            WriteP(laname, "Sdec", param0Speed.Sdec, Path)
            WriteP(laname, "RunTime", param0Speed.RunTime, Path)
            WriteP(laname, "ReduceRatio", param0Speed.ReduceRatio, Path)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 保存该轴的位置数组
    ''' </summary>
    ''' <param name="Path">存储路径</param>
    ''' <param name="LpName">标题名称</param>
    ''' <param name="PositionNew">该轴位置数组</param>
    ''' <remarks></remarks>
    Private Sub SaveNamePositStr(ByVal Path As String, ByVal LpName As String, ByVal PositionNew As ArrayList)
        Path = Path & ".mtq"
        LpName = LpName & "位置"

        For i As Int16 = 0 To PositionNew.Count - 1
            Dim PoSitionStrr As DMCCard.Postn = PositionNew(i)
            WriteP(LpName, PoSitionStrr.PotionStrr, PoSitionStrr.PotionInt.ToString, Path)
            WriteP(LpName, PoSitionStrr.PotionStrr & "Type", PoSitionStrr.PotionType.ToString, Path)
            WriteP(LpName, PoSitionStrr.PotionStrr & "Get", PoSitionStrr.PotionGet.ToString, Path)
        Next
    End Sub



    ''' <summary>
    ''' 保存轴所有速度及位置名称
    ''' </summary>
    ''' <param name="paths">路径</param>
    ''' <param name="AxiaName">轴名称</param>
    ''' <param name="AxiaSpeedArrilist"></param>
    ''' <remarks></remarks>
    Public Sub SavePositionNum(ByVal paths As String, ByVal AxiaName As String, ByVal AxiaSpeedArrilist As ArrayList) '保存位置

        Dim Str As IO.StreamWriter = New IO.StreamWriter(paths, False)
        Try
            Str.WriteLine("#" & AxiaName & "速度")
            For i As Int16 = 0 To AxiaSpeedArrilist.Count - 1
                Str.WriteLine(AxiaSpeedArrilist(i))
            Next

        Catch ex As Exception

        End Try
        Str.Close()
        Str.Dispose()
    End Sub

    ''' <summary>
    ''' 读取轴速度，位置名字
    ''' </summary>
    ''' <param name="AxiaNameStr"></param>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Public Sub ReadAxiaNameSpeedPosition(ByVal path As String, ByVal AxiaNameStr As String, ByRef AxiaSpeedArrilist As ArrayList, ByRef AxiaPositionArrilist As ArrayList) '读取轴速度，位置名字
        ' Dim AxiaSpeedArrilist As New ArrayList
        'Dim AxiaPositionArrilist As New ArrayList

        If IO.File.Exists(path) = False Then
            Exit Sub
        End If

        Dim Str As IO.StreamReader = New IO.StreamReader(path)
        Dim AxiaS As String = Str.ReadLine
        Try

            If AxiaS = "#" & AxiaNameStr & "速度" Then
                Dim NowStrS As String
                While True
                    NowStrS = Str.ReadLine
                    If NowStrS = "" Then
                        Exit Try
                    End If

                    If NowStrS.Substring(0, 1) <> "#" Then
                        AxiaSpeedArrilist.Add(NowStrS)
                    Else
                        Exit While
                    End If
                End While
            Else
                ' MsgBox("参数文件不正确")
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        Str.Dispose()
        Str.Close()
    End Sub

    ''' <summary>
    ''' 将轴的所有速度写入枚举模块中
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub m_WriteSpeed(ByVal Sw As IO.StreamWriter, ByVal SpeedList As ArrayList, ByVal PositionList As ArrayList)

        ''''''写模块中的枚举文件()
        'Dim Sw As IO.StreamWriter = New IO.StreamWriter("Path", False)
        Dim CardAxiaConfig As ArrayList = Read_All_AxisName()

        Sw.WriteLine("Module Module_A")
        Sw.WriteLine(" ")
        Sw.WriteLine(" Public Class AxisName")
        For i As Int16 = 0 To CardAxiaConfig.Count - 1
            Dim Node As DMCCard._AxisNameConf = CardAxiaConfig(i)
            Dim AxisName As String = Node.AxiaNameN
            Sw.WriteLine(" Public Shared " & AxisName & " As String = " & Chr(34) & AxisName & Chr(34))
            ' Sw.WriteLine(" Public Const " & CardAxiaConfig(i) & " As String = " & Chr(34) & CardAxiaConfig(i) & Chr(34))
        Next
        Sw.WriteLine("")
        Sw.WriteLine("End Class")
        Sw.WriteLine("")
        Sw.WriteLine("")

        For i As Int16 = 0 To SpeedList.Count - 1
            Dim InList As ArrayList = SpeedList(i)
            Dim CNode As DMCCard.SpeedStrut = InList(0)
            Dim CName As String = CNode.SpeedStuName
            CName = "_" & CName.Substring(0, CName.LastIndexOf("-")) & "速度"

            Sw.WriteLine("")
            Sw.WriteLine(" Public Class " & CName)

            For j As Int16 = 0 To InList.Count - 1
                Dim InNode As DMCCard.SpeedStrut = InList(j)
                Dim name As String = InNode.SpeedStuName
                '  Dim s As String = name.Remove(name.IndexOf("-"), 1)
                Sw.WriteLine(" Public Shared " & name.Remove(name.IndexOf("-"), 1) & " As String = " & Chr(34) & name & Chr(34))
            Next
            Sw.WriteLine(" End Class ")

        Next

        For i As Int16 = 0 To PositionList.Count - 1
            Dim InList As ArrayList = PositionList(i)
            Dim CNode As DMCCard.Postn = InList(0)
            Dim CName As String = CNode.PotionStrr
            CName = "_" & CName.Substring(0, CName.LastIndexOf("-")) & "位置"

            '  Dim Sw1 As IO.StreamWriter = New IO.StreamWriter("", True)
            Sw.WriteLine("")
            Sw.WriteLine(" Public Class " & CName)

            For j As Int16 = 0 To InList.Count - 1
                Dim InNode As DMCCard.Postn = InList(j)
                Dim name As String = InNode.PotionStrr
                Sw.WriteLine(" Public Shared " & name.Remove(name.IndexOf("-"), 1) & " As String = " & Chr(34) & name & Chr(34))
            Next

            Sw.WriteLine(" End Class ")

        Next
        Sw.WriteLine("End Module")
    End Sub
End Class
