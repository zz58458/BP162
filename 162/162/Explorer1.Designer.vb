<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Explorer1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Friend WithEvents ToolStripContainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents TreeNodeImageList As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents BackToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ForwardToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FoldersToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListViewToolStripButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmallIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FoldersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ListViewLargeImageList As System.Windows.Forms.ImageList
    Friend WithEvents ListViewSmallImageList As System.Windows.Forms.ImageList

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Explorer1))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("系统参数")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("膜参数")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("相机参数")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("参数", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PParam")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("OutPParam")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("IOConfigParam", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("R1BaseParam")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("R2BaseParam")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("R3BaseParam")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("R4BaseParam")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("XBaseParam")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("YBaseParam")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Z1BaseParam")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Z2BaseParam")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Z3BaseParam")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Z4BaseParam")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Z5BaseParam")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CVBaseParam")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("AxisConfigParam", New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9, TreeNode10, TreeNode11, TreeNode12, TreeNode13, TreeNode14, TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode19})
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("AxisMotionParam")
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.BackToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ForwardToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.FoldersToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ListViewToolStripButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LargeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SmallIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FoldersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripContainer = New System.Windows.Forms.ToolStripContainer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.XPanderPanelList1 = New BSE.Windows.Forms.XPanderPanelList()
        Me.XPanderPanel1 = New BSE.Windows.Forms.XPanderPanel()
        Me.TreeView3 = New System.Windows.Forms.TreeView()
        Me.XPanderPanel2 = New BSE.Windows.Forms.XPanderPanel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.XPanderPanel3 = New BSE.Windows.Forms.XPanderPanel()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TextBox33 = New System.Windows.Forms.TextBox()
        Me.TextBox34 = New System.Windows.Forms.TextBox()
        Me.TextBox35 = New System.Windows.Forms.TextBox()
        Me.TextBox36 = New System.Windows.Forms.TextBox()
        Me.TextBox37 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBox32 = New System.Windows.Forms.TextBox()
        Me.TextBox31 = New System.Windows.Forms.TextBox()
        Me.TextBox28 = New System.Windows.Forms.TextBox()
        Me.TextBox29 = New System.Windows.Forms.TextBox()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.DomainUpDown19 = New System.Windows.Forms.DomainUpDown()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.DomainUpDown14 = New System.Windows.Forms.DomainUpDown()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.DomainUpDown15 = New System.Windows.Forms.DomainUpDown()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.DomainUpDown16 = New System.Windows.Forms.DomainUpDown()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.DomainUpDown17 = New System.Windows.Forms.DomainUpDown()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.DomainUpDown18 = New System.Windows.Forms.DomainUpDown()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.DomainUpDown13 = New System.Windows.Forms.DomainUpDown()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.DomainUpDown11 = New System.Windows.Forms.DomainUpDown()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.DomainUpDown12 = New System.Windows.Forms.DomainUpDown()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.DomainUpDown10 = New System.Windows.Forms.DomainUpDown()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.DomainUpDown9 = New System.Windows.Forms.DomainUpDown()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.DomainUpDown5 = New System.Windows.Forms.DomainUpDown()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.DomainUpDown6 = New System.Windows.Forms.DomainUpDown()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.DomainUpDown7 = New System.Windows.Forms.DomainUpDown()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.DomainUpDown8 = New System.Windows.Forms.DomainUpDown()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.DomainUpDown3 = New System.Windows.Forms.DomainUpDown()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.DomainUpDown4 = New System.Windows.Forms.DomainUpDown()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.DomainUpDown2 = New System.Windows.Forms.DomainUpDown()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.DomainUpDown1 = New System.Windows.Forms.DomainUpDown()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ListView = New System.Windows.Forms.ListView()
        Me.StatusStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.ToolStripContainer.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer.ContentPanel.SuspendLayout()
        Me.ToolStripContainer.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.XPanderPanelList1.SuspendLayout()
        Me.XPanderPanel1.SuspendLayout()
        Me.XPanderPanel2.SuspendLayout()
        Me.XPanderPanel3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 25)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(986, 22)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(32, 17)
        Me.ToolStripStatusLabel.Text = "状态"
        '
        'ToolStrip
        '
        Me.ToolStrip.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackToolStripButton, Me.ForwardToolStripButton, Me.ToolStripSeparator7, Me.FoldersToolStripButton, Me.ToolStripSeparator8, Me.ListViewToolStripButton})
        Me.ToolStrip.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(221, 25)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'BackToolStripButton
        '
        Me.BackToolStripButton.Enabled = False
        Me.BackToolStripButton.Image = CType(resources.GetObject("BackToolStripButton.Image"), System.Drawing.Image)
        Me.BackToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.BackToolStripButton.Name = "BackToolStripButton"
        Me.BackToolStripButton.Size = New System.Drawing.Size(52, 22)
        Me.BackToolStripButton.Text = "后退"
        Me.BackToolStripButton.ToolTipText = "后退到上一项"
        '
        'ForwardToolStripButton
        '
        Me.ForwardToolStripButton.Enabled = False
        Me.ForwardToolStripButton.Image = CType(resources.GetObject("ForwardToolStripButton.Image"), System.Drawing.Image)
        Me.ForwardToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.ForwardToolStripButton.Name = "ForwardToolStripButton"
        Me.ForwardToolStripButton.Size = New System.Drawing.Size(52, 22)
        Me.ForwardToolStripButton.Text = "前进"
        Me.ForwardToolStripButton.ToolTipText = "前进到下一项"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'FoldersToolStripButton
        '
        Me.FoldersToolStripButton.Checked = True
        Me.FoldersToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FoldersToolStripButton.Image = CType(resources.GetObject("FoldersToolStripButton.Image"), System.Drawing.Image)
        Me.FoldersToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.FoldersToolStripButton.Name = "FoldersToolStripButton"
        Me.FoldersToolStripButton.Size = New System.Drawing.Size(64, 22)
        Me.FoldersToolStripButton.Text = "文件夹"
        Me.FoldersToolStripButton.ToolTipText = "切换文件夹视图"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ListViewToolStripButton
        '
        Me.ListViewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListViewToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListToolStripMenuItem, Me.DetailsToolStripMenuItem, Me.LargeIconsToolStripMenuItem, Me.SmallIconsToolStripMenuItem, Me.TileToolStripMenuItem})
        Me.ListViewToolStripButton.Image = CType(resources.GetObject("ListViewToolStripButton.Image"), System.Drawing.Image)
        Me.ListViewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.ListViewToolStripButton.Name = "ListViewToolStripButton"
        Me.ListViewToolStripButton.Size = New System.Drawing.Size(29, 22)
        Me.ListViewToolStripButton.Text = "视图"
        '
        'ListToolStripMenuItem
        '
        Me.ListToolStripMenuItem.Name = "ListToolStripMenuItem"
        Me.ListToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ListToolStripMenuItem.Text = "列表"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Checked = True
        Me.DetailsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.DetailsToolStripMenuItem.Text = "详细信息"
        '
        'LargeIconsToolStripMenuItem
        '
        Me.LargeIconsToolStripMenuItem.Name = "LargeIconsToolStripMenuItem"
        Me.LargeIconsToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.LargeIconsToolStripMenuItem.Text = "大图标"
        '
        'SmallIconsToolStripMenuItem
        '
        Me.SmallIconsToolStripMenuItem.Name = "SmallIconsToolStripMenuItem"
        Me.SmallIconsToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.SmallIconsToolStripMenuItem.Text = "小图标"
        '
        'TileToolStripMenuItem
        '
        Me.TileToolStripMenuItem.Name = "TileToolStripMenuItem"
        Me.TileToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.TileToolStripMenuItem.Text = "平铺"
        '
        'MenuStrip
        '
        Me.MenuStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem, Me.ToolStripTextBox1, Me.ToolStripTextBox2})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 25)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(986, 27)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.ToolStripSeparator1, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator2, Me.PrintToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(58, 23)
        Me.FileToolStripMenuItem.Text = "文件(&F)"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.NewToolStripMenuItem.Text = "新建(&N)"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.OpenToolStripMenuItem.Text = "打开(&O)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(162, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.SaveToolStripMenuItem.Text = "保存(&S)"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.SaveAsToolStripMenuItem.Text = "另存为(&A)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(162, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.PrintToolStripMenuItem.Text = "打印(&P)"
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Image = CType(resources.GetObject("PrintPreviewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "打印预览(&V)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(162, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ExitToolStripMenuItem.Text = "退出(&X)"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.ToolStripSeparator4, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator5, Me.SelectAllToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(59, 23)
        Me.EditToolStripMenuItem.Text = "编辑(&E)"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Image = CType(resources.GetObject("UndoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UndoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.UndoToolStripMenuItem.Text = "撤消(&U)"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Image = CType(resources.GetObject("RedoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RedoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.RedoToolStripMenuItem.Text = "重复(&R)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(158, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = CType(resources.GetObject("CutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CutToolStripMenuItem.Text = "剪切(&T)"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CopyToolStripMenuItem.Text = "复制(&C)"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = CType(resources.GetObject("PasteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.PasteToolStripMenuItem.Text = "粘贴(&P)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(158, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.SelectAllToolStripMenuItem.Text = "全选(&A)"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolBarToolStripMenuItem, Me.StatusBarToolStripMenuItem, Me.FoldersToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(60, 23)
        Me.ViewToolStripMenuItem.Text = "视图(&V)"
        '
        'ToolBarToolStripMenuItem
        '
        Me.ToolBarToolStripMenuItem.Checked = True
        Me.ToolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolBarToolStripMenuItem.Name = "ToolBarToolStripMenuItem"
        Me.ToolBarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ToolBarToolStripMenuItem.Text = "工具栏(&T)"
        '
        'StatusBarToolStripMenuItem
        '
        Me.StatusBarToolStripMenuItem.Checked = True
        Me.StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem"
        Me.StatusBarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.StatusBarToolStripMenuItem.Text = "状态栏(&S)"
        '
        'FoldersToolStripMenuItem
        '
        Me.FoldersToolStripMenuItem.Checked = True
        Me.FoldersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FoldersToolStripMenuItem.Name = "FoldersToolStripMenuItem"
        Me.FoldersToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FoldersToolStripMenuItem.Text = "文件夹(&F)"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(59, 23)
        Me.ToolsToolStripMenuItem.Text = "工具(&T)"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OptionsToolStripMenuItem.Text = "选项(&O)"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator6, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(61, 23)
        Me.HelpToolStripMenuItem.Text = "帮助(&H)"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ContentsToolStripMenuItem.Text = "目录(&C)"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Image = CType(resources.GetObject("IndexToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.IndexToolStripMenuItem.Text = "索引(&I)"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.SearchToolStripMenuItem.Text = "搜索(&S)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(163, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AboutToolStripMenuItem.Text = "关于(&A) ..."
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.BackColor = System.Drawing.SystemColors.Menu
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(60, 23)
        Me.ToolStripTextBox1.Text = "文件路径："
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(250, 23)
        '
        'ToolStripContainer
        '
        '
        'ToolStripContainer.BottomToolStripPanel
        '
        Me.ToolStripContainer.BottomToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.ToolStripContainer.BottomToolStripPanel.Controls.Add(Me.StatusStrip)
        '
        'ToolStripContainer.ContentPanel
        '
        Me.ToolStripContainer.ContentPanel.Controls.Add(Me.SplitContainer)
        Me.ToolStripContainer.ContentPanel.Size = New System.Drawing.Size(986, 533)
        Me.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer.Name = "ToolStripContainer"
        Me.ToolStripContainer.Size = New System.Drawing.Size(986, 632)
        Me.ToolStripContainer.TabIndex = 7
        Me.ToolStripContainer.Text = "ToolStripContainer1"
        '
        'ToolStripContainer.TopToolStripPanel
        '
        Me.ToolStripContainer.TopToolStripPanel.Controls.Add(Me.ToolStrip)
        Me.ToolStripContainer.TopToolStripPanel.Controls.Add(Me.MenuStrip)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(986, 25)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(44, 21)
        Me.ToolStripMenuItem1.Text = "保存"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(44, 21)
        Me.ToolStripMenuItem2.Text = "添加"
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.XPanderPanelList1)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer.Panel2.Controls.Add(Me.ListView)
        Me.SplitContainer.Size = New System.Drawing.Size(986, 533)
        Me.SplitContainer.SplitterDistance = 326
        Me.SplitContainer.TabIndex = 0
        Me.SplitContainer.Text = "SplitContainer1"
        '
        'XPanderPanelList1
        '
        Me.XPanderPanelList1.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Normal
        Me.XPanderPanelList1.Controls.Add(Me.XPanderPanel1)
        Me.XPanderPanelList1.Controls.Add(Me.XPanderPanel2)
        Me.XPanderPanelList1.Controls.Add(Me.XPanderPanel3)
        Me.XPanderPanelList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XPanderPanelList1.GradientBackground = System.Drawing.Color.Empty
        Me.XPanderPanelList1.Location = New System.Drawing.Point(0, 0)
        Me.XPanderPanelList1.Name = "XPanderPanelList1"
        Me.XPanderPanelList1.PanelColors = Nothing
        Me.XPanderPanelList1.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007
        Me.XPanderPanelList1.Size = New System.Drawing.Size(326, 533)
        Me.XPanderPanelList1.TabIndex = 0
        Me.XPanderPanelList1.Text = "XPanderPanelList1"
        '
        'XPanderPanel1
        '
        Me.XPanderPanel1.CaptionFont = New System.Drawing.Font("Microsoft YaHei UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XPanderPanel1.Controls.Add(Me.TreeView3)
        Me.XPanderPanel1.CustomColors.BackColor = System.Drawing.SystemColors.Control
        Me.XPanderPanel1.CustomColors.BorderColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.XPanderPanel1.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty
        Me.XPanderPanel1.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty
        Me.XPanderPanel1.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty
        Me.XPanderPanel1.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel1.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel1.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.XPanderPanel1.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace
        Me.XPanderPanel1.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.XPanderPanel1.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel1.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel1.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel1.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel1.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel1.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel1.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel1.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel1.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.XPanderPanel1.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.XPanderPanel1.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window
        Me.XPanderPanel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel1.Image = Nothing
        Me.XPanderPanel1.Name = "XPanderPanel1"
        Me.XPanderPanel1.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007
        Me.XPanderPanel1.Size = New System.Drawing.Size(326, 25)
        Me.XPanderPanel1.TabIndex = 2
        Me.XPanderPanel1.Text = "系统参数"
        Me.XPanderPanel1.ToolTipTextCloseIcon = Nothing
        Me.XPanderPanel1.ToolTipTextExpandIconPanelCollapsed = Nothing
        Me.XPanderPanel1.ToolTipTextExpandIconPanelExpanded = Nothing
        '
        'TreeView3
        '
        Me.TreeView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView3.Location = New System.Drawing.Point(1, 25)
        Me.TreeView3.Name = "TreeView3"
        TreeNode1.Name = "节点0"
        TreeNode1.Text = "系统参数"
        TreeNode2.Name = "节点1"
        TreeNode2.Text = "膜参数"
        TreeNode3.Name = "节点2"
        TreeNode3.Text = "相机参数"
        TreeNode4.Name = "节点0"
        TreeNode4.Text = "参数"
        Me.TreeView3.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4})
        Me.TreeView3.PathSeparator = ""
        Me.TreeView3.Size = New System.Drawing.Size(324, 0)
        Me.TreeView3.TabIndex = 0
        '
        'XPanderPanel2
        '
        Me.XPanderPanel2.CaptionFont = New System.Drawing.Font("Microsoft YaHei UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XPanderPanel2.Controls.Add(Me.TreeView1)
        Me.XPanderPanel2.CustomColors.BackColor = System.Drawing.SystemColors.Control
        Me.XPanderPanel2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.XPanderPanel2.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty
        Me.XPanderPanel2.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty
        Me.XPanderPanel2.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty
        Me.XPanderPanel2.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.XPanderPanel2.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace
        Me.XPanderPanel2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.XPanderPanel2.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel2.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel2.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel2.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel2.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel2.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.XPanderPanel2.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.XPanderPanel2.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window
        Me.XPanderPanel2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel2.Image = Nothing
        Me.XPanderPanel2.Name = "XPanderPanel2"
        Me.XPanderPanel2.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007
        Me.XPanderPanel2.Size = New System.Drawing.Size(326, 25)
        Me.XPanderPanel2.TabIndex = 0
        Me.XPanderPanel2.Text = "轴以及IO配置参数"
        Me.XPanderPanel2.ToolTipTextCloseIcon = Nothing
        Me.XPanderPanel2.ToolTipTextExpandIconPanelCollapsed = Nothing
        Me.XPanderPanel2.ToolTipTextExpandIconPanelExpanded = Nothing
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(1, 25)
        Me.TreeView1.Name = "TreeView1"
        TreeNode5.Name = "节点2"
        TreeNode5.Text = "PParam"
        TreeNode6.Name = "节点3"
        TreeNode6.Text = "OutPParam"
        TreeNode7.Name = "节点0"
        TreeNode7.Text = "IOConfigParam"
        TreeNode8.Name = "节点0"
        TreeNode8.Text = "R1BaseParam"
        TreeNode9.Name = "节点1"
        TreeNode9.Text = "R2BaseParam"
        TreeNode10.Name = "节点2"
        TreeNode10.Text = "R3BaseParam"
        TreeNode11.Name = "节点3"
        TreeNode11.Text = "R4BaseParam"
        TreeNode12.Name = "节点4"
        TreeNode12.Text = "XBaseParam"
        TreeNode13.Name = "节点5"
        TreeNode13.Text = "YBaseParam"
        TreeNode14.Name = "节点6"
        TreeNode14.Text = "Z1BaseParam"
        TreeNode15.Name = "节点7"
        TreeNode15.Text = "Z2BaseParam"
        TreeNode16.Name = "节点8"
        TreeNode16.Text = "Z3BaseParam"
        TreeNode17.Name = "节点9"
        TreeNode17.Text = "Z4BaseParam"
        TreeNode18.Name = "节点10"
        TreeNode18.Text = "Z5BaseParam"
        TreeNode19.Name = "节点11"
        TreeNode19.Text = "CVBaseParam"
        TreeNode20.Name = "节点1"
        TreeNode20.Text = "AxisConfigParam"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode20})
        Me.TreeView1.Size = New System.Drawing.Size(324, 0)
        Me.TreeView1.TabIndex = 0
        '
        'XPanderPanel3
        '
        Me.XPanderPanel3.CaptionFont = New System.Drawing.Font("Microsoft YaHei UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XPanderPanel3.Controls.Add(Me.TreeView2)
        Me.XPanderPanel3.CustomColors.BackColor = System.Drawing.SystemColors.Control
        Me.XPanderPanel3.CustomColors.BorderColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.XPanderPanel3.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty
        Me.XPanderPanel3.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty
        Me.XPanderPanel3.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty
        Me.XPanderPanel3.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel3.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel3.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.XPanderPanel3.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace
        Me.XPanderPanel3.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.XPanderPanel3.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel3.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel3.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel3.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel3.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel3.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XPanderPanel3.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel3.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel3.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.XPanderPanel3.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.XPanderPanel3.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window
        Me.XPanderPanel3.Expand = True
        Me.XPanderPanel3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.XPanderPanel3.Image = Nothing
        Me.XPanderPanel3.Name = "XPanderPanel3"
        Me.XPanderPanel3.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007
        Me.XPanderPanel3.Size = New System.Drawing.Size(326, 483)
        Me.XPanderPanel3.TabIndex = 1
        Me.XPanderPanel3.Text = "轴的运动参数"
        Me.XPanderPanel3.ToolTipTextCloseIcon = Nothing
        Me.XPanderPanel3.ToolTipTextExpandIconPanelCollapsed = Nothing
        Me.XPanderPanel3.ToolTipTextExpandIconPanelExpanded = Nothing
        '
        'TreeView2
        '
        Me.TreeView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView2.Location = New System.Drawing.Point(1, 25)
        Me.TreeView2.Name = "TreeView2"
        TreeNode21.Name = "节点1"
        TreeNode21.Text = "AxisMotionParam"
        Me.TreeView2.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode21})
        Me.TreeView2.Size = New System.Drawing.Size(324, 458)
        Me.TreeView2.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 191)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(656, 342)
        Me.TabControl1.TabIndex = 3
        Me.TabControl1.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox8)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(648, 316)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "系统参数"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.ComboBox3)
        Me.GroupBox8.Controls.Add(Me.ComboBox2)
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.Label10)
        Me.GroupBox8.Controls.Add(Me.CheckBox1)
        Me.GroupBox8.Location = New System.Drawing.Point(299, 131)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(190, 139)
        Me.GroupBox8.TabIndex = 3
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "排气控制"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(103, 105)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(71, 20)
        Me.ComboBox3.TabIndex = 10
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(103, 46)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(71, 20)
        Me.ComboBox2.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 12)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "排气时间（/秒）："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "间隔次数："
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(29, 26)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "排气开关"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.ComboBox1)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 131)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(287, 145)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "玻璃治具"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.RadioButton3)
        Me.GroupBox7.Controls.Add(Me.RadioButton4)
        Me.GroupBox7.Location = New System.Drawing.Point(11, 99)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(227, 40)
        Me.GroupBox7.TabIndex = 12
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "上膜顺序"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(18, 15)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton3.TabIndex = 9
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "先左后右"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(116, 14)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton4.TabIndex = 10
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "先右后左"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.RadioButton1)
        Me.GroupBox6.Controls.Add(Me.RadioButton2)
        Me.GroupBox6.Location = New System.Drawing.Point(14, 43)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(227, 37)
        Me.GroupBox6.TabIndex = 11
        Me.GroupBox6.TabStop = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(60, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(35, 16)
        Me.RadioButton1.TabIndex = 9
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "左"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(122, 11)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(35, 16)
        Me.RadioButton2.TabIndex = 10
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "右"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(53, 17)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(47, 20)
        Me.ComboBox1.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "上膜顺序："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "数量："
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.TextBox6)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.TextBox5)
        Me.GroupBox4.Location = New System.Drawing.Point(402, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(203, 119)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "驱动器串口"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "波特率"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(70, 70)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(127, 21)
        Me.TextBox6.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "端口号："
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(70, 14)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(127, 21)
        Me.TextBox5.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(381, 119)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "控制卡"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(197, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(180, 101)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "控制卡2"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(47, 62)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(127, 21)
        Me.TextBox3.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "IP："
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(47, 26)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(127, 21)
        Me.TextBox4.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Port:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(185, 101)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "控制卡1"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(47, 62)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(132, 21)
        Me.TextBox2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "IP："
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(47, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(132, 21)
        Me.TextBox1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Port:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox10)
        Me.TabPage2.Controls.Add(Me.GroupBox9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(648, 316)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "膜参数"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Label28)
        Me.GroupBox10.Controls.Add(Me.Label29)
        Me.GroupBox10.Controls.Add(Me.Label30)
        Me.GroupBox10.Controls.Add(Me.Label31)
        Me.GroupBox10.Controls.Add(Me.Label32)
        Me.GroupBox10.Controls.Add(Me.TextBox33)
        Me.GroupBox10.Controls.Add(Me.TextBox34)
        Me.GroupBox10.Controls.Add(Me.TextBox35)
        Me.GroupBox10.Controls.Add(Me.TextBox36)
        Me.GroupBox10.Controls.Add(Me.TextBox37)
        Me.GroupBox10.Controls.Add(Me.Label33)
        Me.GroupBox10.Controls.Add(Me.Label27)
        Me.GroupBox10.Controls.Add(Me.Label26)
        Me.GroupBox10.Controls.Add(Me.Label25)
        Me.GroupBox10.Controls.Add(Me.Label24)
        Me.GroupBox10.Controls.Add(Me.Label23)
        Me.GroupBox10.Controls.Add(Me.TextBox32)
        Me.GroupBox10.Controls.Add(Me.TextBox31)
        Me.GroupBox10.Controls.Add(Me.TextBox28)
        Me.GroupBox10.Controls.Add(Me.TextBox29)
        Me.GroupBox10.Controls.Add(Me.TextBox30)
        Me.GroupBox10.Controls.Add(Me.Label22)
        Me.GroupBox10.Controls.Add(Me.TextBox27)
        Me.GroupBox10.Controls.Add(Me.TextBox26)
        Me.GroupBox10.Controls.Add(Me.TextBox25)
        Me.GroupBox10.Controls.Add(Me.Label21)
        Me.GroupBox10.Controls.Add(Me.TextBox24)
        Me.GroupBox10.Controls.Add(Me.Label20)
        Me.GroupBox10.Controls.Add(Me.TextBox23)
        Me.GroupBox10.Controls.Add(Me.Label19)
        Me.GroupBox10.Location = New System.Drawing.Point(364, 6)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(281, 270)
        Me.GroupBox10.TabIndex = 1
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "膜"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(198, 157)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(23, 12)
        Me.Label28.TabIndex = 31
        Me.Label28.Text = "R："
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(105, 158)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(23, 12)
        Me.Label29.TabIndex = 30
        Me.Label29.Text = "T："
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(0, 158)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(23, 12)
        Me.Label30.TabIndex = 29
        Me.Label30.Text = "Z："
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(198, 132)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(23, 12)
        Me.Label31.TabIndex = 28
        Me.Label31.Text = "Y："
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(110, 132)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(23, 12)
        Me.Label32.TabIndex = 27
        Me.Label32.Text = "X："
        '
        'TextBox33
        '
        Me.TextBox33.Location = New System.Drawing.Point(25, 152)
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New System.Drawing.Size(58, 21)
        Me.TextBox33.TabIndex = 26
        '
        'TextBox34
        '
        Me.TextBox34.Location = New System.Drawing.Point(221, 152)
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Size = New System.Drawing.Size(58, 21)
        Me.TextBox34.TabIndex = 25
        '
        'TextBox35
        '
        Me.TextBox35.Location = New System.Drawing.Point(221, 125)
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Size = New System.Drawing.Size(58, 21)
        Me.TextBox35.TabIndex = 24
        '
        'TextBox36
        '
        Me.TextBox36.Location = New System.Drawing.Point(134, 152)
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New System.Drawing.Size(58, 21)
        Me.TextBox36.TabIndex = 23
        '
        'TextBox37
        '
        Me.TextBox37.Location = New System.Drawing.Point(134, 129)
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.Size = New System.Drawing.Size(58, 21)
        Me.TextBox37.TabIndex = 22
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(6, 132)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(113, 12)
        Me.Label33.TabIndex = 21
        Me.Label33.Text = "相机拍膜治具位置："
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(198, 102)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(23, 12)
        Me.Label27.TabIndex = 20
        Me.Label27.Text = "R："
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(105, 102)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(23, 12)
        Me.Label26.TabIndex = 19
        Me.Label26.Text = "T："
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(0, 102)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(23, 12)
        Me.Label25.TabIndex = 18
        Me.Label25.Text = "Z："
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(198, 73)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(23, 12)
        Me.Label24.TabIndex = 17
        Me.Label24.Text = "Y："
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(105, 73)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(23, 12)
        Me.Label23.TabIndex = 16
        Me.Label23.Text = "X："
        '
        'TextBox32
        '
        Me.TextBox32.Location = New System.Drawing.Point(25, 96)
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Size = New System.Drawing.Size(58, 21)
        Me.TextBox32.TabIndex = 15
        '
        'TextBox31
        '
        Me.TextBox31.Location = New System.Drawing.Point(221, 99)
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New System.Drawing.Size(58, 21)
        Me.TextBox31.TabIndex = 14
        '
        'TextBox28
        '
        Me.TextBox28.Location = New System.Drawing.Point(221, 70)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New System.Drawing.Size(58, 21)
        Me.TextBox28.TabIndex = 13
        '
        'TextBox29
        '
        Me.TextBox29.Location = New System.Drawing.Point(134, 96)
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New System.Drawing.Size(58, 21)
        Me.TextBox29.TabIndex = 12
        '
        'TextBox30
        '
        Me.TextBox30.Location = New System.Drawing.Point(134, 69)
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New System.Drawing.Size(58, 21)
        Me.TextBox30.TabIndex = 11
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 73)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(101, 12)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "膜治具进料位置："
        '
        'TextBox27
        '
        Me.TextBox27.Location = New System.Drawing.Point(223, 45)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New System.Drawing.Size(58, 21)
        Me.TextBox27.TabIndex = 9
        '
        'TextBox26
        '
        Me.TextBox26.Location = New System.Drawing.Point(163, 45)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(58, 21)
        Me.TextBox26.TabIndex = 8
        '
        'TextBox25
        '
        Me.TextBox25.Location = New System.Drawing.Point(103, 45)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New System.Drawing.Size(58, 21)
        Me.TextBox25.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 48)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(107, 12)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "相机拍膜位置XYZ："
        '
        'TextBox24
        '
        Me.TextBox24.Location = New System.Drawing.Point(217, 19)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(58, 21)
        Me.TextBox24.TabIndex = 5
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(139, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 12)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "右放膜高度："
        '
        'TextBox23
        '
        Me.TextBox23.Location = New System.Drawing.Point(75, 22)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(58, 21)
        Me.TextBox23.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 12)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "左放膜高度："
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.TextBox17)
        Me.GroupBox9.Controls.Add(Me.TextBox18)
        Me.GroupBox9.Controls.Add(Me.TextBox19)
        Me.GroupBox9.Controls.Add(Me.Label17)
        Me.GroupBox9.Controls.Add(Me.TextBox20)
        Me.GroupBox9.Controls.Add(Me.TextBox21)
        Me.GroupBox9.Controls.Add(Me.TextBox22)
        Me.GroupBox9.Controls.Add(Me.Label18)
        Me.GroupBox9.Controls.Add(Me.TextBox15)
        Me.GroupBox9.Controls.Add(Me.Label15)
        Me.GroupBox9.Controls.Add(Me.TextBox16)
        Me.GroupBox9.Controls.Add(Me.Label16)
        Me.GroupBox9.Controls.Add(Me.TextBox12)
        Me.GroupBox9.Controls.Add(Me.TextBox13)
        Me.GroupBox9.Controls.Add(Me.TextBox14)
        Me.GroupBox9.Controls.Add(Me.Label14)
        Me.GroupBox9.Controls.Add(Me.TextBox11)
        Me.GroupBox9.Controls.Add(Me.TextBox10)
        Me.GroupBox9.Controls.Add(Me.TextBox9)
        Me.GroupBox9.Controls.Add(Me.Label13)
        Me.GroupBox9.Controls.Add(Me.TextBox8)
        Me.GroupBox9.Controls.Add(Me.Label12)
        Me.GroupBox9.Controls.Add(Me.TextBox7)
        Me.GroupBox9.Controls.Add(Me.Label11)
        Me.GroupBox9.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(355, 270)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "玻璃治具"
        '
        'TextBox17
        '
        Me.TextBox17.Location = New System.Drawing.Point(294, 216)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(58, 21)
        Me.TextBox17.TabIndex = 27
        '
        'TextBox18
        '
        Me.TextBox18.Location = New System.Drawing.Point(225, 216)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(58, 21)
        Me.TextBox18.TabIndex = 26
        '
        'TextBox19
        '
        Me.TextBox19.Location = New System.Drawing.Point(161, 216)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(58, 21)
        Me.TextBox19.TabIndex = 25
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(2, 225)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(161, 12)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "右玻璃治具对角中心偏距XYZ:"
        '
        'TextBox20
        '
        Me.TextBox20.Location = New System.Drawing.Point(292, 184)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(58, 21)
        Me.TextBox20.TabIndex = 23
        '
        'TextBox21
        '
        Me.TextBox21.Location = New System.Drawing.Point(223, 184)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(58, 21)
        Me.TextBox21.TabIndex = 22
        '
        'TextBox22
        '
        Me.TextBox22.Location = New System.Drawing.Point(159, 184)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(58, 21)
        Me.TextBox22.TabIndex = 21
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 193)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(155, 12)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "相机拍右玻璃治具位置XYZ："
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(139, 154)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(58, 21)
        Me.TextBox15.TabIndex = 19
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 157)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 12)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "右玻璃治具上下料位置："
        '
        'TextBox16
        '
        Me.TextBox16.Location = New System.Drawing.Point(137, 127)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(58, 21)
        Me.TextBox16.TabIndex = 17
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 132)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(125, 12)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "右玻璃治具压合位置："
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(293, 96)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(58, 21)
        Me.TextBox12.TabIndex = 15
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(224, 96)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(58, 21)
        Me.TextBox13.TabIndex = 14
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(160, 96)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(58, 21)
        Me.TextBox14.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1, 105)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(161, 12)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "左玻璃治具对角中心偏距XYZ:"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(291, 64)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(58, 21)
        Me.TextBox11.TabIndex = 11
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(222, 64)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(58, 21)
        Me.TextBox10.TabIndex = 9
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(158, 64)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(58, 21)
        Me.TextBox9.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(155, 12)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "相机拍左玻璃治具位置XYZ："
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(139, 39)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(58, 21)
        Me.TextBox8.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(137, 12)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "左玻璃治具上下料位置："
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(137, 12)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(58, 21)
        Me.TextBox7.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 12)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "左玻璃治具压合位置："
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox11)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(648, 316)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "相机参数"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label53)
        Me.GroupBox11.Controls.Add(Me.ComboBox4)
        Me.GroupBox11.Controls.Add(Me.GroupBox13)
        Me.GroupBox11.Controls.Add(Me.GroupBox12)
        Me.GroupBox11.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(634, 304)
        Me.GroupBox11.TabIndex = 0
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "相机参数："
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(545, 38)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(89, 12)
        Me.Label53.TabIndex = 3
        Me.Label53.Text = "视觉方案选择："
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(550, 53)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(78, 20)
        Me.ComboBox4.TabIndex = 2
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.DomainUpDown19)
        Me.GroupBox13.Controls.Add(Me.Label52)
        Me.GroupBox13.Controls.Add(Me.DomainUpDown14)
        Me.GroupBox13.Controls.Add(Me.Label47)
        Me.GroupBox13.Controls.Add(Me.DomainUpDown15)
        Me.GroupBox13.Controls.Add(Me.Label48)
        Me.GroupBox13.Controls.Add(Me.DomainUpDown16)
        Me.GroupBox13.Controls.Add(Me.Label49)
        Me.GroupBox13.Controls.Add(Me.DomainUpDown17)
        Me.GroupBox13.Controls.Add(Me.Label50)
        Me.GroupBox13.Controls.Add(Me.DomainUpDown18)
        Me.GroupBox13.Controls.Add(Me.Label51)
        Me.GroupBox13.Controls.Add(Me.DomainUpDown13)
        Me.GroupBox13.Controls.Add(Me.Label46)
        Me.GroupBox13.Controls.Add(Me.DomainUpDown11)
        Me.GroupBox13.Controls.Add(Me.Label44)
        Me.GroupBox13.Controls.Add(Me.DomainUpDown12)
        Me.GroupBox13.Controls.Add(Me.Label45)
        Me.GroupBox13.Controls.Add(Me.DomainUpDown10)
        Me.GroupBox13.Controls.Add(Me.Label43)
        Me.GroupBox13.Controls.Add(Me.DomainUpDown9)
        Me.GroupBox13.Controls.Add(Me.Label42)
        Me.GroupBox13.Location = New System.Drawing.Point(0, 173)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(605, 131)
        Me.GroupBox13.TabIndex = 1
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "相机参数"
        '
        'DomainUpDown19
        '
        Me.DomainUpDown19.Location = New System.Drawing.Point(529, 17)
        Me.DomainUpDown19.Name = "DomainUpDown19"
        Me.DomainUpDown19.Size = New System.Drawing.Size(74, 21)
        Me.DomainUpDown19.TabIndex = 35
        Me.DomainUpDown19.Text = "0"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(468, 22)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(65, 12)
        Me.Label52.TabIndex = 34
        Me.Label52.Text = "拍照间距："
        '
        'DomainUpDown14
        '
        Me.DomainUpDown14.Location = New System.Drawing.Point(357, 102)
        Me.DomainUpDown14.Name = "DomainUpDown14"
        Me.DomainUpDown14.Size = New System.Drawing.Size(104, 21)
        Me.DomainUpDown14.TabIndex = 33
        Me.DomainUpDown14.Text = "0"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(238, 104)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(101, 12)
        Me.Label47.TabIndex = 32
        Me.Label47.Text = "右相机像素当量："
        '
        'DomainUpDown15
        '
        Me.DomainUpDown15.Location = New System.Drawing.Point(357, 81)
        Me.DomainUpDown15.Name = "DomainUpDown15"
        Me.DomainUpDown15.Size = New System.Drawing.Size(104, 21)
        Me.DomainUpDown15.TabIndex = 31
        Me.DomainUpDown15.Text = "0"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(238, 83)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(77, 12)
        Me.Label48.TabIndex = 30
        Me.Label48.Text = "相机行间距："
        '
        'DomainUpDown16
        '
        Me.DomainUpDown16.Location = New System.Drawing.Point(357, 59)
        Me.DomainUpDown16.Name = "DomainUpDown16"
        Me.DomainUpDown16.Size = New System.Drawing.Size(104, 21)
        Me.DomainUpDown16.TabIndex = 29
        Me.DomainUpDown16.Text = "0"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(238, 61)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(101, 12)
        Me.Label49.TabIndex = 28
        Me.Label49.Text = "右相机旋转角度："
        '
        'DomainUpDown17
        '
        Me.DomainUpDown17.Location = New System.Drawing.Point(357, 37)
        Me.DomainUpDown17.Name = "DomainUpDown17"
        Me.DomainUpDown17.Size = New System.Drawing.Size(104, 21)
        Me.DomainUpDown17.TabIndex = 27
        Me.DomainUpDown17.Text = "0"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(238, 39)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(113, 12)
        Me.Label50.TabIndex = 26
        Me.Label50.Text = "右相机膜曝光时间："
        '
        'DomainUpDown18
        '
        Me.DomainUpDown18.Location = New System.Drawing.Point(357, 15)
        Me.DomainUpDown18.Name = "DomainUpDown18"
        Me.DomainUpDown18.Size = New System.Drawing.Size(104, 21)
        Me.DomainUpDown18.TabIndex = 25
        Me.DomainUpDown18.Text = "0"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(238, 17)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(125, 12)
        Me.Label51.TabIndex = 24
        Me.Label51.Text = "右相机玻璃曝光时间："
        '
        'DomainUpDown13
        '
        Me.DomainUpDown13.Location = New System.Drawing.Point(128, 102)
        Me.DomainUpDown13.Name = "DomainUpDown13"
        Me.DomainUpDown13.Size = New System.Drawing.Size(104, 21)
        Me.DomainUpDown13.TabIndex = 23
        Me.DomainUpDown13.Text = "0"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(9, 104)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(101, 12)
        Me.Label46.TabIndex = 22
        Me.Label46.Text = "左相机像素当量："
        '
        'DomainUpDown11
        '
        Me.DomainUpDown11.Location = New System.Drawing.Point(128, 81)
        Me.DomainUpDown11.Name = "DomainUpDown11"
        Me.DomainUpDown11.Size = New System.Drawing.Size(104, 21)
        Me.DomainUpDown11.TabIndex = 21
        Me.DomainUpDown11.Text = "0"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(9, 83)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(77, 12)
        Me.Label44.TabIndex = 20
        Me.Label44.Text = "相机行间距："
        '
        'DomainUpDown12
        '
        Me.DomainUpDown12.Location = New System.Drawing.Point(128, 59)
        Me.DomainUpDown12.Name = "DomainUpDown12"
        Me.DomainUpDown12.Size = New System.Drawing.Size(104, 21)
        Me.DomainUpDown12.TabIndex = 19
        Me.DomainUpDown12.Text = "0"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(9, 61)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(101, 12)
        Me.Label45.TabIndex = 18
        Me.Label45.Text = "左相机旋转角度："
        '
        'DomainUpDown10
        '
        Me.DomainUpDown10.Location = New System.Drawing.Point(128, 37)
        Me.DomainUpDown10.Name = "DomainUpDown10"
        Me.DomainUpDown10.Size = New System.Drawing.Size(104, 21)
        Me.DomainUpDown10.TabIndex = 17
        Me.DomainUpDown10.Text = "0"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(9, 39)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(113, 12)
        Me.Label43.TabIndex = 16
        Me.Label43.Text = "左相机膜曝光时间："
        '
        'DomainUpDown9
        '
        Me.DomainUpDown9.Location = New System.Drawing.Point(128, 15)
        Me.DomainUpDown9.Name = "DomainUpDown9"
        Me.DomainUpDown9.Size = New System.Drawing.Size(104, 21)
        Me.DomainUpDown9.TabIndex = 15
        Me.DomainUpDown9.Text = "0"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(9, 17)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(125, 12)
        Me.Label42.TabIndex = 14
        Me.Label42.Text = "左相机玻璃曝光时间："
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.DomainUpDown5)
        Me.GroupBox12.Controls.Add(Me.Label38)
        Me.GroupBox12.Controls.Add(Me.DomainUpDown6)
        Me.GroupBox12.Controls.Add(Me.Label39)
        Me.GroupBox12.Controls.Add(Me.DomainUpDown7)
        Me.GroupBox12.Controls.Add(Me.Label40)
        Me.GroupBox12.Controls.Add(Me.DomainUpDown8)
        Me.GroupBox12.Controls.Add(Me.Label41)
        Me.GroupBox12.Controls.Add(Me.DomainUpDown3)
        Me.GroupBox12.Controls.Add(Me.Label36)
        Me.GroupBox12.Controls.Add(Me.DomainUpDown4)
        Me.GroupBox12.Controls.Add(Me.Label37)
        Me.GroupBox12.Controls.Add(Me.DomainUpDown2)
        Me.GroupBox12.Controls.Add(Me.Label35)
        Me.GroupBox12.Controls.Add(Me.DomainUpDown1)
        Me.GroupBox12.Controls.Add(Me.Label34)
        Me.GroupBox12.Location = New System.Drawing.Point(3, 23)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(541, 144)
        Me.GroupBox12.TabIndex = 0
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "相机当量参数"
        '
        'DomainUpDown5
        '
        Me.DomainUpDown5.Location = New System.Drawing.Point(395, 109)
        Me.DomainUpDown5.Name = "DomainUpDown5"
        Me.DomainUpDown5.Size = New System.Drawing.Size(145, 21)
        Me.DomainUpDown5.TabIndex = 15
        Me.DomainUpDown5.Text = "0"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(276, 111)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(113, 12)
        Me.Label38.TabIndex = 14
        Me.Label38.Text = "右相机下边列像素："
        '
        'DomainUpDown6
        '
        Me.DomainUpDown6.Location = New System.Drawing.Point(125, 109)
        Me.DomainUpDown6.Name = "DomainUpDown6"
        Me.DomainUpDown6.Size = New System.Drawing.Size(145, 21)
        Me.DomainUpDown6.TabIndex = 13
        Me.DomainUpDown6.Text = "0"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(6, 111)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(113, 12)
        Me.Label39.TabIndex = 12
        Me.Label39.Text = "左相机下边列像素："
        '
        'DomainUpDown7
        '
        Me.DomainUpDown7.Location = New System.Drawing.Point(395, 77)
        Me.DomainUpDown7.Name = "DomainUpDown7"
        Me.DomainUpDown7.Size = New System.Drawing.Size(145, 21)
        Me.DomainUpDown7.TabIndex = 11
        Me.DomainUpDown7.Text = "0"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(276, 79)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(113, 12)
        Me.Label40.TabIndex = 10
        Me.Label40.Text = "右相机下边行像素："
        '
        'DomainUpDown8
        '
        Me.DomainUpDown8.Location = New System.Drawing.Point(125, 77)
        Me.DomainUpDown8.Name = "DomainUpDown8"
        Me.DomainUpDown8.Size = New System.Drawing.Size(145, 21)
        Me.DomainUpDown8.TabIndex = 9
        Me.DomainUpDown8.Text = "0"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(6, 79)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(113, 12)
        Me.Label41.TabIndex = 8
        Me.Label41.Text = "左相机下边行像素："
        '
        'DomainUpDown3
        '
        Me.DomainUpDown3.Location = New System.Drawing.Point(395, 46)
        Me.DomainUpDown3.Name = "DomainUpDown3"
        Me.DomainUpDown3.Size = New System.Drawing.Size(145, 21)
        Me.DomainUpDown3.TabIndex = 7
        Me.DomainUpDown3.Text = "0"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(276, 48)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(113, 12)
        Me.Label36.TabIndex = 6
        Me.Label36.Text = "右相机上边列像素："
        '
        'DomainUpDown4
        '
        Me.DomainUpDown4.Location = New System.Drawing.Point(125, 46)
        Me.DomainUpDown4.Name = "DomainUpDown4"
        Me.DomainUpDown4.Size = New System.Drawing.Size(145, 21)
        Me.DomainUpDown4.TabIndex = 5
        Me.DomainUpDown4.Text = "0"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 48)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(113, 12)
        Me.Label37.TabIndex = 4
        Me.Label37.Text = "左相机上边列像素："
        '
        'DomainUpDown2
        '
        Me.DomainUpDown2.Location = New System.Drawing.Point(395, 15)
        Me.DomainUpDown2.Name = "DomainUpDown2"
        Me.DomainUpDown2.Size = New System.Drawing.Size(145, 21)
        Me.DomainUpDown2.TabIndex = 3
        Me.DomainUpDown2.Text = "0"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(276, 17)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(113, 12)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "右相机上边行像素："
        '
        'DomainUpDown1
        '
        Me.DomainUpDown1.Location = New System.Drawing.Point(125, 15)
        Me.DomainUpDown1.Name = "DomainUpDown1"
        Me.DomainUpDown1.Size = New System.Drawing.Size(145, 21)
        Me.DomainUpDown1.TabIndex = 1
        Me.DomainUpDown1.Text = "0"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(6, 17)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(113, 12)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "左相机上边行像素："
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(656, 191)
        Me.DataGridView1.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.HeaderText = "轴号"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "X坐标"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Y坐标"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Z坐标"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "R坐标"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "速度"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "周期时间"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "使能"
        Me.Column8.Name = "Column8"
        '
        'ListView
        '
        Me.ListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView.Location = New System.Drawing.Point(0, 0)
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(656, 533)
        Me.ListView.TabIndex = 0
        Me.ListView.UseCompatibleStateImageBehavior = False
        '
        'Explorer1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 632)
        Me.Controls.Add(Me.ToolStripContainer)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Explorer1"
        Me.Text = "Explorer1"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStripContainer.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer.ResumeLayout(False)
        Me.ToolStripContainer.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.XPanderPanelList1.ResumeLayout(False)
        Me.XPanderPanel1.ResumeLayout(False)
        Me.XPanderPanel2.ResumeLayout(False)
        Me.XPanderPanel3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ListView As System.Windows.Forms.ListView
    Friend WithEvents XPanderPanelList1 As BSE.Windows.Forms.XPanderPanelList
    Friend WithEvents XPanderPanel2 As BSE.Windows.Forms.XPanderPanel
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents XPanderPanel3 As BSE.Windows.Forms.XPanderPanel
    Friend WithEvents XPanderPanel1 As BSE.Windows.Forms.XPanderPanel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView
    Friend WithEvents TreeView3 As System.Windows.Forms.TreeView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox27 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TextBox33 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox34 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox35 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox36 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox37 As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextBox32 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox31 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox28 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox29 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox30 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents DomainUpDown19 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown14 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown15 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown16 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown17 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown18 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown13 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown11 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown12 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown10 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown9 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents DomainUpDown5 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown6 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown7 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown8 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown3 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown4 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown2 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents DomainUpDown1 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label34 As System.Windows.Forms.Label

End Class
