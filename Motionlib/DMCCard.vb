Imports System.Drawing

Public Class DMCCard
    Inherits absMotionHaw
#Region "声明"
    Public EX As clsAxis.RunStatus
    Public SetParam As Inset '设定插补矢量运动曲线的参数
    Private mThread As Threading.Thread
    Public InCard As BaseFunction
    Private runflag As Boolean
    Public bln_GridEnable As Boolean = False
    Public bln_GridIsReaction As Boolean = False
    ' Private mOpen As Boolean
    ' Private mClose As Boolean
    '  Private EmgWarm As Boolean '急停标志
    Private mReadIO As IORW '读IO
    Public mNumber As Int16 '轴总数
    Public AxisOfGratingNode() As _PNode '各个轴对应的光栅与安全门
    Private myGMode As clsAxis.gratingMode  '光栅错误信息
    Private NoConfigList As New ArrayList '未配置光栅的轴
    ' Public GList() As _GritMode
    'Private Event GratLeave(ByVal Node As _PNode) '光栅离开
    'Private Event GratTouch(ByVal Node As _PNode, ByVal Temp As axis2410.gratingMode) '碰到光栅
    Private AxisNameList As ArrayList '轴名称数组
    Public PosionList As ArrayList '位置数组
    Public SpeedNameList As ArrayList '速度名称及参数
    Public Single_AxisLimitFu() As Single
    Public Single_AxisLimitZh() As Single
    Private mWaite As Threading.ManualResetEvent
    Private CardName As String

#End Region

#Region "结构"
    Public Structure Postn
        Public PotionStrr As String   '位置名称
        Public PotionInt As Single    '位置大小
        Public PotionType As String   '位置类型，取料 ，插件 ，完成，废料，其他等
        Public PotionGet As String    '那个机械爪
    End Structure

    Public Structure SpeedStrut
        Public SpeedStuName As String
        Public SpeedAORG As ArrayList '速度结构数组
    End Structure

    Public Structure _AxisNameConf
        '  Public CardNameN As String
        Public CardNameNUm As String
        Public AxiaNameN As String
        Public AxisNo As Byte
    End Structure
#End Region



    ''' <summary>
    ''' 卡构造函数
    ''' </summary>
    ''' <param name="Params">卡参数(各轴的基本参数)</param>
    ''' <param name="AxisNum">轴数</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Params As absMotionHaw.MotionHawParam, ByVal AxisNum As Byte, ByVal Card As String)
        Try

            Dim Count As Byte
            CardName = Card
            If Card = "2410" Then
                InCard = New _2410Base
            ElseIf Card = "5400" Then
                InCard = New _5400Base
            ElseIf Card = "5600" Then
                InCard = New _5600Base
            ElseIf Card = "5800" Then
                InCard = New _5800Base
            ElseIf Card = "DFQ601" Then
                InCard = New _601Base
            Else
                Throw New AppException("104001", XX板卡初始化失败)
            End If
            mReadIO = New IORW(InCard)
            Me.InitHaw()
            For i As Int16 = 0 To AxisNum - 1
                If Params.AxisParams(i).IsExist Then
                    Count += 1
                End If
            Next
            If Count = 0 Then
                'MsgBox("轴初始化失败")
                Throw New Exception("104002," & XX板卡初始化失败_轴电平参数不存在)
            End If
            ReDim Me.mtAxis(Count - 1)
            ReDim Me.AxisOfGratingNode(Count - 1)


            mNumber = Count
            Dim n As Int16 = 0
            For j As Int16 = 0 To mtAxis.Length - 1
                For i As Int16 = 0 To AxisNum - 1
                    If Params.AxisParams(i).IsExist And Me.mtAxis.Length > n Then
                        Me.mtAxis(n) = New clsAxis(Card, Params.AxisParams(i).AxisNo, Params.AxisParams(i), InCard, 0)
                        n += 1
                    End If

                Next
            Next

            bln_GridEnable = False
            '   AxisList(i).AxisNo = Params.AxisParams(i).AxisNo

            mWaite = New Threading.ManualResetEvent(False)
            runflag = True
            mThread = New Threading.Thread(AddressOf BG)
            mThread.IsBackground = True
            '  mThread.ApartmentState = Threading.ApartmentState.STA
            mThread.Start()
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#Region "高速位置比较"
    Public Sub HCmp(ByVal axisName As String, ByVal CmpSource As Integer, _
                                        ByVal CmpPositon As Integer, ByVal CmpMode As Integer, _
                                        ByVal CmpLogic As Integer, ByVal CmpComNum As Integer, ByVal PlusWidth As Integer)
        Try
            Select Case CardName
                Case "5600"
                    Dim axis As Byte
                    axis = GetAxis(AxisNameTransNum(axisName)).mAxisNum
                    InCard.ComparePls(axis, CmpSource, CmpPositon, CmpMode, CmpLogic, CmpComNum, PlusWidth)
            End Select
        Catch appex As AppException
            Throw appex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 配置高速位置比较参数(关联轴与比较器)
    ''' </summary>
    ''' <param name="AxisName">轴名</param>
    ''' <param name="CmpComNum">使用的高速比较器
    ''' <para>0:CMP0(OUT12)</para>
    ''' <para>1:CMP1(OUT13)</para>
    ''' <para>2:CMP2(OUT14)</para>
    ''' <para>3:CMP3(OUT15)</para>
    ''' </param>
    ''' <param name="CmpSource">比较源:
    ''' <para>0:指令位置</para>
    ''' <para>1:编码器计数器</para>
    ''' </param>
    ''' <param name="CmpMode">比较模式:
    '''  <para>0:禁止使用位置比较</para>
    ''' <para>1:当前位置等于比较位置时，CMP端口才输出有效电平</para>
    ''' <para>2:当前位置小于比较位置时，CMP端口一直保持有效电平</para>
    '''  <para>3:当前位置大于比较位置时，CMP端口一直保持有效电平</para>
    ''' <para>4:队列模式</para>
    '''  <para>5:线性模式</para>
    ''' </param>
    ''' <param name="CmpLogic">有效电平
    '''  <para>0:低电平</para>
    ''' <para>1:高电平</para>
    ''' </param>
    ''' <param name="PlusWidth">脉冲宽度单位：us  只有在队列模式(4)和线性模式(5)有效，表示到达计数器时，输出多长时间的脉冲</param>
    ''' <remarks></remarks>
    Public Sub HCmpSetConfig(ByVal AxisName As String, ByVal CmpComNum As Integer, ByVal CmpSource As Integer, ByVal CmpMode As Integer, ByVal CmpLogic As Integer, ByVal PlusWidth As Integer)

        Try
            Select Case CardName
                Case "5600"
                    Dim axis As Byte
                    axis = GetAxis(AxisNameTransNum(AxisName)).mAxisNum
                    InCard.CmpSetConfig(axis, CmpComNum, CmpSource, CmpMode, CmpLogic, PlusWidth) 'CmpLogic
            End Select
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            MsgBox(XX高速比较位设置失败)
        End Try
    End Sub

    ''' <summary>
    ''' 输入卡号与比较器返回比较状态
    ''' </summary>
    ''' <param name="axisName">卡号</param>
    ''' <param name="CmpComNum">比较器号</param>
    ''' <param name="RemainedPoint">返回可添加比较点数</param>
    ''' <param name="CurrentPoint">返回当前比较点位置，单位plus</param>
    ''' <param name="FinshedPoint">返回回已比较点个数</param>
    ''' <remarks></remarks>
    Public Sub HCmpGetState(ByVal axisName As String, ByVal CmpComNum As Integer, ByRef RemainedPoint As Integer, ByRef CurrentPoint As Integer, ByRef FinshedPoint As Integer)

        Try
            Select Case CardName
                Case "5600"
                    Dim axis As Byte
                    axis = GetAxis(AxisNameTransNum(axisName)).mAxisNum
                    InCard.CmpGetState(axis, CmpComNum, RemainedPoint, CurrentPoint, FinshedPoint)
            End Select
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            MsgBox(XX获取比较器状态失败)
        End Try
    End Sub

    ''' <summary>
    ''' 输入卡号与比较器返回比较该比较器的配置
    ''' </summary>
    ''' <param name="axisName">卡号</param>
    ''' <param name="CmpComNum">比较器号</param>
    ''' <param name="axis">返回关联的轴号</param>
    ''' <param name="CmpMode">返回比较模式</param>
    ''' <param name="CmpSource">返回比较源</param>
    ''' <param name="CmpLogic">返回比较有效电平</param>
    ''' <param name="PlusWidth">返回比较脉冲宽度</param>
    ''' <remarks></remarks>
    Public Sub HCmpGetConfig(ByVal axisName As String, ByVal CmpComNum As Integer, ByRef axis As Int16, ByRef CmpMode As Integer, ByRef CmpSource As Integer, ByRef CmpLogic As Integer, ByRef PlusWidth As Integer)

        Try
            Select Case CardName
                Case "5600"
                    Dim axisA As Byte
                    axisA = GetAxis(AxisNameTransNum(axisName)).mAxisNum
                    InCard.CmpGetConfig(axisA, CmpComNum, axis, CmpMode, CmpSource, CmpLogic, PlusWidth)
            End Select
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            MsgBox(XX获取比较器状态失败)
        End Try
    End Sub

    ''' <summary>
    ''' 输入卡号与比较器，清除该比较器的已添加比较点数
    ''' </summary>
    ''' <param name="AxisName">轴名称</param>
    ''' <param name="CmpComNum">比较器号</param>
    ''' <remarks></remarks>
    Public Sub HCmpClearPoint(ByVal AxisName As String, ByVal CmpComNum As Integer)

        Try
            Select Case CardName
                Case "5600"
                    Dim axis As Byte
                    axis = GetAxis(AxisNameTransNum(AxisName)).mAxisNum
                    InCard.CmpClearPoint(axis, CmpComNum)
            End Select
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            MsgBox(XX清除比较点失败)
        End Try
    End Sub

    ''' <summary>
    ''' 输入卡号与比较器，为该比较器添加比较点
    ''' </summary>
    ''' <param name="axisName">卡号</param>
    ''' <param name="CmpComNum">比较器号</param>
    ''' <param name="CmpPositon">比较位置</param>
    ''' <remarks></remarks>
    Public Sub HCmpAddPoint(ByVal axisName As String, ByVal CmpComNum As Integer, ByVal CmpPositon As Single)
        Try

            Select Case CardName
                Case "5600"
                    Dim pluscount As Int32
                    Dim axis As Byte
                    axis = GetAxis(AxisNameTransNum(axisName)).mAxisNum
                    pluscount = GetAxis(AxisNameTransNum(axisName)).PulTran(GetAxis(AxisNameTransNum(axisName)).GetParams().RunComPare, CmpPositon)
                    InCard.CmpAddPoint(axis, CmpComNum, pluscount)
            End Select
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            MsgBox(XX添加高速比较点失败)
        End Try
    End Sub

#End Region

#Region "单段直线插补"
    Public Sub SetMulticoorProfile(ByVal MinVel As Integer, ByVal MaxVel As Integer, ByVal Taac As Single, ByVal Tdec As Single, ByVal StopVel As Integer)
        InCard.SetMulticoorProfileH(MinVel, MaxVel, Taac, Tdec, StopVel)
    End Sub

    Public Sub LineMultiCoor(ByVal AnxisNum As Integer, ByRef UAnxi() As UShort, ByRef Position() As Integer, ByVal PosiMode As Integer)
        InCard.LineMultiCoorH(AnxisNum, UAnxi, Position, PosiMode)
    End Sub

    Public Function MultiCoorCheckDone() As Integer

        Return InCard.MultiCoorCheckDoneH()

    End Function
#End Region

#Region "连续插补"

    ''' <summary>
    ''' 打开连续插补缓冲区
    ''' </summary>
    ''' <param name="FAxisName">轴数量</param>
    ''' <param name="SAxisName">轴号列表</param>
    ''' <returns>System.Int32.</returns>
    Public Function ContiOpenList(ByVal FAxisName As String, ByVal SAxisName As String) As Integer

        Try
            Dim UAxis(1) As UShort
            UAxis(0) = GetAxis(AxisNameTransNum(FAxisName)).mAxisNum
            UAxis(1) = GetAxis(AxisNameTransNum(SAxisName)).mAxisNum
            Return InCard.ContiOpenListH(UAxis.Length, UAxis)
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 设置连续插补速度曲线
    ''' </summary>
    ''' <param name="axisNam">轴名称</param>
    ''' <param name="MinVel">最小速度</param>
    ''' <param name="MaxVel">最大速度</param>
    ''' <param name="Taac">加时间</param>
    ''' <param name="Tdec">减时间</param>
    ''' <param name="StopVel">停止速度</param>
    ''' <returns>System.Int32.</returns>
    Public Function ContiSetProfile(ByVal axisNam As String, ByVal MinVel As Double, ByVal MaxVel As Double, ByVal Taac As Double, ByVal Tdec As Double, ByVal StopVel As Double) As Integer
        Dim minval As Integer = GetAxis(AxisNameTransNum(axisNam)).PulTran(GetAxis(AxisNameTransNum(axisNam)).GetParams().RunComPare, MinVel)
        Dim maxval As Integer = GetAxis(AxisNameTransNum(axisNam)).PulTran(GetAxis(AxisNameTransNum(axisNam)).GetParams().RunComPare, MaxVel)
        Return InCard.ContiSetProfileH(minval, maxval, Taac, Tdec, minval)
    End Function

    ''' <summary>
    '''设置连续插补S段时间
    ''' </summary>
    ''' <param name="sTime">平滑时间</param>
    ''' <returns>System.Int32.</returns>
    Public Function ContiSetSProfile(ByVal sTime As Double) As Integer
        Return InCard.ContiSetSProfileH(sTime)
    End Function

    ''' <summary>
    ''' 设置脉冲当量
    ''' </summary>
    ''' <param name="Equiv">脉冲当量</param>
    ''' <returns>System.Int32.</returns>
    Public Function ContiSetEquiv(ByVal AxisName As String, ByVal Equiv As Double) As Integer
        Select Case CardName
            Case "5600"
                Dim axis As Byte
                'Dim PulMmm As Integer = GetAxis(AxisNameTransNum(AxisName)).PulTran(GetAxis(AxisNameTransNum(AxisName)).GetParams().RunComPare, Equiv)
                axis = GetAxis(AxisNameTransNum(AxisName)).mAxisNum
                Return InCard.ContiSetEquivH(axis, Equiv)
            Case Else
                Return 0
        End Select
    End Function

    ''' <summary>
    ''' 连续插补直线指令
    ''' </summary>
    ''' <param name="FAxisName">第一个轴名称</param>
    ''' <param name="SAxisName">第二个轴名称</param>
    ''' <param name="TargetPosition">目标位置数组</param>
    ''' <returns>System.Int32.</returns>
    Public Function ContiLineMove(ByVal FAxisName As String, ByVal SAxisName As String, ByRef TargetPosition() As Double) As Integer
        Dim posPoint(1) As Double
        Dim UAxis(1) As UShort
        posPoint(0) = GetAxis(AxisNameTransNum(FAxisName)).PulTran(GetAxis(AxisNameTransNum(FAxisName)).GetParams().RunComPare, TargetPosition(0))
        posPoint(1) = GetAxis(AxisNameTransNum(SAxisName)).PulTran(GetAxis(AxisNameTransNum(SAxisName)).GetParams().RunComPare, TargetPosition(1))
        UAxis(0) = GetAxis(AxisNameTransNum(FAxisName)).mAxisNum
        UAxis(1) = GetAxis(AxisNameTransNum(SAxisName)).mAxisNum
        GetAxis(AxisNameTransNum(FAxisName)).mDisPulse = posPoint(0)
        GetAxis(AxisNameTransNum(SAxisName)).mDisPulse = posPoint(1)

        Return InCard.ContiLineMoveH(UAxis.Length, UAxis, posPoint, 1, 0)
    End Function

    ''' <summary>
    ''' 连续插补圆弧插补指令
    ''' </summary>
    ''' <param name="AnxisNum">轴数量</param>
    ''' <param name="UAnxi">轴号列表</param>
    ''' <param name="TargetPosition">目标位置数组</param>
    ''' <param name="CenterPosition">圆心位置数组</param>
    ''' <param name="ArcDir">圆弧方向，0：顺时针，1：逆时针</param>
    ''' <param name="Circle">圈数，负数：执行同心圆插补，非负数：执行螺旋线插补。具体设置看说明文档</param>
    ''' <param name="PosiMode">运动模式，0：相对坐标模式，1：绝对坐标模式</param>
    ''' <param name="MarkIndex">标号，任意指定，0表示自动编号</param>
    ''' <returns>System.Int32.</returns>
    Public Function ContiArcMove(ByVal AnxisNum As Integer, ByRef UAnxi() As UShort, ByRef TargetPosition() As Double, ByRef CenterPosition() As Double, ByVal ArcDir As Integer,
                                            ByVal Circle As Integer, ByVal PosiMode As Integer, ByVal MarkIndex As Integer) As Integer
        Return InCard.ContiArcMoveH(AnxisNum, UAnxi, TargetPosition, CenterPosition, ArcDir, Circle, PosiMode, MarkIndex)
    End Function



    ''' <summary>
    ''' 开始连续插补
    ''' </summary>
    ''' <returns>System.Int32.</returns>
    Public Function ContiStarListH() As Integer
        Return InCard.ContiStarListH()
    End Function

    ''' <summary>
    ''' 关闭连续插补缓冲区
    ''' </summary>
    ''' <returns>System.Int32.</returns>
    Public Function ContiCloseList() As Integer
        Return InCard.ContiCloseListH()
    End Function

    ''' <summary>
    ''' 读取轴停止原因
    ''' </summary>
    ''' <param name="axisName"></param>
    ''' <param name="StopReason"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetStopReason(ByVal axisName As String, ByRef StopReason As Int32) As Int16
        Dim axis As Short = AxisNameTransNum(axisName)
        Return InCard.GetStopReason(Axis, StopReason)
    End Function
#End Region

#Region "公共函数"
    Public Sub SetOrgPosition(ByVal AxisName As String, ByVal OrgDis As Single)
        Try
            Dim Long_OrgDis As Long
            Long_OrgDis = GetAxis(AxisNameTransNum(AxisName)).PulTran(GetAxis(AxisNameTransNum(AxisName)).GetParams().RunComPare, OrgDis)
            GetAxis(AxisNameTransNum(AxisName)).Org_Pos = Long_OrgDis
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
    Private Sub BG()
        Try
            While runflag
                If bln_GridEnable Then
                    AxisMoreNode() '处理配置过光栅的轴
                    '需要等待3秒
                    InspLeave() '检测光栅是否离开
                End If
                Threading.Thread.Sleep(50)
            End While
        Catch ex As Exception
            'Throw New Exception("100020,卡后台异常" & ex.Message)
        End Try
    End Sub

    Public Sub Dispos()
        runflag = False
        For i As Int16 = 0 To mtAxis.Length - 1
            mtAxis(i).Dispos()
        Next
    End Sub

#Region "光栅/安全门"

    Public Structure _PNode
        Public AxisNum As String '轴号
        Public GList As ArrayList  '对应的光栅或安全门

    End Structure

    ''' <summary>
    ''' 光栅对应的处理方法
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure _GritMode
        Public Name As String
        Public mode As clsAxis.gratingMode
        Public FlagName As String
    End Structure


    ''' <summary>
    ''' 查询某个轴的光栅安全门配置
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <returns>该轴的配置节点</returns>
    ''' <remarks></remarks>
    Public Function Query(ByVal AxisName As String) As _PNode
        If GetAxis(AxisNameTransNum(AxisName)) Is Nothing Then
            Return Nothing
        End If

        If AxisOfGratingNode Is Nothing Then
            Return Nothing
        End If

        Dim CurNode As _PNode
        For i As Int16 = 0 To AxisOfGratingNode.Length - 1
            CurNode = AxisOfGratingNode(i)
            If AxisOfGratingNode(i).AxisNum = AxisName Then
                Return CurNode
            End If
        Next

        Return Nothing
    End Function

    ''' <summary>
    ''' 设置轴对应光栅或安全门的配置
    ''' </summary>
    ''' <param name="AxisName">要重设的轴</param>
    ''' <returns>配置失败返回False</returns>
    ''' <remarks></remarks>
    Public Function SetGrat(ByVal AxisName As String, ByVal Glist As ArrayList) As Boolean

        If GetAxis(AxisNameTransNum(AxisName)) Is Nothing Then
            Return False
        End If
        Dim NewNode As _PNode
        NewNode.AxisNum = AxisName
        NewNode.GList = Glist
        If AxisOfGratingNode Is Nothing Then
            AxisOfGratingNode(0) = NewNode
            Return True
        Else
            For i As Int16 = 0 To AxisOfGratingNode.Length - 1
                If AxisOfGratingNode(i).AxisNum = AxisName Then
                    AxisOfGratingNode(i) = NewNode
                    Return True
                ElseIf AxisOfGratingNode(i).GList Is Nothing Then
                    AxisOfGratingNode(i) = NewNode
                    Return True
                End If
            Next
        End If

    End Function

    Public AutoRun As Boolean = False
    ''' <summary>
    ''' 轴对应的多个光栅处理
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AxisMoreNode()

        Dim ModeList As New ArrayList

        For i As Int16 = 0 To AxisOfGratingNode.Length - 1
            If Not bln_GridEnable Then
                Exit For
            End If
            Dim CNode As New _PNode
            CNode = AxisOfGratingNode(i)
            Dim Temp As clsAxis.gratingMode = clsAxis.gratingMode.Null

            If CNode.AxisNum Is Nothing Then
                Continue For
            End If
            If GetAxis(AxisNameTransNum(CNode.AxisNum)) Is Nothing Then
                Continue For
            End If


            If CNode.GList Is Nothing Then
                NoConfigList.Add(GetAxis(AxisNameTransNum(CNode.AxisNum)))
                Continue For
            End If

            If GetAxis(AxisNameTransNum(CNode.AxisNum)).ReadArr(False) And AutoRun = False Then
                Continue For
            End If

            For j As Int16 = 0 To CNode.GList.Count - 1
                Dim Name As String = CNode.GList(j).Name
                Dim FlagName As String = CNode.GList(j).FlagName
                If mReadIO.ReadInNum(Name, FlagName, False) Then
                    If CNode.GList(j).mode = clsAxis.gratingMode.减速停 And Temp <> clsAxis.gratingMode.马上停 Then
                        Temp = clsAxis.gratingMode.减速停
                    ElseIf CNode.GList(j).mode = clsAxis.gratingMode.马上停 Then
                        Temp = clsAxis.gratingMode.马上停
                    ElseIf CNode.GList(j).mode = clsAxis.gratingMode.减速 And Temp <> clsAxis.gratingMode.减速停 And Temp <> clsAxis.gratingMode.马上停 Then
                        Temp = clsAxis.gratingMode.减速
                    Else
                        Temp = clsAxis.gratingMode.不理
                    End If
                    'StarGra(CNode.AxisNum, CNode.GList(j).mode)
                End If
            Next

            If Temp <> clsAxis.gratingMode.Null Then
                'RaiseEvent GratTouch(CNode, Temp)
                If (GetAxis(AxisNameTransNum(CNode.AxisNum)).IsOrg Or GetAxis(AxisNameTransNum(CNode.AxisNum)).ReadArr(False)) _
                    And AutoRun = False Then ' Or GetAxis(AxisNameTransNum(CNode.AxisNum)).ReadArr(False) 

                Else
                    bln_GridIsReaction = True
                    StarGra(CNode.AxisNum, Temp)
                    ModeList.Add(Temp)
                End If
                'bln_GridIsReaction = True
                'StarGra(CNode.AxisNum, Temp)
                'ModeList.Add(Temp)
            End If
        Next

        If ModeList.Count = 1 Then
            myGMode = ModeList(0)
        ElseIf ModeList.Count >= 2 Then
            Dim Tem As clsAxis.gratingMode
            For i As Int16 = 0 To ModeList.Count - 2
                If ModeList(i) > ModeList(i + 1) Then
                    Tem = ModeList(i)
                Else
                    Tem = ModeList(i + 1)
                End If
            Next

            myGMode = Tem
        Else
            myGMode = clsAxis.gratingMode.Null
        End If
    End Sub

    Private Sub InspLeave()
        Dim mFlag As Boolean
        For i As Int16 = 0 To AxisOfGratingNode.Length - 1
            If Not bln_GridEnable Then
                Exit For
            End If
            mFlag = True
            Dim CNode As New _PNode
            CNode = AxisOfGratingNode(i)

            If GetAxis(AxisNameTransNum(CNode.AxisNum)) Is Nothing Then
                Continue For
            End If

            If CNode.GList Is Nothing Then
                NoConfigList.Add(GetAxis(AxisNameTransNum(CNode.AxisNum)))
                Continue For
            End If

            'For j As Int16 = 0 To CNode.GList.Count - 1
            '    Dim Name As String = CNode.GList(j).Name
            '    Dim FlagName As String = CNode.GList(j).FlagName
            '    If mReadIO.ReadInNum(Name, FlagName, False) Then
            '        mFlag = False
            '        Exit For
            '    End If
            'Next
            If mFlag Then
                If GetAxis(AxisNameTransNum(CNode.AxisNum)).IsOrg Then
                Else
                    If GetAxis(AxisNameTransNum(CNode.AxisNum)).GoOn <> 2 Then
                        gratings(CNode.AxisNum)
                    End If
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' 通知光栅离开
    ''' </summary>
    ''' <param name="Mode">处理模式，0（不理）或1（恢复、继续）</param>
    ''' <remarks></remarks>
    Public Sub InfromGrat(ByVal Mode As Byte)
        For i As Int16 = 0 To mtAxis.Length - 1
            If mtAxis(i).mAxisNum = 0 Or mtAxis(i).mAxisNum = 1 Then
                Continue For
            End If
            mtAxis(i).GraWatiOne.Set()
            mtAxis(i).GoOn = Mode
        Next

        Threading.Thread.Sleep(100)
        For i As Int16 = 0 To mtAxis.Length - 1
            If mtAxis(i).mAxisNum = 0 Or mtAxis(i).mAxisNum = 1 Then
                mtAxis(i).GraWatiOne.Set()
                mtAxis(i).GoOn = Mode
            End If
        Next
        bln_GridIsReaction = False
    End Sub

    ''' <summary>
    ''' 复位光栅离开
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitGrat()
        For i As Int16 = 0 To mtAxis.Length - 1
            If mtAxis(i).mAxisNum = 0 Or mtAxis(i).mAxisNum = 1 Then
                Continue For
            End If
            mtAxis(i).GraWatiOne.Set()
            mtAxis(i).GoOn = 0
            mtAxis(i).GratingsLeave()
        Next

        Threading.Thread.Sleep(100)
        For i As Int16 = 0 To mtAxis.Length - 1
            If mtAxis(i).mAxisNum = 0 Or mtAxis(i).mAxisNum = 1 Then
                mtAxis(i).GraWatiOne.Set()
                mtAxis(i).GoOn = 0
                mtAxis(i).GratingsLeave()
            End If
        Next
    End Sub

    ''' <summary>
    ''' 通知光栅离开,屏蔽某个轴
    ''' </summary>
    ''' <param name="axis">轴名字</param>
    ''' <remarks></remarks>
    Public Sub InfromGratSome(ByVal axis As String)
        'For i As Int16 = 0 To mtAxis.Length - 1
        mtAxis(AxisNameTransNum(axis)).GraWatiOne.Set()
        mtAxis(AxisNameTransNum(axis)).GoOn = 0
        'Next
    End Sub

    ''' <summary>
    ''' 复位光栅状态
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OrgGrat()
        InfromGrat(0)
        For i As Int16 = 0 To AxisOfGratingNode.Length - 1
            Dim CNode As New _PNode
            CNode = AxisOfGratingNode(i)

            If GetAxis(AxisNameTransNum(CNode.AxisNum)) Is Nothing Then
                Continue For
            End If

            If CNode.GList Is Nothing Then
                NoConfigList.Add(GetAxis(AxisNameTransNum(CNode.AxisNum)))
                Continue For
            End If

            If GetAxis(AxisNameTransNum(CNode.AxisNum)).GoOn <> 2 Then
                gratings(CNode.AxisNum)
            End If
        Next
    End Sub
#End Region

#Region "状态"
    ''' <summary>
    ''' 读取光栅错误最高等级处理模式
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGraErrorMode() As clsAxis.gratingMode
        Return myGMode
    End Function

    ''' <summary>
    ''' 单轴错误信息
    ''' </summary>
    ''' <param name="AxisNum">轴号</param>
    ''' <returns></returns>
    ''' <remarks>单轴错误报警</remarks>
    Public Overloads Function GetAxisError(ByVal AxisNum As Byte) As clsAxis._AXisInfo
        If GetAxis(AxisNum) Is Nothing Then
            Return Nothing
        End If

        Return GetAxis(AxisNum).AxisInfo
    End Function

    ''' <summary>
    ''' 判断运动是否到位
    ''' </summary>
    ''' <param name="AxisNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AxisIsArrived(ByVal AxisNum As String) As Boolean
        Try
            If GetAxis(AxisNameTransNum(AxisNum)) Is Nothing Then
                'MsgBox("该轴未配置基本参数")
                'Throw New Exception("100007,找不到" & AxisNum & "轴！")
            End If


            If GetAxis(AxisNameTransNum(AxisNum)).ReadArr() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub WriteCMPOnOff(ByVal str_Axis As String, ByVal OnOrOff As String)
        Try
            Dim num As Short = AxisNameTransNum(str_Axis)
            GetAxis(num).WriteCMPOnOff1(OnOrOff)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 设置比较触发器触发条件
    ''' </summary>
    ''' <param name="str_Axis">轴名称</param>
    ''' <param name="CMP1_mode">比较器1比较模式，0关闭比较器，1= ，2小于设定值，3,大于</param>
    ''' <param name="CMP2_Mode">比较器2比较模式，0关闭比较器，1= ，2小于设定值，3,大于</param>
    ''' <remarks></remarks>
    Public Sub SetCMPTriggerMode(ByVal str_Axis As String, ByVal CMP1_mode As Int16, ByVal CMP2_Mode As Int16)
        Try
            Dim num As Short = AxisNameTransNum(str_Axis)
            GetAxis(num).setCMPTiggerM(CMP1_mode, CMP2_Mode)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 设置比较器比较值
    ''' </summary>
    ''' <param name="str_Axis">轴名称</param>
    ''' <param name="CMP1_data">比较值1</param>
    ''' <param name="CMP2_data">比较值2</param>
    ''' <remarks></remarks>
    Public Sub SetCMPData(ByVal str_Axis As String, ByVal CMP1_data As Int32, ByVal CMP2_data As Int32)
        Try
            Dim num As Short = AxisNameTransNum(str_Axis)
            GetAxis(num).SetCMP1Data(CMP1_data, CMP1_data)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 读取急停到位等轴的外部信号
    ''' </summary>
    ''' <param name="str_Axis"> 轴号，7位 急停，15位 运动到位</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOtherStatu(ByVal str_Axis As String) As String
        Try
            Dim num As Short = AxisNameTransNum(str_Axis)
            Return GetAxis(num).GetRsts()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 读取轴内部信号，原点 限位，伺服报警等
    ''' </summary>
    ''' <param name="str_axis">11伺服报警，12正限位，13负限位，14原点</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAxisStatu(ByVal str_axis As String) As String
        Try
            Dim num As Short = AxisNameTransNum(str_axis)
            Return GetAxis(num).GetAxisState()
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 单轴错误信息
    ''' </summary>
    ''' <param name="AxisNum">轴名称</param>
    ''' <returns></returns>
    ''' <remarks> </remarks>
    Public Overloads Function GetAxisError(ByVal AxisNum As String) As clsAxis._AXisInfo
        If GetAxis(AxisNameTransNum(AxisNum)) Is Nothing Then
            '  MsgBox("该轴未配置基本参数")
            ' Throw New Exception("100007,找不到" & AxisNum & "轴！")
            Throw New AppException("104003", XX找不到 & AxisNum & XX轴)
        End If

        Return GetAxis(AxisNameTransNum(AxisNum)).AxisInfo
    End Function


    ''' <summary>
    ''' 获取某个轴
    ''' </summary>
    ''' <param name="AxisNum">轴号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAxis(ByVal AxisNum As Short) As clsAxis
        If mtAxis Is Nothing Or AxisNum = -1 Then
            '  Throw New Exception("100008,找不到" & AxisNum & "轴！")
            Return Nothing
        End If

        For i As Int16 = 0 To mtAxis.Length - 1
            If mtAxis(i).mAxisNum = AxisNum Then
                Return mtAxis(i)
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' 获取单轴状态结构
    ''' </summary>
    ''' <param name="AxisNum"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetAxisRunStat(ByVal AxisNum As String) As clsAxis.RunStatus
        Get
            Dim num As Byte = AxisNameTransNum(AxisNum)

            For i As Int16 = 0 To mtAxis.Length - 1
                If mtAxis(i).mAxisNum = num Then
                    'Return mtAxis(i)
                    Return mtAxis(i).EXInfo
                End If
            Next
        End Get
    End Property

    ''' <summary>
    ''' 获取卡中所有轴
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property Axis() As absMtAxis()
        Get
            Return mtAxis
        End Get
    End Property

    ''' <summary>
    ''' 清除所有报警
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub CleanError()
        For i As Int16 = 0 To mNumber - 1
            mtAxis(i).AxisInfo.clear()
        Next
    End Sub

    '清除该轴报警
    Public Sub CleanErrorWarm(ByVal AxisNum As String)
        Dim num As Byte = AxisNameTransNum(AxisNum)

        For i As Int16 = 0 To mtAxis.Length - 1
            If mtAxis(i).mAxisNum = num Then
                mtAxis(i).AxisInfo.clear()

            End If
        Next
    End Sub

    Public Overrides Sub CloseHaw()
        InCard.Close()
        Try
            mWaite.Dispose()
        Catch ex As Exception

        End Try


    End Sub

    ''' <summary>
    ''' 紧急停止所有轴
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub EmgStop()
        InCard.EmgStop()
    End Sub

    ''' <summary>
    ''' 初始化卡
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Overrides Sub InitHaw()
        Dim i As Int16
        i = InCard.Init()
        'If i = 0 Then
        '    ' MsgBox("卡初始化失败...")
        '    Throw New AppException("104001", XX板卡初始化失败)
        'End If
    End Sub

    ''' <summary>
    ''' 所有轴初始化回原点
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub OrgAllAxis()
        For i As Int16 = 0 To mNumber - 1
            mtAxis(i).GoHome()
        Next
    End Sub

    ''' <summary>
    ''' 重设所有信号有效电平
    ''' </summary>
    ''' <param name="Params"></param>
    ''' <remarks></remarks>
    Public Sub ReSetBaseParam(ByVal Params As absMotionHaw.MotionHawParam)

        Dim param As absMtAxis.AxisParam
        Dim AxisNo As Byte

        If mtAxis Is Nothing Then
            Exit Sub
        End If

        For i As Int16 = 0 To Params.AxisParams.Length - 1

            param = Params.AxisParams(i)
            AxisNo = Params.AxisParams(i).AxisNo

            For j As Int16 = 0 To mtAxis.Length - 1
                If mtAxis(i).mAxisNum = AxisNo Then
                    mtAxis(i).ReSetBaseParam(param)
                End If
            Next

        Next
    End Sub
#End Region

#Region ""

    ''' <summary>
    ''' 读取某个InIO某个状态是否超时
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="FlaN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadIOInChge(ByVal name As String, ByVal FlaN As String, ByVal n As Int16) As Boolean
        Dim j As Integer
        While True
            If mReadIO.ReadInNum(name, FlaN) Then
                Return True
            End If
            System.Threading.Thread.Sleep(200)
            j = j + 1
            If n > j Then
                Return False
            End If
        End While
    End Function



    ''' <summary>
    ''' 读取某个OutIO某个状态是否超时
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="FlaN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadIOOutChge(ByVal name As String, ByVal FlaN As String, ByVal n As Int16) As Boolean
        While True
            If mReadIO.ReadOutNum(name, FlaN) Then
                Return True
            End If
            System.Threading.Thread.Sleep(200)
            n = n + 1
            If n > 100 Then
                Return False
            End If
        End While
    End Function



#End Region

    Public Overrides Function ReadDM(ByVal strUnitNum As String, ByVal strHeadCode As String, ByVal intAddress As String, ByVal intData As String, Optional ByVal timeDelay As Integer = 100) As String
        Return Nothing
    End Function

    Public Overrides Function ReadIO(ByVal HardwareNum As Short, ByVal bitNum As Short, ByVal intAddress As Short) As Short

    End Function

    Public Overrides ReadOnly Property BaseFun As BaseFunction
        Get
            Return InCard
        End Get
    End Property

    ''' <summary>
    ''' 写入数据至硬件数据存储区
    ''' </summary>
    ''' <param name="strUnitNum">单元号码或硬件号码</param>
    ''' <param name="strHeadCode">模式代码(读，写等)</param>
    ''' <param name="intAddress">储存地址</param>
    ''' <param name="intData">储存内容</param>
    ''' <param name="timeDelay">延时时间</param>
    ''' <remarks></remarks>
    Public Overrides Sub WriteDM(ByVal strUnitNum As String, ByVal strHeadCode As String, ByVal intAddress As String, ByVal intData As String, Optional ByVal timeDelay As Integer = 100)

    End Sub

    Public Overrides Sub WriteIO(ByVal HardwareNum As Short, ByVal bitNum As Short, ByVal Value As Short, Optional ByVal intAddress As Short = 0)

    End Sub





#Region "插补"
    ''' <summary>
    ''' 2轴直线插补
    ''' </summary>
    ''' <param name="Axis1">轴1</param>
    ''' <param name="Dist1">轴1距离</param>
    ''' <param name="Axis2">轴2</param>
    ''' <param name="Dist2">轴2距离</param>
    ''' <param name="Posi_mode">0－相对位移，1－绝对位移</param>
    ''' <remarks></remarks>
    Public Overrides Sub Line2(ByVal Axis1 As Short, ByVal Dist1 As Long, ByVal Axis2 As Short, ByVal Dist2 As Long, ByVal Posi_mode As Short)
        InCard.SetVectorProfile(SetParam.Min_Vel, SetParam.Max_Vel, SetParam.Tacc, SetParam.Tdec)
        InCard.Line2(Axis1, Dist1, Axis2, Dist2, Posi_mode)
    End Sub

    ''' <summary>
    ''' 3轴直线插补
    ''' </summary>
    ''' <param name="Axis">轴列表</param>
    ''' <param name="Dist1">轴1距离</param>
    ''' <param name="Dist2">轴2距离</param>
    ''' <param name="Dist3">轴3距离</param>
    ''' <param name="Posi_mode">0－相对位移，1－绝对位移</param>
    ''' <remarks></remarks>
    Public Overrides Sub Line3(ByVal Axis As ArrayList, ByVal Dist1 As Long, ByVal Dist2 As Long, ByVal Dist3 As Long, ByVal Posi_mode As Short)
        InCard.SetVectorProfile(SetParam.Min_Vel, SetParam.Max_Vel, SetParam.Tacc, SetParam.Tdec)
        InCard.Line3(Axis, Dist1, Dist2, Dist3, Posi_mode)
    End Sub

    ''' <summary>
    ''' 4轴直线插补
    ''' </summary>
    ''' <param name="card">指定插补运动的板卡号, 范围（0 － N - 1 ,N为卡数）</param>
    ''' <param name="Dist1">指定插补第一轴的位移值，单位：脉冲数</param>
    ''' <param name="Dist2">指定插补第二轴的位移值，单位：脉冲数</param>
    ''' <param name="Dist3">指定插补第三轴的位移值，单位：脉冲数</param>
    ''' <param name="Dist4">指定插补第四轴的位移值，单位：脉冲数</param>
    ''' <param name="Posi_mode"></param>
    ''' <remarks></remarks>
    Public Overrides Sub Line4(ByVal card As Short, ByVal Dist1 As Long, ByVal Dist2 As Long, ByVal Dist3 As Long, ByVal Dist4 As Long, ByVal Posi_mode As Short)
        InCard.SetVectorProfile(SetParam.Min_Vel, SetParam.Max_Vel, SetParam.Tacc, SetParam.Tdec)
        InCard.Line4(card, Dist1, Dist2, Dist3, Dist4, Posi_mode)
    End Sub

    ''' <summary>
    ''' 二轴相对位置插补，圆弧插补
    ''' </summary>
    ''' <param name="Axis">轴号列表</param>
    ''' <param name="target_pos">目标位置列表（指定圆弧终点）</param>
    ''' <param name="cen_pos">圆心位置列表</param>
    ''' <param name="arc_dir">圆弧方向，0－顺时针,1－逆时针</param>
    ''' <remarks></remarks>
    Public Overrides Sub FACLine2(ByVal Axis As ArrayList, ByVal target_pos As ArrayList, ByVal cen_pos As ArrayList, ByVal arc_dir As Short)
        InCard.SetVectorProfile(SetParam.Min_Vel, SetParam.Max_Vel, SetParam.Tacc, SetParam.Tdec)
        InCard.ArcMove(Axis, target_pos, cen_pos, arc_dir)
    End Sub

    ''' <summary>
    ''' 二轴绝对位置插补，圆弧插补
    ''' </summary>
    ''' <param name="Axis">轴号列表</param>
    ''' <param name="target_pos">目标位置列表（指定圆弧终点）</param>
    ''' <param name="cen_pos">圆心位置列表</param>
    ''' <param name="arc_dir">圆弧方向，0－顺时针,1－逆时针</param>
    ''' <remarks></remarks>
    Public Overrides Sub ABSLine2(ByVal Axis As ArrayList, ByVal target_pos As ArrayList, ByVal cen_pos As ArrayList, ByVal arc_dir As Short)
        InCard.SetVectorProfile(SetParam.Min_Vel, SetParam.Max_Vel, SetParam.Tacc, SetParam.Tdec)
        InCard.relArcMove(Axis, target_pos, cen_pos, arc_dir)
    End Sub

    ''' <summary>
    ''' 插补矢量运动曲线的起始速度、运行速度、加速时间、减速时间
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure Inset
        Public Min_Vel As Double '起始速度，单位pps
        Public Max_Vel As Double '运行速度，单位pps
        Public Tacc As Double '总加速时间，单位s
        Public Tdec As Double '总减速时间，单位s
    End Structure
#End Region

#Region "轴运动函数"


    Public Sub ReadAxisStatu(ByVal AxisName As String)
        GetAxis(AxisNameTransNum(AxisName)).GetAllAxisStatus()
    End Sub


    Public Function ReadArr(ByVal AxisName As String, Optional ByVal Flag As Boolean = True) As Boolean
        Try
            Return GetAxis(AxisNameTransNum(AxisName)).ReadArr(Flag)
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' 设置该轴脉冲
    ''' </summary>
    ''' <param name="AxisName">轴名称</param>
    ''' <param name="Inval">脉冲数</param>
    ''' <remarks></remarks>
    Public Sub SetPosition(ByVal AxisName As String, ByVal Inval As Single)
        GetAxis(AxisNameTransNum(AxisName)).SetPosition(Inval)
    End Sub

    Public Sub ChangeDispos(ByVal AxisName As String, ByVal NewPos As Single)
        GetAxis(AxisNameTransNum(AxisName)).ResetPosition(NewPos)
    End Sub

    ''' <summary>
    ''' 获取目标位
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDisPos(ByVal AxisName As String) As Single
        Return GetAxis(AxisNameTransNum(AxisName)).GetDistance()
    End Function

    ''' <summary>
    ''' 获取传动比
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRunCompare(ByVal AxisName As String) As Single
        Return GetAxis(AxisNameTransNum(AxisName)).GetRunCompare()
    End Function

    ''' <summary>
    ''' 读取SD信号
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadSD(ByVal AxisName As String) As Byte
        Return GetAxis(AxisNameTransNum(AxisName)).ReadSD()
    End Function

    ''' <summary>
    ''' 设置编码器
    ''' </summary>
    ''' <param name="AxisName">轴名称</param>
    ''' <param name="ini">需要设置的值(毫米)</param>
    ''' <remarks></remarks>
    Public Sub SetEncode(ByVal AxisName As String, ByVal ini As Single)
        GetAxis(AxisNameTransNum(AxisName)).SetEncode(ini)
    End Sub

    ''' <summary>
    ''' 读编码器
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <param name="Plus">为True时读取脉冲，False读取距离</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEncode(ByVal AxisName As String, Optional ByVal Plus As Boolean = True)
        Return Math.Round(GetAxis(AxisNameTransNum(AxisName)).GetEncode(Plus), 3)
    End Function

    ''' <summary>
    ''' 所有轴上电
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub SevOnOff()
        For i As Int16 = 0 To mtAxis.Length - 1
            mtAxis(i).POW_T()
        Next
    End Sub

    Public Function ReadReadly(ByVal AxisName As String) As Boolean
        Return GetAxis(AxisNameTransNum(AxisName)).ReadAxisReadly
    End Function

    Public Function ReadReadly(ByVal AxisName As Byte) As Boolean
        Return GetAxis((AxisName)).ReadAxisReadly
    End Function

    ''' <summary>
    ''' 单轴上电
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <remarks></remarks>
    Public Sub Pow(ByVal AxisName As String)
        GetAxis(AxisNameTransNum(AxisName)).POW_T()
    End Sub

    ''' <summary>
    ''' 单轴下电
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DownPow(ByVal AxisName As String)
        GetAxis(AxisNameTransNum(AxisName)).DownPow()
    End Sub

    ''' <summary>
    ''' 全部下电
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SevonDown()
        For i As Int16 = 0 To mtAxis.Length - 1
            mtAxis(i).DownPow()
        Next
    End Sub

    Public Overloads Function MoveFAC(ByVal AxisName As String, ByVal InVel As Single, Optional ByVal WaitOver As Boolean = False) As Boolean
        Return GetAxis(AxisNameTransNum(AxisName)).MoveTofac(InVel, WaitOver)
    End Function

    ''' <summary>
    ''' 单轴相对运动
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <param name="PosionName" >位置名称</param>
    ''' <param name="WaitOver">超时是否报警</param>
    ''' <returns>命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Overloads Function MoveFAC(ByVal AxisName As String, ByVal PosionName As String, Optional ByVal WaitOver As Boolean = False) As Boolean
        Dim f As Boolean
        Dim DisPos As Double = NameTranPos(PosionName, f) '运动位置
        Return GetAxis(AxisNameTransNum(AxisName)).MoveTofac(DisPos, WaitOver)
    End Function

    Public Overloads Function MoveABS(ByVal AxisName As String, ByVal InVel As Single, Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            If GetAxis(AxisNameTransNum(AxisName)).MoveToabs(InVel, WaitOver) Then
                Return True
            Else
                Return False
                'Throw New Exception(AxisName & "绝对位置模式，运动到" & InVel & "位置发送运动指令失败")
            End If
        Catch ex As Exception
            Throw ex
        End Try
        '   Return GetAxis(AxisNameTransNum(AxisName)).MoveToabs(InVel, WaitOver)
    End Function

    ''' <summary>
    ''' 改变轴位置
    ''' </summary>
    ''' <param name="AxisName">轴名称</param>
    ''' <param name="Pos"> 新的绝对目标位移</param>
    ''' <remarks></remarks>
    Public Overloads Sub ReSetPos(ByVal AxisName As String, ByVal Pos As Single)
        Try
            GetAxis(AxisNameTransNum(AxisName)).ResetPosition(Pos)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 单轴绝对运动
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <param name="PosionName" >位置名称</param>
    ''' <param name="WaitOver">超时是否报警</param>
    ''' <returns>命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Overloads Function MoveABS(ByVal AxisName As String, ByVal PosionName As String, Optional ByVal WaitOver As Boolean = False) As Boolean
        Dim f As Boolean
        Dim DisPos As Double = NameTranPos(PosionName, f) '运动位置
        Return GetAxis(AxisNameTransNum(AxisName)).MoveToabs(DisPos, WaitOver)
    End Function

    ''' <summary>
    ''' 重设轴基本参数
    ''' </summary>
    ''' <param name="AxisName">轴名称</param>
    ''' <param name="RunP">轴运动参数</param>
    ''' <remarks></remarks>
    Public Overloads Function ResetParam(ByVal AxisName As String, ByVal RunP As absMtAxis._RunParam, Optional ByVal ThrowEr As Boolean = False) As Boolean
        GetAxis(AxisNameTransNum(AxisName)).ReSetRunP(RunP)
        Return True
    End Function

    Public Overloads Function ResetParam(ByVal AxisName As Short, ByVal RunP As absMtAxis._RunParam) As Boolean
        GetAxis(AxisName).ReSetRunP(RunP)
        Return True
    End Function

    ''' <summary>
    ''' 单轴停止
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <param name="WaitOver">超时是否报警</param>
    ''' <returns>命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function StopRun(ByVal AxisName As String, Optional ByVal WaitOver As Boolean = False) As Boolean
        Return GetAxis(AxisNameTransNum(AxisName)).StopM(WaitOver)
    End Function

    ''' <summary>
    ''' 所有轴急停
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AllStop()
        For i As Int16 = 0 To mNumber - 1
            mtAxis(i).StopM()
        Next
    End Sub

    ''' <summary>
    ''' 所有轴减速停
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AllDelStop()
        For i As Int16 = 0 To mNumber - 1
            mtAxis(i).DelStopM()
        Next
    End Sub

    ''' <summary>
    ''' 单轴持续运动
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <param name="WaitOver">超时是否报警</param>
    ''' <returns>命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function MoveKeep(ByVal AxisName As String, ByVal Dir As Byte, Optional ByVal WaitOver As Boolean = False) As Boolean
        Return GetAxis(AxisNameTransNum(AxisName)).K_Move(Dir, WaitOver)
    End Function

    ''' <summary>
    ''' 单轴回原点
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <param name="WaitOver">超时是否报警</param>
    ''' <returns>命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function GoHome(ByVal AxisName As String, Optional ByVal WaitOver As Boolean = False) As Boolean
        Return GetAxis(AxisNameTransNum(AxisName)).GoHome(WaitOver)
    End Function

    ''' <summary>
    ''' 单轴变速
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <param name="WaitOver">超时是否报警</param>
    ''' <returns>命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function ChangeSpeed(ByVal AxisName As String, ByVal Compaer As Single, Optional ByVal WaitOver As Boolean = False) As Boolean
        Return GetAxis(AxisNameTransNum(AxisName)).ChangeSpeed(Compaer, WaitOver)
    End Function


    ''' <summary>
    ''' 减速停止
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <param name="WaitOver">超时是否报警</param>
    ''' <returns>命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function DelSpeedStop(ByVal AxisName As String, Optional ByVal WaitOver As Boolean = False) As Boolean
        Return GetAxis(AxisNameTransNum(AxisName)).DelStopM(WaitOver)
    End Function


    ''' <summary>
    ''' 单轴暂停
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <param name="Pmode">暂停模式（0—>减速停止，1—>减速停止直到运动完成）</param>
    ''' <param name="WaitOver">超时是否等待</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Paused(ByVal AxisName As String, Optional ByVal Pmode As Byte = 0, Optional ByVal WaitOver As Boolean = False) As Boolean
        Return GetAxis(AxisNameTransNum(AxisName)).Paused(Pmode, WaitOver)
    End Function

    ''' <summary>
    ''' 单轴开始
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <param name="WaitOver">超时是否报警</param>
    ''' <returns>命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function Started(ByVal AxisName As String, Optional ByVal WaitOver As Boolean = False) As Boolean
        Return GetAxis(AxisNameTransNum(AxisName)).Started(WaitOver)
    End Function

    ''' <summary>
    ''' 光栅处理
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <returns>命令发送是否成功</returns>
    ''' <remarks></remarks>
    Private Function StarGra(ByVal AxisName As String, Optional ByVal Inmode As clsAxis.gratingMode = clsAxis.gratingMode.减速停) As Boolean
        Return GetAxis(AxisNameTransNum(AxisName)).StarGra(Inmode)
    End Function

    ''' <summary>
    ''' 光栅离开
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <param name="WaitOver">超时是否报警</param>
    ''' <returns>命令发送是否成功</returns>
    ''' <remarks></remarks>
    Private Function gratings(ByVal AxisName As String, Optional ByVal WaitOver As Boolean = False) As Boolean
        Return GetAxis(AxisNameTransNum(AxisName)).GratingsLeave(WaitOver)
    End Function

    ''' <summary>
    ''' 获取轴当前位置
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPos(ByVal AxisName As String) As Single
        Return Math.Round(GetAxis(AxisNameTransNum(AxisName)).ReadPosition, 3)
    End Function

    ''' <summary>
    ''' 获取单轴当前速度
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSpeed(ByVal AxisName As String) As Double
        Return GetAxis(AxisNameTransNum(AxisName)).ReadNowSpeed()
    End Function

    ''' <summary>
    ''' 判断该轴是否在某个位置
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <param name="PositionName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsThere(ByVal AxisName As String, ByVal PositionName As String) As Boolean
        Dim f As Boolean
        Dim DisPos As Double = NameTranPos(PositionName, f) '运动位置
        Return GetAxis(AxisNameTransNum(AxisName)).IsThere(DisPos)
    End Function


    ''' <summary>
    ''' 重设所有信号有效电平
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <remarks></remarks>
    Public Sub ReSetBaseParam(ByVal Param As absMtAxis.AxisParam)
        For i As Int16 = 0 To mtAxis.Length - 1
            mtAxis(i).ReSetBaseParam(Param)
        Next
    End Sub
    Public Sub ReSetHand()
        For i As Int16 = 0 To mtAxis.Length - 1
            mtAxis(i).ReSetHandP(i, 1, 0)
            mtAxis(i).SetHandSpeed(i, 10000)
        Next
    End Sub

    ''' <summary>
    ''' 无反相间隙的绝对运动
    ''' </summary>
    ''' <param name="AxisName">轴名称</param>
    ''' <param name="PosionName">目标位置名称</param>
    ''' <param name="OffDis">间隙补偿</param>
    ''' <param name="WaitOver"></param>
    ''' <remarks></remarks>
    Public Overloads Sub MoveNoSpaceAbs(ByVal AxisName As String, ByVal PosionName As String, ByVal OffDis As Single, Optional ByVal WaitOver As Boolean = False)
        Dim f As Boolean
        Dim DisPos As Double = NameTranPos(PosionName, f) '运动位置
        GetAxis(AxisNameTransNum(AxisName))._Move(DisPos, OffDis, WaitOver)
    End Sub

    Public Overloads Sub MoveNoSpaceAbs(ByVal AxisName As String, ByVal PosionName As Single, ByVal OffDis As Single, Optional ByVal WaitOver As Boolean = False)
        GetAxis(AxisNameTransNum(AxisName))._Move(PosionName, OffDis, WaitOver)
    End Sub

#End Region

#Region ""
    ''' <summary>
    ''' 负极限信号
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetFEL(ByVal AxisName As String) As Boolean
        Get
            Return GetAxis(AxisNameTransNum(AxisName)).GetFEL
        End Get
    End Property

    Public ReadOnly Property GetFEL(ByVal AxisName As Byte) As Boolean
        Get
            ' Return GetAxis(AxisNameTransNum(AxisName)).GetFEL
            Return GetAxis(AxisName).GetFEL
        End Get
    End Property


    Public ReadOnly Property GetINP(ByVal AxisName As String) As Boolean
        Get
            Return GetAxis(AxisNameTransNum(AxisName)).GetINP()
        End Get
    End Property

    Public ReadOnly Property GetINP(ByVal AxisName As Byte) As Boolean
        Get
            Return GetAxis(AxisName).GetINP()
        End Get
    End Property

    ''' <summary>
    ''' 正极限信号
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetZEL(ByVal AxisName As String) As Boolean
        Get
            Return GetAxis(AxisNameTransNum(AxisName)).GetZEL
        End Get
    End Property

    Public ReadOnly Property GetZEL(ByVal AxisName As Byte) As Boolean
        Get
            Return GetAxis(AxisName).GetZEL
        End Get
    End Property

    ''' <summary>
    ''' 伺服信号
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetSEV(ByVal AxisName As String) As Boolean
        Get
            Return GetAxis(AxisNameTransNum(AxisName)).GetSevn
        End Get
    End Property

    Public ReadOnly Property GetSEV(ByVal AxisName As Byte) As Boolean
        Get
            Return GetAxis(AxisName).GetSevn
        End Get
    End Property

    ''' <summary>
    ''' 急停信号
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetEMG(ByVal AxisName As String) As Boolean
        Get
            Return GetAxis(AxisNameTransNum(AxisName)).GetEMG
        End Get
    End Property

    Public ReadOnly Property GetEMG(ByVal AxisName As Byte) As Boolean
        Get
            Return GetAxis(AxisName).GetEMG
        End Get
    End Property

    ''' <summary>
    ''' 原点信号
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetORG(ByVal AxisName As String) As Boolean
        Get
            Return GetAxis(AxisNameTransNum(AxisName)).GetORG
        End Get
    End Property

    Public ReadOnly Property GetORG(ByVal AxisName As Byte) As Boolean
        Get
            Return GetAxis((AxisName)).GetORG
        End Get
    End Property

    Public ReadOnly Property GetEZ(ByVal AxisName As String) As Boolean
        Get
            Return GetAxis(AxisNameTransNum(AxisName)).GetEZ
        End Get
    End Property

    Public ReadOnly Property GetEZ(ByVal AxisName As Byte) As Boolean
        Get
            Return GetAxis((AxisName)).GetEZ
        End Get
    End Property
#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    ''' <summary>
    ''' 设置INP
    ''' </summary>
    ''' <param name="AxisName">轴</param>
    ''' <param name="NOINP">True有效</param>
    ''' <param name="Def">是否使用配置的INP</param>
    ''' <remarks></remarks>
    Public Sub SetINP(ByVal AxisName As String, ByVal NOINP As Boolean, Optional ByVal Def As Boolean = True)
        Try
            GetAxis(AxisNameTransNum(AxisName)).SetInp(NOINP, Def)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 设置运动参数
    ''' </summary>
    ''' <param name="AxisName">轴名称</param>
    ''' <param name="SpeedName">速度名称</param>
    ''' <remarks></remarks>
    Public Function LodeParam(ByVal AxisName As String, ByVal SpeedName As String) As Boolean
        Dim Runp As absMtAxis._RunParam = Nothing
        For i As Int16 = 0 To SpeedNameList.Count - 1
            Dim NList As ArrayList = SpeedNameList(i)
            Dim Flag As Boolean = False
            For j As Int16 = 0 To NList.Count - 1
                Dim SpeedNode As SpeedStrut = NList(j)
                If SpeedNode.SpeedStuName = SpeedName Then
                    Runp = SpeedNode.SpeedAORG(0)
                    Flag = True
                    Exit For
                End If
            Next
            If Flag Then
                Exit For
            End If
        Next

        'Dim f1, f2 As Boolean
        'Dim R As Single = NameTranPos(AxisName & "-正极限", f1)
        'Dim L As Single = NameTranPos(AxisName & "-负极限", f2)
        'If f1 Then
        '    Runp.RightLimit = 0
        'End If
        'If f2 Then
        '    Runp.LeftLimit = 0
        'End If
        'Runp.RightLimit = NameTranPos(AxisName & "-正极限")
        'Runp.LeftLimit = NameTranPos(AxisName & "-负极限")
        ResetParam(AxisName, Runp)
    End Function

    ''' <summary>
    ''' 设置轴运动位置、速度
    ''' </summary>
    ''' <param name="NameList">轴数组</param>
    ''' <param name="SpeedName">速度数组</param>
    ''' <remarks></remarks>
    Public Sub SetName(ByRef NameList As ArrayList, ByRef SpeedName As ArrayList, Optional ByVal FlagName As String = "感应", Optional ByVal InspDoor As Boolean = False)
        Try
            If NameList.Count = 0 And SpeedName.Count = 0 Then
                Throw New Exception("")
            End If
            AxisNameList = NameList
            SpeedNameList = SpeedName

            For byte_i As Byte = 0 To AxisOfGratingNode.Length - 1

                Dim _AxisGri, _AxisGris As _GritMode
                Dim AxisNameStr As _AxisNameConf
                AxisNameStr = AxisNameList(byte_i)
                ' If AxisNameStr.AxiaNameN = "Y1" Or AxisNameStr.AxiaNameN = "Y2" Then
                AxisOfGratingNode(byte_i).AxisNum = AxisNameStr.AxiaNameN
                _AxisGri.mode = clsAxis.gratingMode.减速停
                _AxisGri.Name = "安全光栅"
                _AxisGri.FlagName = FlagName ' "感应"

                _AxisGris.mode = clsAxis.gratingMode.减速停
                _AxisGris.Name = "后光栅"
                _AxisGris.FlagName = FlagName ' "感应"

                AxisOfGratingNode(byte_i).GList = New ArrayList
                AxisOfGratingNode(byte_i).GList.Add(_AxisGri)
                AxisOfGratingNode(byte_i).GList.Add(_AxisGris)
                If InspDoor Then
                    Dim _AxisGriDoor1, _AxisGriDoor2 As _GritMode
                    _AxisGriDoor1.mode = clsAxis.gratingMode.减速停
                    _AxisGriDoor1.Name = "前门开关"
                    _AxisGriDoor1.FlagName = "没感应" ' "感应"

                    _AxisGriDoor2.mode = clsAxis.gratingMode.减速停
                    _AxisGriDoor2.Name = "后门开关"
                    _AxisGriDoor2.FlagName = "没感应" ' "感应"

                    AxisOfGratingNode(byte_i).GList.Add(_AxisGriDoor1)
                    AxisOfGratingNode(byte_i).GList.Add(_AxisGriDoor2)
                End If

                '  End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' 设置所有轴名称
    ''' </summary>
    ''' <param name="NameList">轴名称关系数组</param>
    ''' <remarks></remarks>
    Public Sub SetAllAxisName(ByRef NameList As ArrayList)
        AxisNameList = NameList
    End Sub

    ''' <summary>
    ''' 设置所有轴位置名称
    ''' </summary>
    ''' <param name="PositionName">该轴所有位置关系数组</param>
    ''' <remarks></remarks>
    Public Sub SetAllAxisPosition(ByRef PositionName As ArrayList)
        PosionList = PositionName
    End Sub

    ''' <summary>
    ''' 设置所有轴速度名称
    ''' </summary>
    ''' <param name="SpeedName">轴速度关系数组</param>
    ''' <remarks></remarks>
    Public Sub SetAllAxisSpeed(ByRef SpeedName As ArrayList)
        SpeedNameList = SpeedName
    End Sub

    ''' <summary>
    ''' 轴名称转轴号
    ''' </summary>
    ''' <param name="AxisName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AxisNameTransNum(ByVal AxisName As String) As Short
        If AxisNameList Is Nothing Then
            '  Return -1
            Throw New AppException("104004", XX找不到 & AxisName & XX轴配置) 
        End If
        If AxisName Is Nothing Then
            Return Nothing
        End If
        Dim name As String = AxisName
        For i As Int16 = 0 To AxisNameList.Count - 1 '遍历该轴轴号
            Dim CardT As _AxisNameConf = AxisNameList(i)
            If name = CardT.AxiaNameN Then
                Return CardT.AxisNo
            End If
        Next
        ' Return -1
        Throw New AppException("104005", XX找不到 & AxisName & XX轴配置)
    End Function

    ''' <summary>
    ''' 轴号称转轴名称
    ''' </summary>
    ''' <param name="AxisNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AxisNumTransName(ByVal AxisNum As Short) As String
        If AxisNameList Is Nothing Then
            Return -1
        End If

        Dim num As Short = AxisNum

        For i As Int16 = 0 To AxisNameList.Count - 1 '遍历该轴轴号
            Dim CardT As _AxisNameConf = AxisNameList(i)
            If num = CardT.AxisNo Then
                Return CardT.AxiaNameN
            End If
        Next
        Return -1
    End Function

    ''' <summary>
    ''' 位置名称转换为具体位置
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NameTranPos(ByVal Name As String, ByRef flag As Boolean) As Double
        Try
            For i As Int16 = 0 To PosionList.Count - 1
                Dim NList As ArrayList = PosionList(i)
                For j As Int16 = 0 To NList.Count - 1
                    Dim PosionNode As Postn = NList(j)
                    If PosionNode.PotionStrr = Name Then
                        flag = True
                        Return PosionNode.PotionInt
                    End If
                Next
            Next
        Catch ex As Exception

        End Try

        flag = False
    End Function


    ''' <summary>
    ''' 位置名称转换为具体位置
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NameTranDispos(ByVal Name As String) As Single

        For i As Int16 = 0 To PosionList.Count - 1
            Dim NList As ArrayList = PosionList(i)
            For j As Int16 = 0 To NList.Count - 1
                Dim PosionNode As Postn = NList(j)
                If PosionNode.PotionStrr = Name Then
                    Return PosionNode.PotionInt
                End If
            Next
        Next

    End Function

    ''' <summary>
    ''' 轴IO映射：通用IO点(点号)映射为轴急停点
    ''' </summary>
    ''' <param name="carno">卡号</param>
    ''' <param name="axis">轴号</param>
    ''' <param name="IOnum">通用IO号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function setAxisIOmap(ByVal carNo As Int16, ByVal axis As Int16, ByVal IONum As Int16) As Int16
        Return InCard.axisIOmap(carNo, axis, 3, 6, IONum, 1)
    End Function

    ''' <summary>
    ''' 轴IO映射：通用IO点(名称)映射为轴急停点
    ''' </summary>
    ''' <param name="axis">轴号</param>
    ''' <param name="IOName">IO点名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function setAxisIONameMap(ByVal axis As Int16, ByVal IOName As String) As Int16
        Dim IOMessage As Byte() = mReadIO.GetInNum(IOName)
        Dim carNo As Int16 = IOMessage(0)
        Dim IONum As Int16 = IOMessage(1)
        Return setAxisIOmap(carNo, axis, IONum)
    End Function

    ''' <summary>
    ''' 设置轴EMG信号使能，有效电平为低电平
    ''' </summary>
    ''' <param name="axis">轴号</param>
    ''' <param name="IOName">IO点名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function setEmgModule(ByVal axis As Int16, ByVal IOName As String, ByVal str As String) As UInt16
        Dim IOMessage As Byte() = mReadIO.GetInNum(IOName)
        Dim carNo As Int16 = IOMessage(0)
        Dim logic As Byte = mReadIO.GetIOLogic(IOName, str)
        Return InCard.setEmgModel(carNo, axis, 1, logic)
    End Function

End Class