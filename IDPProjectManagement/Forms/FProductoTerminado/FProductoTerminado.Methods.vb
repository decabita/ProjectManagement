Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection

Partial Public Class FProductoTerminado

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.stored_procedure_name = "dbo.ASP_PROCESS_PRODUCTS"
        Me.parent_table_name = "GetParentTableData"

        Me.localDatagridView = Me.DataGridView
        Me.localBindingNavigator = Me.BindingNavigator
        Me.localTSDownDirectAccess = Me.TSDownDirectAcces
        Me.localObjectKey = Me.tCodigoBarras
        Me.localFocusedObject = Me.tClaveId

    End Sub

    Protected Friend Overrides Function CommandDelete() As Boolean

        Try

            With Me

                If Not CBool(Me.DataGridView.CurrentRow.Cells("is_active").Value) Then MessageBox.Show("El registro no está Activo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Function

                If MessageBox.Show("El registro cambiará de estado a Inactivo. ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(System.Windows.Forms.DialogResult.No) Then Exit Function

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------
                .producto_id = .tClaveId.Text.Trim

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
            Call Me.SetToolBarConfiguration(CApplication.ControlState.Query)

            ' Limpia los controles.
            CApplication.ClearControls(Me)

            ' Inicializa el vínculos de datos.
            If Not Me.ClearControlsBinding() Then Throw New CustomException

            ' Executes Query.
            Me.BWorkerGetData.RunWorkerAsync()

            ' Muestra la ventana de progreso.
            Me.oFProgress = New FProgress
            Me.oFProgress.ShowDialog()

            '-------------------------------------------------------------------------------
            ' Call Child Data Refresh.
            '-------------------------------------------------------------------------------
            If Not Me.oCFormController.child_form Is Nothing Then CType(Me.oCFormController.child_form, IFormCommandRules).CommandQuery()
            '-------------------------------------------------------------------------------

            Me.Activate()

            Me.DataGridView.Focus()

            ' Establece el formato de la barra de comandos.
            Call SetToolBarConfiguration(CApplication.ControlState.InitState)

            Return True

        Catch ex As CustomException

            Exit Function

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Protected Friend Overrides Function CommandQueryFind() As Boolean

        'Try
        '    With Me


        '        '--------------------------------------------------------------------------------------------
        '        ' Field Assignment-Validation.
        '        '--------------------------------------------------------------------------------------------
        '        .centro_id = CApplicationController.oCWorkCenter_.centro_id

        '        If String.IsNullOrEmpty(.tCodigoBarras.Text) And _
        '        String.IsNullOrEmpty(.tClaveId.Text) And _
        '        String.IsNullOrEmpty(.tNombre.Text) And _
        '        String.IsNullOrEmpty(.cbPresentacion.SelectedValue) And _
        '        String.IsNullOrEmpty(.cbUnidad.SelectedValue) And _
        '        String.IsNullOrEmpty(.cbTipoMaterial.SelectedValue) And _
        '        String.IsNullOrEmpty(.tPrecioCompra.Text) And _
        '        String.IsNullOrEmpty(.tPrecioVenta.Text) And _
        '        String.IsNullOrEmpty(.cbTipoMaterial.SelectedValue) And _
        '        String.IsNullOrEmpty(.tDescripcion.Text) Then

        '            Throw New CustomException("Se debe proporcionar al menos un valor para la búsqueda.")

        '        Else

        '            .centro_id = CApplicationController.oCWorkCenter_.centro_id

        '            .barcode = (IIf(String.IsNullOrEmpty(tCodigoBarras.Text.Trim()), String.Empty, .tCodigoBarras.Text.Trim))

        '            .producto_id = (IIf(String.IsNullOrEmpty(tClaveId.Text.Trim()), String.Empty, .tClaveId.Text.Trim))

        '            .producto_nombre = (IIf(String.IsNullOrEmpty(.tNombre.Text.Trim()), String.Empty, .tNombre.Text.Trim))

        '            .presentacion_id = If(.cbPresentacion.SelectedValue Is Nothing, String.Empty, .cbPresentacion.SelectedValue.Trim)

        '            .unidad_id = If(.cbUnidad.SelectedValue Is Nothing, String.Empty, .cbUnidad.SelectedValue.Trim)

        '            .tipo_id = If(.cbTipoMaterial.SelectedValue Is Nothing, String.Empty, .cbTipoMaterial.SelectedValue.Trim)

        '            .precio_compra = (IIf(String.IsNullOrEmpty(.tPrecioCompra.Text.Trim()), 0, .tPrecioCompra.Text.Trim))

        '            .precio_venta = (IIf(String.IsNullOrEmpty(.tPrecioVenta.Text.Trim()), 0, .tPrecioVenta.Text.Trim))


        '            .producto_descripcion = (IIf(String.IsNullOrEmpty(.tDescripcion.Text.Trim), String.Empty, .tDescripcion.Text.Trim))

        '        End If

        '        ' Establece el formato de la barra de comandos.
        '        Call Me.SetToolBarConfiguration(CApplication.ControlState.Query)

        '        ' Limpia los controles.
        '        CApplication.ClearControls(Me)

        '        ' Inicializa el vínculos de datos.
        '        If Not Me.ClearControlsBinding() Then Throw New CustomException
        '        '--------------------------------------------------------------------------------------------

        '        '   Call Me.RequestFilter()

        '        ' Show Progress Window.
        '        With Me.oFProgress

        '            .oTypeCaller = Me.GetType
        '            .oMethodInfo = .oTypeCaller.GetMethod("SetBindingSourceFilter", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)

        '            .oCaller = Me

        '            .StartWorker()

        '            If .IsWorkDone Then

        '                Call SetToolBarConfiguration(CApplication.ControlState.InitState)

        '                Call SetControlsBinding()

        '                ' Establece formato de los controles.
        '                Call SetGridPropertiesFormat()

        '                Call SetControlPropertiesFormat()

        '            Else
        '                Call SetToolBarConfiguration(CApplication.ControlState.Find)

        '            End If

        '        End With


        '        ' Establece el formato de la barra de comandos.
        '        '  Call SetToolBarConfiguration(CApplication.ControlState.Find)

        '        '-------------------------------------------------------------------------------
        '        ' Call Child Data Refresh.
        '        '-------------------------------------------------------------------------------
        '        If Not Me.oCFormController.child_form Is Nothing Then CType(Me.oCFormController.child_form, IFormCommandRules).CommandQuery()
        '        '-------------------------------------------------------------------------------

        '        Me.Activate()

        '        Me.DataGridView.Focus()

        '    End With

        '    Return True

        'Catch ex As CustomException

        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Catch ex As Exception

        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try

    End Function

    Protected Friend Overrides Function CommandSave() As Boolean

        Try
            'With Me

            '    '-------------------------------------------------
            '    ' Field Assignment-Validation.
            '    '-------------------------------------------------
            '    .centro_id = CApplicationController.oCWorkCenter_.centro_id

            '    If (CApplication.CheckRequiredFields(.tClaveId)) Then .producto_id = tClaveId.Text.Trim Else Throw New CustomException

            '    If (CApplication.CheckRequiredFields(.tNombre)) Then .producto_nombre = .tNombre.Text.Trim Else Throw New CustomException

            '    If (CApplication.CheckRequiredFields(.tCodigoBarras)) Then .barcode = .tCodigoBarras.Text.Trim Else Throw New CustomException

            '    If Not (CApplication.CheckRequiredFields(.cbTipoMaterial)) Then Exit Function Else .tipo_id = .cbTipoMaterial.SelectedValue.Trim

            '    If Not (CApplication.CheckRequiredFields(.cbUnidad)) Then Exit Function Else .unidad_id = .cbUnidad.SelectedValue.Trim

            '    If Not (CApplication.CheckRequiredFields(.cbPresentacion)) Then Exit Function Else .presentacion_id = .cbPresentacion.SelectedValue.Trim

            '    If (CApplication.CheckRequiredFields(.tPrecioCompra)) Then .precio_compra = .tPrecioCompra.Text.Trim Else Throw New CustomException

            '    If (CApplication.CheckRequiredFields(.tPrecioVenta)) Then .precio_venta = .tPrecioVenta.Text.Trim Else Throw New CustomException


            '    .producto_descripcion = (IIf(String.IsNullOrEmpty(.tDescripcion.Text.Trim), String.Empty, .tDescripcion.Text.Trim))


            '    If Me.form_state = CApplication.ControlState.Add Then

            '        .is_active = 1

            '        If Not Me.SaveRecord() Then

            '            Me.CommandCancel() : Throw New CustomException

            '        Else

            '            Me.oBindingSource.EndEdit()

            '            Call Me.CommandQuery()

            '            Call Me.SetToolBarConfiguration(CApplication.ControlState.InitState)

            '        End If

            '    ElseIf Me.form_state = CApplication.ControlState.Edit Then

            '        .is_active = .ckActivo.Checked

            '        If Not Me.UpdateRecord() Then

            '            Me.CommandCancel() : Throw New CustomException

            '        Else

            '            Me.oBindingSource.EndEdit()

            '            Dim set_current_row As Integer = Me.current_row

            '            Call Me.CommandQuery()

            '            Call Me.SetToolBarConfiguration(CApplication.ControlState.InitState)

            '            If set_current_row >= 0 Then Me.DataGridView.Rows(set_current_row).Selected = True : Me.oBindingSource.Position = set_current_row

            '        End If

            '    End If

            'End With

            Return True

        Catch ex As CustomException

            Exit Function

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Private Function DeleteRecord() As Boolean

        Try
            'oResponse = New SqlParameter
            'oSqlCommand = New SqlCommand(Me.stored_procedure_name)
            'oSqlCommand.CommandType = CommandType.StoredProcedure

            '' --------------------------------------------------------------------------
            '' Parameter Assignation
            '' --------------------------------------------------------------------------
            'With oSqlCommand.Parameters

            '    .Add("@centro_id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.centro_id
            '    .Add("@producto_id", SqlDbType.VarChar).Value = Me.producto_id.Trim

            '    .Add("@command", SqlDbType.Int).Value = SPCommand.CommandDelete

            'End With

            'oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            'oResponse.Direction = ParameterDirection.Output
            '' --------------------------------------------------------------------------

            'oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            'oSqlCommand.ExecuteNonQuery()

            '' --------------------------------------------------------------------------
            '' Handle SP Response. 
            '' --------------------------------------------------------------------------
            'If CInt(oResponse.Value.Equals(0)) Then MessageBox.Show("Registro actualizado en el sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'If CInt(oResponse.Value.Equals(1)) Then Throw New CustomException("Ocurrio un error al actualizar la información. " & oResponse.Value.ToString)

            'If CInt(oResponse.Value.Equals(3)) Then Throw New CustomException("Dato Para Uso Interno del Sistema. No se permite editar el registro.", "Atención")

            'Me.DataGridView.Update()
            'Me.DataGridView.Refresh()

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
                .Add("@producto_id", SqlDbType.VarChar).Value = Me.producto_id
                .Add("@producto_nombre", SqlDbType.VarChar).Value = Me.producto_nombre
                .Add("@producto_descripcion", SqlDbType.VarChar).Value = Me.producto_descripcion
                .Add("@presentacion_id", SqlDbType.VarChar).Value = Me.presentacion_id
                .Add("@precio_compra", SqlDbType.Decimal).Value = Me.precio_compra
                .Add("@precio_venta", SqlDbType.Decimal).Value = Me.precio_venta
                .Add("@tipo_id", SqlDbType.VarChar).Value = Me.tipo_id
                .Add("@unidad_id", SqlDbType.VarChar).Value = Me.unidad_id
                .Add("@barcode", SqlDbType.VarChar).Value = Me.barcode
                .Add("@is_active", SqlDbType.Bit).Value = Me.is_active
                .Add("@command", SqlDbType.Int).Value = value

            End With

            Return True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Private Function SaveRecord() As Boolean

        'oResponse = New SqlParameter

        'Try

        '    If Not PrepareCommand(SPCommand.CommandSave) Then Throw New CustomException

        '    oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
        '    oResponse.Direction = ParameterDirection.Output

        '    oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection 'CApplicationController.oCDataBase.GetSQLConnection

        '    oSqlCommand.ExecuteNonQuery()

        '    ' --------------------------------------------------------------------------
        '    ' Handle SP Response. 
        '    ' --------------------------------------------------------------------------
        '    If CInt(oResponse.Value.Equals(1)) Then Throw New CustomException("El registro ya existe en el sistema. No se puede duplicar el registro.")

        '    If CInt(oResponse.Value.Equals(0)) Then MessageBox.Show("Registro dado de alta en el sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    If CInt(oResponse.Value.Equals(3)) Then Throw New CustomException("Dato Para Uso Interno del Sistema. No se permite editar el registro.", "Atención")

        '    Return True

        'Catch ex As CustomException

        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Catch ex As Exception

        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Finally

        '    If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        'End Try

    End Function

    Private Function UpdateRecord() As Boolean

        'oResponse = New SqlParameter

        'Try

        '    If Not Me.PrepareCommand(SPCommand.CommandUpdate) Then Throw New CustomException

        '    oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
        '    oResponse.Direction = ParameterDirection.Output

        '    oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

        '    oSqlCommand.ExecuteNonQuery()

        '    ' --------------------------------------------------------------------------
        '    ' Handle SP Response. 
        '    ' --------------------------------------------------------------------------
        '    If CInt(oResponse.Value.Equals(1)) Then Throw New CustomException("El registro ya existe en el sistema. No se puede duplicar el registro.")

        '    If CInt(oResponse.Value.Equals(0)) Then MessageBox.Show("Registro actualizado en el sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    If CInt(oResponse.Value.Equals(3)) Then Throw New CustomException("Dato Para Uso Interno del Sistema. No se permite editar el registro.", "Atención")

        '    Return True

        'Catch ex As CustomException

        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Catch ex As Exception

        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Finally

        '    If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        'End Try

    End Function

    Protected Friend Overrides Function SetBindingSource() As Boolean

        Dim oResponse As New SqlParameter
        Dim oSqlCommand As New SqlCommand(Me.stored_procedure_name)

        Try

            oSqlCommand.CommandType = CommandType.StoredProcedure

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
                .Add("@command", SqlDbType.Int).Value = SPCommand.CommandQueryAll

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output
            ' --------------------------------------------------------------------------

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            If oSqlCommand.Connection Is Nothing Then Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)
            oSqlDataAdapter.Fill(oDataSet, Me.parent_table_name)

            If Not CBool(CInt(oDataSet.Tables(Me.parent_table_name).Rows.Count)) Then Throw New CustomException("No existen valores en la tabla.")

            Me.oBindingSource = New BindingSource
            Me.oBindingSource.DataSource = oDataSet
            Me.oBindingSource.DataMember = Me.parent_table_name

            SetBindingSource = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

        Return SetBindingSource

    End Function

    Protected Friend Overrides Function SetBindingSourceFilter() As Boolean

        Dim oResponse As New SqlParameter
        Dim oSqlCommand As New SqlCommand(Me.stored_procedure_name)

        Try

            oSqlCommand.CommandType = CommandType.StoredProcedure

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@barcode", SqlDbType.VarChar).Value = Me.barcode
                .Add("@centro_id", SqlDbType.VarChar).Value = Me.centro_id
                .Add("@producto_id", SqlDbType.VarChar).Value = Me.producto_id
                .Add("@producto_nombre", SqlDbType.VarChar).Value = Me.producto_nombre
                .Add("@presentacion_id", SqlDbType.VarChar).Value = Me.presentacion_id
                .Add("@unidad_id", SqlDbType.VarChar).Value = Me.unidad_id
                .Add("@tipo_id", SqlDbType.VarChar).Value = Me.tipo_id
                .Add("@precio_compra", SqlDbType.Decimal).Value = Decimal.Parse(Me.precio_compra)
                .Add("@precio_venta", SqlDbType.Decimal).Value = Decimal.Parse(Me.precio_venta)
                '.Add("@producto_descripcion", SqlDbType.VarChar).Value = Me.producto_descripcion
                .Add("@command", SqlDbType.Int).Value = SPCommand.CommandQueryFilter

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            '   oResponse = oSqlCommand.Parameters.Add("@response2", SqlDbType.VarChar, 2000)
            '  oResponse.Direction = ParameterDirection.Output
            ' --------------------------------------------------------------------------
            'If CInt(oResponse.Value.Equals(1)) Then Throw New CustomException("El registro ya existe en el sistema. No se puede duplicar el registro.")

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            If oSqlCommand.Connection Is Nothing Then Exit Function

            oDataSet = New DataSet

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)
            oSqlDataAdapter.Fill(oDataSet, Me.parent_table_name)

            If Not CBool(CInt(oDataSet.Tables(Me.parent_table_name).Rows.Count)) Then MessageBox.Show("No existen valores en la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : SetBindingSourceFilter = False Else SetBindingSourceFilter = True

            Me.oBindingSource = New BindingSource
            Me.oBindingSource.DataSource = oDataSet
            Me.oBindingSource.DataMember = Me.parent_table_name

            Return SetBindingSourceFilter

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

        End Try

    End Function

    Protected Friend Overrides Function SetControlsBinding() As Boolean

        Try

            With Me

                ' -------------------------------------------------------------
                ' TEXTBOX BINDING.
                ' -------------------------------------------------------------
                .tClaveId.DataBindings.Add("text", Me.oBindingSource, "producto_id", True)

                .tNombre.DataBindings.Add("text", Me.oBindingSource, "producto_nombre", True)

                .tDescripcion.DataBindings.Add("text", Me.oBindingSource, "producto_descripcion", True).NullValue = CApplication.NotAssignedValue

                .tPrecioCompra.DataBindings.Add("text", Me.oBindingSource, "precio_compra", True).NullValue = "0.0"

                .tPrecioVenta.DataBindings.Add("text", Me.oBindingSource, "precio_venta", True).NullValue = "0.0"

                .tCodigoBarras.DataBindings.Add("text", Me.oBindingSource, "barcode", True).NullValue = CApplication.NotAssignedValue

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

            If CApplication.GetComboMaterialType(Me.oBSourceCombo) Then Me.oCollectionBSourceCombo.Add(Me.oBSourceCombo, "ComboMaterialType") Else Throw New CustomException

            If CApplication.GetComboMeasures(Me.oBSourceCombo) Then Me.oCollectionBSourceCombo.Add(Me.oBSourceCombo, "ComboMeasures") Else Throw New CustomException

            If CApplication.GetComboPresentation(Me.oBSourceCombo) Then Me.oCollectionBSourceCombo.Add(Me.oBSourceCombo, "ComboPresentation") Else Throw New CustomException


            ' 2. Add combo to Form in Simple View.
            With Me.cbTipoMaterial
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboMaterialType")
                .DisplayMember = "tipo_combo"
                .ValueMember = "tipo_id"
                .DataBindings.Add("SelectedValue", Me.oBindingSource, "tipo_id").NullValue = CApplication.NotAssignedValue

            End With

            ' ++
            With Me.cbUnidad
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboMeasures")
                .DisplayMember = "unidad_combo"
                .ValueMember = "unidad_id"
                .DataBindings.Add("SelectedValue", Me.oBindingSource, "unidad_id").NullValue = CApplication.NotAssignedValue

            End With
            ' ++

            With Me.cbPresentacion
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboPresentation")
                .DisplayMember = "presentacion_combo"
                .ValueMember = "presentacion_id"
                .DataBindings.Add("SelectedValue", Me.oBindingSource, "presentacion_id").NullValue = CApplication.NotAssignedValue
            End With


            ' 3. Add combo to Grid in Multi View.

            Dim gcTipoMaterial As New DataGridViewComboBoxColumn

            With gcTipoMaterial
                .DisplayMember = "tipo_combo"
                .ValueMember = "tipo_id"
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboMaterialType")
                .DataPropertyName = "tipo_id"
                .Name = "tipo_id"
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Me.DataGridView.Columns.Add(gcTipoMaterial)

            ' ++

            Dim gcUnidades As New DataGridViewComboBoxColumn

            With gcUnidades
                .DisplayMember = "unidad_combo"
                .ValueMember = "unidad_id"
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboMeasures")
                .DataPropertyName = "unidad_id"
                .Name = "unidad_id"
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Me.DataGridView.Columns.Add(gcUnidades)

            ' ++

            Dim gcPresentaciones As New DataGridViewComboBoxColumn

            With gcPresentaciones
                .DisplayMember = "presentacion_combo"
                .ValueMember = "presentacion_id"
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboPresentation")
                .DataPropertyName = "presentacion_id"
                .Name = "presentacion_id"
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Me.DataGridView.Columns.Add(gcPresentaciones)

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

    Protected Friend Overrides Function SetControlsBindingOnNew() As Boolean

        Try

            With Me


                ' -------------------------------------------------------------
                ' CHECK BOX BINDING. 
                ' -------------------------------------------------------------
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

            If CApplication.GetComboMaterialType(Me.oBSourceCombo) Then Me.oCollectionBSourceCombo.Add(Me.oBSourceCombo, "ComboMaterialType") Else Throw New CustomException

            If CApplication.GetComboMeasures(Me.oBSourceCombo) Then Me.oCollectionBSourceCombo.Add(Me.oBSourceCombo, "ComboMeasures") Else Throw New CustomException

            If CApplication.GetComboPresentation(Me.oBSourceCombo) Then Me.oCollectionBSourceCombo.Add(Me.oBSourceCombo, "ComboPresentation") Else Throw New CustomException

            ' 2. Add combo to Form in Simple View.

            With Me.cbTipoMaterial
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboMaterialType")
                .DisplayMember = "tipo_combo"
                .ValueMember = "tipo_id"
                .SelectedIndex = 0

            End With

            ' ++

            With Me.cbUnidad
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboMeasures")
                .DisplayMember = "unidad_combo"
                .ValueMember = "unidad_id"
                .SelectedIndex = 0

            End With

            With Me.cbPresentacion
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboPresentation")
                .DisplayMember = "presentacion_combo"
                .ValueMember = "presentacion_id"
                .SelectedIndex = 0
            End With


            ' -------------------------------------------------------------
            ' TEXTBOX BINDING.
            ' -------------------------------------------------------------



            ' 3. Add combo to Grid in Multi View.

            ' -------------------------------------------------------------
            ' DATAGRIDVIEW BINDING.
            ' -------------------------------------------------------------

            ' -------------------------------------------------------------
            ' NAVIGATOR BINDING.
            ' -------------------------------------------------------------

            ' -------------------------------------------------------------
            ' Reset Binding.
            ' -------------------------------------------------------------

            Return True

        Catch ex As CustomException

            Exit Function

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Public Shared Function CommandSaveNonExistingMaterial(ByVal value As CBillOMaterial) As Boolean

        Dim oResponse As New SqlParameter
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_PARTS_")

        Try

            oSqlCommand.CommandType = CommandType.StoredProcedure

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.id
                .Add("@producto_id", SqlDbType.VarChar).Value = value.producto_id
                .Add("@producto_nombre", SqlDbType.VarChar).Value = value.descripcion_componente
                .Add("@producto_descripcion", SqlDbType.VarChar).Value = "Capturado Automáticamente por el sistema. Revisar Datos."
                .Add("@tipo_id", SqlDbType.VarChar).Value = "CMP"

                .Add("@unidad_id", SqlDbType.VarChar).Value = value.unidad_id

                .Add("@is_active", SqlDbType.Bit).Value = 1

                .Add("@command", SqlDbType.Int).Value = SPCommand.CommandSave

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output
            ' --------------------------------------------------------------------------

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            oSqlCommand.ExecuteNonQuery()

            If CInt(oResponse.Value.Equals(1)) Then Throw New CustomException("El registro ya existe en el sistema. No se puede duplicar el registro.")

            If CInt(oResponse.Value.Equals(0)) Then MessageBox.Show("El producto " & value.producto_id & " fue dado de alta en el sistema. El producto se guardo con el tipo CMP, debe modificarlo en caso de ser necesario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try

    End Function

    Public Shared Function CommandSaveNonExistingMaterial(ByVal value As String) As Boolean

        Dim oResponse As New SqlParameter
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_PARTS_")

        Try

            oSqlCommand.CommandType = CommandType.StoredProcedure

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.id
                .Add("@producto_id", SqlDbType.VarChar).Value = value
                .Add("@producto_nombre", SqlDbType.VarChar).Value = value
                .Add("@producto_descripcion", SqlDbType.VarChar).Value = "Capturado Automáticamente por el sistema. Revisar Datos."
                .Add("@tipo_id", SqlDbType.VarChar).Value = "PT"

                .Add("@unidad_id", SqlDbType.VarChar).Value = "PZA"

                .Add("@is_active", SqlDbType.Bit).Value = 1

                .Add("@command", SqlDbType.Int).Value = SPCommand.CommandSave

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output
            ' --------------------------------------------------------------------------

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            oSqlCommand.ExecuteNonQuery()

            If CInt(oResponse.Value.Equals(1)) Then Throw New CustomException("El registro ya existe en el sistema. No se puede duplicar el registro.")

            If CInt(oResponse.Value.Equals(0)) Then MessageBox.Show("El producto " & value & " fue dado de alta en el sistema. El producto se guardo con el tipo CMP, debe modificarlo en caso de ser necesario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try

    End Function

    Protected Friend Overrides Sub SetControlPropertiesFormat()

        Try
            With Me

                .tClaveId.Tag = "Clave"
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

            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub SetGeneralFormat()

        Try
            AddHandler Me.tCodigoBarras.GotFocus, AddressOf CApplication.HandleGotFocus
            AddHandler Me.tClaveId.GotFocus, AddressOf CApplication.HandleGotFocus
            AddHandler Me.tClaveId.LostFocus, AddressOf CApplication.HandleLostFocus
            AddHandler Me.tClaveId.KeyPress, AddressOf CApplication.HandleNotSpaces

            AddHandler Me.tNombre.GotFocus, AddressOf CApplication.HandleGotFocus
            AddHandler Me.tNombre.LostFocus, AddressOf CApplication.HandleLostFocus

            AddHandler Me.tDescripcion.GotFocus, AddressOf CApplication.HandleGotFocus
            AddHandler Me.tDescripcion.LostFocus, AddressOf CApplication.HandleLostFocus

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Protected Friend Overrides Sub SetGridPropertiesFormat()


        Try
            With Me.DataGridView

                .MultiSelect = False

                .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

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

                .Columns("barcode").HeaderText = "Código Barras"
                .Columns("barcode").Visible = True
                .Columns("barcode").Width = 120
                .Columns("barcode").DisplayIndex = 1

                .Columns("producto_id").HeaderText = "Clave"
                .Columns("producto_id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("producto_id").Visible = True
                .Columns("producto_id").Width = 120
                .Columns("producto_id").DisplayIndex = 2

                .Columns("producto_nombre").HeaderText = "Nombre"
                .Columns("producto_nombre").Visible = True
                .Columns("producto_nombre").Width = 300
                .Columns("producto_nombre").DisplayIndex = 3

                .Columns("presentacion_id").HeaderText = "Presentación"
                .Columns("presentacion_id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("presentacion_id").Visible = True
                .Columns("presentacion_id").Width = 180
                .Columns("presentacion_id").DisplayIndex = 4

                .Columns("unidad_id").HeaderText = "Unidad"
                .Columns("unidad_id").Visible = True
                .Columns("unidad_id").Width = 180
                .Columns("unidad_id").DisplayIndex = 5

                .Columns("tipo_id").HeaderText = "Tipo"
                .Columns("tipo_id").Visible = True
                .Columns("tipo_id").Width = 180
                .Columns("tipo_id").DisplayIndex = 6

                .Columns("precio_compra").HeaderText = "Costo"
                .Columns("precio_compra").Visible = True
                .Columns("precio_compra").Width = 100
                .Columns("precio_compra").DisplayIndex = 7

                .Columns("precio_venta").HeaderText = "Precio Venta"
                .Columns("precio_venta").Visible = True
                .Columns("precio_venta").Width = 100
                .Columns("precio_venta").DisplayIndex = 8

                .Columns("producto_descripcion").HeaderText = "Descripción"
                .Columns("producto_descripcion").Visible = True
                .Columns("producto_descripcion").Width = 400
                .Columns("producto_descripcion").DisplayIndex = 9

                .Columns("is_active").HeaderText = "Activo"
                .Columns("is_active").Visible = True
                .Columns("is_active").Width = 50
                .Columns("is_active").DisplayIndex = 10

            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

End Class