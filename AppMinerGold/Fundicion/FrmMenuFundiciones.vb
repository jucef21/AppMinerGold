Public Class FrmMenuFundiciones

    'CARGUE DEL FORMULARIO
    Private Sub FrmMenuFundiciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Panel2.Select()
        Me.Panel3.Select()
        Me.BtnFundiOro.Select()
        Me.BtnFundiOro.Focus()
    End Sub

    Private Sub BtnFundiOro_Click(sender As Object, e As EventArgs) Handles BtnFundiOro.Click
        Me.Cursor = Cursors.WaitCursor
        Me.Close()
        FrmMenuFundi.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnFundiPlata_Click(sender As Object, e As EventArgs) Handles BtnFundiPlata.Click
        Me.Cursor = Cursors.WaitCursor
        Me.Close()
        FrmMenuFundi_Plata.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnFundiPlatino_Click(sender As Object, e As EventArgs) Handles BtnFundiPlatino.Click
        Me.Cursor = Cursors.WaitCursor
        Me.Close()
        FrmMenuFundi_Platino.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class