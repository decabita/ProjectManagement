﻿Imports System.Data.SqlClient

Partial Public Class FMenus

    Dim oSqlCommand As SqlCommand
    Dim oResponse As SqlParameter

    Dim actualRow As Integer
    Dim newRow As Integer

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

    Private _oBindingSourceParent As New BindingSource
    Public Property oBindingSourceParent() As BindingSource
        Get
            Return _oBindingSourceParent
        End Get
        Set(ByVal value As BindingSource)
            _oBindingSourceParent = value
        End Set
    End Property


    Private _centro_id As String = String.Empty
    Public Property centro_id() As String
        Get
            Return _centro_id
        End Get
        Set(ByVal value As String)
            _centro_id = value
        End Set
    End Property

    Private _menu_id As String = String.Empty
    Public Property menu_id() As String
        Get
            Return _menu_id
        End Get
        Set(ByVal value As String)
            _menu_id = value
        End Set
    End Property

    Private _menu_nombre As String = String.Empty
    Public Property menu_nombre() As String
        Get
            Return _menu_nombre
        End Get
        Set(ByVal value As String)
            _menu_nombre = value
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

    Private _menu_caption As String = String.Empty
    Public Property menu_caption() As String
        Get
            Return _menu_caption
        End Get
        Set(ByVal value As String)
            _menu_caption = value
        End Set
    End Property

    Private _is_visible As Boolean
    Public Property is_visible() As Boolean
        Get
            Return _is_visible
        End Get
        Set(ByVal value As Boolean)
            _is_visible = value
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

    Enum SPCommand

        None = 0
        QueryAll = 1
        Add = 2
        Update = 3
        SaveCommand = 4
        Delete = 5
        CheckIfPartExists = 6


        GetRelatedSpecs = 30

    End Enum

End Class
