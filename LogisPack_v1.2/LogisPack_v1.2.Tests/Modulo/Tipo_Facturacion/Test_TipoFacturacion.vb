
Imports CapaDatos

<TestClass()> Public Class Test_TipoFacturacion

    Dim _TipoFacturacionTest As Tipo_Facturacion

    <TestInitialize>
    Public Sub inicializar()

        _TipoFacturacionTest = Mgr_TipoFacturacion_Test.Get_TipoFacturacion1()
        Mgr_TipoFacturacion_Test.Inicializar(_TipoFacturacionTest)

    End Sub

    <TestCleanup>
    Public Sub finalizar()

        Mgr_TipoFacturacion_Test.Finalizar(_TipoFacturacionTest)

    End Sub

    <TestMethod()> Public Sub Registrar_Tipo_Facturacion()

        Dim _TipoFacturacionBD = Mgr_TipoFacturacion.Get_Tipo_Facturacion(_TipoFacturacionTest.id_tipo_facturacion)

        Assert.AreEqual(_TipoFacturacionBD.id_tipo_facturacion, _TipoFacturacionTest.id_tipo_facturacion)
        Assert.AreEqual(_TipoFacturacionBD.nombre, _TipoFacturacionTest.nombre)

    End Sub

    <TestMethod()> Public Sub Editar_Tipo_Facturacion()

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim _TipoFacturacionBD = Mgr_TipoFacturacion.Get_Tipo_Facturacion(_TipoFacturacionTest.id_tipo_facturacion, contexto)
        _TipoFacturacionBD.nombre = "Nombre2"
        Mgr_TipoFacturacion.Editar(_TipoFacturacionBD, contexto)

        Assert.AreEqual(_TipoFacturacionBD.id_tipo_facturacion, _TipoFacturacionTest.id_tipo_facturacion)
        Assert.AreNotEqual(_TipoFacturacionBD.nombre, _TipoFacturacionTest.nombre)

    End Sub

    <TestMethod()> Public Sub Eliminar_Tipo_Facturacion()

        Mgr_TipoFacturacion.Eliminar(_TipoFacturacionTest.id_tipo_facturacion)
        Dim _TipoFacturacion = Mgr_TipoFacturacion.Get_Tipo_Facturacion(_TipoFacturacionTest.id_tipo_facturacion)

        Assert.AreEqual(_TipoFacturacion, Nothing)

    End Sub

End Class