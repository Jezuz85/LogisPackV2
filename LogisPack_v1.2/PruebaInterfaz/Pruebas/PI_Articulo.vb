Imports CapaDatos
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

        '------valido que los valores existen en edetalles
        'Modulo_Articulo.Existencia_Valor_Detalles(driver, _Cliente1, _Almacen1, _Articulo1, _Tipo_Facturacion1, _Tipo_Unidad1)

        '------termino prueba
        'Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

End Class
