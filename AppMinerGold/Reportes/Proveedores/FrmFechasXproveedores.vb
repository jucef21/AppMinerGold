Public Class FrmFechasXproveedores

    'CARGUE DEL FORMULARIO
    Private Sub FrmFechasXproveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'actualizo la fecha en los calendarios
        DTPinicial.Value = Date.Now.ToString("d")
        DTPfinal.Value = Date.Now.ToString("d")

        'habilito el boton 
        Me.BtnImpTD.Enabled = False
        Me.BtnLimpia.Enabled = False

        'limpio  el label
        Me.LblModReg.Text = ""

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE LIMPIAR
    Private Sub BtnLimpia_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpia.Click

        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        'ubico el cursor
        Me.DTPinicial.Enabled = True
        Me.DTPinicial.Text = ""
        Me.DTPinicial.Select()
        Me.DTPinicial.Focus()

        'habilitamos el boton
        Me.BtnConsu.Enabled = True
        Me.BtnImpTD.Enabled = False
        Me.BtnLimpia.Enabled = True

        Me.DTPinicial.Enabled = True
        Me.DTPfinal.Enabled = True

        'limpio  el label
        Me.LblModReg.Text = ""

        'actualizo la fecha en los calendarios
        DTPinicial.Value = Date.Now.ToString("d")
        DTPfinal.Value = Date.Now.ToString("d")

    End Sub


#End Region

    'FUNCION QUE FILTRA LOS DATOS ENTRE FECHAS
    Private Sub LLenaComprasProveedores()
        Dim sqlBusca As String
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
        Dim ANU As String = "ANULADO"
        sqlBusca = "SELECT cedu_com, nom_com, fecha_com, metal_com, grbrutos, ley, grpuros, vrventa, mes_com, año_com, consecutivo, fecha_creado FROM Declara WHERE fecha_modifica BETWEEN @starDate AND @enddate AND nom_com <> '" & ANU & "'ORDER BY fecha_modifica ASC"
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
            'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
            With DataGridView1.RowsDefaultCellStyle
                Me.DataGridView1.Columns(0).Width = 80
                Me.DataGridView1.Columns(0).HeaderText = "Cédula Proveedor"
                Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Me.DataGridView1.Columns(1).Width = 240
                Me.DataGridView1.Columns(1).HeaderText = "Nombre Completo"
                Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                Me.DataGridView1.Columns(2).Width = 100
                Me.DataGridView1.Columns(2).HeaderText = "Fecha de Compra"
                Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(3).Width = 50
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

            End With

        Else
            MsgBox("No hay informacion que mostrar, consulte de nuevo", MsgBoxStyle.Information, "AppMinerGold")
            Me.BtnLimpia.Select()
            Me.BtnLimpia.Focus()
        End If

        'Inhabilito el datagrig para ediccion
        Me.DataGridView1.Enabled = False

        'muestro la cantidad de registros encontrados
        LblModReg.Text = dt.Rows.Count

    End Sub

    'BOTON DE  IMPRIMIR
    Private Sub BtnImpAse1_Click(sender As Object, e As EventArgs) Handles BtnImpTD.Click
        'manejo dek cursor
        Me.Cursor = Cursors.WaitCursor

        FrmRptFechaProv.TextBox1.Text = Me.DTPinicial.Value
        FrmRptFechaProv.TextBox2.Text = Me.DTPfinal.Value
        FrmRptFechaProv.Show()

        'manejo dek cursor
        Me.Cursor = Cursors.Default

    End Sub

    'BOOTN DE CONSULTAR
    Private Sub BtnConsu_Click(sender As Object, e As EventArgs) Handles BtnConsu.Click
        'manejo de cursor
        Me.Cursor = Cursors.WaitCursor

        'llamo el procedimiento
        LLenaComprasProveedores()

        'inhabilito el boton
        Me.BtnConsu.Enabled = False
        Me.BtnImpTD.Enabled = True
        Me.BtnLimpia.Enabled = True

        Me.DTPinicial.Enabled = False
        Me.DTPfinal.Enabled = False

        'manejo de cursor
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class