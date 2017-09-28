Imports CapaDatos

<TestClass()> Public Class Test_Comandos

    <TestMethod()> Public Sub Arbol_Almacen_Nivel0()

        Dim ValorEsperado As String = "SELECT Count(id_almacen), CL.id_cliente ID , CL.nombre  Name FROM Almacen AL INNER JOIN cliente CL ON CL.id_cliente = AL.id_cliente Group By CL.id_cliente,CL.nombre"
        Dim ValorReal As String = String.Empty

        ValorReal = Comandos.Arbol_Almacen_Nivel0.ToString

        Assert.AreEqual(ValorEsperado, ValorReal)
    End Sub

    <TestMethod()> Public Sub Arbol_Almacen_Nivel1()

        Dim ValorEsperado As String = "SELECT (codigo +' '+ nombre) Name, id_almacen ID FROM Almacen WHERE id_cliente = "
        Dim ValorReal As String = String.Empty

        ValorReal = Comandos.Arbol_Almacen_Nivel1.ToString

        Assert.AreEqual(ValorEsperado, ValorReal)
    End Sub

    <TestMethod()> Public Sub Arbol_Almacen_Nivel2()

        Dim ValorEsperado As String = "SELECT 'Articulo: '+nombre Name, id_articulo ID FROM Articulo WHERE id_almacen ="
        Dim ValorReal As String = String.Empty

        ValorReal = Comandos.Arbol_Almacen_Nivel2.ToString

        Assert.AreEqual(ValorEsperado, ValorReal)
    End Sub

End Class