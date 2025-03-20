<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuRepFundi_Platino
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuRepFundi_Platino))
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnRptFundi = New System.Windows.Forms.Button()
        Me.BtnReimpTrasalado = New System.Windows.Forms.Button()
        Me.BtnRelFundi = New System.Windows.Forms.Button()
        Me.BtnSaldoFundi = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnX
        '
        Me.BtnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.BackgroundImage = CType(resources.GetObject("BtnX.BackgroundImage"), System.Drawing.Image)
        Me.BtnX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Location = New System.Drawing.Point(395, 2)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 47
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(119, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SELECCIONE UNA OPCIÓN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(433, 40)
        Me.Panel1.TabIndex = 52
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(183, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(68, 69)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 51
        Me.PictureBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnRptFundi)
        Me.Panel2.Controls.Add(Me.BtnReimpTrasalado)
        Me.Panel2.Controls.Add(Me.BtnRelFundi)
        Me.Panel2.Controls.Add(Me.BtnSaldoFundi)
        Me.Panel2.Location = New System.Drawing.Point(52, 120)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(332, 232)
        Me.Panel2.TabIndex = 50
        '
        'BtnRptFundi
        '
        Me.BtnRptFundi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRptFundi.Image = CType(resources.GetObject("BtnRptFundi.Image"), System.Drawing.Image)
        Me.BtnRptFundi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRptFundi.Location = New System.Drawing.Point(44, 176)
        Me.BtnRptFundi.Name = "BtnRptFundi"
        Me.BtnRptFundi.Size = New System.Drawing.Size(233, 45)
        Me.BtnRptFundi.TabIndex = 52
        Me.BtnRptFundi.Text = "       Detalle &Proveddores x Fundición"
        Me.BtnRptFundi.UseVisualStyleBackColor = True
        '
        'BtnReimpTrasalado
        '
        Me.BtnReimpTrasalado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpTrasalado.Image = CType(resources.GetObject("BtnReimpTrasalado.Image"), System.Drawing.Image)
        Me.BtnReimpTrasalado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReimpTrasalado.Location = New System.Drawing.Point(44, 123)
        Me.BtnReimpTrasalado.Name = "BtnReimpTrasalado"
        Me.BtnReimpTrasalado.Size = New System.Drawing.Size(233, 45)
        Me.BtnReimpTrasalado.TabIndex = 51
        Me.BtnReimpTrasalado.Text = "Reimprime &Traslado"
        Me.BtnReimpTrasalado.UseVisualStyleBackColor = True
        '
        'BtnRelFundi
        '
        Me.BtnRelFundi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRelFundi.Image = CType(resources.GetObject("BtnRelFundi.Image"), System.Drawing.Image)
        Me.BtnRelFundi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRelFundi.Location = New System.Drawing.Point(44, 68)
        Me.BtnRelFundi.Name = "BtnRelFundi"
        Me.BtnRelFundi.Size = New System.Drawing.Size(233, 45)
        Me.BtnRelFundi.TabIndex = 50
        Me.BtnRelFundi.Text = "   Relación de Traslados"
        Me.BtnRelFundi.UseVisualStyleBackColor = True
        '
        'BtnSaldoFundi
        '
        Me.BtnSaldoFundi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSaldoFundi.Image = CType(resources.GetObject("BtnSaldoFundi.Image"), System.Drawing.Image)
        Me.BtnSaldoFundi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSaldoFundi.Location = New System.Drawing.Point(44, 11)
        Me.BtnSaldoFundi.Name = "BtnSaldoFundi"
        Me.BtnSaldoFundi.Size = New System.Drawing.Size(233, 45)
        Me.BtnSaldoFundi.TabIndex = 49
        Me.BtnSaldoFundi.Text = "   &Saldo Actual para Fundir"
        Me.BtnSaldoFundi.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(433, 390)
        Me.Panel3.TabIndex = 53
        '
        'FrmMenuRepFundi_Platino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(433, 390)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximumSize = New System.Drawing.Size(433, 390)
        Me.MinimumSize = New System.Drawing.Size(433, 390)
        Me.Name = "FrmMenuRepFundi_Platino"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Fundición Platino"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnX As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnRptFundi As Button
    Friend WithEvents BtnReimpTrasalado As Button
    Friend WithEvents BtnRelFundi As Button
    Friend WithEvents BtnSaldoFundi As Button
    Friend WithEvents Panel3 As Panel
End Class
