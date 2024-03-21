Imports System.Data.SqlClient
Imports System.Resources
Imports System.Reflection
Imports System.Globalization
Imports System.ComponentModel


Friend Class CApplication

    <STAThread()>
    Shared Sub Main()

        Dim oFLoginForm As New FLoginForm

        Call CApplication.SetCultureSettings()

        If oFLoginForm.ShowDialog() = DialogResult.OK Then
            Application.Run(FAdministrationMenu)
        End If

        FCatalogFormTemplate.Show()

    End Sub


    Public Enum FormatPattern
        NumericDouble = 2
    End Enum

    Public Enum ProductionOrderStatus

        Process = 0
        Closed = 1
        Cancelled = 3

    End Enum

    Public Enum ProductionReportStatus

        ReportadoEnSap = 0
        ReportadoSoloAtlas = 1
        SapInhabilitado = 2
        ReportadoEnBatch = 3
        NoReportadoErrorSap = 4

    End Enum


    Public Enum RecordStatus

        RecordOpen = 0
        RecordCancelled = 1
        RecordFinished = 2

    End Enum

    Public Enum SPCommand

        ' ATENCION: checar CONSECUTIVO.
        GetSapConnection = 1
        GetComboMaterialType = 2
        GetComboMaterialClass = 3
        GetComboPositions = 4
        GetComboManagers = 5
        GetComboShifts = 6
        GetComboScrapSubCauses = 7
        GetComboProductFamily = 8
        GetComboProducts = 9
        GetComboMeasure = 10
        GetComboMachinery = 11
        GetComboProcesses = 12
        GetComboEmployees = 13

        GetComboWorkCenter = 15
        GetComboWorkOrders = 16
        GetComboActiveWorkOrders = 17

        GetComboMenuLevels = 18
        GetComboMenus = 19
        GetComboMenuButtons = 21

        GetComboStopCauses = 22
        GetComboStopSubCauses = 23
        GetComboScrap = 24
        GetComboPartClasification = 25
        GetComboMaterials = 26
        GetComboCompounds = 27
        GetComboWarehouses = 28
        GetComboCompoundsOnNew = 29

        ' de otro SP
        GetComboRacks = 20

        GetEmployeesByPosition = 60
        GetSectionsCombo = 30

        GetComboScrapTypes = 31
        GetComboRTMGroup = 32
        GetComboCostCenter = 33
        GetComboTradeMark = 34
        GetComboRawMaterial = 35
        GetComboMonitors = 36
        GetComboMolds = 37

        GetComboUsers = 38
        GetComboStopCausesRelation = 39

        GetComboSystemFormsOnNew = 40
        GetComboSystemForms = 41

        GetComboPresentation = 42
        ' ** SIGUIENTE COMBO AQUI 

    End Enum

    Public Enum TipoCalculoEnum
        NA = 0
        Covencional = 1
        Fijo = 2
        Corrugado = 3
    End Enum

    Public Enum ViewMode
        SingleView = 1
        Multiview = 2
        SingleViewWOutGrid = 3
    End Enum

    Public Enum WeekDays

        LUN = 1
        MAR = 2
        MIE = 3
        JUE = 4
        VIE = 5
        SAB = 6
        DOM = 7

    End Enum

    Public Enum MailExceptionTypes

        Succesful = 0
        Warning = 1
        RecoverableError = 2
        NonRecoverableError = 3
        SapError = 4
        ProductionReportError = 5
        SystemError = 6
        GetTheFOutOfHere = 99

    End Enum

    Public Shared _usuario_id As String
    'Public Shared oCWorkCenter As New CWorkCenter
    'Public Shared oCWorkShifts As New CWorkShifts

    Public Shared oUsers As New CUsers

    Public Shared p_app_config_xml_file As String = String.Empty

    Public Shared p_app_environment As String

    Public Shared p_NotAssignedValue As String = String.Empty

    Public Shared p_save_to_sap As Boolean

    Public Shared p_user_password As String

    Public Enum ControlState

        None = 0
        InitState = 1
        MultiView = 2
        Add = 3
        Edit = 4
        Delete = 5
        SaveCommand = 6
        Update = 7
        Cancel = 8
        Query = 9
        Find = 10
        ExecFind = 11

    End Enum

    Public Enum ControlStateDefinition

        <Description("NA")> None = 0
        <Description("EN ESPERA")> InitState = 1
        <Description("MULTI-VISTA")> MultiView = 2
        <Description("AGREGAR")> Add = 3
        <Description("EDITAR")> Edit = 4
        <Description("ELIMINANDO")> Delete = 5
        <Description("GUARDANDO")> Saving = 6
        <Description("ACTUALIZANDO")> Update = 7
        <Description("CANCELANDO")> Cancel = 8
        <Description("CONSULTA")> Query = 9
        <Description("BUSCAR")> Find = 10
        <Description("BUSCANDO")> Finding = 11

    End Enum
    Public Enum FormProcessType
        Catalog = 1
        Parent = 2
        Child = 3
    End Enum
    Public Shared Function GetFormStateDescription(ByVal value As Integer) As String

        Dim EnumConstant As [Enum]
        
        Select Case value

            Case ControlStateDefinition.InitState

                EnumConstant = ControlStateDefinition.InitState

            Case ControlStateDefinition.MultiView

                EnumConstant = ControlStateDefinition.MultiView

            Case ControlState.Add

                EnumConstant = ControlStateDefinition.Add

            Case ControlState.Edit

                EnumConstant = ControlStateDefinition.Edit

            Case ControlState.Delete

                EnumConstant = ControlStateDefinition.Delete

            Case ControlState.SaveCommand

                EnumConstant = ControlStateDefinition.Saving

            Case ControlState.Update

                EnumConstant = ControlStateDefinition.Update

            Case ControlState.Cancel

                EnumConstant = ControlStateDefinition.Cancel

            Case ControlState.Query

                EnumConstant = ControlStateDefinition.Query

            Case ControlState.Find

                EnumConstant = ControlStateDefinition.Find

            Case ControlState.ExecFind

                EnumConstant = ControlStateDefinition.Finding

            Case Else

                EnumConstant = ControlStateDefinition.None

        End Select


        Dim fieldInfo As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())

        Dim atribute() As DescriptionAttribute = DirectCast(fieldInfo.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())

        If atribute.Length > 0 Then
            Return atribute(0).Description
        Else
            Return EnumConstant.ToString()
        End If

    End Function

    Public Shared Function GetFormState(ByVal value As Integer) As String

        Select Case value

            Case ControlStateDefinition.InitState

                Return GetFormStateDescription(ControlStateDefinition.InitState)

            Case ControlStateDefinition.MultiView


                Return "MultiView"
            Case ControlState.Add
                Return "Add"
            Case ControlState.Edit
                Return "Edit"
            Case ControlState.Delete
                Return "Delete"
            Case ControlState.SaveCommand
                Return "SaveCommand"
            Case ControlState.Update
                Return "Update"
            Case ControlState.Cancel
                Return "Cancel"
            Case ControlState.Query
                Return "Query"
            Case ControlState.None
                Return "None"
            Case Else
                Return "N/A"
        End Select

    End Function

    Public Shared Function GetFormStateO(ByVal value As Integer) As String

        Select Case value

            Case ControlState.InitState

                Return GetFormStateDescription(ControlStateDefinition.InitState)

            Case ControlState.MultiView
                Return "MultiView"
            Case ControlState.Add
                Return "Add"
            Case ControlState.Edit
                Return "Edit"
            Case ControlState.Delete
                Return "Delete"
            Case ControlState.SaveCommand
                Return "SaveCommand"
            Case ControlState.Update
                Return "Update"
            Case ControlState.Cancel
                Return "Cancel"
            Case ControlState.Query
                Return "Query"
            Case ControlState.None
                Return "None"
            Case Else
                Return "N/A"
        End Select

    End Function

    Public Shared Function CheckRequiredFields(ByVal oObject As Object) As Boolean

        Dim oRequiredText As String = String.Empty

        Try

            If TypeOf oObject Is TextBox Then

                oRequiredText = DirectCast(oObject, TextBox).Text.Trim

            ElseIf TypeOf oObject Is ComboBox Then

                oRequiredText = DirectCast(oObject, ComboBox).Text.Trim

            ElseIf TypeOf oObject Is DateTimePicker Then

                oRequiredText = DirectCast(oObject, DateTimePicker).Text

            End If


            If String.IsNullOrEmpty(oRequiredText) Then oObject.Focus() : Throw New LocalExceptions.RequieredFieldException(oObject.Tag)

            Return True


        Catch ex As LocalExceptions.RequieredFieldException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)


        End Try

    End Function

    'Public Shared Function GetApplicationToolIcon() As ToolTipIcon

    '    Dim oResourceManager As New ResourceManager("IDPProjectManagement.Resources", Assembly.GetExecutingAssembly())

    '    Return oResourceManager.GetObject("Kaluz_LogoIconSmall")

    'End Function

    Public Shared Function GetApplicationIcon() As Icon

        Try

            '      Dim oResourceManager As New ResourceManager("IDPProjectManagement.Resources", Assembly.GetExecutingAssembly())

            Return My.Resources.AppSmallIcon  '  oResourceManager.GetObject("Kaluz_LogoIconSmall")

        Catch ex As Exception

            Return Nothing

        End Try
        

    End Function

    Public Shared Function GetComboActiveWorkOrders(ByRef oBindingSource As BindingSource) As Boolean

        'Dim oDataSet As New DataSet
        'Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        'Dim oSqlDataAdapter As New SqlDataAdapter
        'Dim oResponse As New SqlParameter

        'oSqlCommand.CommandType = CommandType.StoredProcedure

        'oBindingSource = New BindingSource

        'Try
        '    oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id

        '    oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboActiveWorkOrders

        '    oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
        '    oResponse.Direction = ParameterDirection.Output

        '    oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

        '    If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

        '    oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

        '    oSqlDataAdapter.Fill(oDataSet, "GetActiveOrdersCombo")

        '    If Not CBool(CInt(oDataSet.Tables("GetActiveOrdersCombo").Rows.Count)) Then MessageBox.Show("No existen valores en la tabla Ordenes de Trabajo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        '    oBindingSource.DataSource = oDataSet.Tables("GetActiveOrdersCombo")

        '    Return True

        'Catch ex As CustomException

        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Catch ex As Exception

        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Finally

        '    If Not oDataSet Is Nothing Then oDataSet.Dispose()

        '    If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        '    If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        'End Try

    End Function

    Public Shared Function GetComboUsers(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter


        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboUsers

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboUsers")

            If Not CBool(CInt(oDataSet.Tables("GetComboUsers").Rows.Count)) Then MessageBox.Show("No existen valores en la tabla Usuarios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

            oBindingSource.DataSource = oDataSet.Tables("GetComboUsers")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboEmployees(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        'Dim oBindingSourceCombo As New BindingSource

        '  oDataSet = New DataSet
        'oSqlCommand = New SqlCommand("dbo.[ASP_PROCESS_APPLICATION]")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboEmployees

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboEmpleados")

            If Not CBool(CInt(oDataSet.Tables("GetComboEmpleados").Rows.Count)) Then MessageBox.Show("No existen valores en la tabla Tipos de Personal.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error) ' Throw New CustomException("No existen valores en la tabla de tipos de Personal.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboEmpleados")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboEmployeesByPosition(ByRef oComboDummy As ComboBox, ByVal value As String) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_EMPLOYEES")
        Dim oResponse As New SqlParameter
        Dim oSqlDataAdapter As New SqlDataAdapter

        Try
            With oSqlCommand

                .CommandType = CommandType.StoredProcedure

                .Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
                .Parameters.Add("@puesto_id", SqlDbType.NVarChar).Value = value
                .Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetEmployeesByPosition

            End With

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "@GetEmployeesByPosition")

            If CBool(CInt(oDataSet.Tables("@GetEmployeesByPosition").Rows.Count)) Then

                With oComboDummy
                    .DataSource = oDataSet.Tables("@GetEmployeesByPosition")
                    .DisplayMember = "empleado_combo"
                    .ValueMember = "empleado_id"
                    .SelectedIndex = 0
                End With

            Else

                Throw New CustomException("No existe información de Monitores.")

            End If

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboMachinery(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboMachinery

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboMachinery")

            If Not CBool(CInt(oDataSet.Tables("GetComboMachinery").Rows.Count)) Then MessageBox.Show("No existen valores en la tabla Máquinas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error) ' Then Throw New CustomException("No existen valores en la tabla de Máquinas.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboMachinery")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboMolds(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboMolds

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboMolds")

            If Not CBool(CInt(oDataSet.Tables("GetComboMolds").Rows.Count)) Then MessageBox.Show("No existen valores en la tabla Moldes.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

            oBindingSource.DataSource = oDataSet.Tables("GetComboMolds")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboManagers(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter


        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboManagers

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboManagers")

            If Not CBool(CInt(oDataSet.Tables("GetComboManagers").Rows.Count)) Then MessageBox.Show("No existen valores en la tabla Personal.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Throw New CustomException("No existen valores en la tabla de Personal.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboManagers")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboSystemFormsOnNew(ByRef oBindingSource As BindingSource, ByRef value As String) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@perfil_id", SqlDbType.NVarChar).Value = value

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboSystemFormsOnNew

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboSystemFormsOnNew")

            If Not CBool(CInt(oDataSet.Tables("GetComboSystemFormsOnNew").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Formularios.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboSystemFormsOnNew")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboSystemForms(ByRef oBindingSource As BindingSource, ByRef value As String) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@perfil_id", SqlDbType.NVarChar).Value = value

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboSystemForms

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboSystemForms")

            If Not CBool(CInt(oDataSet.Tables("GetComboSystemForms").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Formularios.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboSystemForms")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboMaterialType(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboMaterialType

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetMaterialTypeCombo")

            If Not CBool(CInt(oDataSet.Tables("GetMaterialTypeCombo").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Tipos de Material.")

            oBindingSource.DataSource = oDataSet.Tables("GetMaterialTypeCombo")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboMonitors(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboMonitors

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboMonitors")

            If Not CBool(CInt(oDataSet.Tables("GetComboMonitors").Rows.Count)) Then Throw New CustomException("No existen valores para Monitores.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboMonitors")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboWarehouses(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboWarehouses

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboWarehouses")

            If Not CBool(CInt(oDataSet.Tables("GetComboWarehouses").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Almacenes.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboWarehouses")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboCompounds(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboCompounds

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboCompounds")

            If Not CBool(CInt(oDataSet.Tables("GetComboCompounds").Rows.Count)) Then MessageBox.Show("No existen valores en la tabla Compuestos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Throw New CustomException("No existen valores en la tabla de compuestos.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboCompounds")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboRawMaterial(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboRawMaterial

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboCompounds")

            If Not CBool(CInt(oDataSet.Tables("GetComboCompounds").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de compuestos.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboCompounds")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboCompoundsOnNew(ByRef oBindingSource As BindingSource, ByRef value As String) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@producto_id", SqlDbType.NVarChar).Value = value

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboCompoundsOnNew

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboCompounds")

            If Not CBool(CInt(oDataSet.Tables("GetComboCompounds").Rows.Count)) Then MessageBox.Show("No existen valores para el combo Compuestos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Throw New CustomException("No existen valores en la tabla de compuestos.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboCompounds")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function


    Public Shared Function GetComboMeasures(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_MEASURE")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboMeasure

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboMeasure")

            If Not CBool(CInt(oDataSet.Tables("GetComboMeasure").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de medidas.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboMeasure")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboPresentation(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_PRESENTATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboPresentation

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboPresentation")

            If Not CBool(CInt(oDataSet.Tables("GetComboPresentation").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de presentaciones.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboPresentation")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboMenuButtons(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboMenuButtons

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboMenuButtons")

            If Not CBool(CInt(oDataSet.Tables("GetComboMenuButtons").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Botones de Menu.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboMenuButtons")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboMenus(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboMenus

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetMenusCombo")

            If Not CBool(CInt(oDataSet.Tables("GetMenusCombo").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Menus.")

            oBindingSource.DataSource = oDataSet.Tables("GetMenusCombo")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboNivelesMenu(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboMenuLevels

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetLevelsCombo")

            If Not CBool(CInt(oDataSet.Tables("GetLevelsCombo").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla Niveles de Menú.")

            oBindingSource.DataSource = oDataSet.Tables("GetLevelsCombo")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function



    Public Shared Function GetComboPositions(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        'Dim oBindingSourceCombo As New BindingSource

        '  oDataSet = New DataSet
        'oSqlCommand = New SqlCommand("dbo.[ASP_PROCESS_APPLICATION]")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboPositions

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboPositions")

            If Not CBool(CInt(oDataSet.Tables("GetComboPositions").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Puestos de Trabajo.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboPositions")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboProcesses(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboProcesses

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboProcesses")

            If Not CBool(CInt(oDataSet.Tables("GetComboProcesses").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Personal.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboProcesses")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboPartClasification(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboPartClasification

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboPartClasif")

            If Not CBool(CInt(oDataSet.Tables("GetComboPartClasif").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Clasificaciones.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboPartClasif")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboTradeMark(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboTradeMark

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboTradeMark")

            If Not CBool(CInt(oDataSet.Tables("GetComboTradeMark").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Marcas.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboTradeMark")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboRTMGroup(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboRTMGroup

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboRTMGroup")

            If Not CBool(CInt(oDataSet.Tables("GetComboRTMGroup").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Grupos RTM.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboRTMGroup")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboCostCenter(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboCostCenter

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboCostCenter")

            If Not CBool(CInt(oDataSet.Tables("GetComboCostCenter").Rows.Count)) Then MessageBox.Show("No existen valores en la tabla Centros de Costo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Throw New CustomException("No existen valores en la tabla de Centros de Costo.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboCostCenter")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboProductFamily(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboProductFamily

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboProductFamily")

            If Not CBool(CInt(oDataSet.Tables("GetComboProductFamily").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla Familia de Productos.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboProductFamily")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboMaterials(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboMaterials

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboProducts")

            If Not CBool(CInt(oDataSet.Tables("GetComboProducts").Rows.Count)) Then MessageBox.Show("No existen valores en la tabla Productos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error) ' Throw New CustomException("No existen valores en la tabla de Productos.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboProducts")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboProducts(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboProducts

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboProducts")

            If Not CBool(CInt(oDataSet.Tables("GetComboProducts").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Productos.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboProducts")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboRacks(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_RACKS")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboRacks

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboRacks")

            If Not CBool(CInt(oDataSet.Tables("GetComboRacks").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de medidas.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboRacks")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboRacks(ByRef oComboDummy As ComboBox) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_RACKS")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboRacks

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboRacks")

            If CBool(CInt(oDataSet.Tables("GetComboRacks").Rows.Count)) Then

                With oComboDummy
                    .DataSource = oDataSet.Tables("GetComboRacks")
                    .DisplayMember = "rack_combo"
                    .ValueMember = "rack_id"
                    .SelectedIndex = 0
                End With

            Else
                oComboDummy.Items.Add("M - Peso Asignado Manualmente")
                oComboDummy.ValueMember = "M"
                oComboDummy.DisplayMember = "M - Peso Asignado Manualmente"
                oComboDummy.SelectedIndex = 0

                '  Throw New CustomException("No existe información de Racks.")

            End If

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboRecordStatus(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As DataSet
        Dim oDataTable As DataTable
        Dim oDataRow As DataRow

        Dim oDictionary As New Dictionary(Of Integer, String)

        With oDictionary

            .Add(RecordStatus.RecordOpen, "Abierta")
            .Add(RecordStatus.RecordCancelled, "Cancelada")
            .Add(RecordStatus.RecordFinished, "Cerrada")

        End With


        ' ----------------------------------------------------------------------
        ' Create Table.
        oDataTable = New DataTable("RecordStatusTable")

        Try

            ' Define Columns.
            Dim registro_estatus As DataColumn = New DataColumn("registro_estatus")
            Dim combo_registro_estatus As DataColumn = New DataColumn("combo_registro_estatus")

            registro_estatus.DataType = System.Type.GetType("System.String")
            combo_registro_estatus.DataType = System.Type.GetType("System.String")

            ' Add Columnns to Table.
            oDataTable.Columns.Add(registro_estatus)
            oDataTable.Columns.Add(combo_registro_estatus)
            ' ----------------------------------------------------------------------

            For Each valuePair As KeyValuePair(Of Integer, String) In oDictionary

                oDataRow = oDataTable.NewRow()

                oDataRow.Item("registro_estatus") = valuePair.Key.ToString
                oDataRow.Item("combo_registro_estatus") = valuePair.Key & " - " & valuePair.Value

                oDataTable.Rows.Add(oDataRow)

            Next

            oDataSet = New DataSet

            oDataSet.Tables.Add(oDataTable)

            oBindingSource = New BindingSource

            oBindingSource.DataSource = oDataSet.Tables("RecordStatusTable")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function


    Public Shared Function GetComboReportRecordStatuso(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oDataTable As DataTable
        Dim oDataRow1, oDataRow2, oDataRow3 As DataRow

        ' Create Table.
        oDataTable = New DataTable("ReporteRegistroEstatus")

        ' Define Columns.
        Dim registro_estatus As DataColumn = New DataColumn("registro_estatus")
        Dim combo_registro_estatus As DataColumn = New DataColumn("combo_registro_estatus")

        registro_estatus.DataType = System.Type.GetType("System.String")
        combo_registro_estatus.DataType = System.Type.GetType("System.String")

        ' Add Columnns to Table.
        oDataTable.Columns.Add(registro_estatus)
        oDataTable.Columns.Add(combo_registro_estatus)

        ' Create Rows.
        oDataRow1 = oDataTable.NewRow
        oDataRow2 = oDataTable.NewRow
        oDataRow3 = oDataTable.NewRow

        ' Add Row Values.

        oDataRow1.Item("registro_estatus") = Char.Parse(RecordStatus.RecordOpen)
        oDataRow1.Item("combo_registro_estatus") = "0 - Notificación Abierta"
        oDataRow2.Item("registro_estatus") = Char.Parse(RecordStatus.RecordFinished)
        oDataRow2.Item("combo_registro_estatus") = "1 - Notificación Terminada"
        oDataRow3.Item("registro_estatus") = Char.Parse(RecordStatus.RecordCancelled)
        oDataRow3.Item("combo_registro_estatus") = "2 - Notificación Cancelada"


        With oDataTable.Rows
            .Add(oDataRow1)
            .Add(oDataRow2)
            .Add(oDataRow3)
        End With

        oDataSet.Tables.Add(oDataTable)

        oBindingSource = New BindingSource

        Try

            oBindingSource.DataSource = oDataSet.Tables("ReporteRegistroEstatus")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function


    Public Shared Function GetComboReportStatus(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As DataSet
        Dim oDataTable As DataTable
        Dim oDataRow As DataRow

        Dim oDictionary As New Dictionary(Of Integer, String)

        With oDictionary

            .Add(ProductionReportStatus.ReportadoEnSap, "Reportado En Sap")
            .Add(ProductionReportStatus.ReportadoSoloAtlas, "Reportado En Atlas")
            .Add(ProductionReportStatus.SapInhabilitado, "Sap Inhabilitado - Reportado En Atlas")
            .Add(ProductionReportStatus.ReportadoEnBatch, "Reportado En Batch")
            .Add(ProductionReportStatus.NoReportadoErrorSap, "No Reportado - ErrorSap")

        End With


        ' ----------------------------------------------------------------------
        ' Create Table.
        oDataTable = New DataTable("ReportStatusTable")

        Try

            ' Define Columns.
            Dim reporte_estatus As DataColumn = New DataColumn("reporte_estatus")
            Dim combo_estatus As DataColumn = New DataColumn("combo_estatus")

            reporte_estatus.DataType = System.Type.GetType("System.String")
            combo_estatus.DataType = System.Type.GetType("System.String")

            ' Add Columnns to Table.
            oDataTable.Columns.Add(reporte_estatus)
            oDataTable.Columns.Add(combo_estatus)
            ' ----------------------------------------------------------------------

            For Each valuePair As KeyValuePair(Of Integer, String) In oDictionary

                oDataRow = oDataTable.NewRow()

                oDataRow.Item("reporte_estatus") = valuePair.Key.ToString
                oDataRow.Item("combo_estatus") = valuePair.Key & " - " & valuePair.Value

                oDataTable.Rows.Add(oDataRow)

            Next

            oDataSet = New DataSet

            oDataSet.Tables.Add(oDataTable)

            oBindingSource = New BindingSource

            oBindingSource.DataSource = oDataSet.Tables("ReportStatusTable")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function


    Public Shared Function GetComboScrap(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboScrap

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboScrap")

            If Not CBool(CInt(oDataSet.Tables("GetComboScrap").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Scrap.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboScrap")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboScrapSubCauses(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboScrapSubCauses


            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboSubCauses")

            If Not CBool(CInt(oDataSet.Tables("GetComboSubCauses").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de SubCausas de Scrap.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboSubCauses")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboShifts(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboShifts

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "ComboShifts")

            If Not CBool(CInt(oDataSet.Tables("ComboShifts").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Turnos.")

            oBindingSource.DataSource = oDataSet.Tables("ComboShifts")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboShifts(ByRef oComboDummy As ComboBox) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oResponse As New SqlParameter
        Dim oSqlDataAdapter As New SqlDataAdapter

        Try

            oSqlCommand.CommandType = CommandType.StoredProcedure

            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboShifts

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetShiftsCombo")

            If CBool(CInt(oDataSet.Tables("GetShiftsCombo").Rows.Count)) Then

                With oComboDummy
                    .DataSource = oDataSet.Tables("GetShiftsCombo")
                    .DisplayMember = "combo_turnos"
                    .ValueMember = "turno_id"
                    .SelectedIndex = 0
                End With

            Else

                Throw New CustomException("No existe información de Turnos.")

            End If

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboSpecsWeight(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oDataTable As DataTable
        Dim oDataRow1, oDataRow2, oDataRow3, oDataRow4 As DataRow

        ' Create Table.
        oDataTable = New DataTable("TipoCalculo")

        ' Define Columns.
        Dim calculo_id As DataColumn = New DataColumn("calculo_id")
        Dim calculo_tipo As DataColumn = New DataColumn("calculo_tipo")

        calculo_id.DataType = System.Type.GetType("System.String")
        calculo_tipo.DataType = System.Type.GetType("System.String")


        ' Add Columnns to Table.
        oDataTable.Columns.Add(calculo_id)
        oDataTable.Columns.Add(calculo_tipo)

        ' Create Rows.
        oDataRow1 = oDataTable.NewRow
        oDataRow2 = oDataTable.NewRow
        oDataRow3 = oDataTable.NewRow
        oDataRow4 = oDataTable.NewRow

        ' Add Row Values.

        oDataRow1.Item("calculo_id") = CType(0, TipoCalculoEnum).ToString()
        oDataRow1.Item("calculo_tipo") = "0 - No Asignado"
        oDataRow2.Item("calculo_id") = CType(1, TipoCalculoEnum).ToString()
        oDataRow2.Item("calculo_tipo") = "1 - Tubo Convencional"
        oDataRow3.Item("calculo_id") = CType(2, TipoCalculoEnum).ToString()
        oDataRow3.Item("calculo_tipo") = "2 - Valor Fijo"
        oDataRow4.Item("calculo_id") = CType(3, TipoCalculoEnum).ToString()
        oDataRow4.Item("calculo_tipo") = "3 - Tubo Corrugado"

        With oDataTable.Rows
            .Add(oDataRow1)
            .Add(oDataRow2)
            .Add(oDataRow3)
            .Add(oDataRow4)
        End With

        oDataSet.Tables.Add(oDataTable)

        oBindingSource = New BindingSource

        Try

            oBindingSource.DataSource = oDataSet.Tables("TipoCalculo")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Public Shared Function GetComboStatusx(ByRef oComboDummy As ComboBox) As Boolean

        oComboDummy.Items.Clear()

        oComboDummy.Items.Add("T - Terminado")
        oComboDummy.ValueMember = "T"
        oComboDummy.DisplayMember = "T - Terminado"

        oComboDummy.Items.Add("P - En Proceso")
        oComboDummy.ValueMember = "P"
        oComboDummy.DisplayMember = "P - En Proceso"


        oComboDummy.SelectedIndex = 0

    End Function


    Public Shared Function GetComboStopSubCauses(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboStopSubCauses

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboStopSubCauses")

            'If Not CBool(CInt(oDataSet.Tables("GetComboStopSubCauses").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de SubCausas de Paro.")


            If Not CBool(CInt(oDataSet.Tables("GetComboStopSubCauses").Rows.Count)) Then MessageBox.Show("No existen valores para el combo Subcausas de Paro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

            oBindingSource.DataSource = oDataSet.Tables("GetComboStopSubCauses")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboStopCauses(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboStopCauses

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboStopCauses")

            If Not CBool(CInt(oDataSet.Tables("GetComboStopCauses").Rows.Count)) Then MessageBox.Show("No existen valores para el combo Causas de Paro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

            oBindingSource.DataSource = oDataSet.Tables("GetComboStopCauses")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboStopCausesRelation(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboStopCausesRelation

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboStopCausesRelation")

            If Not CBool(CInt(oDataSet.Tables("GetComboStopCausesRelation").Rows.Count)) Then MessageBox.Show("No existen valores para el combo Causas de Paro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

            oBindingSource.DataSource = oDataSet.Tables("GetComboStopCausesRelation")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function


    Public Shared Function GetComboTipoReporte(ByRef oComboDummy As ComboBox) As Boolean

        oComboDummy.Items.Clear()

        oComboDummy.Items.Add("PT - Producto Terminado")
        oComboDummy.ValueMember = "PT"
        oComboDummy.DisplayMember = "T - Producto Terminado"

        oComboDummy.Items.Add("PP - Producto En Proceso")
        oComboDummy.ValueMember = "PP"
        oComboDummy.DisplayMember = "PP - Producto En Proceso"

        oComboDummy.Items.Add("ENS - Ensamblado")
        oComboDummy.ValueMember = "ENS"
        oComboDummy.DisplayMember = "ENS - Ensamblado"

        oComboDummy.Items.Add("SCR - Scrap")
        oComboDummy.ValueMember = "SCR"
        oComboDummy.DisplayMember = "SCR - Scrap"

        oComboDummy.SelectedIndex = 0

    End Function

    Public Shared Function GetComboWeekDays(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oDataTable As DataTable
        Dim oDataRow1, oDataRow2, oDataRow3, oDataRow4, oDataRow5, oDataRow6, oDataRow7 As DataRow

        ' Create Table.
        oDataTable = New DataTable("WeekDay")

        ' Define Columns.
        Dim dia_id As DataColumn = New DataColumn("dia_id")
        Dim combo_dias As DataColumn = New DataColumn("combo_dias")

        dia_id.DataType = System.Type.GetType("System.String")
        combo_dias.DataType = System.Type.GetType("System.String")

        ' Add Columnns to Table.
        oDataTable.Columns.Add(dia_id)
        oDataTable.Columns.Add(combo_dias)

        ' Create Rows.
        oDataRow1 = oDataTable.NewRow
        oDataRow2 = oDataTable.NewRow
        oDataRow3 = oDataTable.NewRow
        oDataRow4 = oDataTable.NewRow
        oDataRow5 = oDataTable.NewRow
        oDataRow6 = oDataTable.NewRow
        oDataRow7 = oDataTable.NewRow

        ' Add Row Values.

        oDataRow1.Item("dia_id") = CType(WeekDays.LUN, WeekDays).ToString()
        oDataRow1.Item("combo_dias") = CType(WeekDays.LUN, WeekDays).ToString() & " - Lunes"
        oDataRow2.Item("dia_id") = CType(WeekDays.MAR, WeekDays).ToString()
        oDataRow2.Item("combo_dias") = CType(WeekDays.MAR, WeekDays).ToString() & " - Martes"
        oDataRow3.Item("dia_id") = CType(WeekDays.MIE, WeekDays).ToString()
        oDataRow3.Item("combo_dias") = CType(WeekDays.MIE, WeekDays).ToString() & " - Miércoles"
        oDataRow4.Item("dia_id") = CType(WeekDays.JUE, WeekDays).ToString()
        oDataRow4.Item("combo_dias") = CType(WeekDays.JUE, WeekDays).ToString() & " - Jueves"
        oDataRow5.Item("dia_id") = CType(WeekDays.VIE, WeekDays).ToString()
        oDataRow5.Item("combo_dias") = CType(WeekDays.VIE, WeekDays).ToString() & " - Viernes"
        oDataRow6.Item("dia_id") = CType(WeekDays.SAB, WeekDays).ToString()
        oDataRow6.Item("combo_dias") = CType(WeekDays.SAB, WeekDays).ToString() & " - Sábado"
        oDataRow7.Item("dia_id") = CType(WeekDays.DOM, WeekDays).ToString()
        oDataRow7.Item("combo_dias") = CType(WeekDays.DOM, WeekDays).ToString() & " - Domingo"

        With oDataTable.Rows
            .Add(oDataRow1)
            .Add(oDataRow2)
            .Add(oDataRow3)
            .Add(oDataRow4)
            .Add(oDataRow5)
            .Add(oDataRow6)
            .Add(oDataRow7)
        End With

        oDataSet.Tables.Add(oDataTable)

        oBindingSource = New BindingSource

        Try

            oBindingSource.DataSource = oDataSet.Tables("WeekDay")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function


    Public Shared Function GetComboWorkCenter(ByRef oComboDummy As ComboBox) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oResponse As New SqlParameter
        Dim oSqlDataAdapter As New SqlDataAdapter

        Try

            oSqlCommand.CommandType = CommandType.StoredProcedure

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboWorkCenter

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboWorkCenter")

            If Not CBool(CInt(oDataSet.Tables("GetComboWorkCenter").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla Centro de Trabajo.")

            With oComboDummy
                .DataSource = oDataSet.Tables("GetComboWorkCenter")
                .DisplayMember = "combo_centros"
                .ValueMember = "id"
                .SelectedIndex = 0
            End With

            GetComboWorkCenter = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

        Return GetComboWorkCenter

    End Function

    Public Shared Function GetComboWorkCenter(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboWorkCenter

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetComboWorkCenter")

            If Not CBool(CInt(oDataSet.Tables("GetComboWorkCenter").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla Centro de Trabajo.")

            oBindingSource.DataSource = oDataSet.Tables("GetComboWorkCenter")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function GetComboWorkOrders(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter


        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboWorkOrders

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "GetOrdersCombo")

            If Not CBool(CInt(oDataSet.Tables("GetOrdersCombo").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Ordenes de Trabajo.")

            oBindingSource.DataSource = oDataSet.Tables("GetOrdersCombo")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function


    Public Shared Function GetComboWorkOrderStatus(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oDataTable As DataTable
        Dim oDataRow1, oDataRow2, oDataRow3, oDataRow4 As DataRow

        ' Create Table.
        oDataTable = New DataTable("OrdenEstatus")

        ' Define Columns.
        Dim orden_estatus As DataColumn = New DataColumn("orden_status_atlas")
        Dim combo_estatus As DataColumn = New DataColumn("combo_estatus")

        orden_estatus.DataType = System.Type.GetType("System.String")
        combo_estatus.DataType = System.Type.GetType("System.String")

        ' Add Columnns to Table.
        oDataTable.Columns.Add(orden_estatus)
        oDataTable.Columns.Add(combo_estatus)

        ' Create Rows.
        oDataRow1 = oDataTable.NewRow
        oDataRow2 = oDataTable.NewRow
        oDataRow3 = oDataTable.NewRow
        oDataRow4 = oDataTable.NewRow


        ' Add Row Values.

        oDataRow1.Item("orden_status_atlas") = Char.Parse(ProductionOrderStatus.Process)
        oDataRow1.Item("combo_estatus") = "0 - Orden en Proceso"
        oDataRow2.Item("orden_status_atlas") = Char.Parse(ProductionOrderStatus.Closed)
        oDataRow2.Item("combo_estatus") = "1 - Orden Cerrada"
        oDataRow3.Item("orden_status_atlas") = Char.Parse(ProductionOrderStatus.Cancelled)
        oDataRow3.Item("combo_estatus") = "2 - Orden Cancelada"
        '     oDataRow4.Item("orden_status_atlas") = Char.Parse(ProductionOrderStatus.Cancelled)
        '   oDataRow4.Item("combo_estatus") = "3 - Orden Abierta"

        With oDataTable.Rows
            .Add(oDataRow1)
            .Add(oDataRow2)
            .Add(oDataRow3)
            .Add(oDataRow4)
        End With

        oDataSet.Tables.Add(oDataTable)

        oBindingSource = New BindingSource

        Try

            oBindingSource.DataSource = oDataSet.Tables("OrdenEstatus")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Public Shared Function GetCurrentDateTime() As DateTime

        Dim oDateTime As DateTime = DateTime.Now

        Return oDateTime

    End Function

    Public Shared Function GetFormatPattern(ByVal value As Integer) As String

        Select Case value
            Case FormatPattern.NumericDouble
                GetFormatPattern = "#####0.000"
            Case Else
                GetFormatPattern = String.Empty
        End Select

        Return GetFormatPattern
    End Function


    Public Shared Function GetShifts(ByRef oBindingSource As BindingSource) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oSqlDataAdapter As New SqlDataAdapter
        Dim oResponse As New SqlParameter

        oSqlCommand.CommandType = CommandType.StoredProcedure

        oBindingSource = New BindingSource

        Try
            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id
            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboShifts

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "ComboShifts")

            If Not CBool(CInt(oDataSet.Tables("ComboShifts").Rows.Count)) Then Throw New CustomException("No existen valores en la tabla de Turnos.")

            oBindingSource.DataSource = oDataSet.Tables("ComboShifts")

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

    End Function

    Public Shared Function IsGreaterThanZero(ByVal oObject As Object) As Boolean

        Dim oRequiredText As String = String.Empty

        Try

            If TypeOf oObject Is TextBox Then

                oRequiredText = DirectCast(oObject, TextBox).Text.Trim

            ElseIf TypeOf oObject Is ComboBox Then

                oRequiredText = DirectCast(oObject, ComboBox).SelectedValue

            ElseIf TypeOf oObject Is DateTimePicker Then

                oRequiredText = DirectCast(oObject, DateTimePicker).Text

            End If

            If Not (Double.Parse(oRequiredText) > 0) Then oObject.Focus() : Throw New LocalExceptions.ZeroFieldException(oObject.Tag)

            Return True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Public Shared Function IsNumericField(ByVal oObject As Object) As Boolean

        Dim oRequiredText As String = String.Empty

        Try

            If TypeOf oObject Is TextBox Then

                oRequiredText = DirectCast(oObject, TextBox).Text.Trim

            ElseIf TypeOf oObject Is ComboBox Then

                oRequiredText = DirectCast(oObject, ComboBox).SelectedValue

            ElseIf TypeOf oObject Is DateTimePicker Then

                oRequiredText = DirectCast(oObject, DateTimePicker).Text

            End If

            If Not IsNumeric(oRequiredText) Then oObject.Focus() : Throw New LocalExceptions.NumericFieldException(oObject.Tag)

            oRequiredText = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return oRequiredText

    End Function

    Public Shared Sub ClearControlBinding(ByVal oControl As Control)

        Try

            For Each oCtrl As Control In oControl.Controls

                If TypeOf oCtrl Is TextBox Then

                    CType(oCtrl, TextBox).DataBindings.Clear()

                ElseIf TypeOf oCtrl Is ComboBox Then

                    CType(oCtrl, ComboBox).DataBindings.Clear()

                ElseIf TypeOf oCtrl Is DateTimePicker Then

                    CType(oCtrl, DateTimePicker).DataBindings.Clear()

                    ' TODO DATETIME
                    CType(oCtrl, DateTimePicker).Format = DateTimePickerFormat.Custom
                    CType(oCtrl, DateTimePicker).CustomFormat = " "


                ElseIf TypeOf oCtrl Is CheckBox Then

                    CType(oCtrl, CheckBox).DataBindings.Clear()

                ElseIf TypeOf oCtrl Is BindingNavigator Then

                    CType(oCtrl, BindingNavigator).DataBindings.Clear()

                ElseIf TypeOf oCtrl Is DataGridView Then

                    CType(oCtrl, DataGridView).DataSource = Nothing
                    CType(oCtrl, DataGridView).Rows.Clear()
                    '   CType(oCtrl, DataGridView).Columns.Clear()
                Else

                    If oCtrl.Controls.Count > 0 Then

                        ClearControlBinding(oCtrl)

                    End If

                End If

            Next oCtrl


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Shared Sub ClearControls(ByVal Page As Control)


        Try
            For Each oCtrl As Control In Page.Controls

                If TypeOf oCtrl Is TextBox Then

                    CType(oCtrl, TextBox).Clear()

                ElseIf TypeOf oCtrl Is ComboBox Then

                    CType(oCtrl, ComboBox).SelectedIndex = -1

                ElseIf TypeOf oCtrl Is Label And oCtrl.Name.Equals("lbFolioAtlas") Then

                    CType(oCtrl, Label).Text = String.Empty

                ElseIf TypeOf oCtrl Is ToolStrip Then

                    For Each itm As ToolStripItem In DirectCast(oCtrl, ToolStrip).Items

                        If itm.Name.Equals("lbFolioSap") Or itm.Name.Equals("lbConsecutivoSap") Then
                            itm.Text = String.Empty
                        End If
                    Next

                ElseIf TypeOf oCtrl Is CheckBox Then

                    CType(oCtrl, CheckBox).CheckState = CheckState.Unchecked

                ElseIf TypeOf oCtrl Is DataGridView Then
                    'CType(oCtrl, DataGridView).clea()
                    CType(oCtrl, DataGridView).DataSource = Nothing

                ElseIf TypeOf oCtrl Is PictureBox Then

                    CType(oCtrl, PictureBox).Image = New Bitmap(Global.IDPProjectManagement.My.Resources.NoImage)

                Else

                    If oCtrl.Controls.Count > 0 Then
                        If oCtrl.Name.Equals("TSDownDirectAcces") Then

                            Dim a As String

                            a = "b"
                        End If
                        ClearControls(oCtrl)

                    End If

                End If

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try

    End Sub

    Public Shared Sub ClearControlsOnAddState(ByVal Page As Control)

        For Each oCtrl As Control In Page.Controls

            If TypeOf oCtrl Is TextBox Then

                CType(oCtrl, TextBox).Clear()


            ElseIf TypeOf oCtrl Is Label And oCtrl.Name.Equals("lbFolioAtlas") Then

                CType(oCtrl, Label).Text = String.Empty


            ElseIf TypeOf oCtrl Is CheckBox Then

                CType(oCtrl, CheckBox).CheckState = CheckState.Unchecked

                'ElseIf TypeOf oCtrl Is DataGridView Then

                '   CType(oCtrl, DataGridView).DataSource = Nothing
                ' CType(oCtrl, DataGridView).Update()
                '  CType(oCtrl, DataGridView).Refresh()

            ElseIf TypeOf oCtrl Is PictureBox Then

                CType(oCtrl, PictureBox).Image = New Bitmap(Global.IDPProjectManagement.My.Resources.NoImage)

            Else

                If oCtrl.Controls.Count > 0 Then

                    ClearControls(oCtrl)

                End If

            End If

        Next

    End Sub

    Public Shared Sub EnableCell(ByVal dc As DataGridViewCell, ByVal enabled As Boolean)

        dc.ReadOnly = Not enabled

        If (enabled) Then
            ' dc.Style.BackColor = dc.OwningColumn.DefaultCellStyle.BackColor
            dc.Style.ForeColor = Color.Black 'dc.OwningColumn.DefaultCellStyle.ForeColor
        Else
            '  dc.DefaultCellStyle.BackColor = Color.LightGray
            '  dc.Style.ForeColor = Color.DarkGray
        End If

    End Sub

    Public Shared Sub EnableColumn(ByVal dc As DataGridViewColumn, ByVal enabled As Boolean)

        dc.ReadOnly = Not enabled

        If (enabled) Then
            dc.DefaultCellStyle.BackColor = dc.DefaultCellStyle.BackColor
            dc.DefaultCellStyle.ForeColor = dc.DefaultCellStyle.ForeColor
        Else
            'dc.DefaultCellStyle.BackColor = Color.LightGray
            dc.DefaultCellStyle.ForeColor = Color.DarkGray
        End If

    End Sub

    Public Shared Sub EnableControls(ByVal oControl As Control, ByVal value As Boolean)

        Try
            For Each oCtrl As Control In oControl.Controls

                If TypeOf oCtrl Is TextBox Then

                    CType(oCtrl, TextBox).Enabled = value

                ElseIf TypeOf oCtrl Is ComboBox Then

                    CType(oCtrl, ComboBox).Enabled = value

                ElseIf TypeOf oCtrl Is LinkLabel Then

                    CType(oCtrl, LinkLabel).Enabled = value

                    '               ElseIf TypeOf oCtrl Is ToolStrip Then

                    '                    For Each itm As ToolStripItem In DirectCast(oCtrl, ToolStrip).Items

                    ' If itm.Name.Equals("lbFolioSap") Or itm.Name.Equals("lbConsecutivoSap") Then
                    '                  itm.Enabled = value
                    ' End If
                    '                 Next

                ElseIf TypeOf oCtrl Is DateTimePicker Then

                    CType(oCtrl, DateTimePicker).Enabled = value

                ElseIf TypeOf oCtrl Is DataGridView Then

                Else

                    If oCtrl.Controls.Count > 0 Then

                        EnableControls(oCtrl, value)

                    End If

                End If

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try

    End Sub

    Public Shared Sub GetSapConnectionStatus()

        Dim oDataSet As DataSet
        Dim oSqlCommand As SqlCommand
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        Try

            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetSapConnection

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            oSqlCommand.ExecuteNonQuery()

            If CInt(oResponse.Value) Then

                save_to_sap = True
            Else

                save_to_sap = False

                MessageBox.Show("No está definida la conexión a SAP.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Shared Sub HandleDecimalNumbers(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Or (e.KeyChar = "." And sender.Text.IndexOf(".") < 0) Then

            Else

                MessageBox.Show("Capture solo números en formato entero o decimal. Ejemplo: 10, 232.12", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Handled = True
            End If
        End If

    End Sub

    Public Shared Sub HandleGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        With sender

            .BackColor = Color.LightGoldenrodYellow

        End With
    End Sub

    Public Shared Sub HandleGotFocusDirectAccess(ByVal sender As Object, ByVal value As Object)

        With sender

            .BackColor = Color.LightGoldenrodYellow
            value.Enabled = True

        End With

    End Sub


    Public Shared Sub HandleLostFocusDirectAccess(ByVal sender As Object, ByVal value As Object)

        With sender

            .BackColor = Color.White
            value.Enabled = False

        End With

    End Sub

    Public Shared Sub HandleHighlight(ByVal sender As Object, ByVal e As System.EventArgs)

        With sender


            If Not String.IsNullOrEmpty(.Text) Then .Select(.Text.Length, 0)

            '.SelectionStart = 0
            '.SelectionLength = .Text.Length

        End With
    End Sub

    
    Public Shared Sub HandleIntegerNumbers(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then

            Else

                MessageBox.Show("Capture solo números en formato entero. Ejemplo: 10, 35,  822", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Handled = True
            End If
        End If

    End Sub

    Public Shared Sub HandleLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        With sender

            .BackColor = Color.White

        End With
    End Sub

    Public Shared Sub HandleNotSpaces(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar <> ChrW(Keys.Back) Then
            If Asc(e.KeyChar) = Keys.Space Then

                MessageBox.Show("No se permiten espacios en los campos clave.", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Handled = True
            End If
        End If

    End Sub

    Public Shared Sub HandleValidCharacters(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)



        'If e.KeyChar <> ChrW(Keys.Back) Then

        ' '||, -, *, /, <>, <, >, ,(comma), =, <=, >=, ~=, !=, ^=, (, )
        If Asc(e.KeyChar) = 37 Then

            MessageBox.Show("No se permiten espacios en los campos clave.", "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Handled = True
        End If
        '  End If

    End Sub

    Public Shared Sub HandleOnlyUpperCase(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

       e.KeyChar = ChrW(Asc(UCase(e.KeyChar)))

    End Sub
    Public Shared Sub RestoreBackColor(ByVal oControl As Control)

        Try
            For Each oCtrl As Control In oControl.Controls

                If TypeOf oCtrl Is TextBox Then

                    CType(oCtrl, TextBox).BackColor = Color.White

                ElseIf TypeOf oCtrl Is ComboBox Then

                    CType(oCtrl, ComboBox).BackColor = Color.White

                ElseIf TypeOf oCtrl Is LinkLabel Then

                    CType(oCtrl, LinkLabel).BackColor = Color.White

                ElseIf TypeOf oCtrl Is DateTimePicker Then

                    CType(oCtrl, DateTimePicker).BackColor = Color.White

                Else

                    If oCtrl.Controls.Count > 0 Then

                        RestoreBackColor(oCtrl)

                    End If

                End If

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try

    End Sub

    Public Shared Sub SetCultureSettings()

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

    End Sub

    Public Shared Sub SetFormFormat(ByVal oForm As Object)


        If String.Compare(DirectCast(oForm, Form).Name, "FLoginForm") < 0 Then

            With oForm
                '.ControlBox = False
                '.MaximizeBox = False
                '.MinimizeBox = False
                ''   Me.ShowIcon = False
                ''    Me.Text = ""
                '.Dock = DockStyle.Fill
                '.FormBorderStyle = FormBorderStyle.FixedToolWindow
                '.WindowState = FormWindowState.Maximized


                .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                .MaximizeBox = False
                .MinimizeBox = False
                .Size = New Size(1000, 316)
                .Icon = GetApplicationIcon()

            End With

            With oForm
                For i = 0 To .TableLayoutPanel1.RowStyles.Count

                    Select Case i
                        Case 0

                            .TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                            .TableLayoutPanel1.RowStyles.Item(i).Height = 20

                        Case 1

                            .TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                            .TableLayoutPanel1.RowStyles.Item(i).Height = 70

                        Case 2
                            .TableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Percent
                            .TableLayoutPanel1.RowStyles.Item(i).Height = 5

                    End Select

                Next
            End With

        Else
            '-----------------------------
            ' Formatting LogIn Form
            ' ----------------------------
            With DirectCast(oForm, FLoginForm)
                '.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
                .MaximizeBox = False
                .MinimizeBox = False
                .Size = New Size(600, 450)
                .Icon = GetApplicationIcon()
                .WindowState = FormWindowState.Normal
                .Dock = DockStyle.None
                .StartPosition = Windows.Forms.FormStartPosition.CenterScreen

            End With

        End If

        Dim xc As Form
        xc = oForm

        Dim gr As DataGridView

        gr = xc.Controls.Item("DataGridView")



    End Sub

    Public Shared Sub SetFormDisplayFormat(ByVal oForm As Object)


        Select Case oForm.DisplayMode

            Case FormProcessType.Catalog

                With oForm
                    .ControlBox = False
                    .MaximizeBox = False
                    .MinimizeBox = False
                    .ShowIcon = False
                    '.Text = "" THIS FUCKED UP THE FORM BECASUE IT'S USED BEFORE THE FORM IS SHOWED, DON'T USE IT
                    .Dock = DockStyle.Fill
                    .FormBorderStyle = FormBorderStyle.None
                    .WindowState = FormWindowState.Maximized


                End With

                Dim oTableLayoutPanel As TableLayoutPanel = DirectCast(oForm, Form).Controls("TableLayoutPanel1")

                With oTableLayoutPanel

                    For i = 0 To .RowStyles.Count

                        Select Case i
                            Case 0

                                .RowStyles.Item(i).SizeType = SizeType.Percent
                                .RowStyles.Item(i).Height = 30

                            Case 1

                                .RowStyles.Item(i).SizeType = SizeType.Percent
                                .RowStyles.Item(i).Height = 70

                            Case 2
                                .RowStyles.Item(i).SizeType = SizeType.Percent
                                .RowStyles.Item(i).Height = 5

                        End Select

                    Next

                End With

            Case FormProcessType.Parent

                'With oForm

                '    '.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                '    .MaximizeBox = False
                '    .MinimizeBox = False
                '    .Size = New Size(1300, 400)
                '    '.Icon = GetApplicationIcon()

                '    .ControlBox = False
                '    .ShowIcon = False
                '    '    Me.Text = ""

                '    .FormBorderStyle = FormBorderStyle.FixedToolWindow


                'End With


                With oForm
                    .ControlBox = False
                    .MaximizeBox = False
                    .MinimizeBox = False
                    .ShowIcon = False
                    '.Dock = DockStyle.Fill
                    .FormBorderStyle = FormBorderStyle.None
                    '.WindowState = FormWindowState.Maximized
                    .Size = New Size(1300, 400)

                End With


                Dim oTableLayoutPanel As TableLayoutPanel = DirectCast(oForm, Form).Controls("TableLayoutPanel1")

                With oTableLayoutPanel

                    For i = 0 To .RowStyles.Count

                        Select Case i
                            Case 0

                                .RowStyles.Item(i).SizeType = SizeType.Percent
                                .RowStyles.Item(i).Height = 30

                            Case 1

                                .RowStyles.Item(i).SizeType = SizeType.Percent
                                .RowStyles.Item(i).Height = 60

                            Case 2
                                .RowStyles.Item(i).SizeType = SizeType.Percent
                                .RowStyles.Item(i).Height = 10

                        End Select

                    Next
                End With


        End Select

        'If String.Compare(DirectCast(oForm, Form).Name, "FLoginForm") > 0 Then



        'Else
        '    '-----------------------------
        '    ' Formatting LogIn Form
        '    ' ----------------------------
        '    With DirectCast(oForm, FLoginForm)
        '        '.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        '        .MaximizeBox = False
        '        .MinimizeBox = False
        '        .Size = New Size(600, 450)
        '        .Icon = GetApplicationIcon()
        '        .WindowState = FormWindowState.Normal
        '        .Dock = DockStyle.None
        '        .StartPosition = Windows.Forms.FormStartPosition.CenterScreen

        '    End With

        'End If

        'Dim xc As Form
        'xc = oForm

        'Dim gr As DataGridView

        'gr = xc.Controls.Item("DataGridView")



    End Sub

    Public Shared Sub SetSapConnectionStatus(ByVal value As ToolStripLabel)

        Dim oResourceManager As New ResourceManager("IDPProjectManagement.Resources", Assembly.GetExecutingAssembly())

        If CApplication.save_to_sap Then value.ToolTipText = "Comunicación con Sap Habilitada" Else value.ToolTipText = "Comunicación con Sap No Habilitada"

        If CApplication.save_to_sap Then value.ForeColor = Color.Green Else value.ForeColor = Color.Red

        If CApplication.save_to_sap Then value.Image = oResourceManager.GetObject("rss") Else value.Image = oResourceManager.GetObject("rss_remove")


    End Sub

    Public Shared Sub SetTextBoxDefaultColor(ByVal Page As Control)

        For Each ctrl As Control In Page.Controls

            If TypeOf ctrl Is TextBox Then

                CType(ctrl, TextBox).ForeColor = Color.Black
                CType(ctrl, TextBox).BackColor = Color.White

            Else

                If ctrl.Controls.Count > 0 Then SetTextBoxDefaultColor(ctrl)

            End If

        Next

    End Sub

    Public Shared Property app_config_xml_file() As String
        Get
            Return p_app_config_xml_file
        End Get
        Set(ByVal value As String)
            p_app_config_xml_file = value

        End Set
    End Property
    Public Shared Property app_environment() As String
        Get
            Return p_app_environment

        End Get

        Set(ByVal value As String)

            p_app_environment = value

        End Set
    End Property

    Public Shared Property NotAssignedValue() As String
        Get
            Return p_NotAssignedValue
        End Get
        Set(ByVal value As String)
            p_NotAssignedValue = value

        End Set
    End Property

    Public Shared Property save_to_sap() As Boolean
        Get
            Return p_save_to_sap
        End Get
        Set(ByVal value As Boolean)
            p_save_to_sap = value
        End Set
    End Property

    Public Shared Property user_password() As String
        Get
            Return p_user_password

        End Get

        Set(ByVal value As String)

            p_user_password = value
        End Set
    End Property

    Public Shared Property usuario_id() As String
        Get
            Return _usuario_id
        End Get
        Set(ByVal value As String)
            _usuario_id = value
        End Set
    End Property


    Public Shared Function FillComboWithData(ByRef oComboDummy As ComboBox) As Boolean

        Dim oDataSet As New DataSet
        Dim oSqlCommand As New SqlCommand("dbo.ASP_PROCESS_APPLICATION")
        Dim oResponse As New SqlParameter
        Dim oSqlDataAdapter As New SqlDataAdapter

        Try

            oSqlCommand.CommandType = CommandType.StoredProcedure

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.GetComboWorkCenter

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection

            If oSqlCommand.Connection Is Nothing Then Return False : Exit Function

            oSqlDataAdapter = New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "ComboData")

            If Not CBool(CInt(oDataSet.Tables("ComboData").Rows.Count)) Then Throw New CustomException("No hay información para el combo.")

            With oComboDummy
                .DataSource = oDataSet.Tables("ComboData")
                .DisplayMember = "combo_data"
                .ValueMember = "id"
                .SelectedIndex = 0
            End With

            FillComboWithData = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

            If Not oSqlDataAdapter Is Nothing Then oSqlDataAdapter.Dispose()

        End Try

        Return FillComboWithData

    End Function
End Class
