Public Class FrmFechaDisponible

    'CARGUE DEL FORMULARIO
    Private Sub FrmFechaDisponible_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE IMPRIMIR REPORTE POR RANGO DE FECHAS
    Private Sub BtnConsu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsu.Click
        'manejo dek cursor
        Me.Cursor = Cursors.WaitCursor

        'llamo el procedimiento
        LLenaCompras(DataGridView1)

        'inhabilito el boton
        Me.BtnConsu.Enabled = False
        Me.BtnImpTD.Enabled = True
        Me.BtnLimpia.Enabled = True

        Me.DTPinicial.Enabled = False
        Me.DTPfinal.Enabled = False

        'manejo dek cursor
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
        Me.DTPinicial.Text = ""
        Me.DTPinicial.Select()
        Me.DTPinicial.Focus()

        'habilitamos el boton
        Me.BtnConsu.Enabled = True
        Me.BtnImpTD.Enabled = False
        Me.BtnLimpia.Enabled = False

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
    Private Sub LLenaComprasMaterial(ByVal DataGridView As DataGridView)
        Try
            Dim sqlBusca As String
            Dim conn As New OleDb.OleDbConnection
            Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
            Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
            sqlBusca = "SELECT D.cedu_com,
                               D.nom_com,
                               D.dire_com,
                               D.telc_com,
                               D.correo_com,
                               D.dpto_com, 
                               D.fecha_creado,
                               E.direzonas AS [Empresa1Cliente],
                               D.consecutivo
                               FROM Declara D INNER JOIN Empresa1Cliente E
                               ON D.cedu_com = E.ceduem
                               WHERE D.fecha_creado BETWEEN @starDate AND @enddate                               
                               ORDER BY D.consecutivo ASC"
            conn.ConnectionString = cs
            Dim da As New OleDb.OleDbDataAdapter(sqlBusca, conn)
            With da.SelectCommand.Parameters
                .AddWithValue("@starDate", hugh)
                .AddWithValue("@endDate", hugh2)
            End With
            Dim dt As New DataTable("Declara, Empresa1Cliente")
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt
                'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
                With DataGridView1.RowsDefaultCellStyle
                    Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    Me.DataGridView1.Columns(0).Width = 80
                    Me.DataGridView1.Columns(0).HeaderText = "Cédula Proveedor"
                    Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Me.DataGridView1.Columns(1).Width = 260
                    Me.DataGridView1.Columns(1).HeaderText = "Nombre Completo"
                    Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                    Me.DataGridView1.Columns(2).Width = 240
                    Me.DataGridView1.Columns(2).HeaderText = "Dirección"
                    Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                    Me.DataGridView1.Columns(3).Width = 100
                    Me.DataGridView1.Columns(3).HeaderText = "Teléfono"
                    Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Me.DataGridView1.Columns(4).Width = 160
                    Me.DataGridView1.Columns(4).HeaderText = "Correo"
                    Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                    Me.DataGridView1.Columns(5).Width = 120
                    Me.DataGridView1.Columns(5).HeaderText = "Ciudad"
                    Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                    Me.DataGridView1.Columns(6).Width = 100
                    Me.DataGridView1.Columns(6).HeaderText = "Fecha Compra"
                    Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    Me.DataGridView1.Columns(7).Width = 240
                    Me.DataGridView1.Columns(7).HeaderText = "Zona Autorizada"
                    Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                    Me.DataGridView1.Columns(8).Width = 100
                    Me.DataGridView1.Columns(8).HeaderText = "Consecutivo"
                    Me.DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                End With
            Else
                MsgBox("No hay informacion que mostrar, consulte de nuevo", MsgBoxStyle.Information, "AppMinerGold")
                Me.BtnLimpia.Select()
                Me.BtnLimpia.Focus()
            End If
            'Inhabilito el datagrig para ediccion
            Me.DataGridView1.Enabled = True

            'muestro la cantidad de registros encontrados
            LblModReg.Text = dt.Rows.Count

            'inhabilito el boton
            Me.BtnConsu.Enabled = False
        Catch ex As Exception
            MessageBox.Show("No se lleno el Datagridview debido a: " + ex.ToString, "AppMinerGold")
            Me.BtnLimpia.Select()
            Me.BtnLimpia.Focus()
        End Try
    End Sub

    Private Sub LLenaCompras(ByVal DataGridView As DataGridView)
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim sqlZonas = "SELECT cedu_com, nom_com, fecha_com, metal_com, grbrutos, ley, grpuros,consecutivo, ciudad, dpto 
                        FROM Declara WHERE fecha_creado 
                        BETWEEN @starDate AND @enddate AND nom_com <> '" & ANU & "'ORDER BY consecutivo ASC"

        conn.ConnectionString = cs
        Dim da As New OleDb.OleDbDataAdapter(sqlZonas, conn)
        With da.SelectCommand.Parameters
            .AddWithValue("@starDate", hugh)
            .AddWithValue("@endDate", hugh2)
        End With
        Dim dt As New DataTable("Declara")
        da.Fill(dt)

        If dt.Rows.Count > 0 Then
            DataGridView1.DataSource = dt
            'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
            With DataGridView1.RowsDefaultCellStyle
                Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(0).Width = 80
                Me.DataGridView1.Columns(0).HeaderText = "Cédula Proveedor"
                Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Me.DataGridView1.Columns(1).Width = 260
                Me.DataGridView1.Columns(1).HeaderText = "Nombre Completo"
                Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                Me.DataGridView1.Columns(2).Width = 80
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

                Me.DataGridView1.Columns(7).Width = 70
                Me.DataGridView1.Columns(7).HeaderText = "Consecutivo"
                Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(8).Width = 180
                Me.DataGridView1.Columns(8).HeaderText = "Zona Autorizada"
                Me.DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(9).Width = 100
                Me.DataGridView1.Columns(9).HeaderText = "Departamento"
                Me.DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
        Else
            MessageBox.Show("No hay informacion que mostrar, consulte de nuevo", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Private Sub BtnImpAse1_Click(sender As Object, e As EventArgs) Handles BtnImpTD.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor
        'FrmDisponible.TxtFechaIni.Text = Me.DTPinicial.Text
        'FrmDisponible.TxtFechaFin.Text = Me.DTPfinal.Text
        'FrmDisponible.TxtZonas.Text = Me.DataGridView1.CurrentRow.Cells(7).Value
        'FrmDisponible.Show()
        'FrmZonasAuto.TxtFechaIni.Text = Me.DTPinicial.Text
        'FrmZonasAuto.TxtFechaFin.Text = Me.DTPfinal.Text
        'FrmZonasAuto.TxtZonas.Text = Me.DataGridView1.CurrentRow.Cells(7).Value
        'FrmZonasAuto.ShowDialog()

        FrmZonasDpto.TxtFechaIni.Text = Me.DTPinicial.Text
        FrmZonasDpto.TxtFechaFin.Text = Me.DTPfinal.Text
        'FrmZonasDpto.TxtZonas.Text = Me.DataGridView1.CurrentRow.Cells(7).Value
        FrmZonasDpto.ShowDialog()

        'manejo del cursor
        Me.Cursor = Cursors.Default

    End Sub

    Dim IntFila As Integer = 0
    Dim dtzonas As New DataTable
    'Dim IntFila As Integer = 0 'permite almacenar las filas del datagrid
    Private Sub MostrarZonas()
        For i As Integer = 0 To dtzonas.Rows.Count - 1
            Dim value As String
            value = DataGridView1.CurrentRow.Cells(7).Value
            Dim params(0) As Microsoft.Reporting.WinForms.ReportParameter
            params(0) = New Microsoft.Reporting.WinForms.ReportParameter("ParameterZonas", value)
            FrmDisponible.ReportViewer1.LocalReport.SetParameters(params)
            IntFila += 1 ' suma una fila del Dgw
        Next
        IntFila += 1
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub


End Class