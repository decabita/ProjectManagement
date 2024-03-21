<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FParts
    Inherits FCatalogFormTemplate

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FParts))
        Me.BWorkerGetData = New System.ComponentModel.BackgroundWorker()
        Me.TLPModeContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.PnlParentFormContainer = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PnlUpperDataContainer = New System.Windows.Forms.Panel()
        Me.TLPFormUpperData = New System.Windows.Forms.TableLayoutPanel()
        Me.PnlDataContainerLeft = New System.Windows.Forms.Panel()
        Me.lblGuid = New System.Windows.Forms.Label()
        Me.tGuid = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tClaveId = New System.Windows.Forms.TextBox()
        Me.PnlDataContainerRight = New System.Windows.Forms.Panel()
        Me.TCAdditionalData = New System.Windows.Forms.TabControl()
        Me.TPExtras = New System.Windows.Forms.TabPage()
        Me.tDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ckActivo = New System.Windows.Forms.CheckBox()
        Me.PnlGridContainer = New System.Windows.Forms.Panel()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.TLPBottomDAccessContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.TSDownDirectAcces = New System.Windows.Forms.ToolStrip()
        Me.TSBBom = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TLPModeContainer.SuspendLayout()
        Me.PnlParentFormContainer.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PnlUpperDataContainer.SuspendLayout()
        Me.TLPFormUpperData.SuspendLayout()
        Me.PnlDataContainerLeft.SuspendLayout()
        Me.PnlDataContainerRight.SuspendLayout()
        Me.TCAdditionalData.SuspendLayout()
        Me.TPExtras.SuspendLayout()
        Me.PnlGridContainer.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TLPBottomDAccessContainer.SuspendLayout()
        Me.TSDownDirectAcces.SuspendLayout()
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'BWorkerGetData
        '
        '
        'TLPModeContainer
        '
        Me.TLPModeContainer.ColumnCount = 1
        Me.TLPModeContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLPModeContainer.Controls.Add(Me.PnlParentFormContainer, 0, 0)
        Me.TLPModeContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLPModeContainer.Location = New System.Drawing.Point(0, 0)
        Me.TLPModeContainer.Name = "TLPModeContainer"
        Me.TLPModeContainer.RowCount = 1
        Me.TLPModeContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLPModeContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPModeContainer.Size = New System.Drawing.Size(1581, 449)
        Me.TLPModeContainer.TabIndex = 0
        '
        'PnlParentFormContainer
        '
        Me.PnlParentFormContainer.BackColor = System.Drawing.Color.NavajoWhite
        Me.PnlParentFormContainer.Controls.Add(Me.TableLayoutPanel1)
        Me.PnlParentFormContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlParentFormContainer.Location = New System.Drawing.Point(3, 3)
        Me.PnlParentFormContainer.Name = "PnlParentFormContainer"
        Me.PnlParentFormContainer.Size = New System.Drawing.Size(1575, 443)
        Me.PnlParentFormContainer.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PnlUpperDataContainer, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PnlGridContainer, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TLPBottomDAccessContainer, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1575, 443)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'PnlUpperDataContainer
        '
        Me.PnlUpperDataContainer.BackColor = System.Drawing.Color.SandyBrown
        Me.PnlUpperDataContainer.Controls.Add(Me.TLPFormUpperData)
        Me.PnlUpperDataContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlUpperDataContainer.Location = New System.Drawing.Point(1, 1)
        Me.PnlUpperDataContainer.Margin = New System.Windows.Forms.Padding(1)
        Me.PnlUpperDataContainer.Name = "PnlUpperDataContainer"
        Me.PnlUpperDataContainer.Size = New System.Drawing.Size(1573, 130)
        Me.PnlUpperDataContainer.TabIndex = 0
        '
        'TLPFormUpperData
        '
        Me.TLPFormUpperData.BackColor = System.Drawing.Color.Tomato
        Me.TLPFormUpperData.ColumnCount = 2
        Me.TLPFormUpperData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TLPFormUpperData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TLPFormUpperData.Controls.Add(Me.PnlDataContainerLeft, 0, 0)
        Me.TLPFormUpperData.Controls.Add(Me.PnlDataContainerRight, 1, 0)
        Me.TLPFormUpperData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLPFormUpperData.Location = New System.Drawing.Point(0, 0)
        Me.TLPFormUpperData.Name = "TLPFormUpperData"
        Me.TLPFormUpperData.RowCount = 1
        Me.TLPFormUpperData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TLPFormUpperData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TLPFormUpperData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TLPFormUpperData.Size = New System.Drawing.Size(1573, 130)
        Me.TLPFormUpperData.TabIndex = 1
        '
        'PnlDataContainerLeft
        '
        Me.PnlDataContainerLeft.BackColor = System.Drawing.SystemColors.Control
        Me.PnlDataContainerLeft.Controls.Add(Me.lblGuid)
        Me.PnlDataContainerLeft.Controls.Add(Me.tGuid)
        Me.PnlDataContainerLeft.Controls.Add(Me.Label3)
        Me.PnlDataContainerLeft.Controls.Add(Me.tNombre)
        Me.PnlDataContainerLeft.Controls.Add(Me.Label1)
        Me.PnlDataContainerLeft.Controls.Add(Me.tClaveId)
        Me.PnlDataContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataContainerLeft.Location = New System.Drawing.Point(1, 1)
        Me.PnlDataContainerLeft.Margin = New System.Windows.Forms.Padding(1)
        Me.PnlDataContainerLeft.Name = "PnlDataContainerLeft"
        Me.PnlDataContainerLeft.Size = New System.Drawing.Size(784, 128)
        Me.PnlDataContainerLeft.TabIndex = 0
        '
        'lblGuid
        '
        Me.lblGuid.AutoSize = True
        Me.lblGuid.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuid.Location = New System.Drawing.Point(48, 12)
        Me.lblGuid.Name = "lblGuid"
        Me.lblGuid.Size = New System.Drawing.Size(36, 18)
        Me.lblGuid.TabIndex = 26
        Me.lblGuid.Text = "Guid"
        Me.lblGuid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tGuid
        '
        Me.tGuid.BackColor = System.Drawing.SystemColors.Window
        Me.tGuid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tGuid.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tGuid.Location = New System.Drawing.Point(88, 8)
        Me.tGuid.Name = "tGuid"
        Me.tGuid.Size = New System.Drawing.Size(290, 26)
        Me.tGuid.TabIndex = 25
        Me.tGuid.Tag = "Guid"
        Me.tGuid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 18)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Nombre"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tNombre
        '
        Me.tNombre.BackColor = System.Drawing.SystemColors.Window
        Me.tNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNombre.Location = New System.Drawing.Point(88, 68)
        Me.tNombre.Name = "tNombre"
        Me.tNombre.Size = New System.Drawing.Size(290, 26)
        Me.tNombre.TabIndex = 23
        Me.tNombre.Tag = "Nombre"
        Me.tNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 18)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Clave"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tClaveId
        '
        Me.tClaveId.BackColor = System.Drawing.SystemColors.Window
        Me.tClaveId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tClaveId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tClaveId.Location = New System.Drawing.Point(88, 38)
        Me.tClaveId.Name = "tClaveId"
        Me.tClaveId.Size = New System.Drawing.Size(290, 26)
        Me.tClaveId.TabIndex = 22
        Me.tClaveId.Tag = "Clave"
        Me.tClaveId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PnlDataContainerRight
        '
        Me.PnlDataContainerRight.Controls.Add(Me.TCAdditionalData)
        Me.PnlDataContainerRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataContainerRight.Location = New System.Drawing.Point(787, 1)
        Me.PnlDataContainerRight.Margin = New System.Windows.Forms.Padding(1)
        Me.PnlDataContainerRight.Name = "PnlDataContainerRight"
        Me.PnlDataContainerRight.Size = New System.Drawing.Size(785, 128)
        Me.PnlDataContainerRight.TabIndex = 1
        '
        'TCAdditionalData
        '
        Me.TCAdditionalData.Controls.Add(Me.TPExtras)
        Me.TCAdditionalData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCAdditionalData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCAdditionalData.Location = New System.Drawing.Point(0, 0)
        Me.TCAdditionalData.Name = "TCAdditionalData"
        Me.TCAdditionalData.SelectedIndex = 0
        Me.TCAdditionalData.Size = New System.Drawing.Size(785, 128)
        Me.TCAdditionalData.TabIndex = 10
        '
        'TPExtras
        '
        Me.TPExtras.Controls.Add(Me.tDescripcion)
        Me.TPExtras.Controls.Add(Me.Label2)
        Me.TPExtras.Controls.Add(Me.ckActivo)
        Me.TPExtras.Location = New System.Drawing.Point(4, 27)
        Me.TPExtras.Name = "TPExtras"
        Me.TPExtras.Padding = New System.Windows.Forms.Padding(3)
        Me.TPExtras.Size = New System.Drawing.Size(777, 97)
        Me.TPExtras.TabIndex = 0
        Me.TPExtras.Text = "Datos Adicionales"
        Me.TPExtras.UseVisualStyleBackColor = True
        '
        'tDescripcion
        '
        Me.tDescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.tDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescripcion.Location = New System.Drawing.Point(112, 8)
        Me.tDescripcion.Multiline = True
        Me.tDescripcion.Name = "tDescripcion"
        Me.tDescripcion.Size = New System.Drawing.Size(424, 64)
        Me.tDescripcion.TabIndex = 1
        Me.tDescripcion.Tag = "Marca"
        Me.tDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descripción"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ckActivo
        '
        Me.ckActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckActivo.Enabled = False
        Me.ckActivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckActivo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ckActivo.Location = New System.Drawing.Point(552, 8)
        Me.ckActivo.Name = "ckActivo"
        Me.ckActivo.Size = New System.Drawing.Size(72, 24)
        Me.ckActivo.TabIndex = 2
        Me.ckActivo.TabStop = False
        Me.ckActivo.Text = "Activo"
        Me.ckActivo.UseVisualStyleBackColor = True
        '
        'PnlGridContainer
        '
        Me.PnlGridContainer.Controls.Add(Me.DataGridView)
        Me.PnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlGridContainer.Location = New System.Drawing.Point(1, 133)
        Me.PnlGridContainer.Margin = New System.Windows.Forms.Padding(1)
        Me.PnlGridContainer.Name = "PnlGridContainer"
        Me.PnlGridContainer.Size = New System.Drawing.Size(1573, 263)
        Me.PnlGridContainer.TabIndex = 1
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
        Me.DataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView.MultiSelect = False
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.RowHeadersWidth = 51
        Me.DataGridView.Size = New System.Drawing.Size(1573, 263)
        Me.DataGridView.TabIndex = 6
        Me.DataGridView.Tag = "Grid"
        '
        'TLPBottomDAccessContainer
        '
        Me.TLPBottomDAccessContainer.BackColor = System.Drawing.Color.Orange
        Me.TLPBottomDAccessContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TLPBottomDAccessContainer.ColumnCount = 2
        Me.TLPBottomDAccessContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.98245!))
        Me.TLPBottomDAccessContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.01754!))
        Me.TLPBottomDAccessContainer.Controls.Add(Me.TSDownDirectAcces, 0, 0)
        Me.TLPBottomDAccessContainer.Controls.Add(Me.BindingNavigator, 1, 0)
        Me.TLPBottomDAccessContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLPBottomDAccessContainer.Location = New System.Drawing.Point(1, 398)
        Me.TLPBottomDAccessContainer.Margin = New System.Windows.Forms.Padding(1)
        Me.TLPBottomDAccessContainer.Name = "TLPBottomDAccessContainer"
        Me.TLPBottomDAccessContainer.RowCount = 1
        Me.TLPBottomDAccessContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TLPBottomDAccessContainer.Size = New System.Drawing.Size(1573, 44)
        Me.TLPBottomDAccessContainer.TabIndex = 2
        '
        'TSDownDirectAcces
        '
        Me.TSDownDirectAcces.BackColor = System.Drawing.SystemColors.Control
        Me.TSDownDirectAcces.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TSDownDirectAcces.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TSDownDirectAcces.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBBom})
        Me.TSDownDirectAcces.Location = New System.Drawing.Point(2, 2)
        Me.TSDownDirectAcces.Name = "TSDownDirectAcces"
        Me.TSDownDirectAcces.Size = New System.Drawing.Size(1143, 40)
        Me.TSDownDirectAcces.TabIndex = 6
        Me.TSDownDirectAcces.TabStop = True
        Me.TSDownDirectAcces.Text = "ToolStrip1"
        '
        'TSBBom
        '
        Me.TSBBom.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBBom.Image = Global.IDPProjectManagement.My.Resources.Resources.ChildForm
        Me.TSBBom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBBom.Name = "TSBBom"
        Me.TSBBom.Size = New System.Drawing.Size(175, 37)
        Me.TSBBom.Text = "Lista de Materiales"
        '
        'BindingNavigator
        '
        Me.BindingNavigator.AddNewItem = Nothing
        Me.BindingNavigator.AutoSize = False
        Me.BindingNavigator.BackColor = System.Drawing.SystemColors.Control
        Me.BindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator.DeleteItem = Nothing
        Me.BindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BindingNavigator.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator.Location = New System.Drawing.Point(1147, 2)
        Me.BindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator.Name = "BindingNavigator"
        Me.BindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator.Size = New System.Drawing.Size(424, 40)
        Me.BindingNavigator.TabIndex = 7
        Me.BindingNavigator.TabStop = True
        Me.BindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(45, 37)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(29, 37)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(29, 37)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 40)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(29, 37)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(29, 37)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'FParts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1581, 449)
        Me.Controls.Add(Me.TLPModeContainer)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FParts"
        Me.Text = "Catálogo de Productos"
        Me.TLPModeContainer.ResumeLayout(False)
        Me.PnlParentFormContainer.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PnlUpperDataContainer.ResumeLayout(False)
        Me.TLPFormUpperData.ResumeLayout(False)
        Me.PnlDataContainerLeft.ResumeLayout(False)
        Me.PnlDataContainerLeft.PerformLayout()
        Me.PnlDataContainerRight.ResumeLayout(False)
        Me.TCAdditionalData.ResumeLayout(False)
        Me.TPExtras.ResumeLayout(False)
        Me.TPExtras.PerformLayout()
        Me.PnlGridContainer.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TLPBottomDAccessContainer.ResumeLayout(False)
        Me.TLPBottomDAccessContainer.PerformLayout()
        Me.TSDownDirectAcces.ResumeLayout(False)
        Me.TSDownDirectAcces.PerformLayout()
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator.ResumeLayout(False)
        Me.BindingNavigator.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BWorkerGetData As System.ComponentModel.BackgroundWorker
    Friend WithEvents TLPModeContainer As TableLayoutPanel
    Friend WithEvents PnlParentFormContainer As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PnlGridContainer As Panel
    Friend WithEvents TLPBottomDAccessContainer As TableLayoutPanel
    Friend WithEvents BindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents DataGridView As DataGridView
    Friend WithEvents PnlUpperDataContainer As Panel
    Friend WithEvents TLPFormUpperData As TableLayoutPanel
    Friend WithEvents PnlDataContainerLeft As Panel
    Friend WithEvents lblGuid As Label
    Friend WithEvents tGuid As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tClaveId As TextBox
    Friend WithEvents PnlDataContainerRight As Panel
    Friend WithEvents TCAdditionalData As TabControl
    Friend WithEvents TPExtras As TabPage
    Friend WithEvents tDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ckActivo As CheckBox
    Friend WithEvents TSDownDirectAcces As ToolStrip
    Friend WithEvents TSBBom As ToolStripButton
    '  Friend WithEvents DbNavigationBar1 As DBNavigation.DbNavigationBar
End Class