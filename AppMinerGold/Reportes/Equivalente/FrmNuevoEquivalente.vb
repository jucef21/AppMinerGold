Public Class FrmNuevoEquivalente

    Private Sub FrmNuevoEquivalente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet25.Facturacion' Puede moverla o quitarla según sea necesario.
        Me.FacturacionTableAdapter.FillByCiudad(Me.DbmineroDataSet25.Facturacion, TxtVerCiud.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet25.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet25.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet25.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillBycedula(Me.DbmineroDataSet25.Declara, TxtClientes.Text)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class