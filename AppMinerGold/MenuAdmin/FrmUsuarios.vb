Imports System.Data.OleDb
Imports System.Text.RegularExpressions

'formulario de Usuarios
Public Class FrmUsuarios

    'INICIALIZA LOS COMPONENTES
    Public Sub New()
        ' Llamada necesaria para el diseñador.
        Me.InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    'formulario de carga
    Private Sub FrmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cierro las bases de datos abiertas
        conn.Close()

        Refresh()

        Conectarse()

        'posicionamos en cursor
        Me.GroupBox1.Select()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

        'para limpiar los campos
        Call Limpiar_cajas_de_texto()

        'deshabilitar los campor de texto
        Me.TxtID.Enabled = False
        Me.TxtNombre.Enabled = False
        Me.TxtApellido.Enabled = False
        Me.TxtCedula.Enabled = False
        Me.TxtTelFijo.Enabled = False
        Me.TxtTelcel.Enabled = False
        Me.CboSexo.Enabled = False
        Me.DTP_FechaNace.Enabled = False
        Me.TxtDireccion.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.TxtEmail.Enabled = False
        Me.TxtCodigo.Enabled = False
        Me.CboCargo.Enabled = False
        Me.TxtUserName.Enabled = False
        Me.TxtPassword.Enabled = False
        Me.CboTipo_User.Enabled = False
        Me.Cbo_efectivo.Enabled = False

        'habilitamos los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnNuevo.Enabled = True

        'desabilitamos los botones
        Me.BtnNewBuscar.Enabled = False
        Me.BtnGuardar.Enabled = False
        Me.BtnModifica.Enabled = False
        Me.BtnGuardaCambios.Enabled = False
        Me.BtnEliminar.Enabled = False

        'conexion del combobox
        Cargar_Combo(CboSexo, "Select DISTINCT Nom_sexo From sexo Order By Nom_sexo")
        Cargar_Combo(CboCargo, "Select DISTINCT Nom_cargo From cargo Order By Nom_cargo")
        Cargar_Combo(CboTipo_User, "Select DISTINCT tipo_user From tipo_user Order By tipo_user")
        Cargar_Combo(Cbo_efectivo, "Select DISTINCT control From controlcaja Order By control")

        'SELECIONAR COMBOS
        Me.CboSexo.Text = "SELECCIONE"
        Me.CboCargo.Text = "SELECCIONE"

        'Cierro la base
        conn.Close()

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

    'BOTON BUSCAR
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'Ubico el cursor
        Me.TxtBuscar.Focus()

        Try
            'Using conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Dbminero.accdb; Jet OLEDB:Database Password=@waleska2018;")
            Using conn As New OleDb.OleDbConnection
                conn.ConnectionString = cs
                'abrimos la conexion
                conn.Open()
                'creamos la variable de consulta
                Dim SQlbuscar As String
                'realizamos la consulta
                SQlbuscar = "Select * FROM Usuarios WHERE cedula_user ='" & TxtBuscar.Text & "'"
                'creamos el adaptador
                Dim da As New OleDb.OleDbDataAdapter(SQlbuscar, conn)
                'creamos el comando builder
                Dim cb As New OleDb.OleDbCommandBuilder(da)
                'creamos el dataset
                Dim ds As New DataSet
                da.Fill(ds, "Dbminero")
                'creamos el comando de conexion
                'convertimos el comando en tipo texto
                Dim comandos As New OleDbCommand(SQlbuscar, conn) With {
                    .CommandType = CommandType.Text
                }
                'adiccionamos los parametros de consulta
                comandos.Parameters.AddWithValue("@Cedula_user", TxtBuscar.Text)
                'ejecutamos la consulta 
                Dim lectura As OleDbDataReader = comandos.ExecuteReader()

                'si el campo esta vacio
                If (Me.TxtBuscar.Text = "") Then
                    MsgBox("El Campo no puede estar vacio", MsgBoxStyle.Critical, "AppMinerGold")
                    Me.GroupBox1.Select()
                    Me.TxtBuscar.Select()
                    Me.TxtBuscar.Focus()
                    Exit Sub
                End If

                If lectura.Read = True Then
                    Me.TxtID.Text = CStr(lectura(0))
                    Me.TxtNombre.Text = CStr(lectura(2))
                    Me.TxtApellido.Text = CStr(lectura(3))
                    Me.TxtCedula.Text = CStr(lectura(1))
                    Me.TxtTelFijo.Text = CStr(lectura(6))
                    Me.TxtTelcel.Text = CStr(lectura(7))
                    Me.CboSexo.Text = CStr(lectura(4))
                    Me.DTP_FechaNace.Text = CStr(lectura(5))
                    Me.TxtDireccion.Text = CStr(lectura(9))
                    Me.TxtCiudad.Text = CStr(lectura(8))
                    Me.TxtEmail.Text = CStr(lectura(10))
                    Me.TxtCodigo.Text = CStr(lectura(11))
                    Me.CboCargo.Text = CStr(lectura(12))
                    Me.TxtUserName.Text = CStr(lectura(13))
                    Me.TxtPassword.Text = CStr(lectura(14))
                    Me.CboTipo_User.Text = CStr(lectura(15))
                    Me.Cbo_efectivo.Text = CStr(lectura(16))

                    'habilitamos los botones 
                    Me.BtnNuevo.Enabled = True
                    Me.BtnNewBuscar.Enabled = True
                    Me.BtnModifica.Enabled = True
                    Me.BtnEliminar.Enabled = True

                    'deshabilitamos los botones
                    Me.BtnBuscar.Enabled = False
                    Me.BtnGuardar.Enabled = False
                    Me.BtnGuardaCambios.Enabled = False

                    'conexion.Close()
                    Exit Sub

                Else
                    MsgBox("La Cédula ingresada NO EXISTE, en nuestra Base de Datos", MsgBoxStyle.Critical, "AppMinerGold")

                    'para limpiar los campos
                    Limpiar_cajas_de_texto()


                    'Ubico el cursor
                    Me.TxtBuscar.Focus()

                    'Cierro la conexion
                    'conexion.Close()
                    Exit Sub
                    Call Limpiar_Cajas(Me)
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message + "", "AppMinerGold, ¡Ocurrio el siguiente Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'conexion.Close()
        Exit Sub
    End Sub

    'BOTON DE NUEVA BUSQUEDA
    Private Sub BtnNewBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewBuscar.Click

        'para limpiar los campos
        Limpiar_cajas_de_texto()

        'habilitamos los botones 
        Me.BtnBuscar.Enabled = True
        Me.BtnNuevo.Enabled = True

        'deshabilitamos los botones
        Me.BtnNewBuscar.Enabled = False
        Me.BtnGuardar.Enabled = False
        Me.BtnModifica.Enabled = False
        Me.BtnGuardaCambios.Enabled = False
        Me.BtnEliminar.Enabled = False

        'deshabilitar los campos de texto
        Me.TxtID.Enabled = False
        Me.TxtNombre.Enabled = False
        Me.TxtApellido.Enabled = False
        Me.TxtCedula.Enabled = False
        Me.TxtTelFijo.Enabled = False
        Me.TxtTelcel.Enabled = False
        Me.CboSexo.Enabled = False
        Me.DTP_FechaNace.Enabled = False
        Me.TxtDireccion.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.TxtEmail.Enabled = False
        Me.TxtCodigo.Enabled = False
        Me.CboCargo.Enabled = False
        Me.TxtUserName.Enabled = False
        Me.TxtPassword.Enabled = False
        Me.CboTipo_User.Enabled = False
        Me.Cbo_efectivo.Enabled = False

    End Sub

    'BOTON DE NUEVO
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click

        'limpiamos el formulario
        Limpiar_cajas_de_texto()

        'Call Limpiar_Cajas(Me)

        'deshabilitamos los CAMPOS
        Me.TxtID.Enabled = False
        Me.TxtBuscar.Enabled = False

        'habilitar los campos de texto
        Me.TxtNombre.Enabled = True
        Me.TxtApellido.Enabled = True
        Me.TxtCedula.Enabled = True
        Me.TxtTelFijo.Enabled = True
        Me.TxtTelcel.Enabled = True
        Me.CboSexo.Enabled = True
        Me.DTP_FechaNace.Enabled = True
        Me.TxtDireccion.Enabled = True
        Me.TxtCiudad.Enabled = True
        Me.TxtEmail.Enabled = True
        Me.TxtCodigo.Enabled = True
        Me.CboCargo.Enabled = True
        Me.TxtUserName.Enabled = True
        Me.TxtPassword.Enabled = True
        Me.CboTipo_User.Enabled = True
        Me.Cbo_efectivo.Enabled = True

        'deshabilitamos los botones
        Me.BtnBuscar.Enabled = False
        Me.BtnNewBuscar.Enabled = False
        Me.BtnNuevo.Enabled = False
        Me.BtnGuardaCambios.Enabled = False
        Me.BtnModifica.Enabled = False
        Me.BtnEliminar.Enabled = False

        'habilitanos los botones
        Me.BtnGuardar.Enabled = True

        'SELECIONAR COMBOS
        Me.CboSexo.Text = "SELECCIONE"
        Me.CboCargo.Text = "SELECCIONE"

        'UBICO EL CURSOR
        Me.GroupBox2.Select()
        Me.TxtNombre.Select()
        Me.TxtNombre.Focus()

    End Sub

    'BOTON ELIMINAR
    Dim comand As New OleDb.OleDbCommand
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim respuesta As Byte
        Dim adaptador As New OleDb.OleDbDataAdapter
        Dim registros As New DataSet
        Try
            If conn.State() = ConnectionState.Closed Then
                conn.Open()
            End If
            respuesta = CByte(MsgBox("¿Esta seguro de Eliminar este Registro?", MsgBoxStyle.YesNo, "AppMinerGold"))
            If respuesta = vbYes Then
                Dim ConnString As String = cs
                Dim SqlString As String = "DELETE FROM Usuarios WHERE cedula_user = '" & Me.TxtCedula.Text & "' "
                comand = New OleDbCommand(SqlString, conn)

                'ejecuto la orden 
                comand.ExecuteNonQuery()

                'cierro conexion
                conn.Close()

                'mostramos el mensaje
                MsgBox("Usuario eliminado con exito de la Base de Datos!", MsgBoxStyle.Information, "AppMinerGold")

                'para limpiar los campos
                Call Limpiar_cajas_de_texto()

                'deshabilitar los campor de texto
                Me.TxtID.Enabled = False
                Me.TxtNombre.Enabled = False
                Me.TxtApellido.Enabled = False
                Me.TxtCedula.Enabled = False
                Me.TxtTelFijo.Enabled = False
                Me.TxtTelcel.Enabled = False
                Me.CboSexo.Enabled = False
                Me.DTP_FechaNace.Enabled = False
                Me.TxtDireccion.Enabled = False
                Me.TxtCiudad.Enabled = False
                Me.TxtEmail.Enabled = False
                Me.TxtCodigo.Enabled = False
                Me.CboCargo.Enabled = False
                Me.TxtUserName.Enabled = False
                Me.TxtPassword.Enabled = False
                Me.CboTipo_User.Enabled = False
                Me.Cbo_efectivo.Enabled = False

                'habilitamos los botones
                Me.BtnBuscar.Enabled = True
                Me.BtnNuevo.Enabled = True

                'desabilitamos los botones
                Me.BtnNewBuscar.Enabled = False
                Me.BtnGuardar.Enabled = False
                Me.BtnModifica.Enabled = False
                Me.BtnGuardaCambios.Enabled = False
                Me.BtnEliminar.Enabled = False

                'posicionamos en cursor
                Me.TxtBuscar.Focus()

                'conexion del combobox
                Cargar_Combo(CboSexo, "Select DISTINCT Nom_sexo From sexo Order By Nom_sexo")
                Cargar_Combo(CboCargo, "Select DISTINCT Nom_cargo From cargo Order By Nom_cargo")
                Cargar_Combo(CboTipo_User, "Select DISTINCT tipo_user From tipo_user Order By tipo_user")
                Cargar_Combo(Cbo_efectivo, "Select DISTINCT control From controlcaja Order By control")

            Else

                'mostramos el mensaje
                MsgBox("No pudo eliminar el Usuario de la Base de Datos!, se cancelo el registro por parte del Usuario", MsgBoxStyle.Information, "AppMinerGold")

                'para limpiar los campos
                Call Limpiar_cajas_de_texto()

                'deshabilitar los campor de texto
                Me.TxtID.Enabled = False
                Me.TxtNombre.Enabled = False
                Me.TxtApellido.Enabled = False
                Me.TxtCedula.Enabled = False
                Me.TxtTelFijo.Enabled = False
                Me.TxtTelcel.Enabled = False
                Me.CboSexo.Enabled = False
                Me.DTP_FechaNace.Enabled = False
                Me.TxtDireccion.Enabled = False
                Me.TxtCiudad.Enabled = False
                Me.TxtEmail.Enabled = False
                Me.TxtCodigo.Enabled = False
                Me.CboCargo.Enabled = False
                Me.TxtUserName.Enabled = False
                Me.TxtPassword.Enabled = False
                Me.CboTipo_User.Enabled = False
                Me.Cbo_efectivo.Enabled = False

                'habilitamos los botones
                Me.BtnBuscar.Enabled = True
                Me.BtnNuevo.Enabled = True

                'desabilitamos los botones
                Me.BtnNewBuscar.Enabled = False
                Me.BtnGuardar.Enabled = False
                Me.BtnModifica.Enabled = False
                Me.BtnGuardaCambios.Enabled = False
                Me.BtnEliminar.Enabled = False

                'posicionamos en cursor
                Me.TxtBuscar.Focus()

                'conexion del combobox
                Cargar_Combo(CboSexo, "Select DISTINCT Nom_sexo From sexo Order By Nom_sexo")
                Cargar_Combo(CboCargo, "Select DISTINCT Nom_cargo From cargo Order By Nom_cargo")
                Cargar_Combo(CboTipo_User, "Select DISTINCT tipo_user From tipo_user Order By tipo_user")
                Cargar_Combo(Cbo_efectivo, "Select DISTINCT control From controlcaja Order By control")
            End If

        Catch ex As Exception
            MsgBox("Imposible Eliminar porque...:" & ex.Message)

            Limpiar_cajas_de_texto()

            'posicionamos el cursor
            Me.TxtCodigo.Focus()

        End Try

    End Sub

    'BOTON DE CONSULTA DE CLIENTES
    Private Sub BtnConsu_Click(sender As Object, e As EventArgs) Handles BtnConsu.Click
        FrmFiltro.Show()
    End Sub

#End Region

#Region "VALIDACIONES PROCEDIMIENTOS DE GUARDAR USUARIO"

    'BOTON GUARDAR
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        'ValidarUsuarios()
        'revisamos la conexion
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        'REVISO SI LOS CAMPOS EXTAS VACIOS
        If Me.TxtCedula.Text.Equals("") = False Then
            If ExisteCedula(Me.TxtCedula.Text) = False And ExisteUsuario(Me.TxtUserName.Text) = False Then
                'llamo al guardar 
                ValidayGuarda()
            Else
                MsgBox("No se puede Guardar, ya hay un registro con la misma Cédula ó Usuario!", MsgBoxStyle.Information, "AppMinerGold")
                'pocisiono el cursor
                Me.GroupBox2.Select()
                Me.TxtCedula.Select()
                Me.TxtCedula.Focus()
            End If
        Else
            MsgBox("El Campo se debe Ingresar una Cédula ó Usuario! ", MsgBoxStyle.Information, "AppMinerGold")
            Me.GroupBox2.Select()
            Me.TxtCedula.Select()
            Me.TxtCedula.Focus()
        End If
    End Sub

    'VALIDA CEDULA DUPLICADAS AL GUARDAR
    Private Sub ValidarUsuarios()
        If Me.TxtCedula.Text = "" Then
            MsgBox("El Campo se debe Ingresar una Cédula de un Usuario! ", MsgBoxStyle.Critical, "AppMinerGold")
            Me.TxtCedula.Focus()
        Else
            Dim encontro As Integer
            Dim cmd As New OleDb.OleDbCommand

            encontro = 0
            'revisamos la conexion
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            'ejecutamos la consulta
            cmd = New OleDb.OleDbCommand("SELECT * FROM Usuarios WHERE cedula_user='" & Me.TxtCedula.Text & "' ", conn) With {
                .Connection = conn
            }
            Dim dr As OleDb.OleDbDataReader
            dr = cmd.ExecuteReader()
            Try
                Do While dr.Read
                    encontro = 1
                Loop
            Catch ex As Exception
                MsgBox("Ha ocurrido un Error en el Ingreso de Usuarios! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
            End Try

            conn.Close()
            If (encontro = 1) Then
                MsgBox("No se puede Guardar, ya hay un registro con la misma Cédula del Usuario!", MsgBoxStyle.Exclamation, "AppMinerGold")
                'pocisiono el cursor
                Me.GroupBox2.Select()
                Me.TxtCedula.Select()
                Me.TxtCedula.Focus()
            Else
                'llamo al validador 
                ValidayGuarda()
            End If
        End If

    End Sub

    'FUNCION VALIDA USUARIO REPETIDO DE CEDULA
    Function ExisteCedula(ByVal ced_user As String) As Boolean
        'DECLARO VARIABLE DE RESULTADO INICIADA EN FALSE 
        Dim ResulCedu As Boolean = False
        Try
            cmd = New OleDbCommand("SELECT * FROM Usuarios WHERE cedula_user='" & Me.TxtCedula.Text & "' ", conn)
            'RECORRE LOS REGISTRO EN LA BASE DE DATOS
            dr = cmd.ExecuteReader
            'SI EXISTE UN REGISTRO REPETIDO CAMBIA A VERDADERO = TRUE
            'SI NO SE CUMPLE SIGUE EN FALSE
            If dr.Read Then
                ResulCedu = True
            End If
            'CIERRO EL DATAREADER
            dr.Close()
        Catch ex As Exception
            MsgBox("Error de procedimiento: " + ex.ToString)
        End Try
        Return ResulCedu
    End Function

    'FUNCION VALIDA USUARIO REPETIDO DE CEDULA
    Function ExisteUsuario(ByVal nom_user As String) As Boolean
        'DECLARO VARIABLE DE RESULTADO INICIADA EN FALSE 
        Dim ResulUser As Boolean = False
        Try
            cmd = New OleDbCommand("SELECT * FROM Usuarios WHERE usuario='" & Me.TxtUserName.Text & "' ", conn)
            'RECORRE LOS REGISTRO EN LA BASE DE DATOS
            dr = cmd.ExecuteReader
            'SI EXISTE UN REGISTRO REPETIDO CAMBIA A VERDADERO = TRUE
            'SI NO SE CUMPLE SIGUE EN FALSE
            If dr.Read Then
                ResulUser = True
            End If
            'CIERRO EL DATAREADER
            dr.Close()
        Catch ex As Exception
            MsgBox("Error de procedimiento: " + ex.ToString)
        End Try
        Return ResulUser
    End Function

    'PROCESO PARA VALIDAR CAMPOS VACIOS EN GUARDAR
    Private Sub ValidayGuarda()
        If Me.TxtNombre.TextLength > 0 And Me.TxtApellido.TextLength > 0 And Me.TxtCedula.TextLength > 0 And Me.TxtDireccion.TextLength > 0 And Me.TxtTelFijo.TextLength > 0 And Me.TxtCiudad.TextLength > 0 And Me.TxtCodigo.TextLength > 0 And Me.TxtUserName.TextLength > 0 And Me.TxtPassword.TextLength > 0 And Me.TxtEmail.TextLength > 0 Then
            'llamo el  procedimiento
            Guardar()
            'cierro conexion
            conn.Close()
            'para limpiar los campos
            Call Limpiar_cajas_de_texto()
            'habilito campo
            Me.TxtBuscar.Enabled = True
            'deshabilitar los campor de texto
            Me.TxtID.Enabled = False
            Me.TxtNombre.Enabled = False
            Me.TxtApellido.Enabled = False
            Me.TxtCedula.Enabled = False
            Me.TxtTelFijo.Enabled = False
            Me.TxtTelcel.Enabled = False
            Me.CboSexo.Enabled = False
            Me.DTP_FechaNace.Enabled = False
            Me.TxtDireccion.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.TxtEmail.Enabled = False
            Me.TxtCodigo.Enabled = False
            Me.CboCargo.Enabled = False
            Me.TxtUserName.Enabled = False
            Me.TxtPassword.Enabled = False
            Me.CboTipo_User.Enabled = False
            Me.Cbo_efectivo.Enabled = False

            'habilitamos los botones
            Me.BtnBuscar.Enabled = True
            Me.BtnNuevo.Enabled = True

            'desabilitamos los botones
            Me.BtnNewBuscar.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnEliminar.Enabled = False

            'SELECIONAR COMBOS
            Me.CboSexo.Text = "SELECCIONE"
            Me.CboCargo.Text = "SELECCIONE"

            'posicionamos en cursor
            Me.TxtBuscar.Focus()
        Else
            'posicionamos en cursor
            MsgBox("Un Campo está debe estar vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")

        End If
    End Sub

    'PROCEDIMIENTO PARA GUARDAR DATOS
    Private Sub Guardar()
        'variables de fecha de auditoria
        Dim fechaC As Date = CDate(Format(Date.Now.Date))
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        'revisamos la conexion
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        'creamos las variables de fechas
        Dim FechaN As String
        FechaN = CStr(DTP_FechaNace.Value.Date)

        Dim Clave As String
        Encripta(TxtPassword.Text) : Clave = ResultadoENCRIP

        Try

            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            sql = "INSERT INTO Usuarios (cedula_user, nom_user, apell_user, sexo_user, fechanace_user, 
                  telfijo_user, telcel_user, ciudad_user, dire_user, correo_user, codigo_user, cargo_user, 
                  usuario, clave, tipo_user, tipo_efect, fecha_creado, fecha_modifica) VALUES ( '" & TxtCedula.Text & "', '" & TxtNombre.Text & "', '" & TxtApellido.Text & "', 
                  '" & CboSexo.Text & "', '" & FechaN & "', '" & TxtTelFijo.Text & "','" & TxtTelcel.Text & "', '" & TxtCiudad.Text & "', 
                  '" & TxtDireccion.Text & "', '" & TxtEmail.Text & "', '" & TxtCodigo.Text & "', '" & CboCargo.Text & "', 
                  '" & TxtUserName.Text & "','" & ResultadoENCRIP & "','" & CboTipo_User.Text & "','" & Cbo_efectivo.Text & "','" & fechaC & "', '" & fechaM & "')"

            cmd.CommandText = sql

            'ejecutamos la consulta
            cmd.ExecuteNonQuery()

            MsgBox("Los datos se han guardado Correctamente! ", MsgBoxStyle.Information, "AppMinerGold")

            'cierro conexion
            conn.Close()

        Catch ex As Exception
            MsgBox("Error al guardar los datos " & ex.Message, MsgBoxStyle.Information, "AppMinerGold")
        End Try

    End Sub

#End Region

#Region "VALIDACIONES PROCEDIMIENTOS DE MODIFICAR GUARDAR USUARIO"

    'BOTON MODIFICAR
    Private Sub BtnModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModifica.Click

        'deshabilitamos los botones
        Me.BtnNewBuscar.Enabled = False
        Me.BtnNuevo.Enabled = False
        Me.BtnGuardar.Enabled = False
        Me.BtnModifica.Enabled = False
        Me.BtnEliminar.Enabled = False

        'habilitanos los botones
        Me.BtnGuardaCambios.Enabled = True

        'deshabilitar los campor de texto
        Me.TxtBuscar.Enabled = False

        'habilitar los campos de texto
        Me.TxtNombre.Enabled = True
        Me.TxtApellido.Enabled = True
        Me.TxtCedula.Enabled = True
        Me.TxtTelFijo.Enabled = True
        Me.TxtTelcel.Enabled = True
        Me.CboSexo.Enabled = True
        Me.DTP_FechaNace.Enabled = True
        Me.TxtDireccion.Enabled = True
        Me.TxtCiudad.Enabled = True
        Me.TxtEmail.Enabled = True
        Me.TxtCodigo.Enabled = True
        Me.CboCargo.Enabled = True
        Me.TxtUserName.Enabled = True
        Me.TxtPassword.Enabled = True
        Me.CboTipo_User.Enabled = True
        Me.Cbo_efectivo.Enabled = True

        'posicionamos el cursor
        Me.TxtNombre.Focus()


    End Sub

    'BOTON GUARDA CAMBIOS
    Private Sub BtnGuardaCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardaCambios.Click

        ValidayGuardaModifica()

    End Sub

    'PROCESO PARA VALIDAR CAMPOS VACIOS EN GUARDAR CUANDO MODIFICA
    Private Sub ValidayGuardaModifica()
        If Me.TxtNombre.TextLength > 0 And Me.TxtApellido.TextLength > 0 And Me.TxtCedula.TextLength > 0 And Me.TxtDireccion.TextLength > 0 And Me.TxtTelFijo.TextLength > 0 And Me.TxtCiudad.TextLength > 0 And Me.TxtCodigo.TextLength > 0 And Me.TxtUserName.TextLength > 0 And Me.TxtPassword.TextLength > 0 And Me.TxtEmail.TextLength > 0 Then
            'llamo el  procedimiento
            Guarda_cambios()
            'para limpiar los campos
            Call Limpiar_cajas_de_texto()

            'deshabilitar los campor de texto
            Me.TxtID.Enabled = False
            Me.TxtNombre.Enabled = False
            Me.TxtApellido.Enabled = False
            Me.TxtCedula.Enabled = False
            Me.TxtTelFijo.Enabled = False
            Me.TxtTelcel.Enabled = False
            Me.CboSexo.Enabled = False
            Me.DTP_FechaNace.Enabled = False
            Me.TxtDireccion.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.TxtEmail.Enabled = False
            Me.TxtCodigo.Enabled = False
            Me.CboCargo.Enabled = False
            Me.TxtUserName.Enabled = False
            Me.TxtPassword.Enabled = False
            Me.CboTipo_User.Enabled = False
            Me.Cbo_efectivo.Enabled = False

            'habilitamos los botones
            Me.BtnBuscar.Enabled = True
            Me.BtnNuevo.Enabled = True

            'desabilitamos los botones
            Me.BtnNewBuscar.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnEliminar.Enabled = False

            'habilito campo d etexto
            Me.TxtBuscar.Enabled = True

            'SELECIONAR COMBOS
            Me.CboSexo.Text = "SELECCIONE"
            Me.CboCargo.Text = "SELECCIONE"

            'posicionamos en cursor
            Me.TxtBuscar.Focus()

        Else
            MsgBox("Un Campo debe estar vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")

        End If
    End Sub

    'PROCEDIMIENTO GUARDA CAMBIOS 
    Private Sub Guarda_cambios()
        'variables de fecha de auditoria
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        'creamos las variables de fechas
        Dim FechaN As String
        FechaN = CStr(DTP_FechaNace.Value.Date)

        Dim cmd As New OleDb.OleDbCommand

        'revisamos la conexin a la base de datos
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim Clave As String
        Encripta(TxtPassword.Text) : Clave = ResultadoENCRIP

        Try
            ' Verifico que haya escrito el codigo
            If Me.TxtBuscar.Text = "" Then
                ' Si no lo escribió, mando mensaje de error
                MsgBox("Debe ingresar una Cédula", MsgBoxStyle.Exclamation, "AppMinerGold")
                Me.TxtBuscar.Select()
            Else
                Dim sqlquery As String = "UPDATE Usuarios SET cedula_user = '" & Me.TxtCedula.Text & "', nom_user = '" & Me.TxtNombre.Text & "', apell_user = '" & Me.TxtApellido.Text & "'," &
                "sexo_user = '" & Me.CboSexo.Text & "', fechanace_user = '" & FechaN & "', telfijo_user = '" & Me.TxtTelFijo.Text & "', telcel_user = '" & Me.TxtTelcel.Text & "'," &
                "ciudad_user = '" & Me.TxtCiudad.Text & "', dire_user = '" & Me.TxtDireccion.Text & "', correo_user = '" & Me.TxtEmail.Text & "', codigo_user = '" & Me.TxtCodigo.Text & "'," &
                "cargo_user = '" & Me.CboCargo.Text & "', usuario = '" & Me.TxtUserName.Text & "', clave = '" & ResultadoENCRIP & "'," &
                "tipo_user = '" & Me.CboTipo_User.Text & "', tipo_efect = '" & Me.Cbo_efectivo.Text & "', fecha_modifica = '" & fechaM & "' WHERE cedula_user='" & Me.TxtCedula.Text & "'"


                cmd = New OleDb.OleDbCommand(sqlquery, conn)

                'MsgBox(sqlquery)

                'ejecutamos la consulta
                cmd.ExecuteNonQuery()

                'CIERRO LA CONEXION
                conn.Close()

                'presentamos el mensaje 
                MsgBox("Registro actualizado exitosamente", MsgBoxStyle.Information, "AppMinerGold")

            End If

        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Exclamation, "AppMinerGold")

            'para limpiar los campos
            Call Limpiar_cajas_de_texto()

            'deshabilitar los campor de texto
            Me.TxtID.Enabled = False
            Me.TxtNombre.Enabled = False
            Me.TxtApellido.Enabled = False
            Me.TxtCedula.Enabled = False
            Me.TxtTelFijo.Enabled = False
            Me.TxtTelcel.Enabled = False
            Me.CboSexo.Enabled = False
            Me.DTP_FechaNace.Enabled = False
            Me.TxtDireccion.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.TxtEmail.Enabled = False
            Me.TxtCodigo.Enabled = False
            Me.CboCargo.Enabled = False
            Me.TxtUserName.Enabled = False
            Me.TxtPassword.Enabled = False
            Me.CboTipo_User.Enabled = False
            Me.Cbo_efectivo.Enabled = False

            'habilitamos los botones
            Me.BtnBuscar.Enabled = True
            Me.BtnNuevo.Enabled = True

            'desabilitamos los botones
            Me.BtnNewBuscar.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnEliminar.Enabled = False

            'posicionamos en cursor
            Me.TxtBuscar.Focus()

        End Try

    End Sub

#End Region

#Region "VALIDACIONES Y PROCEDIMIENTOS"

    'limpia las cajas de texto
    Private Sub Limpiar_Cajas(ByVal f As Form)
        ' recorrer todos los controles del formulario indicado  
        For Each c As Control In f.Controls
            'If TypeOf c Is TextBox Then
            '    c.Text = "" ' eliminar el texto  
            'End If
            If TypeOf c Is ComboBox Then
                c.Text = "-- Seleccione Item --" ' eliminar el texto  
            End If
        Next
    End Sub

    'Limpiar cajas
    Private Sub Limpiar_cajas_de_texto()
        Me.TxtBuscar.Clear()
        Me.TxtID.Clear()
        Me.TxtNombre.Clear()
        Me.TxtApellido.Clear()
        Me.TxtCedula.Clear()
        Me.TxtTelFijo.Clear()
        Me.TxtTelcel.Clear()
        'Me.CboSexo.Text = Nothing
        Me.DTP_FechaNace.Text = Date.Now.Date
        Me.TxtDireccion.Clear()
        Me.TxtCiudad.Clear()
        Me.TxtEmail.Clear()
        Me.TxtCodigo.Clear()
        'Me.CboCargo.Text = Nothing
        Me.TxtUserName.Clear()
        Me.TxtPassword.Clear()
        'Me.CboTipo_User.Text = Nothing
        'Me.Cbo_efectivo.Text = Nothing

        'UBICO EL CURSOR
        Me.TxtBuscar.Focus()

    End Sub

    'Valido los procedimientos de ingreso duplicados
    Private Sub Validar()
        Dim encontro As Integer
        Dim cmd As New OleDb.OleDbCommand

        encontro = 0

        'revisamos la conexion
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'ejecutamos la consulta
        cmd = New OleDbCommand("SELECT * FROM Usuarios WHERE cedula='" & Me.TxtCedula.Text & "'", conn) With {
            .Connection = conn
        }
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()
        Try
            Do While dr.Read
                encontro = 1
            Loop
        Catch ex As Exception
            MsgBox("Ha ocurrido un Error!", MsgBoxStyle.Critical, "AppMinerGold")
        End Try
        conn.Close()

        'validamos los campos vacios
        ValidaDatos()

        If (encontro = 1) Then
            MsgBox("no se puede Guardar, ya hay un registro con la misma cédula!", MsgBoxStyle.Exclamation, "AppMinerGold")
            'pocisiono el cursor
            Me.TxtCedula.Focus()
        Else
            Guardar()
        End If


    End Sub

    'valida todos los campos no pueden estar vacios
    Private Function ValidaDatos() As Boolean
        If Len(Me.TxtNombre.Text.Trim) = 0 Then MsgBox("El Campo Nombre está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.TxtNombre.Focus() : Return True : Exit Function
        If Len(Me.TxtApellido.Text.Trim) = 0 Then MsgBox("El Campo Apellido está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.TxtApellido.Focus() : Return True : Exit Function
        If Len(Me.TxtCedula.Text.Trim) = 0 Then MsgBox("El Campo Cédula está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.TxtCedula.Focus() : Return True : Exit Function
        If Len(Me.TxtDireccion.Text.Trim) = 0 Then MsgBox("El Campo Dirección está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.TxtDireccion.Focus() : Return True : Exit Function
        If Len(Me.TxtTelFijo.Text.Trim) = 0 Then MsgBox("El Campo Teléfono está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.TxtTelFijo.Focus() : Return True : Exit Function
        If Len(Me.TxtCiudad.Text.Trim) = 0 Then MsgBox("El Campo Ciudad está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.TxtCiudad.Focus() : Return True : Exit Function
        If Len(Me.CboCargo.Text.Trim) = 0 Then MsgBox("El Campo Cargo está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.CboCargo.Focus() : Return True : Exit Function
        If Len(Me.TxtCodigo.Text.Trim) = 0 Then MsgBox("El Campo Código está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.TxtCodigo.Focus() : Return True : Exit Function
        If Len(Me.TxtUserName.Text.Trim) = 0 Then MsgBox("El Campo Usuario está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.TxtUserName.Focus() : Return True : Exit Function
        If Len(Me.TxtPassword.Text.Trim) = 0 Then MsgBox("El Campo Clave está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.TxtPassword.Focus() : Return True : Exit Function
        If Len(Me.TxtEmail.Text.Trim) = 0 Then MsgBox("El Campo Email está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.TxtEmail.Focus() : Return True : Exit Function
        Return True
    End Function

#End Region

#Region "EVENTOS DEL KEYPRESS"

    'valida los campos de Busqueda por cedula SOLO NUMEROS
    Private Sub TxtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBuscar.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'valida los campos de Nombre SOLO LETRAS
    Private Sub TxtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress
        'valida los campos de letras
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        'Para validar el enter en el campo de texto
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida los campos de Apellido SOLO LETRAS
    Private Sub TxtApellido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtApellido.KeyPress
        'valida los campos de letras
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'valida enter paraa el campo de texto
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    'valida los campos de Cedula SOLO NUMEROS
    Private Sub TxtCedula_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCedula.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'valida enter al campo de texto
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida los campos de telefono Fijo SOLO NUMEROS
    Private Sub TxtTelFijo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelFijo.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'valida el campo enter 
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida los campos de telefono Celular SOLO NUMEROS
    Private Sub TxtTelCel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelcel.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'valida el campo enter 
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida enter sexo
    Private Sub CboSexo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboSexo.KeyPress
        'valida el campo enter 
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida enter fecha
    Private Sub DTP_FechaNace_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DTP_FechaNace.KeyPress
        'valida el campo enter 
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida el campor enter direccion
    Private Sub TxtDireccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDireccion.KeyPress
        'VALIDA ENTER
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida los campos de ciudad SOLO LETRAS
    Private Sub Txtciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCiudad.KeyPress
        'valida los campos de letras
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'valida el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida enter en campo texto email
    Private Sub TxtEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEmail.KeyPress
        'VALIDA ENTER
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida enter en campo texto codigo
    Private Sub TxtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        'VALIDA ENTER
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida enter cargo
    Private Sub CboCargo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboCargo.KeyPress
        'VALIDA ENTER
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida tecla enter campo usuario
    Private Sub TxtUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUserName.KeyPress
        'VALIDA ENTER
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida tecla enter campo clave
    Private Sub TxtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassword.KeyPress
        'VALIDA ENTER
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida enter en combo tipo
    Private Sub CboTipo_User_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboTipo_User.KeyPress
        'VALIDA ENTER
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


#End Region

#Region "EVENTOS CHANGED DEL FORMULARIO PARA LETRAS EN MAYUSCULAS"

    ' Mayúsculas TxtNombre  
    Private Sub TxtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged
        Me.TxtNombre.CharacterCasing = CharacterCasing.Upper
    End Sub

    ' Mayúsculas TxtApellido  
    Private Sub TxtApellido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtApellido.TextChanged
        Me.TxtApellido.CharacterCasing = CharacterCasing.Upper
    End Sub

    ' Mayúsculas TxtCiudad  
    Private Sub TxtCiudad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCiudad.TextChanged
        Me.TxtCiudad.CharacterCasing = CharacterCasing.Upper
    End Sub


#End Region

#Region "CONVERTIR A MINUSCULAS Y VALIDAR CORREO"

    'CONVIERTE DE MINUSCULAS A MAYUSCULAS MIENTRAS ESCRIBE
    Private Sub Txtemail_TextChanged(sender As Object, e As EventArgs) Handles TxtEmail.TextChanged
        Dim I As Integer
        Me.TxtEmail.Text = LCase(TxtEmail.Text)
        I = Len(TxtEmail.Text)
        Me.TxtEmail.SelectionStart = I
    End Sub

    'VALIDAR CORREO CON EL FORMATO CORRECTO
    Public Function Validar_Mail(ByVal sMail As String) As Boolean
        ' retorna true o false   
        Return Regex.IsMatch(sMail, "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
    End Function

    'VALIDA EL TECTO ESCRITO DEL CORREO
    Private Sub Txtemail_Leave(sender As Object, e As EventArgs) Handles TxtEmail.Leave
        If Validar_Mail(LCase(TxtEmail.Text)) = False Then
            MsgBox("Dirección de correo con formato Invalido ej: nombre@dominio.com", MessageBoxIcon.Exclamation, "AppMinerGold")
            TxtEmail.Focus()
            TxtEmail.SelectAll()
        End If
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub



#End Region


    ''valida todos los campos no pueden estar vacios
    'Private Function ValidaUsuariosVacios() As Boolean
    '    If Len(Me.TxtNombre.Text.Trim) = 0 Then
    '        MsgBox("El Campo Nombre está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")
    '        Me.TxtNombre.Focus()
    '        Return True
    '        Exit Function
    '        'End If
    '    ElseIf Len(Me.TxtApellido.Text.Trim) = 0 Then
    '        MsgBox("El Campo Apellido está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")
    '        Me.TxtApellido.Focus()
    '        Return True
    '        Exit Function
    '        'End If
    '    ElseIf Len(Me.TxtCedula.Text.Trim) = 0 Then
    '        MsgBox("El Campo Cédula está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")
    '        Me.TxtCedula.Focus()
    '        Return True
    '        Exit Function
    '        'End If
    '    ElseIf Len(Me.TxtDireccion.Text.Trim) = 0 Then
    '        MsgBox("El Campo Dirección está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")
    '        Me.TxtDireccion.Focus()
    '        Return False
    '        Exit Function
    '        'End If
    '    ElseIf Len(Me.TxtTelFijo.Text.Trim) = 0 Then
    '        MsgBox("El Campo Teléfono está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")
    '        Me.TxtTelFijo.Focus()
    '        Return False
    '        Exit Function
    '        'End If
    '    ElseIf Len(Me.TxtCiudad.Text.Trim) = 0 Then
    '        MsgBox("El Campo Ciudad está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")
    '        Me.TxtCiudad.Focus()
    '        Return False
    '        Exit Function
    '        'End If
    '    ElseIf Len(Me.CboCargo.Text.Trim) = 0 Then
    '        MsgBox("El Campo Cargo está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")
    '        Me.CboCargo.Focus()
    '        Return False
    '        Exit Function
    '        'End If
    '    ElseIf Len(Me.TxtCodigo.Text.Trim) = 0 Then
    '        MsgBox("El Campo Código está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")
    '        Me.TxtCodigo.Focus()
    '        Return False
    '        Exit Function
    '        'End If
    '    ElseIf Len(Me.TxtUserName.Text.Trim) = 0 Then
    '        MsgBox("El Campo Usuario está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")
    '        Me.TxtUserName.Focus()
    '        Return False
    '        Exit Function
    '        'End If
    '    ElseIf Len(Me.TxtPassword.Text.Trim) = 0 Then
    '        MsgBox("El Campo Clave está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")
    '        Me.TxtPassword.Focus()
    '        Return False
    '        Exit Function
    '        'End If
    '    ElseIf Len(Me.TxtEmail.Text.Trim) = 0 Then
    '        MsgBox("El Campo Email está vacío, favor agregar datos", MsgBoxStyle.Critical, "AppMinerGold")
    '        Me.TxtEmail.Focus()
    '        Return False
    '        Exit Function
    '    End If

    '    Return True

    'End Function



End Class