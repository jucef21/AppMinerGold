Imports System.Data.OleDb
Imports System.Globalization
Imports System.Threading

Public Class FrmBuscaModiCompPlatino

    'CARGUE DEL FORM
    Private Sub FrmBuscaModiCompPlatino_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-CO")
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

        'limpio los campos
        Me.TxtBuscar.Clear()

        'INCIAR EL DATAGRID LIMPIO DESPUES DE CUALQUIER CONSULTA
        'para limpiar las filas
        Try
            If DataGridView2.RowCount >= 1 Then
                For i As Integer = 0 To DataGridView2.RowCount - 1
                    DataGridView2.Rows.Remove(DataGridView2.CurrentRow)
                Next
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        'para limpiar cualquier registro internamente y desenlazar el control de la BD
        DataGridView2.DataSource = Nothing

        'UBICO EL CURSOR
        Me.Panel2.Select()
        Me.GroupBox3.Select()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()
    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE BUSCAR
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor
        If Me.TxtBuscar.Text = "" Then
            MessageBox.Show("El Campo esta vacío, Dígite un Número de Compra.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'limpio y ubico el cursor
            Me.Panel2.Select()
            Me.GroupBox3.Select()
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
        Else
            'activo el datagrid
            Me.DataGridView2.Enabled = True
            VerMetal()
            'lleno los datos al datagrid
            If FiltroDeclara(Me.TxtBuscar.Text).Rows.Count > 0 Then
                DataGridView2.DataSource = FiltroDeclara(Me.TxtBuscar.Text)
                Me.TxtCedula.Text = DataGridView2.CurrentRow.Cells(1).Value
                'desactivo el datagrid
                Me.DataGridView2.Enabled = False
                Me.TxtBuscar.Enabled = False
                Me.BtnLimpiar.Enabled = True
            Else
                MessageBox.Show("No hay datos en el numero consultado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Panel2.Select()
                Me.GroupBox3.Select()
                Me.TxtBuscar.Clear()
                Me.BtnLimpiar.Select()
                Me.BtnLimpiar.Focus()
            End If
        End If
        'manejo del cursor
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        'limpio el datagrid
        DataGridView2.ClearSelection()
        DataGridView2.DataSource = Nothing
        DataGridView2.Columns.Clear()

        'ubico el cursor
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Text = ""

        'habilito los botones
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Text = ""
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

        'UBICO EL CURSOR
        Me.Panel2.Select()
        Me.GroupBox3.Select()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    Function FiltroDeclara(ByVal busqueda As String) As DataTable
        Dim NumConse As Integer = CInt(TxtBuscar.Text)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM Declara WHERE consecutivo = " & NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Declara")
        DataGridView2.DataSource = dv
        conn.Close()
        Return dt
    End Function


    'PROCEDIMIENTO PARA VER METAL
    Private Sub VerMetal()
        Dim NumConse As Integer = CInt(TxtBuscar.Text)
        Dim dt As New DataTable
        conn.Close()
        Dim consulta As String = "SELECT * FROM Declara WHERE consecutivo = " & NumConse
        Dim cmd As New OleDbCommand(consulta, conn)
        Dim drd As OleDbDataReader
        conn.Open()
        drd = cmd.ExecuteReader
        If drd.Read Then
            MessageBox.Show("El Metal Seleccionado del Consecutivo Consultado es: " + drd.Item("metal_com"), "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Me.TxtEmpCiu.Text = drd.Item("comPlatino").ToString
        Else
            MessageBox.Show("No se encontro Metal", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        drd.Close()
        conn.Close()
    End Sub

#End Region

#Region "DATAGRIDVIEW"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS - DECLARA
    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting

        'activo el datagrid
        Me.DataGridView2.Enabled = True

        'ESTILO DE COLOR EN EL DATAGRID
        DataGridView2.EnableHeadersVisualStyles = False
        With DataGridView2.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DataGridView2.RowsDefaultCellStyle
            Me.DataGridView2.Columns(0).Width = 70
            Me.DataGridView2.Columns(0).HeaderText = "Id"
            Me.DataGridView2.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView2.Columns(1).Width = 80
            Me.DataGridView2.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DataGridView2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView2.Columns(2).Width = 240
            Me.DataGridView2.Columns(2).HeaderText = "Nombre Completo"
            Me.DataGridView2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView2.Columns(3).Width = 100
            Me.DataGridView2.Columns(3).HeaderText = "Fecha de Compra"
            Me.DataGridView2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView2.Columns(10).Width = 150
            Me.DataGridView2.Columns(10).HeaderText = "Metal"
            Me.DataGridView2.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView2.Columns(13).Width = 150
            Me.DataGridView2.Columns(13).HeaderText = "Gramos Brutos"
            Me.DataGridView2.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView2.Columns(13).DefaultCellStyle.Format = "N2"

            Me.DataGridView2.Columns(14).Width = 150
            Me.DataGridView2.Columns(14).HeaderText = "Ley"
            Me.DataGridView2.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView2.Columns(14).DefaultCellStyle.Format = "N4"

            Me.DataGridView2.Columns(15).Width = 150
            Me.DataGridView2.Columns(15).HeaderText = "Gramos Puros"
            Me.DataGridView2.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView2.Columns(15).DefaultCellStyle.Format = "N2"

            Me.DataGridView2.Columns(16).Width = 150
            Me.DataGridView2.Columns(16).HeaderText = "Precio Base"
            Me.DataGridView2.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView2.Columns(16).DefaultCellStyle.Format = "N2"

            Me.DataGridView2.Columns(17).Width = 150
            Me.DataGridView2.Columns(17).HeaderText = "Valor Gr Regalias"
            Me.DataGridView2.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView2.Columns(17).DefaultCellStyle.Format = "N2"

            Me.DataGridView2.Columns(19).Width = 150
            Me.DataGridView2.Columns(19).HeaderText = "Valor Venta"
            Me.DataGridView2.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DataGridView2.Columns(19).DefaultCellStyle.Format = "N2"

            Me.DataGridView2.Columns(29).Width = 150
            Me.DataGridView2.Columns(29).HeaderText = "Consecutivo"
            Me.DataGridView2.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DataGridView2.Columns("Id").Visible = True                '0
            Me.DataGridView2.Columns("cedu_com").Visible = True          '1
            Me.DataGridView2.Columns("nom_com").Visible = True           '2
            Me.DataGridView2.Columns("fecha_com").Visible = True         '3
            Me.DataGridView2.Columns("dire_com").Visible = False         '4
            Me.DataGridView2.Columns("telc_com").Visible = False         '5
            Me.DataGridView2.Columns("correo_com").Visible = False       '6
            Me.DataGridView2.Columns("dpto_com").Visible = False         '7
            Me.DataGridView2.Columns("rut_com").Visible = False          '8
            Me.DataGridView2.Columns("act_com").Visible = False          '9
            Me.DataGridView2.Columns("metal_com").Visible = True         '10
            Me.DataGridView2.Columns("conce_com").Visible = False        '11
            Me.DataGridView2.Columns("ciuddpto").Visible = False         '12
            Me.DataGridView2.Columns("grbrutos").Visible = True          '13
            Me.DataGridView2.Columns("ley").Visible = True               '14
            Me.DataGridView2.Columns("grpuros").Visible = True           '15
            Me.DataGridView2.Columns("base").Visible = True              '16
            Me.DataGridView2.Columns("regala").Visible = True            '17
            Me.DataGridView2.Columns("totalretef").Visible = False       '18
            Me.DataGridView2.Columns("vrventa").Visible = True           '19
            Me.DataGridView2.Columns("fechatasa").Visible = False        '20
            Me.DataGridView2.Columns("mestasa").Visible = False          '21
            Me.DataGridView2.Columns("retevalor").Visible = False        '22
            Me.DataGridView2.Columns("gp_rg").Visible = False            '23
            Me.DataGridView2.Columns("gp_base").Visible = False          '24
            Me.DataGridView2.Columns("valorgrrete").Visible = False      '25
            Me.DataGridView2.Columns("pagobare").Visible = False         '26
            Me.DataGridView2.Columns("mes_com").Visible = False          '27
            Me.DataGridView2.Columns("año_com").Visible = False          '28
            Me.DataGridView2.Columns("consecutivo").Visible = True       '29
            Me.DataGridView2.Columns("fecha_creado").Visible = False     '30
            Me.DataGridView2.Columns("fecha_modifica").Visible = False   '31
            Me.DataGridView2.Columns("letras").Visible = False           '32
            Me.DataGridView2.Columns("detallemineral").Visible = False   '33
            Me.DataGridView2.Columns("verifica").Visible = False         '34
            Me.DataGridView2.Columns("numfundi").Visible = False         '35
            Me.DataGridView2.Columns("formapago").Visible = False        '36
            Me.DataGridView2.Columns("numtarjeta").Visible = False       '37
            Me.DataGridView2.Columns("selebancos").Visible = False       '38
            Me.DataGridView2.Columns("prefijo").Visible = False          '39
            Me.DataGridView2.Columns("ConseQr").Visible = False          '40
            Me.DataGridView2.Columns("tipoop").Visible = False           '41
            Me.DataGridView2.Columns("tipodocu").Visible = False         '42
            Me.DataGridView2.Columns("comOro").Visible = False           '43
            Me.DataGridView2.Columns("comPlatino").Visible = False       '44
            Me.DataGridView2.Columns("comPlata").Visible = False         '45
            Me.DataGridView2.Columns("Ciudad").Visible = False           '46
            Me.DataGridView2.Columns("Dpto").Visible = False             '47

        End With

    End Sub

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS - DECLARA
    Private Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        SoloNumeros(e)
    End Sub

    'CIERRE DEL FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'EVENTO PARA CUANDO DIGITE SOBRE EL DATAGRID MUESTRE EL RESULTADO EN OTRO PANEL - DECLARA
    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick

        'creo la variable para preguntar sobre la atencion del paciente
        Dim resultA As DialogResult = MessageBox.Show("Desea Continuar?, Si para Continuar, No para regresar", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'CONSULTO SI DE DESEA ATENDER LA CONSULTA Y SI ES SI ABRIR FORM
        If resultA = DialogResult.Yes Then
            'desactivo el datagrid
            Me.DataGridView2.Enabled = False

            'ubicamos la la informacion a presentar en el otro formulario Consulta2
            'llamo  el form
            Dim FrmModificaComp As New FrmModiCompraPlatino
            FrmModificaComp.TxtNum_com.Text = DataGridView2.CurrentRow.Cells(29).Value
            FrmModificaComp.TextPrefijo.Text = DataGridView2.CurrentRow.Cells(39).Value

            FrmModificaComp.Txtced_cl.Text = DataGridView2.CurrentRow.Cells(1).Value
            FrmModificaComp.TxtNomApe.Text = DataGridView2.CurrentRow.Cells(2).Value
            FrmModificaComp.DTPfechaactual.Text = DataGridView2.CurrentRow.Cells(3).Value
            FrmModificaComp.TxtDireccion.Text = DataGridView2.CurrentRow.Cells(4).Value
            FrmModificaComp.TxtTelC.Text = DataGridView2.CurrentRow.Cells(5).Value
            FrmModificaComp.TxtCorreo.Text = DataGridView2.CurrentRow.Cells(6).Value
            'datos de ciudad y dpto donde reside
            FrmModificaComp.TxtCiudad.Text = DataGridView2.CurrentRow.Cells(46).Value
            FrmModificaComp.TxtDpto_cl.Text = DataGridView2.CurrentRow.Cells(7).Value

            FrmModificaComp.Txtrut.Text = DataGridView2.CurrentRow.Cells(8).Value
            FrmModificaComp.TxtAct.Text = DataGridView2.CurrentRow.Cells(9).Value

            'FrmModificaComp.CboMetal.Text = DataGridView2.CurrentRow.Cells(10).Value
            'PRUEBA DE LLENAR COMBOBOX PARA METAL
            '============================
            Dim NumConse As Integer = CInt(TxtBuscar.Text)
            Dim da As New OleDbDataAdapter("SELECT * FROM declara WHERE consecutivo = " & NumConse, conn)
            Dim df As New DataSet
            Try
                da.Fill(df, "declara")
                FrmModificaComp.CboMetal.DataSource = df.Tables("declara").DefaultView
                FrmModificaComp.CboMetal.DisplayMember = "metal_com"
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "error no controlado Metal")
            End Try
            '============================

            FrmModificaComp.TxtConcepto.Text = DataGridView2.CurrentRow.Cells(11).Value
            'datos de ciudad y dpto donde compra
            FrmModificaComp.CboCiudad.Text = DataGridView2.CurrentRow.Cells(12).Value
            FrmModificaComp.CboDpto.Text = DataGridView2.CurrentRow.Cells(47).Value

            FrmModificaComp.TxtDetMaterial.Text = DataGridView2.CurrentRow.Cells(33).Value
            FrmModificaComp.TxtGrBr.Text = Format(DataGridView2.CurrentRow.Cells(13).Value, "0.00")
            FrmModificaComp.TxtLey.Text = DataGridView2.CurrentRow.Cells(14).Value
            FrmModificaComp.TxtGrPuros.Text = Format(DataGridView2.CurrentRow.Cells(15).Value, "0.00")
            FrmModificaComp.TxtBase.Text = Format(DataGridView2.CurrentRow.Cells(16).Value, "C")

            FrmModificaComp.TxtRegalias.Text = Format(DataGridView2.CurrentRow.Cells(17).Value, "0.00")
            FrmModificaComp.TxtReteValor.Text = Format(DataGridView2.CurrentRow.Cells(18).Value, "C")
            FrmModificaComp.TxtVrVenta.Text = Format(DataGridView2.CurrentRow.Cells(19).Value, "C")
            FrmModificaComp.TxtMesRega.Text = DataGridView2.CurrentRow.Cells(21).Value
            FrmModificaComp.TxtVrRF.Text = Format(DataGridView2.CurrentRow.Cells(22).Value, "0.00")
            FrmModificaComp.TxtLblGrRg.Text = Format(CDec(DataGridView2.CurrentRow.Cells(23).Value), "C")
            FrmModificaComp.TxtLblpago.Text = Format(CDec(DataGridView2.CurrentRow.Cells(24).Value), "C")
            FrmModificaComp.Txtvrrfgr.Text = Format(CDec(DataGridView2.CurrentRow.Cells(25).Value), "C")
            FrmModificaComp.TxtBarequero.Text = Format(CDec(DataGridView2.CurrentRow.Cells(26).Value), "C")

            'FrmModificaComp.CboMes.Text = DataGridView2.CurrentRow.Cells(27).Value
            'PRUEBA DE LLENAR COMBOBOX PARA MES
            '============================
            Dim NumConsem As Integer = CInt(TxtBuscar.Text)
            Dim dam As New OleDbDataAdapter("SELECT * FROM declara WHERE consecutivo = " & NumConsem, conn)
            Dim dfm As New DataSet
            Try
                dam.Fill(dfm, "declara")
                FrmModificaComp.CboMes.DataSource = dfm.Tables("declara").DefaultView
                FrmModificaComp.CboMes.DisplayMember = "mes_com"
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "error no controlado Mes")
            End Try
            '============================

            'FrmModificaComp.CboAño.Text = DataGridView2.CurrentRow.Cells(28).Value
            'PRUEBA DE LLENAR COMBOBOX PARA AÑO
            '============================
            Dim NumConsea As Integer = CInt(TxtBuscar.Text)
            Dim daa As New OleDbDataAdapter("SELECT * FROM declara WHERE consecutivo = " & NumConsea, conn)
            Dim dfa As New DataSet
            Try
                daa.Fill(dfa, "declara")
                FrmModificaComp.CboAño.DataSource = dfa.Tables("declara").DefaultView
                FrmModificaComp.CboAño.DisplayMember = "año_com"
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "error no controlado Año")
            End Try
            '============================

            'FrmModificaComp.CboFormaPago.Text = DataGridView2.CurrentRow.Cells(36).Value
            'PRUEBA DE LLENAR COMBOBOX PARA FORMA DE PAGO
            '============================
            Dim NumConsef As Integer = CInt(TxtBuscar.Text)
            Dim daf As New OleDbDataAdapter("SELECT * FROM declara WHERE consecutivo = " & NumConsef, conn)
            Dim dff As New DataSet
            Try
                daf.Fill(dff, "declara")
                FrmModificaComp.CboFormaPago.DataSource = dff.Tables("declara").DefaultView
                FrmModificaComp.CboFormaPago.DisplayMember = "formapago"
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "error no controlado Forma Pago")
            End Try
            '============================

            FrmModificaComp.TxtNumTarjeta.Text = DataGridView2.CurrentRow.Cells(37).Value

            'FrmModificaComp.CboBancos.Text = DataGridView2.CurrentRow.Cells(38).Value
            'PRUEBA DE LLENAR COMBOBOX PARA BANCO
            '============================
            Dim NumConseb As Integer = CInt(TxtBuscar.Text)
            Dim dab As New OleDbDataAdapter("SELECT * FROM declara WHERE consecutivo = " & NumConseb, conn)
            Dim dfb As New DataSet
            Try
                dab.Fill(dfb, "declara")
                FrmModificaComp.CboBancos.DataSource = dfb.Tables("declara").DefaultView
                FrmModificaComp.CboBancos.DisplayMember = "selebancos"
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "error no controlado Forma Pago")
            End Try
            '============================

            FrmModificaComp.TxtNomQr.Text = DataGridView2.CurrentRow.Cells(40).Value

            FrmModificaComp.TxtNumTarjeta.Enabled = False
            FrmModificaComp.CboBancos.Enabled = False

            'Envio el numero de docuemnto buscado al reporte
            FrmModificaComp.TxtNum_com.Text = TxtBuscar.Text
            FrmModificaComp.Txtced_cl.Text = Me.TxtCedula.Text

            FrmModificaComp.ShowDialog()

            'cierro la forma actual
            Me.Close()
        Else
            'ubico el cursor para definir el paciente que va atender
            Me.TxtBuscar.Focus()
        End If

        Me.BtnBuscar.Enabled = False

    End Sub

#End Region

End Class