Public Class Documento_Equivalente

    Private Sub FrmEquiChoco_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet26.Facturacion' Puede moverla o quitarla según sea necesario.
        Me.FacturacionTableAdapter.FillByCiudad(Me.DbmineroDataSet26.Facturacion, TxtVerCiud.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet26.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet26.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet26.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByCedula(Me.DbmineroDataSet26.Declara, TxtClientes.Text)

        Me.ReportViewer1.RefreshReport()
    End Sub

End Class