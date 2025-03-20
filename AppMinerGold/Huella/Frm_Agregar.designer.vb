<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Agregar
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Agregar))
        Me.EnrollmentControl = New DPFP.Gui.Enrollment.EnrollmentControl()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnRevisar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'EnrollmentControl
        '
        Me.EnrollmentControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.EnrollmentControl.EnrolledFingerMask = 0
        Me.EnrollmentControl.Location = New System.Drawing.Point(0, 0)
        Me.EnrollmentControl.MaxEnrollFingerCount = 10
        Me.EnrollmentControl.Name = "EnrollmentControl"
        Me.EnrollmentControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000"
        Me.EnrollmentControl.Size = New System.Drawing.Size(492, 314)
        Me.EnrollmentControl.TabIndex = 4
        '
        'BtnSalir
        '
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir.Location = New System.Drawing.Point(359, 332)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(120, 40)
        Me.BtnSalir.TabIndex = 5
        Me.BtnSalir.Text = "&Cerrar"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnRevisar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(490, 388)
        Me.Panel1.TabIndex = 6
        '
        'BtnRevisar
        '
        Me.BtnRevisar.Location = New System.Drawing.Point(11, 331)
        Me.BtnRevisar.Name = "BtnRevisar"
        Me.BtnRevisar.Size = New System.Drawing.Size(53, 40)
        Me.BtnRevisar.TabIndex = 0
        Me.BtnRevisar.Text = "Revisar Disp."
        Me.BtnRevisar.UseVisualStyleBackColor = True
        Me.BtnRevisar.Visible = False
        '
        'Frm_Agregar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(490, 388)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.EnrollmentControl)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Agregar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold, Agregar Huella"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EnrollmentControl As DPFP.Gui.Enrollment.EnrollmentControl
    Friend WithEvents BtnSalir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnRevisar As Button
End Class
