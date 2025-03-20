Public Class FrmRptFechaProv

    Private Sub FrmRptFechaProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet28.Clientes' Puede moverla o quitarla según sea necesario.
        Me.ClientesTableAdapter.FillByFechaxProv(Me.DbmineroDataSet28.Clientes, TextBox1.Text, TextBox2.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet28.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet28.Empresa)

        Me.ReportViewer1.RefreshReport()
    End Sub

End Class