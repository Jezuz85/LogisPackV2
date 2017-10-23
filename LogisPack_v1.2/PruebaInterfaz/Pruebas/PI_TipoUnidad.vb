Imports OpenQA.Selenium
Imports CapaDatos

<TestClass()>
Public Class PI_TipoUnidad

    Dim driver As IWebDriver
    Dim ListaTD As List(Of IWebElement)
    Dim _TipoUni1 As Tipo_Unidad
    Dim _TipoUni2 As Tipo_Unidad
    Dim viewTipoUnidad As ViewTipoUnidad = New ViewTipoUnidad()
    Dim _nombreTipoUnidad As String

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de unidad
        Modulo_TipoUnidad.RegistrarTipoUnidad(driver, _TipoUni1)

        _nombreTipoUnidad = _TipoUni1.nombre

    End Sub

    ''' <summary>
    ''' Método que se invoca para finbalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()

        '------elimino el tipo de unidad
        Modulo_TipoUnidad.Eliminar(driver, _nombreTipoUnidad)

        '------cierro el driver
        Funciones.CerrarDriver(driver)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para registrar un TipoUnidad
    ''' </summary>
    <TestMethod()>
    Public Sub Registrar_TipoUnidad()

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoUnidad.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, ListaTD, _TipoUni1.nombre)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para editar un TipoUnidad
    ''' </summary>
    <TestMethod()>
    Public Sub Editar_TipoUnidad()

        '------edito un tipo de unidad
        Modulo_TipoUnidad.Crear_Obj_TipoUni2(_TipoUni2)
        Modulo_TipoUnidad.Editar(driver, _TipoUni2)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoUnidad.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, ListaTD, _TipoUni2.nombre)

        _nombreTipoUnidad = _TipoUni2.nombre

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para eliminar un TipoUnidad
    ''' </summary>
    <TestMethod()>
    Public Sub Eliminar_TipoUnidad()

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoUnidad.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, ListaTD, _TipoUni1.nombre)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para buscar un TipoUnidad dependiendo del nombre
    ''' </summary>
    <TestMethod()>
    Public Sub Buscar_TipoUnidadByNombre()

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewTipoUnidad.Filtro_Nom, Valores.Nom_TipoUnidad_Buscar.ToString)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoUnidad.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, ListaTD, Valores.Nom_TipoUnidad.ToString)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para resetear un grid
    ''' </summary>
    <TestMethod()>
    Public Sub ResetearGridTipoUnidad()

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewTipoUnidad.Filtro_Nom, Valores.Nom_TipoUnidad_Buscar.ToString)

        '-----valdia que el boton reset funciona
        Pruebas.Validar_btnReset(driver)

    End Sub

End Class
