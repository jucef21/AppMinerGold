Public Class FrmDisponible

    Private Sub FrmDisponible_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet34.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet34.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet34.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByClientesXzonas(Me.DbmineroDataSet34.Declara, TxtFechaIni.Text, TxtFechaFin.Text)

        Dim value As String
        value = TxtZonas.Text
        Dim params(0) As Microsoft.Reporting.WinForms.ReportParameter
        params(0) = New Microsoft.Reporting.WinForms.ReportParameter("ParameterZonas", value)
        Me.ReportViewer1.LocalReport.SetParameters(params)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet34.Empresa1Cliente' Puede moverla o quitarla según sea necesario.
        Me.Empresa1ClienteTableAdapter.FillByClientes1emp(Me.DbmineroDataSet34.Empresa1Cliente, TxtFechaIni.Text, TxtFechaFin.Text)


        Me.ReportViewer1.RefreshReport()

    End Sub


End Class