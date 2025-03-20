Public Class FrmProveeMenu

    'CARGUE DEL FORMULARIO
    Private Sub FrmProveeMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnCompleto_Click(sender As Object, e As EventArgs) Handles BtnCompleto.Click
        'FrmListaClientes.Show()
        FrmRptFullZonasDpto.ShowDialog()
    End Sub

    Private Sub BtnFechas_Click(sender As Object, e As EventArgs) Handles BtnFechas.Click
        FrmFechasXproveedores.Show()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    Private Sub BtnDatosClientes_Click(sender As Object, e As EventArgs) Handles BtnDatosClientes.Click
        FrmClienteCedula.Show()
    End Sub

End Class