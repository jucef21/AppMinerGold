Module NumALetras

    'Main Function
    Public Pointer1 As Integer = 0
    Public Pointer2 As Integer = 0

    ' Converts a number from 1 to 9 into text.
    Function GetDigit(ByVal Digit)
        Select Case Val(Digit)
            Case 1 : GetDigit = "Un"
            Case 2 : GetDigit = "Dos"
            Case 3 : GetDigit = "Tres"
            Case 4 : GetDigit = "Cuatro"
            Case 5 : GetDigit = "Cinco"
            Case 6 : GetDigit = "Seis"
            Case 7 : GetDigit = "Siete"
            Case 8 : GetDigit = "Ocho"
            Case 9 : GetDigit = "Nueve"
            Case Else : GetDigit = ""
        End Select
    End Function

    ' Converts a number from 10 to 99 into text.
    Function GetTens(ByVal TensText)
        Dim Result As String
        Result = "" ' Null out the temporary function value.
        If Val(Left(TensText, 1)) = 1 Then ' If value between 10-19...
            Select Case Val(TensText)
                Case 10 : Result = "Diez"
                Case 11 : Result = "Once"
                Case 12 : Result = "Doce"
                Case 13 : Result = "Trece"
                Case 14 : Result = "Catorce"
                Case 15 : Result = "Quince"
                Case 16 : Result = "Dieciseis"
                Case 17 : Result = "Diecisiete"
                Case 18 : Result = "Dieciocho"
                Case 19 : Result = "Diecinueve"
                Case Else
            End Select
        Else ' If value between 20-99...
            Select Case Val(Left(TensText, 1))
                Case 2 : Result = "Veinte "
                Case 3 : Result = "Treinta "
                Case 4 : Result = "Cuarenta "
                Case 5 : Result = "Cincuenta "
                Case 6 : Result = "Sesenta "
                Case 7 : Result = "Setenta "
                Case 8 : Result = "Ochenta "
                Case 9 : Result = "Noventa "
                Case Else
            End Select
            Result = Result & GetDigit(Right(TensText, 1)) ' Retrieve ones place.
        End If
        GetTens = Result
    End Function

    ' Converts a number from 100 to 990 into text.
    Function GetHundreds(ByVal MyNumber)
        Dim Result As String
        Dim Quinien As String
        Dim Quinien2 As String

        If Val(MyNumber) = 0 Then Exit Function
        MyNumber = Microsoft.VisualBasic.Right("000" & MyNumber, 3)

        'Converte el lugar de las centenas
        Quinien2 = " Cientos "
        If Mid(MyNumber, 1, 1) <> "0" Then
            Quinien = GetDigit(Mid(MyNumber, 1, 1))
            If Quinien = "Cinco" Then
                Quinien = "Quinientos "
                Quinien2 = ""
            End If
            If Quinien = "Uno" Then
                Quinien = ""
                Quinien2 = "Ciento "
            End If
            If Quinien = "Nueve" Then
                Quinien = "Nove"
                Quinien2 = "cientos "
            End If
            If Quinien = "Siete" Then
                Quinien = "Sete"
                Quinien2 = "cientos "
            End If
            Result = Quinien & Quinien2 ' aca le agrega al numero la palabra
        End If

        'Convierte el lugar de los miles
        If Mid(MyNumber, 2, 1) <> "0" Then
            Quinien = GetTens(Mid(MyNumber, 2))
            If Pointer1 = 0 Then
                Pointer1 = 1
                Quinien = Replace(Quinien, " ", " ")
            End If

            Result = Result & Quinien
        Else
            Quinien = GetDigit(Mid(MyNumber, 3))
            Result = Result & Quinien
        End If

        GetHundreds = Result

    End Function

    Public Function SpellNumber(ByVal MyNumber)
        Dim Dollars, Cents, Temp
        Dim DecimalPlace, Count
        Dim Place(9) As String
        Place(2) = " Mil "
        Place(3) = " Millones "
        Place(4) = " Billones "
        Place(5) = " Trillones "

        ' String representation of amount.
        MyNumber = Trim(Str(MyNumber))
        ' Position of decimal place 0 if none.
        DecimalPlace = InStr(MyNumber, ".")
        ' Convert cents and set MyNumber to dollar amount.
        If DecimalPlace > 0 Then
            Cents = GetTens(Left(Mid(MyNumber, DecimalPlace + 1) & "00", 2))
            MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
        End If
        Count = 1
        Do While MyNumber <> ""
            Temp = GetHundreds(Right(MyNumber, 3))
            If Temp <> "" Then Dollars = Temp & Place(Count) & Dollars
            If Len(MyNumber) > 3 Then
                MyNumber = Left(MyNumber, Len(MyNumber) - 3)
            Else
                MyNumber = ""
            End If
            Count = Count + 1
        Loop
        Select Case Dollars
            Case ""
                Dollars = "Cero Centavos"
            Case "One"
                Dollars = "Un Peso"
            Case Else
                Dollars = Dollars & " Pesos"
        End Select
        Select Case Cents
            Case ""
                Cents = " y Cero Centavos"
            Case "One"
                Cents = " y Un Centavo"
            Case Else
                Cents = " y " & Cents & " Centavos"
        End Select
        SpellNumber = Dollars & Cents
    End Function

End Module
