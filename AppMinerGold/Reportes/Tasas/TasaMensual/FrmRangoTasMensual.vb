Public Class FrmRangoTasMensual

    'CARGUE DEL FORMULARIO
    Private Sub FrmRangoTasMensual_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'actualizo la fecha en los calendarios
        DTPinicial.Value = Date.Now.ToString("d")
        DTPfinal.Value = Date.Now.ToString("d")

        'habilito el boton 
        Me.BtnConsu.Enabled = True
        Me.BtnImpTD.Enabled = False
        Me.BtnLimpia.Enabled = False
        Me.BtnRegresa.Enabled = True

        'limpio  el label
        Me.LblModReg.Text = ""

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE IMPRIMIR REPORTE POR RANGO DE FECHAS
    Private Sub BtnConsu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsu.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        'llamo el procedimiento
        LLenaTasaMensual()

        'inhabilito el boton
        Me.BtnConsu.Enabled = False
        Me.BtnImpTD.Enabled = True
        Me.BtnLimpia.Enabled = True
        Me.BtnRegresa.Enabled = True
        Me.DTPinicial.Enabled = False
        Me.DTPfinal.Enabled = False

        'manejo del cursor
        Me.Cursor = Cursors.Default

    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpia_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpia.Click

        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        'ubico el cursor
        Me.DTPinicial.Enabled = True
        Me.DTPfinal.Enabled = True
        Me.DTPinicial.Text = ""
        Me.DTPinicial.Focus()

        'habilitamos el boton
        Me.BtnConsu.Enabled = True
        Me.BtnImpTD.Enabled = False
        Me.BtnLimpia.Enabled = False
        Me.BtnRegresa.Enabled = True

        'limpio  el label
        Me.LblModReg.Text = ""

        'actualizo la fecha en los calendarios
        DTPinicial.Value = Date.Now.ToString("d")
        DTPfinal.Value = Date.Now.ToString("d")

    End Sub

    'BOTON DE REGRESAR
    Private Sub BtnRegresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegresa.Click

        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        Me.Close()

        FrmSecretaria.Show()

        'manejo del cursor
        Me.Cursor = Cursors.Default

    End Sub

#End Region

    'FUNCION QUE FILTRA LOS DATOS ENTRE FECHAS
    Private Sub LLenaTasaMensual()
        Dim sqlBusca As String
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
        sqlBusca = "SELECT detalle, descri, año, fecha_creado FROM regalias WHERE fecha_creado BETWEEN @starDate AND @enddate ORDER BY fecha_creado ASC"
        conn.ConnectionString = cs
        Dim da As New OleDb.OleDbDataAdapter(sqlBusca, conn)
        With da.SelectCommand.Parameters
            .AddWithValue("@starDate", hugh)
            .AddWithValue("@endDate", hugh2)
        End With
        Dim dt As New DataTable("regalias")
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            DataGridView1.DataSource = dt
            'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
            With DataGridView1.RowsDefaultCellStyle
                Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(0).Width = 130
                Me.DataGridView1.Columns(0).HeaderText = "Valor Tasa Mensual"
                Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(0).DefaultCellStyle.Format = "C2"

                Me.DataGridView1.Columns(1).Width = 130
                Me.DataGridView1.Columns(1).HeaderText = "Mes"
                Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(2).Width = 100
                Me.DataGridView1.Columns(2).HeaderText = "Año"
                Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(3).Width = 140
                Me.DataGridView1.Columns(3).HeaderText = "Fecha de Creación"
                Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
            DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.RowCount - 1).Cells(0)
        Else
            MsgBox("No hay informacion que mostrar, consulte de nuevo", MsgBoxStyle.Information, "AppMinerGold")
            'inhabilito el boton
            Me.BtnConsu.Enabled = False
            Me.BtnImpTD.Enabled = True
            Me.BtnLimpia.Enabled = True
            Me.BtnRegresa.Enabled = True
            Me.DTPinicial.Enabled = False
            Me.DTPfinal.Enabled = False
            'ubico el cursor
            Me.BtnLimpia.Select()
            Me.BtnLimpia.Focus()
        End If

        'Inhabilito el datagrig para ediccion
        Me.DataGridView1.Enabled = True

        'muestro la cantidad de registros encontrados
        LblModReg.Text = dt.Rows.Count

        'inhabilito el boton
        Me.BtnConsu.Enabled = False

    End Sub

    'BOTON DE  IMPRIMIR
    Private Sub BtnImpTD_Click(sender As Object, e As EventArgs) Handles BtnImpTD.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        FrmRptTasaMensual.TextBox1.Text = Me.DTPinicial.Value
        FrmRptTasaMensual.TextBox2.Text = Me.DTPfinal.Value
        FrmRptTasaMensual.Show()

        'manejo del cursor
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub
End Class