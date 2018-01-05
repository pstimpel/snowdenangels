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


        Return CleanHtml(GetHtml("http://127.0.0.1:" & Form1.xmrtcpport & "/" & connparam, toParse))

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

    Private Sub ParseHashrate(content As String)

        Try

            '
            '       <!DOCTYPE html><html><head><meta name='viewport' content='width=device-width' /><link rel='stylesheet' href='style.css' /><title>Hashrate Report</title></head><body><div class='all'><div class='version'>v2.0.0-0005e4a</div><div class='header'><span style='color: rgb(255, 160, 0)'>XMR</span>-Stak Monero Miner</div><div class='flex-container'><div class='links flex-item'><a href='/h'><div><span class='letter'>H</span>ashrate</div></a></div><div class='links flex-item'><a href='/r'><div><span class='letter'>R</span>esults</div></a></div><div class='links flex-item'><a href='/c'><div><span class='letter'>C</span>onnection</div></a></div></div><h4>Hashrate Report</h4><div class=data><table><tr><th>Thread ID</th><th>10s</th><th>60s</th><th>15m</th><th rowspan='5'>H/s</td></tr><tr><th>0</th><td> 23.1</td><td></td><td></td></tr><tr><th>1</th><td> 27.4</td><td></td><td></td></tr><tr><th>Totals:</th><td> 50.5</td><td></td><td></td></tr><tr><th>Highest:</th><td> 0.0</td><td colspan='2'></td></tr></table></div></div></body></html>
            '
            If content.IndexOf("Totals:") Then

                Dim subtotal As String = content.Substring(content.IndexOf("Totals:"), 50)
                'is now something like Totals:</th><td> 50.5</td><td></td><td></td></tr><tr><th>Hi

                subtotal = subtotal.Substring(subtotal.IndexOf("<td>") + 4, 10)
                'is now  50.5</td><td></td><td></td></tr><tr><th>Hi

                Try

                    subtotal = subtotal.Substring(0, subtotal.IndexOf("</td>"))
                    subtotal = subtotal.Trim

                    If subtotal.Length > 0 Then

                        If subtotal.IndexOf(".") > 0 Then
                            subtotal = subtotal.Substring(0, subtotal.IndexOf("."))
                        End If

                        Try

                            Form1.currentHashrate = Convert.ToInt32(subtotal)

                        Catch exa As Exception

                        End Try

                    End If

                Catch exb As Exception

                End Try

            End If




        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

        End Try


    End Sub

    Private Function GetHtml(url As String, xmrquerytype As XMRHttpType) As String

        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(url)

            Dim response As System.Net.HttpWebResponse = request.GetResponse()

            If response.StatusCode = System.Net.HttpStatusCode.OK Then

                Dim stream As System.IO.Stream = response.GetResponseStream()

                Dim reader As New System.IO.StreamReader(stream)

                Dim contents As String = reader.ReadToEnd()

                If xmrquerytype = XMRHttpType.Hashrate Then

                    ParseHashrate(contents)

                End If

                Return contents

            Else

                Return ""

            End If

        Catch exa As Net.WebException

            ' Ignore these exceptions since they happen if the port is not ready to use yet

            Return ""

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                .ErrorMessage = ex
            }

            Return ""

        End Try

    End Function


End Module
