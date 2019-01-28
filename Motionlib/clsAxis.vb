Imports System.Threading.Thread
Public Class clsAxis
    Inherits absMtAxis
#Region "声明"
    Public EXInfo As RunStatus  '状态、异常信息
    Public mAxisNum As Byte
    Public Org_Pos As Integer = 0
    Public mDisPulse As Long '绝对位移目标位
    Public GoOn As Byte = 2 '光栅离开后是否继续
    Private BaseFun As BaseFunction
    Private mThread As Threading.Thread
    Private Params As New absMtAxis.AxisParam
    Private RunParam As New absMtAxis._RunParam
    Public CurRunParam As New absMtAxis._RunParam
    Private mRunFlag As Boolean '
    Private mCommandingFlag As Boolean
    Private mMovoLoc As Integer
    Private mComMutex As New Threading.Mutex

    Private WaitThread As Threading.Thread '超时等待线程
    Private Mcurstat As MotionState '当前命令状态
    Private Frontcom As Command = Command.Null     '前一次的命令状态
    Private Const ABS As Byte = 1   '走绝对
    Private Const FAC As Byte = 0   '走相对
    Private Curp As Integer
    Private mPmode As PauseMode '暂停模式
    Private GrMode As gratingMode '光栅模式
    Protected mCom As Command = Command.DelSpeed
    ' Public NowSpeed As Double
    Public Pause As Boolean = False '暂停标志
    Private gratingd As Boolean = False '光栅标志
    '  Public mCurPos As Single   '当前脉冲
    Public mDelScale As Single '变速比
    Public AxisInfo As New _AXisInfo
    Private BackSpeed As Double '恢复速度
    Private ExDLog As New GratingForm '弹出光栅异物窗口
    Public IsOrg As Boolean '复位标志
    Public BWatiOne As Threading.ManualResetEvent
    Private Inspect As Threading.Thread
    Private Flag As Boolean = True
    Private Keep As Boolean
    Private CartType As String
    Private RunWait As New Threading.Mutex
    Private GratFlag As Boolean = False
#End Region

    ''错误代码 404101~404150
    Public Sub New(ByVal CardT As String, ByVal axis As Byte, ByVal Inparam As absMtAxis.AxisParam, ByVal Fun As BaseFunction, ByVal CarNum0 As Integer)
        Try
            'CarNum = CarNum0
            CartType = CardT
            mAxisNum = axis
            Params = Inparam
            BaseFun = Fun

            ' P(Params, RunParam) 'Params轴的配置结构体；RunParam设置速度的结构体;此函数是用于配置轴的参数
            mCom = Command.Null 'Command枚举
            Mcurstat = MotionState.MotionNull '当前状态枚举
            mRunFlag = True
            mMoveWatiOne = New Threading.ManualResetEvent(False)
            mCommWatiOne = New Threading.ManualResetEvent(False)
            GraWatiOne = New Threading.ManualResetEvent(False)
            GraWatiOne.Reset()
            BWatiOne = New Threading.ManualResetEvent(False)
            'Inspect = New Threading.Thread(AddressOf InSpectStatus)
            'Inspect.IsBackground = True
            'Inspect.Start()
            'Wr.WriteExceptionNote(mAxisNum & "轴初始化成功", "")
        Catch ex As Exception
            Throw New Exception("104150;" & XX实例化轴类失败_请退出程序_重新进入 & Chr(13) & ex.Message)
        End Try

    End Sub

#Region "状态"
    Private Enum MotionState As Byte
        MotionKeepMove = 0
        MotionABS = 1
        MotionFAC = 2
        MotionStopMove = 3
        MotionReadPos = 4
        MotionPOW = 5
        MotionComeback = 6
        MotionNull = 7
        'MotionTimeOut = 8
        'MOtionALM = 9
        MotionPause = 10
        MotionStart = 11
        MotionGrating = 12
        MotionCS = 13
        MotionGratLeave = 14
    End Enum

    Private Enum PauseMode As Byte
        减速停止 = 0
        减速停止直到运动完成 = 1
    End Enum

    ''' <summary>
    ''' 光栅处理模式
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum gratingMode As Byte
        Null = 0
        减速停 = 3
        马上停 = 4
        不理 = 1
        减速 = 2
    End Enum

    ''' <summary>
    ''' 轴状态
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum RunStatus As Byte
        运动 = 1
        停止 = 0
    End Enum

    Public Class _AXisInfo
        Public IsBusy As Boolean  '运动或停止
        Public TimeOutWarm As Boolean ' 超时报警
        Public SiFuWarn As Boolean ' 伺服报警
        Public EmgWarm As Boolean '  急停报警
        Public GratWarm As Boolean '光栅报警
        Public ZJiXian As Boolean '正极限报警
        Public FJiXian As Boolean '负极限报警
        Public OrgIsOn As Boolean  '原点光感是否感应
        Public SD As Boolean 'SD
        Public IsArr As Boolean '到位
        Public EZ As Boolean  'EZ

        Public Sub clear()
            Me.ZJiXian = 0
            Me.FJiXian = 0
            Me.TimeOutWarm = 0
            Me.SiFuWarn = 0
            Me.EmgWarm = 0
            Me.GratWarm = 0
        End Sub

    End Class

    Public Structure EXType
        Public Mystatus As RunStatus

    End Structure
#End Region

#Region "状态获取"
    Public ReadOnly Property GetParams() As absMtAxis.AxisParam
        Get
            Return Params
        End Get
    End Property
    ''' <summary>
    ''' 获取轴任务状态
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ReadMyStatus() As Byte
        Get
            Return Mcurstat
        End Get
    End Property


    ''' <summary>
    ''' 获取轴所有异常信息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetAllEX() As _AXisInfo
        Get
            Return AxisInfo
        End Get
    End Property


#End Region

#Region "外部使用"
    ''' <summary>
    ''' 设置INP
    ''' </summary>
    ''' <param name="INP">True有效</param>
    ''' <param name="Def">是否使用配置的INP</param>
    ''' <remarks></remarks>
    Public Sub SetInp(ByVal INP As Boolean, Optional ByVal Def As Boolean = True)
      
        If Def Then '使用默认配置
            INPpin(mAxisNum, Params.INPEable, Params.INPSignal) '设置允许/禁止 INP 信号及其有效的逻辑电平，伺服定位完成（Params.INPEable, Params.INPSignal设置1,0低电平有效）
        Else
            If INP = True Then
                INPpin(mAxisNum, 1, Params.INPSignal)
            Else
                INPpin(mAxisNum, 0, Params.INPSignal)
            End If
        End If
    End Sub

    Public Sub PosTranPlu(ByVal Dis As Single)

    End Sub

    Public Sub WriteCMPOnOff1(ByVal OnOrOff As Byte)
        Try
            WriteCMPOnOff(OnOrOff)
        Catch ex As Exception
            Throw New AppException("404102", XX设置比较输出电平失败)
        End Try
    End Sub

    Public Sub setCMPTiggerM(ByVal CMP1_mode As Int16, ByVal CMP2_mode As Int16)
        Try
            SetCMPTrggerMode(CMP1_mode, CMP2_mode)
        Catch ex As Exception
            Throw New AppException("404103", XX设置比较器触发条件失败)
        End Try
    End Sub

    Public Sub SetCMP1Data(ByVal CMP1_data As Int32, ByVal CMP2_data As Int32)
        Try
            SetCMPData(CMP1_data, CMP2_data)
        Catch ex As Exception
            Throw New AppException("404104", XX设置CMP比较值失败)
        End Try
    End Sub

    Public Function GetRsts() As String
        Try
            Dim Othersignal As Int32 = ReadOtherStatu(mAxisNum)
            Return Convert.ToString(Othersignal, 2)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDistance() As Single
        Return Pultranmm(Params.RunComPare, mDisPulse)
    End Function

    Public Function GetAxisState() As String
        Try
            Dim IOsignal As Long = ReadAxisStatu(mAxisNum)
            Return Convert.ToString(IOsignal, 2)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ResetPosition(ByVal NewPos As Single) '改变目标位置
        Try

            Dim InVal As Long
            InVal = PulTran(Params.RunComPare, NewPos)
            mDisPulse = InVal
            AxisInfo.IsArr = False
            BaseFun.ResetTargetPosition(mAxisNum, InVal)
        Catch ex As Exception
            Throw New AppException("404104", XX改变目标位置失败)
        End Try
    End Sub

    ''' <summary>
    ''' 脉冲设置
    ''' </summary>
    ''' <param name="InVal">毫米</param>
    ''' <remarks></remarks>
    Public Sub SetPosition(ByVal InVal As Single)
        Dim dis As Int32 = PulTran(Params.RunComPare, InVal)
        SetPos(mAxisNum, dis)
        'BaseFun.SetEncode(mAxisNum, InVal)
    End Sub

    Public Function ReadAxisReadly() As Boolean
        Dim byte_i As Int32 = ReaRDY(mAxisNum)
        If byte_i = Params.ReySig Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' 下电
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DownPow()
        Dim se As Int32 = ReaSEVON(mAxisNum)
        If se = Params.SEVON Then
            WeadSEVON(mAxisNum, 1)
            Sleep(200)
            ' WeadSEVON(mAxisNum, Params.SEVON)
        Else
            'WeadSEVON(mAxisNum, 0)
            Sleep(50)
        End If

    End Sub

    ''' <summary>
    ''' 相对运动
    ''' </summary>
    ''' <param name="InVal">运动脉冲数</param>
    ''' <param name="WaitOver">是否超时等待，默认True（等待），false：不等待</param>
    ''' <returns>返回命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function MoveTofac(ByVal InVal As Single, Optional ByVal WaitOver As Boolean = False) As Boolean
        Try

            RunWait.WaitOne()
            InVal = PulTran(Params.RunComPare, InVal)

            If gratingd = True Then
                Frontcom = Command.MoveToABS
                mDisPulse = ReadPos(mAxisNum) + InVal
                AxisInfo.IsArr = False
                Return False
            End If
            If Pause Then
                Return False
            End If
            If AxisInfo.IsBusy = True Then

            End If

            AxisInfo.TimeOutWarm = False
            If SetCommand(Command.MoveToFAC, InVal) Then
                'Wr.WriteExceptionNote(mAxisNum & "轴相对运动，运动距离" & Pultranmm(Params.RunComPare, InVal) & "mm", "指令发送成功")
                Frontcom = Command.MoveToABS
                mCom = Command.MoveToFAC
                mDisPulse = ReadPos(mAxisNum) + InVal
                AxisInfo.IsArr = False
                'AxisInfo.IsBusy = 1
                Related(InVal)
                'Absolut(mDisPulse)
                Mcurstat = MotionState.MotionFAC

                If WaitOver Then
                    Dim param As New ArrayList
                    param.Add(WaitOver)
                    param.Add(RunParam.RunTime)
                    WaitThread = New Threading.Thread(AddressOf WaitTimeOut)
                    WaitThread.Start(param)
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            RunWait.ReleaseMutex()
        End Try

    End Function

    ''' <summary>
    ''' 相对运动
    ''' </summary>
    ''' <param name="InVal">目标位</param>
    ''' <param name="WaitOver">是否超时等待，默认True（等待），false：不等待</param>
    ''' <returns>返回命令发送是否成功</returns>
    ''' <remarks></remarks>
    ''' 
    Public Function MoveToabs(ByVal InVal As Single, Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            RunWait.WaitOne()
            InVal = PulTran(Params.RunComPare, InVal)
            'mDisPulse = InVal
            'AxisInfo.IsArr = False
          
            If gratingd = True Then
                AxisInfo.IsArr = False
                If GratFlag = False Then '只记住前一次指令，继续发送不保存
                    Frontcom = Command.MoveToABS
                    mDisPulse = InVal
                    GratFlag = True
                    Return True
                Else
                    Return False
                End If
            End If

            If Pause Then
                Return False
            End If

            If InVal = ReadPos(mAxisNum) Then
                mDisPulse = InVal
                Return True
            End If

            AxisInfo.TimeOutWarm = False
            Dim a As Command = mCom
            If SetCommand(Command.MoveToABS, InVal) Then
                'Wr.WriteExceptionNote(mAxisNum & "轴绝对运动，目标位置：" & Pultranmm(Params.RunComPare, InVal) & "mm", "指令发送成功")
                Frontcom = Command.MoveToABS
                mCom = Command.MoveToABS
                mDisPulse = InVal
                EXInfo = RunStatus.运动
                AxisInfo.IsArr = False
                ' AxisInfo.IsBusy = 1
                Absolut(mDisPulse)
                Mcurstat = MotionState.MotionABS

                If WaitOver Then
                    Dim param As New ArrayList
                    param.Add(WaitOver)
                    param.Add(RunParam.RunTime)
                    WaitThread = New Threading.Thread(AddressOf WaitTimeOut)
                    WaitThread.Start(param)
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            RunWait.ReleaseMutex()
        End Try
    End Function

    ''' <summary>
    ''' 持续运动
    ''' </summary>
    ''' <param name="WaitOver">超时是否等待，默认true等待，false不等待</param>
    ''' <returns>命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function K_Move(ByVal Dir As Byte, Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            If gratingd = True Then
                Return False
            End If
            If Pause Then
                Return False
            End If
            Keep = True
            AxisInfo.TimeOutWarm = False
            If SetCommand(Command.KeepMove) Then
                'Wr.WriteExceptionNote(mAxisNum & "轴持续运动", "指令发送成功")
                Frontcom = Command.KeepMove
                mCom = Command.KeepMove
                ' Move(RunParam.RunDir)
                ' AxisInfo.IsBusy = 1
                Move(Dir)
                Mcurstat = MotionState.MotionKeepMove
                '   EXInfo = RunStatus.运动
                AxisInfo.IsArr = False
                System.Threading.Thread.Sleep(100)
                If WaitOver Then
                    Dim param As New ArrayList
                    param.Add(WaitOver)
                    param.Add(RunParam.RunTime)
                    WaitThread = New Threading.Thread(AddressOf WaitTimeOut)
                    WaitThread.Start(param)
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    '''停止运动
    ''' </summary>
    ''' <param name="WaitOver">是否等待，默认True（等待），false：不等待</param>
    ''' <returns>返回命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function StopM(Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            If SetCommand(Command.StopMove) Then
                'Wr.WriteExceptionNote(mAxisNum & "轴停止运动", "指令发送成功")
                RunFlag = False
                mCom = Command.StopMove
                S()
                'mDisPulse = ReadPos(mAxisNum)
                Mcurstat = MotionState.MotionStopMove
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
        If Pause Then
            Return False
        End If
    End Function

    ''' <summary>
    '''减速停止
    ''' </summary>
    ''' <param name="WaitOver">是否等待，默认True（等待），false：不等待</param>
    ''' <returns>返回命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function DelStopM(Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            If Pause Then
                Return False
            End If

            If SetCommand(Command.DelSpeed) Then

                RunFlag = False
                mCom = Command.DelSpeed
                ReduceSpeedS(RunParam.Min_Vel * RunParam.ReduceRatio)
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 回原点
    ''' </summary>
    ''' <param name="WaitOver">是否等待，默认True（等待），false：不等待</param>
    ''' <returns>返回命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function GoHome(Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            'If Pause Then
            '    Return False
            'End If
            'If gratingd = True Then
            '    Return False
            'End If
            Pause = False
            If SetCommand(Command.Goback) Then
                mDisPulse = Org_Pos
                Frontcom = Command.Goback
                mCom = Command.Goback
                AxisInfo.IsArr = False
                IsOrg = True
                Console.WriteLine("当前轴目标>> " & mAxisNum & ",目标脉冲：" & mDisPulse)
                Dim Thread As Threading.Thread = New Threading.Thread(AddressOf BackH)
                Thread.Start()
                '  BackH()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''直接回原点
    ''' </summary>
    ''' <param name="WaitOver">是否等待，默认True（等待），false：不等待</param>
    ''' <returns>返回命令发送是否成功</returns>
    ''' <remarks></remarks>
    Private Function GOBack(Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            If gratingd = True Then
                Return False
            End If
            mDisPulse = Org_Pos
            IsOrg = True
            AxisInfo.IsArr = False

            ' SetTVel(mAxisNum, RunParam.Min_Vel, RunParam.OrgSpeed, RunParam.Tacc, RunParam.Tdec)
            AxisInfo.TimeOutWarm = False
            O(mAxisNum, Params.ORGDir + 1, Params.ORGSpeedMode)
            Mcurstat = MotionState.MotionComeback

            Sleep(50)
            Dim Count As Short = 0
            While ReadAxisRunStop(mAxisNum) <> 1
                If Count > 2500 Then
                    Throw New Exception("206091;" & XX复位超时_检查复位速度是否过低)
                End If
                If GetEMG Or GetSevn Then
                    Exit Function
                End If
                Sleep(20)
                Count += 1
            End While
            Sleep(10)
            If GetZEL Then
                Move(Params.LeaveDir)
                Count = 0
                While Not GetORG
                    If Count > 2500 Then
                        Throw New Exception("206091;" & XX复位超时_检查复位速度是否过低)
                    End If
                    If GetEMG Or GetSevn Then
                        Exit Function
                    End If
                    Sleep(20)
                    Count += 1
                End While
                Count = 0
                While GetORG
                    If Count > 2500 Then
                        Throw New Exception("206091;" & XX复位超时_检查复位速度是否过低)
                    End If
                    If GetEMG Or GetSevn Then
                        Exit Function
                    End If
                    Sleep(20)
                    Count += 1
                End While
                Sleep(800)
                S()
                Sleep(100)
                O(mAxisNum, Params.ORGDir + 1, Params.ORGSpeedMode)
            ElseIf GetFEL Then
                MsgBox("复位异常,走出原点时正极限光感感应！")
                Throw New Exception("复位异常,正极限光感感应！")
            End If

            'If WaitOver Then
            '    Dim param As New ArrayList
            '    param.Add(WaitOver)
            '    param.Add(RunParam.RunTime)
            '    WaitThread = New Threading.Thread(AddressOf WaitTimeOut)
            '    WaitThread.Start(param)
            'End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 改变速度，减速
    ''' </summary>
    ''' <param name="WaitOver">是否等待，默认True（等待），false：不等待</param>
    ''' <returns>返回命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function ChangeSpeed(ByVal Compaer As Single, Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            If Pause Then
                Return False
            End If
            ' mDelScale = Scale
            ' If SetCommand(Command.ChangeSpeed) Then
            'Wr.WriteExceptionNote(mAxisNum & " 轴变速", "指令发送成功")
            mCom = Command.ChangeSpeed
            ' ChangeSpeedNew(NowSpeed * RunParam.ReduceRatio)
            '  NowSpeed = ReadVel()
            ChangeSpeedNew(ReadVel() * Compaer)

            Mcurstat = MotionState.MotionCS
            Return True
            'Else
            'Return False
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 上电
    ''' </summary>
    ''' <param name="WaitOver">是否等待，默认True（等待），false：不等待</param>
    ''' <returns>返回命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function POW_T(Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            If Pause Then
                Return False
            End If
            AxisInfo.TimeOutWarm = False
            If SetCommand(Command.POW) Then
                'Wr.WriteExceptionNote(mAxisNum & " 轴上电", "指令发送成功")
                mCom = Command.POW
                Pow()
                Mcurstat = MotionState.MotionPOW
                'If WaitOver Then
                '    Dim param As New ArrayList
                '    param.Add(WaitOver)
                '    param.Add(RunParam.RunTime)
                '    WaitThread = New Threading.Thread(AddressOf WaitTimeOut)
                '    WaitThread.Start(param)
                'End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 读取当前脉冲
    ''' </summary>
    ''' <param name="WaitOver">是否等待，默认True（等待），false：不等待</param>
    ''' <returns>返回命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function ReadP(Optional ByVal WaitOver As Boolean = False) As Long
        Try
            Frontcom = Command.ReadPos
            If Pause Then
                Return False
            End If
            If SetCommand(Command.ReadPos, 0) Then
                'Wr.WriteExceptionNote(mAxisNum & " 轴读取当前脉冲", "指令发送成功")
                mCurPulse = Pultranmm(Params.RunComPare, ReadPos(mAxisNum))
                mCom = Command.ReadPos
                'If WaitOver Then
                '    Dim param As New ArrayList
                '    param.Add(WaitOver)
                '    param.Add(RunParam.RunTime)
                '    WaitThread = New Threading.Thread(AddressOf WaitTimeOut)
                '    WaitThread.Start(param)
                'End If
                Return mCurPulse
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 暂停
    ''' </summary>
    ''' <param name="Pmode">暂停模式（0—>减速停止，1—>减速停止直到运动完成）</param>
    ''' <param name="WaitOver">超时是否等待</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Paused(Optional ByVal Pmode As Byte = 0, Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            If Pause Then
                Return False
            End If
            mPmode = Pmode
            If SetCommand(Command.Pause) Then
                'Wr.WriteExceptionNote(mAxisNum & " 轴暂停", "指令发送成功")
                mCom = Command.Pause
                Pause = True
                If Math.Abs(mDisPulse - ReadPos(mAxisNum)) > 2000 Then
                    ReduceSpeedS(RunParam.Min_Vel / 3)
                End If
                'If WaitOver Then
                '    Dim param As New ArrayList
                '    param.Add(WaitOver)
                '    param.Add(RunParam.RunTime)
                '    WaitThread = New Threading.Thread(AddressOf WaitTimeOut)
                '    WaitThread.Start(param)
                'End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    ''' <summary>
    ''' 光栅处理
    ''' </summary>
    ''' <param name="WaitOver"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StarGra(Optional ByVal Inmode As gratingMode = gratingMode.减速停, Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            If gratingd = True Then
                Return False
            End If

            GrMode = Inmode
            gratingd = True
            mCom = Command.grating
            Select Case GrMode
                Case gratingMode.马上停 '马上停止,但是需要重新开始
                    S()
                    ' AxisInfo.IsBusy = False
                    AxisInfo.EmgWarm = True
                Case gratingMode.减速停 '跑完停下或者慢慢停下，需要重新开始
                    'If Math.Abs(mDisPulse - ReadPos(mAxisNum)) > 2000 Then
                    ReduceSpeedS(RunParam.Min_Vel * RunParam.ReduceRatio)
                    Dim a = mDisPulse
                    'End If
                Case gratingMode.减速
                    BackSpeed = ReadVel()
                    ChangeSpeedNew(ReadVel() * RunParam.ReduceRatio)
                Case gratingMode.不理
            End Select
            AxisInfo.GratWarm = True

            Return True
            ' Else
            '    Return False
            '  End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    ''' <summary>
    ''' 光栅离开
    ''' </summary>
    ''' <param name="WaitOver"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GratingsLeave(Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            If gratingd Then
                AxisInfo.GratWarm = False
                If Frontcom = Command.MoveToABS Or Frontcom = Command.MoveToFAC Then
                    Frontcom = Command.MoveToABS
                End If
                mCom = Command.Leave
                LeaveGra()
                'gratingd = False
                Return True
            Else
                Me.GoOn = 2
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 开始
    ''' </summary>
    ''' <param name="WaitOver">是否等待，默认True（等待），false：不等待</param>
    ''' <returns>返回命令发送是否成功</returns>
    ''' <remarks></remarks>
    Public Function Started(Optional ByVal WaitOver As Boolean = False) As Boolean
        Try
            If Pause Then
                Pause = False
            Else
                Return False
            End If

            If Frontcom = Command.MoveToABS Or Frontcom = Command.MoveToFAC Then
                Frontcom = Command.MoveToABS
            End If

            mCom = Command.Start
            Select Case Frontcom
                Case Command.MoveToABS '定长走绝对
                    MoveToabs(Pultranmm(Params.RunComPare, mDisPulse))
                Case Command.MoveToFAC
                    MoveToabs(mDisPulse)
                Case Command.Goback  '回原点
                    GoHome()
                Case Command.KeepMove '连续运动
                    K_Move(1)
            End Select

            Pause = False
            Return True

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function IsThere(ByVal InVal As Single) As Boolean
        Try
            Dim Dis As Long = PulTran(Params.RunComPare, InVal)
            If Dis = ReadPos(mAxisNum) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Sub Dispos()
        Me.Flag = False
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadPosition() As Single
        Return Pultranmm(Params.RunComPare, ReadPos(mAxisNum)) 'ReadPos(mAxisNum)
    End Function

    ''' <summary>
    ''' 无反相间隙的绝对运动
    ''' </summary>
    ''' <param name="InVal">目标位</param>
    ''' <param name="OffDis" >间隙补偿</param>
    ''' <param name="WaitOver">是否超时等待，默认True（等待），false：不等待</param>
    ''' <remarks></remarks>
    Public Sub _Move(ByVal InVal As Single, ByVal OffDis As Single, Optional ByVal WaitOver As Boolean = False)
        Try
            'If gratingd = True Then
            '    Return False
            'End If
            'If Pause Then
            '    Return False
            'End If

            Dim ABSThread As Threading.Thread
            OffDis = PulTran(Params.RunComPare, OffDis)
            InVal = PulTran(Params.RunComPare, InVal)
            AxisInfo.TimeOutWarm = False

            If InVal = ReadPos(mAxisNum) Then
                Exit Sub
            End If


            If InVal <= ReadPos(mAxisNum) Or OffDis <= 0 Then
                If SetCommand(Command.MoveToABS, InVal) Then

                    Frontcom = Command.MoveToABS
                    mCom = Command.MoveToABS
                    mDisPulse = InVal
                    AxisInfo.IsArr = False
                    '  AxisInfo.IsBusy = 1
                    Absolut(mDisPulse)
                    Mcurstat = MotionState.MotionABS

                    If WaitOver Then
                        Dim param As New ArrayList
                        param.Add(WaitOver)
                        param.Add(RunParam.RunTime)
                        WaitThread = New Threading.Thread(AddressOf WaitTimeOut)
                        WaitThread.Start(param)
                    End If
                Else

                End If
            Else
                Dim a As Long = InVal + OffDis
                Dim b As Long = InVal
                Dim List(1) As Long
                List(0) = a
                List(1) = b

                ABSThread = New Threading.Thread(AddressOf Run)
                ABSThread.Start(List)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Lock As New Threading.ManualResetEvent(False)
    Private RunFlag As Boolean

    Private Sub Run(ByVal list() As Long)
        Try
            Dim aDis As Long = list(0)
            Dim bDis As Long = list(1)
            '  RunFlag = True
            If SetCommand(Command.MoveToABS, aDis) Then
                RunFlag = True
                Frontcom = Command.MoveToABS
                mCom = Command.MoveToABS
                mDisPulse = aDis
                AxisInfo.IsArr = False
                ' AxisInfo.IsBusy = 1
                Absolut(mDisPulse)
                Mcurstat = MotionState.MotionABS

                Dim n As Byte = 0
                While ReadAxisRunStop(mAxisNum) = 0
                    n += 1
                    If n = 500 Then

                    End If
                    Sleep(100)
                End While
                Sleep(500)
                ChangeSpeedNew(ReadVel() * 0.5)
                Frontcom = Command.MoveToABS
                mCom = Command.MoveToABS
                mDisPulse = bDis
                AxisInfo.IsArr = False
                ' AxisInfo.IsBusy = 1
                Absolut(mDisPulse)
                Mcurstat = MotionState.MotionABS
                'Lock.Reset()
                'If Lock.WaitOne(10000, False) Then

                '    Frontcom = Command.MoveToABS
                '    mCom = Command.MoveToABS
                '    mDisPulse = bDis
                '    AxisInfo.IsArr = 0
                '    ' AxisInfo.IsBusy = 1
                '    Absolut(mDisPulse)
                '    Mcurstat = MotionState.MotionABS
                'Else

                'End If
            Else

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''读到位
    Public Function ReadArr(Optional ByVal Flag As Boolean = True) As Boolean
        Try
            If mAxisNum = 1 Then
                Dim a = 1
            End If
            If ReadAxisRunStop(mAxisNum) = 1 Then '轴运动停止
                If GetSevn Then
                    Return False
                End If
                If Flag Then
                    If mAxisNum = 0 Then
                        Dim a = ReadPos(mAxisNum)
                    End If

                    If Math.Abs(mDisPulse - ReadPos(mAxisNum)) <= 5 Then
                        ' Console.WriteLine("到位当前轴>> " & mAxisNum & ",当前脉冲：" & ReadPos(mAxisNum))
                        AxisInfo.IsArr = True '到位
                        EXInfo = RunStatus.停止
                        mCom = Command.Null
                        AxisInfo.IsBusy = False
                        Return True
                    Else
                        AxisInfo.IsArr = False
                        Return False
                    End If
                Else
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReadNowSpeed() As Single

        Return ReadVel()
    End Function

    ''' <summary>
    ''' 正极限信号
    ''' </summary>
    ''' <value>True时感应</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetZEL As Boolean
        Get
            Dim IOsignal As Long = ReadAxisStatu(mAxisNum)
            Dim strIO As String = Convert.ToString(IOsignal, 2)
            Select Case CartType
                Case "5600", "5800"
                    If Getstatus(strIO, 1, 16) = 1 Then
                        AxisInfo.ZJiXian = True
                        Return True
                    Else
                        AxisInfo.ZJiXian = False
                        Return False
                    End If
                Case Else
                    If Getstatus(strIO, 12, 16) = 1 Then  '正限位
                        AxisInfo.ZJiXian = True
                        Return True
                    Else
                        AxisInfo.ZJiXian = False
                        Return False
                    End If
            End Select
        End Get
    End Property

    ''' <summary>
    ''' 负极限信号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetINP() As Boolean
        Dim IOsignal As Long = BaseFun.GetRsts(mAxisNum) ' ReadAxisStatu(mAxisNum)
        Dim strIO As String = Convert.ToString(IOsignal, 2)
        If Getstatus(strIO, 2, 15) = 1 Then
            'AxisInfo.FJiXian = True
            Return True
        Else
            ' AxisInfo.FJiXian = False
            Return False
        End If
    End Function

    ''' <summary>
    ''' 负极限信号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetFEL As Boolean
        Get
            Dim IOsignal As Long = ReadAxisStatu(mAxisNum)
            Dim strIO As String = Convert.ToString(IOsignal, 2)
            Select Case CartType
                Case "5600", "5800"
                    If Getstatus(strIO, 2, 16) = 1 Then
                        AxisInfo.FJiXian = True
                        Return True
                    Else
                        AxisInfo.FJiXian = False
                        Return False
                    End If
                Case Else

                    If Getstatus(strIO, 13, 16) = 1 Then  '负限位
                        AxisInfo.FJiXian = True
                        Return True
                    Else
                        AxisInfo.FJiXian = False
                        Return False
                    End If
            End Select
        End Get
    End Property

    ''' <summary>
    ''' 伺服信号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetSevn As Boolean
        Get
            Dim IOsignal As Long = ReadAxisStatu(mAxisNum)
            Dim strIO As String = Convert.ToString(IOsignal, 2)
            Select Case CartType
                Case "5600", "5800"
                    If Getstatus(strIO, 0, 16) = 1 Then
                        AxisInfo.SiFuWarn = True
                        Return True
                    Else
                        AxisInfo.SiFuWarn = False
                        Return False
                    End If

                Case Else
                    If Getstatus(strIO, 11, 16) = 1 Then  '伺服报警
                        AxisInfo.SiFuWarn = True
                        Return True
                    Else
                        AxisInfo.SiFuWarn = False
                        Return False
                    End If

            End Select
        End Get
    End Property

    ''' <summary>
    ''' 急停信号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetEMG As Boolean
        Get
            Dim IOsignal As Long = ReadAxisStatu(mAxisNum)
            Dim strIO As String = Convert.ToString(IOsignal, 2)
            Select Case CartType
                Case "5600", "5800"
                    If Getstatus(strIO, 3, 16) = 1 Then
                        AxisInfo.EmgWarm = True
                        Return True
                    Else
                        AxisInfo.EmgWarm = False
                        Return False
                    End If
                Case Else
                    If Getstatus(strIO, 7, 32) = 1 Then  '急停
                        AxisInfo.EmgWarm = True
                        Return True
                    Else
                        AxisInfo.EmgWarm = False
                        Return False
                    End If
            End Select
        End Get
    End Property

    ''' <summary>
    ''' 原点信号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetORG As Boolean
        Get
            Dim IOsignal As Long = ReadAxisStatu(mAxisNum)
            Dim strIO As String = Convert.ToString(IOsignal, 2)
            Select Case CartType
                Case "5600", "5800"
                    If Getstatus(strIO, 4, 16) = 1 Then
                        AxisInfo.OrgIsOn = True
                        Return True
                    Else
                        AxisInfo.OrgIsOn = False
                        Return False
                    End If
                Case Else
                    If Getstatus(strIO, 14, 16) = 1 Then
                        AxisInfo.OrgIsOn = True
                        Return True
                    Else
                        AxisInfo.OrgIsOn = False
                        Return False
                    End If
            End Select
        End Get
    End Property

    Public ReadOnly Property GetEZ As Boolean
        Get
            Dim IOsignal As Long = ReadAxisStatu(mAxisNum)
            Dim strIO As String = Convert.ToString(IOsignal, 2)
            Select Case CartType
                Case "5600", "5800"
                    If Getstatus(strIO, 9, 16) = 1 Then
                        AxisInfo.EZ = True
                        Return True
                    Else
                        AxisInfo.EZ = False
                        Return False
                    End If
                Case Else
                    Return False
                    'If Getstatus(strIO, 14, 16) = 1 Then
                    '    AxisInfo.OrgIsOn = True
                    '    Return True
                    'Else
                    '    AxisInfo.OrgIsOn = False
                    '    Return False
                    'End If
            End Select
        End Get
    End Property
#End Region

#Region "私有函数"

    ''' <summary>
    ''' 超时或到位
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function WaitTimeOut(ByVal Param As ArrayList) As Boolean
        Try
            If Param(0) Then
                Me.mMoveWatiOne.Reset()

                If Me.mMoveWatiOne.WaitOne(Param(1) * 1000, False) Then
                    ''是否到位
                    '' AxisInfo.IsORC = 1 '到位
                    'If mDisPulse = ReadPos(mAxisNum) And ReadAxisRunStop(mAxisNum) = 1 Then
                    '    'Wr.WriteExceptionNote(mAxisNum & "轴运动到位", "到位信号发送")
                    '    AxisInfo.IsORC = 1 '到位
                    'Else
                    '    Console.WriteLine(mDisPulse & "  " & ReadPos(mAxisNum) & "  " & ReadAxisRunStop(mAxisNum))
                    'End If
                Else
                    AxisInfo.TimeOutWarm = 1 '超时
                    Return False
                End If

            End If

        Catch ex As Exception

        End Try
    End Function

    Private Function SetCommand(ByVal InCom As absMtAxis.Command, Optional ByVal InVal As Integer = 0) As Boolean
        'If ReadAxisRunStop(mAxisNum) = 0 Then
        '    'If InCom = Command.KeepMove Or InCom = Command.MoveToABS Or InCom = Command.MoveToFAC Or InCom = Command.Goback Then
        '    '    '后台繁忙
        '    '    'Wr.WriteExceptionNote(mAxisNum & "轴后台繁忙", "指令发送失败", mAxisNum.ToString & "轴")
        '    '    Return False
        '    'End If
        '    'Else
        '    '    Return False
        'End If
        Return True
    End Function

    'Private Sub InSpectStatus()
    '    Try
    '        While Flag

    '            Try
    '                GetAllAxisStatus()
    '                System.Threading.Thread.Sleep(1)
    '                If IsOrg And AxisInfo.OrgIsOn And ReadAxisRunStop(mAxisNum) = 1 Then
    '                    'If IsOrg Then
    '                    mDisPulse = Org_Pos
    '                    SetPos(mAxisNum, Org_Pos)
    '                    AxisInfo.IsArr = True
    '                    'End If
    '                    AxisInfo.EmgWarm = False
    '                    AxisInfo.IsBusy = False
    '                    IsOrg = False
    '                Else
    '                    If ReadAxisRunStop(mAxisNum) = 1 Then '轴运动停止
    '                        EXInfo = RunStatus.停止
    '                        If mCom <> Command.Goback Then
    '                            mCom = Command.Null
    '                            AxisInfo.IsBusy = False
    '                        End If
    '                        Dim i As Integer = ReadPos(mAxisNum)
    '                        If mDisPulse = ReadPos(mAxisNum) AndAlso mCom <> Command.Goback Then ' AndAlso mCom = Command.Null
    '                            AxisInfo.IsArr = True '到位
    '                        Else
    '                            AxisInfo.IsArr = False
    '                        End If

    '                        mMoveWatiOne.Set()
    '                        mCommWatiOne.Set()
    '                    Else
    '                        AxisInfo.IsArr = False
    '                        AxisInfo.IsBusy = True
    '                        EXInfo = RunStatus.运动
    '                    End If
    '                End If
    '            Catch ex As Exception

    '            End Try
    '        End While
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub BackH()
        Try
            If Params.ORGMode = 3 Then '只找EZ
                O(mAxisNum, Params.ORGDir + 1, Params.ORGSpeedMode)
            Else
                If GetORG Then '
                    mCom = Command.Goback
                    'Move(Params.LeaveDir)
                    'Move(1)
                    'If Me.mAxisNum > 1 Then
                    '    Related(PulTran(Params.RunComPare, 30)) '走出光感 ,20101013ljk
                    'Else
                    '    Related(PulTran(Params.RunComPare, 40)) '走出光感 ,20101013ljk
                    'End If
                    Move(1)
                    Sleep(300)
                    Dim short_i As Short = 0
                    Do Until Not GetORG
                        Sleep(15)
                        short_i += 1
                        If short_i > 600 Then
                            ReduceSpeedS(RunParam.Min_Vel * RunParam.ReduceRatio)
                            Exit Do
                        End If
                        If GetEMG Or GetSevn Then
                            Exit Sub
                        End If
                    Loop

                    If short_i > 600 Then
                        AxisInfo.TimeOutWarm = True
                        ReduceSpeedS(RunParam.Min_Vel * RunParam.ReduceRatio)
                        'S()
                    Else
                        ReduceSpeedS(RunParam.Min_Vel * RunParam.ReduceRatio)
                        'S()
                        short_i = 0
                        Sleep(20)
                        '   Console.WriteLine("当前轴>> " & mAxisNum & ",当前脉冲：" & ReadPos(mAxisNum))
                        Do Until ReadAxisRunStop(mAxisNum) = 1
                            short_i += 1
                            If short_i > 200 Then
                                AxisInfo.TimeOutWarm = True
                                Exit Do
                            End If
                            If GetEMG Or GetSevn Then
                                Exit Sub
                            End If
                            Sleep(20)
                        Loop
                        Sleep(150)
                        GOBack()
                        mCom = Command.Null
                        mDisPulse = Org_Pos
                    End If
                Else
                    GOBack()
                    mCom = Command.Null
                    mDisPulse = Org_Pos
                End If
            End If
            Dim T1 As Short = 0
            Do Until ReadAxisRunStop(mAxisNum) = 1
                If T1 > 6000 Then
                    S()
                    Exit Sub
                End If
                If GetEMG Or GetSevn Then
                    Exit Sub
                End If
                Sleep(10)
                T1 += 1
            Loop
            mDisPulse = Org_Pos
            SetPos(mAxisNum, Org_Pos)
            AxisInfo.IsArr = True
            AxisInfo.EmgWarm = False
            AxisInfo.IsBusy = False
            IsOrg = False
            mCom = Command.Null
        Catch ex As Exception
            ' Throw ex
        End Try

        '' ''mCom = Command.Goback
    End Sub
    ''当光删离开触发时，会恢复上一次的指令，碰巧遇到在发运动指令的时候会false,到位信号就还会有
    Private Sub LeaveGra() '光栅离开
        'GraWatiOne.Reset()

        Select Case GrMode
            Case gratingMode.马上停 '马上停止,但是需要重新开始
                AxisInfo.EmgWarm = True
                'If GraWatiOne.WaitOne(4000, False) Then
                '    '复位
                '    ' GOBack()
                'Else

                'End If
            Case gratingMode.减速停 '跑完停下或者慢慢停下，需要重新开始

                '选择复位或继续
                If GraWatiOne.WaitOne(-1, False) Then
                    If Me.GoOn = 1 Then
                        Me.GoOn = 2
                        gratingd = False
                        GratFlag = False
                        '继续跑
                        Select Case Frontcom
                            Case Command.MoveToABS '定长走绝对
                                ' Dim dis As Single = Pultranmm(Params.RunComPare, mDisPulse)
                                MoveToabs(Pultranmm(Params.RunComPare, mDisPulse))
                            Case Command.MoveToFAC
                                MoveToabs(Pultranmm(Params.RunComPare, mDisPulse))
                            Case Command.Goback  '回原点
                                ' GoHome()
                            Case Command.KeepMove '连续运动
                                '  K_Move(1)

                        End Select

                    ElseIf GoOn = 0 Then
                        Me.GoOn = 2
                        gratingd = False
                        GratFlag = False
                        mDisPulse = ReadPos(mAxisNum)
                    End If
                End If
            Case gratingMode.减速

                '保持低速或恢复速度
                If GraWatiOne.WaitOne(-1, False) Then

                    If GoOn Then
                        '继续，恢复速度
                        ChangeSpeedNew(BackSpeed)
                    Else
                        '保持低速
                    End If

                End If
            Case gratingMode.不理

        End Select
        'If GoOn = 1 Then
        '  
        'End If

        GraWatiOne.Reset()
    End Sub
#End Region

#Region "调用运动底层函数"

    Protected Overrides Function E(ByVal index As Byte) As Short

    End Function
    Protected Overloads Overrides Sub P(ByVal Param As absMtAxis.AxisParam, ByVal RunP As absMtAxis._RunParam)
        Try
            Me.Params = Param
            SDpin(mAxisNum, Params.SDEnable, Params.SDSignal, Params.SDMode) '减速信号（这里设置为Params.SDEnable0无效，Params.SDSignal, Params.SDMode都设置为0）
            PCSpin(mAxisNum, Params.PCSEnable, Params.PCSSignal) '设置允许/禁止 PCS 外部信号在运动中改变目标位置（ Params.PCSEnable, Params.PCSSignal设置为1,0）
            Pulseout(mAxisNum, Params.PulseMode) '设置指定轴的脉冲输出模式（Params.PulseMode设置为0脉冲/方向，PULn-信号上升有效）
            INPpin(mAxisNum, Params.INPEable, Params.INPSignal) '设置允许/禁止 INP 信号及其有效的逻辑电平，伺服定位完成（Params.INPEable, Params.INPSignal设置1,0低电平有效）
            ERCpin(mAxisNum, Params.ERCMode, Params.ERCSignal, Params.ERCWidth, Params.ERCOfftime) '设置误差清除信号（Params.ERCMode, Params.ERCSignal, Params.ERCWidth, Params.ERCOfftime设置为1,0,30,20）
            BaseFun.WriteERC(mAxisNum, Params.ERCsel) '控制指定轴“误差清除”端子信号的输出（Params.ERCsel设置为0，复位ERCsel信号）

            ALMpin(mAxisNum, Params.ALMSignal, Params.ALMStopMode) '设置 ALM 的逻辑电平及其工作方式（Params.ALMSignal, Params.ALMStopMode设置0,0,低电平有效，立即停止）
            EL(mAxisNum, Params.ELMode) '设置EL信号的有效电平及制动方式，0－立即停、低有效，1－减速停、低有效，2－立即停、高有效，3－减速停、高有效（设置ELMode为0）
            EZ(mAxisNum, Params.EZSignal, Params.EZMode) '设置指定轴的EZ信号的有效电平及其作用（ Params.EZSignal, Params.EZMode设置为0,0低电平，无效）
            'LTC(mAxis, Params.LTCSignal, Params.LTCMode) '设置指定轴锁存信号的有效电平。（Params.LTCSignal, Params.LTCMode设置为0,0）
            HOME(mAxisNum, Params.ORGSignal, Params.ORGFilter) '设置ORG信号的有效电平，以及允许/禁止滤波功能（Params.ORGSignal, Params.ORGFilter设置为0,1低电平有效且滤波）
            'SEVON(mAxis, Params.SEVON) '输出对指定轴的伺服使能端子的控制（Params.SEVON设置为0）
            Counter(mAxisNum, Params.CounterMode) '编码器计数方式（ Params.CounterMode设置为0）
            If Params.ORGMode = 2 Then '反找EZ
                Select Case CartType
                    Case "5600", "5800"
                        HMode(mAxisNum, Params.ORGMode, 5) '设定回原点模式（ Params.ORGMode, Params.ORGEZNo设置为0,1）
                    Case Else
                        HMode(mAxisNum, Params.ORGMode, Params.ORGEZNo) '设定回原点模式（ Params.ORGMode, Params.ORGEZNo设置为0,1）
                End Select
            ElseIf Params.ORGMode = 3 Then '单找EZ模式
                EZ(mAxisNum, Params.EZSignal, 1)
                HMode(mAxisNum, 4, Params.ORGEZNo) '设定回原点模式（ Params.ORGMode, Params.ORGEZNo设置为0,1）
            Else
                HMode(mAxisNum, Params.ORGMode, Params.ORGEZNo) '设定回原点模式（ Params.ORGMode, Params.ORGEZNo设置为0,1）
            End If

            '' '' '' ''ReadRDY(mAxis) '读取指定运动轴的“伺服准备好”端子的电平状态,不能再初始化轴里面用，必须放在程序上电里面。
            '' '' '' ''ConfigEMG(0, 0, 0) 'EMG 信号设置，急停信号有效后会立即停止所有轴'这个急停信号不能放在这里 需要整体对卡的设置 不是对轴的设置
            ' '' '' ''writeSEVON(mAxis, Params.SEVON) '输出对指定轴的伺服使能端子的控制（Params.SEVON设置为0）
            BaseFun.WriteERC(mAxisNum, 0)
            'LTC(mAxisNum, )

            'BaseFun.SetHandwheelInmode(mAxisNum, 1, 3)
            'BaseFun.HandwheelMove(mAxisNum, 10000)
            If mAxisNum = 0 Then
                'BaseFun.ConfigCMP(mAxisNum, 1, 1, 1)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ReSetRunP(ByVal RunP As absMtAxis._RunParam, Optional ByVal ThrowEr As Boolean = False)

        RunParam.Max_Vel = PulTran(Params.RunComPare, RunP.Max_Vel) 'RunP.Max_Vel / Params.RunComPare * 10000
        RunParam.Min_Vel = PulTran(Params.RunComPare, RunP.Min_Vel) ' RunP.Min_Vel / Params.RunComPare * 10000
        RunParam.Sacc = PulTran(Params.RunComPare, RunP.Sacc) ' RunP.Sacc / Params.RunComPare * 10000
        RunParam.Sdec = PulTran(Params.RunComPare, RunP.Sdec) 'RunP.Sdec / Params.RunComPare * 10000
        RunParam.Tacc = RunP.Tacc
        RunParam.Tdec = RunP.Tdec
        'RunParam.Home_Dis = RunP.Home_Dis
        RunParam.RunDir = RunP.RunDir
        RunParam.OrgSpeed = PulTran(Params.RunComPare, RunP.OrgSpeed) 'RunP.OrgSpeed / Params.RunComPare * 10000
        RunParam.RunTime = RunP.RunTime
        RunParam.ReduceRatio = RunP.ReduceRatio
        RunParam.RightLimit = PulTran(Params.RunComPare, RunP.RightLimit) 'RunP.RightLimit / Params.RunComPare * 10000
        RunParam.LeftLimit = PulTran(Params.RunComPare, RunP.LeftLimit) ' RunP.LeftLimit / Params.RunComPare * 10000
        Try
            If ReadAxisRunStop(mAxisNum) <> 1 Then
                Throw New Exception(XX速度发送失败)
            End If
            BaseFun.VarietySpeed(mAxisNum, 0, RunParam.Max_Vel * 15)
            If Params.SorT = 0 Then
                SetSTVel(mAxisNum, RunParam.Min_Vel, RunParam.Max_Vel, RunParam.Tacc, RunParam.Tdec)
            End If
            If Params.SorT = 1 Then
                SetTVel(mAxisNum, RunParam.Min_Vel, RunParam.Max_Vel, RunParam.Tacc, RunParam.Tdec)
            End If
        Catch ex As Exception
            If ThrowEr Then
                Throw ex
            End If
        End Try

    End Sub

    Public Function GetRunCompare() As Single
        Return Params.RunComPare
    End Function

    Public Function ReadSD() As Byte
        Dim IOsignal As Long = ReadAxisStatu(mAxisNum)
        Dim strIO As String = Convert.ToString(IOsignal, 2)
        Return Getstatus(strIO, 15, 16)
    End Function

    Public Sub SetEncode(ByVal Ini As Single)
        Dim dis As Int32 = PulTran(Params.RunComPare, Ini)
        BaseFun.SetEncode(mAxisNum, dis)
    End Sub

    Public Function GetEncode(Optional ByVal Plus As Boolean = True) As Single
        Try
            If Params.EncodeMode = 0 Then '正计数
                If Plus Then
                    Return BaseFun.GetEncoder(mAxisNum)
                Else
                    Dim Dis As Single = Pultranmm(Params.RunComPare, BaseFun.GetEncoder(mAxisNum))
                    Return Dis
                End If
            Else '负计数
                If Plus Then
                    Return -BaseFun.GetEncoder(mAxisNum)
                Else
                    Dim Dis As Single = -Pultranmm(Params.RunComPare, BaseFun.GetEncoder(mAxisNum))
                    Return Dis
                End If
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Sub ReSetBaseParam(ByVal Param As absMtAxis.AxisParam)
        Try
            P(Param, Nothing)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ReSetHandP(ByVal AxisNumber As Byte, ByVal AxisMode As Byte, ByVal DirMode As Byte)
        Try
            BaseFun.SetHandwheelInmode(AxisNumber, AxisMode, DirMode)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetHandSpeed(ByVal AxisNumber As Byte, ByVal AxisHandSpeed As Integer)
        Try
            BaseFun.HandwheelMove(AxisNumber, AxisHandSpeed)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Overrides Function Pow() As Boolean '上电
        Dim se As Int32 = ReaSEVON(mAxisNum)
        If se = Params.SEVON Then
            WeadSEVON(mAxisNum, 1)
            Sleep(200)
            WeadSEVON(mAxisNum, Params.SEVON)
        Else
            WeadSEVON(mAxisNum, 0)
            Sleep(50)
        End If
        Sleep(20)
        Dim sevRDY As Int32 = BaseFun.ReadRDY(mAxisNum)
        If sevRDY = Params.ReySig Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Overrides Sub ChangeSpeedNew(ByVal NewSpeed As Double) '改变速度
        BaseFun.VarietySpeed(mAxisNum, 1, NewSpeed)
        If NewSpeed = 0 Then
            Exit Sub
        End If
        BaseFun.ChangeSpeed(mAxisNum, NewSpeed)
    End Sub

    Protected Overrides Sub M(ByVal pulse As Integer, ByVal pulsModes As Short) '走定长
        If Params.SorT = 0 Then
            ' SetSTVel(mAxisNum, RunParam.Min_Vel, RunParam.Max_Vel, RunParam.Tacc, RunParam.Tdec)
            If ReadAxisRunStop(mAxisNum) = 1 Then
                SPSmove(mAxisNum, pulse, pulsModes)
            End If
        End If
        If Params.SorT = 1 Then
            ' SetTVel(mAxisNum, RunParam.Min_Vel, RunParam.Max_Vel, RunParam.Tacc, RunParam.Tdec)
            If ReadAxisRunStop(mAxisNum) = 1 Then
                TPTmove(mAxisNum, pulse, pulsModes)
            End If
        End If
    End Sub

    Protected Overrides Sub Absolut(ByVal DisPulse As Long) '定长走绝对

        If Params.SorT = 0 Then
            '   SetSTVel(mAxisNum, RunParam.Min_Vel, RunParam.Max_Vel, RunParam.Tacc, RunParam.Tdec)
            If ReadAxisRunStop(mAxisNum) = 1 Then
                SPSmove(mAxisNum, DisPulse, ABS)
            Else
                Dim i As Byte = 1
            End If
        End If
        If Params.SorT = 1 Then
            '  SetTVel(mAxisNum, RunParam.Min_Vel, RunParam.Max_Vel, RunParam.Tacc, RunParam.Tdec)
            'If ReadAxisRunStop(mAxisNum) = 1 Then
            '    TPTmove(mAxisNum, DisPulse, ABS)
            'Else
            '    Dim i As Byte = 1
            'End If
            TPTmove(mAxisNum, DisPulse, ABS)
        End If
    End Sub

    Protected Overrides Sub Related(ByVal DisPulse As Long) '定长走相对
        If Params.SorT = 0 Then
            'SetSTVel(mAxisNum, RunParam.Min_Vel, RunParam.Max_Vel, RunParam.Tacc, RunParam.Tdec)
            If ReadAxisRunStop(mAxisNum) = 1 Then
                SPSmove(mAxisNum, DisPulse, FAC)
            Else
                Dim i As Byte = 1
            End If
        End If
        If Params.SorT = 1 Then
            ' SetTVel(mAxisNum, RunParam.Min_Vel, RunParam.Max_Vel, RunParam.Tacc, RunParam.Tdec)
            ' If ReadAxisRunStop(mAxisNum) = 1 Then
            TPTmove(mAxisNum, DisPulse + ReadPos(mAxisNum), ABS)
            'End If
        End If
    End Sub

    Protected Overrides Sub Move(ByVal dirt As Short) '持续走位
        If Params.SorT = 0 Then
            '  SetSTVel(mAxisNum, RunParam.Min_Vel, RunParam.Max_Vel, RunParam.Tacc, RunParam.Tdec)
            If ReadAxisRunStop(mAxisNum) = 1 Then
                SVSmove(mAxisNum, dirt)
            End If
        End If
        If Params.SorT = 1 Then
            '  SetSTVel(mAxisNum, RunParam.Min_Vel, RunParam.Max_Vel, RunParam.Tacc, RunParam.Tdec)
            If ReadAxisRunStop(mAxisNum) = 1 Then
                TVTmove(mAxisNum, dirt)
            End If
        End If
    End Sub

    Protected Overrides Sub WeadSEVON(ByVal axis As Byte, ByVal on_off As Short) '写入上电函数
        BaseFun.writeSEVON(axis, on_off)
    End Sub

    Protected Overrides Function ReaSEVON(ByVal axis As Byte) As Int32 '读取上电状态
        Return BaseFun.ReadSEVON(axis)
    End Function

    Protected Overrides Function ReaRDY(ByVal axis As Byte) As Int32 '读取准备好信号
        Return BaseFun.ReadRDY(axis)
    End Function

    Protected Overrides Sub H(ByVal axis As Int16, ByVal Home_ORGDir As Int16, ByVal Home_SepMode As Int16, ByVal Home_Diss As Int32) '回原点
        Dim n As Byte = 0

        If AxisInfo.OrgIsOn And ReadAxisRunStop(mAxisNum) = 1 Then
            'Dim ji As Int32 = ReadPos(mAxis)
            Me.M(Home_Diss, 0)
            Sleep(5)

            Do While ReadAxisRunStop(mAxisNum) = 1
                Sleep(100)

                n += 1
                If n > 150 Then
                    S()
                End If
            Loop
            Sleep(1000)
            O(mAxisNum, Params.ORGDir + 1, Home_SepMode)
        Else
            O(mAxisNum, Params.ORGDir + 1, Home_SepMode)
        End If
    End Sub

    Protected Overrides Sub SVSmove(ByVal axis As Int16, ByVal Dir As Int16) 'S连续
        BaseFun.SVmove(axis, Dir)
    End Sub

    Protected Overrides Sub TVTmove(ByVal axis As Int16, ByVal Dir As Int16) 'T连续
        BaseFun.TVmove(axis, Dir)
    End Sub

    Protected Overrides Sub SPSmove(ByVal axis As Int16, ByVal Dist As Long, ByVal posi_mode As Int16) 'S型定长运动
        BaseFun.SPmove(axis, Dist, posi_mode)
    End Sub

    Protected Overrides Sub TPTmove(ByVal axis As Int16, ByVal Dist As Long, ByVal posi_mode As Int16) 'T型定长运动
        BaseFun.TPmove(axis, Dist, posi_mode)
    End Sub


    Protected Overrides Sub O(ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16) '回原点
        BaseFun.HomeMove(axis, home_mode, vel_mode)
    End Sub

    Protected Overrides Function ReadOutIO(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
        Return BaseFun.ReadOutbit(cardno, BitNo)
    End Function


    Protected Overrides Function ReadInIO(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
        Return BaseFun.ReadInbit(cardno, BitNo)
    End Function

    Protected Overrides Sub WriteOutIO(ByVal cardno As Int16, ByVal BitNo As Int16, ByVal on_off As Int16)
        BaseFun.WriteOutbit(cardno, BitNo, on_off)
    End Sub


    Protected Overrides Function ReadAxisRunStop(ByVal AxisNum As Short) As Int16
        Return BaseFun.GetCheckDone(AxisNum)
    End Function

    Protected Overrides Function ReadAxisStatu(ByVal AxisNum As Short) As Long
        Return BaseFun.GetIoStatus(AxisNum)
    End Function

    Protected Overrides Function ReadOtherStatu(ByVal axisnum As Short) As Int32
        Try
            Return BaseFun.GetRsts(axisnum)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Protected Overrides Sub WriteCMPOnOff(ByVal OnOrOff As Byte)
        Try
            BaseFun.WriteCMP(mAxisNum, OnOrOff)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 比较器触发条件
    ''' </summary>
    ''' <param name="cmp1_mode">比较器1比较模式，0关闭比较器，1= ，2小于设定值，3,大于</param>
    ''' <param name="cmp2_mode">比较器2比较模式，0关闭比较器，1= ，2小于设定值，3,大于</param>
    ''' <remarks></remarks>
    Protected Overrides Sub SetCMPTrggerMode(ByVal cmp1_mode As Int16, ByVal cmp2_mode As Int16)
        BaseFun.ConfigComparator(mAxisNum, cmp1_mode, cmp2_mode, 0, 0)
    End Sub
    ''' <summary>
    ''' 设置CMP 比较值
    ''' </summary>
    ''' <param name="CMPData1">比较位置1</param>
    ''' <param name="CMPData2">比较位置2</param>
    ''' <remarks></remarks>
    Protected Overrides Sub SetCMPData(ByVal CMPData1 As Int32, ByVal CMPData2 As Int32)
        BaseFun.SetComparatorData(mAxisNum, CMPData1, CMPData2)
    End Sub

    Protected Overrides Function ReadEncoder(ByVal AxisNum As Short) As Integer
        Return BaseFun.GetEncoder(AxisNum)
    End Function

    Protected Overrides Function ReadPos(ByVal AxisNum As Short) As Long '读取当前值
        Return BaseFun.GetPosition(AxisNum)
    End Function

    Protected Overrides Sub SetPos(ByVal axis As Int16, ByVal pulse As Integer) '设置当前值
        BaseFun.SetPosition(mAxisNum, pulse)
    End Sub

    Protected Overrides Function ReadVel() As Single
        Return (BaseFun.ReadCurrentSpeed(mAxisNum))
    End Function

    Protected Overrides Sub S() '停止运动
        BaseFun.ImdStop(mAxisNum)
    End Sub

    Protected Overrides Sub ReduceSpeedS(ByVal Tdec As Integer) '减速停止
        BaseFun.DecelStop(mAxisNum, Tdec)
    End Sub

    Protected Overrides Sub SetEncoder(ByVal value As Integer)
        BaseFun.SetEncode(mAxisNum, value)
    End Sub

    Protected Overrides Sub SetTVel(ByVal mAxis As Short, ByVal MinVel As Double, ByVal MaxVel As Double, ByVal AccTm As Double, ByVal DecTm As Double) '设置T型速度
        BaseFun.SetProfile(mAxis, MinVel, MaxVel, AccTm, DecTm)
    End Sub

    Protected Overrides Sub SetSVel(ByVal mAxis As Short, ByVal MinVel As Double, ByVal MaxVel As Double, ByVal AccTm As Double, ByVal DecTm As Double, ByVal Sacc As Integer, ByVal Sdec As Integer) '设置S型速度
        BaseFun.SetSProfile(mAxis, MinVel, MaxVel, AccTm, DecTm, Sacc, Sdec)
    End Sub

    Protected Overrides Sub SetSTVel(ByVal mAxis As Short, ByVal MinVel As Double, ByVal MaxVel As Double, ByVal AccTm As Double, ByVal DecTm As Double) '设置S1型速度
        BaseFun.SetSTProfile(mAxis, MinVel, MaxVel, AccTm, DecTm)
    End Sub

    ' 设置EL信号的有效电平及制动方式
    Protected Overrides Sub EL(ByVal axis As Short, ByVal el_mode As Short)
        BaseFun.ELMODE(axis, el_mode)
    End Sub

    ' 设置指定轴的EZ信号的有效电平及其作用
    Protected Overrides Sub EZ(ByVal axis As Int16, ByVal ez_logic As Int16, ByVal ez_mode As Int16)
        BaseFun.Config_EZ(axis, ez_logic, ez_mode)
    End Sub

    ' 设置指定轴锁存信号的有效电平
    Protected Overrides Sub LTC(ByVal axis As Short, ByVal ltc_logic As Short, ByVal ltc_mode As Short)
        BaseFun.ConfigLTC(axis, ltc_logic, ltc_mode)
    End Sub

    ' 设置ORG信号的有效电平，以及允许/禁止滤波功能
    Protected Overrides Sub HOME(ByVal axis As Int16, ByVal org_logic As Int16, ByVal filter As Int16)
        BaseFun.SetHome(axis, org_logic, filter)
    End Sub

    ' 输出对指定轴的伺服使能端子的控制
    Protected Overrides Sub SEVON(ByVal axis As Int16, ByVal on_off As Int16)
        BaseFun.writeSEVON(axis, on_off)
    End Sub

    ' 编码器计数方式
    Protected Overrides Sub Counter(ByVal axis As Int16, ByVal mode As Int16)
        BaseFun.CounterConfig(axis, mode)
    End Sub

    ' 设定回原点模式
    Protected Overrides Sub HMode(ByVal axis As Short, ByVal mode As Short, ByVal EZ_count As Short)
        BaseFun.HomeMode(axis, mode, EZ_count)
    End Sub

    ' 设置SD信号有效的逻辑电平及其工作方式
    Protected Overrides Sub SDpin(ByVal axis As Int16, ByVal enable As Int16, ByVal sd_logic As Int16, ByVal sd_mode As Int16)
        BaseFun.SD(axis, enable, sd_logic, sd_mode)
    End Sub

    ' 设置允许/禁止PCS外部信号在运动中改变目标位置
    Protected Overrides Sub PCSpin(ByVal axis As Int16, ByVal enable As Int16, ByVal pcs_logic As Int16)
        BaseFun.PCS(axis, enable, pcs_logic)
    End Sub

    ' 设置指定轴的脉冲输出方式
    Protected Overrides Sub Pulseout(ByVal axis As Int16, ByVal outmode As Int16)
        BaseFun.PulseOutmode(axis, outmode)
    End Sub

    ' 设置允许/禁止INP信号及其有效的逻辑电平
    Protected Overrides Sub INPpin(ByVal axis As Int16, ByVal enable As Int16, ByVal inp_logic As Int16)
        BaseFun.INP(axis, enable, inp_logic)
    End Sub

    ' 设置允许/禁止ERC信号及其有效电平和输出方式
    Protected Overrides Sub ERCpin(ByVal axis As Int16, ByVal enable As Int16, ByVal erc_logic As Int16, ByVal erc_width As Int16, ByVal erc_off_time As Int16)
        BaseFun.ERC(axis, enable, erc_logic, erc_width, erc_off_time)
    End Sub

    ' 设置ALM的逻辑电平及其工作方式
    Protected Overrides Sub ALMpin(ByVal axis As Int16, ByVal alm_logic As Int16, ByVal alm_action As Int16)
        BaseFun.ALM(axis, alm_logic, alm_action)
    End Sub
    Public Sub GetAllAxisStatus()
        Try
            Dim IOsignal As Long = ReadAxisStatu(mAxisNum)
            Dim strIO As String = Convert.ToString(IOsignal, 2)
            Select Case CartType
                Case "5600", "5800"
                    If Getstatus(strIO, 0, 16) = 1 Then
                        AxisInfo.SiFuWarn = True
                    Else
                        AxisInfo.SiFuWarn = False
                    End If
                    If Getstatus(strIO, 1, 16) = 1 Then
                        AxisInfo.ZJiXian = True
                    Else
                        AxisInfo.ZJiXian = False
                    End If
                    If Getstatus(strIO, 2, 16) = 1 Then
                        AxisInfo.FJiXian = True
                    Else
                        AxisInfo.FJiXian = False
                    End If
                    If Getstatus(strIO, 3, 16) = 1 Then
                        AxisInfo.EmgWarm = True
                    Else
                        AxisInfo.EmgWarm = False
                    End If
                    If Getstatus(strIO, 4, 16) = 1 Then
                        AxisInfo.OrgIsOn = True
                    Else
                        AxisInfo.OrgIsOn = False
                    End If
                    'If Getstatus(strIO, 8, 16) = 1 Then
                    '    AxisInfo.IsArr = True
                    'Else
                    '    AxisInfo.IsArr = False
                    'End If
                Case Else
                    If Getstatus(strIO, 14, 16) = 1 Then
                        AxisInfo.OrgIsOn = True
                    Else
                        AxisInfo.OrgIsOn = False
                    End If
                    If Getstatus(strIO, 11, 16) = 1 Then  '伺服报警
                        AxisInfo.SiFuWarn = True
                    Else
                        AxisInfo.SiFuWarn = False
                    End If
                    If Getstatus(strIO, 12, 16) = 1 Then  '正限位
                        AxisInfo.ZJiXian = True
                    Else
                        AxisInfo.ZJiXian = False
                    End If
                    If Getstatus(strIO, 13, 16) = 1 Then  '负限位
                        AxisInfo.FJiXian = True
                    Else
                        AxisInfo.FJiXian = False
                    End If

                    IOsignal = ReadOtherStatu(mAxisNum)
                    strIO = Convert.ToString(IOsignal, 2)
                    If Getstatus(strIO, 7, 32) = 1 Then  '急停
                        AxisInfo.EmgWarm = True
                    Else
                        AxisInfo.EmgWarm = False
                    End If
                    'If Getstatus(strIO, 15, 32) = 1 Then  '到位
                    '    AxisInfo.IsArr = True
                    'Else
                    '    AxisInfo.IsArr = False
                    'End If
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function Getstatus(ByVal strBinWord As String, ByVal Index As Byte, ByVal bitCount As Byte) As Byte
        Dim str As String = Trim(strBinWord)
        If Len(str) < bitCount Then
            Dim length = bitCount - Len(str)
            Dim i As Int16
            For i = 1 To length Step 1
                str = "0" & str
            Next
        End If
        Return Mid(str, Len(str) - Index, 1)
    End Function
#End Region

#Region "脉冲--传动比转化函数(脉冲数转化成um)"
    ''' <summary>
    ''' 脉冲--转动比转化函数(mm转化为脉冲数)
    ''' </summary>
    ''' <param name="Compare">比例</param>
    ''' <param name="distance">距离</param>
    ''' <returns>脉冲</returns>
    ''' <remarks></remarks>
    Public Function PulTran(ByVal Compare As Double, ByVal distance As Single) As Long
        'If Compare = 0 Then
        '    Return 0
        'End If
        'If mAxisNum = 4 Then
        '    Return distance / Compare * 6400
        'End If
        'If mAxisNum = 3 Then
        '    Return distance / Compare * 100000
        'End If
        'Return distance / Compare * 10000
        Return distance / Compare * Params.MotorCount
    End Function

    Public Function Pultranmm(ByVal Compare As Double, ByVal Inpule As Long) As Single
        'If mAxisNum = 4 Then
        '    Return Inpule * Compare / 6400
        'End If
        'If mAxisNum = 3 Then
        '    Return Inpule * Compare / 100000
        'End If
        'Return Inpule * Compare / 10000
        Return Inpule * Compare / Params.MotorCount
    End Function
#End Region

End Class
