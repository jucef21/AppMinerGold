Public Class FrmValidaEmp

    'CARGUE DEL FORMULARIO
    Private Sub FrmValidaEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Panel2.Select()
        Me.Btnaceptar.Select()
        Me.Btnaceptar.Focus()
    End Sub

    'BOTON DE ACEPTAR FORM
    Private Sub Btnaceptar_Click(sender As Object, e As EventArgs) Handles Btnaceptar.Click
        Me.Close()
    End Sub



End Class