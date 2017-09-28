Imports CapaDatos

<TestClass()> Public Class Test_Articulo
    Dim _Articulo As Articulo
    Dim _Almacen As Almacen
    Dim _Tipo_Facturacion As Tipo_Facturacion
    Dim _Tipo_Unidad As Tipo_Unidad
    Dim _Cliente As Cliente

    <TestInitialize>
    Public Sub inicializar()
        DataAccess.Inicializar_Articulo(_Articulo, _Almacen, _Tipo_Facturacion, _Tipo_Unidad, _Cliente)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        DataAccess.Finalizar_Articulo(_Tipo_Facturacion, _Tipo_Unidad, _Cliente)
    End Sub

    <TestMethod()> Public Sub Registrar_Articulo()

        Dim miArticulo = Getter.Articulo(_Articulo.id_articulo)

        Assert.AreEqual(miArticulo.id_articulo, _Articulo.id_articulo)
        Assert.AreEqual(miArticulo.nombre, _Articulo.nombre)
        Assert.AreEqual(miArticulo.codigo, _Articulo.codigo)

    End Sub

    <TestMethod()> Public Sub Editar_Articulo()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _Edit = Getter.Articulo(_Articulo.id_articulo, contexto)

        _Edit.codigo = "_Cod1"
        _Edit.nombre = "_ArtPrueba"

        Update.Articulo(_Articulo, contexto)

        Assert.AreEqual(_Edit.id_articulo, _Articulo.id_articulo)
        Assert.AreNotEqual(_Edit.nombre, _Articulo.nombre)
        Assert.AreNotEqual(_Edit.codigo, _Articulo.codigo)


    End Sub

    <TestMethod()> Public Sub Eliminar_Articulo()

        Delete.Articulo(_Articulo.id_articulo)

        Dim miArticulo = Getter.Articulo(_Articulo.id_articulo)

        Assert.AreEqual(miArticulo, Nothing)

    End Sub

End Class