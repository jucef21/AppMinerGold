':::Libreria OleDb - Access
Imports System.Data.OleDb

Module Conexiones
    ':::Procedimiento para conexion a Access
    Dim Conn As New OleDbConnection(cs)

    ':::Procedimiento para exportar en Access
    Sub Exportar_Access(ByVal Sql As String)
        ':::Declaramos nuestro objeto de tipo OleDbCommand para ejecutar la consulta
        Dim cmd As New OleDbCommand(Sql, Conn)
        Try
            Conn.Open()
            cmd.ExecuteNonQuery()
            Conn.Close()
        Catch ex As Exception
            MsgBox("No se pueden guardar los registro por: " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
        End Try
        Conn.Close()
    End Sub

    ':::Procedimiento para exportar en Access
    Sub Exportar_Access1(ByVal Sql1 As String)
        ':::Declaramos nuestro objeto de tipo OleDbCommand para ejecutar la consulta
        Dim cmd As New OleDbCommand(Sql1, Conn)
        Try
            Conn.Open()
            cmd.ExecuteNonQuery()
            Conn.Close()
        Catch ex As Exception
            MsgBox("No se pueden guardar los registro por: " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
        End Try
        Conn.Close()
    End Sub

    ':::Procedimiento para exportar en Access
    Sub Exportar_Access2(ByVal Sql2 As String)
        ':::Declaramos nuestro objeto de tipo OleDbCommand para ejecutar la consulta
        Dim cmd As New OleDbCommand(Sql2, Conn)
        Try
            Conn.Open()
            cmd.ExecuteNonQuery()
            Conn.Close()
        Catch ex As Exception
            MsgBox("No se pueden guardar los registro por: " & ex.Message, MsgBoxStyle.Critical, "AppMinerGold")
        End Try
        Conn.Close()
    End Sub


End Module
