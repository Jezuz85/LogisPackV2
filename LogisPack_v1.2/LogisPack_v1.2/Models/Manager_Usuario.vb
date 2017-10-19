Imports System.Security.Principal
Imports CapaDatos
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class Manager_Usuario

    Public Shared Function ValidarAutenticado(ByRef User As IPrincipal) As Boolean

        If (User.Identity.IsAuthenticated) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function ValidarRol(ByRef User As IPrincipal, Rol As String) As Boolean

        If (User.Identity.IsAuthenticated) Then

            Dim contexto As ApplicationDbContext = New ApplicationDbContext()
            Dim userManager = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(contexto))
            Dim s = userManager.GetRoles(User.Identity.GetUserId)

            If (s(0).ToString() = Rol) Then
                Return True
            Else
                Return False
            End If

        Else
            Return False
        End If

    End Function

    Public Shared Function GetUserId(ByRef User As IPrincipal) As String
        Dim contexto As ApplicationDbContext = New ApplicationDbContext()
        Dim userManager = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(contexto))
        Return User.Identity.GetUserId
    End Function

    ''' <summary>
    ''' Metodo que recibe un id del usuario y lo consulta desde la Base de datos, 
    ''' devuelve el nombre del cliente asociado al usuario si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function GetNombreCliente(_id As String) As String

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim _usuario = contexto.AspNetUsers.Where(Function(model) model.Id = _id).SingleOrDefault()

        Return _usuario.Cliente.nombre

    End Function

    Public Shared Function GetRol_User(_Page As Page) As String

        Dim contexto As ApplicationDbContext = New ApplicationDbContext()
        Dim userManager = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(contexto))
        Dim s = userManager.GetRoles(_Page.User.Identity.GetUserId)

        Return s(0).ToString()
    End Function

    Public Shared Sub ValidarMenu(_Page As Page, _Master As MasterPage)

        If Manager_Usuario.ValidarAutenticado(_Page.User) Then

            Util_Menu.CargarMenu(Manager_Usuario.GetRol_User(_Page), _Master)

        Else
            Util_Menu.OcultarMenu(_Master)
        End If

    End Sub
End Class
