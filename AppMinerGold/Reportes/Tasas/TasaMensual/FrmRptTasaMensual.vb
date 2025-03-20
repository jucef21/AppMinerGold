Public Class FrmRptTasaMensual
    Private Sub FrmRptTasaMensual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet5.Regalias' Puede moverla o quitarla según sea necesario.
        Me.RegaliasTableAdapter.Fill(Me.DbmineroDataSet5.Regalias)
        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet5.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.FillByEmpresa(Me.DbmineroDataSet5.Empresa)
        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet5.Regalias' Puede moverla o quitarla según sea necesario.
        'Me.RegaliasTableAdapter.Fill(Me.DbmineroDataSet5.Regalias)
        'PARA ADMIN
        Me.RegaliasTableAdapter.FillByFechas(Me.DbmineroDataSet5.Regalias, TextBox1.Text, TextBox2.Text)
        'PARA CAJERO
        'Me.RegaliasTableAdapter.FillByFechas(Me.DbmineroDataSet5.Regalias, FrmCajaRangoTasMensual.DTPinicial.Value, FrmCajaRangoTasMensual.DTPfinal.Value)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class