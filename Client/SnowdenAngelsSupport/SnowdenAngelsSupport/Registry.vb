Module Registry

    Private Const regPath As String = "HKEY_CURRENT_USER\Software\SnowdenAngelsSupport"

    Public Function KeyExists(key As String) As Boolean

        Try

            If My.Computer.Registry.GetValue(regPath, key, Nothing) Is Nothing Then

                Return False

            Else

                Return True

            End If

        Catch ex As Exception

            Return False

        End Try

    End Function

    Public Function GetValue(key As String) As String

        Try

            Return My.Computer.Registry.GetValue(regPath, key, Nothing)

        Catch ex As Exception

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

            'MsgBox(ex.Message)

            Return False

        End Try

    End Function


End Module
