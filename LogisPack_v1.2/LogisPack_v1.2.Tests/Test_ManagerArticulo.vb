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
        LlenarTextbox()
        ValorEsperado = 0

        ValorReal = Manager_Articulo.CalcularM3(txtAncho, txtAlto, txtLargo)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos enteros"

        LlenarTextbox("100", "100", "100")
        ValorEsperado = 1
        ValorReal = Manager_Articulo.CalcularM3(txtAncho, txtAlto, txtLargo)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox vacios y con datos"

        LlenarTextbox("", "20")

        ValorEsperado = 0
        ValorReal = Manager_Articulo.CalcularM3(txtAncho, txtAlto, txtLargo)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos flotantes"

        LlenarTextbox("100.1", "200.2", "300.3")
        ValorEsperado = 6.018
        ValorReal = Manager_Articulo.CalcularM3(txtAncho, txtAlto, txtLargo)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region


    End Sub

    <TestMethod()> Public Sub CalcularPesoVolumetrico()

#Region "textbox vacio"
        LlenarTextbox()

        ValorEsperado = 0
        ValorReal = Manager_Articulo.CalcularPesoVolumetrico(txtAncho, txtAlto, txtLargo, txtCoefVol)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox vacios y con datos"

        LlenarTextbox("", "2")
        ValorEsperado = 0
        ValorReal = Manager_Articulo.CalcularPesoVolumetrico(txtAncho, txtAlto, txtLargo, txtCoefVol)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos enteros"

        LlenarTextbox("10", "20", "30", "", "", "", "40")
        ValorEsperado = 240
        ValorReal = Manager_Articulo.CalcularPesoVolumetrico(txtAncho, txtAlto, txtLargo, txtCoefVol)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos decimales"

        LlenarTextbox("1.1", "2.2", "3.3", "", "", "", "4.4")

        ValorEsperado = 0.035
        ValorReal = Manager_Articulo.CalcularPesoVolumetrico(txtAncho, txtAlto, txtLargo, txtCoefVol)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

    End Sub

    <TestMethod()> Public Sub CalcularValoracionStock()

#Region "textbox vacios"

        LlenarTextbox()

        ValorEsperado = 0
        ValorReal = Manager_Articulo.CalcularValoracionStock(txtStockFisico, txtValArticulo)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox vacios y con datos"

        LlenarTextbox("", "", "", "", "", "1", "")

        ValorEsperado = 0
        ValorReal = Manager_Articulo.CalcularValoracionStock(txtStockFisico, txtValArticulo)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos enteros"

        LlenarTextbox("", "", "", "10", "", "5", "")
        ValorEsperado = 50
        ValorReal = Manager_Articulo.CalcularValoracionStock(txtStockFisico, txtValArticulo)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "TextBox con datos decimales"

        LlenarTextbox("", "", "", "2.2", "", "5.5", "")

        ValorEsperado = 12.1
        ValorReal = Manager_Articulo.CalcularValoracionStock(txtStockFisico, txtValArticulo)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

    End Sub

    <TestMethod()> Public Sub CalcularValoracionSeguro()

#Region "textbox vacios"

        LlenarTextbox()

        ValorEsperado = 0
        ValorReal = Manager_Articulo.CalcularValoracionSeguro(txtStockFisico, txtValAsegurado)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox vacios y con datos"

        LlenarTextbox("", "", "", "", "1", "", "")

        ValorEsperado = 0
        ValorReal = Manager_Articulo.CalcularValoracionSeguro(txtStockFisico, txtValAsegurado)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos enteros"

        LlenarTextbox("", "", "", "10", "5", "", "")
        ValorEsperado = 50
        ValorReal = Manager_Articulo.CalcularValoracionSeguro(txtStockFisico, txtValAsegurado)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

#Region "textbox con datos decimales"

        LlenarTextbox("", "", "", "2.2", "5.5", "", "")
        ValorEsperado = 12.1
        ValorReal = Manager_Articulo.CalcularValoracionSeguro(txtStockFisico, txtValAsegurado)
        Assert.AreEqual(ValorEsperado, ValorReal)
#End Region

    End Sub

    Public Sub LlenarTextbox(
        Optional ByRef _txtAncho As String = "", Optional ByRef _txtAlto As String = "",
        Optional ByRef _txtLargo As String = "", Optional ByRef _txtStockFisico As String = "",
        Optional ByRef _txtValAsegurado As String = "", Optional ByRef _txtValArticulo As String = "",
        Optional ByRef _txtCoefVol As String = "")

        txtAncho = _txtAncho
        txtAlto = _txtAlto
        txtLargo = _txtLargo
        txtStockFisico = _txtStockFisico
        txtValAsegurado = _txtValAsegurado
        txtValArticulo = _txtValArticulo
        txtCoefVol = _txtCoefVol

    End Sub

End Class