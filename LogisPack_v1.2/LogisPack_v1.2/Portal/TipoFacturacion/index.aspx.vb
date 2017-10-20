Imports CapaDatos

Public Class index1
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

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
    ''' Metodos para llenar el Gridview con los tipos de facturacion de la base de datos
    ''' </summary>
    Private Sub LlenarGridView()

        Mgr_TipoFacturacion.LlenarGrid(GridView1,
                      String.Empty & ViewState(Val_General.SortExpression.ToString),
                      String.Empty & ViewState(Val_General.GridViewSortDirection.ToString),
                      String.Empty & ViewState(Val_General.filtroBusqueda.ToString),
                      String.Empty & ViewState(Val_General.textoBusqueda.ToString))

    End Sub

    '-----------------------------------Metodos del Gridview-----------------------------------
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
            Dim _TipoFacturacion = Mgr_TipoFacturacion.Get_Tipo_Facturacion(Convert.ToInt32(hdfEdit.Value))
            txtNombre_Edit.Text = _TipoFacturacion.nombre
            Util_Modal.AbrirModal(Val_TipoFacturacion.EditModal.ToString, Val_TipoFacturacion.EditModalScript.ToString, Me)

        ElseIf e.CommandName.Equals(Val_General.Eliminar.ToString) Then

            hdfIDDel.Value = Util_Grid.Get_IdRow(GridView1, e, "id")
            Util_Modal.AbrirModal(Val_TipoFacturacion.DeleteModal.ToString, Val_TipoFacturacion.DeleteModalScript.ToString, Me)

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

            bError = Mgr_TipoFacturacion.Guardar(_Nuevo)

            Util_Modal.CerrarModal(Val_TipoFacturacion.AddModal.ToString, Val_TipoFacturacion.AddModalScript.ToString, Me)
            Util_UpdatePanel.CerrarOperacion(Val_General.Registrar.ToString, bError, Me, updatePanelPrinicpal, up_Add)
            LlenarGridView()
        End If

    End Sub

    ''' <summary>
    ''' Metodo que Actualiza un tipo de facturación en la base de datos
    ''' </summary>
    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If (Page.IsValid) Then

            Dim Edit = Mgr_TipoFacturacion.Get_Tipo_Facturacion(Convert.ToInt32(hdfEdit.Value), contexto)

            If Edit IsNot Nothing Then
                Edit.nombre = txtNombre_Edit.Text
            End If

            bError = Mgr_TipoFacturacion.Editar(Edit, contexto)

            Util_Modal.CerrarModal(Val_TipoFacturacion.EditModal.ToString, Val_TipoFacturacion.EditModalScript.ToString, Me)
            Util_UpdatePanel.CerrarOperacion(Val_General.Editar.ToString, bError, Me, updatePanelPrinicpal, up_Edit)
            LlenarGridView()
        End If

    End Sub

    ''' <summary>
    ''' Metodo que Elimina un tipo de facturación en la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Mgr_TipoFacturacion.Eliminar(Convert.ToInt32(hdfIDDel.Value))
        Util_Modal.CerrarModal(Val_TipoFacturacion.DeleteModal.ToString, Val_TipoFacturacion.DeleteModalScript.ToString, Me)
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

    ''' <summary>
    ''' Metodo que realiza una resetea la busqueda en el grid
    ''' </summary>
    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        txtSearch.Text = String.Empty
        ViewState(Val_General.filtroBusqueda.ToString) = String.Empty
        ViewState(Val_General.textoBusqueda.ToString) = String.Empty
        LlenarGridView()
    End Sub

End Class