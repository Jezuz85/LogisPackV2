﻿Imports System.Web.UI.WebControls
Imports CapaDatos

<TestClass()> Public Class Test_Articulo

    Dim _ArticuloTest As Articulo
    Dim _AlmacenTest As Almacen
    Dim _Tipo_FacturacionTest As Tipo_Facturacion
    Dim _Tipo_UnidadTest As Tipo_Unidad
    Dim _ClienteTest As Cliente
    Dim _DropDownlistTest As DropDownList
    Dim _TextBox As TextBox

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        _ClienteTest = Mgr_Cliente_Test.Get_Cliente1()
        _Tipo_FacturacionTest = Mgr_TipoFacturacion_Test.Get_TipoFacturacion1()
        _Tipo_UnidadTest = Mgr_TipoUnidad_Test.Get_Tipo_Unidad1()

        Mgr_Articulo_Test.Inicializar(_ArticuloTest, _AlmacenTest, _Tipo_FacturacionTest, _Tipo_UnidadTest, _ClienteTest)

    End Sub

    ''' <summary>
    ''' Método que se invoca para finalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()
        Mgr_Articulo_Test.Finalizar(_Tipo_FacturacionTest, _Tipo_UnidadTest, _ClienteTest)
    End Sub

    ''' <summary>
    ''' Método que se ejecuta para registrar un articulo
    ''' </summary>
    <TestMethod()> Public Sub Registrar_Articulo()

        Dim _ArticuloBD = Mgr_Articulo.Get_Articulo(_ArticuloTest.id_articulo)

        Assert.AreEqual(_ArticuloBD.id_articulo, _ArticuloTest.id_articulo)
        Assert.AreEqual(_ArticuloBD.nombre, _ArticuloTest.nombre)
        Assert.AreEqual(_ArticuloBD.codigo, _ArticuloTest.codigo)

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para editar un articulo
    ''' </summary>
    <TestMethod()> Public Sub Editar_Articulo()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _ArticuloBD = Mgr_Articulo.Get_Articulo(_ArticuloTest.id_articulo, contexto)

        _ArticuloBD.codigo = "_Cod1"
        _ArticuloBD.nombre = "_ArtPrueba"

        Mgr_Articulo.Editar(_ArticuloTest, contexto)

        Assert.AreEqual(_ArticuloBD.id_articulo, _ArticuloTest.id_articulo)
        Assert.AreNotEqual(_ArticuloBD.nombre, _ArticuloTest.nombre)
        Assert.AreNotEqual(_ArticuloBD.codigo, _ArticuloTest.codigo)


    End Sub

    ''' <summary>
    ''' Método que se ejecuta para eliminar un articulo
    ''' </summary>
    <TestMethod()> Public Sub Eliminar_Articulo()

        Mgr_Articulo.Eliminar(_ArticuloTest.id_articulo)
        Dim _ArticuloBD = Mgr_Articulo.Get_Articulo(_ArticuloTest.id_articulo)

        Assert.AreEqual(_ArticuloBD, Nothing)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en Articulo normal, con filtro de nombre
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_ArticuloByNombre()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteArticulo("ArtPrueb", Val_Articulo.Filtro_Nombre.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en Articulo normal, con filtro de codigo
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_ArticuloByCodigo()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteArticulo("CodArt", Val_Articulo.Filtro_Codigo.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en Articulo normal, con filtro de almacen
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_ArticuloByAlmacen()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteArticulo("Nombrev", Val_Articulo.Filtro_Almacen.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en Articulo normal, con filtro de Cliente
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_ArticuloByCliente()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteArticulo("Nombrev", Val_Articulo.Filtro_Cliente.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Método que se ejecuta para consulta de un articulo
    ''' </summary>
    <TestMethod()> Public Sub Get_Articulo()

        Dim _ArticuloBD = Mgr_Articulo.Get_Articulo(_ArticuloTest.id_articulo)

        Assert.AreEqual(_ArticuloBD.id_articulo, _ArticuloTest.id_articulo)
        Assert.AreEqual(_ArticuloBD.nombre, _ArticuloTest.nombre)
        Assert.AreEqual(_ArticuloBD.codigo, _ArticuloTest.codigo)

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para consulta del ultimo articulo
    ''' </summary>
    <TestMethod()> Public Sub Get_Articulo_Ultimo()

        Dim _ArticuloBD = Mgr_Articulo.Get_Articulo_Ultimo()

        Assert.AreEqual(_ArticuloBD.id_articulo, _ArticuloTest.id_articulo)
        Assert.AreEqual(_ArticuloBD.nombre, _ArticuloTest.nombre)
        Assert.AreEqual(_ArticuloBD.codigo, _ArticuloTest.codigo)

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para consulta de un articulo por el codigo
    ''' </summary>
    <TestMethod()> Public Sub Get_ArticuloByCodigo()

        Dim _ArticuloBD = Mgr_Articulo.Get_ArticuloByCodigo(_ArticuloTest.codigo)

        Assert.AreEqual(_ArticuloBD.id_articulo, _ArticuloTest.id_articulo)
        Assert.AreEqual(_ArticuloBD.nombre, _ArticuloTest.nombre)
        Assert.AreEqual(_ArticuloBD.codigo, _ArticuloTest.codigo)

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para consultar la lista de Articulos de tipo normal y dependiendo del id almacen 
    ''' </summary>
    <TestMethod()> Public Sub Llenar_ListaByAlmacen_ArticuloNormal()

        _DropDownlistTest = New DropDownList()
        Mgr_Articulo.Llenar_ListaByAlmacen_ArticuloNormal(_DropDownlistTest, _AlmacenTest.id_almacen)

        Assert.AreNotEqual(_DropDownlistTest.Items.Count(), 0)

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para consultar la lista de Articulos dependiendo del id almacen 
    ''' </summary>
    <TestMethod()> Public Sub Llenar_ListaByAlmacen()

        _DropDownlistTest = New DropDownList()
        Mgr_Articulo.Llenar_ListaByAlmacen(_DropDownlistTest, _AlmacenTest.id_almacen)

        Assert.AreNotEqual(_DropDownlistTest.Items.Count(), 0)

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para consultar el coeficiente volumetrico de un articulo y agregarlo a un textbox 
    ''' </summary>
    <TestMethod()> Public Sub CargarCoefVol()

        _TextBox = New TextBox()
        Mgr_Articulo.CargarCoefVol(_AlmacenTest.id_almacen, _TextBox)

        Assert.AreEqual(_TextBox.Text, _AlmacenTest.coeficiente_volumetrico.ToString().Replace(",", "."))

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para validar el llenado de ceros en los campos de ubicacion
    ''' </summary>
    <TestMethod()> Public Sub LlenarCeros()

        Dim ValorActual = Mgr_Articulo.LlenarCeros("a")
        Assert.AreEqual("000a", ValorActual)

        ValorActual = Mgr_Articulo.LlenarCeros("aa")
        Assert.AreEqual("00aa", ValorActual)

        ValorActual = Mgr_Articulo.LlenarCeros("aaa")
        Assert.AreEqual("0aaa", ValorActual)

        ValorActual = Mgr_Articulo.LlenarCeros("aaaa")
        Assert.AreEqual("aaaa", ValorActual)
    End Sub

End Class