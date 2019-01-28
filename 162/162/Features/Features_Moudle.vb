Public Module Features_Moudle


    Public Axis0 As Features_Moudle.AXIS = New Features_Moudle.AXIS()
    Public Axis1 As Features_Moudle.AXIS = New Features_Moudle.AXIS()
    Public Axis2 As Features_Moudle.AXIS = New Features_Moudle.AXIS()
    Public Axis3 As Features_Moudle.AXIS = New Features_Moudle.AXIS()
    Public Axis4 As Features_Moudle.AXIS = New Features_Moudle.AXIS()
    Public Axis5 As Features_Moudle.AXIS = New Features_Moudle.AXIS()
    Public Axis6 As Features_Moudle.AXIS = New Features_Moudle.AXIS()
    Public Axis7 As Features_Moudle.AXIS = New Features_Moudle.AXIS()
    Public DataGridV As DataGridView
    'Public panel() As Panel = {Features_Config.panel1, Features_Config.panel2, Features_Config.panel3, Features_Config.panel4}
    ' Public groupbox() As GroupBox = {Features_Config.GroupBox9, Features_Config.GroupBox2, Features_Config.GroupBox7}
    Public FeatureFormOpenStatus As Short = -1
    Public Debug As Short = -1
    '选轴控件变量值
    Public CheAxis0_Checked_Value As Boolean
    Public CheAxis1_Checked_Value As Boolean
    Public CheAxis2_Checked_Value As Boolean
    Public CheAxis3_Checked_Value As Boolean
    Public CheAxis4_Checked_Value As Boolean
    Public CheAxis5_Checked_Value As Boolean
    Public CheAxis6_Checked_Value As Boolean
    Public CheAxis7_Checked_Value As Boolean
    'Public Sub SetAxis()
    '    arryAxis.Add(Axis0)
    '    arryAxis.Add(Axis1)
    '    arryAxis.Add(Axis2)
    '    arryAxis.Add(Axis3)
    '    arryAxis.Add(Axis4)
    '    arryAxis.Add(Axis5)
    '    arryAxis.Add(Axis6)
    '    arryAxis.Add(Axis7)
    'End Sub
    '轴结构体
    Public Structure AXIS
        Public Axis As UInt16 '轴号
        Public OutMode As UShort '脉冲输出模式
        '伺服驱动器配置
        Public RadEMGAllow_Prohibit_Value As UShort 'EMG急停信号禁止/允许
        Public RadEMGLow_High_Value As UShort 'EMG急停信号高低电平有效模式
        Public RadINPAllow_Prohibit_Value As UShort 'INP信号禁止/允许
        Public RadINPLow_High_Value As UShort 'INP信号高低电平有效模式
        Public RadALMAllow_Prohibit_Value As UShort 'ALM信号禁止/允许
        Public RadALMLow_High_Value As UShort 'ALM信号高低电平有效模式

        Public RadERCLow_High_Value As UShort 'ERC信号高低电平有效模式
        Public RadEZLow_High_Value As UShort 'EZ信号高低电平有效模式
        Public RadELProhibit_High As UShort 'EL限位使能状态
        Public RadELLow_High As UShort 'EL信号有效电平
        Public RadELStop_Zimm_Fde As UShort 'EL制动方式
        Public RadServoLow_High As UShort '伺服驱动器使能电平模式
        '运动配置
        Public RadOriginLow_High As UShort '原点ORG信号有效电平模式
        ' Public ComOriginDirection As String '回原点方向
        'Public TexAxisRecycle As String '回原点方向
        Public RadOriginSpeed_HighLow As UShort '原点回零速度模式
        Public RadORGZeroReturn As UShort '原点回零模式
        Public RadLatchValue As UShort '原点锁存源模式
        '轴的运动参数
        Public CurrentPosition As Double '轴当前位置
        Public CurrentSpeed As Double '轴当前速度
        Public TexAxisStartSpeed As Double '轴起始速度
        Public TexAxisRunSpeed As Double '轴的运行速度
        Public TexAxisUpSpeedTime As Double '轴的加速度时间
        Public TexAxisDownSpeedTime As Double '轴的减速度时间
        Public TexAxisDisplacement As Double '轴的位移
        Public TexAxisStopSpeed As Double '轴的停止速度
        Public TexAxisTime As Double '轴的运动时间
        Public TexAxisSTime As Double 'S曲线运动时间
        Public TexAxisRunDirection As String '轴运动的方向
        Public TexAxisRecycle As String '轴的循坏模式
        '轴运动模式设置
        Public RadAxisMove As UShort '轴运动模式
        Public RadAxisAbPositionMode As UShort '轴的位移模式
        Public RadAxisCurve As UShort '轴的运动梯形模式/S型模式
        Public RadIsSymmetry As UShort '轴的对称与非对称模式
        Public RadStopMode As UShort '轴的停止模式

    End Structure

    Public Sub SetVariable(ByRef AXIS As Features_Moudle.AXIS)
        '选轴控件变量值赋值
        If FMain.frm3.RadAxis0.Checked = True Then
            AXIS.Axis = 0
        ElseIf FMain.frm3.RadAxis1.Checked = True Then
            AXIS.Axis = 1
        ElseIf FMain.frm3.RadAxis2.Checked = True Then
            AXIS.Axis = 2
        ElseIf FMain.frm3.RadAxis3.Checked = True Then
            AXIS.Axis = 3
        ElseIf FMain.frm3.RadAxis4.Checked = True Then
            AXIS.Axis = 4
        ElseIf FMain.frm3.RadAxis5.Checked = True Then
            AXIS.Axis = 5
        ElseIf FMain.frm3.RadAxis6.Checked = True Then
            AXIS.Axis = 6
        ElseIf FMain.frm3.RadAxis7.Checked = True Then
            AXIS.Axis = 7
        End If
        '脉冲输出模式
        AXIS.OutMode = FMain.frm3.ComOutMode.Text
        'EMG急停信号模式
        AXIS.RadEMGAllow_Prohibit_Value = IIf(FMain.frm3.RadEMGProhibit.Checked = True, 0, 1)
        AXIS.RadEMGLow_High_Value = IIf(FMain.frm3.RadEMGLow.Checked = True, 0, 1)
        'INP信号模式
        AXIS.RadINPAllow_Prohibit_Value = IIf(FMain.frm3.RadINPAllow.Checked = True, 1, 0)
        AXIS.RadINPLow_High_Value = IIf(FMain.frm3.RadINPHigh.Checked = True, 1, 0)
        'ALM信号模式
        AXIS.RadALMAllow_Prohibit_Value = IIf(FMain.frm3.RadALMAllow.Checked = True, 1, 0)
        AXIS.RadALMLow_High_Value = IIf(FMain.frm3.RadALMLow.Checked = True, 0, 1)
        'ERC电平模式
        AXIS.RadERCLow_High_Value = IIf(FMain.frm3.RadERCLow.Checked = True, 0, 1)
        'EZ电平模式
        AXIS.RadEZLow_High_Value = IIf(FMain.frm3.RadEZLow.Checked = True, 0, 1)
        'EL信号的使能状态
        If FMain.frm3.RadELProhibit.Checked = True Then
            AXIS.RadELProhibit_High = 0
        ElseIf FMain.frm3.RadELAllow.Checked = True Then
            AXIS.RadELProhibit_High = 1
        ElseIf FMain.frm3.RadELZProhibit_FAllow.Checked = True Then
            AXIS.RadELProhibit_High = 2
        ElseIf FMain.frm3.RadELZAllow_FProhibit.Checked = True Then
            AXIS.RadELProhibit_High = 3
        End If
        'EL信号有效电平
        If FMain.frm3.RadELLow.Checked = True Then
            AXIS.RadELLow_High = 0
        ElseIf FMain.frm3.RadELHigh.Checked = True Then
            AXIS.RadELLow_High = 1
        ElseIf FMain.frm3.RadELZLow_FHigh.Checked = True Then
            AXIS.RadELLow_High = 2
        ElseIf FMain.frm3.RadELZHigh_FLow.Checked = True Then
            AXIS.RadELLow_High = 3
        End If
        'EL制动方式
        If FMain.frm3.RadELStop_Zimm.Checked = True Then
            AXIS.RadELStop_Zimm_Fde = 0
        ElseIf FMain.frm3.RadELStop_FDeceleration.Checked = True Then
            AXIS.RadELStop_Zimm_Fde = 1
        ElseIf FMain.frm3.RadELStop_ZImm_FDe.Checked = True Then
            AXIS.RadELStop_Zimm_Fde = 2
        ElseIf FMain.frm3.RadELStop_ZDe_FImm.Checked = True Then
            AXIS.RadELStop_Zimm_Fde = 3
        End If
        '伺服驱动器使能状态
        AXIS.RadServoLow_High = IIf(FMain.frm3.RadServoHigh.Checked = True, 1, 0)
        '原点电平模式
        AXIS.RadOriginLow_High = IIf(FMain.frm3.RadOriginHigh.Checked = True, 1, 0)
        '原点方向模式
        AXIS.TexAxisRunDirection = FMain.frm3.TexAxis0RunDirection.Text
        '原点回零速度模式
        AXIS.RadOriginSpeed_HighLow = IIf(FMain.frm3.RadOriginSpeed_High.Checked = True, 1, 0)
        '原点回零模式
        If FMain.frm3.RadORGOneEZ.Checked = True Then
            AXIS.RadORGZeroReturn = 4
        ElseIf FMain.frm3.RadORGOrigin_FEZ.Checked = True Then
            AXIS.RadORGZeroReturn = 3
        ElseIf FMain.frm3.RadORGOrigin_ZEZ.Checked = True Then
            AXIS.RadORGZeroReturn = 5
        ElseIf FMain.frm3.RadORGZeroReturnOne.Checked = True Then
            AXIS.RadORGZeroReturn = 0
        ElseIf FMain.frm3.RadORGZeroReturnOne_Back.Checked = True Then
            AXIS.RadORGZeroReturn = 1
        ElseIf FMain.frm3.RadORGZeroReturnTwo.Checked = True Then
            AXIS.RadORGZeroReturn = 2
        End If
        '原点锁存源模式
        AXIS.RadLatchValue = IIf(FMain.frm3.RadLatchInstruct.Checked = True, 0, 1)
        '轴运动模式
        If FMain.frm3.RadOriginMove.Checked = True Then
            AXIS.RadAxisMove = 0
        ElseIf FMain.frm3.RadAxisSpeedMove.Checked = True Then
            AXIS.RadAxisMove = 1
        ElseIf FMain.frm3.RadAxisMove.Checked = True Then
            AXIS.RadAxisMove = 2
        End If
        AXIS.RadAxisAbPositionMode = IIf(FMain.frm3.RadAxisRelPosition.Checked = True, 0, 1)  '轴的位移模式
        AXIS.RadAxisCurve = IIf(FMain.frm3.RadTCurve.Checked = True, 0, 1) '轴的运动梯形模
        AXIS.RadIsSymmetry = IIf(FMain.frm3.RadSymmetry.Checked = True, 0, 1) '轴的对称与非对
        AXIS.RadStopMode = IIf(FMain.frm3.RadImmStop.Checked = True, 1, 0) '轴的停止模式
    End Sub


    Public Sub GetVriable(ByRef AXIS As Features_Moudle.AXIS)
        '选轴控件变量值赋值
        'If AXIS.Axis = 0 Then
        '    FMain.frm3.RadAxis0.Checked = True
        'ElseIf AXIS.Axis = 1 Then
        '    FMain.frm3.RadAxis1.Checked = True
        'ElseIf AXIS.Axis = 2 Then
        '    FMain.frm3.RadAxis2.Checked = True
        'ElseIf AXIS.Axis = 3 Then
        '    FMain.frm3.RadAxis3.Checked = True
        'ElseIf AXIS.Axis = 4 Then
        '    FMain.frm3.RadAxis4.Checked = True
        'ElseIf AXIS.Axis = 5 Then
        '    FMain.frm3.RadAxis5.Checked = True
        'ElseIf AXIS.Axis = 6 Then
        '    FMain.frm3.RadAxis6.Checked = True
        'ElseIf AXIS.Axis = 7 Then
        '    FMain.frm3.RadAxis7.Checked = True
        'End If
        '脉冲输出模式
        FMain.frm3.ComOutMode.Text = AXIS.OutMode
        'EMG急停信号模式
        If AXIS.RadEMGAllow_Prohibit_Value = 0 Then
            FMain.frm3.RadEMGProhibit.Checked = True
        Else
            FMain.frm3.RadEMGAllow.Checked = Convert.ToBoolean(AXIS.RadEMGAllow_Prohibit_Value)
        End If
        If AXIS.RadEMGLow_High_Value = 0 Then
            FMain.frm3.RadEMGLow.Checked = True
        Else
            FMain.frm3.RadEMGHigh.Checked = Convert.ToBoolean(AXIS.RadEMGLow_High_Value)
        End If
        'INP信号模式
        If AXIS.RadINPAllow_Prohibit_Value = 1 Then
            FMain.frm3.RadINPAllow.Checked = Convert.ToBoolean(AXIS.RadINPAllow_Prohibit_Value)
        Else
            FMain.frm3.RadINPProhibit.Checked = True
        End If
        If AXIS.RadINPLow_High_Value = 1 Then
            FMain.frm3.RadINPHigh.Checked = Convert.ToBoolean(AXIS.RadINPLow_High_Value)
        Else
            FMain.frm3.RadINPLow.Checked = True
        End If
        'ALM信号模式
        If AXIS.RadALMAllow_Prohibit_Value = 1 Then
            FMain.frm3.RadALMAllow.Checked = Convert.ToBoolean(AXIS.RadALMAllow_Prohibit_Value)
        Else
            FMain.frm3.RadALMProhibit.Checked = True
        End If
        If AXIS.RadALMLow_High_Value = 0 Then
            FMain.frm3.RadALMLow.Checked = True
        Else
            FMain.frm3.RadALMHigh.Checked = Convert.ToBoolean(AXIS.RadALMLow_High_Value)
        End If
        'ERC电平模式
        If AXIS.RadERCLow_High_Value = 0 Then
            FMain.frm3.RadERCLow.Checked = True
        Else
            FMain.frm3.RadERCHigh.Checked = Convert.ToBoolean(AXIS.RadERCLow_High_Value)
        End If
        'EZ电平模式
        If AXIS.RadEZLow_High_Value = 0 Then
            FMain.frm3.RadEZLow.Checked = True
        Else
            FMain.frm3.RadEZHigh.Checked = Convert.ToBoolean(AXIS.RadEZLow_High_Value)
        End If

        'EL信号的使能状态
        If AXIS.RadELProhibit_High = 0 Then
            FMain.frm3.RadELProhibit.Checked = True
        ElseIf AXIS.RadELProhibit_High = 1 Then
            FMain.frm3.RadELAllow.Checked = True
        ElseIf AXIS.RadELProhibit_High = 2 Then
            FMain.frm3.RadELZProhibit_FAllow.Checked = True
        ElseIf AXIS.RadELProhibit_High = 3 Then
            FMain.frm3.RadELZAllow_FProhibit.Checked = True
        End If
        'EL信号有效电平
        If AXIS.RadELLow_High = 0 Then
            FMain.frm3.RadELLow.Checked = True
        ElseIf AXIS.RadELLow_High = 1 Then
            FMain.frm3.RadELHigh.Checked = True
        ElseIf AXIS.RadELLow_High = 2 Then
            FMain.frm3.RadELZLow_FHigh.Checked = True
        ElseIf AXIS.RadELLow_High = 3 Then
            FMain.frm3.RadELZHigh_FLow.Checked = True
        End If
        'EL制动方式
        If AXIS.RadELStop_Zimm_Fde = 0 Then
            FMain.frm3.RadELStop_Zimm.Checked = True
        ElseIf AXIS.RadELStop_Zimm_Fde = 1 Then
            FMain.frm3.RadELStop_FDeceleration.Checked = True
        ElseIf AXIS.RadELStop_Zimm_Fde = 2 Then
            FMain.frm3.RadELStop_ZImm_FDe.Checked = True
        ElseIf AXIS.RadELStop_Zimm_Fde = 3 Then
            FMain.frm3.RadELStop_ZDe_FImm.Checked = True
        End If
        '伺服驱动器使能状态
        If AXIS.RadServoLow_High = 1 Then
            FMain.frm3.RadServoHigh.Checked = Convert.ToBoolean(AXIS.RadServoLow_High)
        Else
            FMain.frm3.RadServoLow.Checked = True
        End If
        '原点电平模式
        If AXIS.RadOriginLow_High = 1 Then
            FMain.frm3.RadOriginHigh.Checked = Convert.ToBoolean(AXIS.RadOriginLow_High)
        Else
            FMain.frm3.RadOriginLow.Checked = True
        End If
        '原点方向模式
        FMain.frm3.TexAxis0RunDirection.Text = AXIS.TexAxisRunDirection
        '原点回零速度模式
        If AXIS.RadOriginSpeed_HighLow = 1 Then
            FMain.frm3.RadOriginSpeed_High.Checked = Convert.ToBoolean(AXIS.RadOriginSpeed_HighLow)
        Else
            FMain.frm3.RadOriginSpeed_Low.Checked = True
        End If
        '原点回零模式
        If AXIS.RadORGZeroReturn = 4 Then
            FMain.frm3.RadORGOneEZ.Checked = True
        ElseIf AXIS.RadORGZeroReturn = 3 Then
            FMain.frm3.RadORGOrigin_FEZ.Checked = True
        ElseIf AXIS.RadORGZeroReturn = 5 Then
            FMain.frm3.RadORGOrigin_ZEZ.Checked = True
        ElseIf AXIS.RadORGZeroReturn = 0 Then
            FMain.frm3.RadORGZeroReturnOne.Checked = True
        ElseIf AXIS.RadORGZeroReturn = 1 Then
            FMain.frm3.RadORGZeroReturnOne_Back.Checked = True
        ElseIf AXIS.RadORGZeroReturn = 2 Then
            FMain.frm3.RadORGZeroReturnTwo.Checked = True
        End If
        '原点锁存源模式
        If AXIS.RadLatchValue = 0 Then
            FMain.frm3.RadLatchInstruct.Checked = True
        Else
            FMain.frm3.RadLatchEncoder.Checked = Convert.ToBoolean(AXIS.RadLatchValue)
        End If
        '轴运动模式
        If AXIS.RadAxisMove = 0 Then
            FMain.frm3.RadOriginMove.Checked = True
        ElseIf AXIS.RadAxisMove = 1 Then
            FMain.frm3.RadAxisSpeedMove.Checked = True
        ElseIf AXIS.RadAxisMove = 2 Then
            FMain.frm3.RadAxisMove.Checked = True
        End If

        If AXIS.RadAxisAbPositionMode = 0 Then
            FMain.frm3.RadAxisRelPosition.Checked = True   '轴的位移模式
        Else
            FMain.frm3.RadAxisAbPosition.Checked = Convert.ToBoolean(AXIS.RadAxisAbPositionMode)   '轴的位移模式
        End If

        If AXIS.RadAxisCurve = 0 Then
            FMain.frm3.RadTCurve.Checked = True  '轴的运动梯形模
        Else
            FMain.frm3.RadSCurve.Checked = Convert.ToBoolean(AXIS.RadAxisCurve)  '轴的运动梯形模
        End If

        If AXIS.RadIsSymmetry = 0 Then
            FMain.frm3.RadSymmetry.Checked = True '轴的对称与非对
        Else
            FMain.frm3.RadAsymmetric.Checked = Convert.ToBoolean(AXIS.RadIsSymmetry)  '轴的对称与非对
        End If

        If AXIS.RadStopMode = 1 Then
            FMain.frm3.RadImmStop.Checked = Convert.ToBoolean(AXIS.RadStopMode) '轴的停止模式
        Else
            FMain.frm3.RadDownStop.Checked = True '轴的停止模式
        End If
        'CurrentPosition()
        'CurrentSpeed()
        'TexAxisStartSpeed()
        'TexAxisRunSpeed()
        'TexAxisUpSpeedTime()
        'TexAxisDownSpeedTime()
        'TexAxisDisplacement()
        'TexAxisStopSpeed()
        'TexAxisTime()
        'TexAxisSTime()
        'TexAxisRunDirection()
        'TexAxisRecycle()
    End Sub
End Module
