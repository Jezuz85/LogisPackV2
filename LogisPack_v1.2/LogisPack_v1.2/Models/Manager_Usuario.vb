Imports System.Security.Principal
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

End Class
