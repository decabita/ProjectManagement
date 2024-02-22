<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FProductoTerminado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FProductoTerminado))
        Me.BWorkerGetData = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TSDownDirectAcces = New System.Windows.Forms.ToolStrip()
        Me.TSBBom = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBEspecificaciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBAdicionales = New System.Windows.Forms.ToolStripButton()
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TPDetalle = New System.Windows.Forms.TabPage()
        Me.tUtilidad = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tPrecioCompra = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tPrecioVenta = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbPresentacion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tCodigoBarras = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbTipoMaterial = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tClaveId = New System.Windows.Forms.TextBox()
        Me.tNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbUnidad = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TPInventario = New System.Windows.Forms.TabPage()
        Me.tReorden = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tInventarioMax = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tInventarioMin = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TPExtras = New System.Windows.Forms.TabPage()
        Me.tDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ckActivo = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TSDownDirectAcces.SuspendLayout()
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TPDetalle.SuspendLayout()
        Me.TPInventario.SuspendLayout()
        Me.TPExtras.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BWorkerGetData
        '
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 565)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1240, 35)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'TSDownDirectAcces
        '
        Me.TSDownDirectAcces.BackColor = System.Drawing.SystemColors.Control
        Me.TSDownDirectAcces.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TSDownDirectAcces.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TSDownDirectAcces.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBBom, Me.ToolStripSeparator2, Me.TSBEspecificaciones, Me.ToolStripSeparator1, Me.TSBAdicionales})
        Me.TSDownDirectAcces.Location = New System.Drawing.Point(2, 2)
        Me.TSDownDirectAcces.Name = "TSDownDirectAcces"
        Me.TSDownDirectAcces.Size = New System.Drawing.Size(900, 31)
        Me.TSDownDirectAcces.TabIndex = 6
        Me.TSDownDirectAcces.TabStop = True
        Me.TSDownDirectAcces.Text = "ToolStrip1"
        '
        'TSBBom
        '
        Me.TSBBom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TSBBom.Image = Global.IDPProjectManagement.My.Resources.Resources.ChildForm
        Me.TSBBom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBBom.Name = "TSBBom"
        Me.TSBBom.Size = New System.Drawing.Size(158, 28)
        Me.TSBBom.Text = "Lista de Materiales"
        Me.TSBBom.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'TSBEspecificaciones
        '
        Me.TSBEspecificaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TSBEspecificaciones.Image = Global.IDPProjectManagement.My.Resources.Resources.ChildForm
        Me.TSBEspecificaciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBEspecificaciones.Name = "TSBEspecificaciones"
        Me.TSBEspecificaciones.Size = New System.Drawing.Size(141, 28)
        Me.TSBEspecificaciones.Text = "Especificaciones"
        Me.TSBEspecificaciones.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'TSBAdicionales
        '
        Me.TSBAdicionales.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TSBAdicionales.Image = Global.IDPProjectManagement.My.Resources.Resources.ChildForm
        Me.TSBAdicionales.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBAdicionales.Name = "TSBAdicionales"
        Me.TSBAdicionales.Size = New System.Drawing.Size(152, 28)
        Me.TSBAdicionales.Text = "Datos Adicionales"
        Me.TSBAdicionales.Visible = False
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
        Me.BindingNavigator.Location = New System.Drawing.Point(904, 2)
        Me.BindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator.Name = "BindingNavigator"
        Me.BindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator.Size = New System.Drawing.Size(334, 31)
        Me.BindingNavigator.TabIndex = 7
        Me.BindingNavigator.TabStop = True
        Me.BindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(48, 28)
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
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.6726!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.3274!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1246, 603)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1240, 172)
        Me.Panel1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TPDetalle)
        Me.TabControl1.Controls.Add(Me.TPInventario)
        Me.TabControl1.Controls.Add(Me.TPExtras)
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(9, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1231, 165)
        Me.TabControl1.TabIndex = 4
        '
        'TPDetalle
        '
        Me.TPDetalle.Controls.Add(Me.tUtilidad)
        Me.TPDetalle.Controls.Add(Me.Label10)
        Me.TPDetalle.Controls.Add(Me.tPrecioCompra)
        Me.TPDetalle.Controls.Add(Me.Label8)
        Me.TPDetalle.Controls.Add(Me.tPrecioVenta)
        Me.TPDetalle.Controls.Add(Me.Label9)
        Me.TPDetalle.Controls.Add(Me.cbPresentacion)
        Me.TPDetalle.Controls.Add(Me.Label7)
        Me.TPDetalle.Controls.Add(Me.tCodigoBarras)
        Me.TPDetalle.Controls.Add(Me.Label6)
        Me.TPDetalle.Controls.Add(Me.cbTipoMaterial)
        Me.TPDetalle.Controls.Add(Me.Label4)
        Me.TPDetalle.Controls.Add(Me.tClaveId)
        Me.TPDetalle.Controls.Add(Me.tNombre)
        Me.TPDetalle.Controls.Add(Me.Label1)
        Me.TPDetalle.Controls.Add(Me.Label3)
        Me.TPDetalle.Controls.Add(Me.cbUnidad)
        Me.TPDetalle.Controls.Add(Me.Label5)
        Me.TPDetalle.Location = New System.Drawing.Point(4, 27)
        Me.TPDetalle.Name = "TPDetalle"
        Me.TPDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.TPDetalle.Size = New System.Drawing.Size(1223, 134)
        Me.TPDetalle.TabIndex = 1
        Me.TPDetalle.Text = "Detalle"
        Me.TPDetalle.UseVisualStyleBackColor = True
        '
        'tUtilidad
        '
        Me.tUtilidad.BackColor = System.Drawing.SystemColors.Window
        Me.tUtilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tUtilidad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tUtilidad.Location = New System.Drawing.Point(367, 97)
        Me.tUtilidad.Name = "tUtilidad"
        Me.tUtilidad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tUtilidad.Size = New System.Drawing.Size(142, 26)
        Me.tUtilidad.TabIndex = 17
        Me.tUtilidad.Tag = "Utilidad %"
        Me.tUtilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(288, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 18)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Utilidad %"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tPrecioCompra
        '
        Me.tPrecioCompra.BackColor = System.Drawing.SystemColors.Window
        Me.tPrecioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tPrecioCompra.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPrecioCompra.Location = New System.Drawing.Point(117, 97)
        Me.tPrecioCompra.Name = "tPrecioCompra"
        Me.tPrecioCompra.Size = New System.Drawing.Size(142, 26)
        Me.tPrecioCompra.TabIndex = 7
        Me.tPrecioCompra.Tag = "Precio Compra"
        Me.tPrecioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 18)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Costo"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tPrecioVenta
        '
        Me.tPrecioVenta.BackColor = System.Drawing.SystemColors.Window
        Me.tPrecioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tPrecioVenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPrecioVenta.Location = New System.Drawing.Point(655, 97)
        Me.tPrecioVenta.Name = "tPrecioVenta"
        Me.tPrecioVenta.Size = New System.Drawing.Size(142, 26)
        Me.tPrecioVenta.TabIndex = 8
        Me.tPrecioVenta.Tag = "Precio de Venta"
        Me.tPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(539, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 18)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Precio de Venta"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbPresentacion
        '
        Me.cbPresentacion.BackColor = System.Drawing.SystemColors.Window
        Me.cbPresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPresentacion.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cbPresentacion.FormattingEnabled = True
        Me.cbPresentacion.Location = New System.Drawing.Point(117, 55)
        Me.cbPresentacion.Name = "cbPresentacion"
        Me.cbPresentacion.Size = New System.Drawing.Size(264, 26)
        Me.cbPresentacion.TabIndex = 4
        Me.cbPresentacion.Tag = "Unidad"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 37)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Presentación"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tCodigoBarras
        '
        Me.tCodigoBarras.BackColor = System.Drawing.SystemColors.Window
        Me.tCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCodigoBarras.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCodigoBarras.Location = New System.Drawing.Point(117, 10)
        Me.tCodigoBarras.Name = "tCodigoBarras"
        Me.tCodigoBarras.Size = New System.Drawing.Size(142, 26)
        Me.tCodigoBarras.TabIndex = 1
        Me.tCodigoBarras.Tag = "Clave"
        Me.tCodigoBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 18)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Código Barras"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbTipoMaterial
        '
        Me.cbTipoMaterial.BackColor = System.Drawing.SystemColors.Window
        Me.cbTipoMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoMaterial.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoMaterial.FormattingEnabled = True
        Me.cbTipoMaterial.Location = New System.Drawing.Point(846, 54)
        Me.cbTipoMaterial.Name = "cbTipoMaterial"
        Me.cbTipoMaterial.Size = New System.Drawing.Size(264, 26)
        Me.cbTipoMaterial.TabIndex = 6
        Me.cbTipoMaterial.Tag = "Tipo"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(769, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 42)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tipo de Producto"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tClaveId
        '
        Me.tClaveId.BackColor = System.Drawing.SystemColors.Window
        Me.tClaveId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tClaveId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tClaveId.Location = New System.Drawing.Point(367, 7)
        Me.tClaveId.Name = "tClaveId"
        Me.tClaveId.Size = New System.Drawing.Size(142, 26)
        Me.tClaveId.TabIndex = 2
        Me.tClaveId.Tag = "Clave"
        Me.tClaveId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tNombre
        '
        Me.tNombre.BackColor = System.Drawing.SystemColors.Window
        Me.tNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNombre.Location = New System.Drawing.Point(605, 8)
        Me.tNombre.Name = "tNombre"
        Me.tNombre.Size = New System.Drawing.Size(505, 26)
        Me.tNombre.TabIndex = 3
        Me.tNombre.Tag = "Nombre"
        Me.tNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(265, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 18)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Clave Interna"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(539, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 18)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Nombre"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbUnidad
        '
        Me.cbUnidad.BackColor = System.Drawing.SystemColors.Window
        Me.cbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUnidad.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cbUnidad.FormattingEnabled = True
        Me.cbUnidad.Location = New System.Drawing.Point(488, 55)
        Me.cbUnidad.Name = "cbUnidad"
        Me.cbUnidad.Size = New System.Drawing.Size(264, 26)
        Me.cbUnidad.TabIndex = 5
        Me.cbUnidad.Tag = "Unidad"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(387, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 37)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Unidad de Venta"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TPInventario
        '
        Me.TPInventario.Controls.Add(Me.tReorden)
        Me.TPInventario.Controls.Add(Me.Label13)
        Me.TPInventario.Controls.Add(Me.tInventarioMax)
        Me.TPInventario.Controls.Add(Me.Label12)
        Me.TPInventario.Controls.Add(Me.tInventarioMin)
        Me.TPInventario.Controls.Add(Me.Label11)
        Me.TPInventario.Location = New System.Drawing.Point(4, 27)
        Me.TPInventario.Name = "TPInventario"
        Me.TPInventario.Size = New System.Drawing.Size(1223, 134)
        Me.TPInventario.TabIndex = 2
        Me.TPInventario.Text = "Inventario"
        Me.TPInventario.UseVisualStyleBackColor = True
        '
        'tReorden
        '
        Me.tReorden.BackColor = System.Drawing.SystemColors.Window
        Me.tReorden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tReorden.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tReorden.Location = New System.Drawing.Point(793, 16)
        Me.tReorden.Name = "tReorden"
        Me.tReorden.Size = New System.Drawing.Size(142, 26)
        Me.tReorden.TabIndex = 20
        Me.tReorden.Tag = "Punto de Reorden"
        Me.tReorden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(663, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 18)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Punto de Reorden"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tInventarioMax
        '
        Me.tInventarioMax.BackColor = System.Drawing.SystemColors.Window
        Me.tInventarioMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tInventarioMax.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tInventarioMax.Location = New System.Drawing.Point(459, 16)
        Me.tInventarioMax.Name = "tInventarioMax"
        Me.tInventarioMax.Size = New System.Drawing.Size(142, 26)
        Me.tInventarioMax.TabIndex = 18
        Me.tInventarioMax.Tag = "Inventario Máximo"
        Me.tInventarioMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(329, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(130, 18)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Inventario Máximo"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tInventarioMin
        '
        Me.tInventarioMin.BackColor = System.Drawing.SystemColors.Window
        Me.tInventarioMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tInventarioMin.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tInventarioMin.Location = New System.Drawing.Point(146, 16)
        Me.tInventarioMin.Name = "tInventarioMin"
        Me.tInventarioMin.Size = New System.Drawing.Size(142, 26)
        Me.tInventarioMin.TabIndex = 16
        Me.tInventarioMin.Tag = "Inventario Mínimo"
        Me.tInventarioMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 18)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Inventario Mínimo"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TPExtras
        '
        Me.TPExtras.Controls.Add(Me.tDescripcion)
        Me.TPExtras.Controls.Add(Me.Label2)
        Me.TPExtras.Controls.Add(Me.ckActivo)
        Me.TPExtras.Location = New System.Drawing.Point(4, 27)
        Me.TPExtras.Name = "TPExtras"
        Me.TPExtras.Padding = New System.Windows.Forms.Padding(3)
        Me.TPExtras.Size = New System.Drawing.Size(1223, 134)
        Me.TPExtras.TabIndex = 0
        Me.TPExtras.Text = "Datos Adicionales"
        Me.TPExtras.UseVisualStyleBackColor = True
        '
        'tDescripcion
        '
        Me.tDescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.tDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescripcion.Location = New System.Drawing.Point(101, 9)
        Me.tDescripcion.Multiline = True
        Me.tDescripcion.Name = "tDescripcion"
        Me.tDescripcion.Size = New System.Drawing.Size(997, 81)
        Me.tDescripcion.TabIndex = 1
        Me.tDescripcion.Tag = "Marca"
        Me.tDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 11)
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
        Me.ckActivo.Location = New System.Drawing.Point(31, 96)
        Me.ckActivo.Name = "ckActivo"
        Me.ckActivo.Size = New System.Drawing.Size(81, 24)
        Me.ckActivo.TabIndex = 2
        Me.ckActivo.TabStop = False
        Me.ckActivo.Text = "Activo"
        Me.ckActivo.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 181)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1240, 378)
        Me.Panel2.TabIndex = 1
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView.MultiSelect = False
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.Size = New System.Drawing.Size(1240, 378)
        Me.DataGridView.TabIndex = 5
        Me.DataGridView.Tag = "Grid"
        '
        'FProductoTerminado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1246, 603)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.Name = "FProductoTerminado"
        Me.Text = "Catálogo de Productos"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TSDownDirectAcces.ResumeLayout(False)
        Me.TSDownDirectAcces.PerformLayout()
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator.ResumeLayout(False)
        Me.BindingNavigator.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TPDetalle.ResumeLayout(False)
        Me.TPDetalle.PerformLayout()
        Me.TPInventario.ResumeLayout(False)
        Me.TPInventario.PerformLayout()
        Me.TPExtras.ResumeLayout(False)
        Me.TPExtras.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BWorkerGetData As System.ComponentModel.BackgroundWorker
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TSDownDirectAcces As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBBom As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBEspecificaciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBAdicionales As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TPDetalle As System.Windows.Forms.TabPage
    Friend WithEvents tCodigoBarras As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbTipoMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tClaveId As System.Windows.Forms.TextBox
    Friend WithEvents tNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TPExtras As System.Windows.Forms.TabPage
    Friend WithEvents tDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ckActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents cbPresentacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tPrecioCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tPrecioVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tUtilidad As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TPInventario As System.Windows.Forms.TabPage
    Friend WithEvents tInventarioMax As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tInventarioMin As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tReorden As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    '  Friend WithEvents DbNavigationBar1 As DBNavigation.DbNavigationBar
End Class
