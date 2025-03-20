Imports System.Data.OleDb

Public Class FrmCambioName

    'CARGUE DEL FORMULARIO
    Private Sub FrmCambioName_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'colocamos los texbox en no editable
        Me.Txtced_cl.Enabled = False
        Me.TxtNomApe.Enabled = False

        'llenamos los datos con la informacion seleccionada
        Me.Txtced_cl.Text = ModuleFrm.Cedula
        Me.TxtName.Text = ModuleFrm.Nombre
        Me.TxtSurName.Text = ModuleFrm.Apellido

        'llamo el  preocedimeinto de CONCATENAR 
        UnirNombres()

        'muestro el resultado y los concateno
        Me.TxtNomApe.Text = Me.TxtName.Text & " " & Me.TxtSurName.Text

        'ubico el cursor
        Me.Panel1.Select()
        Me.TxtNuevoNombre.Select()
        Me.TxtNuevoNombre.Focus()

    End Sub

    'PROCEDIMIENTO PARA UNIR NOMBRE Y APELLIDO DEL CLIENTE
    Private Sub UnirNombres()
        Dim dt As New DataTable
        Dim NomCedCambio As Integer = CInt(Txtced_cl.Text)

        'revisamos la conexin a la base de datos
        If Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            Conectar.conn.Close()
        End If

        Conectar.conn.ConnectionString = cs
        Dim consulta As String = "SELECT * FROM Clientes WHERE ced_cl = " & NomCedCambio ''" & Txtced_cl.Text & "' "
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)
        Dim drd As OleDbDataReader
        Conectar.conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            Me.TxtName.Text = drd.Item("nom_cl").ToString
            Me.TxtSurName.Text = drd.Item("ape_cl").ToString
        Else
            MsgBox("No se encontro NOMBRES", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
        Conectar.conn.Close()
    End Sub

    'BOTON DE CAMBIAR DATOS
    Private Sub BtnCambiar_Click(sender As Object, e As EventArgs) Handles BtnCambiar.Click
        Try
            If TxtNuevoNombre.Text = "" Then
                MessageBox.Show("Para hacer un Cambio debe Digitar un Nombre Completo! ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Panel1.Select()
                Me.TxtNuevoNombre.Select()
                Me.TxtNuevoNombre.Focus()
            Else
                CambiaDeclara()
                'CambiaEmpresaUno()
                'presentamos el mensaje 
                MessageBox.Show("Cambios Actualizados exitosamente, en Compras, Continue el cambio de nombre en el formulario de 'Proveedores'", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'limpio los textbox
                Me.TxtNuevoNombre.Enabled = False
                Me.TxtNuevoNombre.Clear()
                Me.Txtced_cl.Clear()
                Me.TxtNomApe.Clear()
                'INHABILITO BOTON
                Me.BtnCambiar.Enabled = False
                'HABILITO BOTON
            End If
        Catch ex As Exception
            'mensaje de error del procedimiento
            MessageBox.Show("Error al Modificar el Nombre en las Tablas: " & Err.Description, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'PROCESO PARA CAMBIAR NOMBRE EN LA TABLA DECLARA
    Private Sub CambiaDeclara()
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        Dim NumCedu As Integer = CInt(Txtced_cl.Text)
        Try
            Dim SqlCambiaD As String = "UPDATE Declara Set nom_com = '" & TxtNuevoNombre.Text & "' WHERE cedu_com = " & NumCedu
            cmd = New OleDb.OleDbCommand(SqlCambiaD, conn)
            conn.Open()
            'ejecutamos la consulta
            cmd.ExecuteNonQuery()
            'cierro conexion
            conn.Close()
        Catch ex As Exception
            'mensaje de error del procedimiento
            MessageBox.Show("Error al Modificar el Nombre en Tabla 1: " & Err.Description, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'PROCESO PARA CAMBIAR NOMBRE EN LA TABLA EMPRESA1CLIENTE
    Private Sub CambiaEmpresaUno()
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        Dim NumCeduE As Integer = CInt(Txtced_cl.Text)
        Try
            Dim SqlCambiaN As String = "UPDATE Empresa1Cliente Set nomem = '" & TxtNuevoNombre.Text & "' WHERE ceduem = " & NumCeduE   ''" & NumCeduE & "' "
            cmd = New OleDb.OleDbCommand(SqlCambiaN, conn)
            conn.Open()
            'ejecutamos la consulta
            cmd.ExecuteNonQuery()
            'cierro conexion
            conn.Close()
        Catch ex As Exception
            'mensaje de error del procedimiento
            MsgBox("Error al Modificar el Nombre en Tabla 2: " & Err.Description)
        End Try
    End Sub

    'CAMBIA EL TEXTO A MAYUSCULAS
    Private Sub TxtNuevoNombre_TextChanged(sender As Object, e As EventArgs) Handles TxtNuevoNombre.TextChanged
        Me.TxtNuevoNombre.Text = UCase(Me.TxtNuevoNombre.Text)
        Me.TxtNuevoNombre.SelectionStart = Me.TxtNuevoNombre.TextLength + 1
    End Sub

    'CIERRO DEL FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class
