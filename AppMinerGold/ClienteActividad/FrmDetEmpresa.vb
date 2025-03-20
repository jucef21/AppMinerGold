Imports System.Data.OleDb
Imports System.Globalization
Imports System.Threading

Public Class FrmDetEmpresa

    'INICIALIZA LOS COMPONENTES
    Public Sub New()
        ' Llamada necesaria para el diseñador.
        Me.InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    'CARGUE DEL FORMULARIO
    Private Sub FrmDetEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-CO")
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        'no permite cambiar el codigo
        CboDetAct.DropDownStyle = ComboBoxStyle.DropDownList
        CboMateriales.DropDownStyle = ComboBoxStyle.DropDownList
        CboAct1.DropDownStyle = ComboBoxStyle.DropDownList
        CboAct2.DropDownStyle = ComboBoxStyle.DropDownList
        CBOrol.DropDownStyle = ComboBoxStyle.DropDownList
        CBOtipoper.DropDownStyle = ComboBoxStyle.DropDownList
        CBOciudAct.DropDownStyle = ComboBoxStyle.DropDownList
        CboZonas.DropDownStyle = ComboBoxStyle.DropDownList
        CboDpto.DropDownStyle = ComboBoxStyle.DropDownList

        'LLENAMOS LOS DATOS DEL ENCABEZADO DEL CLIENTE - PANEL 1========================

        'colocamos los texbox en no editable
        Me.Txtced_cl.Enabled = False
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomApe.Enabled = False
        Me.DTPfechaactual.Enabled = False

        'formato del datatimepicker
        Me.DTPfechaactual.Format = DateTimePickerFormat.Custom
        Me.DTPfechaactual.CustomFormat = "dd/MM/yyyy"
        Me.DTPfechaactual.Value.ToString()
        Me.DTPfechaactual.Value = Date.Now.ToString("d")

        'LLENAMOS LOS DATOS DEL CLIENTE - GROUPBOX 3 =======================================

        'Inhabilito los campos al ingresar al formulario
        Me.CboDetAct.Enabled = False
        Me.CboZonas.Enabled = False
        Me.CboMateriales.Enabled = False
        Me.CBOciudAct.Enabled = False
        Me.CboDpto.Enabled = False

        'limpio los controles
        Me.CboDetAct.SelectedItem = -1
        'Me.CboZonas.Text = "Seleccione"
        Me.CboMateriales.SelectedIndex = -1
        Me.CboDpto.SelectedIndex = -1

        Cargar_Combo(CboZonas, "SELECT DISTINCT municipio FROM Zonas ORDER BY municipio")
        Cargar_Combo(CboDetAct, "SELECT DISTINCT nom_tiporol FROM tiporol ORDER BY nom_tiporol")
        Cargar_Combo(CboMateriales, "SELECT DISTINCT detalle FROM materiales ORDER BY detalle")
        Cargar_Combo(CBOciudAct, "SELECT DISTINCT ciudad_col FROM ciudad ORDER BY ciudad_col")
        Cargar_Combo(CboDpto, "SELECT DISTINCT departamento FROM ciudad ORDER BY departamento")

        'LLENAMOS LOS DATOS DEL CLIENTE - GROUPBOX 2=======================================
        'formato del datatimepicker
        Me.DTPinicioACT.Format = DateTimePickerFormat.Custom
        Me.DTPinicioACT.CustomFormat = "dd/MM/yyyy"
        Me.DTPinicioACT.Value.Date.ToString()
        Me.DTPinicioACT.Value = Date.Now.ToString("d")

        'formato del datatimepicker
        Me.DTPact2.Format = DateTimePickerFormat.Custom
        Me.DTPact2.CustomFormat = "dd/MM/yyyy"
        Me.DTPact2.Value.Date.ToString()
        Me.DTPact2.Value = Date.Now.ToString("d")

        'Inhabilito los campos
        Me.CboAct1.Enabled = False
        Me.DTPinicioACT.Enabled = False
        Me.CboAct2.Enabled = False
        Me.DTPact2.Enabled = False

        'limpio los controles
        Me.CboAct1.SelectedIndex = -1
        Me.DTPinicioACT.Text = Now.ToShortTimeString
        Me.CboAct2.SelectedIndex = -1
        Me.DTPact2.Text = Now.ToShortTimeString

        Cargar_Combo(CboAct1, "SELECT DISTINCT detalle FROM ciuu ORDER BY detalle")
        Cargar_Combo(CboAct2, "Select DISTINCT detalle From ciuu Order By detalle")

        'LLENAMOS LOS DATOS DEL CLIENTE - GROUPBOX 1=======================================

        'Inhabilito los campos 
        Me.CBOrol.Enabled = False
        Me.CBOtipoper.Enabled = False

        'limpio los controles
        Me.CBOrol.SelectedIndex = -1
        Me.CBOtipoper.SelectedIndex = -1

        Cargar_Combo(CBOrol, "Select DISTINCT nom_tiporol From tiporol Order By nom_tiporol")
        Cargar_Combo(CBOtipoper, "Select DISTINCT nom_tipopersona From tipopersona Order By nom_tipopersona")

        'LLENAMOS LOS DATOS DEL CLIENTE - GROUPBOX 4=======================================

        'deshabilito los textos
        Me.TxtRut.Enabled = False
        Me.TxtObsEmp.Enabled = False

        'limpio los textos
        Me.TxtObsEmp.Clear()

        'BOTONES - PANEL 7 LINKS=================================

        'Activo el  botones
        Me.BtnDatos.Enabled = True
        Me.BtnNuevo.Enabled = False
        Me.BtnModifica.Enabled = False
        Me.BtnGuardaCambios.Enabled = False
        Me.BtnGuardar.Enabled = False
        Me.BtnImprime.Enabled = False

        'llenamos los datos con la informacion seleccionada
        Me.Txtced_cl.Text = ModuleFrm.ced_consulta
        Me.TxtNomPaciente.Text = ModuleFrm.Nom_consulta
        Me.TxtName.Text = ModuleFrm.Nom_consulta
        Me.TxtSurName.Text = ModuleFrm.ape_consulta

        Me.TxtNomCliente.Text = Txtced_cl.Text

        'muestro el resultado y los concateno
        Me.TxtNomApe.Text = Me.TxtName.Text & " " & Me.TxtSurName.Text

    End Sub

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    'CARGAR COMBOBOX
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

    'PROCEDIMIENTO PARA UNIR NOMBRE Y APELLIDO DEL CLIENTE
    Private Sub UnirNombres()
        Dim dt As New DataTable

        Dim numcedula As String = CInt(Txtced_cl.Text)

        'revisamos la conexin a la base de datos
        If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            Conectar.conn.Close()
        End If

        'Conectar.conn.ConnectionString = cs
        Dim consulta As String = "SELECT * FROM Clientes WHERE ced_cl = " & numcedula
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)
        Dim drd As OleDbDataReader
        Conectar.conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            Me.TxtName.Text = drd.Item("nom_cl").ToString
            Me.TxtSurName.Text = drd.Item("ape_cl").ToString
        Else
            MsgBox("No se encontro NOMBRES", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
        Conectar.conn.Close()
    End Sub

    'LIMPIAR LOS CAMPOS
    Private Sub Limpiacampos()
        'limpio los controles
        'panel 1
        Me.Txtced_cl.Clear()
        Me.TxtNomPaciente.Clear()
        Me.TxtNomApe.Clear()
        Me.DTPfechaactual.Text = Date.Now.Date
        'GROUPBOX 3 
        'limpio los controles
        Me.CboDetAct.SelectedIndex = -1
        Me.CboZonas.SelectedIndex = -1
        'Me.CboZonas.Text = "Seleccione"
        Me.CboMateriales.SelectedIndex = -1
        Me.CBOciudAct.SelectedIndex = -1
        Me.CboDpto.SelectedIndex = -1
        'GROUPBOX 2
        Me.CboAct1.SelectedIndex = -1
        Me.DTPinicioACT.Text = Now.ToShortTimeString
        Me.CboAct2.SelectedIndex = -1
        Me.DTPact2.Text = Now.ToShortTimeString
        'GROUPBOX 1
        Me.CBOrol.SelectedIndex = -1
        Me.CBOtipoper.SelectedIndex = -1
        'GROUPBOX 4
        Me.TxtRut.Clear()
        Me.TxtObsEmp.Clear()

    End Sub

    'DESHABILITO TODOS LOS CAMPOS
    Private Sub InhabilitoCampos()
        'panel 1
        Me.Txtced_cl.Enabled = False
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomApe.Enabled = False
        Me.DTPfechaactual.Enabled = False
        'GROUPBOX 3
        Me.CboDetAct.Enabled = False
        Me.CboZonas.Enabled = False
        Me.CboMateriales.Enabled = False
        Me.CBOciudAct.Enabled = False
        Me.CboDpto.Enabled = False
        'GROUPBOX 2
        Me.CboAct1.Enabled = False
        Me.DTPinicioACT.Enabled = False
        Me.CboAct2.Enabled = False
        Me.DTPact2.Enabled = False
        'GROUPBOX 1
        Me.CBOrol.Enabled = False
        Me.CBOtipoper.Enabled = False
        'GROUPBOX 4
        Me.TxtRut.Enabled = False
        Me.TxtObsEmp.Enabled = False

    End Sub

    'HABILITO LOS CAMPOS
    Private Sub HabilitoCampos()
        'panel 1
        Me.Txtced_cl.Enabled = False
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomApe.Enabled = False
        Me.DTPfechaactual.Enabled = False
        'GROUPBOX 3
        Me.CboDetAct.Enabled = True
        Me.CboZonas.Enabled = True
        Me.CboMateriales.Enabled = True
        Me.CBOciudAct.Enabled = True
        Me.CboDpto.Enabled = True
        'GROUPBOX 2
        Me.CboAct1.Enabled = True
        Me.DTPinicioACT.Enabled = True
        Me.CboAct2.Enabled = True
        Me.DTPact2.Enabled = True
        'GROUPBOX 1
        Me.CBOrol.Enabled = True
        Me.CBOtipoper.Enabled = True
        'GROUPBOX 4
        Me.TxtRut.Enabled = True
        Me.TxtObsEmp.Enabled = True

    End Sub

    'RESALTAR COLOR DEL TEXTBOX AL PASAR POR EL FOCO
    Private Sub TieneFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim miTextBox As TextBox
        miTextBox = CType(sender, TextBox)
        miTextBox.BackColor = Color.Plum
    End Sub

    'PIERDE EL COLOR CUANDO PASA EL FOCO
    Private Sub PierdeFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim miTextBox As TextBox
        miTextBox = CType(sender, TextBox)
        miTextBox.BackColor = Color.White
    End Sub

    'VALIDA CAMPOS VACIOS
    Private Sub ValidaCamposVacios()
        If Me.TxtRut.TextLength > 0 Then
            BtnGuardar.Enabled = True
        Else
            BtnGuardar.Enabled = False
        End If
    End Sub

    'VALIDA TEXTO OBLIGATORIO
    Private Sub TxtRut_TextChanged(sender As Object, e As EventArgs)
        'CONVIERTO A MAYUSCULA
        Dim I As Integer
        Me.TxtRut.Text = UCase(TxtRut.Text)
        I = Len(TxtRut.Text)
        Me.TxtRut.SelectionStart = I

        'VALIDO CAMPO VACIO
        ValidaCamposVacios()
    End Sub

#End Region

#Region "EVENTO KEYPRESS PERMITIR ENTER"

    'GROUPBOX 3 ===========================
    Private Sub CBODetAct_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboDetAct.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CboMateriales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboMateriales.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CBOciudAct_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBOciudAct.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CboDpto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboDpto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'GROUPBOX 2 ===========================
    'ACTIVIDAD
    Private Sub CboAct1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboAct1.KeyPress
        Me.CboAct1.DropDownStyle = ComboBoxStyle.DropDownList
        'PERMITIR ENTER
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'FECHA INICIO DE OPERACIONES 1
    Private Sub DTPinicioACT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPinicioACT.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'NO PERMITIR EDICCION DE COMBOBOX ACTIVIDAD 2
    Private Sub CboAct2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboAct2.KeyPress
        'no permite cambiar el codigo
        CboAct2.DropDownStyle = ComboBoxStyle.DropDownList
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'FECHA INICIO DE OPERACIONES 2
    Private Sub DTPact2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPact2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'GROUPBOX 1 ===========================
    'ROL 
    Private Sub CBOrol_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBOrol.KeyPress
        'no permite cambiar el codigo
        Me.CBOrol.DropDownStyle = ComboBoxStyle.DropDownList
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CBOtipoper_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBOtipoper.KeyPress
        'no permite cambiar el codigo
        Me.CBOtipoper.DropDownStyle = ComboBoxStyle.DropDownList
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'LINK PARA CONSULTA DE VALORES
    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://www.dian.gov.co/")
    End Sub

    'LINK PARA CONSULTA DE VALORES
    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://muisca.dian.gov.co/WebRutMuisca/DefConsultaEstadoRUT.faces")
        'Process.Start("https://muisca.dian.gov.co/WebArquitectura/DefLogin.faces")
    End Sub

    'LINK PARA CONSULTA DE RUCOM
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("https://tramites.anm.gov.co/Portal/pages/consultaListados/anonimoListados.jsf")
    End Sub

    'GROUPBOX 4 ===========================

    'OBSERVACIONES
    Private Sub TxtObsEmp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObsEmp.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

#Region "CONVIERTE LOS CAMPOS CON LETRAS MAYUSCULAS"

    'NOMBRE COMPLETO 
    Private Sub TxtNomApe_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNomApe.TextChanged
        Me.TxtNomApe.Text = UCase(Me.TxtNomApe.Text)
        Me.TxtNomApe.SelectionStart = Me.TxtNomApe.TextLength + 1
    End Sub

#End Region

#Region "VALIDA CAMPOS VACIOS A OBLIGATORIOS DELFORMULARIO"

    'valida todos los campos no pueden estar vacios
    Private Function ValidaDatos() As Boolean
        'cliente
        If Len(Me.TxtRut.Text.Trim) = 0 Then MsgBox("El Campo Rut no puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold") : Me.TxtRut.Focus() : Return True : Exit Function
        Return True
    End Function

    'Valida solo Numeros
    Public Sub NumerosyDecimal(ByVal CajaTexto As Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not CajaTexto.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

#End Region

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE ACTUALIZAR DATOS
    Private Sub BtnDatos_Click(sender As Object, e As EventArgs) Handles BtnDatos.Click
        'REVISO LA CONEXION
        If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
            Conectar.conn.Close()
        End If
        'CREO LA CONSULTA
        Dim dt As New DataTable

        Dim Ncedula As Integer
        Ncedula = CInt(Me.Txtced_cl.Text)

        Conectar.Conectarse()
        Dim consulta As String = "SELECT TOP 1 * FROM Empresa1Cliente WHERE ceduem = " & Ncedula
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)
        Try
            Dim drd As OleDbDataReader
            drd = cmd.ExecuteReader
            If drd.Read Then
                'GROUPBOX 3 ======================
                Me.CboDetAct.Text = drd.Item("detact").ToString
                Me.CboZonas.Text = drd.Item("direzonas").ToString
                Me.TxtCodZonas.Text = drd.Item("codigodane").ToString
                Me.CboMateriales.Text = drd.Item("material").ToString
                Me.CBOciudAct.Text = drd.Item("ciudact").ToString
                Me.CboDpto.Text = drd.Item("dpto").ToString
                'GROUPBOX 2 ======================
                Me.CboAct1.Text = drd.Item("actividad1").ToString
                Me.DTPinicioACT.Value = drd.Item("fechaact1").ToString
                Me.CboAct2.Text = drd.Item("actividad2").ToString
                Me.DTPact2.Text = drd.Item("fechaact2").ToString
                'GROUPBOX 1 ======================
                Me.CBOrol.Text = drd.Item("rol").ToString
                Me.CBOtipoper.Text = drd.Item("tipoper").ToString
                'GROUPBOX 4 ======================
                Me.TxtRut.Text = drd.Item("rut").ToString
                Me.TxtObsEmp.Text = drd.Item("obspro").ToString

                'DesActivo el  botones
                Me.BtnDatos.Enabled = False
                Me.BtnNuevo.Enabled = False
                Me.BtnGuardaCambios.Enabled = False
                Me.BtnGuardar.Enabled = False

                'Activo el  botones
                Me.BtnModifica.Enabled = True
                Me.BtnImprime.Enabled = True

            Else
                MsgBox("No se encontro Datos con el cliente solicitado, Falta información por ingresar, Click en NUEVO ...", MsgBoxStyle.Information, "AppMinerGold")

                'Activo el  botones
                Me.BtnDatos.Enabled = False
                Me.BtnModifica.Enabled = False
                Me.BtnGuardaCambios.Enabled = False
                Me.BtnGuardar.Enabled = False

                'Activo el  botones
                Me.BtnNuevo.Enabled = True

                'ubico el cursor
                Me.BtnNuevo.Focus()

            End If
            drd.Close()
            Conectar.conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Falta información por ingresar", MsgBoxStyle.Information, "AppMinerGold")
            'Activo el  boton de nuevo
            Me.BtnNuevo.Enabled = True
        End Try

    End Sub

    'BOTON DE NUEVO
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        'HABILITO LOS CAMPOS DE TEXTO Y CONTROLES
        HabilitoCampos()

        'UBICO EL CURSOR
        Me.GroupBox3.Select()
        Me.CboDetAct.Select()
        Me.CboDetAct.Focus()

        'Activo el  botones
        Me.BtnGuardar.Enabled = True

        'DesActivo el  botones
        Me.BtnDatos.Enabled = False
        Me.BtnNuevo.Enabled = False
        Me.BtnModifica.Enabled = False
        Me.BtnGuardaCambios.Enabled = False
        Me.BtnImprime.Enabled = False

        'UBICO EL CURSOR
        Me.GroupBox3.Select()
        Me.GroupBox3.Focus()
        Me.CboZonas.Select()
        Me.CboZonas.Focus()

    End Sub

    'BOTON DE GUARDAR
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        GuardarEmpresaUno()
    End Sub

    'PROCEDIMIENTOS DE GUARDAR
    Private Sub GuardarEmpresaUno()
        Try
            'fecha actual
            Dim fechaACT As Date = CDate(Format(Date.Now.Date))
            'fecha de inicio de actividad 1
            Dim fechaIniACT As String
            fechaIniACT = CStr(DTPinicioACT.Value.Date)
            'fecha actividad 2
            Dim fechaAct2 As String
            fechaAct2 = CStr(DTPact2.Value.Date)
            'fecha creado
            Dim fechaC As Date = CDate(Format(Date.Now.Date))
            'fecha modifica
            Dim fechaM As Date = CDate(Format(Date.Now.Date))

            cmd.CommandType = CommandType.Text
            cmd.Connection = Conectar.conn

            'VALORES QUITADOS
            Dim Qadmonr, Qdecisoc, Qrecopu, QdetIng As String
            Qadmonr = "N/A"
            Qdecisoc = "N/A"
            Qrecopu = "N/A"
            QdetIng = "N/A"

            Dim QVringresoM, QVrotroingM, QVregresoM, QVractivoM, QVrpasivosM As Decimal
            QVringresoM = 0
            QVrotroingM = 0
            QVregresoM = 0
            QVractivoM = 0
            QVrpasivosM = 0

            sql = "INSERT INTO Empresa1cliente (ceduem, nomem, fechaem, " &
                                       "detact, direzonas, material, ciudact, " &
                                       "actividad1, fechaact1, actividad2, fechaact2, admonr, decisoc, " &
                                       "recopu, rol, tipoper, " &
                                       "vringreso, vrotroing, vregreso, vractivos, vrpasivos, " &
                                       "deting, Obspro, fecha_creado, fecha_modifica, rut, codigodane, dpto) VALUES ('" & Txtced_cl.Text & "', " &
                                       "'" & TxtNomApe.Text & "','" & fechaACT & "', '" & CboDetAct.Text & "'," &
                                       "'" & CboZonas.Text & "', '" & CboMateriales.Text & "', '" & CBOciudAct.Text & "', " &
                                       "'" & CboAct1.Text & "', '" & fechaIniACT & "', '" & CboAct2.Text & "','" & fechaAct2 & "'," &
                                       "'" & Qadmonr & "', '" & Qdecisoc & "', '" & Qrecopu & "',  " &
                                       "'" & CBOrol.Text & "', '" & CBOtipoper.Text & "', " &
                                       "'" & QVringresoM & "','" & QVrotroingM & "','" & QVregresoM & "', " &
                                       "'" & QVractivoM & "', '" & QVrpasivosM & "', '" & QdetIng & "', " &
                                       "'" & TxtObsEmp.Text & "', '" & fechaC & "', '" & fechaM & "', '" & TxtRut.Text & "', '" & TxtCodZonas.Text & "',  '" & CboDpto.Text & "')"

            cmd.CommandText = sql
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Los datos se han guardado Correctamente!, Proveedores ", MsgBoxStyle.Information, "AppMinerGold")

            'LIMPIO LOS CAMPOS
            Limpiacampos()

            'Deshabilito los campos
            InhabilitoCampos()

            'Activo el  botones
            Me.BtnDatos.Enabled = False
            Me.BtnNuevo.Enabled = False
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnImprime.Enabled = True

            Refresh()

        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos, Provedores ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Activo el  botones
            Me.BtnDatos.Enabled = False
            Me.BtnNuevo.Enabled = False
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnImprime.Enabled = False

            Me.BtnGuardar.Enabled = True

            'ubico el cursor
            Me.GroupBox3.Select()
            Me.CboDetAct.Select()
            Me.CboDetAct.Focus()

        End Try

    End Sub

    'BOTON MODIFICAR
    Private Sub BtnModifica_Click(sender As Object, e As EventArgs) Handles BtnModifica.Click

        'Mensaje de modificar
        MsgBox("Va ha Modificar los Datos de la Base de Datos", MsgBoxStyle.Information, "AppMinerGold")

        'Habilito los campos
        HabilitoCampos()

        'colocamos los texbox en no editable
        Me.Txtced_cl.Enabled = False
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomApe.Enabled = False
        Me.DTPfechaactual.Enabled = False

        'ubico el cursor
        Me.GroupBox3.Select()
        Me.CboDetAct.Select()
        Me.CboDetAct.Focus()

        'Activo el  botones
        Me.BtnDatos.Enabled = False
        Me.BtnNuevo.Enabled = False
        Me.BtnModifica.Enabled = False
        Me.BtnGuardaCambios.Enabled = True
        Me.BtnGuardar.Enabled = False
        Me.BtnImprime.Enabled = False

    End Sub

    'GUARDA CAMBIOS DE MODIFICAR
    Private Sub BtnGuardaCambios_Click(sender As Object, e As EventArgs) Handles BtnGuardaCambios.Click
        ModiEmp()
    End Sub

    'PROCEDIMIENTO PARA GUARDAR LOS CAMBIOS
    Private Sub ModiEmp()
        'fecha actual
        Dim fechaACT As String
        fechaACT = CStr(DTPfechaactual.Value.Date)

        'fecha de inicio de activida
        Dim fechaIniACT As String
        fechaIniACT = CStr(DTPinicioACT.Value.Date)
        'fecha actividad 2
        Dim fechaAct2 As String
        fechaAct2 = CStr(DTPact2.Value.Date)

        'fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        Dim cmd As New OleDb.OleDbCommand

        Dim Ncedula As String
        Ncedula = CInt(Me.Txtced_cl.Text)

        'VALORES QUITADOS
        Dim Qadmonr, Qdecisoc, Qrecopu, QdetIng As String
        Qadmonr = "N/A"
        Qdecisoc = "N/A"
        Qrecopu = "N/A"
        QdetIng = "N/A"

        Dim QVringresoM, QVrotroingM, QVregresoM, QVractivoM, QVrpasivosM As Decimal
        QVringresoM = 0
        QVrotroingM = 0
        QVregresoM = 0
        QVractivoM = 0
        QVrpasivosM = 0

        Try
            Dim sqlConsulta As String = "UPDATE Empresa1Cliente SET ceduem = '" & Me.Txtced_cl.Text & "', " &
                                                "nomem = '" & Me.TxtNomApe.Text & "', " &
                                                "fechaem = '" & fechaACT & "', " &
                                                "detact = '" & Me.CboDetAct.Text & "', " &
                                                "direzonas = '" & Me.CboZonas.Text & "', " &
                                                "material = '" & Me.CboMateriales.Text & "', " &
                                                "ciudact = '" & Me.CBOciudAct.Text & "', " &
                                                "actividad1 = '" & Me.CboAct1.Text & "', " &
                                                "fechaact1 = '" & Me.DTPinicioACT.Text & "', " &
                                                "actividad2 = '" & Me.CboAct2.Text & "', " &
                                                "fechaact2 = '" & Me.DTPact2.Text & "', " &
                                                "admonr = '" & Qadmonr & "', " &
                                                "decisoc = '" & Qdecisoc & "', " &
                                                "recopu = '" & Qrecopu & "', " &
                                                "rol = '" & Me.CBOrol.Text & "', " &
                                                "tipoper = '" & Me.CBOtipoper.Text & "', " &
                                                "vringreso = '" & QVringresoM & "', " &
                                                "vrotroing = '" & QVrotroingM & "', " &
                                                "vregreso = '" & QVregresoM & "', " &
                                                "vractivos = '" & QVractivoM & "', " &
                                                "vrpasivos = '" & QVrpasivosM & "', " &
                                                "deting = '" & QdetIng & "', " &
                                                "obspro = '" & Me.TxtObsEmp.Text & "', " &
                                                "fecha_modifica ='" & fechaM & "', " &
                                                "rut = '" & TxtRut.Text & "', " &
                                                "codigodane = '" & TxtCodZonas.Text & "', " &
                                                "dpto = '" & Me.CboDpto.Text & "' WHERE ceduem = " & Ncedula

            cmd = New OleDb.OleDbCommand(sqlConsulta, Conectar.conn)

            conn.Open()

            'ejecutamos la consulta
            cmd.ExecuteNonQuery()

            conn.Close()

            'presentamos el mensaje 
            MsgBox("Registro actualizado exitosamente, Proveedor", MsgBoxStyle.Information, "AppMinerGold")

            'limpio los campos
            Limpiacampos()

            'deshabilito los textos
            InhabilitoCampos()

            'Activo el  botones
            Me.BtnDatos.Enabled = False
            Me.BtnNuevo.Enabled = False
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnGuardar.Enabled = False

            Me.BtnImprime.Enabled = True

            Refresh()

        Catch ex As Exception
            MsgBox("Error al guardar los datos de los Cambios, proveedor " & ex.Message, MsgBoxStyle.Information, "AppMinerGold")

            'Activo el  botones
            Me.BtnDatos.Enabled = False
            Me.BtnNuevo.Enabled = False
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnImprime.Enabled = False

        End Try
    End Sub

    'BOTON DE IMPRIMIR
    Private Sub BtnImprime_Click(sender As Object, e As EventArgs) Handles BtnImprime.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor
        FrmReimprimeVincula.TxtClientes.Text = Me.TxtNomCliente.Text
        FrmReimprimeVincula.ShowDialog()
        'manejo del cursor
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


#Region "EVENTO KEYPRESS"


    'consulta a la tabla 
    Public Function Datos() As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT municipio, codigo_dane FROM Zonas"
        Dim cmd As New OleDbCommand(query, conn)
        Dim da As New OleDbDataAdapter(cmd)
        da.Fill(dt)
        Return (dt)
    End Function

    'CAMBIA COMBOBOX CON TEXBOX AL ESCOJER LA ZONA
    Private Sub LlenaZonas()
        'Dim dadatos As New OleDbDataAdapter("SELECT codigo_dane FROM Zonas WHERE municipio like '%" & CboZonas.Text & "%'", conn)
        Dim dadatos As New OleDbDataAdapter("SELECT codigo_dane FROM Zonas WHERE municipio = '" & CboZonas.Text & "' ", conn)
        Dim ds As New DataSet
        dadatos.Fill(ds, "codigo_dane")
        TxtCodZonas.Text = ds.Tables("codigo_dane").Rows(0).Item(0).ToString
    End Sub

    'SELECCIONA LE TEXBOX CON EL NUMERO DEL MUNICIPIO
    Private Sub CboZonas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CboZonas.SelectionChangeCommitted
        LlenaZonas()
    End Sub

#End Region

End Class