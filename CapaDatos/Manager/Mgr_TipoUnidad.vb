Imports System.Web.UI.WebControls

Public Class Mgr_TipoUnidad

    '------------------------Funciones de la clase tipo unidad
    ''' <summary>
    ''' Metodo que recibe un objeto Tipo Unidad y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Guardar(ByVal _nuevo As Tipo_Unidad) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Tipo_Unidad.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe el objeto Tipo de Unidad a Actualizar y el contexto en que fue creado, devuelve true si fue
    ''' exitosa la actualización, en caso contrario devuelve false
    ''' </summary>
    Public Shared Function Editar(_Edit As Tipo_Unidad, ByRef contexto As LogisPackEntities) As Boolean

        Try
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function


    ''' <summary>
    ''' Metodo que recibe un id del Tipo de Unidad y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Eliminar(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Try
            Dim _Eliminar As New Tipo_Unidad With {
                .id_tipo_unidad = _id
            }
            contexto.Tipo_Unidad.Attach(_Eliminar)
            contexto.Tipo_Unidad.Remove(_Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function


    '------------------------Funciones GETTER
    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Unidad y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Tipo_Unidad si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Tipo_Unidad(id As Integer) As Tipo_Unidad

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Unidad.Where(Function(model) model.id_tipo_unidad = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un nombre del Tipo_Unidad y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Tipo_Unidad si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Tipo_Unidad(_nombre As String) As Tipo_Unidad

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Unidad.Where(Function(model) model.nombre = _nombre).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Unidad y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Tipo_Unidad a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Tipo_Unidad si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Tipo_Unidad(id As Integer, ByRef contexto As LogisPackEntities) As Tipo_Unidad

        Return contexto.Tipo_Unidad.Where(Function(model) model.id_tipo_unidad = id).SingleOrDefault()

    End Function


    '------------------------FUNCIONES DEL DROPDOWNLIST
    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los tipo de unidad existentes en la base de datos
    ''' </summary>
    Public Shared Sub LlenarLista(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Tipo_Unidad
                     Select
                         AL.id_tipo_unidad,
                         AL.nombre
                    ).ToList()

        DropDownList1.DataValueField = "id_tipo_unidad"
        DropDownList1.DataTextField = "nombre"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
        DropDownList1.Items.Insert(0, New ListItem(Val_General.Lista_Seleccione.ToString, String.Empty))
    End Sub


    '------------------------Funciones Grid
    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del tipo de unidad en la base de datos
    ''' </summary>
    Public Shared Sub LlenarGrid(ByRef GridView1 As GridView, columna As String, tipoOrdenacion As String,
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


End Class
