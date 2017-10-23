Public Class ViewTipoFacturacion

    Public Property URL As String

    Public Property txtSearch As String
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

    Public Property Filtro_Nom As String

    Public Sub New()

        URL = "http://www.midemo.es/logispack/Portal/TipoFacturacion/index"
        txtSearch = "MainContent_txtSearch"
        txtNombreAdd = "txtNombre"
        txtNombreEdit = "txtNombre_Edit"
        GridPrinicipal = "MainContent_GridView1"
        ddlFiltroBuscar = "MainContent_ddlBuscar"
        BotonAddModal = "MainContent_btnRegistrar"
        BotonAdd = "MainContent_btnAdd"
        BotonEditModal = "3"
        BotonEdit = "MainContent_btnEdit"
        BotonDeleteModal = "4"
        BotonReset = "MainContent_btnReset"
        BotonBuscar = "MainContent_btnBuscar"
        Filtro_Nom = "Nombre"
        BotonDelete = "MainContent_btnDelete"

    End Sub

End Class
