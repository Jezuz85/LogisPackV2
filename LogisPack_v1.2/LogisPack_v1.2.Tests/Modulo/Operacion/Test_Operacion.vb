
Imports CapaDatos

<TestClass()>
Public Class Test_Operacion

    Dim _ArticuloTest As Articulo
    Dim _AlmacenTest As Almacen
    Dim _Tipo_FacturacionTest As Tipo_Facturacion
    Dim _Tipo_UnidadTest As Tipo_Unidad
    Dim _ClienteTest As Cliente
    Dim _HistoricoTest As Historico


    ''' <summary>
    ''' Método que se invoca para inicializar auitomaticamente una prueba
    ''' </summary>
    <TestInitialize>
    Public Sub Inicializar()

        _ClienteTest = Mgr_Cliente_Test.Get_Cliente1()
        _Tipo_FacturacionTest = Mgr_TipoFacturacion_Test.Get_TipoFacturacion1()
        _Tipo_UnidadTest = Mgr_TipoUnidad_Test.Get_Tipo_Unidad1()
        Mgr_Articulo_Test.Inicializar(_ArticuloTest, _AlmacenTest, _Tipo_FacturacionTest, _Tipo_UnidadTest, _ClienteTest)
    End Sub

    ''' <summary>
    ''' Método que se invoca para finalizar auitomaticamente una prueba
    ''' </summary>
    <TestCleanup>
    Public Sub Finalizar()
        Mgr_Operacion_Test.Finalizar(_Tipo_FacturacionTest, _Tipo_UnidadTest, _ClienteTest, _HistoricoTest)
    End Sub

    ''' <summary>
    ''' Método que se ejecuta para registrar una operacion de entrada
    ''' </summary>
    <TestMethod()> Public Sub Registrar_Operacion_Entrada()

        Mgr_Operacion_Test.Inicializar(_ArticuloTest, _HistoricoTest, Val_Operacion.Entrada.ToString)

        Dim _HistoricoBD = Mgr_Historico.Get_Operacion(_HistoricoTest.id_historico)

        Assert.AreEqual(_HistoricoBD.id_historico, _HistoricoTest.id_historico)
        Assert.AreEqual(_HistoricoBD.fecha_transaccion, _HistoricoTest.fecha_transaccion)
        Assert.AreEqual(_HistoricoBD.cantidad_transaccion, _HistoricoTest.cantidad_transaccion)
        Assert.AreEqual(_HistoricoBD.referencia_ubicacion, _HistoricoTest.referencia_ubicacion)
        Assert.AreEqual(_HistoricoBD.documento_transaccion, _HistoricoTest.documento_transaccion)
        Assert.AreEqual(_HistoricoBD.tipo_transaccion, _HistoricoTest.tipo_transaccion)

    End Sub

    ''' <summary>
    ''' Método que se ejecuta para registrar una operacion de salida
    ''' </summary>
    <TestMethod()> Public Sub Registrar_Operacion_Salida()

        Mgr_Operacion_Test.Inicializar(_ArticuloTest, _HistoricoTest, Val_Operacion.Salida.ToString)

        Dim _HistoricoBD = Mgr_Historico.Get_Operacion(_HistoricoTest.id_historico)

        Assert.AreEqual(_HistoricoBD.id_historico, _HistoricoTest.id_historico)
        Assert.AreEqual(_HistoricoBD.fecha_transaccion, _HistoricoTest.fecha_transaccion)
        Assert.AreEqual(_HistoricoBD.cantidad_transaccion, _HistoricoTest.cantidad_transaccion)
        Assert.AreEqual(_HistoricoBD.referencia_ubicacion, _HistoricoTest.referencia_ubicacion)
        Assert.AreEqual(_HistoricoBD.documento_transaccion, _HistoricoTest.documento_transaccion)
        Assert.AreEqual(_HistoricoBD.tipo_transaccion, _HistoricoTest.tipo_transaccion)

    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en operacion, con filtro de almacen
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_OperacionByAlmacen()

        Mgr_Operacion_Test.Inicializar(_ArticuloTest, _HistoricoTest, Val_Operacion.Entrada.ToString)

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteOperacion("Nombrev", Val_Operacion.Filtro_Almacen.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en operacion, con filtro de cliente
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_OperacionByCliente()

        Mgr_Operacion_Test.Inicializar(_ArticuloTest, _HistoricoTest, Val_Operacion.Entrada.ToString)

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteOperacion("Nombrev", Val_Operacion.Filtro_Cliente.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

    ''' <summary>
    ''' Prueba que se ejecuta para validar el webservice autocomplete en operacion, con filtro de articulo
    ''' </summary>
    <TestMethod()> Public Sub Autocomplete_OperacionByArticulo()

        Mgr_Operacion_Test.Inicializar(_ArticuloTest, _HistoricoTest, Val_Operacion.Entrada.ToString)

        Dim _miServicio As WebService1 = New WebService1()

        Dim _ListaItems As List(Of String) = _miServicio.AutocompleteOperacion("ArtPrueb", Val_Operacion.Filtro_Articulo.ToString(), 1)

        Assert.AreEqual(1, _ListaItems.Count())
    End Sub

End Class
