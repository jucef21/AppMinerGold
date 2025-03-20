Public Class FrmDigitoVerifca

    'CARGUE DEL FORMULARIO
    Private Sub FrmDigitoVerifca_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'LIMPIO LOS CAMPOS
        Me.TxtDocu.Clear()
        Me.TxtDigito.Clear()
        Me.TxtResult.Clear()

        'HABILITO LOS CAMPOS
        Me.TxtDocu.Enabled = True
        Me.TxtDigito.Enabled = True
        Me.TxtResult.Enabled = True

        'HABILITO LOS BOTONES
        Me.BtnValida.Enabled = True
        Me.BtnLimpiar.Enabled = True

        'UBICO EL CURSOR
        Me.TxtDocu.Select()
        Me.TxtDocu.Focus()

    End Sub

    'PROCEDIMIENTO PARA EL CALCULO DEL NIT
    Public Function Digito_verificacion(ByVal nit As String)
        nit = Format(Val("" & nit), "000000000000000")
        Dim residuo As Integer = 0
        Dim mul As Integer = 0
        'MsgBox(res)

        For i As Integer = 15 To 1 Step -1
            If i = 15 Then
                mul = 3
            ElseIf i = 14 Then
                mul = 7
            ElseIf i = 13 Then
                mul = 13
            ElseIf i = 12 Then
                mul = 17
            ElseIf i = 11 Then
                mul = 19
            ElseIf i = 10 Then
                mul = 23
            ElseIf i = 9 Then
                mul = 29
            ElseIf i = 8 Then
                mul = 37
            ElseIf i = 7 Then
                mul = 41
            ElseIf i = 6 Then
                mul = 43
            ElseIf i = 5 Then
                mul = 47
            ElseIf i = 4 Then
                mul = 53
            ElseIf i = 3 Then
                mul = 59
            ElseIf i = 2 Then
                mul = 67
            Else
                mul = 71
            End If
            residuo = residuo + (Val(GetChar(nit, i)) * mul)
        Next
        residuo = residuo Mod 11

        If residuo = 0 Then
            residuo = 0
        ElseIf residuo = 1 Then
            residuo = 1
        Else
            residuo = 11 - residuo
        End If
        Return residuo
    End Function

    'BOTON DE VALIDAR
    Private Sub BtnValida_Click(sender As Object, e As EventArgs) Handles BtnValida.Click

        TxtDigito.Text = Digito_verificacion(TxtDocu.Text)

        Resultado()

        'DESHABILITO LOS CAMPOS
        Me.TxtDocu.Enabled = False
        Me.TxtDigito.Enabled = False
        Me.TxtResult.Enabled = False

        'HABILITO LOS BOTONES
        Me.BtnValida.Enabled = False
        Me.BtnLimpiar.Enabled = True

        'UBICO EL CURSOR
        Me.BtnLimpiar.Select()
        Me.BtnLimpiar.Focus()

    End Sub

    'PROCEDIMIENTO PARA EL  RESULTADO EN CAMPO DE TEXTO
    Sub Resultado()
        TxtResult.Text = TxtDocu.Text + " - " + TxtDigito.Text
    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        'LIMPIO LOS CAMPOS
        Me.TxtDocu.Clear()
        Me.TxtDigito.Clear()
        Me.TxtResult.Clear()

        'HABILITO LOS CAMPOS
        Me.TxtDocu.Enabled = True
        Me.TxtDigito.Enabled = True
        Me.TxtResult.Enabled = True

        'HABILITO LOS BOTONES
        Me.BtnValida.Enabled = True
        Me.BtnLimpiar.Enabled = True

        'UBICO EL CURSOR
        Me.TxtDocu.Select()
        Me.TxtDocu.Focus()
    End Sub

    'BOTON DE REGRESAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'VALIDA SOLO NUMEROS
    Private Sub TxtDocu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocu.KeyPress
        SoloNumeros(e)
    End Sub

    'BOTON DE SALIR 
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

End Class