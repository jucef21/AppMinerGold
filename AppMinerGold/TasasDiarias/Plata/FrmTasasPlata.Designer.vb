<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTasasPlata
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTasasPlata))
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnRetefuente = New System.Windows.Forms.Button()
        Me.BtnRegalias = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblHoraActual = New System.Windows.Forms.Label()
        Me.LblHora = New System.Windows.Forms.Label()
        Me.LblFechaActual = New System.Windows.Forms.Label()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.BtnX.Location = New System.Drawing.Point(358, 5)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 58
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.BtnRetefuente)
        Me.Panel2.Controls.Add(Me.BtnRegalias)
        Me.Panel2.Location = New System.Drawing.Point(33, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(331, 184)
        Me.Panel2.TabIndex = 57
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 33)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 114)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'BtnRetefuente
        '
        Me.BtnRetefuente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRetefuente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRetefuente.Image = CType(resources.GetObject("BtnRetefuente.Image"), System.Drawing.Image)
        Me.BtnRetefuente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRetefuente.Location = New System.Drawing.Point(130, 97)
        Me.BtnRetefuente.Name = "BtnRetefuente"
        Me.BtnRetefuente.Size = New System.Drawing.Size(183, 50)
        Me.BtnRetefuente.TabIndex = 9
        Me.BtnRetefuente.Text = "   &Valor de Retefuente PLATA"
        Me.BtnRetefuente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRetefuente.UseVisualStyleBackColor = True
        '
        'BtnRegalias
        '
        Me.BtnRegalias.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRegalias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegalias.Image = CType(resources.GetObject("BtnRegalias.Image"), System.Drawing.Image)
        Me.BtnRegalias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRegalias.Location = New System.Drawing.Point(130, 33)
        Me.BtnRegalias.Name = "BtnRegalias"
        Me.BtnRegalias.Size = New System.Drawing.Size(183, 50)
        Me.BtnRegalias.TabIndex = 6
        Me.BtnRegalias.Text = "          Valor Regalias PLATA"
        Me.BtnRegalias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRegalias.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LblHoraActual)
        Me.Panel1.Controls.Add(Me.LblHora)
        Me.Panel1.Controls.Add(Me.LblFechaActual)
        Me.Panel1.Controls.Add(Me.LblFecha)
        Me.Panel1.Location = New System.Drawing.Point(30, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 51)
        Me.Panel1.TabIndex = 56
        '
        'LblHoraActual
        '
        Me.LblHoraActual.AutoSize = True
        Me.LblHoraActual.Location = New System.Drawing.Point(248, 17)
        Me.LblHoraActual.Name = "LblHoraActual"
        Me.LblHoraActual.Size = New System.Drawing.Size(10, 13)
        Me.LblHoraActual.TabIndex = 16
        Me.LblHoraActual.Text = "."
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Location = New System.Drawing.Point(214, 17)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(36, 13)
        Me.LblHora.TabIndex = 15
        Me.LblHora.Text = "Hora :"
        '
        'LblFechaActual
        '
        Me.LblFechaActual.AutoSize = True
        Me.LblFechaActual.Location = New System.Drawing.Point(54, 17)
        Me.LblFechaActual.Name = "LblFechaActual"
        Me.LblFechaActual.Size = New System.Drawing.Size(10, 13)
        Me.LblFechaActual.TabIndex = 14
        Me.LblFechaActual.Text = "."
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(5, 17)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblFecha.TabIndex = 13
        Me.LblFecha.Text = "Fecha :"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(397, 40)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "INGRESO DE TASAS DE PLATA"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(397, 294)
        Me.Panel3.TabIndex = 59
        '
        'Timer1
        '
        '
        'FrmTasasPlata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(397, 334)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnX)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmTasasPlata"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmTasasPlata"
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnX As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnRetefuente As Button
    Friend WithEvents BtnRegalias As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblHoraActual As Label
    Friend WithEvents LblHora As Label
    Friend WithEvents LblFechaActual As Label
    Friend WithEvents LblFecha As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Timer1 As Timer
End Class
