<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSplash
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSplash))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LblConteo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblCarga = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(20, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(369, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Derechos Reservados de Autor@Jucef, Software 2.019-2.026, Rev-09-2026"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.White
        Me.ProgressBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.ProgressBar1.Location = New System.Drawing.Point(167, 132)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(168, 28)
        Me.ProgressBar1.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'LblConteo
        '
        Me.LblConteo.AutoSize = True
        Me.LblConteo.BackColor = System.Drawing.Color.Transparent
        Me.LblConteo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LblConteo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConteo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.LblConteo.Location = New System.Drawing.Point(351, 137)
        Me.LblConteo.Name = "LblConteo"
        Me.LblConteo.Size = New System.Drawing.Size(17, 18)
        Me.LblConteo.TabIndex = 2
        Me.LblConteo.Text = "0"
        Me.LblConteo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.MaximumSize = New System.Drawing.Size(413, 196)
        Me.PictureBox1.MinimumSize = New System.Drawing.Size(413, 196)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(413, 196)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'LblCarga
        '
        Me.LblCarga.AutoSize = True
        Me.LblCarga.BackColor = System.Drawing.Color.White
        Me.LblCarga.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.LblCarga.Location = New System.Drawing.Point(244, 12)
        Me.LblCarga.Name = "LblCarga"
        Me.LblCarga.Size = New System.Drawing.Size(10, 13)
        Me.LblCarga.TabIndex = 4
        Me.LblCarga.Text = "."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(187, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Estado: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(198, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "APPMINERGOLD"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(413, 196)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblCarga)
        Me.Controls.Add(Me.LblConteo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(413, 196)
        Me.MinimumSize = New System.Drawing.Size(413, 196)
        Me.Name = "FrmSplash"
        Me.Opacity = 0.8R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSplash"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LblConteo As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblCarga As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As Label
End Class
