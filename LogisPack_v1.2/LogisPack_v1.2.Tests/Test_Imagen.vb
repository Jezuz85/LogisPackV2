Imports CapaDatos

<TestClass()> Public Class Test_Imagen
    Dim _Articulo As Articulo
    Dim _Almacen As Almacen
    Dim _Tipo_Facturacion As Tipo_Facturacion
    Dim _Tipo_Unidad As Tipo_Unidad
    Dim _Cliente As Cliente
    Dim _Imagen As Imagen

    <TestInitialize>
    Public Sub inicializar()
        DataAccess.Inicializar_Imagen(_Articulo, _Almacen, _Tipo_Facturacion, _Tipo_Unidad, _Cliente, _Imagen)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        DataAccess.Finalizar_Articulo(_Tipo_Facturacion, _Tipo_Unidad, _Cliente)
    End Sub

    <TestMethod()> Public Sub Registrar_Imagen()

        Dim miImagen = Getter.Imagen(_Imagen.id_imagen)

        Assert.AreEqual(miImagen.id_imagen, _Imagen.id_imagen)
        Assert.AreEqual(miImagen.nombre, _Imagen.nombre)
        Assert.AreEqual(miImagen.url_imagen, _Imagen.url_imagen)

    End Sub

    <TestMethod()> Public Sub Editar_Imagen()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _Edit = Getter.Imagen(_Imagen.id_imagen, contexto)

        _Edit.nombre = "nombre2"
        _Edit.url_imagen = "url_imagen2"

        Update.Imagen(_Edit, contexto)

        Assert.AreEqual(_Edit.id_imagen, _Imagen.id_imagen)
        Assert.AreNotEqual(_Edit.nombre, _Imagen.nombre)
        Assert.AreNotEqual(_Edit.url_imagen, _Imagen.url_imagen)


    End Sub

    <TestMethod()> Public Sub Eliminar_Imagen()

        Delete.Imagen(_Imagen.id_imagen)

        Dim miImagen = Getter.Ubicacion(_Imagen.id_imagen)

        Assert.AreEqual(miImagen, Nothing)

    End Sub
End Class