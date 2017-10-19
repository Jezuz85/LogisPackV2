Imports System.Globalization
Imports System.Web.UI.WebControls

Public Class Mgr_Almacen

    Structure struct_Almacen
        Public nombre As String
        Public codigo As String
        Public coeficiente_volumetrico As String
        Public id_cliente As String
    End Structure

    '------------------------FUNCIONES DEL GRID
    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del almacen en la base de datos
    ''' </summary>
    Public Shared Sub Llenar_Grid(ByRef GridView1 As GridView, idCliente As Integer, columna As String, tipoOrdenacion As String,
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

        If columna = Val_Almacen.Filtro_Codigo.ToString Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.codigo).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.codigo).ToList()
            End If

        End If
        If columna = Val_Almacen.Filtro_Nombre.ToString Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.nombre).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.nombre).ToList()
            End If

        End If
        If columna = Val_Almacen.Filtro_Cliente.ToString Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.cliente).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.cliente).ToList()
            End If

        End If
        If columna = Val_Almacen.Filtro_Coeficiente.ToString Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.coeficiente_volumetrico).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.coeficiente_volumetrico).ToList()
            End If

        End If

        If textoBusqueda <> String.Empty Then
            If filtroBusqueda = Val_Almacen.Filtro_Nombre.ToString Then
                query = query.Where(Function(x) x.nombre.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = Val_Almacen.Filtro_Cliente.ToString Then
                query = query.Where(Function(x) x.cliente.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = Val_Almacen.Filtro_Codigo.ToString Then
                query = query.Where(Function(x) x.codigo.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = Val_Almacen.Filtro_Coeficiente.ToString Then
                query = query.Where(Function(x) x.coeficiente_volumetrico = textoBusqueda).ToList()
            End If
        End If

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    '------------------------FUNCIONES DEL DROPDOWNLIST
    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio y lo devuelve con los datos de todos los alamcenes
    ''' existentes en la base de datos
    ''' </summary>
    Public Shared Sub Llenar_Lista(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Almacen
                     Select
                         AL.id_almacen,
                         AL.nombre
                    ).ToList()

        Util_ControlesDinamicos.Set_Text_Value_List(DropDownList1, query, Val_Almacen.Nom_Alm.ToString, Val_Almacen.Id_Alm.ToString)

        DropDownList1.Items.Insert(0, New ListItem(Val_General.Lista_Seleccione.ToString, String.Empty))

    End Sub

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio y un id del cliente , y lo devuelve con los datos de 
    ''' todos los alamcenes de ese cliente
    ''' </summary>
    Public Shared Sub Llenar_Lista(ByRef DropDownList1 As DropDownList, idCliente As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Almacen
                     Where AL.id_cliente = idCliente
                     Select
                         AL.id_almacen,
                         AL.nombre
                    ).ToList()


        Util_ControlesDinamicos.Set_Text_Value_List(DropDownList1, query, Val_Almacen.Nom_Alm.ToString, Val_Almacen.Id_Alm.ToString)

        DropDownList1.Items.Insert(0, New ListItem(Val_General.Lista_Seleccione.ToString, String.Empty))
    End Sub


    '------------------------FUNCIONES DE LA CLASE ALMACEN
    ''' <summary>
    ''' Metodo que recibe un objeto Almacen y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Guardar(ByVal _nuevo As Almacen) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Almacen.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe el objeto Almacen a Actualizar y el contexto en que fue creado, devuelve true si fue
    ''' exitosa la actualización, en caso contrario devuelve false
    ''' </summary>
    Public Shared Function Editar(_Edit As Almacen, ByRef contexto As LogisPackEntities) As Boolean

        Try
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Almacen y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Eliminar(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim _Eliminar As New Almacen With {
                .id_almacen = _id
            }
            contexto.Almacen.Attach(_Eliminar)
            contexto.Almacen.Remove(_Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Almacen y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Almacen si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Consultar(id As Integer) As Almacen

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Almacen.Where(Function(model) model.id_almacen = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Almacen y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Almacen a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Almacen si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Consultar(id As Integer, ByRef contexto As LogisPackEntities) As Almacen
        Return contexto.Almacen.Where(Function(model) model.id_almacen = id).SingleOrDefault()
    End Function

    ''' <summary>
    ''' Metodo que recibe un array de string y retorna un objeto almacen
    ''' </summary>
    Public Shared Function Crear_Objeto(_almacen As struct_Almacen) As Almacen

        Dim _Nuevo As New Almacen With {
                .nombre = _almacen.nombre,
                .codigo = _almacen.codigo,
                .coeficiente_volumetrico = Double.Parse(_almacen.coeficiente_volumetrico, CultureInfo.InvariantCulture),
                .id_cliente = Convert.ToInt32(_almacen.id_cliente)
            }

        Return _Nuevo
    End Function

    ''' <summary>
    ''' Metodo que devuelve una variable de tipo estructura con el cuerpo de la clase almacen
    ''' </summary>
    Public Shared Function Get_Struct() As struct_Almacen

        Dim _mialmacen As struct_Almacen = Nothing

        Return _mialmacen
    End Function

End Class
