

Public Class Val_Paginas

    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub

    Public Overrides Function ToString() As String
        Return Key
    End Function


    '------------------------------------------------------------------
    '------------------------URL DEL MENU DE LA APLICACION-------------
    '------------------------------------------------------------------
    Public Shared ReadOnly URL_Operacion As Val_Paginas = New Val_Paginas("../../Archivos/Operacion/")
    Public Shared ReadOnly URL_Articulos As Val_Paginas = New Val_Paginas("../../Archivos/Articulos/")
    Public Shared ReadOnly URL_Temp As Val_Paginas = New Val_Paginas("../../Archivos/Temp/")
    Public Shared ReadOnly Login As Val_Paginas = New Val_Paginas("~/Account/Login")
    Public Shared ReadOnly Inicio As Val_Paginas = New Val_Paginas("~/Default")

    '---------------------------------------------------
    '------------------------MODULOS--------------------
    '---------------------------------------------------
    Public Shared ReadOnly Cliente_Index As Val_Paginas = New Val_Paginas("Cliente_Index")
    Public Shared ReadOnly Almacen_Index As Val_Paginas = New Val_Paginas("Almacen_Index")
    Public Shared ReadOnly Articulo_Index As Val_Paginas = New Val_Paginas("Articulo_Index")
    Public Shared ReadOnly TipoFacturacion_Index As Val_Paginas = New Val_Paginas("TipoFacturacion_Index")
    Public Shared ReadOnly TipoUnidad_Index As Val_Paginas = New Val_Paginas("TipoUnidad_Index")
    Public Shared ReadOnly Operacion_Index As Val_Paginas = New Val_Paginas("Operacion_Index")

End Class