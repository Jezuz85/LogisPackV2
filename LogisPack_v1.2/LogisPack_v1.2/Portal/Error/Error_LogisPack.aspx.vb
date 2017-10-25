Imports System.Net
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
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

            Try

                Dim mensaje As MailMessage = New MailMessage("jesuse.garcia@direcline.com", "jesuse.garcia@direcline.com")
                mensaje.Subject = "Error Logis Pack"
                mensaje.IsBodyHtml = True


                Dim cuerpoEmail As StringBuilder = New StringBuilder()
                cuerpoEmail.AppendLine("Ha ocurrido un error Inesperado")
                cuerpoEmail.AppendLine()
                cuerpoEmail.AppendLine(ViewState("LastError").ToString())
                mensaje.Body = cuerpoEmail.ToString()


                Dim _smtp As SmtpClient = New SmtpClient()
                Dim _smtpUserInfo As NetworkCredential = New NetworkCredential()

                _smtp.Host = "smtp.direcline.com"
                _smtp.UseDefaultCredentials = True
                _smtp.Port = 587
                _smtp.Credentials = New NetworkCredential("jesuse.garcia@direcline.com", "Jgardir1")
                _smtp.EnableSsl = True

                ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True

                _smtp.Send(mensaje)
                mensaje.Dispose()

            Catch ex As Exception
                Console.WriteLine("" & ex.ToString())
            End Try


        End If

    End Sub

End Class