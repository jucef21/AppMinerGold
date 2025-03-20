<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTomarHuellas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTomarHuellas))
        Me.BtnRegresa = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtVeriCedula = New System.Windows.Forms.TextBox()
        Me.BtnVerifica = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.BtnIngresa = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnRegresa
        '
        Me.BtnRegresa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRegresa.Image = CType(resources.GetObject("BtnRegresa.Image"), System.Drawing.Image)
        Me.BtnRegresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRegresa.Location = New System.Drawing.Point(122, 376)
        Me.BtnRegresa.Name = "BtnRegresa"
        Me.BtnRegresa.Size = New System.Drawing.Size(135, 42)
        Me.BtnRegresa.TabIndex = 10
        Me.BtnRegresa.Text = "&Regresar"
        Me.BtnRegresa.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TxtVeriCedula)
        Me.Panel2.Controls.Add(Me.BtnVerifica)
        Me.Panel2.Location = New System.Drawing.Point(61, 209)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(241, 147)
        Me.Panel2.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Cédula:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(57, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "INGRESO DE DATOS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtVeriCedula
        '
        Me.TxtVeriCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVeriCedula.Location = New System.Drawing.Point(71, 34)
        Me.TxtVeriCedula.Name = "TxtVeriCedula"
        Me.TxtVeriCedula.Size = New System.Drawing.Size(124, 23)
        Me.TxtVeriCedula.TabIndex = 3
        Me.TxtVeriCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnVerifica
        '
        Me.BtnVerifica.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnVerifica.Image = CType(resources.GetObject("BtnVerifica.Image"), System.Drawing.Image)
        Me.BtnVerifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnVerifica.Location = New System.Drawing.Point(30, 75)
        Me.BtnVerifica.Name = "BtnVerifica"
        Me.BtnVerifica.Size = New System.Drawing.Size(185, 53)
        Me.BtnVerifica.TabIndex = 4
        Me.BtnVerifica.Text = "&VERIFICA DATOS"
        Me.BtnVerifica.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtCedula)
        Me.Panel1.Controls.Add(Me.BtnIngresa)
        Me.Panel1.Location = New System.Drawing.Point(61, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(241, 147)
        Me.Panel1.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cédula:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(57, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "INGRESO DE DATOS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCedula
        '
        Me.TxtCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCedula.Location = New System.Drawing.Point(71, 36)
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(124, 23)
        Me.TxtCedula.TabIndex = 1
        Me.TxtCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnIngresa
        '
        Me.BtnIngresa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnIngresa.Image = CType(resources.GetObject("BtnIngresa.Image"), System.Drawing.Image)
        Me.BtnIngresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnIngresa.Location = New System.Drawing.Point(30, 72)
        Me.BtnIngresa.Name = "BtnIngresa"
        Me.BtnIngresa.Size = New System.Drawing.Size(185, 53)
        Me.BtnIngresa.TabIndex = 2
        Me.BtnIngresa.Text = "     &INGRESAR DATOS"
        Me.BtnIngresa.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(145, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "BIOMETRÍA"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(368, 36)
        Me.Label1.TabIndex = 8
        '
        'FrmTomarHuellas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(366, 440)
        Me.Controls.Add(Me.BtnRegresa)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTomarHuellas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tomar Huellas"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnRegresa As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtVeriCedula As TextBox
    Friend WithEvents BtnVerifica As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents BtnIngresa As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
