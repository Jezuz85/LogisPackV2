Imports CapaDatos

Public Class Error_LogisPack
    Inherits Page

    Private contexto As LogisPackEntities = New LogisPackEntities()
    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            idCliente = Mgr_Usuario.Get_Cliente_Usuario(Manager_Usuario.GetUserId(User))

            If Manager_Usuario.ValidarRol(User, Val_Rol.Admin.ToString) Then

                If Request.QueryString("aspxerrorpath") IsNot Nothing Then

                    Dim _error As String = Request.QueryString("aspxerrorpath")

                End If

                If IsPostBack = False Then
                    LoadError(Server.GetLastError())
                End If
            Else
                Response.Redirect(Val_Paginas.Inicio.ToString)
            End If
        Else
            Response.Redirect(Val_Paginas.Login.ToString)
        End If

    End Sub

    Protected Sub LoadError(objError As Exception)

        If objError IsNot Nothing Then

            Dim lastError As StringBuilder = New StringBuilder()

            If objError.Message IsNot Nothing Then

                lastError.AppendLine("Message:")
                lastError.AppendLine(objError.Message)
                lastError.AppendLine()

            End If

            If objError.InnerException IsNot Nothing Then

                lastError.AppendLine("InnerException:")
                lastError.AppendLine(objError.InnerException.ToString())
                lastError.AppendLine()
            End If

            If objError.Source IsNot Nothing Then

                lastError.AppendLine("Source:")
                lastError.AppendLine(objError.Source)
                lastError.AppendLine()
            End If

            If objError.StackTrace IsNot Nothing Then

                lastError.AppendLine("StackTrace:")
                lastError.AppendLine(objError.StackTrace)
                lastError.AppendLine()

            End If

            ViewState.Add("LastError", lastError.ToString())

            Dim cuerpoEmail As StringBuilder = New StringBuilder()
            cuerpoEmail.AppendLine("Ha ocurrido un error Inesperado")
            cuerpoEmail.AppendLine()
            cuerpoEmail.AppendLine(ViewState("LastError").ToString())

            Util_Correo.EnviarCorreo(cuerpoEmail, "Error Logis Pack", Val_Correo.EmailFrom.ToString, Val_Correo.Contraseña.ToString,
                Val_Correo.EmailTo.ToString, Val_Correo.Host.ToString, Convert.ToInt32(Val_Correo.Puerto.ToString))
        End If

    End Sub

End Class