Imports System.Data.OleDb

Public Class FrmSeleCertificadoRF

    'CARGUE DEL FORMULARIO
    Private Sub FrmSeleCertificadoRF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        VerCiudad()

        'limpio los campos
        Me.TxtBuscar.Clear()
        Me.TxtBuscar.Focus()
        Me.TxtBuscar.Enabled = True

        'limpio el datagrid
        Me.DGVimpRF.ClearSelection()
        Me.DGVimpRF.DataSource = Nothing
        Me.DGVimpRF.Columns.Clear()
        Me.DGVimpRF.Enabled = True

        'activo los botones
        Me.BtnDocIngreso.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

    End Sub

    'BOTON DE  DE DOCUEMNTO DE INGRESO
    Private Sub BtnDocIngreso_Click(sender As Object, e As EventArgs) Handles BtnDocIngreso.Click
        Try
            'manejo del cursor
            Me.Cursor = Cursors.WaitCursor

            'lleno los datos al datagrid
            If FiltroDeclara(Me.TxtBuscar.Text).Rows.Count > 0 Then
                DGVimpRF.DataSource = FiltroDeclara(Me.TxtBuscar.Text)
                MessageBox.Show("Busqueda Encontrada, Aceptar para Imprimir", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Envio el numero de docuemnto buscado al reporte
                FrmRptCertiRF.TxtConsecutivo.Text = TxtBuscar.Text
                'ModuleFrm.VerCiudad = Me.TxtEmpCiu.Text
                FrmRptCertiRF.TxtVerCiudImp.Text = Me.TxtEmpCiu.Text
                FrmRptCertiRF.ShowDialog()

                'Inhabilito el boton
                Me.TxtBuscar.Enabled = False
                Me.DGVimpRF.Enabled = False
                Me.BtnDocIngreso.Enabled = False
            Else
                MessageBox.Show("No se encontro ningún Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'limpio y ubico el cursor
                Me.TxtBuscar.Text = ""
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Focus()
            End If
            'manejo del cursor
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox("No existe Registro de Ingreso, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")
            'limpio y ubico el cursor
            Me.TxtBuscar.Text = ""
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
            'manejo del cursor
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    'FUNCION DE FILTRAR NUMERO DE DOCUMENTO DE INGRESO
    Function FiltroDeclara(ByVal busqueda As String) As DataTable
        Dim NumConse As Integer = CInt(TxtBuscar.Text)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM declara WHERE consecutivo =" & NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Declara")
        DGVimpRF.DataSource = dv
        Return dt
    End Function

    'PROCEDIMIENTO PARA UNIR NOMBRE Y APELLIDO DEL CLIENTE
    Private Sub VerCiudad()
        Dim dt As New DataTable
        'revisamos la conexin a la base de datos
        If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            Conectar.conn.Close()
        End If
        Dim consulta As String = "SELECT * FROM Empresa"
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)
        Dim drd As OleDbDataReader
        Conectar.conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            Me.TxtEmpCiu.Text = drd.Item("ciudad").ToString
        Else
            MsgBox("No se encontro CIUDAD", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
        Conectar.conn.Close()
    End Sub

#Region "DATAGRIDVIEW INGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVimpRF_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVimpRF.CellFormatting

        'activo el datagrid
        Me.DGVimpRF.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVimpRF.EnableHeadersVisualStyles = False
        With DGVimpRF.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVimpRF.RowsDefaultCellStyle
            Me.DGVimpRF.Columns(0).Width = 70
            Me.DGVimpRF.Columns(0).HeaderText = "Id"
            Me.DGVimpRF.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVimpRF.Columns(1).Width = 80
            Me.DGVimpRF.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DGVimpRF.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVimpRF.Columns(2).Width = 240
            Me.DGVimpRF.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVimpRF.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVimpRF.Columns(3).Width = 100
            Me.DGVimpRF.Columns(3).HeaderText = "Fecha de Compra"
            Me.DGVimpRF.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVimpRF.Columns(19).Width = 80
            Me.DGVimpRF.Columns(19).HeaderText = "Valor de la Compra"
            Me.DGVimpRF.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVimpRF.Columns(19).DefaultCellStyle.Format = "N2"

            Me.DGVimpRF.Columns(23).Width = 80
            Me.DGVimpRF.Columns(23).HeaderText = "Valor Regalias"
            Me.DGVimpRF.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVimpRF.Columns(23).DefaultCellStyle.Format = "N2"

            Me.DGVimpRF.Columns(18).Width = 100
            Me.DGVimpRF.Columns(18).HeaderText = "Valor Retefuente"
            Me.DGVimpRF.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVimpRF.Columns(18).DefaultCellStyle.Format = "N2"

            Me.DGVimpRF.Columns(26).Width = 150
            Me.DGVimpRF.Columns(26).HeaderText = "Valor Cancelado"
            Me.DGVimpRF.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVimpRF.Columns(26).DefaultCellStyle.Format = "C2"

            Me.DGVimpRF.Columns(20).Width = 100
            Me.DGVimpRF.Columns(20).HeaderText = "Año de Compra"
            Me.DGVimpRF.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DGVreimpEqui.Columns(20).DefaultCellStyle.Format = "C2"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVimpRF.Columns("Id").Visible = False              '0
            'Me.DGVimpRF.Columns("cedu_com").Visible = False        '1
            'Me.DGVimpRF.Columns("nom_com").Visible = False         '2
            'Me.DGVimpRF.Columns("fecha_com").Visible = False       '3
            Me.DGVimpRF.Columns("dire_com").Visible = False         '4
            Me.DGVimpRF.Columns("telc_com").Visible = False         '5
            Me.DGVimpRF.Columns("correo_com").Visible = False       '6
            Me.DGVimpRF.Columns("dpto_com").Visible = False         '7
            Me.DGVimpRF.Columns("rut_com").Visible = False          '8
            Me.DGVimpRF.Columns("act_com").Visible = False          '9
            Me.DGVimpRF.Columns("metal_com").Visible = False       '10
            Me.DGVimpRF.Columns("conce_com").Visible = False       '11
            Me.DGVimpRF.Columns("ciuddpto").Visible = False        '12
            Me.DGVimpRF.Columns("grbrutos").Visible = False        '13
            Me.DGVimpRF.Columns("ley").Visible = False             '14
            Me.DGVimpRF.Columns("grpuros").Visible = False         '15
            Me.DGVimpRF.Columns("base").Visible = False            '16
            Me.DGVimpRF.Columns("regala").Visible = False          '17
            'Me.DGVimpRF.Columns("totalretef").Visible = False      '18
            'Me.DGVimpRF.Columns("vrventa").Visible = False         '19
            Me.DGVimpRF.Columns("fechatasa").Visible = False       '20
            Me.DGVimpRF.Columns("mestasa").Visible = False         '21
            Me.DGVimpRF.Columns("retevalor").Visible = False       '22
            'Me.DGVimpRF.Columns("gp_rg").Visible = False           '23
            Me.DGVimpRF.Columns("gp_base").Visible = False         '24
            Me.DGVimpRF.Columns("valorgrrete").Visible = False     '25
            'Me.DGVimpRF.Columns("pagobare").Visible = False        '26
            Me.DGVimpRF.Columns("mes_com").Visible = False         '27
            Me.DGVimpRF.Columns("año_com").Visible = False         '28
            Me.DGVimpRF.Columns("consecutivo").Visible = False    '29
            Me.DGVimpRF.Columns("fecha_creado").Visible = False    '30
            Me.DGVimpRF.Columns("fecha_modifica").Visible = False  '31
            Me.DGVimpRF.Columns("letras").Visible = False          '32
            Me.DGVimpRF.Columns("detallemineral").Visible = False  '33
            Me.DGVimpRF.Columns("verifica").Visible = False        '34
            Me.DGVimpRF.Columns("numfundi").Visible = False        '35
            Me.DGVimpRF.Columns("formapago").Visible = False       '36
            Me.DGVimpRF.Columns("numtarjeta").Visible = False      '37
            Me.DGVimpRF.Columns("selebancos").Visible = False      '38
            Me.DGVimpRF.Columns("prefijo").Visible = False         '39
            Me.DGVimpRF.Columns("ConseQr").Visible = False         '40
            Me.DGVimpRF.Columns("tipoop").Visible = False          '41
            Me.DGVimpRF.Columns("tipodocu").Visible = False        '42
            Me.DGVimpRF.Columns("comOro").Visible = False          '43
            Me.DGVimpRF.Columns("comPlatino").Visible = False      '44
            Me.DGVimpRF.Columns("comPlata").Visible = False        '45
            Me.DGVimpRF.Columns("Ciudad").Visible = False          '46
            Me.DGVimpRF.Columns("dpto").Visible = False            '47

        End With

    End Sub

    'EVENTO KEYPRESS
    Private Sub TxtDocIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress
        SoloNumeros(e)
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


End Class