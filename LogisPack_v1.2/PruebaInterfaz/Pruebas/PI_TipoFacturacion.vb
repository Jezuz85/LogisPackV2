Imports OpenQA.Selenium
Imports CapaDatos

<TestClass()>
Public Class PI_TipoFacturacion

    Dim driver As IWebDriver
    Dim ListaTD As List(Of IWebElement)
    Dim _TipoFact1 As Tipo_Facturacion
    Dim _TipoFact2 As Tipo_Facturacion
    Dim viewTipoFacturacion As ViewTipoFacturacion = New ViewTipoFacturacion()
    Dim _nombreTipoFacturacion As String

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de facturacion
        Modulo_TipoFacturacion.RegistrarTipoFacturacion(driver, _TipoFact1)

        _nombreTipoFacturacion = _TipoFact1.nombre

    End Sub

    ''' <summary>
    ''' Método que se invoca para finbalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()

        '------elimino el tipo de facturacion
        Modulo_TipoFacturacion.Eliminar(driver, _nombreTipoFacturacion)

        '------cierro el driver
        Funciones.CerrarDriver(driver)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para registrar un TipoFacturacion
    ''' </summary>
    <TestMethod()>
    Public Sub Registrar_TipoFacturacion()

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_TipoFacturacion.Existencia_Valor_Grid(driver, ListaTD, _TipoFact1)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para editar un TipoFacturacion
    ''' </summary>
    <TestMethod()>
    Public Sub EditarTipoFacturacion()

        '------edito un tipo de facturacion
        Modulo_TipoFacturacion.Crear_Obj_TipoFact2(_TipoFact2)
        Modulo_TipoFacturacion.Editar(driver, _TipoFact2)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_TipoFacturacion.Existencia_Valor_Grid(driver, ListaTD, _TipoFact2)

        _nombreTipoFacturacion = _TipoFact2.nombre

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para eliminar un TipoFacturacion
    ''' </summary>
    <TestMethod()>
    Public Sub EliminarTipoFacturacion()

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_TipoFacturacion.Existencia_Valor_Grid(driver, ListaTD, _TipoFact1)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para buscar un TipoFacturacion dependiendo del nombre
    ''' </summary>
    <TestMethod()>
    Public Sub Buscar_TipoFacturacionByNombre()

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewTipoFacturacion.Filtro_Nom, Valores.Nom_TipoFact_Buscar.ToString)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_TipoFacturacion.Existencia_Valor_Grid(driver, ListaTD, _TipoFact1)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para resetear un grid
    ''' </summary>
    <TestMethod()>
    Public Sub ResetearGridTipoFacturacion()

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewTipoFacturacion.Filtro_Nom, Valores.Nom_TipoFact_Buscar.ToString)

        '-----valdia que el boton reset funciona
        Pruebas.Validar_btnReset(driver)

    End Sub

End Class
