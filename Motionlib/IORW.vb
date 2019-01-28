Public Class IORW
    Dim Patht As String = My.Application.Info.DirectoryPath
    Dim path As String = Patht.Substring(0, Patht.LastIndexOf("\")) & "\Config\PParam.mtq"
    Dim pathS As String = Patht.Substring(0, Patht.LastIndexOf("\")) & "\Config\OutPParam.mtq"
    Public ggIN As New ArrayList
    Public ggOut As New ArrayList
    Public gggIN(,) As String = {{"", "", "", "", ""}, {"", "", "", "", ""}, {"", "", "", "", ""}, {"", "", "", "", ""}}
    Public gggOUT(,) As String = {{"", "", "", "", ""}, {"", "", "", "", ""}, {"", "", "", "", ""}, {"", "", "", "", ""}}
    Private operate As BaseFunction


    Public Sub New(ByRef Card As BaseFunction)
        Dim Count As Int16 = CInt(ReadP("Count", "0", path, "Count"))
        Dim Counts As Int16 = CInt(ReadP("Count", "0", pathS, "Count"))
        Dim IputStr As String = "Put"

       operate = Card

        For i As Int16 = 1 To Count
            Dim jj As Indsad
            jj.InNameID = ReadP("Input", "0", path, IputStr & i)
            jj.InName = ReadP("Name", "0", path, IputStr & i)
            jj.Highlevel = ReadP("ValA", "0", path, IputStr & i)
            jj.Lowlevel = ReadP("ValB", "0", path, IputStr & i)
            jj.InCard = ReadP("Card", "0", path, IputStr & i)
            ggIN.Add(jj)
            gggIN(i - 1, 0) = jj.InNameID
            gggIN(i - 1, 1) = jj.InName
            gggIN(i - 1, 2) = jj.Highlevel
            gggIN(i - 1, 3) = jj.Lowlevel
            gggIN(i - 1, 4) = jj.InCard
        Next
        For i As Int16 = 1 To Counts
            Dim jj As Outdsad
            jj.OutNameID = ReadP("Output", "0", pathS, IputStr & i)
            jj.OutName = ReadP("Name", "0", pathS, IputStr & i)
            jj.OutHighlevel = ReadP("ValA", "0", pathS, IputStr & i)
            jj.Outlevel = ReadP("ValB", "0", pathS, IputStr & i)
            jj.OutCard = ReadP("Card", "0", pathS, IputStr & i)
            ggOut.Add(jj)
            gggOUT(i - 1, 0) = jj.OutNameID
            gggOUT(i - 1, 1) = jj.OutName
            gggOUT(i - 1, 2) = jj.OutHighlevel
            gggOUT(i - 1, 3) = jj.Outlevel
            gggOUT(i - 1, 4) = jj.OutCard
        Next
    End Sub

    Public Sub ReGetIOStauta()
        Dim Count As Int16 = CInt(ReadP("Count", "0", path, "Count"))
        Dim Counts As Int16 = CInt(ReadP("Count", "0", pathS, "Count"))
        Dim IputStr As String = "Put"
        For i As Int16 = 1 To Counts
            Dim jj As Indsad
            jj.InNameID = ReadP("Input", "0", path, IputStr & i)
            jj.InName = ReadP("Name", "0", path, IputStr & i)
            jj.Highlevel = ReadP("ValA", "0", path, IputStr & i)
            jj.Lowlevel = ReadP("ValB", "0", path, IputStr & i)
            jj.InCard = ReadP("Card", "0", path, IputStr & i)
            ggIN.Add(jj)
            gggIN(i - 1, 0) = jj.InNameID
            gggIN(i - 1, 1) = jj.InName
            gggIN(i - 1, 2) = jj.Highlevel
            gggIN(i - 1, 3) = jj.Lowlevel
            gggIN(i - 1, 4) = jj.InCard
        Next

        For i As Int16 = 1 To Counts
            Dim jj As Outdsad
            jj.OutNameID = ReadP("Output", "0", pathS, IputStr & i)
            jj.OutName = ReadP("Name", "0", pathS, IputStr & i)
            jj.OutHighlevel = ReadP("ValA", "0", pathS, IputStr & i)
            jj.Outlevel = ReadP("ValB", "0", pathS, IputStr & i)
            jj.OutCard = ReadP("Card", "0", pathS, IputStr & i)
            ggOut.Add(jj)
            gggOUT(i - 1, 0) = jj.OutNameID
            gggOUT(i - 1, 1) = jj.OutName
            gggOUT(i - 1, 2) = jj.OutHighlevel
            gggOUT(i - 1, 3) = jj.Outlevel
            gggOUT(i - 1, 4) = jj.OutCard
        Next
    End Sub

    Public Structure Indsad
        Public InName As String 'IO口作用
        Public InCard As Byte '卡号
        Public Lowlevel As String '低电平
        Public Highlevel As String '高电平
        Public InNameID As String '对应卡的IO号
        Public InfMode As Boolean '对应该点显示方式
    End Structure

    Public Structure Outdsad
        Public OutName As String 'IO口作用
        Public OutCard As Byte '卡号
        Public Outlevel As String  '有效电平
        Public OutHighlevel As String '高电平
        Public OutNameID As String '对应卡的IO号
        Public OutMotion As Boolean '操作写入
    End Structure

    ''' <summary>
    ''' 读取输入
    ''' </summary>
    ''' <param name="NameNum"></param>
    ''' <param name="InState"></param> 
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadInNum(ByVal NameNum As String, ByVal InState As String, Optional ByVal ThrowEx As Boolean = True) As Boolean

        Try
            For i As Int16 = 0 To ggIN.Count - 1
                Dim INsyruc As Indsad = ggIN(i)
                If INsyruc.InName = NameNum Then
                    Select Case InState
                        Case INsyruc.Highlevel
                            If operate.ReadInbit(CShort(INsyruc.InCard), CShort(INsyruc.InNameID)) = 1 Then
                                Return True
                            Else
                                Return False
                            End If
                        Case INsyruc.Lowlevel
                            If operate.ReadInbit(CShort(INsyruc.InCard), CShort(INsyruc.InNameID)) = 0 Then
                                Return True
                            Else
                                Return False
                            End If
                        Case Else
                            If ThrowEx Then
                                Throw New AppException("404020", NameNum & XX输入点IO状态格式错误)
                            Else
                                Return False
                            End If
                    End Select
                End If
            Next
            If ThrowEx Then
                Throw New AppException("404030", NameNum & XX输入点IO未配置)
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 读取输出
    ''' </summary>
    ''' <param name="NameNum"></param>
    ''' <param name="InState"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadOutNum(ByVal NameNum As String, ByVal InState As String) As Boolean
        For i As Int16 = 0 To ggOut.Count - 1
            Dim INsyruc As Outdsad = ggOut(i)
            If INsyruc.OutName = NameNum Then
                Select Case InState
                    Case INsyruc.OutHighlevel
                        If operate.ReadOutbit(CShort(INsyruc.OutCard), CShort(INsyruc.OutNameID)) = 1 Then
                            Return True
                        Else
                            Return False
                        End If
                    Case INsyruc.Outlevel
                        If operate.ReadOutbit(CShort(INsyruc.OutCard), CShort(INsyruc.OutNameID)) = 0 Then
                            Return True
                        Else
                            Return False
                        End If
                    Case Else
                        Throw New AppException("404021", NameNum & XX输出点IO状态格式错误)
                End Select
            End If
        Next
        Throw New AppException("404030", NameNum & XX输出点IO未配置)
    End Function

    Public Function GetIOLogic(ByVal NameNum As String, ByVal InState As String) As Byte
        For i As Int16 = 0 To ggIN.Count - 1
            Dim INsyruc As Indsad = ggIN(i)
            If INsyruc.InName = NameNum Then
                Select Case InState
                    Case INsyruc.Highlevel
                        Return 1
                    Case INsyruc.Lowlevel
                        Return 0
                    Case Else
                        Throw New AppException("404020", NameNum & XX输入点IO状态格式错误)
                End Select
            End If
        Next
        Throw New AppException("404030", NameNum & XX输出点IO未配置)
    End Function

    ''' <summary>
    ''' 写入输出点
    ''' </summary>
    ''' <param name="NameNum"></param>
    ''' <param name="InState"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WriteOutNum(ByVal NameNum As String, ByVal InState As String) As Boolean
        For i As Int16 = 0 To ggOut.Count - 1
            Dim INsyruc As Outdsad = ggOut(i)
            If INsyruc.OutName = NameNum Then
                Select Case InState
                    Case INsyruc.OutHighlevel
                        operate.WriteOutbit(CShort(INsyruc.OutCard), CShort(INsyruc.OutNameID), 1)
                        Return True
                    Case INsyruc.Outlevel
                        operate.WriteOutbit(CShort(INsyruc.OutCard), CShort(INsyruc.OutNameID), 0)
                        Return True
                    Case Else
                        Throw New AppException("404022", NameNum & XX输出点IO状态格式错误)
                End Select
            End If
        Next
        '   Throw New AppException("404030", NameNum & "输出点IO未配置!")
    End Function
    ''' <summary>
    ''' 得到板卡输出口
    ''' </summary>
    ''' <param name="NameNum"> IO点名称</param>
    ''' <returns>返回IO点数</returns>
    ''' <remarks></remarks>
    Public Function GetPutNum(ByVal NameNum As String) As Byte()
        Try
            Dim Rel(1) As Byte
            Dim bln_Have As Boolean = False
            Dim INsyruc As Outdsad = Nothing
            For i As Int16 = 0 To ggOut.Count - 1
                INsyruc = ggOut(i)
                If INsyruc.OutName = NameNum Then
                    bln_Have = True
                    Exit For
                End If
            Next
            If bln_Have Then
                Rel(0) = INsyruc.OutCard
                Rel(1) = INsyruc.OutNameID
                Return Rel
            Else
                MsgBox(XX输出点 & NameNum & XX没有配置IO点)
                Return Nothing
                'Return 14
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 得到板卡输入口
    ''' </summary>
    ''' <param name="NameNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetInNum(ByVal NameNum As String) As Byte()
        Try
            Dim Rel(1) As Byte
            Dim bln_Have As Boolean = False
            Dim INsyruc As Indsad = Nothing
            For i As Int16 = 0 To ggIN.Count - 1
                INsyruc = ggIN(i)
                If INsyruc.InName = NameNum Then
                    bln_Have = True
                    Exit For
                End If
            Next
            If bln_Have Then
                Rel(0) = INsyruc.InCard
                Rel(1) = INsyruc.InNameID
                Return Rel
            Else
                MsgBox(XX输出点 & NameNum & XX没有配置IO点)
                Return Nothing
                'Return 14
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#Region "2016.4.18hh--直接读取IO卡"
    ''' <summary>
    ''' 直接读取板卡上的输出点状态
    ''' </summary>
    ''' <param name="CardNum">卡号</param>
    ''' <param name="OutIONum">点</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadOutIO(ByVal CardNum As Byte, ByVal OutIONum As Byte) As Boolean
        Try
            Return operate.ReadOutbit(CardNum, OutIONum)
        Catch ex As Exception
            Throw New AppException("404023", XX读取 & CardNum.ToString & XX号卡第 & OutIONum.ToString & XX输出点状态异常)
        End Try
        Return False
    End Function

    ''' <summary>
    ''' 直接对板卡输出点写电平状态
    ''' </summary>
    ''' <param name="CardNum">卡号</param>
    ''' <param name="IONum"></param>
    ''' <param name="OnOff">1高电平（开），0低电平（关）</param>
    ''' <remarks></remarks>
    Public Sub WriteOutIO(ByVal CardNum As Byte, ByVal IONum As Byte, ByVal OnOff As Byte)
        Try
            operate.WriteOutbit(CardNum, IONum, OnOff)
        Catch ex As Exception
            Throw New AppException("404024", XX写 & CardNum.ToString & XX号卡第 & IONum.ToString & XX输出点状态异常)
        End Try
    End Sub

    ''' <summary>
    ''' 直接读取板卡上的输入点状态
    ''' </summary>
    ''' <param name="CardNum">卡号</param>
    ''' <param name="InIONum">点</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadInIO(ByVal CardNum As Byte, ByVal InIONum As Byte)
        Try
            Return operate.ReadInbit(CardNum, InIONum)
        Catch ex As Exception
            Throw New AppException("404025", XX读取 & CardNum.ToString & XX号卡第 & InIONum.ToString & XX输入点状态异常)
        End Try
        Return False
    End Function

#End Region

End Class
