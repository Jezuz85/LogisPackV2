Imports System.Globalization
Imports CapaDatos

Public Class Crear
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean
    Private idCliente As Integer
    Private _DataTable As DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Page.Form.Attributes.Add("enctype", "multipart/form-data")

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            idCliente = Mgr_Usuario.Get_Cliente_Usuario(Manager_Usuario.GetUserId(User))

            If Not IsPostBack Then
                ViewState(Val_Articulo.contUbicacion.ToString) = "0"
                CargarListas()

                InicializarGridView()

            Else
                ObtenerControl_Postback(Me)

                For Each ctlID In Page.Request.Form.AllKeys
                    If ctlID IsNot Nothing Then

                        Dim c As Control = Page.FindControl(ctlID)

                        If c IsNot Nothing Then
                            If c.GetType() Is GetType(Button) Then

                                If c.ClientID.Contains(Val_Articulo.btnAddFilaUbicacion.ToString) Then
                                    CrearCamposListaUbicacion(Convert.ToInt32(ViewState(Val_Articulo.contUbicacion.ToString) + 1))
                                ElseIf c.ClientID.Contains(Val_Articulo.btnEliminarFila.ToString) Then
                                    CrearCamposListaUbicacion(Convert.ToInt32(ViewState(Val_Articulo.contUbicacion.ToString) - 1))
                                Else
                                    CrearCamposListaUbicacion(Convert.ToInt32(ViewState(Val_Articulo.contUbicacion.ToString)))
                                End If

                            End If
                        End If

                    End If
                Next

            End If
        Else
            Response.Redirect(Val_Paginas.Login.ToString)
        End If

    End Sub

    '------------------------------------------------------------------
    '------------------------METODOS AL CARGAR LA PAGINA---------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo para obtener que lista hace el postback si Tipo de Articulo o Cliente y asi pintar las ubicaciones
    ''' </summary>
    Private Sub ObtenerControl_Postback(page As Page)

        Dim ctrl As Control = Util_UpdatePanel.ObtenerControl_PostBack(page)

        If ctrl IsNot Nothing Then
            If ctrl.ClientID.Contains(Val_Articulo.ddlTipoArticulo.ToString) Or
                ctrl.ClientID.Contains(Val_Articulo.ddlCliente.ToString) Or
                ctrl.ClientID.Contains(Val_Articulo.ddlAlmacen.ToString) Then
                CrearCamposListaUbicacion(Convert.ToInt32(ViewState(Val_Articulo.contUbicacion.ToString)))
            End If
        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para limpiar los valores del updatepanel
    ''' </summary>
    Private Sub LimpiarControles()

        If bError Then
            If ddlTipoArticulo.SelectedValue = Val_Articulo.Tipo_Picking.ToString Then

                Util_UpdatePanel.LimpiarControles(upAdd_Articulo)
                Mgr_Articulo.Llenar_ListaByAlmacen_ArticuloNormal(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))
                phListaArticulos.Visible = False
                txtUnidad.Text = Nothing
            End If
            ddlAlmacen.SelectedValue = String.Empty
            ddlCliente.SelectedValue = String.Empty
        End If

    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()

        Mgr_TipoFacturacion.LlenarLista(ddlTipoFacturacion)
        Mgr_TipoUnidad.LlenarLista(ddlTipoUnidad)
        Mgr_Cliente.Llenar_ListaByCliente(ddlCliente, idCliente)

    End Sub

    ''' <summary>
    ''' Metodo que crea la tabla ubicacion, para añadir o eliminar filas, para agregar ubicaciones al articulo
    ''' </summary>
    Private Sub CrearCamposListaUbicacion(valor As Integer)

        ViewState(Val_Articulo.contUbicacion.ToString) = Convert.ToString(Mgr_Articulo.crearCamposListaUbicacion(valor, pTabla))

    End Sub


    '------------------------------------------------------------------
    '------------------------METODOS AL GUARDAR UN ARTICULO------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que se ejecuta para crear el articulo y registrarlo en la base de datos
    ''' </summary>
    Private Function GuardarArticulo() As Boolean

#Region "creo la estructura articulo"
        Dim _miArticulo = Mgr_Articulo.Get_Struct()
        _miArticulo.codigo = txtCodigo.Text
        _miArticulo.nombre = txtNombre.Text
        _miArticulo.id_almacen = ddlAlmacen.SelectedValue
        _miArticulo.referencia1 = txtRef1.Text
        _miArticulo.referencia2 = txtRef2.Text
        _miArticulo.referencia3 = txtRef3.Text
        _miArticulo.tipoArticulo = ddlTipoArticulo.SelectedValue
        _miArticulo.identificacion = ddlIdentificacion.SelectedValue
        _miArticulo.id_tipo_unidad = ddlTipoUnidad.SelectedValue
        _miArticulo.referencia_picking = txtRefPick.Text
        _miArticulo.id_tipo_facturacion = ddlTipoFacturacion.SelectedValue
        _miArticulo.observaciones_articulo = txtObsArt.Text
        _miArticulo.observaciones_generales = txtObsGen.Text
        _miArticulo.peso = txtPeso.Text
        _miArticulo.alto = txtAlto.Text
        _miArticulo.largo = txtLargo.Text
        _miArticulo.ancho = txtAncho.Text
        _miArticulo.stock_fisico = txtStockFisico.Text
        _miArticulo.stock_minimo = txtStockMinimo.Text
        _miArticulo.valor_articulo = txtValArticulo.Text
        _miArticulo.coeficiente_volumetrico = txtCoefVol.Text
        _miArticulo.valor_asegurado = txtValAsegurado.Text
#End Region

        bError = Mgr_Articulo.Guardar(Mgr_Articulo.Crear_Objeto(_miArticulo))

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que se ejecuta para crear las imagenes del articulo y registrarlo en la base de datos
    ''' </summary>
    Private Sub GuardarImagenes(articuloView As Articulo)

        Mgr_Imagen.RecorrerGrid_Guardar(fuImagenes, articuloView.id_articulo)

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para crear las ubicaciones del articulo y registrarlo en la base de datos
    ''' </summary>
    Private Sub GuardarUbicaciones(articuloView As Articulo)

        Mgr_Ubicacion.RecorrerGrid_Guardar(pTabla, articuloView.id_articulo)

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para registrar los articulos que conforman el articulo picking y registrarlo en la base de datos
    ''' </summary>
    Private Sub GuardarPicking(articuloView As Articulo)

        Dim contadorControl As Integer = 0

        If ddlTipoArticulo.SelectedValue = Val_Articulo.Tipo_Picking.ToString Then

            For Each row As GridViewRow In GridView1.Rows

                Dim structPicking = Mgr_Articulo.Get_Struct_Picking(row, GridView1, articuloView.id_articulo)
                bError = Mgr_Articulo.Guardar_Picking_Articulo(Mgr_Articulo.Crear_Objeto(structPicking))

            Next

        End If

    End Sub

    '-------------------------------------------------------------------
    '------------------------METODOS DEL GRIDVIEW DE ARTICULO PICKING---
    '-------------------------------------------------------------------
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Val_General.EliminarFila.ToString) Then

            Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
            Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)

            Dim idArticulo As String = gvrow.Cells(0).Text
            Dim Articulo As String = gvrow.Cells(1).Text

            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim dt As DataTable = TryCast(ViewState(Val_Articulo.CurrentTable.ToString), DataTable)
            dt.Rows(index).Delete()

            ViewState(Val_Articulo.CurrentTable.ToString) = dt
            GridView1.DataSource = dt
            GridView1.DataBind()


            btnAddArticuloRow.Visible = True
            ddlListaArticulos.Items.Insert(0, New ListItem(String.Empty + Articulo, String.Empty + idArticulo))

        End If

    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        CargarGridView()
    End Sub

    '------------------------------------------------------------------------------------------
    '------------------------METODOS DEL GRIDVIEW DE LISTA ARTICULO PICKING--------------------
    '------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que inicializa el gridview de los articulo que ocnforman el articulo picking,
    ''' en caso que el cliente quiera registrar un articulo picking
    ''' </summary>
    Private Sub InicializarGridView()

        Util_Grid.Ini_Grid_ArtPick(_DataTable)
        Update_ViewState_Datatable()
        Util_Grid.Update_GridView_CurrentDatatable(_DataTable, GridView1)

    End Sub

    ''' <summary>
    ''' Metodo que actualiza el gridview y viewstate con el DataTable actual
    ''' </summary>
    Private Sub CargarGridView()

        _DataTable = CType(ViewState(Val_Articulo.CurrentTable.ToString), DataTable)
        Update_ViewState_Datatable()
        Util_Grid.Update_GridView_CurrentDatatable(_DataTable, GridView1)

    End Sub

    ''' <summary>
    ''' Metodo que aagrega una fila al gridview de lista articulos picking
    ''' </summary>
    Private Sub AddRowGridview()

        _DataTable = CType(ViewState(Val_Articulo.CurrentTable.ToString), DataTable)
        Util_Grid.AddRow_Grid_ArtPick(_DataTable, ddlListaArticulos.SelectedValue, ddlListaArticulos.SelectedItem.ToString, txtUnidad.Text)
        Update_ViewState_Datatable()
        Util_Grid.Update_GridView_CurrentDatatable(_DataTable, GridView1)

    End Sub

    ''' <summary>
    ''' Metodo que actualiza el viewstate con el DataTable actual
    ''' </summary>
    Private Sub Update_ViewState_Datatable()

        ViewState(Val_Articulo.CurrentTable.ToString) = _DataTable

    End Sub

    '-------------------------------------------------------
    '------------------------EVENTOS------------------------
    '-------------------------------------------------------
    ''' <summary>
    ''' Metodo que se ejecuta cuando se oprime el boton de añadir articulo al artiulo picking
    ''' </summary>
    Protected Sub btnAddArticuloRow_Click(sender As Object, e As EventArgs) Handles btnAddArticuloRow.Click

        If Page.IsValid Then
            AddRowGridview()

            ddlListaArticulos.Items.Remove(ddlListaArticulos.Items.FindByValue(ddlListaArticulos.SelectedValue))

            txtUnidad.Text = String.Empty
            If ddlListaArticulos.Items.Count = 0 Then
                btnAddArticuloRow.Visible = False
            End If

        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para registrar un articulo en la base de datos
    ''' </summary>
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Page.IsValid Then

            Dim Stock_Picking As Double = If(txtStockFisico.Text = String.Empty, 0, Double.Parse(txtStockFisico.Text, CultureInfo.InvariantCulture))

            If GuardarArticulo() Then
                Dim articuloView = Mgr_Articulo.Get_Articulo_Ultimo()
                GuardarImagenes(articuloView)
                GuardarUbicaciones(articuloView)
                GuardarPicking(articuloView)
            End If

            Util_UpdatePanel.CerrarOperacion(Val_General.Registrar.ToString, bError, Me, upAdd_Articulo, upAdd_Articulo)

            LimpiarControles()

        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged

        Mgr_Articulo.CambiarCliente(ddlCliente, txtCoefVol, ddlAlmacen)

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un tipo de articulo, y sirve para mostrar los articulos a agregar
    ''' </summary>
    Protected Sub ddlTipoArticulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoArticulo.SelectedIndexChanged

        If ddlTipoArticulo.SelectedValue = Val_Articulo.Tipo_Picking.ToString And ddlAlmacen.SelectedValue <> String.Empty Then
            Mgr_Articulo.Llenar_ListaByAlmacen_ArticuloNormal(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))
            phListaArticulos.Visible = True
        Else
            phListaArticulos.Visible = False
        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un almacen, y se fija el valor del coeficiente volumetrico
    ''' al articulo dependiendo del valor que tenga el coeficiente del almacen
    ''' </summary>
    Protected Sub ddlAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAlmacen.SelectedIndexChanged

        Mgr_Articulo.SetCoefVolumétrico(ddlAlmacen, txtCoefVol, phListaArticulos, ddlTipoArticulo)
        Mgr_Articulo.Llenar_ListaByAlmacen_ArticuloNormal(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))

    End Sub

End Class