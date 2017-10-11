
Imports System.Web
Imports System.Web.UI.WebControls
Imports Microsoft.Office.Interop

Public Class Manager_Excel

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


    Public Shared Function CargaMasiva(ByRef fuExcel As FileUpload, ByVal SheetName As String, _id_almacen As String) As List(Of String)

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim idAlmacen = Convert.ToInt32(_id_almacen)
        _Errores = New List(Of String)()

        If fuExcel.HasFile Then

#Region "variables"
            Dim urlDoc As String = Utilidades_Fileupload.Subir_Archivo(fuExcel, Paginas.URL_Temp.ToString, "ExcelTemp_" & DateTime.Now.ToString("yyyy-MM-dd") & "")

            Dim Proceed As Boolean = False
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing
            Dim xlCells As Excel.Range = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(HttpContext.Current.Server.MapPath(urlDoc))
            xlApp.Visible = True
            xlWorkSheets = xlWorkBook.Sheets
#End Region
            For x As Integer = 1 To xlWorkSheets.Count

                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

                If xlWorkSheet.Name = SheetName Then

                    Dim range = xlWorkSheet.UsedRange

                    For rowIndex = 2 To range.Rows.Count
                        idAlmacen = Convert.ToInt32(_id_almacen)
                        CargarFila(range, rowIndex)
                        Validarfila(rowIndex, fuExcel.FileName)
                    Next

                    If _Errores.Count = 0 Then
                        For rowIndex = 2 To range.Rows.Count

                            CargarFila(range, rowIndex)

                            Dim TipoFacturacion = Getter.Tipo_Facturacion(_id_tipo_facturacion)
                            _id_tipo_facturacion = TipoFacturacion.id_tipo_facturacion

                            Dim TipoUnidad = Getter.Tipo_Unidad(_id_tipo_unidad)
                            _id_tipo_unidad = TipoUnidad.id_tipo_unidad

                            '-----------------Calculos------------------------------------
                            Dim _M3 As Double = Manager_Articulo.CalcularM3(_alto, _ancho, _largo)
                            Dim _peso_volumen As Double = Manager_Articulo.Calcular_PesoVolumetrico(_alto, _ancho, _largo, _coeficiente_volumetrico)
                            Dim _valoracion_stock As Double = Manager_Articulo.Calcular_ValoracionStock(_stock_fisico, _valor_articulo)
                            Dim _valoracion_seguro As Double = Manager_Articulo.Calcular_ValoracionSeguro(_valor_asegurado, _stock_fisico)

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
                                .zona = Manager_Articulo.LlenarCeros(_zona),
                                .estante = Manager_Articulo.LlenarCeros(_estante),
                                .fila = Manager_Articulo.LlenarCeros(_fila),
                                .columna = Manager_Articulo.LlenarCeros(_columna),
                                .panel = Manager_Articulo.LlenarCeros(_panel),
                                .referencia_ubicacion = _referencia_ubicacion
                                }


                            contexto.Articulo.Add(_Nuevo)
                            contexto.Ubicacion.Add(_Ubicacion)

                        Next
                    Else
                        cerrarExcel(xlApp, xlWorkBooks, xlWorkBook, xlWorkSheet, xlWorkSheets, xlCells, urlDoc)
                        Return _Errores
                    End If

                    Try
                        contexto.SaveChanges()
                    Catch ex As Exception
                        Console.WriteLine(ex)
                    End Try

                    Proceed = True
                    Exit For
                End If

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing
            Next

            If Proceed Then
                xlWorkSheet.Activate()
            Else
                cerrarExcel(xlApp, xlWorkBooks, xlWorkBook, xlWorkSheet, xlWorkSheets, xlCells, urlDoc)
                _Errores.Add(SheetName & " not found.")
                Return _Errores
            End If

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()
            ReleaseComObject(xlCells)
            ReleaseComObject(xlWorkSheets)
            ReleaseComObject(xlWorkSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlWorkBooks)
            ReleaseComObject(xlApp)

            My.Computer.FileSystem.DeleteFile(HttpContext.Current.Server.MapPath(urlDoc))
        Else
            'MessageBox.Show("'" & FileName & "' not located. Try one of the write examples first.")
        End If

        _Errores.Add(Mensajes.CargaExito.ToString)
        Return _Errores

    End Function

    Private Shared Sub ReleaseComObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub

    Private Shared Sub cerrarExcel(ByRef xlApp As Excel.Application, ByRef xlWorkBooks As Excel.Workbooks,
                            ByRef xlWorkBook As Excel.Workbook, ByRef xlWorkSheet As Excel.Worksheet,
                            ByRef xlWorkSheets As Excel.Sheets, ByRef xlCells As Excel.Range, urlDoc As String)

        Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
        xlWorkSheet = Nothing

        xlWorkBook.Close()
        xlApp.UserControl = True
        xlApp.Quit()
        ReleaseComObject(xlCells)
        ReleaseComObject(xlWorkSheets)
        ReleaseComObject(xlWorkSheet)
        ReleaseComObject(xlWorkBook)
        ReleaseComObject(xlWorkBooks)
        ReleaseComObject(xlApp)

        My.Computer.FileSystem.DeleteFile(HttpContext.Current.Server.MapPath(urlDoc))
    End Sub

    Private Shared Sub Validarfila(rowIndex As Integer, nombreArchivo As String)

        '-----------------Validar Tipo Facturacion y Tipo de Unidad
        If Validaciones.Exist_Tipo_Facturacion(_id_tipo_facturacion) = False Then
            _Errores.Add(Format_Respuesta_NoExiste(Mensajes.NoExiste_TipoFacturacion.ToString, rowIndex, nombreArchivo))
        End If

        If Validaciones.Exist_Tipo_Unidad(_id_tipo_unidad) = False Then
            _Errores.Add(Format_Respuesta_NoExiste(Mensajes.NoExiste_TipoUnidad.ToString, rowIndex, nombreArchivo))
        End If

        If Validaciones.Identificacion(_identificacion) = False Then
            _Errores.Add(Format_Respuesta_Valores_Permitidos(Mensajes.NoExiste_Identificacion.ToString, rowIndex, nombreArchivo))
        End If

        '-----------------Validar longitud campos
        If Validaciones.Longitud_Campo(_codigo, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "Código", "25", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_nombre, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "Nombre", "40", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_referencia_picking, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "Referencia Picking", "25", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_referencia1, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "Referencia 1", "25", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_referencia2, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "Referencia 2", "25", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_referencia3, 25) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "Referencia 3", "25", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_observaciones_articulo, 300) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "Observaciones Articulo", "300", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_observaciones_generales, 300) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "Observaciones Generales", "300", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_zona, 4) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "zona", "4", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_estante, 4) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "estante", "4", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_fila, 4) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "fila", "4", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_columna, 4) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "columna", "4", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_panel, 4) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "panel", "4", rowIndex, nombreArchivo))
        End If
        If Validaciones.Longitud_Campo(_referencia_ubicacion, 40) Then
            _Errores.Add(Format_Respuesta_Longitud(Mensajes.Longitud.ToString, "Referencia ubicación", "40", rowIndex, nombreArchivo))
        End If

        '-----------------Validar campos numericos
        If Validaciones.Validarnumero(_valor_articulo) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Mensajes.SoloNumero.ToString, "Valor Artículo", rowIndex, nombreArchivo))
        End If
        If Validaciones.Validarnumero(_valor_asegurado) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Mensajes.SoloNumero.ToString, "Valor Asegurado", rowIndex, nombreArchivo))
        End If
        If Validaciones.Validarnumero(_peso) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Mensajes.SoloNumero.ToString, "Peso", rowIndex, nombreArchivo))
        End If
        If Validaciones.Validarnumero(_alto) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Mensajes.SoloNumero.ToString, "Alto", rowIndex, nombreArchivo))
        End If
        If Validaciones.Validarnumero(_largo) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Mensajes.SoloNumero.ToString, "Largo", rowIndex, nombreArchivo))
        End If
        If Validaciones.Validarnumero(_ancho) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Mensajes.SoloNumero.ToString, "Ancho", rowIndex, nombreArchivo))
        End If
        If Validaciones.Validarnumero(_coeficiente_volumetrico) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Mensajes.SoloNumero.ToString, "Coeficiente Volumétrico", rowIndex, nombreArchivo))
        End If
        If Validaciones.Validarnumero(_stock_fisico) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Mensajes.SoloNumero.ToString, "Stock Físico", rowIndex, nombreArchivo))
        End If
        If Validaciones.Validarnumero(_stock_minimo) = False Then
            _Errores.Add(Format_Respuesta_Numerico(Mensajes.SoloNumero.ToString, "Stock Mínimo", rowIndex, nombreArchivo))
        End If


    End Sub

    Private Shared Sub CargarFila(range As Excel.Range, rowIndex As Integer)

        _codigo = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 1).value, String.Empty)
        _nombre = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 2).value, String.Empty)
        _referencia_picking = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 3).value, String.Empty)
        _referencia1 = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 4).value, String.Empty)
        _referencia2 = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 5).value, String.Empty)
        _referencia3 = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 6).value, String.Empty)
        _identificacion = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 7).value, String.Empty)
        _valor_articulo = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 8).value, "0")
        _valor_asegurado = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 9).value, "0")
        _peso = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 10).value, "0")
        _alto = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 11).value, "0")
        _largo = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 12).value, "0")
        _ancho = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 13).value, "0")
        _coeficiente_volumetrico = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 14).value, "0")
        _observaciones_articulo = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 15).value, String.Empty)
        _observaciones_generales = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 16).value, String.Empty)
        _stock_fisico = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 17).value, "0")
        _stock_minimo = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 18).value, "0")
        _id_tipo_facturacion = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 19).value, "0")
        _id_tipo_unidad = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 20).value, "0")
        _zona = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 21).value, String.Empty)
        _estante = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 22).value, String.Empty)
        _fila = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 23).value, String.Empty)
        _columna = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 24).value, String.Empty)
        _panel = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 25).value, String.Empty)
        _referencia_ubicacion = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 26).value, String.Empty)

    End Sub

    '-------------------validar respuestas

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
