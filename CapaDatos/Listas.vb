Imports System.Web.UI.WebControls

Public Class Listas

    Public Shared Sub Set_Text_Value_List(ByRef _DropDownList As DropDownList, _query As Object, _text As String, _value As String)

        _DropDownList.DataValueField = _value
        _DropDownList.DataTextField = _text
        _DropDownList.DataSource = _query
        _DropDownList.DataBind()

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

        DropDownList1.Items.Insert(0, New ListItem(Val_General.Lista_Seleccione.ToString, String.Empty))
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
        DropDownList1.Items.Insert(0, New ListItem(Val_General.Lista_Seleccione.ToString, String.Empty))
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
        DropDownList1.Items.Insert(0, New ListItem(Val_General.Lista_Seleccione.ToString, String.Empty))
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
