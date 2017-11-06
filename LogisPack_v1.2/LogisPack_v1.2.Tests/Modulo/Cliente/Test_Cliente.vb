
Imports System.Web.UI.WebControls
Imports CapaDatos

<TestClass()> Public Class Test_Cliente

    Dim ClienteTest As Cliente
    Dim _DropDownlistTest As DropDownList
    Dim _GridViewTest As GridView

    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()
        ClienteTest = Mgr_Cliente_Test.Get_Cliente1()
        Mgr_Cliente_Test.Inicializar(ClienteTest)
    End Sub

    ''' <summary>
    ''' Método que se invoca para finbalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()
        Mgr_Cliente_Test.Finalizar(ClienteTest)
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para registrar un Cliente
    ''' </summary>
    <TestMethod()> Public Sub RegistrarCliente()

        Dim ClienteBD = Mgr_Cliente.Get_Cliente(ClienteTest.id_cliente)
        Assert.AreEqual(ClienteBD.id_cliente, ClienteTest.id_cliente)
        Assert.AreEqual(ClienteBD.nombre, ClienteTest.nombre)
        Assert.AreEqual(ClienteBD.codigo, ClienteTest.codigo)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para editar un Cliente
    ''' </summary>
    <TestMethod()> Public Sub EditarCliente()

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim ClienteBD = Mgr_Cliente.Get_Cliente(ClienteTest.id_cliente, contexto)
        ClienteBD.codigo = "Cod2"
        ClienteBD.nombre = "Nombre2"

        Mgr_Cliente.Editar(ClienteBD, contexto)

        Assert.AreEqual(ClienteBD.id_cliente, ClienteTest.id_cliente)
        Assert.AreNotEqual(ClienteBD.nombre, ClienteTest.nombre)
        Assert.AreNotEqual(ClienteBD.codigo, ClienteTest.codigo)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para eliminar un Cliente
    ''' </summary>
    <TestMethod()>
    Public Sub EliminarCliente()

        Mgr_Cliente.Eliminar(ClienteTest.id_cliente)
        Assert.AreEqual(Mgr_Cliente.Get_Cliente(ClienteTest.id_cliente), Nothing)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en cliente, con filtro de Codigo
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_ClienteByCodigo()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteCliente("Codv", Val_Cliente.Filtro_Codigo.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en cliente, con filtro de nombre
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_ClienteByNombre()

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteCliente("Nombrev", Val_Cliente.Filtro_Nombre.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para llenar el grid de un cliente
    ''' </summary>
    <TestMethod()> Public Sub LlenarGrid()

        _GridViewTest = New GridView()
        Mgr_Cliente.LlenarGrid(_GridViewTest, ClienteTest.id_cliente, String.Empty, String.Empty, String.Empty, String.Empty)
        Assert.AreNotEqual(0, _GridViewTest.Rows.Count())

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para llenar la lista de un cliente por el id
    ''' </summary>
    <TestMethod()> Public Sub Llenar_ListaByCliente()

        _DropDownlistTest = New DropDownList()
        Mgr_Cliente.Llenar_ListaByCliente(_DropDownlistTest, ClienteTest.id_cliente)
        Assert.AreNotEqual(0, _DropDownlistTest.Items.Count())

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para consultar un Cliente
    ''' </summary>
    <TestMethod()> Public Sub Get_Cliente()

        Dim ClienteBD = Mgr_Cliente.Get_Cliente(ClienteTest.id_cliente)
        Assert.AreEqual(ClienteBD.id_cliente, ClienteTest.id_cliente)
        Assert.AreEqual(ClienteBD.nombre, ClienteTest.nombre)
        Assert.AreEqual(ClienteBD.codigo, ClienteTest.codigo)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para consultar un Cliente por el nombre
    ''' </summary>
    <TestMethod()> Public Sub Get_ClienteByNombre()

        Dim ClienteBD = Mgr_Cliente.Get_ClienteByNombre(ClienteTest.nombre)
        Assert.AreEqual(ClienteBD.id_cliente, ClienteTest.id_cliente)
        Assert.AreEqual(ClienteBD.nombre, ClienteTest.nombre)
        Assert.AreEqual(ClienteBD.codigo, ClienteTest.codigo)

    End Sub



End Class