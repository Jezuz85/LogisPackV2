Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Pruebas

    Public Shared viewCliente As ViewCliente = New ViewCliente()

    Public Shared Sub Existencia_Valor_Grid(ByRef driver As ChromeDriver, ByRef ListaTD As List(Of IWebElement),
                                            ValorBuscar As String)

        Dim resultado = Funciones.Buscar_Valor_Grid(ListaTD, ValorBuscar)
        Assert.AreEqual(True, resultado)

    End Sub

    Public Shared Sub Validar_btnReset(ByRef driver As ChromeDriver)

        Dim filasAntes As Integer = Funciones.Obtener_CantidadFilasGrid(driver, viewCliente.GridPrinicipal)

        Funciones.ResetearGrid(driver)

        Dim filasDespues As Integer = Funciones.Obtener_CantidadFilasGrid(driver, viewCliente.GridPrinicipal)

        Assert.AreNotEqual(filasAntes, filasDespues)

    End Sub

    Public Shared Sub Existencia_Valor_Label(ByRef driver As ChromeDriver, idLabel As String, ValorEsperado As String)

        Dim _label As IWebElement = driver.FindElement(By.Id(idLabel))
        Assert.AreEqual(ValorEsperado, _label.Text)

    End Sub

End Class
