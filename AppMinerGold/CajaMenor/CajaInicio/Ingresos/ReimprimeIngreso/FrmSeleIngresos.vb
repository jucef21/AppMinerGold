Imports System.Data.OleDb

Public Class FrmSeleIngresos

    'CARGUE DEL FORMULARIO
    Private Sub FrmSeleAse1Ingresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.TxtDocIngreso.Clear()
        Me.TxtDocIngreso.Focus()
        Me.TxtDocIngreso.Enabled = True

        'limpio el datagrid
        Me.DGVreimpIng.ClearSelection()
        Me.DGVreimpIng.DataSource = Nothing
        Me.DGVreimpIng.Columns.Clear()
        Me.DGVreimpIng.Enabled = True

        'activo los botones
        Me.BtnDocIngreso.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.Panel2.Focus()
        Me.TxtDocIngreso.Select()
        Me.TxtDocIngreso.Focus()
        TxtDocIngreso.Clear()

    End Sub

    'BOTON DE  DE DOCUEMNTO DE INGRESO
    Private Sub BtnDocIngreso_Click(sender As Object, e As EventArgs) Handles BtnDocIngreso.Click
        Try
            'lleno los datos al datagrid
            If FiltroCaja(Me.TxtDocIngreso.Text).Rows.Count > 0 Then
                DGVreimpIng.DataSource = FiltroCaja(Me.TxtDocIngreso.Text)
                MsgBox("Busqueda Encontrada, Aceptar para Imprimir", MsgBoxStyle.Information, "AppMinerGold")

                'llamo  el form
                'FrmRptIng.Show()

                FrmRptImpIngreso.TxtNumIngreso.Text = Me.TxtDocIngreso.Text
                FrmRptImpIngreso.ShowDialog()

                'Inhabilito el boton
                Me.TxtDocIngreso.Enabled = False
                Me.DGVreimpIng.Enabled = False
                Me.BtnDocIngreso.Enabled = False

            Else
                MsgBox("No se encontro ningún Registro de Ingreso, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")
                'limpio y ubico el cursor
                Me.TxtDocIngreso.Text = ""
                Me.TxtDocIngreso.Focus()
            End If
        Catch ex As Exception
            MsgBox("No existe Registro de Ingreso, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")
            'limpio y ubico el cursor
            Me.TxtDocIngreso.Text = ""
            Me.TxtDocIngreso.Focus()
        End Try

    End Sub

    'FUNCION DE FILTRAR NUMERO DE DOCUMENTO DE INGRESO
    Function FiltroCaja(ByVal busqueda As String) As DataTable
        conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        'Dim da As New OleDbDataAdapter("SELECT TOP 1 * FROM Clientes WHERE nom_cl LIKE '" & busqueda.Trim & "%' ORDER BY id DESC", conn)
        Dim da As New OleDbDataAdapter("SELECT * FROM CajamenorAse1 WHERE numpresta LIKE '" & busqueda.Trim & "%' ", conn)
        da.Fill(dt)
        dv.Table = ds.Tables("CajamenorAse1")
        DGVreimpIng.DataSource = dv
        conn.Close()
        Return dt
    End Function

#Region "DATAGRIDVIEW INGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVreimpIng_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpIng.CellFormatting

        'activo el datagrid
        Me.DGVreimpIng.Enabled = False

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpIng.RowsDefaultCellStyle
            Me.DGVreimpIng.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpIng.Columns(0).Width = 40
            Me.DGVreimpIng.Columns(0).HeaderText = "Id"

            Me.DGVreimpIng.Columns(1).Width = 80
            Me.DGVreimpIng.Columns(1).HeaderText = "Cédula del Cliente"
            Me.DGVreimpIng.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpIng.Columns(2).Width = 150
            Me.DGVreimpIng.Columns(2).HeaderText = "Nombre del Cliente"
            Me.DGVreimpIng.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpIng.Columns(3).Width = 90
            Me.DGVreimpIng.Columns(3).HeaderText = "Fecha del Ingreso"
            Me.DGVreimpIng.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpIng.Columns(4).Width = 70
            Me.DGVreimpIng.Columns(4).HeaderText = "No. Documento Ingreso"
            Me.DGVreimpIng.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpIng.Columns(8).Width = 90
            Me.DGVreimpIng.Columns(8).HeaderText = "Valor Ingreso"
            Me.DGVreimpIng.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVreimpIng.Columns(8).DefaultCellStyle.Format = "c"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVreimpIng.Columns("nomciud").Visible = False
            Me.DGVreimpIng.Columns("nompagado").Visible = False
            Me.DGVreimpIng.Columns("conce_pre").Visible = False
            Me.DGVreimpIng.Columns("vrpagado").Visible = False
            Me.DGVreimpIng.Columns("fechapago").Visible = False
            Me.DGVreimpIng.Columns("numpago").Visible = False
            Me.DGVreimpIng.Columns("fecha_creado").Visible = False
            Me.DGVreimpIng.Columns("fecha_modifica").Visible = False
            Me.DGVreimpIng.Columns("vrsaldo").Visible = False
            Me.DGVreimpIng.Columns("conce_pago").Visible = False
            Me.DGVreimpIng.Columns("cedupagado").Visible = False

        End With

    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


End Class