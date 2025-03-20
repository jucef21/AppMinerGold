Public Class FrmNuevaCompra
    Private Sub FrmNuevaCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet24.CompraVenta' Puede moverla o quitarla según sea necesario.
        'Me.CompraVentaTableAdapter.Fill(Me.DbmineroDataSet24.CompraVenta)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet24.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet24.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet24.CompraVenta' Puede moverla o quitarla según sea necesario.
        Me.CompraVentaTableAdapter.FillByNumCV(Me.DbmineroDataSet24.CompraVenta, TxtNumCV.Text)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class