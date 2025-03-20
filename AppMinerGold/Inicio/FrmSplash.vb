Public Class FrmSplash

    Dim contador As Byte = 0

    'control de tiempo
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If ProgressBar1.Value < 100 Then
            contador = CByte(contador + 1)
            ProgressBar1.Value = contador
            LblConteo.Text = ProgressBar1.Value & "%"

            ProgressBar1.Increment(1)
            If ProgressBar1.Value = 10 Then
                LblCarga.Text = "Cargando Sistema ."
            End If

            ProgressBar1.Increment(1)
            If ProgressBar1.Value = 20 Then
                LblCarga.Text = "Cargando Sistema . ."
            End If

            ProgressBar1.Increment(1)
            If ProgressBar1.Value = 30 Then
                LblCarga.Text = "Cargando Sistema . . . "
            End If

            ProgressBar1.Increment(1)
            If ProgressBar1.Value = 40 Then
                LblCarga.Text = "Cargando Sistema . . . ."
            End If

            ProgressBar1.Increment(1)
            If ProgressBar1.Value = 50 Then
                LblCarga.Text = "Cargando Sistema . . . . . ."
            End If

            ProgressBar1.Increment(1)
            If ProgressBar1.Value = 60 Then
                LblCarga.Text = "Falta Poco ."
            End If

            If ProgressBar1.Value = 70 Then
                LblCarga.Text = "Falta Poco . ."
            End If

            If ProgressBar1.Value = 80 Then
                LblCarga.Text = "Falta Poco . . ."
            End If

            If ProgressBar1.Value = 90 Then
                LblCarga.Text = "Terminando ."
            End If

            If ProgressBar1.Value = 95 Then
                LblCarga.Text = "Terminando . ."
            End If

            If ProgressBar1.Value = 99 Then
                LblCarga.Text = "Terminando . . ."
            End If

            'Me.PictureBox1.Controls.Add(Me.LblCarga)


        Else
            Me.Hide()
            FrmLogin.Show()
            Timer1.Enabled = False
        End If

    End Sub

    'formulario de inicio de la aplicación
    Private Sub FrmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.PictureBox1.Controls.Add(Me.LblConteo)

        LblConteo.Parent = PictureBox1

    End Sub


End Class