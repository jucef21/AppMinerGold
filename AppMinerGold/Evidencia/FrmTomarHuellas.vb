Public Class FrmTomarHuellas

    'CARGUE DEL FORMULARIO
    Private Sub FrmTomarHuellas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UBICO EL CURSOR
        Me.Panel1.Select()
        Me.TxtCedula.Select()
        Me.TxtCedula.Focus()
        Me.TxtCedula.Clear()
    End Sub

    'BOTON DE INRESAR
    Private Sub BtnIngresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIngresa.Click
        If TxtCedula.Text = "" Then
            'Mensaje
            MsgBox("El campo no puede quedar Vacío, Ingrese una Cédula.", MsgBoxStyle.Information, "AppMinerGold")
            Me.Panel1.Select()
            Me.TxtCedula.Select()
            Me.TxtCedula.Focus()
            Me.TxtCedula.Clear()
        Else
            'My.Forms.Frm_Agregar.Setcedula(Me.TxtCedula.Text.Trim)
            'My.Forms.Frm_Agregar.Setusuarioglb(Me.TxtCedula.Text.Trim)
            'My.Forms.Frm_Agregar.Show()
            Me.Close()
        End If
    End Sub

    'BOTON DE VERIFICAR
    Private Sub BtnVerifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerifica.Click
        If TxtVeriCedula.Text = "" Then
            'Mensaje
            MsgBox("El campo no puede quedar Vacío, Ingrese una Cédula.", MsgBoxStyle.Information, "AppMinerGold")
            Me.Panel1.Select()
            Me.TxtCedula.Select()
            Me.TxtCedula.Focus()
            Me.TxtCedula.Clear()
        Else
            'My.Forms.Verificacion.Setvericedula(Me.TxtVeriCedula.Text.Trim)
            'My.Forms.Verificacion.Setusuarioglb(Me.TxtVeriCedula.Text.Trim)
            'My.Forms.Verificacion.Show()
            Me.Close()
        End If
    End Sub

    'BOTON DE REGRESAR
    Private Sub BtnRegresa_Click_1(sender As Object, e As EventArgs) Handles BtnRegresa.Click
        Me.Close()

    End Sub

    'EVENTO KEYPRESS ingreso
    Private Sub TxtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCedula.KeyPress
        'solo acepta numeros
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'EVENTO KEYPRESS verifica
    Private Sub TxtVeriCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtVeriCedula.KeyPress
        'solo acepta numeros
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub



End Class