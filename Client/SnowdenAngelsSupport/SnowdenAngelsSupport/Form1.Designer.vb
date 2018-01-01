<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lbl_status_name = New System.Windows.Forms.Label()
        Me.lbl_status_response = New System.Windows.Forms.Label()
        Me.btn_miner_start = New System.Windows.Forms.Button()
        Me.btn_miner_stop = New System.Windows.Forms.Button()
        Me.lbl_cores_name = New System.Windows.Forms.Label()
        Me.cmb_cores = New System.Windows.Forms.ComboBox()
        Me.lbl_pool_name = New System.Windows.Forms.Label()
        Me.cmb_pool = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_autostart_name = New System.Windows.Forms.Label()
        Me.chk_autostart_true = New System.Windows.Forms.CheckBox()
        Me.btn_apply_settings = New System.Windows.Forms.Button()
        Me.lbl_apply_settings_hint = New System.Windows.Forms.Label()
        Me.nf = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.lbl_xmrpath_name = New System.Windows.Forms.Label()
        Me.lbl_xmrpath_status = New System.Windows.Forms.Label()
        Me.lbl_cores_number_total = New System.Windows.Forms.Label()
        Me.lbl_xmrtcpport_name = New System.Windows.Forms.Label()
        Me.lbl_xmrtcpport_status = New System.Windows.Forms.Label()
        Me.lnk_minerport = New System.Windows.Forms.LinkLabel()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.lbl_startminimized_name = New System.Windows.Forms.Label()
        Me.chk_startminimized = New System.Windows.Forms.CheckBox()
        Me.txt_userkey_status = New System.Windows.Forms.TextBox()
        Me.lbl_userkey_name = New System.Windows.Forms.Label()
        Me.lbl_allowErrorTransfer_name = New System.Windows.Forms.Label()
        Me.chk_allowErrorTransfer = New System.Windows.Forms.CheckBox()
        Me.lbl_allowStatsTransfer_name = New System.Windows.Forms.Label()
        Me.chk_allowStatsTransfer = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lbl_status_name
        '
        Me.lbl_status_name.AutoSize = True
        Me.lbl_status_name.Location = New System.Drawing.Point(8, 8)
        Me.lbl_status_name.Name = "lbl_status_name"
        Me.lbl_status_name.Size = New System.Drawing.Size(116, 13)
        Me.lbl_status_name.TabIndex = 0
        Me.lbl_status_name.Text = "Status of Monero miner"
        '
        'lbl_status_response
        '
        Me.lbl_status_response.AutoSize = True
        Me.lbl_status_response.Location = New System.Drawing.Point(232, 8)
        Me.lbl_status_response.Name = "lbl_status_response"
        Me.lbl_status_response.Size = New System.Drawing.Size(53, 13)
        Me.lbl_status_response.TabIndex = 1
        Me.lbl_status_response.Text = "Unknown"
        '
        'btn_miner_start
        '
        Me.btn_miner_start.Location = New System.Drawing.Point(232, 248)
        Me.btn_miner_start.Name = "btn_miner_start"
        Me.btn_miner_start.Size = New System.Drawing.Size(129, 23)
        Me.btn_miner_start.TabIndex = 2
        Me.btn_miner_start.Text = "Start Funding"
        Me.btn_miner_start.UseVisualStyleBackColor = True
        '
        'btn_miner_stop
        '
        Me.btn_miner_stop.Location = New System.Drawing.Point(368, 248)
        Me.btn_miner_stop.Name = "btn_miner_stop"
        Me.btn_miner_stop.Size = New System.Drawing.Size(129, 23)
        Me.btn_miner_stop.TabIndex = 3
        Me.btn_miner_stop.Text = "Stop Funding"
        Me.btn_miner_stop.UseVisualStyleBackColor = True
        '
        'lbl_cores_name
        '
        Me.lbl_cores_name.AutoSize = True
        Me.lbl_cores_name.Location = New System.Drawing.Point(8, 80)
        Me.lbl_cores_name.Name = "lbl_cores_name"
        Me.lbl_cores_name.Size = New System.Drawing.Size(143, 13)
        Me.lbl_cores_name.TabIndex = 4
        Me.lbl_cores_name.Text = "Number of CPU Cores to use"
        '
        'cmb_cores
        '
        Me.cmb_cores.FormattingEnabled = True
        Me.cmb_cores.Location = New System.Drawing.Point(232, 72)
        Me.cmb_cores.Name = "cmb_cores"
        Me.cmb_cores.Size = New System.Drawing.Size(170, 21)
        Me.cmb_cores.TabIndex = 5
        '
        'lbl_pool_name
        '
        Me.lbl_pool_name.AutoSize = True
        Me.lbl_pool_name.Location = New System.Drawing.Point(8, 104)
        Me.lbl_pool_name.Name = "lbl_pool_name"
        Me.lbl_pool_name.Size = New System.Drawing.Size(93, 13)
        Me.lbl_pool_name.TabIndex = 6
        Me.lbl_pool_name.Text = "Mining pool to use"
        '
        'cmb_pool
        '
        Me.cmb_pool.FormattingEnabled = True
        Me.cmb_pool.Location = New System.Drawing.Point(232, 96)
        Me.cmb_pool.Name = "cmb_pool"
        Me.cmb_pool.Size = New System.Drawing.Size(170, 21)
        Me.cmb_pool.TabIndex = 7
        '
        'Timer1
        '
        '
        'lbl_autostart_name
        '
        Me.lbl_autostart_name.AutoSize = True
        Me.lbl_autostart_name.Location = New System.Drawing.Point(8, 128)
        Me.lbl_autostart_name.Name = "lbl_autostart_name"
        Me.lbl_autostart_name.Size = New System.Drawing.Size(156, 13)
        Me.lbl_autostart_name.TabIndex = 8
        Me.lbl_autostart_name.Text = "Autostart Mining on system start"
        '
        'chk_autostart_true
        '
        Me.chk_autostart_true.AutoSize = True
        Me.chk_autostart_true.Location = New System.Drawing.Point(232, 128)
        Me.chk_autostart_true.Name = "chk_autostart_true"
        Me.chk_autostart_true.Size = New System.Drawing.Size(15, 14)
        Me.chk_autostart_true.TabIndex = 9
        Me.chk_autostart_true.UseVisualStyleBackColor = True
        '
        'btn_apply_settings
        '
        Me.btn_apply_settings.Location = New System.Drawing.Point(232, 224)
        Me.btn_apply_settings.Name = "btn_apply_settings"
        Me.btn_apply_settings.Size = New System.Drawing.Size(129, 23)
        Me.btn_apply_settings.TabIndex = 10
        Me.btn_apply_settings.Text = "Apply Settings"
        Me.btn_apply_settings.UseVisualStyleBackColor = True
        '
        'lbl_apply_settings_hint
        '
        Me.lbl_apply_settings_hint.AutoSize = True
        Me.lbl_apply_settings_hint.Location = New System.Drawing.Point(368, 232)
        Me.lbl_apply_settings_hint.Name = "lbl_apply_settings_hint"
        Me.lbl_apply_settings_hint.Size = New System.Drawing.Size(256, 13)
        Me.lbl_apply_settings_hint.TabIndex = 12
        Me.lbl_apply_settings_hint.Text = "If Autostart is active, this will start the Funding as well"
        '
        'nf
        '
        Me.nf.Text = "Snowden Angels Support"
        Me.nf.Visible = True
        '
        'lbl_xmrpath_name
        '
        Me.lbl_xmrpath_name.AutoSize = True
        Me.lbl_xmrpath_name.Location = New System.Drawing.Point(8, 32)
        Me.lbl_xmrpath_name.Name = "lbl_xmrpath_name"
        Me.lbl_xmrpath_name.Size = New System.Drawing.Size(70, 13)
        Me.lbl_xmrpath_name.TabIndex = 13
        Me.lbl_xmrpath_name.Text = "Path to Miner"
        '
        'lbl_xmrpath_status
        '
        Me.lbl_xmrpath_status.AutoSize = True
        Me.lbl_xmrpath_status.Location = New System.Drawing.Point(232, 32)
        Me.lbl_xmrpath_status.Name = "lbl_xmrpath_status"
        Me.lbl_xmrpath_status.Size = New System.Drawing.Size(53, 13)
        Me.lbl_xmrpath_status.TabIndex = 14
        Me.lbl_xmrpath_status.Text = "Unknown"
        '
        'lbl_cores_number_total
        '
        Me.lbl_cores_number_total.AutoSize = True
        Me.lbl_cores_number_total.Location = New System.Drawing.Point(408, 80)
        Me.lbl_cores_number_total.Name = "lbl_cores_number_total"
        Me.lbl_cores_number_total.Size = New System.Drawing.Size(51, 13)
        Me.lbl_cores_number_total.TabIndex = 15
        Me.lbl_cores_number_total.Text = "unknown"
        '
        'lbl_xmrtcpport_name
        '
        Me.lbl_xmrtcpport_name.AutoSize = True
        Me.lbl_xmrtcpport_name.Location = New System.Drawing.Point(8, 56)
        Me.lbl_xmrtcpport_name.Name = "lbl_xmrtcpport_name"
        Me.lbl_xmrtcpport_name.Size = New System.Drawing.Size(78, 13)
        Me.lbl_xmrtcpport_name.TabIndex = 16
        Me.lbl_xmrtcpport_name.Text = "Miner TCP port"
        '
        'lbl_xmrtcpport_status
        '
        Me.lbl_xmrtcpport_status.AutoSize = True
        Me.lbl_xmrtcpport_status.Location = New System.Drawing.Point(232, 56)
        Me.lbl_xmrtcpport_status.Name = "lbl_xmrtcpport_status"
        Me.lbl_xmrtcpport_status.Size = New System.Drawing.Size(53, 13)
        Me.lbl_xmrtcpport_status.TabIndex = 17
        Me.lbl_xmrtcpport_status.Text = "Unknown"
        '
        'lnk_minerport
        '
        Me.lnk_minerport.AutoSize = True
        Me.lnk_minerport.Location = New System.Drawing.Point(304, 56)
        Me.lnk_minerport.Name = "lnk_minerport"
        Me.lnk_minerport.Size = New System.Drawing.Size(51, 13)
        Me.lnk_minerport.TabIndex = 18
        Me.lnk_minerport.TabStop = True
        Me.lnk_minerport.Text = "unknown"
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(8, 280)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOutput.Size = New System.Drawing.Size(840, 158)
        Me.txtOutput.TabIndex = 19
        '
        'lbl_startminimized_name
        '
        Me.lbl_startminimized_name.AutoSize = True
        Me.lbl_startminimized_name.Location = New System.Drawing.Point(8, 152)
        Me.lbl_startminimized_name.Name = "lbl_startminimized_name"
        Me.lbl_startminimized_name.Size = New System.Drawing.Size(131, 13)
        Me.lbl_startminimized_name.TabIndex = 20
        Me.lbl_startminimized_name.Text = "Start GUI minimized to tray"
        '
        'chk_startminimized
        '
        Me.chk_startminimized.AutoSize = True
        Me.chk_startminimized.Location = New System.Drawing.Point(232, 152)
        Me.chk_startminimized.Name = "chk_startminimized"
        Me.chk_startminimized.Size = New System.Drawing.Size(15, 14)
        Me.chk_startminimized.TabIndex = 21
        Me.chk_startminimized.UseVisualStyleBackColor = True
        '
        'txt_userkey_status
        '
        Me.txt_userkey_status.Location = New System.Drawing.Point(232, 440)
        Me.txt_userkey_status.Name = "txt_userkey_status"
        Me.txt_userkey_status.ReadOnly = True
        Me.txt_userkey_status.Size = New System.Drawing.Size(616, 20)
        Me.txt_userkey_status.TabIndex = 22
        '
        'lbl_userkey_name
        '
        Me.lbl_userkey_name.AutoSize = True
        Me.lbl_userkey_name.Location = New System.Drawing.Point(8, 448)
        Me.lbl_userkey_name.Name = "lbl_userkey_name"
        Me.lbl_userkey_name.Size = New System.Drawing.Size(46, 13)
        Me.lbl_userkey_name.TabIndex = 23
        Me.lbl_userkey_name.Text = "Userkey"
        '
        'lbl_allowErrorTransfer_name
        '
        Me.lbl_allowErrorTransfer_name.AutoSize = True
        Me.lbl_allowErrorTransfer_name.Location = New System.Drawing.Point(8, 176)
        Me.lbl_allowErrorTransfer_name.Name = "lbl_allowErrorTransfer_name"
        Me.lbl_allowErrorTransfer_name.Size = New System.Drawing.Size(213, 13)
        Me.lbl_allowErrorTransfer_name.TabIndex = 24
        Me.lbl_allowErrorTransfer_name.Text = "Allow transfer of anonymous error messages"
        '
        'chk_allowErrorTransfer
        '
        Me.chk_allowErrorTransfer.AutoSize = True
        Me.chk_allowErrorTransfer.Location = New System.Drawing.Point(232, 176)
        Me.chk_allowErrorTransfer.Name = "chk_allowErrorTransfer"
        Me.chk_allowErrorTransfer.Size = New System.Drawing.Size(15, 14)
        Me.chk_allowErrorTransfer.TabIndex = 25
        Me.chk_allowErrorTransfer.UseVisualStyleBackColor = True
        '
        'lbl_allowStatsTransfer_name
        '
        Me.lbl_allowStatsTransfer_name.AutoSize = True
        Me.lbl_allowStatsTransfer_name.Location = New System.Drawing.Point(8, 200)
        Me.lbl_allowStatsTransfer_name.Name = "lbl_allowStatsTransfer_name"
        Me.lbl_allowStatsTransfer_name.Size = New System.Drawing.Size(166, 13)
        Me.lbl_allowStatsTransfer_name.TabIndex = 26
        Me.lbl_allowStatsTransfer_name.Text = "Allow transfer of Funding statistics"
        '
        'chk_allowStatsTransfer
        '
        Me.chk_allowStatsTransfer.AutoSize = True
        Me.chk_allowStatsTransfer.Location = New System.Drawing.Point(232, 200)
        Me.chk_allowStatsTransfer.Name = "chk_allowStatsTransfer"
        Me.chk_allowStatsTransfer.Size = New System.Drawing.Size(15, 14)
        Me.chk_allowStatsTransfer.TabIndex = 27
        Me.chk_allowStatsTransfer.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 466)
        Me.Controls.Add(Me.cmb_cores)
        Me.Controls.Add(Me.chk_allowStatsTransfer)
        Me.Controls.Add(Me.lbl_allowStatsTransfer_name)
        Me.Controls.Add(Me.chk_allowErrorTransfer)
        Me.Controls.Add(Me.lbl_allowErrorTransfer_name)
        Me.Controls.Add(Me.lbl_userkey_name)
        Me.Controls.Add(Me.txt_userkey_status)
        Me.Controls.Add(Me.chk_startminimized)
        Me.Controls.Add(Me.lbl_startminimized_name)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.lnk_minerport)
        Me.Controls.Add(Me.lbl_xmrtcpport_status)
        Me.Controls.Add(Me.lbl_xmrtcpport_name)
        Me.Controls.Add(Me.lbl_cores_number_total)
        Me.Controls.Add(Me.lbl_xmrpath_status)
        Me.Controls.Add(Me.lbl_xmrpath_name)
        Me.Controls.Add(Me.lbl_apply_settings_hint)
        Me.Controls.Add(Me.btn_apply_settings)
        Me.Controls.Add(Me.chk_autostart_true)
        Me.Controls.Add(Me.lbl_autostart_name)
        Me.Controls.Add(Me.cmb_pool)
        Me.Controls.Add(Me.lbl_pool_name)
        Me.Controls.Add(Me.lbl_cores_name)
        Me.Controls.Add(Me.btn_miner_stop)
        Me.Controls.Add(Me.btn_miner_start)
        Me.Controls.Add(Me.lbl_status_response)
        Me.Controls.Add(Me.lbl_status_name)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Snowden Angels Support"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_status_name As Label
    Friend WithEvents lbl_status_response As Label
    Friend WithEvents btn_miner_start As Button
    Friend WithEvents btn_miner_stop As Button
    Friend WithEvents lbl_cores_name As Label
    Friend WithEvents cmb_cores As ComboBox
    Friend WithEvents lbl_pool_name As Label
    Friend WithEvents cmb_pool As ComboBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lbl_autostart_name As Label
    Friend WithEvents chk_autostart_true As CheckBox
    Friend WithEvents btn_apply_settings As Button
    Friend WithEvents lbl_apply_settings_hint As Label
    Friend WithEvents nf As NotifyIcon
    Friend WithEvents lbl_xmrpath_name As Label
    Friend WithEvents lbl_xmrpath_status As Label
    Friend WithEvents lbl_cores_number_total As Label
    Friend WithEvents lbl_xmrtcpport_name As Label
    Friend WithEvents lbl_xmrtcpport_status As Label
    Friend WithEvents lnk_minerport As LinkLabel
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents lbl_startminimized_name As Label
    Friend WithEvents chk_startminimized As CheckBox
    Friend WithEvents txt_userkey_status As TextBox
    Friend WithEvents lbl_userkey_name As Label
    Friend WithEvents lbl_allowErrorTransfer_name As Label
    Friend WithEvents chk_allowErrorTransfer As CheckBox
    Friend WithEvents lbl_allowStatsTransfer_name As Label
    Friend WithEvents chk_allowStatsTransfer As CheckBox
End Class
