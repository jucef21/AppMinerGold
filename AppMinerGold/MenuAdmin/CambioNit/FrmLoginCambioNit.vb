Imports System.Data.OleDb

Public Class FrmLoginCambioNit


    'representa conexion abierta a una base de datos
    Dim comandos As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter
    Dim lector As OleDbDataReader
    Dim consulta As String

    'CARGUE DEL FORM
    Private Sub FrmLoginCambioNit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'CIERRO LA BASE DE DATOS
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'LLENAMOS LOS DATOS DEL ENCABEZADO DEL CLIENTE - PANEL 1
        'colocamos los texbox en no editable
        Me.TxtClave.Enabled = True

        'UBICO EL CURSOR
        Me.GroupBox1.Select()
        Me.GroupBox1.Focus()
        Me.TxtUsuario.Select()
        Me.TxtUsuario.Focus()

        'Habilito el boton de  aceptar
        BtnAceptar.Enabled = False

        'LIMPIO LOS CAMPOS
        Me.TxtUsuario.Text = ""
        Me.TxtClave.Text = ""

        Refresh()

    End Sub


#Region "EVENTOS KEYPRESS"

    'creamos la validacion de la tecla ENTER entre cada caja de texto en usuario
    Private Sub TxtUsuario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'creamos la validacion de la tecla ENTER entre cada caja de texto en password
    Private Sub TxtClave_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClave.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'habilitar el boton aceptar cuando valide el texto en usuario
    Private Sub TxtUsuario_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtUsuario.TextChanged
        BtnAceptar.Enabled = TxtUsuario.Text <> "" And TxtClave.Text <> ""
    End Sub

    'habilitar el boton aceptar cuando valide el texto en usuario
    Private Sub TxtClave_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtClave.TextChanged
        BtnAceptar.Enabled = TxtUsuario.Text <> "" And TxtClave.Text <> ""
    End Sub

#End Region

#Region "BOTONES DEL FORMULARIO"

    'Eventos del boton aceptar
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If TxtUsuario.Text = "" And TxtClave.Text = "" Then
            MessageBox.Show("Debe Ingresar un Usuario", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TxtUsuario.Clear()
            Me.TxtClave.Clear()
            Me.GroupBox1.Select()
            Me.TxtUsuario.Select()
            Me.TxtUsuario.Focus()
        ElseIf TxtUsuario.Text = "jucef" And TxtClave.Text = "@maria2015" Then
            FrmCambioNit.ShowDialog()
            Me.Close()
        Else
            MessageBox.Show("Usuario o Clave incorrecta", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TxtUsuario.Clear()
            Me.TxtClave.Clear()
            Me.GroupBox1.Select()
            Me.TxtUsuario.Select()
            Me.TxtUsuario.Focus()
        End If
    End Sub

    'BOTON DE CERRA FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    'LIMPIAR CAMPOS
    Private Sub Limpiacampos()
        Me.TxtUsuario.Text = ""
        Me.TxtClave.Text = ""
        'ubico el cursor
        Me.GroupBox1.Select()
        Me.GroupBox1.Focus()
        Me.TxtUsuario.Focus()
    End Sub

#End Region




End Class