Public Class FrmHerramAyuda

    Private Sub FrmHerramAyuda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'INGRESO DE USUARIOS AL SISTEMA
    Private Sub BtnUser_Click(sender As Object, e As EventArgs) Handles BtnUser.Click
        Me.Cursor = Cursors.WaitCursor
        FrmUsuarios.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'tipo de usuarios
    Private Sub BtnUserTipos_Click(sender As Object, e As EventArgs) Handles BtnUserTipos.Click
        Me.Cursor = Cursors.WaitCursor
        FrmTiposUser.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'CARGOS LABORALES PROFESIONES
    Private Sub BtnCargos_Click(sender As Object, e As EventArgs) Handles BtnCargos.Click
        Me.Cursor = Cursors.WaitCursor
        FrmCargos.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'datos de la empresa
    Private Sub BtnEmpresa_Click(sender As Object, e As EventArgs) Handles BtnEmpresa.Click
        Me.Cursor = Cursors.WaitCursor
        FrmEmpresa.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'INGRESO DE CIUU 
    Private Sub BtnCiuud_Click(sender As Object, e As EventArgs) Handles BtnCiuud.Click
        Me.Cursor = Cursors.WaitCursor
        FrmCiuu.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'Ejecuta Calculadora
    Private Sub BtnCalcu_Click(sender As Object, e As EventArgs) Handles BtnCalcu.Click
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "calc.exe"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    'Ejecuta Block de notas
    Private Sub BtnBlock_Click(sender As Object, e As EventArgs) Handles BtnBlock.Click
        'Ejecutar el BLoc de notas         
        'Shell("C:\WINDOWS\system32\notepad.exe", AppWinStyle.NormalFocus)
        Dim Proceso1 As New Process()
        Proceso1.StartInfo.FileName = "notepad.exe"
        Proceso1.StartInfo.Arguments = ""
        Proceso1.Start()
    End Sub

    'Ejecuta Explorador de windows
    Private Sub BtnExplorer_Click(sender As Object, e As EventArgs) Handles BtnExplorer.Click
        'Shell("C:\WINDOWS\explorer.exe", AppWinStyle.MaximizedFocus)     
        Dim Proceso2 As New Process()
        Proceso2.StartInfo.FileName = "explorer.exe"
        Proceso2.StartInfo.Arguments = ""
        Proceso2.Start()
    End Sub

    'Ejecuta cmd sistema operativo
    Private Sub BtnCmd_Click(sender As Object, e As EventArgs) Handles BtnCmd.Click
        'Shell("C:\WINDOWS\system32\cmd.exe", AppWinStyle.MinimizedFocus)
        Dim Proceso3 As New Process()
        Proceso3.StartInfo.FileName = "cmd.exe"
        Proceso3.StartInfo.Arguments = ""
        Proceso3.Start()
    End Sub

    'BOTON DE VALIDOR NIT
    Private Sub BtnValidaN_Click(sender As Object, e As EventArgs) Handles BtnValidaN.Click
        Me.Cursor = Cursors.WaitCursor
        FrmDigitoVerifca.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'CAMBIOS NOMBRES DE CLIENTES
    Private Sub BtnActUser_Click(sender As Object, e As EventArgs) Handles BtnActUser.Click
        Me.Cursor = Cursors.WaitCursor
        FrmBuscaCambio.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'PARTES DEL COMPUTADOR
    Private Sub BtnEquipo_Click(sender As Object, e As EventArgs) Handles BtnEquipo.Click
        Me.Cursor = Cursors.WaitCursor
        FrmPartes.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'ACERCA DE..
    Private Sub BtnAcerca_Click(sender As Object, e As EventArgs) Handles BtnAcerca.Click
        Me.Cursor = Cursors.WaitCursor
        AboutBox1.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTONDE LISTAR PROVEEDORES DE LA BASE DE DATOS
    Private Sub BtnVerProvee_Click(sender As Object, e As EventArgs) Handles BtnVerProvee.Click
        Me.Cursor = Cursors.WaitCursor
        FrmVerClientes.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE AYUDA DE CONFIGURACION REGIONAL
    Private Sub BtnConfig_Click(sender As Object, e As EventArgs) Handles BtnConfig.Click
        Me.Cursor = Cursors.WaitCursor
        FrmConfiguracion.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE CERRAR FORMULARIO
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'BOTON DE AUTORIZACION DIAN
    Private Sub BtnAutoDian_Click(sender As Object, e As EventArgs) Handles BtnAutoDian.Click
        Me.Cursor = Cursors.WaitCursor
        FrmAutoDian.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE Bancos
    Private Sub BtnBancos_Click(sender As Object, e As EventArgs) Handles BtnBancos.Click
        Me.Cursor = Cursors.WaitCursor
        FrmBancos.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE QR
    Private Sub BtnQR_Click(sender As Object, e As EventArgs) Handles BtnQR.Click
        Me.Cursor = Cursors.WaitCursor
        GenerarCodigosQR.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE CIUDADES
    Private Sub BtnCiudades_Click(sender As Object, e As EventArgs) Handles BtnCiudades.Click
        Me.Cursor = Cursors.WaitCursor
        FrmCiudades.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON DE TIPO DE DOCUMENTO
    Private Sub BtnTipo_Click(sender As Object, e As EventArgs) Handles BtnTipo.Click
        Me.Cursor = Cursors.WaitCursor
        FrmTipoDocu.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnOperacion_Click(sender As Object, e As EventArgs) Handles BtnOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        FrmTipoOperacion.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    'BOTON ZONAS
    Private Sub BtnZonas_Click(sender As Object, e As EventArgs) Handles BtnZonas.Click
        Me.Cursor = Cursors.WaitCursor
        FrmZonas.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnCambiaNit_Click(sender As Object, e As EventArgs) Handles BtnCambiaNit.Click
        Me.Cursor = Cursors.WaitCursor
        FrmLoginCambioNit.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

End Class