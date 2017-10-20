Imports System.Web.UI.WebControls

Public Class Mgr_Articulo

    Structure struct_Articulo
        Public codigo As String
        Public nombre As String
        Public peso As String
        Public alto As String
        Public largo As String
        Public ancho As String
        Public cubicaje As String
        Public id_almacen As String
        Public referencia1 As String
        Public referencia2 As String
        Public referencia3 As String
        Public tipoArticulo As String
        Public stock_fisico As String
        Public stock_minimo As String
        Public peso_volumen As String
        Public identificacion As String
        Public id_tipo_unidad As String
        Public valor_articulo As String
        Public valor_asegurado As String
        Public valoracion_stock As String
        Public valoracion_seguro As String
        Public referencia_picking As String
        Public id_tipo_facturacion As String
        Public observaciones_articulo As String
        Public observaciones_generales As String
        Public coeficiente_volumetrico As String
    End Structure

    Structure struct_ArticuloPicking
        Public unidades As String
        Public id_articulo As String
        Public id_picking As String
    End Structure
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

    ''' <summary>
    ''' Metodo que devuelve una variable de tipo estructura con el cuerpo de la clase articulo
    ''' </summary>
    Public Shared Function Get_Struct() As struct_Articulo

        Dim _miArticulo As struct_Articulo = Nothing
        Return _miArticulo

    End Function

    ''' <summary>
    ''' Metodo que devuelve convierte un objeto artiulo a estructura con el cuerpo de la clase articulo
    ''' </summary>
    Public Shared Function Get_Struct(_Articulo As Articulo) As struct_Articulo

        Dim _miArticulo As struct_Articulo = Nothing

        _miArticulo.codigo = _Articulo.codigo
        _miArticulo.nombre = _Articulo.nombre
        _miArticulo.tipoArticulo = _Articulo.tipoArticulo
        _miArticulo.id_almacen = _Articulo.Almacen.nombre
        _miArticulo.referencia_picking = _Articulo.referencia_picking
        _miArticulo.referencia1 = _Articulo.referencia1
        _miArticulo.referencia2 = _Articulo.referencia2
        _miArticulo.referencia3 = _Articulo.referencia3
        _miArticulo.observaciones_generales = _Articulo.observaciones_generales
        _miArticulo.observaciones_articulo = _Articulo.observaciones_articulo
        _miArticulo.stock_minimo = _Articulo.stock_minimo
        _miArticulo.stock_fisico = _Articulo.stock_fisico
        _miArticulo.id_tipo_facturacion = _Articulo.Tipo_Facturacion.nombre
        _miArticulo.identificacion = _Articulo.identificacion
        _miArticulo.alto = _Articulo.alto
        _miArticulo.largo = _Articulo.largo
        _miArticulo.ancho = _Articulo.ancho
        _miArticulo.id_tipo_unidad = _Articulo.Tipo_Unidad.nombre


        Dim PesoVolumen As Double = Convert.ToDouble(_Articulo.peso_volumen).ToString("##,##0.00000")
        Dim CoefVolumetrico As Double = Convert.ToDouble(_Articulo.coeficiente_volumetrico).ToString("##,##0.00000")
        Dim M3 As Double = Convert.ToDouble(_Articulo.cubicaje).ToString("##,##0.00000")
        Dim ValorArticulo As Double = Convert.ToDouble(_Articulo.valor_articulo).ToString("##,##0.00000")
        Dim ValorAsegurado As Double = Convert.ToDouble(_Articulo.valor_asegurado).ToString("##,##0.00000")
        Dim ValoraciónStock As Double = Convert.ToDouble(_Articulo.valoracion_stock).ToString("##,##0.00000")
        Dim ValoraciónSeguro As Double = Convert.ToDouble(_Articulo.valoracion_seguro).ToString("##,##0.00000")
        Dim Peso As Double = Convert.ToDouble(_Articulo.peso).ToString("##,##0.00000")


        _miArticulo.ancho = _Articulo.ancho
        _miArticulo.peso = Peso & " Kgs"
        _miArticulo.ancho = _Articulo.ancho
        _miArticulo.coeficiente_volumetrico = CoefVolumetrico & " Kgs(m³)"
        _miArticulo.ancho = _Articulo.ancho
        _miArticulo.cubicaje = M3
        _miArticulo.ancho = _Articulo.ancho
        _miArticulo.peso_volumen = PesoVolumen & " Kgs(m³)"
        _miArticulo.ancho = _Articulo.ancho
        _miArticulo.valor_articulo = ValorArticulo
        _miArticulo.ancho = _Articulo.ancho
        _miArticulo.valor_asegurado = ValorAsegurado
        _miArticulo.ancho = _Articulo.ancho
        _miArticulo.valoracion_stock = ValoraciónStock
        _miArticulo.ancho = _Articulo.ancho
        _miArticulo.valoracion_seguro = ValoraciónSeguro

        Return _miArticulo

    End Function

    ''' <summary>
    ''' Metodo que recibe un array de string y retorna un objeto articulo
    ''' </summary>
    Public Shared Function Crear_Objeto(_articulo As struct_Articulo) As Articulo

#Region "Validar strings vacios"
        Dim _codigo = Util_Validaciones.Validar_Campo_Vacio(_articulo.codigo, String.Empty)
        Dim _nombre = Util_Validaciones.Validar_Campo_Vacio(_articulo.nombre, String.Empty)
        Dim _id_almacen = Convert.ToInt32(_articulo.id_almacen)
        Dim _referencia1 = Util_Validaciones.Validar_Campo_Vacio(_articulo.referencia1, String.Empty)
        Dim _referencia2 = Util_Validaciones.Validar_Campo_Vacio(_articulo.referencia2, String.Empty)
        Dim _referencia3 = Util_Validaciones.Validar_Campo_Vacio(_articulo.referencia3, String.Empty)
        Dim _tipoArticulo = Util_Validaciones.Validar_Campo_Vacio(_articulo.tipoArticulo, "0")
        Dim _identificacion = Util_Validaciones.Validar_Campo_Vacio(_articulo.identificacion, String.Empty)
        Dim _id_tipo_unidad = Util_Validaciones.Validar_Campo_Vacio(_articulo.id_tipo_unidad, "0")
        Dim _referencia_picking = Util_Validaciones.Validar_Campo_Vacio(_articulo.referencia_picking, String.Empty)
        Dim _id_tipo_facturacion = Util_Validaciones.Validar_Campo_Vacio(_articulo.id_tipo_facturacion, "0")
        Dim _observaciones_articulo = Util_Validaciones.Validar_Campo_Vacio(_articulo.observaciones_articulo, String.Empty)
        Dim _observaciones_generales = Util_Validaciones.Validar_Campo_Vacio(_articulo.observaciones_generales, String.Empty)
#End Region

#Region "Validar campos vacios y formatear decimales"

        Dim _peso As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(_articulo.peso, "0"))
        Dim _alto As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(_articulo.alto, "0"))
        Dim _largo As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(_articulo.largo, "0"))
        Dim _ancho As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(_articulo.ancho, "0"))
        Dim _stock_fisico As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(_articulo.stock_fisico, 0))
        Dim _stock_minimo As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(_articulo.stock_minimo, "0"))
        Dim _valor_articulo As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(_articulo.valor_articulo, 0))
        Dim _coeficiente_volumetrico As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(_articulo.coeficiente_volumetrico, "0"))
        Dim _valor_asegurado As Double = Util_Validaciones.Formatear_Double(Util_Validaciones.Validar_Campo_Vacio(_articulo.valor_asegurado, "0"))
#End Region

#Region "Calculos"

        Dim M3 As Double = Mgr_Articulo.CalcularM3(_alto, _ancho, _largo)
        Dim PesoVol As Double = Mgr_Articulo.Calcular_PesoVolumetrico(_alto, _ancho, _largo, _coeficiente_volumetrico)
        Dim valoracionStock As Double = Mgr_Articulo.Calcular_ValoracionStock(_stock_fisico, _valor_articulo)
        Dim valoracionSeguro As Double = Mgr_Articulo.Calcular_ValoracionSeguro(_valor_asegurado, _stock_fisico)

#End Region

        Dim _Nuevo As New Articulo With {
            .codigo = _codigo,
            .nombre = _nombre,
            .referencia_picking = _referencia_picking,
            .referencia1 = _referencia1,
            .referencia2 = _referencia2,
            .referencia3 = _referencia3,
            .identificacion = _identificacion,
            .valor_articulo = _valor_articulo,
            .valor_asegurado = _valor_asegurado,
            .valoracion_stock = valoracionStock,
            .valoracion_seguro = valoracionSeguro,
            .peso = _peso,
            .alto = _alto,
            .largo = _largo,
            .ancho = _ancho,
            .coeficiente_volumetrico = _coeficiente_volumetrico,
            .cubicaje = M3,
            .peso_volumen = PesoVol,
            .observaciones_articulo = _observaciones_articulo,
            .observaciones_generales = _observaciones_generales,
            .stock_fisico = _stock_fisico,
            .stock_minimo = _stock_minimo,
            .id_almacen = _id_almacen,
            .id_tipo_facturacion = _id_tipo_facturacion,
            .id_tipo_unidad = _id_tipo_unidad,
            .tipoArticulo = _tipoArticulo
        }

        Return _Nuevo

    End Function

    ''' <summary>
    ''' Metodo que recibe el objeto Artículo a Actualizar y el contexto en que fue creado, devuelve true si fue
    ''' exitosa la actualización, en caso contrario devuelve false
    ''' </summary>
    Public Shared Function Editar(_Edit As Articulo, ByRef contexto As LogisPackEntities) As Boolean

        Try
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto Picking_Articulo y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Guardar_Picking_Articulo(ByVal _nuevo As Picking_Articulo) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Picking_Articulo.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function


    ''' <summary>
    ''' Metodo que devuelve una variable de tipo estructura con el cuerpo de la clase articulo picking
    ''' </summary>
    Public Shared Function Get_Struct_Picking(row As GridViewRow, GridView1 As GridView, id_articulo As Integer) As struct_ArticuloPicking

        Dim structPicking As struct_ArticuloPicking = Nothing

#Region "creo la structura picking"
        structPicking.id_articulo = GridView1.DataKeys(row.RowIndex).Values(0).ToString
        structPicking.unidades = row.Cells(2).Text
        structPicking.id_picking = id_articulo
#End Region

        Return structPicking

    End Function

    ''' <summary>
    ''' Metodo que recibe un array de string y retorna un objeto articulo
    ''' </summary>
    Public Shared Function Crear_Objeto(structPicking As struct_ArticuloPicking) As Picking_Articulo


        Dim _NuevoPic_Art As New Picking_Articulo With
            {
            .unidades = structPicking.unidades,
            .id_articulo = structPicking.id_articulo,
            .id_picking = structPicking.id_picking
        }

        Return _NuevoPic_Art

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

        Util_ControlesDinamicos.Set_Text_Value_List(DropDownList1, query, Val_Articulo.Nom_Art.ToString, Val_Articulo.Id_Art.ToString)


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

        Util_ControlesDinamicos.Set_Text_Value_List(DropDownList1, query, Val_Articulo.Nom_Art.ToString, Val_Articulo.Id_Art.ToString)

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

        Util_ControlesDinamicos.Set_Text_Value_List(DropDownList1, query, Val_Articulo.Id_Art.ToString, Val_Articulo.Nom_Art.ToString)

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

            Util_ControlesDinamicos.CrearLiteral("<tr><td>", pTabla)
            Util_ControlesDinamicos.CrearTextbox("txtZona" & i, pTabla, TextBoxMode.SingleLine)
            Util_ControlesDinamicos.CrearLiteral("</td>", pTabla)


            Util_ControlesDinamicos.CrearLiteral("<td>", pTabla)
            Util_ControlesDinamicos.CrearTextbox("txtEstante" & i, pTabla, TextBoxMode.SingleLine)
            Util_ControlesDinamicos.CrearLiteral("</td>", pTabla)


            Util_ControlesDinamicos.CrearLiteral("<td>", pTabla)
            Util_ControlesDinamicos.CrearTextbox("txtFila" & i, pTabla, TextBoxMode.SingleLine)
            Util_ControlesDinamicos.CrearLiteral("</td>", pTabla)


            Util_ControlesDinamicos.CrearLiteral("<td>", pTabla)
            Util_ControlesDinamicos.CrearTextbox("txtColumna" & i, pTabla, TextBoxMode.SingleLine)
            Util_ControlesDinamicos.CrearLiteral("</td>", pTabla)


            Util_ControlesDinamicos.CrearLiteral("<td>", pTabla)
            Util_ControlesDinamicos.CrearTextbox("txtPanel" & i, pTabla, TextBoxMode.SingleLine)
            Util_ControlesDinamicos.CrearLiteral("</td>", pTabla)


            Util_ControlesDinamicos.CrearLiteral("<td>", pTabla)
            Util_ControlesDinamicos.CrearTextbox("txtRefUbi" & i, pTabla, TextBoxMode.SingleLine)
            Util_ControlesDinamicos.CrearLiteral("</td></tr>", pTabla)


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
