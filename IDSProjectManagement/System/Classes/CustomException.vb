
Public Class CustomException
    Inherits Exception

    Private _exception_level As Short

    Public Property exception_level() As Short
        Get
            Return _exception_level
        End Get
        Set(ByVal value As Short)

            _exception_level = value
        End Set
    End Property

    Private _msg_caption As String

    Public Property msg_caption() As String
        Get
            Return _msg_caption
        End Get
        Set(ByVal value As String)

            _msg_caption = value
        End Set
    End Property

    Private _oMessageBoxButtons As MessageBoxButtons

    Public Property oMessageBoxButtons() As MessageBoxButtons
        Get
            Return _oMessageBoxButtons
        End Get
        Set(ByVal value As MessageBoxButtons)

            _oMessageBoxButtons = value
        End Set
    End Property

    Private _oMessageBoxIcon As MessageBoxIcon

    Public Property oMessageBoxIcon() As MessageBoxIcon
        Get
            Return _oMessageBoxIcon
        End Get
        Set(ByVal value As MessageBoxIcon)

            _oMessageBoxIcon = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal message As String, ByVal value As Short)

        MyBase.New(message)

        'Dim oCMailServices As New CMailServices

        Select Case value

            Case CApplication.MailExceptionTypes.Succesful

            Case CApplication.MailExceptionTypes.Warning

            Case CApplication.MailExceptionTypes.RecoverableError

            Case CApplication.MailExceptionTypes.NonRecoverableError

                Me.msg_caption = "Atención"
                Me.oMessageBoxButtons = MessageBoxButtons.OK
                Me.oMessageBoxIcon = MessageBoxIcon.Error

                'With oCMailServices

                '    '' Set Mail Data Details.
                '    '.centro_id = CApplicationController.oCWorkCenter_.centro_id
                '    '.usuario_id = CApplicationController.oCUsers.empleado_id

                '    '.body = message & vbCrLf
                '    '.body = .body & vbCrLf & "Enviado el " & CApplication.GetCurrentDateTime.ToString("d") & " a las: " & CApplication.GetCurrentDateTime.ToString("T") & vbCrLf

                '    '.body = .body & "CENTRO: " & CApplicationController.oCWorkCenter_.centro_id & vbCrLf
                '    '.body = .body & "USUARIO: " & CApplicationController.oCUsers.empleado_id & vbCrLf

                '    '.subject = "Informe de Excepción." &
                '    '" CENTRO: " & CApplicationController.oCWorkCenter_.centro_id &
                '    '" USUARIO: " & CApplicationController.oCUsers.empleado_id

                '    '.to_recipients.Add("destrada.cabita@gmail.com")

                '    '' Sending Mail.
                '    '.SendMail()

                'End With

            Case CApplication.MailExceptionTypes.SapError

                Me.msg_caption = "Atención"
                Me.oMessageBoxButtons = MessageBoxButtons.OK
                Me.oMessageBoxIcon = MessageBoxIcon.Error

                'With oCMailServices

                '    '' Set Mail Data Details.
                '    '.centro_id = CApplicationController.oCWorkCenter_.centro_id
                '    '.usuario_id = CApplicationController.oCUsers.empleado_id

                '    '.body = message & vbCrLf
                '    '.body = .body & vbCrLf & "Enviado el " & CApplication.GetCurrentDateTime.ToString("d") & " a las: " & CApplication.GetCurrentDateTime.ToString("T") & vbCrLf

                '    '.body = .body & "CENTRO: " & CApplicationController.oCWorkCenter_.centro_id & vbCrLf
                '    '.body = .body & "USUARIO: " & CApplicationController.oCUsers.empleado_id & vbCrLf

                '    '.subject = "ATLAS - Informe de Excepción." & _
                '    '" CENTRO: " & CApplicationController.oCWorkCenter_.centro_id & _
                '    '" USUARIO: " & CApplicationController.oCUsers.empleado_id

                '    '.to_recipients.Add("destrada@mexichem.com")
                '    '.to_recipients.Add("royola@mexichem.com")
                '    '.to_recipients.Add("cjimeneb@mexichem.com")
                '    '.to_recipients.Add("wperezp@mexichem.com")
                '    ''.to_recipients.Add("chernand@mexichem.com")

                '    '' Sending Mail.
                '    '.SendMail()

                'End With

            Case CApplication.MailExceptionTypes.ProductionReportError

                Me.msg_caption = "Atención"
                Me.oMessageBoxButtons = MessageBoxButtons.OK
                Me.oMessageBoxIcon = MessageBoxIcon.Error

                'With oCMailServices

                '    ' Set Mail Data Details.
                '    .centro_id = CApplicationController.oCWorkCenter_.centro_id
                '    .usuario_id = CApplicationController.oCUsers.empleado_id

                '    .body = message & vbCrLf
                '    .body = .body & vbCrLf & "Enviado el " & CApplication.GetCurrentDateTime.ToString("d") & " a las: " & CApplication.GetCurrentDateTime.ToString("T") & vbCrLf

                '    .body = .body & "CENTRO: " & CApplicationController.oCWorkCenter_.centro_id & vbCrLf
                '    .body = .body & "USUARIO: " & CApplicationController.oCUsers.empleado_id & vbCrLf

                '    .subject = "ATLAS - Informe de Excepción." & _
                '    " CENTRO: " & CApplicationController.oCWorkCenter_.centro_id & _
                '    " USUARIO: " & CApplicationController.oCUsers.empleado_id

                '    .to_recipients.Add("destrada@mexichem.com")
                '    .to_recipients.Add("royola@mexichem.com")
                '    .to_recipients.Add("cjimeneb@mexichem.com")
                '    .to_recipients.Add("wperezp@mexichem.com")
                '    '.to_recipients.Add("chernand@mexichem.com")

                '    ' Sending Mail.
                '    .SendMail()

                'End With

            Case CApplication.MailExceptionTypes.SystemError

                Me.msg_caption = "Atención"
                Me.oMessageBoxButtons = MessageBoxButtons.OK
                Me.oMessageBoxIcon = MessageBoxIcon.Error

                'With oCMailServices

                '    ' Set Mail Data Details.
                '    .centro_id = CApplicationController.oCWorkCenter_.centro_id
                '    .usuario_id = CApplicationController.oCUsers.empleado_id

                '    .body = message & vbCrLf
                '    .body = .body & vbCrLf & "Enviado el " & CApplication.GetCurrentDateTime.ToString("d") & " a las: " & CApplication.GetCurrentDateTime.ToString("T") & vbCrLf

                '    .body = .body & "CENTRO: " & CApplicationController.oCWorkCenter_.centro_id & vbCrLf
                '    .body = .body & "USUARIO: " & CApplicationController.oCUsers.empleado_id & vbCrLf

                '    .subject = "ATLAS - Informe de Excepción." & _
                '    " CENTRO: " & CApplicationController.oCWorkCenter_.centro_id & _
                '    " USUARIO: " & CApplicationController.oCUsers.empleado_id

                '    .to_recipients.Add("destrada@mexichem.com")

                '    ' Sending Mail.
                '    .SendMail()

                'End With

        End Select

    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
    Public Sub New(ByVal message As String, ByVal InnerException As Exception)
        MyBase.New(message, InnerException)
    End Sub
    Public Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
        MyBase.New(info, context)
    End Sub

    Public Class DeleteRecordException
        Inherits Exception

        Private _message_text As String = "Algo"

        Public Sub x()

            MessageBox.Show("Atención", _message_text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Sub

        Public Sub New()

            MyBase.New()


            x()


        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal InnerExecption As Exception)
            MyBase.New(message, InnerExecption)
        End Sub
        Public Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
        End Sub

    End Class

End Class