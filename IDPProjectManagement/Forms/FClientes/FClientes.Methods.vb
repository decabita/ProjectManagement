Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Public Class FClientes

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.stored_procedure_name = "dbo.SP_PROCESS_CUSTOMERS"
        Me.parent_table_name = "GetParentTableData"

        Me.localDatagridView = Me.DataGridView
        Me.localBindingNavigator = Me.BindingNavigator
        Me.localTSDownDirectAccess = Me.TSDownDirectAcces
        Me.localObjectKey = Me.tGuid
        Me.localFocusedObject = Me.tClaveId

        Me.oMainClass = New CCustomer

    End Sub

    Protected Friend Overrides Function QueryAll() As Boolean

        Try

            ' -------------------------------------------
            ' Get BindingSource.
            ' -------------------------------------------
            If Not SetBindingSource(Me.oBindingSource) Then Throw New CustomException

            QueryAll = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return QueryAll

    End Function

    Protected Friend Overrides Function SetBindingSource(ByRef oBindingSourceDummy As BindingSource) As Boolean

        Try

            Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

                Using oSqlCommand As New SqlCommand(Me.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

                    ' ----------------------
                    ' Parameter Assignation
                    ' ----------------------
                    With oSqlCommand.Parameters

                        .Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
                        .Add("@command", SqlDbType.Int).Value = SPCommand.QueryAll
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                    End With

                    Using oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

                        Using oDataSet As New DataSet

                            oSqlDataAdapter.Fill(oDataSet, "BindedTableDataSet")

                            If Not CBool(CInt(oDataSet.Tables("BindedTableDataSet").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla.")

                            oBindingSourceDummy = New BindingSource
                            oBindingSourceDummy.DataSource = oDataSet
                            oBindingSourceDummy.DataMember = "BindedTableDataSet"

                            SetBindingSource = True

                        End Using

                    End Using

                End Using

            End Using


        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return SetBindingSource

    End Function

    Protected Friend Overrides Function SetControlsBindingOnNew() As Boolean

        Return CCustomer.SetControlsBindingOnNew(Me)

    End Function

    Protected Friend Overrides Function CommandDelete() As Boolean

        Try

            With Me

                If Not CBool(Me.DataGridView.CurrentRow.Cells("is_active").Value) Then MessageBox.Show("El registro no está Activo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Function

                If MessageBox.Show("El registro cambiará de estado a Inactivo. ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(System.Windows.Forms.DialogResult.No) Then Exit Function

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------
                Me.oMainClass.GetClassData(.tClaveId.Text.Trim)

                If Not Me.DeleteRecord() Then Me.form_state = CApplication.ControlState.InitState : Throw New CustomException

                If Not Me.CommandQuery() Then Me.form_state = CApplication.ControlState.InitState : Throw New CustomException

            End With

            Return True

        Catch ex As CustomException

            Exit Function

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Protected Friend Overrides Function CommandQuery() As Boolean

        Try

            ' Establece el formato de la barra de comandos.
            Call SetToolBarConfiguration(CApplication.ControlState.Query)

            ' Limpia los controles.
            CApplication.ClearControls(Me)

            ' Inicializa el vínculos de datos.
            If Not Me.ClearControlsBinding() Then Throw New CustomException

            ' Ejecuta la consulta.
            Me.BWorkerGetData.RunWorkerAsync()

            ' Muestra la ventana de progreso.
            Me.oFProgress = New FProgress
            Me.oFProgress.ShowDialog()

            '-------------------------------------------------------------------------------
            ' Call Child Data Refresh.
            '-------------------------------------------------------------------------------


            '-------------------------------------------------------------------------------

            Me.DataGridView.Focus()

            Return True

        Catch ex As CustomException

            Exit Function

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Protected Friend Overrides Function CommandSave() As Boolean

        Try
            With Me

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------

                Me.oMainClass.centro_id = CApplicationController.oCWorkCenter_.id

                'If (CApplication.CheckRequiredFields(.tUsuarioId)) Then .usuario_id = tUsuarioId.Text.Trim Else Throw New CustomException

                'If (CApplication.CheckRequiredFields(.tClaveId)) Then .nombre_corto = tClaveId.Text.Trim Else Throw New CustomException

                'If (CApplication.CheckRequiredFields(.tNombre)) Then .usuario_nombre = .tNombre.Text.Trim Else Throw New CustomException

                '.usuario_descripcion = (IIf(String.IsNullOrEmpty(.tDescripcion.Text.Trim), String.Empty, .tDescripcion.Text.Trim))

                If Me.form_state = CApplication.ControlState.Add Then

                    '.is_active = 1
                    ' .image_data = Nothing  'SaveImageFile()

                    If Not Me.SaveRecord() Then

                        Me.CommandCancel() : Throw New CustomException

                    Else

                        Me.oBindingSourceParent.EndEdit()
                        Me.oBindingSourceParent.ResetBindings(False)

                        Call CommandQuery()

                        Call SetToolBarConfiguration(CApplication.ControlState.InitState)

                    End If

                ElseIf Me.form_state = CApplication.ControlState.Edit Then

                    .is_active = .ckActivo.Checked

                    If Not Me.UpdateRecord() Then

                        Me.CommandCancel() : Throw New CustomException

                    Else

                        Me.oBindingSourceParent.EndEdit()
                        Me.oBindingSourceParent.ResetBindings(False)

                        Call SetToolBarConfiguration(CApplication.ControlState.InitState)

                    End If

                End If

            End With

            Return True

        Catch ex As CustomException

            Exit Function

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function
    Private Function SaveRecord() As Boolean

        oResponse = New SqlParameter

        Try

            If Not PrepareCommand(SPCommand.Save) Then Throw New CustomException

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            oSqlCommand.ExecuteNonQuery()

            ' --------------------------------------------------------------------------
            ' Handle SP Response. 
            ' --------------------------------------------------------------------------
            If CInt(oResponse.Value.Equals(1)) Then Throw New CustomException("El registro ya existe. No se puede duplicar el registro.")

            If CInt(oResponse.Value.Equals(0)) Then MessageBox.Show("Registro dado de alta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            SaveRecord = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try

        Return SaveRecord

    End Function
    Private Function DeleteRecord() As Boolean

        oResponse = New SqlParameter

        Try

            oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_USERS")
            oSqlCommand.CommandType = CommandType.StoredProcedure

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.centro_id
                .Add("@usuario_id", SqlDbType.VarChar).Value = Me.usuario_id.Trim

                .Add("@command", SqlDbType.Int).Value = SPCommand.Delete

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            ' --------------------------------------------------------------------------

            oSqlCommand.Connection = AbrirAmanco()

            oSqlCommand.ExecuteNonQuery()

            ' --------------------------------------------------------------------------
            ' Handle SP Response. 
            ' --------------------------------------------------------------------------
            If CInt(oResponse.Value) Then Throw New CustomException("Ocurrio un error al actualizar la información. " & oResponse.Value.ToString)

            If CInt(oResponse.Equals(2)) Then Throw New CustomException("El usuario SYS_ATLAS no puede ser modificado. " & oResponse.Value.ToString)

            Me.DataGridView.Update()
            Me.DataGridView.Refresh()

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Private Function PrepareCommand(ByVal value As Integer) As Boolean

        Try
            oSqlCommand = New SqlCommand(Me.stored_procedure_name)
            oSqlCommand.CommandType = CommandType.StoredProcedure

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.VarChar).Value = Me.centro_id
                .Add("@usuario_id", SqlDbType.VarChar).Value = Me.usuario_id
                .Add("@usuario_contraseña", SqlDbType.VarChar).Value = Me.usuario_contraseña
                ' CApplicationController.base64Encode(Me.usuario_contraseña)
                .Add("@usuario_nombre", SqlDbType.VarChar).Value = Me.usuario_nombre
                .Add("@usuario_descripcion", SqlDbType.VarChar).Value = Me.usuario_descripcion
                .Add("@is_active", SqlDbType.Bit).Value = Me.is_active

                .Add("@command", SqlDbType.Int).Value = value

            End With

            Return True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function


    Private Function SetBindingSourceParent(ByRef oBindingSourceDummy As BindingSource) As Boolean

        Dim oResponse As New SqlParameter
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_USERS")

        Try

            oSqlCommand.CommandType = CommandType.StoredProcedure

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.centro_id
                .Add("@command", SqlDbType.Int).Value = SPCommand.QueryAll

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            ' --------------------------------------------------------------------------

            oSqlCommand.Connection = AbrirAmanco()

            If oSqlCommand.Connection Is Nothing Then Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)
            oSqlDataAdapter.Fill(oDataSet, "GetUsersData")

            If Not CBool(CInt(oDataSet.Tables("GetUsersData").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla.")

            oBindingSourceDummy = New BindingSource
            oBindingSourceDummy.DataSource = oDataSet
            oBindingSourceDummy.DataMember = "GetUsersData"

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try

    End Function

    Public Function SetControlsBinding() As Boolean Implements IToolBoxCommand.SetControlsBinding

        Try

            With Me

                ' -------------------------------------------------------------
                ' TEXTBOX BINDING.
                ' -------------------------------------------------------------
                .tUsuarioId.DataBindings.Add("text", Me.oBindingSourceParent, "usuario_id", True)

                .tNombre.DataBindings.Add("text", Me.oBindingSourceParent, "usuario_nombre", True)

                '    .tContraseña.DataBindings.Add("text", Me.oBindingSourceParent, "usuario_contraseña", True).NullValue = CApplication.NotAssignedValue

                .tDescripcion.DataBindings.Add("text", Me.oBindingSourceParent, "usuario_descripcion", True).NullValue = CApplication.NotAssignedValue

                ' -------------------------------------------------------------
                ' CHECK BOX BINDING. 
                ' -------------------------------------------------------------
                .ckActivo.DataBindings.Add("CheckState", Me.oBindingSourceParent, "is_active", True)

                ' -------------------------------------------------------------
                ' PICTURE BOX BINDING. 
                ' -------------------------------------------------------------

            End With

            ' -------------------------------------------------------------
            ' COMBO BINDING.
            ' -------------------------------------------------------------
            ' -------------------------------------------------------------
            ' Get combo data for each Combobox in Form.
            ' -------------------------------------------------------------

            ' 1. Fill Combo Binding Source and Add Combo Binding Source to Collection.


            ' 2. Add combo to Form in Simple View.

            ' ++

            ' 3. Add combo to Grid in Multi View.

            ' -------------------------------------------------------------
            ' DATAGRIDVIEW BINDING.
            ' -------------------------------------------------------------
            Me.DataGridView.DataSource = oBindingSourceParent

            ' -------------------------------------------------------------
            ' NAVIGATOR BINDING.
            ' -------------------------------------------------------------
            Me.BindingNavigator.BindingSource = Me.oBindingSourceParent

            ' -------------------------------------------------------------
            ' Reset Binding.
            ' -------------------------------------------------------------
            oBindingSourceParent.ResetBindings(False)

            Return True

        Catch ex As CustomException

            Exit Function

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Public Function UpdateCommand() As Boolean Implements IToolBoxCommand.UpdateCommand

    End Function

    Private Function UpdateRecord() As Boolean

        oResponse = New SqlParameter

        Try

            If Not PrepareCommand(SPCommand.Update) Then Throw New CustomException

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = AbrirAmanco()

            oSqlCommand.ExecuteNonQuery()

            If CInt(oResponse.Value.Equals(1)) Then Throw New CustomException("El registro ya existe en A-tlas. No se puede duplicar el registro.")

            If CInt(oResponse.Value.Equals(0)) Then MessageBox.Show("Registro actualizado en A-tlas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try

    End Function

    Private Sub SetControlPropertiesFormat() Implements IToolBoxCommand.SetControlPropertiesFormat

        Try
            With Me

                .tClaveId.Tag = "Nombre Corto"
                .tClaveId.MaxLength = 18
                .tClaveId.TextAlign = HorizontalAlignment.Right

                .tNombre.Tag = "Nombre"
                .tNombre.MaxLength = 80
                .tNombre.TextAlign = HorizontalAlignment.Left

                .tDescripcion.Tag = "Descripción"
                .tDescripcion.MaxLength = 120
                .tDescripcion.TextAlign = HorizontalAlignment.Left

                .ckActivo.Tag = "Activo"

                .DataGridView.Tag = "DataGrid"


                For i = 0 To .TableLayoutPanel1.RowStyles.Count

                    Select Case i
                        Case 0

                            .TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                            .TableLayoutPanel1.RowStyles.Item(i).Height = 20

                        Case 1

                            .TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                            .TableLayoutPanel1.RowStyles.Item(i).Height = 70

                        Case 2
                            .TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                            .TableLayoutPanel1.RowStyles.Item(i).Height = 5

                    End Select

                Next

            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub SetGeneralFormat()

        AddHandler Me.tClaveId.GotFocus, AddressOf CApplication.HandleGotFocus
        AddHandler Me.tClaveId.LostFocus, AddressOf CApplication.HandleLostFocus
        AddHandler Me.tClaveId.KeyPress, AddressOf CApplication.HandleNotSpaces

        AddHandler Me.tNombre.GotFocus, AddressOf CApplication.HandleGotFocus
        AddHandler Me.tNombre.LostFocus, AddressOf CApplication.HandleLostFocus

        AddHandler Me.tDescripcion.GotFocus, AddressOf CApplication.HandleGotFocus
        AddHandler Me.tDescripcion.LostFocus, AddressOf CApplication.HandleLostFocus

        For i = 0 To Me.TableLayoutPanel1.RowStyles.Count

            Select Case i
                Case 0

                    Me.TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                    Me.TableLayoutPanel1.RowStyles.Item(i).Height = 20

                Case 1

                    Me.TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                    Me.TableLayoutPanel1.RowStyles.Item(i).Height = 70

                Case 2
                    Me.TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                    Me.TableLayoutPanel1.RowStyles.Item(i).Height = 5

            End Select

        Next

    End Sub

    Private Sub SetGridPropertiesFormat() Implements IToolBoxCommand.SetGridPropertiesFormat

        Try
            With Me.DataGridView

                .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .ColumnHeadersDefaultCellStyle.Font = New Font(.Font.FontFamily, .Font.Size, _
                .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)

                ' .DefaultCellStyle.NullValue = "NA"

                '--------------------------------------------------------------------
                ' TODO 
                '
                ' Change column properties and format in accordance with data. 
                '--------------------------------------------------------------------

                .Columns("centro_id").Visible = False

                .Columns("usuario_id").HeaderText = "Clave"
                .Columns("usuario_id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("usuario_id").Visible = True
                .Columns("usuario_id").DisplayIndex = 1

                .Columns("usuario_nombre").HeaderText = "Nombre"
                .Columns("usuario_nombre").Visible = True
                .Columns("usuario_nombre").DisplayIndex = 2

                .Columns("usuario_descripcion").HeaderText = "Descripción"
                .Columns("usuario_descripcion").Visible = True
                .Columns("usuario_descripcion").DisplayIndex = 3

                .Columns("is_active").HeaderText = "Activo"
                .Columns("is_active").Visible = True
                .Columns("is_active").DisplayIndex = 4

            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    'Private Sub SetToolBarConfiguration(ByVal State As Integer) Implements IToolBoxCommand.SetToolBarConfiguration

    '    Dim enableControls As Boolean = False

    '    Select Case State

    '        ' Initial State On ToolBar Strip.
    '        Case CApplication.ControlState.None

    '            Me.form_state = CApplication.ControlState.None

    '            CApplication.EnableControls(Me, False)

    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True

    '            Me.BindingNavigator.Enabled = False
    '            Me.DataGridView.Enabled = False

    '            ' If there are records.
    '            Select Case IIf(Me.oBindingSourceParent.Count <= 0, 0, 1)

    '                Case Is > 0

    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = True
    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True
    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = True
    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = True
    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = True

    '                    Me.BindingNavigator.Enabled = True
    '                    Me.DataGridView.Enabled = True
    '                    Me.BindingNavigator.Refresh()

    '                    enableControls = True

    '                Case Else

    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True

    '                    Me.BindingNavigator.Enabled = False
    '                    Me.DataGridView.Enabled = False

    '                    enableControls = False


    '            End Select

    '            For Each item As ToolStripItem In TSDownDirectAcces.Items
    '                item.Enabled = enableControls
    '            Next item

    '            Me.tNombre.Focus()

    '            ' Initial State On ToolBar Strip.
    '        Case CApplication.ControlState.InitState

    '            Me.form_state = CApplication.ControlState.InitState

    '            Call CApplication.EnableControls(Me, False)

    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True

    '            Me.BindingNavigator.Enabled = False
    '            Me.DataGridView.Enabled = False

    '            ' If there are records.
    '            Select Case IIf(Me.oBindingSourceParent.Count <= 0, 0, 1)

    '                Case Is > 0

    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = True
    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True
    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = True
    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = True
    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = True

    '                    Me.BindingNavigator.Enabled = True
    '                    Me.DataGridView.Enabled = True
    '                    Me.BindingNavigator.Refresh()

    '                    enableControls = True

    '                Case Else

    '                    DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True

    '                    Me.BindingNavigator.Enabled = False
    '                    Me.DataGridView.Enabled = False

    '                    enableControls = False

    '            End Select

    '            For Each item As ToolStripItem In TSDownDirectAcces.Items
    '                item.Enabled = enableControls
    '            Next item

    '            Me.DataGridView.Focus()

    '        Case CApplication.ControlState.Query

    '            Me.form_state = CApplication.ControlState.Query

    '            CApplication.EnableControls(Me, False)
    '            CApplication.ClearControls(Me)

    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = False

    '            Me.BindingNavigator.Enabled = False
    '            Me.DataGridView.Enabled = False

    '            For Each item As ToolStripItem In Me.TSDownDirectAcces.Items
    '                item.Enabled = False
    '            Next

    '            '---------------------------------------------------------
    '            ' When Press Add Command Button Or Enter Add Mode.
    '            '---------------------------------------------------------
    '        Case CApplication.ControlState.Add

    '            Me.form_state = CApplication.ControlState.Add

    '            CApplication.EnableControls(Me, True)
    '            CApplication.ClearControls(Me)

    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = True
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = True

    '            Me.BindingNavigator.Enabled = False
    '            Me.DataGridView.Enabled = False

    '            For Each item As ToolStripItem In Me.TSDownDirectAcces.Items
    '                item.Enabled = False
    '            Next

    '            Me.tUsuarioId.Focus()

    '            '---------------------------------------------------------
    '            ' When Press Edit Command Button Or Enter Edit Mode. 
    '            '---------------------------------------------------------
    '        Case CApplication.ControlState.Edit

    '            Me.form_state = CApplication.ControlState.Edit

    '            CApplication.EnableControls(Me, True)

    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = True
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
    '            DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = True

    '            Me.tUsuarioId.Enabled = False

    '            Me.BindingNavigator.Enabled = False
    '            Me.DataGridView.Enabled = False

    '            For Each item As ToolStripItem In Me.TSDownDirectAcces.Items
    '                item.Enabled = False
    '            Next item

    '            Me.tNombre.Focus()

    '    End Select

    '    DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormState(Me.form_state)

    'End Sub

    Private Sub SetToolBarConfigurationo(ByVal State As Integer) 'Implements IToolBoxCommand.SetToolBarConfiguration

        Select Case State

            ' Initial State On ToolBar Strip.
            Case CApplication.ControlState.None

                Me.form_state = CApplication.ControlState.None

                '---------------------------------------------------------
                ' On SingleView Mode
                '---------------------------------------------------------
                If Me.view_mode = CApplication.ViewMode.SingleView Then

                    CApplication.EnableControls(Me, False)

                    DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True

                    ' If there are records.
                    Select Case IIf(Me.oBindingSourceParent.Count <= 0, 0, 1)

                        Case Is > 0

                            DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = True
                            DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = True
                            DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = True
                            Me.BindingNavigator.Enabled = True
                            Me.DataGridView.Enabled = True
                            Me.BindingNavigator.Refresh()

                            For Each item As ToolStripItem In TSDownDirectAcces.Items
                                item.Enabled = True
                            Next

                            ' If not.
                        Case Else

                            DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                            DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                            DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                            Me.BindingNavigator.Enabled = False
                            Me.DataGridView.Enabled = False

                            For Each item As ToolStripItem In TSDownDirectAcces.Items
                                item.Enabled = False
                            Next


                    End Select

                    Me.tNombre.Focus()

                End If

                ' Initial State On ToolBar Strip.
            Case CApplication.ControlState.InitState

                Me.form_state = CApplication.ControlState.InitState

                '---------------------------------------------------------
                ' On SingleView Mode
                '---------------------------------------------------------
                If Me.view_mode = CApplication.ViewMode.SingleView Then

                    CApplication.EnableControls(Me, False)

                    DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True

                    ' If there are records.
                    Select Case IIf(Me.oBindingSourceParent.Count <= 0, 0, 1)

                        Case Is > 0

                            DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = True
                            DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = True
                            DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = True

                            Me.BindingNavigator.Enabled = True
                            Me.DataGridView.Enabled = True

                            Me.BindingNavigator.Refresh()

                            For Each item As ToolStripItem In TSDownDirectAcces.Items
                                item.Enabled = True
                            Next

                            ' If not.
                        Case Else

                            DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                            DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                            DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False

                            Me.BindingNavigator.Enabled = False
                            Me.DataGridView.Enabled = False

                            For Each item As ToolStripItem In TSDownDirectAcces.Items
                                item.Enabled = False
                            Next

                    End Select

                    Me.tNombre.Focus()

                    '---------------------------------------------------------
                    ' On Multiview Mode.
                    '---------------------------------------------------------
                ElseIf Me.view_mode = CApplication.ViewMode.Multiview Then

                    DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True

                    '  Call CApplication.EnableColumn(Me.DataGridView.Columns("producto_id"), False)


                    ' If there are records.
                    Select Case IIf(Me.oBindingSourceParent.Count <= 0, 0, 1)

                        Case Is > 0

                            DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = True
                            DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = True

                            Me.BindingNavigator.Enabled = True
                            Me.DataGridView.Enabled = True

                            For Each item As ToolStripItem In TSDownDirectAcces.Items
                                item.Enabled = True
                            Next

                            ' If not.
                        Case Else

                            DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                            DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False

                            Me.BindingNavigator.Enabled = False
                            Me.DataGridView.Enabled = False

                            For Each item As ToolStripItem In TSDownDirectAcces.Items
                                item.Enabled = False
                            Next

                    End Select

                End If

                '---------------------------------------------------------
                ' When Press Query Command Button. 
                '---------------------------------------------------------
            Case CApplication.ControlState.Query

                Me.form_state = CApplication.ControlState.Query

                CApplication.EnableControls(Me, False)
                CApplication.ClearControls(Me)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = False

                Me.BindingNavigator.Enabled = False
                Me.DataGridView.Enabled = False

                For Each item As ToolStripItem In Me.TSDownDirectAcces.Items
                    item.Enabled = False
                Next

                '---------------------------------------------------------
                ' When Press Add Command Button Or Enter Add Mode.
                '---------------------------------------------------------
            Case CApplication.ControlState.Add

                Me.form_state = CApplication.ControlState.Add

                If Me.view_mode = CApplication.ViewMode.SingleView Then

                    CApplication.EnableControls(Me, True)
                    CApplication.ClearControls(Me)

                    DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = True
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = True

                    Me.tUsuarioId.Focus()

                ElseIf Me.view_mode = CApplication.ViewMode.Multiview Then

                    DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = True
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False

                End If

                Me.BindingNavigator.Enabled = False
                Me.DataGridView.Enabled = False

                For Each item As ToolStripItem In Me.TSDownDirectAcces.Items
                    item.Enabled = False
                Next

                '---------------------------------------------------------
                ' When Press Edit Command Button Or Enter Edit Mode. 
                '---------------------------------------------------------
            Case CApplication.ControlState.Edit

                Me.form_state = CApplication.ControlState.Edit

                If Me.view_mode = CApplication.ViewMode.SingleView Then

                    CApplication.EnableControls(Me, True)

                    DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = True
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = True

                    Me.tUsuarioId.Enabled = False

                ElseIf Me.view_mode = CApplication.ViewMode.Multiview Then

                    DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = True
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                    DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False

                End If

                Me.BindingNavigator.Enabled = False
                Me.DataGridView.Enabled = False

                For Each item As ToolStripItem In Me.TSDownDirectAcces.Items
                    item.Enabled = False
                Next

                Me.tNombre.Focus()

        End Select

        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormState(Me.form_state)

    End Sub

End Class