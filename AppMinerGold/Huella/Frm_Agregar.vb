Imports System.Data.OleDb
'Imports DPFP.Capture
'Imports System.Diagnostics.Eventing

Public Class Frm_Agregar

    Private cedula As Integer
    Private usuarioglb As Integer

    Sub Setusuarioglb(ByVal usr As Integer)
        usuarioglb = usr
    End Sub

    Sub Setcedula(ByVal ced As Integer)
        cedula = ced
    End Sub

    Sub Guardar(ByVal TemplateBytes As Byte())
        'fecha modifica
        Dim fechaM As Date
        fechaM = DateTime.Now.ToString("dd/MM/yyyy")
        Dim strConnect As String
        strConnect = cs
        Dim conn As OleDbConnection = New OleDbConnection(strConnect)
        Dim strSql As String = "UPDATE Clientes SET huella=@huella, fecha_modifica='" & fechaM & "' WHERE ced_cl = " & cedula   ''" & cedula & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(strSql, conn)

        ' aqui coloco el parametro de temple
        Dim huella As OleDbParameter = New OleDbParameter("@huella", OleDbType.Binary) With {
            .Value = TemplateBytes
        }
        cmd.Parameters.Add(huella)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            MsgBox("Huella Digital Registrada, Se Actualización Con Exito", MsgBoxStyle.Information, "AppMinerGold")
            'UBICO EL CURSOR
            FrmInicial.Panel1.Select()
            FrmInicial.TxtCedula.Select()
            FrmInicial.TxtCedula.Focus()
            FrmInicial.TxtCedula.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "AppMinerGold, Data Error")
            Exit Sub
        End Try
    End Sub

    'BOTON DE SALIR
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    'SDK TOMAR LAS HUELLAS
    Private Sub EnrollmentControl_OnEnroll(ByVal Control As Object, ByVal FingerMask As Integer, ByVal Template As DPFP.Template, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles EnrollmentControl.OnEnroll
        'convierto el template en  bytes y se guarda en la base de datos
        Dim temBytes As Byte() = Nothing
        Template.Serialize(temBytes)
        Me.Guardar(temBytes)
    End Sub

    'Private Sub BtnRevisar_Click(ByVal sender As Object, e As EventArgs) Handles BtnRevisar.Click
    '    Dim _lectores As ReaderCollection = ReaderCollection.GetReaders()
    '    If _lectores = Nothing Then
    '        MsgBox("No hay lectores de huella instalados en el equipo! ")
    '        Exit Sub
    '    End If
    '    If _lectores.Length = 0 Then
    '        MsgBox("No hay lectores de huella instalados en el equipo! ")
    '        Exit Sub
    '    End If
    '    Dim lector As Reader = _lectores(1)
    '    If Not AbrirLector(lector) Then
    '        Me.Close()
    '    End If
    'End Sub

    'Public Function AbrirLector(ByVal lector As Reader) As Boolean
    '    Reset = False
    '    Dim resultado As Constants.ResultCode = Constants.ResultCode.DP_DEVICE_FAILURE
    '    resultado = lector.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE)
    '    If resultado <> Constants.ResultCode.DP_SUCCESS Then
    '        MessageBox.Show("Error: " & resultado.ToString())
    '        Reset = True
    '        Return False
    '    End If
    '    Return True
    'End Function

End Class
