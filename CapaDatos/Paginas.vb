

Public Class Paginas

    Private Key As String

    Public Shared ReadOnly Login As Paginas = New Paginas("~/Account/Login")
    Public Shared ReadOnly Inicio As Paginas = New Paginas("~/Default")

    Private Sub New(key As String)
        Me.Key = key
    End Sub

    Public Overrides Function ToString() As String
        Return Key
    End Function
End Class