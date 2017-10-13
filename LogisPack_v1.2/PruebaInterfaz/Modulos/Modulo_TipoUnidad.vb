Imports System.Threading
Imports CapaDatos
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Modulo_TipoUnidad

    Public Shared ListaTD As List(Of IWebElement)
    Public Shared viewTipoUnidad As ViewTipoUnidad = New ViewTipoUnidad()

    Public Shared Sub Crear_Obj_TipoUni1(ByRef _Tipo_Unidad As Tipo_Unidad)

        _Tipo_Unidad = New Tipo_Unidad With {
            .nombre = Valores.Nom_TipoUnidad.ToString
        }

    End Sub
    Public Shared Sub Crear_Obj_TipoUni2(ByRef _Tipo_Unidad As Tipo_Unidad)

        _Tipo_Unidad = New Tipo_Unidad With {
            .nombre = Valores.Nom_TipoUnidad_Edit.ToString
        }

    End Sub

    Public Shared Sub Registrar(ByRef driver As ChromeDriver, ByRef _Tipo_Unidad As Tipo_Unidad)

        driver.Navigate().GoToUrl(viewTipoUnidad.URL)

        Funciones.ID_Boton_Click(driver, viewTipoUnidad.BotonAddModal)

        Thread.Sleep(2000)

        Funciones.Clear_SendText_ById(driver, viewTipoUnidad.txtNombreAdd, _Tipo_Unidad.nombre)

        Funciones.ID_Boton_Click(driver, viewTipoUnidad.BotonAdd)

        Thread.Sleep(2000)

    End Sub

    Public Shared Sub Editar(ByRef driver As ChromeDriver, ByRef _Tipo_Unidad As Tipo_Unidad)

        Funciones.Obtener_FilasGrid(driver, viewTipoUnidad.GridPrinicipal, ListaTD)

        Funciones.BotonGrid_Click(ListaTD, Valores.Nom_TipoUnidad.ToString, viewTipoUnidad.BotonEditModal)

        Thread.Sleep(2000)

        Funciones.Clear_SendText_ById(driver, viewTipoUnidad.txtNombreEdit, _Tipo_Unidad.nombre)

        Funciones.ID_Boton_Click(driver, viewTipoUnidad.BotonEdit)

        Thread.Sleep(2000)

    End Sub

    Public Shared Sub Eliminar(ByRef driver As ChromeDriver, valorEliminar As String)

        driver.Navigate().GoToUrl(viewTipoUnidad.URL)

        Funciones.Obtener_FilasGrid(driver, viewTipoUnidad.GridPrinicipal, ListaTD)

        Funciones.BotonGrid_Click(ListaTD, valorEliminar, viewTipoUnidad.BotonDeleteModal)

        Thread.Sleep(2000)

        Funciones.ID_Boton_Click(driver, viewTipoUnidad.BotonDelete)

        Thread.Sleep(2000)

    End Sub

    Public Shared Sub RegistrarTipoUnidad(ByRef driver As ChromeDriver, ByRef _Tipo_Unidad As Tipo_Unidad)
        Crear_Obj_TipoUni1(_Tipo_Unidad)
        Registrar(driver, _Tipo_Unidad)
    End Sub

    Public Shared Sub Existencia_Valor_Grid(ByRef driver As ChromeDriver, ByRef _ListaTD As List(Of IWebElement),
                                            ByRef _Tipo_Unidad As Tipo_Unidad)
        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Tipo_Unidad.nombre)
    End Sub

End Class
