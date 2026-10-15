<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSoporte
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSoporte))
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsImagenEmpresa = New AppMinerGold.DsImagenEmpresa()
        Me.DeclaraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FacturacionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TxtClientes = New System.Windows.Forms.TextBox()
        Me.TxtConsecutivo = New System.Windows.Forms.TextBox()
        Me.TxtVerCiudImp = New System.Windows.Forms.TextBox()
        Me.EmpresaTableAdapter = New AppMinerGold.DsImagenEmpresaTableAdapters.EmpresaTableAdapter()
        Me.DeclaraTableAdapter = New AppMinerGold.DsImagenEmpresaTableAdapters.DeclaraTableAdapter()
        Me.FacturacionTableAdapter = New AppMinerGold.DsImagenEmpresaTableAdapters.FacturacionTableAdapter()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsImagenEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FacturacionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DsImagenEmpresa
        '
        'DsImagenEmpresa
        '
        Me.DsImagenEmpresa.DataSetName = "DsImagenEmpresa"
        Me.DsImagenEmpresa.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DeclaraBindingSource
        '
        Me.DeclaraBindingSource.DataMember = "Declara"
        Me.DeclaraBindingSource.DataSource = Me.DsImagenEmpresa
        '
        'FacturacionBindingSource
        '
        Me.FacturacionBindingSource.DataMember = "Facturacion"
        Me.FacturacionBindingSource.DataSource = Me.DsImagenEmpresa
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsEmpresa"
        ReportDataSource1.Value = Me.EmpresaBindingSource
        ReportDataSource2.Name = "DsDeclara"
        ReportDataSource2.Value = Me.DeclaraBindingSource
        ReportDataSource3.Name = "DsFacturacion"
        ReportDataSource3.Value = Me.FacturacionBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.RptSoporte.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'TxtClientes
        '
        Me.TxtClientes.Enabled = False
        Me.TxtClientes.Location = New System.Drawing.Point(200, 418)
        Me.TxtClientes.Name = "TxtClientes"
        Me.TxtClientes.Size = New System.Drawing.Size(126, 20)
        Me.TxtClientes.TabIndex = 3
        Me.TxtClientes.Visible = False
        '
        'TxtConsecutivo
        '
        Me.TxtConsecutivo.Location = New System.Drawing.Point(358, 419)
        Me.TxtConsecutivo.Name = "TxtConsecutivo"
        Me.TxtConsecutivo.Size = New System.Drawing.Size(100, 20)
        Me.TxtConsecutivo.TabIndex = 4
        '
        'TxtVerCiudImp
        '
        Me.TxtVerCiudImp.Location = New System.Drawing.Point(464, 418)
        Me.TxtVerCiudImp.Name = "TxtVerCiudImp"
        Me.TxtVerCiudImp.Size = New System.Drawing.Size(100, 20)
        Me.TxtVerCiudImp.TabIndex = 5
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'DeclaraTableAdapter
        '
        Me.DeclaraTableAdapter.ClearBeforeFill = True
        '
        'FacturacionTableAdapter
        '
        Me.FacturacionTableAdapter.ClearBeforeFill = True
        '
        'FrmSoporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.TxtConsecutivo)
        Me.Controls.Add(Me.TxtVerCiudImp)
        Me.Controls.Add(Me.TxtClientes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSoporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documento Soporte"
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsImagenEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FacturacionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TxtClientes As TextBox
    Friend WithEvents TxtConsecutivo As TextBox
    Friend WithEvents TxtVerCiudImp As TextBox
    Friend WithEvents DsImagenEmpresa As DsImagenEmpresa
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents EmpresaTableAdapter As DsImagenEmpresaTableAdapters.EmpresaTableAdapter
    Friend WithEvents DeclaraBindingSource As BindingSource
    Friend WithEvents DeclaraTableAdapter As DsImagenEmpresaTableAdapters.DeclaraTableAdapter
    Friend WithEvents FacturacionBindingSource As BindingSource
    Friend WithEvents FacturacionTableAdapter As DsImagenEmpresaTableAdapters.FacturacionTableAdapter
End Class
