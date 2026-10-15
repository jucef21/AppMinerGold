Public Class FrmSelectConta30

    'CARGUE DEL FORMULARIO
    Private Sub FrmSlectConta30_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False

        'actualizo la fecha en los calendarios
        DTPinicial.Value = Date.Now.ToString("d")
        DTPfinal.Value = Date.Now.ToString("d")

        'habilito el boton 
        Me.BtnConsu.Enabled = True
        Me.BtnConta30.Enabled = False
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
        Me.BtnConta30.Enabled = True
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
        Me.BtnConta30.Enabled = False
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

        DataGridView1.DataSource = dt
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False

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
    Private Sub BtnConta30_Click(sender As Object, e As EventArgs) Handles BtnConta30.Click

        Try
            'Verificar que exista una fila actual
            If DataGridView1.CurrentRow Is Nothing OrElse
           DataGridView1.CurrentRow.IsNewRow Then

                MessageBox.Show("Seleccione una compra para imprimir.",
                            "AppMinerGold",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
                Exit Sub
            End If

            'Obtener el consecutivo de la fila actual
            Dim consecutivo As String =
            Convert.ToString(DataGridView1.CurrentRow.Cells("consecutivo").Value)

            'VERIFICACION TEMPORAL: comprobar qué fila se está leyendo
            MessageBox.Show("Consecutivo seleccionado: " & consecutivo)

            If String.IsNullOrWhiteSpace(consecutivo) Then
                MessageBox.Show("El consecutivo está vacío.")
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            'Enviar los datos al formulario
            FrmConta30.TxtFechaIni.Text = DTPinicial.Text
            FrmConta30.TxtFechaFin.Text = DTPfinal.Text
            FrmConta30.TxtConsecutivo.Text = consecutivo

            FrmConta30.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message,
                        "AppMinerGold",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    Private Sub CargarTodasLasCompras()

        Try
            Dim fechaInicial As Date = DTPinicial.Value.Date
            Dim fechaFinal As Date = DTPfinal.Value.Date

            If fechaInicial > fechaFinal Then
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.",
                                "AppMinerGold",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim sql As String =
                "SELECT * FROM Declara " &
                "WHERE fecha_creado >= ? " &
                "AND fecha_creado < ? " &
                "ORDER BY consecutivo"

            Using conn As New OleDb.OleDbConnection(cs)
                Using cmd As New OleDb.OleDbCommand(sql, conn)

                    cmd.Parameters.Add("?", OleDb.OleDbType.Date).Value = fechaInicial
                    cmd.Parameters.Add("?", OleDb.OleDbType.Date).Value = fechaFinal.AddDays(1)

                    Dim dt As New DataTable()

                    Using da As New OleDb.OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("No hay compras en el rango de fechas seleccionado.",
                                        "AppMinerGold",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    'Aquí debes asignar dt al origen de datos
                    'del reporte que utilizas en FrmContabilidad.

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al consultar las compras: " & ex.Message,
                            "AppMinerGold",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

    End Sub

End Class