Public Class Mensajes

    Private Key As String

    Public Shared ReadOnly Registrar As Mensajes = New Mensajes("Add")
    Public Shared ReadOnly Editar As Mensajes = New Mensajes("Edit")
    Public Shared ReadOnly Eliminar As Mensajes = New Mensajes("Delete")
    Public Shared ReadOnly Detalles As Mensajes = New Mensajes("View")


    Public Shared ReadOnly RutaArticulos As Mensajes = New Mensajes("../../Archivos/Articulos/")

    Public Shared ReadOnly AddExito As Mensajes = New Mensajes("EXITO!!! Se Agregó el registro exitosamente")
    Public Shared ReadOnly AddFalla As Mensajes = New Mensajes("ERROR!!! No se pudo agregar el registro ")
    Public Shared ReadOnly EditExito As Mensajes = New Mensajes("EXITO!!! Se Actualizó el registro exitosamente")
    Public Shared ReadOnly EditFalla As Mensajes = New Mensajes("ERROR!!! No se pudo actualizar el registro ")
    Public Shared ReadOnly DeleteExito As Mensajes = New Mensajes("EXITO!!! Se Eliminó el registro exitosamente")
    Public Shared ReadOnly DeleteFalla As Mensajes = New Mensajes("ERROR!!! No se pudo eliminar el registro ")

    Private Sub New(key As String)
        Me.Key = key
    End Sub

    Public Overrides Function ToString() As String
        Return Key
    End Function

End Class
