Imports System.IO
Public Class FrmActaEntrega

    Private Sub FrmActaEntrega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.EmpresaTableAdapter.Fill(Me.DsContrato.Empresa)
        Me.DeclaraTableAdapter.FillByConsecutivo(Me.DsContrato.Declara, TxtConsecutivo.Text)
        Me.ReportViewer1.RefreshReport()
    End Sub


    Public Function GenerarPDF(ByVal consecutivo As String, ByVal rutaPDF As String) As Boolean
        Try
            'Asignar consecutivo
            Me.TxtConsecutivo.Text = consecutivo

            'Cargar Empresa
            Me.EmpresaTableAdapter.Fill(Me.DsContrato.Empresa)

            'Cargar la compra seleccionada
            Me.DeclaraTableAdapter.FillByConsecutivo(Me.DsContrato.Declara, consecutivo)

            'Actualizar ReportViewer
            Me.ReportViewer1.RefreshReport()

            'Renderizar el RDLC como PDF
            Dim bytesPDF() As Byte = Me.ReportViewer1.LocalReport.Render("PDF")

            'Guardar PDF
            File.WriteAllBytes(rutaPDF, bytesPDF)

            Return True
        Catch ex As Exception
            MessageBox.Show("Error generando Acta de Entrega:" & Environment.NewLine & Environment.NewLine & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Class