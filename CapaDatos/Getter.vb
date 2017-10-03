
Public Class Getter

    ''' <summary>
    ''' Metodo que recibe un id del Almacen y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Almacen si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Almacen(id As Integer) As Almacen

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Almacen.Where(Function(model) model.id_almacen = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Almacen y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Almacen a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Almacen si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Almacen(id As Integer, ByRef contexto As LogisPackEntities) As Almacen
        Return contexto.Almacen.Where(Function(model) model.id_almacen = id).SingleOrDefault()
    End Function

    ''' <summary>
    ''' Metodo que devuelve el ultimo Articulo registrado en la base de datos
    ''' </summary>
    Public Shared Function Articulo_Ultimo() As Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.ToList().LastOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, 
    ''' devuelve una lista de objetos de tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Articulo_list(id As Integer) As List(Of Articulo)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.Where(Function(model) model.id_articulo = id).ToList()

    End Function

    Public Shared Function Articulo_Codigo(_codigo As String) As Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Articulo.Where(Function(model) model.codigo = _codigo).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, 
    ''' devuelve una lista de objetos de tipo Articulo que estan asociados a un articulo picking 
    ''' si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Picking_Articulo_list(id As Integer) As List(Of Picking_Articulo)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Picking_Articulo.Where(Function(model) model.id_picking = id).ToList()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, 
    ''' devuelve un  objeto de tipo Articulo que estan asociados a un articulo picking 
    ''' si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Picking_Articulo(id As Integer) As Picking_Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Picking_Articulo.Where(Function(model) model.id_picking_articulo = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el ArticuloPicking a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Picking_Articulo(id As Integer, ByRef contexto As LogisPackEntities) As Picking_Articulo
        Return contexto.Picking_Articulo.Where(Function(model) model.id_picking_articulo = id).SingleOrDefault()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Articulo(id As Integer) As Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.Where(Function(model) model.id_articulo = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Articulo a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Articulo(id As Integer, ByRef contexto As LogisPackEntities) As Articulo
        Return contexto.Articulo.Where(Function(model) model.id_articulo = id).SingleOrDefault()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Cliente y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Cliente si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Cliente(id As Integer) As Cliente

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Cliente.Where(Function(model) model.id_cliente = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Cliente y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Cliente a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Cliente si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Cliente(id As Integer, ByRef contexto As LogisPackEntities) As Cliente

        Return contexto.Cliente.Where(Function(model) model.id_cliente = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Facturacion y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Tipo_Facturacion si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Tipo_Facturacion(id As Integer) As Tipo_Facturacion

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Facturacion.Where(Function(model) model.id_tipo_facturacion = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Facturacion y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Tipo_Facturacion a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Tipo_Facturacion si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Tipo_Facturacion(id As Integer, ByRef contexto As LogisPackEntities) As Tipo_Facturacion

        Return contexto.Tipo_Facturacion.Where(Function(model) model.id_tipo_facturacion = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Unidad y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Tipo_Unidad si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Tipo_Unidad(id As Integer) As Tipo_Unidad

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Unidad.Where(Function(model) model.id_tipo_unidad = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Unidad y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Tipo_Unidad a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Tipo_Unidad si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Tipo_Unidad(id As Integer, ByRef contexto As LogisPackEntities) As Tipo_Unidad

        Return contexto.Tipo_Unidad.Where(Function(model) model.id_tipo_unidad = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Artiuclo, y devuelve una lista de las imagenes asociadas al articulo
    ''' </summary>
    Public Shared Function Imagen_list(id As Integer) As List(Of Imagen)
        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Imagen.Where(Function(model) model.id_articulo = id).ToList()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id de la imagen, y devuelve la imagene asociadas al articulo
    ''' </summary>
    Public Shared Function Imagen(id As Integer) As Imagen
        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Imagen.Where(Function(model) model.id_imagen = id).SingleOrDefault()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id de la Imagen y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver la Imagen a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Imagen si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Imagen(id As Integer, ByRef contexto As LogisPackEntities) As Imagen

        Return contexto.Imagen.Where(Function(model) model.id_imagen = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Artiuclo, y devuelve una lista de las ubicaciones asociadas al articulo
    ''' </summary>
    Public Shared Function Ubicacion_list(id As Integer) As List(Of Ubicacion)
        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Ubicacion.Where(Function(model) model.id_articulo = id).ToList()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Artiuclo, y devuelve una la ubicaciones asociadas al articulo
    ''' </summary>
    Public Shared Function Ubicacion(id As Integer) As Ubicacion
        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Ubicacion.Where(Function(model) model.id_ubicacion = id).SingleOrDefault()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id de la ubicacion y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver la ubicacion a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo ubicacion si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Ubicacion(id As Integer, ByRef contexto As LogisPackEntities) As Ubicacion

        Return contexto.Ubicacion.Where(Function(model) model.id_ubicacion = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del usuario y lo consulta desde la Base de datos, 
    ''' devuelve el id del cliente asociado al usuario si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Cliente_Usuario(_id As String) As Integer

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim _usuario = contexto.AspNetUsers.Where(Function(model) model.Id = _id).SingleOrDefault()

        Return _usuario.id_cliente

    End Function
End Class
