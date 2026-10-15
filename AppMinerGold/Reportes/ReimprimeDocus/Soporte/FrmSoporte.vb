Public Class FrmSoporte
    Private Sub FrmSoporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DsImagenEmpresa.Facturacion' Puede moverla o quitarla según sea necesario.
        Me.FacturacionTableAdapter.FillByCiudad(Me.DsImagenEmpresa.Facturacion, TxtVerCiudImp.Text)

        'TODO: esta línea de código carga datos en la tabla 'DsImagenEmpresa.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByconsecutivo(Me.DsImagenEmpresa.Declara, TxtConsecutivo.Text)

        'TODO: esta línea de código carga datos en la tabla 'DsImagenEmpresa.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DsImagenEmpresa.Empresa)

        Me.ReportViewer1.RefreshReport()

    End Sub
End Class