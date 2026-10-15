Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class FrmImpTodosReportes

    Private Sub FrmImpTodosReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim reporte As New FrmActaEntrega()

        'reporte.GenerarPDF(TxtConsecutivo.Text, "C:\Temp\ActaEntrega.pdf")

        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub BtnPruebaPDF_Click(sender As Object, e As EventArgs) Handles BtnPruebaPDF.Click
        Try
            Dim consecutivo As String = TxtConsecutivo.Text.Trim()

            If String.IsNullOrWhiteSpace(consecutivo) Then
                MessageBox.Show("No hay un consecutivo seleccionado.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim carpetaTemp As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AppMinerGold", "Temp", consecutivo)

            Directory.CreateDirectory(carpetaTemp)

            Dim pdf1 As String = Path.Combine(carpetaTemp, "01_ActaEntrega_" & consecutivo & ".pdf")
            Dim pdf2 As String = Path.Combine(carpetaTemp, "02_CertificacionTri_" & consecutivo & ".pdf")
            Dim pdf3 As String = Path.Combine(carpetaTemp, "03_Contrato_" & consecutivo & ".pdf")
            Dim pdf4 As String = Path.Combine(carpetaTemp, "04_Liquidacion_" & consecutivo & ".pdf")
            Dim pdf5 As String = Path.Combine(carpetaTemp, "05_Pagare_" & consecutivo & ".pdf")

            Me.Cursor = Cursors.WaitCursor

            '==============================
            ' 1. ACTA DE ENTREGA
            '==============================
            Dim acta As New FrmActaEntrega()

            If Not acta.GenerarPDF(consecutivo, pdf1) Then
                Exit Sub
            End If

            '==============================
            ' 2. CERTIFICACION
            '==============================
            Dim certificacion As New FrmCertificacion()

            If Not certificacion.GenerarPDF(consecutivo, pdf2) Then
                Exit Sub
            End If

            '==============================
            ' 3. CONTRATO
            '==============================
            Dim contrato As New FrmContrato()

            If Not contrato.GenerarPDF(consecutivo, pdf3) Then
                Exit Sub
            End If

            '==============================
            ' 4. LIQUIDACION
            '==============================
            Dim liquidacion As New FrmLiquidacion()

            If Not liquidacion.GenerarPDF(consecutivo, pdf4) Then
                Exit Sub
            End If

            '==============================
            ' 5. PAGARE
            '==============================
            Dim pagare As New FrmPagare()

            If Not pagare.GenerarPDF(consecutivo, pdf5) Then
                Exit Sub
            End If

            '==============================
            ' 6. GENERO COMPLETO EL PDF
            '==============================
            'Dim consecutivo As String = TxtConsecutivo.Text.Trim()

            Dim carpetaBase As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AppMinerGold")

            'Dim carpetaTemp As String = Path.Combine(carpetaBase, "Temp", consecutivo)

            Dim rutaPDFFinal As String = Path.Combine(carpetaBase, "Compra_" & consecutivo & ".pdf")

            If UnirPDFs(carpetaTemp, rutaPDFFinal) Then
                MessageBox.Show("Los 5 reportes fueron unidos correctamente." & Environment.NewLine & Environment.NewLine & "Archivo generado:" & Environment.NewLine & rutaPDFFinal, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            MessageBox.Show("Los 5 reportes fueron generados correctamente.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error generando los reportes:" & Environment.NewLine & Environment.NewLine & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function UnirPDFs(ByVal carpetaTemp As String, ByVal rutaPDFFinal As String) As Boolean

        Try
            Dim archivosPDF() As String = {
                Path.Combine(carpetaTemp, "01_ActaEntrega_" & TxtConsecutivo.Text & ".pdf"),
                Path.Combine(carpetaTemp, "02_CertificacionTri_" & TxtConsecutivo.Text & ".pdf"),
                Path.Combine(carpetaTemp, "03_Contrato_" & TxtConsecutivo.Text & ".pdf"),
                Path.Combine(carpetaTemp, "04_Liquidacion_" & TxtConsecutivo.Text & ".pdf"),
                Path.Combine(carpetaTemp, "05_Pagare_" & TxtConsecutivo.Text & ".pdf")
            }

            'Verificar que existan los 5 archivos
            For Each archivo As String In archivosPDF

                If Not File.Exists(archivo) Then
                    MessageBox.Show("No se encontró el archivo:" & Environment.NewLine & Environment.NewLine & archivo, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            Next

            'Crear el PDF final
            Using documento As New Document()
                Using salida As New FileStream(rutaPDFFinal, FileMode.Create, FileAccess.Write, FileShare.None)
                    Using copiador As New PdfCopy(documento, salida)
                        documento.Open()
                        For Each archivo As String In archivosPDF
                            Using lector As New PdfReader(archivo)
                                For pagina As Integer = 1 To lector.NumberOfPages
                                    copiador.AddPage(copiador.GetImportedPage(lector, pagina))
                                Next
                            End Using
                        Next
                        documento.Close()
                    End Using
                End Using
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show("Error uniendo los archivos PDF:" & Environment.NewLine & Environment.NewLine & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function



End Class