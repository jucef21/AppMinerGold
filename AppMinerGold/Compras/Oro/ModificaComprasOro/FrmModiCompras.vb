Imports System.Data.OleDb
Imports System.Globalization
Imports System.Threading

Public Class FrmModiCompras

    'CARGUE DEL FORMULARIO
    Private Sub FrmModiCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-CO")
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        'LLENAMOS LOS DATOS DEL ENCABEZADO DEL CLIENTE - PANEL 1========================

        VerCiudad()

        VerPrefijo()

        ActParam()

        Dim d As DateTime = DateTime.Now
        Dim DateString As String = d.ToString("yyyyMMddHHmmss")
        TxtFecha.Text = DateString

        'LIMPIO EL CONTADOR
        'Me.TxtNum_com.Clear()
        Me.TxtCedImp.Clear()
        Me.TxtFechaTasa.Clear()
        'Me.TxtMesRega.Clear()

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

        '==========================================
        'colocamos los texbox en no editable
        Me.Panel1.Select()
        Me.Txtced_cl.Enabled = False
        Me.TxtNomApe.Enabled = False
        Me.DTPfechaactual.Enabled = False
        Me.TxtDireccion.Enabled = False
        Me.TxtTelC.Enabled = False
        Me.TxtCorreo.Enabled = False
        Me.TxtCiudad.Enabled = False
        Me.TxtDpto_cl.Enabled = False
        Me.Txtrut.Enabled = False
        Me.TxtAct.Enabled = False
        Me.TxtNomPaciente.Enabled = False
        '==========================================
        'Habilito los campos de texto
        Me.Panel6.Select()
        Me.CboMetal.Enabled = False
        Me.TxtConcepto.Enabled = False
        Me.CboCiudad.Enabled = False
        Me.CboDpto.Enabled = False
        Me.TxtDetMaterial.Enabled = False

        Me.TxtGrBr.Enabled = False
        Me.TxtLey.Enabled = False
        Me.TxtGrPuros.Enabled = False
        Me.TxtBase.Enabled = False

        Me.TxtRegalias.Enabled = False
        Me.TxtReteValor.Enabled = False
        Me.TxtVrRF.Enabled = False
        Me.TxtVrVenta.Enabled = False
        '==========================================
        Me.Panel12.Select()
        Me.CboFormaPago.Enabled = False
        Me.TxtNumTarjeta.Enabled = False
        Me.CboBancos.Enabled = False
        '==========================================
        Me.Panel8.Select()
        Me.CboMes.Enabled = False
        Me.CboAño.Enabled = False
        '==========================================

        'BOTONES
        Me.BtnModifica.Enabled = True
        Me.BtnGuardaCambios.Enabled = False

        Me.BtnCalculo.Enabled = False

        'UBICO EL CURSOR
        Me.BtnModifica.Select()
        Me.BtnModifica.Focus()

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE MODIFICAR
    Private Sub BtnModifica_Click(sender As Object, e As EventArgs) Handles BtnModifica.Click

        'Mensaje de modificar
        MessageBox.Show("Va ha Modificar los Datos de la Base de Datos", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.BtnCalculo.Enabled = True
        Me.BtnGuardaCambios.Enabled = True
        Me.BtnModifica.Enabled = False

        'Habilito los campos
        HabilitaCampos()

    End Sub

    'HABILITAR LOS CAMPOS PARA MODIFICAR
    Private Sub HabilitaCampos()
        Cargar_Combo(CboMes, "SELECT DISTINCT detalle FROM meses ORDER BY detalle")
        Cargar_Combo(CboAño, "SELECT DISTINCT detalle FROM años ORDER BY detalle")
        Cargar_Combo(CboFormaPago, "SELECT DISTINCT detalle FROM formapago ORDER BY detalle")
        Cargar_Combo(CboBancos, "SELECT DISTINCT entidad FROM bancos ORDER BY entidad")
        Cargar_Combo(CboCiudad, "SELECT DISTINCT ciudad_col FROM ciudad ORDER BY ciudad_col")
        Cargar_Combo(CboDpto, "SELECT DISTINCT departamento FROM ciudad ORDER BY departamento")

        'INHABILITO LOS CAMPOS
        Me.TextPrefijo.Enabled = False
        Me.TxtNum_com.Enabled = False

        'LIMPIO LOS CAMPOS
        'Me.TxtDetMaterial.Clear()
        'Me.TxtMesRega.Clear()

        Me.TxtGrBr.Clear()
        Me.TxtLey.Clear()
        Me.TxtGrPuros.Clear()
        Me.TxtBase.Clear()
        Me.TxtVrVenta.Clear()

        'Me.TxtRegalias.Clear()
        'Me.TxtVrRF.Clear()
        'Me.Txtvrrfgr.Clear()

        Me.TxtLblGrRg.Clear()
        Me.TxtReteValor.Clear()
        Me.TxtLblpago.Clear()
        Me.TxtBarequero.Clear()

        Me.TxtNumTarjeta.Clear()

        'HABILITO LOS CAMPOS
        Me.CboMetal.Enabled = False
        Me.TxtConcepto.Enabled = True
        Me.CboCiudad.Enabled = True
        Me.CboDpto.Enabled = True
        Me.TxtDetMaterial.Enabled = True

        Me.TxtGrBr.Enabled = True
        Me.TxtLey.Enabled = True
        Me.TxtBase.Enabled = True

        Me.CboFormaPago.Enabled = True
        Me.TxtNumTarjeta.Enabled = False
        Me.CboBancos.Enabled = False

        Me.CboMes.Enabled = True
        Me.CboAño.Enabled = True

        'ubico el cursor
        Me.Panel6.Select()
        Me.CboCiudad.Select()
        Me.CboCiudad.Focus()

    End Sub

    Public Pago As Decimal = 0
    Public PagoBarequero As Decimal = 0
    Public GrPurReg As Decimal = 0
    Public Letnum As String
    'CAMPO CANTIDAD PARA MULTIPLICAR KEY
    Private Sub BtnCalculo_Click(sender As Object, e As EventArgs) Handles BtnCalculo.Click

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

            '****INCIAMOS OPERACIONES INGRESO DE DATOS DE COMPRA
            '====================================================================================================
            '=========================== GRAMOS BRUTOS
            '====================================================================================================
            'Muestro el resultado en un Label para guardar
            Dim LabelBrutos As Decimal = CDec(If(TxtGrBr.Text.Contains(","), TxtGrBr.Text.Replace(",", "."), TxtGrBr.Text))
            LabelBrutos = Math.Round(LabelBrutos, 2)
            Me.Lblbrutos.Text = LabelBrutos.ToString()
            '====================================================================================================
            '=========================== GRAMOS PUROS ( GRAMOS BRUTOS * LEY = GRAMOS PUROS )
            '====================================================================================================
            Dim Rpuros As Decimal = CDec(If(TxtGrBr.Text.Contains(","), TxtGrBr.Text.Replace(",", "."), TxtGrBr.Text)) * CDec(If(TxtLey.Text.Contains(","), TxtLey.Text.Replace(",", "."), TxtLey.Text))
            Rpuros = Math.Round(Rpuros, 2)
            Me.TxtGrPuros.Text = Rpuros.ToString()

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
            Me.Panel12.Select()
            Me.Panel12.Focus()
            Me.CboFormaPago.Select()
            Me.CboFormaPago.Focus()

            BarQ()

        End If

    End Sub

    'BOTON DE GUADAR CAMBIOS
    Private Sub BtnGuardaCambios_Click(sender As Object, e As EventArgs) Handles BtnGuardaCambios.Click
        If TxtGrBr.Text = "" Or TxtLey.Text = "" Or TxtBase.Text = "" Then
            MessageBox.Show("En este Campo No puede estar Vacío", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            ModiCompras()

        End If
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
        If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            Conectar.conn.Close()
        End If
        Dim consulta As String = "SELECT * FROM Clientes WHERE ced_cl = " & CedUne  ''" & Txtced_cl.Text & "' "
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

        Dim consulta As String = "SELECT TOP 1 * FROM Regalias WHERE id = id ORDER BY Id DESC "
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

        Dim consulta As String = "SELECT TOP 1 * FROM Retefuente WHERE id = id ORDER BY Id DESC "
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

    'PROCEDIMIENTO PARA GUARDAR LOS CAMBIOS
    Private Sub ModiCompras()
        'fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        Dim num As Integer
        num = CInt(Me.TxtNum_com.Text)

        Try
            Dim sqlConsulta As String = "UPDATE Declara SET grbrutos = '" & Lblbrutos.Text & "',  " &
                                          "ley = '" & TxtLey.Text & "', " &
                                          "grpuros = '" & TxtGrPuros.Text & "', " &
                                          "base = '" & TxtBase.Text & "', " &
                                          "ciuddpto = '" & CboCiudad.Text & "' , " &
                                          "vrventa = '" & TxtVrVenta.Text & "', " &
                                          "gp_rg = '" & TxtLblGrRg.Text & "', " &
                                          "gp_base = '" & TxtLblpago.Text & "', " &
                                          "pagobare = '" & TxtBarequero.Text & "',  " &
                                          "mes_com = '" & CboMes.Text & "', " &
                                          "año_com =  '" & CboAño.Text & "', " &
                                          "fecha_modifica = '" & fechaM & "', " &
                                          "letras = '" & Letnum & "', " &
                                          "detallemineral = '" & TxtDetMaterial.Text & "' , " &
                                          "formapago = '" & CboFormaPago.Text & "' , " &
                                          "numtarjeta ='" & TxtNumTarjeta.Text & "' , " &
                                          "dpto ='" & CboDpto.Text & "' , " &
                                          "selebancos = '" & CboBancos.Text & "' WHERE consecutivo = " & num

            cmd = New OleDb.OleDbCommand(sqlConsulta, conn)

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            'presentamos el mensaje 
            MsgBox("Registro de Compras Actualizado exitosamente, Proveedor", MsgBoxStyle.Information, "AppMinerGold")

            'LIMPIO LOS CAMPOS
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

            Me.CboMes.SelectedIndex = -1
            Me.CboAño.SelectedIndex = -1

            Me.CboFormaPago.SelectedIndex = -1
            Me.TxtNumTarjeta.Clear()
            Me.CboBancos.SelectedIndex = -1

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

            Me.CboMes.Enabled = False
            Me.CboAño.Enabled = False

            Me.CboFormaPago.Enabled = False
            Me.TxtNumTarjeta.Enabled = False
            Me.CboBancos.Enabled = False

            'BOTONES
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False

            Me.BtnCalculo.Enabled = False

        Catch ex As Exception
            'mensaje de error del procedimiento
            MsgBox("Error: " & Err.Description)
            'muestro el mensaje de resultado
            MsgBox("Error al Guardar Cambios en los datos, Compras" & ex.Message, MsgBoxStyle.Information, "AppMinerGold")

            'LIMPIO LOS CAMPOS
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

            Me.CboMes.SelectedIndex = -1
            Me.CboAño.SelectedIndex = -1

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

            Me.CboMes.Enabled = False
            Me.CboAño.Enabled = False

            Me.CboFormaPago.Enabled = False
            Me.TxtNumTarjeta.Enabled = False
            Me.CboBancos.Enabled = False

            'BOTONES
            Me.BtnModifica.Enabled = True
            Me.BtnGuardaCambios.Enabled = False

            Me.BtnCalculo.Enabled = False
        End Try

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
    Private Sub TxtBase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBase.KeyPress
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

    'COLOCAR LETRAS EN MAYUSCULAS
    Private Sub TxtDetMaterial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDetMaterial.KeyPress
        e.KeyChar = UCase(e.KeyChar)

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
        'Me.TxtGrBr.Text = CDec(If(TxtGrBr.Text.Contains("."), TxtGrBr.Text.Replace(".", ","), TxtGrBr.Text))
    End Sub

    'FORMATO VALOR LEY
    Private Sub TxtLey_Leave(sender As Object, e As EventArgs) Handles TxtLey.Leave
        'Me.TxtLey.Text = CDec(If(TxtLey.Text.Contains("."), TxtLey.Text.Replace(".", ","), TxtLey.Text))
    End Sub

    'FORMATO VALOR BASE
    Private Sub TxtBase_LostFocus(sender As Object, e As EventArgs) Handles TxtBase.LostFocus
        Dim xvalor As Double
        xvalor = Val(Me.TxtBase.Text)
        Me.TxtBase.Text = Format(xvalor, "#,###,##0.00")

    End Sub

#End Region


End Class
