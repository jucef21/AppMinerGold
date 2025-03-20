Imports System.Data.OleDb
Public Class FrmSeleReimpDocTrasladaPlatino

    'CARGUE DEL FORMULARIO
    Private Sub FrmSeleReimpDocTrasladaPlatino_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.TxtDocIngreso.Clear()
        Me.TxtDocIngreso.Focus()
        Me.TxtDocIngreso.Enabled = True

        'limpio el datagrid
        Me.DGVreimpEqui.ClearSelection()
        Me.DGVreimpEqui.DataSource = Nothing
        Me.DGVreimpEqui.Columns.Clear()
        Me.DGVreimpEqui.Enabled = True

        'activo los botones
        Me.BtnDocIngreso.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.Panel2.Focus()
        Me.TxtDocIngreso.Select()
        Me.TxtDocIngreso.Focus()

    End Sub

    'BOTON DE  DE DOCUEMNTO DE INGRESO
    Private Sub BtnDocIngreso_Click(sender As Object, e As EventArgs) Handles BtnDocIngreso.Click
        Try
            'manejo del cursoer
            Me.Cursor = Cursors.WaitCursor

            'lleno los datos al datagrid
            If FiltroDeclara(Me.TxtDocIngreso.Text).Rows.Count > 0 Then
                DGVreimpEqui.DataSource = FiltroDeclara(Me.TxtDocIngreso.Text)
                MessageBox.Show("Busqueda Encontrada, Aceptar para Imprimir", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Envio el numero de docuemnto buscado al reporte
                FrmRptFundiTraslada_Platino.TxtDocFundiPlatino.Text = TxtDocIngreso.Text
                FrmRptFundiTraslada_Platino.TxtMetales.Text = "PLATINO"
                FrmRptFundiTraslada_Platino.ShowDialog()

                'Inhabilito el boton
                Me.TxtDocIngreso.Enabled = False
                Me.DGVreimpEqui.Enabled = False
                Me.BtnDocIngreso.Enabled = False

            Else
                MessageBox.Show("No se encontro ningún Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'limpio y ubico el cursor
                Me.TxtDocIngreso.Text = ""
                Me.TxtDocIngreso.Select()
                Me.TxtDocIngreso.Focus()
            End If

            'manejo del cursoer
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show("Error en la busqueda de Documento de Ingreso, " & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'limpio y ubico el cursor
            Me.TxtDocIngreso.Text = ""
            Me.TxtDocIngreso.Select()
            Me.TxtDocIngreso.Focus()
        End Try

    End Sub

    'FUNCION DE FILTRAR NUMERO DE DOCUMENTO DE INGRESO
    Function FiltroDeclara(ByVal busqueda As String) As DataTable
        conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim NumDoc As String = TxtDocIngreso.Text
        Dim da As New OleDbDataAdapter("SELECT * FROM Fundicion WHERE tipometal = 'PLATINO' AND numdocufundi =" + NumDoc, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Fundicion")
        DGVreimpEqui.DataSource = dv
        conn.Close()
        Return dt
    End Function

#Region "DATAGRIDVIEW INGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVreimpEqui_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpEqui.CellFormatting

        'activo el datagrid
        Me.DGVreimpEqui.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVreimpEqui.EnableHeadersVisualStyles = False
        With DGVreimpEqui.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpEqui.RowsDefaultCellStyle
            Me.DGVreimpEqui.Columns(0).Width = 70
            Me.DGVreimpEqui.Columns(0).HeaderText = "Id"
            Me.DGVreimpEqui.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpEqui.Columns(1).Width = 100
            Me.DGVreimpEqui.Columns(1).HeaderText = "N° Documento"
            Me.DGVreimpEqui.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpEqui.Columns(2).Width = 150
            Me.DGVreimpEqui.Columns(2).HeaderText = "Fecha Traslado"
            Me.DGVreimpEqui.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpEqui.Columns(3).Width = 100
            Me.DGVreimpEqui.Columns(3).HeaderText = "Metal"
            Me.DGVreimpEqui.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpEqui.Columns(5).Width = 130
            Me.DGVreimpEqui.Columns(5).HeaderText = "Gramos Brutos"
            Me.DGVreimpEqui.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpEqui.Columns(5).DefaultCellStyle.Format = "N2"

            Me.DGVreimpEqui.Columns(6).Width = 80
            Me.DGVreimpEqui.Columns(6).HeaderText = "Ley"
            Me.DGVreimpEqui.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpEqui.Columns(6).DefaultCellStyle.Format = "N4"

            Me.DGVreimpEqui.Columns(7).Width = 130
            Me.DGVreimpEqui.Columns(7).HeaderText = "Gramos Puros"
            Me.DGVreimpEqui.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DGVreimpEqui.Columns(7).DefaultCellStyle.Format = "N2"

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            Me.DGVreimpEqui.Columns("Id").Visible = True                      '1
            Me.DGVreimpEqui.Columns("numdocufundi").Visible = True            '2
            Me.DGVreimpEqui.Columns("fechaactualfundi").Visible = True        '3
            Me.DGVreimpEqui.Columns("tipometal").Visible = True               '4
            Me.DGVreimpEqui.Columns("brutosfundi").Visible = True             '5
            Me.DGVreimpEqui.Columns("leyfundi").Visible = True                '6
            Me.DGVreimpEqui.Columns("purosfundi").Visible = True              '7
            Me.DGVreimpEqui.Columns("fundicompra").Visible = False            '8
            Me.DGVreimpEqui.Columns("fundiventa").Visible = False             '9
            Me.DGVreimpEqui.Columns("vrsaldosbrutos").Visible = False         '10
            Me.DGVreimpEqui.Columns("vrsaldosley").Visible = False            '11
            Me.DGVreimpEqui.Columns("vrsaldospuros").Visible = False          '12
            Me.DGVreimpEqui.Columns("fecha_creado").Visible = False           '13
            Me.DGVreimpEqui.Columns("fecha_modifica").Visible = False         '14

        End With

    End Sub

    Private Sub TxtDocIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocIngreso.KeyPress
        SoloNumeros(e)
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

#End Region


End Class