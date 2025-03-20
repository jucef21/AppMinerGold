Public Class FrmNuevoReimpEqui

    Private Sub FrmNuevoReimpEqui_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet27.Facturacion' Puede moverla o quitarla según sea necesario.
        Me.FacturacionTableAdapter.FillByCiudad(Me.DbmineroDataSet27.Facturacion, TxtVerCiudImp.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet27.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet27.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet27.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByXconsecutivo(Me.DbmineroDataSet27.Declara, TxtConsecutivo.Text)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class