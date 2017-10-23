

Public Class ViewAlmacen

    Public Property URL As String

    Public Property txtSearch As String
    Public Property txtcodigoAdd As String
    Public Property txtcodigoEdit As String
    Public Property txtNombreAdd As String
    Public Property txtNombreEdit As String
    Public Property txtCoefVolAdd As String
    Public Property txtCoefVolEdit As String
    Public Property ddlClienteAdd As String
    Public Property ddlClienteEdit As String
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

    Public Property BotonMaxMinBuscar As String

    Public Property Filtro_Cod As String
    Public Property Filtro_Nom As String
    Public Property Filtro_Cli As String

    Public Sub New()

        URL = "http://www.midemo.es/logispack/Portal/Almacen/index"
        txtSearch = "MainContent_txtSearch"
        txtcodigoAdd = "txtCodigo"
        txtcodigoEdit = "txtEditCodigo"
        txtNombreAdd = "txtNombre"
        txtNombreEdit = "txtEditNombre"
        txtCoefVolAdd = "txtCoefVol"
        txtCoefVolEdit = "txtEditCoefVol"
        ddlClienteAdd = "MainContent_ddlClienteAdd"
        ddlClienteEdit = "MainContent_ddlClienteEdit"
        GridPrinicipal = "MainContent_GridView1"
        ddlFiltroBuscar = "MainContent_ddlBuscar"
        BotonAddModal = "MainContent_btnRegistrar"
        BotonAdd = "MainContent_btnAdd"
        BotonEditModal = "6"
        BotonEdit = "MainContent_btnEdit"
        BotonDeleteModal = "9"
        BotonDelete = "MainContent_btnDelete"
        BotonDetallesModal = "8"
        BotonReset = "MainContent_btnReset"
        BotonBuscar = "MainContent_btnBuscar"
        Filtro_Cod = "Código"
        Filtro_Nom = "Nombre"
        Filtro_Cli = "Cliente"
        BotonMaxMinBuscar = "sectionHeaderButton2"

    End Sub


End Class
