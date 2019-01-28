Imports System.Threading
Imports DSD.MotionLib

Public Class FIO

    ''' <summary>
    ''' 实时获取卡IO的状态
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GerIOStatus(ByVal InCard As DMCCard)
        Dim n As Int32
        Dim nn As Int32
        Dim j As UShort
        Dim panel As Panel = New Panel()
        '卡一输入口
        While (True)
            Try
            n = InCard.InCard.ReadInport(0)
            For j = 0 To 19
                Dim label As Label = New Label()
                label = FMain.IOValue.GetIN_OUTLabel(j, Me.GroupBox1)
                If label IsNot Nothing Then
                    FMain.IOValue.SetLabel(label, (n And 1) = 1)
                End If
                n = n >> 1
            Next
            '卡二输入口
            n = InCard.InCard.ReadInport(1)
            For j = 0 To 19
                Dim label As Label = New Label()
                label = FMain.IOValue.GetIN_OUTLabel(j, Me.GroupBox4)
                If label IsNot Nothing Then
                    FMain.IOValue.SetLabel(label, (n And 1) = 1)
                End If
                n = n >> 1
            Next
            '卡一输出口
            n = InCard.InCard.ReadOutport(0)
            For j = 0 To 19
                Dim label As Label = New Label()
                label = FMain.IOValue.GetIN_OUTLabel(j, Me.GroupBox2)
                If label IsNot Nothing Then
                    FMain.IOValue.SetLabel(label, (n And 1) = 1)
                End If
                n = n >> 1
            Next
            '卡二输出口
            n = InCard.InCard.ReadOutport(1)
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
                n = InCard.InCard.GetIoStatus(j)
                nn = InCard.InCard.ReadRDY(j)
                FMain.IOValue.SerAxisStatus(GroupBox3.Controls(j), n, nn)
            Next
            '卡二专用口
            For j = 0 To 5
                n = InCard.InCard.GetIoStatus(j + 6)
                nn = InCard.InCard.ReadRDY(j + 6)
                FMain.IOValue.SerAxisStatus(GroupBox6.Controls(j), n, nn)
                Next
            Catch ex As Exception

            End Try
        End While

    End Sub

    Private Sub FIO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub


End Class