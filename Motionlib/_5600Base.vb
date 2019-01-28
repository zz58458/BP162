'********************************************************************  
'* Filename:    #### Class（VB）
'* Copyright:   LeDSDsun Copyright (c)2014
'* Company:     R&D Team  
'* Author：     ###
'* System Enviroment:    Visual Studio 2008 & 2010 
'* Create for:   #####
'********************************************************************

Public Class _5600Base
    Inherits BaseFunction
    Private mMust As New Threading.Mutex(False)

#Region "declareDMC5000"

    '板卡配置
    ''' <summary>
    ''' 控制卡初始化函数
    ''' </summary>
    ''' <returns>大于0：卡数，小于0：绝对值减1表示拨码重号，等于0：没找到控制卡硬件或初始化失败</returns>
    ''' <remarks></remarks>
    Declare Function dmc_board_init Lib "LTDMC.dll" () As Int16
    ''' <summary>
    ''' 控制卡关闭函数 资源释放
    ''' </summary>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_board_close Lib "LTDMC.dll" () As Int16
    ''' <summary>
    ''' 控制卡硬件复位
    ''' </summary>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_board_reset Lib "LTDMC.dll" () As Int16
    ''' <summary>
    ''' 读取初始化后控制卡信息
    ''' </summary>
    ''' <param name="CardNum">初始化成功的卡数</param>
    ''' <param name="CardTypeList">卡类型列表：卡类型采用16进制表示，如0x5410,0x5800</param>
    ''' <param name="CardIdList">卡ID列表</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_CardInfList Lib "LTDMC.dll" (ByRef CardNum As UInt16, ByRef CardTypeList As UInt32, ByRef CardIdList As UInt16) As Int16
    ''' <summary>
    ''' 读取控制卡版本信息
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="CardVersion">控制卡硬件版本号</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_card_version Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef CardVersion As UInt32) As Int16
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CardNo"></param>
    ''' <param name="FirmID">控制卡固件类型</param>
    ''' <param name="SubFirmID">控制卡固件版本号</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_card_soft_version Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef FirmID As UInt32, ByRef SubFirmID As UInt32) As Int16
    ''' <summary>
    ''' 读取动态库版本号 用日期表示
    ''' </summary>
    ''' <param name="LibVer">版本号</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_card_lib_version Lib "LTDMC.dll" (ByRef LibVer As Int32) As Int16
    ''' <summary>
    ''' 设置函数库函数调用参数打印输出模式
    ''' </summary>
    ''' <param name="mode">打印输出模式：0-不输出，1-输出</param>
    ''' <param name="FileName">文件名：相对或绝对地址文件</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_debug_mode Lib "LTDMC.dll" (ByVal mode As UInt16, ByRef FileName As String) As Int16
    ''' <summary>
    ''' 读取函数库函数调用参数打印输出模式
    ''' </summary>
    ''' <param name="mode">打印输出模式：0-不输出，1-输出</param>
    ''' <param name="FileName">文件名：相对或绝对地址文件</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_debug_mode Lib "LTDMC.dll" (ByVal mode As UInt16, ByRef FileName As String) As Int16
    '密码管理
    ''' <summary>
    ''' 密码校验 失败3次之后 无法再次校验
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="check_sn">旧密码</param>
    ''' <returns>校验状态：0-失败，1-成功</returns>
    ''' <remarks></remarks>
    Declare Function dmc_check_sn Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef check_sn As String) As Int16
    ''' <summary>
    ''' 密码修改
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="new_sn">新密码</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_write_sn Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef new_sn As String) As Int16
    '下载参数文件
    ''' <summary>
    ''' 下载参数文件
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="FileName">文件名：相对或绝对地址文件</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_download_configfile Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef FileName As String) As Int16
    '下载固件文件
    ''' <summary>
    ''' 下载固件文件
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="FileName">文件名：相对或绝对地址文件</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_download_firmware Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef FileName As String) As Int16
    ''' <summary>
    ''' 读取控制卡轴数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="TotalAxis">轴数</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_total_axes Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef TotalAxis As UInt32) As Int16

    '3800 5800专用 轴IO映射配置
    ''' <summary>
    ''' 设置轴IO映射
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="IoType">轴IO信号类型</param>
    ''' <param name="MapIoType">轴IO映射IO口类型</param>
    ''' <param name="MapIoIndex">轴IO映射IO口号</param>
    ''' <param name="Filter">滤波时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_axis_io_map Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal IoType As UInt16, ByVal MapIoType As UInt16, ByVal MapIoIndex As UInt16, ByVal Filter As Double) As Int16
    ''' <summary>
    ''' 读取轴IO映射
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="IoType">轴IO信号类型</param>
    ''' <param name="MapIoType">轴IO映射IO口类型</param>
    ''' <param name="MapIoIndex">轴IO映射IO口号</param>
    ''' <param name="Filter">滤波时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_axis_io_map Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal IoType As UInt16, ByRef MapIoType As UInt16, ByRef MapIoIndex As UInt16, ByRef Filter As Double) As Int16
    ''' <summary>
    ''' 设置所有专用IO滤波时间
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="filter_time">滤波时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_special_input_filter Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal filter_time As Double) As Int16

    'DMC3800专用 虚拟IO映射  用于读取滤波后的IO口电平状态
    ''' <summary>
    ''' 设置虚拟IO映射
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="bitno">虚拟IO口号：0-15</param>
    ''' <param name="MapIoType">轴IO映射IO口类型</param>
    ''' <param name="MapIoIndex">轴IO映射IO口号</param>
    ''' <param name="Filter">滤波时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_io_map_virtual Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal bitno As UInt16, ByVal MapIoType As UInt16, ByVal MapIoIndex As UInt16, ByVal Filter As Double) As Int16
    ''' <summary>
    ''' 读取虚拟IO映射
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="bitno">虚拟IO口号：0-15</param>
    ''' <param name="MapIoType">轴IO映射IO口类型</param>
    ''' <param name="MapIoIndex">轴IO映射IO口号</param>
    ''' <param name="Filter">滤波时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_io_map_virtual Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal bitno As UInt16, ByRef MapIoType As UInt16, ByRef MapIoIndex As UInt16, ByRef Filter As Double) As Int16
    ''' <summary>
    ''' 读取滤波后的IO输入状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="bitno">虚拟IO口号：0-15</param>
    ''' <returns>输入状态：0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_inbit_virtual Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal bitno As UInt16) As Int16

    '限位/异常设置
    ''' <summary>
    ''' 设置软限位参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7></param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="source_sel">位置源：0-指令位置，1-编码器位置</param>
    ''' <param name="SL_action">制动方式：0-减速停止，1-立即停止</param>
    ''' <param name="N_limit">负限位值</param>
    ''' <param name="P_limit">正限位值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_softlimit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal enable As UInt16, ByVal source_sel As UInt16, ByVal SL_action As UInt16, ByVal N_limit As Int32, ByVal P_limit As Int32) As Int16  '设置软限位参数
    ''' <summary>
    ''' 读取软限位参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7></param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="source_sel">位置源：0-指令位置，1-编码器位置</param>
    ''' <param name="SL_action">制动方式：0-减速停止，1-立即停止</param>
    ''' <param name="N_limit">负限位值</param>
    ''' <param name="P_limit">正限位值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_softlimit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef enable As UInt16, ByRef source_sel As UInt16, ByRef SL_action As UInt16, ByRef N_limit As Int32, ByRef P_limit As Int32) As Int16    '读取软限位参数
    ''' <summary>
    ''' 设置硬件限位模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="el_enable">使能：0-禁止，1-允许</param>
    ''' <param name="el_logic">有效电平：0-低电平，1-高电平</param>
    ''' <param name="el_mode">制动方式：0-减速停止，1-立即停止</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_el_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal el_enable As UInt16, ByVal el_logic As UInt16, ByVal el_mode As UInt16) As Int16      '设置EL信号
    ''' <summary>
    ''' 读取硬件限位模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="el_enable">使能：0-禁止，1-允许</param>
    ''' <param name="el_logic">有效电平：0-低电平，1-高电平</param>
    ''' <param name="el_mode">制动方式：0-减速停止，1-立即停止</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_el_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef el_enable As UInt16, ByRef el_logic As UInt16, ByRef el_mode As UInt16) As Int16   '读取设置EL信号
    ''' <summary>
    ''' 设置硬件急停模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="emg_logic">有效电平：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_emg_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal enable As UInt16, ByVal emg_logic As UInt16) As Int16    '设置EMG信号
    ''' <summary>
    ''' 读取硬件急停模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="emg_logic">有效电平：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_emg_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef enable As UInt16, ByRef emg_logic As UInt16) As Int16        '读取设置EMG信号
    '3800 5800专用 外部减速停止信号及减速停止时间配置
    ''' <summary>
    ''' 设置外部IO减速停止模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="logic">有效电平：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_io_dstp_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal enable As UInt16, ByVal logic As UInt16) As Int16
    ''' <summary>
    ''' 读取外部IO减速停止模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="logic">有效电平：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_io_dstp_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef enable As UInt16, ByRef logic As UInt16) As Int16
    ''' <summary>
    ''' 设置减速停止时间，针对所有减速停止有效
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="stop_time">停止时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_dec_stop_time Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef stop_time As Double) As Int16
    ''' <summary>
    ''' 读取减速停止时间，针对所有减速停止有效
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="stop_time">停止时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_dec_stop_time Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef stop_time As Double) As Int16

    '速度设置
    ''' <summary>
    ''' 设置单轴速度参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Min_Vel">起始速度</param>
    ''' <param name="Max_Vel">运行速度</param>
    ''' <param name="Tacc">加速时间，单位s</param>
    ''' <param name="Tdec">减速时间，单位s</param>
    ''' <param name="Stop_vel">停止速度</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_profile Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Stop_vel As Double) As Int16 '设定速度曲线参数
    ''' <summary>
    ''' 读取单轴速度参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Min_Vel">起始速度</param>
    ''' <param name="Max_Vel">运行速度</param>
    ''' <param name="Tacc">加速时间，单位s</param>
    ''' <param name="Tdec">减速时间，单位s</param>
    ''' <param name="Stop_vel">停止速度</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_profile Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef Min_Vel As Double, ByRef Max_Vel As Double, ByRef Tacc As Double, ByRef Tdec As Double, ByRef Stop_vel As Double) As Int16 '读取速度曲线参数
    ''' <summary>
    ''' 设置S速度曲线参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="s_mode">s段参数模式：0</param>
    ''' <param name="s_para">s段时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_s_profile Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal s_mode As UInt16, ByVal s_para As Double) As Int16        '设置平滑速度曲线参数
    ''' <summary>
    ''' 设置S速度曲线参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="s_mode">s段参数模式：0</param>
    ''' <param name="s_para">s段时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_s_profile Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal s_mode As UInt16, ByRef s_para As Double) As Int16    '读取平滑速度曲线参数
    ''' <summary>
    ''' 设置单段插补速度参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="Min_Vel">起始速度</param>
    ''' <param name="Max_Vel">运行速度</param>
    ''' <param name="Tacc">加速时间，单位s</param>
    ''' <param name="Tdec">减速时间，单位s</param>
    ''' <param name="Stop_vel">停止速度</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_vector_profile_multicoor Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Stop_vel As Double) As Int16
    ''' <summary>
    ''' 读取单段插补速度参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="Min_Vel">起始速度</param>
    ''' <param name="Max_Vel">运行速度</param>
    ''' <param name="Tacc">加速时间，单位s</param>
    ''' <param name="Tdec">减速时间，单位s</param>
    ''' <param name="Stop_vel">停止速度</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_vector_profile_multicoor Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByRef Min_Vel As Double, ByRef Max_Vel As Double, ByRef Tacc As Double, ByRef Tdec As Double, ByRef Stop_vel As Double) As Int16

    '运动模块脉冲模式
    ''' <summary>
    ''' 设置脉冲模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="outmode">脉冲输出模式：0-5</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_pulse_outmode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal outmode As UInt16) As Int16    '设定脉冲输出模式
    ''' <summary>
    ''' 读取脉冲模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="outmode">脉冲输出模式：0-5</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_pulse_outmode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef outmode As UInt16) As Int16      '读取脉冲输出模式

    '单轴运动
    '点位运动
    ''' <summary>
    ''' 单轴定长运动
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Dist">目标位置</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_pmove Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal Dist As Int32, ByVal posi_mode As UInt16) As Int16  '指定轴做定长位移运动
    ''' <summary>
    ''' 在线变位
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Dist">目标位置</param>
    ''' <param name="posi_mode">位置模式：0 保留</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_reset_target_position Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal Dist As Int32, ByVal posi_mode As UInt16) As Int16  '运动中改变目标位置
    ''' <summary>
    ''' 在线变速
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Curr_Vel">新速度值</param>
    ''' <param name="Taccdec">新加减速时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_change_speed Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal Curr_Vel As Double, ByVal Taccdec As Double) As Int16        '在线改变指定轴的当前运动速度
    ''' <summary>
    ''' 强制变位
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Dist">目标位置</param>
    ''' <param name="posi_mode">位置模式：0 保留</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_update_target_position Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal Dist As Int32, ByVal posi_mode As UInt16) As Int16  '强行改变目标位置
    'JOG运动
    ''' <summary>
    ''' 速度运动
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="dir">运动方向：0-负方向，1-正方向</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_vmove Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal dir As UInt16) As Int16    '指定轴做连续运动
    'PVT运动
    ''' <summary>
    ''' PVT运动数据
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Count">数据数组元素个数</param>
    ''' <param name="pTime">时间数据数组，单位s</param>
    ''' <param name="pPos">位置数据数组</param>
    ''' <param name="pVel">速度数据数组</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Declare Function dmc_PvtTable Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal Count As Int32, ByRef pTime As Double, ByRef pPos As Int32, ByRef pVel As Double) As Int16
    ''' <summary>
    ''' PTS运动数据
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Count">数据数组元素个数</param>
    ''' <param name="pTime">时间数据数组，单位s</param>
    ''' <param name="pPos">位置数据数组</param>
    ''' <param name="pPercent">加速度变化百分比数据数组</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_PtsTable Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal Count As Int32, ByRef pTime As Double, ByRef pPos As Int32, ByRef pPercent As Double) As Int16
    ''' <summary>
    ''' PVTS运动数据
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Count">数据数组元素个数</param>
    ''' <param name="pTime">时间数据数组，单位s</param>
    ''' <param name="pPos">位置数据数组</param>
    ''' <param name="velBegin">起始速度</param>
    ''' <param name="velEnd">停止速度</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_PvtsTable Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal Count As Int32, ByRef pTime As Double, ByRef pPos As Int32, ByVal velBegin As Double, ByVal velEnd As Double) As Int16
    ''' <summary>
    ''' PTT运动数据
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Count">数据数组元素个数</param>
    ''' <param name="pTime">时间数据数组，单位s</param>
    ''' <param name="pPos">位置数据数组</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_PttTable Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal Count As Int32, ByRef pTime As Double, ByRef pPos As Int32) As Int16
    ''' <summary>
    ''' PVT启动运动
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="AxisNum">轴数：1-8</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_PvtMove Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16) As Int16

    '多轴运动
    '直线插补
    ''' <summary>
    ''' 单段直线插补
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2-8</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="DistList">目标位置列表</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_line_multicoor Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef DistList As Int32, ByVal posi_mode As UInt16) As Int16     '指定轴直线插补运动
    '平面圆弧
    ''' <summary>
    ''' 2轴单段圆弧插补
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="Target_Pos">目标位置</param>
    ''' <param name="Cen_Pos">圆心位置</param>
    ''' <param name="Arc_Dir">圆弧方向：0-顺时针，1-逆时针</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_arc_move_multicoor Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByRef AxisList As UInt16, ByRef Target_Pos As Int32, ByRef Cen_Pos As Int32, ByVal Arc_Dir As UInt16, ByVal posi_mode As UInt16) As Int16

    '回零运动
    ''' <summary>
    ''' 设置原点信号
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="org_logic">有效电平：0-低电平，1-高电平</param>
    ''' <param name="Filter">滤波时间：0 保留</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_home_pin_logic Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal org_logic As UInt16, ByVal Filter As Double) As Int16         '设置HOME信号
    ''' <summary>
    ''' 读取原点信号
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="org_logic">有效电平：0-低电平，1-高电平</param>
    ''' <param name="Filter">滤波时间：0 保留</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_home_pin_logic Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef org_logic As UInt16, ByRef Filter As Double) As Int16     '读取设置HOME信号
    ''' <summary>
    ''' 设置回零模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="home_dir">回零方向：0-负方向，1-正方向</param>
    ''' <param name="vel_mode">回零速度模式：0-低速回零，1-高速回零</param>
    ''' <param name="home_mode">回零模式：0-一次回零，1-一次回零+反找，2-二次回零，3-一次回零+一次EZ回零，4-一次EZ回零</param>
    ''' <param name="EZ_count">EZ次数：1 保留</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_homemode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal home_dir As UInt16, ByVal vel_mode As Double, ByVal home_mode As UInt16, ByVal EZ_count As UInt16) As Int16 '设定指定轴的回原点模式
    ''' <summary>
    ''' 读取回零模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="home_dir">回零方向：0-负方向，1-正方向</param>
    ''' <param name="vel_mode">回零速度模式：0-低速回零，1-高速回零</param>
    ''' <param name="home_mode">回零模式：0-一次回零，1-一次回零+反找，2-二次回零，3-一次回零+一次EZ回零，4-一次EZ回零</param>
    ''' <param name="EZ_count">EZ次数：1 保留</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_homemode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef home_dir As UInt16, ByRef vel_mode As Double, ByRef home_mode As UInt16, ByRef EZ_count As UInt16) As Int16 '读取指定轴的回原点模式
    ''' <summary>
    ''' 回零运动
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_home_move Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16

    '原点锁存
    '3800 5800专用
    ''' <summary>
    ''' 设置原点锁存模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="logic">锁存触发方式：0-下降沿触发，1-上升沿触发</param>
    ''' <param name="source">锁存源：0-指令位置，1-反馈位置</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_homelatch_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal enable As UInt16, ByVal logic As UInt16, ByVal source As UInt16) As Int16
    ''' <summary>
    ''' 读取原点锁存模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="logic">锁存触发方式：0-下降沿触发，1-上升沿触发</param>
    ''' <param name="source">锁存源：0-指令位置，1-反馈位置</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_homelatch_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef enable As UInt16, ByRef logic As UInt16, ByRef source As UInt16) As Int16
    ''' <summary>
    ''' 读取原点锁存状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>锁存状态：0-未锁存，1-已锁存</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_homelatch_flag Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int32
    ''' <summary>
    ''' 清除原点锁存状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_reset_homelatch_flag Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16
    ''' <summary>
    ''' 读取原点锁存值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_homelatch_value Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int32

    '手轮运动
    '3800 5800专用 手轮通道选择
    ''' <summary>
    ''' 设置手轮通道
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="index">手轮通道：0-高速通道，1-低速通道</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_handwheel_channel Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal index As UInt16) As Int16
    ''' <summary>
    ''' 读取手轮通道
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="index">手轮通道：0-高速通道，1-低速通道</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_handwheel_channel Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef index As UInt16) As Int16
    '一个手轮信号控制单个轴运动
    ''' <summary>
    ''' 设置手轮模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="inmode">手轮模式：0-AB相，1-脉冲+方向</param>
    ''' <param name="multi">倍率：[-100,100],负值表示反向</param>
    ''' <param name="vh">保留</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_handwheel_inmode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal inmode As UInt16, ByVal multi As Int32, ByVal vh As Double) As Int16      '设置输入手轮脉冲信号的工作方式
    ''' <summary>
    ''' 读取手轮模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="inmode">手轮模式：0-AB相，1-脉冲+方向</param>
    ''' <param name="multi">倍率：[-100,100],负值表示反向</param>
    ''' <param name="vh">保留</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_handwheel_inmode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef inmode As UInt16, ByRef multi As Int32, ByRef vh As Double) As Int16    '读取输入手轮脉冲信号的工作方式
    '3800 5800专用 一个手轮信号控制多轴运动
    ''' <summary>
    ''' 设置多轴跟随手轮模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="inmode">手轮模式：0-AB相，1-脉冲+方向</param>
    ''' <param name="AxisNum">轴数：1-8</param>
    ''' <param name="AxisList">跟随手轮轴列表</param>
    ''' <param name="multi">跟随倍率列表，[-100,100],负值表示反向</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_handwheel_inmode_extern Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal inmode As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef multi As Int32) As Int16     '设置输入手轮脉冲信号的工作方式
    ''' <summary>
    ''' 读取多轴跟随手轮模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="inmode">手轮模式：0-AB相，1-脉冲+方向</param>
    ''' <param name="AxisNum">轴数：1-8</param>
    ''' <param name="AxisList">跟随手轮轴列表</param>
    ''' <param name="multi">跟随倍率列表，[-100,100],负值表示反向</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_handwheel_inmode_extern Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef inmode As UInt16, ByRef AxisNum As UInt16, ByRef AxisList As UInt16, ByRef multi As Int32) As Int16   '读取输入手轮脉冲信号的工作方式
    '启动手轮运动
    ''' <summary>
    ''' 启动手轮运动
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_handwheel_move Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16         '启动指定轴的手轮脉冲运动
    '编码器
    ''' <summary>
    ''' 设置编码器模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="mode">编码器计数模式：0-脉冲+方向，1-1倍AB相，2-1倍AB相,3-4倍AB相</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_counter_inmode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal mode As UInt16) As Int16      '设定编码器的计数方式
    ''' <summary>
    ''' 读取编码器模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="mode">编码器计数模式：0-脉冲+方向，1-1倍AB相，2-1倍AB相,3-4倍AB相</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_counter_inmode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef mode As UInt16) As Int16        '读取编码器的计数方式
    ''' <summary>
    ''' 读取编码器反馈值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>反馈值</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_encoder Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int32
    ''' <summary>
    ''' 设置编码器位置值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="encoder_value">位置值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_encoder Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal encoder_value As Int32) As Int16
    ''' <summary>
    ''' 设置EZ信号模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="ez_logic">有效电平：0-低电平，1-高电平</param>
    ''' <param name="ez_mode">保留：0</param>
    ''' <param name="Filter">保留：0</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_ez_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal ez_logic As UInt16, ByVal ez_mode As UInt16, ByVal Filter As Double) As Int16       '设置EZ信号
    ''' <summary>
    ''' 读取EZ信号模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="ez_logic">有效电平：0-低电平，1-高电平</param>
    ''' <param name="ez_mode">保留：0</param>
    ''' <param name="Filter">保留：0</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_ez_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef ez_logic As UInt16, ByRef ez_mode As UInt16, ByRef Filter As Double) As Int16     '读取设置EZ信号
    '锁存
    ''' <summary>
    ''' 设置锁存信号模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="ltc_logic">LTC 信号的触发方式，0：下降沿锁存，1：上升沿锁存</param>
    ''' <param name="ltc_mode">保留：0</param>
    ''' <param name="Filter">保留：0</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_ltc_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal ltc_logic As UInt16, ByVal ltc_mode As UInt16, ByVal Filter As Double) As Int16    '设置LTC信号
    ''' <summary>
    ''' 读取锁存信号模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="ltc_logic">LTC 信号的触发方式，0：下降沿锁存，1：上升沿锁存</param>
    ''' <param name="ltc_mode">保留：0</param>
    ''' <param name="Filter">保留：0</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_ltc_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef ltc_logic As UInt16, ByRef ltc_mode As UInt16, ByRef Filter As Double) As Int16  '读取设置LTC信号
    ''' <summary>
    ''' 设置锁存模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="all_enable">锁存模式：0-单轴单次锁存，1-所有轴同时单次锁存，2-单轴连续锁存，3-外部触发延时急停</param>
    ''' <param name="latch_source">锁存源：0-指令位置，1-反馈位置</param>
    ''' <param name="latch_channel">保留：0</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_latch_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal all_enable As UInt16, ByVal latch_source As UInt16, ByVal latch_channel As UInt16) As Int16     '设置锁存方式
    ''' <summary>
    ''' 读取锁存模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="all_enable">锁存模式：0-单轴单次锁存，1-所有轴同时单次锁存，2-单轴连续锁存，3-外部触发延时急停</param>
    ''' <param name="latch_source">锁存源：0-指令位置，1-反馈位置</param>
    ''' <param name="latch_channel">保留：0</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_latch_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef all_enable As UInt16, ByRef latch_source As UInt16, ByRef latch_channel As UInt16) As Int16
    ''' <summary>
    ''' 读取锁存值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>所存值</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_latch_value Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int32           '读取控制卡内锁存值，再连续锁存模式下读取一次控制卡内有效锁存个数将会自动减1,并将锁存值保存在PC缓冲区内
    ''' <summary>
    ''' 读取锁存次数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>锁存次数</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_latch_flag Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16             '读取控制卡内有效锁存个数
    ''' <summary>
    ''' 复位锁存次数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_reset_latch_flag Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16       '复位标志
    ''' <summary>
    ''' 按索引号读取连续锁存值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="index">索引号</param>
    ''' <returns>所存值</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_latch_value_extern Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal index As UInt16) As Int32  '按索引号读取PC缓冲区中已保存的锁存值，读的时候会将控制卡内的有效锁存值全部保存在PC缓冲区中
    ''' <summary>
    ''' 读取连续锁存次数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>锁存次数</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_latch_flag_extern Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16            '读取PC缓冲区中已保存的已锁存值个数
    'DMC3410 5800专用 LTC端口触发延时急停时间 单位us
    ''' <summary>
    ''' 设置外部触发延时急停时间
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="time">延时急停时间，单位us</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_latch_stop_time Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal time As Int32) As Int16
    ''' <summary>
    ''' 读取外部触发延时急停时间
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="time">延时急停时间，单位us</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_latch_stop_time Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef time As Int32) As Int16
    'DMC3800 5800专用 LTC反相输出
    ''' <summary>
    ''' 设置LTC锁存反相输出模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="bitno">反相输出口：0-15</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_SetLtcOutMode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal enable As UInt16, ByVal bitno As UInt16) As Int16
    ''' <summary>
    ''' 读取LTC锁存反相输出模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="bitno">反相输出口：0-15</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_GetLtcOutMode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef enable As UInt16, ByRef bitno As UInt16) As Int16

    '单轴低速位置比较
    ''' <summary>
    ''' 设置单轴低速位置比较器配置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="cmp_source">比较源：0-指令位置，1-反馈位置</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_set_config Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal enable As UInt16, ByVal cmp_source As UInt16) As Int16       '配置比较器
    ''' <summary>
    ''' 读取单轴低速位置比较器配置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="cmp_source">比较源：0-指令位置，1-反馈位置</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_get_config Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef enable As UInt16, ByRef cmp_source As UInt16) As Int16   '读取配置比较器
    ''' <summary>
    ''' 清除位置比较位置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_clear_points Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16          '清除所有比较点
    ''' <summary>
    ''' 添加比较位置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="pos">比较位置</param>
    ''' <param name="dir">比较方向：0：小于等于，1：大于等于0   比较位置与当前位置比较</param>
    ''' <param name="action">触发动作功能</param>
    ''' <param name="actpara">触发动作参数</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_add_point Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal pos As Int32, ByVal dir As UInt16, ByVal action As UInt16, ByVal actpara As Int32) As Int16    '添加比较点
    ''' <summary>
    ''' 读取当前比较位置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="pos">比较位置</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_get_current_point Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef pos As Int32) As Int16    '读取当前比较点
    ''' <summary>
    ''' 读取已比较点数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="pointNum">已比较点数</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_get_points_runned Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef pointNum As Int32) As Int16       '查询已经比较过的点
    ''' <summary>
    ''' 读取剩余比较空间
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="pointNum">剩余比较空间</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_get_points_remained Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef pointNum As Int32) As Int16     '查询可以加入的比较点数量
    '二维低速位置比较
    ''' <summary>
    ''' 设置二维比较器配置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="cmp_source">比较源：0-指令位置，1-反馈位置</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_set_config_extern Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal enable As UInt16, ByVal cmp_source As UInt16) As Int16           '配置比较器
    ''' <summary>
    ''' 读取二维比较器配置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="cmp_source">比较源：0-指令位置，1-反馈位置</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_get_config_extern Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef enable As UInt16, ByRef cmp_source As UInt16) As Int16           '读取配置比较器
    ''' <summary>
    ''' 清除二维比较位置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_clear_points_extern Lib "LTDMC.dll" (ByVal CardNo As UInt16) As Int16          '清除所有比较点
    ''' <summary>
    ''' 添加二维比较位置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="pos">比较位置（xpos,ypos)</param>
    ''' <param name="dir">比较方向（x_dir,y_dir)</param>
    ''' <param name="action">触发动作功能</param>
    ''' <param name="actpara">触发动作参数</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_add_point_extern Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef axis As UInt16, ByRef pos As Int32, ByRef dir As UInt16, ByVal action As UInt16, ByVal actpara As Int32) As Int16          '添加两轴位置比较点
    ''' <summary>
    ''' 读取当前比较位置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="pos">比较位置（xpos,ypos)</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_get_current_point_extern Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef pos As Int32) As Int16    '读取当前比较点
    ''' <summary>
    ''' 读取已比较点数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="pointNum">已比较点数</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_get_points_runned_extern Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef pointNum As Int32) As Int16       '查询已经比较过的点
    ''' <summary>
    ''' 读取剩余比较空间
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="pointNum">剩余比较空间</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_compare_get_points_remained_extern Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef pointNum As Int32) As Int16      '查询可以加入的二维比较点数量

    '单轴高速位置比较函数
    ''' <summary>
    ''' 设置高速比较模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="hcmp">高速比较器号：0-3</param>
    ''' <param name="cmp_mode">比较模式：0-禁止，1-等于，2-小于，3-大于，4-队列，5-线性</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_hcmp_set_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal hcmp As UInt16, ByVal cmp_mode As UInt16) As Int16
    ''' <summary>
    ''' 读取高速比较模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="hcmp">高速比较器号：0-3</param>
    ''' <param name="cmp_mode">比较模式：0-禁止，1-等于，2-小于，3-大于，4-队列，5-线性</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_hcmp_get_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal hcmp As UInt16, ByRef cmp_mode As UInt16) As Int16
    ''' <summary>
    ''' 设置高速比较参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="hcmp">高速比较器号：0-3</param>
    ''' <param name="axis">比较轴号：0-7</param>
    ''' <param name="cmp_source">比较源：0-指令位置，1-反馈位置</param>
    ''' <param name="cmp_logic">比较输出状态：0-低电平，1-高电平</param>
    ''' <param name="time">脉冲时间，单位us,最小1us</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_hcmp_set_config Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal hcmp As UInt16, ByVal axis As UInt16, ByVal cmp_source As UInt16, ByVal cmp_logic As UInt16, ByVal time As Int32) As Int16
    ''' <summary>
    ''' 读取高速比较参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="hcmp">高速比较器号：0-3</param>
    ''' <param name="axis">比较轴号：0-7</param>
    ''' <param name="cmp_source">比较源：0-指令位置，1-反馈位置</param>
    ''' <param name="cmp_logic">比较输出状态：0-低电平，1-高电平</param>
    ''' <param name="time">脉冲时间，单位us,最小1us</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_hcmp_get_config Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal hcmp As UInt16, ByRef axis As UInt16, ByRef cmp_source As UInt16, ByRef cmp_logic As UInt16, ByRef time As Int32) As Int16
    ''' <summary>
    ''' 添加高速比较位置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="hcmp">高速比较器号：0-3</param>
    ''' <param name="cmp_pos">比较位置</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_hcmp_add_point Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal hcmp As UInt16, ByVal cmp_pos As Int32) As Int16
    ''' <summary>
    ''' 设置高速比较线性模式参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="hcmp">高速比较器号：0-3</param>
    ''' <param name="Increment">比较位置增量值</param>
    ''' <param name="Count">比较次数</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_hcmp_set_liner Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal hcmp As UInt16, ByVal Increment As Int32, ByVal Count As Int32) As Int16
    ''' <summary>
    ''' 读取高速比较线性模式参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="hcmp">高速比较器号：0-3</param>
    ''' <param name="Increment">比较位置增量值</param>
    ''' <param name="Count">比较次数</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_hcmp_get_liner Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal hcmp As UInt16, ByRef Increment As Int32, ByRef Count As Int32) As Int16
    ''' <summary>
    ''' 读取高速比较当前状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="hcmp">高速比较器号：0-3</param>
    ''' <param name="remained_points">剩余可用比较点数</param>
    ''' <param name="current_point">当前比较位置</param>
    ''' <param name="runned_points">已比较点数</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_hcmp_get_current_state Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal hcmp As UInt16, ByRef remained_points As Int32, ByRef current_point As Int32, ByRef runned_points As Int32) As Int16
    ''' <summary>
    ''' 清除高速比较位置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="hcmp">高速比较器号：0-3</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_hcmp_clear_points Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal hcmp As UInt16) As Int16
    ''' <summary>
    ''' 读高速比较输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="hcmp">高速比较器号：0-3</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_cmp_pin Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal hcmp As UInt16) As Int16
    ''' <summary>
    ''' 写高速比较输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="hcmp">高速比较器号：0-3</param>
    ''' <param name="on_off">输出口状态：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_write_cmp_pin Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal hcmp As UInt16, ByVal on_off As UInt16) As Int16

    '通用IO
    ''' <summary>
    ''' 按位读输入口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="bitno">IO口号：0-31</param>
    ''' <returns>输入口状态：0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_inbit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal bitno As UInt16) As Int16            '读取输入口的状态
    ''' <summary>
    ''' 按位写输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="bitno">IO口号：0-31</param>
    ''' <param name="on_off">输出状态：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_write_outbit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal bitno As UInt16, ByVal on_off As UInt16) As Int16         '设置输出口的状态
    ''' <summary>
    ''' 按位读输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="bitno">IO口号：0-31</param>
    ''' <returns>输出口状态：0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_outbit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal bitno As UInt16) As Int16           '读取输出口的状态
    ''' <summary>
    ''' 按端口读输入口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="portno">端口号：0-1</param>
    ''' <returns>输入口状态：bit0-bit31表示in0-in31,位值：0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_inport Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal portno As UInt16) As UInt32     '读取输入端口的值
    ''' <summary>
    ''' 按端口读输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="portno">端口号：0</param>
    ''' <returns>输出口状态：bit0-bit31表示out0-out31,位值：0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_outport Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal portno As UInt16) As UInt32            '读取输出端口的值
    ''' <summary>
    ''' 按端口写输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="portno">端口号：0</param>
    ''' <param name="outport_val">输出口状态：bit0-bit31表示out0-out31,位值：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_write_outport Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal portno As UInt16, ByVal outport_val As UInt32) As Int16       '设置输出端口的值
    '3800 5800专用 IO辅助功能函数
    ''' <summary>
    ''' IO翻转
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="bitno">IO口号：0-31</param>
    ''' <param name="reverse_time">翻转时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_reverse_outbit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal bitno As UInt16, ByVal reverse_time As Double) As Int16
    ''' <summary>
    ''' 设置IO计数模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="bitno">IO口号：0-31</param>
    ''' <param name="mode">IO计数模式0：禁用，1：上升沿计数，2：下降沿计数</param>
    ''' <param name="Filter">滤波时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_io_count_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal bitno As UInt16, ByVal mode As UInt16, ByVal Filter As Double) As Int16
    ''' <summary>
    ''' 读取IO计数模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="bitno">IO口号：0-31</param>
    ''' <param name="mode">IO计数模式0：禁用，1：上升沿计数，2：下降沿计数</param>
    ''' <param name="Filter">滤波时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_io_count_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal bitno As UInt16, ByRef mode As UInt16, ByRef Filter As Double) As Int16
    ''' <summary>
    ''' 设置IO计数值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="bitno">IO口号：0-31</param>
    ''' <param name="CountValue">计数值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_io_count_value Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal bitno As UInt16, ByVal CountValue As Int32) As Int16
    ''' <summary>
    ''' 读取IO计数值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="bitno">IO口号：0-31</param>
    ''' <param name="CountValue">计数值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_io_count_value Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal bitno As UInt16, ByRef CountValue As Int32) As Int16

    '伺服专用IO
    ''' <summary>
    ''' 设置INP模式  INP信号会影响到轴的运动状态（check_done)
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能状态：0-禁止，1-允许</param>
    ''' <param name="inp_logic">有效电平：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_inp_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal enable As UInt16, ByVal inp_logic As UInt16) As Int16      '设置INP信号
    ''' <summary>
    ''' 读取INP模式  INP信号会影响到轴的运动状态（check_done)
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能状态：0-禁止，1-允许</param>
    ''' <param name="inp_logic">有效电平：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_inp_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef enable As UInt16, ByRef inp_logic As UInt16) As Int16  '读取设置INP信号
    ''' <summary>
    ''' 设置ALM模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能状态：0-禁止，1-允许</param>
    ''' <param name="alm_logic">有效电平：0-低电平，1-高电平</param>
    ''' <param name="alm_action">制动方式：0-立即停止</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_alm_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal enable As UInt16, ByVal alm_logic As UInt16, ByVal alm_action As UInt16) As Int16 '设置ALM信号
    ''' <summary>
    ''' 读取ALM模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="enable">使能状态：0-禁止，1-允许</param>
    ''' <param name="alm_logic">有效电平：0-低电平，1-高电平</param>
    ''' <param name="alm_action">制动方式：0-立即停止</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_alm_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef enable As UInt16, ByRef alm_logic As UInt16, ByRef alm_action As UInt16) As Int16     '读取设置ALM信号
    ''' <summary>
    ''' 写伺服使能信号输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="on_off">输出状态：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_write_sevon_pin Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal on_off As UInt16) As Int16       '输出SEVON信号
    ''' <summary>
    ''' 读伺服使能信号输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>输出状态：0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_sevon_pin Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16         '读取SEVON信号
    ''' <summary>
    ''' 读伺服准备好信号输入口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>输入状态：0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_rdy_pin Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16           '读取RDY状态
    ''' <summary>
    ''' 写伺服误差清除输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="on_off">输出状态：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_write_erc_pin Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal on_off As UInt16) As Int16       '控制ERC信号输出 
    ''' <summary>
    ''' 读伺服误差清除输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>输出状态：0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_erc_pin Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16       '读取控制ERC信号输出 
    '运动状态
    ''' <summary>
    ''' 读取当前速度
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>速度值</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_current_speed Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Double      '读取指定轴的当前速度
    ''' <summary>
    ''' 读取当前插补速度
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <returns>插补速度</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_vector_speed Lib "LTDMC.dll" (ByVal CardNo As UInt16) As Double    '读取当前卡的插补速度
    ''' <summary>
    ''' 读取当前指令位置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>位置值</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_position Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int32      '读取指定轴的当前位置
    ''' <summary>
    ''' 设置指令位置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="current_position">位置值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_position Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal current_position As Int32) As Int16   '设定指定轴的当前位置
    ''' <summary>
    ''' 检测轴的运动状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>运动状态：0-运动，1-停止</returns>
    ''' <remarks></remarks>
    Declare Function dmc_check_done Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16     '读取指定轴的运动状态
    ''' <summary>
    ''' 检测单段插补运动状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <returns>运动状态：0-运动，1-停止</returns>
    ''' <remarks></remarks>
    Declare Function dmc_check_done_multicoor Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16) As Int16
    ''' <summary>
    ''' 轴IO状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>轴IO状态：0 ALM 1 EL+ 2 EL- 3 EMG 4 ORG 6 SL+ 7 SL- 8 INP 9 EZ 10 RDY 11 DSTP</returns>
    ''' <remarks></remarks>
    Declare Function dmc_axis_io_status Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As UInt32    '读取指定轴有关运动信号的状态
    ''' <summary>
    ''' 停止单轴运动
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="stop_mode">停止模式：0-减速停止，1-立即停止</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_stop Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal stop_mode As UInt16) As Int16       '单轴停止
    ''' <summary>
    ''' 停止单段插补运动
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="stop_mode">停止模式：0-减速停止，1-立即停止</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_stop_multicoor Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal stop_mode As UInt16) As Int16
    ''' <summary>
    ''' 急停所有轴运动
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_emg_stop Lib "LTDMC.dll" (ByVal CardNo As UInt16) As Int16      '紧急停止所有轴
    ''' <summary>
    ''' 读取目标位置
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>目标位置值</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_target_position Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int32      '读取目标位置
    '检测轴到位状态
    ''' <summary>
    ''' 设置误差带
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="factor">编码器系数</param>
    ''' <param name="pos_error">误差带</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_factor_error Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal factor As Double, ByVal pos_error As Int32) As Int16
    ''' <summary>
    ''' 读取误差带
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="factor">编码器系数</param>
    ''' <param name="pos_error">误差带</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_factor_error Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef factor As Double, ByRef pos_error As Int32) As Int16
    ''' <summary>
    ''' 检测指令位置到位 超时100ms
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>到位状态：0-不在误差带范围内，1-在误差带范围内</returns>
    ''' <remarks></remarks>
    Declare Function dmc_check_success_pulse Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16
    ''' <summary>
    ''' 检测反馈位置到位 超时100ms
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>到位状态：0-不在误差带范围内，1-在误差带范围内</returns>
    ''' <remarks></remarks>
    Declare Function dmc_check_success_encoder Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16

    '3800 5800专用 主卡与接线盒通讯状态
    ''' <summary>
    ''' 读取通讯状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="state">状态：0-连接，1-断开</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_LinkState Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef state As UInt16) As Int16      '连接状态

    'DMC5410 DMC5800专用 脉冲当量操作 连续插补功能
    ''' <summary>
    ''' 读取运动模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="run_mode">运动模式</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_axis_run_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef run_mode As UInt16) As Int16       '轴运动模式
    ''' <summary>
    ''' 读取脉冲当量
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="equiv">脉冲当量值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_equiv Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef equiv As Double) As Int16       '脉冲当量
    ''' <summary>
    ''' 设置脉冲当量
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="equiv">脉冲当量值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_equiv Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal equiv As Double) As Int16
    ''' <summary>
    ''' 设置反向间隙
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="backlash">反向间隙值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_backlash_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal backlash As Double) As Int16  '反向间隙
    ''' <summary>
    ''' 读取反向间隙值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="backlash">反向间隙值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_backlash_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef backlash As Double) As Int16
    ''' <summary>
    ''' 设置指令位置值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="pos">位置值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_position_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal pos As Double) As Int16    '当前指令位置
    ''' <summary>
    ''' 读取指令位置值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="pos">指令位置值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_position_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef pos As Double) As Int16
    ''' <summary>
    ''' 设置编码器（反馈）位置值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="pos">位置值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_encoder_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal pos As Double) As Int16   '当前反馈位置
    ''' <summary>
    ''' 读取编码器（反馈）位置值
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="pos">位置值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_encoder_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef pos As Double) As Int16
    ''' <summary>
    ''' 定长运动
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Dist">目标位置</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_pmove_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal Dist As Double, ByVal posi_mode As UInt16) As Int16  '定长
    ''' <summary>
    ''' 单段直线插补
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2-6</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="Target_Pos">目标位置</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_line_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef Target_Pos As Double, ByVal posi_mode As UInt16) As Int16   '单段直线
    ''' <summary>
    ''' 单段插补圆心圆弧/螺旋线/渐开线
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2-6</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="Target_Pos">目标位置</param>
    ''' <param name="Cen_Pos">圆心位置</param>
    ''' <param name="Arc_Dir">圆弧方向：0-顺时针，1-逆时针</param>
    ''' <param name="Circle">圆弧圈数</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_arc_move_center_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef Target_Pos As Double, ByRef Cen_Pos As Double, ByVal Arc_Dir As UInt16, ByVal Circle As Int32, ByVal posi_mode As UInt16) As Int16    '圆心终点式圆弧/螺旋线/渐开线
    ''' <summary>
    ''' 单段插补半径圆弧/螺旋线
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2-6</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="Target_Pos">目标位置</param>
    ''' <param name="Arc_Radius">半径值</param>
    ''' <param name="Arc_Dir">圆弧方向：0-顺时针，1-逆时针</param>
    ''' <param name="Circle">圆弧圈数</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_arc_move_radius_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef Target_Pos As Double, ByVal Arc_Radius As Double, ByVal Arc_Dir As UInt16, ByVal Circle As Int32, ByVal posi_mode As UInt16) As Int16   '半径终点式圆弧/螺旋线
    ''' <summary>
    ''' 连续插补三点圆弧（包括空间）/螺旋线
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2-6</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="Target_Pos">目标位置</param>
    ''' <param name="Mid_Pos">中间位置</param>
    ''' <param name="Circle">圈数：不小于0时表示基于轴列表前两轴平面的螺旋线，小于0时绝对值减1表示空间圆弧圈数</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_arc_move_3points_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef Target_Pos As Double, ByRef Mid_Pos As Double, ByVal Circle As Int32, ByVal posi_mode As UInt16) As Int16    '三点式圆弧/螺旋线
    ''' <summary>
    ''' 矩形区域插补
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="Target_Pos">对角位置</param>
    ''' <param name="Mark_Pos">矩形方向标记位置</param>
    ''' <param name="Count">行数/圈数</param>
    ''' <param name="rect_mode">矩形插补模式:0-逐行，1-渐开线</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_rectangle_move_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef Target_Pos As Double, ByRef Mark_Pos As Double, ByVal Count As Long, ByVal rect_mode As UInt16, ByVal posi_mode As UInt16) As Int16
    ''' <summary>
    ''' 读取当前速度，轴参与插补读的是插补速度
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="current_speed">当前速度值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_current_speed_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef current_speed As Double) As Int16  '轴当前运行速度
    ''' <summary>
    ''' 设置单段插补速度参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="Min_Vel">起始速度</param>
    ''' <param name="Max_Vel">运行速度</param>
    ''' <param name="Tacc">加速时间，单位s</param>
    ''' <param name="Tdec">减速时间，单位s</param>
    ''' <param name="Stop_vel">停止速度</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_vector_profile_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Stop_vel As Double) As Int16    '单段插补速度参数
    ''' <summary>
    ''' 读取单段插补速度参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="Min_Vel">起始速度</param>
    ''' <param name="Max_Vel">运行速度</param>
    ''' <param name="Tacc">加速时间，单位s</param>
    ''' <param name="Tdec">减速时间，单位s</param>
    ''' <param name="Stop_vel">停止速度</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_vector_profile_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByRef Min_Vel As Double, ByRef Max_Vel As Double, ByRef Tacc As Double, ByRef Tdec As Double, ByRef Stop_vel As Double) As Int16
    ''' <summary>
    ''' 设置单轴速度参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Min_Vel">起始速度</param>
    ''' <param name="Max_Vel">运行速度</param>
    ''' <param name="Tacc">加速时间，单位s</param>
    ''' <param name="Tdec">减速时间，单位s</param>
    ''' <param name="Stop_vel">停止速度</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_profile_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Stop_vel As Double) As Int16   '单轴速度参数
    ''' <summary>
    ''' 读取单轴速度参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="Min_Vel">起始速度</param>
    ''' <param name="Max_Vel">运行速度</param>
    ''' <param name="Tacc">加速时间，单位s</param>
    ''' <param name="Tdec">减速时间，单位s</param>
    ''' <param name="Stop_vel">停止速度</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_profile_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef Min_Vel As Double, ByRef Max_Vel As Double, ByRef Tacc As Double, ByRef Tdec As Double, ByRef Stop_vel As Double) As Int16
    ''' <summary>
    ''' 在线变位
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="New_pos">新位置值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_reset_target_position_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal New_pos As Double) As Int16   '在线变位
    ''' <summary>
    ''' 强制变位
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="New_pos">新位置值</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_update_target_position_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal New_pos As Double) As Int16   '强行变位
    ''' <summary>
    ''' 在线变速
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="New_vel">新速度值</param>
    ''' <param name="Taccdec">新加减速时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_change_speed_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal New_vel As Double, ByVal Taccdec As Double) As Int16           '在线变速

    '连续插补
    ''' <summary>
    ''' 打开连续插补缓冲区
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2-6</param>
    ''' <param name="AxisList">轴列表：AxisList[0]-X,AxisList[1]-Y,AxisList[2]-Z,AxisList[3]-U,AxisList[4]-V,AxisList[5]-W</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_open_list Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16) As Int16     '打开连续缓存区
    ''' <summary>
    ''' 关闭连续插补缓冲区
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_close_list Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16) As Int16     '关闭连续缓存区
    ''' <summary>
    ''' 停止连续插补
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="stop_mode">停止模式：0-减速停止，1-立即停止</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_stop_list Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal stop_mode As UInt16) As Int16    '连续插补中停止
    ''' <summary>
    ''' 暂停连续插补
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_pause_list Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16) As Int16     '连续插补中暂停
    ''' <summary>
    ''' 启动连续插补
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_start_list Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16) As Int16    '开始连续插补
    ''' <summary>
    ''' 读取剩余缓冲区空间，调用插补指令请请先判断是否有剩余空间
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <returns>剩余空间</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_remain_space Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16) As Int32     '查连续插补剩余缓存数
    ''' <summary>
    ''' 读取当前段号
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <returns>当前段号</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_read_current_mark Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16) As Int32  '读取当前连续插补段的标号
    ''' <summary>
    ''' 设置拐角混合运动自动平滑过度使能状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="enable">使能状态：0-禁用，1-允许</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_set_blend Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal enable As UInt16) As Int16    'blend拐角过度模式
    ''' <summary>
    ''' 读取拐角混合运动自动平滑过度使能状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="enable">使能状态：0-禁用，1-允许</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_get_blend Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByRef enable As UInt16) As Int16
    ''' <summary>
    ''' 设置插补速度  打开缓冲区前请先预设参数，确定加减速时间，打开缓冲区之后加减速时间参数无法修改
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="Min_Vel">保留</param>
    ''' <param name="Max_Vel">最大运行速度</param>
    ''' <param name="Tacc">加减速时间，单位s</param>
    ''' <param name="Tdec">保留</param>
    ''' <param name="Stop_vel">保留</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_set_profile_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Stop_vel As Double) As Int16   '设置连续插补速度
    ''' <summary>
    ''' 设置S型速度曲线参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="s_mode">保留：0</param>
    ''' <param name="s_para">S段时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_set_s_profile Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal s_mode As UInt16, ByVal s_para As Double) As Int16      '设置连续插补平滑时间
    ''' <summary>
    ''' 读取S型速度曲线参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="s_mode">保留：0</param>
    ''' <param name="s_para">S段时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_get_s_profile Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal s_mode As UInt16, ByRef s_para As Double) As Int16
    ''' <summary>
    ''' 预设单段速度倍率
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="Percent">速度倍率：0-1</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_set_override Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal Percent As Double) As Int16   '设置每段速度比例  缓冲区指令
    ''' <summary>
    ''' 在线调整速度倍率
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="Percent">速度倍率：0-1</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_change_speed_ratio Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal Percent As Double) As Int16
    ''' <summary>
    ''' 读取连续插补状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <returns>连续插补状态：0-运行，1-暂停，2-正常停止，3-未启动，4-空闲</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_get_run_state Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16) As Int16
    ''' <summary>
    ''' 读取连续插补运动状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <returns>运动状态：0-运行，1-停止</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_check_done Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16) As Int16
    ''' <summary>
    ''' 等待输入
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="bitno">IO口号：0-31</param>
    ''' <param name="on_off">输入口有效状态：0-低电平，1-高电平</param>
    ''' <param name="TimeOut">超时时间，单位s</param>
    ''' <param name="mark">段号：0-自动递增</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_wait_input Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal bitno As UInt16, ByVal on_off As UInt16, ByVal TimeOut As Double, ByVal mark As Int32) As Int16   '设置连续插补等待输入
    ''' <summary>
    ''' 相对起点IO滞后输出
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="bitno">输出口号：0-4</param>
    ''' <param name="on_off">输出状态：0-低电平，1-高电平</param>
    ''' <param name="delay_value">滞后值</param>
    ''' <param name="delay_mode">滞后模式：0-时间，1-距离</param>
    ''' <param name="ReverseTime">翻转时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_delay_outbit_to_start Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal bitno As UInt16, ByVal on_off As UInt16, ByVal delay_value As Double, ByVal delay_mode As UInt16, ByVal ReverseTime As Double) As Int16    '相对于轨迹段起点IO滞后输出
    ''' <summary>
    ''' 相对终点IO滞后输出
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="bitno">输出口号：0-4</param>
    ''' <param name="on_off">输出状态：0-低电平，1-高电平</param>
    ''' <param name="delay_time">滞后时间，单位s</param>
    ''' <param name="ReverseTime">翻转时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_delay_outbit_to_stop Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal bitno As UInt16, ByVal on_off As UInt16, ByVal delay_time As Double, ByVal ReverseTime As Double) As Int16   '相对于轨迹段终点IO滞后输出
    ''' <summary>
    ''' 相对终点IO提前输出
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="bitno">输出口号：0-4</param>
    ''' <param name="on_off">输出状态：0-低电平，1-高电平</param>
    ''' <param name="ahead_value">提前量</param>
    ''' <param name="ahead_mode">提前模式：0-时间，1-距离</param>
    ''' <param name="ReverseTime">翻转时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_ahead_outbit_to_stop Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal bitno As UInt16, ByVal on_off As UInt16, ByVal ahead_value As Double, ByVal ahead_mode As UInt16, ByVal ReverseTime As Double) As Int16  '相对轨迹段终点IO提前输出
    ''' <summary>
    ''' 相对起点IO精确滞后距离输出
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="cmp_no">高速比较输出口号：0-4</param>
    ''' <param name="on_off">输出状态：0-低电平，1-高电平</param>
    ''' <param name="map_axis">关联轴号：0-X,1-Y,2-Z,3-U,4-V,5-W</param>
    ''' <param name="delay_dist">滞后距离</param>
    ''' <param name="pos_source">位置源：0-指令位置，1-反馈位置</param>
    ''' <param name="ReverseTime">翻转时间,单位us,至少1us</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_accurate_outbit_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal cmp_no As UInt16, ByVal on_off As UInt16, ByVal map_axis As UInt16, ByVal delay_dist As Double, ByVal pos_source As UInt16, ByVal ReverseTime As Double) As Int16     '确定位置精确输出
    ''' <summary>
    ''' 连续插补立即输出IO
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="bitno">IO口号：0-31</param>
    ''' <param name="on_off">输出状态：0-低电平，1-高电平</param>
    ''' <param name="ReverseTime">翻转时间，单位s</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_write_outbit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal bitno As UInt16, ByVal on_off As UInt16, ByVal ReverseTime As Double) As Int16     '缓冲区立即IO输出
    ''' <summary>
    ''' 清除IO段内未执行完的动作，比如延时翻转
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="IoMask">IO口标记：bit0-bit31代表out0-out31,位值：0-不清除，1-清除</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_clear_io_action Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal IoMask As UInt32) As Int16   '清除段内未执行完的IO动作
    ''' <summary>
    ''' 设置连续插补暂停时输出
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="action">执行动作：0-不动作，1-暂停时输出，运行时不恢复，2-暂停时输出，运行时恢复，3-停止时输出，运行时不恢复</param>
    ''' <param name="mask">IO口标记：bit0-bit31代表out0-out31,位值：0-不参与动作，1-参与动作</param>
    ''' <param name="state">IO口状态：bit0-bit31代表out0-out31,位值：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_set_pause_output Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal action As UInt16, ByVal mask As Int32, ByVal state As Int32) As Int16   '暂停时IO输出 action 0, 不工作；1， 暂停时输出io_state; 2 暂停时输出io_state, 继续运行时首先恢复原来的io; 3,在2的基础上，停止时也生效
    ''' <summary>
    ''' 读取连续插补暂停时输出
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="action">执行动作：0-不动作，1-暂停时输出，运行时不恢复，2-暂停时输出，运行时恢复，3-停止时输出，运行时不恢复</param>
    ''' <param name="mask">IO口标记：bit0-bit31代表out0-out31,位值：0-不参与动作，1-参与动作</param>
    ''' <param name="state">IO口状态：bit0-bit31代表out0-out31,位值：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_get_pause_output Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByRef action As UInt16, ByRef mask As Int32, ByRef state As Int32) As Int16
    ''' <summary>
    ''' 连续插补暂停延时
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="delay_time">延时时间，单位s</param>
    ''' <param name="mark">段号：0-自动递增</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_delay Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal delay_time As Double, ByVal mark As Int32) As Int16    '添加延时指令
    ''' <summary>
    ''' 连续插补直线插补
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2-6</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="Target_Pos">目标位置</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <param name="mark">段号：0-自动递增</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_line_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef Target_Pos As Double, ByVal posi_mode As UInt16, ByVal mark As Int32) As Int16    '连续插补直线
    ''' <summary>
    ''' 连续插补圆心圆弧/螺旋线/渐开线
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2-6</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="Target_Pos">目标位置</param>
    ''' <param name="Cen_Pos">圆心位置</param>
    ''' <param name="Arc_Dir">圆弧方向：0-顺时针，1-逆时针</param>
    ''' <param name="Circle">圆弧圈数:负值表示同心圆</param>
    ''' <param name="posi_mode">位置模式</param>
    ''' <param name="mark">段号：0-自动递增</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_arc_move_center_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef Target_Pos As Double, ByRef Cen_Pos As Double, ByVal Arc_Dir As UInt16, ByVal Circle As Int32, ByVal posi_mode As UInt16, ByVal mark As Int32) As Int16    '圆心终点式圆弧/螺旋线/渐开线
    ''' <summary>
    ''' 连续插补半径圆弧/螺旋线
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2-6</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="Target_Pos">目标位置</param>
    ''' <param name="Arc_Radius">半径值</param>
    ''' <param name="Arc_Dir">圆弧方向：0-顺时针，1-逆时针</param>
    ''' <param name="Circle">圆弧圈数:负值表示同心圆圈数</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <param name="mark">段号：0-自动递增</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_arc_move_radius_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef Target_Pos As Double, ByVal Arc_Radius As Double, ByVal Arc_Dir As UInt16, ByVal Circle As Int32, ByVal posi_mode As UInt16, ByVal mark As Int32) As Int16   '半径终点式圆弧/螺旋线
    ''' <summary>
    ''' 连续插补三点圆弧（包括空间）/螺旋线
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2-6</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="Target_Pos">目标位置</param>
    ''' <param name="Mid_Pos">中间位置</param>
    ''' <param name="Circle">圈数：不小于0时表示基于轴列表前两轴平面的螺旋线，小于0时绝对值减1表示空间圆弧圈数</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <param name="mark">段号：0-自动递增</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_arc_move_3points_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef Target_Pos As Double, ByRef Mid_Pos As Double, ByVal Circle As Int32, ByVal posi_mode As UInt16, ByVal mark As Int32) As Int16    '三点式圆弧/螺旋线
    ''' <summary>
    ''' 设置渐开线插补模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="mode">模式：0-不封闭，1-封闭</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_set_involute_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal mode As UInt16) As Int16
    ''' <summary>
    ''' 读取渐开线插补模式
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="mode">封闭圆模式：0-不封闭，1-封闭</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_get_involute_mode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByRef mode As UInt16) As Int16
    ''' <summary>
    ''' 矩形区域插补
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="AxisNum">轴数：2</param>
    ''' <param name="AxisList">轴列表</param>
    ''' <param name="Target_Pos">对角位置</param>
    ''' <param name="Mark_Pos">矩形方向标记位置</param>
    ''' <param name="Count">行数/圈数</param>
    ''' <param name="rect_mode">矩形插补模式:0-逐行，1-渐开线</param>
    ''' <param name="posi_mode">位置模式：0-相对，1-绝对</param>
    ''' <param name="mark">段号：0-自动递增，>0按设置值设置段号</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_rectangle_move_unit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal AxisNum As UInt16, ByRef AxisList As UInt16, ByRef Target_Pos As Double, ByRef Mark_Pos As Double, ByVal Count As Long, ByVal rect_mode As UInt16, ByVal posi_mode As UInt16, ByVal mark As Long) As Int16
    ''' <summary>
    ''' 计算圆心圆弧弧长
    ''' </summary>
    ''' <param name="start_pos">起始位置</param>
    ''' <param name="target_pos">目标位置</param>
    ''' <param name="cen_pos">圆形位置</param>
    ''' <param name="arc_dir">圆弧方向</param>
    ''' <param name="circle">圈数</param>
    ''' <param name="ArcLength">弧长</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_calculate_arclength_center Lib "LTDMC.dll" (ByRef start_pos As Double, ByRef target_pos As Double, ByRef cen_pos As Double, ByVal arc_dir As UInt16, ByVal circle As Double, ByRef ArcLength As Double) As Int16
    ''' <summary>
    ''' 计算三点圆弧弧长
    ''' </summary>
    ''' <param name="start_pos">起始位置</param>
    ''' <param name="target_pos">目标位置</param>
    ''' <param name="cen_pos">圆形位置</param>
    ''' <param name="circle">圈数</param>
    ''' <param name="ArcLength">弧长</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_calculate_arclength_3point Lib "LTDMC.dll" (ByRef start_pos As Double, ByRef target_pos As Double, ByRef cen_pos As Double, ByVal circle As Double, ByRef ArcLength As Double) As Int16
    ''' <summary>
    ''' 计算半径圆弧弧长
    ''' </summary>
    ''' <param name="start_pos">起始位置</param>
    ''' <param name="target_pos">目标位置</param>
    ''' <param name="arc_radius">圆弧半径</param>
    ''' <param name="arc_dir">圆弧方向</param>
    ''' <param name="circle">圈数</param>
    ''' <param name="ArcLength">弧长</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_calculate_arclength_radius Lib "LTDMC.dll" (ByRef start_pos As Double, ByRef target_pos As Double, ByVal arc_radius As Double, ByVal arc_dir As UInt16, ByVal circle As Double, ByRef ArcLength As Double) As Int16
    ''' <summary>
    ''' 设置7号轴PWM输出功能
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="enable">使能：0-禁用，1-启用</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_pwm_enable Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal enable As UInt16) As Int16
    ''' <summary>
    ''' 读取7号轴PWM输出功能
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="enable">使能：0-禁用，1-启用</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_pwm_enable Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef enable As UInt16) As Int16
    ''' <summary>
    ''' 连续插补中设置PWM输出
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="pwm_no">PWM通道：0-1</param>
    ''' <param name="fDuty">占空比：0-1</param>
    ''' <param name="fFre">频率：0-2MHz</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_set_pwm_output Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal pwm_no As UInt16, ByVal fDuty As Double, ByVal fFre As Double) As Int16
    ''' <summary>
    ''' 设置PWM输出，立即执行
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="pwm_no">PWM通道：0-1</param>
    ''' <param name="fDuty">占空比：0-1</param>
    ''' <param name="fFre">频率：0-2MHz</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_pwm_output Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal pwm_no As UInt16, ByVal fDuty As Double, ByVal fFre As Double) As Int16
    ''' <summary>
    ''' 读取PWM输出
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="pwm_no">PWM通道：0-1</param>
    ''' <param name="fDuty">占空比：0-1</param>
    ''' <param name="fFre">频率：0-2MHz</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_pwm_output Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal pwm_no As UInt16, ByRef fDuty As Double, ByRef fFre As Double) As Int16
    ''' <summary>
    ''' 设置PWM速度跟随参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="pwm_no">PWM通道：0-1</param>
    ''' <param name="mode">跟随模式:0-不跟随 保持状态,1-不跟随 输出低电平,2-不跟随 输出高电平,3-跟随 占空比自动调整,4-跟随 频率自动调整</param>
    ''' <param name="MaxVel">最大运行速度，单位unit</param>
    ''' <param name="MaxValue">最大输出占空比或者频率</param>
    ''' <param name="OutValue">固定输出频率（0-2MHz)或占空比（0-1）</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_set_pwm_follow_speed Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal pwm_no As UInt16, ByVal mode As UInt16, ByVal MaxVel As Double, ByVal MaxValue As Double, ByVal OutValue As Double) As Int16
    ''' <summary>
    ''' 读取PWM速度跟随参数
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Crd">坐标系号：0-1</param>
    ''' <param name="pwm_no">PWM通道：0-1</param>
    ''' <param name="mode">跟随模式:0-不跟随 保持状态,1-不跟随 输出低电平,2-不跟随 输出高电平,3-跟随 占空比自动调整,4-跟随 频率自动调整</param>
    ''' <param name="MaxVel">最大运行速度，单位unit</param>
    ''' <param name="MaxValue">最大输出占空比或者频率</param>
    ''' <param name="OutValue">固定输出频率（0-2MHz)或占空比（0-1）</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_conti_get_pwm_follow_speed Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Crd As UInt16, ByVal pwm_no As UInt16, ByRef mode As UInt16, ByRef MaxVel As Double, ByRef MaxValue As Double, ByRef OutValue As Double) As Int16
    ''' <summary>
    ''' 设置CanIO通讯状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="NodeNum">节点数：1-4</param>
    ''' <param name="state">状态：0-断开，1-连接，2-复位后自动连接</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_set_can_state Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal NodeNum As UInt16, ByVal state As UInt16, ByVal Baud As UInt16) As Int16
    ''' <summary>
    ''' 读取CanIO通讯状态
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="NodeNum">节点数：1-4</param>
    ''' <param name="state">状态：0-断开，1-连接，2-异常</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_can_state Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef NodeNum As UInt16, ByRef state As UInt16) As Int16
    ''' <summary>
    ''' 按位写CanIO输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Node">节点号：1-4</param>
    ''' <param name="bitno">IO口号：0-15</param>
    ''' <param name="on_off">输出口状态：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_write_can_outbit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Node As UInt16, ByVal bitno As UInt16, ByVal on_off As UInt16) As Int16
    ''' <summary>
    ''' 按位读CanIo输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Node">节点号：1-4</param>
    ''' <param name="bitno">IO口号：0-15</param>
    ''' <returns>输出口状态：0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_can_outbit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Node As UInt16, ByVal bitno As UInt16) As Int16
    ''' <summary>
    ''' 按位读CanIo输入口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Node">节点号：1-4</param>
    ''' <param name="bitno">IO口号：0-15</param>
    ''' <returns>输入口状态：0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_can_inbit Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Node As UInt16, ByVal bitno As UInt16) As Int16
    ''' <summary>
    ''' 按端口号写CanIO输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Node">节点号：1-4</param>
    ''' <param name="PortNo">端口号：0-1</param>
    ''' <param name="outport_val">输出端口值：bit0-bit31对应Out0-out31,0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_write_can_outport Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Node As UInt16, ByVal PortNo As UInt16, ByVal outport_val As UInt32) As Int16
    ''' <summary>
    ''' 按端口号读CanIO输出口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Node">节点号：1-4</param>
    ''' <param name="PortNo">端口号：0-1</param>
    ''' <returns>输出端口值：bit0-bit31对应Out0-out31,0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_can_outport Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Node As UInt16, ByVal PortNo As UInt16) As UInt32
    ''' <summary>
    ''' 按端口号读CanIO输入口
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Node">节点号：1-4</param>
    ''' <param name="PortNo">端口号：0-1</param>
    ''' <returns>输入端口值：bit0-bit31对应Out0-out31,0-低电平，1-高电平</returns>
    ''' <remarks></remarks>
    Declare Function dmc_read_can_inport Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal Node As UInt16, ByVal PortNo As UInt16) As UInt32
    ''' <summary>
    ''' 读取CanIo通讯错误码
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="Errcode">CAN错误码</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_can_errcode Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByRef Errcode As UInt16) As Int16
    ''' <summary>
    ''' 读取轴停止原因
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <param name="StopReason">停止原因</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_get_stop_reason Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16, ByRef StopReason As Int32) As Int16   '读取轴停止原因
    ''' <summary>
    ''' 清除轴停止原因
    ''' </summary>
    ''' <param name="CardNo">卡号：0-7</param>
    ''' <param name="axis">轴号：0-7</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Declare Function dmc_clear_stop_reason Lib "LTDMC.dll" (ByVal CardNo As UInt16, ByVal axis As UInt16) As Int16   '清除轴停止原因

    'I/O控制函数
    Declare Function ioc_board_init Lib "IOC0640.dll" () As Int32
    Declare Sub ioc_board_close Lib "IOC0640.dll" ()


    Declare Function ioc_read_inbit Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal BitNo As Int16) As Int32
    Declare Function ioc_read_outbit Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal BitNo As Int16) As Int32
    Declare Function ioc_write_outbit Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal BitNo As Int16, ByVal on_off As Int16) As Int32

    Declare Function ioc_read_inport Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal m_PortNo As Int16) As Int32
    Declare Function ioc_read_outport Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal m_PortNo As Int16) As Int32
    Declare Function ioc_write_outport Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal m_PortNo As Int16, ByVal port_value As Int32) As Int32

    Declare Function ioc_int_disable Lib "IOC0640.dll" (ByVal CardNo As Int16) As Int32

    Declare Function ioc_config_intbitmode Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal BitNo As Int16, ByVal enable As Int16, ByVal logic As Int16) As Int32
    Declare Function ioc_read_intbitmode Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal BitNo As Int16, ByVal enable As Int16, ByVal logic As Int16) As Int32
    Declare Function ioc_read_intbitstatus Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal BitNo As Int16) As Int32

    Declare Function ioc_config_intporten Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal m_PortNo As Int16, ByVal port_en As Int32) As Int32
    Declare Function ioc_config_intportlogic Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal m_PortNo As Int16, ByVal port_logic As Int32) As Int32

    Declare Function ioc_read_intportmode Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal m_PortNo As Int16, ByVal enable As Int32, ByVal logic As Int32) As Int32
    Declare Function ioc_read_intportstatus Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal m_PortNo As Int16) As Int32

    Declare Function ioc_set_filter Lib "IOC0640.dll" (ByVal CardNo As Int16, ByVal filter As Double) As Int32




#End Region

#Region "底层函数"
#Region "高速位置比较"
    Public Overrides Function ComparePls(ByVal axis As Int16, ByVal CmpSource As Integer, _
                                              ByVal CmpPositon As Integer, ByVal CmpMode As Integer, _
                                              ByVal CmpLogic As Integer, ByVal CmpComNum As Integer, ByVal PlusWidth As Integer) As Boolean
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_hcmp_set_mode(CardNo, CmpComNum, CmpMode)
            If ini_i <> 0 Then
                Throw New Exception(XX设置高速比较位置比较模式错误_错误信息为 & ini_i)
            End If

            ini_i = dmc_hcmp_set_config(CardNo, CmpComNum, axis, CmpSource, CmpLogic, PlusWidth)
            If ini_i <> 0 Then
                Throw New Exception(XX设置高速比较位置脉冲宽度错误_错误信息为 & ini_i)
            End If
            ini_i = dmc_hcmp_clear_points(CardNo, CmpComNum)
            If ini_i <> 0 Then
                Throw New Exception(XX清除高速比较点错误_错误信息为 & ini_i)
            End If
            ini_i = dmc_hcmp_add_point(CardNo, CmpComNum, CmpPositon)
            If ini_i <> 0 Then
                Throw New Exception(XX添加高速比较位置点错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function CmpSetConfig(ByVal axis As Int16, ByVal CmpComNum As Integer, ByVal CmpSource As Integer, ByVal CmpMode As Integer, ByVal CmpLogic As Integer, ByVal PlusWidth As Integer) As Boolean
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_hcmp_set_mode(CardNo, CmpComNum, CmpMode)
            If ini_i <> 0 Then
                Throw New Exception(XX设置高速比较位置比较模式错误_错误信息为 & ini_i)
            End If
            ini_i = dmc_hcmp_set_config(CardNo, CmpComNum, axis, CmpSource, CmpLogic, PlusWidth)
            If ini_i <> 0 Then
                Throw New Exception(XX设置高速比较位置脉冲宽度错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function
    Public Overrides Function CmpGetState(ByVal AxisNum As Int16, ByVal CmpComNum As Integer, ByRef RemainedPoint As Integer, ByRef CurrentPoint As Integer, ByRef FinshedPoint As Integer) As Boolean
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If AxisNum <= 5 Then
                CardNo = 0
            ElseIf AxisNum > 5 And AxisNum <= 11 Then
                CardNo = 1
            End If
            Dim ini_i As Int16

            ini_i = dmc_hcmp_get_current_state(CardNo, CmpComNum, RemainedPoint, CurrentPoint, FinshedPoint)
            If ini_i <> 0 Then
                Throw New Exception(XX获取高速比较位置当前状态错误_错误信息为 & ini_i)
            End If
            'dmc_hcmp_get_mode(CardNo, CmpComNum, CmpMode)
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function
    Public Overrides Function CmpGetConfig(ByVal AxisNum As Int16, ByVal CmpComNum As Integer, ByRef axis As Int16, ByRef CmpMode As Integer, ByRef CmpSource As Integer, ByRef CmpLogic As Integer, ByRef PlusWidth As Integer) As Boolean
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If AxisNum <= 5 Then
                CardNo = 0
            ElseIf AxisNum > 5 And AxisNum <= 11 Then
                CardNo = 1

            End If
            Dim ini_i As Int16
            ini_i = dmc_hcmp_get_config(CardNo, CmpComNum, axis, CmpSource, CmpLogic, PlusWidth)
            If ini_i <> 0 Then
                Throw New Exception(XX获取高速比较通道脉冲宽度错误_错误信息为 & ini_i)
            End If
            ini_i = dmc_hcmp_get_mode(CardNo, CmpComNum, CmpMode)
            If ini_i <> 0 Then
                Throw New Exception(XX获取高速比较通道比较模式错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function CmpClearPoint(ByVal AxisNam As Int16, ByVal CmpComNum As Integer) As Boolean
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If AxisNam <= 5 Then
                CardNo = 0
            ElseIf AxisNam > 5 And AxisNam <= 11 Then
                CardNo = 1
            End If
            Dim ini_i As Int16
            ini_i = dmc_hcmp_clear_points(CardNo, CmpComNum)
            If ini_i <> 0 Then
                Throw New Exception(XX清除高速比较通道比较点错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function
    Public Overrides Function CmpAddPoint(ByVal AxisNum As Int16, ByVal CmpComNum As Integer, ByVal CmpPositon As Int32) As Boolean
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If AxisNum <= 5 Then
                CardNo = 0
            ElseIf AxisNum > 5 And AxisNum <= 11 Then
                CardNo = 1
            End If
            Dim ini_i As Int16
            ini_i = dmc_hcmp_add_point(CardNo, CmpComNum, CmpPositon)
            If ini_i <> 0 Then
                Throw New Exception(XX添加高速比较点错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

#End Region

#Region "单段直线插补"
    Public Overrides Function SetMulticoorProfileH(ByVal MinVel As Integer, ByVal MaxVel As Integer, ByVal Taac As Single, ByVal Tdec As Single, ByVal StopVel As Integer) As Boolean
        mMust.WaitOne()
        Try
            Dim ini_i As Int16
            ini_i = dmc_set_vector_profile_multicoor(0, 0, MinVel, MaxVel, Taac, Tdec, StopVel)
            If ini_i <> 0 Then
                Throw New Exception(XX设置单独直线插补速度错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function LineMultiCoorH(ByVal AnxisNum As Integer, ByRef UAnxi() As UShort, ByRef Position() As Integer, ByVal PosiMode As Integer) As Boolean
        mMust.WaitOne()
        Try
            Dim ini_i As Int16
            ini_i = dmc_line_multicoor(0, 0, AnxisNum, UAnxi(0), Position(0), PosiMode)
            If ini_i <> 0 Then
                Throw New Exception(XX执行单独直线插补错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function MultiCoorCheckDoneH() As Integer
        mMust.WaitOne()
        Try

            Return dmc_check_done_multicoor(0, 0)
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function GetStopReason(ByVal axis As UInt16, ByRef StopReason As Int32) As Int16

        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            Dim Reason As Int32
            ini_i = dmc_get_stop_reason(CardNo, axis, Reason) 'dmc_set_pulse_outmode(CardNo, axis, outmode)
            Return Reason
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try

        'Return dmc_get_stop_reason(CardNo, axis, StopReason)
    End Function
#End Region

#Region "连续插补"
    Public Overrides Function ContiOpenListH(ByVal AnxisNum As Integer, ByRef UAnxi() As UShort) As Integer
        mMust.WaitOne()
        Try
            Dim ini_i As Int16
            ini_i = dmc_conti_open_list(0, 0, AnxisNum, UAnxi(0))
            If ini_i <> 0 Then
                Throw New Exception(XX打开连续直线插补_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function ContiSetProfileH(ByVal MinVel As Double, ByVal MaxVel As Double, ByVal Taac As Double, ByVal Tdec As Double, ByVal StopVel As Double) As Integer
        mMust.WaitOne()
        Try
            Dim ini_i As Int16
            ini_i = dmc_set_vector_profile_unit(0, 0, MinVel, MaxVel, Taac, Tdec, StopVel)
            If ini_i <> 0 Then
                Throw New Exception(XX设置连续直线插补速度错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function ContiSetSProfileH(ByVal sTime As Double) As Integer
        mMust.WaitOne()
        Try
            Dim ini_i As Int16
            ini_i = dmc_conti_set_s_profile(0, 0, 0, sTime)
            If ini_i <> 0 Then
                Throw New Exception(XX设置连续直线S段匀速时间信息错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function ContiSetEquivH(ByVal AxisNum As Int16, ByVal Equiv As Double) As Integer
        mMust.WaitOne()
        Try
            Dim Card As Byte
            If AxisNum <= 5 Then
                Card = 0
            ElseIf AxisNum > 5 And AxisNum <= 11 Then
                AxisNum -= 6
                Card = 1
            End If
            Dim ini_i As Int16
            ini_i = dmc_set_equiv(Card, AxisNum, Equiv)
            If ini_i <> 0 Then
                Throw New Exception(XX设置直线插补脉冲当量信息错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function ContiLineMoveH(ByVal AnxisNum As Integer, ByRef UAnxi() As UShort, ByRef TargetPosition() As Double, ByVal PosiMode As Integer, ByVal MarkIndex As Integer) As Integer
        mMust.WaitOne()
        Try
            Dim ini_i As Int16
            ini_i = dmc_conti_line_unit(0, 0, AnxisNum, UAnxi(0), TargetPosition(0), PosiMode, MarkIndex)
            If ini_i <> 0 Then
                Throw New Exception(XX启动连续直线运动信息错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function ContiArcMoveH(ByVal AnxisNum As Integer, ByRef UAnxi() As UShort, ByRef TargetPosition() As Double, ByRef CenterPosition() As Double, ByVal ArcDir As Integer,
                                             ByVal Circle As Integer, ByVal PosiMode As Integer, ByVal MarkIndex As Integer) As Integer
        mMust.WaitOne()
        Try
            Dim ini_i As Int16
            ini_i = dmc_conti_arc_move_center_unit(0, 0, AnxisNum, UAnxi(0), TargetPosition(0), CenterPosition(0), ArcDir, Circle, PosiMode, MarkIndex)
            If ini_i <> 0 Then
                Throw New Exception(XX设置螺旋插补直线信息错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function ContiStarListH() As Integer
        mMust.WaitOne()
        Try
            Dim ini_i As Int16
            ini_i = dmc_conti_start_list(0, 0)
            If ini_i <> 0 Then
                Throw New Exception(XX启动连续直线插补错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    Public Overrides Function ContiCloseListH() As Integer
        mMust.WaitOne()
        Try
            Dim ini_i As Int16
            ini_i = dmc_conti_close_list(0, 0)
            If ini_i <> 0 Then
                Throw New Exception(XX关闭连续直线运动信息错误_错误信息为 & ini_i)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

#End Region

    Public Overrides Function Init() As Int16
        mMust.WaitOne()
        Try
            Try
                ioc_board_init()
            Catch ex As Exception
            End Try


            Try
                dmc_board_close()
            Catch ex As Exception
            End Try

            Dim ini_In16 As Int16 = dmc_board_init
            Try
                dmc_set_can_state(0, 1, 1, 0)
            Catch ex As Exception
            End Try

            Try
                dmc_set_can_state(1, 1, 1, 0)
            Catch ex As Exception
            End Try

            Try
                Dim int_i As Int32
                dmc_get_can_state(0, 1, int_i)
            Catch ex As Exception
            End Try

            Try
                Dim int_i As Int32
                dmc_get_can_state(1, 1, int_i)
            Catch ex As Exception
            End Try
            Return ini_In16
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
            Try
                ioc_board_close()
            Catch ex As Exception
            End Try

            Dim ret As Int16 = dmc_board_close()

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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_set_pulse_outmode(CardNo, axis, outmode)
            If ini_i <> 0 Then
                '  Throw New Exception("设置脉冲发生模式信息错误！错误信息为：" & ini_i)
                Throw New AppException("404050", XX设置脉冲发生模式信息错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            'dmc_change_speed(,axis,

        Catch ex As Exception
            Throw ex
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
            'd5400_config_PCS_PIN(axis, enable, pcs_logic)
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16

            ini_i = dmc_set_inp_mode(CardNo, axis, enable, inp_logic)
            If ini_i <> 0 Then
                'Throw New Exception("404051,INP设置错误！错误信息：" & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            'dmc_set_()
            'd5400_config_ERC_PIN(axis, enable, erc_logic, erc_width, erc_off_time)
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_set_alm_mode(CardNo, axis, 1, alm_logic, alm_action)
            If ini_i <> 0 Then
                ' Throw New Exception("设置报警信号电平信息错误！错误信息为：" & ini_i)
                Throw New AppException("404052", XX设置报警信号电平信息错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 设置EL信号的有效电平及制动方式
    ''' </summary>
    ''' <param name="axis">指定轴号</param>
    ''' <param name="el_mode">EL有效电平和制动方式:0－立即停、低有效，1－减速停、低有效，2－立即停、高有效，3－减速停、高有效</param>
    ''' <remarks></remarks>
    Public Overrides Sub ELMODE(ByVal axis As Int16, ByVal el_mode As Int16)
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            'If el_mode = 0 Then
            '    ini_i = dmc_set_el_mode(CardNo, axis, 1, 0, 1)
            'ElseIf el_mode = 1 Then
            '    ini_i = dmc_set_el_mode(CardNo, axis, 1, 0, 0)
            'ElseIf el_mode = 2 Then
            '    ini_i = dmc_set_el_mode(CardNo, axis, 1, 1, 1)
            'ElseIf el_mode = 3 Then
            '    ini_i = dmc_set_el_mode(CardNo, axis, 1, 1, 0)
            'End If
            ini_i = dmc_set_el_mode(CardNo, axis, 1, el_mode, 0)
            If ini_i <> 0 Then
                ' Throw New Exception("设置编码器计数模式信息错误！错误信息为：" & ini_i)
                Throw New AppException("404053", XX设置编码器计数模式信息错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_set_home_pin_logic(CardNo, axis, org_logic, filter)
            If ini_i <> 0 Then
                'Throw New Exception("设置复位逻辑电平信息错误！错误信息为：" & ini_i)
                Throw New AppException("404054", XX设置复位逻辑电平信息错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_write_sevon_pin(CardNo, axis, on_off)
            If ini_i <> 0 Then
                'Throw New Exception("上下电信息错误！错误信息为：" & ini_i)
                Throw New AppException("404054", XX上下电信息错误_错误信息为 & ini_i)
            End If
            'd5400_write_SEVON_PIN(axis, on_off)
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If

            Return dmc_read_rdy_pin(CardNo, axis)
            'Return d5400_read_RDY_PIN(axis)
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    ''' <summary>
    ''' 读取通用输入点
    ''' </summary>
    ''' <param name="cardno">对应的卡号</param>
    ''' <param name="BitNo">对应的IO点号</param>
    ''' <returns></returns>0为低电平 1为高电平
    ''' <remarks></remarks>
    Public Overrides Function ReadInbit(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
        mMust.WaitOne()
        Try
            'Dim bb As Boolean = dmc_read_inbit(cardno, BitNo)
            If cardno >= 3 Then
                Return ioc_read_inbit(0, BitNo)
            Else
                If BitNo <= 15 Then
                    Return dmc_read_inbit(cardno, BitNo)
                Else
                    Return (dmc_read_can_inbit(cardno, 1, BitNo - 16))
                End If
            End If

        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    ''' <summary>
    ''' 写入通用输出点
    ''' </summary>
    ''' <param name="cardno">对应的卡号</param>
    ''' <param name="BitNo">对应的IO点</param>
    ''' <param name="on_off">要写入ON  OFF  1为ON高电平 0为OFF低电平</param>
    ''' <remarks></remarks>
    Public Overrides Sub WriteOutbit(ByVal cardno As Int16, ByVal BitNo As Int16, ByVal on_off As Int16)
        mMust.WaitOne()
        Try
            Dim ini_i As Int16
            If cardno >= 3 Then
                ioc_write_outbit(0, BitNo, on_off)
            Else
                If BitNo <= 15 Then
                    ini_i = dmc_write_outbit(cardno, BitNo, on_off)
                Else
                    Try
                        Dim int_i As Int32
                        Dim T As Long = Now.Ticks
                        dmc_get_can_state(cardno, 1, int_i)
                        Dim T1 = (Now.Ticks - T) / 10000
                        If int_i <> 1 Then 'can卡掉线重连
                            dmc_set_can_state(cardno, 1, 1, 0)
                            dmc_get_can_state(cardno, 1, int_i)
                            If int_i <> 1 Then
                                ' Throw New Exception("404015,IO扩展卡掉线重连异常!错误信息：" & int_i)
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                    ini_i = dmc_write_can_outbit(cardno, 1, BitNo - 16, on_off)
                End If

                If ini_i <> 0 Then
                    ' Throw New Exception("写入输出点电平信息错误！错误信息为：" & ini_i)
                    Throw New AppException("404055", XX写入输出点电平信息错误_错误信息为 & ini_i)
                End If
            End If

        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub


    ''' <summary>
    ''' 读取通用输出点
    ''' </summary>
    ''' <param name="cardno">对应卡号</param>
    ''' <param name="BitNo">对应的IO点</param>
    ''' <returns></returns>0为低电平 1为高电平
    ''' <remarks></remarks>
    Public Overrides Function ReadOutbit(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
        mMust.WaitOne()
        Try
            If cardno >= 3 Then
                Return ioc_read_outbit(0, BitNo)
            Else
                If BitNo <= 15 Then
                    Return dmc_read_outbit(cardno, BitNo)
                Else
                    Try
                        Dim int_i As Int32
                        dmc_get_can_state(cardno, 1, int_i)
                        If int_i <> 1 Then 'can卡掉线重连
                            dmc_set_can_state(cardno, 1, 1, 0)
                            dmc_get_can_state(cardno, 1, int_i)
                            If int_i <> 1 Then
                                '  Throw New Exception("404025,IO扩展卡掉线重连异常!错误信息：" & int_i)
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                    Return dmc_read_can_outbit(cardno, 1, BitNo - 16)
                End If
            End If


        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
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
            If card >= 3 Then
                Return ioc_read_inport(0, 0)
            Else
                Return dmc_read_outport(card, 0)
            End If


        Catch ex As Exception
            Throw ex
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
            If card >= 3 Then
                Return ioc_read_outport(0, 0)
            Else
                Return dmc_read_outport(card, 0)
            End If

        Catch ex As Exception
            Throw ex
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
        mMust.WaitOne()
        Try
            Dim ini_i As Int16
            ini_i = dmc_write_outport(cardno, 0, Port_Value)
            If ini_i <> 0 Then
                'Throw New Exception("写入全部输出点电平信息错误！错误信息为：" & ini_i)
                Throw New AppException("404056", XX写入输出点电平信息错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
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
            Dim CardNo As UShort = 0
            Dim HomeMode As Byte
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            If mode = 0 Then
                HomeMode = 0
            ElseIf mode = 4 Then
                HomeMode = 4
            Else
                HomeMode = 3
            End If
            Dim ini_i As Int16
            ini_i = dmc_set_homemode(CardNo, axis, 0, 0, HomeMode, EZ_count)
            If ini_i <> 0 Then
                '  Throw New Exception("设置复位EZ信号信息错误！错误信息为：" & ini_i)
                Throw New AppException("404057", XX设置复位EZ信号信息错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If

            Dim ini_i As Int16

            ini_i = dmc_home_move(CardNo, axis)
            If ini_i <> 0 Then
                ' Throw New Exception("执行复位函数错误！错误信息为：" & ini_i)
                Throw New AppException("404058", XX执行复位函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_stop(CardNo, axis, 0)
            If ini_i <> 0 Then
                'Throw New Exception("执行减速停止轴函数错误！错误信息为：" & ini_i)
                Throw New AppException("404059", XX执行减速停止轴函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_stop(CardNo, axis, 1)
            If ini_i <> 0 Then
                'Throw New Exception("执行紧急停止轴函数错误！错误信息为：" & ini_i)

                Throw New AppException("404060", XX执行紧急停止轴函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim ini_i As Int16
            ini_i = dmc_emg_stop(0)
            If ini_i <> 0 Then
                'Throw New Exception("执行紧急停止所有轴函数错误！错误信息为：" & ini_i)
                Throw New AppException("404061", XX执行紧急停止所有轴函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_stop(CardNo, axis, 1)
            If ini_i <> 0 Then
                'Throw New Exception("执行CSTP停止轴函数错误！错误信息为：" & ini_i)
                Throw New AppException("404062", XX执行CSTP停止轴函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Return dmc_get_position(CardNo, axis)
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_set_position(CardNo, axis, current_position)
            If ini_i <> 0 Then
                '  Throw New Exception("设置轴脉冲信息错误！错误信息为：" & ini_i)
                Throw New AppException("404063", XX设置轴脉冲信息错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Return dmc_check_done(CardNo, axis)
            'If d5400_read_inbit(0, 9) = 0 Then
            '    Return 1
            'ElseIf d5400_read_inbit(0, 9) = 1 Then
            '    Return 0
            'End If

        Catch ex As Exception
            Throw ex
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

        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Return dmc_axis_io_status(CardNo, axis)
        Catch ex As Exception
            Throw ex
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
            Return 0
        Catch ex As Exception
            Throw ex
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
            Return 0
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            ' ImdStop(axis)
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            '  EmgStop()
            Dim Cont As Byte = 0
A:

            ini_i = dmc_pmove(CardNo, axis, Dist, posi_mode)
            If ini_i <> 0 Then
                'Throw New Exception("执行T型运动曲线函数错误！错误信息为：" & ini_i) 
                Cont += 1
                If Cont > 20 Then
                    Throw New AppException("404064", XX执行T型运动曲线函数错误_错误信息为 & ini_i & XX请重新上电复位)
                End If
                dmc_stop(CardNo, axis, 1)
                Threading.Thread.Sleep(10)
                GoTo A
            End If
            '  Console.WriteLine(axis & "轴运动发送OK！脉冲->" & Dist)
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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

            'd5400_ex_t_pmove(axis, Dist, posi_mode)
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            dmc_stop(CardNo, axis, 1)
            Threading.Thread.Sleep(10)
            ini_i = dmc_pmove(CardNo, axis, Dist, posi_mode)
            If ini_i <> 0 Then
                'Throw New Exception("执行S型运动函数错误！错误信息为：" & ini_i)
                Throw New AppException("404068", XX执行S型运动曲线函数错误_错误信息为 & ini_i & XX请重新上电复位)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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

        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_vmove(CardNo, axis, Dir)
            If ini_i <> 0 Then
                '  Throw New Exception("执行S连续运动函数错误！错误信息为：" & ini_i)
                Throw New AppException("404069", XX执行S连续运动函数错误_错误信息为 & ini_i & XX请重新上电复位)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_vmove(CardNo, axis, Dir)
            If ini_i <> 0 Then
                '  Throw New Exception("执行T连续运动函数错误！错误信息为：" & ini_i)
                Throw New AppException("404070", XX执行T连续运动函数错误_错误信息为 & ini_i & XX请重新上电复位)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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

        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Return dmc_read_current_speed(CardNo, axis)
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_change_speed(CardNo, axis, Curr_Vel, 0.1)
            If ini_i <> 0 Then
                ' Throw New Exception("执行改变速度函数错误！错误信息为：" & ini_i)
                Throw New AppException("404071", XX执行改变速度函数错误_错误信息为 & ini_i & XX请重新上电复位)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_reset_target_position(CardNo, axis, NewPos, 0)
            If ini_i <> 0 Then
                ' Throw New Exception("执行改变速度函数错误！错误信息为：" & ini_i)
                Throw New AppException("404071", XX执行改变速度函数错误_错误信息为 & ini_i & XX请重新上电复位)
            End If
        Catch ex As Exception

        Finally
            mMust.ReleaseMutex()
        End Try
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

        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            Dim Cont As Byte = 0
            'dmc_stop(CardNo, axis, 1)
A:
            Threading.Thread.Sleep(3)
            ini_i = dmc_set_profile(CardNo, axis, Min_Vel, Max_Vel, Tacc, Tdec, Min_Vel)
          
            If ini_i <> 0 Then
                'hrow New Exception("设置T运动速度函数错误！错误信息为：" & ini_i)
                If Cont > 3 Then
                    Throw New AppException("404073", XX设置T运动速度函数错误_错误信息为 & ini_i)
                End If
                Cont += 1
                GoTo A
            End If
            If CardNo = 0 Then
                ini_i = dmc_set_s_profile(CardNo, axis, 0, 0.05)
            Else
                ini_i = dmc_set_s_profile(CardNo, axis, 0, 0.01)
            End If

            If ini_i <> 0 Then
                'Throw New Exception("设置S运动速度函数错误！错误信息为：" & ini_i)
                Throw New AppException("404072", XX设置S运动速度函数错误_错误信息为 & ini_i)
            End If
          
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ' dmc_stop(CardNo, axis, 1)
            Threading.Thread.Sleep(3)
            ini_i = dmc_set_profile(CardNo, axis, Min_Vel, Max_Vel, Tacc, Tdec, Min_Vel)
            If ini_i <> 0 Then
                ' Throw New Exception("执行S运动函数错误！错误信息为：" & ini_i)
                Throw New AppException("304075", XX执行S运动函数错误_错误信息为 & ini_i)
            End If
            ini_i = dmc_set_s_profile(CardNo, axis, 0, Tacc)
            If ini_i <> 0 Then
                ' Throw New Exception("执行S段时间分配函数错误！错误信息为：" & ini_i)
                Throw New AppException("304074", XX执行S段时间分配函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If

            Dim ini_i As Int16
            ini_i = dmc_set_profile(CardNo, axis, Min_Vel, Max_Vel, Tacc, Tdec, Min_Vel)
            If ini_i <> 0 Then
                ' Throw New Exception("执行ST运动函数错误！错误信息为：" & ini_i)
                Throw New AppException("404077", XX执行ST运动函数错误_错误信息为 & ini_i)
            End If
            ini_i = dmc_set_s_profile(CardNo, axis, 0, Tacc)
            If ini_i <> 0 Then
                'Throw New Exception("执行ST段时间分配函数错误！错误信息为：" & ini_i)
                Throw New AppException("404076", XX执行ST段时间分配函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_update_target_position(CardNo, axis, Dist, 0) ' dmc_reset_target_position(CardNo, axis, Dist, 0)
            If ini_i <> 0 Then
                ' Throw New Exception("改变目标位置函数错误！错误信息为：" & ini_i)
                Throw New AppException("404079", XX改变目标位置函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex

        Catch ex As Exception
            Throw ex
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
            'd5400_t_line2(AXIS1, Dist1, AXIS2, Dist2, posi_mode)
        Catch ex As Exception
            Throw ex
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
            'd5400_t_line3(axis, Dist1, Dist2, Dist3, posi_mode)
        Catch ex As Exception
            Throw ex
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

            'dmc_(cardno, Dist1, Dist2, Dist3, Dist4, posi_mode)
        Catch ex As Exception
            Throw ex
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
            'd5400_arc_move(axis, target_pos, cen_pos, arc_dir)
        Catch ex As Exception
            Throw ex
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

        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_set_handwheel_inmode(CardNo, axis, inmode, count_dir, 0)
            If ini_i <> 0 Then
                ' Throw New Exception("设置手轮脉冲计数方式函数错误！错误信息为：" & ini_i)
                Throw New AppException("404080", XX设置手轮脉冲计数方式函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_handwheel_move(CardNo, axis)
            If ini_i <> 0 Then
                ' Throw New Exception("启动手轮运动函数错误！错误信息为：" & ini_i)
                Throw New AppException("404081", XX启动手轮运动函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Return dmc_get_encoder(CardNo, axis)
        Catch ex As Exception
            Throw ex
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
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_set_encoder(CardNo, axis, encoder_value)
            If ini_i <> 0 Then
                ' Throw New Exception("设置编码器位置函数错误！错误信息为：" & ini_i)
                Throw New AppException("404081", XX设置编码器位置函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
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
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_set_counter_inmode(CardNo, axis, mode)
            If ini_i <> 0 Then
                ' Throw New Exception("设置编码器函数函数错误！错误信息为：" & ini_i)
                Throw New AppException("404082", XX设置编码器函数函数错误_错误信息为 & ini_i)
            End If
        Catch ex As AppException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
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

        Catch ex As Exception
            Throw ex
        Finally
            mMust.ReleaseMutex()
        End Try
    End Sub

    ''' <summary>
    ''' 轴IO映射设置
    ''' </summary>
    ''' <param name="CardNo">卡号</param>
    ''' <param name="axis">轴号</param>
    ''' <param name="IoType">映射类型:0-正限位信号，1-负限位信号，2-原点信号，3-急停信号，4-减速停止信号，5-伺服报警信号，6-伺服准备信号，7-伺服到位信号</param>
    ''' <param name="MapIoType">映射对应信号类型：0-正限位输入端口，1-负限位输入端口，2-原点输入端口，3-伺服报警输入端口，4-伺服准备输入端口，5-伺服到位输入端口，6-通用输入端口</param>
    ''' <param name="MapIoIndex">轴映射IO索引号：0-15（MapIoType=6），0-7（MapIoType=0-5）</param>
    ''' <param name="Filter">滤波时间：单位：s</param>
    ''' <remarks></remarks>
    Public Overrides Function axisIOmap(ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal IoType As UInt16, ByVal MapIoType As UInt16, ByVal MapIoIndex As UInt16, ByVal Filter As Double) As Int16
        mMust.WaitOne()
        Try
            Return dmc_set_axis_io_map(CardNo, axis, IoType, MapIoType, MapIoIndex, Filter)
        Catch ex As Exception

        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

    ''' <summary>
    ''' 设置硬件急停模式
    ''' </summary>
    ''' <param name="CardNo">卡号</param>
    ''' <param name="axis">轴号</param>
    ''' <param name="enable">使能：0-禁止，1-允许</param>
    ''' <param name="emg_logic">有效电平：0-低电平，1-高电平</param>
    ''' <returns>错误代码</returns>
    ''' <remarks></remarks>
    Public Overrides Function setEmgModel(ByVal CardNo As UInt16, ByVal axis As UInt16, ByVal enable As UInt16, ByVal emg_logic As UInt16) As UInt16
        mMust.WaitOne()
        Try
            Return dmc_set_emg_mode(CardNo, axis, enable, emg_logic)
        Catch ex As Exception

        Finally
            mMust.ReleaseMutex()
        End Try
    End Function

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
        mMust.WaitOne()
        Try
            Dim CardNo As UShort = 0
            If axis <= 5 Then
                CardNo = 0
            ElseIf axis > 5 And axis <= 11 Then
                CardNo = 1
                axis -= 6
            End If
            Dim ini_i As Int16
            ini_i = dmc_set_ez_mode(CardNo, axis, ez_logic, ez_mode, 0)
            If ini_i <> 0 Then
                ' Throw New Exception("设置编码器函数函数错误！错误信息为：" & ini_i)
                Throw New AppException("404082", "设置EZ信号函数错误！错误信息为：" & ini_i)
            End If
        Catch ex As Exception
        Finally
            mMust.ReleaseMutex()
        End Try

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
