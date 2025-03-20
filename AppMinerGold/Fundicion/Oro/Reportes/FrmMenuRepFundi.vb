Public Class FrmMenuRepFundi

    'BOTONDE CARGUE DEL FORMLARIO
    Private Sub FrmMenuRepFundi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'BOTON DE SALDOS DE FUNDICION
    Private Sub BtnSaldoFundi_Click(sender As Object, e As EventArgs) Handles BtnSaldoFundi.Click
        FrmRptSaldosFundi.ShowDialog()
    End Sub

    'BOTON DE RELACION DE FUNDICIONES
    Private Sub BtnRelFundi_Click(sender As Object, e As EventArgs) Handles BtnRelFundi.Click
        FrmSeleFechaFundicion.ShowDialog()
    End Sub

    'BOTON DE REIMPRIMIR
    Private Sub BtnReimpTrasalado_Click(sender As Object, e As EventArgs) Handles BtnReimpTrasalado.Click
        FrmSeleReimpDocTraslada.Show()
    End Sub

    'BOTON DE LISTAR PROVEEDORES X FUNDICION
    Private Sub BtnRptFundi_Click(sender As Object, e As EventArgs) Handles BtnRptFundi.Click
        FrmBuscaProvFundi.ShowDialog()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub
End Class