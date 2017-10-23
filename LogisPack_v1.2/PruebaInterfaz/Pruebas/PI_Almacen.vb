Imports CapaDatos
Imports OpenQA.Selenium

<TestClass()>
Public Class PI_Almacen

    Dim driver As IWebDriver
    Dim ListaTD As List(Of IWebElement)
    Dim _Cliente1 As Cliente
    Dim _Almacen1 As Almacen
    Dim _Almacen2 As Almacen
    Dim viewAlmacen As ViewAlmacen = New ViewAlmacen()

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------registro un almacen
        Modulo_Almacen.RegistrarAlmacen(driver, _Almacen1, _Cliente1)

    End Sub

    ''' <summary>
    ''' Método que se invoca para finbalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1.codigo)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para registrar un almacen
    ''' </summary>
    <TestMethod()>
    Public Sub RegistrarAlmacen()

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen1)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para editar un almacen
    ''' </summary>
    <TestMethod()>
    Public Sub EditarAlmacen()

        driver.Navigate().GoToUrl(viewAlmacen.URL)

        '------edito un almacen
        Modulo_Almacen.Crear_Obj_Almacen2(_Almacen2)
        Modulo_Almacen.Editar(driver, _Almacen1, _Almacen2, _Cliente1)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen2)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para eliminar un almacen
    ''' </summary>
    <TestMethod()>
    Public Sub EliminarCliente()

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen1)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para buscar un  almacen dependiendo del codigo de un almacen
    ''' </summary>
    <TestMethod()>
    Public Sub Buscar_AlmacenByCodigo()

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewAlmacen.Filtro_Cod, _Almacen1.codigo)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen1)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para buscar un almacen dependiendo del nombre de un cliente
    ''' </summary>
    <TestMethod()>
    Public Sub Buscar_AlmacenByCliente()

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewAlmacen.Filtro_Cli, _Cliente1.nombre)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen1)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para buscar un almacen dependiendo del nombre de un almacen
    ''' </summary>
    <TestMethod()>
    Public Sub Buscar_AlmacenByNombre()

        '-----Opcion Buscar
        Funciones.ID_Boton_Click(driver, viewAlmacen.BotonMaxMinBuscar)
        Funciones.Buscar_Texto_Grid(driver, viewAlmacen.Filtro_Nom, _Almacen1.nombre)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen1)

    End Sub

End Class
