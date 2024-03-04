Imports System.Reflection
Imports System.Windows.Forms

Public Class MDIMainContainer

    Private _oCFormController_ As New CFormController_
    Public Property oCFormController_() As CFormController_
        Get
            Return _oCFormController_
        End Get
        Set(ByVal value As CFormController_)
            _oCFormController_ = value
        End Set
    End Property

    Private Sub MDIMainContainer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.F1

            Case Keys.F2

                If Me.TSBDelete.Enabled Then Me.TSBDelete.PerformClick() : Exit Sub

            Case Keys.F3

                If Me.TSBExit.Enabled Then Me.TSBExit.PerformClick() : Exit Sub

            Case Keys.F5

                If Me.TSBNew.Enabled Then Me.TSBNew.PerformClick() : Exit Sub

            Case Keys.F6

                If Me.TSBEdit.Enabled Then Me.TSBEdit.PerformClick() : Exit Sub

            Case Keys.F7

                If Me.TSBQuery.Enabled Then Me.TSBQuery.PerformClick() : Exit Sub

            Case Keys.F8

                If Me.TSBSave.Enabled Then Me.TSBSave.PerformClick() : Exit Sub

            Case Keys.F9

                If Me.TSBDirectAccess.Enabled Then Me.TSBDirectAccess.PerformClick() : Exit Sub

            Case Keys.F12

                If Me.TSBCancel.Enabled Then Me.TSBCancel.PerformClick() : Exit Sub

        End Select

    End Sub


    Private Sub MDIMainContainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = CApplication.GetApplicationIcon

        Me.MDIWorkCenter.Text = CApplicationController.oCWorkCenter_.id
        Me.MDIUser.Text = CApplicationController.oCUsers.usuario_id



        Select Case CApplicationController.oCSystemParameters.environment_id

            Case "SYS_DEV"

                Me.MDIEnvironment.Text = "DESARROLLO"

            Case "SYS_PROD"

                Me.MDIEnvironment.Text = "PRODUCCION"

        End Select


        ' Set Command Bar Format.
        Me.TSBNew.Enabled = False
        Me.TSBSave.Enabled = False
        Me.TSBCancel.Enabled = False
        Me.TSBQuery.Enabled = False
        Me.TSBEdit.Enabled = False
        Me.TSBDelete.Enabled = False
        Me.TSBExit.Enabled = False

        ' Assigs form from menu.
        If Me.oCFormController_.parent_form.IsMdiChild Then
            With Me.oCFormController_.parent_form
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                .ControlBox = False
                .MaximizeBox = False
                .MinimizeBox = False
                .ShowIcon = False
                .Text = ""
                .Dock = DockStyle.Fill
                .Show()
            End With

        End If

        'Me.PnlMainFormContainer.Controls.Add(Me.oCFormController_.parent_form)
        '    Me.oCFormController_.parent_form.Show()
        'End If

    End Sub

    Private Sub TSBExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBExit.Click

        Me.Dispose()

    End Sub

    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click

        Call ShowToolBarSelection(sender)

    End Sub

    Private Sub TSBQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBQuery.Click

        Call ShowToolBarSelection(sender)

    End Sub

    Private Sub TSBEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBEdit.Click

        Call ShowToolBarSelection(sender)

    End Sub

    Private Sub TSBDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBDelete.Click

        Call ShowToolBarSelection(sender)

    End Sub

    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click

        Call ShowToolBarSelection(sender)

    End Sub

    Private Sub TSBCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBCancel.Click


        Call ShowToolBarSelection(sender)

    End Sub

    Private Sub TSBDirectAccess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBDirectAccess.Click

        Call ShowToolBarSelection(sender)

    End Sub

    Private Sub TSBExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call ShowToolBarSelection(sender)

    End Sub

    Private Sub ShowToolBarSelection(ByVal sender As System.Object)

        Try

            If Me.ActiveMdiChild Is Nothing Then Throw New CustomException("Seleccione un formulario.")

            Select Case sender.name

                Case "TSBNew"

                    DirectCast(Me.ActiveMdiChild, IFormCommandRules).CommandAddNew()

                Case "TSBCancel"

                    DirectCast(Me.ActiveMdiChild, IFormCommandRules).CommandCancel()

                Case "TSBSave"

                    DirectCast(Me.ActiveMdiChild, IFormCommandRules).CommandSave()

                Case "TSBDelete"

                    DirectCast(Me.ActiveMdiChild, IFormCommandRules).CommandDelete()

                Case "TSBEdit"

                    DirectCast(Me.ActiveMdiChild, IFormCommandRules).CommandEdit()

                Case "TSBQuery"

                    DirectCast(Me.ActiveMdiChild, IFormCommandRules).CommandQuery()

                Case "TSBExportToExcel"

'                    If Me.ActiveMdiChild.Name.Equals("FEmbalajes") Or Me.ActiveMdiChild.Name.Equals("FUnidadesMedida") Or _
'Me.ActiveMdiChild.Name.Equals("FFormularios") Or Me.ActiveMdiChild.Name.Equals("FCentrosTrabajo") Or _
'Me.ActiveMdiChild.Name.Equals("FScrap") Or Me.ActiveMdiChild.Name.Equals("FScrapSubcausas") Or _
'Me.ActiveMdiChild.Name.Equals("FScrapCausas") Or Me.ActiveMdiChild.Name.Equals("FAlmacenes") Or _
'Me.ActiveMdiChild.Name.Equals("FAreasProduccion") Or Me.ActiveMdiChild.Name.Equals("FCentroCostos") Or _
'Me.ActiveMdiChild.Name.Equals("FGruposRTM") Or Me.ActiveMdiChild.Name.Equals("FCelulas") Or _
'Me.ActiveMdiChild.Name.Equals("FOrdenesProduccion") Or Me.ActiveMdiChild.Name.Equals("FCelulaMaquinariaChild") Or _
'Me.ActiveMdiChild.Name.Equals("FScrapRelacionChild") Or Me.ActiveMdiChild.Name.Equals("FMoldes") Or _
'Me.ActiveMdiChild.Name.Equals("FMaquinaria") Or Me.ActiveMdiChild.Name.Equals("FMaquinariaMoldeChild") Or _
'Me.ActiveMdiChild.Name.Equals("FMoldesCavidadesChild") Or Me.ActiveMdiChild.Name.Equals("FPerfilesUsuario") Or _
'Me.ActiveMdiChild.Name.Equals("FPerfilUsuarioChild") Or Me.ActiveMdiChild.Name.Equals("FPerfilFormaChild") Or _
'Me.ActiveMdiChild.Name.Equals("FAppAccessTypes") Or Me.ActiveMdiChild.Name.Equals("FPersonal") Or _
'Me.ActiveMdiChild.Name.Equals("FPersonalChild") Or Me.ActiveMdiChild.Name.Equals("FParoCausas") Or _
'Me.ActiveMdiChild.Name.Equals("FSubcausasParoChild") Or Me.ActiveMdiChild.Name.Equals("FParoSubcausas") Or _
'Me.ActiveMdiChild.Name.Equals("FUsuarios") Or Me.ActiveMdiChild.Name.Equals("FProductionReportChild") Or _
'Me.ActiveMdiChild.Name.Equals("FProductionReportDetailChild") Or Me.ActiveMdiChild.Name.Equals("FProductionReportBomChild") Or _
'Me.ActiveMdiChild.Name.Equals("FProductionReportBatchChild") Or Me.ActiveMdiChild.Name.Equals("FRacks") Or _
'Me.ActiveMdiChild.Name.Equals("FPuestosPersonal") Or Me.ActiveMdiChild.Name.Equals("FTiposMaterial") Or _
'Me.ActiveMdiChild.Name.Equals("FMarcas") Or Me.ActiveMdiChild.Name.Equals("FProcesos") Or _
'Me.ActiveMdiChild.Name.Equals("FProductoTerminado") Or Me.ActiveMdiChild.Name.Equals("FLineasProduccion") Or _
'Me.ActiveMdiChild.Name.Equals("FBomChild") Or Me.ActiveMdiChild.Name.Equals("FEspecificacionesChild") Or _
'Me.ActiveMdiChild.Name.Equals("FEspecificacionAdicionalChild") Or Me.ActiveMdiChild.Name.Equals("FComponentes") Then

'                        DirectCast(Me.oCFormController_.parent_form, IFormCommandRules).CommandSendToExcel()

'                    Else

'                        DirectCast(Me.oCFormController_.parent_form, IBaseLayout).CommandSendToExcel()

'                    End If

                Case "TSBDirectAccess"

                    If Me.ActiveMdiChild.Name.Equals("FEmbalajes") Or Me.ActiveMdiChild.Name.Equals("FUnidadesMedida") Or
Me.ActiveMdiChild.Name.Equals("FFormularios") Or Me.ActiveMdiChild.Name.Equals("FCentrosTrabajo") Or
Me.ActiveMdiChild.Name.Equals("FScrap") Or Me.ActiveMdiChild.Name.Equals("FScrapSubcausas") Or
Me.ActiveMdiChild.Name.Equals("FScrapCausas") Or Me.ActiveMdiChild.Name.Equals("FAlmacenes") Or
Me.ActiveMdiChild.Name.Equals("FAreasProduccion") Or Me.ActiveMdiChild.Name.Equals("FCentroCostos") Or
Me.ActiveMdiChild.Name.Equals("FGruposRTM") Or Me.ActiveMdiChild.Name.Equals("FCelulas") Or
Me.ActiveMdiChild.Name.Equals("FOrdenesProduccion") Or Me.ActiveMdiChild.Name.Equals("FCelulaMaquinariaChild") Or
Me.ActiveMdiChild.Name.Equals("FScrapRelacionChild") Or Me.ActiveMdiChild.Name.Equals("FMoldes") Or
Me.ActiveMdiChild.Name.Equals("FMaquinaria") Or Me.ActiveMdiChild.Name.Equals("FMaquinariaMoldeChild") Or
Me.ActiveMdiChild.Name.Equals("FMoldesCavidadesChild") Or Me.ActiveMdiChild.Name.Equals("FPerfilesUsuario") Or
Me.ActiveMdiChild.Name.Equals("FPerfilUsuarioChild") Or Me.ActiveMdiChild.Name.Equals("FPerfilFormaChild") Or
Me.ActiveMdiChild.Name.Equals("FAppAccessTypes") Or Me.ActiveMdiChild.Name.Equals("FPersonal") Or
Me.ActiveMdiChild.Name.Equals("FPersonalChild") Or Me.ActiveMdiChild.Name.Equals("FParoCausas") Or
Me.ActiveMdiChild.Name.Equals("FSubcausasParoChild") Or Me.ActiveMdiChild.Name.Equals("FParoSubcausas") Or
Me.ActiveMdiChild.Name.Equals("FUsuarios") Or Me.ActiveMdiChild.Name.Equals("FProductionReportChild") Or
Me.ActiveMdiChild.Name.Equals("FProductionReportDetailChild") Or Me.ActiveMdiChild.Name.Equals("FProductionReportBomChild") Or
Me.ActiveMdiChild.Name.Equals("FProductionReportBatchChild") Or Me.ActiveMdiChild.Name.Equals("FRacks") Or
Me.ActiveMdiChild.Name.Equals("FPuestosPersonal") Or Me.ActiveMdiChild.Name.Equals("FTiposMaterial") Or
Me.ActiveMdiChild.Name.Equals("FMarcas") Or Me.ActiveMdiChild.Name.Equals("FProcesos") Or
Me.ActiveMdiChild.Name.Equals("FProductoTerminado") Or Me.ActiveMdiChild.Name.Equals("FLineasProduccion") Or
Me.ActiveMdiChild.Name.Equals("FBomChild") Or Me.ActiveMdiChild.Name.Equals("FEspecificacionesChild") Or
Me.ActiveMdiChild.Name.Equals("FEspecificacionAdicionalChild") Or Me.ActiveMdiChild.Name.Equals("FComponentes") Then

                        DirectCast(Me.ActiveMdiChild, IFormCommandRules).CommandDirectAccess()
                    Else

                        ' DirectCast(Me.ActiveMdiChild, IToolBoxCommand).CommandCancel()
                    End If

                Case "TSBFind"

                    If Me.ActiveMdiChild.Name.Equals("FEmbalajes") Or Me.ActiveMdiChild.Name.Equals("FPersonal") Or
Me.ActiveMdiChild.Name.Equals("FProductoTerminado") Or Me.ActiveMdiChild.Name.Equals("FOrdenesProduccion") Or
 Me.ActiveMdiChild.Name.Equals("FAlmacenes") Or Me.ActiveMdiChild.Name.Equals("FAreasProduccion") Or
 Me.ActiveMdiChild.Name.Equals("FCelulas") Or Me.ActiveMdiChild.Name.Equals("FCentroCostos") Or
 Me.ActiveMdiChild.Name.Equals("FCentrosTrabajo") Or Me.ActiveMdiChild.Name.Equals("FGruposRTM") Or
 Me.ActiveMdiChild.Name.Equals("FMaquinaria") Or Me.ActiveMdiChild.Name.Equals("FMarcas") Or
 Me.ActiveMdiChild.Name.Equals("FMoldes") Or Me.ActiveMdiChild.Name.Equals("FParoCausas") Or
 Me.ActiveMdiChild.Name.Equals("FParoSubcausas") Or Me.ActiveMdiChild.Name.Equals("FPersonal") Or
 Me.ActiveMdiChild.Name.Equals("FProcesos") Or Me.ActiveMdiChild.Name.Equals("FPuestosPersonal") Or
 Me.ActiveMdiChild.Name.Equals("FRacks") Or Me.ActiveMdiChild.Name.Equals("FScrap") Or
 Me.ActiveMdiChild.Name.Equals("FScrapCausas") Or Me.ActiveMdiChild.Name.Equals("FScrapSubcausas") Or
 Me.ActiveMdiChild.Name.Equals("FTiposMaterial") Or Me.ActiveMdiChild.Name.Equals("FUnidadesMedida") Then


                        DirectCast(Me.ActiveMdiChild, IFormCommandRules).CommandFind()

                    End If

                Case "TSBExecFind"

                    If Me.ActiveMdiChild.Name.Equals("FEmbalajes") Or Me.ActiveMdiChild.Name.Equals("FPersonal") Or
 Me.ActiveMdiChild.Name.Equals("FProductoTerminado") Or Me.ActiveMdiChild.Name.Equals("FOrdenesProduccion") Or
 Me.ActiveMdiChild.Name.Equals("FAlmacenes") Or Me.ActiveMdiChild.Name.Equals("FAreasProduccion") Or
 Me.ActiveMdiChild.Name.Equals("FCelulas") Or Me.ActiveMdiChild.Name.Equals("FCentroCostos") Or
 Me.ActiveMdiChild.Name.Equals("FCentrosTrabajo") Or Me.ActiveMdiChild.Name.Equals("FGruposRTM") Or
 Me.ActiveMdiChild.Name.Equals("FMaquinaria") Or Me.ActiveMdiChild.Name.Equals("FMarcas") Or
 Me.ActiveMdiChild.Name.Equals("FMoldes") Or Me.ActiveMdiChild.Name.Equals("FParoCausas") Or
 Me.ActiveMdiChild.Name.Equals("FParoSubcausas") Or Me.ActiveMdiChild.Name.Equals("FPersonal") Or
 Me.ActiveMdiChild.Name.Equals("FProcesos") Or Me.ActiveMdiChild.Name.Equals("FPuestosPersonal") Or
 Me.ActiveMdiChild.Name.Equals("FRacks") Or Me.ActiveMdiChild.Name.Equals("FScrap") Or
 Me.ActiveMdiChild.Name.Equals("FScrapCausas") Or Me.ActiveMdiChild.Name.Equals("FScrapSubcausas") Or
 Me.ActiveMdiChild.Name.Equals("FTiposMaterial") Or Me.ActiveMdiChild.Name.Equals("FUnidadesMedida") Then


                        DirectCast(Me.ActiveMdiChild, IFormCommandRules).CommandQueryFind()

                    End If

            End Select

        Catch ex As InvalidCastException

            MessageBox.Show("El formulario no está habilitado para el comando seleccionado. Informe a Soporte Técnico de Gears.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub


    Private Sub MDIMainContainer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Me.Dispose()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub MDIMenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub AcercaDeAtlasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oAboutBox As New AboutBox

        oAboutBox.StartPosition = FormStartPosition.CenterScreen
        oAboutBox.ShowDialog()

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True

    End Sub

    Private Sub TSBBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call ShowToolBarSelection(sender)

    End Sub

    Private Sub TSBExecFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call ShowToolBarSelection(sender)

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub TSBExportToExcel_Click_1(sender As Object, e As EventArgs) Handles TSBExportToExcel.Click

    End Sub
End Class