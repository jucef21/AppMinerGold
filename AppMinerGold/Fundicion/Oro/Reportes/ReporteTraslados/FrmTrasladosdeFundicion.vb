Public Class FrmTrasladosdeFundicion

    Private Sub FrmTrasladosdeFundicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet23.Fundicion' Puede moverla o quitarla según sea necesario.
        Me.FundicionTableAdapter.FillByFechaNumFundiOro(Me.DbmineroDataSet23.Fundicion, TxtFechaIni.Text, TxtFechaFin.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet23.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet23.Empresa)

        Me.ReportViewer1.RefreshReport

    End Sub

End Class