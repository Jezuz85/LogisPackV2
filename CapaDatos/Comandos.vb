
Public Class Comandos

    Private Key As String

    Public Shared ReadOnly Arbol_Almacen_Nivel0 As Comandos = New Comandos("SELECT Count(id_almacen), CL.id_cliente ID , CL.nombre  Name FROM Almacen AL INNER JOIN cliente CL ON CL.id_cliente = AL.id_cliente Group By CL.id_cliente,CL.nombre")
    Public Shared ReadOnly Arbol_Almacen_Nivel1 As Comandos = New Comandos("SELECT (codigo +' '+ nombre) Name, id_almacen ID FROM Almacen WHERE id_cliente = ")
    Public Shared ReadOnly Arbol_Almacen_Nivel2 As Comandos = New Comandos("SELECT 'Articulo: '+nombre Name, id_articulo ID FROM Articulo WHERE id_almacen =")

    Private Sub New(key As String)
        Me.Key = key
    End Sub

    Public Overrides Function ToString() As String
        Return Key
    End Function
End Class
