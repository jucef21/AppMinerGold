<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeleIngreEliminado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSeleIngreEliminado))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DGVeliminaEgreso = New System.Windows.Forms.DataGridView()
        Me.BtnDocIngreso = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtDocIngreso = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.DGVeliminaEgreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(623, 40)
        Me.Panel1.TabIndex = 53
        '
        'BtnX
        '
        Me.BtnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.BackgroundImage = CType(resources.GetObject("BtnX.BackgroundImage"), System.Drawing.Image)
        Me.BtnX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Location = New System.Drawing.Point(583, 2)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 84
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(134, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(362, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "CONSULTA DE DOCUMENTO DE INGRESO ELIMINADO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DGVeliminaEgreso
        '
        Me.DGVeliminaEgreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVeliminaEgreso.Location = New System.Drawing.Point(20, 195)
        Me.DGVeliminaEgreso.Name = "DGVeliminaEgreso"
        Me.DGVeliminaEgreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVeliminaEgreso.Size = New System.Drawing.Size(583, 109)
        Me.DGVeliminaEgreso.TabIndex = 51
        '
        'BtnDocIngreso
        '
        Me.BtnDocIngreso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDocIngreso.FlatAppearance.BorderSize = 0
        Me.BtnDocIngreso.Image = CType(resources.GetObject("BtnDocIngreso.Image"), System.Drawing.Image)
        Me.BtnDocIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDocIngreso.Location = New System.Drawing.Point(246, 142)
        Me.BtnDocIngreso.Name = "BtnDocIngreso"
        Me.BtnDocIngreso.Size = New System.Drawing.Size(143, 40)
        Me.BtnDocIngreso.TabIndex = 50
        Me.BtnDocIngreso.Text = "&Busca Documento"
        Me.BtnDocIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDocIngreso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDocIngreso.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtDocIngreso)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(82, 66)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(469, 65)
        Me.Panel2.TabIndex = 54
        '
        'TxtDocIngreso
        '
        Me.TxtDocIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDocIngreso.Location = New System.Drawing.Point(293, 13)
        Me.TxtDocIngreso.Name = "TxtDocIngreso"
        Me.TxtDocIngreso.Size = New System.Drawing.Size(138, 26)
        Me.TxtDocIngreso.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Dígite el Número de Documento Eliminado:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(131, 331)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(356, 13)
        Me.Label27.TabIndex = 55
        Me.Label27.Text = "Para Seleccionar el Cliente haz Doble Click Encima de la Fila del Registro."
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(623, 369)
        Me.Panel3.TabIndex = 56
        '
        'FrmSeleIngreEliminado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(623, 369)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGVeliminaEgreso)
        Me.Controls.Add(Me.BtnDocIngreso)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(623, 369)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(623, 369)
        Me.Name = "FrmSeleIngreEliminado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecciona Ingreso Eliminado"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGVeliminaEgreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents DGVeliminaEgreso As DataGridView
    Friend WithEvents BtnDocIngreso As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtDocIngreso As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Panel3 As Panel
End Class
