Imports System.Web.UI.WebControls
Imports CapaDatos

<TestClass()> Public Class Test_ArticuloPicking

    Dim _Articulo_TipoNormalTest As Articulo
    Dim _Articulo_TipoPickingTest As Articulo
    Dim _Picking_Articulo As Picking_Articulo

    Dim _AlmacenTest As Almacen
    Dim _Tipo_FacturacionTest As Tipo_Facturacion
    Dim _Tipo_UnidadTest As Tipo_Unidad
    Dim _ClienteTest As Cliente

    Dim _GridTest As GridView

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        _ClienteTest = Mgr_Cliente_Test.Get_Cliente1()
        _AlmacenTest = Mgr_Almacen_Test.Get_Almacen1(_ClienteTest)
        Mgr_Almacen_Test.Inicializar(_ClienteTest, _AlmacenTest)
        _Tipo_FacturacionTest = Mgr_TipoFacturacion_Test.Get_TipoFacturacion1()
        _Tipo_UnidadTest = Mgr_TipoUnidad_Test.Get_Tipo_Unidad1()
        _Articulo_TipoNormalTest = Mgr_Articulo_Test.Get_Articulo1(_Articulo_TipoNormalTest, _AlmacenTest, _Tipo_FacturacionTest, _Tipo_UnidadTest)
        _Articulo_TipoPickingTest = Mgr_Articulo_Test.Get_ArticuloPicking1(_AlmacenTest, _Tipo_FacturacionTest, _Tipo_UnidadTest)

        Mgr_TipoFacturacion_Test.Inicializar(_Tipo_FacturacionTest)
        Mgr_TipoUnidad_Test.Inicializar(_Tipo_UnidadTest)
        Mgr_Articulo_Test.Inicializar_ArticuloPicking(_Articulo_TipoNormalTest, _Picking_Articulo, _Articulo_TipoPickingTest)

    End Sub

    ''' <summary>
    ''' Método que se invoca para finalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()
        Mgr_Articulo_Test.Finalizar(_Tipo_FacturacionTest, _Tipo_UnidadTest, _ClienteTest)
    End Sub

    ''' <summary>
    ''' Método que se ejecuta para registrar un articulo de tipo picking
    ''' </summary>
    <TestMethod()> Public Sub Registrar_ArticuloPicking()

        Dim miPicking_Articulo = Mgr_Articulo.Get_Picking_Articulo(_Picking_Articulo.id_picking_articulo)

        Assert.AreEqual(miPicking_Articulo.id_articulo, _Articulo_TipoNormalTest.id_articulo)
        Assert.AreEqual(miPicking_Articulo.id_picking, _Articulo_TipoPickingTest.id_articulo)
        Assert.AreEqual(miPicking_Articulo.unidades, _Picking_Articulo.unidades)

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para editar un articulo de tipo picking
    ''' </summary>
    <TestMethod()> Public Sub Editar_ArticuloPicking()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _Edit = Mgr_Articulo.Get_Picking_Articulo(_Picking_Articulo.id_picking_articulo, contexto)

        _Edit.unidades = 30

        Mgr_Articulo.Editar(_Articulo_TipoNormalTest, contexto)

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

    ''' <summary>
    ''' Método que se ejecuta para consultar un articulo de tipo picking y devolver una lista
    ''' </summary>
    <TestMethod()> Public Sub Get_Picking_Articulo_List()

        Dim miPicking_Articulo = Mgr_Articulo.Get_Picking_Articulo_List(_Picking_Articulo.id_picking)
        Assert.AreNotEqual(0, miPicking_Articulo.Count())

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para consultar un articulo de tipo picking
    ''' </summary>
    <TestMethod()> Public Sub Get_Picking_Articulo()

        Dim miPicking_Articulo = Mgr_Articulo.Get_Picking_Articulo(_Picking_Articulo.id_picking_articulo)

        Assert.AreEqual(miPicking_Articulo.id_articulo, _Articulo_TipoNormalTest.id_articulo)
        Assert.AreEqual(miPicking_Articulo.id_picking, _Articulo_TipoPickingTest.id_articulo)
        Assert.AreEqual(miPicking_Articulo.unidades, _Picking_Articulo.unidades)

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para consultar la tabla con los articulos picking en la bd
    ''' </summary>
    <TestMethod()> Public Sub Llenar_Grid()

        _GridTest = New GridView()
        Mgr_Articulo.Llenar_Grid(_GridTest, 1, String.Empty, String.Empty, String.Empty, String.Empty)

        Assert.AreNotEqual(_GridTest.Rows.Count(), 0)

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para consultar la tabla con los articulos de tipo normal de un articulo picking
    ''' </summary>
    <TestMethod()> Public Sub Llenar_Grid_ArtPicking()

        Dim miPicking_Articulo = Mgr_Articulo.Get_Picking_Articulo(_Picking_Articulo.id_picking_articulo)
        _GridTest = New GridView()

        Mgr_Articulo.Llenar_Grid_ArticuloPicking(_GridTest, miPicking_Articulo.id_picking)

        Assert.AreNotEqual(_GridTest.Rows.Count(), 0)

    End Sub

End Class