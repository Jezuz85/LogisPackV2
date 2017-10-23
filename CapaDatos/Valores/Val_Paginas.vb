

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

End Class