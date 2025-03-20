Public Class FrmRangoFechaFundi

    'CARGUE DEL FORMULARIO
    Private Sub FrmRangoAcumulado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TxtGrBrutosC.Clear()
        Me.TxtLeyC.Clear()

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE IMPRIMIR REPORTE POR RANGO DE FECHAS
    Private Sub BtnConsu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsu.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        'llamo el procedimiento
        LLenaCompras()

        'inhabilito el boton
        Me.BtnConsu.Enabled = False
        Me.DTPinicial.Enabled = False
        Me.DTPfinal.Enabled = False
        Me.BtnImpTD.Enabled = True
        Me.BtnLimpia.Enabled = True

        'manejo del cursor
        Me.Cursor = Cursors.Default

    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpia_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpia.Click

        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TxtGrBrutosC.Clear()
        Me.TxtLeyC.Clear()

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
    Private Sub LLenaCompras()
        Dim sqlBusca As String
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
        Dim ANU As String = "ANULADO"
        sqlBusca = "SELECT cedu_com, nom_com, fecha_com, metal_com, grbrutos, ley, grpuros, vrventa, mes_com, año_com, consecutivo, fecha_creado FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND nom_com <> '" & ANU & "' ORDER BY consecutivo ASC"
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
            TextBox1.Text = String.Format("{0:N2}", resultado)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultado = dtl.Compute("Sum(grpuros)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            TextBox3.Text = String.Format("{0:N2}", resultado)

            'SUMA GRAMOS BRUTOS
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dtB As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultadoB As Object = dtB.Compute("Sum(grbrutos)", Nothing)
            Me.TxtGrBrutosC.Text = String.Format("{0:N2}", resultadoB)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultadoB = dtB.Compute("Sum(grbrutos)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            'TextBox3.Text = String.Format("{0:N2}", resultadoB)

            Dim resultadoL As Double
            resultadoL = (resultado / resultadoB)
            Me.TxtLeyC.Text = FormatNumber(resultadoL, 4)
            'Me.TxtLeyC.Text = resultadoL

            'Sumar una Columna VALOR CANCELADO
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dt1 As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultado1 As Object = dt1.Compute("Sum(vrventa)", Nothing)
            TextBox2.Text = String.Format("{0:N2}", resultado1)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultado1 = dt1.Compute("Sum(vrventa)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            'TextBox3.Text = String.Format("{0:N2}", resultado1)

            'inhabilito el boton
            Me.BtnConsu.Enabled = False
            Me.BtnImpTD.Enabled = True
            Me.BtnLimpia.Enabled = True


        Else
            MsgBox("No hay informacion que mostrar, consulte de nuevo", MsgBoxStyle.Information, "AppMinerGold")
            'inhabilito el boton
            Me.BtnConsu.Enabled = False
            Me.BtnImpTD.Enabled = False
            Me.BtnLimpia.Enabled = True

            'ubico el cursor
            Me.BtnLimpia.Select()
            Me.BtnLimpia.Focus()
        End If

        'Inhabilito el datagrig para ediccion
        Me.DataGridView1.Enabled = True

        'muestro la cantidad de registros encontrados
        LblModReg.Text = dt.Rows.Count

    End Sub

    'BOTON DE  IMPRIMIR
    Private Sub BtnImpAse1_Click(sender As Object, e As EventArgs) Handles BtnImpTD.Click
        'manejo dek cursor
        Me.Cursor = Cursors.WaitCursor
        FrmRptAcomula.TextBox1.Text = Me.DTPinicial.Text
        FrmRptAcomula.TextBox2.Text = Me.DTPfinal.Text
        FrmRptAcomula.Show()
        'manejo dek cursor
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class