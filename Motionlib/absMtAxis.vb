Public MustInherit Class absMtAxis



    ''' <summary>
    ''' ��ʼ�������
    ''' </summary>
    ''' <param name="Params">����</param>
    ''' <remarks></remarks>
    Protected MustOverride Overloads Sub P(ByVal Params As AxisParam, ByVal RunP As absMtAxis._RunParam)

    ''' <summary>
    ''' ����T�ٶ�
    ''' </summary>
    ''' <param name="MinVel">��ʼ�ٶ�</param>
    ''' <param name="MaxVel">�����ٶ�</param>
    ''' <param name="AccTm">����ʱ��</param>
    ''' <param name="DecTm">����ʱ��</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetTVel(ByVal axis As Int16, ByVal MinVel As Double, ByVal MaxVel As Double, ByVal AccTm As Double, ByVal DecTm As Double)

    ''' <summary>
    ''' ����S�ٶ�
    ''' </summary>
    ''' <param name="MinVel">��ʼ�ٶ�</param>
    ''' <param name="MaxVel">�����ٶ�</param>
    ''' <param name="AccTm">����ʱ��</param>
    ''' <param name="DecTm">����ʱ��</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetSVel(ByVal axis As Int16, ByVal MinVel As Double, ByVal MaxVel As Double, ByVal AccTm As Double, ByVal DecTm As Double, ByVal Sacc As Integer, ByVal Sdec As Integer)

    ''' <summary>
    ''' ����S�ٶ�
    ''' </summary>
    ''' <param name="MinVel">��ʼ�ٶ�</param>
    ''' <param name="MaxVel">�����ٶ�</param>
    ''' <param name="AccTm">����ʱ��</param>
    ''' <param name="DecTm">����ʱ��</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetSTVel(ByVal axis As Int16, ByVal MinVel As Double, ByVal MaxVel As Double, ByVal AccTm As Double, ByVal DecTm As Double)

    ''' <summary>
    ''' ����λ��
    ''' </summary>
    ''' <param name="pulse">����λ��</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetPos(ByVal axis As Int16, ByVal pulse As Integer)

    ''' <summary>
    ''' �����ԭ��
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub H(ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16, ByVal dis As Int32)

    ''' <summary>
    ''' �����ʼ��
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="home_mode"></param>
    ''' <param name="vel_mode"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub O(ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16)

    ''' <summary>
    ''' ���ᶨ����λ
    ''' </summary>
    ''' <param name="pulse">��������</param>
    ''' <param name="pulsMode">�˶�ģʽ��0��ʾ��ԣ�1��ʾ����</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub M(ByVal pulse As Integer, ByVal pulsMode As Short)

    ''' <summary>
    ''' �߾���
    ''' </summary>
    ''' <param name="pulse"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub Absolut(ByVal pulse As Long)

    ''' <summary>
    ''' �����
    ''' </summary>
    ''' <param name="DisPulse"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub Related(ByVal DisPulse As Long)

    ''' <summary>
    ''' ���������λ
    ''' </summary>
    ''' <param name="dirt">����ѡ��0��ʾ������1��ʾ������</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub Move(ByVal dirt As Short)

    ''' <summary>
    ''' ֹͣ��λ
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub S()

    ''' <summary>
    ''' ��ȡ��ǰ����ֵ
    ''' </summary>
    ''' <returns>���ص�ǰ����ֵ</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadPos(ByVal AxisNum As Short) As Long

    ''' <summary>
    ''' �ı��ٶ�
    ''' </summary>
    ''' <param name="NewSpeed"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub ChangeSpeedNew(ByVal NewSpeed As Double)


    ''' <summary>
    ''' ��ȡ��ǰ�ٶ�
    ''' </summary>
    ''' <returns>���ص�ǰ�ٶ�</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadVel() As Single


    ''' <summary>
    ''' ����ֹͣ
    ''' </summary>
    ''' <param name="Tdec"></param>����ʱ��
    ''' <remarks></remarks>
    Protected MustOverride Sub ReduceSpeedS(ByVal Tdec As Integer) '����ֹͣ

    ''' <summary>
    ''' ��ȡ������ֵ
    ''' </summary>
    ''' <returns>���ر�����ֵ</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadEncoder(ByVal AxisNum As Short) As Int32

    ''' <summary>
    ''' ���ñ�����ֵ
    ''' </summary>
    ''' <param name="value">����ֵ</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetEncoder(ByVal value As Integer)

    ''' <summary>
    ''' ��ȡ���ⲿ���ź�״̬ ��ͣ�����٣���λ��
    ''' </summary>
    ''' <returns>��ǰ��״̬</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadOtherStatu(ByVal AxisNum As Short) As Int32

    ''' <summary>
    ''' ��ȡ��״̬�����ŷ�������INI����
    ''' </summary>
    ''' <returns>��ǰ��״̬</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadAxisStatu(ByVal AxisNum As Short) As Long
    ''' <summary>
    ''' �Ƚ����˿������ƽ
    ''' </summary>
    ''' <param name="OnOrOff">0�͵�ƽ��1Ϊ�ߵ�ƽ</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub WriteCMPOnOff(ByVal OnOrOff As Byte)

    ''' <summary>
    ''' ������Ƚ����Ƚ�ֵ
    ''' </summary>
    ''' <param name="CMPData1">�Ƚ�ֵ1</param>
    ''' <param name="CMPData2">�Ƚ�ֵ2</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetCMPData(ByVal CMPData1 As Int32, ByVal CMPData2 As Int32)
    ''' <summary>
    ''' ���ñȽϴ���ģʽ
    ''' </summary>
    ''' <param name="cmp1_mode">�Ƚ���1�Ƚ�ģʽ��0�رձȽ�����1= ��2С���趨ֵ��3,����</param>
    ''' <param name="cmp2_mode">�Ƚ���2�Ƚ�ģʽ��0�رձȽ�����1= ��2С���趨ֵ��3,����</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SetCMPTrggerMode(ByVal cmp1_mode As Int16, ByVal cmp2_mode As Int16)

    ''' <summary>
    ''' ��ȡ��״̬��0���У�1ֹͣ
    ''' </summary>
    ''' <returns>��ǰ��״̬</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadAxisRunStop(ByVal AxisNum As Short) As Int16

    ''' <summary>
    '''д��IO
    ''' </summary>
    ''' <param name="cardno"></param>
    ''' <param name="BitNo"></param>
    ''' <param name="on_off"></param>
    ''' <remarks></remarks>

    Protected MustOverride Sub WriteOutIO(ByVal cardno As Int16, ByVal BitNo As Int16, ByVal on_off As Int16)

    ''' <summary>
    ''' ��ȡ���IO
    ''' </summary>
    ''' <param name="cardno"></param>
    ''' <param name="BitNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadOutIO(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32

    ''' <summary>
    ''' ��ȡ����IO
    ''' </summary>
    ''' <param name="cardno"></param>
    ''' <param name="BitNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReadInIO(ByVal cardno As Int16, ByVal BitNo As Int16) As Int32

    ''' <summary>
    ''' ������λS
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="Dir"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SVSmove(ByVal axis As Int16, ByVal Dir As Int16)

    ''' <summary>
    ''' ������λT
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="Dir"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub TVTmove(ByVal axis As Int16, ByVal Dir As Int16)

    ''' <summary>
    ''' S�Ͷ����˶�
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="Dist"></param>
    ''' <param name="posi_mode"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SPSmove(ByVal axis As Int16, ByVal Dist As Long, ByVal posi_mode As Int16)

    ''' <summary>
    ''' T�Ͷ����˶�
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="Dist"></param>
    ''' <param name="posi_mode"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub TPTmove(ByVal axis As Int16, ByVal Dist As Long, ByVal posi_mode As Int16)

    ''' <summary>
    ''' ��ѯ��������ź�
    ''' </summary>
    ''' <param name="index">����ֵ��0-�ܴ����־��1-�ŷ�������2-���ޱ�����3-��ͣ������4-�Ƿ�����,5-��λ��ʱ����_
    ''' 6-ԭ���źţ�7-�ŷ�ֹͣ�ź�,8-���������9-�˶�����,</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function E(ByVal index As Byte) As Short

    ''' <summary>
    ''' �ϵ纯��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function Pow() As Boolean

    ''' <summary>
    ''' ��ȡ׼�����ź�
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReaRDY(ByVal axis As Byte) As Int32

    ''' <summary>
    ''' ��ȡ�ϵ��ź�
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ReaSEVON(ByVal axis As Byte) As Int32

    ''' <summary>
    ''' �ϵ纯��
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="on_off"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub WeadSEVON(ByVal axis As Byte, ByVal on_off As Int16)

    ''' <summary>
    ''' ����EL�źŵ���Ч��ƽ���ƶ���ʽ
    ''' </summary>
    ''' <param name="axis">ָ�����</param>
    ''' <param name="el_mode">EL��Ч��ƽ���ƶ���ʽ</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub EL(ByVal axis As Short, ByVal el_mode As Short)

    ''' <summary>
    ''' ����ָ�����EZ�źŵ���Ч��ƽ��������
    ''' </summary>
    ''' <param name="axis">ָ�����</param>
    ''' <param name="ez_logic">EZ�ź��߼���ƽ��0������Ч��1������Ч</param>
    ''' <param name="ez_mode">EZ�źŵĹ�����ʽ</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub EZ(ByVal axis As Int16, ByVal ez_logic As Int16, ByVal ez_mode As Int16)

    ''' <summary>
    ''' ����ָ���������źŵ���Ч��ƽ
    ''' </summary>
    ''' <param name="axis">ָ�����</param>
    ''' <param name="ltc_logic">LTC�ź��߼���ƽ��0������Ч��1������Ч</param>
    ''' <param name="ltc_mode">EL��Ч��ƽ���ƶ���ʽ</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub LTC(ByVal axis As Short, ByVal ltc_logic As Short, ByVal ltc_mode As Short)

    ''' <summary>
    ''' ����ORG�źŵ���Ч��ƽ���Լ�����/��ֹ�˲�����
    ''' </summary>
    ''' <param name="axis">ָ�����</param>
    ''' <param name="org_logic">ORG�źŵ���Ч��ƽ��0���͵�ƽ��Ч��1���ߵ�ƽ��Ч</param>
    ''' <param name="filter">����/��ֹ�˲����ܣ�0����ֹ��1������</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub HOME(ByVal axis As Int16, ByVal org_logic As Int16, ByVal filter As Int16)

    ''' <summary>
    ''' �����ָ������ŷ�ʹ�ܶ��ӵĿ���
    ''' </summary>
    ''' <param name="axis">ָ�����</param>
    ''' <param name="on_off">�趨�ܽŵ�ƽ״̬��0���ͣ�1���ߡ�SEVON����ڳ�ʼ״̬��ѡ��</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SEVON(ByVal axis As Int16, ByVal on_off As Int16)

    ''' <summary>
    ''' ������������ʽ
    ''' </summary>
    ''' <param name="axis">���</param>
    ''' <param name="mode">��������������ģʽ</param>
    ''' <remarks></remarks>
    Protected MustOverride Sub Counter(ByVal axis As Int16, ByVal mode As Int16)

    ''' <summary>
    ''' �趨��ԭ��ģʽ
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="mode"></param>
    ''' <param name="EZ_count"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub HMode(ByVal axis As Short, ByVal mode As Short, ByVal EZ_count As Short)

    ''' <summary>
    ''' ����SD�ź���Ч���߼���ƽ���乤����ʽ
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="enable"></param>
    ''' <param name="sd_logic"></param>
    ''' <param name="sd_mode"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub SDPin(ByVal axis As Int16, ByVal enable As Int16, ByVal sd_logic As Int16, ByVal sd_mode As Int16)

    ''' <summary>
    ''' ��������/��ֹPCS�ⲿ�ź����˶��иı�Ŀ��λ��
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="enable"></param>
    ''' <param name="pcs_logic"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub PCSPin(ByVal axis As Int16, ByVal enable As Int16, ByVal pcs_logic As Int16)

    ''' <summary>
    ''' ����ָ��������������ʽ
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="outmode"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub PulseOut(ByVal axis As Int16, ByVal outmode As Int16)

    ''' <summary>
    ''' ��������/��ֹINP�źż�����Ч���߼���ƽ
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="enable"></param>
    ''' <param name="inp_logic"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub INPPin(ByVal axis As Int16, ByVal enable As Int16, ByVal inp_logic As Int16)

    ''' <summary>
    ''' ��������/��ֹERC�źż�����Ч��ƽ�������ʽ
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="enable"></param>
    ''' <param name="erc_logic"></param>
    ''' <param name="erc_width"></param>
    ''' <param name="erc_off_time"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub ERCPin(ByVal axis As Int16, ByVal enable As Int16, ByVal erc_logic As Int16, ByVal erc_width As Int16, ByVal erc_off_time As Int16)

    ''' <summary>
    ''' ����ALM���߼���ƽ���乤����ʽ
    ''' </summary>
    ''' <param name="axis"></param>
    ''' <param name="alm_logic"></param>
    ''' <param name="alm_action"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub ALMPin(ByVal axis As Int16, ByVal alm_logic As Int16, ByVal alm_action As Int16)


    ''' <summary>
    ''' �ⲿ�����������
    ''' </summary>
    ''' <remarks></remarks>
    Protected Enum Command As Int16
        Null = -1 '������
        MoveToABS = 0 '�����߾���
        MoveToFAC = 1 ' �����߾���
        KeepMove = 2 '�����˶�
        ReadPos = 3 '��ȡ��ǰ����ֵ
        StopMove = 4  ' ֹͣ�˶�
        Comeback = 5   '��ԭ������
        POW = 6 '�ϵ�
        Goback = 7 '��ԭ��
        Pause = 8 '��ͣ
        Start = 9 '��ʼ
        grating = 10 '��դ����
        ChangeSpeed = 11 '����
        Leave = 12 '��դ��ȫ���뿪
        DelSpeed = 13
    End Enum

    'Public CarNum As Integer


    Protected mCurPulse As Long '��ǰĿ��λ

    Protected mFacPulse As Long '���λ��
    Public mMoveWatiOne As Threading.ManualResetEvent
    Public mCommWatiOne As Threading.ManualResetEvent
    Public mHomeWatiOne As Threading.ManualResetEvent
    Public GraWatiOne As Threading.ManualResetEvent


    Public Structure _RunParam
        Public Min_Vel As Single   '��ʼ�ٶ�
        Public Max_Vel As Single  '�����ٶ�
        Public Tacc As Single    '�ܼ���ʱ��
        Public Tdec As Single  '�ܼ���ʱ��
        Public Sacc As Single 'S�μ��پ���
        Public Sdec As Single 'S�μ��پ���
        ' Public Home_Dis As Integer '��ԭ�㸴λ�߳�����
        Public OrgSpeed As Single '��λ�ٶ�
        Public RightLimit As Single '������
        Public LeftLimit As Single '������
        Public RunTime As Long  '��ʱ
        Public ReduceRatio As Single '���ٱ�

        Public RunDir As Byte '�˶�����
        Public AxiaName As String '������

        Public Shared Operator *(ByVal InParam As _RunParam, ByVal Cmp As Single) As _RunParam
            InParam.Max_Vel *= Cmp
            InParam.Min_Vel *= Cmp
            Return InParam
        End Operator


        Public Sub SaveFastenCong(ByVal Path As String, ByVal lpSectionName As String)
            Try
                WriteP(lpSectionName, "Min_Vel", Min_Vel, Path)
                WriteP(lpSectionName, "Max_Vel", Max_Vel, Path)
                WriteP(lpSectionName, "Tacc", Tacc, Path)
                WriteP(lpSectionName, "Tdec", Tdec, Path)
                WriteP(lpSectionName, "Sacc", Sacc, Path)
                WriteP(lpSectionName, "Sdec", Sdec, Path)
                WriteP(lpSectionName, "RunTime", RunTime, Path)
                WriteP(lpSectionName, "ReduceRatio", ReduceRatio, Path)
                WriteP(lpSectionName, "OrgSpeed", OrgSpeed, Path)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Function loadFastenCong(ByVal Path As String, ByVal AxixName As String) As ArrayList
            Try
                Dim ConfigAxix As New ArrayList
                Dim RunParam As _RunParam = Nothing
                RunParam.Min_Vel = CSng(ReadP("Min_Vel", 0, Path, AxixName))
                RunParam.Max_Vel = CSng(ReadP("Max_Vel", 0, Path, AxixName))
                RunParam.Tacc = CSng(ReadP("Tacc", 0, Path, AxixName))
                RunParam.Tdec = CSng(ReadP("Tdec", 0, Path, AxixName))
                RunParam.Sacc = CSng(ReadP("Sacc", 0, Path, AxixName))
                RunParam.Sdec = CSng(ReadP("Sdec", 0, Path, AxixName))
                RunParam.RunTime = CInt(ReadP("RunTime", 0, Path, AxixName))
                RunParam.LeftLimit = CSng(ReadP("LeftLimit", 0, Path, AxixName))
                RunParam.RightLimit = CSng(ReadP("RightLimit", 0, Path, AxixName))
                RunParam.ReduceRatio = CSng(ReadP("ReduceRatio", 0, Path, AxixName))
                RunParam.OrgSpeed = CSng(ReadP("orgspeed", 0, Path, AxixName))
                ConfigAxix.Add(RunParam)
                Return ConfigAxix
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Structure

    Public Structure AxisParam


        Public PulseMode As Byte
        Public CounterMode As Byte '����������ģʽ��������Ƶ
        Public EncodeMode As Byte '������������ʽ����������������
        Public SoftELEnable As Byte
        'Public SoftELMax As Long
        'Public SoftELMin As Long
        Public ORGSignal As Byte
        Public ORGFilter As Byte
        Public ORGMode As Byte
        Public EZSignal As Byte
        Public ORGEZNo As Byte
        Public ORGDir As Byte
        Public ORGSpeedMode As Byte
        Public EMGEable As Byte
        Public EMGSignal As Byte
        Public ALMSignal As Byte
        Public ALMStopMode As Byte
        Public INPEable As Byte
        Public INPSignal As Byte
        Public ERCMode As Byte
        Public ERCSignal As Byte
        Public ERCWidth As Byte
        Public ERCOfftime As Byte
        Public ELMode As Byte
        Public ERCsel As Byte

        'Public ELP As Byte
        'Public ELM As Byte
        Public SEVON As Byte
        Public ReySig As Byte
        Public SorT As Byte
        Public StopMode As Byte
        Public PCSEnable As Byte
        Public PCSSignal As Byte
        Public SDEnable As Byte
        Public SDSignal As Byte
        Public SDMode As Byte
        Public RunComPare As Double
        Public MotorCount As Long
        Public LeaveDir As Byte
        'Public LTCSignal As Byte
        'Public LTCMode As Byte
     

        ' Public AxisName As String

        Public IsExist As Boolean
        Public AxisNo As Byte
        Public FilePath As String
        Public EZMode As Byte


        Public Sub Save(ByVal Path As String)
            Try
                Path = Path & ".mtq"
                WriteIni("PulseMode", PulseMode, Path)
                WriteIni("CounterMode", CounterMode, Path)
                WriteIni("SoftELEnable", SoftELEnable, Path)
                'WriteIni("SoftELMax", SoftELMax, Path)
                'WriteIni("SoftELMin", SoftELMin, Path)
                WriteIni("ORGSignal", ORGSignal, Path)
                WriteIni("ORGFilter", ORGFilter, Path)
                WriteIni("ORGMode", ORGMode, Path)
                WriteIni("ORGEZNo", ORGEZNo, Path)
                WriteIni("ORGDir", ORGDir, Path)
                WriteIni("EZSignal", EZSignal, Path)
                WriteIni("ORGSpeedMode", ORGSpeedMode, Path)
                WriteIni("EMGEable", EMGEable, Path)
                WriteIni("EMGSignal", EMGSignal, Path)
                WriteIni("ALMSignal", ALMSignal, Path)
                WriteIni("ALMStopMode", ALMStopMode, Path)
                WriteIni("INPEable", INPEable, Path)
                WriteIni("INPSignal", INPSignal, Path)
                WriteIni("ERCMode", ERCMode, Path)
                WriteIni("ERCSignal", ERCSignal, Path)
                WriteIni("ERCWidth", ERCWidth, Path)
                WriteIni("ERCOfftime", ERCOfftime, Path)
                WriteIni("ERCsel", ERCsel, Path)
                WriteIni("ELMode", ELMode, Path)
                'WriteIni("ELP", ELP, Path)
                'WriteIni("ELM", ELM, Path)
                WriteIni("ERCsel", ERCsel, Path)
                WriteIni("SEVON", SEVON, Path)
                WriteIni("ReySig", ReySig, Path)
                WriteIni("PCSEnable", PCSEnable, Path)
                WriteIni("PCSSignal", PCSSignal, Path)
                WriteIni("SDEnable", SDEnable, Path)
                WriteIni("SDSignal", SDSignal, Path)
                WriteIni("SDMode", SDMode, Path)
                WriteIni("SorT", SorT, Path)
                WriteIni("StopMode", StopMode, Path)
                WriteIni("RunComPare", RunComPare, Path)
                WriteIni("EncodeMode", EncodeMode, Path)
                WriteIni("MotorCount", MotorCount, Path)
                'WriteIni("Min_Vel", Min_Vel, Path)
                'WriteIni("Max_Vel", Max_Vel, Path)
                'WriteIni("Tacc", Tacc, Path)
                'WriteIni("Sacc", Sacc, Path)
                'WriteIni("Tdec", Tdec, Path)
                'WriteIni("Sdec", Sdec, Path)
                'WriteIni("Home_Dis", Home_Dis, Path)
                'WriteIni("Curr_Vel", Curr_Vel, Path)
                'WriteIni("Chg_enable", Chg_enable, Path)
                WriteIni("LeaveDir", LeaveDir, Path)
                WriteIni("UpFlag", "True", Path)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Save(ByVal Path As String, ByVal param As absMtAxis.AxisParam)
            Try

                WriteIni("PulseMode", param.PulseMode, Path)
                WriteIni("CounterMode", param.CounterMode, Path)
                WriteIni("SoftELEnable", param.SoftELEnable, Path)
                'WriteIni("SoftELMax", SoftELMax, Path)
                'WriteIni("SoftELMin", SoftELMin, Path)
                WriteIni("ORGSignal", param.ORGSignal, Path)
                WriteIni("ORGFilter", param.ORGFilter, Path)
                WriteIni("ORGMode", param.ORGMode, Path)
                WriteIni("ORGEZNo", param.ORGEZNo, Path)
                WriteIni("ORGDir", param.ORGDir, Path)
                WriteIni("EZSignal", param.EZSignal, Path)
                WriteIni("ORGSpeedMode", param.ORGSpeedMode, Path)
                WriteIni("EMGEable", param.EMGEable, Path)
                WriteIni("EMGSignal", param.EMGSignal, Path)
                WriteIni("ALMSignal", param.ALMSignal, Path)
                WriteIni("ALMStopMode", param.ALMStopMode, Path)
                WriteIni("INPEable", param.INPEable, Path)
                WriteIni("INPSignal", param.INPSignal, Path)
                WriteIni("ERCMode", param.ERCMode, Path)
                WriteIni("ERCSignal", param.ERCSignal, Path)
                WriteIni("ERCWidth", param.ERCWidth, Path)
                WriteIni("ERCOfftime", param.ERCOfftime, Path)
                WriteIni("ERCsel", param.ERCsel, Path)
                WriteIni("ELMode", param.ELMode, Path)
                'WriteIni("ELP", ELP, Path)
                'WriteIni("ELM", ELM, Path)
                WriteIni("ERCsel", param.ERCsel, Path)
                WriteIni("SEVON", param.SEVON, Path)
                WriteIni("ReySig", param.ReySig, Path)
                WriteIni("PCSEnable", param.PCSEnable, Path)
                WriteIni("PCSSignal", param.PCSSignal, Path)
                WriteIni("SDEnable", param.SDEnable, Path)
                WriteIni("SDSignal", param.SDSignal, Path)
                WriteIni("SDMode", param.SDMode, Path)
                WriteIni("SorT", param.SorT, Path)
                WriteIni("StopMode", param.StopMode, Path)
                WriteIni("RunComPare", param.RunComPare, Path)
                WriteIni("EncodeMode", param.EncodeMode, Path)
                WriteIni("MotorCount", param.MotorCount, Path)
                'WriteIni("Min_Vel", Min_Vel, Path)
                'WriteIni("Max_Vel", Max_Vel, Path)
                'WriteIni("Tacc", Tacc, Path)
                'WriteIni("Sacc", Sacc, Path)
                'WriteIni("Tdec", Tdec, Path)
                'WriteIni("Sdec", Sdec, Path)
                'WriteIni("Home_Dis", Home_Dis, Path)
                'WriteIni("Curr_Vel", Curr_Vel, Path)
                'WriteIni("Chg_enable", Chg_enable, Path)
                WriteIni("LeaveDir", param.LeaveDir, Path)
                WriteIni("UpFlag", "True", Path)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub load(ByVal Path As String)
            Try
                Path = Path & ".mtq"
                Dim UpFlag As Boolean = CBool(ReadIni("UpFlag", "False", Path)) '��������������־
                PulseMode = CByte(ReadIni("PulseMode", 0, Path))
                CounterMode = CByte(ReadIni("CounterMode", 0, Path))
                EncodeMode = CByte(ReadIni("EncodeMode", 0, Path))
                SoftELEnable = CByte(ReadIni("SoftELEnable", 0, Path))
                'SoftELMax = CLng(ReadIni("SoftELMax", 0, Path))
                'SoftELMin = CLng(ReadIni("SoftELMin", 0, Path))
                ORGSignal = CByte(ReadIni("ORGSignal", 0, Path))
                ORGFilter = CByte(ReadIni("ORGFilter", 0, Path))
                ORGMode = CByte(ReadIni("ORGMode", 0, Path))
                EZSignal = CByte(ReadIni("EZSignal", 0, Path))
                ORGEZNo = CByte(ReadIni("ORGEZNo", 0, Path))
                ORGDir = CByte(ReadIni("ORGDir", 0, Path))
                ORGSpeedMode = CByte(ReadIni("ORGSpeedMode", 0, Path))
                EMGEable = CByte(ReadIni("EMGEable", 0, Path))
                EMGSignal = CByte(ReadIni("EMGSignal", 0, Path))
                ALMSignal = CByte(ReadIni("ALMSignal", 0, Path))
                ALMStopMode = CByte(ReadIni("ALMStopMode", 0, Path))
                INPEable = CByte(ReadIni("INPEable", 0, Path))
                INPSignal = CByte(ReadIni("INPSignal", 0, Path))
                ERCMode = CByte(ReadIni("ERCMode", 0, Path))
                ERCSignal = CByte(ReadIni("ERCSignal", 0, Path))
                ERCWidth = CByte(ReadIni("ERCWidth", 0, Path))
                ERCOfftime = CByte(ReadIni("ERCOfftime", 0, Path))
                ELMode = CByte(ReadIni("ELMode", 0, Path))
                If UpFlag = False Then
                    If ELMode = 0 Or ELMode = 1 Then
                        ELMode = 0
                    Else
                        ELMode = 1
                    End If
                Else
                    Dim A = 1
                End If
                'ELP = CByte(ReadIni("ELP", 0, Path))
                'ELM = CByte(ReadIni("ELM", 0, Path))
                ERCsel = CByte(ReadIni("ERCsel", 0, Path))
                SEVON = CByte(ReadIni("SEVON", 0, Path))
                ReySig = CByte(ReadIni("ReySig", 0, Path))
                SorT = CByte(ReadIni("SorT", 0, Path))
                StopMode = CByte(ReadIni("StopMode", 0, Path))
                PCSEnable = CByte(ReadIni("PCSEnable", 0, Path))
                PCSSignal = CByte(ReadIni("PCSSignal", 0, Path))
                SDEnable = CByte(ReadIni("SDEnable", 0, Path))
                SDSignal = CByte(ReadIni("SDSignal", 0, Path))
                SDMode = CByte(ReadIni("SDMode", 0, Path))
                RunComPare = CDbl(ReadIni("RunComPare", 0, Path))
                MotorCount = CDbl(ReadIni("MotorCount", 10000, Path))
                'Min_Vel = CInt(ReadIni("Min_Vel", 0, Path))
                'Max_Vel = CInt(ReadIni("Max_Vel", 0, Path))
                'Tacc = CSng(ReadIni("Tacc", 0, Path))
                'Tdec = CSng(ReadIni("Tdec", 0, Path))
                'Sacc = CInt(ReadIni("Sacc", 0, Path))
                'Sdec = CInt(ReadIni("Sdec", 0, Path))
                'Home_Dis = CInt(ReadIni("Home_Dis", 0, Path))
                LeaveDir = CByte(ReadIni("LeaveDir", 0, Path))

                'Curr_Vel = CInt(ReadIni("Curr_Vel", 0, Path))
                'Chg_enable = CInt(ReadIni("Chg_enable", 0, Path))



            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Structure

End Class
