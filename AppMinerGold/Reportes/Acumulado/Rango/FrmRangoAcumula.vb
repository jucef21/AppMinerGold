Public Class FrmRangoAcumula

    'CARGUE DEL FORMULARIO
    Private Sub FrmRangoAcumula_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'actualizo la fecha en los calendarios
        DTPinicial.Value = Date.Now.ToString("d")
        DTPfinal.Value = Date.Now.ToString("d")

        'habilito el boton 
        Me.BtnConsu.Enabled = True
        Me.BtnImpTD.Enabled = False
        Me.BtnLimpia.Enabled = True

        'limpio  el label
        Me.LblModReg.Text = ""

        '======================

        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TxtGrBrutosC.Clear()
        Me.TxtLeyC.Clear()

        'HABILITO EL CHK
        Me.ChkOro.Checked = 1
        Me.ChkPlatino.Checked = 1
        Me.ChkPlata.Checked = 1

        Me.ChkOro.CheckState = CheckState.Unchecked
        Me.ChkPlatino.CheckState = CheckState.Unchecked
        Me.ChkPlata.CheckState = CheckState.Unchecked

        'limpio el datagrid
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Columns.Clear()
        Me.DataGridView1.Enabled = True

        Me.Panel4.Enabled = True
        Me.Panel1.Enabled = True
        Me.Panel4.Select()
        Me.Panel1.Select()
        Me.DTPinicial.Select()
        Me.DTPinicial.Focus()

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE IMPRIMIR REPORTE POR RANGO DE FECHAS
    Private Sub BtnConsu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsu.Click
        If ChkOro.Checked = CheckState.Unchecked And ChkPlatino.Checked = CheckState.Unchecked And ChkPlata.Checked = CheckState.Unchecked Then
            MessageBox.Show("Debe seleccionar un Material", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If ChkOro.Checked Then
                'llamo el procedimiento
                LLenaComprasOro()
                'inhabilito el boton
                Me.BtnConsu.Enabled = False
                Me.DTPinicial.Enabled = False
                Me.DTPfinal.Enabled = False
                Me.BtnImpTD.Enabled = True
                Me.BtnLimpia.Enabled = True
            End If

            If ChkPlatino.Checked Then
                'llamo el procedimiento
                LLenaComprasPlatino()
                'inhabilito el boton
                Me.BtnConsu.Enabled = False
                Me.DTPinicial.Enabled = False
                Me.DTPfinal.Enabled = False
                Me.BtnImpTD.Enabled = True
                Me.BtnLimpia.Enabled = True
            End If

            If ChkPlata.Checked Then
                'llamo el procedimiento
                LLenaComprasPlata()
                'inhabilito el boton
                Me.BtnConsu.Enabled = False
                Me.DTPinicial.Enabled = False
                Me.DTPfinal.Enabled = False
                Me.BtnImpTD.Enabled = True
                Me.BtnLimpia.Enabled = True
            End If

        End If
    End Sub

    Private Sub ChkOro_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkOro.CheckStateChanged
        ChkPlata.Checked = CheckState.Unchecked
        ChkPlatino.Checked = CheckState.Unchecked
    End Sub

    Private Sub ChkPlatino_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkPlatino.CheckStateChanged
        ChkOro.Checked = CheckState.Unchecked
        ChkPlata.Checked = CheckState.Unchecked
    End Sub

    Private Sub ChkPlata_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkPlata.CheckStateChanged
        ChkOro.Checked = CheckState.Unchecked
        ChkPlatino.Checked = CheckState.Unchecked
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
        Me.Panel4.Select()
        Me.DTPinicial.Select()
        Me.DTPinicial.Enabled = True
        Me.DTPinicial.Text = ""
        Me.DTPinicial.Focus()
        Me.DTPfinal.Enabled = True

        'habilitamos el boton
        Me.BtnConsu.Enabled = True
        Me.BtnImpTD.Enabled = False
        Me.BtnLimpia.Enabled = False

        'limpio  el label
        Me.LblModReg.Text = ""

        'actualizo la fecha en los calendarios
        DTPinicial.Value = Date.Now.ToString("d")
        DTPfinal.Value = Date.Now.ToString("d")

        'limpio checkbox
        Me.ChkOro.CheckState = CheckState.Unchecked
        Me.ChkPlatino.CheckState = CheckState.Unchecked
        Me.ChkPlata.CheckState = CheckState.Unchecked

    End Sub

#End Region


    'FUNCION QUE FILTRA LOS DATOS ENTRE FECHAS
    Private Sub LLenaComprasOro()
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim num As String = "1"
        Dim NumConse As String = "0"
        sql = "SELECT * 
               FROM Declara 
               WHERE fecha_creado BETWEEN @starDate AND @enddate 
                     AND nom_com <> '" & ANU & "' 
                     AND comOro= '" & num & "'
                     AND consecutivo <> " & NumConse '& "' ORDER BY consecutivo ASC"
        conn.ConnectionString = cs
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        With da.SelectCommand.Parameters
            .AddWithValue("@starDate", hugh)
            .AddWithValue("@endDate", hugh2)
        End With
        Dim ds As New DataSet
        Dim dt As New DataTable("Declara")
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            DataGridView1.DataSource = dt
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With DataGridView1.RowsDefaultCellStyle
                Me.DataGridView1.Columns(1).Width = 70
                Me.DataGridView1.Columns(1).HeaderText = "Cédula Proveedor"
                Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Me.DataGridView1.Columns(2).Width = 240
                Me.DataGridView1.Columns(2).HeaderText = "Nombre Completo"
                Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                Me.DataGridView1.Columns(3).Width = 100
                Me.DataGridView1.Columns(3).HeaderText = "Fecha de Compra"
                Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(10).Width = 120
                Me.DataGridView1.Columns(10).HeaderText = "Metal"
                Me.DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(13).Width = 80
                Me.DataGridView1.Columns(13).HeaderText = "Gramos Brutos"
                Me.DataGridView1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(13).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(14).Width = 60
                Me.DataGridView1.Columns(14).HeaderText = "Ley"
                Me.DataGridView1.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(14).DefaultCellStyle.Format = "N4"

                Me.DataGridView1.Columns(15).Width = 80
                Me.DataGridView1.Columns(15).HeaderText = "Gramos puros"
                Me.DataGridView1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(15).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(19).Width = 150
                Me.DataGridView1.Columns(19).HeaderText = "Valor de Compra"
                Me.DataGridView1.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView1.Columns(19).DefaultCellStyle.Format = "C2"

                Me.DataGridView1.Columns(27).Width = 100
                Me.DataGridView1.Columns(27).HeaderText = "Mes de Compra"
                Me.DataGridView1.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(28).Width = 100
                Me.DataGridView1.Columns(28).HeaderText = "Año de Compra"
                Me.DataGridView1.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(29).Width = 100
                Me.DataGridView1.Columns(29).HeaderText = "Consecutivo"
                Me.DataGridView1.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Me.DataGridView1.Columns(30).Width = 100
                'Me.DataGridView1.Columns(30).HeaderText = "Fecha Creación"
                'Me.DataGridView1.Columns(30).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'cedu_com, nom_com, fecha_com, metal_com, grbrutos, ley, grpuros, vrventa, mes_com, año_com, fecha_creado 

                'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
                Me.DataGridView1.Columns("Id").Visible = True                '0
                Me.DataGridView1.Columns("cedu_com").Visible = True          '1
                Me.DataGridView1.Columns("nom_com").Visible = True           '2
                Me.DataGridView1.Columns("fecha_com").Visible = True         '3
                Me.DataGridView1.Columns("dire_com").Visible = False         '4
                Me.DataGridView1.Columns("telc_com").Visible = False         '5
                Me.DataGridView1.Columns("correo_com").Visible = False       '6
                Me.DataGridView1.Columns("dpto_com").Visible = False         '7
                Me.DataGridView1.Columns("rut_com").Visible = False          '8
                Me.DataGridView1.Columns("act_com").Visible = False          '9
                Me.DataGridView1.Columns("metal_com").Visible = True       '10
                Me.DataGridView1.Columns("conce_com").Visible = False       '11
                Me.DataGridView1.Columns("ciuddpto").Visible = False        '12
                Me.DataGridView1.Columns("grbrutos").Visible = True         '13
                Me.DataGridView1.Columns("ley").Visible = True              '14
                Me.DataGridView1.Columns("grpuros").Visible = True          '15
                Me.DataGridView1.Columns("base").Visible = False             '16
                Me.DataGridView1.Columns("regala").Visible = False           '17
                Me.DataGridView1.Columns("totalretef").Visible = False       '18
                Me.DataGridView1.Columns("vrventa").Visible = True          '19
                Me.DataGridView1.Columns("fechatasa").Visible = False       '20
                Me.DataGridView1.Columns("mestasa").Visible = False         '21
                Me.DataGridView1.Columns("retevalor").Visible = False       '22
                Me.DataGridView1.Columns("gp_rg").Visible = False           '23
                Me.DataGridView1.Columns("gp_base").Visible = False         '24
                Me.DataGridView1.Columns("valorgrrete").Visible = False     '25
                Me.DataGridView1.Columns("pagobare").Visible = False        '26
                Me.DataGridView1.Columns("mes_com").Visible = True         '27
                Me.DataGridView1.Columns("año_com").Visible = True         '28
                Me.DataGridView1.Columns("consecutivo").Visible = True      '29
                Me.DataGridView1.Columns("fecha_creado").Visible = False    '30
                Me.DataGridView1.Columns("fecha_modifica").Visible = False  '31
                Me.DataGridView1.Columns("letras").Visible = False          '32
                Me.DataGridView1.Columns("detallemineral").Visible = False  '33
                Me.DataGridView1.Columns("verifica").Visible = False        '34
                Me.DataGridView1.Columns("numfundi").Visible = False        '35
                Me.DataGridView1.Columns("formapago").Visible = False       '36
                Me.DataGridView1.Columns("numtarjeta").Visible = False      '37
                Me.DataGridView1.Columns("selebancos").Visible = False      '38
                Me.DataGridView1.Columns("prefijo").Visible = False         '39
                Me.DataGridView1.Columns("ConseQr").Visible = False         '40
                Me.DataGridView1.Columns("tipoop").Visible = False          '41
                Me.DataGridView1.Columns("tipodocu").Visible = False        '42
                Me.DataGridView1.Columns("comOro").Visible = False           '43
                Me.DataGridView1.Columns("comPlatino").Visible = False       '44
                Me.DataGridView1.Columns("comPlata").Visible = False         '45
                Me.DataGridView1.Columns("ciudad").Visible = False           '46
                Me.DataGridView1.Columns("dpto").Visible = False             '47

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

    'FUNCION QUE FILTRA LOS DATOS ENTRE FECHAS
    Private Sub LLenaComprasPlatino()
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim num As String = "2"
        Dim NumConse As String = "0"
        sql = "SELECT * 
               FROM Declara 
               WHERE fecha_creado BETWEEN @starDate AND @enddate 
                     AND nom_com <> '" & ANU & "' 
                     AND comPlatino= '" & num & "'
                     AND consecutivo <> " & NumConse '& "' ORDER BY consecutivo ASC"
        conn.ConnectionString = cs
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        With da.SelectCommand.Parameters
            .AddWithValue("@starDate", hugh)
            .AddWithValue("@endDate", hugh2)
        End With
        Dim ds As New DataSet
        Dim dt As New DataTable("Declara")
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            DataGridView1.DataSource = dt
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With DataGridView1.RowsDefaultCellStyle
                Me.DataGridView1.Columns(1).Width = 70
                Me.DataGridView1.Columns(1).HeaderText = "Cédula Proveedor"
                Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Me.DataGridView1.Columns(2).Width = 240
                Me.DataGridView1.Columns(2).HeaderText = "Nombre Completo"
                Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                Me.DataGridView1.Columns(3).Width = 100
                Me.DataGridView1.Columns(3).HeaderText = "Fecha de Compra"
                Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(10).Width = 120
                Me.DataGridView1.Columns(10).HeaderText = "Metal"
                Me.DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(13).Width = 80
                Me.DataGridView1.Columns(13).HeaderText = "Gramos Brutos"
                Me.DataGridView1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(13).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(14).Width = 60
                Me.DataGridView1.Columns(14).HeaderText = "Ley"
                Me.DataGridView1.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(14).DefaultCellStyle.Format = "N4"

                Me.DataGridView1.Columns(15).Width = 80
                Me.DataGridView1.Columns(15).HeaderText = "Gramos puros"
                Me.DataGridView1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(15).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(19).Width = 150
                Me.DataGridView1.Columns(19).HeaderText = "Valor de Compra"
                Me.DataGridView1.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView1.Columns(19).DefaultCellStyle.Format = "C2"

                Me.DataGridView1.Columns(27).Width = 100
                Me.DataGridView1.Columns(27).HeaderText = "Mes de Compra"
                Me.DataGridView1.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(28).Width = 100
                Me.DataGridView1.Columns(28).HeaderText = "Año de Compra"
                Me.DataGridView1.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(29).Width = 100
                Me.DataGridView1.Columns(29).HeaderText = "Consecutivo"
                Me.DataGridView1.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Me.DataGridView1.Columns(30).Width = 100
                'Me.DataGridView1.Columns(30).HeaderText = "Fecha Creación"
                'Me.DataGridView1.Columns(30).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
                Me.DataGridView1.Columns("Id").Visible = True                '00
                Me.DataGridView1.Columns("cedu_com").Visible = True          '01
                Me.DataGridView1.Columns("nom_com").Visible = True           '02
                Me.DataGridView1.Columns("fecha_com").Visible = True         '03
                Me.DataGridView1.Columns("dire_com").Visible = False         '04
                Me.DataGridView1.Columns("telc_com").Visible = False         '05
                Me.DataGridView1.Columns("correo_com").Visible = False       '06
                Me.DataGridView1.Columns("dpto_com").Visible = False         '07
                Me.DataGridView1.Columns("rut_com").Visible = False          '08
                Me.DataGridView1.Columns("act_com").Visible = False          '09
                Me.DataGridView1.Columns("metal_com").Visible = True         '10
                Me.DataGridView1.Columns("conce_com").Visible = False        '11
                Me.DataGridView1.Columns("ciuddpto").Visible = False         '12
                Me.DataGridView1.Columns("grbrutos").Visible = True          '13
                Me.DataGridView1.Columns("ley").Visible = True               '14
                Me.DataGridView1.Columns("grpuros").Visible = True           '15
                Me.DataGridView1.Columns("base").Visible = False             '16
                Me.DataGridView1.Columns("regala").Visible = False           '17
                Me.DataGridView1.Columns("totalretef").Visible = False       '18
                Me.DataGridView1.Columns("vrventa").Visible = True           '19
                Me.DataGridView1.Columns("fechatasa").Visible = False        '20
                Me.DataGridView1.Columns("mestasa").Visible = False          '21
                Me.DataGridView1.Columns("retevalor").Visible = False        '22
                Me.DataGridView1.Columns("gp_rg").Visible = False            '23
                Me.DataGridView1.Columns("gp_base").Visible = False          '24
                Me.DataGridView1.Columns("valorgrrete").Visible = False      '25
                Me.DataGridView1.Columns("pagobare").Visible = False         '26
                Me.DataGridView1.Columns("mes_com").Visible = True           '27
                Me.DataGridView1.Columns("año_com").Visible = True           '28
                Me.DataGridView1.Columns("consecutivo").Visible = True       '29
                Me.DataGridView1.Columns("fecha_creado").Visible = False      '30
                Me.DataGridView1.Columns("fecha_modifica").Visible = False   '31
                Me.DataGridView1.Columns("letras").Visible = False           '32
                Me.DataGridView1.Columns("detallemineral").Visible = False   '33
                Me.DataGridView1.Columns("verifica").Visible = False         '34
                Me.DataGridView1.Columns("numfundi").Visible = False         '35
                Me.DataGridView1.Columns("formapago").Visible = False        '36
                Me.DataGridView1.Columns("numtarjeta").Visible = False       '37
                Me.DataGridView1.Columns("selebancos").Visible = False       '38
                Me.DataGridView1.Columns("prefijo").Visible = False          '39
                Me.DataGridView1.Columns("ConseQr").Visible = False          '40
                Me.DataGridView1.Columns("tipoop").Visible = False           '41
                Me.DataGridView1.Columns("tipodocu").Visible = False         '42
                Me.DataGridView1.Columns("comOro").Visible = False           '43
                Me.DataGridView1.Columns("comPlatino").Visible = False       '44
                Me.DataGridView1.Columns("comPlata").Visible = False         '45
                Me.DataGridView1.Columns("ciudad").Visible = False           '46
                Me.DataGridView1.Columns("dpto").Visible = False             '47

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

    'FUNCION QUE FILTRA LOS DATOS ENTRE FECHAS
    Private Sub LLenaComprasPlata()
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim num As String = "3"
        Dim NumConse As String = "0"
        sql = "SELECT * 
               FROM Declara 
               WHERE fecha_creado BETWEEN @starDate AND @enddate 
                     AND nom_com <> '" & ANU & "' 
                     AND comPlata= '" & num & "'
                     AND consecutivo <> " & NumConse '& "' ORDER BY consecutivo ASC"
        conn.ConnectionString = cs
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        With da.SelectCommand.Parameters
            .AddWithValue("@starDate", hugh)
            .AddWithValue("@endDate", hugh2)
        End With
        Dim ds As New DataSet
        Dim dt As New DataTable("Declara")
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            DataGridView1.DataSource = dt
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With DataGridView1.RowsDefaultCellStyle
                Me.DataGridView1.Columns(1).Width = 70
                Me.DataGridView1.Columns(1).HeaderText = "Cédula Proveedor"
                Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Me.DataGridView1.Columns(2).Width = 240
                Me.DataGridView1.Columns(2).HeaderText = "Nombre Completo"
                Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                Me.DataGridView1.Columns(3).Width = 100
                Me.DataGridView1.Columns(3).HeaderText = "Fecha de Compra"
                Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(10).Width = 120
                Me.DataGridView1.Columns(10).HeaderText = "Metal"
                Me.DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(13).Width = 80
                Me.DataGridView1.Columns(13).HeaderText = "Gramos Brutos"
                Me.DataGridView1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(13).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(14).Width = 60
                Me.DataGridView1.Columns(14).HeaderText = "Ley"
                Me.DataGridView1.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(14).DefaultCellStyle.Format = "N4"

                Me.DataGridView1.Columns(15).Width = 80
                Me.DataGridView1.Columns(15).HeaderText = "Gramos puros"
                Me.DataGridView1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.DataGridView1.Columns(15).DefaultCellStyle.Format = "N2"

                Me.DataGridView1.Columns(19).Width = 150
                Me.DataGridView1.Columns(19).HeaderText = "Valor de Compra"
                Me.DataGridView1.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView1.Columns(19).DefaultCellStyle.Format = "C2"

                Me.DataGridView1.Columns(27).Width = 100
                Me.DataGridView1.Columns(27).HeaderText = "Mes de Compra"
                Me.DataGridView1.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(28).Width = 100
                Me.DataGridView1.Columns(28).HeaderText = "Año de Compra"
                Me.DataGridView1.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Me.DataGridView1.Columns(29).Width = 100
                Me.DataGridView1.Columns(29).HeaderText = "Consecutivo"
                Me.DataGridView1.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Me.DataGridView1.Columns(30).Width = 100
                'Me.DataGridView1.Columns(30).HeaderText = "Fecha Creación"
                'Me.DataGridView1.Columns(30).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
                Me.DataGridView1.Columns("Id").Visible = True                '00
                Me.DataGridView1.Columns("cedu_com").Visible = True          '01
                Me.DataGridView1.Columns("nom_com").Visible = True           '02
                Me.DataGridView1.Columns("fecha_com").Visible = True         '03
                Me.DataGridView1.Columns("dire_com").Visible = False         '04
                Me.DataGridView1.Columns("telc_com").Visible = False         '05
                Me.DataGridView1.Columns("correo_com").Visible = False       '06
                Me.DataGridView1.Columns("dpto_com").Visible = False         '07
                Me.DataGridView1.Columns("rut_com").Visible = False          '08
                Me.DataGridView1.Columns("act_com").Visible = False          '09
                Me.DataGridView1.Columns("metal_com").Visible = True         '10
                Me.DataGridView1.Columns("conce_com").Visible = False        '11
                Me.DataGridView1.Columns("ciuddpto").Visible = False         '12
                Me.DataGridView1.Columns("grbrutos").Visible = True          '13
                Me.DataGridView1.Columns("ley").Visible = True               '14
                Me.DataGridView1.Columns("grpuros").Visible = True           '15
                Me.DataGridView1.Columns("base").Visible = False             '16
                Me.DataGridView1.Columns("regala").Visible = False           '17
                Me.DataGridView1.Columns("totalretef").Visible = False       '18
                Me.DataGridView1.Columns("vrventa").Visible = True           '19
                Me.DataGridView1.Columns("fechatasa").Visible = False        '20
                Me.DataGridView1.Columns("mestasa").Visible = False          '21
                Me.DataGridView1.Columns("retevalor").Visible = False        '22
                Me.DataGridView1.Columns("gp_rg").Visible = False            '23
                Me.DataGridView1.Columns("gp_base").Visible = False          '24
                Me.DataGridView1.Columns("valorgrrete").Visible = False      '25
                Me.DataGridView1.Columns("pagobare").Visible = False         '26
                Me.DataGridView1.Columns("mes_com").Visible = True           '27
                Me.DataGridView1.Columns("año_com").Visible = True           '28
                Me.DataGridView1.Columns("consecutivo").Visible = True       '29
                Me.DataGridView1.Columns("fecha_creado").Visible = False      '30
                Me.DataGridView1.Columns("fecha_modifica").Visible = False   '31
                Me.DataGridView1.Columns("letras").Visible = False           '32
                Me.DataGridView1.Columns("detallemineral").Visible = False   '33
                Me.DataGridView1.Columns("verifica").Visible = False         '34
                Me.DataGridView1.Columns("numfundi").Visible = False         '35
                Me.DataGridView1.Columns("formapago").Visible = False        '36
                Me.DataGridView1.Columns("numtarjeta").Visible = False       '37
                Me.DataGridView1.Columns("selebancos").Visible = False       '38
                Me.DataGridView1.Columns("prefijo").Visible = False          '39
                Me.DataGridView1.Columns("ConseQr").Visible = False          '40
                Me.DataGridView1.Columns("tipoop").Visible = False           '41
                Me.DataGridView1.Columns("tipodocu").Visible = False         '42
                Me.DataGridView1.Columns("comOro").Visible = False           '43
                Me.DataGridView1.Columns("comPlatino").Visible = False       '44
                Me.DataGridView1.Columns("comPlata").Visible = False         '45
                Me.DataGridView1.Columns("ciudad").Visible = False           '46
                Me.DataGridView1.Columns("dpto").Visible = False             '47

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

        If ChkOro.CheckState = CheckState.Checked Then
            'manejo dek cursor
            Me.Cursor = Cursors.WaitCursor
            FrmRptAcomulaOro.TextBox1.Text = Me.DTPinicial.Text
            FrmRptAcomulaOro.TextBox2.Text = Me.DTPfinal.Text
            FrmRptAcomulaOro.ShowDialog()
            'manejo dek cursor
            Me.Cursor = Cursors.Default
        End If

        If ChkPlatino.CheckState = CheckState.Checked Then
            'manejo dek cursor
            Me.Cursor = Cursors.WaitCursor
            FrmRptAcomulaPlatino.TextBox1.Text = Me.DTPinicial.Text
            FrmRptAcomulaPlatino.TextBox2.Text = Me.DTPfinal.Text
            FrmRptAcomulaPlatino.ShowDialog()
            'manejo dek cursor
            Me.Cursor = Cursors.Default
        End If

        If ChkPlata.CheckState = CheckState.Checked Then
            'manejo dek cursor
            Me.Cursor = Cursors.WaitCursor
            FrmRptAcomulaPlata.TextBox1.Text = Me.DTPinicial.Text
            FrmRptAcomulaPlata.TextBox2.Text = Me.DTPfinal.Text
            FrmRptAcomulaPlata.ShowDialog()
            'manejo dek cursor
            Me.Cursor = Cursors.Default
        End If

    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class