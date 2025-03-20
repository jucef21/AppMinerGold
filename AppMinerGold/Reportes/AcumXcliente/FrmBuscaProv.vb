Imports System.Data.OleDb

Public Class FrmBuscaProv

    'CARGUE DEL FORMULARIO
    Private Sub FrmBuscaProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ubicamos el cursor
        'Me.Show()
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Text = ""
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

        Me.DGVprov.DataSource = Nothing

        'Habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = False

    End Sub

#Region "PROCEDIMIENTOS PARA FILTRAR POR NOMBRE EN EL DATAGRID"

    'FUNCION DE FILTRAR NUMERO DE DOCUMENTO DE INGRESO
    Function FiltroProv(ByVal busqueda As String) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE ced_cl LIKE '" & busqueda.Trim & "%' ORDER BY ced_cl ASC", conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Clientes")
        DGVprov.DataSource = dv
        Return dt
    End Function

    'FUNCION DE FILTRAR CEDULA DE UN DATAGRID
    Function FiltroCedula(ByVal busqueda As String) As DataTable
        Dim NumConse As Integer = CInt(TxtBuscar.Text)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE ced_cl = " & NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Clientes")
        DGVprov.DataSource = dv
        Return dt
    End Function

    'CAMPO TEXTO DE BUSCAR
    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        Me.BtnBuscar.Show()
    End Sub

    'FORMATEANDO LAS CELDAS DE UN DATAGRIDVIEW
    Private Sub DGVprov_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVprov.CellFormatting
        'activo el datagrid
        Me.DGVprov.Enabled = True

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVprov.RowsDefaultCellStyle
            Me.DGVprov.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVprov.Columns(0).Width = 70
            Me.DGVprov.Columns(0).HeaderText = "Id"

            Me.DGVprov.Columns(1).Width = 110
            Me.DGVprov.Columns(1).HeaderText = "Cédula del Cliente"
            Me.DGVprov.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVprov.Columns(5).Width = 170
            Me.DGVprov.Columns(5).HeaderText = "Nombre del Cliente"
            Me.DGVprov.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVprov.Columns(6).Width = 150
            Me.DGVprov.Columns(6).HeaderText = "Apellido del Cliente"
            Me.DGVprov.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVprov.Columns("Id").Visible = True                '00
            Me.DGVprov.Columns("ced_cl").Visible = True            '01
            Me.DGVprov.Columns("tipoced_cl").Visible = False       '02
            Me.DGVprov.Columns("fechaexp_cl").Visible = False      '03
            Me.DGVprov.Columns("ciudexp_cl").Visible = False       '04
            Me.DGVprov.Columns("nom_cl").Visible = True            '05
            Me.DGVprov.Columns("ape_cl").Visible = True            '06
            Me.DGVprov.Columns("fechanace_cl").Visible = False     '07
            Me.DGVprov.Columns("lugarnace_cl").Visible = False     '08
            Me.DGVprov.Columns("dire_cl").Visible = True           '09
            Me.DGVprov.Columns("ciud_cl").Visible = True           '10
            Me.DGVprov.Columns("telf_cl").Visible = False          '11
            Me.DGVprov.Columns("telc_cl").Visible = False          '12
            Me.DGVprov.Columns("correo_cl").Visible = False        '13
            Me.DGVprov.Columns("pais_cl").Visible = False          '14
            Me.DGVprov.Columns("control_cl").Visible = False       '15
            Me.DGVprov.Columns("fecha_creado").Visible = False     '16
            Me.DGVprov.Columns("fecha_modifica").Visible = False   '17
            Me.DGVprov.Columns("img").Visible = False              '18
            Me.DGVprov.Columns("huella").Visible = False           '19
            Me.DGVprov.Columns("dpto").Visible = False             '20
            Me.DGVprov.Columns("detact").Visible = False           '21
            Me.DGVprov.Columns("direzonas").Visible = False        '22
            Me.DGVprov.Columns("material").Visible = False         '23
            Me.DGVprov.Columns("ciudadCompra").Visible = False     '24
            Me.DGVprov.Columns("rut").Visible = False              '25
            Me.DGVprov.Columns("actividad1").Visible = False       '26
            Me.DGVprov.Columns("fechaAct1").Visible = False        '27
            Me.DGVprov.Columns("rol").Visible = False              '28
            Me.DGVprov.Columns("tipoper").Visible = False          '29
            Me.DGVprov.Columns("obspro").Visible = False           '30
            Me.DGVprov.Columns("codigoDane").Visible = False       '31
            Me.DGVprov.Columns("fechaActual").Visible = False      '32
            Me.DGVprov.Columns("A1").Visible = False               '33

        End With

    End Sub

    'EVENTO PARA CUANDO DIGITE SOBRE EL DATAGRID MUESTRE EL RESULTADO EN OTRO PANEL
    Private Sub DGVprov_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVprov.CellDoubleClick

        'FUNCIONA DENTRO DEL MISMO FORMULARIO . seleccion de la informacion al hacer doble click
        Me.TextBox1.Text = Me.DGVprov.CurrentRow.Cells(1).Value
        Me.TextBox2.Text = Me.DGVprov.CurrentRow.Cells(5).Value

        'creo la variable para preguntar sobre la atencion del paciente
        Dim resultA As DialogResult = MessageBox.Show("Click en SI para Continuar, o NO para regresar", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'CONSULTO SI DE DESEA ATENDER LA CONSULTA Y SI ES SI ABRIR FORM
        If resultA = DialogResult.Yes Then
            'manejo dek cursor
            Me.Cursor = Cursors.WaitCursor

            'desactivo el datagrid
            Me.DGVprov.Enabled = False
            '===============================================================================
            '*** CAMPOS CONSULTADOS DEL DATAGRIDVIEW ***
            '===============================================================================
            'ubicamos la la informacion a presentar en el otro formulario Consulta2
            ModuleFrm.ced_consulta = Me.TextBox1.Text
            ModuleFrm.Nom_consulta = Me.TextBox2.Text

            'creo el form
            Dim frm1 As New FrmAcumXcliente

            'abro el otro formulario
            frm1.ShowDialog()

            'cierro la forma actual
            Me.Close()

            'manejo dek cursor
            Me.Cursor = Cursors.Default

        Else
            'ubico el cursor
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()

        End If

        'habilitamos los botones 
        Me.BtnBuscar.Enabled = False

    End Sub

#End Region

#Region "BOTONES DEL FORMULARIO"

    'BOTON BUSCAR
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        'verifico el campo vacio
        If Me.TxtBuscar.Text = "" Then
            MessageBox.Show("Para hacer una Consulta debe Digitar la Cédula de Cliente...! ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Ubico el cursor
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
            'Habilito los botones
            Me.BtnBuscar.Enabled = True
            Me.BtnLimpiar.Enabled = False
        Else
            'manejo del cursor
            Me.Cursor = Cursors.WaitCursor
            'lleno los datos al datagrid
            If FiltroCedula(Me.TxtBuscar.Text).Rows.Count > 0 Then
                DGVprov.DataSource = FiltroCedula(Me.TxtBuscar.Text)
                MessageBox.Show("Busqueda Encontrada, Aceptar para Continuar.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Envio el numero de documento buscado al reporte
                'FUNCIONA DENTRO DEL MISMO FORMULARIO . seleccion de la informacion al hacer doble click
                Me.TextBox1.Text = Me.DGVprov.CurrentRow.Cells(1).Value
                Me.TextBox2.Text = Me.DGVprov.CurrentRow.Cells(5).Value
                'ubicamos la la informacion a presentar en el otro formulario Consulta2
                ModuleFrm.ced_consulta = Me.TextBox1.Text
                ModuleFrm.Nom_consulta = Me.TextBox2.Text
                FrmAcumXcliente.ShowDialog()
                'Habilito los botones
                Me.BtnBuscar.Enabled = False
                Me.BtnLimpiar.Enabled = True
                Me.TxtBuscar.Enabled = False
            Else
                MessageBox.Show("No se encontro ningún Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Limpiar_Cajas()
                'limpio y ubico el cursor
                Me.TxtBuscar.Text = ""
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Focus()
                'Habilito los botones
                Me.BtnBuscar.Enabled = False
                Me.BtnLimpiar.Enabled = True
            End If
            'manejo del cursor
            Me.Cursor = Cursors.Default
        End If
        'manejo del cursor
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON LIMPIAR
    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click

        'limpio el datagrid
        DGVprov.ClearSelection()
        DGVprov.DataSource = Nothing
        DGVprov.Columns.Clear()

        'ubico el cursor
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Text = ""
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

        'habilitamos el boton
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = False

    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "Limpieza de Campos"

    'limpia las cajas de texto
    Private Sub Limpiar_Cajas()
        ' recorrer todos los controles del formulario indicado  
        'limpio el datagrid
        'DGVconsupagos.Rows.Clear()                          'para limpiarlo
        DGVprov.DataSource = Nothing
        Me.TxtBuscar.Text = ""

        'limpia texto
        Me.TxtBuscar.Clear()

    End Sub

    'valida solo letras
    Private Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress
        SoloNumeros(e)
    End Sub


#End Region




End Class