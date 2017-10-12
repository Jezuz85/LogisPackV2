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

        Me.URL = "http://www.midemo.es/logispack/Portal/Cliente/index"
        Me.txtSearch = "MainContent_txtSearch"
        Me.txtcodigoAdd = "txtCodigo_Add"
        Me.txtcodigoEdit = "txtCodigo_Edit"
        Me.txtNombreAdd = "txtNombre_Add"
        Me.txtNombreEdit = "txtNombre_Edit"
        Me.GridPrinicipal = "MainContent_GridView1"
        Me.ddlFiltroBuscar = "MainContent_ddlBuscar"
        Me.BotonAddModal = "MainContent_btnRegistrar"
        Me.BotonAdd = "MainContent_btnAdd"
        Me.BotonEditModal = "4"
        Me.BotonEdit = "MainContent_btnEdit"
        Me.BotonDeleteModal = "5"
        Me.BotonReset = "MainContent_btnReset"
        Me.BotonBuscar = "MainContent_btnBuscar"
        Me.Filtro_Cod = "Codigo"
        Me.Filtro_Nom = "Nombre"
        Me.BotonDelete = "MainContent_btnDelete"

    End Sub

End Class
