
Imports System.Web
Imports System.Web.UI.WebControls
Imports Microsoft.Office.Interop

Public Class Mgr_Excel

    Public Shared _codigo As String
    Public Shared _nombre As String
    Public Shared _referencia1 As String
    Public Shared _referencia2 As String
    Public Shared _referencia3 As String
    Public Shared _identificacion As String
    Public Shared _observaciones_articulo As String
    Public Shared _observaciones_generales As String
    Public Shared _id_tipo_facturacion As String
    Public Shared _id_tipo_unidad As String
    Public Shared _referencia_picking As String
    Public Shared idAlmacen As Integer
    Public Shared _valor_articulo As String
    Public Shared _valor_asegurado As String
    Public Shared _peso As String
    Public Shared _alto As String
    Public Shared _largo As String
    Public Shared _ancho As String
    Public Shared _coeficiente_volumetrico As String
    Public Shared _stock_fisico As String
    Public Shared _stock_minimo As String
    Public Shared _M3 As String
    Public Shared _peso_volumen As String
    Public Shared _valoracion_stock As String
    Public Shared _valoracion_seguro As String
    Public Shared _zona As String
    Public Shared _estante As String
    Public Shared _fila As String
    Public Shared _columna As String
    Public Shared _panel As String
    Public Shared _referencia_ubicacion As String
    Public Shared _Errores As List(Of String)

    Public Shared Function CargarExcel(ByRef fuExcel As FileUpload, ByVal SheetName As String, _id_almacen As String) As List(Of String)

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim idAlmacen = Convert.ToInt32(_id_almacen)
        _Errores = New List(Of String)()

        If fuExcel.HasFile Then
            Dim urlDoc As String = Util_Fileupload.Subir_Archivo(fuExcel, Val_Paginas.URL_Temp.ToString, "ExcelTemp_" & DateTime.Now.ToString("yyyy-MM-dd") & "")
            urlDoc = Util_Fileupload.DevolverRutaImagen(fuExcel, Val_Paginas.URL_Temp.ToString, "ExcelTemp_" & DateTime.Now.ToString("yyyy-MM-dd") & "")

            Dim dt As DataTable = DLOffice.ControladorOffice.RellenarDTExcel(urlDoc, "SELECT * FROM " & SheetName, "")

            Dim numeroFila = 1

            For Each row As DataRow In dt.Rows

                CargarFilas(row)
                Validarfila(numeroFila, fuExcel.FileName)
                numeroFila += 1

            Next

            If _Errores.Count = 0 Then

                For Each row As DataRow In dt.Rows

                    CargarFilas(row)

                    Dim TipoFacturacion = Mgr_TipoFacturacion.Get_Tipo_FacturacionByNombre(_id_tipo_facturacion)
                    _id_tipo_facturacion = TipoFacturacion.id_tipo_facturacion

                    Dim TipoUnidad = Mgr_TipoUnidad.Get_Tipo_UnidadByNombre(_id_tipo_unidad)
                    _id_tipo_unidad = TipoUnidad.id_tipo_unidad

                    '-----------------Calculos------------------------------------
                    Dim _M3 As Double = Mgr_Articulo.CalcularM3(_alto, _ancho, _largo)
                    Dim _peso_volumen As Double = Mgr_Articulo.Calcular_PesoVolumetrico(_alto, _ancho, _largo, _coeficiente_volumetrico)
                    Dim _valoracion_stock As Double = Mgr_Articulo.Calcular_ValoracionStock(_stock_fisico, _valor_articulo)
                    Dim _valoracion_seguro As Double = Mgr_Articulo.Calcular_ValoracionSeguro(_valor_asegurado, _stock_fisico)

                    Dim _Nuevo As New Articulo With {
                    .codigo = _codigo,
                    .nombre = _nombre,
                    .referencia_picking = _referencia_picking,
                    .referencia1 = _referencia1,
                    .referencia2 = _referencia3,
                    .referencia3 = _referencia1,
                    .identificacion = _identificacion,
                    .valor_articulo = _valor_articulo,
                    .valoracion_stock = _valoracion_stock,
                    .valoracion_seguro = _valoracion_seguro,
                    .valor_asegurado = _valor_asegurado,
                    .peso = _peso,
                    .alto = _alto,
                    .largo = _largo,
                    .ancho = _ancho,
                    .coeficiente_volumetrico = _coeficiente_volumetrico,
                    .cubicaje = _M3,
                    .peso_volumen = _peso_volumen,
                    .observaciones_articulo = _observaciones_articulo,
                    .observaciones_generales = _observaciones_generales,
                    .stock_fisico = _stock_fisico,
                    .stock_minimo = _stock_minimo,
                    .id_almacen = idAlmacen,
                    .id_tipo_facturacion = _id_tipo_facturacion,
                    .id_tipo_unidad = _id_tipo_unidad,
                    .tipoArticulo = "Normal"
                }

                    Dim _Ubicacion As New Ubicacion With {
                        .id_articulo = _Nuevo.id_articulo,
                        .zona = Mgr_Articulo.LlenarCeros(_zona),
                        .estante = Mgr_Articulo.LlenarCeros(_estante),
                        .fila = Mgr_Articulo.LlenarCeros(_fila),
                        .columna = Mgr_Articulo.LlenarCeros(_columna),
                        .panel = Mgr_Articulo.LlenarCeros(_panel),
                        .referencia_ubicacion = _referencia_ubicacion
                        }


                    contexto.Articulo.Add(_Nuevo)
                    contexto.Ubicacion.Add(_Ubicacion)


                Next

            Else
                Return _Errores
            End If

            _Errores.Add(Val_General.CargaExito.ToString)
            Return _Errores

        End If

    End Function

    Private Shared Sub CargarFilas(row As DataRow)

        _codigo = Util_Validaciones.Validar_Campo_Vacio(CStr(row("codigo")), String.Empty)
        _nombre = Util_Validaciones.Validar_Campo_Vacio(CStr(row("nombre")), String.Empty)
        _referencia_picking = Util_Validaciones.Validar_Campo_Vacio(CStr(row("referencia_picking")), String.Empty)
        _referencia1 = Util_Validaciones.Validar_Campo_Vacio(CStr(row("referencia1")), String.Empty)
        _referencia2 = Util_Validaciones.Validar_Campo_Vacio(CStr(row("referencia2")), String.Empty)
        _referencia3 = Util_Validaciones.Validar_Campo_Vacio(CStr(row("referencia3")), String.Empty)
        _identificacion = Util_Validaciones.Validar_Campo_Vacio(CStr(row("identificacion")), String.Empty)
        _valor_articulo = Util_Validaciones.Validar_Campo_Vacio(CStr(row("valor_articulo")), "0")
        _valor_asegurado = Util_Validaciones.Validar_Campo_Vacio(CStr(row("valor_asegurado")), "0")
        _peso = Util_Validaciones.Validar_Campo_Vacio(CStr(row("peso")), "0")
        _alto = Util_Validaciones.Validar_Campo_Vacio(CStr(row("alto")), "0")
        _largo = Util_Validaciones.Validar_Campo_Vacio(CStr(row("largo")), "0")
        _ancho = Util_Validaciones.Validar_Campo_Vacio(CStr(row("ancho")), "0")
        _coeficiente_volumetrico = Util_Validaciones.Validar_Campo_Vacio(CStr(row("coeficiente_volumetrico")), "0")
        _observaciones_articulo = Util_Validaciones.Validar_Campo_Vacio(CStr(row("observaciones_articulo")), String.Empty)
        _observaciones_generales = Util_Validaciones.Validar_Campo_Vacio(CStr(row("observaciones_generales")), String.Empty)
        _stock_fisico = Util_Validaciones.Validar_Campo_Vacio(CStr(row("stock_fisico")), "0")
        _stock_minimo = Util_Validaciones.Validar_Campo_Vacio(CStr(row("stock_minimo")), "0")
        _id_tipo_facturacion = Util_Validaciones.Validar_Campo_Vacio(CStr(row("tipo_facturacion")), "0")
        _id_tipo_unidad = Util_Validaciones.Validar_Campo_Vacio(CStr(row("tipo_unidad")), "0")
        _zona = Util_Validaciones.Validar_Campo_Vacio(CStr(row("zona")), String.Empty)
        _estante = Util_Validaciones.Validar_Campo_Vacio(CStr(row("estante")), String.Empty)
        _fila = Util_Validaciones.Validar_Campo_Vacio(CStr(row("fila")), String.Empty)
        _columna = Util_Validaciones.Validar_Campo_Vacio(CStr(row("columna")), String.Empty)
        _panel = Util_Validaciones.Validar_Campo_Vacio(CStr(row("panel")), String.Empty)
        _referencia_ubicacion = Util_Validaciones.Validar_Campo_Vacio(CStr(row("referencia_ubicacion")), String.Empty)

    End Sub

    Private Shared Sub Validarfila(rowIndex As Integer, nombreArchivo As String)

        '-----------------Validar Tipo Facturacion y Tipo de Unidad
        If Util_Validaciones.Exist_Tipo_Facturacion(_id_tipo_facturacion) = False Then
            _Errores.Add(Format_Respuesta_NoExiste(Val_General.NoExiste_TipoFacturacion.ToString, rowIndex, nombreArchivo))
        End If

        If Util_Validaciones.Exist_Tipo_Unidad(_id_tipo_unidad) = False Then
            _Errores.Add(Format_Respuesta_NoExiste(Val_General.NoExiste_TipoUnidad.ToString, rowIndex, nombreArchivo))
        End If

        If Util_Validaciones.Identificacion(_identificacion) = False Then
            _Errores.Add(Format_Respuesta_Valores_Permitidos(Val_General.NoExiste_Identificacion.ToString, rowIndex, nombreArchivo))
        End If

        '-----------------Validar longitud campos
        If Util_Validaciones.Longitud_Campo(_codigo, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "Código", "25", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_nombre, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "Nombre", "40", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_referencia_picking, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "Referencia Picking", "25", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_referencia1, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "Referencia 1", "25", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_referencia2, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "Referencia 2", "25", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_referencia3, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "Referencia 3", "25", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_observaciones_articulo, 300) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "Observaciones Articulo", "300", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_observaciones_generales, 300) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "Observaciones Generales", "300", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_zona, 4) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "zona", "4", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_estante, 4) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "estante", "4", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_fila, 4) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "fila", "4", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_columna, 4) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "columna", "4", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_panel, 4) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "panel", "4", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Longitud_Campo(_referencia_ubicacion, 40) Then
            _Errores.Add(Format_Respuesta_Longitud(Val_General.Longitud.ToString, "Referencia ubicación", "40", rowIndex, nombreArchivo))
        End If

        '-----------------Validar campos numericos
        If Util_Validaciones.Validarnumero(_valor_articulo) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Val_General.SoloNumero.ToString, "Valor Artículo", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Validarnumero(_valor_asegurado) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Val_General.SoloNumero.ToString, "Valor Asegurado", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Validarnumero(_peso) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Val_General.SoloNumero.ToString, "Peso", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Validarnumero(_alto) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Val_General.SoloNumero.ToString, "Alto", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Validarnumero(_largo) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Val_General.SoloNumero.ToString, "Largo", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Validarnumero(_ancho) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Val_General.SoloNumero.ToString, "Ancho", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Validarnumero(_coeficiente_volumetrico) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Val_General.SoloNumero.ToString, "Coeficiente Volumétrico", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Validarnumero(_stock_fisico) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Val_General.SoloNumero.ToString, "Stock Físico", rowIndex, nombreArchivo))
        End If
        If Util_Validaciones.Validarnumero(_stock_minimo) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Val_General.SoloNumero.ToString, "Stock Mínimo", rowIndex, nombreArchivo))
        End If


    End Sub




    '------------------------------------------------------------------
    '------------------------VALIDAR RESPUESTAS------------------------
    '------------------------------------------------------------------
    Private Shared Function Format_Respuesta_NoExiste(mensaje As String, fila As Integer, nombreArchivo As String) As String
        Return mensaje & fila & " del Archivo Excel: <strong>" & nombreArchivo & "</strong>"
    End Function

    Private Shared Function Format_Respuesta_Longitud(mensaje As String, campo As String, maxCaracteres As String, fila As Integer, nombreArchivo As String) As String
        Return mensaje & "<strong>" & campo & "</strong> (Máximo caracteres:" & maxCaracteres & ") en la fila: " & fila & " del Archivo Excel: <strong>" & nombreArchivo & "</strong>"
    End Function

    Private Shared Function Format_Respuesta_Valores_Permitidos(mensaje As String, fila As Integer, nombreArchivo As String) As String
        Return mensaje & fila & " del Archivo Excel: <strong>" & nombreArchivo & "</strong>"
    End Function

    Private Shared Function Format_Respuesta_Numerico(mensaje As String, campo As String, fila As Integer, nombreArchivo As String) As String
        Return mensaje & "<strong>" & campo & "</strong> en la fila: " & fila & " del Archivo Excel: <strong>" & nombreArchivo & "</strong>"
    End Function


End Class
