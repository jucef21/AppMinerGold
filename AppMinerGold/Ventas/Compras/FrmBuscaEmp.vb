Imports System.Data.OleDb

Public Class FrmBuscaEmp

    'CARGUE DEL FORMULARIO
    Private Sub FrmBuscaEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'INHABILITO EL CURSOR
        Me.TxtBuscar.Enabled = False

        ConsuEmp()

        'CONSULTO EL LLENADO DEL DATAGRID
        If Me.TxtBuscar.Text = datosEmpresa Then
            'activo el datagrid
            Me.DGVbuscaEmp.Enabled = True
            'lleno los datos al datagrid
            If FiltroEmpresa(Me.TxtBuscar.Text).Rows.Count > 0 Then
                DGVbuscaEmp.DataSource = FiltroEmpresa(Me.TxtBuscar.Text)
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
    Function FiltroEmpresa(ByVal busqueda As String) As DataTable
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
        DGVbuscaEmp.DataSource = dv
        conn.Close()
        Return dt
    End Function

    'FORMATEANDO LAS CELDAS DE UN DATAGRIDVIEW
    Private Sub DGVbuscaEmp_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVbuscaEmp.CellFormatting
        'activo el datagrid
        Me.DGVbuscaEmp.Enabled = True

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVbuscaEmp.RowsDefaultCellStyle
            Me.DGVbuscaEmp.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVbuscaEmp.Columns(0).Width = 40
            Me.DGVbuscaEmp.Columns(0).HeaderText = "Id"

            Me.DGVbuscaEmp.Columns(1).Width = 120
            Me.DGVbuscaEmp.Columns(1).HeaderText = "Nit Empresa"
            Me.DGVbuscaEmp.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVbuscaEmp.Columns(2).Width = 240
            Me.DGVbuscaEmp.Columns(2).HeaderText = "Nombre de la Empresa"
            Me.DGVbuscaEmp.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVbuscaEmp.Columns("apell_user").Visible = False
            Me.DGVbuscaEmp.Columns("sexo_user").Visible = False
            Me.DGVbuscaEmp.Columns("fechanace_user").Visible = False
            Me.DGVbuscaEmp.Columns("telfijo_user").Visible = False
            Me.DGVbuscaEmp.Columns("telcel_user").Visible = False
            Me.DGVbuscaEmp.Columns("ciudad_user").Visible = False
            Me.DGVbuscaEmp.Columns("dire_user").Visible = False
            Me.DGVbuscaEmp.Columns("correo_user").Visible = False
            Me.DGVbuscaEmp.Columns("codigo_user").Visible = False
            Me.DGVbuscaEmp.Columns("cargo_user").Visible = False
            Me.DGVbuscaEmp.Columns("usuario").Visible = False
            Me.DGVbuscaEmp.Columns("clave").Visible = False
            Me.DGVbuscaEmp.Columns("tipo_user").Visible = False
            Me.DGVbuscaEmp.Columns("tipo_efect").Visible = False
            Me.DGVbuscaEmp.Columns("fecha_creado").Visible = False
            Me.DGVbuscaEmp.Columns("fecha_modifica").Visible = False
        End With


    End Sub

    'EVENTO PARA CUANDO DIGITE SOBRE EL DATAGRID MUESTRE EL RESULTADO EN OTRO PANEL
    Private Sub DGVbuscaEmp_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVbuscaEmp.CellClick

        'FUNCIONA DENTRO DEL MISMO FORMULARIO . seleccion de la informacion al hacer doble click
        Me.TextBox1.Text = Me.DGVbuscaEmp.CurrentRow.Cells(1).Value
        Me.TextBox2.Text = Me.DGVbuscaEmp.CurrentRow.Cells(2).Value

        'creo la variable para preguntar sobre la atencion del paciente
        Dim resultA As DialogResult = MessageBox.Show("Click en SI para Ingresar Operaciones, o NO para regresar", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'CONSULTO SI DE DESEA ATENDER LA CONSULTA Y SI ES SI ABRIR FORM
        If resultA = DialogResult.Yes Then
            'desactivo el datagrid
            Me.DGVbuscaEmp.Enabled = False
            '===============================================================================
            '*** CAMPOS CONSULTADOS DEL DATAGRIDVIEW ***
            '===============================================================================
            'ubicamos la la informacion a presentar en el otro formulario Consulta2
            ModuleFrm.ced_consulta = Me.TextBox1.Text
            ModuleFrm.Nom_consulta = Me.TextBox2.Text

            'creo el form
            Dim frm1 As New FrmCompraTraslado
            'abro el otro formulario
            frm1.ShowDialog()
            'cierro la forma actual
            Me.Close()
        Else
            'ubico el cursor
            Me.TxtBuscar.Focus()
        End If

    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class