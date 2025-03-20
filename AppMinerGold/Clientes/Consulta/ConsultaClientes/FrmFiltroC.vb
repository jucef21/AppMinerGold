Imports System.Data.OleDb

Public Class FrmFiltroC

    'FILTRO PARA CLIENTES

    Dim listDGV As List(Of Cliente)

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
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE nom_cl LIKE '%" & busqueda & "%'", conn)
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function

    'FILTRO POR APELLIDOS
    Function FiltroApellido(ByVal busqueda As String) As DataTable
        conn.Open()
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE ape_cl LIKE '%" & busqueda & "%'", conn)
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function

    'FILTRO POR CEDULA
    Function FiltroCedula(ByVal busqueda As String) As DataTable
        conn.Open()
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE ced_cl LIKE '%" & busqueda & "%'", conn)
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
            Dim filtered = (From x In listDGV Where (((x.Nom_cl IsNot Nothing) AndAlso (x.Nom_cl.StartsWith(TextBuscar.Text)))) Select x).ToList()
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
                Dim consultaSQL As String = " Select control_cl as Código, nom_cl as Nombre, ape_cl as Apellidos, ced_cl as Cedula, dire_cl as Dirección, telf_cl as Telefono from Clientes where controlcl LIKE '%" + TextBuscar.Text + "%'"
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
                Dim consultaSQL As String = " Select control_cl as Código, ced_cl as Cedula, nom_cl as Nombre, ape_cl as Apellidos, dire_cl as Dirección, telf_cl as Telefono from Clientes where ced_cl LIKE '%" + TextBuscar.Text + "%'"
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
                Dim consultaSQL As String = " Select control_cl as Código, nom_cl as Nombre, ape_cl as Apellidos, ced_cl as Cedula, dire_cl as Dirección, telf_cl as Telefono from Clientes where nom_cl LIKE '%" + TextBuscar.Text + "%'"
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
                Dim consultaSQL As String = " Select control_cl as Código, ape_cl as Apellidos, nom_cl as Nombre, ced_cl as Cedula, dire_cl as Dirección, telf_cl as Telefono from Clientes where ape_cl LIKE '%" + TextBuscar.Text + "%'"
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

        conn.Close()

        Me.Close()
    End Sub

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

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class