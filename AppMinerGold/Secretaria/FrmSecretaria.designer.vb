<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSecretaria
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSecretaria))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnRegistro = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnClientesS = New System.Windows.Forms.Button()
        Me.BtnClienteAct = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 40)
        Me.Panel1.TabIndex = 2
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(449, 3)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 44
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(149, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "MODULO DE INGRESOS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnRegistro)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.BtnClientesS)
        Me.Panel2.Location = New System.Drawing.Point(23, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(437, 271)
        Me.Panel2.TabIndex = 3
        '
        'BtnRegistro
        '
        Me.BtnRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRegistro.Image = CType(resources.GetObject("BtnRegistro.Image"), System.Drawing.Image)
        Me.BtnRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRegistro.Location = New System.Drawing.Point(216, 35)
        Me.BtnRegistro.Name = "BtnRegistro"
        Me.BtnRegistro.Size = New System.Drawing.Size(196, 80)
        Me.BtnRegistro.TabIndex = 1
        Me.BtnRegistro.Text = "     &Registro Fotografico"
        Me.BtnRegistro.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(22, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(177, 190)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'BtnClientesS
        '
        Me.BtnClientesS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClientesS.Image = CType(resources.GetObject("BtnClientesS.Image"), System.Drawing.Image)
        Me.BtnClientesS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClientesS.Location = New System.Drawing.Point(216, 145)
        Me.BtnClientesS.Name = "BtnClientesS"
        Me.BtnClientesS.Size = New System.Drawing.Size(196, 80)
        Me.BtnClientesS.TabIndex = 2
        Me.BtnClientesS.Text = "&Ingreso de Proveedores"
        Me.BtnClientesS.UseVisualStyleBackColor = True
        '
        'BtnClienteAct
        '
        Me.BtnClienteAct.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClienteAct.Image = CType(resources.GetObject("BtnClienteAct.Image"), System.Drawing.Image)
        Me.BtnClienteAct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClienteAct.Location = New System.Drawing.Point(3, 368)
        Me.BtnClienteAct.Name = "BtnClienteAct"
        Me.BtnClienteAct.Size = New System.Drawing.Size(106, 22)
        Me.BtnClienteAct.TabIndex = 3
        Me.BtnClienteAct.Text = "     &Actividad Económica del Proveedor"
        Me.BtnClienteAct.UseVisualStyleBackColor = True
        Me.BtnClienteAct.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnClienteAct)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(488, 403)
        Me.Panel3.TabIndex = 9
        '
        'FrmSecretaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(488, 403)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(488, 403)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(488, 403)
        Me.Name = "FrmSecretaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Modulo de Secretaria"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnRegistro As System.Windows.Forms.Button
    Friend WithEvents BtnClientesS As System.Windows.Forms.Button
    Friend WithEvents BtnClienteAct As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnX As Button
End Class
