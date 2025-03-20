Public Class FrmFundiRptxProvPlata
    Private Sub FrmFundiRptxProvPlata_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet30.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet30.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet30.Fundicion' Puede moverla o quitarla según sea necesario.
        Me.FundicionTableAdapter.FillByFundi(Me.DbmineroDataSet30.Fundicion, TxtNumero.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet30.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByNumFunfi(Me.DbmineroDataSet30.Declara, TxtNumero.Text)

        Me.ReportViewer1.RefreshReport

    End Sub
End Class