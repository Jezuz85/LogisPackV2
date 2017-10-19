Public Class Val_Rol

    Private Key As String

    Public Shared ReadOnly Admin As Val_Rol = New Val_Rol("Admin")
    Public Shared ReadOnly Manager As Val_Rol = New Val_Rol("Manager")

    Private Sub New(key As String)
        Me.Key = key
    End Sub

    Public Overrides Function ToString() As String
        Return Key
    End Function
End Class
