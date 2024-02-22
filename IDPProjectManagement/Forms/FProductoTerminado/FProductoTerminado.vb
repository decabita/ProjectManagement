Public Class FProductoTerminado

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub BWorkerGetData_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWorkerGetData.DoWork

        Try

            ' Executes Query.
            e.Result = QueryAll()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BWorkerGetData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWorkerGetData.RunWorkerCompleted

        Try

            If Not CBool(CInt(Me.oBindingSource.Count)) Then Throw New CustomException

            Call SetControlsBinding()

            ' Establece formato de los controles.
            Call SetGridPropertiesFormat()

            Call SetControlPropertiesFormat()

            ' Establece el formato de la barra de comandos.
            Call SetToolBarConfiguration(CApplication.ControlState.InitState)


        Catch ex As CustomException

            Call SetToolBarConfiguration(CApplication.ControlState.None)

        Finally

            oFProgress.Dispose()
            BWorkerGetData.Dispose()

        End Try

    End Sub

    Private Sub cbClasificacion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.DroppedDown = True
    End Sub

    Private Sub cbClasificacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.DroppedDown = False
    End Sub

    Private Sub cbProcesos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.DroppedDown = True
    End Sub

    Private Sub cbProcesos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.DroppedDown = False
    End Sub

    Private Sub cbTipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.DroppedDown = True
    End Sub

    Private Sub cbTipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.DroppedDown = False
    End Sub

    Private Sub cbUnidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUnidad.GotFocus
        sender.DroppedDown = True
    End Sub

    Private Sub cbUnidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUnidad.LostFocus
        sender.DroppedDown = False
    End Sub

    Private Sub cbUnidadParent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbUnidad.SelectedIndexChanged

    End Sub

    Private Sub DataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView.DataError
        Dim ex As Exception = e.Exception
    End Sub

    Private Sub DataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.RowEnter

        If Not CBool(CInt(Me.oBindingSource.Count)) Then Exit Sub

        If DataGridView.Rows(e.RowIndex) IsNot Nothing Then Me.current_row = e.RowIndex

    End Sub

    Private Sub FProductos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.oCFormController.active_form = Me

        ' TODO REPORTS
        DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.parent_form = Me
        ' --------------------------------------------------------------------------

        DirectCast(Me.ParentForm, MDIMainContainer).MDICurrentForm.Text = Me.Text
        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormStateDescription(Me.form_state)

        ' Establece el formato de la barra de comandos.
        Call Me.SetToolBarConfiguration(Me.form_state)

    End Sub

    Private Sub FProductos_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate

        If Not Me.form_state = CApplication.ControlState.InitState Then Call CommandCancel()

    End Sub

    Private Sub FProductos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        ' TODO REPORTS
        DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.parent_form = Nothing
        ' --------------------------------------------------------------------------

        Me.oCFormController.parent_form = Nothing
        DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.PerformClick()

    End Sub

    Private Sub FProductos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call CApplication.SetCultureSettings()

        '   TODO REPORTS
        '       Call Me.CommandQuery()

        Call Me.CommandFind()

        Call Me.SetGeneralFormat()

    End Sub

    Private Sub TSBAdicionales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBAdicionales.Click

        Dim oFEspecificacionAdicionalChild As FEspecificacionAdicionalChild

        Try

            If Not Me.oCFormController.child_form Is Nothing Then Throw New CustomException("El formulario ya está abierto.")

            ' ----------------------------------------------------------
            ' Create Child Form
            ' ----------------------------------------------------------
            oFEspecificacionAdicionalChild = New FEspecificacionAdicionalChild

            With oFEspecificacionAdicionalChild

                ' TODO REPORTS
                Me.data_relation_name = oFEspecificacionAdicionalChild.data_relation_name

                .oCFormController = Me.oCFormController
                .MdiParent = Me.ParentForm
                .Show()

            End With

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            Me.oCFormController.child_form = Nothing
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub TSBBom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBBom.Click

        Dim oFBomChild As FBomChild

        Try

            If Not Me.oCFormController.child_form Is Nothing Then Throw New CustomException("El formulario ya está abierto.")

            '   If Not (Me.DataGridView.CurrentRow.Cells("tipo_id").Value.Equals("PT") Or _
            '  Me.DataGridView.CurrentRow.Cells("tipo_id").Value.Equals("COM")) Then Throw New CustomException("Solo se puede especificar la lista a los productos terminados y compuestos.")

            ' ----------------------------------------------------------
            ' Create Child Form
            ' ----------------------------------------------------------
            oFBomChild = New FBomChild

            With oFBomChild

                ' TODO REPORTS
                Me.data_relation_name = oFBomChild.data_relation_name

                .oCFormController = Me.oCFormController
                .MdiParent = Me.ParentForm
                .Show()

            End With

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            Me.oCFormController.child_form = Nothing
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub TSBEspecificaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBEspecificaciones.Click

        Dim oFEspecificacionesChild As FEspecificacionesChild

        Try

            If Not Me.oCFormController.child_form Is Nothing Then Throw New CustomException("El formulario ya está abierto.")

            ' ----------------------------------------------------------
            ' Create Child Form
            ' ----------------------------------------------------------

            oFEspecificacionesChild = New FEspecificacionesChild

            With oFEspecificacionesChild
                ' TODO REPORTS
                Me.data_relation_name = oFEspecificacionesChild.data_relation_name

                .oCFormController = Me.oCFormController
                .MdiParent = Me.ParentForm
                .Show()

            End With

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            Me.oCFormController.child_form = Nothing
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub DataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellContentClick

    End Sub

    Private Sub tCodigoBarras_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tCodigoBarras.KeyPress

        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        If tmp.KeyChar = ChrW(Keys.Enter) Then
            'MessageBox.Show("Enter key")
            Me.tClaveId.Focus()

        End If


    End Sub

    Private Sub tCodigoBarras_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles tCodigoBarras.PreviewKeyDown

     

    End Sub

  
    Private Sub tCodigoBarras_TextChanged(sender As System.Object, e As System.EventArgs) Handles tCodigoBarras.TextChanged

    End Sub

    Private Sub cbTipoMaterial_GotFocus(sender As Object, e As System.EventArgs) Handles cbTipoMaterial.GotFocus
        sender.DroppedDown = True
    End Sub

    Private Sub cbTipoMaterial_LostFocus(sender As Object, e As System.EventArgs) Handles cbTipoMaterial.LostFocus
        sender.DroppedDown = False
    End Sub

    Private Sub cbTipoMaterial_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbTipoMaterial.SelectedIndexChanged

    End Sub
End Class