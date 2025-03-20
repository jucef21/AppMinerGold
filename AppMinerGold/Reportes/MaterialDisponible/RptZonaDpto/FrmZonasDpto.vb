Public Class FrmZonasDpto
    Private Sub FrmZonasDpto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet39.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet39.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet39.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByZonaDpto(Me.DbmineroDataSet39.Declara, TxtFechaIni.Text, TxtFechaFin.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet39.Clientes' Puede moverla o quitarla según sea necesario.
        'Me.ClientesTableAdapter.Fill(Me.DbmineroDataSet39.Clientes)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class