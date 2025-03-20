Public Class FrmImpEvidencia

    Private Sub FrmImpEvidencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet33.Biometrica' Puede moverla o quitarla según sea necesario.
        'Me.BiometricaTableAdapter.Fill(Me.DbmineroDataSet33.Biometrica)
        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet33.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet33.Empresa)
        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet33.Biometrica' Puede moverla o quitarla según sea necesario.
        'Me.BiometricaTableAdapter.Fill(Me.DbmineroDataSet33.Biometrica)
        Me.BiometricaTableAdapter.FillByCedulaEvidencia(Me.DbmineroDataSet33.Biometrica, TxtCedulaImp.Text)
        Me.ReportViewer1.RefreshReport()
    End Sub

End Class