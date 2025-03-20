<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompraTraslado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompraTraslado))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtBrutosSaldo = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Txtpurossaldo = New System.Windows.Forms.TextBox()
        Me.Txtleysaldo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.BtnConsulta = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtInggrpuros = New System.Windows.Forms.TextBox()
        Me.TxtIngley = New System.Windows.Forms.TextBox()
        Me.TxtInggrbrutos = New System.Windows.Forms.TextBox()
        Me.TxtNumTraslado = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtNomPaciente = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtNumDoc = New System.Windows.Forms.TextBox()
        Me.Txtced_cl = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPfechaactual = New System.Windows.Forms.DateTimePicker()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TxtCiudad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPagado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnImpriCaja = New System.Windows.Forms.Button()
        Me.BtnRegreCaja = New System.Windows.Forms.Button()
        Me.TxtSurname = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblRegistros = New System.Windows.Forms.Label()
        Me.BtnNuevoCaja = New System.Windows.Forms.Button()
        Me.BtnGuardaIngreso = New System.Windows.Forms.Button()
        Me.DGVingresos = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtNuevosBrutos = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BtnAjuste = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Txtnuevagrpuros = New System.Windows.Forms.TextBox()
        Me.Txtnuevaley = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Txtajuste = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNumImp = New System.Windows.Forms.TextBox()
        Me.TxtSalLey = New System.Windows.Forms.TextBox()
        Me.TxtSalPu = New System.Windows.Forms.TextBox()
        Me.TxtSalBrutos = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGVingresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtBrutosSaldo)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Txtpurossaldo)
        Me.GroupBox1.Controls.Add(Me.Txtleysaldo)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.BtnConsulta)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.TxtInggrpuros)
        Me.GroupBox1.Controls.Add(Me.TxtIngley)
        Me.GroupBox1.Controls.Add(Me.TxtInggrbrutos)
        Me.GroupBox1.Controls.Add(Me.TxtNumTraslado)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 163)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(672, 111)
        Me.GroupBox1.TabIndex = 147
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Traslado "
        '
        'TxtBrutosSaldo
        '
        Me.TxtBrutosSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBrutosSaldo.Location = New System.Drawing.Point(290, 28)
        Me.TxtBrutosSaldo.Name = "TxtBrutosSaldo"
        Me.TxtBrutosSaldo.Size = New System.Drawing.Size(93, 23)
        Me.TxtBrutosSaldo.TabIndex = 6
        Me.TxtBrutosSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(299, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(76, 13)
        Me.Label22.TabIndex = 166
        Me.Label22.Text = "Gramos Brutos"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(54, 32)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(221, 13)
        Me.Label15.TabIndex = 164
        Me.Label15.Text = "Saldo de Compras Disponibles para Traslado:"
        '
        'Txtpurossaldo
        '
        Me.Txtpurossaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtpurossaldo.Location = New System.Drawing.Point(467, 28)
        Me.Txtpurossaldo.Name = "Txtpurossaldo"
        Me.Txtpurossaldo.Size = New System.Drawing.Size(100, 23)
        Me.Txtpurossaldo.TabIndex = 8
        Me.Txtpurossaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txtleysaldo
        '
        Me.Txtleysaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtleysaldo.Location = New System.Drawing.Point(392, 28)
        Me.Txtleysaldo.Name = "Txtleysaldo"
        Me.Txtleysaldo.Size = New System.Drawing.Size(69, 23)
        Me.Txtleysaldo.TabIndex = 7
        Me.Txtleysaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(485, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 13)
        Me.Label19.TabIndex = 163
        Me.Label19.Text = "Gramos Puros"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(414, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(24, 13)
        Me.Label20.TabIndex = 162
        Me.Label20.Text = "Ley"
        '
        'BtnConsulta
        '
        Me.BtnConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsulta.Image = CType(resources.GetObject("BtnConsulta.Image"), System.Drawing.Image)
        Me.BtnConsulta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConsulta.Location = New System.Drawing.Point(230, 67)
        Me.BtnConsulta.Name = "BtnConsulta"
        Me.BtnConsulta.Size = New System.Drawing.Size(107, 28)
        Me.BtnConsulta.TabIndex = 10
        Me.BtnConsulta.Text = "Consulta"
        Me.BtnConsulta.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(0, 140)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(672, 58)
        Me.GroupBox2.TabIndex = 159
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'TxtInggrpuros
        '
        Me.TxtInggrpuros.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInggrpuros.Location = New System.Drawing.Point(563, 78)
        Me.TxtInggrpuros.Name = "TxtInggrpuros"
        Me.TxtInggrpuros.Size = New System.Drawing.Size(100, 23)
        Me.TxtInggrpuros.TabIndex = 13
        Me.TxtInggrpuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIngley
        '
        Me.TxtIngley.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIngley.Location = New System.Drawing.Point(478, 78)
        Me.TxtIngley.Name = "TxtIngley"
        Me.TxtIngley.Size = New System.Drawing.Size(69, 23)
        Me.TxtIngley.TabIndex = 12
        Me.TxtIngley.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtInggrbrutos
        '
        Me.TxtInggrbrutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInggrbrutos.Location = New System.Drawing.Point(360, 78)
        Me.TxtInggrbrutos.Name = "TxtInggrbrutos"
        Me.TxtInggrbrutos.Size = New System.Drawing.Size(100, 23)
        Me.TxtInggrbrutos.TabIndex = 11
        Me.TxtInggrbrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNumTraslado
        '
        Me.TxtNumTraslado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumTraslado.Location = New System.Drawing.Point(161, 69)
        Me.TxtNumTraslado.Name = "TxtNumTraslado"
        Me.TxtNumTraslado.Size = New System.Drawing.Size(63, 23)
        Me.TxtNumTraslado.TabIndex = 9
        Me.TxtNumTraslado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(581, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 13)
        Me.Label13.TabIndex = 113
        Me.Label13.Text = "Gramos Puros"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(500, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 112
        Me.Label10.Text = "Ley"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(372, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 111
        Me.Label9.Text = "Gramos Brutos"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(150, 13)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "No. de Traslado de Fundición:"
        '
        'TxtNomPaciente
        '
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomPaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.TxtNomPaciente.Location = New System.Drawing.Point(76, 595)
        Me.TxtNomPaciente.Name = "TxtNomPaciente"
        Me.TxtNomPaciente.Size = New System.Drawing.Size(21, 21)
        Me.TxtNomPaciente.TabIndex = 158
        Me.TxtNomPaciente.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtNumDoc)
        Me.Panel2.Controls.Add(Me.Txtced_cl)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.DTPfechaactual)
        Me.Panel2.Controls.Add(Me.Label32)
        Me.Panel2.Controls.Add(Me.TxtCiudad)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.TxtPagado)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(23, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(673, 95)
        Me.Panel2.TabIndex = 146
        '
        'TxtNumDoc
        '
        Me.TxtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumDoc.Location = New System.Drawing.Point(117, 3)
        Me.TxtNumDoc.Name = "TxtNumDoc"
        Me.TxtNumDoc.Size = New System.Drawing.Size(101, 24)
        Me.TxtNumDoc.TabIndex = 1
        Me.TxtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txtced_cl
        '
        Me.Txtced_cl.Enabled = False
        Me.Txtced_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtced_cl.Location = New System.Drawing.Point(117, 32)
        Me.Txtced_cl.Name = "Txtced_cl"
        Me.Txtced_cl.Size = New System.Drawing.Size(116, 23)
        Me.Txtced_cl.TabIndex = 2
        Me.Txtced_cl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Nit:"
        '
        'DTPfechaactual
        '
        Me.DTPfechaactual.Enabled = False
        Me.DTPfechaactual.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPfechaactual.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPfechaactual.Location = New System.Drawing.Point(504, 31)
        Me.DTPfechaactual.Name = "DTPfechaactual"
        Me.DTPfechaactual.Size = New System.Drawing.Size(110, 23)
        Me.DTPfechaactual.TabIndex = 4
        Me.DTPfechaactual.Value = New Date(2018, 5, 11, 0, 0, 0, 0)
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(422, 36)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(76, 13)
        Me.Label32.TabIndex = 105
        Me.Label32.Text = "Fecha  Actual:"
        '
        'TxtCiudad
        '
        Me.TxtCiudad.Enabled = False
        Me.TxtCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCiudad.Location = New System.Drawing.Point(288, 31)
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(116, 21)
        Me.TxtCiudad.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Empresa:"
        '
        'TxtPagado
        '
        Me.TxtPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPagado.Location = New System.Drawing.Point(116, 60)
        Me.TxtPagado.Name = "TxtPagado"
        Me.TxtPagado.Size = New System.Drawing.Size(498, 24)
        Me.TxtPagado.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(242, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Ciudad: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(46, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "No. Ingreso:"
        '
        'BtnImpriCaja
        '
        Me.BtnImpriCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpriCaja.Image = CType(resources.GetObject("BtnImpriCaja.Image"), System.Drawing.Image)
        Me.BtnImpriCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImpriCaja.Location = New System.Drawing.Point(430, 585)
        Me.BtnImpriCaja.Name = "BtnImpriCaja"
        Me.BtnImpriCaja.Size = New System.Drawing.Size(130, 40)
        Me.BtnImpriCaja.TabIndex = 21
        Me.BtnImpriCaja.Text = "        Imprimir Ingresos"
        Me.BtnImpriCaja.UseVisualStyleBackColor = True
        '
        'BtnRegreCaja
        '
        Me.BtnRegreCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRegreCaja.Image = CType(resources.GetObject("BtnRegreCaja.Image"), System.Drawing.Image)
        Me.BtnRegreCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRegreCaja.Location = New System.Drawing.Point(566, 585)
        Me.BtnRegreCaja.Name = "BtnRegreCaja"
        Me.BtnRegreCaja.Size = New System.Drawing.Size(130, 40)
        Me.BtnRegreCaja.TabIndex = 22
        Me.BtnRegreCaja.Text = "   &Regresar"
        Me.BtnRegreCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRegreCaja.UseVisualStyleBackColor = True
        '
        'TxtSurname
        '
        Me.TxtSurname.Enabled = False
        Me.TxtSurname.Location = New System.Drawing.Point(47, 595)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(19, 20)
        Me.TxtSurname.TabIndex = 157
        Me.TxtSurname.Visible = False
        '
        'TxtName
        '
        Me.TxtName.Enabled = False
        Me.TxtName.Location = New System.Drawing.Point(15, 595)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(27, 20)
        Me.TxtName.TabIndex = 156
        Me.TxtName.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 577)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 13)
        Me.Label11.TabIndex = 155
        Me.Label11.Text = "Cantidad de Registros:"
        '
        'LblRegistros
        '
        Me.LblRegistros.AutoSize = True
        Me.LblRegistros.Location = New System.Drawing.Point(137, 578)
        Me.LblRegistros.Name = "LblRegistros"
        Me.LblRegistros.Size = New System.Drawing.Size(10, 13)
        Me.LblRegistros.TabIndex = 154
        Me.LblRegistros.Text = "."
        '
        'BtnNuevoCaja
        '
        Me.BtnNuevoCaja.BackColor = System.Drawing.Color.Transparent
        Me.BtnNuevoCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevoCaja.ForeColor = System.Drawing.Color.Black
        Me.BtnNuevoCaja.Image = CType(resources.GetObject("BtnNuevoCaja.Image"), System.Drawing.Image)
        Me.BtnNuevoCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevoCaja.Location = New System.Drawing.Point(294, 585)
        Me.BtnNuevoCaja.Name = "BtnNuevoCaja"
        Me.BtnNuevoCaja.Size = New System.Drawing.Size(130, 40)
        Me.BtnNuevoCaja.TabIndex = 20
        Me.BtnNuevoCaja.Text = "     Nuevo Ingreso"
        Me.BtnNuevoCaja.UseVisualStyleBackColor = False
        '
        'BtnGuardaIngreso
        '
        Me.BtnGuardaIngreso.BackColor = System.Drawing.Color.Transparent
        Me.BtnGuardaIngreso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGuardaIngreso.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnGuardaIngreso.Image = CType(resources.GetObject("BtnGuardaIngreso.Image"), System.Drawing.Image)
        Me.BtnGuardaIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardaIngreso.Location = New System.Drawing.Point(294, 585)
        Me.BtnGuardaIngreso.Name = "BtnGuardaIngreso"
        Me.BtnGuardaIngreso.Size = New System.Drawing.Size(130, 40)
        Me.BtnGuardaIngreso.TabIndex = 22
        Me.BtnGuardaIngreso.Text = "      Guardar Ingreso"
        Me.BtnGuardaIngreso.UseVisualStyleBackColor = False
        '
        'DGVingresos
        '
        Me.DGVingresos.AllowUserToAddRows = False
        Me.DGVingresos.AllowUserToDeleteRows = False
        Me.DGVingresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVingresos.Location = New System.Drawing.Point(22, 400)
        Me.DGVingresos.Name = "DGVingresos"
        Me.DGVingresos.ReadOnly = True
        Me.DGVingresos.Size = New System.Drawing.Size(673, 174)
        Me.DGVingresos.TabIndex = 18
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(723, 40)
        Me.Panel1.TabIndex = 153
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
        Me.BtnX.Location = New System.Drawing.Point(685, 3)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 56
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(117, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(479, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "DETALLE DE LOS INGRESOS  POR TRASLADOS DE FUNDICIÓN"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.TxtNuevosBrutos)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.BtnAjuste)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Txtnuevagrpuros)
        Me.GroupBox3.Controls.Add(Me.Txtnuevaley)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Txtajuste)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.TxtConcepto)
        Me.GroupBox3.Location = New System.Drawing.Point(23, 297)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(672, 97)
        Me.GroupBox3.TabIndex = 159
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ingreso de Material Fundido"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(620, 33)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(37, 13)
        Me.Label21.TabIndex = 142
        Me.Label21.Text = "Gr. Br."
        '
        'TxtNuevosBrutos
        '
        Me.TxtNuevosBrutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNuevosBrutos.Location = New System.Drawing.Point(161, 28)
        Me.TxtNuevosBrutos.Name = "TxtNuevosBrutos"
        Me.TxtNuevosBrutos.Size = New System.Drawing.Size(93, 23)
        Me.TxtNuevosBrutos.TabIndex = 14
        Me.TxtNuevosBrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(170, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 141
        Me.Label12.Text = "Gramos Brutos"
        '
        'BtnAjuste
        '
        Me.BtnAjuste.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAjuste.Image = CType(resources.GetObject("BtnAjuste.Image"), System.Drawing.Image)
        Me.BtnAjuste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAjuste.Location = New System.Drawing.Point(441, 16)
        Me.BtnAjuste.Name = "BtnAjuste"
        Me.BtnAjuste.Size = New System.Drawing.Size(105, 36)
        Me.BtnAjuste.TabIndex = 17
        Me.BtnAjuste.Text = "       Cálculo Ajuste"
        Me.BtnAjuste.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 32)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(141, 13)
        Me.Label18.TabIndex = 139
        Me.Label18.Text = "Ingreso de Material Fundido:"
        '
        'Txtnuevagrpuros
        '
        Me.Txtnuevagrpuros.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtnuevagrpuros.Location = New System.Drawing.Point(335, 28)
        Me.Txtnuevagrpuros.Name = "Txtnuevagrpuros"
        Me.Txtnuevagrpuros.Size = New System.Drawing.Size(100, 23)
        Me.Txtnuevagrpuros.TabIndex = 16
        Me.Txtnuevagrpuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txtnuevaley
        '
        Me.Txtnuevaley.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtnuevaley.Location = New System.Drawing.Point(260, 28)
        Me.Txtnuevaley.Name = "Txtnuevaley"
        Me.Txtnuevaley.Size = New System.Drawing.Size(69, 23)
        Me.Txtnuevaley.TabIndex = 15
        Me.Txtnuevaley.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(353, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 136
        Me.Label16.Text = "Gramos Puros"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(282, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(24, 13)
        Me.Label17.TabIndex = 135
        Me.Label17.Text = "Ley"
        '
        'Txtajuste
        '
        Me.Txtajuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtajuste.Location = New System.Drawing.Point(555, 28)
        Me.Txtajuste.Name = "Txtajuste"
        Me.Txtajuste.Size = New System.Drawing.Size(60, 23)
        Me.Txtajuste.TabIndex = 18
        Me.Txtajuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(555, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 13)
        Me.Label14.TabIndex = 132
        Me.Label14.Text = "Ajuste de la Fundición"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 13)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "Observaciones del Ingreso:"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConcepto.Location = New System.Drawing.Point(149, 57)
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(514, 25)
        Me.TxtConcepto.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(291, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 13)
        Me.Label5.TabIndex = 161
        Me.Label5.Text = "Formato de Ingreso: ""99.99"""
        '
        'TxtNumImp
        '
        Me.TxtNumImp.Enabled = False
        Me.TxtNumImp.Location = New System.Drawing.Point(24, 277)
        Me.TxtNumImp.Name = "TxtNumImp"
        Me.TxtNumImp.Size = New System.Drawing.Size(29, 20)
        Me.TxtNumImp.TabIndex = 162
        Me.TxtNumImp.Visible = False
        '
        'TxtSalLey
        '
        Me.TxtSalLey.Enabled = False
        Me.TxtSalLey.Location = New System.Drawing.Point(103, 619)
        Me.TxtSalLey.Name = "TxtSalLey"
        Me.TxtSalLey.Size = New System.Drawing.Size(69, 20)
        Me.TxtSalLey.TabIndex = 163
        Me.TxtSalLey.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtSalLey.Visible = False
        '
        'TxtSalPu
        '
        Me.TxtSalPu.Enabled = False
        Me.TxtSalPu.Location = New System.Drawing.Point(178, 619)
        Me.TxtSalPu.Name = "TxtSalPu"
        Me.TxtSalPu.Size = New System.Drawing.Size(69, 20)
        Me.TxtSalPu.TabIndex = 164
        Me.TxtSalPu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtSalPu.Visible = False
        '
        'TxtSalBrutos
        '
        Me.TxtSalBrutos.Enabled = False
        Me.TxtSalBrutos.Location = New System.Drawing.Point(23, 619)
        Me.TxtSalBrutos.Name = "TxtSalBrutos"
        Me.TxtSalBrutos.Size = New System.Drawing.Size(69, 20)
        Me.TxtSalBrutos.TabIndex = 165
        Me.TxtSalBrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtSalBrutos.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(723, 657)
        Me.Panel3.TabIndex = 166
        '
        'FrmCompraTraslado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(723, 657)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtSalBrutos)
        Me.Controls.Add(Me.TxtSalPu)
        Me.Controls.Add(Me.TxtSalLey)
        Me.Controls.Add(Me.TxtNumImp)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtNomPaciente)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnImpriCaja)
        Me.Controls.Add(Me.BtnRegreCaja)
        Me.Controls.Add(Me.TxtSurname)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LblRegistros)
        Me.Controls.Add(Me.BtnNuevoCaja)
        Me.Controls.Add(Me.BtnGuardaIngreso)
        Me.Controls.Add(Me.DGVingresos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(723, 657)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(723, 657)
        Me.Name = "FrmCompraTraslado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " AppMinerGold - Ingresos de Material"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGVingresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtNomPaciente As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtNumDoc As TextBox
    Friend WithEvents Txtced_cl As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPfechaactual As DateTimePicker
    Friend WithEvents Label32 As Label
    Friend WithEvents TxtCiudad As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtPagado As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnImpriCaja As Button
    Friend WithEvents BtnRegreCaja As Button
    Friend WithEvents TxtSurname As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents LblRegistros As Label
    Friend WithEvents BtnNuevoCaja As Button
    Friend WithEvents BtnGuardaIngreso As Button
    Friend WithEvents DGVingresos As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtInggrpuros As TextBox
    Friend WithEvents TxtIngley As TextBox
    Friend WithEvents TxtInggrbrutos As TextBox
    Friend WithEvents TxtNumTraslado As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Txtnuevagrpuros As TextBox
    Friend WithEvents Txtnuevaley As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Txtajuste As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtConcepto As TextBox
    Friend WithEvents BtnConsulta As Button
    Friend WithEvents BtnAjuste As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Txtpurossaldo As TextBox
    Friend WithEvents Txtleysaldo As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TxtNumImp As TextBox
    Friend WithEvents TxtSalLey As TextBox
    Friend WithEvents TxtSalPu As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TxtNuevosBrutos As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtBrutosSaldo As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TxtSalBrutos As TextBox
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel3 As Panel
End Class
