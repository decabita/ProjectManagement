Imports System.Data.SqlClient

Public Class FClientes

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub BWorkerGetProducts_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWorkerGetData.DoWork

        Try

            ' Ejecuta la consulta.
            'e.Result = QueryAll()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BWorkerGetProducts_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWorkerGetData.RunWorkerCompleted

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
            BWorkerGetData.Dispose()

        End Try

    End Sub

    Private Sub FUsuarios_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.oFormController.active_form = Me

        DirectCast(Me.ParentForm, MDIMainContainer).MDICurrentForm.Text = Me.Text
        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormState(Me.form_state)

        ' Establece el formato de la barra de comandos.
        Call SetToolBarConfiguration(Me.form_state)

    End Sub

    Private Sub FUsuarios_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate

        If Not Me.form_state = CApplication.ControlState.InitState Then Call CommandCancel()

    End Sub

    Private Sub FUsuarios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Me.oFormController.parent_form = Nothing
        DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.PerformClick()

    End Sub

    Private Sub FUsuarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ''Application.DoEvents()

        Call CApplication.SetCultureSettings()

        Call CommandQuery()

        Call Me.SetGeneralFormat()

    End Sub

    Private Sub LowerComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Exit Sub



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


    Private Sub TSBBom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub TSBPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            ' ----------------------------------------------------------
            ' Create Child Form
            ' ----------------------------------------------------------



        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            Me.oFormController.child_form = Nothing
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub ExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Call FReportingExcel.SendToExcelService(Me.DataGridView, Me.Text)

    End Sub
End Class