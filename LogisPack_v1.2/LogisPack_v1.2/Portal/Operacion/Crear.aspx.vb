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

            idCliente = Getter.Cliente_Usuario(Manager_Usuario.GetUserId(User))

            If IsPostBack = False Then
                CargarListas()
            End If
        Else
            Response.Redirect(Paginas.Login.ToString)
        End If
    End Sub

    Private Sub CargarListas()
        Listas.Cliente(ddlCliente, idCliente)
    End Sub


    ''' <summary>
    ''' Metodo que muestra por pantalla el valor del stock fisico de un articulo seleccionado
    ''' </summary>
    Public Sub Get_StockArticulo(idArticulo As Integer)

        Dim _Articulo = Getter.Articulo(idArticulo)

        lbStockFisico.Text = If(_Articulo.stock_fisico.ToString() = String.Empty, "-", _Articulo.stock_fisico.ToString())

    End Sub

    ''' <summary>
    ''' Metodo que registra una operacion de Entrada/Salida de un articulo en la base de datos
    ''' </summary>
    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Page.IsValid Then

            Dim _articulo = Getter.Articulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))
            Dim Stock_Picking As Double = Double.Parse(_articulo.stock_fisico, CultureInfo.InvariantCulture)
            Dim unidadesSolicitadas As Double = Double.Parse(txtCantidad.Text, CultureInfo.InvariantCulture)

            If (Stock_Picking > unidadesSolicitadas And ddlTipoOperacion.SelectedValue = "Sal") Or ddlTipoOperacion.SelectedValue = "Ent" Then

#Region "Guardar documento"
                Dim urlDoc As String = String.Empty

                If fuDocumento.HasFile Then
                    urlDoc = Utilidades_Fileupload.Subir_Archivo(fuDocumento, Paginas.URL_Operacion.ToString, "Doc_" & ddlTipoOperacion.SelectedValue & "_" & _articulo.id_articulo & "_" & Convert.ToDateTime(txtFechaOperacion.Text).ToString("yyyy-MM-dd") & "_")
                End If
#End Region

#Region "Guardar operacion nuevo"
                Dim _Nuevo As New Historico With
                    {
                    .fecha_transaccion = txtFechaOperacion.Text,
                    .tipo_transaccion = ddlTipoOperacion.SelectedValue,
                    .referencia_ubicacion = txtRef.Text,
                    .cantidad_transaccion = Convert.ToDouble(txtCantidad.Text),
                    .id_articulo = Convert.ToInt32(ddlListaArticulos.SelectedValue),
                    .documento_transaccion = urlDoc
                }
                bError = Create.Historico(_Nuevo)
#End Region

                If bError Then

                    Dim Edit = Getter.Articulo(Convert.ToInt32(ddlListaArticulos.SelectedValue), contexto)
                    If ddlTipoOperacion.SelectedValue = "Ent" Then
                        Edit.stock_fisico = Edit.stock_fisico + unidadesSolicitadas
                    Else
                        Edit.stock_fisico = Edit.stock_fisico - unidadesSolicitadas
                    End If
                    bError = Update.Articulo(Edit, contexto)

                    Modal.MostrarAlerta(updatePanelPrinicpal, bError, Mensajes.Registrar.ToString)

                    Get_StockArticulo(Edit.id_articulo)

                Else
                    Modal.MostrarAlerta(updatePanelPrinicpal, bError, Mensajes.Registrar.ToString)
                    Return
                End If

            Else
                Modal.MostrarMensajeAlerta(updatePanelPrinicpal, False, Mensajes.Unidades_Stock.ToString)
            End If

        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se elige un articulo de la lista
    ''' </summary>
    Protected Sub ddlListaArticulos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlListaArticulos.SelectedIndexChanged
        If ddlAlmacen.SelectedValue = String.Empty Then
            lbStockFisico.Text = String.Empty
        Else
            Get_StockArticulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))
        End If

    End Sub

    ''' <summary>
    ''' Metodo que registra una operacion de Entrada/Salida de un articulo en la base de datos
    ''' </summary>
    Protected Sub ValidarStock(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        ValidarStock()
    End Sub

    Protected Sub ddlTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoOperacion.SelectedIndexChanged
        ValidarStock()
    End Sub


    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Protected Sub CambiarCliente(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged

        ddlListaArticulos.Items.Clear()

        If ddlCliente.SelectedValue = "" Then
            ddlAlmacen.SelectedValue = ""
        Else
            Listas.Almacen(ddlAlmacen, Convert.ToInt32(ddlCliente.SelectedValue))
        End If
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un almacen, y se fija el valor del coeficiente volumetrico
    ''' al articulo dependiendo del valor que tenga el coeficiente del almacen
    ''' </summary>
    Protected Sub ddlAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAlmacen.SelectedIndexChanged

        If ddlAlmacen.SelectedValue = String.Empty Then
            ddlListaArticulos.Items.Clear()
        Else
            Listas.Articulo_Almacen(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))

            Get_StockArticulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))


        End If

    End Sub


    Private Sub ValidarStock()

        If txtCantidad.Text <> String.Empty Then

            Dim _Articulo = Getter.Articulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))

            Dim StockFisico As Double = Double.Parse(_Articulo.stock_fisico, CultureInfo.InvariantCulture)
            Dim CantidadSolicitada As Double = Double.Parse(txtCantidad.Text, CultureInfo.InvariantCulture)

            If (CantidadSolicitada > StockFisico) And (ddlTipoOperacion.SelectedValue = "Sal") Then
                Modal.MostrarMensajeAlerta(updatePanelPrinicpal, False, Mensajes.Unidades_Stock.ToString)
                txtCantidad.Text = "0"
            Else
                Modal.OcultarAlerta(updatePanelPrinicpal)
            End If
        End If

    End Sub


End Class