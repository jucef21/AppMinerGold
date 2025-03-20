<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEvidencia
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEvidencia))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicFirma = New System.Windows.Forms.PictureBox()
        Me.BtnExaminaFirma = New System.Windows.Forms.Button()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.BtnExaminaHuella = New System.Windows.Forms.Button()
        Me.BtnHuella = New System.Windows.Forms.Button()
        Me.BtnExamina = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PicHuella = New System.Windows.Forms.PictureBox()
        Me.PicFoto = New System.Windows.Forms.PictureBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Txtced_cl = New System.Windows.Forms.TextBox()
        Me.TxtNomApe = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtCedImp = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TxtSurName = New System.Windows.Forms.TextBox()
        Me.TxtNomPaciente = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtNomFoto = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 40)
        Me.Panel1.TabIndex = 191
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(750, 5)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(38, 29)
        Me.BtnX.TabIndex = 45
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(236, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(307, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "ACTUALIZACIÓN DE DATOS DEL  PROVEEDOR"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PicFirma)
        Me.GroupBox1.Controls.Add(Me.BtnExaminaFirma)
        Me.GroupBox1.Controls.Add(Me.TxtCedula)
        Me.GroupBox1.Controls.Add(Me.BtnExaminaHuella)
        Me.GroupBox1.Controls.Add(Me.BtnHuella)
        Me.GroupBox1.Controls.Add(Me.BtnExamina)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PicHuella)
        Me.GroupBox1.Controls.Add(Me.PicFoto)
        Me.GroupBox1.Location = New System.Drawing.Point(47, 158)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(712, 251)
        Me.GroupBox1.TabIndex = 212
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Proveedor"
        '
        'PicFirma
        '
        Me.PicFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicFirma.Location = New System.Drawing.Point(433, 35)
        Me.PicFirma.Name = "PicFirma"
        Me.PicFirma.Size = New System.Drawing.Size(250, 90)
        Me.PicFirma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicFirma.TabIndex = 224
        Me.PicFirma.TabStop = False
        '
        'BtnExaminaFirma
        '
        Me.BtnExaminaFirma.Image = CType(resources.GetObject("BtnExaminaFirma.Image"), System.Drawing.Image)
        Me.BtnExaminaFirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExaminaFirma.Location = New System.Drawing.Point(512, 139)
        Me.BtnExaminaFirma.Name = "BtnExaminaFirma"
        Me.BtnExaminaFirma.Size = New System.Drawing.Size(80, 35)
        Me.BtnExaminaFirma.TabIndex = 223
        Me.BtnExaminaFirma.Text = "  E&xaminar"
        Me.BtnExaminaFirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExaminaFirma.UseVisualStyleBackColor = True
        '
        'TxtCedula
        '
        Me.TxtCedula.Location = New System.Drawing.Point(280, 173)
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(119, 20)
        Me.TxtCedula.TabIndex = 222
        '
        'BtnExaminaHuella
        '
        Me.BtnExaminaHuella.Image = CType(resources.GetObject("BtnExaminaHuella.Image"), System.Drawing.Image)
        Me.BtnExaminaHuella.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExaminaHuella.Location = New System.Drawing.Point(344, 201)
        Me.BtnExaminaHuella.Name = "BtnExaminaHuella"
        Me.BtnExaminaHuella.Size = New System.Drawing.Size(80, 35)
        Me.BtnExaminaHuella.TabIndex = 221
        Me.BtnExaminaHuella.Text = "  E&xaminar"
        Me.BtnExaminaHuella.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExaminaHuella.UseVisualStyleBackColor = True
        '
        'BtnHuella
        '
        Me.BtnHuella.Image = CType(resources.GetObject("BtnHuella.Image"), System.Drawing.Image)
        Me.BtnHuella.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnHuella.Location = New System.Drawing.Point(258, 201)
        Me.BtnHuella.Name = "BtnHuella"
        Me.BtnHuella.Size = New System.Drawing.Size(80, 35)
        Me.BtnHuella.TabIndex = 220
        Me.BtnHuella.Text = "   &Huella"
        Me.BtnHuella.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnHuella.UseVisualStyleBackColor = True
        '
        'BtnExamina
        '
        Me.BtnExamina.Image = CType(resources.GetObject("BtnExamina.Image"), System.Drawing.Image)
        Me.BtnExamina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExamina.Location = New System.Drawing.Point(71, 201)
        Me.BtnExamina.Name = "BtnExamina"
        Me.BtnExamina.Size = New System.Drawing.Size(101, 35)
        Me.BtnExamina.TabIndex = 219
        Me.BtnExamina.Text = "&Examinar"
        Me.BtnExamina.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(529, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "FIRMA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(318, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "HUELLA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(109, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "FOTO"
        '
        'PicHuella
        '
        Me.PicHuella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicHuella.Location = New System.Drawing.Point(280, 35)
        Me.PicHuella.Name = "PicHuella"
        Me.PicHuella.Size = New System.Drawing.Size(120, 130)
        Me.PicHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicHuella.TabIndex = 1
        Me.PicHuella.TabStop = False
        '
        'PicFoto
        '
        Me.PicFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicFoto.Location = New System.Drawing.Point(55, 35)
        Me.PicFoto.Name = "PicFoto"
        Me.PicFoto.Size = New System.Drawing.Size(150, 160)
        Me.PicFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicFoto.TabIndex = 0
        Me.PicFoto.TabStop = False
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(220, 13)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(59, 13)
        Me.Label74.TabIndex = 2
        Me.Label74.Text = "Proveedor:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(19, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Cédula :"
        '
        'Txtced_cl
        '
        Me.Txtced_cl.Enabled = False
        Me.Txtced_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtced_cl.Location = New System.Drawing.Point(70, 10)
        Me.Txtced_cl.Name = "Txtced_cl"
        Me.Txtced_cl.Size = New System.Drawing.Size(144, 23)
        Me.Txtced_cl.TabIndex = 1
        Me.Txtced_cl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNomApe
        '
        Me.TxtNomApe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomApe.Location = New System.Drawing.Point(283, 7)
        Me.TxtNomApe.Name = "TxtNomApe"
        Me.TxtNomApe.Size = New System.Drawing.Size(417, 26)
        Me.TxtNomApe.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TxtNomApe)
        Me.Panel3.Controls.Add(Me.Txtced_cl)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label74)
        Me.Panel3.Location = New System.Drawing.Point(47, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(712, 52)
        Me.Panel3.TabIndex = 213
        '
        'TxtCedImp
        '
        Me.TxtCedImp.Enabled = False
        Me.TxtCedImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCedImp.Location = New System.Drawing.Point(638, 114)
        Me.TxtCedImp.Name = "TxtCedImp"
        Me.TxtCedImp.Size = New System.Drawing.Size(121, 23)
        Me.TxtCedImp.TabIndex = 215
        Me.TxtCedImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCedImp.Visible = False
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.TextBox5)
        Me.Panel7.Controls.Add(Me.TextBox2)
        Me.Panel7.Controls.Add(Me.TxtSurName)
        Me.Panel7.Controls.Add(Me.TxtNomPaciente)
        Me.Panel7.Controls.Add(Me.TxtName)
        Me.Panel7.Location = New System.Drawing.Point(47, 114)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(117, 32)
        Me.Panel7.TabIndex = 214
        Me.Panel7.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(84, 4)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(20, 20)
        Me.TextBox5.TabIndex = 56
        Me.TextBox5.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(58, 4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(20, 20)
        Me.TextBox2.TabIndex = 55
        Me.TextBox2.Visible = False
        '
        'TxtSurName
        '
        Me.TxtSurName.Enabled = False
        Me.TxtSurName.Location = New System.Drawing.Point(21, 3)
        Me.TxtSurName.Name = "TxtSurName"
        Me.TxtSurName.Size = New System.Drawing.Size(13, 20)
        Me.TxtSurName.TabIndex = 53
        Me.TxtSurName.Visible = False
        '
        'TxtNomPaciente
        '
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomPaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.TxtNomPaciente.Location = New System.Drawing.Point(38, 4)
        Me.TxtNomPaciente.Name = "TxtNomPaciente"
        Me.TxtNomPaciente.Size = New System.Drawing.Size(15, 26)
        Me.TxtNomPaciente.TabIndex = 54
        Me.TxtNomPaciente.Visible = False
        '
        'TxtName
        '
        Me.TxtName.Enabled = False
        Me.TxtName.Location = New System.Drawing.Point(5, 4)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(13, 20)
        Me.TxtName.TabIndex = 52
        Me.TxtName.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(209, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(373, 20)
        Me.Label1.TabIndex = 216
        Me.Label1.Text = "ACTUALIZACIÓN DE DATOS BIOMÉTRICOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(263, 428)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(122, 40)
        Me.BtnGuardar.TabIndex = 218
        Me.BtnGuardar.Text = "  &Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImprimir.Image = CType(resources.GetObject("BtnImprimir.Image"), System.Drawing.Image)
        Me.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprimir.Location = New System.Drawing.Point(391, 428)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(122, 40)
        Me.BtnImprimir.TabIndex = 219
        Me.BtnImprimir.Text = "   &Imprimir"
        Me.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtNomFoto)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(800, 497)
        Me.Panel2.TabIndex = 220
        '
        'TxtNomFoto
        '
        Me.TxtNomFoto.Enabled = False
        Me.TxtNomFoto.Location = New System.Drawing.Point(46, 414)
        Me.TxtNomFoto.Name = "TxtNomFoto"
        Me.TxtNomFoto.Size = New System.Drawing.Size(205, 20)
        Me.TxtNomFoto.TabIndex = 225
        '
        'FrmEvidencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 497)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnImprimir)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCedImp)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEvidencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold, Soporte de Datos "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicHuella, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PicHuella As PictureBox
    Friend WithEvents PicFoto As PictureBox
    Friend WithEvents Label74 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Txtced_cl As TextBox
    Friend WithEvents TxtNomApe As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TxtCedImp As TextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TxtSurName As TextBox
    Friend WithEvents TxtNomPaciente As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents BtnExamina As Button
    Friend WithEvents BtnHuella As Button
    Friend WithEvents BtnExaminaHuella As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents BtnExaminaFirma As Button
    Friend WithEvents PicFirma As PictureBox
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents TxtNomFoto As TextBox
End Class
