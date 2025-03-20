Imports System.Runtime.InteropServices
Imports AForge.Video
Imports AForge.Video.DirectShow

Public Class FrmFoto



#Region "VARIABLES DE LA CAMARA"

    'VARIABLE PARA EL FUNCIONAMIENTO DE LA CAMARA === INICIO
    Dim DATOS As IDataObject
    Dim IMAGEN As Image
    Dim CARPETA As String
    Dim FECHA As String = DateTime.Now.ToShortDateString().Replace("/", "_") + "_" + DateTime.Now.ToLongTimeString().Replace(":", "_")
    Dim DIRECTORIO As String = "C:\FotosCompras"
    Dim DESTINO As String
    Dim CONTADOR As Integer = 1
    Dim CARPETAS_DIARIAS As String

    Dim CAMARA As VideoCaptureDevice
    Dim BMP As Bitmap
    Dim Cap As String = "Capture"

    Public Const WM_CAP As Short = &H400S
    Public Const WM_CAP_DLG_VIDEOFORMAT As Integer = WM_CAP + 41
    Public Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Public Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Public Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Public Const WM_CAP_SEQUENCE As Integer = WM_CAP + 62
    Public Const WM_CAP_FILE_SAVEAS As Integer = WM_CAP + 23
    Public Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Public Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Public Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Public Const WS_CHILD As Integer = &H40000000
    Public Const WS_VISIBLE As Integer = &H10000000
    Public Const SWP_NOMOVE As Short = &H2S
    Public Const SWP_NOSIZE As Short = 1
    Public Const SWP_NOZORDER As Short = &H4S
    Public Const HWND_BOTTOM As Short = 1
    Public Const WM_CAP_STOP As Integer = WM_CAP + 68

    Public iDevice As Integer = 0 ' Current device ID
    Public hHwnd As Integer ' Handle to preview window

    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer
    Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Public Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean
    Public Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWndParent As Integer, ByVal nID As Integer) As Integer
    Public Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean

    'FIN DE CREAR VARIABLE PARA EL FUNCIONAMIENTO DE LA CAMARA === TERMINA

#End Region


    'CARGUE DEL FORM
    Private Sub FrmFoto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'PICTUREBOX FOTO
        Me.PicFoto.Visible = True
        Me.PicFoto.Enabled = True
        Me.PicFoto.Image = Nothing
        Me.PicFoto.Refresh()
        Me.PicFoto.Image = Global.AppMinerGold.My.Resources.Resources.Foto

        Me.BtnStart.Enabled = True
        Me.BtnCapturaF.Enabled = False
        Me.BtnStop.Enabled = False
        Me.BtnStart.Select()
        Me.BtnStart.Focus()
    End Sub

    'CIERRE DEL FORM
    'Private Sub FrmFoto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    '    Try
    '        CAMARA.Stop()
    '        ' PictureBox2.Image = Nothing
    '        Me.PicFoto.Image = Global.AppMinerGold.My.Resources.Resources.Foto
    '    Catch ex As Exception
    '        Me.Dispose()
    '        'PictureBox2.Image = Nothing
    '        Me.PicFoto.Image = Global.AppMinerGold.My.Resources.Resources.Foto
    '    End Try
    '    'eliminar el uso del controlador de la CAMARA
    '    RemoveHandler CAMARA.NewFrame, AddressOf CAPTURAR
    '    Me.Close()
    'End Sub

#Region "PROCEDIMIENTOS PARA EL FUNCIONAMIENTO DE LA CAMARA"

    'CARGA LAS CAMARAS INSTALADAS
    Private Sub CAPTURAR(sender As Object, eventArgs As NewFrameEventArgs)
        'Colocar los datos en el mapa de bits
        BMP = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        'Preséntalo en el Picture Box
        PicFoto.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)
    End Sub

    'PROCEDIMIENTO PARA GUARDAR FOTO
    Private Sub GuardaFoto()
        'Crea el nombre de la carpeta  
        Dim ruta As String = "C:\FotosCompras"
        'Si no existe la carpeta de BackUp la creamos.
        If My.Computer.FileSystem.DirectoryExists(ruta) = False Then
            My.Computer.FileSystem.CreateDirectory(ruta)
        End If

        Dim SaveFileDialog As New SaveFileDialog With {
            .SupportMultiDottedExtensions = True,
            .AddExtension = True,
            .Filter = "Extensión de Imagenes (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png",
            .Title = "Guarda Una Imagen"
        }
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            ruta = "C:\FotosCompras"
            Try
                Dim caption = "Guardar Foto"
                Dim nomImagen As String = SaveFileDialog.FileName
                If IO.File.Exists(nomImagen) Then
                    Dim msg As String = String.Format("Ya existe un archivo con el Número digitado. ¿Desea sobrescribirlo?")
                    Dim dr As DialogResult = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If dr <> DialogResult.Yes Then
                        ' No se desea sobrescribir el archivo existente; cancelamos la operación de BackUp.
                        Return
                    Else
                        PicFoto.Image.Save(SaveFileDialog.FileName, Imaging.ImageFormat.Jpeg)
                        CAMARA.Stop()
                        PicFoto.Image = Nothing
                        Me.BtnStart.Enabled = False
                        Me.BtnCapturaF.Enabled = False
                        Me.BtnStop.Enabled = True
                        Me.PicFoto.Image = Global.AppMinerGold.My.Resources.Resources.FotoOK
                    End If
                Else
                    PicFoto.Image.Save(SaveFileDialog.FileName, Imaging.ImageFormat.Jpeg)
                    CAMARA.Stop()
                    PicFoto.Image = Nothing
                    Me.BtnStart.Enabled = False
                    Me.BtnCapturaF.Enabled = False
                    Me.BtnStop.Enabled = True
                    Me.PicFoto.Image = Global.AppMinerGold.My.Resources.Resources.FotoOK
                End If
            Catch ex As Exception
                MessageBox.Show("Error al tomar foto", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                PicFoto.Image = Nothing
                CAMARA.Start()
                Cap = "Capture"
                Me.BtnStart.Enabled = True
                Me.BtnCapturaF.Enabled = False
                Me.BtnStop.Enabled = False
            End Try
        Else
            Dim CAMARAS As VideoCaptureDeviceForm = New VideoCaptureDeviceForm()
            CAMARA.Start()
            Cap = "Capture"
            Me.BtnStart.Enabled = True
            Me.BtnCapturaF.Enabled = False
            Me.BtnStop.Enabled = False
        End If
    End Sub

#End Region

#Region "BOTONES FUNCIONAMIENTO DE LA CAMARA"

    'BOTON DE TOMAR FOTO
    Private Sub BtnCapturaF_Click(sender As Object, e As EventArgs) Handles BtnCapturaF.Click
        If Cap = "Capture" Then
            CAMARA.Stop()
            Cap = "Start"
            GuardaFoto()
            'ACTIVAMOS BOTONES
            Me.BtnStart.Enabled = False
            Me.BtnCapturaF.Enabled = False
            Me.BtnStop.Enabled = False
            Me.BtnX.Select()
            Me.BtnX.Focus()
        Else
            CAMARA.Stop()
            Cap = "Start"
            GuardaFoto()
            'ACTIVAMOS BOTONES
            Me.BtnStart.Enabled = False
            Me.BtnCapturaF.Enabled = False
            Me.BtnStop.Enabled = False
            Me.BtnX.Select()
            Me.BtnX.Focus()
        End If
    End Sub

    'INICIA LA CAMARA
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        'PICTUREBOX FOTO
        Me.PicFoto.Visible = True
        Me.PicFoto.Enabled = True
        Me.PicFoto.Image = Nothing
        Me.PicFoto.Refresh()

        'CARGO LA CAMARA
        Dim CAMARAS As VideoCaptureDeviceForm = New VideoCaptureDeviceForm()
        'DIALOGO CAMARAS DISPONIBLES
        If CAMARAS.ShowDialog() = DialogResult.OK Then
            'CAMARA ELEGIDA
            CAMARA = CAMARAS.VideoDevice
            ' EJECUTARA CADA VEZ QUE SE GENERE UNA IMAGEN
            AddHandler CAMARA.NewFrame, New NewFrameEventHandler(AddressOf CAPTURAR)
            'INICIA LA PRESENTACION DE IMAGENES EN EL PICTUREBOX
            CAMARA.Start()
            'ACTIVAMOS BOTONES FOTO
            Me.BtnStart.Enabled = False
            Me.BtnCapturaF.Enabled = True
            Me.BtnStop.Enabled = False
            Me.BtnCapturaF.Select()
            Me.BtnCapturaF.Focus()
        Else
            MessageBox.Show("Error no hay Camaras disponibles. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ACTIVAMOS BOTONES FOTO
            Me.BtnStart.Enabled = True
            Me.BtnCapturaF.Enabled = False
            Me.BtnStop.Enabled = False
            Me.BtnStart.Select()
            Me.BtnStart.Focus()
        End If
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub


#End Region


End Class