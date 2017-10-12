

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

        Me.URL = "http://www.midemo.es/logispack/Portal/Almacen/index"
        Me.txtSearch = "MainContent_txtSearch"
        Me.txtcodigoAdd = "txtCodigo"
        Me.txtcodigoEdit = "txtEditCodigo"
        Me.txtNombreAdd = "txtNombre"
        Me.txtNombreEdit = "txtEditNombre"
        Me.txtCoefVolAdd = "txtCoefVol"
        Me.txtCoefVolEdit = "txtEditCoefVol"
        Me.ddlClienteAdd = "MainContent_ddlClienteAdd"
        Me.ddlClienteEdit = "MainContent_ddlClienteEdit"
        Me.GridPrinicipal = "MainContent_GridView1"
        Me.ddlFiltroBuscar = "MainContent_ddlBuscar"
        Me.BotonAddModal = "MainContent_btnRegistrar"
        Me.BotonAdd = "MainContent_btnAdd"
        Me.BotonEditModal = "6"
        Me.BotonEdit = "MainContent_btnEdit"
        Me.BotonDeleteModal = "9"
        Me.BotonDelete = "MainContent_btnDelete"
        Me.BotonDetallesModal = "8"
        Me.BotonReset = "MainContent_btnReset"
        Me.BotonBuscar = "MainContent_btnBuscar"
        Me.Filtro_Cod = "Código"
        Me.Filtro_Nom = "Nombre"
        Me.Filtro_Cli = "Cliente"
        Me.BotonMaxMinBuscar = "sectionHeaderButton2"

    End Sub


End Class
