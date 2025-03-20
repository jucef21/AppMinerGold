Public Class FrmRptCompConsecutivo

    Private Sub FrmRptCompConsecutivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet31.Declara' Puede moverla o quitarla según sea necesario.
        'Me.DeclaraTableAdapter.Fill(Me.DbmineroDataSet31.Declara)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet31.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet31.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet31.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByFechaConsecutivo(Me.DbmineroDataSet31.Declara, TextBox1.Text, TextBox2.Text)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class