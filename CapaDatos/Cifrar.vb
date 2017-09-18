
Imports System.Text

Public Class Cifrar

    ''' <summary>
    ''' Metodo que cifra una cadena de texto a pasar por url
    ''' </summary>
    Public Shared Function cifrarCadena(mensaje As String) As String
        Dim result As String = String.Empty
        Dim encrypted As Byte() = Encoding.Unicode.GetBytes(mensaje)
        result = Convert.ToBase64String(encrypted)
        Return result

    End Function

    ''' <summary>
    ''' Metodo que descifra una cadena de texto pasada por url
    ''' </summary>
    Public Shared Function descifrarCadena_Text(mensaje As String) As String
        Dim result As String = String.Empty
        Dim decrypted As Byte() = Convert.FromBase64String(mensaje)
        result = Encoding.Unicode.GetString(decrypted)
        Return result

    End Function

    ''' <summary>
    ''' Metodo que descifra una cadena de texto pasada por url y devuelve un entero
    ''' </summary>
    Public Shared Function descifrarCadena_Num(mensaje As String) As Integer
        Dim result As String = String.Empty
        Dim decrypted As Byte() = Convert.FromBase64String(mensaje)
        result = Encoding.Unicode.GetString(decrypted)
        Return Convert.ToInt32(result)

    End Function

End Class
