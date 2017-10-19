﻿
Imports CapaDatos

<TestClass()> Public Class Test_TipoFacturacion

    Dim _Nuevo As Tipo_Facturacion

    <TestInitialize>
    Public Sub inicializar()

        DataAccess.Inicializar_TipoFacturacion(_Nuevo)

    End Sub
    <TestCleanup>
    Public Sub finalizar()

        DataAccess.Finalizar_TipoFacturacion(_Nuevo)

    End Sub

    <TestMethod()> Public Sub Registrar_Tipo_Facturacion()
        Dim _TipoFacturacion = Mgr_TipoFacturacion.Get_Tipo_Facturacion(_Nuevo.id_tipo_facturacion)
        Assert.AreEqual(_TipoFacturacion.id_tipo_facturacion, _Nuevo.id_tipo_facturacion)
        Assert.AreEqual(_TipoFacturacion.nombre, _Nuevo.nombre)
    End Sub

    <TestMethod()> Public Sub Editar_Tipo_Facturacion()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _TipoFacturacion = Mgr_TipoFacturacion.Get_Tipo_Facturacion(_Nuevo.id_tipo_facturacion, contexto)

        _TipoFacturacion.nombre = "Nombre2"

        Mgr_TipoFacturacion.Editar(_TipoFacturacion, contexto)

        Assert.AreEqual(_TipoFacturacion.id_tipo_facturacion, _Nuevo.id_tipo_facturacion)
        Assert.AreNotEqual(_TipoFacturacion.nombre, _Nuevo.nombre)
    End Sub

    <TestMethod()> Public Sub Eliminar_Tipo_Facturacion()

        Mgr_TipoFacturacion.Eliminar(_Nuevo.id_tipo_facturacion)

        Dim _TipoFacturacion = Mgr_TipoFacturacion.Get_Tipo_Facturacion(_Nuevo.id_tipo_facturacion)

        Assert.AreEqual(_TipoFacturacion, Nothing)

    End Sub

End Class