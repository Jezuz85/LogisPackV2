'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Cliente
    Public Property id_cliente As Integer
    Public Property nombre As String
    Public Property codigo As String

    Public Overridable Property Almacen As ICollection(Of Almacen) = New HashSet(Of Almacen)

End Class
