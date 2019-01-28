<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotionBasicParams
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMotionBasicParams))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCardNo = New System.Windows.Forms.TextBox()
        Me.cboAxisNO = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboSoftELEnable = New System.Windows.Forms.ComboBox()
        Me.cboORGSignal = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.EZSingl_ck = New System.Windows.Forms.Label()
        Me.EZSignal = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LeaveHomeDir = New System.Windows.Forms.ComboBox()
        Me.nupdORGEZ = New System.Windows.Forms.NumericUpDown()
        Me.cboORGFilter = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboORGMode = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboORGDir = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboORGSpeed = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCounter = New System.Windows.Forms.ComboBox()
        Me.cboINPSignal = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboEMGSignal = New System.Windows.Forms.ComboBox()
        Me.cboEMGEable = New System.Windows.Forms.ComboBox()
        Me.cboPulseType = New System.Windows.Forms.ComboBox()
        Me.cboALMSignal = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboALMMode = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboINPEnable = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.MotorCount_nup = New System.Windows.Forms.NumericUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cboEncodeMode = New System.Windows.Forms.ComboBox()
        Me.RunCompare = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.ComSTMode = New System.Windows.Forms.ComboBox()
        Me.ComStopMode = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.ComERCSelSingel = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.ComPCSSignal = New System.Windows.Forms.ComboBox()
        Me.ComSDMode = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.ComPCSEnable = New System.Windows.Forms.ComboBox()
        Me.ComSDSignal = New System.Windows.Forms.ComboBox()
        Me.ComSDEnable = New System.Windows.Forms.ComboBox()
        Me.ComSEVONSignal = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.ComboRaySignel = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboELMode = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboERCOfftime = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboERCWidth = New System.Windows.Forms.ComboBox()
        Me.cboERCEable = New System.Windows.Forms.ComboBox()
        Me.cboERCSignal = New System.Windows.Forms.ComboBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ImportParam = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nupdORGEZ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.MotorCount_nup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RunCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label5.Name = "Label5"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.cboCardNo)
        Me.GroupBox1.Controls.Add(Me.cboAxisNO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'cboCardNo
        '
        resources.ApplyResources(Me.cboCardNo, "cboCardNo")
        Me.cboCardNo.Name = "cboCardNo"
        '
        'cboAxisNO
        '
        resources.ApplyResources(Me.cboAxisNO, "cboAxisNO")
        Me.cboAxisNO.FormattingEnabled = True
        Me.cboAxisNO.Name = "cboAxisNO"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label2.Name = "Label2"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label22.Name = "Label22"
        '
        'cboSoftELEnable
        '
        resources.ApplyResources(Me.cboSoftELEnable, "cboSoftELEnable")
        Me.cboSoftELEnable.FormattingEnabled = True
        Me.cboSoftELEnable.Items.AddRange(New Object() {resources.GetString("cboSoftELEnable.Items"), resources.GetString("cboSoftELEnable.Items1")})
        Me.cboSoftELEnable.Name = "cboSoftELEnable"
        '
        'cboORGSignal
        '
        resources.ApplyResources(Me.cboORGSignal, "cboORGSignal")
        Me.cboORGSignal.FormattingEnabled = True
        Me.cboORGSignal.Items.AddRange(New Object() {resources.GetString("cboORGSignal.Items"), resources.GetString("cboORGSignal.Items1")})
        Me.cboORGSignal.Name = "cboORGSignal"
        '
        'GroupBox3
        '
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Controls.Add(Me.EZSingl_ck)
        Me.GroupBox3.Controls.Add(Me.EZSignal)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.LeaveHomeDir)
        Me.GroupBox3.Controls.Add(Me.cboORGSignal)
        Me.GroupBox3.Controls.Add(Me.nupdORGEZ)
        Me.GroupBox3.Controls.Add(Me.cboORGFilter)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cboORGMode)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.cboORGDir)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.cboORGSpeed)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'EZSingl_ck
        '
        resources.ApplyResources(Me.EZSingl_ck, "EZSingl_ck")
        Me.EZSingl_ck.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.EZSingl_ck.Name = "EZSingl_ck"
        '
        'EZSignal
        '
        resources.ApplyResources(Me.EZSignal, "EZSignal")
        Me.EZSignal.FormattingEnabled = True
        Me.EZSignal.Items.AddRange(New Object() {resources.GetString("EZSignal.Items"), resources.GetString("EZSignal.Items1")})
        Me.EZSignal.Name = "EZSignal"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label1.Name = "Label1"
        '
        'LeaveHomeDir
        '
        resources.ApplyResources(Me.LeaveHomeDir, "LeaveHomeDir")
        Me.LeaveHomeDir.FormattingEnabled = True
        Me.LeaveHomeDir.Items.AddRange(New Object() {resources.GetString("LeaveHomeDir.Items"), resources.GetString("LeaveHomeDir.Items1")})
        Me.LeaveHomeDir.Name = "LeaveHomeDir"
        '
        'nupdORGEZ
        '
        resources.ApplyResources(Me.nupdORGEZ, "nupdORGEZ")
        Me.nupdORGEZ.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
        Me.nupdORGEZ.Name = "nupdORGEZ"
        Me.nupdORGEZ.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cboORGFilter
        '
        resources.ApplyResources(Me.cboORGFilter, "cboORGFilter")
        Me.cboORGFilter.FormattingEnabled = True
        Me.cboORGFilter.Items.AddRange(New Object() {resources.GetString("cboORGFilter.Items"), resources.GetString("cboORGFilter.Items1")})
        Me.cboORGFilter.Name = "cboORGFilter"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label9.Name = "Label9"
        '
        'cboORGMode
        '
        resources.ApplyResources(Me.cboORGMode, "cboORGMode")
        Me.cboORGMode.FormattingEnabled = True
        Me.cboORGMode.Items.AddRange(New Object() {resources.GetString("cboORGMode.Items"), resources.GetString("cboORGMode.Items1"), resources.GetString("cboORGMode.Items2"), resources.GetString("cboORGMode.Items3")})
        Me.cboORGMode.Name = "cboORGMode"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label11.Name = "Label11"
        '
        'cboORGDir
        '
        resources.ApplyResources(Me.cboORGDir, "cboORGDir")
        Me.cboORGDir.FormattingEnabled = True
        Me.cboORGDir.Items.AddRange(New Object() {resources.GetString("cboORGDir.Items"), resources.GetString("cboORGDir.Items1")})
        Me.cboORGDir.Name = "cboORGDir"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label10.Name = "Label10"
        '
        'cboORGSpeed
        '
        resources.ApplyResources(Me.cboORGSpeed, "cboORGSpeed")
        Me.cboORGSpeed.FormattingEnabled = True
        Me.cboORGSpeed.Items.AddRange(New Object() {resources.GetString("cboORGSpeed.Items"), resources.GetString("cboORGSpeed.Items1")})
        Me.cboORGSpeed.Name = "cboORGSpeed"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label8.Name = "Label8"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label7.Name = "Label7"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label21.Name = "Label21"
        '
        'btnLoad
        '
        resources.ApplyResources(Me.btnLoad, "btnLoad")
        Me.btnLoad.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.SaveFileDialog1.Title = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'btnSave
        '
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.btnSave.Name = "btnSave"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label4.Name = "Label4"
        '
        'cboCounter
        '
        resources.ApplyResources(Me.cboCounter, "cboCounter")
        Me.cboCounter.FormattingEnabled = True
        Me.cboCounter.Items.AddRange(New Object() {resources.GetString("cboCounter.Items"), resources.GetString("cboCounter.Items1"), resources.GetString("cboCounter.Items2"), resources.GetString("cboCounter.Items3"), resources.GetString("cboCounter.Items4")})
        Me.cboCounter.Name = "cboCounter"
        '
        'cboINPSignal
        '
        resources.ApplyResources(Me.cboINPSignal, "cboINPSignal")
        Me.cboINPSignal.FormattingEnabled = True
        Me.cboINPSignal.Items.AddRange(New Object() {resources.GetString("cboINPSignal.Items"), resources.GetString("cboINPSignal.Items1")})
        Me.cboINPSignal.Name = "cboINPSignal"
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label25.Name = "Label25"
        '
        'cboEMGSignal
        '
        resources.ApplyResources(Me.cboEMGSignal, "cboEMGSignal")
        Me.cboEMGSignal.FormattingEnabled = True
        Me.cboEMGSignal.Items.AddRange(New Object() {resources.GetString("cboEMGSignal.Items"), resources.GetString("cboEMGSignal.Items1")})
        Me.cboEMGSignal.Name = "cboEMGSignal"
        '
        'cboEMGEable
        '
        resources.ApplyResources(Me.cboEMGEable, "cboEMGEable")
        Me.cboEMGEable.FormattingEnabled = True
        Me.cboEMGEable.Items.AddRange(New Object() {resources.GetString("cboEMGEable.Items"), resources.GetString("cboEMGEable.Items1")})
        Me.cboEMGEable.Name = "cboEMGEable"
        '
        'cboPulseType
        '
        resources.ApplyResources(Me.cboPulseType, "cboPulseType")
        Me.cboPulseType.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.cboPulseType.FormattingEnabled = True
        Me.cboPulseType.Items.AddRange(New Object() {resources.GetString("cboPulseType.Items"), resources.GetString("cboPulseType.Items1"), resources.GetString("cboPulseType.Items2"), resources.GetString("cboPulseType.Items3"), resources.GetString("cboPulseType.Items4"), resources.GetString("cboPulseType.Items5"), resources.GetString("cboPulseType.Items6"), resources.GetString("cboPulseType.Items7")})
        Me.cboPulseType.Name = "cboPulseType"
        '
        'cboALMSignal
        '
        resources.ApplyResources(Me.cboALMSignal, "cboALMSignal")
        Me.cboALMSignal.FormattingEnabled = True
        Me.cboALMSignal.Items.AddRange(New Object() {resources.GetString("cboALMSignal.Items"), resources.GetString("cboALMSignal.Items1")})
        Me.cboALMSignal.Name = "cboALMSignal"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label12.Name = "Label12"
        '
        'cboALMMode
        '
        resources.ApplyResources(Me.cboALMMode, "cboALMMode")
        Me.cboALMMode.FormattingEnabled = True
        Me.cboALMMode.Items.AddRange(New Object() {resources.GetString("cboALMMode.Items"), resources.GetString("cboALMMode.Items1")})
        Me.cboALMMode.Name = "cboALMMode"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label13.Name = "Label13"
        '
        'cboINPEnable
        '
        resources.ApplyResources(Me.cboINPEnable, "cboINPEnable")
        Me.cboINPEnable.FormattingEnabled = True
        Me.cboINPEnable.Items.AddRange(New Object() {resources.GetString("cboINPEnable.Items"), resources.GetString("cboINPEnable.Items1")})
        Me.cboINPEnable.Name = "cboINPEnable"
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.MotorCount_nup)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.cboEncodeMode)
        Me.GroupBox2.Controls.Add(Me.RunCompare)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.ComSTMode)
        Me.GroupBox2.Controls.Add(Me.ComStopMode)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.cboSoftELEnable)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.cboCounter)
        Me.GroupBox2.Controls.Add(Me.cboEMGSignal)
        Me.GroupBox2.Controls.Add(Me.cboEMGEable)
        Me.GroupBox2.Controls.Add(Me.cboPulseType)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'MotorCount_nup
        '
        resources.ApplyResources(Me.MotorCount_nup, "MotorCount_nup")
        Me.MotorCount_nup.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.MotorCount_nup.Name = "MotorCount_nup"
        Me.MotorCount_nup.Value = New Decimal(New Integer() {10000, 0, 0, 0})
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label24.Name = "Label24"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label23.Name = "Label23"
        '
        'cboEncodeMode
        '
        resources.ApplyResources(Me.cboEncodeMode, "cboEncodeMode")
        Me.cboEncodeMode.FormattingEnabled = True
        Me.cboEncodeMode.Items.AddRange(New Object() {resources.GetString("cboEncodeMode.Items"), resources.GetString("cboEncodeMode.Items1")})
        Me.cboEncodeMode.Name = "cboEncodeMode"
        '
        'RunCompare
        '
        resources.ApplyResources(Me.RunCompare, "RunCompare")
        Me.RunCompare.DecimalPlaces = 3
        Me.RunCompare.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.RunCompare.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.RunCompare.Name = "RunCompare"
        Me.RunCompare.Value = New Decimal(New Integer() {2, 0, 0, 65536})
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label27.Name = "Label27"
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label26.Name = "Label26"
        '
        'Label41
        '
        resources.ApplyResources(Me.Label41, "Label41")
        Me.Label41.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label41.Name = "Label41"
        '
        'ComSTMode
        '
        resources.ApplyResources(Me.ComSTMode, "ComSTMode")
        Me.ComSTMode.FormattingEnabled = True
        Me.ComSTMode.Items.AddRange(New Object() {resources.GetString("ComSTMode.Items"), resources.GetString("ComSTMode.Items1")})
        Me.ComSTMode.Name = "ComSTMode"
        '
        'ComStopMode
        '
        resources.ApplyResources(Me.ComStopMode, "ComStopMode")
        Me.ComStopMode.FormattingEnabled = True
        Me.ComStopMode.Items.AddRange(New Object() {resources.GetString("ComStopMode.Items"), resources.GetString("ComStopMode.Items1")})
        Me.ComStopMode.Name = "ComStopMode"
        '
        'GroupBox4
        '
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Controls.Add(Me.Label42)
        Me.GroupBox4.Controls.Add(Me.ComERCSelSingel)
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.Label36)
        Me.GroupBox4.Controls.Add(Me.Label37)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.ComPCSSignal)
        Me.GroupBox4.Controls.Add(Me.ComSDMode)
        Me.GroupBox4.Controls.Add(Me.Label38)
        Me.GroupBox4.Controls.Add(Me.ComPCSEnable)
        Me.GroupBox4.Controls.Add(Me.ComSDSignal)
        Me.GroupBox4.Controls.Add(Me.ComSDEnable)
        Me.GroupBox4.Controls.Add(Me.ComSEVONSignal)
        Me.GroupBox4.Controls.Add(Me.Label34)
        Me.GroupBox4.Controls.Add(Me.ComboRaySignel)
        Me.GroupBox4.Controls.Add(Me.Label35)
        Me.GroupBox4.Controls.Add(Me.cboALMSignal)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.cboALMMode)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.cboELMode)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.cboINPEnable)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.cboERCOfftime)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.cboERCWidth)
        Me.GroupBox4.Controls.Add(Me.cboINPSignal)
        Me.GroupBox4.Controls.Add(Me.cboERCEable)
        Me.GroupBox4.Controls.Add(Me.cboERCSignal)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'Label42
        '
        resources.ApplyResources(Me.Label42, "Label42")
        Me.Label42.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label42.Name = "Label42"
        '
        'ComERCSelSingel
        '
        resources.ApplyResources(Me.ComERCSelSingel, "ComERCSelSingel")
        Me.ComERCSelSingel.FormattingEnabled = True
        Me.ComERCSelSingel.Items.AddRange(New Object() {resources.GetString("ComERCSelSingel.Items"), resources.GetString("ComERCSelSingel.Items1")})
        Me.ComERCSelSingel.Name = "ComERCSelSingel"
        '
        'Label39
        '
        resources.ApplyResources(Me.Label39, "Label39")
        Me.Label39.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label39.Name = "Label39"
        '
        'Label36
        '
        resources.ApplyResources(Me.Label36, "Label36")
        Me.Label36.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label36.Name = "Label36"
        '
        'Label37
        '
        resources.ApplyResources(Me.Label37, "Label37")
        Me.Label37.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label37.Name = "Label37"
        '
        'Label40
        '
        resources.ApplyResources(Me.Label40, "Label40")
        Me.Label40.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label40.Name = "Label40"
        '
        'ComPCSSignal
        '
        resources.ApplyResources(Me.ComPCSSignal, "ComPCSSignal")
        Me.ComPCSSignal.FormattingEnabled = True
        Me.ComPCSSignal.Items.AddRange(New Object() {resources.GetString("ComPCSSignal.Items"), resources.GetString("ComPCSSignal.Items1")})
        Me.ComPCSSignal.Name = "ComPCSSignal"
        '
        'ComSDMode
        '
        resources.ApplyResources(Me.ComSDMode, "ComSDMode")
        Me.ComSDMode.FormattingEnabled = True
        Me.ComSDMode.Items.AddRange(New Object() {resources.GetString("ComSDMode.Items"), resources.GetString("ComSDMode.Items1"), resources.GetString("ComSDMode.Items2"), resources.GetString("ComSDMode.Items3")})
        Me.ComSDMode.Name = "ComSDMode"
        '
        'Label38
        '
        resources.ApplyResources(Me.Label38, "Label38")
        Me.Label38.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label38.Name = "Label38"
        '
        'ComPCSEnable
        '
        resources.ApplyResources(Me.ComPCSEnable, "ComPCSEnable")
        Me.ComPCSEnable.FormattingEnabled = True
        Me.ComPCSEnable.Items.AddRange(New Object() {resources.GetString("ComPCSEnable.Items"), resources.GetString("ComPCSEnable.Items1")})
        Me.ComPCSEnable.Name = "ComPCSEnable"
        '
        'ComSDSignal
        '
        resources.ApplyResources(Me.ComSDSignal, "ComSDSignal")
        Me.ComSDSignal.FormattingEnabled = True
        Me.ComSDSignal.Items.AddRange(New Object() {resources.GetString("ComSDSignal.Items"), resources.GetString("ComSDSignal.Items1")})
        Me.ComSDSignal.Name = "ComSDSignal"
        '
        'ComSDEnable
        '
        resources.ApplyResources(Me.ComSDEnable, "ComSDEnable")
        Me.ComSDEnable.FormattingEnabled = True
        Me.ComSDEnable.Items.AddRange(New Object() {resources.GetString("ComSDEnable.Items"), resources.GetString("ComSDEnable.Items1")})
        Me.ComSDEnable.Name = "ComSDEnable"
        '
        'ComSEVONSignal
        '
        resources.ApplyResources(Me.ComSEVONSignal, "ComSEVONSignal")
        Me.ComSEVONSignal.FormattingEnabled = True
        Me.ComSEVONSignal.Items.AddRange(New Object() {resources.GetString("ComSEVONSignal.Items"), resources.GetString("ComSEVONSignal.Items1")})
        Me.ComSEVONSignal.Name = "ComSEVONSignal"
        '
        'Label34
        '
        resources.ApplyResources(Me.Label34, "Label34")
        Me.Label34.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label34.Name = "Label34"
        '
        'ComboRaySignel
        '
        resources.ApplyResources(Me.ComboRaySignel, "ComboRaySignel")
        Me.ComboRaySignel.FormattingEnabled = True
        Me.ComboRaySignel.Items.AddRange(New Object() {resources.GetString("ComboRaySignel.Items"), resources.GetString("ComboRaySignel.Items1")})
        Me.ComboRaySignel.Name = "ComboRaySignel"
        '
        'Label35
        '
        resources.ApplyResources(Me.Label35, "Label35")
        Me.Label35.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label35.Name = "Label35"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label20.Name = "Label20"
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label19.Name = "Label19"
        '
        'cboELMode
        '
        resources.ApplyResources(Me.cboELMode, "cboELMode")
        Me.cboELMode.FormattingEnabled = True
        Me.cboELMode.Items.AddRange(New Object() {resources.GetString("cboELMode.Items"), resources.GetString("cboELMode.Items1"), resources.GetString("cboELMode.Items2"), resources.GetString("cboELMode.Items3")})
        Me.cboELMode.Name = "cboELMode"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label18.Name = "Label18"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label17.Name = "Label17"
        '
        'cboERCOfftime
        '
        resources.ApplyResources(Me.cboERCOfftime, "cboERCOfftime")
        Me.cboERCOfftime.FormattingEnabled = True
        Me.cboERCOfftime.Items.AddRange(New Object() {resources.GetString("cboERCOfftime.Items"), resources.GetString("cboERCOfftime.Items1"), resources.GetString("cboERCOfftime.Items2"), resources.GetString("cboERCOfftime.Items3"), resources.GetString("cboERCOfftime.Items4"), resources.GetString("cboERCOfftime.Items5"), resources.GetString("cboERCOfftime.Items6")})
        Me.cboERCOfftime.Name = "cboERCOfftime"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label14.Name = "Label14"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label16.Name = "Label16"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.Label15.Name = "Label15"
        '
        'cboERCWidth
        '
        resources.ApplyResources(Me.cboERCWidth, "cboERCWidth")
        Me.cboERCWidth.FormattingEnabled = True
        Me.cboERCWidth.Items.AddRange(New Object() {resources.GetString("cboERCWidth.Items"), resources.GetString("cboERCWidth.Items1"), resources.GetString("cboERCWidth.Items2"), resources.GetString("cboERCWidth.Items3"), resources.GetString("cboERCWidth.Items4"), resources.GetString("cboERCWidth.Items5"), resources.GetString("cboERCWidth.Items6"), resources.GetString("cboERCWidth.Items7"), resources.GetString("cboERCWidth.Items8"), resources.GetString("cboERCWidth.Items9")})
        Me.cboERCWidth.Name = "cboERCWidth"
        '
        'cboERCEable
        '
        resources.ApplyResources(Me.cboERCEable, "cboERCEable")
        Me.cboERCEable.FormattingEnabled = True
        Me.cboERCEable.Items.AddRange(New Object() {resources.GetString("cboERCEable.Items"), resources.GetString("cboERCEable.Items1"), resources.GetString("cboERCEable.Items2"), resources.GetString("cboERCEable.Items3")})
        Me.cboERCEable.Name = "cboERCEable"
        '
        'cboERCSignal
        '
        resources.ApplyResources(Me.cboERCSignal, "cboERCSignal")
        Me.cboERCSignal.FormattingEnabled = True
        Me.cboERCSignal.Items.AddRange(New Object() {resources.GetString("cboERCSignal.Items"), resources.GetString("cboERCSignal.Items1")})
        Me.cboERCSignal.Name = "cboERCSignal"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.OpenFileDialog1.Title = Global.DSD.MotionLib.My.Resources.Resources.String1
        '
        'ImportParam
        '
        resources.ApplyResources(Me.ImportParam, "ImportParam")
        Me.ImportParam.ImageKey = Global.DSD.MotionLib.My.Resources.Resources.String1
        Me.ImportParam.Name = "ImportParam"
        Me.ImportParam.UseVisualStyleBackColor = True
        '
        'frmMotionBasicParams
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ImportParam)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMotionBasicParams"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nupdORGEZ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.MotorCount_nup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RunCompare, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboAxisNO As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboSoftELEnable As System.Windows.Forms.ComboBox
    Friend WithEvents cboORGSignal As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents nupdORGEZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboORGFilter As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboORGMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboORGDir As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboORGSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCounter As System.Windows.Forms.ComboBox
    Friend WithEvents cboINPSignal As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboEMGSignal As System.Windows.Forms.ComboBox
    Friend WithEvents cboEMGEable As System.Windows.Forms.ComboBox
    Friend WithEvents cboPulseType As System.Windows.Forms.ComboBox
    Friend WithEvents cboALMSignal As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboALMMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboINPEnable As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ComSEVONSignal As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents ComboRaySignel As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents ComPCSSignal As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents ComSTMode As System.Windows.Forms.ComboBox
    Friend WithEvents ComStopMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents ComERCSelSingel As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents ComSDMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents ComPCSEnable As System.Windows.Forms.ComboBox
    Friend WithEvents ComSDSignal As System.Windows.Forms.ComboBox
    Friend WithEvents ComSDEnable As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboELMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboERCOfftime As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboERCWidth As System.Windows.Forms.ComboBox
    Friend WithEvents cboERCEable As System.Windows.Forms.ComboBox
    Friend WithEvents cboERCSignal As System.Windows.Forms.ComboBox
    Friend WithEvents RunCompare As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ImportParam As System.Windows.Forms.Button
    Friend WithEvents cboCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LeaveHomeDir As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboEncodeMode As System.Windows.Forms.ComboBox
    Friend WithEvents EZSingl_ck As System.Windows.Forms.Label
    Friend WithEvents EZSignal As System.Windows.Forms.ComboBox
    Friend WithEvents MotorCount_nup As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label24 As System.Windows.Forms.Label
End Class
