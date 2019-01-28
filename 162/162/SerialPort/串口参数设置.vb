Public Class Form2

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If FMain.portchat.LinkSerialPort(ComboBox1.Text, ComboBox2.Text, ComboBox3.Text, Convert.ToUInt16(ComboBox4.Text), ComboBox5.Text, Convert.ToUInt16(ComboBox6.Text)) = True Then
            Me.Close()
        End If
    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class