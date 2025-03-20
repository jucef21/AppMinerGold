Public Class FrmRptEgresoEquivalente

    Private Sub FrmRptEgresoEquivalente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet10.Declara' Puede moverla o quitarla según sea necesario.
        'Me.DeclaraTableAdapter.Fill(Me.DbmineroDataSet10.Declara)

        'Dim p As ReportParameter = New ReportParameter("ced_cl", Me.TxtClientes.Text)
        'Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {p})
        'ReportViewer1.Visible = True
        ''ReportViewer1.DataBind()
        'ReportViewer1.LocalReport.Refresh()
        'Me.DeclaraTableAdapter.Fill(Me.DbmineroDataSet10.Declara)

        'conn.Open()
        ''PASO DATOS AL REPORTE
        ''Dim osql1 As String = "SELECT * FROM Clientes WHERE ced_cl = '" & TxtClientes.Text & "' ORDER BY ID ASC"
        'Dim osql1 As String = "SELECT TOP 1 * FROM Declara WHERE cedu_com Like '" & TxtClientes.Text & "%' ORDER BY id DESC"
        'Dim da1 As New OleDb.OleDbDataAdapter(osql1, conn)
        'DbmineroDataSet10.Declara.Clear()
        'da1.Fill(DbmineroDataSet10, "Declara")
        'Me.ReportViewer1.RefreshReport()

        'conn.Close()

        '       Me.ReportViewer1.RefreshReport
        'Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport
    End Sub

End Class