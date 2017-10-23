Imports CapaDatos
Imports OpenQA.Selenium

<TestClass()>
Public Class PI_Cliente

    Dim driver As IWebDriver
    Dim ListaTD As List(Of IWebElement)
    Dim _Cliente1 As Cliente
    Dim _Cliente2 As Cliente
    Dim viewCliente As ViewCliente = New ViewCliente()
    Dim _Codigo As String

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        _Codigo = _Cliente1.codigo

    End Sub

    ''' <summary>
    ''' Método que se invoca para finbalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Codigo)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para registrar un Cliente
    ''' </summary>
    <TestMethod()>
    Public Sub RegistrarCliente()

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Cliente.Existencia_Valor_Grid(driver, ListaTD, _Cliente1)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para editar un Cliente
    ''' </summary>
    <TestMethod()>
    Public Sub EditarCliente()

        '------edito el cliente
        Modulo_Cliente.Crear_Obj_Cliente2(_Cliente2)
        Modulo_Cliente.Editar(driver, _Cliente1, _Cliente2)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Cliente.Existencia_Valor_Grid(driver, ListaTD, _Cliente2)

        _Codigo = _Cliente2.codigo

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para eliminar un Cliente
    ''' </summary>
    <TestMethod()>
    Public Sub EliminarCliente()

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Cliente.Existencia_Valor_Grid(driver, ListaTD, _Cliente1)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para buscar un Cliente dependiendo del codigo
    ''' </summary>
    <TestMethod()>
    Public Sub Buscar_ClienteByCodigo()

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewCliente.Filtro_Cod, _Cliente1.codigo)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Cliente.Existencia_Valor_Grid(driver, ListaTD, _Cliente1)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para buscar un Cliente dependiendo del nombre
    ''' </summary>
    <TestMethod()>
    Public Sub Buscar_ClienteByNombre()

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewCliente.Filtro_Nom, Valores.Nom_Cliente_Buscar.ToString)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Cliente.Existencia_Valor_Grid(driver, ListaTD, _Cliente1)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para resetear un grid
    ''' </summary>
    <TestMethod()>
    Public Sub ResetearGridCliente()

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewCliente.Filtro_Nom, Valores.Nom_Cliente_Buscar.ToString)

        '-----valdia que el boton reset funciona
        Pruebas.Validar_btnReset(driver)

    End Sub

End Class