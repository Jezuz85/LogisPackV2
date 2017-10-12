Imports System.Threading
Imports CapaDatos
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Modulo_Articulo

    Public Shared ListaTD As List(Of IWebElement)
    Public Shared viewArticulo As ViewArticulo = New ViewArticulo()

    Public Shared Sub Crear_Articulo1(ByRef _Articulo As Articulo)

        _Articulo = New Articulo With {
            .codigo = Valores._Art_cod.ToString,
            .nombre = Valores._Art_nom.ToString,
            .referencia_picking = Valores._Art_ref_pic.ToString,
            .referencia1 = Valores._Art_ref1.ToString,
            .referencia2 = Valores._Art_ref2.ToString,
            .referencia3 = Valores._Art_ref3.ToString,
            .valor_articulo = Valores._Art_valor_art.ToString,
            .valor_asegurado = Valores._Art_valor_ase.ToString,
            .peso = Valores._Art_peso.ToString,
            .alto = Valores._Art_alto.ToString,
            .largo = Valores._Art_largo.ToString,
            .ancho = Valores._Art_ancho.ToString,
            .coeficiente_volumetrico = Valores._Art_coef_vol.ToString,
            .observaciones_articulo = Valores._Art_obs_art.ToString,
            .observaciones_generales = Valores._Art_obs_gen.ToString,
            .stock_fisico = Valores._Art_stock_fis.ToString,
            .stock_minimo = Valores._Art_stock_min.ToString
        }

    End Sub
    Public Shared Sub Crear_Articulo2(ByRef _Articulo As Articulo)

        _Articulo = New Articulo With {
            .codigo = Valores._Art_cod_Edit.ToString,
            .nombre = Valores._Art_nom_Edit.ToString,
            .referencia_picking = Valores._Art_ref_pic_Edit.ToString,
            .referencia1 = Valores._Art_ref1_Edit.ToString,
            .referencia2 = Valores._Art_ref2_Edit.ToString,
            .referencia3 = Valores._Art_ref3_Edit.ToString,
            .valor_articulo = Valores._Art_valor_art_Edit.ToString,
            .valor_asegurado = Valores._Art_valor_ase_Edit.ToString,
            .peso = Valores._Art_peso_Edit.ToString,
            .alto = Valores._Art_alto_Edit.ToString,
            .largo = Valores._Art_largo_Edit.ToString,
            .ancho = Valores._Art_ancho_Edit.ToString,
            .coeficiente_volumetrico = Valores._Art_coef_vol_Edit.ToString,
            .observaciones_articulo = Valores._Art_obs_art_Edit.ToString,
            .observaciones_generales = Valores._Art_obs_gen_Edit.ToString,
            .stock_fisico = Valores._Art_stock_fis_Edit.ToString,
            .stock_minimo = Valores._Art_stock_min_Edit.ToString
        }

    End Sub



    Public Shared Sub Registrar(ByRef driver As ChromeDriver, ByRef _Cliente As Cliente, ByRef _Almacen As Almacen,
        ByRef _Articulo As Articulo, ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad)

        driver.Navigate().GoToUrl(viewArticulo.URL)

        Funciones.ID_Boton_Click(driver, viewArticulo.BotonAddModal.ToString)

        Thread.Sleep(3000)

        Funciones.SendText_ById(driver, viewArticulo.txtCodigo, _Articulo.codigo)
        Funciones.SendText_ById(driver, viewArticulo.txtNombre, _Articulo.nombre)
        Funciones.SendText_ById(driver, viewArticulo.txtRefPick, _Articulo.referencia_picking)
        Funciones.SendText_ById(driver, viewArticulo.txtRef1, _Articulo.referencia1)
        Funciones.SendText_ById(driver, viewArticulo.txtRef2, _Articulo.referencia2)
        Funciones.SendText_ById(driver, viewArticulo.txtRef3, _Articulo.referencia3)
        Funciones.SendText_ById(driver, viewArticulo.txtValArticulo, _Articulo.valor_articulo)
        Funciones.SendText_ById(driver, viewArticulo.txtValAsegurado, _Articulo.valor_asegurado)
        Funciones.SendText_ById(driver, viewArticulo.txtPeso, _Articulo.peso)
        Funciones.SendText_ById(driver, viewArticulo.txtAlto, _Articulo.alto)
        Funciones.SendText_ById(driver, viewArticulo.txtLargo, _Articulo.largo)
        Funciones.SendText_ById(driver, viewArticulo.txtAncho, _Articulo.ancho)
        Funciones.SendText_ById(driver, viewArticulo.txtCoefVol, _Articulo.coeficiente_volumetrico)
        Funciones.SendText_ById(driver, viewArticulo.txtObsGen, _Articulo.observaciones_articulo)
        Funciones.SendText_ById(driver, viewArticulo.txtObsArt, _Articulo.observaciones_generales)
        Funciones.SendText_ById(driver, viewArticulo.txtStockFisico, _Articulo.stock_fisico)
        Funciones.SendText_ById(driver, viewArticulo.txtStockMinimo, _Articulo.stock_minimo)

        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlCliente, _Cliente.nombre)
        Thread.Sleep(2000)
        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlAlmacen, _Almacen.nombre)
        Thread.Sleep(2000)
        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlTipoArticulo, viewArticulo.TipoArticulo_Normal)
        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlTipoUnidad, _Tipo_Unidad.nombre)
        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlTipoFacturacion, _Tipo_Facturacion.nombre)
        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlIdentificacion, viewArticulo.Ide_RF)

        Funciones.ID_Boton_Click(driver, viewArticulo.BotonAdd)

        Thread.Sleep(3000)

        driver.Navigate().GoToUrl(viewArticulo.URL)

    End Sub

    Public Shared Sub RegistrarArticulo(ByRef driver As ChromeDriver, ByRef _Cliente As Cliente, ByRef _Almacen As Almacen,
        ByRef _Articulo As Articulo, ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad)

        Crear_Articulo1(_Articulo)
        Registrar(driver, _Cliente, _Almacen, _Articulo, _Tipo_Facturacion, _Tipo_Unidad)

    End Sub

    Public Shared Sub Existencia_Valor_Detalles(ByRef driver As ChromeDriver, ByRef _Cliente As Cliente,
        ByRef _Almacen As Almacen, ByRef _Articulo As Articulo, ByRef _Tipo_Facturacion As Tipo_Facturacion,
        ByRef _Tipo_Unidad As Tipo_Unidad)


    End Sub


End Class
