Imports System.Web.UI.WebControls

Public Class Mgr_Imagen

    Structure struct_Imagen
        Public nombre As String
        Public id_articulo As String
        Public url_imagen As String
    End Structure

    '------------------------Funciones de la clase imagen
    ''' <summary>
    ''' Metodo que recibe un objeto Imagen y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Guardar(ByVal _nuevo As Imagen) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Imagen.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe el objeto Tipo de Imagen a Actualizar y el contexto en que fue creado, devuelve true si fue
    ''' exitosa la actualización, en caso contrario devuelve false
    ''' </summary>
    Public Shared Function Editar(_Edit As Imagen, ByRef contexto As LogisPackEntities) As Boolean

        Try
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un id de la Imagen y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Eliminar(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim _Eliminar As New Imagen With {
                .id_imagen = _id
            }
            contexto.Imagen.Attach(_Eliminar)
            contexto.Imagen.Remove(_Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que devuelve una variable de tipo estructura con el cuerpo de la clase imagen
    ''' </summary>
    Public Shared Function Get_Struct() As struct_Imagen

        Dim _mistruct As struct_Imagen = Nothing
        Return _mistruct

    End Function

    ''' <summary>
    ''' Metodo que recibe un array de string y retorna un objeto imagen
    ''' </summary>
    Public Shared Function Crear_Objeto(_imagen As struct_Imagen) As Imagen

        Dim _Nuevo As New Imagen With
            {
            .nombre = _imagen.nombre,
            .id_articulo = _imagen.id_articulo,
            .url_imagen = _imagen.url_imagen
        }

        Return _Nuevo

    End Function

    '------------------------Funciones Grid
    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos de la imagen en la base de datos
    ''' </summary>
    Public Shared Sub LlenarGrid(ByRef GridView1 As GridView, id As Integer)

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

    '------------------------Funciones Getter

    ''' <summary>
    ''' Metodo que recibe un id del Artiuclo, y devuelve una lista de las imagenes asociadas al articulo
    ''' </summary>
    Public Shared Function Get_Imagen_list(id As Integer) As List(Of Imagen)
        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Imagen.Where(Function(model) model.id_articulo = id).ToList()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id de la imagen, y devuelve la imagene asociadas al articulo
    ''' </summary>
    Public Shared Function Get_Imagen(id As Integer) As Imagen
        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Imagen.Where(Function(model) model.id_imagen = id).SingleOrDefault()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id de la Imagen y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver la Imagen a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Imagen si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Imagen(id As Integer, ByRef contexto As LogisPackEntities) As Imagen

        Return contexto.Imagen.Where(Function(model) model.id_imagen = id).SingleOrDefault()

    End Function

End Class
