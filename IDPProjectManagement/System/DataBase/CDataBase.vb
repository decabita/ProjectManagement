Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class CDataBase
    Implements IDataBase


    Sub New()

        With Me

            ' -------------------------------------------------
            ' MS ACCESS Connection 
            ' -------------------------------------------------
            .OleDbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
            .OleDbSource = "Data Source=C:\Atlas\ATLAS_SYS.mdb"
            .OleConnString = .OleDbProvider + .OleDbSource


            ' -------------------------------------------------
            ' ORACLE Connection 
            ' -------------------------------------------------
            .OdbcDbProvider = "Driver={Microsoft ODBC for Oracle};"
            .OdbcDbSource = "Server=ecovald.world; Uid=eco_mis; Pwd=master900_"
            .OdbcConnString = .OdbcDbProvider + OdbcDbSource

            ' -------------------------------------------------
            ' SQL Server Connection 
            ' -------------------------------------------------
            .SqlDbProvider = ""
            .SqlDbSource = "Data Source=10.1.2.87;Initial Catalog=PavcoBogota;Persist Security Info=True;User ID=Atlas2k;Password=;Trusted_Connection=False"
            .SQLConnString = .SqlDbProvider + SqlDbSource

            '       Call OpenSQLConnection()

        End With

    End Sub

    Sub SetOleDbDatabaseReader() Implements IDataBase.SetDatabaseReader

        Try
            ' Abre la conexion a DB.
            oOleConnection = New OleDbConnection(Me.OleConnString)
            oOleConnection.Open()

            ' Crea el comando.
            oOleDbCommand = New OleDbCommand(Me.OleQuery, oOleConnection)

            oOleDbDataReader = oOleDbCommand.ExecuteReader()


        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        End Try
    End Sub
    Sub SetOleDbDataAdapter()

        Try

            ' Abre la conexion a DB.
            oOleConnection = New OleDbConnection(Me.OleConnString)
            oOleConnection.Open()

            ' Crea el objeto.
            oOleDbDataAdapter = New OleDbDataAdapter(Me.OleQuery, oOleConnection)

            oDataSet = New DataSet

            oOleDbDataAdapter.Fill(oDataSet)
            oOleDbDataAdapter.Dispose()

            oOleConnection.Close()

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        End Try
    End Sub

    Public Sub SetSQlDataSet()

        Try

            ' Abre la conexion a DB.
            oSqlConnection = New SqlConnection(Me.SQLConnString)
            oSqlConnection.Open()

            ' Crea el objeto.
            oSqlDataAdapter = New SqlDataAdapter(Me.SqlQuery, Me.SQLConnString)

            oDataSet = New DataSet

            oSqlDataAdapter.Fill(oDataSet)
            oSqlDataAdapter.Dispose()

            oSqlConnection.Close()

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        End Try

    End Sub

    Public Function GetSQLDataSet(ByVal pDataSet As DataSet, ByVal tableName As String, ByVal pSqlCommand As SqlCommand) As Boolean

        Try

            ' Abre la conexion a DB.
            ' Dim oSqlConnection = New SqlConnection(SQLConnString)
            '  oSqlConnection.Open()

            Call OpenSQLConnection()

            pSqlCommand.Connection = oSqlConnection
            ' Crea el objeto.
            oSqlDataAdapter = New SqlDataAdapter(pSqlCommand)

            'oDataSet = New DataSet

            oSqlDataAdapter.Fill(pDataSet, tableName)
            oSqlDataAdapter.Dispose()

            oSqlConnection.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        End Try

    End Function

    Private p_oOleConnection As OleDb.OleDbConnection

    Public Property oOleConnection() As OleDb.OleDbConnection _
    Implements IDataBase.oOleConnection
        Get
            Return p_oOleConnection
        End Get
        Set(ByVal value As OleDb.OleDbConnection)
            p_oOleConnection = value
        End Set
    End Property

    Private _oDataSet As DataSet
    Public Property oDataSet() As DataSet
        Get
            Return _oDataSet
        End Get
        Set(ByVal value As DataSet)
            _oDataSet = value
        End Set
    End Property


    Private _oOleDbDataAdapter As OleDb.OleDbDataAdapter
    Public Property oOleDbDataAdapter() As OleDb.OleDbDataAdapter
        Get
            Return _oOleDbDataAdapter
        End Get
        Set(ByVal value As OleDb.OleDbDataAdapter)
            _oOleDbDataAdapter = value
        End Set
    End Property

    Private p_oOleDbDataReader As OleDb.OleDbDataReader

    Public Property oOleDbDataReader() As OleDb.OleDbDataReader Implements IDataBase.oOleDbDataReader
        Get

            Return p_oOleDbDataReader
        End Get
        Set(ByVal value As OleDb.OleDbDataReader)
            p_oOleDbDataReader = value
        End Set
    End Property

    Private p_oOleDbCommand As OleDb.OleDbCommand
    Public Property oOleDbCommand() As OleDb.OleDbCommand Implements IDataBase.oOleDbCommand
        Get
            Return p_oOleDbCommand
        End Get
        Set(ByVal value As OleDb.OleDbCommand)
            p_oOleDbCommand = value
        End Set
    End Property

    Private p_OleConnString As String
    Public Property OleConnString() As String Implements IDataBase.OleConnString
        Get
            Return p_OleConnString
        End Get
        Set(ByVal value As String)
            p_OleConnString = value
        End Set
    End Property

    Private p_OleDbProvider As String

    Public Property OleDbProvider() As String Implements IDataBase.OleDbProvider
        Get
            Return p_OleDbProvider
        End Get
        Set(ByVal value As String)
            p_OleDbProvider = value
        End Set
    End Property

    Private p_OleDbSource As String

    Public Property OleDbSource() As String Implements IDataBase.OleDbSource
        Get
            Return p_OleDbSource
        End Get
        Set(ByVal value As String)
            p_OleDbSource = value
        End Set
    End Property

    Private p_OleQuery As String
    Public Property OleQuery() As String Implements IDataBase.OleQuery
        Get
            Return p_OleQuery
        End Get
        Set(ByVal value As String)
            p_OleQuery = value
        End Set
    End Property

    ' Conexion Sql Server
    Private p_oSqlConnection As SqlConnection
    Public Property oSqlConnection() As SqlConnection
        Get
            Return p_oSqlConnection
        End Get
        Set(ByVal value As SqlConnection)
            p_oSqlConnection = value
        End Set
    End Property


    Private p_oODBCConnection As OdbcConnection
    Public Property oODBCConnection() As OdbcConnection _
    Implements IDataBase.oODBCConnection
        Get
            Return p_oODBCConnection
        End Get
        Set(ByVal value As OdbcConnection)
            p_oODBCConnection = value
        End Set
    End Property

    Private p_oOdbcCommand As OdbcCommand
    Public Property oOdbcCommand() As OdbcCommand _
    Implements IDataBase.oOdbcCommand
        Get
            Return p_oOdbcCommand
        End Get
        Set(ByVal value As OdbcCommand)
            p_oOdbcCommand = value
        End Set
    End Property

    Private p_oOdbcDataReader As OdbcDataReader
    Public Property oOdbcDataReader() As OdbcDataReader _
    Implements IDataBase.oOdbcDataReader
        Get
            Return p_oOdbcDataReader
        End Get
        Set(ByVal value As OdbcDataReader)
            p_oOdbcDataReader = value
        End Set
    End Property


    Private _oSqlDataAdapter As SqlDataAdapter
    Public Property oSqlDataAdapter() As SqlDataAdapter
        Get
            Return _oSqlDataAdapter
        End Get
        Set(ByVal value As SqlDataAdapter)
            _oSqlDataAdapter = value
        End Set
    End Property

    Private p_SqlConnString As String
    Public Property SQLConnString() As String
        Get
            Return p_SqlConnString
        End Get
        Set(ByVal value As String)
            p_SqlConnString = value
        End Set
    End Property

    Private p_SqlDbProvider As String
    Public Property SqlDbProvider() As String
        Get
            Return p_SqlDbProvider
        End Get
        Set(ByVal value As String)
            p_SqlDbProvider = value
        End Set
    End Property

    Private p_SqlDbSource As String
    Public Property SqlDbSource() As String
        Get
            Return p_SqlDbSource
        End Get
        Set(ByVal value As String)
            p_SqlDbSource = value
        End Set
    End Property


    Private p_OdbcConnString As String
    Public Property OdbcConnString() As String Implements IDataBase.OdbcConnString
        Get
            Return p_OdbcConnString
        End Get
        Set(ByVal value As String)
            p_OdbcConnString = value
        End Set
    End Property

    Private p_OdbcDbProvider As String
    Public Property OdbcDbProvider() As String Implements IDataBase.OdbcDbProvider
        Get
            Return p_OdbcDbProvider
        End Get
        Set(ByVal value As String)
            p_OdbcDbProvider = value
        End Set
    End Property

    Private p_OdbcDbSource As String
    Public Property OdbcDbSource() As String Implements IDataBase.OdbcDbSource
        Get
            Return p_OdbcDbSource
        End Get
        Set(ByVal value As String)
            p_OdbcDbSource = value
        End Set
    End Property

    Private p_OdbcQuery As String
    Public Property OdbcQuery() As String Implements IDataBase.OdbcQuery
        Get
            Return p_OdbcQuery
        End Get
        Set(ByVal value As String)
            p_OdbcQuery = value
        End Set
    End Property


    Private p_SqlQuery As String
    Public Property SqlQuery() As String
        Get
            Return p_SqlQuery
        End Get
        Set(ByVal value As String)
            p_SqlQuery = value
        End Set
    End Property

    Public Sub OpenSQLConnection()

        Try

            If IsNothing(oSqlConnection) Then


                oSqlConnection = New SqlConnection(SQLConnString)
                oSqlConnection.Open()

            Else

                If oSqlConnection.State = ConnectionState.Closed Then

                    oSqlConnection = New SqlConnection(SQLConnString)
                    oSqlConnection.Open()

                End If

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Function GetSQLConnectionIn() As SqlConnection

        Try

            If IsNothing(Me.oSqlConnection) Then


                Me.oSqlConnection = New SqlConnection(Me.SQLConnString)
                Me.oSqlConnection.Open()

            Else

                If Me.oSqlConnection.State = ConnectionState.Closed Then

                    Me.oSqlConnection = New SqlConnection(Me.SQLConnString)
                    Me.oSqlConnection.Open()

                End If

            End If


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return Me.oSqlConnection

    End Function

    Public Function GetSQLConnection() As SqlConnection

        Try

            If IsNothing(Me.oSqlConnection) Then


                Me.oSqlConnection = New SqlConnection(CApplicationController.oCSystemParameters.sql_connection_string)
                Me.oSqlConnection.Open()

            Else

                If Me.oSqlConnection.State = ConnectionState.Closed Then

                    Me.oSqlConnection = New SqlConnection(CApplicationController.oCSystemParameters.sql_connection_string)
                    Me.oSqlConnection.Open()

                End If

            End If


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return Me.oSqlConnection


    End Function

End Class
