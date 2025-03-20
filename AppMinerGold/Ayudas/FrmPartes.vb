':::Importamos la libreria System.Management
Imports System.Management

Public Class FrmPartes

    Private Sub FrmPartes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Informacion()
    End Sub

    Private Sub Informacion()
        ':::Obtenemos la informacion del Sistema operativo
        LblNombreSO.Text = ": " + My.Computer.Info.OSFullName
        LblVersionSO.Text = ": " + My.Computer.Info.OSVersion

        Dim consultaSQLArquitectura As String = "SELECT * FROM Win32_Processor"
        Dim objArquitectura As New ManagementObjectSearcher(consultaSQLArquitectura)
        Dim ArquitecturaSO As String = ""
        For Each info As ManagementObject In objArquitectura.Get()
            ArquitecturaSO = info.Properties("AddressWidth").Value.ToString()
        Next info
        LblArquitecturaSO.Text = "Tipo:  " + ArquitecturaSO + " Bits"

        ':::Obtenemos la informacion del Equipo
        LblNombreEquipo.Text = "Pc:   " + My.Computer.Name
        LblNombreUsuario.Text = "User:   " + Security.Principal.WindowsIdentity.GetCurrent().Name

        ':::Obtenemos el serial del Disco Duro
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        LblSerialDD.Text = "No.:   " + serialDD.Properties("SerialNumber").Value.ToString

        '':::Obtenemos el serial de la Board
        'Dim serial As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_BaseBoard")
        'Dim serialBoard As String = ""
        'For Each serialB As ManagementObject In serial.Get()
        '    serialBoard = (serialB.GetPropertyValue("SerialNumber").ToString)
        'Next
        'LblSerialBoard.Text = "No.:  " + serialBoard
        LblSerialBoard.Text = "No.:  " + SystemSerialNumber()

    End Sub

    Private Function SystemSerialNumber() As String
        ' Get the Windows Management Instrumentation object.
        Dim wmi As Object = GetObject("WinMgmts:")

        ' Get the "base boards" (mother boards).
        Dim serial_numbers As String = ""
        Dim mother_boards As Object =
        wmi.InstancesOf("Win32_BaseBoard")
        For Each board As Object In mother_boards
            serial_numbers &= ", " & board.SerialNumber
        Next board
        If serial_numbers.Length > 0 Then serial_numbers =
        serial_numbers.Substring(2)

        Return serial_numbers
    End Function


    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

End Class