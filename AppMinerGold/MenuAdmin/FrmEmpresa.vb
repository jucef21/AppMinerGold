Imports System.Data.OleDb

Public Class FrmEmpresa

    'CARGUE DEL FORMULARIO
    Private Sub FrmEmpresa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'limpio las cajas de texto
        Limpiar_Cajas()

        ' habilito campo
        Me.Txtbuscar.Enabled = False

        'habilito los botones
        Me.BtnActDatosEmp.Enabled = True

        'habilitar botones
        Me.BtnBuscar.Enabled = False
        Me.BtnNuevo.Enabled = False
        Me.BtnGuardar.Enabled = False
        Me.BtnModificar.Enabled = False
        Me.BtnGuardaCambios.Enabled = False

        'deshabilitar campos
        'OFICINA PRINCIPAL
        Me.TxtId.Enabled = False
        Me.TxtNit.Enabled = False
        Me.TxtDv.Enabled = False
        Me.TxtRucom.Enabled = False
        Me.TxtRsocial.Enabled = False
        Me.TxtDireEmp.Enabled = False
        Me.TxtTelemp.Enabled = False
        Me.Txtcorreoemp.Enabled = False
        Me.Cbociuemp.Enabled = False
        Me.CboDpto.Enabled = False
        Me.Cbopaisemp.Enabled = False
        Me.Txtweb.Enabled = False
        'OFICINA 1
        Me.TxtDireSucur1.Enabled = False
        Me.TxtTelSucur1.Enabled = False
        Me.CboCiuSucur1.Enabled = False
        Me.TxtCorreoSucur1.Enabled = False
        Me.CboDptoSucur1.Enabled = False
        'OFICINA 2
        Me.TxtDireSucur2.Enabled = False
        Me.TxtTelSucur2.Enabled = False
        Me.CboCiuSucur2.Enabled = False
        Me.TxtCorreoSucur2.Enabled = False
        Me.CboDptoSucur2.Enabled = False
        'DATOS DEL REPRESENTANTE
        Me.Txtrepre.Enabled = False
        Me.Txtcedrepre.Enabled = False
        Me.Txtdirerepre.Enabled = False
        Me.Txttelrepre.Enabled = False
        Me.Txtcorreorepre.Enabled = False

        'conexion del combobox
        Cbociuemp.DropDownStyle = ComboBoxStyle.DropDownList
        CboDpto.DropDownStyle = ComboBoxStyle.DropDownList
        Cbopaisemp.DropDownStyle = ComboBoxStyle.DropDownList

        Cargar_Combo(Cbociuemp, "Select DISTINCT ciudad_col From ciudad Order By ciudad_col")
        Cargar_Combo(CboDpto, "Select DISTINCT departamento From ciudad Order By departamento")
        Cargar_Combo(Cbopaisemp, "Select DISTINCT pais From paises Order By pais")

        CboCiuSucur1.DropDownStyle = ComboBoxStyle.DropDownList
        CboDptoSucur1.DropDownStyle = ComboBoxStyle.DropDownList

        Cargar_Combo(CboCiuSucur1, "Select DISTINCT ciudad_col From ciudad Order By ciudad_col")
        Cargar_Combo(CboDptoSucur1, "Select DISTINCT departamento From ciudad Order By departamento")

        CboCiuSucur2.DropDownStyle = ComboBoxStyle.DropDownList
        CboDptoSucur2.DropDownStyle = ComboBoxStyle.DropDownList

        Cargar_Combo(CboCiuSucur2, "Select DISTINCT ciudad_col From ciudad Order By ciudad_col")
        Cargar_Combo(CboDptoSucur2, "Select DISTINCT departamento From ciudad Order By departamento")

        'ubico el cursor
        Me.Txtbuscar.Select()
        Me.Txtbuscar.Focus()

    End Sub

    'Cargar Combos
    Private Sub Cargar_Combo(ByVal ComboBox As ComboBox, ByVal sql As String)
        ' nueva conexión indicando al SqlConnection la cadena de conexión   
        Dim conn As New OleDbConnection(cs)
        Try
            conn.Open()
            Dim cmd As New OleDbCommand(sql, conn) ' Pasar la consulta sql y la conexión al Sql Command    
            Dim da As New OleDbDataAdapter(cmd) ' Inicializar un nuevo SqlDataAdapter    
            Dim ds As New DataSet 'Crear y Llenar un Dataset   
            da.Fill(ds)
            ComboBox.DataSource = ds.Tables(0) ' asignar el DataSource al combobox   
            ComboBox.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString ' Asignar el campo a la propiedad DisplayMember del combo    
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Error de Conexión al carga el Combo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

#Region "ACTIVACION DE LAS TECLAS ENTER"

    'OFICINA PRINCIPAL
    'valida los campos de nit SOLO NUMEROS
    Private Sub Txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNit.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'valida enter al campo de texto
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida los campos de digito SOLO NUMEROS
    Private Sub TxtDv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDv.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'valida enter al campo de texto
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida los campos de digito SOLO NUMEROS
    Private Sub TxtRucom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtRucom.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'valida enter al campo de texto
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtRsocial_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRsocial.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtDireEmp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDireEmp.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida los campos de digito SOLO NUMEROS
    Private Sub TxtTelemp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelemp.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'valida enter al campo de texto
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida los campos de digito SOLO NUMEROS
    Private Sub TxtTelerepre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txttelrepre.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'valida enter al campo de texto
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txtcorreoemp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Txtcorreoemp.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbociuemp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Cbociuemp.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbopaisemp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Cbopaisemp.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txtweb_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Txtweb.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'OFICINA 1
    Private Sub TxtDireSucur1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDireSucur1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtTelSucur1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTelSucur1.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CboCiuSucur1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboCiuSucur1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCorreoSucur1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCorreoSucur1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CboDptoSucur1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboDptoSucur1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'OFICINA 2
    Private Sub TxtDireSucur2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDireSucur2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtTelSucur2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTelSucur2.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CboCiuSucur2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboCiuSucur2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCorreoSucur2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCorreoSucur2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CboDptoSucur2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboDptoSucur2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'DATOS DEL REPRESENTANTE
    Private Sub Txtrepre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Txtrepre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'valida los campos de digito SOLO NUMEROS
    Private Sub Txtcedrepre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtcedrepre.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'valida enter al campo de texto
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'DIRECCION DEL REPRESENTANTE LEGAL
    Private Sub Txtdirerepre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Txtdirerepre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'TELEFONO DEL REPRESENTANTE  LEGAL
    Private Sub Txttelrepre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Txttelrepre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'CORREO DEL REPRESENTANTE LEGAL
    Private Sub Txtcorreorepre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Txtcorreorepre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

#Region "BOTONES DEL FORMULARIO"

    'BOTON BUSCAR
    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        'Ubico el cursor
        Me.TxtNit.Select()
        Me.TxtNit.Focus()
        Try
            Using conn As New OleDb.OleDbConnection
                conn.ConnectionString = cs
                'abrimos la conexion
                conn.Open()
                'creamos la variable de consulta
                Dim SQlbuscar As String
                'realizamos la consulta
                SQlbuscar = "Select * FROM empresa WHERE nit_empresa ='" & Txtbuscar.Text & "'"
                'creamos el adaptador
                Dim da As New OleDb.OleDbDataAdapter(SQlbuscar, conn)
                'creamos el comando builder
                Dim cb As New OleDb.OleDbCommandBuilder(da)
                'creamos el dataset
                Dim ds As New DataSet
                da.Fill(ds, "empresa")
                'convertimos el comando en tipo texto
                Dim comandos As New OleDbCommand(SQlbuscar, conn) With {
                    .CommandType = CommandType.Text
                }
                'adiccionamos los parametros de consulta
                comandos.Parameters.AddWithValue("@nit_empresa", Txtbuscar.Text)
                'ejecutamos la consulta 
                Dim lectura As OleDbDataReader = comandos.ExecuteReader()
                'si el campo esta vacio
                If (Me.Txtbuscar.Text = "") Then
                    MessageBox.Show("El Campo no puede estar vacio", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Txtbuscar.Select()
                    Me.Txtbuscar.Focus()
                    Exit Sub
                End If

                If lectura.Read = True Then
                    'OFICINA PRINCIPAL
                    Me.TxtId.Text = CStr(lectura(0))
                    Me.TxtNit.Text = CStr(lectura(1))
                    Me.TxtDv.Text = CStr(lectura(2))
                    Me.TxtRucom.Text = CStr(lectura(17))
                    Me.TxtRsocial.Text = CStr(lectura(3))
                    Me.TxtDireEmp.Text = CStr(lectura(4))
                    Me.TxtTelemp.Text = CStr(lectura(5))
                    Me.Txtcorreoemp.Text = CStr(lectura(6))
                    Me.Cbociuemp.Text = CStr(lectura(7))
                    Me.CboDpto.Text = CStr(lectura(18))
                    Me.Cbopaisemp.Text = CStr(lectura(8))
                    Me.Txtweb.Text = CStr(lectura(9))
                    'OFICINA 1
                    Me.TxtDireSucur1.Text = CStr(lectura(20))
                    Me.TxtTelSucur1.Text = CStr(lectura(21))
                    Me.CboCiuSucur1.Text = CStr(lectura(19))
                    Me.TxtCorreoSucur1.Text = CStr(lectura(23))
                    Me.CboDptoSucur1.Text = CStr(lectura(22))
                    'OFICINA 2
                    Me.TxtDireSucur2.Text = CStr(lectura(25))
                    Me.TxtTelSucur2.Text = CStr(lectura(26))
                    Me.CboCiuSucur2.Text = CStr(lectura(24))
                    Me.TxtCorreoSucur2.Text = CStr(lectura(28))
                    Me.CboDptoSucur2.Text = CStr(lectura(27))
                    'DATOS DEL REPRESENTANTE
                    Me.Txtrepre.Text = CStr(lectura(10))
                    Me.Txtcedrepre.Text = CStr(lectura(11))
                    Me.Txtdirerepre.Text = CStr(lectura(12))
                    Me.Txttelrepre.Text = CStr(lectura(13))
                    Me.Txtcorreorepre.Text = CStr(lectura(14))

                    'habilitamos los botones 
                    'Me.BtnNuevo.Enabled = False
                    'Me.BtnGuardar.Enabled = False
                    Me.BtnModificar.Enabled = True
                    Me.BtnGuardaCambios.Enabled = False

                    'conexion.Close()
                    Exit Sub

                Else
                    MessageBox.Show("El Nit ingresado NO EXISTE, en nuestra Base de Datos", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'Ubico el cursor
                    Me.Txtbuscar.Select()
                    Me.Txtbuscar.Focus()

                    Exit Sub
                    Call Limpiar_Cajas()
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message + "", "AppMinerGold, ¡Ocurrio el siguiente Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Exit Sub
    End Sub

    'BOTON NUEVO
    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click

        'habilitar campos
        'OFICINA PRINCIPAL
        Me.TxtId.Enabled = False
        Me.TxtNit.Enabled = True
        Me.TxtDv.Enabled = True
        Me.TxtRucom.Enabled = True
        Me.TxtRsocial.Enabled = True
        Me.TxtDireEmp.Enabled = True
        Me.TxtTelemp.Enabled = True
        Me.Txtcorreoemp.Enabled = True
        Me.Cbociuemp.Enabled = True
        Me.CboDpto.Enabled = True
        Me.Cbopaisemp.Enabled = True
        Me.Txtweb.Enabled = True
        'OFICINA 1
        Me.TxtDireSucur1.Enabled = True
        Me.TxtTelSucur1.Enabled = True
        Me.CboCiuSucur1.Enabled = True
        Me.TxtCorreoSucur1.Enabled = True
        Me.CboDptoSucur1.Enabled = True
        'OFICINA 2
        Me.TxtDireSucur2.Enabled = True
        Me.TxtTelSucur2.Enabled = True
        Me.CboCiuSucur2.Enabled = True
        Me.TxtCorreoSucur2.Enabled = True
        Me.CboDptoSucur2.Enabled = True
        'DATOS DEL REPRESENTANTE
        Me.Txtrepre.Enabled = True
        Me.Txtcedrepre.Enabled = True
        Me.Txtdirerepre.Enabled = True
        Me.Txttelrepre.Enabled = True
        Me.Txtcorreorepre.Enabled = True

        'deshabilito los botones
        Me.BtnActDatosEmp.Enabled = False
        Me.BtnNuevo.Enabled = False
        Me.BtnGuardaCambios.Enabled = False

        'habilitar botones
        Me.BtnModificar.Enabled = False
        Me.BtnGuardar.Enabled = True

        'ubico el cursor
        Me.TxtNit.Select()
        Me.TxtNit.Focus()


    End Sub

    'BOTON DE ACTUALIZAR DATOS
    Private Sub BtnActDatosEmp_Click(sender As Object, e As EventArgs) Handles BtnActDatosEmp.Click
        'REVISO LA CONEXION
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        'CREO LA CONSULTA
        Dim dt As New DataTable
        Conectar.Conectarse()
        Dim consulta As String = "SELECT * FROM Empresa"
        Dim cmd As New OleDbCommand(consulta, conn)
        Try
            'ejecutamos la consulta 
            Dim lectura As OleDbDataReader = cmd.ExecuteReader()
            If lectura.Read = Nothing Then
                MessageBox.Show("No se encontro Datos de la Empresa solicitada, Falta información por ingresar, Clik en botón NUEVO ...", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Activo el  botones habilito campo
                Me.Txtbuscar.Enabled = False
                'habilito los botones
                Me.BtnActDatosEmp.Enabled = False
                'habilitar botones
                Me.BtnBuscar.Enabled = False

                'Me.BtnGuardar.Enabled = False
                Me.BtnModificar.Enabled = False
                Me.BtnGuardaCambios.Enabled = False
                'ubico el cursor
                Me.BtnNuevo.Enabled = True
                Me.BtnNuevo.Focus()
            Else
                'OFICINA PRINCIPAL
                Me.TxtId.Text = CStr(lectura(0))
                Me.TxtNit.Text = CStr(lectura(1))
                Me.TxtDv.Text = CStr(lectura(2))
                Me.TxtRucom.Text = CStr(lectura(17))
                Me.TxtRsocial.Text = CStr(lectura(3))
                Me.TxtDireEmp.Text = CStr(lectura(4))
                Me.TxtTelemp.Text = CStr(lectura(5))
                Me.Txtcorreoemp.Text = CStr(lectura(6))
                Me.Cbociuemp.Text = CStr(lectura(7))
                Me.CboDpto.Text = CStr(lectura(18))
                Me.Cbopaisemp.Text = CStr(lectura(8))
                Me.Txtweb.Text = CStr(lectura(9))
                'OFICINA 1
                Me.TxtDireSucur1.Text = CStr(lectura(20))
                Me.TxtTelSucur1.Text = CStr(lectura(21))
                Me.CboCiuSucur1.Text = CStr(lectura(19))
                Me.TxtCorreoSucur1.Text = CStr(lectura(23))
                Me.CboDptoSucur1.Text = CStr(lectura(22))
                'OFICINA 2
                Me.TxtDireSucur2.Text = CStr(lectura(25))
                Me.TxtTelSucur2.Text = CStr(lectura(26))
                Me.CboCiuSucur2.Text = CStr(lectura(24))
                Me.TxtCorreoSucur2.Text = CStr(lectura(28))
                Me.CboDptoSucur2.Text = CStr(lectura(27))
                'DATOS DEL REPRESENTANTE
                Me.Txtrepre.Text = CStr(lectura(10))
                Me.Txtcedrepre.Text = CStr(lectura(11))
                Me.Txtdirerepre.Text = CStr(lectura(12))
                Me.Txttelrepre.Text = CStr(lectura(13))
                Me.Txtcorreorepre.Text = CStr(lectura(14))

                'Activo el  botones habilito campo
                Me.Txtbuscar.Enabled = False
                'habilito los botones
                Me.BtnActDatosEmp.Enabled = False

                'habilitar botones
                Me.BtnBuscar.Enabled = False
                'Me.BtnNuevo.Enabled = False
                'Me.BtnGuardar.Enabled = False
                Me.BtnModificar.Enabled = True
                Me.BtnGuardaCambios.Enabled = False
            End If
            'drd.Close()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Falta información por ingresar " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Activo el  boton de nuevo
            Me.BtnModificar.Enabled = True
            Me.BtnModificar.Select()
            Me.BtnModificar.Focus()
            'Me.BtnNuevo.Enabled = False
            'Me.BtnNuevo.Focus()
        End Try
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
        End
    End Sub

#End Region

#Region "VALIDACIONES Y PROCEDIMIENTOS PARA GUARDAR"

    'BOTON GUARDAR
    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        'llamado de la funcion
        ValidarEmpresa()
    End Sub

    'Valido los procedimientos de ingreso duplicados
    Private Sub ValidarEmpresa()
        Dim encontro As Integer
        Dim cmd As New OleDb.OleDbCommand

        encontro = 0
        'revisamos la conexion
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        'ejecutamos la consulta
        cmd = New OleDb.OleDbCommand("SELECT * FROM Empresa WHERE nit_empresa='" & Me.TxtNit.Text & "' ", conn) With {
            .Connection = conn
        }
        Dim dr As OleDb.OleDbDataReader
        dr = cmd.ExecuteReader()
        Try
            Do While dr.Read
                encontro = 1
            Loop
        Catch ex As Exception
            MsgBox("Ha ocurrido un Error en el Ingreso de la Empresa! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
        End Try
        conn.Close()

        If (encontro = 1) Then
            MsgBox("no se puede Guardar, ya hay un registro con el mismo Nit!", MsgBoxStyle.Exclamation, "AppMinerGold")
            'pocisiono el cursor
            Me.TxtNit.Select()
            Me.TxtNit.Focus()
        Else
            'llamado de la funcion
            GuardarEmpresa()
            'cierro conexion
            conn.Close()
        End If

    End Sub

    'PROCEDIMIENTO PARA GUARDAR DATOS
    Private Sub GuardarEmpresa()

        'variables de fecha de auditoria
        Dim fechaC As Date = CDate(Format(Date.Now.Date))
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        'revisamos la conexion
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If

        Try
            If ValidaDatosEmpresa() = False Then Exit Sub

            'empresa
            'OFICINA PRINCIPAL
            Dim nit_empresa As String = ""
            Dim dvempresa As String = ""
            Dim rucom As String = ""
            Dim nombre_empresa As String = ""
            Dim direccion_empresa As String = ""
            Dim telfono_empresa As String = ""
            Dim correo_empresa As String = ""
            Dim ciudad As String = ""
            Dim dpto As String = ""
            Dim pais As String = ""
            Dim sitioweb_empresa As String = ""
            'OFICINA 1
            Dim DireSucur1 As String = ""
            Dim TelSucur1 As String = ""
            Dim CiuSucur1 As String = ""
            Dim CorreoSucur1 As String = ""
            Dim DptoSucur1 As String = ""
            'OFICINA 2
            Dim DireSucur2 As String = ""
            Dim TelSucur2 As String = ""
            Dim CiuSucur2 As String = ""
            Dim CorreoSucur2 As String = ""
            Dim DtoSucur2 As String = ""
            'DATOS DEL REPRESENTANTE
            Dim representante_empresa As String = ""
            Dim cedula_repre As String = ""
            Dim dire_repre As String = ""
            Dim tele_repre As String = ""
            Dim email_repre As String = ""

            'OFICINA PRINCIPAL
            nit_empresa = Me.TxtNit.Text
            dvempresa = Me.TxtDv.Text
            rucom = Me.TxtRucom.Text
            nombre_empresa = Me.TxtRsocial.Text
            direccion_empresa = Me.TxtDireEmp.Text
            telfono_empresa = Me.TxtTelemp.Text
            correo_empresa = Me.Txtcorreoemp.Text
            ciudad = Me.Cbociuemp.Text
            dpto = Me.CboDpto.Text
            pais = Me.Cbopaisemp.Text
            sitioweb_empresa = Me.Txtweb.Text
            'OFICINA 1
            DireSucur1 = Me.TxtDireSucur1.Text
            TelSucur1 = Me.TxtTelSucur1.Text
            CiuSucur1 = Me.CboCiuSucur1.Text
            CorreoSucur1 = Me.TxtCorreoSucur1.Text
            DptoSucur1 = Me.CboDptoSucur1.Text
            'OFICINA 2
            DireSucur2 = Me.TxtDireSucur2.Text
            TelSucur2 = Me.TxtTelSucur2.Text
            CiuSucur2 = Me.CboCiuSucur2.Text
            CorreoSucur2 = Me.TxtCorreoSucur2.Text
            DtoSucur2 = Me.CboDptoSucur2.Text
            'DATOS DEL REPRESENTANTE
            representante_empresa = Me.Txtrepre.Text
            cedula_repre = Me.Txtcedrepre.Text
            dire_repre = Me.Txtdirerepre.Text
            tele_repre = Me.Txttelrepre.Text
            email_repre = Me.Txtcorreorepre.Text

            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            sql = "INSERT INTO empresa (nit_empresa, dvempresa, nombre_empresa, direccion_empresa, telefono_empresa, " &
                              "correo_empresa, ciudad, pais, sitioweb_empresa, representante_empresa, cedula_repre, " &
                              "dire_repre, tele_repre, email_repre, fecha_creado, fecha_modifica, rucom, dpto, " &
                              "sucursal1ciu, diresucur1, telsucu1, dptosucur1, correosucur1, " &
                              "sucursal2ciu, diresucur2, telsucu2, dptosucur2, correosucur2) VALUES " &
                              "('" & TxtNit.Text & "','" & TxtDv.Text & "','" & TxtRsocial.Text & "', '" & TxtDireEmp.Text & "', " &
                              "'" & TxtTelemp.Text & "','" & Txtcorreoemp.Text & "','" & Cbociuemp.Text & "', " &
                              "'" & Cbopaisemp.Text & "','" & Txtweb.Text & "', '" & Txtrepre.Text & "', '" & Txtcedrepre.Text & "'," &
                              "'" & Txtdirerepre.Text & "','" & Txttelrepre.Text & "', " &
                              "'" & Txtcorreorepre.Text & "','" & fechaC & "', '" & fechaM & "', '" & TxtRucom.Text & "', '" & CboDpto.Text & "', " &
                              "'" & CiuSucur1 & "', '" & TxtDireSucur1.Text & "', '" & TxtTelSucur1.Text & "', '" & CboDptoSucur1.Text & "', '" & TxtCorreoSucur1.Text & "', " &
                              "'" & CiuSucur2 & "', '" & TxtDireSucur2.Text & "', '" & TxtTelSucur2.Text & "', '" & CboDptoSucur2.Text & "', '" & TxtCorreoSucur2.Text & "')"

            cmd.CommandText = sql

            'ejecutamos la consulta 
            cmd.ExecuteNonQuery()
            'cierro conexion
            conn.Close()

            MsgBox("Los datos se han guardado Correctamente! ", MsgBoxStyle.Information, "AppMinerGold")

            'limpio los campos
            Limpiar_Cajas()

            'deshabilito los textos
            DesHabilitaTextos()

            'ubicamos el cursor
            Me.BtnActDatosEmp.Enabled = True
            Me.BtnActDatosEmp.Select()
            Me.BtnActDatosEmp.Focus()

            Me.TxtNit.Enabled = False

            'habilitamos los botones
            'Me.BtnNuevo.Enabled = False
            'Me.BtnNuevo.Visible = True
            Me.BtnGuardar.Enabled = False
            Me.BtnGuardar.Visible = False
            Me.BtnModificar.Enabled = False
            Me.BtnModificar.Visible = True
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnGuardaCambios.Visible = False

            Refresh()

        Catch ex As Exception
            MsgBox("Error al guardar los datos " & ex.Message, MsgBoxStyle.Information, "AppMinerGold")
            Me.BtnActDatosEmp.Enabled = True
            Me.BtnActDatosEmp.Select()
            Me.BtnActDatosEmp.Focus()
        End Try

    End Sub

    'valida todos los campos no pueden estar vacios
    Private Function ValidaDatosEmpresa() As Boolean
        'empresa
        If Len(Me.TxtNit.Text.Trim) = 0 Then MsgBox("El Campo Nit no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtNit.Focus() : Return True : Exit Function
        If Len(Me.TxtDv.Text.Trim) = 0 Then MsgBox("El Campo Digito Verificador no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtDv.Focus() : Return True : Exit Function
        If Len(Me.TxtRsocial.Text.Trim) = 0 Then MsgBox("El Campo Razón Social no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtRsocial.Focus() : Return True : Exit Function
        If Len(Me.TxtDireEmp.Text.Trim) = 0 Then MsgBox("El Campo Dirección no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtDireEmp.Focus() : Return True : Exit Function
        If Len(Me.TxtTelemp.Text.Trim) = 0 Then MsgBox("El Campo Teléfono no puede estar vacío, Ingrese los Datos", vbCritical, "AppMinerGold") : Me.TxtTelemp.Focus() : Return True : Exit Function
        Return True
    End Function

#End Region

#Region "VALIDACIONES Y PROCEDIMIENTOS PARA MODIFICAR"

    'BOTON MODIFICAR
    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles BtnModificar.Click

        'deshabilito el texto de buscar
        Me.Txtbuscar.Enabled = False
        Me.BtnBuscar.Enabled = False

        'Habilito los textos
        'OFICINA PRINCIPAL
        Me.TxtId.Enabled = False
        Me.TxtNit.Enabled = False
        Me.TxtDv.Enabled = False
        Me.TxtRucom.Enabled = True
        Me.TxtRsocial.Enabled = True
        Me.TxtDireEmp.Enabled = True
        Me.TxtTelemp.Enabled = True
        Me.Txtcorreoemp.Enabled = True
        Me.Cbociuemp.Enabled = True
        Me.CboDpto.Enabled = True
        Me.Cbopaisemp.Enabled = True
        Me.Txtweb.Enabled = True
        'OFICINA 1
        Me.TxtDireSucur1.Enabled = True
        Me.TxtTelSucur1.Enabled = True
        Me.CboCiuSucur1.Enabled = True
        Me.TxtCorreoSucur1.Enabled = True
        Me.CboDptoSucur1.Enabled = True
        'OFICINA 2
        Me.TxtDireSucur2.Enabled = True
        Me.TxtTelSucur2.Enabled = True
        Me.CboCiuSucur2.Enabled = True
        Me.TxtCorreoSucur2.Enabled = True
        Me.CboDptoSucur2.Enabled = True
        'DATOS DEL REPRESENTANTE
        Me.Txtrepre.Enabled = True
        Me.Txtcedrepre.Enabled = True
        Me.Txtdirerepre.Enabled = True
        Me.Txttelrepre.Enabled = True
        Me.Txtcorreorepre.Enabled = True

        'habilitamos los botones 
        Me.BtnActDatosEmp.Enabled = False
        'Me.BtnNuevo.Enabled = False
        'Me.BtnGuardar.Enabled = False
        Me.BtnModificar.Enabled = False
        Me.BtnGuardaCambios.Enabled = True

        'ubico el cursor
        Me.TxtNit.Select()
        Me.TxtNit.Focus()

    End Sub

    'BOTON GUARDA LOS CAMBIOS
    Private Sub BtnGuardaCambios_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardaCambios.Click
        'variables de fecha de auditoria
        Dim fechaM As Date = CDate(Format(Date.Now.Date))
        Dim cmd As New OleDb.OleDbCommand
        'revisamos la conexin a la base de datos
        If conn.State() = ConnectionState.Closed Then
            conn.Open()
        End If
        Try
            ' Verifico que haya escrito el codigo
            'If Me.Txtbuscar.Text = "" Then
            If Me.Txtbuscar.Text = TxtNit.Text Then
                ' Si no lo escribió, mando mensaje de error
                MsgBox("Debe ingresar un Nit Válido", MsgBoxStyle.Exclamation, "AppMinerGold")
                Me.Txtbuscar.Select()

                'ubico el cursor
                Me.Txtbuscar.Select()
                Me.Txtbuscar.Focus()
            Else
                Dim sqlquery As String = "UPDATE empresa SET nit_empresa = '" & Me.TxtNit.Text & "', " &
                                                        "dvempresa = '" & Me.TxtDv.Text & "', " &
                                                        "nombre_empresa = '" & Me.TxtRsocial.Text & "'," &
                                                        "direccion_empresa = '" & Me.TxtDireEmp.Text & "'," &
                                                        "telefono_empresa = '" & TxtTelemp.Text & "', " &
                                                        "correo_empresa = '" & Me.Txtcorreoemp.Text & "', " &
                                                        "ciudad = '" & Me.Cbociuemp.Text & "'," &
                                                        "pais = '" & Me.Cbopaisemp.Text & "', " &
                                                        "sitioweb_empresa = '" & Me.Txtweb.Text & "', " &
                                                        "representante_empresa = '" & Me.Txtrepre.Text & "', " &
                                                        "cedula_repre = '" & Me.Txtcedrepre.Text & "', " &
                                                        "dire_repre = '" & Me.Txtdirerepre.Text & "', " &
                                                        "tele_repre = '" & Me.Txttelrepre.Text & "', " &
                                                        "email_repre = '" & Me.Txtcorreorepre.Text & "', " &
                                                        "fecha_modifica = '" & fechaM & "', " &
                                                        "rucom = '" & Me.TxtRucom.Text & "', " &
                                                        "dpto = '" & Me.CboDpto.Text & "', " &
                                                        "sucursal1ciu = '" & Me.CboCiuSucur1.Text & "', " &
                                                        "diresucur1 = '" & Me.TxtDireSucur1.Text & "', " &
                                                        "telsucu1 =  '" & Me.TxtTelSucur1.Text & "', " &
                                                        "dptosucur1 = '" & Me.CboDptoSucur1.Text & "', " &
                                                        "correosucur1 = '" & Me.TxtCorreoSucur1.Text & "', " &
                                                        "sucursal2ciu = '" & Me.CboCiuSucur2.Text & "', " &
                                                        "diresucur2 = '" & Me.TxtDireSucur2.Text & "', " &
                                                        "telsucu2 = '" & Me.TxtTelSucur2.Text & "', " &
                                                        "dptosucur2 = '" & Me.CboDptoSucur2.Text & "', " &
                                                        "correosucur2 = '" & Me.TxtCorreoSucur2.Text & "' WHERE nit_empresa = '" & Me.TxtNit.Text & "' "

                cmd = New OleDb.OleDbCommand(sqlquery, conn)
                'ejecutamos la consulta
                cmd.ExecuteNonQuery()
                'CIERRO LA CONEXION
                conn.Close()
                'presentamos el mensaje 
                MessageBox.Show("Registro actualizado exitosamente. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'limpio los campos
                DesHabilitaTextos()
                'limpia los campos de texto
                Limpiar_Cajas()
                'habilito texto
                Me.Txtbuscar.Enabled = False
                'habilito los botones
                Me.BtnBuscar.Enabled = False
                Me.BtnNuevo.Enabled = False
                Me.BtnGuardar.Enabled = False
                Me.BtnModificar.Enabled = False
                Me.BtnGuardaCambios.Enabled = False
                'ubico el cursor
                Me.BtnActDatosEmp.Enabled = True
                Me.BtnActDatosEmp.Select()
                Me.BtnActDatosEmp.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al Modificar Datos. " + Err.Description, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'para limpiar los campos
            Limpiar_Cajas()
            'deshabilitar los campor de texto
            DesHabilitaTextos()
            'habilitamos los botones
            Me.BtnBuscar.Enabled = False
            Me.BtnNuevo.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnModificar.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            'posicionamos en cursor
            Me.BtnActDatosEmp.Enabled = True
            Me.BtnActDatosEmp.Select()
            Me.BtnActDatosEmp.Focus()
        End Try
    End Sub

#End Region

#Region "VALIDACIONES Y PROCEDIMIENTOS"

    'habilita los campos de texto
    Private Sub HabilitaTextos()
        'habilitar campos
        'OFICINA PRINCIPAL
        Me.TxtId.Enabled = False
        Me.TxtNit.Enabled = True
        Me.TxtDv.Enabled = True
        Me.TxtRucom.Enabled = True
        Me.TxtRsocial.Enabled = True
        Me.TxtDireEmp.Enabled = True
        Me.TxtTelemp.Enabled = True
        Me.Txtcorreoemp.Enabled = True
        Me.Cbociuemp.Enabled = True
        Me.CboDpto.Enabled = True
        Me.Cbopaisemp.Enabled = True
        Me.Txtweb.Enabled = True
        'OFICINA 1
        Me.TxtDireSucur1.Enabled = True
        Me.TxtTelSucur1.Enabled = True
        Me.CboCiuSucur1.Enabled = True
        Me.TxtCorreoSucur1.Enabled = True
        Me.CboDptoSucur1.Enabled = True
        'OFICINA 2
        Me.TxtDireSucur2.Enabled = True
        Me.TxtTelSucur2.Enabled = True
        Me.CboCiuSucur2.Enabled = True
        Me.TxtCorreoSucur2.Enabled = True
        Me.CboDptoSucur2.Enabled = True
        'DATOS DEL REPRESENTANTE
        Me.Txtrepre.Enabled = True
        Me.Txtcedrepre.Enabled = True
        Me.Txtdirerepre.Enabled = True
        Me.Txttelrepre.Enabled = True
        Me.Txtcorreorepre.Enabled = True

    End Sub

    'deshabilitar textos
    Private Sub DesHabilitaTextos()

        'deshacilitar campos
        Me.TxtId.Enabled = False
        Me.TxtNit.Enabled = False
        Me.TxtDv.Enabled = False
        Me.TxtRucom.Enabled = False
        Me.TxtRsocial.Enabled = False
        Me.TxtDireEmp.Enabled = False
        Me.TxtTelemp.Enabled = False
        Me.Txtcorreoemp.Enabled = False
        Me.Cbociuemp.Enabled = False
        Me.CboDpto.Enabled = False
        Me.Cbopaisemp.Enabled = False
        Me.Txtweb.Enabled = False
        'OFICINA 1
        Me.TxtDireSucur1.Enabled = False
        Me.TxtTelSucur1.Enabled = False
        Me.CboCiuSucur1.Enabled = False
        Me.TxtCorreoSucur1.Enabled = False
        Me.CboDptoSucur1.Enabled = False
        'OFICINA 2
        Me.TxtDireSucur2.Enabled = False
        Me.TxtTelSucur2.Enabled = False
        Me.CboCiuSucur2.Enabled = False
        Me.TxtCorreoSucur2.Enabled = False
        Me.CboDptoSucur2.Enabled = False
        'DATOS DEL REPRESENTANTE
        Me.Txtrepre.Enabled = False
        Me.Txtcedrepre.Enabled = False
        Me.Txtdirerepre.Enabled = False
        Me.Txttelrepre.Enabled = False
        Me.Txtcorreorepre.Enabled = False

    End Sub

    'limpiar cajas de texto
    Private Sub Limpiar_Cajas()
        'hacilitar campos
        'OFICINA PRINCIPAL
        Me.TxtId.Clear()
        Me.Txtbuscar.Clear()
        Me.TxtNit.Clear()
        Me.TxtDv.Clear()
        Me.TxtRucom.Clear()
        Me.TxtRsocial.Clear()
        Me.TxtDireEmp.Clear()
        Me.TxtTelemp.Clear()
        Me.Txtcorreoemp.Clear()
        Me.Cbociuemp.SelectedIndex = -1
        Me.CboDpto.SelectedIndex = -1
        Me.Cbopaisemp.SelectedIndex = -1
        Me.Txtweb.Clear()
        'OFICINA 1
        Me.TxtDireSucur1.Clear()
        Me.TxtTelSucur1.Clear()
        Me.CboCiuSucur1.SelectedIndex = -1
        Me.TxtCorreoSucur1.Clear()
        Me.CboDptoSucur1.SelectedIndex = -1
        'OFICINA 2
        Me.TxtDireSucur2.Clear()
        Me.TxtTelSucur2.Clear()
        Me.CboCiuSucur2.SelectedIndex = -1
        Me.TxtCorreoSucur2.Clear()
        Me.CboDptoSucur2.SelectedIndex = -1
        'DATOS DEL REPRESENTANTE
        Me.Txtrepre.Clear()
        Me.Txtcedrepre.Clear()
        Me.Txtdirerepre.Clear()
        Me.Txttelrepre.Clear()
        Me.Txtcorreorepre.Clear()

    End Sub

    'MAYUSCULAS Y MINUSCULAS razon social Y CORREOS  
    Private Sub TxtRsocial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRsocial.TextChanged
        Me.TxtRsocial.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub Txtcorreoemp_TextChanged(sender As Object, e As EventArgs) Handles Txtcorreoemp.TextChanged
        Me.Txtcorreoemp.CharacterCasing = CharacterCasing.Lower
    End Sub

    Private Sub TxtCorreoSucur1_TextChanged(sender As Object, e As EventArgs) Handles TxtCorreoSucur1.TextChanged
        Me.TxtCorreoSucur1.CharacterCasing = CharacterCasing.Lower
    End Sub

    Private Sub TxtCorreoSucur2_TextChanged(sender As Object, e As EventArgs) Handles TxtCorreoSucur2.TextChanged
        Me.TxtCorreoSucur2.CharacterCasing = CharacterCasing.Lower
    End Sub

    Private Sub Txtcorreorepre_TextChanged(sender As Object, e As EventArgs) Handles Txtcorreorepre.TextChanged
        Me.Txtcorreorepre.CharacterCasing = CharacterCasing.Lower
    End Sub

    Private Sub Txtrepre_TextChanged(sender As Object, e As EventArgs) Handles Txtrepre.TextChanged
        Me.Txtrepre.Text = UCase(Me.Txtrepre.Text)
        Me.Txtrepre.SelectionStart = Me.Txtrepre.TextLength + 1
    End Sub


#End Region

End Class