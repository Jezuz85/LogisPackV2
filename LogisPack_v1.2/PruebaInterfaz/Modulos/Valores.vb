Public Class Valores
    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub
    Public Overrides Function ToString() As String
        Return Key
    End Function

#Region "Empresa"
    Public Shared ReadOnly Nom_Cliente As Valores = New Valores("Cli_Selenium")
    Public Shared ReadOnly Nom_Cliente2 As Valores = New Valores("Cli2_Selenium")
    Public Shared ReadOnly Nom_Cliente_Edit As Valores = New Valores("Cli_Selenium_1")
    Public Shared ReadOnly Nom_Cliente_Buscar As Valores = New Valores("Cli_Sel")
    Public Shared ReadOnly Cod_Cliente As Valores = New Valores("001_Sel")
    Public Shared ReadOnly Cod_Cliente2 As Valores = New Valores("002_Sel")
    Public Shared ReadOnly Cod_Cliente_Edit As Valores = New Valores("001_Sel_1")
#End Region

#Region "Tipo de facturacion"
    Public Shared ReadOnly Nom_TipoFact As Valores = New Valores("TipoFact_Selenium")
    Public Shared ReadOnly Nom_TipoFact_Edit As Valores = New Valores("TipoFact_Selenium_1")
    Public Shared ReadOnly Nom_TipoFact_Buscar As Valores = New Valores("TipoFact_Sel")
#End Region

#Region "Tipo de Unidad"
    Public Shared ReadOnly Nom_TipoUnidad As Valores = New Valores("TipoUni_Selenium")
    Public Shared ReadOnly Nom_TipoUnidad_Edit As Valores = New Valores("TipoUni_Selenium_1")
    Public Shared ReadOnly Nom_TipoUnidad_Buscar As Valores = New Valores("TipoUni_Sel")
#End Region

#Region "Almacen"

    Public Shared ReadOnly Nom_Almacen As Valores = New Valores("Alm_Selenium")
    Public Shared ReadOnly Nom_Almacen_Edit As Valores = New Valores("Alm_Selenium_1")

    Public Shared ReadOnly Cod_Almacen As Valores = New Valores("001_Sel")
    Public Shared ReadOnly Cod_Almacen_Edit As Valores = New Valores("002_Sel")

    Public Shared ReadOnly CoefVol_Almacen As Valores = New Valores("50")
    Public Shared ReadOnly CoefVol_Almacen_Edit As Valores = New Valores("50,5")


#End Region

#Region "Articulo"

    Public Shared ReadOnly _Art_cod As Valores = New Valores("_Art_cod")
    Public Shared ReadOnly _Art_nom As Valores = New Valores("_Art_nom")
    Public Shared ReadOnly _Art_ref1 As Valores = New Valores("_Art_ref1")
    Public Shared ReadOnly _Art_ref2 As Valores = New Valores("_Art_ref2")
    Public Shared ReadOnly _Art_ref3 As Valores = New Valores("_Art_ref3")
    Public Shared ReadOnly _Art_ref_pic As Valores = New Valores("_Art_ref_pic")
    Public Shared ReadOnly _Art_obs_art As Valores = New Valores("_Art_obs_art")
    Public Shared ReadOnly _Art_obs_gen As Valores = New Valores("_Art_obs_gen")
    Public Shared ReadOnly _Art_peso As Valores = New Valores("10,1")
    Public Shared ReadOnly _Art_alto As Valores = New Valores("20.02")
    Public Shared ReadOnly _Art_largo As Valores = New Valores("30,003")
    Public Shared ReadOnly _Art_ancho As Valores = New Valores("40,0004")
    Public Shared ReadOnly _Art_stock_fis As Valores = New Valores("50,5")
    Public Shared ReadOnly _Art_stock_min As Valores = New Valores("60,06")
    Public Shared ReadOnly _Art_valor_art As Valores = New Valores("70,007")
    Public Shared ReadOnly _Art_coef_vol As Valores = New Valores("80,0008")
    Public Shared ReadOnly _Art_valor_ase As Valores = New Valores("90,9")
    '------------------------------------------------------------------
    Public Shared ReadOnly _Art_cod_Edit As Valores = New Valores("_Art_cod_1")
    Public Shared ReadOnly _Art_nom_Edit As Valores = New Valores("_Art_nom_1")
    Public Shared ReadOnly _Art_ref1_Edit As Valores = New Valores("_Art_ref1_1")
    Public Shared ReadOnly _Art_ref2_Edit As Valores = New Valores("_Art_ref2_1")
    Public Shared ReadOnly _Art_ref3_Edit As Valores = New Valores("_Art_ref3_1")
    Public Shared ReadOnly _Art_ref_pic_Edit As Valores = New Valores("_Art_ref_pic_1")
    Public Shared ReadOnly _Art_obs_art_Edit As Valores = New Valores("_Art_obs_art_1")
    Public Shared ReadOnly _Art_obs_gen_Edit As Valores = New Valores("_Art_obs_gen_1")
    Public Shared ReadOnly _Art_peso_Edit As Valores = New Valores("20,2")
    Public Shared ReadOnly _Art_alto_Edit As Valores = New Valores("30.03")
    Public Shared ReadOnly _Art_largo_Edit As Valores = New Valores("40,004")
    Public Shared ReadOnly _Art_ancho_Edit As Valores = New Valores("50,0005")
    Public Shared ReadOnly _Art_stock_fis_Edit As Valores = New Valores("60,6")
    Public Shared ReadOnly _Art_stock_min_Edit As Valores = New Valores("70,07")
    Public Shared ReadOnly _Art_valor_art_Edit As Valores = New Valores("80,008")
    Public Shared ReadOnly _Art_coef_vol_Edit As Valores = New Valores("90,0009")
    Public Shared ReadOnly _Art_valor_ase_Edit As Valores = New Valores("10,1")

#End Region



End Class
