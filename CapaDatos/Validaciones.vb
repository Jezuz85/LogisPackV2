
Imports System.Globalization
Imports System.Web.UI.WebControls

Public Class Validaciones


    Public Shared Function Validar_Campo_Vacio(_ValorAsignar As String, _ValorDefault As String) As String

        Return If(_ValorAsignar = String.Empty, _ValorDefault, _ValorAsignar)

    End Function

    Public Shared Function Formatear_Double(_ValorAsignar As String) As String

        Return Double.Parse(_ValorAsignar, CultureInfo.InvariantCulture)

    End Function

End Class
