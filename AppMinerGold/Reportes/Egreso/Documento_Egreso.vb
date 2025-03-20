Public Class Documento_Egreso

    Private Sub FrmEgreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet20.Clientes' Puede moverla o quitarla según sea necesario.
        Me.ClientesTableAdapter.FillByCedulaImg(Me.DbmineroDataSet20.Clientes, TxtClientes.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet20.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet20.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet20.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByXcedula(Me.DbmineroDataSet20.Declara, TxtClientes.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet20.FormaPago' Puede moverla o quitarla según sea necesario.
        Me.FormaPagoTableAdapter.Fill(Me.DbmineroDataSet20.FormaPago)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class