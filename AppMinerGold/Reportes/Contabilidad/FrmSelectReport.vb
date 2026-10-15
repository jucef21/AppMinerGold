Public Class FrmSelectReport

    Private Sub BtnImpTD_Click(sender As Object, e As EventArgs) Handles BtnImpTD.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor
        FrmSelectConta.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Btn70Total_Click(sender As Object, e As EventArgs) Handles Btn70Total.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor
        FrmSelectConta70Total.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnConta30_Click(sender As Object, e As EventArgs) Handles BtnConta30.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor
        FrmSelectConta30.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Btn30Total_Click(sender As Object, e As EventArgs) Handles Btn30Total.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor
        FrmSelectConta30Total.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub


End Class