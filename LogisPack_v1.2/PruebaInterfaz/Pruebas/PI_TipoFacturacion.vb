Imports OpenQA.Selenium
Imports CapaDatos

<TestClass()>
Public Class PI_TipoFacturacion

    Dim driver As IWebDriver
    Dim ListaTD As List(Of IWebElement)
    Dim _TipoFact1 As Tipo_Facturacion
    Dim _TipoFact2 As Tipo_Facturacion
    Dim viewTipoFacturacion As ViewTipoFacturacion = New ViewTipoFacturacion()

    <TestMethod()>
    Public Sub Registrar_TipoFacturacion()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de facturacion
        Modulo_TipoFacturacion.RegistrarTipoFacturacion(driver, _TipoFact1)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_TipoFacturacion.Existencia_Valor_Grid(driver, ListaTD, _TipoFact1)

        '------elimino el tipo de facturacion
        Modulo_TipoFacturacion.Eliminar(driver, _TipoFact1.nombre)

        '------cierro el driver
        Funciones.CerrarDriver(driver)
    End Sub

    <TestMethod()>
    Public Sub EditarTipoFacturacion()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de facturacion
        Modulo_TipoFacturacion.RegistrarTipoFacturacion(driver, _TipoFact1)

        '------edito un tipo de facturacion
        Modulo_TipoFacturacion.Crear_TipoFact2(_TipoFact2)
        Modulo_TipoFacturacion.Editar(driver, _TipoFact2)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_TipoFacturacion.Existencia_Valor_Grid(driver, ListaTD, _TipoFact2)

        '------elimino el tipo de facturacion
        Modulo_TipoFacturacion.Eliminar(driver, _TipoFact2.nombre)

        '------cierro el driver
        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub EliminarTipoFacturacion()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de facturacion
        Modulo_TipoFacturacion.RegistrarTipoFacturacion(driver, _TipoFact1)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_TipoFacturacion.Existencia_Valor_Grid(driver, ListaTD, _TipoFact1)

        '------elimino el tipo de facturacion
        Modulo_TipoFacturacion.Eliminar(driver, _TipoFact1.nombre)

        '------cierro el driver
        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub Buscar_TipoFacturacion_Nombre()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de facturacion
        Modulo_TipoFacturacion.RegistrarTipoFacturacion(driver, _TipoFact1)

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewTipoFacturacion.Filtro_Nom, Valores.Nom_TipoFact_Buscar.ToString)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_TipoFacturacion.Existencia_Valor_Grid(driver, ListaTD, _TipoFact1)

        '------elimino el tipo de facturacion
        Modulo_TipoFacturacion.Eliminar(driver, _TipoFact1.nombre)

        '------cierro el driver
        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub ResetearGridTipoFacturacion()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de facturacion
        Modulo_TipoFacturacion.RegistrarTipoFacturacion(driver, _TipoFact1)

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewTipoFacturacion.Filtro_Nom, Valores.Nom_TipoFact_Buscar.ToString)

        '-----valdia que el boton reset funciona
        Pruebas.Validar_btnReset(driver)

        '------elimino el tipo de facturacion
        Modulo_TipoFacturacion.Eliminar(driver, _TipoFact1.nombre)

        '------cierro el driver
        Funciones.CerrarDriver(driver)
    End Sub

End Class
