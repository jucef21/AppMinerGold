Option Explicit On
Option Strict On
Imports System.Data.OleDb

Public Class FrmTiposUser
    Private strConexion As OleDb.OleDbConnection
    Private DS_PR As DataSet
    Private DA_PR As OleDbDataAdapter
    Private Posicion_PR As Integer

    'cargue del formulario
    Private Sub FrmProfesiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        Me.btnGuardar.Visible = False
        Me.btnGuardar.Enabled = False
        Me.btnGuardaCambios.Visible = False
        Me.btnGuardaCambios.Enabled = False
        Me.btnCancelar.Visible = False
        Me.btnCancelar.Enabled = False

        'botones de navegacion activados
        Me.BtnInicio.Enabled = True
        Me.BtnAnterior.Enabled = True
        Me.BtnSiguiente.Enabled = True
        Me.BtnFin.Enabled = True

        'campos deshabilitados
        Me.TxtIdCategoria.Enabled = False
        Me.TxtCategoria.Enabled = False
        Me.CboTipo.Enabled = False
        Me.TxtDescripcion.Enabled = False

        'cargar los datos de la base de datos
        Me.CargarDatosHorario()

        'conexion del combobox
        cargar_Combo(CboTipo, "Select DISTINCT tipo_user From tipo_user Order By tipo_user")


    End Sub

    'Cargar Combos
    Private Sub Cargar_Combo(ByVal Combobox As ComboBox, ByVal sql As String)
        ' nueva conexión indicando al SqlConnection la cadena de conexión   
        Dim cn As New OleDbConnection(cs)
        Try
            ' Abrir la conexión a Sql   
            cn.Open()
            ' Pasar la consulta sql y la conexión al Sql Command    
            Dim cmd As New OleDbCommand(sql, cn)
            ' Inicializar un nuevo SqlDataAdapter    
            Dim da As New OleDbDataAdapter(cmd)
            'Crear y Llenar un Dataset   
            Dim ds As New DataSet
            da.Fill(ds)
            ' asignar el DataSource al combobox   
            Combobox.DataSource = ds.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo    
            Combobox.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub


#Region "BOTONES DEL FORMULARIO"

    'BOTON NUEVO 
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click

        'limpiamos los campos
        Limpiar_Todos()

        'habilitamos los botones 
        Me.btnGuardar.Visible = True
        Me.btnGuardar.Enabled = True
        Me.btnCancelar.Visible = True
        Me.btnCancelar.Enabled = True

        'desactivo los botones
        Me.BtnNuevo.Visible = False
        Me.BtnNuevo.Enabled = False
        Me.BtnEditar.Visible = True
        Me.BtnEditar.Enabled = False
        Me.btnGuardaCambios.Visible = False
        Me.btnGuardaCambios.Enabled = False
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
        Me.TxtCategoria.Enabled = True
        Me.CboTipo.Enabled = True
        Me.TxtDescripcion.Enabled = True

        'posiciona el cursor en el campo deseado
        Me.TxtCategoria.Focus()

    End Sub

    'BOTON GUARDAR
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Me.TxtCategoria.Text = "" Or Me.TxtDescripcion.Text = "" Then
            MsgBox("El Campo Nombre no debe estar Vacío", MsgBoxStyle.Information, "Validación de Usuarios, AppMinerGold")
            Me.TxtCategoria.Focus()
        Else
            Guardar()

            'cerramos el formulario
            Limpiar_Todos()

            'posicionamos en cursor
            Me.TxtCategoria.Focus()

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
            Me.btnGuardar.Visible = False
            Me.btnGuardar.Enabled = False
            Me.btnGuardaCambios.Visible = False
            Me.btnGuardaCambios.Enabled = False
            Me.btnCancelar.Visible = False
            Me.btnCancelar.Enabled = False

            'botones de navegacion activados
            Me.BtnInicio.Enabled = True
            Me.BtnAnterior.Enabled = True
            Me.BtnSiguiente.Enabled = True
            Me.BtnFin.Enabled = True

            'campos deshabilitados
            Me.TxtIdCategoria.Enabled = False
            Me.TxtCategoria.Enabled = False
            Me.CboTipo.Enabled = False
            Me.TxtDescripcion.Enabled = False

            'cargar los datos de la base de datos
            Me.CargarDatosHorario()

        End If

    End Sub

    'BOTON CANCELAR
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        'limpia los campos
        Limpiar_Todos()

        'ubico el cursor
        Me.TxtCategoria.Focus()

        'valido los campos
        ValidaDatosVacios()

    End Sub

    'boton editar MODIFICAR
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click

        'campos deshabilitados
        Me.TxtIdCategoria.Enabled = False

        'campos habilitados
        Me.TxtCategoria.Enabled = True
        Me.CboTipo.Enabled = True
        Me.TxtDescripcion.Enabled = True

        'habilitamos los botones 
        Me.btnGuardaCambios.Visible = True
        Me.btnGuardaCambios.Enabled = True
        Me.btnCancelar.Visible = True
        Me.btnCancelar.Enabled = True

        'deshabilitamos los botones 
        Me.BtnNuevo.Visible = True
        Me.BtnNuevo.Enabled = False
        Me.btnGuardar.Visible = False
        Me.btnGuardar.Enabled = False
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
        Me.TxtCategoria.Focus()

    End Sub

    'boton Guarda CAMBIOS DE MODIFICAR
    Private Sub BtnGuardaCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardaCambios.Click

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
            Dim sqlConsulta As String = "UPDATE tipo_user SET Nom_tipo='" & TxtCategoria.Text & "', tipo_user='" & CboTipo.Text & "',Descripcion='" & TxtDescripcion.Text & "', fecha_modifica='" & fechaM & "' WHERE Nom_tipo='" & TxtCategoria.Text & "'"
            cmd = New OleDb.OleDbCommand(sqlConsulta, conn)

            'ejecutamos la consulta
            cmd.ExecuteNonQuery()

            'CIERRO LA CONEXION
            conn.Close()

            'presentamos el mensaje 
            MsgBox("Registro actualizado exitosamente", MsgBoxStyle.Information, "AppMinerGold")


            'cerramos el formulario
            Limpiar_Todos()

            'posicionamos en cursor
            Me.TxtCategoria.Focus()

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
            Me.btnGuardar.Visible = False
            Me.btnGuardar.Enabled = False
            Me.btnGuardaCambios.Visible = False
            Me.btnGuardaCambios.Enabled = False
            Me.btnCancelar.Visible = False
            Me.btnCancelar.Enabled = False

            'botones de navegacion activados
            Me.BtnInicio.Enabled = True
            Me.BtnAnterior.Enabled = True
            Me.BtnSiguiente.Enabled = True
            Me.BtnFin.Enabled = True

            'campos deshabilitados
            Me.TxtIdCategoria.Enabled = False
            Me.TxtCategoria.Enabled = False
            Me.CboTipo.Enabled = False
            Me.TxtDescripcion.Enabled = False

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
                'Dim ConnString As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Dbminero.accdb; Jet OLEDB:Database Password=@waleska2018;")
                Dim ConnString As String = cs

                'Genero la consulta a  la base de datos
                Dim SqlString As String = "Delete From tipo_user Where Nom_tipo= '" & TxtCategoria.Text & "' "
                comand = New OleDbCommand(SqlString, conn)

                'ejecuto la consulta
                comand.ExecuteNonQuery()

                'cierro la conexion
                conn.Close()

                'muestro el mensaje de la consulta
                MsgBox("Usuario eliminado con exito de la base de datos!", MsgBoxStyle.Information, "AppMinerGold")

                'cerramos el formulario
                Limpiar_Todos()

                'posicionamos en cursor
                Me.TxtCategoria.Focus()

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
                Me.btnGuardar.Visible = False
                Me.btnGuardar.Enabled = False
                Me.btnGuardaCambios.Visible = False
                Me.btnGuardaCambios.Enabled = False
                Me.btnCancelar.Visible = False
                Me.btnCancelar.Enabled = False

                'botones de navegacion activados
                Me.BtnInicio.Enabled = True
                Me.BtnAnterior.Enabled = True
                Me.BtnSiguiente.Enabled = True
                Me.BtnFin.Enabled = True

                'campos deshabilitados
                Me.TxtIdCategoria.Enabled = False
                Me.TxtCategoria.Enabled = False
                Me.CboTipo.Enabled = False
                Me.TxtDescripcion.Enabled = False

                'cargar los datos de la base de datos
                Me.CargarDatosHorario()

            Else

                'muestro el mensaje de la consulta
                MsgBox("Usuario No se elimino de la base de datos!", MsgBoxStyle.Information, "AppMinerGold")

                'cerramos el formulario
                Limpiar_Todos()

                'posicionamos en cursor
                Me.TxtCategoria.Focus()

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
                Me.btnGuardar.Visible = False
                Me.btnGuardar.Enabled = False
                Me.btnGuardaCambios.Visible = False
                Me.btnGuardaCambios.Enabled = False
                Me.btnCancelar.Visible = False
                Me.btnCancelar.Enabled = False

                'botones de navegacion activados
                Me.BtnInicio.Enabled = True
                Me.BtnAnterior.Enabled = True
                Me.BtnSiguiente.Enabled = True
                Me.BtnFin.Enabled = True

                'campos deshabilitados
                Me.TxtIdCategoria.Enabled = False
                Me.TxtCategoria.Enabled = False
                Me.CboTipo.Enabled = False
                Me.TxtDescripcion.Enabled = False

                'cargar los datos de la base de datos
                Me.CargarDatosHorario()

            End If

        Catch ex As Exception

            MsgBox("Imposible Eliminar porque...:" & ex.Message)
            'limpiamos los campos
            Limpiar_Todos()

            'posicionamos el cursor
            Me.TxtCategoria.Focus()

        End Try

    End Sub

#End Region

#Region "Botones de navegación"

    'Boton Inicio
    Private Sub BtnInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInicio.Click

        'establece el contadpr en el primer registro
        Me.Posicion_PR = 0

        'carga los datos al formulario
        Me.CargarDatosHorario()

    End Sub

    'boton anterior
    Private Sub BtnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnterior.Click
        'si estamos en el primer registro no hace moviemiento
        If Me.Posicion_PR = 0 Then
            MessageBox.Show("Primer Registro", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'disminuir el marcador del registro y actualizar los controles con los datos de registro actual
            Me.Posicion_PR -= 1
            'carga los datos al formulario
            Me.CargarDatosHorario()
        End If

    End Sub

    'boton siguiente
    Private Sub BtnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSiguiente.Click
        'si estamos en el ultimo registro no hacer actual
        If Posicion_PR =
            (Me.DS_PR.Tables("tipo_user").Rows.Count - 1) Then
            MessageBox.Show("Último Registro", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'incrementar el marcador de registro y actualizar controles con los datos de registro actual
            Me.Posicion_PR += 1
            'carga los datos al formulario
            Me.CargarDatosHorario()
        End If

    End Sub

    'boton final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        'establecer el marcador de registros en el primero obteniendo el numero de filas que contiene la tabla menos uno
        Me.Posicion_PR = (Me.DS_PR.Tables("tipo_user").Rows.Count - 1)
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
        strConexion = New OleDb.OleDbConnection
        'strConexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Dbminero.accdb; Jet OLEDB:Database Password=@waleska2018;"
        strConexion.ConnectionString = cs
        Me.DA_PR = New OleDbDataAdapter("Select * from tipo_user", conn)
        Dim consulta As OleDbCommandBuilder = New OleDbCommandBuilder(DA_PR)
        Me.DS_PR = New DataSet
        'conn.Open()
        Me.DA_PR.Fill(DS_PR, "tipo_user")
        conn.Close()
        Me.Posicion_PR = 0
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
            sqlquery = "SELECT * FROM tipo_user"
            cmd.Connection = conn
            cmd.CommandText = sqlquery
            '---------------------------------------------------------------------------------------------------------------------------                
            'procedo a pasar los datos de los textbox a la variable para guardar
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("?Nom_tipo", Me.TxtCategoria.Text)
            cmd.Parameters.AddWithValue("?tipo_user", Me.CboTipo.Text)
            cmd.Parameters.AddWithValue("?Descripcion", Me.TxtDescripcion.Text)
            cmd.Parameters.AddWithValue("?fecha_creado", Date.Now)
            cmd.Parameters.AddWithValue("?fecha_modifica", Date.Now)

            cmd.CommandText = "INSERT INTO tipo_user(Nom_tipo, tipo_user, descripcion,fecha_creado, fecha_modifica) VALUES ( '" & TxtCategoria.Text & "', '" & CboTipo.Text & "', '" & TxtDescripcion.Text & "', '" & fechaC & "', '" & fechaM & "')"

            cmd.ExecuteNonQuery()

            'cierro el procedimiento
            conn.Close()

            MsgBox("Los datos se han guardado Correctamente! ", MsgBoxStyle.Information, "AppMinerGold")


        Catch ex As Exception
            MsgBox("No es posible Guardar, Verifique! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
        End Try

    End Sub

    'PROCEDIMIENTO LIMPIAR CAMPOS
    Private Sub Limpiar_Todos()

        'campos LIMPIOS
        Me.TxtIdCategoria.Clear()
        Me.TxtCategoria.Clear()
        Me.TxtDescripcion.Clear()

        'ubicar campo de texto
        Me.TxtCategoria.Focus()

    End Sub

    'CARGA DATOS DE LOS BOTONES DE NAVEGACION
    Private Sub CargarDatosHorario()

        'obtener un objeto con la fila actual
        Dim Drow As DataRow
        Drow = Me.DS_PR.Tables("tipo_user").Rows(Me.Posicion_PR)

        'cargar los controles del formulario con valores de los camapos del registro
        Me.TxtIdCategoria.Text = CStr(Drow("Id"))
        Me.TxtCategoria.Text = CStr(Drow("Nom_tipo"))
        Me.CboTipo.Text = CStr(Drow("tipo_user"))
        Me.TxtDescripcion.Text = CStr(Drow("Descripcion"))

        'mostrar la posicion actual del registro y el numero de registros
        Me.LblRegistros.Text = "Registro No.: " &
        Me.Posicion_PR + 1 & " de " &
        Me.DS_PR.Tables("tipo_user").Rows.Count

    End Sub

    'valida todos los campos no pueden estar vacios
    Private Function ValidaDatosVacios() As Boolean
        'paciente
        If Len(Me.TxtCategoria.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtCategoria.Focus() : Return True : Exit Function
        If Len(Me.TxtDescripcion.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtDescripcion.Focus() : Return True : Exit Function
        Return True
    End Function

#End Region


#Region "EVENTO KEYPRESS"

    'activar los campos textbox con Enter
    Private Sub FrmTipoUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

    Private Sub txtCategoria_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCategoria.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub CboTipo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboTipo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtDescripcion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class
