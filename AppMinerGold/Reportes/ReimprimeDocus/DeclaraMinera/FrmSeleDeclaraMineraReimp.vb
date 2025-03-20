Imports System.Data.OleDb

Public Class FrmSeleDeclaraMineraReimp

    'CARGUE DEL FORMULARIO
    Private Sub FrmSeleDeclaraMineraReimp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Conectar la base de datos
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'limpio los campos
        Me.TxtDocIngreso.Clear()
        Me.TxtDocIngreso.Enabled = True
        Me.TxtDocIngreso.Focus()

        'limpio el datagrid
        Me.DGVreimpDec.ClearSelection()
        Me.DGVreimpDec.DataSource = Nothing
        Me.DGVreimpDec.Columns.Clear()
        Me.DGVreimpDec.Enabled = True

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
        'manejo de cursor
        Me.Cursor = Cursors.WaitCursor

        Try
            'lleno los datos al datagrid
            If FiltroConse(TxtDocIngreso.Text).Rows.Count > 0 Then
                DGVreimpDec.DataSource = FiltroConse(TxtDocIngreso.Text)
                MessageBox.Show("Busqueda Encontrada, Aceptar para Imprimir", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Envio el numero de docuemnto buscado al reporte
                'FrmReimpDeclara.TxtConsecutivo.Text = TxtDocIngreso.Text
                'FrmReimpDeclara.TxtCedula.Text = DGVreimpDec.CurrentRow.Cells(1).Value
                'FrmReimpDeclara.ShowDialog()

                ''NUEVO FORMATO ANM
                'Dim FrmNuevo As New FrmReImpNuevoDeclara
                'FrmNuevo.TxtCedula.Text = DGVreimpDec.CurrentRow.Cells(1).Value
                'FrmNuevo.TxtConsecutivo.Text = TxtDocIngreso.Text
                'FrmNuevo.ShowDialog()

                'NUEVO FORMATO ANM TRIMESTRE
                Dim FrmANMTrim As New FrmRimpANMTrim
                FrmANMTrim.TxtCedula.Text = DGVreimpDec.CurrentRow.Cells(1).Value
                FrmANMTrim.TxtConsecutivo.Text = TxtDocIngreso.Text
                FrmANMTrim.ShowDialog()

                'Inhabilito el boton
                Me.TxtDocIngreso.Enabled = False
                Me.DGVreimpDec.Enabled = False

                Me.BtnDocIngreso.Enabled = False

            Else
                MessageBox.Show("No se encontro ningún Registro de Ingreso, con el Número digitado", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'limpio y ubico el cursor
                Me.TxtDocIngreso.Text = ""
                Me.TxtDocIngreso.Select()
                Me.TxtDocIngreso.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("No existe Registro de Ingreso, con el Número digitado" & ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'limpio y ubico el cursor
            Me.TxtDocIngreso.Text = ""
            Me.TxtDocIngreso.Select()
            Me.TxtDocIngreso.Focus()
        End Try

        'manejo de cursor
        Me.Cursor = Cursors.Default

    End Sub

    'FUNCION DE FILTRAR NUMERO DE DOCUMENTO DE INGRESO
    Function FiltroDeclara(ByVal busqueda As String) As DataTable
        conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim NumConse As String = Convert.ToInt32(TxtDocIngreso.Text)
        Dim Anu As String = "ANULADO"
        'Dim da As New OleDbDataAdapter("SELECT TOP 1 * FROM Clientes WHERE nom_cl LIKE '" & busqueda.Trim & "%' ORDER BY id DESC", conn)
        Dim da As New OleDbDataAdapter("SELECT * FROM Declara WHERE nom_com <> '" & Anu & "' AND consecutivo = " + NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Declara")
        DGVreimpDec.DataSource = dv
        conn.Close()
        Return dt
    End Function

    'FUNCION DE FILTRAR CEDULA DE UN DATAGRID
    Function FiltroConse(ByVal busqueda As String) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim NumConse As String = Convert.ToInt32(TxtDocIngreso.Text)
        Dim Anu As String = "ANULADO"
        Dim da As New OleDbDataAdapter("SELECT * FROM Declara WHERE nom_com <> '" & Anu & "' AND consecutivo = " + NumConse, conn)
        da.Fill(dt)
        dv.Table = ds.Tables("Declara")
        DGVreimpDec.DataSource = dv
        Return dt
    End Function

#Region "DATAGRIDVIEW INGRESOS"

    'FORMATO CAJA MENOR DATAGRIDVIEW INGRESOS
    Private Sub DGVreimpDec_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVreimpDec.CellFormatting

        'activo el datagrid
        Me.DGVreimpDec.Enabled = True

        'deshabilita el efecto visual de windows

        'ESTILO DE COLOR EN EL DATAGRID
        DGVreimpDec.EnableHeadersVisualStyles = False
        With DGVreimpDec.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Beige
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        'ESTABLECE EL ANCHO DE LAS COLUMNAS Y NOMBRES
        With DGVreimpDec.RowsDefaultCellStyle
            Me.DGVreimpDec.Columns(0).Width = 70
            Me.DGVreimpDec.Columns(0).HeaderText = "Id"
            Me.DGVreimpDec.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpDec.Columns(1).Width = 80
            Me.DGVreimpDec.Columns(1).HeaderText = "Cédula Proveedor"
            Me.DGVreimpDec.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.DGVreimpDec.Columns(2).Width = 240
            Me.DGVreimpDec.Columns(2).HeaderText = "Nombre Completo"
            Me.DGVreimpDec.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.DGVreimpDec.Columns(3).Width = 100
            Me.DGVreimpDec.Columns(3).HeaderText = "Fecha de Compra"
            Me.DGVreimpDec.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.DGVreimpDec.Columns(29).Width = 150
            Me.DGVreimpDec.Columns(29).HeaderText = "Consecutivo"
            Me.DGVreimpDec.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'OCULTAR LAS COLUMNAS QUE NO QUIERO MOSTRAR
            'Me.DGVreimpDec.Columns("Id").Visible = False              '0
            'Me.DGVreimpDec.Columns("cedu_com").Visible = False        '1
            'Me.DGVreimpDec.Columns("nom_com").Visible = False         '2
            'Me.DGVreimpDec.Columns("fecha_com").Visible = False       '3
            Me.DGVreimpDec.Columns("dire_com").Visible = False         '4
            Me.DGVreimpDec.Columns("telc_com").Visible = False         '5
            Me.DGVreimpDec.Columns("correo_com").Visible = False       '6
            Me.DGVreimpDec.Columns("dpto_com").Visible = False         '7
            Me.DGVreimpDec.Columns("rut_com").Visible = False          '8
            Me.DGVreimpDec.Columns("act_com").Visible = False          '9
            Me.DGVreimpDec.Columns("metal_com").Visible = False       '10
            Me.DGVreimpDec.Columns("conce_com").Visible = False       '11
            Me.DGVreimpDec.Columns("ciuddpto").Visible = False        '12
            Me.DGVreimpDec.Columns("grbrutos").Visible = False        '13
            Me.DGVreimpDec.Columns("ley").Visible = False             '14
            Me.DGVreimpDec.Columns("grpuros").Visible = False         '15
            Me.DGVreimpDec.Columns("base").Visible = False            '16
            Me.DGVreimpDec.Columns("regala").Visible = False          '17
            Me.DGVreimpDec.Columns("totalretef").Visible = False      '18
            Me.DGVreimpDec.Columns("vrventa").Visible = False         '19
            Me.DGVreimpDec.Columns("fechatasa").Visible = False       '20
            Me.DGVreimpDec.Columns("mestasa").Visible = False         '21
            Me.DGVreimpDec.Columns("retevalor").Visible = False       '22
            Me.DGVreimpDec.Columns("gp_rg").Visible = False           '23
            Me.DGVreimpDec.Columns("gp_base").Visible = False         '24
            Me.DGVreimpDec.Columns("valorgrrete").Visible = False     '25
            Me.DGVreimpDec.Columns("pagobare").Visible = False        '26
            Me.DGVreimpDec.Columns("mes_com").Visible = False         '27
            Me.DGVreimpDec.Columns("año_com").Visible = False         '28
            'Me.DGVreimpDec.Columns("consecutivo").Visible = False    '29
            Me.DGVreimpDec.Columns("fecha_creado").Visible = False    '30
            Me.DGVreimpDec.Columns("fecha_modifica").Visible = False  '31
            Me.DGVreimpDec.Columns("letras").Visible = False          '32
            Me.DGVreimpDec.Columns("detallemineral").Visible = False  '33
            Me.DGVreimpDec.Columns("verifica").Visible = False        '34
            Me.DGVreimpDec.Columns("numfundi").Visible = False        '35

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