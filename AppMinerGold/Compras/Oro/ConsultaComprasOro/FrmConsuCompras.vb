Imports System.Data.OleDb

Public Class FrmConsuCompras

    'CARGUE DEL FORMULARIO
    Private Sub FrmConsuCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ubicamos el cursor
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Text = ""
        Me.BtnBuscar.Select()
        Me.BtnBuscar.Focus()

        'actualizo la fecha en los calendarios
        DTPinicial.Format = DateTimePickerFormat.Custom
        DTPinicial.CustomFormat = "dd/MM/yyyy"
        DTPfinal.Format = DateTimePickerFormat.Custom
        DTPfinal.CustomFormat = "dd/MM/yyyy"

        'DTPinicial.Value = Date.Now.ToString("d")
        DTPinicial.Value = Date.Now.AddDays(-Now.Day + 1).AddDays(+1).AddMonths(+1).AddYears(-1)   '.AddYears(-1).AddMonths(1).AddDays(-1)

        DTPfinal.MaxDate = DateTime.Today
        'DTPfinal.Value = Date.Now.ToString("d")

        'Limpio Datagrid
        Me.DGVprov.DataSource = Nothing

        'limpio  el label
        Me.LblModReg.Text = ""

        'Habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = False


    End Sub


#Region "PROCEDIMIENTOS PARA FILTRAR POR NOMBRE EN EL DATAGRID"

    'FUNCION DE FILTRAR NUMERO DE DOCUMENTO DE INGRESO
    Function LLenaCompras()
        Dim da As OleDbDataAdapter
        Dim dt As DataTable
        conn.ConnectionString = cs
        Dim Numcedullena As Integer = CInt(TxtBuscar.Text)
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)   '= DTP_FechaF.Value.Date
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)  '= DTP_FechaI.Value.Date
        Try
            da = New OleDbDataAdapter("SELECT declara.*
                                       From  declara
                                       INNER JOIN clientes
                                       ON declara.cedu_com = clientes.ced_cl
                                       WHERE declara.fecha_creado BETWEEN @starDate AND @enddate and declara.cedu_com = " & Numcedullena, conn)
            With da.SelectCommand.Parameters
                .AddWithValue("@starDate", hugh)
                .AddWithValue("@endDate", hugh2)
            End With
            dt = New DataTable
            da.Fill(dt)
            Me.DGVprov.DataSource = dt
            'muestro la cantidad de registros encontrados
            LblModReg.Text = dt.Rows.Count
            '===
            'VERIFICA SI HAY DIAS EN VACIO O SIN OPRACION DE UNA DATAGRIDVIEW
            'SUMA GRAMOS PUROS
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            'Dim dt As DataTable = DirectCast(DGVprov.DataSource, DataTable)
            dt = DirectCast(DGVprov.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultado As Object = dt.Compute("Sum(grpuros)", Nothing)
            TextBox1.Text = String.Format("{0:N2}", resultado)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultado = dt.Compute("Sum(grpuros)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            TextBox3.Text = String.Format("{0:N2}", resultado)

            'SUMA GRAMOS BRUTOS
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dtB As DataTable = DirectCast(DGVprov.DataSource, DataTable)
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
                Me.BtnLimpiar.Select()
                Me.BtnLimpiar.Focus()
            End Try

            ''Sumar una Columna VALOR CANCELADO
            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dt1 As DataTable = DirectCast(DGVprov.DataSource, DataTable)
            ' Sumamos todas las filas de la columna TotalFactura.
            Dim resultado1 As Object = dt1.Compute("Sum(vrventa)", Nothing)
            TextBox2.Text = String.Format("{0:N2}", resultado1)
            ' Sumamos todas las filas de la columna grpuros donde el campo Fecha esté comprendido entre el día ' 01/02/2011 y 28/02/2011.
            resultado1 = dt1.Compute("Sum(vrventa)", "fecha_creado >= '" & DTPinicial.Value & "' And fecha_creado <= '" & DTPfinal.Value & "'")
            'TextBox3.Text = String.Format("{0:N2}", resultado1)
        Catch ex As Exception
            MessageBox.Show("No se lleno la consulta debido a: " + ex.ToString, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Limpiar_Cajas()
            'limpio y ubico el cursor
            Me.TxtBuscar.Text = ""
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
            'Habilito los botones
            Me.BtnBuscar.Enabled = False

        End Try
        Return Numcedullena
    End Function

    'CAMPO TEXTO DE BUSCAR
    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        Me.BtnBuscar.Show()
    End Sub

    'FORMATO DEL DATADRIG 
    Private Sub DGVprov_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVprov.CellFormatting
        'activo el datagrid
        Me.DGVprov.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVprov.EnableHeadersVisualStyles = False
        With DGVprov.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVprov.RowsDefaultCellStyle
            Me.DGVprov.Columns(0).Width = 70
            Me.DGVprov.Columns(0).HeaderText = "Id"
            Me.DGVprov.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVprov.Columns(1).Width = 90
            Me.DGVprov.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DGVprov.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVprov.Columns(29).Width = 80
            Me.DGVprov.Columns(29).HeaderText = "Consecutivo"
            Me.DGVprov.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVprov.Columns(2).Width = 240
            Me.DGVprov.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVprov.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVprov.Columns(3).Width = 90
            Me.DGVprov.Columns(3).HeaderText = "Fecha de Compra"
            Me.DGVprov.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVprov.Columns(10).Width = 50
            Me.DGVprov.Columns(10).HeaderText = "Metal"
            Me.DGVprov.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVprov.Columns(13).Width = 80
            Me.DGVprov.Columns(13).HeaderText = "Gramos Brutos"
            Me.DGVprov.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVprov.Columns(13).DefaultCellStyle.Format = "N2"

            Me.DGVprov.Columns(14).Width = 60
            Me.DGVprov.Columns(14).HeaderText = "Ley"
            Me.DGVprov.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVprov.Columns(14).DefaultCellStyle.Format = "N4"

            Me.DGVprov.Columns(15).Width = 80
            Me.DGVprov.Columns(15).HeaderText = "Gramos Puros"
            Me.DGVprov.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVprov.Columns(15).DefaultCellStyle.Format = "N2"

            Me.DGVprov.Columns(19).Width = 130
            Me.DGVprov.Columns(19).HeaderText = "Valor Cancelado"
            Me.DGVprov.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVprov.Columns(19).DefaultCellStyle.Format = "C2"

            Me.DGVprov.Columns(27).Width = 100
            Me.DGVprov.Columns(27).HeaderText = "Mes de Compra"
            Me.DGVprov.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVprov.Columns(28).Width = 100
            Me.DGVprov.Columns(28).HeaderText = "Año de Compra"
            Me.DGVprov.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVprov.Columns("Id").Visible = False              '0
            'Me.DGVprov.Columns("cedu_com").Visible = False         '1
            'Me.DGVprov.Columns("nom_com").Visible = False          '2
            'Me.DGVprov.Columns("fecha_com").Visible = False        '3
            Me.DGVprov.Columns("dire_com").Visible = False         '4
            Me.DGVprov.Columns("telc_com").Visible = False         '5
            Me.DGVprov.Columns("correo_com").Visible = False       '6
            Me.DGVprov.Columns("dpto_com").Visible = False         '7
            Me.DGVprov.Columns("rut_com").Visible = False          '8
            Me.DGVprov.Columns("act_com").Visible = False          '9
            'Me.DGVprov.Columns("metal_com").Visible = False      '10
            Me.DGVprov.Columns("conce_com").Visible = False       '11
            Me.DGVprov.Columns("ciuddpto").Visible = False        '12
            'Me.DGVprov.Columns("grbrutos").Visible = False       '13
            'Me.DGVprov.Columns("ley").Visible = False            '14
            'Me.DGVprov.Columns("grpuros").Visible = False         '15
            Me.DGVprov.Columns("base").Visible = False            '16
            Me.DGVprov.Columns("regala").Visible = False          '17
            Me.DGVprov.Columns("totalretef").Visible = False      '18
            'Me.DGVprov.Columns("vrventa").Visible = False        '19
            Me.DGVprov.Columns("fechatasa").Visible = False       '20
            Me.DGVprov.Columns("mestasa").Visible = False         '21
            Me.DGVprov.Columns("retevalor").Visible = False       '22
            Me.DGVprov.Columns("gp_rg").Visible = False           '23
            Me.DGVprov.Columns("gp_base").Visible = False         '24
            Me.DGVprov.Columns("valorgrrete").Visible = False     '25
            Me.DGVprov.Columns("pagobare").Visible = False        '26
            'Me.DGVprov.Columns("mes_com").Visible = False        '27
            'Me.DGVprov.Columns("año_com").Visible = False        '28
            'Me.DGVprov.Columns("consecutivo").Visible = False    '29
            Me.DGVprov.Columns("fecha_creado").Visible = False    '30
            Me.DGVprov.Columns("fecha_modifica").Visible = False  '31
            Me.DGVprov.Columns("letras").Visible = False          '32
            Me.DGVprov.Columns("detallemineral").Visible = False  '33
            Me.DGVprov.Columns("verifica").Visible = False        '34
            Me.DGVprov.Columns("numfundi").Visible = False        '35
            Me.DGVprov.Columns("formapago").Visible = False       '36
            Me.DGVprov.Columns("numtarjeta").Visible = False      '37
            Me.DGVprov.Columns("selebancos").Visible = False      '38
            Me.DGVprov.Columns("prefijo").Visible = False         '39
            Me.DGVprov.Columns("ConseQr").Visible = False         '40
            Me.DGVprov.Columns("tipoop").Visible = False          '41
            Me.DGVprov.Columns("tipodocu").Visible = False        '42
            Me.DGVprov.Columns("comOro").Visible = False          '43
            Me.DGVprov.Columns("comPlatino").Visible = False      '44
            Me.DGVprov.Columns("comPlata").Visible = False        '45
            Me.DGVprov.Columns("ciudad").Visible = False          '46
            Me.DGVprov.Columns("dpto").Visible = False            '47

        End With

    End Sub

#End Region

#Region "BOTONES DEL FORMULARIO"

    'BOTON BUSCAR
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'verifico el campo vacio
        If Me.TxtBuscar.Text = "" Then
            MessageBox.Show("Para hacer una Consulta debe Digitar la Cédula de Cliente...! ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Ubico el cursor
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
            'Habilito los botones
            Me.BtnBuscar.Enabled = True
            Me.BtnLimpiar.Enabled = False

        Else
            'manejo del cursor
            Me.Cursor = Cursors.WaitCursor

            LLenaCompras()

            'Habilito los botones
            Me.BtnBuscar.Enabled = False
            Me.BtnLimpiar.Enabled = True

            Me.TxtBuscar.Enabled = False

            'inhabilito fechas
            Me.DTPinicial.Enabled = False
            Me.DTPfinal.Enabled = False

            'Inhabilito el datagrig para ediccion
            Me.DGVprov.Enabled = True

            'manejo del cursor
            Me.Cursor = Cursors.Default
        End If
        'manejo del cursor
        Me.Cursor = Cursors.Default

    End Sub

    'BOTON LIMPIAR
    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click

        'limpio el datagrid
        DGVprov.ClearSelection()
        DGVprov.DataSource = Nothing
        DGVprov.Columns.Clear()

        'ubico el cursor
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Text = ""
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

        'habilitamos el boton
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = False


        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TextBox4.Clear()
        Me.TextBox5.Clear()

        'limpio  el label
        Me.LblModReg.Text = ""

        'actualizo la fecha en los calendarios
        DTPinicial.Value = Date.Now.ToString("d")
        DTPfinal.Value = Date.Now.ToString("d")

        'actualizo la fecha en los calendarios
        DTPinicial.Enabled = True
        DTPfinal.Enabled = True

    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "Limpieza de Campos"

    'limpia las cajas de texto
    Private Sub Limpiar_Cajas()
        ' recorrer todos los controles del formulario indicado  
        'limpio el datagrid
        'DGVconsupagos.Rows.Clear()                          'para limpiarlo
        DGVprov.DataSource = Nothing
        Me.TxtBuscar.Text = ""

        'limpia texto
        Me.TxtBuscar.Clear()

    End Sub

    'valida solo letras
    Private Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress
        'valida solo numeros
        SoloNumeros(e)

    End Sub

#End Region

End Class