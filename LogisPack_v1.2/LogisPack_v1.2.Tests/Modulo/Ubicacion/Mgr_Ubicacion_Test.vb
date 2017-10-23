
Imports CapaDatos

Public Class Mgr_Ubicacion_Test

    ''' <summary>
    ''' Metodo que retorna un objeto de tipo ubicacion
    ''' </summary>
    Public Shared Function Get_Ubicacion1(ByRef _Articulo As Articulo) As Ubicacion

        Dim _Nuevo = New Ubicacion With {
            .zona = "zo1",
            .estante = "es1",
            .fila = "fi1",
            .columna = "co1",
            .panel = "pa1",
            .referencia_ubicacion = "referencia_ubicacion1",
            .id_articulo = _Articulo.id_articulo
        }
        Return _Nuevo

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto para guardarlo en la base de datos
    ''' </summary>
    Public Shared Sub Inicializar(ByRef _Articulo As Articulo, ByRef _Almacen As Almacen,
        ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad, ByRef _Cliente As Cliente,
        ByRef _Ubicacion As Ubicacion)

        Mgr_Articulo_Test.Inicializar(_Articulo, _Almacen, _Tipo_Facturacion, _Tipo_Unidad, _Cliente)
        Mgr_Ubicacion.Guardar(_Ubicacion)

    End Sub

End Class
