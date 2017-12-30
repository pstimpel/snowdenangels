Module MinerConfig

    Public Function TranslatePoolNameToURL(pool As String) As String

        Select Case pool
            Case "monerohash.com"
                Return "monerohash.com:3333"
            Case Else
                Return "monerohash.com:3333"

        End Select

    End Function


    Public Sub WriteConfigMiner(pool As String)

		' DO NOT FORGET
		' TODO Replace the Monero address once ForTheRefugees is providing theirs, but keep this one until that point not to mine with an invalid address
		
        Dim config As String = """pool_list"" :
[
	{""pool_address"" : """ & pool & """, ""wallet_address"" : ""421MbN95eXzJkoJbgLTvkkDGbNjpZWdcd9KzVKnXMHexUBAPrFbfQ33EAEjA7GLEeB9evt5AjkD6KgdNN4tfZ5VgM4LjC6V"", ""pool_password"" : ""x"", ""use_nicehash"" : false, ""use_tls"" : false, ""tls_fingerprint"" : """", ""pool_weight"" : 1 },
],
""currency"" : ""monero"",
""call_timeout"" : 10,
""retry_time"" : 30,
""giveup_limit"" : 0,
""verbose_level"" : 4,
""print_motd"" : true,
""h_print_time"" : 60,
""aes_override"" : null,
""use_slow_memory"" : ""warn"",
""tls_secure_algo"" : true,
""daemon_mode"" : false,
""flush_stdout"" : false,
""output_file"" : """",
""httpd_port"" : 45385,
""http_login"" : """",
""http_pass"" : """",
""prefer_ipv4"" : true,

"
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath & "\config.txt", False)
        file.Write(config)
        file.Close()

    End Sub

    Public Sub WriteConfigCpu(cores As Int16)
        Dim config As String ="""cpu_threads_conf"" :
[
"
        Dim i As Integer
        For i = 1 To cores
            config = config & "
        { ""low_power_mode"" : false, ""no_prefetch"" : true, ""affine_to_cpu"" : " & (i-1).ToString & " },

"
        Next i

        Dim configfoot as string="
],
"
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath & "\cpu.txt", False)
        file.Write(config & configfoot)
        file.Close()


    End Sub

End Module
