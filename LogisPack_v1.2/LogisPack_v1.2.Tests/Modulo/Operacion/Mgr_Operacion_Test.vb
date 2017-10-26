
Imports CapaDatos

Public Class Mgr_Operacion_Test

    ''' <summary>
    ''' Metodo que retorna un objeto de tipo operacion de entrada
    ''' </summary>
    Public Shared Function Get_Operacion(ByRef _Articulo As Articulo, tipoOperacion As String) As Historico

        Dim _Historico As New Historico With {
            .fecha_transaccion = "2000-01-01 00:00:00.000",
            .tipo_transaccion = tipoOperacion,
            .referencia_ubicacion = "Ref_Ubi",
            .cantidad_transaccion = "50",
            .id_articulo = _Articulo.id_articulo,
            .documento_transaccion = "Url/Prueba"
        }

        Return _Historico

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto de tipo Articulo, Historico y tipo de operacion y los guarda en la base de datos
    ''' </summary>
    Public Shared Sub Inicializar(ByRef _Articulo As Articulo, ByRef _Historico As Historico, tipoOperacion As String)

        _Historico = Get_Operacion(_Articulo, tipoOperacion)
        Mgr_Historico.Guardar(_Historico)

    End Sub

    ''' <summary>
    ''' Metodo que recibe un objeto de tipo cliente, tipo de unidad y tipo de facturacion y los elimina en la base de datos
    ''' </summary>
    Public Shared Sub Finalizar(ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad,
            ByRef _Cliente As Cliente, ByRef _Historico As Historico)

        Mgr_Cliente.Eliminar(_Cliente.id_cliente)
        Mgr_TipoFacturacion.Eliminar(_Tipo_Facturacion.id_tipo_facturacion)
        Mgr_TipoUnidad.Eliminar(_Tipo_Unidad.id_tipo_unidad)
        Mgr_Historico.Eliminar(_Historico.id_historico)

    End Sub

End Class
