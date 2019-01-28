Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Imports System.Timers
Imports System.IO

Public Class Form1

    Dim Mt As _601Base
    Dim thread As Thread

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles connect.Click
        Dim flag As Boolean
        If Mt.Init() = 0 Then
            flag = True

        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Mt.Close()
    End Sub

    Private Function cardChk() As Boolean
        Return True
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Mt.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combox_axis_num.SelectedIndex = 0
        ComboBox1.SelectedIndex = 0
        in_num.SelectedIndex = 0
        out_num.SelectedIndex = 0
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Public Const HM_SIG_STAT_MASK = 1
    Public Const FL_SIG_STAT_MASK = 64
    Public Const RL_SIG_STAT_MASK = 4096

    Function Test() As Boolean
        Return True
    End Function
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Dim s As UInt32
        s = Test()
    End Sub
    Sub threadSub()
        While 1
            ' Mt.SetOutputSig(0, 10, 0, True)
            Threading.Thread.Sleep(100)
            'Mt.SetOutputSig(0, 10, 1, True)
            Threading.Thread.Sleep(100)
        End While
    End Sub
    Sub Test(ByVal s As String, ByRef str As String)
        str = s
    End Sub

    Sub Test1(ByVal index As Integer)
        Dim s As String
        s = index
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        'Mt.SetOutputSig(0, 10, 0, True)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        ' Mt.SetOutputSig(0, 10, 1, True)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Mt.writeSEVON(5, 1)
        Mt.WriteOutbit(0, 2, 0)

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Mt.writeSEVON(5, 0)
        Mt.WriteOutbit(0, 2, 1)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim axisNum As Int32
        axisNum = combox_axis_num.SelectedIndex
        Mt.writeSEVON(axisNum, 1)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim dist As Int32
        Dim axisNum As Int32
        axisNum = combox_axis_num.SelectedIndex
        dist = Val(txt_axis_dist.Text)
        SetMcParam()
        Mt.TPmove(axisNum, dist, 0)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim dist As Int32
        Dim axisNum As Int32
        axisNum = combox_axis_num.SelectedIndex
        dist = Val(txt_axis_dist.Text)
        SetMcParam()
        Mt.TPmove(axisNum, -dist, 0)
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Dim axisNum As Int32
        axisNum = combox_axis_num.SelectedIndex
        Mt.writeSEVON(axisNum, 0)
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        Dim index As Int32
        index = ComboBox1.SelectedIndex
        If index >= 0 Then
            Mt.WriteOutbit(0, index, 0)
        End If
    End Sub

    Private Sub SetMcParam()
        Dim minVel As Double
        Dim maxVel As Double
        Dim tAcc As Double
        Dim tDec As Double
        Dim axisNum As Int32
        axisNum = combox_axis_num.SelectedIndex
        minVel = Val(txt_min_vel.Text)
        maxVel = Val(txt_max_vel.Text)
        tAcc = Val(txt_acc_time.Text)
        tDec = Val(txt_dec_time.Text)
        Mt.SetProfile(axisNum, minVel, maxVel, tAcc, tDec)
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim index As Int32
        index = ComboBox1.SelectedIndex
        If index >= 0 Then
            Mt.WriteOutbit(0, index, 1)
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim InSig As UInt32
        Dim bitNum As Int32
        bitNum = in_num.SelectedIndex
        InSig = Mt.ReadInbit(0, bitNum)
        txt_in.Text = InSig.ToString
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim OutSig As UInt32
        Dim num As Int32
        num = out_num.SelectedIndex
        OutSig = Mt.ReadOutbit(0, num)
        txt_out.Text = OutSig.ToString
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim pos As Int32
        Dim axis As Int32
        axis = combox_axis_num.SelectedIndex
        pos = Mt.GetEncoder(axis)
        txt_enc_pos.Text = pos.ToString
    End Sub
    Private Sub btn_jog_p_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_jog_p.MouseDown
        Dim axis As Int32
        axis = combox_axis_num.SelectedIndex
        SetMcParam()
        Mt.TVmove(axis, 1)
    End Sub
    Private Sub btn_jog_p_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_jog_p.MouseUp
        'Dim axis As Int32
        'axis = combox_axis_num.SelectedIndex
        'Mt.DecelStop(axis, 0)
    End Sub

    Private Sub btn_jog_n_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_jog_n.MouseUp
        'Dim axis As Int32
        'axis = combox_axis_num.SelectedIndex
        'Mt.DecelStop(axis, 0)
    End Sub

    Private Sub btn_jog_n_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_jog_n.MouseDown
        Dim axis As Int32
        axis = combox_axis_num.SelectedIndex
        SetMcParam()
        Mt.TVmove(axis, 0)
    End Sub

    Private Sub btn_home_Click(sender As Object, e As EventArgs) Handles btn_axis_home.Click
        Dim axis As Int32
        Dim mode As Int32
        axis = combox_axis_num.SelectedIndex
        mode = cmbox_home_mode.SelectedIndex
        Mt.HomeMode(axis, mode, 0)
        Mt.HomeMove(axis, 2, 1)
    End Sub

    Private Sub btn_emg_Click(sender As Object, e As EventArgs) Handles btn_stop_emg.Click
        Dim axis As Int32
        axis = combox_axis_num.SelectedIndex
        Mt.ImdStop(axis)
    End Sub

    Private Sub btn_stop_dec_Click(sender As Object, e As EventArgs)
        Dim axis As Int32
        axis = combox_axis_num.SelectedIndex
        Mt.DecelStop(axis, 0)
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pos As Int32
        Dim axis As Int32
        axis = combox_axis_num.SelectedIndex
        pos = Mt.GetPosition(axis)
        txt_plan_pos.Text = pos.ToString
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim num As Integer
        num = 0
        While True
            num = num + 1
            Thread.Sleep(100)
        End While
    End Sub

    Private Sub btn_axis_acc_Click(sender As Object, e As EventArgs) Handles btn_axis_acc.Click
        Dim curSpeed As Int32
        Dim axis As Int32
        axis = combox_axis_num.SelectedIndex
        curSpeed = Mt.ReadCurrentSpeed(axis)
        If curSpeed < 0 Then
            curSpeed = -curSpeed
        End If
        curSpeed = curSpeed + 5000
        Mt.ChangeSpeed(axis, curSpeed)
    End Sub

    Private Sub btn_axis_dec_Click(sender As Object, e As EventArgs) Handles btn_axis_dec.Click
        Dim curSpeed As Int32
        Dim axis As Int32
        axis = combox_axis_num.SelectedIndex
        curSpeed = Mt.ReadCurrentSpeed(axis)
        If curSpeed < 0 Then
            curSpeed = -curSpeed
        End If
        If curSpeed > 5000 Then
            curSpeed = curSpeed - 5000
            Mt.ChangeSpeed(axis, curSpeed)
        End If

    End Sub

    Private Sub btn_stop_dec_Click_1(sender As Object, e As EventArgs) Handles btn_stop_dec.Click
        Dim axis As Int32
        axis = combox_axis_num.SelectedIndex
        Mt.DecelStop(axis, 0)
    End Sub

    Private Sub btn_set_target_Click(sender As Object, e As EventArgs) Handles btn_set_target.Click
        Dim axis As Int32
        Dim pos As Int32
        pos = Val(txt_new_pos.Text)
        axis = combox_axis_num.SelectedIndex
        Mt.ResetTargetPos(axis, pos)
    End Sub

    Private Sub btn_card_init_Click(sender As Object, e As EventArgs) Handles btn_card_init.Click
        Mt = New _601Base("192.168.0.100".ToString, 2000)
    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
        Dim axis As Int32
        axis = combox_axis_num.SelectedIndex
        Mt.SetPosition(axis, 0)
    End Sub

    Private Sub btn_ready_Click(sender As Object, e As EventArgs) Handles btn_ready.Click

    End Sub

    Private Sub btn_inpos_Click(sender As Object, e As EventArgs) Handles btn_inpos.Click

    End Sub

    Private Sub btn_alarm_Click(sender As Object, e As EventArgs) Handles btn_alarm.Click

    End Sub
End Class
