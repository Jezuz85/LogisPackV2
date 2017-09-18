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

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio y un id del Almacén , y lo devuelve con los datos de 
    ''' todos los articulos de ese Almacén
    ''' </summary>
    Public Shared Sub Articulo(ByRef DropDownList1 As DropDownList, idAlmacen As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Where AL.tipoArticulo = "Normal" And AL.id_almacen = idAlmacen
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
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los articulos existentes en la base de datos
    ''' </summary>
    Public Shared Sub ArticuloTodos(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Select
                         AL.id_articulo,
                         NombreStock = AL.nombre
                    ).ToList()

        DropDownList1.DataValueField = "id_articulo"
        DropDownList1.DataTextField = "NombreStock"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
    End Sub

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los clientes existentes en la base de datos
    ''' </summary>
    Public Shared Sub Cliente(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Cliente
                     Select
                         AL.id_cliente,
                         AL.nombre
                    ).ToList()

        DropDownList1.DataValueField = "id_cliente"
        DropDownList1.DataTextField = "nombre"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()

        DropDownList1.Items.Insert(0, New ListItem("Seleccione...", ""))
    End Sub

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

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los roles existentes en la base de datos
    ''' </summary>
    Public Shared Sub Rol(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.AspNetRoles
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
