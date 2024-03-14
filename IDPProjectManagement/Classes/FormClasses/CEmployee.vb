﻿Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class CEmployee

    Enum SPCommand
        None = 0
        QueryAll = 1
        Add = 2
        Update = 3
        Save = 4
        Delete = 5
        QueryById = 6
        CheckIfPartExists = 7
        QueryFilter = 8
        GetRelatedSpecs = 30
    End Enum

    Shared _oCurrentForm As New Form
    Shared Property CurrentForm() As Form
        Get
            Return _oCurrentForm
        End Get
        Set(ByVal value As Form)
            _oCurrentForm = value
        End Set
    End Property

    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private Property  _guid As String
    Public Property guid() As String
        Get
            Return _guid
        End Get
        Set(ByVal value As String)
            _guid = value
        End Set
    End Property

    Private _centro_id As Integer
    Public Property centro_id() As Integer
        Get
            Return _centro_id
        End Get
        Set(ByVal value As Integer)
            _centro_id = value
        End Set
    End Property

    Private _nombre_corto As String
    Public Property nombre_corto() As String
        Get
            Return _nombre_corto
        End Get
        Set(ByVal value As String)
            _nombre_corto = value
        End Set
    End Property

    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _rfc As String
    Public Property rfc() As String
        Get
            Return _rfc
        End Get
        Set(ByVal value As String)
            _rfc = value
        End Set
    End Property

    Private _razon_social As String
    Public Property razon_social() As String
        Get
            Return _razon_social
        End Get
        Set(ByVal value As String)
            _razon_social = value
        End Set
    End Property

    Private _contacto As String
    Public Property contacto() As String
        Get
            Return _contacto
        End Get
        Set(ByVal value As String)
            _contacto = value
        End Set
    End Property

    Private _email As String
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _telefono As String
    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property
    Private _celular As String
    Public Property celular() As String
        Get
            Return _celular
        End Get
        Set(ByVal value As String)
            _celular = value
        End Set
    End Property

    Private _pais As String
    Public Property pais() As String
        Get
            Return _pais
        End Get
        Set(ByVal value As String)
            _pais = value
        End Set
    End Property

    Private _ciudad As String
    Public Property ciudad() As String
        Get
            Return _ciudad
        End Get
        Set(ByVal value As String)
            _ciudad = value
        End Set
    End Property
    Private _calle As String
    Public Property calle() As String
        Get
            Return _calle
        End Get
        Set(ByVal value As String)
            _calle = value
        End Set
    End Property
    Private _numero_ext As Integer
    Public Property numero_ext() As Integer
        Get
            Return _numero_ext
        End Get
        Set(ByVal value As Integer)
            _numero_ext = value
        End Set
    End Property

    Private _numero_int As Integer
    Public Property numero_int() As Integer
        Get
            Return _numero_int
        End Get
        Set(ByVal value As Integer)
            _numero_int = value
        End Set
    End Property

    Private _colonia As String
    Public Property colonia() As String
        Get
            Return _colonia
        End Get
        Set(ByVal value As String)
            _colonia = value
        End Set
    End Property

    Private _delegacion As String
    Public Property delegacion() As String
        Get
            Return _delegacion
        End Get
        Set(ByVal value As String)
            _delegacion = value
        End Set
    End Property

    Private _codigo_postal As Integer
    Public Property codigo_postal() As Integer
        Get
            Return _codigo_postal
        End Get
        Set(ByVal value As Integer)
            _codigo_postal = value
        End Set
    End Property

    Private _descripcion As String
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _is_active As Boolean
    Public Property is_active() As Boolean
        Get
            Return _is_active
        End Get
        Set(ByVal value As Boolean)
            _is_active = value
        End Set
    End Property

    Public Sub New()
        Initialize()

    End Sub

    Private Sub Initialize()

        For Each prop As PropertyDescriptor In TypeDescriptor.GetProperties(Me)

            Select Case prop.PropertyType.Name

                Case "String"

                    prop.SetValue(Me, String.Empty)

                Case "Boolean"

                    prop.SetValue(Me, False)

                Case "Int32"
                    prop.SetValue(Me, -1)

            End Select
        Next

    End Sub

    Friend Function GetClassData(guid As String) As CEmployee

        Try

            Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

                Using oSqlCommand As New SqlCommand("dbo.SP_EMPLOYEES", oConnection) With {.CommandType = CommandType.StoredProcedure}

                    With oSqlCommand.Parameters
                        .Add("@centro_id", SqlDbType.Int).Value = CApplicationController.oCWorkCenter_.id
                        .Add("@guid", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
                        .Add("@command", SqlDbType.Int).Value = SPCommand.QueryById

                        Dim oSqlParameterResponse = .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                    End With

                    Using oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

                        Using oDataSet As New DataSet

                            oSqlDataAdapter.Fill(oDataSet, "MainTable")

                            If Not CBool(CInt(oDataSet.Tables("MainTable").Rows.Count)) Then Throw New CustomException("No hay información en la tabla.")

                            With oDataSet.Tables("MainTable").Rows(0)

                                'Me.guid = .Item("guid")
                                'Me.id = .Item("id")
                                'Me.centro_id = .Item("centro_id")
                                'Me.nombre_corto = .Item("nombre_corto").ToString.Trim
                                'Me.nombre = .Item("nombre").ToString.Trim
                                'Me.rfc = .Item("rfc").ToString.Trim
                                'Me.razon_social = .Item("razon_social").ToString.Trim
                                'Me.contacto = .Item("contacto").ToString.Trim
                                'Me.email = .Item("email").ToString.Trim
                                'Me.telefono = .Item("telefono").ToString.Trim
                                'Me.celular = .Item("celular").ToString.Trim
                                'Me.pais = .Item("pais").ToString.Trim
                                'Me.ciudad = .Item("ciudad").ToString.Trim
                                'Me.calle = .Item("calle").ToString.Trim
                                'Me.numero_ext = .Item("numero_ext")
                                'Me.numero_int = .Item("numero_int")
                                'Me.colonia = .Item("colonia").ToString.Trim
                                'Me.delegacion = .Item("delegacion").ToString.Trim
                                'Me.codigo_postal = .Item("codigo_postal")
                                'Me.descripcion = .Item("descripcion").ToString.Trim
                                'Me.is_active = .Item("is_active")

                                For Each prop As PropertyDescriptor In TypeDescriptor.GetProperties(Me)

                                    Select Case prop.PropertyType.Name

                                        Case "String"

                                            prop.SetValue(Me, .Item(prop.Name).ToString.Trim)

                                        Case "Boolean"

                                            prop.SetValue(Me, .Item(prop.Name))

                                        Case "Int32"

                                            prop.SetValue(Me, .Item(prop.Name))

                                    End Select
                                Next

                            End With

                        End Using
                    End Using
                End Using
            End Using

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return Me

    End Function
    Public Shared Function FillCustomersCombo(ByRef oComboDummy As ComboBox) As Boolean

        ' Call  combo filler
        If Not CApplication.FillComboWithData(oComboDummy) Then Return FillCustomersCombo

        Return FillCustomersCombo = True

    End Function


    Public Shared Function SetControlsBinding(ByVal oForm As FEmployees) As Boolean

        Try

            With oForm
                ' ----------------
                ' TEXTBOX BINDING.
                ' ----------------

                .tGuid.DataBindings.Add("text", .oBindingSource, "guid", True)

                .tClaveId.DataBindings.Add("text", .oBindingSource, "nombre_corto", True)

                .tNombre.DataBindings.Add("text", .oBindingSource, "nombre", True)

                .tDescripcion.DataBindings.Add("text", .oBindingSource, "descripcion", True).NullValue = CApplication.NotAssignedValue

                ' ------------------------
                ' CHECK BOX BINDING. 
                ' ------------------------
                .ckActivo.DataBindings.Add("CheckState", .oBindingSource, "is_active", True)

                ' -------------------------------------------------------------
                ' PICTURE BOX BINDING. 
                ' -------------------------------------------------------------

                ' -------------------
                ' COMBO BINDING.
                ' -------------------

                ' --------------------------------------
                ' Get combo data for each Combobox in Form.
                ' --------------------------------------

                ' 1. Fill Combo Binding Source and Add Combo Binding Source to Collection.

                ' 2. Add combo to Form in Simple View.

                ' 3. Add combo to Grid in Multi View.

                ' -------------------------------------------------------------
                ' DATAGRIDVIEW BINDING.
                ' -------------------------------------------------------------
                .DataGridView.DataSource = .oBindingSource

                ' -------------------------------------------------------------
                ' NAVIGATOR BINDING.
                ' -------------------------------------------------------------
                .BindingNavigator.BindingSource = .oBindingSource

                ' -------------------------------------------------------------
                ' Reset Binding.
                ' -------------------------------------------------------------
                .oBindingSource.ResetBindings(False)

            End With

            SetControlsBinding = True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return SetControlsBinding

    End Function


    Public Shared Sub SetGridPropertiesFormat(ByVal oForm As FEmployees)

        Try
            With oForm.DataGridView

                .MultiSelect = False

                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .ColumnHeadersDefaultCellStyle.Font = New Font(.Font.FontFamily, 11.0F,
                .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)

                .DefaultCellStyle.Font = New Font(.Font.FontFamily, 10.0F, FontStyle.Regular)

                .AutoGenerateColumns = False

                ' .DefaultCellStyle.NullValue = "NA"

                '--------------------------------------------------------------------
                ' TODO 
                '
                ' Change column properties and format in accordance with data. 
                '--------------------------------------------------------------------
                Dim index As Integer

                index = 0

                .Columns("centro_id").Visible = False
                .Columns("id").Visible = False

                .Columns("guid").HeaderText = "Guid"
                .Columns("guid").Visible = True
                .Columns("guid").DisplayIndex = index
                index += 1
                .Columns("nombre_corto").HeaderText = "Clave"
                .Columns("nombre_corto").Visible = True
                .Columns("nombre_corto").DisplayIndex = index
                index += 1
                .Columns("nombre").HeaderText = "Nombre"
                .Columns("nombre").Visible = True
                .Columns("nombre").DisplayIndex = index
                index += 1
                .Columns("descripcion").HeaderText = "Descripción"
                .Columns("descripcion").Visible = True
                .Columns("descripcion").DisplayIndex = index
                index += 1
                .Columns("email").HeaderText = "Email"
                .Columns("email").Visible = True
                .Columns("email").DisplayIndex = index
                index += 1
                .Columns("telefono").HeaderText = "Teléfono"
                .Columns("telefono").Visible = True
                .Columns("telefono").DisplayIndex = index
                index += 1
                .Columns("celular").HeaderText = "Celular"
                .Columns("celular").Visible = True
                .Columns("celular").DisplayIndex = index
                index += 1
                .Columns("pais").HeaderText = "País"
                .Columns("pais").Visible = True
                .Columns("pais").DisplayIndex = index
                index += 1
                .Columns("ciudad").HeaderText = "Ciudad"
                .Columns("ciudad").Visible = True
                .Columns("ciudad").DisplayIndex = index
                index += 1
                .Columns("calle").HeaderText = "Calle"
                .Columns("calle").Visible = True
                .Columns("calle").DisplayIndex = index
                index += 1
                .Columns("numero_ext").HeaderText = "Número Ext."
                .Columns("numero_ext").Visible = True
                .Columns("numero_ext").DisplayIndex = index
                index += 1
                .Columns("numero_int").HeaderText = "Número Int."
                .Columns("numero_int").Visible = True
                .Columns("numero_int").DisplayIndex = index
                index += 1
                .Columns("colonia").HeaderText = "Colonia"
                .Columns("colonia").Visible = True
                .Columns("colonia").DisplayIndex = index
                index += 1
                .Columns("delegacion").HeaderText = "Delegación"
                .Columns("delegacion").Visible = True
                .Columns("delegacion").DisplayIndex = index
                index += 1
                .Columns("codigo_postal").HeaderText = "Código Postal"
                .Columns("codigo_postal").Visible = True
                .Columns("codigo_postal").DisplayIndex = index
                index += 1
                .Columns("is_active").HeaderText = "Activo"
                .Columns("is_active").Visible = True
                .Columns("is_active").DisplayIndex = index

            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Shared Function SetControlsBindingOnNew(ByVal oForm As FEmployees) As Boolean

        Try

            With oForm

                ' ----------------------
                ' TEXTBOX BINDING.
                ' ----------------------

                ' ----------------------
                ' CHECK BOX BINDING. 
                ' ----------------------

                ' -------------------------------------------------------------
                ' PICTURE BOX BINDING. 
                ' -------------------------------------------------------------

                ' -------------------------------------------------------------
                ' COMBO BINDING.
                ' -------------------------------------------------------------
                ' -------------------------------------------------------------
                ' Get combo data for each Combobox in Form.
                ' -------------------------------------------------------------

                ' 1. Fill Combo Binding Source and Add Combo Binding Source to Collection.

                ' 2. Add combo to Form in Simple View.

                ' 3. Add combo to Grid in Multi View.

                ' -------------------------
                ' DATAGRIDVIEW BINDING.
                ' -------------------------

                ' -------------------------
                ' NAVIGATOR BINDING.
                ' -------------------------

                ' -------------------------
                ' Reset Binding.
                ' -------------------------

            End With

            SetControlsBindingOnNew = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return SetControlsBindingOnNew

    End Function

    Public Shared Sub SetControlPropertiesFormat(ByVal oForm As FEmployees)

        Try
            With oForm

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

    Public Shared Sub SetGeneralFormat(ByVal oForm As FEmployees)

        With oForm

            ' Add behaviour events to controls.
            AddHandler .tClaveId.GotFocus, AddressOf CApplication.HandleGotFocus
            AddHandler .tClaveId.LostFocus, AddressOf CApplication.HandleLostFocus
            AddHandler .tClaveId.KeyPress, AddressOf CApplication.HandleNotSpaces

            AddHandler .tNombre.GotFocus, AddressOf CApplication.HandleGotFocus
            AddHandler .tNombre.LostFocus, AddressOf CApplication.HandleLostFocus

            AddHandler .tDescripcion.GotFocus, AddressOf CApplication.HandleGotFocus
            AddHandler .tDescripcion.LostFocus, AddressOf CApplication.HandleLostFocus

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

    End Sub


    Public Shared Sub PrepareSPCommand(ByVal oSqlCommand As SqlCommand, ByVal spCommandValue As Integer, ByVal oForm As Form)

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

                        .Add("@centro_id", SqlDbType.VarChar).Value = DirectCast(oForm, FEmployees).FormRelatedClass.centro_id
                        .Add("@nombre_corto", SqlDbType.VarChar).Value = DirectCast(oForm, FEmployees).FormRelatedClass.nombre_corto
                        .Add("@nombre", SqlDbType.VarChar).Value = DirectCast(oForm, FEmployees).FormRelatedClass.nombre
                        .Add("@descripcion", SqlDbType.VarChar).Value = DirectCast(oForm, FEmployees).FormRelatedClass.descripcion
                        .Add("@is_active", SqlDbType.Bit).Value = DirectCast(oForm, FEmployees).FormRelatedClass.is_active
                        .Add("@command", SqlDbType.Int).Value = SPCommand.Save
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                    Case SPCommand.Delete

                        .Add("@centro_id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.id
                        .Add("@guid", SqlDbType.VarChar).Value = DirectCast(oForm, FEmployees).FormRelatedClass.guid
                        .Add("@command", SqlDbType.Int).Value = SPCommand.Delete
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                    Case SPCommand.Update

                        .Add("@centro_id", SqlDbType.VarChar).Value = CApplicationController.oCWorkCenter_.id
                        .Add("@guid", SqlDbType.VarChar).Value = DirectCast(oForm, FEmployees).FormRelatedClass.guid
                        .Add("@nombre_corto", SqlDbType.VarChar).Value = DirectCast(oForm, FEmployees).FormRelatedClass.nombre_corto
                        .Add("@nombre", SqlDbType.VarChar).Value = DirectCast(oForm, FEmployees).FormRelatedClass.nombre
                        .Add("@descripcion", SqlDbType.VarChar).Value = DirectCast(oForm, FEmployees).FormRelatedClass.descripcion
                        .Add("@command", SqlDbType.Int).Value = SPCommand.Update
                        .Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output

                End Select

            End With

            'PrepareSPCommand = True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        'Return PrepareSPCommand()

    End Sub
    Public Shared Function SaveRecord(ByVal oForm As FEmployees) As Boolean

        Try

            Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

                Using oSqlCommand As New SqlCommand(oForm.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

                    PrepareSPCommand(oSqlCommand, SPCommand.Save, oForm)

                    oSqlCommand.ExecuteNonQuery()

                    ' ----------------------------
                    ' Handle SP Response. 
                    ' ----------------------------
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


    Public Shared Function UpdateRecord(ByVal oForm As FEmployees) As Boolean

        Try

            Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

                Using oSqlCommand As New SqlCommand(oForm.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

                    'If Not CEmployee.PrepareSPCommand(oSqlCommand, SPCommand.Update, oForm) Then Throw New CustomException

                    PrepareSPCommand(oSqlCommand, SPCommand.Update, oForm)

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

    Public Shared Function DeleteRecord(ByVal oForm As FEmployees) As Boolean

        Try

            Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

                Using oSqlCommand As New SqlCommand(oForm.stored_procedure_name, oConnection) With {.CommandType = CommandType.StoredProcedure}

                    ' ---------------------------------
                    ' Set Command Ready and Execute
                    ' ---------------------------------
                    'If Not CEmployee.PrepareSPCommand(oSqlCommand, SPCommand.Delete, oForm) Then Throw New CustomException

                    PrepareSPCommand(oSqlCommand, SPCommand.Delete, oForm)

                    oSqlCommand.ExecuteNonQuery()

                    ' -------------------------
                    ' Handle SP Response. 
                    ' -------------------------
                    If CInt(oSqlCommand.Parameters("@response").Value.Equals(1)) Then Throw New CustomException("Ocurrio un error al actualizar la información. ")

                    If CInt(oSqlCommand.Parameters("@response").Value.Equals(0)) Then MessageBox.Show("Registro actualizado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    oForm.DataGridView.Update()
                    oForm.DataGridView.Refresh()

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

    Friend Function GetEmployeeDataById() As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.SP_EMPLOYEES")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        Try

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
                .Add("@nombre_corto", SqlDbType.NVarChar).Value = CApplicationController.oCUsers.empleado_id
                .Add("@command", SqlDbType.Int).Value = SPCommand.QueryById

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            ' --------------------------------------------------------------------------

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "Employees")

            If Not CBool(CInt(oDataSet.Tables("Employees").Rows.Count)) Then Exit Function : Throw New CustomException("No hay información en la tabla de Personal para la clave proporcionada.")

            With oDataSet.Tables("Employees").Rows(0)

                Me.centro_id = .Item("centro_id").ToString.Trim
                Me.nombre_corto = .Item("id").ToString.Trim
                Me.nombre = .Item("nombre").ToString.Trim
                'Me.empleado_paterno = .Item("empleado_paterno").ToString.Trim
                'Me.empleado_materno = .Item("empleado_materno").ToString.Trim
                'Me.puesto_id = .Item("puesto_id").ToString.Trim
                'Me.empleado_email = .Item("empleado_email").ToString.Trim
                'Me.empleado_telefono = .Item("empleado_telefono").ToString.Trim
                'Me.empleado_celular = .Item("empleado_celular").ToString.Trim
                'Me.supervisor_id = .Item("supervisor_id").ToString.Trim

            End With

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try


    End Function


End Class
