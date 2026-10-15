<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEscojeImpPlatino
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEscojeImpPlatino))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.TxtConsecu = New System.Windows.Forms.TextBox()
        Me.TxtEmpCiuImp = New System.Windows.Forms.TextBox()
        Me.TxtCedImp = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnPagare = New System.Windows.Forms.Button()
        Me.BtnLiquidacion = New System.Windows.Forms.Button()
        Me.BtnCertifica = New System.Windows.Forms.Button()
        Me.BtnActa = New System.Windows.Forms.Button()
        Me.BtnContrato = New System.Windows.Forms.Button()
        Me.BtnSoporte = New System.Windows.Forms.Button()
        Me.BtnDeclara = New System.Windows.Forms.Button()
        Me.BtnEgreso = New System.Windows.Forms.Button()
        Me.BtnEquivalente = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(45, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(337, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SELECCIONE OPCIÓN DE IMPRESIÓN DE PLATINO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(433, 40)
        Me.Panel1.TabIndex = 104
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(400, 7)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 56
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'TxtConsecu
        '
        Me.TxtConsecu.Enabled = False
        Me.TxtConsecu.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConsecu.Location = New System.Drawing.Point(319, 322)
        Me.TxtConsecu.Name = "TxtConsecu"
        Me.TxtConsecu.Size = New System.Drawing.Size(101, 23)
        Me.TxtConsecu.TabIndex = 104
        Me.TxtConsecu.Visible = False
        '
        'TxtEmpCiuImp
        '
        Me.TxtEmpCiuImp.Enabled = False
        Me.TxtEmpCiuImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmpCiuImp.Location = New System.Drawing.Point(212, 322)
        Me.TxtEmpCiuImp.Name = "TxtEmpCiuImp"
        Me.TxtEmpCiuImp.Size = New System.Drawing.Size(101, 23)
        Me.TxtEmpCiuImp.TabIndex = 103
        Me.TxtEmpCiuImp.Visible = False
        '
        'TxtCedImp
        '
        Me.TxtCedImp.Enabled = False
        Me.TxtCedImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCedImp.Location = New System.Drawing.Point(11, 322)
        Me.TxtCedImp.Name = "TxtCedImp"
        Me.TxtCedImp.Size = New System.Drawing.Size(101, 23)
        Me.TxtCedImp.TabIndex = 102
        Me.TxtCedImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCedImp.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnPagare)
        Me.Panel2.Controls.Add(Me.BtnLiquidacion)
        Me.Panel2.Controls.Add(Me.BtnCertifica)
        Me.Panel2.Controls.Add(Me.BtnActa)
        Me.Panel2.Controls.Add(Me.BtnContrato)
        Me.Panel2.Controls.Add(Me.BtnSoporte)
        Me.Panel2.Controls.Add(Me.BtnDeclara)
        Me.Panel2.Location = New System.Drawing.Point(11, 102)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(409, 215)
        Me.Panel2.TabIndex = 105
        '
        'BtnPagare
        '
        Me.BtnPagare.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPagare.Image = CType(resources.GetObject("BtnPagare.Image"), System.Drawing.Image)
        Me.BtnPagare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPagare.Location = New System.Drawing.Point(207, 61)
        Me.BtnPagare.Name = "BtnPagare"
        Me.BtnPagare.Size = New System.Drawing.Size(193, 40)
        Me.BtnPagare.TabIndex = 12
        Me.BtnPagare.Text = "            6 - Pagare"
        Me.BtnPagare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPagare.UseVisualStyleBackColor = True
        '
        'BtnLiquidacion
        '
        Me.BtnLiquidacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLiquidacion.Image = CType(resources.GetObject("BtnLiquidacion.Image"), System.Drawing.Image)
        Me.BtnLiquidacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLiquidacion.Location = New System.Drawing.Point(207, 11)
        Me.BtnLiquidacion.Name = "BtnLiquidacion"
        Me.BtnLiquidacion.Size = New System.Drawing.Size(193, 40)
        Me.BtnLiquidacion.TabIndex = 11
        Me.BtnLiquidacion.Text = "            5 - Acta de Liquidación"
        Me.BtnLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLiquidacion.UseVisualStyleBackColor = True
        '
        'BtnCertifica
        '
        Me.BtnCertifica.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCertifica.Image = CType(resources.GetObject("BtnCertifica.Image"), System.Drawing.Image)
        Me.BtnCertifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCertifica.Location = New System.Drawing.Point(7, 161)
        Me.BtnCertifica.Name = "BtnCertifica"
        Me.BtnCertifica.Size = New System.Drawing.Size(193, 40)
        Me.BtnCertifica.TabIndex = 10
        Me.BtnCertifica.Text = "           4 - Certificación Tributaria"
        Me.BtnCertifica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCertifica.UseVisualStyleBackColor = True
        '
        'BtnActa
        '
        Me.BtnActa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnActa.Image = CType(resources.GetObject("BtnActa.Image"), System.Drawing.Image)
        Me.BtnActa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnActa.Location = New System.Drawing.Point(7, 111)
        Me.BtnActa.Name = "BtnActa"
        Me.BtnActa.Size = New System.Drawing.Size(193, 40)
        Me.BtnActa.TabIndex = 9
        Me.BtnActa.Text = "           3 - Acta de Entrega"
        Me.BtnActa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnActa.UseVisualStyleBackColor = True
        '
        'BtnContrato
        '
        Me.BtnContrato.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnContrato.Image = CType(resources.GetObject("BtnContrato.Image"), System.Drawing.Image)
        Me.BtnContrato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnContrato.Location = New System.Drawing.Point(7, 61)
        Me.BtnContrato.Name = "BtnContrato"
        Me.BtnContrato.Size = New System.Drawing.Size(193, 40)
        Me.BtnContrato.TabIndex = 8
        Me.BtnContrato.Text = "           2 - Contrato"
        Me.BtnContrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnContrato.UseVisualStyleBackColor = True
        '
        'BtnSoporte
        '
        Me.BtnSoporte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSoporte.Image = CType(resources.GetObject("BtnSoporte.Image"), System.Drawing.Image)
        Me.BtnSoporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSoporte.Location = New System.Drawing.Point(207, 111)
        Me.BtnSoporte.Name = "BtnSoporte"
        Me.BtnSoporte.Size = New System.Drawing.Size(193, 40)
        Me.BtnSoporte.TabIndex = 13
        Me.BtnSoporte.Text = "            7 - Todos los Reportes"
        Me.BtnSoporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSoporte.UseVisualStyleBackColor = True
        '
        'BtnDeclara
        '
        Me.BtnDeclara.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDeclara.Image = CType(resources.GetObject("BtnDeclara.Image"), System.Drawing.Image)
        Me.BtnDeclara.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDeclara.Location = New System.Drawing.Point(5, 10)
        Me.BtnDeclara.Name = "BtnDeclara"
        Me.BtnDeclara.Size = New System.Drawing.Size(193, 44)
        Me.BtnDeclara.TabIndex = 1
        Me.BtnDeclara.Text = "          1 - Declaración de Producción"
        Me.BtnDeclara.UseVisualStyleBackColor = True
        '
        'BtnEgreso
        '
        Me.BtnEgreso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEgreso.Image = CType(resources.GetObject("BtnEgreso.Image"), System.Drawing.Image)
        Me.BtnEgreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEgreso.Location = New System.Drawing.Point(84, 46)
        Me.BtnEgreso.Name = "BtnEgreso"
        Me.BtnEgreso.Size = New System.Drawing.Size(67, 44)
        Me.BtnEgreso.TabIndex = 3
        Me.BtnEgreso.Text = "3 - Documento Egreso"
        Me.BtnEgreso.UseVisualStyleBackColor = True
        Me.BtnEgreso.Visible = False
        '
        'BtnEquivalente
        '
        Me.BtnEquivalente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEquivalente.Image = CType(resources.GetObject("BtnEquivalente.Image"), System.Drawing.Image)
        Me.BtnEquivalente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEquivalente.Location = New System.Drawing.Point(11, 46)
        Me.BtnEquivalente.Name = "BtnEquivalente"
        Me.BtnEquivalente.Size = New System.Drawing.Size(67, 44)
        Me.BtnEquivalente.TabIndex = 2
        Me.BtnEquivalente.Text = "2 - Documento Equivalente"
        Me.BtnEquivalente.UseVisualStyleBackColor = True
        Me.BtnEquivalente.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnEgreso)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.BtnEquivalente)
        Me.Panel3.Controls.Add(Me.TxtConsecu)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.TxtEmpCiuImp)
        Me.Panel3.Controls.Add(Me.TxtCedImp)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(433, 354)
        Me.Panel3.TabIndex = 106
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(184, 56)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 42)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 107
        Me.PictureBox1.TabStop = False
        '
        'FrmEscojeImpPlatino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(433, 354)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(433, 354)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(433, 354)
        Me.Name = "FrmEscojeImpPlatino"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmEscojeImpPlatino"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents TxtConsecu As TextBox
    Friend WithEvents TxtEmpCiuImp As TextBox
    Friend WithEvents TxtCedImp As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnEgreso As Button
    Friend WithEvents BtnEquivalente As Button
    Friend WithEvents BtnDeclara As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnPagare As Button
    Friend WithEvents BtnLiquidacion As Button
    Friend WithEvents BtnCertifica As Button
    Friend WithEvents BtnActa As Button
    Friend WithEvents BtnContrato As Button
    Friend WithEvents BtnSoporte As Button
End Class
