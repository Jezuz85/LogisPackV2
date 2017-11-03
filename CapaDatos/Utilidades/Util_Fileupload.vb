Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Web
Imports System.Web.UI.WebControls

Public Class Util_Fileupload

    ''' <summary>
    ''' Metodo donde se almacena una o varias imagenes en el servidor
    ''' </summary>
    Public Shared Function Subir_Archivos(ByRef _archivo As HttpPostedFile, ruta As String, nombre As String) As String

        Dim rutaImagen As String = HttpContext.Current.Server.MapPath(ruta) & nombre & DateTime.Now.ToString("(MM-dd-yy_H-mm-ss)") & ".jpg"

        Dim bmpPostedImage As New Bitmap(_archivo.InputStream)
        Dim objImage As Drawing.Image = ScaleImage(bmpPostedImage, 81)

        objImage.Save(rutaImagen, ImageFormat.Jpeg)

        Return ruta.Replace("~", "") & nombre & DateTime.Now.ToString("(MM-dd-yy_H-mm-ss)") & ".jpg"

    End Function

    ''' <summary>
    ''' Metodo donde se almacena un archivo en el servidor
    ''' </summary>
    Public Shared Function Subir_Archivo(ByRef _archivo As FileUpload, ruta As String, nombre As String) As String

        Dim fileExtension As String = "." + _archivo.FileName.Substring(_archivo.FileName.LastIndexOf(".") + 1).ToLower()
        Dim rutaImagen As String = HttpContext.Current.Server.MapPath(ruta) & nombre & DateTime.Now.ToString("(MM-dd-yy_H-mm-ss)") & fileExtension
        _archivo.SaveAs(rutaImagen)

        Return ruta.Replace("~", "") & nombre & DateTime.Now.ToString("(MM-dd-yy_H-mm-ss)") & fileExtension

    End Function

    Public Shared Function DevolverRutaImagen(ByRef _archivo As FileUpload, ruta As String, nombre As String) As String

        Dim fileExtension As String = "." + _archivo.FileName.Substring(_archivo.FileName.LastIndexOf(".") + 1).ToLower()
        Dim rutaImagen As String = HttpContext.Current.Server.MapPath(ruta) & nombre & DateTime.Now.ToString("(MM-dd-yy_H-mm-ss)") & fileExtension
        Return rutaImagen

    End Function

    ''' <summary>
    ''' Metodo para redimensionar las imagenes a 800 x 600 pxs
    ''' </summary>
    Private Shared Function ScaleImage(image As Drawing.Image, maxHeight As Integer) As Drawing.Image

        Dim ratio = (maxHeight / image.Height)
        Dim newWidth = CInt((image.Width * ratio))
        Dim newHeight = CInt((image.Height * ratio))
        Dim newImage = New Bitmap(800, 600)

        Using g = Graphics.FromImage(newImage)
            g.DrawImage(image, 0, 0, 800, 600)
        End Using

        Return newImage

    End Function

End Class