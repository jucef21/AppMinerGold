Imports System.Data.OleDb

Public Class FrmTasaBaseDiaria

    'CARGUE DEL FORMULARIO
    Private Sub FrmTasaBaseDiaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'codigo mostrar hora en formulario
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Timer1.Interval = 1000  ' Un segundo
        Timer1.Start()

        'LIMPIO TEXTBOX
        Me.TxttasaDiaria.Clear()
        Me.TxtSelecfecha.Clear()

        'formato del datatimepicker
        Me.DTPfecha.Format = DateTimePickerFormat.Custom
        Me.DTPfecha.CustomFormat = "dd/MM/yyyy"
        Me.DTPfecha.Value.ToString()

        'INCIAR FECHA CON FECHA ACTUAL
        Me.DTPfecha.Value = Now

        'Inhabilito los campos
        Me.TxttasaDiaria.Enabled = False
        Me.DTPfecha.Enabled = False
        Me.TxtSelecfecha.Enabled = False

        'botones
        Me.BtnUpdate.Visible = True
        Me.BtnUpdate.Enabled = True
        Me.BtnNuevo.Visible = True
        Me.BtnNuevo.Enabled = False
        Me.BtnGuardar.Visible = False
        Me.BtnGuardar.Enabled = False
        Me.BtnModifica.Visible = True
        Me.BtnModifica.Enabled = False
        Me.BtnGuardaCambios.Visible = False
        Me.BtnGuardaCambios.Enabled = False
        Me.BtnSalir.Enabled = True

        'ubico el cursor
        Me.TxttasaDiaria.Select()
        Me.TxttasaDiaria.Focus()

        'Dim Tasadiaria As String = 0
        'Me.TxttasaDiaria.Text = Tasadiaria

        Dim Tasadiaria As Double = 0
        Me.TxttasaDiaria.Text = Tasadiaria

    End Sub

    'Cargue del timpo actual en el formulario
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Me.LblFechaActual.Text = Now.ToLongDateString
    End Sub

    'LINK PARA CONSULTA DE VALORES
    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://www.bulliondesk.com/gold-prices/")
    End Sub

    'LINK PARA CONSULTA DE VALORES
    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://www.kitco.com/charts/livegold.html")
    End Sub

    'LINK PARA CONSULTA DE VALORES
    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("http://www.banrep.gov.co/es/tasa-cambio-del-peso-colombiano-trm")
    End Sub

    'LINK DEL BANCO DE BOGOTA
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Process.Start("https://www.bancodebogota.com/wps/portal/banco-de-bogota/bogota/investigaciones-economicas")
    End Sub

#Region "BOTONES"

    Dim TasaD As Decimal
    Dim IntVar As Double
    'BOTON DE ACTUALIZAR
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        'REVISO LA CONEXION
        If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
            Conectar.conn.Close()
        End If

        'CREO LA CONSULTA
        Dim dt As New DataTable
        Conectar.Conectarse()
        Dim consulta As String = "SELECT TOP 1 * FROM Tasadiaria ORDER BY Id DESC "
        Dim cmd As New OleDbCommand(consulta, Conectar.conn)

        TasaD = Me.TxttasaDiaria.Text
        IntVar = Convert.ToDouble(TasaD)

        Try
            Dim drd As OleDbDataReader
            'conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                'GROUPBOX 1 ======================
                TasaD = drd.Item("detalle").ToString
                Me.DTPfecha.Text = drd.Item("descri").ToString
                Me.TxtSelecfecha.Text = drd.Item("fechasele").ToString

                Me.DGVtasadiaria.Enabled = False

                'lleno los datos al datagrid
                DGVtasadiaria.DataSource = FiltroTasa()

                'botones
                Me.BtnUpdate.Visible = True
                Me.BtnUpdate.Enabled = False
                Me.BtnNuevo.Visible = True
                Me.BtnNuevo.Enabled = True
                Me.BtnGuardar.Visible = False
                Me.BtnGuardar.Enabled = False
                Me.BtnModifica.Visible = True
                Me.BtnModifica.Enabled = True
                Me.BtnGuardaCambios.Visible = False
                Me.BtnGuardaCambios.Enabled = False
                Me.BtnSalir.Enabled = True

            Else
                MsgBox("No se encontro Datos, Falta información por ingresar, Click en NUEVO ...", MsgBoxStyle.Information, "AppMinerGold")

                'botones
                Me.BtnUpdate.Visible = True
                Me.BtnUpdate.Enabled = False
                Me.BtnNuevo.Visible = True
                Me.BtnNuevo.Enabled = True
                Me.BtnGuardar.Visible = False
                Me.BtnGuardar.Enabled = False
                Me.BtnModifica.Visible = True
                Me.BtnModifica.Enabled = False
                Me.BtnGuardaCambios.Visible = False
                Me.BtnGuardaCambios.Enabled = False
                Me.BtnSalir.Enabled = True

                'ubico el cursor
                Me.TxttasaDiaria.Select()
                Me.TxttasaDiaria.Focus()

            End If

            Me.TxttasaDiaria.Text = IntVar
            Dim Rtasa As String = Microsoft.VisualBasic.Left(TasaD, 9)
            Me.TxttasaDiaria.Text = Rtasa

            drd.Close()
            Conectar.conn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            MsgBox("Falta información por ingresar", MsgBoxStyle.Information, "AppMinerGold")
            'ubico el cursor
            Me.TxttasaDiaria.Select()
            Me.TxttasaDiaria.Focus()

        End Try


    End Sub

    'BOTON NUEVO
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click

        'habilito los campos
        Me.TxttasaDiaria.Enabled = True
        Me.DTPfecha.Enabled = True
        Me.TxtSelecfecha.Enabled = False

        'limpio los campos
        Limpiacampos()

        'lleno los datos al datagrid
        Me.DGVtasadiaria.Enabled = False
        DGVtasadiaria.DataSource = FiltroTasa()

        'botones
        Me.BtnUpdate.Visible = True
        Me.BtnUpdate.Enabled = False
        Me.BtnNuevo.Visible = False
        Me.BtnNuevo.Enabled = False
        Me.BtnGuardar.Visible = True
        Me.BtnGuardar.Enabled = True
        Me.BtnModifica.Visible = True
        Me.BtnModifica.Enabled = False
        Me.BtnGuardaCambios.Visible = False
        Me.BtnGuardaCambios.Enabled = False
        Me.BtnSalir.Enabled = True

        'ubico el cursor
        Me.TxttasaDiaria.Select()
        Me.TxttasaDiaria.Focus()

    End Sub

    'BOTON GUARDAR
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        'Tasas Diaria
        If Len(Me.TxttasaDiaria.Text.Trim) = 0 Then
            MsgBox("El Campo Tasa Diaria No puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
            Me.TxttasaDiaria.Select()
            Me.TxttasaDiaria.Focus()
        Else
            'llamo elprocedimiento
            GuardarTasas()
        End If

    End Sub

    'BOTON DE MODIFICAR
    Private Sub BtnModifica_Click(sender As Object, e As EventArgs) Handles BtnModifica.Click

        'Mensaje de modificar
        MsgBox("Va ha Modificar los Datos de la Base de Datos", MsgBoxStyle.Information, "AppMinerGold")

        'Habilito los campos
        Me.TxttasaDiaria.Enabled = True
        Me.DTPfecha.Enabled = True
        Me.TxtSelecfecha.Enabled = False

        Me.TxttasaDiaria.Clear()

        Me.DGVtasadiaria.Enabled = False

        'ubico el cursor
        Me.TxttasaDiaria.Select()
        Me.TxttasaDiaria.Focus()

        'lleno los datos al datagrid
        DGVtasadiaria.DataSource = FiltroTasa()

        'botones
        Me.BtnUpdate.Visible = True
        Me.BtnUpdate.Enabled = False
        Me.BtnNuevo.Visible = True
        Me.BtnNuevo.Enabled = False
        Me.BtnGuardar.Visible = False
        Me.BtnGuardar.Enabled = False
        Me.BtnModifica.Visible = False
        Me.BtnModifica.Enabled = False
        Me.BtnGuardaCambios.Visible = True
        Me.BtnGuardaCambios.Enabled = True
        Me.BtnSalir.Enabled = True


    End Sub

    'BOTON DE GUARDA CAMBIOS
    Private Sub BtnGuardaCambios_Click(sender As Object, e As EventArgs) Handles BtnGuardaCambios.Click

        'llamo al procedimiento
        GuardaCambiosTasas()

    End Sub

    'BOTON DE REGRESAR
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
        'FrmTasas.Show()
    End Sub


#End Region

#Region "PROCEDIMIENTOS"

    'FUNCION DE FILTRAR DATOS DE TASAS
    Function FiltroTasa() As DataTable
        'conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM Tasadiaria ORDER BY id ASC", Conectar.conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Tasadiaria")
        DGVtasadiaria.DataSource = dv
        Conectar.conn.Close()
        Return dt
    End Function

    'PROCEDIMIENTO DE LIMPIAR CAMPOS
    Private Sub Limpiacampos()

        'habilito los campos
        Me.TxttasaDiaria.Clear()
        Me.TxtSelecfecha.Clear()
        Me.DTPfecha.Value = Now

    End Sub

    'PROCEDIMIENTO DE GUARDAR
    Private Sub GuardarTasas()

        Try
            'revisamos la conexion
            If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
                Conectar.conn.Open()
            End If

            'fecha seleccionada
            Dim FechaTasa As String
            FechaTasa = CStr(DTPfecha.Value.Date)

            'fecha creado
            Dim fechaC As Date = CDate(Format(Date.Now.Date))

            'fecha modifica
            Dim fechaM As Date = CDate(Format(Date.Now.Date))

            cmd.CommandType = CommandType.Text
            cmd.Connection = Conectar.conn

            sql = "INSERT INTO Tasadiaria (detalle, descri, fecha_creado, fecha_modifica, fechasele) VALUES ('" & TxttasaDiaria.Text & "', " &
                                       "'" & FechaTasa & "', '" & fechaC & "', '" & fechaM & "', '" & TxtSelecfecha.Text & "')"

            cmd.CommandText = sql

            'MsgBox(sql)

            'ejecutamos la consulta
            cmd.ExecuteNonQuery()

            MsgBox("Los datos se han guardado Correctamente!, Tasas Diarias ", MsgBoxStyle.Information, "AppMinerGold")

            'cierro conexion
            Conectar.conn.Close()

            'LIMPIO LOS CAMPOS
            Limpiacampos()

            Me.DGVtasadiaria.DataSource = Nothing

            'inhabilito los campos
            Me.TxttasaDiaria.Enabled = False
            Me.DTPfecha.Enabled = False
            Me.TxtSelecfecha.Enabled = False

            'botones
            Me.BtnUpdate.Visible = True
            Me.BtnUpdate.Enabled = False
            Me.BtnNuevo.Visible = True
            Me.BtnNuevo.Enabled = False
            Me.BtnGuardar.Visible = False
            Me.BtnGuardar.Enabled = False
            Me.BtnModifica.Visible = True
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Visible = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnSalir.Enabled = True

            'ubico el cursor
            Me.TxttasaDiaria.Select()
            Me.TxttasaDiaria.Focus()

        Catch ex As Exception

            'mensaje de error del procedimiento
            MsgBox("Error: " & Err.Description)
            'muestro el mensaje de resultado
            MsgBox("Error al guardar los datos, Tasas Diarias" & ex.Message, MsgBoxStyle.Information, "AppMinerGold")
            ''ubico la pagina de futuro ingreso

            'botones
            Me.BtnUpdate.Visible = True
            Me.BtnUpdate.Enabled = False
            Me.BtnNuevo.Visible = True
            Me.BtnNuevo.Enabled = True
            Me.BtnGuardar.Visible = False
            Me.BtnGuardar.Enabled = False
            Me.BtnModifica.Visible = True
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Visible = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnSalir.Enabled = True

            'ubico el cursor
            Me.TxttasaDiaria.Select()
            Me.TxttasaDiaria.Focus()

        End Try


    End Sub

    'PROCEDIMIENTOS DE GUARDAR MODIFICAR
    Private Sub GuardaCambiosTasas()

        'fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))

        'fecha seleccionada
        Dim FechaSele As String
        FechaSele = CStr(DTPfecha.Value.Date)

        Dim cmd As New OleDb.OleDbCommand

        'revisamos la conexin a la base de datos
        If Global.AppMinerGold.Conectar.conn.State() = Global.System.Data.ConnectionState.Closed Then
            Conectar.conn.Open()
        End If

        Try
            Dim sqlConsulta As String = "UPDATE Tasadiaria SET detalle = '" & TxttasaDiaria.Text & "', " &
                                                "fecha_modifica ='" & fechaM & "', " &
                                                "fechasele = '" & Me.TxtSelecfecha.Text & "' WHERE descri = '" & FechaSele & "' "

            cmd = New OleDb.OleDbCommand(sqlConsulta, Conectar.conn)

            'ejecutamos la consulta
            cmd.ExecuteNonQuery()

            'presentamos el mensaje 
            MsgBox("Registro actualizado exitosamente, Tasas Diaria", MsgBoxStyle.Information, "AppMinerGold")

            'limpio los campos
            Limpiacampos()
            Me.DGVtasadiaria.DataSource = Nothing

            'inhabilito los campos
            Me.TxttasaDiaria.Enabled = False
            Me.DTPfecha.Enabled = False
            Me.TxtSelecfecha.Enabled = False

            'botones
            Me.BtnUpdate.Visible = True
            Me.BtnUpdate.Enabled = True

            Me.BtnNuevo.Visible = True
            Me.BtnNuevo.Enabled = False

            Me.BtnGuardar.Visible = False
            Me.BtnGuardar.Enabled = False

            Me.BtnModifica.Visible = True
            Me.BtnModifica.Enabled = False

            Me.BtnGuardaCambios.Visible = False
            Me.BtnGuardaCambios.Enabled = False
            Me.BtnSalir.Enabled = True

            'ubico el cursor
            Me.TxttasaDiaria.Select()
            Me.TxttasaDiaria.Focus()

            'cierro conexion
            Conectar.conn.Close()

            Refresh()

        Catch ex As Exception
            'muestro el mensaje de resultado
            MsgBox("Error al guardar los datos, Tasas Diarias" & ex.Message, MsgBoxStyle.Information, "AppMinerGold")

            'botones
            Me.BtnUpdate.Visible = True
            Me.BtnUpdate.Enabled = True

            Me.BtnNuevo.Visible = True
            Me.BtnNuevo.Enabled = False

            Me.BtnGuardar.Visible = False
            Me.BtnGuardar.Enabled = False

            Me.BtnModifica.Visible = True
            Me.BtnModifica.Enabled = False

            Me.BtnGuardaCambios.Visible = False
            Me.BtnGuardaCambios.Enabled = False

            Me.BtnSalir.Enabled = True

            'ubico el cursor
            Me.TxttasaDiaria.Select()
            Me.TxttasaDiaria.Focus()

        End Try
        'cierro conexion
        Conectar.conn.Close()
    End Sub

    'FORMATEANDO LAS CELDAS DE UN DATAGRIDVIEW
    Private Sub DGVtasadiaria_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVtasadiaria.CellFormatting
        'activo el datagrid
        Me.DGVtasadiaria.Enabled = True

        ''deshabilita el efecto visual de windows
        ''ESTILO DE COLOR EN EL DATAGRID
        'DGVtasadiaria.EnableHeadersVisualStyles = False
        'With DGVtasadiaria.ColumnHeadersDefaultCellStyle
        '    .BackColor = Color.Beige
        '    .Alignment = DataGridViewContentAlignment.MiddleCenter
        'End With

        ''ESTABLECE LOS COLORES DE LAS CELDAS
        'With Me.DGVtasadiaria.DefaultCellStyle
        '    .Font = New Font("Tahoma", 8)
        '    .ForeColor = Color.Black
        '    '.BackColor = Color.Aqua
        '    .SelectionForeColor = Color.Beige
        '    '.SelectionBackColor = Color.WhiteSmoke
        'End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVtasadiaria.RowsDefaultCellStyle

            Me.DGVtasadiaria.Columns(0).Width = 40
            Me.DGVtasadiaria.Columns(0).HeaderText = "Id"

            Me.DGVtasadiaria.Columns(1).Width = 200
            Me.DGVtasadiaria.Columns(1).HeaderText = "Valor del Día"
            Me.DGVtasadiaria.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVtasadiaria.Columns(1).DefaultCellStyle.Format = "N2"
            Me.DGVtasadiaria.Columns(1).DefaultCellStyle.NullValue = "0.00"

            Me.DGVtasadiaria.Columns(2).Width = 100
            Me.DGVtasadiaria.Columns(2).HeaderText = "Fecha"
            Me.DGVtasadiaria.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Me.DGVtasadiaria.Columns(5).Width = 100
            'Me.DGVtasadiaria.Columns(5).HeaderText = "Año"
            'Me.DGVtasadiaria.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVtasadiaria.Columns("fecha_creado").Visible = False
            Me.DGVtasadiaria.Columns("fecha_modifica").Visible = False
            Me.DGVtasadiaria.Columns("fechasele").Visible = False

        End With

    End Sub


#End Region

#Region "EVENTOS KEYPRESS"

    'EVENTO LEYPRESS TASA
    Private Sub TxttasaDiaria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxttasaDiaria.KeyPress

        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ","c Then
            e.Handled = True
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    'EVENTO KEYPRESS DE DATETIME
    Private Sub DTPfecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPfecha.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'MOSTRAR LA FECHA SELECCIONADA datetime 
    Private Sub DTPfecha_ValueChanged(sender As Object, e As EventArgs) Handles DTPfecha.ValueChanged
        Me.TxtSelecfecha.Text = Format(Me.DTPfecha.Value, "dd/MM/yyyy")
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCEDIDMIENTO PARA ACELERAR EL DATAGRID CON DEMASIADOS REGISTROS"

    'Imports System.Reflection

    ' Public Sub DoubleBufferedASD(dgv As DataGridView, setting As Boolean)
    '     Dim dgvType As Type = dgv.[GetType]()
    '     Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
    '     pi.SetValue(dgv, setting, Nothing)
    ' End Sub
    ' 'Y lo llamo asi:

    'DoubleBufferedASD(dgArticulos, True)

#End Region






End Class