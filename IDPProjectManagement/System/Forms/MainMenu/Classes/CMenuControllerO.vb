Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Reflection

Public Class CMenuControllerOC
    Implements IMenu

    'Shared oLevelCollection As New Collection()
    'Public Shared oLevelCollection As New Collection()

    Private _oLevelCollection As Collection
    Public Property oLevelCollection() As Collection Implements IMenu.oLevelCollection
        Get
            Return _oLevelCollection
        End Get
        Set(ByVal value As Collection)
            _oLevelCollection = value
        End Set
    End Property



    Sub MenuButtonClick(ByVal sender As Object, ByVal e As EventArgs) Implements IMenu.MenuButtonClick

        For Each oLevel In oLevelCollection

            For Each oMenu In oLevel.oMenuCollection

                If Not oMenu.is_root And sender.next_level_id > 0 Then

                    ' Si se oprime el mismo botón.
                    If Not oLevelCollection.Item(sender.level_id).oMenuCollection.Item(sender.menu_id).Equals(oMenu) _
                    And oMenu.visible And oMenu.level_id >= sender.next_level_id Then

                        oMenu.visible = False



                    ElseIf oLevelCollection.Item(sender.next_level_id).oMenuCollection.Item(sender.next_menu_id).Equals(oMenu) _
                    And Not oMenu.visible Then

                        Select Case sender.object_type_id

                            Case 0 '"MENU"

                                Dim pMenuLocation As Point

                                pMenuLocation = sender.location + sender.parent.location + New Point(sender.width - 20, sender.height / 2)

                                With oLevelCollection.Item(sender.next_level_id).oMenuCollection.Item(sender.next_menu_id)
                                    .Location = pMenuLocation
                                    .bringtofront()
                                    .visible = True
                                End With


                        End Select




                    End If

                ElseIf sender.next_level_id = 0 And Not sender.object_id.ToString.Equals("0") Then

                    Select Case sender.object_type_id

                        Case 1 '"FORM"


                            ' CApplicationController.application_environment = "PROD"
                            '  CApplication.oUsers.usuario_id = "ADMINI"
                            CApplicationController.oCWorkCenter_.id = 1

                            Call CApplication.SetCultureSettings()


                            Dim oRetForm As Object = Nothing

                            Dim oMDIMainContainer As New MDIMainContainer()

                            Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco." & sender.object_id)

                            If oType IsNot Nothing Then oRetForm = Activator.CreateInstance(oType)

                            oRetForm.MdiParent = oMDIMainContainer
                            oMDIMainContainer.WindowState = FormWindowState.Maximized
                            oMDIMainContainer.Show()


                            'Dim oFormController As CFormController
                            'oFormController = New CFormController

                            'oFormController.form_name = sender.object_id

                            'If Not oFormController.form_name Is vis Then MessageBox.Show("El formulario ya está abierto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                            'oFormController.ShowLinkedObject()

                            Exit Sub

                    End Select



                End If
            Next

        Next



    End Sub

End Class
