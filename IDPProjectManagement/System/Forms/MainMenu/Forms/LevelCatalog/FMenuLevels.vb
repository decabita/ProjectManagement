﻿Imports System.Data.SqlClient
'Imports Excel = Microsoft.Office.Interop.Excel

Public Class FMenuLevels

   Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub BWorkerGetProducts_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWorkerGetData.DoWork

        Try

            ' Executes Query.
            e.Result = QueryAll()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BWorkerGetProducts_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWorkerGetData.RunWorkerCompleted

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

    Private Sub FMenuLevels_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

         Me.oFormController.active_form = Me

        DirectCast(Me.ParentForm, MDIMainContainer).MDICurrentForm.Text = Me.Text
        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormStateDescription(Me.form_state)

        ' Establece el formato de la barra de comandos.
        Call SetToolBarConfiguration(Me.form_state)

    End Sub

    Private Sub FMenuLevels_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate

        If Not Me.form_state = CApplication.ControlState.InitState Then Call CommandCancel()

    End Sub

    Private Sub FMenuLevels_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed


        Me.oFormController.parent_form = Nothing

        DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.PerformClick()

    End Sub

    Private Sub FMenuLevels_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call CApplication.SetCultureSettings()

        Call Me.CommandQuery()

        Call Me.SetGeneralFormat()

    End Sub

    Private Sub LowerComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LowerComponentes.Click

        Exit Sub
        'Dim xlApp As Excel.Application
        'Dim xlWorkBook As Excel.Workbook
        'Dim xlWorkSheet As Excel.Worksheet
        'Dim misValue As Object = System.Reflection.Missing.Value
        'Dim fileName As String

        'Dim i As Int16, j As Int16


        'Try

        '    xlApp = New Excel.Application
        '    xlWorkBook = xlApp.Workbooks.Add(misValue)
        '    xlWorkSheet = xlWorkBook.Sheets(1)


        '    For i = 0 To DataGridView.RowCount - 2
        '        For j = 0 To DataGridView.ColumnCount - 1
        '            xlWorkSheet.Cells(i + 1, j + 1) = DataGridView(j, i).Value.ToString()
        '        Next
        '    Next

        '    fileName = "c:\vb.net-informations " & DateTime.Today.ToString & ".xls"


        '    xlWorkBook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, _
        '     Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
        '    xlWorkBook.Close(True, misValue, misValue)
        '    xlApp.Quit()

        '    releaseObject(xlWorkSheet)
        '    releaseObject(xlWorkBook)
        '    releaseObject(xlApp)

        '    MessageBox.Show("Over")

        'Catch ex As Exception

        '    MessageBox.Show(ex.Message)

        'End Try

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

    Private Sub TSBMenus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBMenus.Click

        Exit Sub

        'Dim oFBomChild As FBomChild

        'Try

        '    If Not Me.oFormController.child_form Is Nothing Then Throw New CustomException("El formulario ya está abierto.")

        '    If Not Me.DataGridView.CurrentRow.Cells("tipo_id").Value.Equals("PT") Then Throw New CustomException("Solo se puede especificar la lista a los productos terminados.")

        '    ' ----------------------------------------------------------
        '    ' Create Child Form
        '    ' ----------------------------------------------------------
        '    Me.SuspendLayout()

        '    oFBomChild = New FBomChild

        '    With oFBomChild

        '        .oCFormController = Me.oFormController
        '        .MdiParent = Me.ParentForm
        '        .Show()

        '    End With

        '    Me.ResumeLayout()

        'Catch ex As CustomException

        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Catch ex As Exception

        '    Me.oFormController.child_form = Nothing
        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try

    End Sub

    Private Sub DataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellContentClick

    End Sub

    Private Sub DataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.RowEnter

        If Not CBool(CInt(Me.oBindingSource.Count)) Then Exit Sub

        If DataGridView.Rows(e.RowIndex) IsNot Nothing Then Me.current_row = e.RowIndex

    End Sub
End Class