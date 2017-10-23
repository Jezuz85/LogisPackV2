Imports CapaDatos

Public Class index3
    Inherits Page

    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            idCliente = Mgr_Usuario.Get_Cliente_Usuario(Manager_Usuario.GetUserId(User))
            If IsPostBack = False Then
                LlenarGridView()
                CargarListas()
                Util_Modal.OcultarAlerta(updatePanelPrinicpal)
            End If

        Else
            Response.Redirect(Val_Paginas.Login.ToString)
        End If

    End Sub

    '------------------------------------------------------------------
    '------------------------METODOS AL CARGAR LA PAGINA---------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que llena El Gridview con datos de la Base de Datos
    ''' </summary>
    Private Sub LlenarGridView()

        Mgr_Articulo.Llenar_Grid(GridView1,
                                idCliente,
                                String.Empty & ViewState(Val_General.SortExpression.ToString),
                                String.Empty & ViewState(Val_General.GridViewSortDirection.ToString),
                                String.Empty & ViewState(Val_General.filtroBusqueda.ToString),
                                String.Empty & ViewState(Val_General.textoBusqueda.ToString))

    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()
        Mgr_Cliente.Llenar_Lista(ddlCliente, idCliente)
    End Sub

    ''' <summary>
    ''' Metodo que elimina un articulo de la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Mgr_Articulo.Eliminar(Convert.ToInt32(hdfIDDel.Value))
        Util_Modal.CerrarModal(Val_Articulo.DeleteModal.ToString, Val_Articulo.DeleteModalScript.ToString, Me)
        Util_UpdatePanel.CerrarOperacion(Val_General.Eliminar.ToString, bError, Me, updatePanelPrinicpal, Nothing)
        LlenarGridView()

    End Sub

    '-------------------------------------------------------------------
    '------------------------METODOS DEL GRIDVIEW-----------------------
    '-------------------------------------------------------------------
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Val_General.Detalles.ToString) Then

            Dim id As String = Util_Grid.Get_IdRow(GridView1, e)
            Response.Redirect(Val_Articulo.URL_Detalles.ToString & Util_Cifrar.cifrarCadena(id))

        ElseIf e.CommandName.Equals(Val_General.Editar.ToString) Then

            Dim id As String = Util_Grid.Get_IdRow(GridView1, e)
            Response.Redirect(Val_Articulo.URL_Editar.ToString & Util_Cifrar.cifrarCadena(id))

        ElseIf e.CommandName.Equals(Val_General.Eliminar.ToString) Then

            hdfIDDel.Value = Util_Grid.Get_IdRow(GridView1, e)
            Util_Modal.AbrirModal(Val_Articulo.DeleteModal.ToString, Val_Articulo.DeleteModalScript.ToString, Me)

        End If

    End Sub
    Protected Sub GridView1_OnSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        Util_Grid.sortGridView(GridView1, e, ViewState(Val_General.SortExpression.ToString), ViewState(Val_General.GridViewSortDirection.ToString))
        LlenarGridView()

    End Sub
    Protected Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs)
        Util_Grid.SetArrowsGrid(GridView1, e)
    End Sub

    '-------------------------------------------------------
    '------------------------EVENTOS------------------------
    '-------------------------------------------------------
    ''' <summary>
    ''' Metodo que realiza una resetea la busqueda en el grid
    ''' </summary>
    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        txtSearch.Text = String.Empty
        ViewState(Val_General.filtroBusqueda.ToString) = String.Empty
        ViewState(Val_General.textoBusqueda.ToString) = String.Empty
        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que se invoca cuando se presiona el boton "guardar" y redirecciona la pagina a "Crear"
    ''' </summary>
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Response.Redirect(Val_Articulo.URL_Crear.ToString)
    End Sub

    ''' <summary>
    ''' Metodo que realiza una busqueda en el grid
    ''' </summary>
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        ViewState(Val_General.filtroBusqueda.ToString) = ddlBuscar.SelectedValue
        ViewState(Val_General.textoBusqueda.ToString) = txtSearch.Text
        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged

        Mgr_Articulo.CambiarCliente(ddlCliente, New TextBox(), ddlAlmacen)

        If ddlCliente.SelectedValue <> String.Empty Then
            ViewState(Val_General.filtroBusqueda.ToString) = Val_Articulo.Filtro_Cliente.ToString
            ViewState(Val_General.textoBusqueda.ToString) = Convert.ToString(ddlCliente.SelectedItem)
        Else
            txtSearch.Text = String.Empty
            ViewState(Val_General.filtroBusqueda.ToString) = String.Empty
            ViewState(Val_General.textoBusqueda.ToString) = String.Empty
        End If

        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un almacen de la lista
    ''' </summary>
    Protected Sub ddlAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAlmacen.SelectedIndexChanged

        If ddlAlmacen.SelectedValue <> String.Empty Then

            ViewState(Val_General.filtroBusqueda.ToString) = Val_Articulo.Filtro_Almacen.ToString
            ViewState(Val_General.textoBusqueda.ToString) = Convert.ToString(ddlAlmacen.SelectedItem)
        Else
            txtSearch.Text = String.Empty
            ViewState(Val_General.filtroBusqueda.ToString) = String.Empty
            ViewState(Val_General.textoBusqueda.ToString) = String.Empty
        End If

        LlenarGridView()

    End Sub

End Class