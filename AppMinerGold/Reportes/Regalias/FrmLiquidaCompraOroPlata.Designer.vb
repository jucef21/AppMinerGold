<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLiquidaCompraOroPlata
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLiquidaCompraOroPlata))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.TxtMetales = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbmineroDataSet10 = New AppMinerGold.DbmineroDataSet10()
        Me.DeclaraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmpresaTableAdapter = New AppMinerGold.DbmineroDataSet10TableAdapters.EmpresaTableAdapter()
        Me.DeclaraTableAdapter = New AppMinerGold.DbmineroDataSet10TableAdapters.DeclaraTableAdapter()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbmineroDataSet10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(184, 339)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(305, 339)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Visible = False
        '
        'TxtCedula
        '
        Me.TxtCedula.Location = New System.Drawing.Point(425, 339)
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(112, 20)
        Me.TxtCedula.TabIndex = 2
        Me.TxtCedula.Visible = False
        '
        'TxtMetales
        '
        Me.TxtMetales.Location = New System.Drawing.Point(546, 339)
        Me.TxtMetales.Name = "TxtMetales"
        Me.TxtMetales.Size = New System.Drawing.Size(102, 20)
        Me.TxtMetales.TabIndex = 3
        Me.TxtMetales.Visible = False
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsEmpresa"
        ReportDataSource1.Value = Me.EmpresaBindingSource
        ReportDataSource2.Name = "DsDeclara"
        ReportDataSource2.Value = Me.DeclaraBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.RptLiquidaOroPlata.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 4
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DbmineroDataSet10
        '
        'DbmineroDataSet10
        '
        Me.DbmineroDataSet10.DataSetName = "DbmineroDataSet10"
        Me.DbmineroDataSet10.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DeclaraBindingSource
        '
        Me.DeclaraBindingSource.DataMember = "Declara"
        Me.DeclaraBindingSource.DataSource = Me.DbmineroDataSet10
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'DeclaraTableAdapter
        '
        Me.DeclaraTableAdapter.ClearBeforeFill = True
        '
        'FrmLiquidaCompraOroPlata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.TxtMetales)
        Me.Controls.Add(Me.TxtCedula)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLiquidaCompraOroPlata"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMinerGold - Liquida Compra Oro y Plata"
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbmineroDataSet10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents TxtMetales As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DbmineroDataSet10 As DbmineroDataSet10
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents EmpresaTableAdapter As DbmineroDataSet10TableAdapters.EmpresaTableAdapter
    Friend WithEvents DeclaraBindingSource As BindingSource
    Friend WithEvents DeclaraTableAdapter As DbmineroDataSet10TableAdapters.DeclaraTableAdapter
End Class
