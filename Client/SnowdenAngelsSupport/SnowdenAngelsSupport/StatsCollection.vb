Public Class StatsCollection
    'stats_persession_userkey
    'stats_persession_sessionstart
    'stats_persession_sessionend
    'stats_persession_hashes
    'stats_persession_computerkey

    Public s_userkey As String = Form1.userkey
    Public b_sessionstart As Boolean = Form1.statsFirstRun
    Public d_sessionstart As Date = Now
    Public i_hashessummary As Int32 = 0
    Public s_computerkey As String = Form1.computerkey
    Public d_lastupdate As Date = Now

End Class
