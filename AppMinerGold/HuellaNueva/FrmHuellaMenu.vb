Public Class FrmHuellaMenu
    Private Sub FrmHuellaMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Panel1.Select()
        Me.TxtCedula.Select()
        Me.TxtCedula.Focus()
        Me.TxtCedula.Clear()
        Me.TxtVeriCedula.Clear()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    Private Sub BtnIngresa_Click(sender As Object, e As EventArgs) Handles BtnIngresa.Click
        If TxtCedula.Text = "" Then
            MsgBox("El campo no puede quedar Vacío, Ingrese una Cédula.", MsgBoxStyle.Information, "AppMinerGold")
            Me.Panel1.Select()
            Me.TxtCedula.Select()
            Me.TxtCedula.Focus()
            Me.TxtCedula.Clear()
        Else
            Dim ceduhuella As Integer = CInt(TxtCedula.Text)

            Dim Enroller As New FrmHuellaIngresa()
            'AddHandler Enroller.OnTemplate, AddressOf OnTemplate
            Enroller.Setcedula(ceduhuella)
            Enroller.Setusuarioglb(ceduhuella)
            Enroller.ShowDialog()
            Me.TxtCedula.Clear()
            Me.Close()
        End If
    End Sub

    Private Sub BtnVerifica_Click(sender As Object, e As EventArgs) Handles BtnVerifica.Click
        If TxtVeriCedula.Text = "" Then
            'Mensaje
            MsgBox("El campo no puede quedar Vacío, Ingrese una Cédula.", MsgBoxStyle.Information, "AppMinerGold")
            Me.Panel1.Select()
            Me.TxtVeriCedula.Select()
            Me.TxtVeriCedula.Focus()
            Me.TxtVeriCedula.Clear()
        Else
            Dim ceduhuellaV As String = CInt(TxtVeriCedula.Text)
            My.Forms.FrmHuellaVerificacion.Lblced.Text = ceduhuellaV
            My.Forms.FrmHuellaVerificacion.Setvericedula(ceduhuellaV)
            My.Forms.FrmHuellaVerificacion.SetusuarioglbV(ceduhuellaV)
            My.Forms.FrmHuellaVerificacion.ShowDialog()
            Me.TxtVeriCedula.Clear()
            Me.Close()
        End If

    End Sub

    Private Sub BtnConsulta_Click(sender As Object, e As EventArgs) Handles BtnConsulta.Click
        FrmHuellaCargar.ShowDialog()
        Me.Close()
    End Sub

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