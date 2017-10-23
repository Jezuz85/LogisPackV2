
Imports CapaDatos

<TestClass()> Public Class Test_Cliente

    Dim ClienteTest

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

End Class