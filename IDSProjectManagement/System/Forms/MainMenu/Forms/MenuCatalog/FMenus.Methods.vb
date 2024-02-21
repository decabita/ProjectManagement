Imports System.Data
Imports System.Data.SqlClient
Imports System.IO


Partial Public Class FMenus
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
            Me.tMenuId.DataBindings.Clear()
            Me.tNombre.DataBindings.Clear()
            Me.tTitulo.DataBindings.Clear()
            Me.tOrden.DataBindings.Clear()

            '    Me.tDescripcion.DataBindings.Clear()
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

                If Not CBool(Me.DataGridView.CurrentRow.Cells("is_visible").Value) Then Throw New CustomException("El registro no está Activo.") : Throw New CustomException

                If MessageBox.Show("El registro cambiará de estado a Inactivo. ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(System.Windows.Forms.DialogResult.No) Then Throw New CustomException

                '-------------------------------------------------
                ' Field Assignation-Validation.
                '-------------------------------------------------
                .menu_id = .tMenuId.Text.Trim

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

            If Not CBool(Me.DataGridView.CurrentRow.Cells("is_visible").Value) Then Throw New CustomException("El registro no está Activo.")

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

                If (CApplication.CheckRequiredFields(.tMenuId)) Then .menu_id = tMenuId.Text.Trim Else Throw New CustomException

                If (CApplication.CheckRequiredFields(.tNombre)) Then .menu_nombre = .tNombre.Text.Trim Else Throw New CustomException

                .producto_descripcion = (IIf(String.IsNullOrEmpty(.tDescripcion.Text.Trim), String.Empty, .tDescripcion.Text.Trim))



                '.image_data = 'ReadImageFile()

                If Me.form_state = CApplication.ControlState.Add Then

                    .is_visible = 1
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

                    .is_visible = .ckVisible.Checked

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

            oSqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@menu_id", SqlDbType.VarChar).Value = Me.menu_id

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
        oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
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
                    .DisplayMember = "menu_nombre"
                    .ValueMember = "menu_id"
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
            oSqlCommand.Parameters.Add("@menu_id", SqlDbType.VarChar).Value = Me.menu_id
            oSqlCommand.Parameters.Add("@menu_nombre", SqlDbType.VarChar).Value = Me.menu_nombre

            oSqlCommand.Parameters.Add("@menu_caption", SqlDbType.VarChar).Value = Me.menu_caption

            oSqlCommand.Parameters.Add("@is_visible", SqlDbType.Bit).Value = Me.is_visible

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
                .tMenuId.DataBindings.Add("text", Me.oBindingSourceParent, "menu_id", True)

                .tNombre.DataBindings.Add("text", Me.oBindingSourceParent, "menu_nombre", True)

                .tTitulo.DataBindings.Add("text", Me.oBindingSourceParent, "menu_caption", True)

                .tOrden.DataBindings.Add("text", Me.oBindingSourceParent, "menu_order", True)

                '   .tDescripcion.DataBindings.Add("text", Me.oBindingSourceParent, "producto_descripcion", True).NullValue = CApplication.NotAssignedValue


                ' -------------------------------------------------------------
                ' CHECK BOX BINDING. 
                ' -------------------------------------------------------------
                .ckVisible.DataBindings.Add("CheckState", Me.oBindingSourceParent, "is_visible", True)

                ' -------------------------------------------------------------
                ' PICTURE BOX BINDING. 
                ' -------------------------------------------------------------
                '  Me.PictureBox.DataBindings.Add("Image", Me.oBindingSourceParent, "image_data", True).NullValue = New Bitmap(Global.Atlas_Pavco.My.Resources.NoImage)
                ', DataSourceUpdateMode.OnPropertyChanged, New Bitmap(Global.Atlas_Pavco.My.Resources.NoImage))


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

        oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_SYS_MENUS")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.QueryAll

        oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
        oResponse.Direction = ParameterDirection.Output

        Try

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return SetBindingSourceParent

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)
            oSqlDataAdapter.Fill(oDataSet, "GetMenusData")

            If Not CBool(CInt(oDataSet.Tables("GetMenusData").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla.")

            oBindingSourceDummy = New BindingSource
            oBindingSourceDummy.DataSource = oDataSet
            oBindingSourceDummy.DataMember = "GetMenusData"

            SetBindingSourceParent = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            'If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            ' If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

        Return SetBindingSourceParent

    End Function

    Private Sub SetControlPropertiesFormat() Implements IToolBoxCommand.SetControlPropertiesFormat

        Try
            With Me

                .tMenuId.Tag = "Clave"
                .tMenuId.MaxLength = 18
                .tMenuId.TextAlign = HorizontalAlignment.Right

                .tNombre.Tag = "Nombre"
                .tNombre.MaxLength = 80
                .tNombre.TextAlign = HorizontalAlignment.Left

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

                ' ------------------------------------------
                ' Grid Columns.
                ' ------------------------------------------

                .Columns("menu_id").HeaderText = "Clave"
                .Columns("menu_id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("menu_id").Visible = True
                .Columns("menu_id").DisplayIndex = 0

                .Columns("menu_nombre").HeaderText = "Nombre"
                .Columns("menu_nombre").Visible = True
                .Columns("menu_nombre").DisplayIndex = 1

                .Columns("menu_caption").HeaderText = "Título"
                .Columns("menu_caption").Visible = True
                .Columns("menu_caption").DisplayIndex = 2

                .Columns("menu_order").HeaderText = "Posición"
                .Columns("menu_order").Visible = True
                .Columns("menu_order").DisplayIndex = 3

                .Columns("is_visible").HeaderText = "Visible"
                .Columns("is_visible").Visible = True
                .Columns("is_visible").DisplayIndex = 4

            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub SetToolBarConfiguration(ByVal State As Integer) Implements IToolBoxCommand.SetToolBarConfiguration

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

                    '  Call CApplication.EnableColumn(Me.DataGridView.Columns("menu_id"), False)


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

                    Me.tMenuId.Focus()

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

                    Me.tMenuId.Enabled = False

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

        Return UpdateCommand

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

            UpdateRecord = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()


        End Try

        Return UpdateRecord

    End Function

End Class