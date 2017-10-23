Public Class Val_Rol

    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub

    Public Overrides Function ToString() As String
        Return Key
    End Function

    '------------------------------------------------------------------
    '-------NOMBRES DE LOS ROELS EXISTENTES EN LA BASE DE DATOS--------
    '------------------------------------------------------------------
    Public Shared ReadOnly Admin As Val_Rol = New Val_Rol("Admin")
    Public Shared ReadOnly Manager As Val_Rol = New Val_Rol("Manager")

End Class
