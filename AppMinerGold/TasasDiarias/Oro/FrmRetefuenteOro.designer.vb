<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRetefuenteOro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRetefuenteOro))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DGVretefuente = New System.Windows.Forms.DataGridView()
        Me.CboAño = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CboMes = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtVrRetefuente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnModifica = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnGuardaCambios = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblHoraActual = New System.Windows.Forms.Label()
        Me.LblHora = New System.Windows.Forms.Label()
        Me.LblFechaActual = New System.Windows.Forms.Label()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtId = New System.Windows.Forms.TextBox()
        CType(Me.DGVretefuente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(390, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 17)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Formato ""9.00"""
        '
        'DGVretefuente
        '
        Me.DGVretefuente.AllowUserToAddRows = False
        Me.DGVretefuente.AllowUserToDeleteRows = False
        Me.DGVretefuente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVretefuente.Enabled = False
        Me.DGVretefuente.Location = New System.Drawing.Point(144, 250)
        Me.DGVretefuente.Name = "DGVretefuente"
        Me.DGVretefuente.ReadOnly = True
        Me.DGVretefuente.RowHeadersWidth = 51
        Me.DGVretefuente.Size = New System.Drawing.Size(397, 154)
        Me.DGVretefuente.TabIndex = 10
        '
        'CboAño
        '
        Me.CboAño.FormattingEnabled = True
        Me.CboAño.Location = New System.Drawing.Point(437, 202)
        Me.CboAño.Name = "CboAño"
        Me.CboAño.Size = New System.Drawing.Size(83, 21)
        Me.CboAño.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(353, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Ingrese el Año:"
        '
        'CboMes
        '
        Me.CboMes.FormattingEnabled = True
        Me.CboMes.Location = New System.Drawing.Point(207, 202)
        Me.CboMes.Name = "CboMes"
        Me.CboMes.Size = New System.Drawing.Size(140, 21)
        Me.CboMes.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Ingrese el Mes correspondiente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Ingrese el Valor Para este Mes:"
        '
        'TxtVrRetefuente
        '
        Me.TxtVrRetefuente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVrRetefuente.Location = New System.Drawing.Point(229, 162)
        Me.TxtVrRetefuente.Name = "TxtVrRetefuente"
        Me.TxtVrRetefuente.Size = New System.Drawing.Size(126, 26)
        Me.TxtVrRetefuente.TabIndex = 2
        Me.TxtVrRetefuente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(176, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Ingresar el Valor del procentaje de Retefuente."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnNuevo)
        Me.GroupBox1.Controls.Add(Me.BtnModifica)
        Me.GroupBox1.Controls.Add(Me.BtnUpdate)
        Me.GroupBox1.Controls.Add(Me.BtnGuardar)
        Me.GroupBox1.Controls.Add(Me.BtnGuardaCambios)
        Me.GroupBox1.Location = New System.Drawing.Point(108, 424)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(356, 60)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(122, 14)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(107, 40)
        Me.BtnNuevo.TabIndex = 6
        Me.BtnNuevo.Text = "   &Nuevo"
        Me.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'BtnModifica
        '
        Me.BtnModifica.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnModifica.Image = CType(resources.GetObject("BtnModifica.Image"), System.Drawing.Image)
        Me.BtnModifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnModifica.Location = New System.Drawing.Point(236, 14)
        Me.BtnModifica.Name = "BtnModifica"
        Me.BtnModifica.Size = New System.Drawing.Size(107, 40)
        Me.BtnModifica.TabIndex = 7
        Me.BtnModifica.Text = "   &Modificar"
        Me.BtnModifica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnModifica.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUpdate.Image = CType(resources.GetObject("BtnUpdate.Image"), System.Drawing.Image)
        Me.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUpdate.Location = New System.Drawing.Point(6, 14)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(107, 40)
        Me.BtnUpdate.TabIndex = 5
        Me.BtnUpdate.Text = "   &Actualiza"
        Me.BtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(122, 14)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(107, 40)
        Me.BtnGuardar.TabIndex = 9
        Me.BtnGuardar.Text = "   &Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnGuardaCambios
        '
        Me.BtnGuardaCambios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGuardaCambios.Image = CType(resources.GetObject("BtnGuardaCambios.Image"), System.Drawing.Image)
        Me.BtnGuardaCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardaCambios.Location = New System.Drawing.Point(237, 14)
        Me.BtnGuardaCambios.Name = "BtnGuardaCambios"
        Me.BtnGuardaCambios.Size = New System.Drawing.Size(107, 40)
        Me.BtnGuardaCambios.TabIndex = 8
        Me.BtnGuardaCambios.Text = "   &Guardar Cambios"
        Me.BtnGuardaCambios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnGuardaCambios.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LblHoraActual)
        Me.Panel1.Controls.Add(Me.LblHora)
        Me.Panel1.Controls.Add(Me.LblFechaActual)
        Me.Panel1.Controls.Add(Me.LblFecha)
        Me.Panel1.Location = New System.Drawing.Point(41, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(479, 51)
        Me.Panel1.TabIndex = 44
        '
        'LblHoraActual
        '
        Me.LblHoraActual.AutoSize = True
        Me.LblHoraActual.Location = New System.Drawing.Point(352, 18)
        Me.LblHoraActual.Name = "LblHoraActual"
        Me.LblHoraActual.Size = New System.Drawing.Size(10, 13)
        Me.LblHoraActual.TabIndex = 16
        Me.LblHoraActual.Text = "."
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Location = New System.Drawing.Point(310, 18)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(36, 13)
        Me.LblHora.TabIndex = 15
        Me.LblHora.Text = "Hora :"
        '
        'LblFechaActual
        '
        Me.LblFechaActual.AutoSize = True
        Me.LblFechaActual.Location = New System.Drawing.Point(124, 18)
        Me.LblFechaActual.Name = "LblFechaActual"
        Me.LblFechaActual.Size = New System.Drawing.Size(10, 13)
        Me.LblFechaActual.TabIndex = 14
        Me.LblFechaActual.Text = "."
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(75, 18)
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
        Me.Label6.Size = New System.Drawing.Size(566, 40)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "INGRESO DE RETEFUENTE DE ORO"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(359, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 20)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "%"
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
        Me.BtnX.Location = New System.Drawing.Point(524, 3)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 52
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.DGVretefuente)
        Me.Panel2.Controls.Add(Me.TxtId)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.TxtVrRetefuente)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.CboAño)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.CboMes)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(566, 513)
        Me.Panel2.TabIndex = 53
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(28, 259)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 114)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 58
        Me.PictureBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(194, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Ingrese Id:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtId
        '
        Me.TxtId.Location = New System.Drawing.Point(257, 134)
        Me.TxtId.Name = "TxtId"
        Me.TxtId.Size = New System.Drawing.Size(53, 20)
        Me.TxtId.TabIndex = 1
        Me.TxtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmRetefuenteOro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(566, 513)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnX)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(566, 513)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(566, 513)
        Me.Name = "FrmRetefuenteOro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Retefuente"
        CType(Me.DGVretefuente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents DGVretefuente As DataGridView
    Friend WithEvents CboAño As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CboMes As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtVrRetefuente As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnNuevo As Button
    Friend WithEvents BtnModifica As Button
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents BtnGuardaCambios As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblHoraActual As Label
    Friend WithEvents LblHora As Label
    Friend WithEvents LblFechaActual As Label
    Friend WithEvents LblFecha As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label7 As Label
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtId As TextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
