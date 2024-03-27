﻿Imports System.Reflection
Imports System.Linq

Partial Public Class FCatalogFormTemplate

    Public Shared Sub ClearAndUnbindFormControls(ByVal oForm As Object)

        UnbindAndClearControls(oForm)

        ClearProperties(oForm)

    End Sub

    Public Shared Sub UnbindAndClearControls(ByVal oForm As Object)

        Try
            For Each oCtrl As Control In oForm.Controls

                If TypeOf oCtrl Is TextBox Then

                    CType(oCtrl, TextBox).Clear()
                    CType(oCtrl, TextBox).DataBindings.Clear()

                ElseIf TypeOf oCtrl Is ComboBox Then

                    CType(oCtrl, ComboBox).SelectedIndex = -1
                    CType(oCtrl, ComboBox).DataBindings.Clear()

                ElseIf TypeOf oCtrl Is DateTimePicker Then

                    CType(oCtrl, DateTimePicker).DataBindings.Clear()

                    ' TODO DATETIME
                    CType(oCtrl, DateTimePicker).Format = DateTimePickerFormat.Custom
                    CType(oCtrl, DateTimePicker).CustomFormat = ""

                ElseIf TypeOf oCtrl Is CheckBox Then

                    CType(oCtrl, CheckBox).CheckState = CheckState.Unchecked
                    CType(oCtrl, CheckBox).DataBindings.Clear()

                ElseIf TypeOf oCtrl Is BindingNavigator Then

                    CType(oCtrl, BindingNavigator).DataBindings.Clear()

                    'ElseIf TypeOf oCtrl Is Label And oCtrl.Name.Equals("lbFolioAtlas") Then

                    '    CType(oCtrl, Label).Text = String.Empty

                ElseIf TypeOf oCtrl Is DataGridView Then

                    CType(oCtrl, DataGridView).DataSource = Nothing
                    CType(oCtrl, DataGridView).Rows.Clear()
                    '   CType(oCtrl, DataGridView).Columns.Clear()

                ElseIf TypeOf oCtrl Is ToolStrip Then

                    For Each itm As ToolStripItem In DirectCast(oCtrl, ToolStrip).Items

                        If itm.Name.Equals("lbFolioSap") Or itm.Name.Equals("lbConsecutivoSap") Then
                            itm.Text = String.Empty
                        End If
                    Next

                ElseIf TypeOf oCtrl Is PictureBox Then

                    CType(oCtrl, PictureBox).Image = New Bitmap(Global.IDPProjectManagement.My.Resources.NoImage)

                Else
                    ' Clear nested controls
                    If oCtrl.Controls.Count > 0 Then
                        If oCtrl.Name.Equals("TSDownDirectAcces") Then

                        End If

                        UnbindAndClearControls(oCtrl)

                    End If

                End If

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try

    End Sub

    Public Shared Sub ClearProperties(ByVal oForm As Object)

        Try

            'Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & "." & oForm.Name)

            'Dim oType As Type = oForm.[GetType]()

            'Dim ds As PropertyInfo = oForm.[GetType]().GetProperty("oDataSet")

            ''Dim dds = New DataSet

            ''dds = Convert.ChangeType(dds, oForm.[GetType]().GetProperty("oDataSet").PropertyType)

            ''dds = New DataSet

            If Not oForm.oDataSet Is Nothing Then oForm.oDataSet = New DataSet

            If Not oForm.oCollectionBSourceCombo Is Nothing Then oForm.oCollectionBSourceCombo.Clear()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Shared Function GetAllControls(root As Control) As IEnumerable(Of Control)
        Dim children = root.Controls.OfType(Of Control)().ToList()

        For index = children.Count - 1 To 0 Step -1
            children.AddRange(GetAllControls(children(index)))
        Next

        Return children
    End Function

    Public Shared Sub SetFormFormat(ByVal oForm As Object)

        Try

            ' This should be called first, somehow the grid doesnt binds when set maximaxed
            SetFormDisplayFormat(oForm)

            SetControlsBinding(oForm, oForm.Name, oForm.oBindingSource)

            ' Establece formato de los controles.
            SetGridPropertiesFormat(oForm)

            SetControlPropertiesFormat(oForm)

        Catch ex As Exception

            Dim p As String = ex.Message

        End Try


    End Sub

    Public Shared Sub SetFormDisplayFormat(ByVal oForm As Object)


        Select Case oForm.DisplayMode

            Case FormProcessType.Catalog

                ' Shows the form selected from the main menu.

                Dim oTableLayoutPanel As Object = oForm.Controls.Find("TableLayoutPanel1", True)

                If oTableLayoutPanel IsNot Nothing Then

                    With oTableLayoutPanel(0)

                        For i = 0 To .RowStyles.Count

                            Select Case i
                                Case 0

                                    .RowStyles.Item(i).SizeType = SizeType.Percent
                                    .RowStyles.Item(i).Height = 20

                                Case 1

                                    .RowStyles.Item(i).SizeType = SizeType.Percent
                                    .RowStyles.Item(i).Height = 75

                                Case 2
                                    .RowStyles.Item(i).SizeType = SizeType.Percent
                                    .RowStyles.Item(i).Height = 5

                            End Select

                        Next

                    End With
                End If


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

                Dim oTLPModeContainer As TableLayoutPanel = DirectCast(oForm, Form).Controls("TLPModeContainer")

                oTLPModeContainer.RowStyles.Item(1).Height = 0


            Case FormProcessType.Parent

                Dim oTableLayoutPanel As Object = oForm.Controls.Find("TableLayoutPanel1", True)

                If oTableLayoutPanel IsNot Nothing Then

                    With oTableLayoutPanel(0)

                        For i = 0 To .RowStyles.Count

                            Select Case i
                                Case 0

                                    .RowStyles.Item(i).SizeType = SizeType.Percent
                                    .RowStyles.Item(i).Height = 40

                                Case 1

                                    .RowStyles.Item(i).SizeType = SizeType.Percent
                                    .RowStyles.Item(i).Height = 50

                                Case 2
                                    .RowStyles.Item(i).SizeType = SizeType.Percent
                                    .RowStyles.Item(i).Height = 10

                            End Select

                        Next

                    End With
                End If

                With oForm
                    .ControlBox = True
                    .MaximizeBox = False
                    .MinimizeBox = False
                    .ShowIcon = False
                    .FormBorderStyle = FormBorderStyle.FixedDialog
                    '.FormBorderStyle = FormBorderStyle.None
                    .Size = New Size(1400, 350)

                End With

                Dim oTLPModeContainer As TableLayoutPanel = DirectCast(oForm, Form).Controls("TLPModeContainer")
                oTLPModeContainer.RowStyles.Item(1).SizeType = SizeType.Percent
                oTLPModeContainer.RowStyles.Item(1).Height = 50

            Case FormProcessType.Child

                Dim oTableLayoutPanel As Object = oForm.Controls.Find("TableLayoutPanel1", True)

                If oTableLayoutPanel IsNot Nothing Then

                    With oTableLayoutPanel(0)

                        For i = 0 To .RowStyles.Count

                            Select Case i
                                Case 0

                                    .RowStyles.Item(i).SizeType = SizeType.Percent
                                    .RowStyles.Item(i).Height = 40

                                Case 1

                                    .RowStyles.Item(i).SizeType = SizeType.Percent
                                    .RowStyles.Item(i).Height = 50

                                Case 2
                                    .RowStyles.Item(i).SizeType = SizeType.Percent
                                    .RowStyles.Item(i).Height = 10

                            End Select

                        Next

                    End With
                End If

                With oForm
                    .ControlBox = True
                    .MaximizeBox = False
                    .MinimizeBox = False
                    .ShowIcon = False
                    '.Dock = DockStyle.Fill
                    .FormBorderStyle = FormBorderStyle.FixedDialog
                    '.WindowState = FormWindowState.Maximized
                    .Size = New Size(1400, 350)

                End With

                Dim oTLPModeContainer As TableLayoutPanel = DirectCast(oForm, Form).Controls("TLPModeContainer")
                oTLPModeContainer.RowStyles.Item(1).SizeType = SizeType.Percent
                oTLPModeContainer.RowStyles.Item(1).Height = 50


                ' Sets Form Location.
                ' -----------------------------------------------------------------

                'Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & "." & oForm.Name)

                'Dim oFormToShow As Form = Nothing
                'oFormToShow = Activator.CreateInstance(oType)

                Dim frm = Application.OpenForms.Item(oForm.Name)

                oForm.Location = New Point(frm.Left, frm.Top + frm.Height)

                'If Not oForm.CommandQueryAsChild() Then

                '    'oFormController.child_form = Nothing
                '    DirectCast(frm.ParentForm, MDIMainContainer).oCFormController_.child_form = Nothing
                '    frm.Dispose()
                '    frm.focus()
                '    DirectCast(frm.ParentForm, MDIMainContainer).oCFormController_.parent_form.Focus()
                '    'DirectCast(frm.oFormController.parent_form, FProductos).Focus()
                '    Exit Sub

                'End If

                DirectCast(frm.ParentForm, MDIMainContainer).oCFormController_.child_form = frm

        End Select

    End Sub

    Public Shared Sub SetGridPropertiesFormat(ByVal oForm As Object)


        Dim oDataGridView As Object = oForm.Controls.Find("DataGridView", True)

        Try
            With oDataGridView(0)

                .MultiSelect = False

                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan

                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .ColumnHeadersDefaultCellStyle.Font = New Font(CType(.Font.FontFamily, FontFamily), 9.0F,
                .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)

                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
                .ColumnHeadersHeight = 20

                .DefaultCellStyle.Font = New Font(CType(.Font.FontFamily, FontFamily), 9.0F, FontStyle.Regular)

                .AutoGenerateColumns = False

                ' .DefaultCellStyle.NullValue = "NA"
                '--------------------------------------------------------------------
                ' TODO 
                '
                ' Change column properties and format in accordance with data. 
                '--------------------------------------------------------------------

                Dim lGridColumnsClass = ModFormClassDefinition.FormsControlsHelperClass.GetGridColumnDetails(oForm.Name)

                For Each column In lGridColumnsClass

                    .Columns(column.ColumnName).Visible = column.Visible
                    .Columns(column.ColumnName).HeaderText = column.HeaderText
                    .Columns(column.ColumnName).DisplayIndex = column.DisplayIndex

                Next

            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Shared Sub SetControlPropertiesFormat(ByVal oForm As FParts)

        Try
            With oForm

                .tClaveId.Tag = "Clave"
                .tClaveId.MaxLength = 18
                .tClaveId.TextAlign = HorizontalAlignment.Right

                .tNombre.Tag = "Nombre"
                .tNombre.MaxLength = 80
                .tNombre.TextAlign = HorizontalAlignment.Left

                .tDescripcion.Tag = "Descripción"
                .tDescripcion.MaxLength = 120
                .tDescripcion.TextAlign = HorizontalAlignment.Left

                .ckActivo.Tag = "Activo"

                .DataGridView.Tag = "DataGrid"

                ' Add behaviour events to controls.
                AddHandler .tClaveId.GotFocus, AddressOf CApplication.HandleGotFocus
                AddHandler .tClaveId.LostFocus, AddressOf CApplication.HandleLostFocus
                AddHandler .tClaveId.KeyPress, AddressOf CApplication.HandleNotSpaces

                AddHandler .tNombre.GotFocus, AddressOf CApplication.HandleGotFocus
                AddHandler .tNombre.LostFocus, AddressOf CApplication.HandleLostFocus

                AddHandler .tDescripcion.GotFocus, AddressOf CApplication.HandleGotFocus
                AddHandler .tDescripcion.LostFocus, AddressOf CApplication.HandleLostFocus

            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub


    Public Shared Function SetControlsBinding(ByVal oForm As Object, ByVal sourceName As String, ByVal oBindingSource As Object)

        Dim dictionary As New Dictionary(Of String, String)

        dictionary = ModFormClassDefinition.FormsControlsHelperClass.GetControlsBindingList(sourceName)

        Try
            For Each oCtrl As Control In oForm.Controls

                '----------------
                ' TEXTBOX BINDING.
                '----------------

                If TypeOf oCtrl Is TextBox Then

                    If dictionary.ContainsKey(CType(oCtrl, TextBox).Name) Then

                        CType(oCtrl, TextBox).DataBindings.Add("text", oBindingSource, dictionary.Item(CType(oCtrl, TextBox).Name), True)

                    End If

                    ' -------------------
                    ' CHECK BOX BINDING. 
                    ' -------------------

                ElseIf TypeOf oCtrl Is CheckBox Then

                    If dictionary.ContainsKey(CType(oCtrl, CheckBox).Name) Then

                        CType(oCtrl, CheckBox).DataBindings.Add("CheckState", oBindingSource, dictionary.Item(CType(oCtrl, CheckBox).Name), True)

                    End If

                    ' -------------------
                    ' COMBO BINDING.
                    ' -------------------

                    ' --------------------------------------
                    ' Get combo data for each Combobox in Form.
                    ' --------------------------------------

                    ' 1. Fill Combo Binding Source and Add Combo Binding Source to Collection.

                    ' 2. Add combo to Form in Simple View.

                    ' 3. Add combo to Grid in Multi View.


                    ' ------------------------
                    ' DATAGRIDVIEW BINDING.
                    ' ------------------------

                ElseIf TypeOf oCtrl Is DataGridView Then


                    CType(oCtrl, DataGridView).DataSource = oBindingSource


                    'ElseIf TypeOf oCtrl Is DateTimePicker Then

                    '    CType(oCtrl, DateTimePicker).DataBindings.Clear()

                    '    ' TODO DATETIME
                    '    CType(oCtrl, DateTimePicker).Format = DateTimePickerFormat.Custom
                    '    CType(oCtrl, DateTimePicker).CustomFormat = ""

                    'ElseIf TypeOf oCtrl Is CheckBox Then

                    '    CType(oCtrl, CheckBox).CheckState = CheckState.Unchecked
                    '    CType(oCtrl, CheckBox).DataBindings.Clear()

                    ' -------------------------------------------------------------
                    ' NAVIGATOR BINDING.
                    ' -------------------------------------------------------------
                ElseIf TypeOf oCtrl Is BindingNavigator Then

                    CType(oCtrl, BindingNavigator).BindingSource = oBindingSource

                    'ElseIf TypeOf oCtrl Is Label And oCtrl.Name.Equals("lbFolioAtlas") Then

                    '    CType(oCtrl, Label).Text = String.Empty



                    'ElseIf TypeOf oCtrl Is PictureBox Then

                    '    CType(oCtrl, PictureBox).Image = New Bitmap(Global.IDPProjectManagement.My.Resources.NoImage)

                Else
                    ' Clear nested controls
                    If oCtrl.Controls.Count > 0 Then

                        SetControlsBinding(oCtrl, sourceName, oBindingSource)

                    End If

                End If

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try




        'Try

        '    Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & "." & oForm.Name)


        '    'Dim buttons As List(Of Control) = New List(Of Control)()

        '    'For Each c As Control In oForm.Controls
        '    '    If (c.GetType.ToString = "TextBox") Then
        '    '        txtControl = c
        '    '    End If

        '    '    If (c.GetType.ToString = "BindingSource") Then
        '    '        txtControl = c
        '    '    End If
        '    'Next

        '    Dim frm = Application.OpenForms.Item(oForm.Name)

        '    Dim oTableLayoutPanel As Object = frm.Controls.Find("tGuid", True)

        '    Dim oableLayoutPanel As Object = oForm.Controls.Find("tGuid", True)

        '    Dim formType As Type = oForm.GetType().BaseType

        '    Dim formsType As Type = oForm.GetType()

        '    ' USEFUL Get all forms
        '    'Dim forms As List(Of Form) = (From t In oForm.GetType().Assembly.GetTypes() Where t.IsSubclassOf(formType) = True Select DirectCast(Activator.CreateInstance(t), Form)).ToList()

        '    'Dim allControls = New List(Of Button)()
        '    'For Each f In forms
        '    '    allControls.AddRange(GetAllControls(f).OfType(Of Button))
        '    'Next




        '    ''//////////////////////////////////////////////
        '    Dim oBindingSource = oForm.oBindingSource

        '    Dim names As String() = {"guid", "nombre_corto", "descripcion"}

        '    Dim allControls As List(Of TextBox)


        '    'TextBoxes

        '    allControls = New List(Of TextBox)()

        '    allControls.AddRange(GetAllControls(oForm).OfType(Of TextBox))


        '    'For Each item As String In names

        '    '    Dim oObject As Object = allControls.FirstOrDefault(Function(name) name.name = item)

        '    '    'Dim t As Object = oForm.FormRelated.Controls.Find("tGuid", True)

        '    '    If oObject IsNot Nothing Then
        '    '        oObject.DataBindings.Add("text", oBindingSource, item, True)
        '    '    End If

        '    'Next


        '    For Each item As String In names

        '        Dim oObject As TextBox = oForm.FormRelated.Controls.Find(item, True)

        '        If oObject IsNot Nothing Then

        '            oObject.DataBindings.Add("text", oBindingSource, item, True)

        '        End If

        '    Next



        '    Dim t As Object = oForm.FormRelated.Controls.Find("tGuid", True)

        '    Dim x As String = oForm.FormRelated.tGuid






        '    For Each item As String In names

        '        Dim firstLongName As TextBox = allControls.FirstOrDefault(Function(name) name.name = item)

        '        'firstLongName.DataBindings.Add("text", formType.oBindingSource, item, True)

        '    Next


        '    ''//////////////////////////////////////////////



        '    With oForm
        '        ' ----------------
        '        ' TEXTBOX BINDING.
        '        ' ----------------

        '        .tGuid.DataBindings.Add("text", .oBindingSource, "guid", True)

        '        .tClaveId.DataBindings.Add("text", .oBindingSource, "nombre_corto", True)

        '        .tNombre.DataBindings.Add("text", .oBindingSource, "nombre", True)

        '        .tDescripcion.DataBindings.Add("text", .oBindingSource, "descripcion", True).NullValue = CApplication.NotAssignedValue

        ' ------------------------
        ' CHECK BOX BINDING. 
        ' ------------------------
        '        .ckActivo.DataBindings.Add("CheckState", .oBindingSource, "is_active", True)

        '        ' -------------------------------------------------------------
        '        ' PICTURE BOX BINDING. 
        '        ' -------------------------------------------------------------

        ' -------------------
        ' COMBO BINDING.
        ' -------------------

        ' --------------------------------------
        ' Get combo data for each Combobox in Form.
        ' --------------------------------------

        ' 1. Fill Combo Binding Source and Add Combo Binding Source to Collection.

        ' 2. Add combo to Form in Simple View.

        ' 3. Add combo to Grid in Multi View.

        ' ------------------------
        ' DATAGRIDVIEW BINDING.
        ' ------------------------
        '        .DataGridView.DataSource = .oBindingSource

        ' -------------------------------------------------------------
        ' NAVIGATOR BINDING.
        ' -------------------------------------------------------------
        '        .BindingNavigator.BindingSource = .oBindingSource

        ' -------------------------------------------------------------
        ' Reset Binding.
        ' -------------------------------------------------------------
        '.oBindingSource.ResetBindings(True)

        '    End With


        'Catch ex As Exception

        '    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try

    End Function

    Public Shared Function SetControlsBindingOnNew(ByVal oForm As FParts) As Boolean

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

    Public Shared Function SetControlsBindingO(ByVal oForm As Object) As Boolean

        Try

            Dim oType As Type = Assembly.GetExecutingAssembly().GetType(My.Application.Info.AssemblyName & "." & oForm.Name)


            'Dim buttons As List(Of Control) = New List(Of Control)()

            'For Each c As Control In oForm.Controls
            '    If (c.GetType.ToString = "TextBox") Then
            '        txtControl = c
            '    End If

            '    If (c.GetType.ToString = "BindingSource") Then
            '        txtControl = c
            '    End If
            'Next

            Dim frm = Application.OpenForms.Item(oForm.Name)

            Dim oTableLayoutPanel As Object = frm.Controls.Find("tGuid", True)

            Dim oableLayoutPanel As Object = oForm.Controls.Find("tGuid", True)

            Dim formType As Type = oForm.GetType().BaseType

            Dim formsType As Type = oForm.GetType()

            ' USEFUL Get all forms
            'Dim forms As List(Of Form) = (From t In oForm.GetType().Assembly.GetTypes() Where t.IsSubclassOf(formType) = True Select DirectCast(Activator.CreateInstance(t), Form)).ToList()

            'Dim allControls = New List(Of Button)()
            'For Each f In forms
            '    allControls.AddRange(GetAllControls(f).OfType(Of Button))
            'Next




            ''//////////////////////////////////////////////
            Dim allControls

            ' DataBinding

            allControls = New List(Of BindingSource)()

            allControls.AddRange(GetAllControls(oForm).OfType(Of BindingSource))

            Dim oBindingSource As BindingSource = allControls.FirstOrDefault(Function(name) name = "oBindingSource")

            oBindingSource = oForm.oBindingSource

            Dim t As Object = oForm.FormRelated.Controls.Find("tGuid", True)

            Dim x As String = oForm.FormRelated.tGuid

            'TextBoxes

            allControls = New List(Of TextBox)()

            allControls.AddRange(GetAllControls(oForm).OfType(Of TextBox))


            Dim names As String() = {"guid", "nombre_corto"}

            For Each item As String In names

                Dim firstLongName As TextBox = allControls.FirstOrDefault(Function(name) name = item)

                'firstLongName.DataBindings.Add("text", formType.oBindingSource, item, True)

            Next


            ''//////////////////////////////////////////////





            allControls = New List(Of BindingSource)()

            allControls.AddRange(GetAllControls(oForm).OfType(Of BindingSource))

            Dim oTableLayoutPanels As Object = oForm.tGuid





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
                .oBindingSource.ResetBindings(True)

            End With

            SetControlsBindingO = True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return SetControlsBindingO

    End Function


End Class
