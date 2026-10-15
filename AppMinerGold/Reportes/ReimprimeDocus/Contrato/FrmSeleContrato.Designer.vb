<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeleContrato
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSeleContrato))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DGVreimpContrato = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtDocContrato = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnDocIngreso = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DGVreimpContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(623, 40)
        Me.Panel1.TabIndex = 38
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
        Me.BtnX.Location = New System.Drawing.Point(585, 3)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 86
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(227, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "REIMPRESIÓN CONTRATO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DGVreimpContrato
        '
        Me.DGVreimpContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVreimpContrato.Location = New System.Drawing.Point(19, 200)
        Me.DGVreimpContrato.Name = "DGVreimpContrato"
        Me.DGVreimpContrato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVreimpContrato.Size = New System.Drawing.Size(583, 133)
        Me.DGVreimpContrato.TabIndex = 37
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtDocContrato)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(118, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(411, 65)
        Me.Panel2.TabIndex = 39
        '
        'TxtDocContrato
        '
        Me.TxtDocContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDocContrato.Location = New System.Drawing.Point(213, 17)
        Me.TxtDocContrato.Name = "TxtDocContrato"
        Me.TxtDocContrato.Size = New System.Drawing.Size(138, 26)
        Me.TxtDocContrato.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Dígite el Número de Consecutivo:"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(623, 369)
        Me.Panel3.TabIndex = 40
        '
        'BtnDocIngreso
        '
        Me.BtnDocIngreso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDocIngreso.FlatAppearance.BorderSize = 0
        Me.BtnDocIngreso.Image = CType(resources.GetObject("BtnDocIngreso.Image"), System.Drawing.Image)
        Me.BtnDocIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDocIngreso.Location = New System.Drawing.Point(255, 149)
        Me.BtnDocIngreso.Name = "BtnDocIngreso"
        Me.BtnDocIngreso.Size = New System.Drawing.Size(133, 40)
        Me.BtnDocIngreso.TabIndex = 36
        Me.BtnDocIngreso.Text = "&Busca Documento"
        Me.BtnDocIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDocIngreso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDocIngreso.UseVisualStyleBackColor = True
        '
        'FrmSeleContrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(623, 369)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGVreimpContrato)
        Me.Controls.Add(Me.BtnDocIngreso)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(623, 369)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(623, 369)
        Me.Name = "FrmSeleContrato"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecciona Contrato"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGVreimpContrato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents DGVreimpContrato As DataGridView
    Friend WithEvents BtnDocIngreso As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtDocContrato As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
End Class
