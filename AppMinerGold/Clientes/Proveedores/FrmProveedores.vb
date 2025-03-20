Imports System.Data.OleDb
Imports System.IO

Public Class FrmProveedores


#Region "BOTONES FUNCIONAMIENTO SUBIR LA FOTO DE LA CAMARA"

    'BOTON DE EXAMINAR
    Private Sub BtnExaminar_Click(sender As Object, e As EventArgs) Handles BtnExaminar.Click
        'ACTIVAMOS BOTONES
        Me.BtnExaminar.Enabled = False
        'LLAMO AL PROCEDIMIENTO
        CargarFoto()
    End Sub

    'CARGAR FOTO DESDE UNA UBICACION Y UBICARLA EN PICTUREBOX
    Private Sub CargarFoto()
        Dim ruta As String = "C:\FotosCompras"
        Using OpenFileDialog As New OpenFileDialog()
            With OpenFileDialog
                .CheckFileExists = True
                .ShowReadOnly = False
                .Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
                .FilterIndex = 1
                If .ShowDialog = Global.System.Windows.Forms.DialogResult.OK Then
                    ' Mostramos la imagen en el control PictureBox
                    PictureFoto.ImageLocation = .FileName
                    Me.TxtNomFoto.Text = OpenFileDialog.FileName
                End If
            End With
        End Using
    End Sub

#End Region

    'INICIO DEL FORMULARIO =================================================================================

    'INICIALIZA LOS COMPONENTES
    Public Sub New()
        ' Llamada necesaria para el diseñador.
        Me.InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    'Cargue del timpo actual en el formulario
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Me.LblFechaActual.Text = Now.ToLongDateString
    End Sub

    'CARGUE DEL FORMULARIO
    Private Sub FrmProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.PictureFoto.Refresh()
        Me.PictureFoto.Image = Nothing
        Me.PictureFoto.Image = Global.AppMinerGold.My.Resources.Foto

        'codigo mostrar hora en formulario
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Timer1.Interval = 1000  ' Un segundo
        Timer1.Start()

        Limpiar_Cajas()
        Limpiar_cajas_de_texto()

        '==================================== TAB 1
        'ubicamos el cursor
        TabControl1.SelectedIndex = 0

        'Inhabilito el tabcontrol que no utilizo
        TabControl1.Select()
        Me.TabPage1.Enabled = True

        'habilitamos la tabpage busca
        Me.TabPage1.Parent = Me.TabControl1
        Me.TabControl1.SelectedTab = TabPage1

        'habilitamos los botones 
        Me.BtnBuscar.Visible = True
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

        Me.Btnnuevo.Enabled = True
        Me.Btnnuevo.Visible = True

        Me.BtnModifica.Visible = True
        Me.BtnModifica.Enabled = False

        Me.BtnEliminar.Visible = True
        Me.BtnEliminar.Enabled = False

        Me.BtnGuardar.Enabled = False
        Me.BtnGuardar.Visible = False

        Me.BtnGuardaCambios.Enabled = False
        Me.BtnGuardaCambios.Visible = False

        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Visible = False

        Me.TabControl1.Enabled = True

        Me.TxtBuscar.Select()
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

        Me.BtnConsultaHuella.Enabled = True
        '==================================== TAB 2

        'oculatmos la tabpage pacientes
        TabPage2.Parent = Nothing

        'deshabilito los textos
        DesHabilitaTextos()

        'no permite cambiar el codigo
        CBOtipo.DropDownStyle = ComboBoxStyle.DropDownList
        'CBOciudadcl.DropDownStyle = ComboBoxStyle.DropDownList
        CBOpaiscl.DropDownStyle = ComboBoxStyle.DropDownList
        'CBOciudexp.DropDownStyle = ComboBoxStyle.DropDownList

        'conexion del combobox
        Cargar_Combo(CBOtipo, "Select DISTINCT nom_tipodocu From TipoDocumento Order By nom_tipodocu")
        Cargar_Combo(CBOciudexp, "Select DISTINCT ciudad From ciudad Order By ciudad")
        Cargar_Combo(CBOciudadcl, "Select DISTINCT ciudad From ciudad Order By ciudad")
        Cargar_Combo(CBOpaiscl, "Select DISTINCT pais From paises Order By pais")

        'formato del datatimepicker
        Me.DTPnacecl.Format = DateTimePickerFormat.Custom
        Me.DTPnacecl.CustomFormat = "dd/MM/yyyy"
        Me.DTPnacecl.Value.ToString()

        'INCIAR FECHA CON FECHA ACTUAL
        Me.DTPnacecl.Value = Now

        'Cargar los datos para el AutoComplete de los combobox de Ciudad de Expedición
        CBOciudexp.AutoCompleteCustomSource = Autocompletar()
        CBOciudexp.AutoCompleteMode = AutoCompleteMode.Suggest
        CBOciudexp.AutoCompleteSource = AutoCompleteSource.CustomSource

        'Cargar los datos para el AutoComplete de los combobox de Ciudad 
        CBOciudadcl.AutoCompleteCustomSource = Autocompletar()
        CBOciudadcl.AutoCompleteMode = AutoCompleteMode.Suggest
        CBOciudadcl.AutoCompleteSource = AutoCompleteSource.CustomSource

    End Sub


#Region "PROCEDIMIENTOS PARA FILTRAR POR NOMBRE EN EL DATAGRID"

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

    'FUNCION DE FILTRAR CEDULA DE UN DATAGRID
    Function FiltroCedula(ByVal busqueda As String) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim num As String
        num = Convert.ToInt32(TxtBuscar.Text)
        Dim da As New OleDbDataAdapter("SELECT * FROM Clientes WHERE ced_cl = " & num, Conectar.conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Clientes")
        DataGridView1.DataSource = dv
        Conectar.conn.Close()
        Return dt
    End Function

    'CAMPO TEXTO DE BUSCAR
    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        Me.BtnBuscar.Show()
    End Sub

    'VALIDA SOLO NUMEROS 
    Private Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress
        SoloNumeros(e)
    End Sub

    'FORMATEANDO LAS CELDAS DE UN DATAGRIDVIEW
    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'activo el datagrid
        Me.DataGridView1.Enabled = True

        'deshabilita el efecto visual de windows
        'ESTILO DE COLOR EN EL DATAGRID
        DataGridView1.EnableHeadersVisualStyles = False
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE LOS COLORES DE LAS CELDAS
        With Me.DataGridView1.DefaultCellStyle
            .Font = New Font("Tahoma", 8)
            .ForeColor = Color.Black
            '.BackColor = Color.Aqua
            .SelectionForeColor = Color.Beige
            '.SelectionBackColor = Color.WhiteSmoke
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DataGridView1.RowsDefaultCellStyle

            Me.DataGridView1.Columns(0).Width = 70
            Me.DataGridView1.Columns(0).HeaderText = "Id"

            Me.DataGridView1.Columns(1).Width = 100
            Me.DataGridView1.Columns(1).HeaderText = "Cédula"
            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView1.Columns(5).Width = 150
            Me.DataGridView1.Columns(5).HeaderText = "Nombre del Cliente"
            Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(6).Width = 150
            Me.DataGridView1.Columns(6).HeaderText = "Apellido del Cliente"
            Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(9).Width = 220
            Me.DataGridView1.Columns(9).HeaderText = "Dirección Personal"
            Me.DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView1.Columns(10).Width = 180
            Me.DataGridView1.Columns(10).HeaderText = "Ciudad"
            Me.DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DataGridView1.Columns("Id").Visible = False               '00
            'Me.DataGridView1.Columns("ced_cl").Visible = False           '01
            Me.DataGridView1.Columns("tipoced_cl").Visible = False       '02
            Me.DataGridView1.Columns("fechaexp_cl").Visible = False      '03
            Me.DataGridView1.Columns("ciudexp_cl").Visible = False       '04
            'Me.DataGridView1.Columns("nom_cl").Visible = False           '05
            'Me.DataGridView1.Columns("ape_cl").Visible = False           '06
            Me.DataGridView1.Columns("fechanace_cl").Visible = False     '07
            Me.DataGridView1.Columns("lugarnace_cl").Visible = False     '08
            'Me.DataGridView1.Columns("dire_cl").Visible = False          '09
            'Me.DataGridView1.Columns("ciud_cl").Visible = False          '10
            Me.DataGridView1.Columns("telf_cl").Visible = False          '11
            Me.DataGridView1.Columns("telc_cl").Visible = False          '12
            Me.DataGridView1.Columns("correo_cl").Visible = False        '13
            Me.DataGridView1.Columns("pais_cl").Visible = False          '14
            Me.DataGridView1.Columns("control_cl").Visible = False       '15
            Me.DataGridView1.Columns("fecha_creado").Visible = False     '16
            Me.DataGridView1.Columns("fecha_modifica").Visible = False   '17
            Me.DataGridView1.Columns("img").Visible = False              '18
            Me.DataGridView1.Columns("huella").Visible = False           '19
            Me.DataGridView1.Columns("rutaFoto").Visible = False          '20
        End With

    End Sub

    'EVENTO PARA CUANDO DIGITE SOBRE EL DATAGRID MUESTRE EL RESULTADO EN OTRO PANEL
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        'seleccionamo sel tab control que va utilizar
        TabControl1.SelectedIndex = 1

        TabPage2.Parent = TabControl1

        'ubicamos el cursor
        TabControl1.SelectedIndex = 2

        'desactivo el datagrid
        Me.DataGridView1.Enabled = False

        'oculatmos la tabpage busca paciente
        TabPage1.Parent = Nothing
        'TabPage1.Enabled = False

        '===============================================================================
        '*** CAMPOS CONSULTADOS DEL DATAGRIDVIEW ***
        '===============================================================================
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Me.TxtCedulacl.Text = Me.DataGridView1.Item(1, i).Value
        Me.CBOtipo.Text = Me.DataGridView1.Item(2, i).Value
        Me.DTPexpedicion.Value = Me.DataGridView1.Item(3, i).Value
        Me.CBOciudexp.Text = Me.DataGridView1.Item(4, i).Value
        Me.TxtNomcl.Text = Me.DataGridView1.Item(5, i).Value
        Me.TxtApecl.Text = Me.DataGridView1.Item(6, i).Value
        Me.DTPnacecl.Value = Me.DataGridView1.Item(7, i).Value
        Me.TxtLugarnace.Text = Me.DataGridView1.Item(8, i).Value
        Me.Txtdirecl.Text = Me.DataGridView1.Item(9, i).Value
        Me.CBOciudadcl.Text = Me.DataGridView1.Item(10, i).Value
        'Me.Txttelefijocl.Text = Me.DataGridView1.Item(11, i).Value
        Me.Txttelecelcl.Text = Me.DataGridView1.Item(12, i).Value
        Me.Txtemailcl.Text = Me.DataGridView1.Item(13, i).Value
        Me.CBOpaiscl.Text = Me.DataGridView1.Item(14, i).Value
        Me.TxtControlR.Text = Me.DataGridView1.Item(15, i).Value

        If Convert.ToString(DataGridView1.Item(20, i).Value) = String.Empty Then
            Me.PictureFoto.Image = Global.AppMinerGold.My.Resources.Resources.FotoX
        Else
            Me.TxtNomFoto.Text = Me.DataGridView1.Item(20, i).Value
            Me.PictureFoto.ImageLocation = TxtNomFoto.Text
        End If

        'Me.PictureFoto.Image = DataGridView1.CurrentRow.Cells("img").FormattedValue
        'Me.PBProCaptura.Image = DataGridView1.CurrentRow.Cells("huella").FormattedValue

        Me.TxtCedClientes.Text = Me.DataGridView1.Item(1, i).Value

        '===============================================================================
        '*** CAMPOS DE TEXTO MONTRANDO LA INFORMACION CONSULTADA ***
        '===============================================================================
        'habilitamos los botones 
        Me.Btnnuevo.Enabled = False
        Me.Btnnuevo.Visible = True
        Me.BtnGuardar.Enabled = False
        Me.BtnGuardar.Visible = False
        Me.BtnModifica.Enabled = True
        Me.BtnModifica.Visible = True
        Me.BtnGuardaCambios.Enabled = False
        Me.BtnGuardaCambios.Visible = False
        Me.BtnEliminar.Enabled = True
        Me.BtnEliminar.Visible = True
        Me.btnCancelar.Enabled = True
        Me.btnCancelar.Visible = True
        Me.BtnBuscar.Enabled = False

        'BOTONES DE LA CAMARA FOTOS
        Me.BtnExaminar.Enabled = False

    End Sub

#End Region

#Region "BOTONES"

    'BOTON DE CAPTURAR HUELLAS
    Private Sub BtnConsultaHuella_Click(sender As Object, e As EventArgs) Handles BtnConsultaHuella.Click
        FrmInicial.ShowDialog()
    End Sub

    'BOTON BUSCAR
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'verifico el campo vacio
        If Me.TxtBuscar.Text = "" Then
            MsgBox("Para hacer una Consulta debe Digitar la cedula del Proveedor.", MsgBoxStyle.Information, "AppMinerGold")
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
        Else
            'activo el datagrid
            Me.DataGridView1.Enabled = True

            'lleno los datos al datagrid
            If FiltroCedula(Me.TxtBuscar.Text).Rows.Count > 0 Then
                DataGridView1.DataSource = FiltroCedula(Me.TxtBuscar.Text)

                'deshabilito el boton nuevo
                Me.Btnnuevo.Enabled = False

                'Inhabilito el campo de texto
                Me.TxtBuscar.Enabled = False
                Me.BtnBuscar.Enabled = False
                Me.BtnConsultaHuella.Enabled = False

            Else
                MsgBox("La Cédula que Digíto No existe en la Base de Datos, Digite una Nueva.!", vbInformation, "AppMinerGold")
                Me.TxtBuscar.Text = ""
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Focus()
            End If
        End If
    End Sub

    'BOTON LIMPIAR
    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click

        'ubicamos el cursor
        TabControl1.SelectedIndex = 0

        'limpio el datagrid
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        'ubico el cursor
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Text = ""
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

        'habilitamos el boton
        Me.BtnBuscar.Enabled = True
        Me.Btnnuevo.Enabled = True
        Me.BtnGuardar.Enabled = False
        Me.BtnModifica.Enabled = False
        Me.BtnGuardaCambios.Enabled = False
        Me.BtnEliminar.Enabled = False
        Me.btnCancelar.Enabled = False

        Me.BtnConsultaHuella.Enabled = True

    End Sub

    'BOTON DE CONSULTA DE CLIENTES
    Private Sub BtnConsu_Click(sender As Object, e As EventArgs) Handles BtnConsu.Click
        FrmFiltroC.ShowDialog()
    End Sub

    'BOTON NUEVO
    Private Sub Btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnnuevo.Click

        Refresh()

        'PICTUREBOX FOTO
        Me.PictureFoto.Visible = True
        Me.PictureFoto.Enabled = False
        Me.PictureFoto.Image = Nothing
        Me.PictureFoto.Refresh()
        Me.BtnExaminar.Enabled = True

        'seleccionamo tab control que va utiliza
        'activo el tabpage2 datos cliente nuevo 
        TabPage2.Parent = TabControl1

        'selecciono la pagina a trabajar
        TabControl1.SelectedTab = TabPage2
        Me.GroupBox2.Select()
        Me.TxtCedulacl.Select()
        Me.TxtCedulacl.Focus()

        'Inhabilito el tabcontrol que no utilizo
        TabControl1.Select()
        Me.TabPage1.Parent = Nothing
        Me.TabPage1.Enabled = False

        'ejecutamos contador
        ContadorControl()

        'habilito los textos paciente
        Me.TxtControlR.Enabled = False
        Me.TxtBuscar.Enabled = False

        Me.TxtCedulacl.Enabled = True
        Me.CBOtipo.Enabled = True
        Me.DTPexpedicion.Enabled = True
        Me.CBOciudexp.Enabled = True
        Me.TxtNomcl.Enabled = True
        Me.TxtApecl.Enabled = True
        Me.DTPnacecl.Enabled = True
        Me.TxtLugarnace.Enabled = True
        Me.Txtdirecl.Enabled = True
        Me.CBOciudadcl.Enabled = True
        Me.Txttelefijocl.Enabled = True
        Me.Txttelecelcl.Enabled = True
        Me.Txtemailcl.Enabled = True
        Me.CBOpaiscl.Enabled = True

        Me.CBOciudadcl.Text = "SELECCIONE"
        Me.CBOciudexp.Text = "SELECCIONE"

        Me.DTPexpedicion.Value = Date.Now
        Me.DTPnacecl.Value = Date.Now

        'habilitamos los botones 
        Me.Btnnuevo.Enabled = False
        Me.Btnnuevo.Visible = False

        Me.BtnGuardar.Enabled = True
        Me.BtnGuardar.Visible = True

        Me.BtnModifica.Enabled = True
        Me.BtnModifica.Visible = True

        Me.BtnGuardaCambios.Enabled = False
        Me.BtnGuardaCambios.Visible = True

        Me.BtnEliminar.Enabled = False
        Me.BtnEliminar.Visible = True

        Me.btnCancelar.Enabled = True
        Me.btnCancelar.Visible = True

        Me.BtnBuscar.Enabled = False

        'ubicamos el cursor
        Me.TxtCedulacl.Select()
        Me.TxtCedulacl.Focus()

    End Sub

    'BOTON CANCELAR
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        'lipio las cajas de texto
        Limpiar_cajas_de_texto()

        'ubico el tabcontrol
        TabControl1.SelectedIndex = 0

        DataGridView1.ClearSelection()
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()

        'deshabilito los campos de texto
        DesHabilitaTextos()

        'limpio el campo de texto
        Me.TxtBuscar.Text = ""

        'ubico el cursor
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True
        Me.Btnnuevo.Visible = True
        Me.Btnnuevo.Enabled = True
        Me.BtnModifica.Visible = True
        Me.BtnModifica.Enabled = False
        Me.BtnEliminar.Visible = True
        Me.BtnEliminar.Enabled = False

        'cierro conexion
        Conectar.conn.Close()

    End Sub

#End Region

#Region "PROCEDIMIENTOS PARA EL BOTON ELIMINAR DATOS EN LA BASE DE DATOS"

    'BOTON ELIMINAR
    Dim comand As New OleDb.OleDbCommand
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim respuesta As Byte
        Dim adaptador As New OleDb.OleDbDataAdapter
        Dim registros As New DataSet

        '':::Creamos nuestras variables para almacenar los datos a ingresar
        Dim control As Integer = CInt(TxtControlR.Text)

        Try
            'hacemos la consulta
            respuesta = CByte(MsgBox("¿Esta seguro de Eliminar este Registro?", MsgBoxStyle.YesNo, "AppMinerGold"))

            'verificamos la respuesta
            If respuesta = vbYes Then
                Dim fechaM As Date = CDate(Format(Date.Now.Date))
                Dim fechaexp As Date = CDate(Format(Date.Now.Date))
                Dim fechanace As Date = CDate(Format(Date.Now.Date))

                'VARIABLE DE ELIMINACION
                Dim cedula As Double = Me.TxtCedulacl.Text
                Dim tipoced As String = Me.CBOtipo.Text
                Dim ciudexp As String = Me.CBOciudexp.Text
                Dim nombres As String = Me.TxtNomcl.Text
                Dim apellidos As String = Me.TxtApecl.Text
                Dim lugarnace As String = Me.TxtLugarnace.Text
                Dim dire As String = Me.Txtdirecl.Text
                Dim ciudad As String = Me.CBOciudadcl.Text
                Dim telecel As String = Me.Txttelecelcl.Text
                Dim correo As String = Me.Txtemailcl.Text
                Dim pais As String = Me.CBOpaiscl.Text

                cedula = 0
                tipoced = "Seleccione"
                ciudexp = "ANULADO"
                nombres = "ANULADO"
                apellidos = "ANULADO"
                lugarnace = ""
                dire = "ANULADO"
                ciudad = "ANULADO"
                telecel = ""
                correo = ""
                pais = "Seleccione"

                Me.TxtCedulacl.Text = cedula
                Me.CBOtipo.Text = tipoced
                Me.TxtNomcl.Text = nombres
                Me.TxtApecl.Text = apellidos
                Me.TxtLugarnace.Text = lugarnace
                Me.Txtdirecl.Text = dire
                Me.CBOciudadcl.Text = ciudad
                Me.Txttelecelcl.Text = telecel
                Me.Txtemailcl.Text = correo
                Me.CBOpaiscl.Text = pais

                conn.Open()

                Dim ConnString As String = cs

                Dim SqlClientes As String = "UPDATE Clientes SET ced_cl = '" & cedula & "'," &
                                                         "tipoced_cl = '" & tipoced & "'," &
                                                        "fechaexp_cl = '" & fechaexp & "'," &
                                                         "ciudexp_cl = '" & ciudexp & "'," &
                                                             "nom_cl = '" & nombres & "', " &
                                                             "ape_cl = '" & apellidos & "'," &
                                                       "fechanace_cl = '" & fechanace & "'," &
                                                       "lugarnace_cl = '" & lugarnace & "'," &
                                                            "dire_cl = '" & dire & "'," &
                                                            "ciud_cl = '" & ciudad & "'," &
                                                            "telc_cl = '" & telecel & "'," &
                                                          "correo_cl = '" & correo & "'," &
                                                            "pais_cl = '" & pais & "'," &
                                                     "fecha_modifica = '" & fechaM & "' WHERE control_cl = " & control

                cmd = New OleDb.OleDbCommand(SqlClientes, Conectar.conn)

                cmd.ExecuteNonQuery()
                conn.Close()

                MessageBox.Show("Cliente Eliminado Exitosamente de la Base de Datos.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                '==========ELIMINA REGISTRO DE EMRESA1CLIENTES DE ACTIVIDAD
                ModiEmp1Cliente()
                '==========================================================

                'limpio los campos
                Limpiar_cajas_de_texto()

                'deshabilito los textos
                DesHabilitaTextos()

                'ubicamos el cursor
                Me.TabControl1.SelectedIndex = 0
                Me.TxtBuscar.Enabled = False
                Me.TxtBuscar.Text = ""

                Me.BtnBuscar.Enabled = False
                Me.BtnLimpiar.Enabled = False

                Me.BtnX.Select()
                Me.BtnX.Focus()

                'habilitamos los botones 
                Me.Btnnuevo.Visible = True
                Me.BtnGuardar.Visible = False
                Me.BtnModifica.Visible = True
                Me.BtnGuardaCambios.Visible = False
                Me.BtnEliminar.Visible = True
                Me.btnCancelar.Visible = False

                Me.Btnnuevo.Enabled = False
                Me.BtnGuardar.Enabled = False
                Me.BtnModifica.Enabled = False
                Me.BtnGuardaCambios.Enabled = False
                Me.BtnEliminar.Enabled = False
                Me.btnCancelar.Enabled = False
                Me.BtnConsu.Enabled = False

                'limpio el datagrid 
                DataGridView1.ClearSelection()
                DataGridView1.DataSource = Nothing
                DataGridView1.Columns.Clear()

                'ubico la pagina de futuro ingreso
                'Me.TabControl1.SelectedTab = TabPage1
                TabPage1.Parent = TabControl1
                TabControl1.SelectedIndex = 0

                TabPage2.Parent = Nothing

                'ACTIVAMOS BOTONES
                Me.PictureFoto.Visible = True
                Me.PictureFoto.Enabled = False
                Me.PictureFoto.Image = Nothing
                Me.BtnExaminar.Enabled = False

                Refresh()

                'UBICO EL CURSOR
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Focus()

                '==================================CAMBIO
                ''presentamos el mensaje 
                'MsgBox("Registro eliminado con exito de la base de datos!", MsgBoxStyle.Information, "AppMinerGold")

            Else
                'posicionamos el cursor
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Focus()
            End If
            Refresh()
        Catch ex As Exception
            MsgBox("Imposible Eliminar porque...:" & ex.Message, MsgBoxStyle.YesNo, "AppMinerGold")
        End Try
    End Sub

    'PROCEDIMIENTO PARA GUARDAR LOS CAMBIOS
    Private Sub ModiClientesEliminado()
        'fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))
        Dim fechaexp As Date = CDate(Format(Date.Now.Date))
        Dim fechanace As Date = CDate(Format(Date.Now.Date))

        cmd.CommandType = CommandType.Text
        cmd.Connection = conn

        'VARIABLE DE ELIMINACION
        Dim cedula As Double = Me.TxtCedulacl.Text
        Dim tipoced As String = Me.CBOtipo.Text
        Dim ciudexp As String = Me.CBOciudexp.Text
        Dim nombres As String = Me.TxtNomcl.Text
        Dim apellidos As String = Me.TxtApecl.Text
        Dim lugarnace As String = Me.TxtLugarnace.Text
        Dim dire As String = Me.Txtdirecl.Text
        Dim ciudad As String = Me.CBOciudadcl.Text
        Dim telecel As String = Me.Txttelecelcl.Text
        Dim correo As String = Me.Txtemailcl.Text
        Dim pais As String = Me.CBOpaiscl.Text

        cedula = "0"
        tipoced = "Seleccione"
        ciudexp = "ANULADO"
        nombres = "ANULADO"
        apellidos = "ANULADO"
        lugarnace = ""
        dire = "ANULADO"
        ciudad = "ANULADO"
        telecel = ""
        correo = ""
        pais = "Seleccione"

        Me.TxtCedulacl.Text = cedula
        Me.CBOtipo.Text = tipoced
        Me.TxtNomcl.Text = nombres
        Me.TxtApecl.Text = apellidos
        Me.TxtLugarnace.Text = lugarnace
        Me.Txtdirecl.Text = dire
        Me.CBOciudadcl.Text = ciudad
        Me.Txttelecelcl.Text = telecel
        Me.Txtemailcl.Text = correo
        Me.CBOpaiscl.Text = pais

        Try
            Dim SqlClientes As String = "UPDATE Clientes SET ced_cl = '" & cedula & "'," &
                                                 "tipoced_cl = '" & tipoced & "'," &
                                                "fechaexp_cl = '" & fechaexp & "'," &
                                                 "ciudexp_cl = '" & ciudexp & "'," &
                                                     "nom_cl = '" & nombres & "', " &
                                                     "ape_cl = '" & apellidos & "'," &
                                               "fechanace_cl = '" & fechanace & "'," &
                                               "lugarnace_cl = '" & lugarnace & "'," &
                                                    "dire_cl = '" & dire & "'," &
                                                    "ciud_cl = '" & ciudad & "'," &
                                                    "telc_cl = '" & telecel & "'," &
                                                  "correo_cl = '" & correo & "'," &
                                                    "pais_cl = '" & pais & "'," &
                                             "fecha_modifica = '" & fechaM & "' WHERE ced_cl = " & cedula

            cmd = New OleDb.OleDbCommand(SqlClientes, conn)

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Cliente Eliminado Exitosamente de la Base de Datos.", MsgBoxStyle.Information, "AppMinerGold")
            'limpio los campos
            Limpiar_cajas_de_texto()

            'deshabilito los textos
            DesHabilitaTextos()

            'ubicamos el cursor
            Me.TabControl1.SelectedIndex = 0
            Me.TxtBuscar.Enabled = True
            Me.TxtBuscar.Text = ""

            Me.BtnBuscar.Enabled = False
            Me.BtnLimpiar.Enabled = False

            Me.BtnX.Select()
            Me.BtnX.Focus()

            'habilitamos los botones 
            Me.Btnnuevo.Visible = True
            Me.BtnGuardar.Visible = False
            Me.BtnModifica.Visible = True
            Me.BtnGuardaCambios.Visible = False
            Me.BtnEliminar.Visible = True
            Me.btnCancelar.Visible = False

            Me.Btnnuevo.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnEliminar.Enabled = False
            Me.btnCancelar.Enabled = False
            Me.BtnConsu.Enabled = False

            'limpio el datagrid 
            DataGridView1.ClearSelection()
            DataGridView1.DataSource = Nothing
            DataGridView1.Columns.Clear()

            'ubico la pagina de futuro ingreso
            'Me.TabControl1.SelectedTab = TabPage1
            TabPage1.Parent = TabControl1
            TabControl1.SelectedIndex = 0

            TabPage2.Parent = Nothing

            'ACTIVAMOS BOTONES
            Me.PictureFoto.Visible = True
            Me.PictureFoto.Enabled = False
            Me.BtnExaminar.Enabled = False

            Refresh()

            'UBICO EL CURSOR
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()

        Catch ex As Exception
            MessageBox.Show("Error al Eliminar los datos, Cliente" & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)

            DesHabilitaTextos()

            'INHABILITO BOTONES
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnEliminar.Enabled = False

            'UBICO EL CURSOR
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()

        End Try

    End Sub

    'PROCEDIMIENTO PARA GUARDAR LOS CAMBIOS de la ELIMINACION DEL REGISTRO DE CLIENTES
    Private Sub ModiEmp1Cliente()
        'fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        Dim cmd As New OleDb.OleDbCommand

        'revisamos la conexin a la base de datos
        If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            Conectar.conn.Open()
        End If

        Dim Ncedula As Integer
        Ncedula = CInt(Me.TxtCedClientes.Text)

        Me.TxtCedulacl.Text = "0"

        Try
            Dim SqlEliClientes As String = "UPDATE Empresa1Cliente SET ceduem = '" & TxtCedulacl.Text & "', fecha_modifica ='" & fechaM & "' WHERE ceduem = " & Ncedula
            cmd = New OleDb.OleDbCommand(SqlEliClientes, Conectar.conn)

            'ejecutamos la consulta
            cmd.ExecuteNonQuery()
            'presentamos el mensaje 
            'MsgBox("Registro Eliminado Actualizado exitosamente, Proveedor", MsgBoxStyle.Information, "AppMinerGold")
            'cierro conexion
            Conectar.conn.Close()
            Refresh()
        Catch ex As Exception
            'muestro el mensaje de resultado
            MsgBox("Error al guardar los datos de los Cambios, proveedor" & ex.Message, MsgBoxStyle.Information, "AppMinerGold")
        End Try
        'cierro conexion
        Conectar.conn.Close()
    End Sub

#End Region

#Region "PROCEDIMIENTOS PARA EL BOTON MODIFICAR DATOS EN LA BASE DE DATOS"

    'BOTON MODIFICAR
    Private Sub BtnModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModifica.Click

        MsgBox("Va ha Modificar los Datos de la Base de Datos", MsgBoxStyle.Information, "AppMinerGold")

        'Ubicamos el panel de control
        Me.TabControl1.SelectedIndex = 1

        'activamos los campos de texto
        HabilitaTextos()

        'el  campo cedula no se cambia
        Me.TxtCedulacl.Enabled = False

        'ubicamos el cursor
        Me.TxtNomcl.Select()
        Me.TxtNomcl.Focus()

        'habilitamos los botones 
        Me.Btnnuevo.Enabled = False
        Me.Btnnuevo.Visible = True
        Me.BtnGuardar.Enabled = False
        Me.BtnGuardar.Visible = False
        Me.BtnModifica.Enabled = False
        Me.BtnModifica.Visible = False
        Me.BtnGuardaCambios.Enabled = True
        Me.BtnGuardaCambios.Visible = True
        Me.BtnEliminar.Enabled = False
        Me.BtnEliminar.Visible = True
        Me.btnCancelar.Enabled = True
        Me.btnCancelar.Visible = True

        'BOTONES DE LA CAMARA
        Me.BtnExaminar.Enabled = True

        'ACTIVO EL BOTON PARA GUARDAR LOS CAMBIOS
        Me.BtnGuardaCambios.Show()

    End Sub

    'BOTON GUARDARCAMBIOS
    Private Sub BtnGuardaCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardaCambios.Click
        Validamodifica()
    End Sub

    'FUNCION PARA VALIDAR LA MODIFICACION DE LOS DATOS 
    Private Sub Validamodifica()

        'FECHA MODIFICA
        Dim fechaM As Date
        fechaM = CDate(Format(Date.Now.Date))
        'FECHA NACIMIENTO
        Dim FechaN As String
        FechaN = CStr(DTPnacecl.Value.Date)
        'FECHA DE EXPEDICION
        Dim FechaE As String
        FechaE = CStr(DTPexpedicion.Value.Date)

        Dim cmd As New OleDbCommand

        ':::Creamos nuestras variables para almacenar los datos a ingresar
        Dim cedula As Double = Me.TxtCedulacl.Text
        Dim tipoced As String = Me.CBOtipo.Text
        Dim fechaexp As Date = Me.DTPexpedicion.Value   '::FechaE
        Dim ciudexp As String = Me.CBOciudexp.Text
        Dim nombres As String = Me.TxtNomcl.Text
        Dim apellidos As String = Me.TxtApecl.Text
        Dim fechanace As Date = Me.DTPnacecl.Value   '::FechaN
        Dim lugarnace As String = Me.TxtLugarnace.Text
        Dim dire As String = Me.Txtdirecl.Text
        Dim ciudadcl As String = Me.CBOciudadcl.Text
        Dim telef As String = Me.Txttelefijocl.Text
        Dim telecel As String = Me.Txttelecelcl.Text
        Dim correo As String = Me.Txtemailcl.Text
        Dim pais As String = Me.CBOpaiscl.Text
        Dim controlcl As String = Me.TxtControlR.Text
        Dim fechacrea As Date = Date.Now.ToShortTimeString  '::FechaC
        Dim fechamodi As Date = Date.Now.ToShortTimeString  '::FechaM
        '======
        'creo la ruta de la imgen
        Dim nomFoto As String = Me.TxtNomFoto.Text

        Try
            'los campos no deben quedar vacios
            If ValidaDatos() = False Then Exit Sub

            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            ''========================
            ':::Creamos una variable de tipo MemoryStram
            Dim MS As New MemoryStream
            ':::Guardamos en la variable MS el contenido del PictureBox
            PictureFoto.Image.Save(MS, PictureFoto.Image.RawFormat)
            ':::Pasamos a Byte nuestra imagen
            Dim Imagenes() As Byte = MS.GetBuffer
            ':::Agregamos el parametro de nuestra varible imagenes que es de tipo Byte
            cmd.Parameters.AddWithValue("@img", Imagenes)
            ''========================

            sql = "UPDATE Clientes SET control_cl='" & Me.TxtControlR.Text & "', " &
                                        "ced_cl='" & Me.TxtCedulacl.Text & "'," &
                                        "tipoced_cl='" & Me.CBOtipo.Text & "'," &
                                        "fechaexp_cl='" & FechaE & "'," &
                                        "ciudexp_cl='" & Me.CBOciudexp.Text & "'," &
                                        "nom_cl='" & Me.TxtNomcl.Text & "', " &
                                        "ape_cl='" & Me.TxtApecl.Text & "'," &
                                        "fechanace_cl='" & FechaN & "'," &
                                        "lugarnace_cl='" & Me.TxtLugarnace.Text & "'," &
                                        "dire_cl='" & Me.Txtdirecl.Text & "'," &
                                        "ciud_cl='" & Me.CBOciudadcl.Text & "'," &
                                        "telf_cl='" & Me.Txttelefijocl.Text & "'," &
                                        "telc_cl='" & Me.Txttelecelcl.Text & "'," &
                                        "correo_cl='" & Me.Txtemailcl.Text & "'," &
                                        "pais_cl='" & Me.CBOpaiscl.Text & "'," &
                                        "fecha_modifica='" & fechaM & "', img = @img, rutaFoto='" & nomFoto & "' WHERE ced_cl = " & cedula

            cmd.CommandText = sql
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Registro actualizado exitosamente", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

            MS.Close()

            Me.PictureFoto.Visible = True
            Me.PictureFoto.Enabled = False
            Me.PictureFoto.Image = Nothing
            Me.PictureFoto.Refresh()
            Me.BtnExaminar.Enabled = False

            'limpio los campos
            Limpiar_cajas_de_texto()

            'deshabilito los textos
            DesHabilitaTextos()

            'ubicamos el cursor
            Me.TabControl1.SelectedIndex = 0
            Me.TxtBuscar.Enabled = False
            Me.TxtBuscar.Text = ""

            Me.BtnBuscar.Enabled = False
            Me.BtnLimpiar.Enabled = False
            Me.BtnX.Select()
            Me.BtnX.Focus()

            'habilitamos los botones 
            Me.Btnnuevo.Visible = True
            Me.BtnGuardar.Visible = False
            Me.BtnModifica.Visible = True
            Me.BtnGuardaCambios.Visible = False
            Me.BtnEliminar.Visible = True
            Me.btnCancelar.Visible = False

            Me.Btnnuevo.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnEliminar.Enabled = False
            Me.btnCancelar.Enabled = False
            Me.BtnConsu.Enabled = False

            'limpio el datagrid 
            DataGridView1.ClearSelection()
            DataGridView1.DataSource = Nothing
            DataGridView1.Columns.Clear()

            'ubico la pagina de futuro ingreso
            'Me.TabControl1.SelectedTab = TabPage1
            TabPage1.Parent = TabControl1
            TabControl1.SelectedIndex = 0

            TabPage2.Parent = Nothing

            Refresh()

            'UBICO EL CURSOR
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()

        Catch ex As Exception
            'ENVIO EL MENSAJE DE ERROR
            MsgBox(Err.Description, MsgBoxStyle.Exclamation, "AppMinerGold")

            'UBICO EL CURSOR
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
        End Try
    End Sub

#End Region

#Region "PROCEDIMIENTOS PARA EL BOTON GUARDAR DATOS EN LA BASE DE DATOS"

    'BOTON GUARDAR
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Validar()
    End Sub

    'Valido los procedimientos de ingreso duplicados
    Private Sub Validar()
        If Me.TxtCedulacl.Text = "" Then
            MsgBox("El Campo Cédula de un Cliente no deben estar vacias! ", MsgBoxStyle.Critical, "AppMinerGold")
            Me.TxtCedulacl.Select()
            Me.TxtCedulacl.Focus()
        Else
            Dim encontro As Integer
            Dim cmd As New OleDb.OleDbCommand

            Dim numcedula As Integer
            numcedula = CInt(Me.TxtCedulacl.Text)

            encontro = 0
            'revisamos la conexion
            If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Closed Then
                conn.Open()
            End If
            'ejecutamos la consulta
            cmd = New OleDb.OleDbCommand("SELECT * FROM Clientes WHERE ced_cl = " & numcedula, conn) With {
                .Connection = conn
            }
            Dim dr As OleDb.OleDbDataReader
            dr = cmd.ExecuteReader()
            Try
                Do While dr.Read
                    encontro = 1
                Loop
            Catch ex As Exception
                MsgBox("Ha ocurrido un Error en el Ingreso de Clientes! " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
            End Try
            conn.Close()

            If (encontro = 1) Then
                MsgBox("no se puede Guardar, ya hay un registro con la misma Cédula del Cliente!", MsgBoxStyle.Exclamation, "AppMinerGold")

                'pocisiono el cursor
                Me.TxtNomcl.Select()
                Me.TxtNomcl.Focus()
            Else
                Validafoto()
            End If
        End If
    End Sub

    'Valida foto
    Private Sub Validafoto()
        If Me.PictureFoto.Image Is Nothing Then
            MsgBox("El Campo Foto no debe estar vacío! ", MsgBoxStyle.Critical, "AppMinerGold")
        Else
            AgregarDatos()
        End If
    End Sub

    'BOTON DE GUARDAR Y AGREGA LOS DATOS NUEVOS A LA BASE DE DATOS
    Private Sub AgregarDatos()

        'FECHA MODIFICA
        Dim fechaM As Date
        fechaM = CDate(Format(Date.Now.Date))
        'FECHA NACIMIENTO
        Dim FechaN As String
        FechaN = CStr(DTPnacecl.Value.Date)
        'FECHA DE EXPEDICION
        Dim FechaE As String
        FechaE = CStr(DTPexpedicion.Value.Date)
        'FECHA DE CREADO
        Dim FechaC As String
        FechaC = CDate(Format(Date.Now.Date))

        Dim cmd As New OleDb.OleDbCommand

        ':::Creamos nuestras variables para almacenar los datos a ingresar
        Dim cedula As Double = Me.TxtCedulacl.Text
        Dim tipoced As String = Me.CBOtipo.Text
        Dim fechaexp As Date = Me.DTPexpedicion.Value   '::FechaE
        Dim ciudexp As String = Me.CBOciudexp.Text
        Dim nombres As String = Me.TxtNomcl.Text
        Dim apellidos As String = Me.TxtApecl.Text
        Dim fechanace As Date = Me.DTPnacecl.Value   '::FechaN
        Dim lugarnace As String = Me.TxtLugarnace.Text
        Dim dire As String = Me.Txtdirecl.Text
        Dim ciudadcl As String = Me.CBOciudadcl.Text
        Dim telef As String = Me.Txttelefijocl.Text
        Dim telecel As String = Me.Txttelecelcl.Text
        Dim correo As String = Me.Txtemailcl.Text
        Dim pais As String = Me.CBOpaiscl.Text
        Dim controlcl As String = Me.TxtControlR.Text
        Dim fechacrea As Date = Date.Now.ToShortTimeString  '::FechaC
        Dim fechamodi As Date = Date.Now.ToShortTimeString  '::FechaM
        'creo la ruta de la imgen
        Dim nomFoto As String = Me.TxtNomFoto.Text

        Try
            'los campos no deben quedar vacios
            If ValidaDatos() = False Then Exit Sub

            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            ''=====================================================
            ':::Creamos una variable de tipo MemoryStram
            Dim MS As New MemoryStream
            ':::Guardamos en la variable MS el contenido del PictureBox
            PictureFoto.Image.Save(MS, PictureFoto.Image.RawFormat)
            ':::Pasamos a Byte nuestra imagen
            Dim Imagenes() As Byte = MS.GetBuffer
            ':::Agregamos el parametro de nuestra varible imagenes que es de tipo Byte
            cmd.Parameters.AddWithValue("@img", Imagenes)
            ''=====================================================

            sql = "INSERT INTO clientes (ced_cl, tipoced_cl, fechaexp_cl, ciudexp_cl, " &
                                    "nom_cl, ape_cl, fechanace_cl, lugarnace_cl, dire_cl, ciud_cl, " &
                                    "telf_cl, telc_cl, correo_cl, pais_cl, control_cl, fecha_creado, " &
                                    "fecha_modifica, img, rutafoto) VALUES ('" & cedula & "', '" & tipoced & "', " &
                                    "'" & FechaE & "', '" & ciudexp & "','" & nombres & "', '" & apellidos & "'," &
                                    "'" & FechaN & "', '" & lugarnace & "','" & dire & "', '" & ciudadcl & "'," &
                                    "'" & telef & "', '" & telecel & "','" & correo & "', '" & pais & "'," &
                                    "'" & controlcl & "', '" & FechaC & "'," &
                                    "'" & fechaM & "',@img ,'" & nomFoto & "')"

            cmd.CommandText = sql
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            'presentamos el mensaje 
            MessageBox.Show("Los datos se han guardado Correctamente!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

            MS.Close()

            Me.PictureFoto.Visible = True
            Me.PictureFoto.Enabled = False
            Me.PictureFoto.Image = Nothing
            Me.PictureFoto.Refresh()
            Me.BtnExaminar.Enabled = False

            Me.PictureFoto.Image = My.Resources.Foto

            'limpio los campos
            Limpiar_Cajas()

            'limpio los campos
            Limpiar_cajas_de_texto()

            'deshabilito los textos
            DesHabilitaTextos()

            'ubicamos el cursor
            Me.TabControl1.SelectedIndex = 0
            Me.TxtBuscar.Enabled = False
            Me.TxtBuscar.Text = ""

            Me.BtnBuscar.Enabled = False
            Me.BtnLimpiar.Enabled = False

            Me.BtnX.Select()
            Me.BtnX.Focus()

            'habilitamos los botones 
            Me.Btnnuevo.Visible = True
            Me.BtnGuardar.Visible = False
            Me.BtnModifica.Visible = True
            Me.BtnGuardaCambios.Visible = False
            Me.BtnEliminar.Visible = True
            Me.btnCancelar.Visible = False

            Me.Btnnuevo.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnEliminar.Enabled = False
            Me.btnCancelar.Enabled = False
            Me.BtnConsu.Enabled = False

            'limpio el datagrid 
            DataGridView1.ClearSelection()
            DataGridView1.DataSource = Nothing
            DataGridView1.Columns.Clear()

            'ubico la pagina de futuro ingreso
            Me.TabControl1.SelectedTab = TabPage1
            TabPage1.Parent = TabControl1
            TabControl1.SelectedIndex = 0

            Conectar.conn.Close()

            Me.TabControl1.Select()
            Me.TabPage1.Select()
            Me.GroupBox3.Select()
            Me.GroupBox3.Enabled = True

            TabPage2.Parent = Nothing

            'ACTIVAMOS BOTONES
            Me.BtnConsultaHuella.Enabled = False
            Me.BtnConsultaHuella.Visible = True

            Refresh()

            'UBICO EL CURSOR
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()

        Catch ex As Exception
            'ENVIO EL MENSAJE DE RROR
            MsgBox("Error al guardar los datos " & ex.Message, MsgBoxStyle.Information, "AppMinerGold")
            'UBICO EL CURSOR
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
        End Try
    End Sub

#End Region

#Region "Limpieza de Campos"

    'limpia las cajas de texto
    Private Sub Limpiar_Cajas()
        ' recorrer todos los controles del formulario indicado  
        'limpio el datagrid
        'DataGridView1.Rows.Clear()                          'para limpiarlo
        DataGridView1.DataSource = Nothing
        Me.TxtControlR.Text = ""
        Me.TxtBuscar.Text = ""

    End Sub

    'limpio los capos de texto
    Private Sub Limpiar_cajas_de_texto()

        'limpia texto cliente
        Me.TxtCedulacl.Clear()
        Me.CBOtipo.SelectedIndex = -1
        Me.DTPexpedicion.Text = Now.ToLongDateString
        Me.CBOciudexp.SelectedIndex = -1
        Me.TxtNomcl.Clear()
        Me.TxtApecl.Clear()
        Me.DTPnacecl.Text = Now.ToLongDateString
        Me.TxtLugarnace.Clear()
        Me.Txtdirecl.Clear()
        Me.CBOciudadcl.SelectedIndex = -1
        'Me.Txttelefijocl.Clear()
        Me.Txttelecelcl.Clear()
        Me.Txtemailcl.Clear()
        Me.CBOpaiscl.SelectedIndex = -1
        Me.TxtControlR.Clear()
        Me.TxtNomFoto.Clear()

    End Sub

#End Region

#Region "ActivarCamporEnter"

    'activar los campos textbox con Enter cedula
    Private Sub TxtCedulacl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCedulacl.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'activar los campos textbox con Enter tipo cedula
    Private Sub CBOtipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBOtipo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'activar los campos textbox con Enter fecha de expedicion de la cedula
    Private Sub DTPexpedicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPexpedicion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'activar los campos textbox con Enter ciudad de expedicion de la cedula
    Private Sub CBOciudexp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBOciudexp.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'activar los campos textbox con Enter Nombre 
    Private Sub TxtNomcl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNomcl.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'activar los campos textbox con Enter Apellido
    Private Sub TxtApecl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtApecl.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'activar los campos textbox con Enter Fecha Nacimiento 
    Private Sub DTPnacecl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPnacecl.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'activar los campos textbox con EnterLugar que nace
    Private Sub TxtLugarnace_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtLugarnace.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'activar los campos textbox con Enter direccion
    Private Sub Txtdirecl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtdirecl.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'activar los campos textbox con Enter ciudad
    Private Sub Cbociudadcl_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CBOciudadcl.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    ''activar los campos textbox con Enter Telefono fijo
    'Private Sub Txttelefijocl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txttelefijocl.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    'activar los campos textbox con Enter telefono celular
    Private Sub Txttelecelcl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txttelecelcl.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'activar los campos textbox con Enter correo
    Private Sub Txtemailcl_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Txtemailcl.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'activar los campos textbox con Enter pais
    Private Sub Cbopaiscl_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CBOpaiscl.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


#End Region

#Region "ValidaCamposVacios"

    'valida todos los campos no pueden estar vacios
    Private Function ValidaDatos() As Boolean
        'cliente
        If Len(Me.TxtNomcl.Text.Trim) = 0 Then
            MsgBox("El Campo Nombre no puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
            Me.TxtNomcl.Select()
            Me.TxtNomcl.Focus()
            Return False
            Exit Function
        End If

        If Len(Me.TxtApecl.Text.Trim) = 0 Then
            MsgBox("El Campo Apellido no puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
            Me.TxtApecl.Select()
            Me.TxtApecl.Focus()
            Return False
            Exit Function
        End If

        If Len(Me.TxtCedulacl.Text.Trim) = 0 Then
            MsgBox("El Campo Cédula no puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
            Me.TxtCedulacl.Select()
            Me.TxtCedulacl.Focus()
            Return False
            Exit Function
        End If

        If Len(Me.Txttelecelcl.Text.Trim) = 0 Then
            MsgBox("El Campo Teléfono no puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
            Me.Txttelecelcl.Select()
            Me.Txttelecelcl.Focus()
            Return False
            Exit Function
        End If

        If Len(Me.Txtdirecl.Text.Trim) = 0 Then
            MsgBox("El Campo Dirección no puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
            Me.Txtdirecl.Select()
            Me.Txtdirecl.Focus()
            Return False
            Exit Function
        End If

        'If Len(Me.Txtemailcl.Text.Trim) = 0 Then
        '    MsgBox("El Campo Correo no puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
        '    Me.Txtdirecl.Focus()
        '    Return False
        '    Exit Function
        'End If

        If Len(Me.TxtLugarnace.Text.Trim) = 0 Then
            MsgBox("El Campo Dirección no puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
            Me.TxtLugarnace.Select()
            Me.TxtLugarnace.Focus()
            Return False
            Exit Function
        End If

        Return True
    End Function

#End Region

#Region "Valida Solo Numeros y Letras"

    'funcion par validar los campos de texto en letras 
    Private Sub SoloTextosLetras(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNomcl.KeyPress, TxtApecl.KeyPress

        'valida los campos de letras
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            'MsgBox("Solo Digite Letras")
            MsgBox("En este Campo Solo Digite Letras", MsgBoxStyle.Critical, "AppMinerGold")
        End If

    End Sub

    'funcion par validar los campos de texto en Numeros 
    Private Sub SoloTextosNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCedulacl.KeyPress, Txttelecelcl.KeyPress
        'valida los campos de numeros
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            'MsgBox("Solo Digite Números")
            MsgBox("En este  Campo Solo Digite Números", MsgBoxStyle.Critical, "AppMinerGold")
        End If

    End Sub

#End Region

#Region "Habilita y Deshabilita los campos de texto"

    'habilita los campos de texto
    Private Sub HabilitaTextos()
        'habilito los textos
        Me.TxtCedulacl.Enabled = True
        Me.CBOtipo.Enabled = True
        Me.DTPexpedicion.Enabled = True
        Me.CBOciudexp.Enabled = True
        Me.TxtNomcl.Enabled = True
        Me.TxtApecl.Enabled = True
        Me.DTPnacecl.Enabled = True
        Me.TxtLugarnace.Enabled = True
        Me.Txtdirecl.Enabled = True
        Me.CBOciudadcl.Enabled = True
        'Me.Txttelefijocl.Enabled = True
        Me.Txttelecelcl.Enabled = True
        Me.Txtemailcl.Enabled = True
        Me.CBOpaiscl.Enabled = True
        'Me.TxtControlR.Enabled = True

    End Sub

    'deshabilito los textos
    Private Sub DesHabilitaTextos()

        'habilito los textos
        Me.TxtCedulacl.Enabled = False
        Me.CBOtipo.Enabled = False
        Me.DTPexpedicion.Enabled = False
        Me.CBOciudexp.Enabled = False
        Me.TxtNomcl.Enabled = False
        Me.TxtApecl.Enabled = False
        Me.DTPnacecl.Enabled = False
        Me.TxtLugarnace.Enabled = False
        Me.Txtdirecl.Enabled = False
        Me.CBOciudadcl.Enabled = False
        'Me.Txttelefijocl.Enabled = False
        Me.Txttelecelcl.Enabled = False
        Me.Txtemailcl.Enabled = False
        Me.CBOpaiscl.Enabled = False
        Me.TxtControlR.Enabled = False

    End Sub

#End Region

#Region "Validacion del campo texto numerico"

    'formato de texto version numerica para cedula paciente
    Private Sub TxtCedulacl_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCedulacl.Leave
        'Me.TxtCedulaPaciente.Text = Format(CType(Me.TxtCedulaPaciente.Text, Decimal), "###,###,###")
        'Me.TxtCedulaPaciente.Text = Format(CType (TxtCedulaPaciente.Text.ToString, "##,###,###"))
    End Sub

#End Region

#Region "FUNCIONES DEL FORMULARIO"

    'contador
    Function ContadorControl()
        Dim conT As String
        conT = TxtBuscar.Text
        UltimoId()
        Me.TxtControlR.Text = UltimoId()
        Return conT
    End Function

    'para encontrar el valor máximo de una columna y ultimo registro
    Public Function UltimoId() As String
        Conectar.conn.Close()
        Dim resultado As String
        resultado = 0
        Dim query As String = "SELECT MAX(control_cl)FROM Clientes"
        Dim comando As OleDbCommand
        Dim lector As OleDbDataReader
        Conectar.conn.Open()
        comando = New OleDbCommand(query, Conectar.conn)
        lector = comando.ExecuteReader
        If lector.Read Then
            resultado = Val(lector(0).ToString)
        End If
        lector.Close()
        Conectar.conn.Close()
        resultado = resultado + 1
        Return resultado
    End Function

#End Region

#Region "CONVERTIR A MINUSCULAS Y VALIDAR CORREO"

    'CONVIERTE DE MINUSCULAS A MAYUSCULAS MIENTRAS ESCRIBE
    Private Sub Txtemailcl_TextChanged(sender As Object, e As EventArgs) Handles Txtemailcl.TextChanged
        Dim I As Integer
        Me.Txtemailcl.Text = LCase(Txtemailcl.Text)
        I = Len(Txtemailcl.Text)
        Me.Txtemailcl.SelectionStart = I
    End Sub

    ''VALIDAR CORREO CON EL FORMATO CORRECTO
    'Public Function Validar_Mail(ByVal sMail As String) As Boolean
    '    ' retorna true o false   
    '    Return Regex.IsMatch(sMail, "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
    'End Function

    ''VALIDA EL TECTO ESCRITO DEL CORREO
    'Private Sub Txtemailcl_Leave(sender As Object, e As EventArgs) Handles Txtemailcl.Leave
    '    If Validar_Mail(LCase(Txtemailcl.Text)) = False Then
    '        MsgBox("Dirección de correo con formato Invalido ej: nombre@dominio.com", MessageBoxIcon.Exclamation, "AppMinerGold")
    '        Txtemailcl.Focus()
    '        Txtemailcl.SelectAll()
    '    End If
    'End Sub
#End Region

#Region "CONVERTIR A MAYUSCULAS"

    'NOMBRE
    Private Sub TxtNomcl_TextChanged(sender As Object, e As EventArgs) Handles TxtNomcl.TextChanged
        Dim I As Integer
        Me.TxtNomcl.Text = UCase(TxtNomcl.Text)
        I = Len(TxtNomcl.Text)
        Me.TxtNomcl.SelectionStart = I
    End Sub

    'APELLIDO
    Private Sub TxtApecl_TextChanged(sender As Object, e As EventArgs) Handles TxtApecl.TextChanged
        Dim I As Integer
        Me.TxtApecl.Text = UCase(TxtApecl.Text)
        I = Len(TxtApecl.Text)
        Me.TxtApecl.SelectionStart = I
    End Sub

    'LUGAR De NACIMIENTO
    Private Sub TxtLugarnace_TextChanged(sender As Object, e As EventArgs) Handles TxtLugarnace.TextChanged
        Dim I As Integer
        Me.TxtLugarnace.Text = UCase(TxtLugarnace.Text)
        I = Len(TxtLugarnace.Text)
        Me.TxtLugarnace.SelectionStart = I
    End Sub


#End Region

    Public TempRecuperada As Byte() = Nothing
    Private usuarioglb As String

    Sub Setusuarioglb(ByVal usr As String)
        usuarioglb = usr
    End Sub

    'RECUPERA HUELLA
    Private Sub Recuperar()
        Dim strConnect As String
        Dim ret As New DataSet
        Dim tamaño As Integer

        Dim numclientes As Integer = CInt(TxtBuscar.Text)

        strConnect = cs
        Dim conn As OleDbConnection = New OleDbConnection(strConnect)
        Dim Str_consulta As String = "SELECT huella FROM Clientes WHERE ced_cl = " & numclientes ''" & TxtBuscar.Text & "'"
        Dim myCommand As OleDbCommand = New OleDbCommand(Str_consulta, conn)
        Try
            conn.Open()
            Dim AdaptadorSQL As New OleDbDataAdapter
            myCommand.CommandTimeout = 600
            AdaptadorSQL.SelectCommand = myCommand
            AdaptadorSQL.Fill(ret)
            If Not (ret.Tables(0).Rows.Count = 0) Then
                TempRecuperada = ret.Tables(0).Rows(0).Item(0)
                tamaño = TempRecuperada.Length
            Else
                MsgBox("Usuario no registrado en el sistema")
            End If
            conn.Close()
        Catch SQLexc As OleDbException
            MsgBox(SQLexc.ToString)
        End Try
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
        'limpio el  picturebox
        Me.PictureFoto.Image = Nothing
        Me.PictureFoto.Refresh()
    End Sub

    Private Sub FrmProveedores_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'limpio el  picturebox
        Me.PictureFoto.Image = Nothing
        Me.PictureFoto.Refresh()
    End Sub

    Private Sub TtxceduQR_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmBuscaEvidencia.ShowDialog()
    End Sub

End Class