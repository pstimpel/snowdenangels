Imports System.Reflection

Module Updates

    Public Function QueryUpdate() As Boolean

        Try

            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://github.com/pstimpel/snowdenangels/blob/master/release/release.md")

            Dim response As System.Net.HttpWebResponse = request.GetResponse()

            If response.StatusCode = System.Net.HttpStatusCode.OK Then

                Dim stream As System.IO.Stream = response.GetResponseStream()
                Dim reader As New System.IO.StreamReader(stream)
                Dim contents As String = reader.ReadToEnd()


                If contents.IndexOf("version=sassetup") > 0 Then

                    Dim content As String = contents.Substring(contents.IndexOf("version=sassetup"), 100)



                    Dim content_foot() As String = content.Split("</p>")



                    Dim versionstring As String = content_foot(0)

                    If versionstring.Equals("version=sassetup-" & Assembly.GetExecutingAssembly().GetName().Version.ToString & ".exe") Then
                        Return False
                    Else
                        Return True
                    End If

                Else


                End If

                Return False

            Else

                Return False

            End If

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }
            Return False

        End Try


    End Function

End Module
