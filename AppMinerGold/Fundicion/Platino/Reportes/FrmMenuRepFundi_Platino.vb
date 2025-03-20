Public Class FrmMenuRepFundi_Platino

    Private Sub FrmMenuRepFundi_Platino_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'BOTON DE SALDOS DE FUNDICION
    Private Sub BtnSaldoFundi_Click(sender As Object, e As EventArgs) Handles BtnSaldoFundi.Click
        FrmRptSaldosFundi_Platino.ShowDialog()
    End Sub

    'BOTON DE RELACION DE FUNDICIONES
    Private Sub BtnRelFundi_Click(sender As Object, e As EventArgs) Handles BtnRelFundi.Click
        FrmSeleFechaFundicion_Platino.ShowDialog()
    End Sub

    'BOTON DE REIMPRIMIR
    Private Sub BtnReimpTrasalado_Click(sender As Object, e As EventArgs) Handles BtnReimpTrasalado.Click
        FrmSeleReimpDocTrasladaPlatino.Show()
    End Sub

    'BOTON DE LISTAR PROVEEDORES X FUNDICION
    Private Sub BtnRptFundi_Click(sender As Object, e As EventArgs) Handles BtnRptFundi.Click
        FrmBuscaProvFundiPlatino.ShowDialog()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub
End Class