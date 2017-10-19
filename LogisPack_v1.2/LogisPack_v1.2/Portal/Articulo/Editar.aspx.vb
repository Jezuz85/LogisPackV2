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
            Response.Redirect(Val_Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para obtener el control que realizó el postback
    ''' </summary>
    Private Sub ObtenerControl_Postback(page As Page)

        Dim ctrl As Control = Util_UpdatePanel.ObtenerControl_PostBack(page)

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

        Mgr_TipoFacturacion.LlenarLista(ddlTipoFacturacion)
        Mgr_TipoUnidad.LlenarLista(ddlTipoUnidad)
        Mgr_Cliente.Llenar_Lista(ddlCliente, idCliente)

    End Sub

    ''' <summary>
    ''' Metodo que crea la tabla ubicacion, para añadir o eliminar filas, para agregar ubicaciones al articulo
    ''' </summary>
    Private Sub crearCamposListaUbicacion(valor As Integer)

        ViewState("contadorUbi") = Convert.ToString(Mgr_Articulo.crearCamposListaUbicacion(valor, pTabla))

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

        Util_Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)

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
        txtCodigo.Text = itemArticulos.codigo
        txtNombre.Text = itemArticulos.nombre
        txtRefPick.Text = itemArticulos.referencia_picking
        txtRef1.Text = itemArticulos.referencia1
        txtRef2.Text = itemArticulos.referencia2
        txtRef3.Text = itemArticulos.referencia3
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


    '-----------------------------------Metodos del Gridview de imagenes--------------------------------------------------------
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        CargarImagenes(IdArticulo)
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Val_General.Eliminar.ToString) Then
            hdfIDDel.Value = Util_Grid.Get_IdRow(GridView1, e, "id")
            Util_Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)
        End If

    End Sub

    '-----------------------------------Metodos del Gridview de Articulos picking--------------------------------------------------------

    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Val_General.EliminarFila.ToString) Then

            Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
            Dim gvrow As GridViewRow = GridView2.Rows(RowIndex)

            _DataTable = CType(ViewState("CurrentTable"), DataTable)
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
        _DataTable = CType(ViewState("CurrentTable"), DataTable)
        Util_Grid.Update_GridView_CurrentDatatable(_DataTable, GridView2)
    End Sub

    Private Sub Update_ViewState_Datatable()
        ViewState("CurrentTable") = _DataTable
    End Sub

    '-----------------------------------Editar----------------------------------------------------
    ''' <summary>
    ''' Metodos que edita el articulo y devuelve true si la operacion fue exitosa y caso contrario false
    ''' </summary>
    Private Function EditarArticulo(Edit As Articulo) As Boolean

        '----------------Validar strings vacios

        Dim _codigo = Util_Validaciones.Validar_Campo_Vacio(txtCodigo.Text, String.Empty)
        Dim _nombre = Util_Validaciones.Validar_Campo_Vacio(txtNombre.Text, String.Empty)
        Dim _id_almacen = Convert.ToInt32(ddlAlmacen.SelectedValue)
        Dim _referencia1 = Util_Validaciones.Validar_Campo_Vacio(txtRef1.Text, String.Empty)
        Dim _referencia2 = Util_Validaciones.Validar_Campo_Vacio(txtRef2.Text, String.Empty)
        Dim _referencia3 = Util_Validaciones.Validar_Campo_Vacio(txtRef3.Text, String.Empty)
        Dim _tipoArticulo = Util_Validaciones.Validar_Campo_Vacio(ddlTipoArticulo.SelectedValue, "0")
        Dim _identificacion = Util_Validaciones.Validar_Campo_Vacio(ddlIdentificacion.SelectedValue, String.Empty)
        Dim _id_tipo_unidad = Util_Validaciones.Validar_Campo_Vacio(ddlTipoUnidad.SelectedValue, "0")
        Dim _referencia_picking = Util_Validaciones.Validar_Campo_Vacio(txtRefPick.Text, String.Empty)
        Dim _id_tipo_facturacion = Util_Validaciones.Validar_Campo_Vacio(ddlTipoFacturacion.SelectedValue, "0")
        Dim _observaciones_articulo = Util_Validaciones.Validar_Campo_Vacio(txtObsArt.Text, String.Empty)
        Dim _observaciones_generales = Util_Validaciones.Validar_Campo_Vacio(txtObsGen.Text, String.Empty)

        '-----------------Validar campos vacios y formatear decimalesTTT

        Dim _peso As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(txtPeso.Text, "0"))
        Dim _alto As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(txtAlto.Text, "0"))
        Dim _largo As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(txtLargo.Text, "0"))
        Dim _ancho As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(txtAncho.Text, "0"))
        Dim _stock_fisico As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(txtStockFisico.Text, 0))
        Dim _stock_minimo As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(txtStockMinimo.Text, "0"))
        Dim _valor_articulo As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(txtValArticulo.Text, 0))
        Dim _coeficiente_volumetrico As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(txtCoefVol.Text, "0"))
        Dim _valor_asegurado As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(txtValAsegurado.Text, "0"))

        '-----------------Calculos

        Dim _M3 As Double = Mgr_Articulo.CalcularM3(_alto, _ancho, _largo)
        Dim _PesoVol As Double = Mgr_Articulo.Calcular_PesoVolumetrico(_alto, _ancho, _largo, _coeficiente_volumetrico)
        Dim _valoracionStock As Double = Mgr_Articulo.Calcular_ValoracionStock(_stock_fisico, _valor_articulo)
        Dim _valoracionSeguro As Double = Mgr_Articulo.Calcular_ValoracionSeguro(_valor_asegurado, _stock_fisico)

        bError = True

        If Edit IsNot Nothing Then

            Edit.codigo = _codigo
            Edit.nombre = _nombre
            Edit.referencia_picking = _referencia_picking
            Edit.referencia1 = _referencia1
            Edit.referencia2 = _referencia2
            Edit.referencia3 = _referencia3
            Edit.identificacion = _identificacion
            Edit.valor_articulo = _valor_articulo
            Edit.valor_asegurado = _valor_asegurado
            Edit.valoracion_stock = _valoracionStock
            Edit.valoracion_seguro = _valoracionSeguro
            Edit.peso = _peso
            Edit.alto = _alto
            Edit.largo = _largo
            Edit.ancho = _ancho
            Edit.coeficiente_volumetrico = _coeficiente_volumetrico
            Edit.cubicaje = _M3
            Edit.peso_volumen = _PesoVol
            Edit.observaciones_articulo = _observaciones_articulo
            Edit.observaciones_generales = _observaciones_generales
            Edit.stock_fisico = _stock_fisico
            Edit.stock_minimo = _stock_minimo
            Edit.id_almacen = Convert.ToInt32(ddlAlmacen.SelectedValue)
            Edit.id_tipo_facturacion = _id_tipo_facturacion
            Edit.id_tipo_unidad = _id_tipo_unidad
            Edit.tipoArticulo = _tipoArticulo

        End If

        bError = Mgr_Articulo.Editar(Edit, contexto)

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

                Dim urlImagen As String = Util_Fileupload.Subir_Archivos(_imagen, "../../Archivos/Articulos/", "Img_" & Edit.id_articulo & "_" & contadorControl)

                Dim _imagenes As New Imagen With
                    {
                    .nombre = "Imagen_" & DateTime.Now.ToString("(MM-dd-yy_H:mm:ss)"),
                    .id_articulo = Edit.id_articulo,
                    .url_imagen = urlImagen
                }
                bError = Mgr_Imagen.Guardar(_imagenes)
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

            Dim _ListUbicaion As List(Of Ubicacion) = Mgr_Ubicacion.Get_Ubicacion_list(Edit.id_articulo)
            For Each itemUbicacion In _ListUbicaion
                bError = Mgr_Ubicacion.Eliminar(itemUbicacion.id_ubicacion)
            Next

        End If

        If bError Then
            contadorControl = 0
            For Each micontrol As Control In pTabla.Controls

                miTextbox = CType(pTabla.FindControl("txtZona" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    zona = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
                End If

                miTextbox = CType(pTabla.FindControl("txtEstante" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    estante = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
                End If

                miTextbox = CType(pTabla.FindControl("txtFila" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    fila = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
                End If

                miTextbox = CType(pTabla.FindControl("txtColumna" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    Dim valor As String = miTextbox.Text.PadLeft(4, "0")
                    columna = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text.PadLeft(4, "0"))
                End If

                miTextbox = CType(pTabla.FindControl("txtPanel" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    panel = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
                End If

                miTextbox = CType(pTabla.FindControl("txtRefUbi" & contadorControl), TextBox)
                If miTextbox IsNot Nothing Then
                    referencia_ubicacion = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
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

                        bError = Mgr_Ubicacion.Guardar(_NuevoUbicaion)

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

                Dim _ListPicArt As List(Of Picking_Articulo) = Mgr_Articulo.Get_Picking_Articulo_list(Edit.id_articulo)

                For Each itemPicArt In _ListPicArt
                    bError = Mgr_Articulo.Eliminar_Picking_Articulo(itemPicArt.id_picking_articulo)
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
                    bError = Mgr_Articulo.Guardar_Picking_Articulo(_NuevoPic_Art)

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

                            If ddlTipoArticulo.SelectedValue = "Picking" Then

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