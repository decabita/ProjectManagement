Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Deployment.Application

Public Class FLoginForm

    Enum SPCommand

        Authenticate = 6

    End Enum

    Public Sub CheckApplicationUpdates()


        Dim oUpdateCheckInfo As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then

            Dim oApplicationDeployment As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                oUpdateCheckInfo = oApplicationDeployment.CheckForDetailedUpdate()

            Catch dde As DeploymentDownloadException

                MessageBox.Show("La nueva versión de la aplicación no puede ser descargada en estos momentos. " + ControlChars.Lf & ControlChars.Lf & "Por favor verifique su conexión a la red o intentelo más tarde. Error: " + dde.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return

            Catch ioe As InvalidOperationException

                MessageBox.Show("La aplicación no puede se actualizada. Verifique que sea una aplicación ClickOnce. Error: " & ioe.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return

            End Try

            If (oUpdateCheckInfo.UpdateAvailable) Then

                Dim doUpdate As Boolean = True

                If (Not oUpdateCheckInfo.IsUpdateRequired) Then

                    Dim dr As DialogResult = MessageBox.Show("Hay una actualización disponible. ¿Desea actualizar el sistema?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

                    If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        doUpdate = False
                    End If
                Else

                    Dim Choro As String = "Se a detectado una actualización obligatoria de la versión actual a la versión " &
                        oUpdateCheckInfo.MinimumRequiredVersion.ToString() &
                        ". Se instalará la actualización y reiniciará la aplicación."

                    ' Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show(Choro, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                If (doUpdate) Then

                    Try

                        oApplicationDeployment.Update()

                        MessageBox.Show("Se actualizó la aplicación y será reiniciada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Application.Restart()

                    Catch dde As DeploymentDownloadException

                        MessageBox.Show("No se puede instalar la ultima versión de la aplicación. " & ControlChars.Lf & ControlChars.Lf & "Verifique su conexión a la red o intentelo más tarde.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Return

                    End Try
                End If
            End If
        End If

    End Sub


    Private Sub FLoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        Try

            Call CApplication.SetFormFormat(Me)

            Call Me.CheckApplicationUpdates()

            Me.Icon = CApplication.GetApplicationIcon()

            ' Fill combo Work Centers
            If Not CApplication.GetComboWorkCenter(cbWorkCenter) Then Throw New CustomException("No es posible iniciar la aplicación.")

            Me.lbCapsLockWarning.Visible = False
            Me.tUsuarioId.Focus()

        Catch ex As CustomException

            End

        End Try

    End Sub


    Private Function InitApplicationData() As Boolean

        Try
            ' Check System Parameters Data.
            If Not CApplicationController.oCSystemParameters.GetSystemParameterData() Then Throw New CustomException("No es posible iniciar la aplicación." & vbCrLf _
            & "Verificar Parámetros del Sistema para el Centro de Trabajo: " & CApplicationController.oCWorkCenter_.id & ".", CApplication.MailExceptionTypes.NonRecoverableError)

            ' Check Work Center Data.
            If Not CApplicationController.oCWorkCenter_.IsValidWorkCenterData() Then CApplicationController._grant_execute_app = False : Throw New CustomException("No es posible iniciar la aplicación. Verificar Información del Centro de Trabajo: " & CApplicationController.oCWorkCenter_.id & ".", CApplication.MailExceptionTypes.NonRecoverableError)


            ' User Logon.
            If Not Me.AuthenticateUser() Then Return InitApplicationData

            ' Get Employee-User Related Data.
            If Not String.IsNullOrEmpty(CApplicationController.oCUsers.empleado_id) Then Call CApplicationController.oCEmployees.GetEmployeeDataById()

            InitApplicationData = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, ex.msg_caption, ex.oMessageBoxButtons, ex.oMessageBoxIcon)

        End Try

        Return InitApplicationData

    End Function

    Private Function AuthenticateUser() As Boolean

        oSqlParameter = New SqlParameter

        Try

            Using oConnection As SqlConnection = CApplicationController.oCDataBase.GetSQLConnection()

                If Not PrepareCommand(SPCommand.Authenticate) Then Throw New CustomException

                Using oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

                    Using oDataSet As New DataSet

                        oSqlParameter = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
                        oSqlParameter.Direction = ParameterDirection.Output
                        oSqlCommand.Connection = oConnection
                        oSqlDataAdapter.Fill(oDataSet, "Usuario")

                        ' --------------------------------------------------------------------------
                        ' Handle SP Response. 
                        ' --------------------------------------------------------------------------
                        If CInt(oSqlParameter.Value.Equals(2)) Then Throw New CustomException("Usuario o Contraseña incorrectos.")

                        If Not CBool(CInt(oDataSet.Tables("Usuario").Rows.Count)) Then Throw New CustomException("Error de Autenticación. Consulte al Administrador del Sistema.")

                        ' ----------------------------------------------------------------------------------
                        ' Get User Data. 
                        ' ----------------------------------------------------------------------------------
                        With CApplicationController.oCUsers

                            .id = oDataSet.Tables("Usuario").Rows(0).Item("id")
                            .centro_id = oDataSet.Tables("Usuario").Rows(0).Item("centro_id")
                            .usuario_nombre = oDataSet.Tables("Usuario").Rows(0).Item("usuario_nombre").ToString.Trim
                            .usuario_descripcion = oDataSet.Tables("Usuario").Rows(0).Item("usuario_descripcion").ToString.Trim

                        End With
                        ' ----------------------------------------------------------------------------------
                        ' Get User Access Profile.
                        ' ----------------------------------------------------------------------------------
                        'If Not CApplicationController.oCUsers.GetUserRelatedProfile(CApplicationController.oCUsers.usuario_id) Then

                        '    'Throw New CustomException("No hay pérfil de acceso definido para el usuario:  " & CApplicationController.oCUsers.usuario_id, CApplication.MailExceptionTypes.AtlasSystemError)

                        'End If

                    End Using

                End Using

            End Using


            AuthenticateUser = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return AuthenticateUser

    End Function

    Private Function PrepareCommand(ByVal value As Integer) As Boolean

        Try
            oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_USERS")
            oSqlCommand.CommandType = CommandType.StoredProcedure

            ' --------------------------------------------------------------------------
            ' Parameter Assignation
            ' --------------------------------------------------------------------------
            With oSqlCommand.Parameters

                .Add("@centro_id", SqlDbType.Int).Value = CApplicationController.oCWorkCenter_.id
                .Add("@usuario_nombre", SqlDbType.VarChar).Value = CApplicationController.oCUsers.usuario_nombre
                .Add("@usuario_contraseña", SqlDbType.NVarChar).Value = CApplicationController.oCUsers.usuario_contraseña
                .Add("@command", SqlDbType.Int).Value = value

            End With

            PrepareCommand = True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return PrepareCommand

    End Function


    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLogin.Click

        tUsuarioId.Text = "ADMIN"
        tPassword.Text = "ADMIN"

        If Not CApplicationHelper.CheckRequiredFieldsHelper(tUsuarioId) Then Exit Sub
        If Not CApplicationHelper.CheckRequiredFieldsHelper(tPassword) Then Exit Sub

        CApplicationController.oCUsers.usuario_nombre = tUsuarioId.Text.Trim
        CApplicationController.oCUsers.usuario_contraseña = tPassword.Text.Trim
        CApplicationController.oCWorkCenter_.id = Me.cbWorkCenter.SelectedValue

        Try

            ' Process Execution.
            Me.BWorkerAuthenticate.RunWorkerAsync()

            'Show Progress Window.
            Me.oFProgress = New FProgress
            Me.oFProgress.ShowDialog()

            If Not CApplicationController.is_access_granted Then

                Me.tUsuarioId.Focus()
                Throw New CustomException

            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK : Me.Dispose()

        Catch ex As CustomException

        End Try

    End Sub

    Private Sub BWorkerAuthenticate_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWorkerAuthenticate.DoWork

        Try
            '' Show Progress Window.
            'Me.oFProgress = New FProgress
            'Me.oFProgress.ShowDialog()

            'e.Result = myWorkDel("pitufin")

            e.Result = Me.InitApplicationData()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub BWorkerAuthenticate_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWorkerAuthenticate.RunWorkerCompleted

        Try

            If e.Result Then CApplicationController.is_access_granted = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End

        Finally

            Me.oFProgress.Dispose()
            BWorkerAuthenticate.Dispose()

        End Try


    End Sub

    Private Sub AcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oAboutBox As New AboutBox

        oAboutBox.StartPosition = FormStartPosition.CenterScreen
        oAboutBox.ShowDialog()

    End Sub

    Private Sub tUsuarioId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tUsuarioId.KeyDown

        Me.lbCapsLockWarning.Visible = My.Computer.Keyboard.CapsLock

    End Sub


    Private Sub tPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tPassword.KeyDown

        Me.lbCapsLockWarning.Visible = My.Computer.Keyboard.CapsLock

    End Sub

    'Delegate Sub ProgressChange(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)

    Delegate Sub ProgressChange()

    'Dim myMethodAsync As New ProgressChange(AddressOf somthing)

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click

        'Dim ProgressChanged As New ProgressChange(AddressOf bw_ProgressChanged)

        'Me.Invoke(ProgressChanged, Nothing, EventArgs.Empty)

        '-----------------------------------------------------------------
        End

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        BackgroundWorkerTemplate.RunWorkerAsync()

        BWorkerAuthenticate.RunWorkerAsync()

    End Sub

    'This is where, I create a Delegate with String Parameter
    'Public Delegate Function SomeWorkDelegate(ByVal strSomeString As String) As Boolean

    'Dim myWorkDel As SomeWorkDelegate = New SomeWorkDelegate(AddressOf DoSomeWork)

    Dim WorkDelegate As DoWorkDelegate = New DoWorkDelegate(AddressOf DoSomeWork)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Function DoSomeWork(ByVal strWork As String) As Boolean

        'Console.Write(strWork)
        Return True
    End Function


End Class
