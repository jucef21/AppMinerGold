Imports System.Data.OleDb
Imports System.Globalization
Imports System.Threading

Public Class FrmTrasladaFundi

    'CARGUE DEL  FORMULARIO
    Private Sub FrmTrasladaFundi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-CO")
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        'revisamos la conexion
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        'LIMPIO EL CONTADOR
        Me.TxtNum_com.Clear()

        'formato del datatimepicker
        Me.DTPfechaactual.Format = DateTimePickerFormat.Custom
        Me.DTPfechaactual.CustomFormat = "dd/MM/yyyy"
        Me.DTPfechaactual.Value.ToString()
        Me.DTPfechaactual.Value = Date.Now.ToString("d")
        Me.DTPfechaactual.Enabled = False

        'INHABILITO EL DATAGRID
        Me.DataGridView1.Enabled = False
        Me.DataGridView2.Enabled = False

        'HABILITO LOS BOTONES
        Me.BtnPasa.Enabled = False
        Me.BtnQuita.Enabled = False

        Me.BtnTotaliza.Enabled = False

        Me.BtnNuevaFundi.Visible = True
        Me.BtnNuevaFundi.Enabled = True

        Me.BtnGuardaFundi.Visible = True
        Me.BtnGuardaFundi.Enabled = False

        Me.BtnImpriFundi.Visible = True
        Me.BtnImpriFundi.Enabled = False

        Me.BtnLimpia.Visible = True
        Me.BtnLimpia.Enabled = False

        'INCIAR EL DATAGRID LIMPIO DESPUES DE CUALQUIER CONSULTA
        'para limpiar las filas
        Try
            If DataGridView1.RowCount >= 1 Then
                For i As Integer = 0 To DataGridView1.RowCount - 1
                    DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
                Next
            End If
        Catch ex As Exception
        Finally
            If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        'para limpiar las filas
        Try
            If DataGridView2.RowCount >= 1 Then
                For i As Integer = 0 To DataGridView2.RowCount - 1
                    DataGridView2.Rows.Remove(DataGridView2.CurrentRow)
                Next
            End If
        Catch ex As Exception
        Finally
            If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TextBox3.Clear()
        Me.TxtMetal.Clear()

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DATAGRIDVIEW 1
    Private Sub BtnPasa_Click(sender As Object, e As EventArgs) Handles BtnPasa.Click

        Dim Coleccion As DataGridViewSelectedRowCollection = DataGridView1.SelectedRows

        For Each fila As DataGridViewRow In Coleccion
            'variables
            Dim id, nom_com, metal, grbrutos, ley, grpuros, verifica, numfundi As String

            'asignamos los valores del datagrid a las varibles
            id = DataGridView1(0, fila.Index).Value
            nom_com = DataGridView1(2, fila.Index).Value
            metal = DataGridView1(10, fila.Index).Value
            grbrutos = DataGridView1(13, fila.Index).Value
            ley = DataGridView1(14, fila.Index).Value
            grpuros = DataGridView1(15, fila.Index).Value

            verifica = DataGridView1(34, fila.Index).Value
            numfundi = DataGridView1(35, fila.Index).Value

            'pasar los valores del datagrid al datagrid2
            DataGridView2.Rows.Add(id, nom_com, metal, grbrutos, ley, grpuros, verifica, numfundi)

            'borrar la fila del datagrid1 que ya se a copiado al datagrid2
            DataGridView1.Rows.RemoveAt(fila.Index)

        Next

        ''Mostrar el número de filas de un DataGridView..
        'If DataGridView2.Rows.Count > 0 Then
        '    For r As Integer = 0 To DataGridView2.Rows.Count - 1
        '        Me.DataGridView2.Rows(r).HeaderCell.Value = (r + 1).ToString()
        '    Next
        'End If
        'DataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)

        'ACTUALIZA LOS CAMPOS CON LOS NUEVOS VALORES EN EL DATAGRID 2
        Dim Num As String
        Num = Me.TxtNum_com.Text
        'pasar los valores del datagrid al datagrid2
        Dim celda, celda1 As DataGridViewCell
        For Each row As DataGridViewRow In DataGridView2.Rows
            If Not row.IsNewRow Then
                DataGridView2.BeginEdit(False)
                celda = row.Cells("verifica")
                celda.Value = 1
                celda1 = row.Cells("numfundi")
                celda1.Value = Num
                DataGridView2.EndEdit()
            End If
        Next

        'ACTUALIZA PROCEDIMIENTOS AL PASAR LAS FILAS
        SumaDgvUno()
        SumaDgvDos()

        'ACTUALIZO CAMPO DE MATERIAL
        'Dim v_SelectRow As Integer = 1
        'v_SelectRow = Me.DataGridView2.CurrentRow.Index
        'TextBox4.Text = Me.DataGridView2.Item(2, v_SelectRow).Value
        Dim v_SelectRow As String
        v_SelectRow = DataGridView2.CurrentRow.Cells(2).Value
        Me.TxtMetal.Text = v_SelectRow.ToString

        'ACTIVO BOTON DE GUARDAR
        Me.BtnGuardaFundi.Enabled = True

    End Sub

    'BOTON DATAGRIDVIEW 2
    Private Sub BtnQuita_Click(sender As Object, e As EventArgs) Handles BtnQuita.Click

        Dim Coleccion As DataGridViewSelectedRowCollection = DataGridView2.SelectedRows

        For Each fila As DataGridViewRow In Coleccion
            'variables
            Dim id, grbrutos, ley, grpuros, verifica, numfundi As String

            'asignamos los vcvalores del datagrid a las varibles
            id = DataGridView2(0, fila.Index).Value
            grbrutos = DataGridView2(1, fila.Index).Value
            ley = DataGridView2(2, fila.Index).Value
            grpuros = DataGridView2(3, fila.Index).Value

            verifica = DataGridView1(4, fila.Index).Value
            numfundi = DataGridView1(5, fila.Index).Value

            'pasar los valores del datagrid al datagrid2
            DataGridView1.Rows.Add(id, grbrutos, ley, grpuros, verifica, numfundi)

            'borrar la fila del datagrid1 que ya se a copiado al datagrid2
            DataGridView2.Rows.RemoveAt(fila.Index)

        Next


    End Sub

    'BOTON DE NUEVA FUNDICION
    Private Sub BtnNuevaFundi_Click(sender As Object, e As EventArgs) Handles BtnNuevaFundi.Click

        'Actualizo el saldo de gramos
        ActualizoDatagrid()

    End Sub

    'BOTON DE GUARDAR FUNDICION
    Private Sub BtnGuardaFundi_Click(sender As Object, e As EventArgs) Handles BtnGuardaFundi.Click
        Try
            If Me.ValidateChildren And DataGridView2.DataSource <> Nothing Then
                MessageBox.Show("Datos OK", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'MessageBox.Show("Dato Error", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'llamo al procedimiento 
                'GuardaIngresos()
                GuardaData()
                Me.BtnImpriFundi.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'LIMPIO LOS DATAGRID
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView2.Rows.Clear()

        Me.TxtNum_com.Clear()
        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TextBox3.Clear()
        'Me.TxtMetal.Clear()

        Me.TxtDispoBrutos.Clear()
        Me.TxtDispoLey.Clear()
        Me.TxtDispoPuros.Clear()

        'inhabilito los campos
        Me.DTPfechaactual.Enabled = False

        Me.TextBox1.Enabled = False
        Me.TextBox2.Enabled = False
        Me.TextBox3.Enabled = False

        Me.TxtNum_com.Clear()
        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TextBox3.Clear()

        'INHABILITO EL DATAGRID
        Me.DataGridView1.Enabled = False
        Me.DataGridView2.Enabled = False

        'HABILITO LOS BOTONES
        Me.BtnPasa.Enabled = False
        Me.BtnQuita.Enabled = False

        Me.BtnTotaliza.Enabled = False
        Me.BtnNuevaFundi.Enabled = True
        Me.BtnGuardaFundi.Enabled = False
        Me.BtnImpriFundi.Enabled = True
        Me.BtnLimpia.Enabled = False

        'ubico el cursor
        Me.BtnNuevaFundi.Focus()

    End Sub

    'BOTON DE IMPRIMIR VENTA
    Private Sub BtnImpriFundi_Click(sender As Object, e As EventArgs) Handles BtnImpriFundi.Click
        Me.Cursor = Cursors.WaitCursor
        FrmRptFundiTraslada.TxtDocFundi.Text = TxtControlNum.Text
        FrmRptFundiTraslada.TxtMetal.Text = TxtMetal.Text
        FrmRptFundiTraslada.Show()
        Me.Cursor = Cursors.Default
        Me.BtnImpriFundi.Enabled = False
    End Sub

    'BOTON DE LIMPIAR VENTA
    Private Sub BtnLimpia_Click(sender As Object, e As EventArgs) Handles BtnLimpia.Click

        'LIMPIO LOS DATAGRID
        Me.DataGridView1.DataSource = Nothing
        'Me.DataGridView2.DataSource = Nothing
        Me.DataGridView2.Rows.Clear()

        Me.TxtNum_com.Clear()
        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TextBox3.Clear()
        Me.TxtMetal.Clear()

        Me.TxtDispoBrutos.Clear()
        Me.TxtDispoLey.Clear()
        Me.TxtDispoPuros.Clear()

        'HABILITO LOS BOTONES
        Me.BtnPasa.Enabled = False
        Me.BtnQuita.Enabled = False

        Me.BtnTotaliza.Enabled = False

        Me.BtnNuevaFundi.Visible = True
        Me.BtnNuevaFundi.Enabled = True

        Me.BtnGuardaFundi.Visible = True
        Me.BtnGuardaFundi.Enabled = False

        Me.BtnImpriFundi.Visible = True
        Me.BtnImpriFundi.Enabled = False

        Me.BtnLimpia.Visible = True
        Me.BtnLimpia.Enabled = False

    End Sub

    'BOTON DE TOTALIZAR DATOS DEL DATAGRID 2
    Private Sub BtnTotaliza_Click(sender As Object, e As EventArgs) Handles BtnTotaliza.Click
        Dim Total1, Total2, Total3 As Double
        Dim Col As Double = Me.DataGridView2.CurrentCell.ColumnIndex
        For Each rowS As DataGridViewRow In Me.DataGridView2.Rows
            Total1 += Convert.ToDecimal(rowS.Cells(2).Value)
            Total2 += Convert.ToDecimal(rowS.Cells(3).Value)
            Total3 += Convert.ToDecimal(rowS.Cells(4).Value)
        Next
        Me.TextBox1.Text = Math.Round(Total1, 2).ToString
        Me.TextBox2.Text = Math.Round((Total3 / Total1), 2).ToString
        Me.TextBox3.Text = Math.Round(Total3, 2).ToString

        'TextBox4.Text = DataGridView2.Item(1, 2).Value.ToString()

        Dim v_SelectRow As Integer = 1
        v_SelectRow = Me.DataGridView2.CurrentRow.Index
        TxtMetal.Text = Me.DataGridView2.Item(1, v_SelectRow).Value

        Me.BtnGuardaFundi.Enabled = True

    End Sub

    'BOTON DE CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub


#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    'ACTUALIZA DATAGRID EN TIEMPO DE EJECUCCION
    Private Sub ActualizoDatagrid()
        Dim sqlPresta As String
        Dim conn As New OleDb.OleDbConnection
        sqlPresta = "SELECT * FROM Declara WHERE consecutivo <> 0 AND verifica = '" & 0 & "' AND metal_com = 'ORO' ORDER BY consecutivo ASC"
        conn.ConnectionString = cs
        Dim adaptador As New OleDb.OleDbDataAdapter(sqlPresta, conn)
        Dim dt As New DataTable("Declara")
        adaptador.Fill(dt)

        If dt.Rows.Count > 0 Then
            DataGridView1.DataSource = dt

            '===============
            SumaDgvUno()

            'ejecutamos contador
            ContadorVentas()

            Me.TxtControlNum.Text = Me.TxtNum_com.Text

            'HABILITO LOS BOTONES
            Me.BtnPasa.Enabled = True
            Me.BtnQuita.Enabled = True

            Me.BtnTotaliza.Enabled = False
            Me.BtnNuevaFundi.Enabled = False
            Me.BtnGuardaFundi.Enabled = False
            Me.BtnImpriFundi.Enabled = False
            Me.BtnLimpia.Enabled = False

            'HABILITO EL DATAGRID
            Me.DataGridView1.Enabled = True
            Me.DataGridView2.Enabled = True

            'ACTUUALIZA SALDO INICIAL DE FUNDICION
            SaldosFundicion()


        Else
            MessageBox.Show("No hay datos que mostrar, consulte de nuevo", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.BtnNuevaFundi.Enabled = False
            Me.BtnLimpia.Enabled = True

            'ubico el cursor
            Me.BtnLimpia.Select()
            Me.BtnLimpia.Focus()
        End If

        'Dim cantRegistros As Integer = DataGridView1.Rows.Count
        'LblModReg.Text = cantRegistros
    End Sub

    '================================================
    'ACTUALIZA DATOS DEL VALOR DEL SALDO ACTUAL DE GRAMOS PUROS DE FUNDICION, DECLARA
    Private Sub SaldosFundicion()
        Dim dt As New DataTable
        Dim conn As New OleDbConnection(cs)
        Dim consulta As String = "SELECT TOP 1 * FROM Fundicion ORDER BY numdocufundi DESC"
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read() Then
            Me.Tbr.Text = drd.Item("vrsaldosbrutos").ToString
            Me.Tley.Text = drd.Item("vrsaldosley").ToString
            Me.Tpu.Text = drd.Item("vrsaldospuros").ToString

            Dim SaldoBruto, SaldoLey, SaldoPuro As Double
            SaldoBruto = Me.Tbr.Text
            SaldoLey = Me.Tley.Text
            SaldoPuro = Me.Tpu.Text

            'Me.Tbr.Text = Math.Round(SaldoBruto, 4).ToString
            'Me.Tley.Text = Math.Round(SaldoLey, 4).ToString
            'Me.Tpu.Text = Math.Round(SaldoPuro, 4).ToString

            Me.Tbr.Text = FormatNumber(SaldoBruto, 2)
            Me.Tley.Text = FormatNumber(SaldoLey, 4)
            Me.Tpu.Text = FormatNumber(SaldoPuro, 2)

        Else
            MessageBox.Show("Saldo Inicial en Cero", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Tbr.Text = 0
            Dim SaldoTbu As Double
            'Me.Tbr.Text = Format(SaldoTbu, "###,##0")
            Me.Tbr.Text = FormatNumber(SaldoTbu, 2)

            Me.Tley.Text = 0
            Dim SaldoTley As Double
            'Me.Tley.Text = Format(SaldoTley, "###,##0")
            Me.Tley.Text = FormatNumber(SaldoTley, 4)

            Me.Tpu.Text = 0
            Dim SaldoTpu As Double
            Me.Tpu.Text = Format(SaldoTpu, "###,##0")
            Me.Tpu.Text = FormatNumber(SaldoTpu, 2)

        End If
        drd.Close()
        conn.Close()

    End Sub

    'SUMA SALDO INCIAL Y SALDO FINAL
    Private Sub SumaInicialysaldoF()

        Dim SIbr, SIley, SIpu As Double
        SIbr = Me.Tbr.Text
        SIley = Me.Tley.Text
        SIpu = Me.Tpu.Text

        Dim INbr, INley, INpr As Double
        INbr = Me.TextBox1.Text
        INley = Me.TextBox2.Text
        INpr = Me.TextBox3.Text

        Try
            'SUMA LOS VALORES INICIALES CON EL INGRESO ACTUAL
            Dim TotBrutos, TotLey, Totpu As Double
            TotBrutos = SIbr + INbr
            TotLey = Totpu / TotBrutos
            Totpu = SIpu + INpr

        Catch ex As Exception
            MessageBox.Show("Error al sumar saldos, comunicarse al administrador del sistema" & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    '==================================================

    'PROCEDIDMIENTO PARA GUARDAR FUNDICION
    Private Sub GuardaData()

        'fecha creado
        Dim fechaC As Date = CDate(Format(Date.Now.Date))

        'fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        'fecha seleccionada
        Dim FechaActual As String
        FechaActual = CStr(DTPfechaactual.Value.Date)

        '1- ActFilas()
        SaveLineaPedido() ' EXCELENTE
        'PasaFilas() 'EXCELNTE AYUDA 1
        'PasaFilas1()

        'CREO VARIABLES 
        Dim comp, vent As String
        comp = "1"
        vent = "0"

        ''******************************************************************
        ''llamamos la operacion SUMAR GRAMOS BRUTOS
        'Dim FBrutos, FtotalBrutos As Double
        'FBrutos = Me.TextBox1.Text
        'FtotalBrutos = 0
        'FtotalBrutos = FBrutos + TextBox1.Text
        'FtotalBrutos = Math.Round(FBrutos, 4).ToString

        ''******************************************************************
        ''llamamos la operacion SUMAR GRAMOS PUROS
        'Dim Fpuros, FtotalPuros As Double
        'Fpuros = Me.TextBox3.Text
        'FtotalPuros = 0
        'FtotalPuros = Fpuros + TextBox3.Text
        'FtotalPuros = Math.Round(Fpuros, 4).ToString()

        ''******************************************************************
        ''llamamos la operacion SUMAR LEY
        'Dim Fley, FtotalLey As Double
        'Fley = Me.TxtDispoLey.Text
        'FtotalLey = 0
        'FtotalLey = Math.Round(FtotalPuros / FtotalBrutos, 4).ToString

        '******************************************************************
        '*** PROCESO PARA SUMAR SALDOS ***
        Dim SIbr, SIley, SIpu As Double
        SIbr = Me.Tbr.Text
        SIley = Me.Tley.Text
        SIpu = Me.Tpu.Text

        Dim INbr, INley, INpr As Double
        INbr = Me.TextBox1.Text
        INley = Me.TextBox2.Text
        INpr = Me.TextBox3.Text

        'SUMA LOS VALORES INICIALES CON EL INGRESO ACTUAL
        Dim TotBrutos, TotLey, Totpu As Double
        Totpu = SIpu + INpr
        TotBrutos = SIbr + INbr
        TotLey = Totpu / TotBrutos

        TotBrutos = Math.Round(TotBrutos, 2).ToString
        TotLey = Math.Round(TotLey, 4).ToString
        Totpu = Math.Round(Totpu, 2).ToString

        Dim agregar As OleDbCommand = New OleDbCommand("INSERT INTO fundicion (numdocufundi, fechaactualfundi, tipometal, brutosfundi, " &
                                                       "leyfundi, purosfundi, fundicompra, fundiventa, vrsaldosbrutos, vrsaldosley, " &
                                                       "vrsaldospuros, fecha_creado, fecha_modifica)  VALUES (@numdocufundi, @fechaactual, " &
                                                       "@metal_com, @brutosfundi, @leyfundi, @purosfundi, @fundicompra, @fundiventa, " &
                                                       "@vrsaldosbrutos, @vrsaldosley, @vrsaldospuros, @fecha_creado, @fecha_modifica)", conn)
        conn.Open()

        Try

            agregar.Parameters.AddWithValue("@numdocufundi", TxtNum_com.Text)
            agregar.Parameters.AddWithValue("@fechaactual", FechaActual)
            agregar.Parameters.AddWithValue("@tipometal", TxtMetal.Text)

            agregar.Parameters.AddWithValue("@brutosfundi", TextBox1.Text)
            agregar.Parameters.AddWithValue("@leyfundi", TextBox2.Text)
            agregar.Parameters.AddWithValue("@purosfundi", TextBox3.Text)

            agregar.Parameters.AddWithValue("@fundicompra", comp)
            agregar.Parameters.AddWithValue("@fundiventa", vent)

            'agregar.Parameters.AddWithValue("@vrsaldosbrutos", FtotalBrutos)
            'agregar.Parameters.AddWithValue("@vrsaldosley", FtotalLey)
            'agregar.Parameters.AddWithValue("@vrsaldospuros", FtotalPuros)

            agregar.Parameters.AddWithValue("@vrsaldosbrutos", TotBrutos)
            agregar.Parameters.AddWithValue("@vrsaldosley", TotLey)
            agregar.Parameters.AddWithValue("@vrsaldospuros", Totpu)

            agregar.Parameters.AddWithValue("@fecha_creado", fechaC)
            agregar.Parameters.AddWithValue("@fecha_modifica", fechaM)

            agregar.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("INGRESO A FUNDICIÓN, Guardado con Éxito! ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error al Guardar Ingreso.! " & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

    End Sub

    'FUNCION PARA EJECUTAR LA ACTUALIZACION
    Public Function ExecuteAction(cmd As OleDbCommand) As Integer
        If (cmd Is Nothing) Then _
             Throw New ArgumentNullException()
        Try
            Using conn As New OleDbConnection(cs)
                ' Asignamos al objeto Command el objeto Connection.
                cmd.Connection = conn
                conn.Open()
                Return cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Function

    '1- PROCEDMINETO PARA ESCOJER LAS FILAS DEL DATAGRIV SELECCIONADAS ( act la 1ra)
    Private Sub ActFilas()
        Dim very As String
        very = "1"
        Dim Num As String
        Num = Me.TxtNum_com.Text
        Using conn As New OleDbConnection(cs)
            Dim query = "UPDATE Declara SET verifica = '" & very & "', numfundi = '" & Num & "' WHERE id=@id "
            Dim cmd As New OleDbCommand(query, conn)
            'Try
            'conn.Open()
            'Recorre los campos...
            'Dim i As Integer
            'For i = 0 To DataGridView2.Rows.Count
            'For Each Row As DataGridViewRow In DataGridView2.SelectedRows
            For Each Row As DataGridViewRow In DataGridView2.Rows
                'For Each Row As DataGridViewRow In DataGridView2.Rows.OfType(Of DataGridViewRow).Where(Function(x) Not x.IsNewRow)
                'For Each row As DataGridViewCell In Me.DataGridView2.SelectedCells
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@verifica", very)
                cmd.Parameters.AddWithValue("@numfundi", Num)
                conn.Open()
                'Ejecuta la consulta
                cmd.ExecuteNonQuery()
                conn.Close()
            Next
            MessageBox.Show("Actualizadas filas seleccionadas, Correctamente.!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'End Try
        End Using

    End Sub

    '2- FUNCION PARA GUARDAR FILAS EN LA BD ( UNO POR UNO EXCELENTE POR MI)
    Private Sub SaveLineaPedido()
        Dim rowIndex As Integer = 1 'row index to update?
        Try
            For Each row As DataGridViewRow In DataGridView2.Rows
                ' Si la fila se corresponde con la fila de nuevos registros (la última fila del control DataGridView), 
                'continuamos el bucle For Each.
                If (row.IsNewRow) Then Continue For
                'Especificamos la consulta SQL que vamos a ejecutar
                Dim query As String = "UPDATE Declara SET  verifica = @verifica, numfundi = @numfundi WHERE id= @id"
                Dim cmd As New OleDbCommand(query, conn)
                cmd.Parameters.AddWithValue("@verifica", CStr(row.Cells("verifica").Value))
                cmd.Parameters.AddWithValue("@numfundi", CStr(row.Cells("numfundi").Value))
                cmd.Parameters.AddWithValue("@id", CInt(row.Cells("id").Value))
                ' Ejecutamos la consulta.
                ExecuteAction(cmd)
            Next
            ' Llegado a éste punto, se comprende que se han añadido satisfactoriamente todos los registros existentes en
            ' el control DataGridView.
            MessageBox.Show("Filas Actualizadas, Correctamente.!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ' Se ha producido un error
            MessageBox.Show("Error: " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '3- FUNCION PARA GUARDAR FILAS EN LA BD ( UNO POR UNO EXCELENTE POR AYUDA 1)
    Private Sub PasaFilas()
        '==============================================================
        Using Conn As New OleDbConnection(cs)
            Using cmd As New OleDbCommand()
                For Each row As DataGridViewRow In DataGridView2.Rows
                    sql = $"UPDATE Declara SET verifica={CStr(row.Cells(6).Value)}, numfundi={CStr(row.Cells(7).Value)} WHERE id= {CStr(row.Cells(0).Value)}"
                    cmd.CommandText = sql
                    'MsgBox(sql)
                    Try
                        cmd.Connection = Conn
                        Conn.Open()
                        cmd.ExecuteNonQuery()
                        Conn.Close()
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Conn.Close()
                Next
                Conn.Close()
            End Using
            Conn.Close()
        End Using
        conn.Close()
    End Sub

    '4- FUNCION PARA GUARDAR FILAS EN LA BD ( UNO POR UNO EXCELENTE POR AYUDA 2)
    Private Sub PasaFilas1()
        Dim lmiTransaccion As OleDbTransaction = Nothing
        Try
            Using loConexion As New OleDbConnection(cs)
                loConexion.Open()   ' abrir conexión
                'Creamos e inicimos la transaccion
                lmiTransaccion = loConexion.BeginTransaction
                'Proceso de grabación de datos
                Dim lsQuery As String = "UPDATE Declara SET verifica=@Verifica, numfundi=@Numfundi WHERE id=@Id"
                For Each loFila As DataGridViewRow In Me.DataGridView2.Rows
                    Using loComando As New OleDbCommand(lsQuery, loConexion)
                        'añadir parametros al comando 
                        loComando.Parameters.Add(New OleDbParameter("@Verifica", loFila.Cells(5).Value))
                        loComando.Parameters.Add(New OleDbParameter("@Numfundi", loFila.Cells(6).Value))
                        loComando.Parameters.Add(New OleDbParameter("@Id", loFila.Cells(0).Value))
                        loComando.Transaction = lmiTransaccion
                        loComando.ExecuteNonQuery()
                    End Using
                Next
                lmiTransaccion.Commit()
            End Using
        Catch ex As Exception
            lmiTransaccion.Rollback()
            MessageBox.Show("PasaFilas: " + ex.Message, "AppMierGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    '5- SUMAR COLUMNAS DEL DATAGRID 1
    Private Sub SumaDgvUno()
        Try
            Dim Total1, Total2, Total3 As Double
            Dim Col As Double = Me.DataGridView1.CurrentCell.ColumnIndex
            For Each rowS As DataGridViewRow In Me.DataGridView1.Rows
                Total1 += Convert.ToDecimal(rowS.Cells(13).Value)
                Total2 += Convert.ToDecimal(rowS.Cells(14).Value)
                Total3 += Convert.ToDecimal(rowS.Cells(15).Value)
            Next
            Me.TxtDispoBrutos.Text = Math.Round(Total1, 2).ToString
            Me.TxtDispoLey.Text = Math.Round((Total3 / Total1), 4).ToString
            Me.TxtDispoPuros.Text = Math.Round(Total3, 2).ToString
            '===ARREGLO
            'Me.TxtDispoBrutos.Text = FormatNumber(Total1, 2)
            'Dim LeyPasada As Double
            'LeyPasada = (Total3 / Total1)
            'Me.TxtDispoLey.Text = FormatNumber(LeyPasada, 4)
            'Me.TxtDispoPuros.Text = FormatNumber(Total3, 2)

        Catch ex As Exception
            MessageBox.Show("No Hay Valores para sumar, Saldo CERO " & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtDispoBrutos.Clear()
            Me.TxtDispoLey.Clear()
            Me.TxtDispoPuros.Clear()
        End Try
    End Sub

    '6- SUMAR COLUMNAS DEL DATAGRID 2
    Private Sub SumaDgvDos()
        Try
            Dim Total1, Total2, Total3 As Double
            Dim Col As Double = Me.DataGridView2.CurrentCell.ColumnIndex
            For Each rowS As DataGridViewRow In Me.DataGridView2.Rows
                Total1 += Convert.ToDecimal(rowS.Cells(3).Value)
                Total2 += Convert.ToDecimal(rowS.Cells(4).Value)
                Total3 += Convert.ToDecimal(rowS.Cells(5).Value)
            Next
            Me.TextBox1.Text = Math.Round(Total1, 2).ToString
            Me.TextBox2.Text = Math.Round((Total3 / Total1), 4).ToString
            Me.TextBox3.Text = Math.Round(Total3, 2).ToString
            ''===ARREGLO
            'Me.TextBox1.Text = FormatNumber(Total1, 2)
            'Dim LeyRecibida As Double
            'LeyRecibida = (Total3 / Total1)
            'Me.TextBox2.Text = FormatNumber(LeyRecibida, 4)
            'Me.TextBox3.Text = FormatNumber(Total3, 2)

        Catch ex As Exception
            MessageBox.Show("No Hay Valores para sumar, Saldo CERO" & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TextBox1.Clear()
            Me.TextBox2.Clear()
            Me.TextBox3.Clear()
        End Try

        '====================================================================


    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL DATAGRIDVIEW"

    'FORMATO DEL DATAGRIDVIEW 1
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'activo el datagrid
        Me.DataGridView1.Enabled = True

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DataGridView1.RowsDefaultCellStyle
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(0).Width = 50
            Me.DataGridView1.Columns(0).HeaderText = "Id"
            Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(2).Width = 150
            Me.DataGridView1.Columns(2).HeaderText = "Nombre Proveedor"
            Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(10).Width = 100
            Me.DataGridView1.Columns(10).HeaderText = "METAL"
            Me.DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(13).Width = 80
            Me.DataGridView1.Columns(13).HeaderText = "Gramos Brutos"
            Me.DataGridView1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(13).DefaultCellStyle.Format = "N2"

            Me.DataGridView1.Columns(14).Width = 60
            Me.DataGridView1.Columns(14).HeaderText = "Ley"
            Me.DataGridView1.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(14).DefaultCellStyle.Format = "N4"

            Me.DataGridView1.Columns(15).Width = 100
            Me.DataGridView1.Columns(15).HeaderText = "Gramos Puros"
            Me.DataGridView1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(15).DefaultCellStyle.Format = "N2"

            Me.DataGridView1.Columns(29).Width = 70
            Me.DataGridView1.Columns(29).HeaderText = "Consecutivo"
            Me.DataGridView1.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(29).DefaultCellStyle.Format = "N0"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DataGridView1.Columns("Id").Visible = True                '0
            Me.DataGridView1.Columns("cedu_com").Visible = False         '1
            Me.DataGridView1.Columns("nom_com").Visible = True           '2
            Me.DataGridView1.Columns("fecha_com").Visible = False        '3
            Me.DataGridView1.Columns("dire_com").Visible = False         '4
            Me.DataGridView1.Columns("telc_com").Visible = False         '5
            Me.DataGridView1.Columns("correo_com").Visible = False       '6
            Me.DataGridView1.Columns("dpto_com").Visible = False         '7
            Me.DataGridView1.Columns("rut_com").Visible = False          '8
            Me.DataGridView1.Columns("act_com").Visible = False          '9
            Me.DataGridView1.Columns("metal_com").Visible = True       '10
            Me.DataGridView1.Columns("conce_com").Visible = False       '11
            Me.DataGridView1.Columns("ciuddpto").Visible = False        '12
            Me.DataGridView1.Columns("grbrutos").Visible = True         '13
            Me.DataGridView1.Columns("ley").Visible = True              '14
            Me.DataGridView1.Columns("grpuros").Visible = True          '15
            Me.DataGridView1.Columns("base").Visible = False            '16
            Me.DataGridView1.Columns("regala").Visible = False          '17
            Me.DataGridView1.Columns("totalretef").Visible = False      '18
            Me.DataGridView1.Columns("vrventa").Visible = False         '19
            Me.DataGridView1.Columns("fechatasa").Visible = False       '20
            Me.DataGridView1.Columns("mestasa").Visible = False         '21
            Me.DataGridView1.Columns("retevalor").Visible = False       '22
            Me.DataGridView1.Columns("gp_rg").Visible = False           '23
            Me.DataGridView1.Columns("gp_base").Visible = False         '24
            Me.DataGridView1.Columns("valorgrrete").Visible = False     '25
            Me.DataGridView1.Columns("pagobare").Visible = False        '26
            Me.DataGridView1.Columns("mes_com").Visible = False         '27
            Me.DataGridView1.Columns("año_com").Visible = False         '28
            Me.DataGridView1.Columns("consecutivo").Visible = True      '29
            Me.DataGridView1.Columns("fecha_creado").Visible = False    '30
            Me.DataGridView1.Columns("fecha_modifica").Visible = False  '31
            Me.DataGridView1.Columns("letras").Visible = False          '32
            Me.DataGridView1.Columns("detallemineral").Visible = False  '33
            Me.DataGridView1.Columns("verifica").Visible = False        '34
            Me.DataGridView1.Columns("numfundi").Visible = False        '35
            Me.DataGridView1.Columns("formapago").Visible = False       '36
            Me.DataGridView1.Columns("numtarjeta").Visible = False      '37
            Me.DataGridView1.Columns("selebancos").Visible = False      '38
            Me.DataGridView1.Columns("prefijo").Visible = False         '39
            Me.DataGridView1.Columns("conseQr").Visible = False         '40
            Me.DataGridView1.Columns("tipoop").Visible = False          '41
            Me.DataGridView1.Columns("tipodocu").Visible = False        '42
            Me.DataGridView1.Columns("comOro").Visible = False           '43
            Me.DataGridView1.Columns("comPlatino").Visible = False      '44
            Me.DataGridView1.Columns("comPlata").Visible = False        '45
            Me.DataGridView1.Columns("ciudad").Visible = False          '46
            Me.DataGridView1.Columns("dpto").Visible = False            '47

        End With

    End Sub

    'CREA LOS DATOS DEL DATAGRID 2
    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        'DEJO QUE LAS FILAS SEAN SELCCIONADAS POR EL USUARIO Y CONTINUA CON EL BOTON
        If ((DataGridView2.CurrentRow Is Nothing) OrElse (DataGridView2.SelectedRows.Count <> 0)) Then
            Me.BtnTotaliza.Enabled = True
        Else
            Me.BtnTotaliza.Enabled = False
        End If

    End Sub

#End Region

#Region "CONTADORES PARA AMBOS CONCEPTOS"

    'CONTADOR
    Function ContadorVentas()
        Dim conT As String
        conT = TxtCuenta.Text
        UltimoIdIngreso()
        Me.TxtNum_com.Text = UltimoIdIngreso()
        Return conT
    End Function

    'para encontrar el valor máximo de una columna y ultimo registro
    Public Function UltimoIdIngreso() As String
        conn.Close()
        Dim resultado As String
        resultado = 0
        Dim query As String = "SELECT MAX(numdocufundi) FROM fundicion"
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