<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmZonasAuto
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmZonasAuto))
        Me.DeclaraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbmineroDataSet35 = New AppMinerGold.DbmineroDataSet35()
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Empresa1ClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtFechaFin = New System.Windows.Forms.TextBox()
        Me.TxtFechaIni = New System.Windows.Forms.TextBox()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.TxtZonas = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DeclaraTableAdapter = New AppMinerGold.DbmineroDataSet35TableAdapters.DeclaraTableAdapter()
        Me.EmpresaTableAdapter = New AppMinerGold.DbmineroDataSet35TableAdapters.EmpresaTableAdapter()
        Me.Empresa1ClienteTableAdapter = New AppMinerGold.DbmineroDataSet35TableAdapters.Empresa1ClienteTableAdapter()
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbmineroDataSet35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Empresa1ClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DeclaraBindingSource
        '
        Me.DeclaraBindingSource.DataMember = "Declara"
        Me.DeclaraBindingSource.DataSource = Me.DbmineroDataSet35
        '
        'DbmineroDataSet35
        '
        Me.DbmineroDataSet35.DataSetName = "DbmineroDataSet35"
        Me.DbmineroDataSet35.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DbmineroDataSet35
        '
        'Empresa1ClienteBindingSource
        '
        Me.Empresa1ClienteBindingSource.DataMember = "Empresa1Cliente"
        Me.Empresa1ClienteBindingSource.DataSource = Me.DbmineroDataSet35
        '
        'TxtFechaFin
        '
        Me.TxtFechaFin.Enabled = False
        Me.TxtFechaFin.Location = New System.Drawing.Point(332, 398)
        Me.TxtFechaFin.Name = "TxtFechaFin"
        Me.TxtFechaFin.Size = New System.Drawing.Size(100, 20)
        Me.TxtFechaFin.TabIndex = 6
        '
        'TxtFechaIni
        '
        Me.TxtFechaIni.Enabled = False
        Me.TxtFechaIni.Location = New System.Drawing.Point(212, 398)
        Me.TxtFechaIni.Name = "TxtFechaIni"
        Me.TxtFechaIni.Size = New System.Drawing.Size(100, 20)
        Me.TxtFechaIni.TabIndex = 5
        '
        'TxtCedula
        '
        Me.TxtCedula.Enabled = False
        Me.TxtCedula.Location = New System.Drawing.Point(449, 398)
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(100, 20)
        Me.TxtCedula.TabIndex = 7
        '
        'TxtZonas
        '
        Me.TxtZonas.Enabled = False
        Me.TxtZonas.Location = New System.Drawing.Point(332, 357)
        Me.TxtZonas.Name = "TxtZonas"
        Me.TxtZonas.Size = New System.Drawing.Size(100, 20)
        Me.TxtZonas.TabIndex = 8
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DSdeclara"
        ReportDataSource1.Value = Me.DeclaraBindingSource
        ReportDataSource2.Name = "DSempresa"
        ReportDataSource2.Value = Me.EmpresaBindingSource
        ReportDataSource3.Name = "DSEmpresa1Cliente"
        ReportDataSource3.Value = Me.Empresa1ClienteBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.ReportZonas.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 9
        '
        'DeclaraTableAdapter
        '
        Me.DeclaraTableAdapter.ClearBeforeFill = True
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'Empresa1ClienteTableAdapter
        '
        Me.Empresa1ClienteTableAdapter.ClearBeforeFill = True
        '
        'FrmZonasAuto
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
        Me.Name = "FrmZonasAuto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold, Zonas Autorizadas"
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbmineroDataSet35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Empresa1ClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtFechaFin As TextBox
    Friend WithEvents TxtFechaIni As TextBox
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents TxtZonas As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DeclaraBindingSource As BindingSource
    Friend WithEvents DbmineroDataSet35 As DbmineroDataSet35
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents Empresa1ClienteBindingSource As BindingSource
    Friend WithEvents DeclaraTableAdapter As DbmineroDataSet35TableAdapters.DeclaraTableAdapter
    Friend WithEvents EmpresaTableAdapter As DbmineroDataSet35TableAdapters.EmpresaTableAdapter
    Friend WithEvents Empresa1ClienteTableAdapter As DbmineroDataSet35TableAdapters.Empresa1ClienteTableAdapter
End Class
