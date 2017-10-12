Public Class ViewArticulo

    Public Property URL As String

    Public Property txtSearch As String
    Public Property GridPrinicipal As String
    Public Property ddlFiltroBuscar As String

    Public Property BotonAddModal As String
    Public Property BotonAdd As String
    Public Property BotonEditModal As String
    Public Property BotonEdit As String
    Public Property BotonDeleteModal As String
    Public Property BotonDelete As String
    Public Property BotonDetallesModal As String
    Public Property BotonBuscar As String
    Public Property BotonReset As String

    Public Property Filtro_Cod As String
    Public Property Filtro_Nom As String
    Public Property Filtro_Alm As String
    Public Property Filtro_Cli As String

    Public Property ddlCliente As String
    Public Property ddlAlmacen As String
    Public Property ddlTipoArticulo As String
    Public Property txtCodigo As String
    Public Property txtNombre As String
    Public Property txtRefPick As String
    Public Property ddlTipoUnidad As String
    Public Property txtRef1 As String
    Public Property txtRef2 As String
    Public Property txtRef3 As String
    Public Property txtPeso As String
    Public Property txtAlto As String
    Public Property txtLargo As String
    Public Property txtAncho As String
    Public Property txtCoefVol As String
    Public Property ddlTipoFacturacion As String
    Public Property ddlIdentificacion As String
    Public Property txtValArticulo As String
    Public Property txtValAsegurado As String
    Public Property txtObsGen As String
    Public Property txtObsArt As String
    Public Property txtStockFisico As String
    Public Property txtStockMinimo As String

    Public Property TipoArticulo_Normal As String
    Public Property TipoArticulo_Picking As String
    Public Property Ide_CB As String
    Public Property Ide_RF As String

    Public Sub New()

        ddlCliente = "MainContent_ddlCliente"
        ddlAlmacen = "MainContent_ddlAlmacen"
        ddlTipoArticulo = "MainContent_ddlTipoArticulo"
        txtCodigo = "MainContent_txtCodigo"
        txtNombre = "MainContent_txtNombre"
        txtRefPick = "MainContent_txtRefPick"
        ddlTipoUnidad = "MainContent_ddlTipoUnidad"
        txtRef1 = "MainContent_txtRef1"
        txtRef2 = "MainContent_txtRef2"
        txtRef3 = "MainContent_txtRef3"
        txtPeso = "MainContent_txtPeso"
        txtAlto = "MainContent_txtAlto"
        txtLargo = "MainContent_txtLargo"
        txtAncho = "MainContent_txtAncho"
        txtCoefVol = "MainContent_txtCoefVol"
        ddlTipoFacturacion = "MainContent_ddlTipoFacturacion"
        ddlIdentificacion = "MainContent_ddlIdentificacion"
        txtValArticulo = "MainContent_txtValArticulo"
        txtValAsegurado = "MainContent_txtValAsegurado"
        txtObsGen = "MainContent_txtObsGen"
        txtObsArt = "MainContent_txtObsArt"
        txtStockFisico = "MainContent_txtStockFisico"
        txtStockMinimo = "MainContent_txtStockMinimo"
        TipoArticulo_Normal = "Normal"
        TipoArticulo_Picking = "Picking"
        Ide_CB = "CB"
        Ide_RF = "RF"



        URL = "http://www.midemo.es/logispack/Portal/Articulo/index"
        txtSearch = "MainContent_txtSearch"
        GridPrinicipal = "MainContent_GridView1"
        ddlFiltroBuscar = "MainContent_ddlBuscar"
        BotonAddModal = "MainContent_btnGuardar"
        BotonAdd = "MainContent_btnGuardar"
        BotonEditModal = "5"
        BotonEdit = "MainContent_btnEdit"
        BotonDeleteModal = "7"
        BotonReset = "MainContent_btnReset"
        BotonBuscar = "MainContent_btnBuscar"
        Filtro_Cod = "Codigo"
        Filtro_Nom = "Nombre"
        Filtro_Alm = "Almacén"
        Filtro_Cli = "Cliente"
        BotonDelete = "MainContent_btnDelete"

    End Sub
End Class
