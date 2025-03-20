Imports System.Data.OleDb

Public Class ClienteRepository

    Public Shared Function CargarGrilla(valor As String) As List(Of Cliente)
        Conectar.Conectarse()

        Using cn As New OleDb.OleDbConnection(cs)
            Using cmd As OleDbCommand = cn.CreateCommand
                cmd.CommandText = "SELECT controlcl, nom_cl, ape_cl, ced_cl, dire_cl,telf_cl FROM clientes WHERE nom_cl LIKE '" + valor + "%'"
                Dim cliente As New List(Of Cliente)
                Using reader As OleDbDataReader = cmd.ExecuteReader
                    While reader.Read
                        Dim c As New Cliente With {
                            .Nom_cl = reader("nom_cl").ToString,
                            .Ape_cl = reader("ape_cl").ToString,
                            .ced_cl = reader("ced_cl").ToString,
                            .dire_cl = reader("dire_cl").ToString,
                            .telf_cl = reader("telf_cl").ToString
                        }
                        cliente.Add(c)
                    End While
                End Using
                Return cliente
            End Using
        End Using
    End Function


End Class

