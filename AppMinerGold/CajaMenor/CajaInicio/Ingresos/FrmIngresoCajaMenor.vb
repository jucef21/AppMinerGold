Imports System.Data.OleDb

Public Class FrmIngresoCajaMenor

    'CARGUE DEL FORMULARIO
    Private Sub FrmIngresoAse1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'INGRESOS limpio datos
        Me.TxtNumDoc.Clear()
        Me.TxtPagado.Clear()
        Me.TxtConcepto.Clear()
        Me.TxtValorCaja.Clear()

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
        Me.TxtNumDoc.Enabled = False

        Me.TxtConcepto.Enabled = False
        Me.TxtValorCaja.Enabled = False

        'formato del datatimepicker
        Me.DTPfechaactual.Format = DateTimePickerFormat.Custom
        Me.DTPfechaactual.CustomFormat = "dd/MM/yyyy"
        Me.DTPfechaactual.Value.ToString()
        Me.DTPfechaactual.Value = Date.Now.ToString("d")

        'llamo el  preocedimiento de CONCATENAR 
        UnirNombres()

        'muestro el resultado y los concateno
        Me.TxtPagado.Text = Me.TxtName.Text & " " & Me.TxtSurname.Text

        'INHABILITO EL DATAGRID
        Me.DGVingresos.Enabled = False

        'ACTUALIZO EL DATAGRID
        ActualizoDatagrid()

        'ACTUALIZO EL SALDO EN CAJA
        SaldosIngresoInicial()

        'INHABILITO EL BOTON DE GUARDAR
        Me.BtnGuardaIngreso.Enabled = False
        Me.BtnImpriCaja.Enabled = False

    End Sub

#Region "PROCEDIMIENTO DEL  FORMULARIO"

    'PROCEDIMIENTO PARA UNIR NOMBRE Y APELLIDO DEL CLIENTE
    Private Sub UnirNombres()
        Dim dt As New DataTable
        'conn.ConnectionString = cs
        Dim consulta As String = "SELECT * FROM Usuarios WHERE cedula_user = '" & Txtced_cl.Text & "' "
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            Me.TxtName.Text = drd.Item("nom_user").ToString
            Me.TxtSurname.Text = drd.Item("apell_user").ToString
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
        'sqlPresta = "SELECT * FROM CajamenorAse1 WHERE cedu_pre = '" & Txtced_cl.Text & "' ORDER BY id ASC"
        sqlPresta = "SELECT * FROM CajamenorAse1 ORDER BY id ASC"
        conn.ConnectionString = cs
        Dim adaptador As New OleDb.OleDbDataAdapter(sqlPresta, conn)
        Dim dt As New DataTable("CajamenorAse1")
        adaptador.Fill(dt)
        DGVingresos.DataSource = dt
        Dim cantRegistros As Integer = DGVingresos.Rows.Count
        LblRegistros.Text = cantRegistros
    End Sub

    'ACTUALIZA LOS SALDOS VALOR, DESPUES DE CADA REGISTRO
    Private Sub SaldosValor()
        Me.TxtSaldoActual.Text = 0
        'Dim Numerototal As Double
        Dim dt As New DataTable
        'Dim consulta As String = "SELECT TOP 1 * FROM CajamenorAse1 WHERE cedu_pre = '" & Txtced_cl.Text & "' ORDER BY id DESC"
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

    'ACTUALIZA DATOS DEL VALOR DEL SALDO ACTUAL, PARA EL FORMULARIO LOAD
    Private Sub SaldosIngresoInicial()
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
            MsgBox("Saldo Inicial en Cero", MsgBoxStyle.Information, "AppMinerGold")
            Me.TxtSaldoActual.Text = 0
            Dim SaldoTotal As Double
            Me.TxtSaldoActual.Text = Format(SaldoTotal, "$ #,###,##0")

            'Dim MyObject As Double
            'MyObject = TxtSaldoActual.Text
            'TxtSaldoActual.Text = CStr(MyObject.ToString("#,###,##0"))
        End If
        drd.Close()
        conn.Close()

    End Sub

#End Region

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE NUEVO INGRESO
    Private Sub BtnNuevoCaja_Click(sender As Object, e As EventArgs) Handles BtnNuevoCaja.Click

        'colocamos los texbox en no editable
        Me.Txtced_cl.Enabled = False
        Me.TxtPagado.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.DTPfechaactual.Enabled = False
        Me.TxtNumDoc.Enabled = False

        Me.TxtConcepto.Enabled = True
        Me.TxtValorCaja.Enabled = True

        'limpio datos
        Me.TxtNumDoc.Clear()
        Me.TxtPagado.Clear()
        Me.TxtConcepto.Clear()
        Me.TxtValorCaja.Clear()

        'muestro el resultado y los concateno
        Me.TxtPagado.Text = Me.TxtName.Text & " " & Me.TxtSurname.Text

        'ubico el cursor
        Me.GroupBox1.Select()
        Me.TxtConcepto.Select()
        Me.TxtConcepto.Focus()

        'ejecutamos contador
        ContadorIngreso()

        'HABILITO LOS BOTONES
        Me.BtnNuevoCaja.Visible = False
        Me.BtnNuevoCaja.Enabled = False

        Me.BtnGuardaIngreso.Visible = True
        Me.BtnGuardaIngreso.Enabled = True

        Me.BtnImpriCaja.Visible = True
        Me.BtnImpriCaja.Enabled = False

        'INHABILITO EL DATAGRID
        Me.DGVingresos.Enabled = False

        Me.TxtNumIgreso.Text = TxtNumDoc.Text

    End Sub

    'BOTON DE GUARDAR INGRESOS
    Private Sub BtnGuardaIngreso_Click(sender As Object, e As EventArgs) Handles BtnGuardaIngreso.Click
        Try
            If Me.TxtConcepto.TextLength > 0 And Me.TxtValorCaja.TextLength > 0 Then
                'llamo al procedimiento 
                GuardaIngresos()

                'limpio los campos
                Me.TxtNumDoc.Clear()
                Me.TxtPagado.Clear()
                Me.TxtConcepto.Clear()
                Me.TxtValorCaja.Clear()
                Me.TxtSaldoActual.Clear()

                'inhabilito los campos
                Me.Txtced_cl.Enabled = False
                Me.TxtPagado.Enabled = False
                Me.TxtCiudad.Enabled = False
                Me.DTPfechaactual.Enabled = False
                Me.TxtNumDoc.Enabled = False

                Me.TxtConcepto.Enabled = False
                Me.TxtValorCaja.Enabled = False

                'DESHABILITO LOS BOTONES
                'HABILITO LOS BOTONES
                Me.BtnNuevoCaja.Visible = True
                Me.BtnNuevoCaja.Enabled = False

                Me.BtnGuardaIngreso.Visible = False
                Me.BtnGuardaIngreso.Enabled = False

                Me.BtnImpriCaja.Visible = True
                Me.BtnImpriCaja.Enabled = True

                'lleno el SALDO ACTUAL
                SaldosValor()

                'INHABIITO EL DATAGRID
                Me.DGVingresos.Enabled = False

                'ubico el cursor
                Me.BtnImpriCaja.Select()
                Me.BtnImpriCaja.Focus()
            Else
                MessageBox.Show("Los Campos no deben estar vacíos", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.GroupBox1.Select()
                Me.TxtConcepto.Select()
                Me.TxtConcepto.Focus()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Datos en Error", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'limpio los campos
            Me.TxtNumDoc.Clear()
            Me.TxtPagado.Clear()
            Me.TxtConcepto.Clear()
            Me.TxtValorCaja.Clear()
            Me.TxtSaldoActual.Clear()

            Me.BtnNuevoCaja.Visible = True
            Me.BtnNuevoCaja.Enabled = False

            Me.BtnGuardaIngreso.Visible = False
            Me.BtnGuardaIngreso.Enabled = True

            Me.BtnImpriCaja.Visible = False
            Me.BtnImpriCaja.Enabled = False

        End Try


    End Sub

    'PROCEDIMIENTO PARA GUARDAR INGRESOS
    Private Sub GuardaIngresos()

        'revisamos la conexion
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        'INHABILITO EL DATAGRID
        Me.DGVingresos.Enabled = False

        'variable de fecha creado
        Dim fechaC As Date = CDate(Format(Date.Now.Date))
        'variable de fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))
        'variable de fecha actual del documento
        Dim FechaACT As Date = CDate(Format(Date.Now.Date))

        Try
            '******************************************************************
            'llamamos la operacion
            Dim cred, vrabono, total As Double
            '============
            cred = 0
            vrabono = 0
            '============
            cred = CDbl(Me.TxtValorCaja.Text)
            vrabono = CDbl(Me.TxtValorCaja.Text)
            total = 0
            total = CDbl(Me.TxtSaldoActual.Text)
            total = total + vrabono
            Me.TxtSaldoActual.Text = total.ToString("###,###,###,###")
            Me.TxtSaldoActual.Text = total
            '******************************************************************
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn
            sql = "INSERT INTO CajamenorAse1 (cedu_pre, nom_pre, fechaactual_pre, numpresta, nomciud, nompagado, conce_pre, vrprestamo, " &
                                         "fecha_creado, fecha_modifica, vrsaldo) VALUES ('" & Txtced_cl.Text & "', '" & TxtNomPaciente.Text & "', '" & FechaACT & "', " &
                                         "'" & TxtNumDoc.Text & "', '" & TxtCiudad.Text & "','" & TxtPagado.Text & "', '" & TxtConcepto.Text & "', '" & TxtValorCaja.Text & "', '" & fechaC & "', '" & fechaM & "', '" & total & "')"

            cmd.CommandText = sql
            'para ejecutar la consulta
            cmd.ExecuteNonQuery()
            'muestro el  campo en formato numerico
            Me.TxtSaldoActual.Text = Format(CType(Me.TxtSaldoActual.Text, Double), "###,###,###,###")
            'muestro el mensaje de guardar
            MsgBox("INGRESO, Guardado con Éxito! ", MsgBoxStyle.Information, "AppMinerGold")

            'actualizo el datagrid
            ActualizoDatagrid()

            'cierro la conexcion
            conn.Close()

        Catch ex As Exception
            'muestro el mensaje
            MsgBox("Error al Guardar Ingreso.! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
            'limpio todo
            Me.TxtNumDoc.Clear()
            Me.TxtPagado.Clear()
            Me.TxtConcepto.Clear()
            Me.TxtValorCaja.Clear()
            Me.TxtSaldoActual.Clear()
            'ubico el cursor
            Me.TxtConcepto.Focus()
            'cierro conexcion
            conn.Close()
        End Try

    End Sub

    'BOTON DE IMPRIMIR
    Private Sub BtnImpriCaja_Click(sender As Object, e As EventArgs) Handles BtnImpriCaja.Click
        FrmRptImpIngreso.TxtNumIngreso.Text = TxtNumIgreso.Text
        FrmRptImpIngreso.ShowDialog()
    End Sub

#End Region

#Region "DATAGRIDVIEW INGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVingresos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVingresos.CellFormatting

        'activo el datagrid
        Me.DGVingresos.Enabled = True

        'UBICO LA ULTIMA FILA, Scroll to the last row
        DGVingresos.FirstDisplayedScrollingRowIndex = DGVingresos.Rows.Count - 1
        DGVingresos.Rows(DGVingresos.Rows.Count - 1).Selected = True

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVingresos.RowsDefaultCellStyle
            Me.DGVingresos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVingresos.Columns(0).Width = 40
            Me.DGVingresos.Columns(0).HeaderText = "Id"
            Me.DGVingresos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'Me.DGVingresos.Columns(1).Width = 70
            'Me.DGVingresos.Columns(1).HeaderText = "Cédula del Cliente"
            'Me.DGVingresos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Me.DGVingresos.Columns(2).Width = 150
            'Me.DGVingresos.Columns(2).HeaderText = "Nombre del Cliente"
            'Me.DGVingresos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVingresos.Columns(3).Width = 90
            Me.DGVingresos.Columns(3).HeaderText = "Fecha del Ingreso"
            Me.DGVingresos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVingresos.Columns(4).Width = 70
            Me.DGVingresos.Columns(4).HeaderText = "No. Documento Ingreso"
            Me.DGVingresos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVingresos.Columns(8).Width = 90
            Me.DGVingresos.Columns(8).HeaderText = "Valor Ingreso"
            Me.DGVingresos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVingresos.Columns(8).DefaultCellStyle.Format = "c"

            Me.DGVingresos.Columns(10).Width = 90
            Me.DGVingresos.Columns(10).HeaderText = "Fecha del Egreso"
            Me.DGVingresos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVingresos.Columns(11).Width = 80
            Me.DGVingresos.Columns(11).HeaderText = "No. Documento Egreso"
            Me.DGVingresos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVingresos.Columns(9).Width = 100
            Me.DGVingresos.Columns(9).HeaderText = "Valor del Egreso"
            Me.DGVingresos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVingresos.Columns(9).DefaultCellStyle.Format = "c"

            Me.DGVingresos.Columns(14).Width = 100
            Me.DGVingresos.Columns(14).HeaderText = "Valor Saldo"
            Me.DGVingresos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVingresos.Columns(14).DefaultCellStyle.Format = "c"


            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVingresos.Columns("cedu_pre").Visible = False
            Me.DGVingresos.Columns("nom_pre").Visible = False

            Me.DGVingresos.Columns("conce_pre").Visible = False
            Me.DGVingresos.Columns("nomciud").Visible = False
            Me.DGVingresos.Columns("nompagado").Visible = False
            Me.DGVingresos.Columns("conce_pago").Visible = False
            Me.DGVingresos.Columns("cedupagado").Visible = False
            'Me.DGVingresos.Columns("fechapago").Visible = False
            'Me.DGVingresos.Columns("vrpagado").Visible = False
            'Me.DGVingresos.Columns("numpago").Visible = False

            Me.DGVingresos.Columns("fecha_creado").Visible = False
            Me.DGVingresos.Columns("fecha_modifica").Visible = False


        End With


    End Sub

#End Region

#Region "CONTADORES PARA AMBOS CONCEPTOS"

    'CONTADOR
    Function ContadorIngreso()
        Dim conT As String
        conT = Txtced_cl.Text
        UltimoIdIngreso()
        Me.TxtNumDoc.Text = UltimoIdIngreso()
        Return conT
    End Function

    'para encontrar el valor máximo de una columna y ultimo registro
    Public Function UltimoIdIngreso() As String
        conn.Close()
        Dim resultado As String
        resultado = 0
        Dim query As String = "SELECT MAX(numpresta)FROM CajamenorAse1"
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

#Region "EVENTOS KEYPRESS DEL  FORMULARIO"

    'PERMITE TECLA ENTER
    Private Sub TxtConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtConcepto.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    'PERMITE TECLA ENTER
    Private Sub TxtValorCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValorCaja.KeyPress

        'VALIDA SOLO NUMEROS
        SoloNumeros(e)

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    'FORMATO DEL CAMPO DE TEXTO EN NUMERICO
    Private Sub TxtValorCaja_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles TxtValorCaja.Leave
        Me.TxtValorCaja.Text = Format(Val(TxtValorCaja.Text), "#,###,###,###")
    End Sub

    'BOTON DE CERRA FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region



End Class