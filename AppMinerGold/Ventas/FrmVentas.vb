Public Class FrmVentas

    'CARGUE DEL FORMULARIO 
    Private Sub FrmCajaMenorAsesoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.BtnCompras.Enabled = True
        Me.BtnVentas.Enabled = True
        Me.Btnreport.Enabled = False
        Me.BtnSalir.Enabled = True

        'UBICO EL CURSOR
        Me.BtnCompras.Select()
        Me.BtnCompras.Focus()


    End Sub

    'BOTON COMPRAS
    Private Sub BtnCompras_Click(sender As Object, e As EventArgs) Handles BtnCompras.Click
        FrmBuscaEmp.Show()
    End Sub

    'BOTON VENTAS
    Private Sub BtnVentas_Click(sender As Object, e As EventArgs) Handles BtnVentas.Click
        FrmVentaGold.Show()
    End Sub

    'BOTON REPORTE
    Private Sub Btnreport_Click(sender As Object, e As EventArgs) Handles Btnreport.Click

    End Sub

    'BOTON REGRESAR
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
        FrmAdmin.Show()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class