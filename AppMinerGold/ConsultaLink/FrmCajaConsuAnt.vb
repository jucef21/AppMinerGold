Public Class FrmCajaConsuAnt

    'CARGUE DEL FORMULARIO
    Private Sub FrmCajaConsuAnt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'LINK PARA CONSULTA DE PROCURADURIA
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://www.procuraduria.gov.co/portal/consulta_antecedentes.page")
    End Sub

    'LINK PARA CONSULTA DE POLICIA
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://antecedentes.policia.gov.co:7005/WebJudicial/antecedentes.xhtml")
    End Sub

    'LINK PARA CONSULTA DE MINERIA
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("https://tramites.anm.gov.co/Portal/pages/consultaListados/anonimoListados.jsf")
    End Sub

    'LINK PARA CONSULTA DE OFAC
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Process.Start("https://sanctionssearch.ofac.treas.gov/")
    End Sub

    'LINK PARA CONSULTA DE SALDOS DE PROVEEDORES
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Process.Start("https://www.anm.gov.co/?q=barequeros")
    End Sub

    '======================================================

    'LINK PARA CONSULTA DE VALORES DE  ORO DIARIO
    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Process.Start("https://www.goldprice.org/es")
    End Sub

    'LINK PARA CONSULTA DE VALORES DE  ORO DIARIO SEGUNDA OPCION
    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Process.Start("https://www.kitco.com/")
    End Sub

    'LINK PARA CONSULTA DE VALORES TRM
    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Process.Start("http://www.banrep.gov.co/es/estadisticas/trm")
    End Sub

    'LINK PARA CONSULTA DE VALORES BANCO DE BOGOTA
    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Process.Start("https://www.bancodebogota.com/wps/portal/banco-de-bogota/bogota/investigaciones-economicas")
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class