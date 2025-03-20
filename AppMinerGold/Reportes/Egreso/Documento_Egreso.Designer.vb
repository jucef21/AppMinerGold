<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Documento_Egreso
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
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Documento_Egreso))
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbmineroDataSet20 = New AppMinerGold.DbmineroDataSet20()
        Me.ClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DeclaraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FormaPagoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtClientes = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DeclaraTableAdapter = New AppMinerGold.DbmineroDataSet20TableAdapters.DeclaraTableAdapter()
        Me.EmpresaTableAdapter = New AppMinerGold.DbmineroDataSet20TableAdapters.EmpresaTableAdapter()
        Me.ClientesTableAdapter = New AppMinerGold.DbmineroDataSet20TableAdapters.ClientesTableAdapter()
        Me.FormaPagoTableAdapter = New AppMinerGold.DbmineroDataSet20TableAdapters.FormaPagoTableAdapter()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbmineroDataSet20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormaPagoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DbmineroDataSet20
        '
        'DbmineroDataSet20
        '
        Me.DbmineroDataSet20.DataSetName = "DbmineroDataSet20"
        Me.DbmineroDataSet20.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ClientesBindingSource
        '
        Me.ClientesBindingSource.DataMember = "Clientes"
        Me.ClientesBindingSource.DataSource = Me.DbmineroDataSet20
        '
        'DeclaraBindingSource
        '
        Me.DeclaraBindingSource.DataMember = "Declara"
        Me.DeclaraBindingSource.DataSource = Me.DbmineroDataSet20
        '
        'FormaPagoBindingSource
        '
        Me.FormaPagoBindingSource.DataMember = "FormaPago"
        Me.FormaPagoBindingSource.DataSource = Me.DbmineroDataSet20
        '
        'TxtClientes
        '
        Me.TxtClientes.Enabled = False
        Me.TxtClientes.Location = New System.Drawing.Point(12, 418)
        Me.TxtClientes.Name = "TxtClientes"
        Me.TxtClientes.Size = New System.Drawing.Size(94, 20)
        Me.TxtClientes.TabIndex = 3
        Me.TxtClientes.Visible = False
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetEmp"
        ReportDataSource1.Value = Me.EmpresaBindingSource
        ReportDataSource2.Name = "DataSetClientes"
        ReportDataSource2.Value = Me.ClientesBindingSource
        ReportDataSource3.Name = "DataSet1"
        ReportDataSource3.Value = Me.DeclaraBindingSource
        ReportDataSource4.Name = "DataSetFormaPago"
        ReportDataSource4.Value = Me.FormaPagoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.Documento_Egreso.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 4
        '
        'DeclaraTableAdapter
        '
        Me.DeclaraTableAdapter.ClearBeforeFill = True
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'ClientesTableAdapter
        '
        Me.ClientesTableAdapter.ClearBeforeFill = True
        '
        'FormaPagoTableAdapter
        '
        Me.FormaPagoTableAdapter.ClearBeforeFill = True
        '
        'Documento_Egreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.TxtClientes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Documento_Egreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Reporte Egreso"
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbmineroDataSet20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormaPagoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtClientes As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DeclaraBindingSource As BindingSource
    Friend WithEvents DbmineroDataSet20 As DbmineroDataSet20
    Friend WithEvents DeclaraTableAdapter As DbmineroDataSet20TableAdapters.DeclaraTableAdapter
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents EmpresaTableAdapter As DbmineroDataSet20TableAdapters.EmpresaTableAdapter
    Friend WithEvents ClientesBindingSource As BindingSource
    Friend WithEvents ClientesTableAdapter As DbmineroDataSet20TableAdapters.ClientesTableAdapter
    Friend WithEvents FormaPagoBindingSource As BindingSource
    Friend WithEvents FormaPagoTableAdapter As DbmineroDataSet20TableAdapters.FormaPagoTableAdapter
End Class
