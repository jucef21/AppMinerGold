<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReimpEgrEliminado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReimpEgrEliminado))
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbmineroDataSet9 = New AppMinerGold.DbmineroDataSet9()
        Me.CajamenorAse1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtNumEiminado = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.EmpresaTableAdapter = New AppMinerGold.DbmineroDataSet9TableAdapters.EmpresaTableAdapter()
        Me.CajamenorAse1TableAdapter = New AppMinerGold.DbmineroDataSet9TableAdapters.CajamenorAse1TableAdapter()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbmineroDataSet9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CajamenorAse1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DbmineroDataSet9
        '
        'DbmineroDataSet9
        '
        Me.DbmineroDataSet9.DataSetName = "DbmineroDataSet9"
        Me.DbmineroDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CajamenorAse1BindingSource
        '
        Me.CajamenorAse1BindingSource.DataMember = "CajamenorAse1"
        Me.CajamenorAse1BindingSource.DataSource = Me.DbmineroDataSet9
        '
        'TxtNumEiminado
        '
        Me.TxtNumEiminado.Location = New System.Drawing.Point(12, 418)
        Me.TxtNumEiminado.Name = "TxtNumEiminado"
        Me.TxtNumEiminado.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumEiminado.TabIndex = 0
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DSempresa"
        ReportDataSource1.Value = Me.EmpresaBindingSource
        ReportDataSource2.Name = "DScajamenorAse1Eli"
        ReportDataSource2.Value = Me.CajamenorAse1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.RptReimpEgreEliminado.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 1
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'CajamenorAse1TableAdapter
        '
        Me.CajamenorAse1TableAdapter.ClearBeforeFill = True
        '
        'FrmReimpEgrEliminado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.TxtNumEiminado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReimpEgrEliminado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reimprime Egreso Eliminado"
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbmineroDataSet9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CajamenorAse1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtNumEiminado As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents DbmineroDataSet9 As DbmineroDataSet9
    Friend WithEvents CajamenorAse1BindingSource As BindingSource
    Friend WithEvents EmpresaTableAdapter As DbmineroDataSet9TableAdapters.EmpresaTableAdapter
    Friend WithEvents CajamenorAse1TableAdapter As DbmineroDataSet9TableAdapters.CajamenorAse1TableAdapter
End Class
