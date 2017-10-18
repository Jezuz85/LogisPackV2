Imports System.Globalization
Imports System.Text
Imports System.Web.UI.WebControls

Public Class Mgr_Articulo

    '------------------------Funciones de la clase articulo

    ''' <summary>
    ''' Metodo que recibe un objeto Articulo y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Guardar(ByVal _nuevo As Articulo) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Articulo.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Eliminar(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim _Eliminar As New Articulo With {
                .id_articulo = _id
            }
            contexto.Articulo.Attach(_Eliminar)
            contexto.Articulo.Remove(_Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Picking_Articulo y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Eliminar_Picking_Articulo(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim Eliminar As New Picking_Articulo With {
                .id_picking_articulo = _id
            }
            contexto.Picking_Articulo.Attach(Eliminar)
            contexto.Picking_Articulo.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    '------------------------Funciones Grid

    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del articulo en la base de datos
    ''' </summary>
    Public Shared Sub Llenar_Grid(ByRef GridView1 As GridView, idCliente As Integer, columna As String, tipoOrdenacion As String,
                              filtroBusqueda As String, textoBusqueda As String)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Select
                         AL.id_articulo,
                         AL.Almacen.id_cliente,
                         AL.nombre,
                         AL.codigo,
                         Cliente = AL.Almacen.Cliente.nombre,
                         Almacen = AL.Almacen.nombre
                    ).ToList()

        If idCliente <> 1 Then
            query = query.Where(Function(x) x.id_cliente = idCliente).ToList()
        End If

        If columna = Val_Articulo.Filtro_Nombre.ToString Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.nombre).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.nombre).ToList()
            End If
        ElseIf columna = Val_Articulo.Filtro_Codigo.ToString Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.codigo).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.codigo).ToList()
            End If
        ElseIf columna = Val_Articulo.Filtro_Almacen.ToString Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.Almacen).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.Almacen).ToList()
            End If
        ElseIf columna = Val_Articulo.Filtro_Cliente.ToString Then
            If tipoOrdenacion = "1" Then
                query = query.OrderBy(Function(x) x.Cliente).ToList()
            Else
                query = query.OrderByDescending(Function(x) x.Cliente).ToList()
            End If
        End If

        If textoBusqueda <> String.Empty Then
            If filtroBusqueda = Val_Articulo.Filtro_Nombre.ToString Then
                query = query.Where(Function(x) x.nombre.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = Val_Articulo.Filtro_Codigo.ToString Then
                query = query.Where(Function(x) x.codigo.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = Val_Articulo.Filtro_Almacen.ToString Then
                query = query.Where(Function(x) x.Almacen.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            ElseIf filtroBusqueda = Val_Articulo.Filtro_Cliente.ToString Then
                query = query.Where(Function(x) x.Cliente.ToLower.Contains(textoBusqueda.ToLower)).ToList()
            End If
        End If

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Metodo que recibe el gridview para llenar con los datos del articulo picking en la base de datos
    ''' </summary>
    Public Shared Sub Llenar_Grid_ArticuloPicking(ByRef GridView1 As GridView, idPicking As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Picking_Articulo
                     Where AL.id_picking = idPicking
                     Select
                         AL.id_articulo,
                         Cantidad = AL.unidades,
                         Articulo = AL.Articulo.nombre,
                         AL.Articulo.tipoArticulo
                    ).ToList()

        query = query.Where(Function(x) x.tipoArticulo = "Normal").ToList()

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    '------------------------GET Articulo

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Articulo(id As Integer) As Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.Where(Function(model) model.id_articulo = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que devuelve el ultimo Articulo registrado en la base de datos
    ''' </summary>
    Public Shared Function Get_Articulo_Ultimo() As Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.ToList().LastOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un codigo del Articulo y lo consulta desde la Base de datos, 
    ''' devuelve una objeto de tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Articulo_Codigo(_codigo As String) As Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Articulo.Where(Function(model) model.codigo = _codigo).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, 
    ''' devuelve una lista de objetos de tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Articulo_list(id As Integer) As List(Of Articulo)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.Where(Function(model) model.id_articulo = id).ToList()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Articulo a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Articulo(id As Integer, ByRef contexto As LogisPackEntities) As Articulo
        Return contexto.Articulo.Where(Function(model) model.id_articulo = id).SingleOrDefault()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, 
    ''' devuelve una lista de objetos de tipo Articulo que estan asociados a un articulo picking 
    ''' si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Picking_Articulo_list(id As Integer) As List(Of Picking_Articulo)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Picking_Articulo.Where(Function(model) model.id_picking = id).ToList()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, 
    ''' devuelve un  objeto de tipo Articulo que estan asociados a un articulo picking 
    ''' si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Picking_Articulo(id As Integer) As Picking_Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Picking_Articulo.Where(Function(model) model.id_picking_articulo = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el ArticuloPicking a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Picking_Articulo(id As Integer, ByRef contexto As LogisPackEntities) As Picking_Articulo
        Return contexto.Picking_Articulo.Where(Function(model) model.id_picking_articulo = id).SingleOrDefault()
    End Function

    '------------------------FUNCIONES DEL DROPDOWNLIST
    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio y un id del Almacén , y lo devuelve con los datos de 
    ''' todos los articulos de tipo "Normal" de ese Almacén
    ''' </summary>
    Public Shared Sub Llenar_Lista(ByRef DropDownList1 As DropDownList, idAlmacen As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Where (AL.tipoArticulo = "Normal" And AL.id_almacen = idAlmacen) Or
                         (AL.tipoArticulo = "Normal" And AL.Almacen.id_cliente = 1)
                     Select
                         AL.id_articulo,
                         AL.nombre
                    ).ToList()

        Listas.Set_Text_Value_List(DropDownList1, query, Val_Articulo.Id_Art.ToString, Val_Articulo.Nom_Art.ToString)


    End Sub

    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio y un id del Almacén , y lo devuelve con los datos de 
    ''' todos los articulos de ese Almacén
    ''' </summary>
    Public Shared Sub Llenar_Lista_Almacen(ByRef DropDownList1 As DropDownList, idAlmacen As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Where AL.id_almacen = idAlmacen
                     Select
                         AL.id_articulo,
                         AL.nombre
                    ).ToList()

        Listas.Set_Text_Value_List(DropDownList1, query, Val_Articulo.Id_Art.ToString, Val_Articulo.Nom_Art.ToString)

        DropDownList1.Items.Insert(0, New ListItem(Val_General.Lista_Seleccione.ToString, String.Empty))
    End Sub


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

        Listas.Set_Text_Value_List(DropDownList1, query, Val_Articulo.Id_Art.ToString, Val_Articulo.Nom_Art.ToString)

    End Sub

    '------------------------Eventos al crear un articulo
    ''' <summary>
    ''' Metodo que consulta el Coeficiente Volumetrico del almacen y lo asigna al articulo a crear al 
    ''' cargar la pagina
    ''' </summary>
    Public Shared Sub CargarCoefVol(idAlmacen As Integer, ByRef txt1 As TextBox)
        Dim _Almacen = Mgr_Almacen.Consultar(idAlmacen)
        txt1.Text = _Almacen.coeficiente_volumetrico.ToString().Replace(",", ".")
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Public Shared Sub CambiarCliente(ddl1 As DropDownList, txt1 As TextBox, ddl2 As DropDownList)

        If ddl1.SelectedValue = String.Empty Then
            txt1.Text = String.Empty
            ddl2.Items.Clear()
        Else
            Mgr_Almacen.Llenar_Lista(ddl2, Convert.ToInt32(ddl1.SelectedValue))
        End If

    End Sub

    ''' <summary>
    ''' Metodo que crea la tabla ubicacion, para añadir o eliminar filas, para agregar ubicaciones al articulo
    ''' </summary>
    Public Shared Function crearCamposListaUbicacion(valor As Integer, pTabla As Panel) As Integer
        Dim ContFilas As Integer = 0

        If valor < 0 Then
            ContFilas = 0
        Else
            ContFilas = valor
        End If

        For i As Integer = 1 To ContFilas

            ControlesDinamicos.CrearLiteral("<tr><td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtZona" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtEstante" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtFila" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtColumna" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtPanel" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtRefUbi" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td></tr>", pTabla)


        Next

        Return Convert.ToString(ContFilas)
    End Function

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un almacen, y se fija el valor del coeficiente volumetrico
    ''' al articulo dependiendo del valor que tenga el coeficiente del almacen
    ''' </summary>
    Public Shared Sub SetCoefVolumétrico(ByRef ddl1 As DropDownList, ByRef txt1 As TextBox, ByRef ph1 As PlaceHolder,
        ByRef ddl2 As DropDownList)

        If ddl1.SelectedValue = String.Empty Then
            txt1.Text = String.Empty
            ph1.Visible = False
        Else

            If ddl2.SelectedValue = "Picking" Then
                ph1.Visible = True
            Else
                ph1.Visible = False
            End If

            CargarCoefVol(Convert.ToInt32(ddl1.SelectedValue), txt1)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que agrega ceros a la izquierda de los campos de la ubicacion de un articulo
    ''' </summary>
    Public Shared Function LlenarCeros(valor As String) As String
        Return valor.PadLeft(4, "0"c)
    End Function


    '------------------------CALCULOS
    ''' <summary>
    ''' Metodo que calcula Valoracion Stock 
    ''' </summary>
    Public Shared Function Calcular_ValoracionStock(_StockFisico As Double, _ValArticulo As Double) As Double

        Return (_ValArticulo * _StockFisico).ToString(Val_Almacen.Formato_5_decimales.ToString)

    End Function

    ''' <summary>
    ''' Metodo que calcula Valoracion Seguro
    ''' </summary>
    Public Shared Function Calcular_ValoracionSeguro(_ValAsegurado As Double, _StockFisico As Double) As Double

        Return (_ValAsegurado * _StockFisico).ToString(Val_Almacen.Formato_5_decimales.ToString)

    End Function

    ''' <summary>
    ''' Metodo que calcula Peso Volumetrico
    ''' </summary>
    Public Shared Function Calcular_PesoVolumetrico(_Alto As Double, _Ancho As Double, _Largo As Double, _CoefVol As Double) As Double

        Return ((_Alto * _Ancho * _Largo * _CoefVol) / 1000000).ToString(Val_Almacen.Formato_5_decimales.ToString)

    End Function

    ''' <summary>
    ''' Metodo que calcula M3
    ''' </summary>
    Public Shared Function CalcularM3(_Alto As Double, _Ancho As Double, _Largo As Double) As Double

        Return ((_Alto * _Ancho * _Largo) / 1000000).ToString(Val_Almacen.Formato_5_decimales.ToString)

    End Function



End Class
