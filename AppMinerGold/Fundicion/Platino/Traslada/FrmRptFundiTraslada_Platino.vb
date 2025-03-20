Public Class FrmRptFundiTraslada_Platino
    Private Sub FrmRptFundiTraslada_Platino_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet23.Fundicion' Puede moverla o quitarla según sea necesario.
        Me.FundicionTableAdapter.FillByNumConseMetalPlatino(Me.DbmineroDataSet23.Fundicion, TxtDocFundiPlatino.Text, TxtMetales.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet23.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet23.Empresa)


        Me.ReportViewer1.RefreshReport
    End Sub
End Class