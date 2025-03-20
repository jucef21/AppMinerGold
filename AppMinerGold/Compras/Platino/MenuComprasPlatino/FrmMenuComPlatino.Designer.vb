<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuComPlatino
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuComPlatino))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnEliminaComp = New System.Windows.Forms.Button()
        Me.BtnModificaCompras = New System.Windows.Forms.Button()
        Me.BtnCompras = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(88, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MENÚ DE COMPRAS DE PLATINO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel2.Controls.Add(Me.BtnX)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(403, 40)
        Me.Panel2.TabIndex = 51
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(370, 6)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 51
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnEliminaComp)
        Me.Panel1.Controls.Add(Me.BtnModificaCompras)
        Me.Panel1.Controls.Add(Me.BtnCompras)
        Me.Panel1.Location = New System.Drawing.Point(81, 89)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(237, 221)
        Me.Panel1.TabIndex = 48
        '
        'BtnEliminaComp
        '
        Me.BtnEliminaComp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEliminaComp.Image = CType(resources.GetObject("BtnEliminaComp.Image"), System.Drawing.Image)
        Me.BtnEliminaComp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminaComp.Location = New System.Drawing.Point(33, 146)
        Me.BtnEliminaComp.Name = "BtnEliminaComp"
        Me.BtnEliminaComp.Size = New System.Drawing.Size(172, 60)
        Me.BtnEliminaComp.TabIndex = 50
        Me.BtnEliminaComp.Text = "   &Elimina Compras"
        Me.BtnEliminaComp.UseVisualStyleBackColor = True
        '
        'BtnModificaCompras
        '
        Me.BtnModificaCompras.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnModificaCompras.Image = CType(resources.GetObject("BtnModificaCompras.Image"), System.Drawing.Image)
        Me.BtnModificaCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnModificaCompras.Location = New System.Drawing.Point(33, 79)
        Me.BtnModificaCompras.Name = "BtnModificaCompras"
        Me.BtnModificaCompras.Size = New System.Drawing.Size(172, 60)
        Me.BtnModificaCompras.TabIndex = 49
        Me.BtnModificaCompras.Text = "   &Modifica Compras"
        Me.BtnModificaCompras.UseVisualStyleBackColor = True
        '
        'BtnCompras
        '
        Me.BtnCompras.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCompras.Image = CType(resources.GetObject("BtnCompras.Image"), System.Drawing.Image)
        Me.BtnCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCompras.Location = New System.Drawing.Point(33, 13)
        Me.BtnCompras.Name = "BtnCompras"
        Me.BtnCompras.Size = New System.Drawing.Size(172, 60)
        Me.BtnCompras.TabIndex = 48
        Me.BtnCompras.Text = "   &Compras Platino"
        Me.BtnCompras.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(403, 384)
        Me.Panel3.TabIndex = 52
        '
        'FrmMenuComPlatino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(403, 384)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMenuComPlatino"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMenuComPlatino"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnEliminaComp As Button
    Friend WithEvents BtnModificaCompras As Button
    Friend WithEvents BtnCompras As Button
    Friend WithEvents Panel3 As Panel
End Class
