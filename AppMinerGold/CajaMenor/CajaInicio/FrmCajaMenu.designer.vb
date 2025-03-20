<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCajaMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCajaMenu))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnEliminaIngre = New System.Windows.Forms.Button()
        Me.BtnEliminaEgre = New System.Windows.Forms.Button()
        Me.BtnReimpIng = New System.Windows.Forms.Button()
        Me.BtnCajaMenor = New System.Windows.Forms.Button()
        Me.BtnEgresos = New System.Windows.Forms.Button()
        Me.BtnIngresos = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNomPaciente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnEliminaIngre)
        Me.Panel2.Controls.Add(Me.BtnEliminaEgre)
        Me.Panel2.Controls.Add(Me.BtnReimpIng)
        Me.Panel2.Controls.Add(Me.BtnCajaMenor)
        Me.Panel2.Controls.Add(Me.BtnEgresos)
        Me.Panel2.Controls.Add(Me.BtnIngresos)
        Me.Panel2.Location = New System.Drawing.Point(35, 116)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(368, 212)
        Me.Panel2.TabIndex = 46
        '
        'BtnEliminaIngre
        '
        Me.BtnEliminaIngre.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BtnEliminaIngre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEliminaIngre.FlatAppearance.BorderSize = 0
        Me.BtnEliminaIngre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminaIngre.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminaIngre.Image = CType(resources.GetObject("BtnEliminaIngre.Image"), System.Drawing.Image)
        Me.BtnEliminaIngre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminaIngre.Location = New System.Drawing.Point(23, 143)
        Me.BtnEliminaIngre.Name = "BtnEliminaIngre"
        Me.BtnEliminaIngre.Size = New System.Drawing.Size(152, 52)
        Me.BtnEliminaIngre.TabIndex = 6
        Me.BtnEliminaIngre.Text = "Elimina Ingresos"
        Me.BtnEliminaIngre.UseVisualStyleBackColor = False
        '
        'BtnEliminaEgre
        '
        Me.BtnEliminaEgre.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BtnEliminaEgre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEliminaEgre.FlatAppearance.BorderSize = 0
        Me.BtnEliminaEgre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminaEgre.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminaEgre.Image = CType(resources.GetObject("BtnEliminaEgre.Image"), System.Drawing.Image)
        Me.BtnEliminaEgre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminaEgre.Location = New System.Drawing.Point(181, 143)
        Me.BtnEliminaEgre.Name = "BtnEliminaEgre"
        Me.BtnEliminaEgre.Size = New System.Drawing.Size(152, 52)
        Me.BtnEliminaEgre.TabIndex = 5
        Me.BtnEliminaEgre.Text = "Elimina Egresos"
        Me.BtnEliminaEgre.UseVisualStyleBackColor = False
        '
        'BtnReimpIng
        '
        Me.BtnReimpIng.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpIng.Image = CType(resources.GetObject("BtnReimpIng.Image"), System.Drawing.Image)
        Me.BtnReimpIng.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReimpIng.Location = New System.Drawing.Point(181, 85)
        Me.BtnReimpIng.Name = "BtnReimpIng"
        Me.BtnReimpIng.Size = New System.Drawing.Size(152, 52)
        Me.BtnReimpIng.TabIndex = 4
        Me.BtnReimpIng.Text = "     Reimprime Recibos"
        Me.BtnReimpIng.UseVisualStyleBackColor = True
        '
        'BtnCajaMenor
        '
        Me.BtnCajaMenor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCajaMenor.Image = CType(resources.GetObject("BtnCajaMenor.Image"), System.Drawing.Image)
        Me.BtnCajaMenor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCajaMenor.Location = New System.Drawing.Point(23, 85)
        Me.BtnCajaMenor.Name = "BtnCajaMenor"
        Me.BtnCajaMenor.Size = New System.Drawing.Size(152, 52)
        Me.BtnCajaMenor.TabIndex = 3
        Me.BtnCajaMenor.Text = "      Reporte Caja Menor"
        Me.BtnCajaMenor.UseVisualStyleBackColor = True
        '
        'BtnEgresos
        '
        Me.BtnEgresos.BackColor = System.Drawing.Color.Red
        Me.BtnEgresos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEgresos.FlatAppearance.BorderSize = 0
        Me.BtnEgresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEgresos.ForeColor = System.Drawing.Color.White
        Me.BtnEgresos.Image = CType(resources.GetObject("BtnEgresos.Image"), System.Drawing.Image)
        Me.BtnEgresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEgresos.Location = New System.Drawing.Point(181, 22)
        Me.BtnEgresos.Name = "BtnEgresos"
        Me.BtnEgresos.Size = New System.Drawing.Size(152, 52)
        Me.BtnEgresos.TabIndex = 2
        Me.BtnEgresos.Text = "Egresos"
        Me.BtnEgresos.UseVisualStyleBackColor = False
        '
        'BtnIngresos
        '
        Me.BtnIngresos.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnIngresos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnIngresos.FlatAppearance.BorderSize = 0
        Me.BtnIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIngresos.ForeColor = System.Drawing.Color.White
        Me.BtnIngresos.Image = CType(resources.GetObject("BtnIngresos.Image"), System.Drawing.Image)
        Me.BtnIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnIngresos.Location = New System.Drawing.Point(23, 22)
        Me.BtnIngresos.Name = "BtnIngresos"
        Me.BtnIngresos.Size = New System.Drawing.Size(152, 52)
        Me.BtnIngresos.TabIndex = 1
        Me.BtnIngresos.Text = "Ingresos"
        Me.BtnIngresos.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(439, 40)
        Me.Panel1.TabIndex = 44
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(406, 7)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 52
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(163, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 17)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "CAJA MENOR"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtNomPaciente
        '
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomPaciente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.TxtNomPaciente.Location = New System.Drawing.Point(117, 64)
        Me.TxtNomPaciente.Name = "TxtNomPaciente"
        Me.TxtNomPaciente.Size = New System.Drawing.Size(285, 20)
        Me.TxtNomPaciente.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Usuario Activo: "
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TxtNomPaciente)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(439, 380)
        Me.Panel3.TabIndex = 80
        '
        'FrmCajaMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(439, 380)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(439, 380)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(439, 380)
        Me.Name = "FrmCajaMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Caja Menor "
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnReimpIng As Button
    Friend WithEvents BtnCajaMenor As Button
    Friend WithEvents BtnEgresos As Button
    Friend WithEvents BtnIngresos As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtNomPaciente As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnEliminaEgre As Button
    Friend WithEvents BtnEliminaIngre As Button
End Class
