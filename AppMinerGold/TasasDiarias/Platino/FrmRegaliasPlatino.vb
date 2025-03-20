Imports System.Data.OleDb
Imports System.Globalization
Imports System.Threading

Public Class FrmRegaliasPlatino

    'CARGUE DEL FORM
    Private Sub FrmRegaliasPlatino_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        Me.TxtVrRegalias.Enabled = False
        Me.CboMes.Enabled = False
        Me.CboAño.Enabled = False
        Me.DGVregalias.Enabled = False

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
        Me.TxtVrRegalias.Select()
        Me.TxtVrRegalias.Focus()

        Dim regalias As Integer
        'Me.TxtVrRegalias.Text = Format(regalias, "$ #.###,")
        Me.TxtVrRegalias.Text = Format(regalias, "0.00")
    End Sub

    'Cargue del timpo actual en el formulario
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Me.LblFechaActual.Text = Now.ToLongDateString
    End Sub

    'LINK PARA CONSULTA DE VALORES
    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://www.banrep.gov.co/en/node/50262")
    End Sub

    'LINK PARA CONSULTA DE COMO SE LIQUIDAN REGALIAS
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://www.anm.gov.co/?q=proceso-de-recaudo-liquidacion-y-distribucion-de-regalias")
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
        Dim consulta As String = "SELECT TOP 1 * FROM RegaliasPlatino ORDER BY Id DESC "
        Dim cmd As New OleDbCommand(consulta, conn)

        Dim regalias As Single
        regalias = Val(Me.TxtVrRegalias.Text)

        Try
            Dim drd As OleDbDataReader
            conn.Open()
            drd = cmd.ExecuteReader
            If drd.Read Then
                'GROUPBOX 1 ======================
                regalias = drd.Item("detalle").ToString
                Me.CboMes.Text = drd.Item("descri").ToString
                Me.CboAño.Text = drd.Item("año").ToString

                Me.DGVregalias.Enabled = False

                'lleno los datos al datagrid
                DGVregalias.DataSource = Filtro()

                DGVregalias.CurrentCell = DGVregalias.Rows(DGVregalias.RowCount - 1).Cells(0)

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
                Me.TxtVrRegalias.Select()
                Me.TxtVrRegalias.Focus()

            End If

            Me.TxtVrRegalias.Text = Format(regalias, "0.00")

            drd.Close()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Falta información por ingresar", MsgBoxStyle.Information, "AppMinerGold")
            'ubico el cursor
            Me.TxtVrRegalias.Select()
            Me.TxtVrRegalias.Focus()
            conn.Close()
        End Try
    End Sub

    'BOTON DE NUEVO
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click

        Me.TxtId.Enabled = False

        'habilito los campos
        Me.TxtVrRegalias.Enabled = True
        Me.CboMes.Enabled = True
        Me.CboAño.Enabled = True

        'limpio los campos
        Limpiacampos()

        Me.DGVregalias.Enabled = False

        'lleno los datos al datagrid
        DGVregalias.DataSource = Filtro()

        'si el campo esta vacion el datagrid revisa
        If DGVregalias.Rows.Count > 0 Then
            DGVregalias.CurrentCell = DGVregalias.Rows(DGVregalias.RowCount - 1).Cells(0)
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
            Me.TxtVrRegalias.Select()
            Me.TxtVrRegalias.Focus()
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
        Me.TxtVrRegalias.Select()
        Me.TxtVrRegalias.Focus()

        Cargar_Combo(CboMes, "SELECT DISTINCT detalle FROM Meses")
        Cargar_Combo(CboAño, "SELECT DISTINCT detalle FROM Años")

    End Sub

    'BOTON DE GUARDAR
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        'regalias
        If Len(Me.TxtVrRegalias.Text.Trim) = 0 Then
            MsgBox("El Campo Regalias No puede estar vacío, Ingrese los Datos", MsgBoxStyle.Critical, "AppMinerGold")
            Me.TxtVrRegalias.Select()
            Me.TxtVrRegalias.Focus()
        Else
            Try
                GuardarRegalias()
            Catch ex As Exception
                MessageBox.Show("Ingresar datos de Regalias de Platino", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                Me.TxtVrRegalias.Select()
                Me.TxtVrRegalias.Focus()
            End Try
        End If

    End Sub

    'BOTON DE MODIFICAR
    Private Sub BtnModifica_Click(sender As Object, e As EventArgs) Handles BtnModifica.Click

        'Mensaje de modificar
        MsgBox("Va ha Modificar los Datos de la Base de Datos", MsgBoxStyle.Information, "AppMinerGold")

        Me.TxtId.Enabled = True

        'Habilito los campos
        Me.TxtVrRegalias.Enabled = True
        Me.CboMes.Enabled = True
        Me.CboAño.Enabled = True

        Me.TxtVrRegalias.Clear()

        Me.DGVregalias.Enabled = False

        'ubico el cursor
        Me.TxtId.Select()
        Me.TxtId.Focus()

        'lleno los datos al datagrid
        DGVregalias.DataSource = Filtro()

        DGVregalias.CurrentCell = DGVregalias.Rows(DGVregalias.RowCount - 1).Cells(0)

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

    'BOTON DE CERRAR FORM   
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    'PROCEDIMIENTO DE GUARDAR
    Private Sub GuardarRegalias()
        Try

            Dim fechaC As Date = CDate(Format(Date.Now.Date))
            Dim fechaM As Date = CDate(Format(Date.Now.Date))
            Dim number As Decimal = CDec(Me.TxtVrRegalias.Text)
            If Decimal.TryParse(TxtVrRegalias.Text, number) Then
                TxtVrRegalias.Text = Format(number, "0.00")
            End If

            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            sql = "INSERT INTO RegaliasPlatino (detalle, descri, fecha_creado, fecha_modifica, año) VALUES ('" & number & "', " &
                                       "'" & CboMes.Text & "', '" & fechaC & "', '" & fechaM & "', '" & CboAño.Text & "')"

            cmd.CommandText = sql

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Los datos se han guardado Correctamente!, Regalias de Platino", MsgBoxStyle.Information, "AppMinerGold")

            'LIMPIO LOS CAMPOS
            Limpiacampos()
            Me.DGVregalias.DataSource = Nothing
            'inhabilito los campos
            Me.TxtVrRegalias.Enabled = False
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
            Me.TxtVrRegalias.Select()
            Me.TxtVrRegalias.Focus()


        Catch ex As Exception
            MessageBox.Show("Error: al guardar los datos, Regalias de Platino" & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Me.TxtVrRegalias.Select()
            Me.TxtVrRegalias.Focus()

        End Try

    End Sub

    'PROCEDIMIENTO DE LIMPIAR CAMPOS
    Private Sub Limpiacampos()

        'habilito los campos
        Me.TxtId.Clear()
        Me.TxtVrRegalias.Clear()
        Me.CboMes.SelectedIndex = -1
        Me.CboAño.SelectedIndex = -1

    End Sub

    'PROCEDIMIENTOS DE GUARDAR MODIFICAR
    Private Sub GuardaCambios()

        'fecha modifica
        Dim fechaM As Date = CDate(Format(Date.Now.Date))
        Dim NumId As Integer = CInt(TxtId.Text)
        Dim number As Decimal = CDec(Me.TxtVrRegalias.Text)
        Dim MesCambio As String = CboMes.Text

        If Decimal.TryParse(TxtVrRegalias.Text, number) Then
            TxtVrRegalias.Text = Format(number, "0.00")
        End If

        Dim cmd As New OleDbCommand
        Try
            Dim sqlConsulta As String = "UPDATE RegaliasPlatino SET detalle = '" & number & "', " &
                                                "fecha_modifica ='" & fechaM & "', " &
                                                "descri ='" & MesCambio & "', " &
                                                "año = '" & Me.CboAño.Text & "' WHERE id = " & NumId

            cmd = New OleDbCommand(sqlConsulta, conn)

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Registro actualizado exitosamente, Regalias de Platino", MsgBoxStyle.Information, "AppMinerGold")

            'limpio los campos
            Limpiacampos()
            Me.DGVregalias.DataSource = Nothing

            'inhabilito los campos
            Me.TxtId.Enabled = False
            Me.TxtVrRegalias.Enabled = False
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

            'cierro conexion
            Conectar.conn.Close()

            Refresh()

        Catch ex As Exception
            'muestro el mensaje de resultado
            MsgBox("Error al guardar los datos, Regalias de Platino" & ex.Message, MsgBoxStyle.Information, "AppMinerGold")

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
            Me.TxtId.Select()
            Me.TxtId.Focus()

        End Try

    End Sub

    'FUNCION DE FILTRAR DATOS DE REGALIAS
    Function Filtro() As DataTable
        'conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM RegaliasPlatino", Conectar.conn)
        da.Fill(dt)
        dv.Table = ds.Tables("RegaliasPlatino")
        DGVregalias.DataSource = dv
        conn.Close()
        Return dt
    End Function

    'FORMATEANDO LAS CELDAS DE UN DATAGRIDVIEW
    Private Sub DGVregalias_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVregalias.CellFormatting
        'activo el datagrid
        Me.DGVregalias.Enabled = True

        'deshabilita el efecto visual de windows
        'ESTILO DE COLOR EN EL DATAGRID
        DGVregalias.EnableHeadersVisualStyles = False
        With DGVregalias.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE LOS COLORES DE LAS CELDAS
        With Me.DGVregalias.DefaultCellStyle
            .Font = New Font("Tahoma", 8)
            .ForeColor = Color.Black
            '.BackColor = Color.Aqua
            .SelectionForeColor = Color.Beige
            '.SelectionBackColor = Color.WhiteSmoke
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVregalias.RowsDefaultCellStyle

            Me.DGVregalias.Columns(0).Width = 40
            Me.DGVregalias.Columns(0).HeaderText = "Id"

            Me.DGVregalias.Columns(1).Width = 120
            Me.DGVregalias.Columns(1).HeaderText = "Valor del Mes"
            Me.DGVregalias.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVregalias.Columns(1).DefaultCellStyle.Format = "N2"
            Me.DGVregalias.Columns(1).DefaultCellStyle.NullValue = "0.00"

            Me.DGVregalias.Columns(2).Width = 100
            Me.DGVregalias.Columns(2).HeaderText = "Mes"
            Me.DGVregalias.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVregalias.Columns(5).Width = 100
            Me.DGVregalias.Columns(5).HeaderText = "Año"
            Me.DGVregalias.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVregalias.Columns("fecha_creado").Visible = False
            Me.DGVregalias.Columns("fecha_modifica").Visible = False

        End With
    End Sub


#End Region

#Region "EVENTOS KEYPRESS"

    'TEXTBOX REGALIAS
    Private Sub TxtVrRegalias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtVrRegalias.KeyPress
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