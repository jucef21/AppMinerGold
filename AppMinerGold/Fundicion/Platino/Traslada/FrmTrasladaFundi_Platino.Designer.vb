<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrasladaFundi_Platino
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrasladaFundi_Platino))
        Me.TxtMetal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Tpu = New System.Windows.Forms.TextBox()
        Me.Tley = New System.Windows.Forms.TextBox()
        Me.Tbr = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtDispoPuros = New System.Windows.Forms.TextBox()
        Me.TxtDispoLey = New System.Windows.Forms.TextBox()
        Me.TxtDispoBrutos = New System.Windows.Forms.TextBox()
        Me.BtnTotaliza = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnImpriFundi = New System.Windows.Forms.Button()
        Me.BtnNuevaFundi = New System.Windows.Forms.Button()
        Me.BtnGuardaFundi = New System.Windows.Forms.Button()
        Me.BtnLimpia = New System.Windows.Forms.Button()
        Me.TxtCuenta = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BtnPasa = New System.Windows.Forms.Button()
        Me.BtnQuita = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.metal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brutos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ley = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.puros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.verifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numfundi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TxtControlNum = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtNum_com = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.DTPfechaactual = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtMetal
        '
        Me.TxtMetal.Enabled = False
        Me.TxtMetal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMetal.Location = New System.Drawing.Point(967, 507)
        Me.TxtMetal.Name = "TxtMetal"
        Me.TxtMetal.Size = New System.Drawing.Size(100, 23)
        Me.TxtMetal.TabIndex = 282
        Me.TxtMetal.Text = "PLATINO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Location = New System.Drawing.Point(774, 398)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 294
        Me.Label9.Text = "Saldo Fundi"
        Me.Label9.Visible = False
        '
        'Tpu
        '
        Me.Tpu.Enabled = False
        Me.Tpu.Location = New System.Drawing.Point(763, 463)
        Me.Tpu.Name = "Tpu"
        Me.Tpu.Size = New System.Drawing.Size(100, 20)
        Me.Tpu.TabIndex = 293
        Me.Tpu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Tpu.Visible = False
        '
        'Tley
        '
        Me.Tley.Enabled = False
        Me.Tley.Location = New System.Drawing.Point(763, 438)
        Me.Tley.Name = "Tley"
        Me.Tley.Size = New System.Drawing.Size(100, 20)
        Me.Tley.TabIndex = 292
        Me.Tley.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Tley.Visible = False
        '
        'Tbr
        '
        Me.Tbr.Enabled = False
        Me.Tbr.Location = New System.Drawing.Point(763, 414)
        Me.Tbr.Name = "Tbr"
        Me.Tbr.Size = New System.Drawing.Size(100, 20)
        Me.Tbr.TabIndex = 291
        Me.Tbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Tbr.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(936, 387)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 13)
        Me.Label8.TabIndex = 290
        Me.Label8.Text = "Saldo Para Fundición:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 387)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 289
        Me.Label5.Text = "Saldo Disponible:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 466)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 288
        Me.Label10.Text = "Gramos Puros"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 438)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 287
        Me.Label12.Text = "Ley Promedio"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 410)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 286
        Me.Label13.Text = "Gramos Brutos"
        '
        'TxtDispoPuros
        '
        Me.TxtDispoPuros.Enabled = False
        Me.TxtDispoPuros.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDispoPuros.Location = New System.Drawing.Point(97, 463)
        Me.TxtDispoPuros.Name = "TxtDispoPuros"
        Me.TxtDispoPuros.Size = New System.Drawing.Size(100, 23)
        Me.TxtDispoPuros.TabIndex = 285
        Me.TxtDispoPuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtDispoLey
        '
        Me.TxtDispoLey.Enabled = False
        Me.TxtDispoLey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDispoLey.Location = New System.Drawing.Point(97, 433)
        Me.TxtDispoLey.Name = "TxtDispoLey"
        Me.TxtDispoLey.Size = New System.Drawing.Size(100, 23)
        Me.TxtDispoLey.TabIndex = 284
        Me.TxtDispoLey.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtDispoBrutos
        '
        Me.TxtDispoBrutos.Enabled = False
        Me.TxtDispoBrutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDispoBrutos.Location = New System.Drawing.Point(97, 404)
        Me.TxtDispoBrutos.Name = "TxtDispoBrutos"
        Me.TxtDispoBrutos.Size = New System.Drawing.Size(100, 23)
        Me.TxtDispoBrutos.TabIndex = 283
        Me.TxtDispoBrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnTotaliza
        '
        Me.BtnTotaliza.Image = CType(resources.GetObject("BtnTotaliza.Image"), System.Drawing.Image)
        Me.BtnTotaliza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTotaliza.Location = New System.Drawing.Point(596, 410)
        Me.BtnTotaliza.Name = "BtnTotaliza"
        Me.BtnTotaliza.Size = New System.Drawing.Size(152, 52)
        Me.BtnTotaliza.TabIndex = 274
        Me.BtnTotaliza.Text = "Totaliza Datos"
        Me.BtnTotaliza.UseVisualStyleBackColor = True
        Me.BtnTotaliza.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(888, 470)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 281
        Me.Label3.Text = "Gramos Puros"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(888, 442)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 280
        Me.Label2.Text = "Ley Promedio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(888, 414)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 279
        Me.Label1.Text = "Gramos Brutos"
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(966, 467)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 23)
        Me.TextBox3.TabIndex = 278
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(966, 437)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 23)
        Me.TextBox2.TabIndex = 277
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(966, 408)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 23)
        Me.TextBox1.TabIndex = 276
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnImpriFundi
        '
        Me.BtnImpriFundi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpriFundi.Image = CType(resources.GetObject("BtnImpriFundi.Image"), System.Drawing.Image)
        Me.BtnImpriFundi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImpriFundi.Location = New System.Drawing.Point(550, 500)
        Me.BtnImpriFundi.Name = "BtnImpriFundi"
        Me.BtnImpriFundi.Size = New System.Drawing.Size(149, 45)
        Me.BtnImpriFundi.TabIndex = 272
        Me.BtnImpriFundi.Text = "       Imprimir"
        Me.BtnImpriFundi.UseVisualStyleBackColor = True
        '
        'BtnNuevaFundi
        '
        Me.BtnNuevaFundi.BackColor = System.Drawing.Color.Transparent
        Me.BtnNuevaFundi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevaFundi.ForeColor = System.Drawing.Color.Black
        Me.BtnNuevaFundi.Image = CType(resources.GetObject("BtnNuevaFundi.Image"), System.Drawing.Image)
        Me.BtnNuevaFundi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevaFundi.Location = New System.Drawing.Point(238, 500)
        Me.BtnNuevaFundi.Name = "BtnNuevaFundi"
        Me.BtnNuevaFundi.Size = New System.Drawing.Size(149, 45)
        Me.BtnNuevaFundi.TabIndex = 270
        Me.BtnNuevaFundi.Text = "         Nueva Fundición"
        Me.BtnNuevaFundi.UseVisualStyleBackColor = False
        '
        'BtnGuardaFundi
        '
        Me.BtnGuardaFundi.BackColor = System.Drawing.Color.Transparent
        Me.BtnGuardaFundi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGuardaFundi.ForeColor = System.Drawing.Color.Black
        Me.BtnGuardaFundi.Image = CType(resources.GetObject("BtnGuardaFundi.Image"), System.Drawing.Image)
        Me.BtnGuardaFundi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardaFundi.Location = New System.Drawing.Point(394, 500)
        Me.BtnGuardaFundi.Name = "BtnGuardaFundi"
        Me.BtnGuardaFundi.Size = New System.Drawing.Size(149, 45)
        Me.BtnGuardaFundi.TabIndex = 271
        Me.BtnGuardaFundi.Text = "      Guardar Fundición"
        Me.BtnGuardaFundi.UseVisualStyleBackColor = False
        '
        'BtnLimpia
        '
        Me.BtnLimpia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLimpia.FlatAppearance.BorderSize = 0
        Me.BtnLimpia.Image = CType(resources.GetObject("BtnLimpia.Image"), System.Drawing.Image)
        Me.BtnLimpia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLimpia.Location = New System.Drawing.Point(706, 500)
        Me.BtnLimpia.Name = "BtnLimpia"
        Me.BtnLimpia.Size = New System.Drawing.Size(149, 45)
        Me.BtnLimpia.TabIndex = 273
        Me.BtnLimpia.Text = "     &Limpiar"
        Me.BtnLimpia.UseVisualStyleBackColor = True
        '
        'TxtCuenta
        '
        Me.TxtCuenta.Enabled = False
        Me.TxtCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuenta.Location = New System.Drawing.Point(20, 505)
        Me.TxtCuenta.Name = "TxtCuenta"
        Me.TxtCuenta.Size = New System.Drawing.Size(39, 23)
        Me.TxtCuenta.TabIndex = 275
        Me.TxtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtCuenta.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(17, 174)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(493, 206)
        Me.DataGridView1.TabIndex = 267
        '
        'BtnPasa
        '
        Me.BtnPasa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPasa.Image = CType(resources.GetObject("BtnPasa.Image"), System.Drawing.Image)
        Me.BtnPasa.Location = New System.Drawing.Point(518, 242)
        Me.BtnPasa.Name = "BtnPasa"
        Me.BtnPasa.Size = New System.Drawing.Size(45, 61)
        Me.BtnPasa.TabIndex = 266
        Me.BtnPasa.UseVisualStyleBackColor = True
        '
        'BtnQuita
        '
        Me.BtnQuita.Location = New System.Drawing.Point(518, 318)
        Me.BtnQuita.Name = "BtnQuita"
        Me.BtnQuita.Size = New System.Drawing.Size(45, 62)
        Me.BtnQuita.TabIndex = 268
        Me.BtnQuita.Text = "<<"
        Me.BtnQuita.UseVisualStyleBackColor = True
        Me.BtnQuita.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.nombre, Me.metal, Me.brutos, Me.ley, Me.puros, Me.verifica, Me.numfundi})
        Me.DataGridView2.Location = New System.Drawing.Point(572, 174)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.Size = New System.Drawing.Size(493, 206)
        Me.DataGridView2.TabIndex = 269
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.MinimumWidth = 6
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 50
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre Proveedor"
        Me.nombre.MinimumWidth = 6
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 200
        '
        'metal
        '
        Me.metal.HeaderText = "Metal"
        Me.metal.MinimumWidth = 6
        Me.metal.Name = "metal"
        Me.metal.ReadOnly = True
        Me.metal.Visible = False
        Me.metal.Width = 60
        '
        'brutos
        '
        Me.brutos.HeaderText = "Gramos Brutos"
        Me.brutos.MinimumWidth = 6
        Me.brutos.Name = "brutos"
        Me.brutos.ReadOnly = True
        Me.brutos.Width = 125
        '
        'ley
        '
        Me.ley.HeaderText = "Ley"
        Me.ley.MinimumWidth = 6
        Me.ley.Name = "ley"
        Me.ley.ReadOnly = True
        Me.ley.Width = 60
        '
        'puros
        '
        Me.puros.HeaderText = "Gramos Puros"
        Me.puros.MinimumWidth = 6
        Me.puros.Name = "puros"
        Me.puros.ReadOnly = True
        Me.puros.Width = 125
        '
        'verifica
        '
        Me.verifica.HeaderText = "Verifica"
        Me.verifica.MinimumWidth = 6
        Me.verifica.Name = "verifica"
        Me.verifica.ReadOnly = True
        Me.verifica.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.verifica.Width = 125
        '
        'numfundi
        '
        Me.numfundi.HeaderText = "Numero"
        Me.numfundi.MinimumWidth = 6
        Me.numfundi.Name = "numfundi"
        Me.numfundi.ReadOnly = True
        Me.numfundi.Width = 125
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(19, 54)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 265
        Me.PictureBox1.TabStop = False
        '
        'TxtControlNum
        '
        Me.TxtControlNum.Enabled = False
        Me.TxtControlNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtControlNum.Location = New System.Drawing.Point(193, 108)
        Me.TxtControlNum.Name = "TxtControlNum"
        Me.TxtControlNum.Size = New System.Drawing.Size(81, 23)
        Me.TxtControlNum.TabIndex = 264
        Me.TxtControlNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtControlNum.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 13)
        Me.Label6.TabIndex = 263
        Me.Label6.Text = "Datos Registrados Encontrados:"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtNum_com)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.DTPfechaactual)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Location = New System.Drawing.Point(281, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(528, 57)
        Me.Panel2.TabIndex = 262
        '
        'TxtNum_com
        '
        Me.TxtNum_com.Enabled = False
        Me.TxtNum_com.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNum_com.Location = New System.Drawing.Point(185, 15)
        Me.TxtNum_com.Name = "TxtNum_com"
        Me.TxtNum_com.Size = New System.Drawing.Size(81, 23)
        Me.TxtNum_com.TabIndex = 168
        Me.TxtNum_com.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 21)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(162, 13)
        Me.Label21.TabIndex = 169
        Me.Label21.Text = "No. Consecutivo para Fundición:"
        '
        'DTPfechaactual
        '
        Me.DTPfechaactual.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPfechaactual.Location = New System.Drawing.Point(396, 18)
        Me.DTPfechaactual.Name = "DTPfechaactual"
        Me.DTPfechaactual.Size = New System.Drawing.Size(100, 20)
        Me.DTPfechaactual.TabIndex = 166
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(317, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 167
        Me.Label11.Text = "Fecha Actual"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1083, 40)
        Me.Panel1.TabIndex = 261
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
        Me.BtnX.Location = New System.Drawing.Point(1021, 3)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 48
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(419, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(253, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "TRASLADO A FUNDICIÓN DE PLATINO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1083, 554)
        Me.Panel3.TabIndex = 295
        '
        'FrmTrasladaFundi_Platino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1083, 554)
        Me.Controls.Add(Me.TxtMetal)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Tpu)
        Me.Controls.Add(Me.Tley)
        Me.Controls.Add(Me.Tbr)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtDispoPuros)
        Me.Controls.Add(Me.TxtDispoLey)
        Me.Controls.Add(Me.TxtDispoBrutos)
        Me.Controls.Add(Me.BtnTotaliza)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnImpriFundi)
        Me.Controls.Add(Me.BtnNuevaFundi)
        Me.Controls.Add(Me.BtnGuardaFundi)
        Me.Controls.Add(Me.BtnLimpia)
        Me.Controls.Add(Me.TxtCuenta)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BtnPasa)
        Me.Controls.Add(Me.BtnQuita)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TxtControlNum)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTrasladaFundi_Platino"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traslada a Fundición de Platino"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtMetal As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Tpu As TextBox
    Friend WithEvents Tley As TextBox
    Friend WithEvents Tbr As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtDispoPuros As TextBox
    Friend WithEvents TxtDispoLey As TextBox
    Friend WithEvents TxtDispoBrutos As TextBox
    Friend WithEvents BtnTotaliza As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents BtnImpriFundi As Button
    Friend WithEvents BtnNuevaFundi As Button
    Friend WithEvents BtnGuardaFundi As Button
    Friend WithEvents BtnLimpia As Button
    Friend WithEvents TxtCuenta As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BtnPasa As Button
    Friend WithEvents BtnQuita As Button
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents metal As DataGridViewTextBoxColumn
    Friend WithEvents brutos As DataGridViewTextBoxColumn
    Friend WithEvents ley As DataGridViewTextBoxColumn
    Friend WithEvents puros As DataGridViewTextBoxColumn
    Friend WithEvents verifica As DataGridViewTextBoxColumn
    Friend WithEvents numfundi As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TxtControlNum As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtNum_com As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents DTPfechaactual As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
End Class
