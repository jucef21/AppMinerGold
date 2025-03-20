Imports System.Data.OleDb
Imports System.IO

Public Class FrmEvidencia

    'CARGUE DEL FORMULARIO
    Private Sub FrmEvidencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'colocamos los texbox en no editable
        Me.Txtced_cl.Enabled = False
        Me.TxtNomApe.Enabled = False

        'llenamos los datos con la informacion seleccionada
        Me.Txtced_cl.Text = ModuleFrm.ced_consulta
        Me.TxtNomApe.Text = ModuleFrm.Nom_consulta

        'llamo el  preocedimeinto de CONCATENAR 
        'UnirNombres()

        'muestro el resultado y los concateno
        Me.TxtNomApe.Text = Me.TxtName.Text & " " & Me.TxtSurName.Text

        'HABILITOS BOTONES
        Me.BtnExamina.Enabled = True
        Me.BtnHuella.Enabled = True
        Me.BtnExaminaHuella.Enabled = True
        Me.BtnExaminaFirma.Enabled = True
        Me.BtnGuardar.Enabled = True


        'habilitamos los botones 
        Me.PicFoto.Enabled = True
        Me.PicHuella.Enabled = True
        Me.PicFirma.Enabled = True

        Me.BtnGuardar.Enabled = True

        Me.TxtCedula.Enabled = False
        'Me.TxtCedula.Clear()
        Me.TxtCedula.Text = Me.Txtced_cl.Text

    End Sub

    'PROCEDIMIENTO PARA UNIR NOMBRE Y APELLIDO DEL CLIENTE
    Private Sub UnirNombres()
        Dim dt As New DataTable
        Dim consulta As String = "SELECT * FROM Clientes WHERE ced_cl = '" & Txtced_cl.Text & "' "
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            Me.TxtName.Text = drd.Item("nom_cl").ToString
            Me.TxtSurName.Text = drd.Item("ape_cl").ToString
        Else
            MsgBox("No se encontro NOMBRES", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
        conn.Close()
    End Sub

#Region "ZONA DE CAMARA - TOMA FOTO"

    'BOTON DE EXAMINAR FOTO
    Private Sub BtnExamina_Click(sender As Object, e As EventArgs) Handles BtnExamina.Click
        'ACTIVAMOS BOTONES
        Me.BtnExamina.Enabled = False
        'LLAMO AL PROCEDIMIENTO
        CargarFoto()
    End Sub

    'CARGAR FOTO DESDE UNA UBICACION Y UBICARLA EN PICTUREBOX
    Private Sub CargarFoto()
        Dim ruta As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "FotosCompras")
        Using OpenFileDialog As New OpenFileDialog()
            With OpenFileDialog
                .CheckFileExists = True
                .ShowReadOnly = False
                .Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
                .FilterIndex = 1
                If .ShowDialog = Global.System.Windows.Forms.DialogResult.OK Then
                    ' Mostramos la imagen en el control PictureBox
                    Me.PicFoto.ImageLocation = .FileName
                    Me.TxtNomFoto.Text = OpenFileDialog.FileName
                End If
            End With
        End Using
    End Sub

#End Region

#Region "ZONA DE HUELLA - TOMA HUELLA"

    'BOTON DE INICIAR DISPOSITIVO PARA LA HUELLA
    Private Sub BtnHuella_Click(sender As Object, e As EventArgs) Handles BtnHuella.Click
        FrmTomarHuellas.Show()
    End Sub

    'BOTON DE BUSCAR HUELLA EXAMINAR
    Private Sub BtnExaminaHuella_Click(sender As Object, e As EventArgs) Handles BtnExaminaHuella.Click
        CargarHuella()
    End Sub

    'CARGAR HUELLA DESDE UNA UBICACION Y UBICARLA EN PICTUREBOX
    Private Sub CargarHuella()
        Dim ruta As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "FotosCompras")
        Using OpenFileDialog1 As New OpenFileDialog()
            With OpenFileDialog1
                .CheckFileExists = True
                .ShowReadOnly = False
                .Filter = "All Files|*.*|Bitmap Files (*)|*.png;*.gif;*.jpg"
                .FilterIndex = 2
                If .ShowDialog = DialogResult.OK Then
                    ' Mostramos la imagen en el control PictureBox
                    Me.PicHuella.ImageLocation = .FileName
                End If
            End With
        End Using
    End Sub

#End Region

#Region "BOTONES DE FIRMA"

    'BOTON DE EXAMINAR FIRMA
    Private Sub BtnExaminaFirma_Click(sender As Object, e As EventArgs) Handles BtnExaminaFirma.Click
        Dim ruta As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "FotosCompras")
        Using OpenFileDialog1 As New OpenFileDialog()
            With OpenFileDialog1
                .CheckFileExists = True
                .ShowReadOnly = False
                .Filter = "All Files|*.bmp;*.gif;*.jpg;*.png"
                .FilterIndex = 3
                If .ShowDialog = DialogResult.OK Then
                    ' Mostramos la imagen en el control PictureBox
                    Me.PicFirma.ImageLocation = .FileName
                End If
            End With
        End Using
    End Sub


#End Region

#Region "BOTONES DELFORMULARIO"

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        'LLAMA AL PROCEDIMIENTO
        ValidarCedulas()

    End Sub


#End Region

#Region "VALIDA CAMPOS DE FOTOS "

    'Valido los procedimientos de ingreso duplicados
    Private Sub ValidarCedulas()
        If Me.TxtCedula.Text = "" Then
            MsgBox("El Campo Cédula de un Proveedor no debe estar vacío! ", MsgBoxStyle.Critical, "AppMinerGold")
            Me.GroupBox1.Select()
            Me.TxtCedula.Select()
            Me.TxtCedula.Focus()
        Else
            Dim encontro As Integer
            Dim cmd As New OleDb.OleDbCommand

            encontro = 0
            'ejecutamos la consulta
            cmd = New OleDb.OleDbCommand("SELECT * FROM Biometrica WHERE biocedula ='" & Me.TxtCedula.Text & "' ", conn) With {
                .Connection = conn
            }
            conn.Open()
            Dim dr As OleDb.OleDbDataReader
            dr = cmd.ExecuteReader()
            Try
                Do While dr.Read
                    encontro = 1
                Loop
            Catch ex As Exception
                MsgBox("Ha ocurrido un Error en el Ingreso de Clientes! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
            End Try
            conn.Close()
            If (encontro = 1) Then
                MsgBox("No se puede Guardar, ya hay un registro con la misma Cédula del Proveedor!", MsgBoxStyle.Exclamation, "AppMinerGold")
                'pocisiono el cursor
                Me.GroupBox1.Select()
                Me.TxtCedula.Select()
                Me.TxtCedula.Focus()
            Else
                ValidaCamposActualiza()
            End If
        End If
    End Sub

    'VALIDA FOTO VACIA
    Private Sub ValidaCamposActualiza()
        If Me.PicFoto.Image Is Nothing Or Me.PicHuella.Image Is Nothing Or Me.PicFirma.Image Is Nothing Then
            MsgBox("Los Campos de Fotos no deben estar vacíos! ", MsgBoxStyle.Critical, "AppMinerGold")
            Me.BtnExamina.Select()
            Me.BtnExamina.Focus()
        Else
            AgregarDatosActualizados()
            'cierro conexion
            conn.Close()
        End If
    End Sub

    'PROCEDIMIENTO PARA AGREGAR DATOS A LA BASE
    Private Sub AgregarDatosActualizados()
        'variables de fecha de auditoria
        Dim fechaC As Date = CDate(Format(Date.Now.Date))
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        ':::Creamos nuestras variables para almacenar los datos a ingresar
        Dim cedula As String = Me.Txtced_cl.Text
        Dim nombres As String = Me.TxtNomApe.Text
        Dim fechacrea As Date = Date.Now.ToShortTimeString  '::FechaC
        Dim fechamodi As Date = Date.Now.ToShortTimeString  '::FechaM

        Try
            If ValidaDatosCedula() = False Then Exit Sub

            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            'PROCESO PARA FOTO
            ':::Creamos una variable de tipo MemoryStram
            Dim MS As New MemoryStream
            ':::Guardamos en la variable MS el contenido del PictureBox
            PicFoto.Image.Save(MS, PicFoto.Image.RawFormat)
            ':::Pasamos a Byte nuestra imagen
            Dim Imagenes() As Byte = MS.GetBuffer

            ':::Agregamos el parametro de nuestra varible imagenes que es de tipo Byte
            cmd.Parameters.AddWithValue("@biofoto", Imagenes)

            'PROCESO PARA HUELLA
            ':::Creamos una variable de tipo MemoryStram
            Dim MSH As New MemoryStream
            ':::Guardamos en la variable MS el contenido del PictureBox
            PicHuella.Image.Save(MSH, PicHuella.Image.RawFormat)
            ':::Pasamos a Byte nuestra imagen
            Dim ImagenesH() As Byte = MSH.GetBuffer

            ':::Agregamos el parametro de nuestra varible imagenes que es de tipo Byte
            cmd.Parameters.AddWithValue("@biohuella", ImagenesH)

            'PROCESO PARA FIRMA
            ':::Creamos una variable de tipo MemoryStram
            Dim MSF As New MemoryStream
            ':::Guardamos en la variable MS el contenido del PictureBox
            PicFirma.Image.Save(MSF, PicFirma.Image.RawFormat)
            ':::Pasamos a Byte nuestra imagen
            Dim ImagenesF() As Byte = MSF.GetBuffer

            ':::Agregamos el parametro de nuestra varible imagenes que es de tipo Byte
            cmd.Parameters.AddWithValue("@biofirma", ImagenesF)

            'HACEMOS LA CONSULTA PARA GUARDAR
            sql = "INSERT INTO Biometrica (biocedula, bionombre, biofoto, biohuella, biofirma, fecha_creado, " &
                                    "fecha_modifica) VALUES ('" & cedula & "', '" & nombres & "', " &
                                    "@biofoto, @biohuella, @biofirma, '" & fechaC & "', '" & fechaM & "' )"

            cmd.CommandText = sql

            conn.Open()

            'ejecutamos la consulta
            cmd.ExecuteNonQuery()

            ':::Cerramos nuestra conexion
            conn.Close()

            MsgBox("Los datos se han Actualizados Correctamente! ", MsgBoxStyle.Information, "AppMinerGold")

            'ubicamos el cursor

            'habilitamos los botones 
            Me.PicFoto.Enabled = False
            Me.PicHuella.Enabled = False
            Me.PicFirma.Enabled = False

            Me.PicFoto.Image = Nothing
            Me.PicHuella.Image = Nothing
            Me.PicFirma.Image = Nothing

            Me.BtnExamina.Enabled = False
            Me.BtnHuella.Enabled = False
            Me.BtnExaminaHuella.Enabled = False
            Me.BtnExaminaFirma.Enabled = False
            Me.BtnGuardar.Enabled = False

            Me.TxtCedula.Enabled = False

        Catch ex As Exception
            'ENVIO EL MENSAJE DE RROR
            MsgBox("Error al guardar los datos " & ex.Message, MsgBoxStyle.Information, "AppMinerGold")
        End Try

    End Sub

    'valida todos los campos no pueden estar vacios
    Private Function ValidaDatosCedula() As Boolean
        'proveedor
        If Len(Me.TxtCedula.Text.Trim) = 0 Then
            MsgBox("El Campo Cédula no puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
            Me.GroupBox1.Select()
            Me.TxtCedula.Select()
            Me.TxtCedula.Focus()
            Return False
            Exit Function
        End If
        Return True
    End Function

    'BOTON DE IMPRIMIR
    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        FrmImpEvidencia.TxtCedulaImp.Text = Txtced_cl.Text
        FrmImpEvidencia.ShowDialog()
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region







End Class