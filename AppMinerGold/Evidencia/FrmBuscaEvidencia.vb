Imports System.Data.OleDb

Public Class FrmBuscaEvidencia

    'CARGUE DEL FORMULARIO
    Private Sub FrmBuscaEvidencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            'MessageBox.Show(ex.Message.ToString, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        'para limpiar cualquier registro internamente y desenlazar el control de la BD
        DataGridView1.DataSource = Nothing

        'UBICO EL CURSOR
        Me.TxtBuscar.Focus()

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE BUSCAR
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        'verifico el campo vacio
        If Me.TxtBuscar.Text = "" Then
            MsgBox("Para hacer una Consulta debe Digitar la Cédula...! ", MsgBoxStyle.Information, "AppMinerGold")
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
        Else
            'activo el datagrid
            Me.DataGridView1.Enabled = True

            'lleno los datos al datagrid
            If FiltroCedula(Me.TxtBuscar.Text).Rows.Count > 0 Then
                DataGridView1.DataSource = FiltroCedula(Me.TxtBuscar.Text)

                'Inhabilito el campo de texto
                Me.TxtBuscar.Enabled = False
                Me.BtnBuscar.Enabled = False
            Else
                MsgBox("La Cédula que Digíto No existe en la Base de Datos, Digite de nuevo...!", MsgBoxStyle.Information, "AppMinerGold")
                Me.TxtBuscar.Text = ""
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
        conn.Close()

        'UBICO EL CURSOR
        Me.TxtBuscar.Focus()
    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    'FUNCION DE FILTRAR CEDULA DE UN DATAGRID
    Function FiltroCedula(ByVal busqueda As String) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim num As String
        num = Convert.ToInt32(TxtBuscar.Text)
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE ced_cl = " & num, Conectar.conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Clientes")
        DataGridView1.DataSource = dv
        Conectar.conn.Close()
        Return dt
    End Function

#End Region

#Region "DATAGRIDVIEW"

    'FORMATEANDO LAS CELDAS DE UN DATAGRIDVIEW
    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'activo el datagrid
        Me.DataGridView1.Enabled = True

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DataGridView1.RowsDefaultCellStyle

            Me.DataGridView1.Columns(0).Width = 70
            Me.DataGridView1.Columns(0).HeaderText = "Id"

            Me.DataGridView1.Columns(1).Width = 100
            Me.DataGridView1.Columns(1).HeaderText = "Cédula"
            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(5).Width = 150
            Me.DataGridView1.Columns(5).HeaderText = "Nombre"
            Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(6).Width = 150
            Me.DataGridView1.Columns(6).HeaderText = "Apellido"
            Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(9).Width = 220
            Me.DataGridView1.Columns(9).HeaderText = "Dirección Personal"
            Me.DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(10).Width = 180
            Me.DataGridView1.Columns(10).HeaderText = "Ciudad"
            Me.DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DataGridView1.Columns("Id").Visible = False               '00
            'Me.DataGridView1.Columns("ced_cl").Visible = False           '01
            Me.DataGridView1.Columns("tipoced_cl").Visible = False       '02
            Me.DataGridView1.Columns("fechaexp_cl").Visible = False      '03
            Me.DataGridView1.Columns("ciudexp_cl").Visible = False       '04
            'Me.DataGridView1.Columns("nom_cl").Visible = False           '05
            'Me.DataGridView1.Columns("ape_cl").Visible = False           '06
            Me.DataGridView1.Columns("fechanace_cl").Visible = False     '07
            Me.DataGridView1.Columns("lugarnace_cl").Visible = False     '08
            'Me.DataGridView1.Columns("dire_cl").Visible = False          '09
            'Me.DataGridView1.Columns("ciud_cl").Visible = False          '10
            Me.DataGridView1.Columns("telf_cl").Visible = False          '11
            Me.DataGridView1.Columns("telc_cl").Visible = False          '12
            Me.DataGridView1.Columns("correo_cl").Visible = False        '13
            Me.DataGridView1.Columns("pais_cl").Visible = False          '14
            Me.DataGridView1.Columns("control_cl").Visible = False       '15
            Me.DataGridView1.Columns("fecha_creado").Visible = False     '16
            Me.DataGridView1.Columns("fecha_modifica").Visible = False   '17
            Me.DataGridView1.Columns("img").Visible = False              '18
            Me.DataGridView1.Columns("huella").Visible = False           '19
            Me.DataGridView1.Columns("rutaFoto").Visible = False          '20

        End With

        Me.TxtCedula.Text = DataGridView1.CurrentRow.Cells(1).Value

    End Sub

    'EVENTO PARA CUANDO DIGITE SOBRE EL DATAGRID MUESTRE EL RESULTADO EN OTRO PANEL
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        FrmCompras.TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
        FrmCompras.TextBox5.Text = DataGridView1.CurrentRow.Cells(2).Value

        'creo la variable para preguntar sobre la atencion del paciente
        Dim resultA As DialogResult = MessageBox.Show("Desea Continuar?, Si para Comprar, No para regresar", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'CONSULTO SI DE DESEA ATENDER LA CONSULTA Y SI ES SI ABRIR FORM
        If resultA = DialogResult.Yes Then
            'desactivo el datagrid
            Me.DataGridView1.Enabled = False
            'ubicamos la la informacion a presentar en el otro formulario Consulta2
            ModuleFrm.Nom_consulta = FrmCompras.TextBox5.Text
            ModuleFrm.ced_consulta = FrmCompras.TextBox2.Text

            'creo el form
            Dim frm1 As New FrmEvidencia
            'abro el otro formulario
            frm1.ShowDialog()
            'cierro la forma actual
            Me.Close()
        Else
            'ubico el cursor para definir el paciente que va atender
            Me.TxtBuscar.Focus()
        End If
        Me.BtnBuscar.Enabled = False
    End Sub

    'BOTON DE CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub


#End Region


End Class