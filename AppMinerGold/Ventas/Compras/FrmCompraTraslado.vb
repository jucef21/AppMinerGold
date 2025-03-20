Imports System.Data.OleDb

Public Class FrmCompraTraslado

    'CARGUE DEL FORMULARIO
    Private Sub FrmCompraTraslado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        '==========================================================================================
        'llenamos los datos con la informacion seleccionada
        Me.Txtced_cl.Text = ModuleFrm.ced_consulta

        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomPaciente.Text = ModuleFrm.Nom_consulta

        'llamo el  preocedimiento de CONCATENAR 
        UnirNombres()

        'muestro el resultado y los concateno
        Me.TxtPagado.Text = Me.TxtName.Text & " " & Me.TxtSurname.Text

        'INHABILITO EL DATAGRID
        Me.DGVingresos.Enabled = False

        'ACTUALIZO EL DATAGRID COMPMRAVENTAS
        ActualizoDatagridCV()

        'DATOS DEL PANEL 1==============================

        ''INGRESOS limpio datos
        Me.TxtNumDoc.Clear()
        'Me.TxtPagado.Clear()

        'colocamos los texbox en no editable
        Me.Txtced_cl.Enabled = False
        Me.TxtPagado.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.DTPfechaactual.Enabled = False
        Me.TxtNumDoc.Enabled = False

        'formato del datatimepicker
        Me.DTPfechaactual.Format = DateTimePickerFormat.Custom
        Me.DTPfechaactual.CustomFormat = "dd/MM/yyyy"
        Me.DTPfechaactual.Value.ToString()
        Me.DTPfechaactual.Value = Date.Now.ToString("d")

        'INHABILITO EL BOTON DE GUARDAR
        Me.BtnGuardaIngreso.Enabled = False

        'PANEL 2 =====================================================

        Me.TxtBrutosSaldo.Clear()
        Me.TxtBrutosSaldo.Enabled = False

        Me.Txtleysaldo.Clear()
        Me.Txtleysaldo.Enabled = False

        Me.Txtpurossaldo.Clear()
        Me.Txtpurossaldo.Enabled = False

        'LIMPIO LOS CAMPOS DE TEXTO
        Me.TxtNumTraslado.Clear()
        Me.TxtInggrbrutos.Clear()
        Me.TxtIngley.Clear()
        Me.TxtInggrpuros.Clear()

        'INHABILITO LOS CAMPOS DE TEXTO
        Me.TxtNumTraslado.Enabled = False
        Me.BtnConsulta.Enabled = False
        Me.TxtInggrbrutos.Enabled = False
        Me.TxtIngley.Enabled = False
        Me.TxtInggrpuros.Enabled = False

        'PANEL 3 =====================================================
        Me.TxtNuevosBrutos.Clear()
        Me.Txtnuevaley.Clear()
        Me.Txtnuevagrpuros.Clear()
        Me.Txtajuste.Clear()
        Me.TxtConcepto.Clear()

        Me.TxtNuevosBrutos.Enabled = False
        Me.Txtnuevaley.Enabled = False
        Me.Txtnuevagrpuros.Enabled = False
        Me.Txtajuste.Enabled = False
        Me.TxtConcepto.Enabled = False

        'inhabilito botones
        Me.BtnConsulta.Enabled = False
        Me.BtnAjuste.Enabled = False
        Me.BtnGuardaIngreso.Visible = False
        Me.BtnGuardaIngreso.Enabled = False
        Me.BtnImpriCaja.Enabled = True

        Me.BtnNuevoCaja.Enabled = True
        Me.BtnRegreCaja.Enabled = True

        'UBICO EL CURSOR
        Me.BtnNuevoCaja.Select()
        Me.BtnNuevoCaja.Focus()

        'limpio copia de numero para imp
        Me.TxtNumImp.Clear()

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
            MessageBox.Show("No se encontro NOMBRES", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        drd.Close()
        conn.Close()
    End Sub

    'VALIDA CAMPOS VACIOS
    Private Sub ValidaCamposVacios()
        If Me.TxtConcepto.Text = "" And Me.TxtNuevosBrutos.Text = "" And Me.Txtnuevaley.Text = "" And Me.Txtnuevagrpuros.Text = "" Then
            BtnGuardaIngreso.Visible = False
            BtnGuardaIngreso.Enabled = False
        Else
            BtnGuardaIngreso.Visible = True
            BtnGuardaIngreso.Enabled = True
        End If
    End Sub

    'VALIDA SOLO NUMEROS DECIMALES
    Public Sub NumerosyDecimal(ByVal CajaTexto As Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not CajaTexto.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'ACTUALIZA DATAGRID EN TIEMPO DE EJECUCCION
    Private Sub ActualizoDatagridCV()
        Dim sqlPresta As String
        Dim conn As New OleDb.OleDbConnection
        sqlPresta = "SELECT * FROM compraventa WHERE cedunit = '" & Txtced_cl.Text & "' ORDER BY numcompra ASC "
        conn.ConnectionString = cs
        Dim adaptador As New OleDb.OleDbDataAdapter(sqlPresta, conn)
        Dim dt As New DataTable("compraventa")
        adaptador.Fill(dt)
        DGVingresos.DataSource = dt
        Dim cantRegistros As Integer = DGVingresos.Rows.Count
        LblRegistros.Text = cantRegistros
    End Sub

    'ACTUALIZA DATOS DEL VALOR DEL SALDO ACTUAL DE GRAMOS PUROS DE FUNDICION, PARA EL FORMULARIO LOAD
    Private Sub SaldosIngresoInicial()
        Dim dt As New DataTable
        Dim conn As New OleDbConnection(cs)
        Dim numdoc As String
        numdoc = "0"
        Dim consulta As String = "SELECT SUM(brutosfundi) as SumCol1, SUM(purosfundi) as SumCol2 FROM Fundicion WHERE fundiventa = '" & numdoc & "' "
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read() Then
            'Me.TxtBrutosSaldo.Text = drd.Item("vrsaldosbrutos").ToString
            'Me.Txtleysaldo.Text = drd.Item("vrsaldosley").ToString
            'Me.Txtpurossaldo.Text = drd.Item("vrsaldospuros").ToString

            'Me.TxtBrutosSaldo.Text = drd.Item("brutosfundi").ToString
            'Me.Txtleysaldo.Text = drd.Item("leyfundi").ToString
            'Me.Txtpurossaldo.Text = drd.Item("purosfundi").ToString

            'Dim drd As OleDbDataReader = cmd.ExecuteReader()
            If drd.HasRows Then
                Me.TxtBrutosSaldo.Text = drd("SumCol1").ToString
                Me.Txtpurossaldo.Text = drd("SumCol2").ToString
            End If

            Dim SaldoBruto, SaldoLey, SaldoPuro As Double
            SaldoPuro = Me.Txtpurossaldo.Text
            SaldoBruto = Me.TxtBrutosSaldo.Text
            SaldoLey = SaldoPuro / SaldoBruto
            'SaldoLey = Me.Txtleysaldo.Text

            Me.TxtBrutosSaldo.Text = Math.Round(SaldoBruto, 4).ToString
            Me.Txtleysaldo.Text = Math.Round(SaldoLey, 4).ToString
            Me.Txtpurossaldo.Text = Math.Round(SaldoPuro, 4).ToString

        Else
            MessageBox.Show("Saldo Inicial en Cero", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.TxtBrutosSaldo.Text = 0
            Dim SaldoTotal As Double
            Me.TxtBrutosSaldo.Text = Format(SaldoTotal, "###,##0")

            Me.Txtleysaldo.Text = 0
            Dim SaldoTotalBruto As Double
            Me.Txtleysaldo.Text = Format(SaldoTotalBruto, "###,##0")

            Me.Txtpurossaldo.Text = 0
            Dim SaldoTotal1 As Double
            Me.Txtpurossaldo.Text = Format(SaldoTotal1, "###,##0")

        End If
        drd.Close()
        conn.Close()

    End Sub

    'ACTUALIZA SALDO ACTUAL COMPRAS DISPONIBLES
    Private Sub SalInicial()
        Dim dt As New DataTable
        Dim conn As New OleDbConnection(cs)
        Dim consulta As String = "SELECT TOP 1 * FROM compraventa ORDER BY numcompra DESC "
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read() Then
            Me.TxtBrutosSaldo.Text = drd.Item("saldobrutos").ToString
            Me.Txtleysaldo.Text = drd.Item("saldoley").ToString
            Me.Txtpurossaldo.Text = drd.Item("saldopuros").ToString

            Dim SaldoBruto, SaldoLey, SaldoPuro As Double
            SaldoBruto = Me.TxtBrutosSaldo.Text
            SaldoLey = Me.Txtleysaldo.Text
            SaldoPuro = Me.Txtpurossaldo.Text

            Me.TxtBrutosSaldo.Text = Math.Round(SaldoBruto, 4).ToString
            Me.Txtleysaldo.Text = Math.Round(SaldoLey, 4).ToString
            Me.Txtpurossaldo.Text = Math.Round(SaldoPuro, 4).ToString

        Else
            MessageBox.Show("Saldo Inicial en Cero", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Me.TxtBrutosSaldo.Text = ""
            Dim SaldoTotal As Double = 0
            Me.TxtBrutosSaldo.Text = Format(SaldoTotal, "###,##0")

            'Me.Txtleysaldo.Text = ""
            Dim SaldoTotalBruto As Double = 0
            Me.Txtleysaldo.Text = Format(SaldoTotalBruto, "###,##0")

            'Me.Txtpurossaldo.Text = ""
            Dim SaldoTotal1 As Double = 0
            Me.Txtpurossaldo.Text = Format(SaldoTotal1, "###,##0")

        End If
        drd.Close()
        conn.Close()

    End Sub

    'ACTUALIZO SALDO DE COMPRAVENTA
    Private Sub SaldosCompraVenta()
        Dim dt As New DataTable
        Dim conn As New OleDbConnection(cs)
        Dim consulta As String = "SELECT TOP 1 * FROM compraventa ORDER BY numcompra DESC"

        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read() Then
            Me.TxtSalBrutos.Text = drd.Item("vrsaldobrutosC").ToString
            Me.TxtSalLey.Text = drd.Item("vrsaldoleyC").ToString
            Me.TxtSalPu.Text = drd.Item("vrsaldopurosC").ToString

            Dim SaldoBrutosCV, SaldoLeyCV, SaldoPuroCV As Double
            SaldoBrutosCV = Me.TxtSalBrutos.Text
            SaldoLeyCV = Me.TxtSalLey.Text
            SaldoPuroCV = Me.TxtSalPu.Text

            Me.TxtSalBrutos.Text = Math.Round(SaldoBrutosCV, 4).ToString
            Me.TxtSalLey.Text = Math.Round(SaldoLeyCV, 4).ToString
            Me.TxtSalPu.Text = Math.Round(SaldoPuroCV, 4).ToString

        Else
            MessageBox.Show("Saldo Inicial en Cero", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Me.TxtBrutosSaldo.Text = ""
            Dim SaldoTotal As Double = 0
            Me.TxtSalBrutos.Text = Format(SaldoTotal, "###,##0")

            'Me.Txtleysaldo.Text = ""
            Dim SaldoTotalBruto As Double = 0
            Me.TxtSalLey.Text = Format(SaldoTotalBruto, "###,##0")

            'Me.Txtpurossaldo.Text = ""
            Dim SaldoTotal1 As Double = 0
            Me.TxtSalPu.Text = Format(SaldoTotal1, "###,##0")

        End If
        drd.Close()
        conn.Close()

    End Sub

#End Region

#Region "PROCEDMIENTOS PARA EL NUMERO DE TRASLADO"

    'BOTON DE ACTUALIZAR DATOS DE  TRASLADOS
    Private Sub BtnConsulta_Click(sender As Object, e As EventArgs) Handles BtnConsulta.Click

        If TxtNumTraslado.Text = "" Then
            MessageBox.Show("El campo no puede estar vacio, digite un número.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtNumTraslado.Select()
            Me.TxtNumTraslado.Focus()
        Else
            Try
                ' Obtenemos un objeto DataRow correspondiente con el ID escrito en un control TextBox
                Dim row As DataRow = Buscar(TxtNumTraslado.Text)
                If (row Is Nothing) Then
                    MessageBox.Show("El Número Consulatado ya fué Ingresado o No existe, por favor Revise.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' Abandonamos el procedimiento
                    Me.TxtNumTraslado.Clear()
                    'ubico el cursor
                    Me.GroupBox1.Select()
                    Me.GroupBox1.Focus()
                    Me.TxtNumTraslado.Select()
                    Me.TxtNumTraslado.Focus()
                    Return
                End If
                ' Rellenamos los correspondientes controles TextBox con los datos existentes en el objeto DataRow obtenido.
                Me.TxtInggrbrutos.Text = Convert.ToString(row("brutosfundi"))
                Me.TxtIngley.Text = Convert.ToString(row("leyfundi"))
                Me.TxtInggrpuros.Text = Convert.ToString(row("purosfundi"))

                Dim VrIngBrutos, VrIngLey, VrIngPuros As Double

                VrIngBrutos = Me.TxtInggrbrutos.Text
                VrIngLey = Me.TxtIngley.Text
                VrIngPuros = Me.TxtInggrpuros.Text

                Me.TxtInggrbrutos.Text = Math.Round(VrIngBrutos, 4).ToString
                Me.TxtIngley.Text = Math.Round(VrIngLey, 4).ToString
                Me.TxtInggrpuros.Text = Math.Round(VrIngPuros, 4).ToString

                'Inhabilito el campo d ebusqueda
                Me.TxtNumTraslado.Enabled = False
                Me.BtnConsulta.Enabled = False
                Me.Txtnuevaley.Enabled = False
                Me.Txtnuevagrpuros.Enabled = False

                'HABILITO LOS CAMPO SIGUIENTES
                Me.TxtNuevosBrutos.Enabled = True
                Me.Txtnuevaley.Enabled = True
                Me.Txtnuevagrpuros.Enabled = True
                Me.BtnAjuste.Enabled = True
                Me.Txtajuste.Enabled = False
                Me.TxtConcepto.Enabled = True

                'ubico elcursor
                Me.GroupBox3.Select()
                Me.GroupBox3.Focus()
                Me.TxtNuevosBrutos.Select()
                Me.TxtNuevosBrutos.Focus()

            Catch ex As Exception
                ' Se ha producido un error
                MessageBox.Show("Sin registros para Ingresar." & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If

    End Sub

    'FUNCION PARA BUSCAR EL NUMERO DE TRASLADO
    Private Function Buscar(id As String) As DataRow
        If (String.IsNullOrEmpty(id)) Then
            Throw New ArgumentNullException("id")
        End If
        ' Declaramos la variable que devolverá la función, que en principio indica que no existe ningún registro
        ' que coincida con el ID especificado.
        Dim returnValue As DataRow = Nothing
        ' Creamos la conexión con la base de SQL Server.
        Using conn As New OleDbConnection(cs)
            ' Creamos un objeto Command.
            Dim cmd As OleDbCommand = conn.CreateCommand()
            ' Indicamos la consulta SQL de selección que deseamos ejecutar
            'cmd.CommandText = "SELECT * FROM Fundicion WHERE Id=@id"
            cmd.CommandText = "SELECT * FROM Fundicion WHERE numdocufundi=@numdocufundi And fundiventa <> '" & 1 & "' ORDER BY numdocufundi ASC"
            ' Añadimos el único parámetro de entrada existente en la consulta
            cmd.Parameters.AddWithValue("@id", id)
            ' Creamos el adaptador de datos al que le pasamos el objeto Command.
            Dim da As New OleDbDataAdapter(cmd)
            ' Intentamos rellenar un objeto DataTable como resultado de ejecutar la consulta SQL de selección especificada.
            Using dt As New DataTable()
                da.Fill(dt)
                If (dt.Rows.Count > 0) Then
                    ' Nos quedamos con la primera fila u objeto DataRow.
                    returnValue = dt.Rows(0)
                End If
            End Using
        End Using
        ' Devolvemos el objeto DataRow obtenido.
        Return returnValue
    End Function

#End Region

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE NUEVO INGRESO
    Private Sub BtnNuevoCaja_Click(sender As Object, e As EventArgs) Handles BtnNuevoCaja.Click

        'PRIMER GRUPO DE PANEL=========================================================
        'colocamos los texbox en no editable
        Me.Txtced_cl.Enabled = False
        Me.TxtPagado.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.DTPfechaactual.Enabled = False
        Me.TxtNumDoc.Enabled = False

        '2 GRUPO DE PANEL=========================================================
        'limpio datos
        Me.TxtNumTraslado.Clear()
        Me.TxtInggrbrutos.Clear()
        Me.TxtIngley.Clear()
        Me.TxtInggrpuros.Clear()
        Me.TxtConcepto.Clear()

        'HABILITADOS CAMPOS
        Me.TxtNumTraslado.Enabled = True
        Me.BtnConsulta.Enabled = True

        'INHABILITO LOS CAMPOS DE TEXTO
        Me.TxtInggrbrutos.Enabled = False
        Me.TxtIngley.Enabled = False
        Me.TxtInggrpuros.Enabled = False

        '3 GRUPO DE PANEL=========================================================
        'inhabilito el boton
        Me.TxtNuevosBrutos.Enabled = False
        Me.Txtnuevaley.Enabled = False
        Me.Txtnuevagrpuros.Enabled = False
        Me.BtnAjuste.Enabled = False
        Me.Txtajuste.Enabled = False
        Me.TxtConcepto.Enabled = False

        'llamo el  preocedimeinto de CONCATENAR 
        ''UnirNombres()
        'muestro el resultado y los concateno
        Me.TxtPagado.Text = Me.TxtName.Text & " " & Me.TxtSurname.Text

        'UBICO EL CURSOR
        Me.GroupBox1.Select()
        Me.GroupBox1.Focus()
        Me.TxtNumTraslado.Select()
        Me.TxtNumTraslado.Focus()

        'ejecutamos contador
        ContadorIngreso()

        'copio el numero de documento
        Me.TxtNumImp.Text = Me.TxtNumDoc.Text

        'HABILITO LOS BOTONES
        Me.BtnNuevoCaja.Visible = False
        Me.BtnNuevoCaja.Enabled = False

        Me.BtnGuardaIngreso.Visible = True
        Me.BtnGuardaIngreso.Enabled = True

        Me.BtnImpriCaja.Visible = True
        Me.BtnImpriCaja.Enabled = False

        Me.BtnRegreCaja.Visible = True
        Me.BtnRegreCaja.Enabled = True

        'INHABILITO EL DATAGRID
        Me.DGVingresos.Enabled = False

        'INHABILITO EL BOTON DE GUARDAR
        Me.BtnGuardaIngreso.Enabled = False

        'ACTUALIZA SALDOS DE DECLARA 
        SaldosIngresoInicial()

        'SalInicial()

        'ACTUALIZA SALDO DE COMPRAVENTAS PARA LLEVAR SALDOS ACUMULADOS
        SaldosCompraVenta()

    End Sub

    'BOTON DE GUARDAR INGRESOS
    Private Sub BtnGuardaIngreso_Click(sender As Object, e As EventArgs) Handles BtnGuardaIngreso.Click
        If TxtNuevosBrutos.Text = "" And Txtnuevaley.Text = "" And Txtnuevagrpuros.Text = "" Then
            MessageBox.Show("Datos OK", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtNuevosBrutos.Select()
            Me.TxtNuevosBrutos.Focus()
        Else
            'llamo al procedimiento 
            'MsgBox("voy act")
            'Actfundiventas()
            UpdateNum()
            'MsgBox("voy a guardar")
            GuardaIngresos()
        End If

    End Sub

    'ACTUALZIA FUNDICION EN EL CAMPO FUNDIVENTAS
    Private Sub Actfundiventas()
        ''revisamos la conexion
        ''If conn.State() = ConnectionState.Closed Then
        ''    conn.Open()
        ''End If
        Try
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            Dim salfundi As String
            salfundi = "1"

            'Dim num As Double
            'num = CInt(TxtNumDoc.Text)

            Dim sqlf As String = "UPDATE Fundicion SET fundiventa = '" & salfundi & "' WHERE numdocufundi = '" & TxtNumTraslado.Text & "'"
            cmd.Parameters.AddWithValue("@fundiventa", salfundi)
            cmd = New OleDbCommand(sqlf, conn) With {
                .CommandText = sqlf
            }

            'MsgBox(num)
            MsgBox(salfundi)
            MsgBox(sqlf)

            'para ejecutar la consulta
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Se actualizo el registro seleccionado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            'muestro el mensaje
            MessageBox.Show("Error al Actualizar Ingreso.! " & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            conn.Close()
        End Try
    End Sub

    'ACTUALIZA AGREGA EL NUMERO 1 A FUNDIVENTAS PARA BLOQUEAR EL DOCUMENTO FUNDIDO 
    Private Sub UpdateNum()
        Dim rowsAffected As Integer
        Using con As New OleDbConnection(cs)
            Using cmd As New OleDbCommand("UPDATE Fundicion Set  fundiventa = @valor WHERE numdocufundi =@num", conn)
                cmd.Parameters.Add("@valor", OleDbType.VarChar).Value = "1"
                cmd.Parameters.Add("@num", OleDbType.Integer).Value = Me.TxtNumTraslado.Text
                conn.Open()
                rowsAffected = cmd.ExecuteNonQuery()
                conn.Close()
                'MsgBox("Se actualizo el registro seleccionado", MsgBoxStyle.Information, "Negocios")
            End Using
        End Using
    End Sub

    'PROCEDIMIENTO PARA GUARDAR INGRESOS
    Private Sub GuardaIngresos()

        'revisamos la conexion
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        'INHABILITO EL DATAGRID
        Me.DGVingresos.Enabled = False

        'VARIABLE FECHA INGRESO
        Dim fechaING As Date = CDate(Format(Date.Now.Date))

        'VARIABLE FECHA VENTA
        Dim fechaVENTA As Date = CDate(Format(Date.Now.Date))

        'VARIABLE FECHA CREADO
        Dim fechaC As Date = CDate(Format(Date.Now.Date))

        'VARIABLE FECHA MODIFICA
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        '===================== ACTUALIZA SALDO INICIAL
        Dim InicialBr, InicialLey, InicialPu As Double
        InicialBr = CDec(Me.TxtBrutosSaldo.Text)
        InicialLey = CDec(Me.Txtleysaldo.Text)
        InicialPu = CDec(Me.Txtpurossaldo.Text)

        Dim FtraBr, FtraLey, FtraPu As Double
        FtraBr = CDec(Me.TxtInggrbrutos.Text)
        FtraLey = CDec(Me.TxtIngley.Text)
        FtraPu = CDec(Me.TxtInggrpuros.Text)

        Dim TotsaldosBr, TotsaldoLey, TotsaldoPu As Double
        InicialPu = 0
        If InicialPu = 0 Then
            TotsaldoPu = FtraPu
        Else
            TotsaldoPu = InicialPu - FtraPu
        End If

        InicialBr = 0
        If InicialBr = 0 Then
            TotsaldosBr = FtraBr
        Else
            TotsaldosBr = InicialBr - FtraBr
        End If

        InicialLey = 0
        If InicialLey = 0 Then
            TotsaldoLey = TotsaldoPu / TotsaldosBr
        Else
            TotsaldoLey = TotsaldoPu / TotsaldosBr
        End If

        Me.Txtpurossaldo.Text = Math.Round(TotsaldoPu, 4).ToString
        Me.TxtBrutosSaldo.Text = Math.Round(TotsaldosBr, 4).ToString
        Me.Txtleysaldo.Text = Math.Round(TotsaldoLey, 4).ToString

        '==================================================
        'VARIABLE VARIAS
        Dim Ven1, Ven2, veryC As String
        Ven1 = "0"
        Ven2 = "0"
        veryC = "0"

        'OPERACIONES DE SALDO ===================================================
        'llamamos la operacion SUMAR PUROS
        Dim P1, P2, TP2 As Decimal
        P1 = CDec(Me.TxtSalPu.Text)   'SALDO de COMPRAVENTAS EN GRAMOS PUROS
        P2 = CDec(Me.Txtnuevagrpuros.Text)  'VALOR DE GARMOS PUROS QUE INGRESAN
        TP2 = P1 + P2
        TP2 = Math.Round(TP2, 4).ToString

        'llamamos la operacion SUMAR BRUTOS
        Dim B1, B2, TB2 As Decimal
        B1 = CDec(Me.TxtSalBrutos.Text)   'SALDO de COMPRAVENTAS EN GRAMOS BRUTOS
        B2 = CDec(Me.TxtNuevosBrutos.Text)  'VALOR DE GARMOS PUROS QUE INGRESAN
        TB2 = B1 + B2
        TB2 = Math.Round(TB2, 4).ToString

        'llamamos la operacion SUMAR LEY
        Dim L1, L2, TL2 As Decimal
        L1 = CDec(Me.TxtSalLey.Text)  'SALDO DE LA LEY
        L2 = CDec(Me.Txtnuevaley.Text) 'INGRESO DE LA NUEVA LEY
        If L1 = 0 Then
            TL2 = Me.Txtnuevaley.Text
        Else
            'TL2 = (L1 + L2) / 2
            TL2 = TP2 / TB2
        End If
        TL2 = Math.Round(TL2, 4).ToString

        Try
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            sql = "INSERT INTO compraventa (numcompra, cedunit, nomciud, fechaingreso, nompagado, " &
                                "saldobrutos, saldoley, saldopuros, numtraslado, grbrutosT, leyT, grpurosT, " &
                                "brutosnuevos, leynueva, grpurosnuevos, ajuste, concenuevo, vrsaldobrutosC, vrsaldoleyC, vrsaldopurosC, verificaC, " &
                                "fechaventa, ventas1, ventas2, fecha_creado, fecha_modifica)VALUES ('" & TxtNumDoc.Text & "', " &
                                "'" & Txtced_cl.Text & "', '" & TxtCiudad.Text & "', '" & fechaING & "', '" & TxtPagado.Text & "', " &
                                "'" & TxtBrutosSaldo.Text & "', '" & Txtleysaldo.Text & "','" & Txtpurossaldo.Text & "','" & TxtNumTraslado.Text & "', " &
                                "'" & TxtInggrbrutos.Text & "', '" & TxtIngley.Text & "', '" & TxtInggrpuros.Text & "', " &
                                "'" & TxtNuevosBrutos.Text & "', '" & Txtnuevaley.Text & "', '" & Txtnuevagrpuros.Text & "', '" & Txtajuste.Text & "', " &
                                "'" & TxtConcepto.Text & "','" & TB2 & "', '" & TL2 & "','" & TP2 & "', " &
                                "'" & veryC & "','" & fechaVENTA & "', '" & Ven1 & "', '" & Ven2 & "','" & fechaC & "', '" & fechaM & "')"


            cmd.CommandText = sql

            'para ejecutar la consulta
            cmd.ExecuteNonQuery()
            'cierro la conexcion
            conn.Close()

            ''muestro el mensaje de guardar
            MessageBox.Show("INGRESO, Guardado con Éxito! ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'actualizo el datagrid
            'ActualizoDatagridCV()
            '=============0
            'PANEL 1===============================================
            'limpio los campos
            Me.TxtNumDoc.Clear()
            Me.Txtced_cl.Clear()
            Me.TxtCiudad.Clear()
            Me.TxtPagado.Clear()
            'inhabilito los campos
            Me.TxtNumDoc.Enabled = False
            Me.Txtced_cl.Enabled = False
            Me.TxtCiudad.Enabled = False
            Me.TxtPagado.Enabled = False
            Me.DTPfechaactual.Enabled = False
            'PANEL 2===============================================
            'limpio los campos
            Me.TxtBrutosSaldo.Clear()
            Me.Txtleysaldo.Clear()
            Me.Txtpurossaldo.Clear()
            Me.TxtNumTraslado.Clear()
            Me.TxtInggrbrutos.Clear()
            Me.TxtIngley.Clear()
            Me.TxtInggrpuros.Clear()
            'inhabilito los campos
            Me.TxtBrutosSaldo.Enabled = False
            Me.Txtleysaldo.Enabled = False
            Me.Txtpurossaldo.Enabled = False
            Me.TxtNumTraslado.Enabled = False
            Me.TxtInggrbrutos.Enabled = False
            Me.TxtIngley.Enabled = False
            Me.TxtInggrpuros.Enabled = False
            'PANEL 3===============================================
            'limpio los campos
            Me.TxtNuevosBrutos.Clear()
            Me.Txtnuevaley.Clear()
            Me.Txtnuevagrpuros.Clear()
            Me.Txtajuste.Clear()
            Me.TxtConcepto.Clear()
            'inhabilito los campos
            Me.TxtNuevosBrutos.Enabled = False
            Me.Txtnuevaley.Enabled = False
            Me.Txtnuevagrpuros.Enabled = False
            Me.Txtajuste.Enabled = False
            Me.TxtConcepto.Enabled = False
            'PANEL 4===============================================
            'INHABIITO EL DATAGRID
            Me.DGVingresos.Enabled = False
            'DESHABILITO LOS BOTONES
            'HABILITO LOS BOTONES
            Me.BtnNuevoCaja.Visible = True
            Me.BtnNuevoCaja.Enabled = False

            Me.BtnGuardaIngreso.Visible = False
            Me.BtnGuardaIngreso.Enabled = False

            Me.BtnImpriCaja.Visible = True
            Me.BtnImpriCaja.Enabled = True

            Me.BtnRegreCaja.Visible = True
            Me.BtnRegreCaja.Enabled = True

            'ubico el cursor
            Me.BtnImpriCaja.Select()
            Me.BtnImpriCaja.Focus()

        Catch ex As Exception
            'muestro el mensaje
            MessageBox.Show("Error al Guardar Ingreso.! " & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'limpio todo
            Me.TxtNumDoc.Clear()
            Me.TxtPagado.Clear()
            Me.TxtConcepto.Clear()
            'ubico el cursor
            Me.TxtConcepto.Focus()
            'cierro conexcion
            conn.Close()
        End Try

    End Sub

    'BOTON DE IMPRIMIR
    Private Sub BtnImpriCaja_Click(sender As Object, e As EventArgs) Handles BtnImpriCaja.Click
        FrmNuevaCompra.TxtNumCV.Text = Me.TxtNumImp.Text
        FrmNuevaCompra.Show()
    End Sub

    'BOTON DE REGRESAR
    Private Sub BtnRegreCaja_Click(sender As Object, e As EventArgs) Handles BtnRegreCaja.Click
        'cierro el formulario
        Me.Close()
        'cierro la base de datos
        conn.Close()
        'abro el nuevo formulario
        'FrmCajaAse1.Show()
    End Sub

    'CALCULO DEL AJUSTE
    Private Sub BtnAjuste_Click(sender As Object, e As EventArgs) Handles BtnAjuste.Click

        If TxtNuevosBrutos.Text = "" And Txtnuevaley.Text = "" And Txtnuevagrpuros.Text = "" Then
            MessageBox.Show("Los Campos no deben estar vacíos, ingrese cantidades por favor.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'HAGO LA OPERACION DE CALCULO ****DEBE RESTAR SON LOS GRAMOS BRUTOS****
            Dim val1, val2, val3R As Double
            val1 = CDec(TxtInggrbrutos.Text)
            val2 = CDec(TxtNuevosBrutos.Text)
            val3R = val1 - val2
            Me.Txtajuste.Text = Math.Round(val3R, 4).ToString

            'INHABILITO LOS CAMPOS
            Me.TxtNuevosBrutos.Enabled = False
            Me.Txtnuevaley.Enabled = False
            Me.Txtnuevagrpuros.Enabled = False
            Me.BtnAjuste.Enabled = False
            Me.Txtajuste.Enabled = False

            'UBICO EL CURSOR
            Me.GroupBox3.Select()
            Me.GroupBox3.Focus()
            Me.TxtConcepto.Select()
            Me.TxtConcepto.Focus()

            'HABILITO BOTONES
            Me.BtnGuardaIngreso.Enabled = True
        End If

    End Sub

#End Region

#Region "DATAGRIDVIEW INGRESOS COMPRAVENTA"

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

            Me.DGVingresos.Columns(0).Width = 30
            Me.DGVingresos.Columns(0).HeaderText = "Id"
            Me.DGVingresos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVingresos.Columns(1).Width = 50
            Me.DGVingresos.Columns(1).HeaderText = "No. Compra"
            Me.DGVingresos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVingresos.Columns(4).Width = 90
            Me.DGVingresos.Columns(4).HeaderText = "Fecha Compra"
            Me.DGVingresos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVingresos.Columns(13).Width = 90
            Me.DGVingresos.Columns(13).HeaderText = "Gr. Brutos Compra"
            Me.DGVingresos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVingresos.Columns(13).DefaultCellStyle.Format = "N4"

            Me.DGVingresos.Columns(14).Width = 60
            Me.DGVingresos.Columns(14).HeaderText = "Ley Compra"
            Me.DGVingresos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVingresos.Columns(14).DefaultCellStyle.Format = "N4"

            Me.DGVingresos.Columns(15).Width = 90
            Me.DGVingresos.Columns(15).HeaderText = "Gr. Puros Compra"
            Me.DGVingresos.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVingresos.Columns(15).DefaultCellStyle.Format = "N4"

            Me.DGVingresos.Columns(16).Width = 50
            Me.DGVingresos.Columns(16).HeaderText = "Ajuste"
            Me.DGVingresos.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVingresos.Columns(16).DefaultCellStyle.Format = "N4"

            Me.DGVingresos.Columns(18).Width = 90
            Me.DGVingresos.Columns(18).HeaderText = "Saldo Gr. Brutos"
            Me.DGVingresos.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVingresos.Columns(18).DefaultCellStyle.Format = "N4"

            Me.DGVingresos.Columns(19).Width = 60
            Me.DGVingresos.Columns(19).HeaderText = "Saldo Ley"
            Me.DGVingresos.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVingresos.Columns(19).DefaultCellStyle.Format = "N4"

            Me.DGVingresos.Columns(20).Width = 90
            Me.DGVingresos.Columns(20).HeaderText = "Saldo Gr. Puros"
            Me.DGVingresos.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVingresos.Columns(20).DefaultCellStyle.Format = "N4"

            'Me.DGVingresos.Columns(16).Width = 90
            'Me.DGVingresos.Columns(16).HeaderText = "Saldo Ley"
            'Me.DGVingresos.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.DGVingresos.Columns(16).DefaultCellStyle.Format = "N4"

            'Me.DGVingresos.Columns(17).Width = 90
            'Me.DGVingresos.Columns(17).HeaderText = "Saldo Gramos Puros"
            'Me.DGVingresos.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.DGVingresos.Columns(17).DefaultCellStyle.Format = "N4"

            'Me.DGVingresos.Columns(19).Width = 90
            'Me.DGVingresos.Columns(19).HeaderText = "Fecha Venta"
            'Me.DGVingresos.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Me.DGVingresos.Columns(20).Width = 90
            'Me.DGVingresos.Columns(20).HeaderText = "No. Doc. Venta"
            'Me.DGVingresos.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Me.DGVingresos.Columns(26).Width = 90
            'Me.DGVingresos.Columns(26).HeaderText = "Ley Venta"
            'Me.DGVingresos.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DGVingresos.Columns(26).DefaultCellStyle.Format = "N4"

            'Me.DGVingresos.Columns(27).Width = 90
            'Me.DGVingresos.Columns(27).HeaderText = "Gramos Puros Venta"
            'Me.DGVingresos.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.DGVingresos.Columns(27).DefaultCellStyle.Format = "N4"


            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVingresos.Columns("Id").Visible = False                       '00
            'Me.DGVingresos.Columns("numcompra").Visible = False                '01
            Me.DGVingresos.Columns("cedunit").Visible = False                  '02
            Me.DGVingresos.Columns("nomciud").Visible = False                  '03    
            'Me.DGVingresos.Columns("fechaingreso").Visible = False             '04
            Me.DGVingresos.Columns("nompagado").Visible = False                '05
            '=================
            Me.DGVingresos.Columns("saldoBrutos").Visible = False             '06
            Me.DGVingresos.Columns("saldoley").Visible = False                 '07
            Me.DGVingresos.Columns("saldopuros").Visible = False               '08
            '=================
            Me.DGVingresos.Columns("numtraslado").Visible = False              '09
            Me.DGVingresos.Columns("grbrutosT").Visible = False                '10
            Me.DGVingresos.Columns("leyT").Visible = False                     '11
            Me.DGVingresos.Columns("grpurosT").Visible = False                 '12
            '=================
            'Me.DGVingresos.Columns("brutosnuevos").Visible = False             '13
            'Me.DGVingresos.Columns("leynueva").Visible = False                 '14
            'Me.DGVingresos.Columns("grpurosnuevos").Visible = False            '15
            'Me.DGVingresos.Columns("ajuste").Visible = False                   '16
            Me.DGVingresos.Columns("concenuevo").Visible = False               '17
            '=================
            'Me.DGVingresos.Columns("vrsaldobrutosC").Visible = False           '18
            'Me.DGVingresos.Columns("vrsaldoleyC").Visible = False              '19
            'Me.DGVingresos.Columns("vrsaldopurosC").Visible = False            '20
            Me.DGVingresos.Columns("verificaC").Visible = False                '21
            '=================
            Me.DGVingresos.Columns("fechaventa").Visible = False               '22
            Me.DGVingresos.Columns("cedunitventa").Visible = False             '23
            Me.DGVingresos.Columns("numventa").Visible = False                 '24
            Me.DGVingresos.Columns("razonsocial").Visible = False              '25
            Me.DGVingresos.Columns("direcionventa").Visible = False            '26
            Me.DGVingresos.Columns("telcventa").Visible = False                '27
            Me.DGVingresos.Columns("ciudadventa").Visible = False              '28
            '=================
            Me.DGVingresos.Columns("vrbrutosventa").Visible = False            '29
            Me.DGVingresos.Columns("vrleyventa").Visible = False               '30
            Me.DGVingresos.Columns("vrgrpurosventa").Visible = False           '31
            '=================
            Me.DGVingresos.Columns("vrsaldobrutosventa").Visible = False       '32
            Me.DGVingresos.Columns("vrsaldoleyventa").Visible = False          '33
            Me.DGVingresos.Columns("vrsaldopurosventa").Visible = False        '34
            Me.DGVingresos.Columns("conceventas").Visible = False              '35
            '=================
            Me.DGVingresos.Columns("ventas1").Visible = False                  '36
            Me.DGVingresos.Columns("ventas2").Visible = False                  '37
            Me.DGVingresos.Columns("fecha_creado").Visible = False             '38
            Me.DGVingresos.Columns("fecha_modifica").Visible = False           '39

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
        Dim query As String = "Select MAX(numcompra)FROM compraventa"
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

    'PERMITE TECLA ENTER NUMERO DE TRASLADO
    Private Sub TxtNumTraslado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumTraslado.KeyPress

        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MessageBox.Show("En este  Campo Solo Digite Números", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'EVENTO KEYPRESS nuevos brutos
    Private Sub TxtNuevosBrutos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNuevosBrutos.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'NumerosyDecimal(TxtNuevosBrutos, e)

        ' Obtenemos el carácter separador decimal existente actualmente en la configuración regional de Windows.
        'If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
        If ((e.KeyChar = "."c)) Then
            e.KeyChar = Threading.Thread.CurrentThread.
            CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'PERMITE TECLA ENTER GRAMOS LEY
    Private Sub Txtnuevaley_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtnuevaley.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'NumerosyDecimal(Txtnuevaley, e)

        ' Obtenemos el carácter separador decimal existente actualmente en la configuración regional de Windows.
        'If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
        If ((e.KeyChar = "."c)) Then
            e.KeyChar = Threading.Thread.CurrentThread.
            CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'PERMITE TECLA ENTER GRAMOS PUROS
    Private Sub Txtnuevagrpuros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtnuevagrpuros.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'NumerosyDecimal(Txtnuevagrpuros, e)

        ' Obtenemos el carácter separador decimal existente actualmente en la configuración regional de Windows.
        'If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c)) Then
        If ((e.KeyChar = "."c)) Then
            e.KeyChar = Threading.Thread.CurrentThread.
            CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'PERMITE TECLA ENTER CONCEPTO
    Private Sub TxtConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtConcepto.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    '*** EVENTOS CHANGE CAMPOS VACIOS

    'VALIDA CAMPOS VACIOS EN CONCEPTO
    Private Sub TxtConcepto_TextChanged(sender As Object, e As EventArgs) Handles TxtConcepto.TextChanged
        ValidaCamposVacios()
    End Sub

    'VALIDA CAMPOS VACIOS EN NUEVA BRUTOS
    Private Sub TxtNuevosBrutos_TextChanged(sender As Object, e As EventArgs) Handles TxtNuevosBrutos.TextChanged
        ValidaCamposVacios()
    End Sub

    'VALIDA CAMPOS VACIOS EN NUEVA LEY
    Private Sub Txtnuevaley_TextChanged(sender As Object, e As EventArgs) Handles Txtnuevaley.TextChanged
        ValidaCamposVacios()
    End Sub

    'VALIDA CAMPOS VACIOS EN NUEVOS PUROS
    Private Sub Txtnuevagrpuros_TextChanged(sender As Object, e As EventArgs) Handles Txtnuevagrpuros.TextChanged
        ValidaCamposVacios()
    End Sub


#End Region

#Region "EVENTO LEAVE"

    'FORMATO GRAMOS BRUTOS
    Private Sub TxtNuevosBrutos_Leave(sender As Object, e As EventArgs) Handles TxtNuevosBrutos.Leave
        'Me.TxtNuevosBrutos.Text = CDec(If(Me.TxtNuevosBrutos.Text.Contains("."), TxtNuevosBrutos.Text.Replace(".", ","), TxtNuevosBrutos.Text))
    End Sub

    'FORMATO GRAMOS LEY
    Private Sub Txtnuevaley_Leave(sender As Object, e As EventArgs) Handles Txtnuevaley.Leave
        'Me.Txtnuevaley.Text = CDec(If(Me.Txtnuevaley.Text.Contains("."), Txtnuevaley.Text.Replace(".", ","), Txtnuevaley.Text))
    End Sub

    'FORMATO GRAMOS PUROS
    Private Sub Txtnuevagrpuros_Leave(sender As Object, e As EventArgs) Handles Txtnuevagrpuros.Leave
        'Me.Txtnuevagrpuros.Text = CDec(If(Me.Txtnuevagrpuros.Text.Contains("."), Txtnuevagrpuros.Text.Replace(".", ","), Txtnuevagrpuros.Text))
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub


#End Region

    'no se usa pero funcionan
    'ACTUALIZA DATOS DEL VALOR DEL SALDO ACTUAL DE GRAMOS PUROS DE FUNDICION, PARA EL FORMULARIO LOAD
    'Private Sub SaldosIngresoInicial()
    '    Dim dt As New DataTable
    '    Dim sing As String = "0"
    '    Dim conn As New OleDbConnection(cs)
    '    'Dim consulta As String = "Select TOP 1 * FROM Fundicion WHERE cedunit = '" & Txtced_cl.Text & "' ORDER BY id DESC"
    '    'Dim consulta As String = "SELECT TOP 1 * FROM Fundicion WHERE numdocufundi=@numdocufundi ORDER BY numdocufundi DESC"
    '    Dim consulta As String = "SELECT TOP 1 * FROM Fundicion WHERE fundiventa = '" & sing & "' ORDER BY numdocufundi DESC"

    '    Dim cmd As New OleDbCommand(consulta, conn)
    '    Dim drd As OleDbDataReader
    '    conn.Open()
    '    drd = cmd.ExecuteReader
    '    If drd.Read() Then
    '        Me.Txtleysaldo.Text = drd.Item("vrsaldosley").ToString
    '        Me.Txtpurossaldo.Text = drd.Item("vrsaldospuros").ToString

    '        Dim SaldoLey, SaldoPuro As Double
    '        SaldoLey = Me.Txtleysaldo.Text
    '        SaldoPuro = Me.Txtpurossaldo.Text

    '        Me.Txtleysaldo.Text = Math.Round(SaldoLey, 2).ToString
    '        Me.Txtpurossaldo.Text = Math.Round(SaldoPuro, 4).ToString

    '    Else
    '        MsgBox("Saldo Inicial en Cero", MsgBoxStyle.Information, "Negocios")

    '        Me.Txtleysaldo.Text = 0
    '        Dim SaldoTotal As Double
    '        Me.Txtleysaldo.Text = Format(SaldoTotal, "###,##0")

    '        Me.Txtpurossaldo.Text = 0
    '        Dim SaldoTotal1 As Double
    '        Me.Txtpurossaldo.Text = Format(SaldoTotal1, "###,##0")

    '    End If
    '    drd.Close()
    '    conn.Close()

    'End Sub


End Class