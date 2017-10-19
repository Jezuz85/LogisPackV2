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
                        "~/Scripts/Modulos/Rutas_Archivos.js"))

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

        bundles.Add(New ScriptBundle("~/bundles/Almacen_Index").Include(
                    "~/Scripts/Modulos/Almacen/Controles_Almacen.js",
                    "~/Scripts/Modulos/Acordeon.js",
                    "~/Scripts/Modulos/Almacen/Almacen_Index.js"))

        bundles.Add(New ScriptBundle("~/bundles/Articulo_Index").Include(
                    "~/Scripts/Modulos/Articulo/Controles_Articulo.js",
                    "~/Scripts/Modulos/Acordeon.js",
                    "~/Scripts/Modulos/Articulo/Articulo_Index.js"))

        bundles.Add(New ScriptBundle("~/bundles/Articulo_Crear").Include(
                    "~/Scripts/Modulos/Articulo/Controles_Articulo.js",
                    "~/Scripts/Modulos/Articulo/Articulo_Crear.js"))

    End Sub
End Class
