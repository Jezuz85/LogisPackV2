﻿Imports CapaDatos
Imports OpenQA.Selenium

<TestClass()>
Public Class PI_Articulo

    Dim driver As IWebDriver
    Dim ListaTD As List(Of IWebElement)
    Dim _Cliente1 As Cliente
    Dim _Almacen1 As Almacen
    Dim _Tipo_Facturacion1 As Tipo_Facturacion
    Dim _Tipo_Unidad1 As Tipo_Unidad
    Dim _Articulo1 As Articulo
    Dim _Articulo2 As Articulo
    Dim viewArticulo As ViewArticulo = New ViewArticulo()

    <TestMethod()>
    Public Sub RegistrarArticulo()
        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------registro un almacen
        Modulo_Almacen.RegistrarAlmacen(driver, _Almacen1, _Cliente1)

        '------registro un tipo de facturacion
        Modulo_TipoFacturacion.RegistrarTipoFacturacion(driver, _Tipo_Facturacion1)

        '------registro un tipo de unidad
        Modulo_TipoUnidad.RegistrarTipoUnidad(driver, _Tipo_Unidad1)

        '------registro un articulo
        Modulo_Articulo.RegistrarArticulo(driver, _Cliente1, _Almacen1, _Articulo1, _Tipo_Facturacion1, _Tipo_Unidad1)

        '------obtengo los valores del grid
        driver.Navigate().GoToUrl(viewArticulo.URL)
        Funciones.Obtener_FilasGrid(driver, viewArticulo.GridPrinicipal, ListaTD)

        '------dettales de un articulo
        Modulo_Articulo.Detalles(driver, _Cliente1, _Almacen1, _Articulo1, _Tipo_Facturacion1, _Tipo_Unidad1, ListaTD)

        '------termino prueba
        Modulo_TipoFacturacion.Eliminar(driver, _Tipo_Facturacion1.nombre)
        Modulo_TipoUnidad.Eliminar(driver, _Tipo_Unidad1.nombre)
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

    <TestMethod()>
    Public Sub EditarArticulo()
        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------registro un almacen
        Modulo_Almacen.RegistrarAlmacen(driver, _Almacen1, _Cliente1)

        '------registro un tipo de facturacion
        Modulo_TipoFacturacion.RegistrarTipoFacturacion(driver, _Tipo_Facturacion1)

        '------registro un tipo de unidad
        Modulo_TipoUnidad.RegistrarTipoUnidad(driver, _Tipo_Unidad1)

        '------registro un articulo
        Modulo_Articulo.RegistrarArticulo(driver, _Cliente1, _Almacen1, _Articulo1, _Tipo_Facturacion1, _Tipo_Unidad1)

        '------edito un articulo
        Modulo_Articulo.Crear_Obj_Articulo2(_Articulo2)
        Modulo_Articulo.Editar(driver, _Cliente1, _Almacen1, _Articulo2, _Tipo_Facturacion1, _Tipo_Unidad1)

        '------obtengo los valores del grid
        driver.Navigate().GoToUrl(viewArticulo.URL)
        Funciones.Obtener_FilasGrid(driver, viewArticulo.GridPrinicipal, ListaTD)

        '------dettales de un articulo
        Modulo_Articulo.Detalles(driver, _Cliente1, _Almacen1, _Articulo2, _Tipo_Facturacion1, _Tipo_Unidad1, ListaTD)

        '------termino prueba
        Modulo_TipoFacturacion.Eliminar(driver, _Tipo_Facturacion1.nombre)
        Modulo_TipoUnidad.Eliminar(driver, _Tipo_Unidad1.nombre)
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

    <TestMethod()>
    Public Sub EliminarArticulo()
        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------registro un almacen
        Modulo_Almacen.RegistrarAlmacen(driver, _Almacen1, _Cliente1)

        '------registro un tipo de facturacion
        Modulo_TipoFacturacion.RegistrarTipoFacturacion(driver, _Tipo_Facturacion1)

        '------registro un tipo de unidad
        Modulo_TipoUnidad.RegistrarTipoUnidad(driver, _Tipo_Unidad1)

        '------registro un articulo
        Modulo_Articulo.RegistrarArticulo(driver, _Cliente1, _Almacen1, _Articulo1, _Tipo_Facturacion1, _Tipo_Unidad1)

        '------obtengo los valores del grid
        driver.Navigate().GoToUrl(viewArticulo.URL)
        Funciones.Obtener_FilasGrid(driver, viewArticulo.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Articulo.Existencia_Valor_Grid(driver, ListaTD, _Cliente1, _Almacen1, _Articulo1)

        '------termino prueba
        Modulo_TipoFacturacion.Eliminar(driver, _Tipo_Facturacion1.nombre)
        Modulo_TipoUnidad.Eliminar(driver, _Tipo_Unidad1.nombre)
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub



End Class