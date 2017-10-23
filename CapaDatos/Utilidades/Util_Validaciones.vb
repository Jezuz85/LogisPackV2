
Imports System.Globalization

Public Class Util_Validaciones
    Dim contexto As LogisPackEntities = New LogisPackEntities()

    ''' <summary>
    ''' Metodo que valida si un campo es vacio retorna String.Empty sino devuelve el valor actual
    ''' </summary>
    Public Shared Function Validar_Campo_Vacio(_ValorAsignar As String, _ValorDefault As String) As String

        Return If(_ValorAsignar = String.Empty, _ValorDefault, _ValorAsignar)

    End Function

    ''' <summary>
    ''' Metodo que recibe un string de un textbox y retorna formateado a double con decimales
    ''' </summary>
    Public Shared Function Formatear_Double(_ValorAsignar As String) As String

        Return Double.Parse(_ValorAsignar, CultureInfo.InvariantCulture)

    End Function

    ''' <summary>
    ''' Metodo que busca un tipo de facturacion por su nombre y valida si existe un registro de Tipo de Facturacion
    ''' en la base de datos
    ''' </summary>
    Public Shared Function Exist_Tipo_Facturacion(nombre As String) As Boolean

        Dim TipoFacturacion = Mgr_TipoFacturacion.Get_Tipo_Facturacion(nombre)

        If TipoFacturacion IsNot Nothing Then
            Return True
        End If

        Return False

    End Function

    ''' <summary>
    ''' Metodo que busca un tipo de unidad por su nombre y valida si existe un registro de Tipo de unidad
    ''' en la base de datos
    ''' </summary>
    Public Shared Function Exist_Tipo_Unidad(nombre As String) As Boolean

        Dim TipoUnidad = Mgr_TipoUnidad.Get_Tipo_Unidad(nombre)

        If TipoUnidad IsNot Nothing Then
            Return True
        End If

        Return False

    End Function

    ''' <summary>
    ''' Metodo que valida que un valor no supere la cantidad de caracteres pasadas por parametro
    ''' </summary>
    Public Shared Function Longitud_Campo(valor As String, longitud As Integer) As Boolean

        If valor.Length > longitud Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Metodo que formatea a mayusculas el valor ingresado como identificacion
    ''' </summary>
    Public Shared Function Identificacion(valor As String) As Boolean

        If valor.ToUpper = "CB" Or valor.ToUpper = "RF" Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Metodo que valida que un valor pasado por parametro sea solo numerico
    ''' </summary>
    Public Shared Function Validarnumero(valor As String) As Boolean

        If IsNumeric(valor) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
