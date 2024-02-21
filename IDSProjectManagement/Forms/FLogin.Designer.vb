<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FLogin
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
        Me.BWorkerAuthenticate = New System.ComponentModel.BackgroundWorker()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblOrganisation = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.cbWorkCenter = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnEnter
        '
        Me.btnEnter.Location = New System.Drawing.Point(331, 192)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(75, 23)
        Me.btnEnter.TabIndex = 0
        Me.btnEnter.Text = "Entrar"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(276, 79)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(43, 13)
        Me.lblUserName.TabIndex = 1
        Me.lblUserName.Text = "Usuario"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(266, 114)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(61, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Contraseña"
        '
        'lblOrganisation
        '
        Me.lblOrganisation.AutoSize = True
        Me.lblOrganisation.Location = New System.Drawing.Point(276, 156)
        Me.lblOrganisation.Name = "lblOrganisation"
        Me.lblOrganisation.Size = New System.Drawing.Size(48, 13)
        Me.lblOrganisation.TabIndex = 3
        Me.lblOrganisation.Text = "Empresa"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(328, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Label4"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(432, 192)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(331, 79)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(176, 20)
        Me.TextBox1.TabIndex = 6
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(331, 114)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(176, 20)
        Me.TextBox2.TabIndex = 7
        '
        'cbWorkCenter
        '
        Me.cbWorkCenter.FormattingEnabled = True
        Me.cbWorkCenter.Location = New System.Drawing.Point(331, 148)
        Me.cbWorkCenter.Name = "cbWorkCenter"
        Me.cbWorkCenter.Size = New System.Drawing.Size(176, 21)
        Me.cbWorkCenter.TabIndex = 8
        '
        'FLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.cbWorkCenter)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblOrganisation)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.btnEnter)
        Me.Name = "FLogin"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BWorkerAuthenticate As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnEnter As Button
    Friend WithEvents lblUserName As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblOrganisation As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents cbWorkCenter As ComboBox
End Class
