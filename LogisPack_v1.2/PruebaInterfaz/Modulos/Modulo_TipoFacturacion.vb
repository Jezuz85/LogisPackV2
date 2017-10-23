Imports System.Threading
Imports CapaDatos
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Modulo_TipoFacturacion

    Public Shared ListaTD As List(Of IWebElement)
    Public Shared viewTipoFacturacion As ViewTipoFacturacion = New ViewTipoFacturacion()

    ''' <summary>
    ''' Método que recibe un objeto Tipo Facturacion y le agrega los datos especificos para la prueba
    ''' </summary>
    Public Shared Sub Crear_Obj_TipoFact1(ByRef _Tipo_Facturacion As Tipo_Facturacion)

        _Tipo_Facturacion = New Tipo_Facturacion With {
            .nombre = Valores.Nom_TipoFact.ToString
        }

    End Sub

    ''' <summary>
    ''' Método que recibe un objeto Tipo Facturacion y le agrega los datos especificos para la prueba
    ''' </summary>
    Public Shared Sub Crear_Obj_TipoFact2(ByRef _Tipo_Facturacion As Tipo_Facturacion)

        _Tipo_Facturacion = New Tipo_Facturacion With {
            .nombre = Valores.Nom_TipoFact_Edit.ToString
        }

    End Sub

    ''' <summary>
    ''' Método que realiza el registro de un Tipo Facturacion en la aplicacion
    ''' </summary>
    Public Shared Sub Registrar(ByRef driver As ChromeDriver, ByRef _Tipo_Facturacion As Tipo_Facturacion)

        driver.Navigate().GoToUrl(viewTipoFacturacion.URL)

        Funciones.ID_Boton_Click(driver, viewTipoFacturacion.BotonAddModal)

        Thread.Sleep(2000)

        Funciones.Clear_SendText_ById(driver, viewTipoFacturacion.txtNombreAdd, _Tipo_Facturacion.nombre)

        Funciones.ID_Boton_Click(driver, viewTipoFacturacion.BotonAdd)

        Thread.Sleep(2000)

    End Sub

    ''' <summary>
    ''' Método que realiza la actualizacion de un Tipo Facturacion en la aplicacion
    ''' </summary>
    Public Shared Sub Editar(ByRef driver As ChromeDriver, ByRef _Tipo_Facturacion As Tipo_Facturacion)

        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        Funciones.BotonGrid_Click(ListaTD, Valores.Nom_TipoFact.ToString, viewTipoFacturacion.BotonEditModal)

        Thread.Sleep(2000)

        Funciones.Clear_SendText_ById(driver, viewTipoFacturacion.txtNombreEdit, _Tipo_Facturacion.nombre)

        Funciones.ID_Boton_Click(driver, viewTipoFacturacion.BotonEdit)

        Thread.Sleep(2000)

    End Sub

    ''' <summary>
    ''' Método que realiza la eliminación de un Tipo Facturacion en la aplicacion
    ''' </summary>
    Public Shared Sub Eliminar(ByRef driver As ChromeDriver, valorEliminar As String)

        driver.Navigate().GoToUrl(viewTipoFacturacion.URL)

        Funciones.Obtener_FilasGrid(driver, viewTipoFacturacion.GridPrinicipal, ListaTD)

        Funciones.BotonGrid_Click(ListaTD, valorEliminar, viewTipoFacturacion.BotonDeleteModal)

        Thread.Sleep(2000)

        Funciones.ID_Boton_Click(driver, viewTipoFacturacion.BotonDelete)

        Thread.Sleep(2000)

    End Sub

    ''' <summary>
    ''' Método que crea un objeto Tipo Facturacion e invoca el metodo de registrar
    ''' </summary>
    Public Shared Sub RegistrarTipoFacturacion(ByRef driver As ChromeDriver, ByRef _Tipo_Facturacion As Tipo_Facturacion)
        Crear_Obj_TipoFact1(_Tipo_Facturacion)
        Registrar(driver, _Tipo_Facturacion)
    End Sub

    ''' <summary>
    ''' Método que valida la existencia de valores en la lista que contiene los elementos de un grid
    ''' </summary>
    Public Shared Sub Existencia_Valor_Grid(ByRef driver As ChromeDriver, ByRef _ListaTD As List(Of IWebElement),
                                            ByRef _Tipo_Facturacion As Tipo_Facturacion)
        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Tipo_Facturacion.nombre)
    End Sub

End Class
