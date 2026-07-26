<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAdmin
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAdmin))
        Me.PanelBarraTitulo = New System.Windows.Forms.Panel()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.BtnMaximizar = New System.Windows.Forms.Button()
        Me.BtnMinimizar = New System.Windows.Forms.Button()
        Me.BtnRestaurar = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.BtnCopiaSeg = New System.Windows.Forms.Button()
        Me.BtnReportes = New System.Windows.Forms.Button()
        Me.BtnAyudas = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnCajaMenor = New System.Windows.Forms.Button()
        Me.BtnFundicion = New System.Windows.Forms.Button()
        Me.BtnCompras = New System.Windows.Forms.Button()
        Me.BtnTasas = New System.Windows.Forms.Button()
        Me.BtnLinks = New System.Windows.Forms.Button()
        Me.BtnIngresos = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnMenu = New System.Windows.Forms.Button()
        Me.PanelContenedor = New System.Windows.Forms.Panel()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.LblHora = New System.Windows.Forms.Label()
        Me.PanelEstado = New System.Windows.Forms.Panel()
        Me.TssLicencia = New System.Windows.Forms.Label()
        Me.TssUsuario = New System.Windows.Forms.Label()
        Me.TssEstado = New System.Windows.Forms.Label()
        Me.TssEmpresa = New System.Windows.Forms.Label()
        Me.TmOcultar = New System.Windows.Forms.Timer(Me.components)
        Me.TmMostrar = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.wbMonitor = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.PanelBarraTitulo.SuspendLayout()
        Me.PanelMenu.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContenedor.SuspendLayout()
        Me.PanelEstado.SuspendLayout()
        CType(Me.wbMonitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBarraTitulo
        '
        Me.PanelBarraTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.PanelBarraTitulo.Controls.Add(Me.LblTitulo)
        Me.PanelBarraTitulo.Controls.Add(Me.BtnMaximizar)
        Me.PanelBarraTitulo.Controls.Add(Me.BtnMinimizar)
        Me.PanelBarraTitulo.Controls.Add(Me.BtnRestaurar)
        Me.PanelBarraTitulo.Controls.Add(Me.BtnCerrar)
        Me.PanelBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBarraTitulo.Location = New System.Drawing.Point(0, 0)
        Me.PanelBarraTitulo.Name = "PanelBarraTitulo"
        Me.PanelBarraTitulo.Size = New System.Drawing.Size(1150, 35)
        Me.PanelBarraTitulo.TabIndex = 0
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(9, 8)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(227, 17)
        Me.LblTitulo.TabIndex = 4
        Me.LblTitulo.Text = "AppMinerGold, Menú Principal"
        '
        'BtnMaximizar
        '
        Me.BtnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMaximizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnMaximizar.FlatAppearance.BorderSize = 0
        Me.BtnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMaximizar.Image = CType(resources.GetObject("BtnMaximizar.Image"), System.Drawing.Image)
        Me.BtnMaximizar.Location = New System.Drawing.Point(990, 0)
        Me.BtnMaximizar.Name = "BtnMaximizar"
        Me.BtnMaximizar.Size = New System.Drawing.Size(40, 35)
        Me.BtnMaximizar.TabIndex = 3
        Me.BtnMaximizar.UseVisualStyleBackColor = True
        '
        'BtnMinimizar
        '
        Me.BtnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMinimizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnMinimizar.FlatAppearance.BorderSize = 0
        Me.BtnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMinimizar.Image = CType(resources.GetObject("BtnMinimizar.Image"), System.Drawing.Image)
        Me.BtnMinimizar.Location = New System.Drawing.Point(1030, 0)
        Me.BtnMinimizar.Name = "BtnMinimizar"
        Me.BtnMinimizar.Size = New System.Drawing.Size(40, 35)
        Me.BtnMinimizar.TabIndex = 2
        Me.BtnMinimizar.UseVisualStyleBackColor = True
        '
        'BtnRestaurar
        '
        Me.BtnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRestaurar.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnRestaurar.FlatAppearance.BorderSize = 0
        Me.BtnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRestaurar.Image = CType(resources.GetObject("BtnRestaurar.Image"), System.Drawing.Image)
        Me.BtnRestaurar.Location = New System.Drawing.Point(1070, 0)
        Me.BtnRestaurar.Name = "BtnRestaurar"
        Me.BtnRestaurar.Size = New System.Drawing.Size(40, 35)
        Me.BtnRestaurar.TabIndex = 1
        Me.BtnRestaurar.UseVisualStyleBackColor = True
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCerrar.FlatAppearance.BorderSize = 0
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.Location = New System.Drawing.Point(1110, 0)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(40, 35)
        Me.BtnCerrar.TabIndex = 0
        Me.BtnCerrar.UseVisualStyleBackColor = True
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.PanelMenu.Controls.Add(Me.BtnCopiaSeg)
        Me.PanelMenu.Controls.Add(Me.BtnReportes)
        Me.PanelMenu.Controls.Add(Me.BtnAyudas)
        Me.PanelMenu.Controls.Add(Me.BtnSalir)
        Me.PanelMenu.Controls.Add(Me.BtnCajaMenor)
        Me.PanelMenu.Controls.Add(Me.BtnFundicion)
        Me.PanelMenu.Controls.Add(Me.BtnCompras)
        Me.PanelMenu.Controls.Add(Me.BtnTasas)
        Me.PanelMenu.Controls.Add(Me.BtnLinks)
        Me.PanelMenu.Controls.Add(Me.BtnIngresos)
        Me.PanelMenu.Controls.Add(Me.PictureBox1)
        Me.PanelMenu.Controls.Add(Me.BtnMenu)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 35)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(220, 736)
        Me.PanelMenu.TabIndex = 1
        '
        'BtnCopiaSeg
        '
        Me.BtnCopiaSeg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCopiaSeg.FlatAppearance.BorderSize = 0
        Me.BtnCopiaSeg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BtnCopiaSeg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnCopiaSeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCopiaSeg.ForeColor = System.Drawing.Color.White
        Me.BtnCopiaSeg.Image = CType(resources.GetObject("BtnCopiaSeg.Image"), System.Drawing.Image)
        Me.BtnCopiaSeg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCopiaSeg.Location = New System.Drawing.Point(0, 490)
        Me.BtnCopiaSeg.Name = "BtnCopiaSeg"
        Me.BtnCopiaSeg.Size = New System.Drawing.Size(220, 42)
        Me.BtnCopiaSeg.TabIndex = 8
        Me.BtnCopiaSeg.Text = "C&opia de Seguridad"
        Me.BtnCopiaSeg.UseVisualStyleBackColor = True
        '
        'BtnReportes
        '
        Me.BtnReportes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReportes.FlatAppearance.BorderSize = 0
        Me.BtnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BtnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReportes.ForeColor = System.Drawing.Color.White
        Me.BtnReportes.Image = CType(resources.GetObject("BtnReportes.Image"), System.Drawing.Image)
        Me.BtnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReportes.Location = New System.Drawing.Point(0, 448)
        Me.BtnReportes.Name = "BtnReportes"
        Me.BtnReportes.Size = New System.Drawing.Size(220, 42)
        Me.BtnReportes.TabIndex = 7
        Me.BtnReportes.Text = "&Reportes"
        Me.BtnReportes.UseVisualStyleBackColor = True
        '
        'BtnAyudas
        '
        Me.BtnAyudas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAyudas.FlatAppearance.BorderSize = 0
        Me.BtnAyudas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BtnAyudas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnAyudas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAyudas.ForeColor = System.Drawing.Color.White
        Me.BtnAyudas.Image = CType(resources.GetObject("BtnAyudas.Image"), System.Drawing.Image)
        Me.BtnAyudas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAyudas.Location = New System.Drawing.Point(0, 400)
        Me.BtnAyudas.Name = "BtnAyudas"
        Me.BtnAyudas.Size = New System.Drawing.Size(220, 42)
        Me.BtnAyudas.TabIndex = 6
        Me.BtnAyudas.Text = "&Ayudas"
        Me.BtnAyudas.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.FlatAppearance.BorderSize = 0
        Me.BtnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir.Location = New System.Drawing.Point(0, 532)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(220, 42)
        Me.BtnSalir.TabIndex = 9
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'BtnCajaMenor
        '
        Me.BtnCajaMenor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCajaMenor.FlatAppearance.BorderSize = 0
        Me.BtnCajaMenor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BtnCajaMenor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnCajaMenor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCajaMenor.ForeColor = System.Drawing.Color.White
        Me.BtnCajaMenor.Image = CType(resources.GetObject("BtnCajaMenor.Image"), System.Drawing.Image)
        Me.BtnCajaMenor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCajaMenor.Location = New System.Drawing.Point(0, 352)
        Me.BtnCajaMenor.Name = "BtnCajaMenor"
        Me.BtnCajaMenor.Size = New System.Drawing.Size(220, 42)
        Me.BtnCajaMenor.TabIndex = 5
        Me.BtnCajaMenor.Text = "Caja &Menor"
        Me.BtnCajaMenor.UseVisualStyleBackColor = True
        '
        'BtnFundicion
        '
        Me.BtnFundicion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFundicion.FlatAppearance.BorderSize = 0
        Me.BtnFundicion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BtnFundicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnFundicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFundicion.ForeColor = System.Drawing.Color.White
        Me.BtnFundicion.Image = CType(resources.GetObject("BtnFundicion.Image"), System.Drawing.Image)
        Me.BtnFundicion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFundicion.Location = New System.Drawing.Point(0, 310)
        Me.BtnFundicion.Name = "BtnFundicion"
        Me.BtnFundicion.Size = New System.Drawing.Size(220, 42)
        Me.BtnFundicion.TabIndex = 4
        Me.BtnFundicion.Text = "&Fundición"
        Me.BtnFundicion.UseVisualStyleBackColor = True
        '
        'BtnCompras
        '
        Me.BtnCompras.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCompras.FlatAppearance.BorderSize = 0
        Me.BtnCompras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BtnCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCompras.ForeColor = System.Drawing.Color.White
        Me.BtnCompras.Image = CType(resources.GetObject("BtnCompras.Image"), System.Drawing.Image)
        Me.BtnCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCompras.Location = New System.Drawing.Point(0, 267)
        Me.BtnCompras.Name = "BtnCompras"
        Me.BtnCompras.Size = New System.Drawing.Size(220, 42)
        Me.BtnCompras.TabIndex = 3
        Me.BtnCompras.Text = "&Compras"
        Me.BtnCompras.UseVisualStyleBackColor = True
        '
        'BtnTasas
        '
        Me.BtnTasas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTasas.FlatAppearance.BorderSize = 0
        Me.BtnTasas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BtnTasas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnTasas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTasas.ForeColor = System.Drawing.Color.White
        Me.BtnTasas.Image = CType(resources.GetObject("BtnTasas.Image"), System.Drawing.Image)
        Me.BtnTasas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTasas.Location = New System.Drawing.Point(0, 224)
        Me.BtnTasas.Name = "BtnTasas"
        Me.BtnTasas.Size = New System.Drawing.Size(220, 42)
        Me.BtnTasas.TabIndex = 2
        Me.BtnTasas.Text = "&Tasas"
        Me.BtnTasas.UseVisualStyleBackColor = True
        '
        'BtnLinks
        '
        Me.BtnLinks.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLinks.FlatAppearance.BorderSize = 0
        Me.BtnLinks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BtnLinks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnLinks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLinks.ForeColor = System.Drawing.Color.White
        Me.BtnLinks.Image = CType(resources.GetObject("BtnLinks.Image"), System.Drawing.Image)
        Me.BtnLinks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLinks.Location = New System.Drawing.Point(0, 181)
        Me.BtnLinks.Name = "BtnLinks"
        Me.BtnLinks.Size = New System.Drawing.Size(220, 42)
        Me.BtnLinks.TabIndex = 1
        Me.BtnLinks.Text = "&Link Busquedas"
        Me.BtnLinks.UseVisualStyleBackColor = True
        '
        'BtnIngresos
        '
        Me.BtnIngresos.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BtnIngresos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnIngresos.FlatAppearance.BorderSize = 0
        Me.BtnIngresos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.BtnIngresos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnIngresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnIngresos.ForeColor = System.Drawing.Color.White
        Me.BtnIngresos.Image = CType(resources.GetObject("BtnIngresos.Image"), System.Drawing.Image)
        Me.BtnIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnIngresos.Location = New System.Drawing.Point(0, 137)
        Me.BtnIngresos.Name = "BtnIngresos"
        Me.BtnIngresos.Size = New System.Drawing.Size(220, 42)
        Me.BtnIngresos.TabIndex = 0
        Me.BtnIngresos.Text = "&Ingresos"
        Me.BtnIngresos.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(3, 54)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(52, 56)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'BtnMenu
        '
        Me.BtnMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMenu.BackColor = System.Drawing.Color.Transparent
        Me.BtnMenu.BackgroundImage = CType(resources.GetObject("BtnMenu.BackgroundImage"), System.Drawing.Image)
        Me.BtnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMenu.Location = New System.Drawing.Point(181, 6)
        Me.BtnMenu.Name = "BtnMenu"
        Me.BtnMenu.Size = New System.Drawing.Size(32, 32)
        Me.BtnMenu.TabIndex = 0
        Me.BtnMenu.Text = "."
        Me.BtnMenu.UseVisualStyleBackColor = False
        '
        'PanelContenedor
        '
        Me.PanelContenedor.BackColor = System.Drawing.Color.White
        Me.PanelContenedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PanelContenedor.Controls.Add(Me.wbMonitor)
        Me.PanelContenedor.Controls.Add(Me.LblFecha)
        Me.PanelContenedor.Controls.Add(Me.LblHora)
        Me.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContenedor.Location = New System.Drawing.Point(0, 35)
        Me.PanelContenedor.Name = "PanelContenedor"
        Me.PanelContenedor.Size = New System.Drawing.Size(1150, 736)
        Me.PanelContenedor.TabIndex = 2
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha.Location = New System.Drawing.Point(226, 7)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(95, 31)
        Me.LblFecha.TabIndex = 1
        Me.LblFecha.Text = "Label1"
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.Location = New System.Drawing.Point(226, 64)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(139, 46)
        Me.LblHora.TabIndex = 0
        Me.LblHora.Text = "Label1"
        '
        'PanelEstado
        '
        Me.PanelEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.PanelEstado.Controls.Add(Me.TssLicencia)
        Me.PanelEstado.Controls.Add(Me.TssUsuario)
        Me.PanelEstado.Controls.Add(Me.TssEstado)
        Me.PanelEstado.Controls.Add(Me.TssEmpresa)
        Me.PanelEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEstado.Location = New System.Drawing.Point(220, 741)
        Me.PanelEstado.Name = "PanelEstado"
        Me.PanelEstado.Size = New System.Drawing.Size(930, 30)
        Me.PanelEstado.TabIndex = 0
        '
        'TssLicencia
        '
        Me.TssLicencia.AutoSize = True
        Me.TssLicencia.Location = New System.Drawing.Point(9, 8)
        Me.TssLicencia.Name = "TssLicencia"
        Me.TssLicencia.Size = New System.Drawing.Size(10, 13)
        Me.TssLicencia.TabIndex = 3
        Me.TssLicencia.Text = "."
        '
        'TssUsuario
        '
        Me.TssUsuario.AutoSize = True
        Me.TssUsuario.Location = New System.Drawing.Point(856, 8)
        Me.TssUsuario.Name = "TssUsuario"
        Me.TssUsuario.Size = New System.Drawing.Size(10, 13)
        Me.TssUsuario.TabIndex = 2
        Me.TssUsuario.Text = "."
        '
        'TssEstado
        '
        Me.TssEstado.AutoSize = True
        Me.TssEstado.Location = New System.Drawing.Point(650, 8)
        Me.TssEstado.Name = "TssEstado"
        Me.TssEstado.Size = New System.Drawing.Size(10, 13)
        Me.TssEstado.TabIndex = 1
        Me.TssEstado.Text = "."
        '
        'TssEmpresa
        '
        Me.TssEmpresa.AutoSize = True
        Me.TssEmpresa.Location = New System.Drawing.Point(357, 8)
        Me.TssEmpresa.Name = "TssEmpresa"
        Me.TssEmpresa.Size = New System.Drawing.Size(10, 13)
        Me.TssEmpresa.TabIndex = 0
        Me.TssEmpresa.Text = "."
        '
        'TmOcultar
        '
        Me.TmOcultar.Interval = 15
        '
        'TmMostrar
        '
        Me.TmMostrar.Interval = 15
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'wbMonitor
        '
        Me.wbMonitor.AllowExternalDrop = True
        Me.wbMonitor.CreationProperties = Nothing
        Me.wbMonitor.DefaultBackgroundColor = System.Drawing.Color.White
        Me.wbMonitor.Location = New System.Drawing.Point(234, 145)
        Me.wbMonitor.Name = "wbMonitor"
        Me.wbMonitor.Size = New System.Drawing.Size(876, 471)
        Me.wbMonitor.TabIndex = 2
        Me.wbMonitor.ZoomFactor = 1.0R
        '
        'FrmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1150, 771)
        Me.Controls.Add(Me.PanelEstado)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.PanelContenedor)
        Me.Controls.Add(Me.PanelBarraTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmAdminNuevo"
        Me.PanelBarraTitulo.ResumeLayout(False)
        Me.PanelBarraTitulo.PerformLayout()
        Me.PanelMenu.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelContenedor.ResumeLayout(False)
        Me.PanelContenedor.PerformLayout()
        Me.PanelEstado.ResumeLayout(False)
        Me.PanelEstado.PerformLayout()
        CType(Me.wbMonitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelBarraTitulo As Panel
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents PanelContenedor As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnMenu As Button
    Friend WithEvents BtnFundicion As Button
    Friend WithEvents BtnCompras As Button
    Friend WithEvents BtnTasas As Button
    Friend WithEvents BtnLinks As Button
    Friend WithEvents BtnIngresos As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnCajaMenor As Button
    Friend WithEvents BtnRestaurar As Button
    Friend WithEvents BtnCerrar As Button
    Friend WithEvents BtnMinimizar As Button
    Friend WithEvents TmOcultar As Timer
    Friend WithEvents TmMostrar As Timer
    Friend WithEvents BtnMaximizar As Button
    Friend WithEvents LblTitulo As Label
    Friend WithEvents PanelEstado As Panel
    Friend WithEvents TssEmpresa As Label
    Friend WithEvents TssEstado As Label
    Friend WithEvents TssUsuario As Label
    Friend WithEvents TssLicencia As Label
    Friend WithEvents LblHora As Label
    Friend WithEvents LblFecha As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BtnAyudas As Button
    Friend WithEvents BtnCopiaSeg As Button
    Friend WithEvents BtnReportes As Button
    Friend WithEvents wbMonitor As Microsoft.Web.WebView2.WinForms.WebView2
End Class
