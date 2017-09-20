Imports CapaDatos

Public Class index5
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then

            If Manager_Usuario.ValidarRol(User, Rol.Admin.ToString) Then
                LlenarGridView()
                Modal.OcultarAlerta(updatePanelPrinicpal)
            Else
                Response.Redirect(Paginas.Inicio.ToString)
            End If
        Else
            Response.Redirect(Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub LlenarGridView()

        Tabla.Cliente(GridView1)

    End Sub

    ''' <summary>
    ''' Metodos del Gridview
    ''' </summary>
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()
    End Sub
    Protected Sub GridView1_onRowEditing(sender As Object, e As GridViewEditEventArgs)

        hdfEdit.Value = Utilidades_Grid.Get_IdRow_Editing(GridView1, e)
        Dim _Cliente = Getter.Cliente(Convert.ToInt32(hdfEdit.Value))

        txtCodigo_Edit.Text = _Cliente.codigo
        txtNombre_Edit.Text = _Cliente.nombre

        Modal.AbrirModal("EditModal", "EditModalScript", Me)

    End Sub
    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        hdfIDDel.Value = Utilidades_Grid.Get_IdRow_Deleting(GridView1, e)
        Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)


    End Sub

    ''' <summary>
    ''' Metodo que registra un cliente en la base de datos
    ''' </summary>
    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _Nuevo As New Cliente With {
            .codigo = txtCodigo_Add.Text,
            .nombre = txtNombre_Add.Text
        }

        bError = Create.Cliente(_Nuevo)

        Modal.CerrarModal("AddModal", "AddModalScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Registrar.ToString, bError, Me, updatePanelPrinicpal, up_Add)
        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que actualiza un cliente en la base de datos
    ''' </summary>
    Protected Sub Editar(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim Edit = Getter.Cliente(Convert.ToInt32(hdfEdit.Value), contexto)

        If Edit IsNot Nothing Then
            Edit.codigo = txtCodigo_Edit.Text
            Edit.nombre = txtNombre_Edit.Text
        End If

        bError = Update.Cliente(Edit, contexto)

        Modal.CerrarModal("EditModal", "EditModallScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Editar.ToString, bError, Me, updatePanelPrinicpal, up_Edit)
        LlenarGridView()
    End Sub

    ''' <summary>
    ''' Metodo que elimina un cliente en la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Delete.Cliente(Convert.ToInt32(hdfIDDel.Value))
        Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Eliminar.ToString, bError, Me, updatePanelPrinicpal, Nothing)
        LlenarGridView()

    End Sub

End Class