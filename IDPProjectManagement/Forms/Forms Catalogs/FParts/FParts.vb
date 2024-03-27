Imports System.Data.SqlClient
Imports System.Reflection
Imports System.ComponentModel

Public Class FParts

    'Private _oCPart As New Object
    'Public Property FormRelatedClass() As Object
    '    Get
    '        Return _oCPart
    '    End Get
    '    Set(ByVal value As Object)
    '        _oCPart = value
    '    End Set
    'End Property

    Private _oCPart As New CPart
    Public Property FormRelatedClass() As CPart
        Get
            Return _oCPart
        End Get
        Set(ByVal value As CPart)
            _oCPart = value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private oCPart As CPart = New CPart()

    Dim PrepareSPAction As Action(Of SqlCommand, Integer, Form) = AddressOf PrepareSPCommand

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Initialize()

    End Sub

    Private Sub Initialize()



    End Sub

    Private Sub FParts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Properties in Form Templete
        stored_procedure_name = "dbo.SP_PARTS"

        localDatagridView = Me.DataGridView
        localBindingNavigator = Me.BindingNavigator
        localTSDownDirectAccess = Me.TSDownDirectAcces

        Me.FormRelatedClass = New CPart

        FormRelated = Me


        If Me.DisplayMode = CApplication.FormProcessType.Catalog Or Me.DisplayMode = CApplication.FormProcessType.Parent Then

            Me.oCFormController.parent_form = Me
            Me.oCFormController.child_form = Nothing

            localObjectKey = Me.tGuid
            localFocusedObject = Me.tClaveId

            parent_table_name = "GetParentTableData"

            Me.CommandQuery()

        Else

            Me.oCFormController.child_form = Me
            Me.oCFormController.parent_form = Nothing

            localObjectKey = Me.tGuid
            localFocusedObject = Me.tClaveId

            parent_table_name = "GetParentTableData"

            Me.CommandQueryAsChild()

        End If


    End Sub

    Public Function CommandQueryAsChild() As Boolean

        Try

            ''''' Establece el formato de la barra de comandos.
            SetToolBarConfiguration(CApplication.ControlState.Query)

            ''Inicializa el vínculos de datos.
            If Not ClearControlsBinding() Then Throw New CustomException

            '' Ejecuta la consulta.
            Me.BWorkerGetData.RunWorkerAsync()

            'Muestra la ventana de progreso.
            oFProgress = New FProgress
            oFProgress.ShowDialog()

            ''------------------------------------
            '' Call Child Data Refresh.
            ''------------------------------------
            'If Not Me.oCFormController.child_form Is Nothing Then CType(Me.oCFormController.child_form, IFormCommandRules).CommandQuery()

            ' Establece el formato de la barra de comandos.
            SetToolBarConfiguration(CApplication.ControlState.InitState)

            CommandQueryAsChild = True

        Catch ex As CustomException

            SetToolBarConfiguration(CApplication.ControlState.None)
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            SetToolBarConfiguration(CApplication.ControlState.None)
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            ' Activate call SetToolBarConfiguration and passes commnd state which derives in a issue cuasing DataGridView malfunction. This call should be at the end of the commnd after SetToolBarConfiguration.
            Me.Activate()

            Me.DataGridView.Focus()

        End Try

        Return CommandQueryAsChild

    End Function

    Protected Friend Overrides Function CommandQuery() As Boolean

        Try

            ' Establece el formato de la barra de comandos.
            SetToolBarConfiguration(CApplication.ControlState.Query)

            'Inicializa el vínculos de datos.
            If Not ClearControlsBinding() Then Throw New CustomException


            ''Me.QueryAll()

            ''SetFormFormat(Me)

            ' Ejecuta la consulta.
            Me.BWorkerGetData.RunWorkerAsync()

            'Muestra la ventana de progreso.
            oFProgress = New FProgress
            oFProgress.ShowDialog()

            '------------------------------------
            ' Call Child Data Refresh.
            '------------------------------------
            If Not Me.oCFormController.child_form Is Nothing Then CType(Me.oCFormController.child_form, IFormCommandRules).CommandQuery()

            ' Establece el formato de la barra de comandos.
            SetToolBarConfiguration(CApplication.ControlState.InitState)

            CommandQuery = True

        Catch ex As CustomException

            SetToolBarConfiguration(CApplication.ControlState.None)
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            SetToolBarConfiguration(CApplication.ControlState.None)
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            ' Activate call SetToolBarConfiguration and passes commnd state which derives in a issue cuasing DataGridView malfunction. This call should be at the end of the commnd after SetToolBarConfiguration.
            Me.Activate()

            Me.DataGridView.Focus()

        End Try

        Return CommandQuery

    End Function

    Private Sub BWorkerGetData_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWorkerGetData.DoWork

        Try

            ' Executes Query.
            e.Result = Me.QueryAll()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Protected Friend Overrides Function QueryAll() As Boolean

        Try

            ' Get BindingSource.
            If Not SetBindingSource(Me, Me.oBindingSource, PrepareSPAction) Then Return QueryAll

            QueryAll = True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return QueryAll

    End Function


    Private Sub BWorkerGetData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWorkerGetData.RunWorkerCompleted

        Try

            If Not CBool(CInt(Me.oBindingSource.Count)) Then Throw New CustomException

            SetFormFormat(Me)

            ' Establece el formato de la barra de comandos.
            ' Leave this call to avoid activate issue in command query call.
            SetToolBarConfiguration(CApplication.ControlState.InitState)

        Catch ex As CustomException

            SetToolBarConfiguration(CApplication.ControlState.None)

        Finally

            oFProgress.Dispose()
            BWorkerGetData.Dispose()

        End Try

    End Sub

    Protected Friend Overrides Function CommandSave() As Boolean

        Try
            With Me

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------

                If (CApplication.CheckRequiredFields(.tClaveId)) Then Me.FormRelatedClass.nombre_corto = .tClaveId.Text.Trim Else Throw New CustomException

                If (CApplication.CheckRequiredFields(.tNombre)) Then Me.FormRelatedClass.nombre = .tNombre.Text.Trim Else Throw New CustomException

                Me.FormRelatedClass = New CPart With {
                    .centro_id = CApplicationController.oCWorkCenter_.id,
                    .guid = Me.tGuid.Text,
                    .nombre_corto = Me.tClaveId.Text,
                    .nombre = Me.tNombre.Text,
                    .descripcion = Me.tDescripcion.Text
                }

                If Me.form_state = CApplication.ControlState.Add Then

                    Me.FormRelatedClass.is_active = 1

                    If Not CPart.SaveRecord(Me) Then

                        Me.CommandCancel() : Throw New CustomException

                    Else

                        Me.oBindingSource.EndEdit()
                        ' Me.oBindingSource.ResetBindings(False)

                        Call CommandQuery()

                        Call SetToolBarConfiguration(CApplication.ControlState.InitState)

                    End If

                ElseIf Me.form_state = CApplication.ControlState.Edit Then

                    Me.FormRelatedClass.is_active = .ckActivo.Checked

                    If Not CPart.UpdateRecord(Me) Then

                        Me.CommandCancel() : Throw New CustomException

                    Else

                        Me.oBindingSource.EndEdit()
                        ' Me.oBindingSource.ResetBindings(False)

                        Dim set_current_row As Integer = Me.current_row

                        Call Me.CommandQuery()

                        Call Me.SetToolBarConfiguration(CApplication.ControlState.InitState)

                        If set_current_row >= 0 Then Me.DataGridView.Rows(set_current_row).Selected = True : Me.oBindingSource.Position = set_current_row

                    End If

                End If

            End With

            CommandSave = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return CommandSave

    End Function

    Dim SetControlsBindingOnNewAction As Action(Of Form) = AddressOf FCatalogFormTemplate.SetControlsBindingOnNew
    Protected Friend Overrides Function CommandAddNew() As Boolean

        CommandNew(SetControlsBindingOnNewAction)

        Return True

    End Function

    Protected Friend Overrides Function CommandDelete() As Boolean

        Try

            With Me

                If Not CBool(Me.DataGridView.CurrentRow.Cells("is_active").Value) Then MessageBox.Show("El registro no está Activo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return CommandDelete

                If MessageBox.Show("El registro cambiará de estado a Inactivo. ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(System.Windows.Forms.DialogResult.No) Then Return CommandDelete

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------
                Me.FormRelatedClass = New CPart With {
                    .centro_id = CApplicationController.oCWorkCenter_.id,
                    .nombre_corto = Me.tClaveId.Text,
                    .guid = Me.tGuid.Text
                }

                If Not CPart.DeleteRecord(Me) Then Me.form_state = CApplication.ControlState.InitState : Throw New CustomException("Error al eliminar.")

                If Not Me.CommandQuery() Then Me.form_state = CApplication.ControlState.InitState : Throw New CustomException

            End With

            CommandDelete = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return CommandDelete


    End Function

    Private Sub TSBBom_Click(sender As Object, e As EventArgs) Handles TSBBom.Click

        Try

            If Not Me.oCFormController.child_form Is Nothing Then Throw New CustomException("El formulario ya está abierto.")

            'If Not (Me.DataGridView.CurrentRow.Cells("tipo_id").Value.Equals("PT") Or
            'Me.DataGridView.CurrentRow.Cells("tipo_id").Value.Equals("COM")) Then Throw New CustomException("Solo se puede especificar la lista a los productos terminados y compuestos.")

            '' ----------------------------------------------------------
            '' Create Child Form
            '' ----------------------------------------------------------
            'Dim oFormChild As FParts = New FParts

            FAdministrationMenu.ShowMeInMainContainerAsChild(Me, "FParts", CApplication.FormProcessType.Child)

            'With oFBomChild

            '    ' TODO REPORTS
            '    Me.data_relation_name = oFBomChild.data_relation_name
            '    .oCFormController = Me.oCFormController

            '    .MdiParent = Me.ParentForm
            '    .DisplayMode = CApplication.FormProcessType.Child
            '    .Show()

            'End With

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            Me.oCFormController.child_form = Nothing
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub DataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        Dim ex As Exception = e.Exception
    End Sub

    Private Sub DataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        If Not CBool(CInt(Me.oBindingSource.Count)) Then Exit Sub

        If DataGridView.Rows(e.RowIndex) IsNot Nothing Then Me.current_row = e.RowIndex

    End Sub
    Private Sub FParts_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.oCFormController.active_form = Me

        If Me.DisplayMode = CApplication.FormProcessType.Catalog Or Me.DisplayMode = CApplication.FormProcessType.Parent Then

            ' TODO REPORTS
            DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.parent_form = Me

            DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.child_form = Nothing

        Else

            ' TODO REPORTS
            DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.parent_form = Nothing

            DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.child_form = Me

        End If


        DirectCast(Me.ParentForm, MDIMainContainer).MDICurrentForm.Text = Me.Text
        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormStateDescription(Me.form_state)

        ' Establece el formato de la barra de comandos.
        Call SetToolBarConfiguration(Me.form_state)

    End Sub
    Private Sub FParts_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate

        If Not Me.form_state = CApplication.ControlState.InitState Then Call CommandCancel()

    End Sub
    Private Sub FParts_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Try
            If Me.DisplayMode = CApplication.FormProcessType.Catalog Or Me.DisplayMode = CApplication.FormProcessType.Parent Then

                DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.child_form = Nothing

            Else

                ' TODO REPORTS
                DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.parent_form = Nothing

            End If


        Catch ex As Exception

        Finally

            'Me.Dispose()
            DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.PerformClick()

        End Try

    End Sub

    Protected Friend Overrides Function PrepareSPCommand(ByVal oSqlCommand As SqlCommand, ByVal spCommandValue As Integer, ByVal oForm As Form) As Boolean

        Try

            With oSqlCommand.Parameters

                ' ---------------------- 
                ' Parameter Assignation
                ' -----------------------
                Select Case spCommandValue

                    Case SPCommand.QueryAll

                        .Add("@centro_id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
                        .Add("@command", SqlDbType.Int).Value = SPCommand.QueryAll
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                    Case SPCommand.Save

                        .Add("@centro_id", SqlDbType.VarChar).Value = DirectCast(oForm, FParts).FormRelatedClass.centro_id
                        .Add("@nombre_corto", SqlDbType.VarChar).Value = DirectCast(oForm, FParts).FormRelatedClass.nombre_corto
                        .Add("@nombre", SqlDbType.VarChar).Value = DirectCast(oForm, FParts).FormRelatedClass.nombre
                        .Add("@descripcion", SqlDbType.VarChar).Value = DirectCast(oForm, FParts).FormRelatedClass.descripcion
                        .Add("@is_active", SqlDbType.Bit).Value = DirectCast(oForm, FParts).FormRelatedClass.is_active
                        .Add("@command", SqlDbType.Int).Value = SPCommand.Save
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                    Case SPCommand.Delete

                        .Add("@centro_id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.id
                        .Add("@guid", SqlDbType.VarChar).Value = DirectCast(oForm, FParts).FormRelatedClass.guid
                        .Add("@command", SqlDbType.Int).Value = SPCommand.Delete
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                    Case SPCommand.Update

                        .Add("@centro_id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.id
                        .Add("@guid", SqlDbType.VarChar).Value = DirectCast(oForm, FParts).FormRelatedClass.guid
                        .Add("@nombre_corto", SqlDbType.VarChar).Value = DirectCast(oForm, FParts).FormRelatedClass.nombre_corto
                        .Add("@nombre", SqlDbType.VarChar).Value = DirectCast(oForm, FParts).FormRelatedClass.nombre
                        .Add("@descripcion", SqlDbType.VarChar).Value = DirectCast(oForm, FParts).FormRelatedClass.descripcion
                        .Add("@command", SqlDbType.Int).Value = SPCommand.Update
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                End Select

            End With

            'PrepareSPCommand = True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        'Return PrepareSPCommand()

    End Function

    'Public Shared Function SaveRecord(ByVal oForm As FParts) As Boolean

    '    Try

    '        Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

    '            Using oSqlCommand As New SqlCommand(oForm.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

    '                PrepareSPCommand(oSqlCommand, SPCommand.Save, oForm)

    '                oSqlCommand.ExecuteNonQuery()

    '                ' ----------------------------
    '                ' Handle SP Response. 
    '                ' ----------------------------
    '                If CInt(oSqlCommand.Parameters("@response").Value.Equals(1)) Then Throw New CustomException("El registro ya existe. No se puede duplicar el registro.")

    '                If CInt(oSqlCommand.Parameters("@response").Value.Equals(0)) Then MessageBox.Show("Registro dado de alta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            End Using

    '        End Using

    '        SaveRecord = True

    '    Catch ex As CustomException

    '        MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Catch ex As Exception

    '        MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try

    '    Return SaveRecord

    'End Function


    'Public Shared Function UpdateRecord(ByVal oForm As FParts) As Boolean

    '    Try

    '        Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

    '            Using oSqlCommand As New SqlCommand(oForm.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

    '                'If Not CPart.PrepareSPCommand(oSqlCommand, SPCommand.Update, oForm) Then Throw New CustomException

    '                PrepareSPCommand(oSqlCommand, SPCommand.Update, oForm)

    '                oSqlCommand.ExecuteNonQuery()

    '                ' -------------------------
    '                ' Handle SP Response. 
    '                ' -------------------------
    '                If CInt(oSqlCommand.Parameters("@response").Value.Equals(1)) Then Throw New CustomException("El registro ya existe. No se puede duplicar el registro.")

    '                If CInt(oSqlCommand.Parameters("@response").Value.Equals(0)) Then MessageBox.Show("Registro actualizado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            End Using
    '        End Using

    '        UpdateRecord = True

    '    Catch ex As CustomException

    '        MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Catch ex As Exception

    '        MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try

    '    Return UpdateRecord

    'End Function

    'Public Shared Function DeleteRecord(ByVal oForm As FParts) As Boolean

    '    Try

    '        Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

    '            Using oSqlCommand As New SqlCommand(oForm.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

    '                ' ---------------------------------
    '                ' Set Command Ready and Execute
    '                ' ---------------------------------
    '                'If Not CPart.PrepareSPCommand(oSqlCommand, SPCommand.Delete, oForm) Then Throw New CustomException

    '                PrepareSPCommand(oSqlCommand, SPCommand.Delete, oForm)

    '                oSqlCommand.ExecuteNonQuery()

    '                ' -------------------------
    '                ' Handle SP Response. 
    '                ' -------------------------
    '                If CInt(oSqlCommand.Parameters("@response").Value.Equals(1)) Then Throw New CustomException("Ocurrio un error al actualizar la información. ")

    '                If CInt(oSqlCommand.Parameters("@response").Value.Equals(0)) Then MessageBox.Show("Registro actualizado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                oForm.DataGridView.Update()
    '                oForm.DataGridView.Refresh()

    '            End Using

    '        End Using

    '        DeleteRecord = True

    '    Catch ex As CustomException

    '        MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Catch ex As Exception

    '        MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try

    '    Return DeleteRecord

    'End Function

End Class