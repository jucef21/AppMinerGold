<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeleEgresos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSeleEgresos))
        Me.DGVreimpEgreso = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtDocEgreso = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnDocEgreso = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtEmpCiu = New System.Windows.Forms.TextBox()
        CType(Me.DGVreimpEgreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGVreimpEgreso
        '
        Me.DGVreimpEgreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVreimpEgreso.Location = New System.Drawing.Point(19, 202)
        Me.DGVreimpEgreso.Name = "DGVreimpEgreso"
        Me.DGVreimpEgreso.Size = New System.Drawing.Size(583, 113)
        Me.DGVreimpEgreso.TabIndex = 29
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TxtDocEgreso)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(111, 66)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(411, 65)
        Me.Panel3.TabIndex = 28
        '
        'TxtDocEgreso
        '
        Me.TxtDocEgreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDocEgreso.Location = New System.Drawing.Point(213, 17)
        Me.TxtDocEgreso.Name = "TxtDocEgreso"
        Me.TxtDocEgreso.Size = New System.Drawing.Size(138, 26)
        Me.TxtDocEgreso.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Dígite el Número de Documento:"
        '
        'BtnDocEgreso
        '
        Me.BtnDocEgreso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDocEgreso.FlatAppearance.BorderSize = 0
        Me.BtnDocEgreso.Image = CType(resources.GetObject("BtnDocEgreso.Image"), System.Drawing.Image)
        Me.BtnDocEgreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDocEgreso.Location = New System.Drawing.Point(223, 147)
        Me.BtnDocEgreso.Name = "BtnDocEgreso"
        Me.BtnDocEgreso.Size = New System.Drawing.Size(168, 40)
        Me.BtnDocEgreso.TabIndex = 26
        Me.BtnDocEgreso.Text = "     &Busca Documento"
        Me.BtnDocEgreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDocEgreso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDocEgreso.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(623, 40)
        Me.Panel1.TabIndex = 25
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(591, 7)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 54
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(179, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(310, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "REIMPRESIÓN DE EGRESOS DE CAJA MENOR"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtEmpCiu)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(623, 369)
        Me.Panel2.TabIndex = 30
        '
        'TxtEmpCiu
        '
        Me.TxtEmpCiu.Location = New System.Drawing.Point(503, 320)
        Me.TxtEmpCiu.Name = "TxtEmpCiu"
        Me.TxtEmpCiu.Size = New System.Drawing.Size(100, 20)
        Me.TxtEmpCiu.TabIndex = 0
        Me.TxtEmpCiu.Visible = False
        '
        'FrmSeleEgresos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(623, 369)
        Me.ControlBox = False
        Me.Controls.Add(Me.DGVreimpEgreso)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.BtnDocEgreso)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(623, 369)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(623, 369)
        Me.Name = "FrmSeleEgresos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Selección de Egresos"
        CType(Me.DGVreimpEgreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGVreimpEgreso As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TxtDocEgreso As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnDocEgreso As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtEmpCiu As TextBox
End Class
