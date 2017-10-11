Public Class Valores
    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub
    Public Overrides Function ToString() As String
        Return Key
    End Function

#Region "Botones"
    Public Shared ReadOnly ID_btnAddModal As Valores = New Valores("MainContent_btnRegistrar")
    Public Shared ReadOnly ID_btnAdd As Valores = New Valores("MainContent_btnAdd")
    Public Shared ReadOnly ID_btnEditModal As Valores = New Valores("MainContent_btnEdit")
    Public Shared ReadOnly ID_btnReset As Valores = New Valores("MainContent_btnReset")
    Public Shared ReadOnly ID_btnDelete As Valores = New Valores("MainContent_btnDelete")
    Public Shared ReadOnly ID_btnBuscar As Valores = New Valores("MainContent_btnBuscar")
#End Region

#Region "Textbox"
    Public Shared ReadOnly ID_txtNombre As Valores = New Valores("txtNombre")
    Public Shared ReadOnly ID_txtCodigo_Add As Valores = New Valores("txtCodigo_Add")
    Public Shared ReadOnly ID_txtNombre_Add As Valores = New Valores("txtNombre_Add")
    Public Shared ReadOnly ID_txtCodigo_Edit As Valores = New Valores("txtCodigo_Edit")
    Public Shared ReadOnly ID_txtNombre_Edit As Valores = New Valores("txtNombre_Edit")
    Public Shared ReadOnly ID_txtSearch As Valores = New Valores("MainContent_txtSearch")
#End Region

#Region "DropDownlist"

    Public Shared ReadOnly ID_ddlBuscar As Valores = New Valores("MainContent_ddlBuscar")
#End Region

#Region "GridView"

    Public Shared ReadOnly ID_GridEmpresa As Valores = New Valores("MainContent_GridView1")
    Public Shared ReadOnly ID_GridTipoFact As Valores = New Valores("MainContent_GridView1")
    Public Shared ReadOnly ID_GridTipoUnidad As Valores = New Valores("MainContent_GridView1")
#End Region

#Region "Empresa"
    Public Shared ReadOnly URLEmpresa As Valores = New Valores("http://www.midemo.es/logispack/Portal/Cliente/index")
    Public Shared ReadOnly Nom_Empresa As Valores = New Valores("NombreSelenium")
    Public Shared ReadOnly Nom_Empresa_Edit As Valores = New Valores("NombreSelenium_1")
    Public Shared ReadOnly Nom_Empresa_Buscar As Valores = New Valores("NombreSel")
    Public Shared ReadOnly Cod_Empresa As Valores = New Valores("CodSel")
    Public Shared ReadOnly Cod_Empresa_Edit As Valores = New Valores("CodSel_1")
    Public Shared ReadOnly Filtro_Cod As Valores = New Valores("Codigo")
    Public Shared ReadOnly Filtro_Nom As Valores = New Valores("Nombre")
    Public Shared ReadOnly ColBtn_Edit_Emp As Valores = New Valores("4")
    Public Shared ReadOnly ColBtn_Elim_Emp As Valores = New Valores("5")
#End Region

#Region "Tipo de facturacion"

    Public Shared ReadOnly URLTipoFacturacion As Valores = New Valores("http://www.midemo.es/logispack/Portal/TipoFacturacion/index")

    Public Shared ReadOnly Nom_TipoFact As Valores = New Valores("TipoFact_Selenium")
    Public Shared ReadOnly Nom_TipoFact_Edit As Valores = New Valores("TipoFact_Selenium_1")
    Public Shared ReadOnly Nom_TipoFact_Buscar As Valores = New Valores("TipoFact_Sel")
    Public Shared ReadOnly ColBtn_Edit_TipoFact As Valores = New Valores("3")
    Public Shared ReadOnly ColBtn_Elim_TipoFact As Valores = New Valores("4")

#End Region

#Region "Tipo de Unidad"

    Public Shared ReadOnly URLTipoUnidad As Valores = New Valores("http://www.midemo.es/logispack/Portal/TipoUnidad/index")

    Public Shared ReadOnly Nom_TipoUnidad As Valores = New Valores("TipoUni_Selenium")
    Public Shared ReadOnly Nom_TipoUnidad_Edit As Valores = New Valores("TipoUni_Selenium_1")
    Public Shared ReadOnly Nom_TipoUnidad_Buscar As Valores = New Valores("TipoUni_Sel")
    Public Shared ReadOnly ColBtn_Edit_TipoUnidad As Valores = New Valores("3")
    Public Shared ReadOnly ColBtn_Elim_TipoUnidad As Valores = New Valores("4")

#End Region


End Class
