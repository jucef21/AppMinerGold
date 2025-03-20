Public Class FrmMenuTax

    'CARGUE DLE FORM
    Private Sub FrmMenuTax_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor()
        Me.Panel3.Select()
        Me.Panel2.Select()
        Me.BtnOro.Select()
        Me.BtnOro.Focus()
        Me.Cursor = Cursors.Default()
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'BOTON DE ORO
    Private Sub BtnOro_Click(sender As Object, e As EventArgs) Handles BtnOro.Click
        Me.Cursor = Cursors.WaitCursor()
        FrmTasasOro.ShowDialog()
        Me.Close()
        Me.Cursor = Cursors.Default()
    End Sub

    'BOTON DE PLATA
    Private Sub BtnPlata_Click(sender As Object, e As EventArgs) Handles BtnPlata.Click
        Me.Cursor = Cursors.WaitCursor()
        FrmTasasPlata.ShowDialog()
        Me.Close()
        Me.Cursor = Cursors.Default()
    End Sub

    'BOTON DE PLATINO
    Private Sub BtnPlatino_Click(sender As Object, e As EventArgs) Handles BtnPlatino.Click
        Me.Cursor = Cursors.WaitCursor()
        FrmTasaPlatino.ShowDialog()
        Me.Close()
        Me.Cursor = Cursors.Default()
    End Sub


End Class