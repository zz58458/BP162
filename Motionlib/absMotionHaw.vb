Public MustInherit Class absMotionHaw


    '**************************
    '        variables
    '**************************
    Protected mtAxis() As clsAxis

    '**************************************
    '      MustOverrides  Function
    '**************************************
    ''' <summary>
    ''' 初始化硬件及电机并设置相关参数
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Overloads Sub InitHaw()

    ''' <summary>
    ''' 关闭硬件，释放资源
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub CloseHaw()

    ''' <summary>
    ''' 初始化全部轴
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub OrgAllAxis()

    ''' <summary>
    ''' 上电函数
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub SevOnOff()

    ''' <summary>
    ''' 清除伺服报警
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub CleanError()

    ''' <summary>
    ''' 紧急停止所有运动
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub EmgStop()

    ''' <summary>
    ''' 读取IO信号、点位信息
    ''' </summary>
    ''' <param name="HardwareNum ">指定硬件号或单元号,卡从0开始,PLC从100开始</param>
    ''' <param name="bitNum ">指定IO位或所处点位号</param>
    ''' <param name="intAddress">地址：运动控制卡---0表示读input地址，1表示读output地址；PLC--表示地址</param>
    ''' <returns>返回值：0表示低电平；1表示高电平</returns>
    ''' <remarks></remarks>
    Public MustOverride Function ReadIO(ByVal HardwareNum As Short, ByVal bitNum As Short, ByVal intAddress As Short) As Short

    ''' <summary>
    ''' 写入IO信号、点位信息
    ''' </summary>
    ''' <param name="HardwareNum ">指定硬件号或单元号,卡从0开始,PLC从100开始</param>
    ''' <param name="bitNum ">指定IO位或所处点位号</param>
    ''' <param name="Value  ">写入值：0表示低电平；1表示高电平</param>
    ''' <param name="intAddress">地址：运动控制卡---默认为0；PLC--表示地址</param>
    ''' <remarks></remarks>
    Public MustOverride Sub WriteIO(ByVal HardwareNum As Short, ByVal bitNum As Short, ByVal Value As Short, Optional ByVal intAddress As Short = 0)

   

    ''' <summary>
    ''' 2轴直线插补
    ''' </summary>
    ''' <param name="Axis1">轴1</param>
    ''' <param name="Dist1">轴1距离</param>
    ''' <param name="Axis2">轴2</param>
    ''' <param name="Dist2">轴2距离</param>
    ''' <param name="Posi_mode">0－相对位移，1－绝对位移</param>
    ''' <remarks></remarks>
    Public MustOverride Sub Line2(ByVal Axis1 As Short, ByVal Dist1 As Long, ByVal Axis2 As Short, ByVal Dist2 As Long, ByVal Posi_mode As Short)

    ''' <summary>
    ''' 3轴直线插补
    ''' </summary>
    ''' <param name="Axis">轴列表</param>
    ''' <param name="Dist1">轴1距离</param>
    ''' <param name="Dist2">轴2距离</param>
    ''' <param name="Dist3">轴3距离</param>
    ''' <param name="Posi_mode">0－相对位移，1－绝对位移</param>
    ''' <remarks></remarks>
    Public MustOverride Sub Line3(ByVal Axis As ArrayList, ByVal Dist1 As Long, ByVal Dist2 As Long, ByVal Dist3 As Long, ByVal Posi_mode As Short)

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
    Public MustOverride Sub Line4(ByVal card As Short, ByVal Dist1 As Long, ByVal Dist2 As Long, ByVal Dist3 As Long, ByVal Dist4 As Long, ByVal Posi_mode As Short)


    ''' <summary>
    ''' 二轴绝对位置插补，圆弧插补
    ''' </summary>
    ''' <param name="Axis">轴号列表</param>
    ''' <param name="target_pos">目标位置列表（指定圆弧终点）</param>
    ''' <param name="cen_pos">圆心位置列表</param>
    ''' <param name="arc_dir">圆弧方向，0－顺时针,1－逆时针</param>
    ''' <remarks></remarks>
    Public MustOverride Sub ABSLine2(ByVal Axis As ArrayList, ByVal target_pos As ArrayList, ByVal cen_pos As ArrayList, ByVal arc_dir As Short)

    ''' <summary>
    ''' 二轴相对位置插补，圆弧插补
    ''' </summary>
    ''' <param name="Axis">轴号列表</param>
    ''' <param name="target_pos">目标位置列表（指定圆弧终点）</param>
    ''' <param name="cen_pos">圆心位置列表</param>
    ''' <param name="arc_dir">圆弧方向，0－顺时针,1－逆时针</param>
    ''' <remarks></remarks>
    Public MustOverride Sub FACLine2(ByVal Axis As ArrayList, ByVal target_pos As ArrayList, ByVal cen_pos As ArrayList, ByVal arc_dir As Short)


    ''' <summary>
    ''' 写入数据至硬件数据存储区
    ''' </summary>
    ''' <param name="strUnitNum">单元号码或硬件号码</param>
    ''' <param name="strHeadCode">模式代码(读，写等)</param>
    ''' <param name="intAddress">储存地址</param>
    ''' <param name="intData">储存内容</param>
    ''' <param name="timeDelay">延时时间</param>
    ''' <remarks></remarks>
    Public MustOverride Sub WriteDM(ByVal strUnitNum As String, ByVal strHeadCode As String, _
    ByVal intAddress As String, ByVal intData As String, Optional ByVal timeDelay As Integer = 100)

    ''' <summary>
    ''' 写入数据至硬件数据存储区
    ''' </summary>
    ''' <param name="strUnitNum">单元号码或硬件号码</param>
    ''' <param name="strHeadCode">模式代码(读，写等)</param>
    ''' <param name="intAddress">储存地址</param>
    ''' <param name="intData">储存内容</param>
    ''' <param name="timeDelay">延时时间</param>
    ''' <returns>返回读取数据</returns>
    ''' <remarks></remarks>
    Public MustOverride Function ReadDM(ByVal strUnitNum As String, ByVal strHeadCode As String, _
    ByVal intAddress As String, ByVal intData As String, Optional ByVal timeDelay As Integer = 100) As String


    ''' <summary>
    ''' 属性：运动轴
    ''' </summary>
    ''' <value>Null</value>
    ''' <returns>返回对象的所有运动轴</returns>
    ''' <remarks></remarks>
    Public MustOverride ReadOnly Property Axis() As absMtAxis()

    Public Overridable ReadOnly Property BaseFun As BaseFunction
        Get
            Return Nothing
        End Get
    End Property


    Public Structure MotionHawParam
        Public Type As Byte
        Public MotionLable As String
        Public AxisParams() As absMtAxis.AxisParam
        Private Name As String
        Private AxisNum As Byte

        Public Sub Save(ByVal Path As String)
            Try
                Path = Path & ".mtq"
                WriteIni("MotionType", Type, Path)
                WriteIni("MotionLable", MotionLable, Path)
                If Name = String.Empty Then
                    Name = "AxisParameters"
                End If
                WriteIni("AxisName", Name, Path)
                If AxisParams IsNot Nothing Then
                    If AxisParams.Length <> 0 Then
                        WriteIni("AxisNum", AxisParams.Length, Path)
                        Dim strAxisPath As String = Path.Substring(0, Path.LastIndexOf("\")) & "\" & Name
                        For i As Byte = 0 To AxisParams.Length - 1
                            AxisParams(i).Save(strAxisPath & i.ToString)
                        Next
                    Else
                        WriteIni("AxisNum", "0", Path)
                    End If
                Else
                    WriteIni("AxisNum", "0", Path)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Load(ByVal Path As String)
            Try
                Path = Path & ".mtq"
                Type = CByte(ReadIni("MotionType", 0, Path))
                MotionLable = ReadIni("MotionLable", "5400", Path)
                Name = ReadIni("AxisName", "AxisParameters", Path)
                AxisNum = CByte(ReadIni("AxisNum", 0, Path))
                If AxisNum <> 0 Then
                    ReDim AxisParams(AxisNum - 1)
                    Dim strAxisPath As String = Path.Substring(0, Path.LastIndexOf("\")) & "\" & Name
                    For i As Byte = 0 To AxisParams.Length - 1
                        AxisParams(i).load(strAxisPath & i.ToString)
                    Next
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Structure

End Class
