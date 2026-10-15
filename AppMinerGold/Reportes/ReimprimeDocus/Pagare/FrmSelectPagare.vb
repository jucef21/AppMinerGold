Imports System.Data.OleDb
Public Class FrmSelectPagare

    'CARGUE DEL FORMULARIO
    Private Sub FrmSelectPagare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.TxtDocPagare.Clear()
        Me.TxtDocPagare.Focus()
        Me.TxtDocPagare.Enabled = True

        'limpio el datagrid
        Me.DGVreimpPagare.ClearSelection()
        Me.DGVreimpPagare.DataSource = Nothing
        Me.DGVreimpPagare.Columns.Clear()
        Me.DGVreimpPagare.Enabled = True

        'activo los botones
        Me.BtnDocPagare.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.TxtDocPagare.Select()
        Me.TxtDocPagare.Focus()

    End Sub

    'BOTON DE  DE DOCUEMNTO DE INGRESO
    Private Sub BtnDocIngreso_Click(sender As Object, e As EventArgs) Handles BtnDocPagare.Click
        Try
            'manejo dekl cursor
            Me.Cursor = Cursors.WaitCursor

            'lleno los datos al datagrid
            If FiltroDeclara(Me.TxtDocPagare.Text).Rows.Count > 0 Then
                DGVreimpPagare.DataSource = FiltroDeclara(Me.TxtDocPagare.Text)
                MessageBox.Show("Busqueda Encontrada, Aceptar para Imprimir", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Envio el numero de docuemnto buscado al reporte
                FrmReimpPagare.TxtConsecutivo.Text = TxtDocPagare.Text
                FrmReimpPagare.TxtCedula.Text = DGVreimpPagare.CurrentRow.Cells(1).Value
                FrmReimpPagare.ShowDialog()

                'Inhabilito el boton
                Me.TxtDocPagare.Enabled = False
                Me.DGVreimpPagare.Enabled = False
                Me.BtnDocPagare.Enabled = False

            Else
                MessageBox.Show("No se encontro ningún Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'limpio y ubico el cursor
                Me.TxtDocPagare.Text = ""
                Me.TxtDocPagare.Select()
                Me.TxtDocPagare.Focus()
            End If

            'manejo dekl cursor
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("No existe Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            'limpio y ubico el cursor
            Me.TxtDocPagare.Text = ""
            Me.TxtDocPagare.Select()
            Me.TxtDocPagare.Focus()
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

            DGVreimpPagare.DataSource = dt

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
    Private Sub DGVreimpEgreso_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpPagare.CellFormatting

        'activo el datagrid
        Me.DGVreimpPagare.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVreimpPagare.EnableHeadersVisualStyles = False
        With DGVreimpPagare.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpPagare.RowsDefaultCellStyle
            Me.DGVreimpPagare.Columns(0).Width = 70
            Me.DGVreimpPagare.Columns(0).HeaderText = "Id"
            Me.DGVreimpPagare.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpPagare.Columns(1).Width = 80
            Me.DGVreimpPagare.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DGVreimpPagare.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpPagare.Columns(2).Width = 240
            Me.DGVreimpPagare.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVreimpPagare.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpPagare.Columns(3).Width = 100
            Me.DGVreimpPagare.Columns(3).HeaderText = "Fecha de Compra"
            Me.DGVreimpPagare.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpPagare.Columns(10).Width = 50
            Me.DGVreimpPagare.Columns(10).HeaderText = "Metal"
            Me.DGVreimpPagare.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpPagare.Columns(11).Width = 80
            Me.DGVreimpPagare.Columns(11).HeaderText = "Gramos Brutos"
            Me.DGVreimpPagare.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpPagare.Columns(11).DefaultCellStyle.Format = "N2"

            Me.DGVreimpPagare.Columns(12).Width = 80
            Me.DGVreimpPagare.Columns(12).HeaderText = "Ley"
            Me.DGVreimpPagare.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpPagare.Columns(12).DefaultCellStyle.Format = "N2"

            Me.DGVreimpPagare.Columns(13).Width = 100
            Me.DGVreimpPagare.Columns(13).HeaderText = "Gramos Puros"
            Me.DGVreimpPagare.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpPagare.Columns(13).DefaultCellStyle.Format = "N2"

            Me.DGVreimpPagare.Columns(25).Width = 150
            Me.DGVreimpPagare.Columns(25).HeaderText = "Valor Cancelado"
            Me.DGVreimpPagare.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVreimpPagare.Columns(25).DefaultCellStyle.Format = "C2"

            Me.DGVreimpPagare.Columns(19).Width = 100
            Me.DGVreimpPagare.Columns(19).HeaderText = "Mes de Compra"
            Me.DGVreimpPagare.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpPagare.Columns(20).Width = 100
            Me.DGVreimpPagare.Columns(20).HeaderText = "Año de Compra"
            Me.DGVreimpPagare.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DGVreimpEgreso.Columns(20).DefaultCellStyle.Format = "C2"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVreimpEgreso.Columns("Id").Visible = False              '0
            'Me.DGVreimpEgreso.Columns("cedu_com").Visible = False         '1
            'Me.DGVreimpEgreso.Columns("nom_com").Visible = False          '2
            'Me.DGVreimpEgreso.Columns("fecha_com").Visible = False        '3
            Me.DGVreimpPagare.Columns("dire_com").Visible = False         '4
            Me.DGVreimpPagare.Columns("telc_com").Visible = False         '5
            Me.DGVreimpPagare.Columns("correo_com").Visible = False       '6
            Me.DGVreimpPagare.Columns("dpto_com").Visible = False         '7
            Me.DGVreimpPagare.Columns("rut_com").Visible = False          '8
            Me.DGVreimpPagare.Columns("act_com").Visible = False          '9
            'Me.DGVreimpEgreso.Columns("metal_com").Visible = False       '10
            'Me.DGVreimpEgreso.Columns("grbrutos").Visible = False        '11
            'Me.DGVreimpEgreso.Columns("ley").Visible = False             '12
            'Me.DGVreimpEgreso.Columns("grpuros").Visible = False         '13
            Me.DGVreimpPagare.Columns("base").Visible = False             '14
            Me.DGVreimpPagare.Columns("regala").Visible = False           '15
            Me.DGVreimpPagare.Columns("vrventa").Visible = False          '16
            Me.DGVreimpPagare.Columns("conce_com").Visible = False        '17
            Me.DGVreimpPagare.Columns("ciuddpto").Visible = False         '18
            'Me.DGVreimpEgreso.Columns("mes_com").Visible = False          '19
            'Me.DGVreimpEgreso.Columns("año_com").Visible = False          '20
            Me.DGVreimpPagare.Columns("consecutivo").Visible = False      '21
            Me.DGVreimpPagare.Columns("fecha_creado").Visible = False     '22
            Me.DGVreimpPagare.Columns("fecha_modifica").Visible = False   '23
            Me.DGVreimpPagare.Columns("gp_rg").Visible = False            '24
            'Me.DGVreimpEgreso.Columns("gp_base").Visible = False          '25
            Me.DGVreimpPagare.Columns("letras").Visible = False           '26
            Me.DGVreimpPagare.Columns("detallemineral").Visible = False   '27
            Me.DGVreimpPagare.Columns("verifica").Visible = False         '28
            Me.DGVreimpPagare.Columns("numfundi").Visible = False         '29

        End With

    End Sub

    Private Sub TxtDocIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocPagare.KeyPress
        SoloNumeros(e)
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


End Class