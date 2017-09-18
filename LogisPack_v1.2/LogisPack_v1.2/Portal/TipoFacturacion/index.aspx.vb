Imports CapaDatos

Public Class index1
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            LlenarGridView()
            Modal.OcultarAlerta(updatePanelPrinicpal)
        Else
            Response.Redirect(Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodos para llenar el Gridview con los tipos de facturacion de la base de datos
    ''' </summary>
    Private Sub LlenarGridView()

        Tabla.TipoFacturacion(GridView1)

    End Sub

    ''' <summary>
    ''' Metodos del Gridview
    ''' </summary>
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()

    End Sub
    Protected Sub GridView1_onRowEditing(sender As Object, e As GridViewEditEventArgs)

        hdfEdit.Value = Utilidades_Grid.Get_IdRow_Editing(GridView1, e, "id")
        Dim _TipoFacturacion = Getter.Tipo_Facturacion(Convert.ToInt32(hdfEdit.Value))
        txtNombre_Edit.Text = _TipoFacturacion.nombre
        Modal.AbrirModal("EditModal", "EditModalScript", Me)

    End Sub
    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        hdfIDDel.Value = Utilidades_Grid.Get_IdRow_Deleting(GridView1, e, "id")
        Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)

    End Sub

    ''' <summary>
    ''' Metodo que registra un tipo de facturacion en la base de datos
    ''' </summary>
    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _Nuevo As New Tipo_Facturacion With {
            .nombre = txtNombre.Text
        }

        bError = Create.TipoFacturacion(_Nuevo)

        Modal.CerrarModal("AddModal", "AddModalScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Registrar.ToString, bError, Me, updatePanelPrinicpal, up_Add)
        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que Actualiza un tipo de facturación en la base de datos
    ''' </summary>
    Protected Sub Editar(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim Edit = Getter.Tipo_Facturacion(Convert.ToInt32(hdfEdit.Value), contexto)

        If Edit IsNot Nothing Then
            Edit.nombre = txtNombre_Edit.Text
        End If

        bError = Update.Tipo_Facturacion(Edit, contexto)

        Modal.CerrarModal("EditModal", "EditModallScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Editar.ToString, bError, Me, updatePanelPrinicpal, up_Edit)
        LlenarGridView()
    End Sub

    ''' <summary>
    ''' Metodo que Elimina un tipo de facturación en la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Delete.TipoFacturacion(Convert.ToInt32(hdfIDDel.Value))
        Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Eliminar.ToString, bError, Me, updatePanelPrinicpal, Nothing)
        LlenarGridView()

    End Sub

End Class