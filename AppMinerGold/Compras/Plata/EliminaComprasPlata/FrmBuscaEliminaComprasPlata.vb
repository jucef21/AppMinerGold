Imports System.Data.OleDb

Public Class FrmBuscaEliminaComprasPlata

    'CARGUE DEL FORMULARIO
    Private Sub FrmBuscaEliminaComprasPlata_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

        'limpio los campos
        Me.TxtBuscar.Clear()

        'UBICO EL CURSOR
        Me.GroupBox3.Select()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

        'INCIAR EL DATAGRID LIMPIO DESPUES DE CUALQUIER CONSULTA
        'para limpiar las filas
        Try
            If DataGridView1.RowCount >= 1 Then
                For i As Integer = 0 To DataGridView1.RowCount - 1
                    DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
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
        DataGridView1.DataSource = Nothing

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE BUSCAR
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        If Me.TxtBuscar.Text = "" Then
            MsgBox("No se encontro ningún Registro de Ingreso, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")
            'limpio y ubico el cursor
            Me.Panel2.Select()
            Me.GroupBox3.Select()
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Enabled = True
            Me.TxtBuscar.Clear()
            Me.TxtBuscar.Focus()
        Else
            'activo el datagrid
            Me.DataGridView1.Enabled = True
            'lleno los datos al datagrid
            If FiltroDeclara(Me.TxtBuscar.Text).Rows.Count > 0 Then
                'manejo del cursor
                Me.Cursor = Cursors.WaitCursor
                DataGridView1.DataSource = FiltroDeclara(Me.TxtBuscar.Text)
                'deshabilito el boton nuevo
                Me.TxtBuscar.Enabled = False
                Me.BtnBuscar.Enabled = False
                Me.BtnLimpiar.Enabled = True

                'Envio el numero de docuemnto buscado al reporte
                FrmEliminaCompraPlata.TxtNum_com.Text = TxtBuscar.Text

                'ubicamos la la informacion a presentar en el otro formulario Consulta2
                Datos()

                'llamo  el form
                FrmEliminaCompraPlata.ShowDialog()

                'limpio el datagrid
                DataGridView1.ClearSelection()
                DataGridView1.DataSource = Nothing
                DataGridView1.Columns.Clear()
            Else
                MessageBox.Show("El Consecutivo Consultado No Existe!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtBuscar.Text = ""
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Focus()
                'habilito los botones
                Me.BtnBuscar.Enabled = True
                Me.BtnLimpiar.Enabled = True

                'limpio el datagrid
                DataGridView1.ClearSelection()
                DataGridView1.DataSource = Nothing
                DataGridView1.Columns.Clear()
            End If
            'manejo del cursor
            Me.Cursor = Cursors.Default
        End If
    End Sub

    'BOTON DE LIMPIAR
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        'ubico el cursor
        Me.Panel2.Select()
        Me.GroupBox3.Select()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Clear()
        Me.TxtBuscar.Focus()

        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

    End Sub


#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    Function FiltroDeclara(ByVal busqueda As String) As DataTable
        Dim NumConse As Integer = CInt(TxtBuscar.Text)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim Anu As String = "ANULADO"
        Dim da As New OleDbDataAdapter("SELECT * FROM Declara WHERE nom_com <> '" & Anu & "' AND consecutivo = " & NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Declara")
        DataGridView1.DataSource = dv
        Return dt
    End Function

    Private Sub Datos()
        'DATOS DEL CLIENTES
        FrmEliminaCompraPlata.TxtNum_com.Text = DataGridView1.CurrentRow.Cells(29).Value
        FrmEliminaCompraPlata.Txtced_cl.Text = DataGridView1.CurrentRow.Cells(1).Value
        FrmEliminaCompraPlata.TxtNomApe.Text = DataGridView1.CurrentRow.Cells(2).Value
        FrmEliminaCompraPlata.DTPfechaactual.Text = DataGridView1.CurrentRow.Cells(3).Value
        FrmEliminaCompraPlata.TxtDireccion.Text = DataGridView1.CurrentRow.Cells(4).Value
        FrmEliminaCompraPlata.TxtTelC.Text = DataGridView1.CurrentRow.Cells(5).Value
        FrmEliminaCompraPlata.TxtCorreo.Text = DataGridView1.CurrentRow.Cells(6).Value
        FrmEliminaCompraPlata.TxtCiudadReside.Text = DataGridView1.CurrentRow.Cells(45).Value
        FrmEliminaCompraPlata.TxtDpto_cl.Text = DataGridView1.CurrentRow.Cells(7).Value
        FrmEliminaCompraPlata.Txtrut.Text = DataGridView1.CurrentRow.Cells(8).Value
        FrmEliminaCompraPlata.TxtAct.Text = DataGridView1.CurrentRow.Cells(9).Value
        FrmEliminaCompraPlata.TxtMaterial.Text = DataGridView1.CurrentRow.Cells(10).Value
        FrmEliminaCompraPlata.TxtConcepto.Text = DataGridView1.CurrentRow.Cells(11).Value
        FrmEliminaCompraPlata.TxtCiudadCompra.Text = DataGridView1.CurrentRow.Cells(45).Value
        FrmEliminaCompraPlata.TxtDptocompra.Text = DataGridView1.CurrentRow.Cells(46).Value
        FrmEliminaCompraPlata.TxtDetMaterial.Text = DataGridView1.CurrentRow.Cells(33).Value

        FrmEliminaCompraPlata.TxtGrBr.Text = Format(DataGridView1.CurrentRow.Cells(13).Value, "0.00")
        FrmEliminaCompraPlata.TxtLey.Text = DataGridView1.CurrentRow.Cells(14).Value
        FrmEliminaCompraPlata.TxtGrPuros.Text = Format(DataGridView1.CurrentRow.Cells(15).Value, "0.00")

        FrmEliminaCompraPlata.TxtBase.Text = Format(DataGridView1.CurrentRow.Cells(16).Value, "C")
        FrmEliminaCompraPlata.TxtRegalias.Text = Format(DataGridView1.CurrentRow.Cells(17).Value, "0.00")
        FrmEliminaCompraPlata.TxtVrVenta.Text = Format(DataGridView1.CurrentRow.Cells(19).Value, "C")
        FrmEliminaCompraPlata.TxtMesRega.Text = DataGridView1.CurrentRow.Cells(21).Value
        FrmEliminaCompraPlata.TxtLblGrRg.Text = Format(DataGridView1.CurrentRow.Cells(23).Value, "C")
        FrmEliminaCompraPlata.TxtLblpago.Text = Format(DataGridView1.CurrentRow.Cells(24).Value, "C")
        FrmEliminaCompraPlata.TxtBarequero.Text = Format(DataGridView1.CurrentRow.Cells(26).Value, "C")

        FrmEliminaCompraPlata.TxtMes.Text = DataGridView1.CurrentRow.Cells(27).Value
        FrmEliminaCompraPlata.TxtAño.Text = DataGridView1.CurrentRow.Cells(28).Value

    End Sub

#End Region

#Region "DATAGRIDVIEW"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS - DECLARA
    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

        'activo el datagrid
        Me.DataGridView1.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DataGridView1.EnableHeadersVisualStyles = False
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DataGridView1.RowsDefaultCellStyle
            Me.DataGridView1.Columns(0).Width = 70
            Me.DataGridView1.Columns(0).HeaderText = "Id"
            Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(1).Width = 80
            Me.DataGridView1.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(2).Width = 240
            Me.DataGridView1.Columns(2).HeaderText = "Nombre Completo"
            Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(3).Width = 100
            Me.DataGridView1.Columns(3).HeaderText = "Fecha de Compra"
            Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DataGridView1.Columns(29).Width = 150
            Me.DataGridView1.Columns(29).HeaderText = "Consecutivo"
            Me.DataGridView1.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DataGridView2.Columns("Id").Visible = False              '0
            'Me.DataGridView2.Columns("cedu_com").Visible = False        '1
            'Me.DataGridView2.Columns("nom_com").Visible = False         '2
            'Me.DataGridView2.Columns("fecha_com").Visible = False       '3
            Me.DataGridView1.Columns("dire_com").Visible = False         '4
            Me.DataGridView1.Columns("telc_com").Visible = False         '5
            Me.DataGridView1.Columns("correo_com").Visible = False       '6
            Me.DataGridView1.Columns("dpto_com").Visible = False         '7
            Me.DataGridView1.Columns("rut_com").Visible = False          '8
            Me.DataGridView1.Columns("act_com").Visible = False          '9
            Me.DataGridView1.Columns("metal_com").Visible = False       '10
            Me.DataGridView1.Columns("conce_com").Visible = False       '11
            Me.DataGridView1.Columns("ciuddpto").Visible = False        '12
            Me.DataGridView1.Columns("grbrutos").Visible = False        '13
            Me.DataGridView1.Columns("ley").Visible = False             '14
            Me.DataGridView1.Columns("grpuros").Visible = False         '15
            Me.DataGridView1.Columns("base").Visible = False            '16
            Me.DataGridView1.Columns("regala").Visible = False          '17
            Me.DataGridView1.Columns("totalretef").Visible = False      '18
            Me.DataGridView1.Columns("vrventa").Visible = False         '19
            Me.DataGridView1.Columns("fechatasa").Visible = False       '20
            Me.DataGridView1.Columns("mestasa").Visible = False         '21
            Me.DataGridView1.Columns("retevalor").Visible = False       '22
            Me.DataGridView1.Columns("gp_rg").Visible = False           '23
            Me.DataGridView1.Columns("gp_base").Visible = False         '24
            Me.DataGridView1.Columns("valorgrrete").Visible = False     '25
            Me.DataGridView1.Columns("pagobare").Visible = False        '26
            Me.DataGridView1.Columns("mes_com").Visible = False         '27
            Me.DataGridView1.Columns("año_com").Visible = False         '28
            'Me.DataGridView1.Columns("consecutivo").Visible = False    '29
            Me.DataGridView1.Columns("fecha_creado").Visible = False    '30
            Me.DataGridView1.Columns("fecha_modifica").Visible = False  '31
            Me.DataGridView1.Columns("letras").Visible = False          '32
            Me.DataGridView1.Columns("detallemineral").Visible = False  '33
            Me.DataGridView1.Columns("verifica").Visible = False         '34
            Me.DataGridView1.Columns("numfundi").Visible = False         '35
            Me.DataGridView1.Columns("formapago").Visible = False        '36
            Me.DataGridView1.Columns("numtarjeta").Visible = False       '37
            Me.DataGridView1.Columns("selebancos").Visible = False       '38
            Me.DataGridView1.Columns("prefijo").Visible = False          '39
            Me.DataGridView1.Columns("ConseQr").Visible = False          '40
            Me.DataGridView1.Columns("tipoop").Visible = False           '41
            Me.DataGridView1.Columns("tipodocu").Visible = False         '42
            Me.DataGridView1.Columns("comOro").Visible = False           '43
            Me.DataGridView1.Columns("comPlatino").Visible = False       '44
            Me.DataGridView1.Columns("comPlata").Visible = False         '45
            Me.DataGridView1.Columns("Ciudad").Visible = False           '46
            Me.DataGridView1.Columns("Dpto").Visible = False             '47

        End With

    End Sub

    Private Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        SoloNumeros(e)
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    ''EVENTO PARA CUANDO DIGITE SOBRE EL DATAGRID MUESTRE EL RESULTADO EN OTRO PANEL - DECLARA
    'Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
    '    'DATOS DEL CLIENTES
    '    FrmEliminaCompraPlatino.TxtNum_com.Text = DataGridView2.CurrentRow.Cells(29).Value
    '    FrmEliminaCompraPlatino.Txtced_cl.Text = DataGridView2.CurrentRow.Cells(1).Value
    '    FrmEliminaCompraPlatino.TxtNomApe.Text = DataGridView2.CurrentRow.Cells(2).Value
    '    FrmEliminaCompraPlatino.DTPfechaactual.Text = DataGridView2.CurrentRow.Cells(3).Value
    '    FrmEliminaCompraPlatino.TxtDireccion.Text = DataGridView2.CurrentRow.Cells(4).Value
    '    FrmEliminaCompraPlatino.TxtTelC.Text = DataGridView2.CurrentRow.Cells(5).Value
    '    FrmEliminaCompraPlatino.TxtCorreo.Text = DataGridView2.CurrentRow.Cells(6).Value
    '    FrmEliminaCompraPlatino.TxtDpto.Text = DataGridView2.CurrentRow.Cells(7).Value
    '    FrmEliminaCompraPlatino.Txtrut.Text = DataGridView2.CurrentRow.Cells(8).Value
    '    FrmEliminaCompraPlatino.TxtAct.Text = DataGridView2.CurrentRow.Cells(9).Value
    '    FrmEliminaCompraPlatino.CboMetal.Text = DataGridView2.CurrentRow.Cells(10).Value
    '    FrmEliminaCompraPlatino.TxtConcepto.Text = DataGridView2.CurrentRow.Cells(11).Value
    '    FrmEliminaCompraPlatino.CboCiudDpto.Text = DataGridView2.CurrentRow.Cells(12).Value
    '    FrmEliminaCompraPlatino.TxtDetMaterial.Text = DataGridView2.CurrentRow.Cells(33).Value
    '    FrmEliminaCompraPlatino.TxtGrBr.Text = DataGridView2.CurrentRow.Cells(13).Value
    '    FrmEliminaCompraPlatino.TxtLey.Text = DataGridView2.CurrentRow.Cells(14).Value
    '    FrmEliminaCompraPlatino.TxtGrPuros.Text = DataGridView2.CurrentRow.Cells(15).Value
    '    FrmEliminaCompraPlatino.TxtBase.Text = DataGridView2.CurrentRow.Cells(16).Value
    '    FrmEliminaCompraPlatino.TxtRegalias.Text = DataGridView2.CurrentRow.Cells(17).Value
    '    FrmEliminaCompraPlatino.TxtReteValor.Text = DataGridView2.CurrentRow.Cells(18).Value
    '    FrmEliminaCompraPlatino.TxtVrVenta.Text = DataGridView2.CurrentRow.Cells(19).Value
    '    FrmEliminaCompraPlatino.TxtMesRega.Text = DataGridView2.CurrentRow.Cells(21).Value
    '    FrmEliminaCompraPlatino.TxtVrRF.Text = DataGridView2.CurrentRow.Cells(22).Value
    '    FrmEliminaCompraPlatino.TxtLblGrRg.Text = DataGridView2.CurrentRow.Cells(23).Value
    '    FrmEliminaCompraPlatino.TxtLblpago.Text = DataGridView2.CurrentRow.Cells(24).Value
    '    FrmEliminaCompraPlatino.Txtvrrfgr.Text = DataGridView2.CurrentRow.Cells(25).Value
    '    FrmEliminaCompraPlatino.TxtBarequero.Text = DataGridView2.CurrentRow.Cells(26).Value
    '    FrmEliminaCompraPlatino.CboMes.Text = DataGridView2.CurrentRow.Cells(27).Value
    '    FrmEliminaCompraPlatino.CboAño.Text = DataGridView2.CurrentRow.Cells(28).Value

    '    'creo la variable para preguntar sobre la atencion del paciente
    '    Dim resultA As DialogResult = MessageBox.Show("Desea Continuar?, Si para Continuar, No para regresar", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '    'CONSULTO SI DE DESEA ATENDER LA CONSULTA Y SI ES SI ABRIR FORM
    '    If resultA = DialogResult.Yes Then
    '        'desactivo el datagrid
    '        Me.DataGridView2.Enabled = False
    '        'ubicamos la la informacion a presentar en el otro formulario Consulta2
    '        ModuleFrm.Nom_consulta = FrmEliminaCompraPlatino.TextBox5.Text
    '        ModuleFrm.ced_consulta = FrmEliminaCompraPlatino.TextBox2.Text
    '        'ModuleFrm.Direccion = FrmEliminaCompraPlatino.TxtDireccion.Text
    '        'ModuleFrm.Ciudad = FrmEliminaCompraPlatino.TxtDpto.Text
    '        'ModuleFrm.TelC = FrmEliminaCompraPlatino.TxtTelC.Text
    '        'ModuleFrm.Correo = FrmEliminaCompraPlatino.TxtCorreo.Text

    '        'BuscaEm()

    '        'creo el form
    '        Dim frm1 As New FrmEliminaCompraPlatino
    '        'abro el otro formulario
    '        frm1.Show()
    '        'cierro la forma actual
    '        Me.Close()
    '    Else
    '        'ubico el cursor para definir el paciente que va atender
    '        Me.TxtBuscar.Focus()
    '    End If
    '    Me.btnSalir.Enabled = True
    '    Me.BtnBuscar.Enabled = False

    'End Sub

#End Region


End Class