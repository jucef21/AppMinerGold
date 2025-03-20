<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEgresoCajaMenor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEgresoCajaMenor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtPagado = New System.Windows.Forms.TextBox()
        Me.TxtCedPagado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtConcePago = New System.Windows.Forms.TextBox()
        Me.DTPfechapago = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtVrPagado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtSaldoActual = New System.Windows.Forms.TextBox()
        Me.TxtNomPaciente = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtControlPago = New System.Windows.Forms.TextBox()
        Me.Txtced_cl = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPfechaactual = New System.Windows.Forms.DateTimePicker()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TxtCiudad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnImpriCaja = New System.Windows.Forms.Button()
        Me.TxtSurname = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblRegistros = New System.Windows.Forms.Label()
        Me.BtnNuevoPago = New System.Windows.Forms.Button()
        Me.BtnGuardaPago = New System.Windows.Forms.Button()
        Me.DGVegresos = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGVegresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtPagado)
        Me.GroupBox1.Controls.Add(Me.TxtCedPagado)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TxtConcePago)
        Me.GroupBox1.Controls.Add(Me.DTPfechapago)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtVrPagado)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TxtSaldoActual)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 146)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(743, 180)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingreso de Datos "
        '
        'TxtPagado
        '
        Me.TxtPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPagado.Location = New System.Drawing.Point(114, 19)
        Me.TxtPagado.Name = "TxtPagado"
        Me.TxtPagado.Size = New System.Drawing.Size(378, 24)
        Me.TxtPagado.TabIndex = 6
        '
        'TxtCedPagado
        '
        Me.TxtCedPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCedPagado.Location = New System.Drawing.Point(550, 19)
        Me.TxtCedPagado.Name = "TxtCedPagado"
        Me.TxtCedPagado.Size = New System.Drawing.Size(100, 23)
        Me.TxtCedPagado.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Pagado A:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(259, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 124
        Me.Label8.Text = "Fecha  del Pago:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(498, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 125
        Me.Label9.Text = "Cédula :"
        '
        'TxtConcePago
        '
        Me.TxtConcePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConcePago.Location = New System.Drawing.Point(114, 54)
        Me.TxtConcePago.Multiline = True
        Me.TxtConcePago.Name = "TxtConcePago"
        Me.TxtConcePago.Size = New System.Drawing.Size(613, 79)
        Me.TxtConcePago.TabIndex = 8
        '
        'DTPfechapago
        '
        Me.DTPfechapago.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPfechapago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPfechapago.Location = New System.Drawing.Point(354, 142)
        Me.DTPfechapago.Name = "DTPfechapago"
        Me.DTPfechapago.Size = New System.Drawing.Size(112, 23)
        Me.DTPfechapago.TabIndex = 10
        Me.DTPfechapago.Value = New Date(2018, 5, 11, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Concepto del Pago:"
        '
        'TxtVrPagado
        '
        Me.TxtVrPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVrPagado.Location = New System.Drawing.Point(90, 139)
        Me.TxtVrPagado.Name = "TxtVrPagado"
        Me.TxtVrPagado.Size = New System.Drawing.Size(160, 29)
        Me.TxtVrPagado.TabIndex = 9
        Me.TxtVrPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Valor del Pago:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(471, 147)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 95
        Me.Label12.Text = "Saldo en Caja:"
        '
        'TxtSaldoActual
        '
        Me.TxtSaldoActual.Enabled = False
        Me.TxtSaldoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldoActual.Location = New System.Drawing.Point(567, 139)
        Me.TxtSaldoActual.Name = "TxtSaldoActual"
        Me.TxtSaldoActual.Size = New System.Drawing.Size(160, 29)
        Me.TxtSaldoActual.TabIndex = 11
        Me.TxtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNomPaciente
        '
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomPaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.TxtNomPaciente.Location = New System.Drawing.Point(197, 529)
        Me.TxtNomPaciente.Name = "TxtNomPaciente"
        Me.TxtNomPaciente.Size = New System.Drawing.Size(67, 26)
        Me.TxtNomPaciente.TabIndex = 159
        Me.TxtNomPaciente.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtControlPago)
        Me.Panel2.Controls.Add(Me.Txtced_cl)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.DTPfechaactual)
        Me.Panel2.Controls.Add(Me.Label32)
        Me.Panel2.Controls.Add(Me.TxtCiudad)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(84, 54)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(618, 80)
        Me.Panel2.TabIndex = 0
        '
        'TxtControlPago
        '
        Me.TxtControlPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtControlPago.Location = New System.Drawing.Point(68, 8)
        Me.TxtControlPago.Name = "TxtControlPago"
        Me.TxtControlPago.Size = New System.Drawing.Size(114, 24)
        Me.TxtControlPago.TabIndex = 1
        Me.TxtControlPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txtced_cl
        '
        Me.Txtced_cl.Enabled = False
        Me.Txtced_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtced_cl.Location = New System.Drawing.Point(68, 41)
        Me.Txtced_cl.Name = "Txtced_cl"
        Me.Txtced_cl.Size = New System.Drawing.Size(127, 23)
        Me.Txtced_cl.TabIndex = 2
        Me.Txtced_cl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Cédula :"
        '
        'DTPfechaactual
        '
        Me.DTPfechaactual.Enabled = False
        Me.DTPfechaactual.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPfechaactual.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPfechaactual.Location = New System.Drawing.Point(475, 9)
        Me.DTPfechaactual.Name = "DTPfechaactual"
        Me.DTPfechaactual.Size = New System.Drawing.Size(110, 23)
        Me.DTPfechaactual.TabIndex = 4
        Me.DTPfechaactual.Value = New Date(2018, 5, 11, 0, 0, 0, 0)
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(393, 15)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(76, 13)
        Me.Label32.TabIndex = 105
        Me.Label32.Text = "Fecha  Actual:"
        '
        'TxtCiudad
        '
        Me.TxtCiudad.Enabled = False
        Me.TxtCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCiudad.Location = New System.Drawing.Point(384, 43)
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(201, 21)
        Me.TxtCiudad.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(331, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Ciudad: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "No.:"
        '
        'BtnImpriCaja
        '
        Me.BtnImpriCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpriCaja.Image = CType(resources.GetObject("BtnImpriCaja.Image"), System.Drawing.Image)
        Me.BtnImpriCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImpriCaja.Location = New System.Drawing.Point(647, 508)
        Me.BtnImpriCaja.Name = "BtnImpriCaja"
        Me.BtnImpriCaja.Size = New System.Drawing.Size(120, 40)
        Me.BtnImpriCaja.TabIndex = 3
        Me.BtnImpriCaja.Text = "       Imprimir Egreso"
        Me.BtnImpriCaja.UseVisualStyleBackColor = True
        '
        'TxtSurname
        '
        Me.TxtSurname.Enabled = False
        Me.TxtSurname.Location = New System.Drawing.Point(111, 529)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(80, 20)
        Me.TxtSurname.TabIndex = 158
        Me.TxtSurname.Visible = False
        '
        'TxtName
        '
        Me.TxtName.Enabled = False
        Me.TxtName.Location = New System.Drawing.Point(25, 529)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(80, 20)
        Me.TxtName.TabIndex = 157
        Me.TxtName.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(22, 503)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 13)
        Me.Label11.TabIndex = 156
        Me.Label11.Text = "Cantidad de Registros:"
        '
        'LblRegistros
        '
        Me.LblRegistros.AutoSize = True
        Me.LblRegistros.Location = New System.Drawing.Point(136, 504)
        Me.LblRegistros.Name = "LblRegistros"
        Me.LblRegistros.Size = New System.Drawing.Size(10, 13)
        Me.LblRegistros.TabIndex = 155
        Me.LblRegistros.Text = "."
        '
        'BtnNuevoPago
        '
        Me.BtnNuevoPago.BackColor = System.Drawing.Color.Transparent
        Me.BtnNuevoPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevoPago.ForeColor = System.Drawing.Color.Black
        Me.BtnNuevoPago.Image = CType(resources.GetObject("BtnNuevoPago.Image"), System.Drawing.Image)
        Me.BtnNuevoPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevoPago.Location = New System.Drawing.Point(397, 509)
        Me.BtnNuevoPago.Name = "BtnNuevoPago"
        Me.BtnNuevoPago.Size = New System.Drawing.Size(120, 40)
        Me.BtnNuevoPago.TabIndex = 2
        Me.BtnNuevoPago.Text = "     Nuevo Pago"
        Me.BtnNuevoPago.UseVisualStyleBackColor = False
        '
        'BtnGuardaPago
        '
        Me.BtnGuardaPago.BackColor = System.Drawing.Color.Red
        Me.BtnGuardaPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGuardaPago.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnGuardaPago.Image = CType(resources.GetObject("BtnGuardaPago.Image"), System.Drawing.Image)
        Me.BtnGuardaPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardaPago.Location = New System.Drawing.Point(397, 509)
        Me.BtnGuardaPago.Name = "BtnGuardaPago"
        Me.BtnGuardaPago.Size = New System.Drawing.Size(120, 40)
        Me.BtnGuardaPago.TabIndex = 152
        Me.BtnGuardaPago.Text = "      Guardar Egreso"
        Me.BtnGuardaPago.UseVisualStyleBackColor = False
        '
        'DGVegresos
        '
        Me.DGVegresos.AllowUserToAddRows = False
        Me.DGVegresos.AllowUserToDeleteRows = False
        Me.DGVegresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVegresos.Location = New System.Drawing.Point(22, 332)
        Me.DGVegresos.Name = "DGVegresos"
        Me.DGVegresos.ReadOnly = True
        Me.DGVegresos.Size = New System.Drawing.Size(746, 168)
        Me.DGVegresos.TabIndex = 153
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(793, 40)
        Me.Panel1.TabIndex = 154
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(760, 6)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 53
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(227, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(349, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "DETALLE DE LOS EGRESOS DE CAJA MENOR"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnImpriCaja)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(793, 576)
        Me.Panel3.TabIndex = 160
        '
        'FrmEgresoCajaMenor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(793, 576)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtNomPaciente)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TxtSurname)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LblRegistros)
        Me.Controls.Add(Me.BtnNuevoPago)
        Me.Controls.Add(Me.BtnGuardaPago)
        Me.Controls.Add(Me.DGVegresos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(793, 576)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(793, 576)
        Me.Name = "FrmEgresoCajaMenor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Egreso "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGVegresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtPagado As TextBox
    Friend WithEvents TxtCedPagado As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtConcePago As TextBox
    Friend WithEvents DTPfechapago As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtVrPagado As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtSaldoActual As TextBox
    Friend WithEvents TxtNomPaciente As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtControlPago As TextBox
    Friend WithEvents Txtced_cl As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPfechaactual As DateTimePicker
    Friend WithEvents Label32 As Label
    Friend WithEvents TxtCiudad As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnImpriCaja As Button
    Friend WithEvents TxtSurname As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents LblRegistros As Label
    Friend WithEvents BtnNuevoPago As Button
    Friend WithEvents BtnGuardaPago As Button
    Friend WithEvents DGVegresos As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel3 As Panel
End Class
