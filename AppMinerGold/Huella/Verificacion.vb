Imports System.Data.OleDb

Public Class Verificacion

    Public TempRecuperada As Byte() = Nothing

    Private usuarioglbV As Integer
    Private vericedula As Integer

    Sub SetusuarioglbV(ByVal usrV As String)
        usuarioglbV = usrV
    End Sub

    Sub Setvericedula(ByVal ced As Integer)
        vericedula = ced
    End Sub

    'CARGUE DEL FORMULARIO
    Private Sub Verificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'PROCEDIMIENTO DE RECUPERAR LA HUELLA
    Private Sub Recuperar()
        Dim strConnect As String
        Dim ret As New DataSet
        Dim tamaño As Integer
        strConnect = cs
        Dim conn As OleDbConnection = New OleDbConnection(strConnect)
        Dim Str_consulta As String = "SELECT huella FROM Clientes WHERE ced_cl = " & vericedula  '+ vericedula.Trim + "'"
        Dim myCommand As OleDbCommand = New OleDbCommand(Str_consulta, conn)
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
                    MsgBox("Usuario No Registra Huella", MsgBoxStyle.Information, "AppMinerGold")
                End Try
            Else
                MsgBox("Usuario no registrado en el sistema", MsgBoxStyle.Information, "AppMinerGold")
            End If
            conn.Close()
        Catch SQLexc As OleDbException
            MsgBox(SQLexc.ToString)
            MsgBox("Error de Usuario", MsgBoxStyle.Information, "AppMinerGold")
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
                    MsgBox("Cédula Registrada: " & usuarioglbV, MsgBoxStyle.Information, "AppMinerGold")
                Else
                    MsgBox("Huella no Registrada del Usuario, Pruebe de Nuevo.", MsgBoxStyle.Information, "AppMinerGold")
                    Me.Label1.Text = ""
                End If
            End If
        End If
        If Not res.Verified Then EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
    End Sub

    'BOTON DE REGRESAR
    Private Sub BtnRegresa_Click(sender As Object, e As EventArgs) Handles BtnRegresa.Click
        Me.Close()
        'FrmInicial.TxtVeriCedula.Select()
        'FrmInicial.TxtVeriCedula.Clear()
        'FrmInicial.TxtVeriCedula.Focus()

        'INHABILITO EL CAMPO DE TEXTO DE PROVEEDORES
        FrmProveedores.TxtBuscar.Enabled = False
        'AGREGO LOS DATOS BUSCADOS POR HUELLA
        AbreProveedor()

    End Sub

    'FUNCION DE FILTRAR CEDULA DE UN DATAGRID
    Function FiltroCedula(ByVal busqueda As String) As DataTable
        'conn.Open()
        Dim NumCedu As Integer = CInt(vericedula)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE ced_cl = " & NumCedu, Conectar.conn)  ' LIKE '" & busqueda.Trim & "%'", Conectar.conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Clientes")
        FrmProveedores.DataGridView1.DataSource = dv
        Conectar.conn.Close()
        Return dt
    End Function

    Private Sub AbreProveedor()
        FrmProveedores.Show()
        'activo el datagrid
        FrmProveedores.DataGridView1.Enabled = True
        'lleno los datos al datagrid
        If FiltroCedula(usuarioglbV).Rows.Count > 0 Then
            FrmProveedores.DataGridView1.DataSource = FiltroCedula(usuarioglbV)
            'deshabilito el boton nuevo
            FrmProveedores.Btnnuevo.Enabled = False
        End If
    End Sub



End Class