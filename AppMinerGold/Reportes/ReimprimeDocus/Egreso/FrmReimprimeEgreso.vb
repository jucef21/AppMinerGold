Public Class FrmReimprimeEgreso

    Private Sub FrmReimprimeEgreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet13.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.FillByEmpresa(Me.DbmineroDataSet13.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet13.Clientes' Puede moverla o quitarla según sea necesario.
        Me.ClientesTableAdapter.FillByCedulaImg(Me.DbmineroDataSet13.Clientes, TxtCedula.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet13.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByXconsecutivo(Me.DbmineroDataSet13.Declara, TxtConsecutivo.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet13.FormaPago' Puede moverla o quitarla según sea necesario.
        Me.FormaPagoTableAdapter.Fill(Me.DbmineroDataSet13.FormaPago)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class