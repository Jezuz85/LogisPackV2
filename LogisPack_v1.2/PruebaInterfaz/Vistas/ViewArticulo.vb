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

    Public Property lbTipoArticulo As String
    Public Property lbAlmacen As String
    Public Property lbStockMinimo As String
    Public Property lbStockFisico As String
    Public Property lbCodigo As String
    Public Property lbNombre As String
    Public Property lbRefPick As String
    Public Property lbTipoUnidad As String
    Public Property lbRef1 As String
    Public Property lbRef2 As String
    Public Property lbRef3 As String
    Public Property lbPeso As String
    Public Property lbAlto As String
    Public Property lbLargo As String
    Public Property lbAncho As String
    Public Property lbCubicaje As String
    Public Property lbCoefVol As String
    Public Property lbPesoVol As String
    Public Property lbTipoFacturacion As String
    Public Property lbIdentificacion As String
    Public Property lbValArticulo As String
    Public Property lbValAsegurado As String
    Public Property lbValStock As String
    Public Property lbValSeguro As String
    Public Property lbObsGen As String
    Public Property lbObsArt As String



    Public Sub New()

        '------------------detalles articulo
        lbTipoArticulo = "MainContent_lbTipoArticulo"
        lbAlmacen = "MainContent_lbAlmacen"
        lbStockMinimo = "MainContent_lbStockMinimo"
        lbStockFisico = "MainContent_lbStockFisico"
        lbCodigo = "MainContent_lbCodigo"
        lbNombre = "MainContent_lbNombre"
        lbRefPick = "MainContent_lbRefPick"
        lbTipoUnidad = "MainContent_lbTipoUnidad"
        lbRef1 = "MainContent_lbRef1"
        lbRef2 = "MainContent_lbRef2"
        lbRef3 = "MainContent_lbRef3"
        lbPeso = "MainContent_lbPeso"
        lbAlto = "MainContent_lbAlto"
        lbLargo = "MainContent_lbLargo"
        lbAncho = "MainContent_lbAncho"
        lbCubicaje = "MainContent_lbCubicaje"
        lbCoefVol = "MainContent_lbCoefVol"
        lbPesoVol = "MainContent_lbPesoVol"
        lbTipoFacturacion = "MainContent_lbTipoFacturacion"
        lbIdentificacion = "MainContent_lbIdentificacion"
        lbValArticulo = "MainContent_lbValArticulo"
        lbValAsegurado = "MainContent_lbValAsegurado"
        lbValStock = "MainContent_lbValStock"
        lbValSeguro = "MainContent_lbValSeguro"
        lbObsGen = "MainContent_lbObsGen"
        lbObsArt = "MainContent_lbObsArt"



        '-----------------crear aritculo
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

        '----------------------index articulo
        URL = "http://www.midemo.es/logispack/Portal/Articulo/index"
        txtSearch = "MainContent_txtSearch"
        GridPrinicipal = "MainContent_GridView1"
        ddlFiltroBuscar = "MainContent_ddlBuscar"
        BotonAddModal = "MainContent_btnGuardar"
        BotonAdd = "MainContent_btnGuardar"
        BotonEditModal = "6"
        BotonEdit = "MainContent_btnEdit"
        BotonDeleteModal = "8"
        BotonReset = "MainContent_btnReset"
        BotonBuscar = "MainContent_btnBuscar"
        Filtro_Cod = "Codigo"
        Filtro_Nom = "Nombre"
        Filtro_Alm = "Almacén"
        Filtro_Cli = "Cliente"
        BotonDelete = "MainContent_btnDelete"
        BotonDetallesModal = "7"

    End Sub
End Class
