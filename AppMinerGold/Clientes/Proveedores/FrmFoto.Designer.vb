<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFoto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFoto))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.LstDevices = New System.Windows.Forms.ListBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.BtnCapturaF = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.PicFoto = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.Panel3.SuspendLayout()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel3.Controls.Add(Me.BtnX)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Location = New System.Drawing.Point(-1, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(340, 40)
        Me.Panel3.TabIndex = 72
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(289, 5)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(38, 29)
        Me.BtnX.TabIndex = 43
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(89, 11)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(140, 15)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "REGISTRO DE FOTO"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LstDevices
        '
        Me.LstDevices.Enabled = False
        Me.LstDevices.FormattingEnabled = True
        Me.LstDevices.Location = New System.Drawing.Point(9, 44)
        Me.LstDevices.Name = "LstDevices"
        Me.LstDevices.Size = New System.Drawing.Size(240, 17)
        Me.LstDevices.TabIndex = 73
        Me.LstDevices.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(128, 66)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(71, 13)
        Me.Label19.TabIndex = 71
        Me.Label19.Text = "Capturar Foto"
        '
        'BtnStop
        '
        Me.BtnStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStop.Image = CType(resources.GetObject("BtnStop.Image"), System.Drawing.Image)
        Me.BtnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStop.Location = New System.Drawing.Point(170, 260)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(111, 30)
        Me.BtnStop.TabIndex = 22
        Me.BtnStop.Text = "        Apaga Cámara"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'BtnCapturaF
        '
        Me.BtnCapturaF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCapturaF.Image = CType(resources.GetObject("BtnCapturaF.Image"), System.Drawing.Image)
        Me.BtnCapturaF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCapturaF.Location = New System.Drawing.Point(107, 296)
        Me.BtnCapturaF.Name = "BtnCapturaF"
        Me.BtnCapturaF.Size = New System.Drawing.Size(111, 42)
        Me.BtnCapturaF.TabIndex = 24
        Me.BtnCapturaF.Text = "     Toma Foto"
        Me.BtnCapturaF.UseVisualStyleBackColor = True
        '
        'BtnStart
        '
        Me.BtnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStart.Image = CType(resources.GetObject("BtnStart.Image"), System.Drawing.Image)
        Me.BtnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStart.Location = New System.Drawing.Point(53, 260)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(111, 30)
        Me.BtnStart.TabIndex = 21
        Me.BtnStart.Text = "        Inicia Cámara"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'PicFoto
        '
        Me.PicFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicFoto.ErrorImage = CType(resources.GetObject("PicFoto.ErrorImage"), System.Drawing.Image)
        Me.PicFoto.InitialImage = CType(resources.GetObject("PicFoto.InitialImage"), System.Drawing.Image)
        Me.PicFoto.Location = New System.Drawing.Point(81, 85)
        Me.PicFoto.Name = "PicFoto"
        Me.PicFoto.Size = New System.Drawing.Size(168, 165)
        Me.PicFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicFoto.TabIndex = 42
        Me.PicFoto.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnStop)
        Me.Panel1.Controls.Add(Me.BtnCapturaF)
        Me.Panel1.Controls.Add(Me.BtnStart)
        Me.Panel1.Controls.Add(Me.PicFoto)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(340, 360)
        Me.Panel1.TabIndex = 74
        '
        'FrmFoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(340, 360)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.LstDevices)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFoto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmFoto"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents LstDevices As ListBox
    Friend WithEvents Label19 As Label
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnCapturaF As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents PicFoto As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SaveFileDialog As SaveFileDialog
End Class
