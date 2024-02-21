Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO



Public Class CLevel

    Enum SPCommand
        None = 0
        QueryAll = 1
        Add = 2
        Update = 3
        SaveCommand = 4
        Delete = 5

        QueryByLevel = 7

    End Enum

    Private _oSqlDataAdapter As SqlDataAdapter

    Public Property oSqlDataAdapter() As SqlDataAdapter
        Get
            Return _oSqlDataAdapter
        End Get
        Set(ByVal value As SqlDataAdapter)

            _oSqlDataAdapter = value
        End Set
    End Property

    Private _oDataSet As New DataSet

    Public Property oDataSet() As DataSet
        Get
            Return _oDataSet
        End Get
        Set(ByVal value As DataSet)
            _oDataSet = value
        End Set
    End Property

    Private _oBindingSourceParent As New BindingSource
    Public Property oBindingSourceParent() As BindingSource
        Get
            Return _oBindingSourceParent
        End Get
        Set(ByVal value As BindingSource)
            _oBindingSourceParent = value
        End Set
    End Property

    Private Function SetBindingSourceParent(ByRef oBindingSourceDummy As BindingSource) As Boolean

        Dim oResponse As New SqlParameter
        Dim oSqlCommand As SqlCommand

        oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_SYS_MENU_LEVELS")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oSqlCommand.Parameters.Add("@centro_id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
        oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.QueryAll

        oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
        oResponse.Direction = ParameterDirection.Output

        Try

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)
            oDataSet = New DataSet
            oSqlDataAdapter.Fill(oDataSet, "GetMenuLevelData")

            If Not CBool(CInt(oDataSet.Tables("GetMenuLevelData").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de menus.")

            oBindingSourceDummy = New BindingSource
            oBindingSourceDummy.DataSource = oDataSet
            oBindingSourceDummy.DataMember = "GetMenuLevelData"

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

    Private Function QueryAll() As Boolean

        Try

            ' -------------------------------------------
            ' Get BindingSource.
            ' -------------------------------------------
            If Not SetBindingSourceParent(Me.oBindingSourceParent) Then Throw New CustomException

            Return True

        Catch ex As CustomException

            Exit Function

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try



    End Function

    Public Function GetLevelCollection() As Collection

        Dim oLevel As CLevel
        Dim oCMenu As New CMenu
        Dim oLevelCollection As New Collection

        ' Limpia la colección.
        oLevelCollection.Clear()


        Try

            ' -------------------------------------------
            ' Get BindingSource.
            ' -------------------------------------------
            If Not SetBindingSourceParent(Me.oBindingSourceParent) Then Throw New CustomException

            ' -----------------------------------------------------------
            ' Recupera los niveles.
            ' -----------------------------------------------------------
            For Each row As DataRow In oDataSet.Tables("GetMenuLevelData").Rows

                oLevel = New CLevel
                oLevel.level_id = row.Item("level_id")
                oLevel.level_descripcion = row.Item("level_descripcion")

                ' Recupera los menues.
                oCMenu.level_id = oLevel.level_id
                oLevel.oMenuCollection = oCMenu.GetMenuData()

                oLevelCollection.Add(oLevel)

            Next row

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        End Try

        oDataSet.Dispose()

        Return oLevelCollection

    End Function

    Public Function GetLevelCollectionAccess() As Collection

        '------------------------------------------------------
        ' Database 
        '------------------------------------------------------
        Dim oCDataBase As New CDataBase
        Dim oLevel As CLevel

        Dim oCMenu As New CMenu

        Dim oLevelCollection As New Collection

        ' Limpia la colección.
        oLevelCollection.Clear()

        oCDataBase.OleQuery = "SELECT * FROM SYS_MENU_LEVELS"

        Try

            oCDataBase.SetOleDbDataAdapter()

            ' -----------------------------------------------------------
            ' Recupera los niveles.
            ' -----------------------------------------------------------
            'Do While oCDataBase.oOleDbDataReader.Read() = True

            For Each row As DataRow In oCDataBase.oDataSet.Tables(0).Rows

                oLevel = New CLevel
                oLevel.level_id = row.Item("level_id")
                oLevel.level_descripcion = row.Item("level_descripcion")

                ' Recupera los menues.
                oCMenu.level_id = oLevel.level_id
                oLevel.oMenuCollection = oCMenu.GetMenuData()

                oLevelCollection.Add(oLevel)

            Next row

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        End Try

        oCDataBase.oDataSet.Dispose()


        Return oLevelCollection

    End Function


    Private p_oMenuCollection As Collection

    Public Property oMenuCollection() As Collection
        Get
            Return p_oMenuCollection
        End Get
        Set(ByVal value As Collection)
            p_oMenuCollection = value
        End Set
    End Property

    Private p_level_id As Short
    Public Property level_id() As Integer
        Get
            Return p_level_id
        End Get
        Set(ByVal value As Integer)
            p_level_id = value
        End Set
    End Property

    Private p_level_desc As String
    Public Property level_descripcion() As String
        Get
            Return p_level_desc
        End Get
        Set(ByVal value As String)
            p_level_desc = value
        End Set
    End Property

End Class
