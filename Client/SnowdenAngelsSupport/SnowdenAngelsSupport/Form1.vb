Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography

Public Class Form1
    'TODO find a way to supress the warning on xmr-stak start
    'TODO think about stats transfered to a remote site, for global stats
    'TODO create "Share to SocialNetwork" stuff so the users could brag with something
    'TODO how to handle updates
    'TODO create some basic error handling, error broadcasting/collecting

    Public configured As Boolean
    Public cores As Int16
    Public pool As String
    Public autostart As Boolean
    Public xmrpath As String
    Public xmrtcpport As Int32
    Public startminimized As Boolean
    Public userkey As String

    Public minerPools(4) As Minerpool

    Public minerRuns As Boolean = False

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


        Else

            minerRuns = True

            Me.btn_miner_start.Enabled = False
            Me.btn_miner_stop.Enabled = True

            Me.lbl_status_response.Text = "Funding started"
            Me.lbl_status_response.BackColor = Color.LightGreen
            Me.lbl_status_response.ForeColor = Color.Black

            Me.lnk_minerport.Enabled = True




            Dim output As String = ""

            output = output & XMRStakParser.ParseXmrHtml(XMRHttpType.Connection)
            output = output & vbCrLf & "---------------------------------------" & vbCrLf

            output = output & XMRStakParser.ParseXmrHtml(XMRHttpType.Hashrate)
            output = output & vbCrLf & "---------------------------------------" & vbCrLf

            output = output & XMRStakParser.ParseXmrHtml(XMRHttpType.Result)

            Me.txtOutput.Text = output

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


        Dim configCount As Integer = 0
        Dim configCountGoal As Integer = 5


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

    Private Sub InstantiatePool(id As Int16, poolName As String, poolAddress As String)

        Me.minerPools(id) = New Minerpool With {
            .PoolAddress = poolAddress,
            .PoolName = poolName
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

        If Me.startminimized = True Then

            Me.chk_startminimized.CheckState = CheckState.Checked

        End If

        Me.txt_userkey_status.Text = Me.userkey

        Me.TimerExecute()

        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        Me.Timer1.Start()


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

        If Me.startminimized = True Then

            Me.WindowState = FormWindowState.Minimized

            Me.ShowInTaskbar = False

            Me.Visible = False

        End If

    End Sub

    Private Function WriteSettings() As Boolean

        If Me.cmb_pool.Text.Length > 0 And Me.cmb_cores.Text.Length > 0 Then

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

            Me.configured = True

            MinerConfig.WriteConfigMiner(MinerConfig.TranslatePoolNameToURL(Me.cmb_pool.Text.ToString), Me.xmrtcpport)
            MinerConfig.WriteConfigCpu(Convert.ToInt16(Me.cmb_cores.Text.ToString))


            Return True

        End If

        Return False

    End Function

    Private Sub StartFunding()

        Try

            If Me.cmb_pool.Text.Length > 0 And Me.cmb_cores.Text.Length > 0 Then

                Me.WriteSettings()

                If Processes.IsRunningMiner = False Then

                    ' Specify the location of the binary
                    ' Use a hidden window
                    Dim p As New ProcessStartInfo With {
                        .WorkingDirectory = Me.xmrpath,
                        .FileName = Me.xmrpath & "\xmr-stak.exe",
                        .WindowStyle = ProcessWindowStyle.Hidden
                    }
                    '' Start the process
                    Process.Start(p)

                End If


            End If

        Catch ex As Exception

            MsgBox(ex.Message)

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


        End If



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

End Class
