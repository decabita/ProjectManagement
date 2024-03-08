Imports System.Data.SqlClient
Imports System.Reflection
Imports System.ComponentModel

Public Class FWorkCenters

    Private _oCurrentForm As New CWorkCenter
    Public Property FormRelatedClass() As CWorkCenter
        Get
            Return _oCurrentForm
        End Get
        Set(ByVal value As CWorkCenter)
            _oCurrentForm = value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Private Sub FWorkCenters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Properties in Form Templete
        stored_procedure_name = "dbo.SP_WORK_CENTERS"
        parent_table_name = "GetParentTableData"

        localDatagridView = Me.DataGridView
        localBindingNavigator = Me.BindingNavigator
        localTSDownDirectAccess = Me.TSDownDirectAcces
        localObjectKey = Me.tGuid
        localFocusedObject = Me.tClaveId

        Me.FormRelatedClass = New CWorkCenter

        Call CommandFind()

        Call Me.CommandQuery()

        Call CWorkCenter.SetGeneralFormat(Me)

    End Sub

    Private Sub BWorkerGetData_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWorkerGetData.DoWork

        Try

            ' Executes Query.
            e.Result = Me.QueryAll()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BWorkerGetData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWorkerGetData.RunWorkerCompleted

        Try

            If Not CBool(CInt(Me.oBindingSource.Count)) Then Throw New CustomException

            ' Establece bind de los controles.
            Call CWorkCenter.SetControlsBinding(Me)

            ' Establece formato de los controles.
            Call CWorkCenter.SetGridPropertiesFormat(Me)

            Call CWorkCenter.SetControlPropertiesFormat(Me)

            ' Establece el formato de la barra de comandos.
            Call SetToolBarConfiguration(CApplication.ControlState.InitState)

        Catch ex As CustomException

            Call SetToolBarConfiguration(CApplication.ControlState.None)

        Finally

            oFProgress.Dispose()
            BWorkerGetData.Dispose()

        End Try

    End Sub
    Private Sub DataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView.DataError
        Dim ex As Exception = e.Exception
    End Sub

    Private Sub DataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.RowEnter

        If Not CBool(CInt(Me.oBindingSource.Count)) Then Exit Sub

        If DataGridView.Rows(e.RowIndex) IsNot Nothing Then Me.current_row = e.RowIndex

    End Sub
    Private Sub FWorkCenters_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.oCFormController.active_form = Me

        ' TODO REPORTS
        DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.parent_form = Me

        DirectCast(Me.ParentForm, MDIMainContainer).MDICurrentForm.Text = Me.Text
        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormStateDescription(Me.form_state)

        ' Establece el formato de la barra de comandos.
        Call SetToolBarConfiguration(Me.form_state)

    End Sub
    Private Sub FWorkCenters_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate

        If Not Me.form_state = CApplication.ControlState.InitState Then Call CommandCancel()

    End Sub
    Private Sub FWorkCenters_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        ' TODO REPORTS
        DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.parent_form = Nothing

        Me.oCFormController.parent_form = Nothing
        DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.PerformClick()

    End Sub

    Dim PrepareSPAction As Action(Of SqlCommand, Integer, Form) = AddressOf CWorkCenter.PrepareSPCommand

    Protected Friend Overrides Function QueryAll() As Boolean

        Try

            ' Get BindingSource.
            If Not SetBindingSource(Me, Me.oBindingSource, PrepareSPAction) Then Return QueryAll

            QueryAll = True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return QueryAll

    End Function

    Protected Friend Overrides Function CommandDelete() As Boolean

        Try

            With Me

                If Not CBool(Me.DataGridView.CurrentRow.Cells("is_active").Value) Then MessageBox.Show("El registro no está Activo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return CommandDelete

                If MessageBox.Show("El registro cambiará de estado a Inactivo. ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(System.Windows.Forms.DialogResult.No) Then Return CommandDelete

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------
                Me.FormRelatedClass = New CWorkCenter With {
                    .id = CApplicationController.oCWorkCenter_.id,
                    .nombre_corto = Me.tClaveId.Text,
                    .guid = Me.tGuid.Text
                }

                If Not CWorkCenter.DeleteRecord(Me) Then Me.form_state = CApplication.ControlState.InitState : Throw New CustomException("Error al eliminar.")

                If Not Me.CommandQuery() Then Me.form_state = CApplication.ControlState.InitState : Throw New CustomException

            End With

            CommandDelete = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return CommandDelete


    End Function

    Protected Friend Overrides Function CommandQuery() As Boolean

        Try

            ' Establece el formato de la barra de comandos.
            Call SetToolBarConfiguration(CApplication.ControlState.Query)

            ' Limpia los controles.
            CApplication.ClearControls(Me)

            ' Inicializa el vínculos de datos.
            If Not Me.ClearControlsBinding() Then Throw New CustomException

            ' Ejecuta la consulta.
            Me.BWorkerGetData.RunWorkerAsync()

            ' Muestra la ventana de progreso.
            Me.oFProgress = New FProgress
            Me.oFProgress.ShowDialog()

            '------------------------------------
            ' Call Child Data Refresh.
            '------------------------------------
            If Not Me.oCFormController.child_form Is Nothing Then CType(Me.oCFormController.child_form, IFormCommandRules).CommandQuery()

            Me.Activate()

            Me.DataGridView.Focus()

            ' Establece el formato de la barra de comandos.
            Call SetToolBarConfiguration(CApplication.ControlState.InitState)

            CommandQuery = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return CommandQuery

    End Function

    Protected Friend Overrides Function CommandSave() As Boolean

        Try
            With Me

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------

                If (CApplication.CheckRequiredFields(.tClaveId)) Then Me.FormRelatedClass.nombre_corto = .tClaveId.Text.Trim Else Throw New CustomException

                If (CApplication.CheckRequiredFields(.tNombre)) Then Me.FormRelatedClass.nombre = .tNombre.Text.Trim Else Throw New CustomException

                Me.FormRelatedClass = New CWorkCenter With {
                    .id = CApplicationController.oCWorkCenter_.id,
                    .guid = Me.tGuid.Text,
                    .nombre_corto = Me.tClaveId.Text,
                    .nombre = Me.tNombre.Text,
                    .descripcion = Me.tDescripcion.Text
                }

                If Me.form_state = CApplication.ControlState.Add Then

                    Me.FormRelatedClass.is_active = 1

                    If Not CWorkCenter.SaveRecord(Me) Then

                        Me.CommandCancel() : Throw New CustomException

                    Else

                        Me.oBindingSource.EndEdit()
                        ' Me.oBindingSource.ResetBindings(False)

                        Call CommandQuery()

                        Call SetToolBarConfiguration(CApplication.ControlState.InitState)

                    End If

                ElseIf Me.form_state = CApplication.ControlState.Edit Then

                    Me.FormRelatedClass.is_active = .ckActivo.Checked

                    If Not CWorkCenter.UpdateRecord(Me) Then

                        Me.CommandCancel() : Throw New CustomException

                    Else

                        Me.oBindingSource.EndEdit()
                        ' Me.oBindingSource.ResetBindings(False)

                        Dim set_current_row As Integer = Me.current_row

                        Call Me.CommandQuery()

                        Call Me.SetToolBarConfiguration(CApplication.ControlState.InitState)

                        If set_current_row >= 0 Then Me.DataGridView.Rows(set_current_row).Selected = True : Me.oBindingSource.Position = set_current_row

                    End If

                End If

            End With

            CommandSave = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return CommandSave

    End Function

    Dim SetControlsBindingOnNewAction As Action(Of Form) = AddressOf CWorkCenter.SetControlsBindingOnNew
    Protected Friend Overrides Function CommandAddNew() As Boolean

        CommandNew(SetControlsBindingOnNewAction)

        Return True

    End Function

End Class