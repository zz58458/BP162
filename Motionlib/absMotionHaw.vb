Public MustInherit Class absMotionHaw


    '**************************
    '        variables
    '**************************
    Protected mtAxis() As clsAxis

    '**************************************
    '      MustOverrides  Function
    '**************************************
    ''' <summary>
    ''' ��ʼ��Ӳ���������������ز���
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Overloads Sub InitHaw()

    ''' <summary>
    ''' �ر�Ӳ�����ͷ���Դ
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub CloseHaw()

    ''' <summary>
    ''' ��ʼ��ȫ����
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub OrgAllAxis()

    ''' <summary>
    ''' �ϵ纯��
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub SevOnOff()

    ''' <summary>
    ''' ����ŷ�����
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub CleanError()

    ''' <summary>
    ''' ����ֹͣ�����˶�
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub EmgStop()

    ''' <summary>
    ''' ��ȡIO�źš���λ��Ϣ
    ''' </summary>
    ''' <param name="HardwareNum ">ָ��Ӳ���Ż�Ԫ��,����0��ʼ,PLC��100��ʼ</param>
    ''' <param name="bitNum ">ָ��IOλ��������λ��</param>
    ''' <param name="intAddress">��ַ���˶����ƿ�---0��ʾ��input��ַ��1��ʾ��output��ַ��PLC--��ʾ��ַ</param>
    ''' <returns>����ֵ��0��ʾ�͵�ƽ��1��ʾ�ߵ�ƽ</returns>
    ''' <remarks></remarks>
    Public MustOverride Function ReadIO(ByVal HardwareNum As Short, ByVal bitNum As Short, ByVal intAddress As Short) As Short

    ''' <summary>
    ''' д��IO�źš���λ��Ϣ
    ''' </summary>
    ''' <param name="HardwareNum ">ָ��Ӳ���Ż�Ԫ��,����0��ʼ,PLC��100��ʼ</param>
    ''' <param name="bitNum ">ָ��IOλ��������λ��</param>
    ''' <param name="Value  ">д��ֵ��0��ʾ�͵�ƽ��1��ʾ�ߵ�ƽ</param>
    ''' <param name="intAddress">��ַ���˶����ƿ�---Ĭ��Ϊ0��PLC--��ʾ��ַ</param>
    ''' <remarks></remarks>
    Public MustOverride Sub WriteIO(ByVal HardwareNum As Short, ByVal bitNum As Short, ByVal Value As Short, Optional ByVal intAddress As Short = 0)

   

    ''' <summary>
    ''' 2��ֱ�߲岹
    ''' </summary>
    ''' <param name="Axis1">��1</param>
    ''' <param name="Dist1">��1����</param>
    ''' <param name="Axis2">��2</param>
    ''' <param name="Dist2">��2����</param>
    ''' <param name="Posi_mode">0�����λ�ƣ�1������λ��</param>
    ''' <remarks></remarks>
    Public MustOverride Sub Line2(ByVal Axis1 As Short, ByVal Dist1 As Long, ByVal Axis2 As Short, ByVal Dist2 As Long, ByVal Posi_mode As Short)

    ''' <summary>
    ''' 3��ֱ�߲岹
    ''' </summary>
    ''' <param name="Axis">���б�</param>
    ''' <param name="Dist1">��1����</param>
    ''' <param name="Dist2">��2����</param>
    ''' <param name="Dist3">��3����</param>
    ''' <param name="Posi_mode">0�����λ�ƣ�1������λ��</param>
    ''' <remarks></remarks>
    Public MustOverride Sub Line3(ByVal Axis As ArrayList, ByVal Dist1 As Long, ByVal Dist2 As Long, ByVal Dist3 As Long, ByVal Posi_mode As Short)

    ''' <summary>
    ''' 4��ֱ�߲岹
    ''' </summary>
    ''' <param name="card">ָ���岹�˶��İ忨��, ��Χ��0 �� N - 1 ,NΪ������</param>
    ''' <param name="Dist1">ָ���岹��һ���λ��ֵ����λ��������</param>
    ''' <param name="Dist2">ָ���岹�ڶ����λ��ֵ����λ��������</param>
    ''' <param name="Dist3">ָ���岹�������λ��ֵ����λ��������</param>
    ''' <param name="Dist4">ָ���岹�������λ��ֵ����λ��������</param>
    ''' <param name="Posi_mode"></param>
    ''' <remarks></remarks>
    Public MustOverride Sub Line4(ByVal card As Short, ByVal Dist1 As Long, ByVal Dist2 As Long, ByVal Dist3 As Long, ByVal Dist4 As Long, ByVal Posi_mode As Short)


    ''' <summary>
    ''' �������λ�ò岹��Բ���岹
    ''' </summary>
    ''' <param name="Axis">����б�</param>
    ''' <param name="target_pos">Ŀ��λ���б�ָ��Բ���յ㣩</param>
    ''' <param name="cen_pos">Բ��λ���б�</param>
    ''' <param name="arc_dir">Բ������0��˳ʱ��,1����ʱ��</param>
    ''' <remarks></remarks>
    Public MustOverride Sub ABSLine2(ByVal Axis As ArrayList, ByVal target_pos As ArrayList, ByVal cen_pos As ArrayList, ByVal arc_dir As Short)

    ''' <summary>
    ''' �������λ�ò岹��Բ���岹
    ''' </summary>
    ''' <param name="Axis">����б�</param>
    ''' <param name="target_pos">Ŀ��λ���б�ָ��Բ���յ㣩</param>
    ''' <param name="cen_pos">Բ��λ���б�</param>
    ''' <param name="arc_dir">Բ������0��˳ʱ��,1����ʱ��</param>
    ''' <remarks></remarks>
    Public MustOverride Sub FACLine2(ByVal Axis As ArrayList, ByVal target_pos As ArrayList, ByVal cen_pos As ArrayList, ByVal arc_dir As Short)


    ''' <summary>
    ''' д��������Ӳ�����ݴ洢��
    ''' </summary>
    ''' <param name="strUnitNum">��Ԫ�����Ӳ������</param>
    ''' <param name="strHeadCode">ģʽ����(����д��)</param>
    ''' <param name="intAddress">�����ַ</param>
    ''' <param name="intData">��������</param>
    ''' <param name="timeDelay">��ʱʱ��</param>
    ''' <remarks></remarks>
    Public MustOverride Sub WriteDM(ByVal strUnitNum As String, ByVal strHeadCode As String, _
    ByVal intAddress As String, ByVal intData As String, Optional ByVal timeDelay As Integer = 100)

    ''' <summary>
    ''' д��������Ӳ�����ݴ洢��
    ''' </summary>
    ''' <param name="strUnitNum">��Ԫ�����Ӳ������</param>
    ''' <param name="strHeadCode">ģʽ����(����д��)</param>
    ''' <param name="intAddress">�����ַ</param>
    ''' <param name="intData">��������</param>
    ''' <param name="timeDelay">��ʱʱ��</param>
    ''' <returns>���ض�ȡ����</returns>
    ''' <remarks></remarks>
    Public MustOverride Function ReadDM(ByVal strUnitNum As String, ByVal strHeadCode As String, _
    ByVal intAddress As String, ByVal intData As String, Optional ByVal timeDelay As Integer = 100) As String


    ''' <summary>
    ''' ���ԣ��˶���
    ''' </summary>
    ''' <value>Null</value>
    ''' <returns>���ض���������˶���</returns>
    ''' <remarks></remarks>
    Public MustOverride ReadOnly Property Axis() As absMtAxis()

    Public Overridable ReadOnly Property BaseFun As BaseFunction
        Get
            Return Nothing
        End Get
    End Property


    Public Structure MotionHawParam
        Public Type As Byte
        Public MotionLable As String
        Public AxisParams() As absMtAxis.AxisParam
        Private Name As String
        Private AxisNum As Byte

        Public Sub Save(ByVal Path As String)
            Try
                Path = Path & ".mtq"
                WriteIni("MotionType", Type, Path)
                WriteIni("MotionLable", MotionLable, Path)
                If Name = String.Empty Then
                    Name = "AxisParameters"
                End If
                WriteIni("AxisName", Name, Path)
                If AxisParams IsNot Nothing Then
                    If AxisParams.Length <> 0 Then
                        WriteIni("AxisNum", AxisParams.Length, Path)
                        Dim strAxisPath As String = Path.Substring(0, Path.LastIndexOf("\")) & "\" & Name
                        For i As Byte = 0 To AxisParams.Length - 1
                            AxisParams(i).Save(strAxisPath & i.ToString)
                        Next
                    Else
                        WriteIni("AxisNum", "0", Path)
                    End If
                Else
                    WriteIni("AxisNum", "0", Path)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub Load(ByVal Path As String)
            Try
                Path = Path & ".mtq"
                Type = CByte(ReadIni("MotionType", 0, Path))
                MotionLable = ReadIni("MotionLable", "5400", Path)
                Name = ReadIni("AxisName", "AxisParameters", Path)
                AxisNum = CByte(ReadIni("AxisNum", 0, Path))
                If AxisNum <> 0 Then
                    ReDim AxisParams(AxisNum - 1)
                    Dim strAxisPath As String = Path.Substring(0, Path.LastIndexOf("\")) & "\" & Name
                    For i As Byte = 0 To AxisParams.Length - 1
                        AxisParams(i).load(strAxisPath & i.ToString)
                    Next
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Structure

End Class
