
Imports CapaDatos

Public Class Mgr_Cliente_Test

    ''' <summary>
    ''' Metodo que retorna un objeto de tipo cliente
    ''' </summary>
    Public Shared Function Get_Cliente1() As Cliente

        Dim Cliente1 = New Cliente With {
            .codigo = "Codv1",
            .nombre = "Nombrev1"
        }


        Return Cliente1

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto para guardarlo en la base de datos
    ''' </summary>
    Public Shared Sub Inicializar(ByRef _Cliente As Cliente)

        Mgr_Cliente.Guardar(_Cliente)

    End Sub

    ''' <summary>
    ''' Metodo que recibe un objeto  y lo elimina en la base de datos
    ''' </summary>
    Public Shared Sub Finalizar(ByRef _Cliente As Cliente)

        Mgr_Cliente.Eliminar(_Cliente.id_cliente)

    End Sub

End Class
