Imports System.Web.UI.WebControls

Public Class Listas

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio y lo devuelve con los datos de todos los alamcenes
    ''' existentes en la base de datos
    ''' </summary>
    Public Shared Sub Almacen(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Almacen
                     Select
                         AL.id_almacen,
                         AL.nombre
                    ).ToList()

        DropDownList1.DataValueField = "id_almacen"
        DropDownList1.DataTextField = "nombre"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
        DropDownList1.Items.Insert(0, New ListItem("Seleccione...", ""))
    End Sub

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio y un id del cliente , y lo devuelve con los datos de 
    ''' todos los alamcenes de ese cliente
    ''' </summary>
    Public Shared Sub Almacen(ByRef DropDownList1 As DropDownList, idCliente As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Almacen
                     Where AL.id_cliente = idCliente
                     Select
                         AL.id_almacen,
                         AL.nombre
                    ).ToList()

        DropDownList1.DataValueField = "id_almacen"
        DropDownList1.DataTextField = "nombre"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
        DropDownList1.Items.Insert(0, New ListItem("Seleccione...", ""))
    End Sub

    '-------------------------------------------------------------------------------------------------'

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio y un id del Almacén , y lo devuelve con los datos de 
    ''' todos los articulos de tipo "Normal" de ese Almacén
    ''' </summary>
    Public Shared Sub Articulo(ByRef DropDownList1 As DropDownList, idAlmacen As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Where (AL.tipoArticulo = "Normal" And AL.id_almacen = idAlmacen) Or
                         (AL.tipoArticulo = "Normal" And AL.Almacen.id_cliente = 1)
                     Select
                         AL.id_articulo,
                         AL.nombre
                    ).ToList()

        DropDownList1.DataValueField = "id_articulo"
        DropDownList1.DataTextField = "nombre"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
    End Sub

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio y un id del Almacén , y lo devuelve con los datos de 
    ''' todos los articulos de ese Almacén
    ''' </summary>
    Public Shared Sub Articulo_Almacen(ByRef DropDownList1 As DropDownList, idAlmacen As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Where AL.id_almacen = idAlmacen
                     Select
                         AL.id_articulo,
                         AL.nombre
                    ).ToList()

        DropDownList1.DataValueField = "id_articulo"
        DropDownList1.DataTextField = "nombre"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()

        DropDownList1.Items.Insert(0, New ListItem("Seleccione...", ""))
    End Sub

    '-------------------------------------------------------------------------------------------------'

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los articulos existentes en la base de datos
    ''' </summary>
    Public Shared Sub ArticuloPickingEdit(ByRef DropDownList1 As DropDownList, ByRef GridView1 As GridView, idAlmacen As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Where (AL.tipoArticulo = "Normal" And AL.id_almacen = idAlmacen) Or
                         (AL.tipoArticulo = "Normal" And AL.Almacen.id_cliente = 1)
                     Select
                         AL.id_articulo,
                         AL.nombre
                    ).ToList()



        For Each row As GridViewRow In GridView1.Rows

            Dim _id_articulo As String = GridView1.DataKeys(row.RowIndex).Values(0).ToString
            Dim IdArticulo As Integer = Convert.ToInt32(_id_articulo)

            query = query.Where(Function(x) x.id_articulo <> IdArticulo).ToList()
        Next


        DropDownList1.DataValueField = "id_articulo"
        DropDownList1.DataTextField = "nombre"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()

    End Sub

    '-------------------------------------------------------------------------------------------------'

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los clientes existentes en la base de datos
    ''' </summary>
    Public Shared Sub Cliente(ByRef DropDownList1 As DropDownList, idCliente As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        DropDownList1.DataValueField = "id_cliente"
        DropDownList1.DataTextField = "nombre"

        Dim query = (From CL In contexto.Cliente Select CL.id_cliente, CL.nombre).ToList()

        If idCliente <> 1 Then
            query = (From CL In contexto.Cliente Where CL.id_cliente = idCliente Select CL.id_cliente, CL.nombre).ToList()
        End If

        DropDownList1.DataSource = query
        DropDownList1.DataBind()

        DropDownList1.Items.Insert(0, New ListItem("Seleccione...", ""))
    End Sub

    '-------------------------------------------------------------------------------------------------'

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los tipo de facturacion existentes en la base de datos
    ''' </summary>
    Public Shared Sub TipoFacturacion(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Tipo_Facturacion
                     Select
                         AL.id_tipo_facturacion,
                         AL.nombre
                    ).ToList()

        DropDownList1.DataValueField = "id_tipo_facturacion"
        DropDownList1.DataTextField = "nombre"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
    End Sub

    '-------------------------------------------------------------------------------------------------'

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los tipo de unidad existentes en la base de datos
    ''' </summary>
    Public Shared Sub TipoUnidad(ByRef DropDownList1 As DropDownList)

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
    End Sub

    '-------------------------------------------------------------------------------------------------'

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los roles existentes en la base de datos
    ''' </summary>
    Public Shared Sub Rol(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.AspNetRoles
                     Where AL.Id <> 1
                     Select
                         AL.Id,
                         AL.Name
                    ).ToList()

        DropDownList1.DataValueField = "Name"
        DropDownList1.DataTextField = "Name"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
    End Sub
End Class
