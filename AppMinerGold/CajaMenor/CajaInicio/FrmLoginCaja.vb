Imports System.Data.OleDb

Public Class FrmLoginCaja

    'representa conexion abierta a una base de datos
    Dim conn As New OleDb.OleDbConnection
    '====================================
    Dim comandos As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter
    Dim lector As OleDbDataReader
    Dim consulta As String

    'CARGUE DEL Formulario de Ingreso
    Private Sub FrmLoginCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'CIERRO LA BASE DE DATOS
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'LLENAMOS LOS DATOS DEL ENCABEZADO DEL CLIENTE - PANEL 1
        'colocamos los texbox en no editable
        Me.TxtNomPaciente.Enabled = True
        Me.PasswordTextBox.Enabled = True

        'UBICO EL CURSOR
        Me.GroupBox1.Select()
        Me.GroupBox1.Focus()
        Me.UsernameTextBox.Select()
        Me.UsernameTextBox.Focus()

        'Habilito el boton de  aceptar
        OK.Enabled = False

        'LIMPIO LOS CAMPOS
        Me.UsernameTextBox.Text = ""
        Me.PasswordTextBox.Text = ""

        Refresh()

    End Sub


#Region "EVENTOS KEYPRESS"

    'creamos la validacion de la tecla ENTER entre cada caja de texto en usuario
    Private Sub UsernameTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles UsernameTextBox.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'creamos la validacion de la tecla ENTER entre cada caja de texto en password
    Private Sub PasswordTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'habilitar el boton aceptar cuando valide el texto en usuario
    Private Sub UsernameTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles UsernameTextBox.TextChanged
        OK.Enabled = UsernameTextBox.Text <> "" And PasswordTextBox.Text <> ""
    End Sub

    'habilitar el boton aceptar cuando valide el texto en usuario
    Private Sub PasswordTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles PasswordTextBox.TextChanged
        OK.Enabled = UsernameTextBox.Text <> "" And PasswordTextBox.Text <> ""
    End Sub

#End Region

#Region "BOTONES DEL FORMULARIO"

    'Eventos del boton aceptar
    Dim contador As Integer = 0
    Dim cantidadIntentos As Integer = 3
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'refresco el formulario
        Refresh()

        'CONECTO LA BASE DE DATOS
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Dim ConnString As String = cs
        conn.ConnectionString = cs
        Conectarse()
        Try
            Dim Empr As Integer = 1
            If UsuarioRegistrado(UsernameTextBox.Text) = True Then
                Dim contra As String = Clave(UsernameTextBox.Text)
                Dim ClaveDescrip As String
                Encripta(PasswordTextBox.Text) : ClaveDescrip = ResultadoENCRIP
                If contra.Equals(ResultadoENCRIP) = True Then
                    If ConsultarTipoUsuario(UsernameTextBox.Text) = 1 Or ConsultarTipoUsuario(UsernameTextBox.Text) = 3 Then
                        contador = 0 'El contador vuelve a 0
                        GrabaIngresoCajaMenor()
                        FrmCajaMenu.ShowDialog()
                        Me.Close()
                    Else
                        MsgBox("El Usuario: " + UsernameTextBox.Text + " No tiene permiso para ingresar al control de caja Actual", MsgBoxStyle.Critical, "AppMinerGold")
                        Conectar.conn.Close()
                        Limpiacampos()
                        Refresh()
                    End If
                    Limpiacampos()
                    Me.UsernameTextBox.Clear()
                    Me.PasswordTextBox.Clear()
                    Me.GroupBox1.Select()
                    Me.UsernameTextBox.Select()
                    Me.UsernameTextBox.Focus()
                Else
                    MsgBox("La Contraseña Digitada es Invalida", MsgBoxStyle.Critical, "AppMinerGold")
                    Limpiacampos()
                    Conectar.conn.Close()
                    Me.UsernameTextBox.Clear()
                    Me.PasswordTextBox.Clear()
                    Me.GroupBox1.Select()
                    Me.UsernameTextBox.Select()
                    Me.UsernameTextBox.Focus()
                    Refresh()
                End If
            Else
                MsgBox("El Usuario: " + UsernameTextBox.Text + " No se encuentra registrado", MsgBoxStyle.Critical, "AppMinerGold")
                Limpiacampos()
                Conectar.conn.Close()
                Me.UsernameTextBox.Clear()
                Me.PasswordTextBox.Clear()

                Me.GroupBox1.Select()
                Me.UsernameTextBox.Select()
                Me.UsernameTextBox.Focus()
                Refresh()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Conectar.conn.Close()
            Me.UsernameTextBox.Clear()
            Me.PasswordTextBox.Clear()

            Me.GroupBox1.Select()
            Me.UsernameTextBox.Select()
            Me.UsernameTextBox.Focus()
            Refresh()
        End Try
        conn.Close()
        Refresh()
    End Sub

    'BOTON DE CERRA FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    'LIMPIAR CAMPOS
    Private Sub Limpiacampos()
        Me.UsernameTextBox.Text = ""
        Me.PasswordTextBox.Text = ""
        'ubico el cursor
        Me.GroupBox1.Select()
        Me.GroupBox1.Focus()
        Me.UsernameTextBox.Focus()
    End Sub

    'FUNCION PARA GRABAR EL INGRESO AL SISTEMA DEL USUARIO
    Private Sub GrabaIngresoCajaMenor()
        Dim comandos As New OleDb.OleDbCommand
        Dim sqlBusca As String

        'variables de fecha de auditoria
        Dim fechaC As Date = CDate(Format(Date.Now.Date))
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        Dim fechaCA As Date = CDate(Format(Date.Now.ToLocalTime))

        'CONECTO LA BASE DE DATOS
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        'Dim ConnString As String = cs
        'conn.ConnectionString = cs
        'Conectarse()
        Try
            conn.Open()
            'hacemos la consulta
            sqlBusca = "SELECT * FROM RegistroCajaMenorAse1"
            comandos.Connection = conn
            comandos.CommandText = sqlBusca

            'procedemos a pasar los datos de los textos a las variable para guardar
            cmd.Parameters.Clear()
            comandos.Parameters.AddWithValue("?fechaIngreso", fechaCA)
            comandos.Parameters.AddWithValue("?usuarioIngreso", Me.UsernameTextBox.Text)
            comandos.Parameters.AddWithValue("?fecha_creado", fechaC)
            comandos.Parameters.AddWithValue("?fecha_modifica", fechaM)

            'hacemos la consulta Insert para añadir un registro en la base de datos
            comandos.CommandText = "INSERT INTO RegistroCajaMenorAse1(fechaIngreso, usuarioIngreso, fecha_creado, fecha_modifica) VALUES ('" & fechaCA & "','" & UsernameTextBox.Text & "','" & fechaC & "', '" & fechaM & "')"

            'para ejecutar la consulta
            comandos.ExecuteNonQuery()

            ''muestro el mensaje de guardar
            'MsgBox("Registro Guardado con Éxito.! ", MsgBoxStyle.Information, "AppMinerGold")
            conn.Close()
        Catch ex As Exception
            MsgBox("Error al Guardar Ingreso de Caja Menor.! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
            conn.Close()
        End Try
        conn.Close()
    End Sub



#End Region

End Class
