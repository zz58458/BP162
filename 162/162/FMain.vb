Imports DSD.MotionLib
Imports System.Threading

Public Class FMain

    'Private Mt As New DSD.MotionLib._601Base
    Dim connectFlag As Boolean = False
    Public IOValue As IOClass = New IOClass()

    Public paramMotion As DSD.MotionLib.absMotionHaw.MotionHawParam = Nothing
    Public mReadParam As DSD.MotionLib.ReadParam
    Public AxisNameList As ArrayList
    Public CardType As String = Nothing
    Public CardCount As Short = 0
    Public Motion As DSD.MotionLib.DMCCard
    Public clsIOWR As DSD.MotionLib.IORW
    Public frm As FMain
    Public Fio As FIO
    Public portchat As SerialPort_Chat '串口类
    Public ANConfig As New DSD.MotionLib.AxisNoConfig() '可配置的轴界面
    Public frmMotionParams As New DSD.MotionLib.frmMotionBasicParams() '运动配置界面
    Public IOFParams As New DSD.MotionLib.IOForm() '添加卡配置界面
    Public slConfig As New SL_Config() 'SL配置界面
    Public modelConfig As New ModelConfig() '点位配置界面
    Public frm3 As New Features_Config() '轴调试界面
    Public SpeedEdit As New SpeedEdit2() '速度配置显示界面
    Public Explore As New Explorer1()

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        frm = Me
        mReadParam = New DSD.MotionLib.ReadParam()
        AxisNameList = mReadParam.Read_All_AxisName() '读取轴的名字
        CardType = DSD.MotionLib.ReadParam.GetCardType '得到卡的类型
        mReadParam.LodeAxisparam(CardCount, paramMotion) '得到卡的数量和轴的高低电平配置(通过传址得到参数)
        connectFlag = False
        If Not connectFlag Then
            Motion = New DSD.MotionLib.DMCCard(paramMotion, AxisNameList.Count, CardType)
            clsIOWR = New DSD.MotionLib.IORW(Motion.BaseFun)

        End If
        'Try
        '    Mt = New _601Base("192.168.0.100".ToString, 2000) '192.168.0.110
        '    connectFlag = False
        '    If Mt.Init() = True Then
        '        connectFlag = True
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("连接失败！", ex.Message)
        'End Try
        ComBox_Axis_Num.SelectedIndex = 0
        Fio = New FIO() 'IO监控界面
        Dim thr As Thread = New Thread(AddressOf Fio.GerIOStatus)
        thr.IsBackground = True
        thr.Start(Motion)
    End Sub
    ''' <summary>
    ''' 初始化函数
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Load_Form()

    End Sub


    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs)
        If connectFlag = True Then
            Dim axisNum As Int32
            axisNum = ComBox_Axis_Num.SelectedIndex
            ' Mt.writeSEVON(axisNum, 0)
        Else
            MessageBox.Show("请连接控制卡！")
        End If
    End Sub

    Private Sub SetMcParam()
        Dim minVel As Double
        Dim maxVel As Double
        Dim tAcc As Double
        Dim tDec As Double
        Dim axisNum As Int32
        axisNum = ComBox_Axis_Num.SelectedIndex
        minVel = Val(txt_min_vel.Text)
        maxVel = Val(txt_max_vel.Text)
        tAcc = Val(txt_acc_time.Text)
        tDec = Val(txt_dec_time.Text)
        Motion.InCard.SetProfile(axisNum, minVel, maxVel, tAcc, tDec)
    End Sub
    Private Sub IO调试ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles IO调试ToolStripMenuItem.Click
        Fio.ShowDialog()
    End Sub

    Private Sub 可配置的轴ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 未配置的轴ToolStripMenuItem.Click
        ANConfig.ShowDialog()
    End Sub

    Private Sub 点位配置ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 点位配置ToolStripMenuItem.Click

    End Sub

    Private Sub 运动配置ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 运动配置ToolStripMenuItem.Click
        frmMotionParams.ShowDialog()
    End Sub

    Private Sub 修改卡参数ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 修改卡参数ToolStripMenuItem.Click
        IOFParams.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim dist As Int32
        Dim axisNum As Int32
        axisNum = ComBox_Axis_Num.SelectedIndex
        dist = Val(TexBox_Axis_Distance.Text)
        SetMcParam()
        Motion.InCard.TPmove(axisNum, dist, 0)
    End Sub

    Private Sub Button10_Click_1(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        'If connectFlag = True Then
        Dim axisNum As Int32
        axisNum = ComBox_Axis_Num.SelectedIndex
        Motion.InCard.writeSEVON(axisNum, 1)
        'Else
        'MessageBox.Show("请连接控制卡！")
        ' End If
    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim dist As Int32
        Dim axisNum As Int32
        axisNum = ComBox_Axis_Num.SelectedIndex
        dist = Val(TexBox_Axis_Distance.Text)
        Motion.InCard.TPmove(axisNum, -dist, 0)
    End Sub

    Private Sub 速度配置ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 速度配置ToolStripMenuItem.Click
        SpeedEdit.ShowDialog()
    End Sub


    Private Sub Button16_Click_1(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        
    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim pos As Int32
        Dim axis As Int32
        axis = ComBox_Axis_Num.SelectedIndex
        pos = Motion.InCard.GetPosition(axis)
        txt_plan_pos.Text = pos.ToString
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        For i As Short = 0 To 11
            Motion.InCard.ImdStop(i)
        Next
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Motion.InCard.Close()
    End Sub

    Private Sub ExplorerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExplorerToolStripMenuItem.Click
        Explore.ShowDialog()
    End Sub

    Private Sub FMain_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.frm1.Visible = True
    End Sub
End Class
