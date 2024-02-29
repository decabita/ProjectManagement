Imports System.Data.SqlClient

Public Class CCustomers

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

    Private _guid As String
    Public Property guid() As String
        Get
            Return _guid
        End Get
        Set(ByVal value As String)
            _guid = value
        End Set
    End Property

    Private _empresa_id As Integer
    Public Property empresa_id() As Integer
        Get
            Return _empresa_id
        End Get
        Set(ByVal value As Integer)
            _empresa_id = value
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
        GetClassData()
    End Sub

    Private Sub Initialize()

        With Me
            .id = -1
            .guid = String.Empty
            .empresa_id = 0
            .nombre = String.Empty
            .rfc = String.Empty
            .razon_social = String.Empty
            .contacto = String.Empty
            .email = String.Empty
            .telefono = String.Empty
            .celular = String.Empty
            .pais = String.Empty
            .ciudad = String.Empty
            .calle = String.Empty
            .numero_ext = 0
            .numero_int = 0
            .colonia = String.Empty
            .delegacion = String.Empty
            .codigo_postal = 0
            .descripcion = String.Empty
            .is_active = False
        End With

    End Sub

    Friend Function GetClassData() As CCustomers

        Try

            Using oDataSet As New DataSet

                Using oSqlCommand As New SqlCommand("dbo.SP_PROCESS_CUSTOMERS")

                    oSqlCommand.CommandType = CommandType.StoredProcedure
                    oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
                    oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.QueryById
                    oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

                    Dim oSqlParameterResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
                    oSqlParameterResponse.Direction = ParameterDirection.Output

                    Using oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

                        oSqlDataAdapter.Fill(oDataSet, "MainTable")

                        If Not CBool(CInt(oDataSet.Tables("MainTable").Rows.Count)) Then Throw New CustomException("No hay información en la tabla.")

                        With oDataSet.Tables("MainTable").Rows(0)

                            Me.guid = .Item("guid")
                            Me.id = .Item("id")
                            Me.empresa_id = .Item("id")
                            Me.nombre = .Item("nombre").ToString.Trim
                            Me.rfc = .Item("rfc").ToString.Trim
                            Me.razon_social = .Item("razon_social").ToString.Trim
                            Me.contacto = .Item("contacto").ToString.Trim
                            Me.email = .Item("email").ToString.Trim
                            Me.telefono = .Item("telefono").ToString.Trim
                            Me.celular = .Item("celular").ToString.Trim
                            Me.pais = .Item("pais").ToString.Trim
                            Me.ciudad = .Item("pais").ToString.Trim
                            Me.calle = .Item("calle").ToString.Trim
                            Me.numero_ext = .Item("numero_ext")
                            Me.numero_int = .Item("numero_int")
                            Me.colonia = .Item("colonia").ToString.Trim
                            Me.delegacion = .Item("delegacion").ToString.Trim
                            Me.codigo_postal = .Item("codigo_postal")
                            Me.descripcion = .Item("descripcion").ToString.Trim
                            Me.is_active = .Item("is_active")

                        End With
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


    Public Shared Function SetControlsBinding(ByVal oForm As FClientes) As Boolean

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

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return SetControlsBinding

    End Function

    Public Shared Function SetControlsBindingOnNew(ByVal oForm As FClientes) As Boolean

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

End Class
