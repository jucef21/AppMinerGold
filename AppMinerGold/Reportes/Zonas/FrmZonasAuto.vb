Public Class FrmZonasAuto

    Private Sub FrmZonasAuto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet35.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet35.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet35.Empresa1Cliente' Puede moverla o quitarla según sea necesario.
        'Me.Empresa1ClienteTableAdapter.FillByClientes1emp(Me.DbmineroDataSet35.Empresa1Cliente, TxtFechaIni.Text, TxtFechaFin.Text)
        Me.Empresa1ClienteTableAdapter.Fill(Me.DbmineroDataSet35.Empresa1Cliente)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet35.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByZonasXcliente(Me.DbmineroDataSet35.Declara, TxtFechaIni.Text, TxtFechaFin.Text)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class