Public Class _5400Base
    Inherits BaseFunction
    Private mMust As New Threading.Mutex(False)

#Region "declareDMC5400"

    '初始化函数
    Declare Function d5400_board_init Lib "dmc5400.dll" () As Integer
    Declare Sub d5400_board_close Lib "dmc5400.dll" ()


    '中断控制函数
    Declare Function d5400_set_int_enable Lib "dmc5400.dll" (ByVal cardno As Integer) As Integer
    Declare Sub d5400_set_int_disable Lib "dmc5400.dll" ()
    Declare Sub d5400_set_int_factor Lib "dmc5400.dll" (ByVal axis As Integer, ByVal int_factor As Long)
    Declare Function d5400_read_event_int_factor Lib "dmc5400.dll" (ByVal axis As Integer) As Long
    Declare Function d5400_read_error_int_factor Lib "dmc5400.dll" (ByVal axis As Integer) As Long

    Declare Function d5400_get_error_intfactor Lib "dmc5400.dll" (ByVal axis As Integer) As Long


    '脉冲输入\输出设置函数
    Declare Sub d5400_set_pulse_outmode Lib "dmc5400.dll" (ByVal axis As Integer, ByVal outmode As Integer)
    Declare Sub d5400_set_pulse_inmode Lib "dmc5400.dll" (ByVal axis As Integer, ByVal inmode As Integer, ByVal count_dir As Integer)

    '运动速度设置函数
    Declare Sub d5400_set_profile Lib "dmc5400.dll" (ByVal axis As Integer, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
    Declare Sub d5400_set_s_profile Lib "dmc5400.dll" (ByVal axis As Integer, ByVal Min_Vel As Double, ByVal Max_Vel As Double, _
                    ByVal Tacc As Double, ByVal Tdec As Double, ByVal Sacc As Long, ByVal Sdec As Long)
    Declare Sub d5400_change_speed Lib "dmc5400.dll" (ByVal axis As Integer, ByVal Curr_Vel As Double)
    Declare Sub d5400_variety_speed_range Lib "dmc5400.dll" (ByVal axis As Integer, ByVal chg_enable As Integer, ByVal Max_Vel As Double)

    Declare Function d5400_read_current_speed Lib "dmc5400.dll" (ByVal axis As Integer) As Double

    Declare Sub d5400_set_vector_profile Lib "dmc5400.dll" (ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)

    '制动函数
    Declare Sub d5400_decel_stop Lib "dmc5400.dll" (ByVal axis As Integer, ByVal Tdec As Double)
    Declare Sub d5400_imd_stop Lib "dmc5400.dll" (ByVal axis As Integer)
    Declare Sub d5400_emg_stop Lib "dmc5400.dll" ()
    Declare Sub d5400_simultaneous_stop Lib "dmc5400.dll" (ByVal axis As Integer)


    '单轴定长运动函数
    Declare Sub d5400_t_vmove Lib "dmc5400.dll" (ByVal axis As Integer, ByVal dir As Integer)
    Declare Sub d5400_ex_t_pmove Lib "dmc5400.dll" (ByVal axis As Integer, ByVal Dist As Long, ByVal posi_mode As Integer)
    Declare Sub d5400_s_pmove Lib "dmc5400.dll" (ByVal axis As UShort, ByVal Dist As Int32, ByVal posi_mode As UShort)
    Declare Sub d5400_ex_s_pmove Lib "dmc5400.dll" (ByVal axis As Integer, ByVal Dist As Long, ByVal posi_mode As Integer)

    Declare Sub d5400_t_pmove Lib "dmc5400.dll" (ByVal axis As Integer, ByVal Dist As Int32, ByVal posi_mode As UShort)
    Declare Sub d5400_s_vmove Lib "dmc5400.dll" (ByVal axis As Integer, ByVal dir As Integer)


    '线性插补函数
    Declare Sub d5400_t_line2 Lib "dmc5400.dll" (ByVal axis1 As Integer, ByVal Dist1 As Long, ByVal axis2 As Integer, ByVal Dist2 As Long, ByVal posi_mode As Integer)
    Declare Sub d5400_t_line3 Lib "dmc5400.dll" (ByVal axis As ArrayList, ByVal Dist1 As Long, ByVal Dist2 As Long, ByVal Dist3 As Long, ByVal posi_mode As Integer)
    Declare Sub d5400_t_line4 Lib "dmc5400.dll" (ByVal cardno As Integer, ByVal Dist1 As Long, ByVal Dist2 As Long, ByVal Dist3 As Long, ByVal Dist4 As Long, ByVal posi_mode As Integer)

    '圆弧插补函数
    Declare Sub d5400_arc_move Lib "dmc5400.dll" (ByVal axis As ArrayList, ByVal target_pos As ArrayList, ByVal cen_pos As ArrayList, ByVal arc_dir As Integer)
    Declare Sub d5400_rel_arc_move Lib "dmc5400.dll" (ByVal axis As ArrayList, ByVal rel_pos As ArrayList, ByVal rel_cen As ArrayList, ByVal arc_dir As Integer)



    '原点返回函数
    Declare Sub d5400_config_home_mode Lib "dmc5400.dll" (ByVal axis As Integer, ByVal mode As Integer, ByVal EZ_count As Integer)
    Declare Sub d5400_home_move Lib "dmc5400.dll" (ByVal axis As Integer, ByVal home_mode As Integer, ByVal vel_mode As Integer)

    '手轮运动控制函数
    Declare Sub d5400_set_handwheel_inmode Lib "dmc5400.dll" (ByVal axis As Integer, ByVal inmode As Integer, ByVal count_dir As Integer)
    Declare Sub d5400_handwheel_move Lib "dmc5400.dll" (ByVal axis As Integer, ByVal vh As Double)
    Declare Function d5400_get_handwheel_pulse Lib "dmc5400.dll" (ByVal axis As Integer) As Long
    Declare Sub d5400_set_handwheel_pulse Lib "dmc5400.dll" (ByVal axis As Integer, ByVal value As Long)


    '运动状态函数
    Declare Function d5400_check_done Lib "dmc5400.dll" (ByVal axis As Integer) As Integer
    Declare Function d5400_get_rsts Lib "dmc5400.dll" (ByVal axis As Integer) As Long
    Declare Function d5400_axis_io_status Lib "dmc5400.dll" (ByVal axis As Integer) As Integer
    Declare Function d5400_axis_status Lib "dmc5400.dll" (ByVal axis As Integer) As Integer



    '专用信号设置函数
    Declare Sub d5400_config_SD_PIN Lib "dmc5400.dll" (ByVal axis As Integer, ByVal enable As Integer, ByVal sd_logic As Integer, ByVal sd_mode As Integer)
    Declare Sub d5400_config_PCS_PIN Lib "dmc5400.dll" (ByVal axis As Integer, ByVal enable As Integer, ByVal pcs_logic As Integer)
    Declare Sub d5400_config_INP_PIN Lib "dmc5400.dll" (ByVal axis As Integer, ByVal enable As Integer, ByVal inp_logic As Integer)
    Declare Sub d5400_config_ERC_PIN Lib "dmc5400.dll" (ByVal axis As Integer, ByVal enable As Integer, ByVal erc_logic As Integer, ByVal erc_width As Integer, ByVal erc_off_time As Integer)
    Declare Sub d5400_config_ALM_PIN Lib "dmc5400.dll" (ByVal axis As Integer, ByVal alm_logic As Integer, ByVal alm_action As Integer)
    Declare Sub d5400_config_LTC_PIN Lib "dmc5400.dll" (ByVal axis As Integer, ByVal enable As Integer, ByVal ltc_logic As Integer)
    Declare Sub d5400_config_CUN_CLR Lib "dmc5400.dll" (ByVal axis As Integer, ByVal trigger_mode As Integer, ByVal enable As Integer)
    Declare Sub d5400_config_EL_MODE Lib "dmc5400.dll" (ByVal axis As Integer, ByVal el_mode As Integer)
    Declare Sub d5400_set_HOME_pin_logic Lib "dmc5400.dll" (ByVal axis As Integer, ByVal org_logic As Integer, ByVal filter As Integer)

    '编码器位置和内部计数器控制函数
    Declare Function d5400_get_position Lib "dmc5400.dll" (ByVal axis As Integer) As Int32
    Declare Sub d5400_set_position Lib "dmc5400.dll" (ByVal axis As Integer, ByVal current_position As Int32)
    Declare Function d5400_get_encoder Lib "dmc5400.dll" (ByVal axis As Integer) As Long
    Declare Sub d5400_set_encoder Lib "dmc5400.dll" (ByVal axis As Integer, ByVal encoder_value As Long)
    Declare Sub d5400_reset_target_position Lib "dmc5400.dll" (ByVal axis As Integer, ByVal Dist As Long)
    Declare Function d5400_get_postion_deviation Lib "dmc5400.dll" (ByVal axis As Integer) As Long
    Declare Sub d5400_cls_postion_deviation Lib "dmc5400.dll" (ByVal axis As Integer)

    '软件限位设定函数
    Declare Sub d5400_config_softlimit Lib "dmc5400.dll" (ByVal axis As Integer, ByVal source_sel As Integer, ByVal SL_action As Integer)
    Declare Sub d5400_enable_softlimit Lib "dmc5400.dll" (ByVal axis As Integer, ByVal ON_OFF As Integer)
    Declare Sub d5400_set_softlimit_data Lib "dmc5400.dll" (ByVal axis As Integer, ByVal N_limit As Long, ByVal P_limit As Long)

    '缓存器状态读取和位置锁存功能函数
    Declare Function d5400_prebuff_status Lib "dmc5400.dll" (ByVal axis As Integer) As Integer
    Declare Sub d5400_set_latch_trigger_source Lib "dmc5400.dll" (ByVal axis As Integer, ByVal sel As Integer)
    Declare Function d5400_get_rcun_latch_value Lib "dmc5400.dll" (ByVal axis As Integer, ByVal sel As Integer) As Long

    '通用I/O接口函数
    Declare Function d5400_read_inbit Lib "dmc5400.dll" (ByVal bitno As Integer) As Integer
    Declare Sub d5400_write_outbit Lib "dmc5400.dll" (ByVal bitno As Integer, ByVal ON_OFF As Integer)
    Declare Function d5400_read_outbit Lib "dmc5400.dll" (ByVal bitno As Integer) As Integer
    Declare Function d5400_read_inport Lib "dmc5400.dll" (ByVal card As Integer) As Long
    Declare Function d5400_read_outport Lib "dmc5400.dll" (ByVal card As Integer) As Long

    '脉冲当量和闭环操作
    Declare Function d5400_get_scale Lib "dmc5400.dll" (ByVal axis As Integer, ByRef pscale As Double) As Long
    Declare Function d5400_set_scale Lib "dmc5400.dll" (ByVal axis As Integer, ByVal new_scale As Double) As Long

    Declare Function d5400_get_move_ratio Lib "dmc5400.dll" (ByVal axis As Integer, ByRef pEncoder_ratio As Double) As Long
    Declare Function d5400_set_move_ratio Lib "dmc5400.dll" (ByVal axis As Integer, ByVal encoder_ratio As Double) As Long

    Declare Function d5400_pulse_compensate_scale Lib "dmc5400.dll" (ByVal axis As Integer) As Long

    Declare Function d5400_config_pulse_loop_scale Lib "dmc5400.dll" (ByVal axis As Integer, ByVal max_num As Integer, ByVal min_err As Double, ByVal max_err As Double) As Long



#End Region

#Region "底层函数"
    Public Overrides Function Init() As Int16
        mMust.WaitOne()
        Try
            Return d5400_board_init()

        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try


    End Function

    ''' <summary>
    ''' 关闭控制卡，释放系统资源
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Close()
        mMust.WaitOne()
        Try
            d5400_board_close()

        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 设置指定轴的脉冲输出模式
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="outmode">脉冲输出方式选择</param>
    ''' <remarks></remarks>
    Public Overrides Sub PulseOutmode(ByVal axis As Int16, ByVal outmode As Int16)
        mMust.WaitOne()
        Try
            d5400_set_pulse_outmode(axis, outmode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try

    End Sub

    ''' <summary>
    ''' 设置SD信号有效的逻辑电平及其工作方式
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="enable">设置SD信号有效的逻辑电平及其工作方式</param>
    ''' <param name="sd_logic">设置SD信号的有效逻辑电平：0－低电平有效，1－高电平有效。</param>
    ''' <param name="sd_mode">设置SD信号的工作方式</param>
    ''' <remarks></remarks>
    Public Overrides Sub SD(ByVal axis As Int16, ByVal enable As Int16, ByVal sd_logic As Int16, ByVal sd_mode As Int16)
        mMust.WaitOne()
        Try
            d5400_config_SD_PIN(axis, enable, sd_logic, sd_logic)
        Catch ex As Exception

        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 设置允许/禁止PCS外部信号在运动中改变目标位置
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="enable">允许/禁止信号功能：0－无效，1－有效</param>
    ''' <param name="pcs_logic">设置PCS信号的有效电平：0－低电平有效，1－高电平有效</param>
    ''' <remarks></remarks>
    Public Overrides Sub PCS(ByVal axis As Int16, ByVal enable As Int16, ByVal pcs_logic As Int16)
        mMust.WaitOne()
        Try
            d5400_config_PCS_PIN(axis, enable, pcs_logic)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 设置允许/禁止INP信号及其有效的逻辑电平
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="enable">允许/禁止信号功能：0－无效，1－有效</param>
    ''' <param name="inp_logic">设置INP信号的有效电平：0－低电平有效，1－高电平有效</param>
    ''' <remarks></remarks>
    Public Overrides Sub INP(ByVal axis As Int16, ByVal enable As Int16, ByVal inp_logic As Int16)
        mMust.WaitOne()
        Try
            d5400_config_INP_PIN(axis, enable, inp_logic)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 设置允许/禁止ERC信号及其有效电平和输出方式
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="enable">范围：0 - 3;</param>
    ''' <param name="erc_logic">设置INP信号的有效电平：0－低电平有效，1－高电平有效</param>
    ''' <param name="erc_width">误差清除信号ERC有效输出宽度：</param>
    ''' <param name="erc_off_time">ERC信号的关断时间：</param>
    ''' <remarks></remarks>
    Public Overrides Sub ERC(ByVal axis As Int16, ByVal enable As Int16, ByVal erc_logic As Int16, ByVal erc_width As Int16, ByVal erc_off_time As Int16)
        mMust.WaitOne()
        Try
            d5400_config_ERC_PIN(axis, enable, erc_logic, erc_width, erc_off_time)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 设置ALM的逻辑电平及其工作方式
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="alm_logic">ALM信号的输入电平：0－低电平有效，1－高电平有效</param>
    ''' <param name="alm_action">ALM信号的制动方式：0－立即停止，1－减速停止</param>
    ''' <remarks></remarks>
    Public Overrides Sub ALM(ByVal axis As Int16, ByVal alm_logic As Int16, ByVal alm_action As Int16)
        mMust.WaitOne()
        Try
            d5400_config_ALM_PIN(axis, alm_logic, alm_action)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 设置EL信号的有效电平及制动方式
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="el_mode">EL有效电平和制动方式</param>
    ''' <remarks></remarks>
    Public Overrides Sub ELMODE(ByVal axis As Int16, ByVal el_mode As Int16)
        mMust.WaitOne()
        Try
            d5400_config_EL_MODE(axis, el_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 设置ORG信号的有效电平，以及允许/禁止滤波功能
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="org_logic">ORG信号的有效电平：0－低电平有效，1－高电平有效</param>
    ''' <param name="filter">ORG信号的有效电平：0－低电平有效，1－高电平有效</param>
    ''' <remarks></remarks>
    Public Overrides Sub SetHome(ByVal axis As Int16, ByVal org_logic As Int16, ByVal filter As Int16)
        mMust.WaitOne()
        Try
            d5400_set_HOME_pin_logic(axis, org_logic, filter)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 读取指定轴的“伺服使能”端子的电平状态
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <returns>0－低电平，1－高电平。SEVON输出口初始状态可选。</returns>
    ''' <remarks></remarks>
    Public Overrides Function ReadSEVON(ByVal axis As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_read_SEVON_PIN(axis)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function

    ''' <summary>
    ''' 输出对指定轴的伺服使能端子的控制
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="on_off">设定管脚电平状态：0－低，1－高。SEVON输出口初始状态可选。</param>
    ''' <remarks></remarks>
    Public Overrides Sub writeSEVON(ByVal axis As Int16, ByVal on_off As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_write_SEVON_PIN(axis, on_off)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub

    ''' <summary>
    ''' 控制指定轴“误差清除”端子信号的输出
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="sel">0－复位ERC信号，1－输出ERC信号</param>
    ''' <remarks></remarks>
    Public Overrides Sub WriteERC(ByVal axis As Int16, ByVal sel As Int16)
        mMust.WaitOne()
        'Try
        '    d5400_write_ERC_PIN(axis, sel)
        'Catch ex As Exception
        'Finally
        mMust.ReleaseMutex()
        'End Try
    End Sub

    ''' <summary>
    ''' 读取指定运动轴的“伺服准备好”端子的电平状态
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns>0－低电平，1－高电平</returns>
    ''' <remarks></remarks>
    Public Overrides Function ReadRDY(ByVal axis As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_read_RDY_PIN(axis)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function

    ''' <summary>
    ''' 读取通用输入点
    ''' </summary>
    ''' <param name="cardno">对应的卡号</param>
    ''' <param name="BitNo">对应的IO点号</param>
    ''' <returns></returns>0为低电平 1为高电平
    ''' <remarks></remarks>
    Public Overrides Function ReadInbit(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_read_inbit(cardno, BitNo)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function


    ''' <summary>
    ''' 写入通用输出点
    ''' </summary>
    ''' <param name="cardno">对应的卡号</param>
    ''' <param name="BitNo">对应的IO点</param>
    ''' <param name="on_off">要写入ON  OFF  1为ON高电平 0为OFF低电平</param>
    ''' <remarks></remarks>
    Public Overrides Sub WriteOutbit(ByVal cardno As Int16, ByVal BitNo As Int16, ByVal on_off As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_write_outbit(cardno, BitNo, on_off)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub



    ''' <summary>
    ''' 读取通用输出点
    ''' </summary>
    ''' <param name="cardno">对应卡号</param>
    ''' <param name="BitNo">对应的IO点</param>
    ''' <returns></returns>0为低电平 1为高电平
    ''' <remarks></remarks>
    Public Overrides Function ReadOutbit(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_read_outbit(cardno, BitNo)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function


    ''' <summary>
    ''' 读取卡所有通用输入口电平
    ''' </summary>
    ''' <param name="card">对应卡号</param>
    ''' <returns></returns>bit0 – bit19 位值分别代表第 1 – 20 号输入端口值
    ''' <remarks></remarks>
    Public Overrides Function ReadInport(ByVal card As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d5400_read_inport(card)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function


    ''' <summary>
    ''' 读取指定控制卡的全部通用输出口的电平状态
    ''' </summary>
    ''' <param name="card">对应卡号</param>
    ''' <returns></returns>bit0 – bit19 位值分别代表第 1 – 20 号输出端口值
    ''' <remarks></remarks>
    Public Overrides Function ReadOutport(ByVal card As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d5400_read_outport(card)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function



    ''' <summary>
    ''' 指定控制卡的全部通用输出口的电平状态
    ''' </summary>
    ''' <param name="cardno">对应卡号</param>
    ''' <param name="Port_Value"></param>bit0 – bit19 位值分别代表第 1 – 20 号输出端口值。
    ''' <remarks></remarks>
    Public Overrides Sub WriteOutport(ByVal cardno As Int16, ByVal Port_Value As Int32)
        'mMust.WaitOne()
        'Try
        '    d5400_write_outport(cardno, Port_Value)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub


    ''' <summary>
    ''' 设定指定轴的回原点模式
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="mode">回原点的信号模式</param>
    ''' <param name="EZ_count"></param>遇到原点信号后，EZ 信号出现 EZ_count 指定的次数,仅当 mode=1 时该设置有效
    ''' <remarks></remarks>

    Public Overrides Sub HomeMode(ByVal axis As Int16, ByVal mode As Int16, ByVal EZ_count As Int16)
        mMust.WaitOne()
        Try
            d5400_config_home_mode(axis, mode, EZ_count)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 单轴回原点运动
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="home_mode">回原点方式</param>
    ''' <param name="vel_mode"></param>回原点速度：0－低速回原点，1－高速回原点
    ''' <remarks></remarks>
    Public Overrides Sub HomeMove(ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16)
        mMust.WaitOne()
        Try
            d5400_home_move(axis, home_mode, vel_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 指定轴减速停止，调用此函数时立即减速，减速到起始速度后停止脉冲输出。
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Tdec">减速时间</param>
    ''' <remarks></remarks>
    Public Overrides Sub DecelStop(ByVal axis As Int16, ByVal Tdec As Double)
        mMust.WaitOne()
        Try
            d5400_decel_stop(axis, Tdec)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 使指定轴立即停止，没有任何减速的过程
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <remarks></remarks>
    Public Overrides Sub ImdStop(ByVal axis As Int16)
        mMust.WaitOne()
        Try
            d5400_imd_stop(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 使所有轴紧急停止
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub EmgStop()
        mMust.WaitOne()
        Try
            d5400_emg_stop()
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 在指定轴的 CSTP 端子上输出一个单脉冲的停止信号,如果有多个轴的CSTP 信号相连接，则所有相连运动轴将同时停止运行。
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <remarks></remarks>
    Public Overrides Sub SimultaneousStop(ByVal axis As Int16)
        mMust.WaitOne()
        Try
            d5400_simultaneous_stop(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 读取指定轴的指令脉冲位置
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns></returns>返回当前轴脉冲
    ''' <remarks></remarks>
    Public Overrides Function GetPosition(ByVal axis As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d5400_get_position(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    ''' <summary>
    ''' 设定指定轴的指令脉冲位置
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="current_position">需要给定轴当前脉冲</param>
    ''' <remarks></remarks>
    Public Overrides Sub SetPosition(ByVal axis As Int16, ByVal current_position As Integer)
        mMust.WaitOne()
        Try
            ''axis = 3
            d5400_set_position(axis, current_position)
            'd5400_set_encoder(axis, current_position)
            'System.Threading.Thread.Sleep(500)
            'Dim a As Long = d5400_get_position(axis)
            ''a = d5400_get_encoder(axis)
            'a = 0
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 检测指定轴的运动状态，停止或是在运行中
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns></returns>0 表示指定轴正在运行，1 表示指定轴已停止
    ''' <remarks></remarks>
    Public Overrides Function GetCheckDone(ByVal axis As Int16) As Int16
        mMust.WaitOne()
        Try
            Return d5400_check_done(axis)
            'If d5400_read_inbit(0, 9) = 0 Then
            '    Return 1
            'ElseIf d5400_read_inbit(0, 9) = 1 Then
            '    Return 0
            'End If

        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function


    ''' <summary>
    ''' 读取指定轴的预置缓冲区的状态
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns></returns>0－缓冲区空，1－缓冲区满
    ''' <remarks></remarks>
    Public Overrides Function GetPrebuffStatus(ByVal axis As Int16) As Int16
        mMust.WaitOne()
        Try
            Return d5400_prebuff_status(axis)
        Catch ex As Exception

        Finally
            mMust.ReleaseMutex()
        End Try
    End Function


    ''' <summary>
    ''' 读取指定轴有关运动信号的状态，包含指定轴的专用 I/O 状态。
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns></returns>返回值去2进制后16位 每个位代表不同IO
    ''' <remarks></remarks>
    Public Overrides Function GetIoStatus(ByVal axis As Int16) As Long
        mMust.WaitOne()
        Try
            Return d5400_axis_io_status(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try

    End Function


    ''' <summary>
    ''' 读取指定轴的主状态
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetAxisStatus(ByVal axis As Int16) As Int16
        mMust.WaitOne()
        Try
            Return d5400_axis_status(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function


    ''' <summary>
    ''' 读取指定轴的外部信号状态
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns></returns>返回8位  每一位不同含义
    ''' <remarks></remarks>
    Public Overrides Function GetRsts(ByVal axis As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d5400_get_rsts(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function


    ''' <summary>
    ''' 使指定轴以对称梯形速度曲线做定长位移运动。
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Dist"></param>（绝对/相对）位移值，单位：脉冲数
    ''' <param name="posi_mode"></param>位移模式设定：0 表示相对位移，1 表示绝对位移
    ''' <remarks></remarks>
    Public Overrides Sub TPmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d5400_t_pmove(axis, Dist, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 使指定轴以非对称梯形速度曲线做定长位移运动
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Dist"></param>（绝对/相对）位移值，单位：脉冲数
    ''' <param name="posi_mode"></param>位移模式设定：0 表示相对位移，1 表示绝对位移
    ''' <remarks></remarks>
    Public Overrides Sub ExTPmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d5400_ex_t_pmove(axis, Dist, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 使指定轴以对称 S 形速度曲线做定长位移运动
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Dist">（绝对/相对）位移值，单位：脉冲数</param>
    ''' <param name="posi_mode"></param>位移模式设定：0 表示相对位移，1 表示绝对位移
    ''' <remarks></remarks>
    Public Overrides Sub SPmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            Dim a = GetPosition(axis)
            d5400_s_pmove(axis, Dist, posi_mode)

        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 使指定轴以非对称 S 形速度曲线做定长位移运动
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Dist"></param>（绝对/相对）位移值，单位：脉冲数
    ''' <param name="posi_mode"></param>位移模式设定：0 表示相对位移，1 表示绝对位移
    ''' <remarks></remarks>
    Public Overrides Sub ExSPmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d5400_ex_s_pmove(axis, Dist, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 使指定轴以 S 形速度曲线加速到高速，并持续运行下去。
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Dir"></param>指定运动的方向，其中 0 表示负方向，1 表示正方向
    ''' <remarks></remarks>
    Public Overrides Sub SVmove(ByVal axis As Int16, ByVal Dir As Int32)
        mMust.WaitOne()
        Try
            d5400_s_vmove(axis, Dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 使指定轴以 T 形速度曲线加速到高速，并持续运行下去。
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Dir"></param>指定运动的方向，其中 0 表示负方向，1 表示正方向
    ''' <remarks></remarks>
    Public Overrides Sub TVmove(ByVal axis As Int16, ByVal Dir As Int32)
        mMust.WaitOne()
        Try
            d5400_t_vmove(axis, Dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 设定指定轴改变的速度上限，及变速使能
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="chg_enable"></param>禁止/使能连续运行中变速（禁止保留）
    ''' <param name="Max_Vel"></param>运行速度的变速上限值，单位 pps
    ''' <remarks></remarks>
    Public Overrides Sub VarietySpeed(ByVal axis As Int16, ByVal chg_enable As Int16, ByVal Max_Vel As Double)
        mMust.WaitOne()
        Try
            d5400_variety_speed_range(axis, chg_enable, Max_Vel)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 读取当前速度值，单位 pps
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns></returns>指定轴的速度脉冲数
    ''' <remarks></remarks>
    Public Overrides Function ReadCurrentSpeed(ByVal axis As Int16) As Double
        mMust.WaitOne()
        Try
            Return d5400_read_current_speed(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function



    ''' <summary>
    ''' 在线改变指定轴的当前运动速度,且在调用前必须先调用 d5400_variety_speed_range 设置变速范围和使能。
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Curr_Vel"></param>新的运行速度，单位 pps
    ''' <remarks></remarks>
    Public Overrides Sub ChangeSpeed(ByVal axis As Int16, ByVal Curr_Vel As Double)
        mMust.WaitOne()
        Try
            d5400_change_speed(axis, Curr_Vel)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try

    End Sub

    ''' <summary>
    '''  在线改变目标位
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="NewPos">新目标位</param>
    ''' <remarks></remarks>
    Public Overrides Sub ResetTargetPos(ByVal axis As Short, ByVal NewPos As Double)

    End Sub

    ''' <summary>
    ''' 设定插补矢量运动曲线的起始速度、运行速度、加速时间、减速时间
    ''' </summary>
    ''' <param name="Min_Vel"></param>起始速度，单位 pps
    ''' <param name="Max_Vel"></param>运行速度，单位 pps
    ''' <param name="Tacc"></param>总加速时间，单位 s
    ''' <param name="Tdec"></param>总减速时间，单位 s
    ''' <remarks></remarks>
    Public Overrides Sub SetVectorProfile(ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
        mMust.WaitOne()
        Try
            d5400_set_vector_profile(Min_Vel, Max_Vel, Tacc, Tdec)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 设定梯形曲线的起始速度、运行速度、加速时间、减速时间
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Min_Vel"></param>起始速度，单位 pps
    ''' <param name="Max_Vel"></param>运行速度，单位 pps
    ''' <param name="Tacc"></param>总加速时间，单位 s
    ''' <param name="Tdec"></param>总减速时间，单位 s
    ''' <remarks></remarks>
    Public Overrides Sub SetProfile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
        mMust.WaitOne()
        Try
            d5400_set_profile(axis, Min_Vel, Max_Vel, Tacc, Tdec)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub



    ''' <summary>
    ''' 设定 S 形曲线运动的起始速度、运行速度、加速时间、S 段加减速脉冲数
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Min_Vel"></param>起始速度，单位 pps
    ''' <param name="Max_Vel"></param>运行速度，单位 pps
    ''' <param name="Tacc"></param>总加速时间，单位 s
    ''' <param name="Tdec"></param>总减速时间，单位 s
    ''' <param name="Sacc"></param>S 加速段脉冲数
    ''' <param name="Sdec"></param>S 减速段脉冲数
    ''' <remarks></remarks>
    Public Overrides Sub SetSProfile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Sacc As Int32, ByVal Sdec As Int32)
        mMust.WaitOne()
        Try
            d5400_set_s_profile(axis, Min_Vel, Max_Vel, Tacc, Tdec, Sacc, Sdec)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub



    ''' <summary>
    ''' 设定 S 形曲线运动的起始速度、运行速度、总加速时间、S 段加减速时间
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Min_Vel"></param>起始速度，单位 pps
    ''' <param name="Max_Vel"></param>运行速度，单位 pps
    ''' <param name="Tacc"></param>总加速时间，单位 s
    ''' <param name="Tdec"></param>总减速时间，单位 s
    ''' <remarks></remarks>
    Public Overrides Sub SetSTProfile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
        'mMust.WaitOne()
        'Try
        '    d5400_set_st_profile(axis, Min_Vel, Max_Vel, Tacc, Tdec, Tsacc, Tsdec)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub



    ''' <summary>
    ''' 在单轴绝对运动中改变目标位置。注意：该函数仅能在绝对位置模式下使用
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="Dist"></param>绝对位置值
    ''' <remarks></remarks>
    Public Overrides Sub ResetTargetPosition(ByVal axis As Int16, ByVal Dist As Int32)
        mMust.WaitOne()
        Try
            d5400_reset_target_position(axis, Dist)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 指定任意两轴以对称的梯形速度曲线做插补运动
    ''' </summary>
    ''' <param name="AXIS1"></param>指定两轴插补的第一轴
    ''' <param name="Dist1"></param>指定 axis1 的位移值，单位：脉冲数
    ''' <param name="AXIS2"></param>指定两轴插补的第二轴
    ''' <param name="Dist2"></param>指定 axis2 的位移值，单位：脉冲数
    ''' <param name="posi_mode"></param>
    ''' <remarks></remarks>
    Public Overrides Sub Line2(ByVal AXIS1 As Int16, ByVal Dist1 As Int32, ByVal AXIS2 As Int16, ByVal Dist2 As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d5400_t_line2(AXIS1, Dist1, AXIS2, Dist2, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub



    ''' <summary>
    ''' 指定任意三轴以对称的梯形速度曲线做插补运动
    ''' </summary>
    ''' <param name="axis"></param>轴号列表的指针
    ''' <param name="Dist1"></param>指定 axis[0]轴的位移值，单位：脉冲数
    ''' <param name="Dist2"></param>指定 axis[1]轴的位移值，单位：脉冲数
    ''' <param name="Dist3"></param>指定 axis[2]轴的位移值，单位：脉冲数
    ''' <param name="posi_mode"></param>位移模式设定：0 表示相对位移，1 表示绝对位移
    ''' <remarks></remarks>
    Public Overrides Sub Line3(ByVal axis As ArrayList, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d5400_t_line3(axis, Dist1, Dist2, Dist3, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub



    ''' <summary>
    ''' 指定四轴以对称的梯形速度曲线做插补运动
    ''' </summary>
    ''' <param name="cardno"></param>指定插补运动的板卡号, 范围（0 － N - 1 ,N 为卡数）
    ''' <param name="Dist1"></param>指定第一轴的位移值，单位：脉冲数
    ''' <param name="Dist2"></param>指定第二轴的位移值，单位：脉冲数
    ''' <param name="Dist3"></param>指定第三轴的位移值，单位：脉冲数
    ''' <param name="Dist4"></param>指定第四轴的位移值，单位：脉冲数
    ''' <param name="posi_mode"></param>位移模式设定：0 表示相对位移，1 表示绝对位移
    ''' <remarks></remarks>
    Public Overrides Sub Line4(ByVal cardno As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal Dist4 As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d5400_t_line4(cardno, Dist1, Dist2, Dist3, Dist4, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 指定任意的两轴以当前位置为起点，按指定的圆心、目标绝对位置和方向作圆弧插补运动，
    ''' </summary>
    ''' <param name="axis"></param>轴号列表指针
    ''' <param name="target_pos">目标位置列表（指定圆弧终点）</param> 
    ''' <param name="cen_pos">圆心绝对位置列表指针 </param>
    ''' <param name="arc_dir">圆弧方向：0 表示顺时针，1 表示逆时针</param>
    ''' <remarks></remarks>
    Public Overrides Sub ArcMove(ByVal axis As ArrayList, ByVal target_pos As ArrayList, ByVal cen_pos As ArrayList, ByVal arc_dir As Short)
        mMust.WaitOne()
        Try
            d5400_arc_move(axis, target_pos, cen_pos, arc_dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 指定任意的两轴以当前位置为起点，按指定的圆心、目标绝对位置和方向作圆弧插补运动，
    ''' </summary>
    ''' <param name="axis"></param>轴号列表指针
    ''' <param name="target_pos">目标位置列表（指定圆弧终点）</param> 
    ''' <param name="cen_pos">圆心绝对位置列表指针 </param>
    ''' <param name="arc_dir">圆弧方向：0 表示顺时针，1 表示逆时针</param>
    ''' <remarks></remarks>
    Public Overrides Sub relArcMove(ByVal axis As ArrayList, ByVal target_pos As ArrayList, ByVal cen_pos As ArrayList, ByVal arc_dir As Short)
        mMust.WaitOne()
        Try
            d5400_rel_arc_move(axis, target_pos, cen_pos, arc_dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 设置输入手轮脉冲信号的计数方式
    ''' </summary>
    ''' <param name="axis"></param>指定轴号
    ''' <param name="inmode"></param>表示输入方式：0－A、B 相位正交计数，1－双脉冲信号
    ''' <param name="count_dir"></param>计数器的计数方向及倍率设置：设置手轮的倍率, 正数表示默认方向, 负数表示与默认方向相反.
    ''' <remarks></remarks>
    Public Overrides Sub SetHandwheelInmode(ByVal axis As Int16, ByVal inmode As Int16, ByVal count_dir As Int16)
        mMust.WaitOne()
        Try
            d5400_set_handwheel_inmode(axis, inmode, count_dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 启动指定轴的手轮脉冲运动
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="vh"></param>最大脉冲输入频率，单位 pps
    ''' <remarks></remarks>
    Public Overrides Sub HandwheelMove(ByVal axis As Int16, ByVal vh As Double)
        mMust.WaitOne()
        Try
            d5400_handwheel_move(axis, vh)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 读取指定轴编码器反馈位置脉冲计数值
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns></returns>位置反馈脉冲值，单位：脉冲数
    ''' <remarks></remarks>
    Public Overrides Function GetEncoder(ByVal axis As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d5400_get_encoder(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function



    ''' <summary>
    ''' 设置指定轴编码器反馈脉冲计数值，范围：28 位有符号数
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="encoder_value"></param>编码器的设定值。
    ''' <remarks></remarks>
    Public Overrides Sub SetEncode(ByVal axis As Int16, ByVal encoder_value As Int32)
        mMust.WaitOne()
        Try
            d5400_set_encoder(axis, encoder_value)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub



    ''' <summary>
    ''' 设置编码器的计数方式
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="mode"></param>编码器的计数方式,0 非 A/B 相 (脉冲/方向)  1 1×A/B  2 2× A/B  3 4× A/B
    ''' <remarks></remarks>
    Public Overrides Sub CounterConfig(ByVal axis As Int16, ByVal mode As Int16)
        'mMust.WaitOne()
        'Try

        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub


    ''' <summary>
    ''' 设置指定轴“锁存”信号的有效电平及其和工作方式。
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="ltc_logic"></param>LTC 信号逻辑电平：0－低有效，1－高有效
    ''' <param name="ltc_mode"></param>保留
    ''' <remarks></remarks>
    Public Overrides Sub ConfigLTC(ByVal axis As Int16, ByVal ltc_logic As Int16, ByVal ltc_mode As Int16)
        mMust.WaitOne()
        Try
            d5400_config_LTC_PIN(axis, ltc_logic, ltc_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 读取编码器锁存器的值
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns></returns>锁存器内的编码器脉冲数，单位：脉冲
    ''' <remarks></remarks>
    Public Overrides Function GetLatchValue(ByVal axis As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_get_latch_value(axis)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function



    ''' <summary>
    ''' 读取指定控制卡的锁存器的标志位
    ''' </summary>
    ''' <param name="axis"></param>指定控制卡号, 范围（0 － N - 1 ,N 为卡数）
    ''' <returns></returns>返回32位数据  每一位不同
    ''' <remarks></remarks>
    Public Overrides Function GetLatchFlag(ByVal axis As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_get_latch_flag(axis)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function


    ''' <summary>
    ''' 复位指定控制卡的锁存器的标志位
    ''' </summary>
    ''' <param name="cardno"></param>指定控制卡号
    ''' <remarks></remarks>
    Public Overrides Sub ResetLatchFlag(ByVal cardno As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_reset_latch_flag(cardno)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub


    ''' <summary>
    ''' 读取指定控制卡的计数器的标识位
    ''' </summary>
    ''' <param name="cardno"></param>指定控制卡号
    ''' <returns></returns>返回32位数据  每一位不同
    ''' <remarks></remarks>
    Public Overrides Function GetCounterFlag(ByVal cardno As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_get_counter_flag(cardno)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function



    ''' <summary>
    ''' 复位计数器的计数标志位, 范围（0 － N - 1 ,N 为卡数）
    ''' </summary>
    ''' <param name="cardno"></param>指定控制卡号
    ''' <remarks></remarks>
    Public Overrides Sub ResetCounterFlag(ByVal cardno As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_reset_counter_flag(cardno)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub


    ''' <summary>
    ''' 复位计数器的清零标志位, 范围（0 － N - 1 ,N 为卡数）
    ''' </summary>
    ''' <param name="cardno"></param>指定控制卡号
    ''' <remarks></remarks>
    Public Overrides Sub ResetClearFlag(ByVal cardno As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_reset_clear_flag(cardno)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub


    ''' <summary>
    ''' 设置指定轴的 EZ 信号的有效电平及其作用
    ''' </summary>
    ''' <param name="axis"></param>指定轴号
    ''' <param name="ez_logic"></param>EZ 信号逻辑电平：0－低有效，1－高有效
    ''' <param name="ez_mode"></param>EZ 信号的工作方式：0－EZ 信号无效，1－EZ 是计数器复位信号
    ''' <remarks></remarks>
    Public Overrides Sub Config_EZ(ByVal axis As Int16, ByVal ez_logic As Int16, ByVal ez_mode As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_config_EZ_PIN(axis, ez_logic, ez_mode)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try

    End Sub


    ''' <summary>
    ''' 设置锁存方式为单轴锁存或是四轴同时锁存
    ''' </summary>
    ''' <param name="cardno"></param>指定控制卡号
    ''' <param name="all_enable"></param>锁存方式 ：0－单独锁存， 1－四轴同时锁存
    ''' <remarks></remarks>
    Public Overrides Sub ConfigLatchMode(ByVal cardno As Int16, ByVal all_enable As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_config_latch_mode(cardno, all_enable)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub



    ''' <summary>
    ''' 选择全部锁存时的外触发信号通道；可以由二个信号通道输入， 即 LTC0,
    ''' </summary>
    ''' <param name="cardno"></param>卡号
    ''' <param name="num"></param>信号通道选择号 0：LTC0 锁存四个轴 1：LTC1 锁存四个轴
    ''' <remarks></remarks>
    Public Overrides Sub TrigerChunnel(ByVal cardno As Int16, ByVal num As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_triger_chunnel(cardno, num)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub


    ''' <summary>
    ''' 选择编码器 Speaker 和 LED 的输出逻辑, 默认为低有效
    ''' </summary>
    ''' <param name="cardno"></param>卡号
    ''' <param name="logic"></param> 0：低有效， 1：高有效
    ''' <remarks></remarks>
    Public Overrides Sub SetSpeakerLogic(ByVal cardno As Int16, ByVal logic As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_set_speaker_logic(cardno, logic)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub


    ''' <summary>
    '''  EMG 信号设置，急停信号有效后会立即停止所有轴
    ''' </summary>
    ''' <param name="cardno"></param>卡号
    ''' <param name="enable"></param>0：无效; 1:有效
    ''' <param name="emg_logic"></param>0：:低有效; 1:高有效
    ''' <remarks></remarks>
    Public Overrides Sub ConfigEMG(ByVal cardno As Int16, ByVal enable As Int16, ByVal emg_logic As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_config_EMG_PIN(cardno, enable, emg_logic)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cardno"></param>
    ''' <param name="width"></param>
    ''' <param name="enable"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ConfigLTCFilter(ByVal cardno As Int16, ByVal width As Int16, ByVal enable As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_config_LTC_filter(cardno, width, enable)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="width"></param>
    ''' <param name="enable"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ConfigEncoderFilter(ByVal axis As Int16, ByVal width As Int16, ByVal enable As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_config_encoder_filter(axis, width, enable)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub


    ''' <summary>
    ''' 读取指定轴的比较输出端口的电平
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns></returns>1－高电平；0－低电平
    ''' <remarks></remarks>
    Public Overrides Function ReadCMP(ByVal axis As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_read_CMP_PIN(axis)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function



    ''' <summary>
    ''' 设置指定轴的位置比较输出端口的电平
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="on_off"></param>on_off 1－高电平；0－低电平
    ''' <remarks></remarks>
    Public Overrides Sub WriteCMP(ByVal axis As Int16, ByVal on_off As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_write_CMP_PIN(axis, on_off)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub

    ''' <summary>
    ''' 配置位置比较输出端口的功能
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="cmp1_enable"></param>配置 CMP1(X 轴)、CMP2(Y 轴)、CMP3(Z 轴)、CMP4(A
    ''' <param name="cmp2_enable"></param>配置 CMP1’(X 轴)、CMP2’(Y 轴)、CMP3’(Z 轴)、
    ''' <param name="CMP_logic"></param>0－负逻辑；1－正逻辑
    ''' <remarks></remarks>
    Public Overrides Sub ConfigCMP(ByVal axis As Int16, ByVal cmp1_enable As Int16, ByVal cmp2_enable As Int16, ByVal CMP_logic As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_config_CMP_PIN(axis, cmp1_enable, cmp2_enable, CMP_logic)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub
    ''' <summary>
    ''' 配置指定轴 2 个比较器的触发条件。
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="cmp1_condition"></param>比较器 1 的触发条件
    ''' <param name="cmp2_condition"></param>比较器 2 的触发条件
    ''' <param name="source_sel"></param>配置计数器类型
    ''' <param name="SL_action"></param>保留
    ''' <remarks></remarks>
    Public Overrides Sub ConfigComparator(ByVal axis As Int16, ByVal cmp1_condition As Int16, ByVal cmp2_condition As Int16, ByVal source_sel As Int16, ByVal SL_action As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_config_comparator(axis, cmp1_condition, cmp2_condition, source_sel, SL_action)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub



    ''' <summary>
    ''' 预置比较器数值
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="cmp1_data"></param>比较器 1 的值
    ''' <param name="cmp2_data"></param>比较器 2 的值
    ''' <remarks></remarks>
    Public Overrides Sub SetComparatorData(ByVal axis As Int16, ByVal cmp1_data As Int32, ByVal cmp2_data As Int32)
        'mMust.WaitOne()
        'Try
        '    d5400_set_comparator_data(axis, cmp1_data, cmp2_data)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="equiv"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetEquiv(ByVal axis As Int16, ByRef equiv As Double) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_get_equiv(axis, equiv)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="new_equiv"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function SetEquiv(ByVal axis As Int16, ByVal new_equiv As Double) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_set_equiv(axis, new_equiv)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="target_pos"></param>
    ''' <param name="cen_pos"></param>
    ''' <param name="arc_dir"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ArcMoveUnitmm(ByRef axis As Int16, ByRef target_pos As Double, ByRef cen_pos As Double, ByVal arc_dir As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_arc_move_unitmm(axis, target_pos, cen_pos, arc_dir)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="rel_pos"></param>
    ''' <param name="rel_cen"></param>
    ''' <param name="arc_dir"></param>
    ''' <remarks></remarks>
    Public Overrides Sub RelArcMoveUnitmm(ByRef axis As Int16, ByRef rel_pos As Double, ByRef rel_cen As Double, ByVal arc_dir As Int16)
        'mMust.WaitOne()
        'Try
        '    d5400_rel_arc_move_unitmm(axis, rel_pos, rel_cen, arc_dir)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub



    ''' <summary>
    ''' 设置多轴同步运动的运动参数
    ''' </summary>
    ''' <param name="TotalAxes"></param>TotalAxes 同步运动轴的数量
    ''' <param name="pAxis"></param>轴号列表指针
    ''' <param name="pDist"></param>距离列表指针，单位：当量脉冲数
    ''' <param name="posi_mode"></param>位置模式：0 表示相对位置，1 表示绝对位置
    ''' <returns></returns>1 表示正常；－1 表示参数错
    ''' <remarks></remarks>
    Public Overrides Function SetTMoveAll(ByVal TotalAxes As Int16, ByRef pAxis As Int16, ByRef pDist As Int32, ByVal posi_mode As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_set_t_move_all(TotalAxes, pAxis, pDist, posi_mode)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function



    ''' <summary>
    ''' 按照预设运动参数，开始多轴同步运动
    ''' </summary>
    ''' <param name="FirstAxis"></param>FirstAxis 第一轴轴号
    ''' <returns></returns>1 表示正常；－1 表示参数错
    ''' <remarks></remarks>
    Public Overrides Function StartMoveAll(ByVal FirstAxis As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_start_move_all(FirstAxis)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function



    ''' <summary>
    ''' 多轴同步选项的设置
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="sync_stop_on"></param>sync_stop_on 1 表示有 CSTP,轴停止；0 表示有 CSTP 时，轴不停
    ''' <param name="cstop_output_on"></param>cstop_output_on 1 表示当异常停止时，输出 CSTP；0 表示不输出
    ''' <param name="sync_option1"></param> 0 表示立即启动该功能；1 表示等待 CSTA 后启动该功能
    ''' <param name="sync_option2"></param>保留
    ''' <returns></returns>1 表示正常；－1 表示参数错
    ''' <remarks></remarks>
    Public Overrides Function SetSyncOption(ByVal axis As Int16, ByVal sync_stop_on As Int16, ByVal cstop_output_on As Int16, ByVal sync_option1 As Int16, ByVal sync_option2 As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_set_sync_option(axis, sync_stop_on, cstop_output_on, sync_option1, sync_option2)
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function



    ''' <summary>
    ''' 设置同步停止的模式
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="stop_mode"></param>stop_mode 停止模式：0 表示立即停止；1 表示减速停止
    ''' <returns></returns>1 表示正常；－1 表示参数错
    ''' <remarks></remarks>
    Public Overrides Function SetSyncStopMode(ByVal axis As Int16, ByVal stop_mode As Int16) As Int32
        'mMust.WaitOne()
        'Try
        '    Return d5400_set_sync_stop_mode(axis, stop_mode)
        'Catch ex As Exception

        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub BoardRest()
        'mMust.WaitOne()
        'Try
        '    d5400_board_rest()
        'Catch ex As Exception
        'Finally
        '    mMust.ReleaseMutex()
        'End Try
    End Sub

#End Region

End Class
