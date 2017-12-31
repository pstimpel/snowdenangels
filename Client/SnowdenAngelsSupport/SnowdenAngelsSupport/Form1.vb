Imports System.ComponentModel
Imports System.Reflection

Public Class Form1
    'TODO find a way to supress the warning on xmr-stak start
    'TODO create parser for http output of xmr-stak
    'TODO determine http port dynamically, to prevent using ports already in use by others
    'TODO think about stats transfered to a remote site, for global stats
    'TODO create some nice output
    'TODO create "Share to SocialNetwork" stuff so the users could brag with something
    'TODO create basic actions for the NotifyIcon 

    Public configured As Boolean
    Public cores As Int16
    Public pool As String
    Public autostart As Boolean

    Private Sub TimerExecute()

        If Processes.IsRunningMiner() = False Then

            Me.btn_miner_start.Enabled = True
            Me.btn_miner_stop.Enabled = False

            Me.lbl_status_response.Text = "Funding stopped"
            Me.lbl_status_response.BackColor = Color.Red
            Me.lbl_status_response.ForeColor = Color.White

        Else

            Me.btn_miner_start.Enabled = False
            Me.btn_miner_stop.Enabled = True

            Me.lbl_status_response.Text = "Funding started"
            Me.lbl_status_response.BackColor = Color.LightGreen
            Me.lbl_status_response.ForeColor = Color.Black

        End If


    End Sub

    Private Sub TimerEventProcessor(ByVal myObject As Object,
                                         ByVal myEventArgs As EventArgs) _
                                     Handles Timer1.Tick
        Me.TimerExecute()

    End Sub

    Private Function ReadConfig() As Boolean

        Me.autostart = False
        Me.pool = "monerohash.com"
        Me.cores = 1
        Me.configured = False

        Dim configCount As Integer = 0
        Dim configCountGoal As Integer = 4

        If Registry.KeyExists("autostart") Then

            Dim s_autostart As String = Registry.GetValue("autostart")

            If s_autostart.Length > 0 Then

                If s_autostart.Equals("on") Then

                    Me.autostart = True

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

        If configCount = configCountGoal Then

            Me.configured = True

        End If

        Return Me.configured

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' init the form

        Me.Text = Me.Text.ToString & " V" & Assembly.GetExecutingAssembly().GetName().Version.ToString

        ' now, get the presets if there are any

        If Me.ReadConfig() = True Then

        Else

        End If


        Me.cmb_pool.Items.Clear()
        Me.cmb_pool.Items.Add("monerohash.com")
        Me.cmb_pool.Items.Add("irgendwas anderes")

        Me.cmb_pool.Text = pool

        Dim logicCores As Int16 = Environment.ProcessorCount

        Me.cmb_cores.Items.Clear()

        Dim i As Int16 = 0
        For i = 1 To logicCores

            Me.cmb_cores.Items.Add(i.ToString)

            If i = cores Then

                Me.cmb_cores.Text = i.ToString

            End If

        Next i

        If autostart = True Then

            Me.chk_autostart_true.CheckState = CheckState.Checked

            Me.StartFunding()

        End If

        Me.TimerExecute()

        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        Me.Timer1.Start()

        nf.Icon = Me.Icon



    End Sub

    Private Function WriteSettings() As Boolean

        If Me.cmb_pool.Text.Length > 0 And Me.cmb_cores.Text.Length > 0 Then

            If Me.chk_autostart_true.CheckState = CheckState.Checked Then

                Registry.SetValue("autostart", "on")

            Else

                Registry.SetValue("autostart", "off")

            End If

            Registry.SetValue("pool", Me.cmb_pool.Text.ToString)

            Registry.SetValue("cores", Me.cmb_cores.Text.ToString)

            Me.configured = True

            MinerConfig.WriteConfigMiner(MinerConfig.TranslatePoolNameToURL(Me.cmb_pool.Text.ToString))
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

                    Dim p As New ProcessStartInfo

                    ' Specify the location of the binary
                    p.FileName = Application.StartupPath & "\xmr-stak.exe"

                    ' Use a hidden window
                    p.WindowStyle = ProcessWindowStyle.Hidden

                    ' Start the process
                    Process.Start(p)

                End If


            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_miner_start_Click(sender As Object, e As EventArgs) Handles btn_miner_start.Click

        Me.StartFunding()

        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        Me.Timer1.Start()

        Me.TimerExecute()

    End Sub

    Private Sub btn_miner_stop_Click(sender As Object, e As EventArgs) Handles btn_miner_stop.Click

        Processes.KillMiner()

        Threading.Thread.Sleep(3000)

                Me.TimerExecute()


    End Sub

    Private Sub btn_apply_settings_Click(sender As Object, e As EventArgs) Handles btn_apply_settings.Click

        If Me.chk_autostart_true.CheckState = CheckState.Checked Then

            Me.StartFunding()

        Else

            Me.WriteSettings()


        End If



    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Dim nfresult As MsgBoxResult = MsgBox("Should we minimize to the system tray instead of closing the application?", vbYesNoCancel)

        If nfresult = MsgBoxResult.Yes Then

            Me.WindowState = FormWindowState.Minimized

            Me.Visible = False

            e.Cancel() = True

        ElseIf nfresult = MsgBoxResult.Cancel Then

            e.Cancel() = True

        End If


        If Processes.IsRunningMiner = True Then

            Dim result As MsgBoxResult = MsgBox("The Funding is still active, closing as well?", MsgBoxStyle.YesNoCancel, "Funding still active")

            If result = MsgBoxResult.Yes Then

                Processes.KillMiner()

            ElseIf result = MsgBoxResult.No Then
                'ok, close this

            ElseIf result = MsgBoxResult.Cancel Then

                e.Cancel() = True

            End If
        End If

    End Sub

    Private Sub nf_Click(sender As Object, e As EventArgs) Handles nf.Click

        Me.Visible = True

        Me.WindowState = FormWindowState.Normal

    End Sub
End Class
