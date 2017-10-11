Imports System.Threading
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Modulo_TipoUnidad

    Public Shared Function Registrar(ByRef driver As ChromeDriver) As ChromeDriver

        driver.Navigate().GoToUrl(Valores.URLTipoUnidad.ToString)

        Dim btnRegistrar As IWebElement = driver.FindElement(By.Id(Valores.ID_btnAddModal.ToString))
        btnRegistrar.Click()

        Thread.Sleep(3000)

        Funciones.ID_Clear_Text_Change(driver, Valores.ID_txtNombre.ToString, Valores.Nom_TipoUnidad.ToString)

        Funciones.ID_Boton_Click(driver, Valores.ID_btnAdd.ToString)

        Thread.Sleep(3000)

        Return driver

    End Function

    Public Shared Function Editar(ByRef driver As ChromeDriver) As ChromeDriver

        Dim ListaTD As List(Of IWebElement)

        ListaTD = Funciones.Obtener_FilasGrid(driver, Valores.ID_GridTipoFact.ToString)

        Funciones.BotonGrid_Click(ListaTD, Valores.Nom_TipoUnidad.ToString, Valores.ColBtn_Edit_TipoUnidad.ToString)

        Thread.Sleep(2000)

        Funciones.ID_Clear_Text_Change(driver, Valores.ID_txtNombre_Edit.ToString, Valores.Nom_TipoUnidad_Edit.ToString)

        Funciones.ID_Boton_Click(driver, Valores.ID_btnEditModal.ToString)

        Thread.Sleep(2000)

        Return driver

    End Function

    Public Shared Function Eliminar(ByRef driver As ChromeDriver, valorEliminar As String) As ChromeDriver

        Dim ListaTD As List(Of IWebElement)

        ListaTD = Funciones.Obtener_FilasGrid(driver, Valores.ID_GridTipoUnidad.ToString)

        Funciones.BotonGrid_Click(ListaTD, valorEliminar, Valores.ColBtn_Elim_TipoUnidad.ToString)

        Thread.Sleep(2000)

        Funciones.ID_Boton_Click(driver, Valores.ID_btnDelete.ToString)

        Thread.Sleep(2000)

        Return driver

    End Function

End Class
