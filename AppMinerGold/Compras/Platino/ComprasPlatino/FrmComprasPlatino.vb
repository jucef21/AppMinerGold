Imports System.Data.OleDb
Imports System.Globalization
Imports System.Threading

Public Class FrmComprasPlatino

    'CARGUE DEL FORMULARIO
    Private Sub FrmComprasPlatino_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-CO")
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        'LLENAMOS LOS DATOS DEL ENCABEZADO DEL CLIENTE - PANEL 1========================

        VerCiudad()

        Dim d As DateTime = DateTime.Now
        Dim DateString As String = d.ToString("yyyyMMddHHmmss")
        TxtFecha.Text = DateString

        'LIMPIO EL CONTADOR
        Me.TxtNum_com.Clear()
        Me.TxtCedImp.Clear()
        Me.TxtFechaTasa.Clear()
        Me.TxtMesRega.Clear()

        'colocamos los texbox en no editable
        Me.TextPrefijo.Enabled = False
        Me.Txtced_cl.Enabled = False
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomApe.Enabled = False
        Me.DTPfechaactual.Enabled = False
        Me.TxtNum_com.Enabled = False

        Me.TxtCedImp.Text = Me.Txtced_cl.Text

        FrmDecCompras.TxtClientes.Text = Me.Txtced_cl.Text.ToString
        FrmEquivalenteDec.TxtClientes.Text = Me.Txtced_cl.Text.ToString
        FrmEscojeImp.TxtCedImp.Text = Me.Txtced_cl.Text.ToString

        'formato del datatimepicker
        Me.DTPfechaactual.Format = DateTimePickerFormat.Custom
        Me.DTPfechaactual.CustomFormat = "dd/MM/yyyy"
        Me.DTPfechaactual.Value.ToString()
        Me.DTPfechaactual.Value = Date.Now.ToString("d")

        'Habilito los campos de texto
        Me.CboMetal.Enabled = False

        Me.TxtGrBr.Enabled = False
        Me.TxtLey.Enabled = False
        Me.TxtGrPuros.Enabled = False
        Me.TxtBase.Enabled = False
        Me.TxtRegalias.Enabled = False
        Me.TxtReteValor.Enabled = False
        Me.TxtVrRF.Enabled = False
        Me.TxtVrVenta.Enabled = False

        Me.TxtConcepto.Enabled = False
        Me.CboCiudad.Enabled = False
        Me.CboDpto.Enabled = False
        Me.TxtMes.Enabled = False
        Me.TxtAño.Enabled = False
        Me.TxtDetMaterial.Enabled = False

        Me.CboFormaPago.Enabled = False
        Me.TxtNumTarjeta.Enabled = False
        Me.CboBancos.Enabled = False

        'BOTONES
        Me.BtnActualiza.Enabled = True
        Me.BtnNuevo.Enabled = False
        Me.BtnGuardar.Enabled = False
        Me.BtnImprime.Enabled = False
        Me.BtnCalculo.Enabled = False

        'UBICO EL CURSOR
        Me.BtnActualiza.Select()
        Me.BtnActualiza.Focus()

        'CARGA LOS DATOS EN LOS COMBOS
        Cargar_Combo(CboMetal, "SELECT DISTINCT detalle FROM Materiales ORDER BY detalle")

        Cargar_Combo(CboCiudad, "SELECT DISTINCT ciudad_col FROM ciudad ORDER BY ciudad_col")
        Cargar_Combo(CboDpto, "SELECT DISTINCT departamento FROM ciudad ORDER BY departamento")

        Cargar_Combo(CboFormaPago, "SELECT DISTINCT detalle FROM formapago ORDER BY detalle")
        Cargar_Combo(CboBancos, "SELECT DISTINCT entidad FROM bancos ORDER BY entidad")

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE ACTUALIZA
    Private Sub BtnActualiza_Click(sender As Object, e As EventArgs) Handles BtnActualiza.Click

        Dim fechaMes As DateTime = DateTime.Now.Date
        Dim fechaAño As DateTime = DateTime.Now.Date
        Dim mes As Integer = fechaMes.Month
        Dim anio As Integer = fechaAño.Year
        Me.TxtMes.Text = MonthName(Month(fechaMes))
        Me.TxtAño.Text = anio

        'Validamos fecha Actual de compra seleccionado el mes
        'Asigna date usando short format.
        Dim FechaActual As Date = Date.Now.ToShortDateString
        Dim NumMes As Integer
        NumMes = DateAndTime.Month(FechaActual)
        'alista la variable para mostrar el Mes actual
        TxtMonth.Text = NumMes

        'llamo al procedimiento
        'ActTasa()
        ActRegalias()
        ActRetefuente()
        ActParam()

        Me.CboMetal.Text = "PLATINO"

        'BOTONES
        Me.BtnActualiza.Enabled = False
        Me.BtnNuevo.Enabled = True
        Me.BtnGuardar.Enabled = False
        Me.BtnImprime.Enabled = False
        Me.BtnCalculo.Enabled = False

        'UBICO EL CURSOR
        Me.BtnNuevo.Select()
        Me.BtnNuevo.Focus()

    End Sub

    'BOTON NUEVO
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click

        'fecha seleccionada
        Dim FechaAct As String
        FechaAct = CStr(DTPfechaactual.Value.Date)
        Me.TxtFechaTasa.Text = FechaAct

        'INHABILITO LOS CAMPOS
        Me.TextPrefijo.Enabled = False
        Me.TxtNum_com.Enabled = False

        'limpio
        Me.TxtNum_com.Clear()

        'ejecutamos contador
        ContadorIngreso()

        VerPrefijo()

        'ACTIVO LOS CAMPOS
        Me.TxtConcepto.Enabled = True
        Me.CboMetal.Enabled = False
        Me.CboCiudad.Enabled = True
        Me.CboDpto.Enabled = True
        Me.TxtGrBr.Enabled = True
        Me.TxtLey.Enabled = True
        Me.TxtBase.Enabled = True
        Me.TxtDetMaterial.Enabled = True
        Me.TxtMes.Enabled = False
        Me.TxtAño.Enabled = False

        Me.CboFormaPago.Enabled = True
        Me.TxtNumTarjeta.Enabled = False
        Me.CboBancos.Enabled = False

        'BOTONES
        Me.BtnActualiza.Enabled = False
        Me.BtnNuevo.Enabled = False
        Me.BtnGuardar.Enabled = True
        Me.BtnImprime.Enabled = False
        Me.BtnCalculo.Enabled = True

        'UBICO EL CURSOR
        Me.Panel6.Select()
        Me.CboCiudad.Select()
        Me.CboCiudad.Focus()

        'CONCATENO NOMBRE QR
        Me.TxtNomQr.Text = Me.TextPrefijo.Text & "" & Me.TxtNum_com.Text
        Me.TxtConseImp.Text = Me.TxtNum_com.Text

    End Sub

    'BOTON GUARDAR
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        'Verifica campos vacios
        If Len(Me.TxtGrBr.Text.Trim) = 0 Or Me.TxtLey.Text = 0 Or Me.TxtConcepto.Text = "" Or Me.TxtBase.Text = "" Or CboFormaPago.Text = "" Then
            MsgBox("El Campo No puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
            Me.TxtGrBr.Select()
            Me.TxtGrBr.Focus()
        Else
            'llamo elprocedimiento
            Guardarcompra()
        End If

        'Verifica campos vacios
        If TxtMonth.Text <> "" Then
            'llamo elprocedimiento
            AgregaFechas()
        Else
            MsgBox("El Mes esta Vacio", MsgBoxStyle.Critical, "AppMinerGold")
        End If

    End Sub

    'BOTON DE IMPRIMIR
    Private Sub BtnImprime_Click(sender As Object, e As EventArgs) Handles BtnImprime.Click
        Dim FrmImpriCompPlati As New FrmEscojeImpPlatino
        FrmImpriCompPlati.TxtCedImp.Text = TxtCedImp.Text
        FrmImpriCompPlati.TxtEmpCiuImp.Text = TxtEmpCiu.Text
        FrmImpriCompPlati.TxtConsecu.Text = TxtConseImp.Text 'TxtNomQr.Text
        FrmImpriCompPlati.ShowDialog()
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    'PROCEDIMIENTOS DE UNIR TEXTO
    Private Sub BarQ()
        Dim Codimp1 As String = "01"
        Dim Valimp1 As String = "0.00"
        Dim Codimp2 As String = "02"
        Dim Valimp2 As String = "0.00"
        Dim Codimp3 As String = "01"
        Dim Valimp3 As String = "0.00"
        Dim NitOFE As String = Me.TxtNit.Text
        Dim TipoAdq As String = "PROVEEDOR"
        'LIMPIO EN TEXTBO
        Me.TxtQr.Clear()
        'CONCATENAR POR LINEA
        Me.TxtQr.Text = Me.TextPrefijo.Text & "" & Me.TxtNum_com.Text & vbNewLine & TxtFecha.Text & vbNewLine & TxtVrVenta.Text & vbNewLine & Codimp1 & vbNewLine & Valimp1 & vbNewLine & Codimp2 & vbNewLine & Valimp2 & vbNewLine & Codimp3 & vbNewLine & Valimp3 & vbNewLine & NitOFE & vbNewLine & TipoAdq & vbNewLine & Txtced_cl.Text
    End Sub

    Dim QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder
    'TEXTO DE QR
    Private Sub TxtQr_TextChanged(sender As Object, e As EventArgs) Handles TxtQr.TextChanged
        Try
            PictureQR.Image = QR_Generator.Encode(TxtQr.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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
            Me.TxtNit.Text = drd.Item("nit_empresa").ToString
        Else
            MsgBox("No se encontro CIUDAD", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
        Conectar.conn.Close()
    End Sub

    'PROCEDIMIENTO PARA VER PREFIJO
    Private Sub VerPrefijo()
        If TxtEmpCiu.Text = "CALI" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "QUIBDO" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "MANIZALES" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "SANTA ROSA DEL SUR" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "RIOHACHA" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "ARAUCA" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "CONDOTO" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "QUINCHIA" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "SUPIA" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "ISTMINA" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "TARAZA" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "TADÓ" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "BUENAVENTURA" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        ElseIf Me.TxtEmpCiu.Text = "ARMENIA" Then
            Dim dt As New DataTable
            'revisamos la conexin a la base de datos
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            Dim consulta As String = "SELECT prefijo FROM Facturacion WHERE Ciudad= '" & TxtEmpCiu.Text & "' "
            Dim cmd As New OleDbCommand(consulta, Conectar.conn)
            Dim drd As OleDbDataReader
            Conectar.conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                Me.TextPrefijo.Text = drd.Item("prefijo").ToString
            Else
                MsgBox("No se encontro Prefijo de Facturación", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        End If
    End Sub

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
        Dim CedUne As Integer = CInt(Txtced_cl.Text)
        'revisamos la conexin a la base de datos
        If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            Conectar.conn.Close()
        End If
        Dim consulta As String = "SELECT * FROM Clientes WHERE ced_cl = " & CedUne   ''" & Txtced_cl.Text & "' "
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

    Dim txt As String
    Dim x As Single
    Public VrT As Single
    'ACTUALIZA TASAS DIARIAS
    Private Sub ActTasa()

        'REVISO LA CONEXION
        If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
            Conectar.conn.Close()
        End If

        'CREO LA CONSULTA
        Dim dt As New DataTable
        Conectar.Conectarse()

        Dim drd As OleDbDataReader
        Dim cm As OleDbCommand

        'variable fecha actual
        Dim fechaACT As Date
        fechaACT = CDate(DTPfechaactual.Value.Date)

        'fecha creado variable de buscar
        Dim FechaCbusca As Date = DateTime.Now.ToString("dd/MM/yyyy")

        cm = New OleDbCommand("SELECT * FROM Tasadiaria WHERE  id = id ORDER BY Id DESC ", conn)
        drd = cm.ExecuteReader

        Try
            If drd.Read Then
                'GROUPBOX 2 ======================
                Me.TxtBase.Text = drd.Item("detalle").ToString
                Me.TxtFechaTasa.Text = drd.Item("descri").ToString
                If TxtFechaTasa.Text <> FechaCbusca Then
                    MsgBox("Falta información por ingresar, 'Tasa Diaria' del día Actual", MsgBoxStyle.Information, "AppMinerGold")
                Else
                    Dim x As Decimal = CDec(If(TxtBase.Text.Contains(","), TxtBase.Text.Replace(",", "."), TxtBase.Text))
                    x = Math.Round(x, 2)
                    Me.TxtBase.Text = x.ToString
                    VrT = x

                    'Me.TxtBase.Text = Format(VrT, "###,##0.00")

                End If
            End If
            drd.Close()
            Conectar.conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Falta información por ingresar, Tasa Diaria", MsgBoxStyle.Information, "AppMinerGold")
            Me.TxtGrBr.Select()
            Me.TxtGrBr.Focus()
        End Try

    End Sub

    Dim TxtR As String
    Dim Xr As Single
    Public VrR As Single
    'ACTUALIZA REGALIAS
    Private Sub ActRegalias()
        'REVISO LA CONEXION
        If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
            Conectar.conn.Close()
        End If
        'CREO LA CONSULTA
        Dim dt As New DataTable
        Conectar.Conectarse()

        'variable fecha actual
        Dim fechaACT As String
        fechaACT = CStr(DTPfechaactual.Value.Date)

        Dim consulta As String = "SELECT TOP 1 * FROM RegaliasPlatino WHERE id = id ORDER BY Id DESC "
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)
        Try
            Dim drd As OleDbDataReader
            'conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                'GROUPBOX 2 ======================
                Me.TxtRegalias.Text = drd.Item("detalle").ToString
                Me.TxtMesRega.Text = drd.Item("descri").ToString

                Dim Xr As Decimal = CDec(If(TxtRegalias.Text.Contains(","), TxtRegalias.Text.Replace(",", "."), TxtRegalias.Text))
                Xr = Math.Round(Xr, 2)
                Me.TxtRegalias.Text = Xr.ToString
                VrR = Xr

                'Me.TxtRegalias.Text = Format(VrR, "###,##0.00")

            Else
                MsgBox("No se encontro Datos de Regalias, Falta información por ingresar", MsgBoxStyle.Information, "AppMinerGold")
            End If

            drd.Close()
            Conectar.conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Falta información por ingresar, Regalias", MsgBoxStyle.Information, "AppMinerGold")
            'Activo el  boton de nuevo
            'Me.CboMetal.Select()
            'Me.CboMetal.Focus()
            Me.TxtGrBr.Select()
            Me.TxtGrBr.Focus()
        End Try

    End Sub

    'Dim TxtRTF As String
    Dim XrRTF As Single
    Public VrRTF As Single
    'ACTUALIZA RETEFUENTE
    Private Sub ActRetefuente()
        'REVISO LA CONEXION
        If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
            Conectar.conn.Close()
        End If
        'CREO LA CONSULTA
        Dim dt As New DataTable
        Conectar.Conectarse()

        'variable fecha actual
        Dim fechaACT As String
        fechaACT = CStr(DTPfechaactual.Value.Date)

        Dim consulta As String = "SELECT TOP 1 * FROM RetefuentePlatino WHERE id = id ORDER BY Id DESC "
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)
        Try
            Dim drd As OleDbDataReader
            'conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                'GROUPBOX 2 ======================
                Me.TxtVrRF.Text = drd.Item("detalle").ToString
                'Me.TxtMesRega.Text = drd.Item("descri").ToString

                Dim XrRTF As Decimal = CDec(If(TxtVrRF.Text.Contains(","), TxtVrRF.Text.Replace(",", "."), TxtVrRF.Text))
                XrRTF = Math.Round(XrRTF, 2)
                Me.TxtVrRF.Text = XrRTF.ToString
                VrRTF = XrRTF

            Else
                MsgBox("No se encontro Datos de Retefuente, Falta información por ingresar", MsgBoxStyle.Information, "AppMinerGold")
            End If

            drd.Close()
            Conectar.conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Falta información por ingresar, Retefuente", MsgBoxStyle.Information, "AppMinerGold")
            'Activo el  boton de nuevo
            'Me.CboMetal.Select()
            'Me.CboMetal.Focus()
            Me.TxtGrBr.Select()
            Me.TxtGrBr.Focus()
        End Try

    End Sub

    Public VrParam As Single
    'ACTUALIZA PARAMETRO PARA LA RETENCION EN LA FUENTE DEL 2.5% SOBRE EL TOTAL DE COMPRAS
    Private Sub ActParam()
        'REVISO LA CONEXION
        If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
            Conectar.conn.Close()
        End If
        'CREO LA CONSULTA
        Dim dt As New DataTable
        Conectar.Conectarse()

        'variable fecha actual
        Dim fechaACT As String
        fechaACT = CStr(DTPfechaactual.Value.Date)

        Dim consuParam As String = "SELECT * FROM Parametro"
        Dim cmd As New OleDbCommand(consuParam, Conectar.conn)
        Try
            Dim drd As OleDbDataReader
            'conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                'GROUPBOX 2 ======================
                Me.TxtParametro.Text = drd.Item("Param").ToString
                Dim NumPa As Decimal = CDec(If(TxtParametro.Text.Contains(","), TxtParametro.Text.Replace(",", "."), TxtParametro.Text))
                NumPa = Math.Round(NumPa, 2)
                Me.TxtParametro.Text = NumPa.ToString
                VrParam = NumPa
            Else
                MsgBox("No se encontro Datos de Parametro, Falta información por ingresar", MsgBoxStyle.Information, "AppMinerGold")
            End If
            drd.Close()
            Conectar.conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Public Pago As Decimal = 0
    'Public PagoBarequero As Decimal = 0
    'Public GrPurReg As Decimal = 0
    'Public Letnum As String
    'CAMPO CANTIDAD PARA MULTIPLICAR KEY CON VALOR DEL PARAMETRO 97.5 Y 2.5%
    'Private Sub BtnCalculo_Click(sender As Object, e As EventArgs) Handles BtnCalculo.Click

    '    If TxtGrBr.Text = "" Or TxtLey.Text = "" Then
    '        MessageBox.Show("En este Campo No puede estar Vacío", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    Else
    '        '===================================================================
    '        '**** FORMULAS  NUEVAS
    '        '===================================================================
    '        'GRAMOS BRUTOS       = Txtgrbrutos
    '        'LEY                 = Txtley
    '        'GRAMOS PUROS        = Txtgrpuros
    '        'PRECIO BASE         = Txtbase
    '        'VALOR REGALIAS      = Txtregalias
    '        'VALOR % RETE        = Txtvrrf
    '        'VALOR RETEFUENTE    = Txtretevalor
    '        'VALOR REGALIAS      = Txtlblgrrg
    '        'VALOR TOTAL         = Txvrventa
    '        'VALOR BAREQUERO     = Txtbarequero

    '        '****INCIAMOS OPERACIONES INGRESO DE DATOS DE COMPRA
    '        '====================================================================================================
    '        '=========================== GRAMOS BRUTOS
    '        '====================================================================================================
    '        'Muestro el resultado en un Label para guardar
    '        Dim LabelBrutos As Decimal = CDec(If(TxtGrBr.Text.Contains(","), TxtGrBr.Text.Replace(",", "."), TxtGrBr.Text))
    '        LabelBrutos = Math.Round(LabelBrutos, 2)
    '        Me.Lblbrutos.Text = LabelBrutos.ToString
    '        '====================================================================================================
    '        '=========================== GRAMOS PUROS ( GRAMOS BRUTOS * LEY = GRAMOS PUROS )
    '        '====================================================================================================
    '        Dim Rpuros As Decimal = CDec(If(TxtGrBr.Text.Contains(","), TxtGrBr.Text.Replace(",", "."), TxtGrBr.Text)) * CDec(If(TxtLey.Text.Contains(","), TxtLey.Text.Replace(",", "."), TxtLey.Text))
    '        Rpuros = Math.Round(Rpuros, 2)
    '        Me.TxtGrPuros.Text = Rpuros.ToString
    '        '====================================================================================================
    '        '=========================== VALOR DE PRECIO BASE ( PRECIO DE COMPRA DEL DIA )
    '        '====================================================================================================
    '        'ARREGLO NUEVO 13/10/2019
    '        Dim Cbase As Decimal = Convert.ToDecimal(TxtBase.Text, CultureInfo.CreateSpecificCulture("es-CO"))
    '        TxtBase.Text = Cbase.ToString("N2")

    '        '====================================================================================================
    '        'CALCULO FORMULA FECHA: 10-09-2021 dr fredy - Eileen
    '        ' 1 - VrBrMm = VALOR COMPRA BAREQUERO + VALOR MENSUAL DE REGALIAS
    '        ' 2 - Calprecio = (VALOR COMPRA BAREQUERO + VALOR MENSUAL DE REGALIAS) / PORCENTAJE

    '        '****MUESTRO DATOS DE VALORES DE REGALIAS
    '        '====================================================================================================
    '        '=========================== VALOR TOTAL DEL PRECIO REGALIAS ( GRAMOS PUROS * VALOR MENSUAL REGALIAS  )
    '        '====================================================================================================
    '        Dim VrTotPuros As Decimal = CDec(If(TxtGrPuros.Text.Contains(","), TxtGrPuros.Text.Replace(",", "."), TxtGrPuros.Text))
    '        Dim VrRegMensual As Decimal = CDec(If(TxtRegalias.Text.Contains(","), TxtRegalias.Text.Replace(",", "."), TxtRegalias.Text))
    '        Dim VrTotPuXMes As Decimal = 0
    '        VrTotPuXMes = VrTotPuros * VrRegMensual
    '        'VrTotPuXMes = Math.Round(VrTotPuXMes, 2)
    '        TxtLblGrRg.Text = VrTotPuXMes.ToString("N2")

    '        '****MUESTRO DATOS DE VALOR DE PARAMETRO
    '        '====================================================================================================
    '        '=========================== VALOR PARAMETRO DE LA BASE (VALOR 97.5%)
    '        '====================================================================================================
    '        '****MUESTRO DATOS DE VALOR TOTAL DE LA OPERACION
    '        Dim VrParametro As Decimal = CDec(If(TxtParametro.Text.Contains(","), TxtParametro.Text.Replace(",", "."), TxtParametro.Text) / 100)
    '        Dim PremasReg As Decimal = Cbase + VrRegMensual
    '        PremasReg = Math.Round(PremasReg, 2)

    '        Dim BaremasRegDivParam As Decimal = ((PremasReg) / (VrParametro))
    '        BaremasRegDivParam = Math.Round(BaremasRegDivParam, 2)

    '        Dim RtotalCompra As Decimal = (Rpuros * BaremasRegDivParam)

    '        TxtVrLetras.Text = RtotalCompra
    '        TxtVrVenta.Text = RtotalCompra.ToString("N2")

    '        '****MUESTRO DATOS DE VALORES DE RETEFUENTE
    '        '====================================================================================================
    '        '==== OPERACION PARA SACAR EL VALOR DEL IMPUESTO TOTAL DE RETEFUENTE (Gramos puros * Valor Retefuente Mensual)
    '        '====================================================================================================
    '        Dim Vrretefuente As Decimal = CDec(If(TxtVrRF.Text.Contains(","), TxtVrRF.Text.Replace(",", "."), TxtVrRF.Text) / 100)
    '        Dim VrTotalRF As Decimal = 0 'Convert.ToDecimal(TxtReteValor.Text, CultureInfo.CreateSpecificCulture("es-CO"))
    '        VrTotalRF = RtotalCompra * Vrretefuente
    '        TxtReteValor.Text = VrTotalRF.ToString("N2")
    '        '====================================================================================================
    '        '=========================== VALOR RETEFUENTE CALCULO VALOR POR GRAMO (VALOR PRECIO DE COMPRA * 2,5%)
    '        '====================================================================================================
    '        Dim rete As Decimal = CDec(If(TxtVrRF.Text.Contains(","), TxtVrRF.Text.Replace(",", "."), TxtVrRF.Text) / 100)
    '        Dim ReteValor1 As Decimal = 0 'Convert.ToDecimal(Txtvrrfgr.Text, CultureInfo.CreateSpecificCulture("es-CO"))
    '        'ReteValor1 = RtotalCompra * rete
    '        ReteValor1 = VrTotalRF / Rpuros
    '        Txtvrrfgr.Text = ReteValor1.ToString("N2")


    '        '****MUESTRO DATOS DE VALORES DE PAGO
    '        '====================================================================================================
    '        '====================== TOTAL A PAGAR AL BAREQUERO (VALOR TOTAL - VALOR TOTAL DE REGALIAS - VALOR RETEFUENTE)
    '        '====================================================================================================
    '        Pago = RtotalCompra - VrTotPuXMes - VrTotalRF
    '        Me.TxtLblpago.Text = Pago.ToString("N2")
    '        Me.TxtBarequero.Text = Pago.ToString("N2")

    '        '====================================================================================================
    '        '======================= CONVERTIMOS LOS NUMEROS A LETRAS
    '        '====================================================================================================
    '        'ENVIAMOS EL RESULTADO A UNA CAJA DE TEXTO EN LETRAS
    '        Pointer1 = 0
    '        Lbletras.Text = SpellNumber(Val(Me.TxtVrLetras.Text))
    '        Letnum = Lbletras.Text

    '        'INHABILITAMOS LOS CAMPOS
    '        Me.CboMetal.Enabled = False
    '        Me.TxtConcepto.Enabled = False
    '        Me.CboCiudDpto.Enabled = False
    '        Me.TxtDetMaterial.Enabled = False

    '        Me.TxtGrBr.Enabled = False
    '        Me.TxtLey.Enabled = False
    '        Me.TxtBase.Enabled = False

    '        Me.BtnCalculo.Enabled = False

    '        'UBICO EL CURSOR
    '        Me.Panel10.Select()
    '        Me.Panel10.Focus()
    '        Me.CboFormaPago.Select()
    '        Me.CboFormaPago.Focus()

    '        BarQ()

    '    End If

    'End Sub

    Public Pago As Decimal = 0
    Public PagoBarequero As Decimal = 0
    Public GrPurReg As Decimal = 0
    Public Letnum As String
    'CAMPO CANTIDAD PARA MULTIPLICAR KEY
    Private Sub BtnCalculo_Click(sender As Object, e As EventArgs) Handles BtnCalculo.Click
        If TxtGrBr.Text = "" Or TxtLey.Text = "" Then
            MessageBox.Show("En este Campo No puede estar Vacío", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            '===================================================================
            '**** FORMULAS  NUEVAS
            '===================================================================
            'GRAMOS BRUTOS       = Txtgrbrutos
            'LEY                 = Txtley
            'GRAMOS PUROS        = Txtgrpuros
            'PRECIO BASE         = Txtbase
            'VALOR REGALIAS      = Txtregalias
            'VALOR % RETE        = Txtvrrf
            'VALOR RETEFUENTE    = Txtretevalor
            'VALOR REGALIAS      = Txtlblgrrg
            'VALOR TOTAL         = Txvrventa
            'VALOR BAREQUERO     = Txtbarequero

            '****INCIAMOS OPERACIONES INGRESO DE DATOS DE COMPRA
            '====================================================================================================
            '=========================== GRAMOS BRUTOS
            '====================================================================================================
            'Muestro el resultado en un Label para guardar
            Dim LabelBrutos As Decimal = CDec(If(TxtGrBr.Text.Contains(","), TxtGrBr.Text.Replace(",", "."), TxtGrBr.Text))
            LabelBrutos = Math.Round(LabelBrutos, 2)
            Me.Lblbrutos.Text = LabelBrutos.ToString
            '====================================================================================================
            '=========================== GRAMOS PUROS ( GRAMOS BRUTOS * LEY = GRAMOS PUROS )
            '====================================================================================================
            Dim Rpuros As Decimal = CDec(If(TxtGrBr.Text.Contains(","), TxtGrBr.Text.Replace(",", "."), TxtGrBr.Text)) * CDec(If(TxtLey.Text.Contains(","), TxtLey.Text.Replace(",", "."), TxtLey.Text))
            Rpuros = Math.Round(Rpuros, 2)
            Me.TxtGrPuros.Text = Rpuros.ToString
            '====================================================================================================
            '=========================== VALOR DE PRECIO BASE ( PRECIO DE COMPRA DEL DIA )
            '====================================================================================================
            'ARREGLO NUEVO 13/10/2019
            Dim Cbase As Decimal = Convert.ToDecimal(TxtBase.Text, CultureInfo.CreateSpecificCulture("es-CO"))
            TxtBase.Text = Cbase.ToString("N2")

            '====================================================================================================
            'CALCULO FORMULA FECHA: 10-09-2021 dr fredy - Eileen
            ' 1 - VrBrMm = VALOR COMPRA BAREQUERO + VALOR MENSUAL DE REGALIAS
            ' 2 - Calprecio = (VALOR COMPRA BAREQUERO + VALOR MENSUAL DE REGALIAS) / PORCENTAJE

            '****MUESTRO DATOS DE VALORES DE REGALIAS
            '====================================================================================================
            '=========================== VALOR TOTAL DEL PRECIO REGALIAS ( GRAMOS PUROS * VALOR MENSUAL REGALIAS  )
            '====================================================================================================
            Dim VrTotPuros As Decimal = CDec(If(TxtGrPuros.Text.Contains(","), TxtGrPuros.Text.Replace(",", "."), TxtGrPuros.Text))
            Dim VrRegMensual As Decimal = CDec(If(TxtRegalias.Text.Contains(","), TxtRegalias.Text.Replace(",", "."), TxtRegalias.Text))
            Dim VrTotPuXMes As Decimal = VrTotPuros * VrRegMensual
            'VrTotPuXMes = Math.Round(VrTotPuXMes, 2)
            TxtLblGrRg.Text = VrTotPuXMes.ToString("N2")

            '****MUESTRO DATOS DE VALOR TOTAL DE LA OPERACION
            '====================================================================================================
            '=========================== RESULTADO VALOR TOTAL (GRAMOS PUROS * PRECIO DE COMPRA)
            '====================================================================================================
            Dim Rtotal As Decimal = 0 'Convert.ToDecimal(TxtVrVenta.Text, CultureInfo.CreateSpecificCulture("es-CO"))
            Rtotal = Rpuros * Cbase

            Rtotal = Decimal.Round(Rtotal, 2)

            TxtVrLetras.Text = Rtotal
            TxtVrVenta.Text = Rtotal.ToString("N2")
            '****MUESTRO DATOS DE VALORES DE RETEFUENTE
            '====================================================================================================
            '=========================== VALOR RETEFUENTE CALCULO VALOR POR GRAMO (VALOR PRECIO DE COMPRA * 2,5%)
            '====================================================================================================
            Dim rete As Decimal = CDec(If(TxtVrRF.Text.Contains(","), TxtVrRF.Text.Replace(",", "."), TxtVrRF.Text) / 100)
            Dim ReteValor1 As Decimal = 0 'Convert.ToDecimal(Txtvrrfgr.Text, CultureInfo.CreateSpecificCulture("es-CO"))
            ReteValor1 = Cbase * rete
            Txtvrrfgr.Text = ReteValor1.ToString("N2")
            '====================================================================================================
            '==== OPERACION PARA SACAR EL VALOR DEL IMPUESTO TOTAL DE RETEFUENTE (Gramos puros * Valor Gramo de Retefuente Mensual)
            '====================================================================================================
            Dim Vrretefuente As Decimal = CDec(If(TxtVrRF.Text.Contains(","), TxtVrRF.Text.Replace(",", "."), TxtVrRF.Text) / 100)
            Dim VrTotalRF As Decimal = 0 'Convert.ToDecimal(TxtReteValor.Text, CultureInfo.CreateSpecificCulture("es-CO"))
            VrTotalRF = Rtotal * Vrretefuente
            TxtReteValor.Text = VrTotalRF.ToString("N2")
            '****MUESTRO DATOS DE VALORES DE PAGO
            '====================================================================================================
            '====================== TOTAL A PAGAR AL BAREQUERO (VALOR TOTAL - VALOR TOTAL DE REGALIAS - VALOR RETEFUENTE)
            '====================================================================================================
            Pago = Rtotal - VrTotPuXMes - VrTotalRF
            Me.TxtLblpago.Text = Pago.ToString("N2")
            Me.TxtBarequero.Text = Pago.ToString("N2")
            '====================================================================================================
            '======================= CONVERTIMOS LOS NUMEROS A LETRAS
            '====================================================================================================
            'ENVIAMOS EL RESULTADO A UNA CAJA DE TEXTO EN LETRAS
            Pointer1 = 0
            Lbletras.Text = SpellNumber(Val(Me.TxtVrLetras.Text))
            Letnum = Lbletras.Text

            'INHABILITAMOS LOS CAMPOS
            Me.CboMetal.Enabled = False
            Me.CboDpto.Enabled = False
            Me.TxtConcepto.Enabled = False
            Me.CboCiudad.Enabled = False
            Me.TxtDetMaterial.Enabled = False

            Me.TxtGrBr.Enabled = False
            Me.TxtLey.Enabled = False
            Me.TxtGrPuros.Enabled = False
            Me.TxtBase.Enabled = False

            Me.BtnCalculo.Enabled = False

            'UBICO EL CURSOR
            Me.Panel10.Select()
            Me.Panel10.Focus()
            Me.CboFormaPago.Select()
            Me.CboFormaPago.Focus()

            BarQ()

        End If

    End Sub

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

    'PROCEDIMIENTO DE GUARDAR
    Private Sub Guardarcompra()
        Try
            'revisamos la conexion
            'If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            '    Conectar.conn.Open()
            'End If

            'fecha creado
            Dim fechaC As Date = CDate(Format(Date.Now.Date))

            'fecha modifica
            Dim fechaM As Date = CDate(Format(Date.Now.Date))

            'fecha seleccionada
            Dim FechaActual As String
            FechaActual = CStr(DTPfechaactual.Value.Date)

            'envia 0 al verificar
            Dim veri As String
            veri = "0"

            'envia 0 al numero de fundicion
            Dim Numfundi As String
            Numfundi = "0"

            Dim TipoOperacion As String
            TipoOperacion = "1"

            Dim Tipodocu As String
            Tipodocu = "13"

            Dim MateOro As String
            MateOro = "0"

            Dim MatePlatino As String
            MatePlatino = "2"

            Dim MatePlata As String
            MatePlata = "0"

            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            sql = "INSERT INTO Declara (cedu_com, nom_com, fecha_com, dire_com, telc_com, " &
                                        "correo_com, dpto_com, rut_com, act_com, " &
                                        "metal_com, conce_com, ciuddpto, " &
                                        "grbrutos, ley, grpuros, base, regala, totalretef, " &
                                        "vrventa, fechatasa, mestasa, retevalor, " &
                                        "gp_rg, gp_base, valorgrrete, pagobare, mes_com, año_com, " &
                                        "consecutivo, fecha_creado, fecha_modifica, letras, detallemineral, verifica, numfundi, " &
                                        "formapago, numtarjeta, selebancos, prefijo, " &
                                        "ConseQR, tipoop, tipodocu, comOro, comPlatino, comPlata, ciudad, dpto) VALUES ('" & Txtced_cl.Text & "', '" & TxtNomApe.Text & "', '" & DTPfechaactual.Value & "', " &
                                        "'" & TxtDireccion.Text & "', '" & TxtTelC.Text & "', " &
                                        "'" & TxtCorreo.Text & "', '" & TxtDpto_cl.Text & "', '" & Txtrut.Text & "', '" & TxtAct.Text & "', " &
                                        "'" & CboMetal.Text & "', '" & TxtConcepto.Text & "', '" & CboCiudad.Text & "', " &
                                        "'" & TxtGrBr.Text & "', '" & TxtLey.Text & "', '" & TxtGrPuros.Text & "', '" & TxtBase.Text & "', '" & TxtRegalias.Text & "', '" & TxtReteValor.Text & "', " &
                                        "'" & TxtVrVenta.Text & "', '" & TxtFechaTasa.Text & "', '" & TxtMesRega.Text & "', '" & TxtVrRF.Text & "', " &
                                        "'" & TxtLblGrRg.Text & "', '" & TxtLblpago.Text & "', '" & Txtvrrfgr.Text & "', '" & TxtBarequero.Text & "', '" & TxtMes.Text & "', '" & TxtAño.Text & "', " &
                                        "'" & TxtNum_com.Text & "', '" & fechaC & "', '" & fechaM & "', '" & Letnum & "', '" & TxtDetMaterial.Text & "', '" & veri & "', '" & Numfundi & "', " &
                                        "'" & CboFormaPago.Text & "', '" & TxtNumTarjeta.Text & "', '" & CboBancos.Text & "', '" & TextPrefijo.Text & "', " &
                                        "'" & TxtNomQr.Text & "', '" & TipoOperacion & "', '" & Tipodocu & "', '" & MateOro & "', '" & MatePlatino & "', '" & MatePlata & "', '" & TxtCiudad.Text & "',  '" & CboDpto.Text & "')"
            'MsgBox(sql)

            cmd.CommandText = sql

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Los datos se han guardado Correctamente!, " & vbCrLf & " Compras de PLATINO", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'LIMPIO LOS CAMPOS
            Me.TextPrefijo.Clear()
            Me.TxtNum_com.Clear()
            Me.Txtced_cl.Clear()
            Me.TxtNomPaciente.Clear()
            Me.TxtNomApe.Clear()
            Me.DTPfechaactual.Text = Format(DateTime.Now, "dd/MM/yyyy")
            Me.TxtDireccion.Clear()
            Me.TxtTelC.Clear()
            Me.TxtCorreo.Clear()
            Me.TxtCiudad.Clear()
            Me.TxtDpto_cl.Clear()
            Me.Txtrut.Clear()
            Me.TxtAct.Clear()
            '===================
            Me.CboMetal.SelectedIndex = -1
            Me.CboCiudad.SelectedIndex = -1
            Me.CboDpto.SelectedIndex = -1
            Me.TxtConcepto.Clear()
            Me.TxtDetMaterial.Clear()
            Me.TxtMesRega.Clear()

            Me.TxtGrBr.Clear()
            Me.TxtLey.Clear()
            Me.TxtGrPuros.Clear()
            Me.TxtBase.Clear()
            Me.TxtVrVenta.Clear()

            Me.TxtRegalias.Clear()
            Me.Txtvrrfgr.Clear()
            Me.TxtVrRF.Clear()

            Me.TxtLblGrRg.Clear()
            Me.TxtReteValor.Clear()
            Me.TxtLblpago.Clear()
            Me.TxtBarequero.Clear()

            Me.TxtFechaTasa.Clear()

            Me.TxtMes.Clear()
            Me.TxtAño.Clear()

            Me.PictureQR.Dispose()
            Me.TxtNomQr.Clear()

            'INHABILITO LOS CAMPOS
            Me.CboMetal.Enabled = False
            Me.CboCiudad.Enabled = False
            Me.CboDpto.Enabled = False
            Me.TxtConcepto.Enabled = False
            Me.TxtDetMaterial.Enabled = False
            Me.TxtMesRega.Enabled = False

            Me.TxtGrBr.Enabled = False
            Me.TxtLey.Enabled = False
            Me.TxtGrPuros.Enabled = False
            Me.TxtBase.Enabled = False
            Me.TxtVrVenta.Enabled = False

            Me.TxtRegalias.Enabled = False
            Me.Txtvrrfgr.Enabled = False
            Me.TxtVrRF.Enabled = False

            Me.TxtLblGrRg.Enabled = False
            Me.TxtReteValor.Enabled = False
            Me.TxtLblpago.Enabled = False
            Me.TxtBarequero.Enabled = False

            Me.TxtFechaTasa.Enabled = False

            Me.TxtMes.Enabled = False
            Me.TxtAño.Enabled = False

            Me.CboFormaPago.Enabled = False
            Me.TxtNumTarjeta.Enabled = False
            Me.CboBancos.Enabled = False

            'BOTONES
            Me.BtnActualiza.Enabled = False
            Me.BtnNuevo.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnImprime.Enabled = True
            Me.BtnCalculo.Enabled = False

        Catch ex As Exception

            'mensaje de error del procedimiento
            MsgBox("Error: " & Err.Description)
            'muestro el mensaje de resultado
            MsgBox("Error al guardar los datos, Compras" & ex.Message, MsgBoxStyle.Information, "AppMinerGold")

            'LIMPIO LOS CAMPOS
            Me.TextPrefijo.Enabled = False
            Me.TxtNum_com.Clear()
            Me.Txtced_cl.Clear()
            Me.TxtNomPaciente.Clear()
            Me.TxtNomApe.Clear()
            Me.DTPfechaactual.Text = Format(DateTime.Now, "dd/MM/yyyy")
            Me.TxtDireccion.Clear()
            Me.TxtTelC.Clear()
            Me.TxtCorreo.Clear()
            Me.TxtCiudad.Clear()
            Me.TxtDpto_cl.Clear()
            Me.Txtrut.Clear()
            Me.TxtAct.Clear()

            Me.TxtNumTarjeta.Clear()

            Me.CboMetal.SelectedIndex = -1
            Me.CboCiudad.SelectedIndex = -1
            Me.CboDpto.SelectedIndex = -1
            Me.TxtConcepto.Clear()
            Me.TxtDetMaterial.Clear()
            Me.TxtGrBr.Clear()
            Me.TxtLey.Clear()
            Me.TxtGrPuros.Clear()
            Me.TxtBase.Clear()
            Me.TxtRegalias.Clear()
            Me.TxtLblGrRg.Clear()
            Me.Txtvrrfgr.Clear()
            Me.TxtReteValor.Clear()
            Me.TxtVrVenta.Clear()
            Me.TxtLblpago.Clear()
            Me.TxtBarequero.Clear()
            Me.TxtFechaTasa.Clear()
            Me.TxtMesRega.Clear()
            Me.TxtVrRF.Clear()
            Me.TxtMes.Clear()
            Me.TxtAño.Clear()

            Me.PictureQR.Dispose()
            Me.TxtNomQr.Clear()

            'INHABILITO LOS CAMPOS
            Me.CboMetal.Enabled = False
            Me.CboCiudad.Enabled = False
            Me.CboDpto.Enabled = False
            Me.TxtConcepto.Enabled = False
            Me.TxtDetMaterial.Enabled = False
            Me.TxtGrBr.Enabled = False
            Me.TxtLey.Enabled = False
            Me.TxtGrPuros.Enabled = False
            Me.TxtBase.Enabled = False
            Me.TxtRegalias.Enabled = False
            Me.TxtReteValor.Enabled = False
            Me.TxtVrVenta.Enabled = False
            Me.TxtFechaTasa.Enabled = False
            Me.TxtMesRega.Enabled = False
            Me.TxtVrRF.Enabled = False
            Me.TxtMes.Enabled = False
            Me.TxtAño.Enabled = False

            Me.CboFormaPago.Enabled = False
            Me.TxtNumTarjeta.Enabled = False
            Me.CboBancos.Enabled = False

            'BOTONES
            Me.BtnActualiza.Enabled = True
            Me.BtnNuevo.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnImprime.Enabled = False
            Me.BtnCalculo.Enabled = False

        End Try

    End Sub

    'PROCEDIMIENTO DE GUARDAR DATOS TRIMETRES Y MES
    Private Sub AgregaFechas()
        Dim FechaActual As Date = Date.Now.ToShortDateString
        Dim FechaC As Date = CDate(Format(Date.Now.Date))
        Dim FechaM As Date = CDate(Format(Date.Now.Date))

        Dim UnoTri As String = ""
        Dim DosTri As String = ""
        Dim TresTri As String = ""
        Dim CuatroTri As String = ""

        Dim Ene As String = ""
        Dim Feb As String = ""
        Dim Mar As String = ""
        Dim Abr As String = ""
        Dim May As String = ""
        Dim Jun As String = ""
        Dim Jul As String = ""
        Dim Ago As String = ""
        Dim Sep As String = ""
        Dim Oct As String = ""
        Dim Nov As String = ""
        Dim Dic As String = ""

        Try

            If TxtMonth.Text = "1" Then
                UnoTri = "1 X"
                DosTri = "2"
                TresTri = "3"
                CuatroTri = "4"
            ElseIf TxtMonth.Text = "2" Then
                UnoTri = "1 X"
                DosTri = "2"
                TresTri = "3"
                CuatroTri = "4"
            ElseIf TxtMonth.Text = "3" Then
                UnoTri = "1 X"
                DosTri = "2"
                TresTri = "3"
                CuatroTri = "4"
            End If

            If TxtMonth.Text = "4" Then
                UnoTri = "1"
                DosTri = "2 X"
                TresTri = "3"
                CuatroTri = "4"
            ElseIf TxtMonth.Text = "5" Then
                UnoTri = "1"
                DosTri = "2 X"
                TresTri = "3"
                CuatroTri = "4"
            ElseIf TxtMonth.Text = "6" Then
                UnoTri = "1"
                DosTri = "2 X"
                TresTri = "3"
                CuatroTri = "4"
            End If

            If TxtMonth.Text = "7" Then
                UnoTri = "1"
                DosTri = "2"
                TresTri = "3 X"
                CuatroTri = "4"
            ElseIf TxtMonth.Text = "8" Then
                UnoTri = "1"
                DosTri = "2"
                TresTri = "3 X"
                CuatroTri = "4"
            ElseIf TxtMonth.Text = "9" Then
                UnoTri = "1"
                DosTri = "2"
                TresTri = "3 X"
                CuatroTri = "4"
            End If

            If TxtMonth.Text = "10" Then
                UnoTri = "1"
                DosTri = "2"
                TresTri = "3"
                CuatroTri = "4 X"
            ElseIf TxtMonth.Text = "11" Then
                UnoTri = "1"
                DosTri = "2"
                TresTri = "3"
                CuatroTri = "4 X"
            ElseIf TxtMonth.Text = "12" Then
                UnoTri = "1"
                DosTri = "2"
                TresTri = "3"
                CuatroTri = "4 X"
            End If

            If TxtMonth.Text = "1" Then
                Ene = "Enero X"
                Feb = "Febrero"
                Mar = "Marzo"
                Abr = "Abril"
                May = "Mayo"
                Jun = "Junio"
                Jul = "Julio"
                Ago = "Agosto"
                Sep = "Septiembre"
                Oct = "Octubre"
                Nov = "Noviembre"
                Dic = "Diciembre"
            ElseIf TxtMonth.Text = "2" Then
                Ene = "Enero"
                Feb = "Febrero X"
                Mar = "Marzo"
                Abr = "Abril"
                May = "Mayo"
                Jun = "Junio"
                Jul = "Julio"
                Ago = "Agosto"
                Sep = "Septiembre"
                Oct = "Octubre"
                Nov = "Noviembre"
                Dic = "Diciembre"
            ElseIf TxtMonth.Text = "3" Then
                Ene = "Enero"
                Feb = "Febrero"
                Mar = "Marzo X"
                Abr = "Abril"
                May = "Mayo"
                Jun = "Junio"
                Jul = "Julio"
                Ago = "Agosto"
                Sep = "Septiembre"
                Oct = "Octubre"
                Nov = "Noviembre"
                Dic = "Diciembre"
            ElseIf TxtMonth.Text = "4" Then
                Ene = "Enero"
                Feb = "Febrero"
                Mar = "Marzo"
                Abr = "Abril X"
                May = "Mayo"
                Jun = "Junio"
                Jul = "Julio"
                Ago = "Agosto"
                Sep = "Septiembre"
                Oct = "Octubre"
                Nov = "Noviembre"
                Dic = "Diciembre"
            ElseIf TxtMonth.Text = "5" Then
                Ene = "Enero"
                Feb = "Febrero"
                Mar = "Marzo"
                Abr = "Abril"
                May = "Mayo X"
                Jun = "Junio"
                Jul = "Julio"
                Ago = "Agosto"
                Sep = "Septiembre"
                Oct = "Octubre"
                Nov = "Noviembre"
                Dic = "Diciembre"
            ElseIf TxtMonth.Text = "6" Then
                Ene = "Enero"
                Feb = "Febrero"
                Mar = "Marzo"
                Abr = "Abril"
                May = "Mayo"
                Jun = "Junio X"
                Jul = "Julio"
                Ago = "Agosto"
                Sep = "Septiembre"
                Oct = "Octubre"
                Nov = "Noviembre"
                Dic = "Diciembre"
            ElseIf TxtMonth.Text = "7" Then
                Ene = "Enero"
                Feb = "Febrero"
                Mar = "Marzo"
                Abr = "Abril"
                May = "Mayo"
                Jun = "Junio"
                Jul = "Julio X"
                Ago = "Agosto"
                Sep = "Septiembre"
                Oct = "Octubre"
                Nov = "Noviembre"
                Dic = "Diciembre"
            ElseIf TxtMonth.Text = "8" Then
                Ene = "Enero"
                Feb = "Febrero"
                Mar = "Marzo"
                Abr = "Abril"
                May = "Mayo"
                Jun = "Junio"
                Jul = "Julio"
                Ago = "Agosto X"
                Sep = "Septiembre"
                Oct = "Octubre"
                Nov = "Noviembre"
                Dic = "Diciembre"
            ElseIf TxtMonth.Text = "9" Then
                Ene = "Enero"
                Feb = "Febrero"
                Mar = "Marzo"
                Abr = "Abril"
                May = "Mayo"
                Jun = "Junio"
                Jul = "Julio"
                Ago = "Agosto"
                Sep = "Septiembre X"
                Oct = "Octubre"
                Nov = "Noviembre"
                Dic = "Diciembre"
            ElseIf TxtMonth.Text = "10" Then
                Ene = "Enero"
                Feb = "Febrero"
                Mar = "Marzo"
                Abr = "Abril"
                May = "Mayo"
                Jun = "Junio"
                Jul = "Julio"
                Ago = "Agosto"
                Sep = "Septiembre"
                Oct = "Octubre X"
                Nov = "Noviembre"
                Dic = "Diciembre"
            ElseIf TxtMonth.Text = "11" Then
                Ene = "Enero"
                Feb = "Febrero"
                Mar = "Marzo"
                Abr = "Abril"
                May = "Mayo"
                Jun = "Junio"
                Jul = "Julio"
                Ago = "Agosto"
                Sep = "Septiembre"
                Oct = "Octubre"
                Nov = "Noviembre X"
                Dic = "Diciembre"
            ElseIf TxtMonth.Text = "12" Then
                Ene = "Enero"
                Feb = "Febrero"
                Mar = "Marzo"
                Abr = "Abril"
                May = "Mayo"
                Jun = "Junio"
                Jul = "Julio"
                Ago = "Agosto"
                Sep = "Septiembre"
                Oct = "Octubre"
                Nov = "Noviembre"
                Dic = "Diciembre X"
            End If

            cmd = New OleDbCommand("INSERT INTO Trimestre (Ced_Comprador, Fecha_Compra, Consecutivo_Compra, 
            UnoTrimestre, DosTrimestre, TresTrimestre, CuatroTrimestre, 
            enero, febrero, marzo, abril, mayo, junio, 
            julio, agosto, septiembre, octubre, noviembre, diciembre, 
            fecha_creado, fecha_modifica) VALUES ('" & TxtCedImp.Text & "', '" & FechaActual & "', '" & TxtConseImp.Text & "',
            '" & UnoTri & "', '" & DosTri & "', '" & TresTri & "', '" & CuatroTri & "', 
            '" & Ene & "', '" & Feb & "', '" & Mar & "', '" & Abr & "', '" & May & "', '" & Jun & "', 
            '" & Jul & "', '" & Ago & "', '" & Sep & "', '" & Oct & "', '" & Nov & "', '" & Dic & "', 
            '" & FechaC & "', '" & FechaM & "')", conn)

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            'MessageBox.Show("Los datos se han guardado Trimestre!, Compras de PLATINO", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show("Error al guardar Trimestre!, Compras de PLATINO " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


#End Region

#Region "CONTADORES PARA AMBOS CONCEPTOS"

    'CONTADOR
    Function ContadorIngreso()
        Try
            Dim conT As String
            conT = Txtced_cl.Text
            UltimoIdIngreso()
            Me.TxtNum_com.Text = UltimoIdIngreso()
            Return conT
        Catch ex As Exception
            MessageBox.Show("", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim Num As String = "1"
            Me.TxtNum_com.Text = Num
        End Try
    End Function

    'para encontrar el valor máximo de una columna y ultimo registro
    Public Function UltimoIdIngreso() As String
        conn.Close()
        Dim resultado As String
        resultado = 0
        Dim query As String = "SELECT MAX(consecutivo) FROM Declara"
        Dim comando As OleDbCommand
        Dim lector As OleDbDataReader
        conn.Open()
        comando = New OleDbCommand(query, conn)
        lector = comando.ExecuteReader
        If lector.Read Then
            resultado = Val(lector(0).ToString)
        End If
        lector.Close()
        conn.Close()
        resultado = resultado + 1
        Return resultado
    End Function

#End Region

#Region "EVENTO KEYPRESS"

    'FORMATO NUMERICO GRAMOS BRUTOS Y ENTER - EVENTO KEYPRESS
    Private Sub TxtGrBr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtGrBr.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        NumerosyDecimal(TxtGrBr, e)

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    'FORMATO NUMERICO LEY Y ENTER - EVENTO KEYPRESS
    Private Sub TxtLey_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtLey.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        NumerosyDecimal(TxtLey, e)

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    'FORMATO NUMERICO PRECIO BASE Y ENTER - EVENTO KEYPRESS
    Private Sub TxtGrPuros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtGrPuros.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        NumerosyDecimal(TxtBase, e)

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'COLOCAR LETRAS EN MAYUSCULAS
    Private Sub TxtDetMaterial_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'COLOCAR LETRAS EN MAYUSCULAS
    Private Sub CboCiudDpto_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'SELECCIONAR COMBOBOX DE FORMA DE PAGO
    Private Sub CboFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFormaPago.SelectedIndexChanged
        'CHEQUE
        If Me.CboFormaPago.SelectedIndex = 1 Then
            Dim sindex As Integer
            sindex = CboFormaPago.SelectedIndex
            Dim sitem As Object
            sitem = CboFormaPago.SelectedItem
            Me.TxtNumTarjeta.Clear()
            Me.TxtNumTarjeta.Enabled = True
            Me.TxtNumTarjeta.Select()
            Me.TxtNumTarjeta.Focus()
            Me.CboBancos.Enabled = True
            'CREDITO
        ElseIf Me.CboFormaPago.SelectedIndex = 2 Then
            Dim sindex As Integer
            sindex = CboFormaPago.SelectedIndex
            Dim sitem As Object
            sitem = CboFormaPago.SelectedItem
            Me.TxtNumTarjeta.Clear()
            Me.TxtNumTarjeta.Enabled = False
            Me.TxtNumTarjeta.Text = "PAGO A CRÉDITO"
            Me.CboBancos.Enabled = False
            Me.CboBancos.Text = "Seleccione un Banco"
            'EFECTIVO
        ElseIf CboFormaPago.SelectedIndex = 3 Then
            Dim sindex As Integer
            sindex = CboFormaPago.SelectedIndex
            Dim sitem As Object
            sitem = CboFormaPago.SelectedItem
            Me.TxtNumTarjeta.Clear()
            Me.TxtNumTarjeta.Enabled = False
            Me.TxtNumTarjeta.Text = "N/A"
            Me.CboBancos.Enabled = False
            Me.CboBancos.Text = "N/A"
            'TARJETAS
        ElseIf CboFormaPago.SelectedIndex = 4 Then
            Dim sindex As Integer
            sindex = CboFormaPago.SelectedIndex
            Dim sitem As Object
            sitem = CboFormaPago.SelectedItem
            Me.TxtNumTarjeta.Clear()
            Me.TxtNumTarjeta.Enabled = True
            Me.TxtNumTarjeta.Select()
            Me.TxtNumTarjeta.Focus()
            Me.CboBancos.Enabled = True
        End If
    End Sub

    'KEYPRESS DE FORMA DE PAGO
    Private Sub CboFormaPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboFormaPago.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'KEYPRESS DE NUMERO DE TARJETA 
    Private Sub TxtNumTarjeta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumTarjeta.KeyPress
        SoloNumeros(e)
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'KEYPRESS DE BANCOS
    Private Sub CboBancos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboBancos.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'KEYPRESS DE DEPARTAMENTO DE COMPRA DE MATERIAL
    Private Sub CboDpto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboDpto.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

#Region "EVENTO LEAVE"

    'FORMATO VALOR GRAMOS BRUTOS
    Private Sub TxtGrBr_Leave(sender As Object, e As EventArgs) Handles TxtGrBr.Leave
        'Me.TxtGrBr.Text = CDec(If(TxtGrBr.Text.Contains(","), TxtGrBr.Text.Replace(",", "."), TxtGrBr.Text))
    End Sub

    'FORMATO VALOR LEY
    Private Sub TxtLey_Leave(sender As Object, e As EventArgs) Handles TxtLey.Leave
        'Me.TxtLey.Text = CDec(If(TxtLey.Text.Contains(","), TxtLey.Text.Replace(",", "."), TxtLey.Text))
    End Sub

    'FORMATO VALOR GRAMOS BRUTOS
    Private Sub TxtBase_LostFocus(sender As Object, e As EventArgs) Handles TxtBase.LostFocus
        Dim xvalor As Double
        xvalor = Val(Me.TxtBase.Text)
        Me.TxtBase.Text = Format(xvalor, "#,###,##0.00")

    End Sub

#End Region


End Class