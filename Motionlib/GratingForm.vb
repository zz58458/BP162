Public Class GratingForm
    Private ColorFlag As Boolean
   
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ColorFlag = True Then
            ColorFlag = False
            Label2.ForeColor = Drawing.Color.White
        Else
            ColorFlag = True
            Label2.ForeColor = Drawing.Color.Blue
        End If
        Me.Label2.Refresh()

        ThreadFun()
    End Sub


    Public Delegate Function PFunction() As Boolean
    Public Shared sFunction As PFunction

    Private Function AutoColse() As Boolean
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
        Return True
    End Function
    Public Sub ThreadFun()
        Dim Flag As Boolean

        Flag = Me.Invoke(sFunction)
        If Flag = True Then
            Me.Timer1.Enabled = False
            Me.Timer1.Stop()
            Dim PFun As New PFunction(AddressOf AutoColse)
            Me.Invoke(PFun)
        End If
       
    End Sub

End Class