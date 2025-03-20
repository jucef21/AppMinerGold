Imports System.Data.OleDb

Public Class FrmTotalComprado

    'CARGUE DEL FORMULARIO
    Private Sub FrmTotalComprado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'colocamos los texbox en no editable
        Me.Txtced_cl.Enabled = False
        Me.TxtNomApe.Enabled = False

        'actualizo la fecha en los calendarios
        Dim dtFecha As Date = DateSerial(Year(Date.Today), 1, 1)
        Me.DTPinicial.Value = dtFecha
        Me.DTPfinal.Value = Date.Today

        CargaDatos()

    End Sub


#Region "PROCESOS DE ORO"

    'PROCESO DE CONSULTA GRAMOS BRUTOS
    Private Sub LlenaConsultaBrutosOro()
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim NumCedu As Integer
        NumCedu = CInt(Me.Txtced_cl.Text)
        Dim num As String = "1"
        Try
            Using conn As New OleDbConnection(cs)
                Dim cmd As OleDbCommand = conn.CreateCommand()
                'Indicamos la consulta que vamos a ejecutar
                cmd.CommandText = "SELECT SUM(grbrutos) AS Suma FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comOro = '" & num & "' AND cedu_com = " & NumCedu
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                With da.SelectCommand.Parameters
                    .AddWithValue("@starDate", hugh)
                    .AddWithValue("@endDate", hugh2)
                End With
                Dim dt As New DataTable("Declara")
                da.Fill(dt)
                DataGridView1.DataSource = dt
                ' Abrimos la conexión
                conn.Open()
                ' Ejecutamos la consulta
                Dim suma As Object = cmd.ExecuteScalar()
                ' Mostramos el resultado formateado en un control TextBox
                TxtBrutos.Text = String.Format("{0:N2}", suma)
            End Using
        Catch ex As Exception
            MessageBox.Show("No lleno Gramos Brutos. " + ex.Message)
        End Try
    End Sub

    'PROCESO DE CONSULTA GRAMOS BRUTOS
    Private Sub LlenaConsultaPurosOro()
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim NumCedu As Integer
        NumCedu = Me.Txtced_cl.Text
        Dim num As String = "1"
        Try
            Using conn As New OleDbConnection(cs)
                Dim cmd As OleDbCommand = conn.CreateCommand()
                ' Indicamos la consulta que vamos a ejecutar
                cmd.CommandText = "SELECT SUM(grpuros) AS Suma FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comOro = '" & num & "' AND cedu_com = " & NumCedu
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                With da.SelectCommand.Parameters
                    .AddWithValue("@starDate", hugh)
                    .AddWithValue("@endDate", hugh2)
                End With
                Dim dt As New DataTable("Declara")
                da.Fill(dt)
                DataGridView2.DataSource = dt
                ' Abrimos la conexión
                conn.Open()
                ' Ejecutamos la consulta
                Dim suma As Object = cmd.ExecuteScalar()
                ' Mostramos el resultado formateado en un control TextBox
                TxtPuros.Text = String.Format("{0:N2}", suma)
            End Using
        Catch ex As Exception
            MessageBox.Show("No lleno Gramos Puros. " + ex.Message)
        End Try
    End Sub

    'PROCESO DE CONSULTA FECHA COMPRAS
    Private Sub LLenaValorComprasOro()
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim NumCedu As Integer
        NumCedu = Me.Txtced_cl.Text
        Dim num As String = "1"
        Try
            Using conn As New OleDbConnection(cs)
                Dim cmd As OleDbCommand = conn.CreateCommand()
                'Indicamos la consulta que vamos a ejecutar
                cmd.CommandText = "SELECT SUM(vrventa) AS Suma FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comOro = '" & num & "' AND cedu_com = " & NumCedu
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                With da.SelectCommand.Parameters
                    .AddWithValue("@starDate", hugh)
                    .AddWithValue("@endDate", hugh2)
                End With
                Dim dt As New DataTable("Declara")
                da.Fill(dt)
                DataGridView3.DataSource = dt
                ' Abrimos la conexión
                conn.Open()
                ' Ejecutamos la consulta
                Dim suma As Object = cmd.ExecuteScalar()
                ' Mostramos el resultado formateado en un control TextBox
                Me.TxtVrCompras.Text = String.Format("{0:N2}", suma)
            End Using
        Catch ex As Exception
            MessageBox.Show("No lleno Gramos Brutos. " + ex.Message)
        End Try
    End Sub

#End Region

#Region "PROCESOS DE PLATINO"

    'PROCESO DE CONSULTA GRAMOS BRUTOS
    Private Sub LlenaConsultaBrutosPlatino()
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim NumCedu As Integer
        NumCedu = CInt(Me.Txtced_cl.Text)
        Dim num As String = "2"
        Try
            Using conn As New OleDbConnection(cs)
                Dim cmd As OleDbCommand = conn.CreateCommand()
                'Indicamos la consulta que vamos a ejecutar
                cmd.CommandText = "SELECT SUM(grbrutos) AS Suma FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlatino = '" & num & "' AND cedu_com = " & NumCedu
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                With da.SelectCommand.Parameters
                    .AddWithValue("@starDate", hugh)
                    .AddWithValue("@endDate", hugh2)
                End With
                Dim dt As New DataTable("Declara")
                da.Fill(dt)
                DataGridView1.DataSource = dt
                ' Abrimos la conexión
                conn.Open()
                ' Ejecutamos la consulta
                Dim suma As Object = cmd.ExecuteScalar()
                ' Mostramos el resultado formateado en un control TextBox
                TxtBrutos.Text = String.Format("{0:N2}", suma)
            End Using
        Catch ex As Exception
            MessageBox.Show("No lleno Gramos Brutos. " + ex.Message)
        End Try
    End Sub

    'PROCESO DE CONSULTA GRAMOS BRUTOS
    Private Sub LlenaConsultaPurosPlatino()
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim NumCedu As Integer
        NumCedu = Me.Txtced_cl.Text
        Dim num As String = "2"
        Try
            Using conn As New OleDbConnection(cs)
                Dim cmd As OleDbCommand = conn.CreateCommand()
                ' Indicamos la consulta que vamos a ejecutar
                cmd.CommandText = "SELECT SUM(grpuros) AS Suma FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlatino = '" & num & "' AND cedu_com = " & NumCedu
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                With da.SelectCommand.Parameters
                    .AddWithValue("@starDate", hugh)
                    .AddWithValue("@endDate", hugh2)
                End With
                Dim dt As New DataTable("Declara")
                da.Fill(dt)
                DataGridView2.DataSource = dt
                ' Abrimos la conexión
                conn.Open()
                ' Ejecutamos la consulta
                Dim suma As Object = cmd.ExecuteScalar()
                ' Mostramos el resultado formateado en un control TextBox
                TxtPuros.Text = String.Format("{0:N2}", suma)
            End Using
        Catch ex As Exception
            MessageBox.Show("No lleno Gramos Puros. " + ex.Message)
        End Try
    End Sub

    'PROCESO DE CONSULTA FECHA COMPRAS
    Private Sub LLenaValorComprasPlatino()
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim NumCedu As Integer
        NumCedu = Me.Txtced_cl.Text
        Dim num As String = "2"
        Try
            Using conn As New OleDbConnection(cs)
                Dim cmd As OleDbCommand = conn.CreateCommand()
                'Indicamos la consulta que vamos a ejecutar
                cmd.CommandText = "SELECT SUM(vrventa) AS Suma FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlatino = '" & num & "' AND cedu_com = " & NumCedu
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                With da.SelectCommand.Parameters
                    .AddWithValue("@starDate", hugh)
                    .AddWithValue("@endDate", hugh2)
                End With
                Dim dt As New DataTable("Declara")
                da.Fill(dt)
                DataGridView3.DataSource = dt
                ' Abrimos la conexión
                conn.Open()
                ' Ejecutamos la consulta
                Dim suma As Object = cmd.ExecuteScalar()
                ' Mostramos el resultado formateado en un control TextBox
                Me.TxtVrCompras.Text = String.Format("{0:N2}", suma)
            End Using
        Catch ex As Exception
            MessageBox.Show("No lleno Gramos Brutos. " + ex.Message)
        End Try
    End Sub

#End Region

#Region "PROCESOS DE PLATA"

    'PROCESO DE CONSULTA GRAMOS BRUTOS
    Private Sub LlenaConsultaBrutosPlata()
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim NumCedu As Integer
        NumCedu = CInt(Me.Txtced_cl.Text)
        Dim num As String = "3"
        Try
            Using conn As New OleDbConnection(cs)
                Dim cmd As OleDbCommand = conn.CreateCommand()
                'Indicamos la consulta que vamos a ejecutar
                cmd.CommandText = "SELECT SUM(grbrutos) AS Suma FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlata = '" & num & "' AND cedu_com = " & NumCedu
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                With da.SelectCommand.Parameters
                    .AddWithValue("@starDate", hugh)
                    .AddWithValue("@endDate", hugh2)
                End With
                Dim dt As New DataTable("Declara")
                da.Fill(dt)
                DataGridView1.DataSource = dt
                ' Abrimos la conexión
                conn.Open()
                ' Ejecutamos la consulta
                Dim suma As Object = cmd.ExecuteScalar()
                ' Mostramos el resultado formateado en un control TextBox
                TxtBrutos.Text = String.Format("{0:N2}", suma)
            End Using
        Catch ex As Exception
            MessageBox.Show("No lleno Gramos Brutos. " + ex.Message)
        End Try
    End Sub

    'PROCESO DE CONSULTA GRAMOS BRUTOS
    Private Sub LlenaConsultaPurosPlata()
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim NumCedu As Integer
        NumCedu = Me.Txtced_cl.Text
        Dim num As String = "3"
        Try
            Using conn As New OleDbConnection(cs)
                Dim cmd As OleDbCommand = conn.CreateCommand()
                ' Indicamos la consulta que vamos a ejecutar
                cmd.CommandText = "SELECT SUM(grpuros) AS Suma FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlata = '" & num & "' AND cedu_com = " & NumCedu
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                With da.SelectCommand.Parameters
                    .AddWithValue("@starDate", hugh)
                    .AddWithValue("@endDate", hugh2)
                End With
                Dim dt As New DataTable("Declara")
                da.Fill(dt)
                DataGridView2.DataSource = dt
                ' Abrimos la conexión
                conn.Open()
                ' Ejecutamos la consulta
                Dim suma As Object = cmd.ExecuteScalar()
                ' Mostramos el resultado formateado en un control TextBox
                TxtPuros.Text = String.Format("{0:N2}", suma)
            End Using
        Catch ex As Exception
            MessageBox.Show("No lleno Gramos Puros. " + ex.Message)
        End Try
    End Sub

    'PROCESO DE CONSULTA FECHA COMPRAS
    Private Sub LLenaValorComprasPlata()
        Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
        Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
        Dim ANU As String = "ANULADO"
        Dim NumCedu As Integer
        NumCedu = Me.Txtced_cl.Text
        Dim num As String = "3"
        Try
            Using conn As New OleDbConnection(cs)
                Dim cmd As OleDbCommand = conn.CreateCommand()
                'Indicamos la consulta que vamos a ejecutar
                cmd.CommandText = "SELECT SUM(vrventa) AS Suma FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlata = '" & num & "' AND cedu_com = " & NumCedu
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                With da.SelectCommand.Parameters
                    .AddWithValue("@starDate", hugh)
                    .AddWithValue("@endDate", hugh2)
                End With
                Dim dt As New DataTable("Declara")
                da.Fill(dt)
                DataGridView3.DataSource = dt
                ' Abrimos la conexión
                conn.Open()
                ' Ejecutamos la consulta
                Dim suma As Object = cmd.ExecuteScalar()
                ' Mostramos el resultado formateado en un control TextBox
                Me.TxtVrCompras.Text = String.Format("{0:N2}", suma)
            End Using
        Catch ex As Exception
            MessageBox.Show("No lleno Gramos Brutos. " + ex.Message)
        End Try
    End Sub

#End Region

    'PROCESO QUE CARGADATOS
    Private Sub CargaDatos()
        If TxtMaterial.Text = "ORO" Then
            Try
                If Txtced_cl.Text = "" Then
                    MessageBox.Show("El campo no debe estar vacio. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    LlenaConsultaBrutosOro()
                    LlenaConsultaPurosOro()
                    Dim ResulLey As Decimal = CDec(If(TxtPuros.Text.Contains(","), TxtPuros.Text.Replace(",", "."), TxtPuros.Text)) / CDec(If(TxtBrutos.Text.Contains(","), TxtBrutos.Text.Replace(",", "."), TxtBrutos.Text))
                    ResulLey = Math.Round(ResulLey, 4)
                    Me.TxtLey.Text = ResulLey.ToString
                    LLenaValorComprasOro()
                End If
            Catch ex As Exception
                MessageBox.Show("No se Encontraron Compras Registradas. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
        If TxtMaterial.Text = "PLATINO" Then
            Try
                If Txtced_cl.Text = "" Then
                    MessageBox.Show("El campo no debe estar vacio. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    LlenaConsultaBrutosPlatino()
                    LlenaConsultaPurosPlatino()
                    Dim ResulLey As Decimal = CDec(If(TxtPuros.Text.Contains(","), TxtPuros.Text.Replace(",", "."), TxtPuros.Text)) / CDec(If(TxtBrutos.Text.Contains(","), TxtBrutos.Text.Replace(",", "."), TxtBrutos.Text))
                    ResulLey = Math.Round(ResulLey, 4)
                    Me.TxtLey.Text = ResulLey.ToString
                    LLenaValorComprasPlatino()
                End If
            Catch ex As Exception
                MessageBox.Show("No se Encontraron Compras Registradas. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
        If TxtMaterial.Text = "PLATA" Then
            Try
                If Txtced_cl.Text = "" Then
                    MessageBox.Show("El campo no debe estar vacio. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    LlenaConsultaBrutosPlatino()
                    LlenaConsultaPurosPlatino()
                    Dim ResulLey As Decimal = CDec(If(TxtPuros.Text.Contains(","), TxtPuros.Text.Replace(",", "."), TxtPuros.Text)) / CDec(If(TxtBrutos.Text.Contains(","), TxtBrutos.Text.Replace(",", "."), TxtBrutos.Text))
                    ResulLey = Math.Round(ResulLey, 4)
                    Me.TxtLey.Text = ResulLey.ToString
                    LLenaValorComprasPlatino()
                End If
            Catch ex As Exception
                MessageBox.Show("No se Encontraron Compras Registradas. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    'CIERRA FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class