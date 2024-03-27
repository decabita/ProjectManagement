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
        ShowMeInMainContainer(sender.Name, 2)
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


    Private Sub FProjects_Click(sender As Object, e As EventArgs) Handles FProjects.Click

        ShowMeInMainContainer(sender.Name, CApplication.FormProcessType.Parent)

    End Sub

    Protected Friend Overridable Sub ShowMeInMainContainer(FormName As String, Optional ByVal FormProcessType As Integer = CApplication.FormProcessType.Catalog)

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Gets the type of the form selected in the menu button.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & "." & FormName)

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                '  If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                ' Create a form instance from the menu button clicked. FormProcessType indicates if the form is a catalog or a parent form.
                oFormToShow = Activator.CreateInstance(oType)
                oFormToShow.DisplayMode = FormProcessType

                ' MDIContainer Display.
                With oMDIMainContainer

                    ' Assigns parent to form instance.
                    oFormToShow.MdiParent = oMDIMainContainer

                    ' Assigns the form to be displayed by the MDI form.
                    .oCFormController_.parent_form = oFormToShow

                    ' Shows the Main Form Container 
                    .Show()

                End With

            Else

                Throw New CustomException("No se encuentra definido el formulario. Consulte a Soporte Técnico.")

            End If

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Sub ShowMeInMainContainerAsChild(oParentForm As Object, sChildForm As String, Optional ByVal FormProcessType As Integer = CApplication.FormProcessType.Catalog)

        Dim oFormToShow As Object = Nothing
        'Dim oMDIMainContainer As New MDIMainContainer()

        ' Gets the type of the form selected in the menu button.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & "." & sChildForm)

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                '  If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                ' Create a form instance from the child button clicked. FormProcessType indicates if the form is a catalog or a parent form or child form.
                oFormToShow = Activator.CreateInstance(oType)
                oFormToShow.DisplayMode = FormProcessType


                ' MDIContainer Display.
                With oFormToShow

                    .oCFormController = oParentForm.oCFormController
                    .MdiParent = oParentForm.ParentForm

                    oParentForm.oCFormController.child_form = oFormToShow

                    ' Shows the Main Form Container 
                    .Show()

                End With

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