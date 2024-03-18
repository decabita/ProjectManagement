Imports System.Data.SqlClient

Partial Public Class FCatalogFormTemplate

    Enum CustomExceptionMessagesCode

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

    Private _oFormRelatedClass As New Object
    Public Property FormRelatedClass() As CPart
        Get
            Return _oFormRelatedClass
        End Get
        Set(ByVal value As CPart)
            _oFormRelatedClass = value
        End Set
    End Property

    Private _oCFormController As CFormController_

    Public Property oCFormController() As CFormController_ Implements IFormCommandRules.oCFormController
        Get
            Return _oCFormController
        End Get
        Set(ByVal value As CFormController_)

            _oCFormController = value
        End Set
    End Property


    Private _oCApplicationHelper As CApplicationHelper


    Public Property oCApplicationHelper() As CApplicationHelper Implements IFormCommandRules.oCApplicationHelper
        Get
            Return _oCApplicationHelper
        End Get
        Set(ByVal value As CApplicationHelper)

            _oCApplicationHelper = value
        End Set
    End Property

    Private _oResponse As SqlParameter
    Public Property oResponse() As SqlParameter Implements IFormCommandRules.oResponse
        Get
            Return _oResponse
        End Get
        Set(ByVal value As SqlParameter)
            _oResponse = value
        End Set
    End Property

    Private _oSqlCommand As SqlCommand

    Public Property oSqlCommand() As SqlCommand Implements IFormCommandRules.oSqlCommand
        Get
            Return _oSqlCommand
        End Get
        Set(ByVal value As SqlCommand)
            _oSqlCommand = value
        End Set
    End Property

    Private _oSqlParameter As SqlParameter

    Public Property oSqlParameter() As SqlParameter Implements IFormCommandRules.oSqlParameter
        Get
            Return _oSqlParameter
        End Get
        Set(ByVal value As SqlParameter)
            _oSqlParameter = value
        End Set
    End Property

    Private _oSqlDataAdapter As SqlDataAdapter

    Public Property oSqlDataAdapter() As SqlDataAdapter Implements IFormCommandRules.oSqlDataAdapter
        Get
            Return _oSqlDataAdapter
        End Get
        Set(ByVal value As SqlDataAdapter)

            _oSqlDataAdapter = value
        End Set
    End Property

    Private _oDataRelation As DataRelation

    Public Property oDataRelation() As DataRelation ' Implements IFormCommandRules.oDataRelation
        Get
            Return _oDataRelation
        End Get
        Set(ByVal value As DataRelation)

            _oDataRelation = value
        End Set
    End Property

    Private _oCollectionBSourceCombo As New Collection

    Public Property oCollectionBSourceCombo() As Collection Implements IFormCommandRules.oCollectionBSourceCombo
        Get
            Return _oCollectionBSourceCombo
        End Get
        Set(ByVal value As Collection)
            _oCollectionBSourceCombo = value
        End Set
    End Property

    Private _oBSourceCombo As BindingSource

    Public Property oBSourceCombo() As BindingSource Implements IFormCommandRules.oBSourceCombo
        Get

            Return _oBSourceCombo

        End Get

        Set(ByVal value As BindingSource)
            _oBSourceCombo = value
        End Set

    End Property

    Private _oDataSet As New DataSet

    Public Property oDataSet() As DataSet Implements IFormCommandRules.oDataSet
        Get
            Return _oDataSet
        End Get
        Set(ByVal value As DataSet)
            _oDataSet = value
        End Set
    End Property

    Private _oFProgress As New FProgress
    Public Property oFProgress() As FProgress Implements IFormCommandRules.oFProgress
        Get
            Return _oFProgress
        End Get
        Set(ByVal value As FProgress)
            _oFProgress = value
        End Set
    End Property

    Private _oBindingSource As New BindingSource
    Public Property oBindingSource() As BindingSource Implements IFormCommandRules.oBindingSource
        Get
            Return _oBindingSource
        End Get
        Set(ByVal value As BindingSource)
            _oBindingSource = value
        End Set
    End Property

    Private _parent_table_name As String
    Public Property parent_table_name() As String
        Get
            Return _parent_table_name
        End Get
        Set(ByVal value As String)
            _parent_table_name = value
        End Set
    End Property

    Private _child_table_name As String
    Public Property child_table_name() As String
        Get
            Return _child_table_name
        End Get
        Set(ByVal value As String)
            _child_table_name = value
        End Set
    End Property

    Private _stored_procedure_name As String
    Public Property stored_procedure_name() As String
        Get
            Return _stored_procedure_name
        End Get
        Set(ByVal value As String)
            _stored_procedure_name = value
        End Set
    End Property

    Private _NewRowIndex As Integer
    Public Property NewRowIndex() As Integer Implements IFormCommandRules.NewRowIndex
        Get
            Return _NewRowIndex
        End Get
        Set(ByVal value As Integer)
            _NewRowIndex = value
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

    Private _form_state As Integer
    Public Property form_state() As Integer
        Get
            Return _form_state
        End Get
        Set(ByVal value As Integer)
            _form_state = value
        End Set
    End Property

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

    Private _formProcessType As Integer = CApplication.FormProcessType.Catalog
    Public Property MyProcessType() As Integer
        Get
            Return _formProcessType
        End Get
        Set(ByVal value As Integer)
            _formProcessType = value
        End Set
    End Property

    Private _data_relation_name As String
    Public Property data_relation_name() As String
        Get
            Return _data_relation_name
        End Get
        Set(ByVal value As String)
            _data_relation_name = value
        End Set
    End Property

    Dim _localDatagridView As DataGridView

    Protected Property localDatagridView() As DataGridView
        Get
            Return _localDatagridView
        End Get
        Set(ByVal Value As DataGridView)
            _localDatagridView = Value
        End Set
    End Property

    Dim _localBindingNavigator As BindingNavigator

    Protected Property localBindingNavigator() As BindingNavigator
        Get
            Return _localBindingNavigator
        End Get
        Set(ByVal value As BindingNavigator)
            _localBindingNavigator = value
        End Set
    End Property

    Dim _localTSDownDirectAccess As ToolStrip

    Protected Property localTSDownDirectAccess() As ToolStrip
        Get
            Return _localTSDownDirectAccess
        End Get
        Set(ByVal value As ToolStrip)
            _localTSDownDirectAccess = value
        End Set
    End Property

    Dim _localObjectKey As Object

    Protected Property localObjectKey() As Object
        Get
            Return _localObjectKey
        End Get
        Set(ByVal value As Object)
            _localObjectKey = value
        End Set
    End Property

    Dim _localFocusedObject As Object

    Protected Property localFocusedObject() As Object
        Get
            Return _localFocusedObject
        End Get
        Set(ByVal value As Object)
            _localFocusedObject = value
        End Set
    End Property

    Enum SPCommand

        QueryAll = 1
        Add = 2
        Update = 3
        Save = 4
        Delete = 5
        None = 0
        Authenticate = 69

        GetRelatedSpecs = 30

    End Enum



End Class