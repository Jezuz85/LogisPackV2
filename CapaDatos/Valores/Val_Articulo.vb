Public Class Val_Articulo

    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub
    Public Overrides Function ToString() As String
        Return Key
    End Function

    '------------------------------------------------------------------
    '------------------------NOMBRES DE LOS MODALES--------------------
    '------------------------------------------------------------------
    Public Shared ReadOnly DeleteModal As Val_Articulo = New Val_Articulo("DeleteModal")
    Public Shared ReadOnly DeleteModalScript As Val_Articulo = New Val_Articulo("DeleteModalScript")

    '------------------------------------------------------------------
    '------------------------URL DEL MODULO ARTICULO-------------------
    '------------------------------------------------------------------
    Public Shared ReadOnly URL_Crear As Val_Articulo = New Val_Articulo("Crear.aspx")
    Public Shared ReadOnly URL_Detalles As Val_Articulo = New Val_Articulo("Detalles.aspx?id=")
    Public Shared ReadOnly URL_Editar As Val_Articulo = New Val_Articulo("Editar.aspx?id=")

    '------------------------------------------------------------------
    '------------------------FILTROS DE LA LISTA DEL CAMPO BUSCAR------
    '------------------------------------------------------------------
    Public Shared ReadOnly Filtro_Cliente As Val_Articulo = New Val_Articulo("Cliente")
    Public Shared ReadOnly Filtro_Almacen As Val_Articulo = New Val_Articulo("Almacen")
    Public Shared ReadOnly Filtro_Codigo As Val_Articulo = New Val_Articulo("Codigo")
    Public Shared ReadOnly Filtro_Nombre As Val_Articulo = New Val_Articulo("Nombre")

    '------------------------------------------------------------------
    '------------------------VALORES PARA PASAR AL DROPDOWNLIST--------
    '------------------------------------------------------------------
    Public Shared ReadOnly Id_Art As Val_Articulo = New Val_Articulo("id_articulo")
    Public Shared ReadOnly Nom_Art As Val_Articulo = New Val_Articulo("nombre")

    '------------------------------------------------------------------
    '------------------------TIPO DE ARTICULO EXISTENTE----------------
    '------------------------------------------------------------------
    Public Shared ReadOnly Tipo_Normal As Val_Articulo = New Val_Articulo("Normal")
    Public Shared ReadOnly Tipo_Picking As Val_Articulo = New Val_Articulo("Picking")

    '------------------------------------------------------------------
    '------------------------NOMBRE DE LOS VIEWSTATE-------------------
    '------------------------------------------------------------------
    Public Shared ReadOnly contUbicacion As Val_Articulo = New Val_Articulo("contUbicacion")
    Public Shared ReadOnly CurrentTable As Val_Articulo = New Val_Articulo("CurrentTable")

    '------------------------------------------------------------------
    '------------------------ID DE LOS CONTROLES DEL MODULO------------
    '------------------------------------------------------------------
    Public Shared ReadOnly btnAddFilaUbicacion As Val_Articulo = New Val_Articulo("btnAddFilaUbicacion")
    Public Shared ReadOnly btnEliminarFila As Val_Articulo = New Val_Articulo("btnEliminarFila")
    Public Shared ReadOnly ddlTipoArticulo As Val_Articulo = New Val_Articulo("ddlTipoArticulo")
    Public Shared ReadOnly ddlCliente As Val_Articulo = New Val_Articulo("ddlCliente")
    Public Shared ReadOnly ddlAlmacen As Val_Articulo = New Val_Articulo("ddlAlmacen")
    Public Shared ReadOnly txtZona As Val_Articulo = New Val_Articulo("txtZona")
    Public Shared ReadOnly txtEstante As Val_Articulo = New Val_Articulo("txtEstante")
    Public Shared ReadOnly txtFila As Val_Articulo = New Val_Articulo("txtFila")
    Public Shared ReadOnly txtColumna As Val_Articulo = New Val_Articulo("txtColumna")
    Public Shared ReadOnly txtPanel As Val_Articulo = New Val_Articulo("txtPanel")
    Public Shared ReadOnly txtRefUbi As Val_Articulo = New Val_Articulo("txtRefUbi")

    '------------------------------------------------------------------
    '------------------------NOMBRE DE LA HOJA EN EXCEL A CARGAR-------
    '------------------------------------------------------------------
    Public Shared ReadOnly NombreHoja As Val_Articulo = New Val_Articulo("Articulos")

End Class
