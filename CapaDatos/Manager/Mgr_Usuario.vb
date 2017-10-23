Imports System.Web.UI.WebControls

Public Class Mgr_Usuario

    '------------------------------------------------------------------
    '------------------------FUNCIONES DEL DROPDOWNLIST----------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que recibe un objeto DropDownlist vacio  y lo devuelve con los datos de 
    ''' todos los roles existentes en la base de datos
    ''' </summary>
    Public Shared Sub Llenar_Lista_Rol(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.AspNetRoles
                     Where AL.Id <> 1
                     Select
                         AL.Id,
                         AL.Name
                    ).ToList()

        Util_ControlesDinamicos.Set_Text_Value_List(DropDownList1, query, "Name", "Name")
    End Sub

    '------------------------------------------------------------------
    '------------------------FUNCIONES GETTER--------------------------
    '------------------------------------------------------------------
    ''' <summary>
    ''' Metodo que recibe un id del usuario y lo consulta desde la Base de datos, 
    ''' devuelve el id del cliente asociado al usuario si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Cliente_Usuario(_id As String) As Integer

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim _usuario = contexto.AspNetUsers.Where(Function(model) model.Id = _id).SingleOrDefault()

        Return _usuario.id_cliente

    End Function


End Class
