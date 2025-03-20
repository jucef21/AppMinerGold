<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReimprimeVincula
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReimprimeVincula))
        Me.ClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbmineroDataSet14 = New AppMinerGold.DbmineroDataSet14()
        Me.Empresa1ClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtClientes = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClientesTableAdapter = New AppMinerGold.DbmineroDataSet14TableAdapters.ClientesTableAdapter()
        Me.Empresa1ClienteTableAdapter = New AppMinerGold.DbmineroDataSet14TableAdapters.Empresa1ClienteTableAdapter()
        Me.EmpresaTableAdapter = New AppMinerGold.DbmineroDataSet14TableAdapters.EmpresaTableAdapter()
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbmineroDataSet14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Empresa1ClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ClientesBindingSource
        '
        Me.ClientesBindingSource.DataMember = "Clientes"
        Me.ClientesBindingSource.DataSource = Me.DbmineroDataSet14
        '
        'DbmineroDataSet14
        '
        Me.DbmineroDataSet14.DataSetName = "DbmineroDataSet14"
        Me.DbmineroDataSet14.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Empresa1ClienteBindingSource
        '
        Me.Empresa1ClienteBindingSource.DataMember = "Empresa1Cliente"
        Me.Empresa1ClienteBindingSource.DataSource = Me.DbmineroDataSet14
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DbmineroDataSet14
        '
        'TxtClientes
        '
        Me.TxtClientes.Location = New System.Drawing.Point(409, 416)
        Me.TxtClientes.Name = "TxtClientes"
        Me.TxtClientes.Size = New System.Drawing.Size(100, 20)
        Me.TxtClientes.TabIndex = 0
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.ClientesBindingSource
        ReportDataSource2.Name = "DataSet2"
        ReportDataSource2.Value = Me.Empresa1ClienteBindingSource
        ReportDataSource3.Name = "DSempresa"
        ReportDataSource3.Value = Me.EmpresaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.RptReimpVincula.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 1
        '
        'ClientesTableAdapter
        '
        Me.ClientesTableAdapter.ClearBeforeFill = True
        '
        'Empresa1ClienteTableAdapter
        '
        Me.Empresa1ClienteTableAdapter.ClearBeforeFill = True
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'FrmReimprimeVincula
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
        Me.Name = "FrmReimprimeVincula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reimprime Vincula"
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbmineroDataSet14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Empresa1ClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtClientes As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClientesBindingSource As BindingSource
    Friend WithEvents DbmineroDataSet14 As DbmineroDataSet14
    Friend WithEvents Empresa1ClienteBindingSource As BindingSource
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents ClientesTableAdapter As DbmineroDataSet14TableAdapters.ClientesTableAdapter
    Friend WithEvents Empresa1ClienteTableAdapter As DbmineroDataSet14TableAdapters.Empresa1ClienteTableAdapter
    Friend WithEvents EmpresaTableAdapter As DbmineroDataSet14TableAdapters.EmpresaTableAdapter
End Class
