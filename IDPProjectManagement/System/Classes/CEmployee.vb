Imports System.Data
Imports System.Data.SqlClient

Public Class CEmployee

    Enum SPCommand

        QueryById = 10
        QueryAll = 1
        Add = 2
        Update = 3
        SaveCommand = 4
        Delete = 5
        None = 0
        Authenticate = 69

        GetRelatedSpecs = 30

    End Enum

    Private _centro_id As String = String.Empty
    Public Property centro_id() As String
        Get
            Return _centro_id
        End Get
        Set(ByVal value As String)
            _centro_id = value
        End Set
    End Property

    Private _empleado_id As String
    Public Property empleado_id() As String
        Get
            Return _empleado_id
        End Get
        Set(ByVal value As String)
            _empleado_id = value
        End Set
    End Property

    Private _empleado_nombre As String
    Public Property empleado_nombre() As String
        Get
            Return _empleado_nombre
        End Get
        Set(ByVal value As String)
            _empleado_nombre = value
        End Set
    End Property

    Private _empleado_paterno As String
    Public Property empleado_paterno() As String
        Get
            Return _empleado_paterno
        End Get
        Set(ByVal value As String)
            _empleado_paterno = value
        End Set
    End Property

    Private _empleado_materno As String
    Public Property empleado_materno() As String
        Get
            Return _empleado_materno
        End Get
        Set(ByVal value As String)
            _empleado_materno = value
        End Set
    End Property

    Private _puesto_id As String
    Public Property puesto_id() As String
        Get
            Return _puesto_id
        End Get
        Set(ByVal value As String)
            _puesto_id = value
        End Set
    End Property

    Private _supervisor_id As String
    Public Property supervisor_id() As String
        Get
            Return _supervisor_id
        End Get
        Set(ByVal value As String)
            _supervisor_id = value
        End Set
    End Property

    Private _empleado_email As String
    Public Property empleado_email() As String
        Get
            Return _empleado_email
        End Get
        Set(ByVal value As String)
            _empleado_email = value
        End Set
    End Property

    Private _empleado_telefono As String
    Public Property empleado_telefono() As String
        Get
            Return _empleado_telefono
        End Get
        Set(ByVal value As String)
            _empleado_telefono = value
        End Set
    End Property

    Private _empleado_celular As String
    Public Property empleado_celular() As String
        Get
            Return _empleado_celular
        End Get
        Set(ByVal value As String)
            _empleado_celular = value
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

    Friend Function GetEmployeeDataById() As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_EMPLOYEES")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        Try

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
                .Add("@empleado_id", SqlDbType.NVarChar).Value = CApplicationController.oCUsers.empleado_id
                .Add("@command", SqlDbType.Int).Value = SPCommand.QueryById

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            ' --------------------------------------------------------------------------

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "CTL_Empleados_")

            If Not CBool(CInt(oDataSet.Tables("CTL_Empleados_").Rows.Count)) Then Exit Function : Throw New CustomException("No hay información en la tabla de Personal para la clave proporcionada.")

            With oDataSet.Tables("CTL_Empleados_").Rows(0)

                Me.centro_id = .Item("centro_id").ToString.Trim
                Me.empleado_id = .Item("empleado_id").ToString.Trim
                Me.empleado_nombre = .Item("empleado_nombre").ToString.Trim
                Me.empleado_paterno = .Item("empleado_paterno").ToString.Trim
                Me.empleado_materno = .Item("empleado_materno").ToString.Trim
                Me.puesto_id = .Item("puesto_id").ToString.Trim
                Me.empleado_email = .Item("empleado_email").ToString.Trim
                Me.empleado_telefono = .Item("empleado_telefono").ToString.Trim
                Me.empleado_celular = .Item("empleado_celular").ToString.Trim
                Me.supervisor_id = .Item("supervisor_id").ToString.Trim

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
