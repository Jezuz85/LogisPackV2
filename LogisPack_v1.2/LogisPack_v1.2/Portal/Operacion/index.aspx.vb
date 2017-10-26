Imports CapaDatos

Public Class index4
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            idCliente = Mgr_Usuario.Get_Cliente_Usuario(Manager_Usuario.GetUserId(User))
            hdfCliente.Value = idCliente

            If IsPostBack = False Then
                CargarListas()
                LlenarGridView()
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
    Public Sub LlenarGridView()

        Mgr_Historico.LlenarGrid(GridView1, idCliente,
                      String.Empty & ViewState(Val_General.SortExpression.ToString),
                      String.Empty & ViewState(Val_General.GridViewSortDirection.ToString),
                      String.Empty & ViewState(Val_General.filtroBusqueda.ToString),
                      String.Empty & ViewState(Val_General.textoBusqueda.ToString))
    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()

        Mgr_Cliente.Llenar_ListaByCliente(ddlCliente, idCliente)
        Util_DropDownList.Llenar_FiltroBusqueda(ddlBuscar, Val_Paginas.Operacion_Index.ToString)
        hdfFiltro.Value = ddlBuscar.SelectedValue

    End Sub

    '-------------------------------------------------------------------
    '------------------------METODOS DEL GRIDVIEW-----------------------
    '-------------------------------------------------------------------
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()
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
    ''' Metodo que se invoca cuando se presiona el boton "guardar" y redirecciona la pagina a "Crear"
    ''' </summary>
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Response.Redirect(Val_Operacion.URL_Crear.ToString)
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
    ''' Metodo que realiza una resetea la busqueda en el grid
    ''' </summary>
    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        txtSearch.Text = String.Empty
        ViewState(Val_General.filtroBusqueda.ToString) = String.Empty
        ViewState(Val_General.textoBusqueda.ToString) = String.Empty
        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged

        Mgr_Articulo.CambiarCliente(ddlCliente, New TextBox(), ddlAlmacen)

        If ddlCliente.SelectedValue <> String.Empty Then

            ViewState(Val_General.filtroBusqueda.ToString) = Val_Operacion.Filtro_Cliente.ToString
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

            ViewState(Val_General.filtroBusqueda.ToString) = Val_Operacion.Filtro_Almacen.ToString
            ViewState(Val_General.textoBusqueda.ToString) = Convert.ToString(ddlAlmacen.SelectedItem)
            Mgr_Articulo.Llenar_ListaByAlmacen(ddlArticulo, Convert.ToInt32(ddlAlmacen.SelectedValue))
        Else
            ddlArticulo.Items.Clear()
            txtSearch.Text = String.Empty
            ViewState(Val_General.filtroBusqueda.ToString) = String.Empty
            ViewState(Val_General.textoBusqueda.ToString) = String.Empty
        End If

        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un almacen de la lista
    ''' </summary>
    Protected Sub ddlArticulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlArticulo.SelectedIndexChanged

        If ddlArticulo.SelectedValue <> String.Empty Then

            ViewState(Val_General.filtroBusqueda.ToString) = Val_Operacion.Filtro_Articulo.ToString
            ViewState(Val_General.textoBusqueda.ToString) = Convert.ToString(ddlArticulo.SelectedItem)

            Dim _articulo = Mgr_Articulo.Get_Articulo(Convert.ToInt32(ddlArticulo.SelectedValue))

            txtTotalEntrada.Text = Mgr_Historico.Get_Operacion_TotalEntrada(Convert.ToInt32(ddlArticulo.SelectedValue))
            txtTotalSalida.Text = Mgr_Historico.Get_Operacion_TotalSalida(Convert.ToInt32(ddlArticulo.SelectedValue))
            txtStockFisico.Text = _articulo.stock_fisico
            txtStockMinimo.Text = _articulo.stock_minimo

        Else
            txtSearch.Text = String.Empty
            txtTotalEntrada.Text = String.Empty
            txtTotalSalida.Text = String.Empty
            txtStockFisico.Text = String.Empty
            txtStockMinimo.Text = String.Empty
            ViewState(Val_General.filtroBusqueda.ToString) = String.Empty
            ViewState(Val_General.textoBusqueda.ToString) = String.Empty
        End If
        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Evento que filtra el gridview dependiendo del texto enviado
    ''' </summary>
    Protected Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        ViewState(Val_General.filtroBusqueda.ToString) = ddlBuscar.SelectedValue
        ViewState(Val_General.textoBusqueda.ToString) = txtSearch.Text
        LlenarGridView()
    End Sub

    ''' <summary>
    ''' Evento que agrega al campo oculto filtro el campo a buscar dependiendo de la lista desplegable, para asi
    ''' poder filtrar el autocomplete
    ''' </summary>
    Protected Sub ddlBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBuscar.SelectedIndexChanged

        hdfFiltro.Value = ddlBuscar.SelectedValue

    End Sub

End Class