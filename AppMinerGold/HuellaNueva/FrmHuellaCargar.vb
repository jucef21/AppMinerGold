Imports System.Data.OleDb
Imports System.IO

Public Class FrmHuellaCargar

    Private Sub FrmHuellaCargar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Panel1.Select()
        Me.TxtCedula.Enabled = True
        Me.TxtCedula.Select()
        Me.TxtCedula.Focus()
        Me.TxtCedula.Clear()
        Me.BtnCargar.Enabled = True
        Me.BtnImpHuella.Enabled = False
    End Sub

    Private Sub BtnCargar_Click(sender As Object, e As EventArgs) Handles BtnCargar.Click
        BuscarImg()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
        Limpiar()
    End Sub

    'convertir binario a imágen
    Private Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    'convertir imagen a binario
    Private Function Imagen_Bytes(ByVal Imagen As Image) As Byte()
        'si hay imagen
        If Not Imagen Is Nothing Then
            'variable de datos binarios en stream(flujo)
            Dim Bin As New MemoryStream
            'convertir a bytes
            Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
            'retorna binario
            Return Bin.GetBuffer
        Else
            Return Nothing
        End If
    End Function

    Private Sub BuscarImg()
        Dim Num As String = Convert.ToInt32(TxtCedula.Text)
        Try
            Dim Sql As String = "SELECT huella FROM Clientes WHERE ced_cl=" + Num
            Dim lector As OleDbDataReader
            conn = New OleDbConnection(cs)
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim Imag As Byte()
                Dim Comando As New OleDbCommand(Sql, conn)
                lector = Comando.ExecuteReader
                'While lector.Read
                '    Imag = lector("huella")
                '    Me.ImagenHuella.Image = Bytes_Imagen(Imag)
                '    Me.TxtCedula.Enabled = False
                '    Me.BtnCargar.Enabled = False
                '    Me.BtnImpHuella.Enabled = True
                '    Me.BtnX.Enabled = True
                'End While
                Try
                    If lector.Read = True Then
                        Imag = lector("huella")
                        Me.ImagenHuella.Image = Bytes_Imagen(Imag)
                        Me.TxtCedula.Enabled = False
                        Me.BtnCargar.Enabled = False
                        Me.BtnImpHuella.Enabled = True
                        Me.BtnX.Enabled = True
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error, No se ha Actualizado la Captura de Huella.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.TxtCedula.Enabled = True
                    Me.TxtCedula.Clear()
                    Me.TxtCedula.Focus()
                    Me.BtnCargar.Enabled = True
                    Me.BtnImpHuella.Enabled = False
                    Me.BtnX.Enabled = True
                End Try
            End If
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error en Sistema, Primero se debe Actualizar la Captura de Huella.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TxtCedula.Enabled = False
            Me.TxtCedula.Clear()
            Me.BtnCargar.Enabled = False
            Me.BtnImpHuella.Enabled = False
            Me.BtnX.Enabled = True
        End Try
    End Sub

    Private Sub TxtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCedula.KeyPress
        SoloNumeros(e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Limpiar()
        Me.TxtCedula.Clear()
        Me.ImagenHuella.Image = Nothing
    End Sub

    Private Sub BtnImpHuella_Click(sender As Object, e As EventArgs) Handles BtnImpHuella.Click
        'manejo de cursor
        Me.Cursor = Cursors.WaitCursor
        'Dim FrmH As New FrmImprimeH
        'FrmH.TxtCedula.Text = Me.TxtCedula.Text
        'FrmH.ShowDialog()
        'manejo de cursor
        Me.Cursor = Cursors.Default
        Me.BtnImpHuella.Enabled = False
        Me.BtnX.Select()
        Me.BtnCargar.Focus()
    End Sub

End Class