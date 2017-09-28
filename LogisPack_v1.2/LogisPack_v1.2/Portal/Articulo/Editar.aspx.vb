Imports System.Globalization
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

            idCliente = Getter.Cliente_Usuario(Manager_Usuario.GetUserId(User))
            IdArticulo = Cifrar.descifrarCadena_Num(Request.QueryString("id"))

            If Not IsPostBack Then
                ViewState("contadorUbi") = "0"
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

                                If c.ClientID.Contains("btnAddFilaUbicacion") Then
                                    crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi") + 1))
                                ElseIf c.ClientID.Contains("btnEliminarFila") Then
                                    crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi") - 1))
                                Else
                                    crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi")))
                                End If

                            End If
                        End If

                    End If
                Next
            End If
        Else
            Response.Redirect(Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para obtener el control que realizó el postback
    ''' </summary>
    Private Sub ObtenerControl_Postback(page As Page)

        Dim ctrl As Control = Utilidades_UpdatePanel.ObtenerControl_PostBack(page)

        If ctrl IsNot Nothing Then
            If ctrl.ClientID.Contains("ddlTipoArticulo") Or ctrl.ClientID.Contains("ddlCliente") Or ctrl.ClientID.Contains("ddlAlmacen") Then
                crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi")))
            End If
        End If

    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()
        Listas.TipoFacturacion(ddlTipoFacturacion)
        Listas.TipoUnidad(ddlTipoUnidad)
        Listas.Cliente(ddlCliente, idCliente)
    End Sub

    ''' <summary>
    ''' Metodo que en donde se realiza la carga de los datos del articulo y sus atributos
    ''' </summary>
    Private Sub CargarArticulo()

        Dim _Articulo As List(Of Articulo)
        _Articulo = Getter.Articulo_list(IdArticulo)

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
        Listas.Almacen(ddlAlmacen, Convert.ToInt32(ddlCliente.SelectedValue))
        ddlAlmacen.SelectedValue = itemArticulos.id_almacen
        txtCodigo.Text = itemArticulos.codigo
        txtNombre.Text = itemArticulos.nombre
        txtRefPick.Text = itemArticulos.referencia_picking
        txtRef1.Text = itemArticulos.referencia1
        txtRef2.Text = itemArticulos.referencia2
        txtRef3.Text = itemArticulos.referencia3
        ddlTipoUnidad.SelectedValue = itemArticulos.id_tipo_unidad
        txtPeso.Text = itemArticulos.peso.ToString().Replace(",", ".")
        txtAlto.Text = itemArticulos.alto.ToString().Replace(",", ".")
        txtLargo.Text = itemArticulos.largo.ToString().Replace(",", ".")
        txtAncho.Text = itemArticulos.ancho.ToString().Replace(",", ".")
        txtCoefVol.Text = itemArticulos.coeficiente_volumetrico.ToString().Replace(",", ".")
        ddlTipoFacturacion.SelectedValue = itemArticulos.id_tipo_facturacion
        ddlIdentificacion.SelectedValue = itemArticulos.identificacion
        txtValArticulo.Text = itemArticulos.valor_articulo.ToString().Replace(",", ".")
        txtValAsegurado.Text = itemArticulos.valor_asegurado.ToString().Replace(",", ".")
        txtObsGen.Text = itemArticulos.observaciones_generales
        txtObsArt.Text = itemArticulos.observaciones_articulo
        txtStockMinimo.Text = itemArticulos.stock_minimo.ToString().Replace(",", ".")
        txtStockFisico.Text = itemArticulos.stock_fisico.ToString().Replace(",", ".")

    End Sub

    ''' <summary>
    ''' Metodo que en donde se realiza la carga de los datos de los articulos de un picking
    ''' </summary>
    Private Sub CargarArticulosPicking(itemArticulos As Articulo)

        If itemArticulos.tipoArticulo = "Picking" Then

            phListaArticulos.Visible = True

            LlenarGridview(itemArticulos.id_articulo)
            Update_ViewState_Datatable()

            Listas.ArticuloPickingEdit(ddlListaArticulos, GridView2, Convert.ToInt32(ddlAlmacen.SelectedValue))


        End If

    End Sub

    ''' <summary>
    ''' Metodo que en donde se realiza la carga de las imagenes del articulo
    ''' </summary>
    Private Sub CargarImagenes(idArticulo As Integer)
        Tabla.Imagen(GridView1, idArticulo)
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

            miTextbox = CType(pTabla.FindControl("txtZona" & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.zona


            miTextbox = CType(pTabla.FindControl("txtEstante" & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.estante

            miTextbox = CType(pTabla.FindControl("txtFila" & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.fila

            miTextbox = CType(pTabla.FindControl("txtColumna" & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.columna

            miTextbox = CType(pTabla.FindControl("txtPanel" & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.panel

            miTextbox = CType(pTabla.FindControl("txtRefUbi" & ContFilas), TextBox)
            miTextbox.Text = itemUbicacion.referencia_ubicacion

            ContFilas += 1
        Next

    End Sub


    ''' <summary>
    ''' Metodos del Gridview
    ''' </summary>
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        CargarImagenes(IdArticulo)
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Mensajes.Eliminar.ToString) Then
            hdfIDDel.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)
        End If

    End Sub

    ''' <summary>
    ''' Metodos que se llama al presionar el boton editar, e invoca los metodos que hacen la actualizacion de un articulo
    ''' en la base de datos
    ''' </summary>
    Protected Sub Editar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Page.IsValid Then
            Dim Edit = Getter.Articulo(IdArticulo, contexto)

            If EditarArticulo(Edit) Then
                If EditarImagenes(Edit) Then
                    If EditarUbicaciones(Edit) Then
                        If EditarPicking(Edit) Then

                            If ddlTipoArticulo.SelectedValue = "Picking" Then

                                Utilidades_UpdatePanel.LimpiarControles(updatePanelPrinicpal)
                                Listas.Articulo(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))
                                phListaArticulos.Visible = False
                                txtUnidad.Text = Nothing
                            End If
                            ddlAlmacen.SelectedValue = ""
                            ddlCliente.SelectedValue = ""

                        End If
                    End If
                End If
            End If

            Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Editar.ToString, bError, Me, updatePanelPrinicpal, updatePanelPrinicpal)

        End If

    End Sub

    ''' <summary>
    ''' Metodos que edita el articulo y devuelve true si la operacion fue exitosa y caso contrario false
    ''' </summary>
    Private Function EditarArticulo(Edit As Articulo) As Boolean

        Dim M3 As Double = 0
        Dim PesoVol As Double = 0
        Dim valoracionStock As Double = 0
        Dim valoracionSeguro As Double = 0
        bError = True

        M3 = Manager_Articulo.CalcularM3(txtAlto.Text, txtAncho.Text, txtLargo.Text)
        PesoVol = Manager_Articulo.CalcularPesoVolumetrico(txtAlto.Text, txtAncho.Text, txtLargo.Text, txtCoefVol.Text)
        valoracionStock = Manager_Articulo.CalcularValoracionStock(txtStockFisico.Text, txtValArticulo.Text)
        valoracionSeguro = Manager_Articulo.CalcularValoracionSeguro(txtValAsegurado.Text, txtStockFisico.Text)

        If Edit IsNot Nothing Then

            Edit.codigo = If(txtCodigo.Text = String.Empty, String.Empty, txtCodigo.Text)
            Edit.nombre = If(txtNombre.Text = String.Empty, String.Empty, txtNombre.Text)
            Edit.referencia_picking = If(txtRefPick.Text = String.Empty, String.Empty, txtRefPick.Text)
            Edit.referencia1 = If(txtRef1.Text = String.Empty, String.Empty, txtRef1.Text)
            Edit.referencia2 = If(txtRef2.Text = String.Empty, String.Empty, txtRef2.Text)
            Edit.referencia3 = If(txtRef3.Text = String.Empty, String.Empty, txtRef3.Text)
            Edit.identificacion = If(ddlIdentificacion.SelectedValue = String.Empty, String.Empty, ddlIdentificacion.SelectedValue)
            Edit.valor_articulo = If(txtValArticulo.Text = String.Empty, Nothing, Double.Parse(txtValArticulo.Text, CultureInfo.InvariantCulture))
            Edit.valor_asegurado = If(txtValAsegurado.Text = String.Empty, Nothing, Double.Parse(txtValAsegurado.Text, CultureInfo.InvariantCulture))
            Edit.valoracion_stock = valoracionStock
            Edit.valoracion_seguro = valoracionSeguro
            Edit.peso = If(txtPeso.Text = String.Empty, Nothing, Double.Parse(txtPeso.Text, CultureInfo.InvariantCulture))
            Edit.alto = If(txtAlto.Text = String.Empty, Nothing, Double.Parse(txtAlto.Text, CultureInfo.InvariantCulture))
            Edit.largo = If(txtLargo.Text = String.Empty, Nothing, Double.Parse(txtLargo.Text, CultureInfo.InvariantCulture))
            Edit.ancho = If(txtAncho.Text = String.Empty, Nothing, Double.Parse(txtAncho.Text, CultureInfo.InvariantCulture))
            Edit.coeficiente_volumetrico = If(txtCoefVol.Text = String.Empty, Nothing, Double.Parse(txtCoefVol.Text, CultureInfo.InvariantCulture))
            Edit.cubicaje = M3
            Edit.peso_volumen = PesoVol
            Edit.observaciones_articulo = If(txtObsArt.Text = String.Empty, Nothing, txtObsArt.Text)
            Edit.observaciones_generales = If(txtObsGen.Text = String.Empty, Nothing, txtObsGen.Text)
            Edit.stock_fisico = If(txtStockFisico.Text = String.Empty, Nothing, Double.Parse(txtStockFisico.Text, CultureInfo.InvariantCulture))
            Edit.stock_minimo = If(txtStockMinimo.Text = String.Empty, Nothing, Double.Parse(txtStockMinimo.Text, CultureInfo.InvariantCulture))
            Edit.id_almacen = If(ddlAlmacen.SelectedValue = String.Empty, Nothing, Convert.ToInt32(ddlAlmacen.SelectedValue))
            Edit.id_tipo_facturacion = If(ddlTipoFacturacion.SelectedValue = String.Empty, 0, Convert.ToInt32(ddlTipoFacturacion.SelectedValue))
            Edit.id_tipo_unidad = If(ddlTipoUnidad.SelectedValue = String.Empty, 0, Convert.ToInt32(ddlTipoUnidad.SelectedValue))
            Edit.tipoArticulo = If(ddlTipoArticulo.SelectedValue = String.Empty, Nothing, ddlTipoArticulo.SelectedValue)
        End If

        bError = Update.Articulo(Edit, contexto)

        Return bError
    End Function

    ''' <summary>
    ''' Metodos que edita las imagenes del articulo y devuelve true si la operacion fue exitosa y caso contrario false
    ''' </summary>
    Private Function EditarImagenes(Edit As Articulo) As Boolean

        Dim contadorControl As Integer = 0
        bError = True

        'Guardar fotos que fueron cargadas
        For Each _imagen In fuImagenes.PostedFiles
            contadorControl += 1
            If _imagen.ContentLength > 0 And _imagen IsNot Nothing Then

                Dim urlImagen As String = Utilidades_Fileupload.Subir_Archivos(_imagen, "../../Archivos/Articulos/", "Img_" & Edit.id_articulo & "_" & contadorControl)

                Dim _imagenes As New Imagen With
                    {
                    .nombre = "Imagen_" & DateTime.Now.ToString("(MM-dd-yy_H:mm:ss)"),
                    .id_articulo = Edit.id_articulo,
                    .url_imagen = urlImagen
                }
                bError = Create.Imagen(_imagenes)
            End If
        Next

        Return bError
    End Function

    ''' <summary>
    ''' Metodos que edita las ubicaciones del articulo y devuelve true si la operacion fue exitosa y caso contrario false
    ''' </summary>
    Private Function EditarUbicaciones(Edit As Articulo) As Boolean

        Dim miTextbox As TextBox
        Dim contadorControl As Integer = 0
        Dim zona As String = Nothing
        Dim estante As String = Nothing
        Dim fila As String = Nothing
        Dim columna As String = Nothing
        Dim panel As String = Nothing
        Dim referencia_ubicacion As String = Nothing
        Dim _NuevoUbicaion As Ubicacion
        bError = True

        If Edit.Ubicacion.Count > 0 Then

            Dim _ListUbicaion As List(Of Ubicacion) = Getter.Ubicacion_list(Edit.id_articulo)
            For Each itemUbicacion In _ListUbicaion
                bError = Delete.Ubicacion(itemUbicacion.id_ubicacion)
            Next

        End If

        If bError Then
            contadorControl = 0
            For Each micontrol As Control In pTabla.Controls

                miTextbox = CType(pTabla.FindControl("txtZona" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    zona = If(miTextbox.Text = String.Empty, "", miTextbox.Text)
                End If

                miTextbox = CType(pTabla.FindControl("txtEstante" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    estante = If(miTextbox.Text = String.Empty, "", miTextbox.Text)
                End If

                miTextbox = CType(pTabla.FindControl("txtFila" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    fila = If(miTextbox.Text = String.Empty, "", miTextbox.Text)
                End If

                miTextbox = CType(pTabla.FindControl("txtColumna" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    Dim valor As String = miTextbox.Text.PadLeft(4, "0")
                    columna = If(miTextbox.Text = String.Empty, "", miTextbox.Text.PadLeft(4, "0"))
                End If

                miTextbox = CType(pTabla.FindControl("txtPanel" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    panel = If(miTextbox.Text = String.Empty, "", miTextbox.Text)
                End If

                miTextbox = CType(pTabla.FindControl("txtRefUbi" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    referencia_ubicacion = If(miTextbox.Text = String.Empty, "", miTextbox.Text)
                End If

                If referencia_ubicacion IsNot Nothing Then

                    If (zona <> String.Empty) Or
                                (estante <> String.Empty) Or
                                (columna <> String.Empty) Or
                                (panel <> String.Empty) Or
                                (referencia_ubicacion <> String.Empty) Then

                        _NuevoUbicaion = New Ubicacion With {
                                    .zona = zona,
                                    .estante = estante,
                                    .fila = fila,
                                    .columna = columna,
                                    .panel = panel,
                                    .referencia_ubicacion = referencia_ubicacion,
                                    .id_articulo = Edit.id_articulo
                                }

                        bError = Create.Ubicacion(_NuevoUbicaion)

                        If bError = False Then
                            Return bError
                        End If

                        referencia_ubicacion = Nothing

                    End If
                End If

                contadorControl += 1
            Next
        End If

        Return bError
    End Function

    ''' <summary>
    ''' Metodos que edita lso articulo picking del articulo y devuelve true si la operacion fue exitosa y caso contrario false
    ''' </summary>
    Private Function EditarPicking(Edit As Articulo) As Boolean

        Dim contadorControl As Integer = 0
        bError = True

        If ddlTipoArticulo.SelectedValue = "Picking" Then

            If Edit.Picking_Articulo1.Count > 0 Then

                Dim _ListPicArt As List(Of Picking_Articulo) = Getter.Picking_Articulo_list(Edit.id_articulo)

                For Each itemPicArt In _ListPicArt
                    bError = Delete.Picking_Articulo(itemPicArt.id_picking_articulo)
                Next

            Else
                bError = True
            End If

            If bError Then
                For Each row As GridViewRow In GridView2.Rows

                    Dim _id_articulo As String = GridView2.DataKeys(row.RowIndex).Values(0).ToString
                    Dim _unidades As String = row.Cells(2).Text

                    Dim _NuevoPic_Art As New Picking_Articulo With {
                            .unidades = _unidades,
                            .id_articulo = _id_articulo,
                            .id_picking = Edit.id_articulo
                        }
                    bError = Create.Picking_Articulo(_NuevoPic_Art)

                Next
            End If

        End If

        Return bError
    End Function

    ''' <summary>
    ''' Metodo que crea la tabla ubicacion, para añadir o eliminar filas, para agregar ubicaciones al articulo
    ''' </summary>
    Private Sub crearCamposListaUbicacion(valor As Integer)

        ViewState("contadorUbi") = Convert.ToString(Manager_Articulo.crearCamposListaUbicacion(valor, pTabla))

    End Sub

    ''' <summary>
    ''' Metodo para eliminar la imagen seleccionada por el usario
    ''' </summary>
    Protected Sub EliminarImagen(sender As Object, e As EventArgs)

        bError = Delete.Imagen(Convert.ToInt32(hdfIDDel.Value))

        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Eliminar.ToString, bError, Me, updatePanelPrinicpal, Nothing)

        Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)

        CargarImagenes(IdArticulo)
    End Sub

    ''' <summary>
    ''' Metodo que consulta el Coeficiente Volumetrico del almacen y lo asigna al articulo a crear al 
    ''' cargar la pagina
    ''' </summary>
    Private Sub CargarCoefVol(idAlmacen As Integer)
        Dim _Almacen = Getter.Almacen(idAlmacen)
        txtCoefVol.Text = _Almacen.coeficiente_volumetrico
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Protected Sub CambiarCliente(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged
        Manager_Articulo.CambiarCliente(ddlCliente, txtCoefVol, ddlAlmacen)
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se oprime el boton de añadir articulo al artiulo picking
    ''' </summary>
    Protected Sub Añadir_ArticuloLista(sender As Object, e As EventArgs) Handles btnAddArticuloRow.Click

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
    ''' Metodo que se ejecuta cuando se selecciona un almacen, y se fija el valor del coeficiente volumetrico
    ''' al articulo dependiendo del valor que tenga el coeficiente del almacen
    ''' </summary>
    Protected Sub SetCoefVolumétrico(sender As Object, e As EventArgs) Handles ddlAlmacen.SelectedIndexChanged

        Manager_Articulo.SetCoefVolumétrico(ddlAlmacen, txtCoefVol, phListaArticulos, ddlTipoArticulo)

        Listas.ArticuloPickingEdit(ddlListaArticulos, GridView2, Convert.ToInt32(ddlAlmacen.SelectedValue))

    End Sub

    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals("DelRow") Then

            Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
            Dim gvrow As GridViewRow = GridView2.Rows(RowIndex)

            _DataTable = CType(ViewState("CurrentTable"), DataTable)
            _DataTable.Rows(RowIndex).Delete()

            Update_ViewState_Datatable()

            Update_GridView_CurrentDatatable()


            Update_ViewState_Datatable()
            btnAddArticuloRow.Visible = True
            ddlListaArticulos.Items.Insert(0, New ListItem("" + gvrow.Cells(1).Text, "" + gvrow.Cells(0).Text))

        End If

    End Sub
    Protected Sub GridView2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView2.PageIndex = e.NewPageIndex
        Update_GridView_CurrentDatatable()
    End Sub

    Private Sub AddRowGridview()
        Dim rowIndex As Integer = 0

        _DataTable = CType(ViewState("CurrentTable"), DataTable)

        Dim drCurrentRow As DataRow = Nothing
        drCurrentRow = _DataTable.NewRow()
        drCurrentRow("id_articulo") = ddlListaArticulos.SelectedValue
        drCurrentRow("Articulo") = ddlListaArticulos.SelectedItem
        drCurrentRow("Cantidad") = txtUnidad.Text
        _DataTable.Rows.Add(drCurrentRow)

        Update_ViewState_Datatable()
        Update_GridView_CurrentDatatable()

    End Sub

    Private Sub LlenarGridview(_id_articulo As Integer)

        Tabla.ArticuloPicking(GridView2, _id_articulo)

        If GridView2.Rows.Count > 0 Then
            GridtoDataTable()
            Update_ViewState_Datatable()
        Else
            InicializarGridView()
            Update_ViewState_Datatable()
            Update_GridView_CurrentDatatable()
        End If


    End Sub

    Private Sub InicializarGridView()
        _DataTable = New DataTable()
        _DataTable.Columns.Add(New DataColumn("id_articulo", GetType(String)))
        _DataTable.Columns.Add(New DataColumn("Articulo", GetType(String)))
        _DataTable.Columns.Add(New DataColumn("Cantidad", GetType(String)))
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
                dr(i) = row.Cells(i).Text.Replace(" ", "")

            Next
            _DataTable.Rows.Add(dr)

        Next


    End Sub

    Private Sub Update_GridView_CurrentDatatable()

        _DataTable = CType(ViewState("CurrentTable"), DataTable)
        GridView2.DataSource = _DataTable
        GridView2.DataBind()
    End Sub

    Private Sub Update_ViewState_Datatable()

        ViewState("CurrentTable") = _DataTable

    End Sub

End Class