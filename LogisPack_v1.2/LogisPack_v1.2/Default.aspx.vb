Imports CapaDatos
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then

            Dim contexto As ApplicationDbContext = New ApplicationDbContext()
            Dim userManager = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(contexto))
            Dim s = userManager.GetRoles(User.Identity.GetUserId)
            Utilidades_Menu.CargarMenu(s(0).ToString(), Master)

        Else
            Utilidades_Menu.OcultarMenu(Master)
        End If

    End Sub
End Class