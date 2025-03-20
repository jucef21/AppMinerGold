Public Class FrmSecretaria

    'CARGA DEL FORMULARIO
    Private Sub FrmSecretaria_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Panel3.Select()
        Me.Panel2.Select()
        Me.BtnRegistro.Select()
        Me.BtnRegistro.Focus()
    End Sub

    'BOTON DE CLIENTES
    Private Sub BtnClientesS_Click(sender As System.Object, e As System.EventArgs) Handles BtnClientesS.Click
        Me.Cursor = Cursors.WaitCursor()
        'FrmProveedores.ShowDialog()
        FrmClienteActividad.ShowDialog()
        Me.Cursor = Cursors.Default()
        Me.Close()
    End Sub

    'BOTON DE REGISTRO FOTO
    Private Sub BtnRegistro_Click(sender As Object, e As EventArgs) Handles BtnRegistro.Click
        Me.Cursor = Cursors.WaitCursor()
        FrmFoto.ShowDialog()
        Me.Cursor = Cursors.Default()
        Me.Close()
    End Sub

    'BOTON DE ACTIVIDAD DE CLIENTES
    Private Sub BtnClienteAct_Click(sender As Object, e As EventArgs) Handles BtnClienteAct.Click
        Me.Cursor = Cursors.WaitCursor()
        FrmBuscaEmpCli.ShowDialog()
        Me.Cursor = Cursors.Default()
    End Sub

    'BOTON DE CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class