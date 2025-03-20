Public Class FrmSeleRptUiaf

    'cargue del formulario
    Private Sub FrmSeleRptUiaf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Panel1.Select()
        Me.BtnReporte.Select()
        Me.BtnReporte.Focus()
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'LINK SIREL
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://reportes.uiaf.gov.co/ReportesFSMCif64/Modules/Home/html/default.aspx")
    End Sub

    'BOTON DE REPORTE
    Private Sub BtnReporte_Click(sender As Object, e As EventArgs) Handles BtnReporte.Click
        FrmReporteUIAF.Show()
    End Sub

    'DESCARGAR FORMATOS DE PLANTILLAS UIAF
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://www.uiaf.gov.co/caracterizacion_usuario/perfiles/reportantes/real_importadoras_exportadoras_oro/7265")
    End Sub

End Class