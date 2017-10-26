Imports CapaDatos

<TestClass()> Public Class Test_TipoUnidad

    Dim Tipo_UnidadTest As Tipo_Unidad

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()
        Tipo_UnidadTest = Mgr_TipoUnidad_Test.Get_Tipo_Unidad1()
        Mgr_TipoUnidad_Test.Inicializar(Tipo_UnidadTest)
    End Sub

    ''' <summary>
    ''' Método que se invoca para finbalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()
        Mgr_TipoUnidad_Test.Finalizar(Tipo_UnidadTest)
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para registrar un TipoUnidad
    ''' </summary>
    <TestMethod()> Public Sub Registrar_Tipo_Unidad()

        Dim Tipo_UnidadBD = Mgr_TipoUnidad.Get_Tipo_Unidad(Tipo_UnidadTest.id_tipo_unidad)

        Assert.AreEqual(Tipo_UnidadBD.id_tipo_unidad, Tipo_UnidadTest.id_tipo_unidad)
        Assert.AreEqual(Tipo_UnidadBD.nombre, Tipo_UnidadTest.nombre)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para editar un TipoUnidad
    ''' </summary>
    <TestMethod()> Public Sub Editar_Tipo_Unidad()

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim Tipo_UnidadBD = Mgr_TipoUnidad.Get_Tipo_Unidad(Tipo_UnidadTest.id_tipo_unidad, contexto)
        Tipo_UnidadBD.nombre = "Nombre2"

        Mgr_TipoUnidad.Editar(Tipo_UnidadBD, contexto)
        Assert.AreEqual(Tipo_UnidadBD.id_tipo_unidad, Tipo_UnidadTest.id_tipo_unidad)
        Assert.AreNotEqual(Tipo_UnidadBD.nombre, Tipo_UnidadTest.nombre)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para eliminar un TipoUnidad
    ''' </summary>
    <TestMethod()> Public Sub Eliminar_Tipo_Unidad()

        Mgr_TipoUnidad.Eliminar(Tipo_UnidadTest.id_tipo_unidad)
        Dim Tipo_UnidadBD = Mgr_TipoUnidad.Get_Tipo_Unidad(Tipo_UnidadTest.id_tipo_unidad)
        Assert.AreEqual(Tipo_UnidadBD, Nothing)

    End Sub


    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en Tipo de Unidad, con filtro de Codigo
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_TipoUnidadByNombre()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteTipoUnidad("Nombrev", Val_TipoUnidad.Filtro_Nombre.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())

    End Sub
End Class