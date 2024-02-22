Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Public Class FCentrosTrabajo
    Implements IToolBoxCommand


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.oFormController = New CFormController_
        Me.oFormController.parent_form = Me
        Me.view_mode = CApplication.ViewMode.SingleView
        Me.form_state = CApplication.ControlState.InitState
        Me.localFocusedObject = Me.tNombre

    End Sub

    Private Function ClearControlsBinding() As Boolean Implements IToolBoxCommand.ClearControlsBinding

        Try
            ' -------------------------------------------
            ' Clear Binding.
            ' -------------------------------------------
            Call CApplication.ClearControlBinding(Me)

            Me.oDataSet = New DataSet

            If Not Me.oCollectionBSourceCombo Is Nothing Then Me.oCollectionBSourceCombo.Clear()

            Return True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Public Function CommandCancel() As Boolean Implements IToolBoxCommand.CommandCancel

        Select Case Me.view_mode

            Case CApplication.ViewMode.SingleView

                If Me.form_state.Equals(CApplication.ControlState.Add) Then

                    Me.oBindingSource.CancelEdit()

                    Call CommandQuery()

                ElseIf Me.form_state.Equals(CApplication.ControlState.Edit) Then

                    Me.oBindingSource.CancelEdit()

                End If

        End Select

        Call SetToolBarConfiguration(CApplication.ControlState.InitState)

    End Function

    Public Function CommandDelete() As Boolean Implements IToolBoxCommand.CommandDelete

        Try

            With Me

                If Not CBool(Me.DataGridView.CurrentRow.Cells("is_active").Value) Then MessageBox.Show("El registro no está Activo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Function

                If MessageBox.Show("El registro cambiará de estado a Inactivo. ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(System.Windows.Forms.DialogResult.No) Then Exit Function

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------
                ' .almacen_id = .tAlmacenId.Text.Trim

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

    Public Function CommandEdit() As Boolean Implements IToolBoxCommand.CommandEdit

        Try

            If Not CBool(Me.DataGridView.CurrentRow.Cells("is_active").Value) Then MessageBox.Show("El registro no está Activo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Function

            ' Establece el formato de la barra de comandos.
            Call SetToolBarConfiguration(CApplication.ControlState.Edit)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Public Function CommandExit() As Boolean Implements IToolBoxCommand.CommandExit

        DirectCast(Me.ParentForm, MDIMainContainer).Dispose()

    End Function

    Public Function CommandNew() As Boolean Implements IToolBoxCommand.CommandNew

        ' Establece el formato de la barra de comandos.
        Call CApplication.ClearControlBinding(Me) : Call SetToolBarConfiguration(CApplication.ControlState.Add)

    End Function

    Public Function CommandQuery() As Boolean Implements IToolBoxCommand.CommandQuery

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
            '  If Not oFormController.child_form Is Nothing Then DirectCast(oFormController.child_form, FBomChild).CommandQuery()

            Me.DataGridView.Focus()

            Return True

        Catch ex As CustomException

            Exit Function

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Public Function CommandSave() As Boolean Implements IToolBoxCommand.CommandSave

        Try
            With Me

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------
                .centro_id = CApplicationController.oCWorkCenter_.id

                '    If (CApplication.CheckRequiredFields(.tAlmacenId)) Then .almacen_id = tAlmacenId.Text.Trim Else Throw New CustomException

                If (CApplication.CheckRequiredFields(.tNombre)) Then .almacen_nombre = .tNombre.Text.Trim Else Throw New CustomException

                .almacen_descripcion = (IIf(String.IsNullOrEmpty(.tDescripcion.Text.Trim), String.Empty, .tDescripcion.Text.Trim))

                If Me.form_state = CApplication.ControlState.Add Then

                    .is_active = 1
                    ' .image_data = Nothing  'SaveImageFile()

                    If Not Me.SaveRecord() Then

                        Me.CommandCancel() : Throw New CustomException

                    Else

                        Me.oBindingSource.EndEdit()
                        '  Me.oBindingSource.ResetBindings(False)

                        Call Me.CommandQuery()

                        Call Me.SetToolBarConfiguration(CApplication.ControlState.InitState)

                    End If

                ElseIf Me.form_state = CApplication.ControlState.Edit Then

                    .is_active = .ckActivo.Checked

                    If Not Me.UpdateRecord() Then

                        Me.CommandCancel() : Throw New CustomException

                    Else

                        Me.oBindingSource.EndEdit()
                        'Me.oBindingSource.ResetBindings(False)

                        Dim set_current_row As Integer = Me.current_row

                        Call Me.CommandQuery()

                        Call Me.SetToolBarConfiguration(CApplication.ControlState.InitState)


                        If set_current_row >= 0 Then Me.DataGridView.Rows(set_current_row).Selected = True : Me.oBindingSource.Position = set_current_row

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

    Private Function DeleteRecord() As Boolean

        oResponse = New SqlParameter

        Try

            oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_WAREHOUSES")
            oSqlCommand.CommandType = CommandType.StoredProcedure

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.id
                '  .Add("@almacen_id", SqlDbType.VarChar).Value = Me.almacen_id

                .Add("@command", SqlDbType.Int).Value = SPCommand.Delete

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            ' --------------------------------------------------------------------------

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            oSqlCommand.ExecuteNonQuery()

            ' --------------------------------------------------------------------------
            ' Handle SP Response. 
            ' --------------------------------------------------------------------------
            If CInt(oResponse.Value) Then Throw New CustomException("Ocurrio un error al actualizar la información. " & oResponse.Value.ToString)

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
            oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_WAREHOUSES")
            oSqlCommand.CommandType = CommandType.StoredProcedure

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.VarChar).Value = Me.centro_id
                '   .Add("@almacen_id", SqlDbType.VarChar).Value = Me.almacen_id
                .Add("@almacen_nombre", SqlDbType.VarChar).Value = Me.almacen_nombre
                .Add("@almacen_descripcion", SqlDbType.VarChar).Value = Me.almacen_descripcion
                .Add("@is_active", SqlDbType.Bit).Value = Me.is_active

                .Add("@command", SqlDbType.Int).Value = value

            End With

            Return True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Private Function QueryAll() As Boolean

        Try

            ' -------------------------------------------
            ' Get BindingSource.
            ' -------------------------------------------
            If Not SetBindingSource(Me.oBindingSource) Then Throw New CustomException

            Return True

        Catch ex As CustomException

            Exit Function

        End Try

    End Function

    Private Function SaveRecord() As Boolean

        oResponse = New SqlParameter

        Try

            If Not PrepareCommand(SPCommand.SaveCommand) Then Throw New CustomException

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            oSqlCommand.ExecuteNonQuery()

            ' --------------------------------------------------------------------------
            ' Handle SP Response. 
            ' --------------------------------------------------------------------------
            If CInt(oResponse.Value.Equals(1)) Then Throw New CustomException("El registro ya existe en A-tlas. No se puede duplicar el registro.")

            If CInt(oResponse.Value.Equals(0)) Then MessageBox.Show("Registro dado de alta en A-tlas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try

    End Function

    Private Function SetBindingSource(ByRef oBindingSourceDummy As BindingSource) As Boolean

        Dim oResponse As New SqlParameter
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_WORK_CENTER")

        Try

            oSqlCommand.CommandType = CommandType.StoredProcedure

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
                .Add("@command", SqlDbType.Int).Value = SPCommand.QueryAll

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output
            ' --------------------------------------------------------------------------

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            If oSqlCommand.Connection Is Nothing Then Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)
            oSqlDataAdapter.Fill(oDataSet, "BindDataSet")

            If Not CBool(CInt(oDataSet.Tables("BindDataSet").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla.")

            oBindingSourceDummy = New BindingSource
            oBindingSourceDummy.DataSource = oDataSet
            oBindingSourceDummy.DataMember = "BindDataSet"

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
                .tId.DataBindings.Add("text", Me.oBindingSource, "centro_id", True)

                .tNombre.DataBindings.Add("text", Me.oBindingSource, "nombre", True)

                .tDescripcion.DataBindings.Add("text", Me.oBindingSource, "descripcion", True).NullValue = CApplication.NotAssignedValue

                ' -------------------------------------------------------------
                ' CHECK BOX BINDING. 
                ' -------------------------------------------------------------
                .ckActivo.DataBindings.Add("CheckState", Me.oBindingSource, "is_active", True)

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

            ' 3. Add combo to Grid in Multi View.

            ' -------------------------------------------------------------
            ' DATAGRIDVIEW BINDING.
            ' -------------------------------------------------------------
            Me.DataGridView.DataSource = Me.oBindingSource

            ' -------------------------------------------------------------
            ' NAVIGATOR BINDING.
            ' -------------------------------------------------------------
            Me.BindingNavigator.BindingSource = Me.oBindingSource

            ' -------------------------------------------------------------
            ' Reset Binding.
            ' -------------------------------------------------------------
            Me.oBindingSource.ResetBindings(False)

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

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            oSqlCommand.ExecuteNonQuery()

            ' --------------------------------------------------------------------------
            ' Handle SP Response. 
            ' --------------------------------------------------------------------------
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

                .tId.Tag = "Clave"
                .tId.MaxLength = 18
                .tId.TextAlign = HorizontalAlignment.Right

                .tNombre.Tag = "Nombre"
                .tNombre.MaxLength = 80
                .tNombre.TextAlign = HorizontalAlignment.Left

                .tDescripcion.Tag = "Descripción"
                .tDescripcion.MaxLength = 120
                .tDescripcion.TextAlign = HorizontalAlignment.Left

                .ckActivo.Tag = "Activo"

                .DataGridView.Tag = "DataGrid"

            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub SetGeneralFormat()

        Call CApplication.SetFormFormat(Me)

        AddHandler Me.tId.GotFocus, AddressOf CApplication.HandleGotFocus
        AddHandler Me.tId.LostFocus, AddressOf CApplication.HandleLostFocus
        AddHandler Me.tId.KeyPress, AddressOf CApplication.HandleNotSpaces

        AddHandler Me.tNombre.GotFocus, AddressOf CApplication.HandleGotFocus
        AddHandler Me.tNombre.LostFocus, AddressOf CApplication.HandleLostFocus

        AddHandler Me.tDescripcion.GotFocus, AddressOf CApplication.HandleGotFocus
        AddHandler Me.tDescripcion.LostFocus, AddressOf CApplication.HandleLostFocus


    End Sub

    Private Sub SetGridPropertiesFormat() Implements IToolBoxCommand.SetGridPropertiesFormat

        Try
            With Me.DataGridView

                .MultiSelect = False

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

                .Columns("planta_id").Visible = False

                .Columns("centro_id").HeaderText = "Clave"
                .Columns("centro_id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("centro_id").Visible = True
                .Columns("centro_id").DisplayIndex = 1

                .Columns("nombre").HeaderText = "Nombre"
                .Columns("nombre").Visible = True
                .Columns("nombre").DisplayIndex = 2

                .Columns("descripcion").HeaderText = "Descripción"
                .Columns("descripcion").Visible = True
                .Columns("descripcion").DisplayIndex = 3

                .Columns("is_active").HeaderText = "Activo"
                .Columns("is_active").Visible = True
                .Columns("is_active").DisplayIndex = 4


                '.Width = 1600
                '.Height = 461


            End With


            For i = 0 To Me.TableLayoutPanel1.RowStyles.Count

                Select Case i
                    Case 0

                        Me.TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                        Me.TableLayoutPanel1.RowStyles.Item(i).Height = 20

                    Case 1

                        Me.TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                        Me.TableLayoutPanel1.RowStyles.Item(i).Height = 75

                    Case 2
                        Me.TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                        Me.TableLayoutPanel1.RowStyles.Item(i).Height = 5

                End Select





            Next






        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    'Public Sub SetToolBarConfiguration(ByVal State As Integer) Implements IToolBoxCommand.SetToolBarConfiguration

    '    Call SetToolBarConfigurationImplementation(State)

    'End Sub

    Private Sub SetToolBarConfigurationImplementation(ByVal State As Integer)

        Dim enableControls As Boolean = False

        Select Case State

            ' Initial State On ToolBar Strip.
            Case CApplication.ControlState.None

                Me.form_state = CApplication.ControlState.None

                CApplication.EnableControls(Me, False)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True

                Me.BindingNavigator.Enabled = False
                Me.DataGridView.Enabled = False

                ' If there are records.
                Select Case IIf(Me.oBindingSource.Count <= 0, 0, 1)

                    Case Is > 0

                        DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = True

                        Me.BindingNavigator.Enabled = True
                        Me.DataGridView.Enabled = True
                        Me.BindingNavigator.Refresh()

                        enableControls = True

                    Case Else

                        DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True

                        Me.BindingNavigator.Enabled = False
                        Me.DataGridView.Enabled = False

                        enableControls = False


                End Select

                For Each item As ToolStripItem In TSDownDirectAcces.Items
                    item.Enabled = enableControls
                Next item

                Me.tNombre.Focus()

                ' Initial State On ToolBar Strip.
            Case CApplication.ControlState.InitState

                Me.form_state = CApplication.ControlState.InitState

                Call CApplication.EnableControls(Me, False)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExit.Enabled = True

                Me.BindingNavigator.Enabled = False
                Me.DataGridView.Enabled = False

                ' If there are records.
                Select Case IIf(Me.oBindingSource.Count <= 0, 0, 1)

                    Case Is > 0

                        DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = True
                        DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = True

                        Me.BindingNavigator.Enabled = True
                        Me.DataGridView.Enabled = True
                        Me.BindingNavigator.Refresh()

                        enableControls = True

                    Case Else

                        DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = True

                        Me.BindingNavigator.Enabled = False
                        Me.DataGridView.Enabled = False

                        enableControls = False

                End Select

                For Each item As ToolStripItem In TSDownDirectAcces.Items
                    item.Enabled = enableControls
                Next item

                Me.DataGridView.Focus()

            Case CApplication.ControlState.Query

                Me.form_state = CApplication.ControlState.Query

                CApplication.EnableControls(Me, False)
                CApplication.ClearControls(Me)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
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

                CApplication.EnableControls(Me, True)
                CApplication.ClearControls(Me)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = True

                Me.BindingNavigator.Enabled = False
                Me.DataGridView.Enabled = False

                For Each item As ToolStripItem In Me.TSDownDirectAcces.Items
                    item.Enabled = False
                Next

                Me.tId.Focus()

                '---------------------------------------------------------
                ' When Press Edit Command Button Or Enter Edit Mode. 
                '---------------------------------------------------------
            Case CApplication.ControlState.Edit

                Me.form_state = CApplication.ControlState.Edit

                CApplication.EnableControls(Me, True)

                DirectCast(Me.ParentForm, MDIMainContainer).TSBQuery.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBExportToExcel.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBNew.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBEdit.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBSave.Enabled = True
                DirectCast(Me.ParentForm, MDIMainContainer).TSBDelete.Enabled = False
                DirectCast(Me.ParentForm, MDIMainContainer).TSBCancel.Enabled = True

                Me.tId.Enabled = False

                Me.BindingNavigator.Enabled = False
                Me.DataGridView.Enabled = False

                For Each item As ToolStripItem In Me.TSDownDirectAcces.Items
                    item.Enabled = False
                Next item

                Me.tNombre.Focus()

        End Select

        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormState(Me.form_state)

    End Sub

End Class