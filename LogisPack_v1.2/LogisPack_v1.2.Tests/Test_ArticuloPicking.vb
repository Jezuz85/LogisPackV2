Imports CapaDatos


<TestClass()> Public Class Test_ArticuloPicking
    Dim _Articulo As Articulo
    Dim _ArticuloP As Articulo
    Dim _Picking_Articulo As Picking_Articulo
    Dim _Almacen As Almacen
    Dim _Tipo_Facturacion As Tipo_Facturacion
    Dim _Tipo_Unidad As Tipo_Unidad
    Dim _Cliente As Cliente

    <TestInitialize>
    Public Sub inicializar()
        DataAccess.Inicializar_ArticuloPicking(_Articulo, _Almacen, _Tipo_Facturacion, _Tipo_Unidad, _Cliente,
                                               _Picking_Articulo, _ArticuloP)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        DataAccess.Finalizar_Articulo(_Tipo_Facturacion, _Tipo_Unidad, _Cliente)
    End Sub

    <TestMethod()> Public Sub Registrar_ArticuloPicking()

        Dim miPicking_Articulo = Mgr_Articulo.Get_Picking_Articulo(_Picking_Articulo.id_picking_articulo)

        Assert.AreEqual(miPicking_Articulo.id_picking, _Articulo.id_articulo)
        Assert.AreEqual(miPicking_Articulo.id_articulo, _ArticuloP.id_articulo)
        Assert.AreEqual(miPicking_Articulo.unidades, _Picking_Articulo.unidades)

    End Sub

    <TestMethod()> Public Sub Editar_ArticuloPicking()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _Edit = Mgr_Articulo.Get_Picking_Articulo(_Picking_Articulo.id_picking_articulo, contexto)

        _Edit.unidades = 30

        Mgr_Articulo.Editar(_Articulo, contexto)

        Assert.AreEqual(_Edit.id_picking_articulo, _Picking_Articulo.id_picking_articulo)
        Assert.AreNotEqual(_Edit.unidades, _Picking_Articulo.unidades)


    End Sub

    <TestMethod()> Public Sub Eliminar_ArticuloPicking()

        Mgr_Articulo.Eliminar_Picking_Articulo(_Picking_Articulo.id_picking_articulo)

        Dim miPicking_Articulo = Mgr_Articulo.Get_Picking_Articulo(_Picking_Articulo.id_picking_articulo)

        Assert.AreEqual(miPicking_Articulo, Nothing)

    End Sub

End Class