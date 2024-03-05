Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Reflection

Public Class FAdministrationMenu
    Dim UsrLog As String  'el usuario actual logeado en el sistema
    Dim strNumeroPlanta As String

    Private Sub TSMCatalogoMateriales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMCatalogoMateriales.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FProductos")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSBRacks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("IDPProjectManagement.FRacks")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSBEquipos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("IDPProjectManagement.FMaquinaria")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSBUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub FamToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("IDPProjectManagement.FFamiliasProducto")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")


                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMTiposMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMTiposMaterial.Click


        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FTiposMaterial")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico del Sistema.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

                Dim dummy As Form
                dummy = DirectCast(oFormToShow, Form)
                dummy.WindowState = FormWindowState.Maximized

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

    Private Sub TSMRacks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMRacks.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FRacks")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMClasificaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMClasificaciones.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FProductosClasificacion")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMCentrosCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMCentrosCosto.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("IDPProjectManagement.FCentroCostos")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMMarcas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMMarcas.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("IDPProjectManagement.FMarcas")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMCelulas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMCelulas.Click


        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("IDPProjectManagement.FCelulas")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMEquipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMEquipo.Click



        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("IDPProjectManagement.FMaquinaria")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMMoldes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMMoldes.Click


        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("IDPProjectManagement.FMoldes")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMLíneasProducción_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMLíneasProducción.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("IDPProjectManagement.FLineasProduccion")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMAreasProduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMAreasProduccion.Click


        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FAreasProduccion")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMSeccionesProduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMVendors.Click


        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FSecciones")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMGruposRTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMGruposRTM.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FGruposRTM")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMOrdenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FOrdenesProduccion")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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


    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub

    Private Sub ConexiónSAPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click

        Me.Dispose()

    End Sub

    Private Sub NotificaciónMasivaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TSMCausasParo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMCausasParo.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FParoCausas")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMSubcausasParo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMSubcausasParo.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FParoSubcausas")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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


    Private Sub TurnosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMTurnos.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FTurnos")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub ProcesosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMProcesos.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FProcesos")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMUsuarios.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FUsuarios")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMPerfiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMPerfiles.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FPerfilesUsuario")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMPersonal.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FPersonal")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMPuestosPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMPuestosPersonal.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FPuestosPersonal")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub ToolStripMenuItem57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EfectosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TSMFormularios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMFormularios.Click

        Dim oFormToShow As Object = Nothing

        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FFormularios")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMNotificacionesProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMNotificacionesProducto.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FNotificacionesInyeccion")

        CApplicationController.tipo_notificacion = "T"

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer


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

    Private Sub NotificacionesScrapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotificacionesScrapToolStripMenuItem.Click


        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FNotificacionesInyeccion")


        CApplicationController.tipo_notificacion = "S"

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub OrdenesDeProducciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdenesDeProducciónToolStripMenuItem.Click



        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FOrdenesProduccion")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub ConfiguraciònToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciònToolStripMenuItem.Click

    End Sub

    Private Sub TSMEmbalajes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMEmbalajes.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FEmbalajes")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMUnidadesMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMUnidadesMedida.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FUnidadesMedida")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMCentros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMCentros.Click


        Dim oFormToShow As Object = Nothing

        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FCentrosTrabajo")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMScrap.Click

    End Sub

    Private Sub TSMAdministrarScrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMAdministrarScrap.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FScrap")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMSubcausasScrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMSubcausasScrap.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FScrapSubcausas")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TSMCausasScrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMCausasScrap.Click


        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FScrapCausas")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMTiposScrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMTiposScrap.Click


        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FScrapTipos")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMTiposAcceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMTiposAcceso.Click
        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco.FAppAccessTypes")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub FProductoTerminadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FProductoTerminado.Click

        ShowMeInMainContainer("FProductoTerminado")

    End Sub

    Private Sub ComponentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Componentes.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FComponentes")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                '  If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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


    Private Sub OrdenesDeProducciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdenesDeProducciónToolStripMenuItem1.Click

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FOrdenesProduccion")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub ReporteDeProducciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeProducciónToolStripMenuItem.Click



        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()


        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FNotificacionesProducto")


        CApplicationController.tipo_notificacion = "T"

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer


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

    Private Sub XToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oFormToShow As Object = Nothing
        Dim oMDIMainContainer As New MDIMainContainer()

        ' Retrieve form object from application into type.
        Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & ".FWeightCargo4")

        Try

            ' Create form instance from application from type.
            If oType IsNot Nothing Then

                '   If Not CApplicationController.oCUsers.oCollectionProfiles.Contains(oType.Name) Then Throw New CustomException("El usuario no tiene permisos suficientes. Consulte a Soporte Técnico.")

                oFormToShow = Activator.CreateInstance(oType)

                ' Assigns parent to form instance.
                oFormToShow.MdiParent = oMDIMainContainer

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

    Private Sub TSMSistema_Click(sender As System.Object, e As System.EventArgs) Handles TSMSistema.Click

    End Sub

    Private Sub TSMMateriales_Click(sender As System.Object, e As System.EventArgs) Handles TSMMateriales.Click

    End Sub


    Private Sub FProjects_Click(sender As Object, e As EventArgs)
        ShowMeInMainContainer(sender.Name)
    End Sub

    Private Sub FCentrosTrabajo_Click(sender As Object, e As EventArgs) Handles FCentrosTrabajo.Click
        ShowMeInMainContainer(sender.Name)
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
End Class