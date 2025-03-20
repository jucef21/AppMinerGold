Imports System.Data.OleDb

Public Class FrmEgresoCajaMenor

    'CARGUE DEL FORMULARIO
    Private Sub FrmEgresoAse1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'revisamos la conexion
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        'INGRESOS limpio datos
        Me.TxtControlPago.Clear()
        Me.TxtPagado.Clear()
        Me.TxtConcePago.Clear()
        Me.TxtVrPagado.Clear()
        Me.TxtCedPagado.Clear()

        'llenamos los datos con la informacion seleccionada
        Me.Txtced_cl.Text = ModuleFrm.ced_consulta
        Me.TxtCiudad.Text = ModuleFrm.VerCiudad
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomPaciente.Text = ModuleFrm.Nom_consulta

        'DATOS DEL PANEL 1
        '==============================
        'colocamos los texbox en no editable
        Me.Txtced_cl.Enabled = False
        Me.TxtPagado.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.DTPfechaactual.Enabled = False
        Me.TxtControlPago.Enabled = False
        Me.DTPfechapago.Enabled = False
        Me.TxtCedPagado.Enabled = False
        Me.TxtConcePago.Enabled = False
        Me.TxtVrPagado.Enabled = False

        'formato del datatimepicker
        Me.DTPfechaactual.Format = DateTimePickerFormat.Custom
        Me.DTPfechaactual.CustomFormat = "dd/MM/yyyy"
        Me.DTPfechaactual.Value.ToString()
        Me.DTPfechaactual.Value = Date.Now.ToString("d")

        'formato del datatimepicker
        Me.DTPfechapago.Format = DateTimePickerFormat.Custom
        Me.DTPfechapago.CustomFormat = "dd/MM/yyyy"
        Me.DTPfechapago.Value.ToString()
        Me.DTPfechapago.Value = Date.Now.ToString("d")

        'INHABILITO EL DATAGRID
        Me.DGVegresos.Enabled = False

        'ACTUALIZO EL DATAGRID CON DATOS 
        ActualizoDatagrid()

        'Actualizo el saldo
        SaldosEgresoInicial()

        'INHABILITO EL BOTON DE GUARDAR
        Me.BtnGuardaPago.Enabled = False

        'ACTIVO BOTONES
        Me.BtnNuevoPago.Enabled = True
        Me.BtnGuardaPago.Enabled = False
        Me.BtnImpriCaja.Enabled = False

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
        Dim conn As New OleDbConnection
        'sqlPresta = "SELECT * FROM CajamenorAse1 WHERE cedu_pre = '" & Txtced_cl.Text & "' ORDER BY id ASC"
        sqlPresta = "SELECT * FROM CajamenorAse1 ORDER BY id ASC"
        conn.ConnectionString = cs
        Dim adaptador As New OleDbDataAdapter(sqlPresta, conn)
        Dim dt As New DataTable("CajamenorAse1")
        adaptador.Fill(dt)
        DGVegresos.DataSource = dt
        Dim cantRegistros As Integer = DGVegresos.Rows.Count
        LblRegistros.Text = cantRegistros
    End Sub

    'ACTUALIZA DATOS DEL VALOR DEL SALDO ACTUAL, PARA EL FORMULARIO LOAD
    Private Sub SaldosEgresoInicial()
        Dim dt As New DataTable
        Dim conn As New OleDbConnection(cs)
        'Dim consulta As String = "SELECT TOP 1 * FROM CajamenorAse1 WHERE cedu_pre = '" & Txtced_cl.Text & "' ORDER BY id DESC"
        Dim consulta As String = "SELECT TOP 1 * FROM CajamenorAse1 ORDER BY id DESC"
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read() Then
            Me.TxtSaldoActual.Text = drd.Item("vrsaldo").ToString
            'MsgBox("El saldo es: " + Me.TxtSaldoActual.Text)
            Dim MyObject As Double
            MyObject = TxtSaldoActual.Text
            TxtSaldoActual.Text = CStr(MyObject.ToString("#,###,##0"))
        Else
            MsgBox("Saldo Inicial en Cero, Ingrese un valor a la Caja", MsgBoxStyle.Information, "AppMinerGold")
            Me.TxtSaldoActual.Text = 0
            'Dim SaldoTotal As Double
            'Me.TxtSaldoActual.Text = Format(SaldoTotal, "$ #,###,##0")
            Dim MyObject As Double
            MyObject = TxtSaldoActual.Text
            TxtSaldoActual.Text = CStr(MyObject.ToString("###,###,###,##0"))
            'colocamos los texbox en no editable
            Me.Txtced_cl.Enabled = False
            Me.TxtPagado.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.DTPfechaactual.Enabled = False
            Me.TxtControlPago.Enabled = False
            Me.DTPfechapago.Enabled = False
            Me.TxtCedPagado.Enabled = False
            Me.TxtConcePago.Enabled = False
            Me.TxtVrPagado.Enabled = False
            'ACTIVO BOTONES
            Me.BtnNuevoPago.Enabled = False
            Me.BtnGuardaPago.Enabled = False
            Me.BtnImpriCaja.Enabled = False

        End If
        drd.Close()
        conn.Close()

    End Sub

    'VALIDA SALDO ACTUAL, QUE EL EGRESO NO SEA MAYOR
    Private Sub RevisaEgreso()
        Dim x, y As Integer
        x = CInt(Me.TxtVrPagado.Text)
        y = CInt(Me.TxtSaldoActual.Text)
        If (x > y) Then
            MsgBox("El valor pagado es mayor al saldo actual, Ingrese su saldo en caja para continuar", MsgBoxStyle.Information, "AppMinerGold")
            Dim MyObject As Double
            MyObject = TxtSaldoActual.Text
            TxtSaldoActual.Text = CStr(MyObject.ToString("###,###,###,##0"))

            Me.GroupBox1.Select()
            Me.GroupBox1.Focus()
            Me.TxtVrPagado.Focus()
            Me.BtnNuevoPago.Focus()
        Else
            'Procedimiento
            GuardaEgresos()
        End If

    End Sub

    'ACTUALIZA LOS SALDOS CAJAS DE TEXTO, CONN CERRADA PARA EL RESTO DE LA APP
    Private Sub ActualizaSaldosEgresos()
        Me.TxtSaldoActual.Text = 0
        Dim dt As New DataTable
        'Dim consulta As String = "SELECT TOP 1 * FROM CajamenorAse1 WHERE cedu_pre = '" & Txtced_cl.Text & "' ORDER BY id DESC"
        Dim consulta As String = "SELECT TOP 1 * FROM CajamenorAse1 ORDER BY id DESC"
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        'conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            Me.TxtSaldoActual.Text = drd.Item("vrsaldo").ToString
            Me.TxtSaldoActual.Text = Format(CType(Me.TxtSaldoActual.Text, Double), "###,###,###,###")
        Else
            MsgBox("No se encontro los datos solicitados del SALDO", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
    End Sub

    'ACTUALIZA LOS SALDOS VALOR, CONN ABIERTA PARA EL RESTO DE LA APP
    Private Sub SaldosValor()
        Me.TxtSaldoActual.Text = 0
        Dim dt As New DataTable
        Dim consulta As String = "SELECT TOP 1 * FROM CajamenorAse1 WHERE cedu_pre = '" & Txtced_cl.Text & "' ORDER BY id DESC"
        'Dim consulta As String = "SELECT TOP FROM CajamenorAse1 ORDER BY id DESC"
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

#End Region

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE NUEVO PRESTAMO
    Private Sub BtnNuevoPago_Click(sender As Object, e As EventArgs) Handles BtnNuevoPago.Click

        SaldosEgresoInicial()

        'colocamos los texbox en no editable
        Me.Txtced_cl.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.DTPfechaactual.Enabled = False
        Me.TxtControlPago.Enabled = False

        Me.TxtConcePago.Enabled = True
        Me.TxtVrPagado.Enabled = True
        Me.DTPfechapago.Enabled = True
        Me.TxtCedPagado.Enabled = True
        Me.TxtPagado.Enabled = True

        'limpio datos
        Me.TxtControlPago.Clear()
        Me.TxtPagado.Clear()
        Me.TxtConcePago.Clear()
        Me.TxtVrPagado.Clear()
        Me.TxtCedPagado.Clear()

        'ubico el cursor
        Me.TxtPagado.Select()
        Me.TxtPagado.Focus()

        'ejecutamos contador
        ContadorPagos()

        'HABILITO LOS BOTONES
        Me.BtnNuevoPago.Visible = False
        Me.BtnNuevoPago.Enabled = False

        Me.BtnGuardaPago.Visible = True
        Me.BtnGuardaPago.Enabled = True

        Me.BtnImpriCaja.Visible = True
        Me.BtnImpriCaja.Enabled = False

        'INHABILITO EL DATAGRID
        Me.DGVegresos.Enabled = False

    End Sub

    'BOTON DE GUARDAR INGRESOS
    Private Sub BtnGuardapago_Click(sender As Object, e As EventArgs) Handles BtnGuardaPago.Click
        Try
            If TxtPagado.TextLength > 0 And TxtCedPagado.TextLength > 0 And TxtConcePago.TextLength > 0 And TxtVrPagado.TextLength > 0 Then
                'llamo al procedimiento 
                RevisaEgreso()
            Else
                'MENSAJE ERROR
                MessageBox.Show("Los Campos NO deben estar Vacíos", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'colocamos los texbox en no editable
                Me.TxtControlPago.Enabled = False
                Me.DTPfechaactual.Enabled = False
                Me.Txtced_cl.Enabled = False
                Me.TxtCiudad.Enabled = False

                Me.TxtPagado.Enabled = False
                Me.TxtCedPagado.Enabled = False
                Me.TxtConcePago.Enabled = False
                Me.DTPfechapago.Enabled = False
                Me.TxtVrPagado.Enabled = False

                'LIMPIO DATOS
                Me.TxtControlPago.Clear()
                Me.Txtced_cl.Clear()
                Me.TxtCiudad.Clear()

                Me.TxtPagado.Clear()
                Me.TxtCedPagado.Clear()
                Me.TxtConcePago.Clear()
                Me.TxtVrPagado.Clear()

                'formato del datatimepicker
                Me.DTPfechaactual.Format = DateTimePickerFormat.Custom
                Me.DTPfechaactual.CustomFormat = "dd/MM/yyyy"
                Me.DTPfechaactual.Value.ToString()
                Me.DTPfechaactual.Value = Date.Now.ToString("d")

                'formato del datatimepicker
                Me.DTPfechapago.Format = DateTimePickerFormat.Custom
                Me.DTPfechapago.CustomFormat = "dd/MM/yyyy"
                Me.DTPfechapago.Value.ToString()
                Me.DTPfechapago.Value = Date.Now.ToString("d")

                'INHABILITO EL DATAGRID
                Me.DGVegresos.Enabled = False

                'ACTIVO BOTONES
                Me.BtnNuevoPago.Visible = False
                Me.BtnNuevoPago.Enabled = False
                Me.BtnGuardaPago.Visible = False
                Me.BtnGuardaPago.Enabled = False
                Me.BtnImpriCaja.Enabled = False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            'INHABILITO EL BOTON DE GUARDAR
            Me.BtnGuardaPago.Enabled = False

            'ACTIVO BOTONES
            Me.BtnNuevoPago.Visible = True
            Me.BtnNuevoPago.Enabled = True
            Me.BtnGuardaPago.Visible = False
            Me.BtnGuardaPago.Enabled = False
            Me.BtnImpriCaja.Enabled = False

            'UBICO EL CURSOR
            Me.BtnNuevoPago.Select()
            Me.BtnNuevoPago.Focus()
        End Try


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
        'variable de fecha de pago del abono
        Dim FechaPago As String
        FechaPago = CStr(DTPfechapago.Value.Date)

        Try

            '******************************************************************
            'llamamos la operacion
            Dim cred, vrabono, total As Double
            '=======
            cred = 0
            vrabono = 0
            '=======
            cred = CDbl(Me.TxtSaldoActual.Text)
            vrabono = CDbl(Me.TxtVrPagado.Text)
            total = 0
            total = CDbl(Me.TxtSaldoActual.Text)
            total = total - vrabono
            Me.TxtSaldoActual.Text = total.ToString("###,###,###,##0")
            Me.TxtSaldoActual.Text = total
            '******************************************************************

            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            sql = "INSERT INTO CajamenorAse1 (cedu_pre, nom_pre, fechaactual_pre, nomciud, nompagado, cedupagado, " &
                                         "vrpagado, fechapago, numpago, fecha_creado, fecha_modifica, vrsaldo, " &
                                         "conce_pago) VALUES ('" & Txtced_cl.Text & "', '" & TxtNomPaciente.Text & "', " &
                                         "'" & FechaACT & "', '" & TxtCiudad.Text & "', '" & TxtPagado.Text & "', " &
                                         "'" & TxtCedPagado.Text & "', '" & TxtVrPagado.Text & "', '" & FechaPago & "', " &
                                         "'" & TxtControlPago.Text & "', '" & fechaC & "', '" & fechaM & "', " &
                                         "'" & total & "', '" & TxtConcePago.Text & "')"

            cmd.CommandText = sql

            'para ejecutar la consulta
            cmd.ExecuteNonQuery()

            'muestro el  campo en formato numerico
            Me.TxtSaldoActual.Text = Format(CType(Me.TxtSaldoActual.Text, Double), "###,###,###,##0")

            'muestro el mensaje de guardar
            MsgBox("EGRESO, Guardado con Éxito", MsgBoxStyle.Information, "AppMinerGold")

            'actualizo el datagrid
            ActualizoDatagrid()

            'cierro la conexcion
            conn.Close()

            'limpio los campos
            Me.TxtControlPago.Clear()
            Me.TxtPagado.Clear()
            Me.TxtConcePago.Clear()
            Me.TxtVrPagado.Clear()
            Me.TxtSaldoActual.Clear()
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
            Me.DTPfechapago.Enabled = False

            'DESHABILITO LOS BOTONES
            'HABILITO LOS BOTONES
            Me.BtnNuevoPago.Visible = True
            Me.BtnNuevoPago.Enabled = False

            Me.BtnGuardaPago.Visible = False
            Me.BtnGuardaPago.Enabled = False

            Me.BtnImpriCaja.Visible = True
            Me.BtnImpriCaja.Enabled = True

            'lleno el SALDO ACTUAL
            SaldosValor()

            'INHABIITO EL DATAGRID
            Me.DGVegresos.Enabled = False

            'ubico el cursor
            Me.BtnNuevoPago.Enabled = True
            Me.BtnImpriCaja.Focus()

        Catch ex As Exception

            'muestro el mensaje
            MsgBox("Error al Guardar Egreso.! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")

            'limpio todo
            Me.TxtControlPago.Clear()
            Me.TxtPagado.Clear()
            Me.TxtConcePago.Clear()
            Me.TxtVrPagado.Clear()
            Me.TxtSaldoActual.Clear()
            Me.TxtCedPagado.Clear()

            'ubico el cursor
            Me.TxtConcePago.Focus()

            'cierro conexcion
            conn.Close()
        End Try

    End Sub

    'BOTON DE IMPRIMIR
    Private Sub BtnImpriCaja_Click(sender As Object, e As EventArgs) Handles BtnImpriCaja.Click
        FrmRptImpEgreso.ShowDialog()
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "EVENTOS KEYPRESS DEL  FORMULARIO"

    'PERMITE TECLA ENTER
    Private Sub Txtpagado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPagado.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCedpagado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCedPagado.KeyPress
        SoloNumeros(e)
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

    Private Sub TxtVrPagado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtVrPagado.KeyPress
        SoloNumeros(e)
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DTPfechapago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPfechapago.KeyPress
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

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVegresos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVegresos.CellFormatting

        'Scroll to the last row. 
        Me.DGVegresos.FirstDisplayedScrollingRowIndex = Me.DGVegresos.RowCount - 1
        Me.DGVegresos.Rows(Me.DGVegresos.Rows.Count - 1).Selected = True

        'activo el datagrid
        Me.DGVegresos.Enabled = True

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVegresos.RowsDefaultCellStyle
            Me.DGVegresos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVegresos.Columns(0).Width = 40
            Me.DGVegresos.Columns(0).HeaderText = "Id"

            'Me.DGVegresos.Columns(1).Width = 80
            'Me.DGVegresos.Columns(1).HeaderText = "Cédula del Cliente"
            'Me.DGVegresos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Me.DGVegresos.Columns(2).Width = 150
            'Me.DGVegresos.Columns(2).HeaderText = "Nombre del Cliente"
            'Me.DGVegresos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVegresos.Columns(3).Width = 90
            Me.DGVegresos.Columns(3).HeaderText = "Fecha del Ingreso"
            Me.DGVegresos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVegresos.Columns(4).Width = 70
            Me.DGVegresos.Columns(4).HeaderText = "No. Documento Ingreso"
            Me.DGVegresos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVegresos.Columns(8).Width = 90
            Me.DGVegresos.Columns(8).HeaderText = "Valor Ingreso"
            Me.DGVegresos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVegresos.Columns(8).DefaultCellStyle.Format = "c"

            Me.DGVegresos.Columns(10).Width = 90
            Me.DGVegresos.Columns(10).HeaderText = "Fecha del Egreso"
            Me.DGVegresos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVegresos.Columns(11).Width = 80
            Me.DGVegresos.Columns(11).HeaderText = "No. Documento Egreso"
            Me.DGVegresos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVegresos.Columns(9).Width = 100
            Me.DGVegresos.Columns(9).HeaderText = "Valor del Egreso"
            Me.DGVegresos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVegresos.Columns(9).DefaultCellStyle.Format = "c"

            Me.DGVegresos.Columns(14).Width = 100
            Me.DGVegresos.Columns(14).HeaderText = "Valor Saldo"
            Me.DGVegresos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVegresos.Columns(14).DefaultCellStyle.Format = "c"


            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVegresos.Columns("cedu_pre").Visible = False
            Me.DGVegresos.Columns("nom_pre").Visible = False

            Me.DGVegresos.Columns("conce_pre").Visible = False
            Me.DGVegresos.Columns("nomciud").Visible = False
            Me.DGVegresos.Columns("nompagado").Visible = False
            Me.DGVegresos.Columns("conce_pago").Visible = False
            Me.DGVegresos.Columns("cedupagado").Visible = False

            Me.DGVegresos.Columns("fecha_creado").Visible = False
            Me.DGVegresos.Columns("fecha_modifica").Visible = False

        End With

    End Sub

#End Region

#Region "VALIDACIONES CAMPOS NUMERICOS"

    'FORMATO DEL CAMPO DE TEXTO EN NUMERICO
    Private Sub TxtVrPagado_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles TxtVrPagado.Leave
        Me.TxtVrPagado.Text = Format(Val(TxtVrPagado.Text), "#,###,###,###")
    End Sub

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
        Dim query As String = "SELECT MAX(numpago)FROM CajamenorAse1"
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




End Class