Imports System.Globalization
Imports CapaDatos

Public Class Crear1
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.Attributes.Add("enctype", "multipart/form-data")

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            idCliente = Mgr_Usuario.Get_Cliente_Usuario(Manager_Usuario.GetUserId(User))

            If IsPostBack = False Then
                CargarListas()
            End If
        Else
            Response.Redirect(Val_Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()
        Mgr_Cliente.Llenar_Lista(ddlCliente, idCliente)
    End Sub

    ''' <summary>
    ''' Metodo que muestra por pantalla el valor del stock fisico de un articulo seleccionado
    ''' </summary>
    Public Sub Get_StockArticulo(idArticulo As Integer)

        Dim _Articulo = Mgr_Articulo.Get_Articulo(idArticulo)

        lbStockFisico.Text = If(_Articulo.stock_fisico.ToString() = String.Empty, "-", _Articulo.stock_fisico.ToString())

    End Sub

    ''' <summary>
    ''' Metodo que valida que el valor de salida introducido no exceda al stock fisico existente
    ''' </summary>
    Private Sub ValidarStock()

        If txtCantidad.Text <> String.Empty Then

            Dim _Articulo = Mgr_Articulo.Get_Articulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))

            Dim StockFisico As Double = _Articulo.stock_fisico
            Dim CantidadSolicitada As Double = Double.Parse(txtCantidad.Text, CultureInfo.InvariantCulture)

            If (CantidadSolicitada > StockFisico) And (ddlTipoOperacion.SelectedValue = "Sal") Then
                Util_Modal.MostrarMensajeAlerta(updatePanelPrinicpal, False, Val_General.Unidades_Stock.ToString)
                txtCantidad.Text = "0"
            Else
                Util_Modal.OcultarAlerta(updatePanelPrinicpal)
            End If
        End If

    End Sub

    '--------------------------------------------------EVENTOS---------------------------------------------

    ''' <summary>
    ''' Evento que se lanza al ingresar un codigo y valida que exista en la lista de articulos disponibles
    ''' </summary>
    Protected Sub txtCodArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtCodArticulo.TextChanged

        Dim _articulo = Mgr_Articulo.Get_Articulo_Codigo(txtCodArticulo.Text)

        If _articulo IsNot Nothing Then
            If ddlListaArticulos.Items.Contains(ddlListaArticulos.Items.FindByValue(_articulo.id_articulo)) Then
                ddlListaArticulos.SelectedValue = _articulo.id_articulo
            Else
                txtCodArticulo.Text = String.Empty
                ddlListaArticulos.SelectedValue = String.Empty
            End If
        Else
            txtCodArticulo.Text = String.Empty
            ddlListaArticulos.SelectedValue = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' Metodo que registra una operacion de Entrada/Salida de un articulo en la base de datos
    ''' </summary>
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Page.IsValid Then

            Dim _articulo = Mgr_Articulo.Get_Articulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))
            Dim Stock_Picking As Double = Double.Parse(_articulo.stock_fisico, CultureInfo.InvariantCulture)
            Dim unidadesSolicitadas As Double = Double.Parse(txtCantidad.Text, CultureInfo.InvariantCulture)

            If (Stock_Picking > unidadesSolicitadas And ddlTipoOperacion.SelectedValue = "Sal") Or ddlTipoOperacion.SelectedValue = "Ent" Then

#Region "Guardar documento"
                Dim urlDoc As String = String.Empty

                If fuDocumento.HasFile Then
                    urlDoc = Util_Fileupload.Subir_Archivo(fuDocumento, Val_Paginas.URL_Operacion.ToString, "Doc_" & ddlTipoOperacion.SelectedValue & "_" & _articulo.id_articulo & "_" & Convert.ToDateTime(txtFechaOperacion.Text).ToString("yyyy-MM-dd") & "_")
                End If
#End Region

#Region "Guardar operacion nuevo"
                Dim _Nuevo As New Historico With
                    {
                    .fecha_transaccion = txtFechaOperacion.Text,
                    .tipo_transaccion = ddlTipoOperacion.SelectedValue,
                    .referencia_ubicacion = txtRef.Text,
                    .cantidad_transaccion = unidadesSolicitadas,
                    .id_articulo = Convert.ToInt32(ddlListaArticulos.SelectedValue),
                    .documento_transaccion = urlDoc
                }
                bError = Mgr_Historico.Guardar(_Nuevo)
#End Region

                If bError Then

                    Dim Edit = Mgr_Articulo.Get_Articulo(Convert.ToInt32(ddlListaArticulos.SelectedValue), contexto)
                    If ddlTipoOperacion.SelectedValue = "Ent" Then
                        Edit.stock_fisico = Edit.stock_fisico + unidadesSolicitadas
                    Else
                        Edit.stock_fisico = Edit.stock_fisico - unidadesSolicitadas
                    End If
                    bError = Mgr_Articulo.Editar(Edit, contexto)

                    Util_Modal.MostrarAlerta(updatePanelPrinicpal, bError, Val_General.Registrar.ToString)

                    Get_StockArticulo(Edit.id_articulo)

                Else
                    Util_Modal.MostrarAlerta(updatePanelPrinicpal, bError, Val_General.Registrar.ToString)
                    Return
                End If

            Else
                Util_Modal.MostrarMensajeAlerta(updatePanelPrinicpal, False, Val_General.Unidades_Stock.ToString)
            End If

        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se elige un articulo de la lista
    ''' </summary>
    Protected Sub ddlListaArticulos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlListaArticulos.SelectedIndexChanged

        If ddlListaArticulos.SelectedValue = String.Empty Then
            lbStockFisico.Text = String.Empty
            txtCodArticulo.Text = String.Empty
        Else
            Get_StockArticulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))

            Dim _articulo = Mgr_Articulo.Get_Articulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))
            txtCodArticulo.Text = _articulo.codigo

        End If

    End Sub

    ''' <summary>
    ''' Metodo que registra una operacion de Entrada/Salida de un articulo en la base de datos
    ''' </summary>
    Protected Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        ValidarStock()
    End Sub

    ''' <summary>
    ''' Evento que se dispara para validar que cuando se cambia el tipo de operacion, de entrada a salida,
    ''' el stock fisico sea menor o igual a la unidades ingresadas
    ''' </summary>
    Protected Sub ddlTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoOperacion.SelectedIndexChanged
        ValidarStock()
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged

        ddlListaArticulos.Items.Clear()

        If ddlCliente.SelectedValue = String.Empty Then
            ddlAlmacen.Items.Clear()
            ddlListaArticulos.Visible = False
            txtCodArticulo.Visible = False
        Else
            Mgr_Almacen.Llenar_Lista(ddlAlmacen, Convert.ToInt32(ddlCliente.SelectedValue))
            txtCodArticulo.Text = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un almacen, y se fija el valor del coeficiente volumetrico
    ''' al articulo dependiendo del valor que tenga el coeficiente del almacen
    ''' </summary>
    Protected Sub ddlAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAlmacen.SelectedIndexChanged

        If ddlAlmacen.SelectedValue = String.Empty Then
            ddlListaArticulos.Items.Clear()
            txtCodArticulo.Text = String.Empty
            ddlListaArticulos.Visible = False
            txtCodArticulo.Visible = False
        Else
            ddlListaArticulos.Visible = True
            txtCodArticulo.Visible = True
            Mgr_Articulo.Llenar_Lista_Almacen(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))

            If ddlListaArticulos.SelectedValue <> String.Empty Then
                Get_StockArticulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))
                Dim _articulo = Mgr_Articulo.Get_Articulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))
                txtCodArticulo.Text = _articulo.codigo
            End If


        End If

    End Sub

End Class