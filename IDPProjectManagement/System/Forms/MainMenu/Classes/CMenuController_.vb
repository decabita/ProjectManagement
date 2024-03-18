Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Reflection

Public Class CMenuController_
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

        Dim counter, counter2 As Integer

        For Each oLevel In oLevelCollection


            counter = counter + 1

            For Each oMenu In oLevel.oMenuCollection

                counter2 = counter2 + 1

                If Not CBool(oMenu.is_root) And sender.next_level_id > 0 Then

                    ' Si se oprime el mismo botón.
                    If Not oLevelCollection.Item(sender.level_id).oMenuCollection.Item(sender.menu_id).Equals(oMenu) _
                    And oMenu.visible And oMenu.level_id >= sender.next_level_id Then

                        oMenu.visible = False

                        'DirectCast(sender, Button).ForeColor = SystemColors.ControlText

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

                                ' DirectCast(sender, Button).ForeColor = Color.DarkRed

                                'Exit Sub
                        End Select




                    End If

                ElseIf sender.next_level_id = 0 And Not sender.object_id.ToString.Equals("0") Then

                    Select Case sender.object_type_id

                        Case 1 '"FORM"

                            'CApplicationController.application_environment = "PROD"
                            'CApplication.oUsers.usuario_id = "ADMINI"
                            'CApplicationController.oCWorkCenter_.centro_id = "CO02"

                            ' Call CApplication.SetCultureSettings()

                            Dim oFormToShow As Object = Nothing
                            Dim oMDIMainContainer As New MDIMainContainer(oFormToShow)

                            ' Retrieve form object from application into type.
                            Dim oType As Type = Assembly.GetExecutingAssembly().GetType("IDPProjectManagement." & sender.object_id)


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

                                MessageBox.Show("No se encuentra definido el formulario. Consulte a Soporte Técnico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            End If

                            Exit Sub

                    End Select



                End If
            Next

        Next



    End Sub


    Private Sub MenuButtonChangeColor(ByVal sender As System.Object, ByVal e As System.EventArgs)



        ' If Chk.Checked = True Then

        'Label.ForeColor = Color.Red

        '   Else

        'Choose the Color you want when it is unchecked.>>

        '     Label.ForeColor = Color.Black

        '    End If

    End Sub

End Class
