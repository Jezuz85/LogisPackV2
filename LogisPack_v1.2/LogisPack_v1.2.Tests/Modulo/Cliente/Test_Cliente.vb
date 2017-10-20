
Imports CapaDatos

<TestClass()> Public Class Test_Cliente

    Dim ClienteTest


    <TestInitialize>
    Public Sub inicializar()
        ClienteTest = Mgr_Cliente_Test.Get_Cliente1()
        Mgr_Cliente_Test.Inicializar(ClienteTest)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        Mgr_Cliente_Test.Finalizar(ClienteTest)
    End Sub

    <TestMethod()> Public Sub RegistrarCliente()

        Dim ClienteBD = Mgr_Cliente.Get_Cliente(ClienteTest.id_cliente)
        Assert.AreEqual(ClienteBD.id_cliente, ClienteTest.id_cliente)
        Assert.AreEqual(ClienteBD.nombre, ClienteTest.nombre)
        Assert.AreEqual(ClienteBD.codigo, ClienteTest.codigo)

    End Sub

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

    <TestMethod()>
    Public Sub EliminarCliente()

        Mgr_Cliente.Eliminar(ClienteTest.id_cliente)
        Assert.AreEqual(Mgr_Cliente.Get_Cliente(ClienteTest.id_cliente), Nothing)

    End Sub

End Class