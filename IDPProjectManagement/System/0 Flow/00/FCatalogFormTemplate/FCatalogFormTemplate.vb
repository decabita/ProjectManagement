Imports System.Data.SqlClient
Imports System.Reflection
Imports IDPProjectManagement

Public Class FCatalogFormTemplate
    Implements IFormCommandRules

    Friend WithEvents BackgroundWorkerTemplate As System.ComponentModel.BackgroundWorker

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.BackgroundWorkerTemplate = New System.ComponentModel.BackgroundWorker()

        'Call CApplication.SetFormFormat(Me)

        Me.oCFormController = New CFormController_
        Me.oCFormController.parent_form = Me
        Me.view_mode = CApplication.ViewMode.SingleView
        Me.form_state = CApplication.ControlState.InitState

        AddHandler Me.KeyPress, AddressOf Me.CommandClose

    End Sub

    Public Delegate Function DoWorkDelegate(ByVal strSomeString As String) As Boolean


    Protected Friend Overridable Sub CommandClose(sender As Object, e As KeyPressEventArgs) Implements IFormCommandRules.CommandClose

        If Asc(e.KeyChar) = Keys.Escape Then Me.Dispose()

    End Sub

    Protected Friend Overridable Sub SetControlPropertiesFormat() Implements IFormCommandRules.SetControlPropertiesFormat
        Throw New NotImplementedException()
    End Sub

    Protected Friend Overridable Sub SetGridPropertiesFormat() Implements IFormCommandRules.SetGridPropertiesFormat
        Throw New NotImplementedException()
    End Sub

    Public Sub SetToolBarConfiguration(State As Integer) Implements IFormCommandRules.SetToolBarConfiguration

        Dim enableControls As Boolean = False

        Dim oBindingNavigator = Me.ParentForm.Controls.Find("BindingNavigator", True)
        Dim oDataGridView = Me.ParentForm.Controls.Find("DataGridView", True)
        Dim oToolStrip = Me.ParentForm.Controls.Find("TSDownDirectAcces", True)

        Select Case State

            ' Initial State On ToolBar Strip.
            Case CApplication.ControlState.None

                Me.form_state = CApplication.ControlState.None

                CApplication.EnableControls(Me, False)

                With DirectCast(Me.ParentForm, MDIMainContainer)

                    .TSBQuery.Enabled = False
                    .TSBExportToExcel.Enabled = False
                    .TSBNew.Enabled = False
                    .TSBSave.Enabled = False
                    .TSBEdit.Enabled = False
                    .TSBCancel.Enabled = False
                    .TSBDelete.Enabled = False
                    .TSBExit.Enabled = True
                    .TSBDirectAccess.Enabled = False
                    .TSBFind.Enabled = False
                    .TSBExecFind.Enabled = False

                End With

                If oBindingNavigator IsNot Nothing Then

                    DirectCast(oBindingNavigator(0), BindingNavigator).Enabled = False

                End If

                If oDataGridView IsNot Nothing Then

                    DirectCast(oDataGridView(0), DataGridView).Enabled = False

                End If

                If oToolStrip IsNot Nothing Then

                    For Each item As ToolStripItem In DirectCast(oToolStrip(0), ToolStrip).Items
                        item.Enabled = False
                    Next

                End If

                'Me.localBindingNavigator.Enabled = False
                'If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                ' If there are records.
                Select Case IIf(Me.oBindingSource.Count <= 0, 0, 1)

                    Case Is > 0

                        With DirectCast(Me.ParentForm, MDIMainContainer)

                            .TSBQuery.Enabled = True
                            .TSBFind.Enabled = True
                            .TSBNew.Enabled = True
                            .TSBExportToExcel.Enabled = False 'Restore when implemented True
                            .TSBEdit.Enabled = True
                            .TSBDelete.Enabled = True

                        End With


                        'Me.localBindingNavigator.Enabled = True
                        'Me.localDatagridView.Enabled = True
                        'Me.localBindingNavigator.Refresh()

                        If oBindingNavigator IsNot Nothing Then

                            DirectCast(oBindingNavigator(0), BindingNavigator).Enabled = False

                            DirectCast(oBindingNavigator(0), BindingNavigator).Refresh()

                        End If

                        If oDataGridView IsNot Nothing Then

                            DirectCast(oDataGridView(0), DataGridView).Enabled = True

                        End If


                        enableControls = True

                    Case Else

                        DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True

                        'Me.localBindingNavigator.Enabled = False
                        'Me.localDatagridView.Enabled = False

                        If oBindingNavigator IsNot Nothing Then

                            DirectCast(oBindingNavigator(0), BindingNavigator).Enabled = False

                        End If

                        If oDataGridView IsNot Nothing Then

                            DirectCast(oDataGridView(0), DataGridView).Enabled = False

                        End If

                        enableControls = False

                End Select


                If oToolStrip IsNot Nothing Then

                    For Each item As ToolStripItem In DirectCast(oToolStrip(0), ToolStrip).Items
                        item.Enabled = enableControls
                    Next

                End If

                'For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                '    item.Enabled = enableControls
                'Next item

                Me.localFocusedObject.Focus()

                ' Initial State On ToolBar Strip.
            Case CApplication.ControlState.InitState

                Me.form_state = CApplication.ControlState.InitState

                Call CApplication.EnableControls(Me, False)

                With DirectCast(Me.ParentForm, MDIMainContainer)

                    .TSBQuery.Enabled = False
                    .TSBExportToExcel.Enabled = False
                    .TSBNew.Enabled = False
                    .TSBSave.Enabled = False
                    .TSBEdit.Enabled = False
                    .TSBCancel.Enabled = False
                    .TSBDelete.Enabled = False
                    .TSBExit.Enabled = True
                    .TSBDirectAccess.Enabled = False
                    .TSBFind.Enabled = False
                    .TSBExecFind.Enabled = False

                End With

                'Me.localBindingNavigator.Enabled = False
                'If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                If oBindingNavigator IsNot Nothing Then

                    DirectCast(oBindingNavigator(0), BindingNavigator).Enabled = False

                End If

                If oDataGridView IsNot Nothing Then

                    DirectCast(oDataGridView(0), DataGridView).Enabled = False

                End If

                ' If there are records.
                Select Case IIf(Me.oBindingSource.Count <= 0, 0, 1)

                    Case Is > 0

                        With DirectCast(Me.ParentForm, MDIMainContainer)
                            .TSBQuery.Enabled = True
                            .TSBFind.Enabled = True
                            .TSBNew.Enabled = True
                            .TSBExportToExcel.Enabled = False 'Restore when implemented True
                            .TSBEdit.Enabled = True
                            .TSBDelete.Enabled = True
                        End With


                        'Me.localBindingNavigator.Enabled = True
                        'If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = True
                        'Me.localBindingNavigator.Refresh()

                        If oBindingNavigator IsNot Nothing Then

                            DirectCast(oBindingNavigator(0), BindingNavigator).Enabled = True
                            DirectCast(oBindingNavigator(0), BindingNavigator).Refresh()

                        End If

                        If oDataGridView IsNot Nothing Then

                            DirectCast(oDataGridView(0), DataGridView).Enabled = True

                        End If

                        enableControls = True

                    Case Else

                        DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True


                        If oBindingNavigator IsNot Nothing Then

                            DirectCast(oBindingNavigator(0), BindingNavigator).Enabled = False

                        End If

                        If oDataGridView IsNot Nothing Then

                            DirectCast(oDataGridView(0), DataGridView).Enabled = False

                        End If

                        'Me.localBindingNavigator.Enabled = False
                        'If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                        enableControls = False

                End Select

                If oToolStrip IsNot Nothing Then

                    For Each item As ToolStripItem In DirectCast(oToolStrip(0), ToolStrip).Items
                        item.Enabled = enableControls
                    Next

                End If

                If oDataGridView IsNot Nothing Then

                    DirectCast(oDataGridView(0), DataGridView).Focus()

                End If


                'For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                '    item.Enabled = enableControls
                'Next item

                'If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Focus()

                '---------------------------------------------------------
                ' When Press Query Command Button. 
                '---------------------------------------------------------
            Case CApplication.ControlState.Query

                Me.form_state = CApplication.ControlState.Query

                CApplication.EnableControls(Me, False)
                CApplication.ClearControls(Me)

                With DirectCast(Me.ParentForm, MDIMainContainer)

                    .TSBQuery.Enabled = False
                    .TSBExportToExcel.Enabled = False
                    .TSBNew.Enabled = False
                    .TSBEdit.Enabled = False
                    .TSBSave.Enabled = False
                    .TSBDelete.Enabled = False
                    .TSBCancel.Enabled = False
                    .TSBExit.Enabled = False
                    .TSBDirectAccess.Enabled = False
                    .TSBFind.Enabled = False
                    .TSBExecFind.Enabled = False

                End With

                If oBindingNavigator IsNot Nothing Then

                    DirectCast(oBindingNavigator(0), BindingNavigator).Enabled = False

                End If

                If oDataGridView IsNot Nothing Then

                    DirectCast(oDataGridView(0), DataGridView).Enabled = True

                End If

                If oToolStrip IsNot Nothing Then

                    For Each item As ToolStripItem In DirectCast(oToolStrip(0), ToolStrip).Items
                        item.Enabled = False
                    Next

                End If
                '---------------------------------------------------------
                ' When Press Add Command Button Or Enter Add Mode.
                '---------------------------------------------------------
            Case CApplication.ControlState.Add

                Me.form_state = CApplication.ControlState.Add

                CApplication.EnableControls(Me, True)
                CApplication.ClearControls(Me)

                With DirectCast(Me.ParentForm, MDIMainContainer)
                    .TSBQuery.Enabled = False
                    .TSBExportToExcel.Enabled = False
                    .TSBNew.Enabled = False
                    .TSBEdit.Enabled = False
                    .TSBSave.Enabled = True
                    .TSBDelete.Enabled = False
                    .TSBCancel.Enabled = True
                    .TSBExit.Enabled = True
                    .TSBDirectAccess.Enabled = True
                    .TSBFind.Enabled = False
                    .TSBExecFind.Enabled = False
                End With

                If oBindingNavigator IsNot Nothing Then

                    DirectCast(oBindingNavigator(0), BindingNavigator).Enabled = False

                End If

                If oDataGridView IsNot Nothing Then

                    DirectCast(oDataGridView(0), DataGridView).Enabled = False

                End If

                If oToolStrip IsNot Nothing Then

                    For Each item As ToolStripItem In DirectCast(oToolStrip(0), ToolStrip).Items
                        item.Enabled = False
                    Next

                End If

                'Me.localBindingNavigator.Enabled = False
                'If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                'For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                '    item.Enabled = False
                'Next

                Me.localObjectKey.Enabled = False
                Me.localFocusedObject.Focus()

                '---------------------------------------------------------
                ' When Press Edit Command Button Or Enter Edit Mode. 
                '---------------------------------------------------------
            Case CApplication.ControlState.Edit

                Me.form_state = CApplication.ControlState.Edit

                CApplication.EnableControls(Me, True)

                With DirectCast(Me.ParentForm, MDIMainContainer)
                    .TSBQuery.Enabled = False
                    .TSBExportToExcel.Enabled = False
                    .TSBNew.Enabled = False
                    .TSBEdit.Enabled = False
                    .TSBSave.Enabled = True
                    .TSBDelete.Enabled = False
                    .TSBCancel.Enabled = True
                    .TSBExit.Enabled = True
                    .TSBFind.Enabled = False
                    .TSBExecFind.Enabled = False
                    .TSBDirectAccess.Enabled = True
                End With

                Me.localObjectKey.Enabled = False

                If oBindingNavigator IsNot Nothing Then

                    DirectCast(oBindingNavigator(0), BindingNavigator).Enabled = False

                End If

                If oDataGridView IsNot Nothing Then

                    DirectCast(oDataGridView(0), DataGridView).Enabled = False

                End If

                If oToolStrip IsNot Nothing Then

                    For Each item As ToolStripItem In DirectCast(oToolStrip(0), ToolStrip).Items
                        item.Enabled = False
                    Next

                End If

                'Me.localBindingNavigator.Enabled = False
                'If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                'For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                '    item.Enabled = False
                'Next item

                Me.localFocusedObject.Focus()

                '---------------------------------------------------------
                ' When Press Filter Command Button Or Enter Filter Mode.
                '---------------------------------------------------------
            Case CApplication.ControlState.Find

                Me.form_state = CApplication.ControlState.Find

                CApplication.EnableControls(Me, True)
                CApplication.ClearControls(Me)

                With DirectCast(Me.ParentForm, MDIMainContainer)
                    .TSBQuery.Enabled = True
                    .TSBExportToExcel.Enabled = False
                    .TSBNew.Enabled = True
                    .TSBEdit.Enabled = False
                    .TSBSave.Enabled = False
                    .TSBDelete.Enabled = False
                    .TSBCancel.Enabled = False
                    .TSBExit.Enabled = True
                    .TSBDirectAccess.Enabled = False
                    .TSBFind.Enabled = False
                    .TSBExecFind.Enabled = True
                End With

                Me.localBindingNavigator.Enabled = False
                If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                    item.Enabled = False
                Next

                Me.localObjectKey.Focus()

                '---------------------------------------------------------
                ' When Press Exec Filter Command Button Or Enter Filter Mode.
                '---------------------------------------------------------
            Case CApplication.ControlState.ExecFind

                Me.form_state = CApplication.ControlState.ExecFind

                CApplication.EnableControls(Me, False)
                CApplication.ClearControls(Me)

                With DirectCast(Me.ParentForm, MDIMainContainer)
                    .TSBQuery.Enabled = False
                    .TSBExportToExcel.Enabled = False
                    .TSBNew.Enabled = False
                    .TSBEdit.Enabled = False
                    .TSBSave.Enabled = False
                    .TSBDelete.Enabled = False
                    .TSBCancel.Enabled = False
                    .TSBExit.Enabled = False
                    .TSBDirectAccess.Enabled = False
                    .TSBFind.Enabled = False
                    .TSBExecFind.Enabled = False
                End With


                Me.localBindingNavigator.Enabled = False
                If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                    item.Enabled = False
                Next

        End Select

        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormStateDescription(Me.form_state)

    End Sub

    Protected Friend Overridable Function CommandSave() As Boolean Implements IFormCommandRules.CommandSave
        Throw New NotImplementedException()
    End Function

    Protected Friend Overridable Function CommandNew() As Boolean Implements IFormCommandRules.CommandNew
        ' Establece el formato de la barra de comandos.
        Call Me.ClearControlsBinding()
        Call Me.SetToolBarConfiguration(CApplication.ControlState.Add)
        Call Me.SetControlsBindingOnNew()

        Return True

    End Function

    Protected Friend Overridable Function CommandDelete() As Boolean Implements IFormCommandRules.CommandDelete
        Throw New NotImplementedException()
    End Function

    Protected Friend Overridable Function CommandUpdate() As Boolean Implements IFormCommandRules.CommandUpdate
        Throw New NotImplementedException()
    End Function

    Protected Friend Overridable Function CommandEdit() As Boolean Implements IFormCommandRules.CommandEdit

        Try

            If Not CBool(Me.localDatagridView.CurrentRow.Cells("is_active").Value) Then MessageBox.Show("El registro no está Activo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return CommandEdit

            ' Establece el formato de la barra de comandos.
            Call Me.SetToolBarConfiguration(CApplication.ControlState.Edit)

            CommandEdit = True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return CommandEdit

    End Function

    Protected Friend Overridable Function CommandCancel() As Boolean Implements IFormCommandRules.CommandCancel

        Select Case Me.view_mode

            Case CApplication.ViewMode.SingleView

                If Me.form_state.Equals(CApplication.ControlState.Add) Then

                    Me.oBindingSource.CancelEdit()

                    ' TODO REVIEW
                    'If Not CBool(CInt(IIf(Me.localBindingNavigator.BindingSource Is Nothing, 0, Me.localBindingNavigator.BindingSource.Count))) Then CApplication.ClearControlsOnAddState(Me)

                    ' If Not (IIf(Me.localBindingNavigator.BindingSource Is Nothing, 0, Me.localBindingNavigator.BindingSource.Count)) > 0 Then CApplication.ClearControlsOnAddState(Me)

                    If Not Me.localBindingNavigator.BindingSource Is Nothing Then

                        CApplication.ClearControlsOnAddState(Me)

                    End If

                    '-----------------------------------

                    Call Me.CommandQuery()

                ElseIf Me.form_state.Equals(CApplication.ControlState.Find) Then

                    Me.oBindingSource.CancelEdit()

                    Call Me.CommandQuery()

                ElseIf Me.form_state.Equals(CApplication.ControlState.Edit) Then

                    Me.oBindingSource.CancelEdit()

                End If

        End Select

        Call Me.SetToolBarConfiguration(CApplication.ControlState.InitState)

    End Function

    Protected Friend Overridable Function CommandQuery() As Boolean Implements IFormCommandRules.CommandQuery
        Throw New NotImplementedException()
    End Function

    Protected Friend Overridable Function CommandFind() As Boolean Implements IFormCommandRules.CommandFind
        Call ClearControlsBinding()
        Call Me.SetToolBarConfiguration(CApplication.ControlState.Find)

    End Function

    Protected Friend Overridable Function CommandQueryFind() As Boolean Implements IFormCommandRules.CommandQueryFind
        Throw New NotImplementedException()
    End Function

    Protected Friend Overridable Function CommandExit() As Boolean Implements IFormCommandRules.CommandExit

        DirectCast(Me.ParentForm, MDIMainContainer).Dispose()

    End Function

    Protected Friend Overridable Function CommandSendToExcel() As Boolean Implements IFormCommandRules.CommandSendToExcel
        Throw New NotImplementedException()
    End Function

    Protected Friend Overridable Function CommandDirectAccess() As Boolean Implements IFormCommandRules.CommandDirectAccess
        Throw New NotImplementedException()
    End Function

    Protected Friend Overridable Function SetControlsBinding() As Boolean Implements IFormCommandRules.SetControlsBinding
        Throw New NotImplementedException()
    End Function

    Protected Friend Overridable Function SetControlsBindingOnNew() As Boolean Implements IFormCommandRules.SetControlsBindingOnNew
        Throw New NotImplementedException()
    End Function

    Protected Friend Overridable Function ClearControlsBinding() As Boolean Implements IFormCommandRules.ClearControlsBinding

        Try

            ' -------------------------------------------
            ' Clear Binding.
            ' -------------------------------------------
            Call CApplication.ClearControlBinding(Me)

            Me.oDataSet = New DataSet

            If Not Me.oCollectionBSourceCombo Is Nothing Then Me.oCollectionBSourceCombo.Clear()

            Return True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Protected Friend Overridable Function SetBindingSource() As Boolean Implements IFormCommandRules.SetBindingSource
        Throw New NotImplementedException()
    End Function

    Protected Friend Overridable Function SetBindingSource(ByRef oBindingSourceDummy As BindingSource) As Boolean Implements IFormCommandRules.SetBindingSource

        Try

            Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

                Using oSqlCommand As New SqlCommand(Me.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

                    ' ---------------------------------
                    ' Set Command Ready and Execute
                    ' ---------------------------------
                    If Not PrepareSPCommand(oSqlCommand, SPCommand.QueryAll) Then Throw New CustomException

                    Using oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

                        Using oDataSet As New DataSet

                            oSqlDataAdapter.Fill(oDataSet, "BindedTableDataSet")

                            If Not CBool(CInt(oDataSet.Tables("BindedTableDataSet").Rows.Count)) Then Throw New CustomException("SetBindingSource: No existen valores en la tabla. Capture información.")

                            oBindingSourceDummy = New BindingSource
                            oBindingSourceDummy.DataSource = oDataSet
                            oBindingSourceDummy.DataMember = "BindedTableDataSet"

                            SetBindingSource = True

                        End Using

                    End Using

                End Using

            End Using


        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return SetBindingSource

    End Function

    Protected Friend Overridable Function SetBindingSourceFilter(ByRef oBindingSourceDummy As BindingSource) As Boolean Implements IFormCommandRules.SetBindingSourceFilter
        Throw New NotImplementedException()
    End Function

    Protected Friend Overridable Function QueryAll() As Boolean

        Try

            ' -------------------------------------------
            ' Set BindingSource.
            ' -------------------------------------------
            If Not Me.SetBindingSource() Then Throw New CustomException

            QueryAll = True

        Catch ex As CustomException

        End Try

        Return QueryAll

    End Function

    Public Sub HandleLostFocusDirectAccess(ByVal sender As Object, ByVal e As System.EventArgs)

        CApplication.HandleLostFocusDirectAccess(sender, DirectCast(Me.ParentForm, MDIMainContainer).TSBDirectAccess)

    End Sub

    Public Sub HandleGotFocusDirectAccess(ByVal sender As Object, ByVal e As System.EventArgs)

        CApplication.HandleGotFocusDirectAccess(sender, DirectCast(Me.ParentForm, MDIMainContainer).TSBDirectAccess)

    End Sub

    Private Sub BackgroundWorkerTemplate_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerTemplate.DoWork

    End Sub

    Protected Friend Overridable Sub ShowMeInMainContainer(FormName As String)

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & "." & FormName)

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                '  If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

                'Dim dummy As Form
                'dummy = DirectCast(oFormToShow, Form)
                'dummy.WindowState = FormWindowState.Maximized

                ' Assigns form to show to MDI.
                oMDIMainContainer.oCFormController_.parent_form = oFormToShow
                oMDIMainContainer.WindowState = FormWindowState.Maximized
                oMDIMainContainer.Show()

            Else

                Throw New CustomException("No se encuentra definido el formulario. Consulte a Soporte Técnico.")

            End If

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Protected Friend Overridable Function PrepareSPCommand(ByRef oSqlCommandDummy As SqlCommand, spCommandValue As Integer) As Boolean Implements IFormCommandRules.PrepareSPCommand
        Throw New NotImplementedException()
    End Function
End Class