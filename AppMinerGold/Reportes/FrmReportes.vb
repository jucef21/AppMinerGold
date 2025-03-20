Public Class FrmReportes

    'CARGA DEL FORMULARIO
    Private Sub FrmImpriCitasAll_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.BtnCompras.Select()
        Me.BtnCompras.Focus()
    End Sub

    'BOTON DE IMPRIMIR USUARIOS
    Private Sub BtnTasaMensual_Click(sender As Object, e As EventArgs) Handles BtnTasaMensual.Click
        Me.Cursor = Cursors.WaitCursor
        'FrmRangoTasMensual.Show()
        FrmRangoAcumula.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE IMPRIMIR CLIENTES
    Private Sub BtnTasaDiaria_Click(sender As System.Object, e As System.EventArgs) Handles BtnTasaDiaria.Click
        Me.Cursor = Cursors.WaitCursor
        FrmRangoTasasDiarias.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE IMPRIMIR CITAS
    Private Sub BtnCompras_Click(sender As Object, e As EventArgs) Handles BtnCompras.Click
        Me.Cursor = Cursors.WaitCursor
        FrmRangoFechaFundi.ShowDialog()
        'FrmRangoAcumulado.Showdialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE LISTADO DE PROVEEDORES
    Private Sub Btnprov_Click(sender As Object, e As EventArgs) Handles Btnprov.Click
        Me.Cursor = Cursors.WaitCursor
        FrmBuscaProv.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE REGALIAS
    Private Sub BtnRegalias_Click(sender As Object, e As EventArgs) Handles BtnRegalias.Click
        Me.Cursor = Cursors.WaitCursor
        FrmRangoFechasRegalias.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE REIMPRIMIR DOCUMENTOS
    Private Sub BtnReimpDoc_Click(sender As Object, e As EventArgs) Handles BtnReimpDoc.Click
        Me.Cursor = Cursors.WaitCursor
        FrmEscojeReimpDocus.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE LISTA DE PROVEEDORES
    Private Sub BtnListaClientes_Click(sender As Object, e As EventArgs) Handles BtnListaClientes.Click
        Me.Cursor = Cursors.WaitCursor
        FrmProveeMenu.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE ZONAS
    Private Sub BtnZonas_Click(sender As Object, e As EventArgs) Handles BtnZonas.Click
        Me.Cursor = Cursors.WaitCursor
        FrmFechaDisponible.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOOTN DE COMPRAS POR CONSECUTIVO
    Private Sub BtnCompConse_Click(sender As Object, e As EventArgs) Handles BtnCompConse.Click
        Me.Cursor = Cursors.WaitCursor
        FrmComprasConsecutivo.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    Private Sub BtnCertiRF_Click(sender As Object, e As EventArgs) Handles BtnCertiRF.Click
        Me.Cursor = Cursors.WaitCursor
        FrmSeleCertificadoRF.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnUiaf_Click(sender As Object, e As EventArgs) Handles BtnUiaf.Click
        Me.Cursor = Cursors.WaitCursor
        FrmSeleRptUiaf.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnConsultaCom_Click(sender As Object, e As EventArgs) Handles BtnConsultaComp.Click
        Me.Cursor = Cursors.WaitCursor
        'FrmConsuCompras.Show()
        FrmBuscaTotalComprado.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'Liquida Oro Plata Compras
    Private Sub BtnOroPlata_Click(sender As Object, e As EventArgs) Handles BtnOroPlata.Click
        Me.Cursor = Cursors.WaitCursor
        FrmConsultaCompOroPlata.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

End Class