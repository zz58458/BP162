Public MustInherit Class absMtAxis



    ''' <summary>
    ''' 初始化轴参数
    ''' </summary>
    ''' <param name="Params">参数</param>
    ''' <remarks></remarks>
    Protected MustOverride Overloads Sub P(ByVal Params As AxisParam, ByVal RunP As absMtAxis._RunParam)

    ''' <summary>
    ''' 设置T速度
    ''' </summary>
    ''' <param name="MinVel">起始速度</param>
    ''' <param name="MaxVel">运行速度</param>
    ''' <param name="AccTm">加速时间</param>
    ''' <param name="DecTm">减速时间</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetTVel(ByVal axis As Int16, ByVal MinVel As Double, ByVal MaxVel As Double, ByVal AccTm As Double, ByVal DecTm As Double)

    ''' <summary>
    ''' 设置S速度
    ''' </summary>
    ''' <param name="MinVel">起始速度</param>
    ''' <param name="MaxVel">运行速度</param>
    ''' <param name="AccTm">加速时间</param>
    ''' <param name="DecTm">减速时间</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetSVel(ByVal axis As Int16, ByVal MinVel As Double, ByVal MaxVel As Double, ByVal AccTm As Double, ByVal DecTm As Double, ByVal Sacc As Integer, ByVal Sdec As Integer)

    ''' <summary>
    ''' 设置S速度
    ''' </summary>
    ''' <param name="MinVel">起始速度</param>
    ''' <param name="MaxVel">运行速度</param>
    ''' <param name="AccTm">加速时间</param>
    ''' <param name="DecTm">减速时间</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetSTVel(ByVal axis As Int16, ByVal MinVel As Double, ByVal MaxVel As Double, ByVal AccTm As Double, ByVal DecTm As Double)

    ''' <summary>
    ''' 设置位置
    ''' </summary>
    ''' <param name="pulse">脉冲位置</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetPos(ByVal axis As Int16, ByVal pulse As Integer)

    ''' <summary>
    ''' 单轴回原点
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub H(ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16, ByVal dis As Int32)

    ''' <summary>
    ''' 单轴初始化
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="home_mode"></param>
    ''' <param name="vel_mode"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub O(ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16)

    ''' <summary>
    ''' 单轴定长走位
    ''' </summary>
    ''' <param name="pulse">脉冲数量</param>
    ''' <param name="pulsMode">运动模式：0表示相对；1表示绝对</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub M(ByVal pulse As Integer, ByVal pulsMode As Short)

    ''' <summary>
    ''' 走绝对
    ''' </summary>
    ''' <param name="pulse"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub Absolut(ByVal pulse As Long)

    ''' <summary>
    ''' 走相对
    ''' </summary>
    ''' <param name="DisPulse"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub Related(ByVal DisPulse As Long)

    ''' <summary>
    ''' 单轴持续走位
    ''' </summary>
    ''' <param name="dirt">方向选择：0表示负方向；1表示正方向</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub Move(ByVal dirt As Short)

    ''' <summary>
    ''' 停止走位
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub S()

    ''' <summary>
    ''' 读取当前脉冲值
    ''' </summary>
    ''' <returns>返回当前脉冲值</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadPos(ByVal AxisNum As Short) As Long

    ''' <summary>
    ''' 改变速度
    ''' </summary>
    ''' <param name="NewSpeed"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub ChangeSpeedNew(ByVal NewSpeed As Double)


    ''' <summary>
    ''' 读取当前速度
    ''' </summary>
    ''' <returns>返回当前速度</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadVel() As Single


    ''' <summary>
    ''' 减速停止
    ''' </summary>
    ''' <param name="Tdec"></param>减速时间
    ''' <remarks></remarks>
    Protected MustOverride Sub ReduceSpeedS(ByVal Tdec As Integer) '减速停止

    ''' <summary>
    ''' 读取编码器值
    ''' </summary>
    ''' <returns>返回编码器值</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadEncoder(ByVal AxisNum As Short) As Int32

    ''' <summary>
    ''' 设置编码器值
    ''' </summary>
    ''' <param name="value">设置值</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetEncoder(ByVal value As Integer)

    ''' <summary>
    ''' 读取轴外部的信号状态 急停，减速，到位等
    ''' </summary>
    ''' <returns>当前轴状态</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadOtherStatu(ByVal AxisNum As Short) As Int32

    ''' <summary>
    ''' 读取轴状态，有伺服报警，INI，等
    ''' </summary>
    ''' <returns>当前轴状态</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadAxisStatu(ByVal AxisNum As Short) As Long
    ''' <summary>
    ''' 比较器端口输出电平
    ''' </summary>
    ''' <param name="OnOrOff">0低电平，1为高电平</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub WriteCMPOnOff(ByVal OnOrOff As Byte)

    ''' <summary>
    ''' 设置轴比较器比较值
    ''' </summary>
    ''' <param name="CMPData1">比较值1</param>
    ''' <param name="CMPData2">比较值2</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetCMPData(ByVal CMPData1 As Int32, ByVal CMPData2 As Int32)
    ''' <summary>
    ''' 设置比较触发模式
    ''' </summary>
    ''' <param name="cmp1_mode">比较器1比较模式，0关闭比较器，1= ，2小于设定值，3,大于</param>
    ''' <param name="cmp2_mode">比较器2比较模式，0关闭比较器，1= ，2小于设定值，3,大于</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetCMPTrggerMode(ByVal cmp1_mode As Int16, ByVal cmp2_mode As Int16)

    ''' <summary>
    ''' 读取轴状态，0运行，1停止
    ''' </summary>
    ''' <returns>当前轴状态</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadAxisRunStop(ByVal AxisNum As Short) As Int16

    ''' <summary>
    '''写入IO
    ''' </summary>
    ''' <param name="cardno"></param>
    ''' <param name="BitNo"></param>
    ''' <param name="on_off"></param>
    ''' <remarks></remarks>

    Protected MustOverride Sub WriteOutIO(ByVal cardno As Int16, ByVal BitNo As Int16, ByVal on_off As Int16)

    ''' <summary>
    ''' 读取输出IO
    ''' </summary>
    ''' <param name="cardno"></param>
    ''' <param name="BitNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadOutIO(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32

    ''' <summary>
    ''' 读取出入IO
    ''' </summary>
    ''' <param name="cardno"></param>
    ''' <param name="BitNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadInIO(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32

    ''' <summary>
    ''' 连续走位S
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="Dir"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SVSmove(ByVal axis As Int16, ByVal Dir As Int16)

    ''' <summary>
    ''' 连续走位T
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="Dir"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub TVTmove(ByVal axis As Int16, ByVal Dir As Int16)

    ''' <summary>
    ''' S型定长运动
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="Dist"></param>
    ''' <param name="posi_mode"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SPSmove(ByVal axis As Int16, ByVal Dist As Long, ByVal posi_mode As Int16)

    ''' <summary>
    ''' T型定长运动
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="Dist"></param>
    ''' <param name="posi_mode"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub TPTmove(ByVal axis As Int16, ByVal Dist As Long, ByVal posi_mode As Int16)

    ''' <summary>
    ''' 查询单轴各点信号
    ''' </summary>
    ''' <param name="index">索引值：0-总错误标志，1-伺服报警，2-极限报警，3-急停报警，4-非法开门,5-到位超时报警_
    ''' 6-原点信号，7-伺服停止信号,8-脉冲输出，9-运动结束,</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function E(ByVal index As Byte) As Short

    ''' <summary>
    ''' 上电函数
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function Pow() As Boolean

    ''' <summary>
    ''' 读取准备好信号
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReaRDY(ByVal axis As Byte) As Int32

    ''' <summary>
    ''' 读取上电信号
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReaSEVON(ByVal axis As Byte) As Int32

    ''' <summary>
    ''' 上电函数
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="on_off"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub WeadSEVON(ByVal axis As Byte, ByVal on_off As Int16)

    ''' <summary>
    ''' 设置EL信号的有效电平及制动方式
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="el_mode">EL有效电平和制动方式</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub EL(ByVal axis As Short, ByVal el_mode As Short)

    ''' <summary>
    ''' 设置指定轴的EZ信号的有效电平及其作用
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="ez_logic">EZ信号逻辑电平：0－低有效，1－高有效</param>
    ''' <param name="ez_mode">EZ信号的工作方式</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub EZ(ByVal axis As Int16, ByVal ez_logic As Int16, ByVal ez_mode As Int16)

    ''' <summary>
    ''' 设置指定轴锁存信号的有效电平
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="ltc_logic">LTC信号逻辑电平：0－低有效，1－高有效</param>
    ''' <param name="ltc_mode">EL有效电平和制动方式</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub LTC(ByVal axis As Short, ByVal ltc_logic As Short, ByVal ltc_mode As Short)

    ''' <summary>
    ''' 设置ORG信号的有效电平，以及允许/禁止滤波功能
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="org_logic">ORG信号的有效电平：0－低电平有效，1－高电平有效</param>
    ''' <param name="filter">允许/禁止滤波功能：0－禁止，1－允许</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub HOME(ByVal axis As Int16, ByVal org_logic As Int16, ByVal filter As Int16)

    ''' <summary>
    ''' 输出对指定轴的伺服使能端子的控制
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="on_off">设定管脚电平状态：0－低，1－高。SEVON输出口初始状态可选。</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SEVON(ByVal axis As Int16, ByVal on_off As Int16)

    ''' <summary>
    ''' 编码器计数方式
    ''' </summary>
    ''' <param name="axis">轴号</param>
    ''' <param name="mode">编码器反馈输入模式</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub Counter(ByVal axis As Int16, ByVal mode As Int16)

    ''' <summary>
    ''' 设定回原点模式
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="mode"></param>
    ''' <param name="EZ_count"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub HMode(ByVal axis As Short, ByVal mode As Short, ByVal EZ_count As Short)

    ''' <summary>
    ''' 设置SD信号有效的逻辑电平及其工作方式
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="enable"></param>
    ''' <param name="sd_logic"></param>
    ''' <param name="sd_mode"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SDPin(ByVal axis As Int16, ByVal enable As Int16, ByVal sd_logic As Int16, ByVal sd_mode As Int16)

    ''' <summary>
    ''' 设置允许/禁止PCS外部信号在运动中改变目标位置
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="enable"></param>
    ''' <param name="pcs_logic"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub PCSPin(ByVal axis As Int16, ByVal enable As Int16, ByVal pcs_logic As Int16)

    ''' <summary>
    ''' 设置指定轴的脉冲输出方式
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="outmode"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub PulseOut(ByVal axis As Int16, ByVal outmode As Int16)

    ''' <summary>
    ''' 设置允许/禁止INP信号及其有效的逻辑电平
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="enable"></param>
    ''' <param name="inp_logic"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub INPPin(ByVal axis As Int16, ByVal enable As Int16, ByVal inp_logic As Int16)

    ''' <summary>
    ''' 设置允许/禁止ERC信号及其有效电平和输出方式
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="enable"></param>
    ''' <param name="erc_logic"></param>
    ''' <param name="erc_width"></param>
    ''' <param name="erc_off_time"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub ERCPin(ByVal axis As Int16, ByVal enable As Int16, ByVal erc_logic As Int16, ByVal erc_width As Int16, ByVal erc_off_time As Int16)

    ''' <summary>
    ''' 设置ALM的逻辑电平及其工作方式
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="alm_logic"></param>
    ''' <param name="alm_action"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub ALMPin(ByVal axis As Int16, ByVal alm_logic As Int16, ByVal alm_action As Int16)


    ''' <summary>
    ''' 外部调用命令控制
    ''' </summary>
    ''' <remarks></remarks>
    Protected Enum Command As Int16
        Null = -1 '无命令
        MoveToABS = 0 '定长走绝对
        MoveToFAC = 1 ' 定长走绝对
        KeepMove = 2 '连续运动
        ReadPos = 3 '读取当前脉冲值
        StopMove = 4  ' 停止运动
        Comeback = 5   '回原点命令
        POW = 6 '上电
        Goback = 7 '回原点
        Pause = 8 '暂停
        Start = 9 '开始
        grating = 10 '光栅按下
        ChangeSpeed = 11 '变速
        Leave = 12 '光栅或安全门离开
        DelSpeed = 13
    End Enum

    'Public CarNum As Integer


    Protected mCurPulse As Long '当前目标位

    Protected mFacPulse As Long '相对位移
    Public mMoveWatiOne As Threading.ManualResetEvent
    Public mCommWatiOne As Threading.ManualResetEvent
    Public mHomeWatiOne As Threading.ManualResetEvent
    Public GraWatiOne As Threading.ManualResetEvent


    Public Structure _RunParam
        Public Min_Vel As Single   '起始速度
        Public Max_Vel As Single  '运行速度
        Public Tacc As Single    '总加速时间
        Public Tdec As Single  '总减速时间
        Public Sacc As Single 'S段加速距离
        Public Sdec As Single 'S段减速距离
        ' Public Home_Dis As Integer '在原点复位走出距离
        Public OrgSpeed As Single '复位速度
        Public RightLimit As Single '正极限
        Public LeftLimit As Single '负极限
        Public RunTime As Long  '超时
        Public ReduceRatio As Single '减速比

        Public RunDir As Byte '运动方向
        Public AxiaName As String '轴名称

        Public Shared Operator *(ByVal InParam As _RunParam, ByVal Cmp As Single) As _RunParam
            InParam.Max_Vel *= Cmp
            InParam.Min_Vel *= Cmp
            Return InParam
        End Operator


        Public Sub SaveFastenCong(ByVal Path As String, ByVal lpSectionName As String)
            Try
                WriteP(lpSectionName, "Min_Vel", Min_Vel, Path)
                WriteP(lpSectionName, "Max_Vel", Max_Vel, Path)
                WriteP(lpSectionName, "Tacc", Tacc, Path)
                WriteP(lpSectionName, "Tdec", Tdec, Path)
                WriteP(lpSectionName, "Sacc", Sacc, Path)
                WriteP(lpSectionName, "Sdec", Sdec, Path)
                WriteP(lpSectionName, "RunTime", RunTime, Path)
                WriteP(lpSectionName, "ReduceRatio", ReduceRatio, Path)
                WriteP(lpSectionName, "OrgSpeed", OrgSpeed, Path)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Function loadFastenCong(ByVal Path As String, ByVal AxixName As String) As ArrayList
            Try
                Dim ConfigAxix As New ArrayList
                Dim RunParam As _RunParam = Nothing
                RunParam.Min_Vel = CSng(ReadP("Min_Vel", 0, Path, AxixName))
                RunParam.Max_Vel = CSng(ReadP("Max_Vel", 0, Path, AxixName))
                RunParam.Tacc = CSng(ReadP("Tacc", 0, Path, AxixName))
                RunParam.Tdec = CSng(ReadP("Tdec", 0, Path, AxixName))
                RunParam.Sacc = CSng(ReadP("Sacc", 0, Path, AxixName))
                RunParam.Sdec = CSng(ReadP("Sdec", 0, Path, AxixName))
                RunParam.RunTime = CInt(ReadP("RunTime", 0, Path, AxixName))
                RunParam.LeftLimit = CSng(ReadP("LeftLimit", 0, Path, AxixName))
                RunParam.RightLimit = CSng(ReadP("RightLimit", 0, Path, AxixName))
                RunParam.ReduceRatio = CSng(ReadP("ReduceRatio", 0, Path, AxixName))
                RunParam.OrgSpeed = CSng(ReadP("orgspeed", 0, Path, AxixName))
                ConfigAxix.Add(RunParam)
                Return ConfigAxix
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Structure

    Public Structure AxisParam


        Public PulseMode As Byte
        Public CounterMode As Byte '编码器计数模式：计数倍频
        Public EncodeMode As Byte '编码器计数方式：正计数、负计数
        Public SoftELEnable As Byte
        'Public SoftELMax As Long
        'Public SoftELMin As Long
        Public ORGSignal As Byte
        Public ORGFilter As Byte
        Public ORGMode As Byte
        Public EZSignal As Byte
        Public ORGEZNo As Byte
        Public ORGDir As Byte
        Public ORGSpeedMode As Byte
        Public EMGEable As Byte
        Public EMGSignal As Byte
        Public ALMSignal As Byte
        Public ALMStopMode As Byte
        Public INPEable As Byte
        Public INPSignal As Byte
        Public ERCMode As Byte
        Public ERCSignal As Byte
        Public ERCWidth As Byte
        Public ERCOfftime As Byte
        Public ELMode As Byte
        Public ERCsel As Byte

        'Public ELP As Byte
        'Public ELM As Byte
        Public SEVON As Byte
        Public ReySig As Byte
        Public SorT As Byte
        Public StopMode As Byte
        Public PCSEnable As Byte
        Public PCSSignal As Byte
        Public SDEnable As Byte
        Public SDSignal As Byte
        Public SDMode As Byte
        Public RunComPare As Double
        Public MotorCount As Long
        Public LeaveDir As Byte
        'Public LTCSignal As Byte
        'Public LTCMode As Byte
     

        ' Public AxisName As String

        Public IsExist As Boolean
        Public AxisNo As Byte
        Public FilePath As String
        Public EZMode As Byte


        Public Sub Save(ByVal Path As String)
            Try
                Path = Path & ".mtq"
                WriteIni("PulseMode", PulseMode, Path)
                WriteIni("CounterMode", CounterMode, Path)
                WriteIni("SoftELEnable", SoftELEnable, Path)
                'WriteIni("SoftELMax", SoftELMax, Path)
                'WriteIni("SoftELMin", SoftELMin, Path)
                WriteIni("ORGSignal", ORGSignal, Path)
                WriteIni("ORGFilter", ORGFilter, Path)
                WriteIni("ORGMode", ORGMode, Path)
                WriteIni("ORGEZNo", ORGEZNo, Path)
                WriteIni("ORGDir", ORGDir, Path)
                WriteIni("EZSignal", EZSignal, Path)
                WriteIni("ORGSpeedMode", ORGSpeedMode, Path)
                WriteIni("EMGEable", EMGEable, Path)
                WriteIni("EMGSignal", EMGSignal, Path)
                WriteIni("ALMSignal", ALMSignal, Path)
                WriteIni("ALMStopMode", ALMStopMode, Path)
                WriteIni("INPEable", INPEable, Path)
                WriteIni("INPSignal", INPSignal, Path)
                WriteIni("ERCMode", ERCMode, Path)
                WriteIni("ERCSignal", ERCSignal, Path)
                WriteIni("ERCWidth", ERCWidth, Path)
                WriteIni("ERCOfftime", ERCOfftime, Path)
                WriteIni("ERCsel", ERCsel, Path)
                WriteIni("ELMode", ELMode, Path)
                'WriteIni("ELP", ELP, Path)
                'WriteIni("ELM", ELM, Path)
                WriteIni("ERCsel", ERCsel, Path)
                WriteIni("SEVON", SEVON, Path)
                WriteIni("ReySig", ReySig, Path)
                WriteIni("PCSEnable", PCSEnable, Path)
                WriteIni("PCSSignal", PCSSignal, Path)
                WriteIni("SDEnable", SDEnable, Path)
                WriteIni("SDSignal", SDSignal, Path)
                WriteIni("SDMode", SDMode, Path)
                WriteIni("SorT", SorT, Path)
                WriteIni("StopMode", StopMode, Path)
                WriteIni("RunComPare", RunComPare, Path)
                WriteIni("EncodeMode", EncodeMode, Path)
                WriteIni("MotorCount", MotorCount, Path)
                'WriteIni("Min_Vel", Min_Vel, Path)
                'WriteIni("Max_Vel", Max_Vel, Path)
                'WriteIni("Tacc", Tacc, Path)
                'WriteIni("Sacc", Sacc, Path)
                'WriteIni("Tdec", Tdec, Path)
                'WriteIni("Sdec", Sdec, Path)
                'WriteIni("Home_Dis", Home_Dis, Path)
                'WriteIni("Curr_Vel", Curr_Vel, Path)
                'WriteIni("Chg_enable", Chg_enable, Path)
                WriteIni("LeaveDir", LeaveDir, Path)
                WriteIni("UpFlag", "True", Path)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Save(ByVal Path As String, ByVal param As absMtAxis.AxisParam)
            Try

                WriteIni("PulseMode", param.PulseMode, Path)
                WriteIni("CounterMode", param.CounterMode, Path)
                WriteIni("SoftELEnable", param.SoftELEnable, Path)
                'WriteIni("SoftELMax", SoftELMax, Path)
                'WriteIni("SoftELMin", SoftELMin, Path)
                WriteIni("ORGSignal", param.ORGSignal, Path)
                WriteIni("ORGFilter", param.ORGFilter, Path)
                WriteIni("ORGMode", param.ORGMode, Path)
                WriteIni("ORGEZNo", param.ORGEZNo, Path)
                WriteIni("ORGDir", param.ORGDir, Path)
                WriteIni("EZSignal", param.EZSignal, Path)
                WriteIni("ORGSpeedMode", param.ORGSpeedMode, Path)
                WriteIni("EMGEable", param.EMGEable, Path)
                WriteIni("EMGSignal", param.EMGSignal, Path)
                WriteIni("ALMSignal", param.ALMSignal, Path)
                WriteIni("ALMStopMode", param.ALMStopMode, Path)
                WriteIni("INPEable", param.INPEable, Path)
                WriteIni("INPSignal", param.INPSignal, Path)
                WriteIni("ERCMode", param.ERCMode, Path)
                WriteIni("ERCSignal", param.ERCSignal, Path)
                WriteIni("ERCWidth", param.ERCWidth, Path)
                WriteIni("ERCOfftime", param.ERCOfftime, Path)
                WriteIni("ERCsel", param.ERCsel, Path)
                WriteIni("ELMode", param.ELMode, Path)
                'WriteIni("ELP", ELP, Path)
                'WriteIni("ELM", ELM, Path)
                WriteIni("ERCsel", param.ERCsel, Path)
                WriteIni("SEVON", param.SEVON, Path)
                WriteIni("ReySig", param.ReySig, Path)
                WriteIni("PCSEnable", param.PCSEnable, Path)
                WriteIni("PCSSignal", param.PCSSignal, Path)
                WriteIni("SDEnable", param.SDEnable, Path)
                WriteIni("SDSignal", param.SDSignal, Path)
                WriteIni("SDMode", param.SDMode, Path)
                WriteIni("SorT", param.SorT, Path)
                WriteIni("StopMode", param.StopMode, Path)
                WriteIni("RunComPare", param.RunComPare, Path)
                WriteIni("EncodeMode", param.EncodeMode, Path)
                WriteIni("MotorCount", param.MotorCount, Path)
                'WriteIni("Min_Vel", Min_Vel, Path)
                'WriteIni("Max_Vel", Max_Vel, Path)
                'WriteIni("Tacc", Tacc, Path)
                'WriteIni("Sacc", Sacc, Path)
                'WriteIni("Tdec", Tdec, Path)
                'WriteIni("Sdec", Sdec, Path)
                'WriteIni("Home_Dis", Home_Dis, Path)
                'WriteIni("Curr_Vel", Curr_Vel, Path)
                'WriteIni("Chg_enable", Chg_enable, Path)
                WriteIni("LeaveDir", param.LeaveDir, Path)
                WriteIni("UpFlag", "True", Path)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub load(ByVal Path As String)
            Try
                Path = Path & ".mtq"
                Dim UpFlag As Boolean = CBool(ReadIni("UpFlag", "False", Path)) '极限配置升级标志
                PulseMode = CByte(ReadIni("PulseMode", 0, Path))
                CounterMode = CByte(ReadIni("CounterMode", 0, Path))
                EncodeMode = CByte(ReadIni("EncodeMode", 0, Path))
                SoftELEnable = CByte(ReadIni("SoftELEnable", 0, Path))
                'SoftELMax = CLng(ReadIni("SoftELMax", 0, Path))
                'SoftELMin = CLng(ReadIni("SoftELMin", 0, Path))
                ORGSignal = CByte(ReadIni("ORGSignal", 0, Path))
                ORGFilter = CByte(ReadIni("ORGFilter", 0, Path))
                ORGMode = CByte(ReadIni("ORGMode", 0, Path))
                EZSignal = CByte(ReadIni("EZSignal", 0, Path))
                ORGEZNo = CByte(ReadIni("ORGEZNo", 0, Path))
                ORGDir = CByte(ReadIni("ORGDir", 0, Path))
                ORGSpeedMode = CByte(ReadIni("ORGSpeedMode", 0, Path))
                EMGEable = CByte(ReadIni("EMGEable", 0, Path))
                EMGSignal = CByte(ReadIni("EMGSignal", 0, Path))
                ALMSignal = CByte(ReadIni("ALMSignal", 0, Path))
                ALMStopMode = CByte(ReadIni("ALMStopMode", 0, Path))
                INPEable = CByte(ReadIni("INPEable", 0, Path))
                INPSignal = CByte(ReadIni("INPSignal", 0, Path))
                ERCMode = CByte(ReadIni("ERCMode", 0, Path))
                ERCSignal = CByte(ReadIni("ERCSignal", 0, Path))
                ERCWidth = CByte(ReadIni("ERCWidth", 0, Path))
                ERCOfftime = CByte(ReadIni("ERCOfftime", 0, Path))
                ELMode = CByte(ReadIni("ELMode", 0, Path))
                If UpFlag = False Then
                    If ELMode = 0 Or ELMode = 1 Then
                        ELMode = 0
                    Else
                        ELMode = 1
                    End If
                Else
                    Dim A = 1
                End If
                'ELP = CByte(ReadIni("ELP", 0, Path))
                'ELM = CByte(ReadIni("ELM", 0, Path))
                ERCsel = CByte(ReadIni("ERCsel", 0, Path))
                SEVON = CByte(ReadIni("SEVON", 0, Path))
                ReySig = CByte(ReadIni("ReySig", 0, Path))
                SorT = CByte(ReadIni("SorT", 0, Path))
                StopMode = CByte(ReadIni("StopMode", 0, Path))
                PCSEnable = CByte(ReadIni("PCSEnable", 0, Path))
                PCSSignal = CByte(ReadIni("PCSSignal", 0, Path))
                SDEnable = CByte(ReadIni("SDEnable", 0, Path))
                SDSignal = CByte(ReadIni("SDSignal", 0, Path))
                SDMode = CByte(ReadIni("SDMode", 0, Path))
                RunComPare = CDbl(ReadIni("RunComPare", 0, Path))
                MotorCount = CDbl(ReadIni("MotorCount", 10000, Path))
                'Min_Vel = CInt(ReadIni("Min_Vel", 0, Path))
                'Max_Vel = CInt(ReadIni("Max_Vel", 0, Path))
                'Tacc = CSng(ReadIni("Tacc", 0, Path))
                'Tdec = CSng(ReadIni("Tdec", 0, Path))
                'Sacc = CInt(ReadIni("Sacc", 0, Path))
                'Sdec = CInt(ReadIni("Sdec", 0, Path))
                'Home_Dis = CInt(ReadIni("Home_Dis", 0, Path))
                LeaveDir = CByte(ReadIni("LeaveDir", 0, Path))

                'Curr_Vel = CInt(ReadIni("Curr_Vel", 0, Path))
                'Chg_enable = CInt(ReadIni("Chg_enable", 0, Path))



            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Structure

End Class
