Imports System.Data.OleDb

Public Class FrmSeleReimpVincula

    'CARGUE DEL FORMULARIO
    Private Sub FrmSeleReimpVincula_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.TxtDocIngreso.Clear()
        Me.TxtDocIngreso.Focus()
        Me.TxtDocIngreso.Enabled = True

        'limpio el datagrid
        Me.DGVreimpVincula.ClearSelection()
        Me.DGVreimpVincula.DataSource = Nothing
        Me.DGVreimpVincula.Columns.Clear()
        Me.DGVreimpVincula.Enabled = True

        'activo los botones
        Me.BtnDocIngreso.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.TxtDocIngreso.Select()
        Me.TxtDocIngreso.Focus()

    End Sub

    'BOTON DE  DE DOCUMENTO DE INGRESO
    Private Sub BtnDocIngreso_Click(sender As Object, e As EventArgs) Handles BtnDocIngreso.Click
        Try
            'manejo del cursor
            Me.Cursor = Cursors.WaitCursor
            'lleno los datos al datagrid
            If FiltroCedula(TxtDocIngreso.Text).Rows.Count > 0 Then
                DGVreimpVincula.DataSource = FiltroCedula(TxtDocIngreso.Text)
                MessageBox.Show("Busqueda Encontrada, Aceptar para Imprimir", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Envio el numero de documento buscado al reporte
                FrmReimprimeVincula.TxtClientes.Text = DGVreimpVincula.CurrentRow.Cells(1).Value
                FrmReimprimeVincula.ShowDialog()
                'Inhabilito el boton
                Me.TxtDocIngreso.Enabled = False
                Me.DGVreimpVincula.Enabled = True
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
        Catch ex As Exception
            MessageBox.Show("No existe Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'limpio y ubico el cursor
            Me.TxtDocIngreso.Text = ""
            Me.TxtDocIngreso.Select()
            Me.TxtDocIngreso.Focus()
        End Try

    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'FUNCION DE FILTRAR NUMERO DE DOCUMENTO DE INGRESO
    Function FiltroClientes(ByVal busqueda As String) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE ced_cl LIKE '" & busqueda.Trim & "%' ORDER BY ced_cl ASC", conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Clientes")
        DGVreimpVincula.DataSource = dv
        Return dt
    End Function

    'FUNCION DE FILTRAR CEDULA DE UN DATAGRID
    Function FiltroCedula(ByVal busqueda As String) As DataTable
        Dim NumConse As Integer = CInt(TxtDocIngreso.Text)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE ced_cl = " & NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Clientes")
        DGVreimpVincula.DataSource = dv
        Return dt
    End Function

    'VALIDA SOLO NUMEROS
    Private Sub TxtDocIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocIngreso.KeyPress
        'valida solo numeros
        SoloNumeros(e)
    End Sub

#Region "DATAGRIDVIEW INGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVreimpEqui_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpVincula.CellFormatting
        'activo el datagrid
        Me.DGVreimpVincula.Enabled = True

        'deshabilita el efecto visual de windows
        'ESTILO DE COLOR EN EL DATAGRID
        DGVreimpVincula.EnableHeadersVisualStyles = False
        With DGVreimpVincula.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpVincula.RowsDefaultCellStyle

            Me.DGVreimpVincula.Columns(0).Width = 70
            Me.DGVreimpVincula.Columns(0).HeaderText = "Id"

            Me.DGVreimpVincula.Columns(1).Width = 100
            Me.DGVreimpVincula.Columns(1).HeaderText = "Cédula"
            Me.DGVreimpVincula.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpVincula.Columns(5).Width = 150
            Me.DGVreimpVincula.Columns(5).HeaderText = "Nombre del Cliente"
            Me.DGVreimpVincula.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpVincula.Columns(6).Width = 150
            Me.DGVreimpVincula.Columns(6).HeaderText = "Apellido del Cliente"
            Me.DGVreimpVincula.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVreimpVincula.Columns("id").Visible = True                 '0
            Me.DGVreimpVincula.Columns("ced_cl").Visible = True             '1
            Me.DGVreimpVincula.Columns("tipoced_cl").Visible = False        '2
            Me.DGVreimpVincula.Columns("fechaexp_cl").Visible = False       '3
            Me.DGVreimpVincula.Columns("ciudexp_cl").Visible = False        '4
            Me.DGVreimpVincula.Columns("nom_cl").Visible = True             '5
            Me.DGVreimpVincula.Columns("ape_cl").Visible = True             '6
            Me.DGVreimpVincula.Columns("fechanace_cl").Visible = False      '7
            Me.DGVreimpVincula.Columns("lugarnace_cl").Visible = False      '8
            Me.DGVreimpVincula.Columns("dire_cl").Visible = False           '9
            Me.DGVreimpVincula.Columns("ciud_cl").Visible = False          '10
            Me.DGVreimpVincula.Columns("telf_cl").Visible = False          '11
            Me.DGVreimpVincula.Columns("telc_cl").Visible = False          '12
            Me.DGVreimpVincula.Columns("correo_cl").Visible = False        '13
            Me.DGVreimpVincula.Columns("pais_cl").Visible = False          '14
            Me.DGVreimpVincula.Columns("control_cl").Visible = False       '15
            Me.DGVreimpVincula.Columns("fecha_creado").Visible = False     '16
            Me.DGVreimpVincula.Columns("fecha_modifica").Visible = False   '17
            Me.DGVreimpVincula.Columns("img").Visible = False              '18
            Me.DGVreimpVincula.Columns("huella").Visible = False           '19
            Me.DGVreimpVincula.Columns("dpto").Visible = False             '20
            Me.DGVreimpVincula.Columns("detact").Visible = False           '21
            Me.DGVreimpVincula.Columns("direzonas").Visible = False        '22
            Me.DGVreimpVincula.Columns("material").Visible = False         '23
            Me.DGVreimpVincula.Columns("ciudadCompra").Visible = False     '24
            Me.DGVreimpVincula.Columns("rut").Visible = False              '25
            Me.DGVreimpVincula.Columns("actividad1").Visible = False       '26
            Me.DGVreimpVincula.Columns("fechaAct1").Visible = False        '27
            Me.DGVreimpVincula.Columns("rol").Visible = False              '28
            Me.DGVreimpVincula.Columns("tipoper").Visible = False          '29
            Me.DGVreimpVincula.Columns("obspro").Visible = False           '30
            Me.DGVreimpVincula.Columns("codigoDane").Visible = False       '31
            Me.DGVreimpVincula.Columns("fechaActual").Visible = False      '32
            Me.DGVreimpVincula.Columns("A1").Visible = False               '33
        End With

    End Sub

#End Region



End Class