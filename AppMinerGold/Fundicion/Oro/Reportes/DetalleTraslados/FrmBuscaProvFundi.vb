Imports System.Data.OleDb

Public Class FrmBuscaProvFundi

    'CARGUE DEL FORMULARIO
    Private Sub FrmBuscaProvFundi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'habilito los botones
        Me.TxtBuscar.Enabled = True
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

        'limpio los campos
        Me.TxtBuscar.Clear()

        'INCIAR EL DATAGRID LIMPIO DESPUES DE CUALQUIER CONSULTA
        'para limpiar las filas
        Try
            If DataGridView2.RowCount >= 1 Then
                For i As Integer = 0 To DataGridView2.RowCount - 1
                    DataGridView2.Rows.Remove(DataGridView2.CurrentRow)
                Next
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        'para limpiar cualquier registro internamente y desenlazar el control de la BD
        DataGridView2.DataSource = Nothing

        'UBICO EL CURSOR
        Me.GroupBox3.Select()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE BUSCAR
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim Num As String = CInt(TxtBuscar.Text)
        Try
            'manejo del cursoe
            Me.Cursor = Cursors.WaitCursor

            If Me.TxtBuscar.Text = " " Then
                MessageBox.Show("Se debe registrar un Número de Fundición", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'limpio y ubico el cursor
                Me.GroupBox3.Select()
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Clear()
                Me.TxtBuscar.Enabled = True
                Me.TxtBuscar.Focus()
            Else
                'manejo del cursor
                Me.Cursor = Cursors.WaitCursor
                'lleno los datos al datagrid
                If FiltroCodigo(TxtBuscar.Text).Rows.Count > 0 Then
                    DataGridView2.DataSource = FiltroCodigo(TxtBuscar.Text)
                    MessageBox.Show("Busqueda Encontrada, Aceptar para Listar el Reporte.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim FrmFundiRptxP As New FrmFundiRptxProv
                    Dim i As Integer
                    i = DataGridView2.CurrentRow.Index
                    FrmFundiRptxP.TxtNumero.Text = Me.DataGridView2.Item(1, i).Value
                    'FrmFundiRptxP.TxtNumero.Text = DataGridView2.CurrentRow.Cells(1).Value
                    FrmFundiRptxP.ShowDialog()

                    'LIMPIO LOS CONTROLES
                    Me.GroupBox3.Select()
                    Me.TxtBuscar.Select()
                    Me.TxtBuscar.Clear()
                    Me.BtnBuscar.Enabled = False
                    Me.BtnLimpiar.Enabled = True

                    'desactivo el datagrid
                    Me.DataGridView2.Enabled = False
                    Me.DataGridView2.DataSource = Nothing
                Else
                    MessageBox.Show("No se encontro ningún Registro" & vbCr & "de Fundición, con el Número digitado" & vbCr & "o el metal no coincide con ORO", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtBuscar.Clear()
                    Me.DataGridView2.Enabled = False
                    Me.TxtBuscar.Enabled = False
                    Me.BtnBuscar.Enabled = False
                    Me.BtnLimpiar.Enabled = True
                    Me.DataGridView2.DataSource = Nothing
                End If
                'manejo del cursoe
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'limpio y ubico el cursor
            Me.GroupBox3.Select()
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Enabled = False
            'y ubico el cursor
            Me.GroupBox3.Select()
            Me.TxtBuscar.Clear()
            Me.BtnLimpiar.Select()
            Me.BtnLimpiar.Focus()
        End Try

    End Sub

    'FUNCION DE FILTRAR CEDULA DE UN DATAGRID
    Function FiltroCodigo(ByVal busqueda As String) As DataTable
        Dim NumConse As String = CInt(TxtBuscar.Text)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM fundicion WHERE tipometal = 'ORO' AND numdocufundi = " & NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("fundicion")
        DataGridView2.DataSource = dv
        Return dt
    End Function

    'BOTON DE LIMPIAR
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        'limpio el datagrid
        DataGridView2.ClearSelection()
        DataGridView2.DataSource = Nothing
        DataGridView2.Columns.Clear()

        'ubico el cursor
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Text = ""

        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

        'cierro la conexion
        conn.Close()

        'UBICO EL CURSOR
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    Function FiltroDeclara(ByVal busqueda As String) As DataTable

        Dim sqlD As String
        Dim conn As OleDbConnection
        Dim cmd As OleDbCommand
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        sqlD = "SELECT * FROM Fundicion WHERE numdocufundi = ?"
        conn = New OleDbConnection(cs)
        conn.Open()

        cmd = New OleDbCommand With {
            .CommandText = sqlD,
            .CommandType = CommandType.Text,
            .Connection = conn
        }
        cmd.Parameters.Add("?numdocufundi", OleDbType.Double)
        cmd.Parameters("?numdocufundi").Value = Me.TxtBuscar.Text
        da = New OleDbDataAdapter(cmd)
        ds = New DataSet()
        da.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0).DefaultView

    End Function

#End Region

#Region "DATAGRIDVIEW"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS - DECLARA
    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting

        'activo el datagrid
        Me.DataGridView2.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DataGridView2.EnableHeadersVisualStyles = False
        With DataGridView2.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DataGridView2.RowsDefaultCellStyle
            Me.DataGridView2.Columns(0).Width = 70
            Me.DataGridView2.Columns(0).HeaderText = "Id"
            Me.DataGridView2.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView2.Columns(1).Width = 80
            Me.DataGridView2.Columns(1).HeaderText = "No. Documento"
            Me.DataGridView2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView2.Columns(2).Width = 100
            Me.DataGridView2.Columns(2).HeaderText = "Fecha de Fundición"
            Me.DataGridView2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView2.Columns(3).Width = 80
            Me.DataGridView2.Columns(3).HeaderText = "Tipo de Metal"
            Me.DataGridView2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView2.Columns(4).Width = 100
            Me.DataGridView2.Columns(4).HeaderText = "Gramos Brutos"
            Me.DataGridView2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView2.Columns(4).DefaultCellStyle.Format = "N2"

            Me.DataGridView2.Columns(5).Width = 80
            Me.DataGridView2.Columns(5).HeaderText = "Ley"
            Me.DataGridView2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView2.Columns(5).DefaultCellStyle.Format = "N4"

            Me.DataGridView2.Columns(6).Width = 100
            Me.DataGridView2.Columns(6).HeaderText = "Gramos Puros"
            Me.DataGridView2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView2.Columns(6).DefaultCellStyle.Format = "N2"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DataGridView2.Columns("Id").Visible = True                   '0
            Me.DataGridView2.Columns("numdocufundi").Visible = True         '1
            Me.DataGridView2.Columns("fechaactualfundi").Visible = True     '2
            Me.DataGridView2.Columns("tipometal").Visible = True            '3
            Me.DataGridView2.Columns("brutosfundi").Visible = True          '4
            Me.DataGridView2.Columns("leyfundi").Visible = True             '5
            Me.DataGridView2.Columns("purosfundi").Visible = True           '6
            Me.DataGridView2.Columns("fundicompra").Visible = False         '7 
            Me.DataGridView2.Columns("fundiventa").Visible = False          '8
            Me.DataGridView2.Columns("vrsaldosbrutos").Visible = False      '9
            Me.DataGridView2.Columns("vrsaldosley").Visible = False         '10
            Me.DataGridView2.Columns("vrsaldospuros").Visible = False       '11
            Me.DataGridView2.Columns("fecha_creado").Visible = False        '12
            Me.DataGridView2.Columns("fecha_modifica").Visible = False      '13

        End With

    End Sub

    Private Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress
        SoloNumeros(e)
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


End Class