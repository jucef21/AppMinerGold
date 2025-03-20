Imports System.Data.OleDb
Imports System.IO

Public Class FrmBuscaProve

    'CREAR VARIABLES 
    Private strConexion As OleDb.OleDbConnection
    Private DS_CA As DataSet
    Private DA_CA As OleDbDataAdapter
    Private Posicion_CA As Integer

    'CARGUE DEL FORMULARIO
    Private Sub FrmBuscaProve_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UBICO EL CURSOR
        Me.GroupBox1.Select()
        Me.TxtCedulaProv.Select()
        Me.TxtCedulaProv.Focus()
        'Habilto los campos
        Me.TxtCedulaProv.Enabled = True
        Me.BtnBuscarProv.Enabled = True

    End Sub

    'BOTON DE SALIR
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    'BOTON DE BUSCAR
    Dim Datos As DataSet
    Dim adaptador As OleDbDataAdapter
    Dim consulta As String
    Dim lista As Byte
    Private Sub BtnBuscarProv_Click(sender As Object, e As EventArgs) Handles BtnBuscarProv.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cedula As String = Me.TxtCedulaProv.Text
        Dim Imagh As String = cedula + ".jpg"
        Dim SaveDirectory As String = "C:\FotoProHuella\"
        Dim Filename As String = Path.GetFileName(Imagh)
        Dim SavePath As String = Path.Combine(SaveDirectory, Filename)

        'LIMPIO LOS CAMPOS
        LimpiarCamposProv()
        Dim numceduprov As Integer = CInt(TxtCedulaProv.Text)
        'verifico el campo vacio
        If Me.TxtCedulaProv.Text <> "" Then
            consulta = "SELECT * FROM Clientes WHERE ced_cl = " & numceduprov
            adaptador = New OleDbDataAdapter(consulta, conn)
            Datos = New DataSet
            adaptador.Fill(Datos, "Clientes")
            lista = Datos.Tables("Clientes").Rows.Count
            Me.TxtCedulaProv.Enabled = False
            Me.BtnBuscarProv.Enabled = False
            Me.Close()
            conn.Close()
        Else
            MsgBox("Para hacer una Consulta debe Digitar la cedula del Proveedor.", MsgBoxStyle.Information, "AppMinerGold")
            Me.TxtCedulaProv.Select()
            Me.TxtCedulaProv.Focus()
        End If

        'obtener un objeto con la fila actual
        If lista <> 0 Then

            'LISTAMOS LA FOTO
            FrmVerClientes.PictureFoto.Image = Nothing
            Dim I() As Byte = Datos.Tables("Clientes").Rows(0).Item("img")
            Dim ms = New IO.MemoryStream(I)
            FrmVerClientes.PictureFoto.Image = Image.FromStream(ms)

            'LISTAMOS LA HUELLA
            If System.IO.File.Exists(SavePath) Then
                FrmVerClientes.PictureHuella.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(SavePath))
            Else
                FrmVerClientes.PictureHuella.Image = Global.AppMinerGold.My.Resources.Resources.huellaX
            End If

            FrmVerClientes.TxtCedula.Text = Datos.Tables("Clientes").Rows(0).Item("ced_cl")
            FrmVerClientes.TxtNombres.Text = Datos.Tables("Clientes").Rows(0).Item("nom_cl")
            FrmVerClientes.TxtApellidos.Text = Datos.Tables("Clientes").Rows(0).Item("ape_cl")
            FrmVerClientes.TxtDireccion.Text = Datos.Tables("Clientes").Rows(0).Item("dire_cl")
            FrmVerClientes.TxtCiudad.Text = Datos.Tables("Clientes").Rows(0).Item("ciud_cl")
            FrmVerClientes.TxtTelefono.Text = Datos.Tables("Clientes").Rows(0).Item("telc_cl")
            FrmVerClientes.TxtCorreo.Text = Datos.Tables("Clientes").Rows(0).Item("correo_cl")
        Else
            MsgBox("La Cédula que Digíto No existe en la Base de Datos, Digite una Nueva.!", MsgBoxStyle.Information, "AppMinerGold")
            Me.TxtCedulaProv.Text = ""
            Me.TxtCedulaProv.Select()
            Me.TxtCedulaProv.Focus()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    'PROCEDIMIENTO LIMPIAR CAMPOS
    Private Sub LimpiarCamposProv()
        FrmVerClientes.TxtCedula.Clear()
        FrmVerClientes.TxtNombres.Clear()
        FrmVerClientes.TxtApellidos.Clear()
        FrmVerClientes.TxtDireccion.Clear()
        FrmVerClientes.TxtCiudad.Clear()
        FrmVerClientes.TxtTelefono.Clear()
        FrmVerClientes.TxtCorreo.Clear()
        FrmVerClientes.PictureFoto.Image = Nothing
        FrmVerClientes.PictureHuella.Image = Nothing
    End Sub


    'CAMPO DE TEXTO CEDULA
    Private Sub TxtCedulaProv_TextChanged(sender As Object, e As EventArgs) Handles TxtCedulaProv.TextChanged
        Me.BtnBuscarProv.Show()
    End Sub

    'CAMPO KEYPRESS DE TEXTO - VALIDA SOLO NUMEROS
    Private Sub TxtCedulaProv_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCedulaProv.KeyPress
        'solo acepta numeros
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


End Class