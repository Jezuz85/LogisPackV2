Imports CapaDatos

<TestClass()> Public Class Test_Articulo

    Dim _ArticuloTest As Articulo
    Dim _AlmacenTest As Almacen
    Dim _Tipo_FacturacionTest As Tipo_Facturacion
    Dim _Tipo_UnidadTest As Tipo_Unidad
    Dim _ClienteTest As Cliente

    <TestInitialize>
    Public Sub inicializar()
        Mgr_Articulo_Test.Inicializar(_ArticuloTest, _AlmacenTest, _Tipo_FacturacionTest, _Tipo_UnidadTest, _ClienteTest)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        Mgr_Articulo_Test.Finalizar(_Tipo_FacturacionTest, _Tipo_UnidadTest, _ClienteTest)
    End Sub

    <TestMethod()> Public Sub Registrar_Articulo()

        Dim _ArticuloBD = Mgr_Articulo.Get_Articulo(_ArticuloTest.id_articulo)

        Assert.AreEqual(_ArticuloBD.id_articulo, _ArticuloTest.id_articulo)
        Assert.AreEqual(_ArticuloBD.nombre, _ArticuloTest.nombre)
        Assert.AreEqual(_ArticuloBD.codigo, _ArticuloTest.codigo)

    End Sub

    <TestMethod()> Public Sub Editar_Articulo()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _ArticuloBD = Mgr_Articulo.Get_Articulo(_ArticuloTest.id_articulo, contexto)

        _ArticuloBD.codigo = "_Cod1"
        _ArticuloBD.nombre = "_ArtPrueba"

        Mgr_Articulo.Editar(_ArticuloTest, contexto)

        Assert.AreEqual(_ArticuloBD.id_articulo, _ArticuloTest.id_articulo)
        Assert.AreNotEqual(_ArticuloBD.nombre, _ArticuloTest.nombre)
        Assert.AreNotEqual(_ArticuloBD.codigo, _ArticuloTest.codigo)


    End Sub

    <TestMethod()> Public Sub Eliminar_Articulo()

        Mgr_Articulo.Eliminar(_ArticuloTest.id_articulo)
        Dim _ArticuloBD = Mgr_Articulo.Get_Articulo(_ArticuloTest.id_articulo)

        Assert.AreEqual(_ArticuloBD, Nothing)

    End Sub

End Class