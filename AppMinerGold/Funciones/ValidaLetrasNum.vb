Module ValidaLetrasNum

    'Funcion para que solo permite el ingreso de caracteres tipo letra
    Sub SoloLetras(ByRef e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Solo se puede ingresar valores de tipo texto.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = False
        End If
    End Sub

    'Funcion para que solo permite el ingreso de caracteres tipo numerico
    Sub SoloNumeros(ByRef e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MessageBox.Show("Solo se puede ingresar valores de tipo número.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Module
