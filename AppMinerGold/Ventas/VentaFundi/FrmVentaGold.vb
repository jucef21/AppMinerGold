Imports System.Data.OleDb

Public Class FrmVentaGold

    Private Sub FrmVentaGold_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'llenamos los datos con la informacion seleccionada
        Me.Txtced_cl.Text = ModuleFrm.ced_consulta
        Me.TxtNomEmp.Text = ModuleFrm.Nom_consulta

        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomPaciente.Text = ModuleFrm.Nom_consulta

        'revisamos la conexion
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        'DATOS DEL PANEL 1
        '==============================
        'INGRESOS limpio datos
        Me.TxtControlPago.Clear()

        'colocamos los texbox en no editable
        Me.TxtControlPago.Enabled = False
        Me.TxtNomEmp.Enabled = False
        Me.Txtced_cl.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.DTPfechaactual.Enabled = False

        'formato del datatimepicker
        Me.DTPfechaactual.Format = DateTimePickerFormat.Custom
        Me.DTPfechaactual.CustomFormat = "dd/MM/yyyy"
        Me.DTPfechaactual.Value.ToString()
        Me.DTPfechaactual.Value = Date.Now.ToString("d")

        'DATOS DEL PANEL 2
        '==============================
        'INGRESOS limpio datos
        Me.TxtPagado.Clear()
        Me.TxtCedPagado.Clear()
        Me.TxtDireVentas.Clear()
        Me.TxtCiudVentas.Clear()
        Me.TxtTelVentas.Clear()
        Me.TxtConcePago.Clear()
        Me.TxtDispoBrutos.Clear()
        Me.TxtDispoLey.Clear()
        Me.TxtDispoPuros.Clear()
        Me.TxtBrutosVenta.Clear()
        Me.TxtLeyVenta.Clear()
        Me.Txtpurosventa.Clear()
        Me.TxtVrPagado.Clear()
        Me.TxtVrRegalias.Clear()
        Me.TxtMesRega.Clear()
        Me.TxtVrRf.Clear()
        Me.TxtRfValor.Clear()
        Me.TxtCuatro.Clear()
        Me.TxtVrTotal.Clear()
        Me.TxtTotalRegalias.Clear()
        Me.TxtTotalrf.Clear()
        Me.TxtVrNeto.Clear()

        'colocamos los texbox en no editable
        Me.TxtPagado.Enabled = False
        Me.TxtCedPagado.Enabled = False
        Me.TxtDireVentas.Enabled = False
        Me.TxtCiudVentas.Enabled = False
        Me.TxtTelVentas.Enabled = False
        Me.TxtConcePago.Enabled = False
        Me.TxtDispoBrutos.Enabled = False
        Me.TxtDispoLey.Enabled = False
        Me.TxtDispoPuros.Enabled = False
        Me.TxtBrutosVenta.Enabled = False
        Me.TxtLeyVenta.Enabled = False
        Me.Txtpurosventa.Enabled = False
        Me.TxtVrPagado.Enabled = False
        Me.TxtVrRegalias.Enabled = False
        Me.TxtMesRega.Enabled = False
        Me.TxtVrRf.Enabled = False
        Me.TxtRfValor.Enabled = False
        Me.TxtCuatro.Enabled = False
        Me.TxtVrTotal.Enabled = False
        Me.TxtTotalRegalias.Enabled = False
        Me.TxtTotalrf.Enabled = False
        Me.TxtVrNeto.Enabled = False

        'DATOS DEL PANEL 3
        '==============================
        'INHABILITO EL DATAGRID
        Me.DGVegresos.Enabled = False

        'ACTUALIZO EL DATAGRID CON DATOS 
        ActualizoDatagrid()

        'Actualizo el saldo
        SaldosEgresoInicial()

        'INHABILITO EL BOTON DE GUARDAR
        Me.BtnGuardaPago.Enabled = False

        'ACTIVO BOTONES
        Me.BtnCalcular.Enabled = False
        Me.BtnNuevoPago.Enabled = True
        Me.BtnGuardaPago.Enabled = False
        Me.BtnImpriCaja.Enabled = False
        Me.BtnRegreCaja.Enabled = True

    End Sub

#Region "PROCEDIMIENTO DEL  FORMULARIO"

    'PROCEDIMIENTO PARA UNIR NOMBRE Y APELLIDO DEL CLIENTE
    Private Sub UnirNombres()
        Dim dt As New DataTable
        'conn.ConnectionString = cs
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

    'ACTUALIZA DATAGRID EN TIEMPO DE EJECUCCION
    Private Sub ActualizoDatagrid()
        Dim sqlPresta As String
        Dim conn As New OleDb.OleDbConnection
        'sqlPresta = "SELECT * FROM Compraventa WHERE ced_cl = '" & Txtced_cl.Text & "' ORDER BY id ASC"
        sqlPresta = "SELECT * FROM Compraventa ORDER BY id ASC"
        conn.ConnectionString = cs
        Dim adaptador As New OleDb.OleDbDataAdapter(sqlPresta, conn)
        Dim dt As New DataTable("Compraventa")
        adaptador.Fill(dt)
        DGVegresos.DataSource = dt
        Dim cantRegistros As Integer = DGVegresos.Rows.Count
        LblRegistros.Text = cantRegistros
    End Sub

    'ACTUALIZA DATOS DEL VALOR DEL SALDO ACTUAL, PARA EL FORMULARIO LOAD
    Private Sub SaldosEgresoInicial()
        Dim dt As New DataTable
        Dim conn As New OleDbConnection(cs)
        Dim consulta As String = "SELECT TOP 1 * FROM CajamenorAse1 WHERE cedu_pre = '" & Txtced_cl.Text & "' ORDER BY id DESC"
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read() Then
            Me.TxtVrNeto.Text = drd.Item("vrsaldo").ToString
            'MsgBox("El saldo es: " + Me.TxtSaldoActual.Text)
            Dim MyObject As Double
            MyObject = TxtVrNeto.Text
            TxtVrNeto.Text = CStr(MyObject.ToString("#,###,##0"))
        Else
            MsgBox("Saldo Inicial en Cero, Ingrese un valor a la Caja", MsgBoxStyle.Information, "AppMinerGold")
            Me.TxtVrNeto.Text = 0
            'Dim SaldoTotal As Double
            'Me.TxtSaldoActual.Text = Format(SaldoTotal, "$ #,###,##0")
            Dim MyObject As Double
            MyObject = TxtVrNeto.Text
            TxtVrNeto.Text = CStr(MyObject.ToString("###,###,###,##0"))
            'colocamos los texbox en no editable
            Me.Txtced_cl.Enabled = False
            Me.TxtPagado.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.DTPfechaactual.Enabled = False
            Me.TxtControlPago.Enabled = False
            Me.TxtCedPagado.Enabled = False
            Me.TxtConcePago.Enabled = False
            Me.TxtVrPagado.Enabled = False
            'ACTIVO BOTONES
            Me.BtnNuevoPago.Enabled = False
            Me.BtnGuardaPago.Enabled = False
            Me.BtnImpriCaja.Enabled = False
            Me.BtnRegreCaja.Enabled = True
        End If
        drd.Close()
        conn.Close()

    End Sub

    'VALIDA CAMPOS VACIOS
    Private Sub ValidaCamposVaciosEgresos()
        If Me.TxtPagado.TextLength > 0 And Me.TxtCedPagado.TextLength > 0 And Me.TxtDireVentas.TextLength > 0 And Me.TxtCiudVentas.TextLength > 0 And Me.TxtTelVentas.TextLength > 0 And Me.TxtConcePago.TextLength > 0 And Me.TxtBrutosVenta.TextLength > 0 And Me.TxtLeyVenta.TextLength > 0 And Me.Txtpurosventa.TextLength > 0 Then
            BtnGuardaPago.Enabled = True
        Else
            BtnGuardaPago.Enabled = False
        End If
    End Sub

    'VALIDA SALDO ACTUAL, QUE EL EGRESO NO SEA MAYOR
    Private Sub RevisaEgreso()
        '===========================================================
        'codigo ok
        'Dim dt As New DataTable
        'Dim conn As New OleDbConnection(cs)
        'Dim consulta As String = "SELECT TOP 1 * FROM CajamenorAse1 WHERE cedu_pre = '" & Txtced_cl.Text & "' ORDER BY id DESC"
        'Dim cmd As New OleDbCommand(consulta, conn)
        'Dim drd As OleDbDataReader
        'conn.Open()
        'drd = cmd.ExecuteReader
        'If drd.Read() Then
        '    Me.TxtSaldoActual.Text = drd.Item("vrsaldo").ToString
        '    Me.TxtSaldoActual.Text = Format(CType(Me.TxtSaldoActual.Text, Double), "###,###,###,###")
        '    If Me.TxtVrPagado.Text > Me.TxtSaldoActual.Text Then
        '        MsgBox("El valor pagado es mayor al saldo actual, Ingrese su saldo en caja para continuar", MsgBoxStyle.Information, "AppMinerGold")
        '        Me.GroupBox1.Select()
        '        Me.GroupBox1.Focus()
        '        Me.TxtVrPagado.Focus()
        '        Me.BtnNuevoPago.Focus()
        '    Else
        '        GuardaEgresos()
        '    End If
        'End If
        'drd.Close()
        '===========================================================


        Dim x, y As Integer
        x = CInt(Me.TxtVrPagado.Text)
        y = CInt(Me.TxtVrNeto.Text)
        If (x > y) Then
            MsgBox("El valor pagado es mayor al saldo actual, Ingrese su saldo en caja para continuar", MsgBoxStyle.Information, "AppMinerGold")

            Dim MyObject As Double
            MyObject = TxtVrNeto.Text
            TxtVrNeto.Text = CStr(MyObject.ToString("###,###,###,##0"))

            Me.GroupBox1.Select()
            Me.GroupBox1.Focus()
            Me.TxtVrPagado.Focus()
            Me.BtnNuevoPago.Focus()
        Else
            GuardaEgresos()
        End If

    End Sub

    'ACTUALIZA LOS SALDOS CAJAS DE TEXTO, CONN CERRADA PARA EL RESTO DE LA APP
    Private Sub ActualizaSaldosEgresos()
        Me.TxtVrNeto.Text = 0
        Dim dt As New DataTable
        Dim consulta As String = "SELECT TOP 1 * FROM CajamenorAse1 WHERE cedu_pre = '" & Txtced_cl.Text & "' ORDER BY id DESC"
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        'conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            Me.TxtVrNeto.Text = drd.Item("vrsaldo").ToString
            Me.TxtVrNeto.Text = Format(CType(Me.TxtVrNeto.Text, Double), "###,###,###,###")
        Else
            MsgBox("No se encontro los datos solicitados del SALDO", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
    End Sub

    'ACTUALIZA LOS SALDOS DISPONIBLE PARA VENDER
    Private Sub SaldosDisponible()
        Me.TxtVrNeto.Text = 0
        Dim dt As New DataTable
        Dim consulta As String = "SELECT TOP 1 * FROM Compraventa  ORDER BY id DESC"
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        'conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            Me.TxtDispoBrutos.Text = drd.Item("vrsaldobrutosC").ToString
            Me.TxtDispoLey.Text = drd.Item("vrsaldoleyC").ToString
            Me.TxtDispoPuros.Text = drd.Item("vrsaldopurosC").ToString

            'Me.TxtDispoBrutos.Text = Format(CType(Me.TxtVrNeto.Text, Double), "##0.00")

            Dim SaldoBr, SaldoLey, SaldoPu As Double
            SaldoBr = Me.TxtDispoBrutos.Text
            SaldoLey = Me.TxtDispoLey.Text
            SaldoPu = Me.TxtDispoPuros.Text

            Me.TxtDispoBrutos.Text = Math.Round(SaldoBr, 4).ToString
            Me.TxtDispoLey.Text = Math.Round(SaldoLey, 4).ToString
            Me.TxtDispoPuros.Text = Math.Round(SaldoPu, 4).ToString

        Else
            MsgBox("No se encontro Saldos Disponibles", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
    End Sub

    Dim TxtR As String
    Dim Xr As Single
    Public VrR As Single
    'ACTUALIZA REGALIAS
    Private Sub ActRegalias()
        'REVISO LA CONEXION
        If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
            Conectar.conn.Close()
        End If
        'CREO LA CONSULTA
        Dim dt As New DataTable
        Conectar.Conectarse()
        'variable fecha actual
        Dim fechaACT As String
        fechaACT = CStr(DTPfechaactual.Value.Date)
        Dim consulta As String = "SELECT TOP 1 * FROM Regalias WHERE id = id ORDER BY Id DESC "
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)
        Try
            Dim drd As OleDbDataReader
            'conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                'GROUPBOX 2 ======================
                Me.TxtVrRegalias.Text = drd.Item("detalle").ToString
                Me.TxtMesRega.Text = drd.Item("descri").ToString
                Dim Xr As Decimal = CDec(If(TxtVrRegalias.Text.Contains("."), TxtVrRegalias.Text.Replace(".", ","), TxtVrRegalias.Text))
                Xr = Math.Round(Xr, 4)
                Me.TxtVrRegalias.Text = Xr.ToString
                VrR = Xr
                'Me.TxtRegalias.Text = Format(VrR, "###,##0.00")
            Else
                MsgBox("No se encontro Datos de Regalias, Falta información por ingresar", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Falta información por ingresar, Regalias", MsgBoxStyle.Information, "AppMinerGold")
        End Try

    End Sub

    'Dim TxtRTF As String
    Dim XrRTF As Single
    Public VrRTF As Single
    'ACTUALIZA RETEFUENTE
    Private Sub ActRetefuente()
        'REVISO LA CONEXION
        If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
            Conectar.conn.Close()
        End If
        'CREO LA CONSULTA
        Dim dt As New DataTable
        Conectar.Conectarse()
        'variable fecha actual
        Dim fechaACT As String
        fechaACT = CStr(DTPfechaactual.Value.Date)
        Dim consulta As String = "SELECT TOP 1 * FROM Retefuente WHERE id = id ORDER BY Id DESC "
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)
        Try
            Dim drd As OleDbDataReader
            'conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                'GROUPBOX 2 ======================
                Me.TxtRfValor.Text = drd.Item("detalle").ToString
                'Me.TxtMesRega.Text = drd.Item("descri").ToString
                Dim XrRTF As Decimal = CDec(If(TxtRfValor.Text.Contains("."), TxtRfValor.Text.Replace(".", ","), TxtRfValor.Text))
                XrRTF = Math.Round(XrRTF, 4)
                Me.TxtRfValor.Text = XrRTF.ToString
                VrRTF = XrRTF
            Else
                MsgBox("No se encontro Datos de Retefuente, Falta información por ingresar", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Falta información por ingresar, Retefuente", MsgBoxStyle.Information, "AppMinerGold")
        End Try
    End Sub

#End Region

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE NUEVO PRESTAMO
    Private Sub BtnNuevoPago_Click(sender As Object, e As EventArgs) Handles BtnNuevoPago.Click

        'ACTUALIZA SALDOS 
        'Saldos Disponible de material de venta
        SaldosDisponible()
        'Saldo del valor de las regalias mensuales
        ActRegalias()
        'saldo del porcentaje de la retefuente
        ActRetefuente()


        'PANEL 1 =====================================
        'colocamos los texbox en no editable
        Me.TxtControlPago.Enabled = False
        Me.TxtNomEmp.Enabled = False
        Me.Txtced_cl.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.DTPfechaactual.Enabled = False

        'PANEL 2 =====================================
        'INGRESOS limpio datos
        Me.TxtPagado.Clear()
        Me.TxtCedPagado.Clear()
        Me.TxtDireVentas.Clear()
        Me.TxtCiudVentas.Clear()
        Me.TxtTelVentas.Clear()
        Me.TxtConcePago.Clear()
        Me.TxtBrutosVenta.Clear()
        Me.TxtLeyVenta.Clear()
        Me.Txtpurosventa.Clear()
        Me.TxtVrPagado.Clear()
        'Me.TxtVrRegalias.Clear()
        'Me.TxtMesRega.Clear()
        'Me.TxtVrRf.Clear()
        'Me.TxtRfValor.Clear()
        Me.TxtCuatro.Clear()
        Me.TxtVrTotal.Clear()
        Me.TxtTotalRegalias.Clear()
        Me.TxtTotalrf.Clear()
        Me.TxtVrNeto.Clear()

        'colocamos los texbox en no editable
        Me.TxtPagado.Enabled = True
        Me.TxtCedPagado.Enabled = True
        Me.TxtDireVentas.Enabled = True
        Me.TxtCiudVentas.Enabled = True
        Me.TxtTelVentas.Enabled = True
        Me.TxtConcePago.Enabled = True
        Me.TxtBrutosVenta.Enabled = True
        Me.TxtLeyVenta.Enabled = True
        Me.Txtpurosventa.Enabled = False
        Me.TxtVrPagado.Enabled = True
        '====SOLO VALORES FIJOS
        Me.TxtDispoBrutos.Enabled = False
        Me.TxtDispoLey.Enabled = False
        Me.TxtDispoPuros.Enabled = False
        Me.TxtVrTotal.Enabled = False
        Me.TxtTotalRegalias.Enabled = False
        Me.TxtMesRega.Enabled = False
        Me.TxtTotalrf.Enabled = False
        Me.TxtVrNeto.Enabled = False
        Me.TxtVrRegalias.Enabled = False
        Me.TxtVrRf.Enabled = False
        Me.TxtRfValor.Enabled = False
        Me.TxtCuatro.Enabled = False

        'ubico el cursor
        Me.TxtPagado.Select()
        Me.TxtPagado.Focus()

        'ejecutamos contador
        ContadorPagos()

        'HABILITO LOS BOTONES
        Me.BtnCalcular.Enabled = True

        Me.BtnNuevoPago.Visible = True
        Me.BtnNuevoPago.Enabled = False

        Me.BtnGuardaPago.Visible = True
        Me.BtnGuardaPago.Enabled = True

        Me.BtnImpriCaja.Visible = True
        Me.BtnImpriCaja.Enabled = False

        Me.BtnRegreCaja.Visible = True
        Me.BtnRegreCaja.Enabled = True

        'INHABILITO EL DATAGRID
        Me.DGVegresos.Enabled = False

    End Sub

    'BOTON DE GUARDAR INGRESOS
    Private Sub BtnGuardapago_Click(sender As Object, e As EventArgs) Handles BtnGuardaPago.Click

        Try
            If Me.ValidateChildren And TxtBrutosVenta.Text = "" Or TxtLeyVenta.Text = "" Or TxtVrPagado.Text = "" Then
                MessageBox.Show("Datos OK", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'MessageBox.Show("Dato Error", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'llamo al procedimiento 
                'RevisaEgreso()

                'GuardaEgresos()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'limpio los campos
        Me.TxtControlPago.Clear()
        Me.TxtPagado.Clear()
        Me.TxtConcePago.Clear()
        Me.TxtVrPagado.Clear()
        Me.TxtVrNeto.Clear()
        Me.TxtCedPagado.Clear()

        'inhabilito los campos
        Me.Txtced_cl.Enabled = False
        Me.TxtPagado.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.DTPfechaactual.Enabled = False
        Me.TxtControlPago.Enabled = False
        Me.TxtCedPagado.Enabled = False
        Me.TxtConcePago.Enabled = False
        Me.TxtVrPagado.Enabled = False

        'DESHABILITO LOS BOTONES
        'HABILITO LOS BOTONES
        Me.BtnNuevoPago.Visible = True
        Me.BtnNuevoPago.Enabled = False

        Me.BtnGuardaPago.Visible = False
        Me.BtnGuardaPago.Enabled = False

        Me.BtnImpriCaja.Visible = True
        Me.BtnImpriCaja.Enabled = True

        Me.BtnRegreCaja.Visible = True
        Me.BtnRegreCaja.Enabled = True

        'lleno el SALDO ACTUAL
        'SaldosValor()

        'INHABIITO EL DATAGRID
        Me.DGVegresos.Enabled = False

        'ubico el cursor
        Me.BtnNuevoPago.Enabled = True
        Me.BtnImpriCaja.Focus()


    End Sub

    'PROCEDIMIENTO PARA GUARDAR INGRESOS
    Private Sub GuardaEgresos()

        'revisamos la conexion
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        'INHABILITO EL DATAGRID
        Me.DGVegresos.Enabled = False

        'variable de fecha creado
        Dim fechaC As Date = CDate(Format(Date.Now.Date))
        'variable de fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))
        'variable de fecha actual del documento
        Dim FechaACT As Date = CDate(Format(Date.Now.Date))
        Try

            ''******************************************************************
            ''llamamos la operacion
            'Dim cred, vrabono, total As Double
            ''=======
            'cred = 0
            'vrabono = 0
            ''=======
            'cred = CDbl(Me.TxtVrNeto.Text)
            'vrabono = CDbl(Me.TxtVrPagado.Text)
            'total = 0
            'total = CDbl(Me.TxtVrNeto.Text)
            'total = total - vrabono
            'Me.TxtVrNeto.Text = total.ToString("###,###,###,##0")
            'Me.TxtVrNeto.Text = total
            '******************************************************************
            'INDICA QUE LOS VALORES DE SALDO YA FUERON UTILIZADOS
            Dim ventas1 As String
            ventas1 = "2"

            'INDICA QUE SE PRODUJO UNA VENTA Y CUANDO ES 0 QUEDA DISPONIBLE
            Dim ventas2 As String
            ventas2 = "1"

            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            sql = "INSERT INTO Compraventa (numventa, nompagado, cedunit, nomciud, fechaventa, razonsocial, " &
                  "cedunitventa, direccionventa, ciudadventa, telcventa, conceventas, vrbrutosventa, vrleyventa, " &
                  "vrgrpurosventa, vrpagadobase, vrregalias, vrrete, vrcuatro, vrtotal, vrtotalrega, vrtotalrf, " &
                  "vrneto, ventas1, ventas2, fecha_creado, fecha_modifica) VALUES ('" & TxtControlPago.Text & "', " &
                  "'" & TxtNomEmp.Text & "','" & Txtced_cl.Text & "','" & TxtNomEmp.Text & "','" & FechaACT & "','" & TxtPagado.Text & "', " &
                  "'" & TxtCedPagado.Text & "','" & TxtDireVentas.Text & "','" & TxtCiudVentas.Text & "','" & TxtTelVentas.Text & "', " &
                  "'" & TxtConcePago.Text & "','" & TxtBrutosVenta.Text & "','" & TxtLeyVenta.Text & "','" & Txtpurosventa.Text & "', " &
                  "'" & TxtVrPagado.Text & "','" & TxtVrRegalias.Text & "','" & TxtVrRf.Text & "','" & TxtCuatro.Text & "', " &
                  "'" & TxtVrTotal.Text & "','" & TxtTotalRegalias.Text & "','" & TxtTotalrf.Text & "', " &
                  "'" & TxtVrNeto.Text & "','" & ventas1 & "','" & ventas2 & "','" & fechaC & "','" & fechaM & "')"

            cmd.CommandText = sql

            'para ejecutar la consulta
            cmd.ExecuteNonQuery()

            'muestro el mensaje de guardar
            MsgBox("Venta, Guardada con Éxito", MsgBoxStyle.Information, "AppMinerGold")

            'actualizo el datagrid
            ActualizoDatagrid()

            'cierro la conexcion
            conn.Close()

        Catch ex As Exception

            'muestro el mensaje
            MsgBox("Error al Guardar Egreso.! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")

            'limpio todo
            Me.TxtControlPago.Clear()
            Me.TxtPagado.Clear()
            Me.TxtConcePago.Clear()
            Me.TxtVrPagado.Clear()
            Me.TxtVrNeto.Clear()
            Me.TxtCedPagado.Clear()

            'ubico el cursor
            Me.TxtConcePago.Focus()

            'cierro conexcion
            conn.Close()
        End Try

    End Sub

    'BOTON DE IMPRIMIR
    Private Sub BtnImpriCaja_Click(sender As Object, e As EventArgs) Handles BtnImpriCaja.Click
        FrmRptImpEgreso.Show()
    End Sub

    'BOTON DE REGRESAR
    Private Sub BtnRegreCaja_Click(sender As Object, e As EventArgs) Handles BtnRegreCaja.Click
        'cierro el formulario
        Me.Close()
        'cierro la base de datos
        conn.Close()
        'abro el nuevo formulario
        FrmVentas.Show()
    End Sub

#End Region

#Region "EVENTOS KEYPRESS DEL  FORMULARIO SOLO ENTER Y CONTINUA"

    'PERMITE TECLA ENTER
    Private Sub Txtpagado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPagado.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCedpagado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCedPagado.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtDireVentas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDireVentas.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCiudVentas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCiudVentas.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtConcepago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtConcePago.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DGVegresos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGVegresos.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

#Region "DATAGRIDVIEW INGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW COMPRAVENTA
    Private Sub DGVegresos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVegresos.CellFormatting

        'Scroll to the last row. 
        Me.DGVegresos.FirstDisplayedScrollingRowIndex = Me.DGVegresos.RowCount - 1
        Me.DGVegresos.Rows(Me.DGVegresos.Rows.Count - 1).Selected = True

        'activo el datagrid
        Me.DGVegresos.Enabled = True

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVegresos.RowsDefaultCellStyle
            Me.DGVegresos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVegresos.Columns(0).Width = 30
            Me.DGVegresos.Columns(0).HeaderText = "Id"
            Me.DGVegresos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVegresos.Columns(1).Width = 50
            Me.DGVegresos.Columns(1).HeaderText = "No. Compra"
            Me.DGVegresos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVegresos.Columns(4).Width = 90
            Me.DGVegresos.Columns(4).HeaderText = "Fecha Compra"
            Me.DGVegresos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVegresos.Columns(13).Width = 90
            Me.DGVegresos.Columns(13).HeaderText = "Gr. Brutos Compra"
            Me.DGVegresos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVegresos.Columns(13).DefaultCellStyle.Format = "N4"

            Me.DGVegresos.Columns(14).Width = 60
            Me.DGVegresos.Columns(14).HeaderText = "Ley Compra"
            Me.DGVegresos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVegresos.Columns(14).DefaultCellStyle.Format = "N4"

            Me.DGVegresos.Columns(15).Width = 90
            Me.DGVegresos.Columns(15).HeaderText = "Gr. Puros Compra"
            Me.DGVegresos.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVegresos.Columns(15).DefaultCellStyle.Format = "N4"

            Me.DGVegresos.Columns(16).Width = 50
            Me.DGVegresos.Columns(16).HeaderText = "Ajuste"
            Me.DGVegresos.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVegresos.Columns(16).DefaultCellStyle.Format = "N4"

            Me.DGVegresos.Columns(18).Width = 90
            Me.DGVegresos.Columns(18).HeaderText = "Saldo Gr. Brutos"
            Me.DGVegresos.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVegresos.Columns(18).DefaultCellStyle.Format = "N4"

            Me.DGVegresos.Columns(19).Width = 60
            Me.DGVegresos.Columns(19).HeaderText = "Saldo Ley"
            Me.DGVegresos.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVegresos.Columns(19).DefaultCellStyle.Format = "N4"

            Me.DGVegresos.Columns(20).Width = 90
            Me.DGVegresos.Columns(20).HeaderText = "Saldo Gr. Puros"
            Me.DGVegresos.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVegresos.Columns(20).DefaultCellStyle.Format = "N4"

            'Me.DGVegresos.Columns(16).Width = 90
            'Me.DGVegresos.Columns(16).HeaderText = "Saldo Ley"
            'Me.DGVegresos.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.DGVegresos.Columns(16).DefaultCellStyle.Format = "N4"

            'Me.DGVegresos.Columns(17).Width = 90
            'Me.DGVegresos.Columns(17).HeaderText = "Saldo Gramos Puros"
            'Me.DGVegresos.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.DGVegresos.Columns(17).DefaultCellStyle.Format = "N4"

            'Me.DGVegresos.Columns(19).Width = 90
            'Me.DGVegresos.Columns(19).HeaderText = "Fecha Venta"
            'Me.DGVegresos.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Me.DGVegresos.Columns(20).Width = 90
            'Me.DGVegresos.Columns(20).HeaderText = "No. Doc. Venta"
            'Me.DGVegresos.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Me.DGVegresos.Columns(26).Width = 90
            'Me.DGVegresos.Columns(26).HeaderText = "Ley Venta"
            'Me.DGVegresos.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DGVegresos.Columns(26).DefaultCellStyle.Format = "N4"

            'Me.DGVegresos.Columns(27).Width = 90
            'Me.DGVegresos.Columns(27).HeaderText = "Gramos Puros Venta"
            'Me.DGVegresos.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.DGVegresos.Columns(27).DefaultCellStyle.Format = "N4"


            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVegresos.Columns("Id").Visible = False                       '00
            'Me.DGVegresos.Columns("numcompra").Visible = False                '01
            Me.DGVegresos.Columns("cedunit").Visible = False                  '02
            Me.DGVegresos.Columns("nomciud").Visible = False                  '03    
            'Me.DGVegresos.Columns("fechaingreso").Visible = False             '04
            Me.DGVegresos.Columns("nompagado").Visible = False                '05
            '=================
            Me.DGVegresos.Columns("saldoBrutos").Visible = False             '06
            Me.DGVegresos.Columns("saldoley").Visible = False                 '07
            Me.DGVegresos.Columns("saldopuros").Visible = False               '08
            '=================
            Me.DGVegresos.Columns("numtraslado").Visible = False              '09
            Me.DGVegresos.Columns("grbrutosT").Visible = False                '10
            Me.DGVegresos.Columns("leyT").Visible = False                     '11
            Me.DGVegresos.Columns("grpurosT").Visible = False                 '12
            '=================
            'Me.DGVegresos.Columns("brutosnuevos").Visible = False             '13
            'Me.DGVegresos.Columns("leynueva").Visible = False                 '14
            'Me.DGVegresos.Columns("grpurosnuevos").Visible = False            '15
            'Me.DGVegresos.Columns("ajuste").Visible = False                   '16
            Me.DGVegresos.Columns("concenuevo").Visible = False               '17
            '=================
            'Me.DGVegresos.Columns("vrsaldobrutosC").Visible = False           '18
            'Me.DGVegresos.Columns("vrsaldoleyC").Visible = False              '19
            'Me.DGVegresos.Columns("vrsaldopurosC").Visible = False            '20
            Me.DGVegresos.Columns("verificaC").Visible = False                '21
            '=================
            Me.DGVegresos.Columns("fechaventa").Visible = False               '22
            Me.DGVegresos.Columns("cedunitventa").Visible = False             '23
            Me.DGVegresos.Columns("numventa").Visible = False                 '24
            Me.DGVegresos.Columns("razonsocial").Visible = False              '25
            Me.DGVegresos.Columns("direccionventa").Visible = False           '26
            Me.DGVegresos.Columns("telcventa").Visible = False                '27
            Me.DGVegresos.Columns("ciudadventa").Visible = False              '28
            '=================
            Me.DGVegresos.Columns("vrbrutosventa").Visible = False            '29
            Me.DGVegresos.Columns("vrleyventa").Visible = False               '30
            Me.DGVegresos.Columns("vrgrpurosventa").Visible = False           '31
            '=================
            Me.DGVegresos.Columns("vrsaldobrutosventa").Visible = False       '32
            Me.DGVegresos.Columns("vrsaldoleyventa").Visible = False          '33
            Me.DGVegresos.Columns("vrsaldopurosventa").Visible = False        '34
            Me.DGVegresos.Columns("conceventas").Visible = False              '35
            '=================
            Me.DGVegresos.Columns("vrpagadobase").Visible = False             '36
            Me.DGVegresos.Columns("vrregalias").Visible = False               '37
            Me.DGVegresos.Columns("vrrete").Visible = False                   '38
            Me.DGVegresos.Columns("vrcuatro").Visible = False                 '39
            Me.DGVegresos.Columns("vrtotal").Visible = False                  '40
            Me.DGVegresos.Columns("vrtotalrega").Visible = False              '41
            Me.DGVegresos.Columns("vrtotalrf").Visible = False                '42
            Me.DGVegresos.Columns("vrneto").Visible = False                   '43

            Me.DGVegresos.Columns("ventas1").Visible = False                  '44
            Me.DGVegresos.Columns("ventas2").Visible = False                  '45
            Me.DGVegresos.Columns("fecha_creado").Visible = False             '46
            Me.DGVegresos.Columns("fecha_modifica").Visible = False           '47

        End With

    End Sub

#End Region

#Region "VALIDACIONES CAMPOS NUMERICOS Y KEYPRESS"

    'FUNCION PARA SOLO NUMEROS funcion par validar los campos de texto en Numeros 
    Private Sub SoloTextosNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelVentas.KeyPress, TxtCedPagado.KeyPress
        'TxtBrutosVenta.KeyPress, TxtLeyVenta.KeyPress, Txtpurosventa.KeyPress, TxtVrPagado.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            'MsgBox("Solo Digite Números")
            MsgBox("En este  Campo Solo Digite Números", MsgBoxStyle.Critical, "AppMinerGold")
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    ''FORMATO DEL CAMPO DE TEXTO EN NUMERICO
    'Private Sub TxtVrPagado_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles TxtVrPagado.Leave
    '    Me.TxtVrPagado.Text = Format(Val(TxtVrPagado.Text), "#,###,###,###")
    'End Sub

#End Region

#Region "CONTADORES PARA EGRESOS"

    'CONTADOR
    Function ContadorPagos()
        Dim conT As String
        conT = Txtced_cl.Text
        UltimoIdPago()
        Me.TxtControlPago.Text = UltimoIdPago()
        Return conT
    End Function

    'para encontrar el valor máximo de una columna y ultimo registro
    Public Function UltimoIdPago() As String
        conn.Close()
        Dim resultado As String
        resultado = 0
        Dim query As String = "SELECT MAX(numventa)FROM Compraventa"
        Dim comando As OleDbCommand
        Dim lector As OleDbDataReader
        conn.Open()
        comando = New OleDbCommand(query, conn)
        lector = comando.ExecuteReader
        If lector.Read Then
            resultado = Val(lector(0).ToString)
        End If
        lector.Close()
        conn.Close()
        resultado = resultado + 1
        Return resultado
    End Function


#End Region

#Region "ENVENTO CHANGE Y VALIDA CAMPOS VACIOS"

    'VALIDA CAMPOS VACIOS EN PAGADO A:
    Private Sub TxtPagado_TextChanged(sender As Object, e As EventArgs) Handles TxtPagado.TextChanged
        ValidaCamposVaciosEgresos()
    End Sub

    'VALIDA CAMPOS VACIOS EN CEDULA DE LA PERSONA QUE LE PAGAN
    Private Sub TxtCedPagado_TextChanged(sender As Object, e As EventArgs) Handles TxtCedPagado.TextChanged
        ValidaCamposVaciosEgresos()
    End Sub

    'VALIDA CAMPOS VACIOS EN CONCEPTO DEL PAGO
    Private Sub TxtConcePago_TextChanged(sender As Object, e As EventArgs) Handles TxtConcePago.TextChanged
        ValidaCamposVaciosEgresos()
    End Sub

    Private Sub TxtDireVentas_TextChanged(sender As Object, e As EventArgs) Handles TxtDireVentas.TextChanged
        ValidaCamposVaciosEgresos()
    End Sub

    Private Sub TxtCiudVentas_TextChanged(sender As Object, e As EventArgs) Handles TxtCiudVentas.TextChanged
        ValidaCamposVaciosEgresos()
    End Sub

    Private Sub TxtTelVentas_TextChanged(sender As Object, e As EventArgs) Handles TxtTelVentas.TextChanged
        ValidaCamposVaciosEgresos()
    End Sub

    Private Sub TxtBrutosVenta_TextChanged(sender As Object, e As EventArgs) Handles TxtBrutosVenta.TextChanged
        ValidaCamposVaciosEgresos()
    End Sub

    Private Sub TxtLeyVenta_TextChanged(sender As Object, e As EventArgs) Handles TxtLeyVenta.TextChanged
        ValidaCamposVaciosEgresos()
    End Sub

    Private Sub Txtpurosventa_TextChanged(sender As Object, e As EventArgs) Handles Txtpurosventa.TextChanged
        ValidaCamposVaciosEgresos()
    End Sub

    Private Sub TxtVrPagado_TextChanged(sender As Object, e As EventArgs) Handles TxtVrPagado.TextChanged
        ValidaCamposVaciosEgresos()
    End Sub

    Public Pago As Decimal = 0
    Public PagoBarequero As Decimal = 0
    Public GrPurReg As Decimal = 0
    Public Letnum As String
    'BOTON DE CALCULAR LAS OPERACIONES
    Private Sub BtnCalcular_Click(sender As Object, e As EventArgs) Handles BtnCalcular.Click

        'DETERMINA PRIMERO LOS GRAMOS PUROS
        If TxtBrutosVenta.Text = "" Or TxtLeyVenta.Text = "" Or TxtVrPagado.Text = "" Then
            MessageBox.Show("En este Campo No puede estar Vacío", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            '===================================================================
            '**** FORMULAS  NUEVAS
            '===================================================================
            'GRAMOS BRUTOS       = Txtgrbrutos
            'LEY                 = Txtley
            'GRAMOS PUROS        = Txtgrpuros
            'PRECIO BASE         = Txtbase
            'VALOR REGALIAS      = Txtregalias
            'VALOR % RETE        = Txtvrrf
            'VALOR RETEFUENTE    = Txtretevalor
            'VALOR REGALIAS      = Txtlblgrrg
            'VALOR TOTAL         = Txvrventa
            'VALOR BAREQUERO     = Txtbarequero
            '****INCIAMOS OPERACIONES
            '=========================== GRAMOS BRUTOS
            'Muestro el resultado en un Label para guardar
            Dim Brutosventa As Decimal = CDec(If(TxtBrutosVenta.Text.Contains("."), TxtBrutosVenta.Text.Replace(".", ","), TxtBrutosVenta.Text))
            Brutosventa = Math.Round(Brutosventa, 4)
            Me.TxtBrutosVenta.Text = Brutosventa.ToString
            '=========================== GRAMOS PUROS ( BRUTOS * LEY )
            Dim PurosVenta As Decimal = CDec(If(TxtBrutosVenta.Text.Contains("."), TxtBrutosVenta.Text.Replace(".", ","), TxtBrutosVenta.Text)) * CDec(If(TxtLeyVenta.Text.Contains("."), TxtLeyVenta.Text.Replace(".", ","), TxtLeyVenta.Text))
            PurosVenta = Math.Round(PurosVenta, 4)
            Me.Txtpurosventa.Text = PurosVenta.ToString
            '=========================== VALOR DE PRECIO BASE
            Dim Cbase As Decimal = CDec(If(TxtVrPagado.Text.Contains("."), TxtVrPagado.Text.Replace(".", ","), TxtVrPagado.Text))
            'Decimal.TryParse(TxtVrPagado.Text, Cbase)
            Cbase = Math.Round(Cbase, 4)
            Me.TxtVrPagado.Text = Cbase.ToString
            '=========================== VALOR TOTAL DEL PRECIO REGALIAS
            Dim ValorTotRegalias As Decimal = CDec(If(Txtpurosventa.Text.Contains("."), Txtpurosventa.Text.Replace(".", ","), Txtpurosventa.Text)) * CDec(If(TxtVrRegalias.Text.Contains("."), TxtVrRegalias.Text.Replace(".", ","), TxtVrRegalias.Text))
            ValorTotRegalias = Math.Round(ValorTotRegalias, 4)
            Me.TxtTotalRegalias.Text = ValorTotRegalias.ToString
            '=========================== VALOR RETEFUENTE CALCULO VALOR POR GRAMO (BASE * 2,5%)
            Dim ReteValor As Decimal = CDec(If(TxtVrPagado.Text.Contains("."), TxtVrPagado.Text.Replace(".", ","), TxtVrPagado.Text)) * CDec(If(TxtRfValor.Text.Contains("."), TxtRfValor.Text.Replace(".", ","), TxtRfValor.Text) / 100)
            ReteValor = Math.Round(ReteValor, 4)
            Me.TxtVrRf.Text = ReteValor.ToString
            '=========================== RESULTADO VALOR TOTAL (GRPUROS * BASE + VRTOTALREGALIAS)
            Dim Rtotal As Decimal = 0
            Rtotal = PurosVenta * Cbase + ValorTotRegalias
            'Me.TxtVrVenta.Text = Format(Rtotal, "###,###,##0.00")
            Me.TxtVrTotal.Text = Rtotal
            '==== OPERACION PARA SACAR EL VALOR DEL IMPUESTO TOTAL DE RETEFUENTE
            Dim ValorImpRF As Decimal = Rtotal * CDec(If(TxtRfValor.Text.Contains("."), TxtRfValor.Text.Replace(".", ","), TxtRfValor.Text) / 100)
            ValorImpRF = Math.Round(ValorImpRF, 4)
            Me.TxtTotalrf.Text = ValorImpRF.ToString
            '====================== TOTAL A PAGAR AL BAREQUERO (VALORTOTAL - VRTOTALREGALIAS - VRRETEFUENTE)
            Pago = Rtotal - ValorTotRegalias - ValorImpRF
            Pago = Math.Round(Pago, 4)
            'Me.TxtLblpago.Text = Pago.ToString
            Me.TxtVrNeto.Text = Pago.ToString
            '======================= CONVERTIMOS LOS NUMEROS A LETRAS
            'ENVIAMOS EL RESULTADO A UNA CAJA DE TEXTO EN LETRAS
            'Pointer1 = 0
            'Lbletras.Text = SpellNumber(Val(Me.TxtVrVenta.Text))
            'Letnum = Lbletras.Text

        End If

        'inhabilito los campos
        Me.TxtBrutosVenta.Enabled = False
        Me.TxtLeyVenta.Enabled = False
        Me.TxtVrPagado.Enabled = False
        Me.BtnCalcular.Enabled = False
        Me.BtnGuardaPago.Enabled = True

    End Sub


    Private Sub TxtBrutosVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBrutosVenta.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtLeyVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtLeyVenta.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txtpurosventa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtpurosventa.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtVrPagado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtVrPagado.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region




End Class