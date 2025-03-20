Imports System.Globalization
Imports Microsoft.Reporting.WinForms

Public Class FrmNuevoDeclara

    Private WithEvents rptViewer As New ReportViewer()

    Private Sub FrmNuevoDeclara_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cultureInfoES As CultureInfo = New CultureInfo("es-SP")

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet18.Empresa1Cliente' Puede moverla o quitarla según sea necesario.
        Me.Empresa1ClienteTableAdapter.FillByZonas(Me.DbmineroDataSet18.Empresa1Cliente)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet18.Clientes' Puede moverla o quitarla según sea necesario.
        Me.ClientesTableAdapter.FillByZonasCedula(Me.DbmineroDataSet18.Clientes, TxtClientes.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet18.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DbmineroDataSet18.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet18.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByCedula(Me.DbmineroDataSet18.Declara, TxtClientes.Text)

        Me.ReportViewer1.RefreshReport()

    End Sub


End Class