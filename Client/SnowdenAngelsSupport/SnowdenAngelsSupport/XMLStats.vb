Imports System.Globalization
Imports System.Xml

Module XMLStats



    Public Enum XMLStatsType
        personal = 1
        overall = 2
    End Enum

    Public Function ReadLocalXml() As XMLLocalData

        Dim returnlocaldata As New XMLLocalData With {
            .hashrate = 0,
            .hashrate_10seconds = 0,
            .xmrversion = "unknown"
        }

        Try
            Dim document As New System.Xml.XmlDocument
            document = GetLocalXML()

            Dim root As XmlNode = document.ChildNodes(1)

            Dim c As CultureInfo = CultureInfo.InvariantCulture


            'Display the contents of the child nodes.
            If root.HasChildNodes Then
                Dim i As Integer
                For i = 0 To root.ChildNodes.Count - 1
                    'MsgBox(root.ChildNodes(i).Name & " " & root.ChildNodes(i).InnerText)
                    Select Case root.ChildNodes(i).Name
                        Case "total"

                            If IsNumeric(root.ChildNodes(i).InnerText) = True Then
                                returnlocaldata.hashrate = Convert.ToDouble(root.ChildNodes(i).InnerText, c)
                            Else
                                'empty
                                'MsgBox(">" & root.ChildNodes(i).InnerText & "<")
                                returnlocaldata.hashrate = -1
                            End If
                        Case "total10"

                            If IsNumeric(root.ChildNodes(i).InnerText) = True Then
                                returnlocaldata.hashrate_10seconds = Convert.ToDouble(root.ChildNodes(i).InnerText, c)
                            Else
                                'empty
                                'MsgBox(">" & root.ChildNodes(i).InnerText & "<")
                                returnlocaldata.hashrate_10seconds = -1
                            End If
                        Case "version"

                            If root.ChildNodes(i).InnerText.Length > 2 Then
                                returnlocaldata.xmrversion = root.ChildNodes(i).InnerText
                            Else
                                'empty
                                'MsgBox(">" & root.ChildNodes(i).InnerText & "<")
                                returnlocaldata.xmrversion = "unknown"
                            End If

                    End Select
                    Application.DoEvents()
                Next i
            End If

            Return returnlocaldata

        Catch ex As Exception

            'Dim ErrorHandler As New ErrorHandling With {
            '.ErrorMessage = ex
            '   }

        End Try


        Return returnlocaldata

    End Function



    Public Function ReadXml(type As XMLStatsType) As XMLData
        Dim returndata As New XMLData

        Try
            Dim document As New System.Xml.XmlDocument
            document = GetRemoteXML(type)

            Dim root As XmlNode = document.ChildNodes(1)

            Dim c As CultureInfo = CultureInfo.InvariantCulture

            'Display the contents of the child nodes.
            If root.HasChildNodes Then
                Dim i As Integer
                For i = 0 To root.ChildNodes.Count - 1
                    'MsgBox(root.ChildNodes(i).Name & " " & root.ChildNodes(i).InnerText)
                    Select Case root.ChildNodes(i).Name
                        Case "key_key"
                            returndata.key_key = root.ChildNodes(i).InnerText
                        Case "key_hashRatePerSecondSummaryTotal"
                            returndata.key_hashRatePerSecondSummaryTotal = Convert.ToInt32(root.ChildNodes(i).InnerText)
                        Case "key_hashRatePerSecondSummaryLast"
                            returndata.key_hashRatePerSecondSummaryLast = Convert.ToInt32(root.ChildNodes(i).InnerText)
                        Case "key_hashRateSummaryTotal"
                            returndata.key_hashRateSummaryTotal = Convert.ToInt64(root.ChildNodes(i).InnerText)
                        Case "key_hashRateSummaryLast"
                            returndata.key_hashRateSummaryLast = Convert.ToInt64(root.ChildNodes(i).InnerText)
                        Case "key_uniqueComputersTotal"
                            returndata.key_uniqueComputersTotal = Convert.ToInt32(root.ChildNodes(i).InnerText)
                        Case "key_uniqueComputersLast"
                            returndata.key_uniqueComputersLast = Convert.ToInt32(root.ChildNodes(i).InnerText)
                        Case "key_uniqueUsersTotal"
                            returndata.key_uniqueUsersTotal = Convert.ToInt32(root.ChildNodes(i).InnerText)
                        Case "key_uniqueUsersLast"
                            returndata.key_uniqueUsersLast = Convert.ToInt32(root.ChildNodes(i).InnerText)
                        Case "key_sumXMRTotal"
                            returndata.key_sumXMRTotal = Convert.ToDouble(root.ChildNodes(i).InnerText, c)
                        Case "key_sumXMRLast"
                            returndata.key_sumXMRLast = Convert.ToDouble(root.ChildNodes(i).InnerText, c)
                        Case "key_sumUSDTotal"
                            returndata.key_sumUSDTotal = Convert.ToDouble(root.ChildNodes(i).InnerText, c)
                        Case "key_sumUSDLast"
                            returndata.key_sumUSDLast = Convert.ToDouble(root.ChildNodes(i).InnerText, c)

                    End Select
                    Application.DoEvents()
                Next i
            End If

            Return returndata

        Catch ex As Exception

            Dim ErrorHandler As New ErrorHandling With {
                               .ErrorMessage = ex
               }

        End Try


        returndata.key_key = ""
        Return returndata

    End Function

    Private Function GetRemoteXML(type As XMLStatsType) As System.Xml.XmlDocument

        Dim url As String
        If type = XMLStatsType.overall Then
            url = "https://redzoneaction.org/sgasupport/?key=" & Form1.userkey & "&action=xmloverall"
        Else
            url = "https://redzoneaction.org/sgasupport/?key=" & Form1.userkey & "&action=xmlpersonal"
        End If

        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(url)
        request.Credentials = New System.Net.NetworkCredential("username", "password")

        Dim response As System.Net.HttpWebResponse = request.GetResponse()

        If response.StatusCode = System.Net.HttpStatusCode.OK Then

            Dim stream As System.IO.Stream = response.GetResponseStream()
            Dim reader As New System.IO.StreamReader(stream)
            Dim contents As String = reader.ReadToEnd()
            Dim document As New System.Xml.XmlDocument()
            document.LoadXml(contents)

            Return document

        Else

            Dim document As New System.Xml.XmlDocument()
            Return document

        End If

    End Function

    Private Function GetLocalXML() As System.Xml.XmlDocument

        Dim url As String = "http://127.0.0.1:" & Form1.xmrtcpport & "/totalhashrate.xml"

        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(url)
        request.Credentials = New System.Net.NetworkCredential("username", "password")

        Dim response As System.Net.HttpWebResponse = request.GetResponse()

        If response.StatusCode = System.Net.HttpStatusCode.OK Then

            Dim stream As System.IO.Stream = response.GetResponseStream()
            Dim reader As New System.IO.StreamReader(stream)
            Dim contents As String = reader.ReadToEnd()
            Dim document As New System.Xml.XmlDocument()
            'MsgBox(contents)
            document.LoadXml(contents)

            Return document

        Else

            Dim document As New System.Xml.XmlDocument()
            Return document

        End If

    End Function

End Module
