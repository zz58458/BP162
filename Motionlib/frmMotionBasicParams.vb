Public Class frmMotionBasicParams

    ''' <summary>
    ''' 参数文件保存路径  
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
                    MsgBox(XX未发现该轴参数文件)
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
                    If Count = 1 Then '加入轴类型
                        str = str.Substring(str.LastIndexOf("=") + 1, str.Length - str.LastIndexOf("=") - 1)
                        Me.cboCardNo.Text = str
                    End If

                    'If Count = 2 Then '加入轴型号
                    '    str = str.Substring(str.LastIndexOf("=") + 1, str.Length - str.LastIndexOf("=") - 1)
                    '    Me.cboAxisNO.Text = str
                    'End If

                    If Count >= 4 Then '添加轴数目
                        Me.cboAxisNO.Items.Add(str)
                        cboAxisNO.Text = str
                    End If

                  

                    Count += 1
                End While
                Read.Close()
            Else
                MsgBox(XX卡类型文件不存在)
                Exit Sub
            End If


        Catch ex As Exception

        End Try
    End Sub

    'Private Sub ReLoadForm()
    '    Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(My.Settings.Language)
    '    ' Dim s As String = My.Resources.停止
    '    Me.GroupBox1.Text = My.Resources.运动轴选择
    '    Me.Label2.Text = My.Resources.型号
    '    Me.Label3.Text = My.Resources.轴号
    '    Me.GroupBox2.Text = My.Resources.参数设置
    '    Me.Label4.Text = My.Resources.脉冲模式
    '    Me.Label5.Text = My.Resources.编码计数模式
    '    Me.cboCounter.Text = My.Resources.非AB
    '    Me.cboCounter.Items(0) = My.Resources.非AB
    '    Me.Label25.Text = My.Resources.软件极限使能
    '    Me.cboSoftELEnable.Text = My.Resources.无效
    '    Me.cboSoftELEnable.Items(0) = My.Resources.无效
    '    Me.cboSoftELEnable.Items(1) = My.Resources.有效

    '    Me.GroupBox3.Text = My.Resources.原点设置
    '    Me.Label6.Text = My.Resources.原点有效电平
    '    Me.cboORGSignal.Text = My.Resources.高电平
    '    Me.cboORGSignal.Items(1) = My.Resources.高电平
    '    Me.cboORGSignal.Items(0) = My.Resources.低电平
    '    Me.Label7.Text = My.Resources.原点滤波使能
    '    Me.cboORGFilter.Text = My.Resources.允许
    '    Me.cboORGFilter.Items(1) = My.Resources.允许
    '    Me.cboORGFilter.Items(0) = My.Resources.禁止
    '    Me.Label8.Text = My.Resources.回原点模式
    '    Me.Label9.Text = My.Resources.回原点EZ个数
    '    Me.Label10.Text = My.Resources.回原点方向
    '    Me.cboORGDir.Text = My.Resources.反向
    '    Me.cboORGDir.Items(1) = My.Resources.反向
    '    Me.cboORGDir.Items(0) = My.Resources.正向
    '    Me.Label11.Text = My.Resources.回原点速度模式
    '    Me.cboORGSpeed.Text = My.Resources.低速
    '    Me.cboORGSpeed.Items(0) = My.Resources.低速
    '    Me.cboORGSpeed.Items(1) = My.Resources.高速
    '    Me.Label1.Text = My.Resources.离开原点方向
    '    Me.LeaveHomeDir.Text = My.Resources.反向
    '    Me.LeaveHomeDir.Items(0) = My.Resources.反向
    '    Me.LeaveHomeDir.Items(1) = My.Resources.正向
    '    Me.Label21.Text = My.Resources.EMG信号使能
    '    Me.cboEMGEable.Text = My.Resources.无效
    '    Me.cboEMGEable.Items(0) = My.Resources.无效
    '    Me.cboEMGEable.Items(1) = My.Resources.有效
    '    Me.Label22.Text = My.Resources.EMG有效电平
    '    Me.cboEMGSignal.Text = My.Resources.低电平
    '    Me.cboEMGSignal.Items(0) = My.Resources.低电平
    '    Me.cboEMGSignal.Items(1) = My.Resources.高电平
    '    Me.Label41.Text = My.Resources.Stop模式
    '    Me.ComStopMode.Text = My.Resources.立即停止
    '    Me.ComStopMode.Items(1) = My.Resources.立即停止
    '    Me.ComStopMode.Items(0) = My.Resources.减速停止
    '    Me.Label26.Text = My.Resources.速度曲线模式
    '    Me.ComSTMode.Text = My.Resources.S型
    '    Me.ComSTMode.Items(0) = My.Resources.S型
    '    Me.ComSTMode.Items(1) = My.Resources.T型
    '    Me.Label27.Text = My.Resources.传动比
    '    Me.GroupBox4.Text = My.Resources.驱动参数设置
    '    Me.Label34.Text = My.Resources.SEVON电平
    '    Me.ComSEVONSignal.Text = My.Resources.低电平
    '    Me.ComSEVONSignal.Items(0) = My.Resources.低电平
    '    Me.ComSEVONSignal.Items(1) = My.Resources.高电平
    '    Me.Label35.Text = My.Resources.伺服RAY电平
    '    Me.ComboRaySignel.Text = My.Resources.高电平
    '    Me.ComboRaySignel.Items(1) = My.Resources.高电平
    '    Me.ComboRaySignel.Items(0) = My.Resources.低电平
    '    Me.Label12.Text = My.Resources.ALM有效电平
    '    Me.cboALMSignal.Text = My.Resources.低电平
    '    Me.cboALMSignal.Items(0) = My.Resources.低电平
    '    Me.cboALMSignal.Items(1) = My.Resources.高电平
    '    Me.Label13.Text = My.Resources.ALM制动方式
    '    Me.cboALMMode.Text = My.Resources.立即停止
    '    Me.cboALMMode.Items(0) = My.Resources.立即停止
    '    Me.cboALMMode.Items(1) = My.Resources.减速停止
    '    Me.Label14.Text = My.Resources.INP信号使能
    '    Me.cboINPEnable.Text = My.Resources.无效
    '    Me.cboINPEnable.Items(0) = My.Resources.无效
    '    Me.cboINPEnable.Items(1) = My.Resources.有效
    '    Me.Label15.Text = My.Resources.INP有效电平
    '    Me.cboINPSignal.Text = My.Resources.低电平
    '    Me.cboINPSignal.Items(0) = My.Resources.低电平
    '    Me.cboINPSignal.Items(1) = My.Resources.高电平
    '    Me.Label16.Text = My.Resources.ERC信号使能
    '    Me.Label17.Text = My.Resources.ERC有效电平
    '    Me.cboERCSignal.Text = My.Resources.高电平
    '    Me.cboERCSignal.Items(1) = My.Resources.高电平
    '    Me.cboERCSignal.Items(0) = My.Resources.低电平
    '    Me.Label18.Text = My.Resources.ERC有效宽度
    '    Me.Label19.Text = My.Resources.ERC关断时间
    '    Me.Label42.Text = My.Resources.ERC信号
    '    Me.Label20.Text = My.Resources.EL设置
    '    Me.Label38.Text = My.Resources.SD允许或禁止
    '    Me.ComSDEnable.Text = My.Resources.禁止
    '    Me.ComSDEnable.Items(0) = My.Resources.禁止
    '    Me.ComSDEnable.Items(1) = My.Resources.允许
    '    Me.Label37.Text = My.Resources.SD有效电平
    '    Me.ComSDSignal.Text = My.Resources.低电平
    '    Me.ComSDSignal.Items(0) = My.Resources.低电平
    '    Me.ComSDSignal.Items(1) = My.Resources.高电平
    '    Me.Label36.Text = My.Resources.SD工作模式
    '    Me.Label40.Text = My.Resources.PCS允许或禁止
    '    Me.ComPCSEnable.Text = My.Resources.无效
    '    Me.ComPCSEnable.Items(0) = My.Resources.无效
    '    Me.ComPCSEnable.Items(1) = My.Resources.有效
    '    Me.Label39.Text = My.Resources.PCS有效电平
    '    Me.ComPCSSignal.Text = My.Resources.低电平
    '    Me.ComPCSSignal.Items(0) = My.Resources.低电平
    '    Me.ComPCSSignal.Items(1) = My.Resources.高电平
    '    Me.btnLoad.Text = My.Resources.读取参数
    '    Me.btnSave.Text = My.Resources.保存参数
    '    Me.ImportParam.Text = My.Resources.参数导入


    '    ' Me.Text = Globalization.CultureInfo.CurrentUICulture.Name
    'End Sub
 
    Private Sub cboAxisNO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAxisNO.SelectedIndexChanged
        btnLoad_Click(Nothing, Nothing)
    End Sub

End Class