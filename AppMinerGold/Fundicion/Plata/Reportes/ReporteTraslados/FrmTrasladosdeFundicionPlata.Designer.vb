<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrasladosdeFundicionPlata
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrasladosdeFundicionPlata))
        Me.FundicionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbmineroDataSet23 = New AppMinerGold.DbmineroDataSet23()
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtFechaFin = New System.Windows.Forms.TextBox()
        Me.TxtFechaIni = New System.Windows.Forms.TextBox()
        Me.TxtNumFunfi = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
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
        'TxtFechaFin
        '
        Me.TxtFechaFin.Enabled = False
        Me.TxtFechaFin.Location = New System.Drawing.Point(347, 399)
        Me.TxtFechaFin.Name = "TxtFechaFin"
        Me.TxtFechaFin.Size = New System.Drawing.Size(100, 20)
        Me.TxtFechaFin.TabIndex = 5
        '
        'TxtFechaIni
        '
        Me.TxtFechaIni.Enabled = False
        Me.TxtFechaIni.Location = New System.Drawing.Point(232, 399)
        Me.TxtFechaIni.Name = "TxtFechaIni"
        Me.TxtFechaIni.Size = New System.Drawing.Size(100, 20)
        Me.TxtFechaIni.TabIndex = 4
        '
        'TxtNumFunfi
        '
        Me.TxtNumFunfi.Enabled = False
        Me.TxtNumFunfi.Location = New System.Drawing.Point(462, 399)
        Me.TxtNumFunfi.Name = "TxtNumFunfi"
        Me.TxtNumFunfi.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumFunfi.TabIndex = 6
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsFundicion"
        ReportDataSource1.Value = Me.FundicionBindingSource
        ReportDataSource2.Name = "DsEmpresa"
        ReportDataSource2.Value = Me.EmpresaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.Reporte_Traslados_Plata.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 7
        '
        'FundicionTableAdapter
        '
        Me.FundicionTableAdapter.ClearBeforeFill = True
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'FrmTrasladosdeFundicionPlata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.TxtFechaFin)
        Me.Controls.Add(Me.TxtFechaIni)
        Me.Controls.Add(Me.TxtNumFunfi)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTrasladosdeFundicionPlata"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold, Reporte de Traslados de Fundición de Plata"
        CType(Me.FundicionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbmineroDataSet23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtFechaFin As TextBox
    Friend WithEvents TxtFechaIni As TextBox
    Friend WithEvents TxtNumFunfi As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DbmineroDataSet23 As DbmineroDataSet23
    Friend WithEvents FundicionBindingSource As BindingSource
    Friend WithEvents FundicionTableAdapter As DbmineroDataSet23TableAdapters.FundicionTableAdapter
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents EmpresaTableAdapter As DbmineroDataSet23TableAdapters.EmpresaTableAdapter
End Class
