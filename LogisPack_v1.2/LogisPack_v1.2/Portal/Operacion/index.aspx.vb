Imports CapaDatos

Public Class index4
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Page.Form.Attributes.Add("enctype", "multipart/form-data")

        If Manager_Usuario.ValidarAutenticado(User) Then
            CargarListas()
        Else
            Response.Redirect(Paginas.Login.ToString)
        End If
    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()

        Listas.ArticuloTodos(ddlListaArticulos)

    End Sub

    ''' <summary>
    ''' Metodo que registra una operacion de Entrada/Salida de un articulo en la base de datos
    ''' </summary>
    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Page.IsValid Then

            Dim _articulo = Getter.Articulo(Convert.ToInt32(ddlListaArticulos.SelectedValue))
            Dim Stock_Picking As Double = Convert.ToDouble(_articulo.stock_fisico)
            Dim unidadesSolicitadas As Double = Convert.ToDouble(txtCantidad.Text)

            If (Stock_Picking > unidadesSolicitadas And ddlTipoOperacion.SelectedValue = "Sal") Or ddlTipoOperacion.SelectedValue = "Ent" Then

#Region "Guardar documento"

                If fuDocumento.FileName IsNot "" Then

                    Dim urlDoc As String = Utilidades_Fileupload.Subir_Archivo(fuDocumento, "../../Archivos/Operacion/", "Doc_" & ddlTipoOperacion.SelectedValue & "_" & _articulo.id_articulo & "_" & Convert.ToDateTime(txtFechaOperacion.Text).ToString("yyyy-MM-dd") & "_")

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

                        If ddlTipoOperacion.SelectedValue = "Ent" Then
                            _articulo.stock_fisico = _articulo.stock_fisico + Convert.ToDouble(txtCantidad.Text)
                        Else
                            _articulo.stock_fisico = _articulo.stock_fisico - Convert.ToDouble(txtCantidad.Text)

                        End If

                        Try
                            contexto.SaveChanges()
                            'Modal.MostrarMsjModal("Se Registro la operación satisfactoriamente", "EXI", Me)
                        Catch ex As Exception
                            'Modal.MostrarMsjModal("Error al registrar operación", "ERR", Me)
                            Return
                        End Try


                    Else
                        'Modal.MostrarMsjModal("Error al registrar operación", "ERR", Me)
                        Return
                    End If

                Else
                    'Modal.MostrarMsjModal("Tiene que subir un documento", "ERR", Me)
                    Return
                End If
#End Region

            Else

                'Modal.MostrarMsjModal("Las unidades del Articulo no Deben superar al stock actual y deben ser mayor a cero", "ERR", Me)

            End If

        End If

        CargarListas()
    End Sub

End Class