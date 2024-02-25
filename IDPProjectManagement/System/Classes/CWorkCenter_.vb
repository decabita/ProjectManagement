Imports System.Data.SqlClient

Public Class CWorkCenter_

    'Enum SPCommand

    '    QueryById = 6

    'End Enum

    Enum SPCommand
        None = 0
        QueryAll = 1
        Add = 2
        Update = 3
        Save = 4
        Delete = 5
        QueryById = 6
        CheckIfPartExists = 7
        QueryFilter = 8
        GetRelatedSpecs = 30
    End Enum

    Shared _oCurrentForm As New Form
    Shared Property CurrentForm() As Form
        Get
            Return _oCurrentForm
        End Get
        Set(ByVal value As Form)
            _oCurrentForm = value
        End Set
    End Property

    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _guid As String
    Public Property guid() As String
        Get
            Return _guid
        End Get
        Set(ByVal value As String)
            _guid = value
        End Set
    End Property

    Private _nombre_corto As String
    Public Property nombre_corto() As String
        Get
            Return _nombre_corto
        End Get
        Set(ByVal value As String)
            _nombre_corto = value
        End Set
    End Property


    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _descripcion As String
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _is_active As Boolean
    Public Property is_active() As Boolean
        Get
            Return _is_active
        End Get
        Set(ByVal value As Boolean)
            _is_active = value
        End Set
    End Property

    Private _planta_id As String

    Public Sub New()
        With Me
            .id = -1
            .guid = String.Empty
            .nombre = String.Empty
            .nombre_corto = String.Empty
            .descripcion = String.Empty
            .is_active = False
        End With
    End Sub

    Public Property planta_id() As String
        Get
            Return _planta_id
        End Get
        Set(ByVal value As String)
            _planta_id = value
        End Set
    End Property

    Friend Function IsValidWorkCenterData() As Boolean

        Dim CWorkCenter_ = GetWorkCenterClass()

        Return (CWorkCenter_.guid.Length > 0)

    End Function

    Friend Function GetWorkCenterClass() As CWorkCenter_

        Dim oDataSet As DataSet
        Dim oSqlCommand As SqlCommand
        Dim oResponse As New SqlParameter

        oDataSet = New DataSet
        oSqlCommand = New SqlCommand("dbo.ASP_PROCESS_WORK_CENTER")
        oSqlCommand.CommandType = CommandType.StoredProcedure

        Try

            oSqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = CApplicationController.oCWorkCenter_.id

            oSqlCommand.Parameters.Add("@command", SqlDbType.Int).Value = SPCommand.QueryById

            oResponse = oSqlCommand.Parameters.Add("@response", SqlDbType.Int)
            oResponse.Direction = ParameterDirection.Output

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()

            Dim oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

            oSqlDataAdapter.Fill(oDataSet, "CTL_CentrosTrabajo")

            If Not CBool(CInt(oDataSet.Tables("CTL_CentrosTrabajo").Rows.Count)) Then Throw New CustomException("No hay información en la tabla Centros de Trabajo.")

            With oDataSet.Tables("CTL_CentrosTrabajo").Rows(0)
                Me.guid = .Item("guid")
                Me.id = .Item("id")
                Me.nombre_corto = .Item("nombre_corto").ToString.Trim
                Me.nombre = .Item("nombre").ToString.Trim
                Me.descripcion = .Item("descripcion").ToString.Trim
                Me.is_active = .Item("is_active")
            End With

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try

        Return Me

    End Function

    Public Shared Function FillWorkCenterCombo() As Boolean

        Dim oDataSet As DataSet
        Dim oSqlCommand As SqlCommand

        oDataSet = New DataSet
        oSqlCommand = New SqlCommand("dbo.[SP_GET_WORK_CENTER_COMBO]")
        oSqlCommand.CommandType = CommandType.StoredProcedure
        ' oSqlCommand.Parameters.Add("@planta_id", SqlDbType.NVarChar).Value = strPlanta.Trim


        Try

            oSqlCommand.Connection = CApplicationController.oCDataBase.GetSQLConnection()
            Dim oSqlDataAdapter As New SqlDataAdapter(oSqlCommand)

            If oSqlCommand.Connection Is Nothing Then Exit Function

            oSqlDataAdapter.Fill(oDataSet, "WorkCenter")

            If Not CBool(CInt(oDataSet.Tables("WorkCenter").Rows.Count)) Then
                MsgBox("No existe información para el valor seleccionado.", MsgBoxStyle.Information, "Atención")
                Exit Function
            End If

            '  Me.DataSource = oDataSet.Tables("WorkCenter")
            '  Me.DisplayMember = "Centro"
            '  Me.ValueMember = "CentroId"

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Function

    Public Shared Function SetControlsBinding(ByVal oForm As FCentrosTrabajo) As Boolean

        Try

            With oForm
                ' ----------------
                ' TEXTBOX BINDING.
                ' ----------------

                .tGuid.DataBindings.Add("text", .oBindingSource, "guid", True)

                .tClaveId.DataBindings.Add("text", .oBindingSource, "nombre_corto", True)

                .tNombre.DataBindings.Add("text", .oBindingSource, "nombre", True)


                .tDescripcion.DataBindings.Add("text", .oBindingSource, "descripcion", True).NullValue = CApplication.NotAssignedValue

                ' ------------------------
                ' CHECK BOX BINDING. 
                ' ------------------------
                .ckActivo.DataBindings.Add("CheckState", .oBindingSource, "is_active", True)

                ' -------------------------------------------------------------
                ' PICTURE BOX BINDING. 
                ' -------------------------------------------------------------

                ' -------------------
                ' COMBO BINDING.
                ' -------------------

                ' --------------------------------------
                ' Get combo data for each Combobox in Form.
                ' --------------------------------------

                ' 1. Fill Combo Binding Source and Add Combo Binding Source to Collection.

                ' 2. Add combo to Form in Simple View.

                ' 3. Add combo to Grid in Multi View.

                ' -------------------------------------------------------------
                ' DATAGRIDVIEW BINDING.
                ' -------------------------------------------------------------
                .DataGridView.DataSource = .oBindingSource

                ' -------------------------------------------------------------
                ' NAVIGATOR BINDING.
                ' -------------------------------------------------------------
                .BindingNavigator.BindingSource = .oBindingSource

                ' -------------------------------------------------------------
                ' Reset Binding.
                ' -------------------------------------------------------------
                .oBindingSource.ResetBindings(False)

            End With

            SetControlsBinding = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return SetControlsBinding

    End Function
    Public Shared Function SetControlsBindingOnNew(ByVal oForm As FCentrosTrabajo) As Boolean

        Try

            With oForm

                ' ----------------------
                ' TEXTBOX BINDING.
                ' ----------------------


                ' ----------------------
                ' CHECK BOX BINDING. 
                ' ----------------------

                ' -------------------------------------------------------------
                ' PICTURE BOX BINDING. 
                ' -------------------------------------------------------------

                ' -------------------------------------------------------------
                ' COMBO BINDING.
                ' -------------------------------------------------------------
                ' -------------------------------------------------------------
                ' Get combo data for each Combobox in Form.
                ' -------------------------------------------------------------

                ' 1. Fill Combo Binding Source and Add Combo Binding Source to Collection.

                ' 2. Add combo to Form in Simple View.

                ' 3. Add combo to Grid in Multi View.

                ' -------------------------
                ' DATAGRIDVIEW BINDING.
                ' -------------------------


                ' -------------------------
                ' NAVIGATOR BINDING.
                ' -------------------------

                ' -------------------------
                ' Reset Binding.
                ' -------------------------

            End With

            SetControlsBindingOnNew = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return SetControlsBindingOnNew

    End Function

End Class
