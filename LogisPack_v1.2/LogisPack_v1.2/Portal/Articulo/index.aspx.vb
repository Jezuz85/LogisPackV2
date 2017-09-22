Imports CapaDatos

Public Class index3
    Inherits Page

    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then

            idCliente = Getter.Cliente_Usuario(Manager_Usuario.GetUserId(User))
            If IsPostBack = False Then
                LlenarGridView()
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

        Tabla.Articulo(GridView1, idCliente, String.Empty, String.Empty)

    End Sub

    ''' <summary>
    ''' Metodos del gridview
    ''' </summary>
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

        Tabla.Articulo(GridView1, idCliente, "" & ViewState("SortExpression"), "" & ViewState("GridViewSortDirection"))

    End Sub
    Protected Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs)
        Utilidades_Grid.SetArrowsGrid(GridView1, e)
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

    ''' <summary>
    ''' Metodo que se invoca cuando se presiona el boton "guardar" y redirecciona la pagina a "Crear"
    ''' </summary>
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Response.Redirect("Crear.aspx")
    End Sub

End Class