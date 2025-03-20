Imports System.Data.OleDb

Public Class FrmHuellaVerificacion

    Public TempRecuperada As Byte() = Nothing

    Private usuarioglbV As Integer
    Private vericedula As Integer

    Sub SetusuarioglbV(ByVal usrV As String)
        usuarioglbV = usrV
    End Sub

    Sub Setvericedula(ByVal ced As Integer)
        vericedula = ced
        Lblced.Text = Convert.ToInt32(vericedula)
    End Sub

    'CARGUE DEL FORMULARIO
    Private Sub Verificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'PROCEDIMIENTO DE RECUPERAR LA HUELLA
    Private Sub Recuperar()
        Dim Num As String = Lblced.Text
        Dim strConnect As String
        Dim ret As New DataSet
        Dim tamaño As Integer
        strConnect = cs
        Dim conn As OleDbConnection = New OleDbConnection(strConnect)
        Dim sql As String = "SELECT img FROM Clientes WHERE ced_cl= " + Num
        Dim myCommand As OleDbCommand = New OleDbCommand(sql, conn)
        Try
            conn.Open()
            Dim AdaptadorSQL As New OleDbDataAdapter
            myCommand.CommandTimeout = 600
            AdaptadorSQL.SelectCommand = myCommand
            AdaptadorSQL.Fill(ret)
            If Not (ret.Tables(0).Rows.Count = 0) Then
                Try
                    TempRecuperada = ret.Tables(0).Rows(0).Item(0)
                    tamaño = TempRecuperada.Length
                Catch ex As Exception
                    MessageBox.Show("Usuario No Registra Huella", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Else
                MessageBox.Show("Usuario no registrado en el sistema", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            conn.Close()
        Catch SQLexc As OleDbException
            MessageBox.Show("Error de Sistema" + SQLexc.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'PROCEDIMIENTO DE VERIFICACION DE LA HUELLA
    Private Sub VerificationControl_OnComplete(ByVal Control As Object, ByVal FeatureSet As DPFP.FeatureSet, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles VerificationControl.OnComplete
        Dim ver As New DPFP.Verification.Verification()
        Dim res As New DPFP.Verification.Verification.Result()
        Dim tempRec As DPFP.Template
        Dim tama As Integer
        Recuperar()
        If Not (TempRecuperada Is Nothing) Then
            tempRec = New DPFP.Template()
            tempRec.DeSerialize(TempRecuperada)
            tama = tempRec.Size
            If Not tempRec Is Nothing Then                     '   Get template from storage.
                ver.Verify(FeatureSet, tempRec, res)           '   Compare feature set with particular template.
                If res.Verified Then
                    EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Success
                    Me.Label1.Text = "Cédula No.: " & usuarioglbV
                    MessageBox.Show("Usuario Registra la Cédula: " & usuarioglbV, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.BtnRegresa.Enabled = True
                    Me.BtnRegresa.Select()
                    Me.BtnRegresa.Focus()
                Else
                    MessageBox.Show("Huella no Registrada del Usuario, " & vbCrLf & " Pruebe de Nuevo.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'Me.Label1.Text = ""
                    'Me.Lblced.Text = ""
                    Me.BtnRegresa.Enabled = True
                    Me.BtnRegresa.Select()
                    Me.BtnRegresa.Focus()
                End If
            End If
        End If
        If Not res.Verified Then EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
    End Sub

    'BOTON DE REGRESAR
    Private Sub BtnRegresa_Click(sender As Object, e As EventArgs) Handles BtnRegresa.Click
        Me.Close()
    End Sub

End Class