<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptIng
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptIng))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.CajamenorAse1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbmineroDataSet8 = New AppMinerGold.DbmineroDataSet8()
        Me.CajamenorAse1TableAdapter = New AppMinerGold.DbmineroDataSet8TableAdapters.CajamenorAse1TableAdapter()
        Me.TxtNumIngreso = New System.Windows.Forms.TextBox()
        CType(Me.CajamenorAse1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbmineroDataSet8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetReimpIng"
        ReportDataSource1.Value = Me.CajamenorAse1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.RptReimpIngreso.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'CajamenorAse1BindingSource
        '
        Me.CajamenorAse1BindingSource.DataMember = "CajamenorAse1"
        Me.CajamenorAse1BindingSource.DataSource = Me.DbmineroDataSet8
        '
        'DbmineroDataSet8
        '
        Me.DbmineroDataSet8.DataSetName = "DbmineroDataSet8"
        Me.DbmineroDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CajamenorAse1TableAdapter
        '
        Me.CajamenorAse1TableAdapter.ClearBeforeFill = True
        '
        'TxtNumIngreso
        '
        Me.TxtNumIngreso.Location = New System.Drawing.Point(324, 397)
        Me.TxtNumIngreso.Name = "TxtNumIngreso"
        Me.TxtNumIngreso.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumIngreso.TabIndex = 1
        '
        'FrmRptIng
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.TxtNumIngreso)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptIng"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Reporte Ing"
        CType(Me.CajamenorAse1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbmineroDataSet8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CajamenorAse1BindingSource As BindingSource
    Friend WithEvents DbmineroDataSet8 As DbmineroDataSet8
    Friend WithEvents CajamenorAse1TableAdapter As DbmineroDataSet8TableAdapters.CajamenorAse1TableAdapter
    Friend WithEvents TxtNumIngreso As TextBox
End Class
