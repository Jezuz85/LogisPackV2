Public Class ViewCliente

    Public Property URL As String

    Public Property txtSearch As String
    Public Property txtCodigoAdd As String
    Public Property txtcodigoEdit As String
    Public Property txtNombreAdd As String
    Public Property txtNombreEdit As String

    Public Property GridPrinicipal As String
    Public Property ddlFiltroBuscar As String

    Public Property BotonAddModal As String
    Public Property BotonAdd As String
    Public Property BotonEditModal As String
    Public Property BotonEdit As String
    Public Property BotonDeleteModal As String
    Public Property BotonDelete As String
    Public Property BotonBuscar As String
    Public Property BotonReset As String

    Public Property Filtro_Cod As String
    Public Property Filtro_Nom As String


    Public Sub New()

        URL = "http://www.midemo.es/logispack/Portal/Cliente/index"
        txtSearch = "MainContent_txtSearch"
        txtCodigoAdd = "txtCodigo_Add"
        txtcodigoEdit = "txtCodigo_Edit"
        txtNombreAdd = "txtNombre_Add"
        txtNombreEdit = "txtNombre_Edit"
        GridPrinicipal = "MainContent_GridView1"
        ddlFiltroBuscar = "MainContent_ddlBuscar"
        BotonAddModal = "MainContent_btnRegistrar"
        BotonAdd = "MainContent_btnAdd"
        BotonEditModal = "4"
        BotonEdit = "MainContent_btnEdit"
        BotonDeleteModal = "5"
        BotonReset = "MainContent_btnReset"
        BotonBuscar = "MainContent_btnBuscar"
        Filtro_Cod = "Codigo"
        Filtro_Nom = "Nombre"
        BotonDelete = "MainContent_btnDelete"

    End Sub

End Class
