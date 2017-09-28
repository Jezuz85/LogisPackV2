Imports System.Web.UI.WebControls

Public Class Tabla

    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del almacen en la base de datos
    ''' </summary>
    Public Shared Sub Almacen(ByRef GridView1 As GridView, idCliente As Integer, columna As String, tipoOrdenacion As String,
                              filtroBusqueda As String, textoBusqueda As String)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Almacen
                     Select
                         AL.id_almacen,
                         AL.nombre,
                         AL.id_cliente,
                         AL.codigo,
                         cliente = AL.Cliente.nombre,
                         AL.coeficiente_volumetrico
                    ).ToList()

        If idCliente <> 1 Then
            query = query.Where(Function(x) x.id_cliente = idCliente).ToList()
        End If

        If columna = "codigo" Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.codigo).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.codigo).ToList()
            End If

        End If
        If columna = "Nombre" Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.nombre).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.nombre).ToList()
            End If

        End If
        If columna = "Cliente" Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.cliente).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.cliente).ToList()
            End If

        End If
        If columna = "Coeficiente" Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.coeficiente_volumetrico).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.coeficiente_volumetrico).ToList()
            End If

        End If

        If textoBusqueda <> String.Empty Then
            If filtroBusqueda = "Nombre" Then
                query = query.Where(Function(x) x.nombre.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = "Cliente" Then
                query = query.Where(Function(x) x.cliente.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = "codigo" Then
                query = query.Where(Function(x) x.codigo.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            End If
        End If

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del articulo en la base de datos
    ''' </summary>
    Public Shared Sub Articulo(ByRef GridView1 As GridView, idCliente As Integer, columna As String, tipoOrdenacion As String,
                              filtroBusqueda As String, textoBusqueda As String)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Select
                         AL.id_articulo,
                         AL.Almacen.id_cliente,
                         AL.nombre,
                         AL.codigo,
                         Cliente = AL.Almacen.Cliente.nombre,
                         Almacen = AL.Almacen.nombre
                    ).ToList()

        If idCliente <> 1 Then
            query = query.Where(Function(x) x.id_cliente = idCliente).ToList()
        End If

        If columna = "Nombre" Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.nombre).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.nombre).ToList()
            End If
        ElseIf columna = "Codigo" Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.codigo).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.codigo).ToList()
            End If
        ElseIf columna = "Almacen" Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.Almacen).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.Almacen).ToList()
            End If
        ElseIf columna = "Cliente" Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.Cliente).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.Cliente).ToList()
            End If
        End If

        If textoBusqueda <> String.Empty Then
            If filtroBusqueda = "Nombre" Then
                query = query.Where(Function(x) x.nombre.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = "Codigo" Then
                query = query.Where(Function(x) x.codigo.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = "Almacen" Then
                query = query.Where(Function(x) x.Almacen.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = "Cliente" Then
                query = query.Where(Function(x) x.Cliente.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            End If
        End If

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del cliente en la base de datos
    ''' </summary>
    Public Shared Sub Cliente(ByRef GridView1 As GridView, idCliente As Integer, columna As String, tipoOrdenacion As String,
                              filtroBusqueda As String, textoBusqueda As String)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Cliente
                     Select
                         AL.id_cliente,
                         AL.codigo,
                         AL.nombre
                    ).ToList()

        If idCliente <> 1 Then
            query = query.Where(Function(x) x.id_cliente = idCliente).ToList()
        End If

        If columna = "nombre" Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.nombre).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.nombre).ToList()
            End If

        ElseIf columna = "codigo" Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.codigo).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.codigo).ToList()
            End If

        End If

        If textoBusqueda <> String.Empty Then
            If filtroBusqueda = "Nombre" Then
                query = query.Where(Function(x) x.nombre.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = "Codigo" Then
                query = query.Where(Function(x) x.codigo.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            End If
        End If

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del tipo de facturacion en la base de datos
    ''' </summary>
    Public Shared Sub TipoFacturacion(ByRef GridView1 As GridView, columna As String, tipoOrdenacion As String,
                              filtroBusqueda As String, textoBusqueda As String)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Tipo_Facturacion
                     Select
                         AL.id_tipo_facturacion,
                         AL.nombre
                    ).ToList()

        If columna = "nombre" Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.nombre).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.nombre).ToList()
            End If
        End If

        If textoBusqueda <> String.Empty Then
            If filtroBusqueda = "Nombre" Then
                query = query.Where(Function(x) x.nombre.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            End If
        End If

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del tipo de unidad en la base de datos
    ''' </summary>
    Public Shared Sub TipoUnidad(ByRef GridView1 As GridView, columna As String, tipoOrdenacion As String,
                              filtroBusqueda As String, textoBusqueda As String)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Tipo_Unidad
                     Select
                         AL.id_tipo_unidad,
                         AL.nombre
                    ).ToList()
        If columna = "nombre" Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.nombre).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.nombre).ToList()
            End If
        End If

        If textoBusqueda <> String.Empty Then
            If filtroBusqueda = "Nombre" Then
                query = query.Where(Function(x) x.nombre.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            End If
        End If

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos de la imagen en la base de datos
    ''' </summary>
    Public Shared Sub Imagen(ByRef GridView1 As GridView, id As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Imagen
                     Where AL.id_articulo = id
                     Select
                         AL.id_imagen,
                         AL.nombre,
                         AL.url_imagen
                    ).ToList()

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos de el historico en la base de datos
    ''' </summary>
    Public Shared Sub Historico(ByRef GridView1 As GridView, idCliente As Integer, columna As String, tipoOrdenacion As String,
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
                         AL.Articulo.Almacen.id_cliente
                    ).ToList()

        If idCliente <> 1 Then
            query = query.Where(Function(x) x.id_cliente = idCliente).ToList()
        End If

        If columna = "fecha_transaccion" Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.fecha_transaccion).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.fecha_transaccion).ToList()
            End If
        ElseIf columna = "articulo" Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.articulo).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.articulo).ToList()
            End If
        ElseIf columna = "tipo_transaccion" Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.tipo_transaccion).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.tipo_transaccion).ToList()
            End If
        ElseIf columna = "cantidad_transaccion" Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.cantidad_transaccion).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.cantidad_transaccion).ToList()
            End If
        End If

        If textoBusqueda <> String.Empty Then
            If filtroBusqueda = "articulo" Then
                query = query.Where(Function(x) x.articulo.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            End If
        End If

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del articulo picking en la base de datos
    ''' </summary>
    Public Shared Sub ArticuloPicking(ByRef GridView1 As GridView, idPicking As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Picking_Articulo
                     Where AL.id_picking = idPicking
                     Select
                         AL.id_articulo,
                         Cantidad = AL.unidades,
                         Articulo = AL.Articulo.nombre,
                         AL.Articulo.tipoArticulo
                    ).ToList()

        query = query.Where(Function(x) x.tipoArticulo = "Normal").ToList()

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

End Class
