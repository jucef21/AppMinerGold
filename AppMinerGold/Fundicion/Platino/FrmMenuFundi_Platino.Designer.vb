<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuFundi_Platino
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuFundi_Platino))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnEliminaFundi = New System.Windows.Forms.Button()
        Me.BtnFundiReport = New System.Windows.Forms.Button()
        Me.BtnFundi = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(117, 11)
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
        Me.Panel1.TabIndex = 50
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
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(183, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(73, 65)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 49
        Me.PictureBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.BtnEliminaFundi)
        Me.Panel2.Controls.Add(Me.BtnFundiReport)
        Me.Panel2.Controls.Add(Me.BtnFundi)
        Me.Panel2.Location = New System.Drawing.Point(24, 73)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(385, 240)
        Me.Panel2.TabIndex = 48
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(24, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(148, 194)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'BtnEliminaFundi
        '
        Me.BtnEliminaFundi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEliminaFundi.Image = CType(resources.GetObject("BtnEliminaFundi.Image"), System.Drawing.Image)
        Me.BtnEliminaFundi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminaFundi.Location = New System.Drawing.Point(185, 88)
        Me.BtnEliminaFundi.Name = "BtnEliminaFundi"
        Me.BtnEliminaFundi.Size = New System.Drawing.Size(172, 60)
        Me.BtnEliminaFundi.TabIndex = 2
        Me.BtnEliminaFundi.Text = "   &Elimina Fundición"
        Me.BtnEliminaFundi.UseVisualStyleBackColor = True
        '
        'BtnFundiReport
        '
        Me.BtnFundiReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFundiReport.Image = CType(resources.GetObject("BtnFundiReport.Image"), System.Drawing.Image)
        Me.BtnFundiReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFundiReport.Location = New System.Drawing.Point(185, 156)
        Me.BtnFundiReport.Name = "BtnFundiReport"
        Me.BtnFundiReport.Size = New System.Drawing.Size(172, 60)
        Me.BtnFundiReport.TabIndex = 3
        Me.BtnFundiReport.Text = "   &Reportes"
        Me.BtnFundiReport.UseVisualStyleBackColor = True
        '
        'BtnFundi
        '
        Me.BtnFundi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFundi.Image = CType(resources.GetObject("BtnFundi.Image"), System.Drawing.Image)
        Me.BtnFundi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFundi.Location = New System.Drawing.Point(185, 22)
        Me.BtnFundi.Name = "BtnFundi"
        Me.BtnFundi.Size = New System.Drawing.Size(172, 60)
        Me.BtnFundi.TabIndex = 1
        Me.BtnFundi.Text = "   &Enviar a Fundir"
        Me.BtnFundi.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.MaximumSize = New System.Drawing.Size(433, 325)
        Me.Panel3.MinimumSize = New System.Drawing.Size(433, 325)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(433, 325)
        Me.Panel3.TabIndex = 51
        '
        'FrmMenuFundi_Platino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(433, 365)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(433, 365)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(433, 365)
        Me.Name = "FrmMenuFundi_Platino"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Fundición Platino"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnEliminaFundi As Button
    Friend WithEvents BtnFundiReport As Button
    Friend WithEvents BtnFundi As Button
    Friend WithEvents Panel3 As Panel
End Class
