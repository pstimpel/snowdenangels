Imports System.IO
Imports System.Net
Imports System.Text

Public Class Stats


    Dim c_statscollection As StatsCollection

    Property ThisStatsCollection() As StatsCollection
        Get
            Return c_statscollection
        End Get
        Set(ByVal Value As StatsCollection)

            c_statscollection = Value


            If Form1.allowStatsTransfer = True Then

                PostFile(PrepareJson())

            End If

        End Set
    End Property

    Private Function PrepareJson() As String

        '   [
        '     {"PersonID":1,"Name":"Bryon Hetrick","Registered":true},
        '     {"PersonID":2,"Name":"Nicole Wilcox","Registered":true},
        '     {"PersonID":3,"Name":"Adrian Martinson","Registered":false},
        '     {"PersonID":4,"Name":"Nora Osborn","Registered":false}
        ' ]
        'stats_persession_userkey
        'stats_persession_sessionstart
        'stats_persession_sessionend
        'stats_persession_hashes
        'stats_persession_computerkey

        Dim content As String = ""

        content = content & " [ "
        content = content & " { "

        content = content & """userkey"": """ & c_statscollection.s_userkey & """"
        content = content & ", "
        content = content & """computerkey"": """ & c_statscollection.s_computerkey & """"
        content = content & ", "
        content = content & """sessionstart"": """ & Math.Round((c_statscollection.d_sessionstart.ToUniversalTime - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds, 0).ToString & """"
        content = content & ", "

        If c_statscollection.b_sessionstart = True Then

            content = content & """sessionwasstarted"": true"

        Else

            content = content & """sessionwasstarted"": false"

        End If
        content = content & ", "
        content = content & """sessionend"": """ & Math.Round((c_statscollection.d_lastupdate.ToUniversalTime - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds, 0).ToString & """"
        content = content & ", "
        content = content & """hashes"": " & c_statscollection.i_hashessummary.ToString
        content = content & " } "
        content = content & " ] "

        Return content

    End Function

    Private Shared Function PostFile(postcontent As String) As Boolean

        Try

            Dim content As String = "data=" & postcontent

            Dim request As HttpWebRequest = HttpWebRequest.Create(Form1.statscollector)

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


End Class
