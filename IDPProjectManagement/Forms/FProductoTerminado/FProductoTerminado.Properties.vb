Partial Public Class FProductoTerminado

    Private _centro_id As String = String.Empty
    Public Property centro_id() As String
        Get
            Return _centro_id
        End Get
        Set(ByVal value As String)
            _centro_id = value
        End Set
    End Property

    Private _producto_id As String = String.Empty
    Public Property producto_id() As String
        Get
            Return _producto_id
        End Get
        Set(ByVal value As String)
            _producto_id = value
        End Set
    End Property

    Private _producto_nombre As String = String.Empty
    Public Property producto_nombre() As String
        Get
            Return _producto_nombre
        End Get
        Set(ByVal value As String)
            _producto_nombre = value
        End Set
    End Property

    Private _producto_descripcion As String = String.Empty
    Public Property producto_descripcion() As String
        Get
            Return _producto_descripcion
        End Get
        Set(ByVal value As String)
            _producto_descripcion = value
        End Set
    End Property

    Private _tipo_id As String = String.Empty
    Public Property tipo_id() As String
        Get
            Return _tipo_id
        End Get
        Set(ByVal value As String)
            _tipo_id = value
        End Set
    End Property

    Private _unidad_id As String = String.Empty
    Public Property unidad_id() As String
        Get
            Return _unidad_id
        End Get
        Set(ByVal value As String)
            _unidad_id = value
        End Set
    End Property

    Private _presentacion_id As String = String.Empty
    Public Property presentacion_id() As String
        Get
            Return _presentacion_id
        End Get
        Set(ByVal value As String)
            _presentacion_id = value
        End Set
    End Property

    Private _precio_compra As Decimal = 0
    Public Property precio_compra() As String
        Get
            Return _precio_compra
        End Get
        Set(ByVal value As String)
            _precio_compra = value
        End Set
    End Property

    Private _precio_venta As Decimal = 0
    Public Property precio_venta() As String
        Get
            Return _precio_venta
        End Get
        Set(ByVal value As String)
            _precio_venta = value
        End Set
    End Property

    Private _barcode As String = String.Empty
    Public Property barcode() As String
        Get
            Return _barcode
        End Get
        Set(ByVal value As String)
            _barcode = value
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
        CommandQueryAll = 1
        CommandAdd = 2
        CommandUpdate = 3
        CommandSave = 4
        CommandDelete = 5
        CommandQueryFilter = 6
    End Enum

End Class
