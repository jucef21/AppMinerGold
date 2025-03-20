Option Explicit On
Option Strict On
Imports System.Data.OleDb

Public Class FrmTipoOperacion

    Private strConexion As OleDb.OleDbConnection
    Private DS_CA As DataSet
    Private DA_CA As OleDbDataAdapter
    Private Posicion_CA As Integer

    'CARGUE DEL FORMULARIO
    Private Sub FrmTipoOperacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'llamo la conexion
        ConectarDatos()

        'limpio el formulario
        Limpiar_Todos()

        'habilitamos los botones 
        Me.BtnNuevo.Visible = True
        Me.BtnNuevo.Enabled = True
        Me.BtnEditar.Visible = True
        Me.BtnEditar.Enabled = True
        Me.BtnEliminar.Visible = True
        Me.BtnEliminar.Enabled = True

        'botones desactivados
        Me.BtnGuardar.Visible = False
        Me.BtnGuardar.Enabled = False
        Me.BtnGuardaCambios.Visible = False
        Me.BtnGuardaCambios.Enabled = False
        Me.BtnCancelar.Visible = False
        Me.BtnCancelar.Enabled = False

        'botones de navegacion activados
        Me.BtnInicio.Enabled = True
        Me.BtnAnterior.Enabled = True
        Me.BtnSiguiente.Enabled = True
        Me.BtnFin.Enabled = True

        'campos deshabilitados
        Me.TxtIdCategoria.Enabled = False
        Me.TxtNomTipo.Enabled = False
        Me.TxtCodiTipo.Enabled = False

        'cargar los datos de la base de datos
        Me.CargarDatosHorario()

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON NUEVO 
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click

        'limpiamos los campos
        Limpiar_Todos()

        'habilitamos los botones 
        Me.BtnGuardar.Visible = True
        Me.BtnGuardar.Enabled = True
        Me.BtnCancelar.Visible = True
        Me.BtnCancelar.Enabled = True

        'desactivo los botones
        Me.BtnNuevo.Visible = False
        Me.BtnNuevo.Enabled = False
        Me.BtnEditar.Visible = True
        Me.BtnEditar.Enabled = False
        Me.BtnGuardaCambios.Visible = False
        Me.BtnGuardaCambios.Enabled = False
        Me.BtnEliminar.Visible = False
        Me.BtnEliminar.Enabled = False

        'campos de navegacion desactivados
        Me.BtnInicio.Enabled = False
        Me.BtnAnterior.Enabled = False
        Me.BtnSiguiente.Enabled = False
        Me.BtnFin.Enabled = False

        'campos DEShabilitados
        Me.TxtIdCategoria.Enabled = False

        'campos habilitados
        Me.TxtNomTipo.Enabled = True
        Me.TxtCodiTipo.Enabled = True

        'posiciona el cursor en el campo deseado
        Me.TxtNomTipo.Select()
        Me.TxtNomTipo.Focus()

    End Sub

    'BOTON GUARDAR
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Me.TxtNomTipo.Text = "" Or Me.TxtCodiTipo.Text = "" Then
            MessageBox.Show("El Campo Nombre no debe estar Vacío", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtNomTipo.Select()
            Me.TxtNomTipo.Focus()
        Else
            Guardar()

            'cerramos el formulario
            Limpiar_Todos()

            'posicionamos en cursor
            Me.TxtNomTipo.Focus()

            'llamo la conexion de datos
            ConectarDatos()

            'habilitamos los botones 
            Me.BtnNuevo.Visible = True
            Me.BtnNuevo.Enabled = True
            Me.BtnEditar.Visible = True
            Me.BtnEditar.Enabled = True
            Me.BtnEliminar.Visible = True
            Me.BtnEliminar.Enabled = True

            'botones desactivados
            Me.BtnGuardar.Visible = False
            Me.BtnGuardar.Enabled = False
            Me.BtnGuardaCambios.Visible = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnCancelar.Visible = False
            Me.BtnCancelar.Enabled = False

            'botones de navegacion activados
            Me.BtnInicio.Enabled = True
            Me.BtnAnterior.Enabled = True
            Me.BtnSiguiente.Enabled = True
            Me.BtnFin.Enabled = True

            'campos deshabilitados
            Me.TxtIdCategoria.Enabled = False
            Me.TxtNomTipo.Enabled = False
            Me.TxtCodiTipo.Enabled = False

            'cargar los datos de la base de datos
            Me.CargarDatosHorario()

        End If

    End Sub

    'BOTON CANCELAR
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click

        'limpia los campos
        Limpiar_Todos()

        'ubico el cursor
        Me.TxtNomTipo.Select()
        Me.TxtNomTipo.Focus()

        'valido los campos
        ValidaDatosVacios()

    End Sub

    'boton editar MODIFICAR
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click

        'campos deshabilitados
        Me.TxtIdCategoria.Enabled = False

        'campos habilitados
        Me.TxtNomTipo.Enabled = True
        Me.TxtCodiTipo.Enabled = True

        'habilitamos los botones 
        Me.BtnGuardaCambios.Visible = True
        Me.BtnGuardaCambios.Enabled = True
        Me.BtnCancelar.Visible = True
        Me.BtnCancelar.Enabled = True

        'deshabilitamos los botones 
        Me.BtnNuevo.Visible = True
        Me.BtnNuevo.Enabled = False
        Me.BtnGuardar.Visible = False
        Me.BtnGuardar.Enabled = False
        Me.BtnEditar.Enabled = False
        Me.BtnEditar.Visible = False
        Me.BtnEliminar.Visible = False
        Me.BtnEliminar.Enabled = False

        'botones de navegacion activados
        Me.BtnInicio.Enabled = False
        Me.BtnAnterior.Enabled = False
        Me.BtnSiguiente.Enabled = False
        Me.BtnFin.Enabled = False

        'ubico el cursor
        Me.TxtNomTipo.Select()
        Me.TxtNomTipo.Focus()

    End Sub

    'boton Guarda CAMBIOS DE MODIFICAR
    Private Sub BtnGuardaCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardaCambios.Click

        Dim fechaM As Date
        fechaM = CDate(Format(Date.Now.Date))

        Dim cmd As New OleDb.OleDbCommand

        'revisamos la conexin a la base de datos
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        'valida campos vacios
        ValidaDatosVacios()

        Try
            Dim sqlConsulta As String = "UPDATE TipoOperacion SET Detalle_op = '" & TxtNomTipo.Text & "', " &
                                                    "codigo_op = '" & TxtCodiTipo.Text & "', " &
                                                    "fecha_modifica='" & fechaM & "' WHERE Detalle_op = '" & TxtNomTipo.Text & "'"

            cmd = New OleDb.OleDbCommand(sqlConsulta, conn)

            'ejecutamos la consulta
            cmd.ExecuteNonQuery()

            'CIERRO LA CONEXION
            conn.Close()

            'presentamos el mensaje 
            MessageBox.Show("Registro actualizado exitosamente", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'cerramos el formulario
            Limpiar_Todos()

            'posicionamos en cursor
            Me.TxtNomTipo.Select()
            Me.TxtNomTipo.Focus()

            'llamo la conexion de datos
            ConectarDatos()

            'habilitamos los botones 
            Me.BtnNuevo.Visible = True
            Me.BtnNuevo.Enabled = True
            Me.BtnEditar.Visible = True
            Me.BtnEditar.Enabled = True
            Me.BtnEliminar.Visible = True
            Me.BtnEliminar.Enabled = True

            'botones desactivados
            Me.BtnGuardar.Visible = False
            Me.BtnGuardar.Enabled = False
            Me.BtnGuardaCambios.Visible = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnCancelar.Visible = False
            Me.BtnCancelar.Enabled = False

            'botones de navegacion activados
            Me.BtnInicio.Enabled = True
            Me.BtnAnterior.Enabled = True
            Me.BtnSiguiente.Enabled = True
            Me.BtnFin.Enabled = True

            'campos deshabilitados
            Me.TxtIdCategoria.Enabled = False
            Me.TxtNomTipo.Enabled = False
            Me.TxtCodiTipo.Enabled = False

            'cargar los datos de la base de datos
            Me.CargarDatosHorario()

        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Exclamation, "AppMinerGold")
        End Try

    End Sub

    'BOTON ELIMINAR
    Dim comand As New OleDb.OleDbCommand
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim respuesta As Byte
        Dim adaptador As New OleDb.OleDbDataAdapter
        Dim registros As New DataSet
        Try
            'revisamos conexion
            If conn.State() = ConnectionState.Closed Then
                conn.Open()
            End If
            'hacemos la consulta
            respuesta = CByte(MsgBox("¿Esta seguro de Eliminar este Registro?", MsgBoxStyle.YesNo, "AppMinerGold"))
            'verificamos la respuesta
            If respuesta = vbYes Then

                'creo la conexion
                Dim ConnString As String = cs

                'Genero la consulta a  la base de datos
                Dim SqlString As String = "DELETE FROM TipoOperacion WHERE detalle_op = '" & TxtNomTipo.Text & "' "
                comand = New OleDbCommand(SqlString, conn)

                'ejecuto la consulta
                comand.ExecuteNonQuery()

                'cierro la conexion
                conn.Close()

                'muestro el mensaje de la consulta
                MessageBox.Show("Usuario eliminado con exito de la base de datos!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'cerramos el formulario
                Limpiar_Todos()

                'posicionamos en cursor
                Me.TxtNomTipo.Select()
                Me.TxtNomTipo.Focus()

                'llamo la conexion de datos
                ConectarDatos()

                'habilitamos los botones 
                Me.BtnNuevo.Visible = True
                Me.BtnNuevo.Enabled = True
                Me.BtnEditar.Visible = True
                Me.BtnEditar.Enabled = True
                Me.BtnEliminar.Visible = True
                Me.BtnEliminar.Enabled = True

                'botones desactivados
                Me.BtnGuardar.Visible = False
                Me.BtnGuardar.Enabled = False
                Me.BtnGuardaCambios.Visible = False
                Me.BtnGuardaCambios.Enabled = False
                Me.BtnCancelar.Visible = False
                Me.BtnCancelar.Enabled = False

                'botones de navegacion activados
                Me.BtnInicio.Enabled = True
                Me.BtnAnterior.Enabled = True
                Me.BtnSiguiente.Enabled = True
                Me.BtnFin.Enabled = True

                'campos deshabilitados
                Me.TxtIdCategoria.Enabled = False
                Me.TxtNomTipo.Enabled = False
                Me.TxtCodiTipo.Enabled = False

                'cargar los datos de la base de datos
                Me.CargarDatosHorario()

            Else

                'muestro el mensaje de la consulta
                MessageBox.Show("Usuario No se elimino de la base de datos!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'cerramos el formulario
                Limpiar_Todos()

                'posicionamos en cursor
                Me.TxtNomTipo.Select()
                Me.TxtNomTipo.Focus()

                'llamo la conexion de datos
                ConectarDatos()

                'habilitamos los botones 
                Me.BtnNuevo.Visible = True
                Me.BtnNuevo.Enabled = True
                Me.BtnEditar.Visible = True
                Me.BtnEditar.Enabled = True
                Me.BtnEliminar.Visible = True
                Me.BtnEliminar.Enabled = True

                'botones desactivados
                Me.BtnGuardar.Visible = False
                Me.BtnGuardar.Enabled = False
                Me.BtnGuardaCambios.Visible = False
                Me.BtnGuardaCambios.Enabled = False
                Me.BtnCancelar.Visible = False
                Me.BtnCancelar.Enabled = False

                'botones de navegacion activados
                Me.BtnInicio.Enabled = True
                Me.BtnAnterior.Enabled = True
                Me.BtnSiguiente.Enabled = True
                Me.BtnFin.Enabled = True

                'campos deshabilitados
                Me.TxtIdCategoria.Enabled = False
                Me.TxtNomTipo.Enabled = False
                Me.TxtCodiTipo.Enabled = False

                'cargar los datos de la base de datos
                Me.CargarDatosHorario()

            End If

        Catch ex As Exception

            MsgBox("Imposible Eliminar porque...:" & ex.Message)
            'limpiamos los campos
            Limpiar_Todos()

            'posicionamos el cursor
            Me.TxtNomTipo.Focus()

        End Try

    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "Botones de navegación"

    'Boton Inicio
    Private Sub BtnInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInicio.Click

        'establece el contadpr en el primer registro
        Me.Posicion_CA = 0

        'carga los datos al formulario
        Me.CargarDatosHorario()

    End Sub

    'boton anterior
    Private Sub BtnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnterior.Click
        'si estamos en el primer registro no hace moviemiento
        If Me.Posicion_CA = 0 Then
            MessageBox.Show("Primer Registro", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'disminuir el marcador del registro y actualizar los controles con los datos de registro actual
            Me.Posicion_CA -= 1
            'carga los datos al formulario
            Me.CargarDatosHorario()
        End If

    End Sub

    'boton siguiente
    Private Sub BtnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSiguiente.Click
        'si estamos en el ultimo registro no hacer actual
        If Posicion_CA =
            (Me.DS_CA.Tables("TipoOperacion").Rows.Count - 1) Then
            MessageBox.Show("Último Registro", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'incrementar el marcador de registro y actualizar controles con los datos de registro actual
            Me.Posicion_CA += 1
            'carga los datos al formulario
            Me.CargarDatosHorario()
        End If

    End Sub

    'boton final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        'establecer el marcador de registros en el primero obteniendo el numero de filas que contiene la tabla menos uno
        Me.Posicion_CA = (Me.DS_CA.Tables("TipoOperacion").Rows.Count - 1)
        'carga los datos al formulario
        Me.CargarDatosHorario()

    End Sub

#End Region

#Region "Validaciones"

    'PROCEDIMIENTO PARA CONECTAR LOS DATOS AL FORMULARIO
    Private Sub ConectarDatos()
        'revisamos la conexin a la base de datos
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim strConexion As OleDb.OleDbConnection
        strConexion = New OleDb.OleDbConnection With {
            .ConnectionString = cs
        }
        Me.DA_CA = New OleDbDataAdapter("SELECT * FROM TipoOperacion", conn)
        Dim consulta As OleDbCommandBuilder = New OleDbCommandBuilder(DA_CA)
        Me.DS_CA = New DataSet
        Me.DA_CA.Fill(DS_CA, "TipoOperacion")
        conn.Close()
        Me.Posicion_CA = 0
    End Sub

    'procedimiento GUARDAR DATOS
    Private Sub Guardar()
        Dim cmd As New OleDb.OleDbCommand
        Dim sqlquery As String

        'variable de fecha de auditoria
        Dim fechaC As Date = CDate(Format(Date.Now.Date))
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        'revisamos la conexion a la base de datos
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        'ejecutamos las consultas
        Try
            sqlquery = "SELECT * FROM TipoOperacion"
            cmd.Connection = conn
            cmd.CommandText = sqlquery
            '---------------------------------------------------------------------------------------------------------------------------                
            'procedo a pasar los datos de los textbox a la variable para guardar
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("?detalle_op", Me.TxtNomTipo.Text)
            cmd.Parameters.AddWithValue("?codigo_op", Me.TxtCodiTipo.Text)
            cmd.Parameters.AddWithValue("?fecha_creado", Date.Now)
            cmd.Parameters.AddWithValue("?fecha_modifica", Date.Now)

            cmd.CommandText = "INSERT INTO TipoOperacion(detalle_op, codigo_op, fecha_creado, fecha_modifica) VALUES ( '" & TxtNomTipo.Text & "', '" & TxtCodiTipo.Text & "', '" & fechaC & "', '" & fechaM & "')"

            cmd.ExecuteNonQuery()

            'cierro el procedimiento
            conn.Close()

            MessageBox.Show("Los datos se han guardado Correctamente! ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("No es posible Guardar, Verifique! " & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    'PROCEDIMIENTO LIMPIAR CAMPOS
    Private Sub Limpiar_Todos()

        'campos LIMPIOS
        Me.TxtIdCategoria.Clear()
        Me.TxtNomTipo.Clear()
        Me.TxtCodiTipo.Clear()
        'ubicar campo de texto
        Me.TxtNomTipo.Select()
        Me.TxtNomTipo.Focus()

    End Sub

    'CARGA DATOS DE LOS BOTONES DE NAVEGACION
    Private Sub CargarDatosHorario()

        'obtener un objeto con la fila actual
        Dim Drow As DataRow
        Drow = Me.DS_CA.Tables("TipoOperacion").Rows(Me.Posicion_CA)

        'cargar los controles del formulario con valores de los camapos del registro
        Me.TxtIdCategoria.Text = CStr(Drow("Id"))
        Me.TxtNomTipo.Text = CStr(Drow("detalle_op"))
        Me.TxtCodiTipo.Text = CStr(Drow("codigo_op"))

        'mostrar la posicion actual del registro y el numero de registros
        Me.LblRegistros.Text = "Registro No.: " &
        Me.Posicion_CA + 1 & " de " &
        Me.DS_CA.Tables("TipoOperacion").Rows.Count

    End Sub

    'valida todos los campos no pueden estar vacios
    Private Function ValidaDatosVacios() As Boolean
        'paciente
        If Len(Me.TxtNomTipo.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtNomTipo.Focus() : Return True : Exit Function
        If Len(Me.TxtCodiTipo.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtCodiTipo.Focus() : Return True : Exit Function
        Return True
    End Function

#End Region


#Region "EVENTO KEYPRESS"

    'activar los campos textbox con Enter
    Private Sub FrmTipoOperacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'VALIDA SOLO NUMEROS
    Private Sub TxtCodiTipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCodiTipo.KeyPress
        SoloNumeros(e)
    End Sub

#End Region



End Class
