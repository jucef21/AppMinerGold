Imports System.Data.OleDb
Public Class FrmSelectCertificacion

    'CARGUE DEL FORMULARIO
    Private Sub FrmSelectCertificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.TxtDocCertifica.Clear()
        Me.TxtDocCertifica.Focus()
        Me.TxtDocCertifica.Enabled = True

        'limpio el datagrid
        Me.DGVreimpCertifica.ClearSelection()
        Me.DGVreimpCertifica.DataSource = Nothing
        Me.DGVreimpCertifica.Columns.Clear()
        Me.DGVreimpCertifica.Enabled = True

        'activo los botones
        Me.BtnDocCertifica.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.TxtDocCertifica.Select()
        Me.TxtDocCertifica.Focus()

    End Sub

    'BOTON DE  DE DOCUEMNTO DE INGRESO
    Private Sub BtnDocCertifica_Click(sender As Object, e As EventArgs) Handles BtnDocCertifica.Click
        Try
            'manejo dekl cursor
            Me.Cursor = Cursors.WaitCursor

            'lleno los datos al datagrid
            If FiltroDeclara(Me.TxtDocCertifica.Text).Rows.Count > 0 Then
                DGVreimpCertifica.DataSource = FiltroDeclara(Me.TxtDocCertifica.Text)
                MessageBox.Show("Busqueda Encontrada, Aceptar para Imprimir", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Envio el numero de docuemnto buscado al reporte
                FrmReimpCertificacion.TxtConsecutivo.Text = TxtDocCertifica.Text
                FrmReimpCertificacion.TxtCedula.Text = DGVreimpCertifica.CurrentRow.Cells(1).Value
                FrmReimpCertificacion.ShowDialog()

                'Inhabilito el boton
                Me.TxtDocCertifica.Enabled = False
                Me.DGVreimpCertifica.Enabled = False
                Me.BtnDocCertifica.Enabled = False

            Else
                MessageBox.Show("No se encontro ningún Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'limpio y ubico el cursor
                Me.TxtDocCertifica.Text = ""
                Me.TxtDocCertifica.Select()
                Me.TxtDocCertifica.Focus()
            End If

            'manejo dekl cursor
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("No existe Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            'limpio y ubico el cursor
            Me.TxtDocCertifica.Text = ""
            Me.TxtDocCertifica.Select()
            Me.TxtDocCertifica.Focus()
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

            DGVreimpCertifica.DataSource = dt

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
    Private Sub DGVreimpCertifica_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpCertifica.CellFormatting

        'activo el datagrid
        Me.DGVreimpCertifica.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVreimpCertifica.EnableHeadersVisualStyles = False
        With DGVreimpCertifica.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpCertifica.RowsDefaultCellStyle
            Me.DGVreimpCertifica.Columns(0).Width = 70
            Me.DGVreimpCertifica.Columns(0).HeaderText = "Id"
            Me.DGVreimpCertifica.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpCertifica.Columns(1).Width = 80
            Me.DGVreimpCertifica.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DGVreimpCertifica.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpCertifica.Columns(2).Width = 240
            Me.DGVreimpCertifica.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVreimpCertifica.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpCertifica.Columns(3).Width = 100
            Me.DGVreimpCertifica.Columns(3).HeaderText = "Fecha de Compra"
            Me.DGVreimpCertifica.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpCertifica.Columns(10).Width = 50
            Me.DGVreimpCertifica.Columns(10).HeaderText = "Metal"
            Me.DGVreimpCertifica.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpCertifica.Columns(11).Width = 80
            Me.DGVreimpCertifica.Columns(11).HeaderText = "Gramos Brutos"
            Me.DGVreimpCertifica.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpCertifica.Columns(11).DefaultCellStyle.Format = "N2"

            Me.DGVreimpCertifica.Columns(12).Width = 80
            Me.DGVreimpCertifica.Columns(12).HeaderText = "Ley"
            Me.DGVreimpCertifica.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpCertifica.Columns(12).DefaultCellStyle.Format = "N2"

            Me.DGVreimpCertifica.Columns(13).Width = 100
            Me.DGVreimpCertifica.Columns(13).HeaderText = "Gramos Puros"
            Me.DGVreimpCertifica.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpCertifica.Columns(13).DefaultCellStyle.Format = "N2"

            Me.DGVreimpCertifica.Columns(25).Width = 150
            Me.DGVreimpCertifica.Columns(25).HeaderText = "Valor Cancelado"
            Me.DGVreimpCertifica.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVreimpCertifica.Columns(25).DefaultCellStyle.Format = "C2"

            Me.DGVreimpCertifica.Columns(19).Width = 100
            Me.DGVreimpCertifica.Columns(19).HeaderText = "Mes de Compra"
            Me.DGVreimpCertifica.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpCertifica.Columns(20).Width = 100
            Me.DGVreimpCertifica.Columns(20).HeaderText = "Año de Compra"
            Me.DGVreimpCertifica.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DGVreimpEgreso.Columns(20).DefaultCellStyle.Format = "C2"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVreimpEgreso.Columns("Id").Visible = False              '0
            'Me.DGVreimpEgreso.Columns("cedu_com").Visible = False         '1
            'Me.DGVreimpEgreso.Columns("nom_com").Visible = False          '2
            'Me.DGVreimpEgreso.Columns("fecha_com").Visible = False        '3
            Me.DGVreimpCertifica.Columns("dire_com").Visible = False         '4
            Me.DGVreimpCertifica.Columns("telc_com").Visible = False         '5
            Me.DGVreimpCertifica.Columns("correo_com").Visible = False       '6
            Me.DGVreimpCertifica.Columns("dpto_com").Visible = False         '7
            Me.DGVreimpCertifica.Columns("rut_com").Visible = False          '8
            Me.DGVreimpCertifica.Columns("act_com").Visible = False          '9
            'Me.DGVreimpEgreso.Columns("metal_com").Visible = False       '10
            'Me.DGVreimpEgreso.Columns("grbrutos").Visible = False        '11
            'Me.DGVreimpEgreso.Columns("ley").Visible = False             '12
            'Me.DGVreimpEgreso.Columns("grpuros").Visible = False         '13
            Me.DGVreimpCertifica.Columns("base").Visible = False             '14
            Me.DGVreimpCertifica.Columns("regala").Visible = False           '15
            Me.DGVreimpCertifica.Columns("vrventa").Visible = False          '16
            Me.DGVreimpCertifica.Columns("conce_com").Visible = False        '17
            Me.DGVreimpCertifica.Columns("ciuddpto").Visible = False         '18
            'Me.DGVreimpEgreso.Columns("mes_com").Visible = False          '19
            'Me.DGVreimpEgreso.Columns("año_com").Visible = False          '20
            Me.DGVreimpCertifica.Columns("consecutivo").Visible = False      '21
            Me.DGVreimpCertifica.Columns("fecha_creado").Visible = False     '22
            Me.DGVreimpCertifica.Columns("fecha_modifica").Visible = False   '23
            Me.DGVreimpCertifica.Columns("gp_rg").Visible = False            '24
            'Me.DGVreimpEgreso.Columns("gp_base").Visible = False          '25
            Me.DGVreimpCertifica.Columns("letras").Visible = False           '26
            Me.DGVreimpCertifica.Columns("detallemineral").Visible = False   '27
            Me.DGVreimpCertifica.Columns("verifica").Visible = False         '28
            Me.DGVreimpCertifica.Columns("numfundi").Visible = False         '29

        End With

    End Sub

    Private Sub TxtDocCertifica_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocCertifica.KeyPress
        SoloNumeros(e)
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


End Class