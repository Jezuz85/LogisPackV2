Imports CapaDatos

<TestClass()> Public Class Test_Imagen
    Dim ArticuloTest As Articulo
    Dim AlmacenTest As Almacen
    Dim Tipo_FacturacionTest As Tipo_Facturacion
    Dim Tipo_UnidadTest As Tipo_Unidad
    Dim ClienteTest As Cliente
    Dim ImagenTest As Imagen

    <TestInitialize>
    Public Sub inicializar()
        Mgr_Imagen_Test.Inicializar(ArticuloTest, AlmacenTest, Tipo_FacturacionTest, Tipo_UnidadTest, ClienteTest, ImagenTest)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        Mgr_Articulo_Test.Finalizar(Tipo_FacturacionTest, Tipo_UnidadTest, ClienteTest)
    End Sub

    <TestMethod()> Public Sub Registrar_Imagen()

        Dim ImagenBD = Mgr_Imagen.Get_Imagen(ImagenTest.id_imagen)

        Assert.AreEqual(ImagenBD.id_imagen, ImagenTest.id_imagen)
        Assert.AreEqual(ImagenBD.nombre, ImagenTest.nombre)
        Assert.AreEqual(ImagenBD.url_imagen, ImagenTest.url_imagen)

    End Sub

    <TestMethod()> Public Sub Editar_Imagen()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim ImagenBD = Mgr_Imagen.Get_Imagen(ImagenTest.id_imagen, contexto)

        ImagenBD.nombre = "nombre2"
        ImagenBD.url_imagen = "url_imagen2"

        Mgr_Imagen.Editar(ImagenBD, contexto)

        Assert.AreEqual(ImagenBD.id_imagen, ImagenTest.id_imagen)
        Assert.AreNotEqual(ImagenBD.nombre, ImagenTest.nombre)
        Assert.AreNotEqual(ImagenBD.url_imagen, ImagenTest.url_imagen)


    End Sub

    <TestMethod()> Public Sub Eliminar_Imagen()

        Mgr_Imagen.Eliminar(ImagenTest.id_imagen)
        Dim ImagenBD = Mgr_Ubicacion.Get_Ubicacion(ImagenTest.id_imagen)
        Assert.AreEqual(ImagenBD, Nothing)

    End Sub
End Class