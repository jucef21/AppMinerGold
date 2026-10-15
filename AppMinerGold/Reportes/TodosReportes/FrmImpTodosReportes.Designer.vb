<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpTodosReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImpTodosReportes))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TxtConsecutivo = New System.Windows.Forms.TextBox()
        Me.TxtFechaIni = New System.Windows.Forms.TextBox()
        Me.TxtFechaFin = New System.Windows.Forms.TextBox()
        Me.BtnPruebaPDF = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.DocumentMapWidth = 96
        Me.ReportViewer1.Enabled = False
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 69)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(98, 129)
        Me.ReportViewer1.TabIndex = 0
        Me.ReportViewer1.Visible = False
        '
        'TxtConsecutivo
        '
        Me.TxtConsecutivo.Enabled = False
        Me.TxtConsecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConsecutivo.Location = New System.Drawing.Point(231, 52)
        Me.TxtConsecutivo.Name = "TxtConsecutivo"
        Me.TxtConsecutivo.Size = New System.Drawing.Size(100, 22)
        Me.TxtConsecutivo.TabIndex = 1
        '
        'TxtFechaIni
        '
        Me.TxtFechaIni.Enabled = False
        Me.TxtFechaIni.Location = New System.Drawing.Point(353, 80)
        Me.TxtFechaIni.Name = "TxtFechaIni"
        Me.TxtFechaIni.Size = New System.Drawing.Size(100, 20)
        Me.TxtFechaIni.TabIndex = 2
        Me.TxtFechaIni.Visible = False
        '
        'TxtFechaFin
        '
        Me.TxtFechaFin.Enabled = False
        Me.TxtFechaFin.Location = New System.Drawing.Point(353, 107)
        Me.TxtFechaFin.Name = "TxtFechaFin"
        Me.TxtFechaFin.Size = New System.Drawing.Size(100, 20)
        Me.TxtFechaFin.TabIndex = 3
        Me.TxtFechaFin.Visible = False
        '
        'BtnPruebaPDF
        '
        Me.BtnPruebaPDF.Image = CType(resources.GetObject("BtnPruebaPDF.Image"), System.Drawing.Image)
        Me.BtnPruebaPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPruebaPDF.Location = New System.Drawing.Point(133, 214)
        Me.BtnPruebaPDF.Name = "BtnPruebaPDF"
        Me.BtnPruebaPDF.Size = New System.Drawing.Size(198, 40)
        Me.BtnPruebaPDF.TabIndex = 4
        Me.BtnPruebaPDF.Text = "GENERAR REPORTES"
        Me.BtnPruebaPDF.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(133, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(198, 118)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reportes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 75)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "01 - Acta de Entrega" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "02 - Certificación Tributario" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "03 - Contrato" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "04 - Liquidac" &
    "ión" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "04 - Pagaré"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(475, 40)
        Me.Panel3.TabIndex = 66
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(69, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(347, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "IMPRESIÓN COMPLETA DE REPORTES DE COMPRA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 16)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Consecutivo: "
        '
        'FrmImpTodosReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(475, 275)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnPruebaPDF)
        Me.Controls.Add(Me.TxtFechaFin)
        Me.Controls.Add(Me.TxtFechaIni)
        Me.Controls.Add(Me.TxtConsecutivo)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImpTodosReportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de Todos losReportes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TxtConsecutivo As TextBox
    Friend WithEvents TxtFechaIni As TextBox
    Friend WithEvents TxtFechaFin As TextBox
    Friend WithEvents BtnPruebaPDF As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
End Class
