Public Class FrmRptAcomulaPlatino
    Private Sub FrmRptAcomulaPlatino_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DataSet3.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByPlatino(Me.DataSet3.Declara, TextBox1.Text, TextBox2.Text)

        'TODO: esta línea de código carga datos en la tabla 'DataSet3.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.FillBy(Me.DataSet3.Empresa)

        Me.ReportViewer1.RefreshReport()

    End Sub
End Class