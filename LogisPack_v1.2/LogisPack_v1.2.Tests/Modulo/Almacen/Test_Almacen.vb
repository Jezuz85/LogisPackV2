Imports System.Web.UI.WebControls
Imports CapaDatos

<TestClass()> Public Class Test_Almacen

    Dim _ClienteTest1 As Cliente
    Dim _AlmacenTest As Almacen
    Dim _DropDownlistTest As DropDownList
    Dim _GridViewTest As GridView

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        _ClienteTest1 = Mgr_Cliente_Test.Get_Cliente1()
        Mgr_Almacen_Test.Inicializar(_ClienteTest1, _AlmacenTest)

    End Sub

    ''' <summary>
    ''' Método que se invoca para finalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()
        Mgr_Cliente_Test.Finalizar(_ClienteTest1)
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para registrar un almacen
    ''' </summary>
    <TestMethod()> Public Sub Registrar_Almacen()

        Dim AlmacenBd = Mgr_Almacen.Get_Almacen(_AlmacenTest.id_almacen)

        Assert.AreEqual(AlmacenBd.id_almacen, _AlmacenTest.id_almacen)
        Assert.AreEqual(AlmacenBd.id_cliente, _AlmacenTest.id_cliente)
        Assert.AreEqual(AlmacenBd.nombre, _AlmacenTest.nombre)
        Assert.AreEqual(AlmacenBd.codigo, _AlmacenTest.codigo)
        Assert.AreEqual(AlmacenBd.coeficiente_volumetrico, _AlmacenTest.coeficiente_volumetrico)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para editar un almacen
    ''' </summary>
    <TestMethod()> Public Sub Editar_Almacen()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim AlmacenBD = Mgr_Almacen.Get_Almacen(_AlmacenTest.id_almacen, contexto)

        AlmacenBD.codigo = "Codv2"
        AlmacenBD.nombre = "Nombrev2"
        AlmacenBD.coeficiente_volumetrico = "20"

        Mgr_Almacen.Editar(_AlmacenTest, contexto)

        Assert.AreEqual(AlmacenBD.id_almacen, _AlmacenTest.id_almacen)
        Assert.AreNotEqual(AlmacenBD.nombre, _AlmacenTest.nombre)
        Assert.AreNotEqual(AlmacenBD.codigo, _AlmacenTest.codigo)
        Assert.AreNotEqual(AlmacenBD.coeficiente_volumetrico, _AlmacenTest.coeficiente_volumetrico)


    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para eliminar un almacen
    ''' </summary>
    <TestMethod()> Public Sub Eliminar_Almacen()

        Mgr_Almacen.Eliminar(_AlmacenTest.id_almacen)
        Dim AlmacenBD = Mgr_Almacen.Get_Almacen(_AlmacenTest.id_almacen)

        Assert.AreEqual(AlmacenBD, Nothing)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en almacen, con filtro de Codigo
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_AlmacenByCodigo()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteAlmacen("Codv", Val_Almacen.Filtro_Codigo.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en almacen, con filtro de nombre
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_AlmacenByNombre()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteAlmacen("Nombrev", Val_Almacen.Filtro_Nombre.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en almacen, con filtro de coeficiente
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_AlmacenByCoeficienteVolumetrico()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteAlmacen("123", Val_Almacen.Filtro_Coeficiente.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en almacen, con filtro de cliente
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_AlmacenByCliente()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteAlmacen("Nombrev", Val_Almacen.Filtro_Cliente.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para devolver el grid de almacenes
    ''' </summary>
    <TestMethod()> Public Sub Llenar_Grid()

        _GridViewTest = New GridView()

        Mgr_Almacen.Llenar_Grid(_GridViewTest, 1, String.Empty, String.Empty, String.Empty, String.Empty)

        Assert.AreNotEqual(_GridViewTest.Rows.Count(), 0)
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para devolver la lista de almacenes en la bd
    ''' </summary>
    <TestMethod()> Public Sub Llenar_Lista()

        _DropDownlistTest = New DropDownList()

        Mgr_Almacen.Llenar_Lista(_DropDownlistTest)

        Assert.AreNotEqual(_DropDownlistTest.Items.Count(), 0)
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para devolver la lista de almacenes dependiendo del cliente
    ''' </summary>
    <TestMethod()> Public Sub Llenar_ListaByCliente()

        _DropDownlistTest = New DropDownList()

        Mgr_Almacen.Llenar_ListaByCliente(_DropDownlistTest, _ClienteTest1.id_cliente)

        Assert.AreNotEqual(_DropDownlistTest.Items.Count(), 0)
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para consultar un almacen
    ''' </summary>
    <TestMethod()> Public Sub Get_Almacen()

        Dim AlmacenBd = Mgr_Almacen.Get_Almacen(_AlmacenTest.id_almacen)

        Assert.AreEqual(AlmacenBd.id_almacen, _AlmacenTest.id_almacen)
        Assert.AreEqual(AlmacenBd.id_cliente, _AlmacenTest.id_cliente)
        Assert.AreEqual(AlmacenBd.nombre, _AlmacenTest.nombre)
        Assert.AreEqual(AlmacenBd.codigo, _AlmacenTest.codigo)
        Assert.AreEqual(AlmacenBd.coeficiente_volumetrico, _AlmacenTest.coeficiente_volumetrico)

    End Sub

End Class