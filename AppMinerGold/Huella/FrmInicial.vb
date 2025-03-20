Public Class FrmInicial

    'CARGUE DEL SISTEMA
    Private Sub FrmInicial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'UBICO EL CURSOR
        Me.Panel1.Select()
        Me.TxtCedula.Select()
        Me.TxtCedula.Focus()
        Me.TxtCedula.Clear()
        Me.TxtVeriCedula.Clear()

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
            Dim ceduhuella As Integer = CInt(TxtCedula.Text)
            My.Forms.Frm_Agregar.Setcedula(ceduhuella)
            My.Forms.Frm_Agregar.Setusuarioglb(ceduhuella)
            My.Forms.Frm_Agregar.ShowDialog()
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
            Dim ceduhuellaV As Integer = CInt(TxtVeriCedula.Text)
            My.Forms.Verificacion.Setvericedula(ceduhuellaV)
            My.Forms.Verificacion.SetusuarioglbV(ceduhuellaV)
            My.Forms.Verificacion.ShowDialog()
            Me.Close()
        End If
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

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub


End Class