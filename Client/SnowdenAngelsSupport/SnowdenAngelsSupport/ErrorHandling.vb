Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Text

Public Class ErrorHandling

    Private s_exception As Exception

    Private Shared errordirectory As String = Form1.xmrpath & "\errors"

    Property ErrorMessage() As Exception
        Get
            Return s_exception
        End Get
        Set(ByVal Value As Exception)

            s_exception = Value

            'is the ErrorDirectory there?

            CreateErrorDirectory()

            'store on disk

            If Form1.allowErrorTransfer = True Then

                SaveToDisk(s_exception)

            End If

            Try
                Form1.sts_strip_label4.Text = "Error report created"
            Catch exex As Exception

            End Try

        End Set
    End Property

    Private Function CreateErrorDirectory() As Boolean

        Try

            If Directory.Exists(errordirectory) = False Then

                Directory.CreateDirectory(errordirectory)

            End If

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

    Private Function SaveToDisk(errormessage As Exception) As Boolean

        Try

            Randomize()
            Dim rand As Integer = Math.Round(Rnd(1) * 1000000000, 0)
            Dim fileName As String = Crypto.GenerateSHA256String((rand).ToString & " - " & errordirectory & (rand * 2).ToString).ToLower & ".txt"

            '   [
            '     {"PersonID":1,"Name":"Bryon Hetrick","Registered":true},
            '     {"PersonID":2,"Name":"Nicole Wilcox","Registered":true},
            '     {"PersonID":3,"Name":"Adrian Martinson","Registered":false},
            '     {"PersonID":4,"Name":"Nora Osborn","Registered":false}
            ' ]
            Dim content As String = ""

            content = content & " [ "
            content = content & " { "

            content = content & """date"": """ & Math.Round((DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds, 0).ToString & """"
            content = content & ", "
            content = content & """error"": """ & errormessage.Message.Replace(vbCrLf, " ").Replace("\", "\\") & """"
            content = content & ", "
            content = content & """stacktrace"": """ & errormessage.StackTrace.Replace(vbCrLf, " ").Replace("\", "\\") & " " & errormessage.GetBaseException.ToString().Replace(vbCrLf, " ").Replace("\", "\\") & """"
            content = content & ", "
            content = content & """version"": """ & Assembly.GetExecutingAssembly().GetName().Version.ToString & """"
            content = content & " } "
            content = content & " ] "

            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(errordirectory & "\" & fileName, False)
            file.Write(content)
            file.Close()

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

    Private Shared Function PostFile(filename) As Boolean

        Try

            Dim content As String = "data=" & File.ReadAllText(filename)

            Dim request As HttpWebRequest = HttpWebRequest.Create(Form1.errorcollector)

            request.Method = "POST"

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(content)

            request.ContentType = "application/x-www-form-urlencoded"

            request.ContentLength = byteArray.Length

            Dim dataStream As Stream = request.GetRequestStream()

            dataStream.Write(byteArray, 0, byteArray.Length)

            dataStream.Close()

            Dim response As HttpWebResponse = request.GetResponse()

            Dim returnvalue As Boolean

            If response.StatusCode = HttpStatusCode.OK Then

                returnvalue = True

            Else

                returnvalue = False

            End If

            response.Close()

            Return returnvalue

        Catch ex As Exception

            Return False

        End Try

    End Function

    Public Shared Function TransferErrors() As Boolean

        Try

            If Directory.Exists(errordirectory) = True Then

                If Form1.allowErrorTransfer = True Then

                    Dim fileEntries As String() = Directory.GetFiles(errordirectory)

                    Dim fileName As String

                    For Each fileName In fileEntries

                        If PostFile(fileName) = True Then

                            File.Delete(fileName)

                        End If

                    Next fileName

                    Try
                        Form1.sts_strip_label5.Text = "Error reports sent"
                    Catch exex As Exception

                    End Try


                    Return True

                Else

                    Return False

                End If

            Else

                Return False

            End If

        Catch ex As Exception

            Form1.txt_errorlog.Text = ex.Message & " " & ex.StackTrace & vbCrLf & Form1.txt_errorlog.Text

            Return False

        End Try



    End Function

End Class
