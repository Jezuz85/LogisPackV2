Imports CapaDatos

<TestClass()> Public Class Test_Almacen
    Dim _Almacen As Almacen
    Dim _Cliente As Cliente

    <TestInitialize>
    Public Sub inicializar()
        DataAccess.Inicializar_Almacen(_Almacen, _Cliente)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        DataAccess.Finalizar_Cliente(_Cliente)
    End Sub

    <TestMethod()> Public Sub Registrar_Almacen()
        Dim miAlmacen = Mgr_Almacen.Consultar(_Almacen.id_almacen)

        Assert.AreEqual(miAlmacen.id_almacen, _Almacen.id_almacen)
        Assert.AreEqual(miAlmacen.id_cliente, _Almacen.id_cliente)
        Assert.AreEqual(miAlmacen.nombre, _Almacen.nombre)
        Assert.AreEqual(miAlmacen.codigo, _Almacen.codigo)
        Assert.AreEqual(miAlmacen.coeficiente_volumetrico, _Almacen.coeficiente_volumetrico)
    End Sub

    <TestMethod()> Public Sub Editar_Almacen()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _Edit = Mgr_Almacen.Consultar(_Almacen.id_almacen, contexto)

        _Edit.codigo = "Codv2"
        _Edit.nombre = "Nombrev2"
        _Edit.coeficiente_volumetrico = "20"

        Mgr_Almacen.Editar(_Almacen, contexto)

        Assert.AreEqual(_Edit.id_almacen, _Almacen.id_almacen)
        Assert.AreNotEqual(_Edit.nombre, _Almacen.nombre)
        Assert.AreNotEqual(_Edit.codigo, _Almacen.codigo)
        Assert.AreNotEqual(_Edit.coeficiente_volumetrico, _Almacen.coeficiente_volumetrico)


    End Sub

    <TestMethod()> Public Sub Eliminar_Almacen()

        Mgr_Almacen.Eliminar(_Almacen.id_almacen)

        Dim miAlmacen = Mgr_Almacen.Consultar(_Almacen.id_almacen)

        Assert.AreEqual(miAlmacen, Nothing)

    End Sub

End Class