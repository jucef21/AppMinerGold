Public Class FrmRptIng
    Private Sub FrmRptIng_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet8.CajamenorAse1' Puede moverla o quitarla según sea necesario.
        'Me.CajamenorAse1TableAdapter.Fill(Me.DbmineroDataSet8.CajamenorAse1)
        Me.CajamenorAse1TableAdapter.FillByReimpIngresoCM(Me.DbmineroDataSet8.CajamenorAse1, TxtNumIngreso.Text)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class