Imports System.Data.OleDb

Public Class FrmBuscaCambio

    'CARGUE DEL FORMULARIO
    Private Sub FrmBuscaCambio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True
        Me.TxtBuscar.Enabled = True

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
        Me.Panel1.Select()
        Me.GroupBox3.Select()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Clear()
        Me.TxtBuscar.Focus()

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE BUSCAR
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        'verifico el campo vacio
        If Me.TxtBuscar.Text = "" Then
            MessageBox.Show("Para hacer una Consulta debe Digitar el Número de Cédula! ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
        Else
            'activo el datagrid
            Me.DataGridView1.Enabled = True
            'lleno los datos al datagrid
            If Filtro(Me.TxtBuscar.Text).Rows.Count > 0 Then
                DataGridView1.DataSource = Filtro(Me.TxtBuscar.Text)
                Me.TxtBuscar.Enabled = False
            Else
                MessageBox.Show("El Número que Digíto No existe en la Base de Datos, Digite un Nuevo Número!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Panel1.Select()
                Me.GroupBox3.Select()
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Clear()
                Me.TxtBuscar.Focus()

                'habilito los botones
                Me.BtnBuscar.Enabled = True
                Me.BtnLimpiar.Enabled = True
                Me.TxtBuscar.Enabled = True

                'limpio el datagrid
                DataGridView1.ClearSelection()
                DataGridView1.DataSource = Nothing
                DataGridView1.Columns.Clear()
            End If
        End If
    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        'cierro la conexion
        conn.Close()

        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True
        Me.TxtBuscar.Enabled = True

        'UBICO EL CURSOR
        Me.Panel1.Select()
        Me.GroupBox3.Select()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Clear()
        Me.TxtBuscar.Focus()
    End Sub



#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    'FUNCION DE FILTRAR NOMBRE DE UN DATAGRID
    Function Filtro(ByVal busqueda As String) As DataTable
        Dim NumCed As String = TxtBuscar.Text
        conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        'Dim da As New OleDbDataAdapter("SELECT TOP 1 * FROM Clientes WHERE nom_cl LIKE '" & busqueda.Trim & "%' ORDER BY id DESC", conn)
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE ced_cl = " & NumCed, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Clientes")
        DataGridView1.DataSource = dv
        conn.Close()
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

            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(0).Width = 40
            Me.DataGridView1.Columns(0).HeaderText = "Id"
            Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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
            Me.DataGridView1.Columns("id").Visible = True                             '00
            Me.DataGridView1.Columns("ced_cl").Visible = False                        '01
            Me.DataGridView1.Columns("tipoced_cl").Visible = False                    '02
            Me.DataGridView1.Columns("fechaexp_cl").Visible = False                   '03
            Me.DataGridView1.Columns("ciudexp_cl").Visible = False                    '04
            Me.DataGridView1.Columns("nom_cl").Visible = True                         '05
            Me.DataGridView1.Columns("ape_cl").Visible = True                         '06
            Me.DataGridView1.Columns("fechanace_cl").Visible = False                  '07
            Me.DataGridView1.Columns("lugarnace_cl").Visible = False                  '08
            Me.DataGridView1.Columns("dire_cl").Visible = False                       '09
            Me.DataGridView1.Columns("ciud_cl").Visible = False                       '10
            Me.DataGridView1.Columns("telf_cl").Visible = False                       '11
            Me.DataGridView1.Columns("telc_cl").Visible = False                       '12
            Me.DataGridView1.Columns("correo_cl").Visible = False                     '13
            Me.DataGridView1.Columns("pais_cl").Visible = False                       '14
            Me.DataGridView1.Columns("control_cl").Visible = False                    '15
            Me.DataGridView1.Columns("fecha_creado").Visible = False                  '16
            Me.DataGridView1.Columns("fecha_modifica").Visible = False                '17
            Me.DataGridView1.Columns("img").Visible = False                           '18
            Me.DataGridView1.Columns("huella").Visible = False                        '19
            Me.DataGridView1.Columns("dpto").Visible = False                          '20
            Me.DataGridView1.Columns("detact").Visible = False                        '21
            Me.DataGridView1.Columns("direzonas").Visible = False                     '22
            Me.DataGridView1.Columns("material").Visible = False                      '23
            Me.DataGridView1.Columns("ciudadCompra").Visible = False                  '24
            Me.DataGridView1.Columns("rut").Visible = False                           '25
            Me.DataGridView1.Columns("actividad1").Visible = False                    '26
            Me.DataGridView1.Columns("fechaAct1").Visible = False                     '27
            Me.DataGridView1.Columns("rol").Visible = False                           '28
            Me.DataGridView1.Columns("tipoper").Visible = False                       '29
            Me.DataGridView1.Columns("obspro").Visible = False                        '30
            Me.DataGridView1.Columns("codigoDane").Visible = False                    '31
            Me.DataGridView1.Columns("fechaActual").Visible = False                   '32
            Me.DataGridView1.Columns("A1").Visible = False                            '33
            Me.DataGridView1.Columns("ruta").Visible = False                          '34

        End With

        Me.TxtCedula.Text = DataGridView1.CurrentRow.Cells(1).Value

    End Sub

    'EVENTO PARA CUANDO DIGITE SOBRE EL DATAGRID MUESTRE EL RESULTADO EN OTRO PANEL
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        ModuleFrm.Nombre = DataGridView1.CurrentRow.Cells(5).Value
        ModuleFrm.Apellido = DataGridView1.CurrentRow.Cells(6).Value
        ModuleFrm.Cedula = DataGridView1.CurrentRow.Cells(1).Value

        'creo la variable para preguntar sobre la atencion del paciente
        Dim Pregunta As DialogResult = MessageBox.Show("Desea Continuar?, Si para Continuar, No para regresar", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'CONSULTO SI DE DESEA ATENDER LA CONSULTA Y SI ES SI ABRIR FORM
        If Pregunta = DialogResult.Yes Then
            Me.TxtBuscar.Text = ""
            'desactivo el datagrid
            Me.DataGridView1.Enabled = False
            Me.DataGridView1.DataSource = Nothing
            'creo el form
            'Dim f2 As New FrmEvidencia
            Dim f2 As New FrmCambioName
            'abro el otro formulario
            f2.ShowDialog()
        Else
            'ubico el cursor para definir el paciente que va atender
            Me.TxtBuscar.Text = ""
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
        End If

        Me.BtnBuscar.Enabled = False

    End Sub

#End Region

    Private Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress
        SoloNumeros(e)
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub


End Class