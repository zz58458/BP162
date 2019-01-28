Public Class frmMotionBasicParams

    ''' <summary>
    ''' �����ļ�����·��  
    ''' </summary>
    ''' <remarks></remarks>

    Dim Axis2410 As New _2410Base
    Dim MtParams As absMotionHaw.MotionHawParam
    Dim axisNum As Byte = 0

  

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim params As New absMtAxis.AxisParam
            params.FilePath = My.Application.Info.DirectoryPath
            params.MotorCount = Me.MotorCount_nup.Value
            params.PulseMode = cboPulseType.SelectedIndex
            params.CounterMode = cboCounter.SelectedIndex
            params.EncodeMode = cboEncodeMode.SelectedIndex
            params.ALMSignal = cboALMSignal.SelectedIndex
            params.ALMStopMode = cboALMMode.SelectedIndex
            params.ELMode = cboELMode.SelectedIndex
            params.EMGEable = cboEMGEable.SelectedIndex
            params.EMGSignal = cboEMGSignal.SelectedIndex
            params.ERCMode = cboERCEable.SelectedIndex
            params.ERCOfftime = cboERCOfftime.SelectedIndex
            params.ERCSignal = cboERCSignal.SelectedIndex
            params.ERCWidth = cboERCWidth.SelectedIndex
            params.ERCsel = ComERCSelSingel.SelectedIndex
            params.INPEable = cboINPEnable.SelectedIndex
            params.INPSignal = cboINPSignal.SelectedIndex
            params.EZSignal = EZSignal.SelectedIndex
            params.ORGDir = cboORGDir.SelectedIndex
            params.ORGEZNo = nupdORGEZ.Value
            params.ORGFilter = cboORGFilter.SelectedIndex
            params.ORGMode = cboORGMode.SelectedIndex
            params.ORGSignal = cboORGSignal.SelectedIndex
            params.ORGSpeedMode = cboORGSpeed.SelectedIndex
            params.SoftELEnable = cboSoftELEnable.SelectedIndex
            'params.SoftELMax = nupdELP.Value
            'params.SoftELMin = nupdELM.Value
            params.SEVON = ComSEVONSignal.SelectedIndex
            params.SorT = ComSTMode.SelectedIndex
            params.ReySig = ComboRaySignel.SelectedIndex
            params.StopMode = ComStopMode.SelectedIndex
            params.PCSEnable = ComPCSEnable.SelectedIndex
            params.PCSSignal = ComPCSSignal.SelectedIndex
            params.SDEnable = ComSDEnable.SelectedIndex
            params.SDSignal = ComSDSignal.SelectedIndex
            params.SDMode = ComSDMode.SelectedIndex
            params.RunComPare = RunCompare.Value
            params.LeaveDir = LeaveHomeDir.SelectedIndex
            'params.Max_Vel = CInt(TexMaxSed.Text)
            'params.Min_Vel = CInt(TexMinSed.Text)
            'params.Sacc = CInt(TexAddDis.Text)
            'params.Sdec = CInt(TexCutDis.Text)
            'params.Tacc = CSng(TexAddSedTm.Text)
            'params.Tdec = CSng(TexCutSedTm.Text)
            'params.Home_Dis = CInt(HomeOutDis.Text)


            If params.FilePath IsNot Nothing And params.FilePath <> String.Empty And IO.Directory.Exists(params.FilePath) Then
                Dim dir As String = params.FilePath.Substring(0, params.FilePath.LastIndexOf("\")) & "\Config"
                If Not IO.Directory.Exists(dir) Then
                    IO.Directory.CreateDirectory(dir)
                End If

                params.Save(dir & "\" & cboAxisNO.Text & "BaseParam")

            End If
            'Else
            '    SaveFileDialog1.Filter = "MotionParams Files (*.mtp)|*.mtp||"
            '    If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '        params.Save(SaveFileDialog1.FileName.Substring(0, SaveFileDialog1.FileName.LastIndexOf(".mtp")))
            '    End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Try
            Dim params As New absMtAxis.AxisParam
            Dim filepath As String = My.Application.Info.DirectoryPath
            If filepath IsNot Nothing And filepath <> String.Empty And IO.Directory.Exists(filepath) Then
                Dim dir As String = filepath.Substring(0, filepath.LastIndexOf("\")) & "\Config" & "\" & cboAxisNO.Text & "BaseParam"
                If IO.File.Exists(dir & ".mtq") Then
                    params.load(dir)
                    RefreshControls(params)
                Else
                    MsgBox(XXδ���ָ�������ļ�)
                End If



                'Else
                '    OpenFileDialog1.Filter = "MotionParams Files (*.mtp)|*.mtp||"
                '    If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '        params.load(OpenFileDialog1.FileName.Substring(0, OpenFileDialog1.FileName.LastIndexOf(".mtp")))

                '        RefreshControls(params)
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RefreshControls(ByVal params As absMtAxis.AxisParam)
        Try
            cboPulseType.SelectedIndex = params.PulseMode
            cboCounter.SelectedIndex = params.CounterMode
            cboEncodeMode.SelectedIndex = params.EncodeMode
            cboALMSignal.SelectedIndex = params.ALMSignal
            cboALMMode.SelectedIndex = params.ALMStopMode
            cboELMode.SelectedIndex = params.ELMode
            cboEMGEable.SelectedIndex = params.EMGEable
            cboEMGSignal.SelectedIndex = params.EMGSignal
            cboERCEable.SelectedIndex = params.ERCMode
            cboERCOfftime.SelectedIndex = params.ERCOfftime
            cboERCSignal.SelectedIndex = params.ERCSignal
            cboERCWidth.SelectedIndex = params.ERCWidth
            ComERCSelSingel.SelectedIndex = params.ERCsel
            cboINPEnable.SelectedIndex = params.INPEable
            cboINPSignal.SelectedIndex = params.INPSignal
            cboORGDir.SelectedIndex = params.ORGDir
            nupdORGEZ.Value = params.ORGEZNo
            cboORGFilter.SelectedIndex = params.ORGFilter
            cboORGMode.SelectedIndex = params.ORGMode
            EZSignal.SelectedIndex = params.EZSignal
            cboORGSignal.SelectedIndex = params.ORGSignal
            cboORGSpeed.SelectedIndex = params.ORGSpeedMode
            cboSoftELEnable.SelectedIndex = params.SoftELEnable
            ComSEVONSignal.SelectedIndex = params.SEVON
            ComSTMode.SelectedIndex = params.SorT
            ComboRaySignel.SelectedIndex = params.ReySig
            ComStopMode.SelectedIndex = params.StopMode
            ComPCSEnable.SelectedIndex = params.PCSEnable
            ComPCSSignal.SelectedIndex = params.PCSSignal
            ComSDEnable.SelectedIndex = params.SDEnable
            ComSDSignal.SelectedIndex = params.SDSignal
            ComSDMode.SelectedIndex = params.SDMode
            RunCompare.Value = params.RunComPare
            LeaveHomeDir.SelectedIndex = params.LeaveDir

            Me.MotorCount_nup.Value = params.MotorCount

            'nupdELP.Value = params.SoftELMax
            'nupdELM.Value = params.SoftELMin
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub ImportParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportParam.Click
        Try
            Dim params As New absMtAxis.AxisParam
            Dim filepath As String = My.Application.Info.DirectoryPath
            Dim open As New System.Windows.Forms.OpenFileDialog
            Dim dir As String = filepath.Substring(0, filepath.LastIndexOf("\")) & "\Config"
            'open.InitialDirectory = dir
            open.Filter = "(*.mtq)|*.mtq||"
            If IO.Directory.Exists(dir) Then
                If open.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dir = open.FileName
                Else
                    Exit Sub
                End If

            End If

            dir = dir.Substring(0, dir.LastIndexOf("."))
            params.load(dir)

            RefreshControls(params)
            'Else
            ' OpenFileDialog1.Filter = "MotionParams Files (*.mtp)|*.mtp||"
            '    If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '        params.load(OpenFileDialog1.FileName.Substring(0, OpenFileDialog1.FileName.LastIndexOf(".mtp")))

            '        RefreshControls(params)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmMotionBasicParams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Read As IO.StreamReader
        Dim mpath As String = My.Application.Info.DirectoryPath
        Dim str As String
        Dim Count As Int16 = 0

        If Me.cboAxisNO.Items.Count > 0 Then
            Me.cboAxisNO.SelectedIndex = 0
        End If

        My.Settings.Language = Language
        'ReLoadForm()

        mpath = mpath.Substring(0, mpath.LastIndexOf("\")) & "\Config"

        Try
            If IO.File.Exists(mpath & "\AxisName.mtq") Then
                Read = New IO.StreamReader(mpath & "\AxisName.mtq")
                While True
                    str = Read.ReadLine
                    If str = "" Then
                        Exit While
                    End If
                    If Count = 1 Then '����������
                        str = str.Substring(str.LastIndexOf("=") + 1, str.Length - str.LastIndexOf("=") - 1)
                        Me.cboCardNo.Text = str
                    End If

                    'If Count = 2 Then '�������ͺ�
                    '    str = str.Substring(str.LastIndexOf("=") + 1, str.Length - str.LastIndexOf("=") - 1)
                    '    Me.cboAxisNO.Text = str
                    'End If

                    If Count >= 4 Then '�������Ŀ
                        Me.cboAxisNO.Items.Add(str)
                        cboAxisNO.Text = str
                    End If

                  

                    Count += 1
                End While
                Read.Close()
            Else
                MsgBox(XX�������ļ�������)
                Exit Sub
            End If


        Catch ex As Exception

        End Try
    End Sub

    'Private Sub ReLoadForm()
    '    Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(My.Settings.Language)
    '    ' Dim s As String = My.Resources.ֹͣ
    '    Me.GroupBox1.Text = My.Resources.�˶���ѡ��
    '    Me.Label2.Text = My.Resources.�ͺ�
    '    Me.Label3.Text = My.Resources.���
    '    Me.GroupBox2.Text = My.Resources.��������
    '    Me.Label4.Text = My.Resources.����ģʽ
    '    Me.Label5.Text = My.Resources.�������ģʽ
    '    Me.cboCounter.Text = My.Resources.��AB
    '    Me.cboCounter.Items(0) = My.Resources.��AB
    '    Me.Label25.Text = My.Resources.�������ʹ��
    '    Me.cboSoftELEnable.Text = My.Resources.��Ч
    '    Me.cboSoftELEnable.Items(0) = My.Resources.��Ч
    '    Me.cboSoftELEnable.Items(1) = My.Resources.��Ч

    '    Me.GroupBox3.Text = My.Resources.ԭ������
    '    Me.Label6.Text = My.Resources.ԭ����Ч��ƽ
    '    Me.cboORGSignal.Text = My.Resources.�ߵ�ƽ
    '    Me.cboORGSignal.Items(1) = My.Resources.�ߵ�ƽ
    '    Me.cboORGSignal.Items(0) = My.Resources.�͵�ƽ
    '    Me.Label7.Text = My.Resources.ԭ���˲�ʹ��
    '    Me.cboORGFilter.Text = My.Resources.����
    '    Me.cboORGFilter.Items(1) = My.Resources.����
    '    Me.cboORGFilter.Items(0) = My.Resources.��ֹ
    '    Me.Label8.Text = My.Resources.��ԭ��ģʽ
    '    Me.Label9.Text = My.Resources.��ԭ��EZ����
    '    Me.Label10.Text = My.Resources.��ԭ�㷽��
    '    Me.cboORGDir.Text = My.Resources.����
    '    Me.cboORGDir.Items(1) = My.Resources.����
    '    Me.cboORGDir.Items(0) = My.Resources.����
    '    Me.Label11.Text = My.Resources.��ԭ���ٶ�ģʽ
    '    Me.cboORGSpeed.Text = My.Resources.����
    '    Me.cboORGSpeed.Items(0) = My.Resources.����
    '    Me.cboORGSpeed.Items(1) = My.Resources.����
    '    Me.Label1.Text = My.Resources.�뿪ԭ�㷽��
    '    Me.LeaveHomeDir.Text = My.Resources.����
    '    Me.LeaveHomeDir.Items(0) = My.Resources.����
    '    Me.LeaveHomeDir.Items(1) = My.Resources.����
    '    Me.Label21.Text = My.Resources.EMG�ź�ʹ��
    '    Me.cboEMGEable.Text = My.Resources.��Ч
    '    Me.cboEMGEable.Items(0) = My.Resources.��Ч
    '    Me.cboEMGEable.Items(1) = My.Resources.��Ч
    '    Me.Label22.Text = My.Resources.EMG��Ч��ƽ
    '    Me.cboEMGSignal.Text = My.Resources.�͵�ƽ
    '    Me.cboEMGSignal.Items(0) = My.Resources.�͵�ƽ
    '    Me.cboEMGSignal.Items(1) = My.Resources.�ߵ�ƽ
    '    Me.Label41.Text = My.Resources.Stopģʽ
    '    Me.ComStopMode.Text = My.Resources.����ֹͣ
    '    Me.ComStopMode.Items(1) = My.Resources.����ֹͣ
    '    Me.ComStopMode.Items(0) = My.Resources.����ֹͣ
    '    Me.Label26.Text = My.Resources.�ٶ�����ģʽ
    '    Me.ComSTMode.Text = My.Resources.S��
    '    Me.ComSTMode.Items(0) = My.Resources.S��
    '    Me.ComSTMode.Items(1) = My.Resources.T��
    '    Me.Label27.Text = My.Resources.������
    '    Me.GroupBox4.Text = My.Resources.������������
    '    Me.Label34.Text = My.Resources.SEVON��ƽ
    '    Me.ComSEVONSignal.Text = My.Resources.�͵�ƽ
    '    Me.ComSEVONSignal.Items(0) = My.Resources.�͵�ƽ
    '    Me.ComSEVONSignal.Items(1) = My.Resources.�ߵ�ƽ
    '    Me.Label35.Text = My.Resources.�ŷ�RAY��ƽ
    '    Me.ComboRaySignel.Text = My.Resources.�ߵ�ƽ
    '    Me.ComboRaySignel.Items(1) = My.Resources.�ߵ�ƽ
    '    Me.ComboRaySignel.Items(0) = My.Resources.�͵�ƽ
    '    Me.Label12.Text = My.Resources.ALM��Ч��ƽ
    '    Me.cboALMSignal.Text = My.Resources.�͵�ƽ
    '    Me.cboALMSignal.Items(0) = My.Resources.�͵�ƽ
    '    Me.cboALMSignal.Items(1) = My.Resources.�ߵ�ƽ
    '    Me.Label13.Text = My.Resources.ALM�ƶ���ʽ
    '    Me.cboALMMode.Text = My.Resources.����ֹͣ
    '    Me.cboALMMode.Items(0) = My.Resources.����ֹͣ
    '    Me.cboALMMode.Items(1) = My.Resources.����ֹͣ
    '    Me.Label14.Text = My.Resources.INP�ź�ʹ��
    '    Me.cboINPEnable.Text = My.Resources.��Ч
    '    Me.cboINPEnable.Items(0) = My.Resources.��Ч
    '    Me.cboINPEnable.Items(1) = My.Resources.��Ч
    '    Me.Label15.Text = My.Resources.INP��Ч��ƽ
    '    Me.cboINPSignal.Text = My.Resources.�͵�ƽ
    '    Me.cboINPSignal.Items(0) = My.Resources.�͵�ƽ
    '    Me.cboINPSignal.Items(1) = My.Resources.�ߵ�ƽ
    '    Me.Label16.Text = My.Resources.ERC�ź�ʹ��
    '    Me.Label17.Text = My.Resources.ERC��Ч��ƽ
    '    Me.cboERCSignal.Text = My.Resources.�ߵ�ƽ
    '    Me.cboERCSignal.Items(1) = My.Resources.�ߵ�ƽ
    '    Me.cboERCSignal.Items(0) = My.Resources.�͵�ƽ
    '    Me.Label18.Text = My.Resources.ERC��Ч���
    '    Me.Label19.Text = My.Resources.ERC�ض�ʱ��
    '    Me.Label42.Text = My.Resources.ERC�ź�
    '    Me.Label20.Text = My.Resources.EL����
    '    Me.Label38.Text = My.Resources.SD������ֹ
    '    Me.ComSDEnable.Text = My.Resources.��ֹ
    '    Me.ComSDEnable.Items(0) = My.Resources.��ֹ
    '    Me.ComSDEnable.Items(1) = My.Resources.����
    '    Me.Label37.Text = My.Resources.SD��Ч��ƽ
    '    Me.ComSDSignal.Text = My.Resources.�͵�ƽ
    '    Me.ComSDSignal.Items(0) = My.Resources.�͵�ƽ
    '    Me.ComSDSignal.Items(1) = My.Resources.�ߵ�ƽ
    '    Me.Label36.Text = My.Resources.SD����ģʽ
    '    Me.Label40.Text = My.Resources.PCS������ֹ
    '    Me.ComPCSEnable.Text = My.Resources.��Ч
    '    Me.ComPCSEnable.Items(0) = My.Resources.��Ч
    '    Me.ComPCSEnable.Items(1) = My.Resources.��Ч
    '    Me.Label39.Text = My.Resources.PCS��Ч��ƽ
    '    Me.ComPCSSignal.Text = My.Resources.�͵�ƽ
    '    Me.ComPCSSignal.Items(0) = My.Resources.�͵�ƽ
    '    Me.ComPCSSignal.Items(1) = My.Resources.�ߵ�ƽ
    '    Me.btnLoad.Text = My.Resources.��ȡ����
    '    Me.btnSave.Text = My.Resources.�������
    '    Me.ImportParam.Text = My.Resources.��������


    '    ' Me.Text = Globalization.CultureInfo.CurrentUICulture.Name
    'End Sub
 
    Private Sub cboAxisNO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAxisNO.SelectedIndexChanged
        btnLoad_Click(Nothing, Nothing)
    End Sub

End Class