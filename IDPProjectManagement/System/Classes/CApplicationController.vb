Friend Class CApplicationController

    Shared _tipo_notificacion As String
    Shared Property tipo_notificacion() As String
        Get
            Return _tipo_notificacion
        End Get
        Set(ByVal value As String)
            _tipo_notificacion = value
        End Set
    End Property

    Private _oFProgress As New FProgress
    Public Property oFProgress() As FProgress
        Get
            Return _oFProgress
        End Get
        Set(ByVal value As FProgress)
            _oFProgress = value
        End Set
    End Property

    Shared _oCUsers As New CUsers
    Shared Property oCUsers() As CUsers
        Get
            Return _oCUsers
        End Get
        Set(ByVal value As CUsers)
            _oCUsers = value
        End Set
    End Property

    Shared _oCEmployee As New CEmployee
    Shared Property oCEmployees() As CEmployee
        Get
            Return _oCEmployee
        End Get
        Set(ByVal value As CEmployee)
            _oCEmployee = value
        End Set
    End Property

    Shared _oCWorkCenter As New CWorkCenter
    Shared Property oCWorkCenter_() As CWorkCenter
        Get
            Return _oCWorkCenter
        End Get
        Set(ByVal value As CWorkCenter)
            _oCWorkCenter = value
        End Set
    End Property

    Shared _oCMenuController As New CMenuController_
    Shared Property oCMenuController_() As CMenuController_
        Get
            Return _oCMenuController
        End Get
        Set(ByVal value As CMenuController_)
            _oCMenuController = value
        End Set
    End Property

    Shared _oCDataBase As New CDataBase
    Shared Property oCDataBase() As CDataBase
        Get
            Return _oCDataBase
        End Get
        Set(ByVal value As CDataBase)
            _oCDataBase = value
        End Set
    End Property

    Shared _oCSystemParameters As New CSystemParameters
    Shared Property oCSystemParameters() As CSystemParameters
        Get
            Return _oCSystemParameters
        End Get
        Set(ByVal value As CSystemParameters)
            _oCSystemParameters = value
        End Set
    End Property

    'Shared _oCMailServices As CMailServices
    'Shared Property oCMailServices() As CMailServices
    '    Get
    '        Return _oCMailServices
    '    End Get
    '    Set(ByVal value As CMailServices)
    '        _oCMailServices = value
    '    End Set
    'End Property

    Public Shared _is_access_granted As Boolean = False
    Public Shared Property is_access_granted() As Boolean
        Get
            Return _is_access_granted

        End Get

        Set(ByVal value As Boolean)

            _is_access_granted = value

        End Set
    End Property

    Public Shared _grant_execute_app As Boolean = False
    Public Shared Property grant_execute_app() As Boolean
        Get
            Return _grant_execute_app

        End Get

        Set(ByVal value As Boolean)

            _grant_execute_app = value

        End Set
    End Property


    'Public Shared Function GetSapInstance() As CSap

    '    Dim oCSap As CSap

    '    oCSap = New CSap

    '    Return oCSap

    'End Function

    Public Shared Function GetProgressFormInstance() As FProgress

        Dim oFProgress As FProgress

        oFProgress = New FProgress

        Return oFProgress

    End Function

    'Public Shared Function GetWorkOrderInstance() As CWorkOrder

    '    Dim oCWorkOrder As CWorkOrder

    '    oCWorkOrder = New CWorkOrder

    '    Return oCWorkOrder

    'End Function

    'Public Shared Function GetRacksInstance() As CRacks

    '    Dim oCracks As CRacks

    '    oCracks = New CRacks

    '    Return oCracks

    'End Function

    'Public Shared Function GetReportingProcessInstance() As CReportingProcess

    '    Dim oCReportingProcess As New CReportingProcess

    '    Return oCReportingProcess

    'End Function

    'Public Shared Function GetProductionReportInstance() As CProductionReport

    '    Dim oCProductionReport As New CProductionReport

    '    Return oCProductionReport

    'End Function

    Public Shared Sub ReleaseObject(ByVal value As Object)
        Try

            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(value) > 0)
            End While

            'System.Runtime.InteropServices.Marshal.ReleaseComObject(value)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Finally

            value = Nothing

            GC.Collect()

        End Try

    End Sub

End Class
