Public Class CUserProfileObjects

    Private _centro_id As String = String.Empty
    Public Property centro_id() As String
        Get
            Return _centro_id
        End Get
        Set(ByVal value As String)
            _centro_id = value
        End Set
    End Property

    Private _forma_id As String
    Public Property forma_id() As String
        Get
            Return _forma_id
        End Get
        Set(ByVal value As String)
            _forma_id = value
        End Set
    End Property

    Private _permiso_id As String
    Public Property permiso_id() As String
        Get
            Return _permiso_id
        End Get
        Set(ByVal value As String)
            _permiso_id = value
        End Set
    End Property

End Class
