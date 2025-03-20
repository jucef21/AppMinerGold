Public Class FrmMenu

    'CARGUE DEL FORM
    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Panel3.Select()
        Me.Panel1.Select()
        Me.BtnCompraOro.Select()
        Me.BtnCompraOro.Focus()
    End Sub

    'COMPRAS DE ORO
    Private Sub BtnCompraOro_Click(sender As Object, e As EventArgs) Handles BtnCompraOro.Click
        Me.Close()
        FrmMenuCompras.ShowDialog()
    End Sub

    'COMPRAS DE PLATINO
    Private Sub BtnCompraPlatino_Click(sender As Object, e As EventArgs) Handles BtnCompraPlatino.Click
        Me.Close()
        FrmMenuComPlatino.ShowDialog()
    End Sub

    'COMPRAS DE PATLA
    Private Sub BtnCompraPlata_Click(sender As Object, e As EventArgs) Handles BtnCompraPlata.Click
        Me.Close()
        FrmMenuComPlata.ShowDialog()
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub


End Class