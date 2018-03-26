Imports System.IO


Module MinerConfig

    Public Enum XMRWalletAddress
        developer = 0
        ForTheRefugees = 1
    End Enum

    Public Sub KillLogFile()

        Try

            If File.Exists(Form1.xmrpath & "\logout.txt") = True Then

                File.Delete(Form1.xmrpath & "\logout.txt")

            End If

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }


        End Try

    End Sub

    Private Function TestSelectedPort(ip As String, port As Int32) As Boolean
        ' Function to open a socket to the specified port to see if it is listening

        ' Connect to socket
        Dim testSocket As New System.Net.Sockets.TcpClient()

        Try
            testSocket.Connect(ip, port)
            ' The socket is accepting connections
            testSocket.Close()
            Return True

        Catch ex As Exception
            ' The port is not accepting connections
            Return False
        End Try

        Return False
    End Function

    Public Function GetFreeTcpPort() As Int32

        Dim startport As Int32 = 42000

        For i = startport To (startport + 10000)

            If TestSelectedPort("127.0.0.1", i) = False Then

                Return i

            End If

        Next i


        Return 0


    End Function

    Private Function CopyFile(filename As String) As Boolean

        Try

            If File.Exists(Form1.xmrpath & "\" & filename) = False Then

                File.Copy(Application.StartupPath & "\" & filename, Form1.xmrpath & "\" & filename)

            End If

            Return True

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try

    End Function

    Public Function XmrStakStorePathPrepare() As String

        Try

            Form1.xmrpath = Application.UserAppDataPath

            If Directory.Exists(Form1.xmrpath) = False Then

                Directory.CreateDirectory(Form1.xmrpath)

            End If

            Registry.SetValue("xmrpath", Form1.xmrpath)

            MinerConfig.CopyFile("xmr-stak.exe")
            MinerConfig.CopyFile("libeay32.dll")
            MinerConfig.CopyFile("ssleay32.dll")

            Return True

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try

    End Function


    Public Function TranslatePoolNameToURL(pool As String) As String

        For i = 0 To Form1.minerPools.Length - 1
            If Form1.minerPools(i).PoolName.ToLower.Equals(pool.ToLower) Then
                Return Form1.minerPools(i).PoolAddress
            End If

        Next i

        '
        Return "monerohash.com:3333"

    End Function
    Public Function GetMonerWalletAddress(walletToUse As XMRWalletAddress) As String

        If walletToUse = XMRWalletAddress.developer Then
            Return "421MbN95eXzJkoJbgLTvkkDGbNjpZWdcd9KzVKnXMHexUBAPrFbfQ33EAEjA7GLEeB9evt5AjkD6KgdNN4tfZ5VgM4LjC6V"
        Else
            Return "47gRtvuDS9dNjkNs2nFqiSVHk3tqdT239j9Tj1KxAWNPRogHnGUdMdvQBwevobeAxQHqjBu8WcZzfNrdbReYNAU1KBidTzc"
        End If


    End Function


    Public Sub WriteConfigMiner(xmrtcpport As Int32)

        Try


            Dim config As String = "
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
""httpd_port"" : " & xmrtcpport.ToString & ",
""http_login"" : """",
""http_pass"" : """",
""prefer_ipv4"" : true,

"
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(Form1.xmrpath & "\config.txt", False)
            file.Write(config)
            file.Close()

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

        End Try


    End Sub
    Public Sub WriteConfigPool(pool As String, walletToUse As XMRWalletAddress)

        Try
            ' 4TR: 47gRtvuDS9dNjkNs2nFqiSVHk3tqdT239j9Tj1KxAWNPRogHnGUdMdvQBwevobeAxQHqjBu8WcZzfNrdbReYNAU1KBidTzc
            ' PST: 421MbN95eXzJkoJbgLTvkkDGbNjpZWdcd9KzVKnXMHexUBAPrFbfQ33EAEjA7GLEeB9evt5AjkD6KgdNN4tfZ5VgM4LjC6V

            Dim myXMRWalletAddress As String = GetMonerWalletAddress(walletToUse)

            Dim config As String = """pool_list"" :
[
	{""pool_address"" : """ & pool & """, ""wallet_address"" : """ & myXMRWalletAddress & """,""rig_id"" : """", ""pool_password"" : ""x"", ""use_nicehash"" : false, ""use_tls"" : false, ""tls_fingerprint"" : """", ""pool_weight"" : 1 },
],
""currency"" : ""monero7"",

"
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(Form1.xmrpath & "\pools.txt", False)
            file.Write(config)
            file.Close()

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

        End Try


    End Sub

    Public Sub WriteConfigCpu(cores As Int16)

        Try

            Dim config As String = """cpu_threads_conf"" :
[
"
            Dim i As Integer
            For i = 1 To (cores * 2) Step 2
                config = config & "   { ""low_power_mode"" : false, ""no_prefetch"" : true, ""affine_to_cpu"" : " & (i - 1).ToString & " },
"
            Next i

            Dim configfoot As String = "
],
"
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(Form1.xmrpath & "\cpu.txt", False)
            file.Write(config & configfoot)
            file.Close()

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

        End Try

    End Sub

End Module
