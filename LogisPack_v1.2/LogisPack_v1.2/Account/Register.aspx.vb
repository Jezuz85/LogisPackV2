Imports CapaDatos
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin

Partial Public Class Register
    Inherits Page

    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then

            idCliente = Mgr_Usuario.Get_Cliente_Usuario(Manager_Usuario.GetUserId(User))

            If IsPostBack = False Then
                Mgr_Usuario.Llenar_Lista_Rol(ddlRol)
                Mgr_Cliente.Llenar_Lista(ddlCliente, idCliente)
            End If

        Else
            Response.Redirect(Val_Paginas.Login.ToString)
        End If


    End Sub

    Protected Sub CreateUser_Click(sender As Object, e As EventArgs)

        Dim userName As String = Email.Text

        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()

        Dim signInManager = Context.GetOwinContext().Get(Of ApplicationSignInManager)()

        Dim user = New ApplicationUser() With {
            .UserName = userName,
            .Email = userName,
            .id_cliente = Convert.ToInt32(ddlCliente.SelectedValue)
        }

        Dim result = manager.Create(user, Password.Text)

        If result.Succeeded Then

            Dim _user = manager.FindByName(userName)
            manager.AddToRole(_user.Id, ddlRol.SelectedValue)

            ' Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite https://go.microsoft.com/fwlink/?LinkID=320771
            ' Dim code = manager.GenerateEmailConfirmationToken(user.Id)
            ' Dim callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request)
            ' manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=""" & callbackUrl & """>aquí</a>.")

            signInManager.SignIn(user, isPersistent:=False, rememberBrowser:=False)
            IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
        Else
            ErrorMessage.Text = result.Errors.FirstOrDefault()
        End If
    End Sub

End Class

