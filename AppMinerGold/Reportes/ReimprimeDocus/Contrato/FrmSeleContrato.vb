Imports System.Data.OleDb
Public Class FrmSeleContrato

    'CARGUE DEL FORMULARIO
    Private Sub FrmSeleContrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.TxtDocContrato.Clear()
        Me.TxtDocContrato.Focus()
        Me.TxtDocContrato.Enabled = True

        'limpio el datagrid
        Me.DGVreimpContrato.ClearSelection()
        Me.DGVreimpContrato.DataSource = Nothing
        Me.DGVreimpContrato.Columns.Clear()
        Me.DGVreimpContrato.Enabled = True

        'activo los botones
        Me.BtnDocIngreso.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.TxtDocContrato.Select()
        Me.TxtDocContrato.Focus()

    End Sub

    'BOTON DE  DE DOCUEMNTO DE INGRESO
    Private Sub BtnDocIngreso_Click(sender As Object, e As EventArgs) Handles BtnDocIngreso.Click
        Try
            'manejo dekl cursor
            Me.Cursor = Cursors.WaitCursor

            'lleno los datos al datagrid
            If FiltroDeclara(Me.TxtDocContrato.Text).Rows.Count > 0 Then
                DGVreimpContrato.DataSource = FiltroDeclara(Me.TxtDocContrato.Text)
                MessageBox.Show("Busqueda Encontrada, Aceptar para Imprimir", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Envio el numero de docuemnto buscado al reporte
                FrmContrato.TxtConsecutivo.Text = TxtDocContrato.Text
                FrmContrato.TxtCedula.Text = DGVreimpContrato.CurrentRow.Cells(1).Value
                FrmContrato.ShowDialog()

                'Inhabilito el boton
                Me.TxtDocContrato.Enabled = False
                Me.DGVreimpContrato.Enabled = False
                Me.BtnDocIngreso.Enabled = False

            Else
                MessageBox.Show("No se encontro ningún Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'limpio y ubico el cursor
                Me.TxtDocContrato.Text = ""
                Me.TxtDocContrato.Select()
                Me.TxtDocContrato.Focus()
            End If

            'manejo dekl cursor
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("No existe Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            'limpio y ubico el cursor
            Me.TxtDocContrato.Text = ""
            Me.TxtDocContrato.Select()
            Me.TxtDocContrato.Focus()
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

            DGVreimpContrato.DataSource = dt

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
    Private Sub DGVreimpEgreso_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpContrato.CellFormatting

        'activo el datagrid
        Me.DGVreimpContrato.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVreimpContrato.EnableHeadersVisualStyles = False
        With DGVreimpContrato.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpContrato.RowsDefaultCellStyle
            Me.DGVreimpContrato.Columns(0).Width = 70
            Me.DGVreimpContrato.Columns(0).HeaderText = "Id"
            Me.DGVreimpContrato.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpContrato.Columns(1).Width = 80
            Me.DGVreimpContrato.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DGVreimpContrato.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpContrato.Columns(2).Width = 240
            Me.DGVreimpContrato.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVreimpContrato.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpContrato.Columns(3).Width = 100
            Me.DGVreimpContrato.Columns(3).HeaderText = "Fecha de Compra"
            Me.DGVreimpContrato.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpContrato.Columns(10).Width = 50
            Me.DGVreimpContrato.Columns(10).HeaderText = "Metal"
            Me.DGVreimpContrato.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpContrato.Columns(11).Width = 80
            Me.DGVreimpContrato.Columns(11).HeaderText = "Gramos Brutos"
            Me.DGVreimpContrato.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpContrato.Columns(11).DefaultCellStyle.Format = "N2"

            Me.DGVreimpContrato.Columns(12).Width = 80
            Me.DGVreimpContrato.Columns(12).HeaderText = "Ley"
            Me.DGVreimpContrato.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpContrato.Columns(12).DefaultCellStyle.Format = "N2"

            Me.DGVreimpContrato.Columns(13).Width = 100
            Me.DGVreimpContrato.Columns(13).HeaderText = "Gramos Puros"
            Me.DGVreimpContrato.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpContrato.Columns(13).DefaultCellStyle.Format = "N2"

            Me.DGVreimpContrato.Columns(25).Width = 150
            Me.DGVreimpContrato.Columns(25).HeaderText = "Valor Cancelado"
            Me.DGVreimpContrato.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVreimpContrato.Columns(25).DefaultCellStyle.Format = "C2"

            Me.DGVreimpContrato.Columns(19).Width = 100
            Me.DGVreimpContrato.Columns(19).HeaderText = "Mes de Compra"
            Me.DGVreimpContrato.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpContrato.Columns(20).Width = 100
            Me.DGVreimpContrato.Columns(20).HeaderText = "Año de Compra"
            Me.DGVreimpContrato.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DGVreimpEgreso.Columns(20).DefaultCellStyle.Format = "C2"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVreimpEgreso.Columns("Id").Visible = False              '0
            'Me.DGVreimpEgreso.Columns("cedu_com").Visible = False         '1
            'Me.DGVreimpEgreso.Columns("nom_com").Visible = False          '2
            'Me.DGVreimpEgreso.Columns("fecha_com").Visible = False        '3
            Me.DGVreimpContrato.Columns("dire_com").Visible = False         '4
            Me.DGVreimpContrato.Columns("telc_com").Visible = False         '5
            Me.DGVreimpContrato.Columns("correo_com").Visible = False       '6
            Me.DGVreimpContrato.Columns("dpto_com").Visible = False         '7
            Me.DGVreimpContrato.Columns("rut_com").Visible = False          '8
            Me.DGVreimpContrato.Columns("act_com").Visible = False          '9
            'Me.DGVreimpEgreso.Columns("metal_com").Visible = False       '10
            'Me.DGVreimpEgreso.Columns("grbrutos").Visible = False        '11
            'Me.DGVreimpEgreso.Columns("ley").Visible = False             '12
            'Me.DGVreimpEgreso.Columns("grpuros").Visible = False         '13
            Me.DGVreimpContrato.Columns("base").Visible = False             '14
            Me.DGVreimpContrato.Columns("regala").Visible = False           '15
            Me.DGVreimpContrato.Columns("vrventa").Visible = False          '16
            Me.DGVreimpContrato.Columns("conce_com").Visible = False        '17
            Me.DGVreimpContrato.Columns("ciuddpto").Visible = False         '18
            'Me.DGVreimpEgreso.Columns("mes_com").Visible = False          '19
            'Me.DGVreimpEgreso.Columns("año_com").Visible = False          '20
            Me.DGVreimpContrato.Columns("consecutivo").Visible = False      '21
            Me.DGVreimpContrato.Columns("fecha_creado").Visible = False     '22
            Me.DGVreimpContrato.Columns("fecha_modifica").Visible = False   '23
            Me.DGVreimpContrato.Columns("gp_rg").Visible = False            '24
            'Me.DGVreimpEgreso.Columns("gp_base").Visible = False          '25
            Me.DGVreimpContrato.Columns("letras").Visible = False           '26
            Me.DGVreimpContrato.Columns("detallemineral").Visible = False   '27
            Me.DGVreimpContrato.Columns("verifica").Visible = False         '28
            Me.DGVreimpContrato.Columns("numfundi").Visible = False         '29

        End With

    End Sub

    Private Sub TxtDocIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocContrato.KeyPress
        SoloNumeros(e)
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


End Class