Imports OpenQA.Selenium

<TestClass()>
Public Class PI_TipoUnidad

    Dim driver As IWebDriver
    Dim ListaTD As List(Of IWebElement)

    <TestMethod()>
    Public Sub Registrar_TipoUnidad()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_TipoUnidad.Registrar(driver)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridTipoUnidad.ToString)

        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Nom_TipoUnidad.ToString)
        Assert.AreEqual(True, resultado)

        driver = Modulo_TipoUnidad.Eliminar(driver, Valores.Nom_TipoUnidad.ToString)

        Funciones.CerrarDriver(driver)
    End Sub

    <TestMethod()>
    Public Sub EditarTipoUnidad()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_TipoUnidad.Registrar(driver)

        driver = Modulo_TipoUnidad.Editar(driver)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridTipoUnidad.ToString)

        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Nom_TipoUnidad_Edit.ToString)
        Assert.AreEqual(True, resultado)

        driver = Modulo_TipoUnidad.Eliminar(driver, Valores.Nom_TipoUnidad_Edit.ToString)

        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub EliminarTipoUnidad()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_TipoUnidad.Registrar(driver)

        driver = Modulo_TipoUnidad.Eliminar(driver, Valores.Nom_TipoUnidad.ToString)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridTipoUnidad.ToString)

        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Nom_TipoUnidad.ToString)
        Assert.AreEqual(False, resultado)

        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub Buscar_TipoUnidad_Nombre()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_TipoUnidad.Registrar(driver)

        driver = Funciones.Buscar_Texto_Grid(driver, Valores.Filtro_Nom.ToString, Valores.Nom_TipoUnidad_Buscar.ToString)

        ListaTD = Funciones.GetListaTD(driver, Valores.ID_GridTipoUnidad.ToString)
        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, Valores.Nom_TipoUnidad.ToString)
        Assert.AreEqual(True, resultado)


        driver = Modulo_TipoUnidad.Eliminar(driver, Valores.Nom_TipoUnidad.ToString)

        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub ResetearGridTipoUnidad()

        driver = Modulo_Usuario.IniciarSesion(driver)

        driver = Modulo_TipoUnidad.Registrar(driver)

        driver = Funciones.Buscar_Texto_Grid(driver, Valores.Filtro_Nom.ToString, Valores.Nom_TipoUnidad_Buscar.ToString)
        Dim filasAntes As Integer = Funciones.Obtener_CantidadFilasGrid(driver, Valores.ID_GridTipoUnidad.ToString)

        driver = Funciones.ResetearGrid(driver)

        Dim filasDespues As Integer = Funciones.Obtener_CantidadFilasGrid(driver, Valores.ID_GridTipoUnidad.ToString)

        Assert.AreNotEqual(filasAntes, filasDespues)

        driver = Modulo_TipoUnidad.Eliminar(driver, Valores.Nom_TipoUnidad.ToString)

        Funciones.CerrarDriver(driver)

    End Sub

End Class
