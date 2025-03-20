Public Class FrmMenuRepFundi_Plata

    Private Sub FrmMenuRepFundi_Plata_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'BOTON DE SALDOS DE FUNDICION
    Private Sub BtnSaldoFundi_Click(sender As Object, e As EventArgs) Handles BtnSaldoFundi.Click
        FrmRptSaldosFundi_Plata.ShowDialog()
    End Sub

    'BOTON DE RELACION DE FUNDICIONES
    Private Sub BtnRelFundi_Click(sender As Object, e As EventArgs) Handles BtnRelFundi.Click
        FrmSeleFechaFundicion_Plata.ShowDialog()
    End Sub

    'BOTON DE REIMPRIMIR
    Private Sub BtnReimpTrasalado_Click(sender As Object, e As EventArgs) Handles BtnReimpTrasalado.Click
        FrmSeleReimpDocTrasladaPlata.Show()
    End Sub

    'BOTON DE LISTAR PROVEEDORES X FUNDICION
    Private Sub BtnRptFundi_Click(sender As Object, e As EventArgs) Handles BtnRptFundi.Click
        FrmBuscaProvFundiPlata.ShowDialog()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub
End Class