Public Class FrmTasasOro

    'CARGUE DEL FORMULARIO
    Private Sub FrmTasas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor()
        Me.Panel3.Select()
        Me.Panel2.Select()
        Me.BtnRegalias.Select()
        Me.BtnRegalias.Focus()
        Me.Cursor = Cursors.Default()

        'codigo mostrar hora en formulario
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Timer1.Interval = 1000  ' Un segundo
        Timer1.Start()
    End Sub

    'Cargue del timpo actual en el formulario
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Me.LblFechaActual.Text = Now.ToLongDateString
    End Sub

    'BOTON DE REGALIAS MENSUALES
    Private Sub BtnRegalias_Click(sender As Object, e As EventArgs) Handles BtnRegalias.Click
        Me.Cursor = Cursors.WaitCursor()
        FrmRegaliasOro.ShowDialog()
        Me.Cursor = Cursors.Default()
    End Sub

    'BOTON DE RETEFUENTE
    Private Sub BtnRetefuente_Click(sender As Object, e As EventArgs) Handles BtnRetefuente.Click
        Me.Cursor = Cursors.WaitCursor()
        FrmRetefuenteOro.ShowDialog()
        Me.Cursor = Cursors.Default()
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class