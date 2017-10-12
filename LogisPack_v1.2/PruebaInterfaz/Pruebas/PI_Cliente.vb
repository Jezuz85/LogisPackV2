Imports CapaDatos
Imports OpenQA.Selenium

<TestClass()>
Public Class PI_Cliente

    Dim driver As IWebDriver
    Dim ListaTD As List(Of IWebElement)
    Dim _Cliente1 As Cliente
    Dim _Cliente2 As Cliente
    Dim viewCliente As ViewCliente = New ViewCliente()

    <TestMethod()>
    Public Sub RegistrarCliente()
        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Cliente.Existencia_Valor_Grid(driver, ListaTD, _Cliente1)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

    <TestMethod()>
    Public Sub EditarCliente()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------edito el cliente
        Modulo_Cliente.Crear_Cliente2(_Cliente2)
        Modulo_Cliente.Editar(driver, _Cliente1, _Cliente2)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Cliente.Existencia_Valor_Grid(driver, ListaTD, _Cliente2)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente2)

    End Sub

    <TestMethod()>
    Public Sub EliminarCliente()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Cliente.Existencia_Valor_Grid(driver, ListaTD, _Cliente1)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

    <TestMethod()>
    Public Sub BuscarClienteCodigo()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewCliente.Filtro_Cod, _Cliente1.codigo)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Cliente.Existencia_Valor_Grid(driver, ListaTD, _Cliente1)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

    <TestMethod()>
    Public Sub BuscarClienteNombre()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewCliente.Filtro_Nom, Valores.Nom_Cliente_Buscar.ToString)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Cliente.Existencia_Valor_Grid(driver, ListaTD, _Cliente1)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

    <TestMethod()>
    Public Sub ResetearGridCliente()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewCliente.Filtro_Nom, Valores.Nom_Cliente_Buscar.ToString)

        '-----valdia que el boton reset funciona
        Pruebas.Validar_btnReset(driver)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1)


    End Sub

End Class