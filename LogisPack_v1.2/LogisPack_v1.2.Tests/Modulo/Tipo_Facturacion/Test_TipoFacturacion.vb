
Imports CapaDatos

<TestClass()> Public Class Test_TipoFacturacion

    Dim _TipoFacturacionTest As Tipo_Facturacion

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        _TipoFacturacionTest = Mgr_TipoFacturacion_Test.Get_TipoFacturacion1()
        Mgr_TipoFacturacion_Test.Inicializar(_TipoFacturacionTest)

    End Sub

    ''' <summary>
    ''' Método que se invoca para finbalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()

        Mgr_TipoFacturacion_Test.Finalizar(_TipoFacturacionTest)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para registrar un TipoFacturacion
    ''' </summary>
    <TestMethod()> Public Sub Registrar_Tipo_Facturacion()

        Dim _TipoFacturacionBD = Mgr_TipoFacturacion.Get_Tipo_FacturacionById(_TipoFacturacionTest.id_tipo_facturacion)

        Assert.AreEqual(_TipoFacturacionBD.id_tipo_facturacion, _TipoFacturacionTest.id_tipo_facturacion)
        Assert.AreEqual(_TipoFacturacionBD.nombre, _TipoFacturacionTest.nombre)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para editar un TipoFacturacion
    ''' </summary>
    <TestMethod()> Public Sub Editar_Tipo_Facturacion()

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim _TipoFacturacionBD = Mgr_TipoFacturacion.Get_Tipo_Facturacion(_TipoFacturacionTest.id_tipo_facturacion, contexto)
        _TipoFacturacionBD.nombre = "Nombre2"
        Mgr_TipoFacturacion.Editar(_TipoFacturacionBD, contexto)

        Assert.AreEqual(_TipoFacturacionBD.id_tipo_facturacion, _TipoFacturacionTest.id_tipo_facturacion)
        Assert.AreNotEqual(_TipoFacturacionBD.nombre, _TipoFacturacionTest.nombre)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para eliminar un TipoFacturacion
    ''' </summary>
    <TestMethod()> Public Sub Eliminar_Tipo_Facturacion()

        Mgr_TipoFacturacion.Eliminar(_TipoFacturacionTest.id_tipo_facturacion)
        Dim _TipoFacturacion = Mgr_TipoFacturacion.Get_Tipo_FacturacionById(_TipoFacturacionTest.id_tipo_facturacion)

        Assert.AreEqual(_TipoFacturacion, Nothing)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en Tipo de Facturacion, con filtro de Codigo
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_TipoFacturacionByNombre()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteTipoFacturacion("Nombrev", Val_TipoFacturacion.Filtro_Nombre.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())

    End Sub

End Class