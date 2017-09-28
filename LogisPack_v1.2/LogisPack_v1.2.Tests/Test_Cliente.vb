
Imports CapaDatos

<TestClass()> Public Class Test_Cliente
    Dim _Nuevo As Cliente

    <TestInitialize>
    Public Sub inicializar()
        DataAccess.Inicializar_Cliente(_Nuevo)
    End Sub

    <TestCleanup>
    Public Sub finalizar()
        DataAccess.Finalizar_Cliente(_Nuevo)
    End Sub

    <TestMethod()> Public Sub RegistrarCliente()
        Dim _cliente = Getter.Cliente(_Nuevo.id_cliente)

        Assert.AreEqual(_cliente.id_cliente, _Nuevo.id_cliente)
        Assert.AreEqual(_cliente.nombre, _Nuevo.nombre)
        Assert.AreEqual(_cliente.codigo, _Nuevo.codigo)
    End Sub

    <TestMethod()> Public Sub EditarCliente()

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _cliente = Getter.Cliente(_Nuevo.id_cliente, contexto)

        _cliente.codigo = "Cod2"
        _cliente.nombre = "Nombre2"

        Update.Cliente(_cliente, contexto)

        Assert.AreEqual(_cliente.id_cliente, _Nuevo.id_cliente)
        Assert.AreNotEqual(_cliente.nombre, _Nuevo.nombre)
        Assert.AreNotEqual(_cliente.codigo, _Nuevo.codigo)


    End Sub

    <TestMethod()> Public Sub EliminarCliente()

        Delete.Cliente(_Nuevo.id_cliente)

        Dim _cliente = Getter.Cliente(_Nuevo.id_cliente)

        Assert.AreEqual(_cliente, Nothing)

    End Sub

End Class