Public Class FrmReimpEgrEliminado

    Private Sub FrmReimpEgrEliminado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet9.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.FillByEmpresa(Me.DbmineroDataSet9.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet9.CajamenorAse1' Puede moverla o quitarla según sea necesario.
        Me.CajamenorAse1TableAdapter.FillByImpEgreEliminado(Me.DbmineroDataSet9.CajamenorAse1, TxtNumEiminado.Text)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class