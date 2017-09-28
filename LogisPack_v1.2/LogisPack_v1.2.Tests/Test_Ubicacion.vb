Imports CapaDatos

<TestClass()> Public Class Test_Ubicacion
    Dim _Articulo As Articulo
    Dim _Almacen As Almacen
    Dim _Tipo_Facturacion As Tipo_Facturacion
    Dim _Tipo_Unidad As Tipo_Unidad
    Dim _Cliente As Cliente
    Dim _Ubicacion As Ubicacion

    <TestInitialize>
    Public Sub inicializar()
        DataAccess.Inicializar_Ubicacion(_Articulo, _Almacen, _Tipo_Facturacion, _Tipo_Unidad, _Cliente, _Ubicacion)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        DataAccess.Finalizar_Articulo(_Tipo_Facturacion, _Tipo_Unidad, _Cliente)
    End Sub

    <TestMethod()> Public Sub Registrar_Ubicacion()

        Dim miUbicacion = Getter.Ubicacion(_Ubicacion.id_ubicacion)

        Assert.AreEqual(miUbicacion.id_ubicacion, _Ubicacion.id_ubicacion)
        Assert.AreEqual(miUbicacion.zona, _Ubicacion.zona)
        Assert.AreEqual(miUbicacion.estante, _Ubicacion.estante)
        Assert.AreEqual(miUbicacion.columna, _Ubicacion.columna)
        Assert.AreEqual(miUbicacion.fila, _Ubicacion.fila)
        Assert.AreEqual(miUbicacion.panel, _Ubicacion.panel)
        Assert.AreEqual(miUbicacion.referencia_ubicacion, _Ubicacion.referencia_ubicacion)

    End Sub

    <TestMethod()> Public Sub Editar_Ubicacion()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _Edit = Getter.Ubicacion(_Ubicacion.id_ubicacion, contexto)

        _Edit.zona = "zo2"
        _Edit.estante = "es2"
        _Edit.fila = "fi2"
        _Edit.columna = "co2"
        _Edit.panel = "pa2"
        _Edit.referencia_ubicacion = "referencia_ubicacion2"

        Update.Ubicacion(_Edit, contexto)

        Assert.AreEqual(_Edit.id_ubicacion, _Ubicacion.id_ubicacion)
        Assert.AreNotEqual(_Edit.zona, _Ubicacion.zona)
        Assert.AreNotEqual(_Edit.estante, _Ubicacion.estante)
        Assert.AreNotEqual(_Edit.fila, _Ubicacion.fila)
        Assert.AreNotEqual(_Edit.columna, _Ubicacion.columna)
        Assert.AreNotEqual(_Edit.panel, _Ubicacion.panel)
        Assert.AreNotEqual(_Edit.referencia_ubicacion, _Ubicacion.referencia_ubicacion)


    End Sub

    <TestMethod()> Public Sub Eliminar_Ubicacion()

        Delete.Ubicacion(_Ubicacion.id_ubicacion)

        Dim miUbicacion = Getter.Ubicacion(_Ubicacion.id_ubicacion)

        Assert.AreEqual(miUbicacion, Nothing)

    End Sub
End Class