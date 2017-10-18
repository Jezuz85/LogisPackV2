Imports System.Globalization
Imports CapaDatos
Imports Microsoft.AspNet.Identity

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

            idCliente = Getter.Cliente_Usuario(Manager_Usuario.GetUserId(User))

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
            Response.Redirect(Paginas.Login.ToString)
        End If


    End Sub

    ''' <summary>
    ''' Metodo para obtener que lista hace el postback si Tipo de Articulo o Cliente y asi pintar las ubicaciones
    ''' </summary>
    Private Sub ObtenerControl_Postback(page As Page)

        Dim ctrl As Control = Utilidades_UpdatePanel.ObtenerControl_PostBack(page)

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
            If ddlTipoArticulo.SelectedValue = "Picking" Then

                Utilidades_UpdatePanel.LimpiarControles(upAdd_Articulo)
                Mgr_Articulo.Llenar_Lista(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))
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
        Listas.TipoFacturacion(ddlTipoFacturacion)
        Listas.TipoUnidad(ddlTipoUnidad)
        Listas.Cliente(ddlCliente, idCliente)
    End Sub

    ''' <summary>
    ''' Metodo que crea la tabla ubicacion, para añadir o eliminar filas, para agregar ubicaciones al articulo
    ''' </summary>
    Private Sub CrearCamposListaUbicacion(valor As Integer)

        ViewState(Val_Articulo.contUbicacion.ToString) = Convert.ToString(Mgr_Articulo.crearCamposListaUbicacion(valor, pTabla))

    End Sub

    '--------------------------------------------GUARDAR------------------------------------------------------------
    ''' <summary>
    ''' Metodo que se ejecuta para crear el articulo y registrarlo en la base de datos
    ''' </summary>
    Private Function GuardarArticulo() As Boolean

        '----------------Validar strings vacios

        Dim _codigo = Validaciones.Validar_Campo_Vacio(txtCodigo.Text, String.Empty)
        Dim _nombre = Validaciones.Validar_Campo_Vacio(txtNombre.Text, String.Empty)
        Dim _id_almacen = Convert.ToInt32(ddlAlmacen.SelectedValue)
        Dim _referencia1 = Validaciones.Validar_Campo_Vacio(txtRef1.Text, String.Empty)
        Dim _referencia2 = Validaciones.Validar_Campo_Vacio(txtRef2.Text, String.Empty)
        Dim _referencia3 = Validaciones.Validar_Campo_Vacio(txtRef3.Text, String.Empty)
        Dim _tipoArticulo = Validaciones.Validar_Campo_Vacio(ddlTipoArticulo.SelectedValue, "0")
        Dim _identificacion = Validaciones.Validar_Campo_Vacio(ddlIdentificacion.SelectedValue, String.Empty)
        Dim _id_tipo_unidad = Validaciones.Validar_Campo_Vacio(ddlTipoUnidad.SelectedValue, "0")
        Dim _referencia_picking = Validaciones.Validar_Campo_Vacio(txtRefPick.Text, String.Empty)
        Dim _id_tipo_facturacion = Validaciones.Validar_Campo_Vacio(ddlTipoFacturacion.SelectedValue, "0")
        Dim _observaciones_articulo = Validaciones.Validar_Campo_Vacio(txtObsArt.Text, String.Empty)
        Dim _observaciones_generales = Validaciones.Validar_Campo_Vacio(txtObsGen.Text, String.Empty)

        '-----------------Validar campos vacios y formatear decimalesTTT

        Dim _peso As Double = Validaciones.Formatear_Double(Validaciones.Validar_Campo_Vacio(txtPeso.Text, "0"))
        Dim _alto As Double = Validaciones.Formatear_Double(Validaciones.Validar_Campo_Vacio(txtAlto.Text, "0"))
        Dim _largo As Double = Validaciones.Formatear_Double(Validaciones.Validar_Campo_Vacio(txtLargo.Text, "0"))
        Dim _ancho As Double = Validaciones.Formatear_Double(Validaciones.Validar_Campo_Vacio(txtAncho.Text, "0"))
        Dim _stock_fisico As Double = Validaciones.Formatear_Double(Validaciones.Validar_Campo_Vacio(txtStockFisico.Text, 0))
        Dim _stock_minimo As Double = Validaciones.Formatear_Double(Validaciones.Validar_Campo_Vacio(txtStockMinimo.Text, "0"))
        Dim _valor_articulo As Double = Validaciones.Formatear_Double(Validaciones.Validar_Campo_Vacio(txtValArticulo.Text, 0))
        Dim _coeficiente_volumetrico As Double = Validaciones.Formatear_Double(Validaciones.Validar_Campo_Vacio(txtCoefVol.Text, "0"))
        Dim _valor_asegurado As Double = Validaciones.Formatear_Double(Validaciones.Validar_Campo_Vacio(txtValAsegurado.Text, "0"))

        '-----------------Calculos

        Dim M3 As Double = Mgr_Articulo.CalcularM3(_alto, _ancho, _largo)
        Dim PesoVol As Double = Mgr_Articulo.Calcular_PesoVolumetrico(_alto, _ancho, _largo, _coeficiente_volumetrico)
        Dim valoracionStock As Double = Mgr_Articulo.Calcular_ValoracionStock(_stock_fisico, _valor_articulo)
        Dim valoracionSeguro As Double = Mgr_Articulo.Calcular_ValoracionSeguro(_valor_asegurado, _stock_fisico)

        '-----------------Crear bjeto articulo

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

        bError = Mgr_Articulo.Guardar(_Nuevo)

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que se ejecuta para crear las imagenes del articulo y registrarlo en la base de datos
    ''' </summary>
    Private Sub GuardarImagenes(articuloView As Articulo)

        Dim contadorControl As Integer = 0

        For Each _imagen In fuImagenes.PostedFiles

            contadorControl += 1

            If _imagen.ContentLength > 0 And _imagen IsNot Nothing Then

                Dim urlImagen As String = Utilidades_Fileupload.Subir_Archivos(_imagen, Paginas.URL_Articulos.ToString, "Img_" & articuloView.id_articulo & "_" & contadorControl)

                Dim _imagenes As New Imagen With
                            {
                            .nombre = "Imagen_" & DateTime.Now.ToString("(MM-dd-yy_H:mm:ss)"),
                            .id_articulo = articuloView.id_articulo,
                            .url_imagen = urlImagen
                        }
                Create.Imagen(_imagenes)
            End If

        Next
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para crear las ubicaciones del articulo y registrarlo en la base de datos
    ''' </summary>
    Private Sub GuardarUbicaciones(articuloView As Articulo)

        Dim contadorControl As Integer = 0
        Dim miTextbox As TextBox
        Dim _NuevoUbicaion As Ubicacion
        Dim zona As String = Nothing
        Dim estante As String = Nothing
        Dim fila As String = Nothing
        Dim columna As String = Nothing
        Dim panel As String = Nothing
        Dim referencia_ubicacion As String = Nothing

        For Each micontrol As Control In pTabla.Controls

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtZona.ToString & contadorControl), TextBox)
            If miTextbox IsNot Nothing Then
                zona = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
            End If

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtEstante.ToString & contadorControl), TextBox)
            If miTextbox IsNot Nothing Then
                estante = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
            End If

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtFila.ToString & contadorControl), TextBox)
            If miTextbox IsNot Nothing Then
                fila = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
            End If

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtColumna.ToString & contadorControl), TextBox)
            If miTextbox IsNot Nothing Then
                Dim valor As String = miTextbox.Text.PadLeft(4, "0")
                columna = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text.PadLeft(4, "0"))
            End If

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtPanel.ToString & contadorControl), TextBox)
            If miTextbox IsNot Nothing Then
                panel = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
            End If

            miTextbox = CType(pTabla.FindControl(Val_Articulo.txtRefUbi.ToString & contadorControl), TextBox)
            If miTextbox IsNot Nothing Then
                referencia_ubicacion = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
            End If

            If referencia_ubicacion IsNot Nothing Then

                If (zona <> String.Empty) Or
                            (estante <> String.Empty) Or
                            (columna <> String.Empty) Or
                            (panel <> String.Empty) Or
                            (referencia_ubicacion <> String.Empty) Then

                    _NuevoUbicaion = New Ubicacion With {
                                .zona = zona,
                                .estante = estante,
                                .fila = fila,
                                .columna = columna,
                                .panel = panel,
                                .referencia_ubicacion = referencia_ubicacion,
                                .id_articulo = articuloView.id_articulo
                            }

                    Create.Ubicacion(_NuevoUbicaion)
                    referencia_ubicacion = Nothing

                End If
            End If

            contadorControl += 1
        Next
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta para registrar los articulos que conforman el articulo picking y registrarlo en la base de datos
    ''' </summary>
    Private Sub GuardarPicking(articuloView As Articulo)

        Dim contadorControl As Integer = 0

        If ddlTipoArticulo.SelectedValue = "Picking" Then

            For Each row As GridViewRow In GridView1.Rows

                Dim _id_articulo As String = GridView1.DataKeys(row.RowIndex).Values(0).ToString
                Dim _unidades As String = row.Cells(2).Text

                Dim _NuevoPic_Art As New Picking_Articulo With {
                            .unidades = _unidades,
                            .id_articulo = _id_articulo,
                            .id_picking = articuloView.id_articulo
                        }
                bError = Create.Picking_Articulo(_NuevoPic_Art)

            Next

        End If

    End Sub

    '-----------------------------------Metodos del Gridview de articulos picking--------------------------------------------------------
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
            ddlListaArticulos.Items.Insert(0, New ListItem("" + Articulo, String.Empty + idArticulo))

        End If

    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        CargarGridView()
    End Sub

    '-----------------------------------Metodos del Gridview de lista articulois picking-----------------------------
    ''' <summary>
    ''' Metodo que inicializa el gridview de los articulo que ocnforman el articulo picking,
    ''' en caso que el cliente quiera registrar un articulo picking
    ''' </summary>
    Private Sub InicializarGridView()
        Utilidades_Grid.InicializarGridView(_DataTable)
        Update_ViewState_Datatable()
        Utilidades_Grid.Update_GridView_CurrentDatatable(_DataTable, GridView1)
    End Sub

    ''' <summary>
    ''' Metodo que actualiza el gridview y viewstate con el DataTable actual
    ''' </summary>
    Private Sub CargarGridView()

        _DataTable = CType(ViewState(Val_Articulo.CurrentTable.ToString), DataTable)
        Update_ViewState_Datatable()
        Utilidades_Grid.Update_GridView_CurrentDatatable(_DataTable, GridView1)

    End Sub

    ''' <summary>
    ''' Metodo que aagrega una fila al gridview de lista articulos picking
    ''' </summary>
    Private Sub AddRowGridview()
        _DataTable = CType(ViewState(Val_Articulo.CurrentTable.ToString), DataTable)

        Utilidades_Grid.AddRowGridview(_DataTable, ddlListaArticulos.SelectedValue, ddlListaArticulos.SelectedItem.ToString, txtUnidad.Text)

        Update_ViewState_Datatable()

        Utilidades_Grid.Update_GridView_CurrentDatatable(_DataTable, GridView1)
    End Sub

    ''' <summary>
    ''' Metodo que actualiza el viewstate con el DataTable actual
    ''' </summary>
    Private Sub Update_ViewState_Datatable()
        ViewState(Val_Articulo.CurrentTable.ToString) = _DataTable
    End Sub

    '--------------------------------------------------EVENTOS---------------------------------------------
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

            Utilidades_UpdatePanel.CerrarOperacion(Val_General.Registrar.ToString, bError, Me, upAdd_Articulo, upAdd_Articulo)

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

        If ddlTipoArticulo.SelectedValue = "Picking" And ddlAlmacen.SelectedValue <> String.Empty Then
            Mgr_Articulo.Llenar_Lista(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))
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
        Mgr_Articulo.Llenar_Lista(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))

    End Sub

End Class