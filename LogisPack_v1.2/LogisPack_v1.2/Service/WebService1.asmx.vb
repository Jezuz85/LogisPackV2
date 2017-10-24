Imports System.Web.Services
Imports System.ComponentModel
Imports CapaDatos
Imports System.Web.Script.Services

<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
<ScriptService()>
Public Class WebService1
    Inherits WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hola a todos"
    End Function

    <WebMethod()>
    Public Function AutocompleteOperacion(prefixText As String, ByVal Filtro As String, ByVal Cliente As String) As List(Of String)

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim listArticulos As List(Of String) = New List(Of String)()
        listArticulos.Clear()

        Dim ConsultaArticulo = contexto.Articulo.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()

        If Filtro = Val_Operacion.Filtro_Articulo.ToString Then
            ConsultaArticulo = contexto.Articulo.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()

            If Cliente <> 1 Then
                ConsultaArticulo = ConsultaArticulo.Where(Function(x) x.Almacen.Cliente.id_cliente = Cliente).ToList()
            End If

            For Each item In ConsultaArticulo
                listArticulos.Add(item.nombre)
            Next
            Return listArticulos

        ElseIf Filtro = Val_Operacion.Filtro_Almacen.ToString Then
            Dim ConsultaAlm = contexto.Almacen.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()
            Dim query = ConsultaAlm.GroupBy(Function(model) New With {Key model.nombre}).ToList()

            If Cliente <> 1 Then
                ConsultaAlm = ConsultaAlm.Where(Function(x) x.Cliente.id_cliente = Cliente).ToList()
            End If

            For Each item In ConsultaAlm
                listArticulos.Add(item.nombre)
            Next
            Return listArticulos

        ElseIf Filtro = Val_Operacion.Filtro_Cliente.ToString Then

            Dim ConsultaCli = contexto.Cliente.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()
            Dim query = ConsultaCli.GroupBy(Function(model) New With {Key model.nombre}).ToList()

            If Cliente <> 1 Then
                ConsultaCli = ConsultaCli.Where(Function(x) x.id_cliente = Cliente).ToList()
            End If

            For Each item In ConsultaCli
                listArticulos.Add(item.nombre)
            Next
            Return listArticulos

        End If

        Return listArticulos

    End Function

    <WebMethod()>
    Public Function AutocompleteAlmacen(prefixText As String, ByVal Filtro As String, ByVal Cliente As String) As List(Of String)


        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim listArticulos As List(Of String) = New List(Of String)()
        listArticulos.Clear()

        Dim Consulta = contexto.Almacen.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()

        If Filtro = Val_Almacen.Filtro_Codigo.ToString Then
            Consulta = contexto.Almacen.Where(Function(model) model.codigo.ToLower.Contains(prefixText.ToLower)).ToList()

        ElseIf Filtro = Val_Almacen.Filtro_Coeficiente.ToString Then
            Consulta = contexto.Almacen.Where(Function(model) model.coeficiente_volumetrico = prefixText).ToList()

        ElseIf Filtro = Val_Almacen.Filtro_Nombre.ToString Then
            Consulta = contexto.Almacen.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()

        ElseIf Filtro = Val_Almacen.Filtro_Cliente.ToString Then

            Dim ConsultaCli = contexto.Cliente.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()
            Dim query = ConsultaCli.GroupBy(Function(model) New With {Key model.nombre}).ToList()

            If Cliente <> 1 Then
                ConsultaCli = ConsultaCli.Where(Function(x) x.id_cliente = Cliente).ToList()
            End If

            For Each item In ConsultaCli
                listArticulos.Add(item.nombre)
            Next
            Return listArticulos

        End If

        If Cliente <> 1 Then
            Consulta = Consulta.Where(Function(x) x.id_cliente = Cliente).ToList()
        End If

        For Each item In Consulta

            If Filtro = Val_Almacen.Filtro_Codigo.ToString Then
                listArticulos.Add(item.codigo)
            ElseIf Filtro = Val_Almacen.Filtro_Cliente.ToString Then
                listArticulos.Add(item.Cliente.nombre)
            ElseIf Filtro = Val_Almacen.Filtro_Coeficiente.ToString Then
                listArticulos.Add(item.nombre)
            End If

        Next


        Return listArticulos

    End Function

    <WebMethod()>
    Public Function AutocompleteCliente(prefixText As String, ByVal Filtro As String, ByVal Cliente As String) As List(Of String)


        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim listArticulos As List(Of String) = New List(Of String)()
        listArticulos.Clear()

        Dim Consulta = contexto.Cliente.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()

        If Filtro = Val_Cliente.Filtro_Codigo.ToString Then
            Consulta = contexto.Cliente.Where(Function(model) model.codigo.ToLower.Contains(prefixText.ToLower)).ToList()

        ElseIf Filtro = Val_Cliente.Filtro_Nombre.ToString Then

            Dim ConsultaCli = contexto.Cliente.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()
            Dim query = ConsultaCli.GroupBy(Function(model) New With {Key model.nombre}).ToList()

            If Cliente <> 1 Then
                ConsultaCli = ConsultaCli.Where(Function(x) x.id_cliente = Cliente).ToList()
            End If

            For Each item In ConsultaCli
                listArticulos.Add(item.nombre)
            Next
            Return listArticulos

        End If

        If Cliente <> 1 Then
            Consulta = Consulta.Where(Function(x) x.id_cliente = Cliente).ToList()
        End If

        For Each item In Consulta

            If Filtro = Val_Cliente.Filtro_Codigo.ToString Then
                listArticulos.Add(item.codigo)
            ElseIf Filtro = Val_Cliente.Filtro_Nombre.ToString Then
                listArticulos.Add(item.nombre)
            End If

        Next


        Return listArticulos

    End Function

    <WebMethod()>
    Public Function AutocompleteTipoFacturacion(prefixText As String, ByVal Filtro As String, ByVal Cliente As String) As List(Of String)


        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim listArticulos As List(Of String) = New List(Of String)()
        listArticulos.Clear()

        Dim Consulta = contexto.Tipo_Facturacion.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()

        If Filtro = Val_TipoFacturacion.Filtro_Nombre.ToString Then
            Consulta = contexto.Tipo_Facturacion.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()
        End If

        For Each item In Consulta

            If Filtro = Val_TipoFacturacion.Filtro_Nombre.ToString Then
                listArticulos.Add(item.nombre)
            End If

        Next


        Return listArticulos

    End Function

    <WebMethod()>
    Public Function AutocompleteTipoUnidad(prefixText As String, ByVal Filtro As String, ByVal Cliente As String) As List(Of String)


        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim listArticulos As List(Of String) = New List(Of String)()
        listArticulos.Clear()

        Dim Consulta = contexto.Tipo_Unidad.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()

        If Filtro = Val_TipoUnidad.Filtro_Nombre.ToString Then
            Consulta = contexto.Tipo_Unidad.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()
        End If

        For Each item In Consulta

            If Filtro = Val_TipoUnidad.Filtro_Nombre.ToString Then
                listArticulos.Add(item.nombre)
            End If

        Next


        Return listArticulos

    End Function





End Class