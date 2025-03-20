Imports System.Data.OleDb

Public Class FrmAcumXcliente


    'CARGUE DEL FORMULARIO
    Private Sub AcumXcliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'llenamos los datos con la informacion seleccionada
        Me.Txtced_cl.Enabled = False
        Me.Txtced_cl.Text = ModuleFrm.ced_consulta

        Me.TxtNomPaciente.Enabled = False
        'Me.TxtNomPaciente.Text = ModuleFrm.Nom_consulta

        'llamo el  preocedimeinto de CONCATENAR 
        UnirNombres()

        'muestro el resultado y los concateno
        Me.TxtNomPaciente.Text = Me.TxtName.Text & " " & Me.TxtSurname.Text

        '================
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
        'ubico el cursor
        Me.DTPinicial.Select()
        Me.DTPinicial.Focus()

        Me.TextBox1.Clear()
        Me.TextBox2.Clear()

    End Sub

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    'PROCEDIMIENTO PARA UNIR NOMBRE Y APELLIDO DEL CLIENTE
    Private Sub UnirNombres()
        Dim dt As New DataTable
        Dim NumCedu As Integer = CInt(Txtced_cl.Text)
        Dim consulta As String = "SELECT * FROM Clientes WHERE ced_cl = " & NumCedu
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            Me.TxtName.Text = drd.Item("nom_cl").ToString
            Me.TxtSurname.Text = drd.Item("ape_cl").ToString
        Else
            MsgBox("No se encontro NOMBRES", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
        conn.Close()
    End Sub

    'FUNCION QUE FILTRA LOS DATOS ENTRE FECHAS
    Private Sub LLenaprov()
        Dim sqlBusca As String
        Dim Numcedullena As Integer = CInt(Txtced_cl.Text)
        Dim conn As New OleDb.OleDbConnection
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
        'sqlBusca = "SELECT * FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate and cedu_com = '" & Txtced_cl.Text & "' ORDER BY consecutivo ASC"
        sqlBusca = "SELECT * FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate and cedu_com = " & Numcedullena ''" & Txtced_cl.Text & "' ORDER BY consecutivo ASC"
        conn.ConnectionString = cs
        Dim da As New OleDb.OleDbDataAdapter(sqlBusca, conn)
        With da.SelectCommand.Parameters
            .AddWithValue("@starDate", hugh)
            .AddWithValue("@endDate", hugh2)
        End With
        Dim dt As New DataTable("Declara")
        da.Fill(dt)
        DataGridView1.DataSource = dt

        'Inhabilito el datagrig para ediccion
        Me.DataGridView1.Enabled = False

        'muestro la cantidad de registros encontrados
        LblModReg.Text = dt.Rows.Count

        'inhabilito el boton
        Me.BtnConsu.Enabled = False
        Me.DTPinicial.Enabled = False
        Me.DTPfinal.Enabled = False

    End Sub

#End Region

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE IMPRIMIR REPORTE POR RANGO DE FECHAS
    Private Sub BtnConsu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsu.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        'llamo el procedimiento
        LLenaprov()

        'inhabilito el boton
        Me.BtnConsu.Enabled = False
        Me.BtnImpTD.Enabled = True
        Me.BtnLimpia.Enabled = True

        'VERIFICA SI HAY DIAS EN VACIO O SIN OPRACION DE UNA DATAGRIDVIEW
        'SUMA GRAMOS PUROS
        ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
        Dim dt As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
        ' Sumamos todas las filas de la columna TotalFactura.
        Dim resultado As Object = dt.Compute("Sum(grpuros)", Nothing)
        TextBox1.Text = String.Format("{0:N2}", resultado)
        ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
        resultado = dt.Compute("Sum(grpuros)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
        TextBox3.Text = String.Format("{0:N2}", resultado)

        'SUMA GRAMOS BRUTOS
        ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
        Dim dtB As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
        ' Sumamos todas las filas de la columna TotalFactura.
        Dim resultadoB As Object = dtB.Compute("Sum(grbrutos)", Nothing)
        TextBox5.Text = String.Format("{0:N2}", resultadoB)
        ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
        resultadoB = dtB.Compute("Sum(grbrutos)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
        'TextBox3.Text = String.Format("{0:N2}", resultado)

        'CALCULA LA  LEY
        'Me.TextBox4.Text = FormatNumber(resultado / resultadoB).ToString

        Try
            Dim resultadoL As Double
            resultadoL = (resultado / resultadoB)
            Me.TextBox4.Text = FormatNumber(resultadoL, 4)
            'Me.TextBox4.Text = resultadoL
        Catch ex As Exception
            MsgBox("No hay Compras en la fecha Seleccionada, Consulte un nuevo criterio de Fechas.", MsgBoxStyle.Information, "AppMinerGold")
            Me.BtnLimpia.Select()
            Me.BtnLimpia.Focus()
        End Try

        ''Sumar una Columna VALOR CANCELADO
        ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
        Dim dt1 As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
        ' Sumamos todas las filas de la columna TotalFactura.
        Dim resultado1 As Object = dt1.Compute("Sum(vrventa)", Nothing)
        TextBox2.Text = String.Format("{0:N2}", resultado1)
        ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
        resultado1 = dt1.Compute("Sum(vrventa)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
        'TextBox3.Text = String.Format("{0:N2}", resultado1)

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
        Me.TextBox4.Clear()
        Me.TextBox5.Clear()

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

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DataGridView1.RowsDefaultCellStyle
            Me.DataGridView1.Columns(0).Width = 70
            Me.DataGridView1.Columns(0).HeaderText = "Id"
            Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(1).Width = 90
            Me.DataGridView1.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(29).Width = 80
            Me.DataGridView1.Columns(29).HeaderText = "Consecutivo"
            Me.DataGridView1.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(2).Width = 240
            Me.DataGridView1.Columns(2).HeaderText = "Nombre Completo"
            Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(3).Width = 90
            Me.DataGridView1.Columns(3).HeaderText = "Fecha de Compra"
            Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(10).Width = 50
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
            Me.DataGridView1.Columns(15).HeaderText = "Gramos Puros"
            Me.DataGridView1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(15).DefaultCellStyle.Format = "N2"

            Me.DataGridView1.Columns(19).Width = 130
            Me.DataGridView1.Columns(19).HeaderText = "Valor Cancelado"
            Me.DataGridView1.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(19).DefaultCellStyle.Format = "C2"

            Me.DataGridView1.Columns(27).Width = 100
            Me.DataGridView1.Columns(27).HeaderText = "Mes de Compra"
            Me.DataGridView1.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(28).Width = 100
            Me.DataGridView1.Columns(28).HeaderText = "Año de Compra"
            Me.DataGridView1.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DataGridView1.Columns("Id").Visible = False              '0
            'Me.DataGridView1.Columns("cedu_com").Visible = False         '1
            'Me.DataGridView1.Columns("nom_com").Visible = False          '2
            'Me.DataGridView1.Columns("fecha_com").Visible = False        '3
            Me.DataGridView1.Columns("dire_com").Visible = False         '4
            Me.DataGridView1.Columns("telc_com").Visible = False         '5
            Me.DataGridView1.Columns("correo_com").Visible = False       '6
            Me.DataGridView1.Columns("dpto_com").Visible = False         '7
            Me.DataGridView1.Columns("rut_com").Visible = False          '8
            Me.DataGridView1.Columns("act_com").Visible = False          '9
            'Me.DataGridView1.Columns("metal_com").Visible = False       '10
            Me.DataGridView1.Columns("conce_com").Visible = False       '11
            Me.DataGridView1.Columns("ciuddpto").Visible = False        '12
            'Me.DataGridView1.Columns("grbrutos").Visible = False        '13
            'Me.DataGridView1.Columns("ley").Visible = False             '14
            'Me.DataGridView1.Columns("grpuros").Visible = False         '15
            Me.DataGridView1.Columns("base").Visible = False            '16
            Me.DataGridView1.Columns("regala").Visible = False          '17
            Me.DataGridView1.Columns("totalretef").Visible = False      '18
            'Me.DataGridView1.Columns("vrventa").Visible = False         '19
            Me.DataGridView1.Columns("fechatasa").Visible = False       '20
            Me.DataGridView1.Columns("mestasa").Visible = False         '21
            Me.DataGridView1.Columns("retevalor").Visible = False       '22
            Me.DataGridView1.Columns("gp_rg").Visible = False           '23
            Me.DataGridView1.Columns("gp_base").Visible = False         '24
            Me.DataGridView1.Columns("valorgrrete").Visible = False     '25
            Me.DataGridView1.Columns("pagobare").Visible = False        '26
            'Me.DataGridView1.Columns("mes_com").Visible = False         '27
            'Me.DataGridView1.Columns("año_com").Visible = False         '28
            'Me.DataGridView1.Columns("consecutivo").Visible = False    '29
            Me.DataGridView1.Columns("fecha_creado").Visible = False    '30
            Me.DataGridView1.Columns("fecha_modifica").Visible = False  '31
            Me.DataGridView1.Columns("letras").Visible = False          '32
            Me.DataGridView1.Columns("detallemineral").Visible = False  '33
            Me.DataGridView1.Columns("verifica").Visible = False        '34
            Me.DataGridView1.Columns("numfundi").Visible = False        '35

        End With

    End Sub

    'BOTON DE  IMPRIMIR
    Private Sub BtnImpAse1_Click(sender As Object, e As EventArgs) Handles BtnImpTD.Click
        'manejo del cursor
        Cursor = Cursors.WaitCursor

        FrmRptAcumCliente.TxtClientes.Text = Me.Txtced_cl.Text
        FrmRptAcumCliente.TextBox1.Text = Me.DTPinicial.Value
        FrmRptAcumCliente.TextBox2.Text = Me.DTPfinal.Value
        FrmRptAcumCliente.ShowDialog()

        'manejo del cursor
        Cursor = Cursors.Default

    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class