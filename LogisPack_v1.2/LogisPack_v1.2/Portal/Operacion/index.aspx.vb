Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Web.Mvc
Imports System.Web.Script.Services
Imports System.Web.Services
Imports CapaDatos
Imports Newtonsoft.Json

Public Class index4
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            idCliente = Getter.Cliente_Usuario(Manager_Usuario.GetUserId(User))
            hdfCliente.Value = idCliente

            If IsPostBack = False Then
                CargarListas()
                LlenarGridView()
            End If
        Else
            Response.Redirect(Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que llena El Gridview con datos de la Base de Datos
    ''' </summary>
    Public Sub LlenarGridView()

        Tabla.Historico(GridView1, idCliente,
                      String.Empty & ViewState("SortExpression"),
                      String.Empty & ViewState("GridViewSortDirection"),
                      String.Empty & ViewState("filtroBusqueda"),
                      String.Empty & ViewState("textoBusqueda"))
    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()
        Listas.Cliente(ddlCliente, idCliente)
    End Sub
    '--------------------------------------------------Metodos del Gridview---------------------------------------------
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()
    End Sub
    Protected Sub GridView1_OnSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        Utilidades_Grid.sortGridView(GridView1, e, ViewState("SortExpression"), ViewState("GridViewSortDirection"))

        Tabla.Historico(GridView1,
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
    ''' Metodo que realiza una busqueda en el grid al darle enter al campo de busqueda
    ''' </summary>
    Protected Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        ViewState("filtroBusqueda") = ddlBuscar.SelectedValue
        ViewState("textoBusqueda") = txtSearch.Text
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
    ''' Metodo que realiza una resetea la busqueda en el grid
    ''' </summary>
    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtSearch.Text = String.Empty
        ViewState("filtroBusqueda") = String.Empty
        ViewState("textoBusqueda") = String.Empty

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
            Listas.Articulo_Almacen(ddlArticulo, Convert.ToInt32(ddlAlmacen.SelectedValue))
        Else
            ddlArticulo.Items.Clear()
            txtSearch.Text = String.Empty
            ViewState("filtroBusqueda") = String.Empty
            ViewState("textoBusqueda") = String.Empty
        End If

        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un almacen de la lista
    ''' </summary>
    Protected Sub ddlArticulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlArticulo.SelectedIndexChanged

        If ddlArticulo.SelectedValue <> String.Empty Then

            ViewState("filtroBusqueda") = "Articulo"
            ViewState("textoBusqueda") = Convert.ToString(ddlArticulo.SelectedItem)

            Dim _articulo = Getter.Articulo(Convert.ToInt32(ddlArticulo.SelectedValue))

            txtTotalEntrada.Text = Getter.Operacion_TotalEntrada(Convert.ToInt32(ddlArticulo.SelectedValue))
            txtTotalSalida.Text = Getter.Operacion_TotalSalida(Convert.ToInt32(ddlArticulo.SelectedValue))
            txtStockFisico.Text = _articulo.stock_fisico
            txtStockMinimo.Text = _articulo.stock_minimo

        Else
            txtSearch.Text = String.Empty
            txtTotalEntrada.Text = String.Empty
            txtTotalSalida.Text = String.Empty
            txtStockFisico.Text = String.Empty
            txtStockMinimo.Text = String.Empty
            ViewState("filtroBusqueda") = String.Empty
            ViewState("textoBusqueda") = String.Empty
        End If

        LlenarGridView()

    End Sub
End Class