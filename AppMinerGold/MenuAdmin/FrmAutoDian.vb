Option Explicit On
Option Strict On
Imports System.Data.OleDb

Public Class FrmAutoDian

    Private strConexion As OleDb.OleDbConnection
    Private DS_CA As DataSet
    Private DA_CA As OleDbDataAdapter
    Private Posicion_CA As Integer

    'cargue del formulario
    Private Sub FrmAutoDian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'llamo la conexion
        ConectarDatos()

        'limpio el formulario
        Limpiar_Todos()

        'habilitamos los botones 
        Me.BtnNuevo.Visible = True
        Me.BtnNuevo.Enabled = True
        Me.BtnEditar.Visible = True
        Me.BtnEditar.Enabled = True
        'Me.BtnEliminar.Visible = True
        'Me.BtnEliminar.Enabled = True

        'botones desactivados
        Me.btnGuardar.Visible = False
        Me.btnGuardar.Enabled = False
        Me.btnGuardaCambios.Visible = False
        Me.btnGuardaCambios.Enabled = False

        'botones de navegacion activados
        Me.BtnInicio.Enabled = True
        Me.BtnAnterior.Enabled = True
        Me.BtnSiguiente.Enabled = True
        Me.BtnFin.Enabled = True

        'campos deshabilitados
        Me.TxtIdCategoria.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.TxtDescripcion.Enabled = False
        Me.TxtNumFormu.Enabled = False
        Me.TxtPrefijo.Enabled = False
        Me.TxtNumInicia.Enabled = False
        Me.TxtNumFinal.Enabled = False
        Me.DTPfechaAut.Enabled = False

        Me.TxtDescripcion.Text = "Documento soporte Autorizado por la DIAN BAJO LA resolución de Facturación No."

        'formato del datatimepicker
        Me.DTPfechaAut.Format = DateTimePickerFormat.Custom
        Me.DTPfechaAut.CustomFormat = "dd/MM/yyyy"
        Me.DTPfechaAut.Value.ToString()

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

        'desactivo los botones
        Me.BtnNuevo.Visible = False
        Me.BtnNuevo.Enabled = False
        Me.BtnEditar.Visible = True
        Me.BtnEditar.Enabled = False
        Me.btnGuardaCambios.Visible = False
        Me.btnGuardaCambios.Enabled = False
        'Me.BtnEliminar.Visible = False
        'Me.BtnEliminar.Enabled = False

        'campos de navegacion desactivados
        Me.BtnInicio.Enabled = False
        Me.BtnAnterior.Enabled = False
        Me.BtnSiguiente.Enabled = False
        Me.BtnFin.Enabled = False

        'campos habilitados
        Me.TxtIdCategoria.Enabled = False
        Me.TxtCiudad.Enabled = True
        Me.TxtDescripcion.Enabled = False
        Me.TxtNumFormu.Enabled = True
        Me.TxtPrefijo.Enabled = True
        Me.TxtNumInicia.Enabled = True
        Me.TxtNumFinal.Enabled = True
        Me.DTPfechaAut.Enabled = True

        Me.TxtDescripcion.Text = "Documento soporte Autorizado por la DIAN BAJO LA resolución de Facturación No."

        'posiciona el cursor en el campo deseado
        Me.TxtCiudad.Select()
        Me.TxtCiudad.Focus()

    End Sub

    'BOTON GUARDAR
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Me.TxtCiudad.Text = "" Or Me.TxtNumFormu.Text = "" Or Me.TxtPrefijo.Text = "" Or Me.TxtNumInicia.Text = "" Or Me.TxtNumFinal.Text = "" Then
            MsgBox("El Campo no debe estar Vacío", MsgBoxStyle.Information, "Validación de Campos, AppMinerGold")
            Me.TxtCiudad.Select()
            Me.TxtCiudad.Focus()
        Else
            Guardar()

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

            'botones de navegacion activados
            Me.BtnInicio.Enabled = True
            Me.BtnAnterior.Enabled = True
            Me.BtnSiguiente.Enabled = True
            Me.BtnFin.Enabled = True

            'campos habilitados
            Me.TxtIdCategoria.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.TxtDescripcion.Enabled = False
            Me.TxtNumFormu.Enabled = False
            Me.TxtPrefijo.Enabled = False
            Me.TxtNumInicia.Enabled = False
            Me.TxtNumFinal.Enabled = False
            Me.DTPfechaAut.Enabled = False

            'cargar los datos de la base de datos
            Me.CargarDatosHorario()

        End If

    End Sub

    'boton editar MODIFICAR
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click

        'campos deshabilitados
        Me.TxtIdCategoria.Enabled = False

        'campos habilitados
        Me.TxtIdCategoria.Enabled = False
        Me.TxtCiudad.Enabled = True
        Me.TxtDescripcion.Enabled = False
        Me.TxtNumFormu.Enabled = True
        Me.TxtPrefijo.Enabled = True
        Me.TxtNumInicia.Enabled = True
        Me.TxtNumFinal.Enabled = True
        Me.DTPfechaAut.Enabled = True

        'habilitamos los botones 
        Me.btnGuardaCambios.Visible = True
        Me.btnGuardaCambios.Enabled = True

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
        Me.TxtCiudad.Select()
        Me.TxtCiudad.Focus()

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

        Dim NumId As Integer = CInt(TxtIdCategoria.Text)

        Try
            Dim sqlConsulta As String = "UPDATE Facturacion SET prefijo = '" & TxtPrefijo.Text & "', " &
                                                "detalle = '" & TxtDescripcion.Text & "', " &
                                                "autorizacion = '" & TxtNumFormu.Text & "', " &
                                                "ciudad = '" & TxtCiudad.Text & "', " &
                                                "numautoinicial = '" & TxtNumInicia.Text & "', " &
                                                "numautofinal = '" & TxtNumFinal.Text & "', " &
                                                "fechaauto ='" & DTPfechaAut.Text & "', " &
                                                "fecha_modifica='" & fechaM & "' WHERE id = " & NumId

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

            'botones de navegacion activados
            Me.BtnInicio.Enabled = True
            Me.BtnAnterior.Enabled = True
            Me.BtnSiguiente.Enabled = True
            Me.BtnFin.Enabled = True

            'campos deshabilitados
            Me.TxtIdCategoria.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.TxtDescripcion.Enabled = False
            Me.TxtNumFormu.Enabled = False
            Me.TxtPrefijo.Enabled = False
            Me.TxtNumInicia.Enabled = False
            Me.TxtNumFinal.Enabled = False
            Me.DTPfechaAut.Enabled = False

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

                Dim ConnString As String = cs

                'Genero la consulta a  la base de datos
                Dim SqlString As String = "Delete From Facturacion Where ciudad = '" & TxtCiudad.Text & "' "
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

                'botones de navegacion activados
                Me.BtnInicio.Enabled = True
                Me.BtnAnterior.Enabled = True
                Me.BtnSiguiente.Enabled = True
                Me.BtnFin.Enabled = True

                'campos deshabilitados
                Me.TxtIdCategoria.Enabled = False
                Me.TxtCiudad.Enabled = False
                Me.TxtDescripcion.Enabled = False
                Me.TxtNumFormu.Enabled = False
                Me.TxtPrefijo.Enabled = False
                Me.TxtNumInicia.Enabled = False
                Me.TxtNumFinal.Enabled = False
                Me.DTPfechaAut.Enabled = False

                'cargar los datos de la base de datos
                Me.CargarDatosHorario()

            Else

                'muestro el mensaje de la consulta
                MsgBox("El Codigo de Facturación no se elimino de la base de datos!", MsgBoxStyle.Information, "AppMinerGold")

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

                'botones de navegacion activados
                Me.BtnInicio.Enabled = True
                Me.BtnAnterior.Enabled = True
                Me.BtnSiguiente.Enabled = True
                Me.BtnFin.Enabled = True

                'campos deshabilitados
                Me.TxtIdCategoria.Enabled = False
                Me.TxtCiudad.Enabled = False
                Me.TxtDescripcion.Enabled = False
                Me.TxtNumFormu.Enabled = False
                Me.TxtPrefijo.Enabled = False
                Me.TxtNumInicia.Enabled = False
                Me.TxtNumFinal.Enabled = False
                Me.DTPfechaAut.Enabled = False

                'cargar los datos de la base de datos
                Me.CargarDatosHorario()

            End If

        Catch ex As Exception

            MsgBox("Imposible Eliminar porque...:" & ex.Message)
            'limpiamos los campos
            Limpiar_Todos()

            'posicionamos el cursor
            Me.TxtCiudad.Select()
            Me.TxtCiudad.Focus()

        End Try

    End Sub

    'BOTON De CERRAR
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
            (Me.DS_CA.Tables("Facturacion").Rows.Count - 1) Then
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
        Me.Posicion_CA = (Me.DS_CA.Tables("Facturacion").Rows.Count - 1)
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
        Me.DA_CA = New OleDbDataAdapter("Select * from Facturacion", conn)
        Dim consulta As OleDbCommandBuilder = New OleDbCommandBuilder(DA_CA)
        Me.DS_CA = New DataSet
        'conn.Open()
        Me.DA_CA.Fill(DS_CA, "Facturacion")
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

        Me.TxtDescripcion.Text = "Autorización Numeración de Facturación No.  "

        'ejecutamos las consultas
        Try
            sqlquery = "SELECT * FROM Facturacion"
            cmd.Connection = conn
            cmd.CommandText = sqlquery
            '---------------------------------------------------------------------------------------------------------------------------                
            'procedo a pasar los datos de los textbox a la variable para guardar
            cmd.Parameters.Clear()
            'cmd.Parameters.AddWithValue("?id", Me.TxtIdCategoria.Text)
            cmd.Parameters.AddWithValue("?prefijo", Me.TxtPrefijo.Text)
            cmd.Parameters.AddWithValue("?detalle", Me.TxtDescripcion.Text)
            cmd.Parameters.AddWithValue("?autorizacion", Me.TxtNumFormu.Text)
            cmd.Parameters.AddWithValue("?ciudad", Me.TxtCiudad.Text)
            cmd.Parameters.AddWithValue("?numautoinicial", Me.TxtNumInicia.Text)
            cmd.Parameters.AddWithValue("?numautofinal", Me.TxtNumFinal.Text)
            cmd.Parameters.AddWithValue("?fechaauto", Me.DTPfechaAut.Text)
            cmd.Parameters.AddWithValue("?fecha_creado", Date.Now)
            cmd.Parameters.AddWithValue("?fecha_modifica", Date.Now)

            cmd.CommandText = "INSERT INTO Facturacion(prefijo, detalle, autorizacion, ciudad, " &
                                                    "numautoinicial, numautofinal, fechaauto, fecha_creado, " &
                                                    "fecha_modifica) VALUES ( '" & TxtPrefijo.Text & "', '" & TxtDescripcion.Text & "', " &
                                                    "'" & TxtNumFormu.Text & "', '" & TxtCiudad.Text & "', '" & TxtNumInicia.Text & "', " &
                                                    "'" & TxtNumFinal.Text & "', '" & DTPfechaAut.Text & "', " &
                                                    "'" & fechaC & "', '" & fechaM & "')"

            cmd.ExecuteNonQuery()
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
        Me.TxtCiudad.Clear()
        Me.TxtDescripcion.Clear()
        Me.TxtNumFormu.Clear()
        Me.TxtPrefijo.Clear()
        Me.TxtNumInicia.Clear()
        Me.TxtNumFinal.Clear()

        'formato del datatimepicker
        Me.DTPfechaAut.Format = DateTimePickerFormat.Custom
        Me.DTPfechaAut.CustomFormat = "dd/MM/yyyy"
        Me.DTPfechaAut.Value.ToString()

        'ubicar campo de texto
        Me.TxtCiudad.Select()
        Me.TxtCiudad.Focus()

    End Sub

    'CARGA DATOS DE LOS BOTONES DE NAVEGACION
    Private Sub CargarDatosHorario()
        Try
            'obtener un objeto con la fila actual
            Dim Drow As DataRow
            Drow = Me.DS_CA.Tables("Facturacion").Rows(Me.Posicion_CA)

            'cargar los controles del formulario con valores de los camapos del registro
            Me.TxtIdCategoria.Text = CStr(Drow("Id"))
            Me.TxtPrefijo.Text = CStr(Drow("prefijo"))
            Me.TxtDescripcion.Text = CStr(Drow("detalle"))
            Me.TxtNumFormu.Text = CStr(Drow("autorizacion"))
            Me.TxtCiudad.Text = CStr(Drow("ciudad"))
            Me.TxtNumInicia.Text = CStr(Drow("numautoinicial"))
            Me.TxtNumFinal.Text = CStr(Drow("numautofinal"))
            Me.DTPfechaAut.Text = CStr(Drow("fechaauto"))

            'mostrar la posicion actual del registro y el numero de registros
            Me.LblRegistros.Text = "Registro No.: " &
            Me.Posicion_CA + 1 & " de " &
            Me.DS_CA.Tables("Facturacion").Rows.Count

        Catch ex As Exception
            MsgBox("No Hay Registros Grabados, Verifique! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
        End Try


    End Sub

    'valida todos los campos no pueden estar vacios
    Private Function ValidaDatosVacios() As Boolean
        If Len(Me.TxtPrefijo.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtPrefijo.Focus() : Return True : Exit Function
        If Len(Me.TxtDescripcion.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtDescripcion.Focus() : Return True : Exit Function
        If Len(Me.TxtNumFormu.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtNumFormu.Focus() : Return True : Exit Function
        If Len(Me.TxtCiudad.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtCiudad.Focus() : Return True : Exit Function
        If Len(Me.TxtNumInicia.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtNumInicia.Focus() : Return True : Exit Function
        If Len(Me.TxtNumFinal.Text.Trim) = 0 Then MsgBox("El Campo no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtNumFinal.Focus() : Return True : Exit Function
        Return True
    End Function

#End Region


#Region "EVENTO KEYPRESS"

    'activar los campos textbox con Enter
    Private Sub FrmAutoDian_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCiudad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCiudad.KeyPress
        SoloLetras(e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtNumFormu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumFormu.KeyPress
        SoloNumeros(e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtPrefijo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPrefijo.KeyPress
        SoloLetras(e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtNumInicia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumInicia.KeyPress
        SoloNumeros(e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtNumFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumFinal.KeyPress
        SoloNumeros(e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

End Class