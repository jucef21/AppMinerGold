<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReimpDeclara
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
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReimpDeclara))
        Me.DeclaraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbmineroDataSet11 = New AppMinerGold.DbmineroDataSet11()
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Empresa1ClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtConsecutivo = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.DeclaraTableAdapter = New AppMinerGold.DbmineroDataSet11TableAdapters.DeclaraTableAdapter()
        Me.EmpresaTableAdapter = New AppMinerGold.DbmineroDataSet11TableAdapters.EmpresaTableAdapter()
        Me.Empresa1ClienteTableAdapter = New AppMinerGold.DbmineroDataSet11TableAdapters.Empresa1ClienteTableAdapter()
        Me.DeclaraClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClientesTableAdapter = New AppMinerGold.DbmineroDataSet11TableAdapters.ClientesTableAdapter()
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbmineroDataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Empresa1ClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeclaraClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DeclaraBindingSource
        '
        Me.DeclaraBindingSource.DataMember = "Declara"
        Me.DeclaraBindingSource.DataSource = Me.DbmineroDataSet11
        '
        'DbmineroDataSet11
        '
        Me.DbmineroDataSet11.DataSetName = "DbmineroDataSet11"
        Me.DbmineroDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DbmineroDataSet11
        '
        'Empresa1ClienteBindingSource
        '
        Me.Empresa1ClienteBindingSource.DataMember = "Empresa1Cliente"
        Me.Empresa1ClienteBindingSource.DataSource = Me.DbmineroDataSet11
        '
        'ClientesBindingSource
        '
        Me.ClientesBindingSource.DataMember = "Clientes"
        Me.ClientesBindingSource.DataSource = Me.DbmineroDataSet11
        '
        'TxtConsecutivo
        '
        Me.TxtConsecutivo.Enabled = False
        Me.TxtConsecutivo.Location = New System.Drawing.Point(252, 418)
        Me.TxtConsecutivo.Name = "TxtConsecutivo"
        Me.TxtConsecutivo.Size = New System.Drawing.Size(100, 20)
        Me.TxtConsecutivo.TabIndex = 0
        Me.TxtConsecutivo.Visible = False
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetReimpDeclara"
        ReportDataSource1.Value = Me.DeclaraBindingSource
        ReportDataSource2.Name = "DataSetEmp"
        ReportDataSource2.Value = Me.EmpresaBindingSource
        ReportDataSource3.Name = "DataSetZonas"
        ReportDataSource3.Value = Me.Empresa1ClienteBindingSource
        ReportDataSource4.Name = "DsClientes"
        ReportDataSource4.Value = Me.ClientesBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.RptDeclaraReimprime.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 1
        '
        'TxtCedula
        '
        Me.TxtCedula.Location = New System.Drawing.Point(385, 418)
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(100, 20)
        Me.TxtCedula.TabIndex = 2
        Me.TxtCedula.Visible = False
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
        'DeclaraClientesBindingSource
        '
        Me.DeclaraClientesBindingSource.DataMember = "Declara_Clientes"
        Me.DeclaraClientesBindingSource.DataSource = Me.DeclaraBindingSource
        '
        'ClientesTableAdapter
        '
        Me.ClientesTableAdapter.ClearBeforeFill = True
        '
        'FrmReimpDeclara
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.TxtConsecutivo)
        Me.Controls.Add(Me.TxtCedula)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReimpDeclara"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Reporte Reimp Declara"
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbmineroDataSet11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Empresa1ClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeclaraClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtConsecutivo As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DeclaraBindingSource As BindingSource
    Friend WithEvents DbmineroDataSet11 As DbmineroDataSet11
    Friend WithEvents DeclaraTableAdapter As DbmineroDataSet11TableAdapters.DeclaraTableAdapter
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents EmpresaTableAdapter As DbmineroDataSet11TableAdapters.EmpresaTableAdapter
    Friend WithEvents Empresa1ClienteBindingSource As BindingSource
    Friend WithEvents Empresa1ClienteTableAdapter As DbmineroDataSet11TableAdapters.Empresa1ClienteTableAdapter
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents DeclaraClientesBindingSource As BindingSource
    Friend WithEvents ClientesTableAdapter As DbmineroDataSet11TableAdapters.ClientesTableAdapter
    Friend WithEvents ClientesBindingSource As BindingSource
End Class
