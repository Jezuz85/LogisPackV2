Imports CapaDatos

<TestClass()> Public Class Test_ArticuloPicking
    Dim _Articulo As Articulo
    Dim _ArticuloP As Articulo
    Dim _Picking_Articulo As Picking_Articulo
    Dim _Almacen As Almacen
    Dim _Tipo_Facturacion As Tipo_Facturacion
    Dim _Tipo_Unidad As Tipo_Unidad
    Dim _Cliente As Cliente

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        Mgr_Almacen_Test.Inicializar(_Cliente, _Almacen)
        Mgr_TipoFacturacion_Test.Inicializar(_Tipo_Facturacion)
        Mgr_TipoUnidad_Test.Inicializar(_Tipo_Unidad)
        _ArticuloP = Mgr_Articulo_Test.Get_ArticuloPicking1(_Almacen, _Tipo_Facturacion, _Tipo_Unidad)

        Mgr_Articulo_Test.Inicializar_ArticuloPicking(_Articulo, _Picking_Articulo, _ArticuloP)
    End Sub

    ''' <summary>
    ''' Método que se invoca para finalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()
        Mgr_Articulo_Test.Finalizar(_Tipo_Facturacion, _Tipo_Unidad, _Cliente)
    End Sub

    ''' <summary>
    ''' Método que se ejecuta para registrar un articulo de tipo picking
    ''' </summary>
    <TestMethod()> Public Sub Registrar_ArticuloPicking()

        Dim miPicking_Articulo = Mgr_Articulo.Get_Picking_Articulo(_Picking_Articulo.id_picking_articulo)

        Assert.AreEqual(miPicking_Articulo.id_picking, _Articulo.id_articulo)
        Assert.AreEqual(miPicking_Articulo.id_articulo, _ArticuloP.id_articulo)
        Assert.AreEqual(miPicking_Articulo.unidades, _Picking_Articulo.unidades)

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para editar un articulo de tipo picking
    ''' </summary>
    <TestMethod()> Public Sub Editar_ArticuloPicking()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _Edit = Mgr_Articulo.Get_Picking_Articulo(_Picking_Articulo.id_picking_articulo, contexto)

        _Edit.unidades = 30

        Mgr_Articulo.Editar(_Articulo, contexto)

        Assert.AreEqual(_Edit.id_picking_articulo, _Picking_Articulo.id_picking_articulo)
        Assert.AreNotEqual(_Edit.unidades, _Picking_Articulo.unidades)


    End Sub

    ''' <summary>
    ''' Método que se ejecuta para eliminar un articulo de tipo picking
    ''' </summary>
    <TestMethod()> Public Sub Eliminar_ArticuloPicking()

        Mgr_Articulo.Eliminar_Picking_Articulo(_Picking_Articulo.id_picking_articulo)

        Dim miPicking_Articulo = Mgr_Articulo.Get_Picking_Articulo(_Picking_Articulo.id_picking_articulo)

        Assert.AreEqual(miPicking_Articulo, Nothing)

    End Sub

End Class