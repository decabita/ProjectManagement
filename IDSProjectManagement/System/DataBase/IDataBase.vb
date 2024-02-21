Imports System.IO
Imports System.Data.OleDb
Imports System.Data.Odbc
Public Interface IDataBase
    ' -------------------------------------------------
    ' MS ACCESS Connection 
    ' -------------------------------------------------
    Property oOleConnection() As OleDb.OleDbConnection
    Property oOleDbCommand() As OleDb.OleDbCommand
    Property oOleDbDataReader() As OleDb.OleDbDataReader

    Property OleConnString() As String
    Property OleDbProvider() As String
    Property OleDbSource() As String
    Property OleQuery() As String

    ' -------------------------------------------------
    ' ORACLE Connection 
    ' -------------------------------------------------
    Property oODBCConnection() As OdbcConnection
    Property oOdbcCommand() As OdbcCommand
    Property oOdbcDataReader() As OdbcDataReader

    Property OdbcConnString() As String
    Property OdbcDbProvider() As String
    Property OdbcDbSource() As String
    Property OdbcQuery() As String


    ' -------------------------------------------------
    ' Methods
    ' -------------------------------------------------

    Sub SetDatabaseReader()



End Interface