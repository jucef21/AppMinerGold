Public Class FrmRpt_Regalias

    Private Sub FrmRpt_Regalias_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet10.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.FillByEmpresa(Me.DbmineroDataSet10.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet10.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByFechaCompra(Me.DbmineroDataSet10.Declara, TextBox1.Text, TextBox2.Text, TxtMetales.Text)

        Me.ReportViewer1.RefreshReport()
    End Sub

End Class