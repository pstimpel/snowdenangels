﻿Module Processes

    Public Function IsRunningMiner() As Boolean

        For Each prog As Process In Process.GetProcesses
            Debug.Print(prog.ProcessName)
            If prog.ProcessName = "xmr-stak.exe" Or prog.ProcessName = "xmr-stak" Then
                Return True
            End If
        Next

        Return False

    End Function

End Module
