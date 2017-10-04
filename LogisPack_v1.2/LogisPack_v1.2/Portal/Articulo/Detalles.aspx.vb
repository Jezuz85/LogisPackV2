Imports CapaDatos

Public Class Detalles
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Manager_Usuario.ValidarMenu(Me, Master)

        If Manager_Usuario.ValidarAutenticado(User) Then
            Dim IdArticulo = Cifrar.descifrarCadena_Num(Request.QueryString("id"))
            CargarArticulo(IdArticulo)
        Else
            Response.Redirect(Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para cargar los datos del articulo a consultar
    ''' </summary>
    Private Sub CargarArticulo(IdArticulo As Integer)
        Dim _Articulo As List(Of Articulo) = Getter.Articulo_list(IdArticulo)

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

        Dim PesoVolumen As String = Convert.ToDouble(itemArticulos.peso_volumen).ToString("##,##0.00000")
        Dim CoefVolumetrico As String = Convert.ToDouble(itemArticulos.coeficiente_volumetrico).ToString("##,##0.00000")
        Dim M3 As String = Convert.ToDouble(itemArticulos.cubicaje).ToString("##,##0.00000")
        Dim ValorArticulo As String = Convert.ToDouble(itemArticulos.valor_articulo).ToString("##,##0.00")
        Dim ValorAsegurado As String = Convert.ToDouble(itemArticulos.valor_asegurado).ToString("##,##0.00")
        Dim ValoraciónStock As String = Convert.ToDouble(itemArticulos.valoracion_stock).ToString("##,##0.00")
        Dim ValoraciónSeguro As String = Convert.ToDouble(itemArticulos.valoracion_seguro).ToString("##,##0.00")
        Dim Peso As String = Convert.ToDouble(itemArticulos.peso).ToString("##,##0.00000")


        lbTipoArticulo.Text = itemArticulos.tipoArticulo
        lbAlmacen.Text = itemArticulos.Almacen.nombre
        lbCodigo.Text = itemArticulos.codigo
        lbNombre.Text = itemArticulos.nombre
        lbRefPick.Text = itemArticulos.referencia_picking
        lbRef1.Text = itemArticulos.referencia1
        lbRef2.Text = itemArticulos.referencia2
        lbRef3.Text = itemArticulos.referencia3
        lbTipoUnidad.Text = itemArticulos.Tipo_Unidad.nombre
        lbPeso.Text = Peso & " Kgs"
        lbAlto.Text = itemArticulos.alto
        lbLargo.Text = itemArticulos.largo
        lbAncho.Text = itemArticulos.ancho
        lbCoefVol.Text = CoefVolumetrico & " Kgs(m³)"
        lbCubicaje.Text = M3
        txtPesoVol.Text = PesoVolumen & " Kgs(m³)"
        lbTipoFacturacion.Text = itemArticulos.Tipo_Facturacion.nombre
        lbIdentificacion.Text = itemArticulos.identificacion
        lbValArticulo.Text = ValorArticulo
        txtValAsegurado.Text = ValorAsegurado
        lbValSotck.Text = ValoraciónStock
        txtValSeguro.Text = ValoraciónSeguro
        txtObsGen.Text = itemArticulos.observaciones_generales
        txtObsArt.Text = itemArticulos.observaciones_articulo
        lbStockMinimo.Text = itemArticulos.stock_minimo
        lbStockFisico.Text = itemArticulos.stock_fisico
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para cargar los datos del articulo que conforman el articulo picking a consultar
    ''' </summary>
    Private Sub CargarArticulosPicking(itemArticulos As Articulo)

        If itemArticulos.tipoArticulo = "Picking" Then
            phListaArticulos.Visible = True

            ControlesDinamicos.CrearLiteral("<ul class='list-group'>", pArticulos)
            For Each itemPickArticulos In itemArticulos.Picking_Articulo1

                Dim _ArticuloPick = contexto.Articulo.Where(Function(model) model.id_articulo = itemPickArticulos.id_articulo).SingleOrDefault()
                ControlesDinamicos.CrearLiteral("<li class='list-group-item'><strong>Articulo:</strong> " & _ArticuloPick.nombre & " <strong>Unidades:</strong> " & itemPickArticulos.unidades & "</li>", pArticulos)
            Next
            ControlesDinamicos.CrearLiteral("</ul>", pArticulos)

        End If
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para cargar los datos de las imagenes del articulo a consultar
    ''' </summary>
    Private Sub CargarImagenes(itemArticulos As Articulo)

        If itemArticulos.Imagen.Count > 0 Then
            ControlesDinamicos.CrearLiteral("
                <div id='ImagenesArticulo' class='carousel slide' data-ride='carousel' style='width:50%;height:50%;'>
                    <div class='carousel-inner'>", pImagenes)
            Dim contadorImagenes As Integer = 0

            For Each itemImagen In itemArticulos.Imagen

                If contadorImagenes = 0 Then

                    ControlesDinamicos.CrearLiteral("<div class='item active'>", pImagenes)
                Else

                    ControlesDinamicos.CrearLiteral("<div class='item'>", pImagenes)
                End If


                ControlesDinamicos.CrearLiteral("<img src='" & itemImagen.url_imagen & "' style='width:100%;'>", pImagenes)
                ControlesDinamicos.CrearLiteral("</div>", pImagenes)

                contadorImagenes += 1
            Next

            ControlesDinamicos.CrearLiteral("</div>
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
            ControlesDinamicos.CrearLiteral("<h5>Sin imagenes registradas</h5>", pImagenes)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para cargar los datos de las imagenes del articulo a consultar
    ''' </summary>
    Private Sub CargarUbicacion(itemArticulos As Articulo)

        If itemArticulos.Ubicacion.Count > 0 Then

            ControlesDinamicos.CrearLiteral("<table class='table table-bordered table-hover'>
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

                ControlesDinamicos.CrearLiteral("<tr'>", pTabla)
                ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.zona & "</td>", pTabla)
                ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.estante & "</td>", pTabla)
                ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.fila & "</td>", pTabla)
                ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.columna & "</td>", pTabla)
                ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.panel & "</td>", pTabla)
                ControlesDinamicos.CrearLiteral("<td>" & itemUbicacion.referencia_ubicacion & "</td>", pTabla)
                ControlesDinamicos.CrearLiteral("</tr>", pTabla)

            Next
            ControlesDinamicos.CrearLiteral("</tbody></table>", pTabla)
        Else
            ControlesDinamicos.CrearLiteral("<h5>Sin ubicaciones registradas</h5>", pTabla)
        End If
    End Sub

End Class