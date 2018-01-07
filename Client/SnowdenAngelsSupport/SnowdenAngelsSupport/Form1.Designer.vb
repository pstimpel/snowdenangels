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
        Me.lbl_turnfundingontoseestats = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_stats_allusers_xmr = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_stats_allusers_usd = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl_stats_allusers_hashes = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbl_stats_allusers_computers = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbl_stats_allusers_hashrateavg = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lbl_stats_allusers_users = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_localstats = New System.Windows.Forms.Label()
        Me.lbl_stats_personal_xmr = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl_stats_personal_usd = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbl_stats_personal_hashes = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbl_stats_personal_computers = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_stats_personal_hashrateavg = New System.Windows.Forms.Label()
        Me.lbl_hashratepersecond = New System.Windows.Forms.Label()
        Me.lbl_stats_personal_users = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_moneroaddress_status = New System.Windows.Forms.TextBox()
        Me.lbl_xmraddress_name = New System.Windows.Forms.Label()
        Me.lbl_hashrate_status = New System.Windows.Forms.Label()
        Me.lbl_currenthashrate_name = New System.Windows.Forms.Label()
        Me.tab_config = New System.Windows.Forms.TabPage()
        Me.lnk_helponline = New System.Windows.Forms.LinkLabel()
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
        Me.btn_miner_stop = New System.Windows.Forms.Button()
        Me.btn_miner_start = New System.Windows.Forms.Button()
        Me.lbl_share_name = New System.Windows.Forms.Label()
        Me.lnk_moreinfo = New System.Windows.Forms.LinkLabel()
        Me.pct_update = New System.Windows.Forms.PictureBox()
        Me.pct_trafficlight = New System.Windows.Forms.PictureBox()
        Me.pct_twitter = New System.Windows.Forms.PictureBox()
        Me.pct_googleplus = New System.Windows.Forms.PictureBox()
        Me.pct_facebook = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pct_box_tuwat = New System.Windows.Forms.PictureBox()
        Me.txt_errorlog = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.tab_stats.SuspendLayout()
        Me.tab_config.SuspendLayout()
        Me.tab_logs.SuspendLayout()
        CType(Me.pct_update, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pct_trafficlight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pct_twitter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pct_googleplus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pct_facebook, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Location = New System.Drawing.Point(8, 93)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(864, 288)
        Me.TabControl1.TabIndex = 31
        '
        'tab_stats
        '
        Me.tab_stats.Controls.Add(Me.lbl_turnfundingontoseestats)
        Me.tab_stats.Controls.Add(Me.Label1)
        Me.tab_stats.Controls.Add(Me.lbl_stats_allusers_xmr)
        Me.tab_stats.Controls.Add(Me.Label5)
        Me.tab_stats.Controls.Add(Me.lbl_stats_allusers_usd)
        Me.tab_stats.Controls.Add(Me.Label9)
        Me.tab_stats.Controls.Add(Me.lbl_stats_allusers_hashes)
        Me.tab_stats.Controls.Add(Me.Label13)
        Me.tab_stats.Controls.Add(Me.lbl_stats_allusers_computers)
        Me.tab_stats.Controls.Add(Me.Label15)
        Me.tab_stats.Controls.Add(Me.lbl_stats_allusers_hashrateavg)
        Me.tab_stats.Controls.Add(Me.Label17)
        Me.tab_stats.Controls.Add(Me.lbl_stats_allusers_users)
        Me.tab_stats.Controls.Add(Me.Label19)
        Me.tab_stats.Controls.Add(Me.Label4)
        Me.tab_stats.Controls.Add(Me.lbl_localstats)
        Me.tab_stats.Controls.Add(Me.lbl_stats_personal_xmr)
        Me.tab_stats.Controls.Add(Me.Label10)
        Me.tab_stats.Controls.Add(Me.lbl_stats_personal_usd)
        Me.tab_stats.Controls.Add(Me.Label12)
        Me.tab_stats.Controls.Add(Me.lbl_stats_personal_hashes)
        Me.tab_stats.Controls.Add(Me.Label8)
        Me.tab_stats.Controls.Add(Me.lbl_stats_personal_computers)
        Me.tab_stats.Controls.Add(Me.Label6)
        Me.tab_stats.Controls.Add(Me.lbl_stats_personal_hashrateavg)
        Me.tab_stats.Controls.Add(Me.lbl_hashratepersecond)
        Me.tab_stats.Controls.Add(Me.lbl_stats_personal_users)
        Me.tab_stats.Controls.Add(Me.Label2)
        Me.tab_stats.Controls.Add(Me.txt_moneroaddress_status)
        Me.tab_stats.Controls.Add(Me.lbl_xmraddress_name)
        Me.tab_stats.Controls.Add(Me.lbl_hashrate_status)
        Me.tab_stats.Controls.Add(Me.lbl_currenthashrate_name)
        Me.tab_stats.Location = New System.Drawing.Point(4, 22)
        Me.tab_stats.Name = "tab_stats"
        Me.tab_stats.Size = New System.Drawing.Size(856, 262)
        Me.tab_stats.TabIndex = 2
        Me.tab_stats.Text = "Statistics"
        Me.tab_stats.UseVisualStyleBackColor = True
        '
        'lbl_turnfundingontoseestats
        '
        Me.lbl_turnfundingontoseestats.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_turnfundingontoseestats.Location = New System.Drawing.Point(6, 10)
        Me.lbl_turnfundingontoseestats.Name = "lbl_turnfundingontoseestats"
        Me.lbl_turnfundingontoseestats.Size = New System.Drawing.Size(841, 214)
        Me.lbl_turnfundingontoseestats.TabIndex = 91
        Me.lbl_turnfundingontoseestats.Text = "Please Start Funding, and allow transfers of funding statistics"
        Me.lbl_turnfundingontoseestats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(484, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 37)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "Remote All Users"
        '
        'lbl_stats_allusers_xmr
        '
        Me.lbl_stats_allusers_xmr.AutoSize = True
        Me.lbl_stats_allusers_xmr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_allusers_xmr.Location = New System.Drawing.Point(747, 77)
        Me.lbl_stats_allusers_xmr.Name = "lbl_stats_allusers_xmr"
        Me.lbl_stats_allusers_xmr.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_allusers_xmr.TabIndex = 89
        Me.lbl_stats_allusers_xmr.Text = "unknown"
        Me.lbl_stats_allusers_xmr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(747, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Total XMR"
        '
        'lbl_stats_allusers_usd
        '
        Me.lbl_stats_allusers_usd.AutoSize = True
        Me.lbl_stats_allusers_usd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_allusers_usd.Location = New System.Drawing.Point(747, 140)
        Me.lbl_stats_allusers_usd.Name = "lbl_stats_allusers_usd"
        Me.lbl_stats_allusers_usd.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_allusers_usd.TabIndex = 87
        Me.lbl_stats_allusers_usd.Text = "unknown"
        Me.lbl_stats_allusers_usd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(747, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Total USD"
        '
        'lbl_stats_allusers_hashes
        '
        Me.lbl_stats_allusers_hashes.AutoSize = True
        Me.lbl_stats_allusers_hashes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_allusers_hashes.Location = New System.Drawing.Point(492, 139)
        Me.lbl_stats_allusers_hashes.Name = "lbl_stats_allusers_hashes"
        Me.lbl_stats_allusers_hashes.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_allusers_hashes.TabIndex = 85
        Me.lbl_stats_allusers_hashes.Text = "unknown"
        Me.lbl_stats_allusers_hashes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(492, 115)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 13)
        Me.Label13.TabIndex = 84
        Me.Label13.Text = "Hashes total"
        '
        'lbl_stats_allusers_computers
        '
        Me.lbl_stats_allusers_computers.AutoSize = True
        Me.lbl_stats_allusers_computers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_allusers_computers.Location = New System.Drawing.Point(620, 77)
        Me.lbl_stats_allusers_computers.Name = "lbl_stats_allusers_computers"
        Me.lbl_stats_allusers_computers.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_allusers_computers.TabIndex = 83
        Me.lbl_stats_allusers_computers.Text = "unknown"
        Me.lbl_stats_allusers_computers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(620, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 13)
        Me.Label15.TabIndex = 82
        Me.Label15.Text = "Computers"
        '
        'lbl_stats_allusers_hashrateavg
        '
        Me.lbl_stats_allusers_hashrateavg.AutoSize = True
        Me.lbl_stats_allusers_hashrateavg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_allusers_hashrateavg.Location = New System.Drawing.Point(491, 77)
        Me.lbl_stats_allusers_hashrateavg.Name = "lbl_stats_allusers_hashrateavg"
        Me.lbl_stats_allusers_hashrateavg.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_allusers_hashrateavg.TabIndex = 81
        Me.lbl_stats_allusers_hashrateavg.Text = "unknown"
        Me.lbl_stats_allusers_hashrateavg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(491, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(119, 13)
        Me.Label17.TabIndex = 80
        Me.Label17.Text = "Hashrate / Second avg"
        '
        'lbl_stats_allusers_users
        '
        Me.lbl_stats_allusers_users.AutoSize = True
        Me.lbl_stats_allusers_users.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_allusers_users.Location = New System.Drawing.Point(619, 140)
        Me.lbl_stats_allusers_users.Name = "lbl_stats_allusers_users"
        Me.lbl_stats_allusers_users.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_allusers_users.TabIndex = 79
        Me.lbl_stats_allusers_users.Text = "unknown"
        Me.lbl_stats_allusers_users.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(619, 116)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 78
        Me.Label19.Text = "Users"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(110, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(262, 37)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Remote Personal"
        '
        'lbl_localstats
        '
        Me.lbl_localstats.AutoSize = True
        Me.lbl_localstats.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_localstats.Location = New System.Drawing.Point(10, 9)
        Me.lbl_localstats.Name = "lbl_localstats"
        Me.lbl_localstats.Size = New System.Drawing.Size(94, 37)
        Me.lbl_localstats.TabIndex = 76
        Me.lbl_localstats.Text = "Local"
        '
        'lbl_stats_personal_xmr
        '
        Me.lbl_stats_personal_xmr.AutoSize = True
        Me.lbl_stats_personal_xmr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_personal_xmr.Location = New System.Drawing.Point(373, 77)
        Me.lbl_stats_personal_xmr.Name = "lbl_stats_personal_xmr"
        Me.lbl_stats_personal_xmr.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_personal_xmr.TabIndex = 75
        Me.lbl_stats_personal_xmr.Text = "unknown"
        Me.lbl_stats_personal_xmr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(373, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "Total XMR"
        '
        'lbl_stats_personal_usd
        '
        Me.lbl_stats_personal_usd.AutoSize = True
        Me.lbl_stats_personal_usd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_personal_usd.Location = New System.Drawing.Point(373, 140)
        Me.lbl_stats_personal_usd.Name = "lbl_stats_personal_usd"
        Me.lbl_stats_personal_usd.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_personal_usd.TabIndex = 73
        Me.lbl_stats_personal_usd.Text = "unknown"
        Me.lbl_stats_personal_usd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(373, 116)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 72
        Me.Label12.Text = "Total USD"
        '
        'lbl_stats_personal_hashes
        '
        Me.lbl_stats_personal_hashes.AutoSize = True
        Me.lbl_stats_personal_hashes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_personal_hashes.Location = New System.Drawing.Point(118, 139)
        Me.lbl_stats_personal_hashes.Name = "lbl_stats_personal_hashes"
        Me.lbl_stats_personal_hashes.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_personal_hashes.TabIndex = 71
        Me.lbl_stats_personal_hashes.Text = "unknown"
        Me.lbl_stats_personal_hashes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(118, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "Hashes total"
        '
        'lbl_stats_personal_computers
        '
        Me.lbl_stats_personal_computers.AutoSize = True
        Me.lbl_stats_personal_computers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_personal_computers.Location = New System.Drawing.Point(246, 77)
        Me.lbl_stats_personal_computers.Name = "lbl_stats_personal_computers"
        Me.lbl_stats_personal_computers.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_personal_computers.TabIndex = 69
        Me.lbl_stats_personal_computers.Text = "unknown"
        Me.lbl_stats_personal_computers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(246, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "Computers"
        '
        'lbl_stats_personal_hashrateavg
        '
        Me.lbl_stats_personal_hashrateavg.AutoSize = True
        Me.lbl_stats_personal_hashrateavg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_personal_hashrateavg.Location = New System.Drawing.Point(117, 77)
        Me.lbl_stats_personal_hashrateavg.Name = "lbl_stats_personal_hashrateavg"
        Me.lbl_stats_personal_hashrateavg.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_personal_hashrateavg.TabIndex = 67
        Me.lbl_stats_personal_hashrateavg.Text = "unknown"
        Me.lbl_stats_personal_hashrateavg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_hashratepersecond
        '
        Me.lbl_hashratepersecond.AutoSize = True
        Me.lbl_hashratepersecond.Location = New System.Drawing.Point(117, 53)
        Me.lbl_hashratepersecond.Name = "lbl_hashratepersecond"
        Me.lbl_hashratepersecond.Size = New System.Drawing.Size(119, 13)
        Me.lbl_hashratepersecond.TabIndex = 66
        Me.lbl_hashratepersecond.Text = "Hashrate / Second avg"
        '
        'lbl_stats_personal_users
        '
        Me.lbl_stats_personal_users.AutoSize = True
        Me.lbl_stats_personal_users.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stats_personal_users.Location = New System.Drawing.Point(245, 140)
        Me.lbl_stats_personal_users.Name = "lbl_stats_personal_users"
        Me.lbl_stats_personal_users.Size = New System.Drawing.Size(73, 20)
        Me.lbl_stats_personal_users.TabIndex = 65
        Me.lbl_stats_personal_users.Text = "unknown"
        Me.lbl_stats_personal_users.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(245, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Users"
        '
        'txt_moneroaddress_status
        '
        Me.txt_moneroaddress_status.Location = New System.Drawing.Point(128, 232)
        Me.txt_moneroaddress_status.Name = "txt_moneroaddress_status"
        Me.txt_moneroaddress_status.ReadOnly = True
        Me.txt_moneroaddress_status.Size = New System.Drawing.Size(720, 20)
        Me.txt_moneroaddress_status.TabIndex = 63
        '
        'lbl_xmraddress_name
        '
        Me.lbl_xmraddress_name.AutoSize = True
        Me.lbl_xmraddress_name.Location = New System.Drawing.Point(8, 236)
        Me.lbl_xmraddress_name.Name = "lbl_xmraddress_name"
        Me.lbl_xmraddress_name.Size = New System.Drawing.Size(114, 13)
        Me.lbl_xmraddress_name.TabIndex = 62
        Me.lbl_xmraddress_name.Text = "Monero address in use"
        '
        'lbl_hashrate_status
        '
        Me.lbl_hashrate_status.AutoSize = True
        Me.lbl_hashrate_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_hashrate_status.Location = New System.Drawing.Point(16, 77)
        Me.lbl_hashrate_status.Name = "lbl_hashrate_status"
        Me.lbl_hashrate_status.Size = New System.Drawing.Size(73, 20)
        Me.lbl_hashrate_status.TabIndex = 61
        Me.lbl_hashrate_status.Text = "unknown"
        Me.lbl_hashrate_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_currenthashrate_name
        '
        Me.lbl_currenthashrate_name.AutoSize = True
        Me.lbl_currenthashrate_name.Location = New System.Drawing.Point(16, 53)
        Me.lbl_currenthashrate_name.Name = "lbl_currenthashrate_name"
        Me.lbl_currenthashrate_name.Size = New System.Drawing.Size(91, 13)
        Me.lbl_currenthashrate_name.TabIndex = 60
        Me.lbl_currenthashrate_name.Text = "Hashes / Second"
        '
        'tab_config
        '
        Me.tab_config.Controls.Add(Me.lnk_helponline)
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
        Me.tab_config.Size = New System.Drawing.Size(856, 262)
        Me.tab_config.TabIndex = 0
        Me.tab_config.Text = "Configuration"
        Me.tab_config.UseVisualStyleBackColor = True
        '
        'lnk_helponline
        '
        Me.lnk_helponline.AutoSize = True
        Me.lnk_helponline.Location = New System.Drawing.Point(640, 206)
        Me.lnk_helponline.Name = "lnk_helponline"
        Me.lnk_helponline.Size = New System.Drawing.Size(60, 13)
        Me.lnk_helponline.TabIndex = 58
        Me.lnk_helponline.TabStop = True
        Me.lnk_helponline.Text = "Online help"
        '
        'btn_userkey_change
        '
        Me.btn_userkey_change.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_userkey_change.Location = New System.Drawing.Point(721, 234)
        Me.btn_userkey_change.Name = "btn_userkey_change"
        Me.btn_userkey_change.Size = New System.Drawing.Size(129, 22)
        Me.btn_userkey_change.TabIndex = 57
        Me.btn_userkey_change.Text = "Change userkey"
        Me.btn_userkey_change.UseVisualStyleBackColor = True
        '
        'cmb_cores
        '
        Me.cmb_cores.FormattingEnabled = True
        Me.cmb_cores.Location = New System.Drawing.Point(232, 50)
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
        Me.lbl_userkey_name.Location = New System.Drawing.Point(8, 239)
        Me.lbl_userkey_name.Name = "lbl_userkey_name"
        Me.lbl_userkey_name.Size = New System.Drawing.Size(46, 13)
        Me.lbl_userkey_name.TabIndex = 52
        Me.lbl_userkey_name.Text = "Userkey"
        '
        'txt_userkey_status
        '
        Me.txt_userkey_status.Location = New System.Drawing.Point(232, 235)
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
        Me.lbl_xmrtcpport_status.Location = New System.Drawing.Point(228, 32)
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
        Me.lbl_cores_number_total.Location = New System.Drawing.Point(408, 54)
        Me.lbl_cores_number_total.Name = "lbl_cores_number_total"
        Me.lbl_cores_number_total.Size = New System.Drawing.Size(51, 13)
        Me.lbl_cores_number_total.TabIndex = 45
        Me.lbl_cores_number_total.Text = "unknown"
        '
        'lbl_xmrpath_status
        '
        Me.lbl_xmrpath_status.AutoSize = True
        Me.lbl_xmrpath_status.Location = New System.Drawing.Point(228, 8)
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
        Me.lbl_apply_settings_hint.Location = New System.Drawing.Point(368, 206)
        Me.lbl_apply_settings_hint.Name = "lbl_apply_settings_hint"
        Me.lbl_apply_settings_hint.Size = New System.Drawing.Size(256, 13)
        Me.lbl_apply_settings_hint.TabIndex = 42
        Me.lbl_apply_settings_hint.Text = "If Autostart is active, this will start the Funding as well"
        '
        'btn_apply_settings
        '
        Me.btn_apply_settings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_apply_settings.Location = New System.Drawing.Point(231, 200)
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
        Me.cmb_pool.Location = New System.Drawing.Point(232, 76)
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
        Me.tab_logs.Controls.Add(Me.txt_errorlog)
        Me.tab_logs.Controls.Add(Me.txtOutput)
        Me.tab_logs.Location = New System.Drawing.Point(4, 22)
        Me.tab_logs.Name = "tab_logs"
        Me.tab_logs.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_logs.Size = New System.Drawing.Size(856, 262)
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
        Me.txtOutput.Size = New System.Drawing.Size(840, 189)
        Me.txtOutput.TabIndex = 20
        '
        'btn_miner_stop
        '
        Me.btn_miner_stop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_miner_stop.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_miner_stop.Location = New System.Drawing.Point(187, 5)
        Me.btn_miner_stop.Name = "btn_miner_stop"
        Me.btn_miner_stop.Size = New System.Drawing.Size(129, 82)
        Me.btn_miner_stop.TabIndex = 60
        Me.btn_miner_stop.Text = "Stop Funding"
        Me.btn_miner_stop.UseVisualStyleBackColor = True
        '
        'btn_miner_start
        '
        Me.btn_miner_start.BackColor = System.Drawing.Color.LightGreen
        Me.btn_miner_start.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_miner_start.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_miner_start.Location = New System.Drawing.Point(50, 5)
        Me.btn_miner_start.Name = "btn_miner_start"
        Me.btn_miner_start.Size = New System.Drawing.Size(129, 82)
        Me.btn_miner_start.TabIndex = 59
        Me.btn_miner_start.Text = "Start Funding"
        Me.btn_miner_start.UseVisualStyleBackColor = False
        '
        'lbl_share_name
        '
        Me.lbl_share_name.AutoSize = True
        Me.lbl_share_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_share_name.Location = New System.Drawing.Point(561, 454)
        Me.lbl_share_name.Name = "lbl_share_name"
        Me.lbl_share_name.Size = New System.Drawing.Size(155, 39)
        Me.lbl_share_name.TabIndex = 68
        Me.lbl_share_name.Text = "Share at"
        '
        'lnk_moreinfo
        '
        Me.lnk_moreinfo.AutoSize = True
        Me.lnk_moreinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnk_moreinfo.Location = New System.Drawing.Point(569, 384)
        Me.lnk_moreinfo.Name = "lnk_moreinfo"
        Me.lnk_moreinfo.Size = New System.Drawing.Size(306, 33)
        Me.lnk_moreinfo.TabIndex = 69
        Me.lnk_moreinfo.TabStop = True
        Me.lnk_moreinfo.Text = "bit.ly/snowdenangels"
        '
        'pct_update
        '
        Me.pct_update.BackgroundImage = Global.SnowdenAngelsSupport.My.Resources.Resources.update
        Me.pct_update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pct_update.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pct_update.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pct_update.Location = New System.Drawing.Point(779, 6)
        Me.pct_update.Name = "pct_update"
        Me.pct_update.Size = New System.Drawing.Size(88, 80)
        Me.pct_update.TabIndex = 71
        Me.pct_update.TabStop = False
        '
        'pct_trafficlight
        '
        Me.pct_trafficlight.BackgroundImage = Global.SnowdenAngelsSupport.My.Resources.Resources.traffic_red
        Me.pct_trafficlight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pct_trafficlight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pct_trafficlight.Location = New System.Drawing.Point(10, 5)
        Me.pct_trafficlight.Name = "pct_trafficlight"
        Me.pct_trafficlight.Size = New System.Drawing.Size(32, 82)
        Me.pct_trafficlight.TabIndex = 70
        Me.pct_trafficlight.TabStop = False
        '
        'pct_twitter
        '
        Me.pct_twitter.BackgroundImage = Global.SnowdenAngelsSupport.My.Resources.Resources.twitter
        Me.pct_twitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pct_twitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pct_twitter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pct_twitter.Location = New System.Drawing.Point(832, 452)
        Me.pct_twitter.Name = "pct_twitter"
        Me.pct_twitter.Size = New System.Drawing.Size(43, 44)
        Me.pct_twitter.TabIndex = 67
        Me.pct_twitter.TabStop = False
        '
        'pct_googleplus
        '
        Me.pct_googleplus.BackgroundImage = Global.SnowdenAngelsSupport.My.Resources.Resources.googleplus
        Me.pct_googleplus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pct_googleplus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pct_googleplus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pct_googleplus.Location = New System.Drawing.Point(784, 452)
        Me.pct_googleplus.Name = "pct_googleplus"
        Me.pct_googleplus.Size = New System.Drawing.Size(42, 44)
        Me.pct_googleplus.TabIndex = 66
        Me.pct_googleplus.TabStop = False
        '
        'pct_facebook
        '
        Me.pct_facebook.BackgroundImage = Global.SnowdenAngelsSupport.My.Resources.Resources.facebook
        Me.pct_facebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pct_facebook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pct_facebook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pct_facebook.Location = New System.Drawing.Point(736, 452)
        Me.pct_facebook.Name = "pct_facebook"
        Me.pct_facebook.Size = New System.Drawing.Size(42, 44)
        Me.pct_facebook.TabIndex = 65
        Me.pct_facebook.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.SnowdenAngelsSupport.My.Resources.Resources.ForTheRefugees_552_204
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(8, 388)
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
        Me.pct_box_tuwat.Location = New System.Drawing.Point(570, 532)
        Me.pct_box_tuwat.Name = "pct_box_tuwat"
        Me.pct_box_tuwat.Size = New System.Drawing.Size(304, 56)
        Me.pct_box_tuwat.TabIndex = 63
        Me.pct_box_tuwat.TabStop = False
        '
        'txt_errorlog
        '
        Me.txt_errorlog.Location = New System.Drawing.Point(8, 200)
        Me.txt_errorlog.Multiline = True
        Me.txt_errorlog.Name = "txt_errorlog"
        Me.txt_errorlog.ReadOnly = True
        Me.txt_errorlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_errorlog.Size = New System.Drawing.Size(840, 56)
        Me.txt_errorlog.TabIndex = 21
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 595)
        Me.Controls.Add(Me.pct_update)
        Me.Controls.Add(Me.pct_trafficlight)
        Me.Controls.Add(Me.lnk_moreinfo)
        Me.Controls.Add(Me.pct_twitter)
        Me.Controls.Add(Me.pct_googleplus)
        Me.Controls.Add(Me.pct_facebook)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pct_box_tuwat)
        Me.Controls.Add(Me.btn_miner_stop)
        Me.Controls.Add(Me.btn_miner_start)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lbl_share_name)
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
        CType(Me.pct_update, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pct_trafficlight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pct_twitter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pct_googleplus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pct_facebook, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btn_miner_stop As Button
    Friend WithEvents btn_miner_start As Button
    Friend WithEvents pct_box_tuwat As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_userkey_change As Button
    Friend WithEvents txt_moneroaddress_status As TextBox
    Friend WithEvents lbl_xmraddress_name As Label
    Friend WithEvents lnk_helponline As LinkLabel
    Friend WithEvents pct_facebook As PictureBox
    Friend WithEvents pct_googleplus As PictureBox
    Friend WithEvents pct_twitter As PictureBox
    Friend WithEvents lbl_share_name As Label
    Friend WithEvents lnk_moreinfo As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_stats_allusers_xmr As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lbl_stats_allusers_usd As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lbl_stats_allusers_hashes As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lbl_stats_allusers_computers As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lbl_stats_allusers_hashrateavg As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lbl_stats_allusers_users As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_localstats As Label
    Friend WithEvents lbl_stats_personal_xmr As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lbl_stats_personal_usd As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lbl_stats_personal_hashes As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lbl_stats_personal_computers As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lbl_stats_personal_hashrateavg As Label
    Friend WithEvents lbl_hashratepersecond As Label
    Friend WithEvents lbl_stats_personal_users As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_turnfundingontoseestats As Label
    Friend WithEvents pct_trafficlight As PictureBox
    Friend WithEvents pct_update As PictureBox
    Friend WithEvents txt_errorlog As TextBox
End Class
