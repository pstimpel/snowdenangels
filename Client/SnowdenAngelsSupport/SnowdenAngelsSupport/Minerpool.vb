Public Class Minerpool

    Private s_poolName As String
    Private s_poolAddress As String

    Property PoolName() As String
        Get
            Return s_poolName
        End Get
        Set(ByVal Value As String)
            s_poolName = Value
        End Set
    End Property

    Property PoolAddress() As String
        Get
            Return s_poolAddress
        End Get
        Set(ByVal Value As String)
            s_poolAddress = Value
        End Set
    End Property

End Class
