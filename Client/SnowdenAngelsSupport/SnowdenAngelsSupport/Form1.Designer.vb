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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.nf = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tab_stats = New System.Windows.Forms.TabPage()
        Me.lbl_hashrate_status = New System.Windows.Forms.Label()
        Me.lbl_currenthashrate_name = New System.Windows.Forms.Label()
        Me.tab_config = New System.Windows.Forms.TabPage()
        Me.btn_userkey_change = New System.Windows.Forms.Button()
        Me.cmb_cores = New System.Windows.Forms.ComboBox()
        Me.chk_allowStatsTransfer = New System.Windows.Forms.CheckBox()
        Me.lbl_allowStatsTransfer_name = New System.Windows.Forms.Label()
        Me.chk_allowErrorTransfer = New System.Windows.Forms.CheckBox()
        Me.lbl_allowErrorTransfer_name = New System.Windows.Forms.Label()
        Me.lbl_userkey_name = New System.Windows.Forms.Label()
        Me.txt_userkey_status = New System.Windows.Forms.TextBox()
        Me.chk_startminimized = New System.Windows.Forms.CheckBox()
        Me.lbl_startminimized_name = New System.Windows.Forms.Label()
        Me.lnk_minerport = New System.Windows.Forms.LinkLabel()
        Me.lbl_xmrtcpport_status = New System.Windows.Forms.Label()
        Me.lbl_xmrtcpport_name = New System.Windows.Forms.Label()
        Me.lbl_cores_number_total = New System.Windows.Forms.Label()
        Me.lbl_xmrpath_status = New System.Windows.Forms.Label()
        Me.lbl_xmrpath_name = New System.Windows.Forms.Label()
        Me.lbl_apply_settings_hint = New System.Windows.Forms.Label()
        Me.btn_apply_settings = New System.Windows.Forms.Button()
        Me.chk_autostart_true = New System.Windows.Forms.CheckBox()
        Me.lbl_autostart_name = New System.Windows.Forms.Label()
        Me.cmb_pool = New System.Windows.Forms.ComboBox()
        Me.lbl_pool_name = New System.Windows.Forms.Label()
        Me.lbl_cores_name = New System.Windows.Forms.Label()
        Me.tab_logs = New System.Windows.Forms.TabPage()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.lnk_update = New System.Windows.Forms.LinkLabel()
        Me.btn_miner_stop = New System.Windows.Forms.Button()
        Me.btn_miner_start = New System.Windows.Forms.Button()
        Me.lbl_status_response = New System.Windows.Forms.Label()
        Me.lbl_status_name = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pct_box_tuwat = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.tab_stats.SuspendLayout()
        Me.tab_config.SuspendLayout()
        Me.tab_logs.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pct_box_tuwat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'nf
        '
        Me.nf.Text = "Snowden Angels Support"
        Me.nf.Visible = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab_stats)
        Me.TabControl1.Controls.Add(Me.tab_config)
        Me.TabControl1.Controls.Add(Me.tab_logs)
        Me.TabControl1.Location = New System.Drawing.Point(8, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(864, 312)
        Me.TabControl1.TabIndex = 31
        '
        'tab_stats
        '
        Me.tab_stats.Controls.Add(Me.lbl_hashrate_status)
        Me.tab_stats.Controls.Add(Me.lbl_currenthashrate_name)
        Me.tab_stats.Location = New System.Drawing.Point(4, 22)
        Me.tab_stats.Name = "tab_stats"
        Me.tab_stats.Size = New System.Drawing.Size(856, 286)
        Me.tab_stats.TabIndex = 2
        Me.tab_stats.Text = "Statistics"
        Me.tab_stats.UseVisualStyleBackColor = True
        '
        'lbl_hashrate_status
        '
        Me.lbl_hashrate_status.AutoSize = True
        Me.lbl_hashrate_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_hashrate_status.Location = New System.Drawing.Point(8, 32)
        Me.lbl_hashrate_status.Name = "lbl_hashrate_status"
        Me.lbl_hashrate_status.Size = New System.Drawing.Size(91, 25)
        Me.lbl_hashrate_status.TabIndex = 61
        Me.lbl_hashrate_status.Text = "unknown"
        Me.lbl_hashrate_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_currenthashrate_name
        '
        Me.lbl_currenthashrate_name.AutoSize = True
        Me.lbl_currenthashrate_name.Location = New System.Drawing.Point(8, 8)
        Me.lbl_currenthashrate_name.Name = "lbl_currenthashrate_name"
        Me.lbl_currenthashrate_name.Size = New System.Drawing.Size(91, 13)
        Me.lbl_currenthashrate_name.TabIndex = 60
        Me.lbl_currenthashrate_name.Text = "Hashes / Second"
        '
        'tab_config
        '
        Me.tab_config.Controls.Add(Me.btn_userkey_change)
        Me.tab_config.Controls.Add(Me.cmb_cores)
        Me.tab_config.Controls.Add(Me.chk_allowStatsTransfer)
        Me.tab_config.Controls.Add(Me.lbl_allowStatsTransfer_name)
        Me.tab_config.Controls.Add(Me.chk_allowErrorTransfer)
        Me.tab_config.Controls.Add(Me.lbl_allowErrorTransfer_name)
        Me.tab_config.Controls.Add(Me.lbl_userkey_name)
        Me.tab_config.Controls.Add(Me.txt_userkey_status)
        Me.tab_config.Controls.Add(Me.chk_startminimized)
        Me.tab_config.Controls.Add(Me.lbl_startminimized_name)
        Me.tab_config.Controls.Add(Me.lnk_minerport)
        Me.tab_config.Controls.Add(Me.lbl_xmrtcpport_status)
        Me.tab_config.Controls.Add(Me.lbl_xmrtcpport_name)
        Me.tab_config.Controls.Add(Me.lbl_cores_number_total)
        Me.tab_config.Controls.Add(Me.lbl_xmrpath_status)
        Me.tab_config.Controls.Add(Me.lbl_xmrpath_name)
        Me.tab_config.Controls.Add(Me.lbl_apply_settings_hint)
        Me.tab_config.Controls.Add(Me.btn_apply_settings)
        Me.tab_config.Controls.Add(Me.chk_autostart_true)
        Me.tab_config.Controls.Add(Me.lbl_autostart_name)
        Me.tab_config.Controls.Add(Me.cmb_pool)
        Me.tab_config.Controls.Add(Me.lbl_pool_name)
        Me.tab_config.Controls.Add(Me.lbl_cores_name)
        Me.tab_config.Location = New System.Drawing.Point(4, 22)
        Me.tab_config.Name = "tab_config"
        Me.tab_config.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_config.Size = New System.Drawing.Size(856, 286)
        Me.tab_config.TabIndex = 0
        Me.tab_config.Text = "Configuration"
        Me.tab_config.UseVisualStyleBackColor = True
        '
        'btn_userkey_change
        '
        Me.btn_userkey_change.Location = New System.Drawing.Point(720, 256)
        Me.btn_userkey_change.Name = "btn_userkey_change"
        Me.btn_userkey_change.Size = New System.Drawing.Size(129, 23)
        Me.btn_userkey_change.TabIndex = 57
        Me.btn_userkey_change.Text = "Change userkey"
        Me.btn_userkey_change.UseVisualStyleBackColor = True
        '
        'cmb_cores
        '
        Me.cmb_cores.FormattingEnabled = True
        Me.cmb_cores.Location = New System.Drawing.Point(232, 48)
        Me.cmb_cores.Name = "cmb_cores"
        Me.cmb_cores.Size = New System.Drawing.Size(170, 21)
        Me.cmb_cores.TabIndex = 36
        '
        'chk_allowStatsTransfer
        '
        Me.chk_allowStatsTransfer.AutoSize = True
        Me.chk_allowStatsTransfer.Location = New System.Drawing.Point(232, 176)
        Me.chk_allowStatsTransfer.Name = "chk_allowStatsTransfer"
        Me.chk_allowStatsTransfer.Size = New System.Drawing.Size(15, 14)
        Me.chk_allowStatsTransfer.TabIndex = 56
        Me.chk_allowStatsTransfer.UseVisualStyleBackColor = True
        '
        'lbl_allowStatsTransfer_name
        '
        Me.lbl_allowStatsTransfer_name.AutoSize = True
        Me.lbl_allowStatsTransfer_name.Location = New System.Drawing.Point(8, 176)
        Me.lbl_allowStatsTransfer_name.Name = "lbl_allowStatsTransfer_name"
        Me.lbl_allowStatsTransfer_name.Size = New System.Drawing.Size(166, 13)
        Me.lbl_allowStatsTransfer_name.TabIndex = 55
        Me.lbl_allowStatsTransfer_name.Text = "Allow transfer of Funding statistics"
        '
        'chk_allowErrorTransfer
        '
        Me.chk_allowErrorTransfer.AutoSize = True
        Me.chk_allowErrorTransfer.Location = New System.Drawing.Point(232, 152)
        Me.chk_allowErrorTransfer.Name = "chk_allowErrorTransfer"
        Me.chk_allowErrorTransfer.Size = New System.Drawing.Size(15, 14)
        Me.chk_allowErrorTransfer.TabIndex = 54
        Me.chk_allowErrorTransfer.UseVisualStyleBackColor = True
        '
        'lbl_allowErrorTransfer_name
        '
        Me.lbl_allowErrorTransfer_name.AutoSize = True
        Me.lbl_allowErrorTransfer_name.Location = New System.Drawing.Point(8, 152)
        Me.lbl_allowErrorTransfer_name.Name = "lbl_allowErrorTransfer_name"
        Me.lbl_allowErrorTransfer_name.Size = New System.Drawing.Size(213, 13)
        Me.lbl_allowErrorTransfer_name.TabIndex = 53
        Me.lbl_allowErrorTransfer_name.Text = "Allow transfer of anonymous error messages"
        '
        'lbl_userkey_name
        '
        Me.lbl_userkey_name.AutoSize = True
        Me.lbl_userkey_name.Location = New System.Drawing.Point(8, 264)
        Me.lbl_userkey_name.Name = "lbl_userkey_name"
        Me.lbl_userkey_name.Size = New System.Drawing.Size(46, 13)
        Me.lbl_userkey_name.TabIndex = 52
        Me.lbl_userkey_name.Text = "Userkey"
        '
        'txt_userkey_status
        '
        Me.txt_userkey_status.Location = New System.Drawing.Point(232, 256)
        Me.txt_userkey_status.Name = "txt_userkey_status"
        Me.txt_userkey_status.ReadOnly = True
        Me.txt_userkey_status.Size = New System.Drawing.Size(480, 20)
        Me.txt_userkey_status.TabIndex = 51
        '
        'chk_startminimized
        '
        Me.chk_startminimized.AutoSize = True
        Me.chk_startminimized.Location = New System.Drawing.Point(232, 128)
        Me.chk_startminimized.Name = "chk_startminimized"
        Me.chk_startminimized.Size = New System.Drawing.Size(15, 14)
        Me.chk_startminimized.TabIndex = 50
        Me.chk_startminimized.UseVisualStyleBackColor = True
        '
        'lbl_startminimized_name
        '
        Me.lbl_startminimized_name.AutoSize = True
        Me.lbl_startminimized_name.Location = New System.Drawing.Point(8, 128)
        Me.lbl_startminimized_name.Name = "lbl_startminimized_name"
        Me.lbl_startminimized_name.Size = New System.Drawing.Size(131, 13)
        Me.lbl_startminimized_name.TabIndex = 49
        Me.lbl_startminimized_name.Text = "Start GUI minimized to tray"
        '
        'lnk_minerport
        '
        Me.lnk_minerport.AutoSize = True
        Me.lnk_minerport.Location = New System.Drawing.Point(304, 32)
        Me.lnk_minerport.Name = "lnk_minerport"
        Me.lnk_minerport.Size = New System.Drawing.Size(51, 13)
        Me.lnk_minerport.TabIndex = 48
        Me.lnk_minerport.TabStop = True
        Me.lnk_minerport.Text = "unknown"
        '
        'lbl_xmrtcpport_status
        '
        Me.lbl_xmrtcpport_status.AutoSize = True
        Me.lbl_xmrtcpport_status.Location = New System.Drawing.Point(232, 32)
        Me.lbl_xmrtcpport_status.Name = "lbl_xmrtcpport_status"
        Me.lbl_xmrtcpport_status.Size = New System.Drawing.Size(53, 13)
        Me.lbl_xmrtcpport_status.TabIndex = 47
        Me.lbl_xmrtcpport_status.Text = "Unknown"
        '
        'lbl_xmrtcpport_name
        '
        Me.lbl_xmrtcpport_name.AutoSize = True
        Me.lbl_xmrtcpport_name.Location = New System.Drawing.Point(8, 32)
        Me.lbl_xmrtcpport_name.Name = "lbl_xmrtcpport_name"
        Me.lbl_xmrtcpport_name.Size = New System.Drawing.Size(78, 13)
        Me.lbl_xmrtcpport_name.TabIndex = 46
        Me.lbl_xmrtcpport_name.Text = "Miner TCP port"
        '
        'lbl_cores_number_total
        '
        Me.lbl_cores_number_total.AutoSize = True
        Me.lbl_cores_number_total.Location = New System.Drawing.Point(408, 56)
        Me.lbl_cores_number_total.Name = "lbl_cores_number_total"
        Me.lbl_cores_number_total.Size = New System.Drawing.Size(51, 13)
        Me.lbl_cores_number_total.TabIndex = 45
        Me.lbl_cores_number_total.Text = "unknown"
        '
        'lbl_xmrpath_status
        '
        Me.lbl_xmrpath_status.AutoSize = True
        Me.lbl_xmrpath_status.Location = New System.Drawing.Point(232, 8)
        Me.lbl_xmrpath_status.Name = "lbl_xmrpath_status"
        Me.lbl_xmrpath_status.Size = New System.Drawing.Size(53, 13)
        Me.lbl_xmrpath_status.TabIndex = 44
        Me.lbl_xmrpath_status.Text = "Unknown"
        '
        'lbl_xmrpath_name
        '
        Me.lbl_xmrpath_name.AutoSize = True
        Me.lbl_xmrpath_name.Location = New System.Drawing.Point(8, 8)
        Me.lbl_xmrpath_name.Name = "lbl_xmrpath_name"
        Me.lbl_xmrpath_name.Size = New System.Drawing.Size(102, 13)
        Me.lbl_xmrpath_name.TabIndex = 43
        Me.lbl_xmrpath_name.Text = "Path to Miner config"
        '
        'lbl_apply_settings_hint
        '
        Me.lbl_apply_settings_hint.AutoSize = True
        Me.lbl_apply_settings_hint.Location = New System.Drawing.Point(368, 208)
        Me.lbl_apply_settings_hint.Name = "lbl_apply_settings_hint"
        Me.lbl_apply_settings_hint.Size = New System.Drawing.Size(256, 13)
        Me.lbl_apply_settings_hint.TabIndex = 42
        Me.lbl_apply_settings_hint.Text = "If Autostart is active, this will start the Funding as well"
        '
        'btn_apply_settings
        '
        Me.btn_apply_settings.Location = New System.Drawing.Point(232, 200)
        Me.btn_apply_settings.Name = "btn_apply_settings"
        Me.btn_apply_settings.Size = New System.Drawing.Size(129, 23)
        Me.btn_apply_settings.TabIndex = 41
        Me.btn_apply_settings.Text = "Apply Settings"
        Me.btn_apply_settings.UseVisualStyleBackColor = True
        '
        'chk_autostart_true
        '
        Me.chk_autostart_true.AutoSize = True
        Me.chk_autostart_true.Location = New System.Drawing.Point(232, 104)
        Me.chk_autostart_true.Name = "chk_autostart_true"
        Me.chk_autostart_true.Size = New System.Drawing.Size(15, 14)
        Me.chk_autostart_true.TabIndex = 40
        Me.chk_autostart_true.UseVisualStyleBackColor = True
        '
        'lbl_autostart_name
        '
        Me.lbl_autostart_name.AutoSize = True
        Me.lbl_autostart_name.Location = New System.Drawing.Point(8, 104)
        Me.lbl_autostart_name.Name = "lbl_autostart_name"
        Me.lbl_autostart_name.Size = New System.Drawing.Size(156, 13)
        Me.lbl_autostart_name.TabIndex = 39
        Me.lbl_autostart_name.Text = "Autostart Mining on system start"
        '
        'cmb_pool
        '
        Me.cmb_pool.FormattingEnabled = True
        Me.cmb_pool.Location = New System.Drawing.Point(232, 72)
        Me.cmb_pool.Name = "cmb_pool"
        Me.cmb_pool.Size = New System.Drawing.Size(170, 21)
        Me.cmb_pool.TabIndex = 38
        '
        'lbl_pool_name
        '
        Me.lbl_pool_name.AutoSize = True
        Me.lbl_pool_name.Location = New System.Drawing.Point(8, 80)
        Me.lbl_pool_name.Name = "lbl_pool_name"
        Me.lbl_pool_name.Size = New System.Drawing.Size(93, 13)
        Me.lbl_pool_name.TabIndex = 37
        Me.lbl_pool_name.Text = "Mining pool to use"
        '
        'lbl_cores_name
        '
        Me.lbl_cores_name.AutoSize = True
        Me.lbl_cores_name.Location = New System.Drawing.Point(8, 56)
        Me.lbl_cores_name.Name = "lbl_cores_name"
        Me.lbl_cores_name.Size = New System.Drawing.Size(143, 13)
        Me.lbl_cores_name.TabIndex = 35
        Me.lbl_cores_name.Text = "Number of CPU Cores to use"
        '
        'tab_logs
        '
        Me.tab_logs.Controls.Add(Me.txtOutput)
        Me.tab_logs.Location = New System.Drawing.Point(4, 22)
        Me.tab_logs.Name = "tab_logs"
        Me.tab_logs.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_logs.Size = New System.Drawing.Size(856, 286)
        Me.tab_logs.TabIndex = 1
        Me.tab_logs.Text = "Logs"
        Me.tab_logs.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(8, 8)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOutput.Size = New System.Drawing.Size(840, 272)
        Me.txtOutput.TabIndex = 20
        '
        'lnk_update
        '
        Me.lnk_update.AutoSize = True
        Me.lnk_update.Location = New System.Drawing.Point(728, 16)
        Me.lnk_update.Name = "lnk_update"
        Me.lnk_update.Size = New System.Drawing.Size(142, 13)
        Me.lnk_update.TabIndex = 58
        Me.lnk_update.TabStop = True
        Me.lnk_update.Text = "Update available, click here!"
        '
        'btn_miner_stop
        '
        Me.btn_miner_stop.Location = New System.Drawing.Point(528, 8)
        Me.btn_miner_stop.Name = "btn_miner_stop"
        Me.btn_miner_stop.Size = New System.Drawing.Size(129, 23)
        Me.btn_miner_stop.TabIndex = 60
        Me.btn_miner_stop.Text = "Stop Funding"
        Me.btn_miner_stop.UseVisualStyleBackColor = True
        '
        'btn_miner_start
        '
        Me.btn_miner_start.Location = New System.Drawing.Point(392, 8)
        Me.btn_miner_start.Name = "btn_miner_start"
        Me.btn_miner_start.Size = New System.Drawing.Size(129, 23)
        Me.btn_miner_start.TabIndex = 59
        Me.btn_miner_start.Text = "Start Funding"
        Me.btn_miner_start.UseVisualStyleBackColor = True
        '
        'lbl_status_response
        '
        Me.lbl_status_response.AutoSize = True
        Me.lbl_status_response.Location = New System.Drawing.Point(232, 16)
        Me.lbl_status_response.Name = "lbl_status_response"
        Me.lbl_status_response.Size = New System.Drawing.Size(53, 13)
        Me.lbl_status_response.TabIndex = 62
        Me.lbl_status_response.Text = "Unknown"
        '
        'lbl_status_name
        '
        Me.lbl_status_name.AutoSize = True
        Me.lbl_status_name.Location = New System.Drawing.Point(8, 16)
        Me.lbl_status_name.Name = "lbl_status_name"
        Me.lbl_status_name.Size = New System.Drawing.Size(116, 13)
        Me.lbl_status_name.TabIndex = 61
        Me.lbl_status_name.Text = "Status of Monero miner"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.SnowdenAngelsSupport.My.Resources.Resources.ForTheRefugees_552_204
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(8, 360)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(552, 200)
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'pct_box_tuwat
        '
        Me.pct_box_tuwat.BackgroundImage = Global.SnowdenAngelsSupport.My.Resources.Resources._300px_34c3_tuwat
        Me.pct_box_tuwat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pct_box_tuwat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pct_box_tuwat.ImageLocation = ""
        Me.pct_box_tuwat.Location = New System.Drawing.Point(568, 360)
        Me.pct_box_tuwat.Name = "pct_box_tuwat"
        Me.pct_box_tuwat.Size = New System.Drawing.Size(304, 56)
        Me.pct_box_tuwat.TabIndex = 63
        Me.pct_box_tuwat.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 568)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pct_box_tuwat)
        Me.Controls.Add(Me.lbl_status_response)
        Me.Controls.Add(Me.lbl_status_name)
        Me.Controls.Add(Me.btn_miner_stop)
        Me.Controls.Add(Me.btn_miner_start)
        Me.Controls.Add(Me.lnk_update)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Snowden Angels Support"
        Me.TabControl1.ResumeLayout(False)
        Me.tab_stats.ResumeLayout(False)
        Me.tab_stats.PerformLayout()
        Me.tab_config.ResumeLayout(False)
        Me.tab_config.PerformLayout()
        Me.tab_logs.ResumeLayout(False)
        Me.tab_logs.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pct_box_tuwat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents nf As NotifyIcon
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tab_stats As TabPage
    Friend WithEvents lbl_hashrate_status As Label
    Friend WithEvents lbl_currenthashrate_name As Label
    Friend WithEvents tab_config As TabPage
    Friend WithEvents cmb_cores As ComboBox
    Friend WithEvents chk_allowStatsTransfer As CheckBox
    Friend WithEvents lbl_allowStatsTransfer_name As Label
    Friend WithEvents chk_allowErrorTransfer As CheckBox
    Friend WithEvents lbl_allowErrorTransfer_name As Label
    Friend WithEvents lbl_userkey_name As Label
    Friend WithEvents txt_userkey_status As TextBox
    Friend WithEvents chk_startminimized As CheckBox
    Friend WithEvents lbl_startminimized_name As Label
    Friend WithEvents lnk_minerport As LinkLabel
    Friend WithEvents lbl_xmrtcpport_status As Label
    Friend WithEvents lbl_xmrtcpport_name As Label
    Friend WithEvents lbl_cores_number_total As Label
    Friend WithEvents lbl_xmrpath_status As Label
    Friend WithEvents lbl_xmrpath_name As Label
    Friend WithEvents lbl_apply_settings_hint As Label
    Friend WithEvents btn_apply_settings As Button
    Friend WithEvents chk_autostart_true As CheckBox
    Friend WithEvents lbl_autostart_name As Label
    Friend WithEvents cmb_pool As ComboBox
    Friend WithEvents lbl_pool_name As Label
    Friend WithEvents lbl_cores_name As Label
    Friend WithEvents tab_logs As TabPage
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents lnk_update As LinkLabel
    Friend WithEvents btn_miner_stop As Button
    Friend WithEvents btn_miner_start As Button
    Friend WithEvents lbl_status_response As Label
    Friend WithEvents lbl_status_name As Label
    Friend WithEvents pct_box_tuwat As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_userkey_change As Button
End Class
