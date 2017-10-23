Imports System.Threading
Imports CapaDatos
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Modulo_Cliente

    Public Shared ListaTD As List(Of IWebElement)
    Public Shared viewCliente As ViewCliente = New ViewCliente()

    ''' <summary>
    ''' Método que recibe un objeto cliente y le agrega los datos especificos para la prueba
    ''' </summary>
    Public Shared Sub Crear_Obj_Cliente1(ByRef _Cliente As Cliente)

        _Cliente = New Cliente With {
            .codigo = Valores.Cod_Cliente.ToString,
            .nombre = Valores.Nom_Cliente.ToString
        }

    End Sub

    ''' <summary>
    ''' Método que recibe un objeto cliente y le agrega los datos especificos para la prueba
    ''' </summary>
    Public Shared Sub Crear_Obj_Cliente2(ByRef _Cliente As Cliente)

        _Cliente = New Cliente With {
            .codigo = Valores.Cod_Cliente_Edit.ToString,
            .nombre = Valores.Nom_Cliente_Edit.ToString
        }

    End Sub

    ''' <summary>
    ''' Método que realiza el registro de un cliente en la aplicacion
    ''' </summary>
    Public Shared Sub Registrar(ByRef driver As ChromeDriver, ByRef _Cliente As Cliente)

        driver.Navigate().GoToUrl(viewCliente.URL)

        Funciones.ID_Boton_Click(driver, viewCliente.BotonAddModal.ToString)

        Thread.Sleep(2000)

        Funciones.SendText_ById(driver, viewCliente.txtCodigoAdd, _Cliente.codigo)
        Funciones.SendText_ById(driver, viewCliente.txtNombreAdd, _Cliente.nombre)

        Funciones.ID_Boton_Click(driver, viewCliente.BotonAdd)

        Thread.Sleep(2000)

    End Sub

    ''' <summary>
    ''' Método que realiza la actualizacion de un cliente en la aplicacion
    ''' </summary>
    Public Shared Sub Editar(ByRef driver As ChromeDriver, ByRef _Cliente1 As Cliente, ByRef _Cliente2 As Cliente)

        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        Funciones.BotonGrid_Click(ListaTD, _Cliente1.codigo, viewCliente.BotonEditModal)

        Thread.Sleep(2000)

        Funciones.Clear_SendText_ById(driver, viewCliente.txtcodigoEdit, _Cliente2.codigo)
        Funciones.Clear_SendText_ById(driver, viewCliente.txtNombreEdit, _Cliente2.nombre)

        Funciones.ID_Boton_Click(driver, viewCliente.BotonEdit)

        Thread.Sleep(2000)

    End Sub

    ''' <summary>
    ''' Método que realiza la eliminación de un cliente en la aplicacion
    ''' </summary>
    Public Shared Sub Eliminar(ByRef driver As ChromeDriver, valorEliminar As String)

        driver.Navigate().GoToUrl(viewCliente.URL)

        Funciones.Obtener_FilasGrid(driver, viewCliente.GridPrinicipal, ListaTD)

        Funciones.BotonGrid_Click(ListaTD, valorEliminar, viewCliente.BotonDeleteModal)

        Thread.Sleep(2000)

        Funciones.ID_Boton_Click(driver, viewCliente.BotonDelete)

        Thread.Sleep(2000)

    End Sub

    ''' <summary>
    ''' Método que crea un objeto cliente e invoca el metodo de registrar
    ''' </summary>
    Public Shared Sub RegistrarCliente(ByRef driver As ChromeDriver, ByRef _Cliente As Cliente)
        Crear_Obj_Cliente1(_Cliente)
        Registrar(driver, _Cliente)
    End Sub

    ''' <summary>
    ''' Método que valida la existencia de valores en la lista que contiene los elementos de un grid
    ''' </summary>
    Public Shared Sub Existencia_Valor_Grid(ByRef driver As ChromeDriver, ByRef _ListaTD As List(Of IWebElement),
                                            ByRef _Cliente As Cliente)

        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Cliente.codigo)
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Cliente.nombre)
    End Sub

End Class
