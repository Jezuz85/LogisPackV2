Imports System.Threading
Imports CapaDatos
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Modulo_TipoFacturacion

    Public Shared ListaTD As List(Of IWebElement)
    Public Shared viewTipoFacturacion As ViewTipoFacturacion = New ViewTipoFacturacion()

    Public Shared Sub Crear_TipoFact1(ByRef _Tipo_Facturacion As Tipo_Facturacion)

        _Tipo_Facturacion = New Tipo_Facturacion With {
            .nombre = Valores.Nom_TipoFact.ToString
        }

    End Sub
    Public Shared Sub Crear_TipoFact2(ByRef _Tipo_Facturacion As Tipo_Facturacion)

        _Tipo_Facturacion = New Tipo_Facturacion With {
            .nombre = Valores.Nom_TipoFact_Edit.ToString
        }

    End Sub

    Public Shared Sub Registrar(ByRef driver As ChromeDriver, ByRef _Tipo_Facturacion As Tipo_Facturacion)

        driver.Navigate().GoToUrl(viewTipoFacturacion.URL)

        Funciones.ID_Boton_Click(driver, viewTipoFacturacion.BotonAddModal)

        Thread.Sleep(2000)

        Funciones.Clear_SendText_ById(driver, viewTipoFacturacion.txtNombreAdd, _Tipo_Facturacion.nombre)

        Funciones.ID_Boton_Click(driver, viewTipoFacturacion.BotonAdd)

        Thread.Sleep(2000)

    End Sub

    Public Shared Sub Editar(ByRef driver As ChromeDriver, ByRef _Tipo_Facturacion As Tipo_Facturacion)

        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        Funciones.BotonGrid_Click(ListaTD, Valores.Nom_TipoFact.ToString, viewTipoFacturacion.BotonEditModal)

        Thread.Sleep(2000)

        Funciones.Clear_SendText_ById(driver, viewTipoFacturacion.txtNombreEdit, _Tipo_Facturacion.nombre)

        Funciones.ID_Boton_Click(driver, viewTipoFacturacion.BotonEdit)

        Thread.Sleep(2000)

    End Sub

    Public Shared Sub Eliminar(ByRef driver As ChromeDriver, valorEliminar As String)

        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        Funciones.BotonGrid_Click(ListaTD, valorEliminar, viewTipoFacturacion.BotonDeleteModal)

        Thread.Sleep(2000)

        Funciones.ID_Boton_Click(driver, viewTipoFacturacion.BotonDelete)

        Thread.Sleep(2000)

    End Sub

    Public Shared Sub RegistrarTipoFacturacion(ByRef driver As ChromeDriver, ByRef _Tipo_Facturacion As Tipo_Facturacion)
        Crear_TipoFact1(_Tipo_Facturacion)
        Registrar(driver, _Tipo_Facturacion)
    End Sub

    Public Shared Sub Existencia_Valor_Grid(ByRef driver As ChromeDriver, ByRef _ListaTD As List(Of IWebElement),
                                            ByRef _Tipo_Facturacion As Tipo_Facturacion)
        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Tipo_Facturacion.nombre)
    End Sub

End Class
