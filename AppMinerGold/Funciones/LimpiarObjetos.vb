Module LimpiarObjetos

    Public Sub Limpiar_Todos(ByVal f As Form)
        Dim obj As Object
        For Each obj In f.Controls
            If TypeOf obj Is System.Windows.Forms.TextBox Then
                obj.text = ""
            End If
            If TypeOf obj Is System.Windows.Forms.CheckBox Then
                obj.checked = False
            End If
            If TypeOf obj Is System.Windows.Forms.ListBox Then
                obj.items.clear()
            End If
            If TypeOf obj Is System.Windows.Forms.RadioButton Then
                obj.checked = False
            End If
        Next

    End Sub

End Module
