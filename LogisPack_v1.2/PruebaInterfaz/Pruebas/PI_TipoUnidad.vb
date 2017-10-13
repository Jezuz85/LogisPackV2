Imports OpenQA.Selenium
Imports CapaDatos

<TestClass()>
Public Class PI_TipoUnidad

    Dim driver As IWebDriver
    Dim ListaTD As List(Of IWebElement)
    Dim _TipoUni1 As Tipo_Unidad
    Dim _TipoUni2 As Tipo_Unidad
    Dim viewTipoUnidad As ViewTipoUnidad = New ViewTipoUnidad()

    <TestMethod()>
    Public Sub Registrar_TipoUnidad()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de unidad
        Modulo_TipoUnidad.RegistrarTipoUnidad(driver, _TipoUni1)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoUnidad.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, ListaTD, _TipoUni1.nombre)

        '------elimino el tipo de unidad
        Modulo_TipoUnidad.Eliminar(driver, _TipoUni1.nombre)

        '------cierro el driver
        Funciones.CerrarDriver(driver)
    End Sub

    <TestMethod()>
    Public Sub Editar_TipoUnidad()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de unidad
        Modulo_TipoUnidad.RegistrarTipoUnidad(driver, _TipoUni1)

        '------edito un tipo de unidad
        Modulo_TipoUnidad.Crear_Obj_TipoUni2(_TipoUni2)
        Modulo_TipoUnidad.Editar(driver, _TipoUni2)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoUnidad.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, ListaTD, _TipoUni2.nombre)

        '------elimino el tipo de unidad
        Modulo_TipoUnidad.Eliminar(driver, _TipoUni2.nombre)

        '------cierro el driver
        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub Eliminar_TipoUnidad()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de unidad
        Modulo_TipoUnidad.RegistrarTipoUnidad(driver, _TipoUni1)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoUnidad.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, ListaTD, _TipoUni1.nombre)

        '------elimino el tipo de unidad
        Modulo_TipoUnidad.Eliminar(driver, _TipoUni1.nombre)

        '------cierro el driver
        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub Buscar_TipoUnidad_Nombre()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de unidad
        Modulo_TipoUnidad.RegistrarTipoUnidad(driver, _TipoUni1)

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewTipoUnidad.Filtro_Nom, Valores.Nom_TipoUnidad_Buscar.ToString)

        '------obtengo los valores del grid
        Funciones.Obtener_FilasGrid(driver, viewTipoUnidad.GridPrinicipal, ListaTD)

        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, ListaTD, Valores.Nom_TipoUnidad.ToString)

        '------elimino el tipo de unidad
        Modulo_TipoUnidad.Eliminar(driver, _TipoUni1.nombre)

        '------cierro el driver
        Funciones.CerrarDriver(driver)

    End Sub

    <TestMethod()>
    Public Sub ResetearGridTipoUnidad()

        '------inicio sesion
        Modulo_Usuario.IniciarSesion(driver)

        '------registro un tipo de unidad
        Modulo_TipoUnidad.RegistrarTipoUnidad(driver, _TipoUni1)

        '-----Opcion Buscar
        Funciones.Buscar_Texto_Grid(driver, viewTipoUnidad.Filtro_Nom, Valores.Nom_TipoUnidad_Buscar.ToString)

        '-----valdia que el boton reset funciona
        Pruebas.Validar_btnReset(driver)

        '------elimino el tipo de unidad
        Modulo_TipoUnidad.Eliminar(driver, _TipoUni1.nombre)

        '------cierro el driver
        Funciones.CerrarDriver(driver)

    End Sub

End Class
