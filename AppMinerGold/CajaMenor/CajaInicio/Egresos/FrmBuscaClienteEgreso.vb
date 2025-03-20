Imports System.Data.OleDb

Public Class FrmBuscaClienteEgreso

    'CARGUE DEL FORMULARIO
    Private Sub FrmBuscaClienteEgreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'INHABILITO EL CURSOR
        Me.TxtBuscar.Enabled = False
        'ASIGNO EL NOMBRE AL CAMPO
        Me.TxtBuscar.Text = datosUsuario
        'CONSULTO EL LLENADO DEL DATAGRID
        If Me.TxtBuscar.Text = datosUsuario Then
            'activo el datagrid
            Me.DGVcaja.Enabled = True
            'lleno los datos al datagrid
            If FiltroCaja(Me.TxtBuscar.Text).Rows.Count > 0 Then
                DGVcaja.DataSource = FiltroCaja(Me.TxtBuscar.Text)
            Else
                MsgBox("La Letra Inicial del Nombre del Cliente No se encuentra en la Base de Datos...!", MsgBoxStyle.Information, "AppMinerGold")
            End If
        End If

        VerCiudad()

    End Sub

    'FUNCION DE FILTRAR NOMBRE DE UN DATAGRID
    Function FiltroCaja(ByVal busqueda As String) As DataTable
        'CONECTO LA BASE DE DATOS
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM Usuarios WHERE nom_user LIKE '" & busqueda.Trim & "%' ", conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Usuarios")
        DGVcaja.DataSource = dv
        conn.Close()
        Return dt
    End Function

    'PROCEDIMIENTO PARA VER CIUDAD
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
            MsgBox("No se encontro CIUDAD", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
        Conectar.conn.Close()
    End Sub

    'FORMATEANDO LAS CELDAS DE UN DATAGRIDVIEW
    Private Sub DGVcaja_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVcaja.CellFormatting
        'activo el datagrid
        Me.DGVcaja.Enabled = True

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVcaja.RowsDefaultCellStyle
            Me.DGVcaja.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVcaja.Columns(0).Width = 40
            Me.DGVcaja.Columns(0).HeaderText = "Id"

            Me.DGVcaja.Columns(1).Width = 90
            Me.DGVcaja.Columns(1).HeaderText = "Cédula del Cliente"
            Me.DGVcaja.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVcaja.Columns(2).Width = 140
            Me.DGVcaja.Columns(2).HeaderText = "Nombre del Cliente"
            Me.DGVcaja.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVcaja.Columns(3).Width = 140
            Me.DGVcaja.Columns(3).HeaderText = "Apellido del Cliente"
            Me.DGVcaja.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVcaja.Columns("sexo_user").Visible = False
            Me.DGVcaja.Columns("fechanace_user").Visible = False
            Me.DGVcaja.Columns("telfijo_user").Visible = False
            Me.DGVcaja.Columns("telcel_user").Visible = False
            Me.DGVcaja.Columns("ciudad_user").Visible = False
            Me.DGVcaja.Columns("dire_user").Visible = False
            Me.DGVcaja.Columns("correo_user").Visible = False
            Me.DGVcaja.Columns("codigo_user").Visible = False
            Me.DGVcaja.Columns("cargo_user").Visible = False
            Me.DGVcaja.Columns("usuario").Visible = False
            Me.DGVcaja.Columns("clave").Visible = False
            Me.DGVcaja.Columns("tipo_user").Visible = False
            Me.DGVcaja.Columns("tipo_efect").Visible = False
            Me.DGVcaja.Columns("fecha_creado").Visible = False
            Me.DGVcaja.Columns("fecha_modifica").Visible = False
        End With

    End Sub

    'EVENTO PARA CUANDO DIGITE SOBRE EL DATAGRID MUESTRE EL RESULTADO EN OTRO PANEL
    Private Sub DGVcaja_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVcaja.CellClick

        'FUNCIONA DENTRO DEL MISMO FORMULARIO . seleccion de la informacion al hacer doble click
        Me.TextBox1.Text = Me.DGVcaja.CurrentRow.Cells(1).Value
        Me.TextBox2.Text = Me.DGVcaja.CurrentRow.Cells(2).Value

        'creo la variable para preguntar sobre la atencion del paciente
        Dim resultA As DialogResult = MessageBox.Show("Click en SI para Ingresar Operaciones, o NO para regresar", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'CONSULTO SI DE DESEA ATENDER LA CONSULTA Y SI ES SI ABRIR FORM
        If resultA = DialogResult.Yes Then
            'desactivo el datagrid
            Me.DGVcaja.Enabled = False
            '===============================================================================
            '*** CAMPOS CONSULTADOS DEL DATAGRIDVIEW ***
            '===============================================================================
            'ubicamos la la informacion a presentar en el otro formulario Consulta2
            ModuleFrm.ced_consulta = Me.TextBox1.Text
            ModuleFrm.Nom_consulta = Me.TextBox2.Text
            ModuleFrm.VerCiudad = Me.TxtEmpCiu.Text

            'creo el form
            Dim frm1 As New FrmEgresoCajaMenor
            'abro el otro formulario
            frm1.ShowDialog()
            'cierro la forma actual
            Me.Close()
        Else
            'ubico el cursor
            Me.TxtBuscar.Focus()
        End If

    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class