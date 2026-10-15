<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmActaEntrega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmActaEntrega))
        Me.TxtConsecutivo = New System.Windows.Forms.TextBox()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DsContrato = New AppMinerGold.DsContrato()
        Me.DeclaraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DeclaraTableAdapter = New AppMinerGold.DsContratoTableAdapters.DeclaraTableAdapter()
        Me.EmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmpresaTableAdapter = New AppMinerGold.DsContratoTableAdapters.EmpresaTableAdapter()
        CType(Me.DsContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtConsecutivo
        '
        Me.TxtConsecutivo.Location = New System.Drawing.Point(299, 422)
        Me.TxtConsecutivo.Name = "TxtConsecutivo"
        Me.TxtConsecutivo.Size = New System.Drawing.Size(100, 20)
        Me.TxtConsecutivo.TabIndex = 0
        '
        'TxtCedula
        '
        Me.TxtCedula.Location = New System.Drawing.Point(419, 422)
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(100, 20)
        Me.TxtCedula.TabIndex = 1
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsDeclara"
        ReportDataSource1.Value = Me.DeclaraBindingSource
        ReportDataSource2.Name = "DsEmpresa"
        ReportDataSource2.Value = Me.EmpresaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppMinerGold.ActaEntrega.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 2
        '
        'DsContrato
        '
        Me.DsContrato.DataSetName = "DsContrato"
        Me.DsContrato.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DeclaraBindingSource
        '
        Me.DeclaraBindingSource.DataMember = "Declara"
        Me.DeclaraBindingSource.DataSource = Me.DsContrato
        '
        'DeclaraTableAdapter
        '
        Me.DeclaraTableAdapter.ClearBeforeFill = True
        '
        'EmpresaBindingSource
        '
        Me.EmpresaBindingSource.DataMember = "Empresa"
        Me.EmpresaBindingSource.DataSource = Me.DsContrato
        '
        'EmpresaTableAdapter
        '
        Me.EmpresaTableAdapter.ClearBeforeFill = True
        '
        'FrmActaEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.TxtCedula)
        Me.Controls.Add(Me.TxtConsecutivo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmActaEntrega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formulario de Acta de Entrega"
        CType(Me.DsContrato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeclaraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtConsecutivo As TextBox
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DsContrato As DsContrato
    Friend WithEvents DeclaraBindingSource As BindingSource
    Friend WithEvents DeclaraTableAdapter As DsContratoTableAdapters.DeclaraTableAdapter
    Friend WithEvents EmpresaBindingSource As BindingSource
    Friend WithEvents EmpresaTableAdapter As DsContratoTableAdapters.EmpresaTableAdapter
End Class
