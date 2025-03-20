Public Class FrmEquivalenteDec

    Private Sub FrmEquivalenteDec_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet19.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet19.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet19.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByOrdenCedyConse(Me.DbmineroDataSet19.Declara, TxtClientes.Text)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class