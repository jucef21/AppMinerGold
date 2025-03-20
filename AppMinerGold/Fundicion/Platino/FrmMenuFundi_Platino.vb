Public Class FrmMenuFundi_Platino

    'CARGUE DEL FORMULARIO
    Private Sub FrmMenuFundi_Platino_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'BOTON DE FUNDICION
    Private Sub BtnFundi_Click(sender As Object, e As EventArgs) Handles BtnFundi.Click
        Me.Cursor = Cursors.WaitCursor
        Me.Close()
        FrmTrasladaFundi_Platino.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE REPORTES DE FUNDICION()
    Private Sub BtnFundiReport_Click(sender As Object, e As EventArgs) Handles BtnFundiReport.Click
        Me.Cursor = Cursors.WaitCursor
        Me.Close()
        FrmMenuRepFundi_Platino.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE ELIMINAR FUNDICION
    Private Sub BtnEliminaFundi_Click(sender As Object, e As EventArgs) Handles BtnEliminaFundi.Click
        Me.Cursor = Cursors.WaitCursor
        FrmSaldoFundicion_Platino.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class