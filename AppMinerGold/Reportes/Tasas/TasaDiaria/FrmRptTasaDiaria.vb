Public Class FrmRptTasaDiaria

    Private Sub FrmRptTasaDiaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet4.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByFechas(Me.DbmineroDataSet4.Declara, TextBox1.Text, TextBox2.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet4.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.FillByEmpresa(Me.DbmineroDataSet4.Empresa)

        Me.ReportViewer1.RefreshReport()

    End Sub
End Class