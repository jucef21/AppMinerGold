<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProveeMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProveeMenu))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnFechas = New System.Windows.Forms.Button()
        Me.BtnCompleto = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnDatosClientes = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel3.Controls.Add(Me.BtnX)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(373, 40)
        Me.Panel3.TabIndex = 8
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
        Me.BtnX.Location = New System.Drawing.Point(335, 2)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 81
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(81, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(211, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "REPORTES DE PROVEEDORES"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnDatosClientes)
        Me.Panel1.Controls.Add(Me.BtnFechas)
        Me.Panel1.Controls.Add(Me.BtnCompleto)
        Me.Panel1.Location = New System.Drawing.Point(59, 90)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(249, 223)
        Me.Panel1.TabIndex = 10
        '
        'BtnFechas
        '
        Me.BtnFechas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFechas.FlatAppearance.BorderSize = 0
        Me.BtnFechas.Image = CType(resources.GetObject("BtnFechas.Image"), System.Drawing.Image)
        Me.BtnFechas.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnFechas.Location = New System.Drawing.Point(30, 89)
        Me.BtnFechas.Name = "BtnFechas"
        Me.BtnFechas.Size = New System.Drawing.Size(185, 42)
        Me.BtnFechas.TabIndex = 11
        Me.BtnFechas.Text = "Reporte por Fechas"
        Me.BtnFechas.UseVisualStyleBackColor = True
        '
        'BtnCompleto
        '
        Me.BtnCompleto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCompleto.FlatAppearance.BorderSize = 0
        Me.BtnCompleto.Image = CType(resources.GetObject("BtnCompleto.Image"), System.Drawing.Image)
        Me.BtnCompleto.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnCompleto.Location = New System.Drawing.Point(30, 27)
        Me.BtnCompleto.Name = "BtnCompleto"
        Me.BtnCompleto.Size = New System.Drawing.Size(185, 42)
        Me.BtnCompleto.TabIndex = 10
        Me.BtnCompleto.Text = "Reporte Completo"
        Me.BtnCompleto.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(373, 396)
        Me.Panel2.TabIndex = 11
        '
        'BtnDatosClientes
        '
        Me.BtnDatosClientes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDatosClientes.FlatAppearance.BorderSize = 0
        Me.BtnDatosClientes.Image = CType(resources.GetObject("BtnDatosClientes.Image"), System.Drawing.Image)
        Me.BtnDatosClientes.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnDatosClientes.Location = New System.Drawing.Point(30, 152)
        Me.BtnDatosClientes.Name = "BtnDatosClientes"
        Me.BtnDatosClientes.Size = New System.Drawing.Size(185, 42)
        Me.BtnDatosClientes.TabIndex = 12
        Me.BtnDatosClientes.Text = "   Informe Datos Completos"
        Me.BtnDatosClientes.UseVisualStyleBackColor = True
        '
        'FrmProveeMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(373, 396)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(373, 396)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(373, 396)
        Me.Name = "FrmProveeMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Menú Proveedores"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnFechas As Button
    Friend WithEvents BtnCompleto As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents BtnDatosClientes As Button
End Class
