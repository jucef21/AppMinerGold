Imports System.Data.OleDb

Public Class FrmPermisoEliPlatino

    Dim conn As New OleDb.OleDbConnection
    '====================================
    Dim comandos As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter
    Dim lector As OleDbDataReader
    Dim consulta As String

    Private Sub FrmPermisoEliPlatino_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Me.TxtNomPaciente.Enabled = True
        Me.PasswordTextBox.Enabled = True

        Me.GroupBox1.Select()
        Me.GroupBox1.Focus()
        Me.UsernameTextBox.Select()
        Me.UsernameTextBox.Focus()

        OK.Enabled = False

        Me.UsernameTextBox.Text = ""
        Me.PasswordTextBox.Text = ""

        Refresh()

    End Sub

#Region "EVENTOS KEYPRESS"

    Private Sub UsernameTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles UsernameTextBox.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub PasswordTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub UsernameTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles UsernameTextBox.TextChanged
        OK.Enabled = UsernameTextBox.Text <> "" And PasswordTextBox.Text <> ""
    End Sub

    Private Sub PasswordTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles PasswordTextBox.TextChanged
        OK.Enabled = UsernameTextBox.Text <> "" And PasswordTextBox.Text <> ""
    End Sub

#End Region

#Region "BOTONES DEL FORMULARIO"

    Dim contador As Integer = 0
    Dim cantidadIntentos As Integer = 3
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Refresh()

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Dim ConnString As String = cs
        conn.ConnectionString = cs
        Conectar.conn.Open()

        Try
            Dim Empr As Integer = 1
            If UsuarioRegistrado(UsernameTextBox.Text) = True Then
                Dim contra As String = Clave(UsernameTextBox.Text)
                Dim ClaveDescrip As String
                Encripta(PasswordTextBox.Text) : ClaveDescrip = ResultadoENCRIP
                If contra.Equals(ResultadoENCRIP) = True Then
                    If ConsultarTipoUsuario(UsernameTextBox.Text) = 1 Then
                        contador = 0 'El contador vuelve a 0
                        GrabaIngresoCajaEliminar()
                        FrmBuscaEliminaComprasPlatino.ShowDialog()
                        Me.Close()
                    Else
                        MessageBox.Show("El Usuario: " + UsernameTextBox.Text + " No tiene permiso para ingresar, Consulte al Administrador.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Conectar.conn.Close()
                        Me.UsernameTextBox.Clear()
                        Me.PasswordTextBox.Clear()
                        Me.GroupBox1.Select()
                        Me.UsernameTextBox.Select()
                        Me.UsernameTextBox.Focus()
                        Refresh()
                    End If
                    Me.UsernameTextBox.Clear()
                    Me.PasswordTextBox.Clear()

                    Me.GroupBox1.Select()
                    Me.UsernameTextBox.Select()
                    Me.UsernameTextBox.Focus()
                Else
                    MessageBox.Show("La Contraseña Digitada es Invalida", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Conectar.conn.Close()
        Refresh()
    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    Private Sub Limpiacampos()
        Me.UsernameTextBox.Text = ""
        Me.PasswordTextBox.Text = ""

        Me.GroupBox1.Select()
        Me.GroupBox1.Focus()
        Me.UsernameTextBox.Select()
        Me.UsernameTextBox.Focus()
    End Sub

    Private Sub GrabaIngresoCajaEliminar()
        Dim comandos As New OleDb.OleDbCommand
        Dim sqlBusca As String

        Dim fechaC As Date = CDate(Format(Date.Now.Date))
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        Dim fechaCA As Date = CDate(Format(Date.Now.ToLocalTime))

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Try
            conn.Open()

            sqlBusca = "SELECT * FROM RegistroCajaElimina"
            comandos.Connection = conn
            comandos.CommandText = sqlBusca

            cmd.Parameters.Clear()
            comandos.Parameters.AddWithValue("?fechaIngreso", fechaCA)
            comandos.Parameters.AddWithValue("?usuarioIngreso", Me.UsernameTextBox.Text)
            comandos.Parameters.AddWithValue("?fecha_creado", fechaC)
            comandos.Parameters.AddWithValue("?fecha_modifica", fechaM)

            comandos.CommandText = "INSERT INTO RegistroCajaElimina(fechaIngreso, usuarioIngreso, fecha_creado, fecha_modifica) VALUES ('" & fechaCA & "','" & UsernameTextBox.Text & "','" & fechaC & "', '" & fechaM & "')"
            comandos.ExecuteNonQuery()

            conn.Close()
        Catch ex As Exception
            MsgBox("Error al Guardar Ingreso de Caja Menor.! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
            conn.Close()
        End Try
        conn.Close()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

End Class