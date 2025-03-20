Public Class FrmMenuCompras

    'BOTON DE COMRPAS DE ORO
    Private Sub BtnCompras_Click(sender As Object, e As EventArgs) Handles BtnCompras.Click
        Me.Close()
        FrmBuscaProveedor.ShowDialog()
    End Sub

    'BOTON DE MODIFICAR ORO
    Private Sub BtnModificaCompras_Click(sender As Object, e As EventArgs) Handles BtnModificaCompras.Click
        Me.Close()
        FrmBuscaModiCompras.ShowDialog()
    End Sub

    'BOTON DE ELIMINAR COMPRAS DE ORO
    Private Sub BtnEliminaComp_Click(sender As Object, e As EventArgs) Handles BtnEliminaComp.Click
        FrmBuscaEliminaCompras.ShowDialog()
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class