Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography

Public Class Form1
    'TODO create "Share to SocialNetwork" stuff so the users could brag with something


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



#If DEBUG Then
    'Public errorcollector As String = "http://127.0.0.1/sgasupport/errorhandler.php"
    'Public statscollector As String = "http://127.0.0.1/sgasupport/statshandler.php"
    Public errorcollector As String = "https://redzoneaction.org/sgasupport/errorhandler.php"
    Public statscollector As String = "https://redzoneaction.org/sgasupport/statshandler.php"
    Private WalletAddressInUse As MinerConfig.XMRWalletAddress = MinerConfig.XMRWalletAddress.developer
    Private XMRStakStartupStyle as ProcessWindowStyle = ProcessWindowStyle.Normal
#Else
    Public errorcollector As String = "https://redzoneaction.org/sgasupport/errorhandler.php"
    Public statscollector As String = "https://redzoneaction.org/sgasupport/statshandler.php"
    Private WalletAddressInUse As MinerConfig.XMRWalletAddress = MinerConfig.XMRWalletAddress.ForTheRefugees
    Private XMRStakStartupStyle As ProcessWindowStyle = ProcessWindowStyle.Hidden
#End If


    Public nfContextmenu As New ContextMenuStrip


    Private Sub TimerExecute()

        If Processes.IsRunningMiner() = False Then

            minerRuns = False

            Me.btn_miner_start.Enabled = True
            Me.btn_miner_stop.Enabled = False

            Me.lbl_status_response.Text = "Funding stopped"
            Me.lbl_status_response.BackColor = Color.Red
            Me.lbl_status_response.ForeColor = Color.White

            Me.lnk_minerport.Enabled = False

            Me.txtOutput.Text = ""

            Me.lbl_hashrate_status.Text = "unknown"

            Me.btn_miner_start.BackColor = Color.LightGreen


            statsFirstRun = True

        Else

            minerRuns = True

            Me.btn_miner_start.Enabled = False
            Me.btn_miner_stop.Enabled = True

            Me.lbl_status_response.Text = "Funding started"
            Me.lbl_status_response.BackColor = Color.LightGreen
            Me.lbl_status_response.ForeColor = Color.Black

            Me.lnk_minerport.Enabled = True

            Me.btn_miner_start.BackColor = SystemColors.Control



            Dim output As String = ""

            output = output & XMRStakParser.ParseXmrHtml(XMRHttpType.Connection)
            output = output & vbCrLf & "---------------------------------------" & vbCrLf

            output = output & XMRStakParser.ParseXmrHtml(XMRHttpType.Hashrate)
            output = output & vbCrLf & "---------------------------------------" & vbCrLf

            output = output & XMRStakParser.ParseXmrHtml(XMRHttpType.Result)

            Me.txtOutput.Text = output

            If Me.currentHashrate > 0 Then

                Me.lbl_hashrate_status.Text = Me.currentHashrate.ToString

            End If

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

        If timercounter = 5 Then

            ErrorHandling.TransferErrors()

        End If

        timercounter = timercounter + 1

        If timercounter = 6 Then

            timercounter = 0

        End If

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
        Me.allowErrorTransfer = True
        Me.allowStatsTransfer = True

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

        If Processes.IsRunningMiner = True Then
            'Kill the miner, to make sure we are using the right config
            Processes.KillMiner()

        End If

        MinerConfig.KillLogFile()

        If Me.autostart = True Then

            Me.chk_autostart_true.CheckState = CheckState.Checked

            Me.StartFunding()

        End If

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

            Me.lnk_update.Visible = True
            Me.lnk_update.Links.Add(0, ("https://github.com/pstimpel/snowdenangels/blob/master/release/").Length, "https://github.com/pstimpel/snowdenangels/blob/master/release/")
            Me.lnk_update.Enabled = True

        Else

            Me.lnk_update.Visible = False
            Me.lnk_update.Enabled = False

            If Me.startminimized = True Then

                Me.WindowState = FormWindowState.Minimized

                Me.ShowInTaskbar = False

                Me.Visible = False

            End If


        End If

        Me.btn_apply_settings.BackColor = SystemColors.Control



    End Sub

    Private Function WriteSettings() As Boolean

        If Me.cmb_pool.Text.Length > 0 And Me.cmb_cores.Text.Length > 0 Then


            If Me.chk_allowErrorTransfer.CheckState = CheckState.Checked Then

                Registry.SetValue("allowerrortransfer", "on")

            Else

                Registry.SetValue("allowerrortransfer", "off")

            End If

            If Me.chk_allowStatsTransfer.CheckState = CheckState.Checked Then

                Registry.SetValue("allowstatstransfer", "on")

            Else

                Registry.SetValue("allowstatstransfer", "off")

            End If

            If Me.chk_autostart_true.CheckState = CheckState.Checked Then

                Registry.SetValue("autostart", "on")

            Else

                Registry.SetValue("autostart", "off")

            End If

            If Me.chk_startminimized.CheckState = CheckState.Checked Then

                Registry.SetValue("startminimized", "on")

            Else

                Registry.SetValue("startminimized", "off")

            End If

            Registry.SetValue("pool", Me.cmb_pool.Text.ToString)

            Registry.SetValue("cores", Me.cmb_cores.Text.ToString)

            Registry.SetValue("xmrpath", Me.xmrpath)

            Registry.SetValueUAC(Application.StartupPath & "\xmr-stak.exe", "RunAsInvoker")

            Me.configured = True

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
        Catch abort As System.ComponentModel.Win32Exception

            MsgBox("abort by user")

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                            .ErrorMessage = ex
            }

        End Try
    End Sub

    Private Sub StartFunding()

        Try

            If Me.cmb_pool.Text.Length > 0 And Me.cmb_cores.Text.Length > 0 Then

                Me.WriteSettings()

                If Processes.IsRunningMiner = False Then

                    StartTheMiner()

                End If


            End If


        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                            .ErrorMessage = ex
            }

        End Try

    End Sub


    Private Sub Btn_miner_start_Click(sender As Object, e As EventArgs) Handles btn_miner_start.Click

        Me.StartFunding()

        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        Me.Timer1.Start()

        Me.TimerExecute()

    End Sub

    Private Sub Btn_miner_stop_Click(sender As Object, e As EventArgs) Handles btn_miner_stop.Click

        Processes.KillMiner()

        Threading.Thread.Sleep(3000)

        Me.TimerExecute()


    End Sub

    Private Sub Btn_apply_settings_Click(sender As Object, e As EventArgs) Handles btn_apply_settings.Click

        If Me.chk_autostart_true.CheckState = CheckState.Checked Then

            Me.StartFunding()

            Me.Timer1.Enabled = True
            Me.Timer1.Interval = 10000
            Me.Timer1.Start()

            Me.TimerExecute()


        Else


            Me.WriteSettings()
            If Me.minerRuns = True Then

                Processes.KillMiner()

                Threading.Thread.Sleep(1000)

                Me.StartFunding()

                Me.Timer1.Enabled = True
                Me.Timer1.Interval = 10000
                Me.Timer1.Start()

                Me.TimerExecute()

            End If

        End If

        Me.btn_apply_settings.BackColor = SystemColors.Control

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Dim nfresult As MsgBoxResult = MsgBox("Should we minimize to the system tray instead of closing the application?", vbYesNoCancel)

        Dim hideIcon As Boolean = True

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


        If Processes.IsRunningMiner = True Then

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

    Private Sub Lnk_update_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_update.LinkClicked

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

        If minerRuns = True Then

            Processes.KillMiner()

            Threading.Thread.Sleep(3000)

            Me.TimerExecute()

        End If

    End Sub
    Private Sub MenuItem2_Click()

        If minerRuns = False Then
            Me.StartFunding()

            Me.Timer1.Enabled = True
            Me.Timer1.Interval = 10000
            Me.Timer1.Start()

            Me.TimerExecute()

        End If

    End Sub
    Private Sub MenuItem3_Click()

        Me.ShowInTaskbar = True

        Me.Visible = True

        Me.WindowState = FormWindowState.Normal

        Me.BringToFront()

    End Sub
    Private Sub MenuItem4_Click()

        If Processes.IsRunningMiner = True Then

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
End Class
