Imports System.Text.RegularExpressions

Module XMRStakParser

    'TODO replace this dirty parser by something useful once there is a nice output format from xmr-stak available

    Public Enum XMRHttpType
        Connection = 0
        Hashrate = 1
        Result = 2

    End Enum

    Public Function ParseXmrHtml(toParse As XMRHttpType) As String

        Dim connparam As String = ""
        Select Case toParse
            Case XMRHttpType.Connection
                connparam = "c"
            Case XMRHttpType.Hashrate
                connparam = "h"
            Case XMRHttpType.Result
                connparam = "r"
        End Select


        Return CleanHtml(GetHtml("http://127.0.0.1:" & Form1.xmrtcpport & "/" & connparam))

    End Function

    Private Function StripTags(ByVal html As String) As String

        Try

            Dim reporthtml() As String = html.Split("Report")


            html = reporthtml(reporthtml.Length - 1)

            html = html.Replace("eport", "")

            If html.IndexOf("Top 10 best results found") > 0 Then

                Dim reporthtml2() As String = html.Split("Top 10 best results found")

                html = reporthtml2(0)

            End If

            html = Regex.Replace(html, "</span>", "")
            html = Regex.Replace(html, "<span.*?>", "")
            html = Regex.Replace(html, "</tr>", vbCrLf)
            html = Regex.Replace(html, "<.*?>", " ")

            While html.IndexOf("  ") > -1

                html = html.Replace("  ", " ")

            End While

            html = html.Trim()

            html = html.Replace(vbCrLf & " ", vbCrLf)

            Return html

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return ""

        End Try

    End Function

    Private Function CleanHtml(html As String) As String

        html = StripTags(html)

        Return html

    End Function

    Private Function GetHtml(url As String) As String

        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(url)

            Dim response As System.Net.HttpWebResponse = request.GetResponse()

            If response.StatusCode = System.Net.HttpStatusCode.OK Then

                Dim stream As System.IO.Stream = response.GetResponseStream()

                Dim reader As New System.IO.StreamReader(stream)

                Dim contents As String = reader.ReadToEnd()

                Return contents

            Else

                Return ""

            End If

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return ""

        End Try

    End Function


End Module
