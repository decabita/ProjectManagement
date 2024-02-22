Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient

Public Class CMenu
    Inherits System.Windows.Forms.Panel

    Enum SPCommand
        None = 0
        QueryAll = 1
        Add = 2
        Update = 3
        SaveCommand = 4
        Delete = 5

        QueryByLevel = 7


    End Enum

    Public Function GetMenuData() As Collection

        '------------------------------------------------------
        ' Database 
        '------------------------------------------------------
        Dim oMenu As CMenu
        Dim oCButton As New CButton

        Dim oMenuCollection As New Collection

        ''  oCDataBase.OleQuery = "SELECT * FROM SYS_MENUS WHERE LEVEL_ID = " & Me.level_id
        '& _                              " AND IS_VISIBLE = 1"

        Try

            ' Limpia la colección.
            oMenuCollection.Clear()

            ' -------------------------------------------
            ' Get BindingSource.
            ' -------------------------------------------
            If Not SetBindingSourceParent(Me.oBindingSourceParent) Then Throw New CustomException

            '------------------------------------------------------
            ' Recupera los menues del nivel.
            '------------------------------------------------------
            For Each row As DataRow In oDataSet.Tables("GetMenuData").Rows

                ' Create a New Menu. 
                oMenu = New CMenu

                ' Set Menu Properties.               
                oMenu.level_id = row.Item("level_id")
                oMenu.menu_id = row.Item("menu_id")
                oMenu.menu_caption = row.Item("menu_caption")
                oMenu.menu_order = row.Item("menu_order")
                oMenu.is_visible = row.Item("is_visible")
                oMenu.is_root = row.Item("is_root")
                oMenu.Visible = oMenu.is_visible

                ' Get Menu Buttons. 
                oCButton.level_id = oMenu.level_id
                oCButton.menu_id = oMenu.menu_id

                oMenu.oButtonCollection = oCButton.GetCommandData()


                For Each oCButton In oMenu.oButtonCollection
                    oMenu.Height = oCButton.Height * (oMenu.oButtonCollection.Count)
                    oMenu.Width = oCButton.Width
                    oMenu.Controls.Add(oCButton)
                Next

                oMenu.Location = New Point((oMenu.Width * oDataSet.Tables(0).Rows.IndexOf(row)) + 5, 5)

                oMenuCollection.Add(oMenu)

            Next row


        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        Finally

            oDataSet.Dispose()

        End Try

        Return oMenuCollection

    End Function

    Public Function GetMenuDataAccess() As Collection

        '------------------------------------------------------
        ' Database 
        '------------------------------------------------------
        Dim oCDataBase As New CDataBase
        Dim oMenu As CMenu
        Dim oCButton As New CButton

        Dim oMenuCollection As New Collection

        oCDataBase.OleQuery = "SELECT * FROM SYS_MENUS WHERE LEVEL_ID = " & Me.level_id
        '& _                              " AND IS_VISIBLE = 1"

        Try

            oCDataBase.SetOleDbDataAdapter()  'SetDatabaseReader()

            ' Limpia la colección.
            oMenuCollection.Clear()
            '------------------------------------------------------
            ' Recupera los menues del nivel.
            '------------------------------------------------------

            For Each row As DataRow In oCDataBase.oDataSet.Tables(0).Rows

                ' Create a New Menu. 
                oMenu = New CMenu

                ' Set Menu Properties.               
                oMenu.level_id = row.Item("level_id")
                oMenu.menu_id = row.Item("menu_id")
                oMenu.menu_desc = row.Item("menu_desc")
                oMenu.menu_order = row.Item("menu_order")
                oMenu.is_visible = row.Item("is_visible")
                oMenu.is_root = row.Item("is_root")
                oMenu.Visible = oMenu.is_visible

                ' Get Menu Buttons. 
                oCButton.level_id = oMenu.level_id
                oCButton.menu_id = oMenu.menu_id
                oMenu.oButtonCollection = oCButton.GetCommandData()

                '   oMenu.Height = oCButton.Height * (oMenu.oButtonCollection.Count)
                '   oMenu.Width = oCButton.Width

                For Each oCButton In oMenu.oButtonCollection
                    oMenu.Height = oCButton.Height * (oMenu.oButtonCollection.Count)
                    oMenu.Width = oCButton.Width
                    oMenu.Controls.Add(oCButton)
                Next

                oMenu.Location = New Point((oMenu.Width * oCDataBase.oDataSet.Tables(0).Rows.IndexOf(row)) + 5, 5)

                oMenuCollection.Add(oMenu)

            Next row

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        End Try

        oCDataBase.oDataSet.Dispose()

        Return oMenuCollection

    End Function


    Private Function SetBindingSourceParent(ByRef oBindingSourceDummy As BindingSource) As Boolean

        Dim oResponse As New SqlParameter
        Dim oSqlCommand As SqlCommand

        oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_SYS_MENUS")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oSqlCommand.Parameters.Add("@level_id", SqlDbType.VarChar).Value = Me.level_id
        oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.QueryByLevel

        oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
        oResponse.Direction = ParameterDirection.Output

        Try

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oDataSet = New DataSet

            oSqlDataAdapter.Fill(oDataSet, "GetMenuData")

            '  If Not CBool(CInt(oDataSet.Tables("GetMenuData").Rows.Count)) Then Exit Function 'Throw New CustomException("No existen valores en la tabla.")

            oBindingSourceDummy = New BindingSource
            oBindingSourceDummy.DataSource = oDataSet
            oBindingSourceDummy.DataMember = "GetMenuData"

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

    Private p_oButtonCollection As Collection

    Public Property oButtonCollection() As Collection
        Get
            Return p_oButtonCollection
        End Get
        Set(ByVal value As Collection)
            p_oButtonCollection = value
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

    Private p_menu_id As Short
    Public Property menu_id() As Short
        Get
            Return p_menu_id
        End Get
        Set(ByVal value As Short)
            p_menu_id = value
        End Set
    End Property


    Private p_menu_order As Integer
    Public Property menu_order() As Integer
        Get
            Return p_menu_order
        End Get
        Set(ByVal value As Integer)
            p_menu_order = value
        End Set
    End Property

    Private p_menu_caption As String
    Public Property menu_caption() As String
        Get
            Return p_menu_caption
        End Get
        Set(ByVal value As String)
            p_menu_caption = value
        End Set
    End Property

    Private p_is_visible As Short
    Public Property is_visible() As Short
        Get
            Return p_is_visible
        End Get
        Set(ByVal value As Short)
            p_is_visible = value
        End Set
    End Property

    Private p_is_root As Short
    Public Property is_root() As Short
        Get
            Return p_is_root
        End Get
        Set(ByVal value As Short)
            p_is_root = value
        End Set
    End Property

    Private p_menu_desc As String
    Public Property menu_desc() As String
        Get
            Return p_menu_desc
        End Get
        Set(ByVal value As String)
            p_menu_desc = value
        End Set
    End Property

End Class
