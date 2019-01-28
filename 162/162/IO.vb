Public Class IO
    ''' <summary>
    ''' 获取控件对象
    ''' </summary>
    ''' <param name="index">控件数量</param>
    ''' <param name="f">GroupBox控件，传址</param>
    ''' <returns>返回Label控件类型的值</returns>
    ''' <remarks></remarks>
    Public Function GetIN_OUTLabel(ByVal index As Int16, ByRef f As GroupBox)
        Dim _Label As Label = New Label()
        Dim txt As String = index.ToString()
        For Each _Label In f.Controls
            If _Label IsNot Nothing And _Label.Text = txt Then
                Return _Label
            End If
        Next
        Return Nothing
    End Function
    ''' <summary>
    ''' 设置控件，显示IO口状态
    ''' </summary>
    ''' <param name="label">label控件，传址</param>
    ''' <param name="status">IO状态</param>
    ''' <remarks></remarks>
    Public Sub SetLabel(ByRef label As Label, ByVal status As Boolean)
        If label IsNot Nothing Then
            If status Then
                label.BackColor = Color.Red
            Else
                label.BackColor = Color.Green
            End If
        End If
    End Sub
    ''' <summary>
    ''' 显示专用IO口
    ''' </summary>
    ''' <param name="panel">panel控件，传址</param>
    ''' <param name="status">IO状态</param>
    ''' <param name="nn">RDY，IO状态</param>
    ''' <remarks></remarks>
    Public Sub SerAxisStatus(ByRef panel As Panel, ByVal status As UInteger, ByVal nn As UInteger)
        Dim _Label As Label = New Label()
        For Each _Label In panel.Controls
            If _Label IsNot Nothing Then
                If _Label.Text = "Limit+" Then
                    SetLabel(_Label, (status And 1) = 1)
                ElseIf _Label.Text = "Home" Then
                    SetLabel(_Label, (status And Math.Pow(2, 1)) = 1)
                ElseIf _Label.Text = "Limit-" Then
                    SetLabel(_Label, (status And Math.Pow(2, 2)) = 1)
                ElseIf _Label.Text = "RDY" Then
                    SetLabel(_Label, nn = 1)

                End If
            End If
        Next
    End Sub
End Class
