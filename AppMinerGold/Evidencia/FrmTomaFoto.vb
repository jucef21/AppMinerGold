Imports System.Runtime.InteropServices

Public Class FrmTomaFoto

    'CARGUE DEL FORMULARIO
    Private Sub FrmTomaFoto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        INICIAR.Enabled = True
        CAPTURAR.Enabled = False
        FORMATO.Enabled = False
        CAPTURAR.Enabled = False
        GUARDAR.Enabled = False
        Apagar.Enabled = True

    End Sub

#Region "VARIABLES DE LA CAMARA"

    Dim DATOS As IDataObject
    Dim IMAGEN As Image
    Dim CARPETA As String
    Dim FECHA As String = DateTime.Now.ToShortDateString().Replace("/", "_") + "_" + DateTime.Now.ToLongTimeString().Replace(":", "_")
    'Dim DIRECTORIO As String = "C:\Users\SALVADOR\Desktop\" ' AQUI COLOCA LA RUTA A TU ESCRITORIO
    Dim DIRECTORIO As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    Dim DESTINO As String
    Dim CONTADOR As Integer = 1
    Dim CARPETAS_DIARIAS As String
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

#End Region

    'CARGA LAS CAMARAS INSTALADAS
    Private Sub LoadDeviceList()
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0
        Do
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
            If bReturn Then lstDevices.Items.Add(strName.Trim)
            x += 1
        Loop Until bReturn = False
    End Sub

    'INICIA LA CAMARA Abre la Vista
    Public Sub OpenPreviewWindow()
        Dim iHeight As Integer = VISOR.Height
        Dim iWidth As Integer = VISOR.Width
        'Abrir ventana de vista previa en picturebox
        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 320, 240, VISOR.Handle.ToInt32, 0)
        ' Conectarse al dispositivo
        SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0)
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            'Establecer la escala de vista previa
            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)
            'Establecer la tasa de vista previa en milisegundos
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)
            'Comienza a previsualizar la imagen desde la cámara.
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)
            ' Cambiar el tamaño de la ventana para ajustar en picturebox
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, VISOR.Width, VISOR.Height, SWP_NOMOVE Or SWP_NOZORDER)
            'abre resolucion del formato
            SendMessage(hHwnd, WM_CAP_DLG_VIDEOFORMAT, 320, 240)
        Else
            ' Error al conectar al dispositivo cerrar ventana
            MsgBox("No hay Cámaras Conectadas", MsgBoxStyle.Information, "AppMinerGold")
            DestroyWindow(hHwnd)
        End If
    End Sub

    'Public Sub OpenPreviewWindowCliente()
    '    'Abrir ventana de vista previa en picturebox
    '    hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 600, 480, FrmEvidencia.PicFoto.Handle.ToInt32, 0)
    '    'Conectar al dispositivo
    '    SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0)
    '    If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
    '        'Establecer la escala de vista previa
    '        SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)
    '        'Establecer la velocidad de vista previa en milisegundos
    '        SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)
    '        'Comience a previsualizar la imagen de la cámara
    '        SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)
    '        'Cambiar el tamaño de la ventana para que quepa en el cuadro de imagen
    '        SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, FrmEvidencia.PicFoto.Width, FrmEvidencia.PicFoto.Height, SWP_NOMOVE Or SWP_NOZORDER)
    '    Else
    '        'Error al conectarse al dispositivo cerrar ventana
    '        DestroyWindow(hHwnd)

    '    End If
    'End Sub

    'Public Sub CapturarCliente()
    '    'Copiar imagen al portapapeles
    '    SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
    '    'Obtenga una imagen del portapapeles y conviértala en un mapa de bits
    '    DATOS = Clipboard.GetDataObject()
    '    IMAGEN = CType(DATOS.GetData(GetType(System.Drawing.Bitmap)), Image)
    '    Me.PCAPTURA.Image = IMAGEN
    '    GUARDAR.Visible = True
    'End Sub

    'APAGA LA CAMARA
    Public Sub ClosePreviewWindow()
        'Desconectarse del dispositivo
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, 0, 0)
        'Cierra la Ventana
        DestroyWindow(hHwnd)
    End Sub

    Private Sub INICIAR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INICIAR.Click
        'Load And Capture Device
        OpenPreviewWindow()
        INICIAR.Enabled = False
        FORMATO.Enabled = True
        CAPTURAR.Enabled = False
        GUARDAR.Enabled = False
        Apagar.Enabled = True

    End Sub

    Private Sub CAPTURAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CAPTURAR.Click
        ' Copy image to clipboard
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
        ' Get image from clipboard and convert it to a bitmap
        DATOS = Clipboard.GetDataObject()
        IMAGEN = CType(DATOS.GetData(GetType(System.Drawing.Bitmap)), Image)
        PCAPTURA.Image = IMAGEN

        INICIAR.Enabled = False
        FORMATO.Enabled = False
        CAPTURAR.Enabled = False
        GUARDAR.Enabled = True
        Apagar.Enabled = True

    End Sub

    Private Sub FORMATO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FORMATO.Click

        SendMessage(hHwnd, WM_CAP_DLG_VIDEOFORMAT, 0, 0)

        INICIAR.Enabled = False
        FORMATO.Enabled = False
        CAPTURAR.Enabled = True
        GUARDAR.Enabled = False
        Apagar.Enabled = True

    End Sub

    'BOTON DE GUARDAR
    Private Sub GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GUARDAR.Click
        'Set Save Dialog
        'VARIABLES PARA CONVERTIR LA FOTO
        Dim data As IDataObject
        Dim bmap As Image
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
            Dim saveFileDialog As SaveFileDialog = New SaveFileDialog With {
                            .Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif",
                            .Title = "Proveedor"
                        }
            If saveFileDialog.ShowDialog = DialogResult.OK Then
                bmap.Save(saveFileDialog.FileName, Imaging.ImageFormat.Bmp)
            End If
        End If
        INICIAR.Enabled = False
        FORMATO.Enabled = False
        CAPTURAR.Enabled = False
        GUARDAR.Enabled = False
        Apagar.Enabled = True
    End Sub

    'BOTON DE PAGAR
    Private Sub Apagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Apagar.Click
        ClosePreviewWindow()
        Me.Close()
    End Sub

End Class