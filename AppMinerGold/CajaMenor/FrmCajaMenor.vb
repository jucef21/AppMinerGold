Public Class FrmCajaMenor

    'CARGUE DEL FORMULARIO 
    Private Sub FrmCajaMenor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'INHABILITO LOS BOTONES
        Me.GroupBox1.Select()
        Me.BtnAsesor1.Select()
        Me.BtnAsesor1.Enabled = True
        Me.BtnAsesor1.Focus()
    End Sub

    'BOTON ASESOR 1
    Private Sub BtnAsesor1_Click(sender As Object, e As EventArgs) Handles BtnAsesor1.Click
        Refresh()

        'CONECTO LA BASE DE DATOS
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        FrmLoginCaja.Show()

    End Sub

    'BOTON SALIR DEL FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class