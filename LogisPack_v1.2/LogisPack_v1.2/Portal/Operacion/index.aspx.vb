﻿Imports System.IO
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
        Mgr_Cliente.Llenar_Lista(ddlCliente, idCliente)
    End Sub
    '--------------------------------------------------Metodos del Gridview---------------------------------------------
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

    '--------------------------------------------------EVENTOS---------------------------------------------
    ''' <summary>
    ''' Metodo que realiza una busqueda en el grid al darle enter al campo de busqueda
    ''' </summary>
    Protected Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        ViewState(Val_General.filtroBusqueda.ToString) = ddlBuscar.SelectedValue
        ViewState(Val_General.textoBusqueda.ToString) = txtSearch.Text
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

            ViewState(Val_General.filtroBusqueda.ToString) = "Cliente"
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

            ViewState(Val_General.filtroBusqueda.ToString) = "Almacen"
            ViewState(Val_General.textoBusqueda.ToString) = Convert.ToString(ddlAlmacen.SelectedItem)
            Mgr_Articulo.Llenar_Lista_Almacen(ddlArticulo, Convert.ToInt32(ddlAlmacen.SelectedValue))
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

            ViewState(Val_General.filtroBusqueda.ToString) = "Articulo"
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
End Class