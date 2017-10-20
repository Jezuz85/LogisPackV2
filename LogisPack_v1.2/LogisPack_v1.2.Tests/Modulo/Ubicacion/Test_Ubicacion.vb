Imports CapaDatos

<TestClass()> Public Class Test_Ubicacion

    Dim ArticuloTest As Articulo
    Dim AlmacenTest As Almacen
    Dim Tipo_FacturacionTest As Tipo_Facturacion
    Dim Tipo_UnidadTest As Tipo_Unidad
    Dim ClienteTest As Cliente
    Dim UbicacionTest As Ubicacion

    <TestInitialize>
    Public Sub inicializar()
        Mgr_Ubicacion_Test.Inicializar(ArticuloTest, AlmacenTest, Tipo_FacturacionTest, Tipo_UnidadTest, ClienteTest, UbicacionTest)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        Mgr_Articulo_Test.Finalizar(Tipo_FacturacionTest, Tipo_UnidadTest, ClienteTest)
    End Sub

    <TestMethod()> Public Sub Registrar_Ubicacion()

        Dim UbicacionBD = Mgr_Ubicacion.Get_Ubicacion(UbicacionTest.id_ubicacion)

        Assert.AreEqual(UbicacionBD.id_ubicacion, UbicacionTest.id_ubicacion)
        Assert.AreEqual(UbicacionBD.zona, UbicacionTest.zona)
        Assert.AreEqual(UbicacionBD.estante, UbicacionTest.estante)
        Assert.AreEqual(UbicacionBD.columna, UbicacionTest.columna)
        Assert.AreEqual(UbicacionBD.fila, UbicacionTest.fila)
        Assert.AreEqual(UbicacionBD.panel, UbicacionTest.panel)
        Assert.AreEqual(UbicacionBD.referencia_ubicacion, UbicacionTest.referencia_ubicacion)

    End Sub

    <TestMethod()> Public Sub Editar_Ubicacion()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim UbicacionTest = Mgr_Ubicacion.Get_Ubicacion(Me.UbicacionTest.id_ubicacion, contexto)

        UbicacionTest.zona = "zo2"
        UbicacionTest.estante = "es2"
        UbicacionTest.fila = "fi2"
        UbicacionTest.columna = "co2"
        UbicacionTest.panel = "pa2"
        UbicacionTest.referencia_ubicacion = "referencia_ubicacion2"

        Mgr_Ubicacion.Editar(UbicacionTest, contexto)

        Assert.AreEqual(UbicacionTest.id_ubicacion, Me.UbicacionTest.id_ubicacion)
        Assert.AreNotEqual(UbicacionTest.zona, Me.UbicacionTest.zona)
        Assert.AreNotEqual(UbicacionTest.estante, Me.UbicacionTest.estante)
        Assert.AreNotEqual(UbicacionTest.fila, Me.UbicacionTest.fila)
        Assert.AreNotEqual(UbicacionTest.columna, Me.UbicacionTest.columna)
        Assert.AreNotEqual(UbicacionTest.panel, Me.UbicacionTest.panel)
        Assert.AreNotEqual(UbicacionTest.referencia_ubicacion, Me.UbicacionTest.referencia_ubicacion)


    End Sub

    <TestMethod()> Public Sub Eliminar_Ubicacion()

        Mgr_Ubicacion.Eliminar(UbicacionTest.id_ubicacion)
        Dim UbicacionBD = Mgr_Ubicacion.Get_Ubicacion(UbicacionTest.id_ubicacion)
        Assert.AreEqual(UbicacionBD, Nothing)

    End Sub
End Class