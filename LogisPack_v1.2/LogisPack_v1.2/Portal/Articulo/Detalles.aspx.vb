Imports CapaDatos

Public Class Detalles
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()

    '------------------------------------------------------------------
    '------------------------METODOS AL CARGAR LA PAGINA---------------
    '------------------------------------------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)
            Dim IdArticulo = Util_Cifrar.descifrarCadena_Num(Request.QueryString("id"))
            CargarArticulo(IdArticulo)
        Else
            Response.Redirect(Val_Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para cargar los datos del articulo a consultar
    ''' </summary>
    Private Sub CargarArticulo(IdArticulo As Integer)
        Dim _Articulo As List(Of Articulo) = Mgr_Articulo.Get_Articulo_List(IdArticulo)

        For Each itemArticulos In _Articulo

            CargarArticulo(itemArticulos)
            CargarArticulosPicking(itemArticulos)
            CargarUbicacion(itemArticulos)
            CargarImagenes(itemArticulos)
        Next
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para cargar los datos del articulo a consultar
    ''' </summary>
    Private Sub CargarArticulo(itemArticulos As Articulo)

        Dim _miArticulo = Mgr_Articulo.Get_Struct(itemArticulos)

#Region "cargar valores"
        lbTipoArticulo.Text = _miArticulo.tipoArticulo
        lbAlmacen.Text = _miArticulo.id_almacen
        lbCodigo.Text = _miArticulo.codigo
        lbNombre.Text = _miArticulo.nombre
        lbRefPick.Text = _miArticulo.referencia_picking
        lbRef1.Text = _miArticulo.referencia1
        lbRef2.Text = _miArticulo.referencia2
        lbRef3.Text = _miArticulo.referencia3
        lbTipoUnidad.Text = _miArticulo.id_tipo_unidad
        lbPeso.Text = _miArticulo.peso
        lbAlto.Text = _miArticulo.alto
        lbLargo.Text = _miArticulo.largo
        lbAncho.Text = _miArticulo.ancho
        lbCoefVol.Text = _miArticulo.coeficiente_volumetrico
        lbCubicaje.Text = _miArticulo.cubicaje
        lbPesoVol.Text = _miArticulo.peso_volumen
        lbTipoFacturacion.Text = _miArticulo.id_tipo_facturacion
        lbIdentificacion.Text = _miArticulo.identificacion
        lbValArticulo.Text = _miArticulo.valor_articulo
        lbValAsegurado.Text = _miArticulo.valor_asegurado
        lbValStock.Text = _miArticulo.valoracion_stock
        lbValSeguro.Text = _miArticulo.valoracion_seguro
        lbObsGen.Text = _miArticulo.observaciones_generales
        lbObsArt.Text = _miArticulo.observaciones_articulo
        lbStockMinimo.Text = _miArticulo.stock_minimo
        lbStockFisico.Text = _miArticulo.stock_fisico
#End Region

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para cargar los datos del articulo que conforman el articulo picking a consultar
    ''' </summary>
    Private Sub CargarArticulosPicking(itemArticulos As Articulo)

        If itemArticulos.tipoArticulo = Val_Articulo.Tipo_Picking.ToString Then
            phListaArticulos.Visible = True

            Util_ControlesDinamicos.CrearLiteral("<ul class='list-group'>", pArticulos)
            For Each itemPickArticulos In itemArticulos.Picking_Articulo1

                Dim _ArticuloPick = contexto.Articulo.Where(Function(model) model.id_articulo = itemPickArticulos.id_articulo).SingleOrDefault()
                Util_ControlesDinamicos.CrearLiteral("<li class='list-group-item'><strong>Articulo:</strong> " & _ArticuloPick.nombre & " <strong>Unidades:</strong> " & itemPickArticulos.unidades & "</li>", pArticulos)
            Next
            Util_ControlesDinamicos.CrearLiteral("</ul>", pArticulos)

        End If
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para cargar los datos de las imagenes del articulo a consultar
    ''' </summary>
    Private Sub CargarImagenes(itemArticulos As Articulo)

        If itemArticulos.Imagen.Count > 0 Then
            Util_ControlesDinamicos.CrearLiteral("
                <div id='ImagenesArticulo' class='carousel slide' data-ride='carousel' style='width:50%;height:50%;'>
                    <div class='carousel-inner'>", pImagenes)
            Dim contadorImagenes As Integer = 0

            For Each itemImagen In itemArticulos.Imagen

                If contadorImagenes = 0 Then

                    Util_ControlesDinamicos.CrearLiteral("<div class='item active'>", pImagenes)
                Else

                    Util_ControlesDinamicos.CrearLiteral("<div class='item'>", pImagenes)
                End If


                Util_ControlesDinamicos.CrearLiteral("<img src='" & itemImagen.url_imagen & "' style='width:100%;'>", pImagenes)
                Util_ControlesDinamicos.CrearLiteral("</div>", pImagenes)

                contadorImagenes += 1
            Next

            Util_ControlesDinamicos.CrearLiteral("</div>
                <a class='left carousel-control' href='#ImagenesArticulo' data-slide='prev'>
                    <span class='glyphicon glyphicon-chevron-left'></span>
                    <span class='sr-only'>Previous</span>
                </a>
                <a class='right carousel-control' href='#ImagenesArticulo' data-slide='next'>
                    <span class='glyphicon glyphicon-chevron-right'>
                    </span><span class='sr-only'>Next</span>
                </a>
            </div>", pImagenes)
        Else
            Util_ControlesDinamicos.CrearLiteral("<h5>Sin imagenes registradas</h5>", pImagenes)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para cargar los datos de las imagenes del articulo a consultar
    ''' </summary>
    Private Sub CargarUbicacion(itemArticulos As Articulo)

        If itemArticulos.Ubicacion.Count > 0 Then

            Util_ControlesDinamicos.CrearLiteral("<table class='table table-bordered table-hover'>
                    <tbody>
                        <tr class='bg-aqua color-palette'>
                            <th class='col-md-1 text-center'>Zona</th>
                            <th Class='col-md-1 text-center'>Estante</th>
                            <th Class='col-md-1 text-center'>Fila</th>
                            <th Class='col-md-2 text-center'>Columna</th>
                            <th Class='col-md-1 text-center'>Panel</th>
                            <th Class='col-md-6 text-center'>Referencia Ubicación</th>
                        </tr>", pTabla)
            For Each itemUbicacion In itemArticulos.Ubicacion

                Util_ControlesDinamicos.CrearLiteral("<tr'>", pTabla)
                Util_ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.zona & "</td>", pTabla)
                Util_ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.estante & "</td>", pTabla)
                Util_ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.fila & "</td>", pTabla)
                Util_ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.columna & "</td>", pTabla)
                Util_ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.panel & "</td>", pTabla)
                Util_ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.referencia_ubicacion & "</td>", pTabla)
                Util_ControlesDinamicos.CrearLiteral("</tr>", pTabla)

            Next
            Util_ControlesDinamicos.CrearLiteral("</tbody></table>", pTabla)
        Else
            Util_ControlesDinamicos.CrearLiteral("<h5>Sin ubicaciones registradas</h5>", pTabla)
        End If
    End Sub

End Class