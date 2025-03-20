Public Class FrmRptSaldosFundi
    Private Sub FrmRptSaldosFundi_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet21.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet21.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet21.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillBySaldosFundi(Me.DbmineroDataSet21.Declara)

        Me.ReportViewer1.RefreshReport()
    End Sub

End Class