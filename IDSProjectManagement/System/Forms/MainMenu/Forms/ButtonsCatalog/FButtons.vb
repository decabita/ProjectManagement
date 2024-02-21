﻿Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class FButtons

    Private Sub FButtons_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate

        If Not Me.form_state = CApplication.ControlState.InitState Then Call CommandCancel()

    End Sub

    Private Sub FButtons_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ''Application.DoEvents()

        Call CApplication.SetCultureSettings()

        Call CommandQuery()

        'CFormController.parent_form = Me
        'DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.parent_form = Me

        Call CApplication.SetFormFormat(Me)

        AddHandler Me.tButtonId.GotFocus, AddressOf CApplication.HandleGotFocus
        AddHandler Me.tButtonId.LostFocus, AddressOf CApplication.HandleLostFocus

        AddHandler Me.tNombre.GotFocus, AddressOf CApplication.HandleGotFocus
        AddHandler Me.tNombre.LostFocus, AddressOf CApplication.HandleLostFocus

        AddHandler Me.tDescripcion.GotFocus, AddressOf CApplication.HandleGotFocus
        AddHandler Me.tDescripcion.LostFocus, AddressOf CApplication.HandleLostFocus

    End Sub

    Private Sub FButtons_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.oFormController.active_form = Me

        DirectCast(Me.ParentForm, MDIMainContainer).MDICurrentForm.Text = Me.Text
        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormStateDescription(Me.form_state)

        ' Establece el formato de la barra de comandos.
        Call SetToolBarConfiguration(Me.form_state)

    End Sub

    Private Sub DataGridView_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView.CellBeginEdit

        If Not Me.view_mode.Equals(CApplication.ViewMode.Multiview) Then Exit Sub

        ' Establece el formato de la barra de comandos.
        Call SetToolBarConfiguration(CApplication.ControlState.Edit)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString())
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub BWorkerGetProducts_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWorkerGetProducts.DoWork

        Try

            ' Executes Query.
            e.Result = QueryAll()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BWorkerGetProducts_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWorkerGetProducts.RunWorkerCompleted

        Try

            If Not CBool(CInt(Me.oBindingSourceParent.Count)) Then Throw New CustomException

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
            BWorkerGetProducts.Dispose()

        End Try


    End Sub

    Private Sub FButtons_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Me.oFormController.parent_form = Nothing
        DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.PerformClick()

    End Sub

    Private Sub TSBEspecificaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim oFEspecificacionesChild As FEspecificacionesChild

        'Try

        '    If Not Me.oFormController.child_form Is Nothing Then Throw New CustomException("El formulario ya está abierto.")

        '    ' ----------------------------------------------------------
        '    ' Create Child Form
        '    ' ----------------------------------------------------------

        '    Me.SuspendLayout()

        '    oFEspecificacionesChild = New FEspecificacionesChild

        '    With oFEspecificacionesChild
        '        .oCFormController = Me.oFormController
        '        .MdiParent = Me.ParentForm
        '        .Show()
        '        ' .Location = New Point(Me.Left, Me.Top + Me.Height)

        '    End With

        '    Me.ResumeLayout()

        'Catch ex As CustomException

        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Catch ex As Exception

        '    Me.oFormController.child_form = Nothing
        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try

    End Sub

    Private Sub cbTipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMenu.GotFocus
        sender.DroppedDown = True
    End Sub

    Private Sub cbTipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMenu.LostFocus
        sender.DroppedDown = False
    End Sub

    Private Sub cbUnidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.DroppedDown = True
    End Sub

    Private Sub cbUnidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.DroppedDown = False
    End Sub


  

    Private Sub DataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellContentClick

    End Sub
End Class