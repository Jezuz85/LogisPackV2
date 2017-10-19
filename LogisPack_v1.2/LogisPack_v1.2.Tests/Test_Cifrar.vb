Imports CapaDatos

<TestClass()> Public Class Test_Cifrar

    <TestMethod()> Public Sub cifrarCadena()

        Dim msjCifrar As String = "Prueba1234"

        Dim ValorEsperado As String = "UAByAHUAZQBiAGEAMQAyADMANAA="
        Dim ValorReal As String = String.Empty

        ValorReal = Util_Cifrar.cifrarCadena(msjCifrar)

        Assert.AreEqual(ValorEsperado, ValorReal)

    End Sub

    <TestMethod()> Public Sub descifrarCadena()

        Dim msjdesCifrar As String = "UAByAHUAZQBiAGEAMQAyADMANAA="

        Dim ValorEsperado As String = "Prueba1234"
        Dim ValorReal As String = String.Empty

        ValorReal = Util_Cifrar.descifrarCadena_Text(msjdesCifrar)

        Assert.AreEqual(ValorEsperado, ValorReal)
    End Sub

    <TestMethod()> Public Sub descifrarCadenaNum()

        Dim msjdesCifrar As String = "MQAwAA=="

        Dim ValorEsperado As Integer = 10
        Dim ValorReal As Integer = 0

        ValorReal = Util_Cifrar.descifrarCadena_Num(msjdesCifrar)

        Assert.AreEqual(ValorEsperado, ValorReal)
    End Sub

End Class
