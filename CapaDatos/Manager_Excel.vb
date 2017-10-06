
Imports System.Web
Imports System.Web.UI.WebControls
Imports Microsoft.Office.Interop

Public Class Manager_Excel


    Public Shared Sub CargaMasiva(ByRef fuExcel As FileUpload, ByVal SheetName As String, _id_almacen As String)
        Dim contexto As LogisPackEntities = New LogisPackEntities()

        If fuExcel.HasFile Then

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

            For x As Integer = 1 To xlWorkSheets.Count

                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

                If xlWorkSheet.Name = SheetName Then

                    Dim range = xlWorkSheet.UsedRange

                    For rowIndex = 2 To range.Rows.Count

                        Dim valor1 As Double = Convert.ToDouble(range.Cells(rowIndex, 8).value)
                        Dim valor2 As Double = Convert.ToDouble(Convert.ToString(range.Cells(rowIndex, 8).value))
                        Dim valor3 As Double = range.Cells(rowIndex, 8).value

                        Dim _codigo As String = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 1).value, String.Empty)
                        Dim _nombre As String = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 2).value, String.Empty)
                        Dim _referencia_picking As String = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 3).value, String.Empty)
                        Dim _referencia1 As String = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 4).value, String.Empty)
                        Dim _referencia2 As String = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 5).value, String.Empty)
                        Dim _referencia3 As String = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 6).value, String.Empty)
                        Dim _identificacion As String = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 7).value, String.Empty)
                        Dim _valor_articulo As Double = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 8).value, "0")
                        Dim _valor_asegurado As Double = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 9).value, "0")
                        Dim _peso As Double = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 10).value, "0")
                        Dim _alto As Double = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 11).value, "0")
                        Dim _largo As Double = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 12).value, "0")
                        Dim _ancho As Double = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 13).value, "0")
                        Dim _coeficiente_volumetrico As Double = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 14).value, "0")
                        Dim _observaciones_articulo As String = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 15).value, String.Empty)
                        Dim _observaciones_generales As String = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 16).value, String.Empty)
                        Dim _stock_fisico As Double = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 17).value, String.Empty)
                        Dim _stock_minimo As Double = Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 18).value, String.Empty)
                        Dim idAlmacen = Convert.ToInt32(_id_almacen)
                        Dim _valoracion_stock As Double = Manager_Articulo.CalcularValoracionStock(_stock_fisico, _valor_articulo)
                        Dim _valoracion_seguro As Double = Manager_Articulo.CalcularValoracionSeguro(_valor_asegurado, _stock_fisico)

                        Dim _M3 As Double = Manager_Articulo.CalcularM3(_alto, _ancho, _largo)
                        Dim _peso_volumen As Double = Manager_Articulo.CalcularPesoVolumetrico(_alto, _ancho, _largo, _coeficiente_volumetrico)

                        Dim _id_tipo_facturacion As String = 0
                        Dim _id_tipo_unidad As String = 0
                        Dim TipoFacturacion = Getter.Tipo_Facturacion(Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 19).value, String.Empty))
                        Dim TipoUnidad = Getter.Tipo_Unidad(Validaciones.Validar_Campo_Vacio(range.Cells(rowIndex, 20).value, String.Empty))

                        If TipoFacturacion IsNot Nothing Then
                            _id_tipo_facturacion = TipoFacturacion.id_tipo_facturacion
                        End If

                        If TipoUnidad IsNot Nothing Then
                            _id_tipo_unidad = TipoUnidad.id_tipo_unidad
                        End If

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
                        contexto.Articulo.Add(_Nuevo)
                    Next


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
                'MessageBox.Show("File is open, if you close Excel just opened outside of this program we will crash-n-burn.")
            Else
                'MessageBox.Show(SheetName & " not found.")
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
    End Sub

    Public Shared Sub ReleaseComObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub

End Class
