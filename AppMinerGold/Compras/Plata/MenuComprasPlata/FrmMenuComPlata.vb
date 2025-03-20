Public Class FrmMenuComPlata

    'CARGUE DEL FORM
    Private Sub FrmMenuComPlata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor()
        Me.Panel3.Select()
        Me.Panel1.Select()
        Me.BtnCompras.Select()
        Me.BtnCompras.Focus()
        Me.Cursor = Cursors.Default()
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'BOTON DE COMPRAS DE PLATA
    Private Sub BtnCompras_Click(sender As Object, e As EventArgs) Handles BtnCompras.Click
        Me.Close()
        FrmBuscaProvPlata.ShowDialog()
    End Sub

    'BOTON DE MODIFICAR COMPRAS DE PLATA
    Private Sub BtnModificaCompras_Click(sender As Object, e As EventArgs) Handles BtnModificaCompras.Click
        Me.Close()
        FrmBuscaModiCompPlata.ShowDialog()
    End Sub

    'BOTON DE ELIMINAR COMPRAS DE PLATA
    Private Sub BtnEliminaComp_Click(sender As Object, e As EventArgs) Handles BtnEliminaComp.Click
        Me.Close()
        FrmPermisoEliPlata.ShowDialog()
    End Sub

End Class