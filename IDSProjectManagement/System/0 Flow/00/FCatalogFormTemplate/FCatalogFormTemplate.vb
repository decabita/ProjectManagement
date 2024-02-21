
Imports System.Reflection

Public Class FCatalogFormTemplate
    Inherits System.Windows.Forms.Form
    Implements IFormCommandRules

    Friend WithEvents BackgroundWorkerTemplate As System.ComponentModel.BackgroundWorker

    Public Delegate Function DoWorkDelegate(ByVal strSomeString As String) As Boolean


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Call CApplication.SetFormFormat(Me)

        Me.oCFormController = New CFormController_
        Me.oCFormController.parent_form = Me
        Me.view_mode = CApplication.ViewMode.SingleView
        Me.form_state = CApplication.ControlState.InitState

        AddHandler Me.KeyPress, AddressOf Me.CommandClose

    End Sub

    Sub InitializeComponent()
        Me.BackgroundWorkerTemplate = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'BackgroundWorkerTemplate
        '
        '
        'FCatalogFormTemplate
        '
        Me.ClientSize = New System.Drawing.Size(282, 253)
        Me.ControlBox = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FCatalogFormTemplate"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)

    End Sub

    Protected Friend Overridable Function CommandExit() As Boolean Implements IFormCommandRules.CommandExit

        DirectCast(Me.ParentForm, MDIMainContainer).Dispose()

    End Function

    Protected Friend Overridable Function CommandFind() As Boolean Implements IFormCommandRules.CommandFind

        Call ClearControlsBinding()
        Call Me.SetToolBarConfiguration(CApplication.ControlState.Find)

    End Function

    Protected Friend Overridable Function CommandQueryFind() As Boolean Implements IFormCommandRules.CommandQueryFind

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

    Protected Friend Overridable Function CommandNew() As Boolean Implements IFormCommandRules.CommandNew

        ' Establece el formato de la barra de comandos.
        Call ClearControlsBinding()
        Call Me.SetToolBarConfiguration(CApplication.ControlState.Add)
        Call Me.SetControlsBindingOnNew()
    End Function

    Protected Friend Overridable Sub CommandClose(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Implements IFormCommandRules.CommandClose

        If Asc(e.KeyChar) = Keys.Escape Then Me.Dispose()

    End Sub

    Protected Friend Overridable Function CommandQuery() As Boolean Implements IFormCommandRules.CommandQuery

    End Function

    Public Overridable Function CommandSendToExcel() As Boolean Implements IFormCommandRules.CommandSendToExcel

        'Dim oCReportingServices As New CReportingServices

        'With oCReportingServices

        '    .SheetTitle = Me.Text
        '    .ParentTableName = Me.parent_table_name
        '    .DataRelationName = Me.data_relation_name
        '    .DataGridViewParent = Me.localDatagridView
        '    .oFormController = Me.oCFormController
        '    .oDataSetParent = Me.oDataSet
        '    .SendToExcelService()

        'End With

    End Function

    Protected Friend Overridable Function CommandDirectAccess() As Boolean Implements IFormCommandRules.CommandDirectAccess

    End Function

    Protected Friend Overridable Function CommandEdit() As Boolean Implements IFormCommandRules.CommandEdit

        Try

            If Not CBool(Me.localDatagridView.CurrentRow.Cells("is_active").Value) Then MessageBox.Show("El registro no está Activo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Function

            ' Establece el formato de la barra de comandos.
            Call Me.SetToolBarConfiguration(CApplication.ControlState.Edit)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function
    Protected Friend Overridable Function CommandDelete() As Boolean Implements IFormCommandRules.CommandDelete

    End Function

    Protected Friend Overridable Function CommandSave() As Boolean Implements IFormCommandRules.CommandSave

    End Function

    Protected Friend Function CommandUpdate() As Boolean Implements IFormCommandRules.CommandUpdate

    End Function

    Protected Friend Overridable Function SetBindingSource() As Boolean Implements IFormCommandRules.SetBindingSource

    End Function

    Protected Friend Overridable Function SetBindingSourceFilter() As Boolean Implements IFormCommandRules.SetBindingSourceFilter

    End Function

    Protected Friend Overridable Function SetControlsBinding() As Boolean Implements IFormCommandRules.SetControlsBinding

    End Function

    Protected Friend Overridable Function SetControlsBindingOnNew() As Boolean Implements IFormCommandRules.SetControlsBindingOnNew

    End Function

    Protected Friend Overridable Sub SetToolBarConfiguration(ByVal State As Integer) Implements IFormCommandRules.SetToolBarConfiguration

        Dim enableControls As Boolean = False

        Select Case State

            ' Initial State On ToolBar Strip.
            Case CApplication.ControlState.None

                Me.form_state = CApplication.ControlState.None

                CApplication.EnableControls(Me, False)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDirectAccess.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBFind.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExecFind.Enabled = False

                Me.localBindingNavigator.Enabled = False
                If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                ' If there are records.
                Select Case IIf(Me.oBindingSource.Count <= 0, 0, 1)

                    Case Is > 0

                        DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBFind.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = True

                        Me.localBindingNavigator.Enabled = True
                        Me.localDatagridView.Enabled = True
                        Me.localBindingNavigator.Refresh()

                        enableControls = True

                    Case Else

                        DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True

                        Me.localBindingNavigator.Enabled = False
                        Me.localDatagridView.Enabled = False

                        enableControls = False

                End Select

                For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                    item.Enabled = enableControls
                Next item

                Me.localFocusedObject.Focus()

                ' Initial State On ToolBar Strip.
            Case CApplication.ControlState.InitState

                Me.form_state = CApplication.ControlState.InitState

                Call CApplication.EnableControls(Me, False)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDirectAccess.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBFind.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExecFind.Enabled = False

                Me.localBindingNavigator.Enabled = False
                If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                ' If there are records.
                Select Case IIf(Me.oBindingSource.Count <= 0, 0, 1)

                    Case Is > 0

                        DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBFind.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = True

                        Me.localBindingNavigator.Enabled = True
                        If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = True
                        Me.localBindingNavigator.Refresh()

                        enableControls = True

                    Case Else

                        DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True

                        Me.localBindingNavigator.Enabled = False
                        If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                        enableControls = False

                End Select

                For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                    item.Enabled = enableControls
                Next item

                If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Focus()

                '---------------------------------------------------------
                ' When Press Query Command Button. 
                '---------------------------------------------------------
            Case CApplication.ControlState.Query

                Me.form_state = CApplication.ControlState.Query

                CApplication.EnableControls(Me, False)
                CApplication.ClearControls(Me)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDirectAccess.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBFind.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExecFind.Enabled = False

                Me.localBindingNavigator.Enabled = False
                If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = True

                For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                    item.Enabled = False
                Next

                '---------------------------------------------------------
                ' When Press Add Command Button Or Enter Add Mode.
                '---------------------------------------------------------
            Case CApplication.ControlState.Add

                Me.form_state = CApplication.ControlState.Add

                CApplication.EnableControls(Me, True)
                CApplication.ClearControls(Me)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDirectAccess.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBFind.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExecFind.Enabled = False

                Me.localBindingNavigator.Enabled = False
                If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                    item.Enabled = False
                Next

                Me.localObjectKey.Focus()

                '---------------------------------------------------------
                ' When Press Edit Command Button Or Enter Edit Mode. 
                '---------------------------------------------------------
            Case CApplication.ControlState.Edit

                Me.form_state = CApplication.ControlState.Edit

                CApplication.EnableControls(Me, True)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBFind.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExecFind.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDirectAccess.Enabled = True

                Me.localObjectKey.Enabled = False

                Me.localBindingNavigator.Enabled = False
                If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                    item.Enabled = False
                Next item

                Me.localFocusedObject.Focus()

                '---------------------------------------------------------
                ' When Press Filter Command Button Or Enter Filter Mode.
                '---------------------------------------------------------
            Case CApplication.ControlState.Find

                Me.form_state = CApplication.ControlState.Find

                CApplication.EnableControls(Me, True)
                CApplication.ClearControls(Me)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDirectAccess.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBFind.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExecFind.Enabled = True

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

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDirectAccess.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBFind.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExecFind.Enabled = False

                Me.localBindingNavigator.Enabled = False
                If Not Me.localDatagridView Is Nothing Then Me.localDatagridView.Enabled = False

                For Each item As ToolStripItem In Me.localTSDownDirectAccess.Items
                    item.Enabled = False
                Next

        End Select

        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormStateDescription(Me.form_state)

    End Sub

    Protected Friend Overridable Sub SetControlPropertiesFormat() Implements IFormCommandRules.SetControlPropertiesFormat

    End Sub

    Protected Friend Overridable Sub SetGridPropertiesFormat() Implements IFormCommandRules.SetGridPropertiesFormat

    End Sub

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

End Class
