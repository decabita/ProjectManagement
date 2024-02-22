Imports System.Data.SqlClient

Partial Public Class FCentrosTrabajo

    Dim oSqlCommand As SqlCommand
    Dim oResponse As SqlParameter

    Private _oFormController As CFormController_

    Public Property oFormController() As CFormController_
        Get
            Return _oFormController
        End Get
        Set(ByVal value As CFormController_)

            _oFormController = value
        End Set
    End Property

    Private _oSqlDataAdapter As SqlDataAdapter

    Public Property oSqlDataAdapter() As SqlDataAdapter
        Get
            Return _oSqlDataAdapter
        End Get
        Set(ByVal value As SqlDataAdapter)

            _oSqlDataAdapter = value
        End Set
    End Property


    Private _oCollectionBSourceCombo As New Collection

    Public Property oCollectionBSourceCombo() As Collection
        Get
            Return _oCollectionBSourceCombo
        End Get
        Set(ByVal value As Collection)
            _oCollectionBSourceCombo = value
        End Set
    End Property

    Private _oCollectionBSourceComboChild As New Collection

    Public Property oCollectionBSourceComboChild() As Collection
        Get
            Return _oCollectionBSourceComboChild
        End Get
        Set(ByVal value As Collection)
            _oCollectionBSourceComboChild = value
        End Set
    End Property


    Private _oBSourceCombo As BindingSource

    Public Property oBSourceCombo() As BindingSource
        Get

            Return _oBSourceCombo

        End Get

        Set(ByVal value As BindingSource)
            _oBSourceCombo = value
        End Set

    End Property

    Private _oBSourceChildren As BindingSource

    Public Property oBSourceChildren() As BindingSource
        Get

            Return _oBSourceChildren

        End Get

        Set(ByVal value As BindingSource)
            _oBSourceChildren = value
        End Set

    End Property


    Private _oBSourceComboType As New BindingSource

    Public Property oBSourceComboType() As BindingSource
        Get
            Return _oBSourceComboType
        End Get
        Set(ByVal value As BindingSource)
            _oBSourceComboType = value
        End Set
    End Property


    Private _oDataSet As New DataSet

    Public Property oDataSet() As DataSet
        Get
            Return _oDataSet
        End Get
        Set(ByVal value As DataSet)
            _oDataSet = value
        End Set
    End Property

    Private _oFProgress As New FProgress
    Public Property oFProgress() As FProgress
        Get
            Return _oFProgress
        End Get
        Set(ByVal value As FProgress)
            _oFProgress = value
        End Set
    End Property

    'Private _oBindingSource As New BindingSource
    'Public Property oBindingSource() As BindingSource
    '    Get
    '        Return _oBindingSource
    '    End Get
    '    Set(ByVal value As BindingSource)
    '        _oBindingSource = value
    '    End Set
    'End Property

    Private _oBindingSourceChild As New BindingSource
    Public Property oBindingSourceChild() As BindingSource
        Get
            Return _oBindingSourceChild
        End Get
        Set(ByVal value As BindingSource)
            _oBindingSourceChild = value
        End Set
    End Property

    Private _oBSourceComboChild As New BindingSource

    Public Property oBSourceComboChild() As BindingSource
        Get

            Return _oBSourceComboChild

        End Get

        Set(ByVal value As BindingSource)
            _oBSourceComboChild = value
        End Set

    End Property

    Private _centro_id As String
    Public Property centro_id() As String
        Get
            Return _centro_id
        End Get
        Set(ByVal value As String)
            _centro_id = value
        End Set
    End Property

    Private _almacen_nombre As String
    Public Property almacen_nombre() As String
        Get
            Return _almacen_nombre
        End Get
        Set(ByVal value As String)
            _almacen_nombre = value
        End Set
    End Property

    Private _almacen_descripcion As String
    Public Property almacen_descripcion() As String
        Get
            Return _almacen_descripcion
        End Get
        Set(ByVal value As String)
            _almacen_descripcion = value
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

    Private _view_mode As Integer = CApplication.ViewMode.SingleView
    Public Property view_mode() As Integer
        Get
            Return _view_mode
        End Get
        Set(ByVal value As Integer)
            _view_mode = value
        End Set
    End Property

    'Private _form_state As Integer
    'Public Property form_state() As Integer
    '    Get
    '        Return _form_state
    '    End Get
    '    Set(ByVal value As Integer)
    '        _form_state = value
    '    End Set
    'End Property

    Private _is_new_row As Boolean
    Public Property is_new_row() As Boolean
        Get
            Return _is_new_row
        End Get
        Set(ByVal value As Boolean)
            _is_new_row = value
        End Set
    End Property

    Private _current_row As Integer = -1
    Public Property current_row() As Integer
        Get
            Return _current_row
        End Get
        Set(ByVal value As Integer)
            _current_row = value
        End Set
    End Property

    Enum SPCommand

        QueryAll = 1
        Add = 2
        Update = 3
        SaveCommand = 4
        Delete = 5
        None = 0

        GetRelatedSpecs = 30

    End Enum

End Class
