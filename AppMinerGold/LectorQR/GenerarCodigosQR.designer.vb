<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarCodigosQR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerarCodigosQR))
        Me.Tab = New System.Windows.Forms.TabControl()
        Me.TabGenerar = New System.Windows.Forms.TabPage()
        Me.TabResultadoQR = New System.Windows.Forms.TabControl()
        Me.TabQRConfiguracion = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OpForzarUTF = New System.Windows.Forms.CheckBox()
        Me.PColorQR = New System.Windows.Forms.Panel()
        Me.PColorFondo = New System.Windows.Forms.Panel()
        Me.TxtEscalaPixel = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lsNivelCorreccion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImgQR = New System.Windows.Forms.PictureBox()
        Me.BtImprimirQR = New System.Windows.Forms.Button()
        Me.BtGuardarQR = New System.Windows.Forms.Button()
        Me.BtGenerarQR = New System.Windows.Forms.Button()
        Me.TabQRTextoResultante = New System.Windows.Forms.TabPage()
        Me.TxtTextoQR = New System.Windows.Forms.TextBox()
        Me.TabLeerQR = New System.Windows.Forms.TabPage()
        Me.TxtLeerQRImagen = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.OpLeerForzarUTF8 = New System.Windows.Forms.CheckBox()
        Me.TxtLeerQRTexto = New System.Windows.Forms.TextBox()
        Me.BtDecodificarImagenQR = New System.Windows.Forms.Button()
        Me.ImgQRExistente = New System.Windows.Forms.PictureBox()
        Me.BtSelImagenQR = New System.Windows.Forms.Button()
        Me.DlImprimir = New System.Windows.Forms.PrintDialog()
        Me.ImprimirDoc = New System.Drawing.Printing.PrintDocument()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Tab.SuspendLayout()
        Me.TabGenerar.SuspendLayout()
        Me.TabResultadoQR.SuspendLayout()
        Me.TabQRConfiguracion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ImgQR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabQRTextoResultante.SuspendLayout()
        Me.TabLeerQR.SuspendLayout()
        CType(Me.ImgQRExistente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab
        '
        Me.Tab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tab.Controls.Add(Me.TabGenerar)
        Me.Tab.Controls.Add(Me.TabLeerQR)
        Me.Tab.Location = New System.Drawing.Point(12, 56)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(545, 440)
        Me.Tab.TabIndex = 6
        '
        'TabGenerar
        '
        Me.TabGenerar.Controls.Add(Me.TabResultadoQR)
        Me.TabGenerar.Location = New System.Drawing.Point(4, 22)
        Me.TabGenerar.Name = "TabGenerar"
        Me.TabGenerar.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGenerar.Size = New System.Drawing.Size(537, 414)
        Me.TabGenerar.TabIndex = 0
        Me.TabGenerar.Text = "Generar QR"
        Me.TabGenerar.UseVisualStyleBackColor = True
        '
        'TabResultadoQR
        '
        Me.TabResultadoQR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabResultadoQR.Controls.Add(Me.TabQRConfiguracion)
        Me.TabResultadoQR.Controls.Add(Me.TabQRTextoResultante)
        Me.TabResultadoQR.Location = New System.Drawing.Point(6, 40)
        Me.TabResultadoQR.Name = "TabResultadoQR"
        Me.TabResultadoQR.SelectedIndex = 0
        Me.TabResultadoQR.Size = New System.Drawing.Size(516, 363)
        Me.TabResultadoQR.TabIndex = 15
        '
        'TabQRConfiguracion
        '
        Me.TabQRConfiguracion.Controls.Add(Me.GroupBox1)
        Me.TabQRConfiguracion.Controls.Add(Me.ImgQR)
        Me.TabQRConfiguracion.Controls.Add(Me.BtImprimirQR)
        Me.TabQRConfiguracion.Controls.Add(Me.BtGuardarQR)
        Me.TabQRConfiguracion.Controls.Add(Me.BtGenerarQR)
        Me.TabQRConfiguracion.Location = New System.Drawing.Point(4, 22)
        Me.TabQRConfiguracion.Name = "TabQRConfiguracion"
        Me.TabQRConfiguracion.Padding = New System.Windows.Forms.Padding(3)
        Me.TabQRConfiguracion.Size = New System.Drawing.Size(508, 337)
        Me.TabQRConfiguracion.TabIndex = 0
        Me.TabQRConfiguracion.Text = "Generar QR"
        Me.TabQRConfiguracion.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.OpForzarUTF)
        Me.GroupBox1.Controls.Add(Me.PColorQR)
        Me.GroupBox1.Controls.Add(Me.PColorFondo)
        Me.GroupBox1.Controls.Add(Me.TxtEscalaPixel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lsNivelCorreccion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(494, 76)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuración QR "
        '
        'OpForzarUTF
        '
        Me.OpForzarUTF.AutoSize = True
        Me.OpForzarUTF.Checked = True
        Me.OpForzarUTF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OpForzarUTF.Location = New System.Drawing.Point(202, 48)
        Me.OpForzarUTF.Name = "OpForzarUTF"
        Me.OpForzarUTF.Size = New System.Drawing.Size(88, 17)
        Me.OpForzarUTF.TabIndex = 35
        Me.OpForzarUTF.Text = "Forzar UTF-8"
        Me.OpForzarUTF.UseVisualStyleBackColor = True
        '
        'PColorQR
        '
        Me.PColorQR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PColorQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PColorQR.Location = New System.Drawing.Point(398, 46)
        Me.PColorQR.Name = "PColorQR"
        Me.PColorQR.Size = New System.Drawing.Size(75, 20)
        Me.PColorQR.TabIndex = 34
        Me.PColorQR.Visible = False
        '
        'PColorFondo
        '
        Me.PColorFondo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PColorFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PColorFondo.Location = New System.Drawing.Point(398, 19)
        Me.PColorFondo.Name = "PColorFondo"
        Me.PColorFondo.Size = New System.Drawing.Size(75, 20)
        Me.PColorFondo.TabIndex = 33
        Me.PColorFondo.Visible = False
        '
        'TxtEscalaPixel
        '
        Me.TxtEscalaPixel.Location = New System.Drawing.Point(107, 46)
        Me.TxtEscalaPixel.Mask = "9"
        Me.TxtEscalaPixel.Name = "TxtEscalaPixel"
        Me.TxtEscalaPixel.Size = New System.Drawing.Size(25, 20)
        Me.TxtEscalaPixel.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Escala del pixel"
        '
        'lsNivelCorreccion
        '
        Me.lsNivelCorreccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lsNivelCorreccion.FormattingEnabled = True
        Me.lsNivelCorreccion.Items.AddRange(New Object() {"Bajo (7%)", "Medio (15%)", "Alto (25%)", "Muy alto (30%)"})
        Me.lsNivelCorreccion.Location = New System.Drawing.Point(106, 19)
        Me.lsNivelCorreccion.Name = "lsNivelCorreccion"
        Me.lsNivelCorreccion.Size = New System.Drawing.Size(121, 21)
        Me.lsNivelCorreccion.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Nivel de corrección"
        '
        'ImgQR
        '
        Me.ImgQR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImgQR.BackColor = System.Drawing.Color.White
        Me.ImgQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImgQR.Location = New System.Drawing.Point(230, 101)
        Me.ImgQR.Name = "ImgQR"
        Me.ImgQR.Size = New System.Drawing.Size(200, 200)
        Me.ImgQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgQR.TabIndex = 15
        Me.ImgQR.TabStop = False
        '
        'BtImprimirQR
        '
        Me.BtImprimirQR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtImprimirQR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtImprimirQR.Image = CType(resources.GetObject("BtImprimirQR.Image"), System.Drawing.Image)
        Me.BtImprimirQR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtImprimirQR.Location = New System.Drawing.Point(40, 233)
        Me.BtImprimirQR.Name = "BtImprimirQR"
        Me.BtImprimirQR.Size = New System.Drawing.Size(135, 40)
        Me.BtImprimirQR.TabIndex = 16
        Me.BtImprimirQR.Text = "     &Imprimir QR"
        Me.BtImprimirQR.UseVisualStyleBackColor = True
        '
        'BtGuardarQR
        '
        Me.BtGuardarQR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtGuardarQR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtGuardarQR.Image = CType(resources.GetObject("BtGuardarQR.Image"), System.Drawing.Image)
        Me.BtGuardarQR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtGuardarQR.Location = New System.Drawing.Point(42, 173)
        Me.BtGuardarQR.Name = "BtGuardarQR"
        Me.BtGuardarQR.Size = New System.Drawing.Size(135, 40)
        Me.BtGuardarQR.TabIndex = 17
        Me.BtGuardarQR.Text = "    G&uardar QR"
        Me.BtGuardarQR.UseVisualStyleBackColor = True
        '
        'BtGenerarQR
        '
        Me.BtGenerarQR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtGenerarQR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtGenerarQR.Image = CType(resources.GetObject("BtGenerarQR.Image"), System.Drawing.Image)
        Me.BtGenerarQR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtGenerarQR.Location = New System.Drawing.Point(42, 110)
        Me.BtGenerarQR.Name = "BtGenerarQR"
        Me.BtGenerarQR.Size = New System.Drawing.Size(135, 40)
        Me.BtGenerarQR.TabIndex = 14
        Me.BtGenerarQR.Text = "     &Generar QR"
        Me.BtGenerarQR.UseVisualStyleBackColor = True
        '
        'TabQRTextoResultante
        '
        Me.TabQRTextoResultante.Controls.Add(Me.TxtTextoQR)
        Me.TabQRTextoResultante.Location = New System.Drawing.Point(4, 22)
        Me.TabQRTextoResultante.Name = "TabQRTextoResultante"
        Me.TabQRTextoResultante.Padding = New System.Windows.Forms.Padding(3)
        Me.TabQRTextoResultante.Size = New System.Drawing.Size(508, 337)
        Me.TabQRTextoResultante.TabIndex = 1
        Me.TabQRTextoResultante.Text = "EscribirTexto QR"
        Me.TabQRTextoResultante.UseVisualStyleBackColor = True
        '
        'TxtTextoQR
        '
        Me.TxtTextoQR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTextoQR.Location = New System.Drawing.Point(6, 6)
        Me.TxtTextoQR.Multiline = True
        Me.TxtTextoQR.Name = "TxtTextoQR"
        Me.TxtTextoQR.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtTextoQR.Size = New System.Drawing.Size(496, 366)
        Me.TxtTextoQR.TabIndex = 2
        Me.TxtTextoQR.Text = "Escribir QR"
        '
        'TabLeerQR
        '
        Me.TabLeerQR.Controls.Add(Me.TxtLeerQRImagen)
        Me.TabLeerQR.Controls.Add(Me.Label29)
        Me.TabLeerQR.Controls.Add(Me.OpLeerForzarUTF8)
        Me.TabLeerQR.Controls.Add(Me.TxtLeerQRTexto)
        Me.TabLeerQR.Controls.Add(Me.BtDecodificarImagenQR)
        Me.TabLeerQR.Controls.Add(Me.ImgQRExistente)
        Me.TabLeerQR.Controls.Add(Me.BtSelImagenQR)
        Me.TabLeerQR.Location = New System.Drawing.Point(4, 22)
        Me.TabLeerQR.Name = "TabLeerQR"
        Me.TabLeerQR.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLeerQR.Size = New System.Drawing.Size(537, 414)
        Me.TabLeerQR.TabIndex = 1
        Me.TabLeerQR.Text = "Leer QR"
        Me.TabLeerQR.UseVisualStyleBackColor = True
        '
        'TxtLeerQRImagen
        '
        Me.TxtLeerQRImagen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtLeerQRImagen.Location = New System.Drawing.Point(12, 15)
        Me.TxtLeerQRImagen.Name = "TxtLeerQRImagen"
        Me.TxtLeerQRImagen.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtLeerQRImagen.Size = New System.Drawing.Size(242, 20)
        Me.TxtLeerQRImagen.TabIndex = 29
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(9, 253)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(381, 13)
        Me.Label29.TabIndex = 28
        Me.Label29.Text = "Texto resultante de la decodificación del código QR de la imagen seleccionada"
        '
        'OpLeerForzarUTF8
        '
        Me.OpLeerForzarUTF8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpLeerForzarUTF8.AutoSize = True
        Me.OpLeerForzarUTF8.Checked = True
        Me.OpLeerForzarUTF8.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OpLeerForzarUTF8.Location = New System.Drawing.Point(351, 18)
        Me.OpLeerForzarUTF8.Name = "OpLeerForzarUTF8"
        Me.OpLeerForzarUTF8.Size = New System.Drawing.Size(88, 17)
        Me.OpLeerForzarUTF8.TabIndex = 14
        Me.OpLeerForzarUTF8.Text = "Forzar UTF-8"
        Me.OpLeerForzarUTF8.UseVisualStyleBackColor = True
        '
        'TxtLeerQRTexto
        '
        Me.TxtLeerQRTexto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtLeerQRTexto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtLeerQRTexto.Location = New System.Drawing.Point(12, 282)
        Me.TxtLeerQRTexto.Multiline = True
        Me.TxtLeerQRTexto.Name = "TxtLeerQRTexto"
        Me.TxtLeerQRTexto.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtLeerQRTexto.Size = New System.Drawing.Size(512, 113)
        Me.TxtLeerQRTexto.TabIndex = 5
        '
        'BtDecodificarImagenQR
        '
        Me.BtDecodificarImagenQR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtDecodificarImagenQR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtDecodificarImagenQR.Image = CType(resources.GetObject("BtDecodificarImagenQR.Image"), System.Drawing.Image)
        Me.BtDecodificarImagenQR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtDecodificarImagenQR.Location = New System.Drawing.Point(445, 10)
        Me.BtDecodificarImagenQR.Name = "BtDecodificarImagenQR"
        Me.BtDecodificarImagenQR.Size = New System.Drawing.Size(79, 35)
        Me.BtDecodificarImagenQR.TabIndex = 4
        Me.BtDecodificarImagenQR.Text = "&Leer QR"
        Me.BtDecodificarImagenQR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtDecodificarImagenQR.UseVisualStyleBackColor = True
        '
        'ImgQRExistente
        '
        Me.ImgQRExistente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImgQRExistente.BackColor = System.Drawing.Color.White
        Me.ImgQRExistente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImgQRExistente.Location = New System.Drawing.Point(12, 51)
        Me.ImgQRExistente.Name = "ImgQRExistente"
        Me.ImgQRExistente.Size = New System.Drawing.Size(512, 189)
        Me.ImgQRExistente.TabIndex = 3
        Me.ImgQRExistente.TabStop = False
        '
        'BtSelImagenQR
        '
        Me.BtSelImagenQR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtSelImagenQR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtSelImagenQR.Image = CType(resources.GetObject("BtSelImagenQR.Image"), System.Drawing.Image)
        Me.BtSelImagenQR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtSelImagenQR.Location = New System.Drawing.Point(260, 6)
        Me.BtSelImagenQR.Name = "BtSelImagenQR"
        Me.BtSelImagenQR.Size = New System.Drawing.Size(85, 39)
        Me.BtSelImagenQR.TabIndex = 0
        Me.BtSelImagenQR.Text = "&Examinar"
        Me.BtSelImagenQR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtSelImagenQR.UseVisualStyleBackColor = True
        '
        'DlImprimir
        '
        Me.DlImprimir.UseEXDialog = True
        '
        'ImprimirDoc
        '
        Me.ImprimirDoc.DocumentName = "codigo_qr"
        '
        'BtnX
        '
        Me.BtnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(532, 8)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 46
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(173, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(197, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "GENERADOR DE CODIGO QR"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(577, 40)
        Me.Panel1.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(577, 513)
        Me.Panel2.TabIndex = 16
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(577, 513)
        Me.Panel3.TabIndex = 8
        '
        'GenerarCodigosQR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(577, 513)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Tab)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(577, 513)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(577, 513)
        Me.Name = "GenerarCodigosQR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold, Generador y Lector códigos QR"
        Me.Tab.ResumeLayout(False)
        Me.TabGenerar.ResumeLayout(False)
        Me.TabResultadoQR.ResumeLayout(False)
        Me.TabQRConfiguracion.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ImgQR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabQRTextoResultante.ResumeLayout(False)
        Me.TabQRTextoResultante.PerformLayout()
        Me.TabLeerQR.ResumeLayout(False)
        Me.TabLeerQR.PerformLayout()
        CType(Me.ImgQRExistente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents TabGenerar As System.Windows.Forms.TabPage
    Friend WithEvents TabLeerQR As System.Windows.Forms.TabPage
    Friend WithEvents OpLeerForzarUTF8 As System.Windows.Forms.CheckBox
    Friend WithEvents TxtLeerQRTexto As System.Windows.Forms.TextBox
    Friend WithEvents BtDecodificarImagenQR As System.Windows.Forms.Button
    Friend WithEvents ImgQRExistente As System.Windows.Forms.PictureBox
    Friend WithEvents BtSelImagenQR As System.Windows.Forms.Button
    Friend WithEvents TabResultadoQR As System.Windows.Forms.TabControl
    Friend WithEvents TabQRConfiguracion As System.Windows.Forms.TabPage
    Friend WithEvents ImgQR As System.Windows.Forms.PictureBox
    Friend WithEvents BtImprimirQR As System.Windows.Forms.Button
    Friend WithEvents BtGuardarQR As System.Windows.Forms.Button
    Friend WithEvents BtGenerarQR As System.Windows.Forms.Button
    Friend WithEvents TabQRTextoResultante As System.Windows.Forms.TabPage
    Friend WithEvents TxtTextoQR As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OpForzarUTF As System.Windows.Forms.CheckBox
    Friend WithEvents TxtEscalaPixel As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lsNivelCorreccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DlImprimir As System.Windows.Forms.PrintDialog
    Friend WithEvents ImprimirDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents TxtLeerQRImagen As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents PColorQR As Panel
    Friend WithEvents PColorFondo As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
End Class
