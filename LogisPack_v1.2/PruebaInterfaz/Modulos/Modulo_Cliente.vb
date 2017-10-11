Imports System.Threading
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Modulo_Cliente

    Public Shared Function Registrar(ByRef driver As ChromeDriver) As ChromeDriver

        driver.Navigate().GoToUrl(Valores.URLEmpresa.ToString)

        Funciones.ID_Boton_Click(driver, Valores.ID_btnAddModal.ToString)

        Thread.Sleep(2000)

        Funciones.ID_Text_Change(driver, Valores.ID_txtCodigo_Add.ToString, Valores.Cod_Empresa.ToString)

        Funciones.ID_Text_Change(driver, Valores.ID_txtNombre_Add.ToString, Valores.Nom_Empresa.ToString)

        Funciones.ID_Boton_Click(driver, Valores.ID_btnAdd.ToString)

        Thread.Sleep(2000)

        Return driver

    End Function

    Public Shared Function Editar(ByRef driver As ChromeDriver) As ChromeDriver

        Dim ListaTD As List(Of IWebElement)

        ListaTD = Funciones.Obtener_FilasGrid(driver, Valores.ID_GridEmpresa.ToString)

        Funciones.BotonGrid_Click(ListaTD, Valores.Cod_Empresa.ToString, Valores.ColBtn_Edit_Emp.ToString)

        Thread.Sleep(2000)

        Funciones.ID_Clear_Text_Change(driver, Valores.ID_txtCodigo_Edit.ToString, Valores.Cod_Empresa_Edit.ToString)

        Funciones.ID_Clear_Text_Change(driver, Valores.ID_txtNombre_Edit.ToString, Valores.Nom_Empresa_Edit.ToString)

        Funciones.ID_Boton_Click(driver, Valores.ID_btnEditModal.ToString)

        Thread.Sleep(2000)

        Return driver

    End Function

    Public Shared Function Eliminar(ByRef driver As ChromeDriver, valorEliminar As String) As ChromeDriver

        Dim ListaTD As List(Of IWebElement)

        ListaTD = Funciones.Obtener_FilasGrid(driver, Valores.ID_GridEmpresa.ToString)

        Funciones.BotonGrid_Click(ListaTD, valorEliminar, Valores.ColBtn_Elim_Emp.ToString)

        Thread.Sleep(2000)

        Funciones.ID_Boton_Click(driver, Valores.ID_btnDelete.ToString)

        Thread.Sleep(2000)

        Return driver

    End Function



End Class
