Partial Public Class FCentrosTrabajo

    Private _oCWorkCenter As New CWorkCenter_
    Public Property oCWorkCenter() As CWorkCenter_
        Get
            Return _oCWorkCenter
        End Get
        Set(ByVal value As CWorkCenter_)
            _oCWorkCenter = value
        End Set
    End Property

    Private _id As String = String.Empty
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _guid As String
    Public Property guid() As String
        Get
            Return _guid
        End Get
        Set(ByVal value As String)
            _guid = value
        End Set
    End Property

    Private _nombre As String = String.Empty
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _nombre_corto As String = String.Empty
    Public Property nombre_corto() As String
        Get
            Return _nombre_corto
        End Get
        Set(ByVal value As String)
            _nombre_corto = value
        End Set
    End Property

    Private _descripcion As String = String.Empty
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _is_active As Boolean
    Public Property is_active() As Boolean
        Get
            Return _is_active
        End Get
        Set(ByVal value As Boolean)
            _is_active = value
        End Set
    End Property

    Enum SPCommand

        None = 0
        QueryAll = 1
        Add = 2
        Update = 3
        Save = 4
        Delete = 5
        CheckIfPartExists = 6
        QueryFilter = 7
        GetRelatedSpecs = 30

    End Enum



End Class
