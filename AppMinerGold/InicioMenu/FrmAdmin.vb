Imports System.Runtime.InteropServices

Public Class FrmAdmin


    Private Sub AjustarResolucion(ByVal formulario As System.Windows.Forms.Form)
        Dim ancho As String = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Width.ToString()
        Dim alto As String = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height.ToString()
        Dim tamano As String = ancho & "x" + alto

        Select Case tamano
            Case "800x600"
                CambiarResolucion(formulario, 110.0F, 110.0F)
                   ' break;
            Case "1024x600"
                CambiarResolucion(formulario, 96.0F, 110.0F)
                   ' break;
            Case "1280x800"
                CambiarResolucion(formulario, 96.0F, 110.0F)
                    ' break;
            Case "1366x768"
                CambiarResolucion(formulario, 96.0F, 110.0F)
                    ' break;
            Case "1680x1050"
                CambiarResolucion(formulario, 96.0F, 110.0F)
                ' break;
            Case Else
                CambiarResolucion(formulario, 96.0F, 96.0F)
                ' break;
        End Select

    End Sub

    Private Sub CambiarResolucion(ByVal formulario As System.Windows.Forms.Form, ByVal ancho As Single, ByVal alto As Single)
        formulario.AutoScaleDimensions = New System.Drawing.SizeF(ancho, alto)
        formulario.PerformAutoScale()
    End Sub

    Private m_ChildFormNumber As Integer

    'CARGUE DEL FORMULARIO PRINCIPAL
    Private Sub FrmAdminNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'MUESTRA EL ESTADO DEL CURSOR
            Me.Cursor = Cursors.WaitCursor

            ' Cargamos los datos en el objeto DataTable
            'adaptar el tamaño de la pantalla al escritorio de cualquier pantalla
            'importante en la propiedad windows.estate colocar normal.
            Me.Location = Screen.PrimaryScreen.WorkingArea.Location
            Me.Size = Screen.PrimaryScreen.WorkingArea.Size

            'Dim classResize As New ClsResizeForm
            'classResize.ResizeForm(Me, 1366, 768)

            'TssLicencia.Text = NomEmpresa

            TssLicencia.Text = "Software Licenciado para:  " & datosEmpresa
            TssEmpresa.Text = " | Aplicación Desarrollada por: Jucef Software"
            TssEstado.Text = "  | Fecha actual del sistema: " & DateTime.Now.ToString().Substring(0, 10)
            TssUsuario.Text = " | Usuario activo: " & datosUsuario

            'cierro la conexion
            Conectar.conn.Close()

        Catch ex As Exception
            ' Se ha producido un error
            MessageBox.Show(ex.Message)
            'ACTUALIZAR CURSOR 
            Me.Cursor = Cursors.Default
        Finally
            'ACTUALIZAR CURSOR 
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub PanelBarraTitulo_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelBarraTitulo.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub AbrirFormEnPanel(ByVal Formhijo As Object)

        If Me.PanelContenedor.Controls.Count > 0 Then Me.PanelContenedor.Controls.RemoveAt(0)
        Dim fh As Form = TryCast(Formhijo, Form)
        fh.TopLevel = False
        fh.FormBorderStyle = FormBorderStyle.None
        fh.Dock = DockStyle.Fill
        Me.PanelContenedor.Controls.Add(fh)
        Me.PanelContenedor.Tag = fh
        fh.ShowDialog()

    End Sub

    'BOTON DE INGRESOS
    Private Sub BtnIngresos_Click(sender As Object, e As EventArgs) Handles BtnIngresos.Click
        Me.Cursor = Cursors.WaitCursor
        FrmSecretaria.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE LINKS
    Private Sub BtnLinks_Click(sender As Object, e As EventArgs) Handles BtnLinks.Click
        Me.Cursor = Cursors.WaitCursor
        FrmConsuAnt.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE TASAS
    Private Sub BtnTasas_Click(sender As Object, e As EventArgs) Handles BtnTasas.Click
        Me.Cursor = Cursors.WaitCursor
        FrmMenuTax.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE COMPRAS
    Private Sub BtnCompras_Click(sender As Object, e As EventArgs) Handles BtnCompras.Click
        Me.Cursor = Cursors.WaitCursor
        FrmMenu.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE FUNDICION
    Private Sub BtnFundicion_Click(sender As Object, e As EventArgs) Handles BtnFundicion.Click
        Me.Cursor = Cursors.WaitCursor
        FrmMenuFundiciones.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE CAJA MENOR
    Private Sub BtnCajaMenor_Click(sender As Object, e As EventArgs) Handles BtnCajaMenor.Click
        Me.Cursor = Cursors.WaitCursor
        FrmCajaMenor.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE AYUDAS DEL SISTEMA
    Private Sub BtnAyudas_Click(sender As Object, e As EventArgs) Handles BtnAyudas.Click
        Me.Cursor = Cursors.WaitCursor
        FrmHerramAyuda.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE REPORTES
    Private Sub BtnReportes_Click(sender As Object, e As EventArgs) Handles BtnReportes.Click
        Me.Cursor = Cursors.WaitCursor()
        FrmReportes.ShowDialog()
        Me.Cursor = Cursors.Default()
    End Sub

    'BOTON DE COPIAS DE SEGURIDAD
    Private Sub BtnCopiaSeg_Click(sender As Object, e As EventArgs) Handles BtnCopiaSeg.Click
        Me.Cursor = Cursors.WaitCursor()
        FrmBackup.ShowDialog()
        Me.Cursor = Cursors.Default()
    End Sub

    'BOTON DE SALIR
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        If MessageBox.Show("Desea Salir de la Aplicación", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub TmOCULTAR_Tick(sender As Object, e As EventArgs) Handles TmOcultar.Tick
        If PanelMenu.Width <= 60 Then
            Me.TmOcultar.Enabled = False
        Else
            Me.PanelMenu.Width = PanelMenu.Width - 5
        End If
    End Sub

    Private Sub TmMOSTRAR_Tick(sender As Object, e As EventArgs) Handles TmMostrar.Tick
        If PanelMenu.Width >= 220 Then
            Me.TmMostrar.Enabled = False
        Else
            Me.PanelMenu.Width = PanelMenu.Width + 5
        End If
    End Sub

    Private Sub BtnMenu_Click(sender As Object, e As EventArgs) Handles BtnMenu.Click
        If PanelMenu.Width = 220 Then
            TmOcultar.Enabled = True
        ElseIf PanelMenu.Width = 60 Then
            TmMostrar.Enabled = True
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        If MessageBox.Show("Desea Salir de la Aplicación", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub BtnRestaurar_Click(sender As Object, e As EventArgs) Handles BtnRestaurar.Click
        Me.WindowState = FormWindowState.Normal
        BtnRestaurar.Visible = False
        BtnMaximizar.Visible = True
    End Sub

    Private Sub BtnMinimizar_Click(sender As Object, e As EventArgs) Handles BtnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BtnMaximizar_Click(sender As Object, e As EventArgs) Handles BtnMaximizar.Click
        BtnMaximizar.Visible = False
        BtnRestaurar.Visible = True
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblHora.Text = DateTime.Now.ToLongTimeString
        LblFecha.Text = Date.Now.ToLongDateString
    End Sub



End Class