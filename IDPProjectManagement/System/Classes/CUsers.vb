Imports System.Data.SqlClient
Imports System.Deployment.Application

Public Class CUsers

    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _centro_id As Integer
    Public Property centro_id() As Integer
        Get
            Return _centro_id
        End Get
        Set(ByVal value As Integer)
            _centro_id = value
        End Set
    End Property

    Private _usuario_id As String
    Public Property usuario_id() As String
        Get
            Return _usuario_id
        End Get
        Set(ByVal value As String)
            _usuario_id = value
        End Set
    End Property

    Private _usuario_nombre As String
    Public Property usuario_nombre() As String
        Get
            Return _usuario_nombre
        End Get
        Set(ByVal value As String)
            _usuario_nombre = value
        End Set
    End Property

    Private _usuario_descripcion As String
    Public Property usuario_descripcion() As String
        Get
            Return _usuario_descripcion
        End Get
        Set(ByVal value As String)
            _usuario_descripcion = value
        End Set
    End Property

    Private _usuario_sap_id As String
    Public Property usuario_sap_id() As String
        Get
            Return _usuario_sap_id
        End Get
        Set(ByVal value As String)
            _usuario_sap_id = value
        End Set
    End Property

    Private _usuario_contraseña As String

    Public Property usuario_contraseña() As String
        Get
            Return _usuario_contraseña
        End Get

        Set(ByVal value As String)
            _usuario_contraseña = value
        End Set
    End Property

    Private _usuario_nueva_contraseña As String = String.Empty
    Public Property usuario_nueva_contraseña() As String
        Get
            Return _usuario_nueva_contraseña
        End Get
        Set(ByVal value As String)
            _usuario_nueva_contraseña = value
        End Set
    End Property

    Private _confirmar_contraseña As String = String.Empty
    Public Property confirmar_contraseña() As String
        Get
            Return _confirmar_contraseña
        End Get
        Set(ByVal value As String)
            _confirmar_contraseña = value
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


    Private _usuario_perfil As String

    Public Property perfil() As String
        Get
            Return _usuario_perfil

        End Get

        Set(ByVal value As String)

            _usuario_perfil = value
        End Set

    End Property


    Enum SPCommand

        ChangePassword = 7
        GetRelatedProfile = 8

    End Enum

    Private _oCollectionProfiles As New Collection

    Public Property oCollectionProfiles() As Collection
        Get
            Return _oCollectionProfiles
        End Get
        Set(ByVal value As Collection)
            _oCollectionProfiles = value
        End Set
    End Property

    Public Function ChangeUserPassword() As Boolean

        Dim oDataSet As DataSet
        Dim oSqlCommand As SqlCommand
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_USERS")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        Try

            oSqlCommand.Parameters.Add("@centro_id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id

            oSqlCommand.Parameters.Add("@usuario_id", SqlDbType.NVarChar).Value = CApplicationController.oCUsers.usuario_id

            oSqlCommand.Parameters.Add("@usuario_contraseña", SqlDbType.NVarChar).Value = CApplicationController.oCUsers.usuario_nueva_contraseña


            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.ChangePassword

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)

            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            oSqlCommand.ExecuteNonQuery()

            If Not CInt(oResponse.Value.Equals(0)) Then Throw New CustomException("Error de Cambio de Contraseña. Consulte al Administrador del Sistema.")

            ' Get User Data. 
            With CApplicationController.oCUsers

                .usuario_contraseña = .usuario_nueva_contraseña

            End With

            '   MessageBox.Show("Atención", "Se actualizó la contraseña correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim dr As DialogResult = MessageBox.Show("Se actualizó la contraseña correctamente. " & vbCrLf & _
                                                     "Si existe una cuenta asociada se enviará un correo con la nueva información.", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If (System.Windows.Forms.DialogResult.OK = dr) Then

                If Not String.IsNullOrEmpty(CApplicationController.oCEmployees.id) Then

                    'Dim oCMailServices As New CMailServices

                    'With oCMailServices

                    '    ' Set Mail Data Details.
                    '    .centro_id = CApplicationController.oCWorkCenter_.centro_id
                    '    .usuario_id = CApplicationController.oCUsers.empleado_id

                    '    .body = "Se actualizó la contraseña correctamente." & vbCrLf
                    '    .body = .body & "Su nueva contraseña es: " & CApplicationController.oCUsers.usuario_contraseña & vbCrLf
                    '    .body = .body & "Enviado el " & CApplication.GetCurrentDateTime.ToString("d") & " a las: " & CApplication.GetCurrentDateTime.ToString("T") & vbCrLf

                    '    .body = .body & "CENTRO: " & CApplicationController.oCWorkCenter_.centro_id & vbCrLf
                    '    .body = .body & "USUARIO: " & CApplicationController.oCUsers.empleado_id & vbCrLf

                    '    .subject = "ATLAS - Informe de Cambio de Contraseña." & _
                    '    " CENTRO: " & CApplicationController.oCWorkCenter_.centro_id & _
                    '    " USUARIO: " & CApplicationController.oCUsers.empleado_id

                    '    .to_recipients.Add(CApplicationController.oCEmployees.empleado_email)

                    '    ' Sending Mail.
                    '    .SendMail()

                    'End With

                Else

                    MessageBox.Show("Atención", "No existe una cuenta de correo asociada al usuario. No se enviará la información por correo.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

            ' -----------------------------------------
            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Public Function GetUserRelatedProfile(ByVal value As String) As Boolean

        Dim oDataSet As DataSet
        Dim oSqlCommand As SqlCommand
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_USERS")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        Try


            If Not Me.oCollectionProfiles Is Nothing Then Me.oCollectionProfiles.Clear()

            oSqlCommand.Parameters.Add("@usuario_id", SqlDbType.NVarChar).Value = value
            oSqlCommand.Parameters.Add("@centro_id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetRelatedProfile

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            Dim oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetUserRelatedProfile")

            If CBool(CInt(oDataSet.Tables("GetUserRelatedProfile").Rows.Count)) Then

                For Each tableRow As DataRow In oDataSet.Tables("GetUserRelatedProfile").Rows

                    Dim oCUserProfileObjects As New CUserProfileObjects

                    oCUserProfileObjects.forma_id = tableRow.Item("forma_id")
                    oCUserProfileObjects.permiso_id = tableRow.Item("permiso_id")
                    Me.oCollectionProfiles.Add(oCUserProfileObjects, tableRow.Item("forma_id").ToString)

                Next

            End If

            GetUserRelatedProfile = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()
            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try

        Return GetUserRelatedProfile

    End Function

End Class
