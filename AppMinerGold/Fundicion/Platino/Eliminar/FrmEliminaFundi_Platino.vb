Imports System.Data.OleDb
Public Class FrmEliminaFundi_Platino

    'CARGUE DEL FORMULARIO
    Private Sub FrmEliminaFundi_Platino_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'codigo mostrar hora en formulario
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Timer1.Interval = 1000  ' Un segundo
        Timer1.Start()

        'DESACTIVO LOS CAMPOS
        Me.TxtId.Enabled = False
        Me.TxtConsecutivo.Enabled = False
        Me.TxtFechafundi.Enabled = False
        Me.Txttipometal.Enabled = False
        Me.Txtbrutos.Enabled = False
        Me.Txtley.Enabled = False
        Me.Txtpuros.Enabled = False

        'ACTIVO LOS BOTONES
        Me.BtnEliminaFundi.Enabled = True
        Me.BtnEliminaFundi.Select()
        Me.BtnEliminaFundi.Focus()

    End Sub

    'Cargue del timpo actual en el formulario
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Me.LblFechaActual.Text = Now.ToLongDateString
    End Sub

    'BOTON DE ELIMINAR
    Private Sub BtnEliminaFundi_Click(sender As Object, e As EventArgs) Handles BtnEliminaFundi.Click
        Dim respuesta As Byte
        Dim adaptador As New OleDb.OleDbDataAdapter
        Dim registros As New DataSet
        Dim num As Integer
        num = CInt(Me.TxtConsecutivo.Text)
        Try
            'revisamos conexion
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Open()
            End If
            'hacemos la consulta
            respuesta = CByte(MsgBox("¿Esta seguro de Eliminar este Registro de Fundición?", MsgBoxStyle.YesNo, "AppMinerGold"))
            'verificamos la respuesta
            If respuesta = vbYes Then
                Dim ConnString As String = cs
                'conn.ConnectionString = cs
                Dim SqlString As String = "DELETE FROM fundicion WHERE numdocufundi = " & num
                cmd = New OleDbCommand(SqlString, Conectar.conn)
                cmd.ExecuteNonQuery()
                Eliminafuncion()
                MessageBox.Show("Fundición eliminada con exito de la base de datos!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BtnEliminaFundi.Enabled = False
                'DESACTIVO LOS CAMPOS
                Me.TxtId.Enabled = False
                Me.TxtConsecutivo.Enabled = False
                Me.TxtFechafundi.Enabled = False
                Me.Txttipometal.Enabled = False
                Me.Txtbrutos.Enabled = False
                Me.Txtley.Enabled = False
                Me.Txtpuros.Enabled = False
                'LIMPIO LOS CAMPOS
                Me.TxtId.Clear()
                Me.TxtConsecutivo.Clear()
                Me.TxtFechafundi.Clear()
                Me.Txttipometal.Clear()
                Me.Txtbrutos.Clear()
                Me.Txtley.Clear()
                Me.Txtpuros.Clear()
                'cierro conexion
                Conectar.conn.Close()
                Refresh()
                'posicionamos el cursor
            Else

            End If
            Conectar.conn.Close()
            Refresh()
        Catch ex As Exception
            MessageBox.Show("Imposible Eliminar porque...:" & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Por Ultimo Cierro La conexion
        Conectar.conn.Close()
    End Sub

    'PROCESO PARA CAMBIAR LOS DATOS DE LA FUNDICION - TABLA DECLARA REACTIVAR LOS PROVEEDORES
    Private Sub Eliminafuncion()
        Dim num As Integer
        num = CInt(Me.TxtConsecutivo.Text)
        Dim cambiofundi, cambiovery As String
        cambiofundi = "0"
        cambiovery = "0"
        Try
            'REVISO LA CONEXION
            If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
                Conectar.conn.Close()
            End If
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            Dim sqlConsulta As String = "UPDATE Declara SET numfundi = '" & cambiofundi & "',  " &
                                              "verifica = '" & cambiovery & "' WHERE numfundi = '" & TxtConsecutivo.Text & "'"
            cmd = New OleDb.OleDbCommand(sqlConsulta, conn)
            conn.Open()
            'ejecutamos la consulta
            cmd.ExecuteNonQuery()
            'cierro conexion
            conn.Close()
            'presentamos el mensaje 
            'MsgBox("Registro Atualizado exitosamente", MsgBoxStyle.Information, "AppMinerGold")
        Catch ex As Exception
            'mensaje de error del procedimiento
            'MsgBox("Error: " & Err.Description)
            'muestro el mensaje de resultado
            'MessageBox.Show(ex.Message)
            'MsgBox("Falta información por ingresar, Regalias", MsgBoxStyle.Information, "AppMinerGold")
        End Try

    End Sub

    'BOTON DE CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class