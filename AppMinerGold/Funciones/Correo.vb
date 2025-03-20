Imports System.Net.Mail
Imports System.Net.Mime

Module Correo

    Private correos As New MailMessage
    Private envios As New System.Net.Mail.SmtpClient

    Sub EnviarCorreo(ByVal emisor As String, ByVal asunto As String, ByVal mensaje As String, ByVal ruta As String, ByVal receptor As String, ByVal password As String)
        Try
            correos.To.Clear()
            'correos.Subject = ""
            correos.Subject = "Base de Datos" 'asunto
            correos.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
            'correos.Body = ""
            correos.Body = "Envío Copia de Seguridad de la fecha: " 'mensaje
            correos.BodyEncoding = System.Text.Encoding.UTF8
            correos.IsBodyHtml = True
            correos.To.Add(Trim(receptor))
            correos.Priority = System.Net.Mail.MailPriority.Normal

            correos.From = New System.Net.Mail.MailAddress(emisor)
            envios.Credentials = New System.Net.NetworkCredential(emisor, password)

            'Aqui es donde adjunto el archivo para despues enviarlo.
            If ruta <> "" Then
                'Dim archivo As System.Net.Mail.Attachment = New System.Net.Mail.Attachment(ruta)
                'correos.Attachments.Add(archivo)
                Try
                    'Dim Archivo As New System.Net.Mail.Attachment(ruta)
                    'correos.Attachments.Add(Archivo)

                    Dim Archivo As Attachment = New System.Net.Mail.Attachment(IO.Path.Combine(Application.StartupPath, ruta, "Archivo Adjunto", FrmCorreo.TxtRutaArchivo.Text))
                    'Dim Archivo As Attachment = New Attachment(ruta, MediaTypeNames.Application.Octet)
                    Dim disposition As ContentDisposition = Archivo.ContentDisposition
                    disposition.CreationDate = System.IO.File.GetCreationTime(ruta)
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(ruta)
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(ruta)
                    correos.Attachments.Add(Archivo)

                    'Dim cd As ContentDisposition = Archivo.ContentDisposition
                    'Console.WriteLine("Content disposition")
                    'Console.WriteLine(cd.ToString())
                    'Console.WriteLine("File {0}", cd.FileName)
                    'Console.WriteLine("Size {0}", cd.Size)
                    'Console.WriteLine("Creation {0}", cd.CreationDate)
                    'Console.WriteLine("Modification {0}", cd.ModificationDate)
                    'Console.WriteLine("Read {0}", cd.ReadDate)
                    'Console.WriteLine("Inline {0}", cd.Inline)
                    'Console.WriteLine("Parameters: {0}", cd.Parameters.Count)

                    'For Each d As DictionaryEntry In cd.Parameters
                    '    Console.WriteLine("{0} = {1}", d.Key, d.Value)
                    'Next

                    Archivo.Dispose()
                Catch ex As Exception
                    MessageBox.Show("Error al intentar adjuntar el archivo" & vbNewLine & "ErrorMag: " & ex.Message, "AppMinerGold®", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            'Datos importantes no modificables para tener acceso a las cuentas CONFIGURACIÓN DEL STMP
            'Dim Origen As String = correos.ToLower
            Dim Origen As String = FrmCorreo.TxtEmisor.Text.ToLower
            Origen = Origen.Remove(0, Origen.IndexOf("@") + 1)
            If Origen = "gmail.com" Then 'PARA GMAIL
                envios.Host = "smtp.gmail.com"
                envios.Port = 587
                'ElseIf Origen = "hotmail.com" Or Origen = "outlook.com" Then 'PARA HOTMAIL Y OUTLOOK
                '    envios.Host = "smtp.live.com"
                '    envios.Port = 25
                'ElseIf Origen = "yahoo.com" Then 'PARA YAHOO
                '    envios.Host = "smtp.mail.yahoo.com"
                '    envios.Port = 25
            End If

            envios.EnableSsl = True

            'envios.UseDefaultCredentials = False

            Try
                envios.Send(correos)
                correos.Dispose()
                MsgBox("El mensaje fue enviado correctamente. ", MsgBoxStyle.Information, "AppMinerGold®")
            Catch ex As Exception
                MsgBox("Error no se puedo enviar el Archivo. ", MsgBoxStyle.Information, "AppMinerGold®")
                Throw New Exception("Error: " & ex.Message & " ")
                'LIMPIO LOS CONTROLES
                FrmCorreo.TxtEmisor.Clear()
                FrmCorreo.TxtAsunto.Clear()
                FrmCorreo.RtbMensaje.Clear()
                FrmCorreo.TxtRutaArchivo.Clear()
                FrmCorreo.TxtReceptor.Clear()
                FrmCorreo.TxtPassword.Clear()
                'DESHABILITO CAMPOS
                FrmCorreo.TxtEmisor.Enabled = False
                FrmCorreo.TxtAsunto.Enabled = False
                FrmCorreo.RtbMensaje.Enabled = False
                FrmCorreo.TxtRutaArchivo.Enabled = False
                FrmCorreo.TxtReceptor.Enabled = False
                FrmCorreo.TxtPassword.Enabled = False

                'DESHABILITO LOS BOTONES
                FrmCorreo.BtnEnviarCorreo.Enabled = False
                FrmCorreo.BtnExamina.Enabled = False

            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensajeria 1.0, AppMinerGold®", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'LIMPIO LOS CONTROLES
            FrmCorreo.TxtEmisor.Clear()
            FrmCorreo.TxtAsunto.Clear()
            FrmCorreo.RtbMensaje.Clear()
            FrmCorreo.TxtRutaArchivo.Clear()
            FrmCorreo.TxtReceptor.Clear()
            FrmCorreo.TxtPassword.Clear()

            'DESHABILITO CAMPOS
            FrmCorreo.TxtEmisor.Enabled = False
            FrmCorreo.TxtAsunto.Enabled = False
            FrmCorreo.RtbMensaje.Enabled = False
            FrmCorreo.TxtRutaArchivo.Enabled = False
            FrmCorreo.TxtReceptor.Enabled = False
            FrmCorreo.TxtPassword.Enabled = False

            'DESHABILITO LOS BOTONES
            FrmCorreo.BtnEnviarCorreo.Enabled = False
            FrmCorreo.BtnExamina.Enabled = False

        End Try
    End Sub

End Module