Imports System.Data.SqlClient

Public Class FClientes

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub FClientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call CApplication.SetCultureSettings()

        Call CommandFind()

        Call Me.CommandQuery()

        Call Me.SetGeneralFormat()

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

            If Me.oBindingSource.Count <= 0 Then Throw New CustomException

            Call Me.SetControlsBinding()

            ' Establece formato de los controles.
            Call Me.SetGridPropertiesFormat()

            Call Me.SetControlPropertiesFormat()

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

    Private Sub FClientes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.oCFormController.active_form = Me

        ' TODO REPORTS
        DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.parent_form = Me
        ' --------------------------------------------------------------------------

        DirectCast(Me.ParentForm, MDIMainContainer).MDICurrentForm.Text = Me.Text
        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormStateDescription(Me.form_state)

        ' Establece el formato de la barra de comandos.
        Call Me.SetToolBarConfiguration(Me.form_state)

    End Sub

    Private Sub FClientes_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate

        If Not Me.form_state = CApplication.ControlState.InitState Then Call CommandCancel()

    End Sub
    Private Sub FClientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        ' TODO REPORTS
        DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.parent_form = Nothing
        ' --------------------------------------------------------------------------

        Me.oCFormController.parent_form = Nothing
        DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.PerformClick()

    End Sub

    Private Sub DataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellContentClick

    End Sub
End Class