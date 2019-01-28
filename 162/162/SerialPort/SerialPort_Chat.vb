Imports System
Imports System.IO.Ports
Imports System.Threading

Public Class SerialPort_Chat
    Dim _continue As Boolean
    Public _serialPort As SerialPort
    Private SMessage As String

    Public Sub New()
        _serialPort = New SerialPort()
        _continue = False
    End Sub
    Public Function LinkSerialPort(ByVal Port As String, ByVal BaundRate As String, ByVal Parit As String, ByVal StopBit As Integer, ByVal DataBits As String, ByVal handshak As Integer) As Boolean
        '  Dim readThread As Thread = New Thread(AddressOf ReadMessage)
        _serialPort = New SerialPort()
        _serialPort.PortName = Port
        _serialPort.BaudRate = BaundRate
        Select Case Parit
            Case "none"
                _serialPort.Parity = Parity.None
            Case "odd"
                _serialPort.Parity = Parity.Odd
            Case "even"
                _serialPort.Parity = Parity.Even
            Case "mark"
                _serialPort.Parity = Parity.Mark
            Case "Space"
                _serialPort.Parity = Parity.Space
        End Select
        _serialPort.DataBits = DataBits
        _serialPort.StopBits = StopBit
        _serialPort.Handshake = handshak
        Try
            _serialPort.Open()
            SMessage = "串口连接成功！"
        Catch ex As Exception
            MessageBox.Show("连接失败！" & ex.Message)
            Return False
        End Try
        _continue = True
        'readThread.IsBackground = True
        ' readThread.Start()
        Return True
    End Function
    Private Function ReadMessage() As Int32
        Dim byteRead(_serialPort.BytesToRead) As Byte
        If (byteRead.Length <> 9) Then
            Throw New Exception("Encoder data error, data lenght not equal to night")
        End If
        _serialPort.Read(byteRead, 0, byteRead.Length)
        Dim AbsEncoderValue As Int32
        AbsEncoderValue = Convert.ToInt32(byteRead(5) * 256 + byteRead(6) * 65536 + byteRead(3) * 256 + byteRead(4))
        Return AbsEncoderValue
    End Function
    Public Function SendMessage(ByVal id As Int16) As Int32
        Dim AbsEncoderValue As Int32 = Nothing
        If String.IsNullOrEmpty(id) <> True And _serialPort.IsOpen = True Then
            Dim byteBuffer(8) As Byte
            Dim servoId As Byte = 0
            Try
                servoId = Convert.ToByte(id)
            Catch ex As Exception
                Throw New Exception("invalid servo id")
            End Try
            byteBuffer(0) = servoId
            byteBuffer(1) = &H3
            Dim adr = &HB07
            byteBuffer(2) = Convert.ToByte(adr >> 8)
            byteBuffer(3) = Convert.ToByte(Convert.ToByte(adr) / 16 * 10 + Convert.ToByte(adr) Mod 16)
            Dim size As UInt16 = 2
            byteBuffer(4) = Convert.ToByte(size >> 8)
            byteBuffer(5) = Convert.ToByte(size)
            byteBuffer(6) = Convert.ToByte(GenerateCRC(byteBuffer))
            byteBuffer(7) = Convert.ToByte(GenerateCRC(byteBuffer) >> 8)
            Try
                _serialPort.Write(byteBuffer, 0, byteBuffer.Length)
            Catch ex As Exception
                Throw New Exception(_serialPort.PortName + " send failed, detail: " + ex.Message)
            End Try
            Thread.Sleep(100)
            AbsEncoderValue = ReadMessage()
        End If
        Return AbsEncoderValue
    End Function
    Public Sub Close_port()
        _serialPort.Close()
        SMessage = "串口已断开！"
    End Sub
    Public Function GetSMssage()
        Return SMessage
    End Function

    Private Function GenerateCRC(ByVal Buffer As Byte()) As UInt32
        Dim CRC_data As UInt32
        Dim i As Byte
        Dim j As Byte = 0
        CRC_data = &HFFFF
        While (j < Buffer.Length - 2)
            CRC_data ^= Buffer(j)
            For i = 0 To 7
                If ((CRC_data And &H1) = &H1) Then
                    CRC_data >>= 1
                    CRC_data ^= &HA001
                Else
                    CRC_data >>= 1
                End If
            Next
        End While
        Return CRC_data
    End Function
End Class
