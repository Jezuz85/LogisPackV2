Imports CapaDatos

<TestClass()> Public Class Test_TipoUnidad
    Dim _Nuevo As Tipo_Unidad

    <TestInitialize>
    Public Sub inicializar()
        DataAccess.Inicializar_TipoUnidad(_Nuevo)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        DataAccess.Finalizar_TipoUnidad(_Nuevo)
    End Sub

    <TestMethod()> Public Sub Registrar_Tipo_Unidad()
        Dim _Tipo_Unidad = Getter.Tipo_Unidad(_Nuevo.id_tipo_unidad)
        Assert.AreEqual(_Tipo_Unidad.id_tipo_unidad, _Nuevo.id_tipo_unidad)
        Assert.AreEqual(_Tipo_Unidad.nombre, _Nuevo.nombre)
    End Sub

    <TestMethod()> Public Sub Editar_Tipo_Unidad()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _Tipo_Unidad = Getter.Tipo_Unidad(_Nuevo.id_tipo_unidad, contexto)

        _Tipo_Unidad.nombre = "Nombre2"

        Update.Tipo_Unidad(_Tipo_Unidad, contexto)

        Assert.AreEqual(_Tipo_Unidad.id_tipo_unidad, _Nuevo.id_tipo_unidad)
        Assert.AreNotEqual(_Tipo_Unidad.nombre, _Nuevo.nombre)
    End Sub

    <TestMethod()> Public Sub Eliminar_Tipo_Unidad()

        Delete.TipoUnidad(_Nuevo.id_tipo_unidad)

        Dim _Tipo_Unidad = Getter.Tipo_Unidad(_Nuevo.id_tipo_unidad)

        Assert.AreEqual(_Tipo_Unidad, Nothing)

    End Sub
End Class