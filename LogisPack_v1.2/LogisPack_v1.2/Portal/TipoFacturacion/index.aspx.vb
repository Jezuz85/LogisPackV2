Imports CapaDatos

Public Class index1
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            If Manager_Usuario.ValidarRol(User, Rol.Admin.ToString) Then

                If IsPostBack = False Then
                    LlenarGridView()
                    Modal.OcultarAlerta(updatePanelPrinicpal)
                End If

            Else
                Response.Redirect(Paginas.Inicio.ToString)
            End If
        Else
            Response.Redirect(Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodos para llenar el Gridview con los tipos de facturacion de la base de datos
    ''' </summary>
    Private Sub LlenarGridView()

        Tabla.TipoFacturacion(GridView1,
                      String.Empty & ViewState("SortExpression"),
                      String.Empty & ViewState("GridViewSortDirection"),
                      String.Empty & ViewState("filtroBusqueda"),
                      String.Empty & ViewState("textoBusqueda"))

    End Sub

    '-----------------------------------Metodos del Gridview-----------------------------------
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()

    End Sub
    Protected Sub GridView1_OnSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        Utilidades_Grid.sortGridView(GridView1, e, ViewState("SortExpression"), ViewState("GridViewSortDirection"))

        Tabla.TipoFacturacion(GridView1,
                       String.Empty & ViewState("SortExpression"),
                       String.Empty & ViewState("GridViewSortDirection"),
                       String.Empty & ViewState("filtroBusqueda"),
                       String.Empty & ViewState("textoBusqueda"))

    End Sub
    Protected Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs)
        Utilidades_Grid.SetArrowsGrid(GridView1, e)
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Mensajes.Editar.ToString) Then

            hdfEdit.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Dim _TipoFacturacion = Getter.Tipo_Facturacion(Convert.ToInt32(hdfEdit.Value))
            txtNombre_Edit.Text = _TipoFacturacion.nombre
            Modal.AbrirModal("EditModal", "EditModalScript", Me)

        End If
        If e.CommandName.Equals(Mensajes.Eliminar.ToString) Then

            hdfIDDel.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)

        End If

    End Sub

    '--------------------------------------------------EVENTOS---------------------------------------------
    ''' <summary>
    ''' Metodo que registra un tipo de facturacion en la base de datos
    ''' </summary>
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If (Page.IsValid) Then

            Dim _Nuevo As New Tipo_Facturacion With {
            .nombre = txtNombre.Text
        }

            bError = Create.TipoFacturacion(_Nuevo)

            Modal.CerrarModal("AddModal", "AddModalScript", Me)
            Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Registrar.ToString, bError, Me, updatePanelPrinicpal, up_Add)
            LlenarGridView()
        End If

    End Sub

    ''' <summary>
    ''' Metodo que Actualiza un tipo de facturación en la base de datos
    ''' </summary>
    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If (Page.IsValid) Then

            Dim Edit = Getter.Tipo_Facturacion(Convert.ToInt32(hdfEdit.Value), contexto)

            If Edit IsNot Nothing Then
                Edit.nombre = txtNombre_Edit.Text
            End If

            bError = Update.Tipo_Facturacion(Edit, contexto)

            Modal.CerrarModal("EditModal", "EditModallScript", Me)
            Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Editar.ToString, bError, Me, updatePanelPrinicpal, up_Edit)
            LlenarGridView()
        End If
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

    ''' <summary>
    ''' Metodo que realiza una busqueda en el grid
    ''' </summary>
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        ViewState("filtroBusqueda") = ddlBuscar.SelectedValue
        ViewState("textoBusqueda") = txtSearch.Text
        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que realiza una resetea la busqueda en el grid
    ''' </summary>
    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtSearch.Text = String.Empty
        ViewState("filtroBusqueda") = String.Empty
        ViewState("textoBusqueda") = String.Empty

        LlenarGridView()
    End Sub

End Class