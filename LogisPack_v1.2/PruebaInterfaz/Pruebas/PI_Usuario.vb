Imports OpenQA.Selenium

<TestClass()>
Public Class PI_Usuario

    Dim driver As IWebDriver

    <TestMethod()>
    Public Sub Loguearse()

        driver = Modulo_Usuario.IniciarSesion(driver)

        Dim currentURL As String = driver.Url
        Assert.AreEqual(currentURL, "http://www.midemo.es/logispack/")

        Funciones.CerrarDriver(driver)

    End Sub
End Class
