<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpeedEdit2
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SpeedEditGB = New System.Windows.Forms.GroupBox()
        Me.ChangeSpeed = New System.Windows.Forms.Button()
        Me.AddSpeedNow = New System.Windows.Forms.Button()
        Me.SubSpeedNow = New System.Windows.Forms.Button()
        Me.WkComDGv = New System.Windows.Forms.DataGridView()
        Me.SaveNewSped = New System.Windows.Forms.Button()
        Me.ExitNewSpeed = New System.Windows.Forms.Button()
        Me.SlowSpeedratio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RunTimeOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubPulse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddPuls = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrgSpeed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpeedValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StarSpeed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkCom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpeedEditGB.SuspendLayout()
        CType(Me.WkComDGv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SpeedEditGB
        '
        Me.SpeedEditGB.Controls.Add(Me.ChangeSpeed)
        Me.SpeedEditGB.Controls.Add(Me.AddSpeedNow)
        Me.SpeedEditGB.Controls.Add(Me.SubSpeedNow)
        Me.SpeedEditGB.Controls.Add(Me.WkComDGv)
        Me.SpeedEditGB.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SpeedEditGB.Location = New System.Drawing.Point(0, 6)
        Me.SpeedEditGB.Name = "SpeedEditGB"
        Me.SpeedEditGB.Size = New System.Drawing.Size(1066, 415)
        Me.SpeedEditGB.TabIndex = 54
        Me.SpeedEditGB.TabStop = False
        Me.SpeedEditGB.Text = "速度编辑"
        '
        'ChangeSpeed
        '
        Me.ChangeSpeed.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ChangeSpeed.Location = New System.Drawing.Point(912, 362)
        Me.ChangeSpeed.Name = "ChangeSpeed"
        Me.ChangeSpeed.Size = New System.Drawing.Size(132, 41)
        Me.ChangeSpeed.TabIndex = 38
        Me.ChangeSpeed.Text = "改变速度"
        Me.ChangeSpeed.UseVisualStyleBackColor = True
        '
        'AddSpeedNow
        '
        Me.AddSpeedNow.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AddSpeedNow.Location = New System.Drawing.Point(621, 362)
        Me.AddSpeedNow.Name = "AddSpeedNow"
        Me.AddSpeedNow.Size = New System.Drawing.Size(132, 41)
        Me.AddSpeedNow.TabIndex = 37
        Me.AddSpeedNow.Text = "添加速度"
        Me.AddSpeedNow.UseVisualStyleBackColor = True
        '
        'SubSpeedNow
        '
        Me.SubSpeedNow.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SubSpeedNow.Location = New System.Drawing.Point(344, 362)
        Me.SubSpeedNow.Name = "SubSpeedNow"
        Me.SubSpeedNow.Size = New System.Drawing.Size(131, 42)
        Me.SubSpeedNow.TabIndex = 36
        Me.SubSpeedNow.Text = "删除速度"
        Me.SubSpeedNow.UseVisualStyleBackColor = True
        '
        'WkComDGv
        '
        Me.WkComDGv.CausesValidation = False
        Me.WkComDGv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WkComDGv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WorkCom, Me.StarSpeed, Me.SpeedValue, Me.OrgSpeed, Me.AddTime, Me.SubTime, Me.AddPuls, Me.SubPulse, Me.RunTimeOut, Me.SlowSpeedratio})
        Me.WkComDGv.Location = New System.Drawing.Point(8, 19)
        Me.WkComDGv.Name = "WkComDGv"
        Me.WkComDGv.ReadOnly = True
        Me.WkComDGv.RowHeadersVisible = False
        Me.WkComDGv.RowTemplate.Height = 23
        Me.WkComDGv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.WkComDGv.ShowCellErrors = False
        Me.WkComDGv.Size = New System.Drawing.Size(1053, 337)
        Me.WkComDGv.TabIndex = 2
        '
        'SaveNewSped
        '
        Me.SaveNewSped.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SaveNewSped.Location = New System.Drawing.Point(912, 427)
        Me.SaveNewSped.Name = "SaveNewSped"
        Me.SaveNewSped.Size = New System.Drawing.Size(132, 42)
        Me.SaveNewSped.TabIndex = 39
        Me.SaveNewSped.Text = "保存数据"
        Me.SaveNewSped.UseVisualStyleBackColor = True
        '
        'ExitNewSpeed
        '
        Me.ExitNewSpeed.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ExitNewSpeed.Location = New System.Drawing.Point(621, 427)
        Me.ExitNewSpeed.Name = "ExitNewSpeed"
        Me.ExitNewSpeed.Size = New System.Drawing.Size(132, 45)
        Me.ExitNewSpeed.TabIndex = 55
        Me.ExitNewSpeed.Text = "退出不保存"
        Me.ExitNewSpeed.UseVisualStyleBackColor = True
        '
        'SlowSpeedratio
        '
        Me.SlowSpeedratio.HeaderText = "减速比"
        Me.SlowSpeedratio.Name = "SlowSpeedratio"
        Me.SlowSpeedratio.ReadOnly = True
        Me.SlowSpeedratio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'RunTimeOut
        '
        Me.RunTimeOut.HeaderText = "运动超时"
        Me.RunTimeOut.Name = "RunTimeOut"
        Me.RunTimeOut.ReadOnly = True
        Me.RunTimeOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SubPulse
        '
        Me.SubPulse.HeaderText = "减速脉冲"
        Me.SubPulse.Name = "SubPulse"
        Me.SubPulse.ReadOnly = True
        Me.SubPulse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'AddPuls
        '
        Me.AddPuls.HeaderText = "加速脉冲"
        Me.AddPuls.Name = "AddPuls"
        Me.AddPuls.ReadOnly = True
        Me.AddPuls.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SubTime
        '
        Me.SubTime.HeaderText = "减速时间"
        Me.SubTime.Name = "SubTime"
        Me.SubTime.ReadOnly = True
        Me.SubTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'AddTime
        '
        Me.AddTime.HeaderText = "加速时间"
        Me.AddTime.Name = "AddTime"
        Me.AddTime.ReadOnly = True
        Me.AddTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'OrgSpeed
        '
        Me.OrgSpeed.HeaderText = "复位速度"
        Me.OrgSpeed.Name = "OrgSpeed"
        Me.OrgSpeed.ReadOnly = True
        Me.OrgSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SpeedValue
        '
        Me.SpeedValue.HeaderText = "最大速度"
        Me.SpeedValue.Name = "SpeedValue"
        Me.SpeedValue.ReadOnly = True
        Me.SpeedValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'StarSpeed
        '
        Me.StarSpeed.HeaderText = "启动速度"
        Me.StarSpeed.Name = "StarSpeed"
        Me.StarSpeed.ReadOnly = True
        Me.StarSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'WorkCom
        '
        Me.WorkCom.HeaderText = "速度类型"
        Me.WorkCom.Name = "WorkCom"
        Me.WorkCom.ReadOnly = True
        Me.WorkCom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.WorkCom.Width = 150
        '
        'SpeedEdit2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1066, 486)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExitNewSpeed)
        Me.Controls.Add(Me.SaveNewSped)
        Me.Controls.Add(Me.SpeedEditGB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SpeedEdit2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SpeedEdit2"
        Me.SpeedEditGB.ResumeLayout(False)
        CType(Me.WkComDGv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpeedEditGB As System.Windows.Forms.GroupBox
    Friend WithEvents ChangeSpeed As System.Windows.Forms.Button
    Friend WithEvents AddSpeedNow As System.Windows.Forms.Button
    Friend WithEvents SubSpeedNow As System.Windows.Forms.Button
    Friend WithEvents WkComDGv As System.Windows.Forms.DataGridView
    Friend WithEvents SaveNewSped As System.Windows.Forms.Button
    Friend WithEvents ExitNewSpeed As System.Windows.Forms.Button
    Friend WithEvents WorkCom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StarSpeed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpeedValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrgSpeed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddPuls As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubPulse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RunTimeOut As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SlowSpeedratio As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
