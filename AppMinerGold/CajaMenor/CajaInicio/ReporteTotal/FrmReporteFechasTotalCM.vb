Public Class FrmReporteFechasTotalCM

    'CARGUE DEL FORMULARIO
    Private Sub FrmReporteFechasAse1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'actualizo la fecha en los calendarios
        Me.DTPinicialCaja.Value = Date.Now.ToString("d")
        Me.DTPfinalCaja.Value = Date.Now.ToString("d")

        'inhabilito el boron
        Me.BtnImpri.Enabled = False

        'habilito el boton 
        Me.BtnConsu.Enabled = True

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE IMPRIMIR REPORTE POR RANGO DE FECHAS
    Private Sub BtnConsu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsu.Click

        'llamo el procedimiento
        LlenaGridCajamenorAse1()

        'inhabilito el boton
        Me.BtnConsu.Enabled = False

        'hanilito el boton
        Me.BtnImpri.Enabled = True
        Me.BtnLimpia.Enabled = True

        'ubico el cursor
        Me.BtnImpri.Select()
        Me.BtnImpri.Focus()

    End Sub

    'BOTON DE IMPRIMIR
    Private Sub BtnImpri_Click(sender As System.Object, e As System.EventArgs) Handles BtnImpri.Click
        FrmSeleccionaReporte.ShowDialog()
    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpia_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpia.Click

        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        'ubico el cursor
        Me.DTPinicialCaja.Enabled = True
        Me.DTPinicialCaja.Text = ""
        Me.DTPinicialCaja.Focus()

        'habilitamos el boton
        Me.BtnConsu.Enabled = True
        Me.BtnImpri.Enabled = True
        Me.BtnLimpia.Enabled = True

        'limpio  el label
        Me.LblModReg.Text = ""

        'inhabilito el boron
        Me.BtnImpri.Enabled = False

        'habilito el boton 
        Me.BtnConsu.Enabled = True

        'actualizo la fecha en los calendarios
        DTPinicialCaja.Value = Date.Now.ToString("d")
        DTPfinalCaja.Value = Date.Now.ToString("d")

    End Sub


#End Region

#Region "PROCEDIMIENTO PARA CONSULTAR FECHAS"

    'CONSULTAR EL RANGO DE FECHAS Y MOSTRAR DATOS EN DATAGRID
    Private Sub LlenaGridCajamenorAse1()
        Dim sqlBusca As String
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicialCaja.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinalCaja.Value.Date)  '= DTP_FechaI.Value.Date
        sqlBusca = "SELECT * FROM CajamenorAse1 WHERE fechaactual_pre BETWEEN @starDate AND @enddate ORDER BY id ASC"
        conn.ConnectionString = cs
        Dim da As New OleDb.OleDbDataAdapter(sqlBusca, conn)
        With da.SelectCommand.Parameters
            .AddWithValue("@starDate", hugh)
            .AddWithValue("@endDate", hugh2)
        End With
        Dim dt As New DataTable("CajamenorAse1")
        da.Fill(dt)
        DataGridView1.DataSource = dt

        'Inhabilito el datagrig para ediccion
        Me.DataGridView1.Enabled = False

        'muestro la cantidad de registros encontrados
        LblModReg.Text = dt.Rows.Count

        'inhabilito el boton
        Me.BtnConsu.Enabled = False

    End Sub

#End Region

    'FORMATO DEL DATADRIG 
    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'activo el datagrid
        Me.DataGridView1.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DataGridView1.EnableHeadersVisualStyles = False
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'UBICO LA ULTIMA FILA, Scroll to the last row
        'DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.Rows.Count - 1
        'DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DataGridView1.RowsDefaultCellStyle
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(0).Width = 40
            Me.DataGridView1.Columns(0).HeaderText = "Id"
            Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(1).Width = 80
            Me.DataGridView1.Columns(1).HeaderText = "Cédula del Cliente"
            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(2).Width = 150
            Me.DataGridView1.Columns(2).HeaderText = "Nombre del Cliente"
            Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(3).Width = 90
            Me.DataGridView1.Columns(3).HeaderText = "Fecha del Ingreso"
            Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(4).Width = 70
            Me.DataGridView1.Columns(4).HeaderText = "No. Doc. Ingreso"
            Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(8).Width = 90
            Me.DataGridView1.Columns(8).HeaderText = "Valor del Ingreso"
            Me.DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(8).DefaultCellStyle.Format = "c"

            Me.DataGridView1.Columns(10).Width = 90
            Me.DataGridView1.Columns(10).HeaderText = "Fecha del Egreso"
            Me.DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(11).Width = 80
            Me.DataGridView1.Columns(11).HeaderText = "No. Doc. Egreso"
            Me.DataGridView1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(9).Width = 100
            Me.DataGridView1.Columns(9).HeaderText = "Valor del Egreso"
            Me.DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(9).DefaultCellStyle.Format = "c"

            Me.DataGridView1.Columns(14).Width = 100
            Me.DataGridView1.Columns(14).HeaderText = "Valor Saldo"
            Me.DataGridView1.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(14).DefaultCellStyle.Format = "c"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DataGridView1.Columns("conce_pre").Visible = False
            Me.DataGridView1.Columns("nomciud").Visible = False
            Me.DataGridView1.Columns("nompagado").Visible = False
            Me.DataGridView1.Columns("conce_pago").Visible = False
            Me.DataGridView1.Columns("cedupagado").Visible = False

            Me.DataGridView1.Columns("fecha_creado").Visible = False
            Me.DataGridView1.Columns("fecha_modifica").Visible = False

        End With

    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class