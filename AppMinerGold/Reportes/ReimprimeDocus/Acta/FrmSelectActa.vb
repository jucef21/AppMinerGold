Imports System.Data.OleDb
Public Class FrmSelectActa

    'CARGUE DEL FORMULARIO
    Private Sub FrmSelectActa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.TxtDocActa.Clear()
        Me.TxtDocActa.Focus()
        Me.TxtDocActa.Enabled = True

        'limpio el datagrid
        Me.DGVreimpActa.ClearSelection()
        Me.DGVreimpActa.DataSource = Nothing
        Me.DGVreimpActa.Columns.Clear()
        Me.DGVreimpActa.Enabled = True

        'activo los botones
        Me.BtnDocActa.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.TxtDocActa.Select()
        Me.TxtDocActa.Focus()

    End Sub

    'BOTON DE  DE DOCUEMNTO DE INGRESO
    Private Sub BtnDocActa_Click(sender As Object, e As EventArgs) Handles BtnDocActa.Click
        Try
            'manejo dekl cursor
            Me.Cursor = Cursors.WaitCursor

            'lleno los datos al datagrid
            If FiltroDeclara(Me.TxtDocActa.Text).Rows.Count > 0 Then
                DGVreimpActa.DataSource = FiltroDeclara(Me.TxtDocActa.Text)
                MessageBox.Show("Busqueda Encontrada, Aceptar para Imprimir", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Envio el numero de docuemnto buscado al reporte
                FrmActaEntrega.TxtConsecutivo.Text = TxtDocActa.Text
                FrmActaEntrega.TxtCedula.Text = DGVreimpActa.CurrentRow.Cells(1).Value
                FrmActaEntrega.ShowDialog()

                'Inhabilito el boton
                Me.TxtDocActa.Enabled = False
                Me.DGVreimpActa.Enabled = False
                Me.BtnDocActa.Enabled = False

            Else
                MessageBox.Show("No se encontro ningún Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'limpio y ubico el cursor
                Me.TxtDocActa.Text = ""
                Me.TxtDocActa.Select()
                Me.TxtDocActa.Focus()
            End If

            'manejo dekl cursor
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("No existe Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            'limpio y ubico el cursor
            Me.TxtDocActa.Text = ""
            Me.TxtDocActa.Select()
            Me.TxtDocActa.Focus()
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

            DGVreimpActa.DataSource = dt

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
    Private Sub DGVreimpActa_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpActa.CellFormatting

        'activo el datagrid
        Me.DGVreimpActa.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVreimpActa.EnableHeadersVisualStyles = False
        With DGVreimpActa.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpActa.RowsDefaultCellStyle
            Me.DGVreimpActa.Columns(0).Width = 70
            Me.DGVreimpActa.Columns(0).HeaderText = "Id"
            Me.DGVreimpActa.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpActa.Columns(1).Width = 80
            Me.DGVreimpActa.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DGVreimpActa.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpActa.Columns(2).Width = 240
            Me.DGVreimpActa.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVreimpActa.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpActa.Columns(3).Width = 100
            Me.DGVreimpActa.Columns(3).HeaderText = "Fecha de Compra"
            Me.DGVreimpActa.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpActa.Columns(10).Width = 50
            Me.DGVreimpActa.Columns(10).HeaderText = "Metal"
            Me.DGVreimpActa.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpActa.Columns(11).Width = 80
            Me.DGVreimpActa.Columns(11).HeaderText = "Gramos Brutos"
            Me.DGVreimpActa.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpActa.Columns(11).DefaultCellStyle.Format = "N2"

            Me.DGVreimpActa.Columns(12).Width = 80
            Me.DGVreimpActa.Columns(12).HeaderText = "Ley"
            Me.DGVreimpActa.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpActa.Columns(12).DefaultCellStyle.Format = "N2"

            Me.DGVreimpActa.Columns(13).Width = 100
            Me.DGVreimpActa.Columns(13).HeaderText = "Gramos Puros"
            Me.DGVreimpActa.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpActa.Columns(13).DefaultCellStyle.Format = "N2"

            Me.DGVreimpActa.Columns(25).Width = 150
            Me.DGVreimpActa.Columns(25).HeaderText = "Valor Cancelado"
            Me.DGVreimpActa.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVreimpActa.Columns(25).DefaultCellStyle.Format = "C2"

            Me.DGVreimpActa.Columns(19).Width = 100
            Me.DGVreimpActa.Columns(19).HeaderText = "Mes de Compra"
            Me.DGVreimpActa.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpActa.Columns(20).Width = 100
            Me.DGVreimpActa.Columns(20).HeaderText = "Año de Compra"
            Me.DGVreimpActa.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DGVreimpEgreso.Columns(20).DefaultCellStyle.Format = "C2"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVreimpEgreso.Columns("Id").Visible = False              '0
            'Me.DGVreimpEgreso.Columns("cedu_com").Visible = False         '1
            'Me.DGVreimpEgreso.Columns("nom_com").Visible = False          '2
            'Me.DGVreimpEgreso.Columns("fecha_com").Visible = False        '3
            Me.DGVreimpActa.Columns("dire_com").Visible = False         '4
            Me.DGVreimpActa.Columns("telc_com").Visible = False         '5
            Me.DGVreimpActa.Columns("correo_com").Visible = False       '6
            Me.DGVreimpActa.Columns("dpto_com").Visible = False         '7
            Me.DGVreimpActa.Columns("rut_com").Visible = False          '8
            Me.DGVreimpActa.Columns("act_com").Visible = False          '9
            'Me.DGVreimpEgreso.Columns("metal_com").Visible = False       '10
            'Me.DGVreimpEgreso.Columns("grbrutos").Visible = False        '11
            'Me.DGVreimpEgreso.Columns("ley").Visible = False             '12
            'Me.DGVreimpEgreso.Columns("grpuros").Visible = False         '13
            Me.DGVreimpActa.Columns("base").Visible = False             '14
            Me.DGVreimpActa.Columns("regala").Visible = False           '15
            Me.DGVreimpActa.Columns("vrventa").Visible = False          '16
            Me.DGVreimpActa.Columns("conce_com").Visible = False        '17
            Me.DGVreimpActa.Columns("ciuddpto").Visible = False         '18
            'Me.DGVreimpEgreso.Columns("mes_com").Visible = False          '19
            'Me.DGVreimpEgreso.Columns("año_com").Visible = False          '20
            Me.DGVreimpActa.Columns("consecutivo").Visible = False      '21
            Me.DGVreimpActa.Columns("fecha_creado").Visible = False     '22
            Me.DGVreimpActa.Columns("fecha_modifica").Visible = False   '23
            Me.DGVreimpActa.Columns("gp_rg").Visible = False            '24
            'Me.DGVreimpEgreso.Columns("gp_base").Visible = False          '25
            Me.DGVreimpActa.Columns("letras").Visible = False           '26
            Me.DGVreimpActa.Columns("detallemineral").Visible = False   '27
            Me.DGVreimpActa.Columns("verifica").Visible = False         '28
            Me.DGVreimpActa.Columns("numfundi").Visible = False         '29

        End With

    End Sub

    Private Sub TxtDocIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocActa.KeyPress
        SoloNumeros(e)
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


End Class