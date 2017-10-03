Imports System.Globalization
Imports CapaDatos
Imports Microsoft.AspNet.Identity

Public Class Crear
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Page.Form.Attributes.Add("enctype", "multipart/form-data")

        If Manager_Usuario.ValidarAutenticado(User) Then

            idCliente = Getter.Cliente_Usuario(Manager_Usuario.GetUserId(User))

            If Not IsPostBack Then
                ViewState("contadorUbi") = "0"
                CargarListas()

                InicializarGridView()

            Else
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

    Private Sub InicializarGridView()
        Dim dt As New DataTable()
        Dim dr As DataRow = Nothing

        dt.Columns.Add(New DataColumn("id_articulo", GetType(String)))
        dt.Columns.Add(New DataColumn("Articulo", GetType(String)))
        dt.Columns.Add(New DataColumn("Cantidad", GetType(String)))


        ViewState("CurrentTable") = dt
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    Private Sub CargarGridView()
        Dim rowIndex As Integer = 0
        Dim dtCurrentTable As DataTable = CType(ViewState("CurrentTable"), DataTable)
        Dim drCurrentRow As DataRow = Nothing

        ViewState("CurrentTable") = dtCurrentTable
        GridView1.DataSource = dtCurrentTable
        GridView1.DataBind()
    End Sub

    Private Sub AddRowGridview()
        Dim rowIndex As Integer = 0
        Dim dtCurrentTable As DataTable = CType(ViewState("CurrentTable"), DataTable)
        Dim drCurrentRow As DataRow = Nothing


        drCurrentRow = dtCurrentTable.NewRow()
        drCurrentRow("id_articulo") = ddlListaArticulos.SelectedValue
        drCurrentRow("Articulo") = ddlListaArticulos.SelectedItem
        drCurrentRow("Cantidad") = txtUnidad.Text
        dtCurrentTable.Rows.Add(drCurrentRow)

        ViewState("CurrentTable") = dtCurrentTable
        GridView1.DataSource = dtCurrentTable
        GridView1.DataBind()
    End Sub



    ''' <summary>
    ''' Metodo para obtener que lista hace el postback si Tipo de Articulo o Cliente y asi pintar las ubicaciones
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
    ''' Metodo que crea la tabla ubicacion, para añadir o eliminar filas, para agregar ubicaciones al articulo
    ''' </summary>
    Private Sub crearCamposListaUbicacion(valor As Integer)

        ViewState("contadorUbi") = Convert.ToString(Manager_Articulo.crearCamposListaUbicacion(valor, pTabla))

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para registrar un articulo en la base de datos
    ''' </summary>
    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Page.IsValid Then

            Dim Stock_Picking As Double = If(txtStockFisico.Text = String.Empty, 0, Double.Parse(txtStockFisico.Text, CultureInfo.InvariantCulture))

            If GuardarArticulo() Then
                Dim articuloView = Getter.Articulo_Ultimo()
                GuardarImagenes(articuloView)
                GuardarUbicaciones(articuloView)
                GuardarPicking(articuloView)
            End If

            Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Registrar.ToString, bError, Me, upAdd_Articulo, upAdd_Articulo)

            LimpiarControles()

        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para crear el articulo y registrarlo en la base de datos
    ''' </summary>
    Private Function GuardarArticulo() As Boolean

        Dim M3 As Double = 0
        Dim PesoVol As Double = 0
        Dim valoracionStock As Double = 0
        Dim valoracionSeguro As Double = 0

        M3 = Manager_Articulo.CalcularM3(txtAlto.Text, txtAncho.Text, txtLargo.Text)
        PesoVol = Manager_Articulo.CalcularPesoVolumetrico(txtAlto.Text, txtAncho.Text, txtLargo.Text, txtCoefVol.Text)
        valoracionStock = Manager_Articulo.CalcularValoracionStock(txtStockFisico.Text, txtValArticulo.Text)
        valoracionSeguro = Manager_Articulo.CalcularValoracionSeguro(txtValAsegurado.Text, txtStockFisico.Text)

        Dim _Nuevo As New Articulo With
            {
            .codigo = If(txtCodigo.Text = String.Empty, String.Empty, txtCodigo.Text),
            .nombre = If(txtNombre.Text = String.Empty, String.Empty, txtNombre.Text),
            .referencia_picking = If(txtRefPick.Text = String.Empty, String.Empty, txtRefPick.Text),
            .referencia1 = If(txtRef1.Text = String.Empty, String.Empty, txtRef1.Text),
            .referencia2 = If(txtRef2.Text = String.Empty, String.Empty, txtRef2.Text),
            .referencia3 = If(txtRef3.Text = String.Empty, String.Empty, txtRef3.Text),
            .identificacion = If(ddlIdentificacion.SelectedValue = String.Empty, String.Empty, ddlIdentificacion.SelectedValue),
            .valor_articulo = If(txtValArticulo.Text = String.Empty, Nothing, Double.Parse(txtValArticulo.Text, CultureInfo.InvariantCulture)),
            .valor_asegurado = If(txtValAsegurado.Text = String.Empty, Nothing, Double.Parse(txtValAsegurado.Text, CultureInfo.InvariantCulture)),
            .valoracion_stock = valoracionStock,
            .valoracion_seguro = valoracionSeguro,
            .peso = If(txtPeso.Text = String.Empty, Nothing, Double.Parse(txtPeso.Text, CultureInfo.InvariantCulture)),
            .alto = If(txtAlto.Text = String.Empty, Nothing, Double.Parse(txtAlto.Text, CultureInfo.InvariantCulture)),
            .largo = If(txtLargo.Text = String.Empty, Nothing, Double.Parse(txtLargo.Text, CultureInfo.InvariantCulture)),
            .ancho = If(txtAncho.Text = String.Empty, Nothing, Double.Parse(txtAncho.Text, CultureInfo.InvariantCulture)),
            .coeficiente_volumetrico = If(txtCoefVol.Text = String.Empty, Nothing, Double.Parse(txtCoefVol.Text, CultureInfo.InvariantCulture)),
            .cubicaje = M3,
            .peso_volumen = PesoVol,
            .observaciones_articulo = If(txtObsArt.Text = String.Empty, Nothing, txtObsArt.Text),
            .observaciones_generales = If(txtObsGen.Text = String.Empty, Nothing, txtObsGen.Text),
            .stock_fisico = If(txtStockFisico.Text = String.Empty, 0, Double.Parse(txtStockFisico.Text, CultureInfo.InvariantCulture)),
            .stock_minimo = If(txtStockMinimo.Text = String.Empty, 0, Double.Parse(txtStockMinimo.Text, CultureInfo.InvariantCulture)),
            .id_almacen = If(ddlAlmacen.SelectedValue = String.Empty, Nothing, Convert.ToInt32(ddlAlmacen.SelectedValue)),
            .id_tipo_facturacion = If(ddlTipoFacturacion.SelectedValue = String.Empty, 0, Convert.ToInt32(ddlTipoFacturacion.SelectedValue)),
            .id_tipo_unidad = If(ddlTipoUnidad.SelectedValue = String.Empty, 0, Convert.ToInt32(ddlTipoUnidad.SelectedValue)),
            .tipoArticulo = If(ddlTipoArticulo.SelectedValue = String.Empty, Nothing, ddlTipoArticulo.SelectedValue)
        }

        bError = Create.Articulo(_Nuevo)

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que se ejecuta para crear las imagenes del articulo y registrarlo en la base de datos
    ''' </summary>
    Private Sub GuardarImagenes(articuloView As Articulo)

        Dim contadorControl As Integer = 0

        For Each _imagen In fuImagenes.PostedFiles

            contadorControl += 1

            If _imagen.ContentLength > 0 And _imagen IsNot Nothing Then

                Dim urlImagen As String = Utilidades_Fileupload.Subir_Archivos(_imagen, Paginas.URL_Articulos.ToString, "Img_" & articuloView.id_articulo & "_" & contadorControl)

                Dim _imagenes As New Imagen With
                            {
                            .nombre = "Imagen_" & DateTime.Now.ToString("(MM-dd-yy_H:mm:ss)"),
                            .id_articulo = articuloView.id_articulo,
                            .url_imagen = urlImagen
                        }
                Create.Imagen(_imagenes)
            End If

        Next
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para crear las ubicaciones del articulo y registrarlo en la base de datos
    ''' </summary>
    Private Sub GuardarUbicaciones(articuloView As Articulo)

        Dim contadorControl As Integer = 0
        Dim miTextbox As TextBox
        Dim _NuevoUbicaion As Ubicacion
        Dim zona As String = Nothing
        Dim estante As String = Nothing
        Dim fila As String = Nothing
        Dim columna As String = Nothing
        Dim panel As String = Nothing
        Dim referencia_ubicacion As String = Nothing

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
                                .id_articulo = articuloView.id_articulo
                            }

                    Create.Ubicacion(_NuevoUbicaion)
                    referencia_ubicacion = Nothing

                End If
            End If

            contadorControl += 1
        Next
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para registrar los articulos que conforman el articulo picking y registrarlo en la base de datos
    ''' </summary>
    Private Sub GuardarPicking(articuloView As Articulo)

        Dim contadorControl As Integer = 0

        If ddlTipoArticulo.SelectedValue = "Picking" Then

            For Each row As GridViewRow In GridView1.Rows

                Dim _id_articulo As String = GridView1.DataKeys(row.RowIndex).Values(0).ToString
                Dim _unidades As String = row.Cells(2).Text

                Dim _NuevoPic_Art As New Picking_Articulo With {
                            .unidades = _unidades,
                            .id_articulo = _id_articulo,
                            .id_picking = articuloView.id_articulo
                        }
                bError = Create.Picking_Articulo(_NuevoPic_Art)

            Next

        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para limpiar los valores del updatepanel
    ''' </summary>
    Private Sub LimpiarControles()

        If bError Then
            If ddlTipoArticulo.SelectedValue = "Picking" Then

                Utilidades_UpdatePanel.LimpiarControles(upAdd_Articulo)
                Listas.Articulo(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))
                phListaArticulos.Visible = False
                txtUnidad.Text = Nothing
            End If
            ddlAlmacen.SelectedValue = ""
            ddlCliente.SelectedValue = ""
        End If
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
    ''' Metodo que se ejecuta cuando se selecciona un tipo de articulo, y sirve para mostrar los articulos a agregar
    ''' </summary>
    Protected Sub ddlTipoArticulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoArticulo.SelectedIndexChanged

        If ddlTipoArticulo.SelectedValue = "Picking" And ddlAlmacen.SelectedValue <> String.Empty Then
            Listas.Articulo(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))
            phListaArticulos.Visible = True
        Else
            phListaArticulos.Visible = False
        End If


    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un almacen, y se fija el valor del coeficiente volumetrico
    ''' al articulo dependiendo del valor que tenga el coeficiente del almacen
    ''' </summary>
    Protected Sub SetCoefVolumétrico(sender As Object, e As EventArgs) Handles ddlAlmacen.SelectedIndexChanged

        Manager_Articulo.SetCoefVolumétrico(ddlAlmacen, txtCoefVol, phListaArticulos, ddlTipoArticulo)
        Listas.Articulo(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))

    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals("DelRow") Then

            Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
            Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)

            Dim idArticulo As String = gvrow.Cells(0).Text
            Dim Articulo As String = gvrow.Cells(1).Text

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim dt As DataTable = TryCast(ViewState("CurrentTable"), DataTable)
            dt.Rows(index).Delete()

            ViewState("CurrentTable") = dt
            GridView1.DataSource = dt
            GridView1.DataBind()


            btnAddArticuloRow.Visible = True
            ddlListaArticulos.Items.Insert(0, New ListItem("" + Articulo, "" + idArticulo))

        End If

    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        CargarGridView()
    End Sub




End Class