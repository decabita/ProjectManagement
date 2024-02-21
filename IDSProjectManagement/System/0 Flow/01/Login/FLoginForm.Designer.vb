<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class FLoginForm
    Inherits FCatalogFormTemplate

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
        Me.BWorkerAuthenticate = New System.ComponentModel.BackgroundWorker()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.lbCapsLockWarning = New System.Windows.Forms.Label()
        Me.cbWorkCenter = New System.Windows.Forms.ComboBox()
        Me.PlantaLabel = New System.Windows.Forms.Label()
        Me.bLogin = New System.Windows.Forms.Button()
        Me.tPassword = New System.Windows.Forms.TextBox()
        Me.tUsuarioId = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BWorkerAuthenticate
        '
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Cancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.Location = New System.Drawing.Point(541, 214)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(86, 38)
        Me.Cancel.TabIndex = 319
        Me.Cancel.Text = "&Cancelar"
        '
        'lbCapsLockWarning
        '
        Me.lbCapsLockWarning.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCapsLockWarning.ForeColor = System.Drawing.Color.Red
        Me.lbCapsLockWarning.Image = Global.IDSProjectManagement.My.Resources.Resources.warning
        Me.lbCapsLockWarning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbCapsLockWarning.Location = New System.Drawing.Point(443, 271)
        Me.lbCapsLockWarning.Name = "lbCapsLockWarning"
        Me.lbCapsLockWarning.Size = New System.Drawing.Size(187, 30)
        Me.lbCapsLockWarning.TabIndex = 24
        Me.lbCapsLockWarning.Text = "Bloq Mayúsculas Activado"
        Me.lbCapsLockWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbWorkCenter
        '
        Me.cbWorkCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbWorkCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbWorkCenter.FormattingEnabled = True
        Me.cbWorkCenter.Location = New System.Drawing.Point(360, 163)
        Me.cbWorkCenter.Name = "cbWorkCenter"
        Me.cbWorkCenter.Size = New System.Drawing.Size(268, 25)
        Me.cbWorkCenter.TabIndex = 29
        '
        'PlantaLabel
        '
        Me.PlantaLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlantaLabel.Location = New System.Drawing.Point(264, 162)
        Me.PlantaLabel.Name = "PlantaLabel"
        Me.PlantaLabel.Size = New System.Drawing.Size(83, 23)
        Me.PlantaLabel.TabIndex = 32
        Me.PlantaLabel.Text = "Empresa"
        Me.PlantaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bLogin
        '
        Me.bLogin.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bLogin.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLogin.Location = New System.Drawing.Point(446, 214)
        Me.bLogin.Name = "bLogin"
        Me.bLogin.Size = New System.Drawing.Size(84, 38)
        Me.bLogin.TabIndex = 30
        Me.bLogin.Text = "&Entrar"
        '
        'tPassword
        '
        Me.tPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPassword.Location = New System.Drawing.Point(360, 116)
        Me.tPassword.Name = "tPassword"
        Me.tPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tPassword.Size = New System.Drawing.Size(268, 24)
        Me.tPassword.TabIndex = 27
        Me.tPassword.Tag = "Contraseña"
        Me.tPassword.Text = "admin"
        '
        'tUsuarioId
        '
        Me.tUsuarioId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tUsuarioId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tUsuarioId.Location = New System.Drawing.Point(360, 72)
        Me.tUsuarioId.Name = "tUsuarioId"
        Me.tUsuarioId.Size = New System.Drawing.Size(268, 24)
        Me.tUsuarioId.TabIndex = 25
        Me.tUsuarioId.Tag = "Usuario"
        Me.tUsuarioId.Text = "admin"
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLabel.Location = New System.Drawing.Point(254, 115)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(93, 23)
        Me.PasswordLabel.TabIndex = 28
        Me.PasswordLabel.Text = "Contraseña"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.Location = New System.Drawing.Point(241, 72)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(107, 23)
        Me.UsernameLabel.TabIndex = 26
        Me.UsernameLabel.Text = "Usuario"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(570, 358)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 38)
        Me.Button1.TabIndex = 320
        Me.Button1.Text = "&Entrar"
        Me.Button1.Visible = False
        '
        'FLoginForm
        '
        Me.AcceptButton = Me.bLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(658, 403)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.lbCapsLockWarning)
        Me.Controls.Add(Me.cbWorkCenter)
        Me.Controls.Add(Me.PlantaLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.bLogin)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.tPassword)
        Me.Controls.Add(Me.tUsuarioId)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FLoginForm"
        Me.ShowIcon = True
        Me.ShowInTaskbar = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acceso"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BWorkerAuthenticate As System.ComponentModel.BackgroundWorker
    Friend WithEvents cbWorkCenter As System.Windows.Forms.ComboBox
    Friend WithEvents PlantaLabel As System.Windows.Forms.Label
    Friend WithEvents bLogin As System.Windows.Forms.Button
    Friend WithEvents tPassword As System.Windows.Forms.TextBox
    Friend WithEvents tUsuarioId As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents lbCapsLockWarning As System.Windows.Forms.Label
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Button1 As Button
End Class
