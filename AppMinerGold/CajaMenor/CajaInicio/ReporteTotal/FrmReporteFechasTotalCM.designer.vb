<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReporteFechasTotalCM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReporteFechasTotalCM))
        Me.BtnLimpia = New System.Windows.Forms.Button()
        Me.BtnImpri = New System.Windows.Forms.Button()
        Me.BtnConsu = New System.Windows.Forms.Button()
        Me.LblModReg = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DTPfinalCaja = New System.Windows.Forms.DateTimePicker()
        Me.DTPinicialCaja = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnLimpia
        '
        Me.BtnLimpia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLimpia.FlatAppearance.BorderSize = 0
        Me.BtnLimpia.Image = CType(resources.GetObject("BtnLimpia.Image"), System.Drawing.Image)
        Me.BtnLimpia.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnLimpia.Location = New System.Drawing.Point(659, 415)
        Me.BtnLimpia.Name = "BtnLimpia"
        Me.BtnLimpia.Size = New System.Drawing.Size(120, 40)
        Me.BtnLimpia.TabIndex = 30
        Me.BtnLimpia.Text = "     &Limpiar"
        Me.BtnLimpia.UseVisualStyleBackColor = True
        '
        'BtnImpri
        '
        Me.BtnImpri.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpri.FlatAppearance.BorderSize = 0
        Me.BtnImpri.Image = CType(resources.GetObject("BtnImpri.Image"), System.Drawing.Image)
        Me.BtnImpri.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnImpri.Location = New System.Drawing.Point(534, 415)
        Me.BtnImpri.Name = "BtnImpri"
        Me.BtnImpri.Size = New System.Drawing.Size(120, 40)
        Me.BtnImpri.TabIndex = 29
        Me.BtnImpri.Text = "     &Imprimir"
        Me.BtnImpri.UseVisualStyleBackColor = True
        '
        'BtnConsu
        '
        Me.BtnConsu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsu.FlatAppearance.BorderSize = 0
        Me.BtnConsu.Image = CType(resources.GetObject("BtnConsu.Image"), System.Drawing.Image)
        Me.BtnConsu.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnConsu.Location = New System.Drawing.Point(408, 415)
        Me.BtnConsu.Name = "BtnConsu"
        Me.BtnConsu.Size = New System.Drawing.Size(120, 40)
        Me.BtnConsu.TabIndex = 28
        Me.BtnConsu.Text = "     &Consultar"
        Me.BtnConsu.UseVisualStyleBackColor = True
        '
        'LblModReg
        '
        Me.LblModReg.AutoSize = True
        Me.LblModReg.Location = New System.Drawing.Point(149, 403)
        Me.LblModReg.Name = "LblModReg"
        Me.LblModReg.Size = New System.Drawing.Size(10, 13)
        Me.LblModReg.TabIndex = 26
        Me.LblModReg.Tag = ""
        Me.LblModReg.Text = "."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 403)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Registros Encontrados:"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(22, 136)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(882, 256)
        Me.DataGridView1.TabIndex = 25
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.DTPfinalCaja)
        Me.Panel2.Controls.Add(Me.DTPinicialCaja)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(127, 57)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(675, 56)
        Me.Panel2.TabIndex = 24
        '
        'DTPfinalCaja
        '
        Me.DTPfinalCaja.Location = New System.Drawing.Point(407, 16)
        Me.DTPfinalCaja.Name = "DTPfinalCaja"
        Me.DTPfinalCaja.Size = New System.Drawing.Size(223, 20)
        Me.DTPfinalCaja.TabIndex = 2
        '
        'DTPinicialCaja
        '
        Me.DTPinicialCaja.Location = New System.Drawing.Point(82, 16)
        Me.DTPinicialCaja.Name = "DTPinicialCaja"
        Me.DTPinicialCaja.Size = New System.Drawing.Size(223, 20)
        Me.DTPinicialCaja.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(338, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fecha Final:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Fecha Inicial:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(929, 40)
        Me.Panel1.TabIndex = 22
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(895, 7)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 52
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(340, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(270, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "REPORTE CAJA MENOR ENTRE FECHAS"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(929, 485)
        Me.Panel3.TabIndex = 31
        '
        'FrmReporteFechasTotalCM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(929, 485)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnLimpia)
        Me.Controls.Add(Me.BtnImpri)
        Me.Controls.Add(Me.BtnConsu)
        Me.Controls.Add(Me.LblModReg)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(929, 485)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(929, 485)
        Me.Name = "FrmReporteFechasTotalCM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Reporte Caja Menor "
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnLimpia As Button
    Friend WithEvents BtnImpri As Button
    Friend WithEvents BtnConsu As Button
    Friend WithEvents LblModReg As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DTPfinalCaja As DateTimePicker
    Friend WithEvents DTPinicialCaja As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel3 As Panel
End Class
