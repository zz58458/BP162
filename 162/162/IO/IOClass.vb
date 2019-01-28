Imports System.Windows.Forms
Public Class IOClass
    ''' <summary>
    ''' 获取控件对象
    ''' </summary>
    ''' <param name="index">控件数量</param>
    ''' <param name="f">GroupBox控件，传址</param>
    ''' <returns>返回Label控件类型的值</returns>
    ''' <remarks></remarks>
    Public Function GetIN_OUTLabel(ByVal index As Int16, ByRef f As GroupBox)
        'Dim _Label As Label = New Label()
        Dim txt As String = index.ToString()
        Try
            For Each _Label As Control In f.Controls
                If _Label.GetType().ToString() = "System.Windows.Forms.Label" Then
                    If _Label IsNot Nothing And _Label.Text = txt Then
                        Return _Label
                    End If
                End If
            Next
        Catch ex As Exception
            Return Nothing
        End Try
       
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
    Public Sub SerAxisStatus(ByRef panel As Panel, ByVal status As UInteger, ByVal nn As Integer)
        ' Dim _Label As Label = New Label()
        Try
            For Each _Label As Control In panel.Controls
                If _Label.GetType().ToString() = "System.Windows.Forms.Label" Then
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
                End If
            Next
        Catch ex As Exception
        End Try
       
    End Sub

    Public Function GetAxis(ByVal panel As Panel) As UShort
        Dim Axis As UShort = New UShort()

        Dim _RadAxis As RadioButton = New RadioButton()

        For Each _RadAxis In panel.Controls
            If _RadAxis IsNot Nothing Then
                If _RadAxis.Name.Chars(7) = "0" And _RadAxis.Checked Then
                    Axis = 0
                ElseIf _RadAxis.Name.Chars(7) = "1" And _RadAxis.Checked Then
                    Axis = 1
                ElseIf _RadAxis.Name.Chars(7) = "2" And _RadAxis.Checked Then
                    Axis = 2
                ElseIf _RadAxis.Name.Chars(7) = "3" And _RadAxis.Checked Then
                    Axis = 3
                ElseIf _RadAxis.Name.Chars(7) = "4" And _RadAxis.Checked Then
                    Axis = 4
                ElseIf _RadAxis.Name.Chars(7) = "5" And _RadAxis.Checked Then
                    Axis = 5
                ElseIf _RadAxis.Name.Chars(7) = "6" And _RadAxis.Checked Then
                    Axis = 6
                ElseIf _RadAxis.Name.Chars(7) = "7" And _RadAxis.Checked Then
                    Axis = 7
                Else

                End If


            End If
        Next

        Return Axis
    End Function

    Public Sub GetAxisDataName(ByRef panel As Panel, ByRef panel1 As Panel, ByRef panel2 As Panel, ByRef Axis As Features_Moudle.AXIS)
        Dim _TextBook As TextBox = New TextBox()
        For Each _TextBook In panel.Controls
            If _TextBook IsNot Nothing Then
                If _TextBook.Name.Chars(8) = "0" Then
                    Axis.CurrentPosition = _TextBook.Text.ToString()
                ElseIf _TextBook.Name.Chars(8) = "1" Then
                    Axis.CurrentSpeed = _TextBook.Text.ToString()
                ElseIf _TextBook.Name.Chars(8) = "2" Then
                    Axis.TexAxisStartSpeed = _TextBook.Text.ToString()
                ElseIf _TextBook.Name.Chars(8) = "3" Then
                    Axis.TexAxisRunSpeed = _TextBook.Text.ToString()
                ElseIf _TextBook.Name.Chars(8) = "4" Then
                    Axis.TexAxisUpSpeedTime = _TextBook.Text.ToString()
                ElseIf _TextBook.Name.Chars(8) = "5" Then
                    Axis.TexAxisDownSpeedTime = _TextBook.Text.ToString()
                ElseIf _TextBook.Name.Chars(8) = "6" Then
                    Axis.TexAxisSTime = _TextBook.Text.ToString()
                ElseIf _TextBook.Name.Chars(8) = "7" Then
                    Axis.TexAxisDisplacement = _TextBook.Text.ToString()
                ElseIf _TextBook.Name.Chars(8) = "8" Then
                    Axis.TexAxisTime = _TextBook.Text.ToString()
                ElseIf _TextBook.Name.Chars(8) = "9" Then
                    Axis.TexAxisStopSpeed = _TextBook.Text.ToString()
                End If
            End If
        Next
        'For Each _ComboxBox In panel1.Controls
        '    If _ComboxBox IsNot Nothing Then
        '        If _ComboxBox.Name = "TexAxis0RunDirection" And _ComboxBox.Text <> "" Then
        '            Axis.TexAxisRunDirection = _ComboxBox.Text.ToString()
        '        ElseIf _ComboxBox.Name = "TexAxis1RunDirection" And _ComboxBox.Text <> "" Then
        '            Axis.TexAxisRunDirection = _ComboxBox.Text.ToString()
        '        End If
        '    End If
        'Next
        'For Each _CheckBox In panel2.Controls
        '    If _CheckBox IsNot Nothing Then
        '        If _CheckBox.Name.Chars(7) = "0" And _CheckBox.Checked = True Then
        '            Axis.TexAxisRecycle = _CheckBox.Text.ToString()
        '        End If
        '    End If
        'Next
    End Sub
End Class
