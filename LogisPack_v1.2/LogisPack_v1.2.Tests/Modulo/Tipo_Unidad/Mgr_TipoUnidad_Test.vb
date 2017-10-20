
Imports CapaDatos

Public Class Mgr_TipoUnidad_Test

    Public Shared Function Get_Tipo_Unidad1() As Tipo_Unidad

        Dim _Nuevo = New Tipo_Unidad With {
            .nombre = "Nombrev1"
        }

        Return _Nuevo

    End Function

    Public Shared Sub Inicializar(ByRef _Tipo_Unidad As Tipo_Unidad)
        Mgr_TipoUnidad.Guardar(_Tipo_Unidad)
    End Sub

    Public Shared Sub Finalizar(ByRef _Tipo_Unidad As Tipo_Unidad)
        Mgr_TipoUnidad.Eliminar(_Tipo_Unidad.id_tipo_unidad)
    End Sub

End Class
