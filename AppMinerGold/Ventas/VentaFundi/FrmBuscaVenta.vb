Imports System.Data.OleDb

Public Class FrmBuscaVenta

    'CARGUE DEL FORMULARIO
    Private Sub FrmBuscaVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'INHABILITO EL CURSOR
        Me.TxtBuscar.Enabled = False

        ConsuEmp()

        'CONSULTO EL LLENADO DEL DATAGRID
        If Me.TxtBuscar.Text = datosEmpresa Then
            'activo el datagrid
            Me.DGVbuscaVenta.Enabled = True
            'lleno los datos al datagrid
            If FiltroVentas(Me.TxtBuscar.Text).Rows.Count > 0 Then
                DGVbuscaVenta.DataSource = FiltroVentas(Me.TxtBuscar.Text)
            Else
                MsgBox("La Letra Inicial del Nombre de la Empresa No se encuentra en la Base de Datos...!", MsgBoxStyle.Information, "AppMinerGold")
            End If
        End If
    End Sub

    'CONSULTA EL NOMBRE DE LA EMPRESA
    Function ConsuEmp()
        'CONECTO LA BASE DE DATOS
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        Try
            cmd = New OleDbCommand("SELECT nombre_empresa FROM Empresa", conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                datosEmpresa = CStr(dr.Item("nombre_empresa"))
            End If
            dr.Close()
            Me.TxtBuscar.Text = datosEmpresa
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return datosEmpresa
        conn.Close()
    End Function

    'FUNCION DE FILTRAR NOMBRE DE UN DATAGRID
    Function FiltroVentas(ByVal busqueda As String) As DataTable
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
        DGVbuscaVenta.DataSource = dv
        conn.Close()
        Return dt
    End Function

    'FORMATEANDO LAS CELDAS DE UN DATAGRIDVIEW
    Private Sub DGVbuscaVenta_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVbuscaVenta.CellFormatting
        'activo el datagrid
        Me.DGVbuscaVenta.Enabled = True

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVbuscaVenta.RowsDefaultCellStyle
            Me.DGVbuscaVenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVbuscaVenta.Columns(0).Width = 40
            Me.DGVbuscaVenta.Columns(0).HeaderText = "Id"

            Me.DGVbuscaVenta.Columns(1).Width = 120
            Me.DGVbuscaVenta.Columns(1).HeaderText = "Nit Empresa"
            Me.DGVbuscaVenta.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVbuscaVenta.Columns(2).Width = 240
            Me.DGVbuscaVenta.Columns(2).HeaderText = "Nombre de la Empresa"
            Me.DGVbuscaVenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVbuscaVenta.Columns("apell_user").Visible = False
            Me.DGVbuscaVenta.Columns("sexo_user").Visible = False
            Me.DGVbuscaVenta.Columns("fechanace_user").Visible = False
            Me.DGVbuscaVenta.Columns("telfijo_user").Visible = False
            Me.DGVbuscaVenta.Columns("telcel_user").Visible = False
            Me.DGVbuscaVenta.Columns("ciudad_user").Visible = False
            Me.DGVbuscaVenta.Columns("dire_user").Visible = False
            Me.DGVbuscaVenta.Columns("correo_user").Visible = False
            Me.DGVbuscaVenta.Columns("codigo_user").Visible = False
            Me.DGVbuscaVenta.Columns("cargo_user").Visible = False
            Me.DGVbuscaVenta.Columns("usuario").Visible = False
            Me.DGVbuscaVenta.Columns("clave").Visible = False
            Me.DGVbuscaVenta.Columns("tipo_user").Visible = False
            Me.DGVbuscaVenta.Columns("tipo_efect").Visible = False
            Me.DGVbuscaVenta.Columns("fecha_creado").Visible = False
            Me.DGVbuscaVenta.Columns("fecha_modifica").Visible = False
        End With

    End Sub

    'EVENTO PARA CUANDO DIGITE SOBRE EL DATAGRID MUESTRE EL RESULTADO EN OTRO PANEL
    Private Sub DGVbuscaVenta_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVbuscaVenta.CellClick

        'FUNCIONA DENTRO DEL MISMO FORMULARIO . seleccion de la informacion al hacer doble click
        Me.TextBox1.Text = Me.DGVbuscaVenta.CurrentRow.Cells(1).Value
        Me.TextBox2.Text = Me.DGVbuscaVenta.CurrentRow.Cells(2).Value

        'creo la variable para preguntar sobre la atencion del paciente
        Dim resultA As DialogResult = MessageBox.Show("Click en SI para Ingresar Operaciones, o NO para regresar", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'CONSULTO SI DE DESEA ATENDER LA CONSULTA Y SI ES SI ABRIR FORM
        If resultA = DialogResult.Yes Then
            'desactivo el datagrid
            Me.DGVbuscaVenta.Enabled = False
            '===============================================================================
            '*** CAMPOS CONSULTADOS DEL DATAGRIDVIEW ***
            '===============================================================================
            'ubicamos la la informacion a presentar en el otro formulario Consulta2
            ModuleFrm.ced_consulta = Me.TextBox1.Text
            ModuleFrm.Nom_consulta = Me.TextBox2.Text

            'creo el form
            Dim frm1 As New FrmVentaGold
            'abro el otro formulario
            frm1.ShowDialog()
            'cierro la forma actual
            Me.Close()
        Else
            'ubico el cursor
            Me.TxtBuscar.Focus()
        End If

    End Sub

    'BOTON DE REGRESAR
    Private Sub BtnRegBusca_Click(sender As Object, e As EventArgs) Handles BtnRegBusca.Click
        'cierro conexion
        conn.Close()
        'cierro el formulario
        Me.Close()
        'llamo al formualrio principal
        FrmCajaMenu.Show()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub
End Class