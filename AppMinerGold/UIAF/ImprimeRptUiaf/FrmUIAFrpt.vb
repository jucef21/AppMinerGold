Public Class FrmUIAFrpt
    Private Sub FrmUIAFrpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet37.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet37.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet37.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByLlenaUIAF(Me.DbmineroDataSet37.Declara, TextBox1.Text, TextBox2.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet37.Clientes' Puede moverla o quitarla según sea necesario.
        Me.ClientesTableAdapter.Fill(Me.DbmineroDataSet37.Clientes)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class