Imports System.Data.OleDb

Public Class FrmSeleEgresos

    'CARGUE DEL FORMULARIO
    Private Sub FrmSeleAse1Egresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.Panel3.Select()
        Me.TxtDocEgreso.Select()
        Me.TxtDocEgreso.Clear()
        Me.TxtDocEgreso.Focus()
        Me.TxtDocEgreso.Enabled = True

        'limpio el datagrid
        Me.DGVreimpEgreso.ClearSelection()
        Me.DGVreimpEgreso.DataSource = Nothing
        Me.DGVreimpEgreso.Columns.Clear()

        'activo los botones
        Me.BtnDocEgreso.Enabled = True

        VerCiudad()

    End Sub

    'FUNCION DE FILTRAR NUMERO DE DOCUMENTO DE INGRESO
    Function FiltroCaja(ByVal busqueda As String) As DataTable
        conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim NumeroEgreso As Integer = TxtDocEgreso.Text
        Dim da As New OleDbDataAdapter("SELECT * FROM CajamenorAse1 WHERE numpago = " & NumeroEgreso, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("CajamenorAse1")
        DGVreimpEgreso.DataSource = dv
        conn.Close()
        Return dt
    End Function

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
        Else
            MsgBox("No se encontro CIUDAD", MsgBoxStyle.Information, "AppMinerGold")
        End If
        drd.Close()
        Conectar.conn.Close()
    End Sub

#Region "DATAGRIDVIEW EGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVreimpEgreso_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpEgreso.CellFormatting

        'activo el datagrid
        Me.DGVreimpEgreso.Enabled = False

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpEgreso.RowsDefaultCellStyle
            Me.DGVreimpEgreso.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpEgreso.Columns(0).Width = 40
            Me.DGVreimpEgreso.Columns(0).HeaderText = "Id"

            Me.DGVreimpEgreso.Columns(1).Width = 80
            Me.DGVreimpEgreso.Columns(1).HeaderText = "Cédula del Cliente"
            Me.DGVreimpEgreso.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpEgreso.Columns(2).Width = 150
            Me.DGVreimpEgreso.Columns(2).HeaderText = "Nombre del Cliente"
            Me.DGVreimpEgreso.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpEgreso.Columns(10).Width = 90
            Me.DGVreimpEgreso.Columns(10).HeaderText = "Fecha del Pago"
            Me.DGVreimpEgreso.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpEgreso.Columns(11).Width = 70
            Me.DGVreimpEgreso.Columns(11).HeaderText = "No. Documento Ingreso"
            Me.DGVreimpEgreso.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpEgreso.Columns(9).Width = 90
            Me.DGVreimpEgreso.Columns(9).HeaderText = "Valor Ingreso"
            Me.DGVreimpEgreso.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.DGVreimpEgreso.Columns(9).DefaultCellStyle.Format = "c"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVreimpEgreso.Columns("nomciud").Visible = False
            Me.DGVreimpEgreso.Columns("nompagado").Visible = False
            Me.DGVreimpEgreso.Columns("conce_pre").Visible = False
            Me.DGVreimpEgreso.Columns("vrprestamo").Visible = False
            Me.DGVreimpEgreso.Columns("fechaactual_pre").Visible = False
            Me.DGVreimpEgreso.Columns("numpresta").Visible = False
            Me.DGVreimpEgreso.Columns("fecha_creado").Visible = False
            Me.DGVreimpEgreso.Columns("fecha_modifica").Visible = False
            Me.DGVreimpEgreso.Columns("vrsaldo").Visible = False
            Me.DGVreimpEgreso.Columns("conce_pago").Visible = False
            Me.DGVreimpEgreso.Columns("cedupagado").Visible = False

        End With

    End Sub

#End Region

    'BOTON DE BUSCAR EGRESOS
    Private Sub BtnDocEgreso_Click(sender As Object, e As EventArgs) Handles BtnDocEgreso.Click
        Me.TxtDocEgreso.Enabled = False
        Try
            'lleno los datos al datagrid
            If FiltroCaja(Me.TxtDocEgreso.Text).Rows.Count > 0 Then
                DGVreimpEgreso.DataSource = FiltroCaja(Me.TxtDocEgreso.Text)
                MessageBox.Show("Busqueda Encontrada, Aceptar para Imprimir", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ModuleFrm.VerCiudad = Me.TxtEmpCiu.Text

                FrmRptEg.TxtNumEgreso.Text = Me.TxtDocEgreso.Text
                FrmRptEg.ShowDialog()

                'Inhabilito el boton
                Me.BtnDocEgreso.Enabled = False
                Me.BtnX.Focus()
            Else
                MessageBox.Show("No se encontro ningún Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'limpio y ubico el cursor
                Me.Panel3.Select()
                Me.TxtDocEgreso.Select()
                Me.TxtDocEgreso.Text = ""
                Me.TxtDocEgreso.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("No existe Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'limpio y ubico el cursor
            Me.Panel3.Select()
            Me.TxtDocEgreso.Select()
            Me.TxtDocEgreso.Text = ""
            Me.TxtDocEgreso.Focus()
        End Try
    End Sub

    'VALIDA TEXTO NUMERICO
    Private Sub TxtDocEgreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocEgreso.KeyPress
        SoloNumeros(e)
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class