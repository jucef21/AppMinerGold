<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSelectReport
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelectReport))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Btn30Total = New System.Windows.Forms.Button()
        Me.Btn70Total = New System.Windows.Forms.Button()
        Me.BtnImpTD = New System.Windows.Forms.Button()
        Me.BtnConta30 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Btn30Total)
        Me.GroupBox1.Controls.Add(Me.Btn70Total)
        Me.GroupBox1.Controls.Add(Me.BtnImpTD)
        Me.GroupBox1.Controls.Add(Me.BtnConta30)
        Me.GroupBox1.Location = New System.Drawing.Point(53, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(255, 207)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reporte de %"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.BtnX)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(360, 40)
        Me.Panel3.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(313, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "REPORTE DE PROVEEDORES - CONTABILIDAD"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(360, 288)
        Me.Panel1.TabIndex = 58
        '
        'BtnX
        '
        Me.BtnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.BtnX.BackgroundImage = CType(resources.GetObject("BtnX.BackgroundImage"), System.Drawing.Image)
        Me.BtnX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Location = New System.Drawing.Point(320, 3)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(35, 35)
        Me.BtnX.TabIndex = 79
        Me.BtnX.UseVisualStyleBackColor = False
        '
        'Btn30Total
        '
        Me.Btn30Total.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn30Total.FlatAppearance.BorderSize = 0
        Me.Btn30Total.Image = CType(resources.GetObject("Btn30Total.Image"), System.Drawing.Image)
        Me.Btn30Total.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn30Total.Location = New System.Drawing.Point(17, 160)
        Me.Btn30Total.Name = "Btn30Total"
        Me.Btn30Total.Size = New System.Drawing.Size(210, 40)
        Me.Btn30Total.TabIndex = 55
        Me.Btn30Total.Text = "     &Imprimir 30% Totales x Fecha"
        Me.Btn30Total.UseVisualStyleBackColor = True
        '
        'Btn70Total
        '
        Me.Btn70Total.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn70Total.FlatAppearance.BorderSize = 0
        Me.Btn70Total.Image = CType(resources.GetObject("Btn70Total.Image"), System.Drawing.Image)
        Me.Btn70Total.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn70Total.Location = New System.Drawing.Point(17, 68)
        Me.Btn70Total.Name = "Btn70Total"
        Me.Btn70Total.Size = New System.Drawing.Size(210, 40)
        Me.Btn70Total.TabIndex = 54
        Me.Btn70Total.Text = "     &Imprimir 70% Totales x Fecha"
        Me.Btn70Total.UseVisualStyleBackColor = True
        '
        'BtnImpTD
        '
        Me.BtnImpTD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpTD.FlatAppearance.BorderSize = 0
        Me.BtnImpTD.Image = CType(resources.GetObject("BtnImpTD.Image"), System.Drawing.Image)
        Me.BtnImpTD.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnImpTD.Location = New System.Drawing.Point(17, 19)
        Me.BtnImpTD.Name = "BtnImpTD"
        Me.BtnImpTD.Size = New System.Drawing.Size(210, 40)
        Me.BtnImpTD.TabIndex = 52
        Me.BtnImpTD.Text = "     &Imprimir 70% por Consecutivo"
        Me.BtnImpTD.UseVisualStyleBackColor = True
        '
        'BtnConta30
        '
        Me.BtnConta30.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConta30.FlatAppearance.BorderSize = 0
        Me.BtnConta30.Image = CType(resources.GetObject("BtnConta30.Image"), System.Drawing.Image)
        Me.BtnConta30.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnConta30.Location = New System.Drawing.Point(17, 114)
        Me.BtnConta30.Name = "BtnConta30"
        Me.BtnConta30.Size = New System.Drawing.Size(210, 40)
        Me.BtnConta30.TabIndex = 53
        Me.BtnConta30.Text = "     &Imprimir 30% por Consecutivo"
        Me.BtnConta30.UseVisualStyleBackColor = True
        '
        'FrmSelectReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(360, 288)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelectReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecciona Reporte"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnConta30 As Button
    Friend WithEvents BtnImpTD As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnX As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Btn70Total As Button
    Friend WithEvents Btn30Total As Button
End Class
