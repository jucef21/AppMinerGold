Imports System.Data.OleDb
Public Class FrmSelectLiquidacion

    'CARGUE DEL FORMULARIO
    Private Sub FrmSelectLiquidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.TxtDocLiquidacion.Clear()
        Me.TxtDocLiquidacion.Focus()
        Me.TxtDocLiquidacion.Enabled = True

        'limpio el datagrid
        Me.DGVreimpLiquidacion.ClearSelection()
        Me.DGVreimpLiquidacion.DataSource = Nothing
        Me.DGVreimpLiquidacion.Columns.Clear()
        Me.DGVreimpLiquidacion.Enabled = True

        'activo los botones
        Me.BtnDocLiquidacion.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.TxtDocLiquidacion.Select()
        Me.TxtDocLiquidacion.Focus()

    End Sub

    'BOTON DE  DE DOCUEMNTO DE INGRESO
    Private Sub BtnDocCertifica_Click(sender As Object, e As EventArgs) Handles BtnDocLiquidacion.Click
        Try
            'manejo dekl cursor
            Me.Cursor = Cursors.WaitCursor

            'lleno los datos al datagrid
            If FiltroDeclara(Me.TxtDocLiquidacion.Text).Rows.Count > 0 Then
                DGVreimpLiquidacion.DataSource = FiltroDeclara(Me.TxtDocLiquidacion.Text)
                MessageBox.Show("Busqueda Encontrada, Aceptar para Imprimir", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Envio el numero de docuemnto buscado al reporte
                FrmActaLiquidacion.TxtConsecutivo.Text = TxtDocLiquidacion.Text
                FrmActaLiquidacion.TxtCedula.Text = DGVreimpLiquidacion.CurrentRow.Cells(1).Value
                FrmActaLiquidacion.ShowDialog()

                'Inhabilito el boton
                Me.TxtDocLiquidacion.Enabled = False
                Me.DGVreimpLiquidacion.Enabled = False
                Me.BtnDocLiquidacion.Enabled = False

            Else
                MessageBox.Show("No se encontro ningún Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'limpio y ubico el cursor
                Me.TxtDocLiquidacion.Text = ""
                Me.TxtDocLiquidacion.Select()
                Me.TxtDocLiquidacion.Focus()
            End If

            'manejo dekl cursor
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("No existe Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            'limpio y ubico el cursor
            Me.TxtDocLiquidacion.Text = ""
            Me.TxtDocLiquidacion.Select()
            Me.TxtDocLiquidacion.Focus()
        End Try

    End Sub

    'FUNCION DE FILTRAR NUMERO DE DOCUMENTO DE INGRESO
    Function FiltroDeclara(ByVal busqueda As String) As DataTable

        Dim dt As New DataTable

        If String.IsNullOrWhiteSpace(busqueda) Then
            Return dt
        End If

        Dim NumContrato As Integer

        If Not Integer.TryParse(busqueda, NumContrato) Then
            MsgBox("Ingrese un número de consecutivo válido.")
            Return dt
        End If

        Try
            conn.Open()

            Dim sql As String = "SELECT * FROM Declara WHERE consecutivo = ? AND nom_com <> 'ANULADO'"

            Using cmd As New OleDbCommand(sql, conn)
                cmd.Parameters.AddWithValue("@consecutivo", NumContrato)

                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            DGVreimpLiquidacion.DataSource = dt

        Catch ex As Exception
            MsgBox("Error al realizar la búsqueda: " & ex.Message)

        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Return dt

    End Function

#Region "DATAGRIDVIEW INGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVreimpCertifica_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpLiquidacion.CellFormatting

        'activo el datagrid
        Me.DGVreimpLiquidacion.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVreimpLiquidacion.EnableHeadersVisualStyles = False
        With DGVreimpLiquidacion.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpLiquidacion.RowsDefaultCellStyle
            Me.DGVreimpLiquidacion.Columns(0).Width = 70
            Me.DGVreimpLiquidacion.Columns(0).HeaderText = "Id"
            Me.DGVreimpLiquidacion.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpLiquidacion.Columns(1).Width = 80
            Me.DGVreimpLiquidacion.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DGVreimpLiquidacion.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpLiquidacion.Columns(2).Width = 240
            Me.DGVreimpLiquidacion.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVreimpLiquidacion.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpLiquidacion.Columns(3).Width = 100
            Me.DGVreimpLiquidacion.Columns(3).HeaderText = "Fecha de Compra"
            Me.DGVreimpLiquidacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpLiquidacion.Columns(10).Width = 50
            Me.DGVreimpLiquidacion.Columns(10).HeaderText = "Metal"
            Me.DGVreimpLiquidacion.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpLiquidacion.Columns(11).Width = 80
            Me.DGVreimpLiquidacion.Columns(11).HeaderText = "Gramos Brutos"
            Me.DGVreimpLiquidacion.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpLiquidacion.Columns(11).DefaultCellStyle.Format = "N2"

            Me.DGVreimpLiquidacion.Columns(12).Width = 80
            Me.DGVreimpLiquidacion.Columns(12).HeaderText = "Ley"
            Me.DGVreimpLiquidacion.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpLiquidacion.Columns(12).DefaultCellStyle.Format = "N2"

            Me.DGVreimpLiquidacion.Columns(13).Width = 100
            Me.DGVreimpLiquidacion.Columns(13).HeaderText = "Gramos Puros"
            Me.DGVreimpLiquidacion.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpLiquidacion.Columns(13).DefaultCellStyle.Format = "N2"

            Me.DGVreimpLiquidacion.Columns(25).Width = 150
            Me.DGVreimpLiquidacion.Columns(25).HeaderText = "Valor Cancelado"
            Me.DGVreimpLiquidacion.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVreimpLiquidacion.Columns(25).DefaultCellStyle.Format = "C2"

            Me.DGVreimpLiquidacion.Columns(19).Width = 100
            Me.DGVreimpLiquidacion.Columns(19).HeaderText = "Mes de Compra"
            Me.DGVreimpLiquidacion.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpLiquidacion.Columns(20).Width = 100
            Me.DGVreimpLiquidacion.Columns(20).HeaderText = "Año de Compra"
            Me.DGVreimpLiquidacion.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DGVreimpEgreso.Columns(20).DefaultCellStyle.Format = "C2"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVreimpEgreso.Columns("Id").Visible = False              '0
            'Me.DGVreimpEgreso.Columns("cedu_com").Visible = False         '1
            'Me.DGVreimpEgreso.Columns("nom_com").Visible = False          '2
            'Me.DGVreimpEgreso.Columns("fecha_com").Visible = False        '3
            Me.DGVreimpLiquidacion.Columns("dire_com").Visible = False         '4
            Me.DGVreimpLiquidacion.Columns("telc_com").Visible = False         '5
            Me.DGVreimpLiquidacion.Columns("correo_com").Visible = False       '6
            Me.DGVreimpLiquidacion.Columns("dpto_com").Visible = False         '7
            Me.DGVreimpLiquidacion.Columns("rut_com").Visible = False          '8
            Me.DGVreimpLiquidacion.Columns("act_com").Visible = False          '9
            'Me.DGVreimpEgreso.Columns("metal_com").Visible = False       '10
            'Me.DGVreimpEgreso.Columns("grbrutos").Visible = False        '11
            'Me.DGVreimpEgreso.Columns("ley").Visible = False             '12
            'Me.DGVreimpEgreso.Columns("grpuros").Visible = False         '13
            Me.DGVreimpLiquidacion.Columns("base").Visible = False             '14
            Me.DGVreimpLiquidacion.Columns("regala").Visible = False           '15
            Me.DGVreimpLiquidacion.Columns("vrventa").Visible = False          '16
            Me.DGVreimpLiquidacion.Columns("conce_com").Visible = False        '17
            Me.DGVreimpLiquidacion.Columns("ciuddpto").Visible = False         '18
            'Me.DGVreimpEgreso.Columns("mes_com").Visible = False          '19
            'Me.DGVreimpEgreso.Columns("año_com").Visible = False          '20
            Me.DGVreimpLiquidacion.Columns("consecutivo").Visible = False      '21
            Me.DGVreimpLiquidacion.Columns("fecha_creado").Visible = False     '22
            Me.DGVreimpLiquidacion.Columns("fecha_modifica").Visible = False   '23
            Me.DGVreimpLiquidacion.Columns("gp_rg").Visible = False            '24
            'Me.DGVreimpEgreso.Columns("gp_base").Visible = False          '25
            Me.DGVreimpLiquidacion.Columns("letras").Visible = False           '26
            Me.DGVreimpLiquidacion.Columns("detallemineral").Visible = False   '27
            Me.DGVreimpLiquidacion.Columns("verifica").Visible = False         '28
            Me.DGVreimpLiquidacion.Columns("numfundi").Visible = False         '29

        End With

    End Sub

    Private Sub TxtDocCertifica_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocLiquidacion.KeyPress
        SoloNumeros(e)
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


End Class