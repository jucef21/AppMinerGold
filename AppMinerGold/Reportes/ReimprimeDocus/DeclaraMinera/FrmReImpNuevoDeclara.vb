Public Class FrmReImpNuevoDeclara
    Private Sub FrmReImpNuevoDeclara_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet11.Clientes' Puede moverla o quitarla según sea necesario.
        Me.ClientesTableAdapter.FillByZonasCedula(Me.DbmineroDataSet11.Clientes, TxtCedula.Text)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet11.Empresa' Puede moverla o quitarla según sea necesario.
        Me.EmpresaTableAdapter.FillByEmpresa(Me.DbmineroDataSet11.Empresa)

        'TODO: esta línea de código carga datos en la tabla 'DbmineroDataSet11.Declara' Puede moverla o quitarla según sea necesario.
        Me.DeclaraTableAdapter.FillByReimDeclara(Me.DbmineroDataSet11.Declara, TxtConsecutivo.Text)

        Me.ReportViewer1.RefreshReport
    End Sub
End Class