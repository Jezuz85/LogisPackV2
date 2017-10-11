Imports CapaDatos

Public Class index3
    Inherits Page

    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            idCliente = Getter.Cliente_Usuario(Manager_Usuario.GetUserId(User))
            If IsPostBack = False Then
                LlenarGridView()
                CargarListas()
                Modal.OcultarAlerta(updatePanelPrinicpal)
            End If

        Else
            Response.Redirect(Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que llena El Gridview con datos de la Base de Datos
    ''' </summary>
    Private Sub LlenarGridView()

        Tabla.Articulo(GridView1, idCliente, String.Empty, String.Empty, String.Empty & ViewState("filtroBusqueda"), String.Empty & ViewState("textoBusqueda"))

    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()
        Listas.Cliente(ddlCliente, idCliente)
    End Sub

    ''' <summary>
    ''' Metodo que elimina un articulo de la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Delete.Articulo(Convert.ToInt32(hdfIDDel.Value))
        Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Eliminar.ToString, bError, Me, updatePanelPrinicpal, Nothing)
        LlenarGridView()
    End Sub

    '--------------------------------------------------Metodos del gridview-----------------------------------------
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Mensajes.Detalles.ToString) Then
            Dim id As String = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Response.Redirect("Detalles.aspx?id=" & Cifrar.cifrarCadena(id))

        End If

        If e.CommandName.Equals(Mensajes.Editar.ToString) Then

            Dim id As String = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Response.Redirect("Editar.aspx?id=" & Cifrar.cifrarCadena(id))

        End If

        If e.CommandName.Equals(Mensajes.Eliminar.ToString) Then

            hdfIDDel.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)

        End If

    End Sub
    Protected Sub GridView1_OnSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        Utilidades_Grid.sortGridView(GridView1, e, ViewState("SortExpression"), ViewState("GridViewSortDirection"))

        Tabla.Articulo(GridView1,
                       idCliente,
                       String.Empty & ViewState("SortExpression"),
                       String.Empty & ViewState("GridViewSortDirection"),
                       String.Empty & ViewState("filtroBusqueda"),
                       String.Empty & ViewState("textoBusqueda"))

    End Sub
    Protected Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs)
        Utilidades_Grid.SetArrowsGrid(GridView1, e)
    End Sub

    '--------------------------------------------------EVENTOS---------------------------------------------
    ''' <summary>
    ''' Metodo que realiza una resetea la busqueda en el grid
    ''' </summary>
    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtSearch.Text = String.Empty
        ViewState("filtroBusqueda") = String.Empty
        ViewState("textoBusqueda") = String.Empty

        LlenarGridView()
    End Sub

    ''' <summary>
    ''' Metodo que se invoca cuando se presiona el boton "guardar" y redirecciona la pagina a "Crear"
    ''' </summary>
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Response.Redirect("Crear.aspx")
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
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged
        Manager_Articulo.CambiarCliente(ddlCliente, New TextBox(), ddlAlmacen)

        If ddlCliente.SelectedValue <> String.Empty Then

            ViewState("filtroBusqueda") = "Cliente"
            ViewState("textoBusqueda") = Convert.ToString(ddlCliente.SelectedItem)
        Else
            txtSearch.Text = String.Empty
            ViewState("filtroBusqueda") = String.Empty
            ViewState("textoBusqueda") = String.Empty
        End If

        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un almacen de la lista
    ''' </summary>
    Protected Sub ddlAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAlmacen.SelectedIndexChanged

        If ddlAlmacen.SelectedValue <> String.Empty Then

            ViewState("filtroBusqueda") = "Almacen"
            ViewState("textoBusqueda") = Convert.ToString(ddlAlmacen.SelectedItem)
        Else
            txtSearch.Text = String.Empty
            ViewState("filtroBusqueda") = String.Empty
            ViewState("textoBusqueda") = String.Empty
        End If

        LlenarGridView()

    End Sub

End Class