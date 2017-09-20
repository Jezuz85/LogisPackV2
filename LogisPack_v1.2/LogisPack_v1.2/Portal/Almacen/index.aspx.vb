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
        Tabla.Almacen(GridView1, idCliente, "", "")
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
        End If

    End Sub
    Protected Sub GridView1_onRowEditing(sender As Object, e As GridViewEditEventArgs)

        hdfEdit.Value = Utilidades_Grid.Get_IdRow_Editing(GridView1, e)
        Dim _Almacen = Getter.Almacen(Convert.ToInt32(hdfEdit.Value))
        Listas.Cliente(ddlClienteEdit, idCliente)

        Dim CoefVolumetrico As String = Convert.ToDouble(_Almacen.coeficiente_volumetrico).ToString("##,##0.00").Replace(",", ".")

        ddlClienteEdit.SelectedValue = _Almacen.id_cliente
        txtEditCodigo.Text = _Almacen.codigo
        txtEditNombre.Text = _Almacen.nombre
        txtEditCoefVol.Text = CoefVolumetrico

        Modal.AbrirModal("EditModal", "EditModalScript", Me)

    End Sub
    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        hdfIDDel.Value = Utilidades_Grid.Get_IdRow_Deleting(GridView1, e)
        Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)

    End Sub
    Protected Sub GridView1_OnSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        Dim sortField = e.SortExpression
        Dim SortDirection = e.SortDirection

        If GridView1.Attributes("CurrentSortField") IsNot Nothing AndAlso
            GridView1.Attributes("CurrentSortDirection") IsNot Nothing Then

            If sortField = GridView1.Attributes("CurrentSortField") Then
                If GridView1.Attributes("CurrentSortDirection") = "ASC" Then
                    SortDirection = SortDirection.Descending
                Else
                    SortDirection = SortDirection.Ascending
                End If
            End If

            GridView1.Attributes("CurrentSortField") = sortField
            ViewState("SortExpression") = sortField

            If SortDirection = SortDirection.Ascending Then
                GridView1.Attributes("CurrentSortDirection") = "ASC"
                ViewState("GridViewSortDirection") = SortDirection.Ascending
            Else
                GridView1.Attributes("CurrentSortDirection") = "DESC"
                ViewState("GridViewSortDirection") = SortDirection.Descending
            End If


        End If
        'If e.SortExpression <> ViewState("SortExpression") Then
        '    e.SortDirection = SortDirection.Descending
        '    ViewState("GridViewSortDirection") = e.SortDirection

        'ElseIf ViewState("GridViewSortDirection") = SortDirection.Ascending Then
        '    ViewState("GridViewSortDirection") = SortDirection.Descending
        '    e.SortDirection = SortDirection.Descending

        'ElseIf ViewState("GridViewSortDirection") = SortDirection.Descending Then
        '    ViewState("GridViewSortDirection") = SortDirection.Ascending
        '    e.SortDirection = SortDirection.Ascending
        'End If
        'ViewState("SortExpression") = e.SortExpression

        Tabla.Almacen(GridView1, idCliente, "" & ViewState("SortExpression"), "" & ViewState("GridViewSortDirection"))

    End Sub
    Protected Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            For Each tc As TableCell In e.Row.Cells
                If tc.HasControls() Then

                    Dim lnk As LinkButton = Nothing

                    If TypeOf tc.Controls(0) Is LinkButton Then
                        lnk = CType(tc.Controls(0), LinkButton)
                    End If

                    If lnk IsNot Nothing AndAlso GridView1.Attributes("CurrentSortField") = lnk.CommandArgument Then
                        Dim image As New Image()

                        If GridView1.Attributes("CurrentSortDirection") = "ASC" Then
                            image.ImageUrl = "~/Content/images/arrow-orderasc.png"
                        Else
                            image.ImageUrl = "~/Content/images/arrow-orderdesc.png"
                        End If

                        tc.Controls.Add(New LiteralControl("&nbsp;"))
                        tc.Controls.Add(image)

                    End If



                End If

            Next

        End If

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

        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Editar.ToString, bError, Me, updatePanelPrinicpal, up_Edit)

        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que Elimina un registro de Almacen de la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)
        bError = Delete.Almacen(Convert.ToInt32(hdfIDDel.Value))

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

End Class