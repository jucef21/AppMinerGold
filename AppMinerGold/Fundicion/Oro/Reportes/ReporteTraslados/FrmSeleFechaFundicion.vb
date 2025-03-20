Public Class FrmSeleFechaFundicion

    'CARGUE DEL FORMULARIO
    Private Sub FrmSeleFechaFundicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'actualizo la fecha en los calendarios
        DTPinicial.Value = Date.Now.ToString("d")
        DTPfinal.Value = Date.Now.ToString("d")

        'habilito el boton 
        Me.BtnConsu.Enabled = True
        Me.BtnImpTD.Enabled = False
        Me.BtnLimpia.Enabled = False

        'limpio  el label
        Me.LblModReg.Text = ""

        '======================
        Me.TextBox2.Clear()

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE IMPRIMIR REPORTE POR RANGO DE FECHAS
    Private Sub BtnConsu_Click(sender As Object, e As EventArgs) Handles BtnConsu.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        'llamo el procedimiento
        LLenaFundicion()

        'inhabilito el boton
        Me.BtnConsu.Enabled = False
        Me.BtnImpTD.Enabled = True
        Me.BtnLimpia.Enabled = True

        Me.BtnLimpia.Select()
        Me.BtnLimpia.Focus()

        'manejo del cursor
        Me.Cursor = Cursors.Default

    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpia_Click(sender As Object, e As EventArgs) Handles BtnLimpia.Click

        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        Me.TextBox2.Clear()

        'ubico el cursor
        Me.DTPinicial.Enabled = True
        Me.DTPinicial.Text = ""
        Me.DTPinicial.Focus()

        'habilitamos el boton
        Me.BtnConsu.Enabled = True
        Me.BtnImpTD.Enabled = False
        Me.BtnLimpia.Enabled = False

        'limpio  el label
        Me.LblModReg.Text = ""

        'actualizo la fecha en los calendarios
        DTPinicial.Value = Date.Now.ToString("d")
        DTPfinal.Value = Date.Now.ToString("d")

    End Sub

#End Region

    'FUNCION QUE FILTRA LOS DATOS ENTRE FECHAS
    Private Sub LLenaFundicion()
        Dim sqlBusca As String
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
        sqlBusca = "SELECT * FROM Fundicion WHERE fecha_creado BETWEEN @starDate AND @enddate AND tipometal = 'ORO'"
        conn.ConnectionString = cs
        Dim da As New OleDb.OleDbDataAdapter(sqlBusca, conn)
        With da.SelectCommand.Parameters
            .AddWithValue("@starDate", hugh)
            .AddWithValue("@endDate", hugh2)
        End With
        Dim dt As New DataTable("Fundicion")
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            DataGridView1.DataSource = dt
        Else
            MessageBox.Show("No hay informacion que mostrar, consulte de nuevo", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'inhabilito el boton
            Me.BtnConsu.Enabled = False
            Me.BtnImpTD.Enabled = False
            Me.BtnLimpia.Enabled = True

            Me.DTPinicial.Enabled = False
            Me.DTPfinal.Enabled = False

            'ubico el cursor
            Me.BtnLimpia.Select()
            Me.BtnLimpia.Focus()
        End If

        'Inhabilito el datagrig para ediccion
        Me.DataGridView1.Enabled = False

        'muestro la cantidad de registros encontrados
        LblModReg.Text = dt.Rows.Count

        'inhabilito el boton
        Me.BtnConsu.Enabled = False


    End Sub

    'FORMATO DEL DATADRIG 
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'activo el datagrid
        Me.DataGridView1.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DataGridView1.EnableHeadersVisualStyles = False
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DataGridView1.RowsDefaultCellStyle
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(0).Width = 30
            Me.DataGridView1.Columns(0).HeaderText = "Id"
            Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(1).Width = 80
            Me.DataGridView1.Columns(1).HeaderText = "No. de Fundición"
            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(2).Width = 80
            Me.DataGridView1.Columns(2).HeaderText = "Fecha de Fundición"
            Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(4).Width = 100
            Me.DataGridView1.Columns(4).HeaderText = "Gramos Brutos"
            Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(4).DefaultCellStyle.Format = "N2"

            Me.DataGridView1.Columns(5).Width = 70
            Me.DataGridView1.Columns(5).HeaderText = "Ley"
            Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(5).DefaultCellStyle.Format = "N4"

            Me.DataGridView1.Columns(6).Width = 100
            Me.DataGridView1.Columns(6).HeaderText = "Gramos Puros"
            Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(6).DefaultCellStyle.Format = "N2"

            Me.DataGridView1.Columns(3).Width = 80
            Me.DataGridView1.Columns(3).HeaderText = "Material"
            Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DataGridView1.Columns("Id").Visible = True                   '0
            Me.DataGridView1.Columns("numdocufundi").Visible = True         '1
            Me.DataGridView1.Columns("fechaactualfundi").Visible = True     '2
            Me.DataGridView1.Columns("tipometal").Visible = True            '3
            Me.DataGridView1.Columns("brutosfundi").Visible = True          '4
            Me.DataGridView1.Columns("leyfundi").Visible = True             '5
            Me.DataGridView1.Columns("purosfundi").Visible = True           '6
            Me.DataGridView1.Columns("fundicompra").Visible = False         '7
            Me.DataGridView1.Columns("fundiventa").Visible = False          '8
            Me.DataGridView1.Columns("vrsaldosbrutos").Visible = False      '9
            Me.DataGridView1.Columns("vrsaldosley").Visible = False         '10
            Me.DataGridView1.Columns("vrsaldospuros").Visible = False       '11
            Me.DataGridView1.Columns("fecha_creado").Visible = False        '12
            Me.DataGridView1.Columns("fecha_modifica").Visible = False      '13

        End With

    End Sub

    'BOTON DE  IMPRIMIR
    Private Sub BtnImpAse1_Click(sender As Object, e As EventArgs) Handles BtnImpTD.Click
        Me.Cursor = Cursors.WaitCursor
        FrmTrasladosdeFundicion.TxtFechaIni.Text = Me.DTPinicial.Text
        FrmTrasladosdeFundicion.TxtFechaFin.Text = Me.DTPfinal.Text
        FrmTrasladosdeFundicion.Show()
        Me.BtnImpTD.Enabled = False
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class