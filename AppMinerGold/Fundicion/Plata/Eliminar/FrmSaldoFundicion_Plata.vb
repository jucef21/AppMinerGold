Imports System.Data.OleDb

Public Class FrmSaldoFundicion_Plata

    'CARGUE DEL FORMULARIO
    Private Sub FrmSaldoFundicion_Plata_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'codigo mostrar hora en formulario
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Timer1.Interval = 1000  ' Un segundo
        Timer1.Start()

        'ACTIVO LOS BOTONES
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

        Me.TxtNum_com.Enabled = True
        Me.TxtNum_com.Clear()

        Me.Panel3.Select()
        Me.TxtNum_com.Select()
        Me.TxtNum_com.Focus()

    End Sub

    'Cargue del timpo actual en el formulario
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Me.LblFechaActual.Text = Now.ToLongDateString
    End Sub

    'BOTON BUSCAR
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim Num As String = CInt(TxtNum_com.Text)
        Try
            'manejo del cursor
            Me.Cursor = Cursors.WaitCursor

            If Me.TxtNum_com.Text = "" Then
                MessageBox.Show("No se encontro ningún Registro de Fundición, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'limpio y ubico el cursor
                Me.BtnLimpiar.Enabled = True
                Me.BtnBuscar.Enabled = True

                Me.TxtNum_com.Enabled = True
                Me.Panel3.Select()
                Me.TxtNum_com.Select()
                Me.TxtNum_com.Clear()
                Me.TxtNum_com.Focus()
            Else
                'manejo del cursor
                Me.Cursor = Cursors.WaitCursor
                'lleno los datos al datagrid
                If FiltroCodigo(TxtNum_com.Text).Rows.Count > 0 Then
                    DataGridView1.DataSource = FiltroCodigo(TxtNum_com.Text)
                    MessageBox.Show("Busqueda Encontrada, Aceptar para Continuar.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim FrmEliminaFPlata As New FrmEliminaFundi_Plata
                    Dim i As Integer
                    i = DataGridView1.CurrentRow.Index
                    FrmEliminaFPlata.TxtId.Text = Me.DataGridView1.Item(0, i).Value
                    FrmEliminaFPlata.TxtConsecutivo.Text = Me.DataGridView1.Item(1, i).Value
                    FrmEliminaFPlata.TxtFechafundi.Text = Me.DataGridView1.Item(2, i).Value
                    FrmEliminaFPlata.Txttipometal.Text = Me.DataGridView1.Item(3, i).Value
                    FrmEliminaFPlata.Txtbrutos.Text = Format(Me.DataGridView1.Item(4, i).Value, "0.00")
                    FrmEliminaFPlata.Txtley.Text = Format(Me.DataGridView1.Item(5, i).Value, "0.0000")
                    FrmEliminaFPlata.Txtpuros.Text = Format(Me.DataGridView1.Item(6, i).Value, "0.00")
                    'llamo  el form
                    FrmEliminaFPlata.ShowDialog()

                    'limpio el datagrid y  campos
                    Me.TxtNum_com.Clear()
                    Me.DataGridView1.DataSource = Nothing

                    Me.DataGridView1.Enabled = False
                    Me.TxtNum_com.Enabled = False
                    Me.BtnBuscar.Enabled = False
                    Me.BtnLimpiar.Enabled = False

                Else
                    MessageBox.Show("No se encontro ningún Registro" & vbCr & "de Fundición, con el Número digitado" & vbCr & "o el Metal no Coincide con PLATA", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtNum_com.Clear()
                    Me.DataGridView1.Enabled = False
                    Me.TxtNum_com.Enabled = False
                    Me.BtnBuscar.Enabled = False
                    Me.BtnLimpiar.Enabled = True
                    Me.DataGridView1.DataSource = Nothing
                End If
                'manejo del cursor
                Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            MsgBox("No existen datos en el numero consultado, intente de nuevo con otro número.", MsgBoxStyle.Information, "AppMinerGold")
            Me.TxtNum_com.Clear()
            Me.DataGridView1.Enabled = False
            Me.TxtNum_com.Enabled = False
            Me.BtnBuscar.Enabled = False
            Me.BtnLimpiar.Enabled = True
            Me.DataGridView1.DataSource = Nothing

        End Try

    End Sub


    'FUNCION DE FILTRAR CEDULA DE UN DATAGRID
    Function FiltroCodigo(ByVal busqueda As String) As DataTable
        Dim NumConse As String = CInt(TxtNum_com.Text)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM fundicion WHERE tipometal='PLATA' AND numdocufundi = " & NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("fundicion")
        DataGridView1.DataSource = dv
        Return dt
    End Function


    'BOTON DE LIMPIAR
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        'ubico el cursor
        Me.TxtNum_com.Enabled = True
        Me.TxtNum_com.Text = ""

        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True
        'cierro la conexion
        conn.Close()

        'UBICO EL CURSOR
        Me.TxtNum_com.Select()
        Me.TxtNum_com.Focus()

    End Sub

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS - DECLARA
    Private Sub Datagridview1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

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
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(0).Width = 70
            Me.DataGridView1.Columns(0).HeaderText = "Id"
            Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(1).Width = 80
            Me.DataGridView1.Columns(1).HeaderText = "No de Consecutivo"
            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(2).Width = 80
            Me.DataGridView1.Columns(2).HeaderText = "Fecha de Fundición"
            Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(3).Width = 50
            Me.DataGridView1.Columns(3).HeaderText = "Tipo de Metal"
            Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(4).Width = 100
            Me.DataGridView1.Columns(4).HeaderText = "Gramos Brutos"
            Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(4).DefaultCellStyle.Format = "N2"

            Me.DataGridView1.Columns(5).Width = 100
            Me.DataGridView1.Columns(5).HeaderText = "Ley"
            Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(5).DefaultCellStyle.Format = "N4"

            Me.DataGridView1.Columns(6).Width = 100
            Me.DataGridView1.Columns(6).HeaderText = "Gramos Puros"
            Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView1.Columns(6).DefaultCellStyle.Format = "N2"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DataGridView1.Columns("Id").Visible = True                         '0
            Me.DataGridView1.Columns("numdocufundi").Visible = True               '1
            Me.DataGridView1.Columns("fechaactualfundi").Visible = True           '2
            Me.DataGridView1.Columns("tipometal").Visible = True                  '3
            Me.DataGridView1.Columns("brutosfundi").Visible = True                '4
            Me.DataGridView1.Columns("leyfundi").Visible = True                   '5
            Me.DataGridView1.Columns("purosfundi").Visible = True                 '6
            Me.DataGridView1.Columns("fundicompra").Visible = False               '7
            Me.DataGridView1.Columns("fundiventa").Visible = False                '8
            Me.DataGridView1.Columns("vrsaldosbrutos").Visible = False            '9
            Me.DataGridView1.Columns("vrsaldosley").Visible = False               '10
            Me.DataGridView1.Columns("vrsaldospuros").Visible = False             '11
            Me.DataGridView1.Columns("fecha_creado").Visible = False              '12
            Me.DataGridView1.Columns("fecha_modifica").Visible = False            '13
        End With

    End Sub

    'VALIDA SOLO NUMEROS
    Private Sub TxtNum_com_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNum_com.KeyPress
        SoloNumeros(e)
    End Sub

    'BOTON DE CERAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class