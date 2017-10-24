Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Optimization

Public Class BundleConfig
    ' Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkID=303951
    Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/WebFormsJs").Include(
                        "~/Scripts/WebForms/WebForms.js",
                        "~/Scripts/WebForms/WebUIValidation.js",
                        "~/Scripts/WebForms/MenuStandards.js",
                        "~/Scripts/WebForms/Focus.js",
                        "~/Scripts/WebForms/GridView.js",
                        "~/Scripts/WebForms/DetailsView.js",
                        "~/Scripts/WebForms/TreeView.js",
                        "~/Scripts/WebForms/WebParts.js"))

        ' El orden es muy importante para el funcionamiento de estos archivos ya que tienen dependencias explícitas
        bundles.Add(New ScriptBundle("~/bundles/MsAjaxJs").Include(
                "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"))

        ' Use la versión de desarrollo de Modernizr para desarrollar y aprender. Luego, cuando esté listo
        ' para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/MisScripts").Include(
                        "~/Scripts/jquery-3.1.1.slim.js",
                        "~/Scripts/jquery-3.1.1.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js",
                        "~/Scripts/Modulos/Rutas_Archivos.js",
                        "~/Scripts/Custom.js"))

        bundles.Add(New StyleBundle("~/Content/Direcline").Include(
                  "~/Content/NormalizeCss.css",
                  "~/Content/jQueryUiCss.css",
                  "~/Content/BaseCSS.css",
                  "~/Content/MainMasterCss.css",
                  "~/Content/CustomCss.css",
                  "~/Content/Site.css"))

        ScriptManager.ScriptResourceMapping.AddDefinition("respond", New ScriptResourceDefinition() With {
                .Path = "~/Scripts/respond.min.js",
                .DebugPath = "~/Scripts/respond.js"})

#Region "Almacen"
        bundles.Add(New ScriptBundle("~/bundles/Almacen_Index").Include(
                    "~/Scripts/Modulos/Almacen/Controles_Almacen.js",
                    "~/Scripts/Modulos/Acordeon.js",
                    "~/Scripts/Modulos/AutoComplete.js",
                    "~/Scripts/Modulos/Almacen/Almacen_Index.js"))
#End Region

#Region "Cliente"
        bundles.Add(New ScriptBundle("~/bundles/Cliente_Index").Include(
                    "~/Scripts/Modulos/Cliente/Controles_Cliente.js",
                    "~/Scripts/Modulos/Acordeon.js",
                    "~/Scripts/Modulos/AutoComplete.js",
                    "~/Scripts/Modulos/Cliente/Cliente_Index.js"))
#End Region

#Region "TipoFacturacion"
        bundles.Add(New ScriptBundle("~/bundles/TipoFacturacion_Index").Include(
                    "~/Scripts/Modulos/TipoFacturacion/Controles_TipoFacturacion.js",
                    "~/Scripts/Modulos/Acordeon.js",
                    "~/Scripts/Modulos/AutoComplete.js",
                    "~/Scripts/Modulos/TipoFacturacion/TipoFacturacion_Index.js"))
#End Region

#Region "TipoUnidad"
        bundles.Add(New ScriptBundle("~/bundles/TipoUnidad_Index").Include(
                    "~/Scripts/Modulos/TipoUnidad/Controles_TipoUnidad.js",
                    "~/Scripts/Modulos/Acordeon.js",
                    "~/Scripts/Modulos/AutoComplete.js",
                    "~/Scripts/Modulos/TipoUnidad/TipoUnidad_Index.js"))
#End Region

#Region "Operacion"
        bundles.Add(New ScriptBundle("~/bundles/Operacion_Index").Include(
                    "~/Scripts/Modulos/Operacion/Controles_Operacion.js",
                    "~/Scripts/Modulos/Acordeon.js",
                    "~/Scripts/Modulos/AutoComplete.js",
                    "~/Scripts/Modulos/Operacion/Operacion_Index.js"))

        bundles.Add(New ScriptBundle("~/bundles/Operacion_Crear").Include(
                    "~/Scripts/Modulos/Operacion/Controles_Operacion.js",
                    "~/Scripts/Modulos/Operacion/Operacion_Crear.js"))
#End Region

#Region "Articulo"
        bundles.Add(New ScriptBundle("~/bundles/Articulo_Index").Include(
                    "~/Scripts/Modulos/Articulo/Controles_Articulo.js",
                    "~/Scripts/Modulos/Acordeon.js",
                    "~/Scripts/Modulos/AutoComplete.js",
                    "~/Scripts/Modulos/Articulo/Articulo_Index.js"))

        bundles.Add(New ScriptBundle("~/bundles/Articulo_Crear").Include(
                    "~/Scripts/Modulos/Articulo/Controles_Articulo.js",
                    "~/Scripts/Modulos/Articulo/Articulo_Crear.js"))

        bundles.Add(New ScriptBundle("~/bundles/Articulo_Editar").Include(
                    "~/Scripts/Modulos/Articulo/Controles_Articulo.js",
                    "~/Scripts/Modulos/Articulo/Articulo_Editar.js"))
#End Region


    End Sub
End Class
