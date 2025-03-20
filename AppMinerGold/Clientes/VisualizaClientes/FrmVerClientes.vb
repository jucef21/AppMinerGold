Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmVerClientes

    'CREAR VARIABLES 
    Private strConexion As OleDb.OleDbConnection
    Private DS_CA As DataSet
    Private DA_CA As OleDbDataAdapter
    Private Posicion_CA As Integer

    'CARGUE DEL  FORMULARIO
    Private Sub FrmVerClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'INHABILITO LOS CAMPOS
        Me.TxtCedula.Enabled = False
        Me.TxtNombres.Enabled = False
        Me.TxtApellidos.Enabled = False
        Me.TxtDireccion.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.TxtTelefono.Enabled = False
        Me.TxtCorreo.Enabled = False
        Me.PictureFoto.Enabled = False
        Me.PictureHuella.Enabled = False

        'limpio el formulario
        LimpiarCampos()

        'botones de navegacion activados
        Me.BtnInicio.Enabled = False
        Me.BtnAnterior.Enabled = False
        Me.BtnSiguiente.Enabled = False
        Me.BtnFin.Enabled = False

        Me.BtnCargaDatos.Enabled = True
        Me.BtnSalir.Enabled = True
        Me.BtnBuscar.Enabled = True

        'UBICO EL CURSOR
        Me.BtnCargaDatos.Select()
        Me.BtnCargaDatos.Focus()

        Me.PictureFoto.Image = Global.AppMinerGold.My.Resources.Resources.Foto
        Me.PictureHuella.Image = Global.AppMinerGold.My.Resources.Resources.huella

    End Sub

#Region "'PROCEDIMIENTOS DEL FORMULARIO"

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
        Dim num As Integer
        num = 111111111
        Me.DA_CA = New OleDbDataAdapter("SELECT * FROM Clientes WHERE ced_cl <>" & num, conn)
        Dim consulta As OleDbCommandBuilder = New OleDbCommandBuilder(DA_CA)
        Me.DS_CA = New DataSet
        'conn.Open()
        Me.DA_CA.Fill(DS_CA, "Clientes")
        conn.Close()
        Me.Posicion_CA = 0
    End Sub

    'FUNCIONES DE CARGAR OBJETOS A LA BASE DE DATOS
    'Convertir Una Imagen en Byte
    Public Function GetByteArrayFromImage(ByVal img As Image) As Byte()
        Dim ms As New System.IO.MemoryStream
        img.Save(ms, Imaging.ImageFormat.Bmp)
        Dim outBytes(CInt(ms.Length - 1)) As Byte
        ms.Seek(0, System.IO.SeekOrigin.Begin)
        ms.Read(outBytes, 0, CInt(ms.Length))
        Return outBytes
    End Function

    'Convertir Byte en Una Imagene
    Public Function GetImageFromByteArray(ByVal bytes As Byte()) As Bitmap
        Return CType(Bitmap.FromStream(New IO.MemoryStream(bytes)), Bitmap)
    End Function


    '=================

    Dim DRow As DataRow 'definimos una especie de array para almacenar datos 1 columna por campo
    Dim dt As New DataTable
    Dim da As SqlDataAdapter

    Function MostrarFoto()
        DRow = Me.DS_CA.Tables("Clientes").Rows(Me.Posicion_CA)
        Try
            'extraer del MyData el campo "foto",de tipo byte
            Dim MyData As Byte() = DirectCast(DRow("img"), Byte())
            'Convertimos en datos validos para campo de foto con el stream
            Dim Stream = New MemoryStream(MyData)
            'cargamos el resultado obtenido en el campo image del picture box 'cajadefotos2'
            PictureFoto.Image = Image.FromStream(Stream)
        Catch ex As Exception
            MessageBox.Show("Foto pendiente de Actualizar", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.PictureFoto.Image = Global.AppMinerGold.My.Resources.Resources.FotoX
        End Try
    End Function

    Function MostrarHuella()
        ' Mostramos la imagen en el control PictureBox
        Dim cedula As String = Me.TxtCedula.Text
        Dim Img As String = cedula + ".jpg"
        Dim SaveDirectory As String = "C:\FotoProHuella\"
        Dim Filename As String = Path.GetFileName(Img)
        Dim SavePath As String = Path.Combine(SaveDirectory, Filename)

        If System.IO.File.Exists(SavePath) Then
            PictureHuella.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(SavePath))
        Else
            Me.PictureHuella.Image = Global.AppMinerGold.My.Resources.Resources.huellaX
        End If
    End Function



    'CARGA DATOS DE LOS BOTONES DE NAVEGACION
    Private Sub CargarDatos()
        'obtener un objeto con la fila actual
        Dim Drow As DataRow
        Drow = Me.DS_CA.Tables("Clientes").Rows(Me.Posicion_CA)

        'cargar los controles del formulario con valores de los camapos del registro
        Me.TxtCedula.Text = CStr(Drow("ced_cl"))
        Me.TxtNombres.Text = CStr(Drow("nom_cl"))
        Me.TxtApellidos.Text = CStr(Drow("ape_cl"))
        Me.TxtDireccion.Text = CStr(Drow("dire_cl"))
        Me.TxtCiudad.Text = CStr(Drow("ciud_cl"))
        Me.TxtTelefono.Text = CStr(Drow("telc_cl"))
        Me.TxtCorreo.Text = CStr(Drow("correo_cl"))

        'SELECCIONE LA FOTO SI ESTA VACIO COLOCA FOTOX SI NO COLOCA LA SUBIDA
        If PictureFoto.Image Is Nothing Then
            Me.PictureFoto.Image = Global.AppMinerGold.My.Resources.Resources.FotoX
        Else
            MostrarFoto()
        End If

        If PictureHuella.Image Is Nothing Then
            Me.PictureHuella.Image = Global.AppMinerGold.My.Resources.Resources.huellaX
        Else
            MostrarHuella()
        End If

        'mostrar la posicion actual del registro y el numero de registros
        Me.LblRegistros.Text = "Registro No.: " &
        Me.Posicion_CA + 1 & " de " &
        Me.DS_CA.Tables("Clientes").Rows.Count

    End Sub

    'PROCEDIMIENTO LIMPIAR CAMPOS
    Private Sub LimpiarCampos()
        Me.TxtCedula.Clear()
        Me.TxtNombres.Clear()
        Me.TxtApellidos.Clear()
        Me.TxtDireccion.Clear()
        Me.TxtCiudad.Clear()
        Me.TxtTelefono.Clear()
        Me.TxtCorreo.Clear()
        Me.PictureHuella.Image = Global.AppMinerGold.My.Resources.Resources.huella
        Me.PictureFoto.Image = Global.AppMinerGold.My.Resources.Resources.Foto

    End Sub

#End Region

#Region "Botones de navegación"

    'Boton Inicio
    Private Sub BtnInicio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnInicio.Click
        'establece el contadpr en el primer registro
        Me.Posicion_CA = 0

        'carga los datos al formulario
        Me.CargarDatos()

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
            Me.CargarDatos()
        End If

    End Sub

    'boton siguiente
    Private Sub BtnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSiguiente.Click
        'si estamos en el ultimo registro no hacer actual
        If Posicion_CA =
            (Me.DS_CA.Tables("Clientes").Rows.Count - 1) Then
            MessageBox.Show("Último Registro", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'incrementar el marcador de registro y actualizar controles con los datos de registro actual
            Me.Posicion_CA += 1
            'carga los datos al formulario
            Me.CargarDatos()
        End If

    End Sub

    'boton final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        'establecer el marcador de registros en el primero obteniendo el numero de filas que contiene la tabla menos uno
        Me.Posicion_CA = (Me.DS_CA.Tables("Clientes").Rows.Count - 1)

        'carga los datos al formulario
        Me.CargarDatos()

    End Sub


#End Region

#Region "Botones del formulario"

    'BOTON DE CARGAR DATOS
    Private Sub BtnCargaDatos_Click(sender As Object, e As EventArgs) Handles BtnCargaDatos.Click

        Me.Cursor = Cursors.WaitCursor

        'llamo la conexion de datos
        ConectarDatos()

        'botones de navegacion activados
        Me.BtnInicio.Enabled = True
        Me.BtnAnterior.Enabled = True
        Me.BtnSiguiente.Enabled = True
        Me.BtnFin.Enabled = True

        Me.BtnBuscar.Enabled = False
        Me.BtnCargaDatos.Enabled = False
        Me.BtnSalir.Enabled = True

        'cargar los datos de la base de datos
        Me.CargarDatos()

        Me.Cursor = Cursors.Default

    End Sub

    'BOTON DE SALIR
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    'BOTON DE BUSCAR REGISTRO POR CEDULA
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        LimpiarCampos()
        Me.BtnCargaDatos.Enabled = False
        FrmBuscaProve.Show()
    End Sub

#End Region


End Class