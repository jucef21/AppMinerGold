<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDisponible
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDisponible))
        Me.DeclaraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbmineroDataSet34 = New AppMinerGold.DbmineroDataSet34()
        Me.Empresa1ClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtFechaIni = New System.Windows.Forms.TextBox()
        Me.TxtFechaFin = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.DeclaraTableAdapter = New AppMinerGold.DbmineroDataSet34TableAdapters.DeclaraTableAdapter()
        Me.Empresa1ClienteTableAdapter = New AppMinerGold.DbmineroDataSet34TableAdapters.Empresa1ClienteTableAdapter()
        Me.EmpresaTableAdapter = New AppMinerGold.DbmineroDataSet34TableAdapters.EmpresaTableAdapter()
        Me.TxtZonas = New System.Windows.Forms.TextBox()
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbmineroDataSet34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Empresa1ClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DeclaraBindingSource
        '
        Me.DeclaraBindingSource.DataMember = "Declara"
        Me.DeclaraBindingSource.DataSource = Me.DbmineroDataSet34
        '
        'DbmineroDataSet34
        '
        Me.DbmineroDataSet34.DataSetName = "DbmineroDataSet34"
        Me.DbmineroDataSet34.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Empresa1ClienteBindingSource
        '
        Me.Empresa1ClienteBindingSource.DataMember = "Empresa1Cliente"
        Me.Empresa1ClienteBindingSource.DataSource = Me.DbmineroDataSet34
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DbmineroDataSet34
        '
        'TxtFechaIni
        '
        Me.TxtFechaIni.Enabled = False
        Me.TxtFechaIni.Location = New System.Drawing.Point(240, 418)
        Me.TxtFechaIni.Name = "TxtFechaIni"
        Me.TxtFechaIni.Size = New System.Drawing.Size(100, 20)
        Me.TxtFechaIni.TabIndex = 0
        Me.TxtFechaIni.Visible = False
        '
        'TxtFechaFin
        '
        Me.TxtFechaFin.Enabled = False
        Me.TxtFechaFin.Location = New System.Drawing.Point(360, 418)
        Me.TxtFechaFin.Name = "TxtFechaFin"
        Me.TxtFechaFin.Size = New System.Drawing.Size(100, 20)
        Me.TxtFechaFin.TabIndex = 1
        Me.TxtFechaFin.Visible = False
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.RptDisponible.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 2
        '
        'TxtCedula
        '
        Me.TxtCedula.Enabled = False
        Me.TxtCedula.Location = New System.Drawing.Point(477, 418)
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(100, 20)
        Me.TxtCedula.TabIndex = 3
        Me.TxtCedula.Visible = False
        '
        'DeclaraTableAdapter
        '
        Me.DeclaraTableAdapter.ClearBeforeFill = True
        '
        'Empresa1ClienteTableAdapter
        '
        Me.Empresa1ClienteTableAdapter.ClearBeforeFill = True
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'TxtZonas
        '
        Me.TxtZonas.Enabled = False
        Me.TxtZonas.Location = New System.Drawing.Point(360, 377)
        Me.TxtZonas.Name = "TxtZonas"
        Me.TxtZonas.Size = New System.Drawing.Size(100, 20)
        Me.TxtZonas.TabIndex = 4
        Me.TxtZonas.Visible = False
        '
        'FrmDisponible
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.TxtFechaFin)
        Me.Controls.Add(Me.TxtFechaIni)
        Me.Controls.Add(Me.TxtCedula)
        Me.Controls.Add(Me.TxtZonas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDisponible"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Reporte Material Disponible"
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbmineroDataSet34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Empresa1ClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtFechaIni As TextBox
    Friend WithEvents TxtFechaFin As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents DeclaraBindingSource As BindingSource
    Friend WithEvents DbmineroDataSet34 As DbmineroDataSet34
    Friend WithEvents Empresa1ClienteBindingSource As BindingSource
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents DeclaraTableAdapter As DbmineroDataSet34TableAdapters.DeclaraTableAdapter
    Friend WithEvents Empresa1ClienteTableAdapter As DbmineroDataSet34TableAdapters.Empresa1ClienteTableAdapter
    Friend WithEvents EmpresaTableAdapter As DbmineroDataSet34TableAdapters.EmpresaTableAdapter
    Friend WithEvents TxtZonas As TextBox
End Class
