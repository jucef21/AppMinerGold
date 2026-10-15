Public Class FrmEscojeImpPlata

    Private Sub FrmEscojeImpPlata_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'BOTON DE DECLARACION DEL BAREQUERO
    Private Sub BtnDeclara_Click(sender As Object, e As EventArgs) Handles BtnDeclara.Click

        Declaración_de_produccion.TxtClientes.Text = Me.TxtCedImp.Text
        Declaración_de_produccion.TxtConse.Text = Me.TxtConsecu.Text
        Declaración_de_produccion.ShowDialog()

    End Sub

    'BOTON DE EQUIVALENTE
    Private Sub BtnEquivalente_Click(sender As Object, e As EventArgs) Handles BtnEquivalente.Click
        Documento_Equivalente.TxtClientes.Text = Me.TxtCedImp.Text
        Documento_Equivalente.TxtVerCiud.Text = Me.TxtEmpCiuImp.Text
        Documento_Equivalente.ShowDialog()
    End Sub

    'BOTON DE EGRESO
    Private Sub BtnEgreso_Click(sender As Object, e As EventArgs) Handles BtnEgreso.Click
        Documento_Egreso.TxtClientes.Text = Me.TxtCedImp.Text
        Documento_Egreso.ShowDialog()
    End Sub

    'BOTON DE CERRAR FROM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    Private Sub BtnContrato_Click(sender As Object, e As EventArgs) Handles BtnContrato.Click
        FrmContrato.TxtCedula.Text = TxtCedImp.Text
        FrmContrato.TxtConsecutivo.Text = TxtConsecu.Text
        FrmContrato.ShowDialog()
    End Sub

    Private Sub BtnActa_Click(sender As Object, e As EventArgs) Handles BtnActa.Click
        FrmActaEntrega.TxtCedula.Text = TxtCedImp.Text
        FrmActaEntrega.TxtConsecutivo.Text = TxtConsecu.Text
        FrmActaEntrega.ShowDialog()
    End Sub

    Private Sub BtnCertifica_Click(sender As Object, e As EventArgs) Handles BtnCertifica.Click
        FrmCertificacion.TxtCedula.Text = TxtCedImp.Text
        FrmCertificacion.TxtConsecutivo.Text = TxtConsecu.Text
        FrmCertificacion.ShowDialog()
    End Sub

    Private Sub BtnLiquidacion_Click(sender As Object, e As EventArgs) Handles BtnLiquidacion.Click
        FrmLiquidacion.TxtCedula.Text = TxtCedImp.Text
        FrmLiquidacion.TxtConsecutivo.Text = TxtConsecu.Text
        FrmLiquidacion.ShowDialog()
    End Sub

    Private Sub BtnPagare_Click(sender As Object, e As EventArgs) Handles BtnPagare.Click
        FrmPagare.TxtCedula.Text = TxtCedImp.Text
        FrmPagare.TxtConsecutivo.Text = TxtConsecu.Text
        FrmPagare.ShowDialog()
    End Sub

    Private Sub BtnSoporte_Click(sender As Object, e As EventArgs) Handles BtnSoporte.Click
        'FrmSeleTodosReportes.TxtVerCiudImp.Text = TxtEmpCiuImp.Text
        FrmImpTodosReportes.TxtConsecutivo.Text = TxtConsecu.Text
        FrmImpTodosReportes.ShowDialog()
    End Sub

End Class