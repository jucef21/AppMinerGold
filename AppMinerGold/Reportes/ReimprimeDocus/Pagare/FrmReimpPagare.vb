Public Class FrmReimpPagare
    Private Sub FrmReimpPagare_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DsContrato.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DsContrato.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DsContrato.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByConsecutivo(Me.DsContrato.Declara, TxtConsecutivo.Text)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class