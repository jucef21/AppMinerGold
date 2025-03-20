Option Explicit On
Option Strict On
Imports System.Data.OleDb

Public Class FrmCiudades
    Private strConexion As OleDb.OleDbConnection
    Private DS_CA As DataSet
    Private DA_CA As OleDbDataAdapter
    Private Posicion_CA As Integer

    'cargue del formulario
    Private Sub Frmcargos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        Me.TxtCiudad.Enabled = False
        Me.Txtciudcol.Enabled = False
        Me.TxtCodigoD.Enabled = False
        Me.CboDpto.Enabled = False
        Me.CboPais.Enabled = False

        Cargar_Combo(CboDpto, "SELECT DISTINCT departamento FROM Ciudad ORDER BY departamento")
        Cargar_Combo(CboPais, "SELECT DISTINCT Pais FROM paises ORDER BY Pais")

        'llamo la conexion
        ConectarDatos()

        'cargar los datos de la base de datos
        Me.CargarDatosHorario()

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

        'campos deshabilitados
        Me.TxtIdCategoria.Enabled = False
        Me.TxtCiudad.Enabled = True
        Me.Txtciudcol.Enabled = False
        Me.TxtCodigoD.Enabled = True
        Me.CboDpto.Enabled = True
        Me.CboPais.Enabled = True

        'posiciona el cursor en el campo deseado
        Me.TxtCiudad.Select()
        Me.TxtCiudad.Focus()

    End Sub

    'BOTON GUARDAR
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Me.TxtCiudad.Text = "" Or Me.TxtCodigoD.Text = "" Then
            MsgBox("El Campo Nombre no debe estar Vacío", MsgBoxStyle.Information, "Validación de Usuarios, AppMinerGold")
            Me.Panel1.Select()
            Me.GroupBox3.Select()
            Me.TxtCiudad.Text = ""
            Me.TxtCiudad.Focus()
        Else
            ValidaDane()

            'cerramos el formulario
            Limpiar_Todos()

            'posicionamos en cursor
            Me.TxtCiudad.Select()
            Me.TxtCiudad.Focus()

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
            Me.TxtCiudad.Enabled = False
            Me.Txtciudcol.Enabled = False
            Me.TxtCodigoD.Enabled = False
            Me.CboDpto.Enabled = False
            Me.CboPais.Enabled = False

            'cargar los datos de la base de datos
            Me.CargarDatosHorario()

        End If

    End Sub

    'BOTON CANCELAR
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        'limpia los campos
        Limpiar_Todos()

        'ubico el cursor
        Me.TxtCiudad.Focus()

        'valido los campos
        ValidaDatosVacios()

    End Sub

    'boton editar MODIFICAR
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click

        'campos deshabilitados
        Me.TxtIdCategoria.Enabled = False
        Me.Txtciudcol.Enabled = False

        'campos habilitados
        Me.TxtCiudad.Enabled = True
        Me.TxtCodigoD.Enabled = True
        Me.CboDpto.Enabled = True
        Me.CboPais.Enabled = True

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
        Me.GroupBox3.Select()
        Me.TxtCiudad.Select()
        Me.TxtCiudad.Focus()

    End Sub

    'boton Guarda CAMBIOS DE MODIFICAR
    Private Sub BtnGuardaCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardaCambios.Click
        If Me.TxtCiudad.Text = "" Or Me.TxtCodigoD.Text = "" Then
            MsgBox("El Campo Nombre no debe estar Vacío", MsgBoxStyle.Information, "Validación de Usuarios, AppMinerGold")
            Me.Panel1.Select()
            Me.GroupBox3.Select()
            Me.TxtCiudad.Text = ""
            Me.TxtCiudad.Focus()
        Else
            ValidaDaneModificado()
        End If
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

                Dim ConnString As String = cs

                'Genero la consulta a  la base de datos
                Dim SqlString As String = "Delete From ciudad Where ciudad= '" & TxtCiudad.Text & "' "
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
                Me.TxtCiudad.Focus()

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
                Me.TxtCiudad.Enabled = False
                Me.CboDpto.Enabled = False

                'cargar los datos de la base de datos
                Me.CargarDatosHorario()

            Else

                'muestro el mensaje de la consulta
                MsgBox("Usuario No se elimino de la base de datos!", MsgBoxStyle.Information, "AppMinerGold")

                'cerramos el formulario
                Limpiar_Todos()

                'posicionamos en cursor
                Me.TxtCiudad.Focus()

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
                Me.TxtCiudad.Enabled = False
                Me.CboDpto.Enabled = False

                'cargar los datos de la base de datos
                Me.CargarDatosHorario()

            End If

        Catch ex As Exception

            MsgBox("Imposible Eliminar porque...:" & ex.Message)
            'limpiamos los campos
            Limpiar_Todos()

            'posicionamos el cursor
            Me.TxtCiudad.Focus()

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
            (Me.DS_CA.Tables("ciudad").Rows.Count - 1) Then
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
        Me.Posicion_CA = (Me.DS_CA.Tables("ciudad").Rows.Count - 1)
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
        Me.DA_CA = New OleDbDataAdapter("SELECT * FROM ciudad", conn)
        Dim consulta As OleDbCommandBuilder = New OleDbCommandBuilder(DA_CA)
        Me.DS_CA = New DataSet
        'conn.Open()
        Me.DA_CA.Fill(DS_CA, "ciudad")
        conn.Close()
        Me.Posicion_CA = 0
    End Sub

    'Valida si el codigo Dane existe GUARDAR
    Private Sub ValidaDane()
        Dim encontro As Integer
        encontro = 0
        'revisamos la conexion
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        'ejecutamos la consulta
        cmd = New OleDbCommand("SELECT * FROM ciudad WHERE codigo_ciu='" & Me.TxtCodigoD.Text & "' ", conn) With {
            .Connection = conn
        }
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()
        Try
            Do While dr.Read
                encontro = 1
            Loop
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un Error en el Ingreso!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        conn.Close()

        If (encontro = 1) Then
            MessageBox.Show("El Código ingresado ya EXISTE!, verifique", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'pocisiono el cursor
            Me.Panel1.Select()
            Me.GroupBox3.Select()
            Me.TxtCodigoD.Text = ""
            Me.TxtCodigoD.Focus()
        Else
            'llamado de la funcion
            Guardar()
            'cierro conexion
            conn.Close()
        End If
    End Sub

    'Valida si el codigo Dane existe GUARDAR
    Private Sub ValidaDaneModificado()
        Dim encontro As Integer
        encontro = 0
        'revisamos la conexion
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        'ejecutamos la consulta
        cmd = New OleDbCommand("SELECT * FROM ciudad WHERE codigo_ciu='" & Me.TxtCodigoD.Text & "' ", conn) With {
            .Connection = conn
        }
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()
        Try
            Do While dr.Read
                encontro = 1
            Loop
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un Error en el Ingreso!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        conn.Close()

        If (encontro = 1) Then
            MessageBox.Show("El Código ingresado ya EXISTE!, verifique", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'pocisiono el cursor
            Me.Panel1.Select()
            Me.GroupBox3.Select()
            Me.TxtCodigoD.Text = ""
            Me.TxtCodigoD.Focus()
        Else
            'llamado de la funcion
            GuardaCambiosCiudad()
            'cierro conexion
            conn.Close()
        End If
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
            sqlquery = "SELECT * FROM ciudad"
            cmd.Connection = conn
            cmd.CommandText = sqlquery
            '---------------------------------------------------------------------------------------------------------------------------                
            'procedo a pasar los datos de los textbox a la variable para guardar
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("?ciudad", Me.TxtCiudad.Text)
            cmd.Parameters.AddWithValue("?ciudad_col", Me.TxtCiudad.Text)
            cmd.Parameters.AddWithValue("?codigo_ciu", Me.TxtCodigoD.Text)
            cmd.Parameters.AddWithValue("?Departamento", Me.CboDpto.Text)
            cmd.Parameters.AddWithValue("?Descripcion", Me.CboPais.Text)
            cmd.Parameters.AddWithValue("?fecha_creado", Date.Now)
            cmd.Parameters.AddWithValue("?fecha_modifica", Date.Now)

            cmd.CommandText = "INSERT INTO ciudad(ciudad, ciudad_col, codigo_ciu, departamento, descripcion, fecha_creado, fecha_modifica) VALUES ( '" & TxtCiudad.Text & "', '" & TxtCiudad.Text & "', '" & TxtCodigoD.Text & "','" & CboDpto.Text & "', '" & CboPais.Text & "', '" & fechaC & "', '" & fechaM & "')"

            cmd.ExecuteNonQuery()

            'cierro el procedimiento
            conn.Close()

            MsgBox("Los datos se han guardado Correctamente! ", MsgBoxStyle.Information, "AppMinerGold")


        Catch ex As Exception
            MsgBox("No es posible Guardar, Verifique! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
        End Try

    End Sub

    'procedimiento GUARDAR DATOS MODIFICADOS
    Private Sub GuardaCambiosCiudad()

        Dim fechaM As Date
        fechaM = CDate(Format(Date.Now.Date))

        'revisamos la conexin a la base de datos
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        Try
            Dim sqlConsulta As String = "UPDATE ciudad SET ciudad='" & TxtCiudad.Text & "', " &
                                                        "ciudad_col = '" & TxtCiudad.Text & "', " &
                                                        "codigo_ciu = '" & TxtCodigoD.Text & "', " &
                                                        "Departamento = '" & CboDpto.Text & "', " &
                                                        "Descripcion = '" & CboPais.Text & "', " &
                                                        "fecha_modifica ='" & fechaM & "' WHERE ciudad='" & Txtciudcol.Text & "'"
            cmd = New OleDb.OleDbCommand(sqlConsulta, conn)

            'ejecutamos la consulta
            cmd.ExecuteNonQuery()

            'CIERRO LA CONEXION
            conn.Close()

            'presentamos el mensaje 
            MsgBox("Registro actualizado exitosamente", MsgBoxStyle.Information, "AppMinerGold")

            'cerramos el formulario
            Limpiar_Todos()

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
            Me.Txtciudcol.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.TxtCodigoD.Enabled = False
            Me.CboDpto.Enabled = False
            Me.CboPais.Enabled = False

            'llamo la conexion
            ConectarDatos()

            'cargar los datos de la base de datos
            Me.CargarDatosHorario()

            Me.BtnNuevo.Select()
            Me.BtnNuevo.Focus()

        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Exclamation, "AppMinerGold")

            'campos deshabilitados
            Me.TxtIdCategoria.Enabled = False
            Me.Txtciudcol.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.TxtCodigoD.Enabled = False
            Me.CboDpto.Enabled = False
            Me.CboPais.Enabled = False

            Me.BtnNuevo.Select()
            Me.BtnNuevo.Focus()
        End Try

    End Sub

    'PROCEDIMIENTO LIMPIAR CAMPOS
    Private Sub Limpiar_Todos()

        'campos LIMPIOS
        Me.TxtIdCategoria.Clear()
        Me.Txtciudcol.Clear()
        Me.TxtCiudad.Clear()
        Me.TxtCodigoD.Clear()
        Me.CboDpto.Text = "Seleccione"
        Me.CboPais.Text = "Seleccione"

        'ubicar campo de texto
        Me.GroupBox3.Select()
        Me.TxtCiudad.Select()
        Me.TxtCiudad.Focus()

    End Sub

    'CARGA DATOS DE LOS BOTONES DE NAVEGACION
    Private Sub CargarDatosHorario()

        'obtener un objeto con la fila actual
        Dim Drow As DataRow
        Drow = Me.DS_CA.Tables("ciudad").Rows(Me.Posicion_CA)

        'cargar los controles del formulario con valores de los camapos del registro
        Me.TxtIdCategoria.Text = CStr(Drow("Id"))
        Me.Txtciudcol.Text = CStr(Drow("ciudad"))
        Me.TxtCiudad.Text = CStr(Drow("ciudad_col"))
        Me.TxtCodigoD.Text = CStr(Drow("codigo_ciu"))
        Me.CboDpto.Text = CStr(Drow("departamento"))
        Me.CboPais.Text = CStr(Drow("Descripcion"))

        'mostrar la posicion actual del registro y el numero de registros
        Me.LblRegistros.Text = "Registro No.: " &
        Me.Posicion_CA + 0 & " de " &
        Me.DS_CA.Tables("ciudad").Rows.Count

    End Sub

    'valida todos los campos no pueden estar vacios
    Private Function ValidaDatosVacios() As Boolean
        'paciente
        If Len(Me.TxtCiudad.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtCiudad.Focus() : Return True : Exit Function
        If Len(Me.TxtCodigoD.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtCodigoD.Focus() : Return True : Exit Function
        Return True
    End Function


#End Region


#Region "EVENTO KEYPRESS"

    'activar los campos textbox con Enter
    Private Sub FrmCiudades_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'VALIDA SOLO NUMEROS
    Private Sub TxtCodigoD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCodigoD.KeyPress
        SoloNumeros(e)
    End Sub


#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    'CARGAR COMBOBOX
    Private Sub Cargar_Combo(ByVal ComboBox As ComboBox, ByVal sql As String)
        ' nueva conexión indicando al SqlConnection la cadena de conexión   
        Dim conn As New OleDbConnection(cs)
        Try
            conn.Open()
            Dim cmd As New OleDbCommand(sql, conn) ' Pasar la consulta sql y la conexión al Sql Command    
            Dim da As New OleDbDataAdapter(cmd) ' Inicializar un nuevo SqlDataAdapter    
            Dim ds As New DataSet 'Crear y Llenar un Dataset   
            da.Fill(ds)
            ComboBox.DataSource = ds.Tables(0) ' asignar el DataSource al combobox   
            ComboBox.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString ' Asignar el campo a la propiedad DisplayMember del combo    
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Error de Conexión al carga el Combo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    'CONVIERTE EN MAYUSCULAS EL NOMBRE DEL MUNICIPIO
    Private Sub TxtCiudad_TextChanged(sender As Object, e As EventArgs) Handles TxtCiudad.TextChanged
        Me.TxtCiudad.Text = UCase(Me.TxtCiudad.Text)
        Me.TxtCiudad.SelectionStart = Me.TxtCiudad.TextLength + 1
    End Sub

#End Region


End Class
