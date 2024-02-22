Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient

Public Class CButton
    Inherits System.Windows.Forms.Button
    Sub New()

        '   Me.Height = 40
        ' Me.Width = 250

    End Sub
    Private _oBindingSourceParent As New BindingSource
    Public Property oBindingSourceParent() As BindingSource
        Get
            Return _oBindingSourceParent
        End Get
        Set(ByVal value As BindingSource)
            _oBindingSourceParent = value
        End Set
    End Property

    Enum SPCommand
        QueryAll = 1
        Add = 2
        Update = 3
        SaveCommand = 4
        Delete = 5
        None = 0

        QueryByLevelMenu = 7


    End Enum

    Private _oDataSet As New DataSet

    Public Property oDataSet() As DataSet
        Get
            Return _oDataSet
        End Get
        Set(ByVal value As DataSet)
            _oDataSet = value
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

    Public Function GetCommandData() As Collection

        '------------------------------------------------------
        ' Database 
        '------------------------------------------------------       
        '  Dim oCDataBase As New CDataBase
        Dim oButton As CButton

        Dim oButtonCollection As New Collection

        ' Limpia la colección.
        oButtonCollection.Clear()


        Try

            ' -------------------------------------------
            ' Get BindingSource.
            ' -------------------------------------------
            If Not SetBindingSourceParent(Me.oBindingSourceParent) Then Throw New CustomException

            '------------------------------------------------------
            ' Recupera los botones del menu.
            '------------------------------------------------------
            For Each row As DataRow In oDataSet.Tables("GetMenuButtonData").Rows

                oButton = New CButton

                oButton.level_id = row.Item("level_id")
                oButton.menu_id = row.Item("menu_id")
                oButton.button_id = row.Item("button_id")
                oButton.button_caption = row.Item("button_caption")
                oButton.button_order = row.Item("button_order")
                oButton.next_level_id = row.Item("next_level_id")
                oButton.next_menu_id = row.Item("next_menu_id")
                oButton.object_type_id = row.Item("object_type_id")
                oButton.object_id = row.Item("object_id")
                oButton.Visible = row.Item("is_visible")

                If oButton.level_id = 1 Then
                    oButton.Height = 55
                Else

                    oButton.Height = 40
                End If

                oButton.Width = 250

                ' Da formato a los botones.
                oButton.Font = New System.Drawing.Font("Sans Serif", 10, FontStyle.Regular)
                oButton.TextAlign = ContentAlignment.MiddleCenter

                oButton.AutoSize = True

                '------------------------------------------------------
                ' Configura Botones.
                '------------------------------------------------------
                oButton.Name = oButton.button_id
                oButton.Top = oButton.Height * (oButtonCollection.Count) ' oCDataBase.oDataSet.Tables(0).Rows.IndexOf(row)
                oButton.Text = oButton.button_caption

                ' Agrega el manejador de eventos.
                'AddHandler oButton.Click, AddressOf Me.MenuButtonClick

                '------------------------------------------------------


                Select Case oButton.object_type_id

                    Case 1

                        oButton.Image = My.Resources.ButtonForm


                    Case Else

                        oButton.Image = My.Resources.ButtonMenu

                End Select

                If oButton.Text.Equals("Modelado de Fábrica") Then oButton.Image = My.Resources.FactoryModelling

                If oButton.Text.Equals("Notificaciones de Producción") Then oButton.Image = My.Resources.Resources.ProductionReports

                If oButton.Text.Equals("Administración del Sistema") Then oButton.Image = My.Resources.Resources.SystemConfiguration

                oButton.ImageAlign = ContentAlignment.MiddleLeft
                oButton.TextAlign = ContentAlignment.MiddleLeft

                oButton.TextImageRelation = Windows.Forms.TextImageRelation.ImageBeforeText

                oButtonCollection.Add(oButton)

            Next row

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        End Try

        oDataSet.Dispose()

        Return oButtonCollection

    End Function

    Public Function GetCommandDataAccess() As Collection

        '------------------------------------------------------
        ' Database 
        '------------------------------------------------------       
        Dim oCDataBase As New CDataBase
        Dim oButton As CButton

        Dim oButtonCollection As New Collection

        oCDataBase.OleQuery = "SELECT * FROM SYS_MENU_BUTTON WHERE LEVEL_ID = " & Me.level_id & _
        " AND MENU_ID = " & Me.menu_id & _
        " ORDER BY BUTTON_ORDER ASC"

        Try

            oCDataBase.SetOleDbDataAdapter()

            ' Limpia la colección.
            oButtonCollection.Clear()

            '------------------------------------------------------
            ' Recupera los botones del menu.
            '------------------------------------------------------
            For Each row As DataRow In oCDataBase.oDataSet.Tables(0).Rows

                oButton = New CButton

                oButton.level_id = row.Item("level_id")
                oButton.menu_id = row.Item("menu_id")
                oButton.button_id = row.Item("button_id")
                oButton.button_caption = row.Item("button_caption")
                oButton.button_order = row.Item("button_order")
                oButton.next_level_id = row.Item("next_level_id")
                oButton.next_menu_id = row.Item("next_menu_id")
                oButton.object_type_id = row.Item("object_type_id")
                oButton.object_id = row.Item("object_id")
                oButton.Visible = row.Item("visible")

                If oButton.level_id = 1 Then
                    oButton.Height = 55
                Else

                    oButton.Height = 40
                End If

                oButton.Width = 250

                ' Da formato a los botones.
                oButton.Font = New System.Drawing.Font("Sans Serif", 10, FontStyle.Regular)
                oButton.TextAlign = ContentAlignment.MiddleCenter

                oButton.AutoSize = True

                '------------------------------------------------------
                ' Configura Botones.
                '------------------------------------------------------
                oButton.Name = oButton.button_id
                oButton.Top = oButton.Height * (oButtonCollection.Count) ' oCDataBase.oDataSet.Tables(0).Rows.IndexOf(row)
                oButton.Text = oButton.button_caption

                ' Agrega el manejador de eventos.
                'AddHandler oButton.Click, AddressOf Me.MenuButtonClick

                '------------------------------------------------------


                Select Case oButton.object_type_id

                    Case 1

                        oButton.Image = My.Resources.ButtonForm


                    Case Else

                        oButton.Image = My.Resources.ButtonMenu

                End Select

                If oButton.Text.Equals("Modelado de Fábrica") Then oButton.Image = My.Resources.FactoryModelling


                If oButton.Text.Equals("Notificaciones de Producción") Then oButton.Image = My.Resources.Resources.ProductionReports

                If oButton.Text.Equals("Administración del Sistema") Then oButton.Image = My.Resources.Resources.SystemConfiguration

                oButton.ImageAlign = ContentAlignment.MiddleLeft
                oButton.TextAlign = ContentAlignment.MiddleLeft

                oButton.TextImageRelation = Windows.Forms.TextImageRelation.ImageBeforeText

                oButtonCollection.Add(oButton)

            Next row

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        End Try

        oCDataBase.oDataSet.Dispose()

        Return oButtonCollection

    End Function

    Private p_oBtnCollection As Collection

    Public Property oBtnCollection() As Collection
        Get
            Return p_oBtnCollection
        End Get
        Set(ByVal value As Collection)
            p_oBtnCollection = value
        End Set
    End Property

    Private p_level_id As Integer
    Public Property level_id() As Integer
        Get
            Return p_level_id
        End Get
        Set(ByVal value As Integer)
            p_level_id = value
        End Set
    End Property

    Private p_menu_id As Integer
    Public Property menu_id() As Integer
        Get
            Return p_menu_id
        End Get
        Set(ByVal value As Integer)
            p_menu_id = value
        End Set
    End Property


    Private p_button_id As Integer
    Public Property button_id() As Integer
        Get
            Return p_button_id
        End Get
        Set(ByVal value As Integer)
            p_button_id = value
        End Set
    End Property

    Private p_button_order As Integer
    Public Property button_order() As Integer
        Get
            Return p_button_order
        End Get
        Set(ByVal value As Integer)
            p_button_order = value
        End Set
    End Property

    Private p_button_caption As String
    Public Property button_caption() As String
        Get
            Return p_button_caption
        End Get
        Set(ByVal value As String)
            p_button_caption = value
        End Set
    End Property

    Private p_next_level_id As Integer
    Public Property next_level_id() As Integer
        Get
            Return p_next_level_id
        End Get
        Set(ByVal value As Integer)
            p_next_level_id = value
        End Set
    End Property

    Private p_next_menu_id As Integer
    Public Property next_menu_id() As Integer
        Get
            Return p_next_menu_id
        End Get
        Set(ByVal value As Integer)
            p_next_menu_id = value
        End Set
    End Property

    Private p_is_visible As Boolean

    Public Property is_visible() As Boolean
        Get
            Return p_is_visible
        End Get
        Set(ByVal value As Boolean)
            p_is_visible = value
        End Set
    End Property

    Private p_object_type_id As Integer
    Public Property object_type_id() As Integer
        Get
            Return p_object_type_id
        End Get
        Set(ByVal value As Integer)
            p_object_type_id = value
        End Set
    End Property

    Private p_object_id As String
    Public Property object_id() As String
        Get
            Return p_object_id
        End Get
        Set(ByVal value As String)
            p_object_id = value
        End Set
    End Property

    Private p_form_to_go As String
    Public Property form_to_go() As String
        Get
            Return p_form_to_go
        End Get
        Set(ByVal value As String)
            p_form_to_go = value
        End Set
    End Property

    Private _ButtonPressed As Boolean = False
    Public Property ButtonPressed() As Boolean
        Get
            Return _ButtonPressed
        End Get
        Set(ByVal value As Boolean)
            _ButtonPressed = value
        End Set
    End Property


    Public Sub CButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click

        If Not Me.ButtonPressed Then

        End If

        Me.ButtonPressed = Not (Me.ButtonPressed)


    End Sub

    Private Function SetBindingSourceParent(ByRef oBindingSourceDummy As BindingSource) As Boolean

        Dim oResponse As New SqlParameter
        Dim oSqlCommand As SqlCommand

        oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_SYS_MENU_BUTTON")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.QueryByLevelMenu
        oSqlCommand.Parameters.Add("@level_id", SqlDbType.Int).Value = Me.level_id
        oSqlCommand.Parameters.Add("@menu_id", SqlDbType.Int).Value = Me.menu_id

        oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
        oResponse.Direction = ParameterDirection.Output

        Try

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)
            oDataSet = New DataSet
            oSqlDataAdapter.Fill(oDataSet, "GetMenuButtonData")

            'If Not CBool(CInt(oDataSet.Tables("GetMenuButtonData").Rows.Count)) Then Exit Function 'Throw New CustomException("No existen valores en la tabla.")

            oBindingSourceDummy = New BindingSource
            oBindingSourceDummy.DataSource = oDataSet
            oBindingSourceDummy.DataMember = "GetMenuButtonData"

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try

    End Function

End Class
