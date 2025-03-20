Public Class FrmSeleccionaReporte

    'CARGUE DEL FORMULARIO
    Private Sub FrmSeleccionaReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'HABILITO EL CHK
        Me.ChkTotal.Checked = 1

        'LIMPIO LOS  CHECKBOX
        Me.ChkIngresos.CheckState = CheckState.Unchecked
        Me.ChkEgresos.CheckState = CheckState.Unchecked

    End Sub

    'CHK INGRESOS
    Private Sub ChkIngresos_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkIngresos.CheckStateChanged
        Me.ChkTotal.CheckState = CheckState.Unchecked
        Me.ChkEgresos.CheckState = CheckState.Unchecked
    End Sub

    'CHK EGRESOS
    Private Sub ChkEgresos_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkEgresos.CheckStateChanged
        Me.ChkTotal.CheckState = CheckState.Unchecked
        Me.ChkIngresos.CheckState = CheckState.Unchecked
    End Sub

    'CHK TOTAL
    Private Sub ChkTotal_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkTotal.CheckStateChanged
        Me.ChkIngresos.CheckState = CheckState.Unchecked
        Me.ChkEgresos.CheckState = CheckState.Unchecked
    End Sub

    'BOOTN SE IMPRIMIR
    Private Sub BtnImpriAse1_Click(sender As Object, e As EventArgs) Handles BtnImpriAse1.Click
        'SELECCIONO EL TIPO DE IMPRESION TOTAL
        If ChkTotal.Checked Then
            FrmRptTotalCM.ShowDialog()
        End If

        'SELECCIONO EL TIPO DE IMPRESION SOLO INGRESOS
        If ChkIngresos.Checked Then
            FrmRptTotalING.ShowDialog()
        End If

        'SELECCIONO EL TIPO DE IMPRESION SOLO EGRESOS
        If ChkEgresos.Checked Then
            FrmRptTotalEGR.ShowDialog()
        End If

    End Sub

    'BOTON DE REGRESAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class