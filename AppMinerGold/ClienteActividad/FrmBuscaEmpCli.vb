Imports System.Data.OleDb

Public Class FrmBuscaEmpCli

    'CARGUE DEL FORMULARIO
    Private Sub FrmBuscaEmpCli_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

        'limpio los campos
        Me.TxtBuscar.Clear()

        'INCIAR EL DATAGRID LIMPIO DESPUES DE CUALQUIER CONSULTA
        'para limpiar las filas
        Try
            If DataGridView1.RowCount >= 1 Then
                For i As Integer = 0 To DataGridView1.RowCount - 1
                    DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
                Next
            End If
        Catch ex As Exception
        Finally
            If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
                Conectar.conn.Close()
            End If
        End Try

        'para limpiar cualquier registro internamente y desenlazar el control de la BD
        DataGridView1.DataSource = Nothing

        'UBICO EL CURSOR
        Me.GroupBox3.Select()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE BUSCAR
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        'cursor de esperar
        Me.Cursor = Cursors.WaitCursor
        'verifico el campo vacio
        If Me.TxtBuscar.Text = "" Then
            MsgBox("Para hacer una Consulta debe Digitar la letra Inicial del Nombre...! ", MsgBoxStyle.Information, "AppMinerGold")
            'ubico el cursor
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
        Else
            'activo el datagrid
            Me.DataGridView1.Enabled = True
            'lleno los datos al datagrid
            If FiltroCedula(Me.TxtBuscar.Text).Rows.Count > 0 Then
                'manejo del cursor
                Me.Cursor = Cursors.WaitCursor
                DataGridView1.DataSource = FiltroCedula(Me.TxtBuscar.Text)
                'deshabilito el boton nuevo
                Me.TxtBuscar.Enabled = False
                Me.BtnBuscar.Enabled = False
                Me.BtnLimpiar.Enabled = True

                'manejo del cursor
                Me.Cursor = Cursors.Default
            Else
                MessageBox.Show("La Cédula que Digíto No existe en la Base de Datos, Digite una Nueva.!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtBuscar.Text = ""
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Focus()
                'habilito los botones
                Me.BtnBuscar.Enabled = True
                Me.BtnLimpiar.Enabled = True

                'limpio el datagrid
                DataGridView1.ClearSelection()
                DataGridView1.DataSource = Nothing
                DataGridView1.Columns.Clear()
            End If
        End If
        'cursor de esperar
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        'ubico el cursor
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Text = ""

        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

        'cierro la conexion
        Conectar.conn.Close()

        'UBICO EL CURSOR
        Me.TxtBuscar.Focus()
    End Sub

    'BOTON DE CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    'FUNCION DE FILTRAR CEDULA DE UN DATAGRID
    Function FiltroCedula(ByVal busqueda As String) As DataTable
        Dim NumConse As Integer = CInt(TxtBuscar.Text)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE ced_cl = " & NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Clientes")
        DataGridView1.DataSource = dv
        Return dt
    End Function

    'VALIDA SOLO NUMEROS EN TEXTO BUSCAR
    Private Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress

        'Valida solo letras
        SoloNumeros(e)

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

#Region "DATAGRIDVIEW"

    'FORMATEANDO LAS CELDAS DE UN DATAGRIDVIEW
    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'activo el datagrid
        Me.DataGridView1.Enabled = True

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DataGridView1.RowsDefaultCellStyle

            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(0).Width = 70

            Me.DataGridView1.Columns(1).Width = 100
            Me.DataGridView1.Columns(1).HeaderText = "Cédula"
            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(5).Width = 150
            Me.DataGridView1.Columns(5).HeaderText = "Nombre del Cliente"
            Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(6).Width = 150
            Me.DataGridView1.Columns(6).HeaderText = "Apellido del Cliente"
            Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DataGridView1.Columns("Id").Visible = True                '00
            Me.DataGridView1.Columns("ced_cl").Visible = True            '01
            Me.DataGridView1.Columns("tipoced_cl").Visible = False       '02
            Me.DataGridView1.Columns("fechaexp_cl").Visible = False      '03
            Me.DataGridView1.Columns("ciudexp_cl").Visible = False       '04
            Me.DataGridView1.Columns("nom_cl").Visible = True            '05
            Me.DataGridView1.Columns("ape_cl").Visible = True            '06
            Me.DataGridView1.Columns("fechanace_cl").Visible = False     '07
            Me.DataGridView1.Columns("lugarnace_cl").Visible = False     '08
            Me.DataGridView1.Columns("dire_cl").Visible = True           '09
            Me.DataGridView1.Columns("ciud_cl").Visible = True           '10
            Me.DataGridView1.Columns("telf_cl").Visible = False          '11
            Me.DataGridView1.Columns("telc_cl").Visible = False          '12
            Me.DataGridView1.Columns("correo_cl").Visible = False        '13
            Me.DataGridView1.Columns("pais_cl").Visible = False          '14
            Me.DataGridView1.Columns("control_cl").Visible = False       '15
            Me.DataGridView1.Columns("fecha_creado").Visible = False     '16
            Me.DataGridView1.Columns("fecha_modifica").Visible = False   '17
            Me.DataGridView1.Columns("img").Visible = False              '18
            Me.DataGridView1.Columns("huella").Visible = False           '19
            Me.DataGridView1.Columns("dpto").Visible = False             '20
            Me.DataGridView1.Columns("detact").Visible = False           '21
            Me.DataGridView1.Columns("direzonas").Visible = False        '22
            Me.DataGridView1.Columns("material").Visible = False         '23
            Me.DataGridView1.Columns("ciudadCompra").Visible = False     '24
            Me.DataGridView1.Columns("rut").Visible = False              '25
            Me.DataGridView1.Columns("actividad1").Visible = False       '26
            Me.DataGridView1.Columns("fechaAct1").Visible = False        '27
            Me.DataGridView1.Columns("rol").Visible = False              '28
            Me.DataGridView1.Columns("tipoper").Visible = False          '29
            Me.DataGridView1.Columns("obspro").Visible = False           '30
            Me.DataGridView1.Columns("codigoDane").Visible = False       '31
            Me.DataGridView1.Columns("fechaActual").Visible = False      '32
            Me.DataGridView1.Columns("A1").Visible = False               '33
        End With

    End Sub

    'EVENTO PARA CUANDO DIGITE SOBRE EL DATAGRID MUESTRE EL RESULTADO EN OTRO PANEL
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        FrmDetEmpresa.TxtName.Text = DataGridView1.CurrentRow.Cells(5).Value  'nombre
        FrmDetEmpresa.TxtSurName.Text = DataGridView1.CurrentRow.Cells(6).Value   'apellido
        FrmDetEmpresa.TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value  'cedula
        FrmDetEmpresa.TextBox5.Text = DataGridView1.CurrentRow.Cells(0).Value 'id

        'creo la variable para preguntar sobre la atencion del paciente
        Dim resultA As DialogResult = MessageBox.Show("Desea Consultar al Cliente?, Si para Atención, No para regresar a una selección del Proveedor", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'CONSULTO SI DE DESEA ATENDER LA CONSULTA Y SI ES SI ABRIR FORM
        If resultA = DialogResult.Yes Then
            'muestro el cursor
            Me.Cursor = Cursors.WaitCursor

            'desactivo el datagrid
            Me.DataGridView1.Enabled = False

            ModuleFrm.Nom_consulta = FrmDetEmpresa.TxtName.Text
            ModuleFrm.ape_consulta = FrmDetEmpresa.TxtSurName.Text
            ModuleFrm.ced_consulta = FrmDetEmpresa.TextBox2.Text

            'creo el form
            Dim frm1 As New FrmDetEmpresa
            frm1.ShowDialog()

            'cierro la forma actual
            Me.Close()

            'muestro el cursor
            Me.Cursor = Cursors.Default
        Else
            'ubico el cursor para definir el paciente que va atender
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
        End If

        Me.BtnBuscar.Enabled = False

    End Sub

#End Region


End Class