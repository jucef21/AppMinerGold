Imports System.Data.OleDb
Imports System.Globalization
Imports System.Threading

Public Class FrmRetefuenteOro

    'CARGUE DEL FORMULARIO
    Private Sub FrmRetefuente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-CO")
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        'codigo mostrar hora en formulario
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Timer1.Interval = 1000  ' Un segundo
        Timer1.Start()

        'no permite cambiar el codigo
        CboMes.DropDownStyle = ComboBoxStyle.DropDownList
        CboAño.DropDownStyle = ComboBoxStyle.DropDownList

        Cargar_Combo(CboMes, "SELECT DISTINCT detalle FROM Meses")
        Cargar_Combo(CboAño, "SELECT DISTINCT detalle FROM Años")

        Me.TxtId.Enabled = False
        Me.TxtVrRetefuente.Enabled = False
        Me.CboMes.Enabled = False
        Me.CboAño.Enabled = False
        Me.DGVretefuente.Enabled = False

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

        'ubico el cursor
        Me.BtnUpdate.Select()
        Me.BtnUpdate.Focus()

        Dim Retefuente As Integer
        'Me.TxtVrRetefuente.Text = Format(Retefuente, "#.###,")
        Me.TxtVrRetefuente.Text = Format(Retefuente, "0.00")

    End Sub

    'Cargue del timpo actual en el formulario
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Me.LblFechaActual.Text = Now.ToLongDateString
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

#Region "BOTONES"

    'BOTON DE ACTUALIZAR
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click

        'CREO LA CONSULTA
        Dim dt As New DataTable
        Dim consulta As String = "SELECT TOP 1 * FROM Retefuente ORDER BY Id DESC "
        Dim cmd As New OleDbCommand(consulta, conn)

        Dim retefuente As Single
        retefuente = Val(Me.TxtVrRetefuente.Text)

        'ubico el cursor
        Me.TxtVrRetefuente.Select()
        Me.TxtVrRetefuente.Focus()

        'Habilito los combos
        Me.TxtId.Enabled = False
        Me.CboMes.Enabled = False
        Me.CboAño.Enabled = False

        Try
            Dim drd As OleDbDataReader
            conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                'GROUPBOX 1 ======================
                retefuente = drd.Item("detalle").ToString
                Me.CboMes.Text = drd.Item("descri").ToString
                Me.CboAño.Text = drd.Item("año").ToString

                Me.DGVretefuente.Enabled = False

                'lleno los datos al datagrid
                DGVretefuente.DataSource = Filtro()

                DGVretefuente.CurrentCell = DGVretefuente.Rows(DGVretefuente.RowCount - 1).Cells(0)

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

                'ubico el cursor
                Me.TxtVrRetefuente.Select()
                Me.TxtVrRetefuente.Focus()

                'Habilito los combos
                Me.CboMes.Enabled = False
                Me.CboAño.Enabled = False

            End If

            Me.TxtVrRetefuente.Text = Format(retefuente, "0.00")

            drd.Close()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Falta información por ingresar Retefuente Oro", MsgBoxStyle.Information, "AppMinerGold")
            'ubico el cursor
            Me.TxtVrRetefuente.Select()
            Me.TxtVrRetefuente.Focus()
            'Habilito los combos
            Me.CboMes.Enabled = False
            Me.CboAño.Enabled = False
            conn.Close()
        End Try

    End Sub

    'BOTON DE NUEVO
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click

        'habilito los campos
        Me.TxtId.Enabled = False
        Me.TxtVrRetefuente.Enabled = True
        Me.CboMes.Enabled = True
        Me.CboAño.Enabled = True

        'limpio los campos
        Limpiacampos()

        Me.DGVretefuente.Enabled = False

        'lleno los datos al datagrid
        DGVretefuente.DataSource = Filtro()

        'si el campo esta vacion el datagrid revisa
        If DGVretefuente.Rows.Count > 0 Then
            DGVretefuente.CurrentCell = DGVretefuente.Rows(DGVretefuente.RowCount - 1).Cells(0)
        Else
            'botones
            Me.BtnUpdate.Visible = True
            Me.BtnUpdate.Enabled = False
            Me.BtnNuevo.Visible = True
            Me.BtnNuevo.Enabled = False
            Me.BtnGuardar.Visible = False
            Me.BtnGuardar.Enabled = True
            Me.BtnModifica.Visible = True
            Me.BtnModifica.Enabled = False
            Me.BtnGuardaCambios.Visible = False
            Me.BtnGuardaCambios.Enabled = False

            'ubico el cursor
            Me.TxtVrRetefuente.Select()
            Me.TxtVrRetefuente.Focus()
        End If
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

        'ubico el cursor
        Me.TxtVrRetefuente.Select()
        Me.TxtVrRetefuente.Focus()

        Cargar_Combo(CboMes, "SELECT DISTINCT detalle FROM Meses")
        Cargar_Combo(CboAño, "SELECT DISTINCT detalle FROM Años")

    End Sub

    'BOTON DE GUARDAR
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        'regalias
        If Len(Me.TxtVrRetefuente.Text.Trim) = 0 Then
            MsgBox("El Campo Retefuente No puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
            Me.TxtVrRetefuente.Select()
            Me.TxtVrRetefuente.Focus()
        Else
            'llamo elprocedimiento
            GuardarRetefuente()
        End If

    End Sub

    'BOTON DE MODIFICAR
    Private Sub BtnModifica_Click(sender As Object, e As EventArgs) Handles BtnModifica.Click

        'Mensaje de modificar
        MsgBox("Va ha Modificar los Datos de la Base de Datos", MsgBoxStyle.Information, "AppMinerGold")

        'Habilito los campos
        Me.TxtId.Enabled = True
        Me.TxtVrRetefuente.Enabled = True
        Me.CboMes.Enabled = True
        Me.CboAño.Enabled = True

        Me.TxtVrRetefuente.Clear()

        Me.DGVretefuente.Enabled = False

        'ubico el cursor
        Me.TxtId.Select()
        Me.TxtId.Focus()

        'lleno los datos al datagrid
        DGVretefuente.DataSource = Filtro()

        DGVretefuente.CurrentCell = DGVretefuente.Rows(DGVretefuente.RowCount - 1).Cells(0)

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

    End Sub

    'BOTON DE GUARDAR CAMBIOS
    Private Sub BtnGuardaCambios_Click(sender As Object, e As EventArgs) Handles BtnGuardaCambios.Click

        'llamo al procedimiento
        GuardaCambios()

    End Sub

    'BOTON CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    'PROCEDIMIENTO DE GUARDAR
    Private Sub GuardarRetefuente()

        Try
            'fecha creado
            Dim fechaC As Date = CDate(Format(Date.Now.Date))
            Dim fechaM As Date = CDate(Format(Date.Now.Date))

            Dim number As Decimal = CDec(Me.TxtVrRetefuente.Text)
            If Decimal.TryParse(TxtVrRetefuente.Text, number) Then
                TxtVrRetefuente.Text = Format(number, "0.00")
            End If

            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            sql = "INSERT INTO Retefuente (detalle, descri, fecha_creado, fecha_modifica, año) VALUES ('" & number & "', '" & CboMes.Text & "', '" & fechaC & "', '" & fechaM & "', '" & CboAño.Text & "')"

            cmd.CommandText = sql

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Los datos se han guardado Correctamente!, Regalias de ORO", MsgBoxStyle.Information, "AppMinerGold")

            'LIMPIO LOS CAMPOS
            Limpiacampos()

            Me.DGVretefuente.DataSource = Nothing

            'inhabilito los campos
            Me.TxtVrRetefuente.Enabled = False
            Me.CboMes.Enabled = False
            Me.CboAño.Enabled = False

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

            'ubico el cursor
            Me.TxtVrRetefuente.Select()
            Me.TxtVrRetefuente.Focus()
        Catch ex As Exception
            MessageBox.Show("Error: al guardar los datos, Retefuente de ORO" & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            'ubico el cursor
            Me.TxtVrRetefuente.Select()
            Me.TxtVrRetefuente.Focus()

        End Try

    End Sub

    'PROCEDIMIENTO DE LIMPIAR CAMPOS
    Private Sub Limpiacampos()

        'habilito los campos
        Me.TxtId.Clear()
        Me.TxtVrRetefuente.Clear()
        Me.CboMes.SelectedIndex = -1
        Me.CboAño.SelectedIndex = -1

    End Sub

    'PROCEDIMIENTOS DE GUARDAR MODIFICAR
    Private Sub GuardaCambios()

        'fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))
        Dim NumId As Integer = CInt(TxtId.Text)
        Dim number As Decimal = CDec(Me.TxtVrRetefuente.Text)

        If Decimal.TryParse(TxtVrRetefuente.Text, number) Then
            TxtVrRetefuente.Text = Format(number, "0.00")
        End If

        Dim cmd As New OleDbCommand

        Try
            Dim sqlConsulta As String = "UPDATE Retefuente SET detalle = '" & number & "', descri = '" & Me.CboMes.Text & "', " &
                                                "fecha_modifica ='" & fechaM & "', " &
                                                "año = '" & Me.CboAño.Text & "' WHERE id = " & NumId

            cmd = New OleDbCommand(sqlConsulta, conn)

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Registro actualizado exitosamente, Retefuente de ORO", MsgBoxStyle.Information, "AppMinerGold")

            'limpio los campos
            Limpiacampos()
            Me.DGVretefuente.DataSource = Nothing

            'inhabilito los campos
            Me.TxtId.Enabled = False
            Me.TxtVrRetefuente.Enabled = False
            Me.CboMes.Enabled = False
            Me.CboAño.Enabled = False

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

            'ubico el cursor
            Me.TxtVrRetefuente.Select()
            Me.TxtVrRetefuente.Focus()

            Refresh()

        Catch ex As Exception
            'muestro el mensaje de resultado
            MsgBox("Error al guardar los datos, Retefuente de ORO" & ex.Message, MsgBoxStyle.Information, "AppMinerGold")

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

            'ubico el cursor
            Me.TxtVrRetefuente.Select()
            Me.TxtVrRetefuente.Focus()

        End Try

    End Sub

    'FUNCION DE FILTRAR DATOS DE REGALIAS
    Function Filtro() As DataTable
        'conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM Retefuente", conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Retefuente")
        DGVretefuente.DataSource = dv
        conn.Close()
        Return dt
    End Function

    'FORMATEANDO LAS CELDAS DE UN DATAGRIDVIEW
    Private Sub DGVretefuente_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVretefuente.CellFormatting
        'activo el datagrid
        Me.DGVretefuente.Enabled = True

        'deshabilita el efecto visual de windows
        'ESTILO DE COLOR EN EL DATAGRID
        DGVretefuente.EnableHeadersVisualStyles = False
        With DGVretefuente.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE LOS COLORES DE LAS CELDAS
        With Me.DGVretefuente.DefaultCellStyle
            .Font = New Font("Tahoma", 8)
            .ForeColor = Color.Black
            '.BackColor = Color.Aqua
            .SelectionForeColor = Color.Beige
            '.SelectionBackColor = Color.WhiteSmoke
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVretefuente.RowsDefaultCellStyle

            Me.DGVretefuente.Columns(0).Width = 40
            Me.DGVretefuente.Columns(0).HeaderText = "Id"

            Me.DGVretefuente.Columns(1).Width = 120
            Me.DGVretefuente.Columns(1).HeaderText = "Valor del Mes"
            Me.DGVretefuente.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVretefuente.Columns(1).DefaultCellStyle.Format = "N2"
            Me.DGVretefuente.Columns(1).DefaultCellStyle.NullValue = "0.00"

            Me.DGVretefuente.Columns(2).Width = 100
            Me.DGVretefuente.Columns(2).HeaderText = "Mes"
            Me.DGVretefuente.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVretefuente.Columns(5).Width = 100
            Me.DGVretefuente.Columns(5).HeaderText = "Año"
            Me.DGVretefuente.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVretefuente.Columns("fecha_creado").Visible = False
            Me.DGVretefuente.Columns("fecha_modifica").Visible = False

        End With

    End Sub

#End Region

#Region "EVENTOS KEYPRESS"

    'TEXTBOX RETEFUENTE
    Private Sub TxtVrRetefuente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtVrRetefuente.KeyPress

        'formato numerico con punto decimal 
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    'COMBO MES
    Private Sub CboMes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboMes.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'COMBO AÑO
    Private Sub CboAño_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboAño.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'KEYPRESS ID
    Private Sub TxtId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtId.KeyPress
        SoloNumeros(e)
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region



End Class