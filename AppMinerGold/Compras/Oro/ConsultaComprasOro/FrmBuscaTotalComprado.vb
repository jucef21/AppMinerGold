Imports System.Data.OleDb

Public Class FrmBuscaTotalComprado

    'CARGUE DEL FORMULARIO
    Private Sub FrmBuscaTotalComprado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'actualizo la fecha en los calendarios
        Dim dtFecha As Date = DateSerial(Year(Date.Today), 1, 1)
        Me.DTPinicial.Value = dtFecha
        Me.DTPfinal.Value = Date.Today

        'UBICO EL CURSOR
        Me.Panel2.Select()
        Me.GroupBox3.Select()
        Me.TxtBuscar.Clear()
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()

        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

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

        'LIMPIO LOS  CHECKBOX
        Me.ChkOro.Checked = 1
        Me.ChkPlatino.Checked = 1
        Me.ChkPlata.Checked = 1

        Me.ChkOro.CheckState = CheckState.Unchecked
        Me.ChkPlatino.CheckState = CheckState.Unchecked
        Me.ChkPlata.CheckState = CheckState.Unchecked

        Me.TxtCedula.Clear()
        Me.TxtMetal.Clear()

    End Sub

#Region "BOTONES DEL FORMULARIO"

    'BOTON DE BUSCAR
    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        'cursor de esperar
        Me.Cursor = Cursors.WaitCursor
        'verifico el campo vacio
        If Me.TxtBuscar.Text = "" Then
            MsgBox("Para hacer una Consulta debe Digitar el Número de Cédula! ", MsgBoxStyle.Information, "AppMinerGold")
            'ubico el cursor
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
        Else
            Me.TxtCedula.Text = Me.TxtBuscar.Text
            'activo el datagrid
            Me.DataGridView2.Enabled = True
            'lleno los datos al datagrid
            If FiltroCedula(Me.TxtBuscar.Text).Rows.Count > 0 Then
                'manejo del cursor
                Me.Cursor = Cursors.WaitCursor
                DataGridView2.DataSource = FiltroCedula(Me.TxtBuscar.Text)
                Me.TxtCedula.Text = DataGridView2.CurrentRow.Cells(1).Value
                'deshabilito el boton nuevo
                Me.TxtBuscar.Enabled = False
                Me.BtnBuscar.Enabled = False
                Me.BtnLimpiar.Enabled = True
                If ChkOro.Checked = CheckState.Unchecked And ChkPlatino.Checked = CheckState.Unchecked And ChkPlata.Checked = CheckState.Unchecked Then
                    MessageBox.Show("Debe seleccionar un Material", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If ChkOro.Checked Then
                        'EscojeMaterialOro()
                        LlenaMaterialOro()
                        'inhabilito el boton
                        Me.Panel2.Select()
                        Me.GroupBox3.Select()
                        Me.BtnBuscar.Enabled = False
                        Me.BtnLimpiar.Enabled = True
                        Me.TxtBuscar.Enabled = False
                    End If

                    If ChkPlatino.Checked Then
                        'EscojeMaterialPlatino()
                        LlenaMaterialPlatino()
                        'inhabilito el boton
                        Me.Panel2.Select()
                        Me.GroupBox3.Select()
                        Me.BtnBuscar.Enabled = False
                        Me.BtnLimpiar.Enabled = True
                        Me.TxtBuscar.Enabled = False
                    End If

                    If ChkPlata.Checked Then
                        'EscojeMaterialPlata()
                        LlenaMaterialPlata()
                        'inhabilito el boton
                        Me.Panel2.Select()
                        Me.GroupBox3.Select()
                        Me.BtnBuscar.Enabled = False
                        Me.BtnLimpiar.Enabled = True
                        Me.TxtBuscar.Enabled = False
                    End If
                End If

                'manejo del cursor
                Me.Cursor = Cursors.Default
            Else
                MessageBox.Show("La Cédula que Digíto No Registra Compras!", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Panel2.Select()
                Me.GroupBox3.Select()
                Me.TxtBuscar.Text = ""
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Focus()
                'habilito los botones
                Me.BtnBuscar.Enabled = True
                Me.BtnLimpiar.Enabled = True

                'limpio el datagrid
                DataGridView2.ClearSelection()
                DataGridView2.DataSource = Nothing
                DataGridView2.Columns.Clear()
            End If
        End If
        'cursor de esperar
        Me.Cursor = Cursors.Default
    End Sub

    'FUNCION DE FILTRAR CEDULA DE UN DATAGRID
    Function FiltroCedula(ByVal busqueda As String) As DataTable
        Dim NumConse As Integer = CInt(TxtBuscar.Text)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM Declara WHERE cedu_com = " & NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Declara")
        'DataGridView1.DataSource = dv
        Return dt
    End Function

    Private Sub ChkOro_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkOro.CheckStateChanged
        ChkPlata.Checked = CheckState.Unchecked
        ChkPlatino.Checked = CheckState.Unchecked
        Me.TxtMetal.Text = "ORO"
    End Sub

    Private Sub ChkPlatino_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkPlatino.CheckStateChanged
        ChkOro.Checked = CheckState.Unchecked
        ChkPlata.Checked = CheckState.Unchecked
        Me.TxtMetal.Text = "PLATINO"
    End Sub

    Private Sub ChkPlata_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkPlata.CheckStateChanged
        ChkOro.Checked = CheckState.Unchecked
        ChkPlatino.Checked = CheckState.Unchecked
        Me.TxtMetal.Text = "PLATA"
    End Sub

    'PROCESO SELECCIONA MATERIAL ORO
    Private Sub EscojeMaterialOro()
        Try
            'manejo del cursor
            Me.Cursor = Cursors.WaitCursor

            If Me.TxtBuscar.Text = "" Then
                MsgBox("No se encontro ningún Registro de Ingreso, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")
                'limpio y ubico el cursor
            Else
                Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
                Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
                Dim ANU As String = "ANULADO"
                Dim NumCedu As Integer
                NumCedu = Me.TxtBuscar.Text
                Dim num As String = "1"
                Try
                    Using conn As New OleDbConnection(cs)
                        Dim cmd As OleDbCommand = conn.CreateCommand()
                        'Indicamos la consulta que vamos a ejecutar
                        cmd.CommandText = "SELECT * FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comOro = '" & num & "' AND cedu_com = " & NumCedu
                        Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                        With da.SelectCommand.Parameters
                            .AddWithValue("@starDate", hugh)
                            .AddWithValue("@endDate", hugh2)
                        End With
                        Dim dt As New DataTable("Declara")
                        da.Fill(dt)
                        DataGridView2.DataSource = dt
                        'muestro la cantidad de registros encontrados
                        LblModReg.Text = dt.Rows.Count

                        MessageBox.Show("Busqueda Encontrada, Aceptar para Continuar. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'DATOS DEL CLIENTES
                        FrmTotalComprado.TxtMaterial.Text = TxtMetal.Text
                        FrmTotalComprado.Txtced_cl.Text = DataGridView2.CurrentRow.Cells(1).Value
                        FrmTotalComprado.TxtNomApe.Text = DataGridView2.CurrentRow.Cells(2).Value
                        FrmTotalComprado.LblModReg.Text = LblModReg.Text
                        FrmTotalComprado.TxtMaterial.Text = "ORO"

                        'desactivo el datagrid
                        Me.DataGridView2.Enabled = False

                        'DESHABILITO LOS BOTONES
                        Me.BtnBuscar.Enabled = False
                        Me.BtnLimpiar.Enabled = True

                        Me.TxtBuscar.Enabled = False

                        'llamo  el form
                        FrmTotalComprado.ShowDialog()

                        'limpio el datagrid
                        DataGridView2.ClearSelection()
                        DataGridView2.DataSource = Nothing
                        DataGridView2.Columns.Clear()

                    End Using
                Catch ex As Exception
                    MessageBox.Show("No hay datos en el numero consultado. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If
            'manejo del cursor
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("No hay datos en el numero consultado. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtBuscar.Enabled = False
            Me.TxtBuscar.Clear()
            Me.BtnBuscar.Enabled = False
            Me.BtnLimpiar.Enabled = True

            'UBICO EL CURSOR
            Me.BtnLimpiar.Select()
            Me.BtnLimpiar.Focus()
        End Try

    End Sub

    'PROCESO SELECCIONA MATERIAL PLATINO
    Private Sub EscojeMaterialPlatino()
        Try
            'manejo del cursor
            Me.Cursor = Cursors.WaitCursor

            If Me.TxtBuscar.Text = "" Then
                MsgBox("No se encontro ningún Registro de Ingreso, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")
                'limpio y ubico el cursor
            Else
                Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
                Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
                Dim ANU As String = "ANULADO"
                Dim NumCedu As Integer
                NumCedu = Me.TxtBuscar.Text
                Dim num As String = "2"
                Try
                    Using conn As New OleDbConnection(cs)
                        Dim cmd As OleDbCommand = conn.CreateCommand()
                        'Indicamos la consulta que vamos a ejecutar
                        cmd.CommandText = "SELECT * FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlatino = '" & num & "' AND cedu_com = " & NumCedu
                        Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                        With da.SelectCommand.Parameters
                            .AddWithValue("@starDate", hugh)
                            .AddWithValue("@endDate", hugh2)
                        End With
                        Dim dt As New DataTable("Declara")
                        da.Fill(dt)
                        DataGridView2.DataSource = dt
                        'muestro la cantidad de registros encontrados
                        LblModReg.Text = dt.Rows.Count
                        MessageBox.Show("Busqueda Encontrada, Aceptar para Continuar. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'DATOS DEL CLIENTES
                        FrmTotalComprado.TxtMaterial.Text = TxtMetal.Text
                        FrmTotalComprado.Txtced_cl.Text = DataGridView2.CurrentRow.Cells(1).Value
                        FrmTotalComprado.TxtNomApe.Text = DataGridView2.CurrentRow.Cells(2).Value
                        FrmTotalComprado.LblModReg.Text = LblModReg.Text
                        FrmTotalComprado.TxtMaterial.Text = "PLATINO"

                        'desactivo el datagrid
                        Me.DataGridView2.Enabled = False

                        'DESHABILITO LOS BOTONES
                        Me.BtnBuscar.Enabled = False
                        Me.BtnLimpiar.Enabled = True

                        Me.TxtBuscar.Enabled = False

                        'llamo  el form
                        FrmTotalComprado.ShowDialog()

                        'limpio el datagrid
                        DataGridView2.ClearSelection()
                        DataGridView2.DataSource = Nothing
                        DataGridView2.Columns.Clear()

                    End Using
                Catch ex As Exception
                    MessageBox.Show("No hay datos en el numero consultado. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If
            'manejo del cursor
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("No hay datos en el numero consultado. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtBuscar.Enabled = False
            Me.TxtBuscar.Clear()
            Me.BtnBuscar.Enabled = False
            Me.BtnLimpiar.Enabled = True

            'UBICO EL CURSOR
            Me.BtnLimpiar.Select()
            Me.BtnLimpiar.Focus()
        End Try

    End Sub

    'PROCESO SELECCIONA MATERIAL PLATA
    Private Sub EscojeMaterialPlata()
        Try
            'manejo del cursor
            Me.Cursor = Cursors.WaitCursor

            If Me.TxtBuscar.Text = "" Then
                MsgBox("No se encontro ningún Registro de Ingreso, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")
                'limpio y ubico el cursor
            Else
                Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
                Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
                Dim ANU As String = "ANULADO"
                Dim NumCedu As Integer
                NumCedu = Me.TxtBuscar.Text
                Dim num As String = "3"
                Try
                    Using conn As New OleDbConnection(cs)
                        Dim cmd As OleDbCommand = conn.CreateCommand()
                        'Indicamos la consulta que vamos a ejecutar
                        cmd.CommandText = "SELECT * FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlata = '" & num & "' AND cedu_com = " & NumCedu
                        Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                        With da.SelectCommand.Parameters
                            .AddWithValue("@starDate", hugh)
                            .AddWithValue("@endDate", hugh2)
                        End With
                        Dim dt As New DataTable("Declara")
                        da.Fill(dt)
                        DataGridView2.DataSource = dt
                        'muestro la cantidad de registros encontrados
                        LblModReg.Text = dt.Rows.Count
                        MessageBox.Show("Busqueda Encontrada, Aceptar para Continuar. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'DATOS DEL CLIENTES
                        FrmTotalComprado.TxtMaterial.Text = TxtMetal.Text
                        FrmTotalComprado.Txtced_cl.Text = DataGridView2.CurrentRow.Cells(1).Value
                        FrmTotalComprado.TxtNomApe.Text = DataGridView2.CurrentRow.Cells(2).Value
                        FrmTotalComprado.LblModReg.Text = LblModReg.Text
                        FrmTotalComprado.TxtMaterial.Text = "PLATA"

                        'desactivo el datagrid
                        Me.DataGridView2.Enabled = False

                        'DESHABILITO LOS BOTONES
                        Me.BtnBuscar.Enabled = False
                        Me.BtnLimpiar.Enabled = True

                        Me.TxtBuscar.Enabled = False

                        'llamo  el form
                        FrmTotalComprado.ShowDialog()

                        'limpio el datagrid
                        DataGridView2.ClearSelection()
                        DataGridView2.DataSource = Nothing
                        DataGridView2.Columns.Clear()

                    End Using
                Catch ex As Exception
                    MessageBox.Show("No hay datos en el numero consultado. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If
            'manejo del cursor
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("No hay datos en el numero consultado. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtBuscar.Enabled = False
            Me.TxtBuscar.Clear()
            Me.BtnBuscar.Enabled = False
            Me.BtnLimpiar.Enabled = True

            'UBICO EL CURSOR
            Me.BtnLimpiar.Select()
            Me.BtnLimpiar.Focus()
        End Try

    End Sub

    '=======================================================

    'PRUEBA DE ORO, PLATINO Y PLATA
    Private Sub LlenaMaterialOro()
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        If Me.TxtBuscar.Text = "" Then
            MessageBox.Show("Debe digitar un Número de Cédula.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'limpio y ubico el cursor
            Me.Panel2.Select()
            Me.GroupBox3.Select()
            Me.BtnBuscar.Enabled = True
            Me.BtnLimpiar.Enabled = True
            Me.TxtBuscar.Enabled = True
            Me.TxtBuscar.Clear()
            Me.TxtBuscar.Select()
            Me.TxtBuscar.Focus()
        Else
            Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
            Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
            Dim ANU As String = "ANULADO"
            Dim NumCedu As Integer
            NumCedu = Me.TxtBuscar.Text
            Dim num As String = "1"
            Try
                Using conn As New OleDbConnection(cs)
                    Dim cmd As OleDbCommand = conn.CreateCommand()
                    'Indicamos la consulta que vamos a ejecutar
                    cmd.CommandText = "SELECT * FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comOro = '" & num & "' AND cedu_com = " & NumCedu
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                    With da.SelectCommand.Parameters
                        .AddWithValue("@starDate", hugh)
                        .AddWithValue("@endDate", hugh2)
                    End With
                    Dim dt As New DataTable("Declara")
                    da.Fill(dt)
                    DataGridView2.DataSource = dt
                    'muestro la cantidad de registros encontrados
                    LblModReg.Text = dt.Rows.Count

                    If DataGridView2.Rows.Count = 0 Then
                        MessageBox.Show("No hay datos en el numero consultado. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Panel2.Select()
                        Me.GroupBox3.Select()
                        Me.BtnBuscar.Enabled = False
                        Me.BtnLimpiar.Enabled = True
                        Me.TxtBuscar.Enabled = False
                        Me.TxtBuscar.Clear()
                        Me.TxtBuscar.Select()
                        Me.BtnLimpiar.Focus()
                        'limpio los checkbox
                        Me.ChkOro.CheckState = CheckState.Unchecked
                        Me.ChkPlatino.CheckState = CheckState.Unchecked
                        Me.ChkPlata.CheckState = CheckState.Unchecked
                        'limpio el datagrid
                        DataGridView2.ClearSelection()
                        DataGridView2.DataSource = Nothing
                        DataGridView2.Columns.Clear()
                    Else
                        MessageBox.Show("Busqueda Encontrada, Aceptar para Continuar. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'DATOS DEL CLIENTES
                        FrmTotalComprado.TxtMaterial.Text = TxtMetal.Text
                        FrmTotalComprado.Txtced_cl.Text = DataGridView2.CurrentRow.Cells(1).Value
                        FrmTotalComprado.TxtNomApe.Text = DataGridView2.CurrentRow.Cells(2).Value
                        FrmTotalComprado.LblModReg.Text = LblModReg.Text
                        FrmTotalComprado.TxtMaterial.Text = "ORO"

                        'desactivo el datagrid
                        Me.DataGridView2.Enabled = False

                        'DESHABILITO LOS BOTONES
                        Me.BtnBuscar.Enabled = False
                        Me.BtnLimpiar.Enabled = True
                        Me.TxtBuscar.Enabled = False

                        'llamo  el form
                        FrmTotalComprado.ShowDialog()

                        'limpio el datagrid
                        DataGridView2.ClearSelection()
                        DataGridView2.DataSource = Nothing
                        DataGridView2.Columns.Clear()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("No hay datos en el numero consultado. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Panel2.Select()
                Me.GroupBox3.Select()
                Me.BtnBuscar.Enabled = True
                Me.BtnLimpiar.Enabled = True
                Me.TxtBuscar.Enabled = True
                Me.TxtBuscar.Clear()
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Focus()
            End Try
            'manejo del cursor
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LlenaMaterialPlatino()
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        If Me.TxtBuscar.Text = "" Then
            MsgBox("No se encontro ningún Registro, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")
            'limpio y ubico el cursor
            Me.Panel2.Select()
            Me.GroupBox3.Select()
            Me.BtnBuscar.Enabled = False
            Me.BtnLimpiar.Enabled = True
            Me.TxtBuscar.Enabled = False
            Me.TxtBuscar.Clear()
            Me.TxtBuscar.Select()
            Me.BtnLimpiar.Focus()
            'limpio los checkbox
            Me.ChkOro.CheckState = CheckState.Unchecked
            Me.ChkPlatino.CheckState = CheckState.Unchecked
            Me.ChkPlata.CheckState = CheckState.Unchecked
            'limpio el datagrid
            DataGridView2.ClearSelection()
            DataGridView2.DataSource = Nothing
            DataGridView2.Columns.Clear()
        Else
            Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
            Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
            Dim ANU As String = "ANULADO"
            Dim NumCedu As Integer
            NumCedu = Me.TxtBuscar.Text
            Dim num As String = "2"
            Try
                Using conn As New OleDbConnection(cs)
                    Dim cmd As OleDbCommand = conn.CreateCommand()
                    'Indicamos la consulta que vamos a ejecutar
                    cmd.CommandText = "SELECT * FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlatino = '" & num & "' AND cedu_com = " & NumCedu
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                    With da.SelectCommand.Parameters
                        .AddWithValue("@starDate", hugh)
                        .AddWithValue("@endDate", hugh2)
                    End With
                    Dim dt As New DataTable("Declara")
                    da.Fill(dt)
                    DataGridView2.DataSource = dt
                    'muestro la cantidad de registros encontrados
                    LblModReg.Text = dt.Rows.Count

                    If DataGridView2.Rows.Count = 0 Then
                        MessageBox.Show("No hay datos en el numero consultado. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Panel2.Select()
                        Me.GroupBox3.Select()
                        Me.BtnBuscar.Enabled = True
                        Me.BtnLimpiar.Enabled = True
                        Me.TxtBuscar.Enabled = True
                        Me.TxtBuscar.Clear()
                        Me.TxtBuscar.Select()
                        Me.TxtBuscar.Focus()
                    Else
                        MessageBox.Show("Busqueda Encontrada, Aceptar para Continuar. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'DATOS DEL CLIENTES
                        FrmTotalComprado.TxtMaterial.Text = TxtMetal.Text
                        FrmTotalComprado.Txtced_cl.Text = DataGridView2.CurrentRow.Cells(1).Value
                        FrmTotalComprado.TxtNomApe.Text = DataGridView2.CurrentRow.Cells(2).Value
                        FrmTotalComprado.LblModReg.Text = LblModReg.Text
                        FrmTotalComprado.TxtMaterial.Text = "PLATINO"

                        'desactivo el datagrid
                        Me.DataGridView2.Enabled = False

                        'DESHABILITO LOS BOTONES
                        Me.BtnBuscar.Enabled = False
                        Me.BtnLimpiar.Enabled = True
                        Me.TxtBuscar.Enabled = False

                        'llamo  el form
                        FrmTotalComprado.ShowDialog()

                        'limpio el datagrid
                        DataGridView2.ClearSelection()
                        DataGridView2.DataSource = Nothing
                        DataGridView2.Columns.Clear()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("No hay datos en el numero consultado. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Panel2.Select()
                Me.GroupBox3.Select()
                Me.BtnBuscar.Enabled = True
                Me.BtnLimpiar.Enabled = True
                Me.TxtBuscar.Enabled = True
                Me.TxtBuscar.Clear()
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Focus()
            End Try
            'manejo del cursor
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LlenaMaterialPlata()
        'manejo del cursor
        Me.Cursor = Cursors.WaitCursor

        If Me.TxtBuscar.Text = "" Then
            MsgBox("No se encontro ningún Registro, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")
            'limpio y ubico el cursor
            Me.Panel2.Select()
            Me.GroupBox3.Select()
            Me.BtnBuscar.Enabled = False
            Me.BtnLimpiar.Enabled = True
            Me.TxtBuscar.Enabled = False
            Me.TxtBuscar.Clear()
            Me.TxtBuscar.Select()
            Me.BtnLimpiar.Focus()
            'limpio los checkbox
            Me.ChkOro.CheckState = CheckState.Unchecked
            Me.ChkPlatino.CheckState = CheckState.Unchecked
            Me.ChkPlata.CheckState = CheckState.Unchecked
            'limpio el datagrid
            DataGridView2.ClearSelection()
            DataGridView2.DataSource = Nothing
            DataGridView2.Columns.Clear()
        Else
            Dim hugh As Date = CStr(Me.DTPinicial.Value.Date)
            Dim hugh2 As Date = CStr(Me.DTPfinal.Value.Date)
            Dim ANU As String = "ANULADO"
            Dim NumCedu As Integer
            NumCedu = Me.TxtBuscar.Text
            Dim num As String = "3"
            Try
                Using conn As New OleDbConnection(cs)
                    Dim cmd As OleDbCommand = conn.CreateCommand()
                    'Indicamos la consulta que vamos a ejecutar
                    cmd.CommandText = "SELECT * FROM Declara WHERE fecha_creado BETWEEN @starDate AND @enddate AND comPlata = '" & num & "' AND cedu_com = " & NumCedu
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                    With da.SelectCommand.Parameters
                        .AddWithValue("@starDate", hugh)
                        .AddWithValue("@endDate", hugh2)
                    End With
                    Dim dt As New DataTable("Declara")
                    da.Fill(dt)
                    DataGridView2.DataSource = dt
                    'muestro la cantidad de registros encontrados
                    LblModReg.Text = dt.Rows.Count

                    If DataGridView2.Rows.Count = 0 Then
                        MessageBox.Show("No hay datos en el numero consultado. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Panel2.Select()
                        Me.GroupBox3.Select()
                        Me.BtnBuscar.Enabled = True
                        Me.BtnLimpiar.Enabled = True
                        Me.TxtBuscar.Enabled = True
                        Me.TxtBuscar.Clear()
                        Me.TxtBuscar.Select()
                        Me.TxtBuscar.Focus()
                    Else
                        MessageBox.Show("Busqueda Encontrada, Aceptar para Continuar. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'DATOS DEL CLIENTES
                        FrmTotalComprado.TxtMaterial.Text = TxtMetal.Text
                        FrmTotalComprado.Txtced_cl.Text = DataGridView2.CurrentRow.Cells(1).Value
                        FrmTotalComprado.TxtNomApe.Text = DataGridView2.CurrentRow.Cells(2).Value
                        FrmTotalComprado.LblModReg.Text = LblModReg.Text
                        FrmTotalComprado.TxtMaterial.Text = "PLATA"

                        'desactivo el datagrid
                        Me.DataGridView2.Enabled = False

                        'DESHABILITO LOS BOTONES
                        Me.BtnBuscar.Enabled = False
                        Me.BtnLimpiar.Enabled = True
                        Me.TxtBuscar.Enabled = False

                        'llamo  el form
                        FrmTotalComprado.ShowDialog()

                        'limpio el datagrid
                        DataGridView2.ClearSelection()
                        DataGridView2.DataSource = Nothing
                        DataGridView2.Columns.Clear()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("No hay datos en el numero consultado. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Panel2.Select()
                Me.GroupBox3.Select()
                Me.BtnBuscar.Enabled = True
                Me.BtnLimpiar.Enabled = True
                Me.TxtBuscar.Enabled = True
                Me.TxtBuscar.Clear()
                Me.TxtBuscar.Select()
                Me.TxtBuscar.Focus()
            End Try
            'manejo del cursor
            Me.Cursor = Cursors.Default
        End If
    End Sub


    '=======================================================

    'BOTON DE LIMPIAR
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        'limpio el datagrid
        DataGridView2.ClearSelection()
        DataGridView2.DataSource = Nothing
        DataGridView2.Columns.Clear()

        'ubico el cursor
        Me.GroupBox3.Select()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Enabled = True
        Me.TxtBuscar.Text = ""
        Me.TxtBuscar.Focus()

        'habilito los botones
        Me.BtnBuscar.Enabled = True
        Me.BtnLimpiar.Enabled = True

        Me.LblModReg.Text = ""

        ChkOro.Checked = CheckState.Unchecked
        ChkPlatino.Checked = CheckState.Unchecked
        ChkPlata.Checked = CheckState.Unchecked

        Me.TxtMetal.Clear()
        Me.TxtCedula.Clear()

    End Sub

    'BOTON CERRAR FORM
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL FORMULARIO"

    'VALIDA SOLO NUMEROS
    Private Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress
        'activa el campo enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

        SoloNumeros(e)
    End Sub

#End Region

#Region "DATAGRIDVIEW"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS - DECLARA
    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting

        'activo el datagrid
        Me.DataGridView2.Enabled = True

        'deshabilita el efecto visual de windows

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

            Me.DataGridView2.Columns(1).Width = 120
            Me.DataGridView2.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DataGridView2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DataGridView2.Columns(2).Width = 240
            Me.DataGridView2.Columns(2).HeaderText = "Nombre Completo"
            Me.DataGridView2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DataGridView2.Columns(3).Width = 100
            Me.DataGridView2.Columns(3).HeaderText = "Fecha de Compra"
            Me.DataGridView2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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
            Me.DataGridView2.Columns("metal_com").Visible = False       '10
            Me.DataGridView2.Columns("conce_com").Visible = False       '11
            Me.DataGridView2.Columns("ciuddpto").Visible = False        '12
            Me.DataGridView2.Columns("grbrutos").Visible = False        '13
            Me.DataGridView2.Columns("ley").Visible = False             '14
            Me.DataGridView2.Columns("grpuros").Visible = False         '15
            Me.DataGridView2.Columns("base").Visible = False            '16
            Me.DataGridView2.Columns("regala").Visible = False          '17
            Me.DataGridView2.Columns("totalretef").Visible = False      '18
            Me.DataGridView2.Columns("vrventa").Visible = False         '19
            Me.DataGridView2.Columns("fechatasa").Visible = False       '20
            Me.DataGridView2.Columns("mestasa").Visible = False         '21
            Me.DataGridView2.Columns("retevalor").Visible = False       '22
            Me.DataGridView2.Columns("gp_rg").Visible = False           '23
            Me.DataGridView2.Columns("gp_base").Visible = False         '24
            Me.DataGridView2.Columns("valorgrrete").Visible = False     '25
            Me.DataGridView2.Columns("pagobare").Visible = False        '26
            Me.DataGridView2.Columns("mes_com").Visible = False         '27
            Me.DataGridView2.Columns("año_com").Visible = False         '28
            Me.DataGridView2.Columns("consecutivo").Visible = True      '29
            Me.DataGridView2.Columns("fecha_creado").Visible = False    '30
            Me.DataGridView2.Columns("fecha_modifica").Visible = False  '31
            Me.DataGridView2.Columns("letras").Visible = False          '32
            Me.DataGridView2.Columns("detallemineral").Visible = False  '33
            Me.DataGridView2.Columns("verifica").Visible = False        '34
            Me.DataGridView2.Columns("numfundi").Visible = False        '35
            Me.DataGridView2.Columns("formapago").Visible = False       '36
            Me.DataGridView2.Columns("numtarjeta").Visible = False      '37
            Me.DataGridView2.Columns("selebancos").Visible = False      '38
            Me.DataGridView2.Columns("prefijo").Visible = False         '39
            Me.DataGridView2.Columns("ConseQr").Visible = False         '40
            Me.DataGridView2.Columns("tipoop").Visible = False          '41
            Me.DataGridView2.Columns("tipodocu").Visible = False        '42
            Me.DataGridView2.Columns("comOro").Visible = False          '43
            Me.DataGridView2.Columns("comPlatino").Visible = False      '44
            Me.DataGridView2.Columns("comPlata").Visible = False        '45
            Me.DataGridView2.Columns("ciudad").Visible = False          '46
            Me.DataGridView2.Columns("dpto").Visible = False            '47
        End With

    End Sub

#End Region

End Class
