Public Class FrmRptImpIngreso

    Private Sub FrmRptImpIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet8.CajamenorAse1' Puede moverla o quitarla según sea necesario.
        Me.CajamenorAse1TableAdapter.Fill(Me.DbmineroDataSet8.CajamenorAse1)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet8.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.FillByEmpresa(Me.DbmineroDataSet8.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet8.CajamenorAse1' Puede moverla o quitarla según sea necesario.
        Me.CajamenorAse1TableAdapter.FillByIngresosCM(Me.DbmineroDataSet8.CajamenorAse1, TxtNumIngreso.Text)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class