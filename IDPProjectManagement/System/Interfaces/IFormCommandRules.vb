﻿Imports System.Data.SqlClient

Public Interface IFormCommandRules

    '----------------------------------------------------
    ' Properties All Forms Must Have.
    '----------------------------------------------------
    Property oDataSet() As DataSet
    Property oBSourceCombo() As BindingSource
    Property oCollectionBSourceCombo() As Collection
    Property oSqlDataAdapter() As SqlDataAdapter
    Property oResponse() As SqlParameter
    Property oSqlParameter() As SqlParameter
    Property oCFormController() As CFormController_
    Property oCApplicationHelper() As CApplicationHelper
    Property oSqlCommand() As SqlCommand
    Property oFProgress() As FProgress
    Property oBindingSource() As BindingSource
    Property NewRowIndex() As Integer


    ' Common Behavior

    '----------------------------------------------------
    ' ToolBoxCommand
    '----------------------------------------------------
    Function CommandSave() As Boolean

    Function CommandAddNew() As Boolean
    Function CommandNew() As Boolean
    Function CommandDelete() As Boolean
    Function CommandUpdate() As Boolean
    Function CommandEdit() As Boolean
    Function CommandCancel() As Boolean
    Function CommandQuery() As Boolean
    Function CommandFind() As Boolean
    Function CommandQueryFind() As Boolean
    Function CommandExit() As Boolean
    Sub CommandClose(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    Function CommandSendToExcel() As Boolean
    Function CommandDirectAccess() As Boolean

    '----------------------------------------------------
    ' ?
    '----------------------------------------------------

    Function SetControlsBinding() As Boolean
    Function SetControlsBindingOnNew() As Boolean
    Function ClearControlsBinding() As Boolean
    Function SetBindingSource() As Boolean

    Function SetBindingSource(ByRef oBindingSourceDummy As BindingSource) As Boolean

    Function SetBindingSource(ByRef oForm As Form, ByRef oBindingSourceDummy As BindingSource, ByVal PrepareSPCommand As Action(Of SqlCommand, Int32, Form)) As Boolean

    Function SetBindingSourceFilter(ByRef oBindingSourceDummy As BindingSource) As Boolean
    Function PrepareSPCommand(ByRef oSqlCommandDummy As SqlCommand, ByVal spCommandValue As Integer) As Boolean

    Sub SetControlPropertiesFormat()
    Sub SetGridPropertiesFormat()
    Sub SetToolBarConfiguration(ByVal State As Integer)

    Function CommandNew(ByVal SetControlsBindingOnNew As Action(Of Form)) As Boolean


End Interface


