
Imports CapaDatos

Public Class Mgr_Almacen_Test

    ''' <summary>
    ''' Metodo que recibe un objeto de tipo cliente y retorna un objeto de tipo Almacen asociado al cliente recibido
    ''' </summary>
    Public Shared Function Get_Almacen1(ByRef _Cliente As Cliente) As Almacen

        Dim Almacen1 = New Almacen With {
        .nombre = "Nombrev1",
        .codigo = "Codv1",
        .coeficiente_volumetrico = "123",
        .id_cliente = _Cliente.id_cliente
        }

        Return Almacen1

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto de tipo cliente y un objeto de tipo Almacen y los guarda en la base de datos
    ''' </summary>
    Public Shared Sub Inicializar(ByRef _Cliente As Cliente, ByRef _Almacen As Almacen)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Mgr_Cliente_Test.Inicializar(_Cliente)

        _Almacen = Get_Almacen1(_Cliente)

        If Mgr_Almacen.Guardar(_Almacen) Then
            _Almacen = Mgr_Almacen.Get_Almacen_Ultimo()
        End If

    End Sub

End Class
