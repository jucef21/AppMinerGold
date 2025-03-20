Public Class FrmConsultaCompOroPlata

    'CARGUE DEL FORM
    Private Sub FrmConsultaCompOroPlata_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'actualizo la fecha en los calendarios
        'DTPinicial.Value = Date.Now.ToString("d")
        'DTPfinal.Value = Date.Now.ToString("d")

        'actualizo la fecha en los calendarios
        Dim dtFecha As Date = DateSerial(Year(Date.Today), 1, 1)
        Me.DTPinicial.Value = dtFecha
        Me.DTPfinal.Value = Date.Today

        'habilito el boton 
        Me.BtnBuscar.Enabled = True
        Me.BtnImprimir.Enabled = False
        Me.BtnLimpiar.Enabled = False

        'limpio  el label
        Me.LblModReg.Text = ""

        '======================
        'ubico el cursor
        Me.Panel4.Select()
        Me.GroupBox1.Select()
        Me.DTPinicial.Select()
        Me.DTPinicial.Focus()

        Me.TxtGrBrutosC.Clear()
        Me.TxtLey.Clear()
        Me.TxtPuros.Clear()
        Me.TxtPlata.Clear()

        Me.TotalBrutos.Clear()
        Me.TotalPuros.Clear()

        'INCIAR EL DATAGRID LIMPIO DESPUES DE CUALQUIER CONSULTA
        'para limpiar las filas
        Try
            If DataGridView1.RowCount >= 1 Then
                For i As Integer = 0 To DataGridView1.RowCount - 1
                    DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
                Next
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        'para limpiar cualquier registro internamente y desenlazar el control de la BD
        DataGridView1.DataSource = Nothing

        'Inhabilito las fechas
        Me.Panel1.Enabled = True
        Me.Panel2.Enabled = True

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE IMPRIMIR REPORTE POR RANGO DE FECHAS
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        'llamo el procedimiento
        LLenaCompras()

        'inhabilito el boton
        Me.BtnBuscar.Enabled = False
        Me.DTPinicial.Enabled = False
        Me.DTPfinal.Enabled = False
        Me.BtnImprimir.Enabled = True
        Me.BtnLimpiar.Enabled = True

        'manejo del cursor
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        Me.TxtGrBrutosC.Clear()
        Me.TxtLey.Clear()
        Me.TxtPuros.Clear()
        Me.TxtPlata.Clear()

        Me.TotalBrutos.Clear()
        Me.TotalPuros.Clear()

        'ubico el cursor
        Me.Panel4.Select()
        Me.GroupBox1.Select()
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True
        Me.BtnImprimir.Enabled = False

        Me.DTPinicial.Enabled = True
        Me.DTPfinal.Enabled = True

        'limpio  el label
        Me.LblModReg.Text = ""

        'actualizo la fecha en los calendarios
        Dim dtFecha As Date = DateSerial(Year(Date.Today), 1, 1)
        Me.DTPinicial.Value = dtFecha
        Me.DTPfinal.Value = Date.Today

        'Inhabilito las fechas
        Me.Panel1.Enabled = True
        Me.Panel2.Enabled = True

        'ubico el cursor
        Me.Panel4.Select()
        Me.GroupBox1.Select()
        Me.DTPinicial.Select()
        Me.DTPinicial.Focus()

    End Sub

    'BOTON DE  IMPRIMIR
    Private Sub BtnImpAse1_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        'manejo de cursor
        Me.Cursor = Cursors.WaitCursor
        FrmLiquidaCompraOroPlata.TextBox1.Text = Me.DTPinicial.Text
        FrmLiquidaCompraOroPlata.TextBox2.Text = Me.DTPfinal.Text
        FrmLiquidaCompraOroPlata.TxtMetales.Text = Me.TxtMetal.Text
        FrmLiquidaCompraOroPlata.Show()
        'manejo de cursor
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCESOS DEL FORMULARIO"

    'FUNCION QUE FILTRA LOS DATOS ENTRE FECHAS
    Private Sub LLenaCompras()
        Dim metal As String = "ORO"
        Dim metal1 As String = " ORO"
        Dim sqlBusca As String
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
        Dim ANU As String = "ANULADO"
        sqlBusca = "SELECT cedu_com, nom_com, fecha_com, metal_com, grbrutos, ley, grpuros, vrventa, mes_com, año_com, consecutivo, fecha_creado FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND metal_com = '" & metal & "' AND nom_com <> '" & ANU & "' ORDER BY consecutivo ASC"
        conn.ConnectionString = cs
        Dim da As New OleDb.OleDbDataAdapter(sqlBusca, conn)
        With da.SelectCommand.Parameters
            .AddWithValue("@starDate", hugh)
            .AddWithValue("@endDate", hugh2)
        End With
        Dim dt As New DataTable("Declara")
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            DataGridView1.DataSource = dt
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With DataGridView1.RowsDefaultCellStyle
                Me.DataGridView1.Columns(0).Width = 70
                Me.DataGridView1.Columns(0).HeaderText = "Cédula Proveedor"
                Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Me.DataGridView1.Columns(1).Width = 240
                Me.DataGridView1.Columns(1).HeaderText = "Nombre Completo"
                Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                Me.DataGridView1.Columns(2).Width = 100
                Me.DataGridView1.Columns(2).HeaderText = "Fecha de Compra"
                Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(3).Width = 100
                Me.DataGridView1.Columns(3).HeaderText = "Metal"
                Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(4).Width = 80
                Me.DataGridView1.Columns(4).HeaderText = "Gramos Brutos"
                Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(4).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(5).Width = 60
                Me.DataGridView1.Columns(5).HeaderText = "Ley"
                Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(5).DefaultCellStyle.Format = "N4"

                Me.DataGridView1.Columns(6).Width = 80
                Me.DataGridView1.Columns(6).HeaderText = "Gramos puros"
                Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(6).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(7).Width = 150
                Me.DataGridView1.Columns(7).HeaderText = "Valor de Compra"
                Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView1.Columns(7).DefaultCellStyle.Format = "C2"

                Me.DataGridView1.Columns(8).Width = 100
                Me.DataGridView1.Columns(8).HeaderText = "Mes de Compra"
                Me.DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(9).Width = 100
                Me.DataGridView1.Columns(9).HeaderText = "Año de Compra"
                Me.DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(10).Width = 100
                Me.DataGridView1.Columns(10).HeaderText = "Consecutivo"
                Me.DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(11).Width = 100
                Me.DataGridView1.Columns(11).HeaderText = "Fecha Creación"
                Me.DataGridView1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With

            'VERIFICA SI HAY DIAS EN VACIO O SIN OPRACION DE UNA DATAGRIDVIEW
            'SUMA GRAMOS PUROS
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dtl As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultado As Object = dtl.Compute("Sum(grpuros)", Nothing)
            TxtPuros.Text = String.Format("{0:N2}", resultado)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultado = dtl.Compute("Sum(grpuros)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            TotalPuros.Text = String.Format("{0:N2}", resultado)

            'SUMA GRAMOS BRUTOS
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dtB As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultadoB As Object = dtB.Compute("Sum(grbrutos)", Nothing)
            Me.TxtGrBrutosC.Text = String.Format("{0:N2}", resultadoB)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultadoB = dtB.Compute("Sum(grbrutos)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            TotalBrutos.Text = String.Format("{0:N2}", resultadoB)

            Dim resultadoL As Double
            resultadoL = (resultado / resultadoB)
            Me.TxtLey.Text = FormatNumber(resultadoL, 4)

            Dim resultadoP As Double
            resultadoP = (resultadoB - resultado)
            Me.TxtPlata.Text = FormatNumber(resultadoP, 2)

            ''Sumar una Columna VALOR CANCELADO
            '' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            'Dim dt1 As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            '' Sumamos todas las filas de la columna TotalFactura.
            'Dim resultado1 As Object = dt1.Compute("Sum(vrventa)", Nothing)
            'TextBox2.Text = String.Format("{0:N2}", resultado1)
            '' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            'resultado1 = dt1.Compute("Sum(vrventa)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            ''TextBox3.Text = String.Format("{0:N2}", resultado1)

            'inhabilito el boton
            Me.BtnBuscar.Enabled = False
            Me.BtnImprimir.Enabled = True
            Me.BtnLimpiar.Enabled = True


        Else
            MsgBox("No hay informacion que mostrar, consulte de nuevo", MsgBoxStyle.Information, "AppMinerGold")
            'inhabilito el boton
            Me.BtnBuscar.Enabled = False
            Me.BtnImprimir.Enabled = False
            Me.BtnLimpiar.Enabled = True

            'ubico el cursor
            Me.BtnLimpiar.Select()
            Me.BtnLimpiar.Focus()
        End If

        'Inhabilito el datagrig para ediccion
        Me.DataGridView1.Enabled = True

        'muestro la cantidad de registros encontrados
        LblModReg.Text = dt.Rows.Count

    End Sub

#End Region


End Class