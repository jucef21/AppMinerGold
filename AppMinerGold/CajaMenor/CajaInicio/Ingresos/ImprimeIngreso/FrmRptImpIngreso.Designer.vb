<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptImpIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptImpIngreso))
        Me.DbmineroDataSet8 = New AppMinerGold.DbmineroDataSet8()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.CajamenorAse1TableAdapter = New AppMinerGold.DbmineroDataSet8TableAdapters.CajamenorAse1TableAdapter()
        Me.TxtNumIngreso = New System.Windows.Forms.TextBox()
        Me.CajamenorAse1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmpresaTableAdapter = New AppMinerGold.DbmineroDataSet8TableAdapters.EmpresaTableAdapter()
        CType(Me.DbmineroDataSet8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CajamenorAse1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DbmineroDataSet8
        '
        Me.DbmineroDataSet8.DataSetName = "DbmineroDataSet8"
        Me.DbmineroDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSetCMing"
        ReportDataSource1.Value = Me.CajamenorAse1BindingSource
        ReportDataSource2.Name = "DataSetEmpresa"
        ReportDataSource2.Value = Me.EmpresaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.RptIngresoCM.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(1, -1)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(794, 451)
        Me.ReportViewer1.TabIndex = 0
        '
        'CajamenorAse1TableAdapter
        '
        Me.CajamenorAse1TableAdapter.ClearBeforeFill = True
        '
        'TxtNumIngreso
        '
        Me.TxtNumIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumIngreso.Location = New System.Drawing.Point(317, 412)
        Me.TxtNumIngreso.Name = "TxtNumIngreso"
        Me.TxtNumIngreso.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumIngreso.TabIndex = 1
        '
        'CajamenorAse1BindingSource
        '
        Me.CajamenorAse1BindingSource.DataMember = "CajamenorAse1"
        Me.CajamenorAse1BindingSource.DataSource = Me.DbmineroDataSet8
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DbmineroDataSet8
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'FrmRptImpIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(778, 412)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.TxtNumIngreso)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptImpIngreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Reporte Ingreso"
        CType(Me.DbmineroDataSet8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CajamenorAse1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CajamenorAse1BindingSource As BindingSource
    Friend WithEvents DbmineroDataSet8 As DbmineroDataSet8
    Friend WithEvents CajamenorAse1TableAdapter As DbmineroDataSet8TableAdapters.CajamenorAse1TableAdapter
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents EmpresaTableAdapter As DbmineroDataSet8TableAdapters.EmpresaTableAdapter
    Friend WithEvents TxtNumIngreso As TextBox
End Class
