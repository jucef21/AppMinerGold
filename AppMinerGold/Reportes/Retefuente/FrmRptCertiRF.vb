Public Class FrmRptCertiRF

    Private Sub FrmRptCertiRF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet31.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByConsecutivo(Me.DbmineroDataSet31.Declara, TxtConsecutivo.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet31.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet31.Empresa)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class