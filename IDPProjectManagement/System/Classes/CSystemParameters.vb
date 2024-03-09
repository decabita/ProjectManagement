Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Resources
Imports System.Configuration

Public Class CSystemParameters


    Enum SPCommand

        None = 0
        QueryAll = 1
        Add = 2
        Update = 3
        SaveCommand = 4
        Delete = 5
        QueryByCenterId = 6

    End Enum


    Enum SYSEnvironment

        SYS_DEV = 0
        SYS_PROD = 99

    End Enum

    Private _centro_id As Integer

    Public Property centro_id() As Integer
        Get
            Return _centro_id
        End Get
        Set(ByVal value As Integer)
            _centro_id = value

        End Set
    End Property

    Private _environment_id As String = String.Empty

    Public Property environment_id() As String
        Get
            Return _environment_id
        End Get
        Set(ByVal value As String)
            _environment_id = value

        End Set
    End Property


    Private _sql_connection_string As String = ConfigurationManager.ConnectionStrings("LocalConnection").ConnectionString



    Public Property sql_connection_string() As String
        Get
            Return _sql_connection_string
        End Get
        Set(ByVal value As String)
            _sql_connection_string = value

        End Set
    End Property

    Private _sql_server_name As String = String.Empty

    Public Property sql_server_name() As String
        Get
            Return _sql_server_name
        End Get
        Set(ByVal value As String)
            _sql_server_name = value

        End Set
    End Property

    Private _sql_database_name As String = String.Empty

    Public Property sql_database_name() As String
        Get
            Return _sql_database_name
        End Get
        Set(ByVal value As String)
            _sql_database_name = value

        End Set
    End Property

    Private _sql_logon_id As String = String.Empty

    Public Property sql_logon_id() As String
        Get
            Return _sql_logon_id
        End Get
        Set(ByVal value As String)
            _sql_logon_id = value

        End Set
    End Property

    Private _sql_logon_password As String = String.Empty

    Public Property sql_logon_password() As String
        Get
            Return _sql_logon_password
        End Get
        Set(ByVal value As String)
            _sql_logon_password = value

        End Set
    End Property

    Private _sap_logon_id As String = String.Empty

    Public Property sap_logon_id() As String
        Get
            Return _sap_logon_id
        End Get
        Set(ByVal value As String)
            _sap_logon_id = value

        End Set
    End Property

    Private _sap_logon_password As String = String.Empty

    Public Property sap_logon_password() As String
        Get
            Return _sap_logon_password
        End Get
        Set(ByVal value As String)
            _sap_logon_password = value

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

    Friend Function GetSystemParameterData() As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_SYS_SYSTEM")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        Try

            oSqlCommand.Parameters.Add("@centro_id", SqlDbType.Int).Value = CApplicationController.oCWorkCenter_.id

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.QueryByCenterId

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "SYS_ApplicationParameters")

            If Not CBool(CInt(oDataSet.Tables("SYS_ApplicationParameters").Rows.Count)) Then Throw New CustomException("No hay información en la tabla de Parámetros del Sistema.")

            With oDataSet.Tables("SYS_ApplicationParameters").Rows(0)

                Me.centro_id = .Item("centro_id")
                Me.environment_id = .Item("environment_id").ToString.Trim ' 
                Me.sql_connection_string = .Item("sql_connection_string").ToString.Trim
                Me.sql_logon_id = .Item("sql_logon_id").ToString.Trim
                Me.sql_logon_password = .Item("sql_logon_password").ToString.Trim
                Me.is_active = .Item("is_active")
            End With

            GetSystemParameterData = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try

        Return GetSystemParameterData

    End Function


End Class
