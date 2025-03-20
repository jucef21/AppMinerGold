<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEliminaFundi_Platino
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEliminaFundi_Platino))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.TxtConsecutivo = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Txtpuros = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txtley = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txtbrutos = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txttipometal = New System.Windows.Forms.TextBox()
        Me.TxtFechafundi = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblHoraActual = New System.Windows.Forms.Label()
        Me.LblHora = New System.Windows.Forms.Label()
        Me.LblFechaActual = New System.Windows.Forms.Label()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.TxtId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnEliminaFundi = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(114, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(225, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "ELIMINA FUNDICIÓN DE PLATINO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(433, 40)
        Me.Panel1.TabIndex = 223
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
        Me.BtnX.Location = New System.Drawing.Point(395, 1)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 46
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'TxtConsecutivo
        '
        Me.TxtConsecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConsecutivo.Location = New System.Drawing.Point(186, 125)
        Me.TxtConsecutivo.Name = "TxtConsecutivo"
        Me.TxtConsecutivo.Size = New System.Drawing.Size(73, 26)
        Me.TxtConsecutivo.TabIndex = 222
        Me.TxtConsecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Txtpuros)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Txtley)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Txtbrutos)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Txttipometal)
        Me.Panel3.Controls.Add(Me.TxtFechafundi)
        Me.Panel3.Location = New System.Drawing.Point(16, 161)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(393, 205)
        Me.Panel3.TabIndex = 225
        '
        'Txtpuros
        '
        Me.Txtpuros.Location = New System.Drawing.Point(195, 157)
        Me.Txtpuros.Name = "Txtpuros"
        Me.Txtpuros.Size = New System.Drawing.Size(100, 20)
        Me.Txtpuros.TabIndex = 14
        Me.Txtpuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha de la Fundición :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(100, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo de Metal :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(54, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Total de Gramos Brutos :"
        '
        'Txtley
        '
        Me.Txtley.Location = New System.Drawing.Point(195, 122)
        Me.Txtley.Name = "Txtley"
        Me.Txtley.Size = New System.Drawing.Size(100, 20)
        Me.Txtley.TabIndex = 13
        Me.Txtley.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(73, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Ley de la Fundición :"
        '
        'Txtbrutos
        '
        Me.Txtbrutos.Location = New System.Drawing.Point(195, 90)
        Me.Txtbrutos.Name = "Txtbrutos"
        Me.Txtbrutos.Size = New System.Drawing.Size(100, 20)
        Me.Txtbrutos.TabIndex = 12
        Me.Txtbrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(57, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Total de Gramos Puros :"
        '
        'Txttipometal
        '
        Me.Txttipometal.Location = New System.Drawing.Point(195, 33)
        Me.Txttipometal.Name = "Txttipometal"
        Me.Txttipometal.Size = New System.Drawing.Size(100, 20)
        Me.Txttipometal.TabIndex = 11
        Me.Txttipometal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtFechafundi
        '
        Me.TxtFechafundi.Location = New System.Drawing.Point(195, 8)
        Me.TxtFechafundi.Name = "TxtFechafundi"
        Me.TxtFechafundi.Size = New System.Drawing.Size(100, 20)
        Me.TxtFechafundi.TabIndex = 10
        Me.TxtFechafundi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LblHoraActual)
        Me.Panel2.Controls.Add(Me.LblHora)
        Me.Panel2.Controls.Add(Me.LblFechaActual)
        Me.Panel2.Controls.Add(Me.LblFecha)
        Me.Panel2.Location = New System.Drawing.Point(16, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(393, 57)
        Me.Panel2.TabIndex = 224
        '
        'LblHoraActual
        '
        Me.LblHoraActual.AutoSize = True
        Me.LblHoraActual.Location = New System.Drawing.Point(290, 19)
        Me.LblHoraActual.Name = "LblHoraActual"
        Me.LblHoraActual.Size = New System.Drawing.Size(10, 13)
        Me.LblHoraActual.TabIndex = 20
        Me.LblHoraActual.Text = "."
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Location = New System.Drawing.Point(248, 19)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(36, 13)
        Me.LblHora.TabIndex = 19
        Me.LblHora.Text = "Hora :"
        '
        'LblFechaActual
        '
        Me.LblFechaActual.AutoSize = True
        Me.LblFechaActual.Location = New System.Drawing.Point(62, 19)
        Me.LblFechaActual.Name = "LblFechaActual"
        Me.LblFechaActual.Size = New System.Drawing.Size(10, 13)
        Me.LblFechaActual.TabIndex = 18
        Me.LblFechaActual.Text = "."
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(13, 19)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblFecha.TabIndex = 17
        Me.LblFecha.Text = "Fecha :"
        '
        'TxtId
        '
        Me.TxtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtId.Location = New System.Drawing.Point(25, 125)
        Me.TxtId.Name = "TxtId"
        Me.TxtId.Size = New System.Drawing.Size(57, 26)
        Me.TxtId.TabIndex = 221
        Me.TxtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtId.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(88, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 220
        Me.Label1.Text = "No. Consecutivo :"
        '
        'BtnEliminaFundi
        '
        Me.BtnEliminaFundi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEliminaFundi.Image = CType(resources.GetObject("BtnEliminaFundi.Image"), System.Drawing.Image)
        Me.BtnEliminaFundi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminaFundi.Location = New System.Drawing.Point(128, 392)
        Me.BtnEliminaFundi.Name = "BtnEliminaFundi"
        Me.BtnEliminaFundi.Size = New System.Drawing.Size(174, 46)
        Me.BtnEliminaFundi.TabIndex = 211
        Me.BtnEliminaFundi.Text = "Elimina Fundición"
        Me.BtnEliminaFundi.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnEliminaFundi)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.MaximumSize = New System.Drawing.Size(433, 489)
        Me.Panel4.MinimumSize = New System.Drawing.Size(433, 489)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(433, 489)
        Me.Panel4.TabIndex = 226
        '
        'Timer1
        '
        '
        'FrmEliminaFundi_Platino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(433, 489)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtConsecutivo)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TxtId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(433, 489)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(433, 489)
        Me.Name = "FrmEliminaFundi_Platino"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Elimina Fundición Platino"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents TxtConsecutivo As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Txtpuros As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Txtley As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Txtbrutos As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Txttipometal As TextBox
    Friend WithEvents TxtFechafundi As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblHoraActual As Label
    Friend WithEvents LblHora As Label
    Friend WithEvents LblFechaActual As Label
    Friend WithEvents LblFecha As Label
    Friend WithEvents TxtId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnEliminaFundi As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Timer1 As Timer
End Class
