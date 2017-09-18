Public Class Rol

    Private Key As String

    Public Shared ReadOnly Admin As Rol = New Rol("Admin")
    Public Shared ReadOnly Manager As Rol = New Rol("Manager")

    Private Sub New(key As String)
        Me.Key = key
    End Sub

    Public Overrides Function ToString() As String
        Return Key
    End Function
End Class
