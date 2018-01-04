Module Registry

    Private Const regPath As String = "HKEY_CURRENT_USER\Software\SnowdenAngelsSupport"
    Private Const regPathUAC As String = "HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers"

    'TODO: make this more nice, by determining regPath dynamic instead of having different sets of similar functions

    Public Function SetAutostart(enabled As Boolean) As Boolean

        Try

            If enabled = True Then

                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)

            Else

                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)

            End If

            Return True

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try

    End Function

    Public Function KeyExistsUAC(key As String) As Boolean

        Try

            If My.Computer.Registry.GetValue(regPathUAC, key, Nothing) Is Nothing Then

                Return False

            Else

                Return True

            End If

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try

    End Function

    Public Function GetValueUAC(key As String) As String

        Try

            Return My.Computer.Registry.GetValue(regPathUAC, key, Nothing)

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }


            Return ""

        End Try

    End Function

    Public Function SetValueUAC(key As String, value As String) As Boolean

        Try

            If Not Registry.KeyExistsUAC(key) Then

                Registry.CreateKeyUAC(key)

            End If

            My.Computer.Registry.SetValue(regPathUAC, key, value)

            Return True

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try


    End Function

    Public Function CreateKeyUAC(key As String) As Boolean

        Try

            If Not Registry.KeyExistsUAC(key) Then

                My.Computer.Registry.LocalMachine.CreateSubKey(regPathUAC & "/" & key)

            End If

            Return True

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try

    End Function




    Public Function KeyExists(key As String) As Boolean

        Try

            If My.Computer.Registry.GetValue(regPath, key, Nothing) Is Nothing Then

                Return False

            Else

                Return True

            End If

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try

    End Function

    Public Function GetValue(key As String) As String

        Try

            Return My.Computer.Registry.GetValue(regPath, key, Nothing)

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }


            Return ""

        End Try

    End Function

    Public Function SetValue(key As String, value As String) As Boolean

        Try

            If Not Registry.KeyExists(key) Then

                Registry.CreateKey(key)

            End If

            My.Computer.Registry.SetValue(regPath, key, value)

            Return True

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try


    End Function

    Public Function CreateKey(key As String) As Boolean

        Try

            If Not Registry.KeyExists(key) Then

                My.Computer.Registry.LocalMachine.CreateSubKey(regPath & "/" & key)

            End If

            Return True

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try

    End Function


End Module
