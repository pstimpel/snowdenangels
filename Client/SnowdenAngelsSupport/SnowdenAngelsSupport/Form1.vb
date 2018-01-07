Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports Microsoft.Win32

Public Class Form1

    Public configured As Boolean
    Public cores As Int16
    Public pool As String
    Public autostart As Boolean
    Public xmrpath As String
    Public xmrtcpport As Int32
    Public startminimized As Boolean
    Public userkey As String
    Public allowStatsTransfer As Boolean
    Public allowErrorTransfer As Boolean
    Public computerkey As String
    Public minerPools(4) As Minerpool
    Public statsFirstRun As Boolean = True
    Public minerRuns As Boolean = False
    Public currentHashrate As Int32 = 0

    Public G_StatsCollection As StatsCollection

    Private timercounter As Int16 = 0

    Public Shared Event SessionEnding As SessionEndingEventHandler
    Private Shared WM_QUERYENDSESSION As Integer = &H11
    Private Shared systemShutdown As Boolean = False

    Private fundingstopped_counter As Integer = 0

#If DEBUG Then
    'Public errorcollector As String = "http://127.0.0.1/sgasupport/errorhandler.php"
    'Public statscollector As String = "http://127.0.0.1/sgasupport/statshandler.php"
    Public link_SharerEncoded As String = "https%3A%2F%2Fredzoneaction.org%2Fsgasupport%2F%3Fkey%3D"
    Public errorcollector As String = "https://redzoneaction.org/sgasupport/errorhandler.php"
    Public statscollector As String = "https://redzoneaction.org/sgasupport/statshandler.php"
    Private WalletAddressInUse As MinerConfig.XMRWalletAddress = MinerConfig.XMRWalletAddress.developer
    Private XMRStakStartupStyle as ProcessWindowStyle = ProcessWindowStyle.Normal
#Else
    Public link_SharerEncoded As String = "https%3A%2F%2Fredzoneaction.org%2Fsgasupport%2F%3Fkey%3D"
    Public errorcollector As String = "https://redzoneaction.org/sgasupport/errorhandler.php"
    Public statscollector As String = "https://redzoneaction.org/sgasupport/statshandler.php"
    Private WalletAddressInUse As MinerConfig.XMRWalletAddress = MinerConfig.XMRWalletAddress.ForTheRefugees
    Private XMRStakStartupStyle As ProcessWindowStyle = ProcessWindowStyle.Minimized
#End If


    Public nfContextmenu As New ContextMenuStrip


    Private Sub TimerExecute()

        If Processes.IsRunningMiner() = False Then

            If fundingstopped_counter > 2 Then

                Me.sts_strip_label1.Text = "Funding stopped"

            Else

                fundingstopped_counter = fundingstopped_counter + 1

            End If

            minerRuns = False

            Me.btn_miner_start.Enabled = True
            Me.btn_miner_stop.Enabled = False

            Me.pct_trafficlight.BackgroundImage = My.Resources.ResourceManager.GetObject("traffic_red")


            Me.lnk_minerport.Enabled = False

            Me.txtOutput.Text = ""

            Me.lbl_hashrate_status.Text = "unknown"

            Me.btn_miner_start.BackColor = Color.LightGreen


            statsFirstRun = True

            Me.lbl_turnfundingontoseestats.Visible = True

            Application.DoEvents()

        Else

            fundingstopped_counter = 0

            Me.lbl_turnfundingontoseestats.Visible = False

            minerRuns = True

            Me.btn_miner_start.Enabled = False
            Me.btn_miner_stop.Enabled = True

            Me.pct_trafficlight.BackgroundImage = My.Resources.ResourceManager.GetObject("traffic_green")

            Me.lnk_minerport.Enabled = True

            Me.btn_miner_start.BackColor = SystemColors.Control


            Me.sts_strip_label3.Text = "Collecting local stats"
            Application.DoEvents()

            Dim output As String = ""

            output = output & XMRStakParser.ParseXmrHtml(XMRHttpType.Connection)
            output = output & vbCrLf & "---------------------------------------" & vbCrLf

            output = output & XMRStakParser.ParseXmrHtml(XMRHttpType.Hashrate)
            output = output & vbCrLf & "---------------------------------------" & vbCrLf

            output = output & XMRStakParser.ParseXmrHtml(XMRHttpType.Result)

            Me.txtOutput.Text = output


            Application.DoEvents()

            Dim XMLhashrate As New XMLLocalData()
            XMLhashrate = XMLStats.ReadLocalXml()

            If XMLhashrate.hashrate > 0 Then

                Me.lbl_hashrate_status.Text = Convert.ToInt16(XMLhashrate.hashrate).ToString
                Me.currentHashrate = Convert.ToInt32(XMLhashrate.hashrate)

            ElseIf XMLhashrate.hashrate <= 0 And XMLhashrate.hashrate_10seconds > 0 Then

                Me.lbl_hashrate_status.Text = Convert.ToInt16(XMLhashrate.hashrate_10seconds).ToString
                Me.currentHashrate = Convert.ToInt32(XMLhashrate.hashrate)

            Else

                Me.lbl_hashrate_status.Text = "warming up"
                Me.currentHashrate = 0

            End If

            If XMLhashrate.xmrversion.Length > 0 Then

                Me.lbl_minerversion_status.Text = XMLhashrate.xmrversion

            End If

            Me.sts_strip_label3.Text = "Local stats collected"
            Application.DoEvents()

            If statsFirstRun = True Then

                Me.G_StatsCollection.b_sessionstart = True
                Me.G_StatsCollection.d_lastupdate = Now
                Me.G_StatsCollection.i_hashessummary = 0
                Me.G_StatsCollection.d_sessionstart = Now
                Me.G_StatsCollection.s_userkey = Me.userkey
                Me.G_StatsCollection.s_computerkey = Me.computerkey

                Dim statspush As New Stats With {
                    .ThisStatsCollection = Me.G_StatsCollection
                }

                statsFirstRun = False

            Else

                Me.G_StatsCollection.b_sessionstart = False
                Me.G_StatsCollection.i_hashessummary = Me.G_StatsCollection.i_hashessummary + (currentHashrate * (DateDiff(DateInterval.Second, Me.G_StatsCollection.d_lastupdate, Now)))
                Me.G_StatsCollection.d_lastupdate = Now

                If timercounter = 5 Then

                    Dim statspush As New Stats With {
                    .ThisStatsCollection = Me.G_StatsCollection
                    }

                End If

            End If



        End If

        If timercounter = 1 Then

            Me.sts_strip_label2.Text = "Collecting remote stats"

            CreateFundingStatsDisplay()

            Me.sts_strip_label2.Text = "Remote stats collected"

        End If

        If timercounter = 5 Then

            ErrorHandling.TransferErrors()



        End If

        timercounter = timercounter + 1

        If timercounter = 6 Then

            timercounter = 0

        End If
        Application.DoEvents()


    End Sub

    Private Sub CreateFundingStatsDisplay()

        Try
            If minerRuns = True Then

                Dim personalStats As New XMLData()

                If Me.allowStatsTransfer = True Then

                    personalStats = XMLStats.ReadXml(XMLStatsType.personal)

                    Me.lbl_stats_personal_computers.Text = personalStats.key_uniqueComputersTotal.ToString
                    Me.lbl_stats_personal_hashes.Text = personalStats.key_hashRateSummaryTotal.ToString
                    Me.lbl_stats_personal_hashrateavg.Text = personalStats.key_hashRatePerSecondSummaryTotal.ToString
                    Me.lbl_stats_personal_usd.Text = FormatNumber(personalStats.key_sumUSDTotal, 2).ToString
                    Me.lbl_stats_personal_users.Text = personalStats.key_uniqueUsersTotal.ToString
                    Me.lbl_stats_personal_xmr.Text = personalStats.key_sumXMRTotal.ToString

                Else

                    personalStats.key_key = "none"

                End If
                Application.DoEvents()

                Dim overallStats As New XMLData()
                overallStats = XMLStats.ReadXml(XMLStatsType.overall)

                Me.lbl_stats_allusers_computers.Text = overallStats.key_uniqueComputersTotal.ToString
                Me.lbl_stats_allusers_hashes.Text = overallStats.key_hashRateSummaryTotal.ToString
                Me.lbl_stats_allusers_hashrateavg.Text = overallStats.key_hashRatePerSecondSummaryTotal.ToString
                Me.lbl_stats_allusers_usd.Text = FormatNumber(overallStats.key_sumUSDTotal, 2).ToString
                Me.lbl_stats_allusers_users.Text = overallStats.key_uniqueUsersTotal.ToString
                Me.lbl_stats_allusers_xmr.Text = overallStats.key_sumXMRTotal.ToString

                Application.DoEvents()


            End If

        Catch exa As Exception

            Dim ErrorHandler As New ErrorHandling With {
                            .ErrorMessage = exa
            }

        End Try

    End Sub



    Private Sub TimerEventProcessor(ByVal myObject As Object, ByVal myEventArgs As EventArgs) Handles Timer1.Tick

        Me.TimerExecute()

    End Sub

    Private Function ReadConfig() As Boolean

        Me.autostart = False
        Me.pool = "Monerohash.com"
        Me.cores = 1
        Me.configured = False
        Me.startminimized = False
        Me.allowErrorTransfer = False
        Me.allowStatsTransfer = False

        Dim configCount As Integer = 0
        Dim configCountGoal As Integer = 7


        Me.userkey = ""

        If Registry.KeyExists("userkey") Then

            Dim s_userkey As String = Registry.GetValue("userkey")

            If s_userkey.Length > 0 Then

                Me.userkey = s_userkey

            End If

        End If

        If Me.userkey.Length = 0 Then

            Randomize()
            Dim rand As Integer = Math.Round(Rnd(1) * 1000000000, 0)
            Dim generatedKey As String = Crypto.GenerateSHA256String((rand).ToString & " - " & Me.xmrpath & (rand * 2).ToString).ToLower
            Registry.SetValue("userkey", generatedKey)
            Me.userkey = generatedKey

        End If

        Me.computerkey = ""

        If Registry.KeyExists("computerkey") Then

            Dim s_computerkey As String = Registry.GetValue("computerkey")

            If s_computerkey.Length > 0 Then

                Me.computerkey = s_computerkey

            End If

        End If

        If Me.computerkey.Length = 0 Then

            Randomize()
            Dim rand As Integer = Math.Round(Rnd(1) * 1000000000, 0)
            Dim generatedKeyM As String = Crypto.GenerateSHA256String((rand).ToString & " - " & Environment.MachineName & (rand * 2).ToString).ToLower
            Registry.SetValue("computerkey", generatedKeyM)
            Me.computerkey = generatedKeyM

        End If

        If Registry.KeyExists("allowstatstransfer") Then

            Dim s_allowstatstransfer As String = Registry.GetValue("allowstatstransfer")

            If s_allowstatstransfer.Length > 0 Then

                If s_allowstatstransfer.Equals("on") Then

                    Me.allowStatsTransfer = True

                End If

                configCount = configCount + 1

            End If

        End If

        If Registry.KeyExists("allowerrortransfer") Then

            Dim s_allowerrortransfer As String = Registry.GetValue("allowerrortransfer")

            If s_allowerrortransfer.Length > 0 Then

                If s_allowerrortransfer.Equals("on") Then

                    Me.allowErrorTransfer = True

                End If

                configCount = configCount + 1

            End If

        End If


        If Registry.KeyExists("autostart") Then

            Dim s_autostart As String = Registry.GetValue("autostart")

            If s_autostart.Length > 0 Then

                If s_autostart.Equals("on") Then

                    Me.autostart = True

                End If

                configCount = configCount + 1

            End If

        End If

        If Registry.KeyExists("startminimized") Then

            Dim s_startminimized As String = Registry.GetValue("startminimized")

            If s_startminimized.Length > 0 Then

                If s_startminimized.Equals("on") Then

                    Me.startminimized = True

                End If

                configCount = configCount + 1

            End If

        End If


        If Registry.KeyExists("pool") Then

            Dim s_pool As String = Registry.GetValue("pool")

            If s_pool.Length > 0 Then

                Me.pool = s_pool

                configCount = configCount + 1

            End If

        End If

        If Registry.KeyExists("cores") Then

            Dim s_cores As String = Registry.GetValue("cores")

            If s_cores.Length > 0 Then

                Me.cores = Convert.ToInt16(s_cores)

                configCount = configCount + 1

            End If

        End If

        If Registry.KeyExists("xmrpath") Then

            Dim s_xmrpath As String = Registry.GetValue("xmrpath")

            If s_xmrpath.Length > 0 Then

                Me.xmrpath = s_xmrpath

                configCount = configCount + 1

            End If

        End If

        If configCount = configCountGoal Then

            Me.configured = True

        End If

        Return Me.configured

    End Function

    Private Sub InstantiatePool(id As Int16, mypoolName As String, mypoolAddress As String)

        Me.minerPools(id) = New Minerpool With {
            .PoolAddress = mypoolAddress,
            .PoolName = mypoolName
        }


    End Sub

    Private Sub CreatePools()

        InstantiatePool(0, "Monerohash.com", "monerohash.com:3333")
        InstantiatePool(1, "Moneropool.com", "mine.moneropool.com:3333")
        InstantiatePool(2, "Crypto-pool.fr", "xmr.crypto-pool.fr:3333")
        InstantiatePool(3, "MineXMR.com", "pool.minexmr.com:4444")
        InstantiatePool(4, "XMRPool.eu", "xmrpool.eu:3333")

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.sts_strip_label1.Width = 170
        Me.sts_strip_label2.Width = 170
        Me.sts_strip_label3.Width = 170
        Me.sts_strip_label4.Width = 170
        Me.sts_strip_label5.Width = 170

        Me.Timer2.Stop()
        Me.Timer2.Enabled = False

        Me.lbl_turnfundingontoseestats.Visible = True

        If WalletAddressInUse = MinerConfig.XMRWalletAddress.developer Then

            MsgBox("Developer address in use", vbCritical, "ATTENTION!")

        End If

        G_StatsCollection = New StatsCollection

        Dim i As Int16 = 0

        CreatePools()

        ' init the form

        Me.Text = "Snowden's Guardian Angels Support" & " V" & Assembly.GetExecutingAssembly().GetName().Version.ToString

        ' now, get the presets if there are any

        If MinerConfig.XmrStakStorePathPrepare() Then

        Else

        End If


        If Me.ReadConfig() = True Then

        Else

        End If


        'TODO remove these 4 lines once we turn from BETA into PRODUCTIVE
        Me.chk_allowErrorTransfer.Checked = True
        Me.chk_allowStatsTransfer.Checked = True
        Me.chk_allowErrorTransfer.Enabled = False
        Me.chk_allowStatsTransfer.Enabled = False



        Me.xmrtcpport = MinerConfig.GetFreeTcpPort()

        Me.lbl_xmrtcpport_status.Text = Me.xmrtcpport.ToString

        Me.lnk_minerport.Text = "Local Mining Stats"
        Me.lnk_minerport.Links.Add(0, ("http://127.0.0.1:" & Me.xmrtcpport.ToString & "/").Length, "http://127.0.0.1:" & Me.xmrtcpport.ToString & "/")
        Me.lnk_minerport.Enabled = False

        Me.lnk_helponline.Links.Add(0, ("https://redzoneaction.org/sgasupport/?page=faq").Length, "https://redzoneaction.org/sgasupport/?page=faq")
        Me.lnk_helponline.Enabled = True

        Me.cmb_pool.Items.Clear()

        For i = 0 To minerPools.Length - 1
            If minerPools(i).PoolName <> Nothing Then
                Me.cmb_pool.Items.Add(minerPools(i).PoolName)
            End If
        Next i

        Me.cmb_pool.Text = pool

        Me.cmb_pool.DropDownStyle = ComboBoxStyle.DropDownList

        Dim logicCores As Int16 = Environment.ProcessorCount

        Me.cmb_cores.Items.Clear()


        If logicCores > 1 Then

            For i = 1 To Convert.ToInt16(logicCores / 2)

                Me.cmb_cores.Items.Add(i.ToString)

                If i = cores Then

                    Me.cmb_cores.Text = i.ToString

                End If

            Next i

        Else

            Me.cmb_cores.Text = "1"

        End If
        Me.lbl_cores_number_total.Text = "out of " & logicCores.ToString & " cores"

        Me.cmb_cores.DropDownStyle = ComboBoxStyle.DropDownList

        Me.lbl_xmrpath_status.Text = Me.xmrpath

        If Processes.IsRunningMiner() = True Then
            'Kill the miner, to make sure we are using the right config
            Processes.KillMiner()
            Me.sts_strip_label1.Text = "Funding stopped"
            Application.DoEvents()

        End If

        MinerConfig.KillLogFile()


        If Me.allowStatsTransfer = True Then

            Me.chk_allowStatsTransfer.CheckState = CheckState.Checked

        End If

        If Me.allowErrorTransfer = True Then

            Me.chk_allowErrorTransfer.CheckState = CheckState.Checked

        End If

        If Me.startminimized = True Then

            Me.chk_startminimized.CheckState = CheckState.Checked

        End If

        Me.txt_userkey_status.Text = Me.userkey

        Me.TimerExecute()

        timercounter = 0

        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        Me.Timer1.Start()


        Me.txt_moneroaddress_status.Text = MinerConfig.GetMonerWalletAddress(Me.WalletAddressInUse)

        Dim menuitem1 As New ToolStripMenuItem With {
            .Text = "Sto&p Funding",
            .Name = "stopfunding"
        }
        AddHandler menuitem1.Click, AddressOf Me.MenuItem1_Click
        nfContextmenu.Items.Add(menuitem1)

        Dim menuitem2 As New ToolStripMenuItem With {
            .Text = "S&tart Funding",
            .Name = "startfunding"
        }
        AddHandler menuitem2.Click, AddressOf Me.MenuItem2_Click
        nfContextmenu.Items.Add(menuitem2)

        Dim menuitem3 As New ToolStripMenuItem With {
            .Text = "Show &Application window",
            .Name = "showapplication"
        }
        AddHandler menuitem3.Click, AddressOf Me.MenuItem3_Click
        nfContextmenu.Items.Add(menuitem3)

        Dim menuitem4 As New ToolStripMenuItem With {
            .Text = "E&xit",
            .Name = "exit"
        }
        AddHandler menuitem4.Click, AddressOf Me.MenuItem4_Click
        nfContextmenu.Items.Add(menuitem4)



        nf.Icon = Me.Icon

        nf.Text = "Snowden's Guardian Angels Support"

        nf.ContextMenuStrip = nfContextmenu


        If Updates.QueryUpdate = True Then

            Me.pct_update.Visible = True

            Dim tt As New ToolTip()
            tt.SetToolTip(Me.pct_update, "There are updates available, please click!")

        Else

            Me.pct_update.Visible = False

            If Me.startminimized = True Then

                Me.WindowState = FormWindowState.Minimized

                Me.ShowInTaskbar = False

                Me.Visible = False

            End If


        End If

        If Me.autostart = True Then

            Me.chk_autostart_true.CheckState = CheckState.Checked

            SoftstartMinerviaTimer2()

        End If

        Me.btn_apply_settings.BackColor = SystemColors.Control

    End Sub

    Private Sub Timer2_Fired() Handles Timer2.Tick

        Me.StartFunding()

        timercounter = 0


        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        Me.Timer1.Start()

        Me.TimerExecute()

        Me.Timer2.Stop()
        Me.Timer2.Enabled = False

        Me.sts_strip_label1.Text = "Funding started"
        Application.DoEvents()

    End Sub

    Private Function WriteSettings() As Boolean

        If Me.cmb_pool.Text.Length > 0 And Me.cmb_cores.Text.Length > 0 Then


            If Me.chk_allowErrorTransfer.CheckState = CheckState.Checked Then

                Registry.SetValue("allowerrortransfer", "on")
                Me.allowErrorTransfer = True

            Else

                Registry.SetValue("allowerrortransfer", "off")
                Me.allowErrorTransfer = False

            End If

            If Me.chk_allowStatsTransfer.CheckState = CheckState.Checked Then

                Registry.SetValue("allowstatstransfer", "on")
                Me.allowStatsTransfer = True

            Else

                Registry.SetValue("allowstatstransfer", "off")
                Me.allowStatsTransfer = False

            End If

            If Me.chk_autostart_true.CheckState = CheckState.Checked Then

                Registry.SetValue("autostart", "on")

                Registry.SetAutostart(True)

                Me.autostart = True

            Else

                Registry.SetValue("autostart", "off")

                Registry.SetAutostart(False)

                Me.autostart = False

            End If

            If Me.chk_startminimized.CheckState = CheckState.Checked Then

                Registry.SetValue("startminimized", "on")

                Me.startminimized = True

            Else

                Registry.SetValue("startminimized", "off")

                Me.startminimized = False

            End If

            Registry.SetValue("pool", Me.cmb_pool.Text.ToString)
            Me.pool = Me.cmb_pool.Text.ToString

            Registry.SetValue("cores", Me.cmb_cores.Text.ToString)
            Me.cores = Convert.ToInt16(Me.cmb_cores.Text.ToString)

            Registry.SetValue("xmrpath", Me.xmrpath)


            Registry.SetValueUAC(Application.StartupPath & "\xmr-stak.exe", "RunAsInvoker")

            Me.configured = True

            Me.xmrtcpport = MinerConfig.GetFreeTcpPort()
            Me.lbl_xmrtcpport_status.Text = Me.xmrtcpport
            Me.lnk_minerport.Links.Clear()
            Me.lnk_minerport.Links.Add(0, ("http://127.0.0.1:" & Me.xmrtcpport.ToString & "/").Length, "http://127.0.0.1:" & Me.xmrtcpport.ToString & "/")


            MinerConfig.WriteConfigMiner(MinerConfig.TranslatePoolNameToURL(Me.cmb_pool.Text.ToString), Me.xmrtcpport, WalletAddressInUse)
            MinerConfig.WriteConfigCpu(Convert.ToInt16(Me.cmb_cores.Text.ToString))


            Return True

        End If

        Return False

    End Function

    Private Sub StartTheMiner()
        Try

            Dim p As New ProcessStartInfo With {
                           .WorkingDirectory = Me.xmrpath,
                           .FileName = Application.StartupPath & "\xmr-stak.exe",
                           .WindowStyle = XMRStakStartupStyle
                       }
            ' .FileName = Me.xmrpath & "\xmr-stak.exe",
            '' Start the process
            Process.Start(p)
            Me.sts_strip_label1.Text = "Funding started"
            Application.DoEvents()

        Catch abort As System.ComponentModel.Win32Exception

            MsgBox("abort by user")

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                            .ErrorMessage = ex
            }

        End Try
    End Sub

    Private Sub SoftstartMinerviaTimer2()

        Me.sts_strip_label1.Text = "Attempt to start funding"
        Application.DoEvents()
        'do this 5 seconds later
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 5000
        Me.Timer2.Start()


    End Sub

    Private Sub StartFunding()

        Try

            If Me.cmb_pool.Text.Length > 0 And Me.cmb_cores.Text.Length > 0 Then

                'save settings again, just in case...
                Me.WriteSettings()

                If Processes.IsRunningMiner() = False Then

                    Me.sts_strip_label1.Text = "Start funding"
                    Application.DoEvents()
                    StartTheMiner()

                Else

                    Processes.KillMiner()
                    Me.sts_strip_label1.Text = "Funding stopped"
                    Application.DoEvents()
                    SoftstartMinerviaTimer2()

                End If

                Application.DoEvents()


            End If


        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                            .ErrorMessage = ex
            }

        End Try

    End Sub


    Private Sub Btn_miner_start_Click(sender As Object, e As EventArgs) Handles btn_miner_start.Click

        Me.StartFunding()

        timercounter = 0


        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        Me.Timer1.Start()

        Me.TimerExecute()

    End Sub

    Private Sub Btn_miner_stop_Click(sender As Object, e As EventArgs) Handles btn_miner_stop.Click

        Processes.KillMiner()
        Me.sts_strip_label1.Text = "Funding stopped"
        Application.DoEvents()
        Threading.Thread.Sleep(3000)

        Me.TimerExecute()


    End Sub

    Private Sub Btn_apply_settings_Click(sender As Object, e As EventArgs) Handles btn_apply_settings.Click

        Me.WriteSettings()

        If Processes.IsRunningMiner() = True Then

            ' restart the miner, no matter what autostart is at

            Processes.KillMiner()
            Me.sts_strip_label1.Text = "Funding stopped"
            Application.DoEvents()

            SoftstartMinerviaTimer2()

        Else

            If Me.chk_autostart_true.CheckState = CheckState.Checked Then

                ' start the miner since the user told autostart true

                SoftstartMinerviaTimer2()

            End If

        End If

        Me.btn_apply_settings.BackColor = SystemColors.Control

    End Sub


    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_QUERYENDSESSION Then
            'MessageBox.Show("queryendsession: this is a logoff, shutdown, or reboot")
            systemShutdown = True
        End If
        ' If this is WM_QUERYENDSESSION, the closing event should be raised in the base WndProc.
        MyBase.WndProc(m)
    End Sub 'WndProc 

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing


        Dim hideIcon As Boolean = True


        If systemShutdown = False Then


            Dim nfresult As MsgBoxResult = MsgBox("Should we minimize to the system tray instead of closing the application?", vbYesNoCancel)


            If nfresult = MsgBoxResult.Yes Then

                Me.WindowState = FormWindowState.Minimized

                Me.Visible = False

                'Me.ShowInTaskbar = False

                hideIcon = False

                e.Cancel() = True

            ElseIf nfresult = MsgBoxResult.No Then
                'ignore for the moment

            ElseIf nfresult = MsgBoxResult.Cancel Then

                e.Cancel() = True

                hideIcon = False

                Exit Sub

            End If


            If Processes.IsRunningMiner() = True Then

                Dim result As MsgBoxResult = MsgBox("The Funding is still active, closing as well?", MsgBoxStyle.YesNoCancel, "Funding still active")

                If result = MsgBoxResult.Yes Then

                    Processes.KillMiner()

                ElseIf result = MsgBoxResult.No Then
                    'ok, close this

                ElseIf result = MsgBoxResult.Cancel Then

                    e.Cancel() = True

                    hideIcon = False


                End If
            End If

        Else

            'this is when the form is closing due Powerdown or Logoff from Windows, triggered by the session-handler
            hideIcon = True

        End If

        'dregister the nf-icon
        If hideIcon = True Then

            nf.Visible = False
            nf = Nothing

        End If



    End Sub

    Private Sub Nf_Click(sender As Object, e As EventArgs) Handles nf.Click

        Me.Visible = True

        Me.WindowState = FormWindowState.Normal

        Me.ShowInTaskbar = True


    End Sub

    Private Sub Lnk_helponline_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_helponline.LinkClicked

        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())

    End Sub

    Private Sub Lnk_minerport_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_minerport.LinkClicked

        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        Dim f As Form
        f = sender

        'Check if the form is minimized
        If f.WindowState = FormWindowState.Minimized Then

            f.ShowInTaskbar = False

        End If

    End Sub

    Private Sub MenuItem1_Click()

        If Processes.IsRunningMiner() = True Then

            Processes.KillMiner()
            Me.sts_strip_label1.Text = "Funding stopped"
            Application.DoEvents()

            Threading.Thread.Sleep(3000)

            Me.TimerExecute()

        End If

    End Sub
    Private Sub MenuItem2_Click()

        If Processes.IsRunningMiner() = False Then

            SoftstartMinerviaTimer2()

        End If

    End Sub
    Private Sub MenuItem3_Click()

        Me.ShowInTaskbar = True

        Me.Visible = True

        Me.WindowState = FormWindowState.Normal

        Me.BringToFront()

    End Sub
    Private Sub MenuItem4_Click()

        If Processes.IsRunningMiner() = True Then

            Dim result As MsgBoxResult = MsgBox("The Funding is still active, closing as well?", MsgBoxStyle.YesNoCancel, "Funding still active")

            If result = MsgBoxResult.Yes Then

                Processes.KillMiner()

                End

            ElseIf result = MsgBoxResult.No Then
                'ok, close this

                End

            ElseIf result = MsgBoxResult.Cancel Then

            End If
        Else

            Dim result As MsgBoxResult = MsgBox("Do you really want to close this?", MsgBoxStyle.YesNo, "Snowden's Guardian Angels Support")

            If result = MsgBoxResult.Yes Then

                End

            End If

        End If

    End Sub

    Private Sub Btn_userkey_change_Click(sender As Object, e As EventArgs) Handles btn_userkey_change.Click

        If Me.txt_userkey_status.ReadOnly = True Then

            Me.txt_userkey_status.ReadOnly = False

            Me.btn_userkey_change.Text = "Save userkey"

        Else

            If Me.txt_userkey_status.Text.Length = 64 Then

                Me.userkey = Me.txt_userkey_status.Text

                Registry.SetValue("userkey", Me.txt_userkey_status.Text)


                'Stats should change from this point, so restart the stats collector
                statsFirstRun = True



            Else

                'reset, since key was wrong
                Me.txt_userkey_status.Text = Me.userkey

                MsgBox("Failed, key has wrong format. Please use only keys you copied from other installations of Snowden's Guardian Angels Support", vbCritical, "Failed")

            End If

            Me.txt_userkey_status.ReadOnly = True

            Me.btn_userkey_change.Text = "Change userkey"

        End If

    End Sub

    Private Sub ChangeApplyButtonColor()

        Me.btn_apply_settings.BackColor = Color.LightGoldenrodYellow

    End Sub

    Private Sub Cmb_cores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_cores.SelectedIndexChanged

        ChangeApplyButtonColor()

    End Sub

    Private Sub Cmb_pool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_pool.SelectedIndexChanged

        ChangeApplyButtonColor()

    End Sub

    Private Sub Chk_autostart_true_CheckedChanged(sender As Object, e As EventArgs) Handles chk_autostart_true.CheckedChanged

        ChangeApplyButtonColor()

    End Sub

    Private Sub Chk_startminimized_CheckedChanged(sender As Object, e As EventArgs) Handles chk_startminimized.CheckedChanged

        ChangeApplyButtonColor()

    End Sub

    Private Sub Chk_allowErrorTransfer_CheckedChanged(sender As Object, e As EventArgs) Handles chk_allowErrorTransfer.CheckedChanged

        ChangeApplyButtonColor()

    End Sub

    Private Sub Chk_allowStatsTransfer_CheckedChanged(sender As Object, e As EventArgs) Handles chk_allowStatsTransfer.CheckedChanged

        ChangeApplyButtonColor()

    End Sub

    Private Function CreateShareLink() As String

        If Me.allowStatsTransfer = True Then
            Return Me.link_SharerEncoded & Me.userkey
        Else
            Return Me.link_SharerEncoded
        End If


    End Function

    Private Sub Pct_facebook_Click(sender As Object, e As EventArgs) Handles pct_facebook.Click

        Dim link As String = "https://www.facebook.com/sharer.php?u=" & CreateShareLink()
        System.Diagnostics.Process.Start(link)


    End Sub

    Private Sub Pct_googleplus_Click(sender As Object, e As EventArgs) Handles pct_googleplus.Click

        Dim link As String = "https://plus.google.com/share?url=" & CreateShareLink()
        System.Diagnostics.Process.Start(link)

    End Sub

    Private Sub Pct_twitter_Click(sender As Object, e As EventArgs) Handles pct_twitter.Click

        Dim link As String = "https://twitter.com/intent/tweet?url=" & CreateShareLink()
        System.Diagnostics.Process.Start(link)

    End Sub

    Private Sub Lnk_moreinfo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_moreinfo.LinkClicked

        Dim link As String = "https://redzoneaction.org/sgasupport/"
        If Me.allowStatsTransfer = True Then
            link = link & "?key=" & Me.userkey
        End If
        System.Diagnostics.Process.Start(link)

    End Sub

    Private Sub Pct_update_Click(sender As Object, e As EventArgs) Handles pct_update.Click

        System.Diagnostics.Process.Start("https://github.com/pstimpel/snowdenangels/blob/master/release/")


    End Sub
End Class
