Imports System.Data.OleDb

Public Class FrmSeleEliminaEgreso

    'CARGUE DEL FORM
    Private Sub FrmSeleEliminaEgreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.TxtDocIngreso.Clear()
        Me.TxtDocIngreso.Enabled = True
        Me.TxtDocIngreso.Focus()

        'limpio el datagrid
        Me.DGVeliminaEgreso.ClearSelection()
        Me.DGVeliminaEgreso.DataSource = Nothing
        Me.DGVeliminaEgreso.Columns.Clear()
        Me.DGVeliminaEgreso.Enabled = True

        'activo los botones
        Me.BtnDocIngreso.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.Panel2.Focus()
        Me.TxtDocIngreso.Select()
        Me.TxtDocIngreso.Focus()

    End Sub

#Region "BOTONES DEL FORM"

    'BOTON DE  DE DOCUMENTO DE INGRESO
    Private Sub BtnDocIngreso_Click(sender As Object, e As EventArgs) Handles BtnDocIngreso.Click
        'manejo de cursor
        Me.Cursor = Cursors.WaitCursor
        Try
            'lleno los datos al datagrid
            If FiltroDeclara(Me.TxtDocIngreso.Text).Rows.Count > 0 Then
                DGVeliminaEgreso.DataSource = FiltroDeclara(Me.TxtDocIngreso.Text)

                'LIMPIO
                FrmEliminaEgreso.TxtControlPago.Text = Me.TxtDocIngreso.Text

                'Inhabilito el boton
                Me.TxtDocIngreso.Enabled = False
                Me.DGVeliminaEgreso.Enabled = False
                Me.BtnDocIngreso.Enabled = False

            Else
                MsgBox("No se encontro ningún Registro de Ingreso, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")

                'LIMPIO
                Me.TxtDocIngreso.Clear()

                'Inhabilito el boton
                Me.TxtDocIngreso.Enabled = True
                Me.BtnDocIngreso.Enabled = True
                Me.DGVeliminaEgreso.Enabled = False

                'limpio y ubico el cursor
                Me.TxtDocIngreso.Text = ""
                Me.TxtDocIngreso.Select()
                Me.TxtDocIngreso.Focus()

            End If
        Catch ex As Exception
            MsgBox("No existe Registro de Ingreso, con el Número digitado", MsgBoxStyle.Information, "AppMinerGold")
            'Inhabilito el boton
            Me.TxtDocIngreso.Enabled = True
            Me.BtnDocIngreso.Enabled = True
            Me.DGVeliminaEgreso.Enabled = False

            'limpio y ubico el cursor
            Me.TxtDocIngreso.Text = ""
            Me.TxtDocIngreso.Select()
            Me.TxtDocIngreso.Focus()
        End Try

        'manejo de cursor
        Me.Cursor = Cursors.Default

    End Sub


    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region

#Region "PROCEDIMIENTOS DEL FORM"

    Function FiltroDeclara(ByVal busqueda As String) As DataTable
        conn.Open()
        Dim NumConse As Integer = CInt(Me.TxtDocIngreso.Text)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM CajamenorAse1 WHERE cedu_pre <> '" & 1111111111 & "' AND numpago = " & NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("CajamenorAse1")
        DGVeliminaEgreso.DataSource = dv
        conn.Close()
        Return dt
    End Function

#End Region

#Region "DATAGRIDVIEW INGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVreimpDec_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVeliminaEgreso.CellFormatting

        'activo el datagrid
        Me.DGVeliminaEgreso.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVeliminaEgreso.EnableHeadersVisualStyles = False
        With DGVeliminaEgreso.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVeliminaEgreso.RowsDefaultCellStyle
            Me.DGVeliminaEgreso.Columns(0).Width = 70
            Me.DGVeliminaEgreso.Columns(0).HeaderText = "Id"
            Me.DGVeliminaEgreso.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVeliminaEgreso.Columns(1).Width = 80
            Me.DGVeliminaEgreso.Columns(1).HeaderText = "Cédula"
            Me.DGVeliminaEgreso.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVeliminaEgreso.Columns(2).Width = 240
            Me.DGVeliminaEgreso.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVeliminaEgreso.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVeliminaEgreso.Columns(3).Width = 100
            Me.DGVeliminaEgreso.Columns(3).HeaderText = "Fecha"
            Me.DGVeliminaEgreso.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVeliminaEgreso.Columns(11).Width = 150
            Me.DGVeliminaEgreso.Columns(11).HeaderText = "Consecutivo"
            Me.DGVeliminaEgreso.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVreimpDec.Columns("Id").Visible = False                     '0
            'Me.DGVreimpDec.Columns("cedu_pre").Visible = False               '1
            'Me.DGVreimpDec.Columns("nom_pre").Visible = False                '2
            'Me.DGVreimpDec.Columns("fechaactual_pre").Visible = False        '3
            Me.DGVeliminaEgreso.Columns("numpresta").Visible = False          '4
            Me.DGVeliminaEgreso.Columns("nomciud").Visible = False            '5
            Me.DGVeliminaEgreso.Columns("nompagado").Visible = False          '6
            Me.DGVeliminaEgreso.Columns("conce_pre").Visible = False          '7
            Me.DGVeliminaEgreso.Columns("vrprestamo").Visible = False         '8
            Me.DGVeliminaEgreso.Columns("vrpagado").Visible = False           '9
            Me.DGVeliminaEgreso.Columns("fechapago").Visible = False          '10
            'Me.DGVeliminaEgreso.Columns("numpago").Visible = False            '11
            Me.DGVeliminaEgreso.Columns("fecha_creado").Visible = False       '12
            Me.DGVeliminaEgreso.Columns("fecha_modifica").Visible = False     '13
            Me.DGVeliminaEgreso.Columns("vrsaldo").Visible = False            '14
            Me.DGVeliminaEgreso.Columns("conce_pago").Visible = False         '15
            Me.DGVeliminaEgreso.Columns("cedupagado").Visible = False         '16

        End With

    End Sub

    Private Sub DGVeliminaEgreso_CellDoubleClick(sender As Object, e As EventArgs) Handles DGVeliminaEgreso.CellDoubleClick

        FrmEliminaEgreso.Txtced_cl.Text = DGVeliminaEgreso.CurrentRow.Cells(1).Value
        FrmEliminaEgreso.TxtNomPaciente.Text = DGVeliminaEgreso.CurrentRow.Cells(2).Value

        FrmEliminaEgreso.TxtPagado.Text = DGVeliminaEgreso.CurrentRow.Cells(6).Value
        FrmEliminaEgreso.TxtCedPagado.Text = DGVeliminaEgreso.CurrentRow.Cells(16).Value
        FrmEliminaEgreso.TxtConcePago.Text = DGVeliminaEgreso.CurrentRow.Cells(15).Value
        FrmEliminaEgreso.TxtVrPagado.Text = DGVeliminaEgreso.CurrentRow.Cells(9).Value

        Dim FecPag As Date
        FecPag = Format(DGVeliminaEgreso.CurrentRow.Cells(10).Value, "Short Date")
        FrmEliminaEgreso.TxtFechaPago.Text = FecPag

        'creo la variable para preguntar sobre la atencion del paciente
        Dim resultA As DialogResult = MessageBox.Show("Desea Consultar al Cliente?, Si para Atención, No para regresar", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'CONSULTO SI DE DESEA ATENDER LA CONSULTA Y SI ES SI ABRIR FORM
        If resultA = DialogResult.Yes Then
            'muestro el cursor
            Me.Cursor = Cursors.WaitCursor

            'desactivo el datagrid
            Me.DGVeliminaEgreso.Enabled = False

            FrmEliminaEgreso.ShowDialog()

            'cierro la forma actual
            Me.Close()

            'Inhabilito el boton
            Me.TxtDocIngreso.Enabled = False
            Me.DGVeliminaEgreso.Enabled = False
            Me.DGVeliminaEgreso.Enabled = False

            'muestro el cursor
            Me.Cursor = Cursors.Default
        Else
            'ubico el cursor para definir el paciente que va atender
            Me.TxtDocIngreso.Select()
            Me.TxtDocIngreso.Focus()
        End If

        Me.BtnDocIngreso.Enabled = False
    End Sub

#End Region

#Region "EVENTO KEYPRESS"

    'TEXTO KEYPRESS
    Private Sub TxtDocIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocIngreso.KeyPress
        SoloNumeros(e)
    End Sub


#End Region


End Class