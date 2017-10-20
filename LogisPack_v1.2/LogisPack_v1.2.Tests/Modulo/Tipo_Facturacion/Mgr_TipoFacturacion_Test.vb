
Imports CapaDatos

Public Class Mgr_TipoFacturacion_Test

    Public Shared Function Get_TipoFacturacion1() As Tipo_Facturacion

        Dim _Nuevo = New Tipo_Facturacion With {
            .nombre = "Nombrev1"
        }

        Return _Nuevo

    End Function

    Public Shared Sub Inicializar(ByRef _Nuevo As Tipo_Facturacion)
        Mgr_TipoFacturacion.Guardar(_Nuevo)
    End Sub

    Public Shared Sub Finalizar(ByRef _Nuevo As Tipo_Facturacion)
        Mgr_TipoFacturacion.Eliminar(_Nuevo.id_tipo_facturacion)
    End Sub


End Class
