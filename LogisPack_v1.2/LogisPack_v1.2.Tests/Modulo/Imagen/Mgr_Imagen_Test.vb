
Imports CapaDatos

Public Class Mgr_Imagen_Test

    ''' <summary>
    ''' Metodo que retorna un objeto de tipo imagen
    ''' </summary>
    Public Shared Function Get_Imagen1(ByRef _Articulo As Articulo) As Imagen

        Dim _Imagen = New Imagen With {
            .nombre = "nombre1",
            .url_imagen = "url_imagen1",
            .id_articulo = _Articulo.id_articulo
        }

        Return _Imagen

    End Function
    ''' <summary>
    ''' Metodo que recibe un objeto para guardarlo en la base de datos
    ''' </summary>
    Public Shared Sub Inicializar(ByRef _Articulo As Articulo, ByRef _Almacen As Almacen,
        ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad, ByRef _Cliente As Cliente,
        ByRef _Imagen As Imagen)

        Mgr_Articulo_Test.Inicializar(_Articulo, _Almacen, _Tipo_Facturacion, _Tipo_Unidad, _Cliente)
        Mgr_Imagen.Guardar(_Imagen)

    End Sub

End Class
