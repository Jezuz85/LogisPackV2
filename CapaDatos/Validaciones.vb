
Imports System.Globalization
Imports System.IO
Imports System.Web.UI.WebControls

Public Class Validaciones
    Dim contexto As LogisPackEntities = New LogisPackEntities()

    Public Shared Function Validar_Campo_Vacio(_ValorAsignar As String, _ValorDefault As String) As String

        Return If(_ValorAsignar = String.Empty, _ValorDefault, _ValorAsignar)

    End Function

    Public Shared Function Formatear_Double(_ValorAsignar As String) As String

        Return Double.Parse(_ValorAsignar, CultureInfo.InvariantCulture)

    End Function

    Public Shared Function Exist_Tipo_Facturacion(nombre As String) As Boolean

        Dim TipoFacturacion = Getter.Tipo_Facturacion(nombre)

        If TipoFacturacion IsNot Nothing Then
            Return True
        End If

        Return False

    End Function

    Public Shared Function Exist_Tipo_Unidad(nombre As String) As Boolean

        Dim TipoUnidad = Getter.Tipo_Unidad(nombre)

        If TipoUnidad IsNot Nothing Then
            Return True
        End If

        Return False

    End Function

    Public Shared Function Longitud_Campo(valor As String, longitud As Integer) As Boolean

        If valor.Length > longitud Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function Identificacion(valor As String) As Boolean

        If valor.ToUpper = "CB" Or valor.ToUpper = "RF" Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function Validarnumero(valor As String) As Boolean

        If IsNumeric(valor) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
