Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Reflection

Public Class FAdministrationMenu

    Private Sub FMainMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Creates Menu Object.
        Dim oMenuController_ As New CMenuController_

        Me.Icon = CApplication.GetApplicationIcon()
        ' ---------------------------------------------------
        ' TODO TAKE OUT MENU 
        ' Menu Object Init.
        '
        '   oMenuController_.init() - Esta es al linea original

        ' CApplicationController.oCMenuController_.init()
        ' ---------------------------------------------------

        ' Show Menu Main Window
        Me.WindowState = FormWindowState.Maximized

        '    Me.MDIWorkCenter.Text = CApplicationController.oCWorkCenter_.centro_id
        '   Me.MDIUser.Text = CApplicationController.oCUsers.usuario_id

        '  Select Case CApplicationController.oCSystemParameters.environment_id

        '    Case "SYS_DEV"
        ' Me.MDIEnvironment.Text = "DESARROLLO"

        '    Case "SYS_PROD"

        '  Me.MDIEnvironment.Text = "PRODUCCION"

        '  End Select



        'CApplicationController.application_environment()
        'Me.Show()

        ' --------------------------------------------------------------
        ' Implements their 'standart' menu. :)
        ' --------------------------------------------------------------
        '   Dim oCDynamicMenu As New CDynamicMenu()
        '  oCDynamicMenu.objForm = Me
        ' Me.Menu = oCDynamicMenu.LoadDynamicMenu()



    End Sub
    Private Sub FClientes_Click(sender As Object, e As EventArgs) Handles FClientes.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FCustomerAreas_Click(sender As Object, e As EventArgs) Handles FCustomerAreas.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FVendors_Click(sender As Object, e As EventArgs) Handles FVendors.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FWarehouses_Click(sender As Object, e As EventArgs) Handles FWarehouses.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FParts_Click(sender As Object, e As EventArgs) Handles FParts.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FWorkCenters_Click(sender As Object, e As EventArgs) Handles FWorkCenters.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FServicesProvided_Click(sender As Object, e As EventArgs) Handles FServicesProvided.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FProspects_Click(sender As Object, e As EventArgs) Handles FProspects.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FPositions_Click(sender As Object, e As EventArgs) Handles FPositions.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FActivities_Click(sender As Object, e As EventArgs)
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FMeasurements_Click(sender As Object, e As EventArgs) Handles FMeasurements.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FMachinery_Click(sender As Object, e As EventArgs) Handles FMachinery.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FPersons_Click(sender As Object, e As EventArgs) Handles FPersons.Click
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FBrands_Click(sender As Object, e As EventArgs) Handles FBrands.Click
        ShowMeInMainContainer(sender.Name)
    End Sub
End Class