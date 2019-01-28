Module Mdl2410


#Region "DMC2410"

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''                 初始化函数                      '''
    Declare Function d2410_board_init Lib "DMC2410.dll" () As Int16
    Declare Sub d2410_board_close Lib "DMC2410.dll" ()

    '脉冲输入输出配置
    Declare Sub d2410_set_pulse_outmode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal outmode As Int16)

    '专用信号设置函数
    Declare Sub d2410_config_SD_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal sd_logic As Int16, ByVal sd_mode As Int16)
    Declare Sub d2410_config_PCS_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal pcs_logic As Int16)
    Declare Sub d2410_config_INP_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal inp_logic As Int16)
    Declare Sub d2410_config_ERC_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal erc_logic As Int16, ByVal erc_width As Int16, ByVal erc_off_time As Int16)
    Declare Sub d2410_config_ALM_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal alm_logic As Int16, ByVal alm_action As Int16)
    Declare Sub d2410_config_EL_MODE Lib "DMC2410.dll" (ByVal axis As Int16, ByVal el_mode As Int16)
    Declare Sub d2410_set_HOME_pin_logic Lib "DMC2410.dll" (ByVal axis As Int16, ByVal org_logic As Int16, ByVal filter As Int16)

    Declare Function d2410_read_SEVON_PIN Lib "DMC2410.dll" (ByVal axis As Int16) As Int32
    Declare Sub d2410_write_SEVON_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal on_off As Int16)
    Declare Sub d2410_write_ERC_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal sel As Int16)
    Declare Function d2410_read_RDY_PIN Lib "DMC2410.dll" (ByVal axis As Int16) As Int32

    '通用输入/输出控制函数
    Declare Function d2410_read_inbit Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
    Declare Sub d2410_write_outbit Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal BitNo As Int16, ByVal on_off As Int16)
    Declare Function d2410_read_outbit Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
    Declare Function d2410_read_inport Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Declare Function d2410_read_outport Lib "DMC2410.dll" (ByVal card As Int16) As Int32
    Declare Sub d2410_write_outport Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal Port_Value As Int32)


    '找原点
    Declare Sub d2410_config_home_mode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal mode As Int16, ByVal EZ_count As Int16)
    Declare Sub d2410_home_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16)

    '制动函数
    Declare Sub d2410_decel_stop Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Tdec As Double)
    Declare Sub d2410_imd_stop Lib "DMC2410.dll" (ByVal axis As Int16)
    Declare Sub d2410_emg_stop Lib "DMC2410.dll" ()
    Declare Sub d2410_simultaneous_stop Lib "DMC2410.dll" (ByVal axis As Int16)

    '位置设置和读取函数
    Declare Function d2410_get_position Lib "DMC2410.dll" (ByVal axis As Int16) As Integer

    Declare Sub d2410_set_position Lib "DMC2410.dll" (ByVal axis As Int16, ByVal current_position As Integer)

    '状态检测函数
    Declare Function d2410_check_done Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Declare Function d2410_prebuff_status Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Declare Function d2410_axis_io_status Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Declare Function d2410_axis_status Lib "DMC2410.dll" (ByVal axis As Int16) As Int16
    Declare Function d2410_get_rsts Lib "DMC2410.dll" (ByVal axis As Int16) As Int32

    '单轴定长运动
    Declare Sub d2410_t_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As UInt16, ByVal posi_mode As Int16)

    Declare Sub d2410_ex_t_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
    Declare Sub d2410_s_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
    Declare Sub d2410_ex_s_pmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)

    '单轴连续运动
    Declare Sub d2410_s_vmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dir As Int16)
    Declare Sub d2410_t_vmove Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dir As Int16)


    '速度设置
    Declare Sub d2410_variety_speed_range Lib "DMC2410.dll" (ByVal axis As Int16, ByVal chg_enable As Int16, ByVal Max_Vel As Double)
    Declare Function d2410_read_current_speed Lib "DMC2410.dll" (ByVal axis As Int16) As Double
    Declare Sub d2410_change_speed Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Curr_Vel As Double)
    Declare Sub d2410_set_vector_profile Lib "DMC2410.dll" (ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
    Declare Sub d2410_set_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
    Declare Sub d2410_set_s_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Sacc As Int32, ByVal Sdec As Int32)
    Declare Sub d2410_set_st_profile Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Tsacc As Double, ByVal Tsdec As Double)

    Declare Sub d2410_reset_target_position Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist As Int32)

    '线性插补
    Declare Sub d2410_t_line2 Lib "DMC2410.dll" (ByVal AXIS1 As Int16, ByVal Dist1 As Int32, ByVal AXIS2 As Int16, ByVal Dist2 As Int32, ByVal posi_mode As Int16)
    Declare Sub d2410_t_line3 Lib "DMC2410.dll" (ByVal axis As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal posi_mode As Int16)
    Declare Sub d2410_t_line4 Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal Dist4 As Int32, ByVal posi_mode As Int16)

    '圆弧插补
    Declare Sub d2410_arc_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal target_pos As Int32, ByVal cen_pos As Int32, ByVal arc_dir As Int16)
    Declare Sub d2410_rel_arc_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal target_pos As Int32, ByVal cen_pos As Int32, ByVal arc_dir As Int16)


    '手轮运动
    Declare Sub d2410_set_handwheel_inmode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal inmode As Int16, ByVal count_dir As Int16)
    Declare Sub d2410_handwheel_move Lib "DMC2410.dll" (ByVal axis As Int16, ByVal vh As Double)


    '//---------------------   编码器计数功能PLD  ----------------------//
    Declare Function d2410_get_encoder Lib "DMC2410.dll" (ByVal axis As Int16) As Int32
    Declare Sub d2410_set_encoder Lib "DMC2410.dll" (ByVal axis As Int16, ByVal encoder_value As Int32)

    Declare Sub d2410_counter_config Lib "DMC2410.dll" (ByVal axis As Int16, ByVal mode As Int16)
    Declare Sub d2410_config_LTC_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal ltc_logic As Int16, ByVal ltc_mode As Int16)

    Declare Function d2410_get_latch_value Lib "DMC2410.dll" (ByVal axis As Int16) As Int32

    Declare Function d2410_get_latch_flag Lib "DMC2410.dll" (ByVal cardno As Int16) As Int32
    Declare Sub d2410_reset_latch_flag Lib "DMC2410.dll" (ByVal cardno As Int16)

    Declare Function d2410_get_counter_flag Lib "DMC2410.dll" (ByVal cardno As Int16) As Int32
    Declare Sub d2410_reset_counter_flag Lib "DMC2410.dll" (ByVal cardno As Int16)

    Declare Sub d2410_reset_clear_flag Lib "DMC2410.dll" (ByVal cardno As Int16)

    '//---------------------   DMC2410新加功能 ----------------------//
    Declare Sub d2410_config_EZ_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal ez_logic As Int16, ByVal ez_mode As Int16)

    Declare Sub d2410_config_latch_mode Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal all_enable As Int16)

    Declare Sub d2410_triger_chunnel Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal num As Int16)

    Declare Sub d2410_set_speaker_logic Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal logic As Int16)

    Declare Sub d2410_config_EMG_PIN Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal enable As Int16, ByVal emg_logic As Int16)

    Declare Sub d2410_config_LTC_filter Lib "DMC2410.dll" (ByVal cardno As Int16, ByVal width As Int16, ByVal enable As Int16)
    Declare Sub d2410_config_encoder_filter Lib "DMC2410.dll" (ByVal axis As Int16, ByVal width As Int16, ByVal enable As Int16)

    '增加位置比较输出功能
    Declare Function d2410_read_CMP_PIN Lib "DMC2410.dll" (ByVal axis As Int16) As Int32
    Declare Sub d2410_write_CMP_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal on_off As Int16)

    Declare Sub d2410_config_CMP_PIN Lib "DMC2410.dll" (ByVal axis As Int16, ByVal cmp1_enable As Int16, ByVal cmp2_enable As Int16, ByVal CMP_logic As Int16)

    '软件限位控制函数
    Declare Sub d2410_config_comparator Lib "DMC2410.dll" (ByVal axis As Int16, ByVal cmp1_condition As Int16, ByVal cmp2_condition As Int16, ByVal source_sel As Int16, ByVal SL_action As Int16)

    Declare Sub d2410_set_comparator_data Lib "DMC2410.dll" (ByVal axis As Int16, ByVal cmp1_data As Int32, ByVal cmp2_data As Int32)


    '不同脉冲当量的圆弧插补
    Declare Function d2410_get_equiv Lib "DMC2410.dll" (ByVal axis As Int16, ByRef equiv As Double) As Int32
    Declare Function d2410_set_equiv Lib "DMC2410.dll" (ByVal axis As Int16, ByVal new_equiv As Double) As Int32

    Declare Sub d2410_arc_move_unitmm Lib "DMC2410.dll" (ByRef axis As Int16, ByRef target_pos As Double, ByRef cen_pos As Double, ByVal arc_dir As Int16)
    Declare Sub d2410_rel_arc_move_unitmm Lib "DMC2410.dll" (ByRef axis As Int16, ByRef rel_pos As Double, ByRef rel_cen As Double, ByVal arc_dir As Int16)


    '//增加同时起停操作
    Declare Function d2410_set_t_move_all Lib "DMC2410.dll" (ByVal TotalAxes As Int16, ByRef pAxis As Int16, ByRef pDist As Int32, ByVal posi_mode As Int16) As Int32
    Declare Function d2410_start_move_all Lib "DMC2410.dll" (ByVal FirstAxis As Int16) As Int32

    Declare Function d2410_set_sync_option Lib "DMC2410.dll" (ByVal axis As Int16, ByVal sync_stop_on As Int16, ByVal cstop_output_on As Int16, ByVal sync_option1 As Int16, ByVal sync_option2 As Int16) As Int32
    Declare Function d2410_set_sync_stop_mode Lib "DMC2410.dll" (ByVal axis As Int16, ByVal stop_mode As Int16) As Int32
    Declare Sub d2410_board_rest Lib "DMC2410.dll" ()


    Declare Function d2410_pulse_loop Lib "DMC2410.dll" (ByVal axis As Int16) As Int16

#End Region


    '#Region "DMC2410B"

    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    '''                                 DMC2410B V1.0 函数列表                           ''''
    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    '''                 初始化函数                      '''
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Declare Function d2410_board_init Lib "DMC2410B.dll" () As Short
    '    Declare Sub d2410_board_close Lib "DMC2410B.dll" ()

    '    脉冲输入输出配置
    '    Declare Sub d2410_set_pulse_outmode Lib "DMC2410B.dll" (ByVal axis As Short, ByVal outmode As Short)
    '    Declare Sub d2410_counter_config Lib "DMC2410B.dll" (ByVal axis As Short, ByVal mode As Short)

    '    速度设置
    '    Declare Sub d2410_set_profile Lib "DMC2410B.dll" (ByVal axis As Short, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
    '    Declare Sub d2410_set_s_profile Lib "DMC2410B.dll" (ByVal axis As Short, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Sacc As Integer, ByVal Sdec As Integer)
    '    Declare Sub d2410_set_st_profile Lib "DMC2410B.dll" (ByVal axis As Short, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Tsacc As Double, ByVal Tsdec As Double)
    '    Declare Sub d2410_set_vector_profile Lib "DMC2410B.dll" (ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
    '    Declare Sub d2410_change_speed Lib "DMC2410B.dll" (ByVal axis As Short, ByVal Curr_Vel As Double)
    '    Declare Function d2410_read_current_speed Lib "DMC2410B.dll" (ByVal axis As Short) As Double
    '    Declare Sub d2410_variety_speed_range Lib "DMC2410B.dll" (ByVal axis As Short, ByVal chg_enable As Short, ByVal Max_Vel As Double)

    '    制动函数
    '    Declare Sub d2410_decel_stop Lib "DMC2410B.dll" (ByVal axis As Short, ByVal Tdec As Double)
    '    Declare Sub d2410_imd_stop Lib "DMC2410B.dll" (ByVal axis As Short)
    '    Declare Sub d2410_emg_stop Lib "DMC2410B.dll" ()

    '    单轴位置控制函数
    '    UPGRADE_NOTE: dir was upgraded to dir_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    '    Declare Sub d2410_t_vmove Lib "DMC2410B.dll" (ByVal axis As Short, ByVal dir_Renamed As Short)
    '    UPGRADE_NOTE: dir was upgraded to dir_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    '    Declare Sub d2410_s_vmove Lib "DMC2410B.dll" (ByVal axis As Short, ByVal dir_Renamed As Short)

    '    Declare Sub d2410_t_pmove Lib "DMC2410B.dll" (ByVal axis As Short, ByVal Dist As Integer, ByVal posi_mode As Short)
    '    Declare Sub d2410_s_pmove Lib "DMC2410B.dll" (ByVal axis As Short, ByVal Dist As Integer, ByVal posi_mode As Short)
    '    Declare Sub d2410_ex_t_pmove Lib "DMC2410B.dll" (ByVal axis As Short, ByVal Dist As Integer, ByVal posi_mode As Short)
    '    Declare Sub d2410_ex_s_pmove Lib "DMC2410B.dll" (ByVal axis As Short, ByVal Dist As Integer, ByVal posi_mode As Short)

    '    线性插补
    '    Declare Sub d2410_t_line2 Lib "DMC2410B.dll" (ByVal AXIS1 As Short, ByVal Dist1 As Integer, ByVal AXIS2 As Short, ByVal Dist2 As Integer, ByVal posi_mode As Short)
    '    Declare Sub d2410_t_line3 Lib "DMC2410B.dll" (ByRef axis As Short, ByVal Dist1 As Integer, ByVal Dist2 As Integer, ByVal Dist3 As Integer, ByVal posi_mode As Short)
    '    Declare Sub d2410_t_line4 Lib "DMC2410B.dll" (ByVal cardno As Short, ByVal Dist1 As Integer, ByVal Dist2 As Integer, ByVal Dist3 As Integer, ByVal Dist4 As Integer, ByVal posi_mode As Short)


    '    圆弧插补
    '    Declare Sub d2410_arc_move Lib "DMC2410B.dll" (ByRef axis As Short, ByRef target_pos As Integer, ByRef cen_pos As Integer, ByVal arc_dir As Short)
    '    Declare Sub d2410_rel_arc_move Lib "DMC2410B.dll" (ByRef axis As Short, ByRef target_pos As Integer, ByRef cen_pos As Integer, ByVal arc_dir As Short)

    '    找原点
    '    Declare Sub d2410_config_home_mode Lib "DMC2410B.dll" (ByVal axis As Short, ByVal mode As Short, ByVal EZ_count As Short)
    '    Declare Sub d2410_home_move Lib "DMC2410B.dll" (ByVal axis As Short, ByVal home_mode As Short, ByVal vel_mode As Short)

    '    手轮运动
    '    Declare Sub d2410_set_handwheel_inmode Lib "DMC2410B.dll" (ByVal axis As Short, ByVal inmode As Short, ByVal count_dir As Short)
    '    Declare Sub d2410_handwheel_move Lib "DMC2410B.dll" (ByVal axis As Short, ByVal vh As Double)


    '    状态检测函数
    '    Declare Function d2410_check_done Lib "DMC2410B.dll" (ByVal axis As Short) As Short
    '    Declare Function d2410_prebuff_status Lib "DMC2410B.dll" (ByVal axis As Short) As Short
    '    Declare Function d2410_axis_io_status Lib "DMC2410B.dll" (ByVal axis As Short) As Short
    '    Declare Function d2410_axis_status Lib "DMC2410B.dll" (ByVal axis As Short) As Short
    '    Declare Function d2410_get_rsts Lib "DMC2410B.dll" (ByVal axis As Short) As Integer

    '    专用信号设置函数
    '    Declare Sub d2410_config_SD_PIN Lib "DMC2410B.dll" (ByVal axis As Short, ByVal enable As Short, ByVal sd_logic As Short, ByVal sd_mode As Short)
    '    Declare Sub d2410_config_PCS_PIN Lib "DMC2410B.dll" (ByVal axis As Short, ByVal enable As Short, ByVal pcs_logic As Short)
    '    Declare Sub d2410_config_INP_PIN Lib "DMC2410B.dll" (ByVal axis As Short, ByVal enable As Short, ByVal inp_logic As Short)
    '    Declare Sub d2410_config_ERC_PIN Lib "DMC2410B.dll" (ByVal axis As Short, ByVal enable As Short, ByVal erc_logic As Short, ByVal erc_width As Short, ByVal erc_off_time As Short)
    '    Declare Sub d2410_config_ALM_PIN Lib "DMC2410B.dll" (ByVal axis As Short, ByVal alm_logic As Short, ByVal alm_action As Short)
    '    Declare Sub d2410_config_EL_MODE Lib "DMC2410B.dll" (ByVal axis As Short, ByVal el_mode As Short)
    '    UPGRADE_NOTE: filter was upgraded to filter_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    '    Declare Sub d2410_set_HOME_pin_logic Lib "DMC2410B.dll" (ByVal axis As Short, ByVal org_logic As Short, ByVal filter_Renamed As Short)

    '    Declare Function d2410_read_SEVON_PIN Lib "DMC2410B.dll" (ByVal axis As Short) As Integer
    '    Declare Sub d2410_write_SEVON_PIN Lib "DMC2410B.dll" (ByVal axis As Short, ByVal on_off As Short)
    '    Declare Function d2410_read_RDY_PIN Lib "DMC2410B.dll" (ByVal axis As Short) As Integer
    '    Declare Sub d2410_write_ERC_PIN Lib "DMC2410B.dll" (ByVal axis As Short, ByVal sel As Short)
    '    Declare Sub d2410_config_EMG_PIN Lib "DMC2410B.dll" (ByVal cardno As Short, ByVal enable As Short, ByVal emg_logic As Short)

    '    位置设置和读取函数
    '    Declare Function d2410_get_position Lib "DMC2410B.dll" (ByVal axis As Short) As Integer
    '    Declare Sub d2410_set_position Lib "DMC2410B.dll" (ByVal axis As Short, ByVal current_position As Integer)
    '    Declare Sub d2410_reset_target_position Lib "DMC2410B.dll" (ByVal axis As Short, ByVal Dist As Integer)


    '    增加位置比较输出功能
    '    Declare Function d2410_compare_config Lib "DMC2410B.dll" (ByVal card As Short, ByVal enable As Short, ByVal axis As Short, ByVal cmp_source As Short) As Integer
    '    Declare Function d2410_compare_get_config Lib "DMC2410B.dll" (ByVal card As Short, ByVal enable As Short, ByVal axis As Short, ByVal cmp_source As Short) As Integer
    '    Declare Function d2410_compare_clear_points Lib "DMC2410B.dll" (ByVal card As Short) As Integer
    '    UPGRADE_NOTE: dir was upgraded to dir_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    '    Declare Function d2410_compare_add_point Lib "DMC2410B.dll" (ByVal card As Short, ByVal pos As Integer, ByVal dir_Renamed As Short, ByVal action As Short, ByVal actpara As Integer) As Integer
    '    Declare Function d2410_compare_get_current_point Lib "DMC2410B.dll" (ByVal card As Short) As Integer
    '    Declare Function d2410_compare_get_points_runned Lib "DMC2410B.dll" (ByVal card As Short) As Integer
    '    Declare Function d2410_compare_get_points_remained Lib "DMC2410B.dll" (ByVal card As Short) As Integer


    '    ' 连续插补函数
    '    Declare Function d2410_conti_lines Lib "DMC2410B.dll" (ByVal axisNum As Short, ByRef piaxisList As Short, ByRef pPosList As Integer, ByVal posi_mode As Short) As Integer
    '    Declare Function d2410_conti_arc Lib "DMC2410B.dll" (ByRef piaxisList As Short, ByRef pPosList As Integer, ByRef cen_pos As Integer, ByVal arc_dir As Short, ByVal posi_mode As Short) As Integer
    '    Declare Function d2410_conti_restrain_speed Lib "DMC2410B.dll" (ByVal card As Short, ByVal v As Double) As Integer
    '    Declare Function d2410_conti_get_current_speed_ratio Lib "DMC2410B.dll" (ByVal card As Short) As Integer

    '    UPGRADE_NOTE: filter was upgraded to filter_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    '    Declare Function d2410_conti_set_mode Lib "DMC2410B.dll" (ByVal card As Short, ByVal conti_mode As Short, ByVal conti_vl As Double, ByVal conti_para As Double, ByVal filter_Renamed As Double) As Integer
    '    UPGRADE_NOTE: filter was upgraded to filter_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    '    Declare Function d2410_conti_get_mode Lib "DMC2410B.dll" (ByVal card As Short, ByRef conti_mode As Short, ByRef conti_vl As Double, ByRef conti_para As Double, ByRef filter_Renamed As Double) As Integer

    '    Declare Function d2410_conti_open_list Lib "DMC2410B.dll" (ByVal axisNum As Short, ByRef piaxisList As Short) As Integer
    '    Declare Function d2410_conti_close_list Lib "DMC2410B.dll" (ByVal card As Short) As Integer
    '    Declare Function d2410_conti_check_remain_space Lib "DMC2410B.dll" (ByVal card As Short) As Integer

    '    Declare Function d2410_conti_decel_stop_list Lib "DMC2410B.dll" (ByVal card As Short) As Integer
    '    Declare Function d2410_conti_sudden_stop_list Lib "DMC2410B.dll" (ByVal card As Short) As Integer
    '    Declare Function d2410_conti_pause_list Lib "DMC2410B.dll" (ByVal card As Short) As Integer
    '    Declare Function d2410_conti_start_list Lib "DMC2410B.dll" (ByVal card As Short) As Integer


    '    通用输入/输出控制函数
    '    Declare Function d2410_read_inbit Lib "DMC2410B.dll" (ByVal cardno As Short, ByVal BitNo As Short) As Integer
    '    Declare Sub d2410_write_outbit Lib "DMC2410B.dll" (ByVal cardno As Short, ByVal BitNo As Short, ByVal on_off As Short)
    '    Declare Function d2410_read_outbit Lib "DMC2410B.dll" (ByVal cardno As Short, ByVal BitNo As Short) As Integer
    '    Declare Function d2410_read_inport Lib "DMC2410B.dll" (ByVal card As Short) As Integer
    '    Declare Function d2410_read_outport Lib "DMC2410B.dll" (ByVal card As Short) As Integer
    '    Declare Sub d2410_write_outport Lib "DMC2410B.dll" (ByVal cardno As Short, ByVal Port_Value As Integer)


    '    //---------------------   编码器计数功能PLD  ----------------------//
    '    Declare Function d2410_get_encoder Lib "DMC2410B.dll" (ByVal axis As Short) As Integer
    '    Declare Sub d2410_set_encoder Lib "DMC2410B.dll" (ByVal axis As Short, ByVal encoder_value As Integer)

    '    Declare Sub d2410_config_LTC_PIN Lib "DMC2410B.dll" (ByVal axis As Short, ByVal ltc_logic As Short, ByVal ltc_mode As Short)

    '    Declare Function d2410_get_latch_value Lib "DMC2410B.dll" (ByVal axis As Short) As Integer

    '    Declare Function d2410_get_latch_flag Lib "DMC2410B.dll" (ByVal cardno As Short) As Integer
    '    Declare Sub d2410_reset_latch_flag Lib "DMC2410B.dll" (ByVal cardno As Short)

    '    Declare Function d2410_get_counter_flag Lib "DMC2410B.dll" (ByVal cardno As Short) As Integer
    '    Declare Sub d2410_reset_counter_flag Lib "DMC2410B.dll" (ByVal cardno As Short)

    '    Declare Sub d2410_reset_clear_flag Lib "DMC2410B.dll" (ByVal cardno As Short)

    '    //---------------------   DMC2410B编码器计数新加功能 ----------------------//
    '    Declare Sub d2410_config_EZ_PIN Lib "DMC2410B.dll" (ByVal axis As Short, ByVal ez_logic As Short, ByVal ez_mode As Short)

    '    Declare Sub d2410_config_latch_mode Lib "DMC2410B.dll" (ByVal cardno As Short, ByVal all_enable As Short)

    '    Declare Sub d2410_triger_chunnel Lib "DMC2410B.dll" (ByVal cardno As Short, ByVal num As Short)

    '    Declare Sub d2410_set_speaker_logic Lib "DMC2410B.dll" (ByVal cardno As Short, ByVal logic As Short)


    '    Declare Sub d2410_config_LTC_filter Lib "DMC2410B.dll" (ByVal cardno As Short, ByVal width As Short, ByVal enable As Short)
    '    Declare Sub d2410_config_encoder_filter Lib "DMC2410B.dll" (ByVal axis As Short, ByVal width As Short, ByVal enable As Short)

    '    //脉冲当量设置
    '    Declare Function d2410_get_equiv Lib "DMC2410B.dll" (ByVal axis As Short, ByRef equiv As Double) As Integer
    '    Declare Function d2410_set_equiv Lib "DMC2410B.dll" (ByVal axis As Short, ByVal new_equiv As Double) As Integer

    '    Declare Function d2410_get_position_unitmm Lib "DMC2410B.dll" (ByVal axis As Short, ByRef pos_by_mm As Double) As Integer
    '    Declare Function d2410_set_position_unitmm Lib "DMC2410B.dll" (ByVal axis As Short, ByVal pos_by_mm As Double) As Integer
    '    Declare Function d2410_read_current_speed_unitmm Lib "DMC2410B.dll" (ByVal axis As Short, ByRef current_speed As Double) As Integer

    '    Declare Function d2410_get_encoder_unitmm Lib "DMC2410B.dll" (ByVal axis As Short, ByRef encoder_pos_by_mm As Double) As Integer
    '    Declare Function d2410_set_encoder_unitmm Lib "DMC2410B.dll" (ByVal axis As Short, ByVal encoder_pos_by_mm As Double) As Integer

    '    Declare Sub d2410_arc_move_unitmm Lib "DMC2410B.dll" (ByRef axis As Short, ByRef target_pos As Double, ByRef cen_pos As Double, ByVal arc_dir As Short)
    '    Declare Sub d2410_rel_arc_move_unitmm Lib "DMC2410B.dll" (ByRef axis As Short, ByRef rel_pos As Double, ByRef rel_cen As Double, ByVal arc_dir As Short)

    '    Declare Function d2410_pulse_loop Lib "DMC2410B.dll" (ByVal axis As Short) As Integer


    '    多卡运行
    '    Declare Function d2410_set_t_move_all Lib "DMC2410B.dll" (ByVal TotalAxes As Short, ByRef pAxis As Short, ByRef pDist As Integer, ByVal posi_mode As Short) As Integer
    '    Declare Function d2410_start_move_all Lib "DMC2410B.dll" (ByVal FirstAxis As Short) As Integer
    '    Declare Sub d2410_simultaneous_stop Lib "DMC2410B.dll" (ByVal axis As Short)
    '    Declare Function d2410_set_sync_option Lib "DMC2410B.dll" (ByVal axis As Short, ByVal sync_stop_on As Short, ByVal cstop_output_on As Short, ByVal sync_option1 As Short, ByVal sync_option2 As Short) As Integer
    '    Declare Function d2410_set_sync_stop_mode Lib "DMC2410B.dll" (ByVal axis As Short, ByVal stop_mode As Short) As Integer
    '    Declare Function d2410_config_CSTA_PIN Lib "DMC2410B.dll" (ByVal axis As Short, ByVal edge_mode As Short) As Integer





    '    '函数参数必须严格保持一致性

    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    '''                                 DMC2410B V1.0 end of module                       '''
    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '#End Region


End Module
