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
    Public Function Autocomplete(prefixText As String, count As Integer, ByVal contextKey As String) As List(Of String)

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
    Public Function GetStates(prefixText As String, count As Integer) As List(Of String)

        Dim states As List(Of String) = New List(Of String)()

        states.Add("Alabama")
        states.Add("California")
        states.Add("North Dakota")
        states.Add("Alaska")
        Return states
    End Function

End Class