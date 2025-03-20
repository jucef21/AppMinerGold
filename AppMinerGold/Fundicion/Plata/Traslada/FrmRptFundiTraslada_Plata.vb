Public Class FrmRptFundiTraslada_Plata

    Private Sub FrmRptFundiTraslada_Plata_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet23.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet23.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet23.Fundicion' Puede moverla o quitarla según sea necesario.
        Me.FundicionTableAdapter.FillByNumConseMetalPlata(Me.DbmineroDataSet23.Fundicion, TxtDocFundiPlata.Text, TxtMetales.Text)

        Me.ReportViewer1.RefreshReport
    End Sub

End Class