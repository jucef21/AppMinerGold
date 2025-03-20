Public Class FrmRangoFechasRegalias

    'CARGUE DEL FORMULARIO
    Private Sub FrmRangoFechasRegalias_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TxtMetal.Clear()

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

        'LIMPIO LOS  CHECKBOX
        Me.ChkOro.Checked = 1
        Me.ChkPlatino.Checked = 1
        Me.ChkPlata.Checked = 1

        Me.ChkOro.CheckState = CheckState.Unchecked
        Me.ChkPlatino.CheckState = CheckState.Unchecked
        Me.ChkPlata.CheckState = CheckState.Unchecked

        'Inhabilito las fechas
        Me.Panel1.Enabled = True
        Me.Panel2.Enabled = True

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE IMPRIMIR REPORTE POR RANGO DE FECHAS
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor
        'verifico el campo vacio
        If ChkOro.Checked = CheckState.Unchecked And ChkPlatino.Checked = CheckState.Unchecked And ChkPlata.Checked = CheckState.Unchecked Then
            MessageBox.Show("Debe seleccionar un Material", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If ChkOro.Checked Then
                LLenaRegaliasOro()
                'inhabilito el boton
                Me.Panel4.Select()
                Me.GroupBox1.Select()
                Me.DTPinicial.Select()
                Me.DTPinicial.Focus()
                Me.BtnBuscar.Enabled = False
                Me.BtnLimpiar.Enabled = True
                Me.BtnImprimir.Enabled = True
                'Inhabilito LOS  CHECKBOX
                Me.ChkOro.Enabled = False
                Me.ChkPlatino.Enabled = False
                Me.ChkPlata.Enabled = False
                'Inhabilito las fechas
                Me.Panel1.Enabled = False
                Me.Panel2.Enabled = False
            End If

            If ChkPlatino.Checked Then
                LLenaRegaliasPlatino()
                'inhabilito el boton
                Me.Panel4.Select()
                Me.GroupBox1.Select()
                Me.DTPinicial.Select()
                Me.DTPinicial.Focus()
                Me.BtnBuscar.Enabled = False
                Me.BtnLimpiar.Enabled = True
                Me.BtnImprimir.Enabled = True
                'Inhabilito LOS  CHECKBOX
                Me.ChkOro.Enabled = False
                Me.ChkPlatino.Enabled = False
                Me.ChkPlata.Enabled = False
                'Inhabilito las fechas
                Me.Panel1.Enabled = False
                Me.Panel2.Enabled = False
            End If

            If ChkPlata.Checked Then
                LLenaRegaliasPlata()
                'inhabilito el boton
                Me.Panel4.Select()
                Me.GroupBox1.Select()
                Me.DTPinicial.Select()
                Me.DTPinicial.Focus()
                Me.BtnBuscar.Enabled = False
                Me.BtnLimpiar.Enabled = True
                Me.BtnImprimir.Enabled = True
                'Inhabilito LOS  CHECKBOX
                Me.ChkOro.Enabled = False
                Me.ChkPlatino.Enabled = False
                Me.ChkPlata.Enabled = False
                'Inhabilito las fechas
                Me.Panel1.Enabled = False
                Me.Panel2.Enabled = False
            End If
        End If
        'manejo del cursor
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiar.Click
        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TxtMetal.Clear()

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

        'Limpio los Chk
        Me.ChkOro.CheckState = CheckState.Unchecked
        Me.ChkPlatino.CheckState = CheckState.Unchecked
        Me.ChkPlata.CheckState = CheckState.Unchecked

        'Hbilito LOS  CHECKBOX
        Me.ChkOro.Enabled = True
        Me.ChkPlatino.Enabled = True
        Me.ChkPlata.Enabled = True

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
        FrmRpt_Regalias.TextBox1.Text = Me.DTPinicial.Text
        FrmRpt_Regalias.TextBox2.Text = Me.DTPfinal.Text
        FrmRpt_Regalias.TxtMetales.Text = DataGridView1.CurrentRow.Cells(3).Value
        FrmRpt_Regalias.TxtCedula.Text = DataGridView1.CurrentRow.Cells(0).Value
        FrmRpt_Regalias.Show()
        'manejo de cursor
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCESOS DEL FORMULARIO"

    'PROCESO SELECCIONA MATERIAL A CONSULTAR
    Private Sub ChkOro_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkOro.CheckStateChanged
        ChkPlata.Checked = CheckState.Unchecked
        ChkPlatino.Checked = CheckState.Unchecked
        Me.TxtMetal.Text = "ORO"
    End Sub

    Private Sub ChkPlatino_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkPlatino.CheckStateChanged
        ChkOro.Checked = CheckState.Unchecked
        ChkPlata.Checked = CheckState.Unchecked
        Me.TxtMetal.Text = "PLATINO"
    End Sub

    Private Sub ChkPlata_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkPlata.CheckStateChanged
        ChkOro.Checked = CheckState.Unchecked
        ChkPlatino.Checked = CheckState.Unchecked
        Me.TxtMetal.Text = "PLATA"
    End Sub


    'FUNCION QUE FILTRA LOS DATOS ENTRE FECHAS MATERIAL ORO
    Private Sub LLenaRegaliasOro()
        Dim sqlBusca As String
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
        Dim ANU As String = "ANULADO"
        Dim num As String = "1"
        sqlBusca = "SELECT cedu_com, nom_com, fecha_com, metal_com, grbrutos, ley, grpuros, gp_rg, mes_com, año_com, consecutivo, fecha_creado FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comOro = '" & num & "' AND nom_com <> '" & ANU & "' ORDER BY consecutivo ASC"
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
                Me.DataGridView1.Columns(0).Width = 80
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

                Me.DataGridView1.Columns(6).Width = 100
                Me.DataGridView1.Columns(6).HeaderText = "Gramos Puros"
                Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(6).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(7).Width = 150
                Me.DataGridView1.Columns(7).HeaderText = "Valor Regalias"
                Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(8).Width = 100
                Me.DataGridView1.Columns(8).HeaderText = "Mes de Compra"
                Me.DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(9).Width = 100
                Me.DataGridView1.Columns(9).HeaderText = "Año de Compra"
                Me.DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(11).Width = 100
                Me.DataGridView1.Columns(11).HeaderText = "Fecha Creado"
                Me.DataGridView1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With

            'VERIFICA SI HAY DIAS EN VACIO O SIN OPERACION DE UNA DATAGRIDVIEW
            'SUMA GRAMOS PUROS
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dtg As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultado As Object = dtg.Compute("Sum(grpuros)", Nothing)
            TextBox1.Text = String.Format("{0:N2}", resultado)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultado = dtg.Compute("Sum(grpuros)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            TextBox3.Text = String.Format("{0:N2}", resultado)

            ''Sumar una Columna VALOR CANCELADO
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dt1 As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultado1 As Object = dt1.Compute("Sum(gp_rg)", Nothing)
            TextBox2.Text = String.Format("{0:N2}", resultado1)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultado1 = dt1.Compute("Sum(gp_rg)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            'TextBox3.Text = String.Format("{0:N2}", resultado1)

            Dim resultadoL As Double
            resultadoL = (resultado1 / resultado)
            Me.TxtLeyC.Text = FormatNumber(resultadoL, 4)

            'muestro la cantidad de registros encontrados
            LblModReg.Text = dt.Rows.Count

        Else
            MsgBox("No hay informacion que mostrar, consulte de nuevo", MsgBoxStyle.Information, "AppMinerGold")
            'ubico el cursor
            Me.Panel4.Select()
            Me.GroupBox1.Select()
            Me.DTPinicial.Text = ""
            Me.BtnBuscar.Enabled = True
            Me.BtnLimpiar.Enabled = True
            Me.BtnImprimir.Enabled = False
            Me.BtnLimpiar.Select()
            Me.BtnLimpiar.Focus()

            Me.DTPinicial.Enabled = True
            Me.DTPfinal.Enabled = True

            'limpio  el label
            Me.LblModReg.Text = ""

            'actualizo la fecha en los calendarios
            Dim dtFecha As Date = DateSerial(Year(Date.Today), 1, 1)
            Me.DTPinicial.Value = dtFecha
            Me.DTPfinal.Value = Date.Today

        End If

    End Sub

    'FUNCION QUE FILTRA LOS DATOS ENTRE FECHAS MATERIAL PLATINO
    Private Sub LLenaRegaliasPlatino()
        Dim sqlBusca As String
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
        Dim ANU As String = "ANULADO"
        Dim num As String = "2"
        sqlBusca = "SELECT cedu_com, nom_com, fecha_com, metal_com, grbrutos, ley, grpuros, gp_rg, mes_com, año_com, consecutivo, fecha_creado FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlatino = '" & num & "' AND nom_com <> '" & ANU & "' ORDER BY consecutivo ASC"
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
                Me.DataGridView1.Columns(0).Width = 80
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

                Me.DataGridView1.Columns(6).Width = 100
                Me.DataGridView1.Columns(6).HeaderText = "Gramos Puros"
                Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(6).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(7).Width = 150
                Me.DataGridView1.Columns(7).HeaderText = "Valor Regalias"
                Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"

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
                Me.DataGridView1.Columns(11).HeaderText = "Fecha Creado"
                Me.DataGridView1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With

            'VERIFICA SI HAY DIAS EN VACIO O SIN OPRACION DE UNA DATAGRIDVIEW
            'SUMA GRAMOS PUROS
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dtg As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultado As Object = dtg.Compute("Sum(grpuros)", Nothing)
            TextBox1.Text = String.Format("{0:N2}", resultado)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultado = dtg.Compute("Sum(grpuros)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            TextBox3.Text = String.Format("{0:N2}", resultado)

            ''Sumar una Columna VALOR CANCELADO
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dt1 As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultado1 As Object = dt1.Compute("Sum(gp_rg)", Nothing)
            TextBox2.Text = String.Format("{0:N2}", resultado1)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultado1 = dt1.Compute("Sum(gp_rg)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            'TextBox3.Text = String.Format("{0:N2}", resultado1)

            Dim resultadoL As Double
            resultadoL = (resultado1 / resultado)
            Me.TxtLeyC.Text = FormatNumber(resultadoL, 4)

            'muestro la cantidad de registros encontrados
            LblModReg.Text = dt.Rows.Count

        Else
            MsgBox("No hay informacion que mostrar, consulte de nuevo", MsgBoxStyle.Information, "AppMinerGold")
            'ubico el cursor
            Me.Panel4.Select()
            Me.GroupBox1.Select()
            Me.DTPinicial.Text = ""
            Me.BtnBuscar.Enabled = True
            Me.BtnLimpiar.Enabled = True
            Me.BtnImprimir.Enabled = False
            Me.BtnLimpiar.Select()
            Me.BtnLimpiar.Focus()

            Me.DTPinicial.Enabled = True
            Me.DTPfinal.Enabled = True

            'limpio  el label
            Me.LblModReg.Text = ""

            'actualizo la fecha en los calendarios
            Dim dtFecha As Date = DateSerial(Year(Date.Today), 1, 1)
            Me.DTPinicial.Value = dtFecha
            Me.DTPfinal.Value = Date.Today

        End If
    End Sub

    'FUNCION QUE FILTRA LOS DATOS ENTRE FECHAS MATERIAL PLATA
    Private Sub LLenaRegaliasPlata()
        Dim sqlBusca As String
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
        Dim ANU As String = "ANULADO"
        Dim num As String = "3"
        sqlBusca = "SELECT cedu_com, nom_com, fecha_com, metal_com, grbrutos, ley, grpuros, gp_rg, mes_com, año_com, consecutivo, fecha_creado FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlata = '" & num & "' AND nom_com <> '" & ANU & "' ORDER BY consecutivo ASC"
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
                Me.DataGridView1.Columns(0).Width = 80
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

                Me.DataGridView1.Columns(6).Width = 100
                Me.DataGridView1.Columns(6).HeaderText = "Gramos Puros"
                Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(6).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(7).Width = 150
                Me.DataGridView1.Columns(7).HeaderText = "Valor Regalias"
                Me.DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"

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

            'VERIFICA SI HAY DIAS EN VACIO O SIN OPRACION DE UNA DATAGRIDVIEW
            'SUMA GRAMOS PUROS
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dtg As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultado As Object = dtg.Compute("Sum(grpuros)", Nothing)
            TextBox1.Text = String.Format("{0:N2}", resultado)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultado = dtg.Compute("Sum(grpuros)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            TextBox3.Text = String.Format("{0:N2}", resultado)

            ''Sumar una Columna VALOR CANCELADO
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dt1 As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultado1 As Object = dt1.Compute("Sum(gp_rg)", Nothing)
            TextBox2.Text = String.Format("{0:N2}", resultado1)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultado1 = dt1.Compute("Sum(gp_rg)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            'TextBox3.Text = String.Format("{0:N2}", resultado1)

            Dim resultadoL As Double
            resultadoL = (resultado1 / resultado)
            Me.TxtLeyC.Text = FormatNumber(resultadoL, 4)

            'muestro la cantidad de registros encontrados
            LblModReg.Text = dt.Rows.Count

        Else
            MsgBox("No hay informacion que mostrar, consulte de nuevo", MsgBoxStyle.Information, "AppMinerGold")
            'ubico el cursor
            Me.Panel4.Select()
            Me.GroupBox1.Select()
            Me.DTPinicial.Text = ""
            Me.BtnBuscar.Enabled = True
            Me.BtnLimpiar.Enabled = True
            Me.BtnImprimir.Enabled = False
            Me.BtnLimpiar.Select()
            Me.BtnLimpiar.Focus()

            Me.DTPinicial.Enabled = True
            Me.DTPfinal.Enabled = True

            'limpio  el label
            Me.LblModReg.Text = ""

            'actualizo la fecha en los calendarios
            Dim dtFecha As Date = DateSerial(Year(Date.Today), 1, 1)
            Me.DTPinicial.Value = dtFecha
            Me.DTPfinal.Value = Date.Today

        End If
    End Sub


#End Region


End Class