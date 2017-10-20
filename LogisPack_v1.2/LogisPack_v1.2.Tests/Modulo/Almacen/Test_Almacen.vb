Imports CapaDatos

<TestClass()> Public Class Test_Almacen

    Dim _Cliente1
    Dim AlmacenTest

    <TestInitialize>
    Public Sub inicializar()

        _Cliente1 = Mgr_Cliente_Test.Get_Cliente1()
        AlmacenTest = Mgr_Almacen_Test.Get_Almacen1(_Cliente1)

        Mgr_Almacen_Test.Inicializar(_Cliente1, AlmacenTest)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        Mgr_Cliente_Test.Finalizar(_Cliente1)
    End Sub

    <TestMethod()> Public Sub Registrar_Almacen()

        Dim AlmacenBd = Mgr_Almacen.Consultar(AlmacenTest.id_almacen)

        Assert.AreEqual(AlmacenBd.id_almacen, AlmacenTest.id_almacen)
        Assert.AreEqual(AlmacenBd.id_cliente, AlmacenTest.id_cliente)
        Assert.AreEqual(AlmacenBd.nombre, AlmacenTest.nombre)
        Assert.AreEqual(AlmacenBd.codigo, AlmacenTest.codigo)
        Assert.AreEqual(AlmacenBd.coeficiente_volumetrico, AlmacenTest.coeficiente_volumetrico)

    End Sub

    <TestMethod()> Public Sub Editar_Almacen()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim AlmacenBD = Mgr_Almacen.Consultar(AlmacenTest.id_almacen, contexto)

        AlmacenBD.codigo = "Codv2"
        AlmacenBD.nombre = "Nombrev2"
        AlmacenBD.coeficiente_volumetrico = "20"

        Mgr_Almacen.Editar(AlmacenTest, contexto)

        Assert.AreEqual(AlmacenBD.id_almacen, AlmacenTest.id_almacen)
        Assert.AreNotEqual(AlmacenBD.nombre, AlmacenTest.nombre)
        Assert.AreNotEqual(AlmacenBD.codigo, AlmacenTest.codigo)
        Assert.AreNotEqual(AlmacenBD.coeficiente_volumetrico, AlmacenTest.coeficiente_volumetrico)


    End Sub

    <TestMethod()> Public Sub Eliminar_Almacen()

        Mgr_Almacen.Eliminar(AlmacenTest.id_almacen)
        Dim AlmacenBD = Mgr_Almacen.Consultar(AlmacenTest.id_almacen)

        Assert.AreEqual(AlmacenBD, Nothing)

    End Sub

End Class