<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresoCajaMenor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIngresoCajaMenor))
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
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.TxtValorCaja = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtSaldoActual = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnImpriCaja = New System.Windows.Forms.Button()
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtNumIgreso = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        CType(Me.DGVingresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNomPaciente
        '
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomPaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.TxtNomPaciente.Location = New System.Drawing.Point(147, 527)
        Me.TxtNomPaciente.Name = "TxtNomPaciente"
        Me.TxtNomPaciente.Size = New System.Drawing.Size(67, 26)
        Me.TxtNomPaciente.TabIndex = 145
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
        Me.Panel2.Location = New System.Drawing.Point(55, 54)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(673, 112)
        Me.Panel2.TabIndex = 0
        '
        'TxtNumDoc
        '
        Me.TxtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumDoc.Location = New System.Drawing.Point(109, 8)
        Me.TxtNumDoc.Name = "TxtNumDoc"
        Me.TxtNumDoc.Size = New System.Drawing.Size(101, 24)
        Me.TxtNumDoc.TabIndex = 123
        Me.TxtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txtced_cl
        '
        Me.Txtced_cl.Enabled = False
        Me.Txtced_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtced_cl.Location = New System.Drawing.Point(109, 39)
        Me.Txtced_cl.Name = "Txtced_cl"
        Me.Txtced_cl.Size = New System.Drawing.Size(116, 23)
        Me.Txtced_cl.TabIndex = 1
        Me.Txtced_cl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 43)
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
        Me.DTPfechaactual.Location = New System.Drawing.Point(504, 8)
        Me.DTPfechaactual.Name = "DTPfechaactual"
        Me.DTPfechaactual.Size = New System.Drawing.Size(110, 23)
        Me.DTPfechaactual.TabIndex = 3
        Me.DTPfechaactual.Value = New Date(2018, 5, 11, 0, 0, 0, 0)
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(422, 13)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(76, 13)
        Me.Label32.TabIndex = 105
        Me.Label32.Text = "Fecha  Actual:"
        '
        'TxtCiudad
        '
        Me.TxtCiudad.Enabled = False
        Me.TxtCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCiudad.Location = New System.Drawing.Point(432, 38)
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(182, 21)
        Me.TxtCiudad.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Recibi de:"
        '
        'TxtPagado
        '
        Me.TxtPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPagado.Location = New System.Drawing.Point(108, 70)
        Me.TxtPagado.Name = "TxtPagado"
        Me.TxtPagado.Size = New System.Drawing.Size(506, 24)
        Me.TxtPagado.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(386, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Ciudad: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(46, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "No.:"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConcepto.Location = New System.Drawing.Point(126, 22)
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(529, 48)
        Me.TxtConcepto.TabIndex = 108
        '
        'TxtValorCaja
        '
        Me.TxtValorCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValorCaja.Location = New System.Drawing.Point(126, 76)
        Me.TxtValorCaja.Name = "TxtValorCaja"
        Me.TxtValorCaja.Size = New System.Drawing.Size(160, 29)
        Me.TxtValorCaja.TabIndex = 109
        Me.TxtValorCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(427, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 95
        Me.Label12.Text = "Saldo en Caja:"
        '
        'TxtSaldoActual
        '
        Me.TxtSaldoActual.Enabled = False
        Me.TxtSaldoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldoActual.Location = New System.Drawing.Point(509, 76)
        Me.TxtSaldoActual.Name = "TxtSaldoActual"
        Me.TxtSaldoActual.Size = New System.Drawing.Size(145, 29)
        Me.TxtSaldoActual.TabIndex = 8
        Me.TxtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Valor del Ingreso:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 13)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Concepto del Ingreso:"
        '
        'BtnImpriCaja
        '
        Me.BtnImpriCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpriCaja.Image = CType(resources.GetObject("BtnImpriCaja.Image"), System.Drawing.Image)
        Me.BtnImpriCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImpriCaja.Location = New System.Drawing.Point(471, 504)
        Me.BtnImpriCaja.Name = "BtnImpriCaja"
        Me.BtnImpriCaja.Size = New System.Drawing.Size(120, 40)
        Me.BtnImpriCaja.TabIndex = 3
        Me.BtnImpriCaja.Text = "        Imprimir Ingresos"
        Me.BtnImpriCaja.UseVisualStyleBackColor = True
        '
        'TxtSurname
        '
        Me.TxtSurname.Enabled = False
        Me.TxtSurname.Location = New System.Drawing.Point(86, 527)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(55, 20)
        Me.TxtSurname.TabIndex = 144
        Me.TxtSurname.Visible = False
        '
        'TxtName
        '
        Me.TxtName.Enabled = False
        Me.TxtName.Location = New System.Drawing.Point(18, 527)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(61, 20)
        Me.TxtName.TabIndex = 143
        Me.TxtName.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(50, 504)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 13)
        Me.Label11.TabIndex = 142
        Me.Label11.Text = "Cantidad de Registros:"
        '
        'LblRegistros
        '
        Me.LblRegistros.AutoSize = True
        Me.LblRegistros.Location = New System.Drawing.Point(164, 505)
        Me.LblRegistros.Name = "LblRegistros"
        Me.LblRegistros.Size = New System.Drawing.Size(10, 13)
        Me.LblRegistros.TabIndex = 141
        Me.LblRegistros.Text = "."
        '
        'BtnNuevoCaja
        '
        Me.BtnNuevoCaja.BackColor = System.Drawing.Color.Transparent
        Me.BtnNuevoCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevoCaja.ForeColor = System.Drawing.Color.Black
        Me.BtnNuevoCaja.Image = CType(resources.GetObject("BtnNuevoCaja.Image"), System.Drawing.Image)
        Me.BtnNuevoCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevoCaja.Location = New System.Drawing.Point(335, 504)
        Me.BtnNuevoCaja.Name = "BtnNuevoCaja"
        Me.BtnNuevoCaja.Size = New System.Drawing.Size(120, 40)
        Me.BtnNuevoCaja.TabIndex = 2
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
        Me.BtnGuardaIngreso.Location = New System.Drawing.Point(335, 504)
        Me.BtnGuardaIngreso.Name = "BtnGuardaIngreso"
        Me.BtnGuardaIngreso.Size = New System.Drawing.Size(120, 40)
        Me.BtnGuardaIngreso.TabIndex = 137
        Me.BtnGuardaIngreso.Text = "      Guardar Ingreso"
        Me.BtnGuardaIngreso.UseVisualStyleBackColor = False
        '
        'DGVingresos
        '
        Me.DGVingresos.AllowUserToAddRows = False
        Me.DGVingresos.AllowUserToDeleteRows = False
        Me.DGVingresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVingresos.Location = New System.Drawing.Point(55, 300)
        Me.DGVingresos.Name = "DGVingresos"
        Me.DGVingresos.ReadOnly = True
        Me.DGVingresos.Size = New System.Drawing.Size(673, 170)
        Me.DGVingresos.TabIndex = 135
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(793, 40)
        Me.Panel1.TabIndex = 140
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(756, 6)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 54
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(227, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(354, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "DETALLE DE LOS INGRESOS DE CAJA MENOR"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtConcepto)
        Me.GroupBox1.Controls.Add(Me.TxtValorCaja)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtSaldoActual)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(55, 173)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(672, 121)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingreso de Datos del Recibo"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TxtNumIgreso)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(793, 576)
        Me.Panel3.TabIndex = 146
        '
        'TxtNumIgreso
        '
        Me.TxtNumIgreso.Location = New System.Drawing.Point(645, 515)
        Me.TxtNumIgreso.Name = "TxtNumIgreso"
        Me.TxtNumIgreso.Size = New System.Drawing.Size(52, 20)
        Me.TxtNumIgreso.TabIndex = 0
        Me.TxtNumIgreso.Visible = False
        '
        'FrmIngresoCajaMenor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(793, 576)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtNomPaciente)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnImpriCaja)
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
        Me.MaximumSize = New System.Drawing.Size(793, 576)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(793, 576)
        Me.Name = "FrmIngresoCajaMenor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Ingresos de caja menor"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGVingresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtNomPaciente As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtNumDoc As TextBox
    Friend WithEvents TxtConcepto As TextBox
    Friend WithEvents TxtValorCaja As TextBox
    Friend WithEvents Txtced_cl As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPfechaactual As DateTimePicker
    Friend WithEvents Label32 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtSaldoActual As TextBox
    Friend WithEvents TxtCiudad As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtPagado As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnImpriCaja As Button
    Friend WithEvents TxtSurname As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents LblRegistros As Label
    Friend WithEvents BtnNuevoCaja As Button
    Friend WithEvents BtnGuardaIngreso As Button
    Friend WithEvents DGVingresos As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents TxtNumIgreso As TextBox
End Class
