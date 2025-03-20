<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetEmpresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDetEmpresa))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnImprime = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnModifica = New System.Windows.Forms.Button()
        Me.BtnGuardaCambios = New System.Windows.Forms.Button()
        Me.BtnDatos = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CboDpto = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtRut = New System.Windows.Forms.TextBox()
        Me.CboZonas = New System.Windows.Forms.ComboBox()
        Me.CboMateriales = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CboDetAct = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.CBOciudAct = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CboAct2 = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CboAct1 = New System.Windows.Forms.ComboBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.DTPinicioACT = New System.Windows.Forms.DateTimePicker()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.DTPact2 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtObsEmp = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBOrol = New System.Windows.Forms.ComboBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.CBOtipoper = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TxtSurName = New System.Windows.Forms.TextBox()
        Me.TxtNomPaciente = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtNomApe = New System.Windows.Forms.TextBox()
        Me.DTPfechaactual = New System.Windows.Forms.DateTimePicker()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Txtced_cl = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.PanelTitulo = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNomCliente = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtCodZonas = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnImprime)
        Me.Panel2.Controls.Add(Me.BtnGuardar)
        Me.Panel2.Controls.Add(Me.BtnNuevo)
        Me.Panel2.Controls.Add(Me.BtnModifica)
        Me.Panel2.Controls.Add(Me.BtnGuardaCambios)
        Me.Panel2.Controls.Add(Me.BtnDatos)
        Me.Panel2.Location = New System.Drawing.Point(195, 465)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(636, 52)
        Me.Panel2.TabIndex = 47
        '
        'BtnImprime
        '
        Me.BtnImprime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImprime.Image = CType(resources.GetObject("BtnImprime.Image"), System.Drawing.Image)
        Me.BtnImprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprime.Location = New System.Drawing.Point(524, 9)
        Me.BtnImprime.Name = "BtnImprime"
        Me.BtnImprime.Size = New System.Drawing.Size(100, 35)
        Me.BtnImprime.TabIndex = 27
        Me.BtnImprime.Text = "   &Imprimir"
        Me.BtnImprime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnImprime.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(421, 9)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(100, 35)
        Me.BtnGuardar.TabIndex = 26
        Me.BtnGuardar.Text = "   Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(108, 9)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(100, 35)
        Me.BtnNuevo.TabIndex = 23
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'BtnModifica
        '
        Me.BtnModifica.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnModifica.Image = CType(resources.GetObject("BtnModifica.Image"), System.Drawing.Image)
        Me.BtnModifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnModifica.Location = New System.Drawing.Point(212, 9)
        Me.BtnModifica.Name = "BtnModifica"
        Me.BtnModifica.Size = New System.Drawing.Size(100, 35)
        Me.BtnModifica.TabIndex = 24
        Me.BtnModifica.Text = "   Modificar"
        Me.BtnModifica.UseVisualStyleBackColor = True
        '
        'BtnGuardaCambios
        '
        Me.BtnGuardaCambios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGuardaCambios.Image = CType(resources.GetObject("BtnGuardaCambios.Image"), System.Drawing.Image)
        Me.BtnGuardaCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardaCambios.Location = New System.Drawing.Point(317, 9)
        Me.BtnGuardaCambios.Name = "BtnGuardaCambios"
        Me.BtnGuardaCambios.Size = New System.Drawing.Size(100, 35)
        Me.BtnGuardaCambios.TabIndex = 25
        Me.BtnGuardaCambios.Text = "   Guarda Cambios"
        Me.BtnGuardaCambios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardaCambios.UseVisualStyleBackColor = True
        '
        'BtnDatos
        '
        Me.BtnDatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDatos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDatos.Image = CType(resources.GetObject("BtnDatos.Image"), System.Drawing.Image)
        Me.BtnDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDatos.Location = New System.Drawing.Point(4, 9)
        Me.BtnDatos.Name = "BtnDatos"
        Me.BtnDatos.Size = New System.Drawing.Size(100, 35)
        Me.BtnDatos.TabIndex = 22
        Me.BtnDatos.Text = "     Act. Datos"
        Me.BtnDatos.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CboDpto)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TxtRut)
        Me.GroupBox3.Controls.Add(Me.CboZonas)
        Me.GroupBox3.Controls.Add(Me.CboMateriales)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.CboDetAct)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.CBOciudAct)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 109)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(967, 81)
        Me.GroupBox3.TabIndex = 44
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalles de la Actividad del Proveedor"
        '
        'CboDpto
        '
        Me.CboDpto.FormattingEnabled = True
        Me.CboDpto.Location = New System.Drawing.Point(402, 48)
        Me.CboDpto.Name = "CboDpto"
        Me.CboDpto.Size = New System.Drawing.Size(279, 21)
        Me.CboDpto.TabIndex = 149
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(312, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 150
        Me.Label8.Text = "Departamento:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(728, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "No. de RUT:"
        '
        'TxtRut
        '
        Me.TxtRut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRut.Location = New System.Drawing.Point(803, 46)
        Me.TxtRut.Name = "TxtRut"
        Me.TxtRut.Size = New System.Drawing.Size(132, 21)
        Me.TxtRut.TabIndex = 14
        Me.TxtRut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CboZonas
        '
        Me.CboZonas.FormattingEnabled = True
        Me.CboZonas.Location = New System.Drawing.Point(422, 18)
        Me.CboZonas.Name = "CboZonas"
        Me.CboZonas.Size = New System.Drawing.Size(263, 21)
        Me.CboZonas.TabIndex = 116
        '
        'CboMateriales
        '
        Me.CboMateriales.FormattingEnabled = True
        Me.CboMateriales.Location = New System.Drawing.Point(845, 17)
        Me.CboMateriales.Name = "CboMateriales"
        Me.CboMateriales.Size = New System.Drawing.Size(99, 21)
        Me.CboMateriales.TabIndex = 115
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(720, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(119, 13)
        Me.Label22.TabIndex = 109
        Me.Label22.Text = "Materiales Autorizados :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(939, 48)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(13, 16)
        Me.Label19.TabIndex = 105
        Me.Label19.Text = "*"
        '
        'CboDetAct
        '
        Me.CboDetAct.FormattingEnabled = True
        Me.CboDetAct.Location = New System.Drawing.Point(134, 18)
        Me.CboDetAct.Name = "CboDetAct"
        Me.CboDetAct.Size = New System.Drawing.Size(191, 21)
        Me.CboDetAct.TabIndex = 1
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(691, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(13, 16)
        Me.Label20.TabIndex = 106
        Me.Label20.Text = "*"
        '
        'CBOciudAct
        '
        Me.CBOciudAct.FormattingEnabled = True
        Me.CBOciudAct.Location = New System.Drawing.Point(61, 47)
        Me.CBOciudAct.Name = "CBOciudAct"
        Me.CBOciudAct.Size = New System.Drawing.Size(209, 21)
        Me.CBOciudAct.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 103
        Me.Label10.Text = "Ciudad: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(331, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Zona Autoizada:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Detalle de la Actividad:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CboAct2)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.CboAct1)
        Me.GroupBox2.Controls.Add(Me.Label56)
        Me.GroupBox2.Controls.Add(Me.DTPinicioACT)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.DTPact2)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 194)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(967, 85)
        Me.GroupBox2.TabIndex = 45
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ingreso de Las Actividades del Provedor"
        '
        'CboAct2
        '
        Me.CboAct2.FormattingEnabled = True
        Me.CboAct2.Location = New System.Drawing.Point(119, 49)
        Me.CboAct2.Name = "CboAct2"
        Me.CboAct2.Size = New System.Drawing.Size(621, 21)
        Me.CboAct2.TabIndex = 10
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 13)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Actividad Principal: "
        '
        'CboAct1
        '
        Me.CboAct1.FormattingEnabled = True
        Me.CboAct1.Location = New System.Drawing.Point(119, 20)
        Me.CboAct1.Name = "CboAct1"
        Me.CboAct1.Size = New System.Drawing.Size(621, 21)
        Me.CboAct1.TabIndex = 8
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(746, 23)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(82, 13)
        Me.Label56.TabIndex = 11
        Me.Label56.Text = "Inicio Actividad:"
        '
        'DTPinicioACT
        '
        Me.DTPinicioACT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPinicioACT.Location = New System.Drawing.Point(840, 20)
        Me.DTPinicioACT.Name = "DTPinicioACT"
        Me.DTPinicioACT.Size = New System.Drawing.Size(104, 20)
        Me.DTPinicioACT.TabIndex = 9
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(13, 52)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(66, 13)
        Me.Label35.TabIndex = 12
        Me.Label35.Text = "Actividad 2: "
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(746, 53)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(82, 13)
        Me.Label34.TabIndex = 13
        Me.Label34.Text = "Inicio Actividad:"
        '
        'DTPact2
        '
        Me.DTPact2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPact2.Location = New System.Drawing.Point(840, 50)
        Me.DTPact2.Name = "DTPact2"
        Me.DTPact2.Size = New System.Drawing.Size(104, 20)
        Me.DTPact2.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtObsEmp)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CBOrol)
        Me.GroupBox1.Controls.Add(Me.LinkLabel3)
        Me.GroupBox1.Controls.Add(Me.CBOtipoper)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 283)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(967, 173)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingresar los Datos del Proveedor"
        '
        'TxtObsEmp
        '
        Me.TxtObsEmp.Location = New System.Drawing.Point(560, 108)
        Me.TxtObsEmp.Multiline = True
        Me.TxtObsEmp.Name = "TxtObsEmp"
        Me.TxtObsEmp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObsEmp.Size = New System.Drawing.Size(376, 40)
        Me.TxtObsEmp.TabIndex = 15
        Me.TxtObsEmp.Text = "N/A"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(474, 108)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 13)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "Observaciones:"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(798, 72)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(121, 13)
        Me.LinkLabel2.TabIndex = 102
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "DIAN, Consulta de RUT"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(633, 72)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(107, 13)
        Me.LinkLabel1.TabIndex = 101
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Inicio de Sesión Dian"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(639, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(183, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 105
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(35, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(184, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 104
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Rol :"
        '
        'CBOrol
        '
        Me.CBOrol.FormattingEnabled = True
        Me.CBOrol.Location = New System.Drawing.Point(53, 105)
        Me.CBOrol.Name = "CBOrol"
        Me.CBOrol.Size = New System.Drawing.Size(155, 21)
        Me.CBOrol.TabIndex = 12
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(81, 72)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(85, 13)
        Me.LinkLabel3.TabIndex = 100
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Consulta Rucom"
        '
        'CBOtipoper
        '
        Me.CBOtipoper.FormattingEnabled = True
        Me.CBOtipoper.Location = New System.Drawing.Point(296, 105)
        Me.CBOtipoper.Name = "CBOtipoper"
        Me.CBOtipoper.Size = New System.Drawing.Size(155, 21)
        Me.CBOtipoper.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(214, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Tipo Persona :"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.TextBox5)
        Me.Panel7.Controls.Add(Me.TextBox2)
        Me.Panel7.Controls.Add(Me.TxtSurName)
        Me.Panel7.Controls.Add(Me.TxtNomPaciente)
        Me.Panel7.Controls.Add(Me.TxtName)
        Me.Panel7.Location = New System.Drawing.Point(11, 461)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(166, 75)
        Me.Panel7.TabIndex = 48
        Me.Panel7.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(76, 52)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(78, 20)
        Me.TextBox5.TabIndex = 56
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(76, 27)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(78, 20)
        Me.TextBox2.TabIndex = 55
        '
        'TxtSurName
        '
        Me.TxtSurName.Location = New System.Drawing.Point(80, 4)
        Me.TxtSurName.Name = "TxtSurName"
        Me.TxtSurName.Size = New System.Drawing.Size(83, 20)
        Me.TxtSurName.TabIndex = 53
        '
        'TxtNomPaciente
        '
        Me.TxtNomPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomPaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.TxtNomPaciente.Location = New System.Drawing.Point(5, 26)
        Me.TxtNomPaciente.Name = "TxtNomPaciente"
        Me.TxtNomPaciente.Size = New System.Drawing.Size(65, 26)
        Me.TxtNomPaciente.TabIndex = 54
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(5, 4)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(69, 20)
        Me.TxtName.TabIndex = 52
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtNomApe)
        Me.Panel1.Controls.Add(Me.DTPfechaactual)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Controls.Add(Me.Txtced_cl)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label74)
        Me.Panel1.Location = New System.Drawing.Point(24, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(822, 42)
        Me.Panel1.TabIndex = 43
        '
        'TxtNomApe
        '
        Me.TxtNomApe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomApe.Location = New System.Drawing.Point(171, 7)
        Me.TxtNomApe.Name = "TxtNomApe"
        Me.TxtNomApe.Size = New System.Drawing.Size(408, 26)
        Me.TxtNomApe.TabIndex = 2
        '
        'DTPfechaactual
        '
        Me.DTPfechaactual.Enabled = False
        Me.DTPfechaactual.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPfechaactual.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPfechaactual.Location = New System.Drawing.Point(693, 10)
        Me.DTPfechaactual.Name = "DTPfechaactual"
        Me.DTPfechaactual.Size = New System.Drawing.Size(112, 23)
        Me.DTPfechaactual.TabIndex = 3
        Me.DTPfechaactual.Value = New Date(2018, 5, 11, 0, 0, 0, 0)
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(583, 15)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(101, 13)
        Me.Label32.TabIndex = 3
        Me.Label32.Text = "Fecha Visita Actual:"
        '
        'Txtced_cl
        '
        Me.Txtced_cl.Enabled = False
        Me.Txtced_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtced_cl.Location = New System.Drawing.Point(48, 8)
        Me.Txtced_cl.Name = "Txtced_cl"
        Me.Txtced_cl.Size = New System.Drawing.Size(78, 23)
        Me.Txtced_cl.TabIndex = 1
        Me.Txtced_cl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cédula :"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(130, 13)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(42, 13)
        Me.Label74.TabIndex = 2
        Me.Label74.Text = "Cliente:"
        '
        'PanelTitulo
        '
        Me.PanelTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.PanelTitulo.Controls.Add(Me.BtnX)
        Me.PanelTitulo.Controls.Add(Me.Label4)
        Me.PanelTitulo.Location = New System.Drawing.Point(0, 0)
        Me.PanelTitulo.Name = "PanelTitulo"
        Me.PanelTitulo.Size = New System.Drawing.Size(1016, 40)
        Me.PanelTitulo.TabIndex = 49
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(982, 8)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 45
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(328, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(302, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "INGRESO DE LOS DATOS DE PROVEEDORES"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtNomCliente
        '
        Me.TxtNomCliente.Location = New System.Drawing.Point(863, 69)
        Me.TxtNomCliente.Name = "TxtNomCliente"
        Me.TxtNomCliente.Size = New System.Drawing.Size(105, 20)
        Me.TxtNomCliente.TabIndex = 50
        Me.TxtNomCliente.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TxtCodZonas)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1016, 549)
        Me.Panel3.TabIndex = 51
        '
        'TxtCodZonas
        '
        Me.TxtCodZonas.Location = New System.Drawing.Point(862, 43)
        Me.TxtCodZonas.Name = "TxtCodZonas"
        Me.TxtCodZonas.Size = New System.Drawing.Size(80, 20)
        Me.TxtCodZonas.TabIndex = 50
        Me.TxtCodZonas.Visible = False
        '
        'FrmDetEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1016, 601)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtNomCliente)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTitulo)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1016, 601)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1016, 601)
        Me.Name = "FrmDetEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Ingreso de Datos"
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.PanelTitulo.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnImprime As Button
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents BtnNuevo As Button
    Friend WithEvents BtnModifica As Button
    Friend WithEvents BtnGuardaCambios As Button
    Friend WithEvents BtnDatos As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CboMateriales As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents CboDetAct As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents CBOciudAct As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CboAct2 As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents CboAct1 As ComboBox
    Friend WithEvents Label56 As Label
    Friend WithEvents DTPinicioACT As DateTimePicker
    Friend WithEvents Label35 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents DTPact2 As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtRut As TextBox
    Friend WithEvents TxtObsEmp As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CBOrol As ComboBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents CBOtipoper As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TxtSurName As TextBox
    Friend WithEvents TxtNomPaciente As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtNomApe As TextBox
    Friend WithEvents DTPfechaactual As DateTimePicker
    Friend WithEvents Label32 As Label
    Friend WithEvents Txtced_cl As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label74 As Label
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtNomCliente As TextBox
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents CboZonas As ComboBox
    Friend WithEvents TxtCodZonas As TextBox
    Friend WithEvents CboDpto As ComboBox
    Friend WithEvents Label8 As Label
End Class
