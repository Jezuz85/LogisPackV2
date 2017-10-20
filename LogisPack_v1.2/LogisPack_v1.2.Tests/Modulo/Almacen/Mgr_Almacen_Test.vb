
Imports CapaDatos

Public Class Mgr_Almacen_Test


    Public Shared Function Get_Almacen1(ByRef _Cliente As Cliente) As Almacen

        Dim Almacen1 = New Almacen With {
        .nombre = "Nombrev1",
        .codigo = "Codv1",
        .coeficiente_volumetrico = "10",
        .id_cliente = _Cliente.id_cliente
        }

        Return Almacen1

    End Function


    Public Shared Sub Inicializar(ByRef _Cliente As Cliente, ByRef _Almacen As Almacen)

        Mgr_Cliente_Test.Inicializar(_Cliente)
        Mgr_Almacen.Guardar(_Almacen)

    End Sub


End Class
