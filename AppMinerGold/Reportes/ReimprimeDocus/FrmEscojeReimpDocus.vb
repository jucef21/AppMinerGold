Public Class FrmEscojeReimpDocus

    'CARGUE DEL FORMULARIO
    Private Sub FrmEscojeReimpDocus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TxtCedImp.Text = ModuleFrm.clientes
    End Sub

    'BOTON DE DECLARACION MINERA
    Private Sub BtnDeclara_Click(sender As Object, e As EventArgs) Handles BtnDeclara.Click
        FrmSeleDeclaraMineraReimp.ShowDialog()
    End Sub

    'BOTON DE EQUIVALENTE
    Private Sub BtnEquivalente_Click(sender As Object, e As EventArgs) Handles BtnEquivalente.Click
        FrmSeleEquivaReim.ShowDialog()
    End Sub

    'BOTON DE VINCULACION
    Private Sub BtnReimpVincula_Click(sender As Object, e As EventArgs) Handles BtnReimpVincula.Click
        FrmSeleReimpVincula.ShowDialog()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'BOTON DE EGRESO 
    Private Sub BtnEgreso_Click(sender As Object, e As EventArgs) Handles BtnEgreso.Click
        FrmSeleEgresoReimp.ShowDialog()
    End Sub

    'BOTON DE SOPORTE
    Private Sub BtnSoporte_Click(sender As Object, e As EventArgs) Handles BtnSoporte.Click
        FrmSeleTodosReportes.ShowDialog()
    End Sub

    'BOTON DE CONTRATO
    Private Sub BtnContrato_Click(sender As Object, e As EventArgs) Handles BtnContrato.Click
        FrmSeleContrato.ShowDialog()
    End Sub

    'BOTON DE ACTA DE ENTREGA
    Private Sub BtnActa_Click(sender As Object, e As EventArgs) Handles BtnActa.Click
        FrmSelectActa.ShowDialog()
    End Sub

    'BOTON DE CERTIFICACION TRIBUTARIA
    Private Sub BtnCertificacion_Click(sender As Object, e As EventArgs) Handles BtnCertificacion.Click
        FrmSelectCertificacion.ShowDialog()
    End Sub

    'BOTON DE LIQUIDACION
    Private Sub BtnLiquidacion_Click(sender As Object, e As EventArgs) Handles BtnLiquidacion.Click
        FrmSelectLiquidacion.ShowDialog()
    End Sub

    'BOTON DE PAGARE
    Private Sub BtnPagare_Click(sender As Object, e As EventArgs) Handles BtnPagare.Click
        FrmSelectPagare.ShowDialog()
    End Sub

End Class