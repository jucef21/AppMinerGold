Public Class FrmRptTotalCM

    Private Sub FrmRptTotalCM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet9.CajamenorAse1' Puede moverla o quitarla según sea necesario.
        'Me.CajamenorAse1TableAdapter.Fill(Me.DbmineroDataSet9.CajamenorAse1)

        Me.EmpresaTableAdapter.FillByEmpresa(Me.DbmineroDataSet9.Empresa)

        Dim SQLase1 As String
        Dim ConnAse1Total As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(FrmReporteFechasTotalCM.DTPinicialCaja.Value.Date)
        Dim hugh2 As Date = CStr(FrmReporteFechasTotalCM.DTPfinalCaja.Value.Date)
        SQLase1 = "SELECT * FROM CajamenorAse1 WHERE fechaactual_pre BETWEEN @starDate AND @enddate ORDER BY id ASC "
        ConnAse1Total.ConnectionString = cs
        Dim da As New OleDb.OleDbDataAdapter(SQLase1, ConnAse1Total)
        With da.SelectCommand.Parameters
            .AddWithValue("@starDate", hugh)
            .AddWithValue("@endDate", hugh2)
        End With
        da.Fill(DbmineroDataSet9, "CajamenorAse1")
        Me.ReportViewer1.RefreshReport()
    End Sub

End Class