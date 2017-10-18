Imports CapaDatos

Public Class DataAccess

    Public Shared Sub Inicializar_Cliente(ByRef _Nuevo As Cliente)

        _Nuevo = New Cliente With {
            .codigo = "Codv1",
            .nombre = "Nombrev1"
        }
        Create.Cliente(_Nuevo)
    End Sub

    Public Shared Sub Finalizar_Cliente(ByRef _Nuevo As Cliente)
        Delete.Cliente(_Nuevo.id_cliente)
    End Sub

    Public Shared Sub Inicializar_Almacen(ByRef _Nuevo As Almacen, ByRef _Cliente As Cliente)

        Inicializar_Cliente(_Cliente)
        _Nuevo = New Almacen With {
        .nombre = "Nombrev1",
        .codigo = "Codv1",
        .coeficiente_volumetrico = "10",
        .id_cliente = _Cliente.id_cliente
        }
        Mgr_Almacen.Guardar(_Nuevo)

    End Sub

    Public Shared Sub Inicializar_TipoFacturacion(ByRef _Nuevo As Tipo_Facturacion)

        _Nuevo = New Tipo_Facturacion With {
            .nombre = "Nombrev1"
        }
        Create.TipoFacturacion(_Nuevo)
    End Sub

    Public Shared Sub Finalizar_TipoFacturacion(ByRef _Nuevo As Tipo_Facturacion)
        Delete.TipoFacturacion(_Nuevo.id_tipo_facturacion)
    End Sub

    Public Shared Sub Inicializar_TipoUnidad(ByRef _Nuevo As Tipo_Unidad)

        _Nuevo = New Tipo_Unidad With {
            .nombre = "Nombrev1"
        }
        Create.TipoUnidad(_Nuevo)
    End Sub

    Public Shared Sub Finalizar_TipoUnidad(ByRef _Nuevo As Tipo_Unidad)
        Delete.TipoUnidad(_Nuevo.id_tipo_unidad)
    End Sub

    Public Shared Sub Inicializar_Articulo(ByRef _Articulo As Articulo, ByRef _Almacen As Almacen,
        ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad, ByRef _Cliente As Cliente)

        Inicializar_Almacen(_Almacen, _Cliente)
        Inicializar_TipoFacturacion(_Tipo_Facturacion)
        Inicializar_TipoUnidad(_Tipo_Unidad)

        _Articulo = New Articulo With
            {
            .codigo = "Cod1",
            .nombre = "ArtPrueba",
            .referencia_picking = "RefPick",
            .referencia1 = "ref1",
            .referencia2 = "ref2",
            .referencia3 = "ref3",
            .identificacion = "CB",
            .valor_articulo = 100.1,
            .valor_asegurado = 200.2,
            .valoracion_stock = 300.3,
            .valoracion_seguro = 400.4,
            .peso = 500.5,
            .alto = 600.6,
            .largo = 700.7,
            .ancho = 800.8,
            .coeficiente_volumetrico = 900.9,
            .cubicaje = 10000.1,
            .peso_volumen = 2000.2,
            .observaciones_articulo = "Observaciones Articulo Prueba",
            .observaciones_generales = "Observaciones Generales Prueba",
            .stock_fisico = 3000.3,
            .stock_minimo = 4000.4,
            .id_almacen = _Almacen.id_almacen,
            .id_tipo_facturacion = _Tipo_Facturacion.id_tipo_facturacion,
            .id_tipo_unidad = _Tipo_Unidad.id_tipo_unidad,
            .tipoArticulo = "Normal"
        }
        Mgr_Articulo.Guardar(_Articulo)

    End Sub

    Public Shared Sub Finalizar_Articulo(ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad,
            ByRef _Cliente As Cliente)

        Delete.Cliente(_Cliente.id_cliente)
        Delete.TipoFacturacion(_Tipo_Facturacion.id_tipo_facturacion)
        Delete.TipoUnidad(_Tipo_Unidad.id_tipo_unidad)
    End Sub

    Public Shared Sub Inicializar_Ubicacion(ByRef _Articulo As Articulo, ByRef _Almacen As Almacen,
        ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad, ByRef _Cliente As Cliente,
        ByRef _Ubicacion As Ubicacion)

        Inicializar_Articulo(_Articulo, _Almacen, _Tipo_Facturacion, _Tipo_Unidad, _Cliente)

        _Ubicacion = New Ubicacion With {
            .zona = "zo1",
            .estante = "es1",
            .fila = "fi1",
            .columna = "co1",
            .panel = "pa1",
            .referencia_ubicacion = "referencia_ubicacion1",
            .id_articulo = _Articulo.id_articulo
        }

        Create.Ubicacion(_Ubicacion)
    End Sub

    Public Shared Sub Inicializar_Imagen(ByRef _Articulo As Articulo, ByRef _Almacen As Almacen,
        ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad, ByRef _Cliente As Cliente,
        ByRef _Imagen As Imagen)

        Inicializar_Articulo(_Articulo, _Almacen, _Tipo_Facturacion, _Tipo_Unidad, _Cliente)

        _Imagen = New Imagen With {
            .nombre = "nombre1",
            .url_imagen = "url_imagen1",
            .id_articulo = _Articulo.id_articulo
        }

        Create.Imagen(_Imagen)
    End Sub

    Public Shared Sub Inicializar_ArticuloPicking(ByRef _Articulo As Articulo, ByRef _Almacen As Almacen,
        ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad, ByRef _Cliente As Cliente,
        ByRef _Picking_Articulo As Picking_Articulo, ByRef _ArticuloP As Articulo)

        Inicializar_Almacen(_Almacen, _Cliente)
        Inicializar_TipoFacturacion(_Tipo_Facturacion)
        Inicializar_TipoUnidad(_Tipo_Unidad)

        _Articulo = New Articulo With
            {
            .codigo = "Cod1",
            .nombre = "Art_Pick1",
            .referencia_picking = "RefPick",
            .referencia1 = "ref1",
            .referencia2 = "ref2",
            .referencia3 = "ref3",
            .identificacion = "CB",
            .valor_articulo = 100.1,
            .valor_asegurado = 200.2,
            .valoracion_stock = 300.3,
            .valoracion_seguro = 400.4,
            .peso = 500.5,
            .alto = 600.6,
            .largo = 700.7,
            .ancho = 800.8,
            .coeficiente_volumetrico = 900.9,
            .cubicaje = 10000.1,
            .peso_volumen = 2000.2,
            .observaciones_articulo = "Observaciones Articulo Prueba",
            .observaciones_generales = "Observaciones Generales Prueba",
            .stock_fisico = 3000.3,
            .stock_minimo = 4000.4,
            .id_almacen = _Almacen.id_almacen,
            .id_tipo_facturacion = _Tipo_Facturacion.id_tipo_facturacion,
            .id_tipo_unidad = _Tipo_Unidad.id_tipo_unidad,
            .tipoArticulo = "Picking"
        }
        Mgr_Articulo.Guardar(_Articulo)

        _ArticuloP = New Articulo With
            {
            .codigo = "Cod1",
            .nombre = "ArtPick_1",
            .referencia_picking = "RefPick",
            .referencia1 = "ref1",
            .referencia2 = "ref2",
            .referencia3 = "ref3",
            .identificacion = "CB",
            .valor_articulo = 100.1,
            .valor_asegurado = 200.2,
            .valoracion_stock = 300.3,
            .valoracion_seguro = 400.4,
            .peso = 500.5,
            .alto = 600.6,
            .largo = 700.7,
            .ancho = 800.8,
            .coeficiente_volumetrico = 900.9,
            .cubicaje = 10000.1,
            .peso_volumen = 2000.2,
            .observaciones_articulo = "Observaciones Articulo Prueba",
            .observaciones_generales = "Observaciones Generales Prueba",
            .stock_fisico = 3000.3,
            .stock_minimo = 4000.4,
            .id_almacen = _Almacen.id_almacen,
            .id_tipo_facturacion = _Tipo_Facturacion.id_tipo_facturacion,
            .id_tipo_unidad = _Tipo_Unidad.id_tipo_unidad,
            .tipoArticulo = "Normal"
        }
        Mgr_Articulo.Guardar(_ArticuloP)

        Inicializar_Picking_Articulo(_Picking_Articulo, _Articulo, _ArticuloP)

    End Sub

    Public Shared Sub Inicializar_Picking_Articulo(ByRef _Picking_Articulo As Picking_Articulo, ByRef _Articulo As Articulo, ByRef _ArticuloP As Articulo)

        _Picking_Articulo = New Picking_Articulo With
            {
            .unidades = 2,
            .id_articulo = _ArticuloP.id_articulo,
            .id_picking = _Articulo.id_articulo
        }
        Create.Picking_Articulo(_Picking_Articulo)

    End Sub

End Class
