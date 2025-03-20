Imports System.Data.OleDb

Public Class FrmCambioNit

    'CARGUE DEL FORM
    Private Sub FrmCambioNit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.TxtNit.Enabled = False
        Me.TxtDigi.Enabled = False
        Me.TxtNit.Clear()
        Me.TxtDigi.Clear()

        Me.TxtNuevoNit.Enabled = True
        Me.TxtNuevoDigi.Enabled = True

        'UBICO EL CURSOR
        Me.Panel2.Select()
        Me.GroupBox2.Select()
        Me.TxtNuevoNit.Select()
        Me.TxtNuevoNit.Focus()

        'HABILITO LOS BOTONES
        Me.BtnAcepta.Enabled = True

        ValidaNit()

    End Sub

    'BOTON DE CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'BOTON DE ACEPTAR
    Private Sub BtnAcepta_Click(sender As Object, e As EventArgs) Handles BtnAcepta.Click
        ' Verifico que haya escrito el codigo
        If Me.TxtNuevoNit.Text = "" And TxtNuevoDigi.Text = "" Then
            'Si no lo escribió, mando mensaje de error
            MessageBox.Show("Debe ingresar un Nit Válido o Dígito Válido", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'ubico el cursor
            Me.Panel2.Select()
            Me.GroupBox2.Select()
            Me.TxtNuevoNit.Select()
            Me.TxtNuevoNit.Focus()
        Else
            AgregaNitNuevo()
        End If
    End Sub

    'BOTON DE CANCELAR
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        'LIMPIO LOS CAMPOS
        Me.TxtNit.Clear()
        Me.TxtDigi.Clear()
        Me.TxtNuevoNit.Clear()
        Me.TxtNuevoDigi.Clear()

        'HABILITO LOS CAMPOS
        Me.TxtNuevoNit.Enabled = True
        Me.TxtNuevoDigi.Enabled = True

        'UBICO EL CURSOR
        Me.Panel2.Select()
        Me.GroupBox2.Select()
        Me.TxtNuevoNit.Focus()
    End Sub

    'VALIDA SOLO NUMEROS
    Private Sub TxtNuevoNit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNuevoNit.KeyPress
        SoloNumeros(e)
    End Sub

    Private Sub TxtNuevoDigi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNuevoDigi.KeyPress
        SoloNumeros(e)
    End Sub

    'PROCESO PARA VALIDAR NIT
    Private Sub ValidaNit()
        Dim dt As New DataTable
        Dim num As String = "CAMBIO DE NIT"
        If Label8.Text = num Then
            Dim consulta As String = "SELECT * FROM Empresa"
            Dim cmd As New OleDbCommand(consulta, conn)
            Dim drd As OleDbDataReader
            conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TxtNit.Text = drd.Item("nit_empresa").ToString
                Me.TxtDigi.Text = drd.Item("dvempresa").ToString
            Else
                MessageBox.Show("No se Existen datos, comuniquese con al Administrador del Sistema.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            drd.Close()
            conn.Close()
        End If
    End Sub

    'PROCEDIMIENTO PARA AGREGAR NIT NUEVO A LA BASE
    Private Sub AgregaNitNuevo()
        Dim NumId As Integer = 1
        Dim Nomb As String = "Colombia"
        Try
            If TxtNuevoNit.Text = "" And TxtNuevoDigi.Text = "" Then
                ' Si no lo escribió, mando mensaje de error
                MessageBox.Show("Debe ingresar un Nit Válido", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'ubico el cursor
                Me.Panel2.Select()
                Me.GroupBox2.Select()
                Me.TxtNuevoNit.Select()
                Me.TxtNuevoNit.Focus()
            Else
                Dim sqlNit = "UPDATE Empresa SET nit_empresa = '" & TxtNuevoNit.Text & "', dvempresa = '" & TxtNuevoDigi.Text & "' WHERE id = " & NumId
                Dim cmd As New OleDbCommand(sqlNit, conn)
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
                MessageBox.Show("Registro actualizado exitosamente. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNit.Text = ""
                Me.TxtDigi.Text = ""
                Me.TxtNuevoNit.Text = ""
                Me.TxtNuevoDigi.Text = ""
                Me.TxtNuevoNit.Enabled = False
                Me.TxtNuevoDigi.Enabled = False
                Me.BtnAcepta.Enabled = False

                Me.BtnX.Enabled = True
                Me.BtnX.Select()
                Me.BtnX.Focus()
                Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al Modificar Datos. " + Err.Description, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.BtnAcepta.Enabled = True
            Me.BtnX.Enabled = True

            Me.TxtNuevoNit.Text = ""
            Me.TxtNuevoDigi.Text = ""

            Me.Panel2.Select()
            Me.GroupBox2.Select()
            Me.TxtNuevoNit.Select()
            Me.TxtNuevoNit.Focus()
            Refresh()
        End Try
    End Sub

End Class