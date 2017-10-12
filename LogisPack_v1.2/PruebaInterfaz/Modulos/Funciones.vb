Imports System.Threading
Imports CapaDatos
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Funciones

    Public Shared viewCliente As ViewCliente = New ViewCliente()

    Public Shared Sub CerrarDriver(ByRef driver As ChromeDriver)
        driver.Close()
    End Sub

    Public Shared Function Obtener_CantidadFilasGrid(ByRef driver As ChromeDriver, idGrid As String) As Integer

        Dim GridView1 As IWebElement = driver.FindElement(By.Id(idGrid))
        Dim cantidadFilas As List(Of IWebElement) = GridView1.FindElements(By.TagName("tr")).ToList()

        Return cantidadFilas.Count - 1

    End Function

    Public Shared Sub Obtener_FilasGrid(ByRef driver As ChromeDriver, idGrid As String, ByRef ListaTD As List(Of IWebElement))

        Dim GridView1 As IWebElement = driver.FindElement(By.Id(idGrid))
        ListaTD = GridView1.FindElements(By.TagName("tr")).ToList()

    End Sub

    Public Shared Function Buscar_Valor_Grid(ByRef _ListaTR As List(Of IWebElement), valorBuscar As String) As Boolean

        For Each itemTR As IWebElement In _ListaTR

            Dim listatd As List(Of IWebElement) = itemTR.FindElements(By.TagName("td")).ToList()

            For Each itemTD In listatd

                If itemTD.Text = valorBuscar Then
                    Return True
                End If

            Next

        Next

        Return False

    End Function

    Public Shared Function Buscar_Boton_Grid(_ListaTR As List(Of IWebElement), valorBuscar As String, posicionBoton As Integer) As IWebElement

        For Each itemTR As IWebElement In _ListaTR

            Dim listatd As List(Of IWebElement) = itemTR.FindElements(By.TagName("td")).ToList()

            Dim contador = 1
            Dim bandera = False

            For Each itemTD In listatd

                If itemTD.Text = valorBuscar Then
                    bandera = True
                End If

                If bandera Then
                    contador += 1
                End If

                If contador = posicionBoton Then
                    Dim _Buttonfield As IWebElement = itemTD.FindElement(By.TagName("input"))

                    Return _Buttonfield
                End If


            Next

        Next

        Return Nothing

    End Function

    Public Shared Sub ID_Boton_Click(ByRef driver As ChromeDriver, idBoton As String)
        Dim _boton As IWebElement = driver.FindElement(By.Id(idBoton))
        _boton.Click()
    End Sub

    Public Shared Sub BotonGrid_Click(ListaTD As List(Of IWebElement), ValorColumna As String, valorcolumnaBoton As String)

        Dim _valorcolumnaBoton As Integer = Convert.ToInt32(valorcolumnaBoton)
        Dim _boton As IWebElement = Funciones.Buscar_Boton_Grid(ListaTD, ValorColumna, _valorcolumnaBoton)
        _boton.Click()

    End Sub

    Public Shared Sub SendText_ById(ByRef driver As ChromeDriver, idTextbox As String, valorIngresar As String)
        Dim _TextBox As IWebElement = driver.FindElement(By.Id(idTextbox))
        _TextBox.SendKeys(valorIngresar)
    End Sub

    Public Shared Sub Clear_SendText_ById(ByRef driver As ChromeDriver, idTextbox As String, valorIngresar As String)
        Dim _TextBox As IWebElement = driver.FindElement(By.Id(idTextbox))
        _TextBox.Clear()
        _TextBox.SendKeys(valorIngresar)
    End Sub

    Public Shared Sub ID_DropDownList_SelectedValue(ByRef driver As ChromeDriver, idDropDownlist As String, filtro As String)
        Dim _DropDownlist As IWebElement = driver.FindElement(By.Id(idDropDownlist)).FindElement(By.XPath(".//option[contains(text(),'" & filtro & "')]"))
        _DropDownlist.Click()
    End Sub

    Public Shared Sub Buscar_Texto_Grid(ByRef driver As ChromeDriver, filtro As String, ValorBuscar As String)

        Funciones.ID_DropDownList_SelectedValue(driver, viewCliente.ddlFiltroBuscar, filtro)

        Funciones.SendText_ById(driver, viewCliente.txtSearch, ValorBuscar)

        Funciones.ID_Boton_Click(driver, viewCliente.BotonBuscar)

        Thread.Sleep(2000)

    End Sub

    Public Shared Sub ResetearGrid(ByRef driver As ChromeDriver)

        Funciones.ID_Boton_Click(driver, viewCliente.BotonReset)

        Thread.Sleep(2000)

    End Sub

    Public Shared Sub CerrarPrueba(ByRef driver As ChromeDriver, ByRef _Cliente As Cliente)

        '------elimino el cliente
        Modulo_Cliente.Eliminar(driver, _Cliente.codigo)

        '------cierro el driver
        CerrarDriver(driver)
    End Sub

End Class
