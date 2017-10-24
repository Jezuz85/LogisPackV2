
Imports System.Web.UI.WebControls

Public Class Util_DropDownList

    ''' <summary>
    ''' Metodo que setea los valors de value y text a un dropdownlist
    ''' </summary>
    Public Shared Sub Set_Text_Value_List(ByRef _DropDownList As DropDownList, _query As Object, _text As String, _value As String)

        _DropDownList.DataValueField = _value
        _DropDownList.DataTextField = _text
        _DropDownList.DataSource = _query
        _DropDownList.DataBind()

    End Sub

    ''' <summary>
    ''' Metodo que llena los dropdownlist del filtro de busqeuda
    ''' </summary>
    Public Shared Sub Llenar_FiltroBusqueda(ByRef _DropDownList As DropDownList, Pagina As String)

        If Pagina = Val_Paginas.Almacen_Index.ToString Then

            _DropDownList.Items.Insert(0, New ListItem(Val_Almacen.Filtro_Codigo.ToString, Val_Almacen.Filtro_Codigo.ToString))
            _DropDownList.Items.Insert(1, New ListItem(Val_Almacen.Filtro_Cliente.ToString, Val_Almacen.Filtro_Cliente.ToString))
            _DropDownList.Items.Insert(2, New ListItem(Val_Almacen.Filtro_Coeficiente.ToString, Val_Almacen.Filtro_Coeficiente.ToString))
            _DropDownList.Items.Insert(3, New ListItem(Val_Almacen.Filtro_Nombre.ToString, Val_Almacen.Filtro_Nombre.ToString))

        ElseIf Pagina = Val_Paginas.Cliente_Index.ToString Then
            _DropDownList.Items.Insert(0, New ListItem(Val_Cliente.Filtro_Codigo.ToString, Val_Cliente.Filtro_Codigo.ToString))
            _DropDownList.Items.Insert(1, New ListItem(Val_Cliente.Filtro_Nombre.ToString, Val_Cliente.Filtro_Nombre.ToString))

        ElseIf Pagina = Val_Paginas.Articulo_Index.ToString Then
            _DropDownList.Items.Insert(0, New ListItem(Val_Articulo.Filtro_Almacen.ToString, Val_Articulo.Filtro_Almacen.ToString))
            _DropDownList.Items.Insert(1, New ListItem(Val_Articulo.Filtro_Cliente.ToString, Val_Articulo.Filtro_Cliente.ToString))
            _DropDownList.Items.Insert(2, New ListItem(Val_Articulo.Filtro_Codigo.ToString, Val_Articulo.Filtro_Codigo.ToString))
            _DropDownList.Items.Insert(3, New ListItem(Val_Articulo.Filtro_Nombre.ToString, Val_Articulo.Filtro_Nombre.ToString))

        ElseIf Pagina = Val_Paginas.Operacion_Index.ToString Then
            _DropDownList.Items.Insert(0, New ListItem(Val_Operacion.Filtro_Almacen.ToString, Val_Operacion.Filtro_Almacen.ToString))
            _DropDownList.Items.Insert(1, New ListItem(Val_Operacion.Filtro_Articulo.ToString, Val_Operacion.Filtro_Articulo.ToString))
            _DropDownList.Items.Insert(2, New ListItem(Val_Operacion.Filtro_Cliente.ToString, Val_Operacion.Filtro_Cliente.ToString))

        ElseIf Pagina = Val_Paginas.TipoFacturacion_Index.ToString Then
            _DropDownList.Items.Insert(0, New ListItem(Val_TipoFacturacion.Filtro_Nombre.ToString, Val_TipoFacturacion.Filtro_Nombre.ToString))

        ElseIf Pagina = Val_Paginas.TipoUnidad_Index.ToString Then
            _DropDownList.Items.Insert(0, New ListItem(Val_TipoUnidad.Filtro_Nombre.ToString, Val_TipoUnidad.Filtro_Nombre.ToString))
        End If

    End Sub

End Class
