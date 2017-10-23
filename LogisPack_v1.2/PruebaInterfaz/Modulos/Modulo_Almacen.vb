Imports System.Threading
Imports CapaDatos
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Modulo_Almacen

    Public Shared ListaTD As List(Of IWebElement)
    Public Shared viewAlmacen As ViewAlmacen = New ViewAlmacen()

    ''' <summary>
    ''' Método que recibe un objeto almacen y le agrega los datos especificos para la prueba
    ''' </summary>
    Public Shared Sub Crear_Obj_Almacen1(ByRef _Almacen As Almacen)

        _Almacen = New Almacen With {
            .codigo = Valores.Cod_Almacen.ToString,
            .nombre = Valores.Nom_Almacen.ToString,
            .coeficiente_volumetrico = Valores.CoefVol_Almacen.ToString
        }

    End Sub

    ''' <summary>
    ''' Método que recibe un objeto almacen y le agrega los datos especificos para la prueba
    ''' </summary>
    Public Shared Sub Crear_Obj_Almacen2(ByRef _Almacen As Almacen)

        _Almacen = New Almacen With {
            .codigo = Valores.Cod_Almacen_Edit.ToString,
            .nombre = Valores.Nom_Almacen_Edit.ToString,
            .coeficiente_volumetrico = Valores.CoefVol_Almacen_Edit.ToString
        }

    End Sub

    ''' <summary>
    ''' Método que realiza el registro de un almacen en la aplicacion
    ''' </summary>
    Public Shared Sub Registrar(ByRef driver As ChromeDriver, ByRef _Almacen As Almacen, ByRef _Cliente As Cliente)

        driver.Navigate().GoToUrl(viewAlmacen.URL)

        Funciones.ID_Boton_Click(driver, viewAlmacen.BotonAddModal)

        Thread.Sleep(2000)

        Funciones.SendText_ById(driver, viewAlmacen.txtcodigoAdd, _Almacen.codigo)
        Funciones.SendText_ById(driver, viewAlmacen.txtNombreAdd, _Almacen.nombre)
        Funciones.SendText_ById(driver, viewAlmacen.txtCoefVolAdd, _Almacen.coeficiente_volumetrico)
        Funciones.ID_DropDownList_SelectedValue(driver, viewAlmacen.ddlClienteAdd, _Cliente.nombre)

        Funciones.ID_Boton_Click(driver, viewAlmacen.BotonAdd)

        Thread.Sleep(2000)

    End Sub

    ''' <summary>
    ''' Método que realiza la actualizacion de un almacen en la aplicacion
    ''' </summary>
    Public Shared Sub Editar(ByRef driver As ChromeDriver, ByRef _Almacen1 As Almacen, ByRef _Almacen2 As Almacen,
                             ByRef _Cliente As Cliente)

        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)
        Funciones.BotonGrid_Click(ListaTD, _Almacen1.codigo, viewAlmacen.BotonEditModal)

        Thread.Sleep(2000)

        Funciones.Clear_SendText_ById(driver, viewAlmacen.txtcodigoEdit, _Almacen2.codigo)
        Funciones.Clear_SendText_ById(driver, viewAlmacen.txtNombreEdit, _Almacen2.nombre)
        Funciones.Clear_SendText_ById(driver, viewAlmacen.txtCoefVolEdit, _Almacen2.coeficiente_volumetrico)
        Funciones.ID_DropDownList_SelectedValue(driver, viewAlmacen.ddlClienteEdit, _Cliente.nombre)

        Funciones.ID_Boton_Click(driver, viewAlmacen.BotonEdit)

        Thread.Sleep(2000)

    End Sub

    ''' <summary>
    ''' Método que realiza la eliminación de un almacen en la aplicacion
    ''' </summary>
    Public Shared Sub Eliminar(ByRef driver As ChromeDriver, valorEliminar As String)

        driver.Navigate().GoToUrl(viewAlmacen.URL)

        Funciones.Obtener_FilasGrid(driver, viewAlmacen.GridPrinicipal, ListaTD)

        Funciones.BotonGrid_Click(ListaTD, valorEliminar, viewAlmacen.BotonDeleteModal)

        Thread.Sleep(2000)

        Funciones.ID_Boton_Click(driver, viewAlmacen.BotonDelete)

        Thread.Sleep(2000)

    End Sub

    ''' <summary>
    ''' Método que crea un objeto almacen e invoca el metodo de registrar
    ''' </summary>
    Public Shared Sub RegistrarAlmacen(ByRef driver As ChromeDriver, ByRef _Almacen As Almacen, ByRef _Cliente As Cliente)
        Crear_Obj_Almacen1(_Almacen)
        Registrar(driver, _Almacen, _Cliente)
    End Sub

    ''' <summary>
    ''' Método que valida la existencia de valores en la lista que contiene los elementos de un grid
    ''' </summary>
    Public Shared Sub Existencia_Valor_Grid(ByRef driver As ChromeDriver, ByRef _ListaTD As List(Of IWebElement), ByRef _Almacen As Almacen)
        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Almacen.codigo)
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Almacen.nombre)
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Almacen.coeficiente_volumetrico)
    End Sub


End Class
