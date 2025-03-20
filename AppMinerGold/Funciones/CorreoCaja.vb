Imports System.Net
Imports System.Net.Mail

Module CorreoCaja

    Private CorreosCaja As New MailMessage
    Private EnviosCaja As New SmtpClient

    Sub EnviarCorreoCaja(ByVal emisor As String, ByVal asunto As String, ByVal mensaje As String, ByVal ruta As String, ByVal receptor As String, ByVal password As String)
        Try
            '
            CorreosCaja.Subject = ""
            CorreosCaja.Subject = asunto
            CorreosCaja.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
            '
            CorreosCaja.To.Clear()
            CorreosCaja.Body = ""
            CorreosCaja.Body = mensaje
            CorreosCaja.BodyEncoding = System.Text.Encoding.UTF8
            '
            CorreosCaja.IsBodyHtml = True
            '
            CorreosCaja.To.Add(Trim(receptor))
            '
            CorreosCaja.Priority = System.Net.Mail.MailPriority.Normal

            'Aqui es donde adjunto el archivo para despues enviarlo.
            If ruta <> "" Then
                Dim archivo As Net.Mail.Attachment = New Net.Mail.Attachment(ruta)
                CorreosCaja.Attachments.Add(archivo)
            End If

            CorreosCaja.From = New MailAddress(receptor)
            EnviosCaja.Credentials = New NetworkCredential(receptor, password)

            'Datos importantes no modificables para tener acceso a las cuentas
            'CONFIGURACIÓN DEL STMP
            Dim ORIGEN As String = FrmCajaCorreo.TxtEmisor.Text.ToLower
            ORIGEN = ORIGEN.Remove(0, ORIGEN.IndexOf("@") + 1)
            If ORIGEN = "gmail.com" Then 'PARA GMAIL
                EnviosCaja.Host = "smtp.gmail.com"
            ElseIf ORIGEN = "hotmail.com" Or ORIGEN = "outlook.com" Then 'PARA HOTMAIL Y OUTLOOK
                EnviosCaja.Host = "smtp.live.com"
            End If

            EnviosCaja.Port = 587
            EnviosCaja.EnableSsl = True

            Try
                EnviosCaja.Send(CorreosCaja)
                MsgBox("El mensaje fue enviado correctamente. ", MsgBoxStyle.Information, "AppMinerGold")
            Catch ex As Exception
                Throw New Exception("Error: (" & ex.Message & ")")
                'LIMPIO LOS CONTROLES
                FrmCajaCorreo.TxtEmisor.Clear()
                FrmCajaCorreo.TxtAsunto.Clear()
                FrmCajaCorreo.RtbMensaje.Clear()
                FrmCajaCorreo.TxtRutaArchivo.Clear()
                FrmCajaCorreo.TxtReceptor.Clear()
                FrmCajaCorreo.TxtPassword.Clear()
                'DESHABILITO CAMPOS
                FrmCajaCorreo.TxtEmisor.Enabled = False
                FrmCajaCorreo.TxtAsunto.Enabled = False
                FrmCajaCorreo.RtbMensaje.Enabled = False
                FrmCajaCorreo.TxtRutaArchivo.Enabled = False
                FrmCajaCorreo.TxtReceptor.Enabled = False
                FrmCajaCorreo.TxtPassword.Enabled = False

                'DESHABILITO LOS BOTONES
                FrmCajaCorreo.BtnEnviar.Enabled = False
                FrmCajaCorreo.BtnExamina.Enabled = False

            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensajeria 1.0, AppMinerGold®", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'LIMPIO LOS CONTROLES
            FrmCajaCorreo.TxtEmisor.Clear()
            FrmCajaCorreo.TxtAsunto.Clear()
            FrmCajaCorreo.RtbMensaje.Clear()
            FrmCajaCorreo.TxtRutaArchivo.Clear()
            FrmCajaCorreo.TxtReceptor.Clear()
            FrmCajaCorreo.TxtPassword.Clear()

            'DESHABILITO CAMPOS
            FrmCajaCorreo.TxtEmisor.Enabled = False
            FrmCajaCorreo.TxtAsunto.Enabled = False
            FrmCajaCorreo.RtbMensaje.Enabled = False
            FrmCajaCorreo.TxtRutaArchivo.Enabled = False
            FrmCajaCorreo.TxtReceptor.Enabled = False
            FrmCajaCorreo.TxtPassword.Enabled = False

            'DESHABILITO LOS BOTONES
            FrmCajaCorreo.BtnEnviar.Enabled = False
            FrmCajaCorreo.BtnExamina.Enabled = False

        End Try
    End Sub

End Module

