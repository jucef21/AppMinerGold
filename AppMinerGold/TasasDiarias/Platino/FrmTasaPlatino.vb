Public Class FrmTasaPlatino

    'CARGUE DEL FORM
    Private Sub FrmTasaPlatino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.LblHoraActual.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now)
        Me.LblFechaActual.Text = Now.ToLongDateString
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'REGALIAS PLATINO
    Private Sub BtnRegalias_Click(sender As Object, e As EventArgs) Handles BtnRegalias.Click
        Me.Cursor = Cursors.WaitCursor()
        FrmRegaliasPlatino.ShowDialog()
        Me.Cursor = Cursors.Default()
    End Sub

    'RETEFUENTE PLATINO
    Private Sub BtnRetefuente_Click(sender As Object, e As EventArgs) Handles BtnRetefuente.Click
        Me.Cursor = Cursors.WaitCursor()
        FrmRetefuentePlatino.ShowDialog()
        Me.Cursor = Cursors.Default()
    End Sub

End Class