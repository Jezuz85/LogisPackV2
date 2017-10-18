Imports System.Threading
Imports CapaDatos
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Modulo_Articulo

    Public Shared ListaTD As List(Of IWebElement)
    Public Shared viewArticulo As ViewArticulo = New ViewArticulo()

    'Public Shared ReadOnly Iterator Property NextArticulo As IEnumerable(Of Articulo)
    '    Get
    '        Yield New Articulo With {.nombre = "Tadpole", .codigo = 400}
    '        Yield New Articulo With {.nombre = "Tadpole", .codigo = 400}
    '        Yield New Articulo With {.nombre = "Tadpole", .codigo = 400}
    '        Yield New Articulo With {.nombre = "Tadpole", .codigo = 400}
    '    End Get
    'End Property


    Public Shared Sub Crear_Obj_Articulo1(ByRef _Articulo As Articulo)



        '-----------------Calculos
        Dim M3 As Double = Mgr_Articulo.CalcularM3(Valores._Art_alto.ToString, Valores._Art_ancho.ToString, Valores._Art_largo.ToString)
        Dim PesoVol As Double = Mgr_Articulo.Calcular_PesoVolumetrico(Valores._Art_alto.ToString, Valores._Art_ancho.ToString, Valores._Art_largo.ToString, Valores._Art_coef_vol.ToString)
        Dim valoracionStock As Double = Mgr_Articulo.Calcular_ValoracionStock(Valores._Art_stock_fis.ToString, Valores._Art_valor_art.ToString)
        Dim valoracionSeguro As Double = Mgr_Articulo.Calcular_ValoracionSeguro(Valores._Art_valor_ase.ToString, Valores._Art_stock_fis.ToString)

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
            .stock_minimo = Valores._Art_stock_min.ToString,
            .cubicaje = M3,
            .peso_volumen = PesoVol,
            .valoracion_stock = valoracionStock,
            .valoracion_seguro = valoracionSeguro
        }

    End Sub
    Public Shared Sub Crear_Obj_Articulo2(ByRef _Articulo As Articulo)

        '-----------------Calculos
        Dim M3 As Double = Mgr_Articulo.CalcularM3(Valores._Art_alto_Edit.ToString, Valores._Art_ancho_Edit.ToString,
            Valores._Art_largo_Edit.ToString)

        Dim PesoVol As Double = Mgr_Articulo.Calcular_PesoVolumetrico(Valores._Art_alto_Edit.ToString,
            Valores._Art_ancho_Edit.ToString, Valores._Art_largo_Edit.ToString, Valores._Art_coef_vol_Edit.ToString)

        Dim valoracionStock As Double = Mgr_Articulo.Calcular_ValoracionStock(Valores._Art_stock_fis_Edit.ToString,
            Valores._Art_valor_art_Edit.ToString)

        Dim valoracionSeguro As Double = Mgr_Articulo.Calcular_ValoracionSeguro(Valores._Art_valor_ase_Edit.ToString,
            Valores._Art_stock_fis_Edit.ToString)

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
            .stock_minimo = Valores._Art_stock_min_Edit.ToString,
            .cubicaje = M3,
            .peso_volumen = PesoVol,
            .valoracion_stock = valoracionStock,
            .valoracion_seguro = valoracionSeguro
        }

    End Sub

    Public Shared Sub Registrar(ByRef driver As ChromeDriver, ByRef _Cliente As Cliente, ByRef _Almacen As Almacen,
        ByRef _Articulo As Articulo, ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad)

        driver.Navigate().GoToUrl(viewArticulo.URL)

        Funciones.ID_Boton_Click(driver, viewArticulo.BotonAddModal.ToString)

        Thread.Sleep(2000)

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
        Funciones.SendText_ById(driver, viewArticulo.txtObsGen, _Articulo.observaciones_generales)
        Funciones.SendText_ById(driver, viewArticulo.txtObsArt, _Articulo.observaciones_articulo)
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

        Funciones.Clear_SendText_ById(driver, viewArticulo.txtCoefVol, _Articulo.coeficiente_volumetrico)

        Funciones.ID_Boton_Click(driver, viewArticulo.BotonAdd)

        Thread.Sleep(2000)

        driver.Navigate().GoToUrl(viewArticulo.URL)
    End Sub

    Public Shared Sub Editar(ByRef driver As ChromeDriver, ByRef _Cliente As Cliente, ByRef _Almacen As Almacen,
         ByRef _Articulo As Articulo, ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad)

        driver.Navigate().GoToUrl(viewArticulo.URL)

        Funciones.Obtener_FilasGrid(driver, viewArticulo.GridPrinicipal, ListaTD)
        Funciones.BotonGrid_Click(ListaTD, _Almacen.nombre, viewArticulo.BotonEditModal.ToString)

        Thread.Sleep(2000)

        Funciones.Clear_SendText_ById(driver, viewArticulo.txtCodigo, _Articulo.codigo)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtNombre, _Articulo.nombre)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtRefPick, _Articulo.referencia_picking)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtRef1, _Articulo.referencia1)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtRef2, _Articulo.referencia2)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtRef3, _Articulo.referencia3)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtValArticulo, _Articulo.valor_articulo)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtValAsegurado, _Articulo.valor_asegurado)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtPeso, _Articulo.peso)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtAlto, _Articulo.alto)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtLargo, _Articulo.largo)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtAncho, _Articulo.ancho)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtObsGen, _Articulo.observaciones_generales)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtObsArt, _Articulo.observaciones_articulo)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtStockFisico, _Articulo.stock_fisico)
        Funciones.Clear_SendText_ById(driver, viewArticulo.txtStockMinimo, _Articulo.stock_minimo)

        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlCliente, _Cliente.nombre)
        Thread.Sleep(2000)
        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlAlmacen, _Almacen.nombre)
        Thread.Sleep(2000)
        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlTipoArticulo, viewArticulo.TipoArticulo_Normal)
        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlTipoUnidad, _Tipo_Unidad.nombre)
        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlTipoFacturacion, _Tipo_Facturacion.nombre)
        Funciones.ID_DropDownList_SelectedValue(driver, viewArticulo.ddlIdentificacion, viewArticulo.Ide_RF)

        Funciones.Clear_SendText_ById(driver, viewArticulo.txtCoefVol, _Articulo.coeficiente_volumetrico)

        Funciones.ID_Boton_Click(driver, viewArticulo.BotonAdd)

        Thread.Sleep(2000)

        driver.Navigate().GoToUrl(viewArticulo.URL)
    End Sub

    Public Shared Sub Detalles(ByRef driver As ChromeDriver, ByRef _Cliente As Cliente, ByRef _Almacen As Almacen,
        ByRef _Articulo As Articulo, ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad,
        ListaTD As List(Of IWebElement))

        Funciones.BotonGrid_Click(ListaTD, _Almacen.nombre, viewArticulo.BotonDetallesModal)

        Thread.Sleep(2000)

        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbTipoArticulo, viewArticulo.TipoArticulo_Normal)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbAlmacen, _Almacen.nombre)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbStockMinimo, _Articulo.stock_minimo)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbStockFisico, _Articulo.stock_fisico)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbCodigo, _Articulo.codigo)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbNombre, _Articulo.nombre)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbRefPick, _Articulo.referencia_picking)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbRef1, _Articulo.referencia1)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbRef2, _Articulo.referencia2)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbRef3, _Articulo.referencia3)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbTipoUnidad, _Tipo_Unidad.nombre)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbPeso, _Articulo.peso & " Kgs")
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbAlto, _Articulo.alto)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbLargo, _Articulo.largo)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbAncho, _Articulo.ancho)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbCubicaje, _Articulo.cubicaje)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbCoefVol, _Articulo.coeficiente_volumetrico & " Kgs(m³)")
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbPesoVol, _Articulo.peso_volumen & " Kgs(m³)")
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbTipoFacturacion, _Tipo_Facturacion.nombre)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbIdentificacion, viewArticulo.Ide_RF)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbValArticulo, _Articulo.valor_articulo)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbValAsegurado, _Articulo.valor_asegurado)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbValStock, _Articulo.valoracion_stock)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbObsGen, _Articulo.observaciones_generales)
        Pruebas.Existencia_Valor_Label(driver, viewArticulo.lbObsArt, _Articulo.observaciones_articulo)



    End Sub

    Public Shared Sub RegistrarArticulo(ByRef driver As ChromeDriver, ByRef _Cliente As Cliente, ByRef _Almacen As Almacen,
        ByRef _Articulo As Articulo, ByRef _Tipo_Facturacion As Tipo_Facturacion, ByRef _Tipo_Unidad As Tipo_Unidad)

        Crear_Obj_Articulo1(_Articulo)
        Registrar(driver, _Cliente, _Almacen, _Articulo, _Tipo_Facturacion, _Tipo_Unidad)

    End Sub

    Public Shared Sub Existencia_Valor_Grid(ByRef driver As ChromeDriver, ByRef _ListaTD As List(Of IWebElement),
            ByRef _Cliente As Cliente, ByRef _Almacen As Almacen, ByRef _Articulo As Articulo)

        '------valido que los valores existen en el grid
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Almacen.nombre)
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Cliente.nombre)
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Articulo.codigo)
        Pruebas.Existencia_Valor_Grid(driver, _ListaTD, _Articulo.nombre)
    End Sub



End Class
