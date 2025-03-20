

Public Class Fechas
    Private Sub Fechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asigna date usando short format.
        Dim FechaActual As Date = Date.Now.ToShortDateString
        TxtFecha.Text = FechaActual
        Funcion_MonthName()
    End Sub

    Private Sub Funcion_MonthName()
        Dim FechaActual As Date = Date.Now.ToShortDateString
        Dim NomMes As String

        NomMes = MonthName(1, False)
        TxtMonth.Text = NomMes

    End Sub

    Private Sub Datos()
        'Asigna date usando short format.
        Dim FechaActual As Date = Date.Now.ToShortDateString

        Dim oldDay As Integer
        oldDay = DateAndTime.Day(FechaActual)

        Dim oldMes As Integer
        oldMes = DateAndTime.Month(FechaActual)
        TxtMesActual.Text = oldMes

        'Dim oldMes1 As String = Convert.ToString(DateAndTime.MonthName(CStr(Today().Month)))
        'TxtMesActual.Text = oldMes1

        Dim oldAno As Integer
        oldAno = DateAndTime.Year(FechaActual)
        TxtAnoActual.Text = oldAno


        If oldMes = 1 Then
            TxtmesEne.Text = "Enero(X)"
            TxtmesFeb.Text = "Febrero"
            TxtmesMar.Text = "Marzo"
            TxtmesAbr.Text = "Abril"
            TxtmesMay.Text = "Mayo"
            TxtmesJun.Text = "Junio"
            TxtmesJul.Text = "Julio"
            TxtmesAgo.Text = "Agosto"
            TxtmesSep.Text = "Septiembre"
            TxtmesOct.Text = "Octubre"
            TxtmesNov.Text = "Noviembre"
            TxtmesDic.Text = "Diciembre"
        End If
        If oldMes = 2 Then
            TxtmesEne.Text = "Enero"
            TxtmesFeb.Text = "Febrero(X)"
            TxtmesMar.Text = "Marzo"
            TxtmesAbr.Text = "Abril"
            TxtmesMay.Text = "Mayo"
            TxtmesJun.Text = "Junio"
            TxtmesJul.Text = "Julio"
            TxtmesAgo.Text = "Agosto"
            TxtmesSep.Text = "Septiembre"
            TxtmesOct.Text = "Octubre"
            TxtmesNov.Text = "Noviembre"
            TxtmesDic.Text = "Diciembre"
        End If
        If oldMes = 3 Then
            TxtmesEne.Text = "Enero"
            TxtmesFeb.Text = "Febrero"
            TxtmesMar.Text = "Marzo(X)"
            TxtmesAbr.Text = "Abril"
            TxtmesMay.Text = "Mayo"
            TxtmesJun.Text = "Junio"
            TxtmesJul.Text = "Julio"
            TxtmesAgo.Text = "Agosto"
            TxtmesSep.Text = "Septiembre"
            TxtmesOct.Text = "Octubre"
            TxtmesNov.Text = "Noviembre"
            TxtmesDic.Text = "Diciembre"
        End If
        If oldMes = 4 Then
            TxtmesEne.Text = "Enero"
            TxtmesFeb.Text = "Febrero"
            TxtmesMar.Text = "Marzo"
            TxtmesAbr.Text = "Abril(X)"
            TxtmesMay.Text = "Mayo"
            TxtmesJun.Text = "Junio"
            TxtmesJul.Text = "Julio"
            TxtmesAgo.Text = "Agosto"
            TxtmesSep.Text = "Septiembre"
            TxtmesOct.Text = "Octubre"
            TxtmesNov.Text = "Noviembre"
            TxtmesDic.Text = "Diciembre"
        End If
        If oldMes = 5 Then
            TxtmesEne.Text = "Enero"
            TxtmesFeb.Text = "Febrero"
            TxtmesMar.Text = "Marzo"
            TxtmesAbr.Text = "Abril"
            TxtmesMay.Text = "Mayo(X)"
            TxtmesJun.Text = "Junio"
            TxtmesJul.Text = "Julio"
            TxtmesAgo.Text = "Agosto"
            TxtmesSep.Text = "Septiembre"
            TxtmesOct.Text = "Octubre"
            TxtmesNov.Text = "Noviembre"
            TxtmesDic.Text = "Diciembre"
        End If
        If oldMes = 6 Then
            TxtmesEne.Text = "Enero"
            TxtmesFeb.Text = "Febrero"
            TxtmesMar.Text = "Marzo"
            TxtmesAbr.Text = "Abril"
            TxtmesMay.Text = "Mayo"
            TxtmesJun.Text = "Junio(X)"
            TxtmesJul.Text = "Julio"
            TxtmesAgo.Text = "Agosto"
            TxtmesSep.Text = "Septiembre"
            TxtmesOct.Text = "Octubre"
            TxtmesNov.Text = "Noviembre"
            TxtmesDic.Text = "Diciembre"
        End If
        If oldMes = 7 Then
            TxtmesEne.Text = "Enero"
            TxtmesFeb.Text = "Febrero"
            TxtmesMar.Text = "Marzo"
            TxtmesAbr.Text = "Abril"
            TxtmesMay.Text = "Mayo"
            TxtmesJun.Text = "Junio"
            TxtmesJul.Text = "Julio(X)"
            TxtmesAgo.Text = "Agosto"
            TxtmesSep.Text = "Septiembre"
            TxtmesOct.Text = "Octubre"
            TxtmesNov.Text = "Noviembre"
            TxtmesDic.Text = "Diciembre"
        End If
        If oldMes = 8 Then
            TxtmesEne.Text = "Enero"
            TxtmesFeb.Text = "Febrero"
            TxtmesMar.Text = "Marzo"
            TxtmesAbr.Text = "Abril"
            TxtmesMay.Text = "Mayo"
            TxtmesJun.Text = "Junio"
            TxtmesJul.Text = "Julio"
            TxtmesAgo.Text = "Agosto(X)"
            TxtmesSep.Text = "Septiembre"
            TxtmesOct.Text = "Octubre"
            TxtmesNov.Text = "Noviembre"
            TxtmesDic.Text = "Diciembre"
        End If
        If oldMes = 9 Then
            TxtmesEne.Text = "Enero"
            TxtmesFeb.Text = "Febrero"
            TxtmesMar.Text = "Marzo"
            TxtmesAbr.Text = "Abril"
            TxtmesMay.Text = "Mayo"
            TxtmesJun.Text = "Junio"
            TxtmesJul.Text = "Julio"
            TxtmesAgo.Text = "Agosto"
            TxtmesSep.Text = "Septiembre(X)"
            TxtmesOct.Text = "Octubre"
            TxtmesNov.Text = "Noviembre"
            TxtmesDic.Text = "Diciembre"
        End If
        If oldMes = 10 Then
            TxtmesEne.Text = "Enero"
            TxtmesFeb.Text = "Febrero"
            TxtmesMar.Text = "Marzo"
            TxtmesAbr.Text = "Abril"
            TxtmesMay.Text = "Mayo"
            TxtmesJun.Text = "Junio"
            TxtmesJul.Text = "Julio"
            TxtmesAgo.Text = "Agosto"
            TxtmesSep.Text = "Septiembre"
            TxtmesOct.Text = "Octubre(X)"
            TxtmesNov.Text = "Noviembre"
            TxtmesDic.Text = "Diciembre"
        End If
        If oldMes = 11 Then
            TxtmesEne.Text = "Enero"
            TxtmesFeb.Text = "Febrero"
            TxtmesMar.Text = "Marzo"
            TxtmesAbr.Text = "Abril"
            TxtmesMay.Text = "Mayo"
            TxtmesJun.Text = "Junio"
            TxtmesJul.Text = "Julio"
            TxtmesAgo.Text = "Agosto"
            TxtmesSep.Text = "Septiembre"
            TxtmesOct.Text = "Octubre"
            TxtmesNov.Text = "Noviembre(X)"
            TxtmesDic.Text = "Diciembre"
        End If
        If oldMes = 12 Then
            TxtmesEne.Text = "Enero"
            TxtmesFeb.Text = "Febrero"
            TxtmesMar.Text = "Marzo"
            TxtmesAbr.Text = "Abril"
            TxtmesMay.Text = "Mayo"
            TxtmesJun.Text = "Junio"
            TxtmesJul.Text = "Julio"
            TxtmesAgo.Text = "Agosto"
            TxtmesSep.Text = "Septiembre"
            TxtmesOct.Text = "Octubre"
            TxtmesNov.Text = "Noviembre"
            TxtmesDic.Text = "Diciembre(X)"
        End If
        'Trimestre
        If oldMes = 1 Then
            TxtTri1.Text = "1 (X)"
            TxtTri2.Text = "2"
            TxtTri3.Text = "3"
            TxtTri4.Text = "4"
        End If
        If oldMes = 2 Then
            TxtTri1.Text = "1 (X)"
            TxtTri2.Text = "2"
            TxtTri3.Text = "3"
            TxtTri4.Text = "4"
        End If
        If oldMes = 3 Then
            TxtTri1.Text = "1 (X)"
            TxtTri2.Text = "2"
            TxtTri3.Text = "3"
            TxtTri4.Text = "4"
        End If


        If oldMes = 4 Then
            TxtTri1.Text = "1"
            TxtTri2.Text = "2 (X)"
            TxtTri3.Text = "3"
            TxtTri4.Text = "4"
        End If
        If oldMes = 5 Then
            TxtTri1.Text = "1"
            TxtTri2.Text = "2 (X)"
            TxtTri3.Text = "3"
            TxtTri4.Text = "4"
        End If
        If oldMes = 6 Then
            TxtTri1.Text = "1"
            TxtTri2.Text = "2 (X)"
            TxtTri3.Text = "3"
            TxtTri4.Text = "4"
        End If

        If oldMes = 7 Then
            TxtTri1.Text = "1"
            TxtTri2.Text = "2"
            TxtTri3.Text = "3 (X)"
            TxtTri4.Text = "4"
        End If
        If oldMes = 8 Then
            TxtTri1.Text = "1"
            TxtTri2.Text = "2"
            TxtTri3.Text = "3 (X)"
            TxtTri4.Text = "4"
        End If
        If oldMes = 9 Then
            TxtTri1.Text = "1"
            TxtTri2.Text = "2"
            TxtTri3.Text = "3 (X)"
            TxtTri4.Text = "4"
        End If


        If oldMes = 10 Then
            TxtTri1.Text = "1"
            TxtTri2.Text = "2"
            TxtTri3.Text = "3"
            TxtTri4.Text = "4 (X)"
        End If
        If oldMes = 11 Then
            TxtTri1.Text = "1"
            TxtTri2.Text = "2"
            TxtTri3.Text = "3"
            TxtTri4.Text = "4 (X)"
        End If
        If oldMes = 12 Then
            TxtTri1.Text = "1"
            TxtTri2.Text = "2"
            TxtTri3.Text = "3"
            TxtTri4.Text = "4 (X)"
        End If


        'Año
        TxtAno.Text = oldAno

    End Sub

    Private Sub BtnDatos_Click(sender As Object, e As EventArgs) Handles BtnDatos.Click
        Datos()
    End Sub




End Class