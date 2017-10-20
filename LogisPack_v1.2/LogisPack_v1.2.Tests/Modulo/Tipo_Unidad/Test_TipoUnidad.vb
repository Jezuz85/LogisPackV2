Imports CapaDatos

<TestClass()> Public Class Test_TipoUnidad

    Dim Tipo_UnidadTest As Tipo_Unidad

    <TestInitialize>
    Public Sub inicializar()
        Tipo_UnidadTest = Mgr_TipoUnidad_Test.Get_Tipo_Unidad1()
        Mgr_TipoUnidad_Test.Inicializar(Tipo_UnidadTest)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        Mgr_TipoUnidad_Test.Finalizar(Tipo_UnidadTest)
    End Sub

    <TestMethod()> Public Sub Registrar_Tipo_Unidad()

        Dim Tipo_UnidadBD = Mgr_TipoUnidad.Get_Tipo_Unidad(Tipo_UnidadTest.id_tipo_unidad)

        Assert.AreEqual(Tipo_UnidadBD.id_tipo_unidad, Tipo_UnidadTest.id_tipo_unidad)
        Assert.AreEqual(Tipo_UnidadBD.nombre, Tipo_UnidadTest.nombre)

    End Sub

    <TestMethod()> Public Sub Editar_Tipo_Unidad()

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim Tipo_UnidadBD = Mgr_TipoUnidad.Get_Tipo_Unidad(Tipo_UnidadTest.id_tipo_unidad, contexto)
        Tipo_UnidadBD.nombre = "Nombre2"

        Mgr_TipoUnidad.Editar(Tipo_UnidadBD, contexto)
        Assert.AreEqual(Tipo_UnidadBD.id_tipo_unidad, Tipo_UnidadTest.id_tipo_unidad)
        Assert.AreNotEqual(Tipo_UnidadBD.nombre, Tipo_UnidadTest.nombre)

    End Sub

    <TestMethod()> Public Sub Eliminar_Tipo_Unidad()

        Mgr_TipoUnidad.Eliminar(Tipo_UnidadTest.id_tipo_unidad)
        Dim Tipo_UnidadBD = Mgr_TipoUnidad.Get_Tipo_Unidad(Tipo_UnidadTest.id_tipo_unidad)
        Assert.AreEqual(Tipo_UnidadBD, Nothing)

    End Sub
End Class