Public Class FrmConsuAnt

    'CARGUE DEL FORMULARIO
    Private Sub FrmConsuAnt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'LINK PARA CONSULTA DE PROCURADURIA
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://www.procuraduria.gov.co/Pages/Generacion-de-antecedentes.aspx")
    End Sub

    'LINK PARA CONSULTA DE POLICIA
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://antecedentes.policia.gov.co:7005/WebJudicial/antecedentes.xhtml")
    End Sub

    'LINK PARA CONSULTA DE OFAC
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Process.Start("https://sanctionssearch.ofac.treas.gov/")
    End Sub

    'LINK PARA CONSULTA DE REGISTRADURIA
    Private Sub LinkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Process.Start("https://certvigenciacedula.registraduria.gov.co/Datos.aspx")
    End Sub

    'LINK PARA CONSULTA DE NACIONES UNIDAS
    Private Sub LinkLabel12_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        Process.Start("https://www.un.org/site-search/?query=antecedentes")
    End Sub

    'LINK PARA CONSULTA DE CONTRALORIA
    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Process.Start("https://www.contraloria.gov.co/web/guest/persona-natural")
    End Sub

    'LINK PARA CONSULTA DE MINERIA
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("https://tramites.anm.gov.co/Portal/pages/consultaListados/anonimoListados.jsf")
    End Sub

    'LINK PARA CONSULTA DE SALDOS DE PROVEEDORES
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Process.Start("https://www.anm.gov.co/?q=barequeros")
    End Sub

    'LINK PARA CONSULTA DE DOLAR ADUANERO
    Private Sub LinkLabel13_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        Process.Start("https://www.dian.gov.co/dian/cifras/Paginas/DetalleTRM.aspx?DianId=960")
    End Sub

    '======================================================

    'LINK PARA CONSULTA DE VALORES DE  ORO DIARIO - GOLDPRICE TROY
    Private Sub LinkGoldPrice_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkGoldPrice.LinkClicked
        Process.Start("https://www.goldprice.org/es")
    End Sub

    'LINK PARA CONSULTA DE VALORES DE  ORO DIARIO SEGUNDA OPCION - KITCO TROY
    Private Sub LinkKitco_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkKitco.LinkClicked
        Process.Start("https://www.kitco.com/charts/gold")
    End Sub

    'LINK PARA CONSULTA DE VALORES TRM
    Private Sub LinkTrm_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkTrm.LinkClicked
        Process.Start("https://www.banrep.gov.co/en/node/53653")
    End Sub

    'LINK PARA CONSULTA DE VALORES BANCO DE BOGOTA
    Private Sub LinkBcoBogota_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkBcoBogota.LinkClicked
        Process.Start("https://www.bancodebogota.com/wps/portal/banco-de-bogota/bogota/investigaciones-economicas")
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'LINK PARA CONSULTA DE LISTA EUROPEA
    Private Sub LinkLabel14_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        Process.Start("https://eumostwanted.eu/es/search/node?keys=")
    End Sub

    'LINK PARA CONSULTA DE LISTA EUROPEA
    Private Sub LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Process.Start("https://eur-lex.europa.eu/ES/legal-content/glossary/member-states.html")
    End Sub

    Private Sub LinkDolarSpot_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkDolarSpot.LinkClicked
        Process.Start("https://dolar.wilkinsonpc.com.co/dolar-hoy-spot-minuto-a-minuto/")
    End Sub

End Class