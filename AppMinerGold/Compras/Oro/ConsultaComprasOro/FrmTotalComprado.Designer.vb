<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTotalComprado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTotalComprado))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtNomApe = New System.Windows.Forms.TextBox()
        Me.Txtced_cl = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.TxtBrutos = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtVrCompras = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtLey = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPuros = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTPinicial = New System.Windows.Forms.DateTimePicker()
        Me.DTPfinal = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.LblModReg = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtMaterial = New System.Windows.Forms.TextBox()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TxtNomApe)
        Me.Panel3.Controls.Add(Me.Txtced_cl)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label74)
        Me.Panel3.Location = New System.Drawing.Point(56, 54)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(504, 83)
        Me.Panel3.TabIndex = 214
        '
        'TxtNomApe
        '
        Me.TxtNomApe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomApe.Location = New System.Drawing.Point(69, 39)
        Me.TxtNomApe.Name = "TxtNomApe"
        Me.TxtNomApe.Size = New System.Drawing.Size(417, 26)
        Me.TxtNomApe.TabIndex = 2
        '
        'Txtced_cl
        '
        Me.Txtced_cl.Enabled = False
        Me.Txtced_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtced_cl.Location = New System.Drawing.Point(70, 10)
        Me.Txtced_cl.Name = "Txtced_cl"
        Me.Txtced_cl.Size = New System.Drawing.Size(144, 23)
        Me.Txtced_cl.TabIndex = 1
        Me.Txtced_cl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(19, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Cédula :"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(6, 45)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(59, 13)
        Me.Label74.TabIndex = 2
        Me.Label74.Text = "Proveedor:"
        '
        'TxtBrutos
        '
        Me.TxtBrutos.Enabled = False
        Me.TxtBrutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBrutos.Location = New System.Drawing.Point(119, 55)
        Me.TxtBrutos.Name = "TxtBrutos"
        Me.TxtBrutos.Size = New System.Drawing.Size(179, 29)
        Me.TxtBrutos.TabIndex = 217
        Me.TxtBrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 218
        Me.Label1.Text = "Gramos Brutos:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtVrCompras)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtLey)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtPuros)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtBrutos)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 191)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(547, 195)
        Me.GroupBox1.TabIndex = 219
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Compra Durante este Año"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(348, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 13)
        Me.Label7.TabIndex = 225
        Me.Label7.Text = "Valor Total de Compras"
        '
        'TxtVrCompras
        '
        Me.TxtVrCompras.Enabled = False
        Me.TxtVrCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVrCompras.Location = New System.Drawing.Point(328, 93)
        Me.TxtVrCompras.Name = "TxtVrCompras"
        Me.TxtVrCompras.Size = New System.Drawing.Size(179, 29)
        Me.TxtVrCompras.TabIndex = 224
        Me.TxtVrCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 223
        Me.Label4.Text = "Ley:"
        '
        'TxtLey
        '
        Me.TxtLey.Enabled = False
        Me.TxtLey.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLey.Location = New System.Drawing.Point(119, 93)
        Me.TxtLey.Name = "TxtLey"
        Me.TxtLey.Size = New System.Drawing.Size(179, 29)
        Me.TxtLey.TabIndex = 222
        Me.TxtLey.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 221
        Me.Label3.Text = "Gramos Puros:"
        '
        'TxtPuros
        '
        Me.TxtPuros.Enabled = False
        Me.TxtPuros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPuros.Location = New System.Drawing.Point(119, 131)
        Me.TxtPuros.Name = "TxtPuros"
        Me.TxtPuros.Size = New System.Drawing.Size(179, 29)
        Me.TxtPuros.TabIndex = 220
        Me.TxtPuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(90, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 13)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "COMPRAS REALIZADAS"
        '
        'DTPinicial
        '
        Me.DTPinicial.Enabled = False
        Me.DTPinicial.Location = New System.Drawing.Point(81, 156)
        Me.DTPinicial.Name = "DTPinicial"
        Me.DTPinicial.Size = New System.Drawing.Size(200, 20)
        Me.DTPinicial.TabIndex = 220
        '
        'DTPfinal
        '
        Me.DTPfinal.Enabled = False
        Me.DTPfinal.Location = New System.Drawing.Point(375, 156)
        Me.DTPfinal.Name = "DTPfinal"
        Me.DTPfinal.Size = New System.Drawing.Size(200, 20)
        Me.DTPfinal.TabIndex = 221
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 222
        Me.Label5.Text = "Desde:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(329, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 223
        Me.Label6.Text = "Hasta:"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Enabled = False
        Me.DataGridView1.Location = New System.Drawing.Point(413, 394)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(74, 31)
        Me.DataGridView1.TabIndex = 224
        Me.DataGridView1.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Enabled = False
        Me.DataGridView2.Location = New System.Drawing.Point(333, 394)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(74, 31)
        Me.DataGridView2.TabIndex = 225
        Me.DataGridView2.Visible = False
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Enabled = False
        Me.DataGridView3.Location = New System.Drawing.Point(493, 394)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(74, 31)
        Me.DataGridView3.TabIndex = 226
        Me.DataGridView3.Visible = False
        '
        'LblModReg
        '
        Me.LblModReg.AutoSize = True
        Me.LblModReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModReg.Location = New System.Drawing.Point(236, 401)
        Me.LblModReg.Name = "LblModReg"
        Me.LblModReg.Size = New System.Drawing.Size(11, 13)
        Me.LblModReg.TabIndex = 227
        Me.LblModReg.Tag = ""
        Me.LblModReg.Text = "."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 401)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(204, 13)
        Me.Label8.TabIndex = 228
        Me.Label8.Text = "Registros  de Compras Realizadas:"
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(587, 8)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 45
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(118, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(341, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "CONSULTA DATOS DE COMPRAS A PROVEEDORES"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(620, 40)
        Me.Panel1.TabIndex = 229
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtMaterial)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(620, 459)
        Me.Panel2.TabIndex = 230
        '
        'TxtMaterial
        '
        Me.TxtMaterial.Enabled = False
        Me.TxtMaterial.Location = New System.Drawing.Point(30, 426)
        Me.TxtMaterial.Name = "TxtMaterial"
        Me.TxtMaterial.Size = New System.Drawing.Size(100, 20)
        Me.TxtMaterial.TabIndex = 0
        '
        'FrmTotalComprado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(620, 459)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblModReg)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DTPfinal)
        Me.Controls.Add(Me.DTPinicial)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTotalComprado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Total Comprado"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents TxtNomApe As TextBox
    Friend WithEvents Txtced_cl As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label74 As Label
    Friend WithEvents TxtBrutos As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtLey As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtPuros As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DTPinicial As DateTimePicker
    Friend WithEvents DTPfinal As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtVrCompras As TextBox
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents LblModReg As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnX As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtMaterial As TextBox
End Class
