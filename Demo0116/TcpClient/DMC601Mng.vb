﻿Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Imports System.Timers

Public Class StateObject
    Public workSocket As Socket = Nothing
    Public Const BufferSize As Integer = 256
    Public buffer(BufferSize) As Byte
    Public sb As New StringBuilder
End Class
Public Class DMC601Mng

    Private client As Socket
    Private connectFlag As Boolean
    Private cmdState As New Dictionary(Of String, Integer)
    Private critMutex As New ManualResetEvent(False)
    Private ipAddres As String
    Private portNum As Integer
    Public m_gwAddr As Integer
    Public m_inputSig As Integer
    Public m_hmState As Integer
    Public m_hardSig As Integer
    Public m_outPutSig As Integer
    Public m_macAddr(6) As Char
    Public m_hmDir(6) As Boolean
    Public m_planPos(6) As Single
    Public m_realPos(6) As Int32
    Public m_plsType(6) As Integer
    Public m_exInPutSig(6) As Integer
    Public m_exOutPutSig(6) As Integer
    Public m_axisState(6) As Int32
    Public m_axisCurSpeed(6) As Double
    Public m_axisTargetPos(6) As Double
    Public m_inpos(6) As Int32
    Public m_ready(6) As Int32
    Public m_alarm(6) As Int32
    Public m_servo(6) As Int32
    Public Shared Sub msleep(ByVal time As Integer)
        Threading.Thread.Sleep(time)
    End Sub
    Sub New()

    End Sub

    Private Sub Lock()
        critMutex.WaitOne()
        critMutex.Reset()
    End Sub

    Private Sub UnLock()
        critMutex.Set()
    End Sub

    Private Sub SendCommand(ByVal cmdStr As String)
        SendMsg(cmdStr)
    End Sub
    Private Sub SendCmdRecord(ByVal cmdName As String)
        If CmdFind(cmdName) > 0 Then
            Lock()
            cmdState(cmdName) = 0
            UnLock()
        Else
            Lock()
            cmdState.Add(cmdName, 0)
            UnLock()
        End If
    End Sub
    Public Sub RecvCmdRecordState(ByVal cmdName As String, ByVal state As Integer)
        If CmdFind(cmdName) > 0 Then
            Lock()
            cmdState(cmdName) = state
            UnLock()
        End If
    End Sub
    Public Function CheckCndState(ByVal cmdName As String) As Integer
        If CmdFind(cmdName) > 0 Then
            Return cmdState.Item(cmdName)
        Else
            Return 0
        End If
    End Function
    Private Function CmdFind(ByVal cmdName As String) As Integer
        Dim ret As Integer
        If cmdState.ContainsKey(cmdName) = True Then
            ret = 1
        Else
            ret = -1
        End If
        Return ret
    End Function
    Private Function IsConnect() As Boolean
        IsConnect = connectFlag
    End Function
    Private Sub Disconnect()
        If connectFlag = True Then
            connectFlag = False
            client.Shutdown(SocketShutdown.Both)
            client.Close()
            Threading.Thread.Sleep(10)
            End If

    End Sub
    Private Function Connect() As Boolean
        If connectFlag = True Then
            Return True
        End If
        Dim ipAddr As IPAddress
        ipAddr = IPAddress.Parse(ipAddres)
        Dim remoteEP As IPEndPoint = New IPEndPoint(ipAddr, portNum)
        client = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Try
            client.BeginConnect(remoteEP, New AsyncCallback(AddressOf ConnectCallback), client)
        Catch ex As Exception
            connectFlag = False
            If client.Connected = True Then
                client.Shutdown(SocketShutdown.Both)
            End If
            client.Close()
            MsgBox("连接失败:" & ex.Message, vbOKOnly, "连接异常")
        End Try
        Return True
    End Function
    Private Sub ConnectCallback(ByVal ar As IAsyncResult)
        Try
            Dim client As Socket = CType(ar.AsyncState, Socket)
            client.EndConnect(ar)
            Dim state As New StateObject
            state.workSocket = client
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)
            connectFlag = True
        Catch ex As Exception
            connectFlag = False
            If client.Connected = True Then
                client.Shutdown(SocketShutdown.Both)
            End If
            client.Close()
            MsgBox("连接失败:" & ex.Message, vbOKOnly, "连接异常")
        End Try
    End Sub
    Private Sub ReceiveCallback(ByVal ar As IAsyncResult)

        If connectFlag = False Then
            Return
        End If

        Try
            Dim content As String = String.Empty
            Dim state As StateObject = CType(ar.AsyncState, StateObject)
            Dim handler As Socket = state.workSocket
            Dim bytesRead As Integer = handler.EndReceive(ar)
            If bytesRead > 2 Then
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead))
                content = state.sb.ToString
                CmdParse(content)
                state.sb.Clear()
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)
            Else
                connectFlag = False
                If client.Connected = True Then
                    client.Shutdown(SocketShutdown.Both)
                End If
                client.Close()
                Connect()
            End If

        Catch ex As Exception
            connectFlag = False
            If client.Connected = True Then
                client.Shutdown(SocketShutdown.Both)
            End If
            client.Close()
            Connect()
        End Try
    End Sub

    Private Sub SendMsg(ByVal msg As String)

        If client.Poll(1000, SelectMode.SelectRead) = True Then
            Dim i As Int16
            i = 100
        End If
        If client.Connected = True Then
            If connectFlag = True Then
                Lock()
                Send(client, msg.ToString())
                UnLock()
            End If
        End If
    End Sub
    Private Sub Send(ByVal client As Socket, ByVal data As String)

        Dim byteData As Byte() = Encoding.ASCII.GetBytes(data)
        Try
            client.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendCallback), client)
        Catch ex As Exception
            connectFlag = False
            If client.Connected = True Then
                client.Shutdown(SocketShutdown.Both)
            End If
            client.Close()
            Connect()
        End Try
    End Sub
    Private Sub SendCallback(ByVal ar As IAsyncResult)
        Dim client As Socket = CType(ar.AsyncState, Socket)
        Dim bytesSent As Integer = client.EndSend(ar)
    End Sub

    Private Sub CmdParse(ByVal cmdStr As String)

        Dim cmdBuf() As Byte
        cmdBuf = Encoding.ASCII.GetBytes(cmdStr)
        Dim cmd As New StringBuilder
        cmd.Clear()

        If cmdBuf.Length < 2 Then
            Return
        End If

        For i = 0 To cmdBuf.Length - 1
            If cmdBuf(i) = Asc(vbCr) Then
                CmdMng(cmd.ToString)
                cmd.Clear()
            Else
                cmd.Append(Encoding.ASCII.GetString(cmdBuf, i, 1))
            End If
        Next
        cmd.Clear()
    End Sub
    Private Sub CmdMng(ByVal cmdStr As String)

        Dim vStr() As String
        vStr = Split(cmdStr, ",")

        If StrComp(vStr(1), "GET_INPUT") = 0 Then
            m_inputSig = vStr(2)
        ElseIf StrComp(vStr(1), "GET_OUT") = 0 Then
            m_outPutSig = vStr(2)
        ElseIf StrComp(vStr(1), "GET_POST") = 0 Then
            m_planPos(0) = vStr(2)
            m_planPos(1) = vStr(3)
            m_planPos(2) = vStr(4)
            m_planPos(3) = vStr(5)
            m_planPos(4) = vStr(6)
            m_planPos(5) = vStr(7)
        ElseIf StrComp(vStr(1), "GET_EXINPUT") = 0 Then
            Dim devNum As Int32
            devNum = vStr(2)
            m_exInPutSig(devNum) = vStr(3)
        ElseIf StrComp(vStr(1), "GET_EXOUTPUT") = 0 Then
            Dim devNum As Int32
            devNum = vStr(2)
            m_exOutPutSig(devNum) = vStr(3)
        ElseIf StrComp(vStr(1), "HARDSIG") = 0 Then
            m_hardSig = vStr(2)
        ElseIf StrComp(vStr(1), "HOMESTATE") = 0 Then
            m_hmState = vStr(2)
        ElseIf StrComp(vStr(1), "GET_ENC") = 0 Then
            m_realPos(0) = vStr(2)
            m_realPos(1) = vStr(3)
            m_realPos(2) = vStr(4)
            m_realPos(3) = vStr(5)
            m_realPos(4) = vStr(6)
            m_realPos(5) = vStr(7)
        ElseIf StrComp(vStr(1), "CHK_DONE") = 0 Then
            Dim axisNum As Int32
            axisNum = vStr(2)
            m_axisState(axisNum) = vStr(3)
        ElseIf StrComp(vStr(1), "GET_SPEED") = 0 Then
            Dim axisNum As Int32
            axisNum = vStr(2)
            m_axisCurSpeed(axisNum) = vStr(3)
        ElseIf StrComp(vStr(1), "GET_TARGET") = 0 Then
            Dim axisNum As Int32
            axisNum = vStr(2)
            m_axisTargetPos(axisNum) = vStr(3)
        ElseIf StrComp(vStr(1), "GET_SERVOR") = 0 Then
            Dim axisNum As Int32
            axisNum = vStr(2)
            m_servo(axisNum) = vStr(3)
        ElseIf StrComp(vStr(1), "GET_READY") = 0 Then
            Dim axisNum As Int32
            axisNum = vStr(2)
            m_ready(axisNum) = vStr(3)
        ElseIf StrComp(vStr(1), "GET_ALARM") = 0 Then
            Dim axisNum As Int32
            axisNum = vStr(2)
            m_alarm(axisNum) = vStr(3)
        ElseIf StrComp(vStr(1), "GET_INPOS") = 0 Then
            Dim axisNum As Int32
            axisNum = vStr(2)
            m_inpos(axisNum) = vStr(3)
        ElseIf StrComp(vStr(1), "GET_CONFIG") = 0 Then
            If StrComp(vStr(2), "HMDIR") = 0 Then
                Dim subIndex As Integer
                subIndex = vStr(3)
                If StrComp(vStr(4), "POSITIVE") = 0 Then
                    m_hmDir(subIndex) = True
                Else
                    m_hmDir(subIndex) = False
                End If
            End If
        End If

        Dim cmdName As String
        Dim len As Integer
        len = vStr.Length
        cmdName = vStr(1) + vStr(0)
        If StrComp(vStr(len - 1), "BUSY") = 0 Then
            RecvCmdRecordState(cmdName, CMDSTATEINDEX.MOTION_CMD_STATE_BUSY)
        ElseIf StrComp(vStr(len - 1), "ACK") = 0 Then
            RecvCmdRecordState(cmdName, CMDSTATEINDEX.MOTION_CMD_STATE_ACK)
        ElseIf StrComp(vStr(len - 1), "FIN") = 0 Then
            RecvCmdRecordState(cmdName, CMDSTATEINDEX.MOTION_CMD_STATE_FIN)
        End If
    End Sub
    Public Enum CMDSTATEINDEX
        MOTION_CMD_STATE_NONE = 0
        MOTION_CMD_STATE_BUSY
        MOTION_CMD_STATE_ACK
        MOTION_CMD_STATE_FIN
    End Enum
    Private Function IsCmdFin(ByVal cmdMsg As String) As Boolean
        Dim state As Integer
        state = CheckCndState(cmdMsg)
        If CMDSTATEINDEX.MOTION_CMD_STATE_FIN = state Then
            Return True
        End If
        Return False
    End Function
    Private Function IsCmdResp(ByVal cmdMsg As String) As Boolean
        Dim state As Integer
        state = CheckCndState(cmdMsg)
        If CMDSTATEINDEX.MOTION_CMD_STATE_NONE <> state Then
            Return True
        End If
        Return False
    End Function
    Private Function IsCmdBusy(ByVal cmdMsg As String) As Boolean
        Dim state As Integer
        state = CheckCndState(cmdMsg)
        If CMDSTATEINDEX.MOTION_CMD_STATE_BUSY = state Then
            Return True
        End If
        Return False
    End Function
    Private Function WaitCmdFin(ByVal cmdMsg As String) As Boolean
        Dim cnt As Integer
        cnt = 0
        While (1)
            If True = IsCmdResp(cmdMsg) Then
                If True = IsCmdBusy(cmdMsg) Then
                    Return False
                ElseIf True = IsCmdFin(cmdMsg) Then
                    Return True
                Else
                    Threading.Thread.Sleep(1)
                End If
            Else
                If cnt >= 2000 Then
                    Return False
                End If
                cnt = cnt + 1
                Threading.Thread.Sleep(1)
            End If
        End While
        Return True
    End Function
    '运动指令
    Private Function SetAxisServoSta(ByVal usrID As Integer, ByVal axis As Integer, ByVal state As Integer, ByVal block As Boolean) As String

        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_SERVO"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString() + "," + state.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function

    Private Function GetAxisServoSta(ByVal usrID As Integer, ByVal axis As Integer, ByVal state As Integer, ByVal block As Boolean) As Int32

        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_SERVO"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString() + "," + state.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function

    Private Function MoveOneAxis(ByVal usrID As Integer, ByVal type As Integer, ByVal axis As Integer, ByVal pos As Single) As String

        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "MOVET"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString + "," + pos.ToString + "," + type.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function

    Private Function MoveAxisEx(ByVal usrID As Integer, ByVal type As Integer, ByVal axis As Integer, ByVal pos As Single) As String

        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "MOVET_EX"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString + "," + pos.ToString + "," + type.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function

    Private Function MoveAxisIpl(ByVal usrID As Integer, ByVal mask As Integer, ByVal num As Integer, ByVal mode As Integer, ByVal pos() As Integer) As String

        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "MOVET_IPL"
        cmdStr = usrID.ToString + "," + cmdName + "," + mask.ToString + "," + num.ToString + "," + mode.ToString
        For i = 0 To num
            cmdStr = cmdStr + "," + pos(i).ToString
        Next
        cmdStr = cmdStr + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function


    Private Function SetAxisProfile(ByVal usrID As Integer, ByVal axis As Integer, ByVal minVel As Double, ByVal maxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_PROFILE"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString + "," + minVel.ToString + "," + maxVel.ToString + "," + Tacc.ToString + "," + Tdec.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If
        Return cmdName
    End Function

    Private Function SetAxisExProfile(ByVal usrID As Integer, ByVal axis As Integer, ByVal minVel As Double, ByVal maxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_EXPROFILE"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString + "," + minVel.ToString + "," + maxVel.ToString + "," + Tacc.ToString + "," + Tdec.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If
        Return cmdName
    End Function

    Private Function SetVectorTProfile(ByVal usrID As Integer, ByVal s_param As Single, ByVal maxVel As Single, ByVal tAcc As Single, ByVal tDec As Single, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_VECTOR"
        cmdStr = usrID.ToString + "," + cmdName + "," + s_param.ToString + "," + maxVel.ToString + "," + tAcc.ToString + "," + tDec.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If
        Return cmdName
    End Function
    Private Function Jog(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal dir As Integer) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "JOG"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisIndex.ToString + "," + dir.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function

    Private Function SetHomeMode(ByVal usrID As Integer, ByVal axis As Integer, ByVal mode As Integer, ByVal ezCnt As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_HOME"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString + "," + mode.ToString + "," + ezCnt.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If
        Return cmdName
    End Function
    Private Function HomeS(ByVal usrID As Integer, ByVal axis As Integer, ByVal home_mode As Integer, ByVal vel_mode As Integer) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "HOMES"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString + "," + home_mode.ToString + "," + vel_mode.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function
    Private Function StopAll(ByVal usrID As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "STOPA"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If

        Return cmdName
    End Function
    Private Function StopDec(ByVal usrID As Integer, ByVal axis As Integer, ByVal Tdec As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "STOP_DEC"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString + "," + Tdec.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If

        Return cmdName
    End Function
    Private Function StopImd(ByVal usrID As Integer, ByVal axis As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "STOP_IMD"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString + "," + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If

        Return cmdName
    End Function
    Private Function SetPos(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal pos As Single, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_POS"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisIndex.ToString + "," + pos.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If

        Return cmdName
    End Function

    Private Function ResetTarget(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal pos As Single, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_TARGET"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisIndex.ToString + "," + pos.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If

        Return cmdName
    End Function
    Private Function GetTargetPos(ByVal usrID As Integer, ByVal axis As Int32, ByRef pos As Int32, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_TARGET"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            pos = m_axisTargetPos(axis)
        End If
        Return cmdName
    End Function
    Private Function GetLogicPos(ByVal usrID As Integer, ByRef x As Single, ByRef y As Single, ByRef z As Single, ByRef u As Single, ByRef v As Single, ByRef w As Single, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_POST"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            If WaitCmdFin(cmdName) = True Then
                x = m_planPos(0)
                y = m_planPos(1)
                z = m_planPos(2)
                u = m_planPos(3)
                v = m_planPos(4)
                w = m_planPos(5)
            End If

        End If
        Return cmdName
    End Function
    Private Sub TrigPosRead(ByVal usrID As Integer)
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_POST"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
    End Sub
    Private Function IsPosReadOK(ByVal usrID As Integer, ByRef x As Single, ByRef y As Single, ByRef z As Single, ByRef u As Single, ByRef v As Single, ByRef w As Single) As Boolean
        Dim cmdName As String
        cmdName = "GET_POST"
        cmdName = cmdName + usrID.ToString
        If IsCmdFin(cmdName) = True Then
            x = m_planPos(0)
            y = m_planPos(1)
            z = m_planPos(2)
            u = m_planPos(3)
            v = m_planPos(4)
            w = m_planPos(5)
            Return True
        End If
        Return False
    End Function
    Private Function GetEncPos(ByVal usrID As Integer, ByRef x As Int32, ByRef y As Int32, ByRef z As Int32, ByRef u As Int32, ByRef v As Int32, ByRef w As Int32, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_ENC"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            If WaitCmdFin(cmdName) = True Then
                x = m_realPos(0)
                y = m_realPos(1)
                z = m_realPos(2)
                u = m_realPos(3)
                v = m_realPos(4)
                w = m_realPos(5)
            End If
        End If
        Return cmdName
    End Function
    Private Function SetRealPos(ByVal usrID As Integer, ByVal axisNum As Int32, ByVal val As Int32, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_ENC"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisNum.ToString + "," + val.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If
        Return cmdName
    End Function
    Private Function SetAxisSpeed(ByVal usrID As Integer, ByVal axis As Int32, ByVal speed As Int32, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_SPEED"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString + "," + speed.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If
        Return cmdName
    End Function
    Private Function GetAxisSpeed(ByVal usrID As Integer, ByVal axis As Int32, ByRef speed As Int32, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_SPEED"
        cmdStr = usrID.ToString + "," + cmdName + "," + axis.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            speed = Val(m_axisCurSpeed(axis))
        End If
        Return cmdName
    End Function
    Private Function GetInputSigAll(ByVal usrID As Integer, ByRef sigVal As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_INPUT"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
            sigVal = m_inputSig
        End If
        Return cmdName
    End Function
    Private Function GetInputSig(ByVal usrID As Integer, ByVal index As Integer, ByRef sigVal As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_INPUT"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
            sigVal = m_inputSig And 2 ^ index
            If sigVal > 0 Then
                sigVal = 0
            Else
                sigVal = 1
            End If
        End If
        Return cmdName
    End Function

    Private Sub InputTrig(ByVal usrID As Integer)
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_INPUT"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
    End Sub
    Private Function IsInputReady(ByVal usrID As Integer, ByRef inputAll As Integer) As Boolean
        Dim cmdName As String
        cmdName = "GET_INPUT"
        cmdName = cmdName + usrID.ToString
        If IsCmdFin(cmdName) Then
            inputAll = m_inputSig
            Return True
        End If
        Return False
    End Function
    Private Function GetInputSig(ByVal index As Integer) As Integer
        Return m_inputSig And 2 ^ index
    End Function
    Private Function GetOutputSig(ByVal usrID As Integer,ByVal index As Integer,ByRef sigVal As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_OUT"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            sigVal = m_outPutSig And 2 ^ index
            If sigVal > 0 Then
                sigVal = 0
            Else
                sigVal = 1
            End If
        End If
        Return cmdName
    End Function
    Private Function GetOutputSigAll(ByVal usrID As Integer, ByRef sigVal As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_OUT"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            sigVal = m_outPutSig
        End If
        Return cmdName
    End Function
    Private Function SetOutputSig(ByVal usrID As Integer, ByVal index As Integer, ByVal val As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_OUT"
        cmdStr = usrID.ToString + "," + cmdName + "," + index.ToString + "," + val.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If
        Return cmdName
    End Function
    Private Function SetOutputSigAll(ByVal usrID As Integer, ByVal val As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_OUTPORT"
        cmdStr = usrID.ToString + "," + cmdName + "," + val.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If
        Return cmdName
    End Function
    Private Function GetExInputSig(ByVal usrID As Integer, ByVal devNum As Integer, ByVal index As Integer, ByRef sigVal As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_EXINPUT"
        cmdStr = usrID.ToString + "," + cmdName + "," + devNum.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
            sigVal = m_exInPutSig(devNum) And 2 ^ index
        End If
        Return cmdName
    End Function
    Private Function GetExInputSigAll(ByVal usrID As Integer, ByVal devNum As Integer, ByRef sigVal As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_EXINPUT"
        cmdStr = usrID.ToString + "," + cmdName + "," + devNum.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
            sigVal = m_exInPutSig(devNum)
        End If
        Return cmdName
    End Function
    Private Function GetExOutputSig(ByVal usrID As Integer, ByVal devNum As Integer, ByVal index As Integer, ByRef sigVal As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_EXOUT"
        cmdStr = usrID.ToString + "," + cmdName + "," + devNum.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            sigVal = m_exOutPutSig(devNum) And 2 ^ index
        End If
        Return cmdName
    End Function
    Private Function GetExOutputSigAll(ByVal usrID As Integer, ByVal devNum As Integer, ByRef sigVal As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_EXOUT"
        cmdStr = usrID.ToString + "," + cmdName + "," + devNum.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            sigVal = m_exOutPutSig(devNum)
        End If
        Return cmdName
    End Function
    Private Function SetExOutputSigAll(ByVal usrID As Integer, ByVal devNum As Integer, ByVal sigVal As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_EXOUTPORT"
        cmdStr = usrID.ToString + "," + cmdName + "," + devNum.ToString + "," + sigVal.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            sigVal = m_exOutPutSig(devNum)
        End If
        Return cmdName
    End Function
    Private Function SetExOutputSig(ByVal usrID As Integer, ByVal devNum As Integer, ByVal index As Integer, ByVal val As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_EXOUT"
        cmdStr = usrID.ToString + "," + cmdName + "," + devNum.ToString + "," + index.ToString + "," + val.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If
        Return cmdName
    End Function
    Private Function GetHardSigAll(ByVal usrID As Integer, ByRef sigVal As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "HARDSIG"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            sigVal = m_hardSig
        End If
        Return cmdName
    End Function
    Private Sub HardSigTrig(ByVal usrID)
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "HARDSIG"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
    End Sub
    Private Function IsHardSigReady(ByVal usrID As Integer) As Boolean
        Dim cmdName As String
        cmdName = "HARDSIG"
        cmdName = cmdName + usrID.ToString
        If IsCmdFin(cmdName) = True Then
            Return True
        End If
        Return False
    End Function
    Private Function HardSigAll() As Integer
        Return m_hardSig
    End Function
    Private Function GetAxisHmState(ByVal usrID As Integer, ByVal mask As Integer, ByRef hmState As Boolean, ByRef blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "HOMESTATE"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            hmState = m_hmState
        End If
        Return cmdName
    End Function
    Private Function GetAxisState(ByVal usrID As Integer, ByVal axisNum As Integer, ByRef state As Int16, ByRef blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "CHK_DONE"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisNum.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            If True = m_axisState(axisNum) Then
                state = 1
            Else
                state = 0
            End If

        End If
        Return cmdName
    End Function
    Private Function GetAxisInpos(ByVal usrID As Integer, ByVal axisNum As Integer, ByRef state As Integer, ByRef blockFlag As Boolean) As Int32
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_INPOS"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisNum.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            state = m_inpos(axisNum)
        End If
        Return cmdName
    End Function
    Private Function GetAxisReady(ByVal usrID As Integer, ByVal axisNum As Integer, ByRef state As Integer, ByRef blockFlag As Boolean) As Int32
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_READY"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisNum.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            state = m_ready(axisNum)
        End If
        Return cmdName
    End Function
    Private Function GetAxisAlarm(ByVal usrID As Integer, ByVal axisNum As Integer, ByRef state As Integer, ByRef blockFlag As Boolean) As Int32
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_ALARM"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisNum.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            state = m_alarm(axisNum)
        End If
        Return cmdName
    End Function
    Private Function GetAxisServo(ByVal usrID As Integer, ByVal axisNum As Integer, ByRef state As Integer, ByRef blockFlag As Boolean) As Int32
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_SERVOR"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisNum.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            state = m_servo(axisNum)
        End If
        Return cmdName
    End Function
    '参数配置
    Private Function SetCfgCommand(ByVal usrID As Integer, ByVal Name As String, ByVal subIndex As Integer, ByVal valStr As String, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "SET_CONFIG"
        cmdStr = usrID.ToString + "," + cmdName + "," + Name + subIndex.ToString + "," + valStr + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If
        Return cmdName
    End Function

    Private Function SetCfgHomeDir(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal dir As Boolean, ByVal blockFlag As Boolean) As String
        Dim dirStr As String
        If dir = True Then
            dirStr = "POSITIVE"
        Else
            dirStr = "NEGTIVE"
        End If
        Return SetCfgCommand(usrID, "HMDIR", axisIndex, dirStr, blockFlag)
    End Function
    Private Function SetCfgPlsType(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal type As Boolean, ByVal blockFlag As Boolean) As Boolean
        Dim typeStr As String
        If type = True Then
            typeStr = "TWO"
        Else
            typeStr = "ONE"
        End If
        Return SetCfgCommand(usrID, "PLS_TYPE", axisIndex, typeStr, blockFlag)
    End Function
    Private Function SetCfgHmLvl(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal filter As Int16, ByVal blockFlag As Boolean) As Boolean
        Dim typeStr As String
        If filter = 0 Then
            typeStr = "LOW"
        Else
            typeStr = "HIGH"
        End If
        Return SetCfgCommand(usrID, "HM_LVL", axisIndex, typeStr, blockFlag)
    End Function
    '读取设置参数
    Private Function GetCfgCommand(ByVal usrID As Integer, ByVal Name As String, ByVal subIndex As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_CONFIG"
        cmdStr = usrID.ToString + "," + cmdName + "," + Name + subIndex.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
        End If
        Return cmdName
    End Function

    Private Function GetCfgHomeDir(ByVal usrID As String, ByVal axisIndex As Integer, ByRef dir As Boolean, ByVal blockFlag As Boolean) As String
        Dim retStr As String
        retStr = GetCfgCommand(usrID, "HMDIR", axisIndex, blockFlag)
        If blockFlag = True Then
            dir = m_hmDir(axisIndex)
        End If
        Return retStr
    End Function
    Private Function GetCfgPlsType(ByVal usrID As Integer, ByVal axisIndex As Integer, ByRef type As Boolean, ByVal blockFlag As Boolean) As String
        Dim retStr As String
        retStr = GetCfgCommand(usrID, "PLS_TYPE", axisIndex, blockFlag)
        If blockFlag = True Then
            type = m_plsType(axisIndex)
        End If
        Return retStr
    End Function


    '对接函数
    Public Enum StateIndex
        MOTION_CMD_STATE_ERROR = -1
        MOTION_CMD_STATE_OK = 0
    End Enum

    Public Function Init(ByVal ip As String, ByVal port As Integer) As Int16
        cmdState.Clear()
        critMutex.Set()
        ipAddres = ip
        portNum = port
        Connect()
        Dim count As UInt16
        count = 0
        Dim flag As Boolean
        flag = True
        While (flag)
            Thread.Sleep(100)
            count = count + 1
            If count = 100 Or IsConnect() = True Then
                flag = False
            End If
        End While

        If True = IsConnect() Then
            Return StateIndex.MOTION_CMD_STATE_OK
        End If
        Return StateIndex.MOTION_CMD_STATE_ERROR
    End Function

    Public Function Close() As Int16
        Dim state As StateIndex
        state = StateIndex.MOTION_CMD_STATE_OK
        If connectFlag = True Then
            Try
                Disconnect()
                state = StateIndex.MOTION_CMD_STATE_OK
            Catch ex As Exception
                state = StateIndex.MOTION_CMD_STATE_ERROR
            End Try
        End If
        Return state
    End Function

    Public Function set_pulse_outmode(ByVal axis As Int16, ByVal outmode As Int16) As Int16
        Dim state As StateIndex
        Try
            If outmode = 1 Then
                SetCfgPlsType(0, axis, True, True)
            Else
                SetCfgPlsType(0, axis, False, True)
            End If
            state = StateIndex.MOTION_CMD_STATE_OK
        Catch ex As Exception
            state = StateIndex.MOTION_CMD_STATE_ERROR
        End Try
        Return state
    End Function
    Public Function read_RDY_PIN(ByVal axis As Int16) As Int32
        Dim val As Int32
        GetAxisReady(0, axis, val, True)
        Return val
    End Function
    Public Function read_inbit(ByVal index As Integer) As Int16
        Dim val As Integer
        GetInputSig(0, index, val, True)
        Return val
    End Function
    Public Function read_exInbit(ByVal devNum As Integer, ByVal bitNo As Integer) As Int16
        Dim val As Integer
        GetExInputSig(0, devNum, bitNo, val, True)
        Return val
    End Function

    Public Sub write_outbit(ByVal index As Integer, ByVal val As Integer)
        SetOutputSig(0, index, val, True)
    End Sub
    Public Sub write_exOutbit(ByVal devNum As Integer, ByVal index As Integer, ByVal val As Integer)
        SetExOutputSig(0, devNum, index, val, True)
    End Sub

    Public Function read_outbit(ByVal index As Integer) As Integer
        Dim val As Integer
        GetOutputSig(0, index, val, True)
        Return val
    End Function
    Public Function read_exOutbit(ByVal devNum As Integer, ByVal index As Integer) As Integer
        Dim val As Integer
        GetExOutputSig(0, devNum, index, val, True)
        Return val
    End Function

    Public Function read_inport() As Int32
        Dim val As Int32
        GetInputSigAll(0, val, True)
        Return val
    End Function
    Public Function read_exInport(ByVal devNum As Int32) As Int32
        Dim val As Int32
        GetExInputSigAll(0, devNum, val, True)
        Return val
    End Function
    Public Function read_outport() As Int32
        Dim val As Int32
        GetOutputSigAll(0, val, True)
        Return val
    End Function
    Public Function read_exoutport(ByVal devNum As Int32) As Int32
        Dim val As Int32
        GetExOutputSigAll(0, devNum, val, True)
        Return val
    End Function
    Public Sub write_outport(ByVal val As Int32)
        SetOutputSigAll(0, val, True)
    End Sub
    Public Sub write_exoutport(ByVal devNum As Int32, ByVal val As Int32)
        SetExOutputSigAll(0, devNum, val, True)
    End Sub

    Public Sub home_move(ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16)
        HomeS(0, axis, home_mode, vel_mode)
    End Sub
    Public Sub decel_stop(ByVal axis As Int16, ByVal Tdec As Double)
        StopDec(0, axis, Tdec, True)
    End Sub
    Public Sub imd_stop(ByVal axis As Int16)
        StopImd(0, axis, True)
    End Sub
    Public Sub emg_stop()
        StopAll(0, True)
    End Sub

    Function get_plan_pos(ByVal axis As Integer) As Int32
        Dim pos(6) As Int32
        GetLogicPos(0, pos(0), pos(1), pos(2), pos(3), pos(4), pos(5), True)
        Return pos(axis)
    End Function

    Function get_enc_pos(ByVal axis As Integer) As Int32
        Dim pos(6) As Int32
        GetEncPos(0, pos(0), pos(1), pos(2), pos(3), pos(4), pos(5), True)
        Return pos(axis)
    End Function

    Public Sub set_position(ByVal axis As Int32, ByVal val As Int32)
        SetPos(0, axis, val, True)
    End Sub

    Public Function check_done(ByVal axis As Int32) As Int32
        Dim state As Int32
        GetAxisState(0, axis, state, True)
        Return state
    End Function

    Public Const HM_SIG_STAT_MASK = 1
    Public Const FL_SIG_STAT_MASK = 64
    Public Const RL_SIG_STAT_MASK = 4096
    Public Function axis_io_status(ByVal axis As Integer) As Long
        Dim hm As UInt16
        Dim fl As UInt16
        Dim rl As UInt16
        Dim hardSig As Int32
        Dim axis_state As Int32
        GetHardSigAll(0, hardSig, True)
        If (hardSig And (HM_SIG_STAT_MASK << axis)) = 0 Then
            hm = 0
        Else
            hm = 1
        End If
        If (hardSig And (FL_SIG_STAT_MASK << axis)) = 0 Then
            fl = 0
        Else
            fl = 1
        End If
        If (hardSig And (RL_SIG_STAT_MASK << axis)) = 0 Then
            rl = 0
        Else
            rl = 1
        End If
        axis_state = (rl << 13) + (hm << 14) + (fl << 12)
        Return axis_state
    End Function
    Public Function axis_status(ByVal axis As Integer) As Int16
        Dim state As Int16
        GetAxisState(0, axis, state, True)
        Return state
    End Function
    Public Function get_rsts(ByVal axis As Integer) As Int32
        Dim state As Int32
        Return state
    End Function
    Public Sub t_pmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        MoveOneAxis(0, posi_mode, axis, Dist)
    End Sub
    Public Sub ex_t_pmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        MoveAxisEx(0, posi_mode, axis, Dist)
    End Sub
    Public Sub s_pmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        MoveOneAxis(0, posi_mode, axis, Dist)
    End Sub
    Public Sub ex_s_pmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        MoveOneAxis(0, posi_mode, axis, Dist)
    End Sub
    Public Sub s_vmove(ByVal axis As Int16, ByVal Dir As Int32)
        Jog(0, axis, Dir)
    End Sub
    Public Sub t_vmove(ByVal axis As Int16, ByVal Dir As Int32)
        Jog(0, axis, Dir)
    End Sub
    Public Sub variety_speed_range(ByVal axis As Int16, ByVal chg_enable As Int16, ByVal Max_Vel As Double)

    End Sub
    Public Function read_current_speed(ByVal axis As Int16) As Int32
        Dim speed As Int32
        GetAxisSpeed(0, axis, speed, True)
        Return speed
    End Function
    Public Sub change_speed(ByVal axis As Int16, ByVal Curr_Vel As Double)
        SetAxisSpeed(0, axis, Curr_Vel, True)
    End Sub


    Public Sub set_vector_profile(ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
        SetVectorTProfile(0, Min_Vel, Max_Vel, Tacc, Tdec, True)
    End Sub
    Public Sub set_profile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
        SetAxisProfile(0, axis, Min_Vel, Max_Vel, Tacc, Tdec, True)
    End Sub
    Public Sub set_s_profile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Sacc As Int32, ByVal Sdec As Int32)

    End Sub
    Public Sub set_st_profile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Taccs As Double, ByVal Tdecs As Double)

    End Sub
    Public Sub reset_target_position(ByVal axis As Int16, ByVal Dist As Int32)
        ResetTarget(0, axis, Dist, True)
    End Sub
    Public Sub t_line2(ByVal AXIS1 As Int16, ByVal Dist1 As Int32, ByVal AXIS2 As Int16, ByVal Dist2 As Int32, ByVal posi_mode As Int16)

    End Sub
    Public Sub t_line3(ByVal axis As ArrayList, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal posi_mode As Int16)

    End Sub
    Public Sub t_line4(ByVal cardno As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal Dist4 As Int32, ByVal posi_mode As Int16)

    End Sub
    Public Sub arc_move(ByVal axis As ArrayList, ByVal target_pos As ArrayList, ByVal cen_pos As ArrayList, ByVal arc_dir As Short)

    End Sub
    Public Sub rel_arc_move(ByVal axis As ArrayList, ByVal target_pos As ArrayList, ByVal cen_pos As ArrayList, ByVal arc_dir As Short)

    End Sub
    Public Sub set_handwheel_inmode(ByVal axis As Int16, ByVal inmode As Int16, ByVal count_dir As Int16)

    End Sub
    Public Sub handwheel_move(ByVal axis As Int16, ByVal vh As Double)

    End Sub
    Public Function get_encoder(ByVal axis As Int16) As Int32
        Dim pos(6) As Int32
        GetEncPos(0, pos(0), pos(1), pos(2), pos(3), pos(4), pos(5), True)
        Return pos(axis)
    End Function
    Public Sub set_encoder(ByVal axis As Int16, ByVal encoder_value As Int32)
        SetRealPos(0, axis, encoder_value, True)
    End Sub
    Public Sub counter_config(ByVal axis As Int16, ByVal mode As Int16)

    End Sub
    Public Sub config_LTC_PIN(ByVal axis As Int16, ByVal ltc_logic As Int16, ByVal ltc_mode As Int16)

    End Sub
    Public Function get_latch_value(ByVal axis As Int16) As Int32
        Dim enc As Int32
        Return enc
    End Function
    Public Function get_latch_flag(ByVal axis As Int16) As Int32
        Return 0
    End Function
    Public Sub reset_latch_flag(ByVal cardno As Int16)

    End Sub
    Public Function get_counter_flag(ByVal cardno As Int16)
        Return 0
    End Function
    Public Sub reset_counter_flag(ByVal cardno As Int16)

    End Sub
    Public Sub reset_clear_flag(ByVal cardno As Int16)
        SetPos(0, 0, 0, True)
        SetPos(0, 1, 0, True)
        SetPos(0, 2, 0, True)
        SetPos(0, 3, 0, True)
    End Sub
    Public Sub config_latch_mode(ByVal cardno As Int16, ByVal all_enable As Int16)

    End Sub
    Public Sub triger_chunnel(ByVal cardno As Int16, ByVal num As Int16)

    End Sub
    Public Sub set_speaker_logic(ByVal cardno As Int16, ByVal logic As Int16)

    End Sub
    Public Sub config_EMG_PIN(ByVal cardno As Int16, ByVal enable As Int16, ByVal emg_logic As Int16)

    End Sub
    Public Sub config_LTC_filter(ByVal cardno As Int16, ByVal width As Int16, ByVal enable As Int16)

    End Sub
    Public Sub config_encoder_filter(ByVal axis As Int16, ByVal width As Int16, ByVal enable As Int16)

    End Sub
    Public Function read_CMP_PIN(ByVal axis As Int16) As Int32
        Return 0
    End Function
    Public Sub write_CMP_PIN(ByVal axis As Int16, ByVal on_off As Int16)

    End Sub
    Public Sub config_CMP_PIN(ByVal axis As Int16, ByVal cmp1_enable As Int16, ByVal cmp2_enable As Int16, ByVal CMP_logic As Int16)

    End Sub
    Public Sub config_comparator(ByVal axis As Int16, ByVal cmp1_condition As Int16, ByVal cmp2_condition As Int16, ByVal source_sel As Int16, ByVal SL_action As Int16)

    End Sub
    Public Sub set_comparator_data(ByVal axis As Int16, ByVal cmp1_data As Int32, ByVal cmp2_data As Int32)

    End Sub
    Public Function get_equiv(ByVal axis As Int16, ByRef equiv As Double) As Int32
        Return 0
    End Function
    Public Function set_equiv(ByVal axis As Int16, ByVal new_equiv As Double) As Int32
        Return 0
    End Function
    Public Sub arc_move_unitmm(ByRef axis As Int16, ByRef target_pos As Double, ByRef cen_pos As Double, ByVal arc_dir As Int16)

    End Sub
    Public Sub rel_arc_move_unitmm(ByRef axis As Int16, ByRef rel_pos As Double, ByRef rel_cen As Double, ByVal arc_dir As Int16)

    End Sub
    Public Function set_t_move_all(ByVal TotalAxes As Int16, ByRef pAxis As Int16, ByRef pDist As Int32, ByVal posi_mode As Int16) As Int32
        Return 0
    End Function
    Public Function start_move_all(ByVal FirstAxis As Int16) As Int32
        Return 0
    End Function
    Public Function set_sync_option(ByVal axis As Int16, ByVal sync_stop_on As Int16, ByVal cstop_output_on As Int16, ByVal sync_option1 As Int16, ByVal sync_option2 As Int16) As Int32
        Return 0
    End Function
    Public Function set_sync_stop_mode(ByVal axis As Int16, ByVal stop_mode As Int16) As Int32
        Return 0
    End Function
    Public Sub board_rest()

    End Sub

    Public Sub set_HOME_pin_logic(ByVal axis As Int16, ByVal org_logic As Int16, ByVal filter As Int16)
        SetCfgHmLvl(0, axis, filter, True)
    End Sub
    Public Sub config_EZ_PIN(ByVal axis As Int16, ByVal ez_logic As Int16, ByVal ez_mode As Int16)

    End Sub
    Public Sub config_INP_PIN(ByVal axis As Int16, ByVal enable As Int16, ByVal inp_logic As Int16)

    End Sub
    Public Sub config_ERC_PIN(ByVal axis As Int16, ByVal enable As Int16, ByVal erc_logic As Int16, ByVal erc_width As Int16, ByVal erc_off_time As Int16)

    End Sub
    Public Sub config_ALM_PIN(ByVal axis As Int16, ByVal alm_logic As Int16, ByVal alm_action As Int16)

    End Sub
    Public Sub config_EL_MODE(ByVal axis As Int16, ByVal el_mode As Int16)


    End Sub
    Function read_SEVON_PIN(ByVal axis As Int16) As Int32
        Dim val As Int32
        Return GetAxisServo(0, axis, val, True)
    End Function
    Public Sub write_SEVON_PIN(ByVal axis As Int16, ByVal on_off As Int16)
        SetAxisServoSta(0, axis, on_off, True)
    End Sub
    Public Sub write_ERC_PIN(ByVal axis As Int16, ByVal sel As Int16)

    End Sub
    Public Sub config_home_mode(ByVal axis As Int16, ByVal mode As Int16, ByVal EZ_count As Int16)
        SetHomeMode(0, axis, mode, EZ_count, True)
    End Sub
End Class
