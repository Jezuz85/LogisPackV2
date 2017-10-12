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

    <TestMethod()>
    Public Sub RegistrarAlmacen()
        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------registro un almacen
        Modulo_Almacen.RegistrarAlmacen(driver, _Almacen1, _Cliente1)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen1)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

    <TestMethod()>
    Public Sub EditarAlmacen()
        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------registro un almacen
        Modulo_Almacen.RegistrarAlmacen(driver, _Almacen1, _Cliente1)

        driver.Navigate().GoToUrl(viewAlmacen.URL)

        '------edito un almacen
        Modulo_Almacen.Crear_Almacen2(_Almacen2)
        Modulo_Almacen.Editar(driver, _Almacen1, _Almacen2, _Cliente1)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen2)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

    <TestMethod()>
    Public Sub EliminarCliente()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------registro un almacen
        Modulo_Almacen.RegistrarAlmacen(driver, _Almacen1, _Cliente1)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen1)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

    <TestMethod()>
    Public Sub BuscarClienteCodigo()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------registro un almacen
        Modulo_Almacen.RegistrarAlmacen(driver, _Almacen1, _Cliente1)

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewAlmacen.Filtro_Cod, _Almacen1.codigo)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen1)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

    <TestMethod()>
    Public Sub BuscarClienteCliente()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------registro un almacen
        Modulo_Almacen.RegistrarAlmacen(driver, _Almacen1, _Cliente1)

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewAlmacen.Filtro_Cli, _Cliente1.nombre)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen1)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

    <TestMethod()>
    Public Sub BuscarClienteNombre()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un cliente
        Modulo_Cliente.RegistrarCliente(driver, _Cliente1)

        '------registro un almacen
        Modulo_Almacen.RegistrarAlmacen(driver, _Almacen1, _Cliente1)

        '-----Opcion Buscar
        Funciones.ID_Boton_Click(driver, viewAlmacen.BotonMaxMinBuscar)
        Funciones.Buscar_Texto_Grid(driver, viewAlmacen.Filtro_Nom, _Almacen1.nombre)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Modulo_Almacen.Existencia_Valor_Grid(driver, ListaTD, _Almacen1)

        '------termino prueba
        Funciones.CerrarPrueba(driver, _Cliente1)

    End Sub

End Class
