<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReeimpMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReeimpMenu))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnImpElimEgre = New System.Windows.Forms.Button()
        Me.BtnImpElimIngre = New System.Windows.Forms.Button()
        Me.BtnReimpEgresos = New System.Windows.Forms.Button()
        Me.BtnReimpIng = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(410, 40)
        Me.Panel1.TabIndex = 20
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(377, 7)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 53
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(95, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(227, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "REIMPRESIÓN DE DOCUMENTOS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnImpElimEgre)
        Me.GroupBox1.Controls.Add(Me.BtnImpElimIngre)
        Me.GroupBox1.Controls.Add(Me.BtnReimpEgresos)
        Me.GroupBox1.Controls.Add(Me.BtnReimpIng)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 191)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione"
        '
        'BtnImpElimEgre
        '
        Me.BtnImpElimEgre.BackColor = System.Drawing.Color.Red
        Me.BtnImpElimEgre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpElimEgre.ForeColor = System.Drawing.Color.White
        Me.BtnImpElimEgre.Image = CType(resources.GetObject("BtnImpElimEgre.Image"), System.Drawing.Image)
        Me.BtnImpElimEgre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImpElimEgre.Location = New System.Drawing.Point(203, 100)
        Me.BtnImpElimEgre.Name = "BtnImpElimEgre"
        Me.BtnImpElimEgre.Size = New System.Drawing.Size(165, 55)
        Me.BtnImpElimEgre.TabIndex = 11
        Me.BtnImpElimEgre.Text = "    Reimprime Egresos Eliminados"
        Me.BtnImpElimEgre.UseVisualStyleBackColor = False
        '
        'BtnImpElimIngre
        '
        Me.BtnImpElimIngre.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnImpElimIngre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpElimIngre.ForeColor = System.Drawing.Color.White
        Me.BtnImpElimIngre.Image = CType(resources.GetObject("BtnImpElimIngre.Image"), System.Drawing.Image)
        Me.BtnImpElimIngre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImpElimIngre.Location = New System.Drawing.Point(203, 34)
        Me.BtnImpElimIngre.Name = "BtnImpElimIngre"
        Me.BtnImpElimIngre.Size = New System.Drawing.Size(165, 55)
        Me.BtnImpElimIngre.TabIndex = 10
        Me.BtnImpElimIngre.Text = "    Reimprime Ingresos Eliminados"
        Me.BtnImpElimIngre.UseVisualStyleBackColor = False
        '
        'BtnReimpEgresos
        '
        Me.BtnReimpEgresos.BackColor = System.Drawing.Color.Red
        Me.BtnReimpEgresos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpEgresos.ForeColor = System.Drawing.Color.White
        Me.BtnReimpEgresos.Image = CType(resources.GetObject("BtnReimpEgresos.Image"), System.Drawing.Image)
        Me.BtnReimpEgresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReimpEgresos.Location = New System.Drawing.Point(17, 100)
        Me.BtnReimpEgresos.Name = "BtnReimpEgresos"
        Me.BtnReimpEgresos.Size = New System.Drawing.Size(165, 55)
        Me.BtnReimpEgresos.TabIndex = 9
        Me.BtnReimpEgresos.Text = "    Reimprime EGRESOS"
        Me.BtnReimpEgresos.UseVisualStyleBackColor = False
        '
        'BtnReimpIng
        '
        Me.BtnReimpIng.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnReimpIng.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpIng.ForeColor = System.Drawing.Color.White
        Me.BtnReimpIng.Image = CType(resources.GetObject("BtnReimpIng.Image"), System.Drawing.Image)
        Me.BtnReimpIng.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReimpIng.Location = New System.Drawing.Point(17, 34)
        Me.BtnReimpIng.Name = "BtnReimpIng"
        Me.BtnReimpIng.Size = New System.Drawing.Size(165, 55)
        Me.BtnReimpIng.TabIndex = 8
        Me.BtnReimpIng.Text = "    Reimprime INGRESOS"
        Me.BtnReimpIng.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(410, 360)
        Me.Panel2.TabIndex = 24
        '
        'FrmReeimpMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(410, 360)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(410, 360)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(410, 360)
        Me.Name = "FrmReeimpMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Reeimprime Documentos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnReimpEgresos As Button
    Friend WithEvents BtnReimpIng As Button
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnImpElimEgre As Button
    Friend WithEvents BtnImpElimIngre As Button
End Class
