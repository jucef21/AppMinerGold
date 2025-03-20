Public Class FrmRptAcumCliente

    Private Sub FrmRptAcumCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet17.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet17.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet17.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.Fill(Me.DbmineroDataSet17.Declara)

        Me.DeclaraTableAdapter.FillByAcumCliente(Me.DbmineroDataSet17.Declara, TextBox1.Text, TextBox2.Text, TxtClientes.Text)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class