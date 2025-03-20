Imports System.Data.OleDb
Imports System.IO
Imports System.Xml

Public Class FrmLogin

    Dim Conexion As New OleDbConnection 'representa conexion abierta a una base de datos

    'Formulario de Ingreso
    Private Sub FrmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.UsernameTextBox.Select()
        Me.UsernameTextBox.Focus()
        OK.Enabled = False
        'conectarse()
    End Sub

    'Eventos del boton aceptar
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'cursor de esperar
        Me.Cursor = Cursors.WaitCursor
        If CompruebaSerial() = False Then
        Else
            'Conectar la base de datos
            If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
                Conectar.conn.Close()
            End If
            Conectar.conn.Open()
            Try
                ValidaEntradaEmp()
                Llenaempresa()
            Catch ex As Exception
                'envio menaje de error
                MsgBox(ex.ToString)
            End Try
            'cierro la base de datos
            Conectar.conn.Close()
        End If
        'muestro el cursor normal
        Me.Cursor = Cursors.Default
    End Sub

    'COMPRUEBA EL SERIAL DEL SOFTWARE
    Public Function CompruebaSerial()
        Dim Verificado As Boolean = False
        Dim vs As New VerificarSerial
        Dim SerialGenerado As String
        Dim SerialGuardado As String

        vs.GetCpuID()
        vs.GetMacAddress()
        vs.GetMotherBoardID()

        If File.Exists("verificador.xml") = False Then
            'File.Create("verificador.xml").Dispose()
            Dim settings As XmlWriterSettings = New XmlWriterSettings()
            settings.Indent = True
            ' Create XmlWriter.
            Using writer As XmlWriter = XmlWriter.Create("verificador.xml", settings)
                ' Begin writing.
                writer.WriteStartDocument()
                writer.WriteStartElement("VerificadorSeriales") ' Root.
                writer.WriteStartElement("serialinfo")
                writer.WriteElementString("serial", "12345")
                writer.WriteEndElement()
                ' End document.
                writer.WriteEndElement()
                writer.WriteEndDocument()
            End Using
        End If
        Dim myXMLfile As String = "verificador.xml"
        Dim fsReadXml As New FileStream(myXMLfile, FileMode.Open)
        Try
            Dim ds As New DataSet()
            ds.ReadXml(fsReadXml)
            SerialGuardado = (ds.Tables(0).Rows(0).Item(0).ToString)
            SerialGenerado = VerificarSerial.GenerarSerial(vs.cpuInfo & vs.macaddress & vs.strMotherBoardID)
            fsReadXml.Close()
            If SerialGuardado = SerialGenerado Then
                Verificado = True
            Else
                Dim serial As String = SerialGuardado
                If MessageBox.Show("No ha registrado un serial o el que tiene es inválido ¿Desea introducir el serial ahora?", "AppMinerGold", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    serial = InputBox("Inserte el serial Autorizado para continuar", "AppMinerGold")
                    If serial = SerialGenerado Then
                        Verificado = True
                        ' Create XmlWriterSettings.
                        Dim settings As XmlWriterSettings = New XmlWriterSettings()
                        settings.Indent = True
                        ' Create XmlWriter.
                        Using writer As XmlWriter = XmlWriter.Create("verificador.xml", settings)
                            ' Begin writing.
                            writer.WriteStartDocument()
                            writer.WriteStartElement("VerificadorSeriales") ' Root.

                            writer.WriteStartElement("serialinfo")
                            writer.WriteElementString("serial", serial)
                            writer.WriteEndElement()

                            ' End document.
                            writer.WriteEndElement()
                            writer.WriteEndDocument()
                        End Using
                    End If
                Else
                    MessageBox.Show("Lo sentimos, no puede acceder sin haber registrado este software!, comuniquese con el Administrador.", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
            Return Verificado
        Catch ex As Exception
            Return False
        Finally
            fsReadXml.Close()
        End Try
    End Function

    'procedimiento para llamar el nombre de la empresa de la base de datos
    Private Sub Llamaremp()
        If ConsultarEmpresa(NomEmpresa) = "" Then
            FrmAdmin.TssLicencia.Text = datosEmpresa
        End If
    End Sub

    'Eventos del boton Cancelar
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Hide()
        'End
        Application.Exit()
    End Sub

    'creamos la validacion de la tecla ENTER entre cada caja de texto en usuario
    Private Sub UsernameTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles UsernameTextBox.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'creamos la validacion de la tecla ENTER entre cada caja de texto en password
    Private Sub PasswordTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'habilitar el boton aceptar cuando valide el texto en usuario
    Private Sub UsernameTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles UsernameTextBox.TextChanged
        OK.Enabled = UsernameTextBox.Text <> "" And PasswordTextBox.Text <> ""
    End Sub

    'habilitar el boton aceptar cuando valide el texto en usuario
    Private Sub PasswordTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles PasswordTextBox.TextChanged
        OK.Enabled = UsernameTextBox.Text <> "" And PasswordTextBox.Text <> ""
    End Sub

    'Botón de recuperar
    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FrmRecupera.ShowDialog()
    End Sub

    'FUNCION PARA GRABAR EL INGRESO AL SISTEMA
    Private Sub GrabaIngreso()
        'Conectar la base de datos
        If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
            Conectar.conn.Close()
        End If
        'variables de fecha de auditoria
        Dim fechaC As Date = CDate(Format(Date.Now.Date))
        Dim fechaM As Date = CDate(Format(Date.Now.Date))
        Dim fechaCA As Date = CDate(Format(Date.Now.ToLocalTime))
        Dim agregar As OleDbCommand = New OleDbCommand("INSERT INTO RegistroInicial(fechaIngreso, usuarioIngreso, fecha_creado, fecha_modifica) VALUES ('" & fechaCA & "','" & UsernameTextBox.Text & "','" & fechaC & "', '" & fechaM & "')", conn)
        Try
            agregar.Parameters.AddWithValue("@fechaIngreso", fechaCA)
            agregar.Parameters.AddWithValue("@usuarioIngreso", Me.UsernameTextBox.Text)
            agregar.Parameters.AddWithValue("@fecha_creado", fechaC)
            agregar.Parameters.AddWithValue("@fecha_modifica", fechaM)
            conn.Open()
            agregar.ExecuteNonQuery()
            conn.Close()
            'MessageBox.Show("registro del Usuario Guardado con Éxito.! ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al Guardar Registro de Ingreso.! ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

    End Sub

    'FUNCION DE FILTRAR la empresa
    'CADENA DE CONEXION
    'Private CadenaConexion As String = cs
    'PROCEDIMINTO PARA BUSCAR LA EMPRESA
    Private Function Buscar(id As String) As DataRow
        If (String.IsNullOrEmpty(id)) Then
            Throw New ArgumentNullException("id")
        End If
        ' Declaramos la variable que devolverá la función, que en principio indica que no existe ningún registro
        ' que coincida con el ID especificado.
        Dim returnValue As DataRow = Nothing
        ' Creamos la conexión con la base de SQL Server.
        Using conn As New OleDbConnection(cs)
            ' Creamos un objeto Command.
            Dim cmd As OleDbCommand = conn.CreateCommand()
            ' Indicamos la consulta SQL de selección que deseamos ejecutar
            cmd.CommandText = "SELECT * FROM Empresa WHERE Id=@id"
            ' Añadimos el único parámetro de entrada existente en la consulta
            cmd.Parameters.AddWithValue("@id", id)
            ' Creamos el adaptador de datos al que le pasamos el objeto Command.
            Dim da As New OleDbDataAdapter(cmd)
            ' Intentamos rellenar un objeto DataTable como resultado de ejecutar la consulta SQL de selección especificada.
            Using dt As New DataTable()
                da.Fill(dt)
                If (dt.Rows.Count > 0) Then
                    ' Nos quedamos con la primera fila u objeto DataRow.
                    returnValue = dt.Rows(0)
                End If
            End Using
        End Using
        ' Devolvemos el objeto DataRow obtenido.
        Return returnValue
    End Function

    'PROCEDIMIENTO PARA LLENAR DATOS EMPRESA
    Private Sub Llenaempresa()
        Dim Empr As Integer = 1
        If UsuarioRegistrado(UsernameTextBox.Text) = True Then
            Dim contra As String = Clave(UsernameTextBox.Text)

            Dim ClaveDescrip As String
            Encripta(PasswordTextBox.Text) : ClaveDescrip = ResultadoENCRIP

            If contra.Equals(ResultadoENCRIP) = True Then
                If ConsultarTipoUsuario(UsernameTextBox.Text) = 1 Then
                    GrabaIngreso()
                    Llamaremp()
                    FrmAdmin.ShowDialog()
                    Me.Close()
                ElseIf ConsultarTipoUsuario(UsernameTextBox.Text) = 3 Then
                    GrabaIngreso()
                    Llamaremp()
                    FrmAdmin.ShowDialog()
                    'FrmInvitado.ShowDialog()
                    'me.Close()
                Else
                    GrabaIngreso()
                    Llamaremp()
                    'FrmUsuario.ShowDialog()
                    Me.Close()
                End If
                Me.Close()
            Else
                MsgBox("La Contraseña Digitada es Invalida", MsgBoxStyle.Critical, "AppMinerGold")
                Me.UsernameTextBox.Clear()
                Me.PasswordTextBox.Clear()
                Me.UsernameTextBox.Select()
                Me.UsernameTextBox.Focus()
            End If
        Else
            'envio menaje de error
            MsgBox("El Usuario: " + UsernameTextBox.Text + " No se encuentra registrado", MsgBoxStyle.Critical, "AppMinerGold")
            Me.UsernameTextBox.Clear()
            Me.PasswordTextBox.Clear()
            Me.UsernameTextBox.Select()
            Me.UsernameTextBox.Focus()
        End If

    End Sub

    'PROCESO PARA VALIDAR INGRESO DE LA EMPRESA
    Private Sub ValidaEntradaEmp()
        Dim Empr As Integer = 1
        Try
            ' Obtenemos un objeto DataRow correspondiente con el ID escrito en un control TextBox
            Dim row As DataRow = Buscar(Empr)
            If (row Is Nothing) Then
                MessageBox.Show("Su Empresa No está Registrada, Ingrese sus datos, Tenga en cuenta que esta es la única oportunidad de Ingresar sus Datos Oficiales. ", "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Abandonamos el procedimiento
                FrmEmpresa.ShowDialog()
                Return
            Else
                ' Rellenamos los correspondientes controles TextBox  con los datos existentes en el objeto DataRow obtenido.
                FrmValidaEmp.TextBox1.Text = Convert.ToString(row("nombre_empresa"))
                FrmValidaEmp.TextBox2.Text = Convert.ToString(row("nit_empresa"))
                FrmValidaEmp.TextBox3.Text = Convert.ToString(row("dvempresa"))
                FrmValidaEmp.ShowDialog()
            End If
        Catch ex As Exception
            ' Se ha producido un error
            MessageBox.Show("No se vinculado una Empresa, Comuniquese con el Administrador del Sistema. " + ex.Message, "AppMinerGold", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub



End Class
