

Imports CapaDatos

Public Class Mgr_Cliente_Test

    Public Shared Function Get_Cliente1() As Cliente

        Dim Cliente1 = New Cliente With {
            .codigo = "Codv1",
            .nombre = "Nombrev1"
        }

        Return Cliente1

    End Function

    Public Shared Sub Inicializar(ByRef _Cliente As Cliente)

        Mgr_Cliente.Guardar(_Cliente)

    End Sub

    Public Shared Sub Finalizar(ByRef _Cliente As Cliente)

        Mgr_Cliente.Eliminar(_Cliente.id_cliente)

    End Sub



End Class
