<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeleccionaReporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSeleccionaReporte))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnX = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnImpriAse1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkTotal = New System.Windows.Forms.CheckBox()
        Me.ChkEgresos = New System.Windows.Forms.CheckBox()
        Me.ChkIngresos = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnX)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(349, 40)
        Me.Panel1.TabIndex = 23
        '
        'BtnX
        '
        Me.BtnX.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnX.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.BtnX.FlatAppearance.BorderSize = 0
        Me.BtnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnX.Image = CType(resources.GetObject("BtnX.Image"), System.Drawing.Image)
        Me.BtnX.Location = New System.Drawing.Point(312, 8)
        Me.BtnX.Name = "BtnX"
        Me.BtnX.Size = New System.Drawing.Size(25, 25)
        Me.BtnX.TabIndex = 54
        Me.BtnX.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(84, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(172, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "REPORTES CAJA MENOR"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnImpriAse1
        '
        Me.BtnImpriAse1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImpriAse1.FlatAppearance.BorderSize = 0
        Me.BtnImpriAse1.Image = CType(resources.GetObject("BtnImpriAse1.Image"), System.Drawing.Image)
        Me.BtnImpriAse1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnImpriAse1.Location = New System.Drawing.Point(95, 229)
        Me.BtnImpriAse1.Name = "BtnImpriAse1"
        Me.BtnImpriAse1.Size = New System.Drawing.Size(120, 40)
        Me.BtnImpriAse1.TabIndex = 4
        Me.BtnImpriAse1.Text = "     &Imprimir"
        Me.BtnImpriAse1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkTotal)
        Me.GroupBox1.Controls.Add(Me.ChkEgresos)
        Me.GroupBox1.Controls.Add(Me.ChkIngresos)
        Me.GroupBox1.Location = New System.Drawing.Point(50, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(241, 135)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione Opción"
        '
        'ChkTotal
        '
        Me.ChkTotal.AutoSize = True
        Me.ChkTotal.Location = New System.Drawing.Point(79, 97)
        Me.ChkTotal.Name = "ChkTotal"
        Me.ChkTotal.Size = New System.Drawing.Size(70, 17)
        Me.ChkTotal.TabIndex = 3
        Me.ChkTotal.Text = "Completo"
        Me.ChkTotal.UseVisualStyleBackColor = True
        '
        'ChkEgresos
        '
        Me.ChkEgresos.AutoSize = True
        Me.ChkEgresos.Location = New System.Drawing.Point(79, 64)
        Me.ChkEgresos.Name = "ChkEgresos"
        Me.ChkEgresos.Size = New System.Drawing.Size(64, 17)
        Me.ChkEgresos.TabIndex = 2
        Me.ChkEgresos.Text = "Egresos"
        Me.ChkEgresos.UseVisualStyleBackColor = True
        '
        'ChkIngresos
        '
        Me.ChkIngresos.AutoSize = True
        Me.ChkIngresos.Location = New System.Drawing.Point(79, 36)
        Me.ChkIngresos.Name = "ChkIngresos"
        Me.ChkIngresos.Size = New System.Drawing.Size(66, 17)
        Me.ChkIngresos.TabIndex = 1
        Me.ChkIngresos.Text = "Ingresos"
        Me.ChkIngresos.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnImpriAse1)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(349, 310)
        Me.Panel2.TabIndex = 33
        '
        'FrmSeleccionaReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(349, 310)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(349, 310)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(349, 310)
        Me.Name = "FrmSeleccionaReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Selecciona Reporte "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnImpriAse1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ChkTotal As CheckBox
    Friend WithEvents ChkEgresos As CheckBox
    Friend WithEvents ChkIngresos As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnX As Button
End Class
