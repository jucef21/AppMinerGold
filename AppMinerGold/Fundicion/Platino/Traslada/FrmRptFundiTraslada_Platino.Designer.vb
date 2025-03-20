<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRptFundiTraslada_Platino
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptFundiTraslada_Platino))
        Me.FundicionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbmineroDataSet23 = New AppMinerGold.DbmineroDataSet23()
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtDocFundiPlatino = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TxtMetales = New System.Windows.Forms.TextBox()
        Me.FundicionTableAdapter = New AppMinerGold.DbmineroDataSet23TableAdapters.FundicionTableAdapter()
        Me.EmpresaTableAdapter = New AppMinerGold.DbmineroDataSet23TableAdapters.EmpresaTableAdapter()
        CType(Me.FundicionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbmineroDataSet23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FundicionBindingSource
        '
        Me.FundicionBindingSource.DataMember = "Fundicion"
        Me.FundicionBindingSource.DataSource = Me.DbmineroDataSet23
        '
        'DbmineroDataSet23
        '
        Me.DbmineroDataSet23.DataSetName = "DbmineroDataSet23"
        Me.DbmineroDataSet23.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DbmineroDataSet23
        '
        'TxtDocFundiPlatino
        '
        Me.TxtDocFundiPlatino.Location = New System.Drawing.Point(340, 393)
        Me.TxtDocFundiPlatino.Name = "TxtDocFundiPlatino"
        Me.TxtDocFundiPlatino.Size = New System.Drawing.Size(100, 20)
        Me.TxtDocFundiPlatino.TabIndex = 0
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetFundi"
        ReportDataSource1.Value = Me.FundicionBindingSource
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.EmpresaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.Reporte_Fundicion_Platino.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 1
        '
        'TxtMetales
        '
        Me.TxtMetales.Location = New System.Drawing.Point(472, 392)
        Me.TxtMetales.Name = "TxtMetales"
        Me.TxtMetales.Size = New System.Drawing.Size(100, 20)
        Me.TxtMetales.TabIndex = 2
        '
        'FundicionTableAdapter
        '
        Me.FundicionTableAdapter.ClearBeforeFill = True
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'FrmRptFundiTraslada_Platino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.TxtDocFundiPlatino)
        Me.Controls.Add(Me.TxtMetales)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptFundiTraslada_Platino"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Reporte  Fundición Platino"
        CType(Me.FundicionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbmineroDataSet23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtDocFundiPlatino As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TxtMetales As TextBox
    Friend WithEvents DbmineroDataSet23 As DbmineroDataSet23
    Friend WithEvents FundicionBindingSource As BindingSource
    Friend WithEvents FundicionTableAdapter As DbmineroDataSet23TableAdapters.FundicionTableAdapter
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents EmpresaTableAdapter As DbmineroDataSet23TableAdapters.EmpresaTableAdapter
End Class
