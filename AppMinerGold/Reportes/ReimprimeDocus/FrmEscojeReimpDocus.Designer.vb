<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEscojeReimpDocus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEscojeReimpDocus))
        Me.TxtCedImp = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnPagare = New System.Windows.Forms.Button()
        Me.BtnLiquidacion = New System.Windows.Forms.Button()
        Me.BtnCertificacion = New System.Windows.Forms.Button()
        Me.BtnActa = New System.Windows.Forms.Button()
        Me.BtnContrato = New System.Windows.Forms.Button()
        Me.BtnSoporte = New System.Windows.Forms.Button()
        Me.BtnReimpVincula = New System.Windows.Forms.Button()
        Me.BtnDeclara = New System.Windows.Forms.Button()
        Me.BtnEgreso = New System.Windows.Forms.Button()
        Me.BtnEquivalente = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCedImp
        '
        Me.TxtCedImp.Enabled = False
        Me.TxtCedImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCedImp.Location = New System.Drawing.Point(11, 45)
        Me.TxtCedImp.Name = "TxtCedImp"
        Me.TxtCedImp.Size = New System.Drawing.Size(101, 23)
        Me.TxtCedImp.TabIndex = 106
        Me.TxtCedImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCedImp.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnPagare)
        Me.Panel2.Controls.Add(Me.BtnLiquidacion)
        Me.Panel2.Controls.Add(Me.BtnCertificacion)
        Me.Panel2.Controls.Add(Me.BtnActa)
        Me.Panel2.Controls.Add(Me.BtnContrato)
        Me.Panel2.Controls.Add(Me.BtnSoporte)
        Me.Panel2.Controls.Add(Me.BtnReimpVincula)
        Me.Panel2.Controls.Add(Me.BtnDeclara)
        Me.Panel2.Location = New System.Drawing.Point(14, 102)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(448, 208)
        Me.Panel2.TabIndex = 105
        '
        'BtnPagare
        '
        Me.BtnPagare.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPagare.Image = CType(resources.GetObject("BtnPagare.Image"), System.Drawing.Image)
        Me.BtnPagare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPagare.Location = New System.Drawing.Point(228, 101)
        Me.BtnPagare.Name = "BtnPagare"
        Me.BtnPagare.Size = New System.Drawing.Size(200, 40)
        Me.BtnPagare.TabIndex = 7
        Me.BtnPagare.Text = "           7 - Pagare"
        Me.BtnPagare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPagare.UseVisualStyleBackColor = True
        '
        'BtnLiquidacion
        '
        Me.BtnLiquidacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLiquidacion.Image = CType(resources.GetObject("BtnLiquidacion.Image"), System.Drawing.Image)
        Me.BtnLiquidacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLiquidacion.Location = New System.Drawing.Point(228, 55)
        Me.BtnLiquidacion.Name = "BtnLiquidacion"
        Me.BtnLiquidacion.Size = New System.Drawing.Size(200, 40)
        Me.BtnLiquidacion.TabIndex = 6
        Me.BtnLiquidacion.Text = "           6 - Liquidación"
        Me.BtnLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLiquidacion.UseVisualStyleBackColor = True
        '
        'BtnCertificacion
        '
        Me.BtnCertificacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCertificacion.Image = CType(resources.GetObject("BtnCertificacion.Image"), System.Drawing.Image)
        Me.BtnCertificacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCertificacion.Location = New System.Drawing.Point(228, 9)
        Me.BtnCertificacion.Name = "BtnCertificacion"
        Me.BtnCertificacion.Size = New System.Drawing.Size(200, 40)
        Me.BtnCertificacion.TabIndex = 5
        Me.BtnCertificacion.Text = "           5 - Certificación"
        Me.BtnCertificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCertificacion.UseVisualStyleBackColor = True
        '
        'BtnActa
        '
        Me.BtnActa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnActa.Image = CType(resources.GetObject("BtnActa.Image"), System.Drawing.Image)
        Me.BtnActa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnActa.Location = New System.Drawing.Point(17, 147)
        Me.BtnActa.Name = "BtnActa"
        Me.BtnActa.Size = New System.Drawing.Size(200, 40)
        Me.BtnActa.TabIndex = 4
        Me.BtnActa.Text = "           4 - Acta de Entrega"
        Me.BtnActa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnActa.UseVisualStyleBackColor = True
        '
        'BtnContrato
        '
        Me.BtnContrato.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnContrato.Image = CType(resources.GetObject("BtnContrato.Image"), System.Drawing.Image)
        Me.BtnContrato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnContrato.Location = New System.Drawing.Point(17, 101)
        Me.BtnContrato.Name = "BtnContrato"
        Me.BtnContrato.Size = New System.Drawing.Size(200, 40)
        Me.BtnContrato.TabIndex = 3
        Me.BtnContrato.Text = "           3 - Contrato"
        Me.BtnContrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnContrato.UseVisualStyleBackColor = True
        '
        'BtnSoporte
        '
        Me.BtnSoporte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSoporte.Image = CType(resources.GetObject("BtnSoporte.Image"), System.Drawing.Image)
        Me.BtnSoporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSoporte.Location = New System.Drawing.Point(228, 147)
        Me.BtnSoporte.Name = "BtnSoporte"
        Me.BtnSoporte.Size = New System.Drawing.Size(200, 40)
        Me.BtnSoporte.TabIndex = 8
        Me.BtnSoporte.Text = "8 - Todos los Reportes"
        Me.BtnSoporte.UseVisualStyleBackColor = True
        '
        'BtnReimpVincula
        '
        Me.BtnReimpVincula.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpVincula.Image = CType(resources.GetObject("BtnReimpVincula.Image"), System.Drawing.Image)
        Me.BtnReimpVincula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReimpVincula.Location = New System.Drawing.Point(17, 55)
        Me.BtnReimpVincula.Name = "BtnReimpVincula"
        Me.BtnReimpVincula.Size = New System.Drawing.Size(200, 40)
        Me.BtnReimpVincula.TabIndex = 2
        Me.BtnReimpVincula.Text = "      2 - Formulario de Vinculación"
        Me.BtnReimpVincula.UseVisualStyleBackColor = True
        '
        'BtnDeclara
        '
        Me.BtnDeclara.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDeclara.Image = CType(resources.GetObject("BtnDeclara.Image"), System.Drawing.Image)
        Me.BtnDeclara.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDeclara.Location = New System.Drawing.Point(17, 9)
        Me.BtnDeclara.Name = "BtnDeclara"
        Me.BtnDeclara.Size = New System.Drawing.Size(200, 40)
        Me.BtnDeclara.TabIndex = 1
        Me.BtnDeclara.Text = "           1 - Declaración de Producción"
        Me.BtnDeclara.UseVisualStyleBackColor = True
        '
        'BtnEgreso
        '
        Me.BtnEgreso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEgreso.Image = CType(resources.GetObject("BtnEgreso.Image"), System.Drawing.Image)
        Me.BtnEgreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEgreso.Location = New System.Drawing.Point(341, 45)
        Me.BtnEgreso.Name = "BtnEgreso"
        Me.BtnEgreso.Size = New System.Drawing.Size(58, 40)
        Me.BtnEgreso.TabIndex = 9
        Me.BtnEgreso.Text = "4 - Documento Egreso"
        Me.BtnEgreso.UseVisualStyleBackColor = True
        Me.BtnEgreso.Visible = False
        '
        'BtnEquivalente
        '
        Me.BtnEquivalente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEquivalente.Image = CType(resources.GetObject("BtnEquivalente.Image"), System.Drawing.Image)
        Me.BtnEquivalente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEquivalente.Location = New System.Drawing.Point(405, 45)
        Me.BtnEquivalente.Name = "BtnEquivalente"
        Me.BtnEquivalente.Size = New System.Drawing.Size(58, 40)
        Me.BtnEquivalente.TabIndex = 10
        Me.BtnEquivalente.Text = "       3 - Documento Equivalente"
        Me.BtnEquivalente.UseVisualStyleBackColor = True
        Me.BtnEquivalente.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(484, 40)
        Me.Panel1.TabIndex = 104
        '
        'BtnX
        '
        Me.BtnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.BackgroundImage = CType(resources.GetObject("BtnX.BackgroundImage"), System.Drawing.Image)
        Me.BtnX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Location = New System.Drawing.Point(445, 2)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 82
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(146, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SELECCIONE OPCIÓN REIMPRIME"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.TxtCedImp)
        Me.Panel3.Controls.Add(Me.BtnEquivalente)
        Me.Panel3.Controls.Add(Me.BtnEgreso)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(484, 330)
        Me.Panel3.TabIndex = 107
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(227, 54)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(45, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 107
        Me.PictureBox1.TabStop = False
        '
        'FrmEscojeReimpDocus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(484, 330)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(484, 330)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(484, 330)
        Me.Name = "FrmEscojeReimpDocus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Reimprime Documentos"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TxtCedImp As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnEgreso As Button
    Friend WithEvents BtnEquivalente As Button
    Friend WithEvents BtnDeclara As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnReimpVincula As Button
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnSoporte As Button
    Friend WithEvents BtnContrato As Button
    Friend WithEvents BtnActa As Button
    Friend WithEvents BtnCertificacion As Button
    Friend WithEvents BtnPagare As Button
    Friend WithEvents BtnLiquidacion As Button
End Class
