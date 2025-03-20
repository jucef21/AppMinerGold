Imports System.Data.OleDb

Public Class FrmSeleEgresoReimp

    'CARGUE DEL FORMULARIO
    Private Sub FrmSeleEgresoReimp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.TxtDocIngreso.Clear()
        Me.TxtDocIngreso.Focus()
        Me.TxtDocIngreso.Enabled = True

        'limpio el datagrid
        Me.DGVreimpEgreso.ClearSelection()
        Me.DGVreimpEgreso.DataSource = Nothing
        Me.DGVreimpEgreso.Columns.Clear()
        Me.DGVreimpEgreso.Enabled = True

        'activo los botones
        Me.BtnDocIngreso.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.TxtDocIngreso.Select()
        Me.TxtDocIngreso.Focus()

    End Sub

    'BOTON DE  DE DOCUEMNTO DE INGRESO
    Private Sub BtnDocIngreso_Click(sender As Object, e As EventArgs) Handles BtnDocIngreso.Click
        Try
            'manejo dekl cursor
            Me.Cursor = Cursors.WaitCursor

            'lleno los datos al datagrid
            If FiltroDeclara(Me.TxtDocIngreso.Text).Rows.Count > 0 Then
                DGVreimpEgreso.DataSource = FiltroDeclara(Me.TxtDocIngreso.Text)
                MsgBox("Busqueda Encontrada, Aceptar para Imprimir", MsgBoxStyle.Information, "AppMinerGold")

                'Envio el numero de docuemnto buscado al reporte
                FrmReimprimeEgreso.TxtConsecutivo.Text = TxtDocIngreso.Text
                FrmReimprimeEgreso.TxtCedula.Text = DGVreimpEgreso.CurrentRow.Cells(1).Value

                'llamo  el form
                FrmReimprimeEgreso.Show()

                'Inhabilito el boton
                Me.TxtDocIngreso.Enabled = False
                Me.DGVreimpEgreso.Enabled = False
                Me.BtnDocIngreso.Enabled = False

            Else
                MsgBox("No se encontro ningún Registro de Ingreso, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")
                'limpio y ubico el cursor
                Me.TxtDocIngreso.Text = ""
                Me.TxtDocIngreso.Select()
                Me.TxtDocIngreso.Focus()
            End If

            'manejo dekl cursor
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox("No existe Registro de Ingreso, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")

            'limpio y ubico el cursor
            Me.TxtDocIngreso.Text = ""
            Me.TxtDocIngreso.Select()
            Me.TxtDocIngreso.Focus()
        End Try

    End Sub

    'FUNCION DE FILTRAR NUMERO DE DOCUMENTO DE INGRESO
    Function FiltroDeclara(ByVal busqueda As String) As DataTable
        conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        'Dim da As New OleDbDataAdapter("SELECT TOP 1 * FROM Clientes WHERE nom_cl LIKE '" & busqueda.Trim & "%' ORDER BY id DESC", conn)
        Dim da As New OleDbDataAdapter("SELECT * FROM Declara WHERE consecutivo LIKE '" & busqueda.Trim & "%' ORDER BY consecutivo ASC", conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Declara")
        DGVreimpEgreso.DataSource = dv
        conn.Close()
        Return dt
    End Function

#Region "DATAGRIDVIEW INGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVreimpEgreso_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpEgreso.CellFormatting

        'activo el datagrid
        Me.DGVreimpEgreso.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVreimpEgreso.EnableHeadersVisualStyles = False
        With DGVreimpEgreso.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpEgreso.RowsDefaultCellStyle
            Me.DGVreimpEgreso.Columns(0).Width = 70
            Me.DGVreimpEgreso.Columns(0).HeaderText = "Id"
            Me.DGVreimpEgreso.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpEgreso.Columns(1).Width = 80
            Me.DGVreimpEgreso.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DGVreimpEgreso.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpEgreso.Columns(2).Width = 240
            Me.DGVreimpEgreso.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVreimpEgreso.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpEgreso.Columns(3).Width = 100
            Me.DGVreimpEgreso.Columns(3).HeaderText = "Fecha de Compra"
            Me.DGVreimpEgreso.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpEgreso.Columns(10).Width = 50
            Me.DGVreimpEgreso.Columns(10).HeaderText = "Metal"
            Me.DGVreimpEgreso.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpEgreso.Columns(11).Width = 80
            Me.DGVreimpEgreso.Columns(11).HeaderText = "Gramos Brutos"
            Me.DGVreimpEgreso.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpEgreso.Columns(11).DefaultCellStyle.Format = "N2"

            Me.DGVreimpEgreso.Columns(12).Width = 80
            Me.DGVreimpEgreso.Columns(12).HeaderText = "Ley"
            Me.DGVreimpEgreso.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpEgreso.Columns(12).DefaultCellStyle.Format = "N2"

            Me.DGVreimpEgreso.Columns(13).Width = 100
            Me.DGVreimpEgreso.Columns(13).HeaderText = "Gramos Puros"
            Me.DGVreimpEgreso.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpEgreso.Columns(13).DefaultCellStyle.Format = "N2"

            Me.DGVreimpEgreso.Columns(25).Width = 150
            Me.DGVreimpEgreso.Columns(25).HeaderText = "Valor Cancelado"
            Me.DGVreimpEgreso.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVreimpEgreso.Columns(25).DefaultCellStyle.Format = "C2"

            Me.DGVreimpEgreso.Columns(19).Width = 100
            Me.DGVreimpEgreso.Columns(19).HeaderText = "Mes de Compra"
            Me.DGVreimpEgreso.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpEgreso.Columns(20).Width = 100
            Me.DGVreimpEgreso.Columns(20).HeaderText = "Año de Compra"
            Me.DGVreimpEgreso.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DGVreimpEgreso.Columns(20).DefaultCellStyle.Format = "C2"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVreimpEgreso.Columns("Id").Visible = False              '0
            'Me.DGVreimpEgreso.Columns("cedu_com").Visible = False         '1
            'Me.DGVreimpEgreso.Columns("nom_com").Visible = False          '2
            'Me.DGVreimpEgreso.Columns("fecha_com").Visible = False        '3
            Me.DGVreimpEgreso.Columns("dire_com").Visible = False         '4
            Me.DGVreimpEgreso.Columns("telc_com").Visible = False         '5
            Me.DGVreimpEgreso.Columns("correo_com").Visible = False       '6
            Me.DGVreimpEgreso.Columns("dpto_com").Visible = False         '7
            Me.DGVreimpEgreso.Columns("rut_com").Visible = False          '8
            Me.DGVreimpEgreso.Columns("act_com").Visible = False          '9
            'Me.DGVreimpEgreso.Columns("metal_com").Visible = False       '10
            'Me.DGVreimpEgreso.Columns("grbrutos").Visible = False        '11
            'Me.DGVreimpEgreso.Columns("ley").Visible = False             '12
            'Me.DGVreimpEgreso.Columns("grpuros").Visible = False         '13
            Me.DGVreimpEgreso.Columns("base").Visible = False             '14
            Me.DGVreimpEgreso.Columns("regala").Visible = False           '15
            Me.DGVreimpEgreso.Columns("vrventa").Visible = False          '16
            Me.DGVreimpEgreso.Columns("conce_com").Visible = False        '17
            Me.DGVreimpEgreso.Columns("ciuddpto").Visible = False         '18
            'Me.DGVreimpEgreso.Columns("mes_com").Visible = False          '19
            'Me.DGVreimpEgreso.Columns("año_com").Visible = False          '20
            Me.DGVreimpEgreso.Columns("consecutivo").Visible = False      '21
            Me.DGVreimpEgreso.Columns("fecha_creado").Visible = False     '22
            Me.DGVreimpEgreso.Columns("fecha_modifica").Visible = False   '23
            Me.DGVreimpEgreso.Columns("gp_rg").Visible = False            '24
            'Me.DGVreimpEgreso.Columns("gp_base").Visible = False          '25
            Me.DGVreimpEgreso.Columns("letras").Visible = False           '26
            Me.DGVreimpEgreso.Columns("detallemineral").Visible = False   '27
            Me.DGVreimpEgreso.Columns("verifica").Visible = False         '28
            Me.DGVreimpEgreso.Columns("numfundi").Visible = False         '29

        End With

    End Sub

    Private Sub TxtDocIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocIngreso.KeyPress
        SoloNumeros(e)
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


End Class