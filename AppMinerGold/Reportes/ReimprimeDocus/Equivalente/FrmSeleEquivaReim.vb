Imports System.Data.OleDb

Public Class FrmSeleEquivaReim

    'CARGUE DEL FORMULARIO
    Private Sub FrmSeleEquivaReim_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        VerCiudad()

        'limpio los campos
        Me.TxtDocIngreso.Clear()
        Me.TxtDocIngreso.Focus()
        Me.TxtDocIngreso.Enabled = True

        'limpio el datagrid
        Me.DGVreimpEqui.ClearSelection()
        Me.DGVreimpEqui.DataSource = Nothing
        Me.DGVreimpEqui.Columns.Clear()
        Me.DGVreimpEqui.Enabled = True

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
            'manejo del cursor
            Me.Cursor = Cursors.WaitCursor
            'verifico el campo vacio
            If Me.TxtDocIngreso.Text = "" Then
                MessageBox.Show("El Campo de Consulta no se digito un Número...! ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Ubico el cursor
                'limpio y ubico el cursor
                Me.Panel2.Enabled = True
                Me.TxtDocIngreso.Text = ""
                Me.TxtDocIngreso.Select()
                Me.TxtDocIngreso.Focus()
                'manejo del cursor
                Me.Cursor = Cursors.Default
            Else
                'manejo del cursor
                Me.Cursor = Cursors.WaitCursor
                If FiltroDeclara(Me.TxtDocIngreso.Text).Rows.Count > 0 Then
                    DGVreimpEqui.DataSource = FiltroDeclara(Me.TxtDocIngreso.Text)
                    MessageBox.Show("Busqueda Encontrada, Aceptar para Imprimir", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'Envio el numero de docuemnto buscado al reporte
                    FrmNuevoReimpEqui.TxtConsecutivo.Text = TxtDocIngreso.Text
                    FrmNuevoReimpEqui.TxtVerCiudImp.Text = Me.TxtEmpCiu.Text
                    'llamo  el form
                    FrmNuevoReimpEqui.ShowDialog()

                    'Inhabilito el boton
                    Me.TxtDocIngreso.Enabled = False
                    Me.DGVreimpEqui.Enabled = False
                    Me.BtnDocIngreso.Enabled = False

                Else
                    MessageBox.Show("No se encontro ningún Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'limpio y ubico el cursor
                    Me.TxtDocIngreso.Text = ""
                    Me.TxtDocIngreso.Select()
                    Me.TxtDocIngreso.Focus()
                End If
                'manejo del cursor
                Me.Cursor = Cursors.Default
            End If
            'manejo del cursor
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("No existe Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'limpio y ubico el cursor
            Me.TxtDocIngreso.Text = ""
            Me.TxtDocIngreso.Select()
            Me.TxtDocIngreso.Focus()
        End Try
    End Sub

    'BOTON DE CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    Function FiltroDeclara(ByVal busqueda As String) As DataTable
        Dim dt As New DataTable()

        Dim consecutivo As Integer

        'Validar que sea un número
        If Not Integer.TryParse(busqueda.Trim(), consecutivo) Then
            MessageBox.Show("Ingrese un número válido.", "AppMinerGold - Registro anulado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return dt
        End If

        'No permitir buscar registros anulados
        If consecutivo = 1111111111 Then
            MessageBox.Show("Este consecutivo corresponde a un registro anulado.",
                        "AppMinerGold - Registro anulado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DGVreimpEqui.DataSource = Nothing
            Return dt
        End If

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim sql As String = "SELECT * FROM Declara " &
                            "WHERE consecutivo = ? " &
                            "AND cedu_com <> 1111111111"

            Using da As New OleDbDataAdapter(sql, conn)
                da.SelectCommand.Parameters.Add("@consecutivo", OleDbType.Integer).Value = consecutivo
                da.Fill(dt)
            End Using

            DGVreimpEqui.DataSource = dt

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No se encontró ningún registro.",
                            "AppMinerGold - Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al buscar: " & ex.Message,
                        "AppMinerGold - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

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
            MessageBox.Show("No se encontro CIUDAD", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        drd.Close()
        Conectar.conn.Close()
    End Sub

    'VALIDA SOLO NUMEROS
    Private Sub TxtDocIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocIngreso.KeyPress
        SoloNumeros(e)
    End Sub

#Region "DATAGRIDVIEW INGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVreimpEqui_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpEqui.CellFormatting

        'activo el datagrid
        Me.DGVreimpEqui.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVreimpEqui.EnableHeadersVisualStyles = False
        With DGVreimpEqui.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpEqui.RowsDefaultCellStyle
            Me.DGVreimpEqui.Columns(0).Width = 70
            Me.DGVreimpEqui.Columns(0).HeaderText = "Id"
            Me.DGVreimpEqui.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpEqui.Columns(1).Width = 80
            Me.DGVreimpEqui.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DGVreimpEqui.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpEqui.Columns(2).Width = 240
            Me.DGVreimpEqui.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVreimpEqui.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpEqui.Columns(3).Width = 100
            Me.DGVreimpEqui.Columns(3).HeaderText = "Fecha de Compra"
            Me.DGVreimpEqui.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpEqui.Columns(10).Width = 50
            Me.DGVreimpEqui.Columns(10).HeaderText = "Metal"
            Me.DGVreimpEqui.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpEqui.Columns(11).Width = 80
            Me.DGVreimpEqui.Columns(11).HeaderText = "Gramos Brutos"
            Me.DGVreimpEqui.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpEqui.Columns(11).DefaultCellStyle.Format = "N2"

            Me.DGVreimpEqui.Columns(12).Width = 80
            Me.DGVreimpEqui.Columns(12).HeaderText = "Ley"
            Me.DGVreimpEqui.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpEqui.Columns(12).DefaultCellStyle.Format = "N2"

            Me.DGVreimpEqui.Columns(13).Width = 100
            Me.DGVreimpEqui.Columns(13).HeaderText = "Gramos Puros"
            Me.DGVreimpEqui.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpEqui.Columns(13).DefaultCellStyle.Format = "N2"

            Me.DGVreimpEqui.Columns(25).Width = 150
            Me.DGVreimpEqui.Columns(25).HeaderText = "Valor Cancelado"
            Me.DGVreimpEqui.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVreimpEqui.Columns(25).DefaultCellStyle.Format = "C2"

            Me.DGVreimpEqui.Columns(19).Width = 100
            Me.DGVreimpEqui.Columns(19).HeaderText = "Mes de Compra"
            Me.DGVreimpEqui.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpEqui.Columns(20).Width = 100
            Me.DGVreimpEqui.Columns(20).HeaderText = "Año de Compra"
            Me.DGVreimpEqui.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.DGVreimpEqui.Columns(20).DefaultCellStyle.Format = "C2"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVreimpEqui.Columns("Id").Visible = False              '0
            'Me.DGVreimpEqui.Columns("cedu_com").Visible = False         '1
            'Me.DGVreimpEqui.Columns("nom_com").Visible = False          '2
            'Me.DGVreimpEqui.Columns("fecha_com").Visible = False        '3
            Me.DGVreimpEqui.Columns("dire_com").Visible = False         '4
            Me.DGVreimpEqui.Columns("telc_com").Visible = False         '5
            Me.DGVreimpEqui.Columns("correo_com").Visible = False       '6
            Me.DGVreimpEqui.Columns("dpto_com").Visible = False         '7
            Me.DGVreimpEqui.Columns("rut_com").Visible = False          '8
            Me.DGVreimpEqui.Columns("act_com").Visible = False          '9
            'Me.DGVreimpEqui.Columns("metal_com").Visible = False       '10
            'Me.DGVreimpEqui.Columns("grbrutos").Visible = False        '11
            'Me.DGVreimpEqui.Columns("ley").Visible = False             '12
            'Me.DGVreimpEqui.Columns("grpuros").Visible = False         '13
            Me.DGVreimpEqui.Columns("base").Visible = False             '14
            Me.DGVreimpEqui.Columns("regala").Visible = False           '15
            Me.DGVreimpEqui.Columns("vrventa").Visible = False          '16
            Me.DGVreimpEqui.Columns("conce_com").Visible = False        '17
            Me.DGVreimpEqui.Columns("ciuddpto").Visible = False         '18
            'Me.DGVreimpEqui.Columns("mes_com").Visible = False          '19
            'Me.DGVreimpEqui.Columns("año_com").Visible = False          '20
            Me.DGVreimpEqui.Columns("consecutivo").Visible = False      '21
            Me.DGVreimpEqui.Columns("fecha_creado").Visible = False     '22
            Me.DGVreimpEqui.Columns("fecha_modifica").Visible = False   '23
            Me.DGVreimpEqui.Columns("gp_rg").Visible = False            '24
            'Me.DGVreimpEqui.Columns("gp_base").Visible = False          '25
            Me.DGVreimpEqui.Columns("letras").Visible = False           '26
            Me.DGVreimpEqui.Columns("detallemineral").Visible = False   '27
            Me.DGVreimpEqui.Columns("verifica").Visible = False         '28
            Me.DGVreimpEqui.Columns("numfundi").Visible = False         '29

        End With

    End Sub

#End Region


End Class