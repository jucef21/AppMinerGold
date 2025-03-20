Public Class FrmRptAcomula
    Private Sub FrmRptAcomula_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet6.Declara' Puede moverla o quitarla según sea necesario.
        'Me.DeclaraTableAdapter.Fill(Me.DbmineroDataSet6.Declara)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet6.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.FillByEmpresa(Me.DbmineroDataSet6.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet6.Declara' Puede moverla o quitarla según sea necesario.
        'Me.DeclaraTableAdapter.Fill(Me.DbmineroDataSet6.Declara)
        'PARA ADMIN
        Me.DeclaraTableAdapter.FillByFechaCompra(Me.DbmineroDataSet6.Declara, TextBox1.Text, TextBox2.Text)
        'PARA CAJERO
        'Me.DeclaraTableAdapter.FillByFechaCompra(Me.DbmineroDataSet6.Declara, FrmCajaRangoAcumulado.DTPinicial.Value, FrmCajaRangoAcumulado.DTPfinal.Value)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class