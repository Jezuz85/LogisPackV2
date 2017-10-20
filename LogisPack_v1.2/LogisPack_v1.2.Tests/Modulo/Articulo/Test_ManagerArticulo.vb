Imports CapaDatos

<TestClass()> Public Class Test_ManagerArticulo

    Private ValorEsperado As Double
    Private ValorReal As Double
    Private txtAncho As String
    Private txtAlto As String
    Private txtLargo As String
    Private txtStockFisico As String
    Private txtValAsegurado As String
    Private txtValArticulo As String
    Private txtCoefVol As String

    <TestInitialize>
    Public Sub inicializar()
        ValorEsperado = 0
        ValorReal = 0
        txtAncho = String.Empty
        txtAlto = String.Empty
        txtLargo = String.Empty
        txtStockFisico = String.Empty
        txtValAsegurado = String.Empty
        txtValArticulo = String.Empty
        txtCoefVol = String.Empty
    End Sub

    <TestMethod()> Public Sub CalcularM3()

#Region "textbox vacios"
        ValorEsperado = 0

        ValorReal = Mgr_Articulo.CalcularM3(0, 0, 0)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos enteros"

        ValorEsperado = 1
        ValorReal = Mgr_Articulo.CalcularM3(100, 100, 100)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox vacios y con datos"

        ValorEsperado = 0
        ValorReal = Mgr_Articulo.CalcularM3(0, 20, 0)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos flotantes"
        ValorEsperado = 6.018
        ValorReal = Mgr_Articulo.CalcularM3(100.1, 200.2, 300.3)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region


    End Sub

    <TestMethod()> Public Sub CalcularPesoVolumetrico()

#Region "textbox vacio"

        ValorEsperado = 0
        ValorReal = Mgr_Articulo.Calcular_PesoVolumetrico(0, 0, 0, 0)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox vacios y con datos"
        ValorEsperado = 0
        ValorReal = Mgr_Articulo.Calcular_PesoVolumetrico(0, 2, 0, 0)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos enteros"
        ValorEsperado = 240
        ValorReal = Mgr_Articulo.Calcular_PesoVolumetrico(10, 20, 30, 40)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos decimales"
        ValorEsperado = 0.035
        ValorReal = Mgr_Articulo.Calcular_PesoVolumetrico(1.1, 2.2, 3.3, 4.4)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

    End Sub

    <TestMethod()> Public Sub CalcularValoracionStock()

#Region "textbox vacios"

        ValorEsperado = 0
        ValorReal = Mgr_Articulo.Calcular_ValoracionStock(0, 0)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox vacios y con datos"
        ValorEsperado = 0
        ValorReal = Mgr_Articulo.Calcular_ValoracionStock(1, 0)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos enteros"

        ValorEsperado = 50
        ValorReal = Mgr_Articulo.Calcular_ValoracionStock(10, 5)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "TextBox con datos decimales"
        ValorEsperado = 12.1
        ValorReal = Mgr_Articulo.Calcular_ValoracionStock(2.2, 5.5)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

    End Sub

    <TestMethod()> Public Sub CalcularValoracionSeguro()

#Region "textbox vacios"
        ValorEsperado = 0
        ValorReal = Mgr_Articulo.Calcular_ValoracionSeguro(0, 0)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox vacios y con datos"
        ValorEsperado = 0
        ValorReal = Mgr_Articulo.Calcular_ValoracionSeguro(1, 0)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos enteros"
        ValorEsperado = 50
        ValorReal = Mgr_Articulo.Calcular_ValoracionSeguro(10, 5)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos decimales"

        ValorEsperado = 12.1
        ValorReal = Mgr_Articulo.Calcular_ValoracionSeguro(2.2, 5.5)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

    End Sub



End Class