Imports System.Web.UI.WebControls
Imports CapaDatos

<TestClass()> Public Class Test_Imagen

    Dim _ArticuloTest As Articulo
    Dim _AlmacenTest As Almacen
    Dim _Tipo_FacturacionTest As Tipo_Facturacion
    Dim _Tipo_UnidadTest As Tipo_Unidad
    Dim _ClienteTest As Cliente
    Dim _ImagenTest As Imagen
    Dim _DropDownlistTest As DropDownList
    Dim _GridViewTest As GridView

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        _ClienteTest = Mgr_Cliente_Test.Get_Cliente1()
        _Tipo_FacturacionTest = Mgr_TipoFacturacion_Test.Get_TipoFacturacion1()
        _Tipo_UnidadTest = Mgr_TipoUnidad_Test.Get_Tipo_Unidad1()

        Mgr_Articulo_Test.Inicializar(_ArticuloTest, _AlmacenTest, _Tipo_FacturacionTest, _Tipo_UnidadTest, _ClienteTest)

        _ImagenTest = Mgr_Imagen_Test.Get_Imagen1(_ArticuloTest)
        Mgr_Imagen_Test.Inicializar(_ArticuloTest, _AlmacenTest, _Tipo_FacturacionTest, _Tipo_UnidadTest, _ClienteTest, _ImagenTest)

    End Sub

    ''' <summary>
    ''' Método que se invoca para finbalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()
        Mgr_Articulo_Test.Finalizar(_Tipo_FacturacionTest, _Tipo_UnidadTest, _ClienteTest)
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para registrar un Imagen
    ''' </summary>
    <TestMethod()> Public Sub Registrar_Imagen()

        Dim ImagenBD = Mgr_Imagen.Get_Imagen(_ImagenTest.id_imagen)

        Assert.AreEqual(ImagenBD.id_imagen, _ImagenTest.id_imagen)
        Assert.AreEqual(ImagenBD.nombre, _ImagenTest.nombre)
        Assert.AreEqual(ImagenBD.url_imagen, _ImagenTest.url_imagen)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para editar un Imagen
    ''' </summary>
    <TestMethod()> Public Sub Editar_Imagen()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim ImagenBD = Mgr_Imagen.Get_Imagen(_ImagenTest.id_imagen, contexto)

        ImagenBD.nombre = "nombre2"
        ImagenBD.url_imagen = "url_imagen2"

        Mgr_Imagen.Editar(ImagenBD, contexto)

        Assert.AreEqual(ImagenBD.id_imagen, _ImagenTest.id_imagen)
        Assert.AreNotEqual(ImagenBD.nombre, _ImagenTest.nombre)
        Assert.AreNotEqual(ImagenBD.url_imagen, _ImagenTest.url_imagen)


    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para eliminar un Imagen
    ''' </summary>
    <TestMethod()> Public Sub Eliminar_Imagen()

        Mgr_Imagen.Eliminar(_ImagenTest.id_imagen)
        Dim ImagenBD = Mgr_Ubicacion.Get_Ubicacion(_ImagenTest.id_imagen)
        Assert.AreEqual(ImagenBD, Nothing)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para consultar un Imagen
    ''' </summary>
    <TestMethod()> Public Sub Get_Imagen()

        Dim ImagenBD = Mgr_Imagen.Get_Imagen(_ImagenTest.id_imagen)

        Assert.AreEqual(ImagenBD.id_imagen, _ImagenTest.id_imagen)
        Assert.AreEqual(ImagenBD.nombre, _ImagenTest.nombre)
        Assert.AreEqual(ImagenBD.url_imagen, _ImagenTest.url_imagen)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para consultar una lista de Imagenes
    ''' </summary>
    <TestMethod()> Public Sub Get_Imagen_list()

        Dim ImagenBD = Mgr_Imagen.Get_Imagen_list(_ImagenTest.id_imagen)
        Assert.AreEqual(ImagenBD.Count(), 0)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para llenar el grid de imagenes de un articulo
    ''' </summary>
    <TestMethod()> Public Sub LlenarGrid()

        _GridViewTest = New GridView()
        Mgr_Imagen.LlenarGrid(_GridViewTest, _ArticuloTest.id_articulo)
        Assert.AreEqual(_GridViewTest.Rows.Count(), 0)

    End Sub



End Class