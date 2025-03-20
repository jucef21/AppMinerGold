Imports System.Data.OleDb

Public Class FrmEliminaCompraPlata

    'CARGUE DEL FORMULARIO
    Private Sub FrmEliminaCompraPlata_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ","
        Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = "."
        Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ","
        Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = "."

        'LLENAMOS LOS DATOS DEL ENCABEZADO DEL CLIENTE - PANEL 1========================

        'colocamos los texbox en no editable
        Me.TxtNum_com.Enabled = False
        Me.Txtced_cl.Enabled = False
        Me.TxtNomPaciente.Enabled = False
        Me.TxtNomApe.Enabled = False
        Me.DTPfechaactual.Enabled = False
        Me.TxtDireccion.Enabled = False
        Me.TxtTelC.Enabled = False
        Me.TxtCorreo.Enabled = False
        Me.TxtCiudadReside.Enabled = False
        Me.TxtDpto_cl.Enabled = False
        Me.Txtrut.Enabled = False
        Me.TxtAct.Enabled = False

        'Habilito los campos de texto
        Me.TxtMaterial.Enabled = False
        Me.TxtConcepto.Enabled = False
        Me.TxtCiudadCompra.Enabled = False
        Me.TxtDptocompra.Enabled = False
        Me.TxtDetMaterial.Enabled = False

        Me.TxtGrBr.Enabled = False
        Me.TxtLey.Enabled = False
        Me.TxtGrPuros.Enabled = False
        Me.TxtBase.Enabled = False
        Me.TxtRegalias.Enabled = False
        Me.TxtVrVenta.Enabled = False

        Me.TxtReteValor.Enabled = False
        Me.TxtVrRF.Enabled = False

        Me.TxtMes.Enabled = False
        Me.TxtAño.Enabled = False

        'BOTONES
        Me.BtnEliminaComp.Enabled = True

        'Validamos fecha Actual de compra seleccionado el mes
        'Asigna date usando short format.
        Dim FechaActual As Date = Date.Now.ToShortDateString
        Dim NumMes As Integer
        NumMes = DateAndTime.Month(FechaActual)
        'alista la variable para mostrar el Mes actual
        TxtMonth.Text = NumMes

        TxtCedImp.Text = Txtced_cl.Text
        TxtConse.Text = TxtNum_com.Text

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE GUADAR CAMBIOS
    Private Sub BtnEliminaComp_Click(sender As Object, e As EventArgs) Handles BtnEliminaComp.Click
        Dim respuesta As Byte
        Dim adaptador As New OleDb.OleDbDataAdapter
        Dim registros As New DataSet

        Dim num As Integer
        num = CInt(Me.TxtNum_com.Text)

        Try
            'revisamos conexion
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Close()
            End If
            'hacemos la consulta
            respuesta = CByte(MsgBox("¿Esta seguro de Eliminar este Registro de Compra?", MsgBoxStyle.YesNo, "AppMinerGold"))
            'verificamos la respuesta
            If respuesta = vbYes Then
                '===================================CAMBIO
                ModiComprasEliminado()
                'presentamos el mensaje 
                MsgBox("Registro eliminado con exito de la base de datos!", MsgBoxStyle.Information, "AppMinerGold")

                EliminaFechas()

                LimpiaDatos()
                Me.BtnEliminaComp.Enabled = False
                'cierro conexion
                'Conectar.conn.Close()
                Refresh()
            Else
                'posicionamos el cursor
            End If
            'Conectar.conn.Close()
            Refresh()
        Catch ex As Exception
            MsgBox("Imposible Eliminar porque...:" & ex.Message, MsgBoxStyle.Information, "AppMinerGold")
        End Try
        'Por Ultimo Cierro La conexion
        'Conectar.conn.Close()
    End Sub

    'PROCEDIMIENTO PARA GUARDAR LOS CAMBIOS
    Private Sub ModiComprasEliminado()
        'fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        cmd.CommandType = CommandType.Text
        cmd.Connection = conn

        Dim num As Integer
        num = CInt(Me.TxtNum_com.Text)

        'VARIABLE DE ELIMINACION
        Dim Ebrutos, Eley, Epuros, Ebase, Eregala, Evrventa, Emestasa, Egp_rg, Egp_base As String
        Dim Epagobare, Eletras, Edetallemineral, EciudadCom, EdptpCom As String
        Dim Ecedu_com, Enom_com, Etelc_com, Ecorreo_com, Erut_com, Enumfundi, Everifica As String
        Dim Edire_com, Edpto_com, Eact_com, Econce_com, Eciudad As String

        Ecedu_com = "1111111111"
        Enom_com = "ANULADO"
        Edire_com = "ANULADO"
        Etelc_com = "1111111111"
        Ecorreo_com = "ANULADO"
        Erut_com = "1111111111"
        Eciudad = "ANULADO"
        Edpto_com = "ANULADO"
        Eact_com = "ANULADO"
        Enumfundi = "0101"
        Everifica = "1"
        Econce_com = "ANULADO"
        Edetallemineral = "ANULADO"

        Ebrutos = "0"
        Eley = "0"
        Epuros = "0"
        Ebase = "0"
        Eregala = "0"
        Evrventa = "0"
        Emestasa = "Seleccione"
        Egp_rg = "0"
        Egp_base = "0"
        Epagobare = "0"
        Eletras = "ANULADO"
        EciudadCom = "ANULADO"
        EdptpCom = "ANULADO"

        Try
            Dim sqlConsulta As String = "UPDATE Declara SET cedu_com = '" & Ecedu_com & "', " &
                                          "nom_com = '" & Enom_com & "', " &
                                          "fecha_com = '" & DTPfechaactual.Text & "', " &
                                          "dire_com =  '" & Edire_com & "', " &
                                          "telc_com = '" & Etelc_com & "', " &
                                          "correo_com = '" & Ecorreo_com & "', " &
                                          "ciuddpto = '" & Eciudad & "', " &
                                          "dpto_com = '" & Edpto_com & "', " &
                                          "rut_com = '" & Erut_com & "', " &
                                          "act_com = '" & Eact_com & "', " &
                                          "conce_com = '" & Econce_com & "', " &
                                          "detallemineral = '" & Edetallemineral & "', " &
                                          "grbrutos = '" & Ebrutos & "',  " &
                                          "ley = '" & Eley & "', " &
                                          "grpuros = '" & Epuros & "', " &
                                          "base = '" & Ebase & "', " &
                                          "regala = '" & Eregala & "', " &
                                          "vrventa = '" & Evrventa & "', " &
                                          "mestasa = '" & Emestasa & "', " &
                                          "gp_rg = '" & Egp_rg & "', " &
                                          "gp_base = '" & Egp_base & "', " &
                                          "pagobare = '" & Epagobare & "',  " &
                                          "mes_com = '" & TxtMes.Text & "', " &
                                          "año_com =  '" & TxtAño.Text & "', " &
                                          "fecha_modifica = '" & fechaM & "', " &
                                          "letras = '" & Eletras & "', " &
                                          "verifica = '" & Everifica & "', " &
                                          "numfundi = '" & Enumfundi & "', " &
                                          "ciudad = '" & EciudadCom & "', " &
                                          "dpto = '" & EdptpCom & "' WHERE consecutivo = " & num

            cmd = New OleDb.OleDbCommand(sqlConsulta, conn)

            'ABRO CONEXION
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            'presentamos el mensaje 
            MessageBox.Show("Registro de Compras Eliminado Exitosamente de la Base de Datos.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'LIMPIO LOS CAMPOS
            Me.TxtNum_com.Clear()
            Me.Txtced_cl.Clear()
            Me.TxtNomPaciente.Clear()
            Me.TxtNomApe.Clear()
            Me.DTPfechaactual.Text = Format(DateTime.Now, "dd/MM/yyyy")
            Me.TxtDireccion.Clear()
            Me.TxtTelC.Clear()
            Me.TxtCorreo.Clear()
            Me.TxtCiudadReside.Clear()
            Me.TxtDpto_cl.Clear()
            Me.Txtrut.Clear()
            Me.TxtAct.Clear()
            '===================
            Me.TxtMaterial.Clear()
            Me.TxtConcepto.Clear()
            Me.TxtCiudadCompra.Clear()
            Me.TxtDptocompra.Clear()
            Me.TxtDetMaterial.Clear()
            Me.TxtGrBr.Clear()
            Me.TxtLey.Clear()
            Me.TxtGrPuros.Clear()
            Me.TxtBase.Clear()
            Me.TxtRegalias.Clear()
            Me.TxtLblGrRg.Clear()
            Me.TxtBarequero.Clear()
            Me.TxtVrVenta.Clear()
            Me.TxtFechaTasa.Clear()
            Me.TxtMesRega.Clear()
            Me.TxtVrRF.Clear()
            Me.TxtMes.Clear()
            Me.TxtAño.Clear()

            'INHABILITO LOS CAMPOS
            Me.TxtMaterial.Enabled = False
            Me.TxtConcepto.Enabled = False
            Me.TxtCiudadCompra.Enabled = False
            Me.TxtDptocompra.Enabled = False
            Me.TxtDetMaterial.Enabled = False
            Me.TxtGrBr.Enabled = False
            Me.TxtLey.Enabled = False
            Me.TxtGrPuros.Enabled = False
            Me.TxtBase.Enabled = False
            Me.TxtRegalias.Enabled = False
            Me.TxtLblGrRg.Enabled = False
            Me.TxtBarequero.Enabled = False
            Me.TxtVrVenta.Enabled = False
            Me.TxtFechaTasa.Enabled = False
            Me.TxtMesRega.Enabled = False
            Me.TxtMes.Enabled = False
            Me.TxtAño.Enabled = False

        Catch ex As Exception
            'mensaje de error del procedimiento
            MsgBox("Error: " & Err.Description)
            'muestro el mensaje de resultado
            MessageBox.Show("Error al Guardar Cambios en los datos, Compras" & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'LIMPIO LOS CAMPOS
            Me.TxtNum_com.Clear()
            Me.Txtced_cl.Clear()
            Me.TxtNomPaciente.Clear()
            Me.TxtNomApe.Clear()
            Me.DTPfechaactual.Text = Format(DateTime.Now, "dd/MM/yyyy")
            Me.TxtDireccion.Clear()
            Me.TxtTelC.Clear()
            Me.TxtCorreo.Clear()
            Me.TxtCiudadReside.Clear()
            Me.TxtDpto_cl.Clear()
            Me.Txtrut.Clear()
            Me.TxtAct.Clear()
            '===================
            Me.TxtMaterial.Clear()
            Me.TxtConcepto.Clear()
            Me.TxtCiudadCompra.Clear()
            Me.TxtDptocompra.Clear()
            Me.TxtDetMaterial.Clear()
            Me.TxtGrBr.Clear()
            Me.TxtLey.Clear()
            Me.TxtGrPuros.Clear()
            Me.TxtBase.Clear()
            Me.TxtRegalias.Clear()
            Me.TxtLblGrRg.Clear()
            Me.TxtBarequero.Clear()
            Me.TxtVrVenta.Clear()
            Me.TxtFechaTasa.Clear()
            Me.TxtMesRega.Clear()
            Me.TxtVrRF.Clear()
            Me.TxtMes.Clear()
            Me.TxtAño.Clear()

            'INHABILITO LOS CAMPOS
            Me.TxtMaterial.Enabled = False
            Me.TxtConcepto.Enabled = False
            Me.TxtCiudadCompra.Enabled = False
            Me.TxtDptocompra.Enabled = False
            Me.TxtDetMaterial.Enabled = False
            Me.TxtGrBr.Enabled = False
            Me.TxtLey.Enabled = False
            Me.TxtGrPuros.Enabled = False
            Me.TxtBase.Enabled = False
            Me.TxtRegalias.Enabled = False
            Me.TxtLblGrRg.Enabled = False
            Me.TxtBarequero.Enabled = False
            Me.TxtVrVenta.Enabled = False
            Me.TxtFechaTasa.Enabled = False
            Me.TxtMesRega.Enabled = False
            Me.TxtMes.Enabled = False
            Me.TxtAño.Enabled = False

        End Try
    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    Private Sub LimpiaDatos()
        'DATOS DEL CLIENTES
        Me.TxtNum_com.Clear()
        Me.Txtced_cl.Clear()
        Me.TxtNomApe.Clear()
        Me.DTPfechaactual.Text = Date.Today
        Me.TxtDireccion.Clear()
        Me.TxtTelC.Clear()
        Me.TxtCorreo.Clear()
        Me.TxtCiudadReside.Clear()
        Me.TxtDpto_cl.Clear()
        Me.Txtrut.Clear()
        Me.TxtAct.Clear()
        Me.TxtMaterial.Clear()
        Me.TxtConcepto.Clear()
        Me.TxtCiudadCompra.Clear()
        Me.TxtDptocompra.Clear()
        Me.TxtDetMaterial.Clear()
        Me.TxtGrBr.Clear()
        Me.TxtLey.Clear()
        Me.TxtGrPuros.Clear()
        Me.TxtBase.Clear()
        Me.TxtRegalias.Clear()
        Me.TxtReteValor.Clear()
        Me.TxtVrVenta.Clear()
        Me.TxtMesRega.Clear()
        Me.TxtVrRF.Clear()
        Me.TxtLblGrRg.Clear()
        Me.TxtLblpago.Clear()
        Me.Txtvrrfgr.Clear()
        Me.TxtBarequero.Clear()
        Me.TxtMes.Clear()
        Me.TxtAño.Clear()

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
        Dim numced As Integer = CInt(Txtced_cl.Text)

        'revisamos la conexin a la base de datos
        If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            Conectar.conn.Close()
        End If

        'Conectar.conn.ConnectionString = cs
        Dim consulta As String = "SELECT * FROM Clientes WHERE ced_cl = " & numced  '" & Txtced_cl.Text & "' "
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
                    Dim x As Decimal = CDec(If(TxtBase.Text.Contains("."), TxtBase.Text.Replace(".", ","), TxtBase.Text))
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

        Dim consulta As String = "SELECT TOP 1 * FROM RegaliasPlata WHERE id = id ORDER BY Id DESC "
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)
        Try
            Dim drd As OleDbDataReader
            'conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                'GROUPBOX 2 ======================
                Me.TxtRegalias.Text = drd.Item("detalle").ToString
                Me.TxtMesRega.Text = drd.Item("descri").ToString

                Dim Xr As Decimal = CDec(If(TxtRegalias.Text.Contains("."), TxtRegalias.Text.Replace(".", ","), TxtRegalias.Text))
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

        Dim consulta As String = "SELECT TOP 1 * FROM RetefuentePlata WHERE id = id ORDER BY Id DESC "
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)
        Try
            Dim drd As OleDbDataReader
            'conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                'GROUPBOX 2 ======================
                Me.TxtVrRF.Text = drd.Item("detalle").ToString
                'Me.TxtMesRega.Text = drd.Item("descri").ToString

                Dim XrRTF As Decimal = CDec(If(TxtVrRF.Text.Contains("."), TxtVrRF.Text.Replace(".", ","), TxtVrRF.Text))
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

    Public Pago As Decimal = 0
    Public PagoBarequero As Decimal = 0
    Public GrPurReg As Decimal = 0
    Public Letnum As String
    'CAMPO CANTIDAD PARA MULTIPLICAR KEY
    Private Sub BtnCalculo_Click(sender As Object, e As EventArgs)

        If TxtGrBr.Text = "" Or TxtLey.Text = "" Or TxtBase.Text = "" Then
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
            '****INCIAMOS OPERACIONES
            '=========================== GRAMOS BRUTOS
            'Muestro el resultado en un Label para guardar
            Dim LabelBrutos As Decimal = CDec(If(TxtGrBr.Text.Contains("."), TxtGrBr.Text.Replace(".", ","), TxtGrBr.Text))
            LabelBrutos = Math.Round(LabelBrutos, 4)
            Me.Lblbrutos.Text = LabelBrutos.ToString
            '=========================== LEY
            'Muestro el resultado en un Label para guardar
            Dim VrLey As Decimal = CDec(If(TxtLey.Text.Contains("."), TxtLey.Text.Replace(".", ","), TxtLey.Text))
            VrLey = Math.Round(VrLey, 4)
            Me.TxtLey.Text = VrLey.ToString
            '=========================== GRAMOS PUROS ( BRUTOS * LEY )
            Dim Rpuros As Decimal = CDec(If(TxtGrBr.Text.Contains("."), TxtGrBr.Text.Replace(".", ","), TxtGrBr.Text)) * CDec(If(TxtLey.Text.Contains("."), TxtLey.Text.Replace(".", ","), TxtLey.Text))
            Rpuros = Math.Round(Rpuros, 4)
            Me.TxtGrPuros.Text = Rpuros.ToString
            '=========================== VALOR DE PRECIO BASE
            'Dim Cbase As Decimal '= 0
            'Decimal.TryParse(TxtBase.Text, Cbase)
            'Me.TxtBase.Text = Cbase

            Dim Cbase As Decimal = CDec(If(TxtBase.Text.Contains("."), TxtBase.Text.Replace(".", ","), TxtBase.Text))
            Cbase = Math.Round(Cbase, 2)
            Me.TxtBase.Text = Cbase.ToString

            '=========================== VALOR TOTAL DEL PRECIO REGALIAS
            Dim ValorTotRegalias As Decimal = CDec(If(TxtGrPuros.Text.Contains("."), TxtGrPuros.Text.Replace(".", ","), TxtGrPuros.Text)) * CDec(If(TxtRegalias.Text.Contains("."), TxtRegalias.Text.Replace(".", ","), TxtRegalias.Text))
            ValorTotRegalias = Math.Round(ValorTotRegalias, 4)
            Me.TxtLblGrRg.Text = ValorTotRegalias.ToString
            '=========================== VALOR RETEFUENTE CALCULO VALOR POR GRAMO (BASE * 2,5%)
            Dim ReteValor As Decimal = CDec(If(TxtBase.Text.Contains("."), TxtBase.Text.Replace(".", ","), TxtBase.Text)) * CDec(If(TxtVrRF.Text.Contains("."), TxtVrRF.Text.Replace(".", ","), TxtVrRF.Text) / 100)
            ReteValor = Math.Round(ReteValor, 4)
            Me.Txtvrrfgr.Text = ReteValor.ToString
            '=========================== RESULTADO VALOR TOTAL (GRPUROS * BASE + VRTOTALREGALIAS)
            Dim Rtotal As Decimal = 0
            Rtotal = Rpuros * Cbase + ValorTotRegalias
            'Me.TxtVrVenta.Text = Format(Rtotal, "###,###,##0.00")
            Me.TxtVrVenta.Text = Rtotal
            '==== OPERACION PARA SACAR EL VALOR DEL IMPUESTO TOTAL DE RETEFUENTE
            Dim ValorImpRF As Decimal = Rtotal * CDec(If(TxtVrRF.Text.Contains("."), TxtVrRF.Text.Replace(".", ","), TxtVrRF.Text) / 100)
            ValorImpRF = Math.Round(ValorImpRF, 4)
            Me.TxtReteValor.Text = ValorImpRF.ToString
            '====================== TOTAL A PAGAR AL BAREQUERO (VALORTOTAL - VRTOTALREGALIAS - VRRETEFUENTE)
            Pago = Rtotal - ValorTotRegalias - ValorImpRF
            Pago = Math.Round(Pago, 4)
            Me.TxtLblpago.Text = Pago.ToString
            Me.TxtBarequero.Text = Pago.ToString
            '======================= CONVERTIMOS LOS NUMEROS A LETRAS
            'ENVIAMOS EL RESULTADO A UNA CAJA DE TEXTO EN LETRAS
            Pointer1 = 0
            Lbletras.Text = SpellNumber(Val(Me.TxtVrVenta.Text))
            Letnum = Lbletras.Text

        End If

        Me.TxtDetMaterial.Enabled = False
        Me.TxtGrBr.Enabled = False
        Me.TxtLey.Enabled = False
        Me.TxtGrPuros.Enabled = False
        Me.TxtBase.Enabled = False

    End Sub

    'Valida solo Numeros
    Public Sub NumerosyDecimal(ByVal CajaTexto As Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not CajaTexto.Text.IndexOf(",") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'PROCEDIMIENTO DE GUARDAR DATOS TRIMETRES Y MES PARA ELIMINAR
    Private Sub EliminaFechas()
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

        Dim SqlUpdate As String

        Try

            If TxtMonth.Text = "1" Then
                UnoTri = "ANULADO"
            ElseIf TxtMonth.Text = "2" Then
                UnoTri = "ANULADO"
            ElseIf TxtMonth.Text = "3" Then
                UnoTri = "ANULADO"
            End If

            If TxtMonth.Text = "4" Then
                DosTri = "ANULADO"
            ElseIf TxtMonth.Text = "5" Then
                DosTri = "ANULADO"
            ElseIf TxtMonth.Text = "6" Then
                DosTri = "ANULADO"
            End If

            If TxtMonth.Text = "7" Then
                TresTri = "ANULADO"
            ElseIf TxtMonth.Text = "8" Then
                TresTri = "ANULADO"
            ElseIf TxtMonth.Text = "9" Then
                TresTri = "ANULADO"
            End If

            If TxtMonth.Text = "10" Then
                CuatroTri = "ANULADO"
            ElseIf TxtMonth.Text = "11" Then
                CuatroTri = "ANULADO"
            ElseIf TxtMonth.Text = "12" Then
                CuatroTri = "ANULADO"
            End If

            If TxtMonth.Text = "1" Then
                Ene = "ANULADO"
            ElseIf TxtMonth.Text = "2" Then
                Feb = "ANULADO"
            ElseIf TxtMonth.Text = "3" Then
                Mar = "ANULADO"
            ElseIf TxtMonth.Text = "4" Then
                Abr = "ANULADO"
            ElseIf TxtMonth.Text = "5" Then
                May = "ANULADO"
            ElseIf TxtMonth.Text = "6" Then
                Jun = "ANULADO"
            ElseIf TxtMonth.Text = "7" Then
                Jul = "ANULADO"
            ElseIf TxtMonth.Text = "8" Then
                Ago = "ANULADO"
            ElseIf TxtMonth.Text = "9" Then
                Sep = "ANULADO"
            ElseIf TxtMonth.Text = "10" Then
                Oct = "ANULADO"
            ElseIf TxtMonth.Text = "11" Then
                Nov = "ANULADO"
            ElseIf TxtMonth.Text = "12" Then
                Dic = "ANULADO"
            End If

            Dim CedComp As String = Convert.ToInt32(1111111111)
            Dim Num As String = Convert.ToInt32(TxtConse.Text)
            Dim NumConse As String = Convert.ToInt32(11111)

            SqlUpdate = "UPDATE Trimestre SET Ced_Comprador = '" & CedComp & "',
                                   Consecutivo_Compra = '" & NumConse & "',
                                   UnoTrimestre = '" & UnoTri & "', 
                                   DosTrimestre = '" & DosTri & "', 
                                   TresTrimestre = '" & TresTri & "', 
                                   CuatroTrimestre = '" & CuatroTri & "', 
                                   enero = '" & Ene & "', 
                                   febrero = '" & Feb & "', 
                                   marzo = '" & Mar & "', 
                                   abril = '" & Abr & "', 
                                   mayo = '" & May & "', 
                                   junio = '" & Jun & "', 
                                   julio = '" & Jul & "', 
                                   agosto = '" & Ago & "', 
                                   septiembre = '" & Sep & "', 
                                   octubre = '" & Oct & "', 
                                   noviembre = '" & Nov & "', 
                                   diciembre = '" & Dic & "', 
                                   fecha_modifica = '" & FechaM & "' WHERE Consecutivo_Compra = " & Num

            cmd = New OleDbCommand(SqlUpdate, conn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            'MessageBox.Show("Los datos Eliminados se han guardado Trimestre!, Compras de PLATA", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show("Error al Eliminar Trimestre!, Compras de PLATA " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

#End Region

#Region "CONTADORES PARA AMBOS CONCEPTOS"

    'CONTADOR
    Function ContadorIngreso()
        Dim conT As String
        conT = Txtced_cl.Text
        UltimoIdIngreso()
        Me.TxtNum_com.Text = UltimoIdIngreso()
        Return conT
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
    Private Sub TxtGrBr_KeyPress(ByVal sender As Object, e As KeyPressEventArgs) Handles TxtGrBr.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ","c Then
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
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ","c Then
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
    Private Sub TxtBase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBase.KeyPress
        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ","c Then
            e.Handled = True
        End If

        NumerosyDecimal(TxtBase, e)

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

#Region "EVENTO LEAVE"

    'FORMATO GRAMOS BRUTOS
    Private Sub TxtBase_Leave(sender As Object, e As EventArgs) Handles TxtBase.Leave
        'Me.TxtBase.Text = CDec(If(Me.TxtBase.Text.Contains("."), TxtBase.Text.Replace(".", ","), TxtBase.Text))
    End Sub

    Private Sub TxtGrBr_Leave(sender As Object, e As EventArgs) Handles TxtGrBr.Leave
        'Me.TxtGrBr.Text = CDec(If(Me.TxtGrBr.Text.Contains("."), TxtGrBr.Text.Replace(".", ","), TxtGrBr.Text))
    End Sub

    'FORMATO VALOR LEY
    Private Sub TxtLey_Leave(sender As Object, e As EventArgs) Handles TxtLey.Leave
        'Me.TxtLey.Text = CDec(If(TxtLey.Text.Contains("."), TxtLey.Text.Replace(".", ","), TxtLey.Text))
        'Me.TxtLey.Text = Format(Val(TxtLey.Text), "#,###,###,###.00")
    End Sub

#End Region

#Region "funciones para el metodo mas simple para convertir numero a letras"

    '*******************************************
    ' Convierte un número  del 1 al 9 en texto. *
    '*******************************************
    Dim Pointer1 As Integer = 0
    Dim Pointer2 As Integer = 0
    Function GetDigit(ByVal Digit)
        Select Case Val(Digit)
            Case 1 : GetDigit = "Un"
            Case 2 : GetDigit = "Dos"
            Case 3 : GetDigit = "Tres"
            Case 4 : GetDigit = "Cuatro"
            Case 5 : GetDigit = "Cinco"
            Case 6 : GetDigit = "Seis"
            Case 7 : GetDigit = "Siete"
            Case 8 : GetDigit = "Ocho"
            Case 9 : GetDigit = "Nueve"
            Case Else : GetDigit = ""
        End Select
    End Function

    '*********************************************
    ' Convierte números de 10 a 99 a texto. *
    '*********************************************
    Function GetTens(ByVal TensText)
        Dim Result As String
        Result = ""           'anula el valor temporal de la funcion
        If Val(Microsoft.VisualBasic.Left(TensText, 1)) = 1 Then   ' si el valor esta entre 10-19
            Select Case Val(TensText)
                Case 10 : Result = "Diez"
                Case 11 : Result = "Once"
                Case 12 : Result = "Doce"
                Case 13 : Result = "Trece"
                Case 14 : Result = "Catorce"
                Case 15 : Result = "Quince"
                Case 16 : Result = "Dieciseis"
                Case 17 : Result = "Diecisiete"
                Case 18 : Result = "Dieciocho"
                Case 19 : Result = "Diecinueve"
                Case Else
            End Select
        Else    ' Si el valor esta entre 20-99
            Select Case Val(Microsoft.VisualBasic.Left(TensText, 1))
                Case 2 : Result = "Veinte "
                Case 3 : Result = "Treinta "
                Case 4 : Result = "Cuarenta "
                Case 5 : Result = "Cincuenta "
                Case 6 : Result = "Sesenta "
                Case 7 : Result = "Setenta "
                Case 8 : Result = "Ochenta "
                Case 9 : Result = "Noventa "
                Case Else
            End Select
            Result = Result & GetDigit _
       (Microsoft.VisualBasic.Right(TensText, 1))  'Retrae el lugar
        End If
        GetTens = Result
    End Function

    '*******************************************
    ' Convierte los números de 100-999 a texto *
    '*******************************************
    Function GetHundreds(ByVal MyNumber)
        Dim Result As String
        Dim Quinien As String
        Dim Quinien2 As String

        If Val(MyNumber) = 0 Then Exit Function
        MyNumber = Microsoft.VisualBasic.Right("000" & MyNumber, 3)

        'Converte el lugar de las centenas
        Quinien2 = " Cientos "
        If Mid(MyNumber, 1, 1) <> "0" Then
            Quinien = GetDigit(Mid(MyNumber, 1, 1))
            If Quinien = "Cinco" Then
                Quinien = "Quinientos "
                Quinien2 = ""
            End If
            If Quinien = "Uno" Then
                Quinien = ""
                Quinien2 = "Ciento "
            End If
            If Quinien = "Nueve" Then
                Quinien = "Nove"
                Quinien2 = "cientos "
            End If
            If Quinien = "Siete" Then
                Quinien = "Sete"
                Quinien2 = "cientos "
            End If
            Result = Quinien & Quinien2 ' aca le agrega al numero la palabra
        End If

        'Convierte el lugar de los miles
        If Mid(MyNumber, 2, 1) <> "0" Then
            Quinien = GetTens(Mid(MyNumber, 2))
            If Pointer1 = 0 Then
                Pointer1 = 1
                Quinien = Replace(Quinien, " ", " y ")
            End If

            Result = Result & Quinien
        Else
            Quinien = GetDigit(Mid(MyNumber, 3))
            Result = Result & Quinien
        End If

        GetHundreds = Result
    End Function

    '****************
    ' Function Principal *
    '****************
    Function SpellNumber(ByVal MyNumber)
        Dim OtroNumero As String = MyNumber
        Dim Dolares, Centavos, Temp As String
        Dim DecimalPlace, Count
        Dim Place(9) As String
        Place(2) = " Mil "
        Place(3) = " Millones "
        Place(4) = " Billones "
        Place(5) = " Trillones "
        ' String representa la cantidad
        MyNumber = Trim(Str(MyNumber))
        ' el lugar de la posicion decimal ) si ninguno
        DecimalPlace = InStr(MyNumber, ".")
        'Convierte Centavos and set MyNumber a la cantidad en dolares
        If DecimalPlace > 0 Then
            OtroNumero = Microsoft.VisualBasic.Left(MyNumber, DecimalPlace - 1)
            Centavos = GetTens(Microsoft.VisualBasic.Left(Mid(MyNumber, DecimalPlace + 1) & "00", 2))
            MyNumber = Trim(Microsoft.VisualBasic.Left(MyNumber, DecimalPlace - 1))
        Else
            OtroNumero = MyNumber
        End If
        Dim enta, hacer As String
        Dim BuscaEspacio As Integer
        enta = CStr(MyNumber)
        hacer = ""
        If enta.Length = 2 And (Microsoft.VisualBasic.Right(enta, 1) = "0") Then
            hacer = "cero"
        End If
        Count = 1
        Do While MyNumber <> ""
            Temp = GetHundreds(Microsoft.VisualBasic.Right(MyNumber, 3))
            If Temp <> "" Then Dolares = Temp & Place(Count) & Dolares
            If Len(MyNumber) > 3 Then
                If Len(OtroNumero) = 4 And Microsoft.VisualBasic.Left(OtroNumero, 1) = "1" Then
                    Pointer2 = 1
                End If
                MyNumber = Microsoft.VisualBasic.Left(MyNumber, Len(MyNumber) - 3)
            Else
                MyNumber = ""
            End If
            Count = Count + 1
        Loop
        If Pointer2 = 1 Then
            Dolares = Microsoft.VisualBasic.Right(Dolares, Len(Dolares) - 3)
        End If
        If hacer = "cero" Then
            BuscaEspacio = InStr(Dolares, " ")
            Dolares = Microsoft.VisualBasic.Left(Dolares, BuscaEspacio - 1)
        End If

        Select Case Dolares
            Case ""
                Dolares = "Cero Centavos"
            Case "One"
                Dolares = "Un Pesor"
                'MsgBox("sopas")
            Case Else
                Dolares = Dolares & " Pesos"
        End Select

        Centavos = Replace(Centavos, " ", " y ")
        Select Case Centavos
            Case ""
                Centavos = " con " & Centavos & " Centavos"
            Case Else
                Centavos = " y Cero Centavos"
        End Select

        SpellNumber = Dolares & Centavos
    End Function

#End Region

    'COLOCAR LETRAS EN MAYUSCULAS
    Private Sub TxtDetMaterial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDetMaterial.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class