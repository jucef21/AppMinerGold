<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTomaFoto
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTomaFoto))
        Me.Apagar = New System.Windows.Forms.Button()
        Me.GUARDAR = New System.Windows.Forms.Button()
        Me.PCAPTURA = New System.Windows.Forms.PictureBox()
        Me.FORMATO = New System.Windows.Forms.Button()
        Me.CAPTURAR = New System.Windows.Forms.Button()
        Me.INICIAR = New System.Windows.Forms.Button()
        Me.VISOR = New System.Windows.Forms.PictureBox()
        Me.Reloj = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        CType(Me.PCAPTURA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VISOR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Apagar
        '
        Me.Apagar.Location = New System.Drawing.Point(211, 368)
        Me.Apagar.Name = "Apagar"
        Me.Apagar.Size = New System.Drawing.Size(114, 40)
        Me.Apagar.TabIndex = 5
        Me.Apagar.Text = "Cerrar"
        Me.Apagar.UseVisualStyleBackColor = True
        '
        'GUARDAR
        '
        Me.GUARDAR.Location = New System.Drawing.Point(415, 305)
        Me.GUARDAR.Name = "GUARDAR"
        Me.GUARDAR.Size = New System.Drawing.Size(114, 40)
        Me.GUARDAR.TabIndex = 4
        Me.GUARDAR.Text = "Guardar"
        Me.GUARDAR.UseVisualStyleBackColor = True
        '
        'PCAPTURA
        '
        Me.PCAPTURA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PCAPTURA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PCAPTURA.Location = New System.Drawing.Point(280, 42)
        Me.PCAPTURA.Name = "PCAPTURA"
        Me.PCAPTURA.Size = New System.Drawing.Size(250, 250)
        Me.PCAPTURA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PCAPTURA.TabIndex = 79
        Me.PCAPTURA.TabStop = False
        '
        'FORMATO
        '
        Me.FORMATO.Location = New System.Drawing.Point(148, 305)
        Me.FORMATO.Name = "FORMATO"
        Me.FORMATO.Size = New System.Drawing.Size(114, 40)
        Me.FORMATO.TabIndex = 2
        Me.FORMATO.Text = "Formato"
        Me.FORMATO.UseVisualStyleBackColor = True
        '
        'CAPTURAR
        '
        Me.CAPTURAR.Location = New System.Drawing.Point(279, 305)
        Me.CAPTURAR.Name = "CAPTURAR"
        Me.CAPTURAR.Size = New System.Drawing.Size(114, 40)
        Me.CAPTURAR.TabIndex = 3
        Me.CAPTURAR.Text = "Capturar"
        Me.CAPTURAR.UseVisualStyleBackColor = True
        '
        'INICIAR
        '
        Me.INICIAR.Location = New System.Drawing.Point(12, 305)
        Me.INICIAR.Name = "INICIAR"
        Me.INICIAR.Size = New System.Drawing.Size(114, 40)
        Me.INICIAR.TabIndex = 1
        Me.INICIAR.Text = "Iniciar"
        Me.INICIAR.UseVisualStyleBackColor = True
        '
        'VISOR
        '
        Me.VISOR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VISOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VISOR.Location = New System.Drawing.Point(13, 42)
        Me.VISOR.Name = "VISOR"
        Me.VISOR.Size = New System.Drawing.Size(250, 250)
        Me.VISOR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.VISOR.TabIndex = 71
        Me.VISOR.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 30)
        Me.Panel1.TabIndex = 192
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(196, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "CAPTURA DE IMAGEN"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstDevices
        '
        Me.lstDevices.Enabled = False
        Me.lstDevices.FormattingEnabled = True
        Me.lstDevices.Location = New System.Drawing.Point(13, 368)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(192, 30)
        Me.lstDevices.TabIndex = 193
        Me.lstDevices.Visible = False
        '
        'FrmTomaFoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(550, 417)
        Me.Controls.Add(Me.lstDevices)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Apagar)
        Me.Controls.Add(Me.GUARDAR)
        Me.Controls.Add(Me.PCAPTURA)
        Me.Controls.Add(Me.FORMATO)
        Me.Controls.Add(Me.CAPTURAR)
        Me.Controls.Add(Me.INICIAR)
        Me.Controls.Add(Me.VISOR)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTomaFoto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toma Foto"
        CType(Me.PCAPTURA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VISOR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Apagar As Button
    Friend WithEvents GUARDAR As Button
    Friend WithEvents PCAPTURA As PictureBox
    Friend WithEvents FORMATO As Button
    Friend WithEvents CAPTURAR As Button
    Friend WithEvents INICIAR As Button
    Friend WithEvents VISOR As PictureBox
    Friend WithEvents Reloj As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents lstDevices As ListBox
End Class
