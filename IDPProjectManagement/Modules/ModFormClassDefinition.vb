Module ModFormClassDefinition


    Public Class GridBasicDTOClass

        Private _id As Integer
        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Private Property _guid As String
        Public Property guid() As String
            Get
                Return _guid
            End Get
            Set(ByVal value As String)
                _guid = value
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

    End Class

    Public Class GridColumnsClass

        Private Property _columnName As String
        Public Property ColumnName() As String
            Get
                Return _columnName
            End Get
            Set(ByVal value As String)
                _columnName = value
            End Set
        End Property

        Private _visible As Boolean = False
        Public Property Visible() As Boolean
            Get
                Return _visible
            End Get
            Set(ByVal value As Boolean)
                _visible = value
            End Set
        End Property

        Private _headerText As String
        Public Property HeaderText() As String
            Get
                Return _headerText
            End Get
            Set(ByVal value As String)
                _headerText = value
            End Set
        End Property

        Private _displayIndex As Integer = 0
        Public Property DisplayIndex() As Integer
            Get
                Return _displayIndex
            End Get
            Set(ByVal value As Integer)
                _displayIndex = value
            End Set
        End Property

    End Class

    Public Class FormsControlsHelperClass

        Public Shared Function GetGridColumnBasicDetails() As List(Of GridColumnsClass)

            Dim index As Integer = 0
            Dim lGridColumnsClass As New List(Of GridColumnsClass)

            Dim oGridColumnsClass As New GridColumnsClass
            oGridColumnsClass.ColumnName = "id"
            oGridColumnsClass.Visible = False
            oGridColumnsClass.DisplayIndex = index
            lGridColumnsClass.Add(oGridColumnsClass)

            index += 1
            oGridColumnsClass = New GridColumnsClass()
            oGridColumnsClass.ColumnName = "centro_id"
            oGridColumnsClass.Visible = False
            oGridColumnsClass.DisplayIndex = index
            lGridColumnsClass.Add(oGridColumnsClass)

            index += 1
            oGridColumnsClass = New GridColumnsClass()
            oGridColumnsClass.ColumnName = "guid"
            oGridColumnsClass.HeaderText = "Guid"
            oGridColumnsClass.Visible = True
            oGridColumnsClass.DisplayIndex = index
            lGridColumnsClass.Add(oGridColumnsClass)

            index += 1
            oGridColumnsClass = New GridColumnsClass()
            oGridColumnsClass.ColumnName = "nombre_corto"
            oGridColumnsClass.HeaderText = "Clave"
            oGridColumnsClass.Visible = True
            oGridColumnsClass.DisplayIndex = index
            lGridColumnsClass.Add(oGridColumnsClass)

            index += 1
            oGridColumnsClass = New GridColumnsClass()
            oGridColumnsClass.ColumnName = "nombre"
            oGridColumnsClass.HeaderText = "Nombre"
            oGridColumnsClass.Visible = True
            oGridColumnsClass.DisplayIndex = index
            lGridColumnsClass.Add(oGridColumnsClass)

            index += 1
            oGridColumnsClass = New GridColumnsClass()
            oGridColumnsClass.ColumnName = "descripcion"
            oGridColumnsClass.HeaderText = "Descripción"
            oGridColumnsClass.Visible = True
            oGridColumnsClass.DisplayIndex = index
            lGridColumnsClass.Add(oGridColumnsClass)

            Return lGridColumnsClass

        End Function
        Public Shared Function GetGridColumnDetails(ByVal sourceName As String) As List(Of GridColumnsClass)

            Dim index As Integer = 0
            Dim dictionary As New Dictionary(Of String, String)
            Dim lGridColumnsClass As New List(Of GridColumnsClass)
            Dim oGridColumnsClass = New GridColumnsClass()

            Select Case sourceName

                'Case "FParts"

                '    dictionary.Add("centro_id", "centro_id")
                '    dictionary.Add("tClaveId", "nombre_corto")
                '    dictionary.Add("tNombre", "nombre")
                '    dictionary.Add("tDescripcion", "descripcion")
                '    dictionary.Add("ckActivo", "is_active")


                Case "FParts"


                    lGridColumnsClass = GetGridColumnBasicDetails()

                    For Each cls In lGridColumnsClass

                        index += If(cls.Visible, 1, 0)

                    Next

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "tipo_id"
                        .HeaderText = "Tipo"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "unidad_id"
                        .HeaderText = "UM"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "unidad_id"
                        .HeaderText = "UM"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "presentacion_id"
                        .HeaderText = "Presentacion"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "precio_compra"
                        .HeaderText = "Precio Compra"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "porcentaje_utilidad"
                        .HeaderText = "% Utilidad"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "precio_venta"
                        .HeaderText = "Precio Venta"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "iva"
                        .HeaderText = "I.V.A"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "inventario_minimo"
                        .HeaderText = "Inventario Mínimo"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "inventario_maximo"
                        .HeaderText = "Inventario Máximo"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "punto_reorden"
                        .HeaderText = "Punto Reorden"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

                    index += 1
                    oGridColumnsClass = New GridColumnsClass()

                    With oGridColumnsClass
                        .ColumnName = "is_active"
                        .HeaderText = "Activo"
                        .Visible = True
                        .DisplayIndex = index
                    End With

                    lGridColumnsClass.Add(oGridColumnsClass)

            End Select



            Return lGridColumnsClass

        End Function

        Public Shared Function GetControlsBasicBinding() As Dictionary(Of String, String)

            Dim dictionary As New Dictionary(Of String, String)

            dictionary.Add("tGuid", "guid")
            dictionary.Add("tClaveId", "nombre_corto")
            dictionary.Add("tNombre", "nombre")
            dictionary.Add("tDescripcion", "descripcion")
            dictionary.Add("ckActivo", "is_active")

            Return dictionary

        End Function

        Public Shared Function GetControlsBindingList(ByVal sourceName As String) As Dictionary(Of String, String)

            Dim dictionary As New Dictionary(Of String, String)


            Select Case sourceName
                Case "FParts"

                    dictionary = GetControlsBasicBinding()

            End Select


            Return dictionary

        End Function


    End Class


End Module


