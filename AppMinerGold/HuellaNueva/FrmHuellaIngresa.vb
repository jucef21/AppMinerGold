Imports System.Data.OleDb
Imports System.IO

Public Class FrmHuellaIngresa

    Implements DPFP.Capture.EventHandler
    Delegate Sub FunctionCall(ByVal param)
    Private Capturer As DPFP.Capture.Capture
    Dim count As Integer

    Public Enroller As DPFP.Processing.Enrollment
    Private Template As DPFP.Template

    Private cedula As Integer
    Private usuarioglb As Integer

    Sub Setusuarioglb(ByVal usr As Integer)
        usuarioglb = usr
    End Sub

    Sub Setcedula(ByVal ced As Integer)
        cedula = ced
    End Sub

    Private Sub OnTemplate(ByVal template)
        Invoke(New FunctionCall(AddressOf _OnTemplate), template)
    End Sub

    Private Sub _OnTemplate(ByVal template)
        Me.Template = template
        If Not template Is Nothing Then
            'savetemplate()
            'copio la ultima imagen al picturebox
            Me.PicImagen.Image = PictureBox4.Image
            MsgBox("Inscripción Digital Exitosa," & vbCrLf & "Continue y Guardar.", MsgBoxStyle.Information, "AppMinerGold")
            'Me.Close()
            Me.TxtCedula.Enabled = False
            Me.BtnGuardar.Enabled = True
            Me.BtnGuardar.Select()
            Me.BtnGuardar.Focus()
        Else
            MessageBox.Show("La plantilla de huellas dactilares no es válida." & vbCrLf & "Repita el registro de huellas dactilares.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Panel1.Select()
            Me.GroupBox2.Select()
            Me.TxtCedula.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.TxtCedula.Clear()
            Me.BtnX.Select()
            Me.BtnX.Focus()
        End If
    End Sub

    Protected Overridable Sub Init()
        Try
            Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
            Enroller = New DPFP.Processing.Enrollment()
            UpdateStatus()
            If (Not Capturer Is Nothing) Then
                Capturer.EventHandler = Me                              ' Subscribe for capturing events.
            Else
                SetPrompt("No se puede iniciar la operación de captura!")
            End If
        Catch ex As DPFP.Error.SDKException
            ' MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox("Error el dispositivo no se encuentra Conectado. " + ex.ToString, MsgBoxStyle.Exclamation, "AppMinerGold")
        End Try
    End Sub

    Protected Overridable Sub Processs(ByVal Sample As DPFP.Sample)
        DrawPicture(ConvertSampleToBitmap(Sample))
    End Sub

    Protected Function ConvertSampleToBitmap(ByVal Sample As DPFP.Sample) As Bitmap
        Dim convertor As New DPFP.Capture.SampleConversion()  ' Create a sample convertor.
        Dim bitmap As Bitmap = Nothing              ' TODO: the size doesn't matter
        convertor.ConvertToPicture(Sample, bitmap)
        Try
            If PictureBox1.Image Is Nothing Then
                Invoke(New FunctionCall(AddressOf _picturebox1draw), bitmap)
            ElseIf PictureBox2.Image Is Nothing Then
                Invoke(New FunctionCall(AddressOf _picturebox2draw), bitmap)
            ElseIf PictureBox3.Image Is Nothing Then
                Invoke(New FunctionCall(AddressOf _picturebox3draw), bitmap)
            ElseIf PictureBox4.Image Is Nothing Then
                Invoke(New FunctionCall(AddressOf _picturebox4draw), bitmap)
            ElseIf PicImagen.Image Is Nothing Then
                Invoke(New FunctionCall(AddressOf _picImagedraw), bitmap)
            Else
            End If
        Catch ex As Exception
        End Try
        ' TODO: return bitmap as a result
        Return bitmap
    End Function

    Protected Function ExtractFeatures(ByVal Sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet
        Dim extractor As New DPFP.Processing.FeatureExtraction()    ' Create a feature extractor
        Dim feedback As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
        Dim features As New DPFP.FeatureSet()
        extractor.CreateFeatureSet(Sample, Purpose, feedback, features) ' TODO: return features as a result?
        If (feedback = DPFP.Capture.CaptureFeedback.Good) Then
            Return features
        Else
            Return Nothing
        End If
    End Function

    Protected Sub StartCapture()
        If (Not Capturer Is Nothing) Then
            Try
                Capturer.StartCapture()
                SetPrompt("Usando el lector de huellas digitales," & vbCrLf & "Escanee su huella digital.")
            Catch ex As DPFP.Error.SDKException
                'SetPrompt("Can't initiate capture!")
                MsgBox("Error el dispositivo no se encuentra Conectado. " + ex.ToString, MsgBoxStyle.Exclamation, "AppMinerGold")
            End Try
        End If
    End Sub

    Protected Sub StopCapture()
        If (Not Capturer Is Nothing) Then
            Try
                Capturer.StopCapture()
            Catch ex As Exception
                SetPrompt("No se puede finalizar la captura!")
            End Try
        End If
    End Sub

    Private Sub CaptureForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtCedula.Enabled = False
        Me.TxtCedula.Text = Convert.ToInt32(cedula)
        Init()
        StartCapture()
    End Sub

    Private Sub CaptureForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        StopCapture()
    End Sub

    Sub OnComplete(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete
        If String.IsNullOrWhiteSpace(TxtCedula.Text) Then
            MsgBox("No se ha ingresado ningún nombre para esta captura.")
        Else
            MakeReport("La muestra de huellas dactilares fue capturada.")
            SetPrompt("Escanear la misma huella digital nuevamente.")
            Process(Sample)
        End If
    End Sub

    Sub OnFingerGone(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone
        MakeReport("El dedo fue retirado del lector de huellas dactilares..")
    End Sub

    Sub OnFingerTouch(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch
        MakeReport("El lector de huellas digitales fue tocado.")
    End Sub

    Sub OnReaderConnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect
        MakeReport("El lector de huellas digitales estaba conectado.")
    End Sub

    Sub OnReaderDisconnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect
        MakeReport("El lector de huellas estaba desconectado.")
    End Sub

    Sub OnSampleQuality(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality
        If CaptureFeedback = DPFP.Capture.CaptureFeedback.Good Then
            MakeReport("La calidad de la muestra de huellas dactilares es buena.")
        Else
            MakeReport("La calidad de la muestra de huellas dactilares es mala..")
        End If
    End Sub

    Protected Sub SetStatus(ByVal status)
        Invoke(New FunctionCall(AddressOf _SetStatus), status)
    End Sub

    Private Sub _SetStatus(ByVal status)
        StatusLine.Text = status
    End Sub

    Protected Sub SetPrompt(ByVal text)
        Invoke(New FunctionCall(AddressOf _SetPrompt), text)
    End Sub

    Private Sub _SetPrompt(ByVal text)
        Prompt.Text = text
    End Sub

    Protected Sub MakeReport(ByVal status)
        Try
            Invoke(New FunctionCall(AddressOf _MakeReport), status)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub _MakeReport(ByVal status)
        StatusText.AppendText(status + Chr(13) + Chr(10))
    End Sub

    Protected Sub DrawPicture(ByVal bmp)
        Invoke(New FunctionCall(AddressOf _DrawPicture), bmp)
    End Sub

    Private Sub _DrawPicture(ByVal bmp)
        ImagenHuella.Image = New Bitmap(bmp, ImagenHuella.Size)
    End Sub

    Sub _picturebox1draw(ByVal bmp)
        PictureBox1.Image = New Bitmap(bmp, 157, 168)
        ProgressBar1.Value = 25
    End Sub

    Sub _picturebox2draw(ByVal bmp)
        PictureBox2.Image = New Bitmap(bmp, 157, 168)
        ProgressBar1.Value = 50
    End Sub

    Sub _picturebox3draw(ByVal bmp)
        PictureBox3.Image = New Bitmap(bmp, 157, 168)
        ProgressBar1.Value = 75
    End Sub

    Sub _picturebox4draw(ByVal bmp)
        PictureBox4.Image = New Bitmap(bmp, 157, 168)
        ProgressBar1.Value = 100
    End Sub

    Sub _picImagedraw(ByVal bmp)
        PicImagen.Image = New Bitmap(bmp, 157, 168)
    End Sub

    Sub Pictureboxesclear()
        'Limpio los pictureBox
        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        PictureBox4.Image = Nothing
        PicImagen.Image = Nothing
        ImagenHuella.Dispose()
        StatusText.Clear()
        Prompt.Clear()
        ProgressBar1.Dispose()
        BtnX.Focus()
    End Sub

    Protected Sub Process(ByVal Sample As DPFP.Sample)
        Processs(Sample)
        ' Process the sample and create a feature set for the enrollment purpose.
        Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment)
        ' Check quality of the sample and add to enroller if it's good
        If (Not features Is Nothing) Then
            Try
                MakeReport("Se creó el conjunto de funciones de huellas dactilares..")
                Enroller.AddFeatures(features)        ' Add feature set to template.
            Finally
                UpdateStatus()
                ' Check if template has been created.
                Select Case Enroller.TemplateStatus
                    Case DPFP.Processing.Enrollment.Status.Ready    ' Report success and stop capturing
                        OnTemplate(Enroller.Template)
                        'SetPrompt("Click Close, and then click Fingerprint Verification.")
                        Template = Enroller.Template
                        StopCapture()
                    Case DPFP.Processing.Enrollment.Status.Failed   ' Report failure and restart capturing
                        Enroller.Clear()
                        StopCapture()
                        OnTemplate(Nothing)
                        StartCapture()
                End Select
            End Try
        End If
    End Sub

    Protected Sub UpdateStatus()
        ' Show number of samples needed.
        SetStatus(String.Format("Necesitas pasar el Dedo: {0} Veces", Enroller.FeaturesNeeded))
    End Sub

    'convertir binario a imágen
    Private Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    'convertir imagen a binario
    Private Function Imagen_Bytes(ByVal Imagen As Image) As Byte()
        'si hay imagen
        If Not Imagen Is Nothing Then
            'variable de datos binarios en stream(flujo)
            Dim Bin As New MemoryStream
            'convertir a bytes
            Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
            'retorna binario
            Return Bin.GetBuffer
        Else
            Return Nothing
        End If
    End Function

    Private Sub TxtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCedula.KeyPress
        SoloNumeros(e)
    End Sub

    'FUNCION VALIDA USUARIO REPETIDO DE CEDULA
    Function ExisteCedula(ByVal ced_user As String) As Boolean
        Dim ResulCedu As Boolean = False
        Dim Num As String = Convert.ToInt32(TxtCedula.Text)
        Try
            cmd = New OleDbCommand("SELECT ced_cl FROM Clientes WHERE ced_cl=" + Num, conn)
            conn.Open()
            dr = cmd.ExecuteReader
            'SI EXISTE UN REGISTRO REPETIDO CAMBIA A VERDADERO = TRUE, SI NO SE CUMPLE SIGUE EN FALSE
            If dr.Read Then
                ResulCedu = True
                MessageBox.Show("Error la Cédula Ingresada ya Existe, " & vbCrLf & "Intente de nuevo. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            dr.Close()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return ResulCedu
    End Function

    Sub Savetemplate(ByVal TemplateBytes As Byte())

        CargarHuella()

        Dim fechaM As Date
        fechaM = DateTime.Now.ToString("dd/MM/yyyy")

        Dim strConnect As String
        strConnect = cs
        Dim conn As OleDbConnection = New OleDbConnection(strConnect)
        Dim cedula As String = Me.TxtCedula.Text

        Dim Ruta = "C:\FotoProHuella\"
        Dim Img As String = Ruta + cedula + ".jpeg"

        'img=@img   (Foto del proveedor)
        'huella=@huella  (huella biometrica)
        'ruta  (ruta de la carpeta donde esta la imagen de la huella)

        sql = "UPDATE Clientes SET huella=@huella, fecha_modifica='" & fechaM & "', ruta='" & Img & "' WHERE ced_cl = " & cedula
        Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)

        'Dim huella As OleDbParameter = New OleDbParameter("@img", OleDbType.Binary) With {
        '    .Value = TemplateBytes
        '}
        'cmd.Parameters.Add(huella)

        Dim Imag As Byte()
        Imag = Imagen_Bytes(ImagenHuella.Image)
        cmd.Parameters.AddWithValue("@huella", Imag)

        'If ExisteCedula(TxtCedula.Text) = False Then
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Los datos se han guardado Correctamente!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmd.Dispose()
            conn.Dispose()
            BtnGuardar.Enabled = False
            TxtCedula.Enabled = False
            Pictureboxesclear()
            Me.TxtCedula.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("No se puede Guardar," & vbCrLf & "Ya hay un registro con la misma Cédula!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Panel1.Select()
            Me.GroupBox2.Select()
            Me.TxtCedula.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.TxtCedula.Clear()
            Me.BtnX.Select()
            Me.BtnX.Focus()
        End Try
        'Else
        '    MsgBox("Error la Cédula Ingresada ya Existe: ")
        'End If
    End Sub

    'Valido los procedimientos de ingreso duplicados
    Private Sub Validar()
        If Me.TxtCedula.Text = "" Then
            MsgBox("El Campo Cédula no deben estar vacio! ", MsgBoxStyle.Critical, "AppMinerGold")
            Me.TxtCedula.Select()
            Me.TxtCedula.Focus()
        Else
            Dim encontro As Integer = 0
            Dim numcedula As String = Convert.ToInt32(TxtCedula.Text)
            If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Closed Then
                conn.Open()
            End If
            sql = "SELECT ced_cl FROM Clientes WHERE ced_cl = " & numcedula
            Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader()
            Try
                Do While dr.Read
                    encontro = 1
                Loop
            Catch ex As Exception
                MsgBox("Ha ocurrido un Error en el Ingreso de Cédula! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
            End Try
            conn.Close()

            If encontro = 1 Then
                MsgBox("no se puede Guardar, ya hay un registro con la misma Cédula!", MsgBoxStyle.Exclamation, "AppMinerGold")
            Else
                Dim temBytes As Byte() = Nothing
                Template.Serialize(temBytes)
                'Guardar(temBytes)
                Savetemplate(temBytes)
            End If
        End If
    End Sub

    'BOTON DE GUARDAR Y AGREGA LOS DATOS NUEVOS A LA BASE DE DATOS - NO LO USE PORQUE SOLO SE ACTUALIZA
    Private Sub Guardar(ByVal TemplateBytes As Byte())

        Dim strConnect As String
        strConnect = cs
        Dim conn As OleDbConnection = New OleDbConnection(strConnect)
        Dim cedula As Double = Me.TxtCedula.Text
        sql = "INSERT INTO Clientes (cedula, img, huella) VALUES ('" & cedula & "', @img, @huella)"
        Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
        ' aqui coloco el parametro de temple
        Dim huella As OleDbParameter = New OleDbParameter("@img", OleDbType.Binary) With {
            .Value = TemplateBytes
        }
        cmd.Parameters.Add(huella)

        Dim Imag As Byte()
        Imag = Imagen_Bytes(ImagenHuella.Image)
        cmd.Parameters.AddWithValue("@huella", Imag)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Los datos se han guardado Correctamente!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Pictureboxesclear()
        Catch ex As Exception
            MsgBox("Error al guardar los datos " & ex.Message, MsgBoxStyle.Information, "AppMinerGold")
        End Try
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        'Validar()
        Dim temBytes As Byte() = Nothing
        Template.Serialize(temBytes)
        Savetemplate(temBytes)
    End Sub

    'CARGAR HUELLA DESDE UNA UBICACION Y UBICARLA EN PICTUREBOX
    Private Sub CargarHuella()
        Dim Ruta = "C:\FotoProHuella\"
        Dim cedula As Double = Me.TxtCedula.Text
        'Si no existe la carpeta de BackUp la creamos.
        If My.Computer.FileSystem.DirectoryExists(Ruta) = False Then
            My.Computer.FileSystem.CreateDirectory(Ruta)
        End If
        Dim SaveFileDialog As New SaveFileDialog With {
             .SupportMultiDottedExtensions = True,
             .AddExtension = True,
             .Filter = "Extensión de Imagenes (*.jpg, *.png) | *.jpg; *.png",
             .FilterIndex = 1,
             .FileName = cedula,
             .Title = "Guarda Huella Biometrica"
        }
        'Coloco el nombre de la ruta de la huella 
        Me.TxtNomRutaHuella.Text = Ruta + SaveFileDialog.FileName + ".Jpeg"

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
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
                        PicImagen.Image.Save(SaveFileDialog.FileName, Imaging.ImageFormat.Jpeg)
                    End If
                Else
                    PicImagen.Image.Save(SaveFileDialog.FileName, Imaging.ImageFormat.Jpeg)
                End If
            Catch ex As Exception
                MessageBox.Show("Error al Guardar Huella", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                PicImagen.Image = Nothing
            End Try
        End If

    End Sub

End Class
