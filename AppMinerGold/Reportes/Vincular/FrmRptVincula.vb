Imports Microsoft.Reporting.WinForms

Public Class FrmRptVincula

    Private Sub FrmRptVincula_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet14.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet14.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet14.Empresa1Cliente' Puede moverla o quitarla según sea necesario.
        Me.Empresa1ClienteTableAdapter.FillByEmp1ClienteReimp(Me.DbmineroDataSet14.Empresa1Cliente, TxtClientes.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet14.Clientes' Puede moverla o quitarla según sea necesario.
        Me.ClientesTableAdapter.FillByClienteCedula(Me.DbmineroDataSet14.Clientes, TxtClientes.Text)

        Dim NumRepor As Integer = CInt(TxtClientes.Text)

        Dim p As ReportParameter = New ReportParameter("ced_cl", NumRepor)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {p})
        ReportViewer1.Visible = True
        'ReportViewer1.DataBind()
        ReportViewer1.LocalReport.Refresh()
        Me.ClientesTableAdapter.Fill(Me.DbmineroDataSet14.Clientes)

        conn.Open()
        'PASO DATOS AL REPORTE
        'Dim osql1 As String = "SELECT * FROM Clientes WHERE ced_cl = '" & TxtClientes.Text & "' ORDER BY ID ASC"
        Dim osql1 As String = "SELECT * FROM Clientes WHERE ced_cl = " & NumRepor 'Like '" & TxtClientes.Text & "%'"
        Dim da1 As New OleDb.OleDbDataAdapter(osql1, conn)
        DbmineroDataSet14.Clientes.Clear()
        da1.Fill(DbmineroDataSet14, "Clientes")

        Me.ReportViewer1.RefreshReport()
        conn.Close()

        ''TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet1.Empresa1Cliente' Puede moverla o quitarla según sea necesario.
        'Me.Empresa1ClienteTableAdapter.Fill(Me.DbmineroDataSet1.Empresa1Cliente)

        ''TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet1.Clientes' Puede moverla o quitarla según sea necesario.
        'Me.ClientesTableAdapter.Fill(Me.DbmineroDataSet1.Clientes)

        ''==conversion a numerico
        'Dim numced As Integer
        'numced = CInt(TxtClientes.Text)

        'Dim p As ReportParameter = New ReportParameter("ced_cl", numced)
        'Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {p})
        'ReportViewer1.Visible = True
        ''ReportViewer1.DataBind()
        'ReportViewer1.LocalReport.Refresh()
        'Me.ClientesTableAdapter.Fill(Me.DbmineroDataSet1.Clientes)

        'conn.Open()

        ''PASO DATOS AL REPORTE
        ''Dim osql1 As String = "SELECT * FROM Clientes WHERE ced_cl Like '" & TxtClientes.Text & "%'"
        'Dim osql1 As String = "SELECT * FROM Clientes WHERE ced_cl = " & numced
        'Dim da1 As New OleDb.OleDbDataAdapter(osql1, conn)
        'DbmineroDataSet1.Clientes.Clear()
        'da1.Fill(DbmineroDataSet1, "Clientes")
        'Me.ReportViewer1.RefreshReport()
        'conn.Close()

    End Sub

End Class
