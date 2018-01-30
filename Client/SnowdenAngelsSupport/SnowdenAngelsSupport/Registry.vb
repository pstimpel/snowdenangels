Public Class Registry

    Private Const regPath_CURRENTUSER As String = "Software\SnowdenAngelsSupport"
    Private Const regPath As String = "HKEY_CURRENT_USER\" & regPath_CURRENTUSER
    Private Const regPathUAC As String = "HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers"

    'TODO: check, if we need the anti elevation warning things in UAC, since the miner is not elevated anymore
    'TODO: make this more nice, by determining regPath dynamic instead of having different sets of similar functions

    Public Shared Function SetAutostart(enabled As Boolean) As Boolean

        Try

            If enabled = True Then

                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)

            Else

                Try

                    My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)

                Catch exa As Exception

                    ' we are not interested in errors telling the object does not exist, since we want to delete it anyways..
                End Try

            End If

            Return True

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try

    End Function




    Public Shared Function KeyExistsUAC(key As String) As Boolean

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

    Public Shared Function GetValueUAC(key As String) As String

        Try

            Return My.Computer.Registry.GetValue(regPathUAC, key, Nothing)

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }


            Return ""

        End Try

    End Function

    Public Shared Function SetValueUAC(key As String, value As String) As Boolean

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

    Public Shared Function CreateKeyUAC(key As String) As Boolean

        Try

            If Not Registry.KeyExistsUAC(key) Then

                My.Computer.Registry.LocalMachine.CreateSubKey(regPathUAC & "\" & key)

            End If

            Return True

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try

    End Function



    Public Shared Function DeleteKey(key As String) As Boolean

        Try

            If key.Length = 0 Then

                Return False

            End If


            If KeyExists(key) = True Then

                My.Computer.Registry.CurrentUser.OpenSubKey(regPath_CURRENTUSER, True).DeleteValue(key)

            End If

            Return True

        Catch exa As Exception

            'MsgBox(exa.Message)
            ' we are not interested in errors telling the object does not exist, since we want to delete it anyways..

            Return True

        End Try


    End Function

    Public Shared Function KeyExists(key As String) As Boolean

        Try

            If key.Length = 0 Then

                Return False

            End If


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

    Public Shared Function GetValue(key As String) As String

        Try

            If key.Length = 0 Then

                Return ""

            End If

            Return My.Computer.Registry.GetValue(regPath, key, Nothing)

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }


            Return ""

        End Try

    End Function

    Public Shared Function SetValue(key As String, value As String) As Boolean

        Try

            If key.Length = 0 Then

                Return False

            End If


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

    Public Shared Function CreateKey(key As String) As Boolean

        Try

            If key.Length = 0 Then

                Return False

            End If

            If Not Registry.KeyExists(key) Then

                My.Computer.Registry.LocalMachine.CreateSubKey(regPath & "\" & key)

            End If

            Return True

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return False

        End Try

    End Function


End Class
