<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MDIMainContainer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIMainContainer))
        Me.MDIStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.MDIWorkCenter = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MDIUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MDIEnvironment = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MDIFormState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MDICurrentForm = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TLPStatusStrip = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStripMDI = New System.Windows.Forms.ToolStrip()
        Me.TSBQuery = New System.Windows.Forms.ToolStripButton()
        Me.TSBNew = New System.Windows.Forms.ToolStripButton()
        Me.TSBEdit = New System.Windows.Forms.ToolStripButton()
        Me.TSBSave = New System.Windows.Forms.ToolStripButton()
        Me.TSBDelete = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBFind = New System.Windows.Forms.ToolStripButton()
        Me.TSBExecFind = New System.Windows.Forms.ToolStripButton()
        Me.TSBDirectAccess = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBExit = New System.Windows.Forms.ToolStripButton()
        Me.TLPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeAtlasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MDIStatusStrip.SuspendLayout()
        Me.TLPStatusStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStripMDI.SuspendLayout()
        Me.TLPanel1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MDIStatusStrip
        '
        Me.MDIStatusStrip.AutoSize = False
        Me.MDIStatusStrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MDIStatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MDIStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MDIWorkCenter, Me.MDIUser, Me.MDIEnvironment, Me.MDIFormState, Me.MDICurrentForm})
        Me.MDIStatusStrip.Location = New System.Drawing.Point(0, 0)
        Me.MDIStatusStrip.Name = "MDIStatusStrip"
        Me.MDIStatusStrip.Size = New System.Drawing.Size(1083, 26)
        Me.MDIStatusStrip.SizingGrip = False
        Me.MDIStatusStrip.TabIndex = 8
        Me.MDIStatusStrip.Text = "StatusStrip1"
        '
        'MDIWorkCenter
        '
        Me.MDIWorkCenter.AutoSize = False
        Me.MDIWorkCenter.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.MDIWorkCenter.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.MDIWorkCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.MDIWorkCenter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MDIWorkCenter.Name = "MDIWorkCenter"
        Me.MDIWorkCenter.Size = New System.Drawing.Size(100, 20)
        Me.MDIWorkCenter.Text = "Wok Center"
        Me.MDIWorkCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MDIUser
        '
        Me.MDIUser.AutoSize = False
        Me.MDIUser.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.MDIUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.MDIUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.MDIUser.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MDIUser.Name = "MDIUser"
        Me.MDIUser.Size = New System.Drawing.Size(100, 20)
        Me.MDIUser.Text = "User"
        '
        'MDIEnvironment
        '
        Me.MDIEnvironment.AutoSize = False
        Me.MDIEnvironment.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.MDIEnvironment.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.MDIEnvironment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MDIEnvironment.Name = "MDIEnvironment"
        Me.MDIEnvironment.Size = New System.Drawing.Size(100, 20)
        Me.MDIEnvironment.Text = "Environment"
        '
        'MDIFormState
        '
        Me.MDIFormState.AutoSize = False
        Me.MDIFormState.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.MDIFormState.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.MDIFormState.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MDIFormState.Name = "MDIFormState"
        Me.MDIFormState.Size = New System.Drawing.Size(100, 20)
        Me.MDIFormState.Text = "Form State"
        '
        'MDICurrentForm
        '
        Me.MDICurrentForm.AutoSize = False
        Me.MDICurrentForm.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.MDICurrentForm.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.MDICurrentForm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MDICurrentForm.Name = "MDICurrentForm"
        Me.MDICurrentForm.Size = New System.Drawing.Size(300, 20)
        Me.MDICurrentForm.Text = "Current Form"
        '
        'TLPStatusStrip
        '
        Me.TLPStatusStrip.ColumnCount = 2
        Me.TLPStatusStrip.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 97.94817!))
        Me.TLPStatusStrip.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.051836!))
        Me.TLPStatusStrip.Controls.Add(Me.MDIStatusStrip, 0, 0)
        Me.TLPStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TLPStatusStrip.Location = New System.Drawing.Point(0, 647)
        Me.TLPStatusStrip.Name = "TLPStatusStrip"
        Me.TLPStatusStrip.RowCount = 1
        Me.TLPStatusStrip.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TLPStatusStrip.Size = New System.Drawing.Size(1106, 26)
        Me.TLPStatusStrip.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.Controls.Add(Me.ToolStripMDI)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1106, 28)
        Me.Panel1.TabIndex = 18
        '
        'ToolStripMDI
        '
        Me.ToolStripMDI.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripMDI.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripMDI.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBQuery, Me.TSBNew, Me.TSBEdit, Me.TSBSave, Me.TSBDelete, Me.TSBCancel, Me.ToolStripSeparator6, Me.TSBFind, Me.TSBExecFind, Me.TSBDirectAccess, Me.ToolStripSeparator1, Me.TSBExportToExcel, Me.ToolStripSeparator8, Me.TSBExit})
        Me.ToolStripMDI.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMDI.Name = "ToolStripMDI"
        Me.ToolStripMDI.Size = New System.Drawing.Size(1128, 27)
        Me.ToolStripMDI.TabIndex = 0
        Me.ToolStripMDI.TabStop = True
        Me.ToolStripMDI.Text = "ToolStrip1"
        '
        'TSBQuery
        '
        Me.TSBQuery.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBQuery.Image = Global.IDPProjectManagement.My.Resources.Resources.SearchCommand
        Me.TSBQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBQuery.Name = "TSBQuery"
        Me.TSBQuery.Size = New System.Drawing.Size(87, 24)
        Me.TSBQuery.Text = "&Consulta"
        Me.TSBQuery.ToolTipText = "Consulta - F7"
        '
        'TSBNew
        '
        Me.TSBNew.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBNew.Image = Global.IDPProjectManagement.My.Resources.Resources.NewCommand
        Me.TSBNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNew.Name = "TSBNew"
        Me.TSBNew.Size = New System.Drawing.Size(74, 24)
        Me.TSBNew.Text = "Nue&vo"
        Me.TSBNew.ToolTipText = "Nuevo - F5"
        '
        'TSBEdit
        '
        Me.TSBEdit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBEdit.Image = Global.IDPProjectManagement.My.Resources.Resources.EditCommand
        Me.TSBEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBEdit.Name = "TSBEdit"
        Me.TSBEdit.Size = New System.Drawing.Size(68, 24)
        Me.TSBEdit.Text = "&Editar"
        Me.TSBEdit.ToolTipText = "Editar - F6"
        '
        'TSBSave
        '
        Me.TSBSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBSave.Image = Global.IDPProjectManagement.My.Resources.Resources.SaveCommand
        Me.TSBSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBSave.Name = "TSBSave"
        Me.TSBSave.Size = New System.Drawing.Size(84, 24)
        Me.TSBSave.Text = "&Guardar"
        Me.TSBSave.ToolTipText = "Guardar - F8"
        '
        'TSBDelete
        '
        Me.TSBDelete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBDelete.Image = Global.IDPProjectManagement.My.Resources.Resources.Inactive
        Me.TSBDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBDelete.Name = "TSBDelete"
        Me.TSBDelete.Size = New System.Drawing.Size(100, 24)
        Me.TSBDelete.Text = "Desac&tivar"
        Me.TSBDelete.ToolTipText = "Desactivar - F2"
        Me.TSBDelete.Visible = False
        '
        'TSBCancel
        '
        Me.TSBCancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBCancel.Image = CType(resources.GetObject("TSBCancel.Image"), System.Drawing.Image)
        Me.TSBCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBCancel.Name = "TSBCancel"
        Me.TSBCancel.Size = New System.Drawing.Size(87, 24)
        Me.TSBCancel.Text = "Ca&ncelar"
        Me.TSBCancel.ToolTipText = "Cancelar - F12"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 27)
        '
        'TSBFind
        '
        Me.TSBFind.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TSBFind.Image = Global.IDPProjectManagement.My.Resources.Resources.FilterCommand
        Me.TSBFind.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TSBFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBFind.Name = "TSBFind"
        Me.TSBFind.Size = New System.Drawing.Size(76, 24)
        Me.TSBFind.Text = "Buscar"
        Me.TSBFind.Visible = False
        '
        'TSBExecFind
        '
        Me.TSBExecFind.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TSBExecFind.Image = Global.IDPProjectManagement.My.Resources.Resources.FilterExecCommand
        Me.TSBExecFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBExecFind.Name = "TSBExecFind"
        Me.TSBExecFind.Size = New System.Drawing.Size(154, 24)
        Me.TSBExecFind.Text = "Ejecutar Busqueda"
        Me.TSBExecFind.Visible = False
        '
        'TSBDirectAccess
        '
        Me.TSBDirectAccess.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBDirectAccess.Image = Global.IDPProjectManagement.My.Resources.Resources.DirectAccessCommand
        Me.TSBDirectAccess.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TSBDirectAccess.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBDirectAccess.Name = "TSBDirectAccess"
        Me.TSBDirectAccess.Size = New System.Drawing.Size(133, 24)
        Me.TSBDirectAccess.Text = "A&cceso Directo "
        Me.TSBDirectAccess.ToolTipText = "Acceso Directo - F9"
        Me.TSBDirectAccess.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'TSBExportToExcel
        '
        Me.TSBExportToExcel.Enabled = False
        Me.TSBExportToExcel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TSBExportToExcel.Image = Global.IDPProjectManagement.My.Resources.Resources.ExcelExport
        Me.TSBExportToExcel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TSBExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBExportToExcel.Name = "TSBExportToExcel"
        Me.TSBExportToExcel.Size = New System.Drawing.Size(138, 24)
        Me.TSBExportToExcel.Text = "E&xportar a Excel"
        Me.TSBExportToExcel.Visible = False
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 27)
        '
        'TSBExit
        '
        Me.TSBExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBExit.Image = Global.IDPProjectManagement.My.Resources.Resources.ExitCommand
        Me.TSBExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBExit.Name = "TSBExit"
        Me.TSBExit.Size = New System.Drawing.Size(57, 24)
        Me.TSBExit.Text = "&Salir"
        Me.TSBExit.ToolTipText = "Salir - F3"
        '
        'TLPanel1
        '
        Me.TLPanel1.BackColor = System.Drawing.Color.GhostWhite
        Me.TLPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TLPanel1.ColumnCount = 1
        Me.TLPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLPanel1.Controls.Add(Me.MenuStrip2, 0, 0)
        Me.TLPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TLPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TLPanel1.Name = "TLPanel1"
        Me.TLPanel1.RowCount = 1
        Me.TLPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPanel1.Size = New System.Drawing.Size(1106, 30)
        Me.TLPanel1.TabIndex = 17
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.MenuStrip2.Location = New System.Drawing.Point(2, 2)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(166, 26)
        Me.MenuStrip2.TabIndex = 11
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(93, 22)
        Me.ToolStripMenuItem1.Text = "&Archivo"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.IDPProjectManagement.My.Resources.Resources.ExitCommand
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(121, 26)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcercaDeAtlasToolStripMenuItem})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripMenuItem2.Text = "Ayuda"
        '
        'AcercaDeAtlasToolStripMenuItem
        '
        Me.AcercaDeAtlasToolStripMenuItem.Name = "AcercaDeAtlasToolStripMenuItem"
        Me.AcercaDeAtlasToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.AcercaDeAtlasToolStripMenuItem.Text = "Acerca"
        '
        'MDIMainContainer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1106, 673)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TLPanel1)
        Me.Controls.Add(Me.TLPStatusStrip)
        Me.DoubleBuffered = True
        Me.IsMdiContainer = True
        Me.Name = "MDIMainContainer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MDIStatusStrip.ResumeLayout(False)
        Me.MDIStatusStrip.PerformLayout()
        Me.TLPStatusStrip.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStripMDI.ResumeLayout(False)
        Me.ToolStripMDI.PerformLayout()
        Me.TLPanel1.ResumeLayout(False)
        Me.TLPanel1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MDIStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MDIWorkCenter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MDIUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MDIEnvironment As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MDIFormState As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MDICurrentForm As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TLPStatusStrip As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStripMDI As ToolStrip
    Friend WithEvents TSBQuery As ToolStripButton
    Friend WithEvents TSBNew As ToolStripButton
    Friend WithEvents TSBEdit As ToolStripButton
    Friend WithEvents TSBSave As ToolStripButton
    Friend WithEvents TSBDelete As ToolStripButton
    Friend WithEvents TSBCancel As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents TSBFind As ToolStripButton
    Friend WithEvents TSBExecFind As ToolStripButton
    Friend WithEvents TSBDirectAccess As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TSBExportToExcel As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents TSBExit As ToolStripButton
    Friend WithEvents TLPanel1 As TableLayoutPanel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents AcercaDeAtlasToolStripMenuItem As ToolStripMenuItem
End Class
