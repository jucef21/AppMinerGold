Public Class FrmEscojeImp

    'CARGUE DEL FORMULARIO
    Private Sub FrmEscojeImp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'BOTON DE DECLARACION MINERA
    Private Sub BtnDeclara_Click(sender As Object, e As EventArgs) Handles BtnDeclara.Click

        Documento_Origen.TxtClientes.Text = Me.TxtCedImp.Text
        Documento_Origen.TxtConse.Text = Me.TxtConsecu.Text
        Documento_Origen.ShowDialog()

    End Sub

    'BOTON DE EQUIVALENTE
    Private Sub BtnEquivalente_Click(sender As Object, e As EventArgs) Handles BtnEquivalente.Click
        Documento_Equivalente.TxtClientes.Text = Me.TxtCedImp.Text
        Documento_Equivalente.TxtVerCiud.Text = Me.TxtEmpCiuImp.Text
        Documento_Equivalente.ShowDialog()
    End Sub

    'BOTON DE EGRESO
    Private Sub BtnEgreso_Click(sender As Object, e As EventArgs) Handles BtnEgreso.Click
        Documento_Egreso.TxtClientes.Text = Me.TxtCedImp.Text
        Documento_Egreso.ShowDialog()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class