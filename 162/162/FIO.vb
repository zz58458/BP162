Public Class FIO
    ''' <summary>
    ''' 实时获取卡IO的状态
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GerIOStatus()
        Dim n As Int32
        Dim nn As Int32
        Dim j As UShort
        Dim panel As Panel = New Panel()
        '卡一输入口
        n = FMain.Mt.ReadInport(0)
        For j = 0 To 19
            Dim label As Label = New Label()
            label = FMain.IOValue.GetIN_OUTLabel(j, Me.GroupBox1)
            If label IsNot Nothing Then
                FMain.IOValue.SetLabel(label, (n And 1) = 1)
            End If
            n = n >> 1
        Next
        '卡二输入口
        n = FMain.Mt.ReadInport(1)
        For j = 0 To 19
            Dim label As Label = New Label()
            label = FMain.IOValue.GetIN_OUTLabel(j, Me.GroupBox4)
            If label IsNot Nothing Then
                FMain.IOValue.SetLabel(label, (n And 1) = 1)
            End If
            n = n >> 1
        Next
        '卡一输出口
        n = FMain.Mt.ReadOutport(0)
        For j = 0 To 19
            Dim label As Label = New Label()
            label = FMain.IOValue.GetIN_OUTLabel(j, Me.GroupBox2)
            If label IsNot Nothing Then
                FMain.IOValue.SetLabel(label, (n And 1) = 1)
            End If
            n = n >> 1
        Next
        '卡二输出口
        n = FMain.Mt.ReadOutport(0)
        For j = 0 To 19
            Dim label As Label = New Label()
            label = FMain.IOValue.GetIN_OUTLabel(j, Me.GroupBox5)
            If label IsNot Nothing Then
                FMain.IOValue.SetLabel(label, (n And 1) = 1)
            End If
            n = n >> 1
        Next
        '卡一专用口
        For j = 0 To 5
            n = FMain.Mt.GetIoStatus(j)
            nn = FMain.Mt.ReadRDY(j)
            FMain.IOValue.SerAxisStatus(GroupBox3.Controls(j), n, nn)
        Next
        '卡二专用口
        For j = 0 To 5
            n = FMain.Mt.GetIoStatus(j)
            nn = FMain.Mt.ReadRDY(j)
            FMain.IOValue.SerAxisStatus(GroupBox6.Controls(j), n, nn)
        Next
    End Sub
End Class