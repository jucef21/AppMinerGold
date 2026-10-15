Imports System.IO

Public Class FrmLiquidacion

    Private Sub FrmLiquidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DsContrato.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.Fill(Me.DsContrato.Empresa)
        'TODO: esta línea de código carga datos en la tabla 'DsContrato.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByConsecutivo(Me.DsContrato.Declara, TxtConsecutivo.Text)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Public Function GenerarPDF(ByVal consecutivo As String, ByVal rutaPDF As String) As Boolean
        Try
            Me.TxtConsecutivo.Text = consecutivo
            Me.EmpresaTableAdapter.Fill(Me.DsContrato.Empresa)
            Me.DeclaraTableAdapter.FillByConsecutivo(Me.DsContrato.Declara, consecutivo)
            Me.ReportViewer1.RefreshReport()

            Dim bytesPDF() As Byte = Me.ReportViewer1.LocalReport.Render("PDF")

            File.WriteAllBytes(rutaPDF, bytesPDF)

            Return True
        Catch ex As Exception
            MessageBox.Show("Error generando Liquidación:" & Environment.NewLine & Environment.NewLine & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Class