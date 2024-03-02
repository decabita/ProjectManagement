Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection

Partial Public Class FCentrosTrabajo

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.stored_procedure_name = "dbo.ASP_PROCESS_WORK_CENTER"
        Me.parent_table_name = "GetParentTableData"

        Me.localDatagridView = Me.DataGridView
        Me.localBindingNavigator = Me.BindingNavigator
        Me.localTSDownDirectAccess = Me.TSDownDirectAcces
        Me.localObjectKey = Me.tGuid
        Me.localFocusedObject = Me.tClaveId

    End Sub


    Protected Friend Overrides Function QueryAll() As Boolean

        Try

            ' -------------------------------------------
            ' Get BindingSource.
            ' -------------------------------------------
            If Not SetBindingSource(Me.oBindingSource) Then Return QueryAll

            QueryAll = True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return QueryAll

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
                .Add("@command", SqlDbType.Int).Value = SPCommand.QueryAll

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output
            ' --------------------------------------------------------------------------

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            If oSqlCommand.Connection Is Nothing Then Return SetBindingSource

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)
            oSqlDataAdapter.Fill(oDataSet, Me.parent_table_name)

            If Not CBool(CInt(oDataSet.Tables(Me.parent_table_name).Rows.Count)) Then MessageBox.Show("No existen valores en la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'New CustomException("No existen valores en la tabla.")

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

    'Protected Friend Overrides Function SetBindingSource(ByRef oBindingSourceDummy As BindingSource) As Boolean

    '    Try

    '        Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

    '            Using oSqlCommand As New SqlCommand(Me.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

    '                ' ---------------------------------
    '                ' Set Command Ready and Execute
    '                ' ---------------------------------
    '                If Not PrepareSPCommand(oSqlCommand, SPCommand.QueryAll) Then Throw New CustomException

    '                Using oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

    '                    Using oDataSet As New DataSet

    '                        oSqlDataAdapter.Fill(oDataSet, "BindedTableDataSet")

    '                        If Not CBool(CInt(oDataSet.Tables("BindedTableDataSet").Rows.Count)) Then Throw New CustomException("SetBindingSource: No existen valores en la tabla. Capture información.")

    '                        oBindingSourceDummy = New BindingSource
    '                        oBindingSourceDummy.DataSource = oDataSet
    '                        oBindingSourceDummy.DataMember = "BindedTableDataSet"

    '                        SetBindingSource = True

    '                    End Using

    '                End Using

    '            End Using

    '        End Using


    '    Catch ex As CustomException

    '        MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Catch ex As Exception

    '        MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try

    '    Return SetBindingSource

    'End Function
    Protected Friend Overrides Function SetControlsBindingOnNew() As Boolean

        Return CWorkCenter_.SetControlsBindingOnNew(Me)

    End Function

    Protected Friend Overrides Function CommandDelete() As Boolean

        Try

            With Me

                If Not CBool(Me.DataGridView.CurrentRow.Cells("is_active").Value) Then MessageBox.Show("El registro no está Activo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return CommandDelete

                If MessageBox.Show("El registro cambiará de estado a Inactivo. ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(System.Windows.Forms.DialogResult.No) Then Return CommandDelete

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------

                If Not Me.DeleteRecord() Then Me.form_state = CApplication.ControlState.InitState : Throw New CustomException("Error al eliminar.")

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

            '------------------------------------
            ' Call Child Data Refresh.
            '------------------------------------
            If Not Me.oCFormController.child_form Is Nothing Then CType(Me.oCFormController.child_form, IFormCommandRules).CommandQuery()


            Me.Activate()

            Me.DataGridView.Focus()

            ' Establece el formato de la barra de comandos.
            Call SetToolBarConfiguration(CApplication.ControlState.InitState)

            CommandQuery = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return CommandQuery

    End Function

    Protected Friend Overrides Function CommandQueryFind() As Boolean

        Try
            With Me

                '--------------------------------------------------------------------------------------------
                ' Field Assignment-Validation.
                '--------------------------------------------------------------------------------------------
                '.centro_id = CApplicationController.oCWorkCenter_.centro_id

                If String.IsNullOrEmpty(.tClaveId.Text) And String.IsNullOrEmpty(.tNombre.Text) And _
                String.IsNullOrEmpty(.tDescripcion.Text) Then

                    Throw New CustomException("Se debe proporcionar al menos un valor para la búsqueda.")

                Else

                    ' .centro_id = .tClaveId.Text

                    .id = (IIf(String.IsNullOrEmpty(tClaveId.Text.Trim()), String.Empty, .tClaveId.Text.Trim))

                    .nombre = (IIf(String.IsNullOrEmpty(.tNombre.Text.Trim()), String.Empty, .tNombre.Text.Trim))

                    .descripcion = (IIf(String.IsNullOrEmpty(.tDescripcion.Text.Trim), String.Empty, .tDescripcion.Text.Trim))

                End If

                ' Establece el formato de la barra de comandos.
                Call Me.SetToolBarConfiguration(CApplication.ControlState.Query)

                ' Limpia los controles.
                CApplication.ClearControls(Me)

                ' Inicializa el vínculos de datos.
                If Not Me.ClearControlsBinding() Then Throw New CustomException

                '--------------------------------------------------------------------------------------------
                ' Show Progress Window.
                '--------------------------------------------------------------------------------------------
                With Me.oFProgress

                    .oTypeCaller = Me.GetType
                    .oMethodInfo = .oTypeCaller.GetMethod("SetBindingSourceFilter", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)

                    .oCaller = Me

                    .StartWorker()

                    If .IsWorkDone Then

                        Call SetToolBarConfiguration(CApplication.ControlState.InitState)

                        Call SetControlsBinding()

                        ' Establece formato de los controles.
                        Call SetGridPropertiesFormat()

                        Call SetControlPropertiesFormat()

                    Else
                        Call SetToolBarConfiguration(CApplication.ControlState.Find)

                    End If

                End With
                '--------------------------------------------------------------------------------------------

                ' Establece el formato de la barra de comandos.
                '  Call SetToolBarConfiguration(CApplication.ControlState.Find)

                '-------------------------------------------------------------------------------
                ' Call Child Data Refresh.
                '-------------------------------------------------------------------------------
                If Not Me.oCFormController.child_form Is Nothing Then CType(Me.oCFormController.child_form, IFormCommandRules).CommandQuery()
                '-------------------------------------------------------------------------------

                Me.Activate()

                Me.DataGridView.Focus()

            End With

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Protected Friend Overrides Function CommandSave() As Boolean

        Try
            With Me

                '-------------------------------------------------
                ' Field Assignment-Validation.
                '-------------------------------------------------

                If (CApplication.CheckRequiredFields(.tClaveId)) Then .nombre_corto = tClaveId.Text.Trim Else Throw New CustomException

                If (CApplication.CheckRequiredFields(.tNombre)) Then .nombre = .tNombre.Text.Trim Else Throw New CustomException

                If (CApplication.CheckRequiredFields(.tDescripcion)) Then .descripcion = IIf(String.IsNullOrEmpty(.tDescripcion.Text.Trim), String.Empty, .tDescripcion.Text.Trim) Else Throw New CustomException


                If Me.form_state = CApplication.ControlState.Add Then

                    .is_active = 1

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

            CommandSave = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return CommandSave

    End Function

    Private Function SaveRecord() As Boolean

        Try

            Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

                Using oSqlCommand As New SqlCommand(Me.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

                    ' ---------------------------------
                    ' Set Command Ready and Execute
                    ' ---------------------------------
                    If Not Me.PrepareSPCommand(oSqlCommand, SPCommand.Save) Then Throw New CustomException

                    oSqlCommand.ExecuteNonQuery()

                    ' -------------------------
                    ' Handle SP Response. 
                    ' -------------------------
                    If CInt(oSqlCommand.Parameters("@response").Value.Equals(1)) Then Throw New CustomException("El registro ya existe. No se puede duplicar el registro.")

                    If CInt(oSqlCommand.Parameters("@response").Value.Equals(0)) Then MessageBox.Show("Registro dado de alta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End Using

            End Using

            SaveRecord = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return SaveRecord

    End Function

    Private Function DeleteRecord() As Boolean

        Try

            Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

                Using oSqlCommand As New SqlCommand(Me.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

                    ' ---------------------------------
                    ' Set Command Ready and Execute
                    ' ---------------------------------
                    If Not PrepareSPCommand(oSqlCommand, SPCommand.Delete) Then Throw New CustomException

                    oSqlCommand.ExecuteNonQuery()

                    ' -------------------------
                    ' Handle SP Response. 
                    ' -------------------------
                    If CInt(oSqlCommand.Parameters("@response").Value.Equals(1)) Then Throw New CustomException("Ocurrio un error al actualizar la información. " & oResponse.Value.ToString)

                    If CInt(oSqlCommand.Parameters("@response").Value.Equals(0)) Then MessageBox.Show("Registro actualizado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.DataGridView.Update()
                    Me.DataGridView.Refresh()

                End Using

            End Using

            DeleteRecord = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return DeleteRecord

    End Function

    Protected Friend Overrides Function PrepareSPCommand(ByRef oSqlCommand As SqlCommand, ByVal spCommandValue As Integer) As Boolean

        Try

            With oSqlCommand.Parameters

                ' ---------------------- 
                ' Parameter Assignation
                ' -----------------------
                Select Case spCommandValue

                    Case SPCommand.QueryAll

                        .Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
                        .Add("@command", SqlDbType.Int).Value = SPCommand.QueryAll
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                    Case SPCommand.Save

                        .Add("@nombre_corto", SqlDbType.VarChar).Value = Me.nombre_corto
                        .Add("@nombre", SqlDbType.VarChar).Value = Me.nombre
                        .Add("@descripcion", SqlDbType.VarChar).Value = Me.descripcion
                        .Add("@is_active", SqlDbType.Bit).Value = Me.is_active
                        .Add("@command", SqlDbType.Int).Value = SPCommand.Save
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                    Case SPCommand.Delete

                        .Add("@id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.id
                        .Add("@guid", SqlDbType.VarChar).Value = Me.guid
                        .Add("@command", SqlDbType.Int).Value = SPCommand.Delete
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                    Case SPCommand.Update

                        .Add("@guid", SqlDbType.VarChar).Value = Me.guid
                        .Add("@nombre_corto", SqlDbType.VarChar).Value = Me.nombre_corto
                        .Add("@nombre", SqlDbType.VarChar).Value = Me.nombre
                        .Add("@descripcion", SqlDbType.VarChar).Value = Me.descripcion
                        .Add("@is_active", SqlDbType.Bit).Value = Me.is_active
                        .Add("@command", SqlDbType.Int).Value = SPCommand.Update
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                End Select

            End With

            PrepareSPCommand = True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return PrepareSPCommand

    End Function

    Protected Friend Overrides Function SetBindingSourceFilter(ByRef oBindingSourceDummy As BindingSource) As Boolean

        Try

            Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

                Using oSqlCommand As New SqlCommand(Me.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

                    If Not PrepareSPCommand(oSqlCommand, SPCommand.Update) Then Throw New CustomException

                    Using oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

                        Using oDataSet As New DataSet

                            oSqlDataAdapter.Fill(oDataSet, Me.parent_table_name)


                            If Not CBool(CInt(oDataSet.Tables(Me.parent_table_name).Rows.Count)) Then MessageBox.Show("No existen valores en la tabla para los parámetros específicados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) : SetBindingSourceFilter = False Else SetBindingSourceFilter = True


                        End Using

                    End Using

                End Using

            End Using






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

        Return SetBindingSourceFilter

    End Function

    Protected Friend Overrides Function SetControlsBinding() As Boolean

        Return CWorkCenter_.SetControlsBinding(Me)

    End Function

    Private Function UpdateRecord() As Boolean

        Try

            Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

                Using oSqlCommand As New SqlCommand(Me.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

                    If Not Me.PrepareSPCommand(oSqlCommand, SPCommand.Update) Then Throw New CustomException

                    oSqlCommand.ExecuteNonQuery()

                    ' -------------------------
                    ' Handle SP Response. 
                    ' -------------------------
                    If CInt(oSqlCommand.Parameters("@response").Value.Equals(1)) Then Throw New CustomException("El registro ya existe. No se puede duplicar el registro.")

                    If CInt(oSqlCommand.Parameters("@response").Value.Equals(0)) Then MessageBox.Show("Registro actualizado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End Using
            End Using

            UpdateRecord = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return UpdateRecord

    End Function

    Protected Friend Overrides Sub SetControlPropertiesFormat()

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


                'For i = 0 To .TableLayoutPanel1.RowStyles.Count

                '    Select Case i
                '        Case 0

                '            .TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                '            .TableLayoutPanel1.RowStyles.Item(i).Height = 20

                '        Case 1

                '            .TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                '            .TableLayoutPanel1.RowStyles.Item(i).Height = 70

                '        Case 2
                '            .TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                '            .TableLayoutPanel1.RowStyles.Item(i).Height = 5

                '    End Select

                'Next

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

    Protected Friend Overrides Sub SetGridPropertiesFormat()

        Try
            With Me.DataGridView

                .MultiSelect = False

                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .ColumnHeadersDefaultCellStyle.Font = New Font(.Font.FontFamily, 11.0F,
                .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)

                .DefaultCellStyle.Font = New Font(.Font.FontFamily, 10.0F, FontStyle.Regular)

                ' .DefaultCellStyle.NullValue = "NA"

                '--------------------------------------------------------------------
                ' TODO 
                '
                ' Change column properties and format in accordance with data. 
                '--------------------------------------------------------------------
                .Columns("planta_id").Visible = False
                .Columns("id").Visible = False

                .Columns("guid").HeaderText = "Guid"
                .Columns("guid").Visible = True
                .Columns("guid").DisplayIndex = 1

                .Columns("nombre_corto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("nombre_corto").Visible = True
                .Columns("nombre_corto").DisplayIndex = 2

                .Columns("nombre_corto").HeaderText = "Clave"
                .Columns("nombre_corto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("nombre_corto").Visible = True
                .Columns("nombre_corto").DisplayIndex = 3

                .Columns("nombre").HeaderText = "Nombre"
                .Columns("nombre").Visible = True
                .Columns("nombre").DisplayIndex = 4

                .Columns("descripcion").HeaderText = "Descripción"
                .Columns("descripcion").Visible = True
                .Columns("descripcion").DisplayIndex = 5

                .Columns("is_active").HeaderText = "Activo"
                .Columns("is_active").Visible = True
                .Columns("is_active").DisplayIndex = 6

            End With

            'For i = 0 To Me.TableLayoutPanel1.RowStyles.Count

            '    Select Case i
            '        Case 0

            '            Me.TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
            '            Me.TableLayoutPanel1.RowStyles.Item(i).Height = 20

            '        Case 1

            '            Me.TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
            '            Me.TableLayoutPanel1.RowStyles.Item(i).Height = 70

            '        Case 2
            '            Me.TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
            '            Me.TableLayoutPanel1.RowStyles.Item(i).Height = 5

            '    End Select

            'Next


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

End Class