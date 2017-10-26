Imports CapaDatos

<TestClass()> Public Class Test_Almacen

    Dim _Cliente1
    Dim AlmacenTest

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        _Cliente1 = Mgr_Cliente_Test.Get_Cliente1()
        Mgr_Almacen_Test.Inicializar(_Cliente1, AlmacenTest)

    End Sub

    ''' <summary>
    ''' Método que se invoca para finalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()
        Mgr_Cliente_Test.Finalizar(_Cliente1)
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para registrar un almacen
    ''' </summary>
    <TestMethod()> Public Sub Registrar_Almacen()

        Dim AlmacenBd = Mgr_Almacen.Consultar(AlmacenTest.id_almacen)

        Assert.AreEqual(AlmacenBd.id_almacen, AlmacenTest.id_almacen)
        Assert.AreEqual(AlmacenBd.id_cliente, AlmacenTest.id_cliente)
        Assert.AreEqual(AlmacenBd.nombre, AlmacenTest.nombre)
        Assert.AreEqual(AlmacenBd.codigo, AlmacenTest.codigo)
        Assert.AreEqual(AlmacenBd.coeficiente_volumetrico, AlmacenTest.coeficiente_volumetrico)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para editar un almacen
    ''' </summary>
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

    ''' <summary>
    ''' Prueba que se ejecuta para eliminar un almacen
    ''' </summary>
    <TestMethod()> Public Sub Eliminar_Almacen()

        Mgr_Almacen.Eliminar(AlmacenTest.id_almacen)
        Dim AlmacenBD = Mgr_Almacen.Consultar(AlmacenTest.id_almacen)

        Assert.AreEqual(AlmacenBD, Nothing)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en almacen, con filtro de Codigo
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_AlmacenByCodigo()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteAlmacen("Codv", Val_Almacen.Filtro_Codigo.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en almacen, con filtro de nombre
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_AlmacenByNombre()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteAlmacen("Nombrev", Val_Almacen.Filtro_Nombre.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en almacen, con filtro de coeficiente
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_AlmacenByCoeficienteVolumetrico()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteAlmacen("123", Val_Almacen.Filtro_Coeficiente.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en almacen, con filtro de cliente
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_AlmacenByCliente()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteAlmacen("Nombrev", Val_Almacen.Filtro_Cliente.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())

    End Sub

End Class