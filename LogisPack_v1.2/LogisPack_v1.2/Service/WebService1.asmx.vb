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
    Public Function AutocompleteOperacion(prefixText As String, count As Integer, ByVal contextKey As String) As List(Of String)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim Consulta = contexto.Articulo.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()

        If contextKey <> 1 Then
            Consulta = contexto.Articulo.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower) And
                                                       model.Almacen.id_cliente = contextKey).ToList()
        End If

        Dim listArticulos As List(Of String) = New List(Of String)()
        For Each item In Consulta
            listArticulos.Add(item.nombre)
        Next

        Return listArticulos

    End Function

    <WebMethod()>
    Public Function AutocompleteAlmacen(prefixText As String, count As Integer, ByVal contextKey As String) As List(Of String)

        Dim parametros As String() = contextKey.Split("|")

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim opcion As String = parametros(1)

        Dim listArticulos As List(Of String) = New List(Of String)()

        Dim Consulta = contexto.Almacen.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()

        If parametros(1) = "codigo" Then

            Consulta = contexto.Almacen.Where(Function(model) model.codigo.ToLower.Contains(prefixText.ToLower)).ToList()
            listArticulos.Clear()

        ElseIf parametros(1) = "Cliente" Then
            Dim ConsultaCli = contexto.Cliente.Where(Function(model) model.nombre.ToLower.Contains(prefixText.ToLower)).ToList()

            Dim query = ConsultaCli.GroupBy(Function(model) New With {Key model.nombre}).ToList()

            listArticulos.Clear()

            If parametros(0) <> 1 Then
                ConsultaCli = ConsultaCli.Where(Function(x) x.id_cliente = parametros(0)).ToList()
            End If

            For Each item In ConsultaCli
                listArticulos.Add(item.nombre)
            Next
            Return listArticulos

        End If

        If parametros(0) <> 1 Then
            Consulta = Consulta.Where(Function(x) x.id_cliente = parametros(0)).ToList()
        End If
        For Each item In Consulta

            If parametros(1) = "codigo" Then
                listArticulos.Add(item.codigo)
            ElseIf parametros(1) = "Cliente" Then
                listArticulos.Add(item.Cliente.nombre)
            Else
                listArticulos.Add(item.nombre)
            End If

        Next


        Return listArticulos

    End Function
End Class