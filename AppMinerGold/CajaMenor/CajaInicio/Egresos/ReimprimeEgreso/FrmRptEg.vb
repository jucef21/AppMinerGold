Public Class FrmRptEg
    Private Sub FrmRptEg_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet9.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.FillByEmpresa(Me.DbmineroDataSet9.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet9.CajamenorAse1' Puede moverla o quitarla según sea necesario.
        Me.CajamenorAse1TableAdapter.FillByReimpEgresoCM(Me.DbmineroDataSet9.CajamenorAse1, TxtNumEgreso.Text)
        Me.ReportViewer1.RefreshReport()

    End Sub
End Class