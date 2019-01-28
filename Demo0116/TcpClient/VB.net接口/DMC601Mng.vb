Imports System
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
    'Private mMust As New Threading.Mutex(False)
    Private ipAddres As String
    Private portNum As Integer
    Public m_gwAddr As Integer
    Public m_speedRate As Integer
    Public m_inputSig As Integer
    Public m_hmState As Integer
    Public m_hardSig As Integer
    Public m_outPutSig As Integer
    Public m_macAddr(6) As Char
    Public m_axisRate(6) As Integer
    Public m_maxV(6) As Single
    Public m_hmSpeed(6) As Single
    Public m_maxAcc(6) As Single
    Public m_maxDec(6) As Single
    Public m_hmDir(6) As Boolean
    Public m_planPos(6) As Single
    Public m_realPos(6) As Int32
    Public m_plsType(6) As Integer
    Public m_exInPutSig(6) As Integer
    Public m_exOutPutSig(6) As Integer
    Public m_axisState(6) As Int32
    Public Shared Sub msleep(ByVal time As Integer)
        Threading.Thread.Sleep(time)
    End Sub
    Sub New()

    End Sub

    Private Sub Lock()
        critMutex.WaitOne()
        critMutex.Reset()
        'mMust.WaitOne()
    End Sub

    Private Sub UnLock()
        critMutex.Set()
        'mMust.ReleaseMutex()
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
        Dim ipAddress As IPAddress
        ipAddress = ipAddress.Parse(ipAddres)
        Dim remoteEP As IPEndPoint = New IPEndPoint(ipAddress, portNum)
        client = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        connectFlag = False
        Try
            client.BeginConnect(remoteEP, New AsyncCallback(AddressOf ConnectCallback), client)
        Catch ex As Exception
            MsgBox("连接失败,请检查硬件连接!", vbOKOnly, "通讯异常")
            connectFlag = False
            Return False
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
            MsgBox("连接失败,请检查硬件连接!", vbOKOnly, "通讯异常")
            connectFlag = False
        End Try

    End Sub
    Private Sub ReceiveCallback(ByVal ar As IAsyncResult)

        If connectFlag = False Then
            Return
        End If

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
            MsgBox("以太网通讯错误！", vbOKOnly, "通讯异常")
        End If

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
        ElseIf StrComp(vStr(1), "GET_POS") = 0 Then
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
        ElseIf StrComp(vStr(1), "GET_CONFIG") = 0 Then
            Dim subIndex As Integer
            subIndex = vStr(3)
            If StrComp(vStr(2), "GRATE") = 0 Then
                m_speedRate = vStr(4)
            ElseIf StrComp(vStr(2), "LRATE") = 0 Then
                m_axisRate(subIndex) = vStr(4)
            ElseIf StrComp(vStr(2), "HMSPEED") = 0 Then
                m_hmSpeed(subIndex) = vStr(4)
            ElseIf StrComp(vStr(2), "HMDIR") = 0 Then
                If StrComp(vStr(4), "POSITIVE") = 0 Then
                    m_hmDir(subIndex) = True
                Else
                    m_hmDir(subIndex) = False
                End If
            ElseIf StrComp(vStr(2), "MAXV") = 0 Then
                m_maxV(subIndex) = vStr(4)
            ElseIf StrComp(vStr(2), "MAXACC") = 0 Then
                m_maxAcc(subIndex) = vStr(4)
            ElseIf StrComp(vStr(2), "MAXDEC") = 0 Then
                m_maxDec(subIndex) = vStr(4)
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
    Private Sub SendMsg(ByVal msg As String)

        If connectFlag = True Then
            Lock()
            Send(client, msg.ToString())
            UnLock()
        End If
    End Sub
    Private Sub Send(ByVal client As Socket, ByVal data As String)

        Dim byteData As Byte() = Encoding.ASCII.GetBytes(data)
        client.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendCallback), client)

    End Sub
    Private Sub SendCallback(ByVal ar As IAsyncResult)
        Dim client As Socket = CType(ar.AsyncState, Socket)
        Dim bytesSent As Integer = client.EndSend(ar)
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
    Private Function MoveOneAxis(ByVal usrID As Integer, ByVal type As Integer, ByVal axis As Integer, ByVal pos As Single) As String

        Dim cmdName As String
        Dim cmdStr As String
        Dim mask As Integer
        cmdName = "MOVEJ"
        mask = 2 ^ axis

        cmdStr = usrID.ToString + "," + cmdName + "," + mask.ToString + "," + type.ToString + "," + pos.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName

    End Function
    Private Function MoveTwoAxis(ByVal usrID As Integer, ByVal type As Integer, ByVal axis1 As Integer, ByVal pos1 As Single, ByVal axis2 As Integer, ByVal pos2 As Single) As String

        Dim cmdName As String
        Dim cmdStr As String
        Dim mask As Integer

        mask = 2 ^ axis1 + 2 ^ axis2
        cmdName = "MOVEJ"

        If axis1 < axis2 Then
            cmdStr = usrID.ToString + "," + cmdName + "," + mask.ToString + "," + type.ToString + "," + pos1.ToString + "," + pos2.ToString + "\r"
        Else
            cmdStr = usrID.ToString + "," + cmdName + "," + mask.ToString + "," + type.ToString + "," + pos2.ToString + "," + pos1.ToString + "\r"
        End If

        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName

    End Function
    Private Function MoveThreeAxis(ByVal usrID As Integer, ByVal type As Integer, ByVal axis1 As Integer, ByVal pos1 As Single, ByVal axis2 As Integer, ByVal pos2 As Single, ByVal axis3 As Integer, ByVal pos3 As Single) As String
        Dim cmdName As String
        Dim cmdStr As String
        Dim mask As Integer
        Dim pos(3) As Single

        mask = 2 ^ axis1 + 2 ^ axis2 + 2 ^ axis3
        cmdName = "MOVEJ"

        If axis1 < axis2 Then
            If axis2 < axis3 Then
                pos(0) = pos1
                pos(1) = pos2
                pos(2) = pos3
            Else
                If axis1 < axis3 Then
                    pos(0) = pos1
                    pos(1) = pos3
                    pos(2) = pos2
                Else
                    pos(0) = pos3
                    pos(1) = pos1
                    pos(2) = pos2
                End If
            End If

        Else
            If axis1 < axis3 Then
                pos(0) = pos2
                pos(1) = pos1
                pos(2) = pos3
            Else
                If axis2 < axis3 Then
                    pos(0) = pos2
                    pos(1) = pos3
                    pos(2) = pos1
                Else
                    pos(0) = pos3
                    pos(1) = pos2
                    pos(2) = pos1
                End If
            End If
        End If
        cmdStr = usrID.ToString + "," + cmdName + "," + mask.ToString + "," + type.ToString + "," + pos1.ToString + "," + pos2.ToString + "," + pos3.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function
    Private Function Move(ByVal usrID As Integer, ByVal type As Integer, ByVal posList() As Single, ByVal axisList() As Integer) As String

        Dim cmdName As String
        Dim cmdStr As String
        Dim posStr As String
        Dim mask As Integer
        Dim sz As Integer

        cmdName = "MOVEJ"
        sz = axisList.Length - 1

        If sz = 0 Then
            Return "NONE"
        End If

        For i = 0 To sz - 1
            For j = i + 1 To sz - 1
                If axisList(j) < axisList(i) Then
                    Dim vf As Single
                    Dim vi As Single

                    vf = posList(i)
                    vi = axisList(i)
                    posList(i) = posList(j)
                    axisList(i) = axisList(j)
                    posList(j) = vf
                    axisList(j) = vi
                End If
            Next
        Next

        For i = 0 To sz - 1
            mask = mask + 2 ^ axisList(i)
        Next

        posStr = ""
        For i = 0 To sz - 1
            posStr = posStr + "," + posList(i).ToString
        Next

        cmdStr = usrID.ToString + "," + cmdName + "," + mask.ToString + "," + type.ToString + posStr + "\r"
        SendMsg(cmdStr)

        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName

    End Function

    Private Function Jog(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal speedRate As Integer, ByVal dir As Integer) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "JOG"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisIndex.ToString + "," + speedRate.ToString + "," + dir.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function
    Private Function HomeS(ByVal usrID As Integer, ByVal axisIndex As Integer) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "HOMES"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisIndex.ToString + "\r"
        SendMsg(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function
    Private Function HomeM(ByVal usrID As Integer, ByVal mask As Integer) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "HOMEM"
        cmdStr = usrID.ToString + "," + cmdName + "," + mask.ToString + "\r"
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
    Private Function StopMulti(ByVal usrID As Integer, ByVal mask As Integer, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "STOPM"
        cmdStr = usrID.ToString + "," + cmdName + "," + mask.ToString + "\r"
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
    Private Function GetLogicPos(ByVal usrID As Integer, ByRef x As Single, ByRef y As Single, ByRef z As Single, ByRef u As Single, ByRef v As Single, ByRef w As Single, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_POS"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            x = m_planPos(0)
            y = m_planPos(1)
            z = m_planPos(2)
            u = m_planPos(3)
            v = m_planPos(4)
            w = m_planPos(5)
        End If
        Return cmdName
    End Function
    Private Sub TrigPosRead(ByVal usrID As Integer)
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_POS"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
    End Sub
    Private Function IsPosReadOK(ByVal usrID As Integer, ByRef x As Single, ByRef y As Single, ByRef z As Single, ByRef u As Single, ByRef v As Single, ByRef w As Single) As Boolean
        Dim cmdName As String
        cmdName = "GET_POS"
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
    Private Function GetRealPos(ByVal usrID As Integer, ByRef x As Int32, ByRef y As Int32, ByRef z As Int32, ByRef u As Int32, ByRef v As Int32, ByRef w As Int32, ByVal blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "GET_ENC"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)

        If blockFlag = True Then
            WaitCmdFin(cmdName)
            x = m_realPos(0)
            y = m_realPos(1)
            z = m_realPos(2)
            u = m_realPos(3)
            v = m_realPos(4)
            w = m_realPos(5)
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
    Private Function GetAxisState(ByVal usrID As Integer, ByVal axisNum As Integer, ByRef state As Boolean, ByRef blockFlag As Boolean) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "CHK_DONE"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisNum.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        If blockFlag = True Then
            WaitCmdFin(cmdName)
            state = m_axisState(axisNum)
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
    Private Function SetCfgSpeedRate(ByVal usrID As Integer, ByVal rate As Integer, ByVal blockFlag As Boolean) As String
        Return SetCfgCommand(usrID, "GRATE", 0, rate.ToString, blockFlag)
    End Function

    Private Function SetCfgAxisRate(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal rate As Integer, ByVal blockFlag As Boolean) As String
        Return SetCfgCommand(usrID, "LRATE", axisIndex, rate.ToString, blockFlag)
    End Function
    Private Function SetCfgHomeSpeed(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal speed As Single, ByVal blockFlag As Boolean) As String
        Return SetCfgCommand(usrID, "HMSPEED", axisIndex, speed.ToString, blockFlag)
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
    Private Function SetCfgMaxV(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal speed As Single, ByVal blockFlag As Boolean) As String
        Return SetCfgCommand(usrID, "MAXV", axisIndex, speed.ToString, blockFlag)
    End Function
    Private Function SetCfgMaxAcc(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal acc As Single, ByVal blockFlag As Boolean) As Boolean
        Return SetCfgCommand(usrID, "MAXACC", axisIndex, acc.ToString, blockFlag)
    End Function
    Private Function SetCfgMaxDec(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal dec As Single, ByVal blockFlag As Boolean) As Boolean
        Return SetCfgCommand(usrID, "MAXDEC", axisIndex, dec.ToString, blockFlag)
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
    Private Function GetCfgSpeedRate(ByVal usrID As Integer, ByRef rate As Integer, ByVal blockFlag As Boolean) As String
        Dim retStr As String
        retStr = GetCfgCommand(usrID, "GRATE", 0, blockFlag)
        If blockFlag = True Then
            rate = m_speedRate
        End If
        Return retStr
    End Function
    Private Function GetCfgAxisRate(ByVal usrID As Integer, ByVal axisIndex As Integer, ByRef rate As Integer, ByVal blockFlag As Boolean) As Boolean
        Dim retStr As String
        retStr = GetCfgCommand(usrID, "LRATE", axisIndex, blockFlag)
        If blockFlag = True Then
            rate = m_axisRate(axisIndex)
        End If
        Return retStr
    End Function
    Private Function GetCfgHomeSpeed(ByVal usrID As Integer, ByVal axisIndex As Integer, ByVal speed As Single, ByVal blockFlag As Boolean) As String
        Dim retStr As String
        retStr = GetCfgCommand(usrID, "HMSPEED", axisIndex, blockFlag)
        If blockFlag = True Then
            speed = m_hmSpeed(axisIndex)
        End If
        Return retStr
    End Function
    Private Function GetCfgHomeDir(ByVal usrID As String, ByVal axisIndex As Integer, ByRef dir As Boolean, ByVal blockFlag As Boolean) As String
        Dim retStr As String
        retStr = GetCfgCommand(usrID, "HMDIR", axisIndex, blockFlag)
        If blockFlag = True Then
            dir = m_hmDir(axisIndex)
        End If
        Return retStr
    End Function
    Private Function GetCfgMaxV(ByVal usrID As Integer, ByVal axisIndex As Integer, ByRef speed As Single, ByVal blockFlag As Boolean) As String
        Dim retStr As String
        retStr = GetCfgCommand(usrID, "MAXV", axisIndex, blockFlag)
        If blockFlag = True Then
            speed = m_maxV(axisIndex)
        End If
        Return retStr
    End Function
    Private Function GetCfgMaxAcc(ByVal usrID As Integer, ByVal axisIndex As Integer, ByRef acc As Single, ByVal blockFlag As Boolean) As String
        Dim retStr As String
        retStr = GetCfgCommand(usrID, "MAXACC", axisIndex, blockFlag)
        If blockFlag = True Then
            acc = m_maxAcc(axisIndex)
        End If
        Return retStr
    End Function
    Private Function GetCfgMaxDec(ByVal usrID As Integer, ByVal axisIndex As Integer, ByRef dec As Single, ByVal blockFlag As Boolean) As String
        Dim retStr As String
        retStr = GetCfgCommand(usrID, "MAXDEC", axisIndex, blockFlag)
        If blockFlag = True Then
            dec = m_maxDec(axisIndex)
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

    '飞拍功能模块
    Private Function FlyCapEnable(ByVal usrID As Integer) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "FLYCAPSW"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function
    Private Function FlyCapDisEnable(ByVal usrID As Integer) As String
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "FLYCAPSW"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
        Return cmdName
    End Function
    Private Sub FlyCapSet(ByVal usrID As Integer, ByVal axisNum As Integer, ByVal num As Integer, ByVal capPos() As Single)
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "FLYCAPSET"
        cmdStr = usrID.ToString + "," + cmdName + "," + axisNum.ToString + "," + num.ToString
        For i = 0 To num - 1
            cmdStr = cmdStr + "," + capPos(i).ToString
        Next
        cmdStr = cmdStr + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
    End Sub
    Private Sub FlyParamCfg(ByVal usrID As Integer, ByVal mask As Integer, ByVal delayTm As Integer, ByVal pluseNum As Integer, ByVal highWidth As Integer, ByVal pluseWidth As Integer)
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "FLYCFG"
        cmdStr = usrID.ToString + "," + cmdName + "," + mask.ToString + "," + delayTm.ToString + "," + pluseNum.ToString + "," + highWidth.ToString + "," + pluseWidth.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
    End Sub
    Private Sub TrigEnable(ByVal usrID As Integer, ByVal mask As Integer)
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "TRIGOPEN"
        cmdStr = usrID.ToString + "," + cmdName + "," + mask.ToString + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
    End Sub
    Private Sub TrigDisenable(ByVal usrID As Integer, ByVal mask As Integer)
        Dim cmdName As String
        Dim cmdStr As String
        cmdName = "TRIGCLOSE"
        cmdStr = usrID.ToString + "," + cmdName + "\r"
        SendCommand(cmdStr)
        cmdName = cmdName + usrID.ToString
        SendCmdRecord(cmdName)
    End Sub
    '对接函数
    Public Enum StateIndex
        MOTION_CMD_STATE_ERROR = -1
        MOTION_CMD_STATE_OK = 1
    End Enum

    Public Function Init(ByVal ip As String, ByVal port As Integer) As Int16
        cmdState.Clear()
        critMutex.Set()
        ipAddres = ip
        portNum = port
        If True = Connect() Then
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
        Return 1
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
        HomeS(0, axis)
    End Sub
    Public Sub decel_stop(ByVal axis As Int16, ByVal Tdec As Double)
        Dim mask As Int32
        mask = 2 ^ axis
        StopMulti(0, mask, True)
    End Sub
    Public Sub imd_stop(ByVal axis As Int16)
        Dim mask As Int32
        mask = 2 ^ axis
        StopMulti(0, mask, True)
    End Sub
    Public Sub emg_stop()
        StopAll(0, True)
    End Sub

    Function get_position(ByVal axis As Integer) As Int32
        Dim pos(6) As Int32
        GetRealPos(0, pos(0), pos(0), pos(0), pos(0), pos(0), pos(0), True)
        Return pos(axis)
    End Function
    Public Sub set_position(ByVal axis As Int32, ByVal val As Int32)
        SetRealPos(0, axis, val, True)
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
        Dim io_state As Long
        Dim hardSig As Int32
        GetHardSigAll(0, hardSig, True)
        'ret=(m_mtHardSig&(HM_SIG_STAT_MASK<<axisIndex))? true:false
        Return io_state
    End Function
    Public Function axis_status(ByVal axis As Integer) As Int32
        Dim state As Int32
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
        MoveOneAxis(0, posi_mode, axis, Dist)
    End Sub
    Public Sub s_pmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        MoveOneAxis(0, posi_mode, axis, Dist)
    End Sub
    Public Sub ex_s_pmove(ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
        MoveOneAxis(0, posi_mode, axis, Dist)
    End Sub
    Public Sub s_vmove(ByVal axis As Int16, ByVal Dir As Int32)
        Jog(0, axis, 100, Dir)
    End Sub
    Public Sub t_vmove(ByVal axis As Int16, ByVal Dir As Int32)
        Jog(0, axis, 100, Dir)
    End Sub
    Public Sub variety_speed_range(ByVal axis As Int16, ByVal chg_enable As Int16, ByVal Max_Vel As Double)
        SetCfgAxisRate(0, axis, Max_Vel, True)
    End Sub
    Public Function read_current_speed(ByVal axis As Int16) As Int32
        Dim rate As Int32
        GetCfgAxisRate(0, axis, rate, True)
        Return rate
    End Function
    Public Sub change_speed(ByVal axis As Int16, ByVal Curr_Vel As Double)

    End Sub
    Public Sub set_vector_profile(ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)

    End Sub
    Public Sub set_profile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)

    End Sub
    Public Sub set_s_profile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Sacc As Int32, ByVal Sdec As Int32)

    End Sub
    Public Sub set_st_profile(ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Taccs As Double, ByVal Tdecs As Double)

    End Sub
    Public Sub reset_target_position(ByVal axis As Int16, ByVal Dist As Int32)

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
        GetRealPos(0, pos(0), pos(1), pos(2), pos(3), pos(4), pos(5), True)
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

    End Sub
    Public Sub config_EZ_PIN(ByVal axis As Int16, ByVal ez_logic As Int16, ByVal ez_mode As Int16)

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
End Class
