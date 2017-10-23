Public Class Val_Operacion

    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub
    Public Overrides Function ToString() As String
        Return Key
    End Function

    '------------------------------------------------------------------
    '------------------------URL DEL MODULO OPERACION------------------
    '------------------------------------------------------------------
    Public Shared ReadOnly URL_Crear As Val_Operacion = New Val_Operacion("Crear.aspx")

    '------------------------------------------------------------------
    '------------------------FILTROS DE LA LISTA DEL CAMPO BUSCAR------
    '------------------------------------------------------------------
    Public Shared ReadOnly Filtro_Cliente As Val_Operacion = New Val_Operacion("Cliente")
    Public Shared ReadOnly Filtro_Almacen As Val_Operacion = New Val_Operacion("Almacen")
    Public Shared ReadOnly Filtro_Articulo As Val_Operacion = New Val_Operacion("Articulo")

    '------------------------------------------------------------------
    '---NOMBRES DE LAS COLUMANS DEL GRIDVIEW DEL MODULO OPERACION------
    '------------------------------------------------------------------
    Public Shared ReadOnly Col_Fecha_Transaccion As Val_Operacion = New Val_Operacion("fecha_transaccion")
    Public Shared ReadOnly Col_Articulo As Val_Operacion = New Val_Operacion("articulo")
    Public Shared ReadOnly Col_Tipo_Transaccion As Val_Operacion = New Val_Operacion("tipo_transaccion")
    Public Shared ReadOnly Col_Cantidad_Transaccion As Val_Operacion = New Val_Operacion("cantidad_transaccion")

End Class
