
Public Class Getter



    '-----------------------------------------Cliente--------------------------------------------------------'

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

    '-----------------------------------------tipo Facturacion--------------------------------------------------------'

    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Facturacion y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Tipo_Facturacion si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Tipo_Facturacion(id As Integer) As Tipo_Facturacion

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Facturacion.Where(Function(model) model.id_tipo_facturacion = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un nombre del Tipo_Facturacion y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Tipo_Facturacion si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Tipo_Facturacion(_nombre As String) As Tipo_Facturacion

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Facturacion.Where(Function(model) model.nombre = _nombre).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Facturacion y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Tipo_Facturacion a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Tipo_Facturacion si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Tipo_Facturacion(id As Integer, ByRef contexto As LogisPackEntities) As Tipo_Facturacion

        Return contexto.Tipo_Facturacion.Where(Function(model) model.id_tipo_facturacion = id).SingleOrDefault()

    End Function

    '-----------------------------------------Tipo unidad--------------------------------------------------------'

    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Unidad y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Tipo_Unidad si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Tipo_Unidad(id As Integer) As Tipo_Unidad

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Unidad.Where(Function(model) model.id_tipo_unidad = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un nombre del Tipo_Unidad y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Tipo_Unidad si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Tipo_Unidad(_nombre As String) As Tipo_Unidad

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Unidad.Where(Function(model) model.nombre = _nombre).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Unidad y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Tipo_Unidad a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Tipo_Unidad si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Tipo_Unidad(id As Integer, ByRef contexto As LogisPackEntities) As Tipo_Unidad

        Return contexto.Tipo_Unidad.Where(Function(model) model.id_tipo_unidad = id).SingleOrDefault()

    End Function

    '-----------------------------------------Imagen--------------------------------------------------------'

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

    '-----------------------------------------Ubicacion--------------------------------------------------------'

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

    '-----------------------------------------Usuario--------------------------------------------------------'

    ''' <summary>
    ''' Metodo que recibe un id del usuario y lo consulta desde la Base de datos, 
    ''' devuelve el id del cliente asociado al usuario si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Cliente_Usuario(_id As String) As Integer

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim _usuario = contexto.AspNetUsers.Where(Function(model) model.Id = _id).SingleOrDefault()

        Return _usuario.id_cliente

    End Function

    '-----------------------------------------Histórico--------------------------------------------------------'
    Public Shared Function Operacion_TotalEntrada(_id_articulo As String) As Double

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim _usuario = contexto.Historico.Where(Function(model) model.id_articulo = _id_articulo And model.tipo_transaccion = "Ent").ToList()

        Return _usuario.Sum(Function(model) model.cantidad_transaccion)

    End Function

    Public Shared Function Operacion_TotalSalida(_id_articulo As String) As Double

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim _usuario = contexto.Historico.Where(Function(model) model.id_articulo = _id_articulo And model.tipo_transaccion = "Sal").ToList()

        Return _usuario.Sum(Function(model) model.cantidad_transaccion)

    End Function
End Class
