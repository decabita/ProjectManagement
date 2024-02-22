Imports System.Data
Imports System.Data.SqlClient
Imports System.IO


Partial Public Class FButtons
    Implements IToolBoxCommand


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.oFormController = New CFormController_
        Me.oFormController.parent_form = Me
        Me.view_mode = CApplication.ViewMode.SingleView
        Me.form_state = CApplication.ControlState.InitState

    End Sub

    Private Function ClearControlsBinding() As Boolean Implements IToolBoxCommand.ClearControlsBinding

        Try

            ' -------------------------------------------
            ' Clear Binding.
            ' -------------------------------------------
            Me.tButtonId.DataBindings.Clear()
            Me.tOrden.DataBindings.Clear()
            Me.tNombre.DataBindings.Clear()
            Me.tCaption.DataBindings.Clear()
            Me.tDescripcion.DataBindings.Clear()
            Me.cbNiveles.DataBindings.Clear()
            Me.cbMenu.DataBindings.Clear()
            Me.ckVisible.DataBindings.Clear()

            Me.DataGridView.DataSource = Nothing

            Me.BindingNavigator.DataBindings.Clear()

            oDataSet = New DataSet

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

                    oBindingSourceParent.CancelEdit()

                    Call CommandQuery()

                ElseIf Me.form_state.Equals(CApplication.ControlState.Edit) Then

                    oBindingSourceParent.CancelEdit()

                End If

            Case CApplication.ViewMode.Multiview

                '---------------------------------------
                ' There is a new record without editing.
                '---------------------------------------
                If newRow > 0 AndAlso DataGridView.IsCurrentRowDirty Then

                    Me.DataGridView.CancelEdit()
                    Me.DataGridView.Refresh()

                    oBindingSourceParent.CancelEdit()
                    '---------------------------------------
                    ' There is a new record without editing.
                    '---------------------------------------
                Else

                    Me.DataGridView.CancelEdit()
                    Me.DataGridView.Refresh()

                    oBindingSourceParent.CancelEdit()
                    Me.DataGridView.Refresh()

                    '  Me.DataGridView.Update()

                End If


        End Select

        Call SetToolBarConfiguration(CApplication.ControlState.InitState)

    End Function

    Public Function CommandDelete() As Boolean Implements IToolBoxCommand.CommandDelete

        Try

            With Me

                If Not CBool(Me.DataGridView.CurrentRow.Cells("is_active").Value) Then Throw New CustomException("El registro no está Activo.") : Throw New CustomException

                If MessageBox.Show("El registro cambiará de estado a Inactivo. ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(System.Windows.Forms.DialogResult.No) Then Throw New CustomException

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------
                .producto_id = .tButtonId.Text.Trim

                If Not DeleteRecord() Then Me.form_state = CApplication.ControlState.InitState : Throw New CustomException

                Call CommandQuery()

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

            If Not CBool(Me.DataGridView.CurrentRow.Cells("is_active").Value) Then Throw New CustomException("El registro no está Activo.")

            ' Dim rButton As RadioButton = 
            ' GroupBox1.Controls()
            ' .OfType(Of RadioButton)()
            ' .Where(Function(r) r.Checked = True)
            '.FirstOrDefault()

            ' Establece el formato de la barra de comandos.
            Call SetToolBarConfiguration(CApplication.ControlState.Edit)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Function
    Public Function CommandExit() As Boolean Implements IToolBoxCommand.CommandExit

        ' If Not (Me.form_state.Equals(CApplication.ControlState.InitState)) And Not (Me.form_state.Equals(CApplication.ControlState.None)) Then

        'Call CommandCancel()

        'End If


        DirectCast(Me.ParentForm, MDIMainContainer).Dispose()
        '   Me.Dispose()

    End Function

    Public Function CommandNew() As Boolean Implements IToolBoxCommand.CommandNew

        '  If Not CFormController.child_form Is Nothing Then CFormController.child_form.Close()

        ' Establece el formato de la barra de comandos.
        Call CApplication.ClearControlBinding(Me) : Call SetToolBarConfiguration(CApplication.ControlState.Add)

        '  Call me.ClearControlsBinding()

    End Function

    Public Function CommandQuery() As Boolean Implements IToolBoxCommand.CommandQuery

        Try

            '   If Not CFormController.child_form Is Nothing Then CFormController.child_form.Close()

            ' Establece el formato de la barra de comandos.
            Call SetToolBarConfiguration(CApplication.ControlState.Query)
            '     'Application.DoEvents()

            ' Limpia los controles.
            CApplication.ClearControls(Me)

            ' Inicializa el vínculos de datos.
            If Not Me.ClearControlsBinding() Then Throw New CustomException

            ' Executes Query.
            Me.BWorkerGetProducts.RunWorkerAsync()

            ' Muestra la ventana de progreso.
            Me.oFProgress = New FProgress
            Me.oFProgress.ShowDialog()


            '            If Not DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.child_form Is Nothing Then DirectCast(DirectCast(Me.ParentForm, MDIMainContainer).oCFormController_.child_form, FBomChild).CommandQuery()


            If Not oFormController.child_form Is Nothing Then

                Select Case oFormController.child_form.Name

                    Case "FBomChild"

                        'DirectCast(oFormController.child_form, FBomChild).CommandQuery()

                    Case "FEspecificacionesChild"

                        'DirectCast(oFormController.child_form, FEspecificacionesChild).CommandQuery()


                End Select


            End If

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

                If (CApplication.CheckRequiredFields(.tButtonId)) Then .producto_id = tButtonId.Text.Trim Else Throw New CustomException

                If (CApplication.CheckRequiredFields(.tNombre)) Then .producto_nombre = .tNombre.Text.Trim Else Throw New CustomException

                .producto_descripcion = (IIf(String.IsNullOrEmpty(.tDescripcion.Text.Trim), String.Empty, .tDescripcion.Text.Trim))

                If Not (CApplication.CheckRequiredFields(.cbMenu)) Then Exit Function Else .tipo_id = .cbMenu.SelectedValue.Trim

                If Not (CApplication.CheckRequiredFields(.cbNiveles)) Then Exit Function Else .unidad_id = .cbNiveles.SelectedValue.Trim


                '.image_data = 'ReadImageFile()

                If Me.form_state = CApplication.ControlState.Add Then

                    .is_active = 1
                    ' .image_data = Nothing  'SaveImageFile()

                    If Not SaveRecord() Then

                        CommandCancel() : Throw New CustomException

                    Else

                        Me.oBindingSourceParent.EndEdit()
                        Me.oBindingSourceParent.ResetBindings(False)

                        Call CommandQuery()

                        Call SetToolBarConfiguration(CApplication.ControlState.InitState)

                    End If

                ElseIf Me.form_state = CApplication.ControlState.Edit Then

                    .is_active = .ckVisible.Checked

                    If Not UpdateRecord() Then

                        CommandCancel() : Throw New CustomException

                    Else

                        Me.oBindingSourceParent.EndEdit()
                        Me.oBindingSourceParent.ResetBindings(False)

                        Call SetToolBarConfiguration(CApplication.ControlState.InitState)

                        ' Call CommandQuery()

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

            oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_PARTS_")
            oSqlCommand.CommandType = CommandType.StoredProcedure

            oSqlCommand.Parameters.Add("@centro_id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@producto_id", SqlDbType.VarChar).Value = Me.producto_id

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.Delete

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()


            oSqlCommand.ExecuteNonQuery()

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

    Public Shared Function FillComboParts() As ComboBox

        Dim oComboDummy As ComboBox = Nothing

        Dim oDataSet As New DataSet()
        Dim oSqlCommand As SqlCommand
        Dim oResponse As SqlParameter

        oDataSet = New DataSet
        oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_PARTS_")
        oSqlCommand.CommandType = CommandType.StoredProcedure
        oSqlCommand.Parameters.Add("@centro_id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
        oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.QueryAll

        oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
        oResponse.Direction = ParameterDirection.Output

        Try
            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            Dim oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "Combo_Parts")

            If Not CBool(CInt(oDataSet.Tables("Combo_Parts").Rows.Count)) Then

                With oComboDummy
                    .DataSource = oDataSet.Tables("Combo_Parts")
                    .DisplayMember = "producto_nombre"
                    .ValueMember = "producto_id"
                End With

            Else

                MessageBox.Show("No existe información para los productos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return oComboDummy

    End Function

    Public Shared Function ImageToByte(ByVal img As Image) As Byte()
        Dim imgStream As MemoryStream = New MemoryStream()

        img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Gif)

        imgStream.Close()
        Dim byteArray As Byte() = imgStream.ToArray()
        imgStream.Dispose()

        Return byteArray
    End Function
    Private Function PrepareCommand(ByVal value As Integer) As Boolean

        Try
            oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_PARTS_")
            oSqlCommand.CommandType = CommandType.StoredProcedure

            oSqlCommand.Parameters.Add("@centro_id", SqlDbType.VarChar).Value = Me.centro_id
            oSqlCommand.Parameters.Add("@producto_id", SqlDbType.VarChar).Value = Me.producto_id
            oSqlCommand.Parameters.Add("@producto_nombre", SqlDbType.VarChar).Value = Me.producto_nombre
            oSqlCommand.Parameters.Add("@producto_descripcion", SqlDbType.VarChar).Value = Me.producto_descripcion
            oSqlCommand.Parameters.Add("@tipo_id", SqlDbType.VarChar).Value = Me.tipo_id

            oSqlCommand.Parameters.Add("@unidad_id", SqlDbType.VarChar).Value = Me.unidad_id

            oSqlCommand.Parameters.Add("@is_active", SqlDbType.Bit).Value = Me.is_active

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = value

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
            If Not SetBindingSourceParent(Me.oBindingSourceParent) Then Throw New CustomException

            Return True

        Catch ex As CustomException

            Exit Function

        End Try

    End Function

    Public Function SaveImageFile() As Byte()

        If String.IsNullOrEmpty(Me.ruta_imagen) Then Return Nothing

        ' Initialize byte array with a null value initially.
        Dim data As Byte() = Nothing

        'Use FileInfo object to get file size.
        Dim fInfo As FileInfo = New FileInfo(Me.ruta_imagen)
        Dim numBytes As Long = fInfo.Length

        ' Open FileStream to read file
        Dim fStream As FileStream = New FileStream(Me.ruta_imagen, FileMode.Open, FileAccess.Read)

        ' Use BinaryReader to read file stream into byte array.
        Dim br As BinaryReader = New BinaryReader(fStream)

        ' When you use BinaryReader, you need to supply number of bytes to read from file.
        ' In this case we want to read entire file. So supplying total number of bytes.
        data = br.ReadBytes(CInt(numBytes))

        Return data

    End Function

    Private Function SaveRecord() As Boolean

        oResponse = New SqlParameter

        Try

            If Not PrepareCommand(SPCommand.SaveCommand) Then Throw New CustomException

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            oSqlCommand.ExecuteNonQuery()

            If CInt(oResponse.Value.Equals(1)) Then Throw New CustomException("El registro ya existe en Gears. No se puede duplicar el registro.")

            If CInt(oResponse.Value.Equals(0)) Then MessageBox.Show("Registro dado de alta en Gears.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            '    If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function


    Public Function SetControlsBinding() As Boolean Implements IToolBoxCommand.SetControlsBinding

        Try
            ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            ' CONTROL BINDING 
            ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            With Me

                ' -------------------------------------------------------------
                ' TEXTBOX BINDING.
                ' -------------------------------------------------------------
                .tButtonId.DataBindings.Add("text", Me.oBindingSourceParent, "button_id", True)

                .tOrden.DataBindings.Add("text", Me.oBindingSourceParent, "button_order", True).NullValue = CApplication.NotAssignedValue

                .tNombre.DataBindings.Add("text", Me.oBindingSourceParent, "button_name", True).NullValue = CApplication.NotAssignedValue

                .tCaption.DataBindings.Add("text", Me.oBindingSourceParent, "button_caption", True).NullValue = CApplication.NotAssignedValue

                .tDescripcion.DataBindings.Add("text", Me.oBindingSourceParent, "button_caption", True).NullValue = CApplication.NotAssignedValue

                ' -------------------------------------------------------------
                ' CHECK BOX BINDING. 
                ' -------------------------------------------------------------
                .ckVisible.DataBindings.Add("CheckState", Me.oBindingSourceParent, "is_active", True)

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

            If CApplication.GetComboNivelesMenu(Me.oBSourceCombo) Then Me.oCollectionBSourceCombo.Add(Me.oBSourceCombo, "ComboNivelesMenu") Else Throw New CustomException

            If CApplication.GetComboMenus(Me.oBSourceCombo) Then Me.oCollectionBSourceCombo.Add(Me.oBSourceCombo, "ComboMenus") Else Throw New CustomException

            ' 2. Add combo to Form in Simple View.

            With Me.cbNiveles
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboNivelesMenu")
                .DisplayMember = "combo_niveles"
                .ValueMember = "level_id"
                .DataBindings.Add("SelectedValue", oBindingSourceParent, "level_id")
            End With

            '++
            With Me.cbMenu
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboMenus")
                .DisplayMember = "combo_menus"
                .ValueMember = "menu_id"
                .DataBindings.Add("SelectedValue", oBindingSourceParent, "menu_id")
            End With

            ' ++



            ' 3. Add combo to Grid in Multi View.

            Dim gcNiveles As New DataGridViewComboBoxColumn

            With gcNiveles
                .DisplayMember = "combo_niveles"
                .ValueMember = "level_id"
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboNivelesMenu")
                .DataPropertyName = "level_id"
                .HeaderText = "Nivel"
                .Name = "level_id"
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Me.DataGridView.Columns.Add(gcNiveles)

            Dim gcMenus As New DataGridViewComboBoxColumn

            With gcMenus
                .DisplayMember = "combo_menus"
                .ValueMember = "menu_id"
                .DataSource = Me.oCollectionBSourceCombo.Item("ComboMenus")
                .DataPropertyName = "menu_id"
                .HeaderText = "Menu"
                .Name = "menu_id"
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Me.DataGridView.Columns.Add(gcMenus)

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

    Private Function SetBindingSourceParent(ByRef oBindingSourceDummy As BindingSource) As Boolean

        Dim oResponse As New SqlParameter
        Dim oSqlCommand As SqlCommand


        oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_SYS_MENU_BUTTON")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.QueryAll

        oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
        oResponse.Direction = ParameterDirection.Output

        ' oDataSet.Clear()

        Try

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)
            oSqlDataAdapter.Fill(oDataSet, "GetButtonsData")

            If Not CBool(CInt(oDataSet.Tables("GetButtonsData").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla.")

            oBindingSourceDummy = New BindingSource
            oBindingSourceDummy.DataSource = oDataSet
            oBindingSourceDummy.DataMember = "GetButtonsData"

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            'If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            ' If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Private Sub SetControlPropertiesFormat() Implements IToolBoxCommand.SetControlPropertiesFormat

        Try
            With Me

                .tButtonId.Tag = "Clave"
                .tButtonId.MaxLength = 18
                .tButtonId.TextAlign = HorizontalAlignment.Right

                .tOrden.Tag = "Posición"
                .tOrden.MaxLength = 2
                .tOrden.TextAlign = HorizontalAlignment.Left

                .tNombre.Tag = "Nombre"
                .tNombre.MaxLength = 80
                .tNombre.TextAlign = HorizontalAlignment.Left

                .tCaption.Tag = "Etiqueta"
                .tCaption.MaxLength = 80
                .tCaption.TextAlign = HorizontalAlignment.Left

                .tDescripcion.Tag = "Descripción"
                .tDescripcion.MaxLength = 120
                .tDescripcion.TextAlign = HorizontalAlignment.Left

                .ckVisible.Tag = "Activo"

                .DataGridView.Tag = "DataGrid"

            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

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

                Exit Sub
                .Columns("centro_id").Visible = False

                .Columns("producto_id").HeaderText = "Clave"
                .Columns("producto_id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("producto_id").Visible = True
                .Columns("producto_id").DisplayIndex = 1

                .Columns("producto_nombre").HeaderText = "Nombre"
                .Columns("producto_nombre").Visible = True
                .Columns("producto_nombre").DisplayIndex = 2

                ' ------------------------------------------
                ' Grid Columns.
                ' ------------------------------------------
                .Columns("tipo_id").Visible = True
                .Columns("tipo_id").DisplayIndex = 3

                .Columns("unidad_id").Visible = True
                .Columns("unidad_id").DisplayIndex = 4
                ' ------------------------------------------
                .Columns("producto_descripcion").HeaderText = "Descripción"
                .Columns("producto_descripcion").Visible = True
                .Columns("producto_descripcion").DisplayIndex = 5

                .Columns("is_active").HeaderText = "Activo"
                .Columns("is_active").Visible = True
                .Columns("is_active").DisplayIndex = 6

                '     .Columns("image_data").Visible = False

            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub SetToolBarConfiguration(ByVal State As Integer)

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

                    Me.tButtonId.Focus()

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

                    Me.tButtonId.Enabled = False

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

        DirectCast(Me.ParentForm, MDIMainContainer).MDIFormState.Text = CApplication.GetFormStateDescription(Me.form_state)

        '     Call SetControlPropertiesFormat()

    End Sub

    Public Function UpdateCommand() As Boolean Implements IToolBoxCommand.UpdateCommand

    End Function

    Private Function UpdateRecord() As Boolean

        oResponse = New SqlParameter

        Try

            If Not PrepareCommand(SPCommand.Update) Then Throw New CustomException

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            oSqlCommand.ExecuteNonQuery()


            If CInt(oResponse.Value.Equals(1)) Then Throw New CustomException("El registro ya existe en Gears. No se puede duplicar el registro.")

            If CInt(oResponse.Value.Equals(0)) Then MessageBox.Show("Registro actualizado en Gears.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()


        End Try

    End Function

End Class