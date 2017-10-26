Imports System.Data.SqlClient
Imports CapaDatos

Public Class index
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

                ViewState(Val_General.filtroBusqueda.ToString) = String.Empty
                ViewState(Val_General.textoBusqueda.ToString) = String.Empty

                MyTreeView.Nodes.Clear()

                Dim dt As DataTable

                If Manager_Usuario.ValidarRol(User, Val_Rol.Admin.ToString) Then
                    dt = GetData(Val_Comandos.Arbol_Almacen_Nivel0.ToString)
                Else
                    Dim objComando As Val_Comandos
                    objComando = New Val_Comandos(String.Empty, String.Empty & idCliente)
                    dt = GetData(objComando.GetComando())
                End If

                LlenarTreeView(dt, 0, Nothing)
                LlenarGridView()
                CargarListas()

            Else

            End If

            Util_Modal.OcultarAlerta(updatePanelPrinicpal)

        Else
            Response.Redirect(Val_Paginas.Login.ToString)
        End If

    End Sub

    '------------------------------------------------------------------
    '------------------------METODOS AL CARGAR LA PAGINA---------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()
        Mgr_Cliente.Llenar_ListaByCliente(ddlClienteAdd, idCliente)

        Util_DropDownList.Llenar_FiltroBusqueda(ddlBuscar, Val_Paginas.Almacen_Index.ToString)
        hdfFiltro.Value = ddlBuscar.SelectedValue

    End Sub

    ''' <summary>
    ''' Metodo que obtiene la data a pasarle al arbol
    ''' </summary>
    Private Function GetData(query As String) As DataTable
        Dim dt As New DataTable()
        Dim constr As String = ConfigurationManager.ConnectionStrings("DLAlmacen").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                End Using
            End Using
            Return dt
        End Using
    End Function

    ''' <summary>
    ''' Metodo que Elimina un registro de Almacen de la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Mgr_Almacen.Eliminar(Convert.ToInt32(hdfIDDel.Value))

        Util_Modal.CerrarModal(Val_Almacen.DeleteModal.ToString, Val_Almacen.DeleteModalScript.ToString, Me)

        Util_UpdatePanel.CerrarOperacion(Val_General.Eliminar.ToString, bError, Me, updatePanelPrinicpal, Nothing)

        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que llena el arbol de almacenes
    ''' </summary>
    Private Sub LlenarTreeView(dtParent As DataTable, parentId As Integer, treeNode As TreeNode)

        For Each row As DataRow In dtParent.Rows

            Dim child As New TreeNode() With {
                .Text = row("Name").ToString(),
                .Value = row("ID").ToString()
                }

            If parentId = 0 Then
                MyTreeView.Nodes.Add(child)
                Dim dtChild As DataTable = GetData(Val_Comandos.Arbol_Almacen_Nivel1.ToString + child.Value)
                LlenarTreeView(dtChild, 1, child)
            ElseIf parentId = 1 Then
                treeNode.ChildNodes.Add(child)
                Dim dtChild As DataTable = Me.GetData(Val_Comandos.Arbol_Almacen_Nivel2.ToString + child.Value)
                LlenarTreeView(dtChild, 2, child)
            Else
                treeNode.ChildNodes.Add(child)
            End If
        Next

        MyTreeView.CollapseAll()

    End Sub

    ''' <summary>
    ''' Metodo que llena El Gridview con datos de la Base de Datos
    ''' </summary>
    Private Sub LlenarGridView()

        Mgr_Almacen.Llenar_Grid(GridView1,
                                idCliente,
                                String.Empty & ViewState(Val_General.SortExpression.ToString),
                                String.Empty & ViewState(Val_General.GridViewSortDirection.ToString),
                                String.Empty & ViewState(Val_General.filtroBusqueda.ToString),
                                String.Empty & ViewState(Val_General.textoBusqueda.ToString))
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

            hdfView.Value = Util_Grid.Get_IdRow(GridView1, e)
            Dim _Almacen = Mgr_Almacen.Consultar(Convert.ToInt32(hdfView.Value))

            lbViewCliente.Text = _Almacen.Cliente.nombre
            lbViewCodigo.Text = _Almacen.codigo
            lbViewNombre.Text = _Almacen.nombre
            lbViewCoefVol.Text = _Almacen.coeficiente_volumetrico

            Util_Modal.AbrirModal(Val_Almacen.ViewModal.ToString, Val_Almacen.ViewModalScript.ToString, Me)

        ElseIf e.CommandName.Equals(Val_General.Editar.ToString) Then

            hdfEdit.Value = Util_Grid.Get_IdRow(GridView1, e)
            Dim _Almacen = Mgr_Almacen.Consultar(Convert.ToInt32(hdfEdit.Value))
            Mgr_Cliente.Llenar_ListaByCliente(ddlClienteEdit, idCliente)

            Dim CoefVolumetrico As String = Convert.ToDouble(_Almacen.coeficiente_volumetrico).ToString("##,##0.00000").Replace(",", ".")

            ddlClienteEdit.SelectedValue = _Almacen.id_cliente
            txtEditCodigo.Text = _Almacen.codigo
            txtEditNombre.Text = _Almacen.nombre
            txtEditCoefVol.Text = CoefVolumetrico

            Util_Modal.AbrirModal(Val_Almacen.EditModal.ToString, Val_Almacen.EditModalScript.ToString, Me)

        ElseIf e.CommandName.Equals(Val_General.Eliminar.ToString) Then

            hdfIDDel.Value = Util_Grid.Get_IdRow(GridView1, e)
            Util_Modal.AbrirModal(Val_Almacen.DeleteModal.ToString, Val_Almacen.DeleteModalScript.ToString, Me)
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
    ''' Metodo que crea un objeto Almacen y lo guarda en la base de datos
    ''' </summary>
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If (Page.IsValid) Then

#Region "creo la estructura almacen"
            Dim _mialmacen = Mgr_Almacen.Get_Struct()
            _mialmacen.nombre = txtNombre.Text
            _mialmacen.codigo = txtCodigo.Text
            _mialmacen.coeficiente_volumetrico = txtCoefVol.Text
            _mialmacen.id_cliente = ddlClienteAdd.SelectedValue
#End Region

            bError = Mgr_Almacen.Guardar(Mgr_Almacen.Crear_Objeto(_mialmacen))

            Util_Modal.CerrarModal(Val_Almacen.AddModal.ToString, Val_Almacen.AddModalScript.ToString, Me)

            Util_UpdatePanel.CerrarOperacion(Val_General.Registrar.ToString, bError, Me, updatePanelPrinicpal, up_Add)
            LlenarGridView()

        End If

    End Sub

    ''' <summary>
    ''' Metodo que Edita un objeto Almacen y actualiza el registro en la base de datos
    ''' </summary>
    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If (Page.IsValid) Then

            Dim Edit = Mgr_Almacen.Consultar(Convert.ToInt32(hdfEdit.Value), contexto)

            If Edit IsNot Nothing Then

#Region "creo la estructura almacen"
                Dim _mialmacen = Mgr_Almacen.Get_Struct()
                _mialmacen.nombre = txtEditNombre.Text
                _mialmacen.codigo = txtEditCodigo.Text
                _mialmacen.coeficiente_volumetrico = txtEditCoefVol.Text
                _mialmacen.id_cliente = ddlClienteEdit.SelectedValue
#End Region

                bError = Mgr_Almacen.Editar(Mgr_Almacen.Crear_Objeto(_mialmacen), contexto)
                Util_Modal.CerrarModal(Val_Almacen.EditModal.ToString, Val_Almacen.EditModalScript.ToString, Me)
                Util_UpdatePanel.CerrarOperacion(Val_General.Editar.ToString, bError, Me, updatePanelPrinicpal, up_Edit)

            End If

            LlenarGridView()

        End If

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
    ''' Evento que agrega al campo oculto filtro el campo a buscar dependiendo de la lista desplegable, para asi
    ''' poder filtrar el autocomplete
    ''' </summary>
    Protected Sub ddlBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBuscar.SelectedIndexChanged

        hdfFiltro.Value = ddlBuscar.SelectedValue

    End Sub

    ''' <summary>
    ''' Metodo que se invoca al darle click al nodo de almacen y asi consultar los datos del almacen
    ''' </summary>
    Protected Sub MyTreeView_SelectedNodeChanged(sender As Object, e As EventArgs) Handles MyTreeView.SelectedNodeChanged

        If MyTreeView.SelectedNode.Depth = 1 Then

            Dim IdAlmacen = Convert.ToInt32(MyTreeView.SelectedNode.Value)
            Dim Listarticulo = contexto.Almacen.Where(Function(model) model.id_almacen = IdAlmacen).SingleOrDefault()

            txtNomAlmacen.Text = Listarticulo.nombre
            CodAlmacen.Text = Listarticulo.codigo
            CoefVol.Text = Listarticulo.coeficiente_volumetrico

            CodCliente.Text = MyTreeView.SelectedNode.Parent.Text
            NomCliente.Text = "Cliente: " & MyTreeView.SelectedNode.Parent.Text
        End If
    End Sub

    ''' <summary>
    ''' Evento que filtra el gridview dependiendo del texto enviado
    ''' </summary>
    Protected Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        ViewState(Val_General.filtroBusqueda.ToString) = ddlBuscar.SelectedValue
        ViewState(Val_General.textoBusqueda.ToString) = txtSearch.Text
        LlenarGridView()
    End Sub
End Class