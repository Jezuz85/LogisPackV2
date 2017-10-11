Imports OpenQA.Selenium

<TestClass()>
Public Class PI_TipoFacturacion

    Dim driver As IWebDriver
    Dim ListaTD As List(Of IWebElement)

    <TestMethod()>
    Public Sub Registrar_TipoFacturacion()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_TipoFacturacion.Registrar(driver)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridTipoFact.ToString)

        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Nom_TipoFact.ToString)
        Assert.AreEqual(True, resultado)

        driver = Modulo_TipoFacturacion.Eliminar(driver, Valores.Nom_TipoFact.ToString)

        Funciones.CerrarDriver(driver)
    End Sub

    <TestMethod()>
    Public Sub EditarTipoFacturacion()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_TipoFacturacion.Registrar(driver)

        driver = Modulo_TipoFacturacion.Editar(driver)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridTipoFact.ToString)

        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Nom_TipoFact_Edit.ToString)
        Assert.AreEqual(True, resultado)

        driver = Modulo_TipoFacturacion.Eliminar(driver, Valores.Nom_TipoFact_Edit.ToString)

        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub EliminarTipoFacturacion()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_TipoFacturacion.Registrar(driver)

        driver = Modulo_TipoFacturacion.Eliminar(driver, Valores.Nom_TipoFact.ToString)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridTipoFact.ToString)

        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Nom_TipoFact.ToString)
        Assert.AreEqual(False, resultado)

        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub Buscar_TipoFacturacion_Nombre()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_TipoFacturacion.Registrar(driver)

        driver = Funciones.Buscar_Texto_Grid(driver, Valores.Filtro_Nom.ToString, Valores.Nom_TipoFact_Buscar.ToString)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridTipoFact.ToString)
        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Nom_TipoFact.ToString)
        Assert.AreEqual(True, resultado)


        driver = Modulo_TipoFacturacion.Eliminar(driver, Valores.Nom_TipoFact.ToString)

        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub ResetearGridTipoFacturacion()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_TipoFacturacion.Registrar(driver)

        driver = Funciones.Buscar_Texto_Grid(driver, Valores.Filtro_Nom.ToString, Valores.Nom_TipoFact_Buscar.ToString)
        Dim filasAntes As Integer = Funciones.Obtener_CantidadFilasGrid(driver, Valores.ID_GridTipoFact.ToString)

        driver = Funciones.ResetearGrid(driver)

        Dim filasDespues As Integer = Funciones.Obtener_CantidadFilasGrid(driver, Valores.ID_GridTipoFact.ToString)

        Assert.AreNotEqual(filasAntes, filasDespues)

        driver = Modulo_TipoFacturacion.Eliminar(driver, Valores.Nom_TipoFact.ToString)

        Funciones.CerrarDriver(driver)

    End Sub

End Class
