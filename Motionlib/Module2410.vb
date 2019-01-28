Module Module2410

    Private mMust As New Threading.Mutex(False)

    Private Declare Function d2410_board_init Lib "DMC2410.dll" () As Int16
    Private Declare Sub d2410_board_close Lib "DMC2410.dll" ()

    '脉冲输入输出配置
    Private Declare Sub d2410_set_pulse_outmode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal outmode As Int16)

    '专用信号设置函数
    Private Declare Sub d2410_config_SD_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal sd_logic As Int16, ByVal sd_mode As Int16)
    Private Declare Sub d2410_config_PCS_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal pcs_logic As Int16)
    Private Declare Sub d2410_config_INP_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal inp_logic As Int16)
    Private Declare Sub d2410_config_ERC_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal erc_logic As Int16, ByVal erc_width As Int16, ByVal erc_off_time As Int16)
    Private Declare Sub d2410_config_ALM_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal alm_logic As Int16, ByVal alm_action As Int16)
    Private Declare Sub d2410_config_EL_MODE Lib "DMC2410.dll" (ByVal axis As Int16, ByVal el_mode As Int16)
    Private Declare Sub d2410_set_HOME_pin_logic Lib "DMC2410.dll" (ByVal axis As Int16, ByVal org_logic As Int16, ByVal filter As Int16)

    Private Declare Function d2410_read_SEVON_PIN Lib "DMC2410.dll" (ByVal axis As Int16) As Int32
    Private Declare Sub d2410_write_SEVON_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal on_off As Int16)
    Private Declare Sub d2410_write_ERC_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal sel As Int16)
    Private Declare Function d2410_read_RDY_PIN Lib "DMC2410.dll" (ByVal axis As Int16) As Int32

    '通用输入/输出控制函数
    Private Declare Function d2410_read_inbit Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
    Private Declare Sub d2410_write_outbit Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal BitNo As Int16, ByVal on_off As Int16)
    Private Declare Function d2410_read_outbit Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
    Private Declare Function d2410_read_inport Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Private Declare Function d2410_read_outport Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Private Declare Sub d2410_write_outport Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal Port_Value As Int32)


    '找原点
    Private Declare Sub d2410_config_home_mode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal mode As Int16, ByVal EZ_count As Int16)
    Private Declare Sub d2410_home_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16)

    '制动函数
    Private Declare Sub d2410_decel_stop Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Tdec As Double)
    Private Declare Sub d2410_imd_stop Lib "DMC2410.dll" (ByVal axis As Int16)
    Private Declare Sub d2410_emg_stop Lib "DMC2410.dll" ()
    Private Declare Sub d2410_simultaneous_stop Lib "DMC2410.dll" (ByVal axis As Int16)

    '位置设置和读取函数
    Private Declare Function d2410_get_position Lib "DMC2410.dll" (ByVal axis As Int16) As Integer

    Private Declare Sub d2410_set_position Lib "DMC2410.dll" (ByVal axis As Int16, ByVal current_position As Integer)

    '状态检测函数
    Private Declare Function d2410_check_done Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Private Declare Function d2410_prebuff_status Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Private Declare Function d2410_axis_io_status Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Private Declare Function d2410_axis_status Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Private Declare Function d2410_get_rsts Lib "DMC2410.dll" (ByVal axis As Int16) As Int32

    '单轴定长运动
    Private Declare Sub d2410_t_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As UInt16, ByVal posi_mode As Int16)

    Private Declare Sub d2410_ex_t_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
    Private Declare Sub d2410_s_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
    Private Declare Sub d2410_ex_s_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)

    '单轴连续运动
    Private Declare Sub d2410_s_vmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dir As Int16)
    Private Declare Sub d2410_t_vmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dir As Int16)


    '速度设置
    Private Declare Sub d2410_variety_speed_range Lib "DMC2410.dll" (ByVal axis As Int16, ByVal chg_enable As Int16, ByVal Max_Vel As Double)
    Private Declare Function d2410_read_current_speed Lib "DMC2410.dll" (ByVal axis As Int16) As Double
    Private Declare Sub d2410_change_speed Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Curr_Vel As Double)
    Private Declare Sub d2410_set_vector_profile Lib "DMC2410.dll" (ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
    Private Declare Sub d2410_set_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
    Private Declare Sub d2410_set_s_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Sacc As Int32, ByVal Sdec As Int32)
    Private Declare Sub d2410_set_st_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Tsacc As Double, ByVal Tsdec As Double)

    Private Declare Sub d2410_reset_target_position Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32)

    '线性插补
    Private Declare Sub d2410_t_line2 Lib "DMC2410.dll" (ByVal AXIS1 As Int16, ByVal Dist1 As Int32, ByVal AXIS2 As Int16, ByVal Dist2 As Int32, ByVal posi_mode As Int16)
    Private Declare Sub d2410_t_line3 Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal posi_mode As Int16)
    Private Declare Sub d2410_t_line4 Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal Dist4 As Int32, ByVal posi_mode As Int16)

    '圆弧插补
    Private Declare Sub d2410_arc_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal target_pos As Int32, ByVal cen_pos As Int32, ByVal arc_dir As Int16)
    Private Declare Sub d2410_rel_arc_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal target_pos As Int32, ByVal cen_pos As Int32, ByVal arc_dir As Int16)


    '手轮运动
    Private Declare Sub d2410_set_handwheel_inmode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal inmode As Int16, ByVal count_dir As Int16)
    Private Declare Sub d2410_handwheel_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal vh As Double)


    '//---------------------   编码器计数功能PLD  ----------------------//
    Private Declare Function d2410_get_encoder Lib "DMC2410.dll" (ByVal axis As Int16) As Int32
    Private Declare Sub d2410_set_encoder Lib "DMC2410.dll" (ByVal axis As Int16, ByVal encoder_value As Int32)

    Private Declare Sub d2410_counter_config Lib "DMC2410.dll" (ByVal axis As Int16, ByVal mode As Int16)
    Private Declare Sub d2410_config_LTC_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal ltc_logic As Int16, ByVal ltc_mode As Int16)

    Private Declare Function d2410_get_latch_value Lib "DMC2410.dll" (ByVal axis As Int16) As Int32

    Private Declare Function d2410_get_latch_flag Lib "DMC2410.dll" (ByVal cardno As Int16) As Int32
    Private Declare Sub d2410_reset_latch_flag Lib "DMC2410.dll" (ByVal cardno As Int16)

    Private Declare Function d2410_get_counter_flag Lib "DMC2410.dll" (ByVal cardno As Int16) As Int32
    Private Declare Sub d2410_reset_counter_flag Lib "DMC2410.dll" (ByVal cardno As Int16)

    Private Declare Sub d2410_reset_clear_flag Lib "DMC2410.dll" (ByVal cardno As Int16)

    '//---------------------   DMC2410新加功能 ----------------------//
    Private Declare Sub d2410_config_EZ_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal ez_logic As Int16, ByVal ez_mode As Int16)

    Private Declare Sub d2410_config_latch_mode Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal all_enable As Int16)

    Private Declare Sub d2410_triger_chunnel Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal num As Int16)

    Private Declare Sub d2410_set_speaker_logic Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal logic As Int16)

    Private Declare Sub d2410_config_EMG_PIN Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal enable As Int16, ByVal emg_logic As Int16)

    Private Declare Sub d2410_config_LTC_filter Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal width As Int16, ByVal enable As Int16)
    Private Declare Sub d2410_config_encoder_filter Lib "DMC2410.dll" (ByVal axis As Int16, ByVal width As Int16, ByVal enable As Int16)

    '增加位置比较输出功能
    Private Declare Function d2410_read_CMP_PIN Lib "DMC2410.dll" (ByVal axis As Int16) As Int32
    Private Declare Sub d2410_write_CMP_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal on_off As Int16)

    Private Declare Sub d2410_config_CMP_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal cmp1_enable As Int16, ByVal cmp2_enable As Int16, ByVal CMP_logic As Int16)

    '软件限位控制函数
    Private Declare Sub d2410_config_comparator Lib "DMC2410.dll" (ByVal axis As Int16, ByVal cmp1_condition As Int16, ByVal cmp2_condition As Int16, ByVal source_sel As Int16, ByVal SL_action As Int16)

    Private Declare Sub d2410_set_comparator_data Lib "DMC2410.dll" (ByVal axis As Int16, ByVal cmp1_data As Int32, ByVal cmp2_data As Int32)


    '不同脉冲当量的圆弧插补
    Private Declare Function d2410_get_equiv Lib "DMC2410.dll" (ByVal axis As Int16, ByRef equiv As Double) As Int32
    Private Declare Function d2410_set_equiv Lib "DMC2410.dll" (ByVal axis As Int16, ByVal new_equiv As Double) As Int32

    Private Declare Sub d2410_arc_move_unitmm Lib "DMC2410.dll" (ByRef axis As Int16, ByRef target_pos As Double, ByRef cen_pos As Double, ByVal arc_dir As Int16)
    Private Declare Sub d2410_rel_arc_move_unitmm Lib "DMC2410.dll" (ByRef axis As Int16, ByRef rel_pos As Double, ByRef rel_cen As Double, ByVal arc_dir As Int16)


    '//增加同时起停操作
    Private Declare Function d2410_set_t_move_all Lib "DMC2410.dll" (ByVal TotalAxes As Int16, ByRef pAxis As Int16, ByRef pDist As Int32, ByVal posi_mode As Int16) As Int32
    Private Declare Function d2410_start_move_all Lib "DMC2410.dll" (ByVal FirstAxis As Int16) As Int32

    Private Declare Function d2410_set_sync_option Lib "DMC2410.dll" (ByVal axis As Int16, ByVal sync_stop_on As Int16, ByVal cstop_output_on As Int16, ByVal sync_option1 As Int16, ByVal sync_option2 As Int16) As Int32
    Private Declare Function d2410_set_sync_stop_mode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal stop_mode As Int16) As Int32
    Private Declare Sub d2410_board_rest Lib "DMC2410.dll" ()


    Private Declare Function d2410_pulse_loop Lib "DMC2410.dll" (ByVal axis As Int16) As Int16


#Region "底层函数"
    Public Function Init() As Int16
        mMust.WaitOne()
        Try
            Return d2410_board_init()

        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try


    End Function

    ''' <summary>
    ''' 关闭控制卡，释放系统资源
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()
        mMust.WaitOne()
        Try
            d2410_board_close()

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
    Public Sub PulseOutmode(ByVal axis As Int16, ByVal outmode As Int16)
        mMust.WaitOne()
        Try
            d2410_set_pulse_outmode(axis, outmode)
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
    Public Sub SD(ByVal axis As Int16, ByVal enable As Int16, ByVal sd_logic As Int16, ByVal sd_mode As Int16)
        mMust.WaitOne()
        Try
            d2410_config_SD_PIN(axis, enable, sd_logic, sd_logic)
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
    Public Sub PCS(ByVal axis As Int16, ByVal enable As Int16, ByVal pcs_logic As Int16)
        mMust.WaitOne()
        Try
            d2410_config_PCS_PIN(axis, enable, pcs_logic)
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
    Public Sub INP(ByVal axis As Int16, ByVal enable As Int16, ByVal inp_logic As Int16)
        mMust.WaitOne()
        Try
            d2410_config_INP_PIN(axis, enable, inp_logic)
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
    Public Sub ERC(ByVal axis As Int16, ByVal enable As Int16, ByVal erc_logic As Int16, ByVal erc_width As Int16, ByVal erc_off_time As Int16)
        mMust.WaitOne()
        Try
            d2410_config_ERC_PIN(axis, enable, erc_logic, erc_width, erc_off_time)
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
    Public Sub ALM(ByVal axis As Int16, ByVal alm_logic As Int16, ByVal alm_action As Int16)
        mMust.WaitOne()
        Try
            d2410_config_ALM_PIN(axis, alm_logic, alm_action)
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
    Public Sub ELMODE(ByVal axis As Int16, ByVal el_mode As Int16)
        mMust.WaitOne()
        Try
            d2410_config_EL_MODE(axis, el_mode)
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
    Public Sub SetHome(ByVal axis As Int16, ByVal org_logic As Int16, ByVal filter As Int16)
        mMust.WaitOne()
        Try
            d2410_set_HOME_pin_logic(axis, org_logic, filter)
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
    Public Function ReadSEVON(ByVal axis As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_read_SEVON_PIN(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    ''' <summary>
    ''' 输出对指定轴的伺服使能端子的控制
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="on_off">设定管脚电平状态：0－低，1－高。SEVON输出口初始状态可选。</param>
    ''' <remarks></remarks>
    Public Sub writeSEVON(ByVal axis As Int16, ByVal on_off As Int16)
        mMust.WaitOne()
        Try
            d2410_write_SEVON_PIN(axis, on_off)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 控制指定轴“误差清除”端子信号的输出
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="sel">0－复位ERC信号，1－输出ERC信号</param>
    ''' <remarks></remarks>
    Public Sub WriteERC(ByVal axis As Int16, ByVal sel As Int16)
        mMust.WaitOne()
        Try
            d2410_write_ERC_PIN(axis, sel)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 读取指定运动轴的“伺服准备好”端子的电平状态
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <returns>0－低电平，1－高电平</returns>
    ''' <remarks></remarks>
    Public Function ReadRDY(ByVal axis As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_read_RDY_PIN(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Function ReadInbit(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_read_inbit(cardno, BitNo)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Sub WriteOutbit(ByVal cardno As Int16, ByVal BitNo As Int16, ByVal on_off As Int16)
        mMust.WaitOne()
        Try
            d2410_write_outbit(cardno, BitNo, on_off)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Function ReadOutbit(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_read_outbit(cardno, BitNo)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Function ReadInport(ByVal card As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_read_inport(card)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Function ReadOutport(ByVal card As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_read_outport(card)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Sub WriteOutport(ByVal cardno As Int16, ByVal Port_Value As Int32)
        mMust.WaitOne()
        Try
            d2410_write_outport(cardno, Port_Value)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub




    Public Sub HomeMode(ByVal axis As Int16, ByVal mode As Int16, ByVal EZ_count As Int16)
        mMust.WaitOne()
        Try
            d2410_config_home_mode(axis, mode, EZ_count)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub HomeMove(ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16)
        mMust.WaitOne()

        Try
            d2410_home_move(axis, home_mode, vel_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub DecelStop(ByVal axis As Int16, ByVal Tdec As Double)
        mMust.WaitOne()
        Try
            d2410_decel_stop(axis, Tdec)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ImdStop(ByVal axis As Int16)
        mMust.WaitOne()
        Try
            d2410_imd_stop(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub EmgStop()
        mMust.WaitOne()
        Try
            d2410_emg_stop()
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub SimultaneousStop(ByVal axis As Int16)
        mMust.WaitOne()
        Try
            d2410_simultaneous_stop(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Function GetPosition(ByVal axis As Int16) As Long
        mMust.WaitOne()
        Try
            Return d2410_get_position(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Sub SetPosition(ByVal axis As Int16, ByVal current_position As Integer)
        mMust.WaitOne()
        Try
            d2410_set_position(axis, current_position)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Function GetCheckDone(ByVal axis As Int16) As Int16
        mMust.WaitOne()
        Try
            Return d2410_check_done(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Function GetPrebuffStatus(ByVal axis As Int16) As Int16
        mMust.WaitOne()
        Try
            Return d2410_prebuff_status(axis)
        Catch ex As Exception

        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Function GetIoStatus(ByVal axis As Int16) As Int16
        mMust.WaitOne()
        Try
            Return d2410_axis_io_status(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try

    End Function

    Public Function GetAxisStatus(ByVal axis As Int16) As Int16
        mMust.WaitOne()
        Try
            Return d2410_axis_status(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try

    End Function

    Public Function GetRsts(ByVal axis As Int16) As Int16
        mMust.WaitOne()
        Try
            Return d2410_get_rsts(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Sub TPmove(ByVal axis As Int16, ByVal Dist As UInt16, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d2410_t_pmove(axis, Dist, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ExTPmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d2410_ex_t_pmove(axis, Dist, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub SPmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d2410_s_pmove(axis, Dist, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ExSPmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d2410_ex_s_pmove(axis, Dist, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub SVmove(ByVal axis As Int16, ByVal Dir As Int16)
        mMust.WaitOne()
        Try
            d2410_s_vmove(axis, Dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub TVmove(ByVal axis As Int16, ByVal Dir As Int16)
        mMust.WaitOne()
        Try
            d2410_t_vmove(axis, Dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub VarietySpeed(ByVal axis As Int16, ByVal chg_enable As Int16, ByVal Max_Vel As Double)
        mMust.WaitOne()
        Try
            d2410_variety_speed_range(axis, chg_enable, Max_Vel)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Function ReadCurrentSpeed(ByVal axis As Int16) As Double
        mMust.WaitOne()
        Try
            Return d2410_read_current_speed(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Sub ChangeSpeed(ByVal axis As Int16, ByVal Curr_Vel As Double)
        mMust.WaitOne()
        Try
            d2410_change_speed(axis, Curr_Vel)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try

    End Sub

    Public Sub SetVectorProfile(ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
        mMust.WaitOne()
        Try
            d2410_set_vector_profile(Min_Vel, Max_Vel, Tacc, Tdec)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub SetProfile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
        mMust.WaitOne()
        Try
            d2410_set_profile(axis, Min_Vel, Max_Vel, Tacc, Tdec)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub SetSProfile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Sacc As Int32, ByVal Sdec As Int32)
        mMust.WaitOne()
        Try
            d2410_set_s_profile(axis, Min_Vel, Max_Vel, Tacc, Tdec, Sacc, Sdec)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub SetSTProfile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Tsacc As Double, ByVal Tsdec As Double)
        mMust.WaitOne()
        Try
            d2410_set_st_profile(axis, Min_Vel, Max_Vel, Tacc, Tdec, Tsacc, Tsdec)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ResetTargetPosition(ByVal axis As Int16, ByVal Dist As Int32)
        mMust.WaitOne()
        Try
            d2410_reset_target_position(axis, Dist)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub Line2(ByVal AXIS1 As Int16, ByVal Dist1 As Int32, ByVal AXIS2 As Int16, ByVal Dist2 As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d2410_t_line2(AXIS1, Dist1, AXIS2, Dist2, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub Line3(ByVal axis As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d2410_t_line3(axis, Dist1, Dist2, Dist3, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub Line4(ByVal cardno As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal Dist4 As Int32, ByVal posi_mode As Int16)
        mMust.WaitOne()
        Try
            d2410_t_line4(cardno, Dist1, Dist2, Dist3, Dist4, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ArcMove(ByVal axis As Int16, ByVal target_pos As Int32, ByVal cen_pos As Int32, ByVal arc_dir As Int16)
        mMust.WaitOne()
        Try
            d2410_arc_move(axis, target_pos, cen_pos, arc_dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub relArcMove(ByVal axis As Int16, ByVal target_pos As Int32, ByVal cen_pos As Int32, ByVal arc_dir As Int16)
        mMust.WaitOne()
        Try
            d2410_rel_arc_move(axis, target_pos, cen_pos, arc_dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub SetHandwheelInmode(ByVal axis As Int16, ByVal inmode As Int16, ByVal count_dir As Int16)
        mMust.WaitOne()
        Try
            d2410_set_handwheel_inmode(axis, inmode, count_dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub HandwheelMove(ByVal axis As Int16, ByVal vh As Double)
        mMust.WaitOne()
        Try
            d2410_handwheel_move(axis, vh)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Function GetEncoder(ByVal axis As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_get_encoder(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Sub SetEncode(ByVal axis As Int16, ByVal encoder_value As Int32)
        mMust.WaitOne()
        Try
            d2410_set_encoder(axis, encoder_value)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub CounterConfig(ByVal axis As Int16, ByVal mode As Int16)
        mMust.WaitOne()
        Try
            d2410_counter_config(axis, mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ConfigLTC(ByVal axis As Int16, ByVal ltc_logic As Int16, ByVal ltc_mode As Int16)
        mMust.WaitOne()
        Try
            d2410_config_LTC_PIN(axis, ltc_logic, ltc_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Function GetLatchValue(ByVal axis As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_get_latch_value(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Function GetLatchFlag(ByVal axis As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_get_latch_flag(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Sub ResetLatchFlag(ByVal cardno As Int16)
        mMust.WaitOne()
        Try
            d2410_reset_latch_flag(cardno)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Function GetCounterFlag(ByVal cardno As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_get_counter_flag(cardno)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Sub ResetCounterFlag(ByVal cardno As Int16)
        mMust.WaitOne()
        Try
            d2410_reset_counter_flag(cardno)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ResetClearFlag(ByVal cardno As Int16)
        mMust.WaitOne()
        Try
            d2410_reset_clear_flag(cardno)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    Public Sub Config_EZ(ByVal axis As Int16, ByVal ez_logic As Int16, ByVal ez_mode As Int16)
        mMust.WaitOne()
        Try
            d2410_config_EZ_PIN(axis, ez_logic, ez_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try

    End Sub

    Public Sub ConfigLatchMode(ByVal cardno As Int16, ByVal all_enable As Int16)
        mMust.WaitOne()
        Try
            d2410_config_latch_mode(cardno, all_enable)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub TrigerChunnel(ByVal cardno As Int16, ByVal num As Int16)
        mMust.WaitOne()
        Try
            d2410_triger_chunnel(cardno, num)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub SetSpeakerLogic(ByVal cardno As Int16, ByVal logic As Int16)
        mMust.WaitOne()
        Try
            d2410_set_speaker_logic(cardno, logic)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ConfigEMG(ByVal cardno As Int16, ByVal enable As Int16, ByVal emg_logic As Int16)
        mMust.WaitOne()
        Try
            d2410_config_EMG_PIN(cardno, enable, emg_logic)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ConfigLTCFilter(ByVal cardno As Int16, ByVal width As Int16, ByVal enable As Int16)
        mMust.WaitOne()
        Try
            d2410_config_LTC_filter(cardno, width, enable)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ConfigEncoderFilter(ByVal axis As Int16, ByVal width As Int16, ByVal enable As Int16)
        mMust.WaitOne()
        Try
            d2410_config_encoder_filter(axis, width, enable)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Function ReadCMP(ByVal axis As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_read_CMP_PIN(axis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Sub WriteCMP(ByVal axis As Int16, ByVal on_off As Int16)
        mMust.WaitOne()
        Try
            d2410_write_CMP_PIN(axis, on_off)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ConfigCMP(ByVal axis As Int16, ByVal cmp1_enable As Int16, ByVal cmp2_enable As Int16, ByVal CMP_logic As Int16)
        mMust.WaitOne()
        Try
            d2410_config_CMP_PIN(axis, cmp1_enable, cmp2_enable, CMP_logic)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub ConfigComparator(ByVal axis As Int16, ByVal cmp1_condition As Int16, ByVal cmp2_condition As Int16, ByVal source_sel As Int16, ByVal SL_action As Int16)
        mMust.WaitOne()
        Try
            d2410_config_comparator(axis, cmp1_condition, cmp2_condition, source_sel, SL_action)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub SetComparatorData(ByVal axis As Int16, ByVal cmp1_data As Int32, ByVal cmp2_data As Int32)
        mMust.WaitOne()
        Try
            d2410_set_comparator_data(axis, cmp1_data, cmp2_data)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Function GetEquiv(ByVal axis As Int16, ByRef equiv As Double) As Int32
        mMust.WaitOne()
        Try
            Return d2410_get_equiv(axis, equiv)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Function SetEquiv(ByVal axis As Int16, ByVal new_equiv As Double) As Int32
        mMust.WaitOne()
        Try
            Return d2410_set_equiv(axis, new_equiv)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Sub ArcMoveUnitmm(ByRef axis As Int16, ByRef target_pos As Double, ByRef cen_pos As Double, ByVal arc_dir As Int16)
        mMust.WaitOne()
        Try
            d2410_arc_move_unitmm(axis, target_pos, cen_pos, arc_dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Sub RelArcMoveUnitmm(ByRef axis As Int16, ByRef rel_pos As Double, ByRef rel_cen As Double, ByVal arc_dir As Int16)
        mMust.WaitOne()
        Try
            d2410_rel_arc_move_unitmm(axis, rel_pos, rel_cen, arc_dir)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    Public Function SetTMoveAll(ByVal TotalAxes As Int16, ByRef pAxis As Int16, ByRef pDist As Int32, ByVal posi_mode As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_set_t_move_all(TotalAxes, pAxis, pDist, posi_mode)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Function StartMoveAll(ByVal FirstAxis As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_start_move_all(FirstAxis)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Function SetSyncOption(ByVal axis As Int16, ByVal sync_stop_on As Int16, ByVal cstop_output_on As Int16, ByVal sync_option1 As Int16, ByVal sync_option2 As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_set_sync_option(axis, sync_stop_on, cstop_output_on, sync_option1, sync_option2)
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Function SetSyncStopMode(ByVal axis As Int16, ByVal stop_mode As Int16) As Int32
        mMust.WaitOne()
        Try
            Return d2410_set_sync_stop_mode(axis, stop_mode)
        Catch ex As Exception

        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Sub BoardRest()
        mMust.WaitOne()
        Try
            d2410_board_rest()
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

#End Region
End Module
