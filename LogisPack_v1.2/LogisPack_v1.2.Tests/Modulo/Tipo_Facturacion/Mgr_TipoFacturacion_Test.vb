
Imports CapaDatos

Public Class Mgr_TipoFacturacion_Test

    ''' <summary>
    ''' Metodo que retorna un objeto de tipo TipoFacturacion
    ''' </summary>
    Public Shared Function Get_TipoFacturacion1() As Tipo_Facturacion

        Dim _Nuevo = New Tipo_Facturacion With {
            .nombre = "Nombrev1"
        }

        Return _Nuevo

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto para guardarlo en la base de datos
    ''' </summary>
    Public Shared Sub Inicializar(ByRef _Nuevo As Tipo_Facturacion)
        Mgr_TipoFacturacion.Guardar(_Nuevo)
    End Sub

    ''' <summary>
    ''' Metodo que recibe un objeto  y lo elimina en la base de datos
    ''' </summary>
    Public Shared Sub Finalizar(ByRef _Nuevo As Tipo_Facturacion)
        Mgr_TipoFacturacion.Eliminar(_Nuevo.id_tipo_facturacion)
    End Sub


End Class
