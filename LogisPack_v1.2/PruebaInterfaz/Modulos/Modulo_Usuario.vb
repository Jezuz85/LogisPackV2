Imports System.Threading
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Modulo_Usuario

    ''' <summary>
    ''' Método que realiza la operacion de iniciar sesion en el sistema
    ''' </summary>
    Public Shared Sub IniciarSesion(ByRef driver As ChromeDriver)

        driver = New ChromeDriver()

        driver.Navigate().GoToUrl("http://www.midemo.es/logispack/Account/Login")
        driver.Manage().Window.Maximize()

        Dim inputCorreo As IWebElement = driver.FindElement(By.Id("MainContent_Email"))
        inputCorreo.SendKeys("Admin@direcline.com")
        Dim inputPassword As IWebElement = driver.FindElement(By.Id("MainContent_Password"))
        inputPassword.SendKeys("#Direcline1234")

        Dim btnRegistrar As IWebElement = driver.FindElement(By.Name("ctl00$MainContent$ctl05"))
        btnRegistrar.Click()

        Thread.Sleep(2000)
    End Sub

End Class
