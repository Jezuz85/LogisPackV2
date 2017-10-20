Imports CapaDatos

Public Class Editar
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean
    Private IdArticulo As Integer = 0
    Private idCliente As Integer
    Private _DataTable As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Page.Form.Attributes.Add("enctype", "multipart/form-data")

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            idCliente = Mgr_Usuario.Get_Cliente_Usuario(Manager_Usuario.GetUserId(User))
            IdArticulo = Util_Cifrar.descifrarCadena_Num(Request.QueryString("id"))

            If Not IsPostBack Then
                ViewState(Val_Articulo.contUbicacion.ToString) = "0"
                CargarListas()
                CargarArticulo()
            Else
                Update_GridView_CurrentDatatable()
                Update_ViewState_Datatable()

                ObtenerControl_Postback(Me)
                For Each ctlID In Page.Request.Form.AllKeys
                    If ctlID IsNot Nothing Then

                        Dim c As Control = Page.FindControl(ctlID)

                        If c IsNot Nothing Then
                            If c.GetType() Is GetType(Button) Then

                                If c.ClientID.Contains(Val_Articulo.btnAddFilaUbicacion.ToString) Then
                                    crearCamposListaUbicacion(Convert.ToInt32(ViewState(Val_Articulo.contUbicacion.ToString) + 1))
                                ElseIf c.ClientID.Contains(Val_Articulo.btnEliminarFila.ToString) Then
                                    crearCamposListaUbicacion(Convert.ToInt32(ViewState(Val_Articulo.contUbicacion.ToString) - 1))
                                Else
                                    crearCamposListaUbicacion(Convert.ToInt32(ViewState(Val_Articulo.contUbicacion.ToString)))
                                End If

                            End If
                        End If

                    End If
                Next
            End If
        Else
            Response.Redirect(Val_Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para obtener el control que realizó el postback
    ''' </summary>
    Private Sub ObtenerControl_Postback(page As Page)

        Dim ctrl As Control = Util_UpdatePanel.ObtenerControl_PostBack(page)

        If ctrl IsNot Nothing Then
            If ctrl.ClientID.Contains(Val_Articulo.ddlTipoArticulo.ToString) Or
                ctrl.ClientID.Contains(Val_Articulo.ddlCliente.ToString) Or
                ctrl.ClientID.Contains(Val_Articulo.ddlAlmacen.ToString) Then
                crearCamposListaUbicacion(Convert.ToInt32(ViewState(Val_Articulo.contUbicacion.ToString)))
            End If
        End If

    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()

        Mgr_TipoFacturacion.LlenarLista(ddlTipoFacturacion)
        Mgr_TipoUnidad.LlenarLista(ddlTipoUnidad)
        Mgr_Cliente.Llenar_Lista(ddlCliente, idCliente)

    End Sub

    ''' <summary>
    ''' Metodo que crea la tabla ubicacion, para añadir o eliminar filas, para agregar ubicaciones al articulo
    ''' </summary>
    Private Sub crearCamposListaUbicacion(valor As Integer)

        ViewState(Val_Articulo.contUbicacion.ToString) = Convert.ToString(Mgr_Articulo.crearCamposListaUbicacion(valor, pTabla))

    End Sub

    ''' <summary>
    ''' Metodo que consulta el Coeficiente Volumetrico del almacen y lo asigna al articulo a crear al 
    ''' cargar la pagina
    ''' </summary>
    Private Sub CargarCoefVol(idAlmacen As Integer)

        Dim _Almacen = Mgr_Almacen.Consultar(idAlmacen)
        txtCoefVol.Text = _Almacen.coeficiente_volumetrico

    End Sub

    ''' <summary>
    ''' Metodo para eliminar la imagen seleccionada por el usario
    ''' </summary>
    Protected Sub EliminarImagen(sender As Object, e As EventArgs)

        bError = Mgr_Imagen.Eliminar(Convert.ToInt32(hdfIDDel.Value))
        Util_UpdatePanel.CerrarOperacion(Val_General.Eliminar.ToString, bError, Me, updatePanelPrinicpal, Nothing)
        Util_Modal.CerrarModal(Val_Articulo.DeleteModal.ToString, Val_Articulo.DeleteModalScript.ToString, Me)
        CargarImagenes(IdArticulo)

    End Sub

    '-----------------------------------Cargar Datos Articulo a Editar----------------------------------------------
    ''' <summary>
    ''' Metodo que en donde se realiza la carga de los datos del articulo y sus atributos
    ''' </summary>
    Private Sub CargarArticulo()

        Dim _Articulo As List(Of Articulo)
        _Articulo = Mgr_Articulo.Get_Articulo_list(IdArticulo)

        For Each itemArticulos In _Articulo

            CargarArticulo(itemArticulos)
            CargarArticulosPicking(itemArticulos)
            CargarImagenes(IdArticulo)
            CargarUbicacion(itemArticulos)

        Next

    End Sub

    ''' <summary>
    ''' Metodo que en donde se realiza la carga de los datos del articulo 
    ''' </summary>
    Private Sub CargarArticulo(itemArticulos As Articulo)

        ddlTipoArticulo.SelectedValue = itemArticulos.tipoArticulo
        ddlCliente.SelectedValue = itemArticulos.Almacen.id_cliente
        Mgr_Almacen.Llenar_Lista(ddlAlmacen, Convert.ToInt32(ddlCliente.SelectedValue))
        ddlAlmacen.SelectedValue = itemArticulos.id_almacen

        txtCodigo.Text = If(itemArticulos.codigo Is Nothing, String.Empty, itemArticulos.codigo)
        txtNombre.Text = If(itemArticulos.nombre Is Nothing, String.Empty, itemArticulos.nombre)
        txtRefPick.Text = If(itemArticulos.referencia_picking Is Nothing, String.Empty, itemArticulos.referencia_picking)
        txtRef1.Text = If(itemArticulos.referencia1 Is Nothing, String.Empty, itemArticulos.referencia1)
        txtRef2.Text = If(itemArticulos.referencia2 Is Nothing, String.Empty, itemArticulos.referencia2)
        txtRef3.Text = If(itemArticulos.referencia3 Is Nothing, String.Empty, itemArticulos.referencia3)
        ddlTipoUnidad.SelectedValue = If(itemArticulos.id_tipo_unidad Is Nothing, String.Empty, itemArticulos.id_tipo_unidad)
        ddlTipoFacturacion.SelectedValue = If(itemArticulos.id_tipo_facturacion Is Nothing, String.Empty, itemArticulos.id_tipo_facturacion)
        txtPeso.Text = itemArticulos.peso.ToString().Replace(",", ".")
        txtAlto.Text = itemArticulos.alto.ToString().Replace(",", ".")
        txtLargo.Text = itemArticulos.largo.ToString().Replace(",", ".")
        txtAncho.Text = itemArticulos.ancho.ToString().Replace(",", ".")
        txtCoefVol.Text = itemArticulos.coeficiente_volumetrico.ToString().Replace(",", ".")
        ddlIdentificacion.SelectedValue = itemArticulos.identificacion
        txtValArticulo.Text = itemArticulos.valor_articulo.ToString().Replace(",", ".")
        txtValAsegurado.Text = itemArticulos.valor_asegurado.ToString().Replace(",", ".")
        txtObsGen.Text = If(itemArticulos.observaciones_generales Is Nothing, String.Empty, itemArticulos.observaciones_generales)
        txtObsArt.Text = If(itemArticulos.observaciones_articulo Is Nothing, String.Empty, itemArticulos.observaciones_articulo)
        txtStockMinimo.Text = itemArticulos.stock_minimo.ToString().Replace(",", ".")
        txtStockFisico.Text = itemArticulos.stock_fisico.ToString().Replace(",", ".")

    End Sub

    ''' <summary>
    ''' Metodo que en donde se realiza la carga de los datos de los articulos de un picking
    ''' </summary>
    Private Sub CargarArticulosPicking(itemArticulos As Articulo)

        If itemArticulos.tipoArticulo = Val_Articulo.Tipo_Picking.ToString Then

            phListaArticulos.Visible = True
            LlenarGridview(itemArticulos.id_articulo)
            Update_ViewState_Datatable()
            Mgr_Articulo.ArticuloPickingEdit(ddlListaArticulos, GridView2, Convert.ToInt32(ddlAlmacen.SelectedValue))

        End If

    End Sub

    ''' <summary>
    ''' Metodo que en donde se realiza la carga de las imagenes del articulo
    ''' </summary>
    Private Sub CargarImagenes(idArticulo As Integer)

        Mgr_Imagen.LlenarGrid(GridView1, idArticulo)

    End Sub

    ''' <summary>
    ''' Metodo que en donde se realiza la carga de las ubicaciones del articulo
    ''' </summary>
    Private Sub CargarUbicacion(itemArticulos As Articulo)

        Dim miTextbox As TextBox

        If itemArticulos.Ubicacion.Count > 0 Then
            crearCamposListaUbicacion(itemArticulos.Ubicacion.Count - 1)
        End If

        Dim ContFilas As Integer = 0

        For Each itemUbicacion In itemArticulos.Ubicacion

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtZona.ToString & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.zona

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtEstante.ToString & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.estante

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtFila.ToString & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.fila

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtColumna.ToString & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.columna

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtPanel.ToString & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.panel

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtRefUbi.ToString & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.referencia_ubicacion

            ContFilas += 1
        Next

    End Sub


    '-----------------------------------Metodos del Gridview de imagenes--------------------------------------------------------
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        CargarImagenes(IdArticulo)
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Val_General.Eliminar.ToString) Then
            hdfIDDel.Value = Util_Grid.Get_IdRow(GridView1, e, "id")
            Util_Modal.AbrirModal(Val_Articulo.DeleteModal.ToString, Val_Articulo.DeleteModalScript.ToString, Me)
        End If

    End Sub

    '-----------------------------------Metodos del Gridview de Articulos picking--------------------------------------------------------

    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Val_General.EliminarFila.ToString) Then

            Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
            Dim gvrow As GridViewRow = GridView2.Rows(RowIndex)

            _DataTable = CType(ViewState(Val_Articulo.CurrentTable.ToString), DataTable)
            _DataTable.Rows(RowIndex).Delete()

            Update_ViewState_Datatable()
            Update_GridView_CurrentDatatable()
            Update_ViewState_Datatable()

            btnAddArticuloRow.Visible = True
            ddlListaArticulos.Items.Insert(0, New ListItem("" + gvrow.Cells(1).Text, String.Empty + gvrow.Cells(0).Text))

        End If

    End Sub
    Protected Sub GridView2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView2.PageIndex = e.NewPageIndex
        Update_GridView_CurrentDatatable()
    End Sub

    Private Sub AddRowGridview()

        _DataTable = CType(ViewState(Val_Articulo.CurrentTable.ToString), DataTable)
        Util_Grid.AddRow_Grid_ArtPick(_DataTable, ddlListaArticulos.SelectedValue, ddlListaArticulos.SelectedItem.ToString, txtUnidad.Text)
        Update_ViewState_Datatable()
        Util_Grid.Update_GridView_CurrentDatatable(_DataTable, GridView2)
        Update_GridView_CurrentDatatable()

    End Sub

    Private Sub LlenarGridview(_id_articulo As Integer)

        Mgr_Articulo.Llenar_Grid_ArticuloPicking(GridView2, _id_articulo)

        If GridView2.Rows.Count > 0 Then
            GridtoDataTable()
            Update_ViewState_Datatable()
        Else
            Util_Grid.Ini_Grid_ArtPick(_DataTable)
            Update_ViewState_Datatable()
            Update_GridView_CurrentDatatable()
        End If


    End Sub

    Private Sub GridtoDataTable()

        _DataTable = New DataTable()
        ' add the columns to the datatable
        If GridView2.HeaderRow IsNot Nothing Then
            For i As Integer = 0 To GridView2.HeaderRow.Cells.Count - 1
                _DataTable.Columns.Add(GridView2.HeaderRow.Cells(i).Text)
            Next
        End If

        ' add each of the data rows to the table
        For Each row As GridViewRow In GridView2.Rows
            Dim dr As DataRow
            dr = _DataTable.NewRow()

            For i As Integer = 0 To row.Cells.Count - 1
                dr(i) = row.Cells(i).Text.Replace(" ", String.Empty)

            Next
            _DataTable.Rows.Add(dr)

        Next


    End Sub

    Private Sub Update_GridView_CurrentDatatable()
        _DataTable = CType(ViewState(Val_Articulo.CurrentTable.ToString), DataTable)
        Util_Grid.Update_GridView_CurrentDatatable(_DataTable, GridView2)
    End Sub

    Private Sub Update_ViewState_Datatable()
        ViewState(Val_Articulo.CurrentTable.ToString) = _DataTable
    End Sub

    '-----------------------------------Editar----------------------------------------------------
    ''' <summary>
    ''' Metodos que edita el articulo y devuelve true si la operacion fue exitosa y caso contrario false
    ''' </summary>
    Private Function EditarArticulo(Edit As Articulo) As Boolean

#Region "creo la estructura articulo"
        Dim _miArticulo = Mgr_Articulo.Get_Struct()
        _miArticulo.codigo = txtCodigo.Text
        _miArticulo.nombre = txtNombre.Text
        _miArticulo.id_almacen = ddlAlmacen.SelectedValue
        _miArticulo.referencia1 = txtRef1.Text
        _miArticulo.referencia2 = txtRef2.Text
        _miArticulo.referencia3 = txtRef3.Text
        _miArticulo.tipoArticulo = ddlTipoArticulo.SelectedValue
        _miArticulo.identificacion = ddlIdentificacion.SelectedValue
        _miArticulo.id_tipo_unidad = ddlTipoUnidad.SelectedValue
        _miArticulo.referencia_picking = txtRefPick.Text
        _miArticulo.id_tipo_facturacion = ddlTipoFacturacion.SelectedValue
        _miArticulo.observaciones_articulo = txtObsArt.Text
        _miArticulo.observaciones_generales = txtObsGen.Text
        _miArticulo.peso = txtPeso.Text
        _miArticulo.alto = txtAlto.Text
        _miArticulo.largo = txtLargo.Text
        _miArticulo.ancho = txtAncho.Text
        _miArticulo.stock_fisico = txtStockFisico.Text
        _miArticulo.stock_minimo = txtStockMinimo.Text
        _miArticulo.valor_articulo = txtValArticulo.Text
        _miArticulo.coeficiente_volumetrico = txtCoefVol.Text
        _miArticulo.valor_asegurado = txtValAsegurado.Text
#End Region

        Dim _ArticuloEdit = Mgr_Articulo.Crear_Objeto(_miArticulo)

        If Edit IsNot Nothing Then
            Edit.codigo = _ArticuloEdit.codigo
            Edit.nombre = _ArticuloEdit.nombre
            Edit.referencia_picking = _ArticuloEdit.referencia_picking
            Edit.referencia1 = _ArticuloEdit.referencia1
            Edit.referencia2 = _ArticuloEdit.referencia2
            Edit.referencia3 = _ArticuloEdit.referencia3
            Edit.identificacion = _ArticuloEdit.identificacion
            Edit.valor_articulo = _ArticuloEdit.valor_articulo
            Edit.valor_asegurado = _ArticuloEdit.valor_asegurado
            Edit.valoracion_stock = _ArticuloEdit.valoracion_stock
            Edit.valoracion_seguro = _ArticuloEdit.valoracion_seguro
            Edit.peso = _ArticuloEdit.peso
            Edit.alto = _ArticuloEdit.alto
            Edit.largo = _ArticuloEdit.largo
            Edit.ancho = _ArticuloEdit.ancho
            Edit.coeficiente_volumetrico = _ArticuloEdit.coeficiente_volumetrico
            Edit.cubicaje = _ArticuloEdit.cubicaje
            Edit.peso_volumen = _ArticuloEdit.peso_volumen
            Edit.observaciones_articulo = _ArticuloEdit.observaciones_articulo
            Edit.observaciones_generales = _ArticuloEdit.observaciones_generales
            Edit.stock_fisico = _ArticuloEdit.stock_fisico
            Edit.stock_minimo = _ArticuloEdit.stock_minimo
            Edit.id_almacen = _ArticuloEdit.id_almacen
            Edit.id_tipo_facturacion = _ArticuloEdit.id_tipo_facturacion
            Edit.id_tipo_unidad = _ArticuloEdit.id_tipo_unidad
            Edit.tipoArticulo = _ArticuloEdit.tipoArticulo
        End If


        Return Mgr_Articulo.Editar(Edit, contexto)

    End Function

    ''' <summary>
    ''' Metodos que edita las imagenes del articulo y devuelve true si la operacion fue exitosa y caso contrario false
    ''' </summary>
    Private Function EditarImagenes(Edit As Articulo) As Boolean

        Return Mgr_Imagen.RecorrerGrid_Guardar(fuImagenes, Edit.id_articulo)

    End Function

    ''' <summary>
    ''' Metodos que edita las ubicaciones del articulo y devuelve true si la operacion fue exitosa y caso contrario false
    ''' </summary>
    Private Function EditarUbicaciones(Edit As Articulo) As Boolean

        bError = True

        If Edit.Ubicacion.Count > 0 Then

            Dim _ListUbicaion As List(Of Ubicacion) = Mgr_Ubicacion.Get_Ubicacion_list(Edit.id_articulo)
            For Each itemUbicacion In _ListUbicaion
                bError = Mgr_Ubicacion.Eliminar(itemUbicacion.id_ubicacion)
            Next

        End If

        Return Mgr_Ubicacion.RecorrerGrid_Guardar(pTabla, Edit.id_articulo)

    End Function

    ''' <summary>
    ''' Metodos que edita lso articulo picking del articulo y devuelve true si la operacion fue exitosa y caso contrario false
    ''' </summary>
    Private Function EditarPicking(Edit As Articulo) As Boolean

        Dim contadorControl As Integer = 0
        bError = True

        If ddlTipoArticulo.SelectedValue = Val_Articulo.Tipo_Picking.ToString Then

            If Edit.Picking_Articulo1.Count > 0 Then

                Dim _ListPicArt As List(Of Picking_Articulo) = Mgr_Articulo.Get_Picking_Articulo_list(Edit.id_articulo)

                For Each itemPicArt In _ListPicArt
                    bError = Mgr_Articulo.Eliminar_Picking_Articulo(itemPicArt.id_picking_articulo)
                Next

            Else
                bError = True
            End If

            If bError Then
                For Each row As GridViewRow In GridView2.Rows

                    Dim structPicking = Mgr_Articulo.Get_Struct_Picking(row, GridView1, Edit.id_articulo)
                    bError = Mgr_Articulo.Guardar_Picking_Articulo(Mgr_Articulo.Crear_Objeto(structPicking))

                Next
            End If

        End If

        Return bError
    End Function

    '--------------------------------------------------EVENTOS---------------------------------------------
    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un almacen, y se fija el valor del coeficiente volumetrico
    ''' al articulo dependiendo del valor que tenga el coeficiente del almacen
    ''' </summary>
    Protected Sub ddlAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAlmacen.SelectedIndexChanged

        Mgr_Articulo.SetCoefVolumétrico(ddlAlmacen, txtCoefVol, phListaArticulos, ddlTipoArticulo)
        Mgr_Articulo.ArticuloPickingEdit(ddlListaArticulos, GridView2, Convert.ToInt32(ddlAlmacen.SelectedValue))

    End Sub

    ''' <summary>
    ''' Metodos que se llama al presionar el boton editar, e invoca los metodos que hacen la actualizacion de un articulo
    ''' en la base de datos
    ''' </summary>
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Page.IsValid Then
            Dim Edit = Mgr_Articulo.Get_Articulo(IdArticulo, contexto)

            If EditarArticulo(Edit) Then
                If EditarImagenes(Edit) Then
                    If EditarUbicaciones(Edit) Then
                        If EditarPicking(Edit) Then

                            If ddlTipoArticulo.SelectedValue = Val_Articulo.Tipo_Picking.ToString Then

                                Util_UpdatePanel.LimpiarControles(updatePanelPrinicpal)
                                Mgr_Articulo.Llenar_Lista(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))
                                phListaArticulos.Visible = False
                                txtUnidad.Text = Nothing
                            End If
                            ddlAlmacen.SelectedValue = String.Empty
                            ddlCliente.SelectedValue = String.Empty

                        End If
                    End If
                End If
            End If

            Util_UpdatePanel.CerrarOperacion(Val_General.Editar.ToString, bError, Me, updatePanelPrinicpal, updatePanelPrinicpal)

        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se oprime el boton de añadir articulo al artiulo picking
    ''' </summary>
    Protected Sub btnAddArticuloRow_Click(sender As Object, e As EventArgs) Handles btnAddArticuloRow.Click

        If Page.IsValid Then
            AddRowGridview()

            ddlListaArticulos.Items.Remove(ddlListaArticulos.Items.FindByValue(ddlListaArticulos.SelectedValue))

            txtUnidad.Text = String.Empty
            If ddlListaArticulos.Items.Count = 0 Then
                btnAddArticuloRow.Visible = False
            End If

        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged
        Mgr_Articulo.CambiarCliente(ddlCliente, txtCoefVol, ddlAlmacen)
    End Sub

End Class