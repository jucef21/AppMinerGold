Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
'Imports System.Data.OleDb.OleDbConnection

Module Conectar

    'Public conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Dbminero.accdb; Jet OLEDB:Database Password =@waleska2018;")
    'Public conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Dbminero.accdb; Jet OLEDB:Database Password=@waleska2018;")
    Public conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Dbminero.accdb; Jet OLEDB:Database Password =@waleska2018;")

    Public cmd As New OleDbCommand
    Public dr As OleDbDataReader
    Public da As OleDbDataAdapter
    Public sql As String = ""
    Public datosEmpresa As String
    Public datosUsuario As String
    Public Controlefectivo As String
    Public NomEmpresa As String
    Public dv As New DataView
    Public ResultadoENCRIP As String

    'cadena de conexion
    'Public cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + My.Computer.FileSystem.CurrentDirectory + "\Dbminero.accdb; Jet OLEDB:Database Password=@waleska2018;"
    ''Public cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Dbminero.accdb; Jet OLEDB:Database Password=@waleska2018;"
    Public cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Dbminero.accdb; Jet OLEDB:Database Password=@waleska2018;"


    'CONECTARSE A LA BASE DE DATOS
    Public Sub Conectarse()
        Try
            conn.Open()
            'MsgBox("Conexión exitosa", vbInformation, "Negocios")
        Catch ex As Exception
            MsgBox("Error en Conexión", MsgBoxStyle.Information, "AppMinerGold")
            MsgBox(ex.ToString)
        End Try
    End Sub

    'FUNCION PARA VALIDAR EN LA BASE DE DATOS SI EXISTE EL USUARIO
    Function UsuarioRegistrado(ByVal nom_user As String) As Boolean
        Dim resultado As Boolean = False
        Try
            cmd = New OleDbCommand("SELECT * FROM Usuarios WHERE Usuario = '" & nom_user & "'", conn)

            dr = cmd.ExecuteReader

            If dr.Read Then
                resultado = True
            End If
            dr.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return resultado

    End Function

    'FUNCION PARA VALIDAR LA CONTRASEÑA
    Function Clave(ByVal nom_user As String) As String
        Dim resultado As String = ""
        Try
            cmd = New OleDbCommand("SELECT clave FROM Usuarios WHERE Usuario = '" & nom_user & "'", conn)

            dr = cmd.ExecuteReader

            If dr.Read Then
                resultado = dr.Item("clave")
            End If
            dr.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return resultado

    End Function

    'FUNCION PARA VALIDAR EL TIPO DE USUARIO
    Function ConsultarTipoUsuario(ByVal nom_user As String) As Integer
        Dim resultado As Integer
        Try
            cmd = New OleDbCommand("SELECT tipo_user, nom_user FROM Usuarios WHERE Usuario = '" & nom_user & "'", conn)

            dr = cmd.ExecuteReader

            If dr.Read Then
                resultado = CInt(dr.Item("Tipo_User"))
                datosUsuario = CStr(dr.Item("Nom_User"))
            End If

            dr.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return resultado

    End Function

    'FUNCION PARA VALIDAR EL TIPO DE USUARIO
    Function ConsultarCajaMenor(ByVal nom_user As String) As Integer
        Dim resultadocaja As Integer
        Try
            cmd = New OleDbCommand("SELECT tipo_efect FROM Usuarios WHERE Usuario = '" & nom_user & "'", conn)
            conn.Open()
            dr = cmd.ExecuteReader

            If dr.Read Then
                Controlefectivo = CInt(dr.Item("tipo_efect"))
                datosUsuario = CStr(dr.Item("Nom_User"))
            End If

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return resultadocaja

    End Function

    'FUNCION PARA VALIDAR EMPRESA
    Function ConsultarEmpresa(ByVal nom_empresa As String) As String
        Try
            cmd = New OleDbCommand("SELECT nombre_empresa FROM Empresa", conn)
            conn.Open()
            dr = cmd.ExecuteReader

            If dr.Read Then
                datosEmpresa = CStr(dr.Item("nombre_empresa"))
            End If

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return datosEmpresa

    End Function

    Public Function Encripta(ByVal SourceText As String) As String
        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New UnicodeEncoding()
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New MD5CryptoServiceProvider()
        'Compute the hash value from the source
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'And convert it to String format for return
        ResultadoENCRIP = Convert.ToBase64String(ByteHash)
        Return Convert.ToBase64String(ByteHash)
    End Function

    '==================================================================================================
    'EJEMPLO IA - Ejemplo para conectar a Access desde VB .NET:
    'Pasos para integrar OpenAI con VB .NET:
    'Regístrate en OpenAI y obtén una API Key.
    'Usa HTTPClient en VB .NET para realizar peticiones a la API.
    '====================================================================================================
    'Imports System.Data.OleDb

    'Public Sub ConnectToAccess()
    '    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\ruta\de\tu\base\de\datos.accdb;"
    '    Using conn As New OleDbConnection(connectionString)
    '        conn.Open()
    '        Dim cmd As New OleDbCommand("SELECT * FROM Tabla", conn)
    '        Using reader As OleDbDataReader = cmd.ExecuteReader()
    '            While reader.Read()
    '                ' Procesar datos
    '                Console.WriteLine(reader("Campo1").ToString())
    '            End While
    '        End Using
    '    End Using
    'End Sub

    'Ejemplo en VB .NET para integrar OpenAI GPT-3:
    '=================================================
    'Imports System.Net.Http
    'Imports System.Text
    'Imports Newtonsoft.Json

    'Public Async Function GetAIResponse(prompt As String) As Task(Of String)
    '    Dim client As New HttpClient()
    '    Dim apiKey As String = "your_openai_api_key"
    '    Dim url As String = "https://api.openai.com/v1/completions"

    '    ' Crear el contenido de la petición
    '    Dim requestBody As New Dictionary(Of String, Object) From {
    '    {"model", "text-davinci-003"},
    '    {"prompt", prompt},
    '    {"max_tokens", 100},
    '    {"temperature", 0.7}
    '}

    '    ' Convertir el cuerpo a JSON
    '    Dim json As String = JsonConvert.SerializeObject(requestBody)
    '    Dim content As New StringContent(json, Encoding.UTF8, "application/json")
    '    content.Headers.Add("Authorization", "Bearer " & apiKey)

    '    ' Enviar la solicitud
    '    Dim response As HttpResponseMessage = Await client.PostAsync(url, content)
    '    Dim responseString As String = Await response.Content.ReadAsStringAsync()

    '    ' Procesar la respuesta
    '    Dim result As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseString)
    '    Dim generatedText As String = result("choices")(0)("text").ToString()

    '    Return generatedText
    'End Function

    'Ejemplo de código en VB .NET usando ML.NET:
    '===========================================
    'Imports Microsoft.ML
    'Imports Microsoft.ML.Data

    'Public Class ModelInput
    '    <ColumnName("Label")>
    '    Public Property Label As Single

    '    <ColumnName("Feature1")>
    '    Public Property Feature1 As Single
    'End Class

    'Public Class ModelOutput
    '    Public Property Prediction As Single
    'End Class

    'Public Sub TrainModel()
    '    ' Crear contexto ML
    '    Dim mlContext As New MLContext()

    '    ' Cargar datos desde Access u otra fuente (por ejemplo, CSV, SQLite)
    '    Dim dataView = mlContext.Data.LoadFromTextFile(Of ModelInput)("data.csv", separatorChar:=",")

    '    ' Crear pipeline de transformación y entrenamiento de modelo
    '    Dim pipeline = mlContext.Transforms.Concatenate("Features", "Feature1") _
    '                        .Append(mlContext.Regression.Trainers.Sdca(labelColumnName:="Label", maximumNumberOfIterations:=100))

    '    ' Entrenar el modelo
    '    Dim model = pipeline.Fit(dataView)

    '    ' Hacer predicciones
    '    Dim prediction = model.Transform(dataView)

    '    ' Evaluar el modelo
    '    Dim metrics = mlContext.Regression.Evaluate(prediction)

    '    Console.WriteLine("RMSE: " & metrics.RootMeanSquaredError)
    'End Sub


End Module
