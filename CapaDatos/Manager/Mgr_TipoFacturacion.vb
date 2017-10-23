Imports System.Web.UI.WebControls

Public Class Mgr_TipoFacturacion

    '------------------------------------------------------------------
    '------------------------FUNCIONES DE LA CLASE TIPO FACTURACION----
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que recibe un objeto Tipo Facturacion y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Guardar(ByVal _nuevo As Tipo_Facturacion) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Tipo_Facturacion.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe el objeto Tipo de Facturación a Actualizar y el contexto en que fue creado, devuelve true si fue
    ''' exitosa la actualización, en caso contrario devuelve false
    ''' </summary>
    Public Shared Function Editar(_Edit As Tipo_Facturacion, ByRef contexto As LogisPackEntities) As Boolean

        Try
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function


    ''' <summary>
    ''' Metodo que recibe un id del Tipo de Facturacion y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Eliminar(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Try
            Dim _Eliminar As New Tipo_Facturacion With {
                .id_tipo_facturacion = _id
            }
            contexto.Tipo_Facturacion.Attach(_Eliminar)
            contexto.Tipo_Facturacion.Remove(_Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    '------------------------------------------------------------------
    '------------------------FUNCIONES DEL GRID------------------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del tipo de facturacion en la base de datos
    ''' </summary>
    Public Shared Sub LlenarGrid(ByRef GridView1 As GridView, columna As String, tipoOrdenacion As String,
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

    '------------------------------------------------------------------
    '------------------------FUNCIONES DEL DROPDOWNLIST----------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los tipo de facturacion existentes en la base de datos
    ''' </summary>
    Public Shared Sub LlenarLista(ByRef DropDownList1 As DropDownList)

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

    '------------------------------------------------------------------
    '------------------------FUNCIONES GETTER--------------------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Facturacion y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Tipo_Facturacion si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Tipo_Facturacion(id As Integer) As Tipo_Facturacion

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Facturacion.Where(Function(model) model.id_tipo_facturacion = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un nombre del Tipo_Facturacion y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Tipo_Facturacion si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Tipo_Facturacion(_nombre As String) As Tipo_Facturacion

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Facturacion.Where(Function(model) model.nombre = _nombre).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Facturacion y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Tipo_Facturacion a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Tipo_Facturacion si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Tipo_Facturacion(id As Integer, ByRef contexto As LogisPackEntities) As Tipo_Facturacion

        Return contexto.Tipo_Facturacion.Where(Function(model) model.id_tipo_facturacion = id).SingleOrDefault()

    End Function

End Class
