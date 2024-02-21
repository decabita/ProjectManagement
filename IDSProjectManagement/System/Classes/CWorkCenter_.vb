Imports System.Data.SqlClient

Public Class CWorkCenter_

    Enum SPCommand

        QueryById = 6
   
    End Enum


    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _centro_alias As String
    Public Property centro_alias() As String
        Get
            Return _centro_alias
        End Get
        Set(ByVal value As String)
            _centro_alias = value
        End Set
    End Property


    Private _centro_nombre As String
    Public Property centro_nombre() As String
        Get
            Return _centro_nombre
        End Get
        Set(ByVal value As String)
            _centro_nombre = value
        End Set
    End Property

    Private _centro_descripcion As String
    Public Property centro_descripcion() As String
        Get
            Return _centro_descripcion
        End Get
        Set(ByVal value As String)
            _centro_descripcion = value
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
    Public Property planta_id() As String
        Get
            Return _planta_id
        End Get
        Set(ByVal value As String)
            _planta_id = value
        End Set
    End Property

    Friend Function GetWorkCenterData() As Boolean

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
                Me.id = .Item("id")
                Me.centro_alias = .Item("centro_alias").ToString.Trim
                Me.centro_nombre = .Item("centro_nombre").ToString.Trim
                Me.centro_descripcion = .Item("centro_descripcion").ToString.Trim

            End With

            GetWorkCenterData = True

        Catch ex As CustomException

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            If Not oDataSet Is Nothing Then oDataSet.Dispose()

            If Not oSqlCommand.Connection Is Nothing Then oSqlCommand.Connection.Close() : oSqlCommand.Dispose()

        End Try

        Return GetWorkCenterData

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
End Class
