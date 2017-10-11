Imports OpenQA.Selenium

<TestClass()>
Public Class PI_Cliente

    Dim driver As IWebDriver
    Dim ListaTD As List(Of IWebElement)

    <TestMethod()>
    Public Sub RegistrarCliente()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_Cliente.Registrar(driver)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridEmpresa.ToString)

        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Cod_Empresa.ToString)
        Assert.AreEqual(True, resultado)

        resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Nom_Empresa.ToString)
        Assert.AreEqual(True, resultado)

        driver = Modulo_Cliente.Eliminar(driver, Valores.Cod_Empresa.ToString)

        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub EditarCliente()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_Cliente.Registrar(driver)

        driver = Modulo_Cliente.Editar(driver)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridEmpresa.ToString)

        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Cod_Empresa_Edit.ToString)
        Assert.AreEqual(True, resultado)

        resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Nom_Empresa_Edit.ToString)
        Assert.AreEqual(True, resultado)

        driver = Modulo_Cliente.Eliminar(driver, Valores.Cod_Empresa_Edit.ToString)

        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub EliminarCliente()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_Cliente.Registrar(driver)

        driver = Modulo_Cliente.Eliminar(driver, Valores.Cod_Empresa.ToString)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridEmpresa.ToString)

        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Cod_Empresa.ToString)
        Assert.AreEqual(False, resultado)

        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub BuscarClienteCodigo()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_Cliente.Registrar(driver)

        driver = Funciones.Buscar_Texto_Grid(driver, Valores.Filtro_Cod.ToString, Valores.Cod_Empresa.ToString)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridEmpresa.ToString)
        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Cod_Empresa.ToString)
        Assert.AreEqual(True, resultado)

        driver = Modulo_Cliente.Eliminar(driver, Valores.Cod_Empresa.ToString)

        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub BuscarClienteNombre()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_Cliente.Registrar(driver)

        driver = Funciones.Buscar_Texto_Grid(driver, Valores.Filtro_Nom.ToString, Valores.Nom_Empresa_Buscar.ToString)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridEmpresa.ToString)
        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Nom_Empresa.ToString)
        Assert.AreEqual(True, resultado)


        driver = Modulo_Cliente.Eliminar(driver, Valores.Cod_Empresa.ToString)

        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub ResetearGridCliente()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_Cliente.Registrar(driver)

        driver = Funciones.Buscar_Texto_Grid(driver, Valores.Filtro_Nom.ToString, Valores.Nom_Empresa_Buscar.ToString)
        Dim filasAntes As Integer = Funciones.Obtener_CantidadFilasGrid(driver, Valores.ID_GridEmpresa.ToString)

        driver = Funciones.ResetearGrid(driver)

        Dim filasDespues As Integer = Funciones.Obtener_CantidadFilasGrid(driver, Valores.ID_GridEmpresa.ToString)

        Assert.AreNotEqual(filasAntes, filasDespues)

        driver = Modulo_Cliente.Eliminar(driver, Valores.Cod_Empresa.ToString)

        Funciones.CerrarDriver(driver)

    End Sub

End Class