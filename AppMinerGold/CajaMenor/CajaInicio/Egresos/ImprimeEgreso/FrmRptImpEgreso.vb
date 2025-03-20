Public Class FrmRptImpEgreso

    Private Sub FrmRptImpEgreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet9.CajamenorAse1' Puede moverla o quitarla según sea necesario.
        Me.CajamenorAse1TableAdapter.Fill(Me.DbmineroDataSet9.CajamenorAse1)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet9.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.FillByEmpresa(Me.DbmineroDataSet9.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet9.CajamenorAse1' Puede moverla o quitarla según sea necesario.

        Me.CajamenorAse1TableAdapter.FillByEgresoCM(Me.DbmineroDataSet9.CajamenorAse1)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class