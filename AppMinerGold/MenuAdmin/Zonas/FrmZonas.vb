Option Explicit On
Option Strict On
Imports System.Data.OleDb

Public Class FrmZonas

    Private strConexion As OleDb.OleDbConnection
    Private DS_CA As DataSet
    Private DA_CA As OleDbDataAdapter
    Private Posicion_CA As Integer

    'CARGUE DEL FORM
    Private Sub FrmZonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Me.txtIdCategoria.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.Txtciudcol.Enabled = False
        Me.TxtCodigoD.Enabled = False
        Me.CboDpto.Enabled = False

        Cargar_Combo(CboDpto, "SELECT DISTINCT departamento FROM Ciudad ORDER BY departamento")

        'cargar los datos de la base de datos
        Me.CargarDatosHorario()

    End Sub

#Region "Botones Form"

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
        Me.txtIdCategoria.Enabled = False
        Me.TxtCiudad.Enabled = True
        Me.Txtciudcol.Enabled = False
        Me.TxtCodigoD.Enabled = True
        Me.CboDpto.Enabled = True

        'posiciona el cursor en el campo deseado
        Me.GroupBox3.Select()
        Me.TxtCiudad.Select()
        Me.TxtCiudad.Focus()

    End Sub

    'BOTON GUARDAR
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Me.TxtCiudad.Text = "" Or Me.TxtCodigoD.Text = "" Then
            MessageBox.Show("El Campo no debe estar Vacío", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.GroupBox3.Select()
            Me.TxtCiudad.Select()
            Me.TxtCiudad.Focus()
        Else

            ValidaDane()

            'cerramos el formulario
            Limpiar_Todos()

            'posicionamos en cursor
            Me.GroupBox3.Select()
            Me.TxtCiudad.Select()
            Me.TxtCiudad.Focus()

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
            Me.txtIdCategoria.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.Txtciudcol.Enabled = False
            Me.TxtCodigoD.Enabled = False
            Me.CboDpto.Enabled = False

            'llamo la conexion
            ConectarDatos()

            'cargar los datos de la base de datos
            Me.CargarDatosHorario()

        End If

    End Sub

    'BOTON CANCELAR
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        'limpia los campos
        Limpiar_Todos()

        'ubico el cursor
        Me.GroupBox3.Select()
        Me.TxtCiudad.Select()
        Me.TxtCiudad.Focus()

        'valido los campos
        ValidaDatosVacios()

    End Sub

    'boton editar MODIFICAR
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click

        'campos deshabilitados
        Me.txtIdCategoria.Enabled = False
        Me.Txtciudcol.Enabled = False

        'campos habilitados
        Me.TxtCiudad.Enabled = True
        Me.TxtCodigoD.Enabled = True
        Me.CboDpto.Enabled = True

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
            MessageBox.Show("El Campo no debe estar Vacío", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.GroupBox3.Select()
            Me.TxtCiudad.Select()
            Me.TxtCiudad.Focus()
        Else
            ValidaDaneCambio()
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
            respuesta = CByte(MessageBox.Show("¿Esta seguro de Eliminar este Registro?", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            'verificamos la respuesta
            If respuesta = vbYes Then
                Dim ConnString As String = cs
                'Genero la consulta a  la base de datos
                Dim SqlString As String = "DELETE FROM Zonas WHERE municipio = '" & TxtCiudad.Text & "' "
                comand = New OleDbCommand(SqlString, conn)
                'ejecuto la consulta
                comand.ExecuteNonQuery()
                'cierro la conexion
                conn.Close()
                'muestro el mensaje de la consulta
                MessageBox.Show("Registro eliminado con éxito de la base de datos!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cerramos el formulario
                Limpiar_Todos()
                'posicionamos en cursor
                Me.TxtCiudad.Focus()
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
                Me.txtIdCategoria.Enabled = False
                Me.TxtCiudad.Enabled = False
                Me.CboDpto.Enabled = False
                'llamo la conexion
                ConectarDatos()
                'cargar los datos de la base de datos
                Me.CargarDatosHorario()
            Else
                MessageBox.Show("Registro No se elimino de la base de datos!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cerramos el formulario
                Limpiar_Todos()
                'posicionamos en cursor
                Me.GroupBox3.Select()
                Me.TxtCiudad.Select()
                Me.TxtCiudad.Focus()

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
                Me.txtIdCategoria.Enabled = False
                Me.TxtCiudad.Enabled = False
                Me.CboDpto.Enabled = False

                'llamo la conexion de datos
                ConectarDatos()

                'cargar los datos de la base de datos
                Me.CargarDatosHorario()

            End If

        Catch ex As Exception
            MessageBox.Show("Imposible Eliminar registro porque" + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'limpiamos los campos
            Limpiar_Todos()

            'posicionamos el cursor
            Me.GroupBox3.Select()
            Me.TxtCiudad.Select()
            Me.TxtCiudad.Focus()

        End Try

    End Sub

    'boton salir
    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'cierro conexion del formulario
        Me.Close()

        'llamo el formulario de regreso
        FrmAdmin.Show()

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
            (Me.DS_CA.Tables("Zonas").Rows.Count - 1) Then
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
        Me.Posicion_CA = (Me.DS_CA.Tables("Zonas").Rows.Count - 1)
        'carga los datos al formulario
        Me.CargarDatosHorario()

    End Sub

#End Region

#Region "Validaciones"

    'PROCEDIMIENTO PARA CONECTAR LOS DATOS AL FORMULARIO
    Private Sub ConectarDatos()
        'revisamos la conexion a la base de datos
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim strConexion As OleDb.OleDbConnection
        strConexion = New OleDb.OleDbConnection
        strConexion.ConnectionString = cs
        Me.DA_CA = New OleDbDataAdapter("SELECT * FROM Zonas", conn)
        Dim consulta As OleDbCommandBuilder = New OleDbCommandBuilder(DA_CA)
        Me.DS_CA = New DataSet
        'conn.Open()
        Me.DA_CA.Fill(DS_CA, "Zonas")
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
        cmd = New OleDbCommand("SELECT * FROM Zonas WHERE codigo_dane='" & Me.TxtCodigoD.Text & "' ", conn) With {
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

    'Valida si el codigo Dane existe GUARDAR CAMBIOS
    Private Sub ValidaDaneCambio()
        Dim encontro As Integer
        encontro = 0
        'revisamos la conexion
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        'ejecutamos la consulta
        cmd = New OleDbCommand("SELECT * FROM Zonas WHERE codigo_dane='" & Me.TxtCodigoD.Text & "' ", conn) With {
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
            GuardaCambiosZonas()
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
            sqlquery = "SELECT * FROM Zonas"
            cmd.Connection = conn
            cmd.CommandText = sqlquery
            '---------------------------------------------------------------------------------------------------------------------------                
            'procedo a pasar los datos de los textbox a la variable para guardar
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("?municipio", Me.TxtCiudad.Text)
            cmd.Parameters.AddWithValue("?departamento", Me.CboDpto.Text)
            cmd.Parameters.AddWithValue("?codigo_dane", Me.TxtCodigoD.Text)
            cmd.Parameters.AddWithValue("?fecha_creado", Date.Now)
            cmd.Parameters.AddWithValue("?fecha_modifica", Date.Now)
            cmd.CommandText = "INSERT INTO Zonas(municipio, departamento, codigo_dane, fecha_creado, fecha_modifica) VALUES ( '" & TxtCiudad.Text & "', '" & CboDpto.Text & "', '" & TxtCodigoD.Text & "', '" & fechaC & "', '" & fechaM & "')"
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Los datos se han guardado Correctamente! ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'carga los datos al formulario
            Me.CargarDatosHorario()
        Catch ex As Exception
            MessageBox.Show("No es posible Guardar, Verifique! " & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Procedimiento Guarda Cambios
    Private Sub GuardaCambiosZonas()
        Dim fechaM As Date
        fechaM = CDate(Format(Date.Now.Date))

        'revisamos la conexion a la base de datos
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        Try
            Dim sqlConsulta As String = "UPDATE Zonas SET municipio ='" & TxtCiudad.Text & "', " &
                                                        "codigo_dane = '" & TxtCodigoD.Text & "', " &
                                                        "departamento = '" & CboDpto.Text & "', " &
                                                        "fecha_modifica ='" & fechaM & "' WHERE municipio='" & Txtciudcol.Text & "'"
            cmd = New OleDb.OleDbCommand(sqlConsulta, conn)

            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Registro actualizado exitosamente", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'cerramos el formulario
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
            Me.txtIdCategoria.Enabled = False
            Me.Txtciudcol.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.TxtCodigoD.Enabled = False
            Me.CboDpto.Enabled = False

            'llamo la conexion
            ConectarDatos()

            'cargar los datos de la base de datos
            Me.CargarDatosHorario()

            Me.BtnNuevo.Select()
            Me.BtnNuevo.Focus()

        Catch ex As Exception
            MessageBox.Show("Error al Guardar Registro" + Err.Description, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'campos deshabilitados
            Me.txtIdCategoria.Enabled = False
            Me.Txtciudcol.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.TxtCodigoD.Enabled = False
            Me.CboDpto.Enabled = False

            Me.BtnNuevo.Select()
            Me.BtnNuevo.Focus()
        End Try

    End Sub

    'PROCEDIMIENTO LIMPIAR CAMPOS
    Private Sub Limpiar_Todos()
        'campos LIMPIOS
        Me.txtIdCategoria.Clear()
        Me.Txtciudcol.Clear()
        Me.TxtCiudad.Clear()
        Me.TxtCodigoD.Clear()
        Me.CboDpto.Text = " Seleccione"
        'ubicar campo de texto
        Me.GroupBox3.Select()
        Me.TxtCiudad.Select()
        Me.TxtCiudad.Focus()
    End Sub

    'CARGA DATOS DE LOS BOTONES DE NAVEGACION
    Private Sub CargarDatosHorario()

        'obtener un objeto con la fila actual
        Dim Drow As DataRow
        Drow = Me.DS_CA.Tables("Zonas").Rows(Me.Posicion_CA)

        'cargar los controles del formulario con valores de los camapos del registro
        Me.txtIdCategoria.Text = CStr(Drow("Id"))
        Me.Txtciudcol.Text = CStr(Drow("municipio"))
        Me.TxtCiudad.Text = CStr(Drow("municipio"))
        Me.TxtCodigoD.Text = CStr(Drow("codigo_dane"))
        Me.CboDpto.Text = CStr(Drow("departamento"))

        'mostrar la posicion actual del registro y el numero de registros
        Me.LblRegistros.Text = "Registro No.: " &
        Me.Posicion_CA + 0 & " de " &
        Me.DS_CA.Tables("Zonas").Rows.Count

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
        End If
    End Sub

    'VALIDA SOLO NUMEROS
    Private Sub TxtCodigoD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCodigoD.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        SoloNumeros(e)
    End Sub

    'CONVIERTE EN MAYUSCULAS EL NOMBRE DEL MUNICIPIO
    Private Sub TxtCiudad_TextChanged(sender As Object, e As EventArgs) Handles TxtCiudad.TextChanged
        Me.TxtCiudad.Text = UCase(Me.TxtCiudad.Text)
        Me.TxtCiudad.SelectionStart = Me.TxtCiudad.TextLength + 1
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

#End Region


End Class
