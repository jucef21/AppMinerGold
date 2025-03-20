Imports System.Data.OleDb

Public Class FrmAgregaHuella

    Private cedula, usuarioglb As String

    Sub Setusuarioglb(ByVal usr As String)
        usuarioglb = usr
    End Sub

    Sub Setcedula(ByVal ced As String)
        cedula = ced
    End Sub

    Sub Guardar(ByVal TemplateBytes As Byte())

        'fecha modifica
        Dim fechaM As Date
        fechaM = DateTime.Now.ToString("dd/MM/yyyy")

        Dim strConnect As String
        strConnect = cs
        Dim conn As OleDbConnection = New OleDbConnection(strConnect)
        Dim strSql As String = "UPDATE Biometria SET biohuella=@biohuella, fecha_modifica='" & fechaM & "' WHERE biocedula= '" & cedula & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(strSql, conn)

        ' aqui coloco el parametro de temple
        Dim huella As OleDbParameter = New OleDbParameter("@biohuella", OleDbType.Binary) With {
            .Value = TemplateBytes
        }
        cmd.Parameters.Add(huella)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            MsgBox("Huella Digital Registrada, Se Actualizao Con Exito", MsgBoxStyle.Information, "AppMinerGold")
            'UBICO EL CURSOR
            FrmEvidencia.GroupBox1.Select()
            FrmEvidencia.TxtCedula.Select()
            FrmEvidencia.TxtCedula.Focus()
            FrmEvidencia.TxtCedula.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Data Error")
            Exit Sub
        End Try
    End Sub

    Private Sub EnrollmentControl_OnEnroll(ByVal Control As Object, ByVal FingerMask As Integer, ByVal Template As DPFP.Template, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles EnrollmentControl.OnEnroll
        'convierto el template en  bytes y se guarda en la base de datos
        Dim temBytes As Byte() = Nothing
        Template.Serialize(temBytes)
        Me.Guardar(temBytes)
    End Sub

End Class
