Imports System.Data.OleDb

Module AutoComple

    'AutoComplete los combobox

    'Metodo para cargar los datos de la BD
    Public Function Datos() As DataTable
        Dim dt As New DataTable()
        'Conectar la base de datos
        If Global.AppMinerGold.Conectar.conn.State = Global.System.Data.ConnectionState.Open Then
            Conectar.conn.Close()
        End If
        Conectar.conn.Open()
        'genero la consulta a la tabla
        Dim Consulta As String = "SELECT * FROM Ciudad WHERE ciudad ORDER BY ciudad ASC"
        'Consulta a la tabla Ciudad
        Dim cmd As New OleDbCommand(Consulta, Conn)
        'Cargo el adaptador
        Dim adap As New OleDbDataAdapter(cmd)
        'lleno la tabla con la consulta
        adap.Fill(dt)
        Return dt
    End Function

    'Metodo para cargar la coleccion de datos para el AutoComplete
    Public Function Autocompletar() As AutoCompleteStringCollection
        Dim dt As DataTable = Datos()

        Dim coleccion As New AutoCompleteStringCollection()
        'Recorrer y cargar los items para el Autocompletado
        For Each row As DataRow In dt.Rows
            coleccion.Add(Convert.ToString(row("ciudad")))
        Next
        Return coleccion
    End Function



End Module
