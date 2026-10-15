<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportes))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnOroPlata = New System.Windows.Forms.Button()
        Me.BtnConsultaComp = New System.Windows.Forms.Button()
        Me.BtnUiaf = New System.Windows.Forms.Button()
        Me.BtnCertiRF = New System.Windows.Forms.Button()
        Me.BtnCompConse = New System.Windows.Forms.Button()
        Me.BtnZonas = New System.Windows.Forms.Button()
        Me.BtnListaClientes = New System.Windows.Forms.Button()
        Me.BtnReimpDoc = New System.Windows.Forms.Button()
        Me.BtnRegalias = New System.Windows.Forms.Button()
        Me.BtnCompras = New System.Windows.Forms.Button()
        Me.BtnTasaMensual = New System.Windows.Forms.Button()
        Me.Btnprov = New System.Windows.Forms.Button()
        Me.BtnTasaDiaria = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtnConta = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(16, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(477, 61)
        Me.Panel1.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(394, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(180, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "REPORTES"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnConta)
        Me.Panel2.Controls.Add(Me.BtnOroPlata)
        Me.Panel2.Controls.Add(Me.BtnConsultaComp)
        Me.Panel2.Controls.Add(Me.BtnUiaf)
        Me.Panel2.Controls.Add(Me.BtnCertiRF)
        Me.Panel2.Controls.Add(Me.BtnCompConse)
        Me.Panel2.Controls.Add(Me.BtnZonas)
        Me.Panel2.Controls.Add(Me.BtnListaClientes)
        Me.Panel2.Controls.Add(Me.BtnReimpDoc)
        Me.Panel2.Controls.Add(Me.BtnRegalias)
        Me.Panel2.Controls.Add(Me.BtnCompras)
        Me.Panel2.Controls.Add(Me.BtnTasaMensual)
        Me.Panel2.Location = New System.Drawing.Point(18, 125)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(475, 325)
        Me.Panel2.TabIndex = 6
        '
        'BtnOroPlata
        '
        Me.BtnOroPlata.Image = CType(resources.GetObject("BtnOroPlata.Image"), System.Drawing.Image)
        Me.BtnOroPlata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOroPlata.Location = New System.Drawing.Point(242, 275)
        Me.BtnOroPlata.Name = "BtnOroPlata"
        Me.BtnOroPlata.Size = New System.Drawing.Size(200, 40)
        Me.BtnOroPlata.TabIndex = 11
        Me.BtnOroPlata.Text = "Listado Compras Plata"
        Me.BtnOroPlata.UseVisualStyleBackColor = True
        '
        'BtnConsultaComp
        '
        Me.BtnConsultaComp.Image = CType(resources.GetObject("BtnConsultaComp.Image"), System.Drawing.Image)
        Me.BtnConsultaComp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConsultaComp.Location = New System.Drawing.Point(27, 118)
        Me.BtnConsultaComp.Name = "BtnConsultaComp"
        Me.BtnConsultaComp.Size = New System.Drawing.Size(200, 40)
        Me.BtnConsultaComp.TabIndex = 5
        Me.BtnConsultaComp.Text = "     Reportes Compras Proveedor"
        Me.BtnConsultaComp.UseVisualStyleBackColor = True
        '
        'BtnUiaf
        '
        Me.BtnUiaf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUiaf.Image = CType(resources.GetObject("BtnUiaf.Image"), System.Drawing.Image)
        Me.BtnUiaf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUiaf.Location = New System.Drawing.Point(243, 224)
        Me.BtnUiaf.Name = "BtnUiaf"
        Me.BtnUiaf.Size = New System.Drawing.Size(200, 40)
        Me.BtnUiaf.TabIndex = 10
        Me.BtnUiaf.Text = "&Reporte UIAF"
        Me.BtnUiaf.UseVisualStyleBackColor = True
        '
        'BtnCertiRF
        '
        Me.BtnCertiRF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCertiRF.Image = CType(resources.GetObject("BtnCertiRF.Image"), System.Drawing.Image)
        Me.BtnCertiRF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCertiRF.Location = New System.Drawing.Point(243, 170)
        Me.BtnCertiRF.Name = "BtnCertiRF"
        Me.BtnCertiRF.Size = New System.Drawing.Size(200, 40)
        Me.BtnCertiRF.TabIndex = 8
        Me.BtnCertiRF.Text = "     &Certificado ReteFuente"
        Me.BtnCertiRF.UseVisualStyleBackColor = True
        '
        'BtnCompConse
        '
        Me.BtnCompConse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCompConse.Image = CType(resources.GetObject("BtnCompConse.Image"), System.Drawing.Image)
        Me.BtnCompConse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCompConse.Location = New System.Drawing.Point(27, 170)
        Me.BtnCompConse.Name = "BtnCompConse"
        Me.BtnCompConse.Size = New System.Drawing.Size(200, 40)
        Me.BtnCompConse.TabIndex = 7
        Me.BtnCompConse.Text = "     &Compras x Consecutivo"
        Me.BtnCompConse.UseVisualStyleBackColor = True
        '
        'BtnZonas
        '
        Me.BtnZonas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnZonas.Image = CType(resources.GetObject("BtnZonas.Image"), System.Drawing.Image)
        Me.BtnZonas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnZonas.Location = New System.Drawing.Point(27, 224)
        Me.BtnZonas.Name = "BtnZonas"
        Me.BtnZonas.Size = New System.Drawing.Size(200, 40)
        Me.BtnZonas.TabIndex = 9
        Me.BtnZonas.Text = "     Proveedores &Zona Origen"
        Me.BtnZonas.UseVisualStyleBackColor = True
        '
        'BtnListaClientes
        '
        Me.BtnListaClientes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnListaClientes.Image = CType(resources.GetObject("BtnListaClientes.Image"), System.Drawing.Image)
        Me.BtnListaClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnListaClientes.Location = New System.Drawing.Point(243, 66)
        Me.BtnListaClientes.Name = "BtnListaClientes"
        Me.BtnListaClientes.Size = New System.Drawing.Size(200, 40)
        Me.BtnListaClientes.TabIndex = 4
        Me.BtnListaClientes.Text = "     Listado de &Proveedores Full"
        Me.BtnListaClientes.UseVisualStyleBackColor = True
        '
        'BtnReimpDoc
        '
        Me.BtnReimpDoc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpDoc.Image = CType(resources.GetObject("BtnReimpDoc.Image"), System.Drawing.Image)
        Me.BtnReimpDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReimpDoc.Location = New System.Drawing.Point(243, 118)
        Me.BtnReimpDoc.Name = "BtnReimpDoc"
        Me.BtnReimpDoc.Size = New System.Drawing.Size(200, 40)
        Me.BtnReimpDoc.TabIndex = 6
        Me.BtnReimpDoc.Text = "     Reimprime &Documentos"
        Me.BtnReimpDoc.UseVisualStyleBackColor = True
        '
        'BtnRegalias
        '
        Me.BtnRegalias.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRegalias.Image = CType(resources.GetObject("BtnRegalias.Image"), System.Drawing.Image)
        Me.BtnRegalias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRegalias.Location = New System.Drawing.Point(243, 16)
        Me.BtnRegalias.Name = "BtnRegalias"
        Me.BtnRegalias.Size = New System.Drawing.Size(200, 40)
        Me.BtnRegalias.TabIndex = 2
        Me.BtnRegalias.Text = "     Listado de Regalias"
        Me.BtnRegalias.UseVisualStyleBackColor = True
        '
        'BtnCompras
        '
        Me.BtnCompras.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCompras.Image = CType(resources.GetObject("BtnCompras.Image"), System.Drawing.Image)
        Me.BtnCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCompras.Location = New System.Drawing.Point(27, 16)
        Me.BtnCompras.Name = "BtnCompras"
        Me.BtnCompras.Size = New System.Drawing.Size(200, 40)
        Me.BtnCompras.TabIndex = 1
        Me.BtnCompras.Text = "&Listado de Compras"
        Me.BtnCompras.UseVisualStyleBackColor = True
        '
        'BtnTasaMensual
        '
        Me.BtnTasaMensual.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTasaMensual.Image = CType(resources.GetObject("BtnTasaMensual.Image"), System.Drawing.Image)
        Me.BtnTasaMensual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTasaMensual.Location = New System.Drawing.Point(27, 66)
        Me.BtnTasaMensual.Name = "BtnTasaMensual"
        Me.BtnTasaMensual.Size = New System.Drawing.Size(200, 40)
        Me.BtnTasaMensual.TabIndex = 3
        Me.BtnTasaMensual.Text = "Reporte Total de Metales"
        Me.BtnTasaMensual.UseVisualStyleBackColor = True
        '
        'Btnprov
        '
        Me.Btnprov.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnprov.Image = CType(resources.GetObject("Btnprov.Image"), System.Drawing.Image)
        Me.Btnprov.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btnprov.Location = New System.Drawing.Point(60, 466)
        Me.Btnprov.Name = "Btnprov"
        Me.Btnprov.Size = New System.Drawing.Size(43, 26)
        Me.Btnprov.TabIndex = 4
        Me.Btnprov.Text = "    &Compras x Proveedor"
        Me.Btnprov.UseVisualStyleBackColor = True
        Me.Btnprov.Visible = False
        '
        'BtnTasaDiaria
        '
        Me.BtnTasaDiaria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTasaDiaria.Image = CType(resources.GetObject("BtnTasaDiaria.Image"), System.Drawing.Image)
        Me.BtnTasaDiaria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTasaDiaria.Location = New System.Drawing.Point(10, 465)
        Me.BtnTasaDiaria.Name = "BtnTasaDiaria"
        Me.BtnTasaDiaria.Size = New System.Drawing.Size(44, 27)
        Me.BtnTasaDiaria.TabIndex = 1
        Me.BtnTasaDiaria.Text = "&Tasas Diarias"
        Me.BtnTasaDiaria.UseVisualStyleBackColor = True
        Me.BtnTasaDiaria.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel3.Controls.Add(Me.BtnX)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(515, 40)
        Me.Panel3.TabIndex = 7
        '
        'BtnX
        '
        Me.BtnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(476, 2)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 0
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(173, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "MODULO DE REPORTES"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnTasaDiaria)
        Me.Panel4.Controls.Add(Me.Btnprov)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(515, 500)
        Me.Panel4.TabIndex = 8
        '
        'BtnConta
        '
        Me.BtnConta.Image = CType(resources.GetObject("BtnConta.Image"), System.Drawing.Image)
        Me.BtnConta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConta.Location = New System.Drawing.Point(27, 275)
        Me.BtnConta.Name = "BtnConta"
        Me.BtnConta.Size = New System.Drawing.Size(200, 40)
        Me.BtnConta.TabIndex = 12
        Me.BtnConta.Text = "Listado Cotabilidad"
        Me.BtnConta.UseVisualStyleBackColor = True
        '
        'FrmReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(515, 500)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(515, 500)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(515, 500)
        Me.Name = "FrmReportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Impresión de Informes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnTasaDiaria As System.Windows.Forms.Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnCompras As Button
    Friend WithEvents BtnTasaMensual As Button
    Friend WithEvents Btnprov As Button
    Friend WithEvents BtnRegalias As Button
    Friend WithEvents BtnReimpDoc As Button
    Friend WithEvents BtnListaClientes As Button
    Friend WithEvents BtnZonas As Button
    Friend WithEvents BtnCompConse As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents BtnCertiRF As Button
    Friend WithEvents BtnUiaf As Button
    Friend WithEvents BtnConsultaComp As Button
    Friend WithEvents BtnOroPlata As Button
    Friend WithEvents BtnConta As Button
End Class
