Public Class FrmCajaMenu

    'INICIALIZA LOS COMPONENTES
    Public Sub New()
        ' Llamada necesaria para el diseñador.
        Me.InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    'CARGUE DEL FORMULARIO
    Private Sub FrmCajaMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LLENAMOS LOS DATOS DEL ENCABEZADO DEL CLIENTE - PANEL 1
        'colocamos los texbox en no editable
        Me.TxtNomPaciente.Enabled = False

        Me.TxtNomPaciente.Text = datosUsuario

        Me.BtnIngresos.Enabled = True
        Me.BtnEgresos.Enabled = True

        'ubico el cursor
        Me.Panel2.Select()
        Me.BtnIngresos.Select()
        Me.BtnIngresos.Focus()

    End Sub

    'BOTON BUSCA CLIENTES INGRESOS
    Private Sub BtnIngresos_Click(sender As Object, e As EventArgs) Handles BtnIngresos.Click
        FrmBuscaClienteCajaIngresos.ShowDialog()
    End Sub

    'BOTON BUSCA CLIENTES EGRESOS
    Private Sub BtnEgresos_Click(sender As Object, e As EventArgs) Handles BtnEgresos.Click
        FrmBuscaClienteEgreso.ShowDialog()
    End Sub

    'BOTON DE CAJA MENOR
    Private Sub BtnCajaMenor_Click(sender As Object, e As EventArgs) Handles BtnCajaMenor.Click
        FrmReporteFechasTotalCM.ShowDialog()
    End Sub

    'BOTON DE REIMPRIMIR RECIBOS DE CAJA MENEOR
    Private Sub BtnReimpIng_Click_1(sender As Object, e As EventArgs) Handles BtnReimpIng.Click
        FrmReeimpMenu.ShowDialog()
    End Sub

    'BOTON DE CERRAR
    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        Me.Close()
    End Sub

    'BOTON DE ELIMINAR EGRESO
    Private Sub BtnEliminaEgre_Click(sender As Object, e As EventArgs) Handles BtnEliminaEgre.Click
        FrmSeleEliminaEgreso.ShowDialog()
    End Sub

    'BOTON DE ELIMINAR INGRESO
    Private Sub BtnEliminaIngre_Click(sender As Object, e As EventArgs) Handles BtnEliminaIngre.Click
        FrmSeleEliminaIngreso.ShowDialog()
    End Sub

End Class