Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Web.WebView2.Core

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
    Private Async Sub FrmAdminNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            ' Creamos una carpeta temporal para que el navegador no falle por permisos
            Dim userPath As String = Path.Combine(Path.GetTempPath(), "JucefSoftware_Trading")
            If Not Directory.Exists(userPath) Then Directory.CreateDirectory(userPath)

            Dim env = Await CoreWebView2Environment.CreateAsync(Nothing, userPath)

            ' Esperamos la inicialización
            Await wbMonitor.EnsureCoreWebView2Async(env)

            ' Configuraciones de seguridad y ejecución
            wbMonitor.CoreWebView2.Settings.IsScriptEnabled = True
            wbMonitor.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
            wbMonitor.CoreWebView2.Settings.AreDevToolsEnabled = True

            ' --- EL CONTENIDO HTML ---
            'Dim htmlMetales As String = "
            '    <!DOCTYPE html>
            '    <html>
            '    <head>
            '        <meta charset='UTF-8'>
            '        <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/admin-lte@3.2/dist/css/adminlte.min.css'>
            '        <style>
            '            body { background-color: #f4f6f9; margin: 10px; overflow: hidden; }
            '            .card { border-radius: 10px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); }
            '            .row { display: flex; }
            '            .col-4 { width: 33.33%; padding: 5px; }
            '        </style>
            '    </head>
            '    <body>
            '        <div class='card card-outline card-dark'>
            '            <div class='card-header'>
            '                <h3 class='card-title'>Monitor en Tiempo Real (Autorefresco cada 5 min)</h3>
            '            </div>
            '            <div class='card-body'>
            '                <div class='row'>
            '                    <div class='col-4'>
            '                        <h5 class='text-center text-warning'>ORO</h5>
            '                        <div id='tv_oro' style='height: 300px;'></div>
            '                    </div>
            '                    <div class='col-4'>
            '                        <h5 class='text-center text-secondary'>PLATA</h5>
            '                        <div id='tv_plata' style='height: 300px;'></div>
            '                    </div>
            '                    <div class='col-4'>
            '                        <h5 class='text-center text-info'>PLATINO</h5>
            '                        <div id='tv_platino' style='height: 300px;'></div>
            '                    </div>
            '                </div>
            '            </div>
            '        </div>

            '        <script type='text/javascript' src='https://s3.tradingview.com/tv.js'></script>
            '        <script>
            '            const config = { 'autosize': true, 'interval': '60', 'theme': 'light', 'style': '3', 'locale': 'es' };

            '            function cargarGraficos() {
            '                if (typeof TradingView !== 'undefined') {
            '                    // Renderizar Oro
            '                    new TradingView.widget({ ...config, 'symbol': 'OANDA:XAUUSD', 'container_id': 'tv_oro' });
            '                    // Renderizar Plata
            '                    new TradingView.widget({ ...config, 'symbol': 'OANDA:XAGUSD', 'container_id': 'tv_plata' });
            '                    // Renderizar Platino
            '                    new TradingView.widget({ ...config, 'symbol': 'OANDA:XPTUSD', 'container_id': 'tv_platino' });

            '                    console.log('Gráficos actualizados: ' + new Date().toLocaleTimeString());
            '                }
            '            }

            '            // 1. Carga inicial
            '            window.onload = cargarGraficos;

            '            // 2. Configurar autorefresco cada 5 minutos (300,000 milisegundos)
            '            // Esto refresca los widgets sin recargar la página blanca ni el formulario de VB
            '            setInterval(cargarGraficos, 300000); 
            '        </script>
            '    </body>
            '    </html>"

            '' Cargamos el HTML
            'wbMonitor.CoreWebView2.NavigateToString(htmlMetales)

        Catch ex As Exception
            MessageBox.Show("Error en Monitor: " & ex.Message)
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