Imports CapaDatos

Public Class index5
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            idCliente = Mgr_Usuario.Get_Cliente_Usuario(Manager_Usuario.GetUserId(User))

            If Manager_Usuario.ValidarRol(User, Val_Rol.Admin.ToString) Then
                If IsPostBack = False Then
                    LlenarGridView()
                    Util_Modal.OcultarAlerta(updatePanelPrinicpal)
                End If
            Else
                Response.Redirect(Val_Paginas.Inicio.ToString)
            End If
        Else
            Response.Redirect(Val_Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub LlenarGridView()

        Mgr_Cliente.LlenarGrid(GridView1,
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

        Util_Grid.sortGridView(GridView1, e, ViewState(Val_General.SortExpression.ToString), ViewState(Val_General.GridViewSortDirection.ToString))

        LlenarGridView()

    End Sub
    Protected Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs)
        Util_Grid.SetArrowsGrid(GridView1, e)
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Val_General.Editar.ToString) Then

            hdfEdit.Value = Util_Grid.Get_IdRow(GridView1, e, "id")
            Dim _Cliente = Mgr_Cliente.Get_Cliente(Convert.ToInt32(hdfEdit.Value))

            txtCodigo_Edit.Text = _Cliente.codigo
            txtNombre_Edit.Text = _Cliente.nombre

            Util_Modal.AbrirModal("EditModal", "EditModalScript", Me)

        End If
        If e.CommandName.Equals(Val_General.Eliminar.ToString) Then

            hdfIDDel.Value = Util_Grid.Get_IdRow(GridView1, e, "id")
            Util_Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)

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

            bError = Mgr_Cliente.Guardar(_Nuevo)

            Util_Modal.CerrarModal("AddModal", "AddModalScript", Me)
            Util_UpdatePanel.CerrarOperacion(Val_General.Registrar.ToString, bError, Me, updatePanelPrinicpal, up_Add)
            LlenarGridView()
        End If

    End Sub

    ''' <summary>
    ''' Metodo que actualiza un cliente en la base de datos
    ''' </summary>
    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If (Page.IsValid) Then

            Dim Edit = Mgr_Cliente.Get_Cliente(Convert.ToInt32(hdfEdit.Value), contexto)

            If Edit IsNot Nothing Then
                Edit.codigo = txtCodigo_Edit.Text
                Edit.nombre = txtNombre_Edit.Text
            End If

            bError = Mgr_Cliente.Editar(Edit, contexto)

            Util_Modal.CerrarModal("EditModal", "EditModallScript", Me)
            Util_UpdatePanel.CerrarOperacion(Val_General.Editar.ToString, bError, Me, updatePanelPrinicpal, up_Edit)
            LlenarGridView()
        End If
    End Sub

    ''' <summary>
    ''' Metodo que elimina un cliente en la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Mgr_Cliente.Eliminar(Convert.ToInt32(hdfIDDel.Value))
        Util_Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)
        Util_UpdatePanel.CerrarOperacion(Val_General.Eliminar.ToString, bError, Me, updatePanelPrinicpal, Nothing)
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