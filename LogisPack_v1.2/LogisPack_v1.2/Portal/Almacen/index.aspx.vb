Imports System.Data.SqlClient
Imports System.Globalization
Imports CapaDatos

Public Class index
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then

            idCliente = Getter.Cliente_Usuario(Manager_Usuario.GetUserId(User))

            If IsPostBack = False Then

                ViewState("filtroBusqueda") = String.Empty
                ViewState("textoBusqueda") = String.Empty

                MyTreeView.Nodes.Clear()

                Dim dt As DataTable

                If Manager_Usuario.ValidarRol(User, Rol.Admin.ToString) Then
                    dt = GetData(Comandos.Arbol_Almacen_Nivel0.ToString)
                Else
                    Dim objComando As Comandos
                    objComando = New Comandos("", "" & idCliente)
                    dt = GetData(objComando.GetComando())
                End If

                LlenarTreeView(dt, 0, Nothing)
                LlenarGridView()
                CargarListas()
            End If

            Modal.OcultarAlerta(updatePanelPrinicpal)

        Else
            Response.Redirect(Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que llena El Gridview con datos de la Base de Datos
    ''' </summary>
    Private Sub LlenarGridView()
        Tabla.Almacen(GridView1, idCliente, String.Empty, String.Empty, String.Empty & ViewState("filtroBusqueda"), String.Empty & ViewState("textoBusqueda"))
    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()
        Listas.Cliente(ddlClienteAdd, idCliente)
    End Sub

    ''' <summary>
    ''' Metodos del Gridview
    ''' </summary>
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Mensajes.Detalles.ToString) Then

            hdfView.Value = Utilidades_Grid.Get_IdRow(GridView1, e)
            Dim _Almacen = Getter.Almacen(Convert.ToInt32(hdfView.Value))

            lbViewCliente.Text = _Almacen.Cliente.nombre
            lbViewCodigo.Text = _Almacen.codigo
            lbViewNombre.Text = _Almacen.nombre
            lbViewCoefVol.Text = _Almacen.coeficiente_volumetrico

            Modal.AbrirModal("ViewModal", "ViewModalScript", Me)

        ElseIf e.CommandName.Equals(Mensajes.Editar.ToString) Then

            hdfEdit.Value = Utilidades_Grid.Get_IdRow(GridView1, e)
            Dim _Almacen = Getter.Almacen(Convert.ToInt32(hdfEdit.Value))
            Listas.Cliente(ddlClienteEdit, idCliente)

            Dim CoefVolumetrico As String = Convert.ToDouble(_Almacen.coeficiente_volumetrico).ToString("##,##0.00").Replace(",", ".")

            ddlClienteEdit.SelectedValue = _Almacen.id_cliente
            txtEditCodigo.Text = _Almacen.codigo
            txtEditNombre.Text = _Almacen.nombre
            txtEditCoefVol.Text = CoefVolumetrico

            Modal.AbrirModal("EditModal", "EditModalScript", Me)

        ElseIf e.CommandName.Equals(Mensajes.Eliminar.ToString) Then

            hdfIDDel.Value = Utilidades_Grid.Get_IdRow(GridView1, e)
            Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)
        End If

    End Sub
    Protected Sub GridView1_OnSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        Utilidades_Grid.sortGridView(GridView1, e, ViewState("SortExpression"), ViewState("GridViewSortDirection"))

        Tabla.Almacen(GridView1, idCliente, "" & ViewState("SortExpression"), "" & ViewState("GridViewSortDirection"), String.Empty & ViewState("filtroBusqueda"), String.Empty & ViewState("textoBusqueda"))

    End Sub
    Protected Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs)
        Utilidades_Grid.SetArrowsGrid(GridView1, e)
    End Sub

    ''' <summary>
    ''' Metodo que crea un objeto Almacen y lo guarda en la base de datos
    ''' </summary>
    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _Nuevo As New Almacen With {
            .nombre = txtNombre.Text,
            .codigo = txtCodigo.Text,
            .coeficiente_volumetrico = Double.Parse(txtCoefVol.Text, CultureInfo.InvariantCulture),
            .id_cliente = Convert.ToInt32(ddlClienteAdd.SelectedValue)
        }

        bError = Create.Almacen(_Nuevo)

        Modal.CerrarModal("AddModal", "AddModalScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Registrar.ToString, bError, Me, updatePanelPrinicpal, up_Add)

        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que Edita un objeto Almacen y actualiza el registro en la base de datos
    ''' </summary>
    Protected Sub Editar(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim Edit = Getter.Almacen(Convert.ToInt32(hdfEdit.Value), contexto)

        If Edit IsNot Nothing Then
            Edit.id_cliente = Convert.ToInt32(ddlClienteEdit.SelectedValue)
            Edit.codigo = txtEditCodigo.Text
            Edit.nombre = txtEditNombre.Text
            Edit.coeficiente_volumetrico = Double.Parse(txtEditCoefVol.Text, CultureInfo.InvariantCulture)
        End If

        bError = Update.Almacen(Edit, contexto)

        Modal.CerrarModal("EditModal", "EditModallScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Editar.ToString, bError, Me, updatePanelPrinicpal, up_Edit)

        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que Elimina un registro de Almacen de la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)
        bError = Delete.Almacen(Convert.ToInt32(hdfIDDel.Value))
        Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)

        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Eliminar.ToString, bError, Me, updatePanelPrinicpal, Nothing)

        LlenarGridView()
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
                Dim dtChild As DataTable = GetData(Comandos.Arbol_Almacen_Nivel1.ToString + child.Value)
                LlenarTreeView(dtChild, 1, child)
            ElseIf parentId = 1 Then
                treeNode.ChildNodes.Add(child)
                Dim dtChild As DataTable = Me.GetData(Comandos.Arbol_Almacen_Nivel2.ToString + child.Value)
                LlenarTreeView(dtChild, 2, child)
            Else
                treeNode.ChildNodes.Add(child)
            End If
        Next

        MyTreeView.CollapseAll()

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
    ''' Metodo que realiza una busqueda en el grid
    ''' </summary>
    Protected Sub Buscar(sender As Object, e As EventArgs) Handles btnBuscar.Click

        ViewState("filtroBusqueda") = ddlBuscar.SelectedValue
        ViewState("textoBusqueda") = txtSearch.Text
        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que realiza una resetea la busqueda en el grid
    ''' </summary>
    Protected Sub Reset(sender As Object, e As EventArgs) Handles btnReset.Click
        txtSearch.Text = String.Empty
        ViewState("filtroBusqueda") = String.Empty
        ViewState("textoBusqueda") = String.Empty

        LlenarGridView()
    End Sub

End Class