Imports System.Data.OleDb

Public Class FrmEliminaEgreso

    Private Sub FrmEliminaEgreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        VerCiudad()

        'DATOS DEL PANEL 1
        '==============================
        'colocamos los texbox en no editable
        Me.Txtced_cl.Enabled = False
        Me.TxtPagado.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.TxtControlPago.Enabled = False
        Me.TxtFechaPago.Enabled = False
        Me.TxtCedPagado.Enabled = False
        Me.TxtConcePago.Enabled = False
        Me.TxtVrPagado.Enabled = False

        'ACTIVO BOTONES
        Me.BtnEliminaPago.Enabled = True
        Me.BtnImpriElim.Enabled = False

        Me.TxtVrPagado.Text = Format(CType(Me.TxtVrPagado.Text, Double), "###,###,###,##0")

        Me.TxtValorElimina.Text = Str(Me.TxtVrPagado.Text)
        Me.TxtNumEliminado.Text = TxtControlPago.Text
        Me.TxtNomCiud.Text = Me.TxtCiudad.Text

        SaldosValor()

    End Sub

#Region "PROCEDIMIENTO DEL  FORMULARIO"

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
            Me.TxtSurname.Text = drd.Item("ape_cl").ToString
        Else
            MsgBox("No se encontro NOMBRES", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
        conn.Close()
    End Sub

    'PROCEDIMIENTO PARA VER CIUDAD
    Private Sub VerCiudad()
        Dim dt As New DataTable
        'revisamos la conexin a la base de datos
        If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            Conectar.conn.Close()
        End If
        Dim consulta As String = "SELECT * FROM Empresa"
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)
        Dim drd As OleDbDataReader
        Conectar.conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            Me.TxtCiudad.Text = drd.Item("ciudad").ToString
        Else
            MsgBox("No se encontro CIUDAD", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
        Conectar.conn.Close()
    End Sub

    'LIMPIA CAMPOS
    Private Sub LimpiaCampos()

        Me.TxtControlPago.Clear()
        Me.TxtFechaPago.Clear()
        Me.Txtced_cl.Clear()
        Me.TxtCiudad.Clear()

        Me.TxtPagado.Clear()
        Me.TxtCedPagado.Clear()
        Me.TxtConcePago.Clear()
        Me.TxtVrPagado.Clear()

    End Sub
#End Region

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE NUEVO PRESTAMO
    Private Sub BtnEliminaPago_Click(sender As Object, e As EventArgs) Handles BtnEliminaPago.Click
        Dim respuesta As Byte
        Dim adaptador As New OleDb.OleDbDataAdapter
        Dim registros As New DataSet
        Dim num As Integer
        num = CInt(Me.TxtControlPago.Text)
        Try
            'hacemos la consulta
            respuesta = CByte(MessageBox.Show("¿Esta seguro de Eliminar este Registro?", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            'verificamos la respuesta
            If respuesta = vbYes Then
                EgresoEliminado()
                EgresoSumaEliminado()
                Me.BtnEliminaPago.Enabled = False
            Else
                Me.BtnX.Select()
                Me.BtnX.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Imposible Eliminar porque...:" & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'posicionamos el cursor
            Me.BtnX.Select()
            Me.BtnX.Focus()
        End Try
    End Sub

    'PROCEDIMIENTO PARA GUARDAR EGRESO POR ELIMINADO
    Private Sub EgresoSumaEliminado()
        'revisamos conexion
        If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            Conectar.conn.Close()
        End If
        'variable de fecha creado
        Dim fechaC As Date = CDate(Format(Date.Now.Date))
        'variable de fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))
        'variable de fecha actual del documento
        Dim FechaACT As Date = CDate(Format(Date.Now.Date))
        'variable de fecha de pago del abono
        Dim FechaPago As Date = CDate(Format(Date.Now.Date))

        Dim nomegre As String = "ABONA EGRESO ELIMINADO"
        TxtNomPaciente.Text = nomegre

        Dim NomPag As String
        NomPag = "ABONO EGRESO ELIMINADO"
        Me.TxtPagado.Text = NomPag

        Dim NomConcePre As String
        NomConcePre = "ANULADO"

        Dim CedPag As String
        CedPag = "1111111111"
        Me.TxtCedPagado.Text = CedPag

        Dim VrPag As String
        VrPag = Me.TxtValorElimina.Text

        Dim VrPagado As String
        VrPagado = 0

        Dim NumConseElim As String
        NumConseElim = Me.TxtNumEliminado.Text
        Me.TxtControlPago.Text = NumConseElim

        Dim ConcePag As String
        ConcePag = "ABONO EGRESO ELIMINADO"
        TxtConcePago.Text = ConcePag

        Dim NumPagoEliminado As Integer
        NumPagoEliminado = 0

        Try

            ''******************************************************************
            ''llamamos la operacion
            Dim cred, vrabono, total As Double
            '=======
            cred = 0
            vrabono = 0
            '=======
            cred = CDbl(Me.TxtSaldoActual.Text)
            vrabono = CDbl(Me.TxtValorElimina.Text)
            total = 0
            total = CDbl(Me.TxtSaldoActual.Text)
            total = total + vrabono
            Me.TxtSaldoActual.Text = total.ToString("###,###,###,##0")
            Me.TxtSaldoActual.Text = total
            '******************************************************************

            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            sql = "INSERT INTO CajamenorAse1 (cedu_pre, nom_pre, fechaactual_pre, nomciud, nompagado, conce_pre, vrprestamo, cedupagado, " &
                                         "vrpagado, fechapago, numpago, fecha_creado, fecha_modifica, vrsaldo, " &
                                         "conce_pago) VALUES ('" & CedPag & "', '" & TxtNomPaciente.Text & "', " &
                                         "'" & FechaACT & "', '" & TxtNomCiud.Text & "', '" & TxtPagado.Text & "', '" & NomConcePre & "', " &
                                         "'" & VrPag & "', '" & TxtCedPagado.Text & "', '" & VrPagado & "', '" & FechaPago & "', " &
                                         "'" & NumPagoEliminado & "', '" & fechaC & "', '" & fechaM & "', " &
                                         "'" & total & "', '" & TxtConcePago.Text & "')"

            cmd.CommandText = sql

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            'MsgBox("EGRESO, Guardado con Éxito", MsgBoxStyle.Information, "AppMinerGold")

            Me.BtnEliminaPago.Enabled = False

            LimpiaCampos()

            Me.TxtValorElimina.Clear()
            Me.TxtSaldoActual.Clear()
            'Me.TxtNumEliminado.Clear()
            Me.TxtName.Clear()
            Me.TxtSurname.Clear()
            Me.TxtNomPaciente.Clear()
            Me.TxtNomCiud.Clear()

            Me.BtnImpriElim.Enabled = True
            Me.BtnImpriElim.Select()
            Me.BtnImpriElim.Focus()

        Catch ex As Exception
            MsgBox("Error al Guardar Egreso.! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
        End Try
        If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            Conectar.conn.Close()
        End If
    End Sub

    'PROCEDIMIENTO PARA ELIMINAR EGRESOS
    Private Sub EgresoEliminado()
        'revisamos la conexion
        Conectar.conn.Close()
        'fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))
        'fecha actual de la operacion
        Dim FechaACT As Date = CDate(Format(Date.Now.Date))
        'variable de fecha de pago del abono
        Dim FechaPago As Date = CDate(Format(Date.Now.Date))

        cmd.CommandType = CommandType.Text
        cmd.Connection = conn

        Dim num As Integer
        num = CInt(Me.TxtControlPago.Text)

        'VARIABLE DE ELIMINACION
        Dim Numcedu, NomEgre, NomPago, ConcePrePago, ConcePago, NumCedPago As String
        Dim ValorPago As Integer

        Numcedu = "1111111111"
        'NomEgre = Me.TxtNomPaciente.Text
        NomEgre = "EGRESO ELIMINADO"
        NomPago = "ANULADO"
        ConcePrePago = "ANULADO"
        ConcePago = "ABONO EGRESO ANULADO"
        NumCedPago = "1111111111"

        ValorPago = 0

        'Me.TxtControlPago.Text = igual
        'Me.DTPfechaactual.Text = actual
        Me.Txtced_cl.Text = Numcedu
        'Me.TxtCiudad.Text = igual

        Me.TxtPagado.Text = NomPago
        Me.TxtCedPagado.Text = NumCedPago
        Me.TxtConcePago.Text = ConcePago
        Me.TxtVrPagado.Text = ValorPago
        'Me.DTPfechapago.Text = igual
        'Me.TxtSaldoActual.Text = igual

        Try
            Dim sqlConsulta As String = "UPDATE CajamenorAse1 SET cedu_pre = '" & Numcedu & "' , " &
                                      "nom_pre = '" & NomEgre & "', " &
                                      "fechaactual_pre = '" & FechaACT & "', " &
                                      "nompagado = '" & NomPago & "', " &
                                      "conce_pre = '" & ConcePrePago & "', " &
                                      "cedupagado = '" & TxtCedPagado.Text & "', " &
                                      "conce_pago = '" & ConcePago & "', " &
                                      "fecha_modifica = '" & fechaM & "' WHERE numpago = " & num

            cmd = New OleDb.OleDbCommand(sqlConsulta, conn)

            'ABRO CONEXION
            Conectar.conn.Open()
            'ejecutamos la consulta
            cmd.ExecuteNonQuery()
            'cierro conexion
            Conectar.conn.Close()

            'presentamos el mensaje 
            MsgBox("Registro Eliminado Exitosamente de la Base de Datos.", MsgBoxStyle.Information, "AppMinerGold")
            Me.BtnEliminaPago.Enabled = False
            LimpiaCampos()
        Catch ex As Exception
            'mensaje de error del procedimiento
            MsgBox("Error: " & Err.Description)
            'muestro el mensaje de resultado
            'MsgBox("Error al Guardar Cambios en los datos" & ex.Message, MsgBoxStyle.Information, "AppMinerGold")
            'cierro conexion
            conn.Close()
        End Try


        'Id                     Auto            Auto            
        'cedu_pre               1111111111      texto           Numcedu
        'nom_pre                ANULADO         texto           NomEgre
        'fechaactual_pre        Actual          fecha          
        'numpresta              =               
        'nomciud                =
        'nompagado              ANULADO         texto           NomPago
        'conce_pre              ANULADO         texto           ConcePrePago 
        'vrprestamo             0               numerico        ValorPre
        'vrpagado               0               numerico        ValorPago
        'fechapago              ACTUAL          fecha           
        'numpago                =                       
        'fecha_creado           =
        'fecha_modifica         ACTUAL          fecha           
        'vrsaldo                0               numerico        sumar el valor 
        'conce_pago             ANULADO         texto           ConcePago
        'cedupagado             1111111111      texto           NumCedPago

        'revisamos la conexion
        Conectar.conn.Close()
    End Sub

    'ACTUALIZA LOS SALDOS VALOR, CONN ABIERTA PARA EL RESTO DE LA APP
    Private Sub SaldosValor()
        Me.TxtSaldoActual.Text = 0
        Dim dt As New DataTable
        Dim consulta As String = "SELECT TOP 1 * FROM CajamenorAse1 ORDER BY id DESC"
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            Me.TxtSaldoActual.Text = drd.Item("vrsaldo").ToString
            Me.TxtSaldoActual.Text = Format(CType(Me.TxtSaldoActual.Text, Double), "###,###,###,###")
        Else
            MsgBox("No se encontro los datos solicitados del SALDO", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
    End Sub

    'BOTON DE IMPRIMIR
    Private Sub BtnImpriCaja_Click(sender As Object, e As EventArgs) Handles BtnImpriElim.Click
        'manejo de cursor
        Me.Cursor = Cursors.WaitCursor
        Dim NumElim As Integer = CInt(TxtNumEliminado.Text)
        FrmImpElimEgre.TxtNumElimina.Text = NumElim
        FrmImpElimEgre.ShowDialog()
        'manejo de cursor
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


End Class