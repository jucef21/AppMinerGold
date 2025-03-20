<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEliminaIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEliminaIngreso))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtPagado = New System.Windows.Forms.TextBox()
        Me.TxtCedPagado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtConcePago = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtVrPagado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtFechaPago = New System.Windows.Forms.TextBox()
        Me.TxtControlPago = New System.Windows.Forms.TextBox()
        Me.Txtced_cl = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtCiudad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNomCiud = New System.Windows.Forms.TextBox()
        Me.TxtNumEliminado = New System.Windows.Forms.TextBox()
        Me.TxtSaldoActual = New System.Windows.Forms.TextBox()
        Me.TxtValorElimina = New System.Windows.Forms.TextBox()
        Me.BtnEliminaPago = New System.Windows.Forms.Button()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtNomPaciente = New System.Windows.Forms.TextBox()
        Me.TxtSurname = New System.Windows.Forms.TextBox()
        Me.BtnImpriElim = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(716, 40)
        Me.Panel1.TabIndex = 176
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(677, 6)
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
        Me.Label4.Location = New System.Drawing.Point(225, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(278, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ELIMINA INGRESO  DE CAJA MENOR"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtPagado)
        Me.GroupBox1.Controls.Add(Me.TxtCedPagado)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TxtConcePago)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtVrPagado)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(677, 146)
        Me.GroupBox1.TabIndex = 175
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingreso de Datos "
        '
        'TxtPagado
        '
        Me.TxtPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPagado.Location = New System.Drawing.Point(123, 19)
        Me.TxtPagado.Name = "TxtPagado"
        Me.TxtPagado.Size = New System.Drawing.Size(340, 24)
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
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Ingreso por:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(470, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 125
        Me.Label9.Text = "Cédula o Nit:"
        '
        'TxtConcePago
        '
        Me.TxtConcePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConcePago.Location = New System.Drawing.Point(123, 54)
        Me.TxtConcePago.Multiline = True
        Me.TxtConcePago.Name = "TxtConcePago"
        Me.TxtConcePago.Size = New System.Drawing.Size(527, 40)
        Me.TxtConcePago.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Concepto del Abono :"
        '
        'TxtVrPagado
        '
        Me.TxtVrPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVrPagado.Location = New System.Drawing.Point(303, 105)
        Me.TxtVrPagado.Name = "TxtVrPagado"
        Me.TxtVrPagado.Size = New System.Drawing.Size(160, 29)
        Me.TxtVrPagado.TabIndex = 9
        Me.TxtVrPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(208, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Valor del Abono :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtFechaPago)
        Me.Panel2.Controls.Add(Me.TxtControlPago)
        Me.Panel2.Controls.Add(Me.Txtced_cl)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.TxtCiudad)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(57, 56)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(618, 80)
        Me.Panel2.TabIndex = 174
        '
        'TxtFechaPago
        '
        Me.TxtFechaPago.Location = New System.Drawing.Point(476, 12)
        Me.TxtFechaPago.Name = "TxtFechaPago"
        Me.TxtFechaPago.Size = New System.Drawing.Size(109, 20)
        Me.TxtFechaPago.TabIndex = 11
        Me.TxtFechaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.Txtced_cl.Location = New System.Drawing.Point(95, 42)
        Me.Txtced_cl.Name = "Txtced_cl"
        Me.Txtced_cl.Size = New System.Drawing.Size(150, 23)
        Me.Txtced_cl.TabIndex = 2
        Me.Txtced_cl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Cédula o Nit :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(376, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 124
        Me.Label8.Text = "Fecha  del Pago:"
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
        'TxtNomCiud
        '
        Me.TxtNomCiud.Location = New System.Drawing.Point(196, 330)
        Me.TxtNomCiud.Name = "TxtNomCiud"
        Me.TxtNomCiud.Size = New System.Drawing.Size(79, 20)
        Me.TxtNomCiud.TabIndex = 176
        Me.TxtNomCiud.Visible = False
        '
        'TxtNumEliminado
        '
        Me.TxtNumEliminado.Location = New System.Drawing.Point(173, 297)
        Me.TxtNumEliminado.Name = "TxtNumEliminado"
        Me.TxtNumEliminado.Size = New System.Drawing.Size(50, 20)
        Me.TxtNumEliminado.TabIndex = 175
        Me.TxtNumEliminado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNumEliminado.Visible = False
        '
        'TxtSaldoActual
        '
        Me.TxtSaldoActual.Location = New System.Drawing.Point(103, 297)
        Me.TxtSaldoActual.Name = "TxtSaldoActual"
        Me.TxtSaldoActual.Size = New System.Drawing.Size(64, 20)
        Me.TxtSaldoActual.TabIndex = 174
        Me.TxtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtSaldoActual.Visible = False
        '
        'TxtValorElimina
        '
        Me.TxtValorElimina.Location = New System.Drawing.Point(24, 297)
        Me.TxtValorElimina.Name = "TxtValorElimina"
        Me.TxtValorElimina.Size = New System.Drawing.Size(73, 20)
        Me.TxtValorElimina.TabIndex = 173
        Me.TxtValorElimina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtValorElimina.Visible = False
        '
        'BtnEliminaPago
        '
        Me.BtnEliminaPago.BackColor = System.Drawing.Color.Transparent
        Me.BtnEliminaPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEliminaPago.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminaPago.Image = CType(resources.GetObject("BtnEliminaPago.Image"), System.Drawing.Image)
        Me.BtnEliminaPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminaPago.Location = New System.Drawing.Point(310, 310)
        Me.BtnEliminaPago.Name = "BtnEliminaPago"
        Me.BtnEliminaPago.Size = New System.Drawing.Size(120, 40)
        Me.BtnEliminaPago.TabIndex = 163
        Me.BtnEliminaPago.Text = "     &Eliminar"
        Me.BtnEliminaPago.UseVisualStyleBackColor = False
        '
        'TxtName
        '
        Me.TxtName.Enabled = False
        Me.TxtName.Location = New System.Drawing.Point(12, 330)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(48, 20)
        Me.TxtName.TabIndex = 170
        Me.TxtName.Visible = False
        '
        'TxtNomPaciente
        '
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomPaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.TxtNomPaciente.Location = New System.Drawing.Point(123, 325)
        Me.TxtNomPaciente.Name = "TxtNomPaciente"
        Me.TxtNomPaciente.Size = New System.Drawing.Size(67, 26)
        Me.TxtNomPaciente.TabIndex = 172
        Me.TxtNomPaciente.Visible = False
        '
        'TxtSurname
        '
        Me.TxtSurname.Enabled = False
        Me.TxtSurname.Location = New System.Drawing.Point(66, 330)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(51, 20)
        Me.TxtSurname.TabIndex = 171
        Me.TxtSurname.Visible = False
        '
        'BtnImpriElim
        '
        Me.BtnImpriElim.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpriElim.Image = CType(resources.GetObject("BtnImpriElim.Image"), System.Drawing.Image)
        Me.BtnImpriElim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImpriElim.Location = New System.Drawing.Point(434, 310)
        Me.BtnImpriElim.Name = "BtnImpriElim"
        Me.BtnImpriElim.Size = New System.Drawing.Size(120, 40)
        Me.BtnImpriElim.TabIndex = 164
        Me.BtnImpriElim.Text = "      &Imprimir"
        Me.BtnImpriElim.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TxtNomCiud)
        Me.Panel3.Controls.Add(Me.TxtNumEliminado)
        Me.Panel3.Controls.Add(Me.TxtSaldoActual)
        Me.Panel3.Controls.Add(Me.TxtValorElimina)
        Me.Panel3.Controls.Add(Me.BtnEliminaPago)
        Me.Panel3.Controls.Add(Me.TxtName)
        Me.Panel3.Controls.Add(Me.TxtNomPaciente)
        Me.Panel3.Controls.Add(Me.TxtSurname)
        Me.Panel3.Controls.Add(Me.BtnImpriElim)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(716, 372)
        Me.Panel3.TabIndex = 177
        '
        'FrmEliminaIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(716, 372)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(716, 372)
        Me.MinimumSize = New System.Drawing.Size(716, 372)
        Me.Name = "FrmEliminaIngreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Elimina Ingreso"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtPagado As TextBox
    Friend WithEvents TxtCedPagado As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtConcePago As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtVrPagado As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtFechaPago As TextBox
    Friend WithEvents TxtControlPago As TextBox
    Friend WithEvents Txtced_cl As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtCiudad As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtNomCiud As TextBox
    Friend WithEvents TxtNumEliminado As TextBox
    Friend WithEvents TxtSaldoActual As TextBox
    Friend WithEvents TxtValorElimina As TextBox
    Friend WithEvents BtnEliminaPago As Button
    Friend WithEvents TxtName As TextBox
    Friend WithEvents TxtNomPaciente As TextBox
    Friend WithEvents TxtSurname As TextBox
    Friend WithEvents BtnImpriElim As Button
    Friend WithEvents Panel3 As Panel
End Class
