Imports System.Web.UI.WebControls

Public Class Mgr_Historico



    ''' <summary>
    ''' Metodo que recibe un objeto Historico y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Guardar(ByVal _nuevo As Historico) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Historico.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    '------------------------FUNCIONES GETTER
    Public Shared Function Get_Operacion_TotalEntrada(_id_articulo As String) As Double

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim _usuario = contexto.Historico.Where(Function(model) model.id_articulo = _id_articulo And model.tipo_transaccion = "Ent").ToList()

        Return _usuario.Sum(Function(model) model.cantidad_transaccion)

    End Function

    Public Shared Function Get_Operacion_TotalSalida(_id_articulo As String) As Double

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim _usuario = contexto.Historico.Where(Function(model) model.id_articulo = _id_articulo And model.tipo_transaccion = "Sal").ToList()

        Return _usuario.Sum(Function(model) model.cantidad_transaccion)

    End Function


    '------------------------FUNCIONES GRID
    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos de el historico en la base de datos
    ''' </summary>
    Public Shared Sub LlenarGrid(ByRef GridView1 As GridView, idCliente As Integer, columna As String, tipoOrdenacion As String,
                              filtroBusqueda As String, textoBusqueda As String)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Historico
                     Select
                         AL.id_historico,
                         AL.fecha_transaccion,
                         articulo = AL.Articulo.nombre,
                         AL.documento_transaccion,
                         AL.cantidad_transaccion,
                         AL.tipo_transaccion,
                         AL.referencia_ubicacion,
                         AL.Articulo.Almacen.id_cliente,
                         almacen = AL.Articulo.Almacen.nombre,
                         cliente = AL.Articulo.Almacen.Cliente.nombre
                    ).ToList()

        If idCliente <> 1 Then
            query = query.Where(Function(x) x.id_cliente = idCliente).ToList()
        End If

        If columna = Val_Operacion.Col_Fecha_Transaccion.ToString Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.fecha_transaccion).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.fecha_transaccion).ToList()
            End If
        ElseIf columna = Val_Operacion.Col_Articulo.ToString Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.articulo).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.articulo).ToList()
            End If
        ElseIf columna = Val_Operacion.Col_Tipo_Transaccion.ToString Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.tipo_transaccion).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.tipo_transaccion).ToList()
            End If
        ElseIf columna = Val_Operacion.Col_Cantidad_Transaccion.ToString Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.cantidad_transaccion).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.cantidad_transaccion).ToList()
            End If
        End If

        If textoBusqueda <> String.Empty Then
            If filtroBusqueda = Val_Operacion.Filtro_Articulo.ToString Then
                query = query.Where(Function(x) x.articulo.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = Val_Operacion.Filtro_Almacen.ToString Then
                query = query.Where(Function(x) x.almacen.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = Val_Operacion.Filtro_Cliente.ToString Then
                query = query.Where(Function(x) x.cliente.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            End If
        End If

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

End Class
