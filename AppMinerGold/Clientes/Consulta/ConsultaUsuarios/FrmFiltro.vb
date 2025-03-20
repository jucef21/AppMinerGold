Imports System.Data.OleDb

Partial Public Class FrmFiltro

    'FILTRO PARA USUARIOS

    Dim listDGV As List(Of Usuario)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Dim conn As New OleDbConnection(cs)

    'CARGUE DEL FORMULARIO
    Private Sub FrmFiltro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ubico el cursor
        'Me.TextBuscar.Focus()
        Me.CboBuscar.Focus()

        'deshabilito el campo de texto
        Me.TextBuscar.Enabled = False

        'deshabilito los botones
        Me.BtnLimpiar.Enabled = False

        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnRegresa.Enabled = True

        'LIMPIO EL COMBOBOX
        Me.CboBuscar.Text = "SELECCIONE"

        LblRegistros.Text = ""

    End Sub


#Region "FILTROS"

    'FILTRO POR NOMBRES
    Function FiltroNombre(ByVal busqueda As String) As DataTable
        conn.Open()
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter("SELECT * FROM Usuarios WHERE nom_user LIKE '%" & busqueda & "%'", conn)
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function

    'FILTRO POR APELLIDOS
    Function FiltroApellido(ByVal busqueda As String) As DataTable
        conn.Open()
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter("SELECT * FROM Usuarios WHERE apell_user LIKE '%" & busqueda & "%'", conn)
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function

    'FILTRO POR CEDULA
    Function FiltroCedula(ByVal busqueda As String) As DataTable
        conn.Open()
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter("SELECT * FROM Usuarios WHERE cedula_user LIKE '%" & busqueda & "%'", conn)
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function

#End Region

    'COMBOBOX DE SELECCION DE OPCIONES
    Private Sub CboBuscar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboBuscar.SelectedIndexChanged
        Try
            'Dim Consulta As String
            If CboBuscar.Text = "" Then
                MsgBox("Debe seleccionar una opción de búsqueda", MsgBoxStyle.Exclamation, "AppMinerGold - Error")
                CboBuscar.Focus()
                Return
            End If

            If CboBuscar.Text = "CODIGO" Then
                'habilito el campo de texto
                Me.TextBuscar.Enabled = True
                Me.TextBuscar.Focus()
            End If

            If CboBuscar.Text = "CEDULA" Then
                'habilito el campo de texto
                Me.TextBuscar.Enabled = True
                Me.TextBuscar.Focus()
            End If

            If CboBuscar.Text = "NOMBRE" Then
                'habilito el campo de texto
                Me.TextBuscar.Enabled = True
                Me.TextBuscar.Focus()

            End If

            If CboBuscar.Text = "APELLIDO" Then
                'habilito el campo de texto
                Me.TextBuscar.Enabled = True
                Me.TextBuscar.Focus()
            End If

            'habilito los botones
            Me.BtnBuscar.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    'TEXBOX DE BUSCAR
    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Try
            Dim filtered = (From x In listDGV Where (((x.Nom_user IsNot Nothing) AndAlso (x.Nom_user.StartsWith(TextBuscar.Text)))) Select x).ToList()
            DgvUsuario.DataSource = filtered
        Catch ex As Exception
            'MsgBox(ex.Message.ToString())
        End Try
    End Sub

    'BOTON BUSCAR
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click

        If TextBuscar.Text = "" Then
            MsgBox("Debe seleccionar una opción de búsqueda", MsgBoxStyle.Information, "AppMinerGold - Error")
            CboBuscar.Focus()
            Me.TextBuscar.Enabled = False
            Return
        End If

        If CboBuscar.Text = "SELECCIONE" Then
            DgvUsuario.DataSource = Nothing
            DgvUsuario.Rows.Clear()
        End If

        If CboBuscar.Text = "CODIGO" Then
            Using cn As New OleDbConnection(cs)
                Dim consultaSQL As String = " Select Id as Código, nom_user as Nombre, apell_user as Apellidos, cedula_user as Cedula, dire_user as Dirección, telfijo_user as Telefono from Usuarios where Id LIKE '%" + TextBuscar.Text + "%'"
                Dim adap As New OleDbDataAdapter(consultaSQL, cn)
                Dim dt As New DataTable()
                adap.Fill(dt)
                'REVISO SI EL RESULTADO ES VALIDO O NULO
                If dt.Rows.Count > 0 Then
                    DgvUsuario.DataSource = dt
                Else
                    MsgBox("El Dato Consultado No Existe, No hay informacion que mostrar", MsgBoxStyle.Information, "AppMinerGold")
                    LimpiaDatos()
                End If
            End Using
        End If

        If CboBuscar.Text = "CEDULA" Then
            Using cn As New OleDbConnection(cs)
                Dim consultaSQL As String = " Select Id as Código,  cedula_user as Cedula, nom_user as Nombre, apell_user as Apellidos, dire_user as Dirección, telfijo_user as Telefono from Usuarios where cedula_user LIKE '%" + TextBuscar.Text + "%'"
                Dim adap As New OleDbDataAdapter(consultaSQL, cn)
                Dim dt As New DataTable()
                adap.Fill(dt)
                'REVISO SI EL RESULTADO ES VALIDO O NULO
                If dt.Rows.Count > 0 Then
                    DgvUsuario.DataSource = dt
                Else
                    MsgBox("El Dato Consultado No Existe, No hay informacion que mostrar", MsgBoxStyle.Information, "AppMinerGold")
                    LimpiaDatos()
                End If
            End Using
        End If

        If CboBuscar.Text = "NOMBRE" Then
            Using cn As New OleDbConnection(cs)
                Dim consultaSQL As String = " Select Id as Código, nom_user as Nombre, apell_user as Apellidos, cedula_user as Cedula, dire_user as Dirección, telfijo_user as Telefono from Usuarios where nom_user LIKE '%" + TextBuscar.Text + "%'"
                Dim adap As New OleDbDataAdapter(consultaSQL, cn)
                Dim dt As New DataTable()
                adap.Fill(dt)
                'REVISO SI EL RESULTADO ES VALIDO O NULO
                If dt.Rows.Count > 0 Then
                    DgvUsuario.DataSource = dt
                Else
                    MsgBox("El Dato Consultado No Existe, No hay informacion que mostrar", MsgBoxStyle.Information, "AppMinerGold")
                    LimpiaDatos()
                End If
            End Using
        End If

        If CboBuscar.Text = "APELLIDO" Then
            Using cn As New OleDbConnection(cs)
                Dim consultaSQL As String = " Select Id as Código,  apell_user as Apellidos, nom_user as Nombre, cedula_user as Cedula, dire_user as Dirección, telfijo_user as Telefono from Usuarios where apell_user LIKE '%" + TextBuscar.Text + "%'"
                Dim adap As New OleDbDataAdapter(consultaSQL, cn)
                Dim dt As New DataTable()
                adap.Fill(dt)
                'REVISO SI EL RESULTADO ES VALIDO O NULO
                If dt.Rows.Count > 0 Then
                    DgvUsuario.DataSource = dt
                Else
                    MsgBox("El Dato Consultado No Existe, No hay informacion que mostrar", MsgBoxStyle.Information, "AppMinerGold")
                    LimpiaDatos()
                End If
            End Using
        End If

        'CUENTO LOS REGISTROS BUSCADOS
        Me.LblRegistros.Text = CStr(DgvUsuario.Rows.Count)

        'habilito los botones
        Me.BtnBuscar.Enabled = False

        'habilito los botones
        Me.BtnLimpiar.Enabled = True
        Me.BtnRegresa.Enabled = True

    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click

        Me.TextBuscar.Text = ""
        Me.CboBuscar.Text = ""
        DgvUsuario.DataSource = Nothing

        'habilito los botones
        Me.BtnBuscar.Enabled = True

        'habilito los botones
        Me.BtnLimpiar.Enabled = False
        Me.BtnRegresa.Enabled = True

        'ubico el cursor
        Me.CboBuscar.Focus()

        'deshabilito el campo de texto
        Me.TextBuscar.Enabled = False

        'LIMPIO EL COMBOBOX
        Me.CboBuscar.Text = "SELECCIONE"

        LblRegistros.Text = ""

    End Sub

    'BOTON DE CERRAR
    Private Sub BtnRegresa_Click(sender As Object, e As EventArgs) Handles BtnRegresa.Click
        Me.Close()
    End Sub

    ''FORMATEANDO LAS CELDAS DE UN DATAGRIDVIEW E USUARIOS
    'Private Sub DgvUsuario_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvUsuario.CellFormatting
    '    'activo el datagrid
    '    Me.DgvUsuario.Enabled = True

    '    'deshabilita el efecto visual de windows ESTILO DE COLOR EN EL DATAGRID
    '    DgvUsuario.EnableHeadersVisualStyles = False
    '    With DgvUsuario.ColumnHeadersDefaultCellStyle
    '        .BackColor = Color.Beige
    '        .Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With

    '    'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES TABLA CITAS
    '    With DgvUsuario.RowsDefaultCellStyle
    '        Me.DgvUsuario.Columns(0).Width = 30
    '        Me.DgvUsuario.Columns(0).HeaderText = "Id"

    '        Me.DgvUsuario.Columns(1).Width = 50
    '        Me.DgvUsuario.Columns(1).HeaderText = "Cédula"
    '        Me.DgvUsuario.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    '        Me.DgvUsuario.Columns(2).Width = 100
    '        Me.DgvUsuario.Columns(2).HeaderText = "Nombre"
    '        Me.DgvUsuario.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '        Me.DgvUsuario.Columns(3).Width = 100
    '        Me.DgvUsuario.Columns(3).HeaderText = "Apellido"
    '        Me.DgvUsuario.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '        Me.DgvUsuario.Columns(6).Width = 10
    '        Me.DgvUsuario.Columns(6).HeaderText = "Teléfono Fijo"
    '        Me.DgvUsuario.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '        Me.DgvUsuario.Columns(9).Width = 100
    '        Me.DgvUsuario.Columns(9).HeaderText = "Dirección"
    '        Me.DgvUsuario.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

    '        'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
    '        Me.DgvUsuario.Columns("sexo_user").Visible = False
    '        Me.DgvUsuario.Columns("fechanace_user").Visible = False
    '        Me.DgvUsuario.Columns("telcel_user").Visible = False
    '        Me.DgvUsuario.Columns("ciudad_user").Visible = False
    '        Me.DgvUsuario.Columns("correo_user").Visible = False
    '        Me.DgvUsuario.Columns("codigo_user").Visible = False
    '        Me.DgvUsuario.Columns("cargo_user").Visible = False
    '        Me.DgvUsuario.Columns("usuario").Visible = False
    '        Me.DgvUsuario.Columns("clave").Visible = False
    '        Me.DgvUsuario.Columns("tipo_user").Visible = False
    '        Me.DgvUsuario.Columns("fecha_creado").Visible = False
    '        Me.DgvUsuario.Columns("fecha_modifica").Visible = False

    '    End With

    'End Sub


    Private Sub LimpiaDatos()
        Me.TextBuscar.Text = ""
        Me.CboBuscar.Text = ""
        DgvUsuario.DataSource = Nothing

        'habilito los botones
        Me.BtnBuscar.Enabled = True

        'habilito los botones
        Me.BtnLimpiar.Enabled = False
        Me.BtnRegresa.Enabled = True

        'ubico el cursor
        Me.CboBuscar.Focus()

        'deshabilito el campo de texto
        Me.TextBuscar.Enabled = False

        'LIMPIO EL COMBOBOX
        Me.CboBuscar.Text = "SELECCIONE"

        LblRegistros.Text = ""
    End Sub


End Class