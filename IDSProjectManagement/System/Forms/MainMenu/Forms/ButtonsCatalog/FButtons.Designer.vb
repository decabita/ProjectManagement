<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FButtons
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FButtons))
        Me.BindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tNombre = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tButtonId = New System.Windows.Forms.TextBox
        Me.ckVisible = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridView = New System.Windows.Forms.DataGridView
        Me.TSDownDirectAcces = New System.Windows.Forms.ToolStrip
        Me.TSBSystemObjects = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.LowerComponentes = New System.Windows.Forms.ToolStripButton
        Me.BWorkerGetProducts = New System.ComponentModel.BackgroundWorker
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TPDetalle = New System.Windows.Forms.TabPage
        Me.cbMenu = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TPExtras = New System.Windows.Forms.TabPage
        Me.tDescripcion = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.tCaption = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tOrden = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbNiveles = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbObjectos = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSDownDirectAcces.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TPDetalle.SuspendLayout()
        Me.TPExtras.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BindingNavigator
        '
        Me.BindingNavigator.AddNewItem = Nothing
        Me.BindingNavigator.AutoSize = False
        Me.BindingNavigator.BackColor = System.Drawing.SystemColors.Control
        Me.BindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator.DeleteItem = Nothing
        Me.BindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator.Location = New System.Drawing.Point(720, 2)
        Me.BindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator.Name = "BindingNavigator"
        Me.BindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator.Size = New System.Drawing.Size(266, 31)
        Me.BindingNavigator.TabIndex = 6
        Me.BindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 28)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 28)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 28)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 31)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 28)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 28)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'tNombre
        '
        Me.tNombre.BackColor = System.Drawing.SystemColors.Window
        Me.tNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNombre.Location = New System.Drawing.Point(66, 57)
        Me.tNombre.Name = "tNombre"
        Me.tNombre.Size = New System.Drawing.Size(290, 22)
        Me.tNombre.TabIndex = 2
        Me.tNombre.Tag = "Nombre"
        Me.tNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nombre"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Clave"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tButtonId
        '
        Me.tButtonId.BackColor = System.Drawing.SystemColors.Window
        Me.tButtonId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tButtonId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tButtonId.Location = New System.Drawing.Point(66, 7)
        Me.tButtonId.Name = "tButtonId"
        Me.tButtonId.Size = New System.Drawing.Size(138, 22)
        Me.tButtonId.TabIndex = 1
        Me.tButtonId.Tag = "Clave"
        Me.tButtonId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ckVisible
        '
        Me.ckVisible.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckVisible.Enabled = False
        Me.ckVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckVisible.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ckVisible.Location = New System.Drawing.Point(34, 57)
        Me.ckVisible.Name = "ckVisible"
        Me.ckVisible.Size = New System.Drawing.Size(62, 24)
        Me.ckVisible.TabIndex = 2
        Me.ckVisible.TabStop = False
        Me.ckVisible.Text = "Visible"
        Me.ckVisible.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descripción"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.Size = New System.Drawing.Size(988, 129)
        Me.DataGridView.TabIndex = 4
        Me.DataGridView.Tag = "Grid"
        '
        'TSDownDirectAcces
        '
        Me.TSDownDirectAcces.BackColor = System.Drawing.SystemColors.Control
        Me.TSDownDirectAcces.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TSDownDirectAcces.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TSDownDirectAcces.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBSystemObjects, Me.ToolStripSeparator2, Me.LowerComponentes})
        Me.TSDownDirectAcces.Location = New System.Drawing.Point(2, 2)
        Me.TSDownDirectAcces.Name = "TSDownDirectAcces"
        Me.TSDownDirectAcces.Size = New System.Drawing.Size(716, 31)
        Me.TSDownDirectAcces.TabIndex = 5
        Me.TSDownDirectAcces.TabStop = True
        Me.TSDownDirectAcces.Text = "ToolStrip1"
        '
        'TSBSystemObjects
        '
        Me.TSBSystemObjects.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TSBSystemObjects.Image = Global.IDSProjectManagement.My.Resources.Resources.ChildForm
        Me.TSBSystemObjects.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSystemObjects.Name = "TSBSystemObjects"
        Me.TSBSystemObjects.Size = New System.Drawing.Size(153, 28)
        Me.TSBSystemObjects.Text = "Objetos Relacionados"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'LowerComponentes
        '
        Me.LowerComponentes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LowerComponentes.Image = CType(resources.GetObject("LowerComponentes.Image"), System.Drawing.Image)
        Me.LowerComponentes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LowerComponentes.Name = "LowerComponentes"
        Me.LowerComponentes.Size = New System.Drawing.Size(112, 28)
        Me.LowerComponentes.Text = "Exportar Excel"
        '
        'BWorkerGetProducts
        '
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.34146!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.65854!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(994, 293)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.tOrden)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.tNombre)
        Me.Panel1.Controls.Add(Me.tCaption)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.tButtonId)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(988, 111)
        Me.Panel1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TPDetalle)
        Me.TabControl1.Controls.Add(Me.TPExtras)
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(454, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(525, 110)
        Me.TabControl1.TabIndex = 3
        '
        'TPDetalle
        '
        Me.TPDetalle.Controls.Add(Me.cbObjectos)
        Me.TPDetalle.Controls.Add(Me.Label8)
        Me.TPDetalle.Controls.Add(Me.cbNiveles)
        Me.TPDetalle.Controls.Add(Me.Label7)
        Me.TPDetalle.Controls.Add(Me.cbMenu)
        Me.TPDetalle.Controls.Add(Me.Label4)
        Me.TPDetalle.Location = New System.Drawing.Point(4, 24)
        Me.TPDetalle.Name = "TPDetalle"
        Me.TPDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.TPDetalle.Size = New System.Drawing.Size(517, 82)
        Me.TPDetalle.TabIndex = 1
        Me.TPDetalle.Text = "Detalle"
        Me.TPDetalle.UseVisualStyleBackColor = True
        '
        'cbMenu
        '
        Me.cbMenu.BackColor = System.Drawing.SystemColors.Window
        Me.cbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMenu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMenu.FormattingEnabled = True
        Me.cbMenu.Location = New System.Drawing.Point(60, 30)
        Me.cbMenu.Name = "cbMenu"
        Me.cbMenu.Size = New System.Drawing.Size(290, 22)
        Me.cbMenu.TabIndex = 1
        Me.cbMenu.Tag = "Unidad"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 14)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Menu"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TPExtras
        '
        Me.TPExtras.Controls.Add(Me.tDescripcion)
        Me.TPExtras.Controls.Add(Me.Label2)
        Me.TPExtras.Controls.Add(Me.ckVisible)
        Me.TPExtras.Location = New System.Drawing.Point(4, 24)
        Me.TPExtras.Name = "TPExtras"
        Me.TPExtras.Padding = New System.Windows.Forms.Padding(3)
        Me.TPExtras.Size = New System.Drawing.Size(517, 82)
        Me.TPExtras.TabIndex = 0
        Me.TPExtras.Text = "Datos Adicionales"
        Me.TPExtras.UseVisualStyleBackColor = True
        '
        'tDescripcion
        '
        Me.tDescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.tDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescripcion.Location = New System.Drawing.Point(86, 8)
        Me.tDescripcion.Multiline = True
        Me.tDescripcion.Name = "tDescripcion"
        Me.tDescripcion.Size = New System.Drawing.Size(366, 44)
        Me.tDescripcion.TabIndex = 1
        Me.tDescripcion.Tag = "Marca"
        Me.tDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 120)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(988, 129)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.98245!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.01754!))
        Me.TableLayoutPanel2.Controls.Add(Me.TSDownDirectAcces, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BindingNavigator, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 255)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(988, 35)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'tCaption
        '
        Me.tCaption.BackColor = System.Drawing.SystemColors.Window
        Me.tCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCaption.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.tCaption.Location = New System.Drawing.Point(66, 82)
        Me.tCaption.Name = "tCaption"
        Me.tCaption.Size = New System.Drawing.Size(290, 22)
        Me.tCaption.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 14)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Etiqueta"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tOrden
        '
        Me.tOrden.BackColor = System.Drawing.SystemColors.Window
        Me.tOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tOrden.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.tOrden.Location = New System.Drawing.Point(66, 32)
        Me.tOrden.Name = "tOrden"
        Me.tOrden.Size = New System.Drawing.Size(138, 22)
        Me.tOrden.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 14)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Orden"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbNiveles
        '
        Me.cbNiveles.BackColor = System.Drawing.SystemColors.Window
        Me.cbNiveles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNiveles.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNiveles.FormattingEnabled = True
        Me.cbNiveles.Location = New System.Drawing.Point(60, 6)
        Me.cbNiveles.Name = "cbNiveles"
        Me.cbNiveles.Size = New System.Drawing.Size(290, 22)
        Me.cbNiveles.TabIndex = 7
        Me.cbNiveles.Tag = "Unidad"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 14)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Nivel"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbObjectos
        '
        Me.cbObjectos.BackColor = System.Drawing.SystemColors.Window
        Me.cbObjectos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObjectos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbObjectos.FormattingEnabled = True
        Me.cbObjectos.Location = New System.Drawing.Point(60, 54)
        Me.cbObjectos.Name = "cbObjectos"
        Me.cbObjectos.Size = New System.Drawing.Size(290, 22)
        Me.cbObjectos.TabIndex = 9
        Me.cbObjectos.Tag = "Unidad"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 14)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Objecto"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FButtons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 293)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FButtons"
        Me.Text = "Catálogo de Botones de Menú"
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator.ResumeLayout(False)
        Me.BindingNavigator.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSDownDirectAcces.ResumeLayout(False)
        Me.TSDownDirectAcces.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TPDetalle.ResumeLayout(False)
        Me.TPExtras.ResumeLayout(False)
        Me.TPExtras.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSDownDirectAcces As System.Windows.Forms.ToolStrip
    Friend WithEvents LowerComponentes As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tButtonId As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents tNombre As System.Windows.Forms.TextBox
    Friend WithEvents ckVisible As System.Windows.Forms.CheckBox
    Friend WithEvents BWorkerGetProducts As System.ComponentModel.BackgroundWorker
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TPExtras As System.Windows.Forms.TabPage
    Friend WithEvents tDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TSBSystemObjects As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cbMenu As System.Windows.Forms.ComboBox
    Friend WithEvents TPDetalle As System.Windows.Forms.TabPage
    Friend WithEvents tOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tCaption As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbNiveles As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbObjectos As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    '  Friend WithEvents DbNavigationBar1 As DBNavigation.DbNavigationBar
End Class
