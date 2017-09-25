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

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()

        Listas.ArticuloTodos(ddlListaArticulos)
        Get_StockArticulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))

    End Sub

    ''' <summary>
    ''' Metodo que muestra por pantalla el valor del stock fisico de un articulo seleccionado
    ''' </summary>
    Public Sub Get_StockArticulo(idArticulo As Integer)

        Dim _Articulo = Getter.Articulo(idArticulo)
        lbStockFisico.Text = _Articulo.stock_fisico.ToString()

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

                Dim urlDoc As String = Utilidades_Fileupload.Subir_Archivo(fuDocumento, Paginas.URL_Operacion.ToString, "Doc_" & ddlTipoOperacion.SelectedValue & "_" & _articulo.id_articulo & "_" & Convert.ToDateTime(txtFechaOperacion.Text).ToString("yyyy-MM-dd") & "_")
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
        Get_StockArticulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))
    End Sub

    ''' <summary>
    ''' Metodo que registra una operacion de Entrada/Salida de un articulo en la base de datos
    ''' </summary>
    Protected Sub ValidarStock(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged

        Dim _Articulo = Getter.Articulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))

        Dim StockFisico As Double = Double.Parse(_Articulo.stock_fisico, CultureInfo.InvariantCulture)
        Dim CantidadSolicitada As Double = Double.Parse(txtCantidad.Text, CultureInfo.InvariantCulture)

        If CantidadSolicitada > StockFisico Then
            Modal.MostrarMensajeAlerta(updatePanelPrinicpal, False, Mensajes.Unidades_Stock.ToString)
        Else
            Modal.OcultarAlerta(updatePanelPrinicpal)
        End If

    End Sub

End Class