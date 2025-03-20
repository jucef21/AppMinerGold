<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRangoAcumula
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRangoAcumula))
        Me.LblModReg = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DTPfinal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DTPinicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtLeyC = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtGrBrutosC = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ChkPlata = New System.Windows.Forms.CheckBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ChkPlatino = New System.Windows.Forms.CheckBox()
        Me.ChkOro = New System.Windows.Forms.CheckBox()
        Me.BtnConsu = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.BtnImpTD = New System.Windows.Forms.Button()
        Me.BtnLimpia = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblModReg
        '
        Me.LblModReg.AutoSize = True
        Me.LblModReg.Location = New System.Drawing.Point(160, 341)
        Me.LblModReg.Name = "LblModReg"
        Me.LblModReg.Size = New System.Drawing.Size(10, 13)
        Me.LblModReg.TabIndex = 46
        Me.LblModReg.Tag = ""
        Me.LblModReg.Text = "."
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Panel3.Controls.Add(Me.BtnX)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(806, 40)
        Me.Panel3.TabIndex = 44
        '
        'BtnX
        '
        Me.BtnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.BtnX.BackgroundImage = CType(resources.GetObject("BtnX.BackgroundImage"), System.Drawing.Image)
        Me.BtnX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Location = New System.Drawing.Point(768, 4)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 78
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(222, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(313, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "CONSULTA TOTAL  DE COMPRAS POR FECHAS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(626, 425)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 17)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Total Cancelado:"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.DTPfinal)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(240, 82)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(193, 55)
        Me.Panel2.TabIndex = 43
        '
        'DTPfinal
        '
        Me.DTPfinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPfinal.Location = New System.Drawing.Point(81, 17)
        Me.DTPfinal.Name = "DTPfinal"
        Me.DTPfinal.Size = New System.Drawing.Size(100, 20)
        Me.DTPfinal.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha Final"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DTPinicial)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(40, 82)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(194, 55)
        Me.Panel1.TabIndex = 42
        '
        'DTPinicial
        '
        Me.DTPinicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPinicial.Location = New System.Drawing.Point(81, 16)
        Me.DTPinicial.Name = "DTPinicial"
        Me.DTPinicial.Size = New System.Drawing.Size(100, 20)
        Me.DTPinicial.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Inicial"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(247, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Seleccione el Rango de Fechas a Consultar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(238, 425)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 17)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Total de Ley:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(393, 425)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(181, 17)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Total de Gramos Puros:"
        '
        'TxtLeyC
        '
        Me.TxtLeyC.Enabled = False
        Me.TxtLeyC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLeyC.Location = New System.Drawing.Point(241, 448)
        Me.TxtLeyC.Name = "TxtLeyC"
        Me.TxtLeyC.Size = New System.Drawing.Size(100, 26)
        Me.TxtLeyC.TabIndex = 36
        Me.TxtLeyC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(430, 448)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(114, 26)
        Me.TextBox1.TabIndex = 30
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 341)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Registros Encontrados:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(35, 145)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(741, 193)
        Me.DataGridView1.TabIndex = 45
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(47, 425)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(186, 17)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Total de Gramos Brutos:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(267, 398)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(252, 17)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Totales de Fechas Seleccionadas"
        '
        'TxtGrBrutosC
        '
        Me.TxtGrBrutosC.Enabled = False
        Me.TxtGrBrutosC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGrBrutosC.Location = New System.Drawing.Point(81, 448)
        Me.TxtGrBrutosC.Name = "TxtGrBrutosC"
        Me.TxtGrBrutosC.Size = New System.Drawing.Size(114, 26)
        Me.TxtGrBrutosC.TabIndex = 38
        Me.TxtGrBrutosC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.ChkPlata)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.TextBox2)
        Me.Panel4.Controls.Add(Me.TxtLeyC)
        Me.Panel4.Controls.Add(Me.TextBox1)
        Me.Panel4.Controls.Add(Me.TxtGrBrutosC)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.ChkPlatino)
        Me.Panel4.Controls.Add(Me.ChkOro)
        Me.Panel4.Controls.Add(Me.BtnConsu)
        Me.Panel4.Controls.Add(Me.TextBox3)
        Me.Panel4.Controls.Add(Me.BtnImpTD)
        Me.Panel4.Controls.Add(Me.BtnLimpia)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(806, 488)
        Me.Panel4.TabIndex = 48
        '
        'ChkPlata
        '
        Me.ChkPlata.AutoSize = True
        Me.ChkPlata.Location = New System.Drawing.Point(589, 104)
        Me.ChkPlata.Name = "ChkPlata"
        Me.ChkPlata.Size = New System.Drawing.Size(60, 17)
        Me.ChkPlata.TabIndex = 54
        Me.ChkPlata.Text = "PLATA"
        Me.ChkPlata.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(591, 448)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(179, 26)
        Me.TextBox2.TabIndex = 33
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(461, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(170, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Seleccione el Material a Consultar:"
        '
        'ChkPlatino
        '
        Me.ChkPlatino.AutoSize = True
        Me.ChkPlatino.Location = New System.Drawing.Point(511, 105)
        Me.ChkPlatino.Name = "ChkPlatino"
        Me.ChkPlatino.Size = New System.Drawing.Size(72, 17)
        Me.ChkPlatino.TabIndex = 28
        Me.ChkPlatino.Text = "PLATINO"
        Me.ChkPlatino.UseVisualStyleBackColor = True
        '
        'ChkOro
        '
        Me.ChkOro.AutoSize = True
        Me.ChkOro.Location = New System.Drawing.Point(447, 105)
        Me.ChkOro.Name = "ChkOro"
        Me.ChkOro.Size = New System.Drawing.Size(50, 17)
        Me.ChkOro.TabIndex = 27
        Me.ChkOro.Text = "ORO"
        Me.ChkOro.UseVisualStyleBackColor = True
        '
        'BtnConsu
        '
        Me.BtnConsu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsu.FlatAppearance.BorderSize = 0
        Me.BtnConsu.Image = CType(resources.GetObject("BtnConsu.Image"), System.Drawing.Image)
        Me.BtnConsu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConsu.Location = New System.Drawing.Point(655, 80)
        Me.BtnConsu.Name = "BtnConsu"
        Me.BtnConsu.Size = New System.Drawing.Size(115, 50)
        Me.BtnConsu.TabIndex = 23
        Me.BtnConsu.Text = "     &Consultar"
        Me.BtnConsu.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(29, 360)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 35
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox3.Visible = False
        '
        'BtnImpTD
        '
        Me.BtnImpTD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpTD.FlatAppearance.BorderSize = 0
        Me.BtnImpTD.Image = CType(resources.GetObject("BtnImpTD.Image"), System.Drawing.Image)
        Me.BtnImpTD.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnImpTD.Location = New System.Drawing.Point(270, 346)
        Me.BtnImpTD.Name = "BtnImpTD"
        Me.BtnImpTD.Size = New System.Drawing.Size(120, 40)
        Me.BtnImpTD.TabIndex = 29
        Me.BtnImpTD.Text = "     &Imprimir"
        Me.BtnImpTD.UseVisualStyleBackColor = True
        '
        'BtnLimpia
        '
        Me.BtnLimpia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLimpia.FlatAppearance.BorderSize = 0
        Me.BtnLimpia.Image = CType(resources.GetObject("BtnLimpia.Image"), System.Drawing.Image)
        Me.BtnLimpia.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnLimpia.Location = New System.Drawing.Point(397, 346)
        Me.BtnLimpia.Name = "BtnLimpia"
        Me.BtnLimpia.Size = New System.Drawing.Size(120, 40)
        Me.BtnLimpia.TabIndex = 28
        Me.BtnLimpia.Text = "     &Limpiar"
        Me.BtnLimpia.UseVisualStyleBackColor = True
        '
        'FrmRangoAcumula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(806, 488)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblModReg)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximumSize = New System.Drawing.Size(806, 488)
        Me.MinimumSize = New System.Drawing.Size(806, 488)
        Me.Name = "FrmRangoAcumula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRangoAcumulado"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblModReg As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DTPfinal As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DTPinicial As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtLeyC As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtGrBrutosC As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ChkPlatino As CheckBox
    Friend WithEvents ChkOro As CheckBox
    Friend WithEvents BtnConsu As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents BtnImpTD As Button
    Friend WithEvents BtnLimpia As Button
    Friend WithEvents ChkPlata As CheckBox
End Class
