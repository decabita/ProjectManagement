Imports System.Reflection
Imports System.Data.SqlClient

Public Class CFormController_
    Implements IDisposable



    Public Enum SPCommand
 
        GetFormRelatedTable = 11

    End Enum

    Private _active_form As Form
    Public Property active_form() As Form
        Get
            Return _active_form
        End Get
        Set(ByVal value As Form)
            _active_form = value
        End Set
    End Property

    Private _parent_form As Object
    Public Property parent_form() As Object
        Get
            Return _parent_form
        End Get
        Set(ByVal value As Object)
            _parent_form = value
        End Set
    End Property

    Private _child_form As Form = Nothing
    Public Property child_form() As Form
        Get
            Return _child_form
        End Get
        Set(ByVal value As Form)
            _child_form = value
        End Set
    End Property


    Private _form_name As String
    Public Property form_name() As String
        Get
            Return _form_name
        End Get
        Set(ByVal value As String)
            _form_name = value
        End Set
    End Property

    Private _level_id As Integer
    Public Property level_id() As Integer
        Get
            Return _level_id
        End Get
        Set(ByVal value As Integer)
            _level_id = value
        End Set
    End Property

    Private _menu_id As Integer
    Public Property menu_id() As Integer
        Get
            Return _menu_id
        End Get
        Set(ByVal value As Integer)
            _menu_id = value
        End Set
    End Property

    Private _button_id As Integer
    Public Property button_id() As Integer
        Get
            Return _button_id
        End Get
        Set(ByVal value As Integer)
            _button_id = value
        End Set
    End Property

    Private _object_id As String
    Public Property object_id() As String
        Get
            Return _object_id
        End Get
        Set(ByVal value As String)
            _object_id = value
        End Set
    End Property

    Private _oCollectionChildrenForm As New Collection

    Public Property oCollectionChildrenForm() As Collection
        Get
            Return _oCollectionChildrenForm
        End Get
        Set(ByVal value As Collection)
            _oCollectionChildrenForm = value
        End Set
    End Property

    Private _oBindingSource As New BindingSource
    Public Property oBindingSource() As BindingSource
        Get
            Return _oBindingSource
        End Get
        Set(ByVal value As BindingSource)
            _oBindingSource = value
        End Set
    End Property

    Public Shared Function IsChildOpen(ByVal oForm As Form) As Boolean

        If oForm Is Nothing Then Exit Function

        
        If oForm.Name.LastIndexOf(".") = -1 Then
            'Appends the root namespace if not specified.
            '     oForm.Name = [Assembly].GetEntryAssembly.GetName.Name & "." & oForm.Name
        End If

        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("Atlas_Pavco_Update." & oForm.Name)


        Try
            If oType Is Nothing Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Function

    Public Shared Function GetFormRelatedTable(ByVal value As String) As String

        Dim oDataSet As DataSet
        Dim oSqlCommand As SqlCommand
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_SYS_FORMS")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        Try

            oSqlCommand.Parameters.Add("@forma_id", SqlDbType.NVarChar).Value = value

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetFormRelatedTable

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            Dim oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetFormRelatedTable")

            If CBool(CInt(oDataSet.Tables("GetFormRelatedTable").Rows.Count)) Then

                With oDataSet.Tables("GetFormRelatedTable").Rows(0)

                    Return .Item("tabla_id").ToString

                End With


            End If


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


    Sub ShowLinkedObject()

        ' CApplicationController.oCSystemParameters.environment_id = "PROD"
        CApplication.usuario_id = "ADMINI"
        CApplicationController.oCWorkCenter_.id = 1

        Call CApplication.SetCultureSettings()


        Dim oRetForm As Object = Nothing

        Dim oMDIMainContainer As New MDIMainContainer()

        Dim oType As Type = Assembly.GetExecutingAssembly().GetType("IDPProjectManagement." & Me.form_name)

        Try
            If oType IsNot Nothing Then oRetForm = Activator.CreateInstance(oType)

            oRetForm.MdiParent = oMDIMainContainer
            oMDIMainContainer.WindowState = FormWindowState.Maximized
            oMDIMainContainer.Show()

        Catch ex As Exception

            MsgBox(ex.Message)
            Exit Sub

        End Try

    End Sub
    Public Declare Function GetActiveWindow Lib "user32" () As System.IntPtr
    Public Declare Auto Function GetWindowText Lib "user32" _
            (ByVal hWnd As System.IntPtr, _
            ByVal lpString As System.Text.StringBuilder, _
            ByVal cch As Integer) As Integer
    Dim makel As String

    Public Shared Function GetCaption() As String
        ' Create a buffer of 256 characters
        Dim Caption As New System.Text.StringBuilder(256)
        Dim hWnd As IntPtr = GetActiveWindow()
        GetWindowText(hWnd, Caption, Caption.Capacity)
        Return Caption.ToString()
    End Function


    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
