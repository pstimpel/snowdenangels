Imports System.Reflection

Public Class Form1
    'TODO clean the code, make it more readable, and sort the ugly staff out ASAP
    'TODO find a way to supress the warning on xmr-stak start
    'TODO create parser for http output of xmr-stak
    'TODO determine http port dynamically, to prevent using ports already in use by others
    'TODO think about stats transfered to a remote site, for global stats
    'TODO create some nice output
    'TODO create "Share to SocialNetwork" stuff so the users could brag with something
    'TODO if autostart is true and is configured, start xmr-stak on form1.load

    Public configured As Boolean
    Public cores As Int16
    Public pool As String
    Public autostart As Boolean

    Private Sub TimerExecute()

        If IsRunningMiner() = False Then

            Me.btn_miner_start.Enabled = True
            Me.btn_miner_stop.Enabled = False

        Else

            Me.btn_miner_start.Enabled = False
            Me.btn_miner_stop.Enabled = True

        End If


    End Sub

    Private Sub TimerEventProcessor(ByVal myObject As Object,
                                         ByVal myEventArgs As EventArgs) _
                                     Handles Timer1.Tick
        TimerExecute()

    End Sub

    Private Function ReadConfig() As Boolean

        autostart = False
        pool = "monerohash.com"
        cores = 1
        configured = False

        Dim configCount As Integer = 0
        Dim configCountGoal As Integer = 3

        If Registry.KeyExists("autostart") Then

            Dim s_autostart As String = Registry.GetValue("autostart")

            If s_autostart.Length > 0 Then

                If s_autostart.Equals("on") Then

                    autostart = True

                End If

                configCount = configCount + 1

            End If

        End If

        If Registry.KeyExists("pool") Then

            Dim s_pool As String = Registry.GetValue("pool")

            If s_pool.Length > 0 Then

                pool = s_pool

                configCount = configCount + 1

            End If

        End If

        If Registry.KeyExists("cores") Then

            Dim s_cores As String = Registry.GetValue("cores")

            If s_cores.Length > 0 Then

                cores = Convert.ToInt16(s_cores)

                configCount = configCount + 1

            End If

        End If

        If configCount = configCountGoal Then

            configured = True

        End If

        Return configured

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' init the form

        Me.Text = Me.Text.ToString & " V" & Assembly.GetExecutingAssembly().GetName().Version.ToString

        ' now, get the presets if there are any

        If ReadConfig() = True Then

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

        TimerExecute()



    End Sub

    Private Sub StartFunding()

        If Me.cmb_pool.Text.Length > 0 And Me.cmb_cores.Text.Length > 0 Then

            Registry.SetValue("autostart", "off")

            Registry.SetValue("pool", Me.cmb_pool.Text.ToString)

            Registry.SetValue("cores", Me.cmb_cores.Text.ToString)

            configured = True



            MinerConfig.WriteConfigMiner(MinerConfig.TranslatePoolNameToURL(Me.cmb_pool.Text.ToString))
            MinerConfig.WriteConfigCpu(Convert.ToInt16(Me.cmb_cores.Text.ToString))

            Dim p As New ProcessStartInfo

            ' Specify the location of the binary
            p.FileName = Application.StartupPath & "\xmr-stak.exe"

            ' Use a hidden window
            p.WindowStyle = ProcessWindowStyle.Hidden

            ' Start the process
            Process.Start(p)

        End If

    End Sub

    Private Sub btn_miner_start_Click(sender As Object, e As EventArgs) Handles btn_miner_start.Click

        StartFunding()

        Timer1.Enabled = True
        Timer1.Interval = 10000
        Timer1.Start()

        TimerExecute()

    End Sub

    Private Sub btn_miner_stop_Click(sender As Object, e As EventArgs) Handles btn_miner_stop.Click

        For Each prog As Process In Process.GetProcesses
            Debug.Print(prog.ProcessName)
            If prog.ProcessName = "xmr-stak.exe" Or prog.ProcessName = "xmr-stak" Then
                prog.Kill()

                Timer1.Stop()
                Timer1.Enabled = False

                Threading.Thread.Sleep(3000)

                TimerExecute()

            End If
        Next

    End Sub
End Class
