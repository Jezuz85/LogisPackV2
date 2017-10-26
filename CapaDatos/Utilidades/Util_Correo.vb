
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Public Class Util_Correo

    Public Shared Sub EnviarCorreo(cuerpoEmail As StringBuilder, _Subject As String, _emailFrom As String, _contraseña As String,
            _emailTo As String, _host As String, _port As Integer)

        Try

            Dim mensaje As MailMessage = New MailMessage(_emailFrom, _emailTo)
            mensaje.Subject = _Subject
            mensaje.IsBodyHtml = True
            mensaje.Body = cuerpoEmail.ToString()


            Dim _smtp As SmtpClient = New SmtpClient()
            Dim _smtpUserInfo As NetworkCredential = New NetworkCredential()

            _smtp.Host = _host
            _smtp.UseDefaultCredentials = True
            _smtp.Port = _port
            _smtp.Credentials = New NetworkCredential(_emailFrom, _contraseña)
            _smtp.EnableSsl = True

            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True

            _smtp.Send(mensaje)
            mensaje.Dispose()

        Catch ex As Exception
            Console.WriteLine("" & ex.ToString())
        End Try

    End Sub

End Class
