
Imports CapaDatos

Public Class Mgr_Articulo_Test

    ''' <summary>
    ''' Metodo que retorna un objeto de tipo articulo
    ''' </summary>
    Public Shared Function Get_Articulo1(ByRef _Articulo As Articulo, ByRef _Almacen As Almacen,
            ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad) As Articulo

        Dim Articulo1 = New Articulo With
            {
            .codigo = "CodArt1",
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

        Return Articulo1

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto de tipo Articulo,cliente ,Almacen, tipo de unidad y tipo de facturacion y los guarda en la base de datos
    ''' </summary>
    Public Shared Sub Inicializar(ByRef _Articulo As Articulo,
                                  ByRef _Almacen As Almacen,
                                  ByRef _Tipo_Facturacion As Tipo_Facturacion,
                                  ByRef _Tipo_Unidad As Tipo_Unidad,
                                  ByRef _Cliente As Cliente)


        Mgr_Almacen_Test.Inicializar(_Cliente, _Almacen)
        Mgr_TipoFacturacion_Test.Inicializar(_Tipo_Facturacion)
        Mgr_TipoUnidad_Test.Inicializar(_Tipo_Unidad)

        _Articulo = Get_Articulo1(_Articulo, _Almacen, _Tipo_Facturacion, _Tipo_Unidad)
        Mgr_Articulo.Guardar(_Articulo)

    End Sub

    ''' <summary>
    ''' Metodo que recibe un objeto de tipo cliente, tipo de unidad y tipo de facturacion y los elimina en la base de datos
    ''' </summary>
    Public Shared Sub Finalizar(ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad,
            ByRef _Cliente As Cliente)

        Mgr_Cliente.Eliminar(_Cliente.id_cliente)
        Mgr_TipoFacturacion.Eliminar(_Tipo_Facturacion.id_tipo_facturacion)
        Mgr_TipoUnidad.Eliminar(_Tipo_Unidad.id_tipo_unidad)

    End Sub


    ''' <summary>
    ''' Metodo que retorna un objeto de tipo articulo picking
    ''' </summary>
    Public Shared Function Get_ArticuloPicking1(ByRef _Almacen As Almacen, ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad) As Articulo

        Dim ArticuloPicking1 = New Articulo With
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

        Return ArticuloPicking1

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto de tipo Articulo,cliente ,Almacen, tipo de unidad y tipo de facturacion y los guarda en la base de datos
    ''' </summary>
    Public Shared Sub Inicializar_ArticuloPicking(ByRef _Articulo As Articulo,
                                                  ByRef _Picking_Articulo As Picking_Articulo,
                                                  ByRef _ArticuloP As Articulo)

        Mgr_Articulo.Guardar(_Articulo)
        Mgr_Articulo.Guardar(_ArticuloP)

        Inicializar_Picking_Articulo(_Picking_Articulo, _Articulo, _ArticuloP)

    End Sub

    ''' <summary>
    ''' Metodo que recibe un objeto de tipo Picking_Articulo,cliente ,Almacen, tipo de unidad y tipo de facturacion y los guarda en la base de datos
    ''' </summary>
    Public Shared Sub Inicializar_Picking_Articulo(ByRef _Picking_Articulo As Picking_Articulo,
                                                   ByRef _Articulo As Articulo,
                                                   ByRef _ArticuloP As Articulo)

        _Picking_Articulo = New Picking_Articulo With
            {
            .unidades = 2,
            .id_articulo = _ArticuloP.id_articulo,
            .id_picking = _Articulo.id_articulo
        }
        Mgr_Articulo.Guardar_Picking_Articulo(_Picking_Articulo)

    End Sub

End Class
