
Public Class Val_Correo


    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub
    Public Overrides Function ToString() As String
        Return Key
    End Function

    '------------------------------------------------------------------
    '------------------------DATOS DE CONFIGURACIÓN--------------------
    '------------------------------------------------------------------
    Public Shared ReadOnly EmailFrom As Val_Correo = New Val_Correo("jesuse.garcia@direcline.com")
    Public Shared ReadOnly Contraseña As Val_Correo = New Val_Correo("Jgardir1")
    Public Shared ReadOnly EmailTo As Val_Correo = New Val_Correo("jesuse.garcia@direcline.com")
    Public Shared ReadOnly Host As Val_Correo = New Val_Correo("smtp.direcline.com")
    Public Shared ReadOnly Puerto As Val_Correo = New Val_Correo("587")

End Class
