
Imports System.Web.UI.WebControls

Public Class Mgr_Cliente

    '------------------------------------------------------------------
    '------------------------FUNCIONES DEL GRID------------------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del cliente en la base de datos
    ''' </summary>
    Public Shared Sub LlenarGrid(ByRef GridView1 As GridView, idCliente As Integer, columna As String, tipoOrdenacion As String,
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

        If columna = Val_Cliente.Filtro_Nombre.ToString Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.nombre).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.nombre).ToList()
            End If

        ElseIf columna = Val_Cliente.Filtro_Codigo.ToString Then

            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.codigo).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.codigo).ToList()
            End If

        End If

        If textoBusqueda <> String.Empty Then
            If filtroBusqueda = Val_Cliente.Filtro_Nombre.ToString Then
                query = query.Where(Function(x) x.nombre.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = Val_Cliente.Filtro_Codigo.ToString Then
                query = query.Where(Function(x) x.codigo.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            End If
        End If

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    '------------------------------------------------------------------
    '------------------------FUNCIONES DEL DROPDOWNLIST----------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los clientes existentes en la base de datos
    ''' </summary>
    Public Shared Sub Llenar_Lista(ByRef DropDownList1 As DropDownList, idCliente As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        DropDownList1.DataValueField = "id_cliente"
        DropDownList1.DataTextField = "nombre"

        Dim query = (From CL In contexto.Cliente Select CL.id_cliente, CL.nombre).ToList()

        If idCliente <> 1 Then
            query = (From CL In contexto.Cliente Where CL.id_cliente = idCliente Select CL.id_cliente, CL.nombre).ToList()
        End If

        DropDownList1.DataSource = query
        DropDownList1.DataBind()

        DropDownList1.Items.Insert(0, New ListItem(Val_General.Lista_Seleccione.ToString, String.Empty))
    End Sub

    '------------------------------------------------------------------
    '------------------------FUNCIONES DE LA CLASE CLIENTE------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que recibe un objeto Cliente y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Guardar(ByVal _nuevo As Cliente) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Cliente.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Cliente y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Eliminar(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim _Eliminar As New Cliente With {
                .id_cliente = _id
            }
            contexto.Cliente.Attach(_Eliminar)
            contexto.Cliente.Remove(_Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe el objeto Cliente a Actualizar y el contexto en que fue creado, devuelve true si fue
    ''' exitosa la actualización, en caso contrario devuelve false
    ''' </summary>
    Public Shared Function Editar(_Edit As Cliente, ByRef contexto As LogisPackEntities) As Boolean

        Try
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    '------------------------------------------------------------------
    '------------------------FUNCIONES GETTER--------------------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que recibe un id del Cliente y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Cliente si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Cliente(id As Integer) As Cliente

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Cliente.Where(Function(model) model.id_cliente = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Cliente y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Cliente a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Cliente si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Cliente(id As Integer, ByRef contexto As LogisPackEntities) As Cliente

        Return contexto.Cliente.Where(Function(model) model.id_cliente = id).SingleOrDefault()

    End Function

End Class
