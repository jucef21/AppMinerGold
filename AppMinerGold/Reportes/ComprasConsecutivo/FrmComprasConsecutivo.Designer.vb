<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComprasConsecutivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComprasConsecutivo))
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtGrBrutosC = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtLeyC = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnImpTD = New System.Windows.Forms.Button()
        Me.BtnLimpia = New System.Windows.Forms.Button()
        Me.LblModReg = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnConsu = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DTPfinal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DTPinicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(548, 363)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 13)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Total de Gramos Brutos:"
        '
        'TxtGrBrutosC
        '
        Me.TxtGrBrutosC.Enabled = False
        Me.TxtGrBrutosC.Location = New System.Drawing.Point(673, 360)
        Me.TxtGrBrutosC.Name = "TxtGrBrutosC"
        Me.TxtGrBrutosC.Size = New System.Drawing.Size(100, 20)
        Me.TxtGrBrutosC.TabIndex = 59
        Me.TxtGrBrutosC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(548, 389)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Total de Ley:"
        '
        'TxtLeyC
        '
        Me.TxtLeyC.Enabled = False
        Me.TxtLeyC.Location = New System.Drawing.Point(673, 386)
        Me.TxtLeyC.Name = "TxtLeyC"
        Me.TxtLeyC.Size = New System.Drawing.Size(100, 20)
        Me.TxtLeyC.TabIndex = 57
        Me.TxtLeyC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(35, 363)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 56
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox3.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(561, 341)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(199, 13)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "Totales de Fechas Seleccionadas"
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(673, 441)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 54
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(548, 443)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "Total Cancelado:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(548, 415)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Total de Gramos Puros:"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(673, 412)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 51
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnImpTD
        '
        Me.BtnImpTD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpTD.FlatAppearance.BorderSize = 0
        Me.BtnImpTD.Image = CType(resources.GetObject("BtnImpTD.Image"), System.Drawing.Image)
        Me.BtnImpTD.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnImpTD.Location = New System.Drawing.Point(199, 391)
        Me.BtnImpTD.Name = "BtnImpTD"
        Me.BtnImpTD.Size = New System.Drawing.Size(120, 40)
        Me.BtnImpTD.TabIndex = 50
        Me.BtnImpTD.Text = "     &Imprimir"
        Me.BtnImpTD.UseVisualStyleBackColor = True
        '
        'BtnLimpia
        '
        Me.BtnLimpia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLimpia.FlatAppearance.BorderSize = 0
        Me.BtnLimpia.Image = CType(resources.GetObject("BtnLimpia.Image"), System.Drawing.Image)
        Me.BtnLimpia.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnLimpia.Location = New System.Drawing.Point(327, 391)
        Me.BtnLimpia.Name = "BtnLimpia"
        Me.BtnLimpia.Size = New System.Drawing.Size(120, 40)
        Me.BtnLimpia.TabIndex = 49
        Me.BtnLimpia.Text = "     &Limpiar"
        Me.BtnLimpia.UseVisualStyleBackColor = True
        '
        'LblModReg
        '
        Me.LblModReg.AutoSize = True
        Me.LblModReg.Location = New System.Drawing.Point(161, 342)
        Me.LblModReg.Name = "LblModReg"
        Me.LblModReg.Size = New System.Drawing.Size(10, 13)
        Me.LblModReg.TabIndex = 47
        Me.LblModReg.Tag = ""
        Me.LblModReg.Text = "."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 342)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Registros Encontrados:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(32, 141)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(741, 193)
        Me.DataGridView1.TabIndex = 46
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Panel3.Controls.Add(Me.BtnX)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(810, 40)
        Me.Panel3.TabIndex = 45
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
        Me.BtnX.Location = New System.Drawing.Point(772, 2)
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
        Me.Label4.Location = New System.Drawing.Point(221, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(375, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "CONSULTA DE COMPRAS POR FECHAS Y CONSECUTIVO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnConsu
        '
        Me.BtnConsu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsu.FlatAppearance.BorderSize = 0
        Me.BtnConsu.Image = CType(resources.GetObject("BtnConsu.Image"), System.Drawing.Image)
        Me.BtnConsu.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnConsu.Location = New System.Drawing.Point(588, 87)
        Me.BtnConsu.Name = "BtnConsu"
        Me.BtnConsu.Size = New System.Drawing.Size(120, 40)
        Me.BtnConsu.TabIndex = 44
        Me.BtnConsu.Text = "     &Consultar"
        Me.BtnConsu.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.DTPfinal)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(350, 78)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(228, 55)
        Me.Panel2.TabIndex = 42
        '
        'DTPfinal
        '
        Me.DTPfinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPfinal.Location = New System.Drawing.Point(95, 17)
        Me.DTPfinal.Name = "DTPfinal"
        Me.DTPfinal.Size = New System.Drawing.Size(100, 20)
        Me.DTPfinal.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 20)
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
        Me.Panel1.Location = New System.Drawing.Point(104, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(228, 55)
        Me.Panel1.TabIndex = 41
        '
        'DTPinicial
        '
        Me.DTPinicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPinicial.Location = New System.Drawing.Point(95, 16)
        Me.DTPinicial.Name = "DTPinicial"
        Me.DTPinicial.Size = New System.Drawing.Size(100, 20)
        Me.DTPinicial.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Inicial"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(280, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Seleccione el Rango de Fechas a Consultar"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnImpTD)
        Me.Panel4.Controls.Add(Me.BtnLimpia)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(810, 489)
        Me.Panel4.TabIndex = 61
        '
        'FrmComprasConsecutivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(810, 489)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtGrBrutosC)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtLeyC)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LblModReg)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.BtnConsu)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(810, 489)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(810, 489)
        Me.Name = "FrmComprasConsecutivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Compras Consecutivo"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label10 As Label
    Friend WithEvents TxtGrBrutosC As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtLeyC As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents BtnImpTD As Button
    Friend WithEvents BtnLimpia As Button
    Friend WithEvents LblModReg As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnConsu As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DTPfinal As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DTPinicial As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel4 As Panel
End Class
