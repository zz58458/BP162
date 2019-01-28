Imports System.Threading

Public Class Features_Config
    Dim Value As UShort
    Dim BOOL As Boolean = False
    Public fileconfig As FileConfig = New FileConfig()
    Public TabControl As TabControl = TabControl1
    Dim Poistion As Integer
    Dim thr As Thread
    ' Dim defrm As Debug = New Debug()
    Dim FilePath As String = "./Config/text1.txt"
    Private Sub Features_Config_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Select Case Features_Moudle.FeatureFormOpenStatus
            Case 0
                TabControl1.SelectedIndex = 0
            Case 1
                TabControl1.SelectedIndex = 1
            Case 2
                TabControl1.SelectedIndex = 2
            Case 3
                TabControl1.SelectedIndex = 3
            Case 4
                TabControl1.SelectedIndex = 4
        End Select
        Features_Moudle.DataGridV = DataGridView1
        DataGridView1.DataSource = fileconfig.LoadFile(FilePath)

        GetConfig_FileOnce()
        'GetConfig_File()
        Card_Init()

        thr = New Thread(AddressOf Poistionn)

        Timer1.Enabled = True
        BOOL = True
        Features_Moudle.FeatureFormOpenStatus = False
        ' defrm.Show()
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ' Features_Control.SetVariable()
        ' ModuleCard.dmc_write_outbit(0, 3, 0)
        ' GetConfig_File()


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim alue() As Boolean = New Boolean() {CheAxis0.Checked, CheAxis1.Checked}
        Dim status As Boolean = New Boolean()

        If alue(0) = True Then
            '  Features_Moudle.SetVariable(Features_Moudle.Axis0)
            If Features_Moudle.Axis0.RadAxisMove = 2 Then
                'FMain.IOValue.GetAxisDataName(Panel6, Panel15, Panel16, Features_Moudle.Axis0)
                Features_Moudle.Axis0.TexAxisRunDirection = TexAxis0RunDirection.Text
                Features_Moudle.Axis0.TexAxisRecycle = TexAxis0Recycle.Checked
                status = FMain.Motion.InCard.Init()
                'FMain.Motion.InCard.TPoint_Motion(Features_Moudle.Axis0)
            End If
        End If
        If alue(1) = True Then
            ' Features_Moudle.SetVariable(Features_Moudle.Axis1)
            If Features_Moudle.Axis0.RadAxisMove = 2 Then
                'FMain.IOValue.GetAxisDataName(Panel7, Panel15, Panel16, Features_Moudle.Axis1)
                Features_Moudle.Axis1.TexAxisRunDirection = TexAxis1RunDirection.Text
                Features_Moudle.Axis1.TexAxisRecycle = TexAxis1Recycle.Checked
                status = FMain.Motion.InCard.Init()
                'FMain.Motion.InCard.TPoint_Motion(Features_Moudle.Axis1)
            End If
        End If
        'If alue(0) = True And alue(1) = True Then
        '    FMain.IOValue.GetAxisDataName(Panel6, Panel15, Panel16, Features_Moudle.Axis0)
        '    Features_Moudle.Axis0.TexAxisRunDirection = TexAxis0RunDirection.Text
        '    Features_Moudle.Axis0.TexAxisRecycle = TexAxis0Recycle.Checked
        '    status = FMain.Motion.InCard.Connect_Card5000(Features_Moudle.Axis0)
        '    FMain.IOValue.GetAxisDataName(Panel7, Panel15, Panel16, Features_Moudle.Axis1)
        '    Features_Moudle.Axis1.TexAxisRunDirection = TexAxis1RunDirection.Text
        '    Features_Moudle.Axis1.TexAxisRecycle = TexAxis1Recycle.Checked
        '    status = FMain.Motion.InCard.Connect_Card5000(Features_Moudle.Axis1)
        '    FMain.Motion.InCard.Multicoor(Features_Moudle.Axis0)
        'End If
        If alue(0) = True Then
            'Features_Moudle.SetVariable(Features_Moudle.Axis0)
            If Features_Moudle.Axis0.RadAxisMove = 0 Then
                'FMain.IOValue.GetAxisDataName(Panel6, Panel15, Panel16, Features_Moudle.Axis0)
                Features_Moudle.Axis0.TexAxisRunDirection = TexAxis0RunDirection.Text
                Features_Moudle.Axis0.TexAxisRecycle = TexAxis0Recycle.Checked
                status = FMain.Motion.InCard.Init()
                ' FMain.Motion.InCard.THome_Origin(Features_Moudle.Axis0)
                thr.Start()
            End If
        End If
        If alue(1) = True Then
            ' Features_Moudle.SetVariable(Features_Moudle.Axis1)
            If Features_Moudle.Axis0.RadAxisMove = 0 Then
                ' FMain.IOValue.GetAxisDataName(Panel7, Panel15, Panel16, Features_Moudle.Axis1)
                Features_Moudle.Axis1.TexAxisRunDirection = TexAxis1RunDirection.Text
                Features_Moudle.Axis1.TexAxisRecycle = TexAxis1Recycle.Checked
                status = FMain.Motion.InCard.Init()
                'FMain.Motion.InCard.THome_Origin(Features_Moudle.Axis1)
                'thr.Start()
            End If
        End If
    End Sub

    Private Sub ButWriteSetValue_Click(sender As System.Object, e As System.EventArgs) Handles ButWriteSetValue.Click

        'Features_Control.SetAxis()
        Value = FMain.IOValue.GetAxis(Me.Panel5)
        Select Case Value
            Case 0
                Features_Moudle.SetVariable(Features_Moudle.Axis0)
                fileconfig.ReConfig_File(Features_Moudle.Axis0, Value)
            Case 1
                Features_Moudle.SetVariable(Features_Moudle.Axis1)
                fileconfig.ReConfig_File(Features_Moudle.Axis1, Value)
            Case 2
                Features_Moudle.SetVariable(Features_Moudle.Axis2)
                fileconfig.ReConfig_File(Features_Moudle.Axis2, Value)
            Case 3
                Features_Moudle.SetVariable(Features_Moudle.Axis3)
                fileconfig.ReConfig_File(Features_Moudle.Axis3, Value)
            Case 4
                Features_Moudle.SetVariable(Features_Moudle.Axis4)
                fileconfig.ReConfig_File(Features_Moudle.Axis4, Value)
            Case 5
                Features_Moudle.SetVariable(Features_Moudle.Axis5)
                fileconfig.ReConfig_File(Features_Moudle.Axis5, Value)
            Case 6
                Features_Moudle.SetVariable(Features_Moudle.Axis6)
                fileconfig.ReConfig_File(Features_Moudle.Axis6, Value)
            Case 7
                Features_Moudle.SetVariable(Features_Moudle.Axis7)
                fileconfig.ReConfig_File(Features_Moudle.Axis7, Value)
        End Select

    End Sub

    Private Sub DataGridView1_RowStateChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView1.RowStateChanged
        Dim i As Int64
        For i = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).HeaderCell.Value = (i + 1).ToString
            Dim dvs As New DataGridViewCellStyle()
            dvs.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Rows(i).HeaderCell.Style = dvs
        Next i
    End Sub
    Private Sub ReConfige_File()
        Select Case Value
            Case 0
                fileconfig.ReConfig_File(Features_Moudle.Axis0, Value)
            Case 1
                fileconfig.ReConfig_File(Features_Moudle.Axis1, Value)
            Case 2
                fileconfig.ReConfig_File(Features_Moudle.Axis2, Value)
            Case 3, Value
                fileconfig.ReConfig_File(Features_Moudle.Axis3, Value)
            Case 4
                fileconfig.ReConfig_File(Features_Moudle.Axis4, Value)
            Case 5
                fileconfig.ReConfig_File(Features_Moudle.Axis5, Value)
            Case 6
                fileconfig.ReConfig_File(Features_Moudle.Axis6, Value)
            Case 7
                fileconfig.ReConfig_File(Features_Moudle.Axis7, Value)
        End Select
    End Sub
    Public Sub GetConfig_File()
        Select Case Value
            Case 0
                fileconfig.GetConfig_File(Features_Moudle.Axis0, 0)
                Features_Moudle.GetVriable(Features_Moudle.Axis0)
            Case 1
                fileconfig.GetConfig_File(Features_Moudle.Axis1, 1)
                Features_Moudle.GetVriable(Features_Moudle.Axis1)
            Case 2
                fileconfig.GetConfig_File(Features_Moudle.Axis2, 2)
                Features_Moudle.GetVriable(Features_Moudle.Axis2)
            Case 3
                fileconfig.GetConfig_File(Features_Moudle.Axis3, 3)
                Features_Moudle.GetVriable(Features_Moudle.Axis3)
            Case 4
                fileconfig.GetConfig_File(Features_Moudle.Axis4, 4)
                Features_Moudle.GetVriable(Features_Moudle.Axis4)
            Case 5
                fileconfig.GetConfig_File(Features_Moudle.Axis5, 5)
                Features_Moudle.GetVriable(Features_Moudle.Axis5)
            Case 6
                fileconfig.GetConfig_File(Features_Moudle.Axis6, 6)
                Features_Moudle.GetVriable(Features_Moudle.Axis6)
            Case 7
                fileconfig.GetConfig_File(Features_Moudle.Axis7, 7)
                Features_Moudle.GetVriable(Features_Moudle.Axis7)
        End Select
    End Sub

    Private Sub RadAxis0_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadAxis0.CheckedChanged
        Value = 0
        If RadAxis0.Checked And BOOL = True Then
            GetConfig_File()
        End If
    End Sub

    Private Sub RadAxis1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadAxis1.CheckedChanged
        Value = 1
        If RadAxis1.Checked Then
            GetConfig_File()
        End If
    End Sub

    Private Sub RadAxis2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadAxis2.CheckedChanged
        Value = 2
        If RadAxis2.Checked Then
            GetConfig_File()
        End If
    End Sub

    Private Sub RadAxis3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadAxis3.CheckedChanged
        Value = 3
        If RadAxis3.Checked Then
            GetConfig_File()
        End If
    End Sub

    Private Sub RadAxis4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadAxis4.CheckedChanged
        Value = 4
        If RadAxis4.Checked Then
            GetConfig_File()
        End If
    End Sub

    Private Sub RadAxis5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadAxis5.CheckedChanged
        Value = 5
        If RadAxis5.Checked Then
            GetConfig_File()
        End If
    End Sub

    Private Sub RadAxis6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadAxis6.CheckedChanged
        Value = 6
        If RadAxis6.Checked Then
            GetConfig_File()
        End If
    End Sub

    Private Sub RadAxis7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadAxis7.CheckedChanged
        Value = 7
        If RadAxis7.Checked Then
            GetConfig_File()
        End If
    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim i As UShort
        For i = 0 To 7
            '  FMain.Motion.InCard.Stopp(i)
        Next
        'ModuleCard.dmc_board_close()
    End Sub
    Public Sub features_display()
        If CheAxis0.Checked = True Then
            ' FMain.Motion.InCard.Display(Features_Moudle.Axis0)

        End If
        If CheAxis1.Checked = True Then
            '  FMain.Motion.InCard.Display(Features_Moudle.Axis1)
        End If
        ' ModuleCard.dmc_board_close()
    End Sub

    Private Sub Features_Config_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        features_display()
    End Sub

    Public Sub Poistionn()
        '' ModuleCard.dmc_write_outbit(0, 0, 0)
        'ModuleCard.dmc_write_outbit(0, 3, 1)
        '' TextBox1.Text = Poistion
        'While (ModuleCard.dmc_get_position(0, 0) <> 10000)

        '    'If Poistion = 10000 Then

        '    ' Poistion = 0
        '    ' End If

        'End While
        'ModuleCard.dmc_write_outbit(0, 3, 0)
        'While (ModuleCard.dmc_check_done(0, Features_Moudle.Axis0.Axis) = 0 Or ModuleCard.dmc_check_done(0, Features_Moudle.Axis1.Axis) = 0) '判断轴运动状态，等待回零运动完成
        '    Application.DoEvents()
        'End While
        'ModuleCard.dmc_set_position(0, Features_Moudle.Axis0.Axis, 0) '设置指定轴的指令脉冲计数器绝对位置为0 
        'ModuleCard.dmc_set_position(0, Features_Moudle.Axis1.Axis, 0) '设置指定轴的指令脉冲计数器绝对位置为0 

    End Sub
    Public Sub Card_Init()
        FMain.IOValue.GetAxisDataName(Panel6, Panel15, Panel16, Features_Moudle.Axis0)
        Features_Moudle.Axis0.TexAxisRunDirection = TexAxis0RunDirection.Text
        Features_Moudle.Axis0.TexAxisRecycle = TexAxis0Recycle.Checked
        FMain.Motion.InCard.Init()
        FMain.IOValue.GetAxisDataName(Panel7, Panel15, Panel16, Features_Moudle.Axis1)
        Features_Moudle.Axis1.TexAxisRunDirection = TexAxis1RunDirection.Text
        Features_Moudle.Axis1.TexAxisRecycle = TexAxis1Recycle.Checked
        FMain.Motion.InCard.Init()
    End Sub
    Public Sub GetAxisDataValue()
        FMain.IOValue.GetAxisDataName(Me.Panel6, Me.Panel15, Me.Panel16, Features_Moudle.Axis0)
        FMain.IOValue.GetAxisDataName(Me.Panel7, Me.Panel15, Me.Panel16, Features_Moudle.Axis1)
    End Sub
    Private Sub GetConfig_FileOnce()

        fileconfig.GetConfig_File(Features_Moudle.Axis0, 0)
        Features_Moudle.GetVriable(Features_Moudle.Axis0)

        fileconfig.GetConfig_File(Features_Moudle.Axis1, 1)
        ' Features_Moudle.GetVriable(Features_Moudle.Axis1)

        fileconfig.GetConfig_File(Features_Moudle.Axis2, 2)
        '  Features_Moudle.GetVriable(Features_Moudle.Axis2)

        fileconfig.GetConfig_File(Features_Moudle.Axis3, 3)
        ' Features_Moudle.GetVriable(Features_Moudle.Axis3)

        fileconfig.GetConfig_File(Features_Moudle.Axis4, 4)
        ' Features_Moudle.GetVriable(Features_Moudle.Axis4)

        fileconfig.GetConfig_File(Features_Moudle.Axis5, 5)
        '  Features_Moudle.GetVriable(Features_Moudle.Axis5)

        fileconfig.GetConfig_File(Features_Moudle.Axis6, 6)
        'Features_Moudle.GetVriable(Features_Moudle.Axis6)

        fileconfig.GetConfig_File(Features_Moudle.Axis7, 7)
        '  Features_Moudle.GetVriable(Features_Moudle.Axis7)

    End Sub

    Private Sub CheAxis0_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheAxis0.CheckedChanged

    End Sub

    Private Sub CheAxis1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheAxis1.CheckedChanged

    End Sub
End Class