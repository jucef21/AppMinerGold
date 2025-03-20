<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHuellaCargar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHuellaCargar))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImpHuella = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCargar = New System.Windows.Forms.Button()
        Me.ImagenHuella = New System.Windows.Forms.PictureBox()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.ImagenHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(357, 40)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "CARGAR HUELLA DIGITAL"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnX
        '
        Me.BtnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnX.ForeColor = System.Drawing.Color.White
        Me.BtnX.Location = New System.Drawing.Point(349, 0)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(40, 40)
        Me.BtnX.TabIndex = 4
        Me.BtnX.Text = "X"
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnImpHuella)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BtnCargar)
        Me.Panel1.Controls.Add(Me.ImagenHuella)
        Me.Panel1.Controls.Add(Me.TxtCedula)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(390, 450)
        Me.Panel1.TabIndex = 52
        '
        'BtnImpHuella
        '
        Me.BtnImpHuella.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpHuella.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImpHuella.Image = CType(resources.GetObject("BtnImpHuella.Image"), System.Drawing.Image)
        Me.BtnImpHuella.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImpHuella.Location = New System.Drawing.Point(103, 365)
        Me.BtnImpHuella.Name = "BtnImpHuella"
        Me.BtnImpHuella.Size = New System.Drawing.Size(165, 43)
        Me.BtnImpHuella.TabIndex = 3
        Me.BtnImpHuella.Text = "Imprimir"
        Me.BtnImpHuella.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Digite el Número de Cédula:"
        '
        'BtnCargar
        '
        Me.BtnCargar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCargar.Image = CType(resources.GetObject("BtnCargar.Image"), System.Drawing.Image)
        Me.BtnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCargar.Location = New System.Drawing.Point(103, 117)
        Me.BtnCargar.Name = "BtnCargar"
        Me.BtnCargar.Size = New System.Drawing.Size(165, 43)
        Me.BtnCargar.TabIndex = 2
        Me.BtnCargar.Text = "Consultar"
        Me.BtnCargar.UseVisualStyleBackColor = True
        '
        'ImagenHuella
        '
        Me.ImagenHuella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImagenHuella.Location = New System.Drawing.Point(121, 178)
        Me.ImagenHuella.Name = "ImagenHuella"
        Me.ImagenHuella.Size = New System.Drawing.Size(130, 160)
        Me.ImagenHuella.TabIndex = 1
        Me.ImagenHuella.TabStop = False
        '
        'TxtCedula
        '
        Me.TxtCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCedula.Location = New System.Drawing.Point(200, 77)
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(134, 26)
        Me.TxtCedula.TabIndex = 1
        Me.TxtCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmHuellaCargar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(390, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnX)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmHuellaCargar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Huella Cargar"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ImagenHuella, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents BtnCargar As Button
    Friend WithEvents ImagenHuella As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnImpHuella As Button
End Class
