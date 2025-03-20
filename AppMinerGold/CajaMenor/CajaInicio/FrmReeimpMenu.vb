Public Class FrmReeimpMenu

    'CARGUE DEL FORMULARIO
    Private Sub FrmReeimpMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UBICO EL CURSOR
        Me.GroupBox1.Select()
        Me.BtnReimpIng.Select()
        Me.BtnReimpIng.Focus()
    End Sub

    'BOTON DE  INGRESOS
    Private Sub BtnReimpIng_Click(sender As Object, e As EventArgs) Handles BtnReimpIng.Click
        FrmSeleIngresos.ShowDialog()
    End Sub

    'BOTON DE EGRESOS
    Private Sub BtnReimpEgresos_Click(sender As Object, e As EventArgs) Handles BtnReimpEgresos.Click
        FrmSeleEgresos.ShowDialog()
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub
    'BOTON DE REIMPRIMIR INGRESOS ELIMINADOS
    Private Sub BtnImpElimIngre_Click(sender As Object, e As EventArgs) Handles BtnImpElimIngre.Click
        FrmSeleIngreEliminado.ShowDialog()
    End Sub

    'BOTON DE REIMPRIMIR EGRESOS ELIMINADOS
    Private Sub BtnImpElimEgre_Click(sender As Object, e As EventArgs) Handles BtnImpElimEgre.Click
        FrmSeleEgreEliminado.ShowDialog()
    End Sub


End Class