Imports OpenQA.Selenium

<TestClass()>
Public Class PI_Usuario

    Dim driver As IWebDriver

    ''' <summary>
    ''' Prueba que se ejecuta para valdiar el inisio de sesión
    ''' </summary>
    <TestMethod()>
    Public Sub Loguearse()

        Modulo_Usuario.IniciarSesion(driver)

        Dim currentURL As String = driver.Url
        Assert.AreEqual(currentURL, "http://www.midemo.es/logispack/")

        Funciones.CerrarDriver(driver)

    End Sub
End Class
