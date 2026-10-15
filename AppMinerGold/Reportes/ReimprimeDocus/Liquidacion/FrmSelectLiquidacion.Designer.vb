<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectLiquidacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelectLiquidacion))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.DGVreimpLiquidacion = New System.Windows.Forms.DataGridView()
        Me.BtnDocLiquidacion = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtDocLiquidacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.DGVreimpLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(217, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(194, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "REIMPRESIÓN LIQUIDACIÓN"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
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
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Location = New System.Drawing.Point(585, 3)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 86
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'DGVreimpLiquidacion
        '
        Me.DGVreimpLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVreimpLiquidacion.Location = New System.Drawing.Point(24, 204)
        Me.DGVreimpLiquidacion.Name = "DGVreimpLiquidacion"
        Me.DGVreimpLiquidacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVreimpLiquidacion.Size = New System.Drawing.Size(583, 133)
        Me.DGVreimpLiquidacion.TabIndex = 52
        '
        'BtnDocLiquidacion
        '
        Me.BtnDocLiquidacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDocLiquidacion.FlatAppearance.BorderSize = 0
        Me.BtnDocLiquidacion.Image = CType(resources.GetObject("BtnDocLiquidacion.Image"), System.Drawing.Image)
        Me.BtnDocLiquidacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDocLiquidacion.Location = New System.Drawing.Point(260, 153)
        Me.BtnDocLiquidacion.Name = "BtnDocLiquidacion"
        Me.BtnDocLiquidacion.Size = New System.Drawing.Size(133, 40)
        Me.BtnDocLiquidacion.TabIndex = 51
        Me.BtnDocLiquidacion.Text = "&Busca Documento"
        Me.BtnDocLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDocLiquidacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDocLiquidacion.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtDocLiquidacion)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(123, 75)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(411, 65)
        Me.Panel2.TabIndex = 54
        '
        'TxtDocLiquidacion
        '
        Me.TxtDocLiquidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDocLiquidacion.Location = New System.Drawing.Point(213, 17)
        Me.TxtDocLiquidacion.Name = "TxtDocLiquidacion"
        Me.TxtDocLiquidacion.Size = New System.Drawing.Size(138, 26)
        Me.TxtDocLiquidacion.TabIndex = 1
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
        Me.Panel3.TabIndex = 55
        '
        'FrmSelectLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(623, 369)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGVreimpLiquidacion)
        Me.Controls.Add(Me.BtnDocLiquidacion)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(623, 369)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(623, 369)
        Me.Name = "FrmSelectLiquidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSelectLiquidacion"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGVreimpLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents DGVreimpLiquidacion As DataGridView
    Friend WithEvents BtnDocLiquidacion As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtDocLiquidacion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
End Class
