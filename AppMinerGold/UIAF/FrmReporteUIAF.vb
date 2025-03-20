Public Class FrmReporteUIAF

    'CARGUE DEL FORMULARIO
    Private Sub FrmReporteUIAF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'actualizo la fecha en los calendarios
        Me.DTPinicial.Value = Date.Now.ToString("d")
        Me.DTPfinal.Value = Date.Now.ToString("d")

        'inhabilito el boron
        Me.BtnImpri.Enabled = False

        'habilito el boton 
        Me.BtnConsu.Enabled = True
    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE IMPRIMIR REPORTE POR RANGO DE FECHAS
    Private Sub BtnConsu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsu.Click

        'llamo el procedimiento
        LlenaGridDeclara()

        'inhabilito el boton
        Me.BtnConsu.Enabled = False

        'hanilito el boton
        Me.BtnImpri.Enabled = True
        Me.BtnLimpia.Enabled = True
        Me.BtnSalirCaja.Enabled = True

        'ubico el cursor
        Me.BtnImpri.Select()
        Me.BtnImpri.Focus()

    End Sub

    'BOTON DE IMPRIMIR
    Private Sub BtnImpri_Click(sender As System.Object, e As System.EventArgs) Handles BtnImpri.Click
        Me.Cursor = Cursors.WaitCursor
        FrmUIAFrpt.TextBox1.Text = Me.DTPinicial.Value
        FrmUIAFrpt.TextBox2.Text = Me.DTPfinal.Value
        FrmUIAFrpt.Show()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpia_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpia.Click

        'limpio el datagrid
        DGVrptUiaf.ClearSelection()
        DGVrptUiaf.DataSource = Nothing
        DGVrptUiaf.Columns.Clear()

        'ubico el cursor
        Me.DTPinicial.Enabled = True
        Me.DTPinicial.Text = ""
        Me.DTPinicial.Focus()

        'habilitamos el boton
        Me.BtnConsu.Enabled = True
        Me.BtnImpri.Enabled = True
        Me.BtnLimpia.Enabled = True
        Me.BtnSalirCaja.Enabled = True

        'limpio  el label
        Me.LblModReg.Text = ""

        'inhabilito el boron
        Me.BtnImpri.Enabled = False

        'habilito el boton 
        Me.BtnConsu.Enabled = True

        'actualizo la fecha en los calendarios
        DTPinicial.Value = Date.Now.ToString("d")
        DTPfinal.Value = Date.Now.ToString("d")

    End Sub

    'BOTON DE REGRESAR
    Private Sub BtnSalirCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalirCaja.Click

        'limpio el datagrid
        DGVrptUiaf.ClearSelection()
        DGVrptUiaf.DataSource = Nothing
        DGVrptUiaf.Columns.Clear()

        'ubico el cursor
        Me.DTPinicial.Enabled = True
        Me.DTPinicial.Text = ""
        Me.DTPinicial.Focus()

        'habilitamos el boton
        Me.BtnConsu.Enabled = True
        Me.BtnImpri.Enabled = True
        Me.BtnLimpia.Enabled = True
        Me.BtnSalirCaja.Enabled = True

        'limpio  el label
        Me.LblModReg.Text = ""

        'inhabilito el boton
        Me.BtnImpri.Enabled = False

        'habilito el boton 
        Me.BtnConsu.Enabled = True

        'cierro el formualrio
        Me.Close()

    End Sub

    'BOTON DE CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCEDIMIENTO PARA CONSULTAR FECHAS"

    'CONSULTAR EL RANGO DE FECHAS Y MOSTRAR DATOS EN DATAGRID
    Private Sub LlenaGridDeclara()
        Dim sqlBusca As String
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
        Dim ANU As String = "ANULADO"
        sqlBusca = "SELECT * FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND nom_com <> '" & ANU & "' ORDER BY consecutivo ASC"
        conn.ConnectionString = cs
        Dim da As New OleDb.OleDbDataAdapter(sqlBusca, conn)
        With da.SelectCommand.Parameters
            .AddWithValue("@starDate", hugh)
            .AddWithValue("@endDate", hugh2)
        End With
        Dim dt As New DataTable("Declara")
        da.Fill(dt)
        DGVrptUiaf.DataSource = dt

        'Inhabilito el datagrig para ediccion
        Me.DGVrptUiaf.Enabled = False

        'muestro la cantidad de registros encontrados
        LblModReg.Text = dt.Rows.Count

        'inhabilito el boton
        Me.BtnConsu.Enabled = False
    End Sub


#End Region

    'FORMATO DEL DATADRIG 
    Private Sub DGVrptUiaf_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVrptUiaf.CellFormatting

        'activo el datagrid
        Me.DGVrptUiaf.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVrptUiaf.EnableHeadersVisualStyles = False
        With DGVrptUiaf.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVrptUiaf.RowsDefaultCellStyle
            Me.DGVrptUiaf.Columns(0).Width = 70
            Me.DGVrptUiaf.Columns(0).HeaderText = "Id"
            Me.DGVrptUiaf.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVrptUiaf.Columns(1).Width = 80
            Me.DGVrptUiaf.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DGVrptUiaf.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVrptUiaf.Columns(2).Width = 240
            Me.DGVrptUiaf.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVrptUiaf.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVrptUiaf.Columns(3).Width = 100
            Me.DGVrptUiaf.Columns(3).HeaderText = "Fecha de Compra"
            Me.DGVrptUiaf.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVrptUiaf.Columns(13).Width = 150
            Me.DGVrptUiaf.Columns(13).HeaderText = "Gramos Brutos"
            Me.DGVrptUiaf.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVrptUiaf.Columns(13).DefaultCellStyle.Format = "N2"

            Me.DGVrptUiaf.Columns(14).Width = 150
            Me.DGVrptUiaf.Columns(14).HeaderText = "Ley"
            Me.DGVrptUiaf.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVrptUiaf.Columns(14).DefaultCellStyle.Format = "N2"

            Me.DGVrptUiaf.Columns(15).Width = 150
            Me.DGVrptUiaf.Columns(15).HeaderText = "Gramos Puros"
            Me.DGVrptUiaf.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVrptUiaf.Columns(15).DefaultCellStyle.Format = "N2"

            Me.DGVrptUiaf.Columns(16).Width = 150
            Me.DGVrptUiaf.Columns(16).HeaderText = "Precio Base"
            Me.DGVrptUiaf.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVrptUiaf.Columns(16).DefaultCellStyle.Format = "N2"

            Me.DGVrptUiaf.Columns(17).Width = 150
            Me.DGVrptUiaf.Columns(17).HeaderText = "Valor Gr Regalias"
            Me.DGVrptUiaf.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVrptUiaf.Columns(17).DefaultCellStyle.Format = "N2"

            Me.DGVrptUiaf.Columns(18).Width = 150
            Me.DGVrptUiaf.Columns(18).HeaderText = "Valor Retefuente"
            Me.DGVrptUiaf.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVrptUiaf.Columns(18).DefaultCellStyle.Format = "N2"

            Me.DGVrptUiaf.Columns(19).Width = 150
            Me.DGVrptUiaf.Columns(19).HeaderText = "Valor Venta"
            Me.DGVrptUiaf.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVrptUiaf.Columns(19).DefaultCellStyle.Format = "N2"

            Me.DGVrptUiaf.Columns(29).Width = 150
            Me.DGVrptUiaf.Columns(29).HeaderText = "Consecutivo"
            Me.DGVrptUiaf.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVrptUiaf.Columns("Id").Visible = False              '0
            'Me.DGVrptUiaf.Columns("cedu_com").Visible = False        '1
            'Me.DGVrptUiaf.Columns("nom_com").Visible = False         '2
            'Me.DGVrptUiaf.Columns("fecha_com").Visible = False       '3
            Me.DGVrptUiaf.Columns("dire_com").Visible = False         '4
            Me.DGVrptUiaf.Columns("telc_com").Visible = False         '5
            Me.DGVrptUiaf.Columns("correo_com").Visible = False       '6
            Me.DGVrptUiaf.Columns("dpto_com").Visible = False         '7
            Me.DGVrptUiaf.Columns("rut_com").Visible = False          '8
            Me.DGVrptUiaf.Columns("act_com").Visible = False          '9
            Me.DGVrptUiaf.Columns("metal_com").Visible = False       '10
            Me.DGVrptUiaf.Columns("conce_com").Visible = False       '11
            Me.DGVrptUiaf.Columns("ciuddpto").Visible = False        '12
            'Me.DGVrptUiaf.Columns("grbrutos").Visible = False        '13
            'Me.DGVrptUiaf.Columns("ley").Visible = False             '14
            'Me.DGVrptUiaf.Columns("grpuros").Visible = False         '15
            'Me.DGVrptUiaf.Columns("base").Visible = False            '16
            'Me.DGVrptUiaf.Columns("regala").Visible = False          '17
            'Me.DGVrptUiaf.Columns("totalretef").Visible = False      '18
            'Me.DGVrptUiaf.Columns("vrventa").Visible = False         '19

            Me.DGVrptUiaf.Columns("fechatasa").Visible = False       '20
            Me.DGVrptUiaf.Columns("mestasa").Visible = False         '21

            Me.DGVrptUiaf.Columns("retevalor").Visible = False       '22
            Me.DGVrptUiaf.Columns("gp_rg").Visible = False           '23
            Me.DGVrptUiaf.Columns("gp_base").Visible = False         '24
            Me.DGVrptUiaf.Columns("valorgrrete").Visible = False     '25
            Me.DGVrptUiaf.Columns("pagobare").Visible = False        '26
            Me.DGVrptUiaf.Columns("mes_com").Visible = False         '27
            Me.DGVrptUiaf.Columns("año_com").Visible = False         '28
            'Me.DGVrptUiaf.Columns("consecutivo").Visible = False    '29
            Me.DGVrptUiaf.Columns("fecha_creado").Visible = False    '30
            Me.DGVrptUiaf.Columns("fecha_modifica").Visible = False  '31
            Me.DGVrptUiaf.Columns("letras").Visible = False          '32
            Me.DGVrptUiaf.Columns("detallemineral").Visible = False  '33
            Me.DGVrptUiaf.Columns("verifica").Visible = False        '34
            Me.DGVrptUiaf.Columns("numfundi").Visible = False        '35
            Me.DGVrptUiaf.Columns("formapago").Visible = False       '36
            Me.DGVrptUiaf.Columns("numtarjeta").Visible = False      '37
            Me.DGVrptUiaf.Columns("selebancos").Visible = False      '38
            Me.DGVrptUiaf.Columns("prefijo").Visible = False         '39
            Me.DGVrptUiaf.Columns("ConseQr").Visible = False         '40
            Me.DGVrptUiaf.Columns("tipoop").Visible = False          '41
            Me.DGVrptUiaf.Columns("tipodocu").Visible = False        '42
        End With

    End Sub


End Class