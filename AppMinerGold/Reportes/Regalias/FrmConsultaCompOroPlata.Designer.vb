<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultaCompOroPlata
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaCompOroPlata))
        Me.TotalPuros = New System.Windows.Forms.TextBox()
        Me.LblModReg = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DTPfinal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DTPinicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TotalBrutos = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtPlata = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtGrBrutosC = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtLey = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtPuros = New System.Windows.Forms.TextBox()
        Me.TxtMetal = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TotalPuros
        '
        Me.TotalPuros.Enabled = False
        Me.TotalPuros.Location = New System.Drawing.Point(21, 371)
        Me.TotalPuros.Name = "TotalPuros"
        Me.TotalPuros.Size = New System.Drawing.Size(100, 20)
        Me.TotalPuros.TabIndex = 65
        Me.TotalPuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TotalPuros.Visible = False
        '
        'LblModReg
        '
        Me.LblModReg.AutoSize = True
        Me.LblModReg.Location = New System.Drawing.Point(141, 315)
        Me.LblModReg.Name = "LblModReg"
        Me.LblModReg.Size = New System.Drawing.Size(10, 13)
        Me.LblModReg.TabIndex = 58
        Me.LblModReg.Tag = ""
        Me.LblModReg.Text = "."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 315)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Registros Encontrados:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(21, 156)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(853, 144)
        Me.DataGridView1.TabIndex = 57
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Panel3.Controls.Add(Me.BtnX)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(890, 40)
        Me.Panel3.TabIndex = 56
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
        Me.BtnX.Location = New System.Drawing.Point(850, 4)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 80
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(197, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(524, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "CONSULTA DE COMPRAS DE METALES PRECIOSOS ORO - PLATA POR FECHAS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.BtnLimpiar)
        Me.GroupBox1.Location = New System.Drawing.Point(127, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(654, 87)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Consulta"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscar.FlatAppearance.BorderSize = 0
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(427, 19)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(105, 40)
        Me.BtnBuscar.TabIndex = 48
        Me.BtnBuscar.Text = "     &Consultar"
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.DTPfinal)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(217, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(189, 55)
        Me.Panel2.TabIndex = 47
        '
        'DTPfinal
        '
        Me.DTPfinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPfinal.Location = New System.Drawing.Point(79, 17)
        Me.DTPfinal.Name = "DTPfinal"
        Me.DTPfinal.Size = New System.Drawing.Size(100, 20)
        Me.DTPfinal.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 20)
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
        Me.Panel1.Location = New System.Drawing.Point(16, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(187, 55)
        Me.Panel1.TabIndex = 46
        '
        'DTPinicial
        '
        Me.DTPinicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPinicial.Location = New System.Drawing.Point(78, 16)
        Me.DTPinicial.Name = "DTPinicial"
        Me.DTPinicial.Size = New System.Drawing.Size(100, 20)
        Me.DTPinicial.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Inicial"
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLimpiar.FlatAppearance.BorderSize = 0
        Me.BtnLimpiar.Image = CType(resources.GetObject("BtnLimpiar.Image"), System.Drawing.Image)
        Me.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnLimpiar.Location = New System.Drawing.Point(538, 19)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(105, 40)
        Me.BtnLimpiar.TabIndex = 45
        Me.BtnLimpiar.Text = "     &Limpiar"
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(309, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Seleccione el Rango de Fechas a Consultar"
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImprimir.FlatAppearance.BorderSize = 0
        Me.BtnImprimir.Image = CType(resources.GetObject("BtnImprimir.Image"), System.Drawing.Image)
        Me.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnImprimir.Location = New System.Drawing.Point(363, 351)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(120, 40)
        Me.BtnImprimir.TabIndex = 46
        Me.BtnImprimir.Text = "     &Imprimir"
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TxtMetal)
        Me.Panel4.Controls.Add(Me.TotalBrutos)
        Me.Panel4.Controls.Add(Me.LblModReg)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.TxtPlata)
        Me.Panel4.Controls.Add(Me.DataGridView1)
        Me.Panel4.Controls.Add(Me.TotalPuros)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.TxtGrBrutosC)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.TxtLey)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.TxtPuros)
        Me.Panel4.Controls.Add(Me.BtnImprimir)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(890, 440)
        Me.Panel4.TabIndex = 67
        '
        'TotalBrutos
        '
        Me.TotalBrutos.Enabled = False
        Me.TotalBrutos.Location = New System.Drawing.Point(21, 347)
        Me.TotalBrutos.Name = "TotalBrutos"
        Me.TotalBrutos.Size = New System.Drawing.Size(100, 20)
        Me.TotalBrutos.TabIndex = 69
        Me.TotalBrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TotalBrutos.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(649, 405)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "Total de Gramos Plata:"
        '
        'TxtPlata
        '
        Me.TxtPlata.Enabled = False
        Me.TxtPlata.Location = New System.Drawing.Point(774, 402)
        Me.TxtPlata.Name = "TxtPlata"
        Me.TxtPlata.Size = New System.Drawing.Size(100, 20)
        Me.TxtPlata.TabIndex = 67
        Me.TxtPlata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(649, 328)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 13)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Total de Gramos Brutos:"
        '
        'TxtGrBrutosC
        '
        Me.TxtGrBrutosC.Enabled = False
        Me.TxtGrBrutosC.Location = New System.Drawing.Point(774, 325)
        Me.TxtGrBrutosC.Name = "TxtGrBrutosC"
        Me.TxtGrBrutosC.Size = New System.Drawing.Size(100, 20)
        Me.TxtGrBrutosC.TabIndex = 59
        Me.TxtGrBrutosC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(649, 354)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Total de Ley:"
        '
        'TxtLey
        '
        Me.TxtLey.Enabled = False
        Me.TxtLey.Location = New System.Drawing.Point(774, 351)
        Me.TxtLey.Name = "TxtLey"
        Me.TxtLey.Size = New System.Drawing.Size(100, 20)
        Me.TxtLey.TabIndex = 57
        Me.TxtLey.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(662, 306)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(199, 13)
        Me.Label12.TabIndex = 56
        Me.Label12.Text = "Totales de Fechas Seleccionadas"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(649, 380)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(118, 13)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "Total de Gramos Puros:"
        '
        'TxtPuros
        '
        Me.TxtPuros.Enabled = False
        Me.TxtPuros.Location = New System.Drawing.Point(774, 377)
        Me.TxtPuros.Name = "TxtPuros"
        Me.TxtPuros.Size = New System.Drawing.Size(100, 20)
        Me.TxtPuros.TabIndex = 54
        Me.TxtPuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtMetal
        '
        Me.TxtMetal.Enabled = False
        Me.TxtMetal.Location = New System.Drawing.Point(164, 347)
        Me.TxtMetal.Name = "TxtMetal"
        Me.TxtMetal.Size = New System.Drawing.Size(52, 20)
        Me.TxtMetal.TabIndex = 70
        Me.TxtMetal.Text = "ORO"
        Me.TxtMetal.Visible = False
        '
        'FrmConsultaCompOroPlata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(890, 440)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(890, 440)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(890, 440)
        Me.Name = "FrmConsultaCompOroPlata"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmConsultaCompOroPlata"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TotalPuros As TextBox
    Friend WithEvents LblModReg As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnLimpiar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DTPfinal As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DTPinicial As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtPlata As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtGrBrutosC As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TxtLey As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtPuros As TextBox
    Friend WithEvents TotalBrutos As TextBox
    Friend WithEvents TxtMetal As TextBox
End Class
