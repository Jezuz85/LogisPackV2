Imports CapaDatos
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)
        Else
            Response.Redirect(Paginas.Login.ToString)
        End If

    End Sub
End Class