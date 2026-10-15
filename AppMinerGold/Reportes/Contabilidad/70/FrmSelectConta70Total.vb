Public Class FrmSelectConta70Total

    Private Sub FrmSelectConta70Total_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        'LLenaCompras(DataGridView1)

        CargarTodasLasCompras()

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
    Private Sub LLenaCompras(ByVal DataGridView As DataGridView)
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim sqlZonas = "SELECT cedu_com, nom_com, fecha_com, metal_com,vrventa, consecutivo
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

                Me.DataGridView1.Columns(1).Width = 240
                Me.DataGridView1.Columns(1).HeaderText = "Nombre Completo"
                Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                Me.DataGridView1.Columns(2).Width = 80
                Me.DataGridView1.Columns(2).HeaderText = "Fecha de Compra"
                Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(3).Width = 70
                Me.DataGridView1.Columns(3).HeaderText = "Metal"
                Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(4).Width = 150
                Me.DataGridView1.Columns(4).HeaderText = "Valor Cancelado"
                Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView1.Columns(4).DefaultCellStyle.Format = "C2"

                Me.DataGridView1.Columns(5).Width = 70
                Me.DataGridView1.Columns(5).HeaderText = "Consecutivo"
                Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


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
    Private Sub BtnImpTD_Click(sender As Object, e As EventArgs) Handles BtnImpTD.Click

        Me.Cursor = Cursors.WaitCursor

        'Enviar los datos al formulario
        FrmConta70Total.TxtFechaIni.Text = DTPinicial.Text
        FrmConta70Total.TxtFechaFin.Text = DTPfinal.Text
        FrmConta70Total.ShowDialog()

        Me.Cursor = Cursors.Default()

    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    Private Sub CargarTodasLasCompras()

        Try
            Dim hugh As Date = DTPinicial.Value.Date
            Dim hugh2 As Date = DTPfinal.Value.Date

            If hugh > hugh2 Then
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.",
                                "AppMinerGold",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim ANU As String = "ANULADO"
            Dim sql = "SELECT cedu_com, nom_com, fecha_com, metal_com,vrventa, consecutivo
                        FROM Declara WHERE fecha_creado 
                        BETWEEN @starDate AND @enddate AND nom_com <> '" & ANU & "'ORDER BY consecutivo ASC"

            conn.ConnectionString = cs
            Dim da As New OleDb.OleDbDataAdapter(sql, conn)
            With da.SelectCommand.Parameters
                .AddWithValue("@starDate", hugh)
                .AddWithValue("@endDate", hugh2)
            End With
            Dim dt As New DataTable("Declara")
            da.Fill(dt)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No hay compras en el rango de fechas seleccionado.",
                                        "AppMinerGold",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)
                Exit Sub
            ElseIf dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt
                'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
                With DataGridView1.RowsDefaultCellStyle
                    Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    Me.DataGridView1.Columns(0).Width = 80
                    Me.DataGridView1.Columns(0).HeaderText = "Cédula Proveedor"
                    Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Me.DataGridView1.Columns(1).Width = 240
                    Me.DataGridView1.Columns(1).HeaderText = "Nombre Completo"
                    Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                    Me.DataGridView1.Columns(2).Width = 80
                    Me.DataGridView1.Columns(2).HeaderText = "Fecha de Compra"
                    Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    Me.DataGridView1.Columns(3).Width = 70
                    Me.DataGridView1.Columns(3).HeaderText = "Metal"
                    Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    Me.DataGridView1.Columns(4).Width = 150
                    Me.DataGridView1.Columns(4).HeaderText = "Valor Cancelado"
                    Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.DataGridView1.Columns(4).DefaultCellStyle.Format = "C2"

                    Me.DataGridView1.Columns(5).Width = 70
                    Me.DataGridView1.Columns(5).HeaderText = "Consecutivo"
                    Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


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
        Catch ex As Exception
            MessageBox.Show("Error al consultar las compras: " & ex.Message,
                            "AppMinerGold",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

    End Sub

End Class