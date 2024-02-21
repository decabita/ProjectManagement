
Imports System.Data.SqlClient
Public Class CSQLServer

    Sub New()

        With Me


            .SqlDbProvider = ""
            .SqlDbSource = "Data Source=10.1.2.87;Initial Catalog=DevPavco;Persist Security Info=True;User ID=A-tlas2k;Password=;Trusted_Connection=False"
            .SQLConnString = .SqlDbProvider + SqlDbSource


        End With

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



    Private _oDataSet As DataSet
    Public Property oDataSet() As DataSet
        Get
            Return _oDataSet
        End Get
        Set(ByVal value As DataSet)
            _oDataSet = value
        End Set
    End Property

    Private p_oSqlConnection As SqlConnection
    Public Property oSqlConnection() As SqlConnection
        Get
            Return p_oSqlConnection
        End Get
        Set(ByVal value As SqlConnection)
            p_oSqlConnection = value
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


    Private p_SqlQuery As String
    Public Property SqlQuery() As String
        Get
            Return p_SqlQuery
        End Get
        Set(ByVal value As String)
            p_SqlQuery = value
        End Set
    End Property



End Class
