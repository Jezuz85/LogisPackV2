Imports CapaDatos

Public Class index5
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            idCliente = Getter.Cliente_Usuario(Manager_Usuario.GetUserId(User))

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
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub LlenarGridView()

        Tabla.Cliente(GridView1,
                      idCliente,
                      String.Empty & ViewState(Val_General.SortExpression.ToString),
                      String.Empty & ViewState(Val_General.GridViewSortDirection.ToString),
                      String.Empty & ViewState(Val_General.filtroBusqueda.ToString),
                      String.Empty & ViewState(Val_General.textoBusqueda.ToString))

    End Sub

    '--------------------------------------------------Metodos del Gridview---------------------------------------------
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()
    End Sub
    Protected Sub GridView1_OnSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        Utilidades_Grid.sortGridView(GridView1, e, ViewState(Val_General.SortExpression.ToString), ViewState(Val_General.GridViewSortDirection.ToString))

        Tabla.Cliente(GridView1,
                      idCliente,
                       String.Empty & ViewState(Val_General.SortExpression.ToString),
                       String.Empty & ViewState(Val_General.GridViewSortDirection.ToString),
                       String.Empty & ViewState(Val_General.filtroBusqueda.ToString),
                       String.Empty & ViewState(Val_General.textoBusqueda.ToString))

    End Sub
    Protected Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs)
        Utilidades_Grid.SetArrowsGrid(GridView1, e)
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Val_General.Editar.ToString) Then

            hdfEdit.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Dim _Cliente = Getter.Cliente(Convert.ToInt32(hdfEdit.Value))

            txtCodigo_Edit.Text = _Cliente.codigo
            txtNombre_Edit.Text = _Cliente.nombre

            Modal.AbrirModal("EditModal", "EditModalScript", Me)

        End If
        If e.CommandName.Equals(Val_General.Eliminar.ToString) Then

            hdfIDDel.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)

        End If

    End Sub

    '--------------------------------------------------EVENTOS---------------------------------------------
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
    ''' Metodo que registra un cliente en la base de datos
    ''' </summary>
    Protected Sub Guardar(sender As Object, e As EventArgs)

        If (Page.IsValid) Then

            Dim _Nuevo As New Cliente With {
                .codigo = txtCodigo_Add.Text,
                .nombre = txtNombre_Add.Text
            }

            bError = Create.Cliente(_Nuevo)

            Modal.CerrarModal("AddModal", "AddModalScript", Me)
            Utilidades_UpdatePanel.CerrarOperacion(Val_General.Registrar.ToString, bError, Me, updatePanelPrinicpal, up_Add)
            LlenarGridView()
        End If

    End Sub

    ''' <summary>
    ''' Metodo que actualiza un cliente en la base de datos
    ''' </summary>
    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If (Page.IsValid) Then

            Dim Edit = Getter.Cliente(Convert.ToInt32(hdfEdit.Value), contexto)

            If Edit IsNot Nothing Then
                Edit.codigo = txtCodigo_Edit.Text
                Edit.nombre = txtNombre_Edit.Text
            End If

            bError = Update.Cliente(Edit, contexto)

            Modal.CerrarModal("EditModal", "EditModallScript", Me)
            Utilidades_UpdatePanel.CerrarOperacion(Val_General.Editar.ToString, bError, Me, updatePanelPrinicpal, up_Edit)
            LlenarGridView()
        End If
    End Sub

    ''' <summary>
    ''' Metodo que elimina un cliente en la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Delete.Cliente(Convert.ToInt32(hdfIDDel.Value))
        Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Val_General.Eliminar.ToString, bError, Me, updatePanelPrinicpal, Nothing)
        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que realiza una busqueda en el grid
    ''' </summary>
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        ViewState(Val_General.filtroBusqueda.ToString) = ddlBuscar.SelectedValue
        ViewState(Val_General.textoBusqueda.ToString) = txtSearch.Text
        LlenarGridView()

    End Sub
End Class